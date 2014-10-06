<% @ Page CodeBehind="post.aspx.cs" Language="c#" AutoEventWireup="false" EnableEventValidation="false" Inherits="BoardHunt.post" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Post Page - Boardhunt</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script src="http://maps.googleapis.com/maps/api/js?sensor=false&amp;libraries=places" type="text/javascript"></script>
    <script type="text/javascript">
        function initialize() {
            var input = document.getElementById('txtTown');
            var autocomplete = new google.maps.places.Autocomplete(input);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="include/js/superfish.js"></script>

    <script src="include/js/bh.js" type="text/javascript"></script>

    <link href="style/global.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="style/superfish.css" />

    <script type="text/javascript">
    $(document).ready(function() {

    jQuery(function(){
        jQuery('ul.sf-menu').superfish();
        });
    });        
    </script>
        <script type="text/javascript">
            //Stop Form Submission of Enter Key Press
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
            }
            document.onkeypress = stopRKey;
    </script>

</head>
<body>
    <div id="main" align="center">
        <form class="header" runat="server" id="Form1">
            <!-- #include file="include/Header.aspx" -->
            <div align="center" style="width: 200px; height: 30px; margin: 0px auto;">
                <span class="midorange14b">
                    <asp:HyperLink runat="server" ID="lnkSell" NavigateUrl="UserMenu.aspx" CssClass="orange_orange14u">Menu&nbsp;</asp:HyperLink>
                    &gt; Step 1: Post Item</span>
            </div>
            <br />
            <br />
            <div align="center">
                <div style="background-color: #F0F0F0; width: 420px">
                    <div style="background-color: #CCCCCC; width: 420px; vertical-align: middle;"><br />
                    <span class="white20b">Step 1 of 3: <span class="white20">Answer and click &quot;Next&quot;</span>
                    <br /></div>
                    
                    <div style="width: 330px; background-color: #F0F0F0" align="left"><br />
                        <span class="dkgrey16">What Type of ad?</span>
                        <br />
                        <asp:RadioButtonList ID="radioAdType" CellPadding="3" CellSpacing="3" OnDataBound="radioAdType_OnDataBound"
                            CssClass="dkrgrey16" runat="server" RepeatDirection="Horizontal" TabIndex="1">
                        </asp:RadioButtonList>
                        <br />
                        <asp:Panel ID="pnlShip" runat="server" Visible="true">
                            <span class="dkgrey16">Will you ship?</span>
                            <br />
                            <asp:RadioButtonList CellPadding="3" CellSpacing="3" ID="rdoShip" CssClass="dkrgrey16"
                                runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                <asp:ListItem Value="0" Text="No" Selected="True">No</asp:ListItem>
                                <asp:ListItem Value="1" Text="Yes">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="pnlCondition" runat="server" Visible="true">
                            <span class="dkgrey16">What kind of condition?</span>
                            <br />
                            <asp:RadioButtonList CellPadding="3" CellSpacing="3" ID="radioConditionType" CssClass="dkrgrey16"
                                runat="server" RepeatDirection="Horizontal" TabIndex="1">
                            </asp:RadioButtonList><span class="midorange12">
                                        (Postings below standards will be removed) 
                                    </span> 
                        </asp:Panel>
                              
                        <br />
                        <span class="dkgrey16">Category</span><br />
                        <asp:DropDownList ID="cboCategory" Width="200px" runat="server" CssClass="dkrgrey16"
                            TabIndex="2">
                        </asp:DropDownList>
                        <br /><br />
                        <span class="dkgrey16" align="center">General area</span><br />
                        <asp:DropDownList ID="cboRegion" Width="200px" runat="server" CssClass="dkrgrey16"
                            TabIndex="3">
                        </asp:DropDownList>
                        <br /><br />
                        <span class="dkgrey16" align="center">City, State:</span><br />
                        <asp:TextBox id="txtTown" runat="server" clientidmode="Static" type="text" size="50" CssClass="dkrgrey16" placeholder="Enter a location" autocomplete="on"  />
                        <%--<asp:TextBox ID="txtTown" Width="200" runat="server" CssClass="dkrgrey16" TabIndex="4"></asp:TextBox>--%>
                        <br />
                                    <span class="midorange12">
                                        (ex: La Jolla, CA) 
                                    </span>                        
                             
                              <%--<input id="searchTextField" runat="server" clientidmode="Static" type="text" size="50" placeholder="Enter a location" autocomplete="on" />--%>
                        <br /><br />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Height="35px" Text="Cancel" TabIndex="5" />
                        <asp:Button ID="btnNext" runat="server" CssClass="btnStep" Height="35px" Text="Next" TabIndex="6" />
                        &nbsp;<br />&nbsp;<br />
                    </div>
                </div>
                <table align="center" cellspacing="0" width="450px" border="0" style="background-color: #F0F0F0;
                    border-color: #FF9900">
                </table>
            </div>
            <asp:HiddenField ID="hdnAdType" runat="server" Value="" />
            <div id="push">
            </div>
            <br />
        </form>
    </div>
    <br />
    <br />
    <div align="center">
        <!-- #include file="include/footer.aspx" -->
    </div>
</body>
</html>
