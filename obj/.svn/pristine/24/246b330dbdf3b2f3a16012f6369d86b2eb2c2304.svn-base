<%@ Page Language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" EnableEventValidation="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never" Inherits="BoardHunt.index" %>
<%@ Register TagPrefix="bh" TagName="lQuestions" Src="include/Controls/LQuestions.ascx" %>
<%@ Register TagPrefix="bh" TagName="lBlog" Src="include/Controls/LBlogs.ascx" %>
<%@ Register TagPrefix="bh" TagName="lComment" Src="include/Controls/LComment.ascx" %>
<%@ Register TagPrefix="bh" TagName="lboards" Src="include/Controls/LBoards.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Used Surfboards for Sale, Sell Surfboards | Boardhunt</title>
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt Surfboards For Sale" href="http://www.malzook.com/rss/surfboards.xml"/>
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="favicon.ico" />
    <meta http-equiv="Page-Enter" content="RevealTrans(Duration=0,Transition=0)" />
    <meta name="description" content="Boardhunt is a Surfboard Marketplace featuring new and used surfboards for sale, helpful blogs, a Q&A panel for surf advice, and product showcases." />
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="verify-v1" content="eWL9d2V/s6d8s6toO33avZ2ySyY72DQg3ZG16K/qM6w=" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <script type="text/javascript">
          $(document).ready(function() {
            jQuery(function(){
	            jQuery('ul.sf-menu').superfish();
            });
          });
    </script>    
    <script type="text/javascript" language="JavaScript">  
    function CheckForEnter(code)
    {
        if(code == 13)
        {
            __doPostBack('ImageButton1','');
        }
    }
    </script>
</head>
<body>
    <form class="header" id="Form1" runat="server">
        <div id="main" align="center">
 <!-- #include file="include/HeaderIdx.aspx" -->
            <div align="center">
                <table cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <!-- top half -->
                        <td bgcolor="#333333" style="height: 188px; width: 890px;">
                            <table style="width: 900px" align="center" cellpadding="0" cellspacing="0" bgcolor="#333333" border="0">
                                <tr>
                                    <td colspan="6" align="center" style="height: 10px">
                                        <img src="images/s1x1.gif" alt=""/></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" class="white30b" bgcolor="#333333" style="height: 26px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;A Surfboard Marketplace<span class="midorange18"><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Find. Sell. Share info on boards.</span></td>
                                    <td align="right" colspan="3" bgcolor="#333333">
                                        <asp:ImageButton ID="imgBtnSell" OnCommand="ImageButton_Click" CommandName="imgBtnSell"
                                            CommandArgument="1" onmouseover="this.src='images/sell.gif'" onmouseout="this.src='images/sell_off.gif'"
                                            runat="server" ToolTip="Start selling stuff" ImageUrl="images/sell_off.gif"></asp:ImageButton>                                       
                                        <asp:ImageButton ID="imgBtnShapers" OnCommand="ImageButton_Click" CommandName="imgBtnShapers" CommandArgument="2"
                                        onmouseover="this.src='images/shaperhouse_home.gif'" onmouseout="this.src='images/shaperhouse_homeoff.gif'"
                                            runat="server" ToolTip="Start selling stuff" ImageUrl="images/shaperhouse_homeoff.gif"></asp:ImageButton>&nbsp;&nbsp;&nbsp;                                      
                                        <br />    
                                        <asp:ImageButton ID="imgBtnSearch" OnCommand="ImageButton_Click" CommandName="imgBtnSearch"
                                            CommandArgument="0" onmouseover="this.src='images/hunt.gif'" onmouseout="this.src='images/hunt_off.gif'"
                                            runat="server" ToolTip="See all surfboards for sale." ImageUrl="images/hunt_off.gif"></asp:ImageButton><a
                                                href="http://www.malzook.com/#"></a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 10px">
                                        <img src="images/s1x1.gif" alt=""/></td>
                                </tr>
                                <tr> 
                                    <td colspan="6" align="center" bgcolor="#f0f0f0" style="height: 19px">
                                        <img src="images/used-surfboards.jpg" alt="used surfboards"/></td>
                                </tr>  
                                <tr>
                                    <td colspan="6" align="center" bgcolor="#000000" style="height: 4px">
                                        <img src="images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" bgcolor="#f0f0f0" style="height: 5px">
                                        <img src="images/s1x1.gif" alt=""/></td>
                                </tr>
                                <tr> 
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14" href="Surfboardsforsale.aspx?iCat=1&bt=1">Shortboards</a>
                                        </td>
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14" href="Surfboardsforsale.aspx?iCat=1&bt=2">Longboards</a>
                                        </td>
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14" href="Surfboardsforsale.aspx?iCat=1&bt=4">Fish/Retro</a>
                                        </td>  
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14"href="Surfboardsforsale.aspx?iCat=1&bt=8">Funshape/Egg</a>
                                        </td>
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14" href="Surfboardsforsale.aspx?iCat=1&bt=16">Big Wave Guns</a>
                                        </td> 
                                    <td align="center" class="dkgrey14b" bgcolor="F0F0F0" style="height: 19px; width: 148px;"><a class="dkrgrey_orange14" href="Surfboardsforsale.aspx?iCat=1&bt=256">Vintage</a>
                                    </td>          
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" bgcolor="#f0f0f0" style="height: 2px">
                                        <img src="images/s1x1.gif" alt=""/></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" bgcolor="#000000" style="height: 4px">
                                        <img src="images/s1x1.gif" alt="" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- end top half -->
                    <!--bottom half-->
                    <tr>
                        <td valign="top" style="width: 890px;background-color:#333333">
                            <table bgcolor="#333333" border="0" width="100%">
                                <tr>
                                    <td colspan="5" style="height: 20px;">
                                    <img src="images/s1x1.gif" alt="" /></td>
                                </tr> 
                                <tr>
                                    <td rowspan="2" style="width: 10px; height: 50px;">
                                    <img src="images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="white20b">
                                    <a href="/matrix.aspx" class="white_orange20u">What board should I ride?</a>
                                    <br />
                                    <a href="/matrix.aspx" class="orange_white12">Visit the Board Matrix</a>
                                    <br /><br />
                                        More Search Stuff
                                        <br />
                                        <a href="surfboardsforsale.aspx?iCat=2" class="orange_white12">Used Snowboards</a>
                                        <br />
                                        <a href="surfboardsforsale.aspx?iCat=3" class="orange_white12">Used Skateboards & Other</a>
                                        <br />
                                        <a href="surfboardsforsale.aspx?iCat=4" class="orange_white12">Used Accessories</a>
                                        <br />
                                        </td>
                                        
                                    <td align="center" valign="top" style="width: 259px">
                                        <bh:lBlog ID="ctlBlog" runat="server" />
                                    </td>
                                        <td align="center" valign="top" width="35%">
                                        <bh:lQuestions id="ctlQuest" runat="server" />
                                    </td>
                                    <td style="width: 10px;">
                                     <img src="images/s1x1.gif" alt="" /></td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="width: 679px">&nbsp;
                                        </td>
                                 </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- end master table -->
                <br />
                <div align="center" id="footer">
                    <!-- #include file="include/footer.aspx" -->
                </div>
                <a href="javascript:void(window.open('http://www.twitter.com/boardhunt'))" ><img src="images/badge_twit.png" border="0" alt="twitter" /></a>
                <a href="javascript:void(window.open('http://www.facebook.com/boardhunt'))"><img src="images/badge_fb.png" border="0" alt="facebook" /></a>
                <a href="javascript:void(window.open('http://www.stumbleupon.com/submit?url=http%3A//www.boardhunt.com&title=Used+Surfboards+For+Sale'))"><img src="images/badge_su.gif" border="0" alt="stumbleupon" /></a>
                <a href="javascript:void(window.open('http://del.icio.us/post?url=http://www.malzook.com&title=Used+Surfboards+For+Sale'))" ><img src="images/badge_delic.png" border="0" alt="delicious" /></a>

            </div>
        </div>
    </form>

    <script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script type="text/javascript">
var pageTracker = _gat._getTracker("UA-2548219-1");
pageTracker._initData();
pageTracker._trackPageview();
    </script>

</body>
</html>
