using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using DALLayer;

namespace BoardHunt
{
    public partial class Matrix : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.Image imgCameraPic;

        protected System.Web.UI.WebControls.ImageButton imgAdType;
        protected System.Web.UI.WebControls.ImageButton imgPreview;

        protected System.Web.UI.WebControls.Panel pnlPrevew;
        protected System.Web.UI.WebControls.Panel lblPrevew;

        protected System.Web.UI.WebControls.LinkButton lnkBtnImg;
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        protected System.Web.UI.WebControls.LinkButton LinkButton2;
        protected System.Web.UI.WebControls.LinkButton lnkBtnPrice;
        protected System.Web.UI.WebControls.LinkButton lnkBtnTown;

        protected const int BitMask_0 = 1;
        protected const int BitMask_1 = 2;
        protected const int BitMask_2 = 4;
        protected const int BitMask_3 = 8;
        protected const int BitMask_4 = 16;
        protected const int BitMask_5 = 32;
        protected const int BitMask_6 = 64;
        protected const int BitMask_7 = 128;
        protected const int BitMask_8 = 256;
        protected const int BitMask_9 = 512;
        protected const int BitMask_10 = 1024;
        protected const int BitMask_11 = 2048;

        protected const int BitMask = 0x20; //100 hex; 256 decimal; this is our one bit high mask; & with whatever and check for > 0

        Hashtable hs = new Hashtable();
        Hashtable hsF = new Hashtable();

        //TODO: Flip / Mirror? 1 is Long not GUN!

                                        //  Sh   Lng   Fsh     Fun      Gun  Hy
        int[,] height2 = new int[3, 6] {{   0,    34,    0,     24,      0,  0},        //Beginner +/-2
                                        {   3,   30,   -3,     20,     18,  -3},        //Intermediate
                                        {   1,   26,   -3,     16,     18,  -3}};       //Advanced

                                       //  Hy    Gun    Fun     Fsh     Lng  Sh
        //int[,] height = new int[3, 6] { {   0,    0,    24,     0,      34,  0},        //Beginner +/-2
        //                                {   -3,   18,   20,     -3,     30,  3},        //Intermediate
        //                                {   -3,   18,   16,     -3,     26,  1}};       //Advanced

        //double[,] thick = new double[2, 6] {   {   3.25, 2.75,     3,      2.75,   3.75,   2.75},   //hi
        //                                        {   2.75,  2,       2.375,  2.25,   2.75,   1.75}   //low
        //                                    };

        double[,] thick = new double[2, 6] {   {2.75,   3.75,   2.75,      3,   2.75,   2.75 },   //hi
                                               {2,      2.75,   2.25,   2.375,      2,  2}   //low
                                            };


        string[] boardTypes = new string[6] { "Hybrid", "Gun", "Fun/Egg", "Fish", "Longboard", "Shortboard" };

        protected void Page_Load(object sender, System.EventArgs e)
        {
            pnlShaperResults.Visible = false;


            lnkSignIn.Text = Global.SetLnkSignIn();
            lnkSignUp.Text = Global.SetLnkSignUp();

            btnSearch.OnClientClick = ("javascript:__doPostBack('btnSearch','');event.returnValue=false;return false;");

            InitHash();

            if (!Page.IsPostBack)
            {
                
                hdnServer.Value = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                SetDefaults();
                LoadFilter();
            }
            if (hdnBoardCode.Value.Length > 0)
            ShowShapers(Convert.ToInt32(hdnBoardCode.Value));
        }

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
            //this.cmdPrev.Click += new System.Web.UI.ImageClickEventHandler(this.cmdPrev_Click);
            //this.cmdNext.Click += new System.Web.UI.ImageClickEventHandler(this.cmdNext_Click);

        }
        #endregion
/*
 */
        private void SetDefaults()
        {
            txtHtFt.Text = "5";
            txtHtIn.Text = "9";
            hdnWeight.Value = txtWeight.Text = "155";

            //FB Likes:
            lblFB.Text = "<fb:like href='" + Request.Url.ToString() + "' layout='button_count' show_faces='false' colorscheme='dark'></fb:like>"; 

            ////FB:OpenGraph meta tags
            HtmlMeta mt = new HtmlMeta();
            mt.Attributes.Add("property", "og:title");
            mt.Attributes.Add("content", "The Board Matrix");

            HtmlMeta mt1 = new HtmlMeta();
            mt1.Attributes.Add("property", "og:description");
            mt1.Attributes.Add("content", "What kind of board should I ride? Check out the Board Matrix.");

            HtmlMeta mt2 = new HtmlMeta();
            mt2.Attributes.Add("property", "og:type");
            mt2.Attributes.Add("content", "product");

            HtmlMeta mt3 = new HtmlMeta();
            mt3.Attributes.Add("property", "og:url");
            //mt3.Attributes.Add("content", "http://www.malzook.com/matrix/");
            mt3.Attributes.Add("content", "http://www.malzook.com/matrix.aspx");

            HtmlMeta mt4 = new HtmlMeta();
            mt4.Attributes.Add("property", "og:image");
            mt4.Attributes.Add("content", "http://www.malzook.com/images/BHLogo.gif" );

            HtmlMeta mt5 = new HtmlMeta();
            mt5.Attributes.Add("property", "og:email");
            mt5.Attributes.Add("content", "info@boardhunt.com");

            this.Header.Controls.Add(mt);
            this.Header.Controls.Add(mt1);
            this.Header.Controls.Add(mt2);
            this.Header.Controls.Add(mt3);
            this.Header.Controls.Add(mt4);
            this.Header.Controls.Add(mt5);

        }

        private void InitHash()
        {
            if (hsF.Count > 1)
                hsF.Clear();

            hsF.Add((object)".0", (object)string.Empty);
            hsF.Add((object)".125", (object)"1/8");
            hsF.Add((object)".25", (object)"1/4");
            hsF.Add((object)".375", (object)"3/8");
            hsF.Add((object)".5", (object)"1/2");
            hsF.Add((object)".625", (object)"5/8");
            hsF.Add((object)".75", (object)"3/4");
            hsF.Add((object)".875", (object)"1/8");

            if (hs.Count > 1)
                hs.Clear();

            //novice
            hs.Add((object)261, (object)10);
            hs.Add((object)262, (object)10);
            hs.Add((object)265, (object)10);
            hs.Add((object)266, (object)10);
            hs.Add((object)273, (object)10);
            hs.Add((object)274, (object)0);
            hs.Add((object)289, (object)0);
            hs.Add((object)290, (object)0);
            hs.Add((object)321, (object)0);
            hs.Add((object)322, (object)0);
            hs.Add((object)385, (object)0);
            hs.Add((object)386, (object)0);

            //inter
            hs.Add((object)517, (object)14);
            hs.Add((object)518, (object)46);
            hs.Add((object)521, (object)46);
            hs.Add((object)522, (object)47);
            hs.Add((object)529, (object)47);
            hs.Add((object)530, (object)47);
            hs.Add((object)545, (object)46);
            hs.Add((object)546, (object)33);
            hs.Add((object)577, (object)59);
            hs.Add((object)578, (object)49);
            hs.Add((object)641, (object)26);
            hs.Add((object)642, (object)16);

            //adv
            hs.Add((object)1029, (object)14);
            hs.Add((object)1030, (object)14);
            hs.Add((object)1033, (object)46);
            hs.Add((object)1034, (object)47);
            hs.Add((object)1041, (object)47);
            hs.Add((object)1042, (object)47);
            hs.Add((object)1057, (object)47);
            hs.Add((object)1058, (object)47);
            hs.Add((object)1089, (object)43);
            hs.Add((object)1090, (object)59);
            hs.Add((object)1153, (object)26);
            hs.Add((object)1154, (object)16);
        }

        private void ShowResults()
        {
            int iWaveSize;
            int iGender;
            int iLevel;

            uint mask;
            mask = BitMask; // 0x20;

            //FILTER PRIORITY
            // 1) Wave size 2) Wave type 3) Skill level

            //MODIFYERS
            //4 height
            //5 weight

            //LEVEL
            //beginner: long | fun
            //intermediate: fun | short
            //advanced: short | fun | long | gun | pro

            //LEVEL CODES:
            //beginner=1;intermediate=2;advanced=3

            //WAVESIZE:
            //any=0;knee=1; waist=2; chest=4; head=8; overhead=16; 2xOverhead=32
            //WAVETYPE:
            //Rollers=1; Hollow=2; 

            //hybrid,  gun,    fun,    fish,   long,   short
            //32,       16,     8,      4,      2,      1

            int iResult, iHigh, iMid, iLow;
            int iHighBase = (int)Math.Pow(2, 8);    //256
            int iMidBase = (int)Math.Pow(2, 2);     //4
            int iLowBase = (int)Math.Pow(2, 0);     //1

            //highest bits
            iLevel = Convert.ToInt32(cboLevel.SelectedValue);
            iHigh = iLevel * iHighBase;
            
            //middle
            iWaveSize = Convert.ToInt32(cboWaveSize.SelectedValue);
            iMid = iWaveSize * iMidBase;
    
            //low
            iGender = Convert.ToInt32(rdoWaveType.SelectedValue);
            iLow = iGender * iLowBase;

            iResult = iHigh + iMid + iLow;

            //ErrorLog.ErrorRoutine(false, "iResult: " + iResult);

            int iBoardCodeDec = 0;

            if (hs.ContainsKey((object)iResult))
            {
                iBoardCodeDec = (int)hs[iResult];
                
            }
            else
            {
                pnlResult.Controls.Add(new LiteralControl("DAH!"));
                return;
            }

            hdnBoardCode.Value = iBoardCodeDec.ToString();

            //iterate with boardcode result
            int val = Convert.ToInt32(hdnBoardCode.Value);

            //hybrid,   gun,    fun,    fish,   long,   short
            //32,       16,       8,      4,      2,      1 

            for (int i = 5; i >= 0; i--)
            {
                if ((mask & val) > 0)
                {
                    if (!lblResultIntro.Visible)
                        lblResultIntro.Visible = true;
                    
                    //add controls with proper mods
                    System.Web.UI.WebControls.Image imgBoard = new System.Web.UI.WebControls.Image();
                    
                    //Labels
                    Label bLabel = new Label();     //board
                    Label dLabel = new Label();     //dims
                    bLabel.CssClass = "midorange16b";
                    dLabel.CssClass = "dkgrey16";

                    int y = Convert.ToInt32(Math.Log(Convert.ToDouble(cboLevel.SelectedValue), 2)); //skill - vert      height[vert,horiz]

                    int Tot = Convert.ToInt32(cboHeightTotal.ToString()) + Convert.ToInt32(height2[y, i].ToString());

                    decimal dTot = Convert.ToDecimal(Tot);
                    decimal dDiv = dTot / Convert.ToDecimal(12);
                    double dFT = Math.Floor(Convert.ToDouble(dDiv));

                    dLabel.Text = "<b>Height:</b> " + dFT.ToString() + "' " + (Tot % 12) + "\"";

                    string dTh = CalcThickness(i) + " ";
                    dLabel.Text += dTh;

                    switch (i)
                    {
                        case 0:
                            bLabel.Text = " Shortboard: ";
                            imgBoard.ImageUrl = "images/shortboard.gif";
                            //imgBoard.ToolTip = "Shortboard | Intermediate to advanced, Waist high and bigger, Thin - lacks floatation";
                            imgBoard.ToolTip = "Shortboard | Recommended for intermediate to advanced, Typically ridden on punchy waist high to overhead, Thin and pointy with less floatation, Mostly under 7ft tall";
                            break;
                        case 1:
                            bLabel.Text = " Longboard: ";
                            imgBoard.ImageUrl = "images/longboard.gif";
                            //imgBoard.ToolTip = "Longboard|Ideal beginner board, Small to medium waves, Plenty floatation";
                            imgBoard.ToolTip = "Longboard|Ideal starter board but also for advanced, Typically ridden in various wave types knee high to overhead, Heavier with plenty floatation, Mostly over 9ft tall";
                            break;
                        case 2:
                            bLabel.Text = " Fish: ";
                            imgBoard.ImageUrl = "images/fish.gif";
                            //imgBoard.ToolTip = "Modern & Retro Fishes|Intermediate to advanced, Ideal for mushy waves, Short and stubbier board";
                            imgBoard.ToolTip = "Modern & Retro Fishes|Recommended for intermediate to advanced, Typically ridden on mushier waves knee high to head high, Shorter and stubbier than a shortboard, mostly under 6ft tall";
                            break;
                        case 3:
                            bLabel.Text = " Funshape/Egg: ";
                            imgBoard.ImageUrl = "images/funshape.gif";
                            //imgBoard.ToolTip = "Funshape & Eggs|Good board for beginners, Small to medium waves";
                            imgBoard.ToolTip = "Funshape & Eggs|Good beginner board but also for advanced, Typically ridden in mushier waves knee high to overhead, Mostly 7-9ft tall";
                            break;
                        case 4:
                            bLabel.Text = " Gun/Mini Gun: ";
                            imgBoard.ImageUrl = "images/gun.gif";
                            //imgBoard.ToolTip = "Gun & Miniguns|For advanced riders on BIG waves";
                            imgBoard.ToolTip = "Gun & Miniguns|For advanced riders, Typically ridden in fast and hollow waves 2-3X overhead, Long, narrow and pointy, Mostly 7-12ft tall";
                            break;
                        case 5:
                            bLabel.Text = " Hybrid: ";
                            imgBoard.ImageUrl = "images/hybrid.gif";
                            //imgBoard.ToolTip = "Hybrid|Intermediate to advanced, pulls in characteristics of other boards";
                            imgBoard.ToolTip = "Hybrid|Recommended for Intermediate to advanced, Typically ridden in mushy to punchy waves waist high to overhead, combines characteristics of two boards, Better floatation than a shortboard, Mostly 5-9ft tall";
                            break;
                        default:
                            break;
                    }

                    imgBoard.Attributes.Add("align", "middle");
                    imgBoard.Attributes.Add("class", "Tips");
                    //imgBoard.Attributes.Add("title", "test|Check1");

                    pnlResult.Controls.Add(imgBoard);
                    pnlResult.Controls.Add(new LiteralControl("&nbsp;"));
                    pnlResult.Controls.Add(bLabel);
                    pnlResult.Controls.Add(new LiteralControl("&nbsp;"));

                    pnlResult.Controls.Add(dLabel);
                    pnlResult.Controls.Add(new LiteralControl("<br><br>"));

                    imgBoard = null;
                    bLabel = null;

                }
                //shift mask
                mask = mask >> 1;
            }

            if (val > 0)
                ShowShapers(val);

        }
/*
 */
        private void ShowShapers(int sCode)
        {
            pnlShaperResults.Controls.Clear();
            
            if (sCode <= 0)
                return;

            pnlShaperResults.Visible = true;
            lblSHResultIntro.Visible = true;

            string ssCode;
            string strSQL = string.Empty;
            strSQL = @"SELECT u.iD, u.txtFullName, u.txtBrandName, u.profilePic, u.txtHomeTown, u.userDir, u.txtUserDetails, u.iAcctType, u.iStatus, u.iMerchantType, u.txtUserName, u.iWisdom, u.iShaperCode, u.iPageViewCount, u.iVoucher
                        FROM tblUser u 
                        INNER JOIN tblServices s ON u.iD = s.iUserId
                        WHERE u.iAcctType = 2 AND u.iMerchantType = 1 AND s.iServiceVal = 3 AND s.iStatus = 1";
        

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                while (dbManager.DataReader.Read())
                {
                    //ErrorLog.ErrorRoutine(false, "reading SH");

                    ssCode = dbManager.DataReader["iShaperCode"].ToString();

                    //ErrorLog.ErrorRoutine(false, "ssCode: " + ssCode);

                    double Num;
                    bool isNum = double.TryParse(ssCode, out Num);
                    if (isNum) 
                    {
                        if (((int)Num & sCode) > 0)
                        {
                            //add controls for shaper: image and name
                            System.Web.UI.WebControls.ImageButton imgBtnShaper = new System.Web.UI.WebControls.ImageButton();
                            Label bLabel = new Label();     //board
                            bLabel.CssClass = "dkorange20b";

                            imgBtnShaper.ID = "imgBtnShaper_" + dbManager.DataReader["iD"].ToString(); ;
                            imgBtnShaper.Attributes.Add("valign", "middle");
                            imgBtnShaper.CommandArgument = dbManager.DataReader["iD"].ToString();

                            imgBtnShaper.Click += new System.Web.UI.ImageClickEventHandler(this.DynamicButton_Click);

                            //strImgPath = "thmb_" + oImgPath.ToString();
                            imgBtnShaper.ImageUrl = hdnServer.Value + "/users/" + Global.ReplaceEx(dbManager.DataReader["userDir"].ToString(), @"\", @"/") + "thmb_" + dbManager.DataReader["profilePic"].ToString();
                            //imgBtnShaper.OnClientClick = ("javascript:__doPostBack('SeeShaper','" + dbManager.DataReader["iD"].ToString() + "');event.returnValue=false;return false;");
                            //imgBtnShaper.CommandArgument = dbManager.DataReader["iD"].ToString();
                            bLabel.Text = dbManager.DataReader["txtBrandName"].ToString();

                            pnlShaperResults.Controls.Add(imgBtnShaper);
                            pnlShaperResults.Controls.Add(new LiteralControl("&nbsp;"));
                            pnlShaperResults.Controls.Add(bLabel);
                            pnlShaperResults.Controls.Add(new LiteralControl("&nbsp;"));
                            pnlShaperResults.Controls.Add(new LiteralControl("<br><br>"));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Matrix:ShowShapers:Error:" + ex.Message);
                classes.Email.SendErrorEmail("Matrix:ShowShapers: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            

        }
        public void SeeShaper(string i)
        {
            ErrorLog.ErrorRoutine(false, "SeeShaper:" + i);
            Response.Redirect("~/Shaper/SurfboardShaper.aspx?q=" + i);
        
        }

/*
 */
        public void DynamicButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            ImageButton oBtn = (ImageButton)sender;
            // Code for the button click event goes here.
            //Shaper/SurfboardShaper.aspx?q=138
            Response.Redirect("~/Shaper/SurfboardShaper.aspx?q=" + oBtn.CommandArgument);
        }  
/*
 */
        private string CalcThickness(int x)
        {
            double a,b,r,lb,eThk,w;
            string sVal, sThk, sSrc;
            string pre = "&nbsp;&nbsp;&nbsp;<b>Thickness:</b> ";

            w = Convert.ToDouble(txtWeight.Text);

            b = thick[0,x];                     //high
            a = thick[1,x];                     //low
            lb = b - a;                         //thick diff
            r = ((w - 100)/220) * lb;           //right
            eThk = Math.Round((r + a) * 8) / 8; //round to nearest 8th -> 2.75

            try
            {

                sVal = eThk.ToString();         //"2.75"

                if (!sVal.Contains("."))                //ignore and return if .0
                    return pre + sVal + "\"";
    
                string[] sArr = sVal.Split('.');

                sSrc = "." + sArr[1];

                //check for ZERO
                if (hsF.ContainsKey((object)sSrc))
                {
                    sThk = sArr[0] + "+" + hsF[sSrc].ToString();
                }
                else
                {
                    sThk = sVal;
                }
                //ErrorLog.ErrorRoutine(false, "BT: " + x + " " + "HiThick: " + b + " LowThick: " + a);
                return pre + sThk + "\"";
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, ex.Message);
                return string.Empty;

            }
            finally
            {
                
            }

        }

/*
 * ACCESSOR METHODS for viewstate
 */
        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;   // default to showing the first page
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        //WAVETYPE
        public string cboWaveSizeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboWaveSizeVal"];
                if (o == null)
                    return ("Any");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboWaveSizeVal"] = value;
            }
        }
        //Total Human Weight Inches
        public int cboWeight
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboWeight"];
                if (o == null)
                    return (0);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboWeight"] = value;
            }
        }
        //Total Human Height Inches
        public int cboHeightTotal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboHeightTotal"];
                if (o == null)
                    return (0);   // default to showing "all"
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_cboHeightTotal"] = value;
            }
        }
/*
 *      
 */
        //WEIGHT
        public string hdnWeightVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_hdnWeightVal"];
                if (o == null)
                    return ("0");   // zero
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_weightVal"] = value;
            }
        }
/*        
 */
        public string rdoWaveTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_rdoWaveTypeVal"];
                if (o == null)
                    return ("0");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_rdoWaveTypeVal"] = value;
            }
        }

/*        
 */
        public string cboPostingTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboPostingTypeVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboPostingTypeVal"] = value;
            }
        }
        /*        
         */
        public string cboKeywordsVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboKeywordsVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboKeywordsVal"] = value;
            }
        }
        /*        
         */
        public string cboUserIdVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboUserIdVal"];
                if (o == null)
                    return (string.Empty);   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboUserIdVal"] = value;
            }
        }
        /*        
         */
        public string cboFinVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboFinVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboFinVal"] = value;
            }
        }

/*
 */
        public string cboBoardVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboBoardVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboBoardVal"] = value;
            }
        }

/*
 */
        public string cboTailTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboTailTypeVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboTailTypeVal"] = value;
            }
        }
/*
 */
        public string cboHtFtVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboHtFtVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboHtFtVal"] = value;
            }
        }
/*
 */
        public string cboAdTypeVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboAdTypeVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboAdTypeVal"] = value;
            }
        }
/*
 */
        public string cboConditionVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboConditionVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }
            set
            {
                this.ViewState["_cboConditionVal"] = value;
            }
        }
/*
 */
        public string cboLocationVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboLocationVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboLocationVal"] = value;
            }
        }
/*
 */
        public string cboSkillLevelVal
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_cboSkillLevelVal"];
                if (o == null)
                    return ("All");   // default to showing "all"
                else
                    return o.ToString();
            }

            set
            {
                this.ViewState["_cboSkillLevelVal"] = value;
            }
        }


        public string VerifyImage(object imgPicPath)
        {

            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                return "images/s1x1.gif";
            }
            else
            {
                return "images/camera.gif";
            }

        }
        /*
        */
        public string GetAdType(object adType)
        {

            if (adType == DBNull.Value || adType.ToString() == "")
            {
                return "images/s1x1.gif";
            }
            else
            {
                switch (adType.ToString())
                {
                    case "2":
                        return "images/wanted.gif";

                    default:
                        return "images/s1x1.gif";
                }
            }
        }

/*
*/
        public string SetBoardPic(object iCat, object iBT)
        {

            string retVal = "images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "images/s1x1.gif";
            }
            else
            {
                switch (iCat.ToString())
                {
                    case "1":
                        switch (iBT.ToString())
                        {
                            case "1":
                                retVal = "images/shortboard.gif";
                                break;
                            case "2":
                                retVal = "images/longboard.gif";
                                break;
                            case "4":
                                retVal = "images/fish.gif";
                                break;
                            case "8":
                                retVal = "images/funshape.gif";
                                break;
                            case "16":
                                retVal = "images/gun.gif";
                                break;
                            case "64":
                                retVal = "images/standup.gif";
                                break;
                            case "128":
                                retVal = "images/pro.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "2":
                        switch (iBT.ToString())
                        {
                            case "7":
                                retVal = "images/freeride.gif";
                                break;
                            case "8":
                                retVal = "images/freestyle.gif";
                                break;
                            case "9":
                                retVal = "images/carve.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "3":
                        switch (iBT.ToString())
                        {
                            case "26":
                                retVal = "images/skateboard.gif";
                                break;
                            default:
                                retVal = "images/s1x1.gif";
                                break;
                        }
                        break;
                    case "4":
                        break;
                    default:
                        retVal = "images/s1x1.gif";
                        break;
                }
            }
            return retVal;
        }
        /*
        */
        public string GetToolTip(object iCat, object iBT)
        {
            string retVal = "images/s1x1.gif";

            if (iBT == DBNull.Value || iBT.ToString() == "")
            {
                retVal = "images/s1x1.gif";
            }
            else
            {
                switch (iCat.ToString())
                {
                    //surfboards
                    case "1":
                        switch (iBT.ToString())
                        {
                            case "1":
                                retVal = "shortboard";
                                break;
                            case "2":
                                retVal = "longboard";
                                break;
                            case "4":
                                retVal = "fish/retro";
                                break;
                            case "8":
                                retVal = "funshape";
                                break;
                            case "16":
                                retVal = "gun";
                                break;
                            case "32":
                                retVal = "other";
                                break;
                            case "64":
                                retVal = "standup paddle";
                                break;
                            case "128":
                                retVal = "pro-model";
                                break;
                            default:
                                retVal = "";
                                break;
                        }
                        break;
                    //case "2":
                    //    break;
                    //case "3":
                    //    break;
                    //case "4":
                    //    break;
                    default:
                        retVal = "";
                        break;
                }
            }
            return retVal;
        }

/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, object oVal)
        {
            //set cLen to oVal
            int cLen = Convert.ToInt32(oVal);

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

        /*
         */
        public string FormatHeightFt(object heightFt)
        {
            string ht = heightFt.ToString();

            switch (Convert.ToInt32(Request.QueryString["iCat"]))
            {
                case 1:
                    ht = ht + "\'";
                    break;
                case 2:
                    ht = ht + " cm" + "&nbsp;";
                    break;
                case 3:
                    ht = "";
                    break;
                case 4:
                    ht = "";
                    break;
            }

            return ht;
        }
        /*
         */
        public string FormatHeightIn(object heightIn)
        {

            string inch = heightIn.ToString();

            switch (Convert.ToInt32(Request.QueryString["iCat"]))
            {
                case 1:
                    inch = inch + "\"" + "&nbsp;";
                    break;
                case 2:
                    inch = "";
                    break;
                case 3:
                    inch = "";
                    break;
                case 4:
                    inch = "";
                    break;
            }

            return inch;
        }

/*
*/
        public string SetPicPath(object iCat, object oUser, object oImgPath)//, object uD)
        {

            //set to clear pic for default
            string retVal = "images/s1x1.gif";
            string strImgPath;// = "thmbNail_" + oImgPath.ToString();

            //get the user dir for the person who posted
            //string iId = Global.ReplaceEx(SQLReader["userDir"].ToString(), @"\", @"/");

            if (oImgPath == DBNull.Value || oImgPath.ToString() == "")
            {
                return retVal;
            }
            else
            {
                string strServerURL;
                strImgPath = "thmbNail_" + oImgPath.ToString();

                hdnServer.Value = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];
                strServerURL = hdnServer.Value;
                //retVal = strServerURL + "/users/" + iId + iCat.ToString() + "/" + Path.GetFileName(strImgPath);

                retVal = strServerURL + "/users/" + oUser.ToString() + Global.DecodeCategory(iCat) + "/" + Path.GetFileName(strImgPath);

            }
            return retVal;
        }
/*
 */
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }

        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Response.Redirect("http://zappos.com");
            //Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString());//+ "&uId=" + e.CommandName.ToString() + "&iCat=" + Request.QueryString["iCat"].ToString());
        }

        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignIn.Text);
        }

        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);

        }

        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post.aspx");

        }


/*
 */
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Matrix:SearchClicked");

            //Get/Set Values
            cboWaveSizeVal = cboWaveSize.SelectedValue; //wavesize
            cboSkillLevelVal = cboLevel.SelectedValue;  //skill level

            rdoWaveTypeVal = rdoWaveType.SelectedValue; //wave type

            cboHeightTotal = Convert.ToInt32(txtHtFt.Text) * 12 + Convert.ToInt32(txtHtIn.Text);    //height
            hdnWeight.Value = txtWeight.Text;   //weight

            ShowResults();
        }

        /*
         * Here we just load and set everything to the default values.
         * NOTE: When any filter fields are changed followed by a search button click, 
         * the new vaules are set and the page will requery.
         * */
        private void LoadFilter()
        {
            //TODO: height, weight, gender, wave type, experience

            //wave height: knee high, waist high, chest, head, overhead. 
            //level:novice, expert
            
            //wavetype:
            //ListItem liWSAny = new ListItem("Any", "0", true);  //Any
            ListItem liWSKnee = new ListItem("Knee", "1"); //small
            ListItem liWSWaist = new ListItem("Waist", "2");  //waist
            ListItem liWSChest = new ListItem("Chest", "4");  //overhead
            ListItem liWSHead = new ListItem("Head", "8");
            ListItem liWSOH = new ListItem("Overhead", "16");
            ListItem liWS2OH = new ListItem("2xOverhead", "32");

            //cboWaveSize.Items.Add(liWSAny);
            cboWaveSize.Items.Add(liWSKnee);
            cboWaveSize.Items.Add(liWSWaist);
            cboWaveSize.Items.Add(liWSChest);
            cboWaveSize.Items.Add(liWSHead);
            cboWaveSize.Items.Add(liWSOH);
            cboWaveSize.Items.Add(liWS2OH);

            //Gender:
            ListItem liRollers = new ListItem("Rollers", "1", true);  //Any
            //liRollers.Attributes.Add("OnClick", "ShowPic('wave_roller.gif')");
            ListItem liHollow = new ListItem("Hollow", "2"); //small
            //liHollow.Attributes.Add("OnClick", "ShowPic('wave_barrel.gif')");
            rdoWaveType.Items.Add(liRollers);
            rdoWaveType.Items.Add(liHollow);
            rdoWaveType.SelectedIndex = 0;

            //Skill Level:
            ListItem liLvlBeg = new ListItem("Newbie", "1", true);  //Any
            ListItem liLvlInter = new ListItem("Intermediate", "2"); //small
            ListItem liLvlAdv = new ListItem("Advanced", "4");  //waist
            //ListItem liLvlPro = new ListItem("Pro", "8");  //overhead
            cboLevel.Items.Add(liLvlBeg);
            cboLevel.Items.Add(liLvlInter);
            cboLevel.Items.Add(liLvlAdv);
            //cboLevel.Items.Add(liLvlPro);

        }
/**
*/
        public string DecodeRegion(object RegionCode)
        {
            return Enum.GetName(typeof(Global.REGION), RegionCode);
        }
/**
*/
        public string DecodeAdType(object AdCode)
        {
            return Enum.GetName(typeof(Global.AD_TYPE), AdCode);
        }
/**
*/
        public string DecodeiCat(object iCat)
        {
            return Global.ReplaceEx(Enum.GetName(typeof(Global.BOARDCAT_TYPE), iCat), "_", " ");
        }


/*
 */
        //Helper function to determine if value is numeric
        private bool IsNumeric(object valType)
        {
            double tempVal = new double();
            string InputValue = Convert.ToString(valType);

            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out tempVal);

            return Numeric;
        }
/*
 */
        private string BuildQryBoardType(string sBoardType)
        {
            int intBoardType = Convert.ToInt32(sBoardType);

            string strBType = " AND";

            if ((BitMask_0 & intBoardType) > 0)
                strBType += " e.iBoardType = 1";
            if ((BitMask_1 & intBoardType) > 0)
                strBType += " e.iBoardType = 2";
            if ((BitMask_2 & intBoardType) > 0)
                strBType += " e.iBoardType = 3";
            if ((BitMask_3 & intBoardType) > 0)
                strBType += " e.iBoardType = 4";
            if ((BitMask_4 & intBoardType) > 0)
                strBType += " e.iBoardType = 5";
            if ((BitMask_5 & intBoardType) > 0)
                strBType += " e.iBoardType = 6";
            if ((BitMask_6 & intBoardType) > 0)
                strBType += " e.iBoardType = 24";
            if ((BitMask_7 & intBoardType) > 0)
                strBType += " e.iBoardType = 27";
            if ((BitMask_8 & intBoardType) > 0)
                strBType += " e.iBoardType = 28";

            //ErrorLog.ErrorRoutine(false, "0&: " + (BitMask_0 & intBoardType));
            //ErrorLog.ErrorRoutine(false, "1&: " + (BitMask_1 & intBoardType));
            //ErrorLog.ErrorRoutine(false, "StrBT: " + strBType);

            return strBType;
        }

    }
}
