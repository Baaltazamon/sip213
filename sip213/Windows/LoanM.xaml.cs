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
    /// Логика взаимодействия для LoanM.xaml
    /// </summary>
    public partial class LoanM : Window
    {
        Functions.DBFunc f = new Functions.DBFunc();
        public LoanM(DateBase.EMPLOYEE emp)
        {
            InitializeComponent();
            f.CheckUserPassword(emp);
        }
    }
}
