using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    public enum NGStepStringOperation {
        Contains, 
        Equal, 
        NotEqual
    }
    
    public class NGStepString : NGStep
    {
        public Func<NGStepString, string> A { get; set; }
        public Func<NGStepString, string> B { get; set; }
        public StringComparison StringComparision { get; set; }
        public NGStepStringOperation Operation { get; set; }

        public NGStepString(string name)
        {
            this.Name = name;
            this.Operation = NGStepStringOperation.Equal;
            this.StringComparision = StringComparison.OrdinalIgnoreCase;
        }

        protected override void Run()
        {
            switch (Operation)
            {
                case NGStepStringOperation.Contains:
                    if (A(this).Contains(B(this)))
                    {
                        this.Result.Status = NGStepStatus.Passed;
                    }
                    else
                    {
                        this.Result.Status = NGStepStatus.Failed;
                    }
                    break;
                case NGStepStringOperation.Equal:
                    if (String.Equals(A(this), B(this), this.StringComparision))
                    {
                        this.Result.Status = NGStepStatus.Passed;
                    }
                    else
                    {
                        this.Result.Status = NGStepStatus.Failed;
                    }
                    break;
                case NGStepStringOperation.NotEqual:
                    if (!String.Equals(A(this), B(this), this.StringComparision))
                    {
                        this.Result.Status = NGStepStatus.Passed;
                    }
                    else
                    {
                        this.Result.Status = NGStepStatus.Failed;
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            
        }
    }
}
