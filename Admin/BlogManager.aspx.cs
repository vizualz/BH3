using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace BoardHunt.Admin
{
    /// <summary>
    /// Summary description for search_results.
    /// </summary>
    public partial class BlogManager1 : System.Web.UI.Page
    {



        protected System.Web.UI.WebControls.HiddenField hdnCat;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton linkEdit;
        protected System.Web.UI.WebControls.CheckBox chkPublish;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            // Put user code to initialize the page here
            Global.AuthenticateUser();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                ErrorLog.ErrorRoutine(false, "Hack Attempt into BlogManager Page!");
                Response.Redirect("../UserMenu.aspx");
            }

            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            // Call the LoadData method to populate control,
            LoadData();

            Page.DataBind();

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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);

        }
        #endregion

        private void LoadData()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Formulate SQL
            strSQL = "SELECT * FROM tblBlog ORDER BY blog_dt DESC"; //WHERE iUser = '" + Session["userId"].ToString() + "' AND adType < 3 ORDER BY dCreateDate DESC";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();

            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            objAdapter.Fill(dsItems, "tblBlog");
            int listCount = dsItems.Tables["tblBlog"].Rows.Count;

            //Do we need to display the back and forward controls?
            if (listCount <= (int)15)
            {
                //If search yields no results, set message
                if (listCount == (int)0)
                {
                    lblNoResult.Text = "You currently have no entries.";
                    dlEntryList.Visible = false;
                }

                HidePaging();
            }

            lblCount.Text = "(" + listCount.ToString() + ")";

            // Populate the repeater control with the Items DataSet
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dsItems.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 15;

            objPds.CurrentPageIndex = CurrentPage;

            lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                + objPds.PageCount.ToString();

            // Disable Prev or Next buttons if necessary
            cmdPrev.Enabled = !objPds.IsFirstPage;
            cmdNext.Enabled = !objPds.IsLastPage;

            //bind to DataList control
            dlEntryList.DataSource = objPds;
            dlEntryList.DataBind();

            myConnection.Close();
        }


        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;   // default to showing the first page
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        public void cmdPrev_Click(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            LoadData();
        }

        public void cmdNext_Click(object sender, System.EventArgs e)
        {

            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadData();
        }

        public string VerifyImage(object imgPicPath)
        {

            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                return "images/s1x1.gif";
            }
            else
            {
                return "images/camera.gif";
            }

        }

        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }

        //Fired when user clicks the edit link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            Response.Redirect("../Blog/BlogEdit.aspx?" + "iD=" + e.CommandArgument.ToString() + "&iU=" + e.CommandName);
        }

        //Fired when user clicks the view link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
        public void ViewPage(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            Response.Redirect("../Blog/BlogDetails.aspx?" + "iD=" + e.CommandArgument.ToString() + "&iU=" + e.CommandName);
        }

        /*
         */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void UpdateToSold(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and unpdate the entry status to sold
            string connStr, strSQL;

            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Build SQL statement
            strSQL = string.Empty;  //"UPDATE tblEntry SET iStatus = '3' WHERE id='" + e.CommandArgument + "'";
            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                LoadData();
            }
            catch
            {
                lblMessage.Text = "SQL Error!<br>";
            }
            finally
            {
                //close
                myConnection.Close();
            }
        }

        /*
        */
        public void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {

                classes.Blog oBlog = new classes.Blog();

                if (dlEntryList.Items.Count > 0)
                {
                    foreach (DataListItem item in dlEntryList.Items)
                    {
                        CheckBox pubCheckBox = item.FindControl("chkPublish") as CheckBox;
                        if (pubCheckBox.Checked == true)
                        {
                            //find the id and publish it
                            HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                            oBlog.PublishBlog(hdnVal.Value, "Y");

                        }
                        else
                        {
                            //find the id and un-publish it
                            HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                            oBlog.PublishBlog(hdnVal.Value, "N");

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error Updating Blog for Publish: " + ex.Message);
            }

            finally { }

            this.LoadData();

        }

        /*
         */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void DeleteEntry(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //3. Formulate SQL
            strSQL = "DELETE FROM tblEntry WHERE id='" + e.CommandArgument + "'";
            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {
                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //rebind data to control
                LoadData();
            }

            catch
            {
                lblMessage.Text = "SQL Error!<br>";
            }

            finally
            {
                //close
                myConnection.Close();
            }
        }

        /**
         */
        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {
                LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
                if (lnkbtn != null)
                {
                    lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");

                }

                LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                if (lnkbtn2 != null)
                {

                    lnkbtn2.Attributes.Add("OnClick", "if(confirm('Are you sure you want to tag this item as sold?')==false){event.returnValue=false;return false;}else{return true;}");
                    //if (lnkbtn2.Text == "SOLD") {lnkbtn2.Enabled = false; }
                }

            }
        }
        /**
         */
        public void dlEntryList_OnItemCreated(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {

                LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                if (lnkbtn2 != null)
                {
                    if (lnkbtn2.Text == "SOLD") { lnkbtn2.Enabled = false; }

                }

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
            Response.Redirect("post.aspx");

        }

        /**
         */
        private void HidePaging()
        {
            cmdNext.Visible = false;
            cmdPrev.Visible = false;
            lblCurrentPage.Visible = false;

        }
        /*
        */
        public string FormatHeightFt(object heightFt, object iCat)
        {
            string ht = heightFt.ToString();

            switch (iCat.ToString())
            {
                case "1":
                    ht = ht + "\'";
                    break;
                case "2":
                    ht = ht + " cm" + "&nbsp;";
                    break;
                case "3":
                    ht = string.Empty;
                    break;
                case "4":
                    ht = string.Empty;
                    break;
                default:
                    ht = string.Empty;
                    break;
            }

            return ht;
        }
        /*
         */
        public string FormatHeightIn(object heightIn, object iCat)
        {

            string inch = heightIn.ToString();

            switch (iCat.ToString())
            {
                case "1":
                    inch = inch + "\"" + "&nbsp;";
                    break;
                case "2":
                    inch = string.Empty;
                    break;
                case "3":
                    inch = string.Empty;
                    break;
                case "4":
                    inch = string.Empty;
                    break;
                default:
                    inch = string.Empty;
                    break;
            }

            return inch;
        }
        /*
         */
        public string GetStatus(object objStat)
        {
            if (objStat.ToString() == "3")
            {
                return "<font color='red'>SOLD<font>";
            }
            else
            {
                return "Sold it!";
            }
        }
        /*
         */
        public bool GetPublishedStatus(object objStat)
        {
            if (objStat.ToString() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         */
        public bool GetEnabledStatus(object objStat)
        {
            if (objStat.ToString() == "3")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
