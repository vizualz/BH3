using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALLayer;
using System.Data.SqlClient;
using System.IO;


namespace BoardHunt.include.Controls
{
    public partial class VanityCtl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //log nudge
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.StoredProcedure, "sp_GetVanityMetrics");

                if (dbManager.DataReader.Read())
                {
                    lblUsers.Text = dbManager.DataReader["numUsers"] + " registered users";
                    lblBoards.Text = dbManager.DataReader["numBoards"] + " boards posted";
                    lblBoardsSold.Text = dbManager.DataReader["soldCount"] + " boards sold";
                    lblSearches.Text = dbManager.DataReader["numSearches"] + " searches";

                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "VanityCtl:Error:" + ex.Message);
                classes.Email.SendErrorEmail("VanityCtl:Error: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
    }
}