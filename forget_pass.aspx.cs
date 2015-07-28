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
using System.Web.Mail;
using System.Data.SqlClient;


namespace BoardHunt
{
	/// <summary>
	/// Summary description for contact.
	/// </summary>
	public partial class forget_pass : System.Web.UI.Page
	{

	
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
	        panelMailSent.Visible = false;
		}
			
			

		public void btnSearch_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                return;
            }
    
            //Connect to DB	
            String strSQL;
            String myConnectString;

            //Formulate connect string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "SELECT * FROM tblUser WHERE txtEmail='" + txtEmail.Text + "'";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                myConnection.Open();

                SqlDataReader objReader = null;
                objReader = objCommand.ExecuteReader();

                if (objReader.Read() == true)
                {

                    BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();
                    byte[] saltBytes = pHash.GenerateSALT();
                    string saltString = Convert.ToBase64String(saltBytes);
                    
                    
                    BoardHunt.classes.RandomPassword pwdGen = new BoardHunt.classes.RandomPassword();
                    string newPwd = pwdGen.Generate();
                    
                    byte[] hBytes = pHash.getHash(saltString, newPwd);
                    string hPass = Convert.ToBase64String(hBytes);

                    if (UpdateUserPwd(hPass, saltString))
                    {
                        //check password match
                        if (newPwd != null && newPwd != "" && newPwd.Length > 0)
                        {

                            string emailMsg = "Your new password is: " + newPwd + "<br><br>You can change it again in the edit profile settings.";
                            classes.Email.SendEmail("Login info", txtEmail.Text, "bh-noreply@boardhunt.com", emailMsg, false);
                            
                            ////Mail the password
                            ////Create an instance of the MailMessage class
                            //MailMessage mail = new MailMessage();

                            ////mail.To = "info@boardhunt.com";
                            //mail.To = txtEmail.Text;
                            //mail.From = "bh-noreply@boardhunt.com";

                            ////'If you want to CC this email to someone else
                            ////'objMM.Cc = "support@1and1.com"

                            ////email format. Can be Text or Html
                            //mail.BodyFormat = MailFormat.Text;

                            ////Set the priority - options are High, Low, and Normal
                            //mail.Priority = MailPriority.Normal;

                            ////Set the subject
                            //mail.Subject = "Login info";

                            ////Set the body
                            //mail.Body = "Your new password is: " + newPwd;

                            ////Smtp Server
                            //SmtpMail.SmtpServer = "mrelay.perfora.net";

                            ////Send the message
                            //SmtpMail.Send(mail);

                            panelSendEmail.Visible = false;
                            panelMailSent.Visible = true;

                        }                    
                    }
                }
                else
                {
                    //TODO: add code for no record for e-mail
                    lblStatus.Text = "&nbsp;We can't find that e-mail.  Check it again or sign up.&nbsp;";
                    lblStatus.BorderWidth = 1;
                }
            }

            catch
            {
                lblStatus.Text = "Error!";
            }

            finally
            {
                myConnection.Close();
            }



        }
        


        /**
         * Update the password field with new hashed password
        */
        public bool UpdateUserPwd(string pwd, string salt)
        {
            bool retVal;

            string conn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            SqlConnection myConnection = new SqlConnection(conn);
            string strSQL = "UPDATE tblUser SET txtPassword = '" + pwd + "', salt = '" + salt + "', sashimi = '1' WHERE txtEmail = '" + txtEmail.Text + "'";


            try
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();
                retVal = true;
            }
            catch
            {
                lblStatus.Text = "ERROR Updating password: " + strSQL;
                retVal = false;
            }
            finally
            {
                myConnection.Close();

            }
            return retVal;

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
			
			this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            
		}
		#endregion
	}
}
