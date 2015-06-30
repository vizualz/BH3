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
using System.Collections.Generic;


namespace BoardHunt
{
    /// <summary>
    /// Summary description for post_item.
    /// </summary>
    /// 

    public partial class edit_item : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Button CmdUpload;
        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        //protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected const int picSizeBigX = 400;
        protected const int picSizeBigY = 400;

        protected const int picSizeThmbX = 75;
        protected const int picSizeThmbY = 75;

        List<HttpPostedFile> lstEditUploadedFiles { get { return (List<HttpPostedFile>)Session["lstEditUploadedFiles"]; } set { Session["lstEditUploadedFiles"] = value; } }


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["name"] != null)
            {
                if (lstEditUploadedFiles == null)
                {
                    lstEditUploadedFiles = new List<HttpPostedFile>();
                }

                foreach (string s in Request.Files)
                {
                    HttpPostedFile file = Request.Files[s];

                    lstEditUploadedFiles.Add(file);
                }
            }
            else
            {
                //Logged in?
                string[] arString;
                arString = Request.QueryString.GetValues("Act");
                if (arString != null)
                {
                    hdnActCode.Value = arString[0].ToString();
                }
                else
                {
                    Global.AuthenticateUser();
                }

                //Embed .js
                //ClientScript.RegisterClientScriptInclude(this.GetType(),"bh",@"include\bh.js");

                //Disable File Uploads
                File1.Disabled = true;
                File2.Disabled = true;
                File3.Disabled = true;
                File4.Disabled = true;

                hdnEntryId.Value = Request.QueryString["iD"];


                if (!(Page.IsPostBack))
                {

                    //default all pics to a clear gif
                    img1.ImageUrl = @"\images\s1x1.gif";
                    img2.ImageUrl = @"\images\s1x1.gif";
                    img3.ImageUrl = @"\images\s1x1.gif";
                    img4.ImageUrl = @"\images\s1x1.gif";

                    BindItemData();

                    //hide to minimize board post breaks
                    rdoImgMgr4.Enabled = false;
                    rdoImgMgr4.Style.Add("Display", "None");

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
<<<<<<< HEAD

=======
            //this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
            //this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
            //this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
>>>>>>> Stash
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);

        }
        #endregion

        /**
*/
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (hdnEntryType.Value == "4")
                Response.Redirect("post_manager.aspx?q=4", true);
            Response.Redirect("post_manager.aspx", true);
        }

        /**
         */
        ////
        //Load up all the data for the selected item
        /// 
        public void BindItemData()
        {

            string strSQL;
            string strServerURL;
            string strCat;
            int iStrCat;
            string adType;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            classes.BoardItem tmpBoardItem = new classes.BoardItem();
            tmpBoardItem.EntryId = Convert.ToInt32(hdnEntryId.Value);

            //Get server URL
            strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            strSQL = @"SELECT e.*, u.userDir  
                       FROM tblEntry e 
                       INNER JOIN tblUser u 
                       ON e.iUser = u.id ";
            //"AND e.iUser IN (select distinct id from tblUser where adtype < 3)";
            strSQL += @"WHERE e.iD = '" + hdnEntryId.Value + "'";

            //TODO: Change query for adtype!
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    //ErrorLog.ErrorRoutine(false,"Seesion: " + Session["userId"].ToString() + " - DB: " + dbManager.DataReader["iUser"].ToString() + 

                    //SECURITY CHECK: Ensure creator or admin is editing
                    if (dbManager.DataReader["iUser"].ToString() != Session["userId"].ToString() && (Session["EmailId"].ToString() != "admin@boardhunt.com"))
                    {
                        Response.Redirect("UserMenu.aspx", true);
                        classes.Email.SendEmail("hack attempt", "info@boardhunt.com", "Hack attempt at posting: " + hdnEntryId.Value);
                    }


                    //verify ACT code
                    if (hdnActCode.Value.Length > 0)
                    {
                        if ((hdnActCode.Value != dbManager.DataReader["activateCode"].ToString()))
                        {
                            lblStatus.Text = "Invalid code!";
                            return;
                        }
                    }


                    hdnEntryType.Value = dbManager.DataReader["adType"].ToString();

                    //set control values
                    strCat = dbManager.DataReader["iCategory"].ToString();
                    iStrCat = Convert.ToInt32(strCat);
                    tmpBoardItem.Category = iStrCat;
                    //tmpBoardItem.Created = Convert.ToDateTime(dbManager.DataReader["dCreateDate"].ToString());
                    LoadControlData(strCat);

                    cboRegion.SelectedValue = dbManager.DataReader["Location"].ToString();
                    txtTown.Text = dbManager.DataReader["txtTown"].ToString();

                    //Set and get values for textboxes
                    txtBrand.Text = dbManager.DataReader["txtBrand"].ToString();

                    lnkManage.NavigateUrl = "post_manager.aspx";



                    switch (strCat) //General category
                    {
                        case "1":   //SURFBOARDS

                            switch (hdnEntryType.Value) //selling,wanted,showcase, or shaper
                            {
                                case "1":
                                    pnlSurfOnly.Visible = true;
                                    pnlHeight.Visible = true;
                                    txtHtFt.Text = dbManager.DataReader["iHtFt"].ToString();
                                    txtHtIn.Text = dbManager.DataReader["iHtIn"].ToString();
                                    txtShaper.Text = dbManager.DataReader["txtShaper"].ToString();

                                    cboBoardType.SelectedValue = dbManager.DataReader["iBoardType"].ToString();
                                    cboTailType.SelectedValue = dbManager.DataReader["iTailType"].ToString();
                                    cboFins.SelectedValue = dbManager.DataReader["iFins"].ToString();

                                    txtWidth.Text = dbManager.DataReader["width"].ToString();
                                    txtWidthNum.Text = dbManager.DataReader["widthNum"].ToString();
                                    txtWidthDNum.Text = dbManager.DataReader["widthDeNum"].ToString();

                                    txtThick.Text = dbManager.DataReader["Thick"].ToString();
                                    txtThickNum.Text = dbManager.DataReader["ThickNum"].ToString();
                                    txtThickDNum.Text = dbManager.DataReader["ThickDeNum"].ToString();
                                    hdnPrice.Value = txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                                    break;
                                case "2":
                                    pnlSurfOnly.Visible = true;
                                    pnlHeight.Visible = true;
                                    txtHtFt.Text = dbManager.DataReader["iHtFt"].ToString();
                                    txtHtIn.Text = dbManager.DataReader["iHtIn"].ToString();

                                    cboBoardType.SelectedValue = dbManager.DataReader["iBoardType"].ToString();
                                    cboTailType.SelectedValue = dbManager.DataReader["iTailType"].ToString();
                                    cboFins.SelectedValue = dbManager.DataReader["iFins"].ToString();

                                    txtWidth.Text = dbManager.DataReader["width"].ToString();
                                    txtWidthNum.Text = dbManager.DataReader["widthNum"].ToString();
                                    txtWidthDNum.Text = dbManager.DataReader["widthDeNum"].ToString();

                                    txtThick.Text = dbManager.DataReader["Thick"].ToString();
                                    txtThickNum.Text = dbManager.DataReader["ThickNum"].ToString();
                                    txtThickDNum.Text = dbManager.DataReader["ThickDeNum"].ToString();
                                    hdnPrice.Value = txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                                    break;
                                case "4":
                                    //BoardType,GenDims,Price,Details
                                    pnlVideo.Visible = true;
                                    pnlSold.Visible = false;
                                    pnlGenDims.Visible = true;
                                    pnlSurfOnly.Visible = false;
                                    pnlHeight.Visible = false;
                                    pnlGearItem.Visible = false;
                                    pnlLocation.Visible = false;
                                    pnlBrand.Visible = false;
                                    pnlModel.Visible = true;
                                    //pnlShip.Visible = false;
                                    lblShipping.Visible = false;
                                    rdoShip.Visible = false;
                                    txtGenDims.Text = dbManager.DataReader["txtGenDimensions"].ToString();
                                    txtModel.Text = dbManager.DataReader["txtModel"].ToString();
                                    lnkManage.NavigateUrl = "post_manager.aspx?q=4";
                                    if (dbManager.DataReader["EntryVideoEmbed"] != null)
                                    {
                                        if (dbManager.DataReader["EntryVideoEmbed"].ToString().Length > 0)
                                            txtVideo.Text = dbManager.DataReader["EntryVideoEmbed"].ToString();
                                    }
                                    //stretch out textbox for width
                                    txtPrice.Width = Unit.Pixel(100);

                                    //return string if it's not null; otherwise return flt if it's not null
                                    if (dbManager.DataReader["txtPrice"] != DBNull.Value)
                                        txtPrice.Text = dbManager.DataReader["txtPrice"].ToString();
                                    else
                                    {
                                        if (dbManager.DataReader["fltPrice"] != DBNull.Value)
                                            txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                                        else
                                            txtPrice.Text = "0";
                                    }

                                    hdnPrice.Value = txtPrice.Text;
                                    break;

                                default:
                                    break;
                            }

                            break;
                        case "2":   //SNOWBOARDS
                            pnlHeight.Visible = true;
                            lblFtHt.Text = "cm";
                            lblFtIn.Visible = false;
                            cboBoardType.SelectedValue = dbManager.DataReader["iBoardType"].ToString();
                            txtHtFt.Text = dbManager.DataReader["iHtFt"].ToString();
                            txtHtIn.Visible = false;
                            hdnPrice.Value = txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                            break;
                        case "3":   //OTHER BOARDS
                            if (dbManager.DataReader["iBoardType"] != System.DBNull.Value || dbManager.DataReader["iBoardType"].ToString() != "")
                            {
                                if (Convert.ToInt32(dbManager.DataReader["iBoardType"].ToString()) > (int)0)
                                {
                                    cboBoardType.SelectedValue = dbManager.DataReader["iBoardType"].ToString();
                                }
                            }
                            else
                            {
                                txtOtherBoard.Text = dbManager.DataReader["txtOtherBoardType"].ToString();
                                cboBoardType.Enabled = false;
                                chkOther.Checked = true;
                            }
                            chkOther.Visible = true;
                            txtOtherBoard.Visible = true;
                            pnlGenDims.Visible = true;
                            txtGenDims.Text = dbManager.DataReader["txtGenDimensions"].ToString();
                            hdnPrice.Value = txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                            break;
                        case "4":   //GEAR
                            pnlBoardType.Visible = false;
                            pnlGearItem.Visible = true;
                            txtGearItem.Text = dbManager.DataReader["txtGearItem"].ToString();
                            hdnPrice.Value = txtPrice.Text = dbManager.DataReader["fltPrice"].ToString();
                            break;
                    }

                    txtDetails.Text = dbManager.DataReader["txtDetails"].ToString();

                    tmpBoardItem.ImgPath1 = dbManager.DataReader["txtImgPath1"].ToString();
                    tmpBoardItem.ImgPath2 = dbManager.DataReader["txtImgPath2"].ToString();
                    tmpBoardItem.ImgPath3 = dbManager.DataReader["txtImgPath3"].ToString();
                    tmpBoardItem.ImgPath4 = dbManager.DataReader["txtImgPath4"].ToString();

                    //TODO: add delete code

                    //scale img place holders to fit page
                    img1.Height = 100;
                    img1.Width = 100;
                    img2.Height = 100;
                    img2.Width = 100;
                    img3.Height = 100;
                    img3.Width = 100;
                    img4.Height = 100;
                    img4.Width = 100;

                    //get name of category
                    strCat = Enum.GetName(typeof(Global.BOARDCAT_DIRS), dbManager.DataReader["iCategory"]);

                    //set up pics (*if available) and radio controls
                    if (tmpBoardItem.ImgPath1.Length > (int)0)
                    {

                        img1.ImageUrl = strServerURL + "/users/" + Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/") + strCat + "/" + Path.GetFileName(tmpBoardItem.ImgPath1);
                        HiddenField1.Value = img1.ImageUrl;
                        File1.Disabled = true;

                    }
                    else //don't show delete or keep; set "change" to "add"
                    {
                        rdoImgMgr1.Items[2].Text = "Add";
                        rdoImgMgr1.Items.Remove("Delete");
                        rdoImgMgr1.Items.Remove("Keep");
                    }
                    if (tmpBoardItem.ImgPath2.Length > (int)0)
                    {

                        img2.ImageUrl = strServerURL + "/users/" + Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/") + strCat + "/" + Path.GetFileName(tmpBoardItem.ImgPath2);
                        HiddenField2.Value = img2.ImageUrl;
                        File2.Disabled = true;
                    }
                    else
                    {
                        rdoImgMgr2.Items[2].Text = "Add";
                        rdoImgMgr2.Items.Remove("Delete");
                        rdoImgMgr2.Items.Remove("Keep");
                    }

                    if (tmpBoardItem.ImgPath3.Length > (int)0)
                    {

                        img3.ImageUrl = strServerURL + "/users/" + Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/") + strCat + "/" + Path.GetFileName(tmpBoardItem.ImgPath3);
                        HiddenField3.Value = img3.ImageUrl;
                        File3.Disabled = true;
                    }
                    else
                    {
                        rdoImgMgr3.Items[2].Text = "Add";
                        rdoImgMgr3.Items.Remove("Delete");
                        rdoImgMgr3.Items.Remove("Keep");
                    }

                    if (tmpBoardItem.ImgPath4.Length > (int)0)
                    {

                        img4.ImageUrl = strServerURL + "/users/" + Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/") + strCat + "/" + Path.GetFileName(tmpBoardItem.ImgPath4);
                        HiddenField4.Value = img4.ImageUrl;
                        File4.Disabled = true;
                    }
                    else
                    {
                        rdoImgMgr4.Items[2].Text = "Add";
                        rdoImgMgr4.Items.Remove("Delete");
                        rdoImgMgr4.Items.Remove("Keep");
                    }
                    adType = dbManager.DataReader["adType"].ToString();
                    tmpBoardItem.AdType = Convert.ToInt32(adType);
                    rdoShip.SelectedValue = dbManager.DataReader["iShip"].ToString();

                    pnlAddImages.Visible = true;
                    //turn off unecessary controls if it's a wanted ad

                    if (adType == "2")
                    {
                        pnlAddImages.Visible = false;
                        pnlSurfOnly.Visible = false;
                        //pnlShip.Visible = false;
                        lblShipping.Visible = false;
                        rdoShip.Visible = false;
                    }
                }

                //save to a session object for later access
                //Global.gItem = EditItem;
                Session["userDir"] = dbManager.DataReader["userDir"].ToString();
                Session["eItem"] = tmpBoardItem;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error: " + ex.Message);
                classes.Email.SendErrorEmail("EditItem:BindItemData: " + ex.Message);
                lblStatus.Text = "Error. Click back on your browser and try again.";
            }

            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


        }

        /*
         * Loads/Binds the appropriate control data
         */
        public void LoadControlData(string strCat)
        {

            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //TODO: need try/catch
            //TODO: need switch statement
            strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = '" + strCat + "'; SELECT * FROM LK_TailType ; SELECT * FROM LK_FinType ;  SELECT * FROM LK_Region";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();

            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            objAdapter.TableMappings.Add("Table", "tblBoardType");
            objAdapter.TableMappings.Add("Table1", "tblTail");
            objAdapter.TableMappings.Add("Table2", "tblFins");
            objAdapter.TableMappings.Add("Table3", "tblRegion");

            objAdapter.Fill(dsItems);

            cboBoardType.DataSource = dsItems;
            cboBoardType.DataMember = "tblBoardType";
            cboBoardType.DataTextField = "BoardType";
            cboBoardType.DataValueField = "iD";
            cboBoardType.DataBind();

            cboTailType.DataSource = dsItems;
            cboTailType.DataMember = "tblTail";
            cboTailType.DataTextField = "TailType";
            cboTailType.DataValueField = "iD";
            cboTailType.DataBind();


            cboFins.DataSource = dsItems;
            cboFins.DataMember = "tblFins";
            cboFins.DataTextField = "finType";
            cboFins.DataValueField = "iD";
            cboFins.DataBind();

            cboRegion.DataSource = dsItems;
            cboRegion.DataMember = "tblRegion";
            cboRegion.DataTextField = "Region";
            cboRegion.DataValueField = "iD";
            cboRegion.DataBind();

            myConnection.Close();

        }

        /**
         * Update the user's entry changes
         */

        //private void imgUpdate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        protected void btnFinish_Click(object sender, System.EventArgs e)
        {
            //check for valid page
            if (!(Page.IsValid))
                return;

            //TODO: reset imgmgr

            Boolean delImgs = false;                          //flag to fire delete logic

            classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["eItem"];   //get board item

            int intHtFt, intHtIn, intWidth, intFins, TailType;
            int iWidthNum, iWidthDNum, iThick, iThickNum, iThickDNum;
            decimal decPrice;
            DateTime dLastModified;
            bool blnProcImgs;

            string[] strImgPathArray = new string[4];

            //Check for adtype;
            if (hdnEntryType.Value != "4")  //not ShaperHouse
            {
                //Location
                tmpBoardItem.Location = Convert.ToInt32(cboRegion.SelectedValue);
                //Town
                tmpBoardItem.Town = Global.CheckString(txtTown.Text);
                //brand
                tmpBoardItem.Brand = Global.CheckString(txtBrand.Text);
                tmpBoardItem.Shaper = Global.CheckString(txtShaper.Text);

                //price
                decPrice = Convert.ToDecimal(txtPrice.Text);
                tmpBoardItem.Price = decPrice;

                //Check for LOWER price change 
                if (decPrice < Convert.ToDecimal(hdnPrice.Value))
                    tmpBoardItem.PriceChange = 1;
            }
            else
                tmpBoardItem.TxtPrice = txtPrice.Text;


            dLastModified = DateTime.Now;

            //details
            tmpBoardItem.Details = Global.CheckString(txtDetails.Text);

            //save board category specific data
            switch (tmpBoardItem.Category)
            {
                case 1: //surf
                    //boardtype
                    tmpBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);

                    switch (tmpBoardItem.AdType)
                    {
                        case 1:

                            //TODO: look at this in depth: what if surf/wanted? problems on combo cat/adtypes
                            //Height (ft & in)
                            intHtFt = Convert.ToInt32(txtHtFt.Text);
                            tmpBoardItem.HtFt = intHtFt;

                            intHtIn = Convert.ToInt32(txtHtIn.Text);
                            tmpBoardItem.HtIn = intHtIn;

                            //Width
                            intWidth = Convert.ToInt32(txtWidth.Text);
                            tmpBoardItem.Width = intWidth;

                            iWidthNum = Convert.ToInt32(txtWidthNum.Text);
                            tmpBoardItem.WidthNum = iWidthNum;

                            iWidthDNum = Convert.ToInt32(txtWidthDNum.Text);
                            tmpBoardItem.WidthDenum = iWidthDNum;

                            //Thickness
                            iThick = Convert.ToInt32(txtThick.Text);
                            tmpBoardItem.Thickness = iThick;

                            iThickNum = Convert.ToInt32(txtThickNum.Text);
                            tmpBoardItem.ThickNum = iThickNum;

                            iThickDNum = Convert.ToInt32(txtThickDNum.Text);
                            tmpBoardItem.ThickDenum = iThickDNum;

                            //Tail
                            TailType = Convert.ToInt32(cboTailType.SelectedItem.Value);
                            tmpBoardItem.TailType = TailType;

                            //Fins
                            intFins = Convert.ToInt32(cboFins.SelectedValue);
                            tmpBoardItem.Fins = intFins;
                            break;
                        case 2:
                            //TODO: WANTED
                            break;
                        case 3:
                            //TODO: SHOWCASE
                            break;
                        case 4:
                            //MODELS
                            tmpBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                            tmpBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                            tmpBoardItem.Model = Global.CheckString(txtModel.Text);
                            tmpBoardItem.VideoLink = txtVideo.Text;
                            break;
                    }

                    break;

                //snow
                case 2:
                    //boardtype
                    tmpBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);

                    //Height (ft & in)
                    intHtFt = Convert.ToInt32(txtHtFt.Text);
                    tmpBoardItem.HtFt = intHtFt;

                    break;
                case 3: //OTHER BOARDS
                    if (chkOther.Checked)
                    {
                        tmpBoardItem.OtherBoardType = Global.CheckString(txtOtherBoard.Text);
                    }
                    else
                    {
                        tmpBoardItem.BoardType = Convert.ToInt32(cboBoardType.SelectedItem.Value);
                    }

                    tmpBoardItem.GenDimensions = Global.CheckString(txtGenDims.Text);
                    break;
                case 4: //GEAR
                    tmpBoardItem.GearItem = Global.CheckString(txtGearItem.Text);
                    break;
            }//end switch

            //Check for new or swapped pics.  The user has 3 possible options here; Keep, delete,
            //, or change an image. ***NOTE: For BETA release entry updates will not use preview_post.  
            //This means pics will *not* be moved to a temp dir as we do in first time posts.  This should change eventually.'
            //Delete any files in imgDel array

            //deal with imgs only if selling or models
            if (tmpBoardItem.AdType.ToString() == "1" || tmpBoardItem.AdType.ToString() == "4")
            {
                blnProcImgs = false;

                tmpBoardItem.Ship = Convert.ToInt16(rdoShip.SelectedValue);

                //switch (rdoImgMgr1.SelectedValue)
                //{
                //    case "Keep":
                //        tmpBoardItem.ImgPath1 = "KEEP";
                //        break;
                //    case "Delete":
                //       delImgArray[0] = Path.GetFileName(tmpBoardItem.ImgPath1);
                //        delImgs = true;
                //        tmpBoardItem.ImgPath1 = "";
                //        break;
                //    case "Change":
                //        blnProcImgs = true;
                //        break;
                //    case "Add":
                //        blnProcImgs = true;
                //        break;
                //    default:
                //        tmpBoardItem.ImgPath1 = "KEEP";
                //        break;
                //}

                //switch (rdoImgMgr2.SelectedValue)
                //{
                //    case "Keep":
                //        tmpBoardItem.ImgPath2 = "KEEP";
                //        break;
                //    case "Delete":
                //        delImgArray[1] = Path.GetFileName(tmpBoardItem.ImgPath2);
                //        delImgs = true;
                //        tmpBoardItem.ImgPath2 = "";
                //        break;
                //    case "Change":
                //        blnProcImgs = true;
                //        break;
                //    case "Add":
                //        blnProcImgs = true;
                //        break;
                //    default:
                //        tmpBoardItem.ImgPath2 = "KEEP";
                //        break;
                //}

                //switch (rdoImgMgr3.SelectedValue)
                //{
                //    case "Keep":
                //        tmpBoardItem.ImgPath3 = "KEEP";
                //        break;
                //    case "Delete":
                //        delImgArray[2] = Path.GetFileName(tmpBoardItem.ImgPath3);
                //        delImgs = true;
                //        tmpBoardItem.ImgPath3 = "";
                //        break;
                //    case "Change":
                //        blnProcImgs = true;
                //        break;
                //    case "Add":
                //        blnProcImgs = true;
                //        break;
                //    default:
                //        tmpBoardItem.ImgPath3 = "KEEP";
                //        break;
                //}

                //switch (rdoImgMgr4.SelectedValue)
                //{
                //    case "Keep":
                //        tmpBoardItem.ImgPath4 = "KEEP";
                //        break;
                //    case "Delete":
                //        delImgArray[3] = Path.GetFileName(tmpBoardItem.ImgPath4);
                //        delImgs = true;
                //        tmpBoardItem.ImgPath4 = "";
                //        break;
                //    case "Change":
                //        blnProcImgs = true;
                //        break;
                //    case "Add":
                //        blnProcImgs = true;
                //        break;
                //    default:
                //        tmpBoardItem.ImgPath4 = "KEEP";
                //        break;
                //}

                //process deletes for pics
                string sDeletedImageUrls = DeletedImageUrls.Value;

                if (!string.IsNullOrWhiteSpace(sDeletedImageUrls))
                {
                    try
                    {
                        DeletedImageUrls.Value = string.Empty;

                        string[] delImgArray = sDeletedImageUrls.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (delImgArray != null && delImgArray.Length > 0)
                        {
                            for (int i = 0; i < delImgArray.Length; i++)
                            {
                                string Filename = delImgArray[i].Substring(delImgArray[i].LastIndexOf('/') + 1);
                                if (Filename == tmpBoardItem.ImgPath1)
                                {
                                    tmpBoardItem.ImgPath1 = string.Empty;
                                }
                                else if (Filename == tmpBoardItem.ImgPath2)
                                {
                                    tmpBoardItem.ImgPath2 = string.Empty;
                                }
                                else if (Filename == tmpBoardItem.ImgPath3)
                                {
                                    tmpBoardItem.ImgPath3 = string.Empty;
                                }
                                else if (Filename == tmpBoardItem.ImgPath4)
                                {
                                    tmpBoardItem.ImgPath4 = string.Empty;
                                }
                                try
                                {
                                    DeleteServerFile(Server.MapPath(".\\" + @"\users\" + Session["userDir"].ToString() + @"\" + tmpBoardItem.Category.ToString() + @"\" + Filename));
                                }
                                catch { ErrorLog.ErrorRoutine(false, "Error in delete"); }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                delImgs = false;

                //upload imgs
                //List<HttpPostedFile> lstUploadedFiles = null;

                //if (Session["UploadedFiles1"] != null)
                //{
                //    lstUploadedFiles = (List<HttpPostedFile>)Session["UploadedFiles1"];
                //    Session["UploadedFiles1"] = null;
                //    if (lstUploadedFiles != null)
                //    {
                //        blnProcImgs = true;
                //    }
                //}
                if (lstEditUploadedFiles != null)
                {
                    //lstUploadedFiles = (List<HttpPostedFile>)Session["UploadedFiles1"];
                    //Session["UploadedFiles1"] = null;
                    //if (lstUploadedFiles != null)
                    {
                        blnProcImgs = true;
                    }
                }
                if (blnProcImgs)
                {
                    //strImgPathArray = UpLoadAllImages(strImgPathArray);
                    tmpBoardItem = UpLoadAllImages(tmpBoardItem, strImgPathArray, lstEditUploadedFiles);
                    lstEditUploadedFiles = new List<HttpPostedFile>();
                }
            }

            //save to DB
            if (hdnEntryType.Value != "4")
            {
                //call object method to update handler
                if (tmpBoardItem.UpdateItem())
                {
                    if (hdnActCode.Value.Length > 0)
                    {
                        //TODO: update to sold
                        pnlAll.Visible = false;
                        lnkMenu.Visible = false;
                        lblPageTitle.Visible = false;
                        lbl2.Text = "Your posting has been updated.<br><br><a href='index.aspx'>Return to Boardhunt</a>";
                    }
                    else
                    {
                        Response.Redirect("post_manager.aspx", true);
                    }
                    Response.Redirect("post_manager.aspx", true);
                }
                else
                {
                    lblStatus.Text = "Edit_item update error!";
                }
            }
            else
            {
                if (!tmpBoardItem.UpdateModel())
                {
                    lblStatus.Text = "Update model failed.";
                }
                else
                    Response.Redirect("post_manager.aspx?q=4", true);
            }

        }
        /**
         */
        private void imgCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (hdnEntryType.Value == "4")
                Response.Redirect("post_manager.aspx?q=4", true);
            Response.Redirect("post_manager.aspx", true);
        }

        //===============================
        //Error Checking & Helper Functions
        //===============================


        protected void btnShowPnl_Click(object sender, System.EventArgs e)
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

        /**
        */
        protected void CheckBrand(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (txtBrand.Text == "")
            {
                txtBrand.Text = "Unknown";
            }
        }

        /**
         */
        protected void CheckHeight(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (txtHtFt.Visible == true)
            {
                if (!IsNumeric(txtHtFt.Text))
                {
                    CustomValidator3.ErrorMessage = "!";
                    args.IsValid = false;
                }

                if (txtHtFt.Text.Contains("."))
                {
                    CustomValidator3.ErrorMessage = "use fractions";
                    args.IsValid = false;
                }

            }

            if (txtHtIn.Visible == true)
            {
                if (!IsNumeric(txtHtIn.Text))
                {
                    CustomValidator3.ErrorMessage = "!";
                    args.IsValid = false;
                }


            }

        }
        /**
         */
        protected void CheckWidth(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (txtWidth.Text.Length > 0)
            {

                if (txtWidth.Text.Contains("."))
                {
                    CustomValidator4.ErrorMessage = "use fractions";
                    args.IsValid = false;
                }

                //Check for numeric entries
                if ((!IsNumeric(txtWidth.Text) && txtWidth.Text != string.Empty) || ((!IsNumeric(txtWidthDNum.Text) && txtWidthDNum.Text != string.Empty) && (!IsNumeric(txtWidthNum.Text) && txtWidthNum.Text != string.Empty)))
                {
                    CustomValidator4.ErrorMessage = "!";
                    args.IsValid = false;
                    return;
                }

                //Check for div by 0 and denom > num
                if (txtWidthDNum.Text.Length > 0 && txtWidthNum.Text.Length > 0)
                {
                    // allow a zero for denom only if others are zero
                    if (Convert.ToInt32(txtWidthDNum.Text) == (int)0)
                    {
                        if (txtWidthNum.Text != "0" && txtWidth.Text != "0")
                        {
                            CustomValidator4.ErrorMessage = "!";
                            args.IsValid = false;
                            return;
                        }
                    }

                    //check for improper fraction
                    if (Convert.ToInt32(txtWidthNum.Text) > Convert.ToInt32(txtWidthDNum.Text))
                    {
                        CustomValidator4.ErrorMessage = "!";
                        args.IsValid = false;
                        return;
                    }
                }
                else
                {
                    txtWidthDNum.Text = "0";
                    txtWidthNum.Text = "0";
                }
            }


           //entry was blank; set to zero unless vals for num and denum
            else
            {
                if ((txtWidthDNum.Text.Length > 0) || (txtWidthNum.Text.Length > 0))
                {
                    CustomValidator4.ErrorMessage = "!";
                    args.IsValid = false;
                    return;
                }
                else
                {
                    txtWidth.Text = "0";
                    txtWidthDNum.Text = "0";
                    txtWidthNum.Text = "0";
                }
            }

            //check for evil script insertion
            if (txtWidth.Text.IndexOf("<script>") > 0 || txtWidthNum.Text.IndexOf("<script>") > 0 || txtWidthDNum.Text.IndexOf("<script>") > 0)
            {
                args.IsValid = false;
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
            if (txtThick.Text.Length > 0)
            {

                if (txtThick.Text.Contains("."))
                {
                    CustomValidator9.ErrorMessage = "use fractions";
                    args.IsValid = false;
                }

                //Check for any non-numeric entries
                if ((!IsNumeric(txtThick.Text) && txtThick.Text.Length > 0) || (!IsNumeric(txtThickDNum.Text) && txtThickDNum.Text.Length > 0) || (!IsNumeric(txtThickNum.Text) && txtThickNum.Text.Length > 0))
                {
                    CustomValidator9.ErrorMessage = "!";
                    args.IsValid = false;
                    return;
                }

                if (txtThickNum.Text.Length > 0 && txtThickDNum.Text.Length > 0)
                {
                    if (Convert.ToInt32(txtThickDNum.Text) == (int)0)   //denom = 0
                    {
                        if (txtThickNum.Text != "0" && txtThick.Text != "0")    //throw error if anyone else is non-zero
                        {
                            CustomValidator9.ErrorMessage = "!";
                            args.IsValid = false;
                        }
                    }
                    //check for num >= denom when denom is non-zero
                    if ((Convert.ToInt32(txtThickNum.Text) >= Convert.ToInt32(txtThickDNum.Text)) && (txtThickDNum.Text != "0"))
                    {
                        CustomValidator9.ErrorMessage = "!";
                        args.IsValid = false;
                    }
                }
                else
                {
                    txtThickNum.Text = "0";
                    txtThickDNum.Text = "0";
                }
            }

            else //allow all blanks and set to zero; if either num or dnum has val then throw an error
            {
                if ((txtThickNum.Text.Length > (int)0) || (txtThickDNum.Text.Length > (int)0))  //num or denom has val - throw error
                {

                    CustomValidator9.ErrorMessage = "!";
                    args.IsValid = false;

                }
                else //all blanks - set to zero
                {
                    txtThick.Text = "0";
                    txtThickNum.Text = "0";
                    txtThickDNum.Text = "0";
                }
            }

            //check for <script> insertion
            if (txtThick.Text.IndexOf("<script>") > 0 || txtThickDNum.Text.IndexOf("<script>") > 0 || txtThickNum.Text.IndexOf("<script>") > 0)
            {
                args.IsValid = false;
                CustomValidator1.Text = "!";
            }

        }

        /*
         */
        public void CheckPrice(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

            double tempVal;

            args.IsValid = true;

            //is it blank?
            if (txtPrice.Text.Length == 0)
            {
                args.IsValid = false;
                CustomValidator5.ErrorMessage = "!";
                return;
            }
            else
            {
                //strip out dollar sign if present
                if (txtPrice.Text.IndexOf("$") != -1)
                {
                    txtPrice.Text = Global.StrReplace(txtPrice.Text, @"\$");

                }

                if (hdnEntryType.Value != "4")
                {

                    //is it a number?
                    if (!IsNumeric(txtPrice.Text))
                    {
                        args.IsValid = false;
                        CustomValidator5.ErrorMessage = "!";
                        return;
                    }

                    //try and convert it 
                    try
                    {
                        tempVal = Convert.ToDouble(txtPrice.Text);
                    }

                    catch
                    {
                        CustomValidator5.ErrorMessage = "!";
                        args.IsValid = false;
                        return;
                    }
                }
            }

        }
        /*
        */
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
                    ErrorLog.ErrorRoutine(false, "Error deletingFile: ");
                }
            }

        }

        /*
        * Upload any images
        */
        //private string[] UpLoadAllImages(BoardItem bItem, string[] strImgPathArray)
        private classes.BoardItem UpLoadAllImages(classes.BoardItem bItem, string[] strImgPathArray, List<HttpPostedFile> lstUploadedFiles)
        {

            string tmpFile;
            string thmbNailPath;
            string userDir = "";
            string strCat;

            strCat = Enum.GetName(typeof(Global.BOARDCAT_DIRS), bItem.Category);

            //set userdir
            userDir = Session["userDir"].ToString();

            //if panel is open check for loaded img files
            if (pnlAddImages.Visible)
            {

                //Collect files names, iterate through each and update accordingly
                // HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
                int count = lstUploadedFiles.Count;

                bool bProcessFiles = true;

                if (string.IsNullOrWhiteSpace(bItem.ImgPath1))
                {
                    bProcessFiles = true;
                }
                if (string.IsNullOrWhiteSpace(bItem.ImgPath2))
                {
                    bProcessFiles = true;
                }
                if (string.IsNullOrWhiteSpace(bItem.ImgPath3))
                {
                    bProcessFiles = true;
                }

                if (!bProcessFiles)
                {
                    return bItem;
                }

                //loop thru for each posted file
                for (int i = 0; i < count; i++)
                {
                    //get handle to file
                    HttpPostedFile file = lstUploadedFiles[i];

                    if (file.ContentLength > (int)0)
                    {

                        //get file name & ext
                        string fileName = Path.GetFileName(file.FileName);
                        string fileExt = Path.GetExtension(file.FileName).ToLower();

                        //Create dir if non-existent
                        if (!(Directory.Exists(Server.MapPath(".\\" + @"\users\" + userDir + strCat + @"\"))))  //Session["userDir"].ToString()
                        {
                            Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + userDir + strCat + @"\"));
                        }

                        //get physical path to upload dir
                        string path = Server.MapPath(".\\" + @"\users\" + userDir + strCat + @"\");

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

                                //if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add" || rdoImgMgr1.SelectedValue == "")
                                //{

                                //    bItem.ImgPath1 = strImgPathArray[i];

                                //    rdoImgMgr1.ClearSelection();

                                //}
                                //else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add" || rdoImgMgr1.SelectedValue == "")
                                //{

                                //    bItem.ImgPath2 = strImgPathArray[i];

                                //    rdoImgMgr2.ClearSelection();

                                //}
                                //else if (rdoImgMgr3.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add" || rdoImgMgr1.SelectedValue == "")
                                //{


                                //    bItem.ImgPath3 = strImgPathArray[i];

                                //    rdoImgMgr3.ClearSelection();
                                //}
                                //else
                                //{
                                //    if (rdoImgMgr4.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add" || rdoImgMgr1.SelectedValue == "")
                                //    {

                                //        bItem.ImgPath4 = strImgPathArray[i];

                                //        rdoImgMgr4.ClearSelection();
                                //    }
                                //}
                                if (string.IsNullOrWhiteSpace(bItem.ImgPath1))
                                {
                                    bItem.ImgPath1 = strImgPathArray[i];
                                }
                                else if (string.IsNullOrWhiteSpace(bItem.ImgPath2))
                                {
                                    bItem.ImgPath2 = strImgPathArray[i];
                                }
                                else if (string.IsNullOrWhiteSpace(bItem.ImgPath3))
                                {
                                    bItem.ImgPath3 = strImgPathArray[i];
                                }
                                //else if (string.IsNullOrWhiteSpace(bItem.ImgPath4))
                                //{
                                //    bItem.ImgPath4 = strImgPathArray[i];
                                //}

                            }
                            catch
                            {
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
        protected void rdoImgMgr3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoImgMgr1.SelectedValue == "Change") File3.Disabled = false;
        }
        protected void rdoImgMgr4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoImgMgr1.SelectedValue == "Change") File4.Disabled = false;
        }
        /*
         */
        protected void btnSold_Click(object sender, EventArgs e)
        {
            //TODO: update to sold
            pnlAll.Visible = false;
            lnkMenu.Visible = false;
            lblPageTitle.Visible = false;

            if (UpdateToSold())
            {
                lbl2.Text = "Your posting has been removed.<br><br><a href='index.aspx'>Return to Boardhunt</a>";
            }
            else
            {
                lbl2.Text = "Something went wrong while updating your board.  We're working to fix the problem.  Thanks.";
                classes.Email.SendErrorEmail("Edit_item:Update to sold failed!");
            }
        }
        /*
         */
        public bool UpdateToSold()
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //Build SQL statement
            strSQL = "UPDATE tblEntry SET iStatus = '3' WHERE id='" + hdnEntryId.Value + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                lbl2.Text = "Error in update";
                ErrorLog.ErrorRoutine(false, "Error:Edit_Item: " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        protected void btnBoost_Click(object sender, EventArgs e)
        {
            Session["ServiceId"] = "1";
            Session["TxnItemId"] = hdnEntryId.Value;
            Response.Redirect("/Pay/OrderForm.aspx", false);
        }



    }
}
