<%@ Page Language="c#" Codebehind="login.aspx.cs" AutoEventWireup="true" Inherits="BoardHunt.login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Login - Boardhunt</title>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    });
    </script>

</head>
<body>
        <div id="main" align="center">
        <form class="header" id="Form1" enctype="multipart/form-data" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <br />
            <span class="midorange26b" style="width: 400px; height: 40px">LOGIN</span>
            <br /><br />
                <span class="midgrey14">&nbsp;</span>
            <asp:Panel ID="pnlSurf" align="center" runat="server" BorderWidth="0px" BorderColor="#CCCCCC"
                BorderStyle="solid">
                <table bgcolor="#F0F0F0" align="center" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 450px">
                            <table bgcolor="#F0F0F0" align="center" cellspacing="2" cellpadding="2" border="0">
                                <tr>
                                    <td rowspan="9" style="width: 25px">
                                        <img src="images/s1x1.gif" alt="spacer"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px" align="right">
                                        
                                        &nbsp;<asp:Label ID="lblMessage" ForeColor="Red" Style="border: solid 1px red" runat="server"
                                            CssClass="alert" Visible="false">&nbsp;</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="3">
                                        <img src="images/s1x1.gif" alt="spacer"></td>
                                </tr>
                                <tr>
                                    <td class="midgrey20b" align="right" nowrap>
                                        &nbsp;E-mail:&nbsp;</td>
                                    <td class="alert" align="left" colspan="2" nowrap>
                                        <asp:TextBox ID="txtUsername" class="dkgrey14" runat="server" Width="210px"></asp:TextBox>
                                        &nbsp;
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CheckUserName"
                                            ErrorMessage="*"></asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="3">
                                        <img src="images/s1x1.gif" alt="spacer"></td>
                                </tr>
                                <tr>
                                    <td class="midgrey20b" align="right" nowrap>
                                        &nbsp;Password:&nbsp;</td>
                                    <td class="alert" align="left" colspan="2" nowrap>
                                        <asp:TextBox ID="txtPassword" class="dkgrey14" runat="server" Width="210px" TextMode="Password"></asp:TextBox>
                                        &nbsp;
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*" OnServerValidate="CheckPass"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;<a href="forget_pass.aspx" class="ltgreen_orange14">Forgot password?</a>&nbsp;</td>
                                    <td class="dkgrey10b" colspan="2">
                                        <asp:CheckBox ID="chkRememberMe" runat="server" Text="&nbsp;Keep me signed in"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                    <td class="alert" align="center" colspan="3">
                                        &nbsp;
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                </tr>
                                
                                <tr valign="top">
                                    <td>
                                        <img src="images/s1x1.gif">
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnLogin" width="100" height="30" runat="server" CssClass="btnGo" Text="Login" OnClick="btnLogin_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table width="250" bgcolor="#CCCCCC">
                                <tr>
                                    <td height="65px">
                                        <img src="images/s1x1.gif">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="white20b" align="center">
                                        &nbsp;&nbsp;Not a member yet?
                                    </td>
                                </tr>
                                <tr>
                                    <td class="midgrey16b" align="center">
                                        &nbsp;&nbsp;It's free, and only takes &nbsp;&nbsp;seconds!
                                    </td>
                                </tr>
                                <tr>
                                    <td height="45px">
                                        <img src="images/s1x1.gif">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <%--<asp:ImageButton ID="imgNewUser" CausesValidation="false" runat="server" ImageUrl="images/sign-up.gif">
                                        </asp:ImageButton>--%>
                                        <asp:Button ID="btnRegister" width="120" height="30" runat="server" CssClass="btnStep" Text="Sign Up" OnClick="btnRegister_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="30px">
                                        <img src="images/s1x1.gif">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="hdnVal" runat="server" />
            <div id="push"></div>
                </form>
        </div>
        <br />
        <div align="center">
            <!-- #include file="include/footer.aspx" -->
        </div>

</body>
</html>
