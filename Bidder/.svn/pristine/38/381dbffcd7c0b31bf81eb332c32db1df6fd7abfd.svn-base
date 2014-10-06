using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

namespace BoardHunt.Blog
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
    public class BlogDetails : System.Web.UI.Page
	{
		
        protected System.Web.UI.WebControls.Label lblLocation;
		protected System.Web.UI.WebControls.Label lblStatus;
        protected System.Web.UI.WebControls.Label lblRatingCount;

		protected System.Web.UI.WebControls.Label lblBrandData;
		protected System.Web.UI.WebControls.Label lblBrand;

		protected System.Web.UI.WebControls.Label lblDateData;
        protected System.Web.UI.WebControls.Label lblDetailsData;

        protected System.Web.UI.WebControls.Label lblAdTitle;
        protected System.Web.UI.WebControls.Label lblVideo;
        protected System.Web.UI.WebControls.Label lblCommentCount;
        protected System.Web.UI.WebControls.Label lblPageViewCount;

		protected System.Web.UI.WebControls.Panel pnlDetails;
        protected System.Web.UI.WebControls.Panel pnlRatings;

        protected System.Web.UI.WebControls.Panel pnlComments;
        protected System.Web.UI.WebControls.Panel pnlLoginMsg;
        protected System.Web.UI.WebControls.Panel pnlCommentBox;

        protected System.Web.UI.WebControls.Panel pnlVideo;
        protected System.Web.UI.WebControls.Panel pnlLogin;

 		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton lnkAbuse;
		protected System.Web.UI.WebControls.ImageButton imgAddFav;
		
        protected System.Web.UI.WebControls.Image Pic1;
        protected System.Web.UI.WebControls.Image Pic2;

        protected System.Web.UI.WebControls.Image Pic1ThmbNail;
        protected System.Web.UI.WebControls.Image Pic2ThmbNail;

		protected System.Web.UI.WebControls.ImageButton imgGoBack;
        protected System.Web.UI.WebControls.ImageButton star1;
        protected System.Web.UI.WebControls.ImageButton star2;
        protected System.Web.UI.WebControls.ImageButton star3;
        protected System.Web.UI.WebControls.ImageButton star4;
        protected System.Web.UI.WebControls.ImageButton star5;

        protected System.Web.UI.WebControls.HyperLink HypLoc;
        protected System.Web.UI.WebControls.HyperLink HypCat;

        protected System.Web.UI.WebControls.HiddenField hdnRatingVal;
        protected System.Web.UI.WebControls.HiddenField hdnRatingCnt;
        protected System.Web.UI.WebControls.HiddenField hdnbId;
        protected System.Web.UI.WebControls.HiddenField hdnPic1URL;
        protected System.Web.UI.WebControls.HiddenField hdnPic2URL;

        protected System.Web.UI.WebControls.LinkButton lnkLoginFirst;
        protected System.Web.UI.WebControls.DataList dlCommentList;
        protected System.Web.UI.WebControls.TextBox txtComment;
        protected System.Web.UI.WebControls.Button btnPostComment;

        protected System.Web.UI.WebControls.TextBox txtPassword;
        protected System.Web.UI.WebControls.TextBox txtUsername;
        protected System.Web.UI.WebControls.Button btnLogin;
        protected System.Web.UI.WebControls.Label lblWallMessage;

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
            //this.btnPostComment.Click += new System.EventHandler(this.btnPostComment_Click);
			this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
            //this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);
            //this.lnkLoginFirst.Click += new System.EventHandler(this.lnkLoginFirst_Click);
            //this.imgAddFav.Click += new System.Web.UI.ImageClickEventHandler(this.imgAddFav_Click);
            //this.btnPostComment.Click += new System.EventHandler(this.btnPostComment_Click);
        }
        #endregion        
        
		private void Page_Load(object sender, System.EventArgs e)
		{

            if (!Page.IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "No")
                {
                    if (Global.CheckLoginCookies(false))
                        Session["LoggedIn"] = "Yes";
                }
            }            
            
            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
            btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing type something into the box.');event.returnValue=false;return false;}else{return true;}");

            //Get model iD
            string[] arString;
            arString = Request.QueryString.GetValues("iD");
            if (arString != null)
            {
                hdnbId.Value = Request.QueryString["iD"].ToString();
                arString[0] = string.Empty;
            }
            else
            {
                pnlDetails.Visible = false;
                lblStatus.Text = "Something went wrong.  Click <a href='BlogResults.aspx'>HERE</a> to read the Blogs.";
                lblStatus.CssClass = "errorLabel";
                return;
            }

            
            if (Session["LoggedIn"].ToString() == "Yes")
            {
                pnlLogin.Visible = false;
                lblWallMessage.Visible = false;
            }

            //Fires on first timers and refresh
            if (!Page.IsPostBack)
			{

                // Put user code to initialize the page here
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();
                
                //Check for cut and paste URL bug: check for NULL;
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferURL"] = Request.UrlReferrer.ToString();
                }

                BindData();
                Session["GoToURL"] = "";
			}

		}
/*
 */ 
		private void BindData()
		{

			string strSQL;
			string myConnectString;
            string strBoardCat;
            string strCat;

            int picCount = 0;
            
			//get connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			//build query, get data and user details for entry
            strSQL = "SELECT tblUser.txtFirstName, tblUser.txtEmail, tblUser.txtPhonenum,tblUser.userDir, tblUser.iShowPhoneNum, tblBlog.* FROM tblUser INNER JOIN tblBlog ON tblUser.Id = tblBlog.iUser WHERE tblBlog.iD = '" + hdnbId.Value + "'";

			SqlConnection myConnection = new SqlConnection(myConnectString); 
			SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
			SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                if (SQLReader.Read() == true)
                {

                    //Date
                    lblDateData.Text = String.Format("{0:MM/dd}", SQLReader["blog_dt"]);

                    //AdTitle
                    lblAdTitle.Text = SQLReader["title"].ToString();

                    //Details
                    lblDetailsData.Text = SQLReader["blog"].ToString();

                    //Category
                    strCat = SQLReader["cat"].ToString();
                    strBoardCat = Global.DecodeCategory(Convert.ToInt32(SQLReader["cat"].ToString()));
                    
                    //TODO: fix hack for hardcoding category
                    strBoardCat = "Blog";
                    //HypCat.Text = Global.up1(strBoardCat);
                    
                    bool blnNullFlg;

                    ////Set the ratings
                    blnNullFlg = setRatings(SQLReader["iRatingCount"].ToString(), SQLReader["iRatingVal"].ToString());
                    lblPageViewCount.Text = incPageViewCount(SQLReader["iPageViewCount"].ToString());

                    string ratCnt = SQLReader["iRatingCount"].ToString();
                    
                    if (ratCnt == string.Empty)
                    {
                        ratCnt ="0";
                    }

                    if (ratCnt == "1")
                    {
                        ratCnt += " Vote";
                    }
                    else
                    {
                        ratCnt += " Votes";
                    }
                    lblRatingCount.Text = ratCnt;

                    ////////////////
                    //process images
                    ////////////////

                    //Add up a pic count so we know whether to hide/show ratings panel

                    //Get user dir
                    string strUserDir = Global.ReplaceEx(SQLReader["userDir"].ToString(), @"\", @"/");

                    //2 pics only for blog
                    Pic1.ImageUrl = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
                    if ((Path.GetFileName(Pic1.ImageUrl)) == "s1x1.gif")
                    {
                        Pic1.Height = 1;
                        Pic1.Width = 1;
                    }
                    else
                    {
                        picCount += 1;
                        Pic1.Height = 300;  //pic size for blog
                        Pic1.Width = 300;

                        //***No thumbnails***

                        hdnPic1URL.Value = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
                    }

                    //Pic2
                    Pic2.ImageUrl = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
                    if ((Path.GetFileName(Pic2.ImageUrl)) == "s1x1.gif")
                    {
                        Pic2.Height = 1;
                        Pic2.Width = 1;
                        Pic2.Visible = false;
                    }
                    else
                    {
                        picCount += 1;

                        Pic2.Height = 300;  //pic size for blog
                        Pic2.Width = 300;
                        

                        //***No thumbnails***
                        hdnPic2URL.Value = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
                    }

                    //Hide rating value in no pics shown (***but this should never happen with blog)
                    if (picCount < 1)
                    {
                        Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/s1x1.gif";
                        pnlComments.Visible = false;

                        Pic1.Width = 1;
                        Pic1.Height = 1;
                        pnlDetails.Width = 800;
                    }
                    //else
                    //{

                        string imgURLVal;
                        string voteVal = "voted_" + hdnbId.Value;

                        imgURLVal = string.Empty;

                        if (Session[voteVal] == null)
                        {
                            imgURLVal = "../images/target_green.gif";
                        }
                        else //disallow voting
                        {
                            if (Session[voteVal].ToString() == "Y")
                            {
                                imgURLVal = "../images/target_orange.gif";
                                star1.Enabled = star2.Enabled = star3.Enabled = star4.Enabled = star5.Enabled = false;
                            }
                        }                        
                        
                        
                        ////////////////////////
                        //Set rating value
                        switch (hdnRatingVal.Value)
                        {
                            case "1":
                                star1.ImageUrl = imgURLVal;
                                break;
                            case "2":
                                star1.ImageUrl = imgURLVal;
                                star2.ImageUrl = imgURLVal;
                                break;
                            case "3":
                                star1.ImageUrl = imgURLVal;
                                star2.ImageUrl = imgURLVal;
                                star3.ImageUrl = imgURLVal;
                                break;
                            case "4":
                                star1.ImageUrl = imgURLVal;
                                star2.ImageUrl = imgURLVal;
                                star3.ImageUrl = imgURLVal;
                                star4.ImageUrl = imgURLVal;
                                break;
                            case "5":
                                star1.ImageUrl = imgURLVal;
                                star2.ImageUrl = imgURLVal;
                                star3.ImageUrl = imgURLVal;
                                star4.ImageUrl = imgURLVal;
                                star5.ImageUrl = imgURLVal;
                                break;
                            default:
                                break;
                        }
                    //}

                    string tmpDetails = lblDetailsData.Text;
                    
                    //Get first occurence
                    int i = tmpDetails.IndexOf("<p>");
                    
                    //Get 2nd occurence
                    i = tmpDetails.IndexOf("<p>", i + 1);

                    //Insert second pic if we have one and if there's a second paragraph tag
                    if ((i > 0) && (picCount > 1))
                    {
                        lblDetailsData.Text = tmpDetails.Insert(i, "<img src='" + Pic2.ImageUrl + "'" + "align='right'" + "height='300' width='300'" + ">");
                        Pic2ThmbNail.Visible = false;
                    }

                }//end if
            }// end try

            catch (Exception ex)
            {
                lblStatus.Text = "Error Loading Data";
                ErrorLog.ErrorRoutine(false, "Error:BlogDetails->BindData(): " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            BindComments();
			
		}		
/*
*/
        public void BindComments()
        {
            //load detailed data for entry item
            string strSQL;
            string myConnectString;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //query item and user details for entry
            strSQL = "SELECT tblUser.txtEmail, tblUser.txtUserName, tblUser.userDir, tblUser.profilePic, tblBlog_dtl.comment_dt as dPosted, tblBlog_dtl.comment as txtComment  FROM tblUser INNER JOIN tblBlog_dtl ON tblUser.Id = tblBlog_dtl.iUser WHERE tblBlog_dtl.blogId = '" + hdnbId.Value + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblBlog_dtl");

                //Get result count for paging
                int listCount = dsItems.Tables["tblBlog_dtl"].Rows.Count;

                if (listCount > 0)
                {
                    dlCommentList.DataBind();
                    lblCommentCount.Text = string.Empty;
                    lblCommentCount.Text += (listCount == 1) ? listCount.ToString() + " Comment" : listCount.ToString() + " Comments";
                }
                else
                {
                    lblCommentCount.Text = "Be the first comment!";
                    lblCommentCount.ForeColor = Color.White;
                }

                pnlCommentBox.Visible = true;
                
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;


                //bind to DataList control
                dlCommentList.DataSource = objPds;
                //dlCommentList.DataSource = dsItems;
                dlCommentList.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BlogDetails:BindComments(): " + ex.Message);
                ErrorLog.ErrorRoutine(false, "BlogDetails:BindComments():InnerEx: " + ex.InnerException);
                classes.Email.SendEmail("BH Error", "info@boardhunt.com", "BlogDetails:BindComments(): " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            if (Session["LoggedIn"].ToString() == "No")
            {
                pnlLoginMsg.Visible = true;
                btnPostComment.Enabled = false;
            }
            else
            {
                btnPostComment.Enabled = true;
            }
        }

/*
 */ 
		public string DecodeBoard(object BoardCode, int cat)
		{
            string val = "";

            switch (cat)
            {
                case (int)1:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_SURF), BoardCode);
                    break;
                case (int)2:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_SNOW), BoardCode);
                    break;
                case (int)3:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_OTHER), BoardCode);
                    break;
            }
            return val;
		}


		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect(ViewState["ReferURL"].ToString());
		}

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
                imgPath = strServerURL + "/users/" + uD + "Blog" + "/" + Path.GetFileName(imgPicPath.ToString());
			}
			
			return imgPath;
		}
/*
 */ 
        private bool setRatings(String cnt, String val)
        {
            bool retVal = false;
            
            if (val == null || val == "")
            {
                //blnNullFlag = true;
                retVal = true;
                hdnRatingVal.Value = "0";
                hdnRatingCnt.Value = "0";
            }
            else
            {
                int iratingVal = Convert.ToInt32(val);
                int iratingCt = Convert.ToInt32(cnt);

                if (iratingCt > (int)0)
                {
                    hdnRatingVal.Value = Convert.ToInt16(Math.Round(Convert.ToDouble(iratingVal / iratingCt))).ToString();
                }
                else
                {
                    hdnRatingVal.Value = "0";
                }
                hdnRatingCnt.Value = cnt.ToString();
            }
            return retVal;
        }
/*
 */
        public string FormatPicPath(object oDir, object oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.ToString().Length > 1)
                return serverURL + "/users/" + oDir.ToString() + oPic.ToString();
            return serverURL + "/images/nopic32.jpg";

        }
/*
 */
        public string ShowUser(object un, object em)
        {
            if ((un.ToString().Length > 1))
                return un.ToString();
            return ParseEmail(em);
        }
/*
 */ 
        //Fired when user clicks to rate.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ProcRating(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Did this to handle NULL values in the db.  Apparently Null arithmatic is frowned upon
            //if (blnNullFlag)
            if (Convert.ToInt32(hdnRatingVal.Value) < (int)1)
            {
                strSQL = "UPDATE tblBlog SET iRatingCount = 1,iRatingVal = " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblBlog SET iRatingCount = iRatingCount + 1,iRatingVal = iRatingVal + " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //disables voting
                string voteVal = "voted_" + hdnbId.Value;
                Session[voteVal] = "Y";

                //rebind data to control
                BindData();
            }
            catch
            {
                ErrorLog.ErrorRoutine(false, "Error in ProcRating");
                lblStatus.Text = "Ratings Error";
            }
            finally
            {
                //close
                myConnection.Close();
            }
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
		private void lnkPost_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../post.aspx");
			
		}

		private void imgAddFav_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

            if (Session["LoggedIn"].ToString() == "No")
            {
                Global.CreateMessageAlert(this.Page, "You must be logged in to do that.", "alertKey");
                return;
            }
            
            //add this entry into the favorites table
			string strSQL;
			string myConnectString;

			//form connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			
			//3. Formulate SQL
			//Get query strings

			strSQL = "INSERT INTO tblFavs (userId, entryId)";
            strSQL += "VALUES ('" + Session["userId"].ToString() + "','" + Request.QueryString["iD"].ToString() + "')";

			SqlConnection myConnection = new SqlConnection(myConnectString);
					
			//todo: need to check for duplicate entries
			try
			{
				myConnection.Open();

				SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				objCommand.ExecuteNonQuery();

				myConnection.Close();

				Global.CreateMessageAlert(this.Page,"Entry has been added to your favorites.", "alertKey");
			}
	
			catch 
			{
				lblStatus.Text = "SQL Error: Connection Bad.<br>";
				lblStatus.Text = "SQL: " + strSQL;
			}		
		}
/*
 */ 
        protected void btnPostComment_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "No")
                return;

            if (txtComment.Text.Length <= 0)
                return;

            //add this entry into the favorites table
            string strSQL;
            string myConnectString;

            //form connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "INSERT INTO tblBlog_dtl (blogId, iUser, comment, comment_dt)";
            strSQL += "VALUES ('" + Convert.ToInt32(hdnbId.Value) + "','" + Convert.ToInt32(Session["userId"].ToString()) + "','" + Global.CheckString(txtComment.Text) + "','" + DateTime.Now + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                myConnection.Close();

                //notify us when a someone posts a comment
                classes.Email.SendEmail("New Blog Comment Posted", "info@boardhunt.com", "BlogURL: " + Request.Url.ToString());

                Response.Redirect(Request.Url.ToString());
            }

            catch(Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BlogDetails:Error posting comment: " + ex.Message);
                lblStatus.Text = "Error posting comment.<br>";
            }		

        }
/*
 */ 
        protected void lnkLoginFirst_Click(object sender, EventArgs e)
        {
            Session["GoToURL"] = Request.Url.ToString();
            Response.Redirect("../login.aspx");
        }
/*
 */
        public string ParseEmail(object em)
        {
            string[] arrStr;
            char[] splitter = { '@' };

            arrStr = em.ToString().Split(splitter);
            return arrStr[0]; 
        }
/*
 * Increment the PageViewCount for the entry.  The value returned will be the display value
 */
        public string incPageViewCount(string cnt)
        {
            string tmpURL = Request.Url.ToString();

            if (Session[tmpURL] != null)
            {
                return cnt;
            }

            string connStr, strSQL;
            int retval;

            retval = 0;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //cnt and iPageViewCount should be equal - do we need to check?
            if (Convert.ToInt32(cnt) < (int)1)
            {
                strSQL = "UPDATE tblBlog SET iPageViewCount = 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblBlog SET iPageViewCount = iPageViewCount + 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                //BindData();

                
                Session.Add(Request.Url.ToString(), Request.Url.ToString());
                retval = Convert.ToInt32(cnt) + 1;
            }
            catch
            {
                ErrorLog.ErrorRoutine(false, "Error in PageViewCount processing");
                lblStatus.Text = "Error!";
            }
            finally
            {
                //close
                myConnection.Close();
            }
            return (retval.ToString());
        }
/*
 */
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            classes.Login clsLogin = new classes.Login();
            if (clsLogin.DoLogin(txtUsername.Text, txtPassword.Text, true, false))
            {
                BindComments();

                dlCommentList.Visible = true;
                pnlCommentBox.Visible = true;

                //Get text for login links
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

            }
            //login failed 
            else
            {
                //TODO: need error msg
                Response.Redirect(Request.Url.ToString(), false);

            }
        }
	}
}
