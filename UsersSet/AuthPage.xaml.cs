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
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace Book.UsersSet
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (Userlogin.Text.Length > 0) // проверяем введён ли логин     
            {
                if (Userpass.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными  
                    ClassBook.connection.Open();
                    string authorization = String.Format("SELECT client_id, email, password FROM [dbo].[Client] WHERE email = @email_value AND password = @pass_value");
                    SqlCommand command = new SqlCommand(authorization, ClassBook.connection);
                    SqlParameter email_param = new SqlParameter("@email_value", Userlogin.Text);
                    command.Parameters.Add(email_param);
                    SqlParameter pass_param = new SqlParameter("@pass_value", Userpass.Password);
                    command.Parameters.Add(pass_param);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassBook.myId = Convert.ToInt32(reader.GetValue(0));
                    }
                    if (reader.HasRows) // если такая запись существует       
                    {
                        ClassBook.MainFrame.Navigate(new UserMainPage());
                    }

                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
            ClassBook.connection.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.MainFrame.Navigate(new StartPage());
        }

        private void Button_WinReg_Click(object sender, RoutedEventArgs e)
        {
           ClassBook.MainFrame.Navigate(new UserReg());
        }
    }
}
