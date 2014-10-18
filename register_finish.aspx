<%@ Page Language="c#" Codebehind="register_finish.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.register_finish" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Register Finish - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    <link href="style/dropdown.css" type="text/css" rel="stylesheet"/>
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
    });
    </script>
</head>
<body>
        <div id="main" align="center">
    <form runat="server">
            <!-- #include file="include/Header.aspx" -->
        <div>
            &nbsp;</div>
        <div align="center">
            <asp:Label ID="lblMessage" runat="server" CssClass="midorange16b" Width="427px"></asp:Label></div>
        <br />
        <div align="center">
            <a href="login.aspx" class="ltgreen_orange20"><u>Sign in</u> to get started!</a></div>

        <div align="center">
            <img height="15" src="images/s1x1.gif" /></div>
            <div id="push">
            </div>        
    </form>
        </div>
        <div align="center">
            <!-- #include file="include/footer.aspx" -->
        </div>
</body>
</html>
