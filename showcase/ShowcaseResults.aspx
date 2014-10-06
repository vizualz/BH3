<%@ Page Language="c#" Codebehind="ShowcaseResults.aspx.cs" AutoEventWireup="True"
    Inherits="BoardHunt.showcase.ShowcaseResults" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Surf Product Showcase | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Keep up with new and unique surfboard and surfing products with Boardhunt’s Showcase." />
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />

    <script language="JavaScript" src="../include/js/bh.js" type="text/javascript"></script>

    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('img.Tips').cluetip({splitTitle: '|',clickThrough:     true});
            
       
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
        <form id="Form1" method="post" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" id="container">
                <div id="wrapper" align="center">
                    <!--left column-->
                    <div id="left" style="margin-right: 2px">
                        <br>
                        <br>
                        <br>
                        <asp:Panel runat="server" Width="132" ID="pnlFilter" BorderStyle="solid" BorderColor="#99CC33"
                            BorderWidth="2">
                            <table bgcolor="#defe99" width="132" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="white20b" align="center" bgcolor="#99CC33" bordercolor="#99CC33" height="25px">
                                        Search</td>
                                </tr>
                                <tr>
                                    <td height="20">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgreen12" align="left" height="15">
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
                                <asp:Panel ID="pnlFltSurf" Visible="false" runat="server">
                                    <tr>
                                        <td height="15">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgreen12" align="left" height="15">
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
                                        <td class="dkgreen12" align="left" height="15">
                                            &nbsp;Height</td>
                                    </tr>
                                    <tr>
                                        <td class="dkgreen12">
                                            &nbsp;<asp:TextBox ID="txtHtFt" runat="server" Width="20" Text="ft" CssClass="controls"></asp:TextBox>
                                            '&nbsp;
                                            <asp:TextBox ID="txtHtIn" CssClass="controls" runat="server" Text="in" Width="20"></asp:TextBox>&nbsp;"</td>
                                    </tr>
                                    <tr>
                                        <td height="15">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td class="dkgreen12" align="left" height="15">
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
                                        <td class="dkgreen12" align="left" height="15">
                                            &nbsp;Tail</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="controls">
                                            </asp:DropDownList></td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="dkgreen12" align="left" height="15">
                                        &nbsp;Price Range</td>
                                </tr>
                                <tr>
                                    <td class="dkgreen12">
                                        &nbsp;$
                                        <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                            CssClass="dkgrey10b"></asp:TextBox>
                                        to&nbsp;$
                                        <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkgrey10b" runat="server"
                                            Text="Max" Width="30"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td height="15">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="center" valign="bottom">
                                        &nbsp;<asp:Button ID="btnSearch" Text="Go" runat="server" CssClass="header" Width="50px"
                                            OnClick="btnSearch_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#99CC33" align="center" height="25px">
                                        <a class="white_white12" href="javascript:navTo('.com/contact.aspx?iD=4');">Want to
                                            Showcase?</a></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <br />
                        <br />
                        <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                    </div>
                    <!-- right column-->
                    <div id="right">
                        <br />
                        <br />
                        <br />
                        <%--BOOST HERE--%>
                        <bh:ShowBoost runat="server">
                        </bh:ShowBoost>
                    </div>
                    <!-- end right column-- >        
        <!--center column-->
                    <div id="center" class="ltgreen40b">
                        <div class="midgreen40b" align="center">
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            <asp:HyperLink CssClass="midgreen40b" ID="HypLoc" runat="server" NavigateUrl="../index.aspx"></asp:HyperLink>&nbsp;
                            <!-- <asp:HyperLink CssClass="midgreen40b" id="HypCat" runat="server" NavigateUrl="#" Enabled="false"></asp:HyperLink> -->
                            <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
                            <asp:Label CssClass="midgrey16b" ID="lblCount" runat="server"></asp:Label>
                        </div>
                        <div class="midgrey16b" align="center">
                            New and Unique Surf Products</div>
                        <div class="cathead" align="center">
                            &nbsp;</div>
                        <div class="cathead" align="center">
                            <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
                        <div align="center">
                            <table width="580">
                                <asp:DataList Width="580" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid"
                                    BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail">
                                    <HeaderTemplate>
                                        <tr>
                                            <td colspan="4" align="center">
                                                &nbsp;</td>
                                        </tr>
                                    </HeaderTemplate>
                                    <SeparatorTemplate>
                                        <hr color="#99CC33" />
                                    </SeparatorTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td class="header" nowrap width="175" align="left">
                                                            <asp:ImageButton Height="75" Width="75" ImageAlign="left" runat="server" ID="ImageButton2"
                                                                OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>'>
                                                            </asp:ImageButton>
                                                        </td>
                                                        <td align="left">
                                                            <table border="0">
                                                                <tr>
                                                                    <td class="cathead" align="left" colspan="2">
                                                                        <asp:LinkButton CssClass="midgrey_green20" ID="lnkTitle" runat="server" OnCommand="GetValues"
                                                                            CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										           <%# DataBinder.Eval(Container.DataItem, "AdTitle")%>
										           
										                
										           </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="midgrey10" align="left">
                                                                        posted on&nbsp;<span class="ltgreen10b"><%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd/yy}")%></span><br />
                                                                        <br />
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
                                                                    <td class="dkgrey12" colspan="2">
                                                                        <%# FormatDetails(DataBinder.Eval(Container.DataItem, "txtDetails"))%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <a href='http://www.malzook.com/showcase/ShowcaseDetails.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                                                            <span style='color: orange'>[+]</span></a>
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
                                                CssClass="controls" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;<asp:ImageButton
                                                    ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                                    runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton></td>
                                </tr>
                            </table>
                            <br>
                            <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                            <asp:HiddenField ID="hdnLocVal" Value="-1" runat="server" />
                            <%--TILEAD--%>
                            <!-- #include file="../include/ads/tileAd.htm" -->
                        </div>
                        <br />
                        <img src="../images/s1x1.gif" height="5">
                    </div>
                    <!-- end center div -->
                </div>
            </div>
            <div align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label></div>
            <div id="push">
            </div>
        </form>
    </div>
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <%--Google analytics--%>

    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
