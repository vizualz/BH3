<%@ Page Language="c#" Codebehind="maintenance.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.maintenance" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Used Surfboards - Boardhunt</title>
    <meta name="description" content="Find or sell used surfboards, snowboards, and other boarding gear across the board riding communities.">
    <link href="style/global.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form class="header" id="Form1" enctype="multipart/form-data" runat="server">
        <table width="900" align="center" class="list">
            <tr>
                <td>
                    <img src="http://www.malzook.com/images/BHLogo.gif" border="0"></td>
            </tr>
            <tr>
                <td colspan="10">
                    <img height="3" src="http://www.malzook.com/images/colornavbar.gif" width="900"></td>
            </tr>
            <tr>
        </table>
        <div align="center">
            <p class="cathead">
                <b>-</b>
            </p>
            <asp:Panel ID="pnlSurf" runat="server" HorizontalAlign="Center" align="center">
                <table bgcolor="#ffffff" cellspacing="0" cellpadding="2" border="0" bordercolor="#ffffff"
                    align="center">
                    <tr>
                        <td>
                            <table bgcolor="#ffffff" cellspacing="2" cellpadding="2" border="0" width="500" align="center">
                                <tr>
                                    <td height="5" colspan="3">
                                        <asp:Label ID="lblMessage" runat="server" CssClass="alert"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="hugegreen">
                                        Fellow Board Riders:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3" colspan="3" bordercolor="transparent">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="hugeorange">
                                        Hang tight while we update the site...
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="3">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <img src="images/FreakCoder.gif" alt="thefreak" /></td>
                                </tr>
                            </table>
                            </td>
                            </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
    <div class="footer" align="center">
        © 2012 Boardhunt</div>
</body>
</html>
