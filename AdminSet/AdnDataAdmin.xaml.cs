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
using Book.AdminSet;

namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdnDataAdmin.xaml
    /// </summary>
    public partial class AdnDataAdmin : UserControl
    {
        public AdnDataAdmin()
        {
            InitializeComponent();
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
                    string Delete = "DELETE FROM admins WHERE id_admin = (@id_admin)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassBook.connection);
                    SqlParameter Delete_param = new SqlParameter("@id_admin", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Администратор удален");
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassBook.connection.Close();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = "SELECT id_admin AS [Номер администратора], Login_a AS Логин, Password_a AS Пароль FROM dbo.admins"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("admins"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdSecondPage());
        }
    }
}