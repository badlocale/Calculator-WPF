using System.Windows;
using System.Windows.Input;
using Calculator.Model;
using Calculator.Model.Operations;
using Calculator.ViewModel;
using Calculator.ViewModel.Commands;

namespace Calculator.View
{
    public partial class App : Application
    {
        private Window _startupWindow = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            IOperationFactory operationFactory = new OperationFactory();
            operationFactory.RegisterOperation<AddOperation>('+');
            operationFactory.RegisterOperation<SubstractOperation>('-');
            operationFactory.RegisterOperation<MultiplyOperation>('*');
            operationFactory.RegisterOperation<SubdivideOperation>('/');

            IRequestScheduler requestScheduler = new RequestScheduler();
            ICommand operatorCommand = new OperatorCommand(requestScheduler, operationFactory);
            ICommand commaCommand = new CommaCommand();
            ICommand deleteDigitCommand = new DeleteDigitCommand();
            ICommand enterDigitCommand = new EnterDigitCommand();

            AppViewModel viewModel = new(
                requestScheduler, 
                commaCommand, 
                deleteDigitCommand, 
                enterDigitCommand, 
                operatorCommand);

            _startupWindow = new CalculatorWindow();
            _startupWindow.DataContext = viewModel;
            _startupWindow.Show();

            base.OnStartup(e);
        }
    }
}
