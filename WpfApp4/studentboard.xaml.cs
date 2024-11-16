using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for studentboard.xaml
    /// </summary>
    public partial class studentboard : Window
    {

        public dbconnection context = new dbconnection();
        public studentboard()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            avvcourse.ItemsSource = context.Assignment.Where(c=>c.status=="Open"&& c.student_id==MainWindow.id).ToList();
            yourcourse.ItemsSource= context.Assignment.Where(c => c.status == "Completed" && c.student_id == MainWindow.id).ToList();

        }
        public string name;
      

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();
            mainWindow.Show();
            this.Close();
        }

      

        private void finish_Click_1(object sender, RoutedEventArgs e)
        {
            name = coursetext.Text;
            var x = context.Assignment.FirstOrDefault(c=>c.title==name);
            x.status = "Completed";
            context.SaveChanges();
            MessageBox.Show("task is done");
            load_data();

        }

        private void avvcourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
