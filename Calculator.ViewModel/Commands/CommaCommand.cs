using System.Linq;

namespace Calculator.ViewModel.Commands
{
    public class CommaCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            AppViewModel viewModel = (AppViewModel)parameter!;
            viewModel.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(viewModel.ActiveValue))
            {
                viewModel.ActiveValue += "0,";
                return;
            }

            if (viewModel.ActiveValue.Count(c => c == ',') != 0)
            {
                viewModel.ErrorMessage = "Разделитель дробной части уже установлен!";
                return;
            }

            viewModel.ActiveValue += ',';
        }

        public override bool CanExecute(object? parameter)
        {
            if (parameter is AppViewModel)
            {
                return true;
            }

            return false;
        }
    }
}
