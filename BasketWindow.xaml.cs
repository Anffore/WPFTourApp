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
        TourDatabase db = new TourDatabase();

        public BasketWindow()
        {
            InitializeComponent();
        }

        private void BasketWindow_Load(object sender, RoutedEventArgs e)
        {
            dataGridBasket.ItemsSource = db.Basket.ToList();
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    }       
}
