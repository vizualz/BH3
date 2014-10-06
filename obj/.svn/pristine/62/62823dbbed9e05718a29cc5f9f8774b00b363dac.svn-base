<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfileManager.aspx.cs" Inherits="BoardHunt.Admin.UserProfileManager1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Admin - Edit User | Boardhunt </title>
        <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
        <script type="text/javascript" src="../include/js/superfish.js"></script>
        <script src="../include/js/bh.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
		<meta name="ROBOTS" content="NOINDEX, NOFOLLOW"/>
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
    <form id="form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <p class="cathead">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="Admin.aspx" CssClass="orange_grey12u">ADMIN</asp:HyperLink>
                &nbsp;&gt;&nbsp;<span class="dkgrey12">EDIT USER DATA</span></p>
            <asp:Panel ID="pnlRegister" runat="server">
                <table cellspacing="0" cellpadding="0" bgcolor="cccc99" border="3" bordercolor="#999966">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" bgcolor="cccc99" height="300px"
                                border="0">
                                <tr>
                                    <td bgcolor="999966" colspan="3" height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td bgcolor="999966" class="black10b" align="center" colspan="3" height="10px">
                                        &nbsp;&nbsp;&nbsp;Edit and click &quot;update&quot;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="999966" colspan="3" height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="2" style="width: 300px">
                                        <img src="../images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="black10b" height="5px" align="right" nowrap style="width: 120px">
                                        Full name:&nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="black10b" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                                            Font-Bold="True" ErrorMessage="!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px" colspan="2" style="width: 300px">
                                        <img src="../images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td class="black10b" height="5px" align="right" style="width: 120px">
                                        E-mail:&nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="black10b" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtEmail"
                                            Font-Bold="True" ErrorMessage="!"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                            Font-Bold="True" ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td height="5px" style="width: 300px" colspan="2">
                                        <img src="../images/s1x1.gif"></td>
                                    
                                </tr>
                                <tr>
                                    <td class="black10b" align="right" height="5px" style="width: 120px">
                                        Phone #:&nbsp;</td>
                                    <td class="dir" align="left">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="black10b" Width="100px" MaxLength="15"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td height="5" style="width: 120px">
                                        <img src="../images/s1x1.gif"></td>
                                    <td class="black10b">
                                        <asp:CheckBox ID="chkShowPhone" runat="server" Text="Display # on ad"></asp:CheckBox>
                                    </td>
                                </tr>
                                <!-- AcctType Always Free (1) until further notice-->
								<tr>
									<td height="2px" style="width: 300px" colspan="2">
                                        <img src="../images/s1x1.gif"></td>
								</tr>		
                                <tr>
                                    <td class="black10b" valign="middle" height="5px" align="right" style="width: 120px">
                                        Are you a&nbsp; business?&nbsp;</td>
                                    <td align="left" valign="middle">
                                        <asp:RadioButtonList ID="radioAcctType" CssClass="black10b" runat="server" Enabled="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="2">Yes</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td class="black10b" valign="middle" height="5px" align="right" style="width: 120px" nowrap>
                                        Comment notification&nbsp;</td>
                                    <td align="left" valign="middle">
                                        <asp:RadioButtonList ID="rdoEmailNotify" CssClass="black10b" runat="server" Enabled="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="Y">On</asp:ListItem>
                                            <asp:ListItem Value="N">Off</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td class="black10b" valign="middle" height="5px" align="right" style="width: 120px" nowrap>
                                        Blog notification&nbsp;</td>
                                    <td align="left" valign="middle">
                                        <asp:RadioButtonList ID="rdoBlogNotify" CssClass="black10b" runat="server" Enabled="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="Y">On</asp:ListItem>
                                            <asp:ListItem Value="N">Off</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td class="black10b" valign="middle" height="5px" align="right" style="width: 120px" nowrap>
                                        Voucher: &nbsp;</td>
                                        <td>
                <asp:DropDownList ID="cboVoucher" runat="server" CssClass="dkrgrey10b">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>                
                </asp:DropDownList>
                                                    
                                        </td>                                
                                </tr> 
<%--                                                                                                  
                                <tr>
                                    <td style="width: 120px; height: 15px" align="right" class="black10b">&nbsp;Password:&nbsp;</td>
                                    <td style="width: 100px; height: 15px;" align="left">
                                        <asp:label ID="lblPassword" runat="server"></asp:label>
                                    </td>
                                </tr>
                               <asp:Panel ID="pnlChangePwd" runat="server" Visible="true">
                                    <tr>
                                        <td class="homedir" align="right" height="15px">
                                            &nbsp;New password:&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="controls" Width="150px" TextMode="Password"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" Font-Bold="True" ErrorMessage="!"
                                                OnServerValidate="CheckPassword"></asp:CustomValidator></td>
                                    </tr>
                                </asp:Panel>--%>
                                <tr>
                                    <td height="5" style="width: 120px">
                                        <img src="../images/s1x1.gif"></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td  height="15px" style="width: 120px">
                                    </td>
                                    <td align="left">
                                    <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" Text="Cancel" OnClick="btnBack_Click" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Text="Save" OnClick="btnNext_Click" />
                                </td>
                                </tr>
                                <tr>
                                    <td height="5px" style="width: 120px" colspan="2">&nbsp;
                                    <asp:Label ID="lblStatus" runat="server" CssClass="alert"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="hdnUId" runat="server" />
    <div id="push">
    </div>        
    </form>
        </div>
    <div align="center"><!-- #include file="../include/footer.aspx" --></div>
</body>
</html>
