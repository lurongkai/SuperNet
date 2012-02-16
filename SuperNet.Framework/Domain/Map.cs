using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SuperNet.Framework.Domain
{
    public class Map:IList<Vector>
    {
        private IList<Vector> _vectors = new List<Vector>();
        private IList<Node> _nodes = new List<Node>();

        public int IndexOf(Vector item) {
            return _vectors.IndexOf(item);
        }

        public void Insert(int index, Vector item) {
            _vectors.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _vectors.RemoveAt(index);
        }

        public Vector this[int index] {
            get {
                return _vectors[index];
            }
            set {
                _vectors[index] = value;
            }
        }

        public void Add(Vector item) {
            SaveNode(item.From);
            SaveNode(item.To);

            _vectors.Add(item);
        }

        public void Clear() {
            _vectors.Clear();
        }

        public bool Contains(Vector item) {
            return _vectors.Contains(item);
        }

        public void CopyTo(Vector[] array, int arrayIndex) {
            _vectors.CopyTo(array, arrayIndex);
        }

        public int Count {
            get { return _vectors.Count; }
        }

        public bool IsReadOnly {
            get { return _vectors.IsReadOnly; }
        }

        public bool Remove(Vector item) {
            return _vectors.Remove(item);
        }

        public IEnumerator<Vector> GetEnumerator() {
            return _vectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void SaveNode(Node node) {
            if (_nodes.Contains(node)) {
                return;
            }
            _nodes.Add(node);
        }

        internal IList<Node> GetAllNodes() {
            var allNodes = new List<Node>();
            foreach (var vector in _vectors) {                
                NodeExist(allNodes, vector.From);
                NodeExist(allNodes, vector.To);
            }

            return allNodes;
        }

        private void NodeExist(IList<Node> nodes, Node node){
            if (!nodes.Contains(node)) {
                nodes.Add(node);
            }
        }
    }
}
