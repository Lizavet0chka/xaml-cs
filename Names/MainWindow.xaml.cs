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
using System.Xml.Linq;

namespace Names
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

        private void addNames_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNames.Text) && !lstNames.Items.Contains(inputNames.Text))
            {
                lstNames.Items.Add(inputNames.Text);
                inputNames.Clear();
            }
        }
        private void inputNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNames.Text) && !lstNames.Items.Contains(inputNames.Text) && e.Key==Key.Enter)
            {
                lstNames.Items.Add(inputNames.Text);
                inputNames.Clear();
            }
        }
    }
}
