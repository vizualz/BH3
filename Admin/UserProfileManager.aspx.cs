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
using DALLayer;

namespace BoardHunt.Admin
{
    public partial class UserProfileManager1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            Global.AuthenticateUser();

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                ErrorLog.ErrorRoutine(false, "Hack Attempt into Admin section!");
                Response.Redirect("../UserMenu.aspx");
            }

            if (!Page.IsPostBack)
            {
                hdnUId.Value = Request.QueryString["iD"].ToString();
                BindData();
            }
        }

        protected void BindData()
        {

            string strSQL, myConnectString, tempPhone;
            tempPhone = string.Empty;

            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Make SQL query and command obj
            strSQL = "SELECT * FROM tblUser WHERE iD = '" + hdnUId.Value + "'";
            SqlConnection myConnection = new SqlConnection(myConnectString);
            SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
            SqlDataReader SQLReader = null;

            try
            {
                myConnection.Open();
                SQLReader = objCommand.ExecuteReader();

                while (SQLReader.Read() == true)
                {
                    //Set and get values for textboxes
                    txtFullName.Text = SQLReader["txtFullName"].ToString();
                    txtEmail.Text = SQLReader["txtEmail"].ToString();
                    txtPhoneNum.Text = SQLReader["txtPhoneNum"].ToString();
                    radioAcctType.SelectedValue = SQLReader["iAcctType"].ToString();
                    rdoEmailNotify.SelectedValue = SQLReader["notify_comment_flg"].ToString();
                    rdoBlogNotify.SelectedValue = SQLReader["notify_blog_flg"].ToString();

                    chkShowPhone.Checked = false;
                    if (SQLReader["iShowPhoneNum"].ToString() == "1")
                    {
                        chkShowPhone.Checked = true;
                    }

                    if (SQLReader["iVoucher"] != null)
                    {
                        if (SQLReader["iVoucher"].ToString().Length > 0)
                            cboVoucher.SelectedValue = SQLReader["iVoucher"].ToString();
                        else
                            cboVoucher.SelectedValue = "0";
                    }
                    else
                    cboVoucher.SelectedValue = "0";
                    
                    //txtAreaCode.Text = txtPhoneNum.Text = string.Empty;

                    //if (SQLReader["txtPhoneNum"].ToString().Length > 1)
                    //{
                    //    tempPhone = SQLReader["txtPhoneNum"].ToString();
                    //    iPhoneLength = tempPhone.Length;

                    //    //show area code
                    //    txtAreaCode.Text = tempPhone.Substring(0, 3);
                    //    txtPhoneNum.Text = tempPhone.Substring(4, iPhoneLength - 4);
                    //}
                }

            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "UPM:BindData:ERROR: " + ex.Message);
                //lblStatus.Text = "Error: " + strSQL;
            }

            finally
            {
                myConnection.Close();
            }
        }

        protected void CheckPassword(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

            //Check for too short of a password; Allow empty string but we won't process pwd
            //if (pnlChangePwd.Visible == true && txtPassword1.Text.Length > 0 && txtPassword1.Text.Length < 6)
            //{
            //    lblStatus.Text = "Please use at least 6 characters!";
            //    args.IsValid = false;
            //}
            return;
        }


        protected void CheckPhoneNum(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;
        }
/*
*/
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
                ErrorLog.ErrorRoutine(false, "Error attempting to verify new user e-mail");
                lblStatus.Text = "ERROR!";
            }
            finally
            {
                myConn.Close();
            }
            return user_Registered;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElJefe.aspx", true);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            classes.User oUser = new classes.User();
            //oUser.Address = txtAddress.Text;
            //oUser.Website = txtWeb.Text;

            oUser.Phone = txtPhoneNum.Text;
            oUser.Email = txtEmail.Text.Trim();
            oUser.Fullname = txtFullName.Text.Trim();
            oUser.ID = Convert.ToInt32(hdnUId.Value);
            oUser.AcctType = Convert.ToInt32(radioAcctType.SelectedValue);
            oUser.Voucher = Convert.ToInt32(cboVoucher.SelectedValue);

            if (chkShowPhone.Checked)
                oUser.ShowPhonenum = 1;

            //***BUG was from class get/set variable = private value
            oUser.FlgBlogNotify = rdoBlogNotify.SelectedValue;

            oUser.FlgCommentNotify = rdoEmailNotify.SelectedValue;

            if (oUser.UpdateProfile())
                Response.Redirect("ElJefe.aspx", true);
            lblStatus.Text = "Error updating.  Check log.";

        }

    }
}
