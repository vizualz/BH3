using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DALLayer;

namespace BoardHunt.include.Controls
{
    public partial class LComment : System.Web.UI.UserControl
    {
        public void Page_Load(object sender, EventArgs e)
        {
            LoadControl();
        }

        public void JumpTo(object src, CommandEventArgs e)
        {
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandName, true);
        }
/*
 */
        public void LoadControl()
        {

            //declare variables	
            string strSQL;    //Moved to global

            //Create connect string
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            string owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];

            //build SQL
            strSQL = @"SELECT TOP 3 c.iD, c.entryId, c.userId, c.txtComment, c.dPosted
                        FROM tblComments c
                        ORDER BY c.dPosted DESC";

            //Declare Dataset
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                //Get result count for paging
                int listCount = dsItems.Tables[0].Rows.Count;

                //bind to DataList control
                dlComments.DataSource = dsItems.Tables[0].DefaultView;
                dlComments.DataBind();
                //lblStatus.Text = dsItems.Tables[0].Rows[0].ToString();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ItemsGet:Error:Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "SQL: " + strSQL);
            }

            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }
/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, int oVal)
        {
            //int iVal = Convert.ToInt32(oVal);
            return Global.FormatDetails(oChunk, oVal); 
        }
/*
*/
        public string FormatTime(object oTime)
        {
            return Global.GetTimeDiff(oTime);
        }
/*
*/
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }
    }
}