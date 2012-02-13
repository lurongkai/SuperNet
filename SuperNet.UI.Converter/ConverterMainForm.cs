using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperNet.Framework.Source;

namespace SuperNet.UI.Converter
{
    public partial class ConverterMainForm : Form
    {
        public ConverterMainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var path = @"C:\test.xls";
            var source = new ExcelMapDataSource(path);
        }
    }
}
