using System.Collections;
using System.Collections.Generic;

namespace SuperNet.Util.Alogrithm.SingleSourceShortestPaths
{
    public class ShortestPathResult : IEnumerable<PathRecord>
    {
        private readonly IList<PathRecord> _pathRecords = new List<PathRecord>();

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