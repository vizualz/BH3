
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DALLayer;

namespace BoardHunt.classes
{
    public class User
    {

        private int iD;
        private string userName;
        private string email;
        private string website;
        private string phone;
       
        private string address;
        private string state;
        private string city;
        private string zipcode;
        private string genData1;

        private string country;
        private int voucher;
        private string fullname;
        private int acctType;
        private int showPhonenum;

        private string flgCommentNotify;
        private string flgBlogNotify;

        protected const int FREE_BOARD_COUNT = 10;

        //====================================================================
        //Constructor
        //====================================================================
        public User()
        {

        }

        public string FlgCommentNotify
        {
            get { return flgCommentNotify; }
            set { flgCommentNotify = value; }
        }

        public string FlgBlogNotify
        {
            get { return flgBlogNotify; }
            set { flgBlogNotify = value; }
        }

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public string GenData1
        {
            get { return genData1; }
            set { genData1 = value; }
        }

        public int ShowPhonenum
        {
            get { return showPhonenum; }
            set { showPhonenum = value; }
        }

        public int AcctType
        {
            get { return acctType; }
            set { acctType = value; }
        }

        public int Voucher
        {
            get { return voucher; }
            set { voucher = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

//
// Helper Functions
//

        public bool UpdateForCoupon()
        {
            ErrorLog.ErrorRoutine(false, "UpdateForCoupon");

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            dbManager.CreateParameters(9);

            dbManager.AddParameters(0, "@Phone", phone);
            dbManager.AddParameters(1, "@UserName", userName);
            dbManager.AddParameters(2, "@Web", website);

            dbManager.AddParameters(3, "@Address", address);
            dbManager.AddParameters(4, "@Zip", zipcode);
            dbManager.AddParameters(5, "@City", city);
            dbManager.AddParameters(6, "@State", state);

            dbManager.AddParameters(7, "@UId", iD);
            dbManager.AddParameters(8, "@AId", genData1);            

            try
            {
                int iRet = 0;
                dbManager.Open();
                iRet = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateUserDataForCoupon"));
                ErrorLog.ErrorRoutine(false, "iRet:" + iRet);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:UpdateCoupon:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        private bool Delete()
        {
            return false;
        }

        public bool SaveForCoupon()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //FIXME:
            int userId = Convert.ToInt32(HttpContext.Current.Session["userId"].ToString());        
            
            //oUser.Phone = txtPhoneNum.Text;
            //oUser.UserName = txtDisplayName.Text;
            //oUser.Address = txtAddress.Text;
            //oUser.Website = txtWeb.Text;

            //(@Title, @Body, @Code, @SMSPkgCnt, 0, GETDATE(), @User, @ImgPath, 0, @DExpire, @Category);

            dbManager.CreateParameters(8);

            dbManager.AddParameters(0, "@Phone", phone);
            dbManager.AddParameters(1, "@UserName", userName);
            dbManager.AddParameters(2, "@Web", website);

            dbManager.AddParameters(3, "@Address", address);
            dbManager.AddParameters(4, "@Zip", zipcode);
            dbManager.AddParameters(5, "@City", city);
            dbManager.AddParameters(6, "@State", state);
            dbManager.AddParameters(7, "@UserId", userId);

            try
            {
                int iRet = 0;
                dbManager.Open();
                //iRet = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.StoredProcedure, "sp_SaveUserDataForCoupon"));
                iRet = dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_SaveUserDataForCoupon");
                ErrorLog.ErrorRoutine(false, "iRet: " + iRet);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:SaveCoupon:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public bool UpdateProfile()
        {

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblUser SET txtFullName = '" + fullname;
            strSQL += "' ,txtEmail = '" + email;
            strSQL += "',txtPhoneNum = '" + phone;

            strSQL += "',iVoucher = '" + voucher;
            strSQL += "',iAcctType = '" + acctType;
            strSQL += "',notify_comment_flg = '" + flgCommentNotify;
            strSQL += "',notify_blog_flg = '" + flgBlogNotify + "'";
            //strSQL += "',txtUserName = '" + txtUserName.Text;

            //if (hdnAcctType.Value == "2")
            //{
            //    if (hdnMT.Value == "1")
            //    {
            //        strSQL += "',txtHomeTown = '" + Global.CheckString(txtHomeTown.Text);
            //        strSQL += "',txtWebSite = '" + Global.CheckString(txtWebsite.Text);
            //        strSQL += "',txtUserDetails = '" + Global.CheckString(txtDetails.Text);
            //        strSQL += "',iWisdom = '" + Global.CheckString(txtShapingYrs.Text);
            //        strSQL += "',txtBrandName = '" + Global.CheckString(txtBrandName.Text);
            //        strSQL += "',iRegion = '" + cboRegion.SelectedValue;

            //        if (hdnShaperCode.Value.Length > 0)
            //            strSQL += "',iShaperCode = '" + Global.CheckString(hdnShaperCode.Value);
            //    }
            //}

            strSQL += " WHERE id =" + ID;

            ErrorLog.ErrorRoutine(false, "User:UpdateProfile:strSQL:" + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "User:UpdateProfile:Error:" + ex.Message);
                ErrorLog.ErrorRoutine(false, "User:UpdateProfile:strSQL:" + strSQL);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }        
        }

        public static bool NeedsUpgrade(int iD)
        {

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = "select count(iD) as numpost from tblentry where iStatus = 1 and iCategory = 1 and iuser = '" + iD + "'";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    if (Convert.ToInt32(dbManager.DataReader["numpost"].ToString()) >= (int)FREE_BOARD_COUNT)
                        return true;
                    else
                        return false;

                }
                else
                {
                    ErrorLog.ErrorRoutine(false, "Zero boards found.  On with post..");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "User.NeedsUpgrade: " + ex.Message);
                classes.Email.SendErrorEmail("User.NeedsUpgrade " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
    }
}
