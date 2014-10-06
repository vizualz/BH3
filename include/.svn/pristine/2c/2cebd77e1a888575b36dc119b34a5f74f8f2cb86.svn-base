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
using System.Configuration;
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
            try
            {
                //if (!Page.IsPostBack)
                //{
                //    BindBoost();

                if (!IsPostBack)
                {
                    Bind();
               
                }
            }
            catch (Exception ex)
            {
                Bind();
            }

            //}

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
                     _pageDataSource.PageSize = 5;
                     _pageDataSource.CurrentPageIndex = index;
                     ViewState["LastPage"] = _pageDataSource.PageCount - 1;
                     dlUpgrades.DataSource = _pageDataSource;
                     dlUpgrades.DataBind();

                     //if (_pageDataSource.IsFirstPage == true)
                     //{
                     //    btnNext.Visible = true;
                     //    btnPrev.Visible = false;
                     //}
                     //if (_pageDataSource.IsLastPage == true)
                     //{
                     //    btnPrev.Visible = true;
                     //    btnNext.Visible = false;
                     //}

                     
                     //if ((_pageDataSource.IsFirstPage != true) && (_pageDataSource.IsLastPage != true))
                     //{
                     //    btnPrev.Visible = true;
                     //    btnNext.Visible = true;
                     //}


                     btnPrev.Visible = !_pageDataSource.IsFirstPage;
                     btnNext.Visible = !_pageDataSource.IsLastPage;

                     //lnkFirst.Visible = !_ pageDataSource.IsFirstPage;
                     //lnkLast.Visible = !_ pageDataSource.IsLastPage;

                 }
             }catch(Exception ex )
             {
             }
        }



//        protected void BindBoost()
//        {
//            string strSQL;
//            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

//            // TODO NOW Fix this query.
//            strSQL = @"SELECT e.txtImgPath1, e.iD, e.iHtFt,e.iPageViewCount, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
//            FROM tblServices s
//            INNER JOIN tblEntry e on s.iEntryId = e.iD
//            INNER JOIN tblUser u on u.id = e.iUser
//            WHERE e.iBoosted = 1
//            AND (e.iStatus <> 3
//            OR e.iStatus is NULL)
//            ORDER BY NEWID()";
//            //strSQL = @"select * from ShowBoostHoriz ORDER BY NEWID()";

//            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

//            try
//            {
//                dbManager.Open();
//                dbManager.ExecuteReader(CommandType.Text, strSQL);
//                dlUpgrades.DataSource = dbManager.DataReader;
//                dlUpgrades.DataBind();

//            }
//            catch (Exception ex)
//            {
//                ErrorLog.ErrorRoutine(false, "Boost:BindBoost:Error: " + ex.Message);
//            }
//            finally
//            {
//                dbManager.Close();
//                dbManager.Dispose();
//            }        
//        }

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

        public void btnPrev_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect(Request.CurrentExecutionFilePath + "?Page=" + (CurPage - 1));
            index -= 1;
            Bind();
        }

        public void btnNext_Click(object src, CommandEventArgs e)
        {

            index += 1;
            Bind();
            //Response.Redirect(Request.CurrentExecutionFilePath + "?Page=" + (CurPage + 1));
        }

    
        
    }
}