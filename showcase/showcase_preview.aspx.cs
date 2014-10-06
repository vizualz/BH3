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



namespace BoardHunt.showcase
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	/// 

	public partial class showcase_preview : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.Label lblPhoneData;
		protected System.Web.UI.WebControls.Label lblFinsData;
		protected System.Web.UI.WebControls.Label lblTailData;
		protected System.Web.UI.WebControls.Label lblWidthData;

		protected System.Web.UI.WebControls.Label lblHeightInData;
		protected System.Web.UI.WebControls.Label lblHeightFtData;
		protected System.Web.UI.WebControls.Label lblHeight;

        protected System.Web.UI.WebControls.LinkButton lnkEmailData;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected System.Web.UI.WebControls.Label lblLocation;
		protected System.Web.UI.WebControls.Label lblThick;


        //TODO: Replace these gloabal vars
        //static string strUserDir;
        //static bool blnNoPics;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Global.AuthenticateUser();
            if (Session["acctType"].ToString() != "3")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];

            if (!Page.IsPostBack)
            {

                ErrorLog.ErrorRoutine(false, "Preview_post:BindData -> Category:" + tmpBoardItem.Category);
                ErrorLog.ErrorRoutine(false, "PP:SessionID:" + Session.SessionID);
    
                // Put user code to initialize the page here
			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

			    //Hide all sub-panels then enable accordingly

                pnlBoardType.Visible = false;

                //imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
                
                //Load up display data and show a preview of the posting
                if (tmpBoardItem != null)
                {
                    BindData(tmpBoardItem);
                }
                else
                {
                    lblStatus.Text = "Error loading data.";
                    lblStatus.CssClass = "errorLabel";
                    return;
                }
			}

            //reload the session item
            //Session["Item"] = tmpBoardItem;
		}

/**
 * Display the data the user has entered from the (previous) post_item page.  The data now resides in a general entry item object
 * Show the general info then display board specfic detail
 */ 
		private void BindData(classes.BoardItem bItem)
		{

            ErrorLog.ErrorRoutine(false, "PP:BindData -> Category:" + bItem.Category);

            hdnUserDir.Value = Session["userDir"].ToString();
            
            //show today's date
            lblDateData.Text = String.Format("{0:MM/dd}", DateTime.Now);

            //location-region and town
            //lblLocation.Text = Global.ProperSpace(DecodeRegion(Convert.ToInt32(bItem.Location)));
            //if (bItem.Town.Length > 0)
            //{
            //    lblLocation.Text += " - " + bItem.Town;
            //}

            //brand
            lblBrandData.Text = bItem.Brand;
            //price
            lblPriceData.Text = "$" + bItem.Price.ToString();
            //details
            lblDetailsData.Text = bItem.Details.ToString();
            //boardtype label
            lblBoardType.Text = "Board Type: ";

            //TODO: ShowPicsForPreview(bItem)
            
            //show pictures waiting in temp dir
            if (bItem.AdType.ToString() != "2")    //1 = selling items; 2 = wanted; 3 = showcase
            {
                //Pic1
                Pic1.ImageUrl = GetPicPath(bItem.ImgPath1);
                if (Pic1.ImageUrl.IndexOf("s1x1.gif") != -1)
                {

                    Pic1.ImageUrl = "images/noimage.gif";
                    Pic1.Width = 157;
                    Pic1.Height = 211;
                    hdnProcPics.Value = "False";

                }
                else //do thmbnail
                {
                    Pic1ThmbNail.ImageUrl = GetPicPath("thmbNail_" + bItem.ImgPath1);
                    Pic1ThmbNail.Visible = true;
                    Pic1ThmbNail.Width = 75;
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
                    Pic2ThmbNail.Width = 75;
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
                    Pic3ThmbNail.Width = 75;
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
                    Pic4ThmbNail.Width = 75;
                    Pic4ThmbNail.Height = 75;
                    hdnProcPics.Value = "True";
                }

            }
            else //show wanted pic
            {
                Pic1.ImageUrl = "images//wantedbig.gif";
                Pic1.Height = 214;
                Pic1.Width = 168;
                hdnProcPics.Value = "False";
            }

            //Show e-mail and possibly phone num
            //ShowContactDetails();

            //board specific data
            switch (bItem.Category.ToString())
			{
				case "1": //surf

                    //switch (bItem.BoardType)
                    switch (bItem.AdType)
                    {
                        case 3: //showcase

                            lblWeb.Text = bItem.WebURL;
                            pnlWeb.Visible = true;
                            lblGenDims.Text = bItem.GenDimensions;
                            pnlGenDims.Visible = true;
                            lblAdTitle.Text = "&nbsp;Title:&nbsp";
                            lblAdTitle.Visible = true;
                            lblAdTitleData.Text = bItem.AdTitle;
                            //pnlGearItem.Visible = true;

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

                    pnlGenDims.Visible = true;
                    lblGenDims.Text = bItem.GenDimensions;
 
                    break;
						
				case "4": //gear
                    lblBrand.Text = "Brand:" + "";

                    pnlGearItem.Visible = true;
                    lblGearItem.Visible = true;
                    pnlBoardType.Visible = false;
                    lblGearItemData.Text = bItem.GearItem;
                    break;

			}

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
			this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
			this.imgContinue.Click += new System.Web.UI.ImageClickEventHandler(this.imgContinue_Click);

		}
		#endregion
/**
 */ 

		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
            tmpBoardItem.EditMode = true;
            Session["Item"] = tmpBoardItem;
            Response.Redirect("showcase_item.aspx");
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
            classes.BoardItem tmpBoardItem2 = (classes.BoardItem)Session["Item"];

            // - Tasks:
            // - Move pics from temp dir to surf dir then delete *.* temp dir
            // - Write entry to db from object

            if (tmpBoardItem2 == null)
            {
                pnlError.Visible = true;
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "ShowcaseItem OK!");
            }
            
            tmpBoardItem2.Created = DateTime.Now;
            tmpBoardItem2.Details = Global.CheckString(tmpBoardItem2.Details);
            tmpBoardItem2.Brand = Global.CheckString(tmpBoardItem2.Brand);

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
                        Response.Redirect("../post_finish.aspx");
                    }
                }
                else
                {
                    lblStatus.Text = "Error posting";
                }
            }
            catch{lblStatus.Text = "ERROR: ";}
            finally{}

            //TODO: Remove.  Do we needed it?
            //Session["Item"] = tmpBoardItem;
		}
/*
 * Moves media files from temp dir to permanent home in user dir
 */ 
        private bool MoveFiles(object catVal, int adType)
        {
            string strCat = Enum.GetName(typeof(Global.BOARDCAT_DIRS), catVal);

            ErrorLog.ErrorRoutine(false, "PP:Moving files to dir: " + strCat);
            
            string srcPath,srcPath_T, targetPath1, targetPath2, targetPath3, targetPath4;
            string strUserDir = hdnUserDir.Value;

            string strBaseDir = AppDomain.CurrentDomain.BaseDirectory + @"\users\" + hdnUserDir.Value;
            string strTmpDir = strBaseDir + @"\temp\";
            string strCatDir = strBaseDir + @"\" + strCat;
            

            targetPath1 = "";
            targetPath2 = "";
            targetPath3 = "";
            targetPath4 = "";

            //Move files from temp to user dir for adtypes other than sell
            if (adType != (int)2)
            {

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

                if (Path.GetFileName(Pic3.ImageUrl) != "s1x1.gif")
                {
                    srcPath = strTmpDir + @"\" + Path.GetFileName(Pic3.ImageUrl);
                    srcPath_T = strTmpDir + @"\" + "thmbNail_" + Path.GetFileName(Pic3.ImageUrl);
                    if (!Directory.Exists(strCatDir))
                    {
                        Directory.CreateDirectory(strCatDir);

                    }
                    //Larger Image
                    targetPath3 = strCatDir + @"\" + Path.GetFileName(Pic3.ImageUrl);
                    File.Move(srcPath, targetPath3);
                    //ThumbNail Image
                    targetPath3 = strCatDir + @"\" + "thmbNail_" + Path.GetFileName(Pic3.ImageUrl);
                    File.Move(srcPath_T, targetPath3);

                }

                if (Path.GetFileName(Pic4.ImageUrl) != "s1x1.gif")
                {
                    srcPath = strTmpDir + @"\" + Path.GetFileName(Pic4.ImageUrl);
                    srcPath_T = strTmpDir + @"\" + "thmbNail_" + Path.GetFileName(Pic4.ImageUrl);
                    if (!Directory.Exists(strCatDir))
                    {
                        Directory.CreateDirectory(strCatDir);

                    }
                    //Larger Image
                    targetPath4 = strCatDir + @"\" + Path.GetFileName(Pic4.ImageUrl);
                    File.Move(srcPath, targetPath4);
                    //Thumbnail Image
                    targetPath4 = strCatDir + @"\" + "thmbNail_" + Path.GetFileName(Pic4.ImageUrl);
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
