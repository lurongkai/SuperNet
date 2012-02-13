using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;
using System.IO;

namespace SuperNet.Framework.Target
{
    public class PajekTargetFormater : ITargetFormater
    {
        private string _path;
        private IDictionary<string,int> _nodes = new Dictionary<string,int>();
        private IList<string> _vectors = new List<string>();
        private int _nodeID = 1;

        public PajekTargetFormater(string path) {
            _path = path;
        }
        public void WriteLine(Vector vector) {
            if (vector == null) {
                return;
            }

            var from = GenerateNode(vector.From);
            var to = GenerateNode(vector.To);

            var vectorFormat = "{0} {1}";
            var line = String.Format(vectorFormat, from, to);
            _vectors.Add(line);
        }

        private int GenerateNode(Node node) {
            if (!_nodes.Keys.Contains(node.NodeName)) {
                var id = _nodeID++;
                _nodes.Add(new KeyValuePair<string,int>(node.NodeName, id));
                return id;
            }

            return _nodes[node.NodeName];
        }

        public void Save() {
            using (var file = new StreamWriter(_path)) {
                WriteNodes(file);
                WriteVectors(file);
            }
        }

        private void WriteVectors(StreamWriter file) {
            file.WriteLine("*Arcs");
            foreach (var vector in _vectors) {
                file.WriteLine(vector);
            }
        }

        private void WriteNodes(StreamWriter file) {
            var prefix = String.Format("*Vertices {0}", _nodes.Count);
            file.WriteLine(prefix);

            var nodeFormat = "{0} \"{1}\"";
            foreach (var node in _nodes) {
                var line = String.Format(nodeFormat, node.Value, node.Key);
                file.WriteLine(line);
            }
        }
    }
}
