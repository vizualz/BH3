<%@ Page Language="c#" Codebehind="BlogResults.aspx.cs" AutoEventWireup="false" EnableEventValidation="false" Inherits="BoardHunt.Blog.BlogResults" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Surfboard Blog Featuring Tips & Highlights | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    <meta name="description" content="Boardhunt Blog. Keep up to date on Surfboard Tips, Website Updates, and related Highlights with the Boardhunt Blog."/>
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <script type="text/javascript">
    $(document).ready(function() {
    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    });
    </script>

    <script type="text/javascript">
        function SaveBG(val)
        {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            hdnCtl.value = val;
        }
         
        function GetBG()
        {
            var hdnCtl;
            hdnCtl = document.getElementById('hdnBackColor');
            return hdnCtl.value;
        }
        
        function SetHdnLocVal()
        {
            
            var hdnCtl;
            var hdnCtl2;
            hdnCtl = document.getElementById('hdnLocVal');
            hdnCtl2 = document.getElementById('cboLocation');
            hndCtl.value = hdnCtl2.value;
        }
    </script>

</head>
<body>
        <div id="main" align="center">
    <form id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
        <div align="center" id="container">
            <div id="wrapper" align="center" style="width: 1100px">
                <!--left column-->
                <div id="left" style="margin-right: 2px">
                    <br>
                    <br>
                    <br>
                    <asp:Panel runat="server" Width="132" ID="pnlFilter" BorderStyle="solid" BorderColor="#999966"
                        BorderWidth="3">
                        <table border="0" bgcolor="#cccc99" width="132" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="hometext" align="center" bgcolor="#999966" bordercolor="#999966" height="25px">
                                    SMART SEARCH</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td class="postdetail" align="left" height="15">
                                    &nbsp;Keyword(s)</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="125" CssClass="controls"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="15">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <%--                    <tr>
                        <td class="postdetail" align="left" height="15">
                            &nbsp;Location</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:DropDownList ID="cboLocation" Visible="false" Width="125" runat="server" CssClass="controls">
                            </asp:DropDownList>
                        </td>
                    </tr> --%>
                            <asp:Panel ID="pnlFltSurf" Visible="false" runat="server">
                                <tr>
                                    <td height="15">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="postdetail" align="left" height="15">
                                        &nbsp;Board Type</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:DropDownList ID="cboBoardType" Width="125" runat="server" CssClass="controls">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td height="15">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="postdetail" align="left" height="15">
                                        &nbsp;Height</td>
                                </tr>
                                <tr>
                                    <td class="postdetail">
                                        &nbsp;<asp:TextBox ID="txtHtFt" runat="server" Width="20" Text="ft" CssClass="controls"></asp:TextBox>
                                        '&nbsp;
                                        <asp:TextBox ID="txtHtIn" CssClass="controls" runat="server" Text="in" Width="20"></asp:TextBox>&nbsp;"</td>
                                </tr>
                                <tr>
                                    <td height="15">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="postdetail" align="left" height="15">
                                        &nbsp;Fins</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:DropDownList ID="cboFins" runat="server" CssClass="controls">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td height="15">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="postdetail" align="left" height="15">
                                        &nbsp;Tail</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="controls">
                                        </asp:DropDownList></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td height="5">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td class="postdetail" align="left" height="15">
                                    &nbsp;Price Range</td>
                            </tr>
                            <tr>
                                <td class="postdetail">
                                    &nbsp;$
                                    <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                        CssClass="controls"></asp:TextBox>
                                    to&nbsp;$
                                    <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="controls" runat="server"
                                        Text="Max" Width="30"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="20">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td align="center" valign="bottom">
                                    &nbsp;<asp:Button ID="btnSearch" Text="Go" runat="server" CssClass="header" Width="50px" /></td>
                            </tr>
                            <%--                    <tr>
                        <td align="center">
                            &nbsp;<a href="advanced_search.aspx" class="advanced_search">More Search Options</a></td>
                    </tr>--%>
                            <tr>
                                <td height="5">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                        </table>
                    </asp:Panel>

                    <!-- #include file="../include/ads/SkyScraperAd.htm" -->

                </div>
                
                <%--right column--%>
                <div id="right">
                    <br />
                    <br />
                    <br />                
                    <%--BOOST HERE--%>
                    <bh:ShowBoost ID="ShowBoost1" runat="server"></bh:ShowBoost>
                </div>                
                <%--end right column--%>
                
                <!--center column-->
                <div id="center" class="midorange40b" width="700">
                    <div class="midorange40b" align="center">
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        <asp:HyperLink CssClass="HeaderLink" ID="HypLoc" runat="server" NavigateUrl="../index.aspx"></asp:HyperLink>
                        <!-- <asp:HyperLink CssClass="HeaderLink" id="HypCat" runat="server" NavigateUrl="#" Enabled="false"></asp:HyperLink> -->
                        <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
                        <asp:Label CssClass="midorange14b" ID="lblCount" runat="server"></asp:Label>
                    </div>
                    <div>
                     <table>
                        <tr>
                            <td class="midorange14" align="left">
                                Tips & updates
                            </td>
                            
                        </tr>
                    </table>
                    </div>
                    <div class="cathead" align="center">
                        &nbsp;</div>
                    <div class="cathead" align="center">
                        <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
                    <div align="center">
                        <table width="670">
                            <asp:DataList Width="650" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid"
                                BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail">
                                <HeaderTemplate>
                                    <tr>
                                        <td colspan="4" align="center">
                                            &nbsp;</td>
                                    </tr>
                                </HeaderTemplate>
                                <SeparatorTemplate>
                                    <hr color="#ff9900" />
                                </SeparatorTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="header" nowrap width="175" align="left">
                                                        <asp:ImageButton Height="150" Width="150" ImageAlign="left" runat="server" ID="ImageButton2"
                                                            OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "cat"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>'>
                                                        </asp:ImageButton>
                                                    </td>
                                                    <td align="left">
                                                        <table border="0">
                                                            <tr>
                                                                <td class="cathead" align="left" colspan="2">
                                                                    <asp:LinkButton CssClass="dkgrey_orange20" ID="lnkTitle" runat="server" OnCommand="GetValues"
                                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'>
										           <%# DataBinder.Eval(Container.DataItem, "title")%>
										           
										                &nbsp;
                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10px" class="midgrey10" align="left">
                                                                    posted on <span class="midorange10b">
                                                                        <%# DataBinder.Eval(Container.DataItem, "blog_dt", "{0: MM/dd/yy}")%>
                                                                    </span>by boardhunt&nbsp;&nbsp;<br />Views:&nbsp;<span class="midorange10b"><%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%></span><br />
                                                                    Comments:&nbsp;<span class="midorange10b"><%# DataBinder.Eval(Container.DataItem, "COUNTER")%></span>
                                                                    
                                                                    <br />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--										      <tr>
                                                    <td class="cathead2" valign="top">
                                                        <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										
										                <%# DataBinder.Eval(Container.DataItem, "txtBrand") %>
										                </asp:LinkButton> 
										           </td>
										      </tr>--%>
                                                            <tr>
                                                                <td class="midgrey10" colspan="2">
                                                                    <%# FormatDetails(DataBinder.Eval(Container.DataItem, "blog"))%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                										           <a href='http://www.malzook.com/Blog/BlogDetails.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD")%>'><span style='color:orange'>[+]</span></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:DataList></table>
                        <table border="0">
                            <tr>
                                <td height="20">
                                    <img src="../images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                        runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;<asp:Label
                                            CssClass="dkgrey12" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;<asp:ImageButton
                                                ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                                runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton></td>
                            </tr>
                        </table>
                        <br />
                        <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                        <asp:HiddenField ID="hdnLocVal" Value="-1" runat="server" />
                        
                        <!-- #include file="../include/ads/tileAd.htm" -->
                        
                    </div>
                    <br />
                    <img src="../images/s1x1.gif" height="5">
                </div>
                <!-- end center div -->
            </div>
        </div>
            <div id="push">
            </div>
    <div align="center">
        <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label></div>                    
    </form>
        </div>

    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>    

    <script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script type="text/javascript">
var pageTracker = _gat._getTracker("UA-2548219-1");
pageTracker._initData();
pageTracker._trackPageview();
    </script>

</body>
</html>
