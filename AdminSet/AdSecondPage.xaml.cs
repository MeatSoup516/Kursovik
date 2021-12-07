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

namespace Book.AdminSet
{
    /// <summary>
    /// Логика взаимодействия для AdSecondPage.xaml
    /// </summary>
    public partial class AdSecondPage : UserControl
    {
        public AdSecondPage()
        {
            InitializeComponent();
        }
        private void Button_Edit_Admin(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdnDataAdmin());
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassBook.MainFrame.Navigate(new StartPage());
        }

        private void Button_Plus_Admin(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdminAdd());
        }
    }
}
