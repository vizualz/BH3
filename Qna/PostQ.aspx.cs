/*
 *      File: PostQ.aspx
 *      
 *      Page 1 of a wizard that collects input from users wanting to ask a question.
 * 
 *      @author: PRM
 * 
 * 
*/
using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DALLayer;

namespace BoardHunt.Qna
{
	/// <summary>
	/// Summary description for post.
	/// </summary>
	public partial class PostQ : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;

		private void Page_Load(object sender, System.EventArgs e)
		{
            
            // Put user code to initialize the page here
			Global.AuthenticateUser();

            // Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            //extra
            imgNext.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Type in a question first.');event.returnValue=false;return false;}else{return true;}");

			if (!Page.IsPostBack)
			{
                //check for Edit-New
                if (Session["QItem"] != null)
                {
                    //Edit new
                    //TODO: verify tQ.EditMode = true
                    hdnEditNew.Value = "1";
                    LoadForEdit();
                    return;
                }
                else
                {
                    //Check for New or Update
                    string[] strArray;

                    strArray = Request.QueryString.GetValues("q");
                    if (strArray != null)
                    {
                        hdnQId.Value = HttpUtility.UrlDecode(strArray[0].ToString());
                        strArray[0] = string.Empty;

                        strArray = Request.QueryString.GetValues("uId");
                        if (strArray != null)
                        {
                            hdnUId.Value = HttpUtility.UrlDecode(strArray[0].ToString());
                            strArray[0] = string.Empty;
                            
                            hdnEditNew.Value = "-1";
                            BindDataForUpdate(hdnQId.Value, hdnUId.Value);
                        }
                        else
                        {
                            //shouldn't happen 
                            lblMessage.Text = "Error big time.";
                        }


                    }
                    //NEW Question
                    else
                    {

                        hdnEditNew.Value = "1";
                        chkNotify.Checked = true;
                    }
                }
               
			}
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
			//this.imgNext.Click += new System.Web.UI.ImageClickEventHandler(this.imgNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


/**
*/
        public void BindDataForUpdate(string qVal, string uVal)
        {
            //TODO: Check to see that id's match; This ensure that only users can edit their own questions
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"SELECT q.CreateDate, q.Question, q.txtTags, q.NotifyFlg 
                       FROM Questions q WHERE QiD = '" + hdnQId.Value + "'";

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    //fill controls
                    txtQuestion.Text = dbManager.DataReader["question"].ToString();
                    txtTags.Text = dbManager.DataReader["txtTags"].ToString();

                    if (dbManager.DataReader["NotifyFlg"].ToString() == "1")
                    {
                        chkNotify.Checked = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Error reading data";
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:PostQ:BindDataForUpdate:Msg: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/**
*/  
		//public void BindData()
        //{
        //    //declare variables	
        //    string strSQL;
        //    string myConnectString;

        //    //Create connect string
        //    myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
        //    SqlConnection myConnection = new SqlConnection(myConnectString);

        //    try
        //    {

        //        //Build SQL statement
        //        strSQL = "SELECT * FROM LK_QCat";

        //        // Read sample item info from SQL into a DataSet
        //        DataSet dsItems = new DataSet();

        //        SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

        //        objAdapter.TableMappings.Add("Table", "tblQCat");

        //        objAdapter.Fill(dsItems);

        //        //cboCategory.DataSource = dsItems;
        //        //cboCategory.DataMember = "tblQCat";
        //        //cboCategory.DataTextField = "Category";
        //        //cboCategory.DataValueField = "iD";
        //        //cboCategory.DataBind();
        //        //cboCategory.SelectedIndex = (int)0;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.ErrorRoutine(false, "PostQ:Error getting category values: " + ex.Message);
        //    }
        //    finally
        //    {
        //        myConnection.Close();
        //    }
        //}
        
/**
*/
        protected void LoadForEdit()
        {
            classes.Question tQuestion = new classes.Question();
            
            tQuestion = (classes.Question)Session["QItem"];
            txtQuestion.Text = tQuestion.StrQuestion;
            txtTags.Text = tQuestion.Tags;
            if (tQuestion.NotifyFlg == 1)
            {
                chkNotify.Checked = true;    
            }

        }
/**
*/
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignIn.Text);
        }
/**
*/
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);
        }
/**
*/
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../post.aspx",false);
            Session["QItem"] = null;
        }
/**
*/
        //private void lnkSell_Click(object sender, System.EventArgs e)
        //{
        //    Global.NavigatePage(lnkSignIn.Text);
        //}
/*
 */ 
        protected void imgNext_Click1(object sender, ImageClickEventArgs e)
        {
            if (txtQuestion.Text.Length < 1)
            {
                return;
            }

            classes.Question tmpQ = new classes.Question();

            //tmpQ.Category = Convert.ToInt32(cboCategory.SelectedItem.Value);
            
            string tmpString;
            tmpString = txtQuestion.Text;

            //Add question mark if missing at the end
            if (tmpString.LastIndexOf("?", tmpString.Length) == (int)-1)
            tmpString += "?";

            //remove characters after 200.
            if (tmpString.Length > 200)
            {
                tmpString = tmpString.Remove(200, tmpString.Length - 200);
            }

            tmpQ.StrQuestion = tmpString;

            //space or question mark?
            tmpQ.Tags = txtTags.Text;


            //reset the edit mode
            tmpQ.EditMode = false;

            //get userId
            tmpQ.User = Convert.ToInt32(Session["userId"].ToString());

            //If updating a Question...we'll need the ID
            if (hdnEditNew.Value != "1" && hdnQId.Value != "-1")
            {
                //assign update id
                tmpQ.QId = Convert.ToInt32(hdnQId.Value);
            }
            else
            {
                tmpQ.QId = (int)-1;
            }

            //Save object to session variable
            Session["QItem"] = tmpQ;

            //to next wizard page
            Response.Redirect("PreviewQ.aspx", false);
        }

	}
}
