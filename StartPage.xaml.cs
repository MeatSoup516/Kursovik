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

namespace Book
{

    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.MainFrame.Navigate(new UsersSet.AuthPage());
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.MainFrame.Navigate(new AdminSet.AdminAuth());
        }
    }
}
