namespace Calculator.Model.EventArguments
{
    public class RequestAddedEventArgs : EventArgs
    {
        public int RequestsQueueLenght { get; set; }

        public RequestAddedEventArgs(int requestsQueueLenght)
        {
            RequestsQueueLenght = requestsQueueLenght;
        }
    }
}
