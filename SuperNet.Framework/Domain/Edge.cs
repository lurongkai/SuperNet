using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Framework.Domain
{
    public class Edge : IEdge
    {
        private IVertex _from;
        private IVertex _to;
        private int _weight;

        public Edge(IVertex from, IVertex to, int weight = 1) {
            _from = from;
            _to = to;
            _weight = weight;

            _from.Edges.Add(this);
            _to.Edges.Add(this);
        }

        public IVertex From {
            get { return _from; }
        }

        public IVertex To {
            get { return _to; }
        }

        public int Weight {
            get { return _weight; }
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
