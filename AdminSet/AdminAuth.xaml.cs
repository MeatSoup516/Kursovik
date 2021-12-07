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


namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdminAuth.xaml
    /// </summary>
    public partial class AdminAuth : Page
    {
        public AdminAuth()
        {
            InitializeComponent();
        }
        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными  
                    ClassBook.connection.Open();
                    string authorization = "SELECT login_a, password_a FROM [dbo].[admins] WHERE [login_a] = @login_value AND [password_a] = @passwd_value";
                    SqlCommand command = new SqlCommand(authorization, ClassBook.connection);
                    SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
                    command.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    command.Parameters.Add(passwd_param);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если такая запись существует       
                    {
                        ClassBook.MainFrame.Navigate(new AdMainPage());
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
    }
}
