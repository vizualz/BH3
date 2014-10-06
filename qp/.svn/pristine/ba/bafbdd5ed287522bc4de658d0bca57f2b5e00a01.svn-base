<%@ Page Codebehind="Preview.aspx.cs" Language="c#" AutoEventWireup="False" Inherits="BoardHunt.qp.Preview" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Preview Post - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>
    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>    
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
      <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('a.Tips').cluetip({splitTitle: '|', clickThrough: true});        
        
    });
    </script>

    <script type="text/javascript">
    var newWin = null;
    function openIt() {
      newWin = window.open('http://www.malzook.com/login.aspx');
    }
    function closeThis(){
      window.open('Close.htm', '_self');
    }
    function doIt() {
      openIt();
      setTimeout("closeThis();",1000);
    }
    </script>

</head>
<body>
    <div id="main" align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <br />
            <div align="center">
                <div align="center" class="white20b" style="height:35px; padding:5px; width:450px; background-color:#CCCCCC">
                <span class="dkrgrey20b">Step 2</span> of 3:&nbsp;Review coupon and buy.              
                </div>
               
                <br />
                <!-- Master Table -->
                <asp:Panel ID="pnlError" runat="server" Width="720px" Visible="false">
                    <table cellpadding="2" cellspacing="0" border="2" bgcolor="#ffE4E1" bordercolor="#ff0000">
                        <tr>
                            <td class="black12b">
                                &nbsp;Arg! Something happened. The geek team is working on a fix. &nbsp;<br />
                                &nbsp;<a href="javascript:doIt()" class="red_black12">Click here to close this browser
                                    and try again.</a></td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <div style="width: 450px" align="left">
                    
                </div>
                <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" Style="width: 450px;height: 210px"
                    BorderWidth="2px" BorderColor="#000000" BorderStyle="Dashed">
                    <div align="center" style="width:448px">
                    <div style="margin-top:10px"> 
                        <asp:Label ID="lblTitle" runat="server" Width="400px" CssClass="dkorange26b"></asp:Label><br />
                    </div>
                        <div style="float: left;border: solid 0px black; width: 110px; margin-top:20px">
                            <asp:Image ID="Pic1" runat="server" Height="75" Width="75"></asp:Image><br />
                        </div>
                        <div style=" float: right; border: solid 0px black; width:300px; margin-top:20px; margin-right:20px" align="left">
                            <asp:Label ID="lblDetailsData" CssClass="dkrgrey20b" runat="server" Width="300px"></asp:Label><br />
                            <br />
                            <asp:Label ID="lblDateData" CssClass="dkgrey14b" runat="server"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <br />
                <div style="border:solid 0px black; height:50px; width:375px; padding-top:10px">
                    <asp:Button ID="btnEdit" runat="server" Width="75" Height="30px" CssClass="btnStepBack" Text="Edit" Visible="false" />&nbsp;
                    <asp:Button ID="btnSave" runat="server" Width="150" Height="30px" CssClass="btnStep" Text="Save For Later" Visible="false" />&nbsp;
                    <asp:Button ID="btnBuy" runat="server" Width="75" Height="30px" CssClass="btnGo" Text="Buy" Visible="false" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkInfo" runat="server" CssClass="Tips" style="border:solid 0px blue; color:Black; text-align:center;height:15px; line-height:15px">[ i ]</asp:LinkButton> 
                                       
                </div>
                <br />
                <asp:Label ID="lblStatus" runat="server" CssClass="errorLabel" Visible="false"></asp:Label>
                <br />                
                <asp:HiddenField ID="hdnProcPics" runat="server" />
                <asp:HiddenField ID="hdnUserDir" runat="server" />
                <asp:HiddenField ID="hdnAdType" runat="server" />
                <br /><br />
            </div>
            <div id="push">
            </div>
        </form>
    </div>
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
