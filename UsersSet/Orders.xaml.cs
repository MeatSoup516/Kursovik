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

namespace Book.UsersSet
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (book_id_TextBox.Text == "" )
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                try
                {
                    if (true)
                    {
                        ClassBook.connection.Open();
                        string cmd = String.Format("insert into orders VALUES(@myID, @book_id_value)"); //добавление
                        SqlCommand command = new SqlCommand(cmd, ClassBook.connection);
                        command.Parameters.Add("@myID", SqlDbType.Int);
                        command.Parameters["@myID"].Value = ClassBook.myId;
                        SqlParameter Car_id_param = new SqlParameter("@book_id_value", book_id_TextBox.Text);
                        command.Parameters.Add(Car_id_param);
                        {      
                            command.ExecuteNonQuery();
                            MessageBox.Show("Заказ одобрен");
                            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "Мой заказ");
                            DirectoryInfo dirInfo = new DirectoryInfo(fileName);
                            using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLineAsync("\n\n");
                                sw.WriteLineAsync("Номер Клиента");
                                sw.WriteLine(ClassBook.myId.ToString());
                                sw.WriteLineAsync("Номер книги");
                                sw.WriteLine(book_id_TextBox.Text.ToString());
                            }
                            MessageBox.Show("Данные о заказе были записаны в раздел 'Корзина'");
                            ClassBook.MainFrame.Navigate(new UserMainPage());
                        }
                    }
                }
                catch
                {

                    MessageBox.Show("Данные введены некорректно");
                }
                ClassBook.connection.Close();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
