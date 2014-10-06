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
using DALLayer;

namespace BoardHunt.Bidder
{
	/// <summary>
    /// Summary description for ItemDetails.
	/// </summary>
    public partial class BidDetails : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Panel pnlWeb;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton lnkAbuse;
        protected System.Web.UI.WebControls.LinkButton lnkLoginFirst;

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
            //this.lnkLoginFirst.Click += new System.EventHandler(this.lnkLoginFirst_Click);
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
			this.imgGoBack.Click += new System.Web.UI.ImageClickEventHandler(this.imgGoBack_Click);
			//this.imgAddFav.Click += new System.Web.UI.ImageClickEventHandler(this.imgAddFav_Click);
            
		}
        #endregion        

		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			//Hide all sub-panels then enable accordingly
			pnlAll.Visible = true;
			pnlWidth.Visible = false;
			pnlSurfOnly.Visible = false;
            pnlContactInfo.Visible = false;
            pnlRatings.Visible = false;

            btnPlaceBid.Enabled = false;

            hdnEId.Value = Request.QueryString["iD"].ToString();
            hdnUserId.Value = string.Empty;

            //TODO: fix this with back button
            imgGoBack.Attributes.Add("onClick", "javascript:history.go(-1); return false;");

            btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Try typing something into the box.');event.returnValue=false;return false;}else{return true;}");

            if (Session["LoggedIn"].ToString() == "Yes")
            {
                pnlLogin.Visible = false;
                hdnUserId.Value = Session["userId"].ToString();
            }

            AuthenticateViewer();
            
            if (!Page.IsPostBack)
			{
				//Check for cut and paste URL bug: check for NULL;
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferURL"] = Request.UrlReferrer.ToString();
                }
                BindData();
                BindUpgrades();
                Session["GoToURL"] = "";
			}

		}
/*
 * Load detailed data for entry item
 */
        private void BindData()
		{

			string strSQL;
            string itemType = string.Empty;

            string strCat;
            int picCount = 0;
            string owner;

            owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "SELECT DISTINCT " + owner + ".getMinBidValue(" + hdnEId.Value + ") as minBidVal, e.iBidder, e.iLocation, e.iHtFt, e.iHtIn, e.iTailType, e.startPrice, e.dStartDate, e.dEndDate, ";
            strSQL += "e.iWidthNum, e.iWidthDenom, e.iWidth, e.iThick, e.iThickNum, e.iThickDenom, e.txtDetails, e.iFinType, e.iBoardType, e.iCategory ";
            strSQL += "FROM tblBidEntry e ";
            strSQL += "LEFT JOIN tblBids b ON e.iD = b.iBidEntryId ";
            strSQL += "AND e.iD='" + hdnEId.Value + "'";            

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    pnlSurfOnly.Visible = true;
                    pnlWidth.Visible = true;
                    
                    //assign the data to the controls
                    lblDateData.Text = String.Format("{0:MM/dd}", dbManager.DataReader["dStartDate"]);
                    hdnEndTime.Value = String.Format("{0:M/d/yyyy HH:mm:ss}", dbManager.DataReader["dEndDate"]);

                    //Check for expired bid
                    DateTime eTime = DateTime.Parse(dbManager.DataReader["dEndDate"].ToString());
                    lblEndDate.Text = String.Format("{0:MM/dd}", dbManager.DataReader["dEndDate"]);

                    ErrorLog.ErrorRoutine(false, "DateCompare: " + DateTime.Compare(DateTime.Now, eTime));

                    //HypCat.Text = Global.up1(Global.DecodeCategory(dbManager.DataReader["iLocation"]));
                    HypHome.NavigateUrl = "BidResults.aspx?iCat=" + dbManager.DataReader["iCategory"].ToString();
                    
                    if (DateTime.Compare(DateTime.Now, eTime) <= 0)
                    {
                        btnPlaceBid.Enabled = false;
                    }

                    lblHeightFtData.Text = dbManager.DataReader["iHtFt"].ToString() + "\'"; 
                    lblHeightInData.Text = dbManager.DataReader["iHtIn"].ToString() + "\"";
                    lblStartingBid.Text = "$" + dbManager.DataReader["startPrice"].ToString();

                    lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(dbManager.DataReader["iBoardType"]), (int)1));

                    if (dbManager.DataReader["minBidVal"] != DBNull.Value)
                    {
                        lblLowestBid.Text = "$" + dbManager.DataReader["minBidVal"].ToString();
                    }
                    else
                    {
                        lblLowestBid.Text = "No bids yet";
                    }
                    

                    lblFinsData.Text = DecodeFins(dbManager.DataReader["iFinType"]);
                    lblTailData.Text = Global.ProperSpace(DecodeTail(dbManager.DataReader["iTailType"]));
                    
                    //HypLoc.Text = Global.ProperSpace(DecodeRegion(dbManager.DataReader["iLocation"]));

                    lblWidthData.Text = dbManager.DataReader["iWidth"].ToString();
                    if (dbManager.DataReader["iWidthNum"] != DBNull.Value || dbManager.DataReader["iWidthNum"].ToString() != "")
                    {
                        lblWidthData.Text += " + " + dbManager.DataReader["iWidthNum"].ToString() + "/" + dbManager.DataReader["iWidthDenom"].ToString();
                    }
                    lblWidthData.Text += "\"";

                    lblThickData.Text = dbManager.DataReader["iThick"].ToString();
                    if (dbManager.DataReader["iThickNum"] != DBNull.Value || dbManager.DataReader["iThickNum"].ToString() != "")
                    {
                        lblThickData.Text += " + " + dbManager.DataReader["iThickNum"].ToString() + "/" + dbManager.DataReader["iThickDenom"].ToString();
                    }
                    lblThickData.Text += "\"";
                    lblDetailsData.Text = dbManager.DataReader["txtDetails"].ToString();

                    Pic1.ImageUrl = "../images/shaper.gif";

                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BidDetails:BindData error: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            //try
            //{

            //    while (SQLReader.Read() == true)
            //    {
 
            //        //Date
            //        lblDateData.Text = String.Format("{0:MM/dd}", SQLReader["dCreateDate"]);

            //        //Location
            //        HypLoc.Text = Global.ProperSpace(DecodeRegion(SQLReader["Location"]));
            //        if (SQLReader["txtTown"].ToString().Length > 0)
            //        {
            //            HypLoc.Text += " (" + SQLReader["txtTown"].ToString() + ")";
            //        }

            //        //Brand
            //        lblBrand.Text = "Brand:&nbsp";
            //        lblBrandData.Text = SQLReader["txtBrand"].ToString();

            //        //Price
            //        lblPriceData.Text = Global.FormatPrice(SQLReader["fltPrice"]);

            //        //Details
            //        lblDetailsData.Text = SQLReader["txtDetails"].ToString();

            //        //Contact
            //        Session["Email"] = SQLReader["txtEmail"].ToString();
            //        lnkEmailData.Text = ParseEmail(SQLReader["txtEmail"].ToString());
            //        lnkEmailData.CommandArgument = SQLReader["txtEmail"].ToString();

            //        string mailBodyTxt = System.Web.HttpUtility.UrlEncode(this.Page.Request.Url.ToString());

            //        lnkEmailData.Attributes.Add("href", "mailto:" + SQLReader["txtEmail"].ToString() + "?subject=About your Boardhunt posting&body=I'm interested about your posting: " + mailBodyTxt);
            //        hdnNotifyEmail.Value = SQLReader["notify_comment_flg"].ToString();

            //        lblPhoneData.Text = SQLReader["txtPhoneNum"].ToString();
            //        lblPhoneData.Visible = ShowPhone(SQLReader["iShowPhoneNum"]);

            //        //Category
            //        strCat = SQLReader["iCategory"].ToString();
            //        hdnStrCat.Value = Global.DecodeCategory(Convert.ToInt32(strCat));
            //        HypCat.Text = Global.up1(hdnStrCat.Value);

            //        //Ad type - Selling:1 , Wanted:2
            //        itemType = SQLReader["adType"].ToString();
            //        lblPageViewCount.Text = incPageViewCount(SQLReader["iPageViewCount"].ToString());
                    
            //        string ratCnt = SQLReader["iRatingCount"].ToString();

            //        if (ratCnt == string.Empty)
            //        {
            //            ratCnt = "0";
            //        }

            //        hdnRatingCnt.Value = ratCnt;

            //        if (ratCnt == "1")
            //        {
            //            ratCnt += " Rating";
            //        }
            //        else
            //        {
            //            ratCnt += " Ratings";
            //        }
                    
            //        lblRatingCount.Text = ratCnt;
                    
                    
            //        //Set Rating if adtype is selling
            //        if (itemType == "1")
            //        {
            //            pnlCondition.Visible = true;
            //            lblCondition.Text = DecodeCondition(SQLReader["iCondition"]);
                        
            //            if (SQLReader["iRatingVal"].ToString() == null || SQLReader["iRatingVal"].ToString() == "")
            //            {
            //                //blnNullFlag = true;
            //                hdnRatingVal.Value = "0";
            //            }
            //            else
            //            {
            //                int iratingVal = Convert.ToInt32(SQLReader["iRatingVal"].ToString());
            //                int iratingCt = Convert.ToInt32(SQLReader["iRatingCount"].ToString());

            //                if (iratingCt > (int)0)
            //                {
            //                    hdnRatingVal.Value = Convert.ToInt16(Math.Round(Convert.ToDouble(iratingVal / iratingCt))).ToString();
            //                }
            //                else
            //                {
            //                    hdnRatingVal.Value = "0";
            //                }
            //            }
            //        }

            //        //Set category specific
            //        switch (strCat)
            //        {
            //            case "1": //surf

            //                lblBrand.Text = "Shaper:&nbsp";
            //                lblBrandData.Text = SQLReader["txtBrand"].ToString();
            //                lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)1));
            //                lblBoardType.Text = "Board type:&nbsp";
            //                lblHeight.Text = "Height:&nbsp";

            //                lblHeightFtData.Text = SQLReader["iHtFt"].ToString() + "\'";
            //                lblHeightInData.Text = SQLReader["iHtIn"].ToString() + "\"";
                            
            //                lblWidthData.Text = SQLReader["width"].ToString();

            //                if (itemType == "1")
            //                {
                                
            //                    if (SQLReader["widthNum"] != DBNull.Value || SQLReader["widthNum"].ToString() != "")
            //                    {
            //                        lblWidthData.Text = lblWidthData.Text + " + " + SQLReader["widthNum"].ToString() + "/" + SQLReader["widthDenum"].ToString();
            //                    }
            //                    lblWidthData.Text = lblWidthData.Text + "\"";

            //                    lblThickData.Text = SQLReader["Thick"].ToString();
            //                    if (SQLReader["ThickNum"] != DBNull.Value || SQLReader["ThickNum"].ToString() != "")
            //                    {
            //                        lblThickData.Text = lblThickData.Text + " + " + SQLReader["ThickNum"].ToString() + "/" + SQLReader["ThickDenum"].ToString();
            //                    }
            //                    lblThickData.Text = lblThickData.Text + "\"";
            //                    //

            //                    lblTailData.Text = Global.ProperSpace(DecodeTail(SQLReader["iTailType"]));
            //                    lblFinsData.Text = DecodeFins(SQLReader["iFins"]);

            //                    pnlWidth.Visible = true;
            //                    pnlSurfOnly.Visible = true;
            //                }
            //                else
            //                {
            //                    pnlSurfOnly.Visible = false;
            //                }

            //                break;

            //            case "2": //snow

            //                lblBoardTypeData.Text = Global.ProperSpace(DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)2));
            //                lblBoardType.Text = "Board type:&nbsp";

            //                lblHeight.Text = "Height:&nbsp";

            //                lblHeightFtData.Text = SQLReader["iHtFt"].ToString() + " cm";

            //                break;

            //            case "3": //other
            //                lblBoardType.Text = "Board type:&nbsp";
            //                if (SQLReader["iBoardType"].ToString() == "" || SQLReader["iBoardType"].ToString() == null)
            //                {
            //                    lblBoardTypeData.Text = SQLReader["txtOtherBoardType"].ToString();
            //                }
            //                else
            //                {
            //                    lblBoardTypeData.Text = DecodeBoard(Convert.ToInt32(SQLReader["iBoardType"]), (int)3);
            //                }

            //                pnlGenDims.Visible = true;
            //                lblGenDims.Text = SQLReader["txtGenDimensions"].ToString();
            //                break;
            //            case "4": //gear
            //                pnlGearItem.Visible = true;
            //                lblGearItem.Text = SQLReader["txtGearItem"].ToString();
            //                pnlAll.Visible = false;

            //                break;

            //        }

            //        //selling or wanted ad type? selling=1; wanted=2
            //        if (itemType == "2")
            //        {
            //            //just show wanted pic
            //            Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/wantedbig.gif";
                         
            //            //hide ratings
            //            pnlRatings.Visible = true;

            //            //hide comments
            //            pnlComments.Visible = true;

            //            lblBrand.Text = "";
            //            pnlWidth.Visible = false;

            //        }
            //        //for selling
            //        else
            //        {
            //            //process images
            //            //add up a pic count so we know wether to hide/show ratings panel
            //            string strUserDir = Global.ReplaceEx(SQLReader["userDir"].ToString(), @"\", @"/");

            //            Pic1.ImageUrl = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
            //            if ((Path.GetFileName(Pic1.ImageUrl)) == "s1x1.gif")
            //            {
            //                Pic1.Height = 1;
            //                Pic1.Width = 1;
            //            }
            //            else
            //            {
            //                picCount += 1;
            //                Pic1.Height = 400;
            //                Pic1.Width = 400;

            //                Pic1ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath1"].ToString(), strUserDir);
            //                Pic1ThmbNail.Width = 75;
            //                Pic1ThmbNail.Height = 75;
            //                Pic1ThmbNail.Visible = true;
            //                hdnPic1URL.Value = GetPicPath(SQLReader["txtImgPath1"], strUserDir);
            //            }

            //            Pic2.ImageUrl = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
            //            if ((Path.GetFileName(Pic2.ImageUrl)) == "s1x1.gif")
            //            {
            //                Pic2.Height = 1;
            //                Pic2.Width = 1;
            //            }
            //            else
            //            {
            //                picCount += 1;
            //                Pic2.Height = 400;
            //                Pic2.Width = 400;

            //                Pic2ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath2"].ToString(), strUserDir);
            //                Pic2ThmbNail.Width = 75;
            //                Pic2ThmbNail.Height = 75;
            //                Pic2ThmbNail.Visible = true;
            //                hdnPic2URL.Value = GetPicPath(SQLReader["txtImgPath2"], strUserDir);
            //            }

            //            Pic3.ImageUrl = GetPicPath(SQLReader["txtImgPath3"], strUserDir);
            //            if ((Path.GetFileName(Pic3.ImageUrl)) == "s1x1.gif")
            //            {
            //                Pic3.Height = 1;
            //                Pic3.Width = 1;
            //            }
            //            else
            //            {
            //                picCount += 1;
            //                Pic3.Height = 400;
            //                Pic3.Width = 400;

            //                Pic3ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath3"].ToString(), strUserDir);
            //                Pic3ThmbNail.Width = 75;
            //                Pic3ThmbNail.Height = 75;
            //                Pic3ThmbNail.Visible = true;
            //                hdnPic3URL.Value = GetPicPath(SQLReader["txtImgPath3"], strUserDir);
            //            }

            //            Pic4.ImageUrl = GetPicPath(SQLReader["txtImgPath4"], strUserDir);
            //            if ((Path.GetFileName(Pic4.ImageUrl)) == "s1x1.gif")
            //            {
            //                Pic4.Height = 1;
            //                Pic4.Width = 1;
            //            }
            //            else
            //            {
            //                picCount += 1;
            //                Pic4.Height = 400;
            //                Pic4.Width = 400;

            //                Pic4ThmbNail.ImageUrl = GetPicPath("thmbNail_" + SQLReader["txtImgPath4"].ToString(), strUserDir);
            //                Pic4ThmbNail.Width = 75;
            //                Pic4ThmbNail.Height = 75;
            //                Pic4ThmbNail.Visible = true;
            //                hdnPic4URL.Value = GetPicPath(SQLReader["txtImgPath4"], strUserDir);
            //            }

            //            //NO IMAGES were uploaded
            //            if (picCount < 1)
            //            {
            //                pnlRatings.Visible = false;
            //                Pic1.ImageUrl = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/noimage.gif";
            //                pnlComments.Visible = false;

            //                //old
            //                //Pic1.Width = 162;
            //                //Pic1.Height = 209;

            //                //new
            //                Pic1.Width = 400;
            //                Pic1.Height = 468;
            //                pnlDetails.Width = 800;
            //            }
            //            else
            //            {
            //                string imgURLVal;
            //                string voteVal = "voted_" + hdnEId.Value;

            //                imgURLVal = string.Empty;

            //                if (Session[voteVal] == null)
            //                {
            //                    imgURLVal = "images/target_green.gif";
            //                }
            //                else //disallow voting
            //                {
            //                    if (Session[voteVal].ToString() == "Y")
            //                    {
            //                        imgURLVal = "images/target_orange.gif";
            //                        star1.Enabled = star2.Enabled = star3.Enabled = star4.Enabled = star5.Enabled = false;
            //                    }
            //                }
                            
            //                //Set rating value
            //                switch (hdnRatingVal.Value)
            //                {
            //                    case "1":
            //                        star1.ImageUrl = imgURLVal;
            //                        break;
            //                    case "2":
            //                        star1.ImageUrl = imgURLVal;
            //                        star2.ImageUrl = imgURLVal;
            //                        break;
            //                    case "3":
            //                        star1.ImageUrl = imgURLVal;
            //                        star2.ImageUrl = imgURLVal;
            //                        star3.ImageUrl = imgURLVal;
            //                        break;
            //                    case "4":
            //                        star1.ImageUrl = imgURLVal;
            //                        star2.ImageUrl = imgURLVal;
            //                        star3.ImageUrl = imgURLVal;
            //                        star4.ImageUrl = imgURLVal;
            //                        break;
            //                    case "5":
            //                        star1.ImageUrl = imgURLVal;
            //                        star2.ImageUrl = imgURLVal;
            //                        star3.ImageUrl = imgURLVal;
            //                        star4.ImageUrl = imgURLVal;
            //                        star5.ImageUrl = imgURLVal;
            //                        break;
            //                    default:
            //                        break;
            //                }
                            
            //            }
            //        }

            //    }//end while

            //}// end try

            //catch (Exception ex)
            //{
            //    lblStatus.Text = "Error Loading Data...";
            //    ErrorLog.ErrorRoutine(false, "Error->ItemDetails:BindData: " + ex.Message); 
            //}

            //finally
            //{
            //    myConnection.Close();
            //}

            //BindComments();
			
		}		
/*
*/
        public void BindComments()
        {
            //load detailed data for entry item
            string strSQL;
            string myConnectString;

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //query item and user details for entry
            strSQL = "SELECT tblUser.txtEmail, tblComments.* FROM tblUser INNER JOIN tblComments ON tblUser.Id = tblComments.userId WHERE tblComments.entryId = '" + hdnEId.Value + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //Declare Dataset
            DataSet dsItems = new DataSet();

            //Set adapter and with connection handle
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                //Fill DataSet
                objAdapter.Fill(dsItems, "tblComments");

                //Get result count for paging
                int listCount = dsItems.Tables["tblComments"].Rows.Count;
                lblCommentCount.Text = listCount.ToString() + "&nbsp;Comment";
                if (listCount != 1)
                {
                    lblCommentCount.Text += "s";
                }
                
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = dsItems.Tables[0].DefaultView;

                //bind to DataList control
                dlCommentList.DataSource = objPds;
                //dlCommentList.DataSource = dsItems;
                dlCommentList.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in CommentList: " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }

            if (Session["LoggedIn"].ToString() == "No")
            {
                pnlLoginMsg.Visible = true;
                
            }
            else
            {
                pnlCommentBox.Visible = true;
            }
        
        }

/*
 */ 
		public string DecodeBoard(object BoardCode, int cat)
		{
            string val = "";

            switch (cat)
            {
                case (int)1:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_SURF), BoardCode);
                    break;
                case (int)2:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_SNOW), BoardCode);
                    break;
                case (int)3:
                    val = Enum.GetName(typeof(Global.BOARDTYPE_OTHER), BoardCode);
                    break;
            }
            return val;
		}
/*
 */

        public string DecodeCondition(object CondCode)
        {
            return Enum.GetName(typeof(Global.CONDITION_TYPE), CondCode);
        } 


		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect(ViewState["ReferURL"].ToString());
		}

		public string GetPicPath(object imgPicPath, string uD)
		{
			string imgPath;
            string strServerURL;

            strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

			//if the imgPicPath is null or empty then just display a blank white area
			if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
			{
                imgPath = strServerURL + "/images/s1x1.gif";
			}
			else
			{
                imgPath = strServerURL + "/users/" + uD + hdnStrCat.Value + "/" + Path.GetFileName(imgPicPath.ToString());
			}
			return imgPath;
		}
		
		//displays phone number based on user pref in db
		public bool ShowPhone(object iDisplay)
		{

			if (Convert.ToInt32(iDisplay.ToString()) == (int)1)
			{
				return true;
			}
			return false;
		}

        //Fired when user clicks the edit link.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            //Todo:we need board type so perhaps we can add it as a hidden value in the .aspx and access on the code sire
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString());// + "&iCat=" + Request.QueryString["iCat"].ToString());
        }

        //Fired when user clicks to vote the entry.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ProcRating(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Did this to handle NULL values in the db.  Apparently NULL arithmatic is frowned upon
            //if (blnNullFlag)
            if (Convert.ToInt32(hdnRatingVal.Value) < (int)1)
            {
                strSQL = "UPDATE tblEntry SET iRatingCount = 1,iRatingVal = " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblEntry SET iRatingCount = iRatingCount + 1,iRatingVal = iRatingVal + " + e.CommandArgument + "WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                string voteVal = "voted_" + hdnEId.Value;

                Session[voteVal] = "Y";

                //rebind data to control
                BindData();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in ProcRating:" + ex.Message);
                lblStatus.Text = "Ratings Error.";
            }
            finally
            {
                //close
                myConnection.Close();            
            }
        }
/*
 */ 
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);
        }		
/*
 */ 
        public string DecodeFins(object FinCode)
		{
			return Enum.GetName(typeof(Global.FINS), FinCode);
		}

		public string DecodeTail(object TailCode)
		{
			return Enum.GetName(typeof(Global.TAIL), TailCode);
		}
		
		private void lnkSignIn_Click(object sender, System.EventArgs e)
		{
			Global.NavigatePage(lnkSignIn.Text);
		}

		private void lnkSignUp_Click(object sender, System.EventArgs e)
		{
			Global.NavigatePage(lnkSignUp.Text);
		}

		private void lnkPost_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("post.aspx");
		}

		private void imgAddFav_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            if (Session["LoggedIn"].ToString() == "No")
            {
                Global.CreateMessageAlert(this.Page, "You must be logged in to do that.", "alertKey");
                return;
            }
            
            //add this entry into the favorites table
			string strSQL;
			string myConnectString;

			//form connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

			
			//Build SQL
			strSQL = "INSERT INTO tblFavs (userId, entryId)";
            strSQL += "VALUES ('" + Session["userId"].ToString() + "','" + Request.QueryString["iD"].ToString() + "')";

			SqlConnection myConnection = new SqlConnection(myConnectString);
					
			//TODO: need to check for duplicate entries
			try
			{
				myConnection.Open();

				SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				objCommand.ExecuteNonQuery();

				myConnection.Close();

                BindComments();

				Global.CreateMessageAlert(this.Page,"Entry has been added to your favorites.", "alertKey");

			}
	
			catch 
			{
				lblStatus.Text = "SQL Error: Connection Bad.<br>";
				lblStatus.Text = "SQL: " + strSQL;
			}		


		}

        protected void btnPostComment_Click(object sender, EventArgs e)
        {

            //add this entry into the favorites table
            string strSQL;
            string myConnectString;
            
            //check login status
            if (Session["LoggedIn"].ToString() == "No")
            {
                //TODO: display please log in?
                return;
            }

            //check for an empty comment
            if (txtComment.Text.Length <= 0)
            {
                txtComment.BorderColor = Color.Red;
                return;
            }

            //form connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "INSERT INTO tblComments (entryId, userId, txtComment, dPosted)";
            strSQL += "VALUES ('" + Convert.ToInt32(hdnEId.Value) + "','" + Convert.ToInt32(Session["userId"].ToString()) + "','" + Global.CheckString(txtComment.Text) + "','" + DateTime.Now + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            //TODO: need to check for duplicate entries - ?
            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //Send E-mail
                if (hdnNotifyEmail.Value == "Y")
                {
                    //classes.Email.SendEmail("A new comment was posted on your board", lnkEmailData.CommandArgument, classes.Email.MSG_POSTED_COMMENT, Request.Url.ToString());
                }

                Response.Redirect(Request.Url.ToString());
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BidDetails:Error posting comment:" + ex.Message);
                lblStatus.Text = "Error posting comment.<br>";
            }

            finally
            {
                myConnection.Close();            
            }

        }
/*
 */ 
        protected void lnkLoginFirst_Click(object sender, EventArgs e)
        {
            Session["GoToURL"] = Request.Url.ToString();
            Response.Redirect("login.aspx");
        }
/*
 */
        public string ParseEmail(object em)
        {
            string[] arrStr;
            char[] splitter = { '@' };

            arrStr = em.ToString().Split(splitter);
            return arrStr[0]; 
        }

/*
 * Increment the PageViewCount for the entry.  The value returned will be the display value
 */
        public string incPageViewCount(string cnt)
        {

            string tmpURL = Request.Url.ToString();

            if (Session[tmpURL] != null)
            {
                return cnt;
            }

            string connStr, strSQL;
            int retval;

            retval = 0;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //cnt and iPageViewCount should be equal - do we need to check?
            if (Convert.ToInt32(cnt) < (int)1)
            {
                strSQL = "UPDATE tblEntry SET iPageViewCount = 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }
            else
            {
                strSQL = "UPDATE tblEntry SET iPageViewCount = iPageViewCount + 1 WHERE iD = '" + Request.QueryString["iD"] + "'";
            }

            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                Session.Add(Request.Url.ToString(), Request.Url.ToString());
                retval = Convert.ToInt32(cnt) + 1;
            }
            
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in PageViewCount processing: " + ex.Message );
                lblStatus.Text = "Error!";
            }
            finally
            {
                //close
                myConnection.Close();
            }
            return (retval.ToString());
        }

/*
 */ 
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //Connect to DB	
            String strSQL;
            String myConnectString;

            //Formulate connect string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //3. Formulate SQL
            strSQL = "SELECT * FROM tblUser WHERE txtEmail='" + txtUsername.Text + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                myConnection.Open();

                SqlDataReader objReader = null;
                objReader = objCommand.ExecuteReader();

                if (objReader.Read() == true)
                {
                    string txtPass = objReader["txtPassword"].ToString();
                    bool bLoginSuccess = false;

                    if (objReader["sashimi"].ToString() == "1")
                    {
                        //get hasher pointer
                        BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();
                        //get salt from db
                        string saltVal = objReader["salt"].ToString();

                        //compute hash from user input
                        byte[] tmpByte;
                        tmpByte = pHash.getHash(saltVal, txtPassword.Text);
                        string pwdToMatch = Convert.ToBase64String(tmpByte);

                        //check for match
                        if (pwdToMatch == txtPass)
                        {
                            bLoginSuccess = true;
                        }

                    }

                    //old algorithm
                    else
                    {
                        if (objReader["txtPassword"].ToString() == txtPassword.Text)
                        {
                            bLoginSuccess = true;
                        }
                    }

                    //check password match
                    if (bLoginSuccess)
                    {

                        // Successful login, save iD for user events while logged in
                        Session["LoggedIn"] = "Yes";
                        Session["userId"] = objReader["iD"].ToString();
                        Session["EmailId"] = objReader["txtEmail"].ToString();
                        Session["acctType"] = objReader["iAcctType"].ToString();
                        pnlLoginMsg.Visible = false;
                        pnlLogin.Visible = false;

                        BindComments();

                        dlCommentList.Visible = true;
                        pnlCommentBox.Visible = true;

                        //Get text for login links
                        lnkSignIn.Text = Global.SetLnkSignIn();
                        lnkSignUp.Text = Global.SetLnkSignUp();

                    }
                    //login failed 
                    else
                    {
                        Response.Redirect("login.aspx");
                    }

                }

                else
                {
                    //lblStatus.Text = "Incorrect Username";
                }

                myConnection.Close();


            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Failed Log-in from pnlLogin: " + ex.Message);
            }



        }
/*
 */ 
        protected void btnMore_Click(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Going to:" + "search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value);
            Response.Redirect("search_results.aspx?loc=all&iCat=" + hdniCat.Value + "&uId=" + hdnUserId.Value, false);
        }
/*
 */
        protected void BindUpgrades()
        {
        
            string strSQL;
            //string strUser;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            //SELECT * from my_table ORDER BY RAND() LIMIT 25

            //build SQL
            strSQL = @"SELECT e.txtImgPath1, e.iD, e.iHtFt, e.iHtIn, e.iUser, e.txtBrand, u.userDir 
            FROM tblServices s
            INNER JOIN tblEntry e on s.iEntryId = e.iD
            INNER JOIN tblUser u on u.id = e.iUser"; 

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                dlUpgrades.DataSource = dbManager.DataReader;
                dlUpgrades.DataBind();

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error: RegisterDBEntry: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        public void AuthenticateViewer()
        {
            if (hdnUserId.Value.Length > 0)
            {
                if (CheckBidPrivs())
                {
                    btnPlaceBid.Enabled = true;
                }
            }
        }
/*
 * 
 */
        public bool CheckBidPrivs()
        {
            string strSQL;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            //build SQL
            strSQL = @"SELECT s.iD 
            FROM tblServices s
            WHERE s.iServiceVal = '2'
            AND s.iUserId = '" + hdnUserId.Value + "'";
            strSQL +=  "AND s.iStatus = '1'";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error: CheckBidPrivs: " + ex.Message);
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
        public string SetPicPath(object uDir, object imgPath)
        {
            //set the default
            string retVal = "images/s1x1.gif";
            if (uDir != null && imgPath != null)
            {
                retVal = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/users/" +  Global.ReplaceEx(uDir.ToString(),@"\",@"/") + "surfboards/" + "thmbNail_" + imgPath;
                //ErrorLog.ErrorRoutine(false, "path: " + retVal);
            }

            return retVal;
        }
/*
 */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void ShowItem(object src, CommandEventArgs e)
        {
            //ErrorLog.ErrorRoutine(false, "path: " + "surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1"); // + Request.QueryString["iCat"].ToString());

        }

        protected void btnPlaceBid_Click(object sender, EventArgs e)
        {
            //TODO: Verify bid
            
            classes.Bids TheBid = new classes.Bids();
            TheBid.BidValue = Convert.ToInt16(txtBidValue.Text);
            TheBid.BidEntry = Convert.ToInt16(hdnEId.Value);
            TheBid.DCreateDate = DateTime.Now;
            TheBid.UserId = Convert.ToInt16(hdnUserId.Value);
            if (TheBid.InsertBid())
            {
                lblBidStatus.Text = "Bid Accepted";
                txtBidValue.Text = string.Empty;
                
            }
            else
            {
                lblBidStatus.Text = "Bid Refused.";
            }
            BindData();
        } 
	}
}
