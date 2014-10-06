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
    public partial class ElJefe1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;

        public System.Web.UI.WebControls.Label lblUserId;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            Global.AuthenticateUser();

            if (Session["EmailId"].ToString() != "admin@boardhunt.com")
            {
                Response.Redirect("../UserMenu.aspx");
            }

            //lnkSignIn.Text = Global.SetLnkSignIn();
            //lnkSignUp.Text = Global.SetLnkSignUp();

            //allow filtering by acct type
            if (!Page.IsPostBack)
            {
                LoadFilter();

                // Call the ItemsGet method to populate control,
                ItemsGet();
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
            this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
            //this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            //this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);
        }
        #endregion

        private void LoadFilter()
        {
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            // build SQL
            strSQL = "SELECT iD, acctType, value FROM tblAcctType";

            SqlConnection myConnection = new SqlConnection(myConnectString);
            DataSet dsItems = new DataSet();

            //Create and add the (default) "All" entry
            ListItem liAllAcctType = new ListItem("All", "All");  //acctTypes
            //ListItem liShaperAcctType = new ListItem("shapers", "2");
            //ListItem liRetAcctType = new ListItem("retailers", "2");

            try
            {

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);
                objAdapter.Fill(dsItems);

                //Filter
                cboFilter.Items.Clear();
                cboFilter.DataSource = dsItems.Tables[0];
                cboFilter.DataTextField = "acctType";
                cboFilter.DataValueField = "value";
                cboFilter.DataBind();

                //cboFilter.Items.Add(liShaperAcctType);
                //cboFilter.Items.Add(liRetAcctType);
                cboFilter.Items.Add(liAllAcctType);
                cboFilter.ClearSelection();
                cboFilter.SelectedIndex = cboFilter.Items.Count - 1;
                //cboCategory.SelectedIndex = cboVal;

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Filter Error";
                ErrorLog.ErrorRoutine(false, "Filter Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }        
        }

        private void ItemsGet()
        {
           
                //declare variables	
                string strSQL;
                string myConnectString;

                //Create connect string
                myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;
                SqlConnection myConnection = new SqlConnection(myConnectString);
                try
                {
                strSQL = "SELECT * FROM tblUser u";

                string fVal = cboFilter.SelectedValue;
                string fText = cboFilter.SelectedItem.Text;

                if (cboFilter.SelectedValue != "All")
                {
                    strSQL += " WHERE iAcctType = '" + cboFilter.SelectedValue + "'";
                    switch (cboFilter.SelectedValue)
                    {
                        case "1":
                            break;
                        case "2":
                            if (fText == "Shapers")
                                strSQL += " AND iMerchantType = '1' ";
                            if (fText == "Retailers")
                                strSQL += " AND iMerchantType = '2' ";
                            break;
                        default:
                            break;
                    }

                }
                strSQL += " ORDER BY iD DESC";

                // Read sample item info from SQL into a DataSet
                DataSet dsItems = new DataSet();

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.Fill(dsItems, "tblEntry");

                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                if (listCount <= (int)15)
                {
                    //hide_Paging();
                    ShowPaging();
                }
                //If search yields no results, set message
                if (listCount == (int)0)
                {
                    dlEntryList1.Visible = false;
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
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                //lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //    + objPds.PageCount.ToString();

                //Chhange by Smarttech
                txtCurrentPage.Text = (CurrentPage + 1).ToString();
                lblcpage.Text = " Of " + objPds.PageCount.ToString();
          
                // Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;

                //bind to DataList control
                dlEntryList1.DataSource = objPds;
                dlEntryList1.DataBind();

                myConnection.Close();
                ShowPaging();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Filter Error";
                ErrorLog.ErrorRoutine(false, "Filter Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }      
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

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void EditUser(object src, CommandEventArgs e)
        {
            Response.Redirect("UserProfileManager.aspx?" + "iD=" + e.CommandArgument.ToString());
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
            ItemsGet();
        }

        private void cmdNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ItemsGet();
        }

        private void hide_Paging()
        {
            //cmdNext.Visible = false;
            //cmdPrev.Visible = false;
            //lblCurrentPage.Visible = false;
            cmdNext.Visible = false;
            
            cmdPrev.Visible = false;
        
            txtCurrentPage.Visible = false;
        
            lblcpage.Visible = false;
        }
        private void ShowPaging()
        {
            //cmdNext.Visible = true;                  //Change By Smarttech
            //cmdPrev.Visible = true;
            //txtCurrentPage.Visible = false;

            cmdNext.Visible = true;
         
            cmdPrev.Visible = true;

            txtCurrentPage.Visible = true;

            lblcpage.Visible = true;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btndownload_Click(object sender, EventArgs e)
        {
            try
            {
                //dlEntryList1.AllowPaging = false;
                binddatalist();
                dlEntryList1.Columns[0].Visible = false;
                dlEntryList1.Columns[1].Visible = false;
                dlEntryList1.Columns[3].Visible = false;
                dlEntryList1.Columns[4].Visible = false;
                dlEntryList1.Columns[5].Visible = false;
                dlEntryList1.Columns[6].Visible = false;
                dlEntryList1.Columns[7].Visible = false;
                dlEntryList1.Columns[8].Visible = false;
                dlEntryList1.Columns[9].Visible = false;

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=EmailDetails.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                dlEntryList1.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

                //dlEntryList1.AllowPaging = true;
                binddatalist();
            }
            catch
            {
            }

        }

        public void binddatalist()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;
            SqlConnection myConnection = new SqlConnection(myConnectString);

            strSQL = "SELECT * FROM tblUser u";

            string fVal = cboFilter.SelectedValue;
            string fText = cboFilter.SelectedItem.Text;

            if (cboFilter.SelectedValue != "All")
            {
                strSQL += " WHERE iAcctType = '" + cboFilter.SelectedValue + "'";
                switch (cboFilter.SelectedValue)
                {
                    case "1":
                        break;
                    case "2":
                        if (fText == "Shapers")
                            strSQL += " AND iMerchantType = '1' ";
                        if (fText == "Retailers")
                            strSQL += " AND iMerchantType = '2' ";
                        break;
                    default:
                        break;
                }

            }
            strSQL += " ORDER BY iD DESC";

            // Read sample item info from SQL into a DataSet
            DataSet dsItems = new DataSet();

            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            objAdapter.Fill(dsItems, "tblEntry");
            //bind to DataList control
            dlEntryList1.DataSource = dsItems;
            dlEntryList1.DataBind();

            myConnection.Close();
        }

        protected void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            //// Set viewstate variable to the next page
            CurrentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;

            // Reload control
            txtclick_itemget();
        }
        public void txtclick_itemget()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;
            SqlConnection myConnection = new SqlConnection(myConnectString);
            try
            {
                strSQL = "SELECT * FROM tblUser u";

                string fVal = cboFilter.SelectedValue;
                string fText = cboFilter.SelectedItem.Text;

                if (cboFilter.SelectedValue != "All")
                {
                    strSQL += " WHERE iAcctType = '" + cboFilter.SelectedValue + "'";
                    switch (cboFilter.SelectedValue)
                    {
                        case "1":
                            break;
                        case "2":
                            if (fText == "Shapers")
                                strSQL += " AND iMerchantType = '1' ";
                            if (fText == "Retailers")
                                strSQL += " AND iMerchantType = '2' ";
                            break;
                        default:
                            break;
                    }

                }
                strSQL += " ORDER BY iD DESC";

                // Read sample item info from SQL into a DataSet
                DataSet dsItems = new DataSet();

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.Fill(dsItems, "tblEntry");

                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                if (listCount <= (int)15)
                {
                    //hide_Paging();
                    ShowPaging();
                    
                }
                //If search yields no results, set message
                if (listCount == (int)0)
                {
                    dlEntryList1.Visible = false;
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
                objPds.PageSize = 15;

                objPds.CurrentPageIndex = CurrentPage;

                //lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //    + objPds.PageCount.ToString();

                //Chhange by Smarttech
                //txtCurrentPage.Text = (CurrentPage + 1).ToString();
                //lblcpage.Text = " Of " + objPds.PageCount.ToString();

                // Disable Prev or Next buttons if necessary
                cmdPrev.Enabled = !objPds.IsFirstPage;
                cmdNext.Enabled = !objPds.IsLastPage;

                //bind to DataList control
                dlEntryList1.DataSource = objPds;
                dlEntryList1.DataBind();

                myConnection.Close();
                ShowPaging();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Filter Error";
                ErrorLog.ErrorRoutine(false, "Filter Error: " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }   
            ////record keyword search term
            //if (cboKeywordsVal.Length > 1)
            //    RecordKeywords();
        }
    }
}
