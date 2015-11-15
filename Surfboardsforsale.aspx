<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Surfboardsforsale.aspx.cs" Inherits="BoardHunt.Surfboardsforsale" %>
<%@ Register TagPrefix="bh" TagName="ShowBoost" Src="~/include/Controls/BoostHoriz.ascx" %>
<%@ Register TagPrefix="bh" TagName="Header" Src="~/include/HeaderCtl.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>

<head>
    <title>Used Surfboards | Boardhunt</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Find new and used surfboards for sale by others in the surfing community"/>
    <meta name="keywords" content="used surfboards, surfboards for sale, buy surfboards, sell surfboards, surfboard, surfboards, surfboard blogs, surfing blogs, surfboard advice" />

    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/skin/default_skin/css/theme.css">

    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="content/assets/admin-tools/admin-forms/css/admin-forms.css">


    <!-- jQuery -->
    <script type="text/javascript" src="content/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="content/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>

    
    <script type="text/javascript" src="include/js/superfish.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />
    <script src="include/js/bh.js" type="text/javascript"></script>
    <link rel="alternate" type="application/rss+xml" title="Boardhunt: Surfboards For Sale" href="http://www.malzook.com/rss/surfboards.xml"/>
   <link href="style/global.css" rel="stylesheet" type="text/css" />
    <link href="style/hover.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="include/js/jquery.jgrowl.js"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="style/jquery.jgrowl.css" />
  <script src="include/js/jquery.cluetip.js" type="text/javascript"></script>
  <link rel="stylesheet" href="style/jquery.cluetip.css" type="text/css" />
   <script type="text/javascript">
       function SaveBG(val) {
           var hdnCtl;
           hdnCtl = document.getElementById('hdnBackColor');
           hdnCtl.value = val;
       }

       function GetBG() {
           var hdnCtl;
           hdnCtl = document.getElementById('hdnBackColor');
           return hdnCtl.value;
       }

       function SetHdnLocVal() {
           var hdnCtl;
           var hdnCtl2;
           hdnCtl = document.getElementById('hdnLocVal');
           hdnCtl2 = document.getElementById('cboLocation');
           hndCtl.value = hdnCtl2.value;
       }
    </script>
	<style type="text/javascript">
		#dlEntryList
		{width:90% !important;
		} 
	</style>

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function () {
                jQuery('ul.sf-menu').superfish();
            });

            $(function () {
                var availableTags = ["Channel Islands", "Channel Island", "flyer", "pod", "Al Merrick", "Roberts", "Rusty", "Lost", "Bissell", "Linden", "FCD", "HIC", "Chemistry", "Xanadu", "3rd World Exotic", "Hynson", "SharpEye", "Becker", "Chili", "Firewire", "Kane Garden", "Santa Cruz", "WRV", "Quiet Flight", "Surf Prescriptions", "SurfTech", "Bill Johnson", "MR", "Weber", "Rickland", "West", "Resist", "KookBox", "Tequoph"];
                $("#txtFilterKwd").autocomplete({
                    source: availableTags, minLength: 2
                });
            });

            $('img.Tips').cluetip({ splitTitle: '|', clickThrough: true });
            $('input.Tips').cluetip({ splitTitle: '|', clickThrough: true, width: 190, height: 'auto', dropShadow: false });

            if ($('#hdnSash').val() == "000") {

                $('#adv').find('input, textarea, button, select').attr('disabled', 'disabled');
                //$('#adv').find('select').attr('disabled', 'disabled');
                $('#adv').bind('click', function () {
                    $.jGrowl.defaults.position = 'center-middle';
                    $.jGrowl.defaults.pool = 1;
                    $.jGrowl("<span class='white16'>To use Advanced Filters, you must be logged in with a Pro Account.&nbsp;&nbsp;<br><a href='/register_user.aspx' class='orange_dkorange16'>Register</a> now or Upgrade if you're already a member.</span>",
                    { sticky: true
                        //height: 400
                        //beforeOpen: function(e,m,o){ 
                        //$(e).height("108px"); 
                        //} 

                        //header: 'Title' 

                    });
                    $('#jGrowl').height(600);
                });

            }

            //don't attach if it's '1' otherwise attach and prevent 

        });

        function jsFunc() {
            document.getElementById("hField").value = "someString";
            __doPostBack("btn1", "");
        }
    </script>
    <!--[if lt IE 7]>
    <script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
    <![endif]-->

<!-- Google ads: Leader was here once -->

</head>
<body style="background: none repeat scroll 0 0 #fff;">
    <form id="Form1" runat="server">
	<bh:Header runat="server" />

        <!-- Begin: Content -->
        <div class="container-fluid">
        	<%--PAGE NAV--%>
			<ul class="breadcrumb">
			    <li><asp:HyperLink ID="HypLoc" runat="server" NavigateUrl="index.aspx"></asp:HyperLink></li>
			    <li class="active"><asp:Label ID="lblCat" runat="server"></asp:Label></li>
			</ul>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:Panel runat="server" role="tabpanel" id="pnlFilter" class="admin-form tab-pane active col-lg-8 col-md-8 col-sm-9 col-xs-12" style="float: none; margin: 0 auto; border:1px">
                    <div class="panel panel-warning heading-border">
                        <div class="panel-heading">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                                <span class="panel-title"><i class="fa fa-sign-in hidden-xs"></i>FIND YOUR BOARD</span>
                            </div>
                        </div>

                        <div class="panel-body p15 pt10">
                            <div class="section row">
                            	<div class="col-md-6 col-sm-6 col-xs-6">

									<asp:TextBox ID="txtFilterKwd" runat="server" class="gui-input" placeholder="Keywords" Style="background-image: url('http://www.malzook.com/images/atarget.gif');
                                     background-repeat: no-repeat; background-position: right"></asp:TextBox>
                            	</div>
                            	<div class="col-md-3 col-sm-3 col-xs-3">
                                    <div class="section">
                                        <label class="field select">
                                            <asp:DropDownList ID="cboLocation" runat="server" TabIndex="3" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <i class="arrow double"></i>
                                        </label>
                                    </div>
                            	</div>
                            	<div class="col-md-3 col-sm-3 col-xs-3">
                                    <div class="section">
                                        <label class="field select">
									<asp:DropDownList ID="cboBoardType" runat="server" CssClass="dkrgrey16" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
                                    </asp:DropDownList>
                                            <i class="arrow double"></i>
                                        </label>
                                    </div>
                            	</div>
							</div><!--- end section row1 -->
							<div class="section row">
								<div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" style="border: 0px solid red">
									<div class="row mb5">
										<div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 mb2" style="border: 0px solid blue">
			                                	<asp:TextBox ID="txtMinPrice" runat="server" OnClick="select()"
			                                                    placeholder="$Min" OnTextChanged="txtPrice_TextChanged" CssClass="gui-input" Width="55px"></asp:TextBox>
			                            </div>
			                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 mt10" style="border: 0px solid blue" >
			                                               <span class="">to</span>
			                            </div>
			                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
			                                                <asp:TextBox ID="txtMaxPrice" runat="server" CssClass="gui-input" OnClick="select()"
			                                                    placeholder="$Max" OnTextChanged="txtPrice_TextChanged" AutoPostBack="true" Width="60px"></asp:TextBox>
			                            </div>
									</div>
								</div>
									<div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="border: 0px solid red">
									<div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
										<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
	                                                <asp:TextBox ID="txtHtFt" runat="server" CssClass="gui-input" OnClick="select()"
	                                                    onkeyup="CountMyChars(txtHtFt,2)" placeholder="ft" Width="40px"></asp:TextBox>
	                                    </div>
	                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
	                                                <asp:TextBox ID="txtHtIn" runat="server" CssClass="gui-input" OnClick="select()"
	                                                    onkeyup="CountMyChars(txtHtIn,2)" placeholder="in" Width="40px"></asp:TextBox>
	                                    </div>
									</div>
									<div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 mt10">
	                                                <span class="">to</span>
	                                </div>
	                                 
	                                 <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
		                                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
		                                                <asp:TextBox ID="txtHtFtMax" runat="server" CssClass="gui-input" OnClick="select()"
		                                                    onkeyup="CountMyChars(this,2)" placeholder="ft" Width="40px"></asp:TextBox>
		                                 </div>
		                                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
		                                                <asp:TextBox ID="txtHtInMax" runat="server" CssClass="gui-input" OnClick="select()"
		                                                    onkeyup="CountMyChars(this,2)" placeholder="in" Width="40px"></asp:TextBox>
		                                </div>
									</div>
									</div>

									<div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
	                                                <asp:Button ID="btnSearch" Text="Hunt" runat="server" CssClass="button btn-primary" 
	                                                    OnClick="btnSearch_Click" />
	                                                    <a href="javascript:resetFilter()" class="black">reset</a>
									</div>
								
							</div> <!--- end div section row 2-->
							<div class="section row">
								<div class="col-lg-12 col-md-12 col-sm-12 hidden-xs">
									<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
										<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
										<div class="section">
											<label class="field select">
												<asp:DropDownList ID="cboCondition" runat="server" CssClass="gui-input" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged" ></asp:DropDownList>
	                                            <i class="arrow double"></i>
	                                        </label>
										</div>
										</div>
										<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
											<label class="field select">
												<asp:DropDownList ID="cboFins" runat="server" CssClass="gui-input" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
		            						</asp:DropDownList><i class="arrow double"></i>
	                                        </label>
	            						</div>
										<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
											<label class="field select">
											<asp:DropDownList ID="cboTailType" runat="server" CssClass="gui-input"
		                					 AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged" />
		            						<i class="arrow double"></i>
	                                        </label>
	            						</div>
									</div>
									<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
										<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
											<label class="field select">
												<asp:DropDownList ID="cboPostingType" runat="server" CssClass="dkrgrey12" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
									                <asp:ListItem Value="All" Text="All"></asp:ListItem>
									                <asp:ListItem Value="2" Text="Business"></asp:ListItem>
									                <asp:ListItem Value="1" Text="Private"></asp:ListItem>
									            </asp:DropDownList>
		            						<i class="arrow double"></i>
	                                        </label>
	            						</div>
										<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
	            							<asp:CheckBox ID="chkReduced" runat="server" Text="&nbsp;Best Deals" OnCheckedChanged="Check_Clicked" AutoPostBack="true" EnableViewState="true" />
	            						</div>

									</div>
								</div>

							</div>
                            
                            </div>
                            </div>
				</asp:Panel>
			</div>
			<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 hidden" >
	    		<asp:Button ID="btnSearch2" Text="Hunt" runat="server" CssClass="button btn-primary" OnClick="btnSearch_Click" Visible="false" />  
	            &nbsp;&nbsp;

	            											<label class="field select">
												<asp:DropDownList ID="cboAdType" Width="40px" runat="server" CssClass="dkrgrey12" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="cboFilter_SelectedIndexChanged">
									            </asp:DropDownList>
		            						<i class="arrow double"></i>
	                                        </label>


			</div>

            <div class="midorange26b" align="center">
                <asp:Label CssClass="" ID="lblNoResult" runat="server"></asp:Label><br />
            </div>

                    <!-- BOOST -->
                    <div class="slider_container_top" style="border: dotted 0px red">
                        <bh:ShowBoost ID="boost" runat="server"></bh:ShowBoost>
                    </div>

                    <div align="center">

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True"> 
								<ContentTemplate>

								<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border: 0px solid black; float:right">
									<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
										<h2>
											<asp:Label ID="lblCount" runat="server"></asp:Label>
										</h2>
									</div>
									<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 mt25">

                                            <!-- Paging -->
                                            <asp:Panel id="pnlPageTop" runat="server">

                                                    <asp:ImageButton ID="topcmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
                                                        ImageUrl="~/images/left_1.gif" runat="server"></asp:ImageButton>
													
                                                    <asp:Label id="lblPage1" runat="server" CssClass="field-label fs14">Page</asp:Label>

	                                                <asp:TextBox ID="txtHiCurrentPage" runat="server" CssClass="gui-input" AutoPostBack="True"
	                                                    Visible="true" OnTextChanged="OnPaging_TextChange" Width="30px"> </asp:TextBox>
	                                              

                                                    <asp:Label ID="toplblcpage" CssClass="field-label fs14" runat="server" Visible="false"></asp:Label>

                                                    <asp:ImageButton ID="topcmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
                                                        runat="server" ImageUrl="images/right.gif"></asp:ImageButton>
											</asp:Panel>
										</div>
								</div>
								<Triggers>
									<asp:AsyncPostBackTrigger ControlID="topcmdNext"  eventname="click"/>
									<asp:AsyncPostBackTrigger ControlID="topcmdPrev"  eventname="click"/>
                                </Triggers>
 								</ContentTemplate>
 								</asp:UpdatePanel>

 								<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
								<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
								<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:DataList  RepeatLayout="Flow" BorderColor="#CCCCCC" BorderStyle="Solid" Style=""
                                        BorderWidth="1" ID="dlEntryList" runat="server" EnableViewState="true" OnItemCommand="View_ItemDetail" >
                                        <HeaderTemplate>
                                        &nbsp;
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                        <div class="panel">
                                        	<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt5 mb5" style="border-bottom-style: solid; border-width: 1px; ">
                                        		<div class="col-xs-3">
		                                        	<asp:ImageButton ID="imgPreview" class="img-responsive" width="151px" height="151px" runat="server" ImageUrl='<%# SetPicPath(DataBinder.Eval(Container.DataItem, "iCategory"), DataBinder.Eval(Container.DataItem, "userDir"), DataBinder.Eval(Container.DataItem, "txtImgPath1"))%>' OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
			                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
		                                            </asp:ImageButton>

	                                                <asp:Panel ID="pnlPreview" CssClass="imgcontainer" runat="server">
	                                                </asp:Panel>
                                        		</div>
                                        		<div class="col-xs-8">
                                        			<div class="col-xs-12">
		                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
			                                                <div class="clearfix">
			                                                <h3>
			                                                    <asp:LinkButton CssClass="" ID="LinkButton2" runat="server" OnCommand="GetValues" style="vertical-align:middle"
			                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
																	<%# FormatHeightFt(DataBinder.Eval(Container.DataItem, "iHtFt"))%>
																	
																	<%# FormatHeightIn(DataBinder.Eval(Container.DataItem, "iHtIn"))%>
																	
							                                        <%# FormatBrand(DataBinder.Eval(Container.DataItem, "txtBrand"), DataBinder.Eval(Container.DataItem, "txtShaper"))%>
																	&nbsp;
																	<%# DataBinder.Eval(Container.DataItem, "txtOtherBoardType")%>
																	<%# DataBinder.Eval(Container.DataItem, "txtGearItem")%>										
			                                                    </asp:LinkButton>&nbsp;
			                                               	</h3>
			                                                </div>
		                                                </div>                                     
														<div class="hidden">
		                                               	<!-- <div class="col-lg-3 xs-hidden"> -->
															<div>
		                										<h6>
			                										<asp:LinkButton BorderWidth="0" runat="server" ID="lnkBtnImg"
			                                                            OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>'
			                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
			                                                            <asp:Image BorderWidth="0" ID="imgCameraPic" runat="server"
			                                                                ImageUrl='<%# SetBoardPic(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue")) %>' />
			                                                        </asp:LinkButton>
		                                                        </h6>
		                									</div>
		                									<div class="clearfix">
		                										<h3>
		                											<%# GetToolTip(DataBinder.Eval(Container.DataItem, "iCategory"),DataBinder.Eval(Container.DataItem, "iValue"))%>
		                										</h3>
		                									</div>
		                									 
														</div>
		                                        		<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 mt15" style="">

		                                                 	<div class="clearfix"> 
		                                                   	 	<a class="label label-default" href='/surfboard.aspx?iD=<%# DataBinder.Eval(Container.DataItem, "iD") %>'>
		                                                        <%# DataBinder.Eval(Container.DataItem, "iPageViewCount")%>&nbsp;views</a>
														 	</div>
														</div>


														<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
															<div class="clearfix">
																<h3>
				                                                    <asp:LinkButton ID="lnkBtnPrice" CssClass="label label-success" runat="server" OnCommand="GetValues"
				                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
				                                                    <%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") %>
				                                                    </asp:LinkButton>
			                                                    </h3>
			                                                </div>
															<%--
															<h4>
			                                                    <asp:LinkButton ID="lnBtnTown" CssClass="dkgrey_white10" runat="server" OnCommand="GetValues"
			                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
			                                                    <%# FormatLoc(DataBinder.Eval(Container.DataItem, "txtTown")) %>
			                                                    &nbsp;&nbsp;
			                                                    </asp:LinkButton>
		                                                    </h4>
		                                                    --%>
														</div>
													</div>
	                                            </div>
	                                            <div class="col-xs-1">
	                                    			<div>
	                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="GetValues"
	                                                        CommandName='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>
											    		<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MMM dd}") %>
	                                                    </asp:LinkButton>
	            									</div>
	            									<div>
														<asp:ImageButton runat="server" class="Tips" title='<%# GetTip(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>'
	                                                        OnCommand="GetValues" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'
	                                                        ID="imgBtnReduced" ImageUrl='<%# SetPricePic(DataBinder.Eval(Container.DataItem, "iPriceChange")) %>' />
	            									</div>
	                                            </div>
                                        	</div>
                                        	</div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
					            </ContentTemplate>
					            <Triggers>
					                <asp:AsyncPostBackTrigger ControlID="btnSearch2" eventname="Click" />
					                <asp:AsyncPostBackTrigger ControlID="btnSearch" eventname="Click" />
					                <asp:AsyncPostBackTrigger ControlID="cboLocation"  eventname="SelectedIndexChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="cboBoardType"  eventname="SelectedIndexChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="txtMaxPrice"  eventname="TextChanged"/>
					                <asp:AsyncPostBackTrigger ControlID="txtMinPrice"  eventname="TextChanged"/>

					                 <asp:AsyncPostBackTrigger ControlID="cboCondition"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboFins"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboTailType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboAdType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="cboPostingType"  eventname="SelectedIndexChanged"/>
					                 <asp:AsyncPostBackTrigger ControlID="chkReduced"  />
					            </Triggers>
					        </asp:UpdatePanel>
					        </div>
					        				<!--- Bottom Nav -->
	                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
	                                        <ContentTemplate>
	                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
	                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"></div>
	                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 mt5">
		                                        <asp:Panel id="pnlPageBtm" runat="server">
				                                                    <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
		                                                        runat="server" ImageUrl="../images/left_1.gif"></asp:ImageButton>                                                      
		                                                	<asp:Label ID="lblPage2" runat="server" CssClass="field-label fs14">Page</asp:Label>  
		                                                <asp:TextBox ID="txtLoCurrentPage" runat="server" CssClass="gui-input" AutoPostBack="True"
		                                                    Visible="true" OnTextChanged="OnPaging_TextChange" Width="30px"></asp:TextBox>
		                                                    <asp:Label ID="lblcpage" runat="server" Visible="false" CssClass="field-label fs14"></asp:Label>
		                                                    <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
		                                                        runat="server" ImageUrl="../images/right.gif"></asp:ImageButton>
		          
												</asp:Panel>
												<Triggers>
												<asp:AsyncPostBackTrigger ControlID="cmdNext"  eventname="click"/>
												<asp:AsyncPostBackTrigger ControlID="cmdPrev"  eventname="click"/>
				                                </Triggers>
				                            </div>
			                                </div>
			 								</ContentTemplate>
											</asp:UpdatePanel>


                                <br />
                                <asp:HiddenField ID="hdnBackColor" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLocVal" Value="" runat="server" />
                                <asp:HiddenField ID="hdniCat" Value="" runat="server" />
                                <asp:HiddenField ID="hdnServer" Value="" runat="server" />
                                <asp:HiddenField ID="hdniBoardType" Value="" runat="server" />
                                <asp:HiddenField ID="hdnKeywords" Value="" runat="server" />
                                <asp:HiddenField ID="hdnUiD" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSash" Value="" runat="server" />


                    <%--END WRAPPER--%>
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="medgrey12"></asp:Label>
                    </div>
			</div><%--END CENTERing DIV--%>


            <div class="push">
            </div>
    		</div> <!--- End container fluid -->
  </form>
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
