using System;
using System.Collections;
using System.Configuration;
using System.Configuration;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DALLayer;

namespace BoardHunt
{
	/// <summary>
	/// Summary description for post_finish.
	/// </summary>
	public partial class UserMenu : System.Web.UI.Page
	{
		
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected const int FREE_BOARD_COUNT = 10;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

            if (!Page.IsPostBack)
            {
                // Put user code to initialize the page here
                Global.AuthenticateUser();

                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                BindData();
                CheckForPro();
                ShowLinks();

                if (hdnACT.Value == Global.ACCT_BIZ)
                {
                    pnlQP.Visible = true;
                    if (!hasCoupons())
                    {
                        //hide footer settings & edit links
                        lnkManageQP.Visible = false;
                        lnkSettings.Visible = false;
                    }
                }
                else
                    pnlQP.Visible = false;

            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
            this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            this.btnBuyShaper.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuyShaper_Click);
            this.lnkAddNewModel.Click += new System.EventHandler(this.lnkAddNewModel_Click);
            this.lnkEditModel.Click += new System.EventHandler(this.lnkEditModel_Click);
            this.lnkFav.Click += new System.EventHandler(this.lnkFav_Click);
            this.lnkEditProfile.Click += new System.EventHandler(this.lnkEditProfile_Click);
            this.lnkSellGear.Click += new System.EventHandler(this.lnkSellGear_Click);
            this.lnkEditGear.Click += new System.EventHandler(this.lnkEditGear_Click);
            this.lnkAskEdit.Click += new System.EventHandler(this.lnkAskEdit_Click);
            this.lnkAskNew.Click += new System.EventHandler(this.lnkAskNew_Click);
            this.lnkShowcaseNew.Click += new System.EventHandler(this.lnkShowcaseNew_Click);
            this.lnkBlogNew.Click += new System.EventHandler(this.lnkBlogNew_Click);
            this.lnkBlogEdit.Click += new System.EventHandler(this.lnkBlogEdit_Click);
            this.imgBtnAcct.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnAcct_Click);
            this.lnkBuyQP.Click += new System.EventHandler(this.lnkBuyQP_Click);
            this.lnkManageQP.Click += new System.EventHandler(this.lnkManageQP_Click);
            this.lnkSettings.Click += new System.EventHandler(this.lnkSettings_Click);
            

            //TODO:
            //this.imgBidder.Click += new System.Web.UI.ImageClickEventHandler(this.imgBidder_Click);

		}
		#endregion

        protected void ShowLinks()
        {
            if (Session["isPro"].ToString() != "1")
            {

                string strSQL = string.Empty;
                IDBManager dbManager = new DBManager(DataProvider.SqlServer);

                strSQL =  "select count(iD) as numpost from tblentry where iStatus = 1 and iCategory = 1 and iuser = '" + Session["userId"].ToString() + "'";

                dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

                try
                {
                    dbManager.Open();
                    dbManager.ExecuteReader(CommandType.Text, strSQL);

                    if (dbManager.DataReader.Read())
                    {
                        if (Convert.ToInt32(dbManager.DataReader["numpost"].ToString()) >= (int)FREE_BOARD_COUNT)
                        {
                            ErrorLog.ErrorRoutine(false, "NumPost: " + dbManager.DataReader["numpost"].ToString());
                            lnkSellGear.Text = "&nbsp;Upgrade";
                            lnkSellGear.CssClass = "ltgreen_green18";
                            //lnkSellGear.CssClass = Global.
                        }
 
                    }
                    else
                        ErrorLog.ErrorRoutine(false, "No boards found.  On with post");
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorRoutine(false, "UM: Error Getting Post within last 30: " + ex.Message);
                    classes.Email.SendErrorEmail("UM: Error Getting Post within last 30: " + ex.Message);
                }
                finally
                {
                    dbManager.Close();
                    dbManager.Dispose();
                }

                //if read() then yes and remove links.  If no read then all good.
            }
        }

        protected void CheckForPro()
        {
                //check for pro and.. 
                BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
                string i = oWS.isPro(Convert.ToInt32(Session["userId"].ToString())).ToString();

                //set style accordingly
                if (i == "1")
                    btnUpgradePro.Visible = false;
                else
                    btnUpgradePro.Visible = true;
        }

        protected bool hasCoupons()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            strSQL = @"SELECT iD FROM tblCoupon WHERE iUser = '" + Session["userId"].ToString() + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "UserMenu:hasCoupons:Error:" + ex.Message);
                classes.Email.SendErrorEmail("UserMenu:hasCoupons:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }        
        }

        protected void BindData()
        {
            //TODO: need to break up into 2 parts: part1) get userdir / part 2 isPro?

            string userDir = "";
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"SELECT coalesce(s.iStatus, 0) as Pro, u.iD, u.profilePic, u.txtUserName, u.userDir, u.iAcctType, u.iStatus, u.iMerchantType, (SELECT iServiceVal FROM tblServices WHERE iServiceVal = 3 AND iUserId = " + Session["userId"].ToString() + ") as iService,";
            strSQL += @" (SELECT COUNT(*)FROM tblEntry WHERE iCategory = 1 AND iUser= '" + Session["userId"].ToString() + "' AND iStatus=1 ) as boardCnt";
            //strSQL += @" (SELECT iStatus FROM tblServices WHERE iServiceVal = 6 AND iUserId = '" + Session["userId"].ToString() + "') as Pro ";
            strSQL += @" FROM tblUser u";
            strSQL += @" LEFT JOIN tblServices s ON s.iUserId ='" + Session["userId"].ToString() + "'";
            strSQL += @" WHERE u.id = '" + Session["userId"].ToString() + "'"; 

         
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    userDir = Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/");
                    imgBtnAcct.ImageUrl = FormatPicPath(dbManager.DataReader["userDir"].ToString(), dbManager.DataReader["profilePic"].ToString());
                    hypAcctEdit.Text = dbManager.DataReader["txtUserName"].ToString();
                    hypAcctEdit.NavigateUrl = "edit_profile.aspx";
                    if (dbManager.DataReader["Pro"].ToString() == "1")
                        btnUpgradePro.Visible = false;
          

                    lblBoardCount.Visible = false;
                    if (System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() == "http://www.malzook.com") //?
                    {
                        if (dbManager.DataReader["boardCnt"] != null)
                        {
                            lblBoardCount.Text = "Surfboards(" + dbManager.DataReader["boardCnt"].ToString() + ")";
                            lblBoardCount.Visible = true;
                        }
                    }

                    Session["userDir"] = userDir;
                    hdnACT.Value = dbManager.DataReader["iAcctType"].ToString();
                    hdnMT.Value = dbManager.DataReader["iMerchantType"].ToString();
                    if (dbManager.DataReader["iService"] != null)
                    {
                        if (dbManager.DataReader["iService"].ToString() == "3")
                        hdnShaperAcctValid.Value = "Y";
                    }

                    //ErrorLog.ErrorRoutine(false, "hdnShaperAcctValid.Value: " + hdnShaperAcctValid.Value);
                }
                else
                {
                    //big problems: this could happen for dual entries into table services
                    ErrorLog.ErrorRoutine(false, "Error: UserMenu:couldn't read userDir or invalid query.");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "UserMenu:Error:BindData: " + ex.Message);
                classes.Email.SendErrorEmail("UserMenu:Error:BindData: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            //Show/hide panels
            switch (hdnACT.Value)
            {
                //TODO: Move to bottom or hide?  Could be confusing with reg user.
                case Global.ACCT_USR:               //allow user to see shaper's panel and upgrade if they'd like
                    pnlShowcase.Visible = false;
                    pnlShaper.Visible = false;
                    pnlShaperCtls.Visible = false;
                    pnlShaperBuy.Visible = false;
                    break;
                case Global.ACCT_BIZ:
                    pnlShowcase.Visible = false;
                    if (hdnMT.Value == Global.MERCHANT_SHAPER)
                        pnlShaper.Visible = true;
                    //Shaper has valid  site?
                    if (hdnShaperAcctValid.Value == "Y")
                    {
                        pnlShaperCtls.Visible = true;
                        pnlShaperBuy.Visible = false;
                    }
                    else
                    {
                        pnlShaperCtls.Visible = false;
                        pnlShaperBuy.Visible = true;
                    }
                    pnlQP.Visible = true;
                    break;
                case Global.ACCT_ADMIN:
                    pnlShowcase.Visible = true;
                    break;
                default:
                    break;
            }


            if (Session["BlogFlg"] != null)
            {
                if (Session["BlogFlg"].ToString() == "Y")
                {
                    pnlBlog.Visible = true;
                }
            }

            //Hide Subscriptions always: feature not implemented
            pnlSUB.Visible = false;
            //Hide Bidder always: feature not implemented
            pnlBidder.Visible = false;

            //**MALZOOK only** TODO: REMOVE this line below
            if (System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() == "http://www.malzook.com")
            {
                //check for shapers and show bidder links
                if (hdnACT.Value == "2" && hdnMT.Value == "1")
                {
                    pnlShaper.Visible = true;
                }
            }
 
        }
/*
 */
        private void imgBtnAcct_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("edit_profile.aspx", true);
        }
/*
 */
        private void btnBuyShaper_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Session["ServiceId"] = "3";
            Response.Redirect("Pay/OrderForm.aspx", false);
        }
/*
 */ 
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignIn.Text);
        }
/*
 */ 
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);

        }
/*
 */
        private void lnkAddNewModel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post_item.aspx?q=4",false);
        }
/*
 */
        private void lnkEditModel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post_manager.aspx?q=4", true);
        }
/*
 */ 
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            //if (lnkPost.Text == "Upgrade")
            //{
            //    Session["ServiceId"] = "7";
            //    Response.Redirect("Pay/OrderForm.aspx", true);
            //}

            //Response.Redirect("post.aspx", true);

        }
/*
 */
        private void lnkSellGear_Click(object sender, System.EventArgs e)
		{
            if (lnkSellGear.Text.IndexOf("Upgrade") > 0)
            {
                Session["ServiceId"] = "6";
                Response.Redirect("Pay/OrderForm.aspx", true);
            }

            Response.Redirect("post.aspx", true);
		}
/*
 */
        private void lnkEditGear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("post_manager.aspx",false);
		}
/*
 */
        private void lnkEditProfile_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("edit_profile.aspx", false);
		}
/*
 */
        private void lnkFav_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("favorites.aspx", false);
		}
/*
 */
        private void lnkShowcaseNew_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/showcase/showcase.aspx", false);
        }
/*
*/
        private void lnkAskNew_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/Qna/PostQ.aspx", false);
        }
/*
*/
        private void lnkBuyQP_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/qp/Post.aspx", false);
        }
/*
*/
        private void lnkManageQP_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/qp/Manager.aspx", false);
        }

/*
*/
        private void lnkSettings_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/qp/Settings.aspx", false);
        }
        
/*
*/
        private void lnkAskEdit_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/Qna/QManager.aspx", false);
        }
/*
*/
        private void lnkBlogEdit_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/Admin/BlogManager.aspx", false);
        }
/*
*/
        private void imgBidder_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("/Bidder/PostBid.aspx", false);
        }
/*
 */
        public string FormatPicPath(string oDir, string oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.Length > 1)
                return serverURL + "/users/" + oDir + "thmb_" + oPic;
            return serverURL + "/images/nopic64.jpg";

        }
/*
 */
        public void GetMoreInfo(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect("Shaper/ShaperHouseMore.aspx",true);

        }

        protected void btnUpgradePro_Click(object sender, EventArgs e)
        {
            Session["ServiceId"] = "6";
            Response.Redirect("Pay/OrderForm.aspx", false);
        }

        protected void lnkBlogNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Blog/Blog.aspx", false);
        }

	}
};
