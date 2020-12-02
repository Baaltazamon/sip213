using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace sip213.Functions
{
    class DBFunc
    {
        DateBase.sip213Entities db = new DateBase.sip213Entities();
        public void Autoris(TextBox log, PasswordBox pass, Window win)
        {
            DateBase.EMPLOYEE emp = db.EMPLOYEE.Where(c => c.login == log.Text && c.password == pass.Password).SingleOrDefault();
            if (emp == null)
            {
                pass.Clear();
                MessageBox.Show("Такой комбинации логин/пароль не существует!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                Func.CheckText(log); 
            }
            else
            {
                if (emp.TITLE == "Operations Manager")
                {
                    Windows.admin a = new Windows.admin(emp);
                    a.Show();
                    win.Close();
                }
                else if (emp.TITLE == "Loan Manager")
                {
                    Windows.LoanM LM = new Windows.LoanM(emp);
                    LM.Show();
                    win.Close();
                }
            }
        }

        public void LoadEmployee(DataGrid grid, ComboBox depart, ComboBox branch, ComboBox superior)
        {
            grid.ItemsSource = db.EMPLOYEE.ToList();
            depart.ItemsSource = db.DEPARTMENT.ToList();
            branch.ItemsSource = db.BRANCH.ToList();
            superior.ItemsSource = db.EMPLOYEE.ToList();
        }

        public void AddEmployee(TextBox FN, TextBox LN, TextBox Log, ComboBox branch, ComboBox title, ComboBox superior, ComboBox depart, DatePicker date, DataGrid dg, TextBox mail)
        {
            DateBase.EMPLOYEE emp = new DateBase.EMPLOYEE
            {
                FIRST_NAME = FN.Text,
                LAST_NAME = LN.Text,
                login = Log.Text,
                ASSIGNED_BRANCH_ID = (branch.SelectedItem as DateBase.BRANCH).BRANCH_ID,
                DEPT_ID = (depart.SelectedItem as DateBase.DEPARTMENT).DEPT_ID,
                TITLE = title.Text,
                password = "qwe",
                START_DATE = Convert.ToDateTime(date.Text),
                MAIL = mail.Text
                
            };
            db.EMPLOYEE.Add(emp);
            db.SaveChanges();
            LoadEmployee(dg, depart, branch, superior);
        }

        public void CheckUserPassword(DateBase.EMPLOYEE emp)
        {
            if (emp.password == "qwe")
            {
                Windows.ChangePassword CP = new Windows.ChangePassword(emp);
                CP.ShowDialog();
            }
        }
        public void SelectEmployee(TextBox FN, TextBox LN, TextBox Log, ComboBox branch, ComboBox title, ComboBox superior, ComboBox depart, DatePicker date, DatePicker dateEnd, DataGrid dg, TextBox mail)
        {
            DateBase.EMPLOYEE emp = dg.SelectedItem as DateBase.EMPLOYEE;
            if (emp == null)
                return;
            FN.Text = emp.FIRST_NAME;
            LN.Text = emp.LAST_NAME;
            Log.Text = emp.login;
            branch.SelectedItem = db.BRANCH.Where(c => c.BRANCH_ID == emp.ASSIGNED_BRANCH_ID).FirstOrDefault();
            title.Text = emp.TITLE;
            superior.SelectedItem = (emp.SUPERIOR_EMP_ID == null) ? null: db.EMPLOYEE.Where(c => c.EMP_ID == emp.EMPLOYEE2.EMP_ID).SingleOrDefault();
            depart.SelectedItem = db.DEPARTMENT.Where(c => c.DEPT_ID == emp.DEPT_ID).FirstOrDefault();
            date.Text = emp.START_DATE.ToString();
            dateEnd.Text = emp.END_DATE.ToString();
            mail.Text = emp.MAIL;
        }

        public void EditEmployee(TextBox FN, TextBox LN, TextBox Log, ComboBox branch, ComboBox title, ComboBox superior, ComboBox depart, DatePicker date, DatePicker dateEnd, DataGrid dg, TextBox mail)
        {
            DateBase.EMPLOYEE emp = dg.SelectedItem as DateBase.EMPLOYEE;
            if (emp == null)
                return;
            emp.FIRST_NAME = FN.Text;
            emp.LAST_NAME = LN.Text;
            emp.login = Log.Text;
            emp.ASSIGNED_BRANCH_ID = (branch.SelectedItem as DateBase.BRANCH).BRANCH_ID;
            emp.DEPT_ID = (depart.SelectedItem as DateBase.DEPARTMENT).DEPT_ID;
            emp.TITLE = title.Text;
            if (superior.SelectedIndex != -1)
            {
                emp.SUPERIOR_EMP_ID = (superior.SelectedItem as DateBase.EMPLOYEE).EMP_ID;
            }
            emp.START_DATE = Convert.ToDateTime(date.Text);
            if (dateEnd.Text != "")
            {
                emp.END_DATE = Convert.ToDateTime(dateEnd.Text);
            }
            emp.MAIL = mail.Text;
            db.SaveChanges();
            LoadEmployee(dg, depart, branch, superior);
        }

        public void DeleteEmployee(DataGrid dg)
        {
            DateBase.EMPLOYEE emp = dg.SelectedItem as DateBase.EMPLOYEE;
            if (emp == null)
                return;
            db.EMPLOYEE.Remove(emp);
            db.SaveChanges();
            dg.ItemsSource = db.EMPLOYEE.ToList();

        }
        
        public void ChangePass(int id, PasswordBox pb, PasswordBox pbrew)
        {
            DateBase.EMPLOYEE emp = db.EMPLOYEE.Where(c => c.EMP_ID == id).SingleOrDefault();
            if (pb.Password != pbrew.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка смены пароля!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            emp.password = pb.Password;
            db.SaveChanges();
            MessageBox.Show("Пароль изменён.", "Complete", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void SendRequest(TextBox mail, int id, string oldMail)
        {
            DateBase.Request req = new DateBase.Request
            {
                UserRequest = id,
                NewMail = mail.Text,
                OldMail = oldMail
            };
            db.Request.Add(req);
            db.SaveChanges();
        }

        public void CheckRequest(Button bt)
        {
            int count = db.Request.Count();
            bt.Content = $"Заявок ({count})";
        }

        public void LoadRequest(DataGrid dg)
        {
            dg.ItemsSource = db.Request.ToList();
        }

        public void RequestAccept(DataGrid dg)
        {
            DateBase.Request req = dg.SelectedItem as DateBase.Request;
            if (req == null)
                return;
            DateBase.EMPLOYEE emp = db.EMPLOYEE.Where(c => c.EMP_ID == req.UserRequest).SingleOrDefault();
            emp.MAIL = req.NewMail;
            db.Request.Remove(req);
            db.SaveChanges();
            LoadRequest(dg);
        }

        public void RequestReject(DataGrid dg)
        {
            DateBase.Request req = dg.SelectedItem as DateBase.Request;
            if (req == null)
                return;
            db.Request.Remove(req);
            db.SaveChanges();
            LoadRequest(dg);
        }
    }
}
