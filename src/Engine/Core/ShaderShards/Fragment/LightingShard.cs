﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Fusee.Serialization;

namespace Fusee.Engine.Core.ShaderShards.Fragment
{
    public static class LightingShard
    {
        ///The maximal number of lights we can render when using the forward pipeline.
        public const int NumberOfLightsForward = 8;

        public static string FragMainMethod(ShaderEffectProps effectProps)
        {
            string fragColorAlpha = effectProps.MatProbs.HasDiffuse ? $"{UniformNameDeclarations.DiffuseColorName}.w" : "1.0";

            var fragMainBody = new List<string>
            {
                "vec4 result = ambientLighting(0.2);", //ambient component
                $"for(int i = 0; i < {NumberOfLightsForward};i++)",
                "{",
                "if(allLights[i].isActive == 0) continue;",
                "vec3 currentPosition = allLights[i].position;",
                "vec4 currentIntensities = allLights[i].intensities;",
                "vec3 currentConeDirection = allLights[i].direction;",
                "float currentAttenuation = allLights[i].maxDistance;",
                "float currentStrength = allLights[i].strength;",
                "float currentOuterConeAngle = allLights[i].outerConeAngle;",
                "float currentInnerConeAngle = allLights[i].innerConeAngle;",
                "int currentLightType = allLights[i].lightType; ",
                "result += ApplyLight(currentPosition, currentIntensities, currentConeDirection, ",
                "currentAttenuation, currentStrength, currentOuterConeAngle, currentInnerConeAngle, currentLightType);",
                "}",

                 effectProps.MatProbs.HasDiffuseTexture ? $"oFragmentColor = result;" : $"oFragmentColor = vec4(result.rgb, {UniformNameDeclarations.DiffuseColorName}.w);",
            };

            return ShaderShardUtil.MainMethod(fragMainBody);
        }

        public static string LightStructDeclaration()
        {
            var lightStruct = @"
            struct Light 
            {
                vec3 position;
                vec3 positionWorldSpace;
                vec4 intensities;
                vec3 direction;
                vec3 directionWorldSpace;
                float maxDistance;
                float strength;
                float outerConeAngle;
                float innerConeAngle;
                int lightType;
                int isActive;
                int isCastingShadows;
                float bias;
            };
            ";
            return lightStruct + $"uniform Light allLights[{NumberOfLightsForward}];";

        }

        public static string AmbientLightMethod()
        {
            var methodBody = new List<string>
            {
                "return vec4(DiffuseColor.xyz * ambientCoefficient, 1.0);"
            };

            return (GLSL.CreateMethod(GLSL.Type.Vec4, "ambientLighting",
                new[] { GLSL.CreateVar(GLSL.Type.Float, "ambientCoefficient") }, methodBody));
        }

        public static string DiffuseLightMethod(ShaderEffectProps effectProps)
        {
            var methodBody = new List<string>
            {
                "float diffuseTerm = dot(N, L);"
            };

            //TODO: Test alpha blending between diffuse and texture
            if (effectProps.MatProbs.HasDiffuseTexture)
                methodBody.Add(
                    $"vec4 blendedCol = mix({UniformNameDeclarations.DiffuseColorName}, texture({UniformNameDeclarations.DiffuseTextureName}, vUV), {UniformNameDeclarations.DiffuseMixName});" +
                    $"return blendedCol * max(diffuseTerm, 0.0) * intensities;");
            else
                methodBody.Add($"return vec4({UniformNameDeclarations.DiffuseColorName}.rgb * intensities.rgb * max(diffuseTerm, 0.0), 1.0);");

            return GLSL.CreateMethod(GLSL.Type.Vec4, "diffuseLighting",
                new[]
                {
                    GLSL.CreateVar(GLSL.Type.Vec3, "N"), GLSL.CreateVar(GLSL.Type.Vec3, "L"),
                    GLSL.CreateVar(GLSL.Type.Vec4, "intensities")
                }, methodBody);

        }

        public static string SpecularLightMethod()
        {
            var methodBody = new List<string>
            {
                "float specularTerm = 0.0;",
                "if(dot(N, L) > 0.0)",
                "{",
                "   // half vector",
                "   vec3 H = normalize(V + L);",
                $"  specularTerm = pow(max(0.0, dot(H, N)), {UniformNameDeclarations.SpecularShininessName});",
                "}",
                $"return vec4(({UniformNameDeclarations.SpecularColorName}.rgb * {UniformNameDeclarations.SpecularIntensityName} * intensities.rgb) * specularTerm, 1.0);"
            };

            return GLSL.CreateMethod(GLSL.Type.Vec4, "specularLighting",
                new[]
                {
                    GLSL.CreateVar(GLSL.Type.Vec3, "N"), GLSL.CreateVar(GLSL.Type.Vec3, "L"), GLSL.CreateVar(GLSL.Type.Vec3, "V"),
                    GLSL.CreateVar(GLSL.Type.Vec4, "intensities")
                }, methodBody);

        }

        /// <summary>
        /// Replaces Specular Calculation with Cook-Torrance-Shader
        /// </summary>
        public static string PbrSpecularLightMethod(MaterialPBRComponent mc)
        {
            var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };

            var delta = 0.0000001;

            var roughness = mc.RoughnessValue + delta; // always float, never int!
            var fresnel = mc.FresnelReflectance + delta;
            var k = mc.DiffuseFraction + delta;

            var methodBody = new List<string>
            {
                $"float roughnessValue = {roughness.ToString(nfi)}; // 0 : smooth, 1: rough", // roughness 
                $"float F0 = {fresnel.ToString(nfi)}; // fresnel reflectance at normal incidence", // fresnel => Specular from Blender
                $"float k = 1.0-{k.ToString(nfi)}; // metaliness", // metaliness from Blender
                "float NdotL = max(dot(N, L), 0.0);",
                "float specular = 0.0;",
                "float BlinnSpecular = 0.0;",
                "",
                "if(dot(N, L) > 0.0)",
                "{",
                "     // calculate intermediary values",
                "     vec3 H = normalize(L + V);",
                "     float NdotH = max(dot(N, H), 0.0); ",
                "     float NdotV = max(dot(N, L), 0.0); // note: this is NdotL, which is the same value",
                "     float VdotH = max(dot(V, H), 0.0);",
                "     float mSquared = roughnessValue * roughnessValue;",
                "",
                "",
                "",
                "",
                "     // -- geometric attenuation",
                "     //[Schlick's approximation of Smith's shadow equation]",
                "     float k= roughnessValue * sqrt(0.5 * 3.14159265);",
                "     float one_minus_k= 1.0 - k;",
                "     float geoAtt = ( NdotL / (NdotL * one_minus_k + k) ) * ( NdotV / (NdotV * one_minus_k + k) );",
                "",
                "     // -- roughness (or: microfacet distribution function)",
                "     // Trowbridge-Reitz or GGX, GTR2",
                "     float a2 = mSquared * mSquared;",
                "     float d = (NdotH * a2 - NdotH) * NdotH + 1.0;",
                "     float roughness = a2 / (3.14 * d * d);",
                "",
                "     // -- fresnel",
                "     // [Schlick 1994, An Inexpensive BRDF Model for Physically-Based Rendering]",
                "     float fresnel = pow(1.0 - VdotH, 5.0);",
                $"    fresnel = clamp((50.0 * {UniformNameDeclarations.SpecularColorName}.y), 0.0, 1.0) * fresnel + (1.0 - fresnel);",
                "",
                $"     specular = (fresnel * geoAtt * roughness) / (NdotV * NdotL * 3.14);",
                "     ",
                "}",
                "",
                $"return intensities * {UniformNameDeclarations.SpecularColorName} * (k + specular * (1.0-k));"
            };

            return GLSL.CreateMethod(GLSL.Type.Vec4, "specularLighting",
                new[]
                {
                    GLSL.CreateVar(GLSL.Type.Vec3, "N"), GLSL.CreateVar(GLSL.Type.Vec3, "L"), GLSL.CreateVar(GLSL.Type.Vec3, "V"),
                    GLSL.CreateVar(GLSL.Type.Vec4, "intensities")
                }, methodBody);
        }

        /// <summary>
        /// Wraps all the lighting methods into a single one
        /// </summary>
        public static string ApplyLightMethod(MaterialComponent mc, ShaderEffectProps effectProps)
        {
            /*  var bumpNormals = new List<string>
              {
                  "///////////////// BUMP MAPPING, object space ///////////////////",
                  $"vec3 bumpNormalsDecoded = normalize(texture(BumpTexture, vUV).rgb * 2.0 - 1.0) * (1.0-{BumpIntensityName});",
                  "vec3 N = normalize(vec3(bumpNormalsDecoded.x, bumpNormalsDecoded.y, -bumpNormalsDecoded.z));"
              }; */

            var bumpNormals = new List<string>
            {
                "///////////////// BUMP MAPPING, tangent space ///////////////////",
                $"vec3 N = ((texture(BumpTexture, vUV).rgb * 2.0) - 1.0f) * vec3({UniformNameDeclarations.BumpIntensityName}, {UniformNameDeclarations.BumpIntensityName}, 1.0);",
                "N = (N.x * vec3(vT)) + (N.y * vB) + (N.z * vNormal);",
                "N = normalize(N);"
            };

            var normals = new List<string>
            {
                "vec3 N = normalize(vNormal);"
            };

            var applyLightParamsWithoutNormals = new List<string>
            {
                //"vec3 N = normalize(vNormal);",
                "vec3 L = vec3(0.0, 0.0, 0.0);",
                "if(lightType == 1){L = -normalize(direction);}",
                "else{ L = normalize(position - vViewPos);}",
                "vec3 V = normalize(-vViewPos.xyz);",
                "if(lightType == 3) {",
                "   L = normalize(vec3(0.0,0.0,-1.0));",
                "}",
                "vec2 o_texcoords = vUV;",
                "",
                "vec4 Idif = vec4(0);",
                "vec4 Ispe = vec4(0);",
                ""
            };

            var applyLightParams = new List<string>();
            applyLightParams.AddRange(effectProps.MatProbs.HasBump ? bumpNormals : normals);

            applyLightParams.AddRange(applyLightParamsWithoutNormals);


            if (effectProps.MatProbs.HasDiffuse)
                applyLightParams.Add("Idif = diffuseLighting(N, L, intensities);");


            if (effectProps.MatProbs.HasSpecular)
                applyLightParams.Add("Ispe = specularLighting(N, L, V, intensities);");


            var attenuation = new List<string>
            {
                "float distanceToLight = length(position - vViewPos.xyz);",
                "float distance = pow(distanceToLight / maxDistance, 2.0);",
                "float att = (clamp(1.0 - pow(distance, 2.0), 0.0, 1.0)) / (pow(distance, 2.0) + 1.0);",
            };

            var pointLight = new List<string>
            {
                "lighting = (Idif * att) + (Ispe * att);",
                "lighting *= strength;"
            };

            //No attenuation!
            var parallelLight = new List<string>
            {
               "lighting = Idif + Ispe;",
                "lighting *= strength;"
            };

            var spotLight = new List<string>
            { 
            //cone component 
            "float lightToSurfaceAngleCos = dot(direction, -L);",

            "float epsilon = cos(innerConeAngle) - cos(outerConeAngle);",
            "float t = (lightToSurfaceAngleCos - cos(outerConeAngle)) / epsilon;",

            "att *= clamp(t, 0.0, 1.0);",
            "",

                "lighting = (Idif * att) + (Ispe * att);",
                "lighting *= strength;"
            };

            // - Disable GammaCorrection for better colors
            /*var gammaCorrection = new List<string>() 
            {
                "vec3 gamma = vec3(1.0/2.2);",
                "result = pow(result, gamma);"
            };*/

            var methodBody = new List<string>();
            methodBody.AddRange(applyLightParams);
            methodBody.Add("vec4 lighting = vec4(0);");
            methodBody.Add("");
            methodBody.AddRange(attenuation);
            methodBody.Add("if(lightType == 0) // PointLight");
            methodBody.Add("{");
            methodBody.AddRange(pointLight);
            methodBody.Add("}");
            methodBody.Add("else if(lightType == 1 || lightType == 3) // ParallelLight or LegacyLight");
            methodBody.Add("{");
            methodBody.AddRange(parallelLight);
            methodBody.Add("}");
            methodBody.Add("else if(lightType == 2) // SpotLight");
            methodBody.Add("{");
            methodBody.AddRange(spotLight);
            methodBody.Add("}");
            methodBody.Add("");
            //methodBody.AddRange(gammaCorrection); // - Disable GammaCorrection for better colors
            methodBody.Add("");

            methodBody.Add("return lighting;");

            return GLSL.CreateMethod(GLSL.Type.Vec4, "ApplyLight",
                new[]
                {
                    GLSL.CreateVar(GLSL.Type.Vec3, "position"), GLSL.CreateVar(GLSL.Type.Vec4, "intensities"),
                    GLSL.CreateVar(GLSL.Type.Vec3, "direction"), GLSL.CreateVar(GLSL.Type.Float, "maxDistance"),
                    GLSL.CreateVar(GLSL.Type.Float, "strength"), GLSL.CreateVar(GLSL.Type.Float, "outerConeAngle"),
                    GLSL.CreateVar(GLSL.Type.Float, "innerConeAngle"), GLSL.CreateVar(GLSL.Type.Int, "lightType"),
                }, methodBody);
        }
    }
}
