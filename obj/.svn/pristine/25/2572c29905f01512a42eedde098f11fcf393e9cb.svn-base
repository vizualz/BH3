<%@ Page Codebehind="edit_item.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.edit_item" ValidateRequest="false"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Edit Post | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" src="include/js/bh.js"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css" type="text/css" media="all" />
	<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false&amp;libraries=places" type="text/javascript"></script>
    <script type="text/javascript">
        function initialize() {
            var input = document.getElementById('txtTown');
            var autocomplete = new google.maps.places.Autocomplete(input);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js" type="text/javascript"></script>
	<script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.1.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <script type="text/javascript">
          $(document).ready(function() {
            jQuery(function(){
	            jQuery('ul.sf-menu').superfish();
            });
          
    
	$(function() {
		var availableTags = ["Channel Islands", "Rusty", "Lost", "Bissell", "Linden", "FCD", "HIC", "Chemistry", "Xanadu", "3rd World Exotic", "Hynson", "SharpEye", "Becker", "Chili", "Firewire", "Kane Garden", "Santa Cruz", "WRV", "Quiet Flight", "Surf Prescriptions", "SurfTech", "Tequoph", "MR", "Weber", "Rickland", "West", "Resist", "KookBox"];
		$("#txtBrand").autocomplete({
			source: availableTags, minLength: 2
		});
	});
	
	$("#txtBrand").bind( "autocompleteclose", function(event, ui) {
        ctl = document.getElementById("txtBrand");
        ctl2 = document.getElementById("txtShaper");
        switch (ctl.value)
        {
        case "Channel Islands":
            ctl2.value = "Al Merrick";
            break;
        case "Rusty":
            ctl2.value = "Rusty Rusty Preisendorfer";
            break;
        case "Lost":
            ctl2.value = "Matt Biolos";
            break;
        case "FCD":
            ctl2.value = "Fletcher Chouinard";
            break;
        case "Surf Prescriptions":
            ctl2.value = "Doc Lausch";
            break;
        case "Linden":
            ctl2.value = "Gary Linden";
            break;
        case "Hynson":
            ctl2.value = "Mike Hynson";
            break;
        case "3rd World Exotic":
            ctl2.value = "Larry Mabile";
            break;
        case "Tequoph":
            ctl2.value = "Bill Johnson";
            break;                                                                      
                
        default:
            break;
        }
    });          
          
          
          });
    </script>
</head>
<body>
        <div id="main" align="center">
    <form class="header" id="Form1" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <div align="center">
                <div align="center" style="width:500px">
                <span class="midorange14b">
                    <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>&nbsp;&gt;&nbsp;
                    <asp:HyperLink runat="server" ID="lnkManage" NavigateUrl="post_manager.aspx" CssClass="orange_orange14u">MANAGE</asp:HyperLink>&nbsp;
                    <asp:Label ID="lblPageTitle" runat="server">&gt;&nbsp;EDIT</asp:Label>
                </span>
                </div>
                <asp:Panel ID="pnlAll" runat="server" Width="610" BorderWidth="1" BorderStyle="solid"
                    BorderColor="#FF9900">
                    <table cellspacing="0" cellpadding="0" width="610" bgcolor="FFFFCC" border="0">
                        <tr>
                            <td height="2" colspan="2" bgcolor="#FF9900">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="white16b" bgcolor="#FF9900" align="center">
                                Edit and click "update"<asp:Panel ID="pnlSold" runat="server" Visible="true">
                                    -&nbsp;or&nbsp;-<br />
                                    <asp:Button runat="server" ID="btnBoost" Text="Boost" Width="60" class="midgreen14"
                                        OnClick="btnBoost_Click" />&nbsp;
                                    <asp:Button runat="server" ID="btnSold" Text="Sold it!" OnClick="btnSold_Click" Width="60"
                                        class="dkorange14" /></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" bgcolor="#FF9900">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td colspan="2" height="10" bgcolor="#ffffcc" class="dkgrey10b" align="right">
                                <span class="midorange10b">*</span> required in<b>bold</b>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="20" colspan="2">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <asp:Panel ID="pnlLocation" runat="server">
                        <tr>
                            <td class="dkgrey14b" align="right" style="height: 22px; width: 128px;">
                                <span class="midorange10b">*</span> Location:&nbsp;</td>
                            <td align="left" style="height: 22px; width: 482px;" class="dkrgrey14">
                                <asp:DropDownList ID="cboRegion" runat="server" CssClass="dkrgrey14" Width="136px"
                                    TabIndex="1">
                                </asp:DropDownList>&nbsp;-&nbsp;<asp:TextBox id="txtTown" runat="server" clientidmode="Static" type="text" size="50" Width="150px" TabIndex="2" CssClass="dkrgrey14" placeholder="" autocomplete="on"  />
                                (city)
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td height="5" style="width: 128px">
                                <img src="images/s1x1.gif"></td>
                            <td style="width: 482px">
                            </td>
                        </tr>
                        <asp:Panel ID="pnlBoardType" runat="server">
                            <tr>
                                <td class="dkgrey14b" align="right" style="width: 128px">
                                    <span class="midorange10b">*</span> Board type:&nbsp;</td>
                                <td align="left" style="width: 482px">
                                    <asp:DropDownList ID="cboBoardType" runat="server" CssClass="dkrgrey14" Width="136px"
                                        TabIndex="3">
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:CheckBox ID="chkOther" runat="server" onclick="ToggleBT()" CssClass="dkgrey10b"
                                        Text="Other" TabIndex="4" Visible="false" />
                                    <asp:TextBox ID="txtOtherBoard" runat="server" CssClass="dkrgrey14" Width="100" TabIndex="5"
                                        Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                            <tr>
                                <!-- todo: make into dynamic label -->
                                <td class="dkgrey14b" align="right" style="width: 130px;">
                                    Item:&nbsp;</td>
                                <td align="left">
                                    <asp:TextBox ID="txtGearItem" Width="136px" CssClass="dkrgrey14" runat="server" Visible="true"></asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlBrand" runat="server">
                        <tr>
                            <td class="dkgrey14b" align="right" style="width: 128px">
                                <span class="midorange10b">*</span> Brand:&nbsp;</td>
                            <td align="left" style="width: 482px" class="dkgrey14b">
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="dkrgrey14" Width="136px" TabIndex="4"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="!" OnServerValidate="CheckBrand"
                                    CssClass="alert"></asp:CustomValidator>
                                    Shaper:&nbsp;<asp:TextBox ID="txtShaper" runat="server" CssClass="dkrgrey14" Width="136px" TabIndex="5"></asp:TextBox>
                                    </td>
                        </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlModel" runat="server" Visible="false">
                        <tr>
                            <td class="dkgrey14b" align="right" style="width: 128px">
                                <span class="midorange10b">*</span>Model:&nbsp;</td>
                            <td align="left" style="width: 482px">
                                <asp:TextBox ID="txtModel" runat="server" CssClass="dkrgrey14" Width="136px" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        </asp:Panel>                        
                        <tr>
                            <td colspan="2"><div><img src="images/s1x1.gif" height="10" alt="spacer"/></div></td>
                        </tr>
                        <asp:Panel ID="pnlHeight" runat="server" Visible="false">
                            <tr>
                                <td class="dkgrey14" align="right">
                                    Height:&nbsp;</td>
                                <td class="dkgrey14" align="left" style="width: 482px">
                                    <asp:TextBox ID="txtHtFt" runat="server" CssClass="dkrgrey14" Width="32px" TabIndex="6"></asp:TextBox>
                                    <asp:Label ID="lblFtHt" runat="server">ft</asp:Label>&nbsp;
                                    <asp:TextBox ID="txtHtIn" runat="server" CssClass="dkrgrey14" Width="24px" TabIndex="7"></asp:TextBox>
                                    <asp:Label ID="lblFtIn" runat="server">in</asp:Label>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="!" Font-Bold="True"
                                        OnServerValidate="CheckHeight"></asp:CustomValidator></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlSurfOnly" runat="server" Visible="false">
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey14" align="right">
                                    Width:&nbsp;</td>
                                <td align="left" class="dkgrey14" style="width: 482px">
                                    <asp:TextBox ID="txtWidth" runat="server" CssClass="dkrgrey14" Width="24px" TabIndex="8"></asp:TextBox>
                                    and&nbsp;<asp:TextBox ID="txtWidthNum" runat="server" CssClass="dkrgrey14" Width="24px"
                                        TabIndex="9"></asp:TextBox>
                                    /
                                    <asp:TextBox ID="txtWidthDNum" runat="server" Width="24px" CssClass="dkrgrey14" TabIndex="10"></asp:TextBox>&nbsp;in
                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="!" Font-Bold="True"
                                        OnServerValidate="CheckWidth"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey14" align="right" style="height: 22px">
                                    Thickness:&nbsp;</td>
                                <td align="left" class="dkgrey14" style="width: 482px; height: 22px;">
                                    <asp:TextBox ID="txtThick" runat="server" CssClass="dkrgrey14" Width="24px" TabIndex="11"></asp:TextBox>
                                    and&nbsp;<asp:TextBox ID="txtThickNum" runat="server" CssClass="dkrgrey14" Width="24px"
                                        TabIndex="12"></asp:TextBox>
                                    /
                                    <asp:TextBox ID="txtThickDNum" runat="server" CssClass="dkrgrey14" Width="24px" TabIndex="13"></asp:TextBox>&nbsp;in
                                    <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="!" Font-Bold="True"
                                        OnServerValidate="CheckThickness"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey14" align="right">
                                    Fins:&nbsp;</td>
                                <td align="left" style="width: 482px">
                                    <asp:DropDownList ID="cboFins" CssClass="dkrgrey14" runat="server" TabIndex="15">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey14" align="right">
                                    Tail:&nbsp;</td>
                                <td align="left" style="width: 482px">
                                    <asp:DropDownList ID="cboTailType" runat="server" CssClass="dkrgrey14" Width="136px"
                                        TabIndex="5">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif"></td>
                                <td style="width: 482px">
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlGenDims" runat="server" Visible="false">
                            <tr>
                                <td valign="top" align="right" width="130">
                                    <asp:Label ID="lblGenDims" CssClass="dkgrey14" runat="server">Dimensions:&nbsp;</asp:Label>&nbsp;
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtGenDims" CssClass="dkgrey10b" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                        </asp:Panel>
<%--                        <asp:Panel ID="pnlShip" runat="server">
                            <tr>
                                <td height="1" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td class="dkgrey14" align="right" valign="bottom">
                                    Shipping:</td>
                                <td class="dkgrey14">
                                    &nbsp;
                                    <asp:RadioButtonList ID="rdoShip" CssClass="dkgrey14" runat="server" RepeatLayout="Table"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Text="No">No</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Yes">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </asp:Panel>--%>
                        <tr>
                            <td colspan="2"><div><img src="images/s1x1.gif" height="10" alt="spacer"/></div></td>
                        </tr>                        
                        <tr>
                            <td class="dkgrey14b" align="right" style="width: 128px">
                                <span class="midorange10b">*</span> Price:&nbsp;</td>
                            <td class="dkgrey10b" align="left" style="width: 482px" colspan="2">
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="dkrgrey14" Width="64px" TabIndex="15"></asp:TextBox>&nbsp;
                                $ (USD)
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="!" Font-Bold="True"
                                    OnServerValidate="CheckPrice"></asp:CustomValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                            
                        <%--<asp:Panel ID="pnlShip" runat="server" style="float:right">--%>
                        <asp:Label ID="lblShipping" runat="server" CssClass="dkgrey14">Shipping:</asp:Label>
                                    
                                    <asp:RadioButtonList ID="rdoShip" CssClass="dkgrey14" runat="server" RepeatLayout="Flow"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Text="No">No</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Yes">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                        <%--</asp:Panel>  --%>                                  
                            
                            </td>
                        </tr>
                        <tr>
                            <td height="10" style="width: 128px">
                                <img src="images/s1x1.gif"></td>
                            <td style="width: 482px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" valign="top" align="right" style="width: 128px">
                                The Deal:&nbsp;</td>
                            <td align="left" style="width: 482px">
                                <asp:TextBox ID="txtDetails" runat="server" CssClass="dkrgrey14" Height="130px" Width="352px"
                                    Rows="10" MaxLength="599" onkeydown="count()" TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                                <span class="dkgrey10b"><b>(600 max; no HTML)</b>&nbsp;&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" style="width: 128px">
                                <img src="images/s1x1.gif"></td>
                            <td style="width: 482px">
                            </td>
                        </tr>
                            <asp:Panel ID="pnlVideo" runat="server" Visible="false">
                            <tr>
                                <td class="dkgrey14" align="right" style="width: 128px">
                                    Video Clip:
                                </td>
                                <td>
                                        <asp:TextBox ID="txtVideo" runat="server" CssClass="dkgrey10"
                                            Height="60px" Width="352px" MaxLength="599" Rows="5" TextMode="MultiLine" TabIndex="70"></asp:TextBox>                            
                                </td>
                            </tr>
                            <tr>
                                <td height="10" colspan="2">
                                    <img src="images/s1x1.gif">
                                </td>
                            </tr>                            
                            </asp:Panel>                        
                        
                        
                        <tr>
                            <td valign="top" align="right" class="dkgrey14" style="height: 43px; width: 128px;">
                                Add/edit photos:&nbsp;</td>
                            <td align="left" style="width: 482px; height: 43px;" bgcolor="#FF9900">
                                <asp:Button ID="btnShowPnl" class="dkorange20b" runat="server" Text="Edit Images..."
                                    Visible="False" TabIndex="16" OnClick="btnShowPnl_Click"></asp:Button>
                                <span class="white10b">&nbsp;<span class="black12">2MB</span>&nbsp;max per JPG or GIF</span></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                            </td>
                            <td style="width: 482px">
                                <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="False"
                                    BorderColor="#ff9900" BorderStyle="Solid" BorderWidth="0" BackColor="#ff9900">
                                    <table style="z-index: 115; width: 288px; height: 52px" align="left" bgcolor="#FFFFFF"
                                        bordercolor="#ff9900" border="0">
                                        <tr>
                                            <td style="width: 120px">
                                                &nbsp;
                                                <asp:Image ID="img1" runat="server" Height="100px" Width="100px"></asp:Image>
                                            </td>
                                            <td valign="bottom">
                                                <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('1')"
                                                    TabIndex="17">
                                                    <asp:ListItem Value="Keep" Selected="True" />
                                                    <asp:ListItem Value="Delete" />
                                                    <asp:ListItem Value="Change" />
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td style="width: 120px">
                                                &nbsp;
                                                <asp:Image ID="img2" runat="server" Height="100px" Width="100px"></asp:Image>
                                            </td>
                                            <td valign="bottom" style="width: 85px">
                                                <asp:RadioButtonList ID="rdoImgMgr2" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('2')"
                                                    TabIndex="18">
                                                    <asp:ListItem Value="Keep" Selected="True" />
                                                    <asp:ListItem Value="Delete" />
                                                    <asp:ListItem Value="Change" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <input class="dkgrey10b" id="File1" type="file" name="File1" runat="server">
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="!" Font-Bold="True"
                                                    OnServerValidate="CheckFileType"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td colspan="2">
                                                <input class="dkgrey10b" id="File2" type="file" name="File2" runat="server">
                                                <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True"
                                                    OnServerValidate="CheckFileType"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 120px">
                                                &nbsp;
                                                <asp:Image ID="img3" runat="server" Height="100px" Width="100px"></asp:Image>
                                            </td>
                                            <td valign="bottom">
                                                <asp:RadioButtonList ID="rdoImgMgr3" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('3')"
                                                    TabIndex="18">
                                                    <asp:ListItem Value="Keep" Selected="True" />
                                                    <asp:ListItem Value="Delete" />
                                                    <asp:ListItem Value="Change" />
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td style="width: 120px">
                                                &nbsp;
                                                <asp:Image ID="img4" runat="server" Height="100px" Width="100px"></asp:Image>
                                            </td>
                                            <td valign="bottom" style="width: 85px">
                                                <asp:RadioButtonList ID="rdoImgMgr4" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('4')"
                                                    TabIndex="19">
                                                    <asp:ListItem Value="Keep" Selected="True" />
                                                    <asp:ListItem Value="Delete" />
                                                    <asp:ListItem Value="Change" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <input class="dkgrey10b" id="File3" type="file" name="File1" runat="server">
                                                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="!" Font-Bold="True"
                                                    OnServerValidate="CheckFileType"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td colspan="2">
                                                <input class="dkgrey10b" id="File4" type="file" name="File2" runat="server">
                                                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="!" Font-Bold="True"
                                                    OnServerValidate="CheckFileType"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" style="width: 128px">
                                <img src="images/s1x1.gif"></td>
                            <td style="width: 482px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                            </td>
                            <td style="width: 482px">
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="Cancel" TabIndex="21"  />
                                    <asp:Button ID="btnFinish" runat="server" CssClass="btnStep" Text="Save" TabIndex="22"  />                                    
                                    
                                    </td>
                        </tr>
                        <tr>
                            <td height="10" style="width: 128px">
                                <img src="images/s1x1.gif"></td>
                            <td style="width: 482px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                            </td>
                            <td style="width: 482px">
                                <asp:Label ID="lblStatus" runat="server" CssClass="header"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                            </td>
                            <td style="width: 482px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                            </td>
                            <td>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <asp:HiddenField ID="HiddenField4" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

        <asp:Label ID="lbl2" runat="server" CssClass="header"></asp:Label>
        <asp:HiddenField ID="hdnActCode" runat="server" />
        <asp:HiddenField ID="hdnEntryId" runat="server" />
        <asp:HiddenField ID="hdnPrice" runat="server" />
        <asp:HiddenField ID="hdnEntryType" runat="server" />
    <div id="push">
    </div>        
    </form>
        </div>
        <br />    
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
