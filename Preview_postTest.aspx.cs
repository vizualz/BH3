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
using System.Diagnostics;



namespace BoardHunt
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	/// 
	

	public partial class Preview_postTest : System.Web.UI.Page
	{

        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        //protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Global.AuthenticateUser();

            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
            
            //TODO: fix double load
            ErrorLog.ErrorRoutine(false, "Preview_postTest:Page_Load:SID: " + Session.SessionID + " isPB: " + Page.IsPostBack);

            if (tmpBoardItem == null)
            {
                HandleError();
                return;
            }

            if (!Page.IsPostBack)
            {
                //Global.AuthenticateUser();
    
                // Put user code to initialize the page here
			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

			    //Hide all sub-panels then enable accordingly
			    pnlAll.Visible = false;
			    pnlWidth.Visible = false;
			    pnlSurfOnly.Visible = false;
                pnlBoardType.Visible = false;

                //Load up display data and show a preview of the posting
                BindData(tmpBoardItem);

			}

            ErrorLog.ErrorRoutine(false, "Preview_postTest:Page_Load:END:SID:" + Session.SessionID + " isPB: " + Page.IsPostBack);
		}

/**
 * Display the data collected from the (previous) post_item page.  The data now resides in a general entry item object
 * Show the general info then display the specifics
 */ 
		private void BindData(classes.BoardItem bItem)
		{

            hdnUserDir.Value = Session["userDir"].ToString();
            hdnAdType.Value = bItem.AdType.ToString();

            //show today's date
            lblDateData.Text = String.Format("{0:MM/dd}", DateTime.Now);

            //location-region and town
            if (bItem.Location > 0)
            {
                lblLocation.Text = Global.SwapChar(DecodeRegion(Convert.ToInt32(bItem.Location))," ", "_");
                if (bItem.Town.Length > 0)
                {
					lblLocation.Text += " - " + bItem.Town + " " + bItem.Zip;

                }
            }

            //brand
            lblBrandData.Text = bItem.Brand;
            if (bItem.Shaper.Length > 1)
                lblBrandData.Text += " / " + bItem.Shaper;
            //price
            lblPriceData.Text = "$" + bItem.Price.ToString();
            //details
            lblDetailsData.Text = bItem.Details.ToString();
            //boardtype label
            lblBoardType.Text = "Board Type: ";


            //TODO: ShowPicsForPreview(bItem)
            //TODO: dont show no image if slot 2

            //show pictures waiting in temp dir
            if (hdnAdType.Value != "2")    //1 = selling items; 2 = wanted; 3 = showcase
            {
                //Pic1
                Pic1.ImageUrl = GetPicPath(bItem.ImgPath1);
                if (Pic1.ImageUrl.IndexOf("s1x1.gif") != -1)
                {
                    Pic1.ImageUrl = "images/noimage.gif";
                    //Pic1.Width = 400;
                    //Pic1.Height = 400;
                    hdnProcPics.Value = "False";
                }
                else //do thmbnail
                {
                    Pic1ThmbNail.ImageUrl = GetPicPath("thmbNail_" + bItem.ImgPath1);
                    Pic1ThmbNail.Visible = true;
                    //Pic1ThmbNail.Width = 75;
                    Pic1ThmbNail.Height = 75;
                    hdnProcPics.Value = "True";
                }

                //Pic2
                Pic2.ImageUrl = GetPicPath(bItem.ImgPath2);
                if (Pic2.ImageUrl.IndexOf("s1x1.gif") != -1)
                {
                    Pic2.Width = 1;
                    Pic2.Height = 1;

                }
                else
                {
                    Pic2ThmbNail.Visible = true;
                    Pic2ThmbNail.ImageUrl = GetPicPath("thmbNail_" + bItem.ImgPath2);
                    //Pic2ThmbNail.Width = 75;
                    Pic2ThmbNail.Height = 75;
                    hdnProcPics.Value = "True";
                }

                //Pic3
                Pic3.ImageUrl = GetPicPath(bItem.ImgPath3);
                if (Pic3.ImageUrl.IndexOf("s1x1.gif") != -1)
                {
                    Pic3.Width = 1;
                    Pic3.Height = 1;
                }
                else
                {
                    Pic3ThmbNail.Visible = true;
                    Pic3ThmbNail.ImageUrl = GetPicPath("thmbNail_" + bItem.ImgPath3);
                    //Pic3ThmbNail.Width = 75;
                    Pic3ThmbNail.Height = 75;
                    hdnProcPics.Value = "True";
                }

                //Pic4
                Pic4.ImageUrl = GetPicPath(bItem.ImgPath4);
                if (Pic4.ImageUrl.IndexOf("s1x1.gif") != -1)
                {
                    Pic4.Width = 1;
                    Pic4.Height = 1;
                }
                else
                {
                    Pic4ThmbNail.Visible = true;
                    Pic4ThmbNail.ImageUrl = GetPicPath("thmbNail_" + bItem.ImgPath4);
                   // Pic4ThmbNail.Width = 75;
                    Pic4ThmbNail.Height = 75;
                    hdnProcPics.Value = "True";
                }
            }
            else //show wanted pic
            {
                Pic1.ImageUrl = "images//wantedbig.gif";
                Pic1.Height = 214;
                //Pic1.Width = 168;
                hdnProcPics.Value = "False";
            }

            //Show e-mail and possibly phone num
            ShowContactDetails();

            //board specific data
            switch (bItem.Category.ToString())
			{
				case "1": //surf

                    //switch (bItem.BoardType)
                    switch (bItem.AdType)
                    {
                        case 1: //buy
                            pnlAll.Visible = true;
                            pnlBoardType.Visible = true;
                            //fins
                            lblFinsData.Text = DecodeFins(bItem.Fins);
                            //tail
                            lblTailData.Text = Global.ProperSpace(DecodeTail(bItem.TailType));

                            //height
                            lblHeightFtData.Text = bItem.HtFt + "\'";
                            lblHeightInData.Text = bItem.HtIn + "\"";

                            //width
                            lblWidthData.Text = bItem.Width.ToString();
                            if (bItem.WidthDenum.ToString().Length > 0 && bItem.WidthNum.ToString().Length > 0)
                            {
                                lblWidthData.Text += " + " + bItem.WidthNum.ToString() + "/" + bItem.WidthDenum.ToString();
  
                            }
                            lblWidthData.Text += "\"";

                            //thickness
                            lblThick.Text = bItem.Thickness.ToString();
                            if (bItem.ThickNum.ToString().Length > 0 && bItem.ThickDenum.ToString().Length > 0)
                            {
                                lblThick.Text += " + " + bItem.ThickNum.ToString() + "/" + bItem.ThickDenum.ToString();
                            }
                            lblThick.Text += "\"";

                            //enable surf panels
                            pnlWidth.Visible = true;
                            pnlSurfOnly.Visible = true;
                            pnlGearItem.Visible = false;
                            lblBoardTypeData.Text = DecodeBoard(bItem.Category, bItem.BoardType);
                            break;

                        case 2: //sell
                            break;
                        case 3: //showcase
                            pnlAll.Visible = false;
                            lblWeb.Text = bItem.WebURL;
                            pnlWeb.Visible = true;
                            lblGenDims.Text = bItem.GenDimensions;
                            pnlGenDims.Visible = true;
                            lblGearItem.Text = "&nbps;Model:&nbsp";
                            lblGearItem.Visible = true;
                            lblGearItemData.Text = bItem.GearItem;
                            pnlGearItem.Visible = true;

                            break;
                        case 4:
                            lblPrice.Text = "Model Price";
                            lblModelData.Text = bItem.Model;
                            lblBoardTypeData.Text = DecodeBoard(bItem.Category, bItem.BoardType);
                            lblGenDims.Text = bItem.GenDimensions;
                            break;
                        default:
                            break;
                    }

					break;
						
				case "2": //snow
                    pnlBoardType.Visible = true;
                    lblHeightFtData.Text = bItem.HtFt + "" + "cm";
                    
                    lblBoardTypeData.Text = DecodeBoard(bItem.Category, bItem.BoardType);
                    lblBrand.Text = "Brand:" + "";
                    
                    pnlSurfOnly.Visible = false;

					break;
						
				case "3": //other board
                    pnlBoardType.Visible = true;
                    lblBrand.Text = "Brand:" + "";

                    if (bItem.OtherBoardType == null || bItem.OtherBoardType == "")
                    {
                        //todo: maybe set other = "" so sql doesn't complain
       
                        bItem.OtherBoardType = "";
                        lblBoardTypeData.Text = DecodeBoard(bItem.Category, bItem.BoardType);

                    }
                    else
                    {
                        lblBoardTypeData.Text = bItem.OtherBoardType;
                    }
                    pnlAll.Visible = false;
                    pnlSurfOnly.Visible = false;
                    pnlGenDims.Visible = true;
                    lblGenDims.Text = bItem.GenDimensions;
                    break;
						
				case "4": //gear
                    lblBrand.Text = "Brand:" + "";
                    pnlAll.Visible = false;
                    pnlSurfOnly.Visible = false;
                    pnlGearItem.Visible = true;
                    lblGearItem.Visible = true;
                    pnlBoardType.Visible = false;
                    lblGearItemData.Text = bItem.GearItem;
                    break;
			}
            SetupUIForEntryType();  //superflous?
		}		
		
/**
 */ 
		public string DecodeBoard(int cat, object BoardCode)
		{
            string rtn = string.Empty;

            switch (cat)
            {
                case 1:
                    rtn = Enum.GetName(typeof(Global.BOARDTYPE_SURF), BoardCode);
                    break;
                case 2:
                    rtn = Enum.GetName(typeof(Global.BOARDTYPE_SNOW), BoardCode);
                    break;
                case 3:
                    rtn = Enum.GetName(typeof(Global.BOARDTYPE_OTHER), BoardCode);
                    break;
            }
            return rtn;
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

            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);

            this.btnEditTop.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnFinishTop.Click += new System.EventHandler(this.btnPublish_Click);

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
        private void btnPublish_Click(object sender, System.EventArgs e)
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
            ErrorLog.ErrorRoutine(false, "post_preview:StepBackEdit:SID: " + Session.SessionID);
            classes.BoardItem oBoardItem = (classes.BoardItem)Session["Item"];
            oBoardItem.EditMode = true;
            Session["Item"] = oBoardItem;
			Response.Redirect("post_itemTest.aspx?", true);        
        }
        
/**
 */ 
		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            StepBackEdit();
		}
/**
 */ 
		public string GetPicPath(object imgPicPath)
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
                //assign http URL for pic in temp dir
                imgPath = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/users/" + hdnUserDir.Value + "temp/" + Path.GetFileName(imgPicPath.ToString());
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
        public string DecodeFins(object FinCode)
		{
			//return Global.ReverseLookUp(FinCode);
			return Enum.GetName(typeof(Global.FINS), FinCode);

		}
/**
*/
        public string DecodeTail(object TailCode)
		{
			//return Global.ReverseLookUp(FinCode);
			return Enum.GetName(typeof(Global.TAIL), TailCode);

		}
/**
*/ 
		private void lnkSignIn_Click(object sender, System.EventArgs e)
		{
            BusinessLogic.HelperFunctions.FaceBookLogout(Session);	
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
/*
*/ 
  public void ShowContactDetails()
        {

            string myConnectString, strSQL;

            //load up contact details
            strSQL = "SELECT txtEmail, txtPhonenum, iShowPhoneNum FROM tblUser WHERE tblUser.iD = '" + Session["userId"].ToString() + "'";

            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                while (SQLReader.Read() == true)
                {

                    lnkEmailData.Text = SQLReader["txtEmail"].ToString();
                    lnkEmailData.Attributes.Add("href", "mailto:" + SQLReader["txtEmail"].ToString());

                    lblPhoneData.Text = SQLReader["txtPhoneNum"].ToString();
                    lblPhoneData.Visible = ShowPhone(SQLReader["iShowPhoneNum"]);

                }

            }

            catch
            {
                lblStatus.Text = "SQL Error!";
                ErrorLog.ErrorRoutine(false, "Error:preview_post:showcontact_details: Can't read contact info");
            }
            finally
            {
                myConnection.Close();
            } 
            return;
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
/*
 */ 
        private void SubmitItem(bool publishVal)
        {

            classes.BoardItem tmpBoardItem2 = (classes.BoardItem)Session["Item"];

            // - Tasks:
            // - Move pics from temp dir to surf dir then delete *.* temp dir
            // - Write entry to db from object

            if (tmpBoardItem2 == null)
            {
                ErrorLog.ErrorRoutine(false, "Error:Preview_Post:imgContinue_Click: BoardItem obj NULL: Session: " + Session.SessionID);
                //ErrorLog.ErrorRoutine(false, "Error:Preview_Post:imgContinue_Click: SessionID: " + Session.SessionID);

                pnlError.Visible = true;
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "Preview_Post:imgContinue_Click:ENTRYITEM OK: " + Session.SessionID);
            }

            tmpBoardItem2.Created = DateTime.Now;
            tmpBoardItem2.Details = Global.CheckString(tmpBoardItem2.Details);
            tmpBoardItem2.Brand = Global.CheckString(tmpBoardItem2.Brand);
            tmpBoardItem2.Shaper = Global.CheckString(tmpBoardItem2.Shaper);

            //Shaperhouse
            if (tmpBoardItem2.AdType == 4)
            {
                if (publishVal)
                    tmpBoardItem2.Status = 5;
                else
                    tmpBoardItem2.Status = 4;
            }

            //check for pics
            if (hdnProcPics.Value == "True" && tmpBoardItem2.AdType != (int)2)
            {
                if (MoveFiles(tmpBoardItem2.Category, tmpBoardItem2.AdType))
                {
                    DeletePicsInTempDir();
                }
            }

            //Save entry
            try
            {
                //write entry to db
                if (tmpBoardItem2.SaveItem())
                {
                    //update user's entry count
                    if (UpdateEntryCount(tmpBoardItem2.IUser.ToString()))
                    {
                        if (!publishVal)
                        {
                            Response.Redirect("post_manager.aspx?q=4", false);
                        }
                        Response.Redirect("post_finishTest.aspx", false);
                    }
                }
                else
                {
                    lblStatus.Text = "Error posting";
                }
            }
            catch { lblStatus.Text = "ERROR"; }
            finally { }

            //TODO: Remove.  Do we needed it?
            //Session["Item"] = tmpBoardItem;        
        }
/*
 * Moves media files from temp dir to permanent home in user dir
 */ 
        private bool MoveFiles(object catVal, int adType)
        {
            string strCat = Enum.GetName(typeof(Global.BOARDCAT_DIRS), catVal);
            
            string srcPath,srcPath_T, targetPath1, targetPath2, targetPath3, targetPath4;
            string strUserDir = hdnUserDir.Value;

            targetPath1 = "";
            targetPath2 = "";
            targetPath3 = "";
            targetPath4 = "";

            //Move files from temp to user dir for sell adtypes only
            if (adType != (int)2)
            {

                //check to make sure pic are not blank entry or the noimage.gif.  *blank entries are denoted by a 1x1px clear gif.
                if (Path.GetFileName(Pic1.ImageUrl) != "s1x1.gif" && Path.GetFileName(Pic1.ImageUrl) != "noimage.gif")
                {
                    srcPath = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + Path.GetFileName(Pic1.ImageUrl);
                    srcPath_T = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                    //check for existing dir
                    if (!Directory.Exists(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat)))
                    {
                        Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat));

                    }
                    //Move Larger Image
                    targetPath1 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + Path.GetFileName(Pic1.ImageUrl);
                    File.Move(srcPath, targetPath1);
                    //Move ThumbNail Image
                    targetPath1 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                    File.Move(srcPath_T, targetPath1);

                }

                if (Path.GetFileName(Pic2.ImageUrl) != "s1x1.gif")
                {
                    srcPath = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + Path.GetFileName(Pic2.ImageUrl);
                    srcPath_T = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + "thmbNail_" + Path.GetFileName(Pic2.ImageUrl);
                    if (!Directory.Exists(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat)))
                    {
                        Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat));

                    }
                    //Larger Image
                    targetPath2 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + Path.GetFileName(Pic2.ImageUrl);
                    File.Move(srcPath, targetPath2);
                    //Thumbnail
                    targetPath2 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + "thmbNail_" + Path.GetFileName(Pic2.ImageUrl);
                    File.Move(srcPath_T, targetPath2);
                }

                if (Path.GetFileName(Pic3.ImageUrl) != "s1x1.gif")
                {
                    srcPath = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + Path.GetFileName(Pic3.ImageUrl);
                    srcPath_T = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + "thmbNail_" + Path.GetFileName(Pic3.ImageUrl);
                    if (!Directory.Exists(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat)))
                    {
                        Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat));

                    }
                    //Larger Image
                    targetPath3 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + Path.GetFileName(Pic3.ImageUrl);
                    File.Move(srcPath, targetPath3);
                    //ThumbNail Image
                    targetPath3 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + "thmbNail_" + Path.GetFileName(Pic3.ImageUrl);
                    File.Move(srcPath_T, targetPath3);

                }

                if (Path.GetFileName(Pic4.ImageUrl) != "s1x1.gif")
                {
                    srcPath = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + Path.GetFileName(Pic4.ImageUrl);
                    srcPath_T = Server.MapPath(".\\" + @"\users\" + strUserDir + @"temp\") + "thmbNail_" + Path.GetFileName(Pic4.ImageUrl);
                    if (!Directory.Exists(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat)))
                    {
                        Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + strUserDir + strCat));

                    }
                    //Larger Image
                    targetPath4 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + Path.GetFileName(Pic4.ImageUrl);
                    File.Move(srcPath, targetPath4);
                    //Thumbnail Image
                    targetPath4 = Server.MapPath(".\\" + @"\users\" + strUserDir + strCat + @"\") + "thmbNail_" + Path.GetFileName(Pic4.ImageUrl);
                    File.Move(srcPath_T, targetPath4);
                }
            }

            return true;

        }
/*
 * Deletes all files in temp dir
 */ 
        private bool DeletePicsInTempDir()
        {
            
            //delete all files in tempDir
            try
            {
                if (Directory.Exists(Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + @"\temp\")))
                {
                    string[] files = Directory.GetFiles(Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + @"\temp\"));
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
                ErrorLog.ErrorRoutine(false, "Preview_Post:DeletePicsInTempDir:ErrorDeletingTempPics: " + e.Message);
                return false;
            }        
        }

/*
 * Handle the null object item error
 */
        private void HandleError()
        {
            ErrorLog.ErrorRoutine(false, "Error:preview_post:Page_Load:BoardItem obj NULL: SessionID: " + Session.SessionID + ":BrowserType:" + Request.Browser.Browser + " User: " + Session["EmailId"].ToString());

            string eLog = string.Empty;
            StackTrace stackTrace = new StackTrace();           // get call stack
            StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)

            // write call stack method names
            foreach (StackFrame stackFrame in stackFrames)
            {
                eLog += stackFrame.GetMethod().Name + " : ";// write method name
                
            }
            ErrorLog.ErrorRoutine(false, eLog);   

            //notify BH
            classes.Email.SendErrorEmail("Error:preview_post:page_load:Null item: Browser: " + Request.Browser.Browser + "-" + Request.Browser.Version + " Server: " + System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString()  +  " Session: " + Session.SessionID + " isPB: " + Page.IsPostBack);

            //show error and re-login
            pnlError.Visible = true;
            pnlDetails.Visible = false;
        }
/*
*/
        private void SetupUIForEntryType()
        {
            btnEdit.Visible = true;
            btnEditTop.Visible = true;
            btnFinishTop.Visible = true;
            btnFinishTop.Text = "Finish";
            btnPublish.Visible = true;
            btnPublish.Text = "Finish";
            btnSave.Visible = false;
            
            switch (hdnAdType.Value)
            {
                //buy
                case "1":
                    break;
                //sell
                case "2":
                    break;
                //showcase item
                case "3":
                    break;
                //Shaper's G-Post
                case "4":
                    pnlBoardType.Visible = true;
                    pnlModel.Visible = true;
                    pnlGenDims.Visible = true;
                    pnlShaper.Visible = true;
                    pnlContact.Visible = false;
                    pnlGearItem.Visible = false;
                    pnlAll.Visible = false;
                    pnlShaper.Visible = false;
                    
                    //buttons
                    btnEdit.Visible = true;
                    btnEditTop.Visible = true;

                    btnFinishTop.Visible = true;
                    btnFinishTop.Text = "Publish";
                    btnPublish.Visible = true;
                    btnPublish.Text = "Publish";
                    
                    btnSave.Visible = true;

                    break;
            }
            return;
        }
	}
}
