using System.Windows.Controls;

namespace Calculator
{
	public interface ICalculator
	{
		string Name { get; set; }
		UserControl GetUserControl();
	}
}