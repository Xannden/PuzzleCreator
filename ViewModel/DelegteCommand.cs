using System;
using System.Windows.Input;

namespace PuzzleCreator.ViewModel
{
	public sealed class DelegateCommand : ICommand
	{
#pragma warning disable CS0067

		public event EventHandler CanExecuteChanged;

#pragma warning enable CS0067

		private readonly Action<object> execute;

		public DelegateCommand(Action<object> execute)
		{
			this.execute = execute;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter) => this.execute?.Invoke(parameter);
	}
}