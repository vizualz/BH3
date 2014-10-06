<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Moo.aspx.cs" Inherits="BoardHunt.Labs.Moo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>MooTips Test</title>

    <script src="../include/js/m1-2b.js" type="text/javascript"></script>

    <script src="../include/js/emenu.js" type="text/javascript"></script>

    <script src="../include/js/bh.js" type="text/javascript"></script>

    <script src="../include/js/qtabs.js" type="text/javascript"></script>

    <link href="../style/tips.css" type="text/css" rel="stylesheet">
    <link href="../style/emenu.css" type="text/css" rel="stylesheet">
    <link href="../style/global.css" type="text/css" rel="stylesheet">
    <link href="../style/hover.css" type="text/css" rel="stylesheet">
    <link href="../style/qtabs.css" type="text/css" rel="stylesheet">

    <script language="javascript" type="text/javascript">
			// ajax function declaration
		
    function GetXmlHttpObject() 
    {
        var xmlHttp=null;
        try 
            {
                // Firefox, Opera 8.0+, Safari
                xmlHttp=new XMLHttpRequest();
            } 
        catch (e) 
            {
                //Internet Explorer
                try {
                        xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");
                    } 
                catch (e) 
                    {
                        xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
                    }
            }
        return xmlHttp;
    }     
/*
*/    
    function ajSearch()
    {
        var file = "SearchItems.aspx?";
       
        
        //var postData = "Sort_Dir=" + sortDir + "&Sort_By=" + sortByField + "&Specials=1&Start_Num=" + Start_Num + "&End_Num=" + End_Num;
        var postData = "x=1";
        
        
        xmlHttp=GetXmlHttpObject();
        //xmlHttp.onreadystatechange = sendResponse();
        xmlHttp.open('POST',file,false);
        xmlHttp.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
        xmlHttp.send(postData); 
        
        alert("sending ajax");
        
        var temp = xmlHttp.responseText;
        
        //document.getElementById('sandbox').innerHTML = xmlHttp.responseText;
        alert("returned: " + temp);    

    }
    
    window.addEvent('domready', function() {
        //MooTips
        var Tips1 = new Tips($$('.Tips1'),
        {
            maxTitleChars: 50,
            offsets: {'x':15,'y':-10}
        });
        
        var opt = {
        flexHeight: true		
        };
        var t2 = new QTabs('ex2', opt);         
    
    });    
    </script>

</head>
<body>
    <form class="header" id="Form1" runat="server"
        method="POST">
        <!-- #include file="../include/header.aspx" -->
        <asp:Label ID="lbltitles" runat="server"></asp:Label>
        <br />
        <div style="border:solid 1px Blue; text-align: left; margin-left: auto; margin-right: auto;">
            <div>
                <!-- Example 2 -->
                <h2>
                    Example 2: flexible height tabs</h2>
                <div class="qtwrapper qtwrap-round1">
                    <div class="qthead-round1">
                        <ul class="qtabs" id="qtabs-ex2">
                            <li><span>First Tab</span></li>
                            <li><span>Second Tab</span></li>
                            <li><span>Third Tab</span></li>
                        </ul>
                    </div>
                    <div class="qtcurrent current-round1" id="current-ex2">
                        <div class="qtcontent">
                            This is the <b>First Tab</b> content
                        </div>
                        <div class="qtcontent">
                            This is the <b>Second Tab</b> content
                        </div>
                        <div class="qtcontent">
                            <img src="../images/apple.jpg" align="left" alt="An apple">This is the <b>Third Tab</b>
                            content<br />
                            <b>flexHeight</b> is <i>true</i> in class options: container height is increased
                            to fit content.
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:TextBox ID="txtBrand" runat="server" onkeyup="ajSearch()"></asp:TextBox>
        </div>
        <p>
        </p>
        <div id="sandbox">
            data to go here
        </div>
        <div align="center">
            <!-- #include file="../include/footer.aspx" -->
        </div>
    </form>
</body>
</html>
