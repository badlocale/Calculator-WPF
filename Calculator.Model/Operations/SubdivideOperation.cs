using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public class SubdivideOperation : OperationBase
    {
        public SubdivideOperation(int delay, decimal rightOperand) : base(delay, rightOperand) { }

        public override decimal Execute(decimal leftOperand)
        {
            Thread.Sleep(_delay);

            checked
            {
                return leftOperand / _rightOperand;
            }
        }
    }
}
