<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adtest.aspx.cs" Inherits="BoardHunt.m.adtest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script runat="server"> 
string googleColor(string value, double random) { 
        string[] colorArray = value.Split(','); 
        return colorArray[(int)random % colorArray.Length]; 
} 

string googleScreenRes() { 
        string screenRes = Request.ServerVariables["HTTP_UA_PIXELS"]; 
        char delimiter = 'x'; 
        if ( screenRes == null ) { 
                screenRes = 
Request.ServerVariables["HTTP_X_UP_DEVCAP_SCREENPIXELS"]; 
                delimiter = ','; 
        } 
        if ( screenRes != null ) { 
                string[] resArray = screenRes.Split(delimiter); 
                if ( resArray.GetUpperBound(0) + 1 == 2 ) { 
                        return "&u_w=" + resArray[0] + "&u_h=" + resArray[1]; 
                } 
        } 
        return ""; 
} 

double Timer() { 
        return (DateTime.Now - DateTime.Now.Date).TotalSeconds; 
} 

</script> 


</head>
<body>
    <form id="form1" runat="server">
    <div>

<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Text" %>
    
<%
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

Response.Write(googleAdUrl);   
  
 WebClient wc = new WebClient(); 
 string googleAdOutput = wc.DownloadString(googleAdUrl); 
 Response.Write(googleAdOutput); 
%> 
    </div>
    </form>
</body>
</html>
