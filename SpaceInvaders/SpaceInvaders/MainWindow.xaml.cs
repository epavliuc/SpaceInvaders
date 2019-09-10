using System;
using System.Collections.Generic;
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

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Player Control, left to right. + boundaries
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {          
            double x = Canvas.GetLeft(player);
            if (x > 0 & x < 600)
            {
                if (e.Key == Key.Left)
                {
                    Canvas.SetLeft(player, x -= 10);
                }
                else if (e.Key == Key.Right)
                {
                    Canvas.SetLeft(player, x += 10);
                }
            }else if (x <= 0)
            {
                Canvas.SetLeft(player, x + 10);
            }
            else if (x >= 600)
            {
                Canvas.SetLeft(player, x - 10);
            }
        }
    }
}
