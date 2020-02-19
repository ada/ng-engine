using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NG;
using System.Text.RegularExpressions;
using NG.Step;
using CustomResource;

namespace NGTest
{
    class Program
    {
        static NGSequencial engine = new NGSequencial();
        static DummyTest r = new DummyTest();
        static void ExpressionA() {
            Console.WriteLine("Expression A");
        }

        static void ExpressionB()
        {
            Console.WriteLine("Expression B");
        }

        static void CustomPreUUT() {
            bool ValidResponse = false;
            do
            {
                Console.Write("UUT Serial number: ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "x":
                        engine.ContinueTesting = false;
                        ValidResponse = true;
                        break;
                    case "":
                        Console.WriteLine("Invalid serial number.");
                        break;
                    default:
                        engine.SerialNumber = s;
                        ValidResponse = true;
                        break;
                }
            } while (!ValidResponse);
        }

        static void Main(string[] args)
        {
            SetupConsole();

            string[] seq1 = {
                ".Net -> CustomStep1 : Boolean_Step := RTestResource.RandomBool() == True",
                ".Net -> CustomStep2 : Boolean_Step := RTestResource.RandomBool() == True"
            };
            
            foreach (string item in seq1)
            {
                Regex regex = new Regex(@"(.+) -> ([A-z0-9_]+)\s:\s(Boolean_Step)\s:=\s(.+)\.(.+)\(\)\s([=><!]+)\s(.+)");
                Match match = regex.Match(item);
                if (!match.Success)
                {
                    throw new Exception();
                }

                string adapter = match.Groups[1].Value;
                string stepName = match.Groups[2].Value;
                string stepType = match.Groups[3].Value;
                string libraryName = match.Groups[4].Value; 
                string functionName = match.Groups[5].Value;
                string comparisionType = match.Groups[6].Value;
                string DesiredValue = match.Groups[7].Value;

                NGStep step = null;
                switch (adapter)
                {
                    case ".Net":
                        step = ConstructDotNetStep(stepName, stepType, libraryName, functionName, comparisionType, DesiredValue);
                        break;
                    default:
                        throw new ArgumentException($"Adapter {adapter} is not supported.");
                       
                }

                
                engine.MainSequence.Add(step);
            }

            /*
            

            PSUTest step2 = new PSUTest("FileSequence");
            */
            //engine.PreUUT = CustomPreUUT;
            //engine.MainSequence.Add(step1);
            //engine.MainSequence.Add(step2);
            engine.Start();
        }

        static NGStep ConstructDotNetStep(string stepName, string stepType, string libraryName, string functionName, string comparisionType, string DesiredValue)
        {
            return new NGStepPassFail(stepName)
            {
                FunctionPath = Scope => r.RandomBool(),
                ComparisionType = comparisionType,
                Desired = bool.Parse(DesiredValue), 
                LibraryName = libraryName+".dll",
                FunctionName = functionName
            };
        }

        static void SetupConsole()
        {
            Console.BufferHeight = 9990;
            Console.BufferWidth = Console.BufferHeight;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
