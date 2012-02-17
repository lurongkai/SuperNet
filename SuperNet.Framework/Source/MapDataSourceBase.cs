using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Source
{
    public class MapDataSourceBase:IImportSource
    {
        protected IDictionary<string, Vertex> _vertexDict = new Dictionary<string, Vertex>();

        public virtual Map ImportMap() {
            throw new NotImplementedException();
        }

        protected Edge GenerateEdge(string[] edgeRaw) {
            var edgeFrom = GenerateVertex(edgeRaw[0]);
            var edgeTo = GenerateVertex(edgeRaw[1]);

            return new Edge(edgeFrom, edgeTo);
        }

        protected Vertex GenerateVertex(string vertexRaw) {
            if (_vertexDict.Keys.Contains(vertexRaw)) {
                return _vertexDict[vertexRaw];
            }

            var vertex = new Vertex {
                VertexName = vertexRaw
            };

            return vertex;
        }
    }
}
