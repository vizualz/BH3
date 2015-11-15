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

namespace BoardHunt
{
	/// <summary>
	/// Summary description for search_results.
	/// </summary>
	public partial class post_manager : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton linkEdit; 
        protected System.Web.UI.WebControls.HiddenField hdnCat;
        protected System.Web.UI.WebControls.CheckBox chkPublish;
		//protected System.Web.UI.WebControls.Button btnDelete;
        //protected System.Web.UI.WebControls.LinkButton lnkBtnView;
		protected System.Web.UI.WebControls.LinkButton lnkBtnAddNew;

		protected void Page_Load(object sender, System.EventArgs e)
		{

            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser(Request.Url.ToString());
				/*
				LinkButton lnkButton = (LinkButton)e.Item.FindControl("lnkBtnAddNew");
				if (lnkButton != null)
				{
					lnkButton.Click += new EventHandler(ProcessClick);

					switch (hdnAdType.Value)
					{
					case "1":
						lnkButton.Text = "[+ New]";
						break;
					case "4":
						lnkButton.Text = "[+ New]";
						break;
					default:
						break;

					}
				}
				*/
            }
				

            // Call the ItemsGet method to populate controls
            ItemsGet();
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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //this.lnkBtnView.Click += new System.EventHandler(this.lnkBtnView_Click);
            this.lnkBtnAddNew.Click += new System.EventHandler(this.lnkBtnAddNew_Click);

		}
		#endregion

		private void ItemsGet()
		{
			//declare variables	
			string strSQL;
			string myConnectString;
		
			//Create connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            SqlConnection myConnection = new SqlConnection(myConnectString);

            string[] arString;
            arString = Request.QueryString.GetValues("q");
            if (arString != null)
            {
                hdnAdType.Value = HttpUtility.UrlDecode(arString[0].ToString());
                arString[0] = string.Empty;
            }
            else
            {
                //default to reg_user
                hdnAdType.Value = "1";
            }

            if (hdnAdType.Value == "4")
            {
                btnCancel.Visible = true;
                btnUpdate.Visible = true;            
            }

            try
            {
                //Formulate SQL
                strSQL = "SELECT e.iD, e.dCreateDate, e.iHtFt, e.iHtIn, e.iCategory, e.txtBrand, e.txtOtherBoardType, e.txtGearItem, e.txtModel, e.fltPrice, e.txtPrice, e.iStatus, e.adType, e.iBoosted";
                strSQL += " FROM tblEntry e";
                strSQL += " WHERE e.iUser = '" + Session["userId"].ToString() + "'";
                strSQL += " AND e.adType = " + hdnAdType.Value;
                strSQL += " ORDER BY e.dCreateDate DESC";

                // Read sample item info from SQL into a DataSet
                DataSet dsItems = new DataSet();

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.Fill(dsItems, "tblEntry");
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "You currently have no entries.";
                        dlEntryList.Visible = false;
                        btnUpdate.Visible = false;
                        btnCancel.Text = "Back to Menu";
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
                ErrorLog.ErrorRoutine(false, "Error:PageManager:ItemsGet(): " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            SetupView();
		}
		
        private void SetupView()
        {
            switch (hdnAdType.Value)
            {
                case "1":
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    lnkBtnAddNew.Text = "+ Board";
                    break;
                case "4":
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    lnkBtnAddNew.Text = "+ Model";
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
				return "images/s1x1.gif";
			}
			else 
			{
				return "images/camera.gif";
			}
			
		}

/*
//Fired when user clicks the edit link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
 */ 
		public void GetValues(object src, CommandEventArgs e)
		{
			//Go to edit item page			
			Response.Redirect("edit_item.aspx?" + "iD=" + e.CommandArgument.ToString());
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
                ItemsGet();
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
                ItemsGet();
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

			/*
			if (e.Item.ItemType == ListItemType.Header)
            {
                LinkButton lnkButton = (LinkButton)e.Item.FindControl("lnkBtnAddNew");
                if (lnkButton != null)
                {
                    lnkButton.Click += new EventHandler(ProcessClick);

                    switch (hdnAdType.Value)
                    {
                        case "1":
                            lnkButton.Text = "[+ Board]";
                            break;
                        case "4":
                            lnkButton.Text = "[+ Model]";
                            break;
                        default:
                            break;

                    }
                }
            }*/

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {


                LinkButton lnkbtnView = (LinkButton)e.Item.FindControl("lnkBtnView");
                LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                ImageButton imgBtnBoost = (ImageButton)e.Item.FindControl("btnUpgrade");
                //ImageButton imgBtnFB = (ImageButton)e.Item.FindControl("imgBtnFB");
                CheckBox chkBox = (CheckBox)e.Item.FindControl("chkPublish");
                if (chkBox != null)
                {
                    chkBox.Visible = false;
                }

                if (lnkbtn2 != null)
                {
                    //hide the SOLD button for SHAPERHOUSE
                    if (hdnAdType.Value == "4")
                    {
                        imgBtnBoost.Visible = false;
                        lnkbtn2.Visible = false;
                        //imgBtnFB.Visible = true;
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
        public string FormatPrice(object typeAd, object fPrice, object sPrice)
        {
            if (typeAd != null)
            {

                if (typeAd.ToString() == "4")
                {
                    //return string if it's not null; otherwise return flt if it's not null
                    if (sPrice != DBNull.Value)
                    {
                        float sfPrice = 0;
                        bool bVal = float.TryParse(sPrice.ToString(), out sfPrice);
                        if (bVal)
                            return Global.FormatPrice(fPrice);
                        else
                            return sPrice.ToString();
                    }
                    else
                    {
                        if (fPrice != DBNull.Value)
                            return Global.FormatPrice(fPrice);
                    }
                    return "unknown";
                }
                else
                    return Global.FormatPrice(fPrice);
            }
            else
                return "unknown";
        }

/*
*/
        public string FormatHeightFt(object heightFt, object iCat)
        {
            if (heightFt == null || heightFt.ToString() == string.Empty)
                return string.Empty;
            
            string ht = heightFt.ToString();

            switch (iCat.ToString())
            {
                case "1":
                    ht = ht + "\'";
                    break;
                case "2":
                    ht = ht + " cm" + "&nbsp;";
                    break;
                case "3":
                    ht = string.Empty;
                    break;
                case "4":
                    ht = string.Empty;
                    break;
                default:
                    ht = string.Empty;
                    break;
            }

            return ht;
        }
/*
 */ 
        public string FormatHeightIn(object heightIn, object iCat)
        {
            if (heightIn == null || heightIn.ToString() == string.Empty)
                return string.Empty;

            string inch = heightIn.ToString();

            switch (iCat.ToString())
            {
                case "1":
                    inch = inch + "\"" + "&nbsp;";
                    break;
                case "2":
                    inch = string.Empty;
                    break;
                case "3":
                    inch = string.Empty;
                    break;
                case "4":
                    inch = string.Empty;
                    break;
                default:
                    inch = string.Empty;
                    break;
            }

            return inch;
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
        public bool GetEnabledStatus(object objStat)
        {
            if (objStat != null)
                if (objStat.ToString() == "3")
                    return false;
            
            return true;    //should never get here by objStat == null
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
        public bool GetPublishedStatus(object oStat)
        {
            if (oStat != null)
            {
                switch (oStat.ToString())
                    {
                    case "4":
                        return false;
                        break;
                    case "5":
                        return true;
                        break;
                    default:
                        return false;
                        break;
                    }
            }
            return true;
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
            try
            {
                classes.BoardItem oBoard = new classes.BoardItem();

                if (dlEntryList.Items.Count > 0)
                {
                    foreach (DataListItem item in dlEntryList.Items)
                    {
                        CheckBox pubCheckBox = item.FindControl("chkPublish") as CheckBox;
                        HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                        //find the id and publish it
                        oBoard.PublishBoard(hdnVal.Value, pubCheckBox.Checked);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error publishing model: " + ex.Message);
            }

            finally { }

            this.ItemsGet();
        }
/*
*/
        public void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenu.aspx", false);
        }

		public void lnkBtnAddNew_Click(Object sender, EventArgs e) 
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

    }
}
