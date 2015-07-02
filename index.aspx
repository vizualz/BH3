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
    <script type="text/javascript">
        var dest = location.search.replace(/^.*?\=/, '');
        if (dest.length > 0) {
            if (dest != "1") {
                (function (a, b) {
                    if (/android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|meego.+mobile|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) window.location = b
                })(navigator.userAgent || navigator.vendor || window.opera, 'http://' + document.domain + '/m/index.aspx');
            }
        }
        else {
            (function (a, b) {
                if (/android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|meego.+mobile|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) window.location = b
            })(navigator.userAgent || navigator.vendor || window.opera, 'http://' + document.domain + '/m/index.aspx');
        }
    </script>
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt Surfboards For Sale"
        href="http://www.malzook.com/rss/surfboards.xml" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="favicon.ico" />
    <meta http-equiv="Page-Enter" content="RevealTrans(Duration=0,Transition=0)" />
    <meta name="description" content="Find new and used surfboards for sale by others in the surfing community.  Find surfboard shapers and get surfboard advice." />
    <meta name="keywords" content="surfboards, used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboard blogs, surfing blogs, surfboard advice" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="verify-v1" content="eWL9d2V/s6d8s6toO33avZ2ySyY72DQg3ZG16K/qM6w=" />
    <meta http-equiv="X-UA-Compatible" content="IE=9"/>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="include/js/superfish.js"></script>
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
    <!-- Google ads: Leader -->
    <script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
    </script>
    <script type='text/javascript'>
        GS_googleAddAdSenseService("ca-pub-0007702553564747");
        GS_googleEnableAllServices();
    </script>
    <script type='text/javascript'>
        GA_googleAddSlot("ca-pub-0007702553564747", "Leader");
    </script>
    <script type='text/javascript'>
        GA_googleFetchAds();
    </script>
    <%--<meta property="og:site_name" content="Boardhunt|  Used Surfboards for Sale" />
    <meta property="og:description" content="Find new and used surfboards for sale by others in the surfing community." />
    <meta property="og:type" content="company" />
    <meta property="og:url" content="http://www.malzook.com/" />
    <meta property="og:image" content="http://www.malzook.com/images/BHLogo.gif" />
    <meta property="og:email" content="info@boardhunt.com" />
    <meta property="fb:app_id" content="143749072318586" />--%>
</head>
<body style="background-color: #FFFFFF; background-image: url('used-surfboards.jpg')">
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
    <div id="main" align="center" style="margin-bottom: 100px; width: 100%;">
        <!-- #include file="include/HeaderIdx.aspx" -->
        <div align="center">
            <!-- top half -->
            <div style="background-color: #FFFFFF; background-image: url(../images/HomepageHarlan.jpg);
                background-repeat: no-repeat; height: 400px; width: 1024px; align: center; cellpadding: 0px;
                cellspacing: 0px; border: solid 0px Black;">
                <div align="left"> 
                <div style="margin-left: 20px; margin-top: 20px; margin-bottom: 50px"><br />
                    <span class="black40b">Used Surfboards for Sale</span><br />
                    <span class="white20g">Connecting surfers with surfboards, beyond classifieds.</span><br /><br />
                        <br />
                    
                    <asp:Button ID="btnSearchSurfboard" OnCommand="ImageButton_Click" CssClass="btnBigOrg" style="padding:10px" 
                        CommandName="btnSearch" runat="server" ToolTip="Search for your next board" 
                        Text="Find Surfboards" onclick="btnSearchSurfboard_Click" />
                    <asp:Button ID="btnSellSurfboard" OnCommand="ImageButton_Click" CssClass="btnBigGreen" style="padding:10px" 
                        CommandName="btnSell" runat="server" ToolTip="Sell your board now" 
                        Text="Sell Surfboards" onclick="btnSellSurfboard_Click" />
                        <br />
                        

               </div>
             </div>
             </div>
                        <div style="margin-top:5px; margin-bottom:0px; height:200px; width: 1024px;  border: solid 0px Black">
                        <br />
                        <div align="left" class="black16b" style="margin-top:0px; margin-bottom:5px; margin-left:0px; float:left; width:250px;">
                                    <a align="left" class="orange_dkorange16" href="Surfboardsforsale.aspx">Easier</a><br />
                                    Accurate categorization and <br/>less clicks to hunt.
                                    </div>
	                    <div align="left" class="black16b" bgcolor="222222" style="margin-top:0px; margin-bottom:0px; margin-left:35px; float:left; width:250px;">
	                                    <a align="left" class="orange_dkorange16" href="Surfboardsforsale.aspx">Quality</a><br />
	                                    We remove the junk.<br/></div>
	                    <div align="left" class="black16b" bgcolor="222222" style="margin-top:0px; margin-bottom:0px; margin-left:0px; float:left; width:250px;">
	                                    <a align="left" class="orange_dkorange16" href="register_user.aspx">Safe Community</a><br />
	                                    No creeps, just surfers.<br/> </div>
	                    <div align="left" class="black16b" bgcolor="222222" style="margin-top:0px; margin-left:20px; margin-bottom:0px; float:left; width:200px;">
	                                    <a align="left" class="orange_dkorange16" href="register_user.aspx">Insight</a><br />
	                                     Get guidance with Matrix and ShaperHouse.<br/></div>        
                 	</div>

             </div>
			</div>

    </form>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-2548219-1");
        pageTracker._initData();
        pageTracker._trackPageview();
    </script>
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>
   
</body>
</html>
