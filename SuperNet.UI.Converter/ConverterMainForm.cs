using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperNet.Framework.Source;
using SuperNet.Framework.Domain;
using SuperNet.Framework;
using SuperNet.Framework.Target;

namespace SuperNet.UI.Converter
{
    public partial class ConverterMainForm : Form
    {
        private Map _map;
        private string _path;

        public ConverterMainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                if (dialog.FileName == null) {
                    return;
                }

                try {
                    _path = dialog.FileName;
                    var source = new ExcelMapDataSource(_path);
                    var importer = new MapImporter(source);
                    _map = importer.GenerateMap();

                    label1.Text = _path;
                    button2.Enabled = true;
                } catch {
                    MessageBox.Show("未知文件.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (_map == null) {
                MessageBox.Show("未知文件.");
                return;
            }

            var target = new PajekTargetFormater(@"C:\result.net");
            var exporter = new MapExporter(_map, target);

            try {
                exporter.Export();
                MessageBox.Show("导出成功.");
            } catch {
                MessageBox.Show("导出失败.");
            }
        }
    }
}
