using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public abstract class OperationBase
    {
        protected readonly int _delay;
        protected readonly decimal _rightOperand;
        
        public OperationBase(int delay, decimal rightOperand)
        {
            _delay = delay;
            _rightOperand = rightOperand;
        }

        public abstract decimal Execute(decimal leftOperand);
    }
}
