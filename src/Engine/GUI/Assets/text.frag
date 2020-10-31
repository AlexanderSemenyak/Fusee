﻿#version 300 es

#ifdef GL_ES
precision highp float;
#endif

in vec2 vUV;
in vec3 vMVNormal;

uniform sampler2D AlbedoTexture;
uniform vec2 AlbedoTextureTiles;
uniform vec4 Albedo;
uniform float AlbedoMix;

out vec4 outColor;

void main()
{
	vec3 N = normalize(vMVNormal);
	vec3 L = vec3(0.0, 0.0, -1.0);

    vec3 lightColor = vec3(1.0, 1.0, 1.0);
    vec4 objCol = vec4(0.0, 0.0, 0.0, 1.0);
    vec4 texCol = texture(AlbedoTexture, vUV * AlbedoTextureTiles);
    vec3 mixCol = mix(Albedo.xyz, texCol.xyz, AlbedoMix);    
    objCol = vec4(mixCol, texCol.a);
    vec4 Idif = vec4(max(dot(N, L), 0.0) * lightColor, 1.0);

	outColor = Idif * objCol;
}