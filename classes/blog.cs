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

namespace BoardHunt.classes
{

    public class Blog
    {
        //=======================================
        //Private Class Data Members
        //=======================================        
        //Data Members: 
        private int user;              //User Id
        private int blogId;            //Blog Id
        private DateTime blogDate;     //Blog Date
        private String myBlog;         //Blog
        private int blogCat;           //BoardCategory
        private string title;          //Blog Title
        private string imgPath1;       //FilePath 1
        private string imgPath2;       //FilePath 2
        private bool editMode;         //Edit 

        //constructor
        public Blog()
        {
            BlogCat = (int)-1;
            Title = "";
            ImgPath1 = "";      //init img paths with
            ImgPath2 = "";
            editMode = false;   //currently using for post/edit
            //BlogDate = DateTime.Now;

        }

        //====================================================================
        //Properties
        //====================================================================
        public int User
        {
            get { return user; }
            set { user = value; }
        }

        public int BlogId
        {
            get { return blogId; }
            set { blogId = value; }
        }

        public DateTime BlogDate
        {
            get { return blogDate; }
            set { blogDate = value; }
        }

        public string MyBlog
        {
            get { return myBlog; }
            set { myBlog = value; }
        }

        public int BlogCat
        {
            get { return blogCat; }
            set { blogCat = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }

        }

        public string ImgPath1
        {
            get { return imgPath1; }
            set { imgPath1 = value; }

        }

        public string ImgPath2
        {
            get { return imgPath2; }
            set { imgPath2 = value; }

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
        public bool SaveItem()
       {
            string myConnectString;
            string strSQL = "Zilch";

            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            ErrorLog.ErrorRoutine(false, "CatValPre-Insert: " + BlogCat);
            
            //Build SQL

            strSQL = "INSERT INTO tblBlog (iUser,blog_dt,blog,cat,title,txtImgPath1, txtImgPath2)";
            strSQL += "VALUES ('" + User + "', '" + BlogDate + "', '" + MyBlog + "', '" + BlogCat + "', '" + Title + "', '" + ImgPath1 + "', '" + ImgPath2 + "')";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {

                myConnection.Open();
 
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ErrMessage: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
                ErrorLog.ErrorRoutine(false, "Error Saving");
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }
/*
 */
        public bool PublishBlog(string id, string pubVal)
        {

            string myConnectString;
            string strSQL = "";

            strSQL = "UPDATE tblBlog SET publish ='" + pubVal + "' where iD = '" + id + "'";
            //buil sql for imgs

            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error Publishing: " + ex.Message);
                return false;
            }

            finally
            {
                myConnection.Close();
            }

        }



        /***********************************
         * Updates a blog in the db
        ***********************************/
        public bool UpdateItem()
        {

            string myConnectString;
            string strSQL = "";

            strSQL = "UPDATE tblBlog SET Title ='" + Title + "',Blog = '" + MyBlog + "'";
            //buil sql for imgs

            //can't do this
            if (ImgPath1 != "KEEP") { strSQL += ",txtImgPath1 = '" + ImgPath1 + "'"; }
            if (ImgPath2 != "KEEP") { strSQL += ",txtImgPath2 = '" + ImgPath2 + "'"; }

            //Build SQL for category specific
            strSQL += "WHERE iD = '" + BlogId + "'";


            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Blog.cs:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Blog.cs:Error: " + ex.InnerException);
                return false;
            }

            finally
            {
                myConnection.Close();
            }
        }
    }
}
