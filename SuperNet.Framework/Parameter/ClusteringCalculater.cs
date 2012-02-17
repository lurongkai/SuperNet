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

        public double CalcClustering() {
            var sum = 0.0d;
            foreach (var vertex in _map.AllVertexs) {
                sum += CalcVertexClustering(vertex);
            }

            return sum / _map.AllVertexs.Count;
        }

        private double CalcVertexClustering(Vertex vertex) {
            var vertexDegree = vertex.Edges.Count;
            var vertexCount = _map.AllVertexs.Count;

            var fullArrayEdge = vertexCount * (vertexCount - 1) / 2;

            return (double)vertexDegree / fullArrayEdge;
        }
    }
}
