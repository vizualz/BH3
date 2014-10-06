<%@ Page Language="c#" Codebehind="forget_pass.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.forget_pass" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>BoardHunt...where boards are sold</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="style/global.css" type="text/css" rel="stylesheet"/>

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
    <form class="header" id="Form1" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <div align="center">
                <br>
                <br>
                <span class="midorange30b">FORG0T PASSWORD?</span><br>
                <br>
                <br>
                <asp:Panel ID="panelSendEmail" runat="server" Width="425" BorderColor="#CCCCCC" border="1"
                    BorderStyle="solid">
                    <table bgcolor="#F0F0F0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2" height="5" bgcolor="CCCCCC" border="0" bordercolor="CCCCCC">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="dkgrey12b" bgcolor="CCCCCC" border="0" bordercolor="CCCCCC">
                                &nbsp;Send us the email you signed up with and we'll send you a new one.&nbsp;&nbsp;You can change this new password in the user menu.&nbsp;</td>
                         </tr>
                            <tr>
                                <td colspan="2" bgcolor="CCCCCC" border="0" bordercolor="999966" style="height: 5px">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td class="midgrey20b" align="right">
                                &nbsp;Email:&nbsp;</td>
                            <td class="dkgrey12" align="left">
                                <asp:TextBox ID="txtEmail" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail"
                                    runat="server" ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td height="10">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td width="5">
                                <img src="images/s1x1.gif" /></td>
                            <td>
                                <asp:ImageButton ID="imgContact" ImageUrl="images/send.gif" runat="server"></asp:ImageButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblStatus" ForeColor="Red" BorderColor="red" BorderWidth="0" BackColor="white" runat="server" CssClass="alert"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelMailSent" runat="server" Visible="False" Width="300" HorizontalAlign="Left">
                <span class="dkorange16b">
                    Thanks! Check your e-mail shortly for your new password. You can change this password
                    in the edit profile settings.
                    </span>
                </asp:Panel>
            </div>

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
