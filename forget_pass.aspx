<%@ Page Language="c#" Codebehind="forget_pass.aspx.cs" AutoEventWireup="false" Inherits="BoardHunt.forget_pass" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Boardhunt</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

    <script type="text/javascript">
       $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });
        });
    </script>
</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <form class="header" id="Form1" runat="server">
            <bh:Header runat="server" />
            <!-- Begin: Content -->
        <div class="container-fluid">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Panel ID="panelSendEmail" runat="server">
                <div role="tabpanel" id="login1" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Get Your Password</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">
                                <div class="col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="username" class="field-label text-left fs18 mb10">E-mail</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn mb10">
                                            <label for="username" class="field prepend-icon">
                                                <asp:TextBox ID="txtEmail" runat="server" class="gui-input" placeholder="Enter e-mail"></asp:TextBox>
                                                <label for="username" class="field-icon">
                                                    <i class="fa fa-user"></i>
                                                </label>
                                            </label>
                                        </div>
                                        <div class="col-md-1">
 											<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail"
                                    		runat="server" ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </div>

			                             <div class="col-md-11 col-sm-11 col-xs-11 pn mb10">
			                             		<asp:Button ID="btnSearch" CommandName="btnSearch" runat="server" ValidationGroup="Login" Style="width: 100%" CssClass="button btn-primary" Text="Search" OnClick="btnSearch_Click" />
			                             </div>
			                             <div class="col-md-1">
			                             </div>

                                        <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                                            <asp:Label ID="lblStatus" ForeColor="Red" BorderColor="red" BorderWidth="0" BackColor="white" runat="server" CssClass="alert"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
											<asp:Panel ID="panelMailSent" runat="server" Visible="False" Width="300" HorizontalAlign="Left">
									                <span class="dkorange16b">
									                    Yep! Check your e-mail shortly for your new password. To change this password
									                    go to the edit profile settings.
									                    </span>
									       </asp:Panel>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
					</div>
				</div>
				</asp:Panel>
			</div>
		</div>

    </form>
    <!-- TODO: Footer -->
    <div class="clearfix"></div>

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
