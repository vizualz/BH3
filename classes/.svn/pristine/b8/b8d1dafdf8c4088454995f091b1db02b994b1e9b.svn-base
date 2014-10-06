using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DALLayer;

namespace BoardHunt.classes
{

    public class Question
    {
        //=======================================
        //Private Class Data Members
        //=======================================        
        //Data Members: 
        private int user;               //User Id
        private int qId;                //Question Id
        private DateTime createDate;    //Question Date
        private String strQuestion;     //Question
        private int category;               //Question Category
        private bool editMode;          //Editing flag
        private int status;             //Status: OK,Abuse,Closed
        private string tags;            //tags used for searching
        private int notifyFlg;          //e-mail notification


        //constructor
        public Question()
        {
            category = (int)-1;
            strQuestion = string.Empty;
            editMode = false;   //currently using for post/edit
            //BlogDate = DateTime.Now;
            qId = -1;

        }

        //====================================================================
        //Properties
        //====================================================================
        public int NotifyFlg
        {
            get { return notifyFlg; }
            set { notifyFlg = value; }
        }

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }
        
        public int User
        {
            get { return user; }
            set { user = value; }
        }

        public int QId
        {
            get { return qId; }
            set { qId = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        public string StrQuestion
        {
            get { return strQuestion; }
            set { strQuestion = value; }
        }

        public int Category
        {
            get { return category; }
            set { category = value; }
        }

         public bool EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }

        /// <summary> 
        /// Public Methods
        /// </summary>
        
        /***********************************
         * Saves an entries data in the db
        ***********************************/    
        public bool SaveNewItem()
       {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            
            //Build SQL
            strSQL = "INSERT INTO Questions (iUser,CreateDate,Question,Cat,Status,PublishFlg,txtTags)";
            strSQL += "VALUES ('" + User + "', '" + CreateDate + "', '" + strQuestion + "', '" + category + "', '" + (int)0 + "', '" + "N" + "', '" + tags + "')";

            try
            {

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error Message: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
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
        public bool UpdatePublishValue(string id, string pubVal)
        {

            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"UPDATE Questions SET PublishFlg = '" + pubVal + "' WHERE QiD = '" + id + "'";

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:QuestionsCls:PublishQuestion:Msg: " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            } 

        }



        /***********************************
         * Updates a Question in the db
        ***********************************/
        public bool UpdateItem()
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL
            strSQL = "UPDATE Questions SET Question='" + strQuestion + "',txtTags='" + tags + "',NotifyFlg='" + notifyFlg + "' WHERE QiD = '" + qId + "'";

            try
            {

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:UpdateQuestion: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
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
        public bool UpdateNotifyValue(string id, string notifyVal)
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"UPDATE Questions SET NotifyFlg = '" + notifyVal + "' WHERE QiD = '" + id + "'"; 

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:QuestionsCls:UpdateNotify:Msg: " + ex.Message);
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
