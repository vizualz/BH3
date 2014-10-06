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
    public partial class item_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string[] arrStr;
            char[] splitter = { '?' };
            string url = Request.Url.ToString();
            arrStr = url.Split(splitter);
            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString();
            Response.Redirect(serverURL + @"/surfboard.aspx?" + arrStr[1]);
        }
    }
}
