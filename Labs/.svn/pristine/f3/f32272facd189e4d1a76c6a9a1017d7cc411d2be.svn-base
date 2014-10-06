<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MenuTest.aspx.cs" Inherits="BoardHunt.Labs.MenuTest" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Menu Test</title>

    <script src="../include/js/m1-2b.js" type="text/javascript"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <script src="../include/js/dropdown.js" type="text/javascript"></script>
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>
    <link href="../style/dropdown.css" type="text/css" rel="stylesheet"/>    

</head>
<body>
    <form class="header" id="Form1" runat="server">
	<style type="text/css">
		body,html{
            margin:0 auto;	
			padding:0;
			font-family:Trebuchet MS, Helvetica, sans-serif;
            text-align:center;
		}
		
		#main{
            width: 100%;
			text-align:center;		
			/*height:500px;*/
/*			margin:5% auto; */
/*		    width:900px;*/
/*			position:relative;
			overflow:auto;
			color:#aaa;
			padding:20px;
			border:1px solid #888;
			background-color:#000;
*/			
		}
	</style>
	<script type="text/javascript">
		new UvumiDropdown('ddMenu');
	</script>

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

                        <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/DWLMZGY56BFVVKYQLNKA64/">
                        </script>

                    </td>
                </tr>
            </table>
        </div>
    </div>
<%--LOGIN MENU--%>    
    <div align="center" style="background-color:#F0F0F0">
        <div style="width:906px;" align="right" class="ltgrey10b">
        <asp:linkbutton id="lnkSignIn" cssclass="grey_orange10" runat="server"></asp:linkbutton>
        |
        <asp:linkbutton id="lnkSignUp" cssclass="grey_orange10" runat="server"></asp:linkbutton>
        |
        <a class="grey_orange10" href="javascript:navTo('.com/help/HowWeWork.aspx');">how
            this works</a>
        |
        <!-- AddThis Button BEGIN -->
        <script type="text/javascript">
        addthis_pub  = 'vizualz';
        addthis_logo            = 'http://www.addthis.com/images/yourlogo.png';
        addthis_logo_background = 'FF9900';
        addthis_logo_color      = '666699';
        addthis_brand           = 'Boardhunt.com';
        addthis_options         = 'stumbleupon, favorites, email, delicious, myspace, facebook, google, digg';
        </script>

        <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" onmouseout="addthis_close()" onclick="return addthis_sendto()">
            <%--<img src="http://s9.addthis.com/addthis16.gif" width="16" height="16" border="0" alt="" />--%>
            <span class="grey_orange10">&nbsp;share +</span>
        </a>
        <script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>              
        </div>
    </div>
    
  
    
    
    
<%--COLOR SPACER--%>                                                     
    <div style="background-color:#99CC33; height:2px;"><img src="http://www.malzook.com/images/s1x1.gif" alt="spacer" /></div>

<%--BEGIN NAV MENU--%>
        <div style="border-bottom:solid 2px #ff9900; background-color:#ffffff;">
        <div style="background-color:#ffffff; width:906px; text-align: left;margin-left: auto; margin-right: auto;">
		<ul id="ddMenu" class="dropdown">
			<li style="width:80px"> <%----%>
				<a class="menu" href="javascript:navTo('.com/index.aspx');">Home</a>
			</li>
			<li style="width:140px">
				<a class="menu">Used Boards</a>
				<ul style="display:none">
					<li>
						<a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=1');">&nbsp;Surfboards</a>
					</li>
					<li>
						<a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=2');">&nbsp;Snowboards</a>
					</li>
					<li>
						<a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=3');">&nbsp;Other Boards</a>
					</li>
				</ul>
			</li>
			<li style="width:140px">
				<a class="menu" href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=4');">Accessories</a>
			</li>
			<li style="width:140px">
				<a class="menu" href="javascript:navTo('.com/showcase_results.aspx');">Showcase</a>
			</li>							
			<li style="width:140px">
				<a class="menu" href="javascript:navTo('.com/Blog/BlogResults.aspx');">Board Blog</a>
			</li>
		    
			<li align="center" style="background-color:#ff9900">
				<a href="javascript:navTo('.com/index.aspx');" class="search"><span>
                    Search</span></a>
			</li>
			<li align="center" style="background-color:#99CC33">
                <asp:linkbutton id="lnkPost" runat="server" class="sell"><span>Sell</span></asp:linkbutton>				
			</li>
		</ul> 
		</div>
   
</div>
<br />
xtra stuff
    </form>
   
</body>
</html>
