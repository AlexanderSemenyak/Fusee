using ProtoBuf;

namespace Fusee.Serialization.V2
{
    /// <summary>
    /// Marker component (contains no data). If contained within a node, the node 
    /// serves as a bone in a bone animation.
    /// </summary>
    [ProtoContract]
    public class FusBone : FusComponent
    {
        /// <summary>
        /// The name of this component.
        /// Needed for blender exporter
        /// </summary>
        [ProtoMember(1)]
        public string Name;
    }
}
