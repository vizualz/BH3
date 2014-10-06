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

namespace BoardHunt.qp
{
	/// <summary>
	/// Summary description for search_results.
	/// </summary>
	public partial class Manager : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton linkEdit; 
        protected System.Web.UI.WebControls.HiddenField hdnCat;
        protected System.Web.UI.WebControls.CheckBox chkPublish;
		//protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        //protected System.Web.UI.WebControls.LinkButton lnkBtnView;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{

            Global.AuthenticateUser(Request.Url.ToString());	

			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            // Call the FillCouponMgr method to populate control,
            FillCouponMgr();

            //TODO: filter users
            //FillAdminData();

            Page.DataBind();

 
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
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //this.lnkBtnView.Click += new System.EventHandler(this.lnkBtnView_Click);
            //this.lnkBtnAddNew.Click += new System.EventHandler(this.lnkBtnAddNew_Click);

		}
		#endregion

        private void FillAdminData()
        {

        }

		private void FillCouponMgr()
		{
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            btnCancel.Visible = true;
            btnUpdate.Visible = true;

            //Formulate SQL
            strSQL = "SELECT c.iD, c.dAdded, c.title, c.body, c.code, c.smsPkgCnt, c.smsLiveCnt, c.iUser, c.imgPath, c.iStatus, c.iPublish, c.dExpire"; //, s.iStatus as pStatus";
            strSQL += " FROM tblCoupon c";
            //strSQL += " LEFT JOIN tblServices s on c.iD = s.iCouponId";

            //if (Session["acctType"].ToString() != "3")
                strSQL += " WHERE c.iUser = '" + Session["userId"].ToString() + "'";
            
            strSQL += " ORDER BY c.dAdded DESC";

            try
            {
                DataSet dsItems = new DataSet();

                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                int listCount = dsItems.Tables[0].Rows.Count;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "You currently have no entries.  Get started now!";
                        dlEntryList.Visible = false;
                        btnUpdate.Visible = true;
                        btnCancel.Text = "Back to Menu";
                        btnUpdate.Text = "Add Coupon";
                    }

                    HidePaging();
                }

                lblCount.Text = "(" + listCount.ToString() + ")";

                // Populate the repeater control with the Items DataSet
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;
                objPds.AllowPaging = true;
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                    + objPds.PageCount.ToString();

                // Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;

                //bind to DataList control
                dlEntryList.DataSource = objPds;
                dlEntryList.DataBind();

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Manager:FillCouponMgr:Error:" + ex.Message);
                ShowError(" Error loading data ");
                classes.Email.SendErrorEmail("Manager:FillCouponMgr:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            //SetupView();
		}
		
        private void SetupView()
        {
            switch (hdnAdType.Value)
            {
                case "1":
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    break;
                case "4":
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    break;
                default:
                    break;

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
					return (int) o;
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
			FillCouponMgr();
		}

		public void cmdNext_Click(object sender, System.EventArgs e)
		{
             
            // Set viewstate variable to the next page
			CurrentPage += 1;

			// Reload control
			FillCouponMgr();
		}
		
/*
//Fired when user clicks the edit link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
 */ 
		public void GetValues(object src, CommandEventArgs e)
		{
			//Go to edit item page			
			Response.Redirect("Post.aspx?" + "q=" + e.CommandArgument.ToString());
        }

/*
 */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void UpdateToSold(object src, CommandEventArgs e)
        {
            //return;

            //Already confirmed so go ahead and update the entry status to sold
            string connStr, strSQL;

            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL statement
            strSQL = "UPDATE tblEntry SET iStatus = '3' WHERE id='" + e.CommandArgument + "'";
            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                FillCouponMgr();
            }
            catch
            {
                lblMessage.Text = "SQL Error!<br>";
            }
            finally
            {
                //close
                myConnection.Close();            
            }
        }

        /*
        //Fired when user clicks the Upgrade button.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
         */
        public void UpgradeEntry(object src, CommandEventArgs e)
        {
            //Set session for posting upgrade
            Session["ServiceId"] = "1";
            Session["TxnItemId"] = e.CommandArgument.ToString();
            ErrorLog.ErrorRoutine(false, "UpgradeId: " + Session["TxnItemId"].ToString());
            Response.Redirect("/Pay/OrderForm.aspx");
        }
        
/*
 */ 
		//Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
		public void DeleteEntry(object src, CommandEventArgs e)
		{
			//Already confirmed so go ahead and delete the entry
			string connStr, strSQL;

			connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			//3. Formulate SQL
			strSQL = "DELETE FROM tblEntry WHERE id='" + e.CommandArgument + "'";
			SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                FillCouponMgr();
            }

            catch
            {
                lblMessage.Text = "SQL Error!<br>";
            }

            finally
            {
                //close
                myConnection.Close();            
            }
		}

/**
 */         
        public void dlEntryList_OnItemDataBound(object sender,DataListItemEventArgs  e)
		{

            //ErrorLog.ErrorRoutine(false, "dlEntryList_OnItemDataBound");

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {
                //LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
                //if (lnkbtn != null)
                //{
                //    lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");
                
                //}

                LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                if (lnkbtn2 != null)
                {

                    //lnkbtn2.Attributes.Add("OnClick", "ChangeStatus()");
                    lnkbtn2.Attributes.Add("OnClick", "if(confirm('Are you sure you want to tag this item as sold?')==false){event.returnValue=false;return false;}else{return true;}");
  
                }

            }
		}
/**
 */
        public void dlEntryList_OnItemCreated(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                LinkButton lnkButton = (LinkButton)e.Item.FindControl("lnkBtnAddNew");
                if (lnkButton != null)
                {
                    lnkButton.Click += new EventHandler(ProcessClick);
                    lnkButton.Text = "[+ Add New]";
                }
            }

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {

                LinkButton lnkbtnView = (LinkButton)e.Item.FindControl("lnkBtnView");
                LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                ImageButton imgBtnBoost = (ImageButton)e.Item.FindControl("btnUpgrade");
                ImageButton imgBtnFB = (ImageButton)e.Item.FindControl("imgBtnFB");
                CheckBox chkBox = (CheckBox)e.Item.FindControl("chkPublish");
                //if (chkBox != null)
                //{
                //    chkBox.Visible = false;
                //}

                if (lnkbtn2 != null)
                {
                    //hide the SOLD button for SHAPERHOUSE
                    if (hdnAdType.Value == "4")
                    {
                        imgBtnBoost.Visible = false;
                        lnkbtn2.Visible = false;
                        imgBtnFB.Visible = true;
                        chkBox.Visible = true;
                        return;
                    }
                    if (lnkbtn2.Text == "SOLD") 
                    { 
                        lnkbtn2.Enabled = false;
                    }
                }
            }
        }
/*
 */
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }
/*
 */
        //private void ProcessClick(Object sender, CommandEventArgs e)
        private void ProcessClick(object sender, System.EventArgs e)
        {

            switch (hdnAdType.Value)
            {
                case "4":
                    Response.Redirect("post_item.aspx?q=4", true);
                    break;
                default:
                    Response.Redirect("post.aspx", true);
                    break;

            }

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
			Response.Redirect("post.aspx", true);
		}
/**
 */
        public void Activate(object src, CommandEventArgs e)
        {
            Session["ServiceId"] = "4";
            Session["TxnItemId"] = e.CommandArgument.ToString();
            Response.Redirect("../Pay/OrderForm.aspx", true);
        }
/**
 */
        public void ViewItem(object src, CommandEventArgs e)
        {
            switch (hdnAdType.Value)
            {
                case "4":
                    Response.Redirect("Shaper/ModelDetails.aspx?iD=" + e.CommandArgument , true);
                    break;
                default:
                    Response.Redirect("surfboard.aspx?iD=" + e.CommandArgument, true);
                    break;

            }

            Response.Redirect("post.aspx", true);

        }

/**
 */
        private void HidePaging()
        {
            cmdNext.Visible = false;
            cmdPrev.Visible = false;
            lblCurrentPage.Visible = false;

        }
        
/*
 */
        public string FormatPkgCnt(object cnt, object iStat)
        {
            if (iStat.ToString() == "1")
            {
                return cnt.ToString();
            }
            return "0";
        }

/*
 */
        public string GetStatus(object objStat)
        {
            if (objStat.ToString() == "3")
            {
                return "<font color='red'>SOLD<font>";
            }
            else
            {
                return "Sold it!";
            }
        }

/*
 */
        public bool GetPublishedStatus(object objStat)
        {
            if (objStat != null)
                if (objStat.ToString() == "1")
                    return true;

            return false;    //should never get here by objStat == null
        }
/*
 */
        public bool GetEnabledStatus(object objStat)
        {
            if (objStat != null)
                if (objStat.ToString() == "1")
                    return true;

            return false;    //should never get here by objStat == null
        }

/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, int iVal)
        {
            return Global.FormatDetails(oChunk, iVal);
        }

/*
 */
        public string FormatOCC(object oId)
        {
            if (oId != null)
            {
                if (hdnAdType.Value != "4")
                return "javascript:void(window.open('http://www.facebook.com/sharer.php?u=http://www.malzook.com/surfboard.aspx?iD=" + oId.ToString() + "&t=Boardhunt.com|Surfboards+For+Sale'))";
                else
                return "javascript:void(window.open('http://www.facebook.com/sharer.php?u=http://www.malzook.com/Shaper/ModelDetails.aspx?iD=" + oId.ToString() + "&t=Boardhunt.com|See my Model'))";
            //http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.boardhunt.com%2FShaper%2FModelDetails.aspx%3FiD%3D1132&t=Boardhunt.com%7CSurfboards+For+Sale
            }
            return string.Empty;
        }
/*
 */
        public bool GetEnabledUpgradeStatus(object oStat, object oServStat)
        {
            if (oStat != null)
                if (oStat.ToString() == "3")        //SOLD
                    return false;

            if (oServStat != null)
                if (oServStat.ToString() == "1")    //BOOSTED already
                    return false;

            return true;
         }
// BOOST if post is active and has not been boosted
        public string SetUpgradeButtonSrc(object oStat, object oServStat)
        {
            if (oStat != null)
                if (oStat.ToString() == "3")        //SOLD
                    return "../images/boost_off.gif";

            if (oServStat != null)
                if (oServStat.ToString() == "1")    //BOOSTED already
                    return "../images/boost_off.gif";

            return "../images/boost_on.gif";            
        }
/*
*/
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Add Coupon")
                Response.Redirect("post.aspx", true);

            try
            {
                classes.Coupon oQP = new classes.Coupon();

                if (dlEntryList.Items.Count > 0)
                {
                    foreach (DataListItem item in dlEntryList.Items)
                    {
                        CheckBox pubChkBox = item.FindControl("chkPublish") as CheckBox;
                        HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                        oQP.PublishUpdate(hdnVal.Value, pubChkBox.Checked);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error publishing model: " + ex.Message);
            }

            finally { }

            this.FillCouponMgr();
        }
/*
*/
        public void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserMenu.aspx", false);
        }
/*
 */ 
        void ShowError(string ErrorMessage)
        {
            lblMessage.Text = ErrorMessage;
            lblMessage.CssClass = "errorLabel";
            dlEntryList.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            cmdPrev.Visible = false;
            cmdNext.Visible = false;
        }

    }
}
