using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG
{
    public class NGSequencial : NGEngine
    {
        public string SerialNumber { get; set; }
        public int Id { get; set; }
        public Action PreUUT { get; set; }

        public NGSequencial()
        {   
            this.PreUUT = DefaultPreUUT;
        }

        protected void DefaultPreUUT()
        {
            bool ValidResponse = false; 
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Engine {Id} - UUT Serial number or 'x' to exit: ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "x":
                        this.ContinueTesting = false;
                        ValidResponse = true; 
                        break;
                    case "":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid serial number.");
                        break;
                    default:
                        this.SerialNumber = s;
                        ValidResponse = true; 
                        break;
                }
            } while (!ValidResponse);
        }

        protected void PostUUT()
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            if (this.MainSequence.Result.Status == Step.NGStepStatus.Passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("UUT {0}: {1}", this.SerialNumber, this.MainSequence.Result.Status);
            Console.ForegroundColor = c; 
            Console.WriteLine("----------------------");
        }
        
        public void Start()
        {
            while (true)
            {
                this.PreUUT();

                if (this.ContinueTesting)
                {
                    this.MainSequence.Execute();
                    this.PostUUT();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
