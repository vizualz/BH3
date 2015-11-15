using System;
using System.Configuration;
using System.Collections;
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

namespace BoardHunt
{
	public partial class Surfboardsforsale : System.Web.UI.Page
	{
		PagedDataSource pagedData = new PagedDataSource();
		int CurPage = 1;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image imgCameraPic;

		protected System.Web.UI.WebControls.TextBox txtLoCurrentPage;
		protected System.Web.UI.WebControls.TextBox txtHiCurrentPage;

		protected System.Web.UI.WebControls.ImageButton imgAdType;
		protected System.Web.UI.WebControls.ImageButton imgPreview;

		protected System.Web.UI.WebControls.Panel pnlPrevew;
		protected System.Web.UI.WebControls.Panel lblPrevew;
		protected System.Web.UI.WebControls.Panel pnlPageTop;
		protected System.Web.UI.WebControls.Panel pnlPageBtm;

		protected System.Web.UI.WebControls.LinkButton lnkBtnImg;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected System.Web.UI.WebControls.LinkButton lnkBtnPrice;
		protected System.Web.UI.WebControls.LinkButton lnkBtnTown;
		protected System.Web.UI.WebControls.LinkButton lnkUpgradeAcct;
		protected System.Web.UI.WebControls.Label lblPage1;
		protected System.Web.UI.WebControls.Label lblPage2;
		protected System.Web.UI.UpdatePanel UpdatePanel1;
		protected System.Web.UI.UpdatePanel UpdatePanel2;
		protected System.Web.UI.UpdatePanel UpdatePanel3;

		//protected global::System.Web.UI.WebControls.DataList dlEntryList;


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

			if (ScriptManager.GetCurrent (this).IsInAsyncPostBack || Page.IsPostBack) {
				//ErrorLog.ErrorRoutine (false, "SFS2: Page_Load: Ajax Kickout");
				return;
			}

			lblNoResult.Text = string.Empty;
			lblNoResult.Visible = false;

			if (!Page.IsPostBack)
			{

				LoadFilter();
				LoadViewCtl();
				GetSetQueryStrings();
				ItemsGet(false);
				SyncFilter();
			}
			else
			{
				//				string controlName = Request.Params.Get("__EVENTTARGET");
				//
				//				switch (controlName)
				//				{
				//				case "pageLnkButton":
				//					string val = Request.Params.Get("__EVENTARGUMENT");
				//					CurrentPage = Convert.ToInt32(val);
				//					ItemsGet(false);
				//					break;
				//				case "btnSearch":
				//					CurrentPage = 0;
				//					break;
				//				case "cboView":
				//					//cboViewVal = cboView.SelectedValue;
				//					//break;
				//				default:
				//					break;
				//				}
			}

			HeaderInit();
			txtHiCurrentPage.ReadOnly = txtLoCurrentPage.ReadOnly = true;
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

			this.cmdPrev.Click  += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
			this.topcmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
			this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
			this.topcmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
			//this.lnkUpgradeAcct.Click += new System.EventHandler(this.lnkUpgradeAcct_Click);

		}
		#endregion

		public void HeaderInit()
		{
			if (Session["LoggedIn"].ToString() == "Yes")
			{
				hdnSash.Value = "0";

				if (Session["isPro"].ToString() == "1")
				{
					//lnkUpgradeAcct.Visible = false;
					hdnSash.Value = "1";
				}
				else
					lnkUpgradeAcct.Visible = true;

			}
			else
			{
				//lnkUpgradeAcct.Visible = false;
				hdnSash.Value = "0";
			}


		}

		private void ItemsGet(bool bln)
		{
			ErrorLog.ErrorRoutine (false, "ItemsGet-Start: DLCount: " + dlEntryList.Items.Count + " fromBtnSearch: " + bln + " isAscyncPB: " + ScriptManager.GetCurrent(this).IsInAsyncPostBack);

			string strSQL;
			string strBoardType;

			strBoardType = string.Empty;

			//TODO: handle all or empty
			if (cboBoardVal != "All")
				strBoardType = BuildQryBoardType(cboBoardVal);

			//LOCATION: Display Only
			//if (cboLocationVal.ToString() != "all" || cboLocationVal.ToString() != "All" || cboLocationVal.ToString() != string.Empty)
			if (cboLocationVal.ToLower() != "all" && cboLocationVal.ToString() != string.Empty)
			{
				HypLoc.Text = Global.SwapChar(DecodeRegion(Convert.ToInt32(cboLocationVal)), " ", "_");
			}
			else
			{
				HypLoc.Text = "Home";
			}

			//build SQL
			if (hdniCat.Value != "4")
			{
				strSQL = "SELECT bt.iValue, * FROM tblEntry e";

				//JOIN stuff here; omit showcase(3)
				strSQL += @" INNER JOIN tblUser u
                                        ON e.iUser = u.id
                                        AND e.iUser IN (SELECT DISTINCT id FROM tblUser WHERE adtype < 3)";

				strSQL += @" INNER JOIN LK_BoardType bt
                            ON bt.iD = e.iBoardType";
			}
			else
			{
				strSQL = "SELECT NULL as iValue,* FROM tblEntry e";

				//JOIN stuff here; omit showcase(3)
				strSQL += @" INNER JOIN tblUser u
                                    ON e.iUser = u.id
                                    AND e.iUser IN (SELECT DISTINCT id FROM tblUser WHERE adtype < 3)";
			}

			strSQL += @" WHERE ";

			//USER
			if (cboUserIdVal != String.Empty)
				strSQL += " e.iUser ='" + cboUserIdVal + "'" + " AND ";

			//LOCATION
			if (cboLocationVal != "All" && cboLocationVal != "all")
				strSQL += " e.Location = '" + cboLocationVal + "'" + " AND";

			//CATEGORY
			strSQL += " e.iCategory = '" + hdniCat.Value + "'";

			//ADTYPE:filter
			/*
			if (cboAdTypeVal != "All")
			{
				strSQL += " AND e.adType = '" + cboAdTypeVal + "'";
			}
			else
			{
				strSQL += " AND e.adType < 3 ";
			}
			*/

			//BOARD CONDITION:filter
			if (cboCondition.SelectedValue != "All" && cboCondition.SelectedIndex >= (int)0)
			{
				strSQL += " AND e.iCondition = '" + cboCondition.SelectedValue + "'";
			}

			if (chkReduced.Checked)
				strSQL += " AND e.iPriceChange = 1 ";

			//HIDE SOLD BOARDS: 3 = marked sold by user. 4 = Forced SOLD by BH
			//TODO: UPDATE tblEntry SET iStatus = 4 WHERE dCreateDate <  '2009-01-01' AND iStatus <> 3
			strSQL += " AND e.iStatus = 1 "; //(e.iStatus IS NULL OR e.iStatus <> 3) "; // ";//(e.iStatus <> 3 OR e.iStatus <> 6)) "; // active == 1

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


			//fix filter for empty boxes
			if (txtMinPrice.Text.Length == (int)0) { txtMinPrice.Text = "$Min"; }
			if (!IsNumeric(txtMinPrice.Text)) { txtMinPrice.Text = "$Min"; }

			if (txtMaxPrice.Text.Length == (int)0) { txtMaxPrice.Text = "$Max"; }
			if (!IsNumeric(txtMaxPrice.Text)) { txtMaxPrice.Text = "$Max"; }

			//check filter for price
			if (txtMinPrice.Text != "$Min")
			{
				strSQL += " AND e.fltPrice >= '" + Convert.ToDouble(txtMinPrice.Text) + "'";
			}

			if (txtMaxPrice.Text != "$Max")
			{
				strSQL += " AND e.fltPrice <= '" + Convert.ToDouble(txtMaxPrice.Text) + "'";
			}

			if (cboKeywordsVal.Length > 1)
			{
				strSQL += " AND (e.txtBrand LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
				strSQL += " OR e.txtTown LIKE '%" + Global.CheckString(cboKeywordsVal) + "%'";
				strSQL += " OR e.txtDetails LIKE '%" + Global.CheckString(cboKeywordsVal) + "%' ";
				strSQL += " OR e.txtShaper LIKE '%" + Global.CheckString(cboKeywordsVal) + "%') ";
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
				strSQL += " AND (e.iHtFt = '" + txtHtFt.Text + "'";

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
				strSQL += " )";
			}

			//Set descending order by date
			strSQL += " ORDER BY e.dCreateDate DESC";

			//ErrorLog.ErrorRoutine(false, "SFS2:ItemsGet:strSQL: " + strSQL);

			IDBManager dbManager = new DBManager(DataProvider.SqlServer);
			dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

			//Declare Dataset
			DataSet dsItems = new DataSet();

			try
			{
				dbManager.Open();
				dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

				//Get result count for paging
				int listCount = dsItems.Tables[0].Rows.Count;

				//check for display count

				ErrorLog.ErrorRoutine(false, "SFS2:ItemsGet:strSQL: backFromQuery ");

				//Do we need to display the back and forward controls? TODO: should this be 50???
				if (listCount <= 50)
				{
					//If search yields no results, set message
					if (listCount == (int)0)
					{
						lblCount.Text = "No boards found. <br/><br/>Search again with the filter on the left.";

						//lblPage1.Visible = false;
						//lblPage2.Visible = false;

						lblNoResult.Visible = true;
						dlEntryList.Visible = false;


						//hide paging
						cmdNext.Visible = false;
						topcmdNext.Visible = false;
						cmdPrev.Visible = false;
						topcmdPrev.Visible = false; 
						lblcpage.Visible = false;
						toplblcpage.Visible = false;

						//hide paging panels
						pnlPageTop.Visible = false;
						pnlPageBtm.Visible = false;
						return;
					}

					cmdNext.Visible = false;
					topcmdNext.Visible = false;
					cmdPrev.Visible = false;
					topcmdPrev.Visible = false; 

					lblcpage.Visible = false;
					toplblcpage.Visible = false;

				}
				else
				{
					//show paging
					cmdNext.Visible = true;
					topcmdNext.Visible = true; 
					cmdPrev.Visible = true;
					topcmdPrev.Visible = true;
					lblcpage.Visible = true;
					toplblcpage.Visible = true; 
				}

				lblCount.Text = "(" + listCount.ToString() + ") " + "Surfboards";

				//Build Paging for control with PageDataSource.  Get the default view
				//from the DataSource and assign it to the PageDataSource.
				PagedDataSource objPds = new PagedDataSource();
				objPds.DataSource = dsItems.Tables[0].DefaultView;
				objPds.AllowPaging = true;
				//if (cboViewVal == "-1")
				//{
				//    //objPds.PageSize = 1;
				//    objPds.AllowPaging = false;
				//}
				//else
				//{


				objPds.PageSize = Convert.ToInt32(cboViewVal);
				objPds.CurrentPageIndex = CurrentPage;
				//}

				txtLoCurrentPage.Text = (CurrentPage + 1).ToString();
				txtHiCurrentPage.Text = (CurrentPage + 1).ToString();

				ErrorLog.ErrorRoutine(false, "IG: CurrentPage: " + CurrentPage);
				ErrorLog.ErrorRoutine (false, "IG: CurrentPage: txtHiCurrentPage:" + txtHiCurrentPage.Text);

				//Omit if originated from the textbox paging change
				if(!bln)
				{
					////akshat
					toplblcpage.Text = " of " + objPds.PageCount.ToString();
					lblcpage.Text = " of " + objPds.PageCount.ToString();

				}

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
				ErrorLog.ErrorRoutine(false, "SFS2:ItemGet():Error Msg: " + ex.Message);
				ErrorLog.ErrorRoutine(false, "Error: " + strSQL);
				lblMessage.Text = "Error!";
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}

			//record keyword search term
			if (cboKeywordsVal.Length > 1)
				RecordKeywords();

			ErrorLog.ErrorRoutine (false, "SFS2:ItemsGet END: DLCountEnd: " + dlEntryList.Items.Count);

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
		public string cboViewVal
		{
			get
			{
				// look for current page in ViewState
				object o = this.ViewState["_cboViewVal"];
				if (o == null)
					return ("50");   // default to showing "all"
				else
					return o.ToString();
			}

			set
			{
				this.ViewState["_cboViewVal"] = value;
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
		 */

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
			string retVal = "images/s1x1.gif";

			if (adType == DBNull.Value || adType.ToString() == "")
			{
				retVal = "images/s1x1.gif";
			}
			else
			{
				switch (adType.ToString())
				{
				case "2":
					retVal = "images/wanted.gif";
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
		public string SetPricePic(object iPCVal)
		{
			if (iPCVal != null)
			if (iPCVal.ToString() == "1")
				return "images/bump.gif";
			return "images/s1x1.gif";
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
					case "32":
						retVal = "images/hybrid.gif";
						break;
					case "64":
						retVal = "images/standup.gif";
						break;
					case "128":
						retVal = "images/pro.gif";
						break;
					case "256":
						retVal = "images/vintage.gif";
						break;
					case "512":
						retVal = "images/otherboard.gif";
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
		public string GetTip(object iPC)
		{
			if (iPC != null)
			if (iPC.ToString() == "1")
				return "Update|This board's price was reduced";
			else
				return "dd";

			return string.Empty;
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
					case "256":
						retVal = "vintage";
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
			lblCat.Text = "All " + Global.up1(DecodeiCat(Convert.ToInt32(hdniCat.Value)));

			//VIEWCOUNT:cboViewVal          50 is the default
			arString = Request.QueryString.GetValues("v");
			if (arString != null)
			{
				if (HttpUtility.UrlDecode(arString[0].ToString()) == "All")
					cboViewVal = "-1";
				else
				{
					cboViewVal = HttpUtility.UrlDecode(arString[0].ToString());
				}
				arString[0] = string.Empty; //clear array 
			}
			else
			{
				cboViewVal = "50";
			}

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
		public string FormatBrand(object oBrand, object oMfr)
		{

			if (oBrand == null || oBrand == DBNull.Value || oBrand.ToString().Length < 1)
				return string.Empty;


			string retVal;
			string strBrand = oBrand.ToString();
			retVal = char.ToUpper(strBrand[0]) + strBrand.Substring(1);

			//if (oMfr != null)
			//    if (oMfr.ToString().Length > 0)
			//        if (retVal != oMfr.ToString())
			//            retVal += "&nbsp;" +  oMfr.ToString();

			return retVal;

		}

		/*
         */
		//Returns truncated string with configurable number of characters
		public string FormatDetails(object oChunk, object oVal)
		{
			if (oChunk.ToString().Length < 1)
				return string.Empty;

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
				ht += "\'";
				break;
			case 2:
				ht += " cm" + "&nbsp;";
				break;
			case 3:
				ht = "";
				break;
			case 4:
				ht = "";
				break;
			default:
				ht += "\'";
				break;
			}

			return ht;
		}
		/*
         */
		public string FormatLoc(object Loc)
		{
			if (Loc.ToString().Length > 0)
			{
				string pl = Loc.ToString ();
				int idx = pl.IndexOf(", United States");
				if (idx > 0)
					pl = pl.Substring(0, idx);
				return pl;
			}
			return Loc.ToString ();
		}

		/*
         */
		public string FormatHeightIn(object heightIn)
		{

			string inch = heightIn.ToString();

			switch (Convert.ToInt32(Request.QueryString["iCat"]))
			{
			case 1:
				inch += "\"" + "&nbsp;";
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
			default:
				inch += "\"" + "&nbsp;";
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
				retVal = "images/nopicyet.gif";
				return retVal;
			}
			else
			{
				string strServerURL;

				strImgPath = Global.ReplaceEx(oImgPath.ToString(), @"\", @"/");
				//strImgPath = "thmbNail_" + strImgPath;


				hdnServer.Value = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
				strServerURL = hdnServer.Value;
				//retVal = strServerURL + "/users/" + iId + iCat.ToString() + "/" + Path.GetFileName(strImgPath);

				retVal = strServerURL + "/users/" + Global.ReplaceEx(oUser.ToString(), @"\", @"/") + Global.DecodeCategory(iCat) + "/" + Path.GetFileName(strImgPath);

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
			Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString());//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
		}


		private void cmdPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// Decrement page, relaod page and update the panel
			CurrentPage -= 1;

			ItemsGet(false);

			UpdatePanel1.Update ();

		}


		private void cmdNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ErrorLog.ErrorRoutine(false, "SFS2:cmdNext_Click:Start");

			// Set viewstate variable to the next page
			CurrentPage += 1;

			// Reload control
			ItemsGet(false);

			UpdatePanel1.Update ();
			ErrorLog.ErrorRoutine(false, "SFS2:cmdNext_Click:End");

		}

		//Hide Paging Controls when results fall under max count
		private void HidePaging()
		{
			ErrorLog.ErrorRoutine(false, "SFS2:HidePaging");

			cmdNext.Visible = false;
			topcmdNext.Visible = false;
			cmdPrev.Visible = false;
			topcmdPrev.Visible = false; 

			lblcpage.Visible = false;
			toplblcpage.Visible = false;


		}
		/*
         */
		//Hide Paging Controls when results fall under max count
		private void ShowPaging()
		{
			cmdNext.Visible = true;
			topcmdNext.Visible = true; 
			cmdPrev.Visible = true;
			topcmdPrev.Visible = true;
			lblcpage.Visible = true;
			toplblcpage.Visible = true; 

		}

		protected void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			ErrorLog.ErrorRoutine (false, "cboFilter_SelectedIndexChanged");
			GoAjaxFilter ();

		}

		protected void Check_Clicked(object sender, EventArgs e)
		{
			GoAjaxFilter ();

		}

		protected void txtPrice_TextChanged(object sender, EventArgs e)
		{
			ErrorLog.ErrorRoutine (false, "txtMaxPrice_TextChanged");
			GoAjaxFilter ();

		}

		protected void GoAjaxFilter()
		{
			ErrorLog.ErrorRoutine (false, "GoAxaj");

			//Set new values to viewstate
			if (txtFilterKwd.Text.Length > 1)
				cboKeywordsVal = txtFilterKwd.Text;
			else
				cboKeywordsVal = string.Empty;

			//get location
			cboLocationVal = cboLocation.SelectedValue.ToString();


			//cboAdTypeVal = cboAdType.SelectedValue.ToString();
			cboPostingTypeVal = cboPostingType.SelectedValue.ToString();
			cboConditionVal = cboCondition.SelectedValue.ToString();
			if (hdniCat.Value == "1")
			{
				cboBoardVal = cboBoardType.SelectedValue.ToString();
				cboFinVal = cboFins.SelectedValue.ToString();
				cboTailTypeVal = cboTailType.SelectedValue.ToString();
			}

			dlEntryList.DataSource = null;
			dlEntryList.DataBind();

			//Reset the paging
			CurrentPage = 0;

			//User has chosen to filter results     
			ItemsGet(false);

			//UpdatePanel2.Update();
			UpdatePanel3.Update();

		}

		/*
 */
		protected void btnSearch2_Click(object sender, EventArgs e)
		{
			ErrorLog.ErrorRoutine (false, "btnSearch2_Click");
		}
		/*
 */
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			//TODO: assign per category

			ErrorLog.ErrorRoutine (false, "btnSearch_Click");

			//Set new values to viewstate
			if (txtFilterKwd.Text.Length > 1)
				cboKeywordsVal = txtFilterKwd.Text;
			else
				cboKeywordsVal = string.Empty;

			//get location
			cboLocationVal = cboLocation.SelectedValue.ToString();


			//cboAdTypeVal = cboAdType.SelectedValue.ToString();
			cboPostingTypeVal = cboPostingType.SelectedValue.ToString();
			cboConditionVal = cboCondition.SelectedValue.ToString();
			if (hdniCat.Value == "1")
			{
				cboBoardVal = cboBoardType.SelectedValue.ToString();
				cboFinVal = cboFins.SelectedValue.ToString();
				cboTailTypeVal = cboTailType.SelectedValue.ToString();
			}

			dlEntryList.DataSource = null;
			dlEntryList.DataBind();

			//Reset the paging
			CurrentPage = 0;

			//User has chosen to filter results     
			ItemsGet(false);
		}

		private void LoadViewCtl()
		{
			return;

			//TODO: remove hardcodings and calculate
			//cboView.Items.Clear();
			//ListItem liViewAll = new ListItem("All", "-1");  //view all on 1 page
			//ListItem liView50 = new ListItem("50", "50");
			//ListItem liView15 = new ListItem("15", "15");
			//cboView.Items.Add(liView15);
			//cboView.Items.Add(liView50);
			//cboView.Items.Add(liViewAll);
		}

		/*
         * Here we just load and set everything to the default values.
         * NOTE: When any filter fields are changed followed by a search button click, 
         * the new vaules are set and the page will requery.
         * TODO: Add panels for snow, other, and gear
         * */
		private void LoadFilter()
		{
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
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;


			// build SQL
			strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "' ORDER BY iValue SELECT * FROM LK_FinType SELECT * FROM LK_Region ORDER BY Description DESC";
			strSQL += " SELECT * FROM LK_TailType SELECT iD,adType from LK_AdType SELECT iD,condition FROM LK_Condition";
			SqlConnection myConnection = new SqlConnection(myConnectString);
			DataSet dsItems = new DataSet();

			//Create and add the (default) "All" entry
			//boardtype
			ListItem liAllBT = new ListItem( "Boards", "All");  //boardtype
			ListItem liAllFin = new ListItem("Fins", "All");  //fins
			ListItem liAllLoc = new ListItem("Region", "All"); //loc
			ListItem liAllTail = new ListItem("Tail", "All"); //tail
			//ListItem liAllType = new ListItem("All", "All"); //ad type
			ListItem liAllCondType = new ListItem("Cond", "All"); //condition

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

				/*
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
				cboAdType.Items.RemoveAt(2);
				cboAdType.ClearSelection();
				cboAdType.SelectedIndex = cboAdType.Items.Count - 1;
				//cboAdType.SelectedIndex = cboAdTypeVal;
				*/

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
			}
			finally
			{
				myConnection.Close();
			}

			cboCondition.Visible = true;
			cboFins.Visible = true;
			cboTailType.Visible = true;
			cboAdType.Visible = false;
			cboPostingType.Visible = true;
			chkReduced.Visible = true;

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

			//cboAdType.ClearSelection();
			//cboAdType.Items.FindByValue(cboAdTypeVal).Selected = true;


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
		private void RecordKeywords()
		{
			classes.util.RecordData(cboKeywordsVal, "Surfboardsforsale");
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
				strBType += " e.iBoardType = 29";
			if ((BitMask_6 & intBoardType) > 0)
				strBType += " e.iBoardType = 24";
			if ((BitMask_7 & intBoardType) > 0)
				strBType += " e.iBoardType = 27";
			if ((BitMask_8 & intBoardType) > 0)
				strBType += " e.iBoardType = 28";
			if ((BitMask_9 & intBoardType) > 0)
				strBType += " e.iBoardType = 6";

			return strBType;
		}

		protected void btnUpdates_Click(object sender, EventArgs e)
		{
			Response.Redirect("http://www.twitter.com/boardhunt", true);
		}



		protected void OnPaging_TextChange(object sender, EventArgs e)
		{

			//Kickout if not triggered by a text change
			if (Convert.ToInt32(txtHiCurrentPage.Text) - 1 == CurrentPage) {
				ErrorLog.ErrorRoutine (false, "Kickout");
				return;
			}

			ErrorLog.ErrorRoutine (false, "OnPaging_TextChange: CurrentPage:" + CurrentPage);
			ErrorLog.ErrorRoutine (false, "OnPaging_TextChange: txtHiCurrentPage:" + txtHiCurrentPage.Text);
			ErrorLog.ErrorRoutine (false, "OnPaging_TextChange: txtLoCurrentPage:" + txtLoCurrentPage.Text);


			//// Set viewstate variable to the next page
			//CurrentPage = Convert.ToInt32(txtLoCurrentPage.Text) - 1;	//0 base offset consideration
			//txtHiCurrentPage.Text = txtLoCurrentPage.Text;				//set top and bottom boxes equal

			// Reload control
			ItemsGet (true);



		}


		public DataTable getTheData()
		{
			string strSQL;
			// TODO NOW Fix this query.
			strSQL = @"SELECT  e.txtImgPath1, e.iD, e.iHtFt, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
                        FROM tblServices s
                        INNER JOIN tblEntry e on s.iEntryId = e.iD
                        INNER JOIN tblUser u on u.id = e.iUser
                        WHERE e.iBoosted = 1
                        AND (e.iStatus <> 3
                        OR e.iStatus is NULL)
                        ORDER BY NEWID()";

			DataSet DS = new DataSet();
			SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);

			SqlDataAdapter objSQLAdapter = new SqlDataAdapter(strSQL, myConnection); objSQLAdapter.Fill(DS, "Customers");


			return DS.Tables[0];

		}

		//void doPaging()
		//{

		//    pagedData.DataSource = getTheData().DefaultView;

		//    pagedData.AllowPaging = true;
		//    pagedData.PageSize = 5;



		//    try
		//    {
		//        if (Request["Page"].ToString() != null)
		//        {
		//            CurPage = Int32.Parse(Request["Page"].ToString());
		//        }
		//        else
		//        {
		//            CurPage = 1;
		//        }

		//        pagedData.CurrentPageIndex = CurPage - 1;

		//    }

		//    catch

		//    (Exception ex)
		//    {

		//        pagedData.CurrentPageIndex = 0;

		//    }

		//    btnPrev.Enabled = (!pagedData.IsFirstPage);
		//    //btnPrev.Visible = (!pagedData.IsFirstPage);

		//    btnNext.Enabled = (!pagedData.IsLastPage);
		//    //btnNext.Visible = (!pagedData.IsLastPage);


		//    //pagedData.CurrentPageIndex = CurPage - 1;

		//    //lblCurrentPage.Text = "Page: " + CurPage.ToString() + " of " + pagedData.PageCount.ToString(); ;

		//    dlUpgrades.DataSource = pagedData;
		//    dlUpgrades.DataBind();

		//}



		//public string SetBoostPicPath(object uDir, object imgPath)
		//{
		//    if (imgPath == string.Empty)
		//        return "images/s1x1.gif";

		//    //set the default"images/s1x1.gif"
		//    string retVal = "images/s1x1.gif";
		//    if (uDir != null && imgPath != null)
		//    {
		//        retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" + Global.ReplaceEx(uDir.ToString(), @"\", @"/") + "surfboards/" + "thmbNail_" + imgPath;
		//    }
		//    return retVal;
		//}

		///*
		//*/
		////Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
		//public void ShowItem(object src, CommandEventArgs e)
		//{
		//    Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/surfboard.aspx?" + "iD=" + e.CommandArgument.ToString());
		//}

		//protected  void btnPrev_Click(object sender, ImageClickEventArgs e)
		//{
		//    Response.Redirect(Request.CurrentExecutionFilePath + "?Page=" + (CurPage - 1));
		//}

		//protected void btnNext_Click(object src, ImageClickEventArgs e)
		//{
		//    Response.Redirect(Request.CurrentExecutionFilePath + "?Page=" + (CurPage + 1));
		//}
	}
}