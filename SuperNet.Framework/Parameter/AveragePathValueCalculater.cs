using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;
using SuperNet.Framework.Algorithm;

namespace SuperNet.Framework.Parameter
{
    public class AveragePathValueCalculater:ParameterCalculater
    {
        public AveragePathValueCalculater(Map map) : base(map) { }

        public double CalcAveragePathValue() {
            var allVertexs = _map.AllVertexs;
            var vertexCount = allVertexs.Count;

            var allVertexShortestPathSum = 0;
            //var dijkstra = GraphAlogrithmFactory.DijkstraAlogrithm(_map);
            foreach (var vertex in _map.AllVertexs) {
                //allVertexShortestPathSum += dijkstra.ShortestPathSum(vertex);
            }

            var fullArrayEdge = vertexCount * (vertexCount - 1) / 2;

            return (double)allVertexShortestPathSum *2 / fullArrayEdge;
        }
    }
}
