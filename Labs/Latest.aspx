<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Latest.aspx.cs" Inherits="BoardHunt.Labs.Latest" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html>

<head runat="server">
    <title>Latest</title>
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script type="text/javascript">
      $(document).ready(function() {
        // This is more like it!
		// initialise plugins
		jQuery(function(){
			jQuery('ul.sf-menu').superfish();
		});

      });
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <br /><br /><br />
    <div align="center">
 
 
<script type="text/javascript">
        function navTo(p1)
        {
            myDNS=document.domain;
            myArray=myDNS.split(".");
            if(myArray.length == 2)
            {
                window.location =  "http://www." + myArray[0] + p1;
            }
            else
            {
                window.location =  "http://www." + myArray[1] + p1;
            }
        }
</script>
<div style="text-align: center; margin:0px" >
    <div align="center" style="border:solid 0px #000000; text-align: left; margin-left: auto; margin-right: auto; width: 906px;">
        <!-- Start: Ads -->
        <div align="center">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <a href="javascript:navTo('.com/index.aspx');">
                            <img src="http://www.malzook.com/images/BHLogo.gif" border="0"alt=""/>&nbsp;&nbsp;&nbsp;</a></td>
                    <td>
                        <!-- #include file="../include/ads/LeaderAd.htm" -->
                    </td>
                </tr>
            </table>
        </div>
    </div>
<%--LOGIN MENU--%>    
    <div align="center" style="background-color:#cccccc">
        <div style="width:906px;" align="right" class="white12">
        <asp:linkbutton id="lnkSignIn" cssclass="sitemenu" runat="server">Sign in</asp:linkbutton>
        |
        <asp:linkbutton id="lnkSignUp" cssclass="sitemenu" runat="server">Sign up</asp:linkbutton>
        <%--|
        <a class="sitemenu" href="javascript:navTo('.com/help/HowWeWork.aspx');">how?
            </a>--%>
        
        </div>
    </div>

<%--COLOR SPACER--%>                                                     
    <div style="background-color:#999999; height:2px;"><img src="http://www.malzook.com/images/s1x1.gif" alt="spacer" /></div>

<%--BEGIN NAV MENU--%>
        <div style="border-bottom:solid 2px #999999; background-color:#999999;">
        <div style="background-color:#999999; width:996px; text-align: left;margin-left: auto; margin-right: auto;height:30px">
		<ul class="sf-menu">
			<li style="width:80px"> 
				<a class="menu" href="javascript:navTo('.com/index.aspx');">Home</a>
			</li>
			<li style="width:165px">
				<a class="menu">Used Boards</a>
				<ul style="display:none">
					<li>
					<a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1');">&nbsp;Surfboards ></a>
					    <ul style="display:none">
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=1');">&nbsp;Shortboard</a></li>
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=2');">&nbsp;Longboard</a></li>
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=4');">&nbsp;Fish/Retro</a></li>
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=8');">&nbsp;Fun Shape</a></li>
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=16');">&nbsp;Gun</a></li>
						<li style="border-bottom:solid 1px #999999"><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=256');">&nbsp;Vintage</a></li>						
						</ul>
					</li>
					<li>
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=2');">&nbsp;Snowboards</a>
					</li>
					<li>
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=3');">&nbsp;Other Boards</a>
					</li>
					<li style="border-bottom:solid 1px #999999">
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=4');">&nbsp;Accessories</a>
					</li>					
				</ul>
			</li>
			<li style="width:125px">
				<a class="menu" href="javascript:navTo('.com/qna/list.aspx?iCat=1');">Ask-a-Pro</a>
			</li>
			<li style="width:120px" class="menu">
				<a class="menu" href="javascript:navTo('.com/showcase/ShowcaseResults.aspx');">Showcase</a>
			</li>							
			<li style="width:70px">
				<a class="menu" href="javascript:navTo('.com/Blog/BlogResults.aspx');">Blog</a>
			</li>
		    <li style="width:140px">
		        <a class="menu" href="javascript:navTo('.com/Shaper/ShaperHouse.aspx');">ShaperHouse</a>
		                 <%--<asp:Substitution ID="ctlSubst" runat="server" MethodName="Global.TryMe" />--%>
					    <ul style="display:none">
						<li><a href="javascript:navTo('.com/Shaper/SurfboardShaper.aspx?q=233');">&nbsp;Shaper10</a></li>
						<li style="border-bottom:solid 1px #999999"><a href="javascript:navTo('.com/Shaper/ShaperHouse.aspx');">&nbsp;View All</a></li>
     					</ul>		        
		    </li>
			<li style="text-align:center; color:#ff9900;">
				<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=1');" class="hunt">
                    &nbsp;&nbsp;&nbsp;Hunt&nbsp;&nbsp;&nbsp;</a>
			</li>
			<li align="center" style="text-align:center;">
                <asp:linkbutton id="lnkPost" runat="server" class="sell">&nbsp;&nbsp;&nbsp;Sell&nbsp;&nbsp;&nbsp;</asp:linkbutton>				
			</li>
		</ul> 
		</div>
   
</div>

    </div>
    </form>
</body>
</html>
