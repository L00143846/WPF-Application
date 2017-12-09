using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EquipMaintSys1
{
    public partial class Login_Screen : UserControl
    {
        #region REGION -- DATABASE CONNECTION
        static string conString = @"Data Source=172.28.134.1;Initial Catalog=L00143846_EquiptMaintSys1;Persist Security Info=True;User ID=j.mcdaid;Password=s4VrsthkQb;Pooling=False";
        SqlConnection con = new SqlConnection(conString);
        #endregion -- DATABASE CONNECTION
        public Login_Screen()
        {
            InitializeComponent();
        }

        #region REGION -- LOGIN BUTTON
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string name = Tbx_User.Text.ToString();
            string passwd = Tbx_Password.Text.ToString();

            try
            {
                con.Open();
                string query = string.Format("select UserPassword from dbo.Employees WHERE Name ='{0}'", name);
                SqlDataAdapter commObject1 = new SqlDataAdapter(query, con);

                string passwdReturned = commObject1.ToString();
                MessageBox.Show(name, passwdReturned);
            }// end try

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }// end catch

            finally
            { con.Close(); }//end finally
        }// END Btn_Login_Click()
        #endregion REGION -- LOGIN BUTTON

        #region REGION -- EXIT BUTTON
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion REGION -- EXIT BUTTON


    }// END class
}// END namespace
