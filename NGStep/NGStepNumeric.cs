using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG.Step
{
    public enum NGComparision
    {
        Eq,
        Neq,
        Eqgt,
        Gt,
        Eqlt,
        Lt,
        Range
    }

    public class NGStepNumeric : NGStep
    {
        private int _A, _B, _C; 

        public Func<NGStepNumeric, int> A { get; set; }
        public Func<NGStepNumeric, int> B { get; set; }
        public Func<NGStepNumeric, int> C { get; set; }

        public string Unit { get; set; }

        public NGComparision Comparision { get; set; }

        public NGStepNumeric(string name)
        {
            this.Result.Status = NGStepStatus.Passed;
            this.Name = name;
        }

        protected override void Run()
        {
            this.Result.Status = NGStepStatus.Passed;
            _A = A(this);
            _B = B(this);
            _C = (Comparision == NGComparision.Range) ? C(this) : _C;

            switch (this.Comparision)
            {
                case NGComparision.Eq:
                    Console.WriteLine("{0}=={1}\t", _A, _B);
                    this.Result.Status = _A == _B ? NGStepStatus.Passed : NGStepStatus.Failed;
                    break;
                case NGComparision.Neq:
                    Console.WriteLine("{0}!={1}\t", _A, _B);
                    this.Result.Status = _A != _B ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                case NGComparision.Eqgt:
                    Console.WriteLine("{0}>={1}\t", _A, _B);
                    this.Result.Status = _A >= _B ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                case NGComparision.Eqlt:
                    Console.WriteLine("{0}<={1}\t", _A, _B);
                    this.Result.Status = _A <= _B ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                case NGComparision.Gt:
                    Console.WriteLine("{0}>{1}\t", _A, _B);
                    this.Result.Status = _A > _B ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                case NGComparision.Lt:
                    Console.WriteLine("{0}<{1}\t", _A, _B);
                    this.Result.Status = _A < _B ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                case NGComparision.Range:
                    Console.WriteLine("{0}>={1} && {0}<={2}\t", _A, _B, _C);
                    this.Result.Status = (_A >= _B) && (_A <= _C) ? NGStepStatus.Passed : NGStepStatus.Failed; ;
                    break;
                default:
                    throw new Exception("Invalid comparision method");
            }
        }
    }
}
