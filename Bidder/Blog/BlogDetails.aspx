<%@ Page Codebehind="BlogDetails.aspx.cs" Language="c#" AutoEventWireup="false" MaintainScrollPositionOnPostback="true"
    Inherits="BoardHunt.Blog.BlogDetails" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Surfboard Blog - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
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
                  });
              }, 
              function () {
                   
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
            
            for (i=0;i<=1;i++)
            {
                imgArray[i] = "hdnPicVal" + (i+1);
                
                var ctl = document.getElementById("hdnPic" + (i+1) + "URL");
                
                if (ctl.value != "")
                {
                imgArray[i] = new Image(300,300);
                imgArray[i].src = ctl.value;
                 }
            }
        }
    </script>

</head>
<body onload="PreLoadImgs();GetRating();">
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <%--PAGE NAV--%>
            <div align="center" style="height:40px; width:200px">
            <asp:HyperLink CssClass="orange_grey12u" Height="50px" ID="HypLoc" Width="200px" runat="server" NavigateUrl="BlogResults.aspx">All Blogs</asp:HyperLink>
            </div>
           
            <div align="center">
                <div align="center" id="container" style="width: 1000px">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <div id="left">
                            <br />
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <br />
                            <%--BOOST HERE--%>
                            <bh:ShowBoost ID="boost1" runat="server">
                            </bh:ShowBoost>
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center" style="width: 710px;">
                            <asp:Panel ID="pnlDetails" runat="server" BackColor="#FFFFFF" BorderColor="#CCCCCC"
                                BorderStyle="solid" Style="width: 670px; margin: 0 auto;" BorderWidth="0px">
                                <div align="center" style="width: 650px; height:350px; padding: 0px 0px 0px 0px">
                                    <br />
                                    <asp:Image ID="Pic1" ImageUrl="../images/s1x1.gif" runat="server" ImageAlign="Left" hspace="10" vspace="0" Style="padding: 0 10px 0 0">
                                    </asp:Image>
                                    <br />
                                    <asp:Label ID="lblAdTitle" CssClass="midorange30b" runat="server"></asp:Label>&nbsp;
                                    <br />
                                    <span class="midgrey10">Posted:</span>
                                    <asp:Label ID="lblDateData" CssClass="midgrey10" runat="server"></asp:Label>&nbsp;
                                    <br />
                                    <br />
                                    <div style="text-align: left">
                                        &nbsp;&nbsp;<asp:Label ID="lblDetailsData" CssClass="dkgrey12" runat="server"></asp:Label>
                                    </div>
                                    &nbsp;&nbsp;<asp:Image ID="Pic2" CssClass="highlightit" runat="server" Visible="false" />&nbsp;
                                </div>
                                <div style="text-align: center; width:650px;">
                                    <div style="float: left">
                                        &nbsp;
                                        <asp:ImageButton ID="imgGoBack" ToolTip="Go back" runat="server" ImageUrl="../images/id_back.gif">
                                        </asp:ImageButton>
                                        <span class="dkgrey14b">Back</span>
                                    </div>
                                    <div align="right" style="">
                                        <a class="orange_ltgreen10u" href="javascript:navTo('.com/contact.aspx?iD=6');">Request
                                            a topic</a>&nbsp;&nbsp;</div>
                                </div>
                            </asp:Panel>
                            <%--VIDEO--%>
                            <asp:Panel HorizontalAlign="Center" ID="pnlVideo" runat="server" Visible="false">
                                <asp:Label ID="lblVideo" runat="server">video</asp:Label>
                            </asp:Panel>
                            <%--RATINGS--%>
                            <div align="center" style="width: 670px; margin: 0 auto; background-color: #F0F0F0;
                                border: solid 1 #F0F0F0; height:40px">
                                <asp:Panel ID="pnlRatings" runat="server" HorizontalAlign="Center">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td valign="middle" class="dkgrey14b" align="left" width="290px">
                                                &nbsp;&nbsp;Rate it:&nbsp;&nbsp;
                                                <asp:ImageButton runat="server" ID="star1" ImageUrl="../images/target_white.gif"
                                                    onmouseout="GetRating()" onmouseover="ProcHover('1')" OnCommand="ProcRating"
                                                    CommandArgument="1" ToolTip="Ugly" align="middle" Style="padding-bottom: 8px" />
                                                <asp:ImageButton runat="server" ID="star2" ImageUrl="../images/target_white.gif"
                                                    onmouseout="GetRating()" onmouseover="ProcHover('2')" OnCommand="ProcRating"
                                                    CommandArgument="2" ToolTip="Bad" align="middle" Style="padding-bottom: 8px" />
                                                <asp:ImageButton runat="server" ID="star3" ImageUrl="../images/target_white.gif"
                                                    onmouseout="GetRating()" onmouseover="ProcHover('3')" OnCommand="ProcRating"
                                                    CommandArgument="3" ToolTip="OK" align="middle" Style="padding-bottom: 8px" />
                                                <asp:ImageButton runat="server" ID="star4" ImageUrl="../images/target_white.gif"
                                                    onmouseout="GetRating()" onmouseover="ProcHover('4')" OnCommand="ProcRating"
                                                    CommandArgument="4" ToolTip="Good" align="middle" Style="padding-bottom: 8px" />
                                                <asp:ImageButton runat="server" ID="star5" ImageUrl="../images/target_white.gif"
                                                    onmouseout="GetRating()" onmouseover="ProcHover('5')" OnCommand="ProcRating"
                                                    CommandArgument="5" ToolTip="Super!" align="middle" Style="padding-bottom: 8px" />
                                                <asp:Label CssClass="dkgrey10b" ID="lblRatingCount" runat="server"></asp:Label>
                                            </td>
                                            <td class="dkgrey14b">
                                                &nbsp;Views:
                                                <asp:Label CssClass="dkgrey14b" ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label>
                                            </td>
                                            <td align="right">
                                                &nbsp;
                                                <!-- AddThis Button BEGIN -->
                                                <div class="addthis_toolbox addthis_default_style">
                                                    <a href="http://www.addthis.com/bookmark.php?v=250&amp;pub=vizualz" class="addthis_button_compact">
                                                        Share</a> <span class="addthis_separator">|</span> <a class="addthis_button_digg"></a>
                                                    <a class="addthis_button_facebook"></a><a class="addthis_button_twitter"></a><a class="addthis_button_email">
                                                    </a>
                                                </div>

                                                <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pub=vizualz"></script>

                                                <!-- AddThis Button END -->
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <br />
                            <%--BEGIN COMMENTS--%>
                            <!-- #include file="../include/Comments.aspx" -->
                            <%--TILEAD & FOOTER--%>
                            <div align="center">
                                <br />
                                <br />
                                <br />
                                <!-- #include file="../include/ads/tileAd.htm" -->
                                <br /><br />
                            </div>
                        </div>
                        <%--end center--%>
                    </div>
                    <%--WRAPPER--%>
                </div>
                <%--CONTAINER--%>
            </div>
            <!-- end master panel -->
            <div>
                <%--<asp:Image ID="Pic2" runat="server" Visible="false"></asp:Image>--%>
                <asp:Image ID="Pic2ThmbNail" CssClass="highlightit" runat="server" Visible="false" />
                <asp:Image ID="Pic3" runat="server" Visible="false"></asp:Image>
                <asp:Image ID="Pic4" runat="server" Visible="false"></asp:Image>
            </div>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>            
            <asp:HiddenField ID="hdnbId" runat="server" />
            <asp:HiddenField ID="hdnPageHit" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPic1URL" runat="server" />
            <asp:HiddenField ID="hdnPic2URL" runat="server" />
            <asp:HiddenField ID="hdnPic3URL" runat="server" />
            <asp:HiddenField ID="hdnPic4URL" runat="server" />
            <asp:HiddenField ID="hdnRatingVal" runat="server" />
            <asp:HiddenField ID="hdnRatingCnt" runat="server" />
            <div id="push">
            </div>
        </form>
    </div>
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
