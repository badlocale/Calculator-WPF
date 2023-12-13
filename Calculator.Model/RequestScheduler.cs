using Calculator.Model.EventArguments;
using Calculator.Model.Operations;
using System.Collections.Concurrent;

namespace Calculator.Model
{
    public class RequestScheduler : IRequestScheduler
    {
        private readonly ConcurrentQueue<OperationBase> _requests = new();
        private readonly ConcurrentQueue<decimal> _results = new();

        public event OperationCompletedHandler? OperationCompleted;
        public event RequestAddedHandler? RequestAdded;
        public event ArithmeticErrorRaisedHandler? ArithmeticErrorRaised;

        public void AddRequest(OperationBase operationRequest)
        {
            _requests.Enqueue(operationRequest);
            OnRequestAdded();
        }

        public void Start()
        {
            Task.Run(Process);
        }

        private void Process()
        {
            OperationBase? operation;
            decimal result;

            while (true)
            {
                if (_requests.TryDequeue(out operation))
                {
                    try
                    {
                        result = operation.Execute(GetLastResult());
                        _results.Enqueue(result);
                    }
                    catch (DivideByZeroException)
                    {
                        OnArithmeticErrorRaised("На нуль делить нельзя!");
                    }
                    catch (OverflowException)
                    {
                        OnArithmeticErrorRaised("Слишком большая целая часть результата!");
                    }
                    finally
                    {
                        OnOperationCompleted();
                    }
                }
            }
        }

        private void OnOperationCompleted()
        {
            var eventArgs = new OperationCompletedEventArgs(
                _results.Count(), _requests.Count(), GetLastResult());

            OperationCompleted?.Invoke(this, eventArgs);
        }

        private void OnRequestAdded()
        {
            var eventArgs = new RequestAddedEventArgs(_requests.Count());

            RequestAdded?.Invoke(this, eventArgs);
        }

        private void OnArithmeticErrorRaised(string message)
        {
            var eventArgs = new ArithmeticErrorRaisedEventArgs(message);

            ArithmeticErrorRaised?.Invoke(this, eventArgs);
        }

        private decimal GetLastResult()
        {
            if (_results.Count > 0)
            {
                return _results.Last();
            }

            return 0;
        }
    }
}
