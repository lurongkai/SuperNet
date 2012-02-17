using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Vertex
    {
        private IList<Edge> _edges;

        public Vertex() {
            _edges = new List<Edge>();
        }

        public string VertexName { get; set; }

        public IList<Edge> Edges {
            get { return _edges; }  
        }

        public IEnumerable<Edge> InDegreeEdge {
            get { return _edges.Where(v => v.To == this); }
        }

        public IEnumerable<Edge> OutDegreeEdge {
            get { return _edges.Where(v => v.From == this); }
        }

        public bool ConnectedWith(Vertex other) {
            foreach (var edge in _edges) {
                if (edge.From == other || edge.To == other) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectFrom(Vertex from) {
            foreach (var edge in InDegreeEdge) {
                if (edge.From == from) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectTo(Vertex to) {
            foreach (var edge in OutDegreeEdge) {
                if (edge.To == to) {
                    return true;
                }
            }
            return false;
        }

        public Edge FindEdgeByVertex(Vertex vertex, bool directed) { 
            
        }

        #region override
        public override string ToString() {
            return VertexName;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return (obj as Vertex).VertexName == this.VertexName;
        }

        public override int GetHashCode() {
            return VertexName.GetHashCode();
        }
        #endregion
    }
}
