namespace VS版本转换器
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxpath = new System.Windows.Forms.TextBox();
            this.buttonopen = new System.Windows.Forms.Button();
            this.buttonstrat = new System.Windows.Forms.Button();
            this.buttonhelp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择项目文件：";
            // 
            // textBoxpath
            // 
            this.textBoxpath.AllowDrop = true;
            this.textBoxpath.Location = new System.Drawing.Point(120, 21);
            this.textBoxpath.Name = "textBoxpath";
            this.textBoxpath.Size = new System.Drawing.Size(204, 21);
            this.textBoxpath.TabIndex = 1;
            this.textBoxpath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxpath_DragDrop);
            this.textBoxpath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxpath_DragEnter);
            // 
            // buttonopen
            // 
            this.buttonopen.Location = new System.Drawing.Point(342, 20);
            this.buttonopen.Name = "buttonopen";
            this.buttonopen.Size = new System.Drawing.Size(37, 23);
            this.buttonopen.TabIndex = 2;
            this.buttonopen.Text = "...";
            this.buttonopen.UseVisualStyleBackColor = true;
            this.buttonopen.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonstrat
            // 
            this.buttonstrat.Location = new System.Drawing.Point(65, 60);
            this.buttonstrat.Name = "buttonstrat";
            this.buttonstrat.Size = new System.Drawing.Size(103, 29);
            this.buttonstrat.TabIndex = 3;
            this.buttonstrat.Text = "开始转换";
            this.buttonstrat.UseVisualStyleBackColor = true;
            this.buttonstrat.Click += new System.EventHandler(this.buttonstrat_Click);
            // 
            // buttonhelp
            // 
            this.buttonhelp.Location = new System.Drawing.Point(231, 60);
            this.buttonhelp.Name = "buttonhelp";
            this.buttonhelp.Size = new System.Drawing.Size(103, 29);
            this.buttonhelp.TabIndex = 4;
            this.buttonhelp.Text = "帮助";
            this.buttonhelp.UseVisualStyleBackColor = true;
            this.buttonhelp.Click += new System.EventHandler(this.buttonhelp_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 101);
            this.Controls.Add(this.buttonhelp);
            this.Controls.Add(this.buttonstrat);
            this.Controls.Add(this.buttonopen);
            this.Controls.Add(this.textBoxpath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS版本转换器 V1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxpath;
        private System.Windows.Forms.Button buttonopen;
        private System.Windows.Forms.Button buttonstrat;
        private System.Windows.Forms.Button buttonhelp;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

