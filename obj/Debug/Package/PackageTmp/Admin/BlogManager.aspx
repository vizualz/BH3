<%@ Page Language="c#" Codebehind="BlogManager.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Admin.BlogManager1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>BoardHunt...where boards are sold</title>
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
        <form id="Form1" method="post" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" class="midorange26b">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="Admin.aspx" CssClass="orange_dkorange26">ADMIN</asp:HyperLink>&nbsp;
                > EDIT/DELETE AD -
                <asp:Label ID="lblCount" runat="server"></asp:Label>
            </div>
            <br />
            <div class="midgrey16b" align="center">
                <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label>
            </div>
            <div align="center">
                    <asp:DataList ID="dlEntryList" Width="600" runat="server" AlternatingItemStyle-BackColor="#E6E6E6"
                        EnableViewState="false" OnItemCommand="View_ItemDetail" OnItemCreated="dlEntryList_OnItemCreated"
                        OnItemDataBound="dlEntryList_OnItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <td width="100" class="midgrey16b">
                                    Posted</td>
                                <td width="100" align="left" class="midgrey16b" colspan="2">
                                    Title</td>
                                <td width="20" class="midgrey16b" colspan="2" align="left">
                                    Manage</td>
                                <td width="20" class="midgrey16b" align="left">
                                    Publish</td>
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
										<%# DataBinder.Eval(Container.DataItem, "blog_dt", "{0: MM/dd}")%>
									</asp:Label>
                                </td>
                                <td align="left" nowrap>
                                    <asp:Label ID="Label3" runat="server" CssClass="dkgrey12b">	    
									    <%# DataBinder.Eval(Container.DataItem, "title")%>
								</asp:Label>
                                </td>
                                <td>
                                    &nbsp&nbsp</td>
                                <td align="left">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" CssClass="dkgrey12b"
                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' OnCommand="GetValues"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>edit</asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="true" CssClass="dkgrey12b"
                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' OnCommand="ViewPage"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>view</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp&nbsp</td>
                                <td align="left">
                                    <%--<asp:LinkButton id="chkPub" runat="server" Font-Underline="true" CssClass="controls" OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>delete</asp:LinkButton>--%>
                                    <asp:CheckBox ID="chkPublish" runat="server" CssClass="dkgrey12b" Checked='<%# GetPublishedStatus(DataBinder.Eval(Container.DataItem, "publish"))%>' />
                                    <asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                    </asp:DataList>

            </div>
            <div align="center">
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                            <asp:Label CssClass="dkgrey12b" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton></td>
                    </tr>
                </table>
                <div align="center">
                    <asp:Button ID="btnUpdate" class="btnGo" OnClick="btnUpdate_Click" runat="server"
                        Text="Update" /></div>
            </div>
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label>
                <div id="push">
            </div>
    </form> 
    </div>
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
