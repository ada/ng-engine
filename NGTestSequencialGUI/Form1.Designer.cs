﻿namespace NGTestSequencialGUI
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
            this.UIButtonTestUUTs = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UIButtonTestUUTs
            // 
            this.UIButtonTestUUTs.Location = new System.Drawing.Point(12, 34);
            this.UIButtonTestUUTs.Name = "UIButtonTestUUTs";
            this.UIButtonTestUUTs.Size = new System.Drawing.Size(157, 60);
            this.UIButtonTestUUTs.TabIndex = 0;
            this.UIButtonTestUUTs.Text = "Test UUTs";
            this.UIButtonTestUUTs.UseVisualStyleBackColor = true;
            this.UIButtonTestUUTs.Click += new System.EventHandler(this.UIButtonTestUUTs_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(12, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(964, 579);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 708);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.UIButtonTestUUTs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UIButtonTestUUTs;
        private System.Windows.Forms.ListBox listBox1;
    }
}

