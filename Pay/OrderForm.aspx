<%@ Page Language="C#" AutoEventWireup="false" Codebehind="OrderForm.aspx.cs" Inherits="BoardHunt.Pay.OrderForm" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html >
<html lang="en">
<head id="Head1" runat="server">
    <title>Buy - Boardhunt</title>
    <meta charset="utf-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <script src="include/js/bh.js" type="text/javascript"></script>

    <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function() {

    $('input.Tips').cluetip({splitTitle: '|',clickThrough:     true});

    });
    </script>

</head>
<body style="background: none repeat scroll 0 0 #fff;">

    <form class="header" id="Form1" enctype="multipart/form-data" runat="server">
	<bh:Header runat="server" />

	<!--- BOOTSTRAPPY -->

            <div align="center">
                <div align="center">
                    <div align="center" style="border: solid 0px red; width: 500px">
                        <br />
                        <asp:Label ID="lblPageTitle" CssClass="dkorange26b" runat="server"></asp:Label><br />
                        <asp:Label ID="lblPageTitleMsg" CssClass="dkgrey12b" runat="server"></asp:Label>
                        <br />
                    </div>
                </div>
                <br />
                    <asp:Panel ID="pnlError" Width="500px" runat="server" CssClass="errorLabel" Visible="false">
                        <asp:Label ID="lblErrorMessage" runat="server" Height="80px" Width="487px" CssClass="black12b"></asp:Label>
                    </asp:Panel>                
                <br />
                <div align="center">
                        <div style="border: solid 1px #999999; width: 650px">
                            <table style="text-align:center" width="649" border="0" cellpadding="0" cellspacing="0">
                                <tr class="white16b" style="background-color: #ff9900" align="center">
                                    <td class="white16b" align="center" colspan="2">
                                        Description</td>
                                    <td style="width:60px; text-align:center">
                                        Quantity</td>
                                    <td align="center" style="width:30px">
                                        Shipping</td>
                                    <td align="center" style="width:50px">
                                        Price</td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="imgItem" runat="server" ImageUrl="../images/s1x1.gif" />
                                        &nbsp;
                                    </td>
                                    <td style="border-right: solid 1px #CCCCCC; margin-left: 15px" align="left">
                                        &nbsp;
                                        <asp:Label ID="lblItemTitle" CssClass="black12b" runat="server" Visible="false"></asp:Label>
                                        <br />
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboItemList" Width="180" CssClass='dkgrey12b' runat="server" Visible="false" OnSelectedIndexChanged="SelectedIndexChanged"></asp:DropDownList>
                                        <br />                                        
                                        <asp:Label ID="lblItemDesc" CssClass="midgrey12b" runat="server"></asp:Label>
                                        <br />
                                        &nbsp;&nbsp;<asp:DropDownList ID="cboRefer" Width="160" CssClass='dkgrey12b' runat="server" Visible="false">
                                        <asp:ListItem Text="Referred by..." Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Sacred Craft" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="border-right: solid 1px #CCCCCC; height: 100px; width: 130px" align="center">
                                        <br />
                                        <asp:Label ID="lblQuantity" Width="20" CssClass="midgrey12b" runat="server" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtQuantity" Width="20" CssClass='midgrey12b' runat="server" Visible="false"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnUpdate" Text="Update" OnCommand="UpdateQuantity" Width="70" CssClass="btnDoSm"
                                            runat="server" />
                                    </td>
                                    <td style="border-right: solid 0px #CCCCCC" align="center">
                                        <asp:Label CssClass='midgrey12b' ID="lblShipping" runat="server"></asp:Label></td>
                                    <td style="border-left: solid 1px #CCCCCC" align="center">
                                        <asp:Label CssClass='midgrey12b' runat="server" ID="lblUnitPrice"></asp:Label></td>
                                </tr>
                                <tr style="background-color: #CCCCCC">
                                    <td colspan="5" align="left">
                                        &nbsp;
                                        <asp:Label CssClass="dkgrey10" ID="lblLegalStuff" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="background-color: #CCCCCC" class="dkgrey14">
                                    <td colspan="4" align="right">
                                        <b>Subtotal:</b>&nbsp;</td>
                                    <td align="right" class="dkgrey14">
                                        <asp:Label ID="lblSubTotal" runat="server"></asp:Label>&nbsp;</td>
                                </tr>
                                <tr style="background-color: #CCCCCC; height: 30px" class="dkgrey14">
                                    <td colspan="4" align="right">
                                        <b>Shipping:</b>&nbsp;</td>
                                    <td align="right" class="dkgrey14">
                                        <asp:Label ID="lblShippingAmt" runat="server"></asp:Label>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="height: 10px" align="left">
                                        &nbsp;<asp:Label ID="lblPromo" CssClass="dkorange12" runat="server" Visible="false">Promo Code:</asp:Label>
                                        <asp:TextBox ID="txtPromo" CssClass="dkgrey12" runat="server" Visible="false"></asp:TextBox>&nbsp;<asp:Button
                                            ID="btnPCode" Visible="false" runat="server" OnClick="btnPCode_Click" CssClass="btnCancel"
                                            Text="Go" />
                                    </td>
                                </tr>
                                <tr style="height: 20px">
                                    <td align="left" colspan="3" style="height: 20px">
                                        <asp:LinkButton ID="lnkBack" runat="server" Visible="false" OnClick="lnkBack_Click">&nbsp;Back to Menu</asp:LinkButton></td>
                                    <td align="right" class="dkgrey18b" style="height: 20px" nowrap>
                                        Grand Total:&nbsp;</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblTotal" CssClass="dkgrey16b"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div style="width: 650px">
                            <div style="float: left; width: 445px; border: solid 0px black" align="left">
                                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="grey_orange12u" Text="Cancel and go back"
                                    OnClick="btnCancel_Click"></asp:LinkButton>
                                <asp:Button ID="btnCancel" runat="server" CssClass="dkgrey10" Text="Go back to Menu"
                                    OnClick="btnCancel_Click" Width="100px" Visible="false" />
                            </div>
                            <div style="float: right; width: 200px; border: solid 0px red">
                                <asp:ImageButton ID="imgBtnPay" runat="server" ImageUrl="../images/PP_btn_xpressCheckout.gif" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                </div>
                <br />
                <br />
                <%-- OLD CODE--%>
                <asp:Label CssClass="dkgrey10b" runat="server" ID="lblClosing"></asp:Label>
                <asp:Label CssClass="midorange14b" runat="server" ID="lblPrice"></asp:Label>
                <asp:RadioButtonList ID="txtCCType" CssClass="midgrey12b" runat="server" Width="176px"
                    Height="40px" Visible="false">
                    <asp:ListItem Value="PP">Process with PayPal</asp:ListItem>
                    <asp:ListItem Value="CC">Process by Credit Card</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="txtOrderAmount" runat="server" Width="112px" Visible="false"></asp:TextBox>
                <%--Order Amount:--%>
                <asp:Button Visible="false" ID="btnSubmit" runat="server" CssClass="dkgrey20b" Text="Continue"
                    OnClick="btnSubmit_Click"></asp:Button>&nbsp;
                <asp:Button ID="btnSubscribe" runat="server" CssClass="midgrey10" Text="Subscribe"
                    ForeColor="Black" BackColor="#ffcc00" OnClick="btnSubscribe_Click" Visible="false" />
            </div>
            <asp:HiddenField ID="hdnDiscountAmt" Value="0" runat="server" />
            <asp:HiddenField ID="hdnInvoiceNo" Value="0" runat="server" />
            <asp:HiddenField ID="hdnTxnId" Value="0" runat="server" />
            <asp:HiddenField ID="hdnServiceName" runat="server" />
            <asp:HiddenField ID="hdnServiceVal" runat="server" />
            <asp:HiddenField ID="hdnUnitPrice" Value="0" runat="server" />
            <asp:HiddenField ID="hdnShippingPrice" Value="0" runat="server" />
            <asp:HiddenField ID="hdnUserDir" Value="0" runat="server" />
            <asp:HiddenField ID="hdnDlftQ" runat="server" />
            <asp:HiddenField ID="hdnGenData" runat="server" Value="-1" />
            <div id="push">
            </div>
        </form>
        <br />


    <div class="clearfix"></div>
    <!-- #include file="../include/footer.aspx" -->

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
