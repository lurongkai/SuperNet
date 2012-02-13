using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.DataSource;

namespace SuperNet.Framework
{
    public class MapImporter
    {
        private IDataSource _dataSource;

        public MapImporter(IDataSource dataSource) {
            _dataSource = dataSource;
        }
    }
}
