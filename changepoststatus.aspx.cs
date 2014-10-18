
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
using System.Text;
using DALLayer;
using System.Security.Cryptography;
using System.IO;
namespace BoardHunt
{
    public partial class changepoststatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string userid = Decrypt(HttpUtility.UrlDecode(Request.QueryString["uid"]));
                string boardid = Decrypt(HttpUtility.UrlDecode(Request.QueryString["bid"]));
                String strSQL;
                String myConnectString;
                if (boardid != null)
                {
                    //Formulate connect string to DB
                    myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;
                    //Build SQL
                    strSQL = "Update tblEntry set iStatus = 3 WHERE iUser='" + Convert.ToInt32(userid.Trim()) + "' and iD= '" + Convert.ToInt32(boardid.Trim()) + "'";

                    SqlConnection myConnection = new SqlConnection(myConnectString);
                    try
                    {
                        myConnection.Open();

                        SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                        objCommand.ExecuteNonQuery();
                        lblmsg.Text = "Thanks! You board was removed.";
                    }
                    catch (Exception ex)
                    {
                        lblmsg.Text = "or Sorry - that board was not found";
                    }
                }
                else
                {
                    Response.Redirect("http://www.boardhunt.com/index.aspx");
                }
            }
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}