<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BoardHunt.Login" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Login - Boardhunt</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <script src="include/js/bh.js" type="text/javascript"></script>

    <!-- Font CSS (Via CDN) -->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">


    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <!-- Begin: Content -->
    <div class="container-fluid">
    <form class="header" id="Form1" runat="server">
	<bh:Header runat="server" />


            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div role="tabpanel" id="login1" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Login</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="username" class="field-label text-left fs18 mb10">E-mail</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <label for="username" class="field prepend-icon">
                                                <asp:TextBox ID="txtUsername" runat="server" class="gui-input" placeholder="Enter username"></asp:TextBox>
                                                <label for="username" class="field-icon">
                                                    <i class="fa fa-user"></i>
                                                </label>
                                            </label>
                                        </div>
                                        <div class="col-md-1">
                                        <!---
                                            <asp:CustomValidator ID="CustomValidator1" CssClass="error" runat="server" ValidationGroup="Login" OnServerValidate="CheckUserName"
                                                ErrorMessage="*"></asp:CustomValidator>
                                                -->

                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                            <label for="username" class="field-label text-left fs18 mb10">Password</label>
                                        </div>
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <label for="password" class="field prepend-icon">
                                                <asp:TextBox ID="txtPassword" class="gui-input" placeholder="Enter password" runat="server" TextMode="Password"></asp:TextBox>
                                                <label for="password" class="field-icon">
                                                    <i class="fa fa-lock"></i>
                                                </label>
                                            </label>
                                        </div>
                                        <div class="col-md-1">
                                        <!---
                                            <asp:CustomValidator ID="CustomValidator2" class="error" runat="server" ErrorMessage="*" ValidationGroup="Login" OnServerValidate="CheckPass"></asp:CustomValidator>
                                            -->
                                        </div>
                                    </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <label class="block mt15 option option-default">
                                    <asp:CheckBox ID="chkRememberMe" runat="server"></asp:CheckBox>
                                    <span class="checkbox"></span>Remember me
                                </label>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6 mt15">
                                <a class="fs14" href="forget_pass.aspx">Forgot password?</a>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                            </div>

                             <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                             	<div class="col-md-11 col-sm-11 col-xs-11 pn">
                             		<asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" Style="width: 100%" CssClass="button btn-primary" Text="Log in" OnClick="btnLogin_Click" />
                             	</div>
                             </div>

                                  <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <asp:LinkButton runat="server" ID="lnkFacebookLogin" CssClass="button btn-social facebook span-left btn-block" ValidationGroup="Facebook" OnClick="lnkFacebookLogin_Click">
                                            <span><i class="fa fa-facebook"></i>
                                            </span>Log in with Facebook</asp:LinkButton>
                                        </div>
								</div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 panel-footer">
                            <div class="col-md-6 col-sm-6 col-xs-6 pn text-left">
                                No Account?

                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6 pn text-right">
                            <asp:Button ID="btnRegister" runat="server" CssClass="button btn-info mr5" Text="Sign Up" OnClick="btnRegister_Click" /></div>
                        </div>
                        <asp:HiddenField ID="hdnVal" runat="server" />
                        <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                    <!-- TODO: Remove -->
                                        <asp:Label ID="lblMessage" ForeColor="Red" Style="border: solid 1px red" runat="server"
                                            CssClass="error-text col-md-11 col-sm-11 col-xs-11 pn text-left fs14" Visible="false">&nbsp;</asp:Label>
                        </div>
                    </div>
                </div>
            </div>
    </form>

    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->
    </div> <!-- end container fluid -->

    <!-- Bootstrap -->
    <script type="text/javascript" src="content/assets/js/bootstrap/bootstrap.min.js"></script>

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

