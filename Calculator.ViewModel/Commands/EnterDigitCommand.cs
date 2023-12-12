using System;
using System.Linq;

namespace Calculator.ViewModel.Commands
{
    public class EnterDigitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var parameters = parameter as Tuple<object, object>;
            if (parameters == null)
            {
                //Log
                return;
            }

            string? digit = parameters.Item1 as string;
            AppViewModel? viewModel = parameters.Item2 as AppViewModel;
            if (string.IsNullOrEmpty(digit) || viewModel == null)
            {
                //Log
                return;
            }

            viewModel.ErrorMessage = string.Empty;

            if (!char.IsDigit(digit.First()))
            {
                //Log
                return;
            }

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
    }
}
