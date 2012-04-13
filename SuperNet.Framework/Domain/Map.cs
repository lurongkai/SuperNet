using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SuperNet.Framework.Interface;

namespace SuperNet.Framework.Domain
{
    public class Map: IMap
    {
        private IList<IEdge> _edges = new List<IEdge>();
        private IList<IVertex> _vertexs = new List<IVertex>();

        public int IndexOf(IEdge item) {
            return _edges.IndexOf(item);
        }

        public void Insert(int index, IEdge item) {
            _edges.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _edges.RemoveAt(index);
        }

        public IEdge this[int index] {
            get {
                return _edges[index];
            }
            set {
                _edges[index] = value;
            }
        }

        public void Add(IEdge item) {
            SaveVertex(item.From);
            SaveVertex(item.To);

            _edges.Add(item);
        }

        public void Add(Vertex from, Vertex to) {
            Add(new Edge(from, to));
            //TODO: remove it!!!!
        }

        public void Clear() {
            _edges.Clear();
        }

        public bool Contains(IEdge item) {
            return _edges.Contains(item);
        }

        public void CopyTo(IEdge[] array, int arrayIndex) {
            _edges.CopyTo(array, arrayIndex);
        }

        public int Count {
            get { return _edges.Count; }
        }

        public bool IsReadOnly {
            get { return _edges.IsReadOnly; }
        }

        public bool Remove(IEdge item) {
            return _edges.Remove(item);
        }

        public IEnumerator<IEdge> GetEnumerator() {
            return _edges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void SaveVertex(IVertex vertex) {
            if (_vertexs.Contains(vertex)) {
                return;
            }
            _vertexs.Add(vertex);
        }

        public IList<IVertex> AllVertexs {
            get { return _vertexs; }
        }

        public IEdge FindEdgeByVertex(IVertex vertex) {
            return _edges
                .Where(e => e.From == vertex || e.To == vertex)
                .FirstOrDefault();
        }

        public IEdge FindEdgeByVertex(IVertex one, IVertex two) {
            return _edges
                .Where(e => e.From == one && e.To == two)
                .FirstOrDefault();
        }
    }
}
