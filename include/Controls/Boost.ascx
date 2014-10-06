<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Boost.ascx.cs" Inherits="BoardHunt.include.Controls.Boost" %>

<asp:Panel runat="server" ID="pnlHotBoards" Width="140px" BorderWidth="0" BorderColor="#ff9900" ToolTip="You can boost your ads into this section when you purchase a PRO account">
    <asp:DataList ID="dlUpgrades" runat="server" Width="140px" CssClass="red_orange12u" RepeatDirection="Horizontal" style="background-image: url(../images/blue.png);"
        RepeatColumns="1" RepeatLayout="Table" ItemStyle-HorizontalAlign="Center">
        <HeaderTemplate>
            <div align="center">
            <table>
                <tr>
                    <td height="10px">
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="50px" align="center" valign="bottom" class="dkrgrey20b">
                        Featured Ads<br />
                        + <a class="white_white12" href="../../post_manager.aspx">my board</a>
                    </td>
                </tr>
            </table>
            </div>
            <br />
          
      
        </HeaderTemplate>
        <ItemTemplate>
            <asp:ImageButton runat="server" ID="imgBtnHotBoard" CssClass="dkgrey_orange12" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetBoostPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>' />
            <br />&nbsp;
            <asp:LinkButton ID="lnkBtnUpBrand" runat="server" CssClass="dkgrey_orange12" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                <%# DataBinder.Eval(Container.DataItem, "iHtFt")%>'<%# DataBinder.Eval(Container.DataItem, "iHtIn")%>"&nbsp;<%# DataBinder.Eval(Container.DataItem, "txtBrand")%>
                </asp:LinkButton>
            <br /> <br /> 
        </ItemTemplate>  
    </asp:DataList>
</asp:Panel>
