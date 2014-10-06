<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SurfboardShaper.aspx.cs"
    Inherits="BoardHunt.Shaper.SurfboardShaper" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<%@ Register TagPrefix="bh" TagName="ctlShapers" Src="../include/Controls/Shapers.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://opengraphprotocol.org/schema/"
    xmlns:fb="http://www.facebook.com/2008/fbml">
<head runat="server">
    <title>Surfboard Shapers | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboard Shaper"
        href="http://www.malzook.com/rss/surfboards.xml" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <meta name="description" content="New and used Surfboards, and other boarding gear, for sale by surfers in the Boardhunt community" />
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />

    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
        $('input.Tips').cluetip({splitTitle: '|',clickThrough:     true,width: '100px'});
            
    });
    </script>

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

    <meta property="og:site_name" content="Boardhunt|ShaperHouse" />
    <meta property="og:description" content="ShaperHouse is where surfboard shapers can display their work and connect with the Boardhunt community" />
    <meta property="fb:app_id" content="143749072318586" />

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
        <form id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <%--PAGE NAV--%>
            <div class="midgrey12" align="center">
            </div>
            <div class="midorange26b" align="center">
                <img src="../images/s1x1.gif" height="3" alt="" /></div>
            <div class="midorange26b" align="center">
                <asp:Label CssClass="midgrey18" ID="lblNoResult" runat="server"></asp:Label>
            </div>
            <div align="center">
                <div align="center" id="container" style="width: 1000px">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <div id="left" style="width: 170px;">
                            <div style="width: 170px; margin-top:50px; border: solid 0px green">
                                
                                <bh:ctlShapers id="ShapersAll" runat="server">
                                </bh:ctlShapers>
                            </div>
                            <br />
                            <%--FILTER--%>
                            <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#99CC33"
                                BorderWidth="1">
                                <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="background-color: #99CC33; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33">
                                            <img src="../images/s1x1.gif" height="5" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #99CC33">
                                            <asp:Button ID="btnSearch2" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #99CC33; width: 147px; height: 20px;">
                                            <a href="javascript:resetFilter()" class="white_white12">start over</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#99CC33" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Keywords:</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="width: 147px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="120" CssClass="dkgrey10b"
                                                Style="background-image: url('http://www.malzook.com/images/atarget.gif');
                                                background-repeat: no-repeat; background-position: right"></asp:TextBox>
                                            <%--<asp:TextBox ID="txtKeywords" onKeyDown="CheckForEnter(event.keyCode);" 
                                            style="background-image:url('http://www.malzook.com/images/atarget.gif');
                                            background-repeat:no-repeat; background-position:right" runat="server" CssClass="midorange10b"
                                            Width="150px"></asp:TextBox>  --%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#ff9900" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Boards:</td>
                                    </tr>
                                    <%--<tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen12" align="left" height="15">
                                            &nbsp;&nbsp;Type of Board</td>
                                    </tr>--%>
                                    <tr>
                                        <td bgcolor="#ff9900">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboBoardType" Width="125" runat="server" CssClass="dkrgrey16b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ff9900" style="height: 5px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" height="10">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" align="left" height="15">
                                            &nbsp;&nbsp;Condition</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboCondition" Width="125" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
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
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" height="5">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" align="left" height="15">
                                            &nbsp;&nbsp;Fins</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" align="left">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboFins" runat="server" CssClass="dkgrey10b" Width="125">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" style="height: 5px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" align="left" height="15">
                                            &nbsp;&nbsp;Tail</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" align="left">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="dkgrey10b"
                                                Width="125">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;Price</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" class="dkgrey12" style="width: 147px">
                                            &nbsp;&nbsp;$
                                            <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                                CssClass="dkgrey10b"></asp:TextBox>
                                            &nbsp;to&nbsp;$
                                            <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkgrey10b" runat="server"
                                                Text="Max" Width="30"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFFF" style="width: 147px; height: 15px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#ff9900" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Sellers:</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 10px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey12" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;For Sale/Wanted</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboAdType" Width="125" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey12" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;Area</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="125" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 147px; height: 5px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey12" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;Business/Private</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboPostingType" Width="125" runat="server" CssClass="dkgrey10b">
                                                <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Business only"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Private only"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <asp:Panel ID="pnlFltSurf" runat="server">
                                        <tr>
                                            <td bgcolor="#FFFFFF" height="10">
                                                <img src="../images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#99CC33" height="5">
                                                <img src="../images/s1x1.gif" alt="" /></td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="background-color: #99CC33; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="width: 147px; height: 10px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="bottom" style="background-color: #99CC33; width: 147px">
                                            <asp:Button ID="btnSearch" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                OnClick="btnSearch_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #99CC33; width: 147px;">
                                            <a href="javascript:resetFilter()" class="white_white12">start over</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #99CC33; height: 1px">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <br />
                            <%--BOOST HERE--%>
                        
                        
                        </div>
                        <!-- end right column-- >
                    <!--CENTER COLUMN-->
                        <div align="center" style="border: solid 0px blue; width: 500px">
                            <asp:Panel runat="server" ID="pnlProfile" Width="500" BorderColor="red" BorderWidth="0">
                                <div style="width: 500px; margin-top:50px" align="left">
                                    <asp:Label ID="lblBrandName" CssClass="white40" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <div style="float: left; width: 160px">
                                        <br />
                                        <br />
                                        <asp:Image runat="server" ID="imgPic" Height="128" Width="128" />
                                        <div>&nbsp;</div>
                                    </div>
                                    <div style="float: left; width: 340px; margin-top:50px;">
                                        <br />
                                        <table>
                                            <tr>
                                                <td align="left" class="dkgrey14">
                                                    Area:</td>
                                                <td align="left">
                                                    <asp:Label ID="lblHometownData" CssClass="white14" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="dkgrey14">
                                                    #:</td>
                                                <td align="left">
                                                    <asp:Label ID="lblPhone" CssClass="white14" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="dkgrey14">
                                                    e:</td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkEmail" CssClass="orange_white14" runat="server"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="dkgrey14">
                                                    Web:</td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkWebSite" CssClass="orange_white14" runat="server" OnClick="lnkWebSite_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <%--<tr><td align="right" class="midgrey14">Bio:</td><td align="left"><asp:Label ID="lblBioData" Cssclass="ltgrey14" runat="server"></asp:Label></td></tr>
                    --%>
                                        </table>
                                    </div>
                                </div>
                                <div>
                                    &nbsp;</div>
                                <div id="bio" style="width: 500px; border: solid 0px blue" align="left">
                                    <span class="dkgrey12">Bio:&nbsp;</span><asp:Label ID="lblBioData" CssClass="white12"
                                        runat="server"></asp:Label>
                                </div>

                            </asp:Panel>
                                <br />
                                <div style="padding-top: 0px; width: 750px; height: 50px; border: solid 0px #333333;
                                    float: left; background-color: #222222" align="left" vertical-align="middle">
                                    <div style="float: left; height: 50px;" vertical-align="middle">
                                        &nbsp;
                                        <asp:Label ID="lblFB" runat="server" Width="200" BorderWidth="0"></asp:Label>
                                    </div>
                                    
                                    
                                    <!-- AddThis Button BEGIN -->
                                    <div style="float: left; width: 300px; height: 50px;" class="addthis_toolbox addthis_default_style addthis_32x32_style" vertical-align="middle">
                                    <a class="addthis_button_preferred_1"></a>
                                    <a class="addthis_button_preferred_2"></a>
                                    <a class="addthis_button_preferred_3"></a>
                                    <a class="addthis_button_compact"></a>
                                    </div>
                                        <script type="text/javascript">    var addthis_config = { "data_track_clickback": true };</script>
                                        <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4df1178f225b17c1"></script>
                                    <!-- AddThis Button END -->
                                    
                                    <div style="float: right; height: 50px;" vertical-align="middle">
                                        <asp:Label ID="lblViews" runat="server" CssClass="midorange16" BorderWidth="0"></asp:Label>&nbsp;
                                    </div>
                                </div>
                                <br />

                            <br />
                            <%--NAV--%>
                            <div id="pageNav" class="dkgrey16" align="left">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                <asp:ImageButton align="absmiddle" ID="imgGoBack" ToolTip="Back to List of Shapers" runat="server"
                                    ImageUrl="../images/id_back.gif" OnClick="imgGoBack_Click"></asp:ImageButton>&nbsp;
                                <asp:HyperLink CssClass="orange_white14" ID="HypNavPrim" runat="server" NavigateUrl="ShaperHouse.aspx"></asp:HyperLink>
                                <span class="midorange12">&nbsp;</span>
                                <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
                                <asp:Label CssClass="dkgrey12" ID="lblCount" runat="server"></asp:Label>
                            </div>
                            <div align="left" style="width: 500px; border: solid 0px Black">
                                    <asp:DataList ID="dlEntryList" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal"
                                        RepeatColumns="2" BackColor="#222222" BorderColor="#000000" BorderStyle="Solid"
                                        BorderWidth="0" HeaderStyle-BackColor="#222222" EnableViewState="true" OnItemCommand="View_ItemDetail">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton Style="margin: 0px 10px 0px 10px" CssClass="Tips" runat="server"
                                                ID="imgBtnModel" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>'
                                                Title='<%# GetToolTip(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue"))%>'
                                                ToolTip='<%# GetToolTip(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue"))%>'>
                                            </asp:ImageButton>
                                            <div style="width: 300px" align="center">
                                                <div style="background-color: #222222; margin-left:30px; float: right;" align="center">
                                                    <asp:LinkButton CssClass="ltgrey_white16b" ID="LinkButton3" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										        <%# DataBinder.Eval(Container.DataItem, "txtModel") %>
                                                    </asp:LinkButton>
                                                </div>
                                                <div style="background-color: #333333; float: right;">
                                                    <asp:LinkButton CssClass="hunt" OnCommand="GetValues" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                                        Style="width: 110px" ID="lnkViewNow" runat="server">&nbsp;View&nbsp;it&nbsp;</asp:LinkButton>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                            </div>
                            <div id="center" width="600">
                                <div align="center" width="500">
                                    <br />
                                    <table border="0">
                                        <tr>
                                            <td height="20">
                                                <img src="../images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                                    runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                                                <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                                <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
                                                <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                                    runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton>
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
                                    <asp:HiddenField ID="hdnUN" Value="" runat="server" />
                                    
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
                    <%--TileAD--%>
                        <div style="margin-top:75px">
                            <br />
                            <!-- #include file="../include/ads/tileAd.htm" -->
                        </div>
                    <%--END CONTAINER--%>
                </div>
            </div>

        </form>
        <%--END MAIN--%>
                    <div id="push">
            </div>
    </div>
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>

    <script type="text/javascript" src="/include/js/googles.js"></script>

</body>
</html>
