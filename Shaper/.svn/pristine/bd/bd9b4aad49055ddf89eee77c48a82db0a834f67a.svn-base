<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShaperHouse.aspx.cs" Inherits="BoardHunt.Shaper.ShaperHouse" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Surfboard Shapers | ShaperHouse </title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->
    <meta name="description" content="New Surfboards Models from Global Shapers" />
    <meta name="keywords" content="new surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: ShaperHouse - New Surfboard Models"
        href="http://www.malzook.com/rss/surfboards.xml" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link href="../style/global.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link href="../style/hover.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>
    <script type="text/javascript">
        function SaveBG(val) {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            hdnCtl.value = val;
        }

        function GetBG() {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            return hdnCtl.value;
        }

        function SetHdnLocVal() {
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
<body bgcolor="#222222">
    <div id="main" align="center">
        <form id="Form1" runat="server">
        <!-- #include file="../include/Header.aspx" -->
        <div id="pageNav" style="width: 1100px" class="white12" align="center">
            <div align="center">
                <asp:HyperLink CssClass="orange_grey12u" ID="HypLoc" runat="server" NavigateUrl="../Shaper/Shaperhouse.aspx">
                <img src="../images/shaperhouse.gif" border="0" alt="shaperhouse" /></asp:HyperLink>
                <%--PAGE NAV--%>
                <br />
                <asp:Label CssClass="" ID="lblPageDesc" runat="server"></asp:Label>
                <asp:Label CssClass="dkgrey12" ID="lblCount" runat="server"></asp:Label>
                <table style="height: 250px; width: 996px">
                    <tr>
                        <td align="left" style="background-image: url(../images/shaperhouse.jpg); width: 996px;
                            vertical-align: bottom;">
                            <div class="dkrgrey16" style="float: left; margin-left: 20px;">
                                <br />
                                <span class="white24">Find new shapes, save. </span>
                                <br />
                                <a class="dkrgrey_orange14" href="./ShaperHouseMore.aspx">shaper sign up</a> | <a
                                    class="dkrgrey_orange14" href="./surfboards.aspx">latest models</a> | <a class="dkrgrey_orange14"
                                        href="./ShaperVideos.aspx">shaperHouseTV</a> |
                                <%--<a class="dkrgrey_orange14" href='http://www.malzook.com/qp/Coupons.aspx'>save how?</a><br /><br />--%>
                                <%--<image src="../images/SH.gif"></image>--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="midorange26b" align="center">
                <img src="../images/s1x1.gif" height="3" alt="" /></div>
            <div class="midorange26b" align="center">
                <asp:Label CssClass="midgrey18" ID="lblNoResult" runat="server"></asp:Label></div>
            <br />
            <br />
            <div align="center">
                <div align="center" id="container" style="width: 1000px;">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <%--FILTER--%>
                        <div id="left" style="width: 170px; border: solid 0px Red">
                            <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#222222"
                                BorderWidth="0">
                                <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="background-color: #222222; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222">
                                            <img src="../images/s1x1.gif" height="5" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #222222">
                                            <asp:Button ID="btnSearch2" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#222222" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Keywords:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="120" CssClass="dkrgrey12"
                                                Style="background-image: url('http://www.malzook.com/images/atarget.gif'); background-repeat: no-repeat;
                                                background-position: right"></asp:TextBox>
                                            <%--<asp:TextBox ID="txtKeywords" onKeyDown="CheckForEnter(event.keyCode);" 
                                            style="background-image:url('http://www.malzook.com/images/atarget.gif');
                     
               
                                          background-repeat:no-repeat; background-position:right" runat="server" CssClass="midorange10b"
                                            Width="150px"></asp:TextBox>  --%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#333333" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Shapes:
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen12" align="left" height="15">
                                            &nbsp;&nbsp;Type of Board</td>
                                    </tr>--%>
                                    <tr>
                                        <td bgcolor="#333333">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboBoardType" Width="125" runat="server" CssClass="dkrgrey16b">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#333333" style="height: 5px">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <%--                                    <tr>
                                        <td bgcolor="#FFFFFF" height="5">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>                                    
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" align="left" height="15">
                                            &nbsp;&nbsp;Height</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtHtFt" onkeyup="CountMyChars(txtHtFt,2)" OnClick="select()"
                                                runat="server" Width="15" Text="ft" CssClass="dkgrey10b"></asp:TextBox>
                                            <asp:TextBox ID="txtHtIn" onkeyup="CountMyChars(txtHtIn,2)" OnClick="select()" CssClass="dkgrey10b"
                                                runat="server" Text="in" Width="15"></asp:TextBox>
                                                 <span style="font: 12px Trebuchet">&nbsp;to</span>&nbsp;
                                                    
                                            <asp:TextBox ID="txtHtFtMax" onkeyup="CountMyChars(this,2)" runat="server" OnClick="select()"
                                                CssClass="dkgrey10b" Text="ft" Width="15"></asp:TextBox>
                                            <asp:TextBox ID="txtHtInMax" onkeyup="CountMyChars(this,2)" OnClick="select()" CssClass="dkgrey10b"
                                                runat="server" Text="in" Width="15"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td bgcolor="#333333" style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <%--                                <tr>
                                    <td bgcolor="#333333" class="white12" align="left" height="15" style="width: 147px">
                                        &nbsp;&nbsp;Price</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#333333" class="white12" style="width: 147px">
                                        &nbsp;&nbsp;$
                                        <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                            CssClass="dkrgrey10b"></asp:TextBox>
                                        &nbsp;to&nbsp;$
                                        <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkrgrey10b" runat="server"
                                            Text="Max" Width="30"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#333333" style="width: 147px;height:15px">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>--%>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" class="white16b" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;Area
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="125" runat="server" CssClass="dkrgrey12">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #222222; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#222222" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="bottom" style="background-color: #222222; width: 147px">
                                            <asp:Button ID="btnSearch" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #222222; width: 147px;">
                                            <a href="javascript:resetFilter()" class="white_white12">reset</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #222222; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <!-- Start: Ads -->
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%-- <div class="white20b">Custom Surfboard Vouchers<br /><br />
                           <a class="grey_ltgreen10" href="http://www.malzook.com/qp/Coupons.aspx">
                                <img src="http://www.malzook.com/images/VoucherOrderForm.gif" border="0" 
                                    alt="More help" class="Tips" title="Vouchers | Save on new custom surfboards from participating shapers" /></a>
                           </div><br /><br />--%>
                            <%--BOOST HERE--%>
                            <div class="white14">
                                <bh:ShowBoost ID="boost1" runat="server"></bh:ShowBoost>
                            </div>
                        </div>
                        <!-- end right column-- >
        
                    <!--CENTER COLUMN-->
                        <div id="center" style="width: 680px; background-color: #222222" class="white12">
                            <div align="center" style="background-color: #222222;">
                                <br />
                                <table border="0">
                                    <tr>
                                        <td height="20">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <%--<asp:LinkButton ID="toplnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>&nbsp;--%>
                                            <div class="slct_box">
                                                <div class="btn_left">
                                                    <asp:ImageButton ID="topcmdPrev" onmouseover="this.src='../images/shaper_left_hover.png'"  onmouseout="this.src='../images/shaper_left.png'"
                                                        ImageUrl="~/images/shaper_left.png" runat="server"></asp:ImageButton>
                                                </div>
                                                <div class="info_txt">
                                                    Page</div>
                                                <asp:TextBox ID="toptxtCurrentPage" runat="server" CssClass="option_box_shaper" AutoPostBack="True"
                                                    Visible="false" OnTextChanged="toptxtCurrentPage_TextChanged" ForeColor="White"></asp:TextBox>
                                                <div class="info_txt">
                                                    <asp:Label ID="toplblcpage" CssClass="info_txt" runat="server" Visible="false"></asp:Label></div>
                                                <div class="btn_left_blue">
                                                    <asp:ImageButton ID="topcmdNext" onmouseover="this.src='../images/shaper_right_hover.png'" onmouseout="this.src='../images/shaper_right.png'" runat="server"
                                                        ImageUrl="~/images/shaper_right.png"></asp:ImageButton>
                                                </div>
                                                <div class="cls">
                                                </div>
                                            </div>
                                            <!-- select box ends-->
                                        </td>
                                    </tr>
                                </table>
                                <asp:DataList Width="650px" RepeatLayout="Table" BorderColor="#222222" BorderStyle="Solid"
                                    OnItemDataBound="dlEntryList_OnItemDataBound" BorderWidth="0" align="center"
                                    OnItemCreated="dlEntryList_OnItemCreated" ID="dlEntryList" runat="server" EnableViewState="true"
                                    OnItemCommand="View_ItemDetail">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlItem" runat="server">
                                            <div align="center" style="border: solid 0px red; height: 100px">
                                                <div align="center" style="border: solid 0px blue; height: 110px; width: 625px">
                                                    <br />
                                                    <div style="width: 80px; background-color: #333333; margin-left: 25px; float: left;
                                                        border: solid 2px white">
                                                        <asp:ImageButton runat="server" ID="ImageButton2" Height='64' Width='64' OnCommand="GetValues"
                                                            CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                                            ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "profilePic"))%>'>
                                                        </asp:ImageButton>
                                                    </div>
                                                    <div style="width: 20px; background-color: #222222; float: left; border: solid 0px black">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left; border: solid 0px black" align="left">
                                                        <asp:LinkButton CssClass="white_grey22" ID="lnkTitle" runat="server" OnCommand="GetValues"
                                                            CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
		                                    <%# DataBinder.Eval(Container.DataItem, "txtBrandName")%>
                                                        </asp:LinkButton>
                                                        <br />
                                                        <span class="dkgrey14">Area: <span class="white14">
                                                            <%# DataBinder.Eval(Container.DataItem, "txtHomeTown")%>
                                                        </span></span>
                                                        <br />
                                                        <span class="dkgrey14">Years Shaping: <span class="white14">
                                                            <%# DataBinder.Eval(Container.DataItem, "iWisdom")%>
                                                        </span></span>
                                                        <br />
                                                        <span class="dkgrey14">Views: <span class="white14">
                                                            <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>
                                                        </span>
                                                            <asp:HiddenField ID="hdnShaperCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iShaperCode")%>' />
                                                            <br />
                                                    </div>
                                                    <div style="float: right; margin-right: 50px;">
                                                        <asp:ImageButton ImageUrl="../images/Voucher_buy_badge.gif" OnCommand="BuyVoucher"
                                                            CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ID="imgBtnVoucher"
                                                            runat="server" Visible='<%#CheckVoucher(DataBinder.Eval(Container.DataItem, "iVoucher"))%>' />
                                                    </div>
                                                </div>
                                                <hr align="center" color="#333333" style="width: 650px" />
                                                <br />
                                            </div>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:DataList>
                                <table border="0">
                                    <tr>
                                        <td height="20">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <div class="slct_box">
                                                <div class="btn_left">
                                       <asp:ImageButton ID="cmdPrev"  onmouseover="this.src='../images/shaper_left_hover.png'"  onmouseout="this.src='../images/shaper_left.png'"
                                                        ImageUrl="~/images/shaper_left.png" runat="server"></asp:ImageButton>
                                                </div>
                                                <div class="info_txt">
                                                    PAGE</div>
                                                <asp:TextBox ID="txtCurrentPage" runat="server" CssClass="option_box_shaper" AutoPostBack="True"
                                                    Visible="false" ForeColor="White" OnTextChanged="txtCurrentPage_TextChanged"></asp:TextBox>
                                                <div class="info_txt">
                                                    <asp:Label ID="lblcpage" runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <div class="btn_left_blue">
                                                 <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/shaper_right_hover.png'" onmouseout="this.src='../images/shaper_right.png'" runat="server"
                                                        ImageUrl="~/images/shaper_right.png"></asp:ImageButton></div>
                                                        </div>
                                                <div class="cls">
                                                </div>
                                            </div>
                                            <!-- select box ends-->
                                       <%--     <asp:LinkButton ID="lnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lnkLast" Text="last" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>--%>
                                        </td>
                                    </tr>
                                </table>
                                <%--  <table border="0">
                                    <tr>
                                        <td height="20">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                                runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                                            <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                            <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
                                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                                runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>--%>
                                <br />
                                <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLocVal" Value="" runat="server" />
                                <asp:HiddenField ID="hdniCat" Value="" runat="server" />
                                <asp:HiddenField ID="hdnServer" Value="" runat="server" />
                                <asp:HiddenField ID="hdniBoardType" Value="" runat="server" />
                                <asp:HiddenField ID="hdnKeywords" Value="" runat="server" />
                                <asp:HiddenField ID="hdnUiD" Value="" runat="server" />
                            </div>
                            <br />
                            <br />
                        </div>
                        <%--END CENTER--%>
                        <%--TILEAD--%>
                        <div align="center">
                            <br />
                            <!-- #include file="../include/ads/tileAd.htm" -->
                        </div>
                    </div>
                    <%--END WRAPPER--%>
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                    </div>
                </div>
                <%--END CONTAINER--%>
            </div>
            <br />
        </div>
        </form>
        <div id="push">
        </div>
        <br />
    </div>
    <br />
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <script type="text/javascript" src="../include/js/googles.js"></script>
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
