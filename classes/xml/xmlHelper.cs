using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.XPath;
using System.Xml;
using System.Net;

namespace BoardHunt.classes.xml
{
    public class xmlHelper
    {

        //constructor
        public xmlHelper()
        {
        
        }

        public static string GetText(string val, string path)
        {
            string newpath = HttpContext.Current.Server.MapPath(path);
            string retVal = string.Empty;

            try
            {
                XPathDocument oXDoc = new XPathDocument(newpath);
                XPathNavigator oXNav = oXDoc.CreateNavigator();

                XPathExpression oXExp = oXNav.Compile(val);
                XPathNodeIterator oXIdx = oXNav.Select(oXExp);

                if (oXIdx.Count == 0)
                {
                    return "-";
                }
                else
                {
                    while (oXIdx.MoveNext())
                    {
                        retVal += oXIdx.Current.Value.Trim();
                    }
                }

                return retVal;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, ex.Message);
                return "-1";
            }
            finally
            {

            }


        }

    }

}
