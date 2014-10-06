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
using System.Xml.XPath;

namespace BoardHunt.Labs
{
    public partial class testXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //classes.Email.SendEmail(classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailSubject", @"~/Xml/Services.xml"), "info@boardhunt.com", "info@boardhunt.com", classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailBodyAny", @"~/Xml/Services.xml"), true);
            classes.Email.SendCCEmail("vizualz@hotmail.com", classes.Email.EMAIL_INFO_BH, "fmdot@hotmail.com", classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailSubject", @"~/Xml/Services.xml"), classes.Email.MSG_THX_VOUCHER_CC, string.Empty, true); 
            
            return;

            //string newpath = HttpContext.Current.Server.MapPath("~/Xml/Services.xml");
            //lblTest.Text = GetText("//service[@id='5']/description", newpath);
            //lblTest.Text = classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailSubject", @"~/Xml/Services.xml");
        }

        protected string GetText(string val, string path)
        {
            string retVal = string.Empty;

            try
            {
                XPathDocument oXDoc = new XPathDocument(path);
                XPathNavigator oXNav = oXDoc.CreateNavigator();

                XPathExpression oXExp = oXNav.Compile(val);
                XPathNodeIterator oXIdx = oXNav.Select(oXExp);

                if(oXIdx.Count == 0) 
                {
                    return  "-";
                }
                else
                {
                    while(oXIdx.MoveNext())
                    {
                        retVal += oXIdx.Current.Value;
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
