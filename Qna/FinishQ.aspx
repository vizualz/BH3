<%@ Page Language="c#" Codebehind="FinishQ.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Qna.FinishQ" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Question posted - Boardhunt</title>
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
    <form id="Form1" runat="server">
        <!-- #include file="../include/Header.aspx" -->
        <div>
            <br>
        </div>
        <div align="center">
            <div align="center" style="border-style: solid; border-width: thin; border-color: #ff9900;
                width: 610px">
                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff" width="610">
                    
                    <tr>
                        <td height="30" bgcolor="#FF9900" align="center" colspan="2">&nbsp;&nbsp;
                            <asp:Label ID="lblMessage" runat="server" CssClass="white20b" ForeColor="#FFFFFF"></asp:Label>&nbsp;&nbsp;</td>
					</tr>
					<tr>
                        <td height="1">
                            <img src="../images/s1x1.gif" />
                        </td>
                    </tr>
					<tr>		
						
          <td height="20" align="center" class="midgrey16b" colspan="2">&nbsp;&nbsp;What would you like to do 
            next?</td> 
					</tr>
					<tr>
                        <td height="5" colspan="2">
                                <img src="../images/nicawave.gif" /></td>
                   </tr>
					<tr>
						
						
          <td width="330px" align="right"><a class="orange_dkorange18" href="PostQ.aspx">ask another question</a></td>
                    
                   
                      <td width="270px" valign="bottom" align="left"><a class="ltgreen_green18" href="QManager.aspx">&nbsp;edit your question</a></td>
                    </tr>
					<tr>
                        <td height="5" colspan="2">
                                <img src="../images/s1x1.gif" /></td>
                   </tr>
                    <tr>
                       <td class="dkgrey12b" align="center" colspan="2" height="35">
                            &nbsp;See it live:&nbsp;         
						<asp:HyperLink ID="lnkPostItem" runat="server" CssClass="smgrlink" NavigateUrl="#"></asp:HyperLink></td>
						
					</tr>	
                    <tr>
                        <td height="25" colspan="2">
                                <img src="../images/s1x1.gif" /></td>
                   </tr>         
 
                 </table>   
                
            </div>
        </div>
         <div id="push">
            </div>     
    </form>
    </div>
<br />
<div align="center"><!-- #include file="../include/footer.aspx" --></div>
        <%--Google analytics--%>
        <script type="text/javascript" src="../include/js/googles.js"></script>
</body>
</html>
