using ProtoBuf;
using System.Collections.Generic;

namespace Fusee.Serialization.V2
{
    /// <summary>
    /// Nodes are the building blocks for scene graphs within .fus files.
    /// </summary>
    [ProtoContract]
    public class FusNode
    {
        #region Payload
        /// <summary>
        /// Indices into the <see cref="FusScene"/>'s list of components that make up this node.
        /// </summary>
        [ProtoMember(1)]
        public List<int> Components;

        /// <summary>
        /// This node's children. Possibly empty.
        /// </summary>
        [ProtoMember(2)]
        public List<FusNode> Children;
        #endregion
    }
}