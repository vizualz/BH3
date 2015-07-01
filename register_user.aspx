<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register_user.aspx.cs" Inherits="BoardHunt.register_user" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup and sell your surfboard | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">
        
    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });

        $(document).ready(function () { $(".defaultText").focus(function (a) { if ($(this).val() == $(this)[0].title) { $(this).removeClass("defaultTextActive"); $(this).val("") } }); $(".defaultText").blur(function () { if ($(this).val() == "") { $(this).addClass("defaultTextActive"); $(this).val($(this)[0].title) } }); $(".defaultText").blur() })

    </script>
</head>
<body style="background: none repeat scroll 0 0 #fff;">
        <form class="header" id="Form1" runat="server">
            <bh:Header runat="server" />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-6 col-sm-6 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-pencil-square"></i>Create Account</span>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                                <span>I'm a member,&nbsp;<a class="ltgreen_orange12 fs14" href="Login.aspx">Log in</a></span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="text-left">
                                <span>Join to find boards or sell them. <span class="midorange14b">Go Pro </span>for more convenience.</span>
                            </div>
                            <div class="section row">
                                <div class="col-md-6 border-right">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                        <span>Create Account</span>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="username" class="field-label text-left fs18 mb10">E-mail<strong class="text-danger">&nbsp;*</strong></label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <label for="Email" class="field prepend-icon">
                                                <asp:TextBox ID="txtEmail" runat="server" class="gui-input" placeholder="Enter your E-mail"></asp:TextBox>
                                                <label for="Email" class="field-icon">
                                                    <i class="fa fa-user"></i>
                                                </label>
                                            </label>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" ValidationGroup="Register" CssClass="fs20 error" ErrorMessage="!" Display="Static"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="!"
                                                OnServerValidate="CheckEmail" CssClass="error"></asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="username" class="field-label text-left fs18 mb10">Password<strong class="text-danger">&nbsp;*</strong></label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <label for="password" class="field prepend-icon">
                                                <asp:TextBox ID="txtPassword1" runat="server" class="gui-input" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                                <label for="password" class="field-icon">
                                                    <i class="fa fa-lock"></i>
                                                </label>
                                            </label>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword1" ValidationGroup="Register" CssClass="fs20 error" ErrorMessage="!" Display="Static"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="!" ValidationGroup="Register" OnServerValidate="CheckPassword"
                                                CssClass="error"></asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 pn">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="Phone" class="field-label text-left fs18 mb10">Phone</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <label for="Phone" class="field prepend-icon">
                                                <asp:TextBox ID="txtPhoneNum" runat="server" class="gui-input" placeholder="Enter pnone number" MaxLength="20" title="optional"></asp:TextBox>
                                                <label for="Phone" class="field-icon">
                                                    <i class="fa fa-phone-square"></i>
                                                </label>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 pn">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="business" class="field-label text-left fs18 mb10">Are you a business?</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <div class="radio-custom mb5">
                                                <asp:RadioButtonList ID="radioAcctType" runat="server" CssClass="dkgrey12" Enabled="true"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="2" Onclick="TogglePanel(this.value,'div_businessType','1');ToggleElement('chkUpgrade',0);ToggleElement('chkUpgrade2',0)">Yes &nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1" Onclick="TogglePanel(this.value,'div_businessType','1');ToggleElement('chkUpgrade',1);ToggleElement('chkUpgrade2',1)" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="div_businessType" style="display: none;" class="col-md-12 col-sm-12 col-xs-12 mb10 pn">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="Whattype" class="field-label text-left fs18 mb10">What type?</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <div class="section">
                                                <label class="field select">
                                                    <asp:DropDownList ID="cboMerchantType" runat="server">
                                                        <asp:ListItem Value="0" Selected="True">Pick one...</asp:ListItem>
                                                        <asp:ListItem Value="1">Shaper/Manufacturer</asp:ListItem>
                                                        <asp:ListItem Value="2">Retailer/Service</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <i class="arrow double"></i>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 pn">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="GoPro" class="field-label text-left fs18 mb10">Go Pro</label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <div class="col-md-5 col-sm-5 col-xs-5 pn">
                                                <div class="col-md-2 col-sm-2 col-xs-2">
                                                    <label class="block mt15 option option-default">
                                                        <asp:CheckBox ID="chkUpgrade" OnClick="CheckPro('0')" runat="server" Text="" />
                                                        <span class="checkbox"></span>
                                                    </label>
                                                </div>
                                                <div class="col-md-4 col-sm-4 col-xs-4">
                                                    <label for="chkUpgrade">
                                                        <img src="images/gopro3mo.gif" alt="" /></label>
                                                </div>
                                            </div>
                                            <div class="col-md-5 col-sm-5 col-xs-5 pn">
                                                <div class="col-md-2 col-sm-2 col-xs-2">
                                                    <label class="block mt15 option option-default">
                                                        <asp:CheckBox ID="chkUpgrade2" runat="server" OnClick="CheckPro('1')" Text="" />
                                                        <span class="checkbox"></span>
                                                    </label>
                                                </div>
                                                <div class="col-md-4 col-sm-4 col-xs-4">
                                                    <label for="chkUpgrade2">
                                                        <img src="images/gopro1yr.gif" alt="" /></label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 pn">
                                        <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="text-left">
                                            <br />
                                            <asp:Label ID="lblStatus" CssClass="error" runat="server"></asp:Label>
                                        </asp:Panel>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 pn text-left">
                                        <span class="fs13">By signing up you agree to our <a class="ltgreen_orange12" href="#" onclick="popUpHelp('3')">Terms.</a></span>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 text-left pn">
                                        <asp:Button ValidationGroup="Register" ID="btnFinish" runat="server" CssClass="button btn-primary" OnClick="btnFinish_Click" OnClientClick="HideElement('btnFinish', 'lblPW');SetElement('hdnMeVal','1');" Text="Create account" />
                                        <span id="lblPW" class="dkorange12b"></span>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                        <span>Features</span>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                        <div class="thumbnail col-md-12 col-sm-12 col-xs-12 mn">
                                            <img align="left" src="images/accounts.png" />
                                        </div>
                                        <%--<asp:Label ID="lblMessage" ForeColor="Red" Style="border: solid 1px red" runat="server"
                                            CssClass="error-text col-md-11 col-sm-11 col-xs-11 pn text-left fs14" Visible="false">&nbsp;</asp:Label>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-8 col-sm-9 col-xs-12 mt15" style="float: none; margin: 0 auto;">
                    <div class="text-left mb20">
                        <span class="text-warning fs20">Want to advertise on Boardhunt?<a href="/contact.aspx" class="text-success fs22">&nbsp;Contact us</a> for details.</span>
                    </div>
                    <div class="text-left mb10">
                        <span class="text-warning fw600 fs20">FAQ</span>
                    </div>
                    <div class="panel-group accordion" id="accordion">
                        <div class="panel">
                            <div class="panel-heading  text-left">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord1"><span class="fs14">Does Boardhunt sell boards? </span></a>
                            </div>
                            <div id="accord1" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    No, the seller does. We just connect you two.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord2">
                                    <span class="fs14">How is BH better than CL, or similar sites?</span>
                                </a>
                            </div>
                            <div id="accord2" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    We know surf and tech. We don't just list boards,
                    we make it easier to find and sell them with advanced features. We care about accuracy
                    and your time.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord3">
                                    <span class="fs14">Can I post for free?</span>
                                </a>
                            </div>
                            <div id="accord3" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Yes, but only two items at a time. Otherwise it's
                    only $19 per year.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord4">
                                    <span class="fs14">Does BH sell our info?</span>
                                </a>
                            </div>
                            <div id="accord4" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Never.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord5">
                                    <span class="fs14">How many pics can I post?</span>
                                </a>
                            </div>
                            <div id="accord5" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Up to three..
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord6">
                                    <span class="fs14">How do I connect with a buyer?</span>
                                </a>
                            </div>
                            <div id="accord6" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Directly. By email, phone, face to face.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord7">
                                    <span class="fs14">How long do boards stay posted?</span>
                                </a>
                            </div>
                            <div id="accord7" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Up to one year then they are deleted.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord8">
                                    <span class="fs14">How does BH maintain quality?</span>
                                </a>
                            </div>
                            <div id="accord8" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    We remove junk. We also fix miscategorized items.
                                </div>
                            </div>
                            <div class="panel-heading  text-left mt5">
                                <a class="accordion-toggle accordion-icon link-unstyled collapsed" aria-expanded="false" data-toggle="collapse" data-parent="#accordion" href="#accord9">
                                    <span class="fs14">Why can retail post here?</span>
                                </a>
                            </div>
                            <div id="accord9" class="panel-collapse collapse" style="height: auto;">
                                <div class="panel-body text-justify">
                                    Because they have good boards for sale. We make
                    it easy to separate them out in our advanced filters.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnMeVal" Value="0" runat="server" />
        </form>

    <div class="clearfix"></div>
        <!-- #include file="include/footer.aspx" -->
    
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-2548219-1");
        pageTracker._initData();
        pageTracker._trackPageview();

        //function checkControl() {
        //    var Email = $("#txtEmail").val();
        //    if (Email != "") {
        //        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        //        if (!emailPattern.test(Email)) {
        //            $('#txtEmail').attr("style","1px solid red");
        //        }
        //    } else {
        //        $('#txtEmail').attr("style", "1px solid red");
        //    }

        //    var Password = $("#txtPassword1").val();
        //    if (Password == "")
        //    {
        //        $('#txtPassword1').attr("style", "1px solid red");
        //    }
        //}
    </script>
    <script type='text/javascript'>

        var _ues = {
            host: 'boardhunt.userecho.com',
            forum: '6121',
            lang: 'en',
            tab_corner_radius: 10,
            tab_font_size: 20,
            tab_image_hash: 'RmVlZGJhY2s%3D',
            tab_alignment: 'left',
            tab_text_color: '#FFFFFF',
            tab_bg_color: '#FF9900',
            tab_hover_color: '#FF6600'
        };

        (function () {
            var _ue = document.createElement('script'); _ue.type = 'text/javascript'; _ue.async = true;
            _ue.src = ('https:' == document.location.protocol ? 'https://s3.amazonaws.com/' : 'http://') + 'cdn.userecho.com/js/widget-1.4.gz.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(_ue, s);
        })();




</script>


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