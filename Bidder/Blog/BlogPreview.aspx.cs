//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			BlogPreview.apx.cs
///		Project log:	
///		@author:        AHM,PRM							 		 
///
//////////////////////////////////////////////////////////////////////////

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


namespace BoardHunt.Blog
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	/// 

    public class BlogPreview : System.Web.UI.Page
	{

        protected System.Web.UI.WebControls.Button btnBack;
        protected System.Web.UI.WebControls.Button btnNext;

		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label lblPhoneData;
		protected System.Web.UI.WebControls.Label lblPriceData;
		protected System.Web.UI.WebControls.Label lblFinsData;
		protected System.Web.UI.WebControls.Label lblTailData;
		protected System.Web.UI.WebControls.Label lblWidthData;
		
        protected System.Web.UI.WebControls.Label lblDateData;

        protected System.Web.UI.WebControls.Label lblAdTitle;
        protected System.Web.UI.WebControls.Label lblAdTitleData;


        //protected System.Web.UI.WebControls.Panel pnlGenDims;
        //protected System.Web.UI.WebControls.Panel pnlGearItem;
        //protected System.Web.UI.WebControls.Panel pnlBoardType;
        //protected System.Web.UI.WebControls.Panel pnlWeb;

		protected System.Web.UI.WebControls.Panel pnlDetails;
        protected System.Web.UI.WebControls.Panel pnlError;
        protected System.Web.UI.WebControls.Panel pnlAdTitle;


        protected System.Web.UI.WebControls.LinkButton lnkEmailData;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected System.Web.UI.WebControls.Image Pic1;
        protected System.Web.UI.WebControls.Image Pic2;
        protected System.Web.UI.WebControls.Image Pic3;
        protected System.Web.UI.WebControls.Image Pic4;

        protected System.Web.UI.WebControls.Image Pic1ThmbNail;
        protected System.Web.UI.WebControls.Image Pic2ThmbNail;
        protected System.Web.UI.WebControls.Image Pic3ThmbNail;
        protected System.Web.UI.WebControls.Image Pic4ThmbNail;

		protected System.Web.UI.WebControls.Label lblDetailsData;
		protected System.Web.UI.WebControls.ImageButton imgGoBack;
        protected System.Web.UI.WebControls.ImageButton imgContinue;

		protected System.Web.UI.WebControls.Label lblLocation;
		protected System.Web.UI.WebControls.Label lblThick;

        protected System.Web.UI.WebControls.HiddenField hdnUserDir;
        protected System.Web.UI.WebControls.HiddenField hdnProcPics;

        //TODO: Replace these gloabal vars
        //static string strUserDir;
        //static bool blnNoPics;

		private void Page_Load(object sender, System.EventArgs e)
		{
            Global.AuthenticateUser();
            
            //check for hacks
            if (Session["blogFlg"].ToString() != "Y")
            {
                Response.Redirect("../UserMenu.aspx");
            }
            
            //get blog obj
            classes.Blog tmpBlog = (classes.Blog)Session["Blog"];

            if (!Page.IsPostBack)
            {

                ErrorLog.ErrorRoutine(false, "Preview_post:BindData -> Category:" + tmpBlog.BlogCat);
                ErrorLog.ErrorRoutine(false, "PP:SessionID:" + Session.SessionID);
    
                // Put user code to initialize the page here
			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

			    //Hide all sub-panels then enable accordingly

                //pnlBoardType.Visible = false;

                //imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
                
                //Load up display data and show a preview of the posting
                BindData(tmpBlog);
			}

            //reload the session item
            Session["Blog"] = tmpBlog;
		}

/**
 * Display the data the user has entered from the (previous) post_item page.  The data now resides in a general entry item object
 * Show the general info then display board specfic detail
 */ 
		private void BindData(classes.Blog sBlog)
		{

            ErrorLog.ErrorRoutine(false, "PP:BindData -> Category:" + sBlog.BlogCat);

            hdnUserDir.Value = Session["userDir"].ToString();
            
            //show today's date
            lblDateData.Text = String.Format("{0:MM/dd}", DateTime.Now);

            //details
            lblDetailsData.Text = sBlog.MyBlog.ToString();

            //TODO: ShowPicsForPreview(bItem)
            
            //show pictures waiting in temp dir
                
            //Pic1
            Pic1.ImageUrl = GetPicPath(sBlog.ImgPath1);
            if (Pic1.ImageUrl.IndexOf("s1x1.gif") != -1)
            {

                Pic1.ImageUrl = "..images/s1x1.gif";
                Pic1.Width = 157;
                Pic1.Height = 211;
                hdnProcPics.Value = "False";

            }
            else //do thmbnail
            {
                Pic1ThmbNail.ImageUrl = GetPicPath("thmbNail_" + sBlog.ImgPath1);
                Pic1ThmbNail.Visible = true;
                Pic1ThmbNail.Width = 75;
                Pic1ThmbNail.Height = 75;
                hdnProcPics.Value = "True";
            }

            //Pic2

            Pic2.ImageUrl = GetPicPath(sBlog.ImgPath2);
            if (Pic2.ImageUrl.IndexOf("s1x1.gif") != -1)
            {
                Pic2.Width = 1;
                Pic2.Height = 1;

            }
            else
            {
                Pic2ThmbNail.Visible = true;
                Pic2ThmbNail.ImageUrl = GetPicPath("thmbNail_" + sBlog.ImgPath2);
                Pic2ThmbNail.Width = 75;
                Pic2ThmbNail.Height = 75;
                hdnProcPics.Value = "True";
            }

            lblAdTitle.Text = "&nbsp;Blog Title:&nbsp;";
            lblAdTitle.Visible = true;
            lblAdTitleData.Text = sBlog.Title;


		}		
		
/**
 */ 
		public string DecodeBoard(int cat,object BoardCode)
		{
            string rtn = "";

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
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
			this.Load += new System.EventHandler(this.Page_Load);


            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

		}
		#endregion
/*
 */ 
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "PP:imgContinue_Click");

            classes.Blog tmpBlog2 = (classes.Blog)Session["Blog"];

            // Tasks:
            // - Move pics from temp dir to surf dir then delete *.* in temp dir
            // - Write entry to db from object

            if (tmpBlog2 == null)
            {
                ErrorLog.ErrorRoutine(false, "Error: Blog obj NULL!");
                ErrorLog.ErrorRoutine(false, "SessionID: " + Session.SessionID);

                pnlError.Visible = true;
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "Blog OK!");
            }

            //tmpBoardItem2.Created = DateTime.Now;
            //tmpBoardItem2.Details = Global.CheckString(tmpBoardItem2.Details);
            //tmpBoardItem2.Brand = Global.CheckString(tmpBoardItem2.Brand);

            //check for pics
            if (hdnProcPics.Value == "True")
            {
                if (MoveFiles(tmpBlog2.BlogCat))
                {
                    DeletePicsInTempDir();
                }
            }

            //Save entry
            try
            {
                tmpBlog2.Title = Global.CheckString(tmpBlog2.Title);
                tmpBlog2.MyBlog = Global.CheckString(tmpBlog2.MyBlog);

                //write entry to db
                if (tmpBlog2.SaveItem())
                {
                    //update blog count?
                    Response.Redirect("BlogFinish.aspx");
                }
                else
                {
                    lblStatus.Text = "Error posting";
                }

            }
            catch { lblStatus.Text = "ERROR: "; }
            finally { }

            //TODO: Remove.  Do we needed it?
            //Session["Item"] = tmpBoardItem;        
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            classes.Blog tmpBlog = (classes.Blog)Session["Blog"];
            tmpBlog.EditMode = true;
            Session["Blog"] = tmpBlog;
            Response.Redirect("BlogItem.aspx");        
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

                    //lnkEmailData.Text = SQLReader["txtEmail"].ToString();
                    //lnkEmailData.Attributes.Add("href", "mailto:" + SQLReader["txtEmail"].ToString());

                    //lblPhoneData.Text = SQLReader["txtPhoneNum"].ToString();
                    //lblPhoneData.Visible = ShowPhone(SQLReader["iShowPhoneNum"]);

                }

            }

            catch
            {
                lblStatus.Text = "Error reading contact data";
                ErrorLog.ErrorRoutine(false, "Error: Can't read contact info");
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
		//public bool UpdateEntryCount(string uiD)
	//	{
			//bool retVal;
            //return retVal;
      //  }
            //string conn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
			//SqlConnection myConnection = new SqlConnection(conn);
		//	string strSQL = "UPDATE tblUser SET iEntryCount = iEntryCount + 1 WHERE iD = '" + uiD + "'";
			
            
		//	try
		//	{
				//myConnection.Open();
				//SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				//objCommand.ExecuteNonQuery();
				//retVal = true;
		//	}
		//	catch
		//	{
				//lblStatus.Text = "ERROR on UPDATE: " + strSQL;
				//retVal = false;
		//	}
		//	finally
		//	{
				//myConnection.Close();
				
		//	}
	


/*
 * Moves media files from temp dir to permanent home in user dir
 */ 
        private bool MoveFiles(object catVal)
        {

            ErrorLog.ErrorRoutine(false, "PP:Moving files to dir: " + "blog");
            
            string srcPath,srcPath_T, targetPath1, targetPath2, targetPath3, targetPath4;
            string strUserDir = hdnUserDir.Value;

            string strBaseDir = AppDomain.CurrentDomain.BaseDirectory + @"\users\" + hdnUserDir.Value;
            string strTmpDir = strBaseDir + @"\temp\";
            string strCatDir = strBaseDir + @"\" + @"blog";
            
            targetPath1 = "";
            targetPath2 = "";

            //Move files from temp to user dir for adtypes other than sell
                //check to make sure pic are not blank entry or the noimage.gif.  *blank entries are denoted by a 1x1px clear gif.
                if (Path.GetFileName(Pic1.ImageUrl) != "s1x1.gif" && Path.GetFileName(Pic1.ImageUrl) != "noimage.gif")
                {
                    srcPath = strTmpDir + @"\" + Path.GetFileName(Pic1.ImageUrl);
                    srcPath_T = strTmpDir + @"\" + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                    
                    //check for existing category dir
                    if (!Directory.Exists(strCatDir))
                    {
                        Directory.CreateDirectory(strCatDir);

                    }
                    //Move Larger Image
                    targetPath1 = strCatDir + @"\" + Path.GetFileName(Pic1.ImageUrl);
                    File.Move(srcPath, targetPath1);
                    //Move ThumbNail Image
                    targetPath1 = strCatDir + @"\" + "thmbNail_" + Path.GetFileName(Pic1.ImageUrl);
                    File.Move(srcPath_T, targetPath1);

                }

                if (Path.GetFileName(Pic2.ImageUrl) != "s1x1.gif")
                {
                    srcPath = strTmpDir + @"\" + Path.GetFileName(Pic2.ImageUrl);
                    srcPath_T = strTmpDir + @"\" + "thmbNail_" + Path.GetFileName(Pic2.ImageUrl);
                    if (!Directory.Exists(strCatDir))
                    {
                        Directory.CreateDirectory(strCatDir);

                    }
                    //Larger Image
                    targetPath2 = strCatDir + @"\" + Path.GetFileName(Pic2.ImageUrl);
                    File.Move(srcPath, targetPath2);
                    //Thumbnail
                    targetPath2 = strCatDir + @"\" + "thmbNail_" + Path.GetFileName(Pic2.ImageUrl);
                    File.Move(srcPath_T, targetPath2);
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
                string strTmpDir = AppDomain.CurrentDomain.BaseDirectory + @"\users\" + hdnUserDir.Value + @"\temp\";

                if (Directory.Exists(strTmpDir))
                {
                    string[] files = Directory.GetFiles(strTmpDir);
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
            catch
            {
                ErrorLog.ErrorRoutine(false, "ErrorDeletingTempPics");
                return false;
            }        
        }
	}
}
