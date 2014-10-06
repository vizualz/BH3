<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QManager.aspx.cs" Inherits="BoardHunt.Qna.QManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ask-a-Pro - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />    

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
        <form id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" class="midorange14b" style="width:500px;height:40px">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="../UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>
                <span class="dkgrey14b">></span>&nbsp;Ask-A-Pro<span class="dkgrey14b">&nbsp;>&nbsp;</span>Manage<asp:Label
                    ID="lblCount" runat="server"></asp:Label></div>
            <p>
            </p>
            <div class="midgrey16b" align="center">
                <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
            <div align="center">
                <table border="0">
                    <asp:DataList ID="dlEntryList" Width="600" runat="server" AlternatingItemStyle-BackColor="#E6E6E6"
                        EnableViewState="false">
                        <HeaderTemplate>
                            <tr>
                                <td width="100" class="midgrey16b">
                                    Posted</td>
                                <td width="100" align="left" class="midgrey16b" colspan="2">
                                    Title</td>
                                <%--<td width="20"><img src="../images/s1x1.gif"></td>--%>
                                <td width="20" class="midgrey16b" colspan="2" align="left">
                                    Manage</td>
                                <%--<td width="20" class="midgrey16b" align="left">Publish</td>--%>
                                <td width="20" class="midgrey16b" align="left" nowrap>
                                    Email Notify</td>
                            </tr>
                            <tr>
                                <td colspan="6" bgcolor="#ff9933">
                                    <img src="../images/s1x1.gif"></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <!-- TODO: This is a multi category view so we need dynamic formatting - Create a hidden control and drop the board cat to dymanically format ht/in -->
                            <tr <%#(Container.ItemIndex%2==1)? "style='background-color:#E6E6E6'":"" %>>
                                <td width="100">
                                    <asp:Label ID="label9" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "CreateDate", "{0: MM/dd}")%>
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" CssClass="dkgrey12b">	    
									    <%# FormatDetails(DataBinder.Eval(Container.DataItem, "Question"))%>
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp&nbsp</td>
                                <td align="left">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" CssClass="dkgrey12b"
                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' OnCommand="GetValues"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>edit</asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="true" CssClass="dkgrey12b"
                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' OnCommand="ViewPage"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>view</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp&nbsp</td>
                                <%--
								<td align="left">
									<asp:LinkButton id="chkPub" runat="server" Font-Underline="true" CssClass="controls" OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>delete</asp:LinkButton>--%>
                                <%--<asp:CheckBox ID="chkPublish" runat="server" CssClass="dkgrey12b"  Checked='<%# GetPublishedStatus(DataBinder.Eval(Container.DataItem, "PublishFlg"))%>' />
								
								</td>
								--%>
                                <td align="left">
                                    <%--<asp:LinkButton id="chkPub" runat="server" Font-Underline="true" CssClass="controls" OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>delete</asp:LinkButton>--%>
                                    <asp:CheckBox ID="chkNotify" runat="server" CssClass="dkgrey12b" Checked='<%# GetNotifyStatus(DataBinder.Eval(Container.DataItem, "NotifyFlg"))%>' />
                                    <asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QiD")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                    </asp:DataList></table>
            </div>
            <div align="center">
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                runat="server" ImageUrl="../images/backpage.gif" Visible="false"></asp:ImageButton>&nbsp;
                            <asp:Label CssClass="dkgrey12b" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                runat="server" ImageUrl="../images/nextpage.gif" Visible="false"></asp:ImageButton></td>
                    </tr>
                </table>
                <div align="center">
                <asp:Button ID="btnCancel" CssClass="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel" />     
                                   &nbsp;
                    <asp:Button ID="btnUpdate" CssClass="btnGo" OnClick="btnUpdate_Click" runat="server"
                        Text="Update" /></div>
            </div>
            <asp:HiddenField ID="hndUserId" runat="server" />
            <div align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label></div>
                <br />
            <div id="push">
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <%--Google analytics--%>

    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
