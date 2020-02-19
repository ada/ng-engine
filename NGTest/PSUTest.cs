using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NG;
using NG.Step;
using CustomResource;

namespace NGTest
{
    class PSUTest : NGSequenceFile
    {
        public PSUTest(string name) : base(name)
        {
            DummyTest r = new DummyTest();

            NGStepNumeric step1 = new NGStepNumeric("Voltage1");
            step1.Comparision = NGComparision.Gt;
            step1.A = Scope => r.RandomInt();
            step1.B = Scope => 50;
            //step1.OverrideStatus(NGStepStatus.Aborted);

            MainSteps.Add(step1);
        }
    }
}
