<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShaperVideos.aspx.cs" Inherits="BoardHunt.Shaper.ShaperVideos" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Surfboard Shaper Videos | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Surfboards and other gear for sale, posted by surfers in the Boardhunt community." />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    });
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


<!-- Google ads: Wide Skyscraper -->

<script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
</script>
<script type='text/javascript'>
    GS_googleAddAdSenseService("ca-pub-0007702553564747");
    GS_googleEnableAllServices();
</script>
<script type='text/javascript'>
    GA_googleAddSlot("ca-pub-0007702553564747", "Wide_Skyscraper");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>

<!-- Google ads: Box -->

<script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
</script>
<script type='text/javascript'>
    GS_googleAddAdSenseService("ca-pub-0007702553564747");
    GS_googleEnableAllServices();
</script>
<script type='text/javascript'>
    GA_googleAddSlot("ca-pub-0007702553564747", "Box");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>


</head>
<body bgcolor="#222222" onload="PreLoadImgs();GetRating();">
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <%--PAGE NAV--%>
            <asp:HyperLink CssClass="orange_grey12u" ID="HypLoc" runat="server" NavigateUrl="../index.aspx"></asp:HyperLink>
            <span class="midorange14">
                <asp:HyperLink CssClass="orange_grey12u" ID="HypCat" runat="server" NavigateUrl="#"
                    OnClick="javascript:history.go(-1); return false;">
                </asp:HyperLink>
                
            </span>
            <div align="center">
                <div align="center" id="container" style="width: 1000px">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <div id="left"><br /><br /><br /><br />
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right"><br /><br /><br /><br />
                            <%--BOOST HERE--%>
                            <bh:ShowBoost ID="boost1" runat="server">
                            </bh:ShowBoost>
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center">
                            <asp:Panel ID="pnlDetails" runat="server" Style="width: 700px;" BorderColor="#FF9900" BorderStyle="solid" BorderWidth="0px">
                                
                                <div id="Div1" width="670" class="midorange40" align="center">ShaperHouse TV<br />
                                <span class="white12"> Learn about surfboard designs. | </span> <a class="white_orange12u" align="left" href="./ShaperHouse.aspx">Back to ShaperHouse</a><br /><object type="application/x-shockwave-flash" width="650" height="350" 
                                    data="http://vimeo.com/hubnut/?user_id=user5277432&amp;color=ffffff&amp;background=333333&amp;fullscreen=1&amp;slideshow=1&amp;stream=channel&amp;id=150021&amp;server=vimeo.com"><param name="quality" value="best" />		
                                    <param name="allowfullscreen" value="true" />		
                                    <param name="allowscriptaccess" value="always" />	
                                    <param name="scale" value="showAll" />	
                                    <param name="movie" value="http://vimeo.com/hubnut/?user_id=user5277432&amp;color=ffffff&amp;background=333333&amp;fullscreen=1&amp;slideshow=1&amp;stream=channel&amp;id=150021&amp;server=vimeo.com" /></object></div>
                                    
                            
                            </asp:Panel>
                            
                            <%--TILEAD & FOOTER--%>
                            <div align="center">
                                <br />
                                <br />
                                <br />
                                <!-- #include file="../include/ads/tileAd.htm" -->
                            </div>
                        </div>
                        <%--WRAPPER--%>
                    </div>
                    <%--CONTAINER--%>
                </div>
            </div>
            <div id="push">
            </div>
        </form>
    </div>
    <%--MAIN--%>
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <%--Google analytics--%>

    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
