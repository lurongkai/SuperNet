using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    internal class VertexRegister
    {
        internal VertexRegister(IVertex currentVertex) {
            Vertex = currentVertex;
            Registed = false;
            TotalWeight = double.MaxValue;
            EdgeTracks = new List<IEdge>();
        }

        internal IVertex Vertex { get; private set; }
        internal bool Registed { get; set; }
        internal double TotalWeight { get; set; }
        internal IList<IEdge> EdgeTracks { get; private set; }

        internal void InitializeWith(IEdge edge) {
            TotalWeight = edge.Weight;
            EdgeTracks.Add(edge);
        }

        internal void UpdateRegister(VertexRegister milestoneRegister, IEdge edge) {
            TotalWeight = milestoneRegister.TotalWeight + edge.Weight;
            EdgeTracks.Clear();
            EdgeTracks = milestoneRegister.EdgeTracks.Select(et => et).ToList();
            EdgeTracks.Add(edge);
        }
    }
}
