using Calculator.Model;
using Calculator.Model.EventArguments;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IRequestScheduler _requestScheduler;
        private string _activeValue = "0";
        private string _errorMessage = string.Empty;
        private decimal _lastResult = 0;
        private int _delay = 0;
        private int _resultsQueueLenght = 0;
        private int _requestsQueueLenght = 0;
        private bool _hasDecimalPoint = false;

        public string ActiveValue
        {
            get => _activeValue;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _activeValue = "0";
                }
                else
                {
                    _activeValue = value;
                }

                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;

                if (!string.IsNullOrEmpty(_errorMessage))
                {
                    SystemSounds.Asterisk.Play();
                }

                OnPropertyChanged();
            }
        }

        public decimal LastResult
        {
            get => _lastResult;
            set
            {
                _lastResult = value;
                OnPropertyChanged();
            }
        }

        public int DelayMilliseconds
        {
            get => _delay;
            set
            {
                _delay = value;
                OnPropertyChanged();
            }
        }

        public int ResultsQueueLenght
        {
            get => _resultsQueueLenght;
            set
            {
                _resultsQueueLenght = value;
                OnPropertyChanged();
            }
        }

        public int RequestsQueueLenght
        {
            get => _requestsQueueLenght;
            set
            {
                _requestsQueueLenght = value;
                OnPropertyChanged();
            }
        }


        public bool HasDecimalPoint
        {
            get => _hasDecimalPoint;
            set
            {
                _hasDecimalPoint = value;
                OnPropertyChanged();
            }
        }

        public ICommand CommaCommand { get; set; }
        public ICommand DeleteDigitCommand { get; set; }
        public ICommand EnterDigitCommand { get; set; }
        public ICommand OperatorCommand { get; set; }

        public AppViewModel(
            IRequestScheduler requestScheduler,
            ICommand commaCommand,
            ICommand deleteDigitCommand,
            ICommand enterDigitCommand,
            ICommand operatorCommand)
        {
            _requestScheduler = requestScheduler;

            CommaCommand = commaCommand;
            DeleteDigitCommand = deleteDigitCommand;
            EnterDigitCommand = enterDigitCommand;
            OperatorCommand = operatorCommand;

            _requestScheduler.OperationCompleted += OperationCompletedHandler;
            _requestScheduler.RequestAdded += RequestAddedHandler;
            _requestScheduler.ArithmeticErrorRaised += ArithmeticErrorRaisedHandler;

            _requestScheduler.Start();
        }

        private void OperationCompletedHandler(object? s, OperationCompletedEventArgs args)
        {
            ResultsQueueLenght = args.ResultsQueueLenght;
            RequestsQueueLenght = args.RequestsQueueLenght;
            LastResult = args.LastResult;
            ActiveValue = "0";
        }

        private void RequestAddedHandler(object? s, RequestAddedEventArgs args)
        {
            RequestsQueueLenght = args.RequestsQueueLenght;
            ErrorMessage = string.Empty;
        }

        private void ArithmeticErrorRaisedHandler(object? s, ArithmeticErrorRaisedEventArgs args)
        {
            ErrorMessage = args.Message;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
