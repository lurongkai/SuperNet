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
            throw new NotImplementedException();
        }

        public double CalcOutDegree() {
            throw new NotImplementedException();
        }

        public double CalcAverageDegree() {
            return (double)_map.Count / (double)_map.GetAllNodes().Count;
        }
    }
}
