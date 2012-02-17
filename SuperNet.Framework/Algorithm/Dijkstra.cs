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

        public int ShortestPathSum(Vertex start, bool directed = false) {
            return ShortestPathResult(start, directed).Select(
                kvp => {
                    var v = kvp.Value;
                    return v.HasValue ? v.Value : 0;
                }).Sum();
        }

        public IDictionary<Vertex, PathValue> ShortestPathResult(Vertex start, bool directed = false/*, bool withWeight = false*/) {
            var sureSet = new List<Vertex>();
            var unsureset = new List<Vertex>();

            unsureset.AddRange(_map.AllVertexs);

            var resultArray = new Dictionary<Vertex, PathValue>(_map.AllVertexs.Count);
            CalculateByDijkstra(start, _map.AllVertexs, sureSet, unsureset, resultArray, directed);

            return resultArray;
        }

        private void CalculateByDijkstra(Vertex start, IList<Vertex> allVetexs, IList<Vertex> sureSet, IList<Vertex> unsureSet, IDictionary<Vertex, PathValue> resultArray, bool directed) {
            sureSet.Add(start);
            resultArray.Add(start, new PathValue { Value = 0 });
            for (int i = 0; i < allVetexs.Count; i++) {
                foreach (var vertex in allVetexs) {
                    var vertexPathValue = EvaluatePathValueBySureSet(vertex, sureSet, resultArray, directed);
                    sureSet.Add(vertex);
                    if (resultArray.Keys.Contains(vertex)) {
                        resultArray[vertex] = new PathValue { Value = vertexPathValue };
                    } else {
                        resultArray.Add(vertex, new PathValue { Value = vertexPathValue });
                    }
                }
            }
        }

        private int EvaluatePathValueBySureSet(Vertex targetVertex, IList<Vertex> sureSet, IDictionary<Vertex, PathValue> resultArray, bool directed) {
            if (sureSet.Contains(targetVertex)) {
                return 0;//Self.
            }

            int minPathValue = 0;

            var allWeights = sureSet
                .Where(vertex => vertex.ConnectedWith(targetVertex))
                .Where(vertex => resultArray[vertex].Value != 0)
                .Select(vertex => {
                    var edge = vertex.FindEdgeByVertex(targetVertex, directed);
                    return edge.Weight;
                });
            if (allWeights.Count() > 0) {
                minPathValue = allWeights.Min();
            }

            return minPathValue;
        }

        public class PathValue
        {
            private int _value;

            public bool HasValue { get; private set; }
            public int Value {
                get { return _value; }
                set { _value = value; HasValue = true; }
            }
        }
    }
}
