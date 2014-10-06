using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DALLayer;

namespace BoardHunt.Qna
{
    public partial class QDetails : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

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

            //this.imgBtnNo.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnNo_Click);
            //this.imgBtnYes.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnYes_Click);
            //this.imgLogin.Click += new System.Web.UI.ImageClickEventHandler(this.imgLogin_Click);
            //this.imgNewUser.Click += new System.Web.UI.ImageClickEventHandler(this.imgNewUser_Click);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            //get user's id if they're logged in
            hndUserId.Value = "-1";
            if (HttpContext.Current.Session["LoggedIn"].ToString() == "Yes")
            {
                hndUserId.Value = Session["UserId"].ToString();
                btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Type in your answer first.');event.returnValue=false;return false;}else{return true;}");
                pnlLoginMsg.Visible = false;
                lblLogin.Visible = false;
            }
            else
            {
                lblLogin.Text = "<span class='midgrey10'><a class='ltgreen_orange10' id='toggle3' href='#login_spot'>Login</a> to answer or vote.&nbsp;<span class='Tips1' title='Ask-a-Pro::Login required to prevent abuse'>Why?</span>&nbsp;";
            }

            if (!Page.IsPostBack)
            {

                //init menu links
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                pnlFilter.Visible = false;
                //hdnQId.Value = Request.QueryString["q"].ToString();

                string[] arString;
                arString = Request.QueryString.GetValues("q");
                if (arString != null)
                {
                    hdnQId.Value = HttpUtility.UrlDecode(arString[0].ToString());
                    arString[0] = string.Empty;
                }
                else
                {
                    //default to surfing
                    hdnQId.Value = "-1";
                }

                BindData();
                LoadAnswers();
            }
        }
/*
 */
        protected void BindData()
        {
           
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Select * from tblBlog WHERE iD = (SELECT MAX(iD) FROM tblBlog WHERE publish = 'Y')

             //query item and user details for entry
            strSQL = @"SELECT q.Cat, q.status, q.createDate, q.CloseDate, q.PublishFlg, q.Question, q.iUser, q.txtTags, q.iViews, q.NotifyFlg,  
                        u.iD, u.txtEmail
                        FROM Questions q INNER JOIN tblUser u ON q.iUser = u.iD";
            
            if (hdnQId.Value == "-1")
                strSQL += " WHERE q.QiD = (SELECT MAX(QiD) FROM Questions)";
            else
                strSQL += " WHERE q.QiD = '" + hdnQId.Value + "'";

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    lblQuestion.Text = dbManager.DataReader["Question"].ToString();
                    lblDateData.Text = String.Format("{0:MM/dd}", dbManager.DataReader["createDate"]);
                    lnkEmailData.Text = ParseEmail(dbManager.DataReader["txtEmail"]);
                    lnkEmailData.CommandArgument = dbManager.DataReader["txtEmail"].ToString();
                    lblTags.Text = dbManager.DataReader["txtTags"].ToString();
                    lblViews.Text = dbManager.DataReader["iViews"].ToString();
                    hdnNotifyEmail.Value = dbManager.DataReader["NotifyFlg"].ToString();
                }
                else
                {
                    lblMessage.Text = "Error!";
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:QDetails:BindData:Msg: " + ex.Message);
                lblStatus.Text = "Error Loading";
                return;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            lblViews.Text = incPageViewCount(lblViews.Text);
        }

/*
*/
        public void LoadAnswers()
        {

            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //build query
            if (hndUserId.Value == "-1")//not logged in
            {
                strSQL = @"SELECT a.dCreateDate, a.Answer, a.iUser, a.VoteY, a.VoteN, a.iD, a.QuestId, a.AbuseFlg, u.txtEmail, u.txtUserName, u.userDir, u.profilePic, -1 as ResponseId  
                           FROM Answers a
                           INNER JOIN tblUser u ON a.iUser = u.iD
                           WHERE QuestId = '" + hdnQId.Value + "'";
            }
            else //logged in
            {
                strSQL = @"SELECT a.dCreateDate, a.iD, a.Answer, a.iUser, a.VoteY, a.VoteN, a.QuestId, u.txtEmail, a.AbuseFlg, u.txtEmail, u.txtUserName, u.userDir, u.profilePic
                             , r.iD as ResponseId 
                                       FROM Answers a
                                       LEFT JOIN tblUserResponse r ON a.iD = r.AnswerId AND r.userId ='" +  hndUserId.Value + "'";
                strSQL += @"JOIN tblUser u ON a.iUser = u.iD
                                       WHERE a.QuestId='" + hdnQId.Value + "'";
            }

            //Declare Dataset
            DataSet dsItems = new DataSet();

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                int listCount = dsItems.Tables[0].Rows.Count;

                if (listCount > 0)
                {
                    dlCommentList.DataBind();

                    lblCommentCount.Text = (listCount == 1) ? listCount.ToString() + " Answer" : listCount.ToString() + " Answers";
                }
                else
                {
                    lblCommentCount.Text = "Be the first answer!";
                    lblCommentCount.CssClass = "ltgreen14b";
                }

                dlCommentList.DataSource = dsItems;
                dlCommentList.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in AnswerList: " + ex.Message);
            }

            finally
            {
                dbManager.Close();
                dbManager.Dispose();
                dsItems = null;
            }

            //Always show comment box. Disable if not logged in
            pnlCommentBox.Visible = true;
            if (Session["LoggedIn"].ToString() == "No")
            {
                pnlLoginMsg.Visible = true;
                pnlLogin.Visible = true;
                txtComment.Enabled = false;
                btnPostComment.Enabled = false;
            }
            else
            {
                pnlLoginMsg.Visible = false;
                pnlLogin.Visible = false;
                txtComment.Enabled = true;
                btnPostComment.Enabled = true;
            }

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
/*
 */
        protected void btnPostComment_Click(object sender, EventArgs e)
        {
            
            //add this entry into the favorites table
            string strSQL;
            string strUserId;
            
            //check login status
            strUserId = "-1";
            if (Session["LoggedIn"].ToString() == "Yes")
            {
                strUserId = Session["userId"].ToString();
            }
            else
            {
                lblMessage.Text = "LOGIN FIRST!";
            }
 
            //check for an empty comment
            //TODO: move to js
            if (txtComment.Text.Length <= 0)
            {
                txtComment.BorderColor = Color.Red;
                return;
            }

            if (chkNotify.Checked == true)
                AddUserToENotifyList();

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            if (txtComment.Text.Length > 1000)
                txtComment.Text = txtComment.Text.Substring(0, 1000);

            //Build SQL
            strSQL = "INSERT INTO Answers (dCreateDate, PublishFlg, Answer, iUser, QuestId, AbuseFlg, VoteY, VoteN)";
            strSQL += "VALUES ('" + DateTime.Now + "','1','" + Global.CheckString(txtComment.Text) + "','";
            strSQL += Convert.ToInt32(strUserId) + "','" + hdnQId.Value + "','0','0','0')";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);

                //clear comment box
                txtComment.Text = string.Empty;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:QDetails:PostAnswer:Msg: " + ex.Message);
                classes.Email.SendErrorEmail("Error:QDetails:PostAnswer:Msg: " + ex.Message);
                return;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            if (hdnNotifyEmail.Value == "1")
            {
                //0: url; 1: response text; 2: username

                string[] eLinkArr = new string[3];
                eLinkArr[0] = Request.Url.ToString();
                eLinkArr[1] = Global.CheckString(txtComment.Text);
                eLinkArr[2] = Session["userName"].ToString();

                //get bcc list
                strSQL = @"SELECT n.iUserId, u.txtEmail FROM tblNotify n 
                    INNER JOIN tblUser u ON n.iUserId = u.iD
                    WHERE iQuestion ='" + hdnQId.Value + "'";
                
                try
                {
                    dbManager.Open();
                    dbManager.ExecuteReader(CommandType.Text, strSQL);

                    //loop reader into array then pass to email
                    ArrayList alBccEmails = new ArrayList();
                    while (dbManager.DataReader.Read())
                    {
                        alBccEmails.Add(dbManager.DataReader["txtEmail"]);
                    }
                    classes.Email.SendEmailBccArry("Your question was answered on Boardhunt", lnkEmailData.CommandArgument, classes.Email.MSG_QUESTION_ANSWERED, eLinkArr, alBccEmails);


                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorRoutine(false, "QDetails:btnPostComment:Error: " + ex.Message);
                    classes.Email.SendErrorEmail("QDetails:btnPostComment:Error: " + ex.Message);
                }
                finally
                {
                    dbManager.Close();
                    dbManager.Dispose();
                }
            }
            
            //Reload the answers
            LoadAnswers();

        }
/*
 */
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            classes.Login clsLogin = new classes.Login();
            if (clsLogin.DoLogin(txtUsername.Text, txtPassword.Text, true, false))
            {

                pnlLoginMsg.Visible = false;
                pnlLogin.Visible = false;

                dlCommentList.Visible = true;
                pnlCommentBox.Visible = true;

                hndUserId.Value = Session["UserId"].ToString();
                btnPostComment.Attributes.Add("OnClick", "if(CheckComment()==false){alert('Type in your answer first.');event.returnValue=false;return false;}else{return true;}");

                //Get text for login links
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                lblLogin.Text = string.Empty;

            }
            //login failed 
            else
            {
                //TODO: display correct failure message
                lblMessage.Text = "Login Failed.  Please try again.";
            }
            LoadAnswers();
        }
/*
 * Increment the PageViewCount for the entry.  The value returned will be the display value
 */
        public string incPageViewCount(string cnt)
        {
            //get the request URL
            string tmpURL = Request.Url.ToString();

            //if it already exists then we know we've been here so don't increment
            if (Session[tmpURL] != null)
                return cnt;

            string strSQL;
            int retval = 0;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //cnt and iPageViewCount should be equal - do we need to check?
            if (Convert.ToInt32(cnt) < (int)1)
            {
                strSQL = "UPDATE Questions SET iViews = 1 WHERE QiD = '" + Request.QueryString["q"] + "'";
            }
            else
            {
                strSQL = "UPDATE Questions SET iViews = iViews + 1 WHERE QiD = '" + Request.QueryString["q"] + "'";
            }

            try
            {
                dbManager.Open();

                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                Session.Add(Request.Url.ToString(), Request.Url.ToString());
                retval = Convert.ToInt32(cnt) + 1;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in PageViewCount processing: " + ex.Message);
                lblStatus.Text = "Error!";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            return retval.ToString();
        }
/*
 */ 
        protected void AddVote(int btnFlag, string AiD)
        {

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //ErrorLog.ErrorRoutine(false, "src: " + btnFlag + " AiD: " + AiD + " QId: " + hdnQId.Value + " UId: " + Session["userId"].ToString());

            dbManager.CreateParameters(4);

            dbManager.AddParameters(0, "@iVal", btnFlag.ToString(), ParameterDirection.Input);
            dbManager.AddParameters(1, "@QiD", hdnQId.Value,ParameterDirection.Input);
            dbManager.AddParameters(2, "@AiD", AiD, ParameterDirection.Input);
            dbManager.AddParameters(3, "@UiD", Session["userId"].ToString(), ParameterDirection.Input);

            int rtnVal;

            try
            {
                dbManager.Open();
                rtnVal = dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddVoteLogResponse");
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in AddVote: " + ex.Message);
                lblStatus.Text = "Error!";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            LoadAnswers();
        }
/*
 */
        protected void FlagAbuse(string val, string id)
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE Answers SET AbuseFlg = 1 WHERE iD = '" + id + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                string strURL = System.Configuration.ConfigurationSettings.AppSettings["serverURL"] + "/Qna/Qdetails.aspx?q=" + val;
                classes.Email.SendEmail("ATP Answer Flagged", "info@boardhunt.com", strURL + " - AnswerId: " + id);
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error in FlagAbuse: " + ex.Message);
                lblStatus.Text = "Error!";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            LoadAnswers();        
        }
/**
 */
        public void dlCommentList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            // null = OK to vote
            // -1 = user not logged in so disable
            // > 0 = user logged in and voted so disable
            
            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {

                LinkButton lnkAbuse = (LinkButton)e.Item.FindControl("lnkFlagAbuse");

                HiddenField hdnAbuseFlg = (HiddenField)e.Item.FindControl("hdnAbuseFlg");
                HiddenField hdnAllowVoting = (HiddenField)e.Item.FindControl("hdnAllowVoting");

                //Abuse
                if (hdnAbuseFlg != null)
                {

                    if (hdnAbuseFlg.Value == "1")
                    {
                        lnkAbuse.Attributes.Add("OnClick","return false;");
                        lnkAbuse.Attributes.Add("href", "#");
                        lnkAbuse.Text = "Flagged";
                        lnkAbuse.ForeColor = Color.Red;
                    }
                    else
                    {
                        lnkAbuse.Attributes.Add("OnClick", "if(confirm('Are you sure you want to flag this answer?  Click OK only if it contains foul or abusive language.')==false){event.returnValue=false;return false;}else{return true;}");
                    }
                }

                //Voting logic
                if (hdnAllowVoting != null)
                {
                    ImageButton imgBtnYes = (ImageButton)e.Item.FindControl("imgBtnYes");
                    ImageButton imgBtnNo = (ImageButton)e.Item.FindControl("imgBtnNo");

                    if (hndUserId.Value == "-1")
                    {
                        imgBtnYes.Attributes.Add("OnClick", "alert('Login first to vote');event.returnValue=false;return false;");
                        imgBtnNo.Attributes.Add("OnClick", "alert('Login first to vote');event.returnValue=false;return false;");
                    }
                }
            }
        }
/*
 */
        protected void Fire_Item(object src, CommandEventArgs e)
        {
            //ImageButton btn = (ImageButton)src;
            //ErrorLog.ErrorRoutine(false, "dlCommentList_Click: " + btn.ID);

        }
/*
 */
        protected void dlCommentList_Click(object src, CommandEventArgs e)
        {
            ImageButton btn = (ImageButton)src;
        }

/*
 */
        protected void lnkFlagAbuse_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            FlagAbuse(lnkBtn.CommandArgument, lnkBtn.CommandName);
        }
/*
 */ 
        protected void imgBtnYes_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            AddVote(1, btn.CommandArgument);
        }
/*
 */ 
        protected void imgBtnNo_Click(object sender, EventArgs e)
        {
          
            ImageButton btn = (ImageButton)sender;
            AddVote(0, btn.CommandArgument);
        }
/*
 */ 
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {

            Global.NavigatePage(lnkSignIn.Text);

        }
/*
 */ 
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);
        }
/*
 */ 
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../post.aspx");

        }
/*
 */
        public bool GetEnabledStatus(object objStat)
        {
            // null = OK to vote
            // -1 = user not logged in so disable
            // > 0 = user logged in and voted so disable

            //ErrorLog.ErrorRoutine(false, "GetEnabledStatus:GetEnabledStatus:ObjStat.ToString()" + objStat.ToString());

            if (objStat == null) 
                return true;

            if (objStat.ToString() == string.Empty)
                return true;

            return false;

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
        public string FormatPicPath(object oDir, object oPic)
        {
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            if (oPic.ToString().Length > 1)
                return serverURL + "/users/" + oDir.ToString() + oPic.ToString();
            return serverURL + "/images/nopic32.jpg";

        } 
        
/*
 */
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        public void AddUserToENotifyList()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "INSERT INTO tblNotify (iQuestion, iUserId, iLevel)";
            strSQL += " SELECT DISTINCT '" + hdnQId.Value + "','" + Session["userId"].ToString() + "','0'";
            strSQL += " FROM tblNotify";
            strSQL += " WHERE NOT EXISTS (SELECT * FROM tblNotify WHERE iEntry='" + hdnQId.Value + "' AND iUserId='" + Session["userId"].ToString() + "')";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "I_D:AddUserToENotifyList:Error:" + ex.Message);
                classes.Email.SendErrorEmail("I_D:AddUserToENotifyList:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
 
    }
}
