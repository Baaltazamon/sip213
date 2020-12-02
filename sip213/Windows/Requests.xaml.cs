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
    /// Interaction logic for Requests.xaml
    /// </summary>
    public partial class Requests : Window
    {
        Functions.DBFunc f = new Functions.DBFunc();
        public Requests()
        {
            InitializeComponent();
            f.LoadRequest(dgReq);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f.RequestAccept(dgReq);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            f.RequestReject(dgReq);
        }
    }
}
