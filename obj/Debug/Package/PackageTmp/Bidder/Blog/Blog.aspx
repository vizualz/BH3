<% @ Page CodeBehind="Blog.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="BoardHunt.Blog.Blog" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Create Blog - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

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
            <table cellspacing="5" width="150" border="0">
                <tr>
                    <td colspan="2" height="10">
                        <img src="../images/s1x1.gif" /></td>
                </tr>
            </table>
            <div align="center">
                <span class="midorange26b">
                    <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="../UserMenu.aspx" CssClass="orange_dkorange26">MENU</asp:HyperLink>
                    &gt; CREATE BLOG</span>
                <br /><br />
                </div>

                <table cellspacing="0" border="3" bgcolor="#FFFFCC" bordercolor="FF9900">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="dkgrey12b">&nbsp;Choose a category</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="cboCategory" Width="200px" runat="server" CssClass="dkgrey10b"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="Cancel" TabIndex="6" />
                                        &nbsp;
                                        <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Text="Next" TabIndex="7" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="push">
                </div>
        </form>
    </div>
    <div align="center">
        <!--#include file="../include/footer.aspx"-->
    </div>
</body>
</html>
