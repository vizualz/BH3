<%@ Page Language="c#" Codebehind="ContactAllUsers.aspx.cs" AutoEventWireup="True"
    ValidateRequest="false" Inherits="BoardHunt.Admin.ContactAllUsers1" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Contact All Users - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />

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
            <!-- #include file="../include/Header.aspx" -->
            <p align="center" class="midorange26b">
                <b>CONTACT ALL USERS</b></p>
            <div align="center">
                <asp:Panel ID="panelSendEmail" runat="server" Width="450" BorderColor="#999966" BorderWidth="4px">
                    <table width="450" bgcolor="cccc99" cellspacing="0" cellpadding="0" height="250">
                        <tr>
                            <td bgcolor="999966" colspan="3" height="25" class="black10" align="center">
                                &nbsp;&nbsp;Get the word out!&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="../images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td colspan="20">
                                <img src="../images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td class="black10" align="right">
                                Subject:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="controls" Width="810px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="black10" valign="top" align="right">
                                Message:&nbsp;</td>
                            <td class="controls" valign="top">
                                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="../Blog/fckeditor/"
                                    Width="810" Height="450">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblErrMessage" runat="server" Text="" CssClass="alert"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <img src="../images/s1x1.gif" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />&nbsp;
                                <asp:Button ID="btnCancelPreview" runat="server" Text="Cancel" OnClick="btnCancelPreview_Click" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CheckFields"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelMailSent" runat="server" Visible="False">
                    <span class="postdetails2b">The word is getting out...</span><br />
                    <br />
                    <a href="admin.aspx">Back to Admin Control Panel</a>
                </asp:Panel>
                <asp:Panel ID="pnlConfirm" runat="server" Visible="False">
                    <table style="width: 344px">
                        <tr>
                            <td class="white10b" bgcolor="#999999" style="width: 332px">
                                <b>Are you sure you want to send this e-mail to all users?</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="white10b" style="width: 332px" bgcolor="#999999">
                                <b>Subject:</b><td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                <asp:Label ID="lblSubCheck" runat="server" CssClass="Controls"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="white10b" style="width: 332px" bgcolor="#999999">
                                <b>Message:</b></td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                <asp:Label ID="lblMsgCheck" runat="server" CssClass="Controls"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 332px">
                                <asp:Button ID="btnOK" Text="OK" runat="server" OnClick="btnOK_Click" Width="63px" />&nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div id="push">
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
