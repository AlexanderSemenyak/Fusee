using System;
using System.Collections.Generic;
using System.Text;

namespace Fusee.Serialization.V2
{
    public class FusVisitor
    {
        protected FusScene _currentScene;
        protected FusNode _currentNode;
        protected int _currentCompInx;

        public void Traverse(FusScene scene)
        {
            _currentScene = scene;
            PreVisit(scene);
            foreach(var child in scene.Children)
                DoVisitNode(child);

            PostVisit(scene);
        }

        private void DoVisitNode(FusNode node)
        {
            _currentNode = node;
            PreVisit(node);
            for(int inx = 0; inx < node.Components.Count; inx++)
            {
                _currentCompInx = inx;
                var component = _currentScene.ComponentList[inx];
                component.Accept(this);
            }
            foreach (var child in node.Children)
                DoVisitNode(child);
            PostVisit(node);
        }

        protected virtual void PreVisit(FusScene scene)
        {

        }

        protected virtual void PostVisit(FusScene scene)
        {

        }

        protected virtual void PreVisit(FusNode node)
        {

        }

        internal protected virtual void PostVisit(FusNode node)
        {

        }

        internal void Visit(FusComponent fusComponent)
        {
            throw new InvalidOperationException($"Cannot visit unkown component type {fusComponent.GetType().Name}.");
        }


        internal protected virtual void Visit(FusMaterial material)
        {

        }

        internal protected virtual void Visit(FusMesh mesh)
        {

        }

        internal protected virtual void Visit(FusTransform xform)
        {

        }
    }
}
