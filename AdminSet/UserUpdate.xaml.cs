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
    /// Логика взаимодействия для UserUpdate.xaml
    /// </summary>
    public partial class UserUpdate : UserControl
    {
        public UserUpdate()
        {
            InitializeComponent();
        }

        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Id_TextBox.Text == "" || Name_TextBox.Text == "" || Email_TextBox.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "Update Client SET  name = @Name_value,email = @Email_client_value ,password = @passwd_value WHERE (client_id = @ID_value)";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                    cmd.Parameters.Add(ID_param);
                    SqlParameter Name_param = new SqlParameter("@Name_value", Name_TextBox.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Email_param = new SqlParameter("@Email_client_value", Email_TextBox.Text);
                    cmd.Parameters.Add(Email_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены");
                    GridAdminDataUser.Children.Clear();
                    GridAdminDataUser.Children.Add(new AdDataUser());
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassBook.connection.Close();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataUser.Children.Clear();
            GridAdminDataUser.Children.Add(new AdDataUser());
        }
    }
}
