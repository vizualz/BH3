<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Surfboardsforsale.aspx.cs" Inherits="BoardHunt.Surfboardsforsale" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="~/include/Controls/BoostHoriz.ascx" %>


<%@ Reference Control="~/include/Controls/BoostHoriz.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>

<head>
    <title>Used Surfboards | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Find new and used surfboards for sale by others in the surfing community"/>
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css" type="text/css" media="all" />
	<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />

	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboards For Sale" href="http://www.malzook.com/rss/surfboards.xml"/>
    <link href="style/global.css" rel="stylesheet" type="text/css" />
    <link href="style/hover.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="include/js/jquery.jgrowl.js"></script>

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
    <style type="text/javascript">
  #dlEntryList
  {width:90% !important;
      
      }  
    
    </style>
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

        function jsFunc() {
            document.getElementById("hField").value = "someString";
            __doPostBack("btn1", "");
        }
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
    GA_googleAddSlot("ca-pub-0007702553564747", "Box");
    GA_googleAddSlot("ca-pub-0007702553564747", "Wide_Skyscraper");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>

</head>
<body>
    <form id="Form1" runat="server">
    <div id="main" align="center">
        <!-- #include file="include/Header.aspx" -->
        <%--PAGE NAV--%>
        <div align="center" style="width: 100%; border: 0px solid red">
            <div class="dkgrey12" align="left" style="width: 1000px; margin-left: 0px; margin-top: 20px;
                vertical-align: baseline; border: 0px solid black">
                <br />
                &nbsp;
                        					

                <asp:HyperLink CssClass="dkgrey_orange12" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>
                <span class="midorange12">&nbsp;></span>
                <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
            </div>
            <div class="midorange26b" align="center">
                <img src="images/s1x1.gif" height="3" alt="" />
            </div>
            <div class="midorange26b" align="center">
                <asp:Label CssClass="midgrey18" ID="lblNoResult" runat="server"></asp:Label><br />
            </div>
            <div align="center">
                <div align="center" id="container" style="width: 1200px; border: solid 0px blue">

                    <!-- BOOST -->
                    <div class="slider_container_top" style="border: dotted 0px red">
                        <bh:ShowBoost ID="boost" runat="server"></bh:ShowBoost>
                    </div>

					<!-- WRAPPER -->
                    <div id="wrapper" align="center" style="width: 1200px; border: solid 0px black">

                        <div class="clr_fix"></div>


                        <!--- FILTER LEFT-SIDE -->
                        <div class="adver_lft_panel" style="border: solid 0px red">
                            <asp:Panel runat="server" Width="196px" ID="pnlFilter" BorderStyle="solid" BorderColor="#99CC33"
                                BorderWidth="0">
                                <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="background-color: #99CC33; height: 1px">
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33">
                                            <img src="images/s1x1.gif" height="5" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #99CC33">
                                            <asp:Button ID="btnSearch2" Text="Hunt" runat="server" CssClass="midgreen24b" Width="100px"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #99CC33; width: 147px; height: 20px;">
                                            <a href="javascript:resetFilter()" class="white_white12">reset</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" bgcolor="#669900" class="ltgreen14" style="width: 147px; height: 20px;">
                                            Find Your Board!
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#669900" class="white16b" align="left" height="15" style="width: 147px">
                                            &nbsp;&nbsp;Area
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#669900" style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="125" runat="server" CssClass="dkrgrey16" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#669900" height="10">
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="white16b" bgcolor="#669900" align="left" style="height: 15px; width: 147px;">
                                            &nbsp;&nbsp;Board
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#669900">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboBoardType" Width="125" runat="server" CssClass="dkrgrey16" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#669900" style="width: 147px; height: 10px;">
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 10px; width: 147px;">
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                        <tr>
                                            <td align="left" bgcolor="#ffffff" class="dkgrey14" style="height: 15px; width: 147px;">
                                                &nbsp;&nbsp;Keywords:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="width: 147px">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" CssClass="dkrgrey12" Style="background-image: url('http://www.malzook.com/images/atarget.gif');
                                                    background-repeat: no-repeat; background-position: right" Width="120"></asp:TextBox>
                                                <%--<asp:TextBox ID="txtKeywords" onKeyDown="CheckForEnter(event.keyCode);" 
                                            style="background-image:url('http://www.malzook.com/images/atarget.gif');
                                            background-repeat:no-repeat; background-position:right" runat="server" CssClass="midorange10b"
                                            Width="150px"></asp:TextBox>  --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="height: 10px">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF" class="dkgrey14" height="15" style="width: 147px">
                                                &nbsp;&nbsp;Price
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" class="dkgrey14" style="width: 147px">
                                                &nbsp;&nbsp;$
                                                <asp:TextBox ID="txtMinPrice" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    Text="Min" Width="30" OnTextChanged="txtPrice_TextChanged"></asp:TextBox>
                                                &nbsp;to&nbsp;$
                                                <asp:TextBox ID="txtMaxPrice" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    Text="Max" Width="30" OnTextChanged="txtPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" height="10">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF" class="dkgrey14" height="15">
                                                &nbsp;&nbsp;Height
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" class="dkgrey14">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtHtFt" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    onkeyup="CountMyChars(txtHtFt,2)" Text="ft" Width="15"></asp:TextBox>
                                                <asp:TextBox ID="txtHtIn" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    onkeyup="CountMyChars(txtHtIn,2)" Text="in" Width="15"></asp:TextBox>
                                                <span style="font: 14px Trebuchet">&nbsp;to</span>&nbsp;
                                                <asp:TextBox ID="txtHtFtMax" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    onkeyup="CountMyChars(this,2)" Text="ft" Width="15"></asp:TextBox>
                                                <asp:TextBox ID="txtHtInMax" runat="server" CssClass="dkrgrey12" OnClick="select()"
                                                    onkeyup="CountMyChars(this,2)" Text="in" Width="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="height: 30px">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                                <div id="adv">
                                    <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="midgreen16b" align="left" valign="bottom">
                                                &nbsp;&nbsp;<asp:CheckBox valign="middle" ID="chkReduced" runat="server" OnCheckedChanged="Check_Clicked" AutoPostBack="true" EnableViewState="true" />&nbsp;Best
                                                deals&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="width: 147px; height: 10px">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                &nbsp;&nbsp;Condition
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF">
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboCondition" Width="125" runat="server" CssClass="dkrgrey12" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" height="10">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" class="dkgrey14" align="left" height="15">
                                                &nbsp;&nbsp;# of Fins
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" align="left">
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboFins" runat="server" CssClass="dkrgrey12" Width="125" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="height: 10px">
                                                <img src="images/s1x1.gif" alt="" />
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
                                                    Width="125" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="width: 147px; height: 10px;">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" align="left" height="15" style="width: 147px">
                                                &nbsp;&nbsp;For Sale/Wanted
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 147px">
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboAdType" Width="125" runat="server" CssClass="dkrgrey12" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 147px; height: 10px;">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" align="left" height="15" style="width: 147px">
                                                &nbsp;&nbsp;Business/Private
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 147px">
                                                &nbsp;&nbsp;<asp:DropDownList ID="cboPostingType" Width="125" runat="server" CssClass="dkrgrey12" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Business only"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Private only"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="background-color: #99CC33; height: 1px">
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#99CC33" style="width: 147px; height: 10px;">
                                                <img src="images/s1x1.gif" alt="" />
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
                                                <img src="images/s1x1.gif" alt="" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                            <br />
                            <!-- Start: Ads -->
                            <!-- #include file="include/ads/SkyScraperAd.htm" -->
                        </div>

                            <div class="middle_adver_panel" style="border: solid 0px #CCCCCC">
                            <div align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True"> 
								<ContentTemplate>
                                <table border="0">
                                    <tr>
                                        <td height="20">
										<!-- COUNTER -->
				                        <div width="" align="left" vertical_align="bottom" class="dkrgrey30b">
				                                
				                                <asp:Label CssClass="dkrgrey30b" ID="lblCount" runat="server"></asp:Label>
										</div>
                                        </td>
                                        <td valign="bottom">
                                            <asp:LinkButton ID="toplnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>&nbsp;
                                            <!-- Paging -->
                                            <asp:Panel id="pnlPageTop" runat="server">
                                            <div class="slct_box">
                                                <div class="btn_left">
                                                    <asp:ImageButton ID="topcmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
                                                        ImageUrl="~/images/left_1.gif" runat="server"></asp:ImageButton>
                                                </div>
                                                <div class="info_txt">
                                                    <asp:Label id="lblPage1" runat="server">Page</asp:Label>
                                                </div>

                                                <asp:TextBox ID="txtHiCurrentPage" runat="server" CssClass="option_box" AutoPostBack="True"
                                                    Visible="true" OnTextChanged="OnPaging_TextChange"></asp:TextBox>
                     
                                                <div class="info_txt">
                                                    <asp:Label ID="toplblcpage" CssClass="info_txt" runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <div class="btn_left_blue">
                                                    <asp:ImageButton ID="topcmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
                                                        runat="server" ImageUrl="images/right.gif"></asp:ImageButton>
                                                </div>
                                                <div class="cls">
                                                </div>
                                            </div>
											</asp:Panel>

                                        </td>
                                    </tr>
                                </table>
								<Triggers>
								<asp:AsyncPostBackTrigger ControlID="topcmdNext"  eventname="click"/>
								<asp:AsyncPostBackTrigger ControlID="topcmdPrev"  eventname="click"/>

                                </Triggers>
 								</ContentTemplate>
 								</asp:UpdatePanel>



								<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<table  align="center">
                                    <asp:DataList  RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid" Width="770px"
                                        BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="true" OnItemCommand="View_ItemDetail">
                                        <HeaderTemplate>
                                            <tr>
                                                <td bgcolor="#ff9900" height="1px" colspan="7">
                                                    <img src="images/s1x1.gif" alt="" height="1" />
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr height="60px" id="hRow" <%# (Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %>
                                                valign="middle" style="cursor: hand" onmouseover="SaveBG(style.backgroundColor);style.backgroundColor='#CCCCCC'"
                                                onmouseout="style.backgroundColor=GetBG();">
                                                <!--Date-->
                                                <td width="25" style="border: solid blue 0px; padding-right:3px">
                                                    &nbsp;
                                                    <asp:LinkButton CssClass="dkgrey_white10" ID="LinkButton1" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										    		<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}") %>
                                                    </asp:LinkButton>
                                                </td>
                                                <!--AdType-->
                                                <td align="center" style="border: solid black 0px" width="5px">


                                                    <asp:ImageButton Visible="false" runat="server" ID="imgAdType" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# GetAdType(DataBinder.Eval(Container.DataItem, "adType")) %>'
                                                        ToolTip='<%# DecodeAdType(DataBinder.Eval(Container.DataItem, "adType"))%>'>
                                                    </asp:ImageButton>
                                                
                                                <asp:Image ID="imgPreview" runat="server" ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>'>
                                                                    </asp:Image>
                                                </td>
                                                <!--HasPic-->
                                                <td width="10" style="border: solid blue 0px">
                                                    <asp:Panel ID="pnlPreview" CssClass="imgcontainer" runat="server">
                                                        <asp:LinkButton BorderWidth="0" runat="server" CssClass="thumbnail" ID="lnkBtnImg"
                                                            OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                            <asp:Image BorderWidth="0" ID="imgCameraPic" CssClass="thumbnail" runat="server"
                                                                ImageUrl='<%# SetBoardPic(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue")) %>' />
                                                            <!--span-->
                                                            <asp:Label ID="lblPreview" runat="server">
                                                                <div style="background-color: White; filter: alpha(opacity=80); opacity: 10.0;">
                                                                    &nbsp;
                                                                    <%# GetToolTip(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue"))%>
                                                                    <%--<span style="background-color:Black;color:White;Width:75px"></span>--%><br />
                                                                    <%--
                                                                    <asp:Image ID="imgPreview" runat="server" ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>'>
                                                                    </asp:Image>
                                                                    --%>
                                                                </div>
                                                            </asp:Label>
                                                        </asp:LinkButton>
                                                    </asp:Panel>
                                                </td>

                                                <td width="3px" style="border: solid blue 0px">
                                                    <img src="images/s1x1.gif" alt="" />
                                                </td>
                                                <!--Desc-->
                                                <td class="dkgrey_white16b" align="left" width="400px"  style="border: 0px solid blue" nowrap>
                                                    <!-- TODO: insert div -->
                                                    <asp:LinkButton CssClass="dkgrey_white16b" ID="LinkButton2" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
										
										<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
										
                                        <%# FormatBrand(DataBinder.Eval(Container.DataItem, "txtBrand"), DataBinder.Eval(Container.DataItem, "txtShaper"))%>
										&nbsp;
										<%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
										<%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>										
                                                    </asp:LinkButton>&nbsp;<br />
                                                  
                                                    <span class="midgrey10"></span><a class="dkgrey_white10" href='http://www.malzook.com/surfboard.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>&nbsp;views</a><span class="midgrey10">&nbsp;</span>
                    
                                                </td>
                                                <!--Area-->
                                                <td width="10" valign="middle" align="right" style="border: solid red 0px">
                                                </td>
                                                <!--Price-->
                                                <td align="left" class="header" width="100" style="border: 0px solid blue">
                                                    <asp:LinkButton ID="lnkBtnPrice" CssClass="dkrgrey_white18b" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") + "&nbsp;&nbsp;" %>
                                                    </asp:LinkButton>
                                                    <asp:ImageButton runat="server" class="Tips" title='<%# GetTip(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>'
                                                        OnCommand="GetValues" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                                        ID="imgBtnReduced" ImageUrl='<%# SetPricePic(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>' />
                                                    <br />
                                                    <asp:LinkButton ID="lnBtnTown" CssClass="dkgrey_white10" runat="server" OnCommand="GetValues"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "txtTown") %>
                                                    &nbsp;&nbsp;
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </table>
					            </ContentTemplate>
					            <Triggers>
					                <asp:AsyncPostBackTrigger ControlID="btnSearch2" eventname="Click" />
					                <asp:AsyncPostBackTrigger ControlID="btnSearch" eventname="Click" />
					                <asp:AsyncPostBackTrigger ControlID="cboLocation"  eventname="SelectedIndexChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="cboBoardType"  eventname="SelectedIndexChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="txtMaxPrice"  eventname="TextChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="txtMinPrice"  eventname="TextChanged"/>

					                 <asp:AsyncPostBackTrigger ControlID="cboCondition"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboFins"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboTailType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboAdType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboPostingType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="chkReduced"  />
					            </Triggers>
					        </asp:UpdatePanel>

                                
                                <table border="0" width="770px">
                                    <tr>
                                        <td height="20" width="">
                                            <img src="images/s1x1.gif" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                    	<td width="237px"><img src="images/s1x1.gif" alt="" /></td>
                                        <td valign="top" width="527px" align="right">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                        <ContentTemplate>
                                        <asp:Panel id="pnlPageBtm" runat="server">
                                            <div class="slct_box">
                                                <div class="btn_left">
                                                    <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
                                                        runat="server" ImageUrl="../images/left_1.gif"></asp:ImageButton>
                                                </div>
                                                <div class="info_txt">
                                                	<asp:Label ID="lblPage2" runat="server">Page</asp:Label>  
                                                </div>
                                                <asp:TextBox ID="txtLoCurrentPage" runat="server" CssClass="option_box" AutoPostBack="True"
                                                    Visible="true" OnTextChanged="OnPaging_TextChange"></asp:TextBox>
                                                <div class="info_txt">
                                                    <asp:Label ID="lblcpage" runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <div class="btn_left_blue">
                                                    <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
                                                        runat="server" ImageUrl="../images/right.gif"></asp:ImageButton></div>
                                                <div class="cls">
                                                </div>
                                            </div>
										</asp:Panel>
										<Triggers>
										<asp:AsyncPostBackTrigger ControlID="cmdNext"  eventname="click"/>
										<asp:AsyncPostBackTrigger ControlID="cmdPrev"  eventname="click"/>

		                                </Triggers>
		 								</ContentTemplate>
										</asp:UpdatePanel>

                                            <!-- select box ends-->
                                            <asp:LinkButton ID="lnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lnkLast" Text="last" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>
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
                                <%--TILEAD--%>
                                <!-- #include file="include/ads/tileAd.htm" -->
                            </div>
                            </div>
                            <div class="adver_ryt_panel">
                              <div id="right">
                      
                            <%--BOOST HERE--%>

                            <!-- #include file="include/Boardhelp.aspx" -->
                             </div>
                            </div>
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
            <!-- #include file="include/footer.aspx" -->
        </div>
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

<%--AdRoll
<script type="text/javascript">
    adroll_adv_id = "2R4YZKILEVHVTDFGBJ62S4";
    adroll_pix_id = "BOYLAOCAHZFRHBZL7BLSVA";
    (function () {
        var oldonload = window.onload;
        window.onload = function () {
            __adroll_loaded = true;
            var scr = document.createElement("script");
            var host = (("https:" == document.location.protocol) ? "https://s.adroll.com" : "http://a.adroll.com");
            scr.setAttribute('async', 'true');
            scr.type = "text/javascript";
            scr.src = host + "/j/roundtrip.js";
            ((document.getElementsByTagName('head') || [null])[0] ||
    document.getElementsByTagName('script')[0].parentNode).appendChild(scr);
            if (oldonload) { oldonload() }
        };
    } ());
</script>
--%>
</body>
</html>
