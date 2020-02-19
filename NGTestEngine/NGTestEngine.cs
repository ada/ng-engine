using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NG.Step;

namespace NG
{ 
    public enum NGStatus
    {
        Idle,
        Running, 
        Finished
    }

    public abstract class NGEngine
    {
        public NGStatus Status { get; }
        public NGStepSeq MainSequence { get; set; }
        public bool ContinueTesting { get; set; } = true;

        public NGEngine()
        {
            this.Status = NGStatus.Idle;
            this.MainSequence = new NGStepSeq("Main sequence");
        }
    }
}
