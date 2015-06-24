<%@ Page Language="C#" AutoEventWireup="true" CodeFile="preview_post.aspx.cs" Inherits="BoardHunt.Preview_post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preview Post - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>--%>

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>

    <script type="text/javascript">
        var newWin = null;
        function openIt() {
            newWin = window.open('http://www.malzook.com/login.aspx');
        }
        function closeThis() {
            window.open('Close.htm', '_self');
        }
        function doIt() {
            openIt();
            setTimeout("closeThis();", 1000);
        }
    </script>
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <!-- Theme CSS -->

</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <div id="main1">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="include/HeaderResponsive.aspx" -->
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-8 col-md-8 col-sm-10 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-6 col-sm-6 col-xs-12 text-left">
                                <span class="panel-title"><i class="fa fa-floppy-o"></i>Last Step: Approve Post</span>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12 text-right">
                                <asp:Button ID="btnEditTop" runat="server" CssClass="btn btn-warning btn-sm" Text="Edit" Visible="false" />&nbsp;&nbsp;
                       
                                <asp:Button ID="btnFinishTop" runat="server" CssClass="btn btn-success btn-sm" Text="Finish" Visible="false" />
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="text-right">
                                <span class="text-warning">Click edit for changes or finish.</span><br />
                                <span class="text-warning">Clickin' back on your browser might cause a break.</span>
                                <asp:Panel ID="pnlError" runat="server" Width="720px" Visible="false">
                                    <span class="error">Oye! Our apologies, not sure what happened.<a href="javascript:doIt()" class="text-danger fs14">Open a new browser
                                    and try again.</a></span>
                                </asp:Panel>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 border-right">
                                <asp:Panel ID="pnlDetails" runat="server">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                    <span>How does it look?</span>
                                </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12 border-right">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <div class="col-md-12 col-sm-12 col-xs-12 pn thumbnail">
                                                <asp:Image ID="Pic1" runat="server"></asp:Image>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image ID="Pic2" runat="server" CssClass="" Style="border: 1px solid #e5e5e5;" Visible="false"></asp:Image>
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image ID="Pic3" runat="server" CssClass="" Style="border: 1px solid #e5e5e5;" Visible="false"></asp:Image>
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image ID="Pic4" runat="server" CssClass="" Style="border: 1px solid #e5e5e5;" Visible="false"></asp:Image>
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image Visible="false" ID="Pic1ThmbNail" CssClass="" Style="border: 1px solid #e5e5e5;" runat="server" ImageUrl="images/s1x1.gif" />
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image Visible="false" ID="Pic2ThmbNail" CssClass="" Style="border: 1px solid #e5e5e5;" runat="server" ImageUrl="images/s1x1.gif" />
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image Visible="false" ID="Pic3ThmbNail" Style="border: 1px solid #e5e5e5;" CssClass="" runat="server" ImageUrl="images/s1x1.gif" />
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3 pn thumbnail br-n">
                                                    <asp:Image Visible="false" ID="Pic4ThmbNail" Style="border: 1px solid #e5e5e5;" CssClass="" runat="server" ImageUrl="images/s1x1.gif" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label class="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn" for="inputStandard">posted:</label>
                                            <asp:Label ID="lblDateData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10" for="inputStandard"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label class="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn" for="inputStandard">Location:</label>
                                            <asp:Label ID="lblLocation" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblGearItem" runat="server" Visible="false" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Gear item:</asp:Label>
                                            <asp:Label ID="lblGearItemData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <asp:Panel ID="pnlModel" runat="server" Visible="false">
                                            <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                                <asp:Label ID="lblModel" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Model:</asp:Label>
                                                <asp:Label ID="lblModelData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblBrand" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Shaper:</asp:Label>
                                            <asp:Label ID="lblBrandData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblBoardType" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Board type:</asp:Label>
                                            <asp:Label ID="lblBoardTypeData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblHeight" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Height:</asp:Label>
                                            <asp:Label ID="lblHeightFtData" runat="server" CssClass="col-md-1 col-sm-1 col-xs-1 field-label text-left mbn pl10"></asp:Label>
                                            <asp:Label ID="lblHeightInData" runat="server" CssClass="col-md-1 col-sm-1 col-xs-1 field-label text-left mbn"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label1" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Width:</asp:Label>
                                            <asp:Label ID="lblWidthData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label11" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Thickness:</asp:Label>
                                            <asp:Label ID="lblThick" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label2" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Tail:</asp:Label>
                                            <asp:Label ID="lblTailData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label3" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Fins:</asp:Label>
                                            <asp:Label ID="lblFinsData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <asp:Panel ID="pnlGenDims" runat="server" Visible="false">
                                            <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                                <asp:Label ID="Label6" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Dimensions:</asp:Label>
                                                <asp:Label ID="lblGenDims" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                                            <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                                <asp:Label ID="Label7" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Web:</asp:Label>
                                                <asp:Label ID="lblWeb" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label4" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">The Deal:</asp:Label>
                                            <asp:Label ID="lblDetailsData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-justify mbn pl10"></asp:Label>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="m5" />
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblPrice" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right fs20 text-warning mbn">Price:</asp:Label>
                                            <asp:Label ID="lblPriceData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left  fs20 text-warning mbn pl10"></asp:Label>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="m5" />
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label5" runat="server" CssClass="col-md-12 col-sm-12 col-xs-12 field-label text-center text-warning fs16 mbn">  Contact Info</asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label8" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">E-mail:</asp:Label>
                                            <asp:Label ID="Label9" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10">
                                                <asp:LinkButton ID="lnkEmailData" runat="server" CssClass="text-warning fs14"></asp:LinkButton>
                                            </asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="Label10" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-right mbn">Phone No:</asp:Label>
                                            <asp:Label ID="lblPhoneData" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <asp:Label ID="lblStatus" runat="server" CssClass="col-md-6 col-sm-6 col-xs-6 field-label text-left mbn pl10"></asp:Label>
                                        </div>

                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="panel-footer col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-12 col-sm-12 col-xs-12 pn text-right">
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-warning" Text="Edit" Visible="false" />&nbsp;
                           
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save Only" Visible="false" />&nbsp;
                           
                            <asp:Button ID="btnPublish" runat="server" CssClass="btn btn-success" Text="Finish" Visible="false" />
                            </div>
                            <asp:HiddenField ID="hdnProcPics" runat="server" />
                            <asp:HiddenField ID="hdnUserDir" runat="server" />
                            <asp:HiddenField ID="hdnAdType" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div align="center" style="display: none;">


                <asp:Panel runat="server" ID="pnlLocation">
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlGearItem">
                </asp:Panel>


                <asp:Panel runat="server" ID="pnlShaper">
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlBoardType">
                </asp:Panel>
                <asp:Panel ID="pnlAll" runat="server">
                    <asp:Panel ID="pnlWidth" runat="server">
                    </asp:Panel>
                    <asp:Panel ID="pnlSurfOnly" runat="server">
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlContact">
                </asp:Panel>
                <!-- problem ? -->
            </div>
        </form>
    </div>
    
    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->
    
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

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
