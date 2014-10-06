using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Net.Mail; 
using System.Collections;
//using System.Web.Mail; 


namespace BoardHunt.classes
{
    public class Email
    {
        public const int MSG_REG_CONGRATS = 1;
        public const int MSG_POSTED_COMMENT = 2;
        public const int MSG_THX_FOR_POST = 3;
        public const int MSG_THX_QUESTION = 4;
        public const int MSG_QUESTION_ANSWERED = 5;
        public const int MSG_THX_FOR_MODEL = 6;
        public const int MSG_NOMORE_COUPONS = 7;
        public const int MSG_THX_VOUCHER_GEN = 8;
        public const int MSG_THX_VOUCHER_CC = 9;

        public const string EMAIL_INFO_BH = "info@boardhunt.com";

        //private const string RELAY = "smtp.1and1.com";
        private const string RELAY = "localhost";
        private const string RELAY_PASS = "sfcSQJkY";
        private const int RELAY_PORT = 587;

        public static bool SendEmail(string strSub, string to, string msg)
        {
            MailMessage message = new MailMessage();

            try
            {

                message.From = new MailAddress("msg-man@boardhunt.com", "Boardhunt");
                message.To.Add(new MailAddress(to));
                message.Subject = strSub;
                message.Body = msg;
                message.IsBodyHtml = true;
                message.Bcc.Add(new MailAddress("info@boardhunt.com"));
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("msg-man@boardhunt.com", RELAY_PASS);

                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.InnerException);
                ErrorLog.ErrorRoutine(false, "Email.cs:To: " + message.To.ToString());
                ErrorLog.ErrorRoutine(false, "Email.cs:From: " + message.From.ToString());
                ErrorLog.ErrorRoutine(false, "Email.cs:Bcc: " + message.Bcc.ToString());
                return false;
            }
        }

       public static bool SendErrorEmail(string msg)
        {
            MailMessage message = new MailMessage();
            
            try
            {

                message.From = new MailAddress("errorbot@boardhunt.com", "Boardhunt");
                message.To.Add(new MailAddress("pm@boardhunt.com"));
                message.Subject = "BH - ERROR";
                message.Body = msg;
                message.IsBodyHtml = true;
                message.Bcc.Add(new MailAddress("info@boardhunt.com"));
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("errorbot@boardhunt.com", RELAY_PASS);

                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.InnerException);
                ErrorLog.ErrorRoutine(false, "Email.cs:To: " + message.To.ToString());
                ErrorLog.ErrorRoutine(false, "Email.cs:From: " + message.From.ToString());
                ErrorLog.ErrorRoutine(false, "Email.cs:Bcc: " + message.Bcc.ToString());
                return false;
            }
        }
/*
 */
        public static bool SendContactEmail(string msg, string subj, string from, string frmName)
        {
            MailMessage message = new MailMessage();

            ErrorLog.ErrorRoutine(false, "SendContactEmail...");

            try
            {

                message.From = new MailAddress(from, frmName);
                message.To.Add(new MailAddress("info@boardhunt.com"));
                message.Subject = subj;
                message.Body = msg;
                message.IsBodyHtml = false;
                message.Bcc.Add(new MailAddress("pm@boardhunt.com"));
                message.Bcc.Add(new MailAddress("fm@boardhunt.com"));
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("msg-man@boardhunt.com", RELAY_PASS);

                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:SendContactEmail:Error sending email: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Email.cs:SendContactEmail:Error sending email: " + ex.InnerException);
                return false;
            }
        }

/*
 */
        public static bool SendEmail(string strSub, string to, int msgType, string[] linkArr)
        {
            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("msg-man@boardhunt.com", "Boardhunt");
                message.To.Add(new MailAddress(to));
                message.Subject = strSub;
                message.Body = BoardHunt.classes.Email.GetMessage(msgType, linkArr);
                message.IsBodyHtml = true;
                message.Bcc.Add(new MailAddress("info@boardhunt.com"));
                //TODO: add more BCC's
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("msg-man@boardhunt.com", RELAY_PASS);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                return false;
            }
        }
/*
 */
        public static bool SendEmailBccArry(string strSub, string to, int msgType, string[] linkArr, IList List)
        {
            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("msg-man@boardhunt.com", "Boardhunt");
                message.To.Add(new MailAddress(to));
                message.Subject = strSub;
                message.Body = BoardHunt.classes.Email.GetMessage(msgType, linkArr);
                message.IsBodyHtml = true;
                int i;
                if (List.Count > 0)
                {
                    for (i = 0; i < List.Count; i++)
                    {
                        message.Bcc.Add(List[i].ToString());
                    }
                }
                message.Bcc.Add("info@boardhunt.com");
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("msg-man@boardhunt.com", RELAY_PASS);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                return false;
            }
        }
/*
 */ 
        public static bool SendCCEmail(string to, string from, string cc, string subj, int msgType, string xtra, bool bcc)
        {
            string[] strArry = new string[] { string.Empty };

            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress(from, "Boardhunt");
                message.To.Add(new MailAddress(to));
                message.CC.Add(new MailAddress(cc));
                message.Subject = subj;
                message.Body = GetMessage(msgType, strArry);    //potential errors here if msgType is other than voucher
                message.Body += "<b>" + xtra + "</b>";
                message.Body = "<div style='Font-Family: Verdana; Font-Size: 10pt'>" + message.Body + "</div>";
                message.IsBodyHtml = true;
                if (bcc)
                {
                    message.Bcc.Add(new MailAddress("info@boardhunt.com"));
                }
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("errorbot@boardhunt.com", RELAY_PASS);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.InnerException);
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                return false;
            }        
        }
/*
 */
        //public static bool SendEmail(string strSub, string to, string msg, bool bcc)
        public static bool SendEmail(string strSub, string to, string from, string msg, bool bcc)
        {
            try
            {
                MailMessage message = new MailMessage();

                //message.From = new MailAddress("boardblog@boardhunt.com", "Boardhunt");
                message.From = new MailAddress(from, "Boardhunt");
                message.To.Add(new MailAddress(to));
                message.Subject = strSub;
                message.Body = "<div style='Font-Family: Verdana; Font-Size: 10pt'>" + msg + "</div>";
                message.IsBodyHtml = true;
                if (bcc)
                {
                    message.Bcc.Add(new MailAddress("info@boardhunt.com"));
                }
                message.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("errorbot@boardhunt.com", RELAY_PASS);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.InnerException);
                ErrorLog.ErrorRoutine(false, "Email.cs:Error sending email: " + ex.Message);
                return false;
            }
        }

/*
 * Used for canned e-mails
 */
        public static string GetMessage(int i, string[] linkArray)
        {

            string mailBody;
            mailBody = "<div style='Font-Family: Verdana; Font-Size: 10pt'>";

             switch (i)
             {
                 case MSG_REG_CONGRATS:
                     mailBody += "Your new Boardhunt account has been created." + "<br><br>";
                     mailBody += "Log in to Boardhunt.com with your e-mail address and password to create board postings.<br><br>";
                     mailBody += "Thanks,<br>";
                     mailBody += "<br>";
                     mailBody += "Boardhunt.com";
                     mailBody += "</div>";
                     break;

                 case MSG_POSTED_COMMENT:
                     mailBody += linkArray[2] + " wrote:" + "<br><br>";
                     mailBody += "\"" + linkArray[1] + "\"" + "<br><br>";
                     mailBody += "Follow this link to reply:<br>";
                     mailBody += "<a href='" + linkArray[0] + "'>" + linkArray[0] + "</a>"; 
                     mailBody += "<br><br>";
                     mailBody += "To control your e-mail notifications login to Boardhunt and view your account profile.";
                     mailBody += "</div>";
                     break;

                 case MSG_THX_FOR_POST:

                     mailBody += "Thanks for posting your <b>" + linkArray[3] + "</b>.<br><br>";
                     mailBody += "<b>Keep this email so you can quickly:</b>" + "<br><br>";
                     mailBody += "View or send to your friends: <br>";
                     mailBody += "<a href='" + linkArray[0] + "'>" + linkArray[0] + "</a>";
                     mailBody += "<br><br>";
                     mailBody += "Sell faster and <font color='green'>BOOST</font> your ad:<br>";
                     mailBody += " Click <a href='http://www.malzook.com/edit_item.aspx?iD=" + linkArray[2] + "&Act=" + linkArray[1] + "'>HERE</a>.";
                     mailBody += "<br><br>";
                     mailBody += "EDIT or REMOVE your ad:<br>";
                     mailBody += " Click <a href='http://www.malzook.com/edit_item.aspx?iD=" + linkArray[2] + "&Act="+ linkArray[1] +"'>HERE</a>.";
                     mailBody += "<br>";
                     mailBody += "IMPORTANT: If you sell you board and want your posting REMOVED, you will need to login to change the status.";
                     mailBody += "<br>";
                     //mailBody += "Donate a board:<br>";
                    // mailBody += "<a href='www.thehiddenwavesfoundation.org'>www.thehiddenwavesfoundation.org</a>";
                     mailBody += "</div>";
                     break;

                 case MSG_THX_FOR_MODEL:

                     mailBody += "Thanks for posting your <b>" + linkArray[3] + "</b> model.<br><br>";
                     mailBody += "<b>Keep this email so you can quickly:</b>" + "<br><br>";
                     mailBody += "View or send to your friends: <br>";
                     mailBody += "<a href='" + linkArray[0] + "'>" + linkArray[0] + "</a>";
                     mailBody += "<br><br>";
                     mailBody += "EDIT or REMOVE your ad:<br>";
                     mailBody += " Click <a href='http://www.malzook.com/edit_item.aspx?iD=" + linkArray[2] + "&Act=" + linkArray[1] + "'>HERE</a>.";
                     mailBody += "<br>";
                     mailBody += "</div>";
                     break;

                 case MSG_THX_QUESTION:
                     mailBody += "Thanks for posting a question to Ask-a-Pro on Boardhunt." + "<br><br>";
                     mailBody += "Here's a link.  Pass it on:<br>";
                     mailBody += "<a href='" + linkArray[0] + "'>" + linkArray[0] + "</a>";
                     mailBody += "<br><br>";
                     mailBody += " - To edit your question, click \"Edit\" in the 'Ask-a-Pro' section after you <a href='http://www.malzook.com/login.aspx'>log in</a>.";
                     mailBody += "</div>";
                     break;

                 case MSG_QUESTION_ANSWERED:
                     mailBody += linkArray[2] + " answered your question." + "<br><br>";
                     mailBody += "Follow this link to read it:<br>";
                     mailBody += "<a href='" + linkArray[0] + "'>" + linkArray[0] + "</a>";
                     mailBody += "<br><br>";
                     mailBody += "To control your e-mail notifications <a href='http://www.malzook.com/login.aspx'>login</a> and edit your question.";
                     mailBody += "</div>";
                     break;

                 case MSG_NOMORE_COUPONS:
                     mailBody += "Your coupon: " + linkArray[0] + " was in high demand and has been consumed entirely." + "<br><br>";
                     mailBody += "Follow this link to renew or to create another coupon:<br>";
                     mailBody += "<a href='www.boardhunt.com/qp/Manager.aspx'>Renew or Create Coupon</a>";
                     mailBody += "<br><br>";
                     mailBody += "</div>";
                     break;

                 case MSG_THX_VOUCHER_GEN:
                     //TODO:
                     break;
                 case MSG_THX_VOUCHER_CC:
                     mailBody = classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailBodySpecific", @"~/Xml/Services.xml");
                     break;
             }
             return mailBody;
        }

    }
}
