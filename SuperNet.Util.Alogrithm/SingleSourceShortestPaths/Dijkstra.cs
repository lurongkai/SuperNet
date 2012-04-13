using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class Dijkstra
    {
        private IMap _map;
        private IVertex _startVertex;

        public Dijkstra(IMap map, IVertex startVertex) {
            _map = map;
            _startVertex = startVertex;
        }
    }
}
