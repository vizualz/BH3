<%@ Page Codebehind="PreviewQ.aspx.cs" Language="c#" AutoEventWireup="False" Inherits="BoardHunt.Qna.PreviewQ" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Preview Question - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />    
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
        <div align="center">
        <div align="center" class="midorange14b" style="width:300px;height:40px">
            <span class="midorange14b">LAST STEP: PREVIEW</span>
            </div>
            <br />
            <!-- Master Table -->
                <asp:Panel ID="pnlError" runat="server" Width="800px" Visible="false">
                <table cellpadding="0" cellspacing="0" border="1" bgcolor="#ffe4e1" bordercolor="#ff0000">
                <tr><td class="black12">&nbsp;
                Arg! Sorry about that.  We're fixing this issue.<br />
                &nbsp;<a href="../login.aspx" class="red_black12">Click here to close this browser and try again.</a>. 
                </td></tr>
                </table>
                
                </asp:Panel>            
            
            <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" BorderWidth="1px"
                BorderColor="#ff9900" BorderStyle="solid" Width="600px">

                <table cellspacing="0" cellpadding="0" border="0" align="center" bgcolor="#ffffff">
                    <tr>
                        <td height="2" colspan="2" bgcolor="#ff9900">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="white16b" bgcolor="#ff9900" align="center" height="20">
                            &nbsp;Click &quot;Edit&quot; for changes or &quot;Done&quot; to approve.&nbsp;</td>
                    </tr>
                    <tr>
                        <td bgcolor="#ff9900" height="2" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>
                            <!-- left side -->
                            <table cellspacing="5">
                                <tr>
                                    <td><img src="../images/qna.jpg" /></td>
                                </tr>
                            </table>
                        </td>
                        <!-- end left side -->
                        
                        
                        <!-- begin right side -->
                        <td> 
                            <table cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
                                
<%--                                <tr>
                                    <td height="20px" width="35%" class="big_md_grnb" align="left">
                                        Category:&nbsp;</td>
                                    <td class="big_md_grn" align="left" width="65%">
                                        <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                                    <td bgcolor="#ffffff">&nbsp;
                                        </td>
                                </tr> --%>                               
                                
                                <tr>
                                    <td align="left" width="65%" colspan="3" bgcolor="defe99">
                                        <asp:Label ID="lblQuestion" CssClass="midgreen24b" runat="server"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td class="ltgrey10b" align="left" colspan="3">
                                        <asp:Label ID="lblDetailsData" runat="server" Width="390px"></asp:Label></td>
                                </tr>
                                
                    <tr>
                           <td bgcolor="#ffffff" height="5px" colspan="3">
                          &nbsp;</td>
                    </tr>

                    <tr>
                        <td height="20px" colspan="3" valign="top" class="ltgrey10b" align="left">
                            Posted on:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label>&nbsp;
                            by&nbsp;<asp:LinkButton ID="lnkEmailData" runat="server" CssClass="ltgreen_green10" Enabled="false"></asp:LinkButton>
                            </td>

                     </tr>
                     <tr>
                        <td style="height:5px" colspan="3">&nbsp;</td>
                     </tr>
                     <tr>
                        <td style="height:5px" colspan="3" class="midgrey14">Tags:</td>
                     </tr>                     
                    <tr>
                        <td height="20px" colspan="3" valign="top" class="ltgreen14b" align="left">
                            <asp:Label ID="lblTags" runat="server"></asp:Label>&nbsp;
                            
                            </td>
 
                     </tr>                        
                    
                </table>
<%--                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff">
                    <tr>
                        <td height="20px" class="sm_dk_grn" align="left">
                            &nbsp;&nbsp;Posted By:&nbsp;</td>
                        <td class="email" align="left" width="150px" colspan="2">
                            </td>
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

                </td> 
                </tr>
                <tr>
                    <td style="height:5px" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="header" colspan="2">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                </tr>
                </table>
            </asp:Panel>
            <br />
            <div align="center" style="width:300px">
                                    <asp:ImageButton ID="imgGoBack" runat="server" ImageUrl="../images/edit.gif" ToolTip="Go back and edit" OnClick="imgGoBack_Click2">
                        </asp:ImageButton>
                        &nbsp;
                         <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="../images/done.gif">
                        </asp:ImageButton>
            </div>
            <asp:HiddenField ID="hdnProcPics" runat="server" />
            <asp:HiddenField ID="hdnUserDir" runat="server" />
        </div>
         <div id="push">
            </div>          
    </form>
    </div>
<br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
        <%--Google analytics--%>
        <script type="text/javascript" src="../include/js/googles.js"></script>       
</body>
</html>
