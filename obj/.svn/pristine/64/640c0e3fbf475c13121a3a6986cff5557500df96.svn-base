<%@ Page Language="c#" Codebehind="BidResults.aspx.cs" AutoEventWireup="True" EnableEventValidation="false" Inherits="BoardHunt.Bidder.BidResults" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Surfboards on Sale - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->

    <script type="text/javascript" src="../include/js/m1-2b.js"></script>
    <script type="text/javascript" src="../include/js/dropdown.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link href="../style/dropdown.css" type="text/css" rel="stylesheet">            
    <link href="../style/global.css" type="text/css" rel="stylesheet">
    <link href="../style/hover.css" type="text/css" rel="stylesheet">
    <link href="../style/tips.css" type="text/css" rel="stylesheet">      

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
    <script language="javascript" type="text/javascript">
    window.addEvent('domready', function() {
        var Tips1 = new Tips($$('.Tips1'),
        {
            maxTitleChars: 50
        });
    });    
    </script>    

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div align="center" id="main">
        <!-- #include file="../include/header2.aspx" -->
        <div align="center" id="container">
        <div id="wrapper" align="center">
        <!--left column-->

        <div id="left">
        <br />
        <br />
        <br />
        <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#669900" BorderWidth="0">
        <table border="0" bgcolor="#DEFE93" bordercolor="#FF9900" Width="142px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="white20b" align="center" bgcolor="#669900" height="25px">Filters</td>
                            
                    </tr>
                    <tr>
                        <td class="midorange10b" valign="top" align="center" bgcolor="#669900" bordercolor="#FF9900" height="15px">
                            Hunt it down</td>
                    </tr>
                    <tr>
                        <td height="15">
                            <img src="../images/s1x1.gif" /></td>
                    </tr>
                    <tr>
                        <td class="dkgreen14b" align="left" style="height: 15px">
                            &nbsp;&nbsp;Keywords</td>
                    </tr>                  
                    <tr>
                        <td>
                            &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="125" CssClass="dkgrey10b"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="midorange10b" align="left" style="height: 10px">
                            &nbsp;&nbsp;&nbsp;e.g. "merrick"</td>
                    </tr>
					<tr>
                        <td height="10">
                            <img src="../images/s1x1.gif" /></td>
                    </tr>  
                    <tr>
                        <td class="dkgreen14b" align="left" height="15">
                            &nbsp;&nbsp;Seller</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;<asp:DropDownList ID="cboPostingType" Width="125" runat="server" CssClass="dkgrey10b">
                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Commercial"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Non-Commercial"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
					<tr>
                        <td height="10">
                            <img src="../images/s1x1.gif" /></td>
                    </tr>                                                           
                    <tr>
                        <td class="dkgreen14b" align="left" height="15">
                            &nbsp;&nbsp;Area</td>
                    </tr>
                    <tr>
                        <td>
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
                            &nbsp;&nbsp;<asp:TextBox ID="txtHtFt" OnClick="select()" runat="server" Width="20" Text="ft" CssClass="dkgrey10b"></asp:TextBox>
                            '&nbsp;
                            <asp:TextBox ID="txtHtIn" OnClick="select()" CssClass="dkgrey10b" runat="server" Text="in" Width="20"></asp:TextBox>&nbsp;"</td>
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
                        <td bgcolor="#DEFE93">
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
                        <td bgcolor="#DEFE93">
                            &nbsp;&nbsp;<asp:DropDownList ID="cboTailType" runat="server" CssClass="dkgrey10b">
                            </asp:DropDownList></td>
                    </tr>
                                   
                    </asp:Panel>
					<tr>
                        <td bgcolor="#DEFE93" height="10">
                            <img src="../images/s1x1.gif" /></td>
                    </tr>
                    <tr>
                        <td bgcolor="#DEFE93" class="dkgreen14b" align="left" height="15">
                            &nbsp;&nbsp;Price</td>
                    </tr>
                    <tr>
                        <td bgcolor="#DEFE93" class="dkgreen14b">
                            &nbsp;&nbsp;$
                            <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min" CssClass="dkgrey10b"></asp:TextBox>
                            to&nbsp;$
                            <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkgrey10b" runat="server" Text="Max" Width="30"></asp:TextBox></td>
                    </tr>
					<tr>
                        <td bgcolor="#DEFE93" height="20">
                            <img src="../images/s1x1.gif" /></td>
                    </tr>
                    <tr>
                        <td bgcolor="#DEFE93" align="center" valign="bottom">
                            &nbsp;<asp:Button ID="btnSearch" OnClientClick="SetHdnLocVal()" Text="Go" runat="server" CssClass="dkgrey12b" Width="50px" onclick="btnSearch_Click" /></td>
                    </tr>
                    <tr>
                        <td bgcolor="#DEFE93" height="5">&nbsp;</td>              
                    </tr>
                    </table>   
                    
         </asp:Panel>
            <br />
            
            <div style="text-align: center;">
            <!-- Start: Ads -->
            <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/D2T2A3Z27VD6NAHMMTLMNF/">
            </script>
            </div>
 
        </div>
        <!-- right column-->
        <div id="right">
            <br />
            <br />
            <br />
            <table width="130px" bgcolor="#cccccc" border="0" cellpadding="0" cellspacing="0">
                           <tr>
                                <td colspan="3" bgcolor="#333333" class="white20b" border="2" bordercolor="#333333" align="center">Boardicons
                                </td>
                           </tr>
                           <tr>
                                <td colspan="3" bgcolor="#333333" class="midorange10b" align="center" style="height: 15px">Learn Board Basics
                                </td>
                           </tr>
                           <tr>
                                <td height="5">
                                &nbsp;</td>
                           </tr>
                           <tr>
                               <td align="center" style="height: 46px"><IMG src="../images/key_shortboard.gif" class="Tips1" title="Shortboard::Intermediate to advanced, Waist high and bigger, Thin - lacks floatation"></td>
                               <td align="center" style="height: 46px"><img src="../images/key_funshape.gif" class="Tips1" title="Funshape & Eggs::Ideal board for beginners, Small to medium waves, Board height: 7-9 ft"></td>
                               <td align="center" style="height: 46px"><img src="../images/key_longboard.gif" class="Tips1" title="Longboard::Ideal board for beginners, Small to medium waves, Plenty floatation"></td>
                           </tr>
                           <tr>
                                <td height="5">
                            <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                               <td align="center"><IMG src="../images/key_fish.gif" class="Tips1" title="All Fishes & Retro::Intermediate to advanced, Ideal for mushy waves, Short and stubbier board"></td>
                               <td align="center"><img src="../images/key_gun.gif" class="Tips1" title="Gun & Miniguns::For advanced riders only, Ridden on big waves, Board height: 7-12 ft"></td>
                               <td align="center"><img src="../images/key_pro.gif" class="Tips1" title="Pro Models::For advanced riders only, Light and thinly shaped, For high performance"></td>
                           </tr>
                           <tr>
                                <td height="5">
                            <img src="../images/s1x1.gif" /></td>
                            </tr>
                           <tr>
                                <td height="5">
                                &nbsp;</td>
                           </tr>    
                   </table>
                   <br />
                   <!-- here -->
                    <asp:Panel runat="server" ID="pnlHotBoards" Width="130px" BorderWidth="2" BorderColor="#f26721" ToolTip="Other boards you might like">
                        <asp:DataList ID="dlUpgrades" runat="server" CssClass="red_orange12u" RepeatDirection="Horizontal"
                            RepeatColumns="1" RepeatLayout="Table" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <span class="ltgreen16b ">More Boards</span><br /><a class="grey_dkgrey10" href="post_manager.aspx">+ add my board</span><br /><br />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgBtnHotBoard" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetHotPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1")) %>' />
                                <br />
                                <asp:LinkButton ID="lnkBtnUpBrand" runat="server"><%# DataBinder.Eval(Container.DataItem, "txtBrand") %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "iHtFt")%>'&nbsp;<%# DataBinder.Eval(Container.DataItem, "iHtIn")%>"</asp:LinkButton>
                                <br /><br />
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>                    

            
           <%--<!--IFRAME Tag // Tag for network 5105: Cold War Collective // Website: Board Hunt // Page: default // Placement: default-right- 120x600 (140606) // created at: Apr 28, 2008 2:39:29 PM   -->
            <IFRAME WIDTH="120" HEIGHT="600" SCROLLING="No" FRAMEBORDER="0" MARGINHEIGHT="0" MARGINWIDTH="0" SRC="http://adserver.adtechus.com/adiframe/3.0/5105/140606/0/168/ADTECH;target=_blank"><script language="javascript" src="http://adserver.adtechus.com/addyn/3.0/5105/140606/0/168/ADTECH;loc=700;target=_blank"></script><noscript><a href="http://adserver.adtechus.com/adlink/3.0/5105/140606/0/168/ADTECH;loc=300" target="_blank"><img src="http://adserver.adtechus.com/adserv/3.0/5105/140606/0/168/ADTECH;loc=300" border="0" width="120" height="600"></a></noscript></IFRAME>
            <!-- End of IFRAME Tag -->--%>
        </div>
        <!-- end right column-- >
        
        <!--center column-->
        <div id="center">
            <div class="midorange26b" align="center">
                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                <asp:HyperLink CssClass="orange_dkorange26" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>&nbsp;>
                <asp:Label CssClass="" ID="lblCat" runat="server"></asp:Label>
                <asp:Label CssClass="midgrey16b" ID="lblCount" runat="server"></asp:Label>
            </div>
<%--            <div class="midgrey16b" align="center">
                Use Filters and Boardicons to Hunt Faster</div>  --%>  
            <div class="midorange26b" align="center">
                &nbsp;</div>
            <div class="midorange26b" align="center">
                <asp:Label CssClass="midgrey16b" ID="lblNoResult" runat="server"></asp:Label></div>
            <div align="center">
                <table width="560" border="0">
                    <asp:DataList Width="560" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid"
                        BorderWidth="0" ID="dlEntryList" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail">
                        <HeaderTemplate>
                            <tr>
                                <td bgcolor="#ff9900" style="height:1px"><img src="../images/s1x1.gif" height="1"></td>
                            </tr>
                        </HeaderTemplate>
                        
                        <ItemTemplate>
<%--                            <tr height="50px" id="hRow" <%# (Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %> valign="top"
                                style="cursor: hand" onmouseover="SaveBG(style.backgroundColor);style.backgroundColor='#FF9900'"
                                onmouseout="style.backgroundColor=GetBG();">
                                <!--Date-->
                                <td>
                                    <asp:LinkButton CssClass="dkgrey_white10" ID="LinkButton1" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}") %>
                                    </asp:LinkButton>
                                </td>
                                <!--AdType-->                                                                
                                <td align="center">
                                    <asp:ImageButton runat="server" ID="imgAdType" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# GetAdType(DataBinder.Eval(Container.DataItem, "adType")) %>'
                                        ToolTip='<%# DecodeAdType(DataBinder.Eval(Container.DataItem, "adType"))%>'></asp:ImageButton>
                                </td>                                
                                <!--BoardTypePic-->
                                <td>
                                    <asp:ImageButton CssClass="Tips1" runat="server" ID="imgBoardType" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetBoardPic(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iBoardType")) %>'
                                        ToolTip='<%# GetToolTip(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iBoardType"))%>'></asp:ImageButton>
                                </td>
                                <td width="3px"><img src="../images/s1x1.gif"</td>  
                                <!--Desc-->                              
                                <td class="dkgrey_white12" nowrap width="170">
                                    <asp:LinkButton CssClass="dkgrey_white12" ID="LinkButton2" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
										<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
										
										<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
										
										<%# FormatDetails(DataBinder.Eval(Container.DataItem, "txtBrand"), (object)22 )%>
										&nbsp;

										<%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
										<%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>										
                                    </asp:LinkButton>&nbsp;
                                </td>
                                <!--Price-->
                                <td align="left" class="header">
                                <asp:LinkButton ID="lnkBtnPrice" CssClass="dkgrey_white10" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") + "&nbsp;&nbsp;" %>
                                </asp:LinkButton>
                                    &nbsp;&nbsp;
                                </td>
                                <!--HasPic-->
                                <td align="left">
                                <asp:Panel ID="pnlPreview" CssClass="imgcontainer" runat="server">
                                    <asp:LinkButton BorderWidth="0" runat="server" CssClass="thumbnail" ID="lnkBtnImg" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                        <asp:Image BorderWidth="0" ID="imgCameraPic" CssClass="thumbnail" onmouseover="this.src='images/camera2.gif'" onmouseout="this.src='images/camera.gif'" runat="server" ImageUrl='<%# VerifyImage(DataBinder.Eval(Container.DataItem, "txtImgPath1")) %>' />
                                        <!--span-->
                                        <asp:Label ID="lblPreview" runat="server">
                                            <asp:Image ID="imgPreview" runat="server" ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>' ></asp:Image>
                                        </asp:Label>                                    
                                    </asp:LinkButton>
                                </asp:Panel>  
                                </td>                                
                                <td>&nbsp;</td>                                
                                <td>&nbsp;</td>
                                <!--Town-->
                                <td align="left" class="header">
                                    <asp:LinkButton ID="lnBtnTown" CssClass="dkgrey_white10" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                        <%# DataBinder.Eval(Container.DataItem, "txtTown") %>
                                        &nbsp;&nbsp;
                                    </asp:LinkButton>                                
                                </td>
                                <td>&nbsp;</td>
                                <td align="middle" class="dkgrey10b">
                                <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>
                                </td>
                                <!-- status-->
                                <td class="red10">
                                    <font color="red">
                                        <%# GetStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>
                                    </font>
                                </td>
                            </tr>--%>
                            <tr>
                          
                            <td class="dkgrey_white12" nowrap>
                                <%--BoardType Pic--%>                                                              
                                &nbsp;
                                <asp:ImageButton align="middle" CssClass="Tips1" runat="server" ID="imgBoardType" OnCommand="GetValues" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetBoardPic("1",DataBinder.Eval(Container.DataItem, "iBoardType")) %>'
                                        ToolTip='<%# GetToolTip("1",DataBinder.Eval(Container.DataItem, "iBoardType"))%>'></asp:ImageButton>
                                &nbsp;                                                                         
                                <asp:LinkButton CssClass="midgrey_orange12" ID="LinkButton2" runat="server" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iBidder")%>'
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "dStartDate", "{0: MM/dd}") %>
                                    &nbsp;
									<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
									
									<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
									&nbsp;
									Start Price:&nbsp;$<%# DataBinder.Eval(Container.DataItem, "startPrice")%>

                                </asp:LinkButton>&nbsp;
                            </td>                            
                            </tr>
                            <tr><td colspan="13" style="border-bottom:solid 1px #999999"><img src="../images/s1x1.gif" alt="spacer" /></td></tr>
                        </ItemTemplate>
                    </asp:DataList></table>
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='images/backpage.gif'"
                                runat="server" ImageUrl="images/backpage.gif"></asp:ImageButton>&nbsp;
                                
                                <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
               
                                <asp:ImageButton
                                ID="cmdNext" onmouseover="this.src='images/nextpage2.gif'" onmouseout="this.src='images/nextpage.gif'"
                                runat="server" ImageUrl="images/nextpage.gif"></asp:ImageButton>
                                
                                </td>
                    </tr>
                </table>
                <br />
                <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                <asp:HiddenField ID="hdnLocVal" Value="-1" runat="server" />
                
                 <!-- #include file="../include/ads/tileAd.htm" -->
                <div align="center" id="footer">
                    <!-- #include file="../include/footer.aspx" -->
                </div>
            </div>
            <br/>
            <img src="../images/s1x1.gif" height="5">
        </div><!-- end center div -->
        </div>        
        
        
        
        </div>
        
    </div>
    </form>
    <div align="center">
        <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label></div>

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