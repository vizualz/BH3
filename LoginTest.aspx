<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginTest.aspx.cs" Inherits="BoardHunt.LoginTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Boardhunt</title>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>--%>

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
    <form class="header" id="Form1" enctype="multipart/form-data" runat="server">

        <!-- #include file="include/HeaderTest.aspx" -->

        <%--<span class="midgrey14">&nbsp;</span>--%>
        <%-- <asp:Panel ID="pnlSurf" align="center" runat="server" BorderWidth="0px" BorderColor="#CCCCCC"
                BorderStyle="solid">--%>
        <!-- Start: Main -->


        <!-- Begin: Content -->
        <div class="container-fluid">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div role="tabpanel" id="login1" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Login</span>
                            </div>
                            <div class="login-links text-right">
                                <a href="logintest.aspx" class="active fs14" title="Sign In">Sign In</a>
                                <span class="text-warning">| </span>
                                <a href="register_usertest.aspx" class="fs14" title="Register">Register</a>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">
                                <div class="col-md-6 border-right">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                        <span>Login</span>
                                    </div>
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
                                            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtUsername" ValidationGroup="Login" CssClass="error" ErrorMessage="!" Display="Static"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator1" CssClass="error" runat="server" ValidationGroup="Login" OnServerValidate="CheckUserName"
                                                ErrorMessage="*"></asp:CustomValidator>
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
                                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ValidationGroup="Login" CssClass="error" ErrorMessage="!" Display="Static"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator2" class="error" runat="server" ErrorMessage="*" ValidationGroup="Login" OnServerValidate="CheckPass"></asp:CustomValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn section-divider mv40">
                                        <span>OR Sign in With</span>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 pn">
                                        <div class="col-md-11 col-sm-11 col-xs-11 pn">
                                            <asp:LinkButton runat="server" ID="lnkFacebookLogin" CssClass="button btn-social facebook span-left btn-block" ValidationGroup="Facebook" OnClick="lnkFacebookLogin_Click">
                                            <span><i class="fa fa-facebook"></i>
                                            </span>Facebook</asp:LinkButton>
                                        </div>

                                        <asp:Label ID="lblMessage" ForeColor="Red" Style="border: solid 1px red" runat="server"
                                            CssClass="error-text col-md-11 col-sm-11 col-xs-11 pn text-left fs14" Visible="false">&nbsp;</asp:Label>

                                        <%-- <a class="button btn-social twitter span-left btn-block" href="#">
                                                <span><i class="fa fa-twitter"></i>
                                                </span>Twitter</a>
                                            <a class="button btn-social googleplus span-left btn-block" href="#">
                                                <span><i class="fa fa-google-plus"></i>
                                                </span>Google+</a>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="Col-md-12 col-sm-12 col-xs-12 pn">
                                <h3 class="mn">Not a member yet? It's free, and only takes seconds ! </h3>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 panel-footer">
                            <div class="col-md-3 col-sm-4 col-xs-7 pn">
                                <label class="block mt15 option option-default">
                                    <asp:CheckBox ID="chkRememberMe" runat="server"></asp:CheckBox>
                                    <span class="checkbox"></span>Remember me
                               
                                </label>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-5 pt20 pb10 pn">
                                <a class="fs14" href="forget_pass.aspx">Forgot password?</a>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-6 col-sm-5 col-xs-12 pn text-right">
                                <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" CssClass="button btn-primary" Text="Login" OnClick="btnLogin_Click" />
                                <asp:Button ID="btnRegister" runat="server" CssClass="button btn-info mr5" Text="Sign Up" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnVal" runat="server" />

                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <!-- Bootstrap -->
    <script type="text/javascript" src="content/assets/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->

    <%--<script type="text/javascript" src="content/assets/js/pages/login/EasePack.min.js"></script>
    <script type="text/javascript" src="content/assets/js/pages/login/rAF.js"></script>
    <script type="text/javascript" src="content/assets/js/pages/login/TweenLite.min.js"></script>
    <script type="text/javascript" src="content/assets/js/pages/login/login.js"></script>--%>

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
