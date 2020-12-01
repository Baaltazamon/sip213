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

namespace sip213.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TopPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbLogin.Text != "")
            {
                tbLogin.Background = Brushes.White;
            }
            else
                tbLogin.Background = Brushes.Transparent;
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != "")
            {
                pbPassword.Background = Brushes.White;
            }
            else
                pbPassword.Background = Brushes.Transparent;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Functions.DBFunc d = new Functions.DBFunc();
            d.Autoris(tbLogin, pbPassword, this);
        }
    }
}
