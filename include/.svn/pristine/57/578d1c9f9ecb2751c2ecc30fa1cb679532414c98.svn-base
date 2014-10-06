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
    public partial class Shapers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
/*
 */
        protected void BindData()
        {
            string strSQL;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            //build SQL
            strSQL = @"SELECT  u.txtUserName, u.iD, u.profilePic, u.userDir, u.txtBrandName 
            FROM tblUser u
            INNER JOIN tblServices s ON u.iD = s.iUserId
            WHERE u.iAcctType = 2 AND u.iMerchantType = 1 AND s.iServiceVal = 3 AND s.iStatus = 1
            ORDER by txtBrandName ASC"; //ORDER BY NEWID()

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
                ErrorLog.ErrorRoutine(false, "Shapers:Error:Bind: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        public string SetPicPath(object uDir, object imgPath)
        {

            //set the default
            string retVal = System.Web.VirtualPathUtility.ToAbsolute("~") + "images/nopic32.jpg";
            if (imgPath != null)
            {
                if (imgPath.ToString().Length < 1)
                    return retVal;
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "/" + "thmbNail_" + imgPath;
            }
            return retVal;
        }

/*
*/
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ShowItem(object src, CommandEventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/Shaper/Surfboardshaper.aspx?" + "q=" + e.CommandArgument.ToString());
        } 
    }
}