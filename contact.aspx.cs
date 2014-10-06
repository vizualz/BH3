using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using System.Net.Mail;


namespace BoardHunt
{
	/// <summary>
	/// Summary description for contact.
	/// </summary>
	public partial class contact : System.Web.UI.Page
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
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

        }
        #endregion
 /*
  */ 
        protected void Page_Load(object sender, System.EventArgs e)
		{

			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );
	        panelMailSent.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();
                
            }
		}
/*
 */ 
        public void BindData()
        {
            string[] arString;
            arString = Request.QueryString.GetValues("iD");
            
            if (arString != null)
            {
                cboSubject.SelectedIndex = Convert.ToInt32(HttpUtility.UrlDecode(arString[0].ToString()));
            }
         
        }

/**
*/ 
        public void CheckFields(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!(name.Text.Length > 0))
            {
                args.IsValid = false;
                lblErrName.Text = "!";
            }

            if (!(email.Text.Length > 0))
            {
                args.IsValid = false;
                lblErrEmail.Text = "!";
            }

            if (!(message.Text.Length > 0))
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
            Response.Redirect("post.aspx");

        }

/*
*/
        private void btnSend_Click(object sender, System.EventArgs e)
        {
            if (!Page.IsValid) 
                return;

            try
            {
                //Send the message
                if (classes.Email.SendContactEmail(message.Text, cboSubject.SelectedItem.Text, email.Text, name.Text))
                {
                    //smtpClient.Send(mail);
                    panelSendEmail.Visible = false;
                    panelMailSent.Visible = true;
                }
            }
            catch (System.Web.HttpException ehttp)
            {
                ErrorLog.ErrorRoutine(false, "Error: " + ehttp.Message);
                lblErrMessage.Text = "Your e-mail address is invalid.  Please fix and resend.";
                lblErrMessage.CssClass = "errorLabel";
            }

            finally
            {

            }
        }

	}
}
