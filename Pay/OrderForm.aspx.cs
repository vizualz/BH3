using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.XPath;
using DALLayer;


namespace BoardHunt.Pay
{
    public partial class OrderForm : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        
        protected string ORDER_ERR_MSG = @"Whoa! Something happened with your order.  
                                            Our team of geeks are working on a fix.<br>Try again shortly.&nbsp;&nbsp;Click <a href='../UserMenu.aspx'>HERE</a>&nbsp;to return to main menu.";
        
        protected string ORDER_PAGE_TITLE_SRVC_1 = @"Boost Your Board";

        protected string ORDER_PAGE_TITLE_SRVC_3 = @"";
        protected string ORDER_PAGE_TITLE_SRVC_4 = @"";
        protected string PROMO_SMS_CREDITS = "10";
        
        protected const string SVCS_BOOST =             "1";
        protected const string SVCS_BID =               "2";
        protected const string SVCS_SHAPERHOUSE =       "3";
        protected const string SVCS_COUPON =            "4";
        protected const string SVCS_VOUCHER =           "5";
        protected const string SVCS_MEMBERSHIP_YR =     "6";
        protected const string SVCS_MEMBERSHIP_3MOS =   "7";

//                                lblItemDesc.Text = @"<span class='midgrey12b'>You'll get...</span><br />
//                                                &nbsp;&nbsp;<span class='dkgrey12'>- Hundreds of more pageviews</span><br />
//                                                &nbsp;&nbsp;<span class='dkgrey12'>- Visibility across the entire site</span> <br />
//                                                &nbsp;&nbsp;<span class='dkgrey12'>- More attention than the other boards for sale</span><br />";
                            
        
        /// <summary>
        /// Required internal variable that lets us know if
        /// we are returning from PayPal. This flag can be used
        /// to bypass other processing that might be happening
        /// for Credit Cards or whatever.
        /// 
        /// This gets set by HandlePayPalReturn. Not used in this
        /// demo. Refer to article to see how it's used in a more
        /// complex environment.
        /// </summary>
        private bool PayPalReturnRequest = false;


        //TODO: Invoice Object
        
        /// <summary>
        /// Our ever so complicated ORDER DATA. Hey this is supposed to be 
        /// a quick demo and skeleton, so I kept it as simple as possible.
        /// The article shows a more complex environment!
        /// </summary>
        protected decimal OrderAmount = 0.00M;
        protected decimal SubTotal = 0.00M;
        protected decimal UnitPrice = 0.00M;

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
            this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
            this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arString;

            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                // Put user code to initialize the page here
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                pnlError.Visible = false;
                lblErrorMessage.Text = string.Empty;
                lblErrorMessage.Visible = false;

                //TODO: check upgrade item id later
                if (Session["ServiceId"] == null)
                {
                    ErrorLog.ErrorRoutine(false, "OrderForm:PageLoad:NULL ServiceId");
                    classes.Email.SendErrorEmail("Orderform:ServiceId was NULL");
                    ShowError(ORDER_ERR_MSG, true);
                    return;
                }

                hdnServiceVal.Value = Session["ServiceId"].ToString();
                hdnUserDir.Value = Session["userDir"].ToString();

                switch (Session["ServiceId"].ToString())
                {
                    case SVCS_COUPON:
                        LoadOrder();
                        txtQuantity.Visible = true;
                        lblQuantity.Visible = false;
                        break;
                    case SVCS_VOUCHER:
                        FillControls();
                        LoadService();
                        txtQuantity.Visible = false;
                        lblQuantity.Visible = true;
                        cboItemList.Visible = true;
                        lblItemTitle.Visible = true;
                        //cboshaper.visible = true;
                        break;
                    case SVCS_MEMBERSHIP_YR:
                        FillProCtl();
                        LoadService();
                        txtQuantity.Visible = false;
                        lblQuantity.Visible = true;
                        cboItemList.Visible = true;
                        lblItemTitle.Visible = true;
                        cboItemList.SelectedIndex = 1;
                        break;
                    case SVCS_MEMBERSHIP_3MOS:
                        FillProCtl();
                        LoadService();
                        txtQuantity.Visible = false;
                        lblQuantity.Visible = true;
                        cboItemList.Visible = true;
                        lblItemTitle.Visible = true;
                        cboItemList.SelectedIndex = 0;

                        break;
                    default:
                        LoadService();
                        break;
                }   

            }

            // Cheack and handle a return from PayPal
            arString = Request.QueryString.GetValues("PayPal");
            if (arString != null)
            {
                //what do we have for session variables???
                this.HandlePayPalReturn();
            }

            //TODO: UI tweaks for serviceIDs
            //Hide posting
            lnkPost.Visible = false;
        }
/*
 */
        protected void FillProCtl()
        {
            cboItemList.Items.Clear();
            cboItemList.Items.Add(new ListItem("3 Month Membership - $9", "3"));
            cboItemList.Items.Add(new ListItem("1 Year Membership - $19", "12"));
            cboItemList.AutoPostBack = true;

            //if(Session["ServiceId"]
            

        }
/*
 */
        protected void FillControls()
        {

        //get shapers who are active and iVoucher = 1;
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @"SELECT u.txtBrandName, u.iD from tblUser u 
                        INNER JOIN tblServices s ON u.iD = s.iUserId
                        WHERE  u.iVoucher = 1 AND u.iAcctType = 2 AND u.iMerchantType = 1 AND s.iServiceVal = 3 AND s.iStatus = 1
                        ORDER BY u.txtBrandName ASC";

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                //Create and add the (default) "All" entry
                ListItem liAllAcctType = new ListItem("Any Listed Shaper", "-1");  //acctTypes
                //liAllAcctType.Attributes.CssStyle = "";

                //Filter
                cboItemList.Items.Clear();
                cboItemList.DataSource = dbManager.DataReader;//dsItems.Tables[0];
                cboItemList.DataTextField = "txtBrandName";
                cboItemList.DataValueField = "iD";
                cboItemList.DataBind();

                cboItemList.Items.Add(liAllAcctType);
                cboItemList.ClearSelection();
                cboItemList.SelectedIndex = cboItemList.Items.Count - 1;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:RegisterDBEntry:Error:" + ex.Message);
                classes.Email.SendErrorEmail("OrderForm:FillControls: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

/*
 */
        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["ServiceId"] != null)
            {
                if (Session["ServiceId"].ToString() == "6" || Session["ServiceId"].ToString() == "7")
                {
                    if (cboItemList.SelectedIndex == 0)
                    {
                        Session["ServiceId"] = "7";
                        hdnServiceVal.Value = "7";
                        LoadService();
                    }
                    else
                    {
                        Session["ServiceId"] = "6";
                        hdnServiceVal.Value = "6";
                        LoadService();
                    }
                }
            }
            ErrorLog.ErrorRoutine(false, "SelectedIndexChanged!");
        }

/*
 */
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            this.OrderAmount = decimal.Parse(Session["TxnOrderAmount"].ToString());

            //Validate order
            if (this.OrderAmount <= (decimal)0)
            {
                this.ShowError(ORDER_ERR_MSG, true);
                ErrorLog.ErrorRoutine(false, "OrderAmount was 0");
                return;
            }

            // *** Dumb ass data simulation - this should only be set once the order is Validated!
            this.Session["OrderAmount"] = this.OrderAmount; //Session["OrderAmount"] doesn't seem to be used

            //Register the entry in the tblServices and go to Paypal if we haven't already
            if (!this.PayPalReturnRequest)
            {
                //force user to make choose referal
                if (Session["ServiceId"].ToString() == SVCS_VOUCHER)
                {
                    if (cboRefer.SelectedValue == "-1")
                    {
                        pnlError.Visible = true;
                        lblErrorMessage.Text = "How did you hear about surfboard voucher?";
                        lblErrorMessage.Visible = true;
                        cboRefer.BackColor = Color.Pink;
                        return;
                    }
                }
                //TODO: log the referral


                //Lets go to PayPal site
                this.HandlePayPalRedirection(); // this will end this request!
                ShowError(this.ORDER_ERR_MSG, true);
                ErrorLog.ErrorRoutine(false, "Error: Failed HandlePayPalRedirection");
                return;
            }

            //TODO: Destroy session vars for invoice
            Session.Remove("TxnOrderAmount");
            Session.Remove("TxnItemId");

            // *** Show the confirmation page - don't transfer so they can refresh without error
            Response.Redirect("Confirmation.aspx?iD=" + Session["ServiceId"].ToString(),true);
        }
/*
 */
        protected void btnSubscribe_Click(object sender, EventArgs e)
        {

            //TODO: Viewstate stuff //BREAK!
            this.OrderAmount = decimal.Parse(Session["TxnOrderAmount"].ToString());

            //Validate order
            if (this.OrderAmount <= (decimal)0)
            {
                this.ShowError(ORDER_ERR_MSG, true);
                return;
            }

            // *** Dumb ass data simulation - this should only be set once the order is Validated!
            this.Session["OrderAmount"] = this.OrderAmount;//Session["OrderAmount"] doesn't seem to be used

            //Register the entry in the tblServices and go to Paypal if we haven't already
            if (!this.PayPalReturnRequest)
            {
                //Registry the entry but DO NOT activate (pStatus).  Authentic activation will be done on PPIPNConf Page.
                RegisterTxnEntry(false,"SUBSCRIBE_TEST", true);

                //lets go to PayPal site
                this.HandlePayPalRedirection(); // this will end this request!
            }

            // *** Show the confirmation page - don't transfer so they can refresh without error
            Response.Redirect("Confirmation.aspx?iD=" + Session["ServiceId"].ToString(), false);
        }

        /// <summary>
        /// Redirects the current request to the PayPal site by passing a querystring.
        /// PayPal then should return to this page with ?PayPal=Cancel or ?PayPal=Success
        /// This routine stores all the form vars so they can be restored later
        /// ***GOES TO PAYPAL***
        /// </summary>
        private void HandlePayPalRedirection()
        {
            // *** Set a flag so we know we redirected
            Session["PayPal_Redirected"] = "True";

            // *** Save any values you might need when you return here
            // *** NOT USED
            Session["PayPal_OrderAmount"] = this.OrderAmount;  // already saved above

            //Session["PayPal_HeardFrom"] = this.txtHeardFrom.Text;
            //Session["PayPal_ToolUsed"] = this.txtToolUsed.Text;

            classes.PP.PayPalHelper PayPal = new classes.PP.PayPalHelper();
            classes.Invoice oInv = new classes.Invoice();

            PayPal.PayPalBaseUrl = classes.PP.Configuration.PayPalUrl;
            PayPal.AccountEmail = classes.PP.Configuration.AccountEmail;
            PayPal.BuyerEmail = Session["EmailId"].ToString();
            PayPal.Amount = this.OrderAmount;

            PayPal.LogoUrl = "http://www.malzook.com/images/BHLogo.gif";

            //TODO: Remove
            //OLD WAY: PayPal.ItemName = "Boardhunt Store Invoice #" + new Guid().GetHashCode().ToString("x");

            //ItemName: Boost Invoice # BHsrvid-userid-code
            //Boost Invoice# BH01-2665-O5C9KY

            //Item#: BHWEB-04-UniqueTblServEntryId
            //Item# BHWEB-1-386

            //        if (hdnServiceVal.Value == "1")
            //sSQL += " AND e.iD = '" + Session["TxnItemId"] + "'";

            PayPal.ItemNumber = "BHWEB-" + Session["ServiceId"].ToString();    //append more below: BHWEB-4-tblServiceId
            PayPal.InvoiceNo = oInv.GenerateInvNum(Session["ServiceId"].ToString(), Session["userId"].ToString()); //BHServiceNum-UserId-Random: BH04-162-2342xy
            
            hdnInvoiceNo.Value = PayPal.InvoiceNo.ToString();

            // *** Have paypal return back to this URL
            PayPal.SuccessUrl = Request.Url + "?PayPal=Success";
            PayPal.CancelUrl = Request.Url + "?PayPal=Cancel";
            
            //Registry the entry but DO NOT activate (pStatus).  Authentic activation will be done on PPIPNConf Page.
            if (!RegisterTxnEntry(false, PayPal.InvoiceNo, false))
            {
                ShowError(ORDER_ERR_MSG, true);
                classes.Email.SendErrorEmail("HPPR:BigError:RegTxnEntry:Check log.");
                return;
            }
            PayPal.ItemNumber += "-" + hdnTxnId.Value;

            if (Session["ServiceId"].ToString() == SVCS_BOOST)
                PayPal.ItemNumber += "-" + Session["TxnItemId"]; //contains unique transaction entry id in tblservices and TxnId item id
            
            PayPal.ItemName += hdnServiceName.Value + " Invoice# " + hdnInvoiceNo.Value;        //item name has invoice # embedded

            switch (Session["ServiceId"].ToString())
            {
                //BOOST
                case "1":
                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                //BIDDER
                case "2":
                    PayPal.ItemName = "Boardhunt Bidder Monthly Subscription:" + Session["userId"].ToString();
                    PayPal.Subscription = true;
                    Response.Redirect(PayPal.GetSUBSubmitUrl());
                    break;
                //ShaperHouse
                case "3":
                    //PayPal.Subscription = true;
                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                //SMS QP
                case "4":
                //ItemName: SMS Coupon Invoice #: BH04-162-JURJIQX
                //Item # 4:2
                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                //VOUCHER
                case "5":
                    ErrorLog.ErrorRoutine(false, "Selected: " + cboItemList.SelectedValue); 
                    PayPal.SuccessUrl += "&inv=" + PayPal.InvoiceNo + "&gdata=" + cboItemList.SelectedValue;
                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                case SVCS_MEMBERSHIP_YR:
                    
                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                case SVCS_MEMBERSHIP_3MOS:

                    Response.Redirect(PayPal.GetSubmitUrl());
                    break;
                default:
                    classes.Email.SendErrorEmail("No case for OrderForm:HandlePPRedir");
                    ErrorLog.ErrorRoutine(false, "No case for OrderForm:HandlePPRedir");
                    break;
            }

            return;
        }

        /// <summary>
        /// Handles the return processing from a PayPal Request.
        /// Looks at the PayPal Querystring variable
        /// </summary>
        private void HandlePayPalReturn()
        {
            string Redir;
            string Result = Request.QueryString["PayPal"].ToString();

            if (Session["PayPal_Redirected"] != null)
                Redir = Session["PayPal_Redirected"].ToString();
            else
                return;

            //Only do this if we are redirected!  i.e. We're back from PayPal!!!
            if (Redir == "True")
            {
                Session.Remove("PayPal_Redirected");    //TODO: bugfix: Error here when posted back when user-> my menu

                // *** Set flag so we know not to go TO PayPal again
                this.PayPalReturnRequest = true;

                // *** Retrieve saved Page content
                //this.txtOrderAmount.Text = ((decimal)Session["PayPal_OrderAmount"]).ToString();
                //this.txtCCType.SelectedValue = "PP";

                //this.txtNotes.Text = (string) Session["PayPal_Notes"];
                //this.txtHeardFrom.Text = (string) Session["PayPal_HeardFrom"];
                //this.txtToolUsed.Text = (string) Session["PayPal_ToolUsed"];

                //TODO: Show sad face
                if (Result == "Cancel") 
                {
                    lblPageTitle.Visible = false;
                    lblPageTitleMsg.Visible = false;

                    switch (Session["ServiceId"].ToString())
                    {
                        case "1":
                            //TODO: add link to manage
                            lblClosing.Text = "Your payment was cancelled.<br><br>Boost your board later from the user menu.";

                            //TODO: remove orphaned ad
                            RemoveTxn(Session["TxnItemId"].ToString());
                            //this.ShowError("You payment was cancelled.  To upgrade and sell your board faster, log-in and manage your ad.");                            

                            break;
                        case "2":
                            //TODO: add link to manage
                            lblClosing.Text = "Your subscription was cancelled.<br><br>You can sign up at a later time by logging-in and clicking on subscriptions.";

                            //remove orphaned ad
                            RemoveTxn("-1");

                            break;
                        case "3":
                            //TODO: add link to manage
                            lblClosing.Text = "Your request for ShaperHouse was cancelled.<br><br>You can sign up later from the user menu after logging in.";

                            //remove orphaned ad
                            RemoveTxn("-1");
                            break;
                        case "4":
                            //TODO: add link to manage
                            lblClosing.Text = "Your coupon purchase was cancelled.<br><br>You can activate it again later from the user menu.";

                            //Leave tblCoupon entry
                            RemoveTxn("-1");
                            break;
                        case "5":
                            //TODO: add link to manage
                            lblClosing.Text = classes.xml.xmlHelper.GetText(@"//service[@id='5']/cancelMsg", @"~/Xml/Services.xml");
                            //Leave tblCoupon entry
                            RemoveTxn("-1");
                            break;
                        case SVCS_MEMBERSHIP_YR:
                            //TODO: add link to manage
                            lblClosing.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/cancelMsg", @"~/Xml/Services.xml");
                            //Leave tblCoupon entry
                            RemoveTxn("-1");
                            break;
                        case SVCS_MEMBERSHIP_3MOS:
                            //TODO: add link to manage
                            lblClosing.Text = classes.xml.xmlHelper.GetText(@"//service[@id='7']/cancelMsg", @"~/Xml/Services.xml");
                            //Leave tblCoupon entry
                            RemoveTxn("-1");
                            break;
                        default:
                            classes.Email.SendErrorEmail("OrderForm:HandlePPRtn:No case for canceled Txn");
                            break;
                    }
                    imgBtnPay.Visible = false;
                    pnlCart.Visible = false;

                    btnSubmit.Visible = false;
                    btnSubscribe.Visible = false;

                    lblClosing.CssClass = "dkgrey16b";

                }
                else
                {

                    // SUCCESS! - simulate button click to save the order and redir to conf page.
                    switch (Session["ServiceId"].ToString())
                    {
                        case "1":
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        case "2":
                            this.btnSubscribe_Click(this, EventArgs.Empty);
                            break;
                        case "3":
                            //Update their acct status to business and manufacturer; set iStatus to 1
                            UpdateAcctStatus();
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        case "4":
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        case "5":
                            hdnInvoiceNo.Value = Request.QueryString["inv"].ToString();
                            hdnGenData.Value = Request.QueryString["gdata"].ToString();
                            ErrorLog.ErrorRoutine(false, "PPReturned:hdnGenData: " + hdnGenData.Value);
                            FinalizeVoucher();
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        case "6":
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        case SVCS_MEMBERSHIP_3MOS:
                            this.btnSubmit_Click(this, EventArgs.Empty);
                            break;
                        default:
                            //shouldn't happen
                            break;
                    }
                }
            }
        }
/*
 * Registers the Txn into tblServices
 */
        private bool RegisterTxnEntry(bool activateVal, string InvNum, bool promo)
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            string iStatus; //bit to activate status. reset to 0 here then set to 1 on PPIPConf page
            string uEntryId = "0";
            string uService = Session["ServiceId"].ToString();
            string uUId = Session["userId"].ToString();

            if (Session["TxnItemId"] == null)
            {
                ErrorLog.ErrorRoutine(false, "OderForm:RegisterTxnEntry:TxnItem was null");
                ShowError(ORDER_ERR_MSG, true);
                return false;
            }
            uEntryId = Session["TxnItemId"].ToString();

            DateTime uSDate = DateTime.Now;
            DateTime uEDate;

            iStatus = "0";
            if (activateVal)
                iStatus = "1";

//@ServiceVal int,
//@EntryId int ,
//@UserId int,
//@dStart datetime = null,
//@dEnd datetime = null,
//@dRestart datetime = null,
//@Status int = 0,
//@TxnId nvarchar(50) = null,
//@TotalPurchasePrice float = null,
//@Units int = null,
//@UnitPrice float = null,
//@Invoice nvarchar(30) = null,
//@CouponId int = null

            dbManager.Open();

            switch (uService)
            {
                //BOOST
                case "1":

                    uEDate = uSDate.AddMonths(3);

                    dbManager.CreateParameters(9);
                    dbManager.AddParameters(0, "@ServiceVal", uService);
                    dbManager.AddParameters(1, "@EntryId", uEntryId);
                    dbManager.AddParameters(2, "@UserId", uUId);

                    dbManager.AddParameters(3, "@Status", iStatus);
                    dbManager.AddParameters(4, "@Units", txtQuantity.Text);
                    dbManager.AddParameters(5, "@Invoice", InvNum);
                    dbManager.AddParameters(6, "@TotalPurchasePrice", this.OrderAmount);

                    dbManager.AddParameters(7, "@dStart", uSDate);
                    dbManager.AddParameters(8, "@dEnd", uEDate);

                    //strSQL = "INSERT INTO tblServices(iServiceVal, iEntryId, iUserId, dStartDate, dEndDate, iStatus, invoice) ";
                    //strSQL += "VALUES('" + uService + "', '" + uEntryId + "', '" + uUId + "', '" + uSDate + "', '" + uEDate + "', '" + iStatus + "', '" + InvNum + "')";

                    break;
                //BIDDER
                case "2":
                    //uEDate = uSDate.AddMonths(12);

                    //strSQL = "INSERT INTO tblServices(iServiceVal, iUserId, dStartDate, dEndDate, iStatus, iUnits, invoice) ";
                    //strSQL += "VALUES('" + uService + "', '" + uUId + "', '" + uSDate + "', '" + uEDate + "','" + iStatus + "','" + InvNum + "')";
                    Response.End();
                    break;

                    //ShaperHouse
                case "3":
                    //TODO: prevent double entries
                    uEDate = uSDate.AddMonths(12);

                    dbManager.CreateParameters(9);
                    dbManager.AddParameters(0, "@ServiceVal", uService);

                    dbManager.AddParameters(1, "@UserId", uUId);

                    dbManager.AddParameters(2, "@Status", iStatus);
                    dbManager.AddParameters(3, "@Units", txtQuantity.Text);
                    dbManager.AddParameters(4, "@Invoice", InvNum);
                    dbManager.AddParameters(5, "@TotalPurchasePrice", this.OrderAmount);

                    dbManager.AddParameters(6, "@dStart", uSDate);
                    dbManager.AddParameters(7, "@dEnd", uEDate);
                    dbManager.AddParameters(8, "@EntryId", 0);
                
                    //strSQL = "INSERT INTO tblServices(iServiceVal, iUserId, dStartDate, dEndDate, iStatus, invoice) ";
                    //strSQL += "VALUES('" + uService + "', '" + uUId + "', '" + uSDate + "', '" + uEDate + "','" + iStatus + "','" + InvNum + "')";

                    break;

                    //Coupon
                case "4":
                    dbManager.CreateParameters(8);
                    dbManager.AddParameters(0, "@ServiceVal", uService);
                    dbManager.AddParameters(1, "@EntryId", uEntryId);
                    dbManager.AddParameters(2, "@UserId", uUId);
                    dbManager.AddParameters(3, "@Status", iStatus);
                    if (promo)
                        dbManager.AddParameters(4, "@Units", PROMO_SMS_CREDITS);
                    else
                        dbManager.AddParameters(4, "@Units", txtQuantity.Text);
                    dbManager.AddParameters(5, "@Invoice", InvNum);
                    dbManager.AddParameters(6, "@TotalPurchasePrice", this.OrderAmount);
                    dbManager.AddParameters(7, "@CouponId", Session["TxnItemId"].ToString());

                    break;
                case "5":

                    uEDate = uSDate.AddMonths(3);

                    dbManager.CreateParameters(9);
                    dbManager.AddParameters(0, "@ServiceVal", uService);
                    dbManager.AddParameters(1, "@EntryId", cboItemList.SelectedValue);   //Shaper id here
                    dbManager.AddParameters(2, "@UserId", uUId);

                    dbManager.AddParameters(3, "@Status", iStatus);
                    dbManager.AddParameters(4, "@Units", lblQuantity.Text);
                    dbManager.AddParameters(5, "@Invoice", InvNum);
                    dbManager.AddParameters(6, "@TotalPurchasePrice", this.OrderAmount);

                    dbManager.AddParameters(7, "@dStart", uSDate);
                    dbManager.AddParameters(8, "@refCode", Convert.ToInt32(cboRefer.SelectedValue));

                    break;
                case SVCS_MEMBERSHIP_YR:

                    uEDate = uSDate.AddMonths(12);

                    dbManager.CreateParameters(8);
                    dbManager.AddParameters(0, "@ServiceVal", uService);
                    dbManager.AddParameters(1, "@EntryId", cboItemList.SelectedValue);   //Shaper id here
                    dbManager.AddParameters(2, "@UserId", uUId);

                    dbManager.AddParameters(3, "@Status", iStatus);
                    dbManager.AddParameters(4, "@Units", lblQuantity.Text);
                    dbManager.AddParameters(5, "@Invoice", InvNum);
                    dbManager.AddParameters(6, "@TotalPurchasePrice", this.OrderAmount);

                    dbManager.AddParameters(7, "@dStart", uSDate);

                    break;
                case SVCS_MEMBERSHIP_3MOS:

                    uEDate = uSDate.AddMonths(3);

                    dbManager.CreateParameters(8);
                    dbManager.AddParameters(0, "@ServiceVal", uService);
                    dbManager.AddParameters(1, "@EntryId", cboItemList.SelectedValue);   //Shaper id here
                    dbManager.AddParameters(2, "@UserId", uUId);

                    dbManager.AddParameters(3, "@Status", iStatus);
                    dbManager.AddParameters(4, "@Units", lblQuantity.Text);
                    dbManager.AddParameters(5, "@Invoice", InvNum);
                    dbManager.AddParameters(6, "@TotalPurchasePrice", this.OrderAmount);

                    dbManager.AddParameters(7, "@dStart", uSDate);

                    break;
                default:
                    break;
            }

            try
            {
                int iTblServUniqId = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.StoredProcedure, "spAddTxn"));
                hdnTxnId.Value = iTblServUniqId.ToString(); //this is the unique iD for the tblServices entry
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:RegisterTxnEntry:Error:" + ex.Message);
                classes.Email.SendErrorEmail("OrderForm:RegisterTxnEntry:Couldn't add entry into tblServices");
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

        private void RemoveTxn(string iD)
        {
            string strSQL;

            strSQL = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //TODO: make bulletproof
            switch (Session["ServiceId"].ToString())
            {
                //BOOST
                case "1":
                    strSQL = "DELETE FROM tblServices WHERE iEntryId = '" + iD + "'";
                    break;
                //BIDDER
                case "2":
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '2' AND iUserId='" + Session["userId"].ToString() + "'";
                    break;
                case "3":
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '3' AND iUserId='" + Session["userId"].ToString() + "'";
                    break;
                case "4":
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '4' AND  iD = '" + hdnTxnId.Value + "'";
                    break;
                case "5":
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '5' AND  iD = '" + hdnTxnId.Value + "'";
                    break;
                case SVCS_MEMBERSHIP_YR:
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '6' AND  iD = '" + hdnTxnId.Value + "'";
                    break;
                case SVCS_MEMBERSHIP_3MOS:
                    strSQL = "DELETE FROM tblServices WHERE iServiceVal = '7' AND  iD = '" + hdnTxnId.Value + "'";
                    break;
                default:
                    break;
            }

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:RemoveTxn:strSQL: " + strSQL);
                ErrorLog.ErrorRoutine(false, "OrderForm:RemovetblServiceTxn: " + ex.Message);
                classes.Email.SendErrorEmail("OrderForm:RemovetblServiceTxn: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
 */
        protected string GetSQLForService()
        {
            string sSQL = string.Empty;

            switch (Session["ServiceId"].ToString())
            {
                case SVCS_BOOST:

                    sSQL = @"SELECT s.name, s.amount, s.displayName, s.duration, s.fltShipping, s.iDefaultQuantity";

                    if (hdnServiceVal.Value == "1")
                        sSQL += " ,e.txtImgPath1, e.txtBrand, e.iHtFt, e.iHtIn ";

                    sSQL += " FROM LK_Services s ";

                    if (hdnServiceVal.Value == "1")
                        sSQL += ", tblEntry e ";

                    sSQL += " WHERE s.iD = '" + Session["ServiceId"].ToString() + "'";

                    if (hdnServiceVal.Value == "1")
                        sSQL += " AND e.iD = '" + Session["TxnItemId"] + "'";

                    break;
                case SVCS_SHAPERHOUSE:
                    sSQL = @"SELECT s.name, s.amount, s.displayName, s.duration, s.fltShipping, s.iDefaultQuantity";

                    if (hdnServiceVal.Value == "1")
                        sSQL += " ,e.txtImgPath1, e.txtBrand, e.iHtFt, e.iHtIn ";

                    sSQL += " FROM LK_Services s ";

                    if (hdnServiceVal.Value == "1")
                        sSQL += ", tblEntry e ";

                    sSQL += " WHERE s.iD = '" + Session["ServiceId"].ToString() + "'";

                    if (hdnServiceVal.Value == "1")
                        sSQL += " AND e.iD = '" + Session["TxnItemId"] + "'";
                    break;
                case SVCS_VOUCHER:
                    sSQL = @"SELECT s.name, s.amount, s.displayName, s.duration, s.fltShipping, s.iDefaultQuantity";
                    sSQL += " FROM LK_Services s ";
                    sSQL += " WHERE s.iD = '" + Session["ServiceId"].ToString() + "'";
                    break;
                case SVCS_MEMBERSHIP_YR:
                    sSQL = @"SELECT s.name, s.amount, s.displayName, s.duration, s.fltShipping, s.iDefaultQuantity";
                    sSQL += " FROM LK_Services s ";
                    sSQL += " WHERE s.iD = '" + Session["ServiceId"].ToString() + "'";
                    break;
                case SVCS_MEMBERSHIP_3MOS:
                    sSQL = @"SELECT s.name, s.amount, s.displayName, s.duration, s.fltShipping, s.iDefaultQuantity";
                    sSQL += " FROM LK_Services s ";
                    sSQL += " WHERE s.iD = '" + Session["ServiceId"].ToString() + "'";
                    break;
                default:
                    break;
            }
            return sSQL;
        }
  

/*
 * Loads the data for the service from the LK_Service table
 */
        protected void LoadService()
        {

            string strSQL;
            string unitVal;
            string shpVal;

            btnSubscribe.Visible = false;
            btnSubmit.Visible = false;

            unitVal = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = GetSQLForService();

            //Run query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    //Name, Price Amt, Shipping, default quantity
                    hdnServiceName.Value = dbManager.DataReader["displayName"].ToString();
                    unitVal = dbManager.DataReader["amount"].ToString();
                    hdnUnitPrice.Value = unitVal;
                    UnitPrice = decimal.Parse(unitVal);
                    shpVal = dbManager.DataReader["fltShipping"].ToString();
                    txtQuantity.Text = dbManager.DataReader["iDefaultQuantity"].ToString();
                    hdnDlftQ.Value = txtQuantity.Text;

                    //discount code here
                    hdnDiscountAmt.Value = "0";

                    lblLegalStuff.Text = "* ALL SALES ARE FINAL";

                    //Unit
                    lblUnitPrice.Text = "$" + String.Format("{0:0.00}", decimal.Parse(unitVal));
                    
                    //Subtotal: sum of all units
                    SubTotal = decimal.Parse(unitVal) * Convert.ToDecimal(txtQuantity.Text);
                    lblSubTotal.Text = "$" + String.Format("{0:0.00}", SubTotal);

                    //Shipping
                    lblShippingAmt.Text = "$" + String.Format("{0:0.00}", decimal.Parse(shpVal));

                    //Tally total = Subtotal + shipping - discount
                    this.OrderAmount = SubTotal + decimal.Parse(shpVal) - decimal.Parse(hdnDiscountAmt.Value);
                    Session["TxnOrderAmount"] = this.OrderAmount; //used to persist across postbacks

                    lblTotal.Text = "$" + String.Format("{0:0.00}", decimal.Parse(this.OrderAmount.ToString()));

                    //lblShipping, imgItem, lblUnitPrice, lnkBack, imgBtnPay, lblSubTotal
                    switch (Session["ServiceId"].ToString())
                    {
                        //BOOST
                        case "1":

                            imgItem.ImageUrl = GetPicPath(dbManager.DataReader["txtImgPath1"].ToString(), true);
                            //imgItem.ImageUrl = "../images/BoostSm120x80.gif";   //Fixme: change to show board pic
                            imgItem.Height = 75;
                            imgItem.Width = 75;
                            lblShipping.Text = "n/a";

                            string strBoardDesc = dbManager.DataReader["txtBrand"].ToString() + " " + dbManager.DataReader["iHtFt"].ToString() + "' " + dbManager.DataReader["iHtIn"].ToString() + "\"";
                            lblPageTitle.Text = "Boost your board";
                            lblPageTitleMsg.Text = "Boosting helps your board sell faster."; 
                            
                            //lblPageTitle.Text = "For the price of 2 fish tacos you'll sell your board even faster";

                            lblItemDesc.Text = "<b>" + strBoardDesc + "</b><br><br>";
                            lblItemDesc.Text += @"
                                                <ul style='padding-left:10px' class='midgrey12'>
                                                    <li>More pageviews</li>
                                                    <li>Higher visibility</li>
                                                    <li>More attention than the others</li>
                                                </ul>
                                                ";
                         
                                
                            txtQuantity.ReadOnly = true;
                            txtQuantity.Visible = true;
                            btnUpdate.Visible = false;
                            break;
                        //BIDDER
                        case "2":
                            break;
                        //SHAPERHOUSE
                        case "3":
                            lblPromo.Visible = true;
                            btnPCode.Visible = true;
                            txtPromo.Visible = true;

                            imgItem.ImageUrl = "../images/shaper_cart.gif";
                            imgItem.Height = 80;
                            imgItem.Width = 120;
                            lblShipping.Text = "n/a";
                            lblPageTitle.Text = "Build your ShaperHouse today.";
                            lblItemDesc.Text = @"<span class='midgrey12b'>Show your craftsmanship</span><br />
                                            &nbsp;&nbsp;<span class='dkgrey12'>- Display your models</span><br />
                                            &nbsp;&nbsp;<span class='dkgrey12'>- Interact with the community</span> <br />";

                            
                            txtQuantity.ReadOnly = true;
                            txtQuantity.Visible = true;
                            btnUpdate.Visible = false;
                            break;

                        case "5":   //voucher

                            //lblPromo.Text = "Partner Code:";

                            //show selected shaper if visible
                            if (Session["TxnItemId"]!= null)
                            {
                                if (Session["TxnItemId"].ToString() != "-1")
                                {
                                    cboItemList.SelectedValue = Session["TxnItemId"].ToString();
                                }
                                else
                                    cboItemList.SelectedValue = "-1";
                            }
                            
                            
                            lblPromo.Visible = true;
                            btnPCode.Visible = true;
                            txtPromo.Visible = true;
                            lblQuantity.Text = dbManager.DataReader["iDefaultQuantity"].ToString();

                            btnUpdate.Visible = false;
                            imgItem.ImageUrl = "../images/VoucherOrderForm.gif";
                            imgItem.Height = 80;
                            imgItem.Width = 120;
                            lblShipping.Text = "n/a";
                            lblPageTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='5']/pageTitle", @"~/Xml/Services.xml");
                            lblItemTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='5']/itemTitle", @"~/Xml/Services.xml");
                            lblItemDesc.Text = classes.xml.xmlHelper.GetText(@"//service[@id='5']/description", @"~/Xml/Services.xml");
                            lblItemDesc.Visible = false;
                            cboRefer.Visible = true;
                            break;

                        case "6":   //membership

                            Session["TxnItemId"] = Session["userId"].ToString();

                            lblPromo.Visible = true;
                            btnPCode.Visible = true;
                            txtPromo.Visible = true;
                            lblQuantity.Text = dbManager.DataReader["iDefaultQuantity"].ToString();

                            btnUpdate.Visible = false;
                            imgItem.ImageUrl = "../images/VoucherOrderForm.gif";
                            imgItem.Height = 80;
                            imgItem.Width = 120;
                            lblShipping.Text = "n/a";
                            lblPageTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/pageTitle", @"~/Xml/Services.xml");
                            lblItemTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/itemTitle", @"~/Xml/Services.xml");
                            lblItemDesc.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/description", @"~/Xml/Services.xml");
                            lblItemDesc.Visible = true;
                            cboRefer.Visible = false;
                            break;
                        case "7":   //membership - 3 mos

                            Session["TxnItemId"] = Session["userId"].ToString();

                            lblPromo.Visible = true;
                            btnPCode.Visible = true;
                            txtPromo.Visible = true;
                            lblQuantity.Text = dbManager.DataReader["iDefaultQuantity"].ToString();

                            btnUpdate.Visible = false;
                            imgItem.ImageUrl = "../images/VoucherOrderForm.gif";
                            imgItem.Height = 80;
                            imgItem.Width = 120;
                            lblShipping.Text = "n/a";
                            lblPageTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/pageTitle", @"~/Xml/Services.xml");
                            lblItemTitle.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/itemTitle", @"~/Xml/Services.xml");
                            lblItemDesc.Text = classes.xml.xmlHelper.GetText(@"//service[@id='6']/description", @"~/Xml/Services.xml");
                            lblItemDesc.Visible = true;
                            cboRefer.Visible = false;
                            break;
                        default:
                            break;
                    }                        
                }
                else
                {
                    
                    ShowError(ORDER_ERR_MSG, true);
                    ErrorLog.ErrorRoutine(false, "OrderForm:LoadService:EmptyDataset");
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:LoadService: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "OrderForm:LoadService:Error: " + strSQL);
                classes.Email.SendErrorEmail("OrderForm:LoadService Failed");
                ShowError(ORDER_ERR_MSG, true);
                return;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            // *** TODO: Any special page processing for you to display your invoice
            //           and solicit user input.
            //switch (Session["ServiceId"].ToString())
            //{
            //    case "0":
            //        break;
            //    case "1":
            //        lblPageTitle.Text = "For the price of 2 fish tacos you could be selling faster!";
            //        lblPageTitleMsg.Text = string.Empty;

            //        //lblClosing.Visible = false;
            //        lblPrice.Text = "<span class='dkgrey12'>Get 3 months worth for </span> <span class='ltgreen14b'>$" + unitVal + " total</span>";

            //        break;
            //    default:
            //        break;
            //}


        }
/*
 */
        protected void GetText(string sVal, string sPath)
        {
            classes.xml.xmlHelper.GetText(sVal, sPath);
        }
/*
 */
        protected void LoadOrder()
        {
            string unitVal;
            string shpVal;
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = @" SELECT c.title, c.body, c.code, c.smsPkgCnt, c.smsLiveCnt, c.iUser, c.imgPath, c.dAdded, c.dExpire,
                        s.name, s.displayName, s.iDefaultQuantity, s.amount, s.fltShipping,
                        u.userDir
                        FROM tblCoupon c
                        INNER JOIN LK_Services s ON s.iD = 4
                        INNER JOIN tblUser u ON u.iD = c.iUser
                        WHERE c.iD = '" + Session["TxnItemId"].ToString() + "'";
            
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    //Name, Price Amt, Shipping, dflt_Quantity
                    hdnServiceName.Value = dbManager.DataReader["name"].ToString();
                    
                    unitVal = dbManager.DataReader["amount"].ToString();
                    hdnUnitPrice.Value = unitVal;
                    UnitPrice = decimal.Parse(unitVal);

                    shpVal = dbManager.DataReader["fltShipping"].ToString();
                    txtQuantity.Text = dbManager.DataReader["iDefaultQuantity"].ToString();//dbManager.DataReader["smsPkgCnt"].ToString();
                    hdnDlftQ.Value = txtQuantity.Text;

                    //discount code here
                    hdnDiscountAmt.Value = "0";

                    lblLegalStuff.Text = "* ALL SALES ARE FINAL";

                    //Unit
                    lblUnitPrice.Text = "$" + String.Format("{0:0.00}", decimal.Parse(unitVal));
                    
                    //Subtotal: sum of all units
                    SubTotal = decimal.Parse(unitVal) * Convert.ToDecimal(txtQuantity.Text);
                    lblSubTotal.Text = "$" + String.Format("{0:0.00}", SubTotal);

                    //Shipping
                    lblShippingAmt.Text = "$" + String.Format("{0:0.00}", decimal.Parse(shpVal));
                    hdnShippingPrice.Value = shpVal;

                    //Grand total = Subtotal + shipping - discount
                    this.OrderAmount = SubTotal + decimal.Parse(shpVal) - decimal.Parse(hdnDiscountAmt.Value);
                    Session["TxnOrderAmount"] = this.OrderAmount; //used to persist across postbacks

                    lblTotal.Text = "$" + String.Format("{0:0.00}", decimal.Parse(this.OrderAmount.ToString()));
                    //ErrorLog.ErrorRoutine(false, "TotText: " + lblTotal.Text);

                    //lblShipping, imgItem, lblUnitPrice, lnkBack, imgBtnPay, lblSubTotal
                    switch (Session["ServiceId"].ToString())
                    {
                        //SMS QP
                        case "4":
                            lblPromo.Visible = true;
                            btnPCode.Visible = true;
                            txtPromo.Visible = true;

                            imgItem.ImageUrl = "../images/CouponDefault.gif";
                            if (dbManager.DataReader["imgPath"].ToString().Length > 1) //
                                imgItem.ImageUrl = GetPicPath(dbManager.DataReader["imgPath"].ToString(), false);

                            imgItem.Height = 75;
                            imgItem.Width = 75;

                            lblShipping.Text = "n/a";
                            lblPageTitle.Text = "YOUR ORDER SUMMARY";
                            lblItemDesc.Text = dbManager.DataReader["title"].ToString() + "<br>" + Global.FormatDetails(dbManager.DataReader["body"], 15);
                            break;
                        default:
                            break;
                    }                        
                }
                else
                {
                    ShowError(ORDER_ERR_MSG, true);
                    ErrorLog.ErrorRoutine(false, "OrderForm:LoadOrder:EmptyDataset");
                    return;
                }

            }
            catch (Exception ex)
            {
                ShowError(ORDER_ERR_MSG, true);
                ErrorLog.ErrorRoutine(false,"OrderForm:LoadOrder: " + ex.Message);
                classes.Email.SendErrorEmail("OrderForm:LoadOrder:Failed");
                return;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            btnSubscribe.Visible = false;
            btnSubmit.Visible = false;
        }
/*
 */
        protected void LoadSUBDisplay()
        {
            string strSQL;
            string val;

            ErrorLog.ErrorRoutine(false, "OrderForm:LoadSUBDisplay");

            val = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "Select amount from LK_Services WHERE iD = '" + Session["ServiceId"].ToString() + "'";

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    val = dbManager.DataReader["amount"].ToString();

                    try
                    {
                        this.OrderAmount = decimal.Parse(val);
                        Session["TxnOrderAmount"] = this.OrderAmount; //used to persist across postbacks
                    }
                    catch
                    {
                        lblClosing.Text = "Whoops - an error occured somewhere here.  Boardhunt has been notified. Please logout and try again.";
                        return;
                    }
                }
                else
                {

                    lblClosing.Text = "Whoops - an error occured somewhere here.  Please logout and try again.";
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:LoadSUBDisplay:Msg: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }


            // *** TODO: Any special page processing for you to display your invoice
            //           and solicit user input.
            switch (Session["ServiceId"].ToString())
            {
                case "0":
                    break;
                case "2":

                    lblPageTitle.Text = "Subscribe to Boardhunt Bidder for <span class='midgreen24b'>" + this.OrderAmount + " per month</span>";
                    lblPageTitleMsg.Text = "Once signed up you will be able to bid to shape a kook's surfboard.";

                    //lblClosing.Visible = false;
                    lblPrice.Text = "Price: <span class='ltgreen14b'>" + this.OrderAmount + " per month" + "</span>";

                    btnSubscribe.Visible = true;
                    btnSubmit.Visible = false;

                    break;
                default:
                    break;
            }
        }
/*
 */
        void ShowError(string ErrorMessage, bool hideAll)
        {
            this.lblErrorMessage.Text = ErrorMessage;
            pnlError.Visible = true;

            if (hideAll)
            {
                pnlCart.Visible = false;
                lblPageTitle.Visible = false;
                lblPageTitleMsg.Visible = false;
            }
        }

        protected void UpdateQuantity(object sender, EventArgs e)
        {
            int iQ = 1;
            bool bQOkay;

            bQOkay = Int32.TryParse(txtQuantity.Text, out iQ);

            if (!bQOkay)
            {
                txtQuantity.Text = hdnDlftQ.Value;
                return;
            }

            decimal decSubTotal;

            //Subtotal: sum of all units
            decSubTotal = decimal.Parse(hdnUnitPrice.Value) * Convert.ToDecimal(iQ);
            //ErrorLog.ErrorRoutine(false, "decSubTotal: " + decSubTotal.ToString());
            lblSubTotal.Text = "$" + String.Format("{0:0.00}", decSubTotal);
            //ErrorLog.ErrorRoutine(false, "lblSubTotal: " + lblSubTotal.Text);

            //Tally total = Subtotal + shipping - discount
            //ErrorLog.ErrorRoutine(false, "decSubTotal: " + decSubTotal.ToString() + " lblShippingAmt: " + lblShippingAmt.Text + " hdnDiscountAmt: " + hdnDiscountAmt.Value);

            this.OrderAmount = decSubTotal + decimal.Parse(hdnShippingPrice.Value) - decimal.Parse(hdnDiscountAmt.Value);
            Session["TxnOrderAmount"] = this.OrderAmount; //used to persist across postbacks

            lblTotal.Text = "$" + String.Format("{0:0.00}", decimal.Parse(this.OrderAmount.ToString()));
            //ErrorLog.ErrorRoutine(false, "TotText: " + lblTotal.Text);
        }
/*
 */
        protected void btnPCode_Click(object sender, EventArgs e)
        {
            if (txtPromo.Text.Length < 1)
                return;            
            
            txtPromo.Text = txtPromo.Text.Trim();
            string val = Session["ServiceId"].ToString();
            switch (Session["ServiceId"].ToString())
            {
                case "3":

                    if (txtPromo.Text != "SHAP3RHOUS3")
                        return;

                    Session["TxnItemId"] = Session["userId"].ToString();

                    //add activated entry in services
                    if (!RegisterTxnEntry(true, "SHAP3RHOUS3_Trial", true))
                    {
                        ShowError(ORDER_ERR_MSG, true);
                        classes.Email.SendErrorEmail("Error activating SH Trial");
                        return;
                    }
                    UpdateAcctStatus();     //BYPASS PayPal
                    classes.Email.SendEmail("ShaperHouse Activated", "info@boardhunt.com", "ShaperHouse activated for userId: " + Session["userId"].ToString() + "-" + HttpContext.Current.Session["EmailId"]);
                    Session["TxnItemId"] = null;
                    Session["ServiceId"] = null;
                    Session["TxnOrderAmount"] = null;
                    Response.Redirect("Confirmation.aspx?iD=3", true);
                    break;

                case "4":

                    txtQuantity.Text = "10";

                    if (txtPromo.Text != "COUPONZ")
                    {
                        ShowError("Enter in a valid Promo code.", false);
                        return;
                    }
                    //add activated entry in services
                    if (RegisterTxnEntry(true, "COUPONZ_Trial", true))
                    {
                        if (!classes.Coupon.ActivateCoupon(Session["TxnItemId"].ToString(), true))
                        {
                            ShowError(ORDER_ERR_MSG, true);
                            classes.Email.SendErrorEmail("Error activating Coupon: " + Session["TxnItemId"].ToString());
                            return;
                        }
                    }
                    else
                    {
                        ShowError(ORDER_ERR_MSG, true);
                        classes.Email.SendErrorEmail("Error activating Coupon: " + Session["TxnItemId"].ToString());
                        return;
                    }

                    classes.Email.SendEmail("Coupon Activated", "info@boardhunt.com", "Coupon: " + Session["TxnItemId"].ToString() + " was activated for User: " + Session["userId"].ToString() + " - " + HttpContext.Current.Session["EmailId"]);
                    Session["TxnItemId"] = null;
                    Session["ServiceId"] = null;
                    Session["TxnOrderAmount"] = null;
                    Response.Redirect("Confirmation.aspx?iD=4", true);
                    break;
                case "5":
                    //TODO: add code and allow
                    break;
                default:
                    break;
            }

        }
/*
 */
        protected void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Global.NavigatePage(lnkSignIn.Text);

        }
/*
 */
        protected void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Global.NavigatePage(lnkSignUp.Text);

        }
/*
 */
        protected void lnkPost_Click(object sender, System.EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Response.Redirect("post.aspx", false);
        }
/*
 */ 
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string dir = string.Empty;

            Session["TxnItemId"] = null;
            Session["TxnOrderAmount"] = null;

            switch (Session["ServiceId"].ToString())
            {
                case "4":
                    dir = "../qp/Manager.aspx";
                    break;
                default:
                    dir = "../UserMenu.aspx";
                    break;
            }

            Session["ServiceId"] = null;
            Response.Redirect(dir, true);
        }
/*
 * Queries buyer and shaper and send email info
 */

        //TODO: get the emails and send the emails with the appropriate text.  Do we copy the shaper or send out a separate email?
        protected bool FinalizeVoucher()
        {
            //TODO: Mention Sacred Craft
            //cboRefer.SelectedValue
            
            string strSQL;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            strSQL = "SELECT u.txtEmail as buyer FROM tblUser u ";// WHERE u.id='" + Session["userId"].ToString() + "'";

            //Shaper was chosen; should be a value here
            if (hdnGenData.Value != "-1")
            {
                strSQL = @"SELECT u.txtEmail as buyer, sq.* FROM tblUser u,(SELECT txtBrandName, txtFullName, txtEmail AS mfg, txtPhoneNum, txtWebsite FROM tblUser WHERE iD='" + hdnGenData.Value + "') sq";
            }
            strSQL += " WHERE u.id='" + Session["userId"].ToString() + "'";

            ErrorLog.ErrorRoutine(false, "OrderForm:FinalizeVoucher:strSQL: " + strSQL);

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);
                if (dbManager.DataReader.Read())
                {
                    if (dbManager.DataReader["buyer"] != null)
                    {
                        if (hdnGenData.Value != "-1")    //Shaper chosen
                        {
                            string xtraData = "BVP Code: " + hdnInvoiceNo.Value + "<br>";
                            xtraData += "Shaper: " + dbManager.DataReader["txtBrandName"].ToString() + "<br>";
                            xtraData += "Name: " + dbManager.DataReader["txtFullName"].ToString() + "<br>";
                            xtraData += "Email: " + dbManager.DataReader["mfg"].ToString() + "<br>";
                            xtraData += "Web: " + dbManager.DataReader["txtWebsite"].ToString() + "<br>";
                            xtraData += "Phone: " + dbManager.DataReader["txtPhoneNum"].ToString() + "<br>";


                            //(string to, string from, string cc, string subj, int msgType, bool bcc)
                            classes.Email.SendCCEmail(dbManager.DataReader["buyer"].ToString(), classes.Email.EMAIL_INFO_BH, dbManager.DataReader["mfg"].ToString(), classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailSubject", @"~/Xml/Services.xml"), classes.Email.MSG_THX_VOUCHER_CC, xtraData, true);
                        }
                        else
                        {
                            string strTxt = classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailBodyAny", @"~/Xml/Services.xml");
                            strTxt += " <br><br> " + "BVP Code: " + hdnInvoiceNo.Value;
                            classes.Email.SendEmail(classes.xml.xmlHelper.GetText(@"//service[@id='5']/emailSubject", @"~/Xml/Services.xml"), dbManager.DataReader["buyer"].ToString(), "info@boardhunt.com", strTxt, true);
                        }
                    }
                    else
                    {
                        classes.Email.SendErrorEmail("Failed to read buyer's email: strSQL: " + strSQL);
                        return false;
                    }
                    
                    return true;
                }
                else
                {
                    classes.Email.SendErrorEmail("Failed to read voucher emails:strSQL: " + strSQL);
                    return false;
                }

               
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:FinalizeVoucher:hdnGenData: " + hdnGenData.Value);
                ErrorLog.ErrorRoutine(false, "OrderForm:FinalizeVoucher:Error: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "OrderForm:FinalizeVoucher:strSQL: " + strSQL);
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
        protected void ShowError()
        {
            btnCancel.Visible = false;
            btnSubscribe.Visible = false;
            btnSubmit.Visible = false;
            lblClosing.Text = "Sorry, something went wrong.&nbsp;&nbsp;<a href='#' onclick=\"javascript:window.opener='x';window.close();\"><u>CLOSE</u></a> this browser and try again.";
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Session["TxnItemId"] = null;
            Session["ServiceId"] = null;
            Session["TxnOrderAmount"] = null;
            Response.Redirect("../UserMenu.aspx", true);
        }
/*
 * Sets users acct to a ShaperHouse acct
 */ 
        private void UpdateAcctStatus()
        {
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            strSQL = "UPDATE tblUser SET iAcctType = 2, iStatus = 1, iMerchantType = 1 WHERE iD =" + Session["userId"].ToString();

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "OrderForm:UpdateAcctStatus:Error:" + ex.Message);
                classes.Email.SendErrorEmail("OrderForm:UpdateAcctStatus:Error:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            
        }
/**
 */
        public string GetPicPath(object imgPicPath, bool bUseExtDir)
        {
            //check for null or empty string
            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == string.Empty)
                return System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/images/s1x1.gif";
            else
            {
                if(bUseExtDir)
                    return System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/users/" + Global.ReplaceEx(hdnUserDir.Value, @"\", "/") + "/" + Global.SURF_CAT + "/" + imgPicPath;
                else
                    return System.Configuration.ConfigurationSettings.AppSettings["ServerURL"] + "/users/" + Global.ReplaceEx(hdnUserDir.Value, @"\", "/") + imgPicPath;
            
            }
        }

    }
}
