<%@ Page language="c#" Codebehind="PostMaster.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Admin.PostMaster1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<head>
		<title>Post Master | Boardhunt</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
        <link href="../style/global.css" type="text/css" rel="stylesheet"/>   
        
        <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/themes/base/jquery-ui.css" type="text/css" media="all" />
        <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js" type="text/javascript"></script>
        <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/jquery-ui.min.js" type="text/javascript"></script>
        <script src="http://jquery-ui.googlecode.com/svn/tags/latest/external/jquery.bgiframe-2.1.1.js" type="text/javascript"></script>
        <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.3/i18n/jquery-ui-i18n.min.js" type="text/javascript"></script>

        
        <script type="text/javascript" src="../include/js/superfish.js"></script>
        <script src="../include/js/bh.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
          <script src="../include/js/jquery.cluetip.js" type="text/javascript"></script>
          <link rel="stylesheet" href="../style/jquery.cluetip.css" type="text/css" />        
		<meta name="ROBOTS" content="NOINDEX, NOFOLLOW"/>
        <script type="text/javascript">
          $(document).ready(function() {
		    jQuery(function(){
			    jQuery('ul.sf-menu').superfish();
		    });
		    
		        $('img.Tips').cluetip({splitTitle: '|',clickThrough:     true});
		    
          });
        
        </script>
        	
	</head>
	<body>
        <div id="main" align="center">
		<form id="Form1" runat="server">
            <!-- #include file="../include/Header.aspx" -->            
	<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
  <div align="center" class="midorange14b" style="width:200px; margin: 0px auto;">ADMIN > VIEW/DELETE - <asp:label id="lblCount" Runat="server"></asp:label></div>
            <br /><br />
			<div class="cathead" align="center"><asp:label class="dir" id="lblNoResult" runat="server"></asp:label></div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
			<div align="center">
			<span class="dkrgrey18b">Search By:&nbsp;&nbsp;</span><span class="dkrgrey18b">ID:&nbsp;</span><asp:TextBox ID="txtSearchById" runat="server" CssClass="black12"></asp:TextBox>&nbsp;<asp:Button OnClick="SearchNow" ID="btnSearch" runat="server" CssClass="btnStep" Text="Search" />
				<table border="0" width="100%">
            
				<asp:datalist id="dlEntryList" Width="900" runat="server" AlternatingItemStyle-BackColor="#E6E6E6" EnableViewState="true"
					OnItemDataBound="dlEntryList_OnItemDataBound" OnItemCreated="dlEntryList_OnItemCreated">
					<HeaderTemplate>
						
							<tr>
								<td width="100" class="dkrgrey16">ID&nbsp;&nbsp;Posted</td>
								<td width="100" class="dkrgrey16">Area</td>
								<td width="100" align="left" class="dkrgrey16" colspan="3">Description</td>
								<td width="20" class="dkrgrey16">Price&nbsp;</td>
								<td colspan="2" style="width:110px" class="dkrgrey16">Manage</td>
								<td class="ltgreen16b">Boost&nbsp;</td>
								<td class="midorange16b">Status&nbsp;</td>
								<td><font color="#33ccff"><b>Tweet</b></font></td>
								<td class="midorange16b">Bump</td>
							</tr>
							<tr>
								<td colspan="12" bgcolor="#ff9933"><img src="../images/s1x1.gif"></td>
							</tr>
						
					</HeaderTemplate>
					<ItemTemplate>
						<!-- TODO: This is a multi category view so we need dynamic formatting - Create a hidden control and drop the board cat to dymanically format ht/in -->
						
							<tr <%#(Container.ItemIndex%2==1)? "style='background-color:#E6E6E6'":"" %> >
								<td class="dkgrey12b" width="100">
								<%# DataBinder.Eval(Container.DataItem, "iD")%>&nbsp;&nbsp;
									<asp:Label id="label9" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "dCreateDate", "{0: MM/dd}")%>
									</asp:Label>
								</td>

								<td width="100">
									<asp:Label id="label1" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "Location")%>
									</asp:Label>
								</td>								
								
								<td align="left">
									<asp:Label id="Label3" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "iHtFt") %>'
									</asp:Label>
								</td>
								<td align="left">
									<asp:Label id="Label4" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "iHtIn") %>"
									</asp:Label>
									&nbsp;
								</td>
								<td align="left" nowrap>
									<asp:Label id="Label2" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "txtBrand") %>
									</asp:Label>
								</td>
								<td align="left">
									<asp:Label id="Label5" runat="server" CssClass="dkgrey12b">
										<%# DataBinder.Eval(Container.DataItem, "fltPrice", "{0:c}") %>
									</asp:Label>
									&nbsp;&nbsp;
								</td>
								
								<td align="left" class="controls">
							        <asp:LinkButton id="LinkButton1" runat="server" Font-Underline="true"  CssClass="dkgrey12b" OnCommand="GetValues" CommandName='<%# DataBinder.Eval(Container.DataItem, "iCategory")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>edit</asp:LinkButton>
								&nbsp;
								</td>
								<td align="left">
									<asp:LinkButton id="btnDelete" runat="server" Font-Underline="true" CssClass="dkgrey12b" OnCommand="DeleteEntry" CommandName="Delete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>delete</asp:LinkButton>
								</td>
								<td>
                                    <asp:CheckBox ID="chkBoosted"  runat="server" CssClass="dkgrey12b" Checked='<%# GetBoostedStatus(DataBinder.Eval(Container.DataItem, "iBoosted"),DataBinder.Eval(Container.DataItem, "iD"))%>' />
    								<asp:HiddenField ID="hdnItemVal" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iD")%>' />	
    								<asp:HiddenField ID="hdnUser" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "iUser")%>' />							
							    </td>
							    <td>&nbsp;
							    <asp:DropDownList ID="cboStatus" runat="server" CssClass="dkgrey12b"></asp:DropDownList><asp:HiddenField ID="hdnStatusDefaultVal" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "iStatus")%>' />
                                </td>
							    <td>
							    <asp:LinkButton id="btnTweet" runat="server" Font-Underline="true" CssClass="dkgrey12b" OnCommand="SendTweet" CommandName="Tweeter"
							     CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>Tweet</asp:LinkButton>
							    </td>
							    <td>
							    <asp:LinkButton id="lnkBump" runat="server" Font-Underline="true" CssClass="dkgrey12b" OnCommand="Bump" CommandName="Tweeter"
							     CommandArgument='<%# DataBinder.Eval(Container.DataItem, "iD")%>'>Bump</asp:LinkButton>
							    </td>							    
							    </td>
							</tr>
						
					</ItemTemplate>
					<HeaderStyle BackColor="#FFFFFF"></HeaderStyle>
				</asp:datalist>
              


				</table>
				</div>
			<div align="left"  >
				<table border="0">
					<tr><td height="20"><img src="../images/s1x1.gif"/></td></tr>
					<tr>
						<td>
                  <%--    <asp:imagebutton id="cmdPrev" onmouseover="this.src='../images/backpage2.gif'" onmouseout="this.src='../images/backpage.gif'"
								runat="server" ImageUrl="../images/backpage.gif"></asp:imagebutton>&nbsp;
							<asp:label CssClass="controls" id="lblCurrentPage" runat="server" Visible="false"></asp:label>&nbsp;
							<asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
							<asp:imagebutton id="cmdNext" onmouseover="this.src='../images/nextpage2.gif'" onmouseout="this.src='../images/nextpage.gif'"
								runat="server" ImageUrl="../images/nextpage.gif"></asp:imagebutton>--%>
                                <div class="slct_box_postmaster">
                                            <div class="btn_left">
                                                <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
                                                    runat="server" ImageUrl="../images/left_1.gif"></asp:ImageButton>
                                            </div>
                                            <div class="info_txt"> 
                                                Page </div>
                                            <asp:TextBox ID="txtCurrentPage" runat="server" CssClass="option_box" AutoPostBack="True"
                                                 OnTextChanged="lblCurrentPage_TextChanged"></asp:TextBox>
                                            <div class="info_txt">
                                                <asp:Label ID="lblcpage" runat="server" ></asp:Label>
                                            </div>
                                            <div class="btn_left_blue">
                                                <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
                                                    runat="server" ImageUrl="../images/right.gif"></asp:ImageButton></div>
                                            <div class="cls">
                                            </div>
                                        </div>

                         </td>						

					</tr>
				</table>
			</div>
               </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdPrev" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmdNext" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="cls">
        </div> 
        <div class="cls">
        </div> 
			<div align="center"><asp:Button ID="btnUpdate" class="dkgrey12b" OnClick="btnUpdate_Click" runat="server" Text="Update" /></div>
			<div align="center"><asp:label id="lblMessage" runat="server" CssClass="header"></asp:label></div>
    <div id="push">
    </div>			
		</form>
			</div>
		<br />
        <div align="center"><!-- #include file="../include/footer.aspx" --></div>
	</body>
</HTML>
