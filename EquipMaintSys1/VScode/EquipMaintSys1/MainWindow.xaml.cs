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
        #region REGION -- DATABASE CONNECTION
        static string conString = @"Data Source=172.28.134.1;Initial Catalog=L00143846_EquiptMaintSys1;Persist Security Info=True;User ID=j.mcdaid;Password=s4VrsthkQb;Pooling=False";
        SqlConnection con = new SqlConnection(conString);
        #endregion -- DATABASE CONNECTION
        #region REGION -- VARIABLES
        // fault tab variables
        int fauB = 0;
        int fauMachineSelected = 0;
        int fauTbx = 0;
        //admin tab variables
        int admB = 0;
        //string admY = "z";
        int admMachineSelected = 0;
        #endregion -- VARIABLES
        public MainWindow()
        {
            InitializeComponent();
            cbo_Selection.Visibility = System.Windows.Visibility.Hidden;
            adminBtn.Visibility = System.Windows.Visibility.Hidden;
            cbo_Fault.Visibility = System.Windows.Visibility.Hidden;
            faultsBtn.Visibility = System.Windows.Visibility.Hidden;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Hidden;
        }

        #region REGION -- Search TAB
        #endregion REGION -- Search TAB
        #region REGION -- FAULT TAB
        private void Fault_Tab_Initialized(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Equiptment", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Fault.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }// end foreach
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally

        }
        private void reportFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 1;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
        }
        private void updateFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 2;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void resolveFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 3;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Collapsed;
        }        
        private void cbo_Fault_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            faultsBtn.Visibility = System.Windows.Visibility.Visible;
            if(fauB == 1)
            {            
                tbxFaultDetail.Visibility = System.Windows.Visibility.Visible;
                fauMachineSelected = 1;
            }
        }
        private void tbxFaultDetail_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFaultDetail.Text = string.Empty;
            fauTbx = 1;

        }       
        private void faultsBtn_Click(object sender, RoutedEventArgs e)
        {
            #region REGION -- report a fault
            if (fauB==1 && fauTbx ==1)
            {
                string details = string.Format(tbxFaultDetail.Text);
                try
                {
                    string machine = cbo_Fault.SelectedItem.ToString();
                    int log_num = 1004;
                    string query = string.Format("INSERT INTO dbo.Fault_Log where Name='{0}'", machine);
                    con.Open();
                    //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                    SqlDataAdapter commObject1 = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    commObject1.Fill(dt);

                    listV_fault_data.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                    }// end FOREACH
                }// end TRY

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }// end catch

                finally
                { con.Close(); }//end finally

            }// end IF
            #endregion  REGION -- report a fault
            #region REGION -- update a fault
            else if (fauB == 2 && fauMachineSelected ==1)
            {
                try
                {
                    string machine = cbo_Fault.SelectedItem.ToString();
                    string query = string.Format("select Event_Num, Name, Component, Technician, Fault_Description, Start_Date_Time, End_Date_Time from Fault_Log where Name='{0}'", machine);
                    con.Open();
                    //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                    SqlDataAdapter commObject1 = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    commObject1.Fill(dt);

                    listV_fault_data.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        listV_fault_data.Items.Add(row.ToString());
                        //ListViewItem entry = new ListViewItem(row[0].ToString());
                        //for (int i = 1; i < dt.Columns.Count; i++)
                        //{
                        //    entry.su
                        //}
                        //faultGridView.
                        //cbo_Fault.Items.Add(row["Name"].ToString());
                        //listV_fault_data.Items.Add(row.ToString());
                        //listV_fault_data.ItemsSource = row.ToString();
                        //listV_fault_data.it
                        //listV_fault_data = new listV_fault_data(row["Name"].ToString());
                        //listV_fault_data.su
                    }// end FOREACH
                }// end TRY

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }// end catch

                finally
                { con.Close(); }//end finally

            }//else if (fauB == 3)
            #endregion REGION-- update a fault
            #region REGION -- resolve a fault



            #endregion REGION -- resolve a fault
        }// end faultsBtn_Click
        #endregion FAULT TAB
        #region REGION -- ADMIN TAB
        #region REGION -- adminTabBtnSecection
        private void queryBreakBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 1;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        private void queryMaintBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 2;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        private void queryCompBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 3;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        private void queryUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 4;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        public void addBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 5;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;


            fauB = 1;
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;

            try
            {
                con.Open();
                //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                SqlDataAdapter commObject1 = new SqlDataAdapter("select * from Item", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                    //cbo_Fault.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally

            // L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
            // using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
            //con.Open();
            //SqlCommand commObject1 = new SqlCommand("select Name from Item", con);

            // L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities();
            // using (L00143846_EquiptMaintSys1Entities db = new L00143846_EquiptMaintSys1Entities())
            //try
            //{
            //    //SqlDataAdapter sda = new SqlDataAdapter("select Name from Item", con);
            //    SqlDataReader dr = commObject1.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        //ListViewItem y = new ListViewItem(dr["Names"].ToString());
            //        //tblkOutput.ToString();
            //        //lbxOutput.ToString();
            //    }
            //    //DataTable dt = new DataTable();
            //    //sda.Fill(dt);
            //    //cbo_Selection.Items.Add(dt);
            //}// end try


        }
        private void archiveBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 6;
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion  REGION -- adminTabBtnSecection
        private void cbo_Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adminBtn.Visibility = System.Windows.Visibility.Visible;
            admMachineSelected = 1;
        }
        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            if(admB == 1 && admMachineSelected == 1) { }
            else if (admB == 2 && admMachineSelected == 1)
            {


            }
            else if (admB == 3 && admMachineSelected == 1) { }
            else if (admB == 4 && admMachineSelected == 1) { }
            else if (admB == 5 && admMachineSelected == 1) { }
            else if (admB == 6 && admMachineSelected == 1) { }
        }


        #endregion REGION -- ADMIN TAB
        #region REGION -- EXIT TAB
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        #endregion REGION -- EXIT TAB


    }// end main
}// end namespace

