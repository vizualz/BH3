<%@ Page Codebehind="BlogItem.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" validateRequest=false Language="c#"
    AutoEventWireup="false" Inherits="BoardHunt.Blog.BlogItem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Blog - Boardhunt</title>
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
    <div align="center">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->
            <div align="center" class="midorange14b" style="width:500px;height:40px">
                <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="Blog.aspx" CssClass="orange_dkorange26">CREATE BLOG</asp:HyperLink>
                &gt;
                <asp:Label runat="server" ID="lblCat"></asp:Label>
            </div
            <br /><br />
            <asp:Panel ID="pnlItem" runat="server" Width="610" BorderColor="#FF9900" BorderWidth="4px" BorderStyle="solid">
                <table cellspacing="0" cellpadding="0" width="610" border="0" bgcolor="FFFFCC">
                    <tr>
                        <td height="2" colspan="2" bgcolor="#FF9900">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    
        <tr> 
          <td colspan="2" class="white16b" bgcolor="#FF9900" align="center" height="20">Blog with some detail!</td>
                    </tr>
                    <tr>
                        <td bgcolor="#FF9900" height="5" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td height="5" bgcolor="#FFFFCC" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td colspan="2" bgcolor="#FFFFCC" class="controls" align="right" style="height: 10px">&nbsp;&nbsp;
                            </td>
                    </tr>
					<tr>
                        <td height="5" bgcolor="#FFFFCC" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    
                    <asp:Panel ID="pnlAdTitle" runat="server" Visible="true">
                        <tr>
                            <td align="right" style="width: 130px;"> 
                                <asp:Label Cssclass="dkgrey12b" ID="lblAdTitle" runat="server">
                                Blog Title:&nbsp;
                                </asp:Label>
                             </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdTitle" CssClass="controls" Width="136px" runat="server" Visible="true"
                                    TabIndex="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img height="5" src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>                    
                    
                    <tr>
                        <td height="5" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                    <tr>
                            <td valign="top" align="right" width="130">
                                <asp:Label ID="lblWeb" CssClass="postdetails2" runat="server">Web:</asp:Label>&nbsp;
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtWebURL" CssClass="controls" runat="server" TabIndex="66"></asp:TextBox>
                            </td>
                    </tr>
                    
                    </asp:Panel>
                    <tr>
                        <td class="dkgrey12b" valign="top" align="right" style="height: 280px">
                            The Blog:&nbsp;</td>
                        <td align="left" style="height: 280px">
                            <asp:TextBox ID="txtDetails" runat="server" CssClass="dkgrey10b" Height="241px" Width="352px" MaxLength="255" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td height="10">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" style="height: 24px">
                        </td>
                        <td align="left" valign="bottom" style="height: 28px" bgcolor="#FF9900">
                            &nbsp;<asp:Button ID="btnShowPnl" CssClass="btnCancel" CausesValidation="false" runat="server" Text="Add Images..."
                                TabIndex="71"></asp:Button>&nbsp;
                            <asp:Label CssClass="black12b" ID="lblImgTip" runat="server">2MB MAX per jpeg or gif.</asp:Label>
                        </td>
                    </tr>
                    <tr>
						<td  height="15"><img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
						<td  colspan="2" height="5"><img src="../images/s1x1.gif"></td>
						</tr>
                    <tr>
                            <td>&nbsp;
                                
                            </td>
                            
                            <td style="width: 482px">
                            <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="False"
                            BorderColor="#ff9900" BorderStyle="Solid" BorderWidth="1" BackColor="#ff9900">
                                <table style="z-index: 115; width: 288px; height: 52px" align="left" bgcolor="#FFFFFF"
                                    bordercolor="#ff9900" border="0">
                                    <tr>
                                        <td style="width: 120px">
                                            &nbsp;
                                            <asp:Image ID="img1" runat="server" Height="100px" Width="100px"></asp:Image>
                                        </td>
                                        <td valign="bottom">
                                            <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('1')"
                                                TabIndex="17">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td style="width: 120px">
                                            &nbsp;
                                            <asp:Image ID="img2" runat="server" Height="100px" Width="100px"></asp:Image>
                                        </td>
                                        <td valign="bottom" style="width: 85px">
                                            <asp:RadioButtonList ID="rdoImgMgr2" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('2')"
                                                TabIndex="18">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File1" type="file" name="File1" runat="server">
                                            <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True"></asp:CustomValidator>
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File2" type="file" name="File2" runat="server">
                                            <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="!" Font-Bold="True"></asp:CustomValidator>
                                        </td>
                                    </tr>

                                </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    
                    <tr>
                        <td height="10" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td>
                                    <asp:Button ID="btnBack" runat="server" CssClass="btnStepBack" Text="< Back" />
                                    &nbsp;
                                    <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Text="Next >"  />
                                    
                            
                        </td>
                    </tr>
                    <tr>
                        <td height="10" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;
                            
                        </td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" CssClass="header"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td>
                            <asp:Label ID="lbl2" runat="server" CssClass="header"></asp:Label></td>
                    </tr>
							<tr>
							<td></td>
							<td>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <asp:HiddenField ID="HiddenField4" runat="server" />                                
                            </td>
							</tr>                                        

                </table>
            </asp:Panel>
            <br />
            <div id="push">
            </div>
        </form>
            </div>
    </div>
            <div align="center">
                <!--#include file="../include/footer.aspx"-->
            </div>    
</body>
</html>
