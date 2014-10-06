using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoardHunt.m
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //// set the ad parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["client"] = "ca-mb-pub-0007702553564747";
            parameters["channel"] = "";
            parameters["color_border"] = "CCCCCC";
            parameters["color_bg"] = "CCCCCC";
            parameters["color_link"] = "000000";
            parameters["color_text"] = "333333";
            parameters["color_url"] = "666666";
            //parameters["slotname"] = "7733197874";
            parameters["format"] = "mobile_single";
            parameters["markup"] = "xhtml";
            parameters["oe"] = "utf8";
            parameters["output"] = "xhtml";


            //// retrieve the markup
            string markup = classes.AdSenseHelper.GetAdMarkup(parameters);
            ltrAds.Text = markup;//Server.HtmlEncode(markup);
        }

        protected void btnHunt_Click(object sender, EventArgs e)
        {
            Response.Redirect("surfboardsforsale.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/index.aspx?r=1",true);
            //Response.Redirect("http://www.malzook.com/index.aspx?r=1", true);
        }
    }
}