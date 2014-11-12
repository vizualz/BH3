<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Matrix.aspx.cs" Inherits="BoardHunt.Matrix" %>

<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="include/Controls/Boost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://opengraphprotocol.org/schema/"
    xmlns:fb="http://www.facebook.com/2008/fbml">
<head runat="server">
    <title>Surfboards for Sale | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>

    <script type="text/javascript" src="http://www.malzook.com/include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="http://www.malzook.com/style/superfish.css" />

    <script src="http://www.malzook.com/include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="http://www.malzook.com/style/jquery.cluetip.css" type="text/css" />
    <meta name="description" content="New and used Surfboards, and other boarding gear, for sale by surfers in the Boardhunt community" />
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboards For Sale"
        href="http://www.malzook.com/rss/surfboards.xml" />
    <style type="text/css">
        #slider { margin: 10px; }
    </style>

    <script type="text/javascript">
  $(document).ready(function() {
    var oCtl;

    $('img.Tips').cluetip({splitTitle: '|',clickThrough:     true});
    $('div.Tips').cluetip({splitTitle: '|',clickThrough:     false});

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });

    $("#slider").slider();
    $("#slider").slider( "option", "max", 300 );
    $("#slider").slider( "option", "min", 100 );

    oCtl = document.getElementById("hdnWeight");
    if (oCtl != null)
    {
        $("#slider").slider( "value", oCtl.value );
    }        

    $("#slider").bind( "slide", function(event, ui) {
        var oCtl;
        oCtl = document.getElementById("txtWeight");
        if (oCtl != null)
        {
            oCtl.value = ui.value;
        }
    });
    
    oCtl = document.getElementById("rdoWaveType_0");
    if (oCtl != null)
    {
        oCtl.setAttribute("OnClick", "ShowPic('wave_roller.gif')");
    } 
    oCtl = document.getElementById("rdoWaveType_1");
    if (oCtl != null)
    {
        oCtl.setAttribute("OnClick", "ShowPic('wave_barrel.gif')");
    } 
    
  });
  function ShowPic(val)
  {
    oCtl = document.getElementById("imgWaveType");
    if (oCtl != null)
    {
        oCtl.src = "http://www.malzook.com/images/" + val; 
    }
  }
  function CheckNum(oCtl)
  {
    if (oCtl == null)
    return;
    
    if (isNaN(oCtl.value))
    {
        if (oCtl.id == "txtHtFt")
            oCtl.value = "5";
        if (oCtl.id == "txtHtIn")
            oCtl.value = "9";
        if (oCtl.id == "txtWeight")
        {
            oCtl.value = "155";
            $("#slider").slider( "value", 155 ); 
        }            
               
    }
    
  }
  function resetFilter()
  {
    $("#slider").slider( "option", "max", 300 );
    $("#slider").slider( "option", "min", 100 );
    $("#slider").slider( "value", 155 );    
    
    var oCtl;
    
    oCtl = document.getElementById("txtHtFt");
    if (oCtl != null)
    {
        oCtl.value = "5"; 
    }
    
    oCtl = document.getElementById("txtHtIn");
    if (oCtl != null)
    {
        oCtl.value = "9";
    }        
    
    oCtl = document.getElementById("txtWeight");
    if (oCtl != null)
    {
        oCtl.value = $("#slider").slider( "option", "value" )
    }
    
    document.getElementById("cboLevel").value="1";
    document.getElementById("cboWaveSize").value="2";
    
    var rdoCtl = document.getElementsByName("rdoWaveType")
	for(var i = 0; i < rdoCtl.length; i++) {
		rdoCtl[i].checked = false;
		if(rdoCtl[i].value == "1") {
			rdoCtl[i].checked = true;
		}
    }
     
    ShowPic('wave_roller.gif');
     
    //document.getElementById("rdoWaveType_0").value="1"; 
    //alert(document.getElementById("rdoWaveType")[0].value);  

    $("#slider").bind( "slide", function(event, ui) {
        var oCtl;
        oCtl = document.getElementById("txtWeight");
        if (oCtl != null)
        {
            oCtl.value = ui.value;
        }
    });
  }
    </script>

    <meta property="fb:app_id" content="143749072318586" />
    
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
    <div id="fb-root">
    </div>

    <script>
      window.fbAsyncInit = function() {
        FB.init({appId: '143749072318586', status: true, cookie: true,
                 xfbml: true});
      };
      (function() {
        var e = document.createElement('script');
        e.type = 'text/javascript';
        e.src = document.location.protocol +
          '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
      }());
    </script>

    <div id="main" align="center">
        <form id="Form1" runat="server" defaultbutton="btnSearch">
            <!-- #include file="include/Header.aspx" -->
            <%--PAGE NAV--%>
            <div align="center" class="dkgrey18v" style="margin-left:500px; width: 500px; text-align: left;"><br />
                <asp:Label ID="lblPage" runat="server" CssClass="midgreen24b">Board Matrix</asp:Label>&nbsp;<span
                    class="red10" valign="top">beta</span><br />
                <span class="dkrgrey14">What board should I ride?</span>
            </div>
            <div align="center">
                <div align="center" id="container" style="width: 1100px;">
                    <div id="wrapper" align="center" style="width: 1000px">
                        <%--LEFT COLUMN--%>
                        <%--FILTER--%>
                        <div id="left" style="width: 170px;">
                            <br />
                            <!-- Start: Ads -->
                            <!-- #include file="include/ads/SkyScraperAd.htm" -->
                        </div>
                        <%--RIGHT COLUMN--%>
                        <div id="right">
                            <%--BOOST HERE--%>
                            <bh:ShowBoost ID="boost1" runat="server">
                            </bh:ShowBoost>
                            <!-- #include file="include/Boardhelp.aspx" --> 
                        </div>
                        <!-- end right column-- >
        
                    <!--CENTER COLUMN-->
                        <div id="center" style="width: 700px">
                            <br />
                            <asp:Panel runat="server" Width="550px" ID="pnlFilter" BorderStyle="solid" BorderColor="#99CC33"
                                BorderWidth="0">
                                <table border="0" bgcolor="#ffffff" width="550px" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td style="background-color: #336600; height: 5px;" colspan="2" class="white24b"
                                            align="center" nowrap>
                                            Identify yourself.</td>
                                        <td colspan="1" align="right" style="background-color: #336600">
                                            <div style="padding-top: 0px; width: 330px; border: solid 0px #333333; float: right;
                                                background-color: #336600" align="right">
                                                <asp:Label ID="lblFB" runat="server" Width="300" BorderWidth="0"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 1px">
                                            <div style="background-color: #ffffff; height: 1px;">
                                                <img height="1" src="http://www.malzook.com/images/s1x1.gif" alt="spacer" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="3" style="width: 134px">
                                            <img src="http://www.malzook.com/images/bodymatrix.gif" height="180" width="100"
                                                border="0" alt="matrix" /></td>
                                        <td align="right" class="dkgrey18" style="border-right: solid 1px #CCCCCC">
                                            Height:&nbsp;</td>
                                        <td align="left">
                                            <span class="dkgrey20b">
                                                <asp:TextBox ID="txtHtFt" onkeyup="CheckNum(this)" OnClick="select()" runat="server"
                                                    Width="15" Text="5" CssClass="dkrgrey18b"></asp:TextBox>&nbsp;'&nbsp;
                                                <asp:TextBox ID="txtHtIn" onkeyup="CheckNum(this)" OnClick="select()" CssClass="dkrgrey18b"
                                                    runat="server" Text="9" Width="15"></asp:TextBox>&nbsp;"</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="dkgrey18" style="border-right: solid 1px #CCCCCC">
                                            Weight:&nbsp;</td>
                                        <td align="left" class="dkgrey12" nowrap>
                                            <div style="border: solid 0px red; height: 40px">
                                                <div style="width: 80px; float: left; border: solid 0px black; margin: 5px">
                                                    <asp:TextBox ID="txtWeight" onkeyup="CheckNum(this)" runat="server" CssClass="dkrgrey18b"
                                                        Width="40px"></asp:TextBox>&nbsp;lbs.
                                                </div>
                                                <div id="slider" style="font-size: 62.5%; width: 150px; float: left;">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="dkgrey18" style="border-right: solid 1px #CCCCCC">
                                            Skill Level:&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboLevel" Width="130" runat="server" CssClass="dkrgrey18b">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 2px">
                                            <div style="background-color: #ffffff; height: 2px;">
                                                <img height="2" src="http://www.malzook.com/images/s1x1.gif" alt="spacer" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 134px" align="center">
                                            <img id="imgWaveType" src="http://www.malzook.com/images/wave_roller.gif" border="0" alt="wave type" /></td>
                                        <td align="right" class="dkgrey18" style="border-right: solid 1px #CCCCCC">
                                            Wave Type:&nbsp;</td>
                                        <td align="left">
                                            <asp:RadioButtonList CssClass="dkgrey12" RepeatDirection="Horizontal" ID="rdoWaveType"
                                                runat="server">
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td nowrap align="right" class="dkgrey18" style="height: 20px; border-right: solid 1px #CCCCCC">
                                            Wave Height:&nbsp;</td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboWaveSize" Width="130" CssClass="dkrgrey18b" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 1px; border-bottom: solid 0px #FFFFFF">
                                            <div style="background-color: #ffffff; height: 1px;">
                                                <img height="1" src="http://www.malzook.com/images/s1x1.gif" alt="spacer" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                        <td align="left">
                                            <asp:Button ID="btnSearch" Text="Go" runat="server" CssClass="midgreen24b" Width="130px"
                                                OnClick="btnSearch_Click" />&nbsp;&nbsp; <a href="javascript:resetFilter()" class="dkgrey_orange12">
                                                    clear</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #99CC33; height: 1px" colspan="3">
                                            <div style="background-color: #99CC33; height: 1px;">
                                                <img height="1" src="http://www.malzook.com/images/s1x1.gif" alt="spacer" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="left">
                                            <asp:Panel ID="pnlResult" runat="server" BackColor="AliceBlue">
                                                &nbsp;<asp:Label ID="lblResultIntro" runat="server" CssClass="dkrgrey20b" Visible="false">&nbsp;Try this for starters:</asp:Label>
                                                <div style="float: right" title="Disclaimer|These suggestions are not exact.  Use as a starting point only as your final dims may slightly vary based on preference and experience."
                                                    class="Tips">
                                                    <span class="red12">*Disclaimer</span></div>
                                                &nbsp;<asp:Label ID="lblHeight" runat="server"></asp:Label><br />
                                                &nbsp;<asp:Label ID="lblRails" runat="server"></asp:Label><br />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="3" align="left">
                                            <asp:Panel ID="pnlShaperResults" runat="server" BackColor="Beige" Visible="false">
                                                <asp:Label ID="lblSHResultIntro" runat="server" CssClass="dkrgrey20b" Visible="false">&nbsp;Shapers that can help:</asp:Label>
                                                <div style="float: right" title="Info|Visit Shaperhouse to these the Shapers who are ready to help you"
                                                    class="Tips">
                                                    <span class="red12">[?]</span></div>
                                                &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label><br />
                                                <asp:Label ID="Label3" runat="server"></asp:Label><br />
                                            </asp:Panel>                                    
                                    </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                            <asp:HiddenField ID="hdnLocVal" Value="" runat="server" />
                            <asp:HiddenField ID="hdniCat" Value="" runat="server" />
                            <asp:HiddenField ID="hdnServer" Value="" runat="server" />
                            <asp:HiddenField ID="hdniBoardType" Value="" runat="server" />
                            <asp:HiddenField ID="hdnKeywords" Value="" runat="server" />
                            <asp:HiddenField ID="hdnUiD" Value="" runat="server" />
                            <asp:HiddenField ID="hdnWeight" Value="" runat="server" />
                            <asp:HiddenField ID="hdnBoardCode" Value="" runat="server" />
                            <br />
                            <br />
                        </div>
                        <%--END CENTER--%>
                    </div>
                     <%--TILEAD--%>
                            <div align="center">
                                <br />
                                <br />
                                <br />
                                <!-- #include file="include/ads/tileAd.htm" -->
                            </div>
                    <%--END WRAPPER--%>
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                    </div>
                </div>
                <%--END CONTAINER--%>
            </div>
            <div id="push">
            </div>
        </form>
    </div>
    <%--END MAIN--%>
    <br />
    <div align="center" id="footer">
        <!-- #include file="include/footer.aspx" -->
    </div>

    <script type="text/javascript" src="http://www.malzook.com/include/js/googles.js"></script>

</body>
</html>
