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
using DALLayer;

namespace BoardHunt.include.Controls
{
    public partial class LBlogs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadControl();
        }
/*
 */
        public void LoadControl()
        {

            //declare variables	
            string strSQL;    //Moved to global

            //Create connect string
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            string owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];

            //build SQL
            owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];
            strSQL = @"SELECT TOP 3 " + owner + @".getBlogCommentCount(e.id) as COUNTER, e.id, e.blog_dt, e.title, e.cat, e.iUser, e.blog, e.txtImgPath1, e.txtImgPath2, e.iPageViewCount, u.userDir 
                        FROM tblBlog e
                        INNER JOIN tblUser u
                        on e.iUser = u.id
                        WHERE e.publish ='Y'
                        ORDER BY e.blog_dt DESC";

            //Declare Dataset
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                //Get result count for paging
                int listCount = dsItems.Tables[0].Rows.Count;

                //bind to DataList control
                dlLBlogs.DataSource = dsItems.Tables[0].DefaultView;
                dlLBlogs.DataBind();

            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "SQL: " + strSQL);
                //lblStatus.Text = "Error: " + ex.Message;
            }

            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }
/*
*/
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }
/*
 */
        public void JumpTo(object src, CommandEventArgs e)
        {
            Response.Redirect("Blog/BlogDetails.aspx?" + "iD=" + e.CommandArgument);
        }
/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, object oVal)
        {
           
            //get cutoff length
            int cLen = Convert.ToInt32(oVal);

            //get string
            string sChunk = oChunk.ToString();

            if (sChunk.Length < cLen)
                return sChunk;

            int n = cLen;

            //check if substring @ cLen pos. is char or whitespace
            if (sChunk.Substring(n, 1).ToString() != " ")
            {
                do
                {
                    //TODO: look into this
                    //if (n >= cLength)
                    //return txtChunk;

                    n++;
                    if (n == sChunk.Length) 
                        break;

                    if (sChunk.Substring(n, 1).ToString() == " ")
                        break;

                } while (n < sChunk.Length);
            }

            //remove characters after cLen chars.
            if (sChunk.Length > n)
                sChunk = sChunk.Remove(n, sChunk.Length - n) + "...";

            return sChunk;

            //PAD with HTML white space here
            //char c = '#';
            //sChunk = oChunk.ToString().PadRight(15, c);
            //return Global.ReplaceEx(sChunk, "#", @"&nbsp;");
        }
 
    }
}