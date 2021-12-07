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
    /// Логика взаимодействия для UpdateBook.xaml
    /// </summary>
    public partial class UpdateBook : UserControl
    {
        public UpdateBook()
        {
            InitializeComponent();
        }
        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Id_TextBox.Text == "" || Name_TextBox.Text == "" || Genre_TextBox.Text == "" || Author_TextBox.Text == "" || Price_TextBox.Text == "" || Quantity_TextBox.Text == "" )
            {
                MessageBox.Show("Пожалуйста, заполните все поля для обновления");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "Update books SET book_name = @Name_value, genre = @genre_value, author = @author_value, price = @Price_value, quantity = @quantity_value  WHERE (book_id = @ID_value)";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                    cmd.Parameters.Add(ID_param);
                    SqlParameter Model_param = new SqlParameter("@Name_value", Name_TextBox.Text);
                    cmd.Parameters.Add(Model_param);
                    SqlParameter Color_param = new SqlParameter("@genre_value", Genre_TextBox.Text);
                    cmd.Parameters.Add(Color_param);
                    SqlParameter Year_release_param = new SqlParameter("@author_value", Author_TextBox.Text);
                    cmd.Parameters.Add(Year_release_param);
                    SqlParameter Price_day_param = new SqlParameter("@Price_value", Price_TextBox.Text);
                    cmd.Parameters.Add(Price_day_param);
                    SqlParameter Mileage_param = new SqlParameter("@quantity_value", Quantity_TextBox.Text);
                    cmd.Parameters.Add(Mileage_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены");
                    GridAdminDataCar.Children.Clear();
                    GridAdminDataCar.Children.Add(new AdDataBook());
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
            GridAdminDataCar.Children.Clear();
            GridAdminDataCar.Children.Add(new AdDataBook());
        }
    }
}

