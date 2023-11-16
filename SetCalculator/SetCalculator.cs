using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Set
{

    [Export(typeof(ICalculator))]
    public class SetCalculator : ICalculator
    {
        public new string Name { get; set; } = "Set Calculator";
        public UserControl GetUserControl()
        {
            return new SetCalc();
        }
    }
}