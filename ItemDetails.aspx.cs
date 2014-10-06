using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoardHunt
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorLog.ErrorRoutine(false, "ItemDetails:Page_Load: ");

                string[] arString;
                arString = Request.QueryString.GetValues("iD");

                if (arString[0] != string.Empty)
                {
                    string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString();

                    Response.Status = "301 Moved Permanently";
                    ErrorLog.ErrorRoutine(false, "addHeaderString:" + serverURL + @"/surfboard.aspx?id=" + arString[0]);
                    Response.AddHeader("Location", serverURL + @"/surfboard.aspx?id=" + arString[0]);

                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "InItemDetails: Exception: " + ex.Message);
            }

        }
    }
}