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

namespace BoardHunt.Shaper
{
    public partial class ModelDetails : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Panel pnlWeb;

        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton lnkAbuse;
        protected System.Web.UI.WebControls.LinkButton lnkLoginFirst;
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

        protected System.Web.UI.WebControls.Label lblWall;

        //protected System.Web.UI.WebControls.Label lblModelData;

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
            this.imgAddFav.Click += new System.Web.UI.ImageClickEventHandler(this.imgAddFav_Click);
            this.imgBuy.Click += new System.Web.UI.ImageClickEventHandler(this.imgBuy_Click);

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {

            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            //Get model iD
            string[] arString;
            arString = Request.QueryString.GetValues("iD");
            if (arString != null)
            {
                hdnEId.Value = Request.QueryString["iD"].ToString();
                arString[0] = string.Empty;
            }
            else
            {
                lblStatus.Text = "Something went wrong.  Click <a href='surfboardsforsale.aspx?iCat=1'>HERE</a> to view boards.";
                lblStatus.ForeColor = Color.White;
                return;
            }


            //lblWallMessage.Text = "<a id=\"toggle2\" class=\"ltgreen_orange12\" href=\"#\"><u>Login</u></a>&nbsp;to write on the Wall.";
            if (Session["LoggedIn"].ToString() == "Yes")
            {
                lblWallMessage.Text = "Write a comment below";
                pnlLogin.Visible = false;
                btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing something into the box.');event.returnValue=false;return false;}else{return true;}");
            }
            string tPage = Page.Request.Url.ToString();
            if (tPage.IndexOf("ModelDetails.aspx") > 1)
                lblWall.Text = "Ask the shaper.";
            else
                lblWall.Text = "Comments or questions? Ask below.";

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

            //Hide all sub-panels then show accordingly
            imgAddFav.Visible = false;
            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
            lblCommentCount.BackColor = Color.Orange;
            pnlCommentBox.BorderWidth = Unit.Pixel(0);
        }
/*
 */
        private void BindData()
        {
            string strSQL;
            string myConnectString;
            string strCat;

            string itemType = "";
            int picCount = 0;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //query item and user details for entry
            strSQL = @"SELECT u.iD, u.txtWebSite, u.txtFirstName, u.txtEmail, u.txtBrandName, u.txtPhonenum, u.userDir, u.iShowPhoneNum, u.notify_comment_flg, tblEntry.* 
                     FROM tblUser u 
                     INNER JOIN tblEntry ON u.Id = tblEntry.iUser 
                     WHERE tblEntry.iD = '" + hdnEId.Value + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                while (SQLReader.Read())
                {
                    //Date
                    lblDateData.Text = String.Format("{0:MM/dd}", SQLReader["dCreateDate"]);

                    //model
                    lblModelData.Text = SQLReader["txtModel"].ToString();

                    //link to parent
                    HypNavPrim.Text = "ShaperHouse";
                    HypNavSec.Text = SQLReader["txtBrandName"].ToString();
                    HypNavSec.NavigateUrl = "SurfboardShaper.aspx?q=" + SQLReader["iUser"].ToString();

                    //Price
                    if (SQLReader["fltPrice"] == DBNull.Value)
                        lblPriceData.Text = SQLReader["txtPrice"].ToString();
                    else
                        lblPriceData.Text = Global.FormatPrice(SQLReader["fltPrice"]);                        

                    //Details
                    lblDetailsData.Text = SQLReader["txtDetails"].ToString();

                    //Contact
                    Session["Email"] = SQLReader["txtEmail"].ToString();
                    //lnkEmailData.Text = ParseEmail(SQLReader["txtEmail"].ToString());
                    lnkEmailData.Text = "Click to email";
                    lnkEmailData.CommandArgument = SQLReader["txtEmail"].ToString();

                    hdnBuyURL.Value = SQLReader["txtWebSite"].ToString();

                    string mailBodyTxt = System.Web.HttpUtility.UrlEncode(this.Page.Request.Url.ToString());
                    string subjAndMsg = "?subject=About your Model&body=I'm interested in more: ";

                    lnkEmailData.Attributes.Add("href", "mailto:" + SQLReader["txtEmail"].ToString() + subjAndMsg + mailBodyTxt);
                    hdnNotifyEmail.Value = SQLReader["notify_comment_flg"].ToString();

                    lblPhoneData.Visible = ShowPhone(SQLReader["iShowPhoneNum"]);
                    if (lblPhoneData.Visible == true)
                        lblPhoneData.Text = Global.FormatPhone(SQLReader["txtPhoneNum"].ToString());

                    if (SQLReader["iStatus"].ToString() == "3")
                    {
                        lblStatus.Text = "This item has been sold";
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.BackColor = Color.White;
                    }
                    //user
                    hdnUserId.Value = SQLReader["iUser"].ToString();

                    //Category
                    strCat = SQLReader["iCategory"].ToString();
                    hdniCat.Value = strCat;
                    hdnStrCat.Value = Global.DecodeCategory(Convert.ToInt32(strCat));

                    //Ad type - Selling:1 , Wanted:2, 3:Showcase, 4:ShaperHouse
                    itemType = SQLReader["adType"].ToString();

                    //Video
                    if (SQLReader["EntryVideoEmbed"] != null)
                        if (SQLReader["EntryVideoEmbed"].ToString().Length > 0)
                        {
                            pnlVideo.Visible = true;
                            lblVideo.Text = Server.HtmlDecode(SQLReader["EntryVideoEmbed"].ToString());
                        }

                    string ipv = incPageViewCount(SQLReader["iPageViewCount"].ToString());
                    lblViews.Text = "&nbsp;" + ipv + "&nbsp;View" + ((Convert.ToInt32(ipv) == 1) ? string.Empty : "s") + "&nbsp;";

                    string ratCnt = SQLReader["iRatingCount"].ToString();

                    if (ratCnt == string.Empty)
                    {
                        ratCnt = "0";
                    }

                    hdnRatingCnt.Value = ratCnt;

                    if (ratCnt == "1")
                    {
                        ratCnt += " Rating";
                    }
                    else
                    {
                        ratCnt += " Ratings";
                    }

                    //lblRatingCount.Text = ratCnt;

                    pnlShip.Visible = false;

                    //Set Rating if adtype is selling
                    if (itemType == "1")
                    {

                        pnlShip.Visible = true;
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

                            lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)1));
                            lblBoardType.Text = "Board type:&nbsp";
                            pnlGenDims.Visible = true;
                            lblGenDims.Text = SQLReader["txtGenDimensions"].ToString();
                            break;

                        case "2": //snow

                            lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)2));
                            lblBoardType.Text = "Board type:&nbsp";

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

                            break;
                        case "4": //gear
                            break;

                    }

                    //selling or wanted ad type? selling=1; wanted=2
                    if (itemType == "2")
                    {
                        //just show wanted pic
                        Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/wantedbig.gif";

                        //hide ratings
                        pnlRatings.Visible = true;

                        //hide comments
                        pnlComments.Visible = true;

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
                            pnlRatings.Visible = false;
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
                                imgURLVal = "images/target_green.gif";
                            }
                            else //disallow voting
                            {
                                if (Session[voteVal].ToString() == "Y")
                                {
                                    imgURLVal = "images/target_orange.gif";
                                    //star1.Enabled = star2.Enabled = star3.Enabled = star4.Enabled = star5.Enabled = false;
                                }
                            }
                        }
                    }

                    lblFB.Text = "<fb:like href='" + Request.Url.ToString() + "' show_faces='false' colorscheme='dark' width='300'></fb:like>";

                    ////FB:OpenGraph meta tags
                    HtmlMeta mt = new HtmlMeta();
                    mt.Attributes.Add("property", "og:title");
                    mt.Attributes.Add("content", SQLReader["txtBrandName"].ToString() + "|" + SQLReader["txtModel"].ToString());

                    HtmlMeta mt1 = new HtmlMeta();
                    mt1.Attributes.Add("property", "og:description");
                    mt1.Attributes.Add("content", Global.FormatDetails(SQLReader["txtDetails"].ToString(), 100));

                    HtmlMeta mt2 = new HtmlMeta();
                    mt2.Attributes.Add("property", "og:type");
                    mt2.Attributes.Add("content", "company");

                    HtmlMeta mt3 = new HtmlMeta();
                    mt3.Attributes.Add("property", "og:url");
                    mt3.Attributes.Add("content", Request.Url.ToString());

                    HtmlMeta mt4 = new HtmlMeta();
                    mt4.Attributes.Add("property", "og:image");
                    mt4.Attributes.Add("content", Pic1ThmbNail.ImageUrl);

                    HtmlMeta mt5 = new HtmlMeta();
                    mt5.Attributes.Add("property", "og:email");
                    mt5.Attributes.Add("content", SQLReader["txtEmail"].ToString());

                    HtmlMeta mt6 = new HtmlMeta();
                    mt6.Attributes.Add("property", "og:phone_number");
                    mt6.Attributes.Add("content", SQLReader["txtPhonenum"].ToString());

                    this.Header.Controls.Add(mt);
                    this.Header.Controls.Add(mt1);
                    this.Header.Controls.Add(mt2);
                    this.Header.Controls.Add(mt3);
                    this.Header.Controls.Add(mt4);
                    this.Header.Controls.Add(mt5);
                    this.Header.Controls.Add(mt6);

                }//end while
            }// end try

            catch (Exception ex)
            {
                lblStatus.Text = "Error Loading Data";
                lblStatus.BackColor = Color.Pink;
                ErrorLog.ErrorRoutine(false, "Error->ItemDetails:BindData: " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            //ShaperHouse:Models only
            //lblRatingCount.Visible = false;
            lblDateData.Visible = false;
            imgAddFav.Visible = false;

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
            Response.Redirect("../post.aspx",true);
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
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "INSERT INTO tblComments (entryId, userId, txtComment, dPosted)";
            strSQL += "VALUES ('" + hdnEId.Value + "','" + Session["userId"].ToString() + "','" + tmpComment + "','" + DateTime.Now + "')";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
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
                    ErrorLog.ErrorRoutine(false, "ModelDetails:btnPostComment:Error:" + ex.Message);
                    classes.Email.SendErrorEmail("ModelDetails:btnPostComment:Error: " + ex.Message);
                }
                finally
                {
                    dbManager.Close();
                    dbManager.Dispose();
                }
            }

            //Refresh
            Response.Redirect(Request.Url.ToString());

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
            //if (Session[tmpURL] != null)
            //{
            //    if (Session[tmpURL].ToString() == Request.Url.ToString())
            //        return cnt;
            //}

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

                //Get text for login links
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                lblWallMessage.Text = "Write a comment below";

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
            Response.Redirect("../search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value, false);
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
        public string FormatPicPath(object oDir, object oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.ToString().Length > 1)
                return serverURL + "/users/" + oDir.ToString() + oPic.ToString();
            return serverURL + "/images/nopic32.jpg";

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

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

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
/*
 */

        private void imgBuy_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Session["ServiceId"] = "5";
            Session["TxnItemId"] = hdnUserId.Value;
            Response.Redirect("../Pay/OrderForm.aspx", false);

            //redir?

            /*
            string hdnBuyURLs = "http://" + hdnBuyURL.Value;

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"INSERT INTO tblShapersReport (iUser, iType, nData, dAdded) 
                        VALUES('" + hdnUserId.Value + "','1','" + hdnBuyURL.Value + "','" + DateTime.Now + "')";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ModelDetails:imgBuy_Click:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            Response.Redirect(hdnBuyURLs, false);
             */
        }

        protected void imgBuy_Click1(object sender, ImageClickEventArgs e)
        {

        } 
    }
}
