using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        struct Person
        {
            public string Vorname;
            public string Nachname;
            public int Alter { get; set; }
            public Person(string vorname, string nachname)
            {
                Vorname = vorname;
                Nachname = nachname;
                Alter = 0;
            }
        }

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
            if (!string.IsNullOrWhiteSpace(inputNames.Text) && !lstNames.Items.Contains(inputNames.Text) && e.Key == Key.Enter)
            {
                lstNames.Items.Add(inputNames.Text);
                inputNames.Clear();
            }
        }

        public void deleteNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Delete)
            {
                lstNames.Items.Remove(lstNames.SelectedItem);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            string FileName=Assembly.GetExecutingAssembly().Location+".txt";
            using (var StringWriter = new StreamWriter(FileName))
            {
                foreach(var line in lstNames.Items)
                    StringWriter.WriteLine(line);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReadData();
        }
        private void ReadData()
        {
            FileStream fs = File.Open(@"Names.dll.txt", FileMode.Open);
            using (var reader = new StreamReader(fs))
            {
                while (reader.Peek() >= 0)
                {
                    string str = reader.ReadLine() ?? string.Empty;
                    lstNames.Items.Add(str);
                }
            }
        }
    }
}
