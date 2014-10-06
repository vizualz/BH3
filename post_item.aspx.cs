//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			post_item.apx.cs
/// 
///		Project log:	
///						6/06/06 -	Not the best date to start a project log
///									but I got the file upload working
///									Error in writing path to DB - check type
///						6/07/06 -	Changed imgPath type in SQL DB to txt 'char'
///									Posting seems to work but buggy with complex filenames
///						7/25/06 -	Added GlobalAuthenticate
///						8/23/06 -	Added RandomFile generator to replace uploaded filename 
///									for pic	
///						8/31/06 -   Music: Radiohead: Everything in it's right place
///									Added error checking for forms
///						9/06/07 -   Added error checking for uploaded file type									
///									 		 
///						
///
///
//////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace BoardHunt
{
	/// <summary>
	/// Summary description for post_item.
	/// </summary>
	/// 
	
	public partial class post_item : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.RadioButtonList radioFins;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button CmdUpload;
        protected System.Web.UI.WebControls.LinkButton lnkHlpBoard; 
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected const int picSizeBigX = 400;
        protected const int picSizeBigY = 400;

        protected const int picSizeThmbX = 75;
        protected const int picSizeThmbY = 75;

        protected const string strErrOneMegPics = "&nbsp;Hated! Something broke. Make sure EACH image is under 1MB and try again. &nbsp;";
        protected const string strErrClose = "&nbsp;Click here to close this browser and try again.&nbsp;";

        protected const string strErrWidth = "&nbsp;Arg! An error occured.  Please fix the width and use fractions. &nbsp;";
        protected const string strErrHeight = "&nbsp;Arg! An error occured.  Please fix the height.&nbsp;";
        protected const string strErrThick = "&nbsp;Arg! An error occured.  Please fix the thickness and use fractions. &nbsp;";
        protected const string strErrPrice = "&nbsp;Arg! An error occured.  Please fix the price. &nbsp;";

		protected void Page_Load(object sender, System.EventArgs e)
		{
            ErrorLog.ErrorRoutine(false, "PI: Pg_Load:IsPB: " + Page.IsPostBack + " SessionID: " + Session.SessionID + " Browser: " + Request.Browser.Browser);

            
            HideErrorMessages();

            //TODO:SECURITY CHECK verify user and stuff object
            //check for ShaperHouse post
            string[] qAdType;
            qAdType = Request.QueryString.GetValues("q");
            if (qAdType != null)    //SH
            {
                classes.BoardItem tItem = new classes.BoardItem();

                tItem.Category = Convert.ToInt32(1);
                tItem.Ship = Convert.ToInt32(0);

                tItem.Location = Convert.ToInt32(1);
                tItem.Town = string.Empty;
                
                tItem.EditMode = false;

                BoardHunt.classes.RandomPassword pwdGen = new BoardHunt.classes.RandomPassword();
                tItem.ActivateCode = pwdGen.Generate();

                tItem.AdType = Convert.ToInt32(HttpUtility.UrlDecode(qAdType[0].ToString()));
                qAdType[0] = string.Empty;
                Session["Item"] = tItem;
                tItem = null;
            }

            //Check for Post breaks.  A typical break will have a null "Item" on a postback.
            if (Session["Item"] == null)
            {
                HandleError();
                return;
            }

            //better performance when this is outside or within !Page.IsPostback?
            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];

			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );
                
            //hide fakie button
            btnNextFake.Style.Add("Display", "None");
            btnNextFake.Style.Add("Class", "btnNext");

            //hide addImgPanel
            pnlAddImages.Visible = true;
            hdnAdType.Value = tmpBoardItem.AdType.ToString();

            if (!Page.IsPostBack)
            {
                //authenticate
                Global.AuthenticateUser();

                //bind data from db
                BindData(tmpBoardItem);

                //Check for editMode
                if (tmpBoardItem.EditMode)
                {
                    LoadForEdits(tmpBoardItem);
                }
                else
                {
                    InitImgUploader();
                }
            }

            //TODO: move to SetUpUIForEntryType
            switch (tmpBoardItem.AdType)
            {
                case 2: //wanted
                    cboFins.Visible = false;
                    lblFins.Visible = false;
                    cboTailType.Visible = false;
                    lblTail.Visible = false;
                    lblImgTip.Visible = false;
                    //imgBtnFinHelp.Visible = false;
                    pnlSurfOnly.Visible = false;
                    pnlBrand.Visible = false;
                    break;
                case 3: //showcase
                    pnlBoardType.Visible = false;
                    pnlHeight.Visible = false;
                    pnlBrand.Visible = true;
                    pnlGenDims.Visible = true;
                    pnlSurfOnly.Visible = false;
                    pnlWeb.Visible = true;
                    pnlGearItem.Visible = true;
                    lblItem.Text = "Model: ";
                    break;
            }

            //hide to minimize board post breaks
            rdoImgMgr4.Enabled = false;
            //img4.Visible = false;
            rdoImgMgr4.Style.Add("Display", "None");

		}
/*
 */ 
        public void Page_Error(object sender, EventArgs e)
        {
            string strErrorMsg;
            strErrorMsg = Session["EmailId"].ToString();
            strErrorMsg += " *URL: " + Request.Url.ToString();
            // Get the path of the page
            strErrorMsg += " *Error in Path :" + Request.Path;
            // Get the QueryString along with the Virtual Path
            strErrorMsg += " *Error Raw Url :" + Request.RawUrl;
            // Create an Exception object from the Last error that occurred on the server
            Exception myError = Server.GetLastError().GetBaseException();
            // Get the error message
            strErrorMsg += " *Error Message :" + myError.Message;
            // Source of the message
            strErrorMsg += " *Error Source :" + myError.Source;
            // Stack Trace of the error
            strErrorMsg += " *Error Stack Trace :" + myError.StackTrace;
            // Method where the error occurred
            strErrorMsg += " *Error TargetSite :" + myError.TargetSite;
            ErrorLog.ErrorRoutine(false, "Error:PI:Page_Error: " + strErrorMsg); 

            //TODO: why not?
            //Server.ClearError();
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
            //this.lnkHlpBoard.Click += new System.EventHandler(this.lnkHlpBoard_Click);
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);

            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

		}
		#endregion
/*
*/ 
        public void BindData(classes.BoardItem tBoardItem)
        {
            //sets the dynamic UI up according to category
            FillDropDowns(tBoardItem.Category.ToString());
            SetUpUIForCategory(tBoardItem.Category.ToString());
            SetUpUIForEntryType(tBoardItem.AdType);
            lblCat.Text = Global.up1(DecodeiCat(tBoardItem.Category));
        }
/*
*/
        public void SetUpUIForEntryType(int cat)
        {
            switch (cat)
            {
                //buy
                case 1:
                    break;
                //sell
                case 2:
                    break;
                //showcase item
                case 3:
                    break;
                //Shaper's Model Post
                case 4:
                    pnlBoardType.Visible = true;
                    pnlModel.Visible = true;
                    pnlGenDims.Visible = true;
                    pnlVideo.Visible = true;
                    pnlGearItem.Visible = false;
                    pnlHeight.Visible = false;
                    pnlSurfOnly.Visible = false;
                    //imgBtnHelp.Visible = false;
                    pnlBrand.Visible = false;
                    lblDetailTxt.Text = "Creative descriptions<br>Board Construction?<br>Ideal rider?<br>Best wave types?<br>Available sizes?<br>Promo prices?";
                    lblInstructions.Text = "Step 1. Add in the details";
                    lblTip.Text = string.Empty;
                    lnkSell.NavigateUrl = "UserMenu.aspx";
                    lblPriceDir.Text = "$ (USD) Type in a price or price range.";
                    txtPrice.Width = Unit.Pixel(100);
                    break;
            }
            return;        
        }
/*
*/
        public void SetUpUIForCategory(string cat)
        {

            switch (cat)
            {
                //surf
                case "1":
                    pnlSurfOnly.Visible = true;
                    //lblBrand.Text += " or Shaper:&nbsp;";
                    pnlGenDims.Visible = false;
                    //imgBtnHelp.Attributes.Add("onClick", "popUpHelp('1')");
                    //imgBtnFinHelp.Attributes.Add("onClick", "popUpHelp('4')");
                    break;

                //snow
                case "2":
                    lblBrand.Text += ":" + "&nbsp;";
                    pnlSurfOnly.Visible = false;
                    lblHtFt.Text = "cm";
                    lblHtIn.Visible = false;
                    txtHtIn.Visible = false;
                    txtHtFt.MaxLength = (int)3;
                    txtHtFt.Width = (int)35;
                    pnlGenDims.Visible = false;
                    //imgBtnHelp.Attributes.Add("onClick", "popUpHelp('2')");
                    
                    break;
                //other board
                case "3":
                    lblBrand.Text += ":" + "&nbsp;";
                    pnlGenDims.Visible = true;
                    pnlSurfOnly.Visible = false;
                    chkOther.Visible = true;
                    chkOther.Checked = false;
                    txtOtherBoard.Visible = true;
                    txtOtherBoard.Enabled = false;
                    pnlHeight.Visible = false;
                    //imgBtnHelp.Visible = false;
                    
                    ListItem li = new ListItem();
                    li = cboBoardType.Items.FindByText("Skateboard     ");
                    if (li != null)
                    {
                        cboBoardType.SelectedItem.Selected = false;
                        li.Selected = true;
                    }
                    break;
                //gear
                case "4":
                    pnlBoardType.Visible = false;
                    pnlGearItem.Visible = true;
                    //lblBrand.Text += ":" + "&nbsp;";
                    lblShaper.Visible = false;
                    txtShaper.Visible = false;
                    pnlHeight.Visible = false;
                    pnlSurfOnly.Visible = false;
                    pnlGenDims.Visible = false;
                    //imgBtnHelp.Visible = false;
                    break;

            }
            return;
        }
        
/*
 * Things to keep in mind here for this event handler:
 *      - we process all board types here including gear
 *      - we process wanted ads too which is a very limited subset including only 
 *        category, boardtype, region, town, details, and price maybe
*/
        
        //private void imgContinue_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            //TODO: figure out why it breaks here sometimes:
            //ideas: check values assigned.  Are we assigning a NULL and breaking the BoardItem Sess var?

            ErrorLog.ErrorRoutine(false, "PI:btnNext_Click: " + Session.SessionID);

            //check file type
            if (!CheckUploadedFiles())
            {
                ResetImgMgr();
                return;
            }

            ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:Done " + Session.SessionID);

            //kick out if validation failed //TODO: where does this come from?
            if (!(Page.IsValid))
            {
                //re-set anything here that needs a reset
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:PageNotValid");
                ResetImgMgr();
                return;
            }

            if (Session["Item"] == null)
            {
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:BoardItem NULL!");
                ShowErrorMessage(true, strErrOneMegPics);
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:BoardItem OK:SID: " + Session.SessionID );
            }

            //Get the Item session object
            classes.BoardItem tBoardItem = (classes.BoardItem)Session["Item"];

            //array holder for pics
            string[] strImgPathArray = new string[4];

            //init img array with blank space
            for (int j = 0; j <= 3; j++)
            {
                strImgPathArray[j] = "";
            }

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, Delete,
            //, or Change an image. ***NOTE: For BETA entry updates will not use preview_post.  
            //This means pics will *not* be moved to a temp dir as we do in posting.  This should change eventually.'
            //Delete any files in imgDel array
            bool blnProcImgs = false;

            switch (rdoImgMgr1.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tBoardItem.ImgPath1 = "";
                    break;
                case "Change":
                    blnProcImgs = true;
                    break;
                case "Add":
                    blnProcImgs = true;
                    break;
                default:
                    break;
            }

            switch (rdoImgMgr2.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tBoardItem.ImgPath2 = "";
                    break;
                case "Change":
                    blnProcImgs = true;
                    break;
                case "Add":
                    blnProcImgs = true;
                    break;
                default:
                    break;
            }

            switch (rdoImgMgr3.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tBoardItem.ImgPath3 = "";
                    break;
                case "Change":
                    blnProcImgs = true;
                    break;
                case "Add":
                    blnProcImgs = true;
                    break;
                default:
                    break;
            }

            //switch (rdoImgMgr4.SelectedValue)
            //{
            //    case "Keep":
            //        break;
            //    case "Delete":
            //        tBoardItem.ImgPath4 = "";
            //        break;
            //    case "Change":
            //        blnProcImgs = true;
            //        break;
            //    case "Add":
            //        blnProcImgs = true;
            //        break;
            //    default:
            //        break;
            //}

            //Process images / *video
            if (blnProcImgs)
                tBoardItem = UpLoadAllImages(tBoardItem, strImgPathArray);

            if (Session["Item"] == null)
            {
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:checkAfterUpload:" + Session.SessionID + ":BoardItem NULL!");
                ShowErrorMessage(true, strErrOneMegPics);
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click:checkAfterUpload:" + Session.SessionID + ":BoardItem OK");
            }

            //Save common data
            tBoardItem.Brand = txtBrand.Text;
            tBoardItem.Shaper = txtShaper.Text;

            string tmpDetails = txtDetails.Text;

            //remove characters after 599.
            if (tmpDetails.Length > 599)
            {
                tBoardItem.Details = tmpDetails.Remove(599, tmpDetails.Length - 599);
            }
            else
            {
                tBoardItem.Details = txtDetails.Text;
            }

            if (tBoardItem.AdType == 4)                 //shaperhouse
                tBoardItem.TxtPrice = txtPrice.Text;
            else
                tBoardItem.Price = Convert.ToDecimal(txtPrice.Text);

            tBoardItem.IUser = Convert.ToInt32(Session["userId"].ToString());
            
            //Save category specific data
            switch (tBoardItem.Category.ToString())
            {
                case "1": //surf

                    switch (tBoardItem.AdType)
                    {
                        case 1: //selling
                            tBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                            tBoardItem.HtFt = Convert.ToInt32(txtHtFt.Text);
                            tBoardItem.HtIn = Convert.ToInt32(txtHtIn.Text);

                            tBoardItem.Thickness = Convert.ToInt32(txtThick.Text);
                            tBoardItem.ThickNum = Convert.ToInt32(txtThickNum.Text);
                            tBoardItem.ThickDenum = Convert.ToInt32(txtThickDNum.Text);
                            tBoardItem.TailType = Convert.ToInt32(cboTailType.SelectedItem.Value);
                            tBoardItem.Width = Convert.ToDecimal(txtWidth.Text);
                            tBoardItem.WidthNum = Convert.ToInt32(txtWidthNum.Text);
                            tBoardItem.WidthDenum = Convert.ToInt32(txtWidthDNum.Text);
                            tBoardItem.Fins = Convert.ToInt32(cboFins.SelectedValue);
                            tBoardItem.Model = Global.CheckString(txtModelPost.Text);
                            break;
                        case 2: //wanted
                            tBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                            tBoardItem.HtFt = Convert.ToInt32(txtHtFt.Text);
                            tBoardItem.HtIn = Convert.ToInt32(txtHtIn.Text);
                            break;
                        case 3: //showcase
                            tBoardItem.GearItem = Global.CheckString(txtGearItem.Text);
                            tBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                            tBoardItem.WebURL = Global.CheckString(txtWebURL.Text);
                            break;
                        case 4: //ShaperHouse
                            tBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                            tBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                            tBoardItem.Model = Global.CheckString(txtModel.Text);
                            tBoardItem.VideoLink = Server.HtmlEncode(txtVideo.Text);
                            break;
                    }
                    
                    break;

                case "2":   //snow
                    tBoardItem.HtFt = Convert.ToInt32(txtHtFt.Text);
                    tBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);

                    //TODO:
                    //switch (tmpBoardItem.AdType)
                    //{
                    //    case 1: //selling
                    //        break;
                    //    case 2: //wanted
                    //        break;
                    //    case 3: //showcase
                    //        break;
                    //}
                    
                    break;
                case "3":   //other boards
                    if (chkOther.Checked)
                    {
                        tBoardItem.OtherBoardType = Global.CheckString(txtOtherBoard.Text);
                    }
                    else
                    {
                        tBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                    }

                    tBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);

                    //TODO:
                    //switch (tmpBoardItem.AdType)
                    //{
                    //    case 1: //selling
                    //        break;
                    //    case 2: //wanted
                    //        break;
                    //    case 3: //showcase
                    //        break;
                    //}

                    break;
                case "4":   //gear
                    tBoardItem.GearItem = Global.CheckString(txtGearItem.Text);

                    //TODO:
                    //switch (tmpBoardItem.AdType)
                    //{
                    //    case 1: //selling
                    //        break;
                    //    case 2: //wanted
                    //        break;
                    //    case 3: //showcase
                    //        break;
                    //}

                    break;
            }

            if (tBoardItem == null)
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click(): End of funtion: BoardItem obj was null: SHOULD NEVER GET HERE");

            //Save object to session variable
            Session["Item"] = tBoardItem;
            tBoardItem = null;

            //????
            //tBoardItem = null;

            if (Session["Item"] == null)
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click(): EOF: SESSION obj was NULL");
            else
                ErrorLog.ErrorRoutine(false, "PI:btnNext_Click(): EOF: SESSION item OK");

            ErrorLog.ErrorRoutine(false, "going to post_prev");

            //Goto preview_post
            Response.Redirect("preview_post.aspx", false);
        }

/*
 * TODO: Still need to code for all cats and adtypes
 */ 
        private bool LoadForEdits(classes.BoardItem tempBoardItem)
        {
            bool retVal = false;

            //re-show pics
            if (tempBoardItem.AdType == (int)1 || tempBoardItem.AdType == (int)4)
            {
                img1.ImageUrl = "images/s1x1.gif";
                img2.ImageUrl = "images/s1x1.gif";
                img3.ImageUrl = "images/s1x1.gif";
                img4.ImageUrl = "images/s1x1.gif";
                string strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                if (tempBoardItem.ImgPath1.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBoardItem.ImgPath1.Split(splitter);
                    img1.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];
                    HiddenField1.Value = img1.ImageUrl;
                    pnlAddImages.Visible = true;
                    //show addImgPanel
                    pnlAddImages.Style.Add("Display", "Block");                    
                }
                else
                {
                    rdoImgMgr1.Items[2].Text = "Add";
                    rdoImgMgr1.Items.Remove("Delete");
                    rdoImgMgr1.Items.Remove("Keep");
                    File1.Disabled = true;
                }
                if (tempBoardItem.ImgPath2.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBoardItem.ImgPath2.Split(splitter);
                    img2.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];// tmpBoardItem.ImgPath1;
                    HiddenField2.Value = img2.ImageUrl;
                    pnlAddImages.Visible = true;
                }
                else
                {

                    rdoImgMgr2.Items[2].Text = "Add";
                    rdoImgMgr2.Items.Remove("Delete");
                    rdoImgMgr2.Items.Remove("Keep");
                    File2.Disabled = true;
               
                }
                if (tempBoardItem.ImgPath3.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBoardItem.ImgPath3.Split(splitter);
                    img3.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];
                    HiddenField3.Value = img3.ImageUrl;
                    pnlAddImages.Visible = true;
                }
                else
                {

                    rdoImgMgr3.Items[2].Text = "Add";
                    rdoImgMgr3.Items.Remove("Delete");
                    rdoImgMgr3.Items.Remove("Keep");
                    File3.Disabled = true;
                }
                if (tempBoardItem.ImgPath4.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBoardItem.ImgPath4.Split(splitter);
                    img4.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];
                    HiddenField4.Value = img4.ImageUrl;
                    pnlAddImages.Visible = true;
                }
                else
                {

                    rdoImgMgr4.Items[2].Text = "Add";
                    rdoImgMgr4.Items.Remove("Delete");
                    rdoImgMgr4.Items.Remove("Keep");
                    File4.Disabled = true;                   
                }
            }

            switch (tempBoardItem.Category)
            {
                case 1:
                    cboBoardType.SelectedValue = tempBoardItem.BoardType.ToString();
                    txtHtFt.Text = tempBoardItem.HtFt.ToString();
                    txtHtIn.Text = tempBoardItem.HtIn.ToString();
                    txtPrice.Text = tempBoardItem.Price.ToString();
                    txtDetails.Text = tempBoardItem.Details.ToString();
                    //if (tempBoardItem.AdType == (int)1)  //selling only

                    switch (tempBoardItem.AdType)
                    {
                        case 1:
                            txtBrand.Text = tempBoardItem.Brand.ToString();
                            txtWidth.Text = tempBoardItem.Width.ToString();
                            txtWidthDNum.Text = tempBoardItem.WidthDenum.ToString();
                            txtWidthNum.Text = tempBoardItem.WidthNum.ToString();
                            txtThick.Text = tempBoardItem.Thickness.ToString();
                            txtThickDNum.Text = tempBoardItem.ThickDenum.ToString();
                            txtThickNum.Text = tempBoardItem.ThickNum.ToString();
                            cboFins.SelectedValue = tempBoardItem.Fins.ToString();
                            cboTailType.SelectedValue = tempBoardItem.TailType.ToString();

                            break;

                        case 4:
                            txtModel.Text = tempBoardItem.Model;
                            txtGenDims.Text = tempBoardItem.GenDimensions;
                            break;
                    }

                    retVal = true;
                    break;
            }
            return retVal;
        }

		//=================================
		//Error Checking & Helper Functions
		//=================================

        private void FillDropDowns(string category)
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "'; SELECT * FROM LK_TailType ; SELECT * FROM LK_FinType";

            SqlConnection myConnection = new SqlConnection(myConnectString);
            DataSet dsItems = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {

                // Read sample item info from SQL into a DataSet
                objAdapter.TableMappings.Add("Table", "tblBoardType");
                objAdapter.TableMappings.Add("Table1", "tblTail");
                objAdapter.TableMappings.Add("Table2", "tblFins");

                objAdapter.Fill(dsItems);

                cboBoardType.DataSource = dsItems;
                cboBoardType.DataMember = "tblBoardType";
                cboBoardType.DataTextField = "BoardType";
                cboBoardType.DataValueField = "iD";
                cboBoardType.DataBind();
                //cboBoardType.SelectedIndex = (int)0;

                cboTailType.DataSource = dsItems;
                cboTailType.DataMember = "tblTail";
                cboTailType.DataTextField = "TailType";
                cboTailType.DataValueField = "iD";
                cboTailType.DataBind();
                cboTailType.SelectedIndex = (int)0;

                cboFins.DataSource = dsItems;
                cboFins.DataMember = "tblFins";
                cboFins.DataTextField = "finType";
                cboFins.DataValueField = "iD";
                cboFins.DataBind();
                cboFins.SelectedIndex = (int)2;
            }
            catch
            {
                ErrorLog.ErrorRoutine(false, "Error: post_item: FillDropDowns()");
                classes.Email.SendErrorEmail("Error: post_item: FillDropDowns()");
             }

            finally
            {
                dsItems.Dispose();
                objAdapter.Dispose();
                myConnection.Close();  
            }

      

        }
/*
 */ 
        protected void btnShowPnl_Click(object sender, System.EventArgs e)
		{
		
			lblStatus.Text = "";
			
			if (!pnlAddImages.Visible)
			{
				pnlAddImages.Visible = true;
                //btnShowPnl.Text = "No Images...";
			}
			else 
			{
				pnlAddImages.Visible = false;
                //btnShowPnl.Text = "Add Images...";
			}
		}
/*
 */ 
		private static string GenerateRandomString(int intLenghtOfString)
		{
			//Create a new StrinBuilder that would hold the random string.
			StringBuilder randomString = new StringBuilder();
			//Create a new instance of the class Random
			Random randomNumber = new Random();
			//Create a variable to hold the generated charater.
			Char appendedChar;
			//Create a loop that would iterate from 0 to the specified value of intLenghtOfString
			for(int i= 0; i<= intLenghtOfString; ++i)
			{
				//Generate the char and assign it to appendedChar
				appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
				//Append appendedChar to randomString
				randomString.Append(appendedChar);
			}
			//Convert randomString to String and return the result.
			return randomString.ToString();
		}
		//===========================
		//Validation helper functions
		//===========================
		//
		//Helper function to determine if value is numeric
		private bool IsNumeric(object valType)
		{
			double tempVal = new double();
			string InputValue = Convert.ToString(valType);

			bool Numeric = double.TryParse(InputValue ,System.Globalization.NumberStyles.Any , null , out tempVal);
		
			return Numeric;
		}
/*
 */ 
		protected void CheckBrand(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
            args.IsValid = true;
            
            if (txtBrand.Text == "")
			{
				txtBrand.Text = "unknown";
			}

            if (txtBrand.Text.IndexOf("<script>")> -1)
            {
                args.IsValid = false;
                CustomValidator2.Text = "!";
            }
		}

/*       
*/
		protected void CheckHeight(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = true;                //all okay unless otherwise denoted below

            //check feet ...do we have a value?
            if (txtHtFt.Text.Length > 0)
            {
                //not numeric so raise error
                if (!IsNumeric(txtHtFt.Text))
                {
                    CustomValidator3.ErrorMessage = "&nbsp;enter in a value&nbsp;";
                    ShowErrorMessage(false, strErrHeight);
                    args.IsValid = false;
                    return;
                }

                if (txtHtFt.Text.Contains("."))
                {
                    CustomValidator3.ErrorMessage = "&nbsp;enter in a value&nbsp;";
                    ShowErrorMessage(false, strErrHeight);
                    args.IsValid = false;
                }
            }
            else //we must not have a value
            {
                CustomValidator3.ErrorMessage = "&nbsp;enter in a value&nbsp;";
                ShowErrorMessage(false, strErrHeight);
                args.IsValid = false;
                return;
            }

    		
            //check inches...do we have a value?
            if (txtHtIn.Text.Length > 0)
            {
                //is it a number
                if (!IsNumeric(txtHtIn.Text))
                {
                    CustomValidator3.ErrorMessage = "!";
                    ShowErrorMessage(false, strErrHeight);
                    args.IsValid = false;
     
                }
                if (txtHtIn.Text.Contains("."))
                {
                    CustomValidator3.ErrorMessage = "!";
                    ShowErrorMessage(false, strErrHeight);
                    args.IsValid = false;
                }

                //is it over 11?
                if (Convert.ToInt32(txtHtIn.Text) > (int)11)
                {
                    CustomValidator3.ErrorMessage = "Too many inches!";
                    ShowErrorMessage(false, strErrHeight);
                    args.IsValid = false;
                    
                }

            }
            //if it's empty set it to zero
            else
            {
                txtHtIn.Text = "0";
         
            }
            
            //check for script insertion
            if (txtHtFt.Text.IndexOf("<script>") > -1 || txtHtIn.Text.IndexOf("<script>") > -1)
            {
                args.IsValid = false;
                ShowErrorMessage(false, strErrHeight);
                CustomValidator3.Text = "!"; 
            }
		}
/*
 */ 
		protected void CheckWidth(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = true;


            //cehck for a val in the first box
            if (txtWidth.Text.Length > 0)
            {

                if (txtWidth.Text.Contains("."))
                {
                    CustomValidator4.ErrorMessage = "use fractions";
                    ShowErrorMessage(false, strErrWidth);
                    args.IsValid = false;
                }
                
                //Check for numeric entries
                if ((!IsNumeric(txtWidth.Text) && txtWidth.Text != string.Empty) || ((!IsNumeric(txtWidthDNum.Text) && txtWidthDNum.Text != string.Empty) && (!IsNumeric(txtWidthNum.Text) && txtWidthNum.Text != string.Empty)))
                {
                    CustomValidator4.ErrorMessage = "!";
                    ShowErrorMessage(false, strErrWidth);
                    args.IsValid = false;
                    return;
                }
                //We know there are no non-numerical vals at this point but possible empty vals
                else
                {
    
                        //Check for div by 0 and denom > num
                        if (txtWidthDNum.Text.Length > 0 && txtWidthNum.Text.Length > 0 )
                        {
 
                            // allow a zero for denom only if others are zero
                            if (Convert.ToInt32(txtWidthDNum.Text) == (int)0)
                            {
                                if (txtWidthNum.Text != "0" && txtWidth.Text != "0")
                                {
                                    CustomValidator4.ErrorMessage = "!";
                                    ShowErrorMessage(false, strErrWidth);
                                    args.IsValid = false;
                                    return;
                                }
                            }

                            //check for improper fraction
                            if (Convert.ToInt32(txtWidthNum.Text) > Convert.ToInt32(txtWidthDNum.Text))
                            {
                                CustomValidator4.ErrorMessage = "!";
                                ShowErrorMessage(false, strErrWidth);
                                args.IsValid = false;
                                return;
                            }
                        }

                        else //whole number < 0 or empty; Zero out vals
                        {
   
                            txtWidthDNum.Text = "0";
                            txtWidthNum.Text = "0";
                        }
                }
            }

            
           //entry was blank; set to zero unless vals for num and denum
            else 
            {
                //check for a val in either num or denom
                if ((txtWidthDNum.Text.Length > 0) || (txtWidthNum.Text.Length > 0))
                {
                    CustomValidator4.ErrorMessage = "!";
                    ShowErrorMessage(false, strErrWidth);
                    args.IsValid = false;
                    return;
                }
                //everybody's blank
                else
                {
                    txtWidth.Text = "0";
                    txtWidthDNum.Text = "0";
                    txtWidthNum.Text = "0";
                }
            }

             //check for evil script insertion
            if (txtWidth.Text.IndexOf("<script>") > -1 || txtWidthNum.Text.IndexOf("<script>") > -1 || txtWidthDNum.Text.IndexOf("<script>") > -1)
            {
                args.IsValid = false;
                ShowErrorMessage(false, strErrWidth);
                CustomValidator4.Text = "!";
            }

		}
/*
*/
        protected void CheckThickness(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            //init to true; similar to innocent until proven guilty
            args.IsValid = true;

                //filter out if we at least have a length
                if (txtThick.Text.Length > 0) //&& txtThickNum.Text.Length > 0 && txtThickDNum.Text.Length > 0)
                {

                    if (txtThick.Text.Contains("."))
                    {
                        CustomValidator1.ErrorMessage = "&nbsp;use fractions&nbsp;";
                        ShowErrorMessage(false, strErrThick);
                        args.IsValid = false;
                    }
                    
                    //Check for any non-numeric entries
                    if ((!IsNumeric(txtThick.Text) && txtThick.Text.Length > 0) || (!IsNumeric(txtThickDNum.Text) && txtThickDNum.Text.Length > 0) || (!IsNumeric(txtThickNum.Text) && txtThickNum.Text.Length > 0))
                    {
                        CustomValidator1.ErrorMessage = "!";
                        ShowErrorMessage(false, strErrThick);
                        args.IsValid = false;
                    }
                    //could be blank entry or numerical
                    else
                    {

                        if (txtThickNum.Text.Length > 0 && txtThickDNum.Text.Length > 0)
                        {
                            if (Convert.ToInt32(txtThickDNum.Text) == (int)0)
                            {
                                if (txtThickNum.Text != "0" && txtThick.Text != "0")
                                {
                                    CustomValidator1.ErrorMessage = "!";
                                    ShowErrorMessage(false, strErrThick);
                                    args.IsValid = false;
                                }
                            }
                            if (Convert.ToInt32(txtThickNum.Text) > Convert.ToInt32(txtThickDNum.Text))
                            {

                                CustomValidator1.ErrorMessage = "!";
                                ShowErrorMessage(false, strErrThick);
                                args.IsValid = false;
                            }
                        }
                        else
                        {
                            txtThickNum.Text = "0";
                            txtThickDNum.Text = "0";
                        }
                    }
                }
                    
                else //allow all blanks and set to zero; if either num or dnum has val then throw an error
                {
                    if ((txtThickNum.Text.Length > (int)0) || (txtThickDNum.Text.Length > (int)0))
                    {

                        CustomValidator1.ErrorMessage = "!";
                        ShowErrorMessage(false, strErrThick);
                        args.IsValid = false;
                        
                    }
                    else
                    {
                        txtThick.Text = "0";
                        txtThickNum.Text = "0";
                        txtThickDNum.Text = "0";
                    }
                }
                
       
            if (txtThick.Text.IndexOf("<script>") > -1 || txtThickDNum.Text.IndexOf("<script>") > -1 || txtThickNum.Text.IndexOf("<script>") > -1)
            {
                args.IsValid = false;
                ShowErrorMessage(false, strErrThick);
                CustomValidator1.Text = "!";
            }

        }
/*
*/
        public void CheckPrice(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			
            double tempVal;

			args.IsValid = true;

            if (pnlVideo.Visible == true)
                return;

            //strip out dollar sign if present
            if (txtPrice.Text.IndexOf("$") != -1)
            {
                txtPrice.Text = Global.StrReplace(txtPrice.Text, @"\$");
                 
            }

			if (!IsNumeric(txtPrice.Text))
			{
				args.IsValid = false;
                ShowErrorMessage(false, strErrPrice);
                CustomValidator5.ErrorMessage = "&nbsp;enter in a price&nbsp;";
			}
			
			try
			{
				tempVal = Convert.ToDouble(txtPrice.Text);
			}
			
			catch
			{
                CustomValidator5.ErrorMessage = "&nbsp;enter in a price&nbsp;";
                ShowErrorMessage(false, strErrPrice);
				args.IsValid = false;
			}
			

		}

/*
 */ 
        public void CheckDetails(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
            
        }

/*
 */
        public void HideErrorMessages()
        {
            lblError.Visible = false; 
            lblInstructions.Text = "Step 2.&nbsp;&nbsp;Sell this thing";
            lblInstructions.CssClass = "white20b";
        } 

/*
        //Here we check the file type and size.  Halt processing any further if the wrong file type or too big o' size is detected.
*/
        //public void CheckUploadedFiles(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        public bool CheckUploadedFiles()
		{

            //TODO: 4 megs is the maxium request length by default. You can change this in your
            //web.config by specifying a maxRequestLength, in KB, in your HttpRuntime of
            //the system.web:

            //check file types without checking radio buttons

            HttpFileCollection uploadFilCol = Request.Files;
            int count = uploadFilCol.Count;
            ErrorLog.ErrorRoutine(false, "FileCnt: " + count + " SID: " + Session.SessionID);

            for (int i = 0; i < count; i++)
            {

                //get handle to file
                HttpPostedFile file = uploadFilCol[i];

                //get file name & ext
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(file.FileName).ToLower();
                int IntFileSize = file.ContentLength;

                ErrorLog.ErrorRoutine(false, "File " + i + ":" + IntFileSize);

                //Check for file type and size:
                //The main reason we're doing it here an not during the UploadAllImages function 
                //is to validate everything first before uploading anything
                if (fileName != string.Empty)
                {
                    if ((!Regex.IsMatch(file.ContentType, "(.gif|.jpg|.jpeg|.bmp|.png)")))
                    {
                        lblError.Text = lblInstructions.Text = "Wrong file type. Try using a jpg, gif, png, or bmp.";
                        lblError.ForeColor = lblInstructions.ForeColor = Color.Black;
                        lblError.BackColor = lblInstructions.BackColor = Color.Pink;
                        lblError.BorderColor = lblInstructions.BorderColor = Color.Red;
                        lblError.BorderWidth = lblInstructions.BorderWidth = 1;
                        lblError.Visible = true;
                        return false;
                    }
                    //check for 2.5 MB max
                    if (IntFileSize <= 0 || IntFileSize >= 2621440)
                    {
                        lblError.Text = lblInstructions.Text = "File too big. Scale it down and try again.";
                        lblError.ForeColor = lblInstructions.ForeColor = Color.Black;
                        lblError.BackColor = lblInstructions.BackColor = Color.Pink;
                        lblError.BorderColor = lblInstructions.BorderColor = Color.Red;
                        lblError.BorderWidth = lblInstructions.BorderWidth = 1;
                        lblError.Visible = true;
                        return false;
                    }

                }
            }
            return true;
		}
/*
*/
        //private void btnNext_Click(object sender, System.EventArgs e)
        //{


        //}
/*
*/
        private void btnBack_Click(object sender, System.EventArgs e)
        {
            //if ShaperHouse posting...
            if (hdnAdType.Value == "4")
            {
                Response.Redirect("UserMenu.aspx", true);
            }
            else
            {
                classes.BoardItem oBoardItem = (classes.BoardItem)Session["Item"];
                oBoardItem.EditMode = true;
                Session["Item"] = oBoardItem;
                Response.Redirect("post.aspx", true);
            }

        }
/*
*/
        private void lnkSignIn_Click(object sender, System.EventArgs e)
		{
				
			Global.NavigatePage(lnkSignIn.Text);

		}
/*
*/
		private void lnkSignUp_Click(object sender, System.EventArgs e)
		{
			Global.NavigatePage(lnkSignUp.Text);
			
		}
/*		
*/        
        private void lnkPost_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("post.aspx", true);
		}
        
        public void ResetImgMgr()
        {
            ListItem li = new ListItem("None", "0");

            if (!rdoImgMgr1.Items.Contains(li))
            {
                rdoImgMgr1.Items.Add(li);
                rdoImgMgr1.SelectedValue = "0";
            }
            if (!rdoImgMgr2.Items.Contains(li))
            {
                rdoImgMgr2.Items.Add(li);
                rdoImgMgr2.SelectedValue = "0";
            }
            if (!rdoImgMgr3.Items.Contains(li))
            {
                rdoImgMgr3.Items.Add(li);
                rdoImgMgr3.SelectedValue = "0";
            }
            if (!rdoImgMgr4.Items.Contains(li))
            {
                rdoImgMgr4.Items.Add(li);
                rdoImgMgr4.SelectedValue = "0";
            }        
        }
/*
*/
        public bool UpdateEntryCount(string uiD, string conn)
		{
			bool retVal;
			SqlConnection myConnection = new SqlConnection(conn);
			string strSQL = "UPDATE tblUser SET iEntryCount = iEntryCount + 1 WHERE iD = '" + uiD + "'";
			

			try
			{
				myConnection.Open();
				SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				objCommand.ExecuteNonQuery();
				retVal = true;
			}
			catch( Exception ex)
			{
                ErrorLog.ErrorRoutine(false, "Error:Post_item:UpdateEntryCount(): " + ex.Message);

                lblStatus.Text = "UPDATE ERROR";
				retVal = false;
			}
			finally
			{
				myConnection.Close();
				
			}
			return retVal;
			
		}
/*
*/       string buildScript(string id, string output_page)
        {
            string myScript = "\n";

            myScript += "<script language='javascript' id='" + id + "'>\n";
            myScript += "window.open('" + output_page + "','anyWho','width=200,height=200,resizable=no'); \n";
            myScript += "</" + "script>\n";

            return myScript;
        }

        private void ShowErrorMessage(Boolean endResp, string msg)
        {

            pnlError.Visible = true;
            lblErrMsg.Text = msg;
            lblErrMsg.Visible = true;
            hypClose.Visible = false;

            ErrorLog.ErrorRoutine(false, "Error:PI:ShowErrorScreen:SessionID: " + Session.SessionID + " ErrorMsg: " + msg);
            
            if (endResp)
            {
                //log and notify BH
                classes.Email.SendErrorEmail("Error:PI:ShowErrorScreen:SessionID: " + Session.SessionID);
                hypClose.Visible = true;
                pnlItem.Visible = false;
                Response.End();
                return;
            }
        }
        
/**
*/
        public string DecodeiCat(object iCat)
        {
            return Global.ReplaceEx(Enum.GetName(typeof(Global.BOARDCAT_TYPE), iCat), "_", " ");
        }

/*
 */ 
        void lnkHlpBoard_Click(object sender, EventArgs e)
        {
            string script_id = "popup";
            string myScript = buildScript(script_id, "help/board_help.aspx");
            if (!IsClientScriptBlockRegistered(script_id))
            {
                RegisterClientScriptBlock(script_id, myScript);
                //RegisterStartupScript(script_id, myScript);
            }
        }

/*
* Upload any/all images
*/
        private classes.BoardItem UpLoadAllImages(classes.BoardItem bItem, string[] strImgPathArray)
        {
            ErrorLog.ErrorRoutine(false, "UpLoadAllImages" );
            
            string tmpFile;
            string thmbNailPath;
            string userDir = "";

            //get user dir
            userDir = Session["userDir"].ToString();

            if (bItem == null)
            {
                ErrorLog.ErrorRoutine(false, "Post_item:UploadAllImages():bItem NULL!");
            }


            //if panel is open check for loaded img files
            if (pnlAddImages.Visible)
            {

                //Collect files names, iterate through each and update accordingly
                HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
                int count = uploadFilCol.Count;

                if (count < 1)
                    return bItem;

                //loop thru for each posted file
                for (int i = 0; i < count; i++)
                {

                    //get handle to file
                    HttpPostedFile file = uploadFilCol[i];

                    if (file.ContentLength > (int)0)    //needed?  we already checked
                    {

                        //get file name & ext
                        string fileName = Path.GetFileName(file.FileName);
                        string fileExt = Path.GetExtension(file.FileName).ToLower();

                        //check for temp dir and create if non-existent
                        if (!(Directory.Exists(Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\"))))
                        {
                            Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\"));
                        }

                        //get physical path to temp dir for upload
                        string path = Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\");

                        ErrorLog.ErrorRoutine(false, "UpLoadAllImages:path: " + path);

                        //Generate random file name 
                        tmpFile = GenerateRandomString(8).ToLower();

                        //concatenate renamed file with ext
                        tmpFile = tmpFile + fileExt;

                        //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                        strImgPathArray[i] = Path.Combine(path, tmpFile);
                        //tmpStruct.tmpArray[i] = Path.Combine(path, tmpFile);
                        thmbNailPath = Path.Combine(path, "thmbNail_" + tmpFile);

                        //Upload to temp dir; we'll write to perm directory after user confirms on preview!
                        //FIXME: Check for file type and size

                        if (fileName != string.Empty)
                        {
                            //resize the image and save
                            //Create an image object from the uploaded file.

                            try
                            {
                                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(file.InputStream);
                                //Larger Image variables
                                int maxWidth = 400;
                                int maxHeight = 400;
                                int sourceWidth = UploadedImage.Width;
                                int sourceHeight = UploadedImage.Height;
                                int sourceX = 0;
                                int sourceY = 0;
                                int destX = 0;
                                int destY = 0;
                                float nPercent = 0;
                                float nPercentW = 0;
                                float nPercentH = 0;

                                //ThumbNail variables
                                int maxWidth_T = 75;
                                int maxHeight_T = 75;
                                int destX_T = 0;
                                int destY_T = 0;
                                float nPercent_T = 0;
                                float nPercentW_T = 0;
                                float nPercentH_T = 0;

                                //Larger Image percents
                                nPercentW = ((float)maxWidth / (float)sourceWidth);
                                nPercentH = ((float)maxHeight / (float)sourceHeight);

                                //Thumbnail percents
                                nPercentW_T = ((float)maxWidth_T / (float)sourceWidth);
                                nPercentH_T = ((float)maxHeight_T / (float)sourceHeight); 

                                //Find the biggest change(smallest pct)
                                if (nPercentH < nPercentW)
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentH;
                                    destX = System.Convert.ToInt16((maxWidth -
                                                  (sourceWidth * nPercent)) / 2);

                                    //Thumbnail Calculations
                                    nPercent_T = nPercentH_T;
                                    destX_T = System.Convert.ToInt16((maxWidth_T -
                                                  (sourceWidth * nPercent_T)) / 2);
                                }
                                else
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentW;
                                    destY    = System.Convert.ToInt16((maxHeight -
                                                  (sourceHeight * nPercent)) / 2);
                                    
                                    //ThumbNail Calculations
                                    nPercent_T = nPercentW_T;
                                    destY_T    = System.Convert.ToInt16((maxWidth_T -
                                                  (sourceHeight * nPercent_T)) / 2);
                                }

                                //Larger Image Calculations
                                int destWidth  = (int)(sourceWidth * nPercent);
                                int destHeight = (int)(sourceHeight * nPercent);

                                //Smaller Image Calculations
                                int destWidth_T  = (int)(sourceWidth * nPercent_T);
                                int destHeight_T = (int)(sourceHeight * nPercent_T);

                                //create the larger bitmap
                                Bitmap bmPhoto = new Bitmap(maxWidth, maxHeight);
                                bmPhoto.SetResolution(UploadedImage.HorizontalResolution,
                                                 UploadedImage.VerticalResolution);

                                //create the thumbnail bitmap
                                Bitmap bmPhotoThmbNail = new Bitmap(maxWidth_T, maxHeight_T);
                                bmPhotoThmbNail.SetResolution(UploadedImage.HorizontalResolution,
                                                          UploadedImage.VerticalResolution);

                                //create larger graphic
                                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                grPhoto.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                grPhoto.Clear(Color.Transparent);
                                grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                grPhoto.DrawImage(UploadedImage,
                                    new Rectangle(destX, destY, destWidth, destHeight),
                                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                                    GraphicsUnit.Pixel);

                                //create thumbnail graphic
                                Graphics grPhotoThmbNail = Graphics.FromImage(bmPhotoThmbNail);
                                grPhotoThmbNail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                grPhotoThmbNail.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                grPhotoThmbNail.Clear(Color.Transparent);
                                grPhotoThmbNail.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                grPhotoThmbNail.DrawImage(UploadedImage,
                                    new Rectangle(destX_T, destY_T, destWidth_T, destHeight_T),
                                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                                    GraphicsUnit.Pixel);

                                //int memberID = 0;

                                //Save the Image(s)
                                // (1) "Saves" the graphic.  It really just updates the bitmap with the contents of the graphic.  
                                // Basically saving it in memory.
                                // (2) Actually save the bitmap to the file system.

                                //Larger
                                grPhoto.Save();                  //  (1)
                                bmPhoto.Save(strImgPathArray[i]);//  (2)  .., ImageFormat.Jpeg)
                                
                                //strip out the superfluous server path and just save the file name;  this was the cause of much grief as we were saving the entire path!
                                strImgPathArray[i] = Path.GetFileName(strImgPathArray[i]);

                                //Thumbnail
                                grPhotoThmbNail.Save();
                                bmPhotoThmbNail.Save(thmbNailPath);

                                //Find out who is set to "change" or "add" so we know who to update
                                //  - We call the clearSelection() to let ourselves know that index has been processed
                                //TODO: append  (&& File1.Value.Length>0)
                                if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
                                {

                                    bItem.ImgPath1 = strImgPathArray[i];
                                    rdoImgMgr1.ClearSelection();

                                }
                                else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                {

                                    bItem.ImgPath2 = strImgPathArray[i];
                                    rdoImgMgr2.ClearSelection();

                                }
                                else if (rdoImgMgr3.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                {


                                    bItem.ImgPath3 = strImgPathArray[i];
                                    rdoImgMgr3.ClearSelection();
                                }
                                else
                                {
                                    if (rdoImgMgr4.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                    {

                                        bItem.ImgPath4 = strImgPathArray[i];
                                        rdoImgMgr4.ClearSelection();
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorRoutine(false, "Post_Item:UpdateAllImages-Error: " + ex.Message); 
                                lblStatus.Text = "Resize/Save Error!";
                            }

                        }
                        else
                        {
                            strImgPathArray[i] = string.Empty;
                        }
                    }
                }
            }//end main if
            //return strImgPathArray;
            return bItem;
        
        }//end function

        protected void InitImgUploader()
        {
                    //TODO: stub this out
                    //setup pic panel for first time thru; 
                    img1.ImageUrl = "images/s1x1.gif";
                    img2.ImageUrl = "images/s1x1.gif";
                    img3.ImageUrl = "images/s1x1.gif";
                    img4.ImageUrl = "images/s1x1.gif";

                    rdoImgMgr1.Items[2].Text = "Add";
                    rdoImgMgr1.Items.Remove("Delete");
                    rdoImgMgr1.Items.Remove("Keep");
                    File1.Disabled = true;

                    rdoImgMgr2.Items[2].Text = "Add";
                    rdoImgMgr2.Items.Remove("Delete");
                    rdoImgMgr2.Items.Remove("Keep");
                    File2.Disabled = true;

                    rdoImgMgr3.Items[2].Text = "Add";
                    rdoImgMgr3.Items.Remove("Delete");
                    rdoImgMgr3.Items.Remove("Keep");
                    File3.Disabled = true;

                    rdoImgMgr4.Items[2].Text = "Add";
                    rdoImgMgr4.Items.Remove("Delete");
                    rdoImgMgr4.Items.Remove("Keep");
                    File4.Disabled = true;        
        }

/*
 * Handle the null object item error
 */
        private void HandleError()
        {
            ErrorLog.ErrorRoutine(false, "Error:PI:Page_Load:HandleError(): oBoardItem was NULL: Server: " + System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + " SessionID: + " + Session.SessionID + " isPB: " + Page.IsPostBack);
            
            //StackTrace stackTrace = new StackTrace();           // get call stack
            //StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)

            //// write call stack method names
            //foreach (StackFrame stackFrame in stackFrames)
            //{
            //    ErrorLog.ErrorRoutine(false, stackFrame.GetMethod().Name);   // write method name
            //}

            //log and notify BH
            classes.Email.SendErrorEmail("Error:PI: page_load: Item was NULL: isPB: " + Page.IsPostBack);

            //show error and re-login
            pnlError.Visible = true;
            pnlItem.Visible = false;
        }
    
    }//end class
}
