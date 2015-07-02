<%@ Control Language="C#" Inherits="BoardHunt.include.HeaderCtl" CodeBehind="HeaderCtl.ascx.cs" %>
<!-- Google ads: Leader -->
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mb10">
    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12" style="float: none; margin: 0 auto;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pb10">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 pn ">
                <a href="/index.aspx">
                    <img src="http://www.boardhunt.com/images/BHLogo.gif" border="0" alt="Boardhunt Logo" class="thumbnail mn" />
                </a>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 pn">
                <!-- #include file="~/include/ads/LeaderAd.htm" -->
            </div>
        </div>
    </div>
</div>
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mb20" style="background-color: #222222;">
    <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12" style="float: none; margin: 0 auto;">
        <nav class="navbar">
                <div class="navbar-header">
                    <button data-target="#myNavbar" data-toggle="collapse" class="navbar-toggle" type="button" aria-expanded="false" style="border-color: #eeeeee;">
                        <span class="icon-bar" style="background-color: #999999;"></span>
                        <span class="icon-bar" style="background-color: #999999;"></span>
                        <span class="icon-bar" style="background-color: #999999;"></span>
                    </button>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav pt20">
                        <li class="dropdown pl20">
                            <a class="dropdown-toggle fs16 pn" data-toggle="dropdown" href="/Surfboardsforsale.aspx?iCat=1">Used Surfboards<span class="caret"></span></a>
                            <ul class="dropdown-menu mtn p5">
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=1" class="fs15">Shortboard</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=2" class="fs15">Longboard</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=4" class="fs15">Modern/Retro Fish</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=8" class="fs15">Fun Shape & Eggs</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=32" class="fs15">Hybrid</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=16" class="fs15">Gun</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=64" class="fs15">Standup Paddle</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=128" class="fs15">Pro Model</a></li>
                                <li><a href="/Surfboardsforsale.aspx?iCat=1&bt=256" class="fs15">Vintage</a></li>
                            </ul>
                        </li>
                        <li class="dropdown pl20">
                            <a class="dropdown-toggle fs16 pn" data-toggle="dropdown" href="/Shaper/surfboards.aspx">New Surfboards<span class="caret"></span></a>
                            <ul class="dropdown-menu mtn p5">
                                <li><a href="/Shaper/ShaperHouse.aspx" class="fs15">ShaperHouse</a></li>
                                <li><a href="/Shaper/surfboards.aspx" class="fs15">Latest Models</a></li>
                                <li><a href="http://www.surfboardbrandshq.com/surfboard-brands/" class="fs15">Brand List</a></li>
                            </ul>
                        </li>
                        <li class="dropdown pl20">
                            <a class="dropdown-toggle fs16 pn" data-toggle="dropdown" href="#">Media<span class="caret"></span></a>
                            <ul class="dropdown-menu mn p5">
                                <li><a href="http://www.boardhunt.tumblr.com" class="fs15">Blog</a></li>
                                <li><a href="/Shaper/ShaperVideos.aspx" class="fs15">Videos</a></li>
                            </ul>
                        </li>
                        <li class="dropdown pl20">
                            <a class="dropdown-toggle fs16 pn" data-toggle="dropdown" href="/qna/list.aspx?iCat=1');">Tools<span class="caret"></span></a>
                            <ul class="dropdown-menu mtn p5">
                                <li><a href="/qna/list.aspx?iCat=1" class="fs15">Ask-a-Pro</a></li>
                                <li><a href="/Matrix.aspx" class="fs15">Board Matrix</a></li>
                            </ul>
                        </li>
                        <li class="pl20"><a href="/Surfboardsforsale.aspx?loc=all&iCat=1" class="fs16 pn">Hunt</a></li>
                        <li class="pl20">
                            <asp:linkbutton id="lnkPost" class="fs16 pn" runat="server">Sell</asp:linkbutton>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right pt20">
                        <li class="pl20">
                            <asp:linkbutton id="lnkSignUp" runat="server" class="pn fs16"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Sign up</asp:linkbutton>
                        </li>
                        <li class="pl20">
                            <asp:linkbutton id="lnkSignIn" runat="server" class="pn fs16"><span class="glyphicon glyphicon-log-in"></span>&nbsp;&nbsp;Sign in</asp:linkbutton>
                        </li>
                        <li class="pl20">
                            <asp:linkbutton id="lnkUpgradeAcct" runat="server" class="pn fs16" visible="false"><i class="fa fa-plus"></i>&nbsp;&nbsp;Upgrade</asp:linkbutton>
                        </li>
                    </ul>
                </div>
          
        </nav>
    </div>
</div>


