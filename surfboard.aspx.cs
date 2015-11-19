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
using System.Web.Services;
using System.Security.Cryptography;
using System.Text; 

namespace BoardHunt
{
    /// <summary>
    /// Summary description for ItemDetails.
    /// </summary>
    public partial class surfboard : System.Web.UI.Page
    {


        //protected System.Web.UI.WebControls.LinkButton lnkAbuse;
        //protected System.Web.UI.WebControls.LinkButton lnkLoginFirst;
        protected System.Web.UI.WebControls.DataList dlCommentList;

        protected System.Web.UI.WebControls.Panel pnlCommentBox;
        protected System.Web.UI.WebControls.Panel pnlComments;
        protected System.Web.UI.WebControls.Button btnPostComment;
        protected System.Web.UI.WebControls.TextBox txtComment;

        protected System.Web.UI.WebControls.Label lblCommentCount;
        protected System.Web.UI.WebControls.Label lblWallMessage;
        protected System.Web.UI.WebControls.Panel pnlLogin;
        protected System.Web.UI.WebControls.Panel pnlLoginMsg;
        protected System.Web.UI.WebControls.TextBox txtUsername;
        protected System.Web.UI.WebControls.TextBox txtPassword;
        protected System.Web.UI.WebControls.CheckBox chkNotify;

		protected const string ERR_MSG = @"Whoops!  Something happened.  The Geeks will 
                                    have this fixed shortly.";
        protected const string ERR_MSG2 = @"Shite!  Something happened.  Boardhunt is on it.  Check back shortly. Meanwhile check out some 
                                        other boards -> <a href='/surfboardsforsale.aspx' class=''>here</a>";
		protected const string MSG_NUDGED = @"The seller was Nudged.";
		protected const string LOGIN_FIRST = @"Pro Account Feature|Nudge automatically sends the seller an email asking, ""Is the board still for sale?""  Check your e-mail for a reply.";
		protected const string LOGIN_FIRST_NAG = @"You must log in to use the time-saving Nudge feature. ";
        protected const string NUDGE_GO = "Nudge | Click to automatically email the seller asking them if this board is still available.";
		protected const string NUDGE_UPGRADE = @"Time to Upgrade | You're out of Nudges. Upgrade your account now.";
		protected const int NUDGE_MAX = 5;

        static string b_id;
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
            this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {

			ErrorLog.ErrorRoutine(false, "YAP: PL");

            //Hide all sub-panels then enable accordingly
            //pnlDetails.Visible = false;
            //pnlAll.Visible = true;
            //pnlWidth.Visible = false;
            //pnlSurfOnly.Visible = false;
            //imgAddFav.Visible = true;
            // Retriving www.malzook.com from web configration
            //serverurl = ConfigurationManager.AppSettings["ServerURL"].ToString();
            hdnMsg.Value = string.Empty;

			ErrorLog.ErrorRoutine(false, "YAP");

            //CATEGORY:intCatType - uses hdnVal because category has no filter element
            string[] arString;
            arString = Request.QueryString.GetValues("iD");
            if (arString != null)
            {
                hdnEId.Value = Request.QueryString["iD"].ToString();
                b_id = hdnEId.Value;
                arString[0] = string.Empty;

                if (!Global.IsNumeric(hdnEId.Value))
                {
                    ShowErrorMessage(ERR_MSG2);
                    ErrorLog.ErrorRoutine(false, "Error->ItemDetails:BindData: PageLoad ");
                    return;
                }
            }
            else
            {
				lblStatus.Text = "Something went wrong.  Click <a href='surfboardsforsale.aspx?iCat=1'>HERE</a> to view Surfboards again.";
                lblStatus.ForeColor = Color.White;
                return;
            }


			ErrorLog.ErrorRoutine(false, "WHERE AM I?");

            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");

            lblCommentCount.BackColor = Color.Orange;
            //lblWallMessage.Text = "<a id=\"toggle2\" class=\"ltgreen_orange12\" href=\"#\"><u>Login</u></a>&nbsp;to write on the Wall.";

            
			//Nudge Button prelim setup
            btnNudge.Enabled = true;
            btnNudge.Visible = true;
            btnNudge.CssClass = "Tips btnGo";
			string strNudgeMsg = string.Empty;


            if (Session["LoggedIn"].ToString() == "Yes")
            {
				//check for Pro and stuff the value and repurpose for later 
                BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
				int iUserID = Convert.ToInt32(Session["userId"]);
				hdnAcctStatus.Value = oWS.isPro(iUserID).ToString();

				if (hdnAcctStatus.Value == "1") {
					strNudgeMsg = NUDGE_GO;
				} 
				else {
					//check for nudge limit
					if (oWS.GetNudgeCountForMonth(iUserID) >= NUDGE_MAX) {
						//UPGRADE NOW: stop nudge and show time to upgrade nag msg
						hdnNudgeCnt.Value = "1";
						strNudgeMsg = NUDGE_UPGRADE;

						btnNudge.Attributes.Add ("onmouseover", "SetElement('btnNudge','Upgrade')");
						btnNudge.Attributes.Add ("onmouseout", "SetElement('btnNudge','Nudge')");
						//btnNudge.Attributes.Add("OnClick", "$.jGrowl.defaults.position = 'center-middle';$.jGrowl('" + NUDGE_UPGRADE + "',{sticky: true});return false;");
						//add 'UPGRADE' on hover
					}
					else
					{
						//all clear keep nudging
						strNudgeMsg = NUDGE_GO;
					}
				}

				//btnNudge.CssClass = "Tips btnGo";
				//strNudgeMsg = NUDGE_GO;

                lblWallMessage.Text = "Got a comment or question?";
                pnlLogin.Visible = false;
                btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing something into the box.');event.returnValue=false;return false;}else{return true;}");
            }
			else //user not logged in
            {
				//TODO: add a login control if not logged in or create an easy way for user to login
			    strNudgeMsg = LOGIN_FIRST;
				btnNudge.Attributes.Add("OnClick", "$.jGrowl.defaults.position = 'center-middle';$.jGrowl('" + LOGIN_FIRST_NAG + "',{sticky: true});return false;");
            }

			//attach routed message
            btnNudge.Attributes.Add("title", strNudgeMsg);

            if (!Page.IsPostBack)
            {
                //Check for cut and paste URL bug: check for NULL;
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferURL"] = Request.UrlReferrer.ToString();
                }
                BindData();
                //BindUpgrades();
                Session["GoToURL"] = "";
            }

            HeaderInit();

        }

		protected int checkedMonthlyNudgeCount()
		{
			return 5;

			//get current month
			int mo = DateTime.Now.Month;

			//sp_GetNudgeCountForMonth
			//select count(iUser) from tblNudge where iUser = 5578 and Month(dAdded) = Month(CURRENT_TIMESTAMP)  
			//and Year(dAdded)= Year(CURRENT_TIMESTAMP)

			//log nudge
			IDBManager dbManager = new DBManager(DataProvider.SqlServer);
			dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

			try
			{
				dbManager.Open();

				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@UserId", Convert.ToInt32(Session["userId"].ToString()));

				dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_GetNudgeCountForMonth");

				return 1;
			}
			catch (Exception ex)
			{
				ErrorLog.ErrorRoutine(false, "ID:Nudge:Error:" + ex.Message);
				classes.Email.SendErrorEmail("ID:Nudge:Bug returning mNudgeCount " + ex.Message);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}

		}

        /*
         */
        private void BindData()
        {
			ErrorLog.ErrorRoutine(false, "SurfBoards: Binding Data");

            string strSQL;
            string myConnectString;
            string strCat;

            string itemType = "";
            int picCount = 0;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //query item and user details for entry
            strSQL = @"SELECT t.iThumbsup, t.iThumbsdown, tblUser.txtFirstName, tblUser.txtEmail, tblUser.txtPhonenum, tblUser.userDir, tblUser.iShowPhoneNum, tblUser.notify_comment_flg, tblEntry.*
                ,(SELECT top 1 id from tblEntry where id > " + hdnEId.Value + " AND iCategory=1 and iStatus=1 ORDER BY id ASC) AS nextID, (SELECT top 1 id from tblEntry where id < " + hdnEId.Value + " AND iCategory=1 and iStatus=1 ORDER BY id DESC) AS prevID, (SELECT count(*) from tblNudge WHERE iItem = " + hdnEId.Value + ") AS numNudges ";
            strSQL += " FROM tblUser INNER JOIN tblEntry ON tblUser.Id = tblEntry.iUser ";
            strSQL += " LEFT JOIN tblVote t ON t.iEntry = tblEntry.iD ";
            strSQL += " WHERE tblEntry.iD = '" + hdnEId.Value + "'";



            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                if (SQLReader.Read())
                {

                    //Date
                    lblDateData.Text = String.Format("{0:MM/dd}", SQLReader["dCreateDate"]);

                    //Location
                    HypLoc.Text = "Home";

                    if (SQLReader["nextID"] != DBNull.Value)
                        btnPageNext.CommandArgument = SQLReader["nextID"].ToString();
                    else
                        btnPageNext.Enabled = false;

                    if (SQLReader["prevID"] != DBNull.Value)
                        btnPagePrev.CommandArgument = SQLReader["prevID"].ToString();
                    else
                        btnPagePrev.Enabled = false;

                    //lblLocation.Text = Global.ProperSpace(DecodeRegion(SQLReader["Location"]));
                    lblLocation.Text = Global.SwapChar(DecodeRegion(SQLReader["Location"]), string.Empty, "_");
                    if (SQLReader["txtTown"].ToString().Length > 0)
                    {
                        lblLocation.Text += " (" + SQLReader["txtTown"].ToString() + ")";
                    }


                    //Brand
					if (SQLReader["txtBrand"] != null)
                    	lblBrandData.Text = SQLReader["txtBrand"].ToString();

                    //Model
                    if (SQLReader["txtModel"] != null)
                    {
                        if (SQLReader["txtModel"].ToString().Length > 1)
                            lblModel.Text = ".&nbsp;" + SQLReader["txtModel"].ToString();
                    }

                    //Price
					if (SQLReader["fltPrice"] != null)
                    lblPriceData.Text = Global.FormatPrice(SQLReader["fltPrice"]);

                    //Details
					if (SQLReader["txtDetails"] != null)
                    lblDetailsData.Text = SQLReader["txtDetails"].ToString();



                    //Contact
                    Session["Email"] = SQLReader["txtEmail"].ToString();
                    lnkEmailData.Text = "e-mail";
                    lnkEmailData.CommandArgument = SQLReader["txtEmail"].ToString();

                    string mailBodyTxt = System.Web.HttpUtility.UrlEncode(this.Page.Request.Url.ToString());
                    string subjAndMsg = "?subject=About your Boardhunt posting&body=I'm interested in your board: ";

                    if (hdniCat.Value == "4")
                    {
                        subjAndMsg = "?subject=About your Boardhunt posting&body=I'm interested in your gear: ";
                    }

                    lnkEmailData.Attributes.Add("href", "mailto:" + SQLReader["txtEmail"].ToString() + subjAndMsg + mailBodyTxt);
                    hdnNotifyEmail.Value = SQLReader["notify_comment_flg"].ToString();

                    lblPhoneData.Visible = ShowPhone(SQLReader["iShowPhoneNum"]);
                    if (lblPhoneData.Visible == true)
                        lblPhoneData.Text = Global.FormatPhone(SQLReader["txtPhoneNum"].ToString());

                    hdnStatus.Value = SQLReader["iStatus"].ToString();

                    if (hdnStatus.Value == "3")
                    {
                        lblStatus.Text = "THIS ITEM HAS BEEN SOLD";
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.BackColor = Color.Pink;
                        lnkEmailData.Enabled = false;
                        btnNudge.Enabled = false;
                        btnNudge.CssClass = "btnCancel";
                        btnNudge.Text = "SOLD";
                        lblNudgeText.Text = string.Empty;
                    }
                    //user
                    hdnUserId.Value = SQLReader["iUser"].ToString();


                    //Category
                    strCat = SQLReader["iCategory"].ToString();
                    hdniCat.Value = strCat;
                    hdnStrCat.Value = Global.DecodeCategory(Convert.ToInt32(strCat));
                    HypCat.Text = Global.up1(hdnStrCat.Value);

                    //Ad type - Selling:1 , Wanted:2
                    itemType = SQLReader["adType"].ToString();
                    lblPageViewCount.Text = incPageViewCount(SQLReader["iPageViewCount"].ToString());
                    lblNudges.Text = SQLReader["numNudges"].ToString();


                    try
                    {
                        string ratCnt = SQLReader["iThumbsup"].ToString();
                        string ratCnt2 = SQLReader["iThumbsdown"].ToString();

                        lblYesCnt.Text = ratCnt;
                        lblNoCnt.Text = ratCnt2;

                        if (SQLReader["iThumbsup"] == DBNull.Value || SQLReader["iThumbsdown"] == DBNull.Value)
                        {
                            lblYesCnt.Text = "0";
                            lblNoCnt.Text = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorRoutine(false, "error BindData: " + ex.Message);
                        lblYesCnt.Text = "0";
                        lblNoCnt.Text = "0";
                    }

                    //pnlShip.Visible = false;

                    //Set Rating if adtype is selling
                    if (itemType == "1")
                    {
                        //pnlCondition.Visible = true;
						try{
                        lblCondition.Text = Global.ProperSpace(DecodeCondition(SQLReader["iCondition"]));
						}
						catch{}

                        //pnlShip.Visible = true;
                        if (SQLReader["iShip"].ToString() == "1")
                            lblShip.Text = "Yes";

                        if (SQLReader["iRatingVal"].ToString() == null || SQLReader["iRatingVal"].ToString() == "")
                        {
                            //blnNullFlag = true;
                            hdnRatingVal.Value = "0";
                        }
                        else
                        {
                            int iratingVal = Convert.ToInt32(SQLReader["iRatingVal"].ToString());
                            int iratingCt = Convert.ToInt32(SQLReader["iRatingCount"].ToString());

                            if (iratingCt > (int)0)
                            {
                                hdnRatingVal.Value = Convert.ToInt16(Math.Round(Convert.ToDouble(iratingVal / iratingCt))).ToString();
                            }
                            else
                            {
                                hdnRatingVal.Value = "0";
                            }
                        }
                    }

                    //Set category specific
                    switch (strCat)
                    {
                        case "1": //surf

						ErrorLog.ErrorRoutine(false, "SURFBOARDS");

                            //lblBrand.Text = "Shaper:&nbsp";
                            lblBrandData.Text = SQLReader["txtBrand"].ToString();
                            if (SQLReader["txtShaper"] != null)
                                if (SQLReader["txtBrand"].ToString() != SQLReader["txtShaper"].ToString())
                                    if (SQLReader["txtShaper"].ToString().Length > 1)
                                        lblShaper.Text = "By " + SQLReader["txtShaper"].ToString();

                            lblBrandData.Text = SQLReader["txtBrand"].ToString();
                            lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)1));

                            lblHeight.Text = "Height&nbsp";

                            lblHeightFtData.Text = SQLReader["iHtFt"].ToString() + "\'";
                            lblHeightInData.Text = SQLReader["iHtIn"].ToString() + "\"";

                            lblWidthData.Text = SQLReader["width"].ToString();

                            if (itemType == "1")
                            {

                                if (SQLReader["widthNum"] != DBNull.Value || SQLReader["widthNum"].ToString() != "")
                                {
                                    lblWidthData.Text = lblWidthData.Text + " + " + SQLReader["widthNum"].ToString() + "/" + SQLReader["widthDenum"].ToString();
                                }
                                lblWidthData.Text = lblWidthData.Text + "\"";

                                lblThickData.Text = SQLReader["Thick"].ToString();
                                if (SQLReader["ThickNum"] != DBNull.Value || SQLReader["ThickNum"].ToString() != "")
                                {
                                    lblThickData.Text = lblThickData.Text + " + " + SQLReader["ThickNum"].ToString() + "/" + SQLReader["ThickDenum"].ToString();
                                }
                                lblThickData.Text = lblThickData.Text + "\"";
                                //

                                lblTailData.Text = Global.ProperSpace(DecodeTail(SQLReader["iTailType"]));
                                lblFinsData.Text = DecodeFins(SQLReader["iFins"]);

                                //pnlWidth.Visible = true;
                                //pnlSurfOnly.Visible = true;
                            }
                            else
                            {
                                //pnlSurfOnly.Visible = false;
                            }

						ErrorLog.ErrorRoutine(false, "SURFBOARDS2");

                            break;

                        case "2": //snow

                            lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)2));
                            lblBoardType.Text = "Board type:&nbsp";



                            lblHeight.Text = "Height:&nbsp";

                            lblHeightFtData.Text = SQLReader["iHtFt"].ToString() + " cm";

                            break;

                        case "3": //other
                            lblBoardType.Text = "Board type:&nbsp";
                            if (SQLReader["iBoardType"].ToString() == "" || SQLReader["iBoardType"].ToString() == null)
                            {
                                lblBoardTypeData.Text = SQLReader["txtOtherBoardType"].ToString();
                            }
                            else
                            {
                                lblBoardTypeData.Text = DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)3);
                            }

                            //pnlGenDims.Visible = true;
                            lblGenDims.Text = SQLReader["txtGenDimensions"].ToString();
                            break;
                        case "4": //gear
                            //pnlGearItem.Visible = true;
                            lblGearItem.Text = SQLReader["txtGearItem"].ToString();
                            //pnlAll.Visible = false;

                            break;

                    }

                    //selling or wanted ad type? selling=1; wanted=2
                    if (itemType == "2")
                    {
                        //just show wanted pic
                        Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/wantedbig.gif";

                        //hide ratings
                        //pnlRatings.Visible = true;

                        //hide comments
                        pnlComments.Visible = true;

                        //lblBrand.Text = "";
                        //pnlWidth.Visible = false;

                    }
                    //for selling
                    else
                    {
                        //process images
                        //add up a pic count so we know wether to hide/show ratings panel
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
                            Pic2.Height = 400;
                            Pic2.Width = 400;

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
                            Pic3.Height = 400;
                            Pic3.Width = 400;

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
                            Pic4.Height = 400;
                            Pic4.Width = 400;

                            Pic4ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath4"].ToString(), strUserDir);
                            Pic4ThmbNail.Width = 75;
                            Pic4ThmbNail.Height = 75;
                            Pic4ThmbNail.Visible = true;
                            hdnPic4URL.Value = GetPicPath(SQLReader["txtImgPath4"], strUserDir);
                        }

                        //NO IMAGES were uploaded
                        if (picCount < 1)
                        {
                            //pnlRatings.Visible = false;
                            Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/noimage.gif";
                            pnlComments.Visible = true;

                            //old
                            //Pic1.Width = 162;
                            //Pic1.Height = 209;

                            //new
                            Pic1.Width = 400;
                            Pic1.Height = 468;
                            pnlDetails.Width = 800;
                        }
                        else
                        {
                            string imgURLVal;
                            string voteVal = "voted_" + hdnEId.Value;

                            imgURLVal = string.Empty;

                            if (Session[voteVal] == null)
                            {
                                imgTdown.Enabled = imgTup.Enabled = true;
                            }
                            else //disallow voting
                            {
                                if (Session[voteVal].ToString() == "Y")
                                {
                                    lblGoodDeal.Text = "";
                                    imgTdown.Enabled = imgTup.Enabled = false;
                                }
                            }
                        }
                    }

                }//end while
                else
                {
                    ShowErrorMessage(ERR_MSG2);
                    ErrorLog.ErrorRoutine(false, "Error->ItemDetails:BindData: Just showing a message");
                }

            }// end try

            catch (Exception ex)
            {
                ShowErrorMessage(ERR_MSG2);
                //divComments.Visible = false;

                ErrorLog.ErrorRoutine(false, "Error->ItemDetails:BindData: " + ex.Message);
                classes.Email.SendErrorEmail("Error:ID:BindData:eId:" + hdnEId.Value + " :" + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            lblBoardType.Visible = false;

            BindComments();

        }
        /*
        */
        public void ShowErrorMessage(string msg)
        {
			ErrorLog.ErrorRoutine(false, ":Surfboards:ShowErrorMessage");

            pnlDetails.Controls.Clear();
            Panel pnlMsg = new Panel();
            pnlMsg.CssClass = "errorLabel";
            pnlMsg.Width = 300;
            pnlMsg.Height = 50;
            pnlMsg.Attributes.Add("style", "margin-top: 5px");
            Literal litMsg = new Literal();
            litMsg.Text = msg;
            pnlDetails.Controls.Add(pnlMsg);
            pnlMsg.Controls.Add(litMsg);

            //pnlRatings.Visible = false;
            pnlLogin.Visible = false;
            pnlLoginMsg.Visible = false;
            pnlComments.Visible = false;
            lblWallMessage.Visible = false;
            lblCommentCount.Visible = false;
        }

        /*
        */
        public void BindComments()
        {
            //load detailed data for entry item
            string strSQL;
            string myConnectString;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

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
                lblCommentCount.Text = "&nbsp;" + listCount.ToString() + "&nbsp;Comment&nbsp;";
                if (listCount != 1)
                {
                    lblCommentCount.Text = "&nbsp;" + listCount.ToString() + "&nbsp;Comments&nbsp;";
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
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

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
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;


            //Build SQL
            strSQL = "INSERT INTO tblFavs (userId, entryId)";
            strSQL += "VALUES ('" + Session["userId"].ToString() + "','" + Request.QueryString["iD"].ToString() + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //TODO: need to check for duplicate entries
            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                myConnection.Close();

                BindComments();

                Global.CreateMessageAlert(this.Page, "Entry has been added to your favorites.", "alertKey");

            }

            catch
            {
                lblStatus.Text = "SQL Error: Connection Bad.<br>";
                lblStatus.Text = "SQL: " + strSQL;
            }


        }
        //EVENT HANDLERS
        protected void btnNudge_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "Yes")
            {
				//reroute to upgrade
				if (hdnNudgeCnt.Value == "1")
				{
					Session["ServiceId"] = "6";
					Response.Redirect ("~/Pay/OrderForm.aspx?", true);
				}
                Nudge();
            }
            else
            {
				hdnMsg.Value = LOGIN_FIRST_NAG;
                return;
            }
            hdnMsg.Value = MSG_NUDGED;
            btnNudge.Enabled = false;
            btnNudge.CssClass = "btnCancel";
            btnNudge.Text = "Nudged";
        }

		protected void setupNudge()
		{
			return;
		}

		//nudge seller
        protected void Nudge()
        {
            string msg = "I'm interested in your " + lblBrandData.Text + " board:<br>";
            msg += Request.Url.ToString();
            msg += "<br><br>Email me back and let me know if it's still available.  Thanks.<br>";

            //msg += "<br> And change post visual status .Then Click Below Link to Change Post Visiual Status...<br>";


            string uidvalue = HttpUtility.UrlEncode(Encrypt(Session["userId"].ToString().Trim()));
            string bidvalue = HttpUtility.UrlEncode(Encrypt(hdnEId.Value));

            msg += "<a href=http://www.boardhunt.com/changepoststatus.aspx?uid=" + uidvalue + "&bid=" + bidvalue + ">Sold your board? Just click HERE to remove it.</a>";



            ErrorLog.ErrorRoutine(false, "To: " + Session["Email"].ToString() + " From: " + Session["EmailId"].ToString());
            classes.Email.SendEmail("Your board was Nudged", Session["Email"].ToString(), Session["EmailId"].ToString(), msg, true);

            //log nudge
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {
                dbManager.Open();

                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@UserId", Convert.ToInt32(Session["userId"].ToString()));
                dbManager.AddParameters(1, "@ItemID", Convert.ToInt32(hdnEId.Value));

				dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_LogNudge");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ID:Nudge:Error:" + ex.Message);
                classes.Email.SendErrorEmail("ID:Nudge:Couldn't add entry into tblServices " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



        protected void btnPostComment_Click(object sender, EventArgs e)
        {

            //add this entry into the favorites table
            string tmpComment;
            string strSQL;

            //check login status
            if (Session["LoggedIn"].ToString() == "No")
                return;

            //check for an empty comment
            if (txtComment.Text.Length <= 0)
            {
                txtComment.BorderColor = Color.Red;
                return;
            }

            if (chkNotify.Checked == true)
                AddUserToENotifyList();

            tmpComment = Global.CheckString(txtComment.Text);

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //Build SQL
            strSQL = "INSERT INTO tblComments (entryId, userId, txtComment, dPosted)";
            strSQL += "VALUES ('" + hdnEId.Value + "','" + Session["userId"].ToString() + "','" + tmpComment + "','" + DateTime.Now + "')";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                ErrorLog.ErrorRoutine(false, "Inserted comment");
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ItemDetails:Error posting comment:" + ex.Message);
                lblStatus.Text = "Error posting comment.<br>";
            }
            finally
            {
                dbManager.Close();
            }

            //Send E-mail
            if (hdnNotifyEmail.Value == "Y")
            {
                string[] eLinkArr = new string[3];
                eLinkArr[0] = Request.Url.ToString();
                //TODO: replace double ''
                eLinkArr[1] = tmpComment;
                eLinkArr[2] = Session["userName"].ToString();

                //get bcc list
                strSQL = @"SELECT n.iUserId, u.txtEmail FROM tblNotify n 
                INNER JOIN tblUser u ON n.iUserId = u.iD
                WHERE iEntry ='" + hdnEId.Value + "'";

                try
                {
                    dbManager.Open();
                    dbManager.ExecuteReader(CommandType.Text, strSQL);

                    //loop reader into array then pass to email
                    ArrayList alBccEmails = new ArrayList();
                    while (dbManager.DataReader.Read())
                    {
                        alBccEmails.Add(dbManager.DataReader["txtEmail"]);
                    }
                    classes.Email.SendEmailBccArry(eLinkArr[2] + " commented on your board", lnkEmailData.CommandArgument, classes.Email.MSG_POSTED_COMMENT, eLinkArr, alBccEmails);

                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorRoutine(false, "ID:PostComment:Error:" + ex.Message);
                    classes.Email.SendErrorEmail("ID:PostComment:Error:" + ex.Message);
                }
                finally
                {
                    dbManager.Close();
                    dbManager.Dispose();
                }
            }

            //Refresh
            Response.Redirect(Request.Url.ToString(), true);

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
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

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

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in PageViewCount processing: " + ex.Message);
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

                lblWallMessage.Text = "Write a comment below";

                btnNudge.Visible = true;
                btnNudge.Enabled = true;
                btnNudge.CssClass = "Tips btnGo";

            }
            //login failed 
            else
            {
                lblWallMessage.Text = "Wrong username or password.&nbsp;&nbsp;<a id='toggle2' class='orange_orange14u' href='#'>Login&nbsp;again.</a>";
                lblWallMessage.ForeColor = Color.Red;
                //Response.Redirect(Request.Url.ToString(), false);

            }
        }
        /*
         */
        protected void btnMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value, false);
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
        public string SetPicPath(object uDir, object imgPath)
        {
            //set the default
            string retVal = "images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
            }

            return retVal;
        }
        /*
         */

        public void HeaderInit()
		{
			/*
            if (Session["LoggedIn"].ToString() == "Yes")
            {
                if (hdnAcctStatus.Value == "1")
                    //lnkUpgradeAcct.Visible = false;
                else
                    lnkUpgradeAcct.Visible = true;
            }
            else
                lnkUpgradeAcct.Visible = false;

        }
			*/
		}
        public string FormatPicPath(object oDir, object oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.ToString().Length > 1)
                return serverURL + "/users/" + oDir.ToString() + "thmb_" + oPic.ToString();
            return serverURL + "/images/nopic64.jpg";

        }
        /*
         */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ShowItem(object src, CommandEventArgs e)
        {
            //ErrorLog.ErrorRoutine(false, "path: " + "surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());

        }

        public void AddUserToENotifyList()
        {
            ErrorLog.ErrorRoutine(false, "attempting to add to notify");
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            strSQL = "INSERT INTO tblNotify (iEntry, iUserId, iLevel)";
            strSQL += " SELECT DISTINCT '" + hdnEId.Value + "','" + Session["userId"].ToString() + "','0'";
            strSQL += " FROM tblNotify";
            strSQL += " WHERE NOT EXISTS (SELECT * FROM tblNotify WHERE iEntry='" + hdnEId.Value + "' AND iUserId='" + Session["userId"].ToString() + "')";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                ErrorLog.ErrorRoutine(false, "Added to notify");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "I_D:AddUserToENotifyList:Error:" + ex.Message);
                classes.Email.SendErrorEmail("I_D:AddUserToENotifyList:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //switch (btn.)           
            //{                 
            //    case "ThisBtnClick":                     

            //        break;                 
            //    case "ThatBtnClick":                     

            //        break;            
            //} 
            Response.Redirect("surfboard.aspx?" + "iD=" + btn.CommandArgument, true);
        }

        protected void btnPageNext_Click(object sender, EventArgs e)
        {
            //Response.Redirect("surfboard.aspx?iD=" + );
        }

        [WebMethod]
        public static void setVoteDone()
        {
            ErrorLog.ErrorRoutine(false, "1");
            string voteVal = "voted_" + b_id;
            ErrorLog.ErrorRoutine(false, "2");
            HttpContext.Current.Session[voteVal] = "Y";
            ErrorLog.ErrorRoutine(false, "3");
        }

    }
}
