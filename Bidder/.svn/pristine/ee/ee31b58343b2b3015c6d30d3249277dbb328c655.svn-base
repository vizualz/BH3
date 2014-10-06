/*
 *      File: Blog.aspx
 *      
 *      This is the first page of a wizard that collects input from users wanting to create a blog.
 *      Collected here are the BlogType/BoardCategory and User.
 * 
 *      @author: AHM
 * 
 * 
*/
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
	/// Summary description for post.
	/// </summary>
    public class Blog : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboCategory;
		protected System.Web.UI.WebControls.DropDownList cboRegion;

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.RadioButtonList radioAdType;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.TextBox txtTown;

        protected System.Web.UI.WebControls.Button btnCancel;
        protected System.Web.UI.WebControls.Button btnNext;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
            
            // Put user code to initialize the page here
			Global.AuthenticateUser();

            //check for blog hacks who may type in URL
             if (Session["blogFlg"].ToString() != "Y")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            // Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			if (!Page.IsPostBack)
			{
                //This flag tells us if we're in edit mode whick is when a user has clicked edit on the preview_post page
                Session["EditMode"] = "false";
                
                BindData();
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
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void btnNext_Click(object sender, System.EventArgs e)
        {

            //Instantiate Blog object
            classes.Blog tmpBlog = new classes.Blog();

            tmpBlog.BlogCat = Convert.ToInt32(cboCategory.SelectedItem.Value);
            tmpBlog.User = Convert.ToInt32(Session["userId"].ToString());
            tmpBlog.EditMode = false;
            tmpBlog.BlogDate = DateTime.Now;

            //Save object to session variable
            Session["Blog"] = tmpBlog;

            //to next wizard page
            Response.Redirect("BlogItem.aspx");
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../UserMenu.aspx");
        }

/**
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
			Response.Redirect("blog.aspx");
			
		}
/**
*/  
		public void BindData()
		{
			//declare variables	
			string strSQL;
			string myConnectString;
		
			//Create connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
			
			//Build SQL statement
			strSQL = "SELECT * FROM LK_Category";
			
			SqlConnection myConnection = new SqlConnection(myConnectString);			

			// Read sample item info from SQL into a DataSet
			DataSet dsItems = new DataSet();

			SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

			objAdapter.TableMappings.Add("Table","tblCat");

			objAdapter.Fill(dsItems);
			
			cboCategory.DataSource = dsItems;
			cboCategory.DataMember = "tblCat";
			cboCategory.DataTextField = "Category";
			cboCategory.DataValueField = "iD";
			cboCategory.DataBind();
			cboCategory.SelectedIndex = (int)0;

			myConnection.Close();

		}


	}
}
