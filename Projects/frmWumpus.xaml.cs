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
    /// Interaction logic for frmWumpus.xaml
    /// </summary>
    public partial class frmWumpus : Window
    {
        public frmWumpus()
        {
            InitializeComponent();
        }

        private void ScrollToBottom()
        {
            lbxGameText.ScrollIntoView(lbxGameText.Items[lbxGameText.Items.Count - 1]);
        }

        private void WriteLine(string text)
        {
            lbxGameText.Items.Add(text);
            ScrollToBottom();
        }

        private void Write(string text)
        {
            lbxGameText.Items.Add(text);
        }
    }
}
