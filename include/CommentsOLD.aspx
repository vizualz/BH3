                        <div class="container-fluid">    
                            <div id="divComments" runat="server" align="center" style="border:solid 0px red;">
                                <div align="center">
                                    <div id='div_comment_wrapper' class="dkgrey14" align="center" style="background:#FFFFFF;height:30px">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:Label ID="lblWall" runat="server" cssclass="dkgrey24b">Comments</asp:Label>
                                                &nbsp&nbsp;
                                                <asp:Label ID="lblWallMessage" runat="server"><a id="toggle2" class="orange_orange14u" href="#">Login</a>
                                                or&nbsp;<a href="../register_user.aspx" class="orange_orange14u">Join</a>&nbsp;to say something.</asp:Label>
                                                <asp:Label ID="lblCommentCount" Cssclass="white12" runat="server"></asp:Label></div>
                                            </div>
                                        </div> 
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:Panel ID="pnlLoginMsg" runat="server" Visible="false" class="dkgrey12">
                                                </asp:Panel>
                                                <br />&nbsp;
                                                <asp:Panel ID="pnlLogin" runat="server" Height="120px" BackColor="#ffffff"
                                                BorderColor="#ff9900" BorderWidth="1px" defaultbutton="btnLogin">
                                            </div>
                                        </div>
                                        
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                E-mail:   
                                                <asp:TextBox ID="txtUsername" runat="server" Width="200"></asp:TextBox>
                                            </div>       
                                        </div>
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">        
                                                Password:&nbsp;
                                            </div>
                                        </div> 
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">      
                                                <asp:TextBox ID="txtPassword" TextMode="Password" Width="200" runat="server" onKeyDown="Check4Enter(event.keyCode);"></asp:TextBox>
                                            </div>
                                        </div>    
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">           
                                                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                                &nbsp;&nbsp
                                                <span class="midorange12b">or</span>&nbsp;<a href="../register_user.aspx" class="dkrgrey_orange14">join</a>
                                                </asp:Panel><br />
                                            </div>           
                                        </div>
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
                                                <asp:Panel runat="server" ID="pnlComments">
                                                    <asp:DataList ID="dlCommentList" RepeatLayout="Table"                    BorderColor="#CC6600"
                                                    BorderStyle="Solid" BorderWidth="0" runat="server" EnableViewState="false" CellSpacing="0" cellpadding="0">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                    <span class="ltgrey10">
                                                    <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>          
                                                    </span>
                                            </div>              
                                        </div>    
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                                                <img src="http://www.malzook.com/images/s1x1.gif" alt="" />
                                                posted on<span class="ltgrey10">
                                                <%# DataBinder.Eval(Container.DataItem, "dPosted", "{0: MM/dd/yy}")%>
                                                &nbsp;
                                                </span>                                                          
                                                <img height="64" width="64" src='<%# FormatPicPath(DataBinder.Eval(Container.DataItem, "userDir"),DataBinder.Eval(Container.DataItem, "profilePic"))%>' alt="profilepic" />
                                                <%# DataBinder.Eval(Container.DataItem, "txtComment") %> 
                                                    </ItemTemplate>
                                                    </asp:DataList> 
                                            </div>                
                                        </div>

                                        <br />
    <%--Comment Box-->
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                                                <asp:Panel ID="pnlCommentBox" runat="server" Visible="true" BackColor="#ffffff"
                                                    BorderColor="#669900" BorderWidth="1" style="width:700px">
                                                    <div class="row"> 
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
                                                            <asp:Label ID="lblCommentBoxHeader" runat="server" CssClass="dkrgrey14" Text="Type below and click submit."></asp:Label>
                                                            <asp:Label runat="server" ID="lblTxtCount">400</asp:Label></td>
                                                            <asp:TextBox ID="txtComment" runat="server" CssClass="dkrgrey14" onkeydown="javascript:CharCountAndDisplay(this.form.txtComment,400,'lblTxtCount')"
                                                            Height="120px" Width="352px" MaxLength="400" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                                            <asp:CheckBox id="chkNotify" CssClass="dkrgrey14" Text="&nbsp;Notify me when anyone comments" runat="server"></asp:CheckBox></td>
                                                            <asp:Button align="right" ID="btnPostComment" Text="Comment" runat="server" CssClass="dkrgrey14"
                                                            OnClick="btnPostComment_Click" />
                                                        </div>    
                                                    </div>
                                                </asp:Panel>
                                            </div>    
                                        </div> 
                                        </asp:Panel>              
                                    </div>
                                </div>
                            </div>
                        </div>                
                                                                        
