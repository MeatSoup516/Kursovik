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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : UserControl
    {
        public AddBook()
        {
            InitializeComponent();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "" || Genre_TextBox.Text == "" || Author_TextBox.Text == "" || Price_TextBox.Text == "" || Quantity_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "insert into books VALUES(@book_name_value, @genre_value, @author_value, @price_value, @quantity_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter Model_param = new SqlParameter("@book_name_value", Name_TextBox.Text);
                    cmd.Parameters.Add(Model_param);
                    SqlParameter Color_param = new SqlParameter("@genre_value", Genre_TextBox.Text);
                    cmd.Parameters.Add(Color_param);
                    SqlParameter Year_release_param = new SqlParameter("@author_value", Author_TextBox.Text);
                    cmd.Parameters.Add(Year_release_param);
                    SqlParameter Price_day_param = new SqlParameter("@price_value", Price_TextBox.Text);
                    cmd.Parameters.Add(Price_day_param);
                    SqlParameter Mileage_param = new SqlParameter("@quantity_value", Quantity_TextBox.Text);
                    cmd.Parameters.Add(Mileage_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Книга добавлена");
                    GridAddBook.Children.Clear();
                    GridAddBook.Children.Add(new AdDataBook()); ;
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                   ClassBook.connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridAddBook.Children.Clear();
            GridAddBook.Children.Add(new AdDataBook());
        }
    }
}
