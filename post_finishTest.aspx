<%@ Page Language="C#" AutoEventWireup="true" CodeFile="post_finishTest.aspx.cs" Inherits="BoardHunt.post_finishTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Finish - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>--%>

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });

            $.ajax({
                url: '/wsBH/BHService.asmx/CreateRSS',
                success: function (data) {
                }
            });

        });
    </script>
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <!-- Theme CSS -->
</head>
<body>
    <div id="main1" align="center">
        <form id="Form1" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-8 col-md-8 col-sm-10 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                
                                    <asp:Image runat="server" ID="imgCheckDone" ImageUrl="images/greencheck.gif" />
                                    <span class="panel-title">You&#39;re all set. </span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <asp:Panel ID="pnlBoost" runat="server">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="#FFFFFF"></asp:Label>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12 thumbnail br-n mn">
                                    <asp:LinkButton ID="btnUpgradePro"  OnClick="btnUpgradePro_Click" runat="server">
                                    <asp:Image ID="img1" runat="server" ImageUrl="images/ProUpgradeImage.jpg" /></asp:LinkButton>
                                </div>
                                 <div class="col-md-6 col-sm-6 col-xs-12 thumbnail br-n mn">
                                    <asp:LinkButton ID="lnkFBShare" runat="server">
                                    <img src="images/fb_share.jpg" border="0" alt="Post to your Facebook" align="top" />
                                    </asp:LinkButton>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12 thumbnail br-n mn">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/BoostImage.gif" OnClick="btnUpgrade_Click" />
                                </div>
                               
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label class="col-md-2 col-sm-2 col-xs-12 text-left field-label">View Your Post:</label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox align="left" ID="txtEntryLink" CssClass="gui-input" OnClick="select()"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-left mt10">
                                    <span class="text-dark fs16 fw600">More Options:</span>
                                    <br />
                                    <asp:HyperLink CssClass="text-warning fs14" ID="hypLnkPost" runat="server" NavigateUrl="post.aspx">Post Another</asp:HyperLink>
                                    <asp:HyperLink CssClass="text-warning fs14" ID="hypLnkPostModel" runat="server" NavigateUrl="post_item.aspx?q=4">Post Another Model</asp:HyperLink>
                                    <asp:HyperLink ID="lnkPostItem" runat="server" CssClass="text-warning fs14" NavigateUrl="#"></asp:HyperLink>
                                    <br />
                                    <asp:HyperLink ID="lnkLivePost" runat="server" CssClass="text-warning fs14">See your post</asp:HyperLink>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-alert-center mt15">
                                    <span class="text-warning fs16 fw600">IMPORTANT!</span>
                                    <span class="text-dark fs14 fw400">In User Menu, you can mark it
                                         <span class="text-warning fs16 fw600">"SOLD"</span>
                                        after you sell it, or <span class="text-warning fs16 fw600">lower price</span> if it's not selling.</span><br />
                                    <asp:HiddenField ID="hdnEntryVal" runat="server" />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
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
            tab_hover_color: '#ff6600'
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
