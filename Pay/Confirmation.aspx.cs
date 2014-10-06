using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BoardHunt.Pay
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                // Put user code to initialize the page here
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();
            }
            
            lblDetails.Visible = false;
            hypRedir.Visible = false;

            string[] arString;
            arString = Request.QueryString.GetValues("iD");
            if (arString == null)
            {
                lblThanks.Text = "&nbsp;Sorry, something went wrong.  Our geek team has been notified to fix this problem immediately.&nbsp;";
                lblThanks.CssClass = "errorLabel";
                hypRedir.Visible = true;
                hypRedir.Text = "Back to Main Menu";
                return;
            }

            switch (arString[0])
            {
                case "1":
                    lblThanks.Text = "Thanks. Your board was Boosted!";
                    lblDetails.Text = "You can Boost more boards from the Board Manager.";
                    hypRedir.Text = "Go to Board Manager";
                    hypRedir.NavigateUrl = "../post_manager.aspx";
                    hypRedir.Visible = true;
                    lblDetails.Visible = true;
                    break;
                case "2":
                    lblThanks.Text = "Thanks!  You're now ready to bid on Board Bidder.";
                    break;
                case "3":
                    lblThanks.Text = "Thanks.  Your Shaperhouse is ready!";
                    lblDetails.Text = "Add some models and edit your profile from the ShaperHouse section on the main menu.";
                    hypRedir.NavigateUrl = "../UserMenu.aspx";
                    hypRedir.Text = "Go to User Menu";
                    hypRedir.Visible = true;
                    lblDetails.Visible = true;                    
                    break;
                case "4":
                    lblThanks.Text = "Thanks. Your coupon is now live to the public!";
                    lblDetails.Text = "Remember you can always edit or remove your coupon from the Coupon Manager.";
                    hypRedir.NavigateUrl = "../qp/Manager.aspx";
                    hypRedir.Text = "Go to Coupon Manager";
                    hypRedir.Visible = true;
                    hypRedir2.NavigateUrl = "../qp/Coupons.aspx";
                    hypRedir2.Text = "See my Coupon now";
                    hypRedir2.Visible = true;
                    lblDetails.Visible = true;
                    break;
                case "5":
                    lblThanks.Text = "Thanks! Your $75 off Surfboard Voucher was sent to your email.<br><br>";
                    lblDetails.Text = "The Shaper has also been notified if you selected one.  Read the entire email for how to contact the shaper and begin.";
                    lblDetails.Visible = true;
                    lblDetails.CssClass = "dkgrey16";
                    break;
                case "6":
                    lblThanks.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/confThanks", @"~/Xml/Services.xml") + "<br><br>";
                    lblDetails.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/confDetails", @"~/Xml/Services.xml");
                    lblDetails.Visible = true;
                    lblDetails.CssClass = "dkgrey16";
                    hypRedir.NavigateUrl = "../UserMenu.aspx";
                    hypRedir.Text = "Go to User Menu";
                    hypRedir.Visible = true;
                    Session["isPro"] = 1;
                    //BoostAllBoardsForUser();
                    break;
                case "7":
                    lblThanks.Text = classes.xml.xmlHelper.GetText(@"//service[@id='7']/confThanks", @"~/Xml/Services.xml") + "<br><br>";
                    lblDetails.Text = classes.xml.xmlHelper.GetText(@"//service[@id='7']/confDetails", @"~/Xml/Services.xml");
                    lblDetails.Visible = true;
                    lblDetails.CssClass = "dkgrey16";
                    hypRedir.NavigateUrl = "../UserMenu.aspx";
                    hypRedir.Text = "Go to User Menu";
                    hypRedir.Visible = true;
                    Session["isPro"] = 1;
                    //BoostAllBoardsForUser();
                    break;
                default:
                    break;
            }

            //clean up
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
        }
/*
 */ 
        protected void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Global.NavigatePage(lnkSignIn.Text);

        }
/*
 */
        protected void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Global.NavigatePage(lnkSignUp.Text);

        }
/*
 */
        protected void lnkPost_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Response.Redirect("post.aspx", true);

        }
    }
}
