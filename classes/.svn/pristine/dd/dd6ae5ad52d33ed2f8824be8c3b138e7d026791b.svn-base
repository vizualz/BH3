using System;
using System.Configuration;
using System.Data;
using DALLayer;

namespace BoardHunt.classes
{
    public class BoardBidItem : BoardItem
    {
        //int bidder;
        private DateTime ended;
        private int winner;
        private Decimal startPrice;
        private Decimal endPrice;


        //constructor
        public BoardBidItem()
        {
            ErrorLog.ErrorRoutine(false, "BBI contructor done");
        }

        //====================================================================
        //Properties & Accessors
        //====================================================================
        public decimal EndPrice
        {
            get { return endPrice; }
            set { endPrice = value; }

        }  

        public decimal StartPrice
        {
            get { return startPrice; }
            set { startPrice = value; }

        }        
        
        public DateTime Ended
        {
            get { return ended; }
            set { ended = value; }

        }        
        
        //public int Bidder
        //{
        //    get { return bidder; }
        //    set { bidder = value; }
        //}

        public int Winner
        {
            get { return winner; }
            set { winner = value; }
        }



/*********************************************/
/************** METHODS **********************/
/*********************************************/
        public bool MonkeyFunction()
        {
            return true;
        }


        public override bool SaveItem()
        {
            string strSQL;
            
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "INSERT INTO tblBidEntry (iBidder, iHtFt, iHtIn, iTailType, iWidth, iWidthNum, iWidthDenom, iThick, iThickNum, iThickDenom, dStartDate, startPrice, txtDetails, iBoardType)";
            strSQL += "VALUES ('" + this.IUser + "', '" + this.HtFt + "', '" + this.HtIn + "', '" + this.TailType + "', '" + this.Width + "', '" + this.WidthNum + "', '" + this.WidthDenum +
                      "', '" + this.Thickness + "', '" + this.ThickNum + "', '" + this.ThickDenum + "' , '" + this.Created + "' , '" + this.StartPrice + "', '" + this.Details + "', '" + this.BoardType + "')";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
            
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BoardBid:SaveItem: " + ex.Message);
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
