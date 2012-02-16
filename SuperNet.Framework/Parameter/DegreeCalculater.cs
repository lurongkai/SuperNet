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
            foreach (var node in _map.AllNodes) {
                inDegree += node.InDegreeVector.Count();
            }

            return (double)inDegree / _map.AllNodes.Count;
        }

        public double CalcOutDegree() {
            var outDegree = 0;
            foreach (var node in _map.AllNodes) {
                outDegree += node.OutDegreeVector.Count();
            }

            return (double)outDegree / _map.AllNodes.Count;
        }

        public double CalcAverageDegree() {
            var vectors = _map.Count * 2;
            return (double)vectors / _map.AllNodes.Count;
        }
    }
}
