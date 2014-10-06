<%@ Page Codebehind="BidDetails.aspx.cs" Language="c#" AutoEventWireup="True" MaintainScrollPositionOnPostback="true"
    Inherits="BoardHunt.Bidder.BidDetails" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/dropdown.css" type="text/css" rel="stylesheet" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript" src="../include/js/m1-2b.js"></script>
    <script type="text/javascript" src="../include/js/dropdown.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>

    <script type="text/javascript">

    </script>

    <script type="text/javascript">
         window.addEvent('domready', function(){
            if(document.getElementById("pnlLogin") != null)
            {         
//                var mySlide2 = new Fx.Slide('pnlLogin', {mode: 'horizontal'});
//                
//                mySlide2.hide();
//             
//                $('toggle2').addEvent('mouseenter', function(e){
//	            e = new Event(e);
//	            mySlide2.toggle();
//	            e.stop();
//        	    });	            
            }
            

            
            });
    </script>
    <script type="text/javascript" src="../include/js/countdown.js"></script>
    <script type="text/javascript">
        function PreLoadImgs()
        {
            var i;
            var imgArray = new Array();
            
            for (i=0;i<=3;i++)
            {
                imgArray[i] = "hdnPicVal" + (i+1);
                
                var ctl = document.getElementById("hdnPic" + (i+1) + "URL");
                
                if (ctl.value != "")
                {
                imgArray[i] = new Image(400,400);
                imgArray[i].src = ctl.value;
                }
            }
        }
    </script>
    <style type="text/css">
    body,
    html {
        margin:0;
        padding:0;
        /*background:#a7a09a;*/
        color:#000;
        }
    body {
        min-width:750px;
        }
    #wrap {
        /*background:#99c;*/
        margin:0 auto;
        width:964px;
        }
    #main {
        /*background:#9c9;*/
        float:left;
        width:760px;
        }
    #sidebar {
        /*background:#c9c;*/
        float:right;
        width:200px;
        }
    #footer {
    /*background:#cc9;*/
    clear:both;
    }
    
    #nav ul{
        margin:0;
        padding:0;
        list-style:none;
        }
    #nav li{
        display:inline;
        margin:0;
        padding:0;
        }
#header h1 {
    padding:5px;
    margin:0;
    }
#nav {
    /*background:#c99;
    padding:5px;*/
    }
#main h2, #main h3, #main p {
    padding:0 10px;
    }
#sidebar ul {
    margin-bottom:0;
    }
#sidebar h3, #sidebar p {
    padding:0 10px;
    }
#footer p {
    padding:5px;
    margin:0;
    }

    </style>

</head>
<body onload="PreLoadImgs();GetRating();">
    <form class="header" id="Form1" runat="server">
    <div id="main" align="center">
        <!-- #include file="../include/header2.aspx" -->
        
<div align="center">      
<div id="wrap">
<%-- DOC HEADING --%>
    <div id="nav" Class="midorange26b">
                <asp:HyperLink CssClass="orange_dkorange26" ID="HypHome" runat="server" NavigateUrl="">Bidder</asp:HyperLink>&nbsp;>&nbsp;
                <%--<asp:HyperLink CssClass="orange_dkorange26" ID="HypLoc" runat="server" NavigateUrl="#">Loc</asp:HyperLink>&nbsp;>&nbsp;--%>
                <%--<asp:HyperLink CssClass="orange_dkorange26" ID="HypCat" runat="server" NavigateUrl="#">Cat</asp:HyperLink>&nbsp;>&nbsp;--%>
                <span class="orange_dkorange26">Bid Details</span>
                <%--Bids>Solana>Surfboards>--%>
                <br /><br />
    </div>
    <div id="main">
        <%--COLUMN 1--%>

                 <asp:Panel ID="pnlDetails" runat="server" BorderColor="#FF9900" BorderStyle="solid" Style="width: 750px" BorderWidth="6px">
                    <!-- Master Table -->
                    <table cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFCC" bordercolor="#999966">
                        <tr>
                            <td>
                                <!-- left side -->
                                <table width="425px" border="0" bgcolor="#FFFFCC" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="10">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;<asp:Image ID="Pic1" runat="server"></asp:Image>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="1" colspan="">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="center">
                                            <asp:Image ID="Pic1ThmbNail" BorderWidth="0" CssClass="highlightit" runat="server"
                                                Visible="false" onmouseover="ImgHover('1')" />&nbsp;
                                            <asp:Image ID="Pic2ThmbNail" BorderWidth="0" CssClass="highlightit" runat="server"
                                                Visible="false" onmouseover="ImgHover('2')" />&nbsp;
                                            <asp:Image ID="Pic3ThmbNail" BorderWidth="0" CssClass="highlightit" runat="server"
                                                Visible="false" onmouseover="ImgHover('3')" />&nbsp;
                                            <asp:Image ID="Pic4ThmbNail" BorderWidth="0" CssClass="highlightit" runat="server"
                                                Visible="false" onmouseover="ImgHover('4')" />&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" bgcolor="#FFFFCC" align="left" colspan="3">
                                            &nbsp;&nbsp;<asp:ImageButton ID="imgGoBack" ToolTip="Back to results" runat="server"
                                                ImageUrl="../images/BackToResults.gif"></asp:ImageButton>&nbsp;<span class="midorange12b">back</span></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFCC" colspan="2" style="height: 5px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                </table>
                            </td>
                            <!-- end left side -->
                            <td>
                                &nbsp;</td>
                            <!-- begin right side -->
                            <td valign="top">
                                <table width="320px" cellpadding="0" cellspacing="0" border="0" bgcolor="FFFFCC">
                                    <tr>
                                        <td bgcolor="#FFFFCC" height="2" colspan="3">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="midgrey10" align="left" bgcolor="#FFFFCC" valign="bottom">
                                            Posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFCC" colspan="1" style="height: 5px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                </table>
                                <table width="315" cellpadding="0" cellspacing="0" border="0" bgcolor="#FFFFCC" bordercolor="#FFFFCC">
                                    <tr>
                                        <td class="dkorange20b" colspan="2" align="left" valign="bottom">
                                            BIDS:&nbsp;
                                            </td>
                                        <td style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey12b" align="left" valign="bottom">
                                            End date:&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEndDate" CssClass="dkgrey12b" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey12b" colspan="2" align="left" valign="bottom">
                                            Time left:&nbsp; <span id="cntdwn"></span>
                                        </td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2">&nbsp;</td>
                                    </tr>                                    
                                    <tr>
                                        <td class="dkgrey12b" align="left" valign="bottom">
                                            Starting Bid:&nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblStartingBid" CssClass="dkgrey12b" runat="server"></asp:Label>
                                        </td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td class="dkgrey12b" align="left" valign="bottom">
                                            Best Bid:&nbsp;</td>
                                        <td><asp:Label ID="lblLowestBid" CssClass="dkgrey12b" runat="server"></asp:Label>
                                        </td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td class="dkgrey12b" align="left" valign="bottom">
                                            My bid is:&nbsp;
                                        </td>
                                        <td class="dkgreen12b">
                                            $<asp:TextBox ID="txtBidValue" runat="server" Width="65px" CssClass="dkgreen12b"></asp:TextBox>&nbsp;
                                            &nbsp;<asp:Button ID="btnPlaceBid" runat="server" Text="Go!" Width="63px" OnClick="btnPlaceBid_Click" />
                                            &nbsp;<asp:Label ID="lblBidStatus" runat="server"></asp:Label>                                        
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="5">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>

                                    <tr>
                                        <td bgcolor="#ff9900" colspan="2" style="height: 5px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffcc66" colspan="2" style="height: 3px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFCC" height="3px" colspan="2">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>                                    
                                    
                                    
                                                                        
                                    <tr>
                                        <td class="dkorange20b" colspan="3" align="left" valign="bottom">
                                            Details:&nbsp;</td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>                                                                          
                                    <tr>
                                        <td height="20px" class="midorange16b" align="left">
                                            <asp:Label ID="lblBoardType" runat="server" nowrap>Board Type:</asp:Label></td>
                                        <td class="dkgrey16b" align="left" valign="bottom">
                                            <asp:Label ID="lblBoardTypeData" runat="server">
                                            </asp:Label></td>
                                        <td bgcolor="#FFFFCC">
                                            &nbsp;
                                        </td>
                                    </tr>

                                    <asp:Panel ID="pnlAll" runat="server">
                                        <tr>
                                            <td height="20px" class="midorange16b" align="left" width="40%">
                                                <asp:Label ID="lblHeight" runat="server">Height:&nbsp;</asp:Label></td>
                                            <td class="dkgrey16b" align="left" valign="bottom" width="60%">
                                                <asp:Label ID="lblHeightFtData" runat="server">
                                                </asp:Label>
                                                <asp:Label ID="lblHeightInData" runat="server">
                                                </asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlWidth" runat="server">
                                        <tr>
                                            <td height="18px" class="midorange16b" align="left">
                                                Width:&nbsp;</td>
                                            <td class="dkgrey16b" align="left" valign="bottom">
                                                <asp:Label ID="lblWidthData" runat="server">
                                                </asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSurfOnly" runat="server">
                                        <tr>
                                            <td height="18px" class="midorange16b" align="left">
                                                Thickness:&nbsp;</td>
                                            <td class="dkgrey16b" align="left" valign="bottom">
                                                <asp:Label ID="lblThickData" runat="server">
                                                </asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="18px" class="midorange16b" align="left">
                                                Tail:&nbsp;</td>
                                            <td class="dkgrey16b" align="left" valign="bottom">
                                                <asp:Label ID="lblTailData" runat="server">
                                                </asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="18px" class="midorange16b" valign="top" align="left">
                                                Fins:&nbsp;</td>
                                            <td class="dkgrey16b" align="left" valign="bottom">
                                                <asp:Label ID="lblFinsData" runat="server">
                                                </asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
<%--                                    <asp:Panel ID="pnlGenDims" Visible="false" runat="server">
                                        <tr>
                                            <td height="18px" class="midorange16b" align="left">
                                                Dimensions:&nbsp;</td>
                                            <td class="dkgrey16b" align="left" valign="bottom">
                                                <asp:Label ID="lblGenDims" runat="server">
                                                </asp:Label>
                                            </td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>--%>
                                    <tr>
                                        <td height="20px" class="midorange16b" align="left" valign="bottom" colspan="2">
                                            Details:&nbsp;</td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey10" align="left" colspan="3" valign="bottom">
                                            <asp:Label ID="lblDetailsData" runat="server" Width="295px"></asp:Label></td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="midorange16b" colspan="3">
                                           &nbsp;
                                        </td>
                                    </tr>  
                                    <tr>
                                        <td class="midorange16b" colspan="3">
                                            Questions or comments?
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="midorange16b" colspan="3">
                                            Leave them below on the Wall
                                        </td>
                                    </tr>                                    
                                    <asp:Panel ID="pnlContactInfo" runat="server">
                                   <tr> 
                                        <td colspan="2" class="dkgrey10">
                                            E-mail:
                                            <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="red_orange12u">
                                            </asp:LinkButton>
                                            &nbsp;&nbsp;Ph:
                                            <asp:Label ID="lblPhoneData" runat="server" CssClass="dkgrey12">
                                            </asp:Label></td>
                                        <td bgcolor="#FFFFCC" style="width: 7px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td bgcolor="#FFFFCC" colspan="2" style="height: 10px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>
<%--                                    <tr>
                                        <td class="controls3" align="left" colspan="2" bgcolor="#FFFFCC">
                                            <asp:LinkButton ID="btnMore" CssClass="red_orange12u" runat="server" Text="See more boards by this user"
                                                OnClick="btnMore_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFCC" colspan="2" style="height: 14px">
                                            <img src="../images/s1x1.gif"></td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="header" colspan="3">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <!-- end master table -->
                </asp:Panel>

<!-- bottom half -->
        <div align="center" style="height: 20px">
            <div align="center" style="margin: 0 auto; width: 755px; border-width: 0px; border-color: #ff9900;
                border-style: solid;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <asp:Panel ID="pnlRatings" runat="server" HorizontalAlign="Center" Width="755px">
                            <td colspan="2">
                                <table bgcolor="F0F0F0" border="0" cellpadding="0" cellspacing="0" width="755">
                                    <tr>
                                        <td class="dkgrey14b" align="left" colspan="2" width="320px" valign="middle">
                                            &nbsp;<span class="dkgrey10b">Good deal?</span>User Rating:&nbsp;&nbsp;<asp:ImageButton runat="server" ID="star1" ImageUrl="../images/target_white.gif"
                                                onmouseout="GetRating()" onmouseover="ProcHover('1')" OnCommand="ProcRating"
                                                CommandArgument="1" ToolTip="Ugly" />
                                            <asp:ImageButton runat="server" ID="star2" ImageUrl="../images/target_white.gif"
                                                onmouseout="GetRating()" onmouseover="ProcHover('2')" OnCommand="ProcRating"
                                                CommandArgument="2" ToolTip="Bad" />
                                            <asp:ImageButton runat="server" ID="star3" ImageUrl="../images/target_white.gif"
                                                onmouseout="GetRating()" onmouseover="ProcHover('3')" OnCommand="ProcRating"
                                                CommandArgument="3" ToolTip="Okay" />
                                            <asp:ImageButton runat="server" ID="star4" ImageUrl="../images/target_white.gif"
                                                onmouseout="GetRating()" onmouseover="ProcHover('4')" OnCommand="ProcRating"
                                                CommandArgument="4" ToolTip="Good" />
                                            <asp:ImageButton runat="server" ID="star5" ImageUrl="../images/target_white.gif"
                                                onmouseout="GetRating()" onmouseover="ProcHover('5')" OnCommand="ProcRating"
                                                CommandArgument="5" ToolTip="Super!" />
                                            <asp:HiddenField ID="hdnRatingVal" runat="server" />
                                            <asp:HiddenField ID="hdnRatingCnt" runat="server" />
                                            <asp:Label CssClass="dkgrey10b" ID="lblRatingCount" runat="server"></asp:Label>
                                        </td>
                                        <td valign="bottom" class="dkgrey14b" nowrap>
                                            &nbsp;Views:
                                            <asp:Label CssClass="dkgrey14b" ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label>
                                        </td>
                                        <td valign="middle" nowrap>
                                            &nbsp;
                                            <!-- AddThis Button BEGIN -->

                                            <script type="text/javascript">
                                                addthis_pub  = 'vizualz';
                                                addthis_logo            = 'http://www.addthis.com/images/yourlogo.png';
                                                addthis_logo_background = 'FF9900';
                                                addthis_logo_color      = '666699';
                                                addthis_brand           = 'Boardhunt.com';
                                                addthis_options         = 'stumbleupon, email, facebook';
                                            </script>

                                            <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')"
                                                onmouseout="addthis_close()" onclick="return addthis_sendto()"><span class="dkgrey14b">
                                                    Share&nbsp;</span><img src="http://s9.addthis.com/addthis16.gif" width="16" height="16"
                                                        border="0" alt="" /></a><script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </asp:Panel>
                    </tr>
                </table>
            </div>
        </div>
        <!-- Begin Comments -->
        <div align="center">
            <br />
            <div class="midorange24b" align="center">
                The Wall<br />
                <asp:Label ID="lblCommentCount" class="dkgrey12" runat="server"></asp:Label>
            </div>
            <asp:Panel runat="server" ID="pnlComments">
                <table width="580">
                    <asp:DataList ID="dlCommentList" Width="580" RepeatLayout="Table" BorderColor="#CC6600"
                        BorderStyle="Solid" BorderWidth="0" runat="server" EnableViewState="false">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="hRow" style="background-color: #FFFFFF">
                                <td class="ltgrey10" align="left">
                                    &nbsp;by<span class="midorange12">
                                        <%# ParseEmail(DataBinder.Eval(Container.DataItem, "txtEmail"))%>
                                    </span>&nbsp;on
                                    <%# DataBinder.Eval(Container.DataItem, "dPosted", "{0: MM/dd/yy}") %>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="dkgrey12" colspan="2" height="25" style="background-color: #F0F0F0">
                                    &nbsp;&nbsp;
                                    <%# DataBinder.Eval(Container.DataItem, "txtComment") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:DataList></table>
                <br />
                <asp:Panel ID="pnlLoginMsg" runat="server" CssClass="dkgrey12" Visible="false">
                    &nbsp; <a class="ltgreen_orange12" id="toggle2" href="#">Login</a> to write something.
                </asp:Panel>
                <asp:Panel ID="pnlLogin" runat="server" Height="80px" Width="250px" BackColor="#ff9900"
                    BorderColor="#FFFFFF" BorderWidth="1px">
                    <table>
                        <tr>
                            <td align="right" class="white12b">
                                E-mail:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="white12b">
                                Password:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnLogin" Text="Login" CssClass="dkgrey12b" runat="server" OnClick="btnLogin_Click" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCommentBox" runat="server" Visible="false">
                    <asp:Label ID="lblCommentBoxHeader" runat="server" CssClass="midgrey12" Text="Ask a question or comment"></asp:Label>&nbsp;
                    <span class="midgrey12">(keep it clean)</span>
                    <br />
                    <asp:TextBox ID="txtComment" onkeydown="CharCount(this,595)" runat="server" CssClass="dkgrey12"
                        Height="120px" Width="352px" MaxLength="255" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnPostComment" Text="Post Comment" runat="server" CssClass="dkgrey12"
                        OnClick="btnPostComment_Click" />
                </asp:Panel>
            </asp:Panel>
        </div>


    </div>
    <div id="sidebar">
    <div align="center">
        <%--COLUMN 2--%>
            <asp:Panel runat="server" ID="pnlHotBoards" BorderWidth="5" BorderColor="#f26721" ToolTip="Other boards you might like">
                <asp:DataList ID="dlUpgrades" runat="server" CssClass="red_orange12u" RepeatDirection="Horizontal"
                    RepeatColumns="1" RepeatLayout="Table" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <span class="ltgreen16b ">More Boards</span><br /><a class="grey_dkgrey10" href="../post_manager.aspx">+ add my board</span><br /><br />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="imgBtnHotBoard" OnCommand="ShowItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1")) %>' />
                        <br />
                        <asp:LinkButton ID="lnkBtnUpBrand" runat="server"><%# DataBinder.Eval(Container.DataItem, "txtBrand") %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "iHtFt")%>'&nbsp;<%# DataBinder.Eval(Container.DataItem, "iHtIn")%>"</asp:LinkButton>
                        <br /><br />
                    </ItemTemplate>
                </asp:DataList>
            </asp:Panel>
            </div>
            <br />
            <div style="text-align: center;">
            <!-- Start: Ads -->
            <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/D2T2A3Z27VD6NAHMMTLMNF/">
            </script>
            </div>            
    </div>
    <div id="footer">
        <%--<p>Footer</p>--%>
    </div>
</div>

        <br />

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
            <asp:HiddenField ID="hdniCat" runat="server" />
            <asp:HiddenField ID="hdnNotifyEmail" runat="server" />
            <asp:HiddenField ID="hdnUserId" runat="server" />
            <asp:HiddenField ID="hdnEndTime" runat="server" />            
        </div>

    </div>
    </form>
    <p>
    </p>
    <br>
    <div align="center">
        <table>
            <tr>
                <td colspan="4" class="ltgreen16b" align="center">
                    Sponsors</td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: center;">
                        <!-- Start: Ads -->

                        <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/TAWJZBACM5BZBDWTZLIYBN/">
                        </script>

                    </div>
                </td>
                <td>
                    &nbsp;
                    <div style="text-align: center;">
                        <!-- Start: Ads -->

                        <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/6HYKHM6BCVF7FBJ6DHZ2XC/">
                        </script>

                    </div>
                </td>
                <td>
                    <div style="text-align: center;">
                        &nbsp;
                        <!-- Start: Ads -->

                        <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/SUSGE3ERMFDSVJAUYM3DTI/">
                        </script>

                    </div>
                </td>
                <td>
                    <div style="text-align: center;">

                        <script type="text/javascript"><!--
            adroll_width = 125;
            adroll_height = 125;
            adroll_a_id = "H2ZFAHQ2VVC4VOWUL4UFZA";
            adroll_s_id = "6HRX4NZQLJAHJNQCOYZCFA";
            adroll_render_link = false;
            //--></script>

                        <script type="text/javascript" src="http://c.adroll.com/j/rolling.js"></script>

                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
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
