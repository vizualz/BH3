using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using DALLayer;

namespace BoardHunt
{
    public partial class Register_User : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Label Label5;
        //protected System.Web.UI.WebControls.TextBox txtFirstName;
        //protected System.Web.UI.WebControls.TextBox txtLastName;

        protected System.Web.UI.WebControls.TextBox txtPassword2;
        // protected System.Web.UI.WebControls.CustomValidator CustomValidator3;
        protected System.Web.UI.WebControls.CustomValidator CustomValidator5;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;

        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.CheckBox chkIAgree;
        protected System.Web.UI.WebControls.CheckBox chkCOPPA;
        //protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            //imgClear.CausesValidation = false;

            lblStatus.Text = string.Empty;

            if (!Page.IsPostBack)
            {

                //txtFullName.Attributes.Add("OnBlur", "CheckControl('txtFullName')");
                txtPassword1.Attributes.Add("OnBlur", "CheckControl('txtPassword1')");
                txtEmail.Attributes.Add("OnBlur", "CheckControl('txtEmail')");

                //chkShowPhone.Checked = true;

                //txtEmail.Attributes.Add("OnFocus", "ToggleText('txtEmail','" + txtEmail.Text + "')");
                //txtEmail.Attributes.Add("OnBlur", "ToggleText('txtEmail','" + txtEmail.Text + "')");
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

        }
        #endregion

        //private void imgClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    txtFullName.Text = txtPassword1.Text =  txtEmail.Text =  txtAreaCode.Text = txtPhoneNum.Text = string.Empty;
        //    lblStatus.Text = string.Empty;
        //    lblStatus.Visible = false;
        //}

        //===============================
        //Error Checking & Helper Functions
        //===============================

        protected void CheckIAgree(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!chkIAgree.Checked)
            {
                args.IsValid = false;
                CustomValidator3.ErrorMessage = "!";
            }
        }

        /*
         */
        protected void CheckCOPPA(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!chkCOPPA.Checked)
            {
                args.IsValid = false;
                CustomValidator3.ErrorMessage = "!";
            }
        }

        private bool IsNumeric(object ValueToCheck)
        {
            double Dummy = new double();
            string InputValue = Convert.ToString(ValueToCheck);

            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out Dummy);

            return Numeric;
        }

        protected void CheckPassword(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = false;

            if (txtPassword1.Text == string.Empty || (txtPassword1.Text.Length < 6))
            {
                CustomValidator1.ErrorMessage = "!";
                pnlError.Visible = true;
                lblStatus.Text = "Password needs to be 6 or more characters.";
                lblStatus.Visible = true;
                //lblStatus.CssClass = "errorLabel";
                return;
            }

            //else if 
            //{
            //    pnlError.Visible = true;
            //    lblStatus.Text = "Password needs to be 6 or more characters.";
            //    lblStatus.Visible = true;

            //}
            else
            {
                args.IsValid = true;
            }

        }


        protected void CheckPhoneNum(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
        }

        private bool verify_User(string myConnStr, string emailId)
        {

            bool user_Registered = true;

            string SQLstr = "SELECT iD FROM tblUser WHERE txtEmail ='" + emailId + "'";

            SqlConnection myConn = new SqlConnection(myConnStr);
            SqlDataReader rdr = null;
            SqlCommand objSQLCommand = new SqlCommand(SQLstr, myConn);

            try
            {
                myConn.Open();
                rdr = objSQLCommand.ExecuteReader();

                if (rdr.Read())
                {
                    user_Registered = true;

                }
                else
                {
                    user_Registered = false;
                }
            }
            catch
            {
                pnlError.Visible = true;
                lblStatus.Text = "ERROR!";
            }
            finally
            {
                myConn.Close();
            }

            return user_Registered;
        }
        /*
         */
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {            
            Response.Redirect("login.aspx");
        }
        /*
         */
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("register_user.aspx");

        }
        /*
         */
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post.aspx");
        }
        /*
         */
        private void LinkButton1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("register_user.aspx");
        }

        protected void CheckEmail(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            string patternLenient = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reLenient = new Regex(patternLenient);

            //string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
            //   + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            //   + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            //   + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            //   + @"[a-zA-Z]{2,}))$";
            //Regex reStrict = new Regex(patternStrict);

            if (reLenient.IsMatch(txtEmail.Text.Trim()))
            {
                args.IsValid = true;
            }
            else
            {
                CustomValidator3.ErrorMessage = "!";
                pnlError.Visible = true;
                lblStatus.Text = "Enter in a valid e-mail.";
                //lblStatus.CssClass = "errorLabel";
                lblStatus.Visible = true;
            }


        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {

            if (!(Page.IsValid))
                return;

            if (hdnMeVal.Value != "1")
                return;

            lblStatus.Text = string.Empty;
            pnlError.Visible = false;

            //OBSOLETE
            //if (!chkCOPPA.Checked)
            //{
            //    lblStatus.Text = "You must be 13 yrs of age to register on this web site.";
            //    return;
            //}

            string txtFN, txtEmailId, txtPassword, txtPhoneNumber;
            string txtUserName;
            int iAcctType;
            int showPhone;
            DateTime dCreateDate;

            byte[] hBytes;      //hash bytes
            byte[] saltBytes;   //salt bytes
            string saltString;  //salt string
            int iBoarderType;
            int iMerchantVal;

            //Validate form and get values
            txtFN = " ";


            txtEmailId = txtEmail.Text;
            txtPassword = txtPassword1.Text;
            txtUserName = Global.ParseEmail(txtEmail.Text);

            BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();

            //Get SALT and encode to string
            saltBytes = pHash.GenerateSALT();
            saltString = Convert.ToBase64String(saltBytes);

            //get hash and encode to string with SALT
            hBytes = pHash.getHash(saltString, txtPassword);
            txtPassword = Convert.ToBase64String(hBytes);   //hashed password

            //Free = 1; Commercial = 2
            iAcctType = Convert.ToInt16(radioAcctType.SelectedValue);

            txtPhoneNumber = string.Empty;
            if (txtPhoneNum.Text != "optional")
                txtPhoneNumber = txtPhoneNum.Text;

            showPhone = (int)0;

            //if no phone num is entered then showPhonenum flag must be set to zero
            //if (txtAreaCode.Text != "" && txtPhoneNum.Text != "")
            //{
            //    if (chkShowPhone.Checked == true)
            //    {
            //        showPhone = (int)1;
            //    }
            //}
            //else
            //{
            //    showPhone = (int)0;
            //}

            iBoarderType = 1; // cboBoarderType.SelectedIndex;

            //log date acct created
            dCreateDate = DateTime.Now;

            //Connect to DB	
            String strSQL;
            String myConnectString;

            //Formulate connect string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            //Verify unique e-mail id.  This is how we try to prevent users
            if (verify_User(myConnectString, txtEmailId))
            {
                pnlError.Visible = true;
                lblStatus.Text = "That e-mail is already registered.  Please try another one.";
                //lblStatus.CssClass = "errorLabel";
                lblStatus.Visible = true;
                return;
            }

            iMerchantVal = (int)0;
            if (iAcctType == (int)2)
            {

                iMerchantVal = Convert.ToInt16(cboMerchantType.SelectedValue);
                if (iMerchantVal == (int)0)
                {
                    pnlError.Visible = true;
                    lblStatus.Text = "Select your type of business.";
                    //lblStatus.CssClass = "errorLabel";
                    cboMerchantType.BorderColor = Color.Red;
                    lblStatus.Visible = true;
                    return;
                }
            }

            //Build SQL
            strSQL = "INSERT INTO tblUser (txtFullName, txtPassword, txtPhoneNum, iShowPhoneNum, txtEmail, dCreateDate, iEntryCount, iAcctType, sashimi, salt, boarderType, iMerchantType, txtUserName)";
            strSQL += "VALUES ('" + txtFN + "', '" + txtPassword + "', '" + txtPhoneNumber + "', '" + showPhone + "','" + txtEmailId + "' , '" + dCreateDate + "','" + (int)0 + "','" + iAcctType + "','" + (int)1 + "','" + saltString + "','" + iBoarderType + "','" + iMerchantVal + "','" + txtUserName + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {

                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                Session["LoggedIn"] = "Yes";
                Session["EmailId"] = txtEmailId;
                Session["acctType"] = Convert.ToInt16(radioAcctType.SelectedValue);
                Session["pw"] = txtPassword1.Text;

                // Successful login, save iD for user events while logged in
                if (chkUpgrade.Checked)
                    Session["ServiceId"] = 7;
                else if (chkUpgrade2.Checked)
                    Session["ServiceId"] = 6;
                else
                    Session["ServiceId"] = null;

                Response.Redirect("register_finish.aspx", false);
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Signup failed!  Message: " + ex.Message);
                pnlError.Visible = true;
                lblStatus.Text = "Signup Failed.";
                //lblStatus.CssClass = "errorLabel";
                lblStatus.Visible = true;
            }

            finally
            {
                myConnection.Close();
            }

        }

    }
}
