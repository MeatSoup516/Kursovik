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
    /// Логика взаимодействия для UserReg.xaml
    /// </summary>
    public partial class UserReg : Page
    {
        public UserReg()
        {
            InitializeComponent();
        }

        private void Button_Auth(object sender, RoutedEventArgs e)
        {
            ClassBook.MainFrame.Navigate(new AuthPage());
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (tbname.Text == " " || tmail.Text == " " || password.Password == " ")
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "insert into Client VALUES(@name_value, @email_value, @pass_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter Name_param = new SqlParameter("@name_value", tbname.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter email_param = new SqlParameter("@email_value", tmail.Text);
                    cmd.Parameters.Add(email_param);
                    SqlParameter pass_param = new SqlParameter("@pass_value", password.Password);
                    cmd.Parameters.Add(pass_param);
                    if (password.Password.Length < 5)
                    {
                        MessageBox.Show("Пароль не может быть меньше 5 символов!!!");
                    }
                    else
                    {
                        int symbols_count = 0;
                        for (int i = 0; i < password.Password.Length; i++) // перебираем символы
                        {
                            if (password.Password[i] >= 'A' || password.Password[i] <= 'Z' || password.Password[i] >= '0' || password.Password[i] <= '9')
                                symbols_count++;  // если русская раскладка
                        }
                        if (symbols_count < password.Password.Length)
                        {
                            MessageBox.Show("Пароль должен состоять только из английских букв и/или цифр");
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Пользователь зарегистрирован");
                            ClassBook.MainFrame.GoBack();
                        }
                    }

                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + "    " + er.Message);
                }
                ClassBook.connection.Close();
            }
        }
    }
}
