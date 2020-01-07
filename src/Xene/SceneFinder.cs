using System;
using System.Collections;
using System.Collections.Generic;
// using Fusee.Serialization;

namespace Fusee.Xene
{
    /* public static class SceneFinderExtensionsOrig
    {
        // Unfortunate construct, but there seems no other way. What we really needed here is a MixIn to make 
        // a INode or SceneContainer implement IEnumerable (afterwards). All C# offers us is to 
        // define ExtensionMethods returning an IEnumerable<>.
        // Thus we need some class to implement that. Here it is - tada:
        internal class SceneNodeEnumerable<TNode> : IEnumerable<TNode> where TNode : INode
        {
            internal Predicate<TNode> _match;
            internal IEnumerator<INode> _rootList;

            public IEnumerator<TNode> GetEnumerator() { return new SceneNodeFinder<TNode>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        internal class SceneComponentEnumerable<TComponent> : IEnumerable<TComponent> where TComponent : IComponent
        {
            internal Predicate<TComponent> _match;
            internal IEnumerator<INode> _rootList;

            public IEnumerator<TComponent> GetEnumerator() { return new SceneComponentFinder<TComponent>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        internal class SceneNodeWhereComponentEnumerable<TNode, TComponent> : IEnumerable<TNode> where TNode : INode where TComponent : IComponent
        {
            internal Predicate<TComponent> _match;
            internal IEnumerator<INode> _rootList;

            public IEnumerator<TNode> GetEnumerator() { return new SceneNodeWhereComponentFinder<TNode, TComponent>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #region FindNodes
        /// <summary>
        /// Creates an enumerable traversing the tree starting with the given node.
        /// </summary>
        /// <param name="root">The root node where to start the traversal.</param>
        /// <param name="match">The matching predicate. Enumeration will yield on every matching node.</param>
        /// <returns>An enumerable that can be used in foreach statements.</returns>
        public static IEnumerable<INode> FindNodes(this INode root, Predicate<INode> match)
        {
            return new SceneNodeEnumerable<INode> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds nodes of a certain type and matching the given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TNode">The type of nodes to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes of the specified type matching the predicate.</returns>
        public static IEnumerable<TNode> FindNodes<TNode>(this INode root, Predicate<TNode> match) where TNode : INode
        {
            return new SceneNodeEnumerable<TNode> {_match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root)};
        }

        /// <summary>
        /// Finds nodes matching the given search predicate within a list of trees.
        /// </summary>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes matching the predicate.</returns>
        public static IEnumerable<INode> FindNodes(this IEnumerable<INode> rootList, Predicate<INode> match)
        {
            return new SceneNodeEnumerable<INode> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds nodes of a certain type and matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TNode">The type of nodes to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes of the specified type matching the predicate.</returns>
        public static IEnumerable<TNode> FindNodes<TNode>(this IEnumerable<INode> rootList, Predicate<TNode> match) where TNode : INode
        {
            return new SceneNodeEnumerable<TNode> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        #endregion

        #region FindComponents
        /// <summary>
        /// Finds components matching the given search predicate within a trees.
        /// </summary>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components matching the predicate.</returns>
        public static IEnumerable<IComponent> FindComponents(this INode root, Predicate<IComponent> match) 
        {
            return new SceneComponentEnumerable<IComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds components of the specified type and matching the given search predicate within a tree.
        /// </summary>
        /// <typeparam name="TComponent">The type of components to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components of the specified type matching the predicate.</returns>
        public static IEnumerable<TComponent> FindComponents<TComponent>(this INode root, Predicate<TComponent> match) where TComponent : IComponent
        {
            return new SceneComponentEnumerable<TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds components matching the given search predicate within a list of trees.
        /// </summary>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components matching the predicate.</returns>
        public static IEnumerable<IComponent> FindComponents(this IEnumerable<INode> rootList, Predicate<IComponent> match)
        {
            return new SceneComponentEnumerable<IComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds components of the specified type and matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TComponent">The type of components to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components of the specified type matching the predicate.</returns>
        public static IEnumerable<TComponent> FindComponents<TComponent>(this IEnumerable<INode> rootList, Predicate<TComponent> match) where TComponent : IComponent
        {
            return new SceneComponentEnumerable<TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        #endregion


        #region FindNodesWhereComponent
        /// <summary>
        /// Finds all nodes containing one or more components matching a given search predicate within a tree of nodes.
        /// </summary>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<INode> FindNodesWhereComponent(this INode root, Predicate<IComponent> match)
        {
            return new SceneNodeWhereComponentEnumerable<INode, IComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds all nodes containing one or more components matching the specified type and a given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TComponent">The type of the components to look for.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<INode> FindNodesWhereComponent<TComponent>(this INode root, Predicate<TComponent> match) where TComponent : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<INode, TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds all nodes of a certain type containing one or more components matching the specified type and a given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TNode">The type of the nodes to search in.</typeparam>
        /// <typeparam name="TComponent">The type of the components to look for.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes of the specified type containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<TNode> FindNodesWhereComponent<TNode, TComponent>(this INode root, Predicate<TComponent> match)
            where TNode : INode
            where TComponent : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNode, TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds all nodes containing one or more components matching a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<INode> FindNodesWhereComponent(this IEnumerable<INode> rootList, Predicate<IComponent> match)
        {
            return new SceneNodeWhereComponentEnumerable<INode, IComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds all nodes containing one or more components matching the specified type and a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TComponent">The type of the components to look for.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<INode> FindNodesWhereComponent<TComponent>(this IEnumerable<INode> rootList, Predicate<TComponent> match) where TComponent : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<INode, TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds all nodes of a certain type containing one or more components matching the specified type and a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TNode">The type of the nodes to search in.</typeparam>
        /// <typeparam name="TComponent">The type of the components to look for.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes of the specified type containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<TNode> FindNodesWhereComponent<TNode, TComponent>(this IEnumerable<INode> rootList, Predicate<TComponent> match)
            where TNode : INode
            where TComponent : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNode, TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        #endregion

    } */


    /// <summary>
    /// Various extensions methods to find nodes or components within trees of scene nodes.
    /// </summary>
    public static class SceneFinderExtensions
    {
        // Unfortunate construct, but there seems no other way. What we really needed here is a MixIn to make 
        // a INode or SceneContainer implement IEnumerable (afterwards). All C# offers us is to 
        // define ExtensionMethods returning an IEnumerable<>.
        // Thus we need some class to implement that. Here it is - tada:
        internal class SceneNodeEnumerable<TNodeToFind, TNode, TComponent> : IEnumerable<TNodeToFind> 
            where TNodeToFind : TNode
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            internal Predicate<TNodeToFind> _match;
            internal IEnumerator<TNode> _rootList;

            public IEnumerator<TNodeToFind> GetEnumerator() { return new SceneNodeFinder<TNodeToFind, TNode, TComponent>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        internal class SceneComponentEnumerable<TComponentToFind, TNode, TComponent> : IEnumerable<TComponentToFind> 
            where TComponentToFind : TComponent
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            internal Predicate<TComponentToFind> _match;
            internal IEnumerator<TNode> _rootList;

            public IEnumerator<TComponentToFind> GetEnumerator() { return new SceneComponentFinder<TComponentToFind, TNode, TComponent>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        internal class SceneNodeWhereComponentEnumerable<TNodeToFind, TComponentToFind, TNode, TComponent> : IEnumerable<TNodeToFind>
            where TNodeToFind : TNode 
            where TComponentToFind : TComponent
            where TNode : class, INode
            where TComponent : class, IComponent

        {
            internal Predicate<TComponentToFind> _match;
            internal IEnumerator<TNode> _rootList;

            public IEnumerator<TNodeToFind> GetEnumerator() { return new SceneNodeWhereComponentFinder<TNodeToFind, TComponentToFind, TNode, TComponent>(_rootList, _match); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #region FindNodes
        /// <summary>
        /// Creates an enumerable traversing the tree starting with the given node.
        /// </summary>
        /// <typeparam name="TNode">The node base type used in the current tree. Inferred by the instance this method is called upon.</typeparam>
        /// <param name="root">The root node where to start the traversal.</param>
        /// <param name="match">The matching predicate. Enumeration will yield on every matching node.</param>
        /// <returns>An enumerable that can be used in foreach statements.</returns>
        public static IEnumerable<TNode> FindNodes<TNode>(this TNode root, Predicate<TNode> match)
            where TNode : class, INode
        {
            return new SceneNodeEnumerable<TNode, TNode, IComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds nodes of a certain type and matching the given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TNodeToFind">The type of nodes to find.</typeparam>
        /// <typeparam name="TNode">The node base type used in the current tree. Inferred by the instance this method is called upon.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes of the specified type matching the predicate.</returns>
        public static IEnumerable<TNodeToFind> FindNodes<TNodeToFind, TNode>(this TNode root, Predicate<TNodeToFind> match) 
            where TNodeToFind : TNode
            where TNode : class, INode
        {
            return new SceneNodeEnumerable<TNodeToFind, TNode, IComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds nodes matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TNode">The node base type used in the current tree. Inferred by the instance this method is called upon.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes matching the predicate.</returns>
        public static IEnumerable<TNode> FindNodes<TNode>(this IEnumerable<TNode> rootList, Predicate<TNode> match)
            where TNode : class, INode
        {
            return new SceneNodeEnumerable<TNode, TNode, IComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds nodes of a certain type and matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TNodeToFind">The type of nodes to find.</typeparam>
        /// <typeparam name="TNode">The node base type used in the current tree. Inferred by the instance this method is called upon.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes of the specified type matching the predicate.</returns>
        public static IEnumerable<TNodeToFind> FindNodes<TNodeToFind, TNode>(this IEnumerable<TNode> rootList, Predicate<TNodeToFind> match) 
            where TNodeToFind : TNode
            where TNode : class, INode
        {
            return new SceneNodeEnumerable<TNodeToFind, TNode, IComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        #endregion

        #region FindComponents
        /// <summary>Finds components matching the given search predicate within a tree.</summary>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components matching the predicate.</returns>
        public static IEnumerable<TComponent> FindComponents<TNode, TComponent>(this TNode root, Predicate<TComponent> match)
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneComponentEnumerable<TComponent, TNode, TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds components matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components matching the predicate.</returns>
        public static IEnumerable<TComponent> FindComponents<TNode, TComponent>(this IEnumerable<TNode> rootList, Predicate<TComponent> match)
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneComponentEnumerable<TComponent, TNode, TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /* Probably not necessary any more since Xene builds on interfaces INode, IComponent and not on concrete SceneNodeContainer / SceneComponentContainer base types
        /// <summary>
        /// Finds components of the specified type and matching the given search predicate within a tree.
        /// </summary>
        /// <typeparam name="TComponentToFind">The type of components to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components of the specified type matching the predicate.</returns>
        public static IEnumerable<TComponentToFind> FindComponents<TComponentToFind>(this INode root, Predicate<TComponentToFind> match) where TComponentToFind : IComponent
        {
            return new SceneComponentEnumerable<TComponentToFind> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }


        /// <summary>
        /// Finds components of the specified type and matching the given search predicate within a list of trees.
        /// </summary>
        /// <typeparam name="TComponentToFind">The type of components to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All components of the specified type matching the predicate.</returns>
        public static IEnumerable<TComponentToFind> FindComponents<TComponentToFind>(this IEnumerable<INode> rootList, Predicate<TComponentToFind> match) where TComponentToFind : IComponent
        {
            return new SceneComponentEnumerable<TComponentToFind> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        */
        #endregion


        #region FindNodesWhereComponent
        /// <summary>
        /// Finds all nodes containing one or more components matching a given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<TNode> FindNodesWhereComponent<TNode, TComponent>(this TNode root, Predicate<TComponent> match)
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNode, TComponent, TNode, TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds all nodes containing one or more components matching a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<TNode> FindNodesWhereComponent<TNode, TComponent>(this IEnumerable<TNode> rootList, Predicate<TComponent> match)
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNode, TComponent, TNode, TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>Finds all nodes containing one or more components matching a given search predicate within a tree of nodes.</summary>
        /// <typeparam name="TNodeToFind">The concrete type of the nodes to find (and to be returned).</typeparam>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<TNodeToFind> FindNodesWhereComponent<TNodeToFind, TNode, TComponent>(this TNode root, Predicate<TComponent> match)
            where TNodeToFind : TNode
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNodeToFind, TComponent, TNode, TComponent> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

        /// <summary>
        /// Finds all nodes containing one or more components matching a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TNodeToFind">The concrete type of the nodes to find (and to be returned).</typeparam>
        /// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
        /// <typeparam name="TComponent">The type of component to find.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>All nodes containing matching components.</returns>
        public static IEnumerable<TNodeToFind> FindNodesWhereComponent<TNodeToFind, TNode, TComponent>(this IEnumerable<TNode> rootList, Predicate<TComponent> match)
            where TNodeToFind : TNode
            where TNode : class, INode
            where TComponent : class, IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNodeToFind, TComponent, TNode, TComponent> { _match = match, _rootList = rootList.GetEnumerator() };
        }


        /* Probably not necessary any more since Xene builds on interfaces INode, IComponent and not on concrete SceneNodeContainer / SceneComponentContainer base types
        /// <summary>
        /// Finds all nodes of a certain type containing one or more components matching the specified type and a given search predicate within a tree of nodes.
        /// </summary>
        /// <typeparam name="TNodeToFind">The type of the nodes to search in.</typeparam>
        /// <typeparam name="TComponentToFind">The type of the components to look for.</typeparam>
        /// <param name="root">The root node where to start the search.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes of the specified type containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<TNodeToFind> FindNodesWhereComponent<TNodeToFind, TComponentToFind>(this INode root, Predicate<TComponentToFind> match)
            where TNodeToFind : INode
            where TComponentToFind : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNodeToFind, TComponentToFind> { _match = match, _rootList = SceneVisitorHelpers.SingleRootEnumerator(root) };
        }

 

        /// <summary>
        /// Finds all nodes containing one or more components matching the specified type and a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TComponentToFind">The type of the components to look for.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<INode> FindNodesWhereComponent<TComponentToFind>(this IEnumerable<INode> rootList, Predicate<TComponentToFind> match) where TComponentToFind : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<INode, TComponentToFind> { _match = match, _rootList = rootList.GetEnumerator() };
        }

        /// <summary>
        /// Finds all nodes of a certain type containing one or more components matching the specified type and a given search predicate within a list of trees of nodes.
        /// </summary>
        /// <typeparam name="TNodeToFind">The type of the nodes to search in.</typeparam>
        /// <typeparam name="TComponentToFind">The type of the components to look for.</typeparam>
        /// <param name="rootList">The list of root nodes of the trees to search in.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        /// <returns>
        /// All nodes of the specified type containing components matching both, type and predicate.
        /// </returns>
        public static IEnumerable<TNodeToFind> FindNodesWhereComponent<TNodeToFind, TComponentToFind>(this IEnumerable<INode> rootList, Predicate<TComponentToFind> match)
            where TNodeToFind : INode
            where TComponentToFind : IComponent
        {
            return new SceneNodeWhereComponentEnumerable<TNodeToFind, TComponentToFind> { _match = match, _rootList = rootList.GetEnumerator() };
        }
        */
        #endregion

    }




    /// <summary>
    /// Allows various searches over scene graphs. 
    /// This class can be used directly but will be more commonly used by calling one 
    /// of the Find extension methods declared in <see cref="SceneFinderExtensions"/>.
    /// </summary>
    /// <remarks>
    /// Search criteria can be passed as (lambda) predicates matching scene nodes.
    /// Results are returned as enumerator. Instead of directly using this class, users should use one of the FindNodes or
    /// FindComponents extension methods. 
    /// </remarks>
    /// <typeparam name="TNodeToFind">The concrete type of nodes to look for.</typeparam>
    /// <typeparam name="TNode">The concrete base type of nodes used as building blocks for scene graphs.</typeparam>
    /// <typeparam name="TComponent">The concrete base type of components used as building blocks for scene graphs.</typeparam>
    public class SceneNodeFinder<TNodeToFind, TNode, TComponent> : SceneFinderBase<TNodeToFind, TNode, TComponent>, IEnumerator<TNodeToFind>
        where TNodeToFind : TNode
        where TNode : class, INode
        where TComponent : class, IComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneNodeFinder{TNodeToFind, TNode, TComponent}"/> class.
        /// </summary>
        /// <param name="rootList">The root list where to start the seach.</param>
        /// <param name="match">The search predicate. Typically specified as a Lambda expression.</param>
        public SceneNodeFinder(IEnumerator<TNode> rootList, Predicate<TNodeToFind> match) : base(rootList, match) { }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext() { return EnumMoveNextNoComponent();}

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public TNodeToFind Current { get { return (TNodeToFind) CurrentNode; } }
        object IEnumerator.Current { get { return Current; } }

        /// <summary>
        /// Reflected Viserator Callback. Performs the match test on the specified node.
        /// </summary>
        /// <param name="node">The node to check for the match.</param>
        [VisitMethod]
        protected void MatchNode(TNodeToFind node)
        {
            if (_match != null && _match(node))
            {
                YieldOnCurrentNode = true;
            }
        }
        
    }

  
    /// <summary>
    /// Allows various searches over scene graphs. 
    /// This class can be used directly but will be more commonly used by calling one 
    /// of the Find extension methods declared in <see cref="SceneFinderExtensions"/>.
    /// </summary>
    /// <remarks>
    /// Search criteria can be passed as (lambda) predicates matching scene components.
    /// Results are returned as enumerator. Instead of directly using this class, users should use one of the FindNodes or
    /// FindComponents extension methods. 
    /// </remarks>
    /// <typeparam name="TComponentToFind">The concrete type of the components to look for.</typeparam>
    /// <typeparam name="TNode">The concrete base type of nodes used as building blocks for scene graphs.</typeparam>
    /// <typeparam name="TComponent">The concrete base type of components used as building blocks for scene graphs.</typeparam>
    public class SceneComponentFinder<TComponentToFind, TNode, TComponent> : SceneFinderBase<TComponentToFind, TNode, TComponent>, IEnumerator<TComponentToFind> 
        where TComponentToFind : TComponent
        where TNode : class, INode
        where TComponent : class, IComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneComponentFinder{TComponentToFind, TNode, TComponent}"/> class.
        /// </summary>
        /// <param name="rootList">The root list.</param>
        /// <param name="match">The match.</param>
        public SceneComponentFinder(IEnumerator<TNode> rootList, Predicate<TComponentToFind> match) : base(rootList, match) { }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext() { return EnumMoveNext(); }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public TComponentToFind Current { get { return (TComponentToFind) CurrentComponent; } }
        object IEnumerator.Current { get { return Current; } }

        /// <summary>
        /// Reflected Viserator Callback. Performs the match test on the specified component.
        /// </summary>
        /// <param name="component">The component to check for the match.</param>
        [VisitMethod]
        protected void MatchComponent(TComponentToFind component)
        {
            if (_match != null && _match(component))
            {
                YieldOnCurrentComponent = true;
            }
        }
    
    }

    /// <summary>
    /// Allows various searches over scene graphs.
    /// This class can be used directly but will be more commonly used by calling one
    /// of the Find extension methods declared in <see cref="SceneFinderExtensions" />.
    /// </summary>
    /// <remarks>
    /// Search criteria can be passed as (lambda) predicates matching scene nodes.
    /// Results are returned as enumerator. Instead of directly using this class, users should use one of the FindNodes or
    /// FindComponents extension methods.
    /// </remarks>
    /// <typeparam name="TNodeToFind">The type of the node to look for.</typeparam>
    /// <typeparam name="TComponentToFind">The concrete type of the components to look for.</typeparam>
    /// <typeparam name="TNode">The concrete base type of nodes used as building blocks for scene graphs.</typeparam>
    /// <typeparam name="TComponent">The concrete base type of components used as building blocks for scene graphs.</typeparam>
    public class SceneNodeWhereComponentFinder<TNodeToFind, TComponentToFind, TNode, TComponent> : SceneFinderBase<TComponentToFind, TNode, TComponent>, IEnumerator<TNodeToFind>
        where TNodeToFind : TNode
        where TComponentToFind : TComponent
        where TNode : class, INode
        where TComponent : class, IComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneNodeWhereComponentFinder{TNodeToFind, TComponentToFind, TNode, TComponent}"/> class.
        /// </summary>
        /// <param name="rootList">The root list.</param>
        /// <param name="match">The match.</param>
        public SceneNodeWhereComponentFinder(IEnumerator<TNode> rootList, Predicate<TComponentToFind> match) : base(rootList, match) { }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext() { return EnumMoveNext(); }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public TNodeToFind Current { get { return (TNodeToFind) CurrentNode; } }
        object IEnumerator.Current { get { return Current; } }

        /// <summary>
        /// Reflected Viserator Callback. Performs the match test on the specified component.
        /// </summary>
        /// <param name="component">The component to check for the match.</param>
        [VisitMethod]
        protected void MatchComponent(TComponentToFind component)
        {
            if (_match != null && _match(component))
            {
                YieldOnCurrentComponent = true;
            }
        }
    }


    /// <summary>
    /// Base class serving for various searches over scene graphs. See the list of derived classes.
    /// </summary>
    /// <typeparam name="TSceneElementType">The concrete type of the components to look for.</typeparam>
    /// <typeparam name="TNode">The concrete base type for nodes used in the scene graph being traversed.</typeparam>
    /// <typeparam name="TComponent">The concrete base type for components used in the scene graph being traversed.</typeparam>
    public class SceneFinderBase<TSceneElementType, TNode, TComponent> : SceneVisitor<TNode, TComponent> where TNode : class, INode where TComponent : class, IComponent 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected IEnumerator<TNode> _rootList;
        protected Predicate<TSceneElementType> _match;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneFinderBase{TSceneElementType,TNode,TComponent}"/> class.
        /// </summary>
        /// <param name="rootList">The root list.</param>
        /// <param name="match">The match.</param>
        public SceneFinderBase(IEnumerator<TNode> rootList, Predicate<TSceneElementType> match)
        {
            _match = match;
            _rootList = rootList;
            EnumInit(_rootList);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _rootList = null;
            _match = null;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            EnumInit(_rootList);
        }
    }
}
