using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
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

        //public variables
        public int xRow = 0;
        public int lineNumber = 1;

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

            string nameOut = textBoxName.Text;
            string addressOut = textBoxAddress.Text;
            int ageOut = 0;

            int ageParse = 0;
            if (nameOut != "")
            {
                if (Int32.TryParse(textBoxAge.Text.Trim(), out ageParse))
                {
                    //textBox value is a number
                    int outAge = Convert.ToInt32(textBoxAge.Text);
                    ageOut = outAge;
                 
                }
                else
                {
                    //not a number
                    MessageBox.Show("Please insert a numeric value for age.");
                }
                if (ageOut > 0 && ageOut < 101)
                {
                    if (addressOut != "")
                    {
                        //all fields validated as within range
                        MessageBox.Show(nameOut);
                        // Write the string to a file.
                        StreamWriter file = new StreamWriter("d:\\test.csv", true);
                        file.WriteLine(nameOut + ',' + ageOut + ',' + addressOut);
                        file.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please enter something into the address field");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please enter an age between 1 and 100");
                }
            }
            else
            {
                MessageBox.Show("Please enter something into the name field");
            }
           
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxAddress.Text = "";
            textBoxAge.Text = "";
            textBoxName.Text = "";
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            var rows = File.ReadAllLines("d:\\test.csv"); //get all rows/lines
            int rowCount = 0;
            foreach (var row in rows)
            {
                rowCount++;
            }

            string[] allLines = File.ReadAllLines("d:\\test.csv");
            
            string line = allLines[0];            
            
            string[] fields = line.Split(',');
            textBoxName.Text = fields[0];
            textBoxAge.Text = fields[1];
            textBoxAddress.Text = fields[2];

            MessageBox.Show(rowCount+" item(s) loaded.");
            xRow = rowCount;
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            
            int rowLimit = xRow;
            string[] allLines = File.ReadAllLines("d:\\test.csv");
           
            if(lineNumber < rowLimit)
            {
                string line = allLines[lineNumber];

                string[] fields = line.Split(',');
                textBoxName.Text = fields[0];
                textBoxAge.Text = fields[1];
                textBoxAddress.Text = fields[2];
                lineNumber++;
            }
        }
    }
}
