using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Input;

namespace EagerNotepad.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public string Text { get; set; } = "Welcome to Eager Notepad! Feel free to delete this text and type your own!";
	}
}
