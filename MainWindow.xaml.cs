using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace pt2022 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Title = "pt2022 | "+((TabItem) tc_nav.Items[tc_nav.SelectedIndex]).Header;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = W;
            Process.Start("https://jellap.peopleteam.hu/jellap/show/" + t.Text);
        }
    }
}
