<%@ Page Language="c#" Codebehind="Manager.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.qp.Manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Edit Coupon - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW"/> 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../include/js/superfish.js"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />       
    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
        
    $('input.Tips').cluetip({splitTitle: '|'});        
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
	        
	        alert(id);
	        return false;		            
        }    

    </script>

</head>
<body>
        <div id="main" align="center">
    <form id="Form1" method="post" runat="server">

            <!-- #include file="../include/Header.aspx" -->
<%--            <div style="width:200px">
                <br />
                <span class="midorange14b">EDIT COUPONS</span><br />
                <br /> 
                </div>  --%>         
            <div align="center" class="midorange14b" style="width:500px">
                <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="../UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>&nbsp;
                > EDIT COUPONS&nbsp;
                <asp:Label ID="lblCount" runat="server"></asp:Label></div>
            <br />
            <div class="midorange26b" align="center">
                <asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label></div>
            <div align="center">
                    <asp:DataList ID="dlEntryList" Width="900" runat="server" 
                        EnableViewState="false" OnItemCommand="View_ItemDetail" OnItemCreated="dlEntryList_OnItemCreated"
                        OnItemDataBound="dlEntryList_OnItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <td width="60" class="midgrey16b" align="left">
                                    Start&nbsp;&nbsp;</td>
                                <td width="60" class="midgrey16b" align="left">
                                    Exp&nbsp;&nbsp;</td>                                    
                                <td width="180" align="left" class="midgrey16b">
                                    Title</td>
                                <td width="120" class="midgrey16b" align="left">
                                    Coupon Code</td>
                                <td class="midgrey16b" width="90">
                                    Purchased
                                </td>
                                <td class="midgrey16b" width="90">
                                    Remaining
                                </td>                                
                                <td align="right">
                                    <img src="../images/s1x1.gif" alt=""/>
                                    <asp:LinkButton ID="lnkBtnAddNew" runat="server" CssClass="ltgreen_orange16" Visible="true"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" bgcolor="#ff9933">
                                    <img src="../images/s1x1.gif"/></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr <%#(Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %>>
                                <td align="left">
                                    <asp:Label ID="label9" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "dAdded", "{0: MM/dd}")%>
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="label4" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "dExpire", "{0: MM/dd}")%>
                                    </asp:Label>
                                </td>                                
                                <td align="left">
                                    <asp:Label ID="lblTitle" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "title")%>
                                    </asp:Label>
                                </td>                                
                                <td align="left" nowrap>
                                    <asp:Label ID="Label3" runat="server" CssClass="dkgrey12b">	    
										<%# DataBinder.Eval(Container.DataItem, "code")%>
										&nbsp;
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="dkgrey12b">
										<%# FormatPkgCnt(DataBinder.Eval(Container.DataItem, "smsPkgCnt"), DataBinder.Eval(Container.DataItem, "iStatus"))%>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "smsLiveCnt")%>
                                    </asp:Label>
                                </td>                                                                
                                <td align="left">
                                    <asp:CheckBox runat="server" Checked='<%# GetPublishedStatus(DataBinder.Eval(Container.DataItem, "iPublish"))%>' ID="chkPublish" CssClass="dkgrey12b" 
                                    Visible='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>' Text="&nbsp;Publish" />
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                        Enabled="true"
                                        OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>edit</asp:LinkButton>                                
                                    &nbsp;
<%--                                    <asp:LinkButton ID="lnkBtnView" runat="server" Font-Underline="true" CssClass="orange_grey12u" Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                        OnCommand="ViewItem" CommandName='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>view</asp:LinkButton>
                                                                        &nbsp;--%>
                                <asp:Button ID="btnPay" OnCommand="Activate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' Text="Purchase" runat="server" Visible='<%# !GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>' CssClass="btnDoSm" />
                                
                                 <asp:ImageButton align="bottom" ID="imgBtnFB" OnClientClick='<%# FormatOCC(DataBinder.Eval(Container.DataItem, "iD"))%>' runat="server" CssClass="Tips"  title="FBShare|Share it on Facebook" ImageUrl="../images/fb_share.gif" Visible='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'  />
                                 <asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                  
                                
                                </td>
<%--
                                    <asp:LinkButton ID="lnkBtnSold" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                        Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                       
                                        OnCommand="UpdateToSold" CommandName='<%# DataBinder.Eval(Container.DataItem, "iStatus")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'><%# GetStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%></asp:LinkButton>

                                    <asp:ImageButton ID="btnUpgrade" class="Tips" title="Boost|Sell your board faster"
                                        ImageUrl='<%# SetUpgradeButtonSrc(DataBinder.Eval(Container.DataItem, "iStatus"),DataBinder.Eval(Container.DataItem, "pStatus"))%>'
                                        runat="server" Enabled='<%# GetEnabledUpgradeStatus(DataBinder.Eval(Container.DataItem, "iStatus"),DataBinder.Eval(Container.DataItem, "pStatus"))%>'
                                        OnCommand="UpgradeEntry" CommandName='<%# DataBinder.Eval(Container.DataItem, "pStatus")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                        &nbsp;&nbsp;--%>

                            </tr>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                    </asp:DataList>
            </div>
            <div align="center">
                <table border="0">
                    <tr>
                        <td height="20">
                            <img src="../images/s1x1.gif"/></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
                                runat="server" ImageUrl="../images/backpage.gif"></asp:ImageButton>&nbsp;
                            <asp:Label CssClass="dkgrey12b" ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
                            <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
                                runat="server" ImageUrl="../images/nextpage.gif"></asp:ImageButton></td>
                    </tr>
                </table>
            </div>
            <div align="center">
            <asp:Button ID="btnCancel" Height="30px" Width="100px" CssClass="btnCancel" runat="server" Text="Cancel" Visible="false" />
            <asp:Button ID="btnUpdate" Height="30px" Width="100px" CssClass="btnGo" runat="server" Text="Update" Visible="false" />
            </div>            
        <asp:HiddenField ID="hdnAdType" runat="server" />
            <div id="push">
            </div>
    </form>
        </div>    
    <br />
    <div align="center">
        <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label></div>
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
