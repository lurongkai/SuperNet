using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;
using System.IO;
using SuperNet.Framework.Interface;

namespace SuperNet.Framework.Target
{
    public class PajekTargetFormater : IExportTarget
    {
        private const string vertexSectionPrefixFormat = "*Vertices {0}";
        private const string vertexFormat = "{0} \"{1}\"";
        private const string edgeSectionPrefix = "*Arcs";
        private const string edgeFormat = "{0} {1}";

        private Map _map;
        private IDictionary<string, int> _vertexCache = new Dictionary<string, int>();
        private int _vertexID = 1;

        public PajekTargetFormater(Map map) {
            _map = map;
        }

        public void ExportMap(string path) {
            var vertexList = GenerateVertexList();
            var edgeList = new List<string>();

            foreach (var edge in _map) {
                Walk(edge, edgeList);
            }

            GenerateFile(vertexList, edgeList, path);
        }

        private void GenerateFile(IList<string> vertexList, List<string> edgeList, string path) {
            using (var file = new StreamWriter(path)) {
                WriteVertexsSection(vertexList, file);
                WriteEdgesSection(edgeList, file);
            }
        }

        private IList<string> GenerateVertexList() {
            var vertexs = _map.AllVertexs;

            var vertexList = new List<string>();
            foreach (var vertex in vertexs) {
                var vertexName = vertex.VertexName;
                if (!_vertexCache.Keys.Contains(vertexName)) {
                    _vertexCache.Add(vertexName, _vertexID++);
                }
                vertexList.Add(String.Format(
                    vertexFormat, 
                    _vertexCache[vertexName], 
                    vertexName));
            }

            return vertexList;
        }

        private void Walk(IEdge edge, IList<string> edgeList) {
            var fromVertexName = edge.From.VertexName;
            var toVertexName = edge.To.VertexName;
            edgeList.Add(String.Format(
                edgeFormat, 
                _vertexCache[fromVertexName],
                _vertexCache[toVertexName]));
        }

        private void WriteVertexsSection(IList<string> vertexList, StreamWriter file) {
            file.WriteLine(String.Format(vertexSectionPrefixFormat, vertexList.Count()));
            foreach (var line in vertexList) {
                file.WriteLine(line);
            }
        }

        private void WriteEdgesSection(IList<string> edgeList, StreamWriter file) {
            file.WriteLine(edgeSectionPrefix);
            foreach (var line in edgeList) {
                file.WriteLine(line);
            }
        }
    }
}
