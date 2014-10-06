using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BoardHunt.classes.PP
{
    public class PayPalHelper
    {

        public string LogoUrl = "http://www.malzook.com/images/BHLogo.gif";
		public string AccountEmail = "";
		public string BuyerEmail = "";
		public string SuccessUrl = "";
		public string CancelUrl = "";
		public string ItemName = "";
        public string ItemNumber = "";
		public decimal Amount = 0.00M;  //doubles up as a3 (amount for subscription)
		public string InvoiceNo = "";
        public string rm = "2";

        //Subscritption variables
        public bool subscription = false;
        public string no_note = "1";    //flag to hide text box for note
        public string p3 = "12";        //subscription duration
        public string t3 = "M";         //units of duration Days, Weeks, Months, Years
        public string src = "1";        //recurring option: Recurring payments. If set to “1,” the payment will recur unless your customer cancels the subscription before the end of the billing cycle

        //public decimal SubscriptionPrice;
		//paypal live
		//public string PayPalBaseUrl = "https://www.paypal.com/cgi-bin/webscr?";
        
        //sandbox
        public string PayPalBaseUrl = string.Empty;
        //public string PayPalBaseUrl = "https://www.sandbox.paypal.com/us/cgi-bin/webscr?";
		public string LastResponse = "";

		public PayPalHelper()
		{

		}

        //For one time buys like BOOST without recurring payments
		public string GetSubmitUrl()
		{
			StringBuilder	url	= new StringBuilder();

			url.Append( this.PayPalBaseUrl + "cmd=_xclick&business="+
				HttpUtility.UrlEncode( AccountEmail ) );

			if( BuyerEmail != null && BuyerEmail != "" )
				url.AppendFormat( "&email={0}", HttpUtility.UrlEncode( BuyerEmail ) );

			if (Amount != 0.00M) 
				url.AppendFormat("&amount={0:f2}", Amount);

			if( LogoUrl != null && LogoUrl != "" )
				url.AppendFormat( "&image_url={0}", HttpUtility.UrlEncode( LogoUrl ) );

			if( ItemName != null && ItemName != "" )
				url.AppendFormat( "&item_name={0}", HttpUtility.UrlEncode( ItemName ) );

            if (ItemNumber != null && ItemNumber != "")
                url.AppendFormat("&item_number={0}", HttpUtility.UrlEncode( ItemNumber ));

			if( InvoiceNo  != null && InvoiceNo != "" )
				url.AppendFormat( "&invoice={0}", HttpUtility.UrlEncode( InvoiceNo ) );

			if( SuccessUrl != null && SuccessUrl != "" )
				url.AppendFormat( "&return={0}", HttpUtility.UrlEncode( SuccessUrl ) );

			if( CancelUrl != null && CancelUrl != "" )
				url.AppendFormat( "&cancel_return={0}", HttpUtility.UrlEncode( CancelUrl ) );

            if (rm != null && rm != "")
                url.AppendFormat("&rm={0}", HttpUtility.UrlEncode(rm));

			return url.ToString();
		}
        
        //Subscription and reccuring payments *** Related to bidder & shapers
        public string GetSUBSubmitUrl()
        {
        //The minimum variables needed are as follows:
        //Code:
        //<form target="paypal" action="https://www.paypal.com/cgi-bin/webscr" method="post">
        //name="cmd" value="_xclick-subscriptions">
        //name="business" value="YourEmail@Domain.com">
        //name="item_name" value="subscribe test">
        //name="no_note" value="1">
        //name="a3" value="30.00">
        //name="p3" value="1">
        //name="t3" value="D">

        //SAMPLE 2*********************
        //<form action="https://www.paypal.com/cgi-bin/webscr" method="post">
        //<input type="hidden" name="cmd" value="_xclick-subscriptions">
        //<input type="hidden" name="business" value="vizualz@hotmail.com">
        //<input type="hidden" name="lc" value="US">
        //<input type="hidden" name="item_name" value="BIDDER">
        //<input type="hidden" name="a3" value="69.00">
        //<input type="hidden" name="currency_code" value="USD">
        //<input type="hidden" name="src" value="1">
        //<input type="hidden" name="p3" value="1">
        //<input type="hidden" name="t3" value="M">
        //<input type="hidden" name="srt" value="12">
        //<input type="hidden" name="sra" value="1">
        //<input type="hidden" name="bn" value="PP-SubscriptionsBF:btn_subscribeCC_LG.gif:NonHostedGuest">
        //<input type="image" src="https://www.paypal.com/en_US/i/btn/btn_subscribeCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
        //<img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">
        //</form>


//*********************
        // optional variables 
         
        //"src" = Recurring payments. If set to "1," the payment will reoccur unless your customer cancels 
        //the subscription before the end of the billing cycle. If omitted, the subscription payment will not reoccur at the end of the billing cycle. 
         
        //"sra" = Re-attempt on failure. If set to "1," and the payment fails, the payment will be re-attempted two more times. 
        //After the third failure, the subscription will be cancelled. If omitted and the payment fails, payment will not be re-attempted and the subscription will be immediately cancelled. 
         
        //"srt" = Recurring Times. This is the number of payments which will occur at the regular rate. If omitted, payment will continue 
        //to reoccur at the regular rate until the subscription is cancelled. The rest of the variables can be found here.

            StringBuilder url = new StringBuilder();

            url.Append(this.PayPalBaseUrl + "cmd=_xclick-subscriptions");
            
            if (AccountEmail != null && AccountEmail != "")
                url.AppendFormat("&business={0}", HttpUtility.UrlEncode(AccountEmail));

            if (BuyerEmail != null && BuyerEmail != "")
            {
                url.AppendFormat("&email={0}", HttpUtility.UrlEncode(BuyerEmail));
                url.AppendFormat("&login_email={0}", HttpUtility.UrlEncode(BuyerEmail));
            }

            if (Amount != 0.00M)
                url.AppendFormat("&a3={0:f2}", Amount); //rate
            
            if (P3 != null && P3 != "")
                url.AppendFormat("&p3={0:f2}", P3); //Regular billing cycle

            if (T3 != null && T3 != "")
                url.AppendFormat("&t3={0:f2}", T3); //Regular billing cycle units Days, Weeks, Mos, Yrs

            if (LogoUrl != null && LogoUrl != "")
                url.AppendFormat("&image_url={0}", HttpUtility.UrlEncode(LogoUrl));

            if (ItemName != null && ItemName != "")
                url.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(ItemName));

            if (ItemNumber != null && ItemNumber != "")
                url.AppendFormat("&item_number={0}", HttpUtility.UrlEncode(ItemNumber));

            if (InvoiceNo != null && InvoiceNo != "")
                url.AppendFormat("&invoice={0}", HttpUtility.UrlEncode(InvoiceNo));

            if (SuccessUrl != null && SuccessUrl != "")
                url.AppendFormat("&return={0}", HttpUtility.UrlEncode(SuccessUrl));

            if (CancelUrl != null && CancelUrl != "")
                url.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(CancelUrl));

            if (no_note != null && no_note != "")
                url.AppendFormat("&no_note={0}", HttpUtility.UrlEncode(no_note));

            if (src != null && src != "")
                //url.AppendFormat("&src={0}", HttpUtility.UrlEncode(src));            

            if (rm != null && rm != "")
                url.AppendFormat("&rm={0}", HttpUtility.UrlEncode(rm));

            ErrorLog.ErrorRoutine(false, "PPH:GetSubmitURL: " + url.ToString());

            return url.ToString();
        }

		/// <summary>
		/// Posts all form variables received back to PayPal. This method is used on 
		/// is used for Payment verification from the 
		/// </summary>
		/// <returns>Empty string on success otherwise the full message from the server</returns>
		public bool IPNPostDataToPayPal(string PayPalUrl,string PayPalEmail) 
		{			
			HttpRequest Request = HttpContext.Current.Request;
			this.LastResponse = "";

			// *** Make sure our payment goes back to our own account
			string Email = Request.Form["receiver_email"];

            ErrorLog.ErrorRoutine(false, "PayPalHelper:IPNPostDataToPayPal:Email: " + Email);

            //verify e-mail
            if (Email == null || Email.Trim().ToLower() != PayPalEmail.ToLower()) 
			{
				this.LastResponse = "Invalid receiver email";
                ErrorLog.ErrorRoutine(false, "Email mismatch - PayPalHelper:IPNPostDataToPayPal: " + this.LastResponse);
				return false;
			}
	
			wwHttp Http = new wwHttp();
			Http.AddPostKey("cmd","_notify-validate");

            foreach (string postKey in Request.Form)
            {
                ErrorLog.ErrorRoutine(false,"PostKey: " + postKey);
                Http.AddPostKey(postKey, Request.Form[postKey]);
                
            }

			// *** Retrieve the HTTP result to a string
			this.LastResponse = Http.GetUrl(PayPalUrl);

            ErrorLog.ErrorRoutine(false, "PayPalHelper:LastResponse: " + this.LastResponse);

            if (this.LastResponse == "VERIFIED")
            {
                return true;
            }
			return false;
		}

        //====================================================================
        //Properties
        //====================================================================
/*
 */ 
        public bool Subscription
        {
            get { return subscription; }
            set { subscription = value; }
        }
/*
 */ 
        public string P3
        {
            get { return p3; }
            set { p3 = value; }
        }
/*
 */ 
        public string T3
        {
            get { return t3; }
            set { t3 = value; }
        }
    }
}
