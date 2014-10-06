<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloseWindow.aspx.cs" Inherits="BoardHunt.Labs.CloseWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script type=text/javascript>
var newWin = null;
function openIt() {
  newWin = window.open('http://www.malzook.com/login.aspx');
}
function closeThis(){
  window.open('Close.aspx', '_self');
}
function doIt() {
  openIt();
  setTimeout("closeThis();",1000);
}
</script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlError" runat="server" Width="720px" Visible="true">
            <table cellpadding="2" cellspacing="0" border="2" bgcolor="#ffE4E1" bordercolor="#ff0000">
            <tr><td class="black12">
            &nbsp;Sheisse! ...Something went wrong.  Pls be sure your pics are under 2MB each.
                &nbsp;<br /> &nbsp;<a href="javascript:doIt()">Click here close this browser and try again.</a></td></tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
