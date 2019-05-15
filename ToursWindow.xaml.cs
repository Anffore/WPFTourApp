using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using WPFTourApp.Model;

namespace WPFTourApp
{
    /// <summary>
    /// Логика взаимодействия для ToursWindow.xaml
    /// </summary>
    public partial class ToursWindow : Window
    {
        TourDatabase db = new TourDatabase();

        public ToursWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow();
            this.Close();
            basketWindow.ShowDialog();
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            Tour selectedTour = dataGridTour.SelectedItem as Tour;

            Basket basket = new Basket();
            basket.TovarId = selectedTour.Id;
            basket.Price = selectedTour.Price;
            basket.Count = Convert.ToInt32(CountBox.Text);

            db.Basket.Add(basket);
            db.SaveChanges();
        }
    }
}
