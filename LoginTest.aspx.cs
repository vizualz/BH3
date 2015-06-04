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
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using DALLayer;
using System.Configuration;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using BusinessLogic;

namespace BoardHunt
{
    /// <summary>
    /// Summary description for login.
    /// </summary>
    public partial class LoginTest : System.Web.UI.Page
    {
        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        //protected System.Web.UI.WebControls.LinkButton lnkPost;
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //FaceBookConnect.API_Key = "110490412616411";
            //FaceBookConnect.API_Secret = "be2db8948341ed782d6369120514dd55";

            FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FaceBook_API_Key"];
            FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FaceBook_API_Secret"];
            
            if (Session["LoggedIn"].ToString() == "Yes")
                Response.Redirect("UserMenuTest.aspx", false);


            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            hdnVal.Value = string.Empty;

            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                Session["FaceBookCode"] = code;

                string data = FaceBookConnect.Fetch(code, "me");
                FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                
                if (BusinessLogic.HelperFunctions.FaceBookLogin(faceBookUser, Session))
                {
                    if (Session["GoToURL"].ToString() == string.Empty)
                        Response.Redirect("UserMenuTest.aspx", true);
                }
            }

            if (Request.QueryString["m"] != null)
            {
                string qStr = Request.QueryString["m"].ToString();

                if (qStr == "1")
                {
                    lblMessage.Text = "&nbsp;Please login or <a class='alert' href='register_user.aspx'><u>sign up</u></a> first!&nbsp;";
                    lblMessage.BackColor = Color.White;
                    lblMessage.BorderColor = Color.Red;
                    lblMessage.Visible = true;
                    lblMessage.Height = Unit.Pixel(16);
                }
            }
        }

        protected void lnkFacebookLogin_Click(object sender, EventArgs e)
        {
            try
            {
                FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
            }
            catch (Exception ex)
            {
                throw ex;
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
            //this.imgLogin.Click += new System.Web.UI.ImageClickEventHandler(this.imgLogin_Click);
            //this.imgNewUser.Click += new System.Web.UI.ImageClickEventHandler(this.imgNewUser_Click);

        }
        #endregion

        private void imgNewUser_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("register_user.aspx", false);
        }

        private void imgLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (!Page.IsValid)
                return;

            DoLogin();

        }
        /*
         */
        private void DoLogin()
        {
            BoardHunt.classes.Login clsLogin = new BoardHunt.classes.Login();
            if (clsLogin.DoLogin(txtUsername.Text, txtPassword.Text, true, false))
            {
                //Set cookie
                if (chkRememberMe.Checked)
                {
                    SetCookie();
                }
                //Destroy the cookie with previous data
                else
                {
                    DestroyCookie();
                }

                //TODO: fixfixfix
                if (Session["EmailId"].ToString() == "admin@boardhunt.com")
                    Response.Redirect("Admin/Admin.aspx", true);

                if (Session["GoToURL"] != null)
                {
                    if (Session["GoToURL"].ToString() == string.Empty)
                        Response.Redirect("UserMenuTest.aspx", true);
                    else
                    {
                        string strGoURL = Session["GoToURL"].ToString();
                        Session["GoToURL"] = string.Empty;
                        Response.Redirect(strGoURL, true);
                    }
                }

            }
            //login failed 
            else
            {
                //and destroy cookie
                if (!chkRememberMe.Checked)
                {
                    DestroyCookie();
                }
                lblMessage.Text = "&nbsp;Wrong e-mail or password.&nbsp;";
                lblMessage.BackColor = Color.White;
                lblMessage.BorderColor = Color.Red;
                lblMessage.Visible = true;
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
            Response.Redirect("post.aspx");
        }

        public void CheckUserName(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

            string usr = txtUsername.Text;

            if ((!Regex.IsMatch(usr, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")) || usr.Length == (int)0)
            {
                args.IsValid = false;
                CustomValidator1.ErrorMessage = "!";
                lblMessage.Text = "&nbsp;Missing or invalid e-mail.&nbsp;";
                lblMessage.BackColor = Color.White;
                lblMessage.BorderColor = Color.Red;
                lblMessage.Visible = true;
            }

        }
        public void CheckPass(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

            args.IsValid = true;

            if ((string.Empty == txtPassword.Text) || (txtPassword.Text == ""))
            {
                args.IsValid = false;
                CustomValidator2.ErrorMessage = "!";
                lblMessage.Text = "&nbsp;Type in a password.&nbsp;";
                lblMessage.BackColor = Color.White;
                lblMessage.BorderColor = Color.Red;
                lblMessage.Visible = true;
            }
        }
        /*
         */
        public bool ReadCookie()
        {

            if (HttpContext.Current.Request.Cookies["UserInfo"] != null)
            {
                txtUsername.Text = Server.HtmlEncode(HttpContext.Current.Request.Cookies["UserInfo"]["sea"].ToString());
                txtPassword.Text = Server.HtmlEncode(HttpContext.Current.Request.Cookies["UserInfo"]["monkey"].ToString());
                chkRememberMe.Checked = true;
                return true;
            }
            else
            {
                chkRememberMe.Checked = false;
                return false;
            }
        }
        /**
         */
        public void SetCookie()
        {
            if (hdnVal.Value.Length == 0 || txtUsername.Text.Length == 0)
            {
                return;
            }

            HttpCookie _userInfo = new HttpCookie("UserInfo");
            _userInfo["sea"] = txtUsername.Text;
            _userInfo["monkey"] = hdnVal.Value;
            _userInfo.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(_userInfo);
        }

        public void DestroyCookie()
        {
            //expire cookie by setting it to yeaster-year
            HttpCookie _userInfo = new HttpCookie("UserInfo");
            _userInfo.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(_userInfo);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            DoLogin();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register_user.aspx", true);
        }

    }
}