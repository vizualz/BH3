<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardMatcher.aspx.cs" Inherits="BoardHunt.Labs.BoardMatcher" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Board Matcher - Boardhunt</title>

    <script type="text/javascript" src="../include/js/m1-2b.js"></script>

    <script type="text/javascript" src="../include/js/dropdown.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link href="../style/dropdown.css" type="text/css" rel="stylesheet" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <link href="../style/tips.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript">
function resetQuery()
{
    alert ("reset");
}
</script>
</head>
<body>
    <form id="form1" runat="server">
       <div id="main" align="center">
            <!-- #include file="../include/header2.aspx" -->
            <div align="center" id="container">
                <div id="wrapper" align="center">
                    <!--left column-->
                    <div id="left">
                        <br />
                        <br />
                        <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#669900"
                            BorderWidth="0">
                            Ads here
                        </asp:Panel>
                        <br />
                        <!-- Start: Ads -->
                        <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                    </div>
                    <!-- right column-->
                    <div id="right">
                        <br />
                        <br />
                        <br />
                        <br />
                        <%--BOOST HERE--%>
                        <bh:ShowBoost ID="boost1" runat="server"></bh:ShowBoost>
                    </div>
                    <!-- end right column-- >
        
                    <!--CENTER column-->
                    <div id="center">
                        <div class="midgrey18" align="center">
                        <asp:HyperLink runat="server" ID="lnkMenuRoot" CssClass="ltgreen_green26" NavigateUrl="List.aspx?iCat=1">Board Matcher</asp:HyperLink>
                            <span class="midgrey18">&nbsp;>&nbsp;</span>The Match
                        </div>
                        <div class="midgrey14" align="center">
                            Find your board.</div>
                            <br />                        
                        <div align="center">
                            <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" BorderWidth="0px"
                                BorderColor="#669900" BorderStyle="solid" Width="600px">
                                <table cellspacing="0" cellpadding="0" border="0" align="center" bgcolor="#ffffff">
                                    <tr>
                                        <td colspan="2" style="height:1px"><img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <!-- left side -->
                                            <table cellspacing="5">
                                                <tr>
                                                    <td>
                                                        <img src="../images/quad3.jpg" /></td>
                                                </tr>
                                            </table>
                                            </td>
                                            <!-- end left side -->
                    <!-- begin right side -->
                    <td>
                    
                            <table border="0" bgcolor="#DEFE93" width="142px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="white20b" colspan="2"  align="center" bgcolor="#669900" height="25px" style="width: 147px">
                                        Board Matcher</td>
                                </tr>
                                <tr>
                                    <td class="midorange10b" valign="top" colspan="2" align="center" bgcolor="#669900" bordercolor="#FF9900"
                                        height="15px" style="width: 147px">
                                        Show me the best board</td>
                                </tr>
                                <tr>
                                    <td height="15" style="width: 147px" colspan="2">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgreen14b" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Weight:&nbsp;</td>
                                    <td style="width: 147px" class="dkgrey10b" align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtWeight" runat="server" Width="30" CssClass="dkgrey10b"></asp:TextBox>
                                        lbs.
                                    </td>                                        
                                </tr>
                                <tr>
                                    <td height="10" colspan="2" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>                                
                                <tr>
                                    <td class="dkgreen14b" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Height:&nbsp;</td>
                                    <td style="width: 147px" align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtHeightFt" onkeyup="CountMyChars(txtHtFt,2)" OnClick="select()"
                                                runat="server" Width="15" Text="ft" CssClass="dkgrey10b"></asp:TextBox>'
                                            <asp:TextBox ID="txtHeightIn" onkeyup="CountMyChars(txtHtIn,2)" OnClick="select()" CssClass="dkgrey10b"
                                                runat="server" Text="in" Width="15"></asp:TextBox>"
                                        
                                    </td>  
                                </tr>
                                <tr>
                                    <td height="10" colspan="2" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                <td class="dkgreen14b">&nbsp;&nbsp;Experience:&nbsp;</td>
                                    <td bgcolor="#DEFE93">
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboExperience" Width="125" runat="server" CssClass="dkgrey10b">
                                        </asp:DropDownList>&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="10" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                <td>&nbsp;</td>
                                    <td bgcolor="#DEFE93">
                                        <asp:Button ID="btnSearch" Text="Go" runat="server"
                                            CssClass="dkgrey12b" Width="50px" OnClick="btnSearch_Click" />
                                    &nbsp;
                                    
                                        <a href="javascript:resetQuery();" style="text-decoration: underline">reset</a>
                                    </td>                                            
                                </tr>
                                <tr>

                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" height="5" style="width: 147px">
                                        &nbsp;</td>
                                </tr>
                            </table>                    
                    </td>
                    </tr>
                    <tr>
                        <td class="header" colspan="2">
                            <asp:Label ID="lblResult" runat="server"></asp:Label></td>
                    </tr>
                    </table> </asp:Panel>
                </div>

             
                <br /><br /><br />
                <%--TILEAD & FOOTER--%>
                <div align="center">
                <br /><br /><br />
                    <!-- #include file="../include/ads/tileAd.htm" -->
                    <div align="center" id="footer">
                        <!-- #include file="../include/footer.aspx" -->
                    </div>
                </div>
                <br />
                <br />
                </div>
                <!-- end center div -->
                </div>
                <div align="center">
                    <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                </div>
            </div>
        </div>
        <%--end main div--%>
        <asp:HiddenField ID="hdnQId" runat="server" />
        <asp:HiddenField ID="hndUserId" runat="server" Value="-1" />        
        <asp:HiddenField ID="hdnNotifyEmail" runat="server" />
        <%--Google analytics--%>
        <script type="text/javascript" src="../include/js/googles.js"></script>
    </form>
</body>
</html>
