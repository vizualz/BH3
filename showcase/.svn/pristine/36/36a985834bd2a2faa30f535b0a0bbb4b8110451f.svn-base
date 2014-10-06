<%@ Page Codebehind="showcase_item.aspx.cs" MaintainScrollPositionOnPostback="true" validateRequest=false Language="c#"
    AutoEventWireup="True" Inherits="BoardHunt.showcase.showcase_item" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Used surfboards snowboards skateboards wakeboards classifieds...Boardhunt</title>
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
        <form class="header" id="Form1" runat="server">

        <!-- #include file="../include/Header.aspx" -->
            <div align="center" class="midorange14b" style="width:500px">
                <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="showcase.aspx" CssClass="midorange14b">CREATE AD</asp:HyperLink>
                &gt;
                <asp:Label runat="server" ID="lblCat"></asp:Label>
            </div >
            <asp:Panel ID="pnlItem" runat="server" Width="610" BorderColor="#FF9900" BorderWidth="4px" BorderStyle="solid">
                <table cellspacing="0" cellpadding="0" width="610" border="0" bgcolor="FFCC66">
                    <tr>
                        <td height="2" colspan="2" bgcolor="#FF9900">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    
        <tr> 
          <td colspan="2" class="black12b" bgcolor="#FF9900" align="center" height="20">Create it with some detail!</td>
                    </tr>
                    <tr>
                        <td bgcolor="#FF9900" height="5" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td height="5" bgcolor="#FFCC66" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10" bgcolor="#FFCC66" class="black12b" align="right">required in bold&nbsp;&nbsp;
                            </td>
                    </tr>
					<tr>
                        <td height="5" bgcolor="#FFCC66" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <asp:Panel ID="pnlBoardType" runat="server">
                        <tr>
                            <td class="black12b" align="right" style="width: 130px;">
                                Board type:&nbsp;</td>
                            <td align="left">
                                <asp:DropDownList ID="cboBoardType" runat="server" CssClass="controls" Width="136px"
                                    TabIndex="1">
                                </asp:DropDownList>
                                
                                <asp:CheckBox ID="chkOther" Text="Or other" runat="server" onClick="ToggleBT();"
                                    CssClass="controls" Checked="false" Visible="false" TabIndex="5" />
                                <asp:TextBox ID="txtOtherBoard" runat="server" Width="100px" Visible="false" CssClass="controls"
                                    ToolTip="Type in your board type" TabIndex="15"></asp:TextBox>
                                <asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="../images/help.gif" CausesValidation="false"
                                    ImageAlign="AbsMiddle" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img height="5" src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlAdTitle" runat="server" Visible="true">
                        <tr>
                            <td align="right" style="width: 130px;"> 
                                <asp:Label Cssclass="black12b" ID="lblAdTitle" runat="server">
                                Showcase Title:&nbsp;
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
                    <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                        <tr>
                            <td align="right" style="width: 130px;"> 
                                <asp:Label Cssclass="black12b" ID="lblItem" runat="server">
                                Item:&nbsp;
                                </asp:Label>
                             </td>
                            <td align="left">
                                <asp:TextBox ID="txtGearItem" CssClass="controls" Width="136px" runat="server" Visible="true"
                                    TabIndex="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img height="5" src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlBrand" runat="server">
                        <tr>
                            <td class="black12b" align="right" width="130px">
                                <asp:Label ID="lblBrand" runat="server">Brand</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="controls" Width="136px" TabIndex="25"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="alert" OnServerValidate="CheckBrand"
                                    ErrorMessage="!"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlGenDims" runat="server">
                        <tr>
                            <td valign="top" align="right" width="130">
                                <asp:Label ID="lblGenDims" CssClass="black12b" runat="server">Dimensions:</asp:Label>&nbsp;
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtGenDims" CssClass="controls" runat="server" TabIndex="60"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>

                    <tr>
                        <td class="black12b" align="right" width="130">
                            &nbsp;Price:&nbsp;</td>
                        <td class="controls" align="left">
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="controls" Width="64px" MaxLength="8"
                                TabIndex="65"></asp:TextBox>&nbsp; $ <span class="black12b">(US dollars)</span>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="alert" OnServerValidate="CheckPrice"
                                ErrorMessage="!"></asp:CustomValidator></td>
                    </tr>
                    
                    <tr>
                        <td height="5" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                    <tr>
                            <td valign="top" align="right" width="130">
                                <asp:Label ID="lblWeb" CssClass="black12b" runat="server">Web:</asp:Label>&nbsp;
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtWebURL" CssClass="controls" runat="server" TabIndex="66"></asp:TextBox>
                            </td>
                    </tr>
                    
                    </asp:Panel>
                    <tr>
                        <td class="black12b" valign="top" align="right">
                            Comments:&nbsp;</td>
                        <td align="left">
                            <asp:TextBox ID="txtDetails" runat="server" CssClass="controls"
                                Height="120px" Width="352px" MaxLength="255" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td height="10">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" style="height: 24px">
                        </td>
                        <td align="left" valign="bottom" style="height: 28px" bgcolor="#FF9900">
                            &nbsp;<asp:Button ID="btnShowPnl" CausesValidation="false" runat="server" Text="Add Images..."
                                TabIndex="71" onclick="btnShowPnl_Click"></asp:Button>&nbsp;
                            <asp:Label CssClass="black12b" ID="lblImgTip" runat="server">If upload doesn't work, try again.</asp:Label>
                        </td>
                    </tr>
                    <tr>
						<td  height="15"><img src="../images/s1x1.gif"></td>
                        
          <td  height="20" valign="top" class="black12b" bgcolor="#FF9900"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(File limit is <font color="red"><b>2MB</b></font> in JPG or GIF
            format)</td>
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
                                            <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="controls" OnClick="rdoClick('1')"
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
                                            <asp:RadioButtonList ID="rdoImgMgr2" runat="server" CssClass="controls" OnClick="rdoClick('2')"
                                                TabIndex="18">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <input class="controls" id="File1" type="file" name="File1" runat="server">
                                            <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td colspan="2">
                                            <input class="controls" id="File2" type="file" name="File2" runat="server">
                                            <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            &nbsp;
                                            <asp:Image ID="img3" runat="server" Height="100px" Width="100px"></asp:Image>
                                        </td>
                                        <td valign="bottom">
                                            <asp:RadioButtonList ID="rdoImgMgr3" runat="server" CssClass="controls" OnClick="rdoClick('3')"
                                                TabIndex="18">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td style="width: 120px">
                                            &nbsp;
                                            <asp:Image ID="img4" runat="server" Height="100px" Width="100px"></asp:Image>
                                        </td>
                                        <td valign="bottom" style="width: 85px">
                                            <asp:RadioButtonList ID="rdoImgMgr4" runat="server" CssClass="controls" OnClick="rdoClick('4')"
                                                TabIndex="19">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <input class="controls" id="File3" type="file" name="File1" runat="server">
                                            <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td colspan="2">
                                            <input class="controls" id="File4" type="file" name="File2" runat="server">
                                            <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
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
                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/back.gif" TabIndex="80">
                            </asp:ImageButton>
                            <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="../images/next.gif" TabIndex="76">
                            </asp:ImageButton>&nbsp;
                            
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
            <br /><br />
            <div id="push">
            </div>
        </form>
            </div>
            <div align="center">
                <!--#include file="../include/footer.aspx"-->
            </div>            
</body>
</html>
