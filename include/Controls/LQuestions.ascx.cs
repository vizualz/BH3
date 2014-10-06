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
    public partial class LQuestions : System.Web.UI.UserControl
    {
        public void Page_Load(object sender, EventArgs e)
        {
            LoadQControl();
        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False. (*OLD notes)
        public void JumpTo(object src, CommandEventArgs e)
        {
            Response.Redirect("Qna/QDetails.aspx?" + "q=" + e.CommandArgument.ToString());
        }
/*
 */
        public void LoadQControl()
        {
            //declare variables	
            string strSQL;    //Moved to global

            //Create connect string
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            
            string owner = System.Configuration.ConfigurationSettings.AppSettings["Owner"];

//            @"SELECT DISTINCT " + owner + @".getQAnswerCount(q.QiD) as COUNTER, q.QiD, q.Cat, q.Status, q.CreateDate, q.CloseDate, q.PublishFlg, q.Question, q.iUser, q.iViews,
//                       u.iD, u.txtEmail
//                       FROM Questions q INNER JOIN tblUser u on q.iUser = u.iD";

            //build SQL
            strSQL = @"SELECT TOP 3 q.QiD,q.Question,q.iViews, u.txtEmail, u.txtUserName
                        FROM Questions q
                        INNER JOIN tblUser u on q.iUser = u.iD
                        ORDER BY q.CreateDate DESC"; 
                        //WHERE q.iViews = (SELECT MAX(iViews) FROM Questions)";

            //Declare Dataset
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);                

                //Get result count for paging
                int listCount = dsItems.Tables[0].Rows.Count;

                //bind to DataList control
                dlSpotLight.DataSource = dsItems.Tables[0].DefaultView;
                dlSpotLight.DataBind();
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ItemsGet:Error:Msg: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "SQL: " + strSQL);
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
       //Returns truncated string with configurable number of characters
       public string FormatDetails(object oChunk, int iVal)
       {
           return Global.FormatDetails(oChunk, iVal); 
       }
/*
*/
       public string ShowUser(object un, object em)
       {
           if ((un.ToString().Length > 1))
               return un.ToString();
           return ParseEmail(em);
       }
/*
*/
       public string ParseEmail(object em)
       {
           string[] arrStr;
           char[] splitter = { '@' };

           arrStr = em.ToString().Split(splitter);
           return arrStr[0];
       } 
    }
}