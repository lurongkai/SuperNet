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

        public double CalcClustering(Vertex vertex) {
            var vertexDegree = vertex.Edges.Count;
            var vertexCount = _map.AllVertexs.Count;

            var fullArrayEdge = vertexCount * (vertexCount - 1) / 2;

            return (double)vertexDegree / fullArrayEdge;
        }
    }
}
