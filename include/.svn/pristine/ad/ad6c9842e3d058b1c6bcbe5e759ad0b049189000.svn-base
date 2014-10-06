<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoostHoriz.ascx.cs" Inherits="BoardHunt.include.Controls.BoostHoriz" %>

<link href="../../style/global.css" rel="stylesheet" type="text/css" />


<%--style="width: 1285px; margin-left: 0px; height: 17px; margin-bottom: 0px;"--%>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="move_slider">
    <div class="inner_slider">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div class="left_arrrow">
            <asp:ImageButton ID="btnPrev" OnClientClick="onNext();" runat="server" ImageUrl="~/images/left_arrow.png" OnClick="btnPrev_Click">
            </asp:ImageButton>
            </div>
            <div class="images_area">
                    <asp:Panel runat="server" ID="pnlHotBoards" ToolTip="Boost your board to show in this space.  It's $5 per ad or it's inclusive with PRO.  Ads will rotate until sold.">
                        <asp:DataList ID="dlUpgrades" runat="server" RepeatDirection="Horizontal" Style="background-color: #ECF8E0;"
                            RepeatColumns="10" ItemStyle-HorizontalAlign="Center" RepeatLayout="Table" >
                            <HeaderTemplate>
                                <div align="right">
                                    <table>
                                        <tr>
                                            <td height="25px" align="left" valign="bottom" class="dkrgrey16">
                                                <a class="orange_ltgreen12u" href="../../post_manager.aspx">add my board</a>&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnUpBrand" runat="server" CssClass="dkgrey_orange12" OnCommand="ShowItem"
                                    CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                <%# DataBinder.Eval(Container.DataItem, "iHtFt")%>'<%# DataBinder.Eval(Container.DataItem, "iHtIn")%>"&nbsp;<%# DataBinder.Eval(Container.DataItem, "txtBrand")%>
                </asp:LinkButton>
                                <asp:ImageButton runat="server" ID="imgBtnHotBoard" CssClass="dkgrey_orange12" OnCommand="ShowItem"
                                    CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                    ImageUrl='<%# SetBoostPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>' />
                                <br />
                                &nbsp; <span class="midgrey10top">views:</span> <a class="dkgrey_white10" href='http://www.malzook.com/surfboard.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD") %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%></a>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                      </asp:Panel>
                </div>
                <!--images area ends-->
            <div class="right_arrrow">
            <asp:ImageButton ID="btnNext" OnClientClick="onNext();"  runat="server" ImageUrl="~/images/right_arrow.png"
                OnCommand="btnNext_Click" />
        </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnPrev" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
       
    </div>
    <!--innder slider ends--->
    <!--move slider ends-->
    <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="../../images/loading.gif" alt="" />
</div>
</div>





