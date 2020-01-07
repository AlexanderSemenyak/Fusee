using System;
using Xunit;
using Fusee.Math.Core;
using Fusee.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Fusee.Xene;

namespace Fusee.Serialization.Test
{
    public class SimpleSerialization
    {
        [Fact]
        public void V1_SimpleScene()
        {
            SceneContainer scene = new SceneContainer
            {
                Header = new SceneHeader
                {
                    Version = 1,
                    CreationDate = DateTime.Today.ToString(),
                    Generator = "SerializationTest",
                    CreatedBy = "Fusee Test Code"
                },
                Children = new List<SceneNodeContainer>
                {
                    new SceneNodeContainer
                    {
                        Name = "DaCube",
                        Components = new List<SceneComponentContainer>
                        {
                            new TransformComponent
                            {
                                Rotation = new float3(0, 0, 0),
                                Scale = new float3(1, 1, 1),
                                Translation = new float3(0, 0, 0)
                            },

                            new MaterialComponent
                            {
                                Diffuse  = new MatChannelContainer { Color = new float4(0.1f, 0.2f, 0.3f, 1) },
                                Specular = new SpecularChannelContainer { Color = new float4(0.1f, 0.2f, 0.3f, 1), Shininess = 1 },
                            },

                            SimpleMeshes.CreateCuboid(new float3(10, 2, 10))
                        }
                    }
                }
            };

            // Serialize original
            var streamOrig = new MemoryStream();
            ProtoBuf.Serializer.Serialize(streamOrig, scene);

            // Copy serialized stream
            var streamTemp = new MemoryStream(streamOrig.GetBuffer());
            streamTemp.Position = 0;

            // Deserialize copied stream into copied scene
            var sceneCopy = ProtoBuf.Serializer.Deserialize<SceneContainer>(streamTemp);

            // Serialize copy
            var streamCopy = new MemoryStream();
            ProtoBuf.Serializer.Serialize(streamCopy, sceneCopy);

            // Compare Serializations
            Assert.Equal(streamOrig.GetBuffer(), streamCopy.GetBuffer());
        }
    }

}

