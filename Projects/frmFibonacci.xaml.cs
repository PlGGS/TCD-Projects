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
using System.Windows.Shapes;

namespace Projects
{
    /// <summary>
    /// Interaction logic for Fibonacci.xaml
    /// </summary>
    public partial class frmFibonacci : Window
    {
        int[] fibs = new int[12];

        public frmFibonacci()
        {
            InitializeComponent();
            fibs.SetValue(1, 0);
            fibs.SetValue(1, 1);
        }

        private void btnCompute_Click(object sender, RoutedEventArgs e)
        {
            lbxFib.Items.Add("1");
            lbxFib.Items.Add("1");
            
            for (int i = 2; i < 12; i++)
            {
                fibs[i] = fibs[i - 1] + fibs[i - 2];
                lbxFib.Items.Add(fibs[i].ToString());
            }
        }
    }
}
