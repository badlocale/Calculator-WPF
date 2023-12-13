using Calculator.Model.EventArguments;
using Calculator.Model.Operations;

namespace Calculator.Model
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
            object sender,
            ArithmeticErrorRaisedEventArgs args );
            object sender,
            ArithmeticErrorRaisedEventArgs args );
            object sender,
            ArithmeticErrorRaisedEventArgs args );

    public interface IRequestScheduler
    {
        event OperationCompletedHandler? OperationCompleted;
        event RequestAddedHandler? RequestAdded;
        event ArithmeticErrorRaisedHandler? ArithmeticErrorRaised;

        void AddRequest(OperationBase request);
        void Start();
    }
}
