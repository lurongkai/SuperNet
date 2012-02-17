using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SuperNet.Framework.Domain
{
    public class Map:IList<Edge>
    {
        private IList<Edge> _edges = new List<Edge>();
        private IList<Vertex> _vertexs = new List<Vertex>();

        public int IndexOf(Edge item) {
            return _edges.IndexOf(item);
        }

        public void Insert(int index, Edge item) {
            _edges.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _edges.RemoveAt(index);
        }

        public Edge this[int index] {
            get {
                return _edges[index];
            }
            set {
                _edges[index] = value;
            }
        }

        public void Add(Edge item) {
            SaveVertex(item.From);
            SaveVertex(item.To);

            _edges.Add(item);
        }

        public void Add(Vertex from, Vertex to) {
            Add(new Edge(from, to));
        }

        public void Clear() {
            _edges.Clear();
        }

        public bool Contains(Edge item) {
            return _edges.Contains(item);
        }

        public void CopyTo(Edge[] array, int arrayIndex) {
            _edges.CopyTo(array, arrayIndex);
        }

        public int Count {
            get { return _edges.Count; }
        }

        public bool IsReadOnly {
            get { return _edges.IsReadOnly; }
        }

        public bool Remove(Edge item) {
            return _edges.Remove(item);
        }

        public IEnumerator<Edge> GetEnumerator() {
            return _edges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void SaveVertex(Vertex vertex) {
            if (_vertexs.Contains(vertex)) {
                return;
            }
            _vertexs.Add(vertex);
        }

        internal IList<Vertex> AllVertexs {
            get { return _vertexs; }
        }
    }
}
