<%@ Page Language="c#" Codebehind="post_manager.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.post_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Post Manager - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('input.Tips').cluetip({splitTitle: '|',width: '145px',clickThrough: true});        
    });
    
        function ChangeStatus(id)
        {
            //
        
            var $dialog = $('<div></div>')
		    .html('Your changes were successfully made.')
		    .dialog({
			    autoOpen: false,
			    height:		200,
			    position:	'center',
			    title: 'Boardhunt'
		    });
		    
	        $dialog.dialog('open');
	        // prevent the default action, e.g., following a link
	        
	        //alert(id);
	        return false;		            
        }    

    </script>

</head>
<body>
    <div id="main" align="center">
        <form id="Form1" method="post" runat="server">
            <!-- #include file="include/Header.aspx" -->
            <div align="center" class="midorange14b" style="width: 500px">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>&nbsp;
                > MANAGE -
                <asp:Label ID="lblCount" runat="server"></asp:Label></div>
            <br />
            <div class="midorange26b" align="center">
                <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
            <div align="center">
                <table border="0">
                    <asp:DataList ID="dlEntryList" Width="700" runat="server" 
                        EnableViewState="false" OnItemCommand="View_ItemDetail" OnItemCreated="dlEntryList_OnItemCreated"
                        OnItemDataBound="dlEntryList_OnItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <td width="100" class="midgrey16b">
                                    Posted&nbsp;&nbsp;</td>
                                <td width="100" align="left" class="midgrey16b" colspan="2">
                                    Description</td>
                                <td width="20" class="midgrey16b" align="left">
                                    Price</td>
                                <td width="20">
                                    <img src="images/s1x1.gif"></td>
                                <td class="midgrey16b" colspan="5" align="left">
                                    Manage
                                </td>
                                <td align="left">
                                    <img src="images/s1x1.gif" alt="" />
                                    <asp:LinkButton ID="lnkBtnAddNew" runat="server" CssClass="ltgreen_orange16" Visible="true"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11" bgcolor="#ff9933">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <!-- TODO: This is a multi category view so we need dynamic formatting - Create a hidden control and drop the board cat to dymanically format ht/in -->
                            <tr <%#(Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %>>
                                <td width="100">
                                    <asp:Label ID="label9" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}")%>
                                    </asp:Label>
                                </td>
                                <td align="left" nowrap>
                                    <asp:Label ID="Label3" runat="server" CssClass="dkgrey12b">	    
									    <%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"), DataBinder.Eval(Container.DataItem, "iCategory"))%>
										
										<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"), DataBinder.Eval(Container.DataItem, "iCategory"))%>
										
										<%# DataBinder.Eval(Container.DataItem, "txtBrand") %>
										&nbsp;

										<%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
										<%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>
										<%# DataBinder.Eval(Container.DataItem, "txtModel")%>
										
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;&nbsp</td>
                                <td align="left" width="30">
                                    <asp:Label ID="Label5" runat="server" CssClass="dkgrey12b">
										<%# FormatPrice(DataBinder.Eval(Container.DataItem, "adType"),DataBinder.Eval(Container.DataItem, "fltPrice"), DataBinder.Eval(Container.DataItem, "txtPrice"))%>
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;&nbsp</td>
                                <td align="left">
                                    <asp:LinkButton ID="lnkBtnView" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                        Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                        OnCommand="ViewItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iCategory")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>view</asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                        Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                        OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iCategory")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>edit</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;&nbsp</td>
                                <td align="left">
                                    <asp:LinkButton ID="lnkBtnSold" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                        Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                        OnCommand="UpdateToSold" CommandName='<%# DataBinder.Eval(Container.DataItem, "iStatus")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'><%# GetStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%></asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;&nbsp;</td>
                                <td align="left">
                                    <asp:ImageButton ID="btnUpgrade" class="Tips" title="Boost|Sell your board faster"
                                        ImageUrl='<%# SetUpgradeButtonSrc(DataBinder.Eval(Container.DataItem, "iStatus"),DataBinder.Eval(Container.DataItem, "iBoosted"))%>'
                                        runat="server" Enabled='<%# GetEnabledUpgradeStatus(DataBinder.Eval(Container.DataItem, "iStatus"),DataBinder.Eval(Container.DataItem, "iBoosted"))%>'
                                        OnCommand="UpgradeEntry" CommandName='<%# DataBinder.Eval(Container.DataItem, "iBoosted")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                    &nbsp;&nbsp;
                                    <asp:CheckBox runat="server" ID="chkPublish" CssClass="dkgrey12b" Checked='<%# GetPublishedStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                        Text="Publish" />
                                        &nbsp;&nbsp;                                    
                                    <asp:ImageButton ID="imgBtnFB" OnClientClick='<%# FormatOCC(DataBinder.Eval(Container.DataItem, "iD"))%>'
                                        runat="server" CssClass="Tips" title="FBShare|Tell your Facebook friends" ImageUrl="images/fb_share.gif" />

                                    <asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                    </asp:DataList>
                </table>
            </div>
            <div align="center">
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="images/s1x1.gif" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='images/backpage2.gif'" onmouseout="this.src='images/backpage.gif'"
                                runat="server" ImageUrl="images/backpage.gif"></asp:ImageButton>&nbsp;
                            <asp:Label CssClass="dkgrey12b" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='images/nextpage2.gif'" onmouseout="this.src='images/nextpage.gif'"
                                runat="server" ImageUrl="images/nextpage.gif"></asp:ImageButton></td>
                    </tr>
                </table>
            </div>
            <div align="center">
                <asp:Button ID="btnCancel" CssClass="btnCancel" runat="server" Text="Cancel" Visible="false" />
                <asp:Button ID="btnUpdate" CssClass="btnGo" runat="server" Text="Update" Visible="false" />
            </div>
            <asp:HiddenField ID="hdnAdType" runat="server" />
            <div id="push">
            </div>
            <div align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label>
                </div>
            <div class="push"></div>                
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>