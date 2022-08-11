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

namespace pt2022 {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
            Database.Register("Admin", "123");
        }

        private void btn_login_Click(object sender, RoutedEventArgs e) {

            if (Database.LogIn(tb_username.Text, tb_password.Text)) {
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            } else {
                l_error.Content = "Invalid Credentials";
            }

        }
    }
}
