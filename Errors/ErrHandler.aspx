<%@ Page Language="c#" Codebehind="ErrHandler.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Errors.ErrHandler" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Error - Boardhunt</title>
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/emenu.css" type="text/css" rel="stylesheet">

    <script type="text/javascript" src="../include/js/m1-2b.js"></script>

    <script type="text/javascript" src="../include/js/emenu.js"></script>

    <link href="../style/global.css" type="text/css" rel="stylesheet">

    <script language="JavaScript" src="../include/js/bh.js" type="text/javascript"></script>

    <script type="text/javascript">
        function navTo(p1)
        {
            myDNS=document.domain;
            myArray=myDNS.split(".");
            window.location =  "http://www." + myArray[1] + p1;
        }

        </script>

</head>
<body>
        <div id="main" align="center">
    <form runat="server">
            <asp:Panel ID="pnlHeader" runat="server">
                <!--#include file="../include/header.aspx"-->
            </asp:Panel>
            <table width="900" align="center" class="list">
                <tr>
                    <td>
                        <a href="../index.aspx">
                            <img src="http://www.malzook.com/images/BHLogo.gif" border="0"></a></td>
                </tr>
                <tr>
                    <td colspan="10">
                        <img height="3" src="http://www.malzook.com/images/colornavbar.gif" width="900"></td>
                </tr>
            </table>
            <br />
            <br />
            <div align="center">
                <div align="center" style="border: solid 1px #CCCCCC; width: 400px">
                    <asp:Label ID="lblMessage" runat="server" CssClass="red20b"></asp:Label>
                    <br />
                    <asp:Label ID="lblMessage2" runat="server" CssClass="midgrey12"></asp:Label>
                </div>
            </div>
            <br />
            <div align="center">
                <a href="../index.aspx">Back to home page</a></div>
            <div align="center">
                <img height="15" src="../images/s1x1.gif" /></div>
            <div id="push">
            </div>
    </form>
    </div>
    <div align="center">
        <!--#include file="../include/footer.aspx"-->
    </div>
</body>
</html>
