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

namespace pt2022
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        int timesclicked = 0;
        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            timesclicked++;

            if (timesclicked % 2 == 0)
            {
                txtbox.IsReadOnly = false;

            }
            else
            {
                txtbox.IsReadOnly = true;
            }

        }

        private void passave_Click(object sender, RoutedEventArgs e)
        {
            if (passtxt.Password == conpasstxt.Password)
            {
                MessageBox.Show("Your passwords match!");
            }
            else
            {
                MessageBox.Show("Your passwords dont match!");
            }
        }
    }
}
