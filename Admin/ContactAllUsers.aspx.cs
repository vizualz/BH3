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
using System.Net.Mail;
using System.Data.SqlClient;


namespace BoardHunt.Admin
{
    /// <summary>
    /// Summary description for contact.
    /// </summary>
    public partial class ContactAllUsers1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected System.Web.UI.WebControls.Label lblErrName;
        protected System.Web.UI.WebControls.Label lblErrEmail;
        protected System.Web.UI.WebControls.Label lblSubject;

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
        /*
  */
        protected void Page_Load(object sender, System.EventArgs e)
        {

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();


            Server.ScriptTimeout = 3000;

            //hide unneeded panels
            panelMailSent.Visible = false;
            pnlConfirm.Visible = false;

            //check for admin
            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                ErrorLog.ErrorRoutine(false, "Hack Attempt into CAU Page!");
                Response.Redirect("../UserMenu.aspx");
            }

            //nothing to do here yet
            if (!Page.IsPostBack)
            {
                FCKeditor1.Value = "To control your e-mail settings <a href='http://www.malzook.com/login.aspx'>log-in</a> to your account and edit your profile.";
            }
        }

        /**
        */
        public void CheckFields(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            ErrorLog.ErrorRoutine(false, "Checking Fields");

            args.IsValid = true;

            if (!(FCKeditor1.Value.Length > 0))
            {
                args.IsValid = false;
                lblErrMessage.Text = "!";
            }

            if (!(txtSubject.Text.Length > 0))
            {
                args.IsValid = false;
                lblErrMessage.Text = "!";
            }
        }
        /**
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
            Response.Redirect("../post.aspx");

        }
        /*
         */
        protected void btnPreview_Click(object sender, EventArgs e)
        {

            lblMsgCheck.Text = FCKeditor1.Value;
            lblSubCheck.Text = txtSubject.Text;

            pnlConfirm.Visible = true;
            panelMailSent.Visible = false;
            panelSendEmail.Visible = false;
        }
        /*
         */
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            //get connect string
            string myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //query item and user details for entry
            string strSQL = "SELECT tblUser.txtEmail FROM tblUser WHERE notify_blog_flg = 'Y'";

            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                //Iterate through the reader and fire off e-mails
                while (SQLReader.Read())
                {

                    ErrorLog.ErrorRoutine(false, "Delivering to: " + SQLReader["txtEmail"].ToString());
                    if (!(classes.Email.SendEmail(txtSubject.Text, SQLReader["txtEmail"].ToString(), "boardblog@boardhunt.com", FCKeditor1.Value, false)))
                    {
                        lblErrMessage.Text = "Error e-mailing the user list";
                        ErrorLog.ErrorRoutine(false, "Error e-mailing the user list iterating through loop");
                        break;
                    }

                }

                panelMailSent.Visible = true;
                pnlConfirm.Visible = false;

            }// end try

            catch (Exception ex)
            {
                lblErrMessage.Text = "Error:Exception sending e-mail";
                ErrorLog.ErrorRoutine(false, "Error->ContactAllUsers:btnOK_Click: " + ex.Message);
            }

            finally
            {
                myConnection.Close();
            }
        }

        protected void btnCancelPreview_Click(object sender, EventArgs e)
        {
            //TODO: opposite

            lblMsgCheck.Text = lblSubCheck.Text = string.Empty;

            pnlConfirm.Visible = false;
            panelMailSent.Visible = true;
            panelSendEmail.Visible = true;
        }

    }
}
