<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="surfboard.aspx.cs" Inherits="BoardHunt.m.surfboard" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Surfboard For Sale | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="Surfboards and other gear for sale, posted by surfers in the Boardhunt community." />

    <script language="JavaScript" src="../include/js/bh.js" type="text/javascript"></script>

    <link href="../style/mob_global.css" type="text/css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/jquery-ui.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
            $('input.Tips').cluetip({ splitTitle: '|', clickThrough: true, width: 190, height: 'auto', dropShadow: false });
            $('input.btnTips').cluetip({ splitTitle: '|', clickThrough: true, width: 50, height: 'auto', dropShadow: false, showTitle: false });

            var oCtl;
            oCtl = document.getElementById('hdnMsg');
            if (oCtl != null) {
                if (oCtl.value.length > 1) {
                    $.jGrowl.defaults.position = 'center-middle';
                    $.jGrowl(oCtl.value, { sticky: true });
                }
            }

            $('#toggle2').hover(
              function () {
                  $('#pnlLogin').slideToggle('slow', function () {
                  });
              },
              function () {
              }
            );
            $('#pnlLogin').hide();

            var oCtl;
            oCtl = document.getElementById("hdnStatus");
            if (oCtl == null)
                return;

            if (oCtl.value == "3") {

                var $dialog = $('<div></div>')
		    .html('This item is SOLD')
		    .dialog({
		        autoOpen: false,
		        title: 'Boardhunt'
		    });


                $dialog.dialog('open');
                // prevent the default action, e.g., following a link
                return false;


            }


        });

    </script>

    <script type="text/javascript">
        function PreLoadImgs() {
            var i;
            var imgArray = new Array();

            for (i = 0; i <= 3; i++) {
                imgArray[i] = "hdnPicVal" + (i + 1);

                var ctl = document.getElementById("hdnPic" + (i + 1) + "URL");

                if (ctl.value != "") {
                    imgArray[i] = new Image(400, 400);
                    imgArray[i].src = ctl.value;
                }
            }
        }
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




</head>
<body bgcolor="#ffffff" onload="PreLoadImgs();">
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/HeaderMob.aspx" -->
            <%--PAGE NAV--%>
            <div align="left" style="width: 850px; margin-top:40px; margin-bottom:0px; margin-left:50px">
                <asp:Panel ID="pnlBreadCrumbs" runat="server">
                <asp:HyperLink CssClass="dkgrey_orange12" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>                           
                <span class="midorange12">&nbsp;>&nbsp;
                    <asp:HyperLink CssClass="dkgrey_orange12" ID="HypCat" runat="server" NavigateUrl="Surfboardsforsale.aspx">
                </asp:HyperLink>
                    <span class="midorange12">&nbsp;>&nbsp;<span class="midorange12">Details</span> </span>
                </span>
                </asp:Panel>
             <div align="left" style="width: 850px; margin-bottom:0px; margin-top:5px; margin-right:0px">    
                        <span class="dkrgrey40"> 
                        <asp:Button ID="btnPageNext" Width="400px" runat="server" Text="< 1 BOARD UP" OnClick="btnPage_Click" title="| 1 board up" CssClass="btnTips btnCancel" />
                        &nbsp;</span>&nbsp;<asp:Button ID="btnPagePrev" runat="server" Text="1 BOARD DOWN >" Width="400px" OnClick="btnPage_Click" title="| 1 board down" CssClass="btnTips btnCancel" />
          </div></div>
            <div align="center">
                <div align="center" id="container" style="width: 1100px">
                    <div id="wrapper" align="center" style="width: 1090px">
                        <%--LEFT COLUMN--%>
                        <div id="left">
                            &nbsp;
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%--BOOST HERE--%>
                            &nbsp;
                        </div>
                        <%--CENTER COLUMN--%>
                        <div id="center">
                            <asp:Panel ID="pnlDetails" runat="server" Style="width: 100%; height:602px; margin-left:30px" BorderColor="#FF9900"
                                BorderStyle="solid" BorderWidth="0px">
                                    

                                <div style="margin-left:60px; width:100%; float:left">
                                    <!-- Master Table -->
                                    <table cellspacing="0" align="center" width="100%" cellpadding="0" border="0" bgcolor="#FFFFFF"
                                        bordercolor="#999966" style="border:solid 0px black">
                                        <tr>
                                            <td valign="top">
                                                <!-- left side -->
                                                <table border="0" bgcolor="#FFFFFF" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="2" class="midorange40b" align="left">
                                                            <asp:Label ID="lblBrandData" runat="server" CssClass="midorange40b"></asp:Label>
                                                            <asp:Label ID="lblModel" runat="server" CssClass="midorange18"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" valign="top" align="left" style="height:28Spx">
                                                            &nbsp;<asp:Label ID="lblShaper" runat="server" CssClass="dkrgrey30g"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            &nbsp;&nbsp;<span class="photo"><asp:Image ID="Pic1" runat="server"></asp:Image></span>&nbsp;</td>
                                                    </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 1px">
                                                                <img src="../images/s1x1.gif" alt="" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="dkrgrey16" valign="middle">
<%--                                                            Rate&nbsp;&nbsp;<br />
                                                            <asp:ImageButton ID="star1" runat="server" align="middle" CommandArgument="1" 
                                                                ImageUrl="../images/target_white.gif" OnCommand="ProcRating" 
                                                                onmouseout="GetRating()" onmouseover="ProcHover('1')" 
                                                                Style="padding-bottom: 8px" ToolTip="Ugly" />
                                                            <asp:ImageButton ID="star2" runat="server" align="middle" CommandArgument="2" 
                                                                ImageUrl="../images/target_white.gif" OnCommand="ProcRating" 
                                                                onmouseout="GetRating()" onmouseover="ProcHover('2')" 
                                                                Style="padding-bottom: 8px" ToolTip="Bad" />
                                                            <asp:ImageButton ID="star3" runat="server" align="middle" CommandArgument="3" 
                                                                ImageUrl="../images/target_white.gif" OnCommand="ProcRating" 
                                                                onmouseout="GetRating()" onmouseover="ProcHover('3')" 
                                                                Style="padding-bottom: 8px" ToolTip="OK" />
                                                            <asp:ImageButton ID="star4" runat="server" align="middle" CommandArgument="4" 
                                                                ImageUrl="../images/target_white.gif" OnCommand="ProcRating" 
                                                                onmouseout="GetRating()" onmouseover="ProcHover('4')" 
                                                                Style="padding-bottom: 8px" ToolTip="Good" />
                                                            <asp:ImageButton ID="star5" runat="server" align="middle" CommandArgument="5" 
                                                                ImageUrl="../images/target_white.gif" OnCommand="ProcRating" 
                                                                onmouseout="GetRating()" onmouseover="ProcHover('5')" 
                                                                Style="padding-bottom: 8px" ToolTip="Super!" /><br />
                                                            <asp:Label ID="lblRatingCount" runat="server" CssClass="dkgrey12"></asp:Label>--%>
                                                            
                                                            </td>
                                                            <td>
                                                                <asp:Image ID="Pic1ThmbNail" runat="server" BorderWidth="0" 
                                                                    CssClass="highlightit" onmouseover="ImgHover('1')" Visible="false" />
                                                                &nbsp;
                                                                <asp:Image ID="Pic2ThmbNail" runat="server" BorderWidth="0" 
                                                                    CssClass="highlightit" onmouseover="ImgHover('2')" Visible="false" />
                                                                &nbsp;
                                                                <asp:Image ID="Pic3ThmbNail" runat="server" BorderWidth="0" 
                                                                    CssClass="highlightit" onmouseover="ImgHover('3')" Visible="false" />
                                                                &nbsp;
                                                                <asp:Image ID="Pic4ThmbNail" runat="server" BorderWidth="0" 
                                                                    CssClass="highlightit" onmouseover="ImgHover('4')" Visible="false" />
                                                                

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 15px; background-color: #FFFFFF">
                                                                <img src="../images/s1x1.gif" alt=""></img></td>
                                                        </tr>
                                                    <tr>
                                                        <td height="30px" valign="bottom" class="dkgreyb_titles" colspan="3" align="left">
                                                            Contact by &nbsp;<asp:LinkButton ID="lnkEmailData" runat="server" CssClass="orange_dkorange40">
                                                             </asp:LinkButton>&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            &nbsp;<asp:Button Visible="false" ID="btnNudge" Style="border-width: 2px" Width="100px" Height="35px" runat="server" CssClass="Tips"
                                                                Text="Nudge" OnClick="btnNudge_Click" /></td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            &nbsp;&nbsp;<asp:Label ID="lblPhoneData" runat="server" CssClass="dkgreyb_bodytext">
                                            </asp:Label></td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>
                                            <!-- end left side -->
<%--                                            <td style="width: 15px; background-color: #FFFFFF">
                                                            <img src="../images/s1x1.gif" alt=""/></td>--%>
                                            <!-- begin right side -->
                                            <td valign="top" style="padding-left: 30px">
                                                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#FFFFFF" bordercolor="#FFFFFF">
                                                    <asp:Panel runat="server" ID="pnlGearItem" Visible="false">
                                                        <tr>
                                                            <td height="20px" width="40%" class="dkgrey16b" align="left">
                                                                Item:&nbsp;
                                                            </td>
                                                            <td class="dkgrey14" align="left" valign="bottom" width="60%">
                                                                <asp:Label ID="lblGearItem" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <img src="../images/s1x1.gif" height="10" alt="spacer" /></div>
                                                        </td>
                                                    </tr>
                                                  
                                                    <asp:Panel runat="server" ID="pnlBoardType">
                                                        <tr>
                                                            <td colspan="2" class="dkgreyb_titles" align="left">
                                                                a
                                                                <asp:Label ID="lblCondition" runat="server"></asp:Label>
                                                                <asp:Label ID="lblBoardTypeData" runat="server"></asp:Label>
                                                              
                                                                <asp:Label ID="lblBoardType" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 10px">
                                                            &nbsp;
                                                        </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    
                                                       
                                                    
                                                    <tr>
                                                        <td align="left" colspan="1" width="300px">
                                                        <asp:Panel runat="server" ID="pnlCondition" Visible="false">
                                                     </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="midorange30" align="left">
                                                            in&nbsp;<asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 10px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <asp:Panel ID="pnlAll" runat="server">
                                                        <tr>
                                                            <td height="20px" class="dkgreyb_details" align="left">
                                                                <asp:Label ID="lblHeight" runat="server"></asp:Label></td>
                                                            <td class="dkgrey_details" align="left" valign="bottom">
                                                                <asp:Label ID="lblHeightFtData" runat="server">
                                                </asp:Label>
                                                                <asp:Label ID="lblHeightInData" runat="server">
                                                </asp:Label></td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlWidth" runat="server">
                                                        <tr>
                                                            <td height="18px" class="dkgreyb_details" align="left">
                                                                Width:&nbsp;</td>
                                                            <td class="dkgrey_details" align="left" valign="bottom">
                                                                <asp:Label ID="lblWidthData" runat="server">
                                                </asp:Label></td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlSurfOnly" runat="server">
                                                        <tr>
                                                            <td height="18px" class="dkgreyb_details" align="left">
                                                                Thick:&nbsp;</td>
                                                            <td class="dkgrey_details" align="left" valign="bottom">
                                                                <asp:Label ID="lblThickData" runat="server">
                                                </asp:Label></td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="18px" class="dkgreyb_details" align="left">
                                                                Tail:&nbsp;</td>
                                                            <td class="dkgrey_details" align="left" valign="bottom">
                                                                <asp:Label ID="lblTailData" runat="server">
                                                </asp:Label></td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="18px" class="dkgreyb_details" valign="top" align="left">
                                                                Fins:&nbsp;</td>
                                                            <td class="dkgrey_details" align="left" valign="bottom">
                                                                <asp:Label ID="lblFinsData" runat="server">
                                                </asp:Label></td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlGenDims" Visible="false" runat="server">
                                                        <tr>
                                                            <td height="18px" class="dkgrey14b" align="left">
                                                                Dimensions:&nbsp;</td>
                                                            <td class="dkgrey14" align="left" valign="bottom">
                                                                <asp:Label ID="lblGenDims" runat="server">
                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlShip" runat="server" Visible="true">
                                                        <tr style="height: 50px">
                                                            <td colspan="2" class="midorange30" align="left" bgcolor="#FFFFFF" valign="bottom">
                                                                Shipping Available:&nbsp;<asp:Label ID="lblShip" CssClass="dkrgrey24" runat="server">No</asp:Label>
                                                                <%--<hr style="background-color:#FF9900;height:2px" />--%>
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                   
                                                    
                                                    <tr>
                                                        <td colspan="2" height="20">
                                                            <img src="../images/s1x1.gif"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="midorange20" bgcolor="#FF9900" align="center" valign="bottom">
                                                            &nbsp;<asp:Label ID="lblPriceData" CssClass="white80b" runat="server">
                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#FFFFFF" height="20px" colspan="2">
                                                            <img src="../images/s1x1.gif"></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td style="height: 60px" class="dkgreyb_titles" align="left" valign="bottom">
                                                            Details:&nbsp;</td>
                                                        <td style="width: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dkgreyb_bodytext" align="left" valign="bottom" style="width:400px">
                                                            <asp:Label ID="lblDetailsData" runat="server"></asp:Label></td>
                                                        <td style="width: 15px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    <tr>
                                                        <td bgcolor="#FFFFFF" style="height: 5px">
                                                            <img src="../images/s1x1.gif"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="controls3" align="left" bgcolor="#FFFFFF">
                                                            <%--<asp:LinkButton ID="btnMore" CssClass="orange_grey12u" runat="server" Text="See more from this user"
                                                                OnClick="btnMore_Click" />--%>
                                                        </td>
                                                        <td style="width: 5px">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="header" colspan="3">
                                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <!-- end master table -->
                                    </div>
                            </asp:Panel>
                            <%--RATINGS--%>
                            <div align="center" style="width: 670px; margin: 0 auto; border:1px solid #F0F0F0">
                                <asp:Panel ID="pnlRatings" runat="server" HorizontalAlign="Center" Visible="false">
                                    <table align="center" bgcolor="#f0f0f0" border="0" cellpadding="0" cellspacing="0"
                                        width="670px">
                                        <tr>
                                            <td bgcolor="#FFFFFF" colspan="4" style="height: 5px">
                                                <img src="../images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" bgcolor="#FFFFFF" align="left" colspan="2" style="height: 20px">
                                                &nbsp;&nbsp;<asp:ImageButton ID="imgGoBack" ToolTip="Back to results" runat="server"
                                                    ImageUrl="../images/id_back.gif"></asp:ImageButton>&nbsp;<span class="dkrgrey16">Go Back
                                                        </span></td>
                                            <td class="ltgrey10" align="right" bgcolor="#FFFFFF" colspan="2" valign="bottom"
                                                style="height: 20px">
                                                Posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" colspan="4" style="height: 5px">
                                                <img src="../images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr style="height: 30px">

                                        <td class="dkrgrey16" align="left">
                                            empty space
                                            </td>
                                            <td align="center">
                                          </td>
                                            <td align="right" class="dkrgrey16">
                                                Views:
                                                <asp:Label CssClass="midorange16" ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;
                                            </td>

                                           
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <br />
                            <%--BEGIN COMMENTS--%>
                            <!-- COMMENTS WERE HERE -->

                            <%--TILEAD--%>
                            <div align="center">
                                <br />
                                <br />
                                <br />
                                &nbsp;
                            </div>
                        </div>
                        <%--WRAPPER--%>
                    </div>
                    <%--CONTAINER--%>
                </div>
            </div>
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
            <asp:HiddenField ID="hdnRatingVal" runat="server" />
            <asp:HiddenField ID="hdnRatingCnt" runat="server" />
            <asp:HiddenField ID="hdnStatus" runat="server" />
            <asp:HiddenField ID="hdnMsg" Value="" runat="server" />
            <asp:HiddenField ID="hdnAcctStatus" Value="" runat="server" />

            <br /><br /><br />
            <asp:Literal runat="server" ID="ltrAds"></asp:Literal>

            <div id="push">
            </div>
        </form>
        <%--MAIN--%>
    </div>
    <br />
    <br />
    <div align="center" id="footer">
        <!-- #include file="../include/footerMob.aspx" -->
    </div>

    <%--Google analytics--%>
    <script type="text/javascript" src="../include/js/googles.js"></script>


  <%--Crazy Egg--%>
<script type="text/javascript">
    setTimeout(function () {
        var a = document.createElement("script");
        var b = document.getElementsByTagName('script')[0];
        a.src = document.location.protocol + "//dnn506yrbagrg.cloudfront.net/pages/scripts/0011/7491.js";
        a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
    }, 1);
</script>
</body>
</html>
