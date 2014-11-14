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

namespace BoardHunt.Blog
{
	/// <summary>
	/// Summary description for post_finish.
	/// </summary>
	public class BlogFinish : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;		
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
        protected System.Web.UI.WebControls.HyperLink lnkPostItem;

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

            if (!Page.IsPostBack)
            {
                classes.Blog tmpBlog = (classes.Blog)Session["Blog"];

                // Put user code to initialize the page here
			    Global.AuthenticateUser();

			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

                string entryId = GetNewEntryId();

                // Put user code to initialize the page here 
                lblMessage.Text = "The Blog has been posted!";
                lnkPostItem.Text = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/Blog/BlogDetails.aspx?iD=" + entryId + "&uId=" + tmpBlog.User + "&iCat=" + tmpBlog.BlogCat;
                lnkPostItem.NavigateUrl = "BlogDetails.aspx?iD=" + entryId;

                Session["Blog"] = null;
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
			Response.Redirect("UserMenu.aspx");
		}
/*
*/ 
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
            strSQL = "SELECT MAX(iD) FROM tblBlog";
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
                lblMessage.Text = "Error getting new entry id for blog";
                strId = "unknown";
            }

            finally
            {
                myConnection.Close();
                SQLReader = null;
                
            }
            return strId;
        }

	}
};
