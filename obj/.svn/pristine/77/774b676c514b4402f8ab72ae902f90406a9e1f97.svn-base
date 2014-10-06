<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="BoardHunt.Admin.Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<title>BoardHunt  ...Your search starts here</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
        <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
        <script type="text/javascript" src="../include/js/superfish.js"></script>
        <script src="../include/js/bh.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
		<meta name="ROBOTS" content="NOINDEX, NOFOLLOW"/>
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
	    <form id="Form1" method="post" runat="server">
            <!-- #include file="../include/Header.aspx" -->
			<div class="dkgrey18v" align="center">
			  <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="Admin.aspx" CssClass="grey_grey22">ADMIN</asp:HyperLink>
			> REPORTS
				<asp:label id="lblCount" Runat="server"></asp:label>
			</div>
			<br />
			<div class="cathead" align="center"><asp:label class="dir" id="lblNoResult" runat="server"></asp:label></div>
			
			<div align="center">
			<table border="1" cellpadding="1" cellspacing="1">
			<asp:datalist id="dlEntryList" runat="server" EnableViewState="false" OnItemCommand="View_ItemDetail" >
					<HeaderTemplate>
						
							<tr>
							<td class="midgrey16b">iD</td>
							<td class="midgrey16b">Date</td>
							<td width="80" class="midgrey16b">Keyword</td>
							<td width="80" class="midgrey16b">Page</td>
							<tr>
								<td colspan="4" bgcolor="#ff9933"><img src="../images/s1x1.gif"></td>
							</tr>						
					</HeaderTemplate>
					<ItemTemplate>
						
								<tr bgcolor="#E6E6E6">
								    <td class="dkgrey10"><%# DataBinder.Eval(Container.DataItem, "iD") %>&nbsp;</td>
								    <td width="50" class="dkgrey10"><%# DataBinder.Eval(Container.DataItem, "dAdded", "{0: MM/dd}")%>&nbsp;</td>	
								    <td class="dkgrey10"><%# DataBinder.Eval(Container.DataItem, "word") %>&nbsp;</td>		
 	
								    <td class="dkgrey10"><%# DataBinder.Eval(Container.DataItem, "page") %>&nbsp;</td>
                                </tr>
							    <tr><td><img src="../images/s1x1.gif" /></td></tr>
					</ItemTemplate>
					<HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
				</asp:datalist>
				</table>
				</div>
			<div align="center">
				<table border="0">
					<tr>
						<td height="20"><img src="../images/s1x1.gif"></td>
					</tr>
					<tr><td>&nbsp;</td></tr>
					<tr>
						<td><asp:imagebutton id="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
								runat="server" ImageUrl="../images/backpage.gif"></asp:imagebutton>&nbsp;
							<asp:label id="lblCurrentPage" CssClass="midgrey10b"  runat="server"></asp:label>&nbsp;
							<asp:imagebutton id="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
								runat="server" ImageUrl="../images/nextpage.gif"></asp:imagebutton></td>
					</tr>
				</table>
			</div>
					<div align="center"><asp:label id="lblMessage" runat="server" CssClass="header"></asp:label></div>
    <div id="push">
    </div>
		</form>
					</div>
		<br />
		<div align="center"><!-- #include file="../include/footer.aspx" --></div>
	</body>
</html>
