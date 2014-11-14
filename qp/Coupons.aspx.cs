using System;
using System.Configuration;
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

namespace BoardHunt.qp
{
    public partial class Coupons : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.Image imgCameraPic;

        //TODO: obsolete
        //protected System.Web.UI.WebControls.Label lblLocation;
        //protected System.Web.UI.WebControls.CheckBox chkBizOnly;

        protected System.Web.UI.WebControls.ImageButton imgAdType;
        protected System.Web.UI.WebControls.ImageButton imgPreview;

        protected System.Web.UI.WebControls.Panel pnlPrevew;
        protected System.Web.UI.WebControls.Panel lblPrevew;

        protected System.Web.UI.WebControls.LinkButton lnkBtnImg;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton LinkButton2;
        protected System.Web.UI.WebControls.LinkButton lnkBtnPrice;
        protected System.Web.UI.WebControls.LinkButton lnkBtnTown;

        protected const int BitMask_0 = 1;
        protected const int BitMask_1 = 2;
        protected const int BitMask_2 = 4;
        protected const int BitMask_3 = 8;
        protected const int BitMask_4 = 16;
        protected const int BitMask_5 = 32;
        protected const int BitMask_6 = 64;
        protected const int BitMask_7 = 128;
        protected const int BitMask_8 = 256;
        protected const int BitMask_9 = 512;
        protected const int BitMask_10 = 1024;
        protected const int BitMask_11 = 2048;

        protected const string ERR_MSG = @"Whoops!  Something happened.  Our team of geeks will 
                                    have this fixed shortly.";
        protected const string ERR_FIXPH = @"Please re-type a valid 10 digit phone number.";
        protected const string ERR_NOT_UNIQ = @"You have already been sent this coupon.&nbsp;&nbsp;We limit 1 coupon per person.";
        protected const string MSG_SENT = @"Your coupon was sent to your phone.";


        protected void Page_Load(object sender, System.EventArgs e)
        {
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            btnSearch.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");
            btnSearch2.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");

            hdnMsg.Value = string.Empty;

            if (!Page.IsPostBack)
            {
                LoadFilter();
                //GetSetQueryStrings();
                ItemsGet();
                //SyncFilter();
            }
            else
            {
                string controlName = Request.Params.Get("__EVENTTARGET");

                switch (controlName)
                {
                    case "pageLnkButton":
                        string val = Request.Params.Get("__EVENTARGUMENT");
                        CurrentPage = Convert.ToInt32(val);
                        ItemsGet();
                        break;
                    case "btnSearch":
                        CurrentPage = 0;
                        break;
                    default:
                        //View_ItemDetail();
                        //if (control.indexof > -1)
                        break;
                }
            }
            pnlFilter.Visible = true;
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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);

        }
        #endregion


        private void ItemsGet()
        {

            string strSQL;
            string strBoardType;
            string strDesc;
            string userDir;

            strBoardType = string.Empty;
            strDesc = string.Empty;
            userDir = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //LOCATION: Display Only
            //if (cboLocationVal.ToString() != "all" || cboLocationVal.ToString() != "All" || cboLocationVal.ToString() != string.Empty)
            //if (cboLocationVal.ToLower() != "all" && cboLocationVal.ToString() != string.Empty)
            //else

            //build SQL
            strSQL = @"SELECT c.iD, c.title, c.body, c.code, c.smsPkgCnt, c.smsLiveCnt, c.dAdded, c.iUser, c.imgPath, c.iStatus, c.iPublish, c.dExpire,
                        u.userDir, u.txtPhoneNum, u.txtWebSite, u.txtUserName,
                        a.pAddress, a.city, a.zipcode, a.stateAbbr 
                        FROM tblCoupon c";

            strSQL += @" INNER JOIN tblUser u
                                    ON c.iUser = u.id";

            strSQL += @" INNER JOIN tblAddress a
                                    ON c.iUser = a.iUser";

            strSQL += @" WHERE c.iStatus = 1 AND c.iPublish = 1 AND c.smsLiveCnt > 0"; //AND smsLiveCount > 0

            //filter:CAT
            if (cboCatVal != "All")
            {
                strSQL += " AND c.CategoryId = '" + cboCatVal + "'";
            }

            //filter:Keyword
            if (cboKeywordsVal.Length > 1)
            {
                strSQL += " AND (c.title LIKE '%" + Global.CheckString(cboKeywordsVal).Trim() + "%'";
                strSQL += " OR c.body LIKE '%" + Global.CheckString(cboKeywordsVal).Trim() + "%')";
            }

            //LOCATION
            //if (cboLocationVal != "All" && cboLocationVal != "all")
            //    strSQL += " AND u.iRegion = '" + cboLocationVal + "'";

            //Set descending order by date
            strSQL += " ORDER BY c.dAdded DESC";

            //ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            lblNoResult.Visible = false;

            //Declare Dataset
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                //Get result count for paging
                //int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                int listCount = dsItems.Tables[0].Rows.Count;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "No Coupons using your search terms were found.";
                        if (hdnKeywords.Value.Length > 0)
                        {
                            lblNoResult.Text += "<br><br>Your search for: " + "<font color='red'>" + hdnKeywords.Value + "</font> had no matches.";
                        }
                        //lblNoResult.Text += " did not match any items. <a href='Surfboardsforsale.aspx?loc=" + hdnLocVal.Value + "&iCat=" + hdniCat.Value + "'><u> Try again by using the Filter on the left</u></a>";
                        lblNoResult.Text += "  <br><br>Try again by using the Filter on the left or click <a href='#'><u>here</u></a>.";

                        lblNoResult.Visible = true;
                        dlEntryList.Visible = false;
                        HidePaging();
                        lblCount.Text = string.Empty;
                        return;
                    }
                    HidePaging();
                }
                else
                {
                    //show paging
                    ShowPaging();
                }

                //lblCount.Text = "(" + listCount.ToString() + ")";

                //Build paging for control with PageDataSource.  Get the default view
                //from the DataSource and assign it to the PageDataSource.
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;
                objPds.AllowPaging = true;
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                + objPds.PageCount.ToString();

                BuildPageLinks(objPds.PageCount);

                // Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;

                //bind to DataList control
                dlEntryList.DataSource = objPds;
                dlEntryList.DataBind();
                dlEntryList.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:ItemGet():Error Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error: " + strSQL);
                lblMessage.Text = "Error";
                lblMessage.CssClass = "errorLabel";
                classes.Email.SendErrorEmail("Error:Coupons: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public bool LogIp(string num)
        {

            string uId;
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            uId = "0";
            if (Session["LoggedIn"].ToString() == "Yes")
                uId = Session["userId"].ToString();

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            strSQL = @"INSERT INTO tblCouponLog (couponId, ipAddress, userId, dAdded, phoneNum)";
            strSQL += "VALUES ('" + hdnCiD.Value + "','" + Request.UserHostAddress + "','" + uId + "','" + DateTime.Now + "','" + num + "')";
            
            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:LogIp:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        /*
         */
        //Get/Set Viewstate for page control
        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;   // default to showing the first page
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }
        /*        
         */
        public string cboPostingTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboPostingTypeVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboPostingTypeVal"] = value;
            }
        }
        /*        
         */
        public string cboKeywordsVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboKeywordsVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboKeywordsVal"] = value;
            }
        }
        /*        
         */
        public string cboUserIdVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboUserIdVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboUserIdVal"] = value;
            }
        }
        /*        
         */
        public string cboFinVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboFinVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboFinVal"] = value;
            }
        }
        /*
         */
        public string cboBoardVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboBoardVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboBoardVal"] = value;
            }
        }
        /*
         */
        public string cboTailTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboTailTypeVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboTailTypeVal"] = value;
            }
        }
/*
 */
        public string cboCatVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboCatVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboCatVal"] = value;
            }
        }
/*
 */
        public string cboAdTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboAdTypeVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboAdTypeVal"] = value;
            }
        }
        /*
         */
        public string cboConditionVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboConditionVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboConditionVal"] = value;
            }
        }
        /*
         */
        public string cboLocationVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboLocationVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboLocationVal"] = value;
            }
        }
        /*
         */
        public string VerifyImage(object imgPicPath)
        {

            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                return "images/s1x1.gif";
            }
            else
            {
                return "images/camera.gif";
            }

        }
        /*
        */
        public string GetAdType(object adType)
        {

            if (adType == DBNull.Value || adType.ToString() == "")
            {
                return "images/s1x1.gif";
            }
            else
            {
                switch (adType.ToString())
                {
                    case "2":
                        return "images/wanted.gif";

                    default:
                        return "images/s1x1.gif";
                }
            }
        }
        /*
         */
        private void BuildPageLinks(int pgCount)
        {
            //build page links if only if we have more than one page
            if (pgCount < 2)
                return;

            //clear out any old ones if we're posting back
            placeHolder.Controls.Clear();

            //loop through and create each page link adding the page # as the visible text
            for (int i = 0; i < pgCount; i++)
            {
                LinkButton lnkButton = new LinkButton();
                lnkButton.Text = Convert.ToInt32(i + 1).ToString() + "&nbsp;";
                lnkButton.OnClientClick = ("javascript:__doPostBack('pageLnkButton','" + i + "');event.returnValue=false;return false;");
                if (CurrentPage == i)
                {
                    lnkButton.ForeColor = Color.Orange;
                }
                placeHolder.Controls.Add(lnkButton);
            }
        }
        /*
        */
        public string SetBoardPic(object iCat, object iBT)
        {

            string retVal = "images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "images/s1x1.gif";
            }
            else
            {
                switch (iCat.ToString())
                {
                    case "1":
                        switch (iBT.ToString())
                        {
                            case "1":
                                retVal = "images/shortboard.gif";
                                break;
                            case "2":
                                retVal = "images/longboard.gif";
                                break;
                            case "4":
                                retVal = "images/fish.gif";
                                break;
                            case "8":
                                retVal = "images/funshape.gif";
                                break;
                            case "16":
                                retVal = "images/gun.gif";
                                break;
                            case "64":
                                retVal = "images/standup.gif";
                                break;
                            case "128":
                                retVal = "images/pro.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "2":
                        switch (iBT.ToString())
                        {
                            case "7":
                                retVal = "images/freeride.gif";
                                break;
                            case "8":
                                retVal = "images/freestyle.gif";
                                break;
                            case "9":
                                retVal = "images/carve.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "3":
                        switch (iBT.ToString())
                        {
                            case "26":
                                retVal = "images/skateboard.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "4":
                        break;
                    default:
                        retVal = "images/s1x1.gif";
                        break;
                }
            }
            return retVal;
        }
        /*
        */
        public string GetToolTip(object iCat, object iBT)
        {
            string retVal = "images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "images/s1x1.gif";
            }
            else
            {
                switch (iCat.ToString())
                {
                    //surfboards
                    case "1":
                        switch (iBT.ToString())
                        {
                            case "1":
                                retVal = "shortboard";
                                break;
                            case "2":
                                retVal = "longboard";
                                break;
                            case "4":
                                retVal = "fish/retro";
                                break;
                            case "8":
                                retVal = "funshape";
                                break;
                            case "16":
                                retVal = "gun";
                                break;
                            case "32":
                                retVal = "other";
                                break;
                            case "64":
                                retVal = "standup paddle";
                                break;
                            case "128":
                                retVal = "pro-model";
                                break;
                            default:
                                retVal = "";
                                break;
                        }
                        break;
                    //case "2":
                    //    break;
                    //case "3":
                    //    break;
                    //case "4":
                    //    break;
                    default:
                        retVal = "";
                        break;
                }
            }
            return retVal;
        }
        /*
         * Gets available query strings and assigns them to hidden elements
         */
        private void GetSetQueryStrings()
        {

            //CATEGORY:intCatType - uses hdnVal because category has no filter element
            string[] arString;
            arString = Request.QueryString.GetValues("iCat");
            if (arString != null)
            {
                hdniCat.Value = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                //default to surfing
                hdniCat.Value = "1";
            }
            lblPageDesc.Text = string.Empty;//"All Shapers "; //+ Global.up1(DecodeiCat(Convert.ToInt32(hdniCat.Value)));

            //BOARDTYPE:strBoardType
            arString = Request.QueryString.GetValues("bt");
            if (arString != null)
            {
                if (HttpUtility.UrlDecode(arString[0].ToString()) == "0")
                    cboBoardVal = "All";
                else
                {
                    cboBoardVal = HttpUtility.UrlDecode(arString[0].ToString());
                }
                arString[0] = string.Empty;
            }
            else
            {
                cboBoardVal = "All";
            }

            //LOCATION:strLocation
            arString = Request.QueryString.GetValues("loc");
            if (arString != null)
            {
                cboLocationVal = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                cboLocationVal = "All";
            }

            //KEYWORDS:strDesc
            arString = Request.QueryString.GetValues("desc");
            if (arString != null)
            {

                cboKeywordsVal = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                cboKeywordsVal = string.Empty;
            }

        }
/*
 */
        public string CheckExp(object dExp)
        {
            if (dExp == null)
                return string.Empty;

            if (dExp.ToString().Length > 1)
                return "Expires: " + String.Format("{0: MM/dd/yyyy}", dExp);
            return string.Empty;
        
        }

/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, object oVal)
        {
            //set cLen to oVal
            int cLen = Convert.ToInt32(oVal);

            //get string
            string txtChunk = oChunk.ToString();

            //if the string length is greater than our cut-off pt. prepare to truncate
            if (txtChunk.Length > cLen)
            {

                int n = cLen;

                //check if substring @ cLen pos. is char or whitespace
                if (txtChunk.Substring(n, 1).ToString() != " ")
                {

                    do
                    {
                        n++;
                        if (n == txtChunk.Length) break;

                        if (txtChunk.Substring(n, 1).ToString() == " ")
                        {
                            break;
                        }
                    } while (n < txtChunk.Length);
                }

                //remove characters after cLen chars.
                if (txtChunk.Length > n)
                {
                    txtChunk = txtChunk.Remove(n, txtChunk.Length - n) + "...";
                }
            }
            return txtChunk;
        }

        /*
         */
        public string FormatHeightFt(object heightFt)
        {
            string ht = heightFt.ToString();

            switch (Convert.ToInt32(Request.QueryString["iCat"]))
            {
                case 1:
                    ht = ht + "\'";
                    break;
                case 2:
                    ht = ht + " cm" + "&nbsp;";
                    break;
                case 3:
                    ht = "";
                    break;
                case 4:
                    ht = "";
                    break;
            }

            return ht;
        }
        /*
         */
        public string FormatHeightIn(object heightIn)
        {

            string inch = heightIn.ToString();

            switch (Convert.ToInt32(Request.QueryString["iCat"]))
            {
                case 1:
                    inch = inch + "\"" + "&nbsp;";
                    break;
                case 2:
                    inch = "";
                    break;
                case 3:
                    inch = "";
                    break;
                case 4:
                    inch = "";
                    break;
            }

            return inch;
        }
/*
 */
        public string GetMapURL(object addy, object city, object st)
        {
            if (addy == null || city == null || st == null)
                return string.Empty;

            return "javascript:void(0);window.open('http://maps.google.com/maps?q=" + addy.ToString() + "+" + city.ToString() + "+" + st.ToString() + "')";

        }

/*
*/
        public string SetPicPath(object oUser, object oImgPath)//, object uD)
        {

            string retVal = "../images/CouponDefault.gif";  //set default
            string strImgPath;

            if (oImgPath == DBNull.Value || oImgPath.ToString() == "" || oImgPath.ToString() == "-1")
            {
                return retVal;
            }
            else
            {
                string strServerURL;
                //strImgPath = "thmbNail_" + oImgPath.ToString();
                strImgPath = oImgPath.ToString();

                hdnServer.Value = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                strServerURL = hdnServer.Value;
                //retVal = strServerURL + "/users/" + iId + iCat.ToString() + "/" + Path.GetFileName(strImgPath);

                retVal = strServerURL + "/users/" + Global.ReplaceEx(oUser.ToString(), @"\", @"/") + Path.GetFileName(strImgPath);

            }
            return retVal;
        }
/*
 */
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {
            string errStr = string.Empty;
            hdnMsg.Value = string.Empty;

            if (e.CommandName == "map")
                return;
            
            if (e == null)
                    return;
                
            //goto merchant website //TODO: make it a pop-up
            if (e.CommandName == "redir")
            {
                if (e.CommandArgument != null)
                {
                    if (e.CommandArgument.ToString().IndexOf("http://") > -1)
                        Response.Redirect(e.CommandArgument.ToString(), true);
                    else
                        Response.Redirect("http://" + e.CommandArgument.ToString(), true);
                }
            }

            //get coupon id
            hdnCiD.Value = e.CommandArgument.ToString();

                TextBox oTxtBox = (TextBox)e.Item.FindControl("txtPhoneNum");
                if (oTxtBox != null)
                {
                    //TODO: Remove ( ) -
                    //Global.ReplaceEx(oTxtBox.Text,"(", string.Empty);

                    if (oTxtBox.Text.Length < 1)    //????
                    {
                        hdnMsg.Value = ERR_FIXPH;
                        return;
                    }
                    
                    if (oTxtBox.Text.Length < 10)
                    {
                        hdnMsg.Value = ERR_FIXPH;
                        return;
                    }

                    if (!CheckForUniqueRequest())
                    {
                        //lblMessage.Text = ERR_NOT_UNIQ;
                        hdnMsg.Value = ERR_NOT_UNIQ;
                        hdnCiD.Value = string.Empty;
                        return;
                    }

                    classes.Mobile.Sms oSms = new BoardHunt.classes.Mobile.Sms();
                    oSms.PhoneNum = oTxtBox.Text;

                    //load coupon details
                    oSms = LoadSMSData(hdnCiD.Value, oSms);

                    string retVal = string.Empty;
                    retVal = oSms.EzSendREST();
                    ErrorLog.ErrorRoutine(false, "SMSretVal: " + retVal);
                    
                    if (retVal.IndexOf("Success") > 1)
                        retVal = "1";

                    switch (retVal)
                    {
                        case ("1"):
                            //lblMessage.Text = "Message sent";
                            hdnMsg.Value = MSG_SENT;
                            //DecrementCouponCnt();
                            //if (!LogIp(oTxtBox.Text))
                            //    errStr = "Error logging ip for coupon";
                            oTxtBox.Text = string.Empty;
                            break;
                        case ("-1"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "Invalid user and/or password or API is not allowed for your account";
                            break;
                        case ("-2"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "Credit limit reached";
                            break;
                        case ("-5"):
                            errStr = "Local opt out";
                            break;
                        case ("-7"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "Invalid message or subject";
                            break;
                        case ("-104"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "Globally opted out phone number";
                            break;
                        case ("-106"):
                            hdnMsg.Value = "Please re-type a correct phone number";
                            errStr = "Incorrectly formatted phone number";
                            break;
                        case ("-10"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "Unknown error";
                            break;
                        case ("0"):
                            hdnMsg.Value = ERR_MSG;
                            errStr = "t_Unknown_Err";
                            break;
                    }
                    
                    if (errStr.Length > 0)
                        classes.Email.SendErrorEmail(errStr);
                }
                else
                {
                    classes.Email.SendErrorEmail("Error:TxtPhone was NULL");
                }

                //clean up
                errStr = string.Empty;
                hdnCiD.Value = string.Empty;

                this.ItemsGet();
        }
/*
 */
        protected void DecrementCouponCnt()
        {
            //checks coupon status first then decrement; coupons with 0 credits will not be displayed
            classes.Coupon.InitDecrement(hdnCiD.Value);
        }


        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            Response.Redirect("SurfboardShaper.aspx?" + "q=" + e.CommandArgument.ToString());//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void SendSMS(object src, CommandEventArgs e)
        {
            return;

            
            //if (txtMessage.Length < 1)
            //{
            //    lblMessage.Text = "SMS Failed";
            //    lblMessage.CssClass = "errorLabel";
            //    return;
            //}
            
            ////decrement count

            //lblMessage.Text = txtMessage;
            //lblMessage.CssClass = "errorLabel";

            //oSMS.Send(txtMessage);
            //DecrementCount(e.CommandArgument.ToString());
        }
/*
 */ 
        protected bool CheckForUniqueRequest()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            strSQL = "SELECT iD FROM tblCouponLog WHERE ipAddress = '" + Request.UserHostAddress + "'";
            strSQL += " AND couponId = '" + hdnCiD.Value + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupons:CheckForUniqueRequest:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupons:CheckForUniqueRequest:Error: Failed UniqueCheck");
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
                    
        }
/*
 */
        protected bool DecrementCount(string iD)
        {
        //TODO:
            return true;
        }


        protected classes.Mobile.Sms LoadSMSData(string iD, classes.Mobile.Sms objSms)
        {
            //build SQL
            string strSQL = string.Empty;
            string sMsg = string.Empty;
            strSQL = "SELECT c.iD, c.title, c.body, c.code, c.smsPkgCnt, c.smsLiveCnt, c.dAdded, c.iUser, c.imgPath, c.iStatus, c.iPublish, c.dExpire"; //, u.userDir, u.txtPhoneNum";
            strSQL += @" FROM tblCoupon c";
//            strSQL += @" INNER JOIN tblUser u ON c.iUser = u.id";

            strSQL += " WHERE c.iD = '" + iD + "'";

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    objSms.Subj = dbManager.DataReader["title"].ToString();
                    
                    sMsg = dbManager.DataReader["body"].ToString() + " - Code:" + dbManager.DataReader["code"].ToString();
                    //if (dbManager.DataReader["dExpire"] != null)
                    //    sMsg += " | Good thru " + dbManager.DataReader["dExpire"].ToString();

                    objSms.Msg = sMsg;
                    //objSms.PhoneNum = "8583424630";
                }
                else
                {
                    ErrorLog.ErrorRoutine(false,"Error on read for coupon data");
                }
                return objSms;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupons:GetTxtForSMS:Error:" + ex.Message);
                return objSms;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
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

        private void cmdPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            ItemsGet();

        }

        private void cmdNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ItemsGet();

        }

        //Hide Paging Controls when results fall under max count
        private void HidePaging()
        {
            cmdNext.Visible = false;
            cmdPrev.Visible = false;
            lblCurrentPage.Visible = false;

        }
        /*
         */
        //Hide Paging Controls when results fall under max count
        private void ShowPaging()
        {
            cmdNext.Visible = true;
            cmdPrev.Visible = true;
            lblCurrentPage.Visible = false;

        }
        /*
         */
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: assign per category
            ErrorLog.ErrorRoutine(false, "btnFilterSearch_Click");

            //Set new values to viewstate
            if (txtFilterKwd.Text.Length > 1)
                cboKeywordsVal = txtFilterKwd.Text;
            else
                cboKeywordsVal = string.Empty;


            //cboLocationVal = cboLocation.SelectedValue.ToString();
            cboCatVal = cboCategory.SelectedValue.ToString();


            //cboAdTypeVal = cboAdType.SelectedValue.ToString();
            //cboPostingTypeVal = cboPostingType.SelectedValue.ToString();
            //cboConditionVal = cboCondition.SelectedValue.ToString();
            //if (hdniCat.Value == "1")
            //{
            //    cboBoardVal = cboCategory.SelectedValue.ToString();
            //    cboFinVal = cboFins.SelectedValue.ToString();
            //    cboTailTypeVal = cboTailType.SelectedValue.ToString();
            //}

            //Reset the paging
            CurrentPage = 0;

            //User has chosen to filter results     
            ItemsGet();
        }

        /*
         * Here we just load and set everything to the default values.
         * NOTE: When any filter fields are changed followed by a search button click, 
         * the new vaules are set and the page will requery.
         * TODO: Add panels for snow, other, and gear
         * */
        private void LoadFilter()
        {
            //ErrorLog.ErrorRoutine(false, "LoadFilter");

            //declare variables	
            string strSQL;
            string myConnectString;
            string category;

            //careful here
            string[] arString;
            arString = Request.QueryString.GetValues("iCat");
            if (arString != null)
            {
                category = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                category = "2";
            }

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            // build SQL
            strSQL = "SELECT * FROM LK_Category WHERE GroupId = '2'"; 

            SqlConnection myConnection = new SqlConnection(myConnectString);
            DataSet dsItems = new DataSet();

            //Create and add the (default) "All" entry
            ListItem liAllCat = new ListItem("All", "All");  //boardtype
            ListItem liAllLoc = new ListItem("All", "All"); //loc

            try
            {

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                //objAdapter.TableMappings.Add("Table", "LK_Category");
                //objAdapter.TableMappings.Add("Table1", "tblFinType");
                //objAdapter.TableMappings.Add("Table2", "tblRegion");
                //objAdapter.TableMappings.Add("Table3", "tblTailType");
                //objAdapter.TableMappings.Add("Table4", "tblAdType");
                //objAdapter.TableMappings.Add("Table5", "tblCondition");

                objAdapter.Fill(dsItems);

                //Category
                cboCategory.Items.Clear();
                cboCategory.DataSource = dsItems.Tables[0];
                //cboCategory.DataMember = "LK_Category";
                cboCategory.DataTextField = "Category";
                cboCategory.DataValueField = "iD";
                cboCategory.DataBind();
                
                cboCategory.Items.Add(liAllCat);
                cboCategory.ClearSelection();
                cboCategory.SelectedIndex = cboCategory.Items.Count - 1;
                //cboCategory.SelectedIndex = cboVal;

                //FINS
                //cboFins.Items.Clear();
                //cboFins.DataSource = dsItems;
                //cboFins.DataMember = "tblFinType";
                //cboFins.DataTextField = "finType";
                //cboFins.DataValueField = "iD";
                //cboFins.DataBind();
                //cboFins.Items.Add(liAllFin);
                //cboFins.ClearSelection();
                //cboFins.SelectedIndex = cboFins.Items.Count - 1;
                //cboFins.SelectedIndex = cboFinVal;

                return;

                //LOCATION
                cboLocation.Items.Clear();
                cboLocation.DataSource = dsItems;
                cboLocation.DataMember = "tblRegion";
                cboLocation.DataTextField = "Region";
                cboLocation.DataValueField = "iD";
                cboLocation.DataBind();
                for (int i = 0; i < cboLocation.Items.Count; i++)
                {
                    switch (dsItems.Tables[2].Rows[i][2].ToString().Trim())
                    {
                        case "State":
                            cboLocation.Items[i].Attributes.Add("style", "color:#000000");
                            break;
                        case "Continent":
                            cboLocation.Items[i].Attributes.Add("style", "color:#999999");
                            break;
                        case "Country":
                            cboLocation.Items[i].Attributes.Add("style", "color:#666666");
                            break;
                    }
                }
                cboLocation.Items.Add(liAllLoc);
                cboLocation.ClearSelection();
                cboLocation.SelectedIndex = cboLocation.Items.Count - 1;
                //cboLocation.SelectedIndex = cboLocationVal;

                //TAIL
                //cboTailType.Items.Clear();
                //cboTailType.DataSource = dsItems;
                //cboTailType.DataMember = "tblTailType";
                //cboTailType.DataTextField = "TailType";
                //cboTailType.DataValueField = "iD";
                //cboTailType.DataBind();
                //cboTailType.Items.Add(liAllTail);
                //cboTailType.ClearSelection();
                //cboTailType.SelectedIndex = cboTailType.Items.Count - 1;
                //cboTailType.SelectedIndex = cboTailTypeVal;

                //ADTYPE: For Sale, Wanted, Showcase
                //cboAdType.Items.Clear();
                //cboAdType.DataSource = dsItems;
                //cboAdType.DataMember = "tblAdType";
                //cboAdType.DataTextField = "adType";
                //cboAdType.DataValueField = "iD";
                //cboAdType.DataBind();
                //cboAdType.Items.Add(liAllType);
                ////remove showcase
                //cboAdType.Items.RemoveAt(2);
                //cboAdType.ClearSelection();
                //cboAdType.SelectedIndex = cboAdType.Items.Count - 1;
                //cboAdType.SelectedIndex = cboAdTypeVal;

                //CONDITION
                //cboCondition.Items.Clear();
                //cboCondition.DataSource = dsItems;
                //cboCondition.DataMember = "tblCondition";
                //cboCondition.DataTextField = "condition";
                //cboCondition.DataValueField = "iD";
                //cboCondition.DataBind();
                //cboCondition.Items.Add(liAllCondType);
                //cboCondition.ClearSelection();
                //cboCondition.SelectedIndex = cboCondition.Items.Count - 1;
                //cboCondition.SelectedIndex = cboConditionVal;

                //?
                //if (!Page.IsPostBack)
                //{
                //    SyncFilter();
                //}
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Filter Error:";
                ErrorLog.ErrorRoutine(false, "Filter Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }
        /**
         */
        private void SyncFilter()
        {
            //KEYWORDS
            if (cboKeywordsVal.Length > 1)
                txtFilterKwd.Text = cboKeywordsVal;

            //LOCATION
            //HACK: fixfixfix
            cboLocation.ClearSelection();

            if (cboLocationVal == "all")
                cboLocationVal = "All";
            if (cboLocationVal == string.Empty)
                cboLocationVal = "All";
            cboLocation.Items.FindByValue(cboLocationVal).Selected = true;

            //cboCondition.ClearSelection();
            //cboCondition.Items.FindByValue(cboConditionVal).Selected = true;

            //cboAdType.ClearSelection();
            //cboAdType.Items.FindByValue(cboAdTypeVal).Selected = true;


            if (hdniCat.Value == "1")
            {

                //BOARDTYPE
                cboCategory.ClearSelection();
                cboCategory.Items.FindByValue(cboBoardVal).Selected = true;

                if (cboTailTypeVal == string.Empty)
                    cboTailTypeVal = "All";
                //cboTailType.ClearSelection();
                //cboTailType.Items.FindByValue(cboTailTypeVal).Selected = true;
                //cboFins.ClearSelection();
                //cboFins.Items.FindByValue(cboFinVal).Selected = true;

            }
        }
        /**
        */
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);
        }
        /**
        */
        public string DecodeAdType(object AdCode)
        {
            return Enum.GetName(typeof(Global.AD_TYPE), AdCode);
        }
        /**
        */
        public string DecodeiCat(object iCat)
        {
            return Global.ReplaceEx(Enum.GetName(typeof(Global.BOARDCAT_TYPE), iCat), "_", " ");
        }

        /**
        */
        public string GetStatus(object objStat)
        {

            string strStat = "";
            strStat = objStat.ToString();
            if (strStat == "3")
            {
                strStat = "SOLD";
            }
            return strStat;

        }

        /*
         */
        //Helper function to determine if value is numeric
        private bool IsNumeric(object valType)
        {
            double tempVal = new double();
            string InputValue = Convert.ToString(valType);

            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out tempVal);

            return Numeric;
        }

        /*
         */
        //<option value="1">Shortboard     </option>1
        //<option value="2">Longboard      </option>2
        //<option value="3">Fish/Retro     </option>4
        //<option value="4">Fun Shape      </option>8
        //<option value="5">Gun            </option>16
        //<option value="6">Other          </option>32
        //<option value="24">Standup Paddle </option>64
        //<option value="27">Pro Model      </option>128
        //<option value="28">Vintage        </option>256
        //<option selected="selected" value="All">All</option>

        private string BuildQryBoardType(string sBoardType)
        {
            int intBoardType = Convert.ToInt32(sBoardType);

            string strBType = " AND";

            if ((BitMask_0 & intBoardType) > 0)
                strBType += " e.iBoardType = 1";
            if ((BitMask_1 & intBoardType) > 0)
                strBType += " e.iBoardType = 2";
            if ((BitMask_2 & intBoardType) > 0)
                strBType += " e.iBoardType = 3";
            if ((BitMask_3 & intBoardType) > 0)
                strBType += " e.iBoardType = 4";
            if ((BitMask_4 & intBoardType) > 0)
                strBType += " e.iBoardType = 5";
            if ((BitMask_5 & intBoardType) > 0)
                strBType += " e.iBoardType = 6";
            if ((BitMask_6 & intBoardType) > 0)
                strBType += " e.iBoardType = 24";
            if ((BitMask_7 & intBoardType) > 0)
                strBType += " e.iBoardType = 27";
            if ((BitMask_8 & intBoardType) > 0)
                strBType += " e.iBoardType = 28";

            //ErrorLog.ErrorRoutine(false, "0&: " + (BitMask_0 & intBoardType));
            //ErrorLog.ErrorRoutine(false, "1&: " + (BitMask_1 & intBoardType));
            //ErrorLog.ErrorRoutine(false, "StrBT: " + strBType);

            return strBType;
        }

        //On postbacks:
        //if (Page.IsPostBack)
        //{
        //    controlName = Request.Params.Get("__EVENTTARGET");
        //    bool blnEntryItemClick = (controlName.IndexOf("dlEntryList") >= (int)0 ? true : false);

        //    //if there's ever a mismatch on a listitem click, go with?
        //    //it could be strLoc or it could be the selected cboval depending if we're showing at filtered result set
        //    //who do we pick???
        //    if ((strLocation != cboLocation.SelectedValue) && blnEntryItemClick)
        //    {
        //        if (hdnLocVal.Value == "-1")
        //        {
        //            strLocation = cboLocation.SelectedValue;
        //        }
        //        else
        //        {
        //            strLocation = hdnLocVal.Value;
        //        }

        //    }
        //    else //just a filter click
        //    {
        //        strLocation = cboLocation.SelectedValue;
        //    }
        //}

/**
 */
        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {

                //LinkButton oLnkMap = (LinkButton)e.Item.FindControl("lnkMap");
                //if (oLnkMap != null)
                //{
                //    oLnkMap.Attributes.Add("onClick", "");
                //}
            }
        }

        protected void lnkBtnCouponStart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Start.aspx", true);
        }

        protected void imgBuy_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Session["LoggedIn"].ToString() == "Yes")
            {
                Session["ServiceId"] = "5";
                Session["TxnItemId"] = HttpContext.Current.Session["userId"];
                Response.Redirect("../Pay/OrderForm.aspx", false);
            }

        }
    }
}
