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

namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdDataBook.xaml
    /// </summary>
    public partial class AdDataBook : UserControl
    {
        public AdDataBook()
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
                    string Delete = "DELETE FROM books WHERE book_id = (@book_id)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassBook.connection);
                    SqlParameter Delete_param = new SqlParameter("@book_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Книга удалена");
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
            string cmd = "SELECT book_id AS [Номер книги],  book_name AS [Название книги], genre AS Жанр, author AS Автор , price AS Цена, " +
                "quantity AS количество FROM dbo.books"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataCar.Children.Clear();
            GridAdminDataCar.Children.Add(new AddBook());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataCar.Children.Clear();
            GridAdminDataCar.Children.Add(new UpdateBook());
        }
    }
}

