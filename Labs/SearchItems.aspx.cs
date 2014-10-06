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

namespace BoardHunt.Labs
{
    public partial class SearchItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "SearchItems:PageLoad()");

            string strX = "";
            if (Request["x"] != null)
            {
                strX = Request["x"].ToString();
                ErrorLog.ErrorRoutine(false, "SearchItems:PageLoad():strX: " + strX);

                Response.Write("Dahhhh!");
            }
        }
    }
}
