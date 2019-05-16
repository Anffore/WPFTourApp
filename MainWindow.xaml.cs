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
        TourDatabaseContext db = new TourDatabaseContext();     

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка поиска тура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Ищем тур по заданным критериям
            var tours = db.Tours.Where(t => t.From == fromTxt.Text)
                                .Where(t => t.Where == whereTxt.Text)
                                .Where(t => t.TripDate == calTxt.SelectedDate);

            //Проверка на найденные туры
            if (tours.Any()) 
            {              
                this.Hide();

                //открываем форму и отображаем в ней найденные туры
                ToursWindow tourWindow = new ToursWindow();
                tourWindow.dataGridTour.ItemsSource = tours.ToList<Tour>();
                tourWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Заданных туров нет!");
            }
        }

        //Вернуться в DashBoard
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Dashboard mainDashboard = new Dashboard();
            mainDashboard.ShowDialog();
        }
    }
}
