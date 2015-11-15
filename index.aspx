 <%@ Page Language="c#" CodeBehind="index.aspx.cs" AutoEventWireup="false" EnableEventValidation="false"
    EnableViewStateMac="false" ViewStateEncryptionMode="Never" Inherits="BoardHunt.index" %>
<%@ Register TagPrefix="bh" TagName="lQuestions" Src="include/Controls/LQuestions.ascx" %>
<%@ Register TagPrefix="bh" TagName="lBlog" Src="include/Controls/LBlogs.ascx" %>
<%@ Register TagPrefix="bh" TagName="lComment" Src="include/Controls/LComment.ascx" %>
<%@ Register TagPrefix="bh" TagName="lboards" Src="include/Controls/LBoards.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://opengraphprotocol.org/schema/"
xmlns:fb="http://www.facebook.com/2008/fbml">
<head>
    <title>Used Surfboards for Sale | Boardhunt</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt Surfboards For Sale"
        href="http://www.boardhunt.com/rss/surfboards.xml" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="favicon.ico" />
    <meta http-equiv="Page-Enter" content="RevealTrans(Duration=0,Transition=0)" />
    <meta name="description" content="Find new and used surfboards for sale by others in the surfing community.  Find surfboard shapers and get surfboard advice." />
    <meta name="keywords" content="surfboards, used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboard blogs, surfing blogs, surfboard advice" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="verify-v1" content="eWL9d2V/s6d8s6toO33avZ2ySyY72DQg3ZG16K/qM6w=" />
    <meta http-equiv="X-UA-Compatible" content="IE=9"/>
    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript" src="include/js/superfish.js"></script>

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
    </script>
    <script type="text/javascript" language="JavaScript">
        function CheckForEnter(code) {
            if (code == 13) {
                __doPostBack('ImageButton1', '');
            }
        }
    </script>

</head>
<body style="background: none repeat scroll 0 0 #fff;" >
    <div id="fb-root">
    </div>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({ appId: '143749072318586', status: true, cookie: true,
                xfbml: true
            });
        };
        (function () {
            var e = document.createElement('script');
            e.type = 'text/javascript';
            e.src = document.location.protocol +
          '//connect.facebook.net/en_US/all.js';
            e.async = true;
            document.getElementById('fb-root').appendChild(e);
        } ());
    </script>
    <form class="header" id="Form1" runat="server">
    	<div class="container-fluid">
        <!-- #include file="include/HeaderIdx.aspx" -->
        
	        <!-- top half -->
	        <div align="center">
	        	<img class="img-responsive" src="../images/HomepageHarlan.jpg" height="50%" width="100%" alt="Used Surfboards - Boardhunt">
	        </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <H1>Used Surfboards for Sale - Premium Online Marketplace</H1>
                    <P>Custom Built for Surfers Since 2006.</P>
                </div>    

            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

	                <div class="col-lg-6 col-md-6col-sm-6 col-xs-6">
	                    <asp:Button ID="btnSearchSurfboard" OnCommand="ImageButton_Click" CssClass="btnBigOrg" style="padding:10px" 
	                        CommandName="btnSearch" runat="server" ToolTip="Search for your next board" 
	                        Text="Find Surfboards" onclick="btnSearchSurfboard_Click" />
					</div>
					<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
	                    <asp:Button ID="btnSellSurfboard" OnCommand="ImageButton_Click" CssClass="btnBigGreen" style="padding:10px" 
	                        CommandName="btnSell" runat="server" ToolTip="Sell your board now" 
	                        Text="Sell Surfboards" onclick="btnSellSurfboard_Click" />
					</div>
                </div>

            </div>    
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>&nbsp;&nbsp;
                    <asp:Button ID="btnLogin" OnCommand="ImageButton_Click" CssClass="button btn-primary" style="border:0"
                        CommandName="btnSell" runat="server" 
                        Text="Log in" onclick="btnLogin_Click" /> 
                </div>                 
       		</div>	

                <br>
                <P>&nbsp;&nbsp;Free | Easier | Quality | Secure | Accurate</P>
            </div>
  		</div>
    </form>

       <br />
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
    </script>

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
