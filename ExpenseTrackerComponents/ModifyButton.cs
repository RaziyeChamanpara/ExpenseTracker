using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExpenseTrackerComponents
{
    public class ModifyButton:ExpenseTrackerButton
    {
        public ModifyButton()
        {
            this.Background = Brushes.SeaGreen;
            this.BorderBrush = Brushes.SeaGreen;
        }

    }
}
