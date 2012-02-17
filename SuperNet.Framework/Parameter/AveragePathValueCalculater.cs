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
            var allVertexs = _map.AllVertexs;
            var vertexCount = allVertexs.Count;

            var allVertexShortestPathSum = 0;
            for (int i = 0; i < vertexCount; i++) {
                for (int j = 0; j < vertexCount; j++) {
                    allVertexShortestPathSum += CalcShortestPath(allVertexs[i], allVertexs[j]);
                }    
            }

            var fullArrayEdge = vertexCount * (vertexCount - 1) / 2;

            return (double)allVertexShortestPathSum / fullArrayEdge;
        }
    }
}
