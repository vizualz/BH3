<%@ Page Language="c#" Codebehind="favorites.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.favorites" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Favorites - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />

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
        <form id="Form1" method="post" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <br />
            <div align="center" class="midorange14b">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>&nbsp;
                &gt;&nbsp; FAVORITES&nbsp;
                <asp:Label ID="lblCount" class="midorange14b" runat="server"></asp:Label>
            </div>
            <br />
            <div class="midgrey16b" align="center">
                <asp:Label class="dir" ID="lblNoResult" runat="server"></asp:Label></div>
            <div align="center">
                <table border="0" width="100%">
                    <asp:DataList ID="dlEntryList" Width="580" runat="server" EnableViewState="false"
                        OnItemCommand="View_ItemDetail" OnItemDataBound="dlEntryList_OnItemDataBound"
                        AlternatingItemStyle-BackColor="#F0F0F0">
                        <HeaderTemplate>
                            <tr>
                                <td width="100" class="midgrey16b">
                                    Posted</td>
                                <td width="" align="left" class="midgrey16b">
                                    Type</td>
                                <td width="20">
                                    <img src="images/s1x1.gif"></td>
                                <td width="100" align="left" class="midgrey16b">
                                    Description</td>
                                <td width="20">
                                    <img src="images/s1x1.gif"></td>
                                <td width="20" class="midgrey16b" colspan="3">
                                    Price</td>
                            </tr>
                            <tr>
                                <td colspan="8" bgcolor="#ff9900">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr <%#(Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %>>
                                <td width="100" class="midgrey12b">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}") %>
										<img src="images/s1x1.gif" width="20" height="5" border="0">
										</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="imgAdType" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# GetAdType(DataBinder.Eval(Container.DataItem, "adType")) %>'
                                        ToolTip='<%# DecodeAdType(DataBinder.Eval(Container.DataItem, "adType"))%>'></asp:ImageButton>
                                </td>
                                <td width="20">
                                    <img src="images/s1x1.gif"></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"),DataBinder.Eval(Container.DataItem, "iCategory"))%>
										<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"),DataBinder.Eval(Container.DataItem, "iCategory"))%>
										&nbsp;
										<%# DataBinder.Eval(Container.DataItem, "txtBrand") %>
										</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" width="30">
                                    <asp:Label ID="Label5" runat="server" CssClass="midgrey12b">
											<%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}")  %>
										</asp:Label>
                                </td>
                                <td>
                                    &nbsp&nbsp</td>
                                <td align="left">
                                    <asp:LinkButton ID="btnDelete" runat="server" Font-Underline="true" CssClass="midgrey_orange12"
                                        OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FaviD")%>'>remove</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                    </asp:DataList>
                </table>
            </div>
            <div align="center">
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='images/backpage.gif'"
                                runat="server" ImageUrl="images/backpage.gif"></asp:ImageButton>&nbsp;
                            <asp:Label CssClass="midgrey12b" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='images/nextpage2.gif'" onmouseout="this.src='images/nextpage.gif'"
                                runat="server" ImageUrl="images/nextpage.gif"></asp:ImageButton></td>
                    </tr>
                </table>
            </div>
            <br />
            <div align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label></div>
            <div>
                &nbsp;</div>
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
