using Calculator.Model.Operations;

namespace Calculator.Model
{
    public interface IOperationFactory
    {
        void RegisterOperation<OperationType>(char symbol)
            where OperationType : OperationBase;
        OperationBase CreateOperation(char symbol, int delay, decimal rightOperand);
    }
}
