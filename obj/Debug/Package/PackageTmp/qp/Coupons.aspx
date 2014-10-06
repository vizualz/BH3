<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="BoardHunt.qp.Coupons" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="../include/Controls/Boost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Surf Coupons | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->

    <meta name="description" content="Surf Coupons are texted to your mobile phone only when you request them on Boardhunt"/>
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />

    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboards For Sale" href="http://www.malzook.com/rss/surfboards.xml"/>
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <script type="text/javascript" src="../include/js/jquery.jgrowl.js"></script>
        <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/jquery.jgrowl.css" />
    <link href="../style/hover.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    
    var oCtl;
    oCtl = document.getElementById('hdnMsg');
    if (oCtl != null)
    {
        if (oCtl.value.length > 1)
        {
            $.jGrowl.defaults.position = 'center-middle';
            $.jGrowl(oCtl.value, { sticky: true , 
            beforeClose: function(e,m) { 
            }
            });            
        }
    }     
    });
    </script>
    <script type='text/javascript' src='http://partner.googleadservices.com/gampad/google_service.js'>

<!-- Google ads: Leader -->

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


</head>
<body bgcolor="#ffffff">
        <div id="main" align="center">
    <form id="Form1" runat="server">

            <!-- #include file="../include/Header.aspx" -->
            <div id="pageNav" class="midorange12" align="center">
                <%--PAGE NAV--%>
                <asp:Label CssClass="" ID="lblPageDesc" runat="server"></asp:Label>
                <asp:Label CssClass="dkgrey12" ID="lblCount" runat="server"></asp:Label>        
            </div>
            <div class="midgrey12" align="center">
               <br />
               <br />
               </div>
            <div class="midorange26b" align="center"><img src="../images/s1x1.gif" height="3" alt="" /></div>
            <div class="midorange26b" align="center">
                <asp:Label CssClass="midgrey18" ID="lblNoResult" runat="server"></asp:Label></div>            
            <div align="center">
            <div align="center" id="container" style="width:1000px;">
                <div id="wrapper" align="center" style="width: 1000px">
                    <%--LEFT COLUMN--%>
                    <%--FILTER--%>
                    <div id="left" style="width:170px;border:solid 0px Red">
                    
                        <!-- Start: Ads -->
                        <!-- #include file="../include/ads/SkyScraperAd.htm" -->
                        <br />
                        <asp:Panel runat="server" Width="142px" ID="pnlFilter" BorderStyle="solid" BorderColor="#ffffff"
                            BorderWidth="0">
                            <table border="0" bgcolor="#ffffff" width="142px" cellpadding="0" cellspacing="0">
                                <tr><td style="background-color:#ffffff;height:1px; width: 147px;"><img src="../images/s1x1.gif" alt="" /></td></tr>
                                <tr>
                                    <td class="ltgreen18" bgcolor="#ffffff" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Seach Coupons</td>
                                    </tr>
                                
                                <tr>
                                        <td bgcolor="#ffffff" style="width: 147px; height: 5px;">
                                        <img src="../images/s1x1.gif" height="5" alt=""/></td>
                                </tr>
                                <tr>        
                                        <td align="center" style="background-color:#ffffff; width: 147px;">
                                            <asp:Button ID="btnSearch2" Text="Go" runat="server"
                                            CssClass="midgreen16b" Width="100px" OnClick="btnSearch_Click" />
                                        </td>
                                </tr>
                                <tr>
                                    <td align="center"  style="background-color:#ffffff;width: 147px; height: 20px;">
                                     <a href="javascript:resetFilter()" class="dkgrey_orange12">refresh</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 10px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                        <td bgcolor="#99CC33" style="height: 15px; width: 147px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                <tr>
                                    <td class="white16b" bgcolor="#99CC33" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Category</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="width: 147px">
                                            &nbsp;&nbsp;<asp:DropDownList ID="cboCategory" Width="125" runat="server" CssClass="dkrgrey16b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#99CC33" style="height: 20px; width: 147px;">
                                            <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
                                    
                                    <tr>
                                    <td bgcolor="#ffffff" class="dkrgrey14" align="left" height="40" style="width: 147px">
                                        &nbsp;&nbsp;Area</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px">
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboLocation" Width="125" runat="server" CssClass="dkrgrey12">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                        
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 10px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 5px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                    </tr>
<%--                                <tr>
                                    <td bgcolor="#333333" class="white12" align="left" height="15" style="width: 147px">
                                        &nbsp;&nbsp;Price</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#333333" class="white12" style="width: 147px">
                                        &nbsp;&nbsp;$
                                        <asp:TextBox ID="txtMinPrice" OnClick="select()" runat="server" Width="30" Text="Min"
                                            CssClass="dkrgrey10b"></asp:TextBox>
                                        &nbsp;to&nbsp;$
                                        <asp:TextBox ID="txtMaxPrice" OnClick="select()" CssClass="dkrgrey10b" runat="server"
                                            Text="Max" Width="30"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#333333" style="width: 147px;height:15px">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>--%>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 5px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>
                                
                                
                                <tr>
                                    <td class="dkrgrey14" bgcolor="#ffffff" align="left" style="height: 15px; width: 147px;">
                                        &nbsp;&nbsp;Keywords</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px" >
                                        &nbsp;&nbsp;<asp:TextBox ID="txtFilterKwd" runat="server" Width="120" CssClass="dkgrey10b" style="background-image:url('http://www.malzook.com/images/atarget.gif');
                                            background-repeat:no-repeat; background-position:right" ></asp:TextBox>
                                        <%--<asp:TextBox ID="txtKeywords" onKeyDown="CheckForEnter(event.keyCode);" 
                                            style="background-image:url('http://www.malzook.com/images/atarget.gif');
                                            background-repeat:no-repeat; background-position:right" runat="server" CssClass="midorange10b"
                                            Width="150px"></asp:TextBox>  --%>                                  
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 5px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>
                                
                                <tr><td style="background-color:#ffffff;height:1px; width: 147px;"><img src="../images/s1x1.gif" alt="" /></td></tr>
                                <tr>
                                    <td bgcolor="#ffffff" style="width: 147px; height: 10px;">
                                        <img src="../images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>        
                                    <td align="center" valign="bottom" style="background-color:#ffffff;width: 147px">
                                        <asp:Button ID="btnSearch" Text="Go" runat="server"
                                            CssClass="midgreen16b" Width="100px" OnClick="btnSearch_Click" /></td>
                                </tr>
                                <tr><td style="background-color:#ffffff;height:1px; width: 147px;"><img src="../images/s1x1.gif" alt="" /></td></tr>
                            </table>
                        </asp:Panel>
                        
                    </div>
                    <%--RIGHT COLUMN--%>
                    <div id="right" align="left" class="dkgrey18" style="margin-top:40px;">
                        <img src="../images/VerticalVoucherImage.gif" /><br /><br />
                        &nbsp;&nbsp;Current Dealz:
                        <div style="border-style:dotted; border-width:2px; width:130px; float: middle; margin-left: 15px; margin-top: 10px" align="center" class="dkrgrey14">
                                                <br />Custom Surfboard Voucher 
                                                <br />
                                                <span class="ltgreen24">$75 worth for $25</span><br />
                                                <a class="dkrgrey_orange14" href="../Shaper/ShaperHouse.aspx">
                                                Choose shaper</a><br>
                                                <br /></div>
                        
                        <div style="width: 130px; float:left; margin-left: 20px; margin-top: 15px; margin-bottom: 50px" align="center" class="dkrgrey12">
                                            <asp:ImageButton ID="imgBuy" runat="server" 
                                                    ImageUrl="../images/Voucher_buy_badge.gif" onclick="imgBuy_Click" /><br />
                                                    <a class="dkrgrey_orange14" href="../login.aspx">Login</a>
                                            </div> 
                        <%--BOOST HERE--%>
                        <bh:ShowBoost ID="boost1" runat="server"></bh:ShowBoost>
                    </div>
                    <!-- end right column-- >
        
                    <!--CENTER COLUMN-->
                    <div id="center" style="border: solid 0px black; margin-left:25px; width:650px">

                        <div style="width: 533px; float:left; margin-left: 25px; margin-bottom: 0px" align="left" class="dkrgrey14">
                                        
                                        <div style="width: 500px; float:left; margin-left: 20px; margin-top: 0px" class="dkrgrey10" align="left"><br />
                                            <img src="../images/Dealz.gif" border="0" alt="Voucher" />
                                            <span class="midgrey16"><br /><br>
                                            
                                            Saving a buck or two is big deal. Visit frequently as we have just built this 
                                            section to help you find savings on surf gear, trips, and other related nuggets.  If you don't 
                                            see anything you like, invite a business below and we'll contact them. Check out<span class="dkrgrey16"> Vouchers </span> (on right)<br /><br />
                                            <span class="dkrgrey30b">and... </span>
                                           
                                        </div>
                                                                                      
                                           
                   <div style="width: 533px; float:left; margin-left: 0px; margin-top: 30px" align="left" class="dkrgrey14">
                        
                        <img src="../images/couponz.gif" border="0" alt="couponz" />
                        
                        <div style="width:533px;" float="left" align="left" class="dkrgrey14">
                        
                       
                            
                        <div style="width:415px; margin-top: 20px; margin-left: 40px" float="right"; align="right">
                        <asp:LinkButton ID="lnkBtnCouponStart" runat="server" CssClass="ltgreen_green18" OnClick="lnkBtnCouponStart_Click">Offer a coupon</asp:LinkButton>
                        </div>
                        <div style="width:415px; margin-left: 40px" float="right" align="right">
                            <span style="font-size: 16px"></span><a class="midgrey_dkgrey14" href="javascript:navTo('.com/contact.aspx?iD=5');">Invite a company</a>
                        
                        <br />
                        <div style="width:415px; margin-top: 10px; margin-bottom: 0px" float="left" align="right">
                        <a href="javascript:void(window.open('http://www.twitter.com/boardhunt'))" ><img src="../images/badge_twit.png" border="0" alt="twitter" /></a>
                        <a href="javascript:void(window.open('http://www.facebook.com/boardhunt'))"><img src="../images/badge_fb.png" border="0" alt="facebook" /></a>
                        <a href="javascript:void(window.open('http://www.stumbleupon.com/submit?url=http%3A//www.boardhunt.com&title=Used+Surfboards+For+Sale'))"><img src="../images/badge_su.gif" border="0" alt="stumbleupon" /></a>
                        
                       </div>
                       </div>
                       
                        <br />
                        <div style="width: 533px; float:left; margin-left: 0px; margin-top: 0px" align="center" class="dkrgrey14">
                            <div class="dkrgrey30b" style="width:533px; margin-top: 30px; margin-bottom: 30px; margin-left: 0px" float="leftS"; align="left">
                                    Current 
                                    Dealz:
                            </div>
                                
                                <asp:DataList Width="533" RepeatLayout="Table" BorderColor="#CC6600" BorderStyle="Solid" OnItemDataBound="dlEntryList_OnItemDataBound"
                                    BorderWidth="0" align="center" ID="dlEntryList" runat="server" EnableViewState="true" OnItemCommand="View_ItemDetail">
                                   <SeparatorTemplate>
                                    <br />
                                    </SeparatorTemplate>                                    
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    
                                    <div class="ltgreen24" align="left" ><%# DataBinder.Eval(Container.DataItem, "title")%>
                                        
                                    </div>
                                    
                                    <div align="center" style="border:dotted 1px black;height:170px;width:530px">
                                        <div style="width:530px; height:110px; border:solid 0px black; margin-top: 20px">
                                        <div style="width:100px;float:left; border:solid 0px black">
               
                                            <asp:ImageButton runat="server" ID="ImageButton2" Height='75' Width='75'
                                                OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "imgPath"))%>'>
                                            </asp:ImageButton>                                  
                                        </div>
                                        
                                        <div style="float:left;border:solid 0px blue; margin-top:5px; width:260px" align="left">
                                        <asp:LinkButton CssClass="ltgrey18" ID="lnkTitle" runat="server" OnCommand="GetValues"
                                                CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
		                                    
                                            </asp:LinkButton><br />
                                            
                                            
                                        <span class="dkrgrey14">
                                            <span class="dkrgrey14" style="width:100%">
                                                <%# DataBinder.Eval(Container.DataItem, "body")%>
                                            </span>
                                        </span>
                                        <br />
                                        <asp:Label ID="lblExp" runat="server" Text='<%# CheckExp(DataBinder.Eval(Container.DataItem, "dExpire"))%>' CssClass="dkgrey12b"></asp:Label>
                                        <asp:HiddenField ID="hdnShaperCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>'/>
                                        <br />
                                        </div>
                                        <div style="float:right; margin: 0 0 0 0; width:140px; border:solid 0px red">
                                        <asp:Button ID="btnSendSMS" OnCommand="SendSMS" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' runat="server" CssClass="btnGo" Width="92px" Height="30px" Text="Text me" />&nbsp;<br />
                                        <br />
                                        <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="dkgrey12" Text='' Width="88px"></asp:TextBox>
                                        <br />
                                        <span style="height:3px" class="midorange12">(ex: 5555555555)</span>
                                        </div>
                                        </div>
                                        <br />
                                     <div style="width:530px; border:solid 0px Green; background-color:#333333;height:22px">
                                        <asp:LinkButton runat="server" ID="lnkFooter" CssClass="grey_dkgrey10" CommandName="redir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "txtWebSite")%>'>
                                        <%# DataBinder.Eval(Container.DataItem, "txtUserName")%>
                                        &nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "txtPhoneNum")%>
                                        &nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "txtWebSite")%>
                                        <%--&nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "pAddress")%>--%>
                                        &nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "city")%>
                                        ,
                                        <%# DataBinder.Eval(Container.DataItem, "stateAbbr")%>
                                        &nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "zipcode")%>                                        
                                        </asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton runat="server" style="text-decoration:underline" CommandName="map" ID="lnkMap" OnClientClick='<%# GetMapURL(DataBinder.Eval(Container.DataItem, "pAddress"), DataBinder.Eval(Container.DataItem, "city"), DataBinder.Eval(Container.DataItem, "stateAbbr"))%>' CssClass="grey_dkgrey10">map</asp:LinkButton>
                                        <br /><br /> 
                                        </div>
                                    </div>
                                     <%--</div>--%>
                                    </ItemTemplate>
                                </asp:DataList>
                            <table border="0">
                                <tr>
                                    <td height="20">
                                        <img src="../images/s1x1.gif" alt=""/></td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                            runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                                        <asp:Label CssClass="controls" ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
                                        <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
                                        <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                            runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                            <asp:HiddenField ID="hdnLocVal" Value="" runat="server" />
                            <asp:HiddenField ID="hdniCat" Value="" runat="server" />
                            <asp:HiddenField ID="hdnServer" Value="" runat="server" />
                            <asp:HiddenField ID="hdniBoardType" Value="" runat="server" />
                            <asp:HiddenField ID="hdnKeywords" Value="" runat="server" />
                            <asp:HiddenField ID="hdnUiD" Value="" runat="server" />
                            <asp:HiddenField ID="hdnCiD" Value="" runat="server" />                            
                            <asp:HiddenField ID="hdnMsg" Value="" runat="server" />
                            <%--TILEAD REMOVED FOR NOW--%>
                         </div>   
                        </div><br /><br />
                        </div>
                       
                    <%--END CENTER--%>
                </div> <%--END WRAPPER--%>
                <div align="center">
                    <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                </div>
            </div> <%--END CONTAINER--%>
            </div>
            
            <div id="push">
            </div>
    </form>
            </div> <%--END MAIN--%>
                            <div align="center" id="footer">
                                <!-- #include file="../include/footer.aspx" -->
                            </div>    
    <script type="text/javascript" src="../include/js/googles.js"></script>
</body>
</html>



