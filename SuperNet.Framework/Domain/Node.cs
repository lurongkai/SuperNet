using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Node
    {
        private IList<Vector> _vectors;

        public Node() {
            _vectors = new List<Vector>();
        }

        public string NodeName { get; set; }

        public IList<Vector> Vectors {
            get { return _vectors; }  
        }

        public IEnumerable<Vector> InDegreeVector {
            get { return _vectors.Where(v => v.To == this); }
        }

        public IEnumerable<Vector> OutDegreeVector {
            get { return _vectors.Where(v => v.From == this); }
        }

        public bool ConnectedWith(Node other) {
            foreach (var vector in _vectors) {
                if (vector.From == other || vector.To == other) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectFrom(Node from) {
            foreach (var vector in InDegreeVector) {
                if (vector.From == from) {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectTo(Node to) {
            foreach (var vector in OutDegreeVector) {
                if (vector.To == to) {
                    return true;
                }
            }
            return false;
        }

        #region override
        public override string ToString() {
            return NodeName;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return (obj as Node).NodeName == this.NodeName;
        }

        public override int GetHashCode() {
            return NodeName.GetHashCode();
        }
        #endregion
    }
}
