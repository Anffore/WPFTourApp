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
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        TourDatabaseContext db = new TourDatabaseContext();

        public BasketWindow()
        {
            InitializeComponent();
            dataGridBasket.ItemsSource = db.Baskets.ToList<Basket>();
        }

        private void BasketWindow_Load(object sender, RoutedEventArgs e)
        {
            
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void DeleteFromBasket(object sender, RoutedEventArgs e)
        {
            //Выбираем объект в строке
            Basket selectedBasket = dataGridBasket.SelectedItem as Basket;
            //Присваиваем объекту ID выбранного элемента
            Basket basket = db.Baskets.Find(selectedBasket.Id);
            //Удаляем его
            db.Baskets.Remove(basket);
            db.SaveChanges();

            //Показываем обновленные данные
            dataGridBasket.ItemsSource = db.Baskets.ToList();
        }
    }       
}
