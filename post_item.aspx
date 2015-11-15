<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post_item.aspx.cs" Inherits="BoardHunt.post_item" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Post Item - Boardhunt</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="style/popup.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css"
        type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css"
        type="text/css" media="all" />

    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js"
        type="text/javascript"></script>

    <script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.2.js"
        type="text/javascript"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js"
        type="text/javascript"></script>


    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>

    <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });

            //$('img.Tips').cluetip({splitTitle: '|'});
            $('img.Tips').cluetip({ width: 300 });

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
                        ctl2.value = "Rusty Preisendorfer";
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

            //hide button on wanted ad
            var ctl1 = document.getElementById('hdnAdType');
            if (ctl1.value == "2") {
                var btn = document.getElementById('btnShowImgPanel');
                btn.style.display = 'none';
            }


            var ctl2 = document.getElementById('File4');
            if (ctl2 != null) {
                ctl2.style.display = 'none';
            }

        });
    </script>

    <script language="JavaScript">
        function FreezeScreen(msg) {
            scroll(0, 0);
            var outerPane = document.getElementById('FreezePane');
            var innerPane = document.getElementById('InnerFreezePane');
            if (outerPane) outerPane.className = 'FreezePaneOn';
            if (innerPane) innerPane.innerHTML += msg;
        }
    </script>

    <script type="text/javascript">
        var newWin = null;
        function openIt() {
            newWin = window.open('http://www.boardhunt.com/login.aspx');
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

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <link href="content/vendor/plugins/dropzone/css/dropzone.css" rel="stylesheet" />
    <script src="content/vendor/plugins/dropzone/dropzone.min.js"></script>
</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <div id="main1">
        <form runat="server" class="header" id="Form1">
            <bh:Header runat="server" />

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="admin-form tab-pane active col-lg-6 col-md-6 col-sm-12 col-xs-12" style="float: none; margin: 0 auto;">

                    <div class="panel panel-warning heading-border col-lg-12 col-md-12 col-sm-12 col-xs-12 pn mt20">
                        <div class="panel-heading">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                                <span class="panel-title"><i class="fa fa-puzzle-piece"></i>Create Surfboard</span>
                            </div>
                        </div>
                        <div class="panel-body p15 mt10">
                            <div class="text-center">
                                <span style="color: #ff9900;" class="fw600">
                                    <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="post.aspx" Style="color: #ff9900;" CssClass="fw600 fs14">Step 1 of 3: General Info</asp:HyperLink>
                                    &gt; Step 2 of 3: 
                                    <asp:Label runat="server" ID="lblCat"></asp:Label>
                                    Details
                                </span>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                <span>No need to repost on Boardhunt with our search power.</span>
                                <asp:Label ID="lblInstructions" runat="server" CssClass="white16" Visible="false">&nbsp;&nbsp;</asp:Label>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pn text-left pb10">
                                <span class="fw600 fs15">This section is required.</span>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 mb15">
                                <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">
                                    Board Type
                                    &nbsp;
                                    <img src="images/help.gif" class="Tips" align="middle" id="imgBTHelp" rel="help/help.aspx?val=1"
                                        title="Board Types" />
                                </label>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <label class="field select">
                                        <asp:DropDownList ID="cboBoardType" runat="server" TabIndex="1">
                                        </asp:DropDownList>
                                        <i class="arrow double"></i>
                                    </label>
                                    <div>
                                        <asp:CheckBox ID="chkOther" Text="&nbsp;Or other" runat="server" onClick="ToggleBT();"
                                            CssClass="dkrgrey16" Checked="false" Visible="false" TabIndex="2" />
                                        <asp:TextBox ID="txtOtherBoard" runat="server" Width="100px" Visible="false" CssClass="dkgrey16"
                                            ToolTip="Type in your board type" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"><strong class="text-danger">*</strong> Height</label>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <div class="col-md-3 col-sm-3 col-xs-4 pn">
                                        <asp:TextBox ID="txtHtFt" runat="server" CssClass="gui-input" MaxLength="2"
                                            TabIndex="5"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                        <asp:Label ID="lblHtFt" runat="server">ft</asp:Label>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-4 pn">
                                        <asp:TextBox ID="txtHtIn" runat="server" CssClass="gui-input" MaxLength="2"
                                            TabIndex="6"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-3  text-left">
                                        <asp:Label ID="lblHtIn" runat="server">in</asp:Label>
                                    </div>
                                    <div class=" col-md-12 col-sm-12 col-xs-12 pn text-left">
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="error" OnServerValidate="CheckHeight"
                                            ErrorMessage="!"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard"><strong class="text-danger">*</strong>  Price</label>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <div class="col-md-4 col-sm-4 col-xs-4 pn">
                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="gui-input" MaxLength="8"
                                            TabIndex="8"></asp:TextBox>
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-8 text-left">
                                        <small>
                                            <asp:Label ID="lblPriceDir" runat="server">
                                         ($ USD) You can edit this later.
                                            </asp:Label></small>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn text-left">
                                        <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="error" OnServerValidate="CheckPrice"
                                            ErrorMessage="!"></asp:CustomValidator>&nbsp;
                                    </div>
                                </div>
                            </div>
                        <div class="clearfix"></div>
                        <hr />
                        <div class="col-md-12 col-sm-12 col-xs-12 pn text-left pb10">
                            <span class="fw600 fs15">This section is optional, but highly recommended to enable all search features.</span>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Brand</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="gui-input" TabIndex="10"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Shaper</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <asp:TextBox ID="txtShaper" runat="server" CssClass="gui-input" TabIndex="11"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="error" Visible="false" OnServerValidate="CheckBrand"
                                    ErrorMessage="!"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Model</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <asp:TextBox ID="txtModelPost" runat="server" CssClass="gui-input" TabIndex="12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Width</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtWidth" runat="server" CssClass="gui-input" MaxLength="2"
                                        TabIndex="15"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-1 col-xs-2 pn">
                                    <span>And</span>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtWidthNum" runat="server" CssClass="gui-input" MaxLength="1"
                                        TabIndex="16"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                    <span>/</span>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtWidthDNum" runat="server" CssClass="gui-input" MaxLength="2"
                                        TabIndex="17"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-3  text-left">
                                    <small>&nbsp;in&nbsp;</small><div class="clearfix">(ex: 18 and 1/4)</div>

                                    <asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="error" OnServerValidate="CheckWidth"
                                        ErrorMessage="!"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Thickness</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtThick" runat="server" CssClass="gui-input" MaxLength="1"
                                        TabIndex="18"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-1 col-xs-2 pn">
                                    <span>And</span>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtThickNum" runat="server" CssClass="gui-input" MaxLength="1"
                                        TabIndex="19"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-1 col-xs-1 pn">
                                    <span>/</span>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-2 pn">
                                    <asp:TextBox ID="txtThickDNum" runat="server" CssClass="gui-input" MaxLength="2"
                                        TabIndex="20"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-3  text-left">
                                    <small>&nbsp;in&nbsp;</small><div class="clearfix">(ex: 2 and 1/4)</div>

                                    <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="errorLabel" OnServerValidate="CheckThickness"
                                        ErrorMessage="!"></asp:CustomValidator>&nbsp;<span class="help"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">Fins</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <label class="field select">
                                    <asp:DropDownList ID="cboFins" runat="server" TabIndex="22">
                                    </asp:DropDownList>
                                    <i class="arrow double"></i>
                                </label>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <asp:Label CssClass="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard" ID="lblTail" runat="server">Tail
                                   &nbsp; <img src="images/help.gif" class="Tips" align="middle" id="imgFinHelp" rel="help/help.aspx?val=4"
                                    title="Tail Types" />
                            </asp:Label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <label class="field select">
                                    <asp:DropDownList ID="cboTailType" runat="server" TabIndex="23">
                                    </asp:DropDownList>
                                    <i class="arrow double"></i>
                                </label>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 mb10">
                            <label class="col-md-3 col-sm-3 col-xs-12 field-label text-left mbn" for="inputStandard">The Deal</label>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <label class="field" for="comment">
                                    <asp:TextBox ID="txtDetails" onkeydown="CountChars()" runat="server" CssClass="gui-textarea"
                                        MaxLength="599" placeholder="Your comment" Rows="10" TextMode="MultiLine" TabIndex="30"></asp:TextBox>
                                    <span class="input-footer text-justify">
                                        <strong>DO:</strong>
                                        <asp:Label ID="lblDetailTxt" runat="server">
                                        How does it ride?,   &nbsp;&nbsp; Describe any dings.,&nbsp;&nbsp;Ideal height and weight?,&nbsp;&nbsp;
                                        Where should it be ridden?,&nbsp;&nbsp;How much did you pay?,&nbsp;&nbsp;What is it made of?,&nbsp;&nbsp;
                                        Why selling?
                                        </asp:Label>
                                    </span>
                                </label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr />
                        <div class="col-md-12 col-sm-12 col-xs-12 pn text-left pb10">
                            <div>
                                <span class="fw600 fs15">Add images and wait for the <span class="text-success">green checkbox</span>. Then hit Next. (Max 3 Images)</span>
                            </div>
                            <div>
                                <small><strong>3MB limit per file</strong>, GIF or JPG only. A <span class="text-danger">red X</span> means file was too big.</small>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 pn text-left pb10">
                            <div class="tray-bin pl10 mb10" style="min-height: 250px;">
                                <div id="divServer" runat="server">
                                    <div id="dropZonefrm" class="dropzone">
                                        <div class="fallback">
                                            <input name="file" type="file" multiple="multiple" runat="server" accept="image/*" capture="camera" />
                                            <asp:Label ID="lblFallbackMessage" runat="server" />
                                            <input name="btnUpload" type="submit" title="Upload" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="panel-footer col-md-12 col-sm-12 col-xs-12">
                            <div class="pull-right">
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default"
                                    Text="< Back" TabIndex="40"></asp:Button>
                                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning"
                                    Text="Next >" TabIndex="42"
                                    OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('btnNext','lbl2');javascript:ShowElement('btnNextFake','btnNext');javascript:DisableElement('btnNextFake');javascript:DisableElement('btnBack');"></asp:Button>
                                <asp:HiddenField ID="hdnAdType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div style="display: none;">
                <asp:Panel ID="pnlError" runat="server" Visible="false" Style="width: 400px; margin: 0px auto; border-style: dashed; border-width: 1px; border-color: red;">
                    <div align="center" style="background-color: #ffE4E1; margin: 0px auto;">
                        <img src="images/red_err_excl.png" border="0" alt="" style="margin-top: 1px" align="middle" />&nbsp;
                                   
                    <asp:Label runat="server" ID="lblErrMsg" CssClass="black16b" Visible="false">
                                    &nbsp;Hated! Something broke. Make sure EACH image is under 1MB and try 
                                    again. &nbsp;<br />                                    
                    </asp:Label>
                        <asp:HyperLink ID="hypClose" onClick="javascript:doIt()" runat="server" CssClass="red_black12">Click here to close this 
                                    browser and try again.</asp:HyperLink>
                        &nbsp;
                       
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlItem" runat="server" BorderColor="#CCCCCC" BorderWidth="0px" BorderStyle="solid" Style="margin: 0px auto;">
                    <table align="center" cellspacing="0" cellpadding="0" width="820" border="0" bgcolor="#F0F0F0" style="margin: 0px auto;">
                        <tr>
                            <td height="2" colspan="2" bgcolor="#CCCCCC">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="white16" align="center" style="height: 30px; background-color: #CCCCCC">No need to repost on Boardhunt with our search power.
                                   
                           
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#CCCCCC" colspan="2" style="height: 5px">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td bgcolor="#cccccc" colspan="2" style="height: 20px">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <tr>
                            <td bgcolor="#cccccc" align="left" colspan="2" height="20" class="black16b">&nbsp;&nbsp;</td>

                        </tr>
                        <tr>
                            <td bgcolor="#cccccc" height="10" colspan="2">
                                <img src="images/s1x1.gif"></td>
                        </tr>

                        <asp:Panel ID="pnlModel" runat="server" Visible="false">
                            <tr>
                                <td bgcolor="#cccccc" class="dkgrey16b" align="right" style="width: 150px">
                                    <span class="midorange10b">*</span>Model name:&nbsp;</td>
                                <td bgcolor="#cccccc" align="left">
                                    <asp:TextBox ID="txtModel" runat="server" Width="132px" CssClass="dkgrey16" ToolTip="Type in the model"
                                        TabIndex="15"></asp:TextBox>
                                </td>
                            </tr>

                        </asp:Panel>
                        <asp:Panel ID="pnlBoardType" runat="server">
                            <tr>
                                <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">Board type:&nbsp;</td>
                                <td bgcolor="#cccccc" align="left">&nbsp;&nbsp;&nbsp;
                                       
                               

                                <%--<asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="images/help.gif" CausesValidation="false"
                                            ImageAlign="AbsMiddle" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#cccccc" height="5" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlGearItem" runat="server" Visible="false">
                            <tr>
                                <td bgcolor="#cccccc" align="right" style="width: 150px;">
                                    <asp:Label CssClass="dkgrey16" ID="lblItem" runat="server">
                                    Item:&nbsp;
                                    </asp:Label>
                                </td>
                                <td bgcolor="#cccccc" align="left">
                                    <asp:TextBox ID="txtGearItem" CssClass="dkgrey16" Width="136px" runat="server" Visible="true"
                                        TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#cccccc" colspan="2">
                                    <img height="5" src="images/s1x1.gif" /></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlBrand" runat="server">
                        </asp:Panel>
                        <asp:Panel ID="pnlHeight" runat="server">
                            <tr>
                                <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">Height:&nbsp;</td>
                                <td bgcolor="#cccccc" class="dkgrey16" align="left"></td>

                            </tr>
                            <tr>
                                <td bgcolor="#cccccc" height="5" colspan="2">
                                    <img src="images/s1x1.gif" /></td>
                            </tr>
                        </asp:Panel>
                        <tr>

                            <td bgcolor="#cccccc" class="dkgrey16" align="right" style="width: 150px">Price:&nbsp;</td>
                            <td bgcolor="#cccccc" align="left">
                                <%-- <asp:TextBox Style="margin-bottom: 2px;" ID="txtPrice" runat="server" CssClass="dkrgrey16" Width="64px" MaxLength="8"
                        TabIndex="8"></asp:TextBox>&nbsp;<asp:Label ID="lblPriceDir" runat="server" CssClass="white14">
                                         ($ USD) You can edit this later.
                        </asp:Label>

                    <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="errorLabel" OnServerValidate="CheckPrice"
                        ErrorMessage="!"></asp:CustomValidator>&nbsp;--%></td>
                        </tr>
                        <asp:Panel ID="pnlSurfOnly" runat="server">
                            <tr>
                                <td bgcolor="#cccccc" height="20" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td height="10" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" height="20" class="black16b">&nbsp;&nbsp;This section is optional, but highly recommended to enable all search features.</td>

                            </tr>
                            <tr>
                                <td height="10" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td class="dkgrey16" align="right" style="width: 150px">
                                    <asp:Label ID="lblBrand" runat="server">Brand:</asp:Label>&nbsp;
                                </td>
                                <td class="dkgrey16" align="left">&nbsp;&nbsp;&nbsp;
                                       
                                <asp:Label ID="lblShaper" CssClass="dkgrey16" runat="server">Shaper:</asp:Label>
                                    &nbsp;
                                       
                               
                        &nbsp;
                                           
                                <asp:Label ID="lblModelPost" runat="server" CssClass="dkgrey16">Model: </asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>



                            <tr>
                                <td class="dkgrey16" align="right" style="width: 150px">Width:&nbsp;</td>
                                <td class="dkgrey16" align="left"></td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2" style="width: 132px">
                                    <img src="images/s1x1.gif" alt="" /></td>
                            </tr>
                            <tr>
                                <td class="dkgrey16" align="right" style="width: 150px">Thickness:&nbsp;</td>
                                <td class="dkgrey16" align="left"></td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td class="dkgrey16" valign="top" align="right" style="width: 150px">
                                    <asp:Label ID="lblFins" runat="server">Fins:&nbsp;</asp:Label>
                                </td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                            <tr>
                                <td class="dkgrey16" align="right" style="width: 150px">
                                    <asp:Label ID="lblerere" runat="server">Tail:&nbsp;</asp:Label></td>
                                <td align="left">


                                    <%--<asp:ImageButton ID="imgBtnFinHelp" CausesValidation="false" runat="server" ImageUrl="images/help.gif"
                                            ImageAlign="AbsMiddle" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="5">
                                    <img src="images/s1x1.gif"></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlGenDims" runat="server">
                            <tr>
                                <td valign="top" align="right" style="width: 150px">
                                    <asp:Label ID="lblGenDims" CssClass="dkgrey16" runat="server">Dimensions:</asp:Label>
                                    &nbsp;
                                </td>
                                <td valign="top" align="left">
                                    <asp:TextBox ID="txtGenDims" CssClass="dkrgrey16" runat="server" TabIndex="24" Width="132"></asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>


                        <tr>
                            <td height="5" colspan="2">
                                <img src="images/s1x1.gif" /></td>
                        </tr>
                        <asp:Panel ID="pnlWeb" runat="server" Visible="false">
                            <tr>
                                <td valign="top" align="right" style="width: 150px">
                                    <asp:Label ID="lblWeb" CssClass="dkgrey16b" runat="server">Web:</asp:Label>&nbsp;
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtWebURL" CssClass="dkrgrey16" runat="server" TabIndex="25"></asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td class="dkgrey16" valign="top" align="right" style="width: 150px; border-right: solid 5px transparent;">The deal:&nbsp;<br />

                            </td>
                            <td align="left" valign="top" style="width: 482px" class="midorange16">

                                <asp:Label ID="lblTxtCount" runat="server">600</asp:Label>
                                <br />



                            </td>
                        </tr>
                        <tr>
                            <td height="40" colspan="2">
                                <img src="images/s1x1.gif"></td>
                        </tr>
                        <asp:Panel ID="pnlVideo" runat="server" Visible="false">
                            <tr>
                                <td class="dkgrey16" align="right" style="width: 150px">Video Clip:&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVideo" runat="server" CssClass="dkgrey10" Height="60px" Width="352px"
                                        MaxLength="599" Rows="5" TextMode="MultiLine" TabIndex="32"></asp:TextBox>
                                    <span class="midorange10b"><b>Cut and paste a URL link from YouTube</b>&nbsp;&nbsp;</span>
                                </td>
                            </tr>
                            <tr>
                                <td height="10" colspan="2">
                                    <img src="images/s1x1.gif">
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td bgcolor="#CCCCCC" align="right" style="height: 30px; width: 150px;"></td>
                            <td align="left" style="height: 30px; width: 482px;" bgcolor="#CCCCCC"></td>
                                <tr>
                                    <td bgcolor="#CCCCCC" align="left" colspan="2" height="20" class="black16b">&nbsp;&nbsp;Add images, or buyers may skip over your post.</td>

                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC" colspan="2">
                                        <%--<input type="button" valign="center" id="btnShowImgPanel" class="dkorange20b" value="Add Images..." onclick="toggleImgPanel('pnlAddImages', 'btnShowImgPanel')" />--%>

                                        <asp:Label CssClass="white14" ID="lblImgTip" runat="server" Width="100%"> 
                                                  &nbsp;&nbsp;1MB limit per file, GIF or JPG only. If post breaks, it's probably too big.</asp:Label>
                                    </td>
                                </tr>



                                <tr>
                                    <td bgcolor="#CCCCCC" height="20" colspan="2">
                                        <img src="images/s1x1.gif"></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC">&nbsp;
                                    </td>
                                    <td bgcolor="#CCCCCC" style="width: 482px" align="left">
                                        <asp:Panel ID="pnlAddImages" runat="server" Height="" Width="352px" Visible="True"
                                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1"
                                            BackColor="#CCCCCC">
                                            <table style="z-index: 115; width: 288px; height: 52px" align="left" bgcolor="#FFFFFF"
                                                bordercolor="#CCCCCC" border="0">
                                                <tr>
                                                    <td style="width: 120px">&nbsp;
                                                   
                                                    <asp:Image ID="img1" runat="server" Height="100px" Width="100px"></asp:Image>
                                                    </td>
                                                    <td valign="bottom">
                                                        <asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('1')"
                                                            TabIndex="35">
                                                            <asp:ListItem Value="Keep" Selected="True" />
                                                            <asp:ListItem Value="Delete" />
                                                            <asp:ListItem Value="Change" />
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="width: 120px">&nbsp;
                                                   
                                                    <asp:Image ID="img2" runat="server" Height="100px" Width="100px"></asp:Image>
                                                    </td>
                                                    <td valign="bottom" style="width: 85px">
                                                        <asp:RadioButtonList ID="rdoImgMgr2" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('2')"
                                                            TabIndex="36">
                                                            <asp:ListItem Value="Keep" Selected="True" />
                                                            <asp:ListItem Value="Delete" />
                                                            <asp:ListItem Value="Change" />
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <input class="dkrgrey12" id="File1" type="file" name="File1" runat="server"
                                                            onchange="swapImg('1')">
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        <input class="dkrgrey12" id="File2" type="file" name="File2" runat="server"
                                                            onchange="swapImg('2')">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 120px">&nbsp;
                                                   
                                                    <asp:Image ID="img3" runat="server" Height="100px" Width="100px"></asp:Image>
                                                    </td>
                                                    <td valign="bottom">
                                                        <asp:RadioButtonList ID="rdoImgMgr3" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('3')"
                                                            TabIndex="37">
                                                            <asp:ListItem Value="Keep" Selected="True" />
                                                            <asp:ListItem Value="Delete" />
                                                            <asp:ListItem Value="Change" />
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="width: 120px">&nbsp;
                                                   
                                                    <asp:Image ID="img4" runat="server" Height="100px" Width="100px"></asp:Image>
                                                    </td>
                                                    <td valign="bottom" style="width: 85px">
                                                        <asp:RadioButtonList ID="rdoImgMgr4" runat="server" CssClass="dkrgrey12" OnClick="rdoClick('4')"
                                                            TabIndex="38">
                                                            <asp:ListItem Value="Keep" Selected="True" />
                                                            <asp:ListItem Value="Delete" />
                                                            <asp:ListItem Value="Change" />
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <input class="dkrgrey12" id="File3" type="file" name="File1" runat="server"
                                                            onchange="swapImg('3')">
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        <input class="dkrgrey12" id="File4" type="file" name="File2" runat="server"
                                                            onchange="swapImg('4')">
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                        <%--<asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="!" Font-Bold="True" OnServerValidate="CheckFileType"></asp:CustomValidator>--%>
                                        <asp:Label runat="server" CssClass="error" ID="lblError" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC" height="10" colspan="2">
                                        <img src="images/s1x1.gif">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 20px">
                                        <img src="images/s1x1.gif" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">&nbsp;</td>
                                    <td nowrap align="left" style="width: 482px">

                                        <asp:Button ID="btnNextFake" runat="server" CssClass="btnNext" Text="Next" />
                                        &nbsp;&nbsp;
                                   
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="images/back.gif" TabIndex="80"
                                        ToolTip="Back" Visible="false"></asp:ImageButton>
                                        <asp:ImageButton ID="imgContinue" runat="server" ImageUrl="images/next.gif" TabIndex="76"
                                            OnClientClick="javascript:ClearHTMLTags();javascript:FreezeScreen('<font color=black>Please wait...</font>');javascript:HideElement('imgContinue','lbl2');javascript:ShowElement('imgContinueFake');javascript:DisableElement('imgContinueFake');javascript:DisableElement('imgBack');"
                                            ToolTip="Next" Visible="false"></asp:ImageButton>&nbsp;
                                   
                                    <asp:ImageButton ID="imgContinueFake" runat="server" ImageUrl="images/NextOff.gif"
                                        TabIndex="77" ToolTip="Next" Visible="false"></asp:ImageButton>&nbsp;
                                   
                                    <asp:Label ID="lbl2" runat="server" CssClass="black12"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 15px">
                                        <img src="images/s1x1.gif"></td>
                                    <td height="15px" align="left" style="width: 482px; height: 15px">
                                        <asp:Label ID="lblTip" runat="server" CssClass="midorange10b"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblStatus" runat="server" CssClass="black12"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                        <asp:HiddenField ID="HiddenField3" runat="server" />
                                        <asp:HiddenField ID="HiddenField4" runat="server" />
                                    </td>
                                </tr>
                    </table>

                    </td>
                            </tr>
                        </table>
                   
                </asp:Panel>
                <div align="center" id="FreezePane" class="FreezePaneOff">
                    <div id="InnerFreezePane" class="InnerFreezePane">
                        <img src="images/wait.gif" alt="Please wait" />
                    </div>
                </div>
                <br />

            </div>

            <input type="hidden" runat="server" id="DeletedImageUrls" />
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

            //$('#divServer').append('<form id="dropZonefrm" class="dropzone" action=""><div class="fallback"><input name="file" type="file" multiple /></div></form>');
        });

        var myDropzone = '';
        var myURL = window.location.hostname + "/post_item.aspx?name=deepak";

        $(document).ready(function () {

            Dropzone.autoDiscover = false;
            Dropzone.options.dropZonefrm = { acceptedFiles: 'image/*' };
            myDropzone = new Dropzone('#dropZonefrm', {
                paramName: 'files',
                autoProcessQueue: true,
                uploadMultiple: true,
                parallelUploads: 25,
                maxFiles: 3,
                maxFilesize: 3.4,
                addRemoveLinks: true,
                acceptedFiles: ".jpg,.gif,.jpeg,.bmp,.png",
                dictDefaultMessage: '<i class="fa fa-cloud-upload"></i>  <strong class="main-text"><b>Drop Files</b> to upload</strong> <br />  <strong class="sub-text">(or click)</strong> ',
                url: "post_item.aspx?name=deepak", 
                //url: "malzook.com?name=deepak", //window.location.hostname + "/post_item.aspx?name=deepak",
                init: function () {
                    var myDropzone = this;

                    //Populate any existing thumbnails
                    var thumbnailUrls = []; // ["http://localhost/mz/users/temp/thmbNail_rzpvnsbte.jpg", "http://localhost/mz/users/temp/thmbNail_lwdmtxxv.png", "http://localhost/mz/users/temp/thmbNail_gulwtudiz.png"]

                    if (document.getElementById("HiddenField1").value != '') {
                        thumbnailUrls[0] = document.getElementById("HiddenField1").value;
                    }

                    if (document.getElementById("HiddenField2").value != '') {
                        thumbnailUrls[1] = document.getElementById("HiddenField2").value;
                    }

                    if (document.getElementById("HiddenField3").value != '') {
                        thumbnailUrls[2] = document.getElementById("HiddenField3").value;
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
                        // have a url property.

                        if (file.url == null) {
                            if (file.name && file.name.trim().length > 0) {
                                if ($("#DeletedImageUrls").val() != '') {
                                    $("#DeletedImageUrls").val($("#DeletedImageUrls").val() + ',' + file.name);
                                }
                                else {
                                    $("#DeletedImageUrls").val(file.name);
                                }
                            }
                        } else {
                            if (file.url && file.url.trim().length > 0) {
                                if ($("#DeletedImageUrls").val() != '') {
                                    $("#DeletedImageUrls").val($("#DeletedImageUrls").val() + ',' + file.url);
                                }
                                else {
                                    $("#DeletedImageUrls").val(file.url);
                                }
                            }
                        }
                    });
                }
            });

            $('div.dz-default.dz-message > span').show(); // Show message span
            $('div.dz-default.dz-message').css({ 'opacity': 1, 'background-image': 'none' });
        });

        //$('#btnNext').click(function () {
        //    myDropzone.processQueue();
        //});

    </script>

    <%--<script>
        
        var myFile1 = {
            name: "thmbNail_rzpvnsbte.jpg", size: 12345
        };
                
        var myDropzone = Dropzone.forElement("dropZonefrm");

        myDropzone.emit("addedfile", myFile1);
        myDropzone.emit("thumbnail", myFile1, "http://localhost/mz/users/temp/thmbNail_rzpvnsbte.jpg");
        myDropzone.emit("complete", myFile1);

        var myFile2 = {
            name: "thmbNail_lwdmtx[xv.jpg", size: 12345
        };

        myDropzone.emit("addedfile", myFile2);
        myDropzone.emit("thumbnail", myFile2, "http://localhost/mz/users/temp/");
        myDropzone.emit("complete", myFile2);

        var myFile3 = {
            name: "thmbNail_gulwtudiz.jpg", size: 12345
        };

        myDropzone.emit("addedfile", myFile3);
        myDropzone.emit("thumbnail", myFile3, "http://localhost/mz/users/temp/");
        myDropzone.emit("complete", myFile3);

        alert(1);
    </script>--%>
</body>
</html>
