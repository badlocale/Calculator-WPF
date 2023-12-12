using Calculator.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public interface IOperationFactory
    {
        void RegisterOperation<OperationType>(char symbol)
            where OperationType : OperationBase;
        OperationBase CreateOperation(char symbol, int delay, decimal rightOperand);
    }
}
