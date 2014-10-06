//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			qp.Post.apx.cs
/// 
///		Project log:	
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
using DALLayer;


namespace BoardHunt.qp
{
	/// <summary>
	/// Summary description for Post.
	/// </summary>
	/// 
	
	public partial class Post : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButtonList radioFins;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button CmdUpload;
        protected System.Web.UI.WebControls.LinkButton lnkHlpBoard;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.DropDownList cboCategory;
        

        protected const int picSizeBigX = 75;
        protected const int picSizeBigY = 75;

        //protected const int picSizeThmbX = 75;
        //protected const int picSizeThmbY = 75;

        protected const string ERR_MSG_BAD_PIC = "Please upload a valid picture in jpg, png or gif format.";
        protected const string ERR_MSG_INVALID_FORM = "One of your entries was invaild.  Please check again and correct.";

		protected void Page_Load(object sender, System.EventArgs e)
		{

            //if 1st coupon then redirect to get footer settings
            if (!CheckForFooterSettings())
                Response.Redirect("Settings.aspx?r=1", true);

			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            SetUI();

            if (!Page.IsPostBack)
            {
                //authenticate
                Global.AuthenticateUser();

                BindControls();

                //check for edits from manager
                string[] arrStr;
                arrStr = Request.QueryString.GetValues("q");
                if (arrStr != null)
                {
                    hdnBackToMgr.Value = "1";
                    LoadForEdits(arrStr[0]);
                    return;
                }

                //check for edits from preview
                if (Session["cItem"] != null)
                {
                    classes.Coupon cpItem = new classes.Coupon();
                    cpItem = (classes.Coupon)Session["cItem"];
                    if (cpItem.EditMode == 1)
                    {
                        LoadForEdits(cpItem);
                    }
                }
                else
                {
                    InitImgMgr();
                }
            }
		}
/*
 */
        protected void SetUI()
        {

            //hide fakie button
            btnNextFake.Style.Add("Display", "None");
            btnNextFake.Style.Add("Class", "btnNext");        
        }

        protected bool CheckForFooterSettings()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "SELECT iD FROM tblAddress WHERE iUser = " + Session["userId"].ToString();

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Post:Check4Footer:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
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
        public void BindData(classes.Coupon cI)
        {
            //sets the dynamic UI up according to category
            //FillDropDowns();

            //TODO: SetupUI();
        }
/*
*/
        
/*
 * Things to keep in mind here for this event handler:
 *      - we process all board types here including gear
 *      - we process wanted ads too which is a very limited subset including only 
 *        category, boardtype, region, town, details, and price maybe
*/
        
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Post:btnNext_Click: " + Session.SessionID);
            
            //TODO: Resolve how Preview will know where the srctempdir is located (2 places)
            // we know if we're updating by checking oItem.Id
            //that's all

            classes.Coupon oItem;

            HttpFileCollection uploadFilCol = Request.Files;
            if (uploadFilCol.Count < 1)
                chkDefaultImg.Checked = true;

            //pre-check file type
            if (!chkDefaultImg.Checked)
            {
                if (!CheckUploadedFiles())
                {
                    ResetImgMgr();
                    ErrorLog.ErrorRoutine(false, "Post:btnNext_Click:CheckUploadedFiles failed");
                    ShowError(false, ERR_MSG_BAD_PIC);
                    return;
                }
            }

            //validate form
            if (!(Page.IsValid))
            {
                //re-set anything here that needs a reset
                ErrorLog.ErrorRoutine(false, "Post:btnNext_Click:PageNotValid");
                ResetImgMgr();
                ShowError(false, ERR_MSG_INVALID_FORM);
                return;
            }

            if (txtTitle.Text.Length < 1)
            {
                ShowError(false, "Coupon title needs a valid entry.");
                return;
            }

            //New or Editing a coupon?
            if (Session["cItem"] != null)
            {
                oItem = (classes.Coupon)Session["cItem"];
            }
            else
            {

                //start fresh 
                oItem =  new classes.Coupon();

                //check for manager edit; we will know if there's an id from the query string
                if (hdnEntryId.Value != "-1")
                {

                    //get status: active or in-active
                    if (hdnStatus.Value.Length > 0)
                        oItem.Status = Convert.ToInt32(hdnStatus.Value);    //tells us if the coupon is active or not
                    else 
                        oItem.Status = 0;   //not active

                    oItem.EditMode = 2;     //editing via manager
                    oItem.EntryId = Convert.ToInt32(hdnEntryId.Value);
                }
            }

            if (!chkDefaultImg.Checked)
                oItem.UseDefaultImg = false;
            else
                oItem.ImgPath1 = string.Empty;

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, Delete, Change
            //Pics will be uploaded to temp then moved to userdir once user accepts final approval in Preview page.
            //Delete any files in imgDel array
            bool blnProcImgs = false;

            if (!oItem.UseDefaultImg)
            {
                switch (rdoImgMgr1.SelectedValue)
                {
                    case "Keep":
                        if (oItem.EditMode == 2)
                        {
                            oItem.UseTempDir = 0;
                            oItem.ImgPath1 = hdnImgPath.Value;
                        }
                        break;
                    case "Delete":
                        oItem.ImgPath1 = string.Empty;
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

                //Process images / *video
                if (blnProcImgs)
                {
                    //init pic array holder
                    string[] strImgPathArray = new string[2];
                    for (int j = 0; j <= 1; j++)
                    {
                        strImgPathArray[j] = string.Empty;
                    }

                    oItem = UpLoadAllImages(oItem, strImgPathArray);
                }

            }

            oItem.Category = Convert.ToInt32(cboCategory.SelectedValue);
            string tmpDetails = txtDetails.Text;

            //truncate characters after 140.
            if (tmpDetails.Length > 140)
            {
                oItem.Details = tmpDetails.Remove(140, tmpDetails.Length - 140);
            }

            string tmpStr;
            tmpStr = Global.CheckString(txtDetails.Text);
            tmpStr = Regex.Replace(tmpStr, @"\s+", " ").Trim();
            oItem.Details = tmpStr;

            oItem.Title = Global.CheckString(txtTitle.Text);
            oItem.CCode = txtCode.Text;

            if (txtDate.Text.Length > 0)
                oItem.Expired = Convert.ToDateTime(txtDate.Text);

            //Save object to session variable
            Session["cItem"] = oItem;

            //Goto preview_post
            Response.Redirect("Preview.aspx", true);
        }

/*
 * TODO: Still need to code for all cats and adtypes
 */ 
        private bool LoadForEdits(classes.Coupon cItm)
        {

            txtDetails.Text = cItm.Details;
            txtTitle.Text = cItm.Title;
            txtCode.Text = cItm.CCode;
            if (cItm.Expired != null)
            {
                if (cItm.Expired != DateTime.MinValue)
                    txtDate.Text = cItm.Expired.ToString();
            }
            cboCategory.SelectedValue = cItm.Category.ToString();

            img1.ImageUrl = "../images/s1x1.gif";
            img2.ImageUrl = "../images/CouponDefault.gif";

            string strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
            if (cItm.ImgPath1.Length > (int)0)  //show pic
            {
                //get URL to show pic
                string path = strServerURL + @"/users/" + Session["userDir"].ToString();
                    if (cItm.UseTempDir == 1)
                        path += @"/temp/";
                string[] strArray;
                char[] splitter = { '\\' };
                strArray = cItm.ImgPath1.Split(splitter);
                img1.ImageUrl = path + strArray[strArray.Length - 1];
                hdnImgPath.Value = img1.ImageUrl;
            }
            else        //no pic was uploaded
            {
                rdoImgMgr1.Items[2].Text = "Add";
                rdoImgMgr1.Items.Remove("Delete");
                rdoImgMgr1.Items.Remove("Keep");
                File1.Disabled = true;
                chkDefaultImg.Checked = true;
            }
            return true;
        }

        private bool LoadForEdits(string iD)
        {
            string imgPath;
            string uDir;
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            hdnEntryId.Value = iD;

            strSQL = @"SELECT c.title, c.body, c.dAdded, c.dExpire, c.code, c.imgPath, c.CategoryId, c.iStatus, u.userDir 
                        FROM tblCoupon c                         
                        INNER JOIN tblUser u ON c.iUser = u.iD
                        WHERE c.iD = '" + iD + "'";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    txtDetails.Text = Global.ReplaceEx(dbManager.DataReader["body"].ToString(), "''", "'");
                    txtTitle.Text = Global.ReplaceEx(dbManager.DataReader["title"].ToString(), "''", "'");
                    txtCode.Text = dbManager.DataReader["code"].ToString();
                    imgPath = dbManager.DataReader["imgPath"].ToString();
                    cboCategory.SelectedValue = dbManager.DataReader["CategoryId"].ToString();
                    hdnImgPath.Value = imgPath;
                    uDir = dbManager.DataReader["userDir"].ToString();
                    hdnStatus.Value = dbManager.DataReader["iStatus"].ToString(); //are we active

                    if (dbManager.DataReader["dExpire"].ToString().Length > 1)
                    {
                        hdnExpDate.Value = dbManager.DataReader["dExpire"].ToString();
                        txtDate.Text = String.Format("{0: MM/dd/yyyy}", Convert.ToDateTime(dbManager.DataReader["dExpire"].ToString()));
                    }

                    img1.ImageUrl = "../images/s1x1.gif";
                    img2.ImageUrl = "../images/CouponDefault.gif";

                    string strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                    if (imgPath.Length > (int)0)  //show pic
                    {
                        //get URL to show pic
                        string path = strServerURL + @"/users/" + Global.ReplaceEx(uDir,@"\","/");
                        img1.ImageUrl = path + imgPath;
                    }
                    else //no pic was uploaded; USE Defualt
                    {
                        chkDefaultImg.Checked = true;
                        rdoImgMgr1.Items[2].Text = "Add";
                        rdoImgMgr1.Items.Remove("Delete");
                        rdoImgMgr1.Items.Remove("Keep");
                        File1.Disabled = true;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Post:LoadForEdits:Error:" + ex.Message);
                string msg = "Arg! A slight error occured.  The Boardhunt geeks are now working to fix this.  Please check back soon.";
                ShowError(true,msg);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

/*
 */ 
        //TODO: Obsolete
		private void imgBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            Session["cItem"] = null;
            if (hdnBackToMgr.Value == "1")
                Response.Redirect("Manager.aspx", true);
            else
                Response.Redirect("../UserMenu.aspx", true);
		}

		//=================================
		//Error Checking & Helper Functions
		//=================================

        private void FillDropDowns(string category)
        {

            try
            {

            }
            catch
            {

            }

            finally
            {

            }

        }
/*
 */
        protected void BindControls()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = "SELECT cat.Id, cat.Category FROM LK_Category cat WHERE GroupId = 2";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                //Category
                cboCategory.Items.Clear();
                cboCategory.DataSource = dsItems.Tables[0];
                //cboCategory.DataMember = "LK_Category";
                cboCategory.DataTextField = "Category";
                cboCategory.DataValueField = "iD";
                cboCategory.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Post:BindControls:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
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
            for (int i = 0; i < count; i++)
            {

                //get handle to file
                HttpPostedFile file = uploadFilCol[i];

                //get file name & ext
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(file.FileName).ToLower();
                int IntFileSize = file.ContentLength;

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
        private void btnBack_Click(object sender, System.EventArgs e)
        {
            Session["cItem"] = null;    
            Response.Redirect("../UserMenu.aspx", true);
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
			Response.Redirect("post.aspx");
		}
        
        public void ResetImgMgr()
        {
            ListItem li = new ListItem("None", "0");

            if (!rdoImgMgr1.Items.Contains(li))
            {
                rdoImgMgr1.Items.Add(li);
                rdoImgMgr1.SelectedValue = "0";
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
                ErrorLog.ErrorRoutine(false, "Error:Post:UpdateEntryCount(): " + ex.Message);

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

        private void ShowError(bool hideAll, string msg)
        {

            pnlError.Visible = true;
            if (msg.Length > 0)
                lblError.Text = msg;
            
            if (hideAll)
                pnlItem.Visible = false;

            //log and notify BH
            ErrorLog.ErrorRoutine(false, "Error:PI:ShowErrorScreen:SessionID: " + Session.SessionID);
            //classes.Email.SendErrorEmail("Error:PI:ShowErrorScreen:SessionID: " + Session.SessionID);

            return;        
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
        //TODO: FIX FIX FIX: new scale logic: scale only if needed. check images
        private classes.Coupon UpLoadAllImages(classes.Coupon bItem, string[] strImgPathArray)
        {
            string tmpFile;
            //string thmbNailPath;
            string userDir = string.Empty;

            //get user dir
            userDir = Global.ReplaceEx(Session["userDir"].ToString(),"/","\\");

            if (bItem == null)  //TODO: should return
                ErrorLog.ErrorRoutine(false, "Post:UploadAllImages():bItem NULL!");

            //if panel is open check for loaded img files
            if (pnlAddImages.Visible)
            {

                //Collect files names, iterate through each and update accordingly
                HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
                int count = uploadFilCol.Count;

                if (count < 1)  //TODO: set imgArray here?
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
                        string serverPath = Global.ReplaceEx(Server.MapPath(".\\"), "\\qp", string.Empty)  + @"users\" + userDir + @"temp\";
                        int noScale = 0;

                        ErrorLog.ErrorRoutine(false, "MP: " + serverPath);

                        //check for temp dir and create if non-existent
                        if (!(Directory.Exists(serverPath)))
                        {
                            //'E:\kunden\homepages\31\d213027625\qp\users\0\0\0\0\0\0\0\1\6\2\temp\'
                            //Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\"));
                            Directory.CreateDirectory(serverPath);
                        }

                        //get physical path to temp dir for upload
                        string path = serverPath;

                        //Generate random file name 
                        tmpFile = GenerateRandomString(8).ToLower();

                        //concatenate renamed file with ext
                        tmpFile = tmpFile + fileExt;

                        //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                        strImgPathArray[i] = Path.Combine(path, tmpFile);
                        //thmbNailPath = Path.Combine(path, "thmbNail_" + tmpFile);

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
                                int maxWidth = picSizeBigX;
                                int maxHeight = picSizeBigY;
                                
                                int sourceWidth = UploadedImage.Width;
                                int sourceHeight = UploadedImage.Height;

                                if ((sourceWidth > maxWidth) || (sourceHeight > maxHeight))
                                    noScale = 1;
                                
                                int sourceX = 0;
                                int sourceY = 0;
                                
                                int destX = 0;
                                int destY = 0;
                                
                                float nPercent = 0;
                                float nPercentW = 0;
                                float nPercentH = 0;

                                //ThumbNail variables
                                //int maxWidth_T = 75;
                                //int maxHeight_T = 75;
                                //int destX_T = 0;
                                //int destY_T = 0;
                                //float nPercent_T = 0;
                                //float nPercentW_T = 0;
                                //float nPercentH_T = 0;

                                //START scaling here but check first if we really need to

                                //Larger Image percents
                                nPercentW = ((float)maxWidth / (float)sourceWidth);
                                nPercentH = ((float)maxHeight / (float)sourceHeight);

                                //Thumbnail percents
                                //nPercentW_T = ((float)maxWidth_T / (float)sourceWidth);
                                //nPercentH_T = ((float)maxHeight_T / (float)sourceHeight); 

                                //Find the biggest change(smallest pct)
                                if (nPercentH < nPercentW)
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentH;
                                    destX = System.Convert.ToInt16((maxWidth -
                                                  (sourceWidth * nPercent)) / 2);

                                    //Thumbnail Calculations
                                    //nPercent_T = nPercentH_T;
                                    //destX_T = System.Convert.ToInt16((maxWidth_T -
                                    //              (sourceWidth * nPercent_T)) / 2);
                                }
                                else
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentW;
                                    destY    = System.Convert.ToInt16((maxHeight -
                                                  (sourceHeight * nPercent)) / 2);
                                    
                                    //ThumbNail Calculations
                                    //nPercent_T = nPercentW_T;
                                    //destY_T    = System.Convert.ToInt16((maxWidth_T -
                                    //              (sourceHeight * nPercent_T)) / 2);
                                }

                                //Larger Image Calculations
                                int destWidth  = (int)(sourceWidth * nPercent);
                                int destHeight = (int)(sourceHeight * nPercent);

                                ErrorLog.ErrorRoutine(false, "Dest H + W: " + destHeight + " " + destHeight);

                                //Smaller Image Calculations
                                //int destWidth_T  = (int)(sourceWidth * nPercent_T);
                                //int destHeight_T = (int)(sourceHeight * nPercent_T);

                                //create the larger bitmap
                                Bitmap bmPhoto = new Bitmap(maxWidth, maxHeight);
                                bmPhoto.SetResolution(UploadedImage.HorizontalResolution,
                                                 UploadedImage.VerticalResolution);

                                //create the thumbnail bitmap
                                //Bitmap bmPhotoThmbNail = new Bitmap(maxWidth_T, maxHeight_T);
                                //bmPhotoThmbNail.SetResolution(UploadedImage.HorizontalResolution,
                                //                          UploadedImage.VerticalResolution);

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
                                //Graphics grPhotoThmbNail = Graphics.FromImage(bmPhotoThmbNail);
                                //grPhotoThmbNail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                //grPhotoThmbNail.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                //grPhotoThmbNail.Clear(Color.Transparent);
                                //grPhotoThmbNail.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                //grPhotoThmbNail.DrawImage(UploadedImage,
                                //    new Rectangle(destX_T, destY_T, destWidth_T, destHeight_T),
                                //    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                                //    GraphicsUnit.Pixel);

                                //int memberID = 0;

                                //Save the Image(s)
                                // (1) "Saves" the graphic.  It really just updates the bitmap with the contents of the graphic.  
                                // Basically saving it in memory.
                                // (2) Actually save the bitmap to the file system.

                                //Larger
                                grPhoto.Save();                  //  (1)
                                bmPhoto.Save(strImgPathArray[i]);//  (2)  .., ImageFormat.Jpeg)
                                
                                //strip out the superfluous server path and just save the file name;  this was the cause of much grief as we were previously saving the entire path!
                                strImgPathArray[i] = Path.GetFileName(strImgPathArray[i]);

                                //Thumbnail
                                //grPhotoThmbNail.Save();
                                //bmPhotoThmbNail.Save(thmbNailPath);

                                bItem.UseTempDir = 1;   //use the temp dir to move pics
                                noScale = 0;            //reset scale flag

                                //Find out who is set to "change" or "add" so we know who to update
                                //  - We call the clearSelection() to let ourselves know that index has been processed
                                //TODO: append  (&& File1.Value.Length>0)
                                if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
                                {
                                    bItem.ImgPath1 = strImgPathArray[i];
                                    rdoImgMgr1.ClearSelection();
                                }
                                //else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                //{

                                //    bItem.ImgPath2 = strImgPathArray[i];
                                //    rdoImgMgr2.ClearSelection();

                                //}

                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorRoutine(false, "Post:UpdateAllImages:Error: " + ex.Message); 
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
            ErrorLog.ErrorRoutine(false, "Error:Post:Page_Error: " + strErrorMsg);

            //TODO: why not?
            //Server.ClearError();
        }

/*
 */
        protected void InitImgMgr()
        {
            img1.ImageUrl = "../images/s1x1.gif";
            img2.ImageUrl = "../images/CouponDefault.gif";

            rdoImgMgr1.Items[2].Text = "Add";
            rdoImgMgr1.Items.Remove("Delete");
            rdoImgMgr1.Items.Remove("Keep");
            File1.Disabled = true;

            //rdoImgMgr2.Items[2].Text = "Add";
            //rdoImgMgr2.Items.Remove("Delete");
            //rdoImgMgr2.Items.Remove("Keep");
            //File2.Disabled = true;        
        
        }
    
    }//end class
}
