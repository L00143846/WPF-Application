using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.EntityClient;



namespace EquipMaintSys1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //static string conString = @"metadata=res://*/EntDataModel1.csdl|res://*/EntDataModel1.ssdl|res://*/EntDataModel1.msl;provider=System.Data.SqlClient;provider connection string="data source = 172.28.134.1; initial catalog = L00143846_EquiptMaintSys1; persist security info=True; user id = j.mcdaid; password=***********; pooling=False; MultipleActiveResultSets=True; App=EntityFramework";
        //static string conString = @"ws12sql1\sqlserver2016;Initial Catalog=L00143846_EquiptMaintSys1;Integrated Security=True";


        //ObservableCollection<testlist2> _testlist = new ObservableCollection<testlist2>();

        //public ObservableCollection<testlist2> TestListSummaryCollection = new ObservableCollection<testlist2>();

        //public class testlist2
        //{
        //    public string name { get; set; }
        //    //public int level { get; set; }
        //}


        public MainWindow()
        { InitializeComponent(); }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }



        public void addBtn_Click(object sender, RoutedEventArgs e)
        {
           // SqlConnection connectionObject1 = new SqlConnection(conString);
           // SqlCommand commandObject1 = new SqlCommand("select * from Item", connectionObject1);
           // SqlDataReader reader;
           // commandObject1.CommandText = "SELECT * FROM Item";
            //commandObject1.CommandType = CommandType.Text;
            //commandObject1.Connection = connectionObject1;


            L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
           // using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
                try
                {
                var query = from n in db.Item
                                //var query = from n in db.Item
                            select n;
                    foreach (String n in query)
                    {
                        cbo_Selection = query.tolist();
                    }
                }

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }

        }


    }// end main
    internal class comboBox_Selection
    {
        public static object item { get; internal set; }
    }

}// end namespace

