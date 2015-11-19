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
        <div class="container-fluid col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <bh:Header runat="server" />

            <%--PAGE NAV--%>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                            <asp:Panel ID="pnlDetails" runat="server" role="tabpanel" class="admin-form tab-pane active 
                                col-lg-10 col-md-10 col-sm-10 col-xs-10" style="float: none; margin: 0 auto;">
            <!-- Master DIV -->
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <asp:HyperLink CssClass="dkgrey_orange12" ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink>&nbsp;&nbsp;
                                           
                                            <asp:HyperLink CssClass="dkgrey_orange12" ID="HypCat" runat="server" NavigateUrl="Surfboardsforsale.aspx">
                                            </asp:HyperLink>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                            <asp:Button ID="btnPageNext" runat="server" Text="&uarr;" Width="50px" Height="40px" OnClick="btnPage_Click" title="Scroll Up" CssClass="btnTips btnStep" style="font-style:normal; font-weight:bolder; font-size: 22px;" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnPagePrev" runat="server" Text="&darr;" Width="50px" Height="40px" OnClick="btnPage_Click" title="Scroll Down" CssClass="btnTips btnStep" style="font-style:normal; font-weight:bolder; font-size: 22px;" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"> 
                                            <asp:Label ID="lblBrandData" runat="server" CssClass="midorange26b"></asp:Label>
                                            <asp:Label ID="lblModel" runat="server" CssClass="midorange18"></asp:Label>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"> 
                                            <asp:Label ID="lblCondition" runat="server" CssClass="midorange26b"></asp:Label>
                                            <asp:Label ID="lblBoardTypeData" runat="server" CssClass="midorange26b">
                                            </asp:Label>
                                            <asp:Label ID="lblBoardType" runat="server" CssClass="dkrgrey18g" nowrap></asp:Label>   
                                        </div>
                                    </div>   
                                    <div class="row">  
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"> 
                                            <asp:Label ID="lblShaper" runat="server" CssClass="dkrgrey18g"></asp:Label>      
                                        </div> 
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"> 
                                            <label for="username" class="field-label text-left fs18 mb10">
                                            <asp:Label ID="lblLocation" runat="server"></asp:Label></label                             
                                        </div> 
                                    </div>    
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"> 
                                            
        <!-- Images & Thumbnails-->
                                            
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                    <asp:Image ID="Pic1" class="img-responsive" runat="server"></asp:Image>&nbsp;
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
                                                    <br><asp:Image ID="Pic1ThmbNail" runat="server" BorderWidth="0" 
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
                                                </div>
                                            </div>    
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  

        <!-- Ratings -->

                                                    <asp:Label id="lblGoodDeal" runat="server">Good deal?</asp:Label>&nbsp;                                                   
                                                    <asp:ImageButton ID="imgTup" runat="server" align="middle" 
                                                    ImageUrl="images/tup_off.gif" OnClientClick="return false;"
                                                    Style="padding-bottom: 8px" ToolTip="Yep" />&nbsp;<asp:Label ID="lblYesCnt" runat="server" CssClass="dkgrey12"></asp:Label>&nbsp;
                                                    
                                                    <asp:ImageButton ID="imgTdown" runat="server" align="middle" OnClientClick="return false;"
                                                    ImageUrl="images/tdown_off.gif" 
                                                    Style="padding-bottom: 8px" ToolTip="Not" />
                                                    <asp:Label ID="lblNoCnt" runat="server" CssClass="dkgrey12"></asp:Label>&nbsp;
                                                
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">  
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                    <label for="username" class="field-label text-left fs18 mb10"><b><asp:Label ID="lblHeight" runat="server"></b></asp:Label><asp:Label ID="lblHeightFtData" runat="server">
                                                    </asp:Label>&nbsp; 
                                                    <asp:Label ID="lblHeightInData" runat="server">
                                                    </asp:Label></label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label for="username" class="field-label text-left fs18 mb10"><b>Width</b>&nbsp;&nbsp;
                                                    <asp:Label ID="lblWidthData" runat="server">
                                                    </asp:Label></label>
                                                </div>  
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label for="username" class="field-label text-left fs18 mb10"><b>Thickness</b>&nbsp;
                                                    &nbsp;<asp:Label ID="lblThickData" runat="server">
                                                    </asp:Label></label>
                                                </div>         
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label for="username" class="field-label text-left fs18 mb10"><b>Tail</b>&nbsp;
                                                    &nbsp;<asp:Label ID="lblTailData" runat="server">
                                                    </asp:Label></label>
                                                </div>         
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                     <label for="username" class="field-label text-left fs18 mb10"><b>Fins</b>&nbsp;                                                  
                                                    <asp:Label ID="lblFinsData" runat="server">
                                                    </asp:Label></label>
                                                </div>         
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                     <label for="username" class="field-label text-left fs18 mb10"><b>Seller Says</b></label>
                                                </div>         
                                            </div>   
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                     <asp:Label ID="lblDetailsData" runat="server"></asp:Label></label>
                                                </div>         
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                    &nbsp;<asp:Label ID="lblPriceData" CssClass="midorange26b" runat="server">
                                                    </asp:Label>
                                                </div>         
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                    </asp:Label>Will seller ship?&nbsp;<asp:Label ID="lblShip" runat="server">No</asp:Label>
                                                </div>         
                                            </div>            
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                     &nbsp;<asp:Button ID="btnNudge" Style="border-width: 1px" Width="90px" Height="40px" runat="server" 
                                                     Text="Nudge" OnClick="btnNudge_Click" />&nbsp;<asp:label id="lblNudgeText" runat="server"> to check availablity</asp:label>
                                                </div>         
                                            </div>               
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                                                     &nbsp;<img src="/images/email.gif" alt="Email seller" align="middle" />
                                                    <asp:LinkButton ID="lnkEmailData" runat="server">
                                                    </asp:LinkButton>
                                                     &nbsp;| text or call&nbsp;<asp:Label ID="lblPhoneData" runat="server">
                                                    </asp:Label>
                                                </div>         
                                            </div> 
                                            <div class="row">
                                                <br>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                     &nbsp;<asp:LinkButton ID="btnMore" class="fs14" runat="server" Text="Seller's Garage View"
                                                     OnClick="btnMore_Click" />
                                                </div>         
                                            </div>                 
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                     &nbsp;<asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                </div>         
                                            </div> 
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     
                            
                                                    
                                                    <asp:ImageButton ID="imgGoBack" ToolTip="Back to results" runat="server"
                                                    ImageUrl="images/id_back.gif"></asp:ImageButton>&nbsp;Back to results
                                                                                           
                                                    

                                                    <!--<asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    
                                                    <asp:ImageButton ID="imgAddFav" runat="server" ImageUrl="images/favorites.gif" ToolTip="Add to My Favorites!">
                                                    </asp:ImageButton>-->
                                                    
                                                    <br>                                      
                                                    <!-- AddThis Button BEGIN -->
                                                    <div class="addthis_toolbox addthis_default_style addthis_32x32_style">
                                                    <a class="addthis_button_preferred_1"></a>
                                                    <a class="addthis_button_preferred_2"></a>
                                                    <a class="addthis_button_preferred_3"></a>
                                                    <a class="addthis_button_compact"></a>
                                                    </div>
                                                    <div>
                                                    <script type="text/javascript">                                                        var addthis_config = { "data_track_clickback": true };</script>
                                                    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4df1178f225b17c1"></script>
                                                    
                                                    <!-- AddThis Button END -->
                                                    <br>
                                                    <asp:Label ID="lblNudges" runat="server" ForeColor="#666666"></asp:Label> Nudges&nbsp;&nbsp; 
                                                    <asp:Label ID="lblPageViewCount" runat="server" ForeColor="#666666"></asp:Label> Views&nbsp;&nbsp; <br>
                                                    
                                                    <%--BEGIN COMMENTS--%>
                                                </div>
                                            </div>     
                                        </div>  
                                    </div>                 
                            </asp:Panel>                                         
                        </div>          
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><br>
                        <!-- #include file="include/Comments.aspx" -->
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
                        <asp:HiddenField ID="hdnNudgeCnt" Value="" runat="server" />
                <div id="push">
                </div>
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