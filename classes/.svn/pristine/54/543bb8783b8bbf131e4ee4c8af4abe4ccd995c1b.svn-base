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
    public class Bids
    {
        private int userId;             //id of bidder - (2) requirements: must be a shaper and have paid
        private int bidEntry;           //FK_tblBidEntry
        private Decimal bidValue;       //value of bid
        private DateTime dCreateDate;   //date bid was placed
    
        //====================================================================
        //Constructor
        //====================================================================
        public Bids()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //====================================================================
        //Properties
        //====================================================================
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int BidEntry
        {
            get { return bidEntry; }
            set { bidEntry = value; }
        }

        public Decimal BidValue
        {
            get { return bidValue; }
            set { bidValue = value; }
        }

        public DateTime DCreateDate
        {
            get { return dCreateDate; }
            set { dCreateDate = value; }
        }

        public bool InsertBid()
        {
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "INSERT INTO tblBids(iUserId, iValue, iBidEntryId, dCreateDate)";
            strSQL += " VALUES ('" + this.UserId + "', '" + this.BidValue + "', '" + this.BidEntry + "', '" + this.DCreateDate + "')";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BoardBid:InsertBid: " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }        
        }
    
    }
}
