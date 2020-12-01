using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace sip213.Functions
{
    static class Func
    {
        static public void CheckText(TextBox tb)
        {
            if (String.IsNullOrEmpty(tb.Text))
            {
                tb.BorderBrush = Brushes.Red;
            }
            else
                tb.BorderBrush = Brushes.Gray;
        }

        static public void Clear(TextBox tb)
        {
            tb.Clear();
        }

        static public void Clear(ComboBox cb, int t)
        {
            cb.SelectedIndex = t;
        }
        static public void Clear(DatePicker dp)
        {
            dp.SelectedDate = DateTime.Now;
        }
        static public void Clear(DatePicker dp, int t)
        {
            dp.Text = "";

        }

        public static string SendCode(string mailto)
        {
            SmtpClient client = new SmtpClient("smtp.mail.ru", 587);
            client.Credentials = new NetworkCredential("bwerfwe@mail.ru", "nbnfybr12");
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("bwerfwe@mail.ru");
            mail.To.Add(new MailAddress(mailto));
            mail.Subject = "Code for change password";
            string code = GenerateCode();
            mail.Body = code;
            client.Send(mail);
            return code;

        }
        public static string GenerateCode()
        {
            string code = "";
            string[] pool = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(6, 12); i++)
            {
                code += pool[rnd.Next(pool.Length)];
            }
            return code;
        }
    }
}
