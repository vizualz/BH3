<%@ Page Codebehind="post_item.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false"
    ValidateRequest="false" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.post_item" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Post Item - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="style/popup.css" type="text/css" rel="stylesheet" />
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

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    //$('img.Tips').cluetip({splitTitle: '|'});
    $('img.Tips').cluetip({width:300});
    
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
            ctl2.value = "Rusty Preisendorfer";
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
        
    //hide button on wanted ad
    var ctl1 = document.getElementById('hdnAdType');
    if (ctl1.value == "2")
    {
        var btn = document.getElementById('btnShowImgPanel');
        btn.style.display = 'none';
    }
    
    
    var ctl2 = document.getElementById('File4');
    if (ctl2 != null)
    {
        ctl2.style.display = 'none';
    }          
        
        });
    </script>

    <script language="JavaScript">
       function FreezeScreen(msg) {
          scroll(0,0);
          var outerPane = document.getElementById('FreezePane');
          var innerPane = document.getElementById('InnerFreezePane');
          if (outerPane) outerPane.className = 'FreezePaneOn';
          if (innerPane) innerPane.innerHTML += msg;
       }
    </script>

    <script type="text/javascript">
    var newWin = null;
    function openIt() {
      newWin = window.open('http://www.boardhunt.com/login.aspx');
    }
    function closeThis(){
      window.open('Close.htm', '_self');
    }
    function doIt() {
      openIt();
      setTimeout("closeThis();",1000);
    }
    </script>

</head>
<body>
            <div id="main" align="center">
                <form class="header" id="Form1" runat="server">
                    <!-- #include file="include/Header.aspx" -->
                    <div align="center" style="width: 500px; margin: 0px auto;">
                        <span class="midorange14b">
                            <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="post.aspx" CssClass="orange_orange14u">Step 1 of 3: General Info</asp:HyperLink>
                            &gt; Step 2 of 3: 
                            <asp:Label runat="server" ID="lblCat"></asp:Label> Details
                        </span><br />
                    </div>
                    <asp:Panel ID="pnlError" runat="server" Visible="false" style="width: 400px; margin: 0px auto; border-style:dashed; border-width:1px; border-color:red;">
                        <div align="center" style="background-color:#ffE4E1; margin: 0px auto;">
                                    <img src="images/red_err_excl.png" border="0" alt="" style=" margin-top:1px" align="middle" />&nbsp;
                                    <asp:Label runat="server" ID="lblErrMsg" CssClass="black16b" Visible="false">
                                    &nbsp;Hated! Something broke. Make sure EACH image is under 1MB and try 
                                    again. &nbsp;<br />                                    
                                    </asp:Label>
                                    <asp:HyperLink ID="hypClose" onClick="javascript:doIt()" runat="server" CssClass="red_black12">Click here to close this 
                                    browser and try again.</asp:HyperLink>
                                    &nbsp;
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlItem" runat="server" BorderColor="#CCCCCC" BorderWidth="0px" BorderStyle="solid" style="margin: 0px auto;">
                        <table align="center" cellspacing="0" cellpadding="0" width="820" border="0" bgcolor="#F0F0F0" style="margin: 0px auto;">
                            <tr>
                                <td height="2" colspan="2" bgcolor="#CCCCCC">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td colspan="2" class="white16" align="center" style="height: 30px; background-color: #CCCCCC">
                                    No need to repost on Boardhunt with our search power.
                                    <asp:Label ID="lblInstructions" runat="server" CssClass="white16" Visible="false">&nbsp;&nbsp;</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" colspan="2" style="height: 5px">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td bgcolor="#cccccc" colspan="2" style="height: 20px">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td bgcolor="#cccccc" align="left" colspan="2" height="20" class="black16b">
                                    &nbsp;&nbsp;This section is required.</td>
                                 
                            </tr>
                            <tr>
                                  <td bgcolor="#cccccc" height="10" colspan="2">
                                      <img src="images/s1x1.gif"></td>
                                </tr>

                            <asp:Panel ID="pnlModel" runat="server" Visible="false">
                                <tr>
                                    <td bgcolor="#cccccc" class="dkgrey16b" align="right" style="width: 150px">
                                        <span class="midorange10b">*</span>Model name:&nbsp;</td>
                                    <td bgcolor="#cccccc" align="left">
                                        <asp:TextBox ID="txtModel" runat="server" Width="132px" CssClass="dkgrey16" ToolTip="Type in the model"
                                            TabIndex="15"></asp:TextBox>
                                    </td>
                                </tr>
                                
                            </asp:Panel>
                            <asp:Panel ID="pnlBoardType" runat="server">
                                <tr>
                                    <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">
                                        Board type:&nbsp;</td>
                                    <td bgcolor="#cccccc" align="left">
                                        <asp:DropDownList ID="cboBoardType" runat="server" CssClass="dkrgrey16" Width="136px"
                                            TabIndex="1">
                                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkOther" Text="&nbsp;Or other" runat="server" onClick="ToggleBT();"
                                            CssClass="dkrgrey16" Checked="false" Visible="false" TabIndex="2" />
                                        <asp:TextBox ID="txtOtherBoard" runat="server" Width="100px" Visible="false" CssClass="dkgrey16"
                                            ToolTip="Type in your board type" TabIndex="3"></asp:TextBox>
                                        <img src="images/help.gif" class="Tips" align="middle" id="imgBTHelp" rel="help/help.aspx?val=1"
                                            title="Board Types" />
                                        <%--<asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="images/help.gif" CausesValidation="false"
                                            ImageAlign="AbsMiddle" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#cccccc" height="5" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>                                
                            </asp:Panel>
                            <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                                <tr>
                                    <td bgcolor="#cccccc" align="right" style="width: 150px;">
                                        <asp:Label CssClass="dkgrey16" ID="lblItem" runat="server">
                                    Item:&nbsp;
                                </asp:Label>
                                    </td>
                                    <td bgcolor="#cccccc" align="left">
                                        <asp:TextBox ID="txtGearItem" CssClass="dkgrey16" Width="136px" runat="server" Visible="true"
                                            TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#cccccc" colspan="2">
                                        <img height="5" src="images/s1x1.gif" /></td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlBrand" runat="server">
                                





                            </asp:Panel>
                            <asp:Panel ID="pnlHeight" runat="server">
                                <tr>
                                    <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">
                                         Height:&nbsp;</td>
                                    <td bgcolor="#cccccc" class="dkgrey16" align="left">
                                        <asp:TextBox ID="txtHtFt" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="2"
                                            TabIndex="5"></asp:TextBox>&nbsp;<asp:Label ID="lblHtFt" runat="server">ft</asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="txtHtIn" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="2"
                                            TabIndex="6"></asp:TextBox>&nbsp;
                                        <asp:Label ID="lblHtIn" runat="server">in</asp:Label>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="errorLabel" OnServerValidate="CheckHeight"
                                            ErrorMessage="!"></asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#cccccc" height="5" colspan="2">
                                        <img src="images/s1x1.gif" /></td>
                                </tr>
                           </asp:Panel>
                            <tr>

                                <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">
                                    Price:&nbsp;</td>
                                <td bgcolor="#cccccc" align="left">
                                    <asp:TextBox style="margin-bottom:2px;" ID="txtPrice" runat="server" CssClass="dkrgrey16" Width="64px" MaxLength="8"
                                        TabIndex="8"></asp:TextBox>&nbsp;<asp:Label ID="lblPriceDir" runat="server" CssClass="white14">
                                         ($ USD) You can edit this later.
                                        </asp:Label>
                                           
                                    <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="errorLabel" OnServerValidate="CheckPrice"
                                        ErrorMessage="!"></asp:CustomValidator>&nbsp;</td>
                            </tr>
                            <asp:Panel ID="pnlSurfOnly" runat="server">
                                <tr>
                                    <td bgcolor="#cccccc" height="20" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                <td align="left" colspan="2" height="20" class="black16b">
                                    &nbsp;&nbsp;This section is optional, but highly recommended to enable all search features.</td>
                                
                                </tr>
                                <tr>
                                    <td height="10" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="dkgrey16" align="right" style="width:150px">
                                        <asp:Label ID="lblBrand" runat="server">Brand:</asp:Label>&nbsp;
                                    </td>
                                    <td class="dkgrey16" align="left">
                                        <asp:TextBox ID="txtBrand" runat="server" CssClass="dkrgrey16" Width="136px" TabIndex="10"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblShaper" CssClass="dkgrey16" runat="server">Shaper:</asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="txtShaper" runat="server" CssClass="dkrgrey16" Width="136px" TabIndex="11"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="errorLabel" OnServerValidate="CheckBrand"
                                            ErrorMessage="!"></asp:CustomValidator>
                                            &nbsp;
                                            <asp:Label ID="lblModelPost" runat="server" CssClass="dkgrey16">Model: </asp:Label>
                                            <asp:TextBox ID="txtModelPost" runat="server" CssClass="dkrgrey16" Width="136px" TabIndex="12"></asp:TextBox>
                                            </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>



                                <tr>
                                    <td class="dkgrey16" align="right" style="width: 150px">
                                        Width:&nbsp;</td>
                                    <td class="dkgrey16" align="left">
                                        <asp:TextBox ID="txtWidth" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="2"
                                            TabIndex="15"></asp:TextBox>&nbsp;and&nbsp;
                                        <asp:TextBox ID="txtWidthNum" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="1"
                                            TabIndex="16"></asp:TextBox>&nbsp;/
                                        <asp:TextBox ID="txtWidthDNum" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="2"
                                            TabIndex="17"></asp:TextBox>&nbsp;in&nbsp;<span class="midorange14">&nbsp;&nbsp;(ex: 18 and 1/4)
                                        </span>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="errorLabel" OnServerValidate="CheckWidth"
                                            ErrorMessage="!"></asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2" style="width: 132px">
                                        <img src="images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgrey16" align="right" style="width: 150px">
                                        Thickness:&nbsp;</td>
                                    <td class="dkgrey16" align="left">
                                        <asp:TextBox ID="txtThick" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="1"
                                            TabIndex="18"></asp:TextBox>&nbsp;and&nbsp;
                                        <asp:TextBox ID="txtThickNum" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="1"
                                            TabIndex="19"></asp:TextBox>&nbsp;/
                                        <asp:TextBox ID="txtThickDNum" runat="server" CssClass="dkrgrey16" Width="24px" MaxLength="2"
                                            TabIndex="20"></asp:TextBox>&nbsp;in&nbsp;<span class="midorange14">&nbsp;&nbsp;(ex: 2 and 1/4)
                                       </span>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="errorLabel" OnServerValidate="CheckThickness"
                                            ErrorMessage="!"></asp:CustomValidator>&nbsp;<span class="help"></span></td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="dkgrey16" valign="top" align="right" style="width: 150px">
                                        <asp:Label ID="lblFins" runat="server">Fins:&nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cboFins" CssClass="dkrgrey16" runat="server" TabIndex="22">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="dkgrey16" align="right" style="width: 150px">
                                        <asp:Label ID="lblTail" runat="server">Tail:&nbsp;</asp:Label></td>
                                    <td align="left">
                                        <asp:DropDownList ID="cboTailType" runat="server" CssClass="dkrgrey16" Width="136px"
                                            TabIndex="23">
                                        </asp:DropDownList>
                                        <img src="images/help.gif" class="Tips" align="middle" id="imgFinHelp" rel="help/help.aspx?val=4"
                                            title="Tail Types" />
                                        <%--<asp:ImageButton ID="imgBtnFinHelp" CausesValidation="false" runat="server" ImageUrl="images/help.gif"
                                            ImageAlign="AbsMiddle" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="5">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlGenDims" runat="server">
                                <tr>
                                    <td valign="top" align="right" style="width: 150px">
                                        <asp:Label ID="lblGenDims" CssClass="dkgrey16" runat="server">Dimensions:</asp:Label>
                                        &nbsp;
                                    </td>
                                    <td valign="top" align="left">
                                        <asp:TextBox ID="txtGenDims" CssClass="dkrgrey16" runat="server" TabIndex="24" Width="132"></asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                           

                            <tr>
                                <td height="5" colspan="2">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                            <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                                <tr>
                                    <td valign="top" align="right" style="width: 150px">
                                        <asp:Label ID="lblWeb" CssClass="dkgrey16b" runat="server">Web:</asp:Label>&nbsp;
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtWebURL" CssClass="dkrgrey16" runat="server" TabIndex="25"></asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="dkgrey16" valign="top" align="right" style="width: 150px; border-right: solid 5px transparent;">
                                    The deal:&nbsp;<br />
   
                                </td>
                                <td align="left" valign="top" style="width: 482px" class="midorange16">
                                    <asp:TextBox ID="txtDetails" onkeydown="CountChars()" runat="server" CssClass="dkrgrey12"
                                        Height="135px" Width="352px" MaxLength="599" Rows="10" 
                                        TextMode="MultiLine" TabIndex="30"></asp:TextBox>
                                    <asp:Label ID="lblTxtCount" runat="server">600</asp:Label>
                                    <br />
                                    
                                    <asp:Label CssClass="midorange14" ID="lblDetailTxt" runat="server">
                                        How does it ride?&nbsp;<br />
                                        Describe any dings.&nbsp;<br />
                                        Ideal height and weight?&nbsp;<br />
                                        Where should it be ridden?&nbsp;<br />
                                        How much did you pay?&nbsp;<br />
                                        What is it made of?&nbsp;<br />
                                        Why selling?&nbsp;<br />
                                    </asp:Label>
                                    
                                    
                                </td>
                            </tr>
                            <tr>
                                <td height="40" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <asp:Panel ID="pnlVideo" runat="server" Visible="false" >
                                <tr>
                                    <td class="dkgrey16" align="right" style="width: 150px" >
                                        Video Clip:&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVideo" runat="server" CssClass="dkgrey10" Height="60px" Width="352px"
                                            MaxLength="599" Rows="5" TextMode="MultiLine" TabIndex="32" 
                                            ></asp:TextBox>
                                        <span class="midorange10b" ><b>Cut and paste a URL link from YouTube</b>&nbsp;&nbsp;</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="2" >
                                        <img src="images/s1x1.gif">
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td bgcolor="#CCCCCC" align="right" style="height: 30px; width: 150px;" >
                                </td>
                                <td align="left" style="height: 30px; width: 482px;" bgcolor="#CCCCCC">
                                       <tr>
                                        <td bgcolor="#CCCCCC" align="left" colspan="2" height="20" class="black16b">
                                            &nbsp;&nbsp;Add images, or buyers may skip over your post.</td>
                                 
                                        </tr>
                                        <tr>
                                            <td bgcolor="#CCCCCC" colspan="2">
                                                <%--<input type="button" valign="center" id="btnShowImgPanel" class="dkorange20b" value="Add Images..." onclick="toggleImgPanel('pnlAddImages', 'btnShowImgPanel')" />--%>
                                             
                                                <asp:Label CssClass="white14" ID="lblImgTip" runat="server" Width="100%"> 
                                                  &nbsp;&nbsp;1MB limit per file, GIF or JPG only. If post breaks, it's probably too big.</asp:Label>
                                            </td>
                                        </tr>
                                    
                                
                            
                            <tr>
                                <td bgcolor="#CCCCCC" height="20" colspan="2" >
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr >
                                <td bgcolor="#CCCCCC">
                                    &nbsp;
                                </td>
                                <td bgcolor="#CCCCCC" style="width: 482px" align="left">
                                    <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="True"
                                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1" 
                                        BackColor="#CCCCCC" >
                                        <table style="z-index: 115; width: 288px; height: 52px" align="left" bgcolor="#FFFFFF"
                                            bordercolor="#CCCCCC" border="0" >
                                            <tr >
                                                <td style="width: 120px">
                                                    &nbsp;
                                                    <asp:Image ID="img1" runat="server" Height="100px" Width="100px"></asp:Image>
                                                </td>
                                                <td valign="bottom">
                                                    <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('1')"
                                                        TabIndex="35">
                                                        <asp:ListItem Value="Keep" Selected="True" />
                                                        <asp:ListItem Value="Delete"  />
                                                        <asp:ListItem Value="Change"  />
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 120px">
                                                    &nbsp;
                                                    <asp:Image ID="img2" runat="server" Height="100px" Width="100px"></asp:Image>
                                                </td>
                                                <td valign="bottom" style="width: 85px">
                                                    <asp:RadioButtonList ID="rdoImgMgr2" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('2')"
                                                        TabIndex="36">
                                                        <asp:ListItem Value="Keep" Selected="True" />
                                                        <asp:ListItem Value="Delete"  />
                                                        <asp:ListItem Value="Change"  />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <input class="dkrgrey12" id="File1" type="file" name="File1" runat="server" 
                                                        onchange="swapImg('1')" >
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    <input class="dkrgrey12" id="File2" type="file" name="File2" runat="server" 
                                                        onchange="swapImg('2')" >
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120px">
                                                    &nbsp;
                                                    <asp:Image ID="img3" runat="server" Height="100px" Width="100px" 
                                                        ></asp:Image>
                                                </td>
                                                <td valign="bottom">
                                                    <asp:RadioButtonList ID="rdoImgMgr3" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('3')"
                                                        TabIndex="37">
                                                        <asp:ListItem Value="Keep" Selected="True"  />
                                                        <asp:ListItem Value="Delete" />
                                                        <asp:ListItem Value="Change"/>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 120px" >
                                                    &nbsp;
                                                    <asp:Image ID="img4" runat="server" Height="100px" Width="100px"></asp:Image>
                                                </td>
                                                <td valign="bottom" style="width: 85px">
                                                    <asp:RadioButtonList ID="rdoImgMgr4" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('4')"
                                                        TabIndex="38" >
                                                        <asp:ListItem Value="Keep" Selected="True"/>
                                                        <asp:ListItem Value="Delete"/>
                                                        <asp:ListItem Value="Change" />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" >
                                                    <input class="dkrgrey12" id="File3" type="file" name="File1" runat="server" 
                                                        onchange="swapImg('3')">
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2" >
                                                    <input class="dkrgrey12" id="File4" type="file" name="File2" runat="server" 
                                                        onchange="swapImg('4')">
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </asp:Panel>
                                    <%--<asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True" OnServerValidate="CheckFileType"></asp:CustomValidator>--%>
                                    <asp:Label runat="server" CssClass="error" ID="lblError" ForeColor="Red" 
                                        ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                 <td bgcolor="#CCCCCC" height="10" colspan="2" >
                                    <img src="images/s1x1.gif">
                                   </td>
                                </tr>
                            <tr>
                                <td colspan="2" style="height: 20px">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td style="width: 150px">
                                    &nbsp;</td>
                                <td nowrap align="left" style="width: 482px">
                                    <asp:Button ID="btnBack" runat="server" Width="75px" Height="35px" CssClass="btnStepBack" 
                                        Text="< Back" TabIndex="40" />
                                    <asp:Button ID="btnNext" runat="server" Width="75px" Height="35px" CssClass="btnStep" 
                                        Text="Next >" TabIndex="42" 
                                        
                                        OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('btnNext','lbl2');javascript:ShowElement('btnNextFake','btnNext');javascript:DisableElement('btnNextFake');javascript:DisableElement('btnBack');" />
                                    <asp:Button ID="btnNextFake" runat="server" CssClass="btnNext" Text="Next" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="images/back.gif" TabIndex="80"
                                        ToolTip="Back" Visible="false"></asp:ImageButton>
                                    <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="images/next.gif" TabIndex="76"
                                        OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('imgContinue','lbl2');javascript:ShowElement('imgContinueFake');javascript:DisableElement('imgContinueFake');javascript:DisableElement('imgBack');"
                                        ToolTip="Next" Visible="false"></asp:ImageButton>&nbsp;
                                    <asp:ImageButton ID="imgContinueFake" runat="server" ImageUrl="images/NextOff.gif"
                                        TabIndex="77" ToolTip="Next" Visible="false"></asp:ImageButton>&nbsp;
                                    <asp:Label ID="lbl2" runat="server" CssClass="black12"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px; height: 15px">
                                    <img src="images/s1x1.gif"></td>
                                <td height="15px" align="left" style="width: 482px; height: 15px">
                                    <asp:Label ID="lblTip" runat="server" CssClass="midorange10b"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblStatus" runat="server" CssClass="black12"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                    <asp:HiddenField ID="HiddenField4" runat="server" />
                                </td>
                            </tr>
                        </table>
                                                        
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div align="center" id="FreezePane" class="FreezePaneOff">
                        <div id="InnerFreezePane" class="InnerFreezePane">
                            <img src="images/wait.gif" alt="Please wait" />
                        </div>
                    </div>
                    <br />
                    <asp:HiddenField ID="hdnAdType" runat="server" />
                    <div id="push">
                    </div>
                </form>
            </div>
                    <div align="center">
                        <!-- #include file="include/footer.aspx" -->
                    </div>
</body>
</html>
