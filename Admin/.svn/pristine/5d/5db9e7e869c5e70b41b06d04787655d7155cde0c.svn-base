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
using System.Text;
using DALLayer;
using Yedda;
using System.Threading;

namespace BoardHunt.Admin
{
    /// <summary>
    /// Summary description for search_results.
    /// </summary>
    public partial class PostMaster1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton linkEdit;
        //protected System.Web.UI.WebControls.LinkButton lnkTweet; 
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.Button btnTweet;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.CheckBox chkBoosted;
        protected System.Web.UI.WebControls.HiddenField hdnStatusVal;

        protected void Page_Load(object sender, System.EventArgs e)
        {

           //  Put user code to initialize the page here
            Global.AuthenticateUser();

            ////prevent users hacks by typing in the URL
            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                ErrorLog.ErrorRoutine(false, "User hack attempt: " + Session["EmailId"].ToString());
                Response.Redirect("../UserMenu.aspx");
            }

            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            //TODO: put some debug in here
            if (Page.IsPostBack)
            {
                string controlName = Request.Params.Get("__EVENTTARGET");
                switch (controlName)
                {
                    case "pageLnkButton":
                        string val = Request.Params.Get("__EVENTARGUMENT");
                        CurrentPage = Convert.ToInt32(val);
                        ItemsGet();
                        break;
                }
            }
            else
            {
                ItemsGet();
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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
            this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
            this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            //this.lnkTweek.Click += new System.EventHandler(this.lnkTweek_Click);

        }
        #endregion


        private void ItemsGet()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"SELECT e.iD, e.dCreateDate, e.iHtFt, e.iHtIn, e.Location, e.iCategory, e.iUser, e.txtBrand, e.txtOtherBoardType, e.txtGearItem, e.fltPrice, e.iStatus, e.iBoosted
                        FROM tblEntry e
                        WHERE (e.adType = '1' OR e.adType = '2')";

            if (txtSearchById.Text.Length > 1)
                if (Convert.ToInt32(txtSearchById.Text) > 0)
                    strSQL += " AND e.iD = '" + Convert.ToInt32(txtSearchById.Text) + "'";

            strSQL += " ORDER BY e.dCreateDate DESC";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                objAdapter.Fill(dsItems, "tblEntry");
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                //Hide paging?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "You currently have no entries.";
                        dlEntryList.Visible = false;
                    }

                    //HidePaging();
                    ShowPaging();
                }


                lblCount.Text = "(" + listCount.ToString() + ")";

                // Populate the repeater control with the Items DataSet
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;
                objPds.AllowPaging = true;
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                //lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //    + objPds.PageCount.ToString();


                txtCurrentPage.Text   = (CurrentPage + 1).ToString();
                //toptxtCurrentPage.Text = (CurrentPage + 1).ToString();      //changebyme
                lblcpage.Text = " Of " + objPds.PageCount.ToString();
                //toplblcpage.Text = " Of " + objPds.PageCount.ToString();


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
                ErrorLog.ErrorRoutine(false, "Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }


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

        public void cmdPrev_Click(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control

            ItemsGet();
 
        }

        public void cmdNext_Click(object sender, System.EventArgs e)
        {

            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ItemsGet();

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
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void UpdateItemStatus(string iVal, string iD)
        {
            //Already confirmed so go ahead and update the entry status to sold
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblEntry SET iStatus = '" + iVal + "'";
            strSQL += "WHERE id='" + iD + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch
            {
                lblMessage.Text = "SQL Error!<br>";
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
        private void BuildPageLinks(int pgCount)
        {
            //build page links if only if we have more than one page
            if (pgCount > 1)
            {
                //clear out any old ones if we're posting back
                //placeHolder.Controls.Clear();  //changebyme

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
                    //placeHolder.Controls.Add(lnkButton); //changebyme
                }
            }

        }
        /*
         */
        //Fired when user clicks the edit link.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            Response.Redirect("../edit_item.aspx?" + "iD=" + e.CommandArgument.ToString());
        }
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void DeleteEntry(object src, CommandEventArgs e)
        {
            //ErrorLog.ErrorRoutine(false, "DeleteEntry");

            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //3. Formulate SQL
            strSQL = "DELETE FROM tblEntry WHERE id='" + e.CommandArgument + "'";
            SqlConnection myConnection = new SqlConnection(connStr);

            //TODO: Need to delete associated pics
            try
            {

                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                ItemsGet();

                //close
                myConnection.Close();
            }

            catch
            {
                lblMessage.Text = "SQL Error!<br>";
            }
        }
        /*
         */
        public bool GetBoostedStatus(object oObj, object oVal)
        {
            if (oObj == null)
            {
                return false;
            }
            else
            {
                if (oObj.ToString() == string.Empty || oObj.ToString() == "0")
                {
                    return false;
                }
                //already upgraded -- expected value of 1 here
                return true;
            }

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
/**
*/
        public bool GetSoldStatus(object objStat)
        {
            ErrorLog.ErrorRoutine(false, "GetSoldStatus");
            return true;

            if (objStat.ToString() == "3")
                return true;
            return false;

        }
/*
 */ 
        public bool OnDDLoad(object objStat)
        {
            ErrorLog.ErrorRoutine(false, "OnDDLoad");
            return true;

            if (objStat.ToString() == "3")
                return true;
            return false;

        }
        
/**
*/
        public string SetBoostStatusVal(object objStat)
        {

            if (objStat != null)
            {
                return objStat.ToString();
            }
            else
            {
                return "0";
            }
        }
/**
 */
        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {

            //ddlImportance.SelectedValue = CType(e.Item.DataItem,
            //DataRowView).Row.Item("IncImp_ID").ToString
            //how to pass DataListItemEventArgs?

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {
                LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
                if (lnkbtn != null)
                {
                    lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");
                }

                DropDownList ddStatus = (DropDownList)e.Item.FindControl("cboStatus");
                if (ddStatus != null)
                {
                    ddStatus.Items.Clear();

                    ListItem liStatus1 = new ListItem("Active", "1");
                    ListItem liStatus3 = new ListItem("Sold", "3");
                    ListItem liStatus6 = new ListItem("Removed", "6");
                    ddStatus.Items.Add(liStatus1);
                    ddStatus.Items.Add(liStatus3);
                    ddStatus.Items.Add(liStatus6);

                    HiddenField hdnStatus = (HiddenField)e.Item.FindControl("hdnStatusDefaultVal");
                    
                    ddStatus.SelectedValue = hdnStatus.Value;

                }            
            }
        }
/**
 */
        public void dlEntryList_OnItemCreated(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            //{

            //    DropDownList ddStatus = (DropDownList)e.Item.FindControl("cboStatus");
            //    if (ddStatus != null)
            //    {
            //        //System.Web.UI
            //        ListItem liStatus1 = new ListItem("Active","1");
            //        ListItem liStatus3 = new ListItem("Sold","3");
            //        ListItem liStatus6 = new ListItem("Deactivated","6");
            //        ddStatus.Items.Add(liStatus1);
            //        ddStatus.Items.Add(liStatus3);
            //        ddStatus.Items.Add(liStatus6);

            //    }

            //}
        }

        /**
         */
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {

            Global.NavigatePage(lnkSignIn.Text);

        }
        /**
         */
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);

        }
        /**
         */
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post.aspx");

        }

        /**
         */
        private void HidePaging()
        {
            cmdNext.Visible = false;
            //topcmdNext.Visible = false;
            cmdPrev.Visible = false;
            //topcmdPrev.Visible = false;
            txtCurrentPage.Visible = false; 
                 //toptxtCurrentPage.Visible = false;
            lblcpage.Visible = false;
            //toplblcpage.Visible = false;

        }

     
        /*
         */
        //Hide Paging Controls when results fall under max count
        private void ShowPaging()
        {
            cmdNext.Visible = true;
            //topcmdNext.Visible = false;
            cmdPrev.Visible = true;
            //topcmdPrev.Visible = false;
            txtCurrentPage.Visible = true;
            //toptxtCurrentPage.Visible = false;
            lblcpage.Visible = true;
            //toplblcpage.Visible = false;

        }

        /*
         */
        protected bool InServiceTable(string bVal)
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "SELECT iD from tblServices where iEntryId ='" + bVal + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PostMaster:InServiceTable:Error:" + ex.Message);
                //classes.Email.SendErrorEmail("PostMaster:Couldn't add entry into tblServices");
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            return false;
        }

/*
*/
        //*********changes here by smarttech*************
        //changes here by smarttech
        protected void BoostBoard(string bVal, string uVal)
        {
            BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
            oWS.ToggleBoostStatus(Convert.ToInt32(uVal), 0, Convert.ToInt32(bVal), 1); 
        }
/*
*/
        //changes here by smarttech
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //*Look at HOW we're looping -- for loop vs foreach!!!
            if (dlEntryList.Items.Count > 0)
            {
                foreach (DataListItem item in dlEntryList.Items)
                {
                    //ErrorLog.ErrorRoutine(false, "ItemId: " + item.ID);
                    //TODO: do a compare on each to a hidden value to see if something has really changed
                    //ErrorLog.ErrorRoutine(false, "itemIndex: " + item.ItemIndex);

                    CheckBox pubCheckBox = item.FindControl("chkBoosted") as CheckBox;
                    CheckBox pubSoldBox = item.FindControl("chkSold") as CheckBox;
                    HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;

                    //sold
                    DropDownList ddStatus = item.FindControl("cboStatus") as DropDownList;
                    UpdateItemStatus(ddStatus.SelectedValue, hdnVal.Value);
                    //if (pubSoldBox.Checked == true)
                    //{
                    //    ErrorLog.ErrorRoutine(false, "SOLD-Checked" + hdnVal.Value);
                    //    //find the id and mark it sold
                    //    ToggleSold(hdnVal.Value, true);
                    //}
                    //else
                    //{
                    //    ErrorLog.ErrorRoutine(false, "SOLD-UnChecked:" + hdnVal.Value);
                    //    ToggleSold(hdnVal.Value, false);
                    //}

                    //Boost
                    if (pubCheckBox.Checked == true)
                    {
                        //ErrorLog.ErrorRoutine(false, "Boost-Checked:" + hdnVal.Value);

                        //find the id and publish it
                        HiddenField hdnUsr = item.FindControl("hdnUser") as HiddenField;
                        BoostBoard(hdnVal.Value, hdnUsr.Value);
                    }
                    else
                    {
                        //ErrorLog.ErrorRoutine(false, "Boost-UnChecked:" + hdnVal.Value);
                        UnBoostBoard(hdnVal.Value);
                    }
                }
            }

            //reload
            this.ItemsGet();
        }
/*
 */
        protected void SearchNow(object sender, System.EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "SearchNow");
            ItemsGet();
        }

        protected void UnBoostBoard(string strVal)
        {
            BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
            oWS.ToggleBoostStatus(0, 0, Convert.ToInt32(strVal), 0);
        }
/*
 */
        public void SendTweet(object src, CommandEventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Sending Tweet");

            string status, strSQL;

            Yedda.Twitter tw = new Yedda.Twitter();

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"SELECT e.iD, e.dCreateDate, e.iHtFt, e.iHtIn, e.Location, e.iCategory, e.iUser, e.txtBrand, e.txtOtherBoardType, e.txtGearItem, e.fltPrice, e.iStatus
                        FROM tblEntry e
                        WHERE e.adType = '1' AND e.iD =" + e.CommandArgument;
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    string htft = dbManager.DataReader["iHtFt"].ToString() + "'";
                    string htin = dbManager.DataReader["iHtIn"].ToString() + "\"";
                    string brand = dbManager.DataReader["txtBrand"].ToString();
 
                    status = "A " + htft + " " + htin + " " + brand + " is for sale on Boardhunt.com";
                    status += "  Check it out: http://www.malzook.com/surfboard.aspx?iD=" + e.CommandArgument;

                    //TODO: Obsolete OLD Yedda Code
                    //retVal = tw.Update("fm@boardhunt.com", "boardhunt3", status, Twitter.OutputFormatType.XML);
                    
                    string url = "";
                    string xml = "";
                    classes.oAuthTwitter oAuth = new classes.oAuthTwitter();

                    oAuth.Token = "26946523-qrX1XQqBrNlIGr0P4pbCOMPFWOa0wFFtTWfqt6c";
                    oAuth.TokenSecret = "gGJrAimUXenzBRxCUbNPrBhTZt1kuuPeiXsrsnAaJGo";

                    //26946523-qrX1XQqBrNlIGr0P4pbCOMPFWOa0wFFtTWfqt6c
                    //gGJrAimUXenzBRxCUbNPrBhTZt1kuuPeiXsrsnAaJGo

                //Get the access token and secret.
                //oAuth.AccessTokenGet(Request["oauth_token"], Request["oauth_verifier"]);
                //if (oAuth.TokenSecret.Length > 0)
                //{
                    ErrorLog.ErrorRoutine(false, "Token: " + oAuth.Token.ToString());
                    ErrorLog.ErrorRoutine(false, "Secret: " + oAuth.TokenSecret.ToString());

                    //We now have the credentials, so make a call to the Twitter API.
                    url = "http://twitter.com/account/verify_credentials.xml";
                    xml = oAuth.oAuthWebRequest(classes.oAuthTwitter.Method.GET, url, String.Empty);
                    //apiResponse.InnerHtml = Server.HtmlEncode(xml);

                    ErrorLog.ErrorRoutine(false, "AuthXML: " + Server.HtmlEncode(xml));
                    lblMessage.Text = Server.HtmlEncode(xml);
                    return;


                    //POST Test
                    url = "http://twitter.com/statuses/update.xml";
                    xml = oAuth.oAuthWebRequest(classes.oAuthTwitter.Method.POST, url, "status=" + oAuth.UrlEncode("BH oAuth Test"));
                    lblMessage.Text = Server.HtmlEncode(xml);
                //}


                    //ErrorLog.ErrorRoutine(false, "Tweet retVal:" + retVal);
                    //lblMessage.Text = "Tweet OK";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PostMaster:SendTweet:Error:" + ex.Message);
                ErrorLog.ErrorRoutine(false, "PostMaster:SendTweet:Error:" + ex.InnerException);
                lblMessage.Text = "Tweet failed";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }
/*
 */
        public void Bump(object src, CommandEventArgs e)
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"UPDATE tblEntry SET dCreateDate ='" + DateTime.Now;
            strSQL += "' WHERE iD ='" + e.CommandArgument + "'";
            
            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

                lblMessage.Text = "Posting: " + e.CommandArgument + " was bumped";
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PostMaster:Bump:Error:" + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL:" + strSQL);
                lblMessage.Text = "Bump failed";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }

        protected void lblCurrentPage_TextChanged(object sender, EventArgs e)
        {
            
            //// Set viewstate variable to the next page
            CurrentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
            //toptxtCurrentPage.Text = lblCurrentPage.Text;

            // Reload control
            txtclick_itemget();



        }
        public void txtclick_itemget()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            strSQL = @"SELECT e.iD, e.dCreateDate, e.iHtFt, e.iHtIn, e.Location, e.iCategory, e.iUser, e.txtBrand, e.txtOtherBoardType, e.txtGearItem, e.fltPrice, e.iStatus, e.iBoosted
                        FROM tblEntry e
                        WHERE (e.adType = '1' OR e.adType = '2')";

            if (txtSearchById.Text.Length > 1)
                if (Convert.ToInt32(txtSearchById.Text) > 0)
                    strSQL += " AND e.iD = '" + Convert.ToInt32(txtSearchById.Text) + "'";

            strSQL += " ORDER BY e.dCreateDate DESC";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                objAdapter.Fill(dsItems, "tblEntry");
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                //Hide paging?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "You currently have no entries.";
                        dlEntryList.Visible = false;
                    }

                    //HidePaging();
                    ShowPaging();
                }


                lblCount.Text = "(" + listCount.ToString() + ")";

                // Populate the repeater control with the Items DataSet
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;
                objPds.AllowPaging = true;
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                //lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //    + objPds.PageCount.ToString();


                //txtCurrentPage.Text = (CurrentPage + 1).ToString();
                ////toptxtCurrentPage.Text = (CurrentPage + 1).ToString();      //changebyme
                //lblcpage.Text = " Of " + objPds.PageCount.ToString();
                ////toplblcpage.Text = " Of " + objPds.PageCount.ToString();


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
                ErrorLog.ErrorRoutine(false, "Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}
