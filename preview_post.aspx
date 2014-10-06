<%@ Page Codebehind="preview_post.aspx.cs" EnableEventValidation="false" Language="c#" AutoEventWireup="False" Inherits="BoardHunt.preview_post" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Preview Post - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
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
            <!-- #include file="include/Header.aspx" -->
            <div align="center">
            <div style="width:400px; height:50px;">
                <span class="midorange26b">
                    Last Step: Approve Post</span>
                </div><br />                   
                <!-- Master Table -->
                <asp:Panel ID="pnlError" runat="server" Width="720px" Visible="false">
                    <table cellpadding="2" cellspacing="0" border="2" bgcolor="#ffE4E1" bordercolor="#ff0000">
                        <tr>
                            <td align="center" height="100px" width="500px" class="dkrgrey16">
                                Oye! Our apologies, not sure what happened.<br />
                               <a href="javascript:doIt()" class="red_black12">Open a new browser
                                    and try again.</a></td>
                        </tr>
                    </table>
                </asp:Panel><br />
                <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" Style="width: 720px"
                    BorderWidth="6px" BorderColor="#FF9900" BorderStyle="solid">
                    <table cellspacing="0" cellpadding="0" border="0" align="center" bgcolor="#FFFFCC">
                        <tr>
                            <td height="2" colspan="2" bgcolor="#ff9900">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                        <td bgcolor="#ff9900">
                        <asp:Button ID="btnEditTop" runat="server" CssClass="btnStepBack" Height="35px" Text="Edit" Visible="false" />&nbsp;&nbsp;
                        <asp:Button ID="btnFinishTop" runat="server" CssClass="btnGo" Height="35px" Text="Finish" Visible="false" />
                        </td>
                            <td class="White20b" bgcolor="#ff9900" align="left" height="20">
                                How does it look?</td>
                        </tr>
                        <tr>
                        <td bgcolor="#ff9900"><span class="white12">Clickin' back on your browser might cause a break.</span></td>
                            <td class="white12" bgcolor="#ff9900" align="left" height="20">
                                Click &quot;edit&quot; for changes or &quot;finish&quot;</td>
                        </tr>
                        <tr>
                            <td bgcolor="#ff9900" height="2" colspan="2">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td>
                                <!-- left side -->
                                <table>
                                    <tr>
                                        <td align="right">
                                            &nbsp;<asp:Image ID="Pic1" runat="server" Height="300" Width="300"></asp:Image>&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Image ID="Pic2" runat="server" Visible="false"></asp:Image>
                                            <asp:Image ID="Pic3" runat="server" Visible="false"></asp:Image>
                                            <asp:Image ID="Pic4" runat="server" Visible="false"></asp:Image>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" nowrap>
                                            <asp:Image Visible="false" ID="Pic1ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                                Height="1" Width="1" />
                                            <asp:Image Visible="false" ID="Pic2ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                                Height="1" Width="1" />
                                            <asp:Image Visible="false" ID="Pic3ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                                Height="1" Width="1" />
                                            <asp:Image Visible="false" ID="Pic4ThmbNail" runat="server" ImageUrl="images/s1x1.gif"
                                                Height="1" Width="1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <!-- end left side -->
                            <!-- begin right side -->
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0" bgcolor="#FFFFCC">
                                    <tr>
                                        <td valign="bottom" class="ltgrey10" align="right">
                                            posted:&nbsp;<asp:Label ID="lblDateData" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                            <img src="images/s1x1.gif"></td>
                                        <td bgcolor="#FFFFCC">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <asp:Panel runat="server" ID="pnlLocation">
                                        <tr>
                                            <td height="20px" width="35%" class="midorange16b" align="left">
                                                Location:&nbsp;</td>
                                            <td class="midorange16b" align="left" width="65%">
                                                <asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlGearItem">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left">
                                                <asp:Label ID="lblGearItem" runat="server" Visible="false">&nbsp;&nbsp;Gear item:&nbsp;</asp:Label>
                                            </td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblGearItemData" runat="server"></asp:Label>
                                            </td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlModel" runat="server" Visible="false">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left">
                                                <asp:Label ID="lblModel" runat="server">Model:&nbsp;</asp:Label></td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblModelData" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlShaper">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left">
                                                <asp:Label ID="lblBrand" runat="server">Shaper:&nbsp;</asp:Label></td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblBrandData" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlBoardType">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left" width="35%">
                                                <asp:Label ID="lblBoardType" runat="server">&nbsp;&nbsp;Board type:&nbsp;</asp:Label></td>
                                            <td class="dkgrey16b" align="left" width="65%">
                                                <asp:Label ID="lblBoardTypeData" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAll" runat="server">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left">
                                                <asp:Label ID="lblHeight" runat="server">Height:&nbsp;</asp:Label></td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblHeightFtData" runat="server"></asp:Label>
                                                <asp:Label ID="lblHeightInData" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlWidth" runat="server">
                                            <tr>
                                                <td height="20px" class="dkrgrey16" align="left">
                                                    Width:&nbsp;</td>
                                                <td class="dkgrey16b" align="left">
                                                    <asp:Label ID="lblWidthData" runat="server"></asp:Label></td>
                                                <td bgcolor="#FFFFCC">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlSurfOnly" runat="server">
                                            <tr>
                                                <td height="20px" class="dkrgrey16" align="left">
                                                    Thickness:&nbsp;</td>
                                                <td class="dkgrey16b" align="left">
                                                    <asp:Label ID="lblThick" runat="server"></asp:Label></td>
                                                <td bgcolor="#FFFFCC">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20px" class="dkrgrey16" align="left">
                                                    Tail:&nbsp;</td>
                                                <td class="dkgrey16b" align="left">
                                                    <asp:Label ID="lblTailData" runat="server"></asp:Label></td>
                                                <td bgcolor="#FFFFCC">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20px" class="dkrgrey16" valign="top" align="left">
                                                    Fins:&nbsp;</td>
                                                <td class="dkgrey16b" align="left">
                                                    <asp:Label ID="lblFinsData" runat="server"></asp:Label></td>
                                                <td bgcolor="#FFFFCC">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlGenDims" runat="server" Visible="false">
                                        <tr>
                                            <td height="20px" class="dkrgrey16" align="left">
                                                Dimensions:&nbsp;</td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblGenDims" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                                        <tr>
                                            <td height="20px" class="dkgrey16" align="left">
                                                Web:&nbsp;</td>
                                            <td class="dkgrey16b" align="left">
                                                <asp:Label ID="lblWeb" runat="server"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;</td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td class="dkrgrey16" align="left" width="400px">
                                            The Deal:&nbsp;</td>
                                        <td bgcolor="#FFFFCC">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkrgrey12" align="left">
                                            <asp:Label ID="lblDetailsData" runat="server" Width="300px"></asp:Label></td>
                                        <td bgcolor="#FFFFCC">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#FFFFCC" height="5px">
                                            <img src="images/s1x1.gif"></td>
                                    </tr>
                                    <tr>
                                        <td height="35px" class="dkorange26b" align="left" valign="bottom">
                                            <asp:Label ID="lblPrice" CssClass="dkorange26b" runat="server">Price:</asp:Label>&nbsp;<asp:Label
                                                ID="lblPriceData" CssClass="dkorange26b" runat="server"></asp:Label></td>
                                        <td bgcolor="#FFFFCC">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ff9900" width="390px" style="height: 5px">
                                            <img src="images/s1x1.gif"></td>
                                    </tr>
                                    
                                </table>
                                <asp:Panel runat="server" ID="pnlContact">
                                    <table cellpadding="0" cellspacing="0" border="0" bgcolor="#FFFFCC">
                                        <tr>
                                            <td colspan="3" bgcolor="#FFFFCC" height="30" class="midorange16b" align="left" valign="bottom">
                                                Contact Info
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20px" class="dkrgrey14" align="left">
                                                E-mail:&nbsp;</td>
                                            <td class="email" align="left" width="150px" colspan="2">
                                                <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="red_orange12u"></asp:LinkButton></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20px" class="dkrgrey14" align="left" nowrap>
                                                Ph:&nbsp;</td>
                                            <td class="dkrgrey14" align="left" colspan="2">
                                                <asp:Label ID="lblPhoneData" runat="server" CssClass="sm_dk_grn"></asp:Label></td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" height="5">
                                                <img src="images/s1x1.gif">
                                            </td>
                                            <td bgcolor="#FFFFCC">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <!-- problem ? -->
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <%--&nbsp;<asp:ImageButton ID="imgGoBack" runat="server" ImageUrl="images/edit.gif" ToolTip="Go back and edit" Visible="false">
                        </asp:ImageButton>
                         <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="images/done.gif" Visible="false">
                        </asp:ImageButton>
                        &nbsp;--%>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnEdit" runat="server" CssClass="btnStepBack" Text="Edit" Height="35px" Visible="false" />&nbsp;
                                <asp:Button ID="btnSave" runat="server" CssClass="btnStep" Text="Save Only" Height="35px" Visible="false" />&nbsp;
                                <asp:Button ID="btnPublish" runat="server" CssClass="btnGo" Text="Finish" Height="35px" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="header" colspan="2">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:HiddenField ID="hdnProcPics" runat="server" />
                <asp:HiddenField ID="hdnUserDir" runat="server" />
                <asp:HiddenField ID="hdnAdType" runat="server" />
                <div id="push">
                </div>
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
