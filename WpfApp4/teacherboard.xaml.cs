using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for teacherboard.xaml
    /// </summary>
    public partial class teacherboard : Window
    {
        public dbconnection context = new dbconnection();
        public teacherboard()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            course_avv.ItemsSource = context.Assignment.ToList();
          

        }
       
        public string description;
        public string title;
        public int id;
        public int studentid;




        private void course_avv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            
            description= course_des.Text;
            title = course_title.Text;
            studentid = int.Parse( student_id.Text);
            Assignment x  = new Assignment();
            x.student_id = studentid;
            x.title = title;
            x.description = description;
            x.status = "Open";
            context.Assignment.Add(x);
            context.SaveChanges();
            MessageBox.Show("course added ");
            load_data();                
            
            




        }

        private void uptade_Click(object sender, RoutedEventArgs e)
        {
            description = course_des.Text;
            title = course_title.Text;
            id = int.Parse(course_id.Text);
            studentid = int.Parse(student_id.Text);
            var z =context.Assignment.FirstOrDefault(c=>c.id==id);
            if(z != null)
            {
                z.title = title;
                z.description = description;
                z.student_id=studentid;
                context.SaveChanges();
                MessageBox.Show("course updated ");
                load_data() ;




            }









        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(course_id.Text);

            var z = context.Assignment.FirstOrDefault(c => c.id == id);
            if (z != null)
            {
                context.Assignment.Remove(z);
                context.SaveChanges();
                MessageBox.Show("course removed ");
                load_data();





            }


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
