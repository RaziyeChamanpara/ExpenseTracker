using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpenseTrackerComponents
{
    public class ExpenseTrackerButton:Button
    {
        public ExpenseTrackerButton()
        {
            //Padding
            this.Padding=new Thickness(10,3,10,3);

            //Margin
            Thickness margin=this.Margin;
            margin.Left = 5;
            margin.Right = 5;
            margin.Top = 5;
            this.Margin = margin;

            //Foreground
            this.Foreground = Brushes.White;

        }
    }
}
