<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShaperHouseBeta.aspx.cs" Inherits="BoardHunt.Shaper.ShaperHouseBeta" %>


<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Surfboard For Sale | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Surfboards and other gear for sale, posted by surfers in the Boardhunt community."/>
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
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
                <span class="midorange14"><span class="midgrey12">Build Your ShaperHouse</span>
                </span></span>
            <div align="center">
                <div align="center" id="container" style="width: 1000px">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <div id="left">
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%--BOOST HERE--%>
                            <bh:ShowBoost ID="boost1" runat="server"></bh:ShowBoost>
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center">
                           <asp:Panel ID="pnlDetails" runat="server" Style="width: 710px;" BorderColor="#FF9900" BorderStyle="solid" BorderWidth="0px">
                            <div style="width:400px" class="white30" align="left"><br />
                                
                            <img src="../images/shaperhousemore.gif" alt="ShaperHouse"/>
                            <!--
                            <span class="white12">You, the craftsmen, build the boards, and we build tools that help sell them.&nbsp; Why exhaust your advertising budget on pricy search optimization or online ads when we deliver to a board hungry market that's ready to buy?&nbsp;</span><br />
                            -->
                            <span class="white12">ShaperHouse is a groovy platform that lets surfboard shapers connect with their passionate board-riding audience.&nbsp&nbsp;Once signed up, shapers can build and display their fine craftsmanship for the entire community to see.  They will gain high visibility and can help prospective board riders find their perfect board.</span><br />
                            
                            <br />
                            
                            <span class="midorange16b">ShaperHouse includes:</span><br />
                            <span class="ltgrey12">- A single page view of all your models</span><br />
                            <span class="ltgrey12">- A detailed profie view for each model</span><br />
                            <span class="ltgrey12">- Your contact info and bio</span><br />
                            <span class="ltgrey12">- Link to your 'used boards for sale'</span><br />
                            <span class="ltgrey12">- Link to your website</span><br /><br />
                         
                            <span class="white16b">ShaperHouse is coming soon!</span><br /><br />
                            <span class="white16b">If you're a shaper and interested in the ShaperHouse Beta Program,  <a class="orange_dkorange16" href="../contact.aspx?iD=0">contact us</a> today.</span>
                            
                            <asp:Panel ID="pnlLoggedIn" runat="server" Visible="false">
                            <br />
                            <asp:ImageButton runat="server" ID="imgBtnBuy" ImageUrl="../images/buy2.gif" OnClick="imgBtnBuy_Click" /><br />
                            <span class="midgrey12">
                            <br />
                            Click on the buy button to purchase.  Once completed you can start building!
                            </span>
                            </asp:Panel>
                            <asp:Panel ID="pnlLoggedOut" runat="server" Visible="false">
                            <span class="midorange16b">You'll need to <a class="ltgreen_orange16" href="../login.aspx">Login</a> or <a class="ltgreen_orange16" href="../register_user.aspx">Sign up</a> first.</span>
                            <br />
                            <span class="midorange16b">Register as a business by choosing 'YES' in the form.<br />
                            Once you've registered and signed in, click the ShaperHouse <img src="../images/buy2.gif" border="0"/> button from the main menu.</span>
                            </asp:Panel>
                            
<%--                            
                                if you haven't, or [buy now]</span><br />
                            <span class="midgrey12">(In Account Settings: 'Yes' must be selected for business to purchase a subscription)</span><br /><br />
                            <span class="white16b">OR</span><br /><br />
                            <span class="midorange16b"><a class="orange_dkorange16" href="../register_user.aspx">Sign up</a> to get a boardhunt login.</span><br />
                            <span class="dkgrey12">(Make sure 'YES' is selected for business)<br />
                                &nbsp;then click on 'Buy' button.</span>--%>
                                
                            </div>
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

