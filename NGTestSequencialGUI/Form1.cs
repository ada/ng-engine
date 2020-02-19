using NG;
using NG.Step;
using R;
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
    public partial class Form1 : Form
    {
        NGSequencial engine = new NGSequencial();


        public Form1()
        {
            InitializeComponent();

            Rand r = new Rand();

            NGStepSeq s1 = new NGStepSeq("Sequence A");

            NGStepPassFail a1 = new NGStepPassFail("Step A.1")
            {
                PassFail = Scope => r.RandomBool()
            };

            NGStepPassFail a2 = new NGStepPassFail("Step A.2")
            {
                PassFail = Scope => r.RandomBool()
            };

            s1.Add(a1);
            s1.Add(a2);


            NGStepPassFail pf1 = new NGStepPassFail("Step 1")
            {
                PassFail = Scope => r.RandomBool()
            };

            NGStepPassFail pf2 = new NGStepPassFail("Step 2")
            {
                PassFail = Scope => r.RandomBool()
            };


            engine.PreUUT = CustomPreUUT;

            engine.MainSequence.Add(s1);
            engine.MainSequence.Add(s1);
            engine.MainSequence.Add(pf1);
            engine.MainSequence.Add(pf2);

            IList<string> s = engine.MainSequence.ToArray();
            listBox1.Items.Clear();
            foreach (var item in s)
            {
                listBox1.Items.Add(item);
            }
        }

        void CustomPreUUT()
        {
            PreUUTForm a = new PreUUTForm();
            a.ShowDialog();
            engine.ContinueTesting = a.Continue;
            engine.SerialNumber = a.SerialNumber;
        }

        private void UIButtonTestUUTs_Click(object sender, EventArgs e)
        {
            
            engine.Start();
        }
    }
}
