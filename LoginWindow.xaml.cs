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
        TourDatabaseContext db = new TourDatabaseContext(); //Контекст данных
        User mainUser = new User(); //Объект хранящий текущего пользователя

        #region Статические переменные
        public static string nameUser; //Имя 
        public static string lastNameUser; //Фамилия
        public static string roleUser; //Роль
        #endregion

        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Авторизирует пользователя по заданому логину и паролю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            //Сравниваем введенный логин и пароль с данными в таблице
            var userAdmin = db.Users.Where(u => u.Login == loginTxt.Text)
                                    .Where(u => u.Password == passTxt.Text);

            //По заданному логину и паролю, находим пользователя с такими данными и присваиваем полям класса User
            foreach(User u in userAdmin)
            {
                mainUser.UserFristName = u.UserFristName;
                mainUser.UserLastName = u.UserLastName;
                mainUser.Role = u.Role;
            }

            //Проверка на NULL, если проверка пройдена, открываем главную форму
            if (userAdmin.Any())
            {
                this.Hide();

                #region Передаем значения User в статические поля
                nameUser = mainUser.UserFristName;
                lastNameUser = mainUser.UserLastName;
                roleUser = mainUser.Role;
                #endregion

                MessageBox.Show("Здравствуйте" + " " + mainUser.UserFristName + " " + mainUser.UserLastName);
                Dashboard mainDashboard = new Dashboard();
                mainDashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
