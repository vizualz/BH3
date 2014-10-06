using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BoardHunt.classes
{
    public class Invoice
    {
        private int liveCount;
        private int initCount;
        private bool editMode;
        private string title;
        private string cCode;

        //====================================================================
        //Constructor
        //====================================================================
        public Invoice()
        {
            editMode = false;
        }

        public string GenerateInvNum(string srvNum, string id)
        {
            //BHServiceNum-UserId-Random
            //BH04-162-2342xy

            string retVal;
            retVal = "BH";

            //pad serivce for 2 digits
            if (srvNum.Length == 1)
                retVal += srvNum.PadLeft(2, '0');
            else
                retVal += srvNum;

            BoardHunt.classes.RandomPassword iGen = new BoardHunt.classes.RandomPassword();
            retVal += "-" + id + "-" + iGen.Generate(6).ToUpper();
            
            return retVal;

          
        }
    }
}
