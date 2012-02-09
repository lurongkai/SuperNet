using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Domain
{
    public class Vector
    {
        public Node From { get; set; }
        public Node To { get; set; }

        public override string ToString() {
            var format = "{0}-{1}";
            return String.Format(format, From.NodeName, To.NodeName);
        }
    }
}
