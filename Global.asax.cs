using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Net.Mail;
using System.Diagnostics;
using System.Reflection;

namespace BoardHunt 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        private const string RELAY = "localhost";
        private const string RELAY_PASS = "sfcSQJkY";
        private const int RELAY_PORT = 587;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
            //hack to prevent the session restart when temp files and handled (ie. creating, deleting)
            PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            object o = p.GetValue(null, null);
            FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            object monitor = f.GetValue(o);
            MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
            m.Invoke(monitor, new object[] { }); 
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

			ErrorLog.ErrorRoutine(false, "SessionStart: " + Session.SessionID);
            
            Session["MaxLoginAttempts"] = 3;		// Max # of Administrator login attempts
			Session["LoginCount"] = 0;				// not used
			Session["EmailId"] = "unknown";			// user's email handle
			Session["userId"] = "0";				// user's id

            Session["LoggedIn"] = "No";				// Track whether they're logged in or not
            if (Global.CheckLoginCookies(false))
                Session["LoggedIn"] = "Yes";

            Session["AdType"] = "";					//Type of ad; 0 = Sell; 1 = Wanted
            Session["GoToURL"] = "";
            Session["BlogFlg"] = "";                // Blog Flag
            
		}

        protected void SessionReport()
        {
            ErrorLog.ErrorRoutine(false,"Session Report: ID: " + Session.SessionID + " UserId: " + Session["userId"].ToString() + " Email: " + Session["EmailId"].ToString());
        }

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            
                // Check the web.config to see if the site is in maintenance mode
                if (System.Configuration.ConfigurationSettings.AppSettings["Maintenance Mode"] == "on")
                {
                    //string maintPath = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString() + "/maintenance.aspx";
                    HttpContext.Current.RewritePath("maintenance.aspx");
                }             
             
        }

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}
/*
 */ 
		protected void Application_Error(Object sender, EventArgs e)
		{
            //return;

            Exception myError = Server.GetLastError();

            //if (myError.InnerException.ToString().IndexOf("Invalid viewstate") > -1)
            //    return;

            //do a send e-mail here
            //Create an instance of the MailMessage class
            MailMessage mail = new MailMessage();

            //SmtpClient smtpClient = new SmtpClient();//*

            MailAddress fromAddress = new MailAddress("ErrorBot@boardhunt.com", "ErrorBot");
  
            mail.To.Add("pm@boardhunt.com");
            //mail.CC.Add("fm@boardhunt.com");
            mail.From = fromAddress;

            //email format. Can be Text or Html
            mail.IsBodyHtml = false;

            //Set the priority - options are High, Low, and Normal
            mail.Priority = MailPriority.Normal;

            //Set the subject
            mail.Subject = "BH - ERROR";

            string strErrorMsg = "BH Application Error";

            strErrorMsg += "\n\nURL: " + Request.Url;

            // Get the path of the page
            strErrorMsg += "\n\nError in Path :" + Request.Path;

            strErrorMsg += "\n\nReferral URL : " + Request.UrlReferrer;

            // Get the QueryString along with the Virtual Path
            strErrorMsg += "\n\nError Raw Url :" + Request.RawUrl;
            
            // Create an Exception object from the Last error that occurred on the server

            // Get the error message
            strErrorMsg += "\n\nError InnerException :" + myError.InnerException;


            strErrorMsg += "\n\nError Message :" + myError.Message;
            // Source of the message
            strErrorMsg += "\n\nError Source :" + myError.Source;
            // Stack Trace of the error
            strErrorMsg += "\n\nError Stack Trace :" + myError.StackTrace;
            // Method where the error occurred
            strErrorMsg += "\n\nError TargetSite :" + myError.TargetSite;
            
            //Set the body
            mail.Body = strErrorMsg;

            //Smtp Server
            //smtpClient.Host = RELAY;

            string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString();

            try
            {
                //Send the message
                //smtpClient.Send(mail);

                SmtpClient client = new SmtpClient(RELAY, RELAY_PORT);
                client.Credentials = new NetworkCredential("msg-man@boardhunt.com", RELAY_PASS);

                client.Send(mail);

                //show the error screen only for BH site
                if (serverURL == "http://www.malzook.com")
                {

                    ErrorLog.ErrorRoutine(false, "Error: " + strErrorMsg);

                    if (myError.Message.ToString().IndexOf("does not exist") > -1)
                    {
                        //404
                        Server.ClearError();
                        ErrorLog.ErrorRoutine(false, "About to Redirect to error page: 404");
                        //Response.Redirect(serverURL + "/Errors/ErrHandler.aspx?iD=1", true);
                    }
                    else
                    {
                        //other errors
                        Server.ClearError();
                        ErrorLog.ErrorRoutine(false, "About to Redirect to error page: UnhandledException");
                        //Response.Redirect(serverURL + "/Errors/ErrHandler.aspx?iD=2", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error sending errlog e-mail! -- " + ex.Message);
                //Response.Redirect(serverURL, true);

            }

            finally
            {

            }
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{
            ErrorLog.ErrorRoutine(false, "APP_END");

            HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember("_theRuntime",
                                                                                            BindingFlags.NonPublic
                                                                                            | BindingFlags.Static
                                                                                            | BindingFlags.GetField,
                                                                                            null,
                                                                                            null,
                                                                                            null);
            if (runtime == null)
                return;

            string shutDownMessage = (string)runtime.GetType().InvokeMember("_shutDownMessage",
                                                                             BindingFlags.NonPublic
                                                                             | BindingFlags.Instance
                                                                             | BindingFlags.GetField,
                                                                             null,
                                                                             runtime,
                                                                             null);

            string shutDownStack = (string)runtime.GetType().InvokeMember("_shutDownStack",
                                                                           BindingFlags.NonPublic
                                                                           | BindingFlags.Instance
                                                                           | BindingFlags.GetField,
                                                                           null,
                                                                           runtime,
                                                                           null);

            //if (!EventLog.SourceExists(".NET Runtime"))
            //{
            //    EventLog.CreateEventSource(".NET Runtime", "Application");
            //}

            //EventLog log = new EventLog();
            //log.Source = ".NET Runtime";

            string errStr;

            errStr = String.Format("\r\n\r\n_shutDownMessage={0}\r\n\r\n_shutDownStack={1}",
                                         shutDownMessage,
                                         shutDownStack);

            ErrorLog.ErrorRoutine(false, "APP_END: " + errStr);

		}

		public static void AuthenticateUser() 
		{ 

			// Can't navigate to the page unless already logged in.
			// If not already logged in go to login page.
			if (HttpContext.Current.Session["LoggedIn"].ToString() == "No")
			{
                //TODO: make absolute
                string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString();
                
                HttpContext.Current.Response.Redirect(serverURL + "/Login.aspx?m=1",true);
			}
			
		}

        public static void AuthenticateUser(string reqUrl)
        {

            // Can't navigate to the page unless already logged in.
            // If not already logged in go to login page.
            if (HttpContext.Current.Session["LoggedIn"].ToString() == "No")
            {
                HttpContext.Current.Session["GoToURL"] = reqUrl;
                string serverURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"].ToString();

                HttpContext.Current.Response.Redirect(serverURL + "/Login.aspx?m=1", true);
            }

        }


		//Sets the text for the Sign In linkbutton
		public static string SetLnkSignIn( )
		{

			if (HttpContext.Current.Session["LoggedIn"].ToString() == "Yes")
			{
				return "log out";
			}
			else
			{
				return "log in";
			}
		}
		
		//Sets the text for the Sign Up linkbutton
		public static string SetLnkSignUp()
		{
			if (HttpContext.Current.Session["LoggedIn"].ToString() == "Yes")
			{
				return "dashboard";
			}
			else
			{
				return "sign up";
			}		
				
		}

		public static void NavigatePage(string lnkText )
		{

            string theURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
            
            switch (lnkText)
			{
				case "log in":
                    HttpContext.Current.Response.Redirect(theURL + "/login.aspx", true);
					break;
				case "sign up":
                    HttpContext.Current.Response.Redirect(theURL + "/register_user.aspx", true);
					break;
				case "log out":
					HttpContext.Current.Session["LoggedIn"]= "No";
					HttpContext.Current.Session.Abandon();
                    
                    //kill cookies 
                    HttpCookie _userInfo = new HttpCookie("UserInfo");
                    _userInfo["sea"] = null;
                    _userInfo["monkey"] = null;
                    _userInfo.Expires = DateTime.Now.AddYears(-30);
                    HttpContext.Current.Response.Cookies.Add(_userInfo);
                    
                    //TODO: redir only if it's a secured page
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl, true);
					break;
			case "dashboard":
                    HttpContext.Current.Response.Redirect(theURL + "/UserMenu.aspx", true);
					break;
                case "Upgrade":
                    HttpContext.Current.Session["ServiceId"] = "6";
                    HttpContext.Current.Response.Redirect(theURL + "/Pay/OrderForm.aspx", true);
                    break;
			}
		}

        public static void LogoutUser()
        {
            HttpContext.Current.Session["LoggedIn"] = "No";
            HttpContext.Current.Session.Abandon();

            //kill cookies 
            HttpCookie _userInfo = new HttpCookie("UserInfo");
            _userInfo["sea"] = null;
            _userInfo["monkey"] = null;
            _userInfo.Expires = DateTime.Now.AddYears(-30);
            HttpContext.Current.Response.Cookies.Add(_userInfo);

            //if (redir)
            //    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl, true);        
        }

        public static bool CheckLoginCookies(bool hashMe)
        {
            string uName, uPass;
            if (HttpContext.Current.Request.Cookies["UserInfo"] != null)
            {
                uName = HttpContext.Current.Request.Cookies["UserInfo"]["sea"].ToString();
                uPass = HttpContext.Current.Request.Cookies["UserInfo"]["monkey"].ToString();

                classes.Login clsLogin = new classes.Login();
                if (clsLogin.DoLogin(uName, uPass, hashMe, false))
                    return true;
                return false;
            }
            else
            {

            }
            return false;
        }

        public static string GenerateRandomString(int intLenghtOfString)
        {
            //Create a new StrinBuilder that would hold the random string.
            StringBuilder randomString = new StringBuilder();
            //Create a new instance of the class Random
            Random randomNumber = new Random();
            //Create a variable to hold the generated charater.
            Char appendedChar;
            //Create a loop that would iterate from 0 to the specified value of intLenghtOfString
            for (int i = 0; i <= intLenghtOfString; ++i)
            {
                //Generate the char and assign it to appendedChar
                appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                //Append appendedChar to randomString
                randomString.Append(appendedChar);
            }
            //Convert randomString to String and return the result.
            return randomString.ToString();
        }		
        
        public static void CreateMessageAlert(System.Web.UI.Page senderpage , string alertMsg, string alertKey)
		{
			
			string strScript;
			strScript = "<script language=JavaScript>alert('" + alertMsg + "')</script>";
			
			if (!(senderpage.IsStartupScriptRegistered(alertKey)))
			{
				senderpage.RegisterStartupScript(alertKey, strScript);

			}
		}

 /*
        //checks for single HTML opening tag '<'
 */ 
        public static bool CheckForTags(string val)
        {
            if (val == null) return false;

            if (val.IndexOf("<") >= 0)
            {
                return true;
            }
            return false;
        }
/*
 */ 
        //checks for single quotes
        public static string CheckString(string val)
        {
            
            if (val == null)
            {
                return string.Empty;
            }
            
            string val2 = val;

            if (val.IndexOf("'") >= 0)
            {
                val2 = Global.ReplaceEx(val, "'", "\''");
            }
            return val2;
        }
/*
*/
        public static string up1(string s)
        {
            return (s.Length > 0) ? Char.ToUpper(s[0]) + s.Substring(1) : s;
            
        }

/*
*/
        public static string StrReplace(string txt, string pattern)
        {
            return System.Text.RegularExpressions.Regex.Replace(txt, pattern, "").Trim();
        } 
 /*
 */ 
        public static string ProperSpace(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, "[A-Z]", " $&").Trim();
        }
/*
*/
        public static string SwapChar(string targetText, string withChar, string replPattern)
        {
            return System.Text.RegularExpressions.Regex.Replace(targetText, replPattern, " ").Trim();
        }
/*
 */ 
        //Format price with $
        public static string FormatPrice(object priceVal)
        {
            return String.Format("{0:c}", priceVal);

        }
/**
*/ 
        public static string ReplaceEx(string original,
                            string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }
/**
*/
        public static string FormatPhone(string pH)
        {
            string retVal = pH;

            if (retVal.Length >= 11)
            {
                retVal = StrReplace(retVal, "-");
                retVal = retVal.Insert(6, "-");

                //insert dash at 6th char
                retVal = "(" + retVal.Substring(0, 3) + ")" + retVal.Substring(3);
            }
            return retVal;
        }
/*
 */
        public static string ParseEmail(object em)
        {
            string[] arrStr;
            char[] splitter = { '@' };

            arrStr = em.ToString().Split(splitter);
            return arrStr[0];
        }
 
/**
*/
        public static string DecodeCategory(object BoardCode)
        {

            return Enum.GetName(typeof(Global.BOARDCAT_DIRS), BoardCode);

        }
/*
 */
        //Returns truncated string with configurable number of characters
        public static string FormatDetails(object oChunk, int oVal)
        {
            //set cLen to oVal
            int cLen = oVal;

            //get string
            string txtChunk = oChunk.ToString();

            //if the string length is greater than our cut-off pt. prepare to truncate
            if (txtChunk.Length > cLen)
            {

                int n = cLen;

                //check if substring @ cLen pos. is char or whitespace
                if (txtChunk.Substring(n, 1).ToString() != " ")
                {

                    do
                    {
                        n++;
                        if (n == txtChunk.Length) break;

                        if (txtChunk.Substring(n, 1).ToString() == " ")
                        {
                            break;
                        }
                    } while (n < txtChunk.Length);
                }

                //remove characters after cLen chars.
                if (txtChunk.Length > n)
                {
                    txtChunk = txtChunk.Remove(n, txtChunk.Length - n) + "...";
                }
            }
            return txtChunk;
        }
//Helper function to determine if value is numeric
        public static bool IsNumeric(object valType)
        {
            double tempVal = new double();
            string InputValue = Convert.ToString(valType);

            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out tempVal);

            return Numeric;
        } 
/*
 */ 
        public static string GetTimeDiff(object oTm)
        {
            string retVal;
            DateTime dt = Convert.ToDateTime(oTm);
            DateTime dtNow = DateTime.Now;
            TimeSpan ts = dtNow - dt;
            double hr = ts.TotalHours;

            if(hr < 1)
            {
                if (ts.TotalMinutes < 1)
                {
                    retVal = Math.Floor(ts.TotalSeconds) + "secs";
                }
                else
                {
                    retVal = Math.Floor(ts.TotalMinutes) + " mins";
                }
                return retVal + " ago";
            }

            if(hr > 24)
            {
                retVal = Math.Floor(ts.TotalDays) + " days";
            }
            else
            {
                retVal = Math.Floor(ts.TotalHours) + " hours";
            }
            return retVal + " ago";

            
        }

/**
*/ 
	    //Global Enumerations
		//surf only
        public enum FINS {Single=1,Twin,Tri,Quad,More};
		public enum TAIL {Squash=1,Swallow,Pin,Rounded,Bat,Diamond,RoundedPin,Other};
		public enum BOARDTYPE_SURF {Shortboard=1,Longboard=2,FishOrRetro=3,Funshape=4,Gun=5,Other=6,StandupPaddle=24,ProModel=27,Vintage=28,Hybrid=29};
        //snow only
        public enum BOARDTYPE_SNOW {Freeride=7,Freestyle=8,Carve=9};
        //other boards only
        public enum BOARDTYPE_OTHER {Wake=15,Kite,Skim,Paddle,Boogie,Carve, Skateboard=26};
        //categories
		public enum BOARDCAT_TYPE {surfboards=1,snowboards,other_boards,accessories};
        //directory names
        public enum BOARDCAT_DIRS {surfboards=1, snowboards, other, accessories, blog};    //for use with directories only
		//ad types
        public enum AD_TYPE {Selling=1,Wanted};
        //regions
        public enum REGION { CA_Southern = 1, CA_Central, CA_Northern, Carolinas, Colorado, Florida, Hawaii, Oregon, Utah, Montana, NewJersey, NewYork, Virginia, Rhode_Island, Washington, Maryland, Delaware, Texas, Maine, Other_USA_States, UK=25, Argentina=26, Central_America=30,South_America=31,South_Africa=32,New_Zealand=33,Europe=34,Australia=35, Canada=36 };
        //ad types
        public enum CONDITION_TYPE { Used = 1, New, LikeNew };        


		//Global Constants
        public const string SURF_CAT = "surfboards";
		public const string SNOW_CAT = "snowboards";
        public const string OTHER_CAT = "other boards";
        public const string ALL_GEAR = "board gear";

        //acct types
        public const string ACCT_USR = "1";
        public const string ACCT_BIZ = "2";
        public const string ACCT_ADMIN = "3";

        public const string MERCHANT_SHAPER = "1";  //shaper or maunfacturer
        public const string MERCHANT_RETAIL = "2";


        #region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

