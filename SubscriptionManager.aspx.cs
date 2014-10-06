//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			login.aspx.cs
///		Project log:	
///						
///
///
//////////////////////////////////////////////////////////////////////////

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
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using DALLayer;

namespace BoardHunt
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
    public partial class SubscriptionManager : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			

			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

            if (!Page.IsPostBack)
            {
                BindData();
            }

		}
/*
 */ 
        protected void BindData()
        {
            string strSQL;
            string val;

            val = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Declare Dataset
            DataSet dsItems = new DataSet();

            strSQL = "SELECT ts.dStartDate, ts.iStatus, lks.name, lks.amount FROM tblServices ts ";
            strSQL += "INNER JOIN LK_Services lks ON ";
            strSQL += "ts.iServiceVal = lks.iD ";
            strSQL += "WHERE ts.iUserId= '" + Session["userId"].ToString() + "'";
            strSQL += " AND ts.iServiceVal = '2'";

            //Get the service info and display the data or if no data redirect them to the order for so they can subscribe to Bidder
            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                int listCount = dsItems.Tables[0].Rows.Count;

                ErrorLog.ErrorRoutine(false, "ListCount: " + listCount);

                if (listCount>0)
                {
                    PagedDataSource objPds = new PagedDataSource();
                    objPds.DataSource = dsItems.Tables[0].DefaultView;
                    objPds.AllowPaging = true;
                    objPds.PageSize = 15;

                    //bind to control
                    dlEntryList.DataSource = objPds;
                    dlEntryList.DataBind();
                }
                else
                {
                    Session["ServiceId"] = "2";
                    Response.Redirect("Pay/OrderForm.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:Page_Load:Msg: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
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

		}
		#endregion

        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {

            //if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            //{
            //    LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
            //    if (lnkbtn != null)
            //    {
            //        lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");
            //    }
            //}
        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void DeleteEntry(object src, CommandEventArgs e)
        {

            try
            {


            }

            catch
            {

            }


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
			Response.Redirect("post.aspx");
			
		}		




                               




	}
}
