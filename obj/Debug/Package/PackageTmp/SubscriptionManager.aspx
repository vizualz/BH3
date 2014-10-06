<%@ Page Language="c#" Codebehind="SubscriptionManager.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.SubscriptionManager" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Log Into Boardhunt To Sell Boarding Gear</title>
    <script type="text/javascript" src="include/js/m1-2b.js"></script>
    <script type="text/javascript" src="include/js/dropdown.js"></script>
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link href="style/dropdown.css" type="text/css" rel="stylesheet"/>
    <link href="style/global.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form class="header" id="Form1" enctype="multipart/form-data" runat="server">
        <div id="main" align="center">
            <!-- #include file="include/header2.aspx" -->
            <span class="midorange26b">SUBSCRIPTIONS</span>
            <br />
            <br />
					<table border="0" width="100%">
					<asp:datalist id="dlEntryList" width="600" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail"
						OnItemDataBound="dlEntryList_OnItemDataBound" AlternatingItemStyle-BackColor="#F0F0F0">
						<HeaderTemplate>
							
								<tr>
									<td class="midgrey16b">Type</td>
                                    <td class="midgrey16b" nowrap>Start Date&nbsp;</td>
									<td class="midgrey16b">Price&nbsp;</td>
									<td class="midgrey16b">Status&nbsp;</td>
									<td class="midgrey16b">Manage&nbsp;</td>
								</tr>
								<tr>
									<td colspan="5" bgcolor="#006600"><img src="images/s1x1.gif"></td>
								</tr>
						</HeaderTemplate>
						<ItemTemplate>
							
								<tr <%#(Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %> >
									<%--Description--%>
									<td class="midgrey12" width="50">
										<%# DataBinder.Eval(Container.DataItem, "name")%>&nbsp;
									</td>
									<%--Start Date--%>
                                    <td class="midgrey12">                                        
										<%# DataBinder.Eval(Container.DataItem, "dStartDate", "{0: MM/dd}") %>
									</td>

                                    <%--Price--%>
                                    <td class="midgrey12">                                        
										<%# DataBinder.Eval(Container.DataItem, "amount") %>
									</td>

									<%--Status--%>
									<td class="midgrey12"><%# DataBinder.Eval(Container.DataItem, "iStatus")%></td>

									<%--Manage--%>
									<td align="left" nowrap>
										<asp:Button runat="server" Text="Buy" ForeColor="006600" />
									&nbsp;
										<asp:LinkButton id="lnkCancel" runat="server" Font-Underline="true" CssClass="midgrey_orange12" OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iStatus")%>'>Cancel</asp:LinkButton>
									</td>
								</tr>
							
						</ItemTemplate>
						<HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
					</asp:datalist>
				    </table> 
				    <asp:Label ID="lblStatus" runat="server"></asp:Label>           
        </div>
    </form>
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
