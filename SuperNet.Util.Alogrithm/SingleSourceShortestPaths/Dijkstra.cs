using System.Collections.Generic;
using System.Linq;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class Dijkstra
    {
        private IMap _map;
        private IVertex _startVertex;
        private RegisterManager _registerManager;

        public Dijkstra(IMap map, IVertex startVertex) {
            _map = map;
            _startVertex = startVertex;
            _registerManager = new RegisterManager(map, startVertex);
        }

        public void ExecuteDijkstra() {
            var milestone = GetMilestoneVertex();
            while (milestone != null) {
                var milestoneRegister = _registerManager.GetRegister(milestone);
                UpdateRelatedRegister(milestoneRegister);
                milestone = GetMilestoneVertex();
            }
        }

        private void UpdateRelatedRegister(VertexRegister milestoneRegister) {
            var milestoneVertex = milestoneRegister.Vertex;
            foreach(var edge in milestoneVertex.OutDegreeEdge) {
                var targetRegister = _registerManager.GetRegister(edge.To);
                var attemtpWeight = milestoneRegister.TotalWeight + edge.Weight;
                if(attemtpWeight < targetRegister.TotalWeight) {
                    targetRegister.UpdateRegister(milestoneRegister);
                }
            }
            milestoneRegister.Registed = true;
        }

        private IVertex GetMilestoneVertex() {
            var registers = _map.AllVertexs
                .Where(v => !v.Equals(_startVertex))
                .Select(v => _registerManager.GetRegister(v))
                .Where(reg => reg.Registed == false);

            var target = FetchVertexThroughRegisters(registers);
            return target;
        }

        private IVertex FetchVertexThroughRegisters(IEnumerable<VertexRegister> registers) {
            double weight = double.MaxValue;
            IVertex target = null;

            foreach (var register in registers) {
                if (register.TotalWeight < weight) {
                    weight = register.TotalWeight;
                    target = register.Vertex;
                }
            }
            return target;
        }
    }
}
