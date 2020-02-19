using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    public enum NGStepStatus
    {
        Done,
        Passed,
        Failed, 
        Aborted, 
        Running
    }

    public class NGStepResult
    {
        public NGStepStatus Status { get; set; }
    }

    public abstract class NGStep
    {
        public string Name { get; set; }
        public NGStepResult Result { get; set; }
        protected NGStepStatus ForcedStatus { get; set; }
        protected bool ForceStatus { get; set; }

        public Action<NGStep> PreExpression { get; set; }
        public Action<NGStep> PostExpression { get; set; }

        public NGStep()
        {
            this.Result = new NGStepResult(); 
        }

        protected void Print(string s) {
            var indent = new string('\t', 0 * 1);
            Console.Write(indent);
            Console.WriteLine(s);
        }

        public void OverrideStatus(NGStepStatus status)
        {
            this.ForceStatus = true; 
            this.ForcedStatus = status;
        }

        protected virtual void PreExecute()
        {
            Print(this.Name + ": Running");
        }

        protected virtual void PostExecute()
        {
            if (this.ForceStatus == true)
            {
                this.Result.Status = this.ForcedStatus;
            }
            ConsoleColor currentColor = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Red;
            if (this.Result.Status == NGStepStatus.Passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
            Print(this.Name + ": " + this.Result.Status);
            Console.ForegroundColor = currentColor; 
        }

        protected abstract void Run();

        public void Execute()
        {
            this.Result.Status = NGStepStatus.Done;

            this.PreExecute();

            if (PreExpression != null)
            {
                this.PreExpression(this);
            }

            this.Run();
            
            if (PostExpression != null)
            {
                this.PostExpression(this);
            }

            this.PostExecute(); 
        }
    }

}
