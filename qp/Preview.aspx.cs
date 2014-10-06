//
//Project File Log:
//2/20/07:  Using the core of the ItemDetails pg, this page is now used as a pre-post preview.
//          Todo: add in new values to db; so far items are posting! =) 

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



namespace BoardHunt.qp
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	/// 
	

	public partial class Preview : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Global.AuthenticateUser();

            classes.Coupon cItem = (classes.Coupon)Session["cItem"];

            if (cItem == null)
            {
                HandleError();
                return;
            }

            if (!Page.IsPostBack)
            {
                // Put user code to initialize the page here
			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

                //Load up display data and show a preview of the posting
                BindData(cItem);

                ErrorLog.ErrorRoutine(false, "cItem.Status: " + cItem.Status);

                SetUI(cItem.Status);

			}
		}

        protected void SetUI(int stat)
        {
            //change button text around if already active
            if (stat == 1)
            {
                btnEdit.Visible = true;
                btnSave.Visible = true;
                btnSave.Text = "Save";
                btnBuy.Visible = false;
                //lnkInfo.Attributes.Add("Title", " | ");
                lnkInfo.Visible = false;
            }
            else //not active
            {
                btnEdit.Visible = true;
                btnSave.Visible = true;
                btnBuy.Visible = true;
                lnkInfo.Attributes.Add("Title", "Info|Click 'Buy' to have your coupon shown to the public immediately.  You can also save and buy later.");
            }
        }

/**
 * Display the data collected from the (previous) post_item page.  The data now resides in a general entry item object
 * Show the general info then display the specifics
 */ 
		private void BindData(classes.Coupon bItem)
		{

            hdnUserDir.Value = Session["userDir"].ToString();

            //show today's date
            if (bItem.Expired != DateTime.MinValue)
                lblDateData.Text = "Exp: " + String.Format("{0:MM/dd/yyyy}", bItem.Expired);

            lblDetailsData.Text = Global.ReplaceEx(bItem.Details,"''","'");    //details
            lblTitle.Text = bItem.Title;            //title

            //TODO
            //lblCouponCode = bItem.CCode;

            //ShowPic
            hdnProcPics.Value = "0";
            if (bItem.UseDefaultImg)
                Pic1.ImageUrl = "../images/CouponDefault.gif";
            else
            {
                hdnProcPics.Value = "1";
                Pic1.ImageUrl = GetPicPath(bItem.ImgPath1, bItem.UseTempDir);
            }

        }
		
		#region Web Form Designer generated code
/**
 */ 
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
            this.Load += new System.EventHandler(this.Page_Load);
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
			//this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            //this.imgContinue.Click += new System.Web.UI.ImageClickEventHandler(this.imgContinue_Click);


		}
		#endregion
/**
*/
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SubmitItem(false);
        }        
/**
*/
        private void btnBuy_Click(object sender, System.EventArgs e)
        {
            SubmitItem(true);
        }
/**
 */
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            StepBackEdit();
        }
/*
 * */
        private void StepBackEdit()
        {
            classes.Coupon oItem = (classes.Coupon)Session["cItem"];
            oItem.EditMode = 1;             //Set Edit flag
            Session["Item"] = oItem;
            oItem = null;
            Response.Redirect("Post.aspx", true);        
        }
        
/**
 */ 
		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            StepBackEdit();
		}
/**
 */ 
		public string GetPicPath(object imgPicPath, int iTemp)
		{
			string imgPath;

            //check for null or empty string
			if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
			{
                //assign clear pixel
                imgPath = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/s1x1.gif";
			}
			else
			{
                imgPath = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/users/" + hdnUserDir.Value;
                if (iTemp == 1) 
                    imgPath += "temp/";
                
                //assign http URL for pic in temp dir
                imgPath += Path.GetFileName(imgPicPath.ToString());
            }
			
			return imgPath;
		}

/**
 */ 
		//Format price with $
		public string FormatPrice(object priceVal)
		{
			return String.Format("{0:c}",priceVal);
		}

/**
 */ 
		//displays phone number based on user pref in db
		public bool ShowPhone(object iDisplay)
		{

			if (Convert.ToInt32(iDisplay.ToString()) == (int)1)
			{
				return true;
			}
			return false;
		}

/**
 */ 
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);

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
            Session["Item"] = null;
            Response.Redirect("../post.aspx");
		}
/*
*/ 
  public void ShowContactDetails()
        {
            string strSQL;

            //load up contact details
            strSQL = "SELECT txtEmail, txtPhonenum, iShowPhoneNum FROM tblUser WHERE tblUser.iD = '" + Session["userId"].ToString() + "'";
        }
        
 /**
  * Update the user's entry count to keep track of # of postings
 */ 
		public bool UpdateEntryCount(string uiD)
		{
			bool retVal;

            string conn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
			SqlConnection myConnection = new SqlConnection(conn);
			string strSQL = "UPDATE tblUser SET iEntryCount = iEntryCount + 1 WHERE iD = '" + uiD + "'";
			

			try
			{
				myConnection.Open();
				SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				objCommand.ExecuteNonQuery();
				retVal = true;
			}
			catch
			{
				lblStatus.Text = "ERROR on UPDATE: " + strSQL;
				retVal = false;
			}
			finally
			{
				myConnection.Close();
				
			}
			return retVal;
		}		

/**
 */ 
		private void imgContinue_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            SubmitItem(true);
		}

        private void SubmitItem(bool publishVal)
        {
            //at this point it's useless to ask for (editmode = 1) because we cannot guarantee where it came from. check c.id instead

            classes.Coupon oItem = (classes.Coupon)Session["cItem"];

            // - Tasks:
            // - Move pics from temp dir to user dir  2)clear temp dir (if needed)
            // - Write obj values to db 

            if (oItem == null)
            {
                ErrorLog.ErrorRoutine(false, "Error:Preview:imgContinue_Click: BoardItem obj NULL: Session: " + Session.SessionID);
                HandleError();
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "Preview:imgContinue_Click:ENTRYITEM OK: " + Session.SessionID);
            }

            if (oItem.EntryId <= 0) //new entry?
            {
                oItem.Created = DateTime.Now;
                oItem.IUser = Convert.ToInt32(Session["userId"].ToString());
            }

            //TODO: figure this out
            //if (publishVal)
            //    oItem.Status = 5;
            //else
            //    oItem.Status = 4;


            //how to determine editMode, iD
            //check for pics
            if (hdnProcPics.Value == "1")
            {
                if (oItem.UseTempDir == 1) //note: hdnProcPics is based on s1x1.gif
                {
                    string userDir = Global.ReplaceEx(hdnUserDir.Value, "/", "\\");
                    string sUPath = Global.ReplaceEx(Server.MapPath(".\\"), "\\qp", string.Empty) + @"users\" + userDir;

                    if (MoveFiles(sUPath))
                    {
                        DeletePicsInTempDir(sUPath);
                    }
                }
            }
            else
                oItem.ImgPath1 = string.Empty;  //default

            //validate text
            oItem.Details = Global.ReplaceEx(oItem.Details, "'", string.Empty);
            oItem.Details = Global.ReplaceEx(oItem.Details, "\"", string.Empty);

            oItem.Title = Global.ReplaceEx(oItem.Title, "'", string.Empty);
            oItem.Title = Global.ReplaceEx(oItem.Title, "\"", string.Empty);

            //Save or Update entry
            try
            {
                //update
                if (oItem.EntryId > 0)
                {
                    if (!oItem.UpdateCoupon())
                    {
                        lblStatus.Text = "Error in Update";
                        lblStatus.CssClass = "errorLabel";
                        return;
                    }

                }
                else
                {
                    oItem.EntryId = oItem.SaveCoupon();
                    ErrorLog.ErrorRoutine(false, "EntryId: " + oItem.EntryId);
                    if (oItem.EntryId < 0)
                    {
                        lblStatus.Text = "Error Saving Data";
                        lblStatus.CssClass = "errorLabel";
                        return;
                    }
                }

                if (publishVal)
                {
                    Session["ServiceId"] = "4";
                    Session["TxnItemId"] = oItem.EntryId;
                    Response.Redirect("../Pay/OrderForm.aspx", true);
                }
                Response.Redirect("Manager.aspx", true);
            }
            catch (Exception ex) 
            { 
                lblStatus.Text = "Arg! Something happened.  Nerdy geeks have been notified. You can try again shortly.";
                ErrorLog.ErrorRoutine(false, ex.Message);
            }
            finally 
            {
                //destroy objects
                oItem = null;
                Session["cItem"] = null;            
            }
        }
/*
 * Moves media files from temp dir to permanent home in user dir
 */ 
        private bool MoveFiles(string svrUPath)
        {
            string tmpFilePath, tmpFilePath_Tmb;
            string targetPath1 = string.Empty;
            string tmpUsrPath = svrUPath + @"temp\";

            //Move files from temp to user dir
            //Check to make sure pic are not blank entry or the noimage.gif.  *blank entries are denoted by a 1x1px clear gif.

            if (Path.GetFileName(Pic1.ImageUrl) != "s1x1.gif" && Path.GetFileName(Pic1.ImageUrl) != "noimage.gif")
            {
                tmpFilePath = tmpUsrPath + Path.GetFileName(Pic1.ImageUrl);
                //tmpFilePath_Tmb = tmpUsrPath + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                //check for existing dir
                if (!Directory.Exists(svrUPath))
                {
                    Directory.CreateDirectory(svrUPath);
                }
                //Move Big Image
                targetPath1 = svrUPath + Path.GetFileName(Pic1.ImageUrl);
                File.Move(tmpFilePath, targetPath1);
                //Move ThumbNail Image
                //targetPath1 = svrUPath + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                //File.Move(tmpFilePath_Tmb, targetPath1);
            }
            return true;
        }
/*
 * Deletes all files in temp dir
 */ 
        private bool DeletePicsInTempDir(string svrPath)
        {
            try
            {
                if (Directory.Exists(svrPath + @"\temp\"))
                {
                    string[] files = Directory.GetFiles(svrPath + @"\temp\");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                    return true;
                }
                else
                {
                     return false;
                }
            }
            catch (Exception e)
            {
                ErrorLog.ErrorRoutine(false, "Preview:DeletePicsInTempDir:" + e.Message);
                return false;
            }        
        }

/*
 * Handle the null object item error
 */
        private void HandleError()
        {
            ErrorLog.ErrorRoutine(false, "Error:preview_post:Page_Load:BoardItem obj NULL: SessionID: " + Session.SessionID + ":BrowserType:" + Request.Browser.Browser);

            //notify BH
            classes.Email.SendErrorEmail("Error:post_item:page_load:Null item on PB/Entry: Session: " + Session.SessionID);

            //show error and re-login
            pnlError.Visible = true;
            pnlDetails.Visible = false;
            
            btnBuy.Visible = false;
            btnEdit.Visible = false;
            btnSave.Visible = false;

            lnkInfo.Visible = false;
        }
/*
*/
        private void SetupUI()
        {
            btnEdit.Visible = true;
            btnBuy.Visible = true; //only for new entries
            btnSave.Visible = true;
            return;
        }
	}
}
