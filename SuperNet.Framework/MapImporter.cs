using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Source;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework
{
    public class MapImporter
    {
        private IMapDataSource _mapDataSource;
        private IDictionary<string, Node> _nodeDict = new Dictionary<string, Node>();
        private int _nodeID;

        public MapImporter(IMapDataSource dataSource) {
            _mapDataSource = dataSource;
        }

        public Map GenerateMap() {
            if (_mapDataSource == null) {
                throw new ArgumentException("_mapDataSource is null.");
            }

            var map = new Map();
            if (_mapDataSource.HasNext) {
                var raw = _mapDataSource.ReadLine();
                var vector = GenerateVector(raw);
                map.Add(vector);
            }

            return map;
        }

        private Vector GenerateVector(string[] vectorRaw) {
            var nodeFrom = GenerateNode(vectorRaw[0]);
            var nodeTo = GenerateNode(vectorRaw[1]);

            return new Vector() { From = nodeFrom, To = nodeTo };
        }

        private Node GenerateNode(string nodeRaw) {
            if (_nodeDict.Keys.Contains(nodeRaw)) {
                return _nodeDict[nodeRaw];
            }

            var node = new Node {
                NodeID = _nodeID++,
                NodeName = nodeRaw
            };

            return node;
        }
    }
}
