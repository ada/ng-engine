using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    internal static class NativeWinAPI
    {
        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr hModule,
            string procedureName);
    }

    public class NGStepPassFail : NGStep
    {
        public Func<NGStepPassFail, bool> FunctionPath { get; set; }
        public string ComparisionType { get; set; }
        public bool Desired { get; set; }
        public string LibraryName { get; set; }
        public string FunctionName { get; set; }
        public NGStepPassFail(string name)
        {
            this.Name = name;
        }

        delegate void ConstructorDelegate();
        delegate bool MyFunctionDelegate();

        protected override void Run()
        {
            this.Result.Status = NGStepStatus.Running;
            IntPtr hLibrary = NativeWinAPI.LoadLibrary(LibraryName);

            if (hLibrary == IntPtr.Zero) // DLL is loaded successfully
            {
                throw new Exception("Invalid library name");
            }
                // FunctionName is, say, "MyFunctionName"
                IntPtr pointerToFunction = NativeWinAPI.GetProcAddress(hLibrary, LibraryName);

                if (pointerToFunction == IntPtr.Zero)
                {
                    throw new Exception("Invalid function name.");
                }

                ConstructorDelegate constructor = (ConstructorDelegate)Marshal.GetDelegateForFunctionPointer(
                        pointerToFunction, typeof(ConstructorDelegate));
                void instance = constructor();

                MyFunctionDelegate function = (MyFunctionDelegate)Marshal.GetDelegateForFunctionPointer(
                        pointerToFunction, typeof(MyFunctionDelegate));
                bool result = function();

                switch (ComparisionType)
                {
                    case "==":
                        if (result == Desired)
                        {
                            this.Result.Status = NGStepStatus.Passed;
                        }
                        else
                        {
                            this.Result.Status = NGStepStatus.Failed;
                        }
                        break;
                    case "!=":
                        if (result != Desired)
                        {
                            this.Result.Status = NGStepStatus.Passed;
                        }
                        else
                        {
                            this.Result.Status = NGStepStatus.Failed;
                        }
                        break;
                    default:
                        throw new ArgumentException();

                }

                NativeWinAPI.FreeLibrary(hLibrary);
            }

            
        }
    }
}
