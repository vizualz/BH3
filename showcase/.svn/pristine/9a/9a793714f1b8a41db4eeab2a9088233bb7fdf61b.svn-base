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

namespace BoardHunt.showcase
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	public partial class ShowcaseDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblPhoneData;
        protected System.Web.UI.WebControls.LinkButton lnkEmailData;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton lnkAbuse;
		
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
			this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
			this.imgAddFav.Click += new System.Web.UI.ImageClickEventHandler(this.imgAddFav_Click);

		}
        #endregion        
        
		protected void Page_Load(object sender, System.EventArgs e)
		{

            // Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			imgAddFav.Visible = true;
            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
            btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing type something into the box.');event.returnValue=false;return false;}else{return true;}");
			
			if (!Page.IsPostBack)
			{
				//Check for cut and paste URL bug: check for NULL;
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferURL"] = Request.UrlReferrer.ToString();
                }
                BindData();
                Session["GoToURL"] = "";
			}

		}

		private void BindData()
		{

			//load detailed data for entry item
			string strSQL;
			string myConnectString;
            bool blnNullFlg;
            string strCat;

            string itemType = "";
            int picCount = 0;
            
			//get connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			//Get query strings for sql query
			hdnEId.Value = Request.QueryString["iD"].ToString();

			//query item and user details for entry
            strSQL = "SELECT tblUser.txtFirstName, tblUser.txtEmail, tblUser.txtPhonenum,tblUser.userDir, tblUser.iShowPhoneNum, tblEntry.* FROM tblUser INNER JOIN tblEntry ON tblUser.Id = tblEntry.iUser WHERE tblEntry.iD = '" + hdnEId.Value + "'";
		
			SqlConnection myConnection = new SqlConnection(myConnectString); 
			SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
			SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                while (SQLReader.Read() == true)
                {

                    //Date
                    lblDateData.Text = String.Format("{0:MM/dd}", SQLReader["dCreateDate"]);

                    //AdTitle
                    lblAdTitle.Text = SQLReader["AdTitle"].ToString();

                    //Brand
                    lblBrand.Text = "Brand:&nbsp";
                    lblBrandData.Text = SQLReader["txtBrand"].ToString();

                    //Price
                    lblPriceData.Text = Global.FormatPrice(SQLReader["fltPrice"]);

                    //Details
                    lblDetailsData.Text = SQLReader["txtDetails"].ToString();
                    
                    lnkWeb.Text = SQLReader["txtWeb"].ToString().Trim();
                    lnkWeb.Attributes.Add("OnClick", "window.open('http://" + lnkWeb.Text + "')");

                    //Category
                    strCat = SQLReader["iCategory"].ToString();
                    hdnStrCat.Value = Global.DecodeCategory(Convert.ToInt32(SQLReader["iCategory"].ToString()));

                    //Ad type - Showcase only: 3 (no need to check really)
                    itemType = SQLReader["adType"].ToString();
                    lblPageViewCount.Text = incPageViewCount(SQLReader["iPageViewCount"].ToString());

                    //Set the ratings
                    string ratCnt = SQLReader["iRatingCount"].ToString();

                    blnNullFlg = setRatings(ratCnt, SQLReader["iRatingVal"].ToString());

                    if (ratCnt == string.Empty)
                    {
                        ratCnt = "0";
                    }

                    if (ratCnt == "1")
                    {
                        ratCnt += " Rating";
                    }
                    else
                    {
                        ratCnt += " Ratings";
                    }
                    lblRatingCount.Text = ratCnt;
                    lblBrandData.Text = SQLReader["txtBrand"].ToString();

                    pnlGenDims.Visible = true;
                    lblGenDims.Text = SQLReader["txtGenDimensions"].ToString();

                    pnlGearItem.Visible = true;
                    lblGearItem.Text = SQLReader["txtGearItem"].ToString();

                    if (!(SQLReader["EntryVideoEmbed"] == null))
                    {
                        if (SQLReader["EntryVideoEmbed"].ToString().Length > 0)
                        {
                            lblVideo.Text = SQLReader["EntryVideoEmbed"].ToString();
                            pnlVideo.Visible = true;
                        }
                    }

                    ///***********PROCESS IMGS

                    //Get user dir
                    string strUserDir = Global.ReplaceEx(SQLReader["userDir"].ToString(), @"\", @"/");

                    Pic1.ImageUrl = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
                    if ((Path.GetFileName(Pic1.ImageUrl)) == "s1x1.gif")
                    {
                        Pic1.Height = 1;
                        Pic1.Width = 1;
                    }
                    else
                    {
                        picCount += 1;
                        Pic1.Height = 400;
                        Pic1.Width = 400;

                        Pic1ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath1"].ToString(), strUserDir);
                        Pic1ThmbNail.Width = 75;
                        Pic1ThmbNail.Height = 75;
                        Pic1ThmbNail.Visible = true;
                        hdnPic1URL.Value = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
                    }

                    Pic2.ImageUrl = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
                    if ((Path.GetFileName(Pic2.ImageUrl)) == "s1x1.gif")
                    {
                        Pic2.Height = 1;
                        Pic2.Width = 1;
                    }
                    else
                    {
                        picCount += 1;
                        //Pic2.Height = 400;
                        //Pic2.Width = 400;

                        Pic2ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath2"].ToString(), strUserDir);
                        Pic2ThmbNail.Width = 75;
                        Pic2ThmbNail.Height = 75;
                        Pic2ThmbNail.Visible = true;
                        hdnPic2URL.Value = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
                    }

                    Pic3.ImageUrl = GetPicPath(SQLReader["txtImgPath3"], strUserDir);
                    if ((Path.GetFileName(Pic3.ImageUrl)) == "s1x1.gif")
                    {
                        Pic3.Height = 1;
                        Pic3.Width = 1;
                    }
                    else
                    {
                        picCount += 1;
                        //Pic3.Height = 400;
                        //Pic3.Width = 400;

                        Pic3ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath3"].ToString(), strUserDir);
                        Pic3ThmbNail.Width = 75;
                        Pic3ThmbNail.Height = 75;
                        Pic3ThmbNail.Visible = true;
                        hdnPic3URL.Value = GetPicPath(SQLReader["txtImgPath3"], strUserDir);
                    }

                    Pic4.ImageUrl = GetPicPath(SQLReader["txtImgPath4"], strUserDir);
                    if ((Path.GetFileName(Pic4.ImageUrl)) == "s1x1.gif")
                    {
                        Pic4.Height = 1;
                        Pic4.Width = 1;
                    }
                    else
                    {
                        picCount += 1;
                        //Pic4.Height = 400;
                        //Pic4.Width = 400;

                        Pic4ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath4"].ToString(), strUserDir);
                        Pic4ThmbNail.Width = 75;
                        Pic4ThmbNail.Height = 75;
                        Pic4ThmbNail.Visible = true;
                        hdnPic4URL.Value = GetPicPath(SQLReader["txtImgPath4"], strUserDir);
                    }

                    //Hide rating value in no pics shown (but this should never happen with showcase)
                    if (picCount < 1)
                    {
                        Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/noimage.gif";
                        pnlComments.Visible = false;

                        Pic1.Width = 162;
                        Pic1.Height = 209;
                        pnlDetails.Width = 800;
                    }
                    else
                    {
                        string strImgPath = "../images/target_orange.gif";
                        
                        //Set rating value
                        switch (hdnRatingVal.Value)
                        {
                            case "1":
                                star1.ImageUrl = strImgPath;
                                break;
                            case "2":
                                star1.ImageUrl = star2.ImageUrl = strImgPath;
                                break;
                            case "3":
                                star1.ImageUrl = star2.ImageUrl = star3.ImageUrl = strImgPath;
                                break;
                            case "4":
                                star1.ImageUrl = star2.ImageUrl = star3.ImageUrl = star4.ImageUrl = strImgPath;
                                break;
                            case "5":
                                star1.ImageUrl = star2.ImageUrl = star3.ImageUrl = star4.ImageUrl = star5.ImageUrl = strImgPath;
                                break;
                            default:
                                break;
                        }
                    }

                }//end while

            }// end try

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:ShowcaseDetails:BindData(): " + ex.Message);
                lblStatus.Text = "Error Loading Data!";
                return;
            }

            finally
            {
                myConnection.Close();
            }

            BindComments();
			
		}

        /*
           * Increment the PageViewCount for the entry.  The value returned will be the display value
           */
        public string incPageViewCount(string cnt)
        {

            string tmpURL = Request.Url.ToString();

            //page refresh: don't add to view count
            if (Session[tmpURL] != null)
            {
                if (Session[tmpURL].ToString() == Request.Url.ToString())
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
                strSQL = "UPDATE tblEntry SET iPageViewCount = 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblEntry SET iPageViewCount = iPageViewCount + 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

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
        public void BindComments()
        {
            //load detailed data for entry item
            string strSQL;
            string myConnectString;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //query item and user details for entry
            strSQL = "SELECT tblUser.txtEmail, tblUser.txtUserName, tblUser.userDir, tblUser.profilePic, tblComments.* FROM tblUser INNER JOIN tblComments ON tblUser.Id = tblComments.userId WHERE tblComments.entryId = '" + hdnEId.Value + "'";

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
                
                //PagedDataSource objPds = new PagedDataSource();
                //objPds.DataSource = dsItems.Tables[0].DefaultView;

                //bind to DataList control
                //dlCommentList.DataSource = objPds;
                dlCommentList.DataSource = dsItems.Tables[0].DefaultView;
                dlCommentList.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error->Showcase-details:BindComments() : " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error->Showcase-details:BindComments() : " + ex.InnerException);
            }

            finally
            {
                myConnection.Close();
            }

            pnlCommentBox.Visible = true;

            if (Session["LoggedIn"].ToString() == "No")
            {
                pnlLoginMsg.Visible = true;
                pnlCommentBox.Enabled = false;
                btnPostComment.Enabled = false;
            }
            else
            {
                pnlLoginMsg.Visible = false;
                pnlCommentBox.Enabled = true;
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
                    hdnRatingCnt.Value = iratingCt.ToString();
                }
                else
                {
                    hdnRatingVal.Value = "0";
                    hdnRatingCnt.Value = "0";
                }
            }
            return retVal;
        }

        //Fired when user clicks the edit link.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        //public void GetValues(object src, CommandEventArgs e)
        //{
        //    //Go to edit item page			
        //    //Todo:we need board type so perhaps we can add it as a hidden value in the .aspx and access on the code sire
        //    Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString());// + "&iCat=" + Request.QueryString["iCat"].ToString());

        //}

        //Fired when user clicks to rate.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ProcRating(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            
            //Did this to handle NULL values in the db.  Apparently Null arithmatic is frowned upon
            //if (blnNullFlag)
            if (Convert.ToInt32(hdnRatingCnt.Value) < (int)1)
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

                //close
                myConnection.Close();

                //rebind data to control
                BindData();
            }

            catch
            {
                lblStatus.Text = "Ratings Error";
            }


        }

        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);

        }		
        
        public string DecodeFins(object FinCode)
		{
			//return Global.ReverseLookUp(FinCode);
			return Enum.GetName(typeof(Global.FINS), FinCode);

		}

		public string DecodeTail(object TailCode)
		{
			//return Global.ReverseLookUp(FinCode);
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
			
            //build sql
			strSQL = "INSERT INTO tblFavs (userId, entryId)";
            strSQL += "VALUES ('" + Session["userId"].ToString() + "','" + Request.QueryString["iD"].ToString() + "')";

			SqlConnection myConnection = new SqlConnection(myConnectString);
					
			//todo: need to check for duplicate entries
            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                BindComments();

                Global.CreateMessageAlert(this.Page, "Entry has been added to your favorites.", "alertKey");
            }

            catch
            {
                lblStatus.Text = "SQL Error: Connection Bad.<br>";
                lblStatus.Text = "SQL: " + strSQL;
            }

            finally
            {
                myConnection.Close();
            }
		}
/*
 */ 
        protected void btnPostComment_Click(object sender, EventArgs e)
        {

            if (Session["LoggedIn"].ToString() == "No")
                return;
            else
                pnlLogin.Visible = false;


            if (txtComment.Text.Length <= 0)
                return;

            //add this entry into the favorites table
            string strSQL;
            string myConnectString;

            //form connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            
            //Build SQL
            strSQL = "INSERT INTO tblComments (entryId, userId, txtComment, dPosted)";
            strSQL += "VALUES ('" + Convert.ToInt32(hdnEId.Value) + "','" + Convert.ToInt32(Session["userId"].ToString()) + "','" + Global.CheckString(txtComment.Text) + "','" + DateTime.Now + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //TODO: need to check for duplicate entries?
            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                classes.Email.SendEmail(Session["userName"].ToString() + " posted a showcase comment","info@boardhunt.com" ,Global.CheckString(txtComment.Text));

                BindComments();
                txtComment.Text = string.Empty;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ShowcaseD:Error posting comment: " + ex.Message);
                lblStatus.Text = "Error posting comment.<br>";
            }
            finally
            {
                myConnection.Close();
            }

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
        public string ParseEmail(object em)
        {
            string[] arrStr;
            char[] splitter = { '@' };

            arrStr = em.ToString().Split(splitter);
            return arrStr[0]; 
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
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            classes.Login clsLogin = new classes.Login();
            if (clsLogin.DoLogin(txtUsername.Text, txtPassword.Text, true, false))
            {
                
                pnlLoginMsg.Visible = false;
                pnlLogin.Visible = false;

                dlCommentList.Visible = true;
                pnlCommentBox.Visible = true;

                //Get text for login links
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

            }
            //login failed 
            else
            {
                Response.Redirect(Request.Url.ToString(),false);
            }
            BindComments();

        }


	}
}
