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
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BoardHunt.include.Controls
{
    public partial class BoostHoriz : System.Web.UI.UserControl
    {
        public int index
        {
            get
            {
                if (ViewState["index"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["index"].ToString());
            }
            set
            {
                ViewState["index"] = value;
            }
        }
     
        protected void Page_Load(object sender, EventArgs e)
        {
			pnlHotBoards.Visible = false;
			btnNext.Visible = false;
			btnPrev.Visible = false;
			return;

			try
            {

                if (!IsPostBack)
                {
                    Bind();
               
                }
            }
            catch (Exception ex)
            {
                Bind();
            }

        }

         private void Bind()
         {
             try
             {
                 DataTable dt = getTheData();

                 if (dt.Rows.Count > 0)
                 {
                     PagedDataSource _pageDataSource = new PagedDataSource();
                     _pageDataSource.DataSource = dt.DefaultView;
                     _pageDataSource.AllowPaging = true;
					_pageDataSource.PageSize = 7;
                     _pageDataSource.CurrentPageIndex = index;
                     ViewState["LastPage"] = _pageDataSource.PageCount - 1;
                     dlUpgrades.DataSource = _pageDataSource;
                     dlUpgrades.DataBind();

					//btnPrev.Visible = !_pageDataSource.IsFirstPage;
					//btnNext.Visible = !_pageDataSource.IsLastPage;

                 }
             }
			catch(Exception ex )
            {
            }
        }


        public DataTable getTheData()
        {
            string strSQL;
           // TODO NOW Fix this query.
            strSQL = @"SELECT  e.txtImgPath1, e.iD, e.iHtFt,e.iPageViewCount, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
                        FROM tblServices s
                        INNER JOIN tblEntry e on s.iEntryId = e.iD
                        INNER JOIN tblUser u on u.id = e.iUser
                        WHERE e.iBoosted = 1
                        AND (e.iStatus <> 3
                        OR e.iStatus is NULL)
                        ORDER BY NEWID()";

            DataSet DS = new DataSet();
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
            SqlDataAdapter objSQLAdapter = new SqlDataAdapter(strSQL, myConnection); objSQLAdapter.Fill(DS, "Customers");

            return DS.Tables[0];

        }

        public string SetBoostPicPath(object uDir, object imgPath)
        {
			string retVal = "~/images/s1x1.gif";	//the default

			if (imgPath.ToString() == string.Empty)
				return retVal;
				
            if (uDir != null && imgPath != null)
            {
				//retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
				retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + imgPath;

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

        public void btnPrev_Click(object sender, ImageClickEventArgs e)
        {
			//decrement unless we're on the first page
			if (index == 0) 
				index = Convert.ToInt32(ViewState ["LastPage"]);
			else
				index -= 1;

            Bind();
        }

        public void btnNext_Click(object src, CommandEventArgs e)
        {
			//increment unless we're on the last page
			if (index == Convert.ToInt32 (ViewState ["LastPage"]))
				index = 0;
			else
				index += 1;
            
			Bind();
        }

		public static string trimIt(object oVal)
		{
			if(oVal.ToString() == null)
				return string.Empty;

			if (oVal.ToString().Length > 9) {
				int count = Math.Min (oVal.ToString ().Length, 9); //9 char string
				return oVal.ToString ().Substring (0, count) + "...";
			}
			return oVal.ToString ();
		}
        
    }
}