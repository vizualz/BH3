using ASPSnippets.FaceBookAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HelperFunctions
/// </summary>

namespace BusinessLogic
{
    public class FaceBookUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
    }

    public static class HelperFunctions
    {
        static string myConnStr;

        public static bool FaceBookLogin(FaceBookUser faceBookUser, System.Web.SessionState.HttpSessionState Session)
        {
            myConnStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

            SqlConnection myConn = new SqlConnection(myConnStr);

            int nUserID = 0;

            try
            {
                bool user_Registered = true;

                string SQLstr = "SELECT iD FROM tblUser WHERE txtEmail ='" + faceBookUser.Email + "' AND IsFacebookUser = 1";
                
                SqlDataReader rdr = null;
                SqlCommand objSQLCommand = new SqlCommand(SQLstr, myConn);
                myConn.Open();
                rdr = objSQLCommand.ExecuteReader();
                
                if (rdr.Read())
                {
                    nUserID = Convert.ToInt32(rdr["iD"]);
                    user_Registered = true;
                }
                else
                {
                    nUserID = 0;
                    user_Registered = false;
                }

                myConn.Close();

                if (user_Registered)
                {
                    Session["userId"] = nUserID;
                    Session["LoggedIn"] = "Yes";
                    Session["EmailId"] = faceBookUser.Email;
                    Session["acctType"] = 1;

                    return true;
                }
                else
                {
                    // Register User
                    string strSQL = "INSERT INTO tblUser (txtFullName, txtPassword, txtEmail, dCreateDate, iEntryCount, IsFacebookUser)";
                    strSQL += " VALUES ('" + faceBookUser.Name + "', 'FaceBook','" + faceBookUser.Email + "', '" + DateTime.Now + "'," + (int)0 + ", 1); SELECT SCOPE_IDENTITY();";

                    SqlCommand objCommand = new SqlCommand(strSQL, myConn);
                    myConn.Open();
                    nUserID = Convert.ToInt32(objCommand.ExecuteScalar());
                    myConn.Close();

                    Session["userId"] = nUserID;
                    Session["LoggedIn"] = "Yes";
                    Session["EmailId"] = faceBookUser.Email;
                    Session["acctType"] = 1;

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }

        public static void FaceBookLogout(System.Web.SessionState.HttpSessionState Session)
        {
            try
            {
                if (Session["FaceBookCode"] != null)
                {
                    string FacebookCode = Convert.ToString(Session["FaceBookCode"]);
                    if (!string.IsNullOrWhiteSpace(FacebookCode))
                    {
                        Session["FaceBookCode"] = null;
                        Session["LoggedIn"] = "No";
                        FaceBookConnect.Logout(FacebookCode);
                    }                    
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}