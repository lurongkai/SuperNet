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



        public int ShortestPathValue(Vertex vetex, bool directed = false/*, bool withWeight = false*/) {
            var sureSet = new List<Vertex>();
            var unsureset = new List<Vertex>();

            sureSet.Add(vetex);
            unsureset.AddRange(_map.AllVertexs.Except(new List<Vertex> { vetex }));

            var resultArray = new Dictionary<Vertex, PathValue>(_map.AllVertexs.Count);
            CalculateByDijkstra(vetex, _map.AllVertexs, sureSet, unsureset, resultArray, directed);

            return resultArray.Select(
                kvp => {
                    var v = kvp.Value;
                    return v.HasValue ? v.Value : 0;
                }).Sum();
        }

        private void CalculateByDijkstra(Vertex vetex, IList<Vertex> allVetexs, IList<Vertex> sureSet, IList<Vertex> unsureSet, IDictionary<Vertex, PathValue> resultArray, bool directed) {
            Func<Vertex, bool> connectivityChecker;
        }

        private int EvaluatePathValueBySureSet(Vertex targetVertex, IList<Vertex> sureSet, IDictionary<Vertex, PathValue> resultArray, bool directed) {
            if (sureSet.Count == 0) {
                return 0;//Self.
            }

            int minPathValue = 0;
            foreach (var vertex in sureSet) {
                if (!targetVertex.ConnectedWith(vertex)) {
                    continue;
                }

                var prePathValue = resultArray[vertex].Value;
                var edge = targetVertex.FindEdgeByVertex(vertex, directed);
                var currentPathValue = prePathValue+edge.Weight;
                if (currentPathValue < minPathValue) {
                    minPathValue = currentPathValue;
                }
            }

            return minPathValue;
        }

        private class PathValue {
            private int _value;

            public bool HasValue { get; private set; }
            public int Value {
                get { return _value; }
                set { _value = value; HasValue = true; }
            }
        }
    }
}
