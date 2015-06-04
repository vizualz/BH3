<%@ Page Language="C#" AutoEventWireup="true" CodeFile="postTest.aspx.cs" Inherits="BoardHunt.postTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Page - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style>
        #radioConditionType td {
            padding-right: 5px;
        }
    </style>
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

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="content/vendor/plugins/dropzone/css/dropzone.css" rel="stylesheet" />
    <script src="content/vendor/plugins/dropzone/dropzone.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>

    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">
    <!-- Theme CSS -->
    
</head>
<body onkeydown="return (event.keyCode!=13)">
    <div id="main1" align="center">
        <form class="header" runat="server" id="Form1">
            <!-- #include file="include/Header.aspx" -->

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
                                    <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="UserMenu.aspx" Style="color: #ff9900;" CssClass="fw600 fs14">Menu&nbsp;</asp:HyperLink>&gt; Step 1 of 3: General Info</span>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                <span>Make it easy to find with accurate info.</span>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pl50 pr50">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="Region" class="field-label text-left fs18 mb10">Region</label>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <div class="section">
                                        <label class="field select">
                                            <asp:DropDownList ID="cboRegion" runat="server" TabIndex="3">
                                            </asp:DropDownList>
                                            <i class="arrow double"></i>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pl50 pr50 mb10">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="citystate" class="field-label text-left fs18 mb10">City, State<small class="fs12">&nbsp;(ex: Encinitas, CA)</small></label>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="citystate" class="field prepend-icon">
                                        <asp:TextBox ID="txtTown" runat="server" CssClass="gui-input" ClientIDMode="Static" type="text" size="45" placeholder="Enter a location" autocomplete="on" />
                                        <label for="citystate" class="field-icon">
                                            <i class="fa fa-globe"></i>
                                        </label>
                                    </label>

                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pl50 pr50 mb10">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="Zip" class="field-label text-left fs18 mb10">Zip/Postal</label>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="Zip" class="field prepend-icon">
                                        <asp:TextBox ID="txtZip" runat="server" ClientIDMode="Static" type="text" size="45" CssClass="gui-input" placeholder="Enter Zipcode" autocomplete="on" />
                                        <label for="Zip" class="field-icon">
                                            <i class="fa fa-globe"></i>
                                        </label>
                                    </label>

                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 pl50 pr50 mb10">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="What" class="field-label text-left fs18 mb10">What kind of condition? <small class="fs12">&nbsp;(Boards must be in decent condition)</small></label>
                                   
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <div class="radio-custom mb5">
                                        <asp:RadioButtonList CellPadding="3" CellSpacing="3" ID="radioConditionType"
                                            runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 pl50 pr50 mb10">
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <label for="What" class="field-label text-left fs18 mb10">Are you willing to ship?</label>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <div class="radio-custom mb5">
                                        <asp:RadioButtonList CellPadding="3" CellSpacing="3" ID="rdoShip" runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                            <asp:ListItem Value="0" Text="No" Selected="True">No&nbsp;&nbsp; </asp:ListItem>
                                            <asp:ListItem Value="1" Text="Yes">Yes</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer col-md-12 col-sm-12 col-xs-12">
                            <asp:HiddenField ID="hdnAdType" runat="server" Value="" />
                            <div class="pull-left">
                                <span style="color: #999;display: inline-block;font-size: 15px;">Avoid scams by dealing local.</span>
                            </div>
                            <div class="pull-right">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" TabIndex="5" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning" Text="Next" TabIndex="6" OnClick="btnNext_Click" />
                            </div>
                        </div>

                    </div>

                </div>
            </div>


            <%--<div align="center" style="width: 250px; height: 30px; margin: 0px auto;">
                <span class="midorange14b">
                    <%--<asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">Menu&nbsp;</asp:HyperLink>-->
                    &gt; Step 1 of 3: General Info</span>
            </div>
            <br />
            <br />--%>
            <%--<div align="center">
                <div style="background-color: #F0F0F0; width: 420px">
                    <div style="background-color: #333333; width: 420px; vertical-align: middle;">
                        <br />
                        <span class="white16">Make it easy to find with accurate info.</span>
                        <br />
                    </div>

                    <div style="width: 330px; background-color: #F0F0F0" align="left">
                        <br />
                        <br />
                        <span class="dkgrey16" align="center">Region</span><br />

                        <br />
                        <br />
                        <span class="dkrgrey16" align="center">City, State:</span><br />

                        <br />
                        <span class="midorange14">(ex: Encinitas, CA) 
                        </span>
                        <br />
                        <br />
                        <span class="dkrgrey16" align="center">Zip/Postal:</span><br />

                        <br />
                        <br />--%>
            <asp:Panel ID="pnlCondition" runat="server" Visible="true">
            </asp:Panel>

            <asp:Panel ID="pnlShip" runat="server" Visible="true">
            </asp:Panel>
            <%--<br />

                        &nbsp;<br />
                        &nbsp;<br />
                    </div>
                </div>
                <table align="center" cellspacing="0" width="450px" border="0" style="background-color: #F0F0F0; border-color: #FF9900">
                </table>
                <div style="background-color: #F0F0F0; width: 420px">
                    <div style="background-color: #333333; width: 420px; vertical-align: middle;">
                        <br />

                        <br />
                    </div>
                </div>


                <br />
            </div>--%>
        </form>

        <br />
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
            });
        </script>
</body>
</html>
