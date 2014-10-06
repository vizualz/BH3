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
    public partial class SurfboardShaper : System.Web.UI.Page
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
        //protected System.Web.UI.WebControls.LinkButton lnkWebSite;

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
            //ErrorLog.ErrorRoutine(false, "SBS:Page_Load");

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            btnSearch.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");
            btnSearch2.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");

            if (!Page.IsPostBack)
            {

                LoadFilter();
                if (!GetSetQueryStrings())
                    return;
                ItemsGet();
                SyncFilter();
            }
            else
            {
                //string controlName = Request.Params.Get("__EVENTTARGET");
                ////ErrorLog.ErrorRoutine(false, "PBfrom: " + controlName);

                //switch (controlName)
                //{
                //    case "pageLnkButton":
                //        string val = Request.Params.Get("__EVENTARGUMENT");
                //        CurrentPage = Convert.ToInt32(val);
                //        ItemsGet();
                //        break;
                //    case "btnSearch":
                //        CurrentPage = 0;
                //        break;
                //    default:
                //        //View_ItemDetail();
                //        //if (control.indexof > -1)
                //        break;
                //}
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

        protected void BindProfile()
        {
            //TODO: verify acctType !

            //ErrorLog.ErrorRoutine(false, "SBS:BindProfile");

            string userDir;
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "SELECT * FROM tblUser u WHERE";

            if (hdnUN.Value != String.Empty)
                strSQL += " u.txtUserName ='" + hdnUN.Value + "'";
            else
                strSQL += " u.iD ='" + hdnUiD.Value + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    lblPhone.Text = Global.FormatPhone(dbManager.DataReader["txtPhoneNum"].ToString());
                    lnkEmail.Text = dbManager.DataReader["txtEmail"].ToString();
                    lnkEmail.Attributes.Add("href", "mailto:" + lnkEmail.Text);
                    lblHometownData.Text = dbManager.DataReader["txtHomeTown"].ToString();
                    lnkWebSite.Text = dbManager.DataReader["txtWebSite"].ToString();
                    userDir = dbManager.DataReader["userDir"].ToString();
                    imgPic.ImageUrl = FormatPicPath(Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(),@"\", @"/"), dbManager.DataReader["profilePic"].ToString());
                    lblBrandName.Text = dbManager.DataReader["txtBrandName"].ToString();
                    lblBioData.Text = dbManager.DataReader["txtUserDetails"].ToString();//Global.FormatDetails(dbManager.DataReader["txtUserDetails"], (int)35);
                    string ipv = incPageViewCount(dbManager.DataReader["iPageViewCount"].ToString());
                    lblViews.Text = "&nbsp;" + ipv + "&nbsp;View" + ((Convert.ToInt32(ipv) == 1) ? string.Empty : "s") + "&nbsp;";

                    
                    //FB:OpenGraph meta tags
                    HtmlMeta mt = new HtmlMeta();
                    mt.Attributes.Add("property", "og:title");
                    mt.Attributes.Add("content", "ShaperHouse|"+lblBrandName.Text);

                    HtmlMeta mt2 = new HtmlMeta();
                    mt2.Attributes.Add("property", "og:type");
                    mt2.Attributes.Add("content", "company");

                    HtmlMeta mt3 = new HtmlMeta();
                    mt3.Attributes.Add("property", "og:url");
                    mt3.Attributes.Add("content", Request.Url.ToString());

                    HtmlMeta mt4 = new HtmlMeta();
                    mt4.Attributes.Add("property", "og:image");
                    mt4.Attributes.Add("content", imgPic.ImageUrl);

                    HtmlMeta mt5 = new HtmlMeta();
                    mt5.Attributes.Add("property", "og:email");
                    mt5.Attributes.Add("content", lnkEmail.Text);

                    HtmlMeta mt6 = new HtmlMeta();
                    mt6.Attributes.Add("property", "og:phone_number");
                    mt6.Attributes.Add("content", lblPhone.Text);

                    this.Header.Controls.Add(mt);
                    this.Header.Controls.Add(mt2);
                    this.Header.Controls.Add(mt3);
                    this.Header.Controls.Add(mt4);
                    this.Header.Controls.Add(mt5);
                    this.Header.Controls.Add(mt6);
                }
                lblFB.Text = "<fb:like href='" + Request.Url.ToString() + "' show_faces='false' colorscheme='dark' width='300'></fb:like>";
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BindProfile:Error:" + ex.Message);
                return;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        private void ItemsGet()
        {
            pnlFilter.Visible = false;

            BindProfile();

            string strSQL;
            string myConnectString;
            string strBoardType;
            string strDesc;

            strBoardType = string.Empty;
            strDesc = string.Empty;

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
            HypNavPrim.Text = "ShaperHouse";

            //build SQL
            if (hdniCat.Value != "4")
            {
                //ErrorLog.ErrorRoutine(false, "iCat1: " + hdniCat.Value);
                strSQL = "SELECT bt.iValue, * FROM tblEntry e";

                //JOIN stuff here; omit showcase(3)
                strSQL += @" INNER JOIN tblUser u
                                    ON e.iUser = u.id
                                    AND e.iUser IN (SELECT DISTINCT id FROM tblUser WHERE adtype = 4)";

                strSQL += @" INNER JOIN LK_BoardType bt
                        ON bt.iD = e.iBoardType";
            }
            else
            {
                //ErrorLog.ErrorRoutine(false, "iCat2: " + hdniCat.Value);
                strSQL = "SELECT NULL as iValue,* FROM tblEntry e";

                //JOIN stuff here; omit showcase(3)
                strSQL += @" INNER JOIN tblUser u
                                    ON e.iUser = u.id
                                    AND e.iUser IN (SELECT DISTINCT id FROM tblUser WHERE adtype = 4)";
            }

            strSQL += @" WHERE ";

            //ErrorLog.ErrorRoutine(false, "hdnUN.Value: " + hdnUN.Value);

            //USER
            if (hdnUN.Value != String.Empty)
                strSQL += " u.txtUserName ='" + hdnUN.Value + "'" + " AND ";
            else
                strSQL += " u.iD ='" + hdnUiD.Value + "'" + " AND ";

            //LOCATION
            if (cboLocationVal != "All" && cboLocationVal != "all")
                strSQL += " e.Location = '" + cboLocationVal + "'" + " AND";

            //CATEGORY
            strSQL += " e.iCategory = '" + hdniCat.Value + "'";

            //ADTYPE:filter
            if (cboAdTypeVal != "All")
            {
                strSQL += " AND e.adType = '" + cboAdTypeVal + "'";
            }
            else
            {
                strSQL += " AND e.adType = 4 ";
            }

            //BOARD CONDITION:filter
            if (cboCondition.SelectedValue != "All" && cboCondition.SelectedIndex >= (int)0)
            {
                strSQL += " AND e.iCondition = '" + cboCondition.SelectedValue + "'";
            }

            //HIDE SOLD BOARDS
            //strSQL += " AND (e.iStatus IS NULL OR e.iStatus <>3) ";

            strSQL += " AND e.iStatus = 5 ";

            //set filter for category  
            if (hdniCat.Value == "1")
            {
                if (cboBoardVal != "All")
                    strSQL += " AND bt.iValue = '" + cboBoardVal + "'";

                //check filter for finType 

                if (cboFinVal != "All")
                    strSQL += " AND e.iFins = '" + cboFinVal + "'";

                //check filter for finType  

                if (cboTailTypeVal != "All")
                    strSQL += " AND e.iTailType = '" + cboTailTypeVal + "'";

                if (cboPostingTypeVal != "All" && cboPostingTypeVal != string.Empty)
                    strSQL += " AND u.iAcctType = '" + cboPostingTypeVal + "'";
            }
            else
            {
                pnlFltSurf.Visible = false;
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

            if (cboKeywordsVal.Length > 1)
            {
                strSQL += " AND (e.txtBrand LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR e.txtTown LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR e.txtDetails LIKE '%" + Global.CheckString(cboKeywordsVal) + "%') ";
            }

            //Validate and set to "ft" or "in" upon failure
            //MIN
            if (txtHtFt.Text.Length == (int)0) { txtHtFt.Text = "ft"; }
            if (!IsNumeric(txtHtFt.Text)) { txtHtFt.Text = "ft"; }

            if (txtHtIn.Text.Length == (int)0) { txtHtIn.Text = "in"; }
            if (!IsNumeric(txtHtIn.Text)) { txtHtIn.Text = "in"; }

            //to MAX
            if (txtHtFtMax.Text.Length == (int)0) { txtHtFtMax.Text = "ft"; }
            if (!IsNumeric(txtHtFtMax.Text)) { txtHtFtMax.Text = "ft"; }

            if (txtHtInMax.Text.Length == (int)0) { txtHtInMax.Text = "in"; }
            if (!IsNumeric(txtHtInMax.Text)) { txtHtInMax.Text = "in"; }

            //Search EXACT example:
            //AND iHtFt = 5 and iHtIn = 9

            //Search RANGE example:
            //AND iHtFt=5 AND iHtIn BETWEEN 9 AND 11
            //OR iHtFt=6 AND iHtIn BETWEEN 0 AND 2

            if ((txtHtFt.Text != "ft"))//check for valid start
            {
                strSQL += " AND e.iHtFt = '" + txtHtFt.Text + "'";

                if (txtHtIn.Text != "in")
                {
                    strSQL += " AND e.iHtIn";

                    if (txtHtFtMax.Text != "ft") //Do RANGE
                    {
                        if (Convert.ToInt16(txtHtFtMax.Text) > Convert.ToInt16(txtHtFt.Text)) //max > min for "ft"
                        {
                            strSQL += " BETWEEN " + txtHtIn.Text + " AND 11";
                            strSQL += " OR";
                            strSQL += " e.iHtFt = '" + txtHtFtMax.Text + "'";
                            if (txtHtInMax.Text != "in")
                            {
                                strSQL += "  AND e.iHtIn BETWEEN 0 AND " + txtHtInMax.Text;
                            }
                            else
                            {
                                strSQL += " AND e.iHtIn = 0";
                            }
                        }
                        else if (Convert.ToInt16(txtHtFtMax.Text) == Convert.ToInt16(txtHtFt.Text)) //max = min for "ft"
                        {
                            if (txtHtInMax.Text != "in")
                            {
                                strSQL += " BETWEEN " + txtHtIn.Text + " AND " + txtHtInMax.Text;
                            }
                            else
                            {
                                txtHtFtMax.Text = "ft";
                            }
                        }
                        else
                        {
                            txtHtFtMax.Text = "ft";
                            strSQL += "='" + txtHtIn.Text + "'";
                        }
                    }
                    else //EXACT
                    {
                        strSQL += "='" + txtHtIn.Text + "'";
                    }
                }
            }

            //Set descending order by date
            strSQL += " ORDER BY e.dCreateDate DESC";

            //ErrorLog.ErrorRoutine(false, "SBS:strSQL: " + strSQL);

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Get handle to connection 
            SqlConnection myConnection = new SqlConnection(myConnectString);

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblEntry");

                //Get result count for paging
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "Your search";
                        if (hdnKeywords.Value.Length > 0)
                        {
                            lblNoResult.Text += " for: " + "<font color='red'>" + hdnKeywords.Value + "</font>";
                        }
                        //lblNoResult.Text += " did not match any items. <a href='Surfboardsforsale.aspx?loc=" + hdnLocVal.Value + "&iCat=" + hdniCat.Value + "'><u> Try again by using the Filter on the left</u></a>";
                        lblNoResult.Text += " did not match any items. Try again by using <br/>the Filter on the left or by going back to the <a href='index.aspx'><u>home</u></a> page.";

                        lblNoResult.Visible = true;
                        dlEntryList.Visible = false;
                        HidePaging();
                        lblCount.Text = string.Empty;
                        lblNoResult.Visible = false;
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

                //lblNoResult.Text = "Loading...";
                //lblNoResult.Visible = true;

                //dlEntryList.

                //bind to DataList control
                dlEntryList.DataSource = objPds;
                dlEntryList.DataBind();
                dlEntryList.RepeatColumns = 2;
                dlEntryList.RepeatDirection = RepeatDirection.Horizontal;
                dlEntryList.Visible = true;

                //hide lblNoResult
                //lblNoResult.Text = "";
                //lblNoResult.Visible = false;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "SBS:ItemGet():Error Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
                lblMessage.Text = "Error!";
                return;
            }
            finally
            {
                myConnection.Close();
            }
        }
/*
 */ 
        protected void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("ShaperHouse.aspx",true);
        }
/*
 * Increment the PageViewCount for the entry.  The value returned will be the display value
 */
        protected string incPageViewCount(string cnt)
        {
            int retval = 0;
            string tmpURL = Request.Url.ToString();
            string strSQL = string.Empty;

            //page refresh: don't add to view count
            //if (Session[tmpURL] != null)
            //{
            //    if (Session[tmpURL].ToString() == Request.Url.ToString())
            //        return cnt;
            //}

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblUser SET iPageViewCount = iPageViewCount + 1 WHERE iD = '" + hdnUiD.Value + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

                Session.Add(Request.Url.ToString(), Request.Url.ToString());
                retval = Convert.ToInt32(cnt) + 1;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "SH:IncPageViewCount:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            return retval.ToString();
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

        public string VerifyImage(object imgPicPath)
        {

            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                return "../images/s1x1.gif";
            }
            else
            {
                return "../images/camera.gif";
            }

        }
        /*
        */
        public string GetAdType(object adType)
        {

            if (adType == DBNull.Value || adType.ToString() == "")
            {
                return "../images/s1x1.gif";
            }
            else
            {
                switch (adType.ToString())
                {
                    case "2":
                        return "../images/wanted.gif";

                    default:
                        return "../images/s1x1.gif";
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

            string retVal = "../images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "../images/s1x1.gif";
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
                                retVal = "../images/longboard.gif";
                                break;
                            case "4":
                                retVal = "../images/fish.gif";
                                break;
                            case "8":
                                retVal = "../images/funshape.gif";
                                break;
                            case "16":
                                retVal = "../images/gun.gif";
                                break;
                            case "64":
                                retVal = "../images/standup.gif";
                                break;
                            case "128":
                                retVal = "../images/pro.gif";
                                break;
                            default:
                                retVal = "../images/s1x1.gif";
                                break;
                        }
                        break;
                    case "2":
                        switch (iBT.ToString())
                        {
                            case "7":
                                retVal = "../images/freeride.gif";
                                break;
                            case "8":
                                retVal = "../images/freestyle.gif";
                                break;
                            case "9":
                                retVal = "../images/carve.gif";
                                break;
                            default:
                                retVal = "../images/s1x1.gif";
                                break;
                        }
                        break;
                    case "3":
                        switch (iBT.ToString())
                        {
                            case "26":
                                retVal = "../images/skateboard.gif";
                                break;
                            default:
                                retVal = "../images/s1x1.gif";
                                break;
                        }
                        break;
                    case "4":
                        break;
                    default:
                        retVal = "../images/s1x1.gif";
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
                switch (iCat.ToString())
                {
                    //surfboards
                    case "1":
                        switch (iBT.ToString())
                        {
                            case "1":
                                retVal = "Model|Shortboard";
                                break;
                            case "2":
                                retVal = "Model|Longboard";
                                break;
                            case "4":
                                retVal = "Model|Fish/retro";
                                break;
                            case "8":
                                retVal = "Model|Funshape";
                                break;
                            case "16":
                                retVal = "Model|Gun";
                                break;
                            case "32":
                                retVal = "Model|Other";
                                break;
                            case "64":
                                retVal = "Model|Standup paddle";
                                break;
                            case "128":
                                retVal = "Model|Pro-model";
                                break;
                            case "256":
                                retVal = "Model|Vintage";
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
        private bool GetSetQueryStrings()
        {
            hdniCat.Value = "1";
            string pi = Request.PathInfo;
            if (pi.Length > 0)
            {
                hdnUN.Value = pi.Substring(1);
                return true;
            }

            //CATEGORY:intCatType - uses hdnVal because category has no filter element
            string[] arString;
            arString = Request.QueryString.GetValues("q");
            if (arString != null)
            {
                hdnUiD.Value = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
                return true;
            }
            else
            {
                //default to surfing
                lblMessage.Text = "missing key!";
                return false;
            }
            //lblCat.Text = "All " + Global.up1(DecodeiCat(Convert.ToInt32(hdniCat.Value)));

            //TODO: determine what is needed below

            //CATEGORY:intCatType - uses hdnVal because category has no filter element
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
            lblCat.Text = "All " + Global.up1(DecodeiCat(Convert.ToInt32(hdniCat.Value)));

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

                lblCat.Text += " by user";
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

            return true;
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
            string retVal = "../images/s1x1.gif";
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
                strImgPath = oImgPath.ToString();

                hdnServer.Value = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                strServerURL = hdnServer.Value;
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
/*
 */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            Response.Redirect("ModelDetails.aspx?" + "iD=" + e.CommandArgument.ToString());//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
        }
/*
 */
        protected void lnkWebSite_Click(object sender, System.EventArgs e)
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"INSERT INTO tblShapersReport (iUser, iType, nData, dAdded) 
                        VALUES('" + hdnUiD.Value + "','1','" + lnkWebSite.Text + "','" + DateTime.Now + "')";
            

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


            Response.Redirect("http://" + lnkWebSite.Text, false);
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


            cboLocationVal = cboLocation.SelectedValue.ToString();


            cboAdTypeVal = cboAdType.SelectedValue.ToString();
            cboPostingTypeVal = cboPostingType.SelectedValue.ToString();
            cboConditionVal = cboCondition.SelectedValue.ToString();
            if (hdniCat.Value == "1")
            {
                cboBoardVal = cboBoardType.SelectedValue.ToString();
                cboFinVal = cboFins.SelectedValue.ToString();
                cboTailTypeVal = cboTailType.SelectedValue.ToString();
            }

            //Reset the paging
            CurrentPage = 0;

            //User has chosen to filter results     
            ItemsGet();
        }

        /*
         * Here we just load and set everything to the default values.
         * NOTE: When any filter fields are changed followed by a search button click, 
         * the new vaules are set and the page will re-query.
         * TODO: Add panels for snow, other, and gear
         * */
        private void LoadFilter()
        {
            //ErrorLog.ErrorRoutine(false, "LoadingFilter");
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
                cboFins.Items.Clear();
                cboFins.DataSource = dsItems;
                cboFins.DataMember = "tblFinType";
                cboFins.DataTextField = "finType";
                cboFins.DataValueField = "iD";
                cboFins.DataBind();
                cboFins.Items.Add(liAllFin);
                cboFins.ClearSelection();
                cboFins.SelectedIndex = cboFins.Items.Count - 1;
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
                cboTailType.Items.Clear();
                cboTailType.DataSource = dsItems;
                cboTailType.DataMember = "tblTailType";
                cboTailType.DataTextField = "TailType";
                cboTailType.DataValueField = "iD";
                cboTailType.DataBind();
                cboTailType.Items.Add(liAllTail);
                cboTailType.ClearSelection();
                cboTailType.SelectedIndex = cboTailType.Items.Count - 1;
                //cboTailType.SelectedIndex = cboTailTypeVal;

                //ADTYPE: For Sale, Wanted, Showcase
                cboAdType.Items.Clear();
                cboAdType.DataSource = dsItems;
                cboAdType.DataMember = "tblAdType";
                cboAdType.DataTextField = "adType";
                cboAdType.DataValueField = "iD";
                cboAdType.DataBind();
                cboAdType.Items.Add(liAllType);
                //remove showcase
                cboAdType.Items.RemoveAt(2);
                cboAdType.ClearSelection();
                cboAdType.SelectedIndex = cboAdType.Items.Count - 1;
                //cboAdType.SelectedIndex = cboAdTypeVal;

                //CONDITION
                cboCondition.Items.Clear();
                cboCondition.DataSource = dsItems;
                cboCondition.DataMember = "tblCondition";
                cboCondition.DataTextField = "condition";
                cboCondition.DataValueField = "iD";
                cboCondition.DataBind();
                cboCondition.Items.Add(liAllCondType);
                cboCondition.ClearSelection();
                cboCondition.SelectedIndex = cboCondition.Items.Count - 1;
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

            cboCondition.ClearSelection();
            cboCondition.Items.FindByValue(cboConditionVal).Selected = true;

            cboAdType.ClearSelection();
            cboAdType.Items.FindByValue(cboAdTypeVal).Selected = true;

            if (hdniCat.Value == "1")
            {
                //BOARDTYPE
                cboBoardType.ClearSelection();
                cboBoardType.Items.FindByValue(cboBoardVal).Selected = true;

                if (cboTailTypeVal == string.Empty)
                    cboTailTypeVal = "All";
                cboTailType.ClearSelection();
                cboTailType.Items.FindByValue(cboTailTypeVal).Selected = true;
                cboFins.ClearSelection();
                cboFins.Items.FindByValue(cboFinVal).Selected = true;

            }
            //ErrorLog.ErrorRoutine(false, "done sync filter");
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

            return strBType;
        }
        /*
         */
        public string FormatPicPath(string oDir, string oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.Length > 1)
                return serverURL + "/users/" + oDir + oPic;
            return serverURL + "/images/nopic128.jpg";

        }
    }
}
