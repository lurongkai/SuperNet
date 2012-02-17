using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Edge
    {
        private Vertex _from;
        private Vertex _to;

        public Edge(Vertex from, Vertex to) {
            _from = from;
            _to = to;

            _from.Edges.Add(this);
            _to.Edges.Add(this);
        }

        public Vertex From {
            get { return _from; }
        }

        public Vertex To {
            get { return _to; }
        }

        #region override
        public override string ToString() {
            var format = "{0}-{1}";
            return String.Format(format, From.VertexName, To.VertexName);
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            var target = (obj as Edge);
            return target.From == this.From &&
                   target.To == this.To;
        }

        public override int GetHashCode() {
            return From.GetHashCode() & To.GetHashCode();
        }
        #endregion
    }
}
