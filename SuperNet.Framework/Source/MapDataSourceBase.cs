﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Source
{
    public class MapDataSourceBase:IImportSource
    {
        protected IDictionary<string, Node> _nodeDict = new Dictionary<string, Node>();
        protected int _nodeID = 1;

        public virtual Map ImportMap() {
            throw new NotImplementedException();
        }

        protected Vector GenerateVector(string[] vectorRaw) {
            var nodeFrom = GenerateNode(vectorRaw[0]);
            var nodeTo = GenerateNode(vectorRaw[1]);

            return new Vector() { From = nodeFrom, To = nodeTo };
        }

        protected Node GenerateNode(string nodeRaw) {
            if (_nodeDict.Keys.Contains(nodeRaw)) {
                return _nodeDict[nodeRaw];
            }

            var node = new Node {
                NodeID = _nodeID++,
                NodeName = nodeRaw
            };

            return node;
        }
    }
}
