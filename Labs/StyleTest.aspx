<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StyleTest.aspx.cs" Inherits="BoardHunt.Labs.StyleTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <script type="text/javascript" src="../include/js/m1-2b.js"></script>
        <script type="text/javascript" src="../include/js/dropdown.js"></script>	
    <style type="text/css">
/* ===== TYPOGRAPHY ===== */
/*Paragraphs, headings, and other miscellaneous font styles such as small and strong tags.*/

a.menu{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#999966;}
a.menu:hover{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#000000;}

a.sell{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#669900;}
a.sell:hover{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#000000;}

a.search{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#ffCC00;}
a.search:hover{font-family: Trebuchet; font-size: 18px; font-weight:bold;  color:#000000;}


/* this is the main UL element*/
.dropdown{
	visibility:hidden;
	margin:0;
	padding:0;
	list-style:none;
	/*border:solid 1px black*/
}

/* these are the inner menus*/
.dropdown ul{
	margin:0;
	padding:0;
	border:2px solid #ff9900;
	border-top:2px solid #ffffff;
	list-style:none;
}

/* these are all the LIs in the menu*/
.dropdown li{
	margin:0;
	padding:0px;
	width:110px;
	background-color:#FFFFFF;
	cursor:pointer;
	display:inline;
}

.dropdown li:hover{
	text-decoration:none;
	color:#CC0033
	
	/* background: #fff */
}

/* these are anchor in the menu, if you want to style them differently from the rest of you website*/
.dropdown a{
	text-decoration:none;
	color:#999999;
	font-weight:bold
}

.dropdown a:hover{
	/*text-decoration:none;
	color:#CC0033
	*/
	/* background: #fff */
}

.dropdown a:hover.special{
	text-decoration:none;
}

/* these are the LIs that only belong to submenu*/
.dropdown ul li
{
    background-color:#ffffff;
	border:0px solid #444;
	border-top:0;
	margin-left:0px;
}

/* these are the LIs that contains a submenu*/
.dropdown li.submenu{
	background-image:url('expand_down.gif');
	background-position:center left;
	background-repeat:no-repeat;
	padding-left:0px;
	width:110px;
}

/* these are the LIs that contains a submenu and which are in a sub-menu themselve*/
.dropdown ul li.submenu{
	background-image:url('expand_right.gif');
	background-position:center right;
	padding:2px;
	width:120px;
}    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
			<li style="width:80px"> 
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
					<li>
						<a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=4');">&nbsp;Accessories</a>
					</li>					
				</ul>
			</li>
			<li style="width:140px">
				<a class="menu" href="javascript:navTo('.com/qna/list.aspx?iCat=1');">Ask-a-Pro</a>
			</li>
			<li style="width:140px" class="menu">
				<a class="menu" href="javascript:navTo('.com/showcase/ShowcaseResults.aspx');">Showcase</a>
			</li>							
			<li style="width:140px">
				<a class="menu" href="javascript:navTo('.com/Blog/BlogResults.aspx');">Blog</a>
			</li>
		    
			<li style="background-color:#ff9900; text-align:center">
				<a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=1');" class="search">
                    Hunt</a>
			</li>
			<li align="center" style="background-color:#99CC33;text-align:center">
                <asp:linkbutton id="lnkPost" runat="server" class="sell">Sell</asp:linkbutton>				
			</li>
		</ul> 
		</div>
   
</div>
<br />    
    </div>
    </form>
</body>
</html>
