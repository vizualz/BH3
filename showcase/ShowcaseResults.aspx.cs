//Log:      


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

namespace BoardHunt.showcase
{
	/// <summary>
	/// Summary description for search_results.
	/// </summary>
	public partial class ShowcaseResults : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;

        //TODO: obsolete

        protected System.Web.UI.WebControls.ImageButton imgAdType;

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton LinkButton2;
        protected System.Web.UI.WebControls.LinkButton lnkTitle;

        protected System.Web.UI.WebControls.DropDownList cboLocation;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            

            lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            ItemsGet();
            if (!Page.IsPostBack)
            {
                //LoadFilter();
            }
            else
            {
                //string controlName = Request.Params.Get("__EVENTTARGET");
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
            string controlName;
		
			strDesc = "";
            
            //Create connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			//Build SQL statement
			//Get query strings
			
            //intCatType = Convert.ToInt32(Request.QueryString["iCat"]);  //category

            //strLocation = Request.QueryString["loc"].ToString();    //location


            //On postbacks:
            //if (Page.IsPostBack)
            //{
            //    controlName = Request.Params.Get("__EVENTTARGET");
            //    bool blnEntryItemClick = (controlName.IndexOf("dlEntryList") >= (int)0 ? true : false);
            //

            HypLoc.Text = "";


            lblCat.Text = "Showcase";//Global.up1(DecodeiCat(intCatType));



            strSQL = @"SELECT e.iD, e.dCreateDate, e.AdTitle, e.iCategory, e.iUser, e.txtBrand, e.txtDetails, e.txtGearItem, e.txtImgPath1, u.userDir
                        from tblEntry e 
                        inner join tblUser u
                        on e.iUser = u.id
                        and e.iUser in (select distinct id from tblUser where adtype = 3)";

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

            strSQL += " ORDER BY e.dCreateDate DESC";
            
            //Get handle to connection 
            SqlConnection myConnection = new SqlConnection(myConnectString);			

			//Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle and SQL statement
			SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblEntry");

                //Get result count for paging
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

			    //show paging
                ShowPaging();
                
                //hide lblNoResult
                lblNoResult.Text = "";
                lblNoResult.Visible = false;
                
                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
			    {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "There are no showcase items to display. <a href='#' onClick='history.back()'><u> Try again.</u></a>";
                        lblNoResult.Visible = true;
                        dlEntryList.Visible = false;
                        pnlFilter.Visible = false;
                    }
                    HidePaging();
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

			    // Disable Prev or Next buttons if necessary
			    cmdPrev.Enabled = !objPds.IsFirstPage;
			    cmdNext.Enabled = !objPds.IsLastPage;

			    //bind to DataList control
			    dlEntryList.DataSource = objPds;
			    dlEntryList.DataBind();
            }
            
            catch 
            {
                lblMessage.Text = "Error!";
                ErrorLog.ErrorRoutine(false,"Error: " + strSQL);
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
					return (int) o;
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
                if (adType.ToString() == "1")
                {
                    return "images/selling.gif";
                }
                else
                {
                    return "images/wanted.gif";
                }
            }

        }
/*
*/
        public string SetPicPath(object iCat, object oUser, object oImgPath)//, object uD)
        {
            //set to clear pic for default
            string retVal = "../images/s1x1.gif";
            string strImgPath;

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
                                retVal = "fish";
                                break;
                            case "4":
                                retVal = "funshape";
                                break;
                            case "5":
                                retVal = "gun";
                                break;
                            //case "6":
                            //    return "images/s1x1.gif";
                            //    break;
                            //case "24":
                            //    return "images/s1x1.gif";
                            //    break;
                            //case "27":
                            //    return "images/s1x1.gif";
                            //    break;
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
 */
        public string SetBoostPicPath(object uDir, object imgPath)
        {

            //set the default
            string retVal = "../images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
            }
            return retVal;
        }

/*
*/
        //Returns truncated string
        public string FormatDetails(object oChunk)
        {
            string txtChunk = oChunk.ToString();

            if (txtChunk.Length > 100)
            {
                int n = 100;

                //check if substring @ 100 pos. is char or whitespace
                if (txtChunk.Substring(100, 1).ToString() != " ")
                {
                    do
                    {
                        n++;
                        if (txtChunk.Substring(n, 1).ToString() == " ")
                        {
                            break;
                        }
                    } while (n <= txtChunk.Length);
                }

                //remove characters after 100.
                txtChunk = txtChunk.Remove(n, txtChunk.Length - n);
            }
            return txtChunk;
        }
        
        //TODO: find what this is all about?
		public void View_ItemDetail(object sender, DataListCommandEventArgs e)
		{
	
		}
		
		//Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
		public void GetValues(object src, CommandEventArgs e)
		{
            Response.Redirect("../showcase/ShowcaseDetails.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString());
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

        //Hide Paging Controls when results fall under max count
        private void ShowPaging()
        {
            cmdNext.Visible = true;
            cmdPrev.Visible = true;
            lblCurrentPage.Visible = true;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            ErrorLog.ErrorRoutine(false, "btnSearch_Click");
            
            //Set viewstate
            //cboLocationVal = cboLocation.SelectedIndex;
           
            //Reload filter again
            //LoadFilter();

            //User has chosen to filter results     
            ItemsGet();
            
            //Reset the paging
            CurrentPage = 0;
            
        }


/*
 *This is the search filter.  It truly doesn't filter the loaded data set due to the complexity of the paging control. 
 *The filter is always checked when the page is loaded.  Since it's blank for the first page load, the user will always get the
 *anticipated result.  When the any filter fields are changed followed by a search button click, the page does a postback reloading
 * the page which in turn checks in the modified filter.
 * TODO: Add panels for snow, other, and gear
 * */ 
        //private void LoadFilter()
        //{
            
            
        //    //declare variables	
        //    string strSQL;
        //    string myConnectString;
        //    string category;
            
        //    //category = Request.QueryString["iCat"].ToString();

        //    //Create connect string
        //    myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

        //    //3. Formulate SQL
        //    strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "' SELECT * FROM LK_FinType SELECT * FROM LK_Region ORDER BY Region";
        //    strSQL += " SELECT * FROM LK_TailType";
        //    SqlConnection myConnection = new SqlConnection(myConnectString);
        //    DataSet dsItems = new DataSet();
            
        //    //Create and add the (default) "All" entry
        //    //boardtype
        //    ListItem liAll = new ListItem();
        //    liAll.Text = "All";
        //    liAll.Value = "All";

        //    //fins
        //    ListItem liAllFin = new ListItem();
        //    liAllFin.Text = "All";
        //    liAllFin.Value = "All";

        //    //location
        //    ListItem liAllLoc = new ListItem();
        //    liAllLoc.Text = "All";
        //    liAllLoc.Value = "All";

        //    //tail
        //    ListItem liAllTail = new ListItem();
        //    liAllTail.Text = "All";
        //    liAllTail.Value = "All";

        //    try
        //    {

        //        SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

        //        objAdapter.TableMappings.Add("Table", "tblBoardType");
        //        objAdapter.TableMappings.Add("Table1", "tblFinType");
        //        objAdapter.TableMappings.Add("Table2", "tblRegion");
        //        objAdapter.TableMappings.Add("Table3", "tblTailType");

        //        objAdapter.Fill(dsItems);

        //        cboBoardType.Items.Clear();
        //        cboBoardType.DataSource = dsItems;
        //        cboBoardType.DataMember = "tblBoardType";
        //        cboBoardType.DataTextField = "BoardType";
        //        cboBoardType.DataValueField = "iD";
        //        cboBoardType.DataBind();
        //        cboBoardType.Items.Add(liAll);

        //        cboBoardType.ClearSelection();
        //        cboBoardType.SelectedIndex = cboVal;
 
        //        cboFins.Items.Clear();
        //        cboFins.DataSource = dsItems;
        //        cboFins.DataMember = "tblFinType";
        //        cboFins.DataTextField = "finType";
        //        cboFins.DataValueField = "iD";
        //        cboFins.DataBind();
        //        cboFins.Items.Add(liAllFin);

        //        cboFins.ClearSelection();
        //        cboFins.SelectedIndex = cboFinVal;

        //        //Location
        //        cboLocation.Items.Clear();
        //        cboLocation.DataSource = dsItems;
        //        cboLocation.DataMember = "tblRegion";
        //        cboLocation.DataTextField = "Region";
        //        cboLocation.DataValueField = "iD";
        //        cboLocation.DataBind();
        //        cboLocation.Items.Add(liAllLoc);

        //        cboLocation.ClearSelection();
        //        cboLocation.SelectedIndex = cboLocationVal;

        //        cboTailType.Items.Clear();
        //        cboTailType.DataSource = dsItems;
        //        cboTailType.DataMember = "tblTailType";
        //        cboTailType.DataTextField = "TailType";
        //        cboTailType.DataValueField = "iD";
        //        cboTailType.DataBind();
        //        cboTailType.Items.Add(liAllTail);

        //        cboTailType.ClearSelection();
        //        cboTailType.SelectedIndex = cboTailTypeVal;

        //        if (!Page.IsPostBack)
        //        {
        //            SyncFilter();
        //        }
        //    }
        //    catch 
        //    {
        //        lblMessage.Text = "Filter Error:";
        //    }
        //    finally
        //    {
        //        myConnection.Close();          
        //    }

        //}


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
            return Global.ReplaceEx(Enum.GetName(typeof(Global.BOARDCAT_TYPE), iCat),"_"," ");
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
	}
}
