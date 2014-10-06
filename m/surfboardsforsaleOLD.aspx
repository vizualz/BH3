<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="surfboardsforsale.aspx.cs"
    Inherits="BoardHunt.m.surfboardsforsale" EnableEventValidation="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Boardhunt | Mobile</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="New and used Surfboards, and other boarding gear, for sale by surfers in the Boardhunt community" />
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css"
        type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css"
        type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js"
        type="text/javascript"></script>
    <script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.1.js"
        type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js"
        type="text/javascript"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboards For Sale"
        href="http://www.boardhunt.com/rss/surfboards.xml" />
    <link href="../style/mob_global.css" type="text/css" rel="stylesheet" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../include/js/jquery.jgrowl.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/jquery.jgrowl.css" />
    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />
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
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });

            $(function () {
                var availableTags = ["Channel Islands", "Channel Island", "flyer", "pod", "Al Merrick", "Roberts", "Rusty", "Lost", "Bissell", "Linden", "FCD", "HIC", "Chemistry", "Xanadu", "3rd World Exotic", "Hynson", "SharpEye", "Becker", "Chili", "Firewire", "Kane Garden", "Santa Cruz", "WRV", "Quiet Flight", "Surf Prescriptions", "SurfTech", "Bill Johnson", "MR", "Weber", "Rickland", "West", "Resist", "KookBox", "Tequoph"];
                $("#txtFilterKwd").autocomplete({
                    source: availableTags, minLength: 2
                });
            });

            $('img.Tips').cluetip({ splitTitle: '|', clickThrough: true });
            $('input.Tips').cluetip({ splitTitle: '|', clickThrough: true, width: 190, height: 'auto', dropShadow: false });

            if ($('#hdnSash').val() == "000") {

                $('#adv').find('input, textarea, button, select').attr('disabled', 'disabled');
                //$('#adv').find('select').attr('disabled', 'disabled');
                $('#adv').bind('click', function () {
                    $.jGrowl.defaults.position = 'center-middle';
                    $.jGrowl.defaults.pool = 1;
                    $.jGrowl("<span class='white16'>To use Advanced Filters, you must be logged in with a Pro Account.&nbsp;&nbsp;<br><a href='/register_user.aspx' class='orange_dkorange16'>Register</a> now or Upgrade if you're already a member.</span>",
                    { sticky: true
                        //height: 400
                        //beforeOpen: function(e,m,o){ 
                        //$(e).height("108px"); 
                        //} 

                        //header: 'Title' 

                    });
                    $('#jGrowl').height(600);
                });

            }

            //don't attach if it's '1' otherwise attach and prevent 

        });
    </script>
    <!--[if lt IE 7]>
    <script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
    <![endif]-->
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
<!--Kissmetrics code-->
<script type="text/javascript">
    _kmq.push(['identify', 'your_identifier_here']);
</script>
<script type="text/javascript">
    var _kmq = _kmq || [];
    function _kms(u) {
        setTimeout(function () {
            var s = document.createElement('script'); var f = document.getElementsByTagName('script')[0]; s.type = 'text/javascript'; s.async = true;
            s.src = u; f.parentNode.insertBefore(s, f);
        }, 1);
    }
    _kms('//i.kissmetrics.com/i.js'); _kms('//doug1izaerwt3.cloudfront.net/4b086541e2a3d11d3745c8203f12221ab599208c.1.js');
</script>
<!--End Kissmetrics code-->
</head>
<body>
    <form id="Form1" runat="server">
    <div id="main" align="center">
        <!-- #include file="../include/HeaderMob.aspx" -->
        <%--PAGE NAV--%>
        <div align="center">

                            <%--FILTER--%>
                            <div id="left" style="">

                                                            <asp:Panel runat="server" Width="" ID="pnlSimple" BorderStyle="solid" BorderColor="#99CC33"
                                    BorderWidth="0">
                                    <table border="0" bgcolor="#ffffff" cellpadding="0" cellspacing="0" style="background-color: #99CC33">
                                    <tr><td align="center" style="background-color: #99CC33">
                                                <asp:Button ID="btnSearch2" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                    OnClick="btnSearch_Click" />
                                            </td>

                                            <td>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="160" CssClass="dkrgrey16b"
                                                    Style="background-image: url('http://www.boardhunt.com/images/atarget.gif');
                                                    background-repeat: no-repeat; background-position: right" Text="Keywords" OnClick="select()" ></asp:TextBox>
                                                <%--<asp:TextBox ID="txtKeywords" onKeyDown="CheckForEnter(event.keyCode);" 
                                            style="background-image:url('http://www.boardhunt.com/images/atarget.gif');
                                            background-repeat:no-repeat; background-position:right" runat="server" CssClass="midorange10b"
                                            Width="150px"></asp:TextBox>  --%>&nbsp;&nbsp;
                                            </td>                                    
                                                   <td >
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboBoardType" Width="175" runat="server" CssClass="dkrgrey16b">
                                                </asp:DropDownList>&nbsp;&nbsp;
                                            </td>
                                            <td >
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="175" runat="server" CssClass="dkrgrey16b">
                                                </asp:DropDownList>&nbsp;&nbsp;
                                            </td>
                                            <td  class="dkgrey14" style="width: 147px">
                                                &nbsp;&nbsp;$
                                                <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                                    CssClass="dkrgrey12"></asp:TextBox>
                                                &nbsp;to&nbsp;$
                                                <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkrgrey12" runat="server"
                                                    Text="Max" Width="30"></asp:TextBox>
                                            </td>
                                    </tr>

                                        <tr>
                                            <td align="center" style="background-color: #99CC33; width: 147px; height: 20px;">
                                                <a href="javascript:resetFilter()" class="white_white12">reset</a>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                                                    <asp:Panel runat="server" Width="" ID="pnlFilter" BorderStyle="solid" BorderColor="#99CC33"
                                    BorderWidth="0">
                                    <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="background-color: #99CC33; height: 1px">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#99CC33">
                                                <img src="../images/s1x1.gif" height="5" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                        <td></td>
                                        </tr>

                                        <tr>
                                            <td bgcolor="#ff9900" align="center" class="white16b" style="width: 147px; height: 30px;">
                                                <img src="../images/s1x1.gif" alt="" />Basic
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="width: 147px; height: 30px;">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" bgcolor="#ffffff" align="left" style="height: 15px; width: 147px;">
                                                &nbsp;&nbsp;Keywords:
                                            </td>
                                        </tr>
                                        <tr>
<td></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="width: 147px; height: 10px;">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkrgrey16b" bgcolor="#ffffff" align="left" style="height: 15px; width: 147px;">
                                                &nbsp;&nbsp;Board
                                            </td>
                                        </tr>
                                        <tr>
<td></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="height: 5px">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" align="left" height="15" style="width: 147px">
                                                &nbsp;&nbsp;Area
                                            </td>
                                        </tr>
                                        <tr>
<td></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" height="5">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15" style="width: 147px">
                                                &nbsp;&nbsp;Price
                                            </td>
                                        </tr>
                                        <tr>
<td></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="height: 30px">
                                                <img src="../images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="adv">
                                        <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="white16b" bgcolor="#ff9900" align="center" style="height: 30px; width: 147px;">
                                                    Advanced
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#ffffff" style="height: 30px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkrgrey16b" align="middle" valign="bottom">
                                                    &nbsp;&nbsp;<asp:CheckBox valign="middle" ID="chkReduced" runat="server" />&nbsp;Best
                                                    deals&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" style="width: 147px; height: 10px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                    &nbsp;&nbsp;Condition
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF">
                                                    &nbsp;&nbsp;<asp:DropDownList ID="cboCondition" Width="125" runat="server" CssClass="dkrgrey12">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" height="10">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                    &nbsp;&nbsp;Board size
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" class="dkgrey14">
                                                    &nbsp;&nbsp;<asp:TextBox ID="txtHtFt" onkeyup="CountMyChars(txtHtFt,2)" OnClick="select()"
                                                        runat="server" Width="15" Text="ft" CssClass="dkrgrey12"></asp:TextBox>
                                                    <asp:TextBox ID="txtHtIn" onkeyup="CountMyChars(txtHtIn,2)" OnClick="select()" CssClass="dkrgrey12"
                                                        runat="server" Text="in" Width="15"></asp:TextBox>
                                                    <span style="font: 14px Trebuchet">&nbsp;to</span>&nbsp;
                                                    <asp:TextBox ID="txtHtFtMax" onkeyup="CountMyChars(this,2)" runat="server" OnClick="select()"
                                                        CssClass="dkrgrey12" Text="ft" Width="15"></asp:TextBox>
                                                    <asp:TextBox ID="txtHtInMax" onkeyup="CountMyChars(this,2)" OnClick="select()" CssClass="dkrgrey12"
                                                        runat="server" Text="in" Width="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" height="10">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                    &nbsp;&nbsp;# of Fins
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" align="left">
                                                    &nbsp;&nbsp;<asp:DropDownList ID="cboFins" runat="server" CssClass="dkrgrey12" Width="125">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" style="height: 10px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                    &nbsp;&nbsp;Tail
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" align="left">
                                                    &nbsp;&nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="dkrgrey12"
                                                        Width="125">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" style="width: 147px; height: 10px;">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkgrey14" align="left" height="15" style="width: 147px">
                                                    &nbsp;&nbsp;For Sale/Wanted
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 147px">
                                                    &nbsp;&nbsp;<asp:DropDownList ID="cboAdType" Width="125" runat="server" CssClass="dkrgrey12">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 147px; height: 10px;">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkgrey14" align="left" height="15" style="width: 147px">
                                                    &nbsp;&nbsp;Business/Private
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 147px">
                                                    &nbsp;&nbsp;<asp:DropDownList ID="cboPostingType" Width="125" runat="server" CssClass="dkrgrey12">
                                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Business only"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Private only"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 30px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #99CC33; height: 1px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#99CC33" style="width: 147px; height: 10px;">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="bottom" style="background-color: #99CC33; width: 147px">
                                                    <asp:Button ID="btnSearch" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #99CC33; width: 147px;">
                                                    <a href="javascript:resetFilter()" class="white_white12">reset</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #99CC33; height: 1px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <br />
                                <!-- Start: Ads -->
                            </div>

            <div style="display: none;">
                <div class="dkgrey12" align="left" style="margin-left: 0px; margin-top: 20px;
                    vertical-align: baseline">
                    <br />
                    &nbsp;
                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    <asp:HyperLink CssClass="dkgrey_orange12" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>
                    <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
                </div>
                <div class="midorange26b" align="center">
                    <img src="../images/s1x1.gif" height="3" alt="" /></div>
                <div class="midorange26b" align="center">
                    <asp:Label CssClass="midgrey18" ID="lblNoResult" runat="server"></asp:Label><br />
                </div>
            </div>
            <div align="center">
                <div align="center" id="container" style="">
                    <div align="center" id="wrapper" style="">
                        <%--LEFT COLUMN--%>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                        </div>
                        <!-- end right column-- >
        
                    <!--CENTER COLUMN-->
                        <div id="center" width="">
                            <div align="left" vertical_align="bottom" class="dkrgrey30b">
                                &nbsp; Surfboards<span class="dkrgrey18g"> for sale by owner</span>&nbsp;<asp:Label
                                    CssClass="dkrgrey30b" ID="lblCount" runat="server"></asp:Label>
                            </div>
                            <div align="center">
                                <table width="" align="center">
                                    <asp:DataList Width="" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid"
                                        BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="true" OnItemCommand="View_ItemDetail">
                                        <HeaderTemplate>
                                            <tr>
                                                <td colspan="12" bgcolor="#ff9900" height="1px">
                                                    <img src="../images/s1x1.gif" alt="" height="1" />
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr id="hRow" valign="middle" style="height: 100px" class="row">
                                                <!--Date-->
                                                <td>
                                                    &nbsp;
                                                    <asp:LinkButton CssClass="dkgrey_white10" ID="LinkButton1" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										            <%//# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}") %>
                                                    </asp:LinkButton>
                                                </td>
                                                <!--AdType-->
                                                <td align="center">
                                                    <asp:ImageButton runat="server" ID="imgAdType" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# GetAdType(DataBinder.Eval(Container.DataItem, "adType")) %>'
                                                        ToolTip='<%# DecodeAdType(DataBinder.Eval(Container.DataItem, "adType"))%>'>
                                                    </asp:ImageButton>
                                                </td>
                                                <!--HasPic-->
                                                <td width="40">
                                                    <asp:Panel ID="pnlPreview" CssClass="imgcontainer" runat="server">
                                                        <asp:LinkButton BorderWidth="0" runat="server" CssClass="thumbnail" ID="lnkBtnImg"
                                                            OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                            <asp:Image BorderWidth="0" ID="imgCameraPic" CssClass="thumbnail" runat="server"
                                                                ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1")) %>' />


                                                        </asp:LinkButton>
                                                    </asp:Panel>
                                                </td>
                                                <td width="3px">
                                                    <img src="../images/s1x1.gif" alt="" />
                                                </td>
                                                <!--Desc-->
                                                <td class="dkrgrey_white_m" align="left" width="100%" nowrap>
                                                    <asp:LinkButton CssClass="dkrgrey_white_m" ID="LinkButton2" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
										
										<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
										
                                        <%# FormatBrand(DataBinder.Eval(Container.DataItem, "txtBrand"), DataBinder.Eval(Container.DataItem, "txtShaper"))%>
										&nbsp;

										<%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
										<%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>										
                                                    
                                                    </asp:LinkButton>&nbsp;<br />
                                                    <asp:LinkButton ID="lnBtnTown" CssClass="dkrgrey_white_med" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "txtTown") %></asp:LinkButton>
                                                        &nbsp;
 
                                                </td>
                                                <!--Area-->
                                                <td width="105" valign="middle" align="right">
                                                </td>
                                                <!--Price-->
                                                <td align="left" class="header" width="">
                                                    <asp:LinkButton ID="lnkBtnPrice" CssClass="dkrgrey_white36b" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") + "&nbsp;&nbsp;" %>
                                                    </asp:LinkButton>
                                                    <asp:ImageButton runat="server" class="Tips" title='<%# GetTip(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>'
                                                        OnCommand="GetValues" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                                        ID="imgBtnReduced" ImageUrl='<%# SetPricePic(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>' />
                                                    <br />
                                                        <a class="dkgrey_white10" href='http://www.boardhunt.com/ItemDetails.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD") %>'>
                                                        <span class="uiSquareValue">
                                                        <span class="value reviews_count">
                                                        <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>
                                                        </span></span>
                                                        </a>
                                                    <span class="midgrey18">&nbsp;Views</span>                                                    
                                        &nbsp;&nbsp;
                                                    
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </table>
                                <% //Paging %>
                                <table border="0">
                                    <tr>
                                        <td height="20">
                                            <img src="../images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:LinkButton ID="lnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_grey22"></asp:LinkButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                                runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                            <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>&nbsp;&nbsp;
                                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                                runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkLast" Text="last" runat="server" Visible="false" CssClass="grey_grey22"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLocVal" Value="" runat="server" />
                                <asp:HiddenField ID="hdniCat" Value="" runat="server" />
                                <asp:HiddenField ID="hdnServer" Value="" runat="server" />
                                <asp:HiddenField ID="hdniBoardType" Value="" runat="server" />
                                <asp:HiddenField ID="hdnKeywords" Value="" runat="server" />
                                <asp:HiddenField ID="hdnUiD" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSash" Value="" runat="server" />
                            </div>
                            <br />
                            <br />

                        </div>
                        <%--END CENTER--%>
                    </div>
                    <%--END WRAPPER--%>
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                    </div>
                </div>
                <%--END CONTAINER--%>
            </div>
            <div class="push">
            </div>
        </div>
        <%--END MAIN--%>
        <div align="center">
            <!-- #include file="../include/footerMob.aspx" -->
        </div>
    </form>
    <script type="text/javascript" src="include/js/googles.js"></script>
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>
    <%--CrazyEgg--%>
    <script type="text/javascript">
        setTimeout(function () {
            var a = document.createElement("script");
            var b = document.getElementsByTagName('script')[0];
            a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/7491.js";
            a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
        }, 1);
    </script>
</body>
</html>
