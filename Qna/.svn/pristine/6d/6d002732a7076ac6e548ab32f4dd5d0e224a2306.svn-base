<%@ Page Language="c#" Codebehind="List.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Qna.List" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Surfboard Help - Q&A | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Get advice on surfboard sizes and design, surf etiquette & travel, and surfing maneuvers by asking others in the Boardhunt community." />
    <meta name="keywords" content="surfboard questions, used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs" />
    <!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />

    <script type="text/javascript">
    $(document).ready(function() {

    //TODO: tips
    
    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    $('img.Tips').cluetip({splitTitle: '|'});        
        
    });
    </script>

    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <link href="../style/tips.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        function SaveBG(val)
        {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            hdnCtl.value = val;
        }
         
        function GetBG()
        {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            return hdnCtl.value;
        }
        
        function SetHdnLocVal()
        {
            
            var hdnCtl;
            var hdnCtl2;
            hdnCtl = document.getElementById('hdnLocVal');
            hdnCtl2 = document.getElementById('cboLocation');
            hndCtl.value = hdnCtl2.value;
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

</head>
<body>
    <div id="main" align="center">
        <form id="Form1" method="post" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" id="container">
                <div id="wrapper" align="center">
                    <!--left column-->
                    <div id="left">
                        <br />
                        <br />
                        <asp:Panel runat="server" Width="140px" ID="pnlFilter" BorderStyle="solid" BorderColor="#669900"
                            BorderWidth="0">
                            <table border="0" bgcolor="#99CC33" bordercolor="#FF9900" width="140px" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td class="white20b" align="center" bgcolor="#669900" height="25px">
                                        Search</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="120" CssClass="dkgrey10b"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td height="10">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="center" valign="bottom">
                                        &nbsp;<asp:Button ID="btnSearch" OnClientClick="SetHdnLocVal()" Text="GO" runat="server"
                                            CssClass="dkgrey12b" Width="60px" OnClick="btnSearch_Click" /></td>
                                </tr>
                                <tr>
                                    <td height="5">
                                        &nbsp;</td>
                                </tr>
                            </table>
                           <table width="130px" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0">
                            
                            
                               <caption>
                                   &nbsp;
                                   <tr>
                                       <td align="center" bgcolor="#333333" class="white20b" colspan="3" height="25px">
                                           Board Matrix</td>
                                   </tr>
                               </caption>
                               </tr>
                            <tr>
                                <td colspan="3">&nbsp</td>
                            </tr>                            
                            <tr align="center">
                                <td colspan="3">
                                <a class="grey_ltgreen10" href="http://www.malzook.com/Matrix.aspx">
                                <img src="http://www.malzook.com/images/matrix_logo.gif" border="0" 
                                    alt="More help" class="Tips" title="Board Matrix | Get board suggestions based on your height, weight, and skill level." /></a>
                                    </td>
                             </tr>                                
                             <tr>
                                <td colspan="3">&nbsp</td>
                            </tr>  

                               <caption>
                                   &nbsp;
                                   <tr>
                                       <td align="center" bgcolor="#333333" class="white20b" colspan="3" height="25px">
                                           Shapers</td>
                                   </tr>
                               </caption>
                               </tr>
                            <tr>
                                <td colspan="3">&nbsp</td>
                            </tr>                            
                            <tr align="center">
                                <td colspan="3">
                                <a class="grey_ltgreen10" href="http://www.malzook.com/Shaper/ShaperHouse.aspx">
                                <img src="http://www.malzook.com/images/ShHomeIcon.gif" border="0" 
                                    alt="More help" class="Tips" title="ShaperHouse | View new models by shapers." /></a>
                                    </td>
                             </tr>    
                              <tr>
                                <td colspan="3">&nbsp</td>
                            </tr> 
                        </table>

                        </asp:Panel>
                        <br />
                        <div style="text-align: center;">
                          
                        <!-- Start: Ads -->
                        <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                            

                        </div>
                        <br />
                        <br />
                    </div>
                    <!--center column-->
                    <div id="center" class="white16">
                        <div class="white16" align="center">
                            <%--<span class="midgreen40b">Ask-a-Pro</span><span class="dkgrey16">&nbsp;&nbsp;</span>--%>
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            <%--<asp:HyperLink CssClass="HeaderLink" ID="HypLoc" runat="server" NavigateUrl="../index.aspx"></asp:HyperLink>&nbsp;>
                            <!-- <asp:HyperLink CssClass="HeaderLink" id="HypCat" runat="server" NavigateUrl="#" Enabled="false"></asp:HyperLink> -->
                            <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>--%>
                            <asp:Label CssClass="white" ID="lblCount" runat="server"></asp:Label>
                        </div>
                        <div class="midgrey12" align="center">
                            <table>
                                <tr>
                                    <td class="ltgreen14">
                                        <a class="green_orange14" href="../Login.aspx">Login</a> to give or get advice.
                                    </td>
                                    <%--<td>
                                        <a href="javascript:void(window.open('http://www.twitter.com/boardhunt'))">
                                            <img src="http://www.malzook.com/images/badge_twit.png" border="0" alt="twitter" style="width: 20px" /></a>
                                        <a href="javascript:void(window.open('http://www.facebook.com/boardhunt'))">
                                            <img src="http://www.malzook.com/images/badge_fb.png" border="0" alt="facebook" /></a>
                                        <a href="javascript:void(window.open('http://www.stumbleupon.com/submit?url=http%3A//www.boardhunt.com&title=Surfboard+Questions'))">
                                            <img src="http://www.malzook.com/images/badge_su.gif" border="0" alt="stumbleupon" /></a>
                                        <a href="javascript:void(window.open('http://del.icio.us/post?url=http://www.malzook.com&title=Surfboard+Questions'))">
                                            <img src="http://www.malzook.com/images/badge_delic.png" border="0" alt="delicious" /></a>
                                    </td>--%>
                                    <img src="../images/AskaProBanner.gif" border="0" alt="Ask Surfboard questions" />
                                </tr>
                            </table>
                            <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
                        <div align="center">
                            <br />
                            <table width="560">
                                <asp:DataList Width="560" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid"
                                    BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="5" style="height: 25px">
                                                <div style="border: solid 0px green">
                                                    <table>
                                                        <!--Answer Count-->
                                                        <td class="white12b" style="width: 50px; background-color: #99CC33" align="center"
                                                            valign="middle">
                                                            <asp:LinkButton CssClass="whiteblack12" ID="lnkAnswerCount" runat="server" OnCommand="GetValues"
                                                                CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>
										    <%# DataBinder.Eval(Container.DataItem, "COUNTER")%><br />
								            &nbsp;Answers&nbsp;
                                                </asp:LinkButton>
                                                        </td>
                                                        <!--Question-->
                                                        <td bgcolor="F0F0F0" class="dkgreen12b" nowrap>
                                                            &nbsp;
                                                            <asp:LinkButton CssClass="midgrey_dkgrey18" ID="LinkButton2" runat="server" OnCommand="GetValues"
                                                                CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>
										        <%# FormatDetails(DataBinder.Eval(Container.DataItem, "Question"))%>
                                                </asp:LinkButton>&nbsp;&nbsp;
                                                        </td>
                                                        <td class="ltgreen10b" align="center" style="background-color: #ffffff" nowrap>
                                                            <a href='http://www.malzook.com/Qna/QDetails.aspx?q=<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>
                                                                <span class="ltgreen10b">
                                                                    <%# DataBinder.Eval(Container.DataItem, "iViews")%>
                                                                    &nbsp;<br />
                                                                    &nbsp;Views&nbsp;</span></a>
                                                        </td>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:DataList></table>
                            <table border="0">
                                <tr>
                                    <td height="20">
                                        <img src="../images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                            runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                                        <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                        <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
                                        &nbsp;
                                        <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                            runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                            <asp:HiddenField ID="hdnLocVal" Value="-1" runat="server" />
                            <!-- #include file="../include/ads/tileAd.htm" -->
                        </div>
                        <br>
                        <img src="../images/s1x1.gif" height="5">
                    </div>
                    <!-- end center div -->
                    <!-- right column-->
                    &nbsp;<div id="right">
                        <br />
                      <bh:ShowBoost ID="boost1" runat="server">
                        </bh:ShowBoost>
                        
                        <!-- Start: Ads -->
                        <!-- #include file="../include/ads/SkyScraperAd.htm" -->                    
                    </div>

                    <!-- end right column -->
                </div>
            </div>
    <div align="center">
        <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label></div>
    <div align="center">
        <div id="push">
        </div>
        </form>
    </div>
        <br />
        <div align="center" id="footer">
            <!-- #include file="../include/footer.aspx" -->
        </div>
    

    <script type="text/javascript" src="../include/js/googles.js"></script>
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
</body>
</html>
