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
                        <!-- #include file="ads/LeaderAd.htm" -->
                    </td>
                </tr>
            </table>
        </div>
    </div>
<%--LOGIN MENU--%>    
    <div align="center" style="background-color:#cccccc">
        <div style="width:906px;" align="right" class="white12">
        <asp:linkbutton id="lnkSignIn" cssclass="sitemenu" runat="server"></asp:linkbutton>
        |
        <asp:linkbutton id="lnkSignUp" cssclass="sitemenu" runat="server"></asp:linkbutton>
        |
        <a class="sitemenu" href="javascript:navTo('.com/help/HowWeWork.aspx');">how?
            </a>
        
        <!-- AddThis Button BEGIN -->
        <script type="text/javascript">
        /*
        addthis_pub  = 'vizualz';
        addthis_logo            = 'http://www.addthis.com/images/yourlogo.png';
        addthis_logo_background = 'FF9900';
        addthis_logo_color      = '666699';
        addthis_brand           = 'Boardhunt.com';
        addthis_options         = 'stumbleupon, favorites, email, delicious, myspace, facebook, google, digg';
        */
//        var addthis_config ={   
//            services_compact = 'favorites, email, delicious'
//        }
        //addthis.button(addthis_config);
        </script>
        

<%--        <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" onmouseout="addthis_close()" onclick="return addthis_sendto()">
            
            <span class="grey_orange10">&nbsp;share +</span>
        </a>--%>
        <script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>  
        <!-- AddThis Button END -->          
        </div>
    </div>

<%--COLOR SPACER--%>                                                     
    <div style="background-color:#999999; height:2px;"><img src="http://www.malzook.com/images/s1x1.gif" alt="spacer" /></div>

<%--BEGIN NAV MENU--%>
        <div style="border-bottom:solid 2px #999999; background-color:#999999;">
        <div style="background-color:#999999; width:906px; text-align: left;margin-left: auto; margin-right: auto;">
		<ul id="ddMenu" class="dropdown">
			<li style="width:80px"> 
				<a class="menu" href="javascript:navTo('.com/index.aspx');">Home</a>
			</li>
			<li style="width:140px">
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
						<li><a href="javascript:navTo('.com/Surfboardsforsale.aspx?iCat=1&bt=256');">&nbsp;Vintage</a></li>						
						</ul>
					</li>
					<li>
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=2');">&nbsp;Snowboards</a>
					</li>
					<li>
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=3');">&nbsp;Other Boards</a>
					</li>
					<li>
						<a href="javascript:navTo('.com/Surfboardsforsale.aspx?loc=all&iCat=4');">&nbsp;Accessories</a>
					</li>					
				</ul>
			</li>
			<li style="width:110px">
				<a class="menu" href="javascript:navTo('.com/qna/list.aspx?iCat=1');">Ask-a-Pro</a>
			</li>
			<li style="width:120px" class="menu">
				<a class="menu" href="javascript:navTo('.com/showcase/ShowcaseResults.aspx');">Showcase</a>
			</li>							
			<li style="width:70px">
				<a class="menu" href="javascript:navTo('.com/Blog/BlogResults.aspx');">Blog</a>
			</li>
		    <li style="width:140px">
		        <a class="menu" href="javascript:navTo('.com/Shaper/ShaperHouseBeta.aspx');">ShaperHouse</a>
		                 <%--<asp:Substitution ID="ctlSubst" runat="server" MethodName="Global.TryMe" />--%>
					    <%--<ul style="display:none">
						<li><a href="javascript:navTo('.com/Shaper/SurfboardShaper.aspx?q=233');">&nbsp;Shaper10</a></li>
						<li><a href="javascript:navTo('.com/Shaper/ShaperHouse.aspx');">&nbsp;View All</a></li>
     					</ul>	--%>	        
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
<br />