using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTourApp
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();       
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Text = LoginWindow.nameUser;
            UserLastName.Text = LoginWindow.lastNameUser;
            UserRole.Text = LoginWindow.roleUser;
        }

        private void SearchTour_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ShowAllTour_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllTourWindow allTourWindow = new AllTourWindow();
            allTourWindow.ShowDialog();
        }
    }
}
