using Calculator.Model.EventArguments;
using Calculator.Model.Operations;
using System.Reflection.Emit;

namespace Calculator.Model
{
    public interface IRequestScheduler
    {
        public delegate void OperationCompletedHandler(
            object sender, 
            OperationCompletedEventArgs args);
        public delegate void RequestAddedHandler(
            object sender,
            RequestAddedEventArgs args);
        public delegate void ArithmeticErrorRaisedHandler(
            object sender,
            ArithmeticErrorRaisedEventArgs args );

        event OperationCompletedHandler? OperationCompleted;
        event RequestAddedHandler? RequestAdded;
        event ArithmeticErrorRaisedHandler? ArithmeticErrorRaised;

        void AddRequest(OperationBase request);
        void Start();
    }
}
