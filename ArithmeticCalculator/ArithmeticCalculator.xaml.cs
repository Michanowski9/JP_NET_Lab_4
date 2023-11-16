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

namespace Arithmetic
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class ArithmeticCalc : UserControl
	{
		public ArithmeticCalc()
		{
			InitializeComponent();
		}
		private void Calculate_OnClick(object sender, RoutedEventArgs e)
		{
			double firstNumber;
			double secondNumber;
			try
			{
				firstNumber = Double.Parse(FirstInput.Text);
				secondNumber = Double.Parse(SecondInput.Text);
			}
			catch (Exception)
			{
				Result.Text = "Error";
				return;
			}
			switch (Operand.Text)
			{
				case "+":
					Result.Text = (firstNumber + secondNumber).ToString();
					break;
				case "*":
					Result.Text = (firstNumber * secondNumber).ToString();
					break;
				default:
					Result.Text = "Error";
					break;
			}
		}
	}
}