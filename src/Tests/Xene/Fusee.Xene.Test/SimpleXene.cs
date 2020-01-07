using System;
using Xunit;
using Fusee.Math.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Fusee.Xene;

namespace Fusee.Xene.Test
{
    public class SimpleXene
    {

        [Fact]
        public void SingleNodeEnumeratorThrowsOnReset()
        {
            TestNode node = new TestNode();
           
            var singleNodeEnumerator = Xene.SceneVisitorHelpers.SingleRootEnumerator(node);

            // See https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator.reset?view=netcore-3.1:
            // "The Reset method is provided for COM interoperability. It does not necessarily need to be implemented;
            // instead, the implementer can simply throw a NotSupportedException."
            Assert.Throws<NotSupportedException>(() => singleNodeEnumerator.Reset());
        }

        [Fact]
        public void SingleNodeEnumerableForEach()
        {
            TestNode node = new TestNode();

            var singleNodeEnumerable = Xene.SceneVisitorHelpers.SingleRootEnumerable(node);

            int i = 0;
            foreach (var curNode in singleNodeEnumerable)
            {
                Assert.Equal(node, curNode);
                i++;
            }

            Assert.Equal(1, i);
        }

        [Fact]
        public void FindNodesSingleRoot()
        {
            TestNode tree = CreateSimpleTestTree();

            IEnumerable<TestNode> findResultChild = tree.FindNodes(node => node.Name.Contains("Child"));
            Assert.Equal(2, findResultChild.Count());

            IEnumerable<TestNode> findResultNode = tree.FindNodes(node => node.Name.Contains("Node"));
            Assert.Equal(2, findResultNode.Count());

        }

        [Fact]
        public void FindNodesListOfRoots()
        {
            var twoRoots = TwoTestTrees();

            IEnumerable<TestNode> findResultChild = twoRoots.FindNodes(node => node.Name.Contains("Child"));

            Assert.Equal(4, findResultChild.Count());
        }

        [Fact]
        public void FindComponentsSingleRootDirect()
        {
            TestNode tree = CreateSimpleTestTree();

            IEnumerable<TestComponent> findComponentsResult2 = tree.FindComponents<TestNode, TestComponent>(comp => comp.Num % 2 == 0);
            Assert.Equal(3, findComponentsResult2.Count());

            IEnumerable<TestComponent> findComponentsResult3 = tree.FindComponents<TestNode, TestComponent>(comp => comp.Num % 3 == 0);
            Assert.Equal(2, findComponentsResult3.Count());
        }

        [Fact]
        public void FindComponentsSingleRootTestFindExtension()
        {
            TestNode tree = CreateSimpleTestTree();

            IEnumerable<TestComponent> findComponentsResult2 = tree.FindComponents(comp => comp.Num % 2 == 0);
            Assert.Equal(3, findComponentsResult2.Count());

            IEnumerable<TestComponent> findComponentsResult3 = tree.FindComponents(comp => comp.Num % 3 == 0);
            Assert.Equal(2, findComponentsResult3.Count());
        }


        private static IEnumerable<TestNode> TwoTestTrees()
        {
            yield return CreateSimpleTestTree();
            yield return CreateSimpleTestTree();
        }

        private static TestNode CreateSimpleTestTree()
        {
            return new TestNode
            {
                Name = "RootNode",
                Children = new TestNode[]
                {
                    new TestNode
                    {
                        Name="ChildNode",
                        Components = new TestComponent[]
                        {
                            new TestComponent{Num = 3},
                        }
                    },
                    new TestNode
                    {
                        Name="ChildNumberTwo",
                        Components = new TestComponent[]
                        {
                            new TestComponent{Num = 4},
                        }
                    },
                },
                Components = new TestComponent[]
                {
                    new TestComponent{Num = 2},
                    new TestComponent{Num = 6}
                }
            };
        }
    }

    internal class TestNode : INode
    {
        public string Name;
        public TestNode[] Children;

        public TestComponent[] Components;

        public IEnumerable<INode> EnumChildren => Children;

        public IEnumerable<IComponent> EnumComponents => Components;
    }

    internal class TestComponent : IComponent
    {
        public int Num;
    }



    internal class TestVisitorV2 : SceneVisitor<TestNode, TestComponent>
    {


    }

    internal static class TestExtensions
    {
        public static IEnumerable<TestComponent> FindComponents(this TestNode root, Predicate<TestComponent> match)
            => root.FindComponents<TestNode, TestComponent>(match);

        public static IEnumerable<TestComponent> FindComponents(this IEnumerable<TestNode> roots, Predicate<TestComponent> match)
            => roots.FindComponents<TestNode, TestComponent>(match);


    }
}

