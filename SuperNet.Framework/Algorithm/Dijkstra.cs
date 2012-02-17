using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Algorithm
{
    public class Dijkstra
    {
        private Map _map;

        public Dijkstra(Map map) {
            _map = map;
        }

        public int ShortestPathValue(Vertex begin, Vertex end, bool directed = false/*, bool withWeight = false*/) {
            throw new NotImplementedException();
        }
    }
}
