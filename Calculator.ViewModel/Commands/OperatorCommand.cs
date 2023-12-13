using Calculator.Model;
using Calculator.Model.Operations;
using System;

namespace Calculator.ViewModel.Commands
{
    public class OperatorCommand : CommandBase
    {
        private readonly IRequestScheduler _requestScheduler;
        private readonly IOperationFactory _operationFactory;

        public OperatorCommand(
            IRequestScheduler requestScheduler,
            IOperationFactory operationFactory)
        {
            _requestScheduler = requestScheduler;
            _operationFactory = operationFactory;
        }

        public override void Execute(object? parameter)
        {
            var parameters = (Tuple<object, object>)parameter!;
            string? operationStr = (string)parameters.Item1;
            AppViewModel? viewModel = (AppViewModel)parameters.Item2;

            viewModel.ErrorMessage = string.Empty;

            char operatorSymbol = char.Parse(operationStr);
            int delay = viewModel.DelayMilliseconds;
            decimal rightOperand = decimal.Parse(viewModel.ActiveValue);

            OperationBase operation =
                _operationFactory.CreateOperation(operatorSymbol, delay, rightOperand);

            _requestScheduler.AddRequest(operation);
        }

        public override bool CanExecute(object? parameter)
        {
            var parameters = parameter as Tuple<object, object>;
            if (parameters == null)
            {
                return false;
            }

            string? digit = parameters.Item1 as string;
            AppViewModel? viewModel = parameters.Item2 as AppViewModel;
            if (string.IsNullOrEmpty(digit) || viewModel == null)
            {
                return false;
            }

            return true;
        }
    }
}
