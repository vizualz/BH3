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
	public partial class post : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton imgNext;
        //protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        //protected System.Web.UI.WebControls.LinkButton lnkSignUp;

        //protected System.Web.UI.WebControls.LinkButton lnkPost;
        //protected System.Web.UI.WebControls.TextBox searchTextField;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Global.AuthenticateUser();

			// Put user code to initialize the page here
			Global.AuthenticateUser("post.aspx");

			string iUID = Session["userId"].ToString();
			string i;

			//check for ProUser
			BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
			i = oWS.isPro(Convert.ToInt32(iUID)).ToString();

			if (i != "1") //if not Pro acct the check to see if they're maxed out of posts
			{
				if (oWS.GetActiveBoardCount(Convert.ToInt32(iUID), 1, 0) > 4 )
					Response.Redirect("/UserMenu.aspx", true); //TODO: add message that they're out of posts
			}

			BindData(); //unconditionally bind the data for the controls

			//if (!Page.IsPostBack) 
			//{
			//	Session ["EditMode"] = "false"; //a check for edit mode ???
			//} 

			//check first time arrival or edit mode
			string[] arString;
			arString = Request.QueryString.GetValues("em");
			if (arString != null)
			{
				if (HttpUtility.UrlDecode (arString [0].ToString ()) == "1") {
					//load object values
					classes.BoardItem tmpBoardItem = (classes.BoardItem)Session["Item"];
					if (tmpBoardItem != null)
					{
						txtTown.Text = tmpBoardItem.Town;
						txtZip.Text = tmpBoardItem.Zip;
					}
				}
			}
			else
			{
				Session ["EditMode"] = "false";
			}

			// Put user code to initialize the page here

			Session ["Item"] = null;

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
		}
		#endregion

/**
*/
        protected void btnNext_Click(object sender, System.EventArgs e)
        {
            classes.BoardItem tmpItem = new classes.BoardItem();

            ErrorLog.ErrorRoutine(false, "Post:btnNext_Click: " + Session.SessionID + " isPB: " + Page.IsPostBack);

			tmpItem.Category = 1; //hardcoded for ALWAYS surfboards
			tmpItem.AdType = 1; //hardcoded for ALWAYS surfboards

            tmpItem.Location = Convert.ToInt32(cboRegion.SelectedItem.Value);
            tmpItem.Ship = Convert.ToInt32(rdoShip.SelectedItem.Value);
            tmpItem.Town = txtTown.Text;
            tmpItem.EditMode = false;

			tmpItem.Zip = txtZip.Text;
			tmpItem.ICondition = Convert.ToInt32(radioConditionType.SelectedItem.Value);

			//Used for convenient 1-click editing from emails.
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
        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            Session["Item"] = null;
            Response.Redirect("UserMenu.aspx",true);

        }

/**
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
            strSQL = "SELECT * FROM LK_Region ORDER BY Description DESC; SELECT iD,condition FROM LK_Condition";
			
			SqlConnection myConnection = new SqlConnection(myConnectString);			

			// Read sample item info from SQL into a DataSet
			DataSet dsItems = new DataSet();
			SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

            try
            {

				objAdapter.TableMappings.Add("Table", "tblRegion");
				objAdapter.TableMappings.Add("Table1", "tblCondition");

                objAdapter.Fill(dsItems);

                cboRegion.DataSource = dsItems;
                cboRegion.DataMember = "tblRegion";
                cboRegion.DataTextField = "Region";
                cboRegion.DataValueField = "iD";
                cboRegion.DataBind();

			
				for (int i = 0; i < cboRegion.Items.Count; i++)
                {
					switch (dsItems.Tables[0].Rows[i][2].ToString().Trim())
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
			catch (Exception ex)
            {
				ErrorLog.ErrorRoutine(false, "Post.aspx: Error loading controls: " + ex.InnerException);
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