using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    public interface INGSeq
    {
        int MyProperty { get; set; }
        void Add(NGStep s);
        void AddFinalization(NGStep s);
        void AddInitialization(NGStep s);
    }

    public class NGStepSeq : NGStep, INGSeq
    {
        public int MyProperty { get; set; }
        protected IList<NGStep> InitializationSteps = new List<NGStep>();
        protected IList<NGStep> MainSteps = new List<NGStep>();
        protected IList<NGStep> FinalizationSteps = new List<NGStep>();

        public NGStepSeq(string name)
        {
            this.Name = name;
        }
        
        protected override void Run()
        {
            try
            {
                if (InitializationSteps.Count > 0)
                {
                    Print("Init:");
                    foreach (var step in InitializationSteps)
                    {
                        step.Execute();
                        this.Result.Status = step.Result.Status;
                        if (this.Result.Status != NGStepStatus.Passed && this.Result.Status != NGStepStatus.Done)
                        {
                            throw new Exception("Failed or aborted at init step " + step.Name);
                        }
                    }
                }

                if (MainSteps.Count > 0)
                {
                    Print("Main: ");
                    foreach (var step in MainSteps)
                    {
                        step.Execute();
                        this.Result.Status = step.Result.Status;

                        if (this.Result.Status != NGStepStatus.Passed && this.Result.Status != NGStepStatus.Done)
                        {
                            throw new Exception("Failed or aborted at main step " + step.Name);
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                ConsoleColor t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message.ToString());
                Console.ForegroundColor = t; 
            }
            finally
            {
                if (FinalizationSteps.Count > 0)
                {
                    Print("Finalize: ");
                    foreach (var step in FinalizationSteps)
                    {
                        step.Execute();
                        this.Result.Status = step.Result.Status;
                        
                        if (this.Result.Status != NGStepStatus.Passed && this.Result.Status != NGStepStatus.Done)
                        {
                            throw new Exception("Failed or aborted at finalization step " + step.Name);
                        }
                    }
                }
            }
        }

        public void Add(NGStep s)
        {
            MainSteps.Add(s);
        }

        public void AddFinalization(NGStep s)
        {
            FinalizationSteps.Add(s);
        }

        public void AddInitialization(NGStep s)
        {
            FinalizationSteps.Add(s);
        }

        public IList<string> ToArray()
        {
            IList<string> names = new List<string>
            {
                this.Name
            };

            foreach (var item in this.MainSteps)
            {
                names.Add(item.Name);
            }

            return names;
        }
    }

}
