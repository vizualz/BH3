<%@ Page Codebehind="edit_profile.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="BoardHunt.edit_profile" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Profile - Boardhunt</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    <script type="text/javascript" src="include/js/bh.js"></script>
    <link href="style/global.css" type="text/css" rel="stylesheet" />

    <!-- Font CSS (Via CDN) -->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,500,700,300">

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">

</head>
<body style="background: none repeat scroll 0 0 #fff;">
<div class="container-fluid">
        <form class="header" id="Form1" runat="server">
            <bh:Header runat="server" />

            <div align="center"> <!--- TODO: Remove eventually -->
                <div align="center" style="width: 400px"> <!--- TODO: add breadcrumb style -->
                    <span class="midorange14b">
                        <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">MENU</asp:HyperLink>
                        &nbsp;&gt;&nbsp;MY ACCOUNT INFO</span>
                </div>

  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:Panel role="tabpanel" runat="server" id="pnlRegister" class="admin-form tab-pane active col-lg-6 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto;">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Profile</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">
                             	<div class="col-md-12 col-sm-12 col-xs-12">
	                                    <div class="col-md-6 col-sm-6 col-xs-6 pn mb10 text-right">
                                            <asp:Image ID="img1" runat="server" Height="64px" Width="64px"></asp:Image>

                                     	</div>
                                     	<div class="col-md-6 col-sm-6 col-xs-6 pn mb10 text-left">
                                     		<asp:RadioButtonList ID="rdoImgMgr1" runat="server" CssClass="dkgrey10b" OnClick="rdoClick('1')"
                                                TabIndex="17">
                                                <asp:ListItem Value="Keep" Selected="True" />
                                                <asp:ListItem Value="Delete" />
                                                <asp:ListItem Value="Change" />
                                            </asp:RadioButtonList>
                                     	</div>
                                </div>
                            	<div class="section row">
	                             	<div class="col-md-12 col-sm-12 col-xs-12">
		                            	<div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
	                                 		<input class="dkgrey10b" id="File1" type="file" name="File1" runat="server" onchange="swapImg('1')" />
	                                 	</div>
                                 	</div>
								</div>

                            	<div class="section row">
	                             	<div class="col-md-12 col-sm-12 col-xs-12">
		                            	<div class="col-md-12 col-sm-12 col-xs-12 pn mb10">
<!--- FAB START -->
                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right" nowrap style="width: 200px">
                                            Full name:&nbsp;</td>
                                        <td align="left" style="width: 300px">
                                            <asp:TextBox ID="txtFullName" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right" nowrap>
                                            Display name:&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="dkgrey14" height="5px" align="right">
                                            E-mail:&nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="dkrgrey14" Style="width: 200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtEmail"
                                                Font-Bold="True" ErrorMessage="!"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                                Font-Bold="True" ErrorMessage="!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                    </tr>
 
                                    <tr>
                                        <td class="dkgrey14" align="right" height="5px">
                                            Phone #:&nbsp;</td>
                                        <td class="dir" align="left">
                                            (
                                            <asp:TextBox ID="txtAreaCode" runat="server" CssClass="dkrgrey14" Width="40px" MaxLength="3"></asp:TextBox>&nbsp;)
                                            -
                                            <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="dkrgrey14" Width="100px" MaxLength="8"></asp:TextBox>
                                            <asp:CustomValidator ID="Customvalidator2" runat="server" Font-Bold="True" ErrorMessage="!"
                                                OnServerValidate="CheckPhoneNum"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
              
                                        <td class="dkrgrey10b" style="height: 20px">
                                            <asp:CheckBox ID="chkShowPhone" runat="server" Text=" Show buyers my phone#"></asp:CheckBox>
                                        </td>
                                    </tr>
 
                                    <tr>
                                        <td class="dkgrey18b" style="height: 40px;" align="left" valign="top" colspan="2">
                                            <span style="width: 100%">&nbsp;Settings&nbsp;</span><br />
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right">
                                            Is this a business?&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="radioAcctType" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="2">Yes</asp:ListItem>
                                                <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
 
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right" nowrap>
                                            Email me when people &nbsp;<br />
                                            write on my wall:&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="rdoEmailNotify" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">On</asp:ListItem>
                                                <asp:ListItem Value="N">Off</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
        
                                    <tr>
                                        <td class="dkgrey14" valign="middle" height="5px" align="right" nowrap>
                                            Email me on new blogs:&nbsp;</td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="rdoBlogNotify" CssClass="dkrgrey14" runat="server" Enabled="True"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">On</asp:ListItem>
                                                <asp:ListItem Value="N">Off</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>

                                    <tr>
                                        <td style="height: 15px" align="right" class="dkgrey14">
                                            &nbsp;Password:&nbsp;</td>
                                        <td style="height: 15px;" align="left">
                                            <asp:Button ID="btnChangePwd" runat="server" class="dkrgrey10b" Text="Change Password..."
                                                Width="130px" OnClick="btnChangePwd_Click" />
                                        </td>
                                    </tr>

                                    <asp:Panel ID="pnlChangePwd" runat="server" Visible="true">
                
                                                &nbsp;New password:&nbsp;
                                
                                                <asp:TextBox ID="txtPassword1" runat="server" CssClass="dkrgrey14" Width="150px"
                                                    TextMode="Password"></asp:TextBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" Font-Bold="True" ErrorMessage="!"
                                                    OnServerValidate="CheckPassword"></asp:CustomValidator>
                                      
                                    </asp:Panel>

<!---PROFILE END -->

										</div>
									</div>
								</div>

                            </div>
						</div>
					</div>
<!---SETTINGS -->
					<div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>Settings</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">
                            </div>
						</div>
					</div>
<!--- SHAPERHOUSE-->
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-4 col-sm-5 col-xs-6 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>ShaperHouse</span>
                            </div>
                        </div>
                        <div class="panel-body p15 pt10">
                            <div class="section row">



                            </div>
						</div>
					</div>
				</asp:Panel>
	</div>
<!--- wrap everything below to the above block -->


                    <table cellspacing="0" cellpadding="0" bgcolor="F0F0F0" border="0" bordercolor="#CCCCCC">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" bgcolor="#F0F0F0" style="height: 600px" border="0">




                                    <asp:Panel ID="pnlShaper" runat="server">
                                        <tr>
                                            <td colspan="2" align="left" style="height:10px">
                                                <asp:Label runat="server" ID="lblShaperHouse" CssClass="dkgrey18b">
                                            &nbsp;ShaperHouse Profile
                                            </asp:Label>
                                                <br />
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Brand:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBrandName" runat="server" CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Region:&nbsp;</td>
                                            <td align="left" class="dkgrey14">
                                                <asp:DropDownList ID="cboRegion" runat="server" CssClass="dkrgrey14" Style="width: 150px">
                                                </asp:DropDownList>&nbsp;&nbsp; Backyard:&nbsp;<asp:TextBox ID="txtHomeTown" runat="server"
                                                    CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Web site:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="dkrgrey14" Style="width: 150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Years shaping:&nbsp;</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtShapingYrs" runat="server" CssClass="dkrgrey14" Style="width: 30px"></asp:TextBox>
                                                <span class="dkgrey10b">(whole numbers)</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 5px;" colspan="2">
                                                <img src="images/s1x1.gif" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td class="dkgrey14" height="5px" align="right" nowrap>
                                                Bio:&nbsp;</td>
                                            <td align="left" valign="top" style="width: 482px">
                                                <asp:TextBox ID="txtDetails" onkeydown="CountChars()" runat="server" CssClass="dkrgrey14"
                                                    Height="135px" Width="350px" MaxLength="599" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>&nbsp;&nbsp;
                                                <span class="dkorange10b">
                                                    <br />
                                                    <b>(600 chars max with no HTML)</b>&nbsp;&nbsp;</span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dkgrey14" align="right" valign="top">
                                                Shaping Designs:&nbsp;<br />
                                                (for shapers only)&nbsp;</td>
                                            <td style="border: solid 0px black" align="left">
                                                <asp:CheckBoxList ID="chkListShaping" CssClass="dkgrey12b" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Text="All" Value="69"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </asp:Panel>

                                    <tr>
                                        <td height="15px" style="width: 120px">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="Cancel" TabIndex="100"
                                                OnClick="btnCancel_Click" />&nbsp;
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnGo" Text="Save" TabIndex="101"
                                                OnClick="btnSave_Click" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px" style="width: 120px" colspan="2">
                                            &nbsp;
                                            <asp:Label ID="lblStatus" runat="server" CssClass="alert"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                


            </div>
            <br />
            <br />
            <asp:HiddenField ID="hdnUserDir" runat="server" />
            <asp:HiddenField ID="hdnProfilePic" runat="server" />
            <asp:HiddenField ID="hdnAcctType" runat="server" />
            <asp:HiddenField ID="hdnMT" runat="server" />
            <asp:HiddenField ID="hdnShaperCode" runat="server" Value="0" />
            <asp:HiddenField ID="hdnIsShaper" runat="server" Value="0" />
            <div id="push">
            </div>
        </form>


</div><!-- END CONTAINER -->

    <div class="clearfix"></div>
    <!-- #include file="include/footer.aspx" -->

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
