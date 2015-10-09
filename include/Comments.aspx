                        <div class="container-fluid">    
                            <div id="divComments" runat="server" align="center" style="border:solid 0px red;">
                                <div align="center">
                                    <div id='div_comment_wrapper'  align="center" style="background:#FFFFFF">

                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:Label ID="lblWall" runat="server" cssclass="dkgrey24b">Comments</asp:Label>
                                                &nbsp&nbsp;
                                                <asp:Label ID="lblWallMessage" runat="server"><a id="toggle2" class="orange_orange14u" href="#">Login</a>
                                                or&nbsp;<a href="../register_user.aspx" class="orange_orange14u">Join</a>&nbsp;to say something.</asp:Label>
                                                <asp:Label ID="lblCommentCount" Cssclass="white12" runat="server"></asp:Label></div>
                                            </div>
                                        </div>
                                        <br>
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:Panel ID="pnlLoginMsg" runat="server" Visible="false" class="dkgrey12">
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <br>
<asp:Panel ID="pnlLogin" runat="server" BackColor="#ffffff" BorderColor="#ff9900" BorderWidth="0px" defaultbutton="btnLogin">                                               
                                        

                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mb5"><br> 
                                                <asp:TextBox ID="txtUsername" runat="server" Width="200" class="gui-input" placeholder="E-mail"></asp:TextBox>
                                            </div>       
                                        </div>
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mb5">      
                                                <asp:TextBox ID="txtPassword" TextMode="Password" Width="200" runat="server" onKeyDown="Check4Enter(event.keyCode);" class="gui-input" placeholder="Password"></asp:TextBox>
                                            </div>
                                        </div>    
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">        
                                                <asp:Button ID="btnLogin" CssClass="button btn-primary" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                                &nbsp;&nbsp
                                                or&nbsp;<a href="../register_user.aspx" class="orange_orange14u">join</a>

                                            </div>           
                                        </div>
</asp:Panel>

  
<asp:Panel runat="server" ID="pnlComments">
                                                    <asp:DataList ID="dlCommentList" RepeatLayout="Flow" BorderColor="#CC6600"
                                                    BorderStyle="Solid" BorderWidth="0" runat="server" EnableViewState="false" CellSpacing="0" cellpadding="0">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="row"> 
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                                    <span class="ltgrey10">
                                                                    <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>          
                                                                    </span>

                                                                    <img src="/images/s1x1.gif" alt="" />
                                                                    posted on<span class="ltgrey10">
                                                                    <%# DataBinder.Eval(Container.DataItem, "dPosted", "{0: MM/dd/yy}")%>
                                                                    &nbsp;
                                                                    </span>                                                          
                                                                    <img height="64" width="64" src='<%# FormatPicPath(DataBinder.Eval(Container.DataItem, "userDir"),DataBinder.Eval(Container.DataItem, "profilePic"))%>' alt="profilepic" />
                                                                <%# DataBinder.Eval(Container.DataItem, "txtComment") %> 
                                                                </div>                
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList> 
                                          

                                        <br />
                                        <%--Comment Box --%>
                                        <div class="row"> 
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                                                <asp:Label ID="lblCommentBoxHeader" runat="server" Text="Type in box and submit."></asp:Label>
                                                <asp:Panel ID="pnlCommentBox" runat="server" Visible="true" BackColor="#ffffff"
                                                    BorderColor="#669900" BorderWidth="0">
                                                    <div class="row"> 
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                                            
                                                            <asp:Label runat="server" ID="lblTxtCount">400</asp:Label>
                                                            <asp:TextBox ID="txtComment" runat="server" onkeydown="javascript:CharCountAndDisplay(this.form.txtComment,400,'lblTxtCount')"
                                                             MaxLength="400" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                                            <br>
                                                            <asp:CheckBox id="chkNotify" Text="&nbsp;Notify me on replies" runat="server"></asp:CheckBox>
                                                            <asp:Button align="right" ID="btnPostComment" Text="submit" runat="server" CssClass="button"
                                                            OnClick="btnPostComment_Click" />
                                                        </div>    
                                                    </div>
                                                </asp:Panel>
                                            </div>    
                                        </div> <!--- close row -->
 </asp:Panel>              

                                    </div>
                                </div>
                            </div>
                        <!-- </div>                 -->
                                                                        
