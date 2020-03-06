﻿using System.Collections.Generic;
using Fusee.Jometri;
using Fusee.Xene;
using System;
using Fusee.Engine.Core.ShaderShards;
using Fusee.Engine.Common;
using Fusee.Serialization.V1;
using Fusee.Serialization;
using Fusee.Math.Core;

namespace Fusee.Engine.Core
{
    /// <summary>
    /// Use ConVSceneToHighLevel to create new high level graph from a low level graph (made out of scene nodes and components) in order
    /// to have each visited element converted and/or split into its high level, render-ready components.
    /// </summary>
    public class ConvertSceneGraph : Visitor<FusNode, FusComponent>
    {
        private Scene _convertedScene;
        private Stack<FusNode> _predecessors;
        private SceneNode _currentNode;

        private Dictionary<Material, ShaderEffect> _matMap;
        private Dictionary<MaterialPBR, ShaderEffect> _pbrComponent;
        private Stack<FusNode> _boneContainers;

        /// <summary>
        /// Method is called when going up one hierarchy level while traversing. Override this method to perform pop on any self-defined state.
        /// </summary>
        protected override void PopState()
        {
            _predecessors.Pop();
        }

        /// <summary>
        /// Traverses the given SceneContainer and creates new high level graph by converting and/or splitting its components into the high level equivalents.
        /// </summary>
        /// <param name="sc">The SceneContainer to convert.</param>
        /// <returns></returns>
        public Scene Convert(FusFile sc)
        {
            _predecessors = new Stack<FusNode>();
            _convertedScene = new Scene();

            _matMap = new Dictionary<Material, ShaderEffect>();
            _pbrComponent = new Dictionary<MaterialPBR, ShaderEffect>();
            _boneContainers = new Stack<FusNode>();

            var payload = (FusScene)sc.Contents;

            Traverse(payload.Children);

            return _convertedScene;
        }

        #region Visitors

        /// <summary>
        /// Converts the fus node container.
        /// </summary>
        /// <param name="snc"></param>
        [VisitMethod]
        public void ConvFusNode(FusNode snc)
        {
            if (_predecessors.Count != 0)
            {
                var parent = _predecessors.Peek();

                if (parent.Children == null)
                    parent.Children = new List<FusNode>();

                _currentNode = new SceneNode { Name = snc.Name };
                //parent.Children.Add(_currentNode);
                //_predecessors.Push(_currentNode);
            }
            else //Add first node to SceneContainer
            {
                // TODO: implement and test!

                _predecessors.Push(new FusNode { Name = CurrentNode.Name });
                _predecessors.Peek().AddNode(new FusNode { Name = CurrentNode.Name });
                
                //_currentNode = _predecessors.Peek();
                //if (_convertedScene.Children != null)
                //    _convertedScene.Children.Add(_currentNode);
                //else
                //    _convertedScene.Children = new List<SceneNodeContainer> { _currentNode };
            }
        }

        ///<summary>
        ///Converts the transform component.
        ///</summary>
        [VisitMethod]
        public void ConvTransform(FusTransform transform)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<SceneComponent>();

            _currentNode.Components.Add(new Transform());
        }

        /// <summary>
        /// Converts the material.
        /// </summary>
        /// <param name="matComp"></param>
        [VisitMethod]
        public void ConvMaterial(FusMaterial matComp)
        {
            var effect = LookupMaterial(matComp);
            _currentNode.Components.Add(effect);
        }

        /// <summary>
        /// Converts the physically based rendering component
        /// </summary>
        /// <param name="matComp"></param>
        [VisitMethod]
        public void ConvMaterial(FusMaterialPBR matComp)
        {
            var effect = LookupMaterial(matComp);
            _currentNode.Components.Add(effect);
        }

        /// <summary>
        /// Converts the shader.
        /// </summary>
        [VisitMethod]
        public void ConvCamComp(FusCamera cc)
        {
            // convert camera

            _currentNode.Components.Add(new Camera(ProjectionMethod.PERSPECTIVE, 0.1f, 1000, M.PiOver2));
        }

        /// <summary>
        /// Converts the mesh.
        /// </summary>
        /// <param name="mesh">The mesh to convert.</param>
        [VisitMethod]
        public void ConvMesh(FusMesh mesh)
        {
            // convert mesh
            

            if (_currentNode.Components == null)
                _currentNode.Components = new List<SceneComponent>();

            var currentNodeEffect = _currentNode.GetComponent<ShaderEffect>();

            if (currentNodeEffect?.GetEffectParam(UniformNameDeclarations.BumpTextureName) != null)
            {
                mesh.Tangents = new Mesh().CalculateTangents();
                mesh.BiTangents = new Mesh().CalculateBiTangents();
            }

            _currentNode.Components.Add(new Mesh());
        }

        /// <summary>
        /// Adds the light component.
        /// </summary>
        /// <param name="lightComponent"></param>
        [VisitMethod]
        public void ConvLight(FusLight lightComponent)
        {
            _currentNode.Components.Add(new Light());
        }

        /// <summary>
        /// Adds the bone component.
        /// </summary>
        /// <param name="bone"></param>
        [VisitMethod]
        public void ConvBone(FusBone bone)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<SceneComponent>();

            _currentNode.Components.Add(new Bone());

            // Collect all bones, later, when a WeightComponent is found, we can set all Joints
            //_boneContainers.Push(_currentNode);
        }

        /// <summary>
        /// Converts the weight component.
        /// </summary>
        /// <param name="weight"></param>
        [VisitMethod]
        public void ConVWeight(FusWeight w)
        {
            var weight = new Weight();

            // check if we have bones
            if (_boneContainers.Count >= 1)
            {
                if (weight.Joints == null) // initialize joint container
                    weight.Joints = new List<SceneNode>();

                // set all bones found until this WeightComponent
                //while (_boneContainers.Count != 0)
                //    weight.Joints.Add(_boneContainers.Pop());
            }

            _currentNode.Components.Add(new Weight());
        }
        #endregion

        #region Make ShaderEffect

        private ShaderEffect LookupMaterial(FusMaterial m)
        {
            var mc = new Material();
            if (_matMap.TryGetValue(mc, out var mat)) return mat;
            mat = ShaderCodeBuilder.MakeShaderEffectFromMatCompProto(mc, _currentNode.GetWeights()); // <- broken
            _matMap.Add(mc, mat);
            return mat;
        }

        private ShaderEffect LookupMaterial(FusMaterialPBR m)
        {
            var mc = new MaterialPBR();
            if (_pbrComponent.TryGetValue(mc, out var mat)) return mat;
            mat = ShaderCodeBuilder.MakeShaderEffectFromMatCompProto(mc, _currentNode.GetWeights());
            _pbrComponent.Add(mc, mat);
            return mat;
        }

        #endregion
    }
}
