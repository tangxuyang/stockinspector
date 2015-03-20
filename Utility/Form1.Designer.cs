namespace Utility
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
            this.tb_Output = new System.Windows.Forms.TextBox();
            this.btn_Translate = new System.Windows.Forms.Button();
            this.tb_input = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tb_Output
            // 
            this.tb_Output.Location = new System.Drawing.Point(13, 301);
            this.tb_Output.Multiline = true;
            this.tb_Output.Name = "tb_Output";
            this.tb_Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Output.Size = new System.Drawing.Size(481, 140);
            this.tb_Output.TabIndex = 1;
            // 
            // btn_Translate
            // 
            this.btn_Translate.Location = new System.Drawing.Point(201, 259);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(75, 23);
            this.btn_Translate.TabIndex = 2;
            this.btn_Translate.Text = ">>";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += new System.EventHandler(this.btn_Translate_Click);
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(23, 13);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(471, 240);
            this.tb_input.TabIndex = 3;
            this.tb_input.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 453);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.btn_Translate);
            this.Controls.Add(this.tb_Output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Output;
        private System.Windows.Forms.Button btn_Translate;
        private System.Windows.Forms.RichTextBox tb_input;
    }
}

