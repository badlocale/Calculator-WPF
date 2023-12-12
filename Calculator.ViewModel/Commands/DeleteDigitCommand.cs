using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel.Commands
{
    public class DeleteDigitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            AppViewModel? viewModel = parameter as AppViewModel;
            if (viewModel == null)
            {
                //Log
                return;
            }

            viewModel.ErrorMessage = string.Empty;

            if (viewModel.ActiveValue.Length == 0)
            {
                //Log
                return;
            }

            viewModel.ActiveValue =
                    viewModel.ActiveValue.Remove(viewModel.ActiveValue.Length - 1);
        }
    }
}
