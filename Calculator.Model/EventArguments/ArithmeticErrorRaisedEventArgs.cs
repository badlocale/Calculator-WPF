namespace Calculator.Model.EventArguments
{
    public class ArithmeticErrorRaisedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ArithmeticErrorRaisedEventArgs(string message)
        {
            Message = message;
        }
    }
}
