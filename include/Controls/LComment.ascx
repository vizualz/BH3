<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LComment.ascx.cs" Inherits="BoardHunt.include.Controls.LComment" %>
        <asp:DataList ID="dlComments" runat="server" RepeatLayout="Table" OnItemCommand="View_ItemDetail">
        <HeaderTemplate><tr><td align="left"><span class="ltgrey16b">Board Comments</span></td></tr></HeaderTemplate>
            <ItemTemplate>
            <hr style="color:#666666" />
            <tr><td align="left">
            <asp:LinkButton ID="lnkCmt" OnCommand="JumpTo" runat="server" CssClass="orange_white12"
            CommandName='<%# DataBinder.Eval(Container.DataItem, "entryId")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                    <%# FormatDetails(DataBinder.Eval(Container.DataItem, "txtComment"), (int)30)%>
                    </asp:LinkButton>
                        </td></tr>
        <tr><td class="dkgrey10" align="left"><%# FormatTime(DataBinder.Eval(Container.DataItem, "dPosted"))%></td></tr>
            </ItemTemplate>
        </asp:DataList>
