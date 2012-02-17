using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Parameter
{
    public class DegreeCalculater:ParameterCalculater
    {
        public DegreeCalculater(Map map) : base(map) { }

        public double CalcInDegree() {
            var inDegree = 0;
            foreach (var vertex in _map.AllVertexs) {
                inDegree += vertex.InDegreeEdge.Count();
            }

            return (double)inDegree / _map.AllVertexs.Count;
        }

        public double CalcOutDegree() {
            var outDegree = 0;
            foreach (var vertex in _map.AllVertexs) {
                outDegree += vertex.OutDegreeEdge.Count();
            }

            return (double)outDegree / _map.AllVertexs.Count;
        }

        public double CalcAverageDegree() {
            var edges = _map.Count * 2;
            return (double)edges / _map.AllVertexs.Count;
        }
    }
}
