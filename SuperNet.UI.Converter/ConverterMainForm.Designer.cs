namespace SuperNet.UI.Converter
{
    partial class ConverterMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnInDegree = new System.Windows.Forms.Button();
            this.btnClustering = new System.Windows.Forms.Button();
            this.btnAveragePath = new System.Windows.Forms.Button();
            this.btnAverageDegree = new System.Windows.Forms.Button();
            this.btnOutDegree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.LightSalmon;
            this.btnOpen.Location = new System.Drawing.Point(12, 37);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(260, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 9);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(62, 13);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "Choice File.";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.LightSalmon;
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(12, 211);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(260, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Pajek format";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInDegree
            // 
            this.btnInDegree.Enabled = false;
            this.btnInDegree.Location = new System.Drawing.Point(12, 66);
            this.btnInDegree.Name = "btnInDegree";
            this.btnInDegree.Size = new System.Drawing.Size(260, 23);
            this.btnInDegree.TabIndex = 3;
            this.btnInDegree.Text = "Calc In-Degree Value";
            this.btnInDegree.UseVisualStyleBackColor = true;
            this.btnInDegree.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClustering
            // 
            this.btnClustering.Enabled = false;
            this.btnClustering.Location = new System.Drawing.Point(12, 153);
            this.btnClustering.Name = "btnClustering";
            this.btnClustering.Size = new System.Drawing.Size(260, 23);
            this.btnClustering.TabIndex = 4;
            this.btnClustering.Text = "Calc Clustering Value";
            this.btnClustering.UseVisualStyleBackColor = true;
            this.btnClustering.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAveragePath
            // 
            this.btnAveragePath.Enabled = false;
            this.btnAveragePath.Location = new System.Drawing.Point(12, 182);
            this.btnAveragePath.Name = "btnAveragePath";
            this.btnAveragePath.Size = new System.Drawing.Size(260, 23);
            this.btnAveragePath.TabIndex = 5;
            this.btnAveragePath.Text = "Calc Average Path Value";
            this.btnAveragePath.UseVisualStyleBackColor = true;
            this.btnAveragePath.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnAverageDegree
            // 
            this.btnAverageDegree.Enabled = false;
            this.btnAverageDegree.Location = new System.Drawing.Point(12, 124);
            this.btnAverageDegree.Name = "btnAverageDegree";
            this.btnAverageDegree.Size = new System.Drawing.Size(260, 23);
            this.btnAverageDegree.TabIndex = 6;
            this.btnAverageDegree.Text = "Calc Average Degree Value";
            this.btnAverageDegree.UseVisualStyleBackColor = true;
            this.btnAverageDegree.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnOutDegree
            // 
            this.btnOutDegree.Enabled = false;
            this.btnOutDegree.Location = new System.Drawing.Point(12, 95);
            this.btnOutDegree.Name = "btnOutDegree";
            this.btnOutDegree.Size = new System.Drawing.Size(260, 23);
            this.btnOutDegree.TabIndex = 7;
            this.btnOutDegree.Text = "Calc Out-Degree Value";
            this.btnOutDegree.UseVisualStyleBackColor = true;
            this.btnOutDegree.Click += new System.EventHandler(this.button7_Click);
            // 
            // ConverterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.btnOutDegree);
            this.Controls.Add(this.btnAverageDegree);
            this.Controls.Add(this.btnAveragePath);
            this.Controls.Add(this.btnClustering);
            this.Controls.Add(this.btnInDegree);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnOpen);
            this.Name = "ConverterMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnInDegree;
        private System.Windows.Forms.Button btnClustering;
        private System.Windows.Forms.Button btnAveragePath;
        private System.Windows.Forms.Button btnAverageDegree;
        private System.Windows.Forms.Button btnOutDegree;
    }
}

