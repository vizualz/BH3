<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="surfboard.aspx.cs" Inherits="BoardHunt.surfboard" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Surfboard For Sale | Boardhunt</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Surfboards and other gear for sale, posted by surfers in the Boardhunt community." />
   <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>


    <!-- Font CSS (Via CDN) -->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">


    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

    <script language="JavaScript" src="include/js/bh.js" type="text/javascript"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="include/js/jquery.jgrowl.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/jquery.jgrowl.css" />

    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {

            $(function () {
                $('#imgTup').hover(function () {
                    $(this).attr('src', 'images/tup_on.gif');
                }, function () {
                    $(this).attr('src', 'images/tup_off.gif');
                });
            });
            $(function () {
                $('#imgTdown').hover(function () {
                    $(this).attr('src', 'images/tdown_on.gif');
                }, function () {
                    $(this).attr('src', 'images/tdown_off.gif');
                });
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
              });

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

            //bind click to buttons
            $('#imgTup').bind('click', function () {
                $.ajax({
                    type: 'POST',
                    url: '/wsBH/BHService.asmx/AddVote',
                    data: "{'bVal': '" + 1 + "', 'iEntry': '" + $('#hdnEId').val() + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=UTF-8",
                    success: function (data) {

                        $.ajax({
                            type: "POST",
                            url: "surfboard.aspx/setVoteDone",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                $("#imgTup").attr("disabled", "disabled");
                                $("#imgTup").attr("src", "/images/tup_dis.gif");
                                $("#imgTdown").attr("disabled", "disabled");
                                $("#imgTdown").attr("src", "/images/tdown_dis.gif");
                            }
                        });

                        $.ajax({
                            type: 'POST',
                            url: '/wsBH/BHService.asmx/GetVotes',
                            data: "{'iEntry': '" + $('#hdnEId').val() + "'}",
                            dataType: "json",
                            contentType: "application/json; charset=UTF-8",
                            success: function (data) {
                                $('#lblYesCnt').html(data.d.thumbsup);
                                $('#lblNoCnt').html(data.d.thumbsdown);
                                $('#lblGoodDeal').html("Thanks");
                            }

                        });
                    }

                });
            });

            //bind click to buttons
            $('#imgTdown').bind('click', function () {
                $.ajax({
                    type: 'POST',
                    url: '/wsBH/BHService.asmx/AddVote',
                    data: "{'bVal': '" + 0 + "', 'iEntry': '" + $('#hdnEId').val() + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=UTF-8",
                    success: function (data) {

                        $.ajax({
                            type: "POST",
                            url: "surfboard.aspx/setVoteDone",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                $("#imgTup").attr("disabled", "disabled");
                                $("#imgTup").attr("src", "/images/tup_dis.gif");
                                $("#imgTdown").attr("disabled", "disabled");
                                $("#imgTdown").attr("src", "/images/tdown_dis.gif");
                            }
                        });

                        $.ajax({
                            type: 'POST',
                            url: '/wsBH/BHService.asmx/GetVotes',
                            data: "{'iEntry': '" + $('#hdnEId').val() + "'}",
                            dataType: "json",
                            contentType: "application/json; charset=UTF-8",
                            success: function (data) {
                                $('#lblYesCnt').html(data.d.thumbsup);
                                $('#lblNoCnt').html(data.d.thumbsdown);
                                $('#lblGoodDeal').html("Thanks");
                            }
                        });
                    }
                });
            });
        });
    </script>
</head>

<body style="background: none repeat scroll 0 0 #fff;">

        <form class="header" id="Form1" runat="server">
            <bh:Header runat="server" />

            <%--PAGE NAV--%>
            <div align="left">
                
				<br />
					<asp:HyperLink CssClass="dkgrey_orange12" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>                           
					<span class="midorange12">&nbsp;>&nbsp;
						<asp:HyperLink CssClass="dkgrey_orange12" ID="HypCat" runat="server" NavigateUrl="Surfboardsforsale.aspx">
						</asp:HyperLink>
						<span class="midorange12">&nbsp;>&nbsp;
							<span class="midorange12">Details</span> 
						</span>
					</span>

				<div align="left" style="width: 150px; margin-bottom:30px; margin-top:5px; margin-left:0px">    
					<span class="dkrgrey20b"> 
					<asp:Button ID="btnPageNext" runat="server" Text="&uarr;" Width="50px" Height="40px" OnClick="btnPage_Click" title="Scroll Up" CssClass="btnTips btnStep" style="font-style:normal; font-weight:bolder; font-size: 22px;" />
					&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnPagePrev" runat="server" Text="&darr;" Width="50px" Height="40px" OnClick="btnPage_Click" title="Scroll Down" CssClass="btnTips btnStep" style="font-style:normal; font-weight:bolder; font-size: 22px;" />
					<br />
	          	</div>
          </div>

          					
                            <asp:Panel ID="pnlDetails" runat="server" role="tabpanel" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                                    <!-- Master Table -->
                                    <table cellspacing="0" align="center" width="680px" cellpadding="0" border="0" bgcolor="#FFFFFF"
                                        bordercolor="#999966" style="border:solid 0px black">
                                        <tr>
                                            <td valign="top">
                                                <!-- left side -->
                                                <table border="0" bgcolor="#FFFFFF" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="2" class="midorange26b" align="left">
                                                            <asp:Label ID="lblBrandData" runat="server" CssClass="midorange26b"></asp:Label>
                                                            <asp:Label ID="lblModel" runat="server" CssClass="midorange18"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" valign="top" align="left" style="height:28Spx">
                                                            &nbsp;<asp:Label ID="lblShaper" runat="server" CssClass="dkrgrey18g"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            &nbsp;&nbsp;
                                                            <asp:Image ID="Pic1" runat="server"></asp:Image>&nbsp;</td>
                                                    </tr>
  
                                                        <tr>
                                                            
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
                                                            <td align="right" class="dkrgrey16b" valign="middle" style="border:1px">
                                                                <asp:Label id="lblGoodDeal" runat="server" class="dkgrey14b">Is it a good deal?</asp:Label><br />
                                                                <asp:Label ID="lblYesCnt" runat="server" CssClass="dkgrey12"></asp:Label>&nbsp;
                                                            <asp:ImageButton ID="imgTup" runat="server" align="middle" 
                                                                ImageUrl="images/tup_off.gif" OnClientClick="return false;"
                                                                  Style="padding-bottom: 8px" ToolTip="Yep" />&nbsp;
                                                            <asp:ImageButton ID="imgTdown" runat="server" align="middle" OnClientClick="return false;"
                                                                ImageUrl="images/tdown_off.gif" 
                                                                Style="padding-bottom: 8px" ToolTip="Not" />
                                                                <asp:Label ID="lblNoCnt" runat="server" CssClass="dkgrey12"></asp:Label>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 15px; background-color: #FFFFFF">
                                                                <img src="images/s1x1.gif" alt="">
                                                            </td>
                                                        </tr>
                                                 
                                                </table>
                                            </td>
                                            <!-- end left side -->
                                            <td style="width: 15px; background-color: #FFFFFF">
                                                            <img src="images/s1x1.gif" alt=""/></td>
                                            <!-- begin right side -->
                                            <td valign="top">
                                                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#FFFFFF" bordercolor="red">

                                                        <tr>
                                                            <td colspan="2" class="dkrgrey16b" align="left">
                                                                <asp:Label ID="lblCondition" runat="server"></asp:Label>
                                                                <asp:Label ID="lblBoardTypeData" runat="server">
                                                                </asp:Label>
                                                                <asp:Label ID="lblBoardType" runat="server" nowrap></asp:Label>
                                                            </td>
                                                        </tr>

                                                    <tr>
                                                        <td class="midorange12" align="left" colspan="2">
                                                            in&nbsp;<asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td height="20" colspan="2">
                                                            <img src="images/s1x1.gif"/></td>
                                                    </tr>

                                                        <tr>
                                                            <td height="20px" class="dkrgrey14" align="left">
                                                                <asp:Label ID="lblHeight" runat="server"></asp:Label>
                                                           
                                                                
                                                          </td>
                                                            <td class="dkrgrey14">
                                                                &nbsp;<asp:Label ID="lblHeightFtData" runat="server">
                                                                </asp:Label>
                                                                <asp:Label ID="lblHeightInData" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td height="18px" class="dkgrey14" align="left">
                                                                <span class="dkrgrey14">Width</span>&nbsp;

                                                            </td>
                                                            <td class="dkrgrey14">
                                                                &nbsp;<asp:Label ID="lblWidthData" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td height="18px" class="dkgrey14" align="left">
                                                                <span class="dkrgrey14">Thickness</span>&nbsp;
                                                            
                                                                
                                                            </td>
                                                            <td class="dkrgrey14">
                                                                &nbsp;<asp:Label ID="lblThickData" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="18px" class="dkgrey14" align="left">
                                                                <span class="dkrgrey14">Tail</span>&nbsp;

                                                           </td>
                                                            <td class="dkrgrey14">
                                                                &nbsp;<asp:Label ID="lblTailData" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="18px" class="dkgrey14" valign="top" align="left">
                                                                <span class="dkrgrey14">Fins</span>&nbsp;                                                  

                                                            </td>
                                                            <td class="dkrgrey14">
                                                                &nbsp;<asp:Label ID="lblFinsData" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>


                                                    <tr>
                                                        <td style="height: 40px" colspan="2" class="dkrgrey16b" align="left" valign="bottom">
                                                            Seller Says&nbsp;</td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td class="dkgrey14" align="left" valign="bottom" colspan="2">
                                                            <asp:Label ID="lblDetailsData" runat="server"></asp:Label></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td height="20" colspan="2">
                                                            <img src="images/s1x1.gif"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="midorange20" bgcolor="#FF9900" align="center" valign="bottom" colspan="2">
                                                            &nbsp;<asp:Label ID="lblPriceData" CssClass="white24b" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                     </tr>
                                                      <tr>
                                                            
                                                        
                                                            <td bgcolor="#FF9900" colspan="2" class="white12" align="center" bgcolor="#FFFFFF" valign="bottom">
                                                                Will seller ship?&nbsp;<asp:Label ID="lblShip" CssClass="dkrgrey12b" runat="server">No</asp:Label>

                                                            </td>
                                                        

                                                   </tr>     
                                                    <tr>
                                                        <td bgcolor="#FFFFFF" height="20px" colspan="2">
                                                            <img src="images/s1x1.gif"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="dkgrey12" colspan="2"><asp:Button ID="btnNudge" Style="border-width: 1px" Width="90px" Height="40px" runat="server" CssClass="Tips"
                                                                Text="Nudge" OnClick="btnNudge_Click" />&nbsp;<asp:label id="lblNudgeText" runat="server"> to quickly check availablity</asp:label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="dkgrey12" colspan="2"><br /><br />
                                                            <img src="/images/email.gif" alt="Email seller" align="middle" />
                                                            <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="grey_orange12u">
                                                            </asp:LinkButton>&nbsp;seller with more questions
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="midorange12" align="left" style="height:30px" colspan="2">
                                                         <asp:Label ID="lblPhoneData" runat="server" CssClass="dkgrey12">
                                                        </asp:Label></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#FFFFFF" style="height: 5px" colspan="2">
                                                            <img src="images/s1x1.gif"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="controls3" align="left" bgcolor="#FFFFFF" colspan="2">
                                                            <asp:LinkButton ID="btnMore" CssClass="orange_grey12u" runat="server" Text="See more from this seller"
                                                                OnClick="btnMore_Click" /></td>
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

                            <%--RATINGS--%>
                            <div align="center" style="width: 670px; margin: 0 auto; border: solid 0 #F0F0F0">

                                    <table align="center" bgcolor="#f0f0f0" border="0" cellpadding="0" cellspacing="0"
                                        width="700px">
                                        <tr>
                                            <td bgcolor="#FFFFFF" colspan="4" style="height: 5px">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" bgcolor="#FFFFFF" align="left" colspan="2" style="height: 20px">
                                                &nbsp;&nbsp;<asp:ImageButton ID="imgGoBack" ToolTip="Back to results" runat="server"
                                                    ImageUrl="images/id_back.gif"></asp:ImageButton>&nbsp;<span class="dkrgrey16b">Back to Surfboards
                                                        </span></td>
                                            <td class="ltgrey10" align="right" bgcolor="#FFFFFF" colspan="2" valign="bottom"
                                                style="height: 20px">
                                                Posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" colspan="4" style="height: 5px">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr style="height: 30px">

                                        <td class="dkrgrey16" align="left">
                                                &nbsp;&nbsp;
                                                <asp:ImageButton ID="imgAddFav" runat="server" ImageUrl="images/favorites.gif" ToolTip="Add to My Favorites!">
                                                </asp:ImageButton>
                                            </td>
                                            <td align="center">
												SOCIAL Plugins
                                             <td align="right" class="dkgrey12">  
                                                <asp:Label CssClass="midorange16" ID="lblNudges" runat="server" ForeColor="#666666"></asp:Label> Nudges&nbsp;&nbsp; 
                                                <asp:Label CssClass="midorange16" ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label> Views&nbsp;&nbsp;
                                            </td> 
                                        </tr>
                                    </table>

                            </div>
                            <br />
                            <%--BEGIN COMMENTS--%>
                            <!-- #include file="include/Comments.aspx" -->

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
            <asp:HiddenField ID="hdnNudgeCnt" Value="" runat="server" />
            <div id="push">
            </div>
        </form>

    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->


    <!-- Bootstrap -->
    <script type="text/javascript" src="content/assets/js/bootstrap/bootstrap.min.js"></script>

    <!-- Theme Javascript -->
    <script type="text/javascript" src="content/assets/js/utility/utility.js"></script>
    <script type="text/javascript" src="content/assets/js/main.js"></script>
    <script type="text/javascript" src="content/assets/js/demo.js"></script>

    <!-- Page Javascript -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            "use strict";
            // Init Theme Core      
            Core.init();
            // Init Demo JS
            Demo.init();
        });
    </script>
    <%--Google analytics--%>
    <script type="text/javascript" src="../include/js/googles.js"></script>




    
</body>
</html>