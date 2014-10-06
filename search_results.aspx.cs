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

namespace BoardHunt
{
    public partial class search_results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string myURL = Request.Url.ToString();
            myURL = Global.ReplaceEx(myURL, "search_results", "Surfboardsforsale");
            Response.Redirect(myURL, false);
        }
    }
}
