using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NG.Step;

namespace k
{
    public class NGSequence
    {
        private readonly IList<NGStep> Steps;
        public string Name { get; set; }
        public bool Pass { get; set; }

        public NGSequence(string name)
        {
            this.Name = name; 
            this.Steps = new List<NGStep>();
        
        }
        
        public int Length
        {
            get { return this.Steps.Count; }
        }

        public void Add(NGStep step) {
            this.Steps.Add(step);
        }

        public void Execute()
        {
            Console.WriteLine("{0}", this.Name);
            Pass = true; 
            foreach (var step in this.Steps)
            {
                step.Execute();
            }
            Console.WriteLine("{0} pass: {1}", this.Name, this.Pass);
        }

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public NGStep this[int index]
        {
            get
            {
                return Steps[index];
            }

            set
            {
                Steps[index] = value;
            }
        }

    }
}
