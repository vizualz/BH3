<%@ Page Codebehind="BlogPreview.aspx.cs" Language="c#" AutoEventWireup="false"
    Inherits="BoardHunt.Blog.BlogPreview" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Used surfboards snowboards skateboards wakeboards classifieds...Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <script type="text/javascript">
    $(document).ready(function() {
    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    });
    </script>
</head>
<body>
        <div id="main" align="center">
    <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
<div align="center" class="midorange14b" style="width:500px;height:40px">
                LAST STEP: APPROVE BLOG</div>
            <!-- Master Table -->
                <asp:Panel ID="pnlError" runat="server" width="500px" Visible="false">
                <table cellpadding="0" cellspacing="0" bgcolor="red"  style=" border: solid 1px #990000">
                <tr><td class="postinfo">
                <b>Error Posting:</b>  Sorry bout that.  We're experience some hiccups in our system and working on the problem.  Please re-log in by clicking <a href="../login.aspx">HERE</a> and try again. 
                </td></tr>
                </table>
                <br />
                </asp:Panel>            
            
            <asp:Panel ID="pnlDetails" runat="server" align="center" BorderWidth="4px" Width="600px"
                BorderColor="#999966" BorderStyle="solid" CssClass="black12b">

                <table cellspacing="0" cellpadding="0" border="0" align="center" bgcolor="#ffffff">
                    <tr>
                        <td height="2" colspan="2" bgcolor="#ff9900">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td bgcolor="#ff9900" height="2" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>
                            <!-- left side -->
                            <table>
                                <tr>
                                    <td align="right">
                                        &nbsp;<asp:Image ID="Pic1" runat="server" Height="300" Width="300"></asp:Image>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Image ID="Pic2" runat="server" Visible="false"></asp:Image>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap>
                                        <asp:Image Visible="false" ID="Pic1ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                            Height="1" Width="1" />
                                        <asp:Image Visible="false" ID="Pic2ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                            Height="1" Width="1" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <!-- end left side -->
                        
                        
                        <!-- begin right side -->
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="ffffff">
                                <tr>
                                    <td bgcolor="#ffffff" height="2" colspan="3" style="width: 110px">
                                        <img src="../images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" bgcolor="#ffffff" height="30" class="medorange" align="left" valign="bottom" style="width: 110px">
                                        THE BLOG</td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="#cccc99">
                                <tr>
                                    <td height="10" colspan="2">
                                        <img src="../images/s1x1.gif"></td>
                                    <td bgcolor="#ffffff">&nbsp;
                                        </td>
                                </tr>
<%--                                
                                <tr>
                                    <td height="12" class="postdetails3" align="left" width="45%">
                                        &nbsp;&nbsp;Location:&nbsp;</td>
                                    <td class="smwhite" align="left" width="55%">
                                        <asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                    <td bgcolor="#ffffff">&nbsp;
                                        </td>
                                </tr>--%>
                               <asp:Panel runat="server" ID="pnlAdTitle" Visible="true">     
                                    <tr>
                                        <td height="12px" class="postdetails3" align="left">
                                            <asp:Label ID="lblAdTitle" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td class="smwhite" align="left">
                                            <asp:Label ID="lblAdTitleData" runat="server"></asp:Label>
                                            </td>
                                            <td bgcolor="#ffffff">&nbsp;
                                                
                                            </td>
                                        </tr>
                                </asp:Panel>                                
<%--                               <asp:Panel runat="server" ID="pnlGearItem">     
                                    <tr>
                                        <td height="12px" class="postdetails3" align="left">
                                            <asp:Label ID="lblGearItem" runat="server" Visible="false">&nbsp;&nbsp;Gear item:&nbsp;</asp:Label>
                                        </td>
                                        <td class="smwhite" align="left">
                                            <asp:Label ID="lblGearItemData" runat="server"></asp:Label>
                                            </td>
                                            <td bgcolor="#ffffff">&nbsp;
                                                
                                            </td>
                                        </tr>
                                </asp:Panel>--%>
<%--                                <tr>
                                    <td class="postdetails3" align="left" style="height: 18px">
                                        &nbsp;&nbsp;<asp:Label ID="lblBrand" runat="server">Shaper:&nbsp;</asp:Label></td>
                                    <td class="smwhite" align="left" style="height: 18px">
                                        <asp:Label ID="lblBrandData" runat="server"></asp:Label></td>
                                    <td bgcolor="#ffffff" style="height: 18px">&nbsp;
                                        </td>
                                </tr>--%>
<%--                                <asp:Panel runat="server" ID="pnlBoardType">
                                    <tr>
                                        <td height="12px" class="postdetails3" align="left" width="45%">
                                            &nbsp;&nbsp;<asp:Label ID="lblBoardType" runat="server">&nbsp;&nbsp;Board type:&nbsp;</asp:Label></td>
                                        <td class="smwhite" align="left" width="55%">
                                            <asp:Label ID="lblBoardTypeData" runat="server"></asp:Label></td>
                                        <td bgcolor="#ffffff">&nbsp;
                                            </td>
                                    </tr>
                                </asp:Panel>--%>

                                
<%--                                <asp:Panel ID="pnlGenDims" runat="server" Visible="false">
                                    <tr>
                                        <td height="12px" class="postdetails3" align="left">
                                            &nbsp;&nbsp;Dimensions:&nbsp;</td>
                                        <td class="smwhite" align="left">
                                            <asp:Label ID="lblGenDims" runat="server"></asp:Label></td>
                                        <td bgcolor="#ffffff">&nbsp;
                                            </td>
                                    </tr>
                                </asp:Panel>--%>
                                
<%--                                <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                                <tr>
                                        <td height="12px" class="postdetails3" align="left">
                                            &nbsp;&nbsp;Web:&nbsp;</td>
                                        <td class="smwhite" align="left">
                                            <asp:Label ID="lblWeb" runat="server"></asp:Label></td>
                                        <td bgcolor="#ffffff">
                                            &nbsp;</td>
                                </tr>
                                </asp:Panel>    --%>                            
                                <tr>
                                    <td class="postdetails3" align="left" colspan="2" width="210px" style="height: 18px">
                                        &nbsp;&nbsp;Blog:&nbsp;</td>
                                    <td bgcolor="#ffffff" style="height: 18px">&nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td class="smwhite" align="left" colspan="2">
                                        &nbsp;&nbsp;<asp:Label ID="lblDetailsData" runat="server" Width="190px"></asp:Label></td>
                                    <td bgcolor="#ffffff">&nbsp;
                                        </td>
                                </tr>
                                
<%--                    <tr>            
                            <td height="30px" colspan="2" class="price" align="center" valign="bottom">
                                Price:&nbsp;<asp:Label ID="lblPriceData" runat="server"></asp:Label></td>
                        	<td bgcolor="#ffffff">&nbsp;
                            	</td>
                    </tr>--%>        
                    
					
                    <tr>
                        <td height="20px" colspan="2" valign="top" class="sm_dk_grn" align="center">
                            posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label></td>
                        <td bgcolor="#ffffff">
                         </td>   
                     </tr>   
                    
                </table>
             <%--   <table cellpadding="0" cellspacing="0" border="0" bgcolor="ffffff">
                    <tr>
                        <td colspan="3" bgcolor="#ffffff" height="30" class="medorange" align="left" valign="bottom">
                            CONTACT
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#cccc99">
                    <tr>
                        <td colspan="3" height="5">
                            <img src="../images/s1x1.gif"></td>
                        <td bgcolor="#ffffff">&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td height="12px" class="postdetails3" align="left" width="60px">
                            &nbsp;&nbsp;E-mail:&nbsp;</td>
                        <td class="email" align="left" width="150px" colspan="2">
                            <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="email"></asp:LinkButton></td>
                        <td bgcolor="#ffffff">&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td height="12px" class="postdetails3" align="left" nowrap>
                            &nbsp;&nbsp;Phone:&nbsp;</td>
                        <td class="smwhite" align="left" colspan="2">
                            <asp:Label ID="lblPhoneData" runat="server"></asp:Label></td>
                        <td bgcolor="#ffffff">&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="5">
                            <img src="../images/s1x1.gif">
                        </td>
                        <td bgcolor="#ffffff">&nbsp;
                            </td>
                    </tr>
                </table>--%>
                <!-- problem ? -->
                </td> 
                </tr>
                <tr>
                    <td>
                        &nbsp;
                                    <asp:Button ID="btnBack" runat="server" CssClass="btnStepBack" Text="< Edit" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Text="Done >" />
                        </td>
                </tr>
                <tr>
                    <td height="5">
                        <img src="../images/s1x1.gif"></td>
                </tr>
                <tr>
                    <td class="header" colspan="2">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="hdnProcPics" runat="server" />
            <asp:HiddenField ID="hdnUserDir" runat="server" />

            <div id="push">
            </div>        
    </form>
        </div>
        <br />
    <div align="center">
        <!--#include file="../include/footer.aspx"-->
    </div>
</body>
</html>
