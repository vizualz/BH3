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
using System.IO;
using System.Web.Mail;


namespace BoardHunt
{
    /// <summary>
    /// Summary description for post_finish.
    /// </summary>
    public partial class register_Finish : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.ImageButton ImageButton1;
        protected System.Web.UI.WebControls.ImageButton ImageButton2;
        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        //protected System.Web.UI.WebControls.LinkButton lnkPost;

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

        protected void Page_Load(object sender, System.EventArgs e)
        {

            String strSQL;
            String myConnectString;

            // Put user code to initialize the page here
            Global.AuthenticateUser();

            Session["LoggedIn"] = "No";

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (!Page.IsPostBack)
            {

                // Put user code to initialize the page here
                ErrorLog.ErrorRoutine(false, "Registered EmailId: " + Session["EmailId"].ToString());

                //Get DB connect string 
                myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

                //***TODO: E-mail verfication & activation
                //***see contact us page

                strSQL = "Select * FROM tblUser WHERE txtEmail = '" + Session["EmailId"].ToString() + "'";
                SqlConnection myConnection = new SqlConnection(myConnectString);

                string usersId = "unknown";

                try
                {
                    myConnection.Open();
                    SqlCommand objCommand = new SqlCommand(strSQL, myConnection);

                    SqlDataReader objReader = null;
                    objReader = objCommand.ExecuteReader();

                    if (objReader.Read())
                    {
                        usersId = objReader["iD"].ToString();
                        //ErrorLog.ErrorRoutine(false, "userId:" + usersId);

                        //Create dirs
                        if (CreateUserDir(usersId))
                        {
                            //set userID
                            //Session["userId"] = usersId;
                            //Session["LoggedIn"] = "Yes";
                            //Session["BlogFlg"] = "N";
                            //Session["LoggedIn"] = "No";

                            lblMessage.Text = "Your account has been created.  An e-mail confirmation has been sent.";
                            SendCongratEmail();
                            NotifyBHEmail(usersId);

                            if (Session["ServiceId"] != null)
                            {
                                if (Session["ServiceId"].ToString() == "6" || Session["ServiceId"].ToString() == "7") //upgrade
                                {
                                    classes.Login clsLogin = new classes.Login();
                                    if (clsLogin.DoLogin(Session["EmailId"].ToString(), string.Empty, true, true))
                                    {
                                        Session["LoggedIn"] = "Yes";
                                        Response.Redirect("Pay/OrderForm.aspx", false);
                                    }
                                }
                            }
                            else
                            {
                                Session["LoggedIn"] = "No";
                                Session["EmailId"] = null;
                                Session["acctType"] = null;
                                Session["pw"] = null;
                            }
                        }
                        else
                        {
                            Session["LoggedIn"] = "No";
                            Session["EmailId"] = null;
                            Session["acctType"] = null;
                            Session["pw"] = null;
                            ErrorLog.ErrorRoutine(false, "Error creating user dirs");
                            lblMessage.Text = "Registration Failed.  Please close this browser and try again.";
                        }
                    }
                    else
                    {
                        ErrorLog.ErrorRoutine(false, "RegisterFinish:PageLoad:Couldn't locate user.");
                        classes.Email.SendErrorEmail("RegisterFinish:PageLoad:Couldn't locate user.");
                    }
                }

                catch (Exception ex)
                {
                    ErrorLog.ErrorRoutine(false, "RegisterFinish:PageLoad: " + ex.Message);
                    lblMessage.Text = "Registration Failed.  Please close this browser and try again.";
                    Session["LoggedIn"] = "No";
                    Session["EmailId"] = null;
                    Session["pw"] = null;
                    Session["acctType"] = null;
                }

                finally
                {
                    myConnection.Close();
                }

            }

        }
        /*
         */
        private void SendCongratEmail()
        {
            //create e-mail msg
            string mailBody = "<div style='Font-Family: Verdana; Font-Size: 10pt'>";
            mailBody += "Your new Boardhunt account has been created." + "<br><br>";
            mailBody += "Log in to Boardhunt.com with your e-mail address and password to create board postings. You can also leave comments on other board postings, blogs, and ask questions in Ask-A-Pro.<br><br>";
            mailBody += "E-mail: " + Session["EmailId"].ToString() + "<br>";
            mailBody += "Password: " + Session["pw"].ToString() + "<br><br>";
            mailBody += "Thanks,<br>";
            mailBody += "<br>";
            mailBody += "Boardhunt.com";
            mailBody += "</div>";

            classes.Email.SendEmail("Boardhunt Account", Session["EmailId"].ToString(), "info@boardhunt.com", mailBody, false);

            Session["pw"] = null;
        }

        //Creates the new user direcectory only after they have successfully registered
        private bool CreateUserDir(string uId)
        {

            int i = 1;
            int pad_size = 10 - uId.Length;
            string user_path = @Server.MapPath("/") + @"users\";
            string userDir = "";
            String strSQL;
            String myConnectString;

            //pad the user ID with zeroes
            //construct dir path string
            while (i <= pad_size)
            {
                userDir = userDir + @"0\";
                user_path = user_path + @"0\";
                i++;
            }

            i = 0;
            while (i < uId.Length)
            {
                userDir = userDir + uId[i] + @"\";
                user_path = user_path + @uId[i] + @"\";
                i++;
            }

            //create the users' directories
            Directory.CreateDirectory(user_path);
            Directory.CreateDirectory(user_path + Global.BOARDCAT_DIRS.surfboards.ToString());
            Directory.CreateDirectory(user_path + Global.BOARDCAT_DIRS.snowboards.ToString());
            Directory.CreateDirectory(user_path + Global.BOARDCAT_DIRS.other.ToString());
            Directory.CreateDirectory(user_path + Global.BOARDCAT_DIRS.accessories.ToString());
            Directory.CreateDirectory(user_path + @"temp");

            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //Formulate SQL
            strSQL = "UPDATE tblUser SET userDir = '" + userDir + "' WHERE id = '" + uId + "'";
            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();
                myConnection.Close();
                //lblMessage.Text = "You're offically registered with Boardhunt!";
                return true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error!";
                ErrorLog.ErrorRoutine(false, "Error setting userDir:" + ex.Message);
                return false;
            }

        }//end of method

        /*
         */
        private void NotifyBHEmail(string uId)
        {
            classes.Email.SendEmail("New Boardhunt Registration", "info@boardhunt.com", "New User: " + uId + " - Email: " + Session["EmailId"].ToString());
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
}