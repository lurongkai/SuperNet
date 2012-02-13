using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Target;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework
{
    public class MapExporter
    {
        private ITargetFormater _targetFormater;
        private Map _map;

        public MapExporter(Map map, ITargetFormater targetFormater) {
            _map = map;
            _targetFormater = targetFormater;
        }

        public void Export() {
            foreach (var vector in _map) {
                _targetFormater.WriteLine(vector);
            }
            _targetFormater.Save();
        }
    }
}
