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
using System.Data;
using System.Data.SqlClient;

namespace Book.UsersSet
{
    /// <summary>
    /// Логика взаимодействия для SortPrice.xaml
    /// </summary>
    public partial class SortPrice : UserControl
    {
        public SortPrice()
        {
            InitializeComponent();
        }

        private void Price1Button_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = "SELECT book_id AS[Номер книги], book_name AS[Название книги], genre AS Жанр, author AS Автор ," +
                    "quantity AS Количество, price AS Цена FROM dbo.books WHERE(price <= 200) AND (price > 0)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

        private void Price2Button_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = "SELECT book_id AS[Номер книги], book_name AS[Название книги], genre AS Жанр, author AS Автор ," +
                    "quantity AS Количество, price AS Цена FROM dbo.books WHERE(price <= 500) AND (price > 200)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

        private void Price3Button_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = "SELECT book_id AS[Номер книги], book_name AS[Название книги], genre AS Жанр, author AS Автор ," +
                    "quantity AS Количество, price AS Цена FROM dbo.books WHERE(price <100000) AND (price > 500)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassBook.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("books"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridPrice.Children.Clear();
            GridPrice.Children.Add(new BookPage());
        }
    }
}
