using System;
using System.Collections;
using System.Configuration;
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
    public partial class FavMaster1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton LinkButton2;
        protected System.Web.UI.WebControls.LinkButton LinkButton3;
        protected System.Web.UI.WebControls.LinkButton linkEdit;
        protected System.Web.UI.WebControls.ImageButton imgAdType;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

        public System.Web.UI.WebControls.Label lblUserId;

        //FIXME: need to pass Cat id to item details
        //public static string iCategory;    

        protected void Page_Load(object sender, System.EventArgs e)
        {

            // Put user code to initialize the page here
            Global.AuthenticateUser();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            // Put user code to initialize the page here
            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            // Call the ItemsGet method to populate control,
            // passing in the sample data.
            ItemsGet();

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


        private void ItemsGet()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Formulate SQL
            strSQL = "SELECT tblEntry.*, tblFavs.* FROM tblEntry INNER JOIN tblFavs ON tblEntry.iD = tblFavs.entryId";
            strSQL = strSQL + " ORDER BY tblEntry.dCreateDate DESC";

            SqlConnection myConnection = new SqlConnection(myConnectString);

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();

            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            objAdapter.Fill(dsItems, "tblEntry");

            int listCount = dsItems.Tables["tblEntry"].Rows.Count;

            //Do we need to display the back and forward controls?
            if (listCount <= (int)15)
            {
                //If search yields no results, set message
                if (listCount == (int)0)
                {
                    lblNoResult.Text = "Your currently have no favorites.";
                    dlEntryList.Visible = false;
                    //lblCount.Text = "(0)";
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

        public void cmdPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            ItemsGet();
        }

        public void cmdNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ItemsGet();
        }


        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }

        //Fired when user clicks the edit link.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            //Todo:we need board type so perhaps we can add it as a hidden value in the .aspx and access on the code sire
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString());// + "&iCat=" + Request.QueryString["iCat"].ToString());

        }
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void DeleteEntry(object src, CommandEventArgs e)
        {
            //Already confirmed so go ahead and delete the entry
            string connStr, strSQL;

            //get conn string
            connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Set SQL statment
            strSQL = "DELETE FROM tblFavs WHERE FaviD='" + e.CommandArgument + "'";
            SqlConnection myConnection = new SqlConnection(connStr);

            try
            {

                myConnection.Open();

                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                //close
                myConnection.Close();

                //rebind data to control
                ItemsGet();

            }

            catch
            {
                lblMessage.Text = "SQL Error: " + strSQL;
            }


        }


        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {
                LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
                if (lnkbtn != null)
                {
                    lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");

                }
            }
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
            Response.Redirect("post.aspx");

        }
        /*
         */
        public string DecodeAdType(object AdCode)
        {
            return Enum.GetName(typeof(Global.AD_TYPE), AdCode);

        }

        public string FormatHeightFt(object heightFt, object category)
        {
            string ht = heightFt.ToString();

            switch (category.ToString())
            {
                case "1": //surf
                    ht = ht + "\'";
                    break;
                case "2":	//snow
                    ht = ht + " cm";
                    break;
                case "3":	//skate
                    ht = "";
                    break;
                case "4":	//other
                    ht = "";
                    break;
            }

            return ht;
        }

        public string FormatHeightIn(object heightIn, object category)
        {

            string inch = heightIn.ToString();

            switch (category.ToString())
            {
                case "1":
                    inch = inch + "\"";
                    break;
                case "3":
                    inch = inch + "\"";
                    break;
                case "2":
                    inch = "";
                    break;
                case "4":
                    inch = "";
                    break;
            }

            return inch;
        }
        /**
         */
        private void HidePaging()
        {
            cmdNext.Visible = false;
            cmdPrev.Visible = false;
            lblCurrentPage.Visible = false;

        }
        /**
         */
        public string GetAdType(object adType)
        {

            if (adType == DBNull.Value || adType.ToString() == "")
            {
                return "../images/s1x1.gif";
            }
            else
            {
                if (adType.ToString() == "1")
                {
                    return "../images/selling.gif";
                }
                else
                {
                    return "../images/wanted.gif";
                }
            }

        }

    }
}
