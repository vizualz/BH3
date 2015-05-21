using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace BoardHunt
{
	/// <summary>
	/// Summary description for post_finish.
	/// </summary>
	public partial class post_finish : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;		
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // Put user code to initialize the page here
            Global.AuthenticateUser();

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (!Page.IsPostBack)
            {
                classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];

                string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

                string entryId = GetNewEntryId();   //this should be moved closer to INSERT in p_preview
                hdnEntryVal.Value = entryId;

                BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
                oWS.InsertBoardForRatings(Convert.ToInt32(entryId.ToString()));
                
                string eLink;

                //reg posts
                if (tmpBoardItem.AdType != 4)
                {
                    pnlBoost.Visible = true;
                    eLink = serverURL + "/surfboard.aspx?iD=" + entryId; 
                    hypLnkPost.Visible = true;
                    hypLnkPostModel.Visible = false;
                }
                else //AdType: 4 = Shaperhouse Model
                {
                    pnlBoost.Visible = false;
                    eLink = serverURL + "/Shaper/ModelDetails.aspx?iD=" + entryId;
                    hypLnkPost.Visible = false;
                    hypLnkPostModel.Visible = true;
                }

                //FB
                lnkFBShare.Attributes.Add("href", "javascript:void(window.open('http://www.facebook.com/sharer.php?u=" + eLink + "&t=Boardhunt.com|Surfboards+For+Sale'))");

                lnkLivePost.NavigateUrl = eLink;

                txtEntryLink.Text = eLink;
                txtEntryLink.ReadOnly = true;

                switch (tmpBoardItem.AdType)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        lnkPostItem.Text = serverURL + "/ShowcaseDetails.aspx?iD=" + entryId + "&uId=" + tmpBoardItem.IUser + "&iCat=" + tmpBoardItem.Category;
                        lnkPostItem.NavigateUrl = "ShowcaseDetails.aspx?iD=" + entryId + "&uId=" + tmpBoardItem.IUser + "&iCat=" + tmpBoardItem.Category;
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
                
                //hide upgrade for non-surf items
                if (tmpBoardItem.Category != (int)1)
                {
                    //btnUpgrade.Visible = false;
                }

                string[] eLinkArr = new string[4];
                eLinkArr[0] = eLink;
                eLinkArr[1] = tmpBoardItem.ActivateCode;
                eLinkArr[2] = entryId;

                //TODO: refine for categories and ad types
                if (tmpBoardItem.BoardType > 0)//surf or accessory?
                {
                    if (tmpBoardItem.AdType == 4)
                        eLinkArr[3] = tmpBoardItem.Model; //SH
                    else
                        eLinkArr[3] = tmpBoardItem.HtFt + "'" + " " + tmpBoardItem.HtIn + "\"" + " " + tmpBoardItem.Brand;
                }
                else
                    eLinkArr[3] = tmpBoardItem.Brand + " " + tmpBoardItem.GearItem;

                if (tmpBoardItem.AdType != 4)
                    classes.Email.SendEmail("Thanks", Session["EmailId"].ToString(), classes.Email.MSG_THX_FOR_POST, eLinkArr);
                else
                    classes.Email.SendEmail("Thanks", Session["EmailId"].ToString(), classes.Email.MSG_THX_FOR_MODEL, eLinkArr);


                //check for pro and.. 
                //BoardHunt.wsBH.BHService 
                oWS = new BoardHunt.wsBH.BHService();
                string i = oWS.isPro(Convert.ToInt32(Session["userId"].ToString())).ToString();

                //set style accordingly
                if (i == "1")
                {
                    oWS.boost(Convert.ToInt32(Session["userId"].ToString()), Convert.ToInt32(entryId));
                    btnUpgradePro.Visible = false;
                    ImageButton1.Visible = false;
                    hypLnkPost.Visible = true;
                }
                else
                {
                    btnUpgradePro.Visible = true;
                    ImageButton1.Visible = false;

                    if (classes.User.NeedsUpgrade(Convert.ToInt32(Session["userId"].ToString())))
                    {
                        hypLnkPost.Text = "All free posts have been used.  Please UPGRADE your account to Pro in UserMenu";
                        hypLnkPost.NavigateUrl = "/UserMenu.aspx";
                    }
                }

                //All done - clean up Session variable
                Session["Item"] = null;

            }
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
			Response.Redirect("post.aspx", false);
		}

        protected void lnkUpgrade_Click1(object sender, EventArgs e)
        {
            //Set session for posting upgrade
            Session["ServiceId"] = "1";
            Session["TxnItemId"] = hdnEntryVal.Value;

            Response.Redirect("/Pay/OrderForm.aspx", false);
        }

        private string GetNewEntryId()
        {
            //declare variables	
            string strSQL;
            string myConnectString;
            object objId;
            string strId;

            strId = "";
            //Get connection string 
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Formulate SQL  
            strSQL = "SELECT MAX(iD) FROM tblEntry";
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
                    objId = SQLReader.GetValue(0);
                    strId = objId.ToString();
                    
                }
            }

            catch
            {
                lblMessage.Text = "Error:GetNewEntryId: " + strSQL;
                strId = "error!";
            }

            finally
            {
                myConnection.Close();
                SQLReader = null;
                
            }
            return strId;
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
		}
		#endregion

        protected void btnUpgradePro_Click(object sender, ImageClickEventArgs e)
        {

            //Set session for posting upgrade
            Session["ServiceId"] = "6";
            Response.Redirect("/Pay/OrderForm.aspx", true);
        }

        protected void btnUpgrade_Click(object sender, ImageClickEventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "post_finish:btnUpgrade_Click");
            
            //Set session for posting upgrade
            Session["ServiceId"] = "1";
            Session["TxnItemId"] = hdnEntryVal.Value;

            Response.Redirect("/Pay/OrderForm.aspx",true);
        }

        protected void lnkBoost_Click(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "post_finish:lnkBoost_Click");

            //Set session for posting upgrade
            Session["ServiceId"] = "1";
            Session["TxnItemId"] = hdnEntryVal.Value;

            Response.Redirect("/Pay/OrderForm.aspx", true);
        }
	}
};
