                            <div id="divComments" runat="server" align="center" style="border:solid 0px red;width:700px">
                                <div align="center">
                                    <div id='div_comment_wrapper' class="dkgrey14" align="center" style="background:#FFFFFF;height:30px">
                                     <div style="float:left; margin-top:10px">&nbsp;
                                     <asp:Label ID="lblWall" runat="server" cssclass="dkgrey24b">Dialog</asp:Label>
                                     <%--<span class="dkgrey24b">The Wall</span>--%>
                                     
                                     &nbsp&nbsp;
                                     <asp:Label ID="lblWallMessage" runat="server"><a id="toggle2" class="orange_orange14u" href="#">Login</a>
                                     or&nbsp;<a href="../register_user.aspx" class="orange_orange14u">Join</a>&nbsp;to say something.</asp:Label>
                                     </div>
                                     <div style="float:right; margin-right:10px; margin-top:10px" align="right">
                                     <asp:Label ID="lblCommentCount" Cssclass="white12" runat="server"></asp:Label></div>
                                    </div>
                                        <asp:Panel ID="pnlLoginMsg" runat="server" Visible="false" class="dkgrey12">
                                        </asp:Panel>
                                        <br />
                                        &nbsp;<asp:Panel ID="pnlLogin" runat="server" Height="120px" Width="300px" BackColor="#ffffff"
                                            BorderColor="#ff9900" BorderWidth="1px" defaultbutton="btnLogin">
                                            <table> 
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>   
                                                <tr>
                                                    <td class="dkrgrey14">
                                                        E-mail:&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsername" runat="server" Width="200"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="dkrgrey14">
                                                        Password:&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" TextMode="Password" Width="200" runat="server" onKeyDown="Check4Enter(event.keyCode);"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                                         <span class="midorange12b">or</span>&nbsp;<a href="../register_user.aspx" class="dkrgrey_orange14">join</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>   
                                            </table>
                                        </asp:Panel><br />
                                    <asp:Panel runat="server" ID="pnlComments" width="700px">
                                        <table width="700" cellpadding="0" cellspacing="0">
                                            <asp:DataList ID="dlCommentList" Width="650px" RepeatLayout="Table" BorderColor="#CC6600"
                                                BorderStyle="Solid" BorderWidth="0" runat="server" EnableViewState="false" CellSpacing="0" cellpadding="0">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--
                                                    <tr>
                                                        <td colspan="3" align="left" style="height:5px">
                                                            <img src="../images/Bubble.jpg" alt="bubble" />
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td style="background-color: #FFFFFF" align="center"><span class="ltgreen12">
                                                                <%# ShowUser(DataBinder.Eval(Container.DataItem, "txtUserName"),DataBinder.Eval(Container.DataItem, "txtEmail"))%>
                                                            </span>
                                                            &nbsp;
                                                        </td>
                                                        <td style="background-color: #FFFFFF">&nbsp;
                                                        </td>
                                                        <td style="background-color: #F0F0F0">
                                                            &nbsp;&nbsp;&nbsp;
                                                        </td>
                                                        <td style="width: 700px; background-color: #F0F0F0" class="ltgrey10"><img src="http://www.malzook.com/images/s1x1.gif" alt="" />
                                                            posted on<span class="ltgrey10">
                                                                <%# DataBinder.Eval(Container.DataItem, "dPosted", "{0: MM/dd/yy}")%>
                                                                &nbsp;
                                                            </span>
                                                        </td>
                                                        <td style="background-color: #F0F0F0">
                                                            &nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #FFFFFF" align="center">
                                                            <img height="64" width="64" src='<%# FormatPicPath(DataBinder.Eval(Container.DataItem, "userDir"),DataBinder.Eval(Container.DataItem, "profilePic"))%>' alt="profilepic" />
                                                            
                                                        </td>
                                                        <td style="background-color: #FFFFFF">
                                                            &nbsp;
                                                        </td>
                                                        <td style="background-color: #F0F0F0">
                                                            &nbsp;
                                                        </td>                                                       
                                                        <td align="left" class="dkgrey12" style="background-color: #F0F0F0">
                                                            <%# DataBinder.Eval(Container.DataItem, "txtComment") %> 
                                                        </td>
                                                        <td style="background-color: #F0F0F0">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                      </tr>
                                                    <tr>
                                                    <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:DataList></table>
                                        
                                        <br />
                                        <%--Comment Box--%>
                                        <asp:Panel ID="pnlCommentBox" runat="server" Visible="true" BackColor="#ffffff"
                                            BorderColor="#669900" BorderWidth="1" style="width:700px">
                                            <table cellpadding="0" cellspacing="0" border="0" width="354px">
                                                <tr>
                                                <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblCommentBoxHeader" runat="server" CssClass="dkrgrey14" Text="Type below and click submit."></asp:Label>
                                                    </td>
                                                    <td align="right" class="white16b">
                                                        <asp:Label runat="server" ID="lblTxtCount">400</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:TextBox ID="txtComment" runat="server" CssClass="dkrgrey14" onkeydown="javascript:CharCountAndDisplay(this.form.txtComment,400,'lblTxtCount')"
                                                            Height="120px" Width="352px" MaxLength="400" Rows="10" TextMode="MultiLine" TabIndex="70"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="50px"><asp:CheckBox id="chkNotify" CssClass="dkrgrey14" Text="&nbsp;Notify me when anyone comments" runat="server"></asp:CheckBox></td>
                                                <td align="right">
                                                        <asp:Button align="right" ID="btnPostComment" Text="Submit" runat="server" CssClass="dkrgrey14"
                                                            OnClick="btnPostComment_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td>&nbsp;</td>
                                                </tr>
                                                
                                            </table>
                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                            </div>                                    
