using ProtoBuf;

namespace Fusee.Serialization.V2
{
    /// <summary>
    /// Base class for components. Each node (<see cref="SceneNodeContainer"/>) contains a list of components of various types.
    /// </summary>
    [ProtoContract]

    [ProtoInclude(100, typeof(TransformComponent))]
    [ProtoInclude(101, typeof(Mesh))]
    [ProtoInclude(102, typeof(MaterialComponent))]
    [ProtoInclude(103, typeof(LightComponent))]
    [ProtoInclude(104, typeof(WeightComponent))]
    [ProtoInclude(105, typeof(AnimationComponent))]
    [ProtoInclude(106, typeof(BoneComponent))]

    public class FusComponent
    {
        /// <summary>
        /// The name of this component.
        /// </summary>
        [ProtoMember(1)]
        public string Name;
    }

}