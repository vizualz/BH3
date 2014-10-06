using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DALLayer;

namespace BoardHunt.classes
{
    public class util
    {

        public static void RecordData(string word, string page)
        {

            string strSQL = string.Empty;
            int i;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "@word", word);
                dbManager.AddParameters(1, "@page", page);
                dbManager.AddParameters(2, "@date", DateTime.Now);
                i = dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "spRecordKeywords");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Util:RecordData:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
    }
}
