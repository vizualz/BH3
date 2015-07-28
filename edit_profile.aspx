<%@ Page Codebehind="edit_profile.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.edit_profile" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Edit Profile - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="include/js/bh.js"></script>

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
            <bh:Header runat="server" />
            <div align="center">
                <div align="center" style="width: 400px">
                    <span class="midorange14b">
                        <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>
                        &nbsp;&gt;&nbsp;MY ACCOUNT INFO</span>
                </div>
                <asp:Panel ID="pnlRegister" runat="server">
                    <table cellspacing="0" cellpadding="0" bgcolor="F0F0F0" border="0" bordercolor="#CCCCCC">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" bgcolor="#F0F0F0" style="height: 600px" border="0">
                                    <tr>
                                        <td bgcolor="#CCCCCC" colspan="2" style="height: 5px">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <%--                                    <tr>
                                        <td bgcolor="#CCCCCC" class="white20b" align="center" colspan="3" height="10px">
                                            &nbsp;&nbsp;&nbsp;Edit Your Info and click &quot;Save&quot;</td>
                                    </tr>--%>
                                    <tr>
                                        <td class="white24b" style="background-color: #CCCCCC;" align="left" colspan="2">
                                            <span >&nbsp;Profile:</span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <img alt="" src="images/s1x1.gif" height="2px" /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td valign="bottom">
                                            <asp:Image ID="img1" runat="server" Height="64px" Width="64px" align="left"></asp:Image>
                                            <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('1')"
                                                TabIndex="17">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <input class="dkgrey10b" id="File1" type="file" name="File1" runat="server" onchange="swapImg('1')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 10px;">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right" nowrap style="width: 200px">
                                            Full name:&nbsp;</td>
                                        <td align="left" style="width: 300px">
                                            <asp:TextBox ID="txtFullName" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                            <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                                                Font-Bold="True" ErrorMessage="!"></asp:RequiredFieldValidator>-->
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 5px;">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right" nowrap>
                                            Display name:&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;" colspan="2">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right">
                                            E-mail:&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtEmail"
                                                Font-Bold="True" ErrorMessage="!"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                                Font-Bold="True" ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;" colspan="2">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" align="right" height="5px">
                                            Phone #:&nbsp;</td>
                                        <td class="dir" align="left">
                                            (
                                            <asp:TextBox ID="txtAreaCode" runat="server" CssClass="dkrgrey14" Width="40px" MaxLength="3"></asp:TextBox>&nbsp;)
                                            -
                                            <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="dkrgrey14" Width="100px" MaxLength="8"></asp:TextBox>
                                            <asp:CustomValidator ID="Customvalidator2" runat="server" Font-Bold="True" ErrorMessage="!"
                                                OnServerValidate="CheckPhoneNum"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                        <td class="dkrgrey10b" style="height: 20px">
                                            <asp:CheckBox ID="chkShowPhone" runat="server" Text=" Show buyers my phone#"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <img alt="" src="images/s1x1.gif" height="2px" /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey18b" style="height: 40px;" align="left" valign="top" colspan="2">
                                            <span style="width: 100%">&nbsp;Settings:&nbsp;</span><br />
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right">
                                            Is this a business?&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="radioAcctType" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="2">Yes</asp:ListItem>
                                                <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;" colspan="2">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right" nowrap>
                                            Email me when people &nbsp;<br />
                                            write on my wall:&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="rdoEmailNotify" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">On</asp:ListItem>
                                                <asp:ListItem Value="N">Off</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;" colspan="2">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right" nowrap>
                                            Email me on new blogs:&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="rdoBlogNotify" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">On</asp:ListItem>
                                                <asp:ListItem Value="N">Off</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 300px; height: 5px;" colspan="2">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 15px" align="right" class="dkgrey14">
                                            &nbsp;Password:&nbsp;</td>
                                        <td style="height: 15px;" align="left">
                                            <asp:Button ID="btnChangePwd" runat="server" class="dkrgrey10b" Text="Change Password..."
                                                Width="130px" OnClick="btnChangePwd_Click" />
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlChangePwd" runat="server" Visible="true">
                                        <tr>
                                            <td class="dkgrey14" align="right" height="15px">
                                                &nbsp;New password:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPassword1" runat="server" CssClass="dkrgrey14" Width="150px"
                                                    TextMode="Password"></asp:TextBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" Font-Bold="True" ErrorMessage="!"
                                                    OnServerValidate="CheckPassword"></asp:CustomValidator></td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td height="10" style="width: 120px">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlShaper" runat="server">
                                        <tr>
                                            <td colspan="2" align="left" style="height:10px">
                                                <asp:Label runat="server" ID="lblShaperHouse" CssClass="dkgrey18b">
                                            &nbsp;ShaperHouse Profile:
                                            </asp:Label>
                                                <br />
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Brand:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBrandName" runat="server" CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Region:&nbsp;</td>
                                            <td align="left" class="dkgrey14">
                                                <asp:DropDownList ID="cboRegion" runat="server" CssClass="dkrgrey14" Style="width: 150px">
                                                </asp:DropDownList>&nbsp;&nbsp; Backyard:&nbsp;<asp:TextBox ID="txtHomeTown" runat="server"
                                                    CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Web site:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Years shaping:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtShapingYrs" runat="server" CssClass="dkrgrey14" Style="width: 30px"></asp:TextBox>
                                                <span class="dkgrey10b">(whole numbers)</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Bio:&nbsp;</td>
                                            <td align="left" valign="top" style="width: 482px">
                                                <asp:TextBox ID="txtDetails" onkeydown="CountChars()" runat="server" CssClass="dkrgrey14"
                                                    Height="135px" Width="350px" MaxLength="599" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>&nbsp;&nbsp;
                                                <span class="dkorange10b">
                                                    <br />
                                                    <b>(600 max; no HTML)</b>&nbsp;&nbsp;</span><span>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td colspan="2" style="height: 5px">
                                            <img src="images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    <asp:Panel ID="pnlShaping" runat="server">
                                        <tr>
                                            <td class="dkgrey14" align="right" valign="top">
                                                Shaping Designs:&nbsp;<br />
                                                (for shapers only)&nbsp;</td>
                                            <td style="border: solid 0px black" align="left">
                                                <asp:CheckBoxList ID="chkListShaping" CssClass="dkgrey12b" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Text="All" Value="69"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="15px" style="width: 120px">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="Cancel" TabIndex="100"
                                                OnClick="btnCancel_Click" />&nbsp;
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnGo" Text="Save" TabIndex="101"
                                                OnClick="btnSave_Click" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px" style="width: 120px" colspan="2">
                                            &nbsp;
                                            <asp:Label ID="lblStatus" runat="server" CssClass="alert"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <br />
            <br />
            <asp:HiddenField ID="hdnUserDir" runat="server" />
            <asp:HiddenField ID="hdnProfilePic" runat="server" />
            <asp:HiddenField ID="hdnAcctType" runat="server" />
            <asp:HiddenField ID="hdnMT" runat="server" />
            <asp:HiddenField ID="hdnShaperCode" runat="server" Value="0" />
            <asp:HiddenField ID="hdnIsShaper" runat="server" Value="0" />
            <div id="push">
            </div>
        </form>
    </div>
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
