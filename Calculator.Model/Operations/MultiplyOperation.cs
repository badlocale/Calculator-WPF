namespace Calculator.Model.Operations
{
    public class MultiplyOperation : OperationBase
    {
        public MultiplyOperation(int delay, decimal rightOperand) : base(delay, rightOperand) { }

        public override decimal Execute(decimal leftOperand)
        {
            Thread.Sleep(_delay);

            checked
            {
                return leftOperand * _rightOperand;
            }
        }
    }
}
