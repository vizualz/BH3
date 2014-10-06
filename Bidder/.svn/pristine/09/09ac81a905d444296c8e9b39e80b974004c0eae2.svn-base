//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			BlogItem.apx.cs
///		Project log:	
///									 		 
///
//////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;
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


namespace BoardHunt.Blog
{
	/// <summary>
	/// Summary description for post_item.
	/// </summary>
	/// 

    public class BlogItem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlItem;

        //protected System.Web.UI.WebControls.Panel pnlGenDims;   //for Other Board cat
        //protected System.Web.UI.WebControls.Panel pnlGearItem;
        //protected System.Web.UI.WebControls.Panel pnlBoardType;
        //protected System.Web.UI.WebControls.Panel pnlBrand;
        protected System.Web.UI.WebControls.Panel pnlWeb;
        protected System.Web.UI.WebControls.Panel pnlAddImages;
        protected System.Web.UI.WebControls.Panel pnlAdTitle;


		protected System.Web.UI.WebControls.TextBox txtDetails;

        //protected System.Web.UI.WebControls.TextBox txtPrice;
        //protected System.Web.UI.WebControls.TextBox txtBrand;
        protected System.Web.UI.WebControls.TextBox txtWebURL;

        //protected System.Web.UI.WebControls.ImageButton imgBtnFinHelp;
        protected System.Web.UI.WebControls.ImageButton imgBtnHelp;

        protected System.Web.UI.WebControls.Button btnBack;
        protected System.Web.UI.WebControls.Button btnNext;


        protected System.Web.UI.WebControls.ImageButton imgContinue;
        protected System.Web.UI.WebControls.ImageButton imgBack;

        protected System.Web.UI.WebControls.LinkButton lnkHlpBoard;

		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputFile File2;
        protected System.Web.UI.HtmlControls.HtmlInputFile File3;
        protected System.Web.UI.HtmlControls.HtmlInputFile File4;

        protected System.Web.UI.WebControls.Button btnShowPnl;
		protected System.Web.UI.WebControls.Button CmdUpload;

        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label lblStatus;
        protected System.Web.UI.WebControls.Label lbl2;
        protected System.Web.UI.WebControls.Label lblCat;
        //protected System.Web.UI.WebControls.Label lblBrand;
        protected System.Web.UI.WebControls.Label lblWeb;
        protected System.Web.UI.WebControls.Label lblItem;
        //protected System.Web.UI.WebControls.Label lblFins;
        //protected System.Web.UI.WebControls.Label lblTail;
        //protected System.Web.UI.WebControls.Label lblHtFt;
        //protected System.Web.UI.WebControls.Label lblHtIn;
        protected System.Web.UI.WebControls.Label lblImgTip;
        protected System.Web.UI.WebControls.Label lblAdTitle;



        //protected System.Web.UI.WebControls.DropDownList cboBoardType;
		//protected System.Web.UI.WebControls.DropDownList cboTailType;

        protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator2;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator3;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator4;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator5;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator6;
		
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
       
        protected System.Web.UI.WebControls.CheckBox chkOther;

        protected System.Web.UI.WebControls.TextBox txtOtherBoard;
        protected System.Web.UI.WebControls.TextBox txtGenDims;
        protected System.Web.UI.WebControls.TextBox txtAdTitle;
        protected System.Web.UI.WebControls.TextBox txtGearItem;
        protected System.Web.UI.WebControls.TextBox txtThick;
        protected System.Web.UI.WebControls.TextBox txtThickNum;
        protected System.Web.UI.WebControls.TextBox txtThickDNum;
        protected System.Web.UI.WebControls.TextBox txtWidthNum;
        protected System.Web.UI.WebControls.TextBox txtWidthDNum;

        protected System.Web.UI.WebControls.Image img1;
        protected System.Web.UI.WebControls.Image img2;
        protected System.Web.UI.WebControls.Image img3;
        protected System.Web.UI.WebControls.Image img4;

        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr1;
        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr2;
        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr3;
        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr4;

        protected System.Web.UI.WebControls.HiddenField HiddenField1;
        protected System.Web.UI.WebControls.HiddenField HiddenField2;
        protected System.Web.UI.WebControls.HiddenField HiddenField3;
        protected System.Web.UI.WebControls.HiddenField HiddenField4;

		//string usrId;
		//int PageType;	//is this adtype?

        struct BlogStruct
        {
            public classes.Blog sBlog;
            public string[] tmpArray;
        }  

		private void Page_Load(object sender, System.EventArgs e)
		{
            
            // Put user code to initialize the page here
			Global.AuthenticateUser();

            if (Session["BlogFlg"].ToString() != "Y")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            if (Session["Blog"] == null)
            {
                HttpContext.Current.Response.Redirect("../Login.aspx");
            }

            classes.Blog tmpBlog = (classes.Blog)Session["Blog"];
			
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );	
            
            if (!Page.IsPostBack)  
			{
                BindData(tmpBlog);

                //Check for editMode
                if (tmpBlog.EditMode)
                {
                    LoadForEdits(tmpBlog);
                }
                else
                {
                    //setup pic panel for first time thru; TODO: stub this out into it's own function later
                    img1.ImageUrl = "../images/s1x1.gif";
                    img2.ImageUrl = "../images/s1x1.gif";

                    rdoImgMgr1.Items[2].Text = "Add";
                    rdoImgMgr1.Items.Remove("Delete");
                    rdoImgMgr1.Items.Remove("Keep");
                    File1.Disabled = true;

                    rdoImgMgr2.Items[2].Text = "Add";
                    rdoImgMgr2.Items.Remove("Delete");
                    rdoImgMgr2.Items.Remove("Keep");
                    File2.Disabled = true;
                }
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
			this.btnShowPnl.Click += new System.EventHandler(this.btnShowPnl_Click);

            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
/*
*/ 
        public void BindData(classes.Blog tBlog)
        {
            //sets the dynamic UI up according to category
            //FillDropDowns(tBoardItem.Category.ToString());
            //SetUpUIForCategory(tBlog.BlogCat.ToString());
            lblCat.Text = Global.up1(DecodeiCat(tBlog.BlogCat));
            
        }
/*
*/
        public void SetUpUIForCategory(string cat)
        {
            return;
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            //get object from session object
            classes.Blog tmpBlog = (classes.Blog)Session["Blog"];

            //kick out if validation failed
            if (!(Page.IsValid))
            {
                return;
            }

            //array holder for pics
            string[] strImgPathArray = new string[2];

            //init img array with blank space
            for (int j = 0; j <= 1; j++)
            {
                strImgPathArray[j] = "";
            }

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, delete,
            //or change an image. ***NOTE: For BETA, editing AFTER original post will not be previewed.  
            //This means pics will *not* be moved to a temp dir as we do in posting.  This should change eventually.
            //Delete any files in imgDel array
            bool blnProcImgs = false;

            switch (rdoImgMgr1.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tmpBlog.ImgPath1 = "";
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
                    tmpBlog.ImgPath2 = "";
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

            //Process media
            if (pnlAddImages.Visible && blnProcImgs)
            {

                //Declare and load a struct to send to UploadAllImages()
                BlogStruct bStruct = new BlogStruct();
                bStruct.sBlog = tmpBlog;
                bStruct.tmpArray = strImgPathArray;

                //AHM comment out temporarily
                bStruct = UpLoadAllImages(ref bStruct);

                tmpBlog = bStruct.sBlog;
            }

            //Save common data and verify strings; we'll check the string after the preview
            tmpBlog.MyBlog = txtDetails.Text;
            tmpBlog.Title = txtAdTitle.Text;

            //Save object to session variable
            Session["Blog"] = tmpBlog;

            //Goto preview blog
            Response.Redirect("BlogPreview.aspx");
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {

            classes.Blog tmpBlogItem = (classes.Blog)Session["Blog"];
            tmpBlogItem.EditMode = true;
            Session["Blog"] = tmpBlogItem;

            Response.Redirect("Blog.aspx");
        }
        
/*
 * 
 */ 
        private bool LoadForEdits(classes.Blog tempBlog)
        {
            bool retVal = false;

            //pic setup
           // if (tempBlog.AdType == (int)1)
           // {
                img1.ImageUrl = "images/s1x1.gif";
                img2.ImageUrl = "images/s1x1.gif";

                string strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                if (tempBlog.ImgPath1.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBlog.ImgPath1.Split(splitter);
                    img1.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];
                    HiddenField1.Value = img1.ImageUrl;
                    pnlAddImages.Visible = true;
                }
                else
                {
                    rdoImgMgr1.Items[2].Text = "Add";
                    rdoImgMgr1.Items.Remove("Delete");
                    rdoImgMgr1.Items.Remove("Keep");
                    File1.Disabled = true;
                }
                if (tempBlog.ImgPath2.Length > (int)0)
                {
                    //get URL to show pic
                    string path = strServerURL + @"\users\" + Session["userDir"].ToString() + @"\temp\";
                    string[] strArray;
                    char[] splitter = { '\\' };
                    strArray = tempBlog.ImgPath2.Split(splitter);
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
          //  }

            return retVal;
        }

		//=================================
		//Error Checking & Helper Functions
		//=================================

        
        private void btnShowPnl_Click(object sender, System.EventArgs e)
		{
		
			lblStatus.Text = "";
			
			if (!pnlAddImages.Visible)
			{
				pnlAddImages.Visible = true;
                btnShowPnl.Text = "No Images...";
			}
			else 
			{
				pnlAddImages.Visible = false;
                btnShowPnl.Text = "Add Images...";
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
        public void CheckDetails(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

        }     

/*
        //Here we check the file type and size.
*/
        public void CheckFileType(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
            		
            args.IsValid = true;

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

                if (fileName != string.Empty)
                {
                    if ((!Regex.IsMatch(file.ContentType, "(.gif|.jpg|.jpeg|.bmp|.png)")))
                    {
                        args.IsValid = false;
                        CustomValidator6.ErrorMessage = "Wrong file type!";
                        return;
                    }
                    //check for 4mb max
                    if (IntFileSize <= 0 || IntFileSize >= 2621440)
                    {
                        args.IsValid = false;
                        CustomValidator6.Text = "File too big!";
                        return;
                    }

                }
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
			Response.Redirect("UserMenu.aspx");
			
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
* Uploads posted images upon verification
*/ 
        //private string[] UpLoadAllImages(string[] strImgPathArray)
        private BlogStruct UpLoadAllImages(ref BlogStruct tmpStruct)
        {

            string tmpFile;
            string thmbNailPath;
            string userDir = "";

            //get user dir
            userDir = Session["userDir"].ToString();

            //if panel is open check for loaded img files
            if (pnlAddImages.Visible)
            {

                //Collect files names, iterate through each and update accordingly
                HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
                int count = uploadFilCol.Count;

                //loop thru for each posted file
                for (int i = 0; i < count; i++)
                {
                    //get handle to file
                    HttpPostedFile file = uploadFilCol[i];

                    if (file.ContentLength > (int)0)
                    {

                        //get file name & ext
                        string fileName = Path.GetFileName(file.FileName);
                        string fileExt = Path.GetExtension(file.FileName).ToLower();

                        string tmpDir = AppDomain.CurrentDomain.BaseDirectory + @"\users\" + userDir + @"\temp\";

                        //check for temp dir and create if non-existent
                        if (!(Directory.Exists(tmpDir)))
                        {
                            //'E:\kunden\homepages\31\d213027625\Showcase\users\0\0\0\0\0\0\0\1\6\2\temp\    
                            Directory.CreateDirectory(tmpDir);
                        }

                        //get physical path to temp dir for upload
                        string path = tmpDir;

                        //Generate random file name 
                        tmpFile = GenerateRandomString(8).ToLower();

                        //concatenate renamed file with ext
                        tmpFile = tmpFile + fileExt;

                        //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                        //strImgPathArray[i] = Path.Combine(path, tmpFile);
                        tmpStruct.tmpArray[i] = Path.Combine(path, tmpFile);
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
                                int maxWidth = 300;
                                int maxHeight = 300;
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
                                int maxWidth_T = 150;
                                int maxHeight_T = 150;
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
                                bmPhoto.Save(tmpStruct.tmpArray[i]);//  (2)  .., ImageFormat.Jpeg)
                                
                                //strip out the superfluous server path and just save the file name;  this was the cause of much grief as we were saving the entire path!
                                tmpStruct.tmpArray[i] = Path.GetFileName(tmpStruct.tmpArray[i]);

                                //Thumbnail
                                grPhotoThmbNail.Save();
                                bmPhotoThmbNail.Save(thmbNailPath);

                                //Find out who is set to "change" or "add" so we know who to update
                                //  - We call the clearSelection() to let ourselves know that index has been processed
                                //TODO: append  (&& File1.Value.Length>0)
                                if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
                                {
                                    tmpStruct.sBlog.ImgPath1 = tmpStruct.tmpArray[i];
                                    rdoImgMgr1.ClearSelection();

                                }
                                else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                {
                                    tmpStruct.sBlog.ImgPath2 = tmpStruct.tmpArray[i];
                                    rdoImgMgr2.ClearSelection();
                                }

                            }
                            catch (Exception ex)
                            {
                                lblStatus.Text = "Resize/Save Error!";
                            }

                        }
                        else
                        {
                            tmpStruct.tmpArray[i] = string.Empty;
                        }
                    }
                }
            }//end main if
            //return strImgPathArray;
            return tmpStruct;
        
        }
    
    }//end class
}
