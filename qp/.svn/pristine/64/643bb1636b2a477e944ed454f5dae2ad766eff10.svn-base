//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			qp\Settings.apx.cs
///		
///
/// Notes: Still testing SaveUserDataForCoupon
//////////////////////////////////////////////////////////////////////////



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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DALLayer;

namespace BoardHunt.qp
{
	/// <summary>
	/// Summary description for edit_profile.
	/// </summary>
	/// 
	
	public partial class Settings : System.Web.UI.Page
	{
    

		protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.TextBox txtPassword2;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here
            Global.AuthenticateUser();			
			
			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			if (!(Page.IsPostBack))
			{
                //LoadControls();

                //check query string to see if it's new or edit mode
                string[] arrStr;
                arrStr = Request.QueryString.GetValues("q");
                if (arrStr != null)
                {
                    hdnAId.Value = arrStr[0];
                    arrStr = null;
                }
                else
                    hdnAId.Value = string.Empty;

                arrStr = Request.QueryString.GetValues("r");
                if (arrStr != null)
                {
                    hdnRDir.Value = arrStr[0];
                    if (hdnRDir.Value == "1")
                        btnSave.Text = "Next";

                }

                GetUserProfileData();
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
		}
		#endregion
		//Update user profile
        private void btnSave_Click(object sender, System.EventArgs e)
		{

            string strSQL = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //TODO:
            //verify form
            
            classes.User oUser = new classes.User();

            oUser.Phone = txtPhoneNum.Text;
            oUser.UserName = txtDisplayName.Text;
            oUser.Address = txtAddress.Text;
            oUser.Website = txtWeb.Text;
            
            oUser.State = txtState.Text.ToUpper();
            oUser.City = txtCity.Text;
            oUser.Zipcode = txtZip.Text;

            oUser.ID = Convert.ToInt32(hdnUId.Value);

            //NEW Address
            if (hdnAId.Value == string.Empty)
            {
                if (oUser.SaveForCoupon())   //stored_proc
                {
                    if (hdnRDir.Value == "1")
                        Response.Redirect("Post.aspx", true);

                    Response.Redirect("Manager.aspx?m=1", true);
                }
                else
                    Response.Redirect("Manager.aspx?m=2", true);
            }
            else
            {
                oUser.GenData1 = hdnAId.Value;
                if (oUser.UpdateForCoupon()) //stored_proc
                    Response.Redirect("Manager.aspx?m=1", true);
                else
                    Response.Redirect("Manager.aspx?m=2", true);
            }
            //FIXME: error.
		}

		//===============================
		//Error Checking & Helper Functions
		//===============================

/*
 */
        protected void ShowMessage(bool hideAll, string msg, int msgType)
        {
            //msgType 0=ERROR

            pnlMessage.Visible = true;
            lblMessage.Text = msg;
            
            if (hideAll)
            {
                btnCancel.Visible = false;
                btnSave.Visible = false;
                pnlSettings.Visible = false;            
            }
        }		
        
        private bool IsNumeric(object ValueToCheck)
		{
			double Dummy = new double();
			string InputValue = Convert.ToString(ValueToCheck);

			bool Numeric = double.TryParse( InputValue , System.Globalization.NumberStyles.Any , null , out Dummy);
		
			return Numeric;
		}


		
			protected void CheckPhoneNum(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
			{
                args.IsValid = true;
                return;
                
                args.IsValid = false;
				
				//check for blank entries
				if (txtPhoneNum.Text == "")
				{
                    args.IsValid = true;
                    return;

				}

                else if (txtPhoneNum.Text == "")
                {
                    Customvalidator1.ErrorMessage = "!";

                }

                else if (txtPhoneNum.Text.Length > 0)
                {
                    Customvalidator1.ErrorMessage = "!";

                }

                //else if (!Regex.IsMatch (txtAreaCode.Text,@"\d{3}"))
                ////validate phone num entry against reg exp
                //{
                //    Customvalidator1.ErrorMessage = "!";	
                //}

				else if (!Regex.IsMatch (txtPhoneNum.Text,@"(\d{3}-\d{4})|(\d{3}.\d{4})|\d{7}"))
					//validate phone num entry against reg exp
				{
					Customvalidator1.ErrorMessage = "!";	

				}

				else
				{
					args.IsValid = true;
				}
		
			}
/*
*/
        private bool verify_User(string myConnStr, string emailId)
        {

            bool user_Registered = false;
            string SQLstr = "SELECT iD FROM tblUser WHERE txtEmail ='" + emailId + "'";
            SqlConnection myConn = new SqlConnection(myConnStr);
            SqlDataReader rdr = null;
            SqlCommand objSQLCommand = new SqlCommand(SQLstr, myConn);

            try
            {
                myConn.Open();
                rdr = objSQLCommand.ExecuteReader();

                if (rdr.Read())
                    user_Registered = true;
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
/**
*/
         private void lnkPost_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../post.aspx");
			
		}		

/**
 */ 
        private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../register_user.aspx");
		}
/**
 */
		private void GetUserProfileData()
		{

            string strSQL, tempPhone;

            tempPhone = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //FixMe: Change so admin can update other user's coupons i.e. Session["userId"]
            //if (iUserType !=)
            hdnUId.Value = Session["userId"].ToString();    //for now

            //Make SQL query and command obj
            strSQL = @"SELECT a.iD as addyId, a.pAddress, a.city, a.stateAbbr, a.zipcode, u.txtUserName, u.txtWebSite, u.txtPhoneNum, u.iD as uId 
                       FROM tblUser u  
                       LEFT JOIN tblAddress a ON a.iUser = u.iD
                       WHERE u.iD = '" + Session["userId"].ToString() + "'";

            ErrorLog.ErrorRoutine(false, strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    if (dbManager.DataReader["addyId"] != DBNull.Value)
                    hdnAId.Value = dbManager.DataReader["addyId"].ToString();

                    //SECURITY CHECK: Ensure user or admin is editing
                    if (dbManager.DataReader["uId"].ToString() != Session["userId"].ToString() && (Session["EmailId"].ToString() != "admin@boardhunt.com"))
                    {
                        Response.Redirect("../UserMenu.aspx", true);
                        classes.Email.SendEmail("Hack attempt", "info@boardhunt.com", "Hack attempt at posting: " + Session["userId"].ToString());
                    }                    

                    //Set and get values for textboxes
                    if (dbManager.DataReader["txtUserName"] != DBNull.Value)
                        txtDisplayName.Text = dbManager.DataReader["txtUserName"].ToString();

                    if (dbManager.DataReader["txtPhoneNum"] != DBNull.Value)
                        txtPhoneNum.Text = dbManager.DataReader["txtPhoneNum"].ToString();

                    if (dbManager.DataReader["pAddress"] != DBNull.Value)
                        txtAddress.Text = dbManager.DataReader["pAddress"].ToString();

                    if (dbManager.DataReader["txtWebSite"] != DBNull.Value)
                        txtWeb.Text = dbManager.DataReader["txtWebSite"].ToString();

                    if (dbManager.DataReader["stateAbbr"] != DBNull.Value)
                       txtState.Text = dbManager.DataReader["stateAbbr"].ToString();
                   
                    if (dbManager.DataReader["city"] != DBNull.Value)
                        txtCity.Text = dbManager.DataReader["city"].ToString();

                   if (dbManager.DataReader["zipcode"] != DBNull.Value)
                       txtZip.Text = dbManager.DataReader["zipcode"].ToString();


                    //if (dbManager.DataReader["txtPhoneNum"].ToString().Length > 1)
                    //{
                    //    tempPhone = dbManager.DataReader["txtPhoneNum"].ToString();
                    //    iPhoneLength = tempPhone.Length;

                    //    //show area code
                    //    txtAreaCode.Text = tempPhone.Substring(0, 3);
                    //    txtPhoneNum.Text = tempPhone.Substring(4, iPhoneLength - 4);
                    //}

                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "CouponSettings:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
		}
/*
 */
        private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../UserMenu.aspx");
		}

/*
 * */
        private void LoadControls()
        {

            //string strSQL = "SELECT BoardType, iValue FROM LK_BoardType WHERE BoardCategory = 1;SELECT iD, Region FROM LK_Region" ;
            //IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            //dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            //DataSet ds = new DataSet();

            //try
            //{
            //    dbManager.Open();
            //    ds = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

            //        chkListShaping.DataSource = ds;
            //        chkListShaping.DataMember = ds.Tables[0].ToString();
            //        chkListShaping.DataTextField = "BoardType";
            //        chkListShaping.DataValueField = "iValue";
            //        chkListShaping.DataBind();

            //        cboRegion.DataSource = ds;
            //        cboRegion.DataMember = ds.Tables[1].ToString();
            //        cboRegion.DataTextField = "Region";
            //        cboRegion.DataValueField = "iD";
            //        cboRegion.DataBind();

            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.ErrorRoutine(false, "Error:EditProfile:LoadControl: " + ex.Message);
            //}
            //finally
            //{
            //    dbManager.Close();
            //    dbManager.Dispose();
            //}
            
        }
	}
}
