
namespace BoardHunt.alert
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;
	using System.Web.UI;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Linq;
	using DALLayer;

	
	public partial class addalert : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSignIn;
		protected System.Web.UI.WebControls.LinkButton lnkSignUp;
		protected System.Web.UI.WebControls.DropDownList cboBoardType;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lnkSignIn.Text = Global.SetLnkSignIn( );
			lnkSignUp.Text = Global.SetLnkSignUp( );

			LoadCtls ();
		}

		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static string[] GetBrands(string prefixText, int count)
		{
			BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();

			// Get the Products From Data Source. Change this method to use Database
			List<string> productList = oWS.GetAllBrands(prefixText, count); 

			// Find All Matching Products
			var list = from p in productList
					where p.Contains(prefixText)
				select p;

			//Convert to Array as We need to return Array
			string[] prefixTextArray = list.ToArray<string>();

			//Return Selected Products
			return prefixTextArray;
		}

		public void LoadCtls()
		{
			string strSQL = "SELECT * FROM LK_BoardType WHERE BoardCategory = 1 ORDER BY iValue";

			IDBManager dbManager = new DBManager(DataProvider.SqlServer);
			dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
			DataSet dsItems = new DataSet();

			try
			{
				dbManager.Open();
				dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);


				cboBoardType.Items.Clear();
				cboBoardType.DataSource = dsItems;
				cboBoardType.DataMember = dsItems.Tables[0].ToString();
				cboBoardType.DataTextField = "BoardType";
				cboBoardType.DataValueField = "iValue";
				cboBoardType.DataBind();
				cboBoardType.Items.Add("Pick one");
				cboBoardType.ClearSelection();
				cboBoardType.SelectedIndex = cboBoardType.Items.Count - 1;

			}
			catch (Exception ex)
			{
				ErrorLog.ErrorRoutine(false, "AddAlert:LoadCtls:Error:" + ex.Message);

			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}		






		}

	}
}

