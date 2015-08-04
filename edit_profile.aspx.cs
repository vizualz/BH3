//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			edit_profile.apx.cs
///		Project log:	
///						
///						7/25/06 -	File creation
///						7/31/06 -	User registration beta completed successfully!
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
using DALLayer;

namespace BoardHunt
{
	/// <summary>
	/// Summary description for edit_profile.
	/// </summary>
	/// 
	
	public partial class edit_profile : System.Web.UI.Page
	{
    

		protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.TextBox txtPassword2;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;

        //for Shaperhouse
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

        protected const int BitMask = 0x100;

        protected const int picSizeShaperX = 128;
        protected const int picSizeShaperY = 128;

        protected const int picSizeBigX = 128;
        protected const int picSizeBigY = 128;

        protected const int picSizeSmX = 64;
        protected const int picSizeSmY = 64;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// Put user code to initialize the page here
            Global.AuthenticateUser(Request.Url.ToString());			
	
			if (!(Page.IsPostBack))
			{
                LoadControl();
				GetUserProfileData();
                SetControls();
                pnlChangePwd.Visible = false;
			}

		}


		//===============================
		//Error Checking & Helper Functions
		//===============================
	
		private bool IsNumeric(object ValueToCheck)
		{
			double Dummy = new double();
			string InputValue = Convert.ToString(ValueToCheck);

			bool Numeric = double.TryParse( InputValue , System.Globalization.NumberStyles.Any , null , out Dummy);
		
			return Numeric;
		}

		protected void CheckPassword(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
            args.IsValid = true;

            //Check for too short of a password; Allow empty string but we won't process pwd
            if (pnlChangePwd.Visible == true && txtPassword1.Text.Length > 0 && txtPassword1.Text.Length < 6) 
            {
                lblStatus.Text = "Please use at least 6 characters!";
                args.IsValid = false;
            }
            return;
		}

		
			protected void CheckPhoneNum(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
			{
				args.IsValid = false;
				
				//cehck for blank entries
				if (txtAreaCode.Text == "" && txtPhoneNum.Text == "")
				{
                    args.IsValid = true;
                    return;

				}

                else if (txtAreaCode.Text.Length > 0 && txtPhoneNum.Text == "")
                {
                    CustomValidator1.ErrorMessage = "!";

                }

                else if (txtPhoneNum.Text.Length > 0 && txtAreaCode.Text == "")
                {
                    CustomValidator1.ErrorMessage = "!";

                }

				else if (!Regex.IsMatch (txtAreaCode.Text,@"\d{3}"))
				//validate phone num entry against reg exp
				{
					CustomValidator1.ErrorMessage = "!";	

				}

				else if (!Regex.IsMatch (txtPhoneNum.Text,@"(\d{3}-\d{4})|(\d{3}.\d{4})|\d{7}"))
					//validate phone num entry against reg exp
				{
					CustomValidator1.ErrorMessage = "!";	

				}

				else
				{
					args.IsValid = true;
				}
		
			}
/*
*/
        private bool verify_User(string myConnStr, string emailId)
        {

            bool user_Registered = false;
            string SQLstr = "SELECT iD FROM tblUser WHERE txtEmail ='" + emailId + "'";
            SqlConnection myConn = new SqlConnection(myConnStr);
            SqlDataReader rdr = null;
            SqlCommand objSQLCommand = new SqlCommand(SQLstr, myConn);

            try
            {
                myConn.Open();
                rdr = objSQLCommand.ExecuteReader();

                if (rdr.Read())
                    user_Registered = true;
            }
            catch
            {
                ErrorLog.ErrorRoutine(false, "Error attempting to verify new user e-mail");
                lblStatus.Text = "ERROR!";
            }
            finally
            {
                myConn.Close();
            }
            return user_Registered;
        }

/*
 */ 
        protected void btnChangePwd_Click(object sender, System.EventArgs e)
        {
            pnlChangePwd.Visible = pnlChangePwd.Visible ? false : true;
        }
	

/**
 */ 
        private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("register_user.aspx");
		}
/**
 */
		private void GetUserProfileData()
		{

            string strSQL, tempPhone;
            int iPhoneLength;

            pnlShaper.Visible = false;
            //pnlShaping.Visible = false;

            tempPhone = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Make SQL query and command obj
            strSQL = "SELECT * FROM tblUser WHERE iD = '" + Session["userId"] + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {

                    //SECURITY CHECK: Ensure user or admin is editing
                    if (dbManager.DataReader["iD"].ToString() != Session["userId"].ToString() && (Session["EmailId"].ToString() != "admin@boardhunt.com"))
                    {
                        Response.Redirect("UserMenu.aspx", true);
                        classes.Email.SendEmail("hack attempt", "info@boardhunt.com", "Hack attempt at posting: " + Session["userId"].ToString());
                    }                    

                    //Set and get values for textboxes
                    txtFullName.Text = dbManager.DataReader["txtFullName"].ToString();
                    txtEmail.Text = dbManager.DataReader["txtEmail"].ToString();
                    txtBrandName.Text = dbManager.DataReader["txtBrandName"].ToString();
                    radioAcctType.SelectedValue = dbManager.DataReader["iAcctType"].ToString();
                    rdoEmailNotify.SelectedValue = dbManager.DataReader["notify_comment_flg"].ToString();
                    rdoBlogNotify.SelectedValue = dbManager.DataReader["notify_blog_flg"].ToString();
                    hdnUserDir.Value = dbManager.DataReader["userDir"].ToString();
                    hdnProfilePic.Value = dbManager.DataReader["profilePic"].ToString();
                    hdnAcctType.Value = dbManager.DataReader["iAcctType"].ToString();
                    hdnMT.Value = dbManager.DataReader["iMerchantType"].ToString();
                    cboRegion.SelectedValue = dbManager.DataReader["iRegion"].ToString();
                    img1.ImageUrl = "images/nopic64.jpg";   //default

                    string strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

                    //profile pic
                    if (dbManager.DataReader["profilePic"].ToString().Length > 1)
                    {
                        img1.ImageUrl = strServerURL + "/users/" + Global.ReplaceEx(hdnUserDir.Value, @"\", @"/") + hdnProfilePic.Value;
                    }
                    else //default or no pic, so set first time "Add" text
                    {
                        rdoImgMgr1.Items[2].Text = "Add";
                        rdoImgMgr1.Items.Remove("Delete");
                        rdoImgMgr1.Items.Remove("Keep");
                    }
                    File1.Disabled = true;                    

                    //username
                    if (dbManager.DataReader["txtUserName"].ToString().Length > 1)
                    {
                        txtUserName.Text = dbManager.DataReader["txtUserName"].ToString();
                    }
                    else
                    {
                        txtUserName.Text = Global.ParseEmail(dbManager.DataReader["txtEmail"]);
                    }

                    //phone
                    chkShowPhone.Checked = false;
                    if (dbManager.DataReader["iShowPhoneNum"].ToString() == "1")
                    {
                        chkShowPhone.Checked = true;
                    }

                    txtAreaCode.Text = txtPhoneNum.Text = string.Empty;

                    if (dbManager.DataReader["txtPhoneNum"].ToString().Length > 1)
                    {
                        tempPhone = dbManager.DataReader["txtPhoneNum"].ToString();
                        iPhoneLength = tempPhone.Length;

                        //show area code
                        txtAreaCode.Text = tempPhone.Substring(0, 3);
                        txtPhoneNum.Text = tempPhone.Substring(4, iPhoneLength - 4);
                    }

                    //shaper
                    if (hdnAcctType.Value == "2" && hdnMT.Value == "1")
                    {
                        hdnIsShaper.Value = "1";
                        pnlShaper.Visible = true;
                        //pnlShaping.Visible = true;
                        txtHomeTown.Text = dbManager.DataReader["txtHomeTown"].ToString();
                        txtDetails.Text = dbManager.DataReader["txtUserDetails"].ToString();
                        txtShapingYrs.Text = dbManager.DataReader["iWisdom"].ToString();
                        txtWebsite.Text = dbManager.DataReader["txtWebSite"].ToString();
                        hdnShaperCode.Value = dbManager.DataReader["iShaperCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Edit_Profile:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
		}
/*
 */
        /*
        * Upload any/all images
        */

        private string UpLoadAllImages()
        {
            string tmpFile;
            string userDir = string.Empty;

            string fullPathAndFile = string.Empty;
            string fullPathAndFile_Thmb = string.Empty;

            //get user dir
            userDir = Session["userDir"].ToString();

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

                    //check for temp dir and create if non-existent; this would be bad right here
                    if (!(Directory.Exists(Server.MapPath(".\\" + @"\users\" + userDir))))
                    {
                        Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + userDir));
                    }

                    //get physical path to user dir for upload
                    string path = Server.MapPath(".\\" + @"\users\" + userDir);

                    //Generate random file name
                    BoardHunt.classes.RandomPassword pwdGen = new BoardHunt.classes.RandomPassword();
                    tmpFile = pwdGen.Generate(8);

                    //concatenate renamed file with ext
                    tmpFile = tmpFile + fileExt;

                    //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                    fullPathAndFile = Path.Combine(path, tmpFile);
                    fullPathAndFile_Thmb = Path.Combine(path, "thmb_" + tmpFile);

                    //Upload directly user dir
                    //FIXME: Check for file type and size

                    if (fileName != string.Empty)   //TODO: maybe check for strLength > 0
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

                            int sourceX = 0;
                            int sourceY = 0;
                            int destX = 0;
                            int destY = 0;

                            float nPercent = 0;
                            float nPercentW = 0;
                            float nPercentH = 0;

                            //ThumbNail variables
                            int maxWidth_T = picSizeSmX;
                            int maxHeight_T = picSizeSmY;
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
                            bmPhoto.Save(fullPathAndFile);//  (2)  .., ImageFormat.Jpeg)

                            //Just get the file name to save to db
                            fullPathAndFile = Path.GetFileName(fullPathAndFile);

                            //Thumbnail
                            grPhotoThmbNail.Save();
                            bmPhotoThmbNail.Save(fullPathAndFile_Thmb);

                            //Find out who is set to "change" or "add" so we know who to update
                            //  - We call the clearSelection() to let ourselves know that index has been processed
                            //TODO: append  (&& File1.Value.Length>0)
                            if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
                            {
                                rdoImgMgr1.ClearSelection();
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.ErrorRoutine(false, "EditProfile:UpdateAllImages-Error: " + ex.Message);
                            lblStatus.Text = "Resize/Save Error";
                        }

                    }
                    else
                    {
                        fullPathAndFile = string.Empty;
                    }
                }
            }

            return fullPathAndFile;

        }//end function
/*
 */ 
        private bool DeleteFile()
        {
            //delete the current profile pic and this should default to nopic64.jpg
            try
            {
                if (File.Exists(Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + hdnProfilePic.Value)))
                {
                    File.Delete(Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + hdnProfilePic.Value));
                    File.Delete(Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + "thmb_" + hdnProfilePic.Value));
                    return true;
                }
                else
                {
                    ErrorLog.ErrorRoutine(false, "edit_profile:deletefile:file didn't exist: " + Server.MapPath(".\\" + @"\users\" + hdnUserDir.Value + hdnProfilePic.Value));
                    return false;
                }
            }
            catch (Exception e)
            {
               ErrorLog.ErrorRoutine(false, "edit_profile:deletefile:ErrorDeletingOldPic: " + e.Message);
                return false;
            }
        }
/*
 */
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
 * */
        private void LoadControl()
        {

            string strSQL = "SELECT BoardType, iValue FROM LK_BoardType WHERE BoardCategory = 1;SELECT iD, Region FROM LK_Region" ;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            DataSet ds = new DataSet();

            try
            {
                dbManager.Open();
                ds = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                    chkListShaping.DataSource = ds;
                    chkListShaping.DataMember = ds.Tables[0].ToString();
                    chkListShaping.DataTextField = "BoardType";
                    chkListShaping.DataValueField = "iValue";
                    chkListShaping.DataBind();

                    cboRegion.DataSource = ds;
                    cboRegion.DataMember = ds.Tables[1].ToString();
                    cboRegion.DataTextField = "Region";
                    cboRegion.DataValueField = "iD";
                    cboRegion.DataBind();

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:EditProfile:LoadControl: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            
        }
/*
 */
        private void SetControls()
        {
            if (hdnIsShaper.Value != "1")
                return;

            uint mask;
            mask = BitMask; // 0x100;

            if (hdnShaperCode.Value.Length < 1)
                return;

            //get the shapers board code.  this is the list of all the boards he shapes.
            int val = Convert.ToInt32(hdnShaperCode.Value);

            for (int i = 8; i >= 0; i--)
            {
                if ((mask & val) > 0)
                {

                    chkListShaping.Items[i].Selected = true;
                }
                mask = mask >> 1;
            }

        }
        /*
                //Here we check the file type and size.  Halt processing any further if the wrong file type or too big o' size is detected.
        */
        public bool CheckFileType()
        {

            //user wanted to upload but no pic
            if (File1.PostedFile == null)
                return false;

            //get file name & ext
            HttpPostedFile oFile = File1.PostedFile;
            string fileName = oFile.FileName;
            string fileExt = Path.GetExtension(fileName).ToLower();
            int IntFileSize = oFile.ContentLength;

            //Check for file type and size:
            if (fileName != string.Empty)
            {
                if ((!Regex.IsMatch(oFile.ContentType, "(.gif|.jpg|.jpeg|.bmp|.png)")))
                {
                    lblStatus.Text = "Wrong file type!";
                    ErrorLog.ErrorRoutine(false, "edit_item:imgContinue_Click:Wrong file type!");
                    return false;
                }
                //check for 2.5 MB max
                if (IntFileSize <= 0 || IntFileSize >= 2621440)
                {
                    lblStatus.Text = "File too big!";
                    ErrorLog.ErrorRoutine(false, "edit_item:imgContinue_Click:File too big!");
                    return false;
                }

            }
            return true;
        }
 /*
  */ 
        private void TallyShaperCode()
        {
           
            int iVal = 0;

            //see whose checked
            for (int i = 0; i < chkListShaping.Items.Count; i++)
            {
                if (chkListShaping.Items[i].Selected == true)
                {
                    //ErrorLog.ErrorRoutine(false, "CheckedItem: " + i);

                    iVal = Convert.ToInt32(chkListShaping.Items[i].Value) + iVal;

                    //ErrorLog.ErrorRoutine(false, "hdnShaperCodeInc: " + iVal);
                }
                hdnShaperCode.Value = iVal.ToString();
            }    
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //kick out if validation failed
            if (!(Page.IsValid))
            {
                //Do over; Reset anything here that needs a reset
                ResetImgMgr();
                return;
            }

            //tally up ShaperCodeValue
            if (hdnIsShaper.Value == "1")
                TallyShaperCode();

            string strSQL = string.Empty;
            string txtPhoneNumber;
            string emailNotify;
            string blogNotify;
            string profPic;
            int showPhoneNum;
            int iAcctType;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Verify unique e-mail id.
            if (Session["EmailId"].ToString() != txtEmail.Text)
            {
                if (verify_User(dbManager.ConnectionString, txtEmail.Text))
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "That e-mail is already registered.  Please try again.";
                    return;
                }
            }

            //show phone flag
            showPhoneNum = (int)0;

            //Free acct=1; Commercial = 2
            iAcctType = Convert.ToInt16(radioAcctType.SelectedValue);
            emailNotify = rdoEmailNotify.SelectedValue;
            blogNotify = rdoBlogNotify.SelectedValue;

            txtPhoneNumber = txtAreaCode.Text + "-" + txtPhoneNum.Text;

            //if no phone num is entered then showPhonenum flag must be set to zero
            if (txtAreaCode.Text != "" && txtPhoneNum.Text != "")
            {
                if (chkShowPhone.Checked == true)
                {
                    showPhoneNum = (int)1;
                }
            }

            //Get user's id
            string uId = Session["userId"].ToString();

            strSQL = "UPDATE tblUser SET txtFullName = '" + txtFullName.Text;
            strSQL += "' ,txtEmail = '" + txtEmail.Text;
            strSQL += "',txtPhoneNum = '" + txtPhoneNumber;
            strSQL += "',iShowPhoneNum = '" + showPhoneNum;
            strSQL += "',iAcctType = '" + iAcctType;
            strSQL += "',notify_comment_flg = '" + emailNotify;
            strSQL += "',notify_blog_flg = '" + blogNotify;
            strSQL += "',txtUserName = '" + txtUserName.Text;

            if (hdnIsShaper.Value == "1")
            {
                    strSQL += "',txtHomeTown = '" + Global.CheckString(txtHomeTown.Text);
                    strSQL += "',txtWebSite = '" + Global.CheckString(txtWebsite.Text);
                    strSQL += "',txtUserDetails = '" + Global.CheckString(txtDetails.Text);
                    strSQL += "',iWisdom = '" + Global.CheckString(txtShapingYrs.Text);
                    strSQL += "',txtBrandName = '" + Global.CheckString(txtBrandName.Text);
                    strSQL += "',iRegion = '" + cboRegion.SelectedValue;

                    if (hdnShaperCode.Value.Length > 0)
                        strSQL += "',iShaperCode = '" + Global.CheckString(hdnShaperCode.Value);
            }

            //skip pwd processing if the change pwd panel is not visible
            if (pnlChangePwd.Visible && txtPassword1.Text.Length > 1)
            {
                BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();

                //Get SALT and encode to string
                byte[] saltBytes = pHash.GenerateSALT();
                string saltString = Convert.ToBase64String(saltBytes);

                //get hash and encode to string with SALT
                byte[] hBytes = pHash.getHash(saltString, txtPassword1.Text);
                string hPass = Convert.ToBase64String(hBytes);   //hashed textual password             

                //build SQL
                strSQL += "' ,txtPassword = '" + hPass + "',salt = '" + saltString + "',sashimi = '" + (int)1;
            }

            //get profile pic if loaded and control set
            if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
            {

                if (!CheckFileType())
                {
                    ResetImgMgr();
                    return;
                }

                //TODO: check for file before attempting to upload
                profPic = UpLoadAllImages();
                strSQL += "' ,profilePic = '" + profPic;
                //delete old profile pic
                if (!(hdnProfilePic.Value.IndexOf("nopic64.jpg") > 0))
                {
                    //ErrorLog.ErrorRoutine(false, "Deleting old pic: " + Server.MapPath(hdnProfilePic.Value));
                    DeleteFile();
                }
            }
            else
            {
                if (rdoImgMgr1.SelectedValue == "Delete")
                {
                    DeleteFile();
                    //set to empty string
                    strSQL += "' ,profilePic = '";
                }
                //else KEEP: do nothing
            }

            strSQL += "' WHERE id = '" + uId + "'";
            ErrorLog.ErrorRoutine(false, "strSQL-> " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

                //Set new EmailId
                Session["EmailId"] = txtEmail.Text;
                //classes.Email.SendEmail("BH Profile Change", "info@boardhunt.com", "For User: " + Session["EmailId"].ToString() + " iD: " + uId);
                Response.Redirect("UserMenu.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "edit_profile:error" + ex.Message);
                lblStatus.Text = "Error: Connection Bad.<br>";
                classes.Email.SendErrorEmail("edit_profile:error" + ex.Message);

            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }	
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenu.aspx");
        }

	}
}
