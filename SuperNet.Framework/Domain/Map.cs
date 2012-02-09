using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SuperNet.Framework.Domain
{
    public class Map:IList<Vector>
    {
        private IList<Vector> vectors = new List<Vector>();

        public int IndexOf(Vector item) {
            return vectors.IndexOf(item);
        }

        public void Insert(int index, Vector item) {
            vectors.Insert(index, item);
        }

        public void RemoveAt(int index) {
            vectors.RemoveAt(index);
        }

        public Vector this[int index] {
            get {
                return vectors[index];
            }
            set {
                vectors[index] = value;
            }
        }

        public void Add(Vector item) {
            vectors.Add(item);
        }

        public void Clear() {
            vectors.Clear();
        }

        public bool Contains(Vector item) {
            return vectors.Contains(item);
        }

        public void CopyTo(Vector[] array, int arrayIndex) {
            vectors.CopyTo(array, arrayIndex);
        }

        public int Count {
            get { return vectors.Count; }
        }

        public bool IsReadOnly {
            get { return vectors.IsReadOnly; }
        }

        public bool Remove(Vector item) {
            return vectors.Remove(item);
        }

        public IEnumerator<Vector> GetEnumerator() {
            return vectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
