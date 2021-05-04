using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		// HACK: I really need to write some comments but I'm too lazy so have an emoji 😛

		public void OnKeyDown(object sender, KeyEventArgs e)
		{
			
		}

		public void OnKeyUp(object sender, KeyEventArgs e)
		{
			string thisStr = e.Key.ToString();
			if (thisStr.Length == 1)
			{
				char? thisChar = thisStr[0];
				if (lastChar is not null)
				{
					string prefix = $"{lastChar}{thisChar}";
					if (prefix.Length >= 2)
					{
						var word = AutoComplete(prefix);
						if (word is not null)
						{
							var txt = this.FindControl<TextBox>("txt");
							string suffix = word.Substring(prefix.Length);
							txt.Text += suffix + " ";
							txt.CaretIndex += suffix.Length + 1;
							thisChar = null;
						}
					}
				}
				lastChar = thisChar;
			}
			else
			{
				lastChar = null;
			}
		}

		private char? lastChar;

		private string? AutoComplete(string start)
		{
			return Words.FirstOrDefault(q => q.ToLower().StartsWith(start.ToLower()));
		}

		private string[] Words { get; } = File.ReadAllLines("Assets/Words.txt");
	}
}
