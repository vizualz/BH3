using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using DALLayer;

namespace BoardHunt.classes
{
    public class Login
    {
        //=======================================
        //Private Class Data Members
        //=======================================        
        //Data Members: 
        private int notifyFlg;          //e-mail notification

        //constructor
        public Login()
        {

        }
/*
 */ 
        public bool DoLogin(string username, string password, bool hashit, bool overRide)
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            //dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

//            strSQL = @"SELECT u.sashimi, u.txtUserName, u.salt, u.txtPassword, u.iD, u.txtEmail, u.iAcctType, u.iMerchantType, u.blog_flg, u.userDir
//                        FROM tblUser u WHERE txtEmail='" + username + "'";

 strSQL = @"SELECT u.sashimi, u.txtUserName, u.salt, u.txtPassword, u.iD, u.txtEmail, u.iAcctType, u.iMerchantType, u.blog_flg, u.userDir, 
            (Select count(*) from tblServices s where (s.iServiceVal = 6 or s.iServiceVal = 7) and iuserId = u.id and iStatus = 1 ) as isPro
                        FROM tblUser u WHERE txtEmail='" + username + "'";
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read() == true)
                {
                    string pwdToMatch;
                    string txtPass = dbManager.DataReader["txtPassword"].ToString();
                    bool bLoginSuccess = false;

                    if (dbManager.DataReader["sashimi"].ToString() == "1" && overRide == false)
                    {
                        if (hashit)
                        {
                            //get hasher pointer
                            BoardHunt.classes.hasher pHash = new BoardHunt.classes.hasher();
                            //get salt from db
                            string saltVal = dbManager.DataReader["salt"].ToString();

                            //compute hash from user input
                            byte[] tmpByte;
                            tmpByte = pHash.getHash(saltVal, password);
                            pwdToMatch = Convert.ToBase64String(tmpByte);
                        }
                        else
                        {
                            //ErrorLog.ErrorRoutine(false, "NotHashing");
                            pwdToMatch = password;
                        }

                        //check for match
                        if (pwdToMatch == txtPass)
                        {
                            bLoginSuccess = true;
                        }
                    }
                    //old algorithm; match with no hash
                    else
                    {
                        if (dbManager.DataReader["txtPassword"].ToString() == password)
                        {
                            bLoginSuccess = true;
                        }
                    }

                    //check password match
                    if (bLoginSuccess || overRide)
                    {

                        // Successful login, save iD for user events while logged in
                        HttpContext.Current.Session["LoggedIn"] = "Yes";
                        HttpContext.Current.Session["userId"] = dbManager.DataReader["iD"].ToString();
                        HttpContext.Current.Session["EmailId"] = dbManager.DataReader["txtEmail"].ToString();
                        HttpContext.Current.Session["acctType"] = dbManager.DataReader["iAcctType"].ToString();
                        HttpContext.Current.Session["MerchantType"] = dbManager.DataReader["iMerchantType"].ToString();
                        HttpContext.Current.Session["BlogFlg"] = dbManager.DataReader["blog_flg"].ToString();
                        HttpContext.Current.Session["userDir"] = dbManager.DataReader["userDir"].ToString();
                        HttpContext.Current.Session["userName"] = dbManager.DataReader["txtUserName"].ToString();
                        if (dbManager.DataReader["txtUserName"].ToString() == string.Empty)
                            HttpContext.Current.Session["userName"] = Global.ParseEmail(dbManager.DataReader["txtEmail"]);

                        //check for pro 
                        if (Convert.ToInt32(dbManager.DataReader["isPro"].ToString()) > 0)
                            HttpContext.Current.Session["isPro"] = 1;
                        else
                            HttpContext.Current.Session["isPro"] = 0;

                        return true;

                    }
                    //login failed 
                    else
                    {
                        return false;
                    }
                }
                else//couldn't read - bad username
                {
                    ErrorLog.ErrorRoutine(false, "No record of user name");
                    return false;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ClsLogin:DoLogin:Error " + ex.Message);
                //send error email
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            
        }

        //Accessor Methods
        public int NotifyFlg
        {
            get { return notifyFlg; }
            set { notifyFlg = value; }
        }
    
    }


}
