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
    public partial class Boost : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindBoost();

        }
        protected void BindBoost()
        {
            string strSQL;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            // TODO NOW Fix this query.
            strSQL = @"SELECT TOP 5 e.txtImgPath1, e.iD, e.iHtFt, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
            FROM tblServices s
            INNER JOIN tblEntry e on s.iEntryId = e.iD
            INNER JOIN tblUser u on u.id = e.iUser
            WHERE e.iBoosted = 1
            AND (e.iStatus <> 3
            OR e.iStatus is NULL)
            ORDER BY NEWID()";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                dlUpgrades.DataSource = dbManager.DataReader;
                dlUpgrades.DataBind();

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Boost:BindBoost:Error: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }        
        }
/*
 */
        public string SetBoostPicPath(object uDir, object imgPath)
        {
            if (imgPath == string.Empty)
                return "images/s1x1.gif";

            //set the default"images/s1x1.gif"
            string retVal = "images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
            }
            return retVal;
        }

/*
*/
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ShowItem(object src, CommandEventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/surfboard.aspx?" + "iD=" + e.CommandArgument.ToString()); 
        } 
    }
}