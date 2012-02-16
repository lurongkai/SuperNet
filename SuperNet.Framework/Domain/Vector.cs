using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Vector
    {
        private Node _from;
        private Node _to;

        public Vector(Node from, Node to) {
            _from = from;
            _to = to;

            _from.Vectors.Add(this);
            _to.Vectors.Add(this);
        }

        public Node From {
            get { return _from; }
        }

        public Node To {
            get { return _to; }
        }

        #region override
        public override string ToString() {
            var format = "{0}-{1}";
            return String.Format(format, From.NodeName, To.NodeName);
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            var target = (obj as Vector);
            return target.From == this.From &&
                   target.To == this.To;
        }

        public override int GetHashCode() {
            return From.GetHashCode() & To.GetHashCode();
        }
        #endregion
    }
}
