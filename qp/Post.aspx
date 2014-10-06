<%@ Page Codebehind="Post.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false"
    ValidateRequest="false" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.qp.Post" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Post - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../style/popup.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css"
        type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css"
        type="text/css" media="all" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js"
        type="text/javascript"></script>

    <script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.1.js"
        type="text/javascript"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />

    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>

    <script src="../include/js/jquery.tipsy.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />
    <link rel="stylesheet" href="../style/tipsy.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
 
     //$('#<%=txtDate.ClientID %>').datepicker(); 
     $("#txtDate").datepicker();
     $.datepicker.setDefaults({
     dateFormat: 'mm/dd/yy'
     });
     
     //.datepicker( "setDate" , date )
                
    //$('#txtCode').tipsy({gravity: 'w'});

    $('span.Tips').cluetip({splitTitle: '|'});
    $('img.Tips').cluetip({width:300});
    $('a.basic').cluetip({width:330,dropShadow:       true});
   
    //hide button on wanted ad
    var ctl1 = document.getElementById('hdnAdType');
    if (ctl1.value == "2")
    {
        var btn = document.getElementById('btnShowImgPanel');
        btn.style.display = 'none';
    }

        });
    </script>

    <script type="text/javascript">
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
      newWin = window.open('http://www.malzook.com/login.aspx');
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
    <div align="center">
        <div align="center">
            <div id="main" align="center">
                <form class="header" id="Form1" runat="server">
                    <!-- #include file="../include/Header.aspx" -->
                    <br />
                    <asp:Panel ID="pnlError" runat="server" Visible="false" Width="500px">
                        <asp:Label ID="lblError" runat="server" CssClass="black12">
                                    &nbsp;Hated! Something broke. Resize your pic so the file is under 1MB and try again.
                                    &nbsp;<br />
                                    &nbsp;<a href="javascript:doIt()" class="red_black12">Click here to close this browser
                                        and try again.</a>                    
                        </asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="pnlItem" runat="server" BorderColor="#CCCCCC" BorderWidth="0px" BorderStyle="solid">
                        <table align="center" cellspacing="1" cellpadding="1" width="820" border="0" bgcolor="#F0F0F0">
                            <tr>
                                <td colspan="2" class="white20b" align="center" style="height: 30px; background-color: #CCCCCC">
                                    <asp:Label ID="lblInstructions" runat="server" CssClass="white20b">
                                     <span class="dkrgrey20b">Step 1</span> of 3:&nbsp;Enter coupon info and click 'Next'
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 5px">
                                    <img src="../images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td bgcolor="#F0F0F0" colspan="2" style="height: 5px">
                                    <img src="../images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td height="5" bgcolor="#F0F0F0" class="dkgrey10b" align="left">
                                    &nbsp;&nbsp;&nbsp;Required in <span class="dkgrey14b">bold</span></td>
                                    <td align="right">&nbsp;&nbsp;<a class="basic" href="test.htm" rel="test.htm">See sample</a>
                                    &nbsp;
                                    </td>
                            </tr>
                            <!-- cat, title, details, code,IMG -->
                            <tr>
                                <td class="dkgrey16b" align="right" style="width: 220px">
                                    Category:&nbsp;</td>
                                <td align="left">
                                    <asp:DropDownList ID="cboCategory" runat="server" Width="132px" CssClass="dkgrey16"
                                        TabIndex="1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey16b" align="right" style="width: 220px">
                                    Title:&nbsp;</td>
                                <td align="left">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="352px" CssClass="dkgrey16" ToolTip="Type in the model"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="dkgrey16b" valign="top" align="right" style="width: 220px; border-right: solid 5px transparent;">
                                    Description:&nbsp;
                                </td>
                                <td align="left" valign="top" style="width: 482px">
                                    <asp:TextBox ID="txtDetails" onkeydown="javascript:CharCountAndDisplay(this.form.txtDetails,100,'lblTxtCount')"
                                        runat="server" CssClass="dkgrey16" Height="135px" Width="352px" MaxLength="100"
                                        Rows="10" TextMode="MultiLine" TabIndex="3"></asp:TextBox>
                                    <span>
                                        <asp:Label ID="lblTxtCount" CssClass="midorange20" runat="server">100</asp:Label>&nbsp;<span
                                            class="dkgrey16">left</span></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 220px">
                                    <asp:Label ID="Label1" CssClass="dkgrey16" runat="server">Expiration Date:</asp:Label>&nbsp;
                                </td>
                                <td class="dkrgrey16">
                                    <div>
                                        <asp:TextBox ID="txtDate" CssClass="dkrgrey16" runat="server" Width="150" TabIndex="4"></asp:TextBox></div>
                                </td>
                            </tr>                            
                            <tr>
                                <td valign="top" align="right" style="width: 220px">
                                    <asp:Label ID="lblGenDims" CssClass="dkgrey16" runat="server">Coupon Code:</asp:Label>&nbsp;
                                </td>
                                <td valign="top" align="left">
                                    <asp:TextBox ID="txtCode" Width="150" CssClass="dkrgrey16" runat="server" TabIndex="5"
                                        Title="used for tracking and authenticity" MaxLength="10"></asp:TextBox>
                                    &nbsp;<span id="sptip" class="Tips" title="Coupon Code| Create a customer code to track your sales. Customers will provide this code at the point of sale.">[
                                        i ]</span>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 220px; height: 10px;">
                                    <img src="../images/s1x1.gif"></td>
                                <td class="dkgrey10b" style="width: 220px; height: 10px;">(ex: "sale2011") Up to 8 char max
                                  <img src="../images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td height="15" style="width: 220px">
                                         <img src="../images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 30px; width: 220px;">
                                </td>
                                <td align="left" style="height: 30px; width: 482px;" bgcolor="#CCCCCC">
                                    <table cellpadding="0" cellspacing="0">
                                        
                                        <tr>
                                            <td>
                                                <%--<input type="button" valign="center" id="btnShowImgPanel" class="dkorange20b" value="Add Images..." onclick="toggleImgPanel('pnlAddImages', 'btnShowImgPanel')" />--%>
                                                <span class="white20b">&nbsp;Upload Image&nbsp;|</span>&nbsp;</td>
                                            <td style="border: solid 0px black">
                                                <asp:Label CssClass="dkgrey10b" ID="lblImgTip" runat="server" Width="100%"><span class="black12">2MB max size</span>&nbsp; in GIF/JPG/PNG format.</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 220px">
                                    &nbsp;
                                </td>
                                <td style="width: 482px" align="left">
                                    <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="True"
                                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1" BackColor="#CCCCCC">
                                        <table style="z-index: 115; width: 100%; height: 52px" align="left" bgcolor="#FFFFFF"
                                            bordercolor="#CCCCCC" border="0">
                                            <tr>
                                                <td style="width: 116px">
                                                    &nbsp;
                                                    <asp:Image ID="img2" ImageUrl="../images/CouponDefault.gif" runat="server" Height="100px"
                                                        Width="102px"></asp:Image>
                                                </td>
                                                <td>
                                                    <table border="0">
                                                        <tr>
                                                            <td class="dkgrey20b" align="center">
                                                                |</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dkgrey16b" align="center">
                                                                &nbsp;or&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dkgrey20b" align="center">
                                                                |</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Image ID="img1" runat="server" Height="100px" Width="100px"></asp:Image>
                                                    &nbsp;
                                                    <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkgrey10b" TabIndex="7"
                                                        OnClick="rdoClick('1')">
                                                        <asp:ListItem Value="Keep" Selected="True" />
                                                        <asp:ListItem Value="Delete" />
                                                        <asp:ListItem Value="Change" />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 116px">
                                                    <asp:CheckBox ID="chkDefaultImg" runat="server" CssClass="dkgrey10b" Text=" Use default image"
                                                        TextAlign="Right" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    <input class="dkgrey10b" id="File1" type="file" name="File1" runat="server" onchange="swapImg('1')" />
                                                    <%--                                                    <input class="dkgrey10b" id="File2" type="file" name="File2" runat="server" onchange="swapImg('2')">--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Label runat="server" CssClass="error" ID="lblError2" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 10px">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td style="width: 220px">
                                    &nbsp;</td>
                                <td nowrap align="left" style="width: 482px">
                                    <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" Width="100px" Height="30px" Text="Cancel" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Width="100px" Height="30px" Text="Next >" OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('btnNext','lbl2');javascript:ShowElement('btnNextFake','btnNext');javascript:DisableElement('btnNextFake');javascript:DisableElement('btnBack');" />
                                    <asp:Button ID="btnNextFake" runat="server" CssClass="btnNext" Text="Next" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lbl2" runat="server" CssClass="black12"></asp:Label>
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
                                    <asp:HiddenField ID="hdnImgPath" runat="server" />
                                    <asp:HiddenField ID="hdnEntryId" Value="-1" runat="server" />
                                    <asp:HiddenField ID="hdnExpDate" runat="server" Value="12/01/1972" />
                                    <asp:HiddenField ID="hdnBackToMgr" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnStatus" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div align="center" id="FreezePane" class="FreezePaneOff">
                        <div id="InnerFreezePane" class="InnerFreezePane">
                            <img src="../images/wait.gif" alt="Please wait" />
                        </div>
                    </div>
                    <br />
                    <asp:HiddenField ID="hdnAdType" runat="server" />
                    <div id="push">
                    </div>
                </form>
            </div>
            <div align="center">
                <!-- #include file="../include/footer.aspx" -->
            </div>
        </div>
    </div>
</body>
</html>
