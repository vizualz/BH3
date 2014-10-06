//
//Project File Log: See CVS bitches
//
//

using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;



namespace BoardHunt.Qna
{
	/// <summary>
	/// Summary description for result_details.
	/// </summary>
	/// 
	

	public partial class PreviewQ : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            ErrorLog.ErrorRoutine(false, "PreviewQ:PageLoad");

            //BoardItem tmpBoardItem = (BoardItem)Session["Item"];
            classes.Question tempQ = (classes.Question)Session["QItem"];

            if (!Page.IsPostBack)
            {

                ErrorLog.ErrorRoutine(false, "PreviewQ:FirstTime");
    
                // Put user code to initialize the page here
			    lnkSignIn.Text = Global.SetLnkSignIn( );
			    lnkSignUp.Text = Global.SetLnkSignUp( );

                //Load up display data and show a preview of the posting
                BindData(tempQ);
			}

		}

/**
 * Display the data the user has entered from the (previous) post_item page.  The data now resides in a general entry item object
 * Show the general info then display board specfic detail
 */ 
		private void BindData(classes.Question qItem)
		{

            ErrorLog.ErrorRoutine(false, "PreviewQ:Binding Data");

            lblQuestion.Text = qItem.StrQuestion;
            //lblCategory.Text = qItem.Category.ToString();

            //show today's date
            lblDateData.Text = String.Format("{0:MM/dd}", DateTime.Now);
            lnkEmailData.Text = ParseEmail(Session["EmailId"]);
            lblTags.Text = qItem.Tags;

            ErrorLog.ErrorRoutine(false, "PreviewQ:Done");
		}		
		
	#region Web Form Designer generated code
/**
 */ 
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
			this.imgContinue.Click += new System.Web.UI.ImageClickEventHandler(this.imgContinue_Click);
            this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

/**
 */ 

		private void imgGoBack_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

		}
/*
 */
        public string ParseEmail(object em)
        {
            string[] arrStr;
            char[] splitter = { '@' };

            arrStr = em.ToString().Split(splitter);
            return arrStr[0];
        }

/**
 */     //TODO: DecodeCategory
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);

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
			Response.Redirect("../post.aspx");
			
		}
        
 /**
  * Update the user's entry count to keep track of # of postings
 */ 
		public bool UpdateEntryCount(string uiD)
		{
			bool retVal;

            string conn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
			SqlConnection myConnection = new SqlConnection(conn);
			string strSQL = "UPDATE tblUser SET iEntryCount = iEntryCount + 1 WHERE iD = '" + uiD + "'";
			

			try
			{
				myConnection.Open();
				SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
				objCommand.ExecuteNonQuery();
				retVal = true;
			}
			catch
			{
				lblStatus.Text = "ERROR on UPDATE: " + strSQL;
				retVal = false;
			}
			finally
			{
				myConnection.Close();
				
			}
			return retVal;
		}		

/**
 */ 
		private void imgContinue_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

            classes.Question tmpQ = (classes.Question)Session["QItem"];

            //show error panel if the object goes null.  If so, then that really sux.
            if (tmpQ == null)
            {
                ErrorLog.ErrorRoutine(false, "Error: BoardItem obj NULL!");
                ErrorLog.ErrorRoutine(false, "SessionID: " + Session.SessionID);

                pnlError.Visible = true;
                return;
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "QItem OK!");
            }

            tmpQ.Tags = Global.CheckString(tmpQ.Tags);
            tmpQ.StrQuestion = Global.CheckString(tmpQ.StrQuestion);

            if (tmpQ.QId != (int)-1)
            {
                //Update
                if (tmpQ.UpdateItem())
                {
                    Response.Redirect("FinishQ.aspx", false);
                }
                else
                {
                    lblStatus.Text = "Error updating question.";
                }
            }
            else
            {
                //New or Edit-new

                //Set the date.  All other fields should be ok since we're only viewing on this page
                tmpQ.CreateDate = DateTime.Now;


                    //Save entry
                    //write entry to db
                    if (tmpQ.SaveNewItem())
                    {

                        //TODO: Decide if we're going to count 
                        //if (UpdateEntryCount(tmpQ.IUser.ToString()))
                        //{
                        //    Response.Redirect("FinishQ.aspx");
                        //}
                        Response.Redirect("FinishQ.aspx",false);
                    }
                    else
                    {
                        lblStatus.Text = "Error Posting Question!";
                        return;
                    }

            }
		}

        protected void imgGoBack_Click2(object sender, ImageClickEventArgs e)
        {
            //Set edit mode and load up the session variable with the class object
            classes.Question tQ = (classes.Question)Session["QItem"];
            tQ.EditMode = true;
            Session["QItem"] = tQ;
            Response.Redirect("PostQ.aspx", false);
        }
	}
}
