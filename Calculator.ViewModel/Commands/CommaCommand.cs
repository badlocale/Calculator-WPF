using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel.Commands
{
    public class CommaCommand : CommandBase
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
    }
}
