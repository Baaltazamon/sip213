using sip213.DateBase;
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

namespace sip213.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private readonly EMPLOYEE emp;

        public ChangePassword(DateBase.EMPLOYEE emp)
        {
            InitializeComponent();
            lbMail.Content = $"Введите код с почты {emp.MAIL}";
            this.emp = emp;
        }

       
        private void pbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lbPass.Content = pbPass.Password;
        }

        private void pbPassRew_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lbPassRew.Content = pbPassRew.Password;
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pbPass.Visibility = Visibility.Hidden;
        }

        private void Button_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            pbPassRew.Visibility = Visibility.Hidden;
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pbPass.Visibility = Visibility.Visible;
        }

        private void Button_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            pbPassRew.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.Func.SendCode(emp.MAIL);
        }
    }
}
