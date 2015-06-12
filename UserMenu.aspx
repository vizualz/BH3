<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMenu.aspx.cs" Inherits="BoardHunt.UserMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Menu - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>--%>

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript" src="include/js/jquery.jgrowl.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('a.Tips').cluetip({ splitTitle: '|', width: 165, clickThrough: true });
            $('span.Tips').cluetip({ splitTitle: '|' });

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>

    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <div id="main1" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="include/HeaderResponsive.aspx" -->

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-8 col-md-10 col-sm-12 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="bg-light dark br-b br-grey posr col-lg-12 col-md-12 col-sm-12 col-xs-12 pn">
                        <div class="col-md-12 col-sm-12 col-xs-12 pt10 pb10">
                            <div class="col-md-6 col-sm-6 col-xs-6  text-left">
                                                                <h2>Dashboard <small>/ Profile</small></h2>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6 pt10 text-right">
                                <asp:Button ID="btnUpgradePro" runat="server" CssClass="btn btn-rounded btn-success btn-sm" Text="Upgrade to Pro" Visible="true"
                                    OnClick="btnUpgradePro_Click" title="Upgrade Account|Get all the Pro features including Nudge and Advanced Filters" />
                            </div>

                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-8 pn pb10 pl10">
                            <div class="col-md-3 col-sm-3 col-xs-4 pn">
                                <asp:ImageButton ID="imgBtnAcct" CssClass="thumbnail" title="Account|Change your pic, displayname, or other account settings"
                                    ImageUrl="images/menu_account_off.gif" runat="server" />
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-8 pn text-left">
                                <div class="pt5">
                                    <asp:HyperLink ID="hypAcctEdit" CssClass="text-dark fs22 fw600" style="text-transform: capitalize;" runat="server"></asp:HyperLink>
                                </div>
                                <div class="pt20">
                                    <asp:LinkButton ID="btnEditProfile" runat="server" CssClass="fs14 fw600 text-success" Text="Edit Profile" Visible="true"
                                        OnClick="btnSettings_Click" title="Edit|Change your settings" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-4 pn pb10 pr10 text-right">
                            <div class="pt5">
                                <asp:LinkButton ID="lnkFav" runat="server" CssClass="text-warning">Favorites</asp:LinkButton>
                            </div>
                            <div class="pt5">
                                <asp:Label ID="lblBoardPostCnt" runat="server" CssClass="text-warning"></asp:Label>
                            </div>
                            <div class="pt5">
                                <asp:Label ID="lblNudgeCnt" runat="server" CssClass="text-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="panel panel-warning heading-border col-lg-12 col-md-12 col-sm-12 col-xs-12 pn mt20">
                        <div class="panel-body p15 mt10">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pn">
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 pn">
                                    <div class="col-lg-6 col-md-6 col-sm-3 col-xs-6 pn">
                                        <asp:ImageButton CssClass="thumbnail" title="Sell|Post your surboards up for sale so buyers can make you a cash offer."
                                            ID="ImageButton1" ImageUrl="images/menu_sell.gif" runat="server" />
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pn">
                                        <span class="text-success fs24 fw600">Sell Surfboards</span>
                                        <br />
                                        <small>New, used, or wanted items.</small><br />
                                        <asp:Label ID="lblBoardCount" runat="server" CssClass="midorange12"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 pn text-right">
                                    <asp:LinkButton ID="lnkSellGear" runat="server" CssClass="text-dark-light"><i class="fa fa-plus"></i>&nbsp; New Post</asp:LinkButton>
                                    <br />
                                    <asp:LinkButton ID="lnkEditGear" runat="server" CssClass="text-dark-light"><i class="fa fa-pencil"></i>&nbsp;Edit Post</asp:LinkButton>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="p5" />
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pn">
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 pn">
                                    <div class="col-lg-6 col-md-6 col-sm-3 col-xs-6 pn">
                                        <asp:ImageButton CssClass="thumbnail" title="Ask-a-Pro|A portal for Boardhunt users to ask and answer questions"
                                            ID="ImageButton2" ImageUrl="images/menu_ask.gif" runat="server" />
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pn">
                                        <span class="text-success fs24 fw600">Ask-a-Pro</span>
                                        <br />
                                        <small>Ask surf questions</small>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 text-right pn">
                                    <asp:LinkButton ID="lnkAskNew" runat="server" CssClass="text-dark-light"><i class="fa fa-plus"></i>&nbsp; New Question</asp:LinkButton>
                                    <br />
                                    <asp:LinkButton ID="lnkAskEdit" runat="server" CssClass="text-dark-light"><i class="fa fa-pencil"></i>&nbsp; Edit Question</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>
            <div align="center" style="display:none;">

                 <asp:Label ID="lblMessage" runat="server" CssClass="cathead"> 
                </asp:Label>
                <br />
                <!-- PROFILE -->

                <br />
                <div align="left" style="background-color: #ffffff; width: 900px; height: 140px; border-bottom: solid 5px #666666">
                    <div id="profileDivLt" style="float: left; width: 600px; height: 140px; border: solid 0px #666666"
                        align="center">

                        <div style="float: left; border: solid 0px black; width: 250px; height: 136px; background-color: #f0f0f0">
                            <br />
                            <%--<asp:HyperLink ID="hypAcctEdit" CssClass="orange_dkorange18" runat="server"></asp:HyperLink>--%>
                            <br />
                            <%--<asp:ImageButton ID="imgBtnAcct" CssClass="Tips" title="Account|Change your pic, displayname, or other account settings"
                                ImageUrl="images/menu_account_off.gif" BackColor="#f0f0f0" runat="server" />--%><br />
                            <%--<asp:Button ID="btnEditProfile" runat="server" Height="20px" Width="80px" CssClass="btnStep" Text="Edit Profile" Visible="true"
                                OnClick="btnSettings_Click" title="Edit|Change your settings" Style="font-size: 11px; margin-top: 2px" />--%>
                        </div>
                        <div align="center" style="float: right; border: solid 0px black; width: 300px;">
                            <span class="dkgrey40">Dashboard</span><br />
                            <span class="midorange12"></span>


                            <br />
                            <br />
                            <%--<asp:Button ID="btnUpgradePro" runat="server" Height="30px" Width="160px" CssClass="gobutton Tips" Text="Upgrade to Pro" Visible="true"
                                OnClick="btnUpgradePro_Click" title="Upgrade Account|Get all the Pro features including Nudge and Advanced Filters" />--%>
                        </div>
                    </div>

                    <div id="profileDivRt" style="margin-left: 10px; padding-left: 3px; float: right; border: solid 0px white; width: 200px; height: 136px; background-color: #f0f0f0"
                        align="left">
                        <!---<br />
                        <asp:LinkButton ID="lnkEditProfile" runat="server" CssClass="grey_grey18">&nbsp;Edit Account Info</asp:LinkButton>
                        -->
                        <br />
                        <%--<asp:LinkButton ID="lnkFav" runat="server" CssClass="orange_dkorange18">Favorites</asp:LinkButton>
                        <br />
                        <asp:Label ID="lblBoardPostCnt" runat="server" CssClass="midorange18"></asp:Label>
                        <br />
                        <asp:Label ID="lblNudgeCnt" runat="server" CssClass="midorange18"></asp:Label>--%>
                    </div>
                </div>
                <!-- SHAPERS -->
                <div align="center" style="border: solid 0px black; width: 900px;">

                    <asp:Panel ID="pnlShaper" runat="server">
                        <div align="center" style="background-color: #ffffff; width: 550px; height: 130px;">
                            <div id="Div9" style="float: left; width: 395px; border: solid 0px green" align="center">
                                <br />
                                <div style="float: left; border: solid 0px white; width: 150px">
                                    <asp:ImageButton CssClass="Tips" title="ShaperHouse|Increase your exposure, post pics and videos of your surfboard models, and allow users to contact you"
                                        ID="imgBtnShapers" ImageUrl="images/shaperhouse_menu.gif" runat="server" />
                                </div>
                                <div align="left" style="float: left; border: solid 0px white; width: 225px;">
                                    <span class="midgreen30b2">ShaperHouse</span><br />
                                    <span class="dkgrey14">Display new surfboard models</span>

                                </div>
                            </div>
                            <div id="Div1" style="float: left; border: solid 0px #666666; width: 150px;" align="left">
                                <br />
                                <div style="float: left; width: 150px">
                                    <asp:Panel ID="pnlShaperBuy" runat="server">
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btnBuyShaper" ImageUrl="images/buy.gif" runat="server" />
                                        &nbsp;
                                    
                                    <asp:LinkButton ID="lnkShaperMoreInfo" OnCommand="GetMoreInfo" CssClass="ltgreen20b"
                                        runat="server">?</asp:LinkButton>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlShaperCtls" runat="server">
                                        <asp:LinkButton ID="lnkAddNewModel" runat="server" CssClass="grey_grey18">&nbsp;New Model&nbsp;<span class="ltgreen18b">+</span></asp:LinkButton>
                                        <br />
                                        <asp:LinkButton ID="lnkEditModel" runat="server" CssClass="grey_grey18">&nbsp;Edit Model</asp:LinkButton>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>


                    <!--Coupons-->
                    <asp:Panel ID="pnlQP" runat="server" Visible="false">
                        <div align="center" style="border: solid 0px red; width: 550px; height: 130px; background-color: #ffffff">
                            <div id="Div8" style="float: left; width: 395px; border: solid 0px green" align="center">
                                <br />
                                <div style="float: left; border: solid 0px black; width: 150px">
                                    <asp:ImageButton CssClass="Tips" title="Coupons|Allows you to offer your coupons to the Boardhunt community via text messaging" ID="imgBtnQPon" ImageUrl="images/menu_coupon.gif" runat="server" />
                                </div>
                                <div align="left" style="float: left; border: solid 0px black; width: 225px">
                                    <span class="midgreen30b3" style="height: 50px">Coupons</span>
                                    &nbsp;&nbsp;&nbsp;
                                <span class="ltorange14b" style="background-color: #ff6600">&nbsp;<span class="Tips" title="Free Coupon Trial|Enter in the Promo code 'COUPONZ' when you purchase for 10 free Text-me coupons.  Click 'New Coupon' to start.">FREE 
                                TRIAL</span>&nbsp;</span>
                                    <br />
                                    <span class="dkgrey14">Create coupons for text messaging</span>
                                    <br />

                                    <br />
                                </div>
                            </div>
                            <div id="divQP" style="float: left; border: solid 0px black; width: 140px;" align="left">
                                <br />
                                <asp:LinkButton ID="lnkBuyQP" runat="server" CssClass="grey_grey18">&nbsp;New Coupon&nbsp;<span class="ltgreen20b">+</span></asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkManageQP" runat="server" CssClass="grey_grey18">&nbsp;Edit Coupon</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkSettings" runat="server" CssClass="grey_grey18">&nbsp;Edit Footer</asp:LinkButton>
                            </div>
                        </div>
                    </asp:Panel>

                </div>


                <!-- SELL -->
                <div align="center" style="width: 550px; height: 130px; background-color: #ffffff">
                    <div id="Div2" style="float: left; width: 395px; border: solid 0px green" align="center">
                        <br />
                        <div style="float: left; border: solid 0px white; width: 150px">
                            <%-- <asp:ImageButton CssClass="Tips" title="Sell|Post your surboards up for sale so buyers can make you a cash offer."
                                ID="ImageButton1" ImageUrl="images/menu_sell.gif" runat="server" />--%>
                        </div>
                        <div align="left" style="float: left; border: solid 0px white; width: 225px">
                            <%--<span class="midgreen30b" style="height: 50px">Sell Surfboards</span>
                            <br />
                            <span class="dkgrey14">New, used, or wanted items.</span><br />
                            <asp:Label ID="lblBoardCount" runat="server" CssClass="midorange12"></asp:Label>--%>
                        </div>
                    </div>
                    <div id="Div3" style="float: left; border: solid 0px white; width: 140px;" align="left">
                        <br />
                        <%--<asp:LinkButton ID="lnkSellGear" runat="server" CssClass="grey_grey18">&nbsp;New Post&nbsp;<span class="ltgreen18b">+</span></asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="lnkEditGear" runat="server" CssClass="grey_grey18">&nbsp;Edit Post</asp:LinkButton>--%>
                    </div>
                </div>
                <!-- AAP -->
                <div align="center" style="width: 550px; height: 130px; background-color: #ffffff">
                    <div id="Div4" style="float: left; width: 395px; border: solid 0px green" align="center">
                        <br />
                        <div style="float: left; border: solid 0px white; width: 150px">
                            <%-- <asp:ImageButton CssClass="Tips" title="Ask-a-Pro|A portal for Boardhunt users to ask and answer questions"
                                ID="ImageButton2" ImageUrl="images/menu_ask.gif" runat="server" />--%>
                        </div>
                        <div align="left" style="float: left; border: solid 0px white; width: 225px">
                            <%--<span class="dkgreen30b" style="height: 50px">Ask-a-Pro</span>
                            <br />
                            <span class="dkgrey14">Ask surf questions</span>
                            --%><br />
                            <br />
                        </div>
                    </div>
                    <div id="Div5" style="float: left; border: solid 0px white; width: 140px;" align="left">
                        <br />
                        <%--<asp:LinkButton ID="lnkAskNew" runat="server" CssClass="grey_grey18">&nbsp;New Question&nbsp;<span class="ltgreen18b">+</span></asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="lnkAskEdit" runat="server" CssClass="grey_grey18">&nbsp;Edit Question</asp:LinkButton>--%>
                    </div>
                </div>
                <!-- SHOWCASE -->
                <asp:Panel ID="pnlShowcase" runat="server">
                    <div align="center" style="width: 520px; height: 130px; background-color: #FFFFFF">
                        <div id="Div6" style="float: left; width: 395px; border: solid 0px green" align="center">
                            <br />
                            <div style="float: left; border: solid 0px white; width: 150px">
                                <asp:ImageButton ID="ImageButton4" ImageUrl="images/menu_account_off.gif" runat="server" />
                            </div>
                            <div align="left" style="float: left; border: solid 0px white; width: 225px">
                                <span class="dkgreen30b" style="height: 50px">Showcase</span>
                                <br />
                                <span class="dkgrey14">Showcase Products</span>
                                <br />
                                <br />
                            </div>
                        </div>
                        <div id="Div10" style="float: left; border: solid 0px white; width: 100px;" align="left">
                            <br />
                            <asp:LinkButton ID="lnkShowcaseNew" runat="server" CssClass="dkgrey_orange12"><img src="images/orangebox.gif" border="0" />&nbsp;Showcase</asp:LinkButton>
                            <br />
                        </div>
                    </div>
                </asp:Panel>




                <asp:Panel ID="pnlBlog" runat="server" Visible="false">
                    <div align="center" style="width: 550px; height: 130px; background-color: #FFFFFF">
                        <div id="Div11" style="float: left; width: 395px; border: solid 0px green" align="center">
                            <br />
                            <div style="float: left; border: solid 0px white; width: 150px">
                                <asp:ImageButton ID="ImageButton5" ImageUrl="images/menu_account_off.gif" runat="server" />
                            </div>
                            <div align="left" style="float: left; border: solid 0px white; width: 225px">
                                <span class="dkgreen30b" style="height: 50px">Blog</span>
                                <br />
                                <span class="dkgrey14">Bloggings</span>
                                <br />
                                <br />
                            </div>
                        </div>
                        <div id="Div7" style="float: left; border: solid 0px white; width: 140px;" align="left">
                            <br />
                            <asp:LinkButton ID="lnkBlogNew" runat="server" CssClass="grey_grey18">&nbsp;Post New&nbsp;<span class="ltgreen18b">+</span></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkBlogEdit" runat="server" CssClass="grey_grey18">&nbsp;Edit</asp:LinkButton>
                        </div>
                    </div>
                </asp:Panel>
                <!-- TODO: Bidder/Subscription -->
                <asp:Panel ID="pnlBidder" runat="server" Visible="false">
                    <asp:ImageButton ID="imgBidder" onmouseover="this.src='images/icon_blogon.gif'" onmouseout="this.src='images/icon_blogoff.gif'"
                        runat="server" ToolTip="Click to start a board bid" ImageUrl="images/icon_blogoff.gif"></asp:ImageButton>
                    <a class="midgrey_dkgrey18" href="Bidder/PostBid.aspx">Start a bid</a>&nbsp;
                </asp:Panel>
                <asp:Panel ID="pnlSUB" runat="server" Visible="false">
                    <asp:ImageButton ID="imgBtnSubscription" onmouseover="this.src='images/icon_blogon.gif'"
                        onmouseout="this.src='images/icon_blogoff.gif'" runat="server" ToolTip="Click to manage subscriptions"
                        ImageUrl="images/icon_blogoff.gif"></asp:ImageButton>
                    <a class="midgrey_dkgrey18" href="SubscriptionManager.aspx">Subscriptions</a>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="hdnACT" runat="server" />
            <asp:HiddenField ID="hdnMT" runat="server" />
            <asp:HiddenField ID="hdnShaperAcctValid" runat="server" Value="N" />
            <asp:HiddenField ID="hdnIsPro" runat="server" Value="-1" />
            <div id="push">
            </div>
        </form>
    </div>
    
    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->

    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <!-- Bootstrap -->
    <script type="text/javascript" src="content/assets/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->

    <!-- Theme Javascript -->
    <script type="text/javascript" src="content/assets/js/utility/utility.js"></script>
    <script type="text/javascript" src="content/assets/js/main.js"></script>
    <script type="text/javascript" src="content/assets/js/demo.js"></script>

    <!-- Page Javascript -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            "use strict";

            // Init Theme Core      
            Core.init();

            // Init Demo JS
            Demo.init();
        });
    </script>
</body>
</html>
