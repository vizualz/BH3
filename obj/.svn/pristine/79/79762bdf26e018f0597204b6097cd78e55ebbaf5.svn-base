<%@ Page Language="c#" Codebehind="contact.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.contact" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Contact Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

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
            <br />
            <span class="midorange26b" style="width: 400px; height: 40px">CONTACT BOARDHUNT</span>
            <br />
            <br />
            <div align="center" style="height:500px">
                <asp:Panel ID="panelSendEmail" runat="server" Width="600" BorderColor="#CCCCCC" BorderWidth="0px">
                    <table width="600" bgcolor="F0F0F0" cellspacing="1" cellpadding="1" height="250">
                        <tr>
                            <td bgcolor="#CCCCCC" colspan="3" height="25" class="white16b" align="center">
                                &nbsp;&nbsp;Let's hear it&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td colspan="20">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14b" width="25%" align="right">
                                Name:&nbsp;</td>
                            <td class="dkgrey12">
                                <asp:TextBox ID="name" CssClass="dkgrey14" runat="server" Width="176px" />
                                <asp:Label ID="lblErrName" runat="server" Text="" CssClass="alert"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14b" align="right">
                                E-mail:&nbsp;</td>
                            <td class="midgrey12">
                                <asp:TextBox ID="email" CssClass="dkgrey14" runat="server" Width="176px" />
                                <asp:Label ID="lblErrEmail" runat="server" Text="" CssClass="alert"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14b" align="right">
                                Subject:&nbsp;</td>
                            <td class="dkgrey14b">
                                <asp:DropDownList ID="cboSubject" runat="server" CssClass="dkgrey14" Enabled="true"
                                    Width="341px">
                                    <asp:ListItem Value="1" Selected="True">GENERAL - questions, comments or ideas</asp:ListItem>
                                    <asp:ListItem Value="2">BOARDHELP - for specific questions on boards</asp:ListItem>
                                    <asp:ListItem Value="3">TECH SUPPORT - report a problem</asp:ListItem>
                                    <asp:ListItem Value="4">MARKETING - for joint Marketing &amp; Promotional events</asp:ListItem>
                                    <asp:ListItem Value="5">ADVERTISING - for Advertising on Boardhunt</asp:ListItem>
                                    <asp:ListItem Value="6">REQUEST - to request a new location</asp:ListItem>
                                    <asp:ListItem Value="7">REQUEST - a blog topic</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="dkgrey14b" valign="top" align="right">
                                Message:&nbsp;</td>
                            <td class="dkgrey12" valign="top">
                                <asp:TextBox ID="message" TextMode="MultiLine" Columns="40" Rows="10" runat="server"
                                    Height="100px" Width="341px" CssClass="dkgrey14" /></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblErrMessage" runat="server" Text="" CssClass="alert"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                 <asp:Button ID="btnSend" runat="server" CssClass="btnGo" Text="Send" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CheckFields"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelMailSent" class="dkgrey12b" runat="server" Visible="False">
                    Thanks! Your message has been sent.
                </asp:Panel>
            </div>
            <div class="push">
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
