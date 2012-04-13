using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SuperNet.Framework.Interface;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class ShortestPathResult : IEnumerable<PathRecord>
    {
        public ShortestPathResult() {}

        internal ShortestPathResult(IDictionary<IVertex, VertexRegister> registerDictionary) {
            foreach(var item in registerDictionary) {
                var record = new PathRecord(item.Key, item.Value.TotalWeight, item.Value.EdgeTracks);
                _pathRecords.Add(record);
            }
        }

        private readonly IList<PathRecord> _pathRecords = new List<PathRecord>();

        public PathRecord GetTargetPathRecord(IVertex target) {
            return _pathRecords.Single(pr => pr.Target == target);
        }

        #region IEnumerable<PathRecord> Members

        public IEnumerator<PathRecord> GetEnumerator() {
            return _pathRecords.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}