//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			BlogEdit.aspx.cs
///		Project log:	
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


namespace BoardHunt.Blog
{
    /// <summary>
    /// Summary description for post_item.
    /// </summary>
    /// 

    public class BlogEdit : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Panel pnlItem;
        protected System.Web.UI.WebControls.Panel pnlWeb;
        protected System.Web.UI.WebControls.Panel pnlAddImages;
        protected System.Web.UI.WebControls.Panel pnlAdTitle;

        protected System.Web.UI.WebControls.TextBox txtBlogTitle;
        protected System.Web.UI.WebControls.TextBox txtDetails;

        protected System.Web.UI.WebControls.TextBox txtWebURL;

        protected System.Web.UI.WebControls.ImageButton imgCancel;
        protected System.Web.UI.WebControls.ImageButton imgUpdate;
        protected System.Web.UI.WebControls.ImageButton imgBtnHelp;

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
        protected System.Web.UI.WebControls.Label lblWeb;
        protected System.Web.UI.WebControls.Label lblItem;
        protected System.Web.UI.WebControls.Label lblImgTip;
        protected System.Web.UI.WebControls.Label lblAdTitle;

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

        protected System.Web.UI.WebControls.Image img1;
        protected System.Web.UI.WebControls.Image img2;

        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr1;
        protected System.Web.UI.WebControls.RadioButtonList rdoImgMgr2;

        protected System.Web.UI.WebControls.HiddenField HiddenField1;
        protected System.Web.UI.WebControls.HiddenField HiddenField2;
        protected System.Web.UI.WebControls.HiddenField HiddenField3;
        protected System.Web.UI.WebControls.HiddenField HiddenField4;

        protected FredCK.FCKeditorV2.FCKeditor FCKeditor1; 


        private void Page_Load(object sender, System.EventArgs e)
        {

            string entryId;
            string usrId;

            // Put user code to initialize the page here
            Global.AuthenticateUser();

            //Register .js
            ClientScript.RegisterClientScriptInclude(this.GetType(), "bh", @"include\bh.js");

            //Disable File Uploads
            File1.Disabled = true;
            File2.Disabled = true;

            //entryId = Request.QueryString["BlogId"];
            entryId = Request.QueryString["iD"].ToString();

            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (!(Page.IsPostBack))
            {

                //default all pics to a clear gif
                img1.ImageUrl = @"\images\s1x1.gif";
                img2.ImageUrl = @"\images\s1x1.gif";

                //TODO: remove dead code
                //Init delete img flag to false
                //delImgs = false;

                txtDetails.Visible = false;

                BindItemData(entryId);
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
            this.btnShowPnl.Click += new System.EventHandler(this.btnShowPnl_Click);
            //this.rdoImgMgr1.SelectedIndexChanged += new System.EventHandler(this.rdoImgMgr1_SelectedIndexChanged);
            this.imgCancel.Click += new System.Web.UI.ImageClickEventHandler(this.imgCancel_Click);
            this.imgUpdate.Click += new System.Web.UI.ImageClickEventHandler(this.imgUpdate_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        /**
 */
        ////
        //Load up all the data for the selected item
        /// 
        public void BindItemData(string Id)
        {

            classes.Blog tmpBlog = new classes.Blog();

            string strSQL;
            string myConnectString;
            string strServerURL;
            string strCat;
            int iStrCat;
            string userDir;

            tmpBlog.BlogId = Convert.ToInt32(Id);

            //Get connection string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Get server URL
            strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            //Formulate SQL
            //strSQL = "SELECT * FROM tblBlog WHERE iD = '" + Id + "'";

            //query item and user details for entry
            strSQL = "SELECT tblUser.userDir, tblBlog.* FROM tblUser INNER JOIN tblBlog ON tblUser.Id = tblBlog.iUser WHERE tblBlog.id = '" + Id + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                while (SQLReader.Read() == true)
                {
                    //set control values
                    strCat = SQLReader["cat"].ToString();
                    iStrCat = Convert.ToInt32(strCat);
                    tmpBlog.BlogCat = iStrCat;

                    txtDetails.Text = SQLReader["blog"].ToString();
                    FCKeditor1.Value = SQLReader["blog"].ToString();

                    txtBlogTitle.Text = SQLReader["title"].ToString();

                    tmpBlog.ImgPath1 = SQLReader["txtImgPath1"].ToString();
                    tmpBlog.ImgPath2 = SQLReader["txtImgPath2"].ToString();

                    userDir = SQLReader["userDir"].ToString();
                    Session["userDir"] = userDir;

                    //scale img place holders to fit page
                    img1.Height = 100;
                    img1.Width = 100;
                    img2.Height = 100;
                    img2.Width = 100;

                    //get name of category
                    //strCat = Enum.GetName(typeof(Global.BOARDCAT_DIRS), SQLReader["cat"]); HARDCODED
                    strCat = @"/" + @"blog";

                    //set up pics (*if available) and radio controls
                    if (tmpBlog.ImgPath1.Length > (int)0)
                    {
                        img1.ImageUrl = strServerURL + "/users/" + userDir + strCat + "/" + Path.GetFileName(tmpBlog.ImgPath1);
                        HiddenField1.Value = img1.ImageUrl;
                        File1.Disabled = true;
                    }
                    else //don't show delete or keep; set "change" to "add"
                    {
                        rdoImgMgr1.Items[2].Text = "Add";
                        rdoImgMgr1.Items.Remove("Delete");
                        rdoImgMgr1.Items.Remove("Keep");
                    }

                    if (tmpBlog.ImgPath2.Length > (int)0)
                    {

                        img2.ImageUrl = strServerURL + "/users/" + userDir + strCat + "/" + Path.GetFileName(tmpBlog.ImgPath2);
                        HiddenField2.Value = img2.ImageUrl;
                        File2.Disabled = true;
                    }
                    else
                    {
                        rdoImgMgr2.Items[2].Text = "Add";
                        rdoImgMgr2.Items.Remove("Delete");
                        rdoImgMgr2.Items.Remove("Keep");
                    }

                    pnlAddImages.Visible = true;
  		
                }

                //save to a session object for later access
                Session["Blog"] = tmpBlog;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:" + ex.Message);
                lblStatus.Text = "BindItemData Error";
            }

            finally
            {
                myConnection.Close();
                SQLReader = null;
            }
        }


        /**
         * Update the user's entry changes
         */

        private void imgUpdate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //check for valid page
            if (!(Page.IsValid))
            {
                return;
            }

            Boolean delImgs = false;                          //flag to fire delete logic

            classes.Blog tmpBlog = (classes.Blog)Session["Blog"];

            int newFileCount;
            string strDetails;

            //DateTime dLastModified;
            bool blnProcImgs;

            string[] strImgPathArray = new string[4];
            string[] delImgArray = new string[4];

            //Init delImgArray
            for (int j = 0; j < 2; j++)
            {
                delImgArray[j] = "";
            }

            //Set Update items
            tmpBlog.Title = Global.CheckString(txtBlogTitle.Text);
            //tmpBlog.MyBlog = Global.CheckString(txtDetails.Text);
            tmpBlog.MyBlog = Global.CheckString(FCKeditor1.Value);

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, delete,
            //, or change an image. ***NOTE: For BETA release entry updates will not use preview_post.  
            //This means pics will *not* be moved to a temp dir as we do in first time posts.  This should change eventually.'
            //Delete any files in imgDel array

            blnProcImgs = false;

            switch (rdoImgMgr1.SelectedValue)
            {
                case "Keep":
                    tmpBlog.ImgPath1 = "KEEP";
                    break;
                case "Delete":
                    delImgArray[0] = Path.GetFileName(tmpBlog.ImgPath1);
                    delImgs = true;
                    tmpBlog.ImgPath1 = "";
                    break;
                case "Change":
                    blnProcImgs = true;
                    break;
                case "Add":
                    blnProcImgs = true;
                    break;
                default:
                    tmpBlog.ImgPath1 = "KEEP";
                    break;
            }

            switch (rdoImgMgr2.SelectedValue)
            {
                case "Keep":
                    tmpBlog.ImgPath2 = "KEEP";
                    break;
                case "Delete":
                    delImgArray[1] = Path.GetFileName(tmpBlog.ImgPath2);
                    delImgs = true;
                    tmpBlog.ImgPath2 = "";
                    break;
                case "Change":
                    blnProcImgs = true;
                    break;
                case "Add":
                    blnProcImgs = true;
                    break;
                default:
                    tmpBlog.ImgPath2 = "KEEP";
                    break;
            }

            //process deletes for pics
            if (delImgs)
            {
                for (int j = 0; j < delImgArray.Length; j++)
                {
                    if (delImgArray[j].Length != 0)
                    {
                        try
                        {
                            DeleteServerFile(Server.MapPath(".\\" + @"\users\" + Session["userDir"].ToString() + @"\blog" + @"\" + delImgArray[j]));
                        }
                        catch (Exception ex)
                        { 
                            
                            ErrorLog.ErrorRoutine(false, "Error deleting imgs: " + ex.Message); 
                        }
                    }
                }
            }
            delImgs = false;

            //upload imgs
            if (blnProcImgs)
            {
                //strImgPathArray = UpLoadAllImages(strImgPathArray);
                tmpBlog = UpLoadAllImages(tmpBlog, strImgPathArray);
            }

            //call object method to update handler
            if (tmpBlog.UpdateItem())
            {
                Response.Redirect("../Admin/BlogManager.aspx");
            }
            else
            {
                lblStatus.Text = "SQL Update Error<br>";
                lblStatus.Text += "Length: " + FCKeditor1.Value.Length;
            }

        }
        /**
         */
        private void imgCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Admin/BlogManager.aspx");
        }

        //===============================
        //Error Checking & Helper Functions
        //===============================

        private void btnShowPnl_Click(object sender, System.EventArgs e)
        {

            if (pnlAddImages.Visible)
            {
                pnlAddImages.Visible = false;
            }
            else
            {
                pnlAddImages.Visible = true;
            }
        }

        /**
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
            for (int i = 0; i <= intLenghtOfString; ++i)
            {
                //Generate the char and assign it to appendedChar
                appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                //Append appendedChar to randomString
                randomString.Append(appendedChar);
            }
            //Strip out any non-alphacharacters
            //Regex.Replace(randomString.ToString, "([|])","x");

            //Convert randomString to String and return the result.
            return randomString.ToString();
        }

        /**
        */
        //Determines if value is numeric
        private bool IsNumeric(object valType)
        {
            double tempVal = new double();
            string InputValue = Convert.ToString(valType);

            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out tempVal);

            return Numeric;
        }

        //Here we check the file type and size.
        public void CheckFileType(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

            args.IsValid = true;

            //load up collection 
            HttpFileCollection uploadFilCol = Request.Files;
            int count = uploadFilCol.Count;
            for (int i = 0; i < count; i++)
            {

                //get a file handle
                HttpPostedFile file = uploadFilCol[i];

                //get file name & ext
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(file.FileName).ToLower();
                int IntFileSize = file.ContentLength;

                if ((fileName != string.Empty) || (fileName != ""))
                {
                    if ((!Regex.IsMatch(file.ContentType, "(.gif|.jpg|.jpeg|.bmp|.png)")))
                    {
                        args.IsValid = false;
                        CustomValidator1.ErrorMessage = "Wrong file type!";
                        return;
                    }
                    //no files greater than 2.5MB -- pleas!
                    if (IntFileSize <= 0 || IntFileSize >= 2621440)
                    {
                        args.IsValid = false;
                        CustomValidator1.Text = "File too big!";
                        return;
                    }

                }
            }

        }
        /**
         * 
        */
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignIn.Text);
        }
        /**
         * 
        */
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);
        }
        /**
         * 
        */
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post.aspx");
        }

        /** 
         */
        //Delete file from the server
        private void DeleteServerFile(string strFileName)
        {

            if (strFileName.Trim().Length > 0)
            {
                try
                {
                    FileInfo fi = new FileInfo(strFileName);

                    if (fi.Exists)//if file exists delete it
                    {
                        fi.Delete();
                    }
                    else
                    {

                    }
                }
                catch
                {
                    ErrorLog.ErrorRoutine(false, "Error deletingFile");
                }
            }

        }

        /*
        * Upload any images
        */
        //private string[] UpLoadAllImages(BoardItem bItem, string[] strImgPathArray)
        private classes.Blog UpLoadAllImages(classes.Blog bItem, string[] strImgPathArray)
        {

            string tmpFile;
            string thmbNailPath;
            string userDir = "";
            string strCat;

            strCat = @"blog";

            //set userdir
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

                        //Create dir if non-existent;  We check the root here because BlogEdit lives within root/Blog/
                        if (!(Directory.Exists(Server.MapPath("/" + @"\users\" + userDir + strCat + @"\"))))  
                        {
                            Directory.CreateDirectory(Server.MapPath("/" + @"\users\" + userDir + strCat + @"\"));
                        }

                        //get physical path to upload dir
                        string path = Server.MapPath("/" + @"\users\" + userDir + strCat + @"\");

                        //Generate random file name 
                        tmpFile = GenerateRandomString(8).ToLower();

                        //concatenate renamed file with ext
                        tmpFile = tmpFile + fileExt;

                        //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                        strImgPathArray[i] = Path.Combine(path, tmpFile);
                        thmbNailPath = Path.Combine(path, "thmbNail_" + tmpFile);

                        //Upload to temp dir; We'll write to perm directory after user confirms on preview!
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
                                    destY = System.Convert.ToInt16((maxHeight -
                                                  (sourceHeight * nPercent)) / 2);

                                    //ThumbNail Calculations
                                    nPercent_T = nPercentW_T;
                                    destY_T = System.Convert.ToInt16((maxWidth_T -
                                                  (sourceHeight * nPercent_T)) / 2);
                                }

                                //Larger Image Calculations
                                int destWidth = (int)(sourceWidth * nPercent);
                                int destHeight = (int)(sourceHeight * nPercent);

                                //Smaller Image Calculations
                                int destWidth_T = (int)(sourceWidth * nPercent_T);
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

                                //Thumbnail
                                grPhotoThmbNail.Save();
                                bmPhotoThmbNail.Save(thmbNailPath);

                                //strip out superfluous file path
                                strImgPathArray[i] = Path.GetFileName(strImgPathArray[i]);

                                //Find out who is set to "change" or "add" so we know who to update
                                //  - We call the clearSelection() to let ourselves know that index has been processed

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
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorRoutine(false, "Error: " + ex.Message);
                                lblStatus.Text = "Upload/Save Error!";
                            }



                        }//end if file > 0
                    }
                }//end for loop
            }
            return bItem;
        }

        /*
         * Disable file control if not set to "change"
         */
        protected void rdoImgMgr1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoImgMgr1.SelectedValue == "Change") { File1.Disabled = false; }
        }
        protected void rdoImgMgr2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoImgMgr1.SelectedValue == "Change") File2.Disabled = false;
        }


    }//end class

}