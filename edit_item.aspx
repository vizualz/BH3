<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_item.aspx.cs" Inherits="BoardHunt.edit_item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Post | Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" src="include/js/bh.js"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false&amp;libraries=places" type="text/javascript"></script>
    <script type="text/javascript">
        function initialize() {
            var input = document.getElementById('txtTown');
            var autocomplete = new google.maps.places.Autocomplete(input);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>--%>

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js" type="text/javascript"></script>
    <script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.1.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });


            $(function () {
                var availableTags = ["Channel Islands", "Rusty", "Lost", "Bissell", "Linden", "FCD", "HIC", "Chemistry", "Xanadu", "3rd World Exotic", "Hynson", "SharpEye", "Becker", "Chili", "Firewire", "Kane Garden", "Santa Cruz", "WRV", "Quiet Flight", "Surf Prescriptions", "SurfTech", "Tequoph", "MR", "Weber", "Rickland", "West", "Resist", "KookBox"];
                $("#txtBrand").autocomplete({
                    source: availableTags, minLength: 2
                });
            });

            $("#txtBrand").bind("autocompleteclose", function (event, ui) {
                ctl = document.getElementById("txtBrand");
                ctl2 = document.getElementById("txtShaper");
                switch (ctl.value) {
                    case "Channel Islands":
                        ctl2.value = "Al Merrick";
                        break;
                    case "Rusty":
                        ctl2.value = "Rusty Rusty Preisendorfer";
                        break;
                    case "Lost":
                        ctl2.value = "Matt Biolos";
                        break;
                    case "FCD":
                        ctl2.value = "Fletcher Chouinard";
                        break;
                    case "Surf Prescriptions":
                        ctl2.value = "Doc Lausch";
                        break;
                    case "Linden":
                        ctl2.value = "Gary Linden";
                        break;
                    case "Hynson":
                        ctl2.value = "Mike Hynson";
                        break;
                    case "3rd World Exotic":
                        ctl2.value = "Larry Mabile";
                        break;
                    case "Tequoph":
                        ctl2.value = "Bill Johnson";
                        break;

                    default:
                        break;
                }
            });


        });
    </script>
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <link href="content/vendor/plugins/dropzone/css/dropzone.css" rel="stylesheet" />
    <script src="content/vendor/plugins/dropzone/dropzone.min.js"></script>
</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <div id="main1">
        <form class="header" id="Form1" runat="server">
            <!-- #include file="include/HeaderResponsive.aspx" -->
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-6 col-md-6 col-sm-12 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="col-md-12 col-sm-12 col-xs-12 text-left pn">
                        <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="text-warning fs16 fw600">MENU</asp:HyperLink>&nbsp;&gt;&nbsp;
                    <asp:HyperLink runat="server" ID="lnkManage" NavigateUrl="post_manager.aspx" CssClass="text-warning fs16 fw600">MANAGE</asp:HyperLink>&nbsp;
                    <asp:Label ID="lblPageTitle" CssClass="text-warning fs16 fw600" runat="server">&gt;&nbsp;EDIT</asp:Label>
                    </div>
                    <div class="panel panel-warning heading-border col-lg-12 col-md-12 col-sm-12 col-xs-12 pn mt20">
                        <div class="panel-heading">
                            <div class="col-md-6 col-sm-6 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-pencil"></i>Edit and click "update"</span>
                            </div>
                            <asp:Panel ID="pnlSold" runat="server" Visible="true">
                                <div class="col-md-1 colsm-1 col-xs-1">
                                    <h2 class="mtn">OR</h2>
                                </div>
                                <div class="col-md-5 col-sm-5 col-xs-5 text-right">
                                    <asp:Button runat="server" ID="btnBoost" Text="Boost" CssClass="btn btn-success btn-sm" OnClick="btnBoost_Click" />&nbsp;
                                    <asp:Button runat="server" ID="btnSold" Text="Sold it!" OnClick="btnSold_Click" class="btn btn-warning btn-sm" />
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="panel-body p15 mt10">
                            <asp:Panel ID="pnlAll" runat="server">
                                <div class="text-right">
                                    <span class="text-danger fs14">* required in bold
                                    </span>
                                </div>
                                <asp:Panel ID="pnlLocation" runat="server">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10 mt10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn fw600" for="inputStandard">
                                           <strong class="text-danger">*</strong> Location
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-6 col-sm-6 col-xs-6 pn">
                                                <label class="field select">
                                                    <asp:DropDownList ID="cboRegion" runat="server"
                                                        TabIndex="1">
                                                    </asp:DropDownList>
                                                    <i class="arrow double"></i>
                                                </label>
                                            </div>
                                            <div class="col-md-5 col-sm-5 col-xs-5">
                                                <asp:TextBox ID="txtTown" runat="server" ClientIDMode="Static" type="text" size="50" TabIndex="2" CssClass="gui-input" placeholder="" autocomplete="on" />
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                <span>(city)</span>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlBoardType" runat="server">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn fw600" for="inputStandard">
                                           <strong class="text-danger">*</strong>   Board type
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-6 col-sm-6 col-xs-6 pn">
                                                <label class="field select">
                                                    <asp:DropDownList ID="cboBoardType" runat="server"
                                                        TabIndex="3">
                                                    </asp:DropDownList>
                                                    <i class="arrow double"></i>
                                                </label>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-6 pn">
                                                <asp:CheckBox ID="chkOther" runat="server" onclick="ToggleBT()"
                                                    Text="Other" TabIndex="4" Visible="false" />
                                                <asp:TextBox ID="txtOtherBoard" runat="server" CssClass="gui-input" TabIndex="5"
                                                    Visible="false"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Item
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txtGearItem" CssClass="gui-input" runat="server" Visible="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlBrand" runat="server">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn fw600" for="inputStandard">
                                            <strong class="text-danger">*</strong>  Brand
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-8 col-sm-8 col-xs-8 pn">
                                                <asp:TextBox ID="txtBrand" runat="server" CssClass="gui-input" TabIndex="4"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="!" OnServerValidate="CheckBrand"
                                                    CssClass="error"></asp:CustomValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Shaper
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-8 col-sm-8 col-xs-8 pn">
                                                <asp:TextBox ID="txtShaper" runat="server" CssClass="gui-input" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlModel" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Model
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-8 col-sm-8 col-xs-8 pn">
                                                <asp:TextBox ID="txtModel" runat="server" CssClass="gui-input" TabIndex="4"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlHeight" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Height
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtHtFt" runat="server" CssClass="gui-input" TabIndex="6"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:Label ID="lblFtHt" runat="server">ft</asp:Label>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtHtIn" runat="server" CssClass="gui-input" TabIndex="7"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:Label ID="lblFtIn" runat="server">in</asp:Label>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="!" Font-Bold="True" CssClass="error"
                                                    OnServerValidate="CheckHeight"></asp:CustomValidator>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlSurfOnly" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Width
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtWidth" runat="server" CssClass="gui-input" TabIndex="8"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <span>and</span>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtWidthNum" runat="server" CssClass="gui-input" TabIndex="9"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                <span>/</span>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtWidthDNum" runat="server" CssClass="gui-input" TabIndex="10"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                in&nbsp;<asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="!" CssClass="error" Font-Bold="True"
                                                    OnServerValidate="CheckWidth"></asp:CustomValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                            Thickness
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtThick" runat="server" CssClass="gui-input" TabIndex="11"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <span>and</span>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtThickNum" runat="server" CssClass="gui-input" TabIndex="12"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                <span>/</span>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                                <asp:TextBox ID="txtThickDNum" runat="server" CssClass="gui-input" TabIndex="13"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                                in&nbsp;<asp:CustomValidator ID="CustomValidator9" runat="server" CssClass="error" ErrorMessage="!" Font-Bold="True"
                                                    OnServerValidate="CheckThickness"></asp:CustomValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Tail</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <label class="field select">
                                                <asp:DropDownList ID="cboTailType" runat="server" TabIndex="5"></asp:DropDownList>
                                                <i class="arrow double"></i>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Fins</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <label class="field select">
                                                <asp:DropDownList ID="cboFins" runat="server" TabIndex="15">
                                                </asp:DropDownList>
                                                <i class="arrow double"></i>
                                            </label>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlGenDims" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <asp:Label ID="lblGenDims" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"> Dimensions</asp:Label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txtGenDims" CssClass="gui-input" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                    <asp:Label ID="Label1" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn fw600" for="inputStandard"> <strong class="text-danger">*</strong>  Price</asp:Label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <div class="col-md-10 col-sm-10 col-xs-10 pn">
                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="gui-input" TabIndex="15"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                            <span>$ (USD)</span>
                                            <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="!" Font-Bold="True" CssClass="error"
                                                OnServerValidate="CheckPrice"></asp:CustomValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                    <asp:Label ID="lblShipping" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"> Shipping</asp:Label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <div class="radio-custom mb5 pt10 text-left">
                                            <asp:RadioButtonList ID="rdoShip" runat="server" RepeatLayout="Flow"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Text="No">No&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes">Yes</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                    <asp:Label ID="Label2" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"> The Deal</asp:Label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <label class="field" for="comment">
                                            <asp:TextBox ID="txtDetails" runat="server" CssClass="gui-textarea" Rows="10" MaxLength="599" onkeydown="count()" TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                                            <span class="input-footer text-justify">
                                                <strong>DO:</strong>
                                                (600 max; no HTML)
                                            </span>
                                        </label>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlVideo" runat="server" Visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                        <asp:Label ID="Label3" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"> Video Clip</asp:Label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txtVideo" runat="server" CssClass="gui-input"
                                                MaxLength="599" Rows="5" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <hr />
                                <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                    <asp:Label ID="Label4" runat="server" class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Add/edit photos</asp:Label>
                                    <div class="col-md-9 col-sm-9 col-xs-12 text-left pt10">
                                        <span class="text-warning  fs14"><strong>2MB</strong> &nbsp;max per JPG or GIF</span>&nbsp;&nbsp;
                                        <asp:Button ID="btnShowPnl" class="btn btn-warning btn-sm" runat="server" Text="Edit Images..." Visible="False" TabIndex="16" OnClick="btnShowPnl_Click"></asp:Button>

                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                                    <asp:Label ID="lblStatus" runat="server" CssClass="header"></asp:Label>
                                </div>
                                <asp:Panel ID="pnlAddImages" runat="server">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pb10">
                                        <div class="tray-bin pl10 mb10 text-left" style="min-height: 250px;">
                                            <div id="dropZonefrm" class="dropzone">
                                                <div class="fallback">
                                                    <input id="File5" name="file" type="file" multiple="multiple" runat="server" />
                                                    <asp:Label ID="lblFallbackMessage" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                        <div class="panel-footer">
                            <div class="text-right pr10 ">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" TabIndex="21" />
                                <asp:Button ID="btnFinish" runat="server" CssClass="btn btn-success" Text="Save" TabIndex="22" />
                            </div>
                            <div>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                <input type="hidden" runat="server" id="DeletedImageUrls" />

                                <asp:Label ID="lbl2" runat="server" CssClass="header"></asp:Label>
                                <asp:HiddenField ID="hdnActCode" runat="server" />
                                <asp:HiddenField ID="hdnEntryId" runat="server" />
                                <asp:HiddenField ID="hdnPrice" runat="server" />
                                <asp:HiddenField ID="hdnEntryType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>
            <div align="center" style="display: none;">

                <table>
                    <tr>
                        <td style="width: 128px"></td>
                        <td style="width: 482px">
                            <asp:Panel ID="panelimg" runat="server" Height="" Width="352px" Visible="False"
                                BorderColor="#ff9900" BorderStyle="Solid" BorderWidth="0" BackColor="#ff9900">
                                <table style="z-index: 115; width: 288px; height: 52px" align="left" bgcolor="#FFFFFF"
                                    bordercolor="#ff9900" border="0">
                                    <tr>
                                        <td style="width: 120px">&nbsp;
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
                                        <td>&nbsp;</td>
                                        <td style="width: 120px">&nbsp;
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
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File2" type="file" name="File2" runat="server">
                                            <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">&nbsp;
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
                                        <td>&nbsp;</td>
                                        <td style="width: 120px">&nbsp;
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
                                            <input class="dkgrey10b" id="File3" type="file" name="File1" runat="server">
                                            <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="!" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td colspan="2">
                                            <input class="dkgrey10b" id="File4" type="file" name="File2" runat="server">
                                            <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="!" CssClass="error" Font-Bold="True"
                                                OnServerValidate="CheckFileType"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
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

            //$('#divServer').append('<form id="dropZonefrm" class="dropzone" action=""><div class="fallback"><input name="file" type="file" multiple /></div></form>');
        });

        var myDropzone = '';

        $(document).ready(function () {
            Dropzone.autoDiscover = false;
            myDropzone = new Dropzone('#dropZonefrm', {
                paramName: 'files',
                autoProcessQueue: true,
                uploadMultiple: true,
                parallelUploads: 25,
                maxFiles: 3,
                maxFilesize: 2.0,
                addRemoveLinks: true,
                acceptedFiles: ".jpg,.gif,.jpeg,.bmp,.png",
                url: "http://localhost/mz/edit_item.aspx?name=deepak",
                init: function () {
                    var myDropzone = this;

                    //Populate any existing thumbnails
                    var thumbnailUrls = [];

                    if (document.getElementById("HiddenField1").value != '') {
                        thumbnailUrls[0] = document.getElementById("HiddenField1").value;
                    }

                    if (document.getElementById("HiddenField2").value != '') {
                        thumbnailUrls[1] = document.getElementById("HiddenField2").value;
                    }

                    if (document.getElementById("HiddenField3").value != '') {
                        thumbnailUrls[2] = document.getElementById("HiddenField3").value;
                    }
                    if (document.getElementById("HiddenField4").value != '') {
                        thumbnailUrls[3] = document.getElementById("HiddenField4").value;
                    }

                    try {
                        if (thumbnailUrls) {
                            for (var i = 0; i < thumbnailUrls.length; i++) {
                                if (thumbnailUrls[i] != undefined) {
                                    var mockFile = {
                                        name: "myimage.jpg",
                                        size: 12345,
                                        type: 'image/jpeg',
                                        status: Dropzone.ADDED,
                                        url: thumbnailUrls[i]
                                    };

                                    // Call the default addedfile event handler
                                    myDropzone.emit("addedfile", mockFile);

                                    // And optionally show the thumbnail of the file:
                                    myDropzone.emit("thumbnail", mockFile, thumbnailUrls[i]);

                                    myDropzone.files.push(mockFile);
                                }
                            }
                        }
                    } catch (e) { }
                    this.on("removedfile", function (file) {
                        // Only files that have been programmatically added should
                        if (file.url && file.url.trim().length > 0) {
                            if ($("#DeletedImageUrls").val() != '') {
                                $("#DeletedImageUrls").val($("#DeletedImageUrls").val() + ',' + file.url);
                            }
                            else {
                                $("#DeletedImageUrls").val(file.url);
                            }
                        }
                    });
                }
            });
        });

        $('#btnFinish').click(function () {
            // then on upload button clicked:
            myDropzone.processQueue();

        });
    </script>
</body>
</html>
