using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
