using System;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

namespace BoardHunt.classes.Mobile
{
    public class Sms
    {
        private string phoneNum;
        private string subj;
        private string msg;
        private string msgType; //express=1, standard=?
        private string user;
        private string pw;

        public Sms()
        {
            user = "vizualz";
            pw = "r4t%y6";
            msgType = "MessageTypeID=1"; //"express=1";
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        public string Subj
        {
            get { return subj; }
            set { subj = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Pw
        {
            get { return pw; }
            set { pw = value; }
        }


        public string CheckBalance()
        {

            string qStr = string.Empty;
            string ret = string.Empty;

            WebRequest w = WebRequest.Create("https://app.eztexting.com/api/credits/check/");

            w.Method = "POST";
            w.ContentType = "application/x-www-form-urlencoded";

            pw = classes.PP.wwHttpUtils.UrlEncode(pw);
            qStr = "User=" + user + "&Pass=" + pw;

            using (Stream writeStream = w.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(qStr);
                writeStream.Write(bytes, 0, bytes.Length);
            }

            using (HttpWebResponse r = (HttpWebResponse)w.GetResponse())
            {
                using (Stream responseStream = r.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        ret = readStream.ReadToEnd();
                    }
                }
            }
            return ret; /* result of API call*/
        
        }

        public string EzSendREST()
        {
            bool isSuccesResponse = true;
            string ret = string.Empty;
            string qStr = string.Empty;
            WebRequest w = WebRequest.Create("https://app.eztexting.com/sending/messages?format=json");
            w.Method = "POST";
            w.ContentType = "application/x-www-form-urlencoded";

            msg = classes.PP.wwHttpUtils.UrlEncode(msg);
            subj = classes.PP.wwHttpUtils.UrlEncode(subj);

            //qStr = "user=" + user + "&pass=" + pw + "&phonenumber=" + phoneNum + "&subject=" + subj + "&message=" + msg + "&" + msgType;
            //msg = "booyaKid";

            qStr = "User=" + user + "&Password=" + pw + "&PhoneNumbers[]=" + phoneNum + "&Subject=" + subj + "&Message=" + msg + "&" + msgType;

            using (Stream writeStream = w.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(qStr);
                writeStream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                using (HttpWebResponse r = (HttpWebResponse)w.GetResponse())
                {
                    ret = GetResponseString(r);
                }
            }
            catch (System.Net.WebException ex)
            {
                isSuccesResponse = false;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    ret = GetResponseString(ex.Response);
                }
            }

            return ret;

            //System.Runtime.Serialization.Json
            //System.Web.SJavaScriptSerializer js = new JavaScriptSerializer();

            //// use free Json.NET library (http://json.codeplex.com/) for JSON handling
            //JObject response = JObject.Parse(ret);

            //System.Console.Out.WriteLine("Status: " + response.SelectToken("Response.Status"));
            //System.Console.Out.WriteLine("Code: " + response.SelectToken("Response.Code"));
            //if (isSuccesResponse)
            //{
            //    System.Console.Out.WriteLine("Message ID: " + response.SelectToken("Response.Entry.ID"));
            //    System.Console.Out.WriteLine("Subject: " + response.SelectToken("Response.Entry.Subject"));
            //    System.Console.Out.WriteLine("Message: " + response.SelectToken("Response.Entry.Message"));
            //    System.Console.Out.WriteLine("Message Type ID: " + response.SelectToken("Response.Entry.MessageTypeID"));
            //    System.Console.Out.WriteLine("Total Recipients: " + response.SelectToken("Response.Entry.RecipientsCount"));
            //    System.Console.Out.WriteLine("Credits Charged: " + response.SelectToken("Response.Entry.Credits"));
            //    System.Console.Out.WriteLine("Time To Send: " + response.SelectToken("Response.Entry.StampToSend"));
            //    System.Console.Out.WriteLine("Phone Numbers: " + response.SelectToken("Response.Entry.PhoneNumbers"));
            //    System.Console.Out.WriteLine("Locally Opted Out Numbers: " + response.SelectToken("Response.Entry.LocalOptOuts"));
            //    System.Console.Out.WriteLine("Globally Opted Out Numbers: " + response.SelectToken("Response.Entry.GlobalOptOuts"));
            //}
            //else
            //{
            //    System.Console.Out.WriteLine("Errors: " + response.SelectToken("Response.Errors"));
            //}
        }

        static string GetResponseString(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                {
                    return readStream.ReadToEnd();
                }
            }
        }        


        public string Send()
        {
        //https://app.eztexting.com/sending/messages?format=json
        //Host: app.eztexting.com
        //Content-Length: 65
        //Pragma: no-cache
        //Content-Type: application/x-www-form-urlencoded
        //User=vizualz&Password=r4t%y6&PhoneNumbers[]=8583424630&Message=hi
            
            string ret = string.Empty;
            string qStr = string.Empty;


            WebRequest w = WebRequest.Create("https://app.eztexting.com/api/sending/");
            w.Method = "POST";
            w.ContentType = "application/x-www-form-urlencoded";

            msg = classes.PP.wwHttpUtils.UrlEncode(msg);
            subj = classes.PP.wwHttpUtils.UrlEncode(subj);

            //qStr = "user=" + user + "&pass=" + pw + "&phonenumber=" + phoneNum + "&subject=" + subj + "&message=" + msg + "&" + msgType;
            
            //msg = "booyaKid";
            qStr = "user="+user+"&pass="+pw+"&phonenumber="+phoneNum+"&subject="+subj+"&message="+msg+"&"+msgType;
            ErrorLog.ErrorRoutine(false, "qStr:" + qStr);

            //:qStr:user=vizualz&pass=r4t%y6&phonenumber=8583424630&subject=%2450+off&message=%2450+off+all+radical+boards+%7C+SpecialCode%3Abc001+%7C+Good+thru+&express=1

            using (Stream writeStream = w.GetRequestStream())
            {
                //byte[] bytes = Encoding.UTF8.GetBytes("user=exampleuser&pass=texting&phonenumber=3616885766&subject=test&message=test message&express=1");
                byte[] bytes = Encoding.UTF8.GetBytes(qStr);
                writeStream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse r = (HttpWebResponse)w.GetResponse())
            {
                using (Stream responseStream = r.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        ret = readStream.ReadToEnd();
                    }
                }
            }
            return ret;
        
        }
    }
}

//1 Message sent 
//-1 Invalid user and/or password or API is not allowed for your account 
//-2  Credit limit reached 
//-5  Local opt out (the recipient/number is on your opt-out list.) 
//-7  Invalid message or subject (exceeds maximum number of characters and/or contains invalid characters - see a list of valid characters below) 
//-104 Globally opted out phone number (the phone number has been opted out from all messages sent from our short code) 
//-106  Incorrectly formatted phone number (number must be 10 digits) 
//-10 Unknown error (please contact our support dept.) 