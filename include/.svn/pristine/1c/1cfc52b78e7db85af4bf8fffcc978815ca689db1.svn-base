<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LQuestions.ascx.cs" Inherits="BoardHunt.include.Controls.LQuestions" %>
        <asp:DataList ID="dlSpotLight" runat="server" RepeatLayout="Table" OnItemCommand="View_ItemDetail">
        <HeaderTemplate>
        <div align="left" style="background-color: #FFFFFF;">
        <a href="Qna/List.aspx" class="dkrgrey_orange20">&nbsp;Ask-A-Pro&nbsp;</a>
         
        </div>
        </HeaderTemplate>
            <SeparatorTemplate>
                        <hr style="color: #fff; background-color: #fff; border: 1px dotted #333333; border-style: none none dotted; "/>
        

            </SeparatorTemplate>
            <FooterTemplate>
                        <hr style="color: #fff; background-color: #fff; border: 1px dotted #333333; border-style: none none dotted; "/>
                    
            </FooterTemplate>
            <ItemTemplate>
            <div style="border-left:solid 3px #ffffff; height:3px;">
            <div style="border-left:solid 3px #ffffff; height:3px;">
            <a class="dkrgrey_orange12" href='http://www.malzook.com/Qna/QDetails.aspx?q=<%# DataBinder.Eval(Container.DataItem, "QiD")%>'>&nbsp;<%# FormatDetails(DataBinder.Eval(Container.DataItem, "Question"), (int)20)%></a>
                       
                        
                        <%--<tr><td class="dkgrey10" align="left">Asked by&nbsp;
                        <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>
                        </td></tr>--%>
            </div>
            </div>
            </ItemTemplate>
            <ItemStyle Height="49px" />
        </asp:DataList>
