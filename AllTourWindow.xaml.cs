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
    /// Логика взаимодействия для AllTourWindow.xaml
    /// </summary>
    public partial class AllTourWindow : Window
    {
        TourDatabaseContext db = new TourDatabaseContext();

        public AllTourWindow()
        {
            InitializeComponent();

            allDataGridTour.ItemsSource = db.Tours.ToList();
        }
        /// <summary>
        /// Вернуться на главную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Dashboard newDashboard = new Dashboard();
            newDashboard.Show();

        }

        /// <summary>
        /// Перейти в корзину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow();
            this.Close();
            basketWindow.ShowDialog();
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            //получаем выбранный элемент в DataGrid типа Tour
            Tour selectedTour = allDataGridTour.SelectedItem as Tour;

            //Создаем корзину и передаем в неё значения из DataGrid
            Basket basket = new Basket();
            basket.TovarId = selectedTour.Id;
            basket.Price = selectedTour.Price;
            basket.Count = Convert.ToInt32(CountBox.Text);

            //Добавляем её в таблицу Basket
            db.Baskets.Add(basket);
            db.SaveChanges();

            //Отображаем окно корзины
            BasketWindow basketWindow = new BasketWindow();
            basketWindow.Show();
        }
    }
}
