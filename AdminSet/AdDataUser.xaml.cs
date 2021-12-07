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
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdDataUser.xaml
    /// </summary>
    public partial class AdDataUser : UserControl
    {
        public AdDataUser()
        {
            InitializeComponent();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataUser.Children.Clear();
            GridAdminDataUser.Children.Add(new UserUpdate());
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            {
                ClassBook.connection.Open();
                string cmd = "SELECT client_id AS [Номер клиента], name AS ФИО, " +
                    " email AS Email, " +
                    " password AS Пароль FROM dbo.Client"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Client"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                ClassBook.connection.Close();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Delete_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните поле для удаления");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string Delete = "DELETE FROM Client WHERE client_id = (@client_id)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassBook.connection);
                    SqlParameter Delete_param = new SqlParameter("@client_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален");
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
