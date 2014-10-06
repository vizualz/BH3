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

namespace BoardHunt.Qna
{
    /// <summary>
    /// Summary description for search_results.
    /// </summary>
    public partial class List : System.Web.UI.Page
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

        //protected System.Web.UI.WebControls.CheckBox chkBizOnly;



        protected void Page_Load(object sender, System.EventArgs e)
        {

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            //if (Page.IsPostBack)
            //{
            //    string controlName = Request.Params.Get("__EVENTTARGET");

            //    switch(controlName)
            //    {
            //        case "pageLnkButton":
            //            string val = Request.Params.Get("__EVENTARGUMENT");
            //            CurrentPage = Convert.ToInt32(val);
            //            break;
            //        case "btnSearch":
            //            CurrentPage = 0;
            //            break;
            //    }
                
              
            //}
            
            //due to the nature of this complex page we need to bind the data every time regardless of first time or postbacks
            ItemsGet();
            
            //if (!Page.IsPostBack)
            //{
            //    LoadFilter();
            //}

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
            string strDesc;
            string controlName;
            int intCatType;
            string strLocation;

            strDesc = "";

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            string owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];

            //build SQL
            strSQL = @"SELECT DISTINCT " + owner + @".getQAnswerCount(q.QiD) as COUNTER, q.QiD, q.Cat, q.Status, q.CreateDate, q.CloseDate, q.PublishFlg, q.Question, q.iUser, q.iViews,
                       u.iD, u.txtEmail
                       FROM Questions q
                       INNER JOIN tblUser u on q.iUser = u.iD";

            

            if (cboKeywordsVal.Length > 0)
            {
                strSQL += @" WHERE ";
                strSQL += " q.txtTags LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
                strSQL += " OR q.Question LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
            }

            //Set descending order by date
            strSQL += " ORDER BY q.CreateDate DESC";

            //ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            //Get handle to connection 
            SqlConnection myConnection = new SqlConnection(myConnectString);

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblQuestions");

                //Get result count for paging
                int listCount = dsItems.Tables["tblQuestions"].Rows.Count;

                //hide lblNoResult
                lblNoResult.Text = "";
                lblNoResult.Visible = false;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "Your search for: " + "<font color='red'>" + strDesc + "</font>" + " did not match any items. <a href='#' onClick='history.back()'><u> Try again.</u></a>";
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
                ErrorLog.ErrorRoutine(false, "ItemsGet:Error:Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "SQL: " + strSQL);
                lblMessage.Text = "Error!";
            }

            finally
            {
                myConnection.Close();
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
 * //Returns truncated string
*/
            public string FormatDetails(object oChunk)
            {

                int cLength = oChunk.ToString().Length;

                string txtChunk = oChunk.ToString();
                int n = 45;

                if (txtChunk.Length > n)
                {
                    //check if substring @ 100 pos. is char or whitespace
                    if (txtChunk.Substring(n, 1).ToString() != " ")
                    {
                        do
                        {
                            n++;
                            if (n >= cLength)
                                return txtChunk;

                            if (txtChunk.Substring(n, 1).ToString() == " ")
                            {
                                break;
                            }
                        } while (n <= txtChunk.Length);
                    }

                    //remove characters after 100.
                    txtChunk = txtChunk.Remove(n, txtChunk.Length - n) + "...";
                }
                return txtChunk;
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
            Response.Redirect("QDetails.aspx?" + "q=" + e.CommandArgument.ToString() );//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());

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

            ErrorLog.ErrorRoutine(false, "AAP:List:btnSearch_Click");

            //Set new values to viewstate
            if (txtFilterKwd.Text.Length > 1)
                cboKeywordsVal = txtFilterKwd.Text;
            else
                cboKeywordsVal = string.Empty;

            //Reset the paging
            CurrentPage = 0;
            
            //User has chosen to filter results     
            ItemsGet();
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
    }
}
