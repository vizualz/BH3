<%@ Page CodeBehind="register_user.aspx.cs" Language="c#" AutoEventWireup="True"
    Inherits="BoardHunt.register_user" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Signup and sell your surfboard | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>
    <script language="javascript">
    <!--
        $(document).ready(function () { $(".defaultText").focus(function (a) { if ($(this).val() == $(this)[0].title) { $(this).removeClass("defaultTextActive"); $(this).val("") } }); $(".defaultText").blur(function () { if ($(this).val() == "") { $(this).addClass("defaultTextActive"); $(this).val($(this)[0].title) } }); $(".defaultText").blur() })
    -->
    </script>
</head>
<body>
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
        <!-- #include file="include/Header.aspx" -->
        <div align="center">
            <asp:Panel ID="pnlRegister" runat="server" BorderColor="#FF9900" BorderWidth="0"
                BorderStyle="solid">
                <div style="width: 275px; margin-top: 20px" align="center" class="dkgrey14">
                    <span class="midorange30b">Create Account</span><br />
                    Join to find boards or sell them. <span class="midorange14b">Go Pro </span>for more
                    convenience.</div>
                <br />
                <div style="width: 1000px; height: 600px">
                    <div class="midgrey16" style="float: left; width: 453px; margin-bottom: 30px; margin-top: 30px"
                        align="left">
                        <img align="left" src="images/accounts.png" />
                        <br />
                    </div>
                    <div align="right" style="float: right; width: 400px; height: 500px">
                        <br />
                        <br />
                        <asp:Panel ID="pnlError" align="center" runat="server" BackColor="#ffE4E1" BorderColor="red"
                            BorderWidth="1" Width="350" valign="middle" Height="50px" Visible="false" CssClass="errorLabel">
                            &nbsp;<br />
                            <asp:Label ID="lblStatus" runat="server" CssClass="dkrgrey14" Width="400px"></asp:Label>
                        </asp:Panel>
                        <br />
                        <div align="right" style="border: solid 0px yellow; width: 410px; margin-top: 25px">
                            <table style="width: 420px; height: 450px; background-color: White;" class="regtable"
                                cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" class="dkgrey12">
                                        I'm a member,&nbsp;<a class="ltgreen_orange12" href="Login.aspx">Log in</a>&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="2">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
<%--                                <tr>
                                    <td class="midgrey24" valign="middle" align="right" nowrap style="width: 150">
                                        &nbsp;&nbsp;&nbsp;Full name:&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="dkgrey18b" Width="250"></asp:TextBox>
                                        &nbsp;<asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="error"
                                            OnServerValidate="CheckFName" ErrorMessage="!"></asp:CustomValidator>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="midgrey24" valign="middle" align="right" style="width: 36%">
                                        &nbsp;&nbsp;&nbsp;E-mail:&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="dkgrey18b" Width="250"></asp:TextBox>
                                        <%--                                                    <asp:RegularExpressionValidator  ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                                        ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        CssClass="error"></asp:RegularExpressionValidator>--%>
                                        &nbsp;<asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="!"
                                            OnServerValidate="CheckEmail" CssClass="error"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="midgrey24" align="right" valign="middle" style="width: 36%">
                                        &nbsp;Password:&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPassword1" runat="server" CssClass="dkgrey18b" Width="250" TextMode="Password"></asp:TextBox>&nbsp;
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="!" OnServerValidate="CheckPassword"
                                            CssClass="error"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 36%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 95%" align="left">
                                        <span class="midorange12">(6 chars min)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="midgrey24" align="right" style="width: 36%" valign="middle">
                                        &nbsp;Phone:&nbsp;<br />
                                    </td>
                                    <td class="midgrey16b" align="left" valign="middle">

                                        <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="defaultText defaultTextActive" MaxLength="8" Width="250" title="optional"></asp:TextBox>
<%--                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="!" OnServerValidate="CheckPhoneNum"
                                            CssClass="error"></asp:CustomValidator>
                                        &nbsp;<span class="midorange12">(optional)&nbsp;&nbsp;</span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
<%--                                <tr>
                                    <td style="width: 36%">
                                        &nbsp;
                                    </td>
                                    <td height="20px" class="midorange12" nowrap align="left">
                                        <asp:CheckBox ID="chkShowPhone" runat="server" Text="&nbsp;Show buyers"></asp:CheckBox>&nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="images/s1x1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dkgrey12" align="right" valign="middle">
                                        &nbsp;&nbsp;&nbsp;Are you a business?&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="radioAcctType" runat="server" CssClass="dkgrey12" Enabled="true"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="2" Onclick="TogglePanel(this.value,'div_businessType','1');ToggleElement('chkUpgrade',0);ToggleElement('chkUpgrade2',0)">&nbsp;Yes&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="1" Onclick="TogglePanel(this.value,'div_businessType','1');ToggleElement('chkUpgrade',1);ToggleElement('chkUpgrade2',1)"
                                                Selected="True">&nbsp;No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 350px; height: 25px;" nowrap>
                                        <div id="div_businessType" style="display: none; margin-left: 60px; margin-bottom: 15px;"
                                            align="left">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td align="right" class="dkgrey12">
                                                        What type?&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="cboMerchantType" runat="server" CssClass="dkrgrey12" Width="155px">
                                                            <asp:ListItem Value="0" Selected="True">Pick one...</asp:ListItem>
                                                            <asp:ListItem Value="1">Shaper/Manufacturer</asp:ListItem>
                                                            <asp:ListItem Value="2">Retailer/Service</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <%--                                                        <!-- TODO -->
                                                        <asp:RadioButtonList ID="rdoMerchantType" runat="server" CssClass="midgrey12" Enabled="true"
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="2" Onclick="TogglePanel(this.value,'div_businessType','1')">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1" Onclick="TogglePanel(this.value,'div_businessType','1')"
                                                                Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="midgrey24" valign="top" align="right" style="height: 10px" rowspan="2">Go Pro:&nbsp;
                                        
                                    </td>
                                    <td align="left"  class="dkgrey16" valign="top">
                                        <asp:CheckBox ID="chkUpgrade" OnClick="CheckPro('0')" runat="server" class="lt_miniorange" Text="" />&nbsp;<img style="vertical-align:middle" src="images/gopro3mo.gif" alt="" />
                                    </td>
                                </tr>
                                <tr style="padding-top:5px">
                                    <td align="left" class="dkgrey16" style="padding-top:5px">
                                        <asp:CheckBox ID="chkUpgrade2" runat="server" OnClick="CheckPro('1')" class="lt_miniorange" Text="" />&nbsp;<img style="vertical-align:middle" src="images/gopro1yr.gif" alt="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px">
                                        <img src="images/s1x1.gif" alt="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="2"><br />
                                        <asp:Button ID="btnFinish" runat="server" align="middle" CssClass="btnGo" Height="50"
                                            OnClick="btnFinish_Click" OnClientClick="HideElement('btnFinish', 'lblPW');SetElement('hdnMeVal','1');"
                                            Text="Create account" Width="150" />
                                        <%--                                                    <a href="#" onclick="clearRegisterForm()"><u>clear</u></a>&nbsp;--%>
                                        <span id="lblPW" class="dkorange12b"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                        <img src="images/s1x1.gif" alt="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15">
                                        <img src="images/s1x1.gif" alt="" />
                                    </td>
                                    <td align="left" class="dkgrey12" style="height: 15px">
                                        By signing up you agree to our
                                        <a class="ltgreen_orange12" href="#" onclick="popUpHelp('3')">Terms.</a>
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div style="float: left; margin-left: 60px; width: 905px" align="left" class="dkgrey14">
                    <br />
                    <span class="midorange20b">Want to advertise on Boardhunt?<a href="/contact.aspx" class="ltgreen_orange20">&nbsp;&nbsp;Contact us</a> for details.</span>
                    <br />
                    <br />
                    <br />
                    <span class="midorange30b">FAQ</span><br />
                    <br />
                    <span class="dkrgrey14">Q)</span> Does Boardhunt sell boards?<br />
                    <span class="dkrgrey14">A)</span> No, the seller does. We just connect you two.<br />
                    <br />
                    <span class="dkrgrey14">Q)</span> How is BH better than CL, or similar sites?<br />
                    <span class="dkrgrey14">A)</span> We know surf and tech. We don't just list boards,
                    we make it easier to find and sell them with advanced features. We care about accuracy
                    and your time.<br />
                    <br />
                    <span class="dkrgrey14">Q)</span> Can I post for free?<br />
                    <span class="dkrgrey14">A)</span> Yes, but only two items at a time. Otherwise it's
                    only $19 per year.
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> Does BH sell our info?<br />
                    <span class="dkrgrey14">A)</span> Never.
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> How many pics can I post?<br />
                    <span class="dkrgrey14">A)</span> Up to three
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> How do I connect with a buyer?<br />
                    <span class="dkrgrey14">A)</span> Directly. By email, phone, face to face.
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> How long do boards stay posted?<br />
                    <span class="dkrgrey14">A)</span> Up to one year then they are deleted.
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> How does BH maintain quality?<br />
                    <span class="dkrgrey14">A)</span> We remove junk. We also fix miscategorized items.
                    <br />
                    <br />
                    <span class="dkrgrey14">Q)</span> Why can retail post here?<br />
                    <span class="dkrgrey14">A)</span> Because they have good boards for sale. We make
                    it easy to separate them out in our advanced filters.
                    <br />
                </div>
            </asp:Panel>
            <br />
            <br />
            <br />
        </div>
        <asp:HiddenField ID="hdnMeVal" Value="0" runat="server" />
        <div id="push">
        </div>
        </form>
    </div>
    <br />
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-2548219-1");
        pageTracker._initData();
        pageTracker._trackPageview();
    </script>
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
            tab_hover_color: '#FF6600'
        };

        (function () {
            var _ue = document.createElement('script'); _ue.type = 'text/javascript'; _ue.async = true;
            _ue.src = ('https:' == document.location.protocol ? 'https://s3.amazonaws.com/' : 'http://') + 'cdn.userecho.com/js/widget-1.4.gz.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(_ue, s);
        })();

</script>
</body>
</html>
