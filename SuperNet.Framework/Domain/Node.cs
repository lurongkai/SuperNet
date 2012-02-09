using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Node
    {
        public int NodeID { get; set; }
        public string NodeName { get; set; }

        public override string ToString() {
            var format = "{0}:{1}";
            return String.Format(format, NodeID, NodeName);
        }

        public override int GetHashCode() {
            return NodeID;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return (obj as Node).NodeID == this.NodeID;
        }
    }
}
