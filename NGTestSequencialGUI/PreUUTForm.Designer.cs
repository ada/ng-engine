namespace NGTestSequencialGUI
{
    partial class PreUUTForm
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
            this.UIButtonContinue = new System.Windows.Forms.Button();
            this.UIButtonCancel = new System.Windows.Forms.Button();
            this.UITextBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UIButtonContinue
            // 
            this.UIButtonContinue.Location = new System.Drawing.Point(450, 322);
            this.UIButtonContinue.Name = "UIButtonContinue";
            this.UIButtonContinue.Size = new System.Drawing.Size(157, 74);
            this.UIButtonContinue.TabIndex = 0;
            this.UIButtonContinue.Text = "Continue";
            this.UIButtonContinue.UseVisualStyleBackColor = true;
            this.UIButtonContinue.Click += new System.EventHandler(this.UIButtonContinue_Click);
            // 
            // UIButtonCancel
            // 
            this.UIButtonCancel.Location = new System.Drawing.Point(287, 322);
            this.UIButtonCancel.Name = "UIButtonCancel";
            this.UIButtonCancel.Size = new System.Drawing.Size(157, 74);
            this.UIButtonCancel.TabIndex = 1;
            this.UIButtonCancel.Text = "Cancel";
            this.UIButtonCancel.UseVisualStyleBackColor = true;
            this.UIButtonCancel.Click += new System.EventHandler(this.UIButtonCancel_Click);
            // 
            // UITextBoxSerialNumber
            // 
            this.UITextBoxSerialNumber.Location = new System.Drawing.Point(274, 235);
            this.UITextBoxSerialNumber.Name = "UITextBoxSerialNumber";
            this.UITextBoxSerialNumber.Size = new System.Drawing.Size(348, 31);
            this.UITextBoxSerialNumber.TabIndex = 2;
            // 
            // PreUUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UITextBoxSerialNumber);
            this.Controls.Add(this.UIButtonCancel);
            this.Controls.Add(this.UIButtonContinue);
            this.Name = "PreUUT";
            this.Text = "PreUUT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UIButtonContinue;
        private System.Windows.Forms.Button UIButtonCancel;
        private System.Windows.Forms.TextBox UITextBoxSerialNumber;
    }
}