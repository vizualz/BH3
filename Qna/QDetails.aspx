<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    Codebehind="QDetails.aspx.cs" Inherits="BoardHunt.Qna.QDetails" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Surfboard Help | Boardhunt</title>
    <meta name="description" content="Give or get advice on surfboards and surfing." />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
    $(document).ready(function() {
    
    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('#toggle2').hover(
          function () {
              $('#pnlLogin').slideToggle('slow', function() {
              });
          }, 
          function () {
              
          }
        );
     $('#pnlLogin').hide();         
    });
    </script>

<!-- Google ads: Leader -->

<script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
</script>
<script type='text/javascript'>
    GS_googleAddAdSenseService("ca-pub-0007702553564747");
    GS_googleEnableAllServices();
</script>
<script type='text/javascript'>
    GA_googleAddSlot("ca-pub-0007702553564747", "Leader");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>


<!-- Google ads: Wide Skyscraper -->

<script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
</script>
<script type='text/javascript'>
    GS_googleAddAdSenseService("ca-pub-0007702553564747");
    GS_googleEnableAllServices();
</script>
<script type='text/javascript'>
    GA_googleAddSlot("ca-pub-0007702553564747", "Wide_Skyscraper");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>

<!-- Google ads: Box -->

<script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>
</script>
<script type='text/javascript'>
    GS_googleAddAdSenseService("ca-pub-0007702553564747");
    GS_googleEnableAllServices();
</script>
<script type='text/javascript'>
    GA_googleAddSlot("ca-pub-0007702553564747", "Box");
</script>
<script type='text/javascript'>
    GA_googleFetchAds();
</script>

</head>
<body>
    <div id="main" align="center">
        <form id="form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" id="container">
                <div id="wrapper" align="center">
                    <!--left column-->
                    <div id="left">
                        <br />
                        <br />
                        <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#669900"
                            BorderWidth="0">
                            <table border="0" bgcolor="#DEFE93" width="142px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="white20b" align="center" bgcolor="#669900" height="25px" style="width: 147px">
                                        Filters</td>
                                </tr>
                                <tr>
                                    <td class="midorange10b" valign="top" align="center" bgcolor="#669900" bordercolor="#FF9900"
                                        height="15px" style="width: 147px">
                                        Hunt it down</td>
                                </tr>
                                <tr>
                                    <td height="15" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgreen14b" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Keywords</td>
                                </tr>
                                <tr>
                                    <td style="width: 147px">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="125" CssClass="dkgrey10b"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="midorange10b" align="left" style="height: 10px; width: 147px;">
                                        &nbsp;&nbsp;&nbsp;e.g. "merrick"</td>
                                </tr>
                                <tr>
                                    <td height="10" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgreen14b" align="left" height="15" style="width: 147px">
                                        &nbsp;&nbsp;Seller</td>
                                </tr>
                                <tr>
                                    <td style="width: 147px">
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboPostingType" Width="125" runat="server" CssClass="dkgrey10b">
                                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Commercial"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Non-Commercial"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="dkgreen14b" align="left" height="15" style="width: 147px">
                                        &nbsp;&nbsp;Area</td>
                                </tr>
                                <tr>
                                    <td style="width: 147px">
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="125" runat="server" CssClass="dkgrey10b">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlFltSurf" runat="server">
                                    <tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15">
                                            &nbsp;&nbsp;Boards</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboBoardType" Width="125" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15">
                                            &nbsp;&nbsp;Height</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen14b">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtHtFt" onkeyup="CountMyChars(txtHtFt,2)" OnClick="select()"
                                                runat="server" Width="15" Text="ft" CssClass="dkgrey10b"></asp:TextBox>'
                                            <asp:TextBox ID="txtHtIn" onkeyup="CountMyChars(txtHtIn,2)" OnClick="select()" CssClass="dkgrey10b"
                                                runat="server" Text="in" Width="15"></asp:TextBox>" <span style="font: 10px Trebuchet">
                                                    to</span>&nbsp;
                                            <asp:TextBox ID="txtHtFtMax" onkeyup="CountMyChars(this,2)" runat="server" OnClick="select()"
                                                CssClass="dkgrey10b" Text="ft" Width="15"></asp:TextBox>'
                                            <asp:TextBox ID="txtHtInMax" onkeyup="CountMyChars(this,2)" OnClick="select()" CssClass="dkgrey10b"
                                                runat="server" Text="in" Width="15"></asp:TextBox>"
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15">
                                            &nbsp;&nbsp;Fins</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" align="left">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboFins" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" height="10">
                                            <img src="../images/s1x1.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15">
                                            &nbsp;&nbsp;Tail</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#DEFE93" align="left">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="dkgrey10b">
                                            </asp:DropDownList></td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td bgcolor="#DEFE93" height="10" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15" style="width: 147px">
                                        &nbsp;&nbsp;Price</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" class="dkgreen14b" style="width: 147px">
                                        &nbsp;&nbsp;$
                                        <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                            CssClass="dkgrey10b"></asp:TextBox>
                                        to&nbsp;$
                                        <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkgrey10b" runat="server"
                                            Text="Max" Width="30"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" height="20" style="width: 147px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" align="center" valign="bottom" style="width: 147px">
                                        &nbsp;<asp:Button ID="btnSearch" OnClientClick="SetHdnLocVal()" Text="Go" runat="server"
                                            CssClass="dkgrey12b" Width="50px" OnClick="btnSearch_Click" /></td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 147px">
                                        <a href="javascript:resetFilter()" style="text-decoration: underline">reset</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#DEFE93" height="5" style="width: 147px">
                                        &nbsp;</td>
                                </tr>
                            </table>
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
                        <bh:ShowBoost ID="boost1" runat="server">
                        </bh:ShowBoost>
                    </div>
                    <!-- end right column-- >
        
                    <!--CENTER column-->
                    <div id="center">
                        <div class="ltgreen14" align="center">
                            <span class="ltgreen26b">Share Knowledge</span></div>
                        <div class="midgrey18" align="center">
                            <asp:HyperLink runat="server" ID="lnkMenuRoot" CssClass="green_orange14" NavigateUrl="List.aspx?iCat=1">Back to list of questions</asp:HyperLink>
                            <span class="midgrey18"></span>
                        </div>
                        <br />
                        <div align="center">
                            <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" BorderWidth="0px"
                                BorderColor="#669900" BorderStyle="solid" Width="600px">
                                <table cellspacing="0" cellpadding="0" border="0" align="center" bgcolor="#ffffff">
                                    <tr>
                                        <td colspan="2" style="height: 1px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <!-- left side -->
                                            <table cellspacing="5">
                                                <tr>
                                                    <td>
                                                        <img src="../images/qna.jpg" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <!-- end left side -->
                                        <!-- begin right side -->
                                        <td>
                                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
                                                <%--<tr>
                                                <td height="20px" width="35%" class="big_md_grnb" align="left">
                                                    Category:&nbsp;</td>
                                                <td class="big_md_grn" align="left" width="65%">
                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                                                <td bgcolor="#ffffff">&nbsp;
                                                    </td>
                                            </tr> --%>
                                                <tr>
                                                    <td bgcolor="#f0f0f0">
                                                        &nbsp;&nbsp;</td>
                                                    <td align="left" width="90%" bgcolor="#f0f0f0">
                                                        <br />
                                                        <asp:Label ID="lblQuestion" CssClass="dkgrey24" runat="server"></asp:Label><br />
                                                    </td>
                                                    <td bgcolor="#f0f0f0">
                                                        &nbsp;&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" bgcolor="#f0f0f0" colspan="4">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="ltgrey10b" align="left" colspan="3">
                                                        <asp:Label ID="lblDetailsData" runat="server" Width="390px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td height="20px" colspan="3" valign="top" class="ltgrey10b" align="left">
                                                        by&nbsp;<asp:LinkButton ID="lnkEmailData" runat="server" CssClass="ltgreen_green10"
                                                            Enabled="false"></asp:LinkButton>
                                                        on&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" colspan="3">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" colspan="3" class="midgrey14" align="left">
                                                        Tags:</td>
                                                </tr>
                                                <tr>
                                                    <td height="20px" colspan="3" valign="top" class="ltgreen12" align="left">
                                                        <asp:Label ID="lblTags" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" colspan="3" class="midgrey14" align="left">
                                                        Views:&nbsp;<span class="ltgreen12"><asp:Label ID="lblViews" runat="server"></asp:Label></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header" colspan="2">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <!-- Begin Comments -->
                        <br />
                        <div align="center" style="width:580px">
                            <div class="ltgreen24b" align="left">
                                &nbsp;&nbsp;<asp:Label ID="lblCommentCount" class="ltgreen24b" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label runat="server" ID="lblLogin"></asp:Label>
                                <hr />
                            </div>
                            <asp:Panel runat="server" ID="pnlComments">
                                <table width="580" cellpadding="0" cellspacing="0">
                                    <asp:DataList ID="dlCommentList" Width="580" RepeatLayout="Table" BorderColor="#669900"
                                        CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="0" runat="server"
                                        EnableViewState="true" OnItemDataBound="dlCommentList_OnItemDataBound">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr style="background-color: #FFFFFF">
                                                <td colspan="4" align="left">
                                                    <img height="64" width="64" src='<%# FormatPicPath(DataBinder.Eval(Container.DataItem, "userDir"),DataBinder.Eval(Container.DataItem, "profilePic"))%>'
                                                        alt="profilepic">
                                                    <span class="ltgrey10">&nbsp;&nbsp;by</span>&nbsp; <span class="ltgreen12">
                                                        <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>
                                                    </span>&nbsp;<span class="ltgrey10">on
                                                        <%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd/yy}")%>
                                                        &nbsp; </span>
                                                </td>
                                            </tr>
                                            <tr style="height: 15">
                                                <td colspan="4" align="left" style="height: 15; background-color: #FFFFFF">
                                                    <img src="../images/Bubble.jpg" style="height: 15" alt="bubble" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkgrey12b" style="background-color: #F0F0F0">
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td border="0" cellpadding="10" align="left" class="dkgrey12" style="width: 250;
                                                    background-color: #F0F0F0"">
                                                    <br />
                                                    <%# DataBinder.Eval(Container.DataItem, "Answer") %>
                                                </td>
                                                <td class="dkgrey12b" style="background-color: #F0F0F0">
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkgrey12b" style="background-color: #F0F0F0">
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td class="dkgrey12" style="background-color: #F0F0F0; width: 25;" valign="middle"
                                                    align="left">
                                                    <asp:ImageButton runat="Server" ImageAlign="Middle" ID="imgBtnYes" Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "ResponseId"))%>'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD") %>' ImageUrl="../images/thumbsup_off.gif"
                                                        OnClick="imgBtnYes_Click" />&nbsp;<%# DataBinder.Eval(Container.DataItem, "VoteY") %>&nbsp;up &nbsp;
                                                    <asp:ImageButton runat="Server" ImageAlign="Middle" ID="imgBtnNo" Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "ResponseId"))%>'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD") %>' ImageUrl="../images/thumbsdown_off.gif"
                                                        OnClick="imgBtnNo_Click" />&nbsp;<%# DataBinder.Eval(Container.DataItem, "VoteN") %>&nbsp;down
                                                    <br />
                                                </td>
                                                <td class="dkgrey12b" style="background-color: #F0F0F0" align="right">
                                                    &nbsp;
                                                </td>
                                                <td colspan="4" align="left" style="background-color: #FFFFFF">
                                                    <br />
                                                    &nbsp&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lnkFlagAbuse" CssClass="grey_dkgrey10"
                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iD") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestId") %>'
                                                        OnClick="lnkFlagAbuse_Click"><u>abuse</u>&nbsp;</asp:LinkButton>
                                                    <asp:HiddenField runat="server" ID="hdnAllowVoting" Value='<%# DataBinder.Eval(Container.DataItem, "ResponseId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnAbuseFlg" Value='<%# DataBinder.Eval(Container.DataItem, "AbuseFlg") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dkgrey12b" align="right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList></table>
                                <br />
                                <%--Login Message Panel--%>
                                <asp:Panel ID="pnlLoginMsg" runat="server" CssClass="dkgrey14" Visible="true">
                                    &nbsp;<span id="login_spot"></span><a class="ltgreen_orange14" id="toggle2" href="#">Login</a> to answer or vote.
                                </asp:Panel>
                                <%--Slideout Login Panel--%>
                                <asp:Panel ID="pnlLogin" runat="server" Width="250px" BackColor="#ffffff" BorderColor="#FF9900"
                                    BorderWidth="1px" Visible="true" DefaultButton="btnLogin">
                                    <table>
                                        <tr>
                                            <td height="50px" align="right" class="dkgrey14">
                                                E-mail:&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtUsername" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="dkgrey14">
                                                Password:&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td height="50px" align="left" valign="middle">
                                                <asp:Button ID="btnLogin" Text="Login" CssClass="dkrgrey14" runat="server" OnClick="btnLogin_Click"
                                                    valign="middle" />
                                                &nbsp;<span class="midorange14">or </span>&nbsp;<a href="../register_user.aspx" class="dkgrey_white14">join</a>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <%--Comment Box--%>
                                <asp:Panel ID="pnlCommentBox" runat="server" Visible="false" BackColor="#FFFFFF"
                                    BorderColor="#99CC33" BorderWidth="1">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="50px" align="left">
                                                <asp:Label ID="lblCommentBoxHeader" runat="server" CssClass="dkrgrey14" Text="Type your answer click submit:"></asp:Label>
                                            </td>
                                            <td align="right" class="ltgreen16b">
                                                <asp:Label runat="server" ID="lblTxtCount">1000</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <asp:TextBox ID="txtComment" runat="server" CssClass="dkgrey14" onkeydown="javascript:CharCountAndDisplay(this.form.txtComment,1000,'lblTxtCount')"
                                                    Height="120px" Width="352px" MaxLength="1000" Rows="10" TextMode="MultiLine"
                                                    TabIndex="70"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50px">
                                                <asp:CheckBox ID="chkNotify" CssClass="dkrgrey14" Text=" Notify me when anyone answers"
                                                    runat="server"></asp:CheckBox></td>
                                            <td align="right">
                                                <asp:Button align="right" ID="btnPostComment" Text="Submit" runat="server" CssClass="dkrgrey14"
                                                    OnClick="btnPostComment_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                        <br />
                        <br />
                        <br />
                        <%--TILEAD & FOOTER--%>
                        <div align="center">
                            <br />
                            <!-- #include file="../include/ads/tileAd.htm" -->
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
            <asp:HiddenField ID="hdnQId" runat="server" />
            <asp:HiddenField ID="hndUserId" runat="server" Value="-1" />
            <asp:HiddenField ID="hdnNotifyEmail" runat="server" />
            <div id="push">
            </div>
        </form>
    </div>
    <br />
    <div align="center" id="footer">
        <!-- #include file="../include/footer.aspx" -->
    </div>
    <%--Google analytics--%>

    <script type="text/javascript" src="../include/js/googles.js"></script>

</body>
</html>
