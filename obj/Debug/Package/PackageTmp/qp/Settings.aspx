<%@ Page Codebehind="Settings.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.qp.Settings" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Settings - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    
    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>    
    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />    

    <script type="text/javascript">
          $(document).ready(function() {
            jQuery(function(){
                jQuery('ul.sf-menu').superfish();
            });
            
            $('a.Tips').cluetip({splitTitle: '|', clickThrough: true});                 
            
          });
    </script>

</head>
<body>
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center">
                <%--            <div align="center" style="width:400px">
                <span class="midorange14b">
                    SETTINGS</span>
                    </div>--%>
                <br /><br />
                <asp:Panel CssClass="errorLabel" ID="pnlMessage" runat="server" Width="500px" Visible="false">
                    &nbsp;
                    <asp:Label ID="lblMessage" runat="server" Width="450px"></asp:Label>
                    &nbsp;
                </asp:Panel>
                <asp:Panel ID="pnlSettings" runat="server">
                    <table cellspacing="0" cellpadding="0" style="border: solid 0px #FF9900; background-color: #F0F0F0; width: 400px; height: 400px;">
                        <tr>
                            <td class="white20b" style="background-color: #CCCCCC" align="center" colspan="2">
                                &nbsp;&nbsp;&nbsp;Coupon Footer&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkInfo" runat="server" CssClass="Tips" Title="Info|The coupon footer contains your contact info and displays on the bottom of all your coupons" style="border:solid 0px blue; color:#ff6600; text-align:center;height:15px; line-height:15px">[ i ]</asp:LinkButton> 
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" align="right" width="150px" nowrap>
                                Biz Name:&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="txtDisplayName" MaxLength="50" runat="server" CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" align="right" width="150px">
                                Web URL:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtWeb" Style="width: 200px" runat="server" CssClass="dkrgrey14"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" colspan="2">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr class="dkgrey14">
                            <td class="dkgrey14" align="right" width="150px">
                                Phone Number:&nbsp;</td>
                            <td class="dir" align="left" valign="middle">
                                <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="dkrgrey14" Width="100px" MaxLength="12"></asp:TextBox>
                                <asp:CustomValidator ID="Customvalidator1" runat="server" Font-Bold="True" ErrorMessage="!"
                                    OnServerValidate="CheckPhoneNum"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" colspan="2">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" align="right" width="150px">
                                &nbsp;Address:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtAddress" Width="200px" runat="server" CssClass="dkrgrey14"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" colspan="2">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" width="150px" align="right">
                                &nbsp;City:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="dkrgrey14"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" colspan="2">
                                <img src="../images/s1x1.gif" alt="" /></td>
                        </tr>
                        <tr>
                            <td class="dkgrey14" width="150px" align="right">
                                State:&nbsp;</td>
                            <td class="dkgrey14">
                                <asp:TextBox ID="txtState" MaxLength="2" Width="30" runat="server" CssClass="dkrgrey14"></asp:TextBox>&nbsp;&nbsp;&nbsp;Zip:&nbsp;<asp:TextBox
                                    ID="txtZip" Width="50" runat="server" MaxLength="5" CssClass="dkrgrey14"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="5px" colspan="2">
                                &nbsp;
                                <asp:Label ID="lblStatus" runat="server" CssClass="alert"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <div align="center">
                    <asp:Button ID="btnCancel" Text="Cancel" Height="30px" Width="100px" runat="server" CssClass="btnCancel" />
                    &nbsp;
                    <asp:Button ID="btnSave" Text="Save" Height="30px" Width="100px" runat="server" CssClass="btnGo" />
                </div>
            </div>
            <asp:HiddenField ID="hdnAId" runat="server" Value="-1" />
            <asp:HiddenField ID="hdnUId" runat="server" Value="0" />
            <asp:HiddenField ID="hdnRDir" runat="server" Value="0" />            
            <div id="push">
            </div>
        </form>
    </div>
    <br />
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
