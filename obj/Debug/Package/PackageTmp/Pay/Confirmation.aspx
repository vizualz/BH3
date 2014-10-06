<%@ Page Language="C#" AutoEventWireup="false" Codebehind="Confirmation.aspx.cs" Inherits="BoardHunt.Pay.Confirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
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
    <form id="form1" runat="server">

            <!-- #include file="../include/Header.aspx" -->
            <div align="center">
<div style="width:700px;margin-top:90px" align="left">
        <asp:label ID="lblThanks" runat="server" CssClass="ltgreen18b"></asp:label><br /><br />
        <asp:Label ID="lblDetails" runat="server" Width="300" CssClass="dkrgrey12" Visible="false"></asp:Label>
        <br /><br /><br />
        <asp:HyperLink ID="hypRedir" runat="server" CssClass="orange_orange14u"></asp:HyperLink>
        <br /><br />
        <asp:HyperLink ID="hypRedir2" runat="server" CssClass="orange_orange14u"></asp:HyperLink>        
<br />
</div>
</div>
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
