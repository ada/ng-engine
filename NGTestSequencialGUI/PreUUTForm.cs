using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGTestSequencialGUI
{
    public partial class PreUUTForm : Form
    {
        public string SerialNumber { get; set; }
        public bool Continue { get; set; }

        public PreUUTForm()
        {
            InitializeComponent();
        }

        private void UIButtonContinue_Click(object sender, EventArgs e)
        {
            this.SerialNumber = UITextBoxSerialNumber.Text;
            this.Continue = true;
            this.Close(); 
        }

        private void UIButtonCancel_Click(object sender, EventArgs e)
        {
            this.Continue = false;
            this.Close();
        }
    }
}
