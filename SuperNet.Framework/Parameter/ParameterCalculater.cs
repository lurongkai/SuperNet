using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Parameter
{
    public abstract class ParameterCalculater
    {
        protected Map _map;
        public ParameterCalculater(Map map) {
            _map = map;
        }

        public int CalcShortestPath(Vertex one, Vertex two) {
            throw new NotImplementedException();
        }
    }
}
