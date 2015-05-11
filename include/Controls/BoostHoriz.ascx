<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoostHoriz.ascx.cs" Inherits="BoardHunt.include.Controls.BoostHoriz" %>


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
	                    <asp:Panel runat="server" ID="pnlHotBoards" ToolTip="Upgrade to PRO or Boost your board!">
	                        <asp:DataList ID="dlUpgrades" runat="server" RepeatDirection="Horizontal" Style="background-color: #FFFFFF;"
	                            RepeatColumns="10" ItemStyle-HorizontalAlign="Center" RepeatLayout="Table" >
	                            <HeaderTemplate>
	                                <div align="right">
	                                    <table>
	                                        <tr>
	                                        	<td class="orange_ltgreen12u">&nbsp;</td>
	                                            <td height="25px" align="left" valign="bottom" class="dkrgrey16">
	                                                <a class="orange_ltgreen12u" href="../../post_manager.aspx">add my board</a>&nbsp;&nbsp;
	                                            </td>
	                                        </tr>
	                                    </table>
	                                </div>
	                            </HeaderTemplate>
	                            <ItemTemplate>
	                            <div style="border: 0px solid black; height:204px; width: 158px; margin-top:2px" >
	                            <div style="border: 0px solid red; height:154px; width: 154px; background: url(images/blur3.jpg);
    background-size: 154px 154px;
    background-repeat: no-repeat;">

	                                <asp:ImageButton Style="border:0px solid grey" runat="server" ID="imgBtnHotBoard" Height="151px" Width="151" CssClass="dkgrey_orange12" OnCommand="ShowItem"
	                                    CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
	                                    ImageUrl='<%# SetBoostPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>' />
	                                <br />
								</div>
	                                <asp:LinkButton ID="lnkBtnUpBrand" runat="server" CssClass="orange_dkorange18" OnCommand="ShowItem"
	                                    CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
					                <%# DataBinder.Eval(Container.DataItem, "iHtFt")%>'<%# DataBinder.Eval(Container.DataItem, "iHtIn")%>"&nbsp;<%# trimIt(DataBinder.Eval(Container.DataItem, "txtBrand"))%>
					                </asp:LinkButton>
					                <br />
	                                &nbsp; <span class="midgrey10top"></span> 
	                                <a class="dkgrey_white10" href='http://www.malzook.com/surfboard.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD") %>'>
	                                    <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>
	                                    &nbsp;Views</a>
	                                <br />
	                                <br />

	                                </div>
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
    <!--inner slider ends--->  
    </div>
    <div class="loading" align="center">
	    Loading. Please wait.<br />
	    <br />
	    <img src="../../images/loading.gif" alt="" />
	</div>
<!--move slider ends-->
</div>	    





