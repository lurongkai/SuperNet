using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;
using System.IO;

namespace SuperNet.Framework.Target
{
    public class PajekTargetFormater : IExportTarget
    {
        private const string nodeSectionPrefixFormat = "*Vertices {0}";
        private const string nodeFormat = "{0} \"{1}\"";
        private const string vectorSectionPrefix = "*Arcs";
        private const string vectorFormat = "{0} {1}";

        private Map _map;
        private IDictionary<string, int> _nodeCache = new Dictionary<string, int>();
        private int _nodeID = 1;

        public PajekTargetFormater(Map map) {
            _map = map;
        }

        public void ExportMap(string path) {
            var nodeList = GenerateNodeList();
            var vectorList = new List<string>();

            foreach (var vector in _map) {
                Walk(vector, vectorList);
            }

            GenerateFile(nodeList, vectorList, path);
        }

        private void GenerateFile(IList<string> nodeList, List<string> vectorList, string path) {
            using (var file = new StreamWriter(path)) {
                WriteNodesSection(nodeList, file);
                WriteVectorsSection(vectorList, file);
            }
        }

        private IList<string> GenerateNodeList() {
            var nodes = _map.GetAllNodes()
                .OrderBy(node => node.NodeID);

            var nodeList = new List<string>();
            foreach (var node in nodes) {
                var nodeName = node.NodeName;
                if (!_nodeCache.Keys.Contains(nodeName)) {
                    _nodeCache.Add(nodeName, _nodeID++);
                }
                nodeList.Add(String.Format(
                    nodeFormat, 
                    _nodeCache[nodeName], 
                    nodeName));
            }

            return nodeList;
        }

        private void Walk(Vector vector, IList<string> vectorList) {
            var fromNodeName = vector.From.NodeName;
            var toNodeName = vector.To.NodeName;
            vectorList.Add(String.Format(
                vectorFormat, 
                _nodeCache[fromNodeName],
                _nodeCache[toNodeName]));
        }

        private void WriteNodesSection(IList<string> nodeList, StreamWriter file) {
            file.WriteLine(String.Format(nodeSectionPrefixFormat, nodeList.Count()));
            foreach (var line in nodeList) {
                file.WriteLine(line);
            }
        }

        private void WriteVectorsSection(IList<string> vectorList, StreamWriter file) {
            file.WriteLine(vectorSectionPrefix);
            foreach (var line in vectorList) {
                file.WriteLine(line);
            }
        }
    }
}
