using ProtoBuf;
using System.Collections.Generic;

namespace Fusee.Serialization.V2
{
    /// <summary>
    /// .fus File contents making up a scene.
    /// </summary>
    [ProtoContract]
    public class FusScene : FusContents
    {
        #region Payload
        /// <summary>
        /// Overall list of components used in this scene. This list contains the .fus file's physical payload.
        /// Indices into this list are used as references at other places in the .fus file.
        /// </summary>
        [ProtoMember(1)]
        public List<FusComponent> ComponentList;

        /// <summary>
        /// List of indices of all components being <see cref="FusMesh"/> instances.
        /// </summary>
        [ProtoMember(2)]
        public List<int> MeshList;

        /// <summary>
        /// List of indices of all components being <see cref="FusTransform"/> instances.
        /// </summary>
        [ProtoMember(3)]
        public List<int> TransformList;

        /// <summary>
        /// List of indices of all components being <see cref="FusMaterial"/> instances.
        /// </summary>
        [ProtoMember(4)]
        public List<int> MaterialList;

        /// <summary>
        /// List of root nodes of the scene graph making up this scene.
        /// </summary>
        [ProtoMember(5)]
        public List<FusNode> Children;
        #region Payload

        
    }
}