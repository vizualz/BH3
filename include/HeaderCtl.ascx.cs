using System;
using System.Web;
using System.Web.UI;

namespace BoardHunt.include
{

	public partial class HeaderCtl : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected void Page_Load(object sender, System.EventArgs e)
		{

			lnkSignIn.Text = Global.SetLnkSignIn();
			lnkSignUp.Text = Global.SetLnkSignUp();
		}

		public bool UpdateLinks()
		{
			return true;
		}

/*
 */ 
		private void lnkSignIn_Click(object sender, System.EventArgs e)
		{
			BusinessLogic.HelperFunctions.FaceBookLogout(Session);
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
			Response.Redirect("post.aspx", true);
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

	}
}

