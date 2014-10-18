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
using DALLayer;

namespace BoardHunt
{
	/// <summary>
    /// Summary description for ItemDetails.
	/// </summary>
    public partial class Profile : System.Web.UI.Page
	{
		

        protected System.Web.UI.WebControls.Panel pnlWeb;

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton lnkAbuse;
        protected System.Web.UI.WebControls.LinkButton lnkLoginFirst;

        //protected System.Web.UI.WebControls.HiddenField hdnNotifyEmail;

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
            //this.lnkLoginFirst.Click += new System.EventHandler(this.lnkLoginFirst_Click);
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
			this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
			//this.imgAddFav.Click += new System.Web.UI.ImageClickEventHandler(this.imgAddFav_Click);
            
		}
        #endregion        

		protected void Page_Load(object sender, System.EventArgs e)
		{
  
			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");

            btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing something into the box.');event.returnValue=false;return false;}else{return true;}");

            if (Session["LoggedIn"].ToString() == "Yes")
                pnlLogin.Visible = false;
            
            if (!Page.IsPostBack)
			{
				//Check for cut and paste URL bug: check for NULL;
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferURL"] = Request.UrlReferrer.ToString();
                }
                BindData();
			}

		}
/*
 */ 
		private void BindData()
		{

			//load detailed data for entry item
			string strSQL;
            string strUserId;

            //Get query strings for sql query
            string[] arString;
            arString = Request.QueryString.GetValues("q");
            if (arString == null)
            {
                lblStatus.Text = "Sorry...Couldn't find that person.";
                return;
            }
            strUserId = HttpUtility.UrlDecode(arString[0].ToString());
            hdnUserId.Value = strUserId;
            arString[0] = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			//query item and user details for entry
            strSQL = "SELECT u.txtFullName, u.txtUserName, u.profilePic, u.txtUserDetails, u.txtWebSite, u.txtEmail, u.txtPhonenum, u.userDir, u.iShowPhoneNum, u.notify_comment_flg from tblUser u WHERE iD='" + strUserId + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    lblFullName.Text = dbManager.DataReader["txtFullName"].ToString();
                   
                    //Details
                    lblDetailsData.Text = dbManager.DataReader["txtUserDetails"].ToString();

                    //Contact
                    Session["Email"] = dbManager.DataReader["txtEmail"].ToString();
                    lnkEmailData.Text = ParseEmail(dbManager.DataReader["txtEmail"].ToString());
                    lnkEmailData.CommandArgument = dbManager.DataReader["txtEmail"].ToString();

                    lnkEmailData.Attributes.Add("href", "mailto:" + dbManager.DataReader["txtEmail"].ToString() + "?subject=Contact from Boardhunt");
                    hdnNotifyEmail.Value = dbManager.DataReader["notify_comment_flg"].ToString();

                    lblPhoneData.Text = dbManager.DataReader["txtPhoneNum"].ToString();
                    lblPhoneData.Visible = ShowPhone(dbManager.DataReader["iShowPhoneNum"]);

                    lblDetailsData.Text = dbManager.DataReader["txtUserDetails"].ToString();

                    Pic1.ImageUrl = FormatPicPath(dbManager.DataReader["userDir"].ToString(), dbManager.DataReader["profilePic"].ToString());

                    string ratCnt = dbManager.DataReader["numRating"].ToString();
                }
                else
                {
                    lblStatus.Text = "Sorry...Couldn't find that person.";
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Profile:Page_Load:Msg: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }			
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
            strSQL = "SELECT tblUser.txtEmail, tblComments.* FROM tblUser INNER JOIN tblComments ON tblUser.Id = tblComments.userId WHERE tblComments.entryId = '" + hdnEId.Value + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblComments");

                //Get result count for paging
                int listCount = dsItems.Tables["tblComments"].Rows.Count;
                lblCommentCount.Text = listCount.ToString() + "&nbsp;Comment";
                if (listCount != 1)
                {
                    lblCommentCount.Text += "s";
                }
                
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;

                //bind to DataList control
                dlCommentList.DataSource = objPds;
                //dlCommentList.DataSource = dsItems;
                dlCommentList.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in CommentList: " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            if (Session["LoggedIn"].ToString() == "No")
            {
                pnlLoginMsg.Visible = true;
                
            }
            else
            {
                pnlCommentBox.Visible = true;
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
/*
 */

        public string DecodeCondition(object CondCode)
        {
            return Enum.GetName(typeof(Global.CONDITION_TYPE), CondCode);
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
                imgPath = strServerURL + "/users/" + uD + hdnStrCat.Value + "/" + Path.GetFileName(imgPicPath.ToString());
			}
			return imgPath;
		}
		
		//displays phone number based on user pref in db
		public bool ShowPhone(object iDisplay)
		{

			if (Convert.ToInt32(iDisplay.ToString()) == (int)1)
			{
				return true;
			}
			return false;
		}

        //Fired when user clicks the edit link.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            //Todo:we need board type so perhaps we can add it as a hidden value in the .aspx and access on the code sire
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString());// + "&iCat=" + Request.QueryString["iCat"].ToString());
        }

        //Fired when user clicks to vote the entry.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ProcRating(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Did this to handle NULL values in the db.  Apparently NULL arithmatic is frowned upon
            //if (blnNullFlag)
            if (Convert.ToInt32(hdnRatingVal.Value) < (int)1)
            {
                strSQL = "UPDATE tblEntry SET iRatingCount = 1,iRatingVal = " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblEntry SET iRatingCount = iRatingCount + 1,iRatingVal = iRatingVal + " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                string voteVal = "voted_" + hdnEId.Value;

                Session[voteVal] = "Y";

                //rebind data to control
                BindData();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in ProcRating:" + ex.Message);
                lblStatus.Text = "Ratings Error.";
            }
            finally
            {
                //close
                myConnection.Close();            
            }
        }
/*
 */
        public string FormatPicPath(string oDir, string oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.Length > 1)
                return serverURL + "/users/" + oDir + oPic;
            return serverURL + "/images/nopic64.jpg";

        }
/*
 */ 
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);
        }		
/*
 */ 
        public string DecodeFins(object FinCode)
		{
			return Enum.GetName(typeof(Global.FINS), FinCode);
		}

		public string DecodeTail(object TailCode)
		{
			return Enum.GetName(typeof(Global.TAIL), TailCode);
		}
		
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
			Response.Redirect("post.aspx");
		}

        //private void imgAddFav_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if (Session["LoggedIn"].ToString() == "No")
        //    {
        //        Global.CreateMessageAlert(this.Page, "You must be logged in to do that.", "alertKey");
        //        return;
        //    }
            
        //    //add this entry into the favorites table
        //    string strSQL;
        //    string myConnectString;

        //    //form connect string
        //    myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			
        //    //Build SQL
        //    strSQL = "INSERT INTO tblFavs (userId, entryId)";
        //    strSQL += "VALUES ('" + Session["userId"].ToString() + "','" + Request.QueryString["iD"].ToString() + "')";

        //    SqlConnection myConnection = new SqlConnection(myConnectString);
					
        //    //TODO: need to check for duplicate entries
        //    try
        //    {
        //        myConnection.Open();

        //        SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
        //        objCommand.ExecuteNonQuery();

        //        myConnection.Close();

        //        BindComments();

        //        Global.CreateMessageAlert(this.Page,"Entry has been added to your favorites.", "alertKey");

        //    }
	
        //    catch 
        //    {
        //        lblStatus.Text = "SQL Error: Connection Bad.<br>";
        //        lblStatus.Text = "SQL: " + strSQL;
        //    }		


        //}

        protected void btnPostComment_Click(object sender, EventArgs e)
        {

            //add this entry into the favorites table
            string strSQL;
            string myConnectString;
            
            //check login status
            if (Session["LoggedIn"].ToString() == "No")
            {
                //TODO: display please log in?
                return;
            }

            //check for an empty comment
            if (txtComment.Text.Length <= 0)
            {
                txtComment.BorderColor = Color.Red;
                return;
            }

            //form connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "INSERT INTO tblComments (entryId, userId, txtComment, dPosted)";
            strSQL += "VALUES ('" + Convert.ToInt32(hdnEId.Value) + "','" + Convert.ToInt32(Session["userId"].ToString()) + "','" + Global.CheckString(txtComment.Text) + "','" + DateTime.Now + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //TODO: need to check for duplicate entries - ?
            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                string[] eLinkArr = new string[1];
                eLinkArr[0] = Request.Url.ToString();

                //Send E-mail
                if (hdnNotifyEmail.Value == "Y")
                {
                    classes.Email.SendEmail("A new comment was posted on your board", lnkEmailData.CommandArgument, classes.Email.MSG_POSTED_COMMENT, eLinkArr);
                }

                Response.Redirect(Request.Url.ToString());
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ItemDetails:Error posting comment:" + ex.Message);
                lblStatus.Text = "Error posting comment.<br>";
            }

            finally
            {
                myConnection.Close();            
            }

        }
/*
 */ 
        protected void lnkLoginFirst_Click(object sender, EventArgs e)
        {
            Session["GoToURL"] = Request.Url.ToString();
            Response.Redirect("login.aspx");
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
        //public string incPageViewCount(string cnt)
        //{

        //    string tmpURL = Request.Url.ToString();

        //    if (Session[tmpURL] != null)
        //    {
        //        return cnt;
        //    }

        //    string connStr, strSQL;
        //    int retval;

        //    retval = 0;

        //    //get conn string
        //    connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

        //    //cnt and iPageViewCount should be equal - do we need to check?
        //    if (Convert.ToInt32(cnt) < (int)1)
        //    {
        //        strSQL = "UPDATE tblEntry SET iPageViewCount = 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
        //    }
        //    else
        //    {
        //        strSQL = "UPDATE tblEntry SET iPageViewCount = iPageViewCount + 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
        //    }

        //    SqlConnection myConnection = new SqlConnection(connStr);

        //    try
        //    {
        //        myConnection.Open();

        //        SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
        //        objCommand.ExecuteNonQuery();

        //        Session.Add(Request.Url.ToString(), Request.Url.ToString());
        //        retval = Convert.ToInt32(cnt) + 1;
        //    }
            
        //    catch (Exception ex)
        //    {
        //        ErrorLog.ErrorRoutine(false, "Error in PageViewCount processing: " + ex.Message );
        //        lblStatus.Text = "Error!";
        //    }
        //    finally
        //    {
        //        //close
        //        myConnection.Close();
        //    }
        //    return (retval.ToString());
        //}

/*
 */ 
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //Connect to DB	
            String strSQL;
            String myConnectString;

            //Formulate connect string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //3. Formulate SQL
            strSQL = "SELECT * FROM tblUser WHERE txtEmail='" + txtUsername.Text + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                myConnection.Open();

                SqlDataReader objReader = null;
                objReader = objCommand.ExecuteReader();

                if (objReader.Read() == true)
                {
                    string txtPass = objReader["txtPassword"].ToString();
                    bool bLoginSuccess = false;

                    if (objReader["sashimi"].ToString() == "1")
                    {
                        //get hasher pointer
                        BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();
                        //get salt from db
                        string saltVal = objReader["salt"].ToString();

                        //compute hash from user input
                        byte[] tmpByte;
                        tmpByte = pHash.getHash(saltVal, txtPassword.Text);
                        string pwdToMatch = Convert.ToBase64String(tmpByte);

                        //check for match
                        if (pwdToMatch == txtPass)
                        {
                            bLoginSuccess = true;
                        }

                    }

                    //old algorithm
                    else
                    {
                        if (objReader["txtPassword"].ToString() == txtPassword.Text)
                        {
                            bLoginSuccess = true;
                        }
                    }

                    //check password match
                    if (bLoginSuccess)
                    {

                        // Successful login, save iD for user events while logged in
                        Session["LoggedIn"] = "Yes";
                        Session["userId"] = objReader["iD"].ToString();
                        Session["EmailId"] = objReader["txtEmail"].ToString();
                        Session["acctType"] = objReader["iAcctType"].ToString();
                        pnlLoginMsg.Visible = false;
                        pnlLogin.Visible = false;

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
                        Response.Redirect("login.aspx");
                    }

                }

                else
                {
                    //lblStatus.Text = "Incorrect Username";
                }

                myConnection.Close();


            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Failed Log-in from pnlLogin: " + ex.Message);
            }



        }
/*
 */ 
        protected void btnMore_Click(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Going to:" + "search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value);
            Response.Redirect("search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value, false);
        }
/*
 */
        protected void BindUpgrades()
        {
        
            string strSQL;
            //string strUser;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            //SELECT * from my_table ORDER BY RAND() LIMIT 25

            
            //build SQL
            strSQL = @"SELECT e.txtImgPath1, e.iD, e.iHtFt, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
            FROM tblServices s
            INNER JOIN tblEntry e on s.iEntryId = e.iD
            INNER JOIN tblUser u on u.id = e.iUser"; 

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
                ErrorLog.ErrorRoutine(false, "Error: RegisterDBEntry: " + ex.Message);
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
            string retVal = "images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" +  Global.ReplaceEx(uDir.ToString(),@"\",@"/") + "surfboards/" + "thmbNail_" + imgPath;
                ErrorLog.ErrorRoutine(false, "path: " + retVal);
            }

            return retVal;
        }
/*
 */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ShowItem(object src, CommandEventArgs e)
        {
            //ErrorLog.ErrorRoutine(false, "path: " + "surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());

        } 
	}
}
