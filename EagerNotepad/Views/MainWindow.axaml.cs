using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace EagerNotepad.Views
{
	public class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void OnKeyDown(object sender, KeyEventArgs e)
		{
			this.FindControl<TextBox>("txt").Text = "FRED IS A BAD DOG";

		}
	}
}
