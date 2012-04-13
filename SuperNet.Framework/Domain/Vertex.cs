using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Framework.Domain
{
    public class Vertex : IVertex
    {
        private IList<IEdge> _edges;

        public Vertex() {
            _edges = new List<IEdge>();
        }

        public string VertexName { get; set; }

        public IList<IEdge> Edges {
            get { return _edges; }  
        }

        public IEnumerable<IEdge> InDegreeEdge {
            get { return _edges.Where(v => v.To == this); }
        }

        public IEnumerable<IEdge> OutDegreeEdge {
            get { return _edges.Where(v => v.From == this); }
        }

        public bool ConnectedWith(IVertex other) {
            foreach (var edge in _edges) {
                if (edge.From == other || edge.To == other) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectFrom(IVertex from) {
            foreach (var edge in InDegreeEdge) {
                if (edge.From == from) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectTo(IVertex to) {
            foreach (var edge in OutDegreeEdge) {
                if (edge.To == to) {
                    return true;
                }
            }
            return false;
        }

        public IEdge FindEdgeByVertex(IVertex vertex, bool directed) {
            if (directed) {
                return InDegreeEdge
                    .Where(e => e.From == vertex)
                    .FirstOrDefault();
            } else {
                return _edges
                    .Where(e => e.From == vertex || e.To == vertex)
                    .FirstOrDefault();
            }
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

        internal IEnumerable<IVertex> ReachableVertexs(bool directed) {
            if (directed) {
                return _edges.Select(edge => edge.To);
            } else {
                return _edges
                    .Select(edge => edge.From)
                    .Concat(_edges.Select(edge => edge.To))
                    .Distinct()
                    .Except(new List<Vertex> { this });
            }
        }
    }
}
