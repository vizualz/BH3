<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DudiersTest.aspx.cs" Inherits="BoardHunt.Labs.DudiersTest" %>
<%@ Register TagPrefix="bh" TagName="ShowVanity" Src="../include/Controls/VanityCtl.ascx" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
       
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
	<bh:Header id="header" runat="server" />
    <div align="center">
    <br /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br /><br />        
        <asp:TextBox ID="TextBox1" runat="server" Text="Text Box"></asp:TextBox>


    </div>

    <bh:ShowVanity id="vanity1" runat="server"/>
    </form>
</body>
</html>

