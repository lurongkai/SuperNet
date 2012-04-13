using System.Collections.Generic;

namespace SuperNet.Framework.Interface
{
    public interface IVertex
    {
        string VertexName { get; }
        IList<IEdge> Edges { get; }
        IEnumerable<IEdge> InDegreeEdge { get; }
        IEnumerable<IEdge> OutDegreeEdge { get; }

        bool ConnectedWith(IVertex other);
        bool ConnectFrom(IVertex from);
        bool ConnectTo(IVertex to);
    }
}