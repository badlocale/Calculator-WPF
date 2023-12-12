namespace Calculator.Model.EventArguments
{
    public class OperationCompletedEventArgs : EventArgs
    {
        public int ResultsQueueLenght { get; set; }
        public int RequestsQueueLenght { get; set; }
        public decimal LastResult { get; set; }

        public OperationCompletedEventArgs(
            int resultsQueueLenght,
            int requestsQueueLenght,
            decimal lastResult)
        {
            ResultsQueueLenght = resultsQueueLenght;
            RequestsQueueLenght = requestsQueueLenght;
            LastResult = lastResult;
        }
    }
}
