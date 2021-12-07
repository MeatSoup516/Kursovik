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
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : UserControl
    {
        public AdminAdd()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridAdminAdd.Children.Clear();
            GridAdminAdd.Children.Add(new AdSecondPage());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginAdm_TextBox.Text == "" || PasswordAdm_TextBox.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "insert into admins VALUES(@login_a_value, @passord_a_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter login_param = new SqlParameter("@login_a_value", LoginAdm_TextBox.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passord_a_value", PasswordAdm_TextBox.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Администратор добавлен");
                    GridAdminAdd.Children.Clear();
                    GridAdminAdd.Children.Add(new AdSecondPage());
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassBook.connection.Close();
            }
        }
    }
}