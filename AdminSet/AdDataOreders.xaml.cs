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
using System.IO;


namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdDataOreders.xaml
    /// </summary>
    public partial class AdDataOreders : UserControl
    {
        public AdDataOreders()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Orders_id_TextBox.Text == "")
                {
                    MessageBox.Show("Пожалуйста, заполните поле для удаления");
                }
                else
                {
                    try
                    {
                        ClassBook.connection.Open();
                        string Delete = "DELETE FROM orders WHERE order_id = (@order_id)";
                        SqlCommand cmd = new SqlCommand(Delete, ClassBook.connection);
                        SqlParameter Delete_param = new SqlParameter("@order_id", Orders_id_TextBox.Text);
                        cmd.Parameters.Add(Delete_param);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Заказ отменен");
                    }
                    catch
                    {

                        MessageBox.Show("Введите номер заказа");
                    }
                    ClassBook.connection.Close();
                }
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Book_id_TextBox.Text == "" || Client_id_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    ClassBook.connection.Open();
                    string registration = "insert into orders VALUES(@client_id_value, @book_id_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassBook.connection);
                    SqlParameter login_param = new SqlParameter("@book_id_value", Book_id_TextBox.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@client_id_value", Client_id_TextBox.Text);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                    GridOrders.Children.Clear();
                    GridOrders.Children.Add(new AdDataOreders());
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
