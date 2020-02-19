using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    public class NGStepExpression : NGStep
    {
        public Action<NGStepExpression> Expression { get; set; }
        
        public NGStepExpression(string name)
        {
            this.Name = name; 
        }
        
        protected override void Run()
        {
            try
            {
                Expression(this);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.Result.Status = NGStepStatus.Done; 
            }
        }
    }
}
