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
using System.IO;

namespace Book.UsersSet
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : UserControl
    {
        public Basket()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GridMyBooks.Children.Clear();
            GridMyBooks.Children.Add(new UserSecondPage());
        }
        private void VievOrder_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.connection.Open();
            string cmd = String.Format("SELECT dbo.orders.order_id AS [Номер заказа], dbo.books.book_name AS[название книги]," +
                "dbo.orders.book_id AS [номер книги]," +
                "dbo.books.price AS[цена] FROM dbo.orders INNER JOIN dbo.books ON dbo.orders.book_id = dbo.books.book_id WHERE client_id = @myID");
            SqlCommand command = new SqlCommand(cmd, ClassBook.connection);
            command.Parameters.Add("@myID", SqlDbType.Int);
            command.Parameters["@myID"].Value = ClassBook.myId;
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable("orders"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassBook.connection.Close();
        }

    }
}
