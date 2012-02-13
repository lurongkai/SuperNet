using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Framework.Source
{
    public class MapDataSourceBase:IMapDataSource
    {
        private int index;
        protected IList<string[]> lines;

        public virtual bool HasNext {
            get {
                return lines.Count > index;
            }
        }

        public virtual string[] ReadLine() {
            if (HasNext) {
                return lines[index++];
            }
            return null;
        }

        public virtual void Reset() {
            index = 0;
        }
    }
}
