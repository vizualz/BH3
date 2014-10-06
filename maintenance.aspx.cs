//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			maintenance.aspx.cs
///     Created:        7/24/07
///		Project log:	
///						
///
///
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


namespace BoardHunt
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public partial class maintenance : System.Web.UI.Page
	{


		protected System.Web.UI.WebControls.ImageButton imgLogin;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// Put user code to initialize the page here
            //lnkSignIn.Text = Global.SetLnkSignIn( );
            //lnkSignUp.Text = Global.SetLnkSignUp( );


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

		}
		#endregion
     

	}
}
