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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public dbconnection context =new dbconnection();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int id;
        private void login_Click(object sender, RoutedEventArgs e)
        {
            string email = emailtext.Text;
            string pass = passtext.Password;
            var user = context.Users.FirstOrDefault(c => c.Password == pass && c.Email == email);
            

            if(user != null)
            {
                id = user.Id;

                if(user.role == "Student") 
                {
                   studentboard studentboard = new studentboard();
                    studentboard.Show();
                    this.Close();

                    MessageBox.Show("you log as student");
                }
                else
                {
                    teacherboard teacherboard = new teacherboard();
                    teacherboard.Show();
                    this.Close();
                   

                    MessageBox.Show("you log as teacher");
                }

            }

            else
            {
                MessageBox.Show("wrong mail or pass");
            }

        }
    }
}
