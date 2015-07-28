<%@ Page Language="c#" Codebehind="contact.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.contact" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE HTML>
<html lang="en">
<head runat="server">
    <title>Contact Boardhunt</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <script src="include/js/bh.js" type="text/javascript"></script>

    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800'>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <form class="header" id="Form1" runat="server">
        <bh:Header runat="server" />

         <!-- Start: Main -->

            <div class="container-fluid">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:Panel ID="panelSendEmail" role="tabpanel" runat="server" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Contact Us</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            	<div class="section row">
                                	<div class="col-md-12 col-sm-12 col-xs-12">
	                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
	                                            <label for="username" class="field prepend-icon">
	                                                <asp:TextBox ID="name" runat="server" class="gui-input" placeholder="Your name"></asp:TextBox>
	                                                <label for="username" class="field-icon">
	                                                    <i class="fa fa-user"></i>
	                                                </label>
	                                            </label>
	                                    </div>
                                    </div>

                                    <div class="col-md-12 col-sm-12 col-xs-12">
	                                    <div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
	                                            <label for="email" class="field prepend-icon">
	                                                <asp:TextBox ID="email" runat="server" class="gui-input" placeholder="Email"></asp:TextBox>
	                                                <label for="email" class="field-icon">
	                                                    <i class="fa fa-user"></i>
	                                                </label>
	                                            </label>


	                                    </div>
	                                    </div>

                                    <div class="col-md-12 col-sm-12 col-xs-12">
				                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pn mb10"> 
				                        <div class="section">
				                        	<label class="field select">
				                                <asp:DropDownList ID="cboSubject" runat="server" Enabled="true">
				                                    <asp:ListItem Value="1" Selected="True">General - Comments or questions</asp:ListItem>
				                                    <asp:ListItem Value="2">Boardhelp - Board related</asp:ListItem>
				                                    <asp:ListItem Value="3">Tech Support - Report problem</asp:ListItem>
				                                    <asp:ListItem Value="5">Adverts - Advertise on Boardhunt</asp:ListItem>

				                                </asp:DropDownList>
				                                <i class="arrow double"></i>
				                                </label>
				                        </div>
				                        </div> 
                                    </div>

                                    <div class="col-md-12 col-sm-12 col-xs-12">
				                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pn mb10"> 
				                        <label class="field" for="comment"> 
				                            <asp:TextBox ID="message" placeholder="Send us a message" TextMode="MultiLine" Columns="40" Rows="10" runat="server"
				                                 CssClass="gui-textarea" />
				                        </label>
				                        </div>
                                    </div>

		                             <div class="col-md-12 col-sm-12 col-xs-12">
		                             	<div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                           					<asp:Button ID="btnSend" runat="server" CssClass="button btn-primary" Text="Send" />
                            				<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CheckFields"></asp:CustomValidator>
		                             	</div>
		                             </div>
		                             <div class="col-md-12 col-sm-12 col-xs-12">
		                             	<div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
                           					<asp:Label id="lblErrorMsg" runat="server"></asp:Label>
		                             	</div>
		                             </div>
								</div><!--- END SECTION ROW -->
							</div><!--- END panel BODY -->
							</div><!--- END panel MAIN -->

							</asp:Panel><!--- master panel-->

			                <asp:Panel ID="panelMailSent" runat="server" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
			                    <div class="panel panel-warning heading-border">
			                        <div class="panel-heading">
			                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
			                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Thanks</span>
			                            </div>
			                        </div>
			                        <div class="panel-body p15 pt10">
			                            <div class="section row">
			                                <div class="col-md-12 col-sm-12 col-xs-12">
			                                Your message was sent.
											</div>
										</div>
									</div>
								</div>
							</asp:Panel>
						</div><!--- master row?-->
					</div><!--- container fluid-->


      </form>
    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->


 

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