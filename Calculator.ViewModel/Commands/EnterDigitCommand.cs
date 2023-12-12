using System;
using System.Linq;

namespace Calculator.ViewModel.Commands
{
    public class EnterDigitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var parameters = (Tuple<object, object>)parameter!;
            string digit = (string)parameters.Item1;
            AppViewModel viewModel = (AppViewModel)parameters.Item2;

            viewModel.ErrorMessage = string.Empty;

            decimal number;

            if (!decimal.TryParse(viewModel.ActiveValue + digit.First(), out number))
            {
                viewModel.ErrorMessage = "Слишком большое число!";
                return;
            }

            if (viewModel.ActiveValue != "0")
            {
                if (number.ToString().Length != viewModel.ActiveValue.Length + 1)
                {
                    viewModel.ErrorMessage = "Слишком высокая точность дробной части!";
                    return;
                }

                viewModel.ActiveValue += digit.First();
            }
            else
            {
                viewModel.ActiveValue = digit;
            }
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

            if (!char.IsDigit(digit.First()))
            {
                return false;
            }

            return true;
        }
    }
}
