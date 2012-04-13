using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class PathRecord
    {
        public PathRecord(IVertex target, double weight, IList<IEdge> edgeTracks) {
            Target = target;
            Weight = weight;
            EdgeTracks = edgeTracks.ToArray();
            ParseVertexTracks(edgeTracks);
        }

        private void ParseVertexTracks(IList<IEdge> edgeTracks) {
            var tempTracks = new List<IVertex>();
            for (int i = 0; i < edgeTracks.Count; i++) {
                var edge = edgeTracks[i];
                if (i == 0) {
                    tempTracks.Add(edge.From);
                }
                tempTracks.Add(edge.To);
            }
            VertexTracks = tempTracks.ToArray();
        }

        public IVertex Target { get; private set; }
        public double Weight { get; private set; }
        public IVertex[] VertexTracks { get; private set; }
        public IEdge[] EdgeTracks { get; private set; }
    }
}
