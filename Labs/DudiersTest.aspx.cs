    using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace BoardHunt.Labs
{
    public partial class DudiersTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Click button to Submit TextBox";
            if (!Page.IsPostBack)
            {
                Label1.Text = "Enter text in text box";
                TextBox1.Text = ".. Then Click Button";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                        //Connect to DB	
            String strSQL;
            String myConnectString;

            //Formulate connect string to DB
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "SELECT count(*) FROM tblUser";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                myConnection.Open();

                SqlDataReader objReader = null;
                objReader = objCommand.ExecuteReader();

                if (objReader.Read() == true)
                {
                    Label1.Text = objReader[0].ToString();
                    Label1.Text += " users registered.";
                }
                else
                {
                    Label1.Text = "Unable to Connect";
                }
            }
            catch
            {
            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}
