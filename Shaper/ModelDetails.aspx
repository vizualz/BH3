<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ModelDetails.aspx.cs" Inherits="BoardHunt.Shaper.ModelDetails" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<%@ Register TagPrefix="bh" TagName="ctlShapers" Src="../include/Controls/Shapers.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Surfboards | Boardhunt</title>
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
        
    $('#toggle2').hover(
          function () {
              $('#pnlLogin').slideToggle('slow', function() {
                // Animation complete.
              });
          }, 
          function () {
              //$('#pnlLogin').slideToggle('slow', function() {
                // Animation complete.
              //});                
          }
        );
     $('#pnlLogin').hide();          
    });
    </script>

    <script type="text/javascript">
        function PreLoadImgs()
        {
            var i;
            var imgArray = new Array();
            
            for (i=0;i<=3;i++)
            {
                imgArray[i] = "hdnPicVal" + (i+1);
                
                var ctl = document.getElementById("hdnPic" + (i+1) + "URL");
                
                if (ctl.value != "")
                {
                imgArray[i] = new Image(400,400);
                imgArray[i].src = ctl.value;
                }
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


    <meta property="og:site_name" content="Surfboard Models|Boardhunt" />
    <meta property="fb:app_id" content="143749072318586" />


</head>
<body bgcolor="#222222" onload="PreLoadImgs();">
    <div id="fb-root">
    </div>

    <script>
      window.fbAsyncInit = function() {
        FB.init({appId: '143749072318586', status: true, cookie: true,
                 xfbml: true});
      };
      (function() {
        var e = document.createElement('script');
        e.type = 'text/javascript';
        e.src = document.location.protocol +
          '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
      }());
    </script>

    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <%--PAGE NAV--%>
            <div align="center">
                <div id="pageNav" align="left" style="width: 610px; margin-top: 50px; border: solid 0px red">
                    <asp:HyperLink CssClass="grey_orange14" ID="HypNavPrim" runat="server" NavigateUrl="ShaperHouse.aspx"></asp:HyperLink>
                    <span class="midorange14">&nbsp;>&nbsp;
                        <asp:HyperLink CssClass="grey_orange14" ID="HypNavSec" runat="server" NavigateUrl="#">
                        </asp:HyperLink>
                        <span class="midorange14">&nbsp;>&nbsp;<span class="midgrey14">Model</span> </span>
                    </span>
                </div>
            </div>
            <div align="center">
                <div align="center" id="container" style="width: 1100px">
                    <div id="wrapper" align="center" style="width: 1090px">
                        <%--LEFT COLUMN--%>
                        <div id="left" style="width: 170px;">
                            <div style="width: 170px; margin-top:0px; border: solid 0px green">
                                <bh:ctlShapers id="ShapersAll" runat="server">
                                </bh:ctlShapers>
                            </div>
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%--BOOST HERE--%>
                            <bh:ShowBoost ID="boost1" runat="server">
                            </bh:ShowBoost><br /> 
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center">
                            <asp:Panel ID="pnlDetails" runat="server" Style="width: 700px;" BorderColor="#FF9900"
                                BorderStyle="solid" BorderWidth="0px">
                                <!-- Master Table -->
                                <table cellspacing="0" align="center" width="700px" cellpadding="0" border="0" bgcolor="#222222"
                                    bordercolor="#999966">
                                    <tr>
                                        <td>
                                            <!-- left side -->
                                            <table border="0" bgcolor="#222222" cellpadding="0" cellspacing="0">
                                                <caption>
                                                    <br />
                                                    <asp:Panel ID="pnlModel" runat="server">
                                                        <tr>
                                                            <td align="left" class="white40" valign="bottom">
                                                                &nbsp;&nbsp;<asp:Label ID="lblModelData" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <tr>
                                                        <td height="30">
                                                            <img src="../images/s1x1.gif"></img></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            &nbsp;&nbsp;<asp:Image ID="Pic1" runat="server" />
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="" height="1">
                                                            <img src="../images/s1x1.gif"></img></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <asp:Image ID="Pic1ThmbNail" runat="server" BorderWidth="0" 
                                                                CssClass="highlightit" onmouseover="ImgHover('1')" Visible="false" />
                                                            &nbsp;
                                                            <asp:Image ID="Pic2ThmbNail" runat="server" BorderWidth="0" 
                                                                CssClass="highlightit" onmouseover="ImgHover('2')" Visible="false" />
                                                            &nbsp;
                                                            <asp:Image ID="Pic3ThmbNail" runat="server" BorderWidth="0" 
                                                                CssClass="highlightit" onmouseover="ImgHover('3')" Visible="false" />
                                                            &nbsp;
                                                            <asp:Image ID="Pic4ThmbNail" runat="server" BorderWidth="0" 
                                                                CssClass="highlightit" onmouseover="ImgHover('4')" Visible="false" />
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#222222" colspan="2" style="height: 10px">
                                                            <img src="../images/s1x1.gif"></img></td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#222222" colspan="2" style="height: 5px">
                                                            <img src="../images/s1x1.gif"></img></td>
                                                    </tr>
                                                </caption>
                                            </table>
                                        </td>
                                        <!-- end left side -->
                                        <td>
                                            &nbsp;</td>
                                        <!-- begin right side -->
                                        <td valign="top">
                                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="FFFFFF">
                                                <tr>
                                                    <td bgcolor="#222222" height="100" colspan="3">
                                                        <img src="../images/s1x1.gif"></td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="#222222" bordercolor="#222222">
                                                <asp:Panel runat="server" ID="pnlBoardType">
                                                    <tr>
                                                        <td style="height: 20px; width: 40%;"class="dkgrey14" align="left">
                                                            <asp:Label ID="lblBoardType" runat="server" nowrap></asp:Label></td>
                                                        <td class="white14" align="left" valign="bottom">
                                                            <asp:Label ID="lblBoardTypeData" runat="server">
                                                            </asp:Label></td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlGenDims" Visible="false" runat="server">
                                                    <tr>
                                                        <td height="18px" class="dkgrey14" align="left">
                                                            Dims:&nbsp;</td>
                                                        <td class="white14" align="left" valign="bottom">
                                                            <asp:Label ID="lblGenDims" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dkgrey14" align="left" valign="bottom">
                                                            Price:&nbsp;</td>
                                                        <td class="white14" align="left" valign="bottom">
                                                            <asp:Label ID="lblPriceData" CssClass="white14" runat="server">
                                                            </asp:Label></td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td colspan="2" height="8">
                                                        <img src="../images/s1x1.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ImageButton ID="imgBuy" runat="server" ImageUrl="../images/Voucher_buy_badge.gif" />
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlShip" runat="server" Visible="true">
                                                    <tr>
                                                        <td colspan="2" class="midgrey14" align="left" bgcolor="#222222" valign="bottom">
                                                            Shipping Available:&nbsp;<asp:Label ID="lblShip" CssClass="midgrey14" runat="server">No</asp:Label>
                                                            <hr style="background-color: #FFFFFF; height: 2px" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td bgcolor="#222222" height="10px" colspan="2">
                                                        <img src="../images/s1x1.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td class="white14b" colspan="2" align="left">
                                                        Contact Shaper
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dkgrey14" align="left">
                                                        <%--<img src="/images/smcell.gif" alt="cellphone" align="middle">--%>
                                                        #:&nbsp;<asp:Label ID="lblPhoneData" runat="server" CssClass="white14" Width="150px">
                                                        </asp:Label>
                                                        <br />
                                                        <%--<img src="/images/email.gif" alt="email" align="middle">--%>
                                                        <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="orange_grey12u">
                                                        </asp:LinkButton>&nbsp;
                                                    </td>
                                                    <td style="width: 5px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#222222" style="height: 10px">
                                                        <img src="../images/s1x1.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td height="20px" class="dkgrey14" align="left" valign="bottom">
                                                        Shaper Says:&nbsp;</td>
                                                    <td style="width: 5px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="white12" align="left" colspan="2" Width="220" valign="bottom">
                                                        <asp:Label ID="lblDetailsData" runat="server" Width="220"></asp:Label></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#222222" style="height: 5px">
                                                        <img src="../images/s1x1.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td class="controls3" align="left" colspan="2" bgcolor="#222222">
                                                        <asp:LinkButton ID="btnMore" CssClass="orange_grey12u" runat="server" Text="Shaper's used boards for sale"
                                                            OnClick="btnMore_Click" /></td>
                                                    
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header" colspan="3">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                                <!-- end master table -->
                            </asp:Panel>
                            <asp:Panel ID="pnlVideo" runat="server" Visible="false">
                                <asp:Label ID="lblVideo" runat="server"></asp:Label>
                            </asp:Panel>
                            <%--RATINGS--%>
                            <div align="center" style="width: 710px; margin: 0 auto; border: solid 0 #F0F0F0">
                                <asp:Panel ID="pnlRatings" runat="server" HorizontalAlign="Center">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="700px" style="background-color: #222222;
                                        vertical-align: middle">
                                        <tr>
                                            <td vertical-align="middle" align="left">
                                                &nbsp;&nbsp;
                                                <asp:ImageButton align="absmiddle" ID="imgGoBack" ToolTip="Back to ShaperHouse" runat="server"
                                                    ImageUrl="../images/id_back.gif"></asp:ImageButton>&nbsp;<span class="midorange14">Back</span></td>
                                            <td class="dkgrey10" align="right" valign="bottom" style="height: 20px">
                                                <%--Posted:&nbsp;--%>
                                                <asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 320px" valign="middle" class="dkgrey14" align="left">
                                                &nbsp;&nbsp;
                                                <%--<asp:Label CssClass="dkgrey14" ID="lblPageViewCount" runat="server"></asp:Label>
                                                                &nbsp;--%>
                                                <%--TODO: ADD FB Likes--%>
                                                <%--<asp:Label CssClass="dkgrey12" ID="lblRatingCount" runat="server"></asp:Label>--%>
                                                <div style="padding-top: 2px; width: 300px; border: solid 0px #333333;
                                                    float: left; background-color: #222222" align="left" valign="middle">
                                                    <div style="float: left; valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="lblFB" runat="server" Width="300" BorderWidth="0"></asp:Label>
                                                    </div>
                                                    
                                                </div>
                                            </td>
                                            <td class="dkgrey14" align="right" valign="middle">
                                                <%--Favs:&nbsp;--%>
                                                <asp:ImageButton Visible="false" ID="imgAddFav" runat="server" ImageUrl="../images/favorites.gif"
                                                    ToolTip="Add to My Favorites!"></asp:ImageButton>
                                                &nbsp;&nbsp;&nbsp;
                                                 <!-- AddThis Button BEGIN -->
                                                <div style="float: left; height: 50px; width:250px"; class="addthis_toolbox addthis_default_style addthis_32x32_style" vertical-align="middle">
                                                    <a class="addthis_button_preferred_1"></a>
                                                    <a class="addthis_button_preferred_2"></a>
                                                    <a class="addthis_button_preferred_3"></a>
                                                    <a class="addthis_button_compact"></a>
                                                </div>
                                        <script type="text/javascript">                                            var addthis_config = { "data_track_clickback": true };</script>
                                        <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4df1178f225b17c1"></script>
                                    <!-- AddThis Button END -->
                                            
                                            <div style="float: right;">
                                                        <asp:Label ID="lblViews" runat="server" CssClass="midorange14" BorderWidth="0">&nbsp;</asp:Label>&nbsp;
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <br />
                            <%--BEGIN COMMENTS--%>
                            <div style="background-color: white; width: 705px">
                                <!-- #include file="../include/Comments.aspx" -->
                            </div>
                        </div>
                        
                        <%--TILEAD--%>
                        <div style="margin-top:20px" align="center">
                            <br /><br />
                            <!-- #include file="../include/ads/tileAd.htm" -->
                        </div>

                        <%--WRAPPER--%>
                    </div>
                    <%--CONTAINER--%>
                </div>
                <br />
                <br />
                <br />
                <!-- include file="../include/ads/tileAd.htm" -->
<%--                <div align="center" style="width:302px;height:252px">
                                        <script type="text/javascript"><!--
                adroll_width = 300;
                adroll_height = 250;
                adroll_a_id = "GX2WB4UKAJCUZGLQ4VPCPR";
                adroll_s_id = "6HRX4NZQLJAHJNQCOYZCFA";
                adroll_render_link = false;
                //--></script>
                        <script type="text/javascript" src="http://c.adroll.com/j/rolling.js"></script>
                </div>--%>
                
                <br />
            </div>
            <asp:Image ID="Pic2" runat="server" Visible="false"></asp:Image>
            <asp:Image ID="Pic3" runat="server" Visible="false"></asp:Image>
            <asp:Image ID="Pic4" runat="server" Visible="false"></asp:Image>
            <asp:HiddenField ID="hdnPic1URL" runat="server" />
            <asp:HiddenField ID="hdnPic2URL" runat="server" />
            <asp:HiddenField ID="hdnPic3URL" runat="server" />
            <asp:HiddenField ID="hdnPic4URL" runat="server" />
            <asp:HiddenField ID="hdnEId" runat="server" />
            <asp:HiddenField ID="hdnStrCat" runat="server" />
            <asp:HiddenField ID="hdniCat" runat="server" />
            <asp:HiddenField ID="hdnNotifyEmail" runat="server" />
            <asp:HiddenField ID="hdnUserId" runat="server" />
            <asp:HiddenField ID="hdnRatingVal" runat="server" />
            <asp:HiddenField ID="hdnRatingCnt" runat="server" />
            <asp:HiddenField ID="hdnBuyURL" runat="server" />
            <div id="push">
            
            </div>
        </form>
    </div>
    <br /><br />
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>

    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
