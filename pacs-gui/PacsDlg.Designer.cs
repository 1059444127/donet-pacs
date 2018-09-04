namespace pacs_gui
{
    partial class PacsDlg
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.startup = new System.Windows.Forms.Button();
            this.label_port = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textAE = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startup
            // 
            this.startup.Location = new System.Drawing.Point(356, 26);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(75, 23);
            this.startup.TabIndex = 0;
            this.startup.Text = "启动";
            this.startup.UseVisualStyleBackColor = true;
            this.startup.Click += new System.EventHandler(this.Startup_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(24, 32);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(29, 12);
            this.label_port.TabIndex = 1;
            this.label_port.Text = "端口";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(59, 28);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(58, 21);
            this.textPort.TabIndex = 2;
            this.textPort.Text = "104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "AETitle";
            // 
            // textAE
            // 
            this.textAE.Location = new System.Drawing.Point(210, 28);
            this.textAE.Name = "textAE";
            this.textAE.Size = new System.Drawing.Size(99, 21);
            this.textAE.TabIndex = 4;
            this.textAE.Text = "JFPACS";
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(24, 84);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(53, 12);
            this.label_path.TabIndex = 5;
            this.label_path.Text = "存储位置";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(83, 81);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(267, 21);
            this.textPath.TabIndex = 6;
            this.textPath.Text = "E:/Code/dicom";
            // 
            // PacsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 131);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.textAE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.startup);
            this.Name = "PacsDlg";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startup;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAE;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox textPath;
    }
}

