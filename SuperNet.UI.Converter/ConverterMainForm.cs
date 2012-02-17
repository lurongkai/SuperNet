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
using SuperNet.Framework.Parameter;

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
                    _map = source.ImportMap();

                    lblFilePath.Text = _path;
                    btnInDegree.Enabled = true;
                    btnOutDegree.Enabled = true;
                    btnAverageDegree.Enabled = true;
                    btnClustering.Enabled = true;
                    btnAveragePath.Enabled = true;
                    btnExport.Enabled = true;
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

            var target = new PajekTargetFormater(_map);

            try {
                target.ExportMap(@"C:\result.net");
                MessageBox.Show("导出成功.");
            } catch {
                MessageBox.Show("导出失败.");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            var calculater = new DegreeCalculater(_map);
            try {
                MessageBox.Show(
                    calculater.CalcInDegree().ToString(),
                    "Value",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            var calculater = new DegreeCalculater(_map);
            try {
                MessageBox.Show(
                    calculater.CalcOutDegree().ToString(),
                    "Value",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            var calculater = new DegreeCalculater(_map);
            try {
                MessageBox.Show(
                    calculater.CalcAverageDegree().ToString(),
                    "Value",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            var calculater = new ClusteringCalculater(_map);
            try {
                MessageBox.Show(
                    calculater.CalcClustering().ToString(),
                    "Value",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            var calculater = new AveragePathValueCalculater(_map);
            try {
                MessageBox.Show(
                    calculater.CalcAveragePathValue().ToString(),
                    "Value",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
