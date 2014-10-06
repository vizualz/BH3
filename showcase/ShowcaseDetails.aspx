<%@ Page Codebehind="ShowcaseDetails.aspx.cs" Language="c#" AutoEventWireup="True" MaintainScrollPositionOnPostback="true" Inherits="BoardHunt.showcase.ShowcaseDetails" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Surf Product Review - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
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
            
        $('#toggle2').hover(
              function () {
                  $('#pnlLogin').slideToggle('slow', function() {
                    // Animation complete.
                  });
              }, 
              function () {
            
              }
            );
         $('#pnlLogin').hide();                        
        });
    </script>
    <script type="text/javascript" defer="defer">
        function PreLoadImgs()
        {
            var i;
            var imgArray = new Array();
            
            for (i=0;i<=3;i++)
            {
                imgArray[i] = "hdnPicVal" + (i+1);
                
                var ctl = document.getElementById("hdnPic" + (i+1) + "URL");
                
                if (ctl != null)
                {
                imgArray[i] = new Image(400,400);
                imgArray[i].src = ctl.value;
                }
            }
        }
    </script>

</head>
<body>
        <div id="main" align="center">
    <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <%--PAGE NAV--%>
            <asp:HyperLink CssClass="HeaderLink" ID="HypLoc" runat="server" NavigateUrl="../index.aspx"></asp:HyperLink>
            <asp:HyperLink CssClass="HeaderLink" ID="HypCat" runat="server" NavigateUrl="#" OnClick="javascript:history.go(-1); return false;">
            </asp:HyperLink>
            <div align="center">
                <div align="center" id="container" style="width: 1000px">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <div id="left">
                            <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%--BOOST HERE--%>
                            <bh:showboost id="boost1" runat="server"></bh:showboost>
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center" style="width:700px;">
                            <asp:Panel ID="pnlDetails" style="width:690px" runat="server" BackColor="#DEFE93" BorderColor="#669900"
                                BorderStyle="solid" BorderWidth="1px">
                                <!-- Master Table -->
                                <table cellspacing="0" cellpadding="0" border="0" bgcolor="#DEFE93">
                                    <tr>
                                        <td>
                                            <!-- left side -->
                                            <table border="0" bgcolor="DEFE93" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="10">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        &nbsp;<asp:Image ID="Pic1" runat="server" style="margin:0px 5px 0px 0px;"></asp:Image>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td height="1">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                    <td align="right">
                                                    </td>
                                                    <td align="left">
                                                    </td>
                                                    <td colspan="2">
                                                        <img src="../images/s1x1.gif" alt=""/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="center">
                                                        <asp:Image ID="Pic1ThmbNail" BorderWidth="1" BorderColor="#DEFE93" CssClass="highlightit"
                                                            runat="server" Visible="false" onmouseover="ImgHover('1')" />&nbsp;
                                                        <asp:Image ID="Pic2ThmbNail" BorderWidth="1" BorderColor="#DEFE93" CssClass="highlightit"
                                                            runat="server" Visible="false" onmouseover="ImgHover('2')" />&nbsp;
                                                        <asp:Image ID="Pic3ThmbNail" BorderWidth="1" BorderColor="#DEFE93" CssClass="highlightit"
                                                            runat="server" Visible="false" onmouseover="ImgHover('3')" />&nbsp;
                                                        <asp:Image ID="Pic4ThmbNail" BorderWidth="1" BorderColor="#DEFE93" CssClass="highlightit"
                                                            runat="server" Visible="false" onmouseover="ImgHover('4')" />&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#DEFE93" height="5" colspan="2">
                                                        <img src="../images/s1x1.gif" alt="" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <!-- end left side -->
                                        <!-- begin right side -->
                                        <td valign="top">
                                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="#DEFE93">
                                                <tr>
                                                    <td colspan="2" height="20">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <asp:Panel runat="server" ID="pnlAdTitle" Visible="true">
                                                    <tr>
                                                        <td colspan="2" height="35px" class="midgreen30b" align="left" valign="bottom">
                                                            <asp:Label ID="lblAdTitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlGearItem" Visible="false">
                                                    <tr>
                                                        <td colspan="2" height="35px" class="midorange16b" align="left" valign="bottom">
                                                            <asp:Label ID="lblGearItem" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td colspan="2" class="dkgrey12" align="left" style="height: 18px">
                                                        <asp:Label ID="lblBrand" runat="server">Brand:&nbsp;</asp:Label>
                                                        <asp:Label ID="lblBrandData" runat="server"></asp:Label></td>
                                                    <td style="height: 18px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <asp:Panel runat="server" ID="pnlBoardType" Visible="false">
                                                    <tr>
                                                        <td height="12px" class="dkgrey12" align="left">
                                                            <asp:Label ID="lblBoardType" runat="server"></asp:Label></td>
                                                        <td class="smwhite" align="left">
                                                            <asp:Label ID="lblBoardTypeData" runat="server">
                                                            </asp:Label></td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlGenDims" Visible="false" runat="server">
                                                    <tr>
                                                        <td height="12px" colspan="2" class="dkgrey12" align="left">
                                                            Dimensions:&nbsp;
                                                            <asp:Label ID="lblGenDims" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td bgcolor="#DEFE93">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlWeb" runat="server" Visible="true">
                                                    <tr>
                                                        <td height="12px" colspan="2" class="dkgrey12" align="left">
                                                            Web:&nbsp;
                                                            <asp:LinkButton ID="lnkWeb" CssClass="ltgreen_orange12" runat="server"></asp:LinkButton>
                                                        </td>
                                                        <td bgcolor="#DEFE93">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td height="35px" class="dkgrey12" align="left" colspan="2" valign="bottom">
                                                        The Scoop:&nbsp;</td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dkgrey12" align="left" colspan="2">
                                                        <asp:Label ID="lblDetailsData" runat="server" Width="280px"></asp:Label></td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="2" colspan="2">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" height="5">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                </tr>
                                                <tr>
                                                    <td class="dkgrey10" colspan="3" align="left" valign="bottom">
                                                        Price:&nbsp;<asp:Label ID="lblPriceData" runat="server">
                                                        </asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="dkgrey10" colspan="3" align="left" valign="top">
                                                        Posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" height="10">
                                                        <img src="../images/s1x1.gif" alt=""/></td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" colspan="3">
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header" colspan="2">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                                <div style="overflow:hidden;text-align: center;background:#DEFE93"><div style="float:left">&nbsp;
                                <asp:ImageButton ID="imgGoBack" ToolTip="Go back" runat="server" ImageUrl="../images/id_back.gif">
                                                    </asp:ImageButton>    
                                <span class="dkgrey12">&nbsp;back</span>
                                </div><div align="right" style=""><a class="ltgreen_orange12" href="javascript:navTo('.com/contact.aspx?iD=4');">
                                                        Got something to Showcase?&nbsp;</a></div>
                                </div>
                            </asp:Panel>
                            <!-- end master panel -->

                            <!-- video -->
                            <asp:Panel HorizontalAlign="Center" ID="pnlVideo" runat="server" Visible="false">
                            <br />
                                <asp:Label ID="lblVideo" runat="server">video</asp:Label>
                            <br />                                
                            </asp:Panel>

                            <%--RATINGS--%>
                            <div align="center" style="width: 100%; margin: 0 auto; background-color:#F0F0F0; border:solid 1 #F0F0F0">
                                    <asp:Panel ID="pnlRatings" runat="server" HorizontalAlign="Center">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="middle" class="dkgrey14b" align="left" width="290px">&nbsp;Rate it:&nbsp;&nbsp;
                                                                <asp:ImageButton  runat="server" ID="star1" ImageUrl="../images/target_white.gif"
                                                                    onmouseout="GetRating()" onmouseover="ProcHover('1')" OnCommand="ProcRating"
                                                                    CommandArgument="1" ToolTip="Ugly" align="middle" style="padding-bottom:8px" />
                                                                <asp:ImageButton runat="server" ID="star2" ImageUrl="../images/target_white.gif"
                                                                    onmouseout="GetRating()" onmouseover="ProcHover('2')" OnCommand="ProcRating"
                                                                    CommandArgument="2" ToolTip="Bad" align="middle" style="padding-bottom:8px" />
                                                                <asp:ImageButton runat="server" ID="star3" ImageUrl="../images/target_white.gif"
                                                                    onmouseout="GetRating()" onmouseover="ProcHover('3')" OnCommand="ProcRating"
                                                                    CommandArgument="3" ToolTip="OK" align="middle" style="padding-bottom:8px" />
                                                                <asp:ImageButton runat="server" ID="star4" ImageUrl="../images/target_white.gif"
                                                                    onmouseout="GetRating()" onmouseover="ProcHover('4')" OnCommand="ProcRating"
                                                                    CommandArgument="4" ToolTip="Good" align="middle" style="padding-bottom:8px" />
                                                                <asp:ImageButton runat="server" ID="star5" ImageUrl="../images/target_white.gif"
                                                                    onmouseout="GetRating()" onmouseover="ProcHover('5')" OnCommand="ProcRating"
                                                                    CommandArgument="5" ToolTip="Super!" align="middle" style="padding-bottom:8px" />
                                                                <asp:Label CssClass="dkgrey10b" ID="lblRatingCount" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="dkgrey14b">
                                                                &nbsp;Views:
                                                                <asp:Label CssClass="dkgrey14b" ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                &nbsp;
                                                                <!-- AddThis Button BEGIN -->
                                                                <script type="text/javascript" src="../include/js/addthis.js"></script>

                                                                <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')"
                                                                    onmouseout="addthis_close()" onclick="return addthis_sendto()"><span class="dkgrey14b">
                                                                        Share&nbsp;</span><img src="http://s9.addthis.com/addthis16.gif" width="16" height="16" align="middle" style="padding-bottom:8px"
                                                                            border="0" alt="" /></a><script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>
                                                                &nbsp;
                                                                <!-- AddThis Button END -->
                                                            </td>
                                                        <td class="dkgrey14b" valign="middle" nowrap>
                                                            &nbsp; Favs!&nbsp;
                                                            <asp:ImageButton ID="imgAddFav" runat="server" ImageUrl="../images/favorites.gif" ToolTip="Add to My Favorites!">
                                                            </asp:ImageButton>
                                                            &nbsp;
                                                        </td>                                                            
                                                        </tr>
                                                    </table>
                                </asp:Panel>                                    
                            </div>
                                <br />                              
                            
                            <%--BEGIN COMMENTS--%>
                            <div align="center" style="border:solid 0px Grey">
                                <div align="center">
                                    <div class="midorange24b" align="center" style="background:#FFFFFF;height:30px">
                                     <div style="float:left;">&nbsp;The Wall</div>
                                     <div align="right">
                                     <asp:Label ID="lblCommentCount" Cssclass="midorange12" runat="server"></asp:Label></div>
                                    </div>
                                    <asp:Panel runat="server" ID="pnlComments">
                                        <table width="650" cellpadding="0" cellspacing="0">
                                            <asp:DataList ID="dlCommentList" Width="580" RepeatLayout="Table" BorderColor="#CC6600"
                                                BorderStyle="Solid" BorderWidth="0" runat="server" EnableViewState="false">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td colspan="3">
                                                        <img src='<%# FormatPicPath(DataBinder.Eval(Container.DataItem, "userDir"),DataBinder.Eval(Container.DataItem, "profilePic"))%>' alt="profilepic">
                                                        <span class="ltgrey10">
                                                            &nbsp;&nbsp;by</span>&nbsp;
                                                        <span class="ltgreen12">
                                                                <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>
                                                        </span>
                                                        &nbsp;<span class="ltgrey10">on
                                                            <%# DataBinder.Eval(Container.DataItem, "dPosted", "{0: MM/dd/yy}")%>
                                                            &nbsp;
                                                            </span>                                                        
                                                        </td>
                                                     </tr>
                                                    <tr style="height: 15">
                                                        <td colspan="3" align="left" style="height: 15; background-color: #FFFFFF">
                                                            <img src="../images/Bubble.jpg" style="height: 15" alt="bubble" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="left" class="dkgrey12" style="height: 25; background-color: #F0F0F0">
                                                            <br />&nbsp;&nbsp;
                                                            <%# DataBinder.Eval(Container.DataItem, "txtComment")%>
                                                            &nbsp;
                                                            <br /><br />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:DataList></table>
                                        <br />
                                        <asp:Panel ID="pnlLoginMsg" runat="server" Visible="false" class="dkgrey12">
                                        <a id="toggle2" class="ltgreen_orange12" href="#">Login</a>&nbsp;to say something.
                                        </asp:Panel>
                                        <asp:Panel ID="pnlLogin" runat="server" Height="100px" Width="300px" BackColor="#ff9900"
                                            BorderColor="#ffffff" BorderWidth="1px">
                                            <table>
                                                <tr>
                                                    <td class="white12b">
                                                        E-mail:&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsername" runat="server" Width="200"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="white12b">
                                                        Password:&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" TextMode="Password" Width="200" runat="server" onKeyDown="Check4Enter(event.keyCode);"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <%--Comment Box--%>
                                        <asp:Panel ID="pnlCommentBox" runat="server" BackColor="#99CC33"
                                            BorderColor="#669900" BorderWidth="1">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblCommentBoxHeader" runat="server" CssClass="white12b" Text="Type your answer:"></asp:Label>
                                                    </td>
                                                    <td align="right" class="white16b">
                                                        <asp:Label runat="server" ID="lblTxtCount">400</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right">
                                                        <asp:TextBox ID="txtComment" runat="server" CssClass="dkgrey12" onkeydown="javascript:CharCountAndDisplay(this.form.txtComment,400,'lblTxtCount')"
                                                            Height="120px" Width="352px" MaxLength="400" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button align="right" ID="btnPostComment" Text="Submit" runat="server" CssClass="dkgrey12"
                                                            OnClick="btnPostComment_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                            </div>
                            <%--TILEAD & FOOTER--%>
                            <div align="center">
                                <br />
                                <br />
                                <br />
                                <!-- #include file="../include/ads/tileAd.htm" -->

                            </div>
                        </div>
                        <%--END CENTER--%>
                    </div>
                    <%--END WRAPPER--%>
                    </div></div>
                    <div>
                        <asp:Image ID="Pic2" runat="server" Visible="false"></asp:Image>
                        <asp:Image ID="Pic3" runat="server" Visible="false"></asp:Image>
                        <asp:Image ID="Pic4" runat="server" Visible="false"></asp:Image>
                        <asp:HiddenField ID="hdnPic1URL" runat="server" />
                        <asp:HiddenField ID="hdnPic2URL" runat="server" />
                        <asp:HiddenField ID="hdnPic3URL" runat="server" />
                        <asp:HiddenField ID="hdnPic4URL" runat="server" />
                        <asp:HiddenField ID="hdnEId" runat="server" />
                        <asp:HiddenField ID="hdnStrCat" runat="server" />
                        <asp:HiddenField ID="hdnRatingVal" runat="server" />
                        <asp:HiddenField ID="hdnRatingCnt" runat="server" />                         
                    </div>
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
