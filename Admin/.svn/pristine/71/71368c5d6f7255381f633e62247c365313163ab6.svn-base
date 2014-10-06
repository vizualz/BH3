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
using System.IO;
using DALLayer;
using Rss;

namespace BoardHunt.Admin
{

    public partial class Admin1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            Global.AuthenticateUser();

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                ErrorLog.ErrorRoutine(false, "Hack Attempt into Admin Page!");
                Response.Redirect("../UserMenu.aspx");
            }

            if (!Page.IsPostBack)
            {
                classes.Mobile.Sms oSms = new classes.Mobile.Sms();
                lblCouponCnt.Text = "(" + oSms.CheckBalance() + ")";
            }
        }
/*
 */
        protected void lnkBtnSales_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sales.aspx");
        }
        
        /*
         */
        protected void lnkCoupon_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coupons.aspx");

        }
        /*
         */
        protected void lbEntries_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostMaster.aspx");

        }
        /*
         */
        protected void lbUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElJefe.aspx");
        }
        /*
         */
        protected void lbFavorites_Click(object sender, EventArgs e)
        {
            Response.Redirect("FavMaster.aspx");
        }
        /*
         */
        protected void lnkBlog_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogManager.aspx");
        }
        /*
         */
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {

            Global.NavigatePage(lnkSignIn.Text);

        }

        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);

        }

        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../post.aspx");

        }

        protected void lnkReports_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Reports.aspx");

        }

        protected void lnkContactAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactAllUsers.aspx");
        }

        protected void lnkUserMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserMenu.aspx");
        }

        protected void lnkCreateRSS_Click(object sender, EventArgs e)
        {
            CreateRSS();
            CreateBlogRss();
        }

        private void CreateRSS()
        {
            string strSQL = string.Empty;
            strSQL = @"Select TOP 5 e.iD, e.iUser, e.iCategory, e.iHtFt, e.iHtIn, e.txtBrand, e.txtDetails, e.txtOtherBoardType, e.txtGearItem, e.fltPrice, e.dCreateDate, e.txtImgPath1, tblUser.userDir
                       FROM tblEntry e
                       INNER JOIN tblUser ON e.iUser = tblUser.iD
                       WHERE adtype = '1' AND iCategory = '1' 
                       ORDER BY e.dCreateDate DESC";
            
            DataSet dsItems = new DataSet();
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);
          

            RssChannel channel = new RssChannel();
            foreach(DataRow dr in dsItems.Tables[0].Rows)
            {
                RssItem item = new RssItem();

                item.Title = dr["iHtFt"].ToString() + "' " + dr["iHtIn"].ToString() + "\" " + dr["txtBrand"].ToString() + ": " + Global.DecodeCategory(dr["iCategory"]);
                item.Link = new Uri("http://www.malzook.com/surfboard.aspx?iD=" + dr["iD"].ToString());

                string strUrl = string.Empty;
                if (dr["txtImgPath1"] != DBNull.Value && dr["txtImgPath1"].ToString().Length > 1)
                {
                    string strUserDir = Global.ReplaceEx(dr["userDir"].ToString(), @"\", @"/");
                    strUrl = "<img width=\"75\" height=\"75\" src=\"" + GetPicPath("thmbNail_" + dr["txtImgPath1"].ToString(), strUserDir) + "\"/>";
                }
                item.Description = strUrl + Global.FormatDetails(dr["txtDetails"], (int)50);
                item.PubDate = Convert.ToDateTime(dr["dCreateDate"].ToString());
                
                channel.Items.Add(item);
            }

            channel.Generator = "Boardhunt RSS Generator";
            channel.Title = "Boardhunt: Used Surfboards for Sale";
            channel.Description = "Boardhunt: Latest Boards";
            channel.LastBuildDate = channel.Items.LatestPubDate();
            channel.Link = new Uri("http://www.malzook.com/rss/surfboards.xml");
            
            RssImage rssImg = new RssImage();
            rssImg.Link = new Uri("http://www.malzook.com");
            rssImg.Title = "Boardhunt logo";
            rssImg.Height = 100;
            rssImg.Width = 160;
            rssImg.Url = new Uri("http://www.malzook.com/images/BHLogo.gif");
            rssImg.Description = "Boardhunt host a free service allowing the searching and selling of used surfboards";
            channel.Image = rssImg;

            RssFeed feed = new RssFeed();
            feed.Channels.Add(channel);
            feed.Write(Server.MapPath(".\\..\\rss\\") + "surfboards.xml");

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Admin:CreateRSS:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }  

            /*
            Response.ContentType = "text/xml";
            feed.Write(Response.OutputStream);
            Response.End();
             */

        }

        protected void CreateBlogRss()
        {
            string strSQL = string.Empty;
            string owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];
            strSQL = @"SELECT TOP 5 " + owner + @".getBlogCommentCount(e.id) as COUNTER, e.id, e.blog_dt, e.title, e.cat, e.iUser, e.blog, e.txtImgPath1, e.txtImgPath2, e.iPageViewCount, u.userDir 
                        FROM tblBlog e
                        INNER JOIN tblUser u
                        on e.iUser = u.id
                        WHERE e.publish ='Y'
                        ORDER BY e.blog_dt DESC";

            DataSet dsItems = new DataSet();
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Admin:CreateRSS:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            RssChannel channel = new RssChannel();
            foreach (DataRow dr in dsItems.Tables[0].Rows)
            {
                RssItem item = new RssItem();

                item.Title = dr["title"].ToString(); 
                item.Link = new Uri("http://www.malzook.com/BlogDetails.aspx?iD=" + dr["iD"].ToString());
                //TODO: add pics for blogs
                item.Description = Global.FormatDetails(dr["blog"], (int)50);
                item.PubDate = Convert.ToDateTime(dr["blog_dt"].ToString());

                channel.Items.Add(item);
            }

            channel.Generator = "Boardhunt RSS Generator";
            channel.Title = "Boardhunt: Surfing and Surfboard Blog";
            channel.Description = "BH Latest Boards";
            channel.LastBuildDate = channel.Items.LatestPubDate();
            channel.Link = new Uri("http://www.malzook.com/rss/blog.xml");

            RssImage rssImg = new RssImage();
            rssImg.Link = new Uri("http://www.malzook.com");
            rssImg.Title = "Boardhunt logo";
            rssImg.Height = 100;
            rssImg.Width = 160;
            rssImg.Url = new Uri("http://www.malzook.com/images/BHLogo.gif");
            rssImg.Description = "Boardhunt host a free service allowing the searching and selling of used surfboards";
            channel.Image = rssImg;
 
            RssFeed feed = new RssFeed();
            feed.Channels.Add(channel);
            feed.Write(Server.MapPath(".\\..\\rss\\") + "blog.xml");            
        }
/*
 */ 
        public string GetPicPath(object imgPicPath, string uD)
        {
            string imgPath;
            string strServerURL;

            strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            //if the imgPicPath is null or empty then just display a blank white area
            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                imgPath = strServerURL + "/images/s1x1.gif";
            }
            else
            {
                imgPath = strServerURL + "/users/" + uD + "surfboards/" + Path.GetFileName(imgPicPath.ToString());
            }
            return imgPath;
        }
    }
}
