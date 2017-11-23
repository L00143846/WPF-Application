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
using System.Data.Sql;

namespace EquipMaintSys1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyDatabaseEntities dbEntities = new MyDatabaseEntities();
        List<userList> = new List<User>();


        public MainWindow()
        {
            InitializeComponent();
        }
        private void mtdLoadUsers()
        {
            userList.Clear();
            foreach (var user in dbEntities.Users)
            {
                userList.Add(user);
            }
        }
        private UserControl mtdGetUserDetails(string username, string password)
        {
            User userDetails = new User();
            foreach(var user in userList)
            {
                if (username == user.UserName && password == user.Password)
                {
                    userDetails = user;
                }
            }
            return userDetails;
        }



        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
