/*
 *      File: post.aspx
 *      
 *      This is the first page of a wizard that collects input from users wanting to post items.
 *      Collected here are the Adtype, BoardCategory, Location, and Town.
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

namespace BoardHunt
{
	/// <summary>
	/// Summary description for post.
	/// </summary>
	public class post : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboCategory;
		protected System.Web.UI.WebControls.DropDownList cboRegion;
		protected System.Web.UI.WebControls.ImageButton imgNext;
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.RadioButtonList radioAdType;
        protected System.Web.UI.WebControls.RadioButtonList rdoShip;
        protected System.Web.UI.WebControls.RadioButtonList radioConditionType;
		protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.TextBox txtTown;
        protected System.Web.UI.WebControls.Panel pnlShip;
        protected System.Web.UI.WebControls.Panel pnlCondition;
        protected System.Web.UI.WebControls.HiddenField hdnAdType;
        protected System.Web.UI.WebControls.Button btnCancel;
        protected System.Web.UI.WebControls.Button btnNext;
        //protected System.Web.UI.WebControls.TextBox searchTextField;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            //clear out any old session item
            Session["Item"] = null;

            ErrorLog.ErrorRoutine(false, "Post:Page_Load: " + Session.SessionID + " isPB: " + Page.IsPostBack);
            //ErrorLog.ErrorRoutine(false, "Post:Page_Load: val: " + searchTextField.Text);

            // Put user code to initialize the page here
			Global.AuthenticateUser("post.aspx");
            //Global.AuthenticateUser();

            if (Session["isPro"].ToString() != "1") //if not Pro acct the check to see if they're maxed out of posts
            {
                if (classes.User.NeedsUpgrade(Convert.ToInt32(Session["userId"].ToString())))
                    Response.Redirect("/UserMenu.aspx", true); //TODO: add message
            }

            // Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			if (!Page.IsPostBack)
			{
                //This tells us if we're in edit mode; user clicked edit on the preview_post page
                Session["EditMode"] = "false";

                //radioAdType.Attributes.Add("OnClick", "TogglePanel('div_condition','radioAdType')");
                
                BindData();
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
            this.Load += new System.EventHandler(this.Page_Load);
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
			this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
			this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
		}
		#endregion

/**
*/
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            classes.BoardItem tmpItem = new classes.BoardItem();

            ErrorLog.ErrorRoutine(false, "Post:btnNext_Click: " + Session.SessionID + " isPB: " + Page.IsPostBack);

            //ErrorLog.ErrorRoutine(false, "Post:btnNext_Click: " + searchTextField.);

            tmpItem.Category = Convert.ToInt32(cboCategory.SelectedItem.Value);
            tmpItem.Location = Convert.ToInt32(cboRegion.SelectedItem.Value);
            tmpItem.AdType = Convert.ToInt32(radioAdType.SelectedItem.Value);
            tmpItem.Ship = Convert.ToInt32(rdoShip.SelectedItem.Value);

            //if selling ad type get the board/item condition
            if (radioAdType.SelectedItem.Value == "1")
            {
                tmpItem.ICondition = Convert.ToInt32(radioConditionType.SelectedItem.Value);
            }

            tmpItem.Town = txtTown.Text;
            //tmpItem.Town = searchTextField.Text;

            tmpItem.EditMode = false;

            BoardHunt.classes.RandomPassword pwdGen = new BoardHunt.classes.RandomPassword();
            tmpItem.ActivateCode = pwdGen.Generate();

            //Save board object to session variable
            Session["Item"] = tmpItem;
            tmpItem = null;

            //to next wizard page
            Response.Redirect("post_item.aspx", false);

        }
/**
*/
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Session["Item"] = null;
            Response.Redirect("UserMenu.aspx",true);

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
		public void BindData()
		{
			//declare variables	
			string strSQL;
			string myConnectString;

            //check to see if we already know what type of adType posting this will be
            string[] qAdType;
            qAdType = Request.QueryString.GetValues("q");
            if (qAdType != null)
            {
                hdnAdType.Value = HttpUtility.UrlDecode(qAdType[0].ToString());
                qAdType[0] = string.Empty;
            }
            else
            {
                //unknown type
                hdnAdType.Value = "0";
            }
		
			//Create connect string
			myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
			
			//Build SQL statement
            strSQL = "SELECT * FROM LK_AdType ; SELECT * FROM LK_Category WHERE GroupId='1'; SELECT * FROM LK_Region ORDER BY Description DESC; SELECT iD,condition FROM LK_Condition";
			
			SqlConnection myConnection = new SqlConnection(myConnectString);			

			// Read sample item info from SQL into a DataSet
			DataSet dsItems = new DataSet();
			SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {
                objAdapter.TableMappings.Add("Table", "tblAd");
                objAdapter.TableMappings.Add("Table1", "tblCat");
                objAdapter.TableMappings.Add("Table2", "tblRegion");
                objAdapter.TableMappings.Add("Table3", "tblCondition");

                objAdapter.Fill(dsItems);

                radioAdType.DataSource = dsItems;
                radioAdType.DataMember = "tblAd";
                radioAdType.DataTextField = "adType";
                radioAdType.DataValueField = "iD";
                radioAdType.DataBind();
                radioAdType.SelectedIndex = (int)0;

                //Remove showcase; Only admin privilege
                //TODO: fix this tmp hack
                radioAdType.Items.Remove(radioAdType.Items.FindByValue("3"));
                radioAdType.Items.Remove(radioAdType.Items.FindByValue("4"));

                cboCategory.DataSource = dsItems;
                cboCategory.DataMember = "tblCat";
                cboCategory.DataTextField = "Category";
                cboCategory.DataValueField = "iD";
                cboCategory.DataBind();
                cboCategory.SelectedIndex = (int)0;

                cboRegion.DataSource = dsItems;
                cboRegion.DataMember = "tblRegion";
                cboRegion.DataTextField = "Region";
                cboRegion.DataValueField = "iD";
                cboRegion.DataBind();

                for (int i = 0; i < cboRegion.Items.Count; i++)
                {
                    switch (dsItems.Tables[2].Rows[i][2].ToString().Trim())
                    {
                        case "State":
                            cboRegion.Items[i].Attributes.Add("style", "color:#000000");
                            break;
                        case "Continent":
                            cboRegion.Items[i].Attributes.Add("style", "color:#999999");
                            break;
                        case "Country":
                            cboRegion.Items[i].Attributes.Add("style", "color:#666666");
                            break;

                    }
                }
                cboRegion.SelectedIndex = (int)0;

                radioConditionType.DataSource = dsItems;
                radioConditionType.DataMember = "tblCondition";
                radioConditionType.DataTextField = "condition";
                radioConditionType.DataValueField = "iD";
                radioConditionType.DataBind();
                radioConditionType.SelectedIndex = (int)0;
            }
            catch
            {
                ErrorLog.ErrorRoutine(false, "Post.aspx: Error loading controls");
            }

            finally
            {
                myConnection.Close();
            }

            //hide for minisites
            if (hdnAdType.Value == "4")
            {
                pnlShip.Visible = false;
                pnlCondition.Visible = false;
            }

		}

        protected void radioAdType_OnDataBound(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            foreach (ListItem li in rbl.Items)
            {
                li.Attributes.Add("onclick", "javascript:TogglePanel('" + li.Value + "','div_condition','2')");
            }        
        }


	}
}
