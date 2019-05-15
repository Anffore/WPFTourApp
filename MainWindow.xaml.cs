using System;
using System.Linq;
using System.Windows;
using WPFTourApp.Model;

namespace WPFTourApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TourDatabase db = new TourDatabase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var tours = db.Tours.Where(t => t.From == fromTxt.Text)
                                .Where(t => t.Where == whereTxt.Text)
                                .Where(t => t.TripDate == calTxt.SelectedDate);

            if(tours.Any()) //Проверка на найденные туры
            {              
                this.Hide();
                ToursWindow tourWindow = new ToursWindow();
                tourWindow.dataGridTour.ItemsSource = tours.ToList<Tour>();
                tourWindow.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Заданных туров нет!");
            }
        }

        //Завершить работу приложения
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
