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

namespace BoardHunt.help
{
    
    
    public partial class help : System.Web.UI.Page
    {
        //protected System.Web.UI.WebControls.Image imgHelp;

        protected void Page_Load(object sender, EventArgs e)
        {
            string qryVal;
            qryVal = Request.QueryString["val"];
            switch (qryVal)
            {
                case "1":
                    imgHelp.ImageUrl = "../images/boards.gif";
                    imgHelp.Width = 277;
                    imgHelp.Height = 276;
                    break;
                case "2":
                    imgHelp.ImageUrl = "../images/snowboards.gif";
                    imgHelp.Width = 278;
                    imgHelp.Height = 279;
                    break;
                case "4":
                    imgHelp.ImageUrl = "../images/tails.gif";
                    imgHelp.Width = 285;
                    imgHelp.Height = 263;
                    break;
                default:
                    break;
            }
        }
    }
}
