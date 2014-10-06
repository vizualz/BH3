//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			showcase_item.apx.cs
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


namespace BoardHunt.showcase
{
	/// <summary>
	/// Summary description for post_item.
	/// </summary>
	/// 
	
	public partial class showcase_item : System.Web.UI.Page
	{

   //for Other Board cat




        protected System.Web.UI.WebControls.ImageButton imgBtnFinHelp;

        protected System.Web.UI.WebControls.LinkButton lnkHlpBoard;


		protected System.Web.UI.WebControls.Button CmdUpload;

        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label lblFins;
        protected System.Web.UI.WebControls.Label lblTail;
        protected System.Web.UI.WebControls.Label lblHtFt;
        protected System.Web.UI.WebControls.Label lblHtIn;



        //protected System.Web.UI.WebControls.DropDownList cboBoardType;
		//protected System.Web.UI.WebControls.DropDownList cboTailType;

        protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator3;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator4;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
       

        protected System.Web.UI.WebControls.TextBox txtThick;
        protected System.Web.UI.WebControls.TextBox txtThickNum;
        protected System.Web.UI.WebControls.TextBox txtThickDNum;
        protected System.Web.UI.WebControls.TextBox txtWidthNum;
        protected System.Web.UI.WebControls.TextBox txtWidthDNum;




		//string usrId;
		//int PageType;	//is this adtype?

        struct BoardStruct
        {
            public classes.BoardItem sItem;
            public string[] tmpArray;
        }  

		protected void Page_Load(object sender, System.EventArgs e)
		{
            
            // Put user code to initialize the page here
			Global.AuthenticateUser();

            if (Session["acctType"].ToString() != "3")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            if (Session["Item"] == null)
            {
                HttpContext.Current.Response.Redirect("../Login.aspx");
            }

            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
			
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );	
			
			// Put user code to initialize the page here
            //if (pnlItem.Visible)
            //{ 
            //    PageType = 0; //wtf is this?  adtype?
            //}

			//usrId = Session["userId"].ToString();   //TODO: remove if this isn't doing squat
            
            if (!Page.IsPostBack)  
			{

                BindData(tmpBoardItem);

                //Check for editMode
                if (tmpBoardItem.EditMode)
                {
                    LoadForEdits(tmpBoardItem);
                }
                else
                {
                    //setup pic panel for first time thru; TODO: stub this out into it's own function later
                    img1.ImageUrl = "../images/s1x1.gif";
                    img2.ImageUrl = "../images/s1x1.gif";
                    img3.ImageUrl = "../images/s1x1.gif";
                    img4.ImageUrl = "../images/s1x1.gif";

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
			}

            switch (tmpBoardItem.AdType)
            {

                case 3: //showcase
                    pnlBoardType.Visible = false;
                    pnlBrand.Visible = true;
                    pnlGenDims.Visible = true;
                    pnlWeb.Visible = true;
                    pnlGearItem.Visible = true;
                    lblItem.Text = "Item: ";
                   
                    break;

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
			this.imgBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgBack_Click);
			this.imgContinue.Click += new System.Web.UI.ImageClickEventHandler(this.imgContinue_Click);

		}
		#endregion
/*
*/ 
        public void BindData(classes.BoardItem tBoardItem)
        {
            //sets the dynamic UI up according to category
            //FillDropDowns(tBoardItem.Category.ToString());
            SetUpUIForCategory(tBoardItem.Category.ToString());
            lblCat.Text = Global.up1(DecodeiCat(tBoardItem.Category));
            
        }
/*
*/
        public void SetUpUIForCategory(string cat)
        {

            switch (cat)
            {
                //surf
                case "1":
                    lblBrand.Text += "/Shaper:&nbsp;";
                    pnlGenDims.Visible = false;
                    imgBtnHelp.Attributes.Add("onClick", "popUpHelp('1')");
                    break;
                //snow
                case "2":
                    lblBrand.Text += ":" + "&nbsp;";
                    pnlGenDims.Visible = false;
                    imgBtnHelp.Attributes.Add("onClick", "popUpHelp('2')");
                    
                    break;
                //other board
                case "3":
                    lblBrand.Text += ":" + "&nbsp;";
                    pnlGenDims.Visible = true;
                    chkOther.Visible = true;
                    chkOther.Checked = false;
                    txtOtherBoard.Visible = true;
                    txtOtherBoard.Enabled = false;
                    imgBtnHelp.Visible = false;
                    break;
                //gear
                case "4":
                    //pnlBoardType.Visible = false;
                    pnlGearItem.Visible = true;
                    lblBrand.Text += ":" + "&nbsp;";
                    pnlGenDims.Visible = false;
                    imgBtnHelp.Visible = false;
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
        
        private void imgContinue_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            //get object from session object
            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
            
            //kick out if validation failed
            if (!(Page.IsValid))
			{
				return;
			}

            //array holder for pics
            string[] strImgPathArray = new string[4];

            //init img array with blank space
            for (int j = 0; j <= 3; j++)
            {
                strImgPathArray[j] = "";
            }

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, delete,
            //, or change an image. ***NOTE: For BETA entry updates will not use preview_post.  
            //This means pics will *not* be moved to a temp dir as we do in posting.  This should change eventually.'
            //Delete any files in imgDel array
            bool blnProcImgs = false;

            switch (rdoImgMgr1.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tmpBoardItem.ImgPath1 = "";
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
                    tmpBoardItem.ImgPath2 = "";
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
                    tmpBoardItem.ImgPath3 = "";
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

            switch (rdoImgMgr4.SelectedValue)
            {
                case "Keep":
                    break;
                case "Delete":
                    tmpBoardItem.ImgPath4 = "";
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
                BoardStruct bStruct = new BoardStruct();
                bStruct.sItem = tmpBoardItem;
                bStruct.tmpArray = strImgPathArray;

                bStruct = UpLoadAllImages(ref bStruct);

                tmpBoardItem = bStruct.sItem;
            }

            //Save common data
            tmpBoardItem.Brand = txtBrand.Text;
            tmpBoardItem.Details = txtDetails.Text;
            tmpBoardItem.Price = Convert.ToDecimal(txtPrice.Text);
            tmpBoardItem.IUser = Convert.ToInt32(Session["userId"].ToString());
            tmpBoardItem.Location = (int)1;

            tmpBoardItem.AdTitle = Global.CheckString(txtAdTitle.Text);

            //Save category specific data
            switch (tmpBoardItem.Category.ToString())
            {
                case "1": //surf

                    switch (tmpBoardItem.AdType)
                    {

                        case 3: //showcase
                            tmpBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                            tmpBoardItem.WebURL = Global.CheckString(txtWebURL.Text.Trim());
                            break;
                    }
                    
                    break;

                case "2":   //snow

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
                        tmpBoardItem.OtherBoardType = Global.CheckString(txtOtherBoard.Text);
                    }
                    else
                    {
                        //tmpBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                    }
                    
                    tmpBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);

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
                    tmpBoardItem.GearItem = Global.CheckString(txtGearItem.Text);

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

                    switch (tmpBoardItem.AdType)
                    {
                        case 3: //showcase
                            tmpBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                            tmpBoardItem.WebURL = Global.CheckString(txtWebURL.Text.Trim());
                            break;
                    }

                    break;
            }

            //Save object to session variable
            Session["Item"] = tmpBoardItem;

            //Goto preview_post
            Response.Redirect("showcase_preview.aspx");
        }

/*
 * TODO: Still need to code for all cats and adtypes
 */ 
        private bool LoadForEdits(classes.BoardItem tempBoardItem)
        {
            bool retVal = false;

            //pic setup
            if (tempBoardItem.AdType == (int)1)
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
                    img3.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];// tempBoardItem.ImgPath1;
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
                    img4.ImageUrl = path + "thmbNail_" + strArray[strArray.Length - 1];// tempBoardItem.ImgPath1;
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

                    txtPrice.Text = tempBoardItem.Price.ToString();
                    txtDetails.Text = tempBoardItem.Details.ToString();
                    if (tempBoardItem.AdType == (int)1)  //selling only
                    {
                        txtBrand.Text = tempBoardItem.Brand.ToString();

                        txtWidthDNum.Text = tempBoardItem.WidthDenum.ToString();
                        txtWidthNum.Text = tempBoardItem.WidthNum.ToString();
                        txtThick.Text = tempBoardItem.Thickness.ToString();
                        txtThickDNum.Text = tempBoardItem.ThickDenum.ToString();
                        txtThickNum.Text = tempBoardItem.ThickNum.ToString();

                    }
                    retVal = true;
                    break;
            }
            return retVal;
        }
/*
 */ 
		private void imgBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
            tmpBoardItem.EditMode = true;
            Session["Item"] = tmpBoardItem;			
            
            Response.Redirect ("showcase.aspx");
		}

		//=================================
		//Error Checking & Helper Functions
		//=================================

        //private void FillDropDowns(string category)
        //{
        //    //declare variables	
        //    string strSQL;
        //    string myConnectString;
        //    //string category;
        //    //category = tmpBoardItem.Category.ToString();

        //    //Create connect string
        //    myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

        //    //Build SQL
        //    strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + category + "'; SELECT * FROM LK_TailType ; SELECT * FROM LK_FinType";

        //    SqlConnection myConnection = new SqlConnection(myConnectString);

        //    // Read sample item info from SQL into a DataSet
        //    DataSet dsItems = new DataSet();

        //    SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

        //    objAdapter.TableMappings.Add("Table", "tblBoardType");
        //    objAdapter.TableMappings.Add("Table1", "tblTail");
        //    objAdapter.TableMappings.Add("Table2", "tblFins");

        //    objAdapter.Fill(dsItems);

        //    cboBoardType.DataSource = dsItems;
        //    cboBoardType.DataMember = "tblBoardType";
        //    cboBoardType.DataTextField = "BoardType";
        //    cboBoardType.DataValueField = "iD";
        //    cboBoardType.DataBind();
        //    //cboBoardType.SelectedIndex = (int)0;

        //    cboTailType.DataSource = dsItems;
        //    cboTailType.DataMember = "tblTail";
        //    cboTailType.DataTextField = "TailType";
        //    cboTailType.DataValueField = "iD";
        //    cboTailType.DataBind();
        //    cboTailType.SelectedIndex = (int)0;

        //    //radioFins.DataSource = dsItems;
        //    //radioFins.DataMember = "tblFins";
        //    //radioFins.DataTextField = "finType";
        //    //radioFins.DataValueField = "iD";
        //    //radioFins.DataBind();
        //    //radioFins.SelectedIndex = (int)2;

        //    cboFins.DataSource = dsItems;
        //    cboFins.DataMember = "tblFins";
        //    cboFins.DataTextField = "finType";
        //    cboFins.DataValueField = "iD";
        //    cboFins.DataBind();
        //    cboFins.SelectedIndex = (int)2;

        //    myConnection.Close();        

        //}
        
        protected void btnShowPnl_Click(object sender, System.EventArgs e)
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
        public void CheckPrice(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			
			double tempVal;

			args.IsValid = true;

            //strip out dollar sign if present
            if (txtPrice.Text.IndexOf("$") != -1)
            {
                txtPrice.Text = Global.StrReplace(txtPrice.Text, @"\$");
                 
            }

			if (!IsNumeric(txtPrice.Text))
			{
				args.IsValid = false;
				CustomValidator5.ErrorMessage = "!";
			}
			
			try
			{
				tempVal = Convert.ToDouble(txtPrice.Text);
			}
			
			catch
			{
				CustomValidator5.ErrorMessage = "!";
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
			Response.Redirect("showcase.aspx");
			
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
			catch
			{
				lblStatus.Text = "UPDATE ERROR: " + strSQL;
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
        private BoardStruct UpLoadAllImages(ref BoardStruct tmpStruct)
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
                                    tmpStruct.sItem.ImgPath1 = tmpStruct.tmpArray[i];
                                    ErrorLog.ErrorRoutine(false, "Setting1: " + tmpStruct.tmpArray[i]);
                                    rdoImgMgr1.ClearSelection();

                                }
                                else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                {
                                    tmpStruct.sItem.ImgPath2 = tmpStruct.tmpArray[i];
                                    ErrorLog.ErrorRoutine(false, "Setting2: " + tmpStruct.tmpArray[i]);
                                    rdoImgMgr2.ClearSelection();
                                }
                                else if (rdoImgMgr3.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                {
                                    tmpStruct.sItem.ImgPath3 = tmpStruct.tmpArray[i];
                                    ErrorLog.ErrorRoutine(false, "Setting3: " + tmpStruct.tmpArray[i]);
                                    rdoImgMgr3.ClearSelection();
                                }
                                else
                                {
                                    if (rdoImgMgr4.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
                                    {

                                        tmpStruct.sItem.ImgPath4 = tmpStruct.tmpArray[i];
                                        ErrorLog.ErrorRoutine(false, "Setting4: " + tmpStruct.tmpArray[i]);
                                        rdoImgMgr4.ClearSelection();
                                    }
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
        
        }//end function
    
    }//end class
}
