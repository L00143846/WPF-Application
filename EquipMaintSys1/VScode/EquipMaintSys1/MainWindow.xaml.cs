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
//using System.Data.EntityClient;



namespace EquipMaintSys1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
    {
        static string conString = @"data source = 172.28.134.1; initial catalog = L00143846_EquiptMaintSys1; persist security info=True;user id = j.mcdaid; password=***********;pooling=False;MultipleActiveResultSets=True;App=EntityFramework";
        SqlConnection con = new SqlConnection(conString);

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
            con.Open();
            //connection object

            //command object
            SqlCommand commObject1 = new SqlCommand("select Name from Item", con);

            // L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
            // using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
            try
            {
                //SqlDataAdapter sda = new SqlDataAdapter("select Name from Item", con);


                SqlDataReader dr = commObject1.ExecuteReader();

                while (dr.Read())
                {
                    //ListViewItem y = new ListViewItem(dr["Names"].ToString());
                    tblkOutput.ToString();
                }

                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                //cbo_Selection.Items.Add(dt);

            }// end try

            catch (Exception ex)
                { MessageBox.Show(ex.Message); }// end catch

            finally
                {
                //connectionObject1.Close();
                //con.Close();
                }//end finally
        }// end addBtn_Click


    }// end main
    internal class comboBox_Selection
    {
        public static object item { get; internal set; }
    }

}// end namespace

