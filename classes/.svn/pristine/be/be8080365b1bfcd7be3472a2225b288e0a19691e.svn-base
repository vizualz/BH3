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
    public class Coupon : BaseItem
    {
        private int liveCount;
        private int initCount;
        private int smsPkgCnt;

        private string title;
        private string cCode;
        private int useTempDir;
        private int status; // 0:coupon not active ; 1 = coupon active

        private bool useDefaultImg;

        //====================================================================
        //Constructor
        //====================================================================
        public Coupon()
        {
            useTempDir = 1;
            EntryId = -1;
            smsPkgCnt = 0;
            Expired = DateTime.MinValue;
            status = 0;
            useDefaultImg = true;
        }
//////////////
//MEMBERS
/// /////////
        public bool UseDefaultImg
        {
            get { return useDefaultImg; }
            set { useDefaultImg = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int SmsPkgCnt
        {
            get { return smsPkgCnt; }
            set { smsPkgCnt = value; }
        }

        public int UseTempDir
        {
            get { return useTempDir; }
            set { useTempDir = value; }
        }

        public string CCode
        {
            get { return cCode; }
            set { cCode = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int LiveCount
        {
            get { return liveCount; }
            set { liveCount = value; }
        }

        public int InitCount
        {
            get { return initCount; }
            set { initCount = value; }
        }

        public bool UpdateCoupon()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblCoupon SET title='" + Title + "', body='" + Details + "', code='" + CCode + "', imgPath='" + ImgPath1 + "', CategoryId='" + Category + "'";
            
            if (Expired > DateTime.Now)
                strSQL += ", dExpire='" + Expired + "'";
            
            strSQL += " WHERE iD = '" + this.EntryId + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:UpdateCoupon:Error:" + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
                classes.Email.SendErrorEmail("Coupon Update Failed: " + this.EntryId);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        public bool PublishUpdate(string iD, bool pubVal)
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            string pVal = "0";
            if (pubVal)
                pVal = "1";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblCoupon SET iPublish='" + pVal + "'"; //, body='" + Details + "', code='" + CCode + "', imgPath='" + ImgPath1 + "', CategoryId='" + Category + "'";
            strSQL += " WHERE iD = '" + iD + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
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

        public static void Decrement(string iD)
        {
            //TODO: Add 0 logic to send email and decativate coupon on 0 credits

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"UPDATE tblCoupon SET smsLiveCnt = (smsLiveCnt - 1)
                        WHERE iD = '" + iD + "'";
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:Decrement:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupon:Decrement:Error:Id " + iD);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        public static bool ActivateCoupon(string id, bool trial)
        {
            int rtn;
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblCoupon SET iStatus = '1', ";

            if (!trial)
                strSQL += "smsLiveCnt = smsPkgCnt, ";
            else
                strSQL += "smsLiveCnt='20', smsPkgCnt='20', ";
            strSQL += "iPublish='1' WHERE iD ='" + id + "'";

            try
            {
                dbManager.Open();
                rtn = dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "clsCoupon:ActivateCoupon:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "clsCoupon:ActivateCoupon:Error: " + strSQL);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }         
        }


/*
 * Check Coupon and possible deactive it
 */ 
        public static bool InitDecrement(string iD)
        {
            //TODO: Add 0 logic to send email and decativate coupon on 0 credits

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"SELECT smsLiveCnt FROM tblCoupon WHERE iD = '" + iD + "'";
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    if (dbManager.DataReader["smsLiveCnt"].ToString() == "1")
                    {
                        //don't decrement, deactivate coupon, send email
                        Deactivate(iD, true);
                        return true;
                    }
                    else
                        Decrement(iD);
                    return true;
                }
                classes.Email.SendErrorEmail("Failed to read coupon on CheckCouponStatus");
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:Decrement:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupon:InitDecrement:Error:");
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public static void Deactivate(string cId, bool notify)
        {
            //TODO: Add 0 logic to send email and decativate coupon on 0 credits

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"UPDATE tblCoupon SET iStatus = 0, smsLiveCnt = 0, iPublish = 0
                        WHERE iD = '" + cId + "'";
            //TODO: update tblServices for the coupon?
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:Deactivate:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupon:Deactivate:Error: Failed to deactivate: " + cId);
                return;
                
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            //notify
            if (notify)
                EmailUserToRenew(cId);
               
        }

        public static void EmailUserToRenew(string iD)
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"SELECT c.iUser, c.title u.txtEmail FROM tblCoupon c
                       INNER JOIN tblUser u ON c.iUser = u.iD
                        WHERE c.iD = '" + iD + "'";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    string[] eLinkArr = new string[1];
                    eLinkArr[0] = dbManager.DataReader["title"].ToString();
                    classes.Email.SendEmail("Coupon Renewal", dbManager.DataReader["txtEmail"].ToString(), 7, eLinkArr);
                }
                return;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:EmailCouponRenewal:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupon:EmailCouponRenewal:Error:" + iD);
                return;

            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }  
        }

/*
 */ 
        public int SaveCoupon()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //(@Title, @Body, @Code, @SMSPkgCnt, 0, GETDATE(), @User, @ImgPath, 0, @DExpire, @Category);

           
            dbManager.CreateParameters(8);
            dbManager.AddParameters(0, "@Title", title);
            dbManager.AddParameters(1, "@Body", Details);
            dbManager.AddParameters(2, "@Code", CCode);
            dbManager.AddParameters(3, "@SMSPkgCnt", smsPkgCnt);
            dbManager.AddParameters(4, "@User", IUser);
            dbManager.AddParameters(5, "@ImgPath", ImgPath1);

            if (Expired == DateTime.MinValue)
                dbManager.AddParameters(6, "@DExpire", null);
            else
                dbManager.AddParameters(6, "@DExpire", Expired);
            
            
            dbManager.AddParameters(7, "@Category", Category);

            try
            {
                int iRet = 0;
                dbManager.Open();
                iRet = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.StoredProcedure, "spAddCoupon"));
                return iRet;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Coupon:SaveCoupon:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Coupon Save Failed");
                return -1;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
    }
}