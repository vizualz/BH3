//Log:      Check CVS for log
//
//

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

namespace BoardHunt.Bidder
{
    /// <summary>
    /// Summary description for search_results.
    /// </summary>
    public partial class BidResults : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.Image imgCameraPic;

        
        //TODO: obsolete
        //protected System.Web.UI.WebControls.Label lblLocation;

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

        protected void Page_Load(object sender, System.EventArgs e)
        {

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (Page.IsPostBack)
            {
                string controlName = Request.Params.Get("__EVENTTARGET");

                switch(controlName)
                {
                    case "pageLnkButton":
                        string val = Request.Params.Get("__EVENTARGUMENT");
                        CurrentPage = Convert.ToInt32(val);
                        break;
                    case "btnSearch":
                        CurrentPage = 0;
                        break;
                }
            }

            //due to the complex nature of this page we need to bind the data every time regardless of first time or postbacks
            ItemsGet();
            
            if (!Page.IsPostBack)
            {
                LoadFilter();
                BindUpgrades();
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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);

        }
        #endregion

        private void ItemsGet()
        {

            //declare variables	
            string strSQL;    //Moved to global
            string myConnectString;
            int intCatType;
            string strLocation;
            string strDesc;
            string strUser;
            string controlName;

            strDesc = string.Empty;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            intCatType = Convert.ToInt32(Request.QueryString["iCat"]);  //category

            //get query string for location which may or may not be null
            string[] arString;
            arString = Request.QueryString.GetValues("loc");
            if (arString != null)
            {
                strLocation = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                strLocation = "all";
            }

            //On postbacks:
            if (Page.IsPostBack)
            {
                controlName = Request.Params.Get("__EVENTTARGET");
                bool blnEntryItemClick = (controlName.IndexOf("dlEntryList") >= (int)0 ? true : false);

                //if there's ever a mismatch on a listitem click, go with?
                //it could be strLoc or it could be the selected cboval depending if we're showing at filtered result set
                //who do we pick???
                if ((strLocation != cboLocation.SelectedValue) && blnEntryItemClick)
                {
                    //ErrorLog.ErrorRoutine(false, "2b");
                    
                    if (hdnLocVal.Value == "-1")
                    {
                        //ErrorLog.ErrorRoutine(false, "2c");
                        strLocation = cboLocation.SelectedValue;
                    }
                    else
                    {
                        //ErrorLog.ErrorRoutine(false, "2d");
                        strLocation = hdnLocVal.Value;
                    }

                }
                else //just a filter click
                {

                    strLocation = cboLocation.SelectedValue;
                }

            }

            //location display only
            if (strLocation != "all" && strLocation != "All")
            {
                HypLoc.Text = Global.ProperSpace(DecodeRegion(Convert.ToInt32(strLocation)));
            }

            HypLoc.Text = "Bids";

            lblCat.Text = Global.up1(DecodeiCat(intCatType));

            //get query string for keywords which may or may not be null
            //Array.Clear(arString, 0, 1);
            string[] arString2;
            arString2 = Request.QueryString.GetValues("desc");
            if (arString2 != null)
            {
                strDesc = HttpUtility.UrlDecode(arString2[0].ToString());
                arString2[0] = string.Empty;
            }
            else
            {
                strDesc = "";
            }

            //TODO: query by user?
            //get query string for displaying user
            //arString = Request.QueryString.GetValues("uId");
            //if (arString != null)
            //{
            //    strUser = HttpUtility.UrlDecode(arString[0].ToString());
            //    arString[0] = string.Empty;

            //    lblCat.Text += " by user";
            //    HypLoc.NavigateUrl = "search_results.aspx?loc=all&iCat=" + intCatType;
            //    HypLoc.ToolTip = "Click here to view all users";
                
            //}
            //else
            //{
            //    strUser = String.Empty;
            //}

            //build SQL
            strSQL = "SELECT e.iD, e.iBidder, e.iHtFt, e.iHtIn, e.startPrice, e.dStartDate, e.dEndDate, e.iBoardType FROM tblBidEntry e ";
            
            strSQL += @"WHERE ";

            //if (strUser != String.Empty)
            //{
            //    strSQL += " e.iBidder ='" + strUser + "'" + " AND ";
            //}

            //remove "all"
            if (strLocation != "all" && strLocation != "All")
            {
                strSQL += " e.Location = '" + strLocation + "'" + " AND";
            }
            strSQL += " e.iCategory = '" + intCatType + "'";

            //set filter for category category 
            if (intCatType != (int)1)
            {
                pnlFltSurf.Visible = false;
            }
            else 
            {
                //check filter and see if something is selected for boardType  *TODO: remove the superfluous "&&" 
                if (cboBoardType.SelectedValue != "All" && cboBoardType.SelectedIndex >= (int)0)
                {
                    strSQL += " AND e.iBoardType = '" + cboBoardType.SelectedValue + "'";
                }

                //check filter for finType  *TODO: remove the superfluous "&&" 
                if (cboFins.SelectedValue != "All" && cboBoardType.SelectedIndex >= (int)0)
                {
                    strSQL += " AND e.iFins = '" + cboFins.SelectedValue + "'";
                }

                //check filter for finType  *TODO: remove the superfluous "&&" 
                if (cboTailType.SelectedValue != "All" && cboBoardType.SelectedIndex >= (int)0)
                {
                    strSQL += " AND e.iTailType = '" + cboTailType.SelectedValue + "'";
                }

                if (cboPostingType.SelectedValue != "All" && cboPostingType.SelectedIndex >= (int)0)
                {
                    strSQL += " And u.iAcctType = '" + cboPostingType.SelectedValue + "'";
                }
            }

            //fix filter for empty boxes
            if (txtMinPrice.Text.Length == (int)0) { txtMinPrice.Text = "Min"; }
            if (!IsNumeric(txtMinPrice.Text)) { txtMinPrice.Text = "Min"; }

            if (txtMaxPrice.Text.Length == (int)0) { txtMaxPrice.Text = "Max"; }
            if (!IsNumeric(txtMaxPrice.Text)) { txtMaxPrice.Text = "Max"; }

            //check filter for price
            if (txtMinPrice.Text != "Min")
            {
                strSQL += " AND e.fltPrice >= '" + Convert.ToDouble(txtMinPrice.Text) + "'";
            }

            if (txtMaxPrice.Text != "Max")
            {
                strSQL += " AND e.fltPrice <= '" + Convert.ToDouble(txtMaxPrice.Text) + "'";
            }

            //search for keyword from query string
            if (strDesc.Length > 0)
            {
                strSQL += " AND e.txtBrand LIKE '%" + strDesc + "%'";
                strSQL += " OR e.txtTown LIKE '%" + strDesc + "%'";
                strSQL += " OR e.txtDetails LIKE '%" + strDesc + "%'";
            }

            if (txtFilterKwd.Text.Length > 0)
            {
                //TODO: Checkstring
                strSQL += " AND e.txtBrand LIKE '%" + Global.CheckString(txtFilterKwd.Text) + "%'";
                strSQL += " OR e.txtTown LIKE '%" + Global.CheckString(txtFilterKwd.Text) + "%'";
                strSQL += " OR e.txtDetails LIKE '%" + Global.CheckString(txtFilterKwd.Text) + "%'";
            }

            if (txtHtFt.Text.Length == (int)0) { txtHtFt.Text = "ft"; }
            if (!IsNumeric(txtHtFt.Text)) { txtHtFt.Text = "ft"; }

            if (txtHtIn.Text.Length == (int)0) { txtHtIn.Text = "in"; }
            if (!IsNumeric(txtHtIn.Text)) { txtHtIn.Text = "in"; }

            if (txtHtFt.Text != "ft")
            {
                strSQL += " AND e.iHtFt = '" + txtHtFt.Text + "'";
                //never search just in alone
                if (txtHtIn.Text != "in")
                {
                    strSQL += " AND e.iHtIn = '" + txtHtIn.Text + "'";
                }
            }

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set descending order by date
            strSQL = strSQL + " ORDER BY e.dStartDate DESC";

            ////////////////////
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);
                
                //Fill DataSet
                //objAdapter.Fill(dsItems, "tblEntry");

                //Get result count for paging
                //int listCount = dsItems.Tables["tblEntry"].Rows.Count;
                int listCount = dsItems.Tables[0].Rows.Count;

                //hide lblNoResult
                lblNoResult.Text = "";
                lblNoResult.Visible = false;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "Your search for: " + "<font color='red'>" + strDesc + "</font>" + " did not match any bid items. <a href='#' onClick='history.back()'><u> Try again.</u></a>";
                        lblNoResult.Visible = true;
                        dlEntryList.Visible = false;
                        pnlFilter.Visible = false;
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

                lblCount.Text = "(" + listCount.ToString() + ")";

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

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:BidResults Page_Load:Msg: " + ex.Message);
                lblMessage.Text = "Error!";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            ////////////////////

            //Set adapter and with connection handle
            //SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

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
        public int cboFinVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboFinVal"];
                if (o == null)
                    return (cboFins.Items.Count - (int)1);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboFinVal"] = value;
            }
        }

        /*
         */
        public int cboVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboVal"];
                if (o == null)
                    return (cboBoardType.Items.Count - (int)1);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboVal"] = value;
            }
        }

        /*
         */
        public int cboTailTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboTailTypeVal"];
                if (o == null)
                    return (cboTailType.Items.Count - (int)1);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboTailTypeVal"] = value;
            }
        }

        /*
         */
        public int cboLocationVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboLocationVal"];
                if (o == null)
                    return (cboLocation.Items.Count - (int)1);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboLocationVal"] = value;
            }
        }

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
                if (pgCount > 1)
                {
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
                                retVal = "../images/shortboard.gif";
                                break;
                            case "2":
                                retVal = "images/longboard.gif";
                                break;
                            case "3":
                                retVal = "images/fish.gif";
                                break;
                            case "4":
                                retVal = "images/funshape.gif";
                                break;
                            case "5":
                                retVal = "images/gun.gif";
                                break;
                            //case "6":
                            //    return "images/s1x1.gif";
                            //    break;
                            case "24":
                                retVal = "images/standup.gif";
                                break;
                            case "27":
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
            string retVal = "../images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "../images/s1x1.gif";
            }
            else
            {
                string hdr = "Bid on a::";
                
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
                            case "3":
                                retVal = "fish/retro";
                                break;
                            case "4":
                                retVal = "funshape";
                                break;
                            case "5":
                                retVal = "gun";
                                break;
                            case "6":
                                retVal = "other";
                                break;
                            case "24":
                                retVal = "standup paddle";
                                break;
                            case "27":
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
                retVal = hdr + retVal;
            }
            return retVal;
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
        public string SetPicPath(object iCat, object oUser, object oImgPath)//, object uD)
        {

            //set to clear pic for default
            string retVal = "images/s1x1.gif";
            string strImgPath;// = "thmbNail_" + oImgPath.ToString();

            //get the user dir for the person who posted
            //string iId = Global.ReplaceEx(SQLReader["userDir"].ToString(), @"\", @"/");

            if (oImgPath == DBNull.Value || oImgPath.ToString() == "")
            {
                return retVal;
            }
            else
            {
                string strServerURL;
                strImgPath = "thmbNail_" + oImgPath.ToString();

                strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                //retVal = strServerURL + "/users/" + iId + iCat.ToString() + "/" + Path.GetFileName(strImgPath);

                retVal = strServerURL + "/users/" + oUser.ToString() + Global.DecodeCategory(iCat) + "/" + Path.GetFileName(strImgPath);

            }
            return retVal;
        }
        /*
         */
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
            Response.Redirect("BidDetails.aspx?" + "iD=" + e.CommandArgument.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());

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

            ErrorLog.ErrorRoutine(false, "btnSearch_Click");

            //Set viewstate
            cboVal = cboBoardType.SelectedIndex;
            cboFinVal = cboFins.SelectedIndex;
            cboLocationVal = cboLocation.SelectedIndex;

            cboTailTypeVal = cboTailType.SelectedIndex;

            //Reload filter again
            LoadFilter();

            //Reset the paging
            CurrentPage = 0;
            
            //User has chosen to filter results     
            ItemsGet();
        }

/*
 *This is the search filter.  It truly doesn't filter the loaded data set due to the complexity of the paging control. 
 *The filter is always checked when the page is loaded.  Since it's blank for the first page load, the user will always get the
 *anticipated result.  When the any filter fields are changed followed by a search button click, the page does a postback reloading
 * the page which in turn checks in the modified filter.
 * TODO: Add panels for snow, other, and gear
 * */
        private void LoadFilter()
        {

            //declare variables	
            string strSQL;
            string myConnectString;
            string category;
            category = Request.QueryString["iCat"].ToString();

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //3. Formulate SQL
            strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "' SELECT * FROM LK_FinType SELECT * FROM LK_Region ORDER BY Description DESC";
            strSQL += " SELECT * FROM LK_TailType";
            SqlConnection myConnection = new SqlConnection(myConnectString);
            DataSet dsItems = new DataSet();

            //Create and add the (default) "All" entry
            //boardtype
            ListItem liAll = new ListItem();
            liAll.Text = "All";
            liAll.Value = "All";

            //fins
            ListItem liAllFin = new ListItem();
            liAllFin.Text = "All";
            liAllFin.Value = "All";

            //location
            ListItem liAllLoc = new ListItem();
            liAllLoc.Text = "All";
            liAllLoc.Value = "All";

            //tail
            ListItem liAllTail = new ListItem();
            liAllTail.Text = "All";
            liAllTail.Value = "All";

            try
            {

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.TableMappings.Add("Table", "tblBoardType");
                objAdapter.TableMappings.Add("Table1", "tblFinType");
                objAdapter.TableMappings.Add("Table2", "tblRegion");
                objAdapter.TableMappings.Add("Table3", "tblTailType");

                objAdapter.Fill(dsItems);

                cboBoardType.Items.Clear();
                cboBoardType.DataSource = dsItems;
                cboBoardType.DataMember = "tblBoardType";
                cboBoardType.DataTextField = "BoardType";
                cboBoardType.DataValueField = "iD";
                cboBoardType.DataBind();
                cboBoardType.Items.Add(liAll);

                cboBoardType.ClearSelection();
                cboBoardType.SelectedIndex = cboVal;

                cboFins.Items.Clear();
                cboFins.DataSource = dsItems;
                cboFins.DataMember = "tblFinType";
                cboFins.DataTextField = "finType";
                cboFins.DataValueField = "iD";
                cboFins.DataBind();
                cboFins.Items.Add(liAllFin);

                cboFins.ClearSelection();
                cboFins.SelectedIndex = cboFinVal;

                //Location
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
                cboLocation.SelectedIndex = cboLocationVal;

                cboTailType.Items.Clear();
                cboTailType.DataSource = dsItems;
                cboTailType.DataMember = "tblTailType";
                cboTailType.DataTextField = "TailType";
                cboTailType.DataValueField = "iD";
                cboTailType.DataBind();
                cboTailType.Items.Add(liAllTail);

                cboTailType.ClearSelection();
                cboTailType.SelectedIndex = cboTailTypeVal;

                if (!Page.IsPostBack)
                {
                    SyncFilter();
                }
            }
            catch
            {
                lblMessage.Text = "Filter Error:";
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
            string strLoc = Request.QueryString["loc"].ToString();
            if (strLoc == "all" || strLoc == "All")
            {
                cboLocation.SelectedItem.Selected = false;
                cboLocation.Items.FindByText("All").Selected = true;
            }
            else
            {
                cboLocation.SelectedItem.Selected = false;
                //lookup querystring and sync to cboLoc
                cboLocation.Items.FindByValue(strLoc).Selected = true;
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
        protected void BindUpgrades()
        {

            ErrorLog.ErrorRoutine(false, "BindUpgrades()");

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
        public string SetHotPicPath(object uDir, object imgPath)
        {
            
            //set the default
            string retVal = "images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
                //ErrorLog.ErrorRoutine(false, "path: " + retVal);
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
    }
}
