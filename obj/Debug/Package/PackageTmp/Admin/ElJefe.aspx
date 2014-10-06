<%@ Page Language="c#" Codebehind="ElJefe.aspx.cs" AutoEventWireup="True" Inherits="BoardHunt.Admin.ElJefe1" EnableEventValidation="false"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>BoardHunt ...Your search starts here</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../style/global.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript" src="../include/js/superfish.js"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" media="screen" href="../style/superfish.css" />
    <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />

    <script type="text/javascript">
          $(document).ready(function() {
		    jQuery(function(){
			    jQuery('ul.sf-menu').superfish();
		    });
          });
        </script>
            <style type="text/css">
    body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        
   .mGrid {   
        background-color: #fff ;   
        border: solid 1px #525252 ;   
        border-collapse:collapse ;   
    }  
    .mGrid td {   
         
        border-bottom: 6px solid #FFFFFF;
      padding: 4px;
       color: #666666;
    font-family: Trebuchet MS;
    font-size: 10px;
    }  
    .mGrid th {   
   
     border-bottom: 3px solid #FF9933;
    font-weight: lighter;
    padding: 9px 2px; 
     color: #999999;
    font-family: Trebuchet MS;
    font-size: 16px;
    font-weight: bold;
    }  
    
      </style>
</head>

<body>
    <div id="main" align="center">

        <form id="Form1" method="post" runat="server">
        <!-- #include file="../include/Header.aspx" -->
        <div class="dkgrey18v" align="center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          
            <asp:HyperLink runat="server" ID="lnkMenu" NavigateUrl="Admin.aspx" CssClass="grey_grey22">ADMIN</asp:HyperLink>
            > USER ADMIN
            <asp:Label ID="lblCount" runat="server"></asp:Label><br />
            <br />
            <asp:DropDownList ID="cboFilter" runat="server" CssClass="midorange16b" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div class="cathead" align="center">
        
        <div align="center"><asp:Label class="dir" ID="lblNoResult" runat="server"></asp:Label></div>
        
            <table border="1" cellpadding="1" cellspacing="1">

                <asp:GridView ID="dlEntryList1" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                    EmptyDataText="No Record Found!" Width="720px" AlternatingRowStyle-CssClass="alt"
                    BorderWidth="0px" EnableModelValidation="True" GridLines="None" CssClass="mGrid ">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbliD" runat="server" Text='<%# Eval("iD") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Full Name">
                            <ItemTemplate>
                                <asp:Label ID="lbltxtFullName" runat="server" Text='<%# Eval("txtFullName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <asp:Label ID="lbltxtEmail" runat="server" Text='<%# Eval("txtEmail") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AcctType">
                            <ItemTemplate>
                                <asp:Label ID="lbliAcctType" runat="server" Text='<%# Eval("iAcctType") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EntryCnt">
                            <ItemTemplate>
                                <asp:Label ID="lbliEntryCount" runat="server" Text='<%# Eval("iEntryCount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sign-up">
                            <ItemTemplate>
                                <asp:Label ID="lbldCreateDate" runat="server" Text='<%# Eval("dCreateDate", "{0: MM/dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lbliStatus" runat="server" Text='<%# Eval("iStatus") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ShowPhone#">
                            <ItemTemplate>
                                <asp:Label ID="lbliShowPhoneNum" runat="server" Text='<%# Eval("iShowPhoneNum") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Change">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Font-Underline="true" CssClass="controls2"
                                    OnCommand="EditUser">edit</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Voucher">
                            <ItemTemplate>
                                <asp:Label ID="lbliVoucher" runat="server" Text='<%# Eval("iVoucher") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <PagerStyle />
                    <RowStyle BackColor="#E6E6E6" />
                </asp:GridView>
            </table>
        </div>
        <div align="center" width="100px">
            <table border="0">
                <tr>
                    <td height="20" colspan="3">
                        <img src="../images/s1x1.gif">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <div class="slct_box">
                            <div class="btn_left">
                                <asp:ImageButton ID="cmdPrev" onmouseover="this.src='../images/left.gif'" onmouseout="this.src='../images/left_1.gif'"
                                    runat="server" ImageUrl="../images/left_1.gif"></asp:ImageButton>
                            </div>
                            <div class="info_txt">
                                Page
                            </div>
                            <asp:TextBox ID="txtCurrentPage" runat="server" CssClass="option_box" AutoPostBack="True"
                                Visible="false" OnTextChanged="txtCurrentPage_TextChanged"></asp:TextBox>
                            <div class="info_txt">
                                <asp:Label ID="lblcpage" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="btn_left_blue">
                                <asp:ImageButton ID="cmdNext" onmouseover="this.src='../images/right_1.gif'" onmouseout="this.src='../images/right.gif'"
                                    runat="server" ImageUrl="../images/right.gif"></asp:ImageButton></div>
                            <div class="cls">
                            </div>
                        </div>
                        <!-- select box ends-->
                        <asp:LinkButton ID="lnkFirst" Text="first" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lnkLast" Text="last" runat="server" Visible="false" CssClass="grey_orange12u"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnStep" Text="Update" />
                                    <asp:Button ID="btndownload" runat="server" CssClass="btnStep" Text="Download Email Contact"
                                        OnClick="btndownload_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
      
          
        <div align="center">
            <asp:Label ID="lblMessage" runat="server" CssClass="header"></asp:Label>
        </div>
        <div id="push">
          
        </div>
        </form>
    </div>
    <br />
    <div align="center">
        <!-- #include file="../include/footer.aspx" -->
    </div>
</body>
</html>
