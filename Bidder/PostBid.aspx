<%@ Page Codebehind="PostBid.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="c#"
    AutoEventWireup="True" Inherits="BoardHunt.Bidder.PostBid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>Post Item Page - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    <script type="text/javascript" src="../include/js/m1-2b.js"></script>
    <script type="text/javascript" src="../include/js/dropdown.js"></script>
    <script language="JavaScript" src="../include/js/bh.js" type="text/javascript"></script>     
    <link href="../style/dropdown.css" type="text/css" rel="stylesheet"/>
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>
    <link href="../style/popup.css" type="text/css" rel="stylesheet"/>
    <link href="../style/tips.css" type="text/css" rel="stylesheet"/> 

    
<%--    <script language="javascript" type="text/javascript">
    window.addEvent('domready', function() {
    
    //hide button on wanted ad
    var ctl1 = document.getElementById('pnlBrand');
    if (ctl1 == null)
    {
        var btn = document.getElementById('btnShowImgPanel');
        btn.style.display = 'none';
    }
    
    
    var ctl2 = document.getElementById('File4');
    if (ctl2 != null)
    {
        ctl2.style.display = 'none';
    }    

    });    
    </script>--%>

    <script language="JavaScript">
       function FreezeScreen(msg) {
          scroll(0,0);
          var outerPane = document.getElementById('FreezePane');
          var innerPane = document.getElementById('InnerFreezePane');
          if (outerPane) outerPane.className = 'FreezePaneOn';
          if (innerPane) innerPane.innerHTML += msg;
       }
    </script>
    <script language="javascript" type="text/javascript">
    window.addEvent('domready', function() {
        var Tips1 = new Tips($$('.Tips1'),
        {
        maxTitleChars: 50
        });
    });   
    </script> 
     
</head>
<body>
    <div align="center">
        <form id="Form1" runat="server">
        <div id="main" align="center">
            <!-- #include file="../include/header2.aspx" -->
            <p class="midorange26b">
                <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="post.aspx" CssClass="orange_dkorange26">CREATE AD</asp:HyperLink>
                &gt;
                <asp:Label runat="server" ID="lblCat"></asp:Label>
            </p>
            <asp:Panel ID="pnlItem" runat="server" Width="750" BorderColor="#FF9900" BorderWidth="4px" BorderStyle="solid">
                <table cellspacing="0" cellpadding="0" width="750" border="0" bgcolor="ffffcc">
                    <tr>
                        <td height="2" colspan="2" bgcolor="#FF9900">
                            <img src="../images/s1x1.gif">
                         </td>
                    </tr>
                    
        <tr> 
          <td colspan="2" class="white16b" bgcolor="#ff9900" align="center" height="20">Be kind to your Shaper</td>
                    </tr>
                 
                    <tr>
                        <td bgcolor="#ff9900" colspan="2" style="height: 5px">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFFCC" colspan="2" style="height: 5px">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td height="10" colspan="2" bgcolor="#ffffcc" class="black10" align="left">&nbsp;&nbsp;<span class="midorange10b">*</span> Required</td>
                    </tr>
					<tr>
                        <td height="5" bgcolor="#FFFFCC" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <%--PRICE--%>
                    <tr>
                        <td class="black12" align="right" style="width: 130px;">
                                <span class="midorange10b">*</span>Starting Bid Price:&nbsp;</td>
                        <td align="left"><asp:TextBox ID="txtStartPrice" runat="server" Width="63px" ></asp:TextBox> 
                        &nbsp; $ <span class="midorange10b">(US dollars)</span>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="alert" OnServerValidate="CheckPrice"
                                ErrorMessage="!"></asp:CustomValidator>                       
                        </td>
                    </tr>
					<tr>
                        <td height="5" bgcolor="#FFFFCC" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                     <%--BOARD DETAILS--%>                    
                    <asp:Panel ID="pnlBoardType" runat="server">
                        <tr>
                            <td class="black12" align="right" style="width: 130px;">
                                <span class="midorange10b">*</span> Board type:&nbsp;</td>
                            <td align="left">
                                <asp:DropDownList ID="cboBoardType" runat="server" CssClass="dkgrey12" Width="136px"
                                    TabIndex="1">
                                </asp:DropDownList>
                                
                                <asp:CheckBox ID="chkOther" Text="Or other" runat="server" onClick="ToggleBT();"
                                    CssClass="dkgrey12" Checked="false" Visible="false" TabIndex="5" />
                                <asp:TextBox ID="txtOtherBoard" runat="server" Width="100px" Visible="false" CssClass="dkgrey12"
                                    ToolTip="Type in your board type" TabIndex="15"></asp:TextBox>
                                <asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="../images/help.gif" CausesValidation="false"
                                    ImageAlign="AbsMiddle" />
                            </td>
                        </tr>
                        <tr>
                            <td height="5"><img src="../images/s1x1.gif"></td>
                            <td class="midorange10b" align="left" valign="bottom">
                                Rollover Boardicons for description&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="1"><img src="../images/s1x1.gif"></td>
                            <td>
                                <table>
                                     <tr height="65px">
                                        <td align="center" class="dkgrey10b" width="60px"><IMG src="../images/shortboard.gif"class="Tips1" title="SURF: Shortboards::Typically thinner, below 7ft, with pointy noses, and 3 to 4 fins"><br />Shortboard</td>
                                        <td align="center" class="midgrey10b" width="60px"><img src="../images/funshape.gif" class="Tips1" title="SURF: Funshapes & Eggs::Shorter than a longboard, avg 7 to 8 ft, normally with 1 to 3 fins"><br />Funshape</td> 
                                        <td align="center" class="dkgrey10b" width="60px"><img src="../images/longboard.gif" class="Tips1" title="SURF: Longboards::Usually 9ft or bigger with rounded noses, and single or tri fin option (no Stand-up or paddle boards in this category please)"><br />Longboard</td> 
                                        <td align="center" class="midgrey10b" width="60px"><IMG src="../images/fish.gif" class="Tips1" title="SURF: Fishes/Retro::Any modern or retro fish, usually shorter and stubbier than a shortboard, with twin or quad fin set up"><br />Fish/retro</td> 
                                        <td align="center" class="dkgrey10b" width="60px"><img src="../images/gun.gif" class="Tips1" title="SURF: Gun & Miniguns::Big Wave boards, narrow and tall avg 7-12ft, various tails - mainly pin, with single to quad fin set up"><br />Guns</td> 
                                        <td align="center" class="midgrey10b" width="60px"><img src="../images/pro.gif" class="Tips1" title="SURF: Pro Models::Any Pro or signature board, or previously ridden by a pro"><br />Pro-model</td> 
                                        <td align="center" class="dkgrey10b" width="60px"><IMG src="../images/standup.gif" class="Tips1" title="SURF: Stand Up Paddle:: Typically 9-15ft and come with a paddle"><br />Stand-up</td> 
                                    </tr>
                                    
                             </table>
                           </td> 
                        </tr>
                    </asp:Panel>
                    
                    <%--TODO: REMOVE--%>
<%--                    <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                        <tr>
                            <td align="right" style="width: 130px;"> 
                                <asp:Label Cssclass="black12" ID="lblItem" runat="server">
                                <span class="midorange10b">*</span> Item:&nbsp;
                                </asp:Label>
                             </td>
                            <td align="left">
                                <asp:TextBox ID="txtGearItem" CssClass="dkgrey12" Width="136px" runat="server" Visible="true"
                                    TabIndex="20"></asp:TextBox>
                            </td>    
                        <tr>
                            <td colspan="2">
                                <img height="5" src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>--%>
                    
                    <%--TODO: REMOVE--%>
<%--                    <asp:Panel ID="pnlBrand" runat="server">
                        <tr>
                            <td class="dkgrey12b" align="right" width="130px">
                                <asp:Label ID="lblBrand" runat="server">Brand</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="dkgrey10b" Width="136px" TabIndex="25"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="alert" OnServerValidate="CheckBrand"
                                    ErrorMessage="!"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>--%>
                    
                    <asp:Panel ID="pnlHeight" runat="server">
                        
                         <tr>   
                            <td class="black12" align="right" style="width: 130px">
                                <span class="midorange10b">*</span> Height:&nbsp;</td>
                            <td class="black12" align="left">
                                <asp:TextBox ID="txtHtFt" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="2"
                                    TabIndex="30"></asp:TextBox>&nbsp;<asp:Label ID="lblHtFt" runat="server">ft</asp:Label>&nbsp;
                                <asp:TextBox ID="txtHtIn" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="2"
                                    TabIndex="35"></asp:TextBox>&nbsp;
                                <asp:Label ID="lblHtIn" runat="server">in</asp:Label>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="alert" OnServerValidate="CheckHeight"
                                    ErrorMessage="!"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>
 
                    
                    <asp:Panel ID="pnlSurfOnly" runat="server">
                        <tr>
                            <td height="5" colspan="2" style="width: 132px">
                                <img src="../images/s1x1.gif"></td>     
                        </tr>
                        <tr>
                            <td class="dkgrey12" align="right" style="width: 132px">
                                Width:&nbsp;</td>
                            <td class="dkgrey12" align="left">
                                <asp:TextBox ID="txtWidth" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="2"
                                    TabIndex="36"></asp:TextBox>&nbsp;and&nbsp;
                                <asp:TextBox ID="txtWidthNum" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="1"
                                    TabIndex="37"></asp:TextBox>&nbsp;/
                                <asp:TextBox ID="txtWidthDNum" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="2"
                                    TabIndex="38"></asp:TextBox>&nbsp;in&nbsp;<span class="midorange10b">(fractions only)</span>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="alert" OnServerValidate="CheckWidth"
                                    ErrorMessage="!"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" style="width: 132px">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td class="dkgrey12" align="right" style="width: 132px">
                                Thickness:&nbsp;</td>
                            <td class="dkgrey12" align="left">
                                <asp:TextBox ID="txtThick" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="1"
                                    TabIndex="50"></asp:TextBox>&nbsp;and&nbsp;
                                <asp:TextBox ID="txtThickNum" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="1"
                                    TabIndex="51"></asp:TextBox>&nbsp;/
                                <asp:TextBox ID="txtThickDNum" runat="server" CssClass="dkgrey10b" Width="24px" MaxLength="2"
                                    TabIndex="52"></asp:TextBox>&nbsp;in&nbsp;<span class="midorange10b">(fractions only)</span>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="alert" OnServerValidate="CheckThickness"
                                    ErrorMessage="!"></asp:CustomValidator>&nbsp;<span class="help"></span></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" style="width: 132px">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td class="dkgrey12b" valign="top" align="right" style="width: 130px">
                                <asp:Label ID="lblFins" runat="server">Fins:&nbsp;</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cboFins" CssClass="dkgrey10b" runat="server" TabIndex="56">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" style="width: 132px">
                                <img src="../images/s1x1.gif"></td>
                        </tr>                        
                        <tr>
                            <td class="dkgrey12b" align="right" style="width: 130px">
                                <asp:Label ID="lblTail" runat="server">Tail:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:DropDownList ID="cboTailType" runat="server" CssClass="dkgrey10b" Width="136px"
                                    TabIndex="57">
                                </asp:DropDownList>
                                <asp:ImageButton ID="imgBtnFinHelp" CausesValidation="false" runat="server" ImageUrl="../images/help.gif"
                                    ImageAlign="AbsMiddle" />
                            </td>
                        </tr>                        
                        <tr>
                            <td colspan="2" height="5">
                                <img src="../images/s1x1.gif"></td>
                        </tr>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlGenDims" runat="server">
                        <tr>
                            <td valign="top" align="right" width="130">
                                <asp:Label ID="lblGenDims" CssClass="dkgrey12b" runat="server">Dimensions:</asp:Label>&nbsp;
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtGenDims" CssClass="dkgrey10b" runat="server" TabIndex="60"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>

<%--                    <tr>
                        <td class="black12" align="right" width="130">
                            <span class="midorange10b">*</span> Price:&nbsp;</td>
                        <td class="black10" align="left" style="width: 482px">
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="dkgrey10b" Width="64px" MaxLength="8"
                                TabIndex="65"></asp:TextBox>&nbsp; $ <span class="midorange10b">(US dollars)</span>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="alert" OnServerValidate="CheckPrice"
                                ErrorMessage="!"></asp:CustomValidator></td>
                    </tr>--%>
                    
                    <tr>
                        <td height="5" colspan="2">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                    <tr>
                            <td valign="top" align="right" width="130">
                                <asp:Label ID="lblWeb" CssClass="dkgrey12b" runat="server">Web:</asp:Label>&nbsp;
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtWebURL" CssClass="dkgrey10b" runat="server" TabIndex="60"></asp:TextBox>
                            </td>
                    </tr>
                    
                    </asp:Panel>

                    <tr>
                        <td class="dkgrey12b" valign="top" align="right">
                            Details:&nbsp;</td>
                        <td align="left" valign="top" style="width: 482px">
                            <asp:TextBox ID="txtDetails" onkeydown="CountChars()" runat="server" CssClass="dkgrey12"
                                Height="120px" Width="352px" MaxLength="599" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                <span class="midorange10b"><b>(600 max; no HTML)</b>&nbsp;&nbsp;</span>
                                </td>
                    </tr>
                    
                    <tr>
                        <td height="10">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" style="height: 24px">
                        </td>
                        <td align="left" valign="bottom" style="height: 28px; width: 482px;" bgcolor="#FF9900">
                            &nbsp;
                            <input type="button" id="btnShowImgPanel" value="Add Images..." onclick="toggleImgPanel('pnlAddImages', 'btnShowImgPanel')" />    
                                &nbsp;
                            <asp:Label CssClass="white10b" ID="lblImgTip" runat="server"><span class="black12">2MB</span>&nbsp;max per GIF or JPG.</asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
						<td  height="15"><img src="../images/s1x1.gif"></td>
                        
          <td  height="20" valign="top" class="white10b" bgcolor="#FF9900" style="width: 482px"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            
            </td>
                    </tr>
                    <tr>
						<td  colspan="2" height="5"><img src="../images/s1x1.gif"></td>
					</tr>
                    <tr>
                            <td>&nbsp;
                                
                            </td>
                            
                            <td style="width: 482px" align="left">
                            <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="True"
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
                                            <input class="dkgrey10b" id="File1" type="file" name="File1" runat="server" onchange="swapImg('1')">
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File2" type="file" name="File2" runat="server" onchange="swapImg('2')">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            &nbsp;
                                            <asp:Image ID="img3" runat="server" Height="100px" Width="100px"></asp:Image>
                                        </td>
                                        <td valign="bottom">
                                            <asp:RadioButtonList ID="rdoImgMgr3" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('3')"
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
                                            <asp:RadioButtonList ID="rdoImgMgr4" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('4')"
                                                TabIndex="19">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File3" type="file" name="File1" runat="server" onchange="swapImg('3')">
                                        </td>
                                        <td>&nbsp;
                                            </td>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File4" type="file" name="File2" runat="server" onchange="swapImg('4')">
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <%--<asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True" OnServerValidate="CheckFileType"></asp:CustomValidator>--%>
                                <asp:Label runat="server" CssClass="error" ID="lblError" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    
                    <tr>
                        <td colspan="2" style="height: 10px">
                            <img src="../images/s1x1.gif"></td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                        <td nowrap align="left" style="width: 482px">
                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/back.gif" TabIndex="80" ToolTip="Back">
                            </asp:ImageButton>
                            <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="../images/next.gif" TabIndex="76" OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('imgContinue','lbl2');javascript:ShowElement('imgContinueFake');javascript:DisableElement('imgContinueFake');javascript:DisableElement('imgBack');" ToolTip="Next">
                            </asp:ImageButton>&nbsp;
                            <asp:ImageButton ID="imgContinueFake" runat="server" ImageUrl="../images/NextOff.gif" TabIndex="77" ToolTip="Next">
                            </asp:ImageButton>&nbsp;
                            <asp:Label ID="lbl2" runat="server" CssClass="black12"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td align="left" style="width: 482px">
                            <asp:Label ID="lblStatus" runat="server" CssClass="black12"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>

                    </tr>
							<tr>
							<td></td>
							<td style="width: 482px">
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <asp:HiddenField ID="HiddenField4" runat="server" />                                
                            </td>
							</tr>                                        

                </table>
            </asp:Panel>
            
            <div align="center" id="FreezePane" class="FreezePaneOff">
               <div id="InnerFreezePane" class="InnerFreezePane"><img src="../images/wait.gif" alt="Please wait" /> </div>
            </div>

            <br>
            <div align="center">
                <!-- #include file="../include/footer.aspx" -->
            </div>
            </div>
        </form>
    </div>
</body>
</html>
