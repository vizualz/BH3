<%@Page CodeBehind="PostQ.aspx.cs" Language="c#" AutoEventWireup="False" Inherits="BoardHunt.Qna.PostQ" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Ask a Question - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />    
    <script type="text/javascript">
    $(document).ready(function() {
    
    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('a.Tips').cluetip({splitTitle: '|'});        
    });
    </script> 

</head>
<body>
        <div id="main" align="center">
    <form class="header" runat="server" id="Form1">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center">
                <table cellspacing="5" width="150" border="0">
                    <tr>
                        <td colspan="2" height="10">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                </table>
            </div>
            <div align="center">
                <span class="midorange14b">
                    <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="../UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>
                    <span class="dkgrey14b"> > </span>Ask-A-Pro<span class="dkgrey14b"> > </span>POST</span>
                <br />
                <br />
                <br />
                <table cellspacing="0" border="0" bgcolor="#F0F0F0" bordercolor="FF9900">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
<%--                                <tr>
                                    <td valign="top" colspan="2" align="left">
                                        <span class="dkgrey16">&nbsp;&nbsp;Choose a category.</span></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                        <asp:DropDownList ID="cboCategory" Width="200px" runat="server" CssClass="dkgrey12"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <span class="dkgrey16">&nbsp;&nbsp;Type in your question:</span>
                                    </td>
                                    <td align="right" class="midorange16b">
                                        <asp:Label ID="lblTxtCount" runat="server">200</asp:Label>&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                        <asp:TextBox ID="txtQuestion" onkeydown="javascript:CharCountAndDisplay(this.form.txtQuestion,200,'lblTxtCount')"
                                            runat="server" CssClass="dkgrey18" Height="120px" Width="352px" MaxLength="599"
                                            Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="dkgrey16">&nbsp;&nbsp;Tag this by describing your question<a class="Tips" href="#" title="Tags make your question searchable|Separate with commas (e.g. beginner, surfboard, summer)">
                                            <span class="midorange16">[?]</span></a>:</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                        <img src="../images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                        <asp:TextBox ID="txtTags" onkeydown="CharCount(this,50)" runat="server" CssClass="dkgrey18"
                                            Width="352px" MaxLength="50" TextMode="SingleLine" TabIndex="70"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="midorange12">
                                        &nbsp;&nbsp;<asp:CheckBox ID="chkNotify" CssClass="midorange12" runat="server" Text="&nbsp;E-mail me when someone answers" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                        <img src="../images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:ImageButton ID="imgNext" runat="server" ImageUrl="../images/preview.gif" TabIndex="5" OnClick="imgNext_Click1">
                                        </asp:ImageButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        <asp:HiddenField runat="server" ID="hdnEditNew" Value="-1" />
        <asp:HiddenField runat="server" ID="hdnQId" Value="-1" />
        <asp:HiddenField runat="server" ID="hdnUId" Value="-1" />
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
         <div id="push">
            </div>          
    </form>
        </div>
    <br /><br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
        <%--Google analytics--%>
        <script type="text/javascript" src="../include/js/googles.js"></script>    
</body>
</html>
