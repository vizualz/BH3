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

namespace BoardHunt.Qna
{
	/// <summary>
	/// Summary description for post_finish.
	/// </summary>
	public partial class FinishQ : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;		
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

            if (!Page.IsPostBack)
            {
                classes.Question tQ = (classes.Question)Session["QItem"];

                if (tQ == null)
                    return;

                // Put user code to initialize the page here
			    Global.AuthenticateUser();

			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

                string entryId;

                //display the correct entry id: Update or New?
                if (tQ.QId == (int)-1)
                {
                    entryId = GetNewEntryId();
                }
                else
                {
                    entryId = tQ.QId.ToString();
                }

                // Put user code to initialize the page here 
                lblMessage.Text = "You're done!";

                string eLink = System.Configuration.ConfigurationSettings.AppSettings["serverURL"].ToString() + "/Qna/QDetails.aspx?q=" + entryId;

                lnkPostItem.Text = eLink;
                lnkPostItem.NavigateUrl = eLink;

                string[] eLinkArr = new string[1];
                eLinkArr[0] = eLink;

                //email only if new
                if (tQ.QId == (int)-1)
                {
                    classes.Email.SendEmail("Thanks for Asking", Session["EmailId"].ToString(), 4, eLinkArr);
                }

                Session["QItem"] = null;

                ////////////////////

                //hdnEntryVal.Value = entryId;
                //lnkPostItem.Attributes.Add("href", "mailto:" + "?subject=See My Boardhunt Posting&body=" + eLink);
                //lnkPostItem.NavigateUrl = "surfboard.aspx?iD=" + entryId + "&uId=" + tmpBoardItem.IUser + "&iCat=" + tmpBoardItem.Category;

                //txtEntryLink.Text = eLink;
                //txtEntryLink.ReadOnly = true;
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
			Response.Redirect("../post.aspx");
			
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
            strSQL = "SELECT MAX(QiD) FROM Questions";
            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                if (SQLReader.Read())
                {
                    //set control values
                    objId = SQLReader.GetValue(0);
                    strId = objId.ToString();
                }
            }

            catch
            {
                lblMessage.Text = "Error: " + strSQL;
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
	}
};
