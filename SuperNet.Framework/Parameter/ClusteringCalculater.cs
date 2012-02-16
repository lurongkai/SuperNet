using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Parameter
{
    public class ClusteringCalculater:ParameterCalculater
    {
        public ClusteringCalculater(Map map) : base(map) { }

        public double CalcClustering(Node node) {
            var nodeDegree = node.Vectors.Count;
            var nodeCount = _map.AllNodes.Count;

            var fullArrayEdge = nodeCount * (nodeCount - 1) / 2;

            return (double)nodeDegree / fullArrayEdge;
        }
    }
}
