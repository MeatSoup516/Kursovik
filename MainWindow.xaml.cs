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

namespace Book
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"LAPTOP-38P683PN"; //NOTEBOOK-MAX\SQLEXPRESS KOMP\SQLEXPRESS PC-MAX\SQLEXPRESS
            builder.InitialCatalog = "Kursbook";
            builder.IntegratedSecurity = true;
            ClassBook.connection = new SqlConnection(builder.ConnectionString);
            MainFrame.Navigate(new StartPage());
            ClassBook.MainFrame = MainFrame;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
