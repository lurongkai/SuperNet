using System.Collections.Generic;

namespace SuperNet.Framework.Interface
{
    public interface IMap : IList<IEdge>
    {
        IList<IVertex> AllVertexs { get; }
    }
}