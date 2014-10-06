<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LBlogs.ascx.cs"
    Inherits="BoardHunt.include.Controls.LBlogs" %>
<asp:DataList ID="dlLBlogs" runat="server" RepeatLayout="Table" OnItemCommand="View_ItemDetail">
    <HeaderTemplate>
        <div align="left" style="background-color: #FFFFFF;">
        <a href="http://www.malzook.com/Blog/BlogResults.aspx" class="dkrgrey_orange20">&nbsp;Blogs&nbsp;</a>
        
        </div>        
    </HeaderTemplate>
            <SeparatorTemplate>
                        <hr style="color: #fff; background-color: #fff; border: 1px dotted #333333; border-style: none none dotted; "/>
            </SeparatorTemplate> 
               
    <ItemTemplate>
            <div style="border-left:solid 3px #ffffff; height:10px;">
            <div style="border-left:solid 3px #ffffff; height:10px;">
                <a class="dkrgrey_orange12" href='http://www.malzook.com/Blog/BlogDetails.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "id")%>'>&nbsp;<%# FormatDetails(DataBinder.Eval(Container.DataItem, "title"), (int)20)%></a>
              </div>
              </div>   
       
        <%--<tr><td class="dkgrey10" align="left">Posted on&nbsp;<%# DataBinder.Eval(Container.DataItem, "blog_dt", "{0: MM/dd}") %></td></tr>--%>
    </ItemTemplate>
            <FooterTemplate>
                        <hr style="color: #fff; background-color: #fff; border: 1px dotted #333333; border-style: none none dotted; "/>
               </FooterTemplate> 
            <ItemStyle Height="49px" />               
</asp:DataList>
