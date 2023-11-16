using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SetCalculator
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	[Export(typeof(ICalculator))]
	public partial class UserControl1 : UserControl, ICalculator
	{
		public new string Name { get; set; } = "Set Calculator";
		public UserControl1()
		{
			InitializeComponent();
		}
		public UserControl GetUserControl()
		{
			return this;
		}

		private void Calculate_OnClick(object sender, RoutedEventArgs e)
		{
			var set1 = FirstInput.Text.Split(" ");
			var set2 = SecondInput.Text.Split(" ");
			switch (Operand.Text)
			{
				case "+":
					Result.Text = String.Join(" ", set1.Union(set2));
					break;
				case "*":
					Result.Text = String.Join(" ", set1.Intersect(set2));
					break;
				default:
					Result.Text = "Error";
					break;
			}
		}
	}
}