using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NG;
using NG.Step;
using R; 

namespace NGTestParallel
{
    public class NGTestParallel
    {
        static Rand r = new Rand(); 

        static void Expression() {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}: Working... ");
                System.Threading.Thread.Sleep(1000);
            }
        }

        
        static void Main(string[] args)
        {
            Init();

            NGStepPassFail step = new NGStepPassFail("PassFail step");
            step.PassFail = () => r.RandomBool();
            step.PostExpression = () => {
                Console.WriteLine($"{DateTime.Now}");
            }; 

            NGParallel engine = new NGParallel();
            engine.NumberOfUUTs = 3; 
            engine.MainSequence.Add(step);
            engine.Start();
        }

        static void Init()
        {
            Console.BufferHeight = 9990;
            Console.BufferWidth = Console.BufferHeight;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    
}
