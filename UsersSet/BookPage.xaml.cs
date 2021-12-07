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
using System.Text.RegularExpressions;

namespace Book.UsersSet
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : UserControl
    {
        public BookPage()
        {
            InitializeComponent();
        }

        private void PriceButton_Click(object sender, RoutedEventArgs e)
        {
            GridBooks.Children.Clear();
            GridBooks.Children.Add(new SortPrice());
        }

        private void VievBooks_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = "SELECT book_id AS[Номер книги], book_name AS[Название книги], genre AS Жанр, author AS Автор ," +
                    "quantity AS Количество, price AS Цена" +
                " FROM dbo.books WHERE (NOT (book_id IN (SELECT book_id FROM dbo.orders)))"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }
        public static string check(string variable)
        {
            Regex regex = new Regex(@"[A-z0-9А-я ]");
            if (!regex.IsMatch(variable))
                return "error";
            else
                return "";

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            {
                ClassBook.connection.Open();
                string error_msg = "";
                if ((error_msg = check(tSearch.Text)) == "")
                {
                    string search_value = tSearch.Text;
                    //Поиск
                    string Search = "SELECT book_id AS [Номер книги], book_name AS [Название книги], genre AS Жанр, author AS Автор ," +
                    "quantity AS [Количество], price AS [Цена]" +
                   " FROM books WHERE book_name LIKE '%" + search_value + "%'";
                    SqlCommand cmd = new SqlCommand(Search, ClassBook.connection);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
                    dataAdp.Fill(dt);
                    DataGrid.ItemsSource = dt.DefaultView; // Сам вывод
                    ClassBook.connection.Close();
                }
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            GridBooks.Children.Clear();
            GridBooks.Children.Add(new Orders());
        }
    }
}
