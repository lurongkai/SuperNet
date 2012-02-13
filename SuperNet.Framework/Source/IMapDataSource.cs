using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Source
{
    public interface IMapDataSource
    {
        bool HasNext { get; }
        string[] ReadLine();
    }
}
