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
    public partial class LBoards : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            string strSQL;    
            strSQL = @"Select TOP 3 e.iD, e.iUser, e.iHtFt, e.iHtIn, e.txtBrand, e.txtOtherBoardType,e.txtGearItem, e.fltPrice, e.dCreateDate
                       FROM tblEntry e
                       WHERE adtype = '1' and iCategory = '1' 
                       ORDER BY e.dCreateDate DESC";

            //Create connect string
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                dlLatest.DataSource = dbManager.DataReader;
                dlLatest.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "index:Error Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error: " + strSQL);
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
            return Global.FormatDetails(oChunk, oVal);
        }
/*
*/
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False. (*OLD notes)
        public void GetValues(object src, CommandEventArgs e)
        {
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString());
        }
/*
*/
        public string FormatHeightFt(object heightFt)
        {
            return heightFt.ToString() + "\'";
        }
/*
*/
        public string FormatHeightIn(object heightIn)
        {
            return heightIn.ToString() + "\"" + "&nbsp;";
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