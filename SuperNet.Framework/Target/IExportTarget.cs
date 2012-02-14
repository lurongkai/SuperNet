using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Target
{
    public interface IExportTarget
    {
        void ExportMap(string path);
    }
}
