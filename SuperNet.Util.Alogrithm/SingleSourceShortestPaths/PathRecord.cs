using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class PathRecord
    {
        public double Weight { get; private set; }
        public IVertex[] VertexTracks { get; private set; }
        public IEdge EdgeTracks { get; private set; }
    }
}
