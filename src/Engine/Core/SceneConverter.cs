using Fusee.Math.Core;
using Fusee.Xene;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fusee.Serialization
{
    public interface IConvertiableSceneContainer<T, K> where K : class, IConvertiableSceneComponent, new()
    {
        string Name { get; set; }
        List<T> Children { get; set; }
        List<K> Components { get; set; }
    }

    public interface IConvertiableSceneComponent
    {
        string Info { get; set; }
    }

    public class SceneConverter<T, K> : SceneVisitor where T : class, IConvertiableSceneContainer<T, K>, new()
                                                     where K : class, IConvertiableSceneComponent, new()
    {
        private T _convertedScene;
        private Stack<T> _predecessors;
        protected T _currentNode;

        protected override void PopState()
        {
            _predecessors.Pop();
        }

        public static string ToString(T snc)
        {
            var sb = new StringBuilder();
            foreach (var c in snc.Children)
                sb.Append(PrintSceneContainer(c));
            
            return sb.ToString();
        }
     
        private static string PrintSceneContainer(T snc)
        {
            var currentBuilder = new StringBuilder();

            currentBuilder.AppendLine(snc.Name);

            if (snc.Components != null)
                foreach (var cmp in snc.Components)
                    currentBuilder.AppendLine($"\t {cmp.Info}");

            if(snc.Children != null)
                foreach (var child in snc?.Children)
                    currentBuilder.Append(PrintSceneContainer(child));

            return currentBuilder.ToString();
        }

        /// <summary>
        /// Traverses the given SceneContainer and creates new graph by converting and/or splitting its components into the
        /// IConvertiableSceneContainer/IConvertiableSceneComponent equivalents.
        /// </summary>
        /// <param name="sc">The SceneContainer to convert.</param>
        /// <returns>The converted scene</returns>
        public T Convert(SceneContainer sc)
        {
            _predecessors = new Stack<T>();
            _convertedScene = new T {
                Name = sc.Header.ToString()
            };

            Traverse(sc.Children);

            return _convertedScene;
        }

        #region Visitors
        /// <summary>
        /// Converts the scene node container.
        /// </summary>
        /// <param name="snc"></param>
        [VisitMethod]
        public void ConvSceneNodeContainer(SceneNodeContainer snc)
        {
            if (_predecessors.Count != 0)
            {
                var parent = _predecessors.Peek();

                if (parent.Children == null)
                    parent.Children = new List<T>();

                _currentNode = new T { Name = (snc.Name == string.Empty ? "[SceneContainer]: Unnamed" : $"[SceneContainer]: {snc.Name}") };
                parent.Children.Add(_currentNode);
                _predecessors.Push(_currentNode);
            }
            else //Add first node to SceneContainer
            {
                _predecessors.Push(new T { Name = (CurrentNode.Name == null ? "[SceneContainer]: Unnamed" : $"[SceneContainer]: {CurrentNode.Name}") });
                _currentNode = _predecessors.Peek();
                if (_convertedScene.Children != null)
                    _convertedScene.Children.Add(_currentNode);
                else
                    _convertedScene.Children = new List<T> { _currentNode };
            }
        }

        ///<summary>
        ///Converts the transform component.
        ///</summary>
        [VisitMethod]
        public virtual void ConvTransform(TransformComponent transform)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the material.
        /// </summary>
        /// <param name="matComp"></param>
        [VisitMethod]
        public virtual void ConvMaterial(MaterialComponent matComp)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the materials light component.
        /// </summary>
        /// <param name="matComp"></param>
        [VisitMethod]
        public virtual void ConvMaterial(MaterialLightComponent matComp)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the physically based rendering component
        /// </summary>
        /// <param name="matComp"></param>
        [VisitMethod]
        public virtual void ConvMaterial(MaterialPBRComponent matComp)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the shader.
        /// </summary>
        [VisitMethod]
        public virtual void ConvProjComp(ProjectionComponent pc)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the mesh.
        /// </summary>
        /// <param name="mesh">The mesh to convert.</param>
        [VisitMethod]
        public virtual void ConvMesh(Mesh mesh)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Adds the light component.
        /// </summary>
        /// <param name="lightComponent"></param>
        [VisitMethod]
        public virtual void ConvLight(LightComponent lightComponent)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Adds the bone component.
        /// </summary>
        /// <param name="bone"></param>
        [VisitMethod]
        public virtual void ConvBone(BoneComponent bone)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }

        /// <summary>
        /// Converts the weight component.
        /// </summary>
        /// <param name="weight"></param>
        [VisitMethod]
        public virtual void ConvWeight(WeightComponent weight)
        {
            throw new NotImplementedException("This component has no conversion method, please implement it via override and use GetCurrentNode() to access the currently used node");
        }
        #endregion
    }
    
    public class ASCIISceneComponent : IConvertiableSceneContainer<ASCIISceneComponent, ASCIISceneComponentContainer>
    {
        public string Name { get; set; }
        public List<ASCIISceneComponent> Children { get; set; }
        public List<ASCIISceneComponentContainer> Components { get; set; }
    }

    public class ASCIISceneComponentContainer : IConvertiableSceneComponent
    {
        public string Info { get; set; }
    }


    public class TextConverter : SceneConverter<ASCIISceneComponent, ASCIISceneComponentContainer>
    {
        [VisitMethod]
        public override void ConvTransform(TransformComponent transform)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[TransformComponent] Translation: {transform.Translation}, Rotation: {transform.Rotation}, Scale: {transform.Scale}"
            });
        }

        [VisitMethod]
        public override void ConvMaterial(MaterialComponent matComp)
        {        
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

                string diff = "";
                string spec = "";
                string bump = "";

            if(matComp.HasDiffuse)
                diff = $"[MaterialComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if(matComp.HasSpecular)
                spec = $"[MaterialComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if(matComp.HasBump)
                bump = $"[MaterialComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        [VisitMethod]
        public override void ConvMaterial(MaterialLightComponent matComp)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            string diff = "";
            string spec = "";
            string bump = "";

            if (matComp.HasDiffuse)
                diff = $"[MaterialLightComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if (matComp.HasSpecular)
                spec = $"[MaterialLightComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if (matComp.HasBump)
                bump = $"[MaterialLightComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        [VisitMethod]
        public override void ConvMaterial(MaterialPBRComponent matComp)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            string diff = "";
            string spec = "";
            string bump = "";

            if (matComp.HasDiffuse)
                diff = $"[MaterialPBRComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if (matComp.HasSpecular)
                spec = $"[MaterialPBRComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if (matComp.HasBump)
                bump = $"[MaterialPBRComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        [VisitMethod]
        public override void ConvMesh(Mesh mesh)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[Mesh Component] Vertices length: {mesh.Vertices.Length}, Triangles length: {mesh.Triangles.Length}, Normals length: {mesh.Normals.Length}"
            });
        }

        [VisitMethod]
        public override void ConvProjComp(ProjectionComponent pc)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[ProjectionComponent] Projection method: {pc.ProjectionMethod}, Projection FOV: {pc.Fov}, Projection NearZ/FarZ: {pc.ZNear}/{pc.ZFar}"
            });
        }

        public override void ConvBone(BoneComponent bone)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[BoneComponent]"
            });
        }

        [VisitMethod]
        public override void ConvLight(LightComponent lightComponent)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[LightComponent]"
            });
        }

        [VisitMethod]
        public override void ConvWeight(WeightComponent weight)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<ASCIISceneComponentContainer>();

            _currentNode.Components.Add(new ASCIISceneComponentContainer
            {
                Info = $"[WeightComponent]"
            });
        }
    }
        
    public class JSONSceneComponent : IConvertiableSceneContainer<JSONSceneComponent, JSONSceneComponentContainer>
    {
        public string Name { get; set; }
        public List<JSONSceneComponent> Children { get; set; }        
        public List<JSONSceneComponentContainer> Components { get; set; }
    }
   
    public class JSONSceneComponentContainer : IConvertiableSceneComponent
    {
        public string Info { get; set; }
    }

    public class JSONMeshComponentContainer : JSONSceneComponentContainer
    {
       
        public string Info { get; set; }

        public float3[] Vertices { get; set; }
        public ushort[] Triangles { get; set; }
        public float3[] Normals { get; set; }
    }

    public class JSONConverter : SceneConverter<JSONSceneComponent, JSONSceneComponentContainer>
    {
        [VisitMethod]
        public override void ConvTransform(TransformComponent transform)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = $"[TransformComponent] Translation: {transform.Translation}, Rotation: {transform.Rotation}, Scale: {transform.Scale}"
            });
        }

        [VisitMethod]
        public override void ConvMaterial(MaterialComponent matComp)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            string diff = "";
            string spec = "";
            string bump = "";

            if (matComp.HasDiffuse)
                diff = $"[MaterialComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if (matComp.HasSpecular)
                spec = $"[MaterialComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if (matComp.HasBump)
                bump = $"[MaterialComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        public override void ConvMaterial(MaterialLightComponent matComp)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            string diff = "";
            string spec = "";
            string bump = "";

            if (matComp.HasDiffuse)
                diff = $"[MaterialLightComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if (matComp.HasSpecular)
                spec = $"[MaterialLightComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if (matComp.HasBump)
                bump = $"[MaterialLightComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        [VisitMethod]
        public override void ConvMaterial(MaterialPBRComponent matComp)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            string diff = "";
            string spec = "";
            string bump = "";

            if (matComp.HasDiffuse)
                diff = $"[MaterialPBRComponent, Diffuse] Color: {matComp.Diffuse.Color}, Texture: {matComp.Diffuse.Texture}, Mix: {matComp.Diffuse.Mix}\n";
            if (matComp.HasSpecular)
                spec = $"[MaterialPBRComponent, Specular] Color: {matComp.Specular.Color}, Texture: {matComp.Specular.Texture}, Mix: {matComp.Specular.Mix}\n";
            if (matComp.HasBump)
                bump = $"[MaterialPBRComponent, Bump] Intensity: {matComp.Bump.Intensity}, Texture: {matComp.Bump.Texture}";

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = diff + spec + bump
            });
        }

        [VisitMethod]
        public override void ConvMesh(Mesh mesh)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONMeshComponentContainer
            {
                Info = $"[Mesh Component] Vertices length: {mesh.Vertices.Length}, Triangles length: {mesh.Triangles.Length}, Normals length: {mesh.Normals.Length}",
                Vertices = mesh.Vertices,
                Triangles = mesh.Triangles,
                Normals = mesh.Normals                
            });
        }

        [VisitMethod]
        public override void ConvProjComp(ProjectionComponent pc)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = $"[ProjectionComponent] Projection method: {pc.ProjectionMethod}, Projection FOV: {pc.Fov}, Projection NearZ/FarZ: {pc.ZNear}/{pc.ZFar}"
            });
        }

        [VisitMethod]
        public override void ConvBone(BoneComponent bone)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = $"[BoneComponent]"
            });
        }

        [VisitMethod]
        public override void ConvLight(LightComponent lightComponent)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = $"[LightComponent]"
            });
        }

        [VisitMethod]
        public override void ConvWeight(WeightComponent weight)
        {
            if (_currentNode.Components == null)
                _currentNode.Components = new List<JSONSceneComponentContainer>();

            _currentNode.Components.Add(new JSONSceneComponentContainer
            {
                Info = $"[WeightComponent]"
            });
        }
    }
}
