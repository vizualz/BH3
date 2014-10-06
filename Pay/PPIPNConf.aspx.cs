using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Data.SqlClient;
using DALLayer;


namespace BoardHunt.Pay
{
    public partial class PPIPNConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load");

            //2. Payment Status Check 
            //In this step, you should check that the "payment_status" form field is "Completed". 
            //This ensures that the customer's payment has been processed by PayPal, and it has been added to the seller's account. 

            //3. Transaction Duplication Check 
            //In this step, you should check that the "txn_id" form field, transaction ID, 
            //has not already been processed by your automation system. A good thing to do is to 
            //store the transaction ID in a database or file for duplication checking. 
            //If the transaction ID posted by PayPal is a duplicate, you should not continue 
            //your automation process for this transaction. Otherwise, this could result in sending the same product to a customer twice. 

            //4. Seller Email Validation 
            //In this step, you simply make sure that the transaction is for your account. 
            //Your account will have specific email addresses assigned to it. You should 
            //verify that the "receiver_email" field has a value that corresponds to an email 
            //associated with your account. 

            //5. Payment Validation 
            //As of now, this step is not listed on other sites as a requirement, but it is very important. Because any customer who is familiar with query strings can modify the cost of a seller's product, you should verify that the "payment_gross" field corresponds with the actual price of the item that the customer is purchasing. It is up to you to determine the exact price of the item the customer is purchasing using the form fields. Some common fields you may use to lookup the item being purchased include "item_name" and "item_number". To see for yourself, follow these steps: 
            //Click on a button used to purchase one of your products. 
            //Locate the "payment_gross" field in the query string and change its value. 
            //Use the changed URL and perform a re-request, typically by hitting [ENTER] in the browser Address Bar. 
            //Notice the changed price for your product on the PayPal order page.

            //Post back to either sandbox or live
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            string strLive = "https://www.paypal.com/cgi-bin/webscr?";

            string txnId;
            string txnType;
            
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:VERIFIED");

                //// *** Success! Finalize your order, send email etc.

                //Item_name = Request.Form("item_name")
                //Item_number = Request.Form("item_number")
                //Payment_status = Request.Form("payment_status")
                //Payment_amount = Request.Form("mc_gross")
                //Payment_currency = Request.Form("mc_currency")
                //Txn_id = Request.Form("txn_id")
                //Receiver_email = Request.Form("receiver_email")
                //Payer_email = Request.Form("payer_email")

                //TYPICAL IPN
                //mc_gross=1.04&invoice=f3d2972&address_status=confirmed&
                //payer_id=LGPXCPBDR6L3L&tax=0.00&address_street=32+Kaiea+Place&
                //payment_date=01%3A44%3A51+Sep+02%2C+2004+PDT&payment_status=Completed&
                //address_zip=96779&first_name=Frederik&mc_fee=0.33&
                //address_name=Frederik+Strahl&notify_version=1.6&
                //custom=&payer_status=unverified&business=rstrahl%40west-wind.com&
                //address_country=United+States&address_city=Paia&
                //quantity=1&payer_email=rickstrahl%40hotmail.com&
                //verify_sign=AEXSm3Liw0MGNI363IuRPYv10swA&
                //payment_type=instant&last_name=Strahl&address_state=HI&
                //receiver_email=rstrahl%40west-wind.com&payment_fee=0.33&
                //receiver_id=T2HZ2XA7RCUCL&txn_type=web_accept&
                //item_name=West+Wind+Web+Store+Invoice+%23f3d2972&
                //mc_currency=USD&item_number=&payment_gross=1.04

                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment
                ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:FormVarCount: " + Request.Form.Count);

                string itemName = Request.Form["item_name"].ToString();         //Service = 1, iEntryId; Service = 2, iUserId; Service = 3, iUserId; Service = 4, iEntryId(CouponId) ***THIS IS WHAT WE ACTIVE ON***
                string itemNumber = Request.Form["item_number"].ToString();     //Service ID 1=BOOST, 2=Bidder Subscription, 3=ShaperHouse, 4=Coupons
                string invoice = Request.Form["invoice"].ToString();
                
                ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:Invoice: " + invoice);


                if (Request.Form["txn_id"] != null)
                {
                    txnId = Request.Form["txn_id"].ToString();
                }
                else
                {
                    txnId = "0";
                    return; // or else paypal will keep sending requests
                }

                if (Request.Form["txn_type"] != null)
                {
                    txnType = Request.Form["txn_type"].ToString();
                    ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:txn_type: " + txnType);
                }

                //***Possible values for txn_type***
                //subscr_signup - a subscriber has signed up for the service
                //subscr_payment - a subscriber has paid for the service
                //subscr_failed - a subscriber tried to pay for the service but things didn't work out
                //subscr_cancelled - a subscriber cancelled a subscription
                //subscr_eot - a subscriber has reached the end of the subscription term
                //subscr_modify - a subscriber profile has been modified

                string[] arrStr;
                arrStr = itemNumber.Split('-');

                //int pos = itemNumber.IndexOf("-");
                //itemName = itemNumber.Substring(pos + 1);
                
                //SMS Coupon Invice #: BH04-162-JURJIQX
                //Item # BHWEB-04-tblServiceId

                //Surf Coupons Invoice# BH04-1621-PJKKZ[R
                //Item# BHWEB-4-220

                if (itemName != null)
                {
                    if (ActivateService(arrStr, txnId, invoice))
                    {
                        switch (arrStr[1])  //serviceId
                        {
                            //BOOST
                            case "1":
                                //PostProcessing & Send congrats e-mail:  Upgrade boards the new way
                                string[] arrStr2;
                                arrStr2 = itemNumber.Split('-'); //BHWEB-1-104-1249

                                UpgradeBoardsForUser(invoice, 0, Convert.ToInt32(arrStr2[4]));  //need to somehow get boardID
                                classes.Email.SendEmail("Boosted Posting", "info@boardhunt.com", "Posting: " + itemName + " was BOOSTED.");
                                break;
                            //BIDDER
                            case "2":
                                classes.Email.SendEmail("Subscription Activated", "info@boardhunt.com", "Activated subscription for id: " + itemName + " successfully.");
                                break;
                            //ShaperHouse
                            case "3":
                                //TODO: set iStatus = 1 here for shaper?
                                classes.Email.SendEmail("ShaperHouse Account Activated", "info@boardhunt.com", "The ShaperHouse account was activated for id: " + itemName + ".");
                                break;
                            case "4":
                                if (ActivateCoupon(arrStr))
                                    classes.Email.SendEmail("Coupon Activated", "info@boardhunt.com", "The SMS Mobile Coupon campaign has been activated for: " + itemName + ".");
                                else
                                    classes.Email.SendErrorEmail("Coupon activation failed for tblServiceId: " + arrStr[2]);
                                break;
                            case "5":
                                classes.Email.SendEmail("Voucher Purchase", "info@boardhunt.com", "Voucher: " + itemName + " was purchased.");
                                break;
                            case "6":
                                UpgradeBoardsForUser(invoice, 1, 0);
                                classes.Email.SendEmail("Membership Upgrade - 1 Year", "info@boardhunt.com", "Membership: " + itemName + " was purchased.");
                                break;
                            case "7":
                                UpgradeBoardsForUser(invoice, 1, 0);
                                classes.Email.SendEmail("Membership Upgrade - 3 Months", "info@boardhunt.com", "Membership: " + itemName + " was purchased.");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //Notify BH of update failure
                        classes.Email.SendEmail("Service activation failed", "info@boardhunt.com", "Service: " + itemNumber + " Posting: " + itemName + " failed.");
                    }
                }
                else
                    ErrorLog.ErrorRoutine(false, "Missing item # for Txn");
            }
            else if (strResponse == "INVALID")
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:INVALID");
                classes.Email.SendErrorEmail("PayPal IPN failure");
                //log for manual investigation
            }
            else
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:Page_Load:" + strResponse);
                //log response/ipn data for manual investigation
            }

        }

        //private void UpgradeBoardsForUser(string num, bool invoice, int all, int boardId)
        private void UpgradeBoardsForUser(string invoice, int all, int boardId)
        {
            //This function will Boost all boards.  UseCase: when a user upgrades his account to Pro.

            //should never happen
            if (invoice.Length < 1)
                return;

            string[] arrStr;
            arrStr = invoice.Split('-');    //arrstr[1] holds the userID

            //call sproc with [1] array val to activate
            //check for pro and.. 
            BoardHunt.wsBH.BHService oWS = new BoardHunt.wsBH.BHService();
            oWS.ToggleBoostStatus(Convert.ToInt32(arrStr[1]), all, boardId, 1); 

        }

        // This helper method encodes a string correctly for an HTTP POST
        private string Encode(string oldValue)
        {
            string newValue = oldValue.Replace("\"", "'");
            newValue = System.Web.HttpUtility.UrlEncode(newValue);
            newValue = newValue.Replace("%2f", "/");
            return newValue;
        }
/*
 */ 
        private bool ActivateService(string[] sArry , string txnVal, string invoice)
        {
            //TODO: verify unique Txn
            //VerifyUniqTxn();

            //sArry[] = [0] = BHWEB, [1] = ServiceVal, [2] = unique tblId

            //EXAMPLE:
            //Surf Coupons Invoice# BH04-1621-PJKKZ[R
            //Item# BHWEB-4-220

            int rtn;
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //iStatus should be 0 and txn_id (from PP) should be empty or null
            strSQL = "UPDATE tblServices SET iStatus = '1', txn_id='" + txnVal + "'";
            strSQL += " WHERE iServiceVal ='" + sArry[1] + "' AND iD = '" + sArry[2].ToString() + "'";

            try
            {
                dbManager.Open();
                rtn = dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                ErrorLog.ErrorRoutine(false, "PPIPN:ActivateService:Return Val: " + rtn);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:ActivateService:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "PPIPN:ActivateService:strSQL: " + strSQL);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }           
        }
/*
 */
        private bool FinalizeVoucher(string[] sArry)
        {
            //sArry[] = [0] = BHWEB, [1] = ServiceVal, [2] = unique tblId
            //send email to shaper

            //Surf Coupons Invoice# BH04-1621-PJKKZ[R
            //Item# BHWEB-4-220

            int rtn;
            string strSQL;
            string strSubQry;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblCoupon SET iStatus = '1', iPublish= '1', smsLiveCnt = smsPkgCnt";
            strSubQry = "(SELECT iEntryId FROM tblServices WHERE iD = '" + sArry[2] + "')";
            strSQL += " WHERE iD =" + strSubQry;

            try
            {
                dbManager.Open();
                rtn = dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;

                //classes.Email.SendEmail("Your Boardhunt Surfboard Voucher", "info@boardhunt.com", "The SMS Mobile Coupon campaign has been activated for: " + itemName + ".");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:FinalizeVoucher:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "PPIPN:FinalizeVoucher:strSQL: " + strSQL);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


        }
/*
 */
        private bool ActivateCoupon(string[] sArry)
        {
            //sArry[] = [0] = 'BHWEB', [1] = ServiceVal, [2] = unique tblId

            //Surf Coupons Invoice# BH04-1621-PJKKZ[R
            //Item# BHWEB-4-220

            int rtn;
            string strSQL;
            string strSubQry;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "UPDATE tblCoupon SET iStatus = '1', iPublish= '1', smsLiveCnt = smsPkgCnt";
            strSubQry = "(SELECT iEntryId FROM tblServices WHERE iD = '" + sArry[2] + "')";
            strSQL += " WHERE iD =" + strSubQry;

            try
            {
                dbManager.Open();
                rtn = dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "PPIPN:ActivateCoupon:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "PPIPN:ActivateCoupon:strSQL: " + strSQL);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        } 

    }
}
