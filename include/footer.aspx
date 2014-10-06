<%@ Register TagPrefix="bh" TagName="ShowVanity" Src="../include/Controls/VanityCtl.ascx" %>
<br />
<div id="footer" style="width:100%; height:100px; background-color:#333333">

<div align="center" style="width:1100px">

<div style="width:400px; margin-left:20px; float:left; margin-top:10px;" class="ltgrey10" align="left"><br />
    <table align="left" valign="center" style="cellspacing: 10px;">
        <tr>
            <td style="width:90px">
                <a class="white_white12" href="/about.aspx">about</a><br />
                <a class="white_white12" href="javascript:void(0);" onclick="popUpHelp('5');event.returnValue=false;return false;">privacy</a><br /> 
                <a class="white_white12" href="javascript:void(0);" onclick="popUpHelp('3');event.returnValue=false;return false;">terms</a>
            </td>
            <td style="width:90px">
                <a class="white_white12" href="/register_user.aspx">join</a><br />
                <a class="white_white12" href="/contact.aspx?iD=0">contact</a><br /> 
                <a class="white_white12" href="/contact.aspx?iD=4">advertise</a><br />            
            </td>
            <td style="width:90px">  
                <a class="white_white12" href="/Blog/BlogResults.aspx">blog</a><br /> 
                <a class="white_white12" href="/qna/list.aspx?iCat=1">ask-a-pro</a><br />
                <a class="white_white12" href="/qp/Coupons.aspx">dealz</a><br /> 
                
            </td>
            <td style="width:90px"> 
               <a class="white_white12" href="/surfboardsforsale.aspx">used boards</a><br /> 
               <a class="white_white12" href="/shaper/shaperhouse.aspx">shapers</a><br /> 
               <a class="white_white12" href="/matrix.aspx">matrix</a><br />   
           </td>
      </tr>


 
    </table>
        <bh:ShowVanity id="vanity1" runat="server"/>    
</div>

<div style="float:right; width:650px;" align="right">
<table align="right" style="width:650x; cellspacing: 0px">
    <tr>
        
    
  
    <td align="right"><span class="white12">support bh</span>
        
        </td>
        <td width="60%">
             
             <a href="javascript:void(window.open('http://www.twitter.com/boardhunt'))" ><img src="http://boardhunt.com/images/social/twitter_footer.gif" border="0" alt="twitter" /></a>
             <a href="javascript:void(window.open('http://www.facebook.com/boardhunt'))"><img src="http://boardhunt.com/images/social/fb_footer.gif" border="0" alt="facebook" /></a>
            <a href="javascript:void(window.open('http://www.stumbleupon.com/submit?url=http%3A//www.boardhunt.com&title=Used+Surfboards+For+Sale'))"><img src="http://boardhunt.com/images/social/stumbleupon_footer.gif" border="0" alt="stumbleupon" /></a>             
            <%--<a href="javascript:void(window.open('http://del.icio.us/post?url=http://www.malzook.com&title=Used+Surfboards+For+Sale'))" ><img src="http://boardhunt.com/images/social/delicious_footer.gif" border="0" alt="delicious" /></a>--%>
        </td>
        <td align="right" >
            <br /><iframe src="http://www.facebook.com/plugins/like.php?href=www.boardhunt.com&amp;layout=button_count&amp;show_faces=true&amp;width=80&amp;action=like&amp;colorscheme=light&amp;height=21" 
            scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:80px; height:25px;" allowTransparency="true"></iframe>
	        <%--<br /><g:plusone></g:plusone>--%> 
            <br /><span class="midgrey10">© 2012 Boardhunt LLC</span>
            <br /><asp:Label runat="server" ID="lblSold" CssClass="midgrey10"></asp:Label>
        </td>
   </tr>
</table>
</div>


</div>

</div>

