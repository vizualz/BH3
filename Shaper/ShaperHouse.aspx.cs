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

namespace BoardHunt.Shaper
{
    public partial class ShaperHouse : System.Web.UI.Page
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

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            HypLoc.Visible = false;

            btnSearch.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");
            btnSearch2.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");

            if (!Page.IsPostBack)
            {
                LoadFilter();
                GetSetQueryStrings();
                ItemsGet();
                SyncFilter();
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
            this.topcmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
            this.topcmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);

        }
        #endregion


        private void ItemsGet()
        {
            ErrorLog.ErrorRoutine(false, "ItemsGet");


            string strSQL;
            string strBoardType;
            string strDesc;
            string userDir;

            strBoardType = string.Empty;
            strDesc = string.Empty;
            userDir = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //TODO: handle all or empty
            if (cboBoardVal != "All")
                strBoardType = BuildQryBoardType(cboBoardVal);

            //LOCATION: Display Only
            //if (cboLocationVal.ToString() != "all" || cboLocationVal.ToString() != "All" || cboLocationVal.ToString() != string.Empty)
            //if (cboLocationVal.ToLower() != "all" && cboLocationVal.ToString() != string.Empty)
            //{
            //    HypLoc.Text = Global.ProperSpace(DecodeRegion(Convert.ToInt32(cboLocationVal)));
            //}
            //else
            //{
            //    HypLoc.Text = "Home";
            //}

            //build SQL
            strSQL = @"SELECT u.iD, u.txtBrandName, u.txtFullName, u.profilePic, u.txtHomeTown, u.userDir, u.txtUserDetails, u.iAcctType, u.iStatus, u.iMerchantType, u.txtUserName, u.iWisdom, u.iShaperCode, u.iPageViewCount, u.iVoucher
                        FROM tblUser u 
                        INNER JOIN tblServices s ON u.iD = s.iUserId
                        WHERE u.iAcctType = 2 AND u.iMerchantType = 1 AND s.iServiceVal = 3 AND s.iStatus = 1 
                        AND u.iD <> 3070 AND u.iD <> 433
                        ";

            // TODO: remove after using to fix tblUSer
            //UPDATE tblUser SET iStatus = 1 where iD in ( SELECT iUserId FROM tblServices WHERE iStatus = 1 and iServiceVal = 3 )

            //CATEGORY
            //strSQL += " e.iCategory = '" + hdniCat.Value + "'";

            //ADTYPE:filter
            //if (cboAdTypeVal != "All")
            //{
            //    strSQL += " AND e.adType = '" + cboAdTypeVal + "'";
            //}
            //else
            //{
            //    strSQL += " AND e.adType < 3 ";
            //}

            //BOARD CONDITION:filter
            //if (cboCondition.SelectedValue != "All" && cboCondition.SelectedIndex >= (int)0)
            //{
            //    strSQL += " AND e.iCondition = '" + cboCondition.SelectedValue + "'";
            //}

            //HIDE SOLD BOARDS: 3 = marked sold by user. 4 = Forced SOLD by BH
            //TODO: UPDATE tblEntry SET iStatus = 4 WHERE dCreateDate <  '2009-01-01' AND iStatus <> 3
            //strSQL += " AND (e.iStatus IS NULL OR e.iStatus <>3) ";

            //set filter for category  
            //if (hdniCat.Value == "1")
            //{
                //if (cboBoardVal != "All")
                //    strSQL += " AND u.iShaperCode = '" + cboBoardVal + "'";

            //    //check filter for finType 

            //    if (cboFinVal != "All")
            //        strSQL += " AND e.iFins = '" + cboFinVal + "'";

            //    //check filter for finType  

            //    if (cboTailTypeVal != "All")
            //        strSQL += " AND e.iTailType = '" + cboTailTypeVal + "'";

            //    if (cboPostingTypeVal != "All" && cboPostingTypeVal != string.Empty)
            //        strSQL += " AND u.iAcctType = '" + cboPostingTypeVal + "'";
            //}
            //else
            //{
            //    pnlFltSurf.Visible = false;
            //}

            //fix filter for empty boxes
            //if (txtMinPrice.Text.Length == (int)0) { txtMinPrice.Text = "Min"; }
            //if (!IsNumeric(txtMinPrice.Text)) { txtMinPrice.Text = "Min"; }

            //if (txtMaxPrice.Text.Length == (int)0) { txtMaxPrice.Text = "Max"; }
            //if (!IsNumeric(txtMaxPrice.Text)) { txtMaxPrice.Text = "Max"; }

            //check filter for price
            //if (txtMinPrice.Text != "Min")
            //{
            //    strSQL += " AND e.fltPrice >= '" + Convert.ToDouble(txtMinPrice.Text) + "'";
            //}

            //if (txtMaxPrice.Text != "Max")
            //{
            //    strSQL += " AND e.fltPrice <= '" + Convert.ToDouble(txtMaxPrice.Text) + "'";
            //}

            if (cboKeywordsVal.Length > 1)
            {
                strSQL += " AND (u.txtBrandName LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtFullName LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtHomeTown LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtUserDetails LIKE '%" + Global.CheckString(cboKeywordsVal) + "%') ";
            }

            //Validate and set to "ft" or "in" upon failure
            //MIN
            //if (txtHtFt.Text.Length == (int)0) { txtHtFt.Text = "ft"; }
            //if (!IsNumeric(txtHtFt.Text)) { txtHtFt.Text = "ft"; }

            //if (txtHtIn.Text.Length == (int)0) { txtHtIn.Text = "in"; }
            //if (!IsNumeric(txtHtIn.Text)) { txtHtIn.Text = "in"; }

            ////to MAX
            //if (txtHtFtMax.Text.Length == (int)0) { txtHtFtMax.Text = "ft"; }
            //if (!IsNumeric(txtHtFtMax.Text)) { txtHtFtMax.Text = "ft"; }

            //if (txtHtInMax.Text.Length == (int)0) { txtHtInMax.Text = "in"; }
            //if (!IsNumeric(txtHtInMax.Text)) { txtHtInMax.Text = "in"; }

            //Search EXACT example:
            //AND iHtFt = 5 and iHtIn = 9

            //Search RANGE example:
            //AND iHtFt=5 AND iHtIn BETWEEN 9 AND 11
            //OR iHtFt=6 AND iHtIn BETWEEN 0 AND 2

            //if ((txtHtFt.Text != "ft"))//check for valid start
            //{
            //    strSQL += " AND e.iHtFt = '" + txtHtFt.Text + "'";

            //    if (txtHtIn.Text != "in")
            //    {
            //        strSQL += " AND e.iHtIn";

            //        if (txtHtFtMax.Text != "ft") //Do RANGE
            //        {
            //            if (Convert.ToInt16(txtHtFtMax.Text) > Convert.ToInt16(txtHtFt.Text)) //max > min for "ft"
            //            {
            //                strSQL += " BETWEEN " + txtHtIn.Text + " AND 11";
            //                strSQL += " OR";
            //                strSQL += " e.iHtFt = '" + txtHtFtMax.Text + "'";
            //                if (txtHtInMax.Text != "in")
            //                {
            //                    strSQL += "  AND e.iHtIn BETWEEN 0 AND " + txtHtInMax.Text;
            //                }
            //                else
            //                {
            //                    strSQL += " AND e.iHtIn = 0";
            //                }
            //            }
            //            else if (Convert.ToInt16(txtHtFtMax.Text) == Convert.ToInt16(txtHtFt.Text)) //max = min for "ft"
            //            {
            //                if (txtHtInMax.Text != "in")
            //                {
            //                    strSQL += " BETWEEN " + txtHtIn.Text + " AND " + txtHtInMax.Text;
            //                }
            //                else
            //                {
            //                    txtHtFtMax.Text = "ft";
            //                }
            //            }
            //            else
            //            {
            //                txtHtFtMax.Text = "ft";
            //                strSQL += "='" + txtHtIn.Text + "'";
            //            }
            //        }
            //        else //EXACT
            //        {
            //            strSQL += "='" + txtHtIn.Text + "'";
            //        }
            //    }
            //}

            //LOCATION
            if (cboLocationVal != "All" && cboLocationVal != "all")
                strSQL += " AND u.iRegion = '" + cboLocationVal + "'";

            //Set descending order by date
            strSQL += " ORDER BY u.txtBrandName ASC"; //ORDER by u.txtBrandName ASC";

            //ErrorLog.ErrorRoutine(false, "shapers:strSQL: " + strSQL);

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
                        lblNoResult.Text = "No surfboard shapers using your search terms were found.";
                        if (hdnKeywords.Value.Length > 0)
                        {
                            lblNoResult.Text += "<br><br>Your search for: " + "<font color='red'>" + hdnKeywords.Value + "</font> had no matches.";
                        }
                        //lblNoResult.Text += " did not match any items. <a href='Surfboardsforsale.aspx?loc=" + hdnLocVal.Value + "&iCat=" + hdniCat.Value + "'><u> Try again by using the Filter on the left</u></a>";
                        lblNoResult.Text += "  <br><br>Try again by using the Filter on the left or click <a href='ShaperHouse.aspx'><u>here</u></a>.";

                        lblNoResult.Visible = true;
                        dlEntryList.Visible = false;
                        HidePaging();
                        lblCount.Text = string.Empty;
                        return;
                    }
                    ShowPaging();
                    //HidePaging();
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

                //txtCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //+ objPds.PageCount.ToString();

                //Chhange by Smarttech
                txtCurrentPage.Text = (CurrentPage + 1).ToString();
                toptxtCurrentPage.Text = (CurrentPage + 1).ToString();     
                lblcpage.Text = " Of " + objPds.PageCount.ToString();
                toplblcpage.Text = " Of " + objPds.PageCount.ToString();

                BuildPageLinks(objPds.PageCount);

                //// Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                topcmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;
                topcmdNext.Enabled = !objPds.IsLastPage; 

                //bind to DataList control
                dlEntryList.DataSource = objPds;
                dlEntryList.DataBind();
                dlEntryList.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "SH:ItemGet():Error Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error: " + strSQL);
                lblMessage.Text = "Error!";
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
           /* //build page links if only if we have more than one page
            if (pgCount < 2)
                return;

            //clear out any old ones if we're posting back
            //placeHolder.Controls.Clear();  //Change by Smarttech

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
                //placeHolder.Controls.Add(lnkButton);
            } */

            //rules: only 10 links ever; if more then ...

            //build page links if only if we have more than one page
            if (pgCount < 1)
                return;

            int iStart = 0;
            int iEnd = 0;
            int iLimit = 3;
            int iLimitHalf = (iLimit - 1) / 2;

            //lnkFirst.OnClientClick = ("javascript:__doPostBack('pageLnkButton','0');event.returnValue=false;return false;");
            ////toplnkFirst.OnClientClick = ("javascript:__doPostBack('pageLnkButton','0');event.returnValue=false;return false;");
            //lnkLast.OnClientClick = ("javascript:__doPostBack('pageLnkButton','" + (pgCount - 1) + "');event.returnValue=false;return false;");

            if (pgCount <= iLimit)  //less that limit; just show them
            {
                iStart = 0;
                iEnd = pgCount;
                //lnkFirst.Visible = false;
                ////toplnkFirst.Visible = false;
                //lnkLast.Visible = false;
            }
            else//pgCount over limit (30 over 15)  :: TODO: add case for getting back to beginning
            {
                if (pgCount - CurrentPage > iLimitHalf) //(30 - 20) > 7? need to scroll over
                {
                    if (CurrentPage - iLimitHalf > 0) // check for negative vals
                    {
                        iStart = CurrentPage - iLimitHalf; //re-set start page so that current is in middle
                        //lnkFirst.Visible = true;
                        //toplnkFirst.Visible = true;
                        //lnkLast.Visible = true;
                    }
                    else
                    {
                        iStart = 0;//CurrentPage; // if negative value then just set start to current
                        //lnkFirst.Visible = false;
                        //toplnkFirst.Visible = false;
                        //lnkLast.Visible = true;
                    }
                    iEnd = iStart + iLimit; //set end to  whatever startVal + the limit

                    //add ...
                }
                else
                {
                    if (pgCount - CurrentPage <= iLimitHalf) // (middle spot is too close to pgCount)
                    {
                        iStart = pgCount - iLimit;  //set start from pgCount
                        iEnd = pgCount;// set end to pgCount
                        //lnkFirst.Visible = true;
                        //toplnkFirst.Visible = true;
                        //lnkLast.Visible = false;
                    }
                }
            }

            //clear out any old ones if we're posting back
            //placeHolder.Controls.Clear();   //changebyme

            ////loop through and create each page link adding the page # as the visible text - OLD code
            for (int i = iStart; i < iEnd; i++)
            {
                //string dots = "...";

                //Label lbl = new Label();
                //lbl.Text = dots;

                LinkButton lnkButton = new LinkButton();
                lnkButton.Text = "&nbsp;" + Convert.ToInt32(i + 1).ToString() + "&nbsp;";
                lnkButton.OnClientClick = ("javascript:__doPostBack('pageLnkButton','" + i + "');event.returnValue=false;return false;");

                if (CurrentPage == i)
                {
                    lnkButton.ForeColor = Color.Orange;
                    lnkButton.BorderWidth = 1;
                    lnkButton.BorderColor = Color.Black;
                }
                //placeHolder.Controls.Add(lnkButton);  //changebyme
            }

        }
/*
 */ 
        public bool CheckVoucher(object i)
        {
            if (i != null)
            {
                if (i.ToString() == "1")
                    return true;
            }
            return false;
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

            //USER: strUser
            arString = Request.QueryString.GetValues("uId");
            if (arString != null)
            {
                cboUserIdVal = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;

                lblPageDesc.Text += " by user";
                HypLoc.NavigateUrl = "Surfboardsforsale.aspx?iCat=" + cboUserIdVal;
                HypLoc.ToolTip = "Click here to view all users";
            }
            else
            {
                cboUserIdVal = String.Empty;
            }

            //posting type: commercial or non
            arString = Request.QueryString.GetValues("pt");
            if (arString != null)
            {
                cboPostingTypeVal = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                cboPostingTypeVal = String.Empty;
            }
            //TODO: put other possible query values here; ideas: use array and pass into ItemsGet
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
        public string SetPicPath(object oUser, object oImgPath)//, object uD)
        {

            //set to clear pic for default
            string retVal = "../images/nopic64.jpg";
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
                strImgPath = "thmb_" + oImgPath.ToString();
                //strImgPath = oImgPath.ToString();

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

        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            Response.Redirect("SurfboardShaper.aspx?" + "q=" + e.CommandArgument.ToString());//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
        }
/*
 */ 
        public void BuyVoucher(object src, CommandEventArgs e)
        {
            Session["ServiceId"] = "5";
            Session["TxnItemId"] = e.CommandName;
            Response.Redirect("../Pay/OrderForm.aspx", false);
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
            //cmdNext.Visible = false;
            //cmdPrev.Visible = false;                 //Change By Smarttech
            //txtCurrentPage.Visible = false;
            cmdNext.Visible = false;
            topcmdNext.Visible = false;
            cmdPrev.Visible = false;
            topcmdPrev.Visible = false;
            txtCurrentPage.Visible = false;
            toptxtCurrentPage.Visible = false;
            lblcpage.Visible = false;
            toplblcpage.Visible = false;
        }
        /*
         */
        //Hide Paging Controls when results fall under max count
        private void ShowPaging()
        {
            //cmdNext.Visible = true;                  //Change By Smarttech
            //cmdPrev.Visible = true;
            //txtCurrentPage.Visible = false;

            cmdNext.Visible = true;
            topcmdNext.Visible = true;
            cmdPrev.Visible = true;
            topcmdPrev.Visible = true;
            txtCurrentPage.Visible = true;
            toptxtCurrentPage.Visible = true;
            lblcpage.Visible = true;
            toplblcpage.Visible = true; 

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


            cboLocationVal = cboLocation.SelectedValue.ToString();
            cboBoardVal = cboBoardType.SelectedValue.ToString();


            //cboAdTypeVal = cboAdType.SelectedValue.ToString();
            //cboPostingTypeVal = cboPostingType.SelectedValue.ToString();
            //cboConditionVal = cboCondition.SelectedValue.ToString();
            //if (hdniCat.Value == "1")
            //{
            //    cboBoardVal = cboBoardType.SelectedValue.ToString();
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
                category = "1";
            }

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            // build SQL
            strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "' SELECT * FROM LK_FinType SELECT * FROM LK_Region ORDER BY Description DESC";
            strSQL += " SELECT * FROM LK_TailType SELECT iD,adType from LK_AdType SELECT iD,condition FROM LK_Condition";
            SqlConnection myConnection = new SqlConnection(myConnectString);
            DataSet dsItems = new DataSet();

            //Create and add the (default) "All" entry
            //boardtype
            ListItem liAllBT = new ListItem("All", "All");  //boardtype
            ListItem liAllFin = new ListItem("All", "All");  //fins
            ListItem liAllLoc = new ListItem("All", "All"); //loc
            ListItem liAllTail = new ListItem("All", "All"); //tail
            ListItem liAllType = new ListItem("All", "All"); //ad type
            ListItem liAllCondType = new ListItem("All", "All"); //condition

            try
            {

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.TableMappings.Add("Table", "tblBoardType");
                objAdapter.TableMappings.Add("Table1", "tblFinType");
                objAdapter.TableMappings.Add("Table2", "tblRegion");
                objAdapter.TableMappings.Add("Table3", "tblTailType");
                objAdapter.TableMappings.Add("Table4", "tblAdType");
                objAdapter.TableMappings.Add("Table5", "tblCondition");

                objAdapter.Fill(dsItems);

                //BOARTYPE
                cboBoardType.Items.Clear();
                cboBoardType.DataSource = dsItems;
                cboBoardType.DataMember = "tblBoardType";
                cboBoardType.DataTextField = "BoardType";
                cboBoardType.DataValueField = "iValue";
                cboBoardType.DataBind();
                cboBoardType.Items.Add(liAllBT);
                cboBoardType.ClearSelection();
                cboBoardType.SelectedIndex = cboBoardType.Items.Count - 1;
                //cboBoardType.SelectedIndex = cboVal;

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
                cboBoardType.ClearSelection();
                cboBoardType.Items.FindByValue(cboBoardVal).Selected = true;

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
        public void dlEntryList_OnItemCreated(object sender, DataListItemEventArgs e)
        {

        }


/**
 */
        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (cboBoardVal == "All")
                return;

            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Separator)
            {

                ImageButton oImg = (ImageButton)e.Item.FindControl("ImageButton2");
                if (oImg != null)
                {
                    ErrorLog.ErrorRoutine(false, "oLnk: " + oImg.ImageUrl);
                    //oImg.Visible = false;
                }

                //filter the results
                LinkButton oLnk = (LinkButton)e.Item.FindControl("lnkTitle");
                if (oLnk != null)
                ErrorLog.ErrorRoutine(false, "oLnk: " + oLnk.Text);

                HiddenField oHdn = (HiddenField)e.Item.FindControl("hdnShaperCode");
                if (oHdn != null)
                {
                    int shprCode;
                    try
                    {
                        shprCode = Convert.ToInt32(oHdn.Value);
                    }
                    catch
                    {
                        shprCode = 0;
                    }
                    
                    int btVal = Convert.ToInt32(cboBoardVal);
                    if ((shprCode & btVal) < 1)
                    {
                        if (dlEntryList.Items.Count > 0)
                        {
                            Panel oPnl = (Panel)e.Item.FindControl("pnlItem");
                            if (oPnl != null)
                                oPnl.Visible = false;
                            //e.Item.Parent.Visible = false;
                            //dlEntryList.Items[e.Item.ItemIndex - 1].Visible = false;
                            //ErrorLog.ErrorRoutine(false, "Hiding");
                        }
                    }
                }
            }
        }

        //**************************************************************************************** Start Change By Smarttech *****************************************************

        protected void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            //// Set viewstate variable to the next page
            CurrentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
            toptxtCurrentPage.Text = txtCurrentPage.Text;

            // Reload control
            txtclick_itemget();



        }
        public void txtclick_itemget()
        {
            string strSQL;
            string strBoardType;
            string strDesc;
            string userDir;

            strBoardType = string.Empty;
            strDesc = string.Empty;
            userDir = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //TODO: handle all or empty
            if (cboBoardVal != "All")
                strBoardType = BuildQryBoardType(cboBoardVal);

               strSQL = @"SELECT u.iD, u.txtBrandName, u.txtFullName, u.profilePic, u.txtHomeTown, u.userDir, u.txtUserDetails, u.iAcctType, u.iStatus, u.iMerchantType, u.txtUserName, u.iWisdom, u.iShaperCode, u.iPageViewCount, u.iVoucher
                        FROM tblUser u 
                        INNER JOIN tblServices s ON u.iD = s.iUserId
                        WHERE u.iAcctType = 2 AND u.iMerchantType = 1 AND s.iServiceVal = 3 AND s.iStatus = 1 
                        AND u.iD <> 3070 AND u.iD <> 433
                        ";

            if (cboKeywordsVal.Length > 1)
            {
                strSQL += " AND (u.txtBrandName LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtFullName LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtHomeTown LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR u.txtUserDetails LIKE '%" + Global.CheckString(cboKeywordsVal) + "%') ";
            }

           //LOCATION
            if (cboLocationVal != "All" && cboLocationVal != "all")
                strSQL += " AND u.iRegion = '" + cboLocationVal + "'";

            //Set descending order by date
            strSQL += " ORDER BY u.txtBrandName ASC"; //ORDER by u.txtBrandName ASC";

            //ErrorLog.ErrorRoutine(false, "shapers:strSQL: " + strSQL);

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
                        lblNoResult.Text = "No surfboard shapers using your search terms were found.";
                        if (hdnKeywords.Value.Length > 0)
                        {
                            lblNoResult.Text += "<br><br>Your search for: " + "<font color='red'>" + hdnKeywords.Value + "</font> had no matches.";
                        }
                        //lblNoResult.Text += " did not match any items. <a href='Surfboardsforsale.aspx?loc=" + hdnLocVal.Value + "&iCat=" + hdniCat.Value + "'><u> Try again by using the Filter on the left</u></a>";
                        lblNoResult.Text += "  <br><br>Try again by using the Filter on the left or click <a href='ShaperHouse.aspx'><u>here</u></a>.";

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

                //txtCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //+ objPds.PageCount.ToString();

                //Chhange by Smarttech
                //txtCurrentPage.Text = (CurrentPage + 1).ToString();
                //toptxtCurrentPage.Text = (CurrentPage + 1).ToString();
                //lblcpage.Text = " Of " + objPds.PageCount.ToString();
                //toplblcpage.Text = " Of " + objPds.PageCount.ToString();

                BuildPageLinks(objPds.PageCount);

                // Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                topcmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;
                topcmdNext.Enabled = !objPds.IsLastPage; 

                //bind to DataList control
                dlEntryList.DataSource = objPds;
                dlEntryList.DataBind();
                dlEntryList.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "SH:ItemGet():Error Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error: " + strSQL);
                lblMessage.Text = "Error!";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            ////record keyword search term
            //if (cboKeywordsVal.Length > 1)
            //    RecordKeywords();
        }

        protected void toptxtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            //// Set viewstate variable to the next page
            CurrentPage = Convert.ToInt32(toptxtCurrentPage.Text) - 1;
            txtCurrentPage.Text = toptxtCurrentPage.Text;
            txtclick_itemget();

        }

        //**************************************************************************************** End Change By Smarttech *****************************************************
    }
}
