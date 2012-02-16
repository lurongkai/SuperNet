using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Parameter
{
    public class AveragePathValueCalculater:ParameterCalculater
    {
        public AveragePathValueCalculater(Map map) : base(map) { }

        public double CalcAveragePathValue() {
            var allNode = _map.AllNodes;
            var nodeCount = allNode.Count;

            var allNodeShortestPathSum = 0;
            for (int i = 0; i < nodeCount; i++) {
                for (int j = 0; j < nodeCount; j++) {
                    allNodeShortestPathSum += CalcShortestPath(allNode[i], allNode[j]);
                }    
            }

            var fullArrayEdge = nodeCount * (nodeCount - 1) / 2;

            return (double)allNodeShortestPathSum / fullArrayEdge;
        }
    }
}
