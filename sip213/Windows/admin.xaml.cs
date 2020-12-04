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
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        Functions.DBFunc f = new Functions.DBFunc();
        
        public admin(DateBase.EMPLOYEE emp)
        {
            InitializeComponent();
            dpDateStart.DisplayDateStart = DateTime.Now;
            dpDateStart.DisplayDate = DateTime.Now;
            f.LoadEmployee(dgEmployee, cbDepartment, cbBranch, cbSuperior);
            f.CheckRequest(btReq);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f.AddEmployee(tbFirstName, tbLastName, tbLogin, cbBranch, cbTitle, cbSuperior, cbDepartment, dpDateStart, dgEmployee, tbMail);
        }

        private void dgEmployee_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            f.SelectEmployee(tbFirstName, tbLastName, tbLogin, cbBranch, cbTitle, cbSuperior, cbDepartment, dpDateStart, dpDateEnd, dgEmployee, tbMail);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            f.EditEmployee(tbFirstName, tbLastName, tbLogin, cbBranch, cbTitle, cbSuperior, cbDepartment, dpDateStart, dpDateEnd, dgEmployee, tbMail);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Functions.Func.Clear(tbFirstName);
            Functions.Func.Clear(tbLogin);
            Functions.Func.Clear(tbLastName);
            Functions.Func.Clear(tbMail);
            Functions.Func.Clear(cbTitle, 0);
            Functions.Func.Clear(cbBranch, 0);
            Functions.Func.Clear(cbDepartment, 0);
            Functions.Func.Clear(cbSuperior, -1);
            Functions.Func.Clear(dpDateEnd, 0);
            Functions.Func.Clear(dpDateStart);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            f.DeleteEmployee(dgEmployee);
        }

        private void btReq_Click(object sender, RoutedEventArgs e)
        {
            Windows.Requests req = new Requests();
            req.ShowDialog();
            f.LoadEmployee(dgEmployee, cbDepartment, cbBranch, cbSuperior);
        }
    }
}
