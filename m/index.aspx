<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BoardHunt.m.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boardhunt - mobile surfboard web site</title>
    <link href="../style/mob_global.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../include/js/googles.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" style="margin-top:100px">
    <img src="/images/BHLogo.gif" alt="logo" width="250"/>
    <br /><br /><br /><br />
    <asp:Button ID="btnHunt" runat="server" Text="Hunt Boards" CssClass="btnMob" 
            style="width: 330px;height: 100px" onclick="btnHunt_Click"></asp:Button><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Full Site" CssClass="btnMob" 
            style="width: 330px;height: 100px" onclick="Button1_Click"></asp:Button>
            <br />
    <div style="height:200px">&nbsp;</div>
    <span class="midgrey20">(c) 2012 Boardhunt LLC </span>

    </div>
    <br /><br /><br />
    <asp:Literal runat="server" ID="ltrAds"></asp:Literal>
    </form>

</body>
</html>
