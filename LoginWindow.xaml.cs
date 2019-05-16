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
using WPFTourApp.Model;

namespace WPFTourApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        TourDatabaseContext db = new TourDatabaseContext();
        User mainUser = new User();

        public static string nameUser;
        public static string lastNameUser;
        public static string roleUser;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var userAdmin = db.Users.Where(u => u.Login == loginTxt.Text)
                                    .Where(u => u.Password == passTxt.Text);

            foreach(User u in userAdmin)
            {
                mainUser.UserFristName = u.UserFristName;
                mainUser.UserLastName = u.UserLastName;
                mainUser.Role = u.Role;
            }

            if (userAdmin.Any())
            {
                this.Hide();

                nameUser = mainUser.UserFristName;
                lastNameUser = mainUser.UserLastName;
                roleUser = mainUser.Role;

                MessageBox.Show("Здравствуйте" + " " + mainUser.UserFristName + " " + mainUser.UserLastName);
                Dashboard mainDashboard = new Dashboard();
                mainDashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
