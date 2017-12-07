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
        // fault tab variables, the int variables are use for logic decisions
        int fauB = 0;
        int fauMachineSelected = 0;
        int fauTbx = 0;

        //admin tab variables, the int variables are use for logic decisions
        int admB = 0;
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

        private void reportFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 1;
            cbo_Fault.Items.Clear();
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;

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
        private void updateFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 2;
            cbo_Fault.Items.Clear();
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Collapsed;
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
        private void resolveFaultBtn_Click(object sender, RoutedEventArgs e)
        {
            fauB = 3;
            cbo_Fault.Items.Clear();
            cbo_Fault.Visibility = System.Windows.Visibility.Visible;
            tbxFaultDetail.Visibility = System.Windows.Visibility.Collapsed;
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
                    //string t = "10/10/2017 10:10"; //used for testing
                    string t = DateTime.Now.ToString("MM/dd/yyyy h:mm");
                    string queryReport = string.Format("INSERT INTO dbo.Fault_Log (Name, Fault_Description, Start_Date_Time) VALUES ('{0}', '{1}', '{2}')", machine, details, t);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryReport, con);
                    cmd.ExecuteNonQuery();
                    //message box used for testing
                    //MessageBox.Show(string.Format("{0}, {1}, \n{2}", machine, t, details), "Fault Details");
                }// end TRY

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }// end catch

                finally
                { MessageBox.Show("Fault successfully logged"); con.Close(); }//end finally   

            }// end IF
            #endregion  REGION -- report a fault
            #region REGION -- update a fault
            else if (fauB == 2 && fauMachineSelected ==1)//FAULTS        select * from dbo.fault_log
            {
                try
                {
                    string machine = cbo_Fault.SelectedItem.ToString();
                    //string query = string.Format("select Event_Num, Name, Component, Technician, Fault_Description, Start_Date_Time, End_Date_Time from Fault_Log where Name='{0}'", machine);
                    string query = string.Format("select * from dbo.fault_log");
                    con.Open();
                    //SqlCommand commObject1 = new SqlCommand("select Name from Equiptment", con);
                    SqlDataAdapter commObject1 = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    commObject1.Fill(dt);

                    listV_fault_data.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        
                       faultGridView.Equals(row);
                        //faultGridView.DataSource = row();
                        ////var incindent = query["Event_Num"];
                        ////var mach = query["Name"];
                        ////var component = query["Component"];
                        ////var technician = query["Technician"];
                        ////var details = query["Fault_Description"];
                        ////var startTime = query["Start_Date_Time"];
                        ////var endTime = query["End_Date_Time"];

                        ////DataRow row = dt.NewRow();
                        ////row["Incindent#"] = incindent;
                        ////row["Machine"] = mach;
                        ////row["Component"] = component;
                        ////row["Technician"] = technician;
                        ////row["Details"] = details;
                        ////row["Start Date/Time"] = startTime;
                        ////row["End Date/Time"] = endTime;
                        ////dt.Rows.Add(row);

                        // // listV_fault_data.Items.Add(row.ToString());
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
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;

            try
            {
                con.Open();
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Equiptment", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }// end foreach
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally
        }
        private void queryMaintBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 2;
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;

            try
            {
                con.Open();
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Equiptment", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }// end foreach
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally
        }
        private void queryCompBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 3;
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
            try
            {
                con.Open();
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Equiptment", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                }// end foreach 
                
                //System.Threading.Thread.Sleep(1000);

                           
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close();}//end finally           
        }
        private void queryUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 4;
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;
        }
        public void addBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 5;
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;

            try
            {
                con.Open();
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Item", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }// end foreach
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally


        }
        private void archiveBtn_Click(object sender, RoutedEventArgs e)
        {
            admB = 6;
            cbo_Selection.Items.Clear();
            cbo_Selection.Visibility = System.Windows.Visibility.Visible;

            try
            {
                con.Open();
                SqlDataAdapter commObject1 = new SqlDataAdapter("select Name from Item", con);
                DataTable dt = new DataTable();
                commObject1.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbo_Selection.Items.Add(row["Name"].ToString());
                    //listV_fault_data.Items.Add(row["Name"].ToString());
                }// end foreach
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally
        }
        #endregion  REGION -- adminTabBtnSecection
        private void cbo_Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adminBtn.Visibility = System.Windows.Visibility.Visible;
            admMachineSelected = 1;

            
        }
        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            if(admB == 1 && admMachineSelected == 1) { }        //FAULTS        select * from dbo.fault_log
            else if (admB == 2 && admMachineSelected == 1) { }  //MAINTENANCE   select * from dbo.Maintenance_Schedule
            else if (admB == 3 && admMachineSelected == 1) { }  //COMPONENTS    select * from dbo.component where Linked_Equiptment='CNC'
            else if (admB == 4 && admMachineSelected == 1) { }  //USERS         select * from dbo.Employees
            else if (admB == 5 && admMachineSelected == 1) { }  //ADD ITEM      
            else if (admB == 6 && admMachineSelected == 1) { }  //ARCHIVE ITEM  
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

