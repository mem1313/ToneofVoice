namespace SofpotTestApplication_WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.happy = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sad = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.angry = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.normal3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.normal1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.happy.SuspendLayout();
            this.sad.SuspendLayout();
            this.angry.SuspendLayout();
            this.normal3.SuspendLayout();
            this.normal1.SuspendLayout();
            this.SuspendLayout();
            // 
            // happy
            // 
            this.happy.Controls.Add(this.label1);
            this.happy.Location = new System.Drawing.Point(0, 0);
            this.happy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.happy.Name = "happy";
            this.happy.Size = new System.Drawing.Size(344, 296);
            this.happy.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "HAPPY";
            // 
            // sad
            // 
            this.sad.Controls.Add(this.label2);
            this.sad.Location = new System.Drawing.Point(392, 0);
            this.sad.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sad.Name = "sad";
            this.sad.Size = new System.Drawing.Size(344, 296);
            this.sad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "SAD";
            // 
            // angry
            // 
            this.angry.Controls.Add(this.label3);
            this.angry.Location = new System.Drawing.Point(779, 0);
            this.angry.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.angry.Name = "angry";
            this.angry.Size = new System.Drawing.Size(344, 296);
            this.angry.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "MAD";
            // 
            // normal3
            // 
            this.normal3.Controls.Add(this.label6);
            this.normal3.Location = new System.Drawing.Point(392, 341);
            this.normal3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.normal3.Name = "normal3";
            this.normal3.Size = new System.Drawing.Size(344, 296);
            this.normal3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 32);
            this.label6.TabIndex = 3;
            this.label6.Text = "NORMAL \r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 32);
            this.label5.TabIndex = 2;
            this.label5.Text = "IRRETATED";
            // 
            // normal1
            // 
            this.normal1.Controls.Add(this.label5);
            this.normal1.Location = new System.Drawing.Point(0, 341);
            this.normal1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.normal1.Name = "normal1";
            this.normal1.Size = new System.Drawing.Size(344, 296);
            this.normal1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(779, 341);
            this.listBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 283);
            this.listBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 639);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.normal3);
            this.Controls.Add(this.angry);
            this.Controls.Add(this.normal1);
            this.Controls.Add(this.sad);
            this.Controls.Add(this.happy);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.happy.ResumeLayout(false);
            this.happy.PerformLayout();
            this.sad.ResumeLayout(false);
            this.sad.PerformLayout();
            this.angry.ResumeLayout(false);
            this.angry.PerformLayout();
            this.normal3.ResumeLayout(false);
            this.normal3.PerformLayout();
            this.normal1.ResumeLayout(false);
            this.normal1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel happy;
        private System.Windows.Forms.Panel sad;
        private System.Windows.Forms.Panel angry;
        private System.Windows.Forms.Panel normal3;
        private System.Windows.Forms.Panel normal1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

