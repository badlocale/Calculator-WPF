using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
