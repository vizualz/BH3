<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BoardHunt.m.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boardhunt - mobile surfboard web site</title>
    <link href="../style/mob_global.css" type="text/css" rel="stylesheet" />
    <script runat="server"> 
//string googleColor(string value, double random) { 
//        string[] colorArray = value.Split(','); 
//        return colorArray[(int)random % colorArray.Length]; 
//} 

//string googleScreenRes() { 
//        string screenRes = Request.ServerVariables["HTTP_UA_PIXELS"]; 
//        char delimiter = 'x'; 
//        if ( screenRes == null ) { 
//                screenRes = 
//Request.ServerVariables["HTTP_X_UP_DEVCAP_SCREENPIXELS"]; 
//                delimiter = ','; 
//        } 
//        if ( screenRes != null ) { 
//                string[] resArray = screenRes.Split(delimiter); 
//                if ( resArray.GetUpperBound(0) + 1 == 2 ) { 
//                        return "&u_w=" + resArray[0] + "&u_h=" + resArray[1]; 
//                } 
//        } 
//        return ""; 
//} 

//double Timer() { 
//        return (DateTime.Now - DateTime.Now.Date).TotalSeconds; 
//} 

</script> 
<script type="text/javascript" src="../include/js/googles.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" style="margin-top:100px">
    <img src="/images/BHLogo.gif" alt="logo" width="250"/>
    <br /><br /><br /><br />
    <asp:Button ID="btnHunt" runat="server" Text="Hunt Boards" CssClass="btnMob" 
            style="width: 330px;height: 100px" onclick="btnHunt_Click"></asp:Button><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Full Site" CssClass="btnMob" 
            style="width: 330px;height: 100px" onclick="Button1_Click"></asp:Button>
            <br />
    <asp:Literal runat="server" ID="ltrAds"></asp:Literal>
    <br />
    <asp:Label ID="lblAds" runat="server"></asp:Label>
    <div style="height:200px">&nbsp;</div>
    <span class="midgrey20">(c) 2012 Boardhunt LLC </span>

    </div>
    <p></p>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Text" %>
    
<%
    /*
double googleTime = (DateTime.Now - new 
DateTime(1970,1,1)).TotalSeconds; 
double googleDt = (1000 * googleTime) + Math.Round(1000 * Timer() - 
(int)Timer()); 
string googleScheme = "http://"; 
string https = Request.ServerVariables["HTTPS"]; 
if ( https.IndexOf("on") > -1 ) { 
        googleScheme = "https://"; 
} 
string googleHost = Server.UrlEncode(googleScheme + 
Request.ServerVariables["HTTP_HOST"]); 

string googleAdUrl = "http://pagead2.googlesyndication.com/pagead/ads?" + 
  "ad_type=text_image" + 
  "&channel=" +
  "&client=ca-mb-pub-0007702553564747" + 
  "&color_border=" + googleColor("555555", googleTime) + 
  "&color_bg=" + googleColor("EEEEEE", googleTime) + 
  "&color_link=" + googleColor("400058", googleTime) + 
  "&color_text=" + googleColor("000000", googleTime) + 
  "&color_url=" + googleColor("008000", googleTime) + 
  "&dt=" + googleDt + 
  "&format=mobile_single" + 
  "&host=" + googleHost + 
  "&ip=" + Server.UrlEncode(Request.ServerVariables["REMOTE_ADDR"]) + 
  "&markup=xhtml" + 
  "&oe=utf8" + 
  "&output=xhtml" + 
  "&ref=" + Server.UrlEncode(Request.ServerVariables["HTTP_REFERER"]) 
+ 
  "&url=" + googleHost + 
Server.UrlEncode(Request.ServerVariables["URL"]) + 
  "&useragent=" + 
Server.UrlEncode(Request.ServerVariables["HTTP_USER_AGENT"]) + 
  googleScreenRes();

//Response.Write(googleAdUrl);   
  
 WebClient wc = new WebClient(); 
 string googleAdOutput = wc.DownloadString(googleAdUrl); 
 Response.Write(googleAdOutput);
     */
%> 
    </form>

</body>
</html>
