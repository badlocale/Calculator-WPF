using Calculator.Model.Operations;

namespace Calculator.Model
{
    public class OperationFactory : IOperationFactory
    {
        private readonly Dictionary<char, Type> _registeredOperations = new();

        public OperationBase CreateOperation(char symbol, int delay, decimal rightOperand)
        {
            Type? type;
            if (_registeredOperations.TryGetValue(symbol, out type))
            {
                return (OperationBase)Activator.CreateInstance(type, delay, rightOperand)!;
            }
            else
            {
                throw new KeyNotFoundException("Cant find operation type with that key.");
            }
        }

        public void RegisterOperation<OperationType>(char symbol)
            where OperationType : OperationBase
        {
            _registeredOperations.Add(symbol, typeof(OperationType));
        }
    }
}
