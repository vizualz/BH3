<% @ Page CodeBehind="showcase.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="BoardHunt.showcase.showcase" %>
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
    <form class="header" runat="server" id="Form1">
            <!-- #include file="../include/Header.aspx" -->
        <div align="center">
            <div align="center" class="midorange14b" style="width:500px">
                <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="../UserMenu.aspx" >MENU</asp:HyperLink>
                &gt; CREATE AD</div>
            <br>
            <br>
            <br>
            <table cellspacing="0" border="3" bgcolor="#FFCC66" bordercolor="FF9900">
                <tr>
                    <td>
                        <table>

                            <tr>
                                <td height="5">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="black14b">&nbsp;Choose a category</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cboCategory" Width="200px" runat="server" CssClass="controls"
                                        TabIndex="2">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            
<%--                            <tr>
                                <td>
                                    <span class="postdetails2">&nbsp;3. Choose a location</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cboRegion" Width="200px" runat="server" CssClass="controls"
                                        TabIndex="3">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <span class="postdetails2">&nbsp;4. Enter a city/region</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtTown" Width="200" runat="server" CssClass="controls" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            --%>
                            <tr>
                                <td height="5">
                                    <img src="../images/s1x1.gif" /></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:ImageButton ID="imgNext" runat="server" ImageUrl="../images/next.gif" TabIndex="5">
                                    </asp:ImageButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
            <div id="push">
            </div>        
    </form>
        </div>
    <div align="center">
        <!--#include file="../include/footer.aspx"-->
    </div>
</body>
</html>
