namespace Calculator.ViewModel.Commands
{
    public class DeleteDigitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            AppViewModel? viewModel = (AppViewModel)parameter!;

            viewModel.ErrorMessage = string.Empty;

            if (viewModel.ActiveValue.Length == 0)
            {
                return;
            }

            viewModel.ActiveValue =
                    viewModel.ActiveValue.Remove(viewModel.ActiveValue.Length - 1);
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
