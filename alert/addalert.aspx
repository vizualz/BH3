<%@ Page Language="C#" AutoEventWireup="true" Codebehind="addalert.aspx.cs" Inherits="BoardHunt.alert.addalert" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Boardhunt</title>
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />

    <script type="text/javascript">
      $(document).ready(function() {
	    jQuery(function(){
		    jQuery('ul.sf-menu').superfish();
	    });
      });
    </script>

</head>
<body class="dkgreen30">
    <div id="main" align="center">
        <form class="header" id="form1" runat="server">
                <!-- #include file="../include/Header.aspx" -->
				<asp:ScriptManager ID="ScriptManager1" runat="server">
				</asp:ScriptManager>
                
                <br />
                <div align="center">
                <span class="midorange26b">Alerts</span><br /></br>
                <div align="left" style="width: 700px; height:700px; margin-left:30px">
                When a &nbsp;<asp:DropDownList ID="cboBoardType" Width="200" runat="server" CssClass="dkrgrey30b">
                                                </asp:DropDownList>&nbsp; gets listed to Boardhunt



               <br/><br/>
                
				<span class="dkorange16">WHERE</span> the surfboard brand is&nbsp;
				<asp:TextBox ID="txtBrandName" runat="server" placeholder="i.e. Channel Islands"></asp:TextBox>
				<cc1:AutoCompleteExtender ServiceMethod="GetBrands"	
    				ServicePath="" 
				    MinimumPrefixLength="2"
				    CompletionInterval="0" EnableCaching="false" CompletionSetCount="10" 
				    TargetControlID="txtBrandName"
				    ID="autoCompleteExtender1" runat="server" FirstRowSelected = "false"
				    >
				</cc1:AutoCompleteExtender><br/><br/>
				<span class="dkorange16">OR</span>&nbsp;the Shaper is&nbsp;
				<asp:TextBox ID="txtShaperName" runat="server" placeholder="Al Merrick"></asp:TextBox>
				<cc1:AutoCompleteExtender ServiceMethod="GetShapers"	
    				ServicePath="" 
				    MinimumPrefixLength="1"
				    CompletionInterval="0" EnableCaching="false" CompletionSetCount="10" 
				    TargetControlID="txtShaperName"
				    ID="autoCompleteExtender2" runat="server" FirstRowSelected = "false" 
				    >
				</cc1:AutoCompleteExtender>
				<br/></br>
				<span class="dkorange16">AND</span> the height is around <asp:TextBox ID="txtHtFt" runat="server" placeholder="5"></asp:TextBox>'&nbsp;
				<asp:TextBox ID="txtHtIn" runat="server" placeholder="10"></asp:TextBox>"
				<br/><br/>
				<asp:Button runat="server" Text="Set Alert" id="btnSet"></asp:Button>

                </div>
                </div>
    <div id="push">
    </div>
    </form> 
    </div>
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>




