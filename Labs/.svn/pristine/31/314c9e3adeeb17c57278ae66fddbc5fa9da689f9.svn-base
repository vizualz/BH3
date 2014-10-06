<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MenuTest2.aspx.cs" Inherits="BoardHunt.Labs.MenuTest2" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Menu Test</title>

    <script src="../include/js/m1-2b.js" type="text/javascript"></script>
    <script src="../include/js/emenu.js" type="text/javascript"></script>
    <script src="../include/js/bh.js" type="text/javascript"></script>
    <script src="../include/js/qtabs.js" type="text/javascript"></script>
    <link href="../style/tips.css" type="text/css" rel="stylesheet"/>
    <link href="../style/emenu2.css" type="text/css" rel="stylesheet"/>
    <link href="../style/global.css" type="text/css" rel="stylesheet"/>
    <link href="../style/hover.css" type="text/css" rel="stylesheet"/>
    <link href="../style/qtabs.css" type="text/css" rel="stylesheet"/>

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
    
    </script>

</head>
<body>
    <form class="header" id="Form1" action="MenuTest.aspx" enctype="multipart/form-data" runat="server" method="POST">
<script type="text/javascript">
            window.addEvent('domready', function(){
                new Element('div', {
                    id: 'debug',
                    styles: {
                        overflow: 'auto',
                        height: 100,
                        width: 200
                    }
                }).injectInside(document.body);
                new EMenu('menu1', {
                    onMenuShow: function(el){
                        //$('debug').grab(new Element('div', {text: 'show ' + el.getFirst().get('text')}), 'top');
                    },
                    onMenuHide: function(el){
                        //$('debug').grab(new Element('div', {text: 'hide ' + el.getFirst().get('text')}), 'top');
                    }
                });
            });
</script>

<script type="text/javascript">
        function navTo(p1)
        {
            myDNS=document.domain;
            myArray=myDNS.split(".");
            if(myArray.length == 2)
            {
                window.location =  "http://www." + myArray[0] + p1;
            }
            else
            {
                window.location =  "http://www." + myArray[1] + p1;
            }
        }
</script>
<div style="text-align: center; margin:0px" >
    <div align="center" style="border:solid 0px #000000; text-align: left; margin-left: auto; margin-right: auto; width: 906px;">
        <!-- Start: Ads -->
        <div align="center">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <a href="javascript:navTo('.com/index.aspx');">
                            <img src="http://www.boardhunt.com/images/BHLogo.gif" border="0">&nbsp;&nbsp;&nbsp;</a></td>
                    <td>

                        <script type="text/javascript" src="http://c.adroll.com/r/6HRX4NZQLJAHJNQCOYZCFA/DWLMZGY56BFVVKYQLNKA64/">
                        </script>

                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    
    <div align="center" style="text-align: left; margin-left: auto; margin-right: auto; width: 1600px;">
        <div align="right">
            <table width="1600px" border="0" bgcolor="#F0F0F0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" width="950px">
                        <img src="http://www.boardhunt.com/images/s1x1.gif" />
                    </td>
                    <td align="right" width="100px" class="red20b" nowrap>
                        <asp:linkbutton id="lnkSignIn" cssclass="grey_orange10" runat="server"></asp:linkbutton>
                        .
                        <asp:linkbutton id="lnkSignUp" cssclass="grey_orange10" runat="server"></asp:linkbutton>
                    </td>
                    <td align="right" width="110px" valign="bottom">
                        <a class="orange_ltgreen10u" href="javascript:navTo('.com/help/HowWeWork.aspx');">how
                            this works</a>&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="right" width="450px">
                        <img src="http://www.boardhunt.com/images/s1x1.gif">
                    </td>
                </tr>
                <tr>
                <td colspan="4">
                
                </td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#ff9900" height="3px" align="right" width="950px"><img src="http://www.boardhunt.com/images/s1x1.gif"/></td>
                </tr>
            </table>
            <br />
        </div>
        <%--MENU--%>
        <div id="menu1" align="center" class="emenu" style="border: 1px solid #000000;">
            <ul style="border: 1px solid #F00000;">
                <li>
                    <h2>
                        &nbsp;
                    </h2>
                </li>
                <li>
                    <h2>
                        &nbsp;
                    </h2>
                </li>
                <li>
                    <h2>
                        <a href="javascript:void(0);">&nbsp;Used Boards</a>
                    </h2>
                    <ul>
                        <li>
                            <ul>
                                <li><a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=1');">&nbsp;Surfboards</a></li>
                                <li><a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=2');">&nbsp;Snowboards</a></li>
                                <li><a href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=3');">&nbsp;Other
                                    boards</a></li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <h2>
                        <a class="menu" href="javascript:navTo('.com/search_results.aspx?loc=all&iCat=4');">
                            Accessories</a></h2>
                </li>
                <li>
                    <h2>
                        <a class="menu" href="javascript:navTo('.com/showcase_results.aspx');">Showcase</a></h2>
                </li>
                <li>
                    <h2>
                        <a class="menu" href="javascript:navTo('.com/Blog/BlogResults.aspx');">Board Blog&nbsp;</a>
                    </h2>
                </li>
                <li>&nbsp;<a class="bh" href="javascript:navTo('.com/index.aspx');"><span style="background-color: #98CC31;">
                    &nbsp;&nbsp;Search&nbsp;&nbsp;</span></a>
                    <asp:linkbutton id="lnkPost" class="bh" runat="server"><span style="background-color:#ff9900;">&nbsp;&nbsp;Sell&nbsp;&nbsp;</span></asp:linkbutton>
                </li>
            </ul>
            <div class="menu_content">
                <img height="3" src="http://www.boardhunt.com/images/colornavbar.gif" width="1600" />
            </div>
        </div>
    </div>

    <div>Content will go here</div>
        <div align="center">
            <!-- #include file="../include/footer.aspx" -->
        </div>
        </div> 
    </form>
   
</body>
</html>
