using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Node
    {
        public string NodeName { get; set; }

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
    }
}
