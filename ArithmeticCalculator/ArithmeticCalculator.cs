using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Arithmetic
{

    [Export(typeof(ICalculator))]
    public class ArithmeticCalculator : ICalculator
    {
        public new string Name { get; set; } = "Arithmetic Calculator";
        public UserControl GetUserControl()
        {
            return new ArithmeticCalc();
        }
    }
}
