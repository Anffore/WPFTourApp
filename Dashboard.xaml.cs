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

        /// <summary>
        /// Присваиваем текстовым полям значения текущего пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Text = LoginWindow.nameUser;
            UserLastName.Text = LoginWindow.lastNameUser;
            UserRole.Text = LoginWindow.roleUser;
        }

        /// <summary>
        /// Переход на форму поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTour_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// Переход на форму всех туров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllTour_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllTourWindow allTourWindow = new AllTourWindow();
            allTourWindow.ShowDialog();
        }
    }
}
