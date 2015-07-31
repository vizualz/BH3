<%@ Page Language="c#" CodeBehind="post_manager.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.post_manager" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Post Manager - Boardhunt</title>
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

     <script src="include/js/bh.js" type="text/javascript"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />


    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {

            $('input.Tips').cluetip({ splitTitle: '|', width: '145px', clickThrough: true });
        });

        function ChangeStatus(id) {
            //

            var $dialog = $('<div></div>')
		    .html('Your changes were successfully made.')
		    .dialog({
		        autoOpen: false,
		        height: 200,
		        position: 'center',
		        title: 'Boardhunt'
		    });

            $dialog.dialog('open');
            // prevent the default action, e.g., following a link

            //alert(id);
            return false;
        }

    </script>
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <div id="main1">
        <form id="Form1" method="post" runat="server">
            <bh:Header runat="server" />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-8 col-md-8 col-sm-10 col-xs-12" style="float: none; margin: 0 auto;">
                    <div align="center" class="midorange14b col-md-12 col-sm-12 col-xs-12 text-left">
                        <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>&nbsp;
                		> MANAGE -
                		<asp:Label ID="lblCount" runat="server"></asp:Label>
                    </div>
                    <div class="midorange26b col-md-12 col-sm-12 col-xs-12 text-left" align="center">
                    	<div class="midorange26b col-md-6 col-sm-6 col-xs-6 text-left">
                    		<asp:Label CssClass="dir" ID="lblNoResult" runat="server"></asp:Label>
                    	</div>
	                    <div class="midorange26b col-md-6 col-sm-6 col-xs-6 text-right"> 
	                    <asp:LinkButton ID="lnkBtnAddNew" runat="server" CssClass="btn btn-default" Visible="true"></asp:LinkButton>
	                    </div>
                    </div>

                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <table class="" border="1">
                            <asp:DataList ID="dlEntryList" runat="server" CssClass="table table-bordered table-responsive"
                                EnableViewState="false" OnItemCommand="View_ItemDetail" OnItemCreated="dlEntryList_OnItemCreated"
                                OnItemDataBound="dlEntryList_OnItemDataBound">
                                <HeaderTemplate>
                                    <tr class="bg-light">
                                        <td class="midgrey16b">Date</td>
                                        <td align="left" class="midgrey16b">Detail</td>
                                        <td class="midgrey16b" align="left">$</td>
                                        <td class="midgrey16b" colspan="3" align="left">Manage
                                		</td>
                                    </tr>

                                </HeaderTemplate>
                                <ItemTemplate>
                                    <!-- TODO: This is a multi category view so we need dynamic formatting - Create a hidden control and drop the board cat to dymanically format ht/in -->
                                    <tr <%#(Container.ItemIndex%2==1)? "style='background-color:#F0F0F0'":"" %>>
                                        <td>
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
                                        <td align="left">
                                            <asp:Label ID="Label5" runat="server" CssClass="dkgrey12b">
											<%# FormatPrice(DataBinder.Eval(Container.DataItem, "adType"),DataBinder.Eval(Container.DataItem, "fltPrice"), DataBinder.Eval(Container.DataItem, "txtPrice"))%>
                                    		</asp:Label>
                                        </td>
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
                                        <td align="left">
                                            <asp:LinkButton ID="lnkBtnSold" runat="server" Font-Underline="true" CssClass="orange_grey12u"
                                                Enabled='<%# GetEnabledStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%>'
                                                OnCommand="UpdateToSold" CommandName='<%# DataBinder.Eval(Container.DataItem, "iStatus")%>'
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'><%# GetStatus(DataBinder.Eval(Container.DataItem, "iStatus"))%></asp:LinkButton>
                                        </td>
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

                                            <asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />
                                        </td>

                                    </tr>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
                            </asp:DataList>
                        </table>
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
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
                </div>
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>


    <!-- Bootstrap -->
    <script type="text/javascript" src="content/assets/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->

    <!-- Theme Javascript -->
    <script type="text/javascript" src="content/assets/js/utility/utility.js"></script>
    <script type="text/javascript" src="content/assets/js/main.js"></script>
    <script type="text/javascript" src="content/assets/js/demo.js"></script>

    <!-- Page Javascript -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            "use strict";

            // Init Theme Core      
            Core.init();

            // Init Demo JS
            Demo.init();
        });
    </script>
</body>
</html>
