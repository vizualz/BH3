<%@ Page Language="C#" AutoEventWireup="false" Codebehind="OrderForm.aspx.cs" Inherits="BoardHunt.Pay.OrderForm" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html >
<html lang="en">
<head id="Head1" runat="server">
    <title>Buy - Boardhunt</title>
    <meta charset="utf-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="../style/global.css" type="text/css" rel="stylesheet" />
    <script src="../include/js/bh.js" type="text/javascript"></script>

    <!-- jQuery -->
    <script type="text/javascript" src="~/content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="~/content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>



    <!-- Font CSS (Via CDN) -->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">


    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="../content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="../content/assets/admin-tools/admin-forms/css/admin-forms.css">

    <script type="text/javascript">
    $(document).ready(function() {
    $('input.Tips').cluetip({splitTitle: '|',clickThrough:     true});
    });
    </script>

</head>
<body style="background: none repeat scroll 0 0 #fff;">

    <form class="header" id="Form1" runat="server">
        <div class="container-fluid">
        <bh:Header runat="server" />

           <div class="col-lg-12 col-md-12 col-sm-12col-xs-12">
                <div class="admin-form tab-pane active col-lg-12 col-md-12 col-sm-6 col-xs-2 style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading col-md-12 col-sm-6 col-xs-2 text-left">
                            <div class="col-lg-12 col-md-12 col-sm-6 col-xs-2 text-left">
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label><br />
                            <asp:Label ID="lblPageTitleMsg" runat="server"></asp:Label>  
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-6 col-xs-2 text-right">
                            <asp:Panel ID="pnlError" runat="server" CssClass="errorLabel" Visible="false">
                            <asp:Label ID="lblErrorMessage" runat="server" ></asp:Label>
                            </asp:Panel>  
                        </div>
                    </div>
                    <div class="panel-body p15 pt10">
                        <div class="section row">
                            <div class="col-lg-12 col-md-12 col-sm-6 col-xs-2 border-right">
                            </div>
                        </div>
                    </div>     
                    <div class="container-responsive">
                            <h2>&nbsp;Boardhunt Membership</h2>
                            <p></p>  
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Quantity</th>
                                    <th>Shipping</th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><asp:Label ID="lblItemTitle" runat="server" Visible="false"></asp:Label><br>
                                                 
                                    <asp:DropDownList ID="cboItemList" runat="server" Visible="false" OnSelectedIndexChanged="SelectedIndexChanged"></asp:DropDownList> 
                                                                       
                                    <asp:Label ID="lblItemDesc" runat="server"></asp:Label><br>
                                    <asp:Image ID="imgItem" runat="server" ImageUrl="../images/s1x1.gif" /></td>
     
                                  <!--  <td><asp:DropDownList ID="cboRefer" runat="server" 
                                        Visible="false">
                                        <asp:ListItem Text="Referred by..." Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Sacred Craft" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList></td> -->
                                    <td><asp:Label ID="lblQuantity" runat="server" Visible="false">
                                        </asp:Label>
                                        <asp:TextBox ID="txtQuantity" runat="server" Visible="false">
                                        </asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnUpdate" Text="Update" OnCommand="UpdateQuantity" CssClass="btnDoSm"
                                            runat="server" /></td>
                                    <td><asp:Label ID="lblShipping" runat="server"></asp:Label></td>
                                    <td><asp:Label runat="server" ID="lblUnitPrice"></asp:Label></td>
                                    
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblLegalStuff" runat="server"></asp:Label></td>
                                    <td><b>Subtotal:</b></td>
                                    <td><asp:Label ID="lblSubTotal" runat="server"></asp:Label>&nbsp;</td>
                                   <!-- <td><b>Shipping:</b><asp:Label ID="lblShippingAmt" runat="server"></asp:Label>&nbsp;</td> -->
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblPromo" runat="server" CssClass="fs14" Visible="false">Promo Code:
                                        </asp:Label><asp:TextBox ID="txtPromo" runat="server" Visible="false"></asp:TextBox>&nbsp;<asp:Button
                                            ID="btnPCode" Visible="false" runat="server" OnClick="btnPCode_Click" CssClass="btnCancel"
                                            Text="Go" /></td>
                                    <td><asp:LinkButton ID="lnkBack" runat="server" Visible="false" OnClick="lnkBack_Click">&nbsp;Back to Menu</asp:LinkButton></td>
                                    <td>Grand Total:</td>
                                    <td><asp:Label runat="server" ID="lblTotal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style>
                                            <div style="float: right; border: solid 0px black" align="left">
                                            &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel"
                                            OnClick="btnCancel_Click"></asp:LinkButton>
                                            <asp:Button ID="btnCancel" runat="server" Text="Go back to Menu"
                                            OnClick="btnCancel_Click" Visible="false" /> &nbsp;
                                            </div>
                                            <div style="float: right; border: solid 0px red">
                                            <asp:ImageButton ID="imgBtnPay" runat="server" ImageUrl="../images/PP_btn_xpressCheckout.gif" OnClick="btnSubmit_Click" />
                                            </div>
                                        </div>
                                    </td>   
                                </tr>     
                                
                            </tbody>
                        </table>  
                    </div>         
                </div>
            </div>        
                    
                  
                <br />
                <br />


                <%-- OLD CODE--%>
                <asp:Label CssClass="dkgrey10b" runat="server" ID="lblClosing"></asp:Label>
                <asp:Label CssClass="midorange14b" runat="server" ID="lblPrice"></asp:Label>
                <asp:RadioButtonList ID="txtCCType" CssClass="midgrey12b" runat="server" 
                    Height="40px" Visible="false">
                    <asp:ListItem Value="PP">Process with PayPal</asp:ListItem>
                    <asp:ListItem Value="CC">Process by Credit Card</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="txtOrderAmount" runat="server" Visible="false"></asp:TextBox>
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
            </div>
        </form>
        <br />


    <div class="clearfix"></div>
    <!-- #include file="../include/footer.aspx" -->

    <!-- Bootstrap -->
    <script type="text/javascript" src="../content/assets/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->

    <!-- Theme Javascript -->
    <script type="text/javascript" src="../content/assets/js/utility/utility.js"></script>
    <script type="text/javascript" src="../content/assets/js/main.js"></script>
    <script type="text/javascript" src="../content/assets/js/demo.js"></script>

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

