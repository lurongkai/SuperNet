using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    internal class RegisterManager
    {
        private IMap _map;
        private IVertex _startVertex;
        private IDictionary<IVertex, VertexRegister> _registers = new Dictionary<IVertex, VertexRegister>();

        internal RegisterManager(IMap map, IVertex startVertex) {
            _map = map;
            _startVertex = startVertex;
            InitializeRegisterDictionary();
        }

        private void InitializeRegisterDictionary() {
            var unRegistedVertexs = _map.AllVertexs.Where(vtx => vtx != _startVertex);
            foreach (var vertex in unRegistedVertexs) {
                var register = CreateVertexRegister(vertex);
                _registers.Add(vertex, register);
            }
            HandleDirectWeight();
        }

        private VertexRegister CreateVertexRegister(IVertex vertex) {
            return new VertexRegister(vertex);
        }

        private void HandleDirectWeight() {
            foreach (var edge in _startVertex.OutDegreeEdge) {
                var register = GetRegister(edge.To);
                register.InitializeWith(edge);
            }
        }

        internal VertexRegister GetRegister(IVertex vertex) {
            return _registers[vertex];
        }
    }
}
