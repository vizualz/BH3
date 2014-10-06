<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LBoards.ascx.cs" Inherits="BoardHunt.include.Controls.LBoards" %>
<asp:DataList ID="dlLatest" runat="server" RepeatLayout="Table" OnItemCommand="View_ItemDetail">
    <HeaderTemplate>
        <tr>
            <td align="left">
                <a href="SurfboardsForSale.aspx?iCat=1"><span class="ltgrey16b">New/Used Surfboards</span></a></td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <hr style="color:#666666" />
        <tr>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="GetValues" CssClass="orange_white12"
                    CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										    
                                            <%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
                                            <%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
                                            &nbsp;
                                            <%# FormatDetails(DataBinder.Eval(Container.DataItem, "txtBrand"), (int)22 )%>
                                            
                                            <%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
                                            
                                            <%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>&nbsp;
                                            
                                            <%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") + "&nbsp;&nbsp;" %>
                </asp:LinkButton>
            </td>
        </tr>
        <tr><td class="dkgrey10" align="left"><%# FormatTime(DataBinder.Eval(Container.DataItem, "dCreateDate"))%></td></tr>
    </ItemTemplate>
</asp:DataList>
