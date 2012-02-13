using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToExcel;
using System.IO;

namespace SuperNet.Framework.Source
{
    public class ExcelMapDataSource:MapDataSourceBase
    {
        public ExcelMapDataSource(string path) {
            if (!File.Exists(path)) {
                throw new ArgumentException("File not Exist.");
            }
            lines = ReadAll(path);
        }

        public IList<string[]> ReadAll(string path) {
            var excel = new ExcelQueryFactory(path);
            var worksheet = excel.WorksheetNoHeader(0);
            if (worksheet != null) {
                var data = from row in worksheet
                           select new string[] {
                                row[0].Value.ToString(),
                                row[1].Value.ToString()
                           };
                return data.ToList();
            }
            return new List<string[]>();
        }

    }
}
