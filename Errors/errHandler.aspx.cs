//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			ErrHandler.apx.cs
///     Author:         @LA
//////////////////////////////////////////////////////////////////////////


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
using System.Data.SqlClient;
using System.IO;
using System.Web.Mail;


namespace BoardHunt.Errors
{
	/// <summary>
	/// Summary description for post_finish.
	/// </summary>
    public partial class ErrHandler : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Panel pnlHeader;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMessage2;

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

        private void Page_Load(object sender, System.EventArgs e)
		{
            pnlHeader.Visible = false;

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();


            string val;
            try
            {
                val = Request.QueryString["iD"].ToString();
            }
            catch
            {
                val = "2";
            }

            switch (val)
            {
                case "1":
                    lblMessage.Text = "We can't find that file.";
                    lblMessage2.Text = "Check the URL and be sure your Javascript is enabled.";
                    //lblMessage.Text = "That file was not found.  Be sure you didn't mis-type the URL and that you have Javascript enabled.";
                    break;
                case "2":
                    lblMessage.Text = "Dah!  An unexpected error has occured.";
                    lblMessage2.Text = "Hang tight while we fix the problem!  You can also close the browser and try again.";
                    break;
                default:
                    lblMessage.Text = "We can't find that file.";
                    lblMessage2.Text = "Be sure you didn't mis-type the URL and that you have Javascript enabled.";
                    break;
            }
              
		}
           
/*
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

	}
};
