<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shapers.ascx.cs" Inherits="BoardHunt.include.Controls.Shapers" %>

<asp:Panel runat="server" ID="pnlAllShapers" Width="148px" BorderWidth="0" BorderColor="#999999" ToolTip="See all the shapers">
    <asp:DataList ID="dlUpgrades" runat="server" Width="148px" CssClass="red_orange12u" RepeatDirection="Horizontal"
        RepeatColumns="1" RepeatLayout="Table" ItemStyle-HorizontalAlign="Center" BackColor="#333333">
        <HeaderTemplate>
            <div align="center">
            <table bgcolor="#333333">
                <tr>
                    <td align="center">
                        <span class="midorange18b">More Shapers</span><br />
                    </td>
                </tr>
            </table>
            </div>
            <br />
             <br />
        </HeaderTemplate>
        <ItemStyle HorizontalAlign="Right" />
        <ItemTemplate>
<%--            <asp:ImageButton runat="server" ID="imgBtnShaper" CssClass="white_white12" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "profilePic"))%>' />
            <br />--%>
            <asp:LinkButton ID="lnkShaper" runat="server" CssClass="white_white12" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                <%# DataBinder.Eval(Container.DataItem, "txtBrandName")%>&nbsp;<br />
                </asp:LinkButton>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Panel>
