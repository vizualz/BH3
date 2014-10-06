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

namespace BoardHunt.Admin
{
    public partial class Reports : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;

        public System.Web.UI.WebControls.Label lblUserId;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;

        public const int pgSize = 100;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            Global.AuthenticateUser();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            // Call the ItemsGet method to populate control,
            LoadData();
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
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            DataSet dsItems = new DataSet();

            strSQL = "SELECT iD, word, page, dAdded FROM tblSearchTerms ORDER BY dAdded";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Report:LoadData:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            int listCount = dsItems.Tables[0].Rows.Count;

            if (listCount <= (int)100)
            {
                hide_Paging();
            }
            //If search yields no results, set message
            if (listCount == (int)0)
            {
                dlEntryList.Visible = false;
                lblCount.Text = "(0)";
            }
            else
            {
                lblCount.Text = "(" + listCount.ToString() + ")";
            }

            // Populate the repeater control with the Items DataSet
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dsItems.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 100;

            objPds.CurrentPageIndex = CurrentPage;

            lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                + objPds.PageCount.ToString();

            // Disable Prev or Next buttons if necessary
            cmdPrev.Enabled = !objPds.IsFirstPage;
            cmdNext.Enabled = !objPds.IsLastPage;

            //bind to DataList control
            dlEntryList.DataSource = objPds;
            dlEntryList.DataBind();

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

        /*
                public void cmdPrev_Click(object sender, System.EventArgs e)
                {
                    // Set viewstate variable to the previous page
                    CurrentPage -= 1;

                    // Reload control
                    ItemsGet();
                }


                public void cmdNext_Click(object sender, System.EventArgs e)
                {
                    // Set viewstate variable to the next page
                    CurrentPage += 1;

                    // Reload control
                    ItemsGet();
                }
        */


        public string VerifyImage(object imgPicPath)
        {

            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                return "../images/s1x1.gif";
            }
            else
            {
                return "../images/camera.gif";
            }

        }

        public string DecodeAdType(object AdCode)
        {
            //return Global.ReverseLookUp(FinCode);
            return Enum.GetName(typeof(Global.AD_TYPE), AdCode);

        }

        public string FormatPrice(object priceVal)
        {
            string tempVal = priceVal.ToString();

            if (tempVal.IndexOf(@".") > (int)0)
            {
                return tempVal;
            }
            else
            {
                return tempVal + ".00";
            }

        }

        public string FormatHeightFt(object heightFt)
        {
            string ht = heightFt.ToString();

            switch (Convert.ToInt32(Request.QueryString["boardCategory"]))
            {
                case 1:
                    ht = ht + "\'";
                    break;
                case 2:
                    ht = ht + " cm";
                    break;
                case 3:
                    ht = "";
                    break;
                case 4:
                    ht = "";
                    break;
            }

            return ht;
        }

        public string FormatHeightIn(object heightIn)
        {

            string inch = heightIn.ToString();

            switch (Convert.ToInt32(Request.QueryString["boardCategory"]))
            {
                case 1:
                    inch = inch + "\"";
                    break;
                case 3:
                    inch = inch + "\"";
                    break;
                case 2:
                    inch = "";
                    break;
                case 4:
                    inch = "";
                    break;
            }

            return inch;
        }


        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }


        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {

            Global.NavigatePage(lnkSignIn.Text);

        }

        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);

        }

        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../post.aspx");

        }

        private void cmdPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            LoadData();

        }

        private void cmdNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadData();

        }

        private void hide_Paging()
        {
            cmdNext.Visible = false;
            cmdPrev.Visible = false;
            lblCurrentPage.Visible = false;

        }

        }
    }
