<%@ Page Language="c#" Codebehind="post_finish.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.post_finish" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Post Finish - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
    });

    $.ajax({
        url: '/wsBH/BHService.asmx/CreateRSS',
        success: function (data) {
        }
    }); 

    });
    </script>

</head>
<body>
    <div id="main" align="center">
        <form id="Form1" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <div align="center" style="width: 800px; margin: 0px auto;">
                <div align="center" style="border-style: solid; border-width: 0px; border-color: #FF9900;
                    width: 620px; margin: 0px auto;">
                    <br />
                    
                    <div style="width: 650px; background-color: #FFFFFF">
                        <asp:Panel ID="pnlBoost" runat="server" Width="700px" Height="250">
                            <div align="left" style="float: left; background-color: #FFFFFF; width: 630px; margin-top: 50px; margin-bottom: 20px; margin-left:0px"
                                class="dkrgrey30b">
                                <asp:Image runat="server" ID="imgCheckDone" ImageUrl="images/greencheck.gif" />
                                You<span class="dkrgrey30b">&#39;re all set. </span><br />
                            </div>    
                                <br />
                            
                            <div align="left" style="float: left; background-color: #FFFFFF; width: 600px; margin-top: 0px; margin-left: 0px;"
                                class="dkrgrey30b"><br /><br />
                                
                                <table>
                                   <tr>
                                       <td> 
                                            
                                            <asp:ImageButton ID="btnUpgradePro" runat="server" ImageUrl="images/ProUpgradeImage.gif"
                                             OnClick="btnUpgradePro_Click" />
                                       </td>
                                       <td>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/BoostImage.gif" OnClick="btnUpgrade_Click" />
                                            <%--<asp:LinkButton ID="lnkBoost" class="ltgreen_green26" runat="server" Text="Boost it now!" OnClick="lnkBoost_Click"/>--%>
                                            
                                        </td>                                                                           
                                    </tr>
                                </table>
                            </div>
                            
                            
                            <div align="left" style="float: left; width: 200px; background-color: #FFFFFF; margin-top: 0px; margin-left: 0px;" class="dkrgrey30b">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#FFFFFF"></asp:Label>
                        <div><br />
                            Get more...<br /><br />
                            <asp:LinkButton ID="lnkFBShare" runat="server"><img src="images/fb_share.jpg" border="0" alt="Post to your Facebook" align="top" /></asp:LinkButton>
                            <br /><br /><span class="dkorange12">Link:</span><asp:TextBox align="left" ID="txtEntryLink" CssClass="dkorange10b" OnClick="select()"
                                    runat="server" Width="270px"></asp:TextBox>
                            <br /><br />
                            
                             </div>
                        
                    </div><br />
                        </asp:Panel>
                        <br /><br />
                        <div style="float: left; background-color: #FFFFFF; width: 700px; height: 50px">
                            <div align="left" style="float: left; background-color: #FFFFFF; width: 700px; margin-left: 0px;">
                               <div style="float: left"><br />
                                    <span class="dkrgrey30b">More Options:</span><br />
                                    <asp:HyperLink CssClass="red_orange12u" ID="hypLnkPost" runat="server" class="midgrey_dkgrey18"
                                    NavigateUrl="post.aspx">Post Another</asp:HyperLink>
                                    <!-- another post -->
                                    <asp:HyperLink CssClass="red_orange12u" ID="hypLnkPostModel" runat="server" class="midgrey_dkgrey18"
                                    NavigateUrl="post_item.aspx?q=4">Post Another Model</asp:HyperLink>                                
                                    
                                    <asp:HyperLink ID="lnkPostItem" runat="server" CssClass="white_white12" NavigateUrl="#"></asp:HyperLink>
                                <br />
                                    <asp:HyperLink ID="lnkLivePost" runat="server" CssClass="red_orange12u">See your post</asp:HyperLink>
                                <%--<a href="Surfboardsforsale.aspx" class=""></a>--%>
                                   
                                    
                               <div style="float: right; width: 1px;">
                                    
                                    <br />
                               </div>
                            </div>
                            <div align="left" style="float: left; width:650px;">
                                <br />
                                  <span class="dkorange14b">IMPORTANT!</span>
                                  <span class="dkrgrey14">In User Menu, you can mark it <span class="dkorange14b">"SOLD"</span> after you sell it, or <span class="dkorange14b">lower price</span> if it's not selling.</span><br />
                                  
                                    </span><br />
                                  
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;
                </div>
            </div>
            <asp:HiddenField ID="hdnEntryVal" runat="server" />
            </div>
            <div id="push">
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
         <script type='text/javascript'>

              var _ues = {
                  host: 'boardhunt.userecho.com',
                  forum: '6121',
                  lang: 'en',
                  tab_corner_radius: 10,
                  tab_font_size: 20,
                  tab_image_hash: 'RmVlZGJhY2s%3D',
                  tab_alignment: 'left',
                  tab_text_color: '#FFFFFF',
                  tab_bg_color: '#FF9900',
                  tab_hover_color: '#ff6600'
              };

              (function () {
                  var _ue = document.createElement('script'); _ue.type = 'text/javascript'; _ue.async = true;
                  _ue.src = ('https:' == document.location.protocol ? 'https://s3.amazonaws.com/' : 'http://') + 'cdn.userecho.com/js/widget-1.4.gz.js';
                  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(_ue, s);
              })();

       </script>
</body>
</html>
