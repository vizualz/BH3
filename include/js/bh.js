/*
//Filename: bh.js
//This Javascript file contains some client helper functions.  As of right now is just one big
//global file.  We can organize a break it up as development continues.
*/

function CheckPro(val) {
    var oCtl;
    var oCtl2;

    if (val == '0') {
        oCtl = document.getElementById("chkUpgrade");
        if (oCtl.checked) {
            oCtl2 = document.getElementById("chkUpgrade2");
            if (oCtl2.checked)
                oCtl2.checked = false;
        }
    }

    if (val == '1') {
        oCtl = document.getElementById("chkUpgrade2");
        if (oCtl.checked) {
            oCtl2 = document.getElementById("chkUpgrade");
            if (oCtl2.checked)
                oCtl2.checked = false;
        }
    }


}

//SetElement('hdnMeVal','1');
function SetElement(ctl,val)
{
        var oCtl;
        oCtl = document.getElementById(ctl);
        if (oCtl != null)
        {
            oCtl.value = val;
        }
    
}
function Check4Enter(code)
{
    //alert(code);
    if(code == 13)
    {
        __doPostBack('btnLogin','');
    }
    
}

//var illegalChars = /\W/; // allow letters, numbers, and underscores
function Check4Enter(code)
{
    //alert(code);
    if(code == 13)
    {
        __doPostBack('btnLogin','');
    }
    
}

function clearRegisterForm()
{
        var oCtl;
        oCtl = document.getElementById("txtFullName");
        if (oCtl != null)
        {
            oCtl.value = "";
            document.forms["Form1"].elements["txtPassword1"].value = document.forms["Form1"].elements["txtEmail"].value =  "";
        }
}

/*
*/
    function CheckControl(ctlName)
    {
        var oCtl;
        oCtl = document.getElementById(ctlName);
        if (oCtl == null)
        {
            alert("null control");
            return;
        }
        
        if(oCtl.value.length == 0)
        {
          //oCtl.style.borderColor = "none";
          oCtl.style.border = "2px inset";
          oCtl.style.borderColorLeft='';
          return;  
        }     
        
        switch(ctlName)
            {
            case "txtFullName":
                if(oCtl.value.length > 0)
                {
                  //oCtl.style.border = "Green";  
                  oCtl.style.border = "2px inset";
                  oCtl.style.borderColorLeft='';
                }
                else
                {
                    oCtl.style.borderColor = "Red";
                }            
                break;
            case "txtEmail":
                
                var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
                
                if (emailPattern.test(oCtl.value))
                {
                    //oCtl.style.borderColor = "Green";
                      oCtl.style.border = "2px inset";
                      oCtl.style.borderColorLeft='';
                }
                else
                {
                    oCtl.style.borderColor = "Red";
                }
                break;    
            case "txtPassword1":
                if(oCtl.value.length >= 6)
                {
                  //oCtl.style.borderColor = "Green";
                    oCtl.style.border = "2px inset"; 
                    oCtl.style.borderColorLeft='';                     
                }
                else
                {
                    oCtl.style.borderColor = "Red";
                }              
                break;                
            }        
    }

/*
*/ 
    function resetFilter()
    {
        var oCtl;
        oCtl = document.getElementById('txtFilterKwd');
        if (oCtl != null)
        {
            oCtl.value = "";
        }
        oCtl = document.getElementById('cboPostingType');
        if (oCtl != null)
        {
            oCtl.selectedIndex = 0;
        }
        //boardtype
        oCtl = document.getElementById('cboBoardType');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }                 
        //Ht In Range
        oCtl = document.getElementById('txtHtFt');
        if (oCtl != null)
        {
            oCtl.value = "ft";
        }
        oCtl = document.getElementById('txtHtFtMax');
        if (oCtl != null)
        {
            oCtl.value = "ft";
        }
        oCtl = document.getElementById('txtHtIn');
        if (oCtl != null)
        {
            oCtl.value = "in";
        }
        oCtl = document.getElementById('txtHtInMax');
        if (oCtl != null)
        {
            oCtl.value = "in";
        }
        //Price
        oCtl = document.getElementById('txtMinPrice');
        if (oCtl != null)
        {
            oCtl.value = "Min";
        } 
        oCtl = document.getElementById('txtMaxPrice');
        if (oCtl != null)
        {
            oCtl.value = "Max";
        }                                                
        //Tail
        oCtl = document.getElementById('cboTailType');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }
        //Fins
        oCtl = document.getElementById('cboFins');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }
        //Fins
        oCtl = document.getElementById('cboLocation');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }
        //condition
        oCtl = document.getElementById('cboCondition');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }              
        //adType
        oCtl = document.getElementById('cboAdType');
        if (oCtl != null)
        {
            oCtl.selectedIndex = oCtl.length - 1;
        }                       
    }

/*
*/ 
    function swapImg(val)
    {
        var imgHolder;
        var ctl;
        imgHolder = "img" + val;
        ctl = document.getElementById(imgHolder);
        ctl.src = "http://www.malzook.com/images/greencheck.gif";
    }


/*
*/
    function ToggleText(ctl, txt)
    {
        
        var oCtl;
        oCtl = document.getElementById(ctl);
        if (oCtl != null)
        {
            if(oCtl.value == "Used for login")
            {
                oCtl.value = "";
                return;
            }
            else
            {
                if (oCtl.value == "")
                {
                    oCtl.value = txt;
                }
            }
        }
    }
	
/*
*/
    function toggleImgPanel(panel, button)
    {
        var pnl;
        var btn;
        pnl = document.getElementById(panel);
        
        //change button text
        btn = document.getElementById(button);
        if (btn.value == "Add Images...")
        {
            pnl.style.display = 'inline';
            btn.value = "No Images...";
        }
        else
        {
            pnl.style.display = 'none';
            btn.value = "Add Images...";
        }
 
    }
/*
*/
    function TogglePanel(val, panel, rval)
    {
        var pnl;
        var btn;
        
        pnl = document.getElementById(panel);
        
        if (val == rval)
        {
            pnl.style.display = 'none';
        }
        else
        {
            pnl.style.display = 'block';
            //hide
        }
    }	    
/*
*/
    function rdoClick(val)
    {

        var fileControl;
        var rdo;
        var rtn;
        var img;
        var hdn;
       
        var fileMgr = "File" + val;         //handle variable to file control
        var rdoMgr = "rdoImgMgr" + val;     //handle variable to radio control
        var imgVal = "img" + val;           //handle var for img
        var hdnCtl = "HiddenField" + val;   //handle for hidden field
        
        fileControl = document.getElementById(fileMgr);
        img = document.getElementById(imgVal);
        hdn = document.getElementById(hdnCtl);
        rtn = getRadioSelectedValue(rdoMgr);
        if (rtn == "Keep")
        {
            //show pic
            fileControl.disabled = true;
            img.src = hdn.value;
        }
        if (rtn == "Delete")
        {
            //show red x
            img.src = "images/imgDeleted.gif"
            
            fileControl.disabled = true;
        }            
        if (rtn == "Change")
        {
            //enable control
            fileControl.disabled = false;                
        } 
        if (rtn == "Add")
        {
            //enable control
            fileControl.disabled = false;                
        }           

     return;
    }
/*
*/
    function getRadioSelectedValue(radioList)
    {
        
        var rdo = document.getElementById(radioList);
        var options = rdo.getElementsByTagName('input');
        //alert(options.length);
        for(i=0;i<options.length;i++){
            var opt = options[i];
            if(opt.checked)
            {
                return opt.value;
            }
        }
    } 



/**
Show element
*/
	function ShowElement(obj, oStyle)
	{
	    if (obj != null)
	    {
	        el = document.getElementById(obj);
	        if (el != null)
            {
	            el.style.display = 'block';
	            el.style.cssText = "'" + oStyle + "'";
	        }
        }
	}

/**
Toggle element
*/
function ToggleElement(obj, val) {
    if (obj != null) {
        el = document.getElementById(obj);
        if (val == 0)
            el.disabled = true;
        else
            el.disabled = false;    
    }
}

/**
/**
Disable element
*/
	function DisableElement(obj)
	{
	    if (obj != null)
	    {
	        el = document.getElementById(obj);
            el.disabled = true;
        }
	}
	
/**
Hide element
*/
	function HideElement(obj, lblId)
	{
        
        var ctl;
        ctl = document.getElementById(obj);
        ctl.style.display = "none";
        
        if (lblId != null)
        {
            var ctl2;
            ctl2 = document.getElementById(lblId);
            if (ctl2 != null)
            {
                ctl2.innerHTML = "Please wait...";
                ctl2.style.display = "inline";        
            }
            else
            {
                alert("invisible");
            }
        }
	}
/**
Allow sz characters max for a field and display max number of chars left
*/
	function CharCountAndDisplay(txtField, iMaxLength, txtDisplayField)
	{

	    var oEl;
	    oEl = document.getElementById(txtDisplayField);  
	    
	    if (txtField == null || iMaxLength == null || oEl == null)
	    {
	        return;
	    }

	    if (txtField.value.length >= iMaxLength)
	    {
	        txtField.value = txtField.value.substring(0, iMaxLength);
	        txtField.style.borderColor = "Red";
        }
        else
        {
            oEl.innerHTML = iMaxLength - txtField.value.length;
        }
	}

	
/**
Allow sz characters max for a field
*/
	function CharCount(txtField, iMaxLength)
	{
	    if (txtField == null || iMaxLength == null)
	    {
	        return;
	    }
      
        txtField.style.borderColor = "#666666";
        
      
	    if (txtField.value.length >= iMaxLength)
	    {
	        txtField.value = txtField.value.substring(0, iMaxLength);
	        txtField.style.borderColor = "Red";
        }
	}

/**
Allow 599 characters max but only for this control TODO: OBSOLETE this function
*/
	function CountChars()
	{
	    var iMaxLength = 599;
        
	    if (document.Form1.txtDetails.value.length > iMaxLength)
	    {
	        document.Form1.txtDetails.value = document.Form1.txtDetails.value.substring(0, iMaxLength);
        }
	}

/**
Allow 150 characters max for a field
*/
	function CountMyChars(txtField,val)
	{
	    
	    if (txtField == null || val == null)
	    {
	        return;
	    }
        
        //alert("length: " + txtField.value.length);
        
	    if (txtField.value.length > val)
	    {
	        //alert("trimming: " + txtField.value.substring(0, val));
	        txtField.value = txtField.value.substring(0, val);
        }
	}

/**
//TODO: Obsolete this function due to hardcoding
Allow 150 characters max for a field
*/
	function CountCharz(txtField)
	{
	    
	    var iMaxLength = 150;
        
	    if (txtField.value.length > iMaxLength)
	    {
	        txtField.value = txtField.value.substring(0, iMaxLength);
        }
	}
	
/**
Processed on MouseOver to show highlighted rating
*/
	function ProcHover(val)
	{
        var ctl;
        var ctlRC;
        var host;
        host = location.host;  
        
        ctlRC = document.getElementById("lblRatingCount");    
        
        switch(val)
            {
            case "1":
                ctl = document.getElementById("star1");
                ctl.src= "http://" + host + "/images/target_green.gif";
                ct2 = document.getElementById("star2");
                ct2.src= "http://" + host + "/images/target_white.gif";
                ct3 = document.getElementById("star3");
                ct3.src= "http://" + host + "/images/target_white.gif";
                ct4 = document.getElementById("star4");
                ct4.src= "http://" + host + "/images/target_white.gif";
                ct5 = document.getElementById("star5");
                ct5.src= "http://" + host + "/images/target_white.gif";                

                ctlRC.innerHTML = "Ugly";
                break;
            case "2":
                ctl = document.getElementById("star1");
                ctl.src= "http://" + host + "/images/target_green.gif";
                ct2 = document.getElementById("star2");
                ct2.src= "http://" + host + "/images/target_green.gif";
                ct3 = document.getElementById("star3");
                ct3.src= "http://" + host + "/images/target_white.gif";
                ct4 = document.getElementById("star4");
                ct4.src= "http://" + host + "/images/target_white.gif";
                ct5 = document.getElementById("star5");
                ct5.src= "http://" + host + "/images/target_white.gif";                                               
            
                ctlRC.innerHTML = "Bad";
                break;
            case "3":
                ctl = document.getElementById("star1");
                ctl.src= "http://" + host + "/images/target_green.gif";
                ct2 = document.getElementById("star2");
                ct2.src= "http://" + host + "/images/target_green.gif";
                ct3 = document.getElementById("star3");
                ct3.src= "http://" + host + "/images/target_green.gif";
                ct4 = document.getElementById("star4");
                ct4.src= "http://" + host + "/images/target_white.gif";
                ct5 = document.getElementById("star5");
                ct5.src= "http://" + host + "/images/target_white.gif";                                               
                
                ctlRC.innerHTML = "Okay";
                break;
            case "4":
                ctl = document.getElementById("star1");
                ctl.src= "http://" + host + "/images/target_green.gif";
                ct2 = document.getElementById("star2");
                ct2.src= "http://" + host + "/images/target_green.gif";
                ct3 = document.getElementById("star3");
                ct3.src= "http://" + host + "/images/target_green.gif";
                ct4 = document.getElementById("star4");
                ct4.src= "http://" + host + "/images/target_green.gif";
                ct5 = document.getElementById("star5");
                ct5.src= "http://" + host + "/images/target_white.gif";                                                
                
                ctlRC.innerHTML = "Good";
                break;
            case "5":
                ctl = document.getElementById("star1");
                ctl.src= "http://" + host + "/images/target_green.gif";
                ct2 = document.getElementById("star2");
                ct2.src= "http://" + host + "/images/target_green.gif";
                ct3 = document.getElementById("star3");
                ct3.src= "http://" + host + "/images/target_green.gif";
                ct4 = document.getElementById("star4");
                ct4.src= "http://" + host + "/images/target_green.gif";
                ct5 = document.getElementById("star5");
                ct5.src= "http://" + host + "/images/target_green.gif";                               
            
                ctlRC.innerHTML = "Super!";
                break;
            default:

                break;
            }
        return;
	}
/**
//Processed on MouseOut to get back the old rating
*/	
	function GetRating()
	{
	    var oPnl;
	    oPnl = document.getElementById("pnlRatings");
	    if (oPnl == null)
	    {
	        return;
	    }
	    
	    var val;
	    var val2;
	    var ctlRatingCT;
	    var ratVal;
        val = document.getElementById("hdnRatingVal");
        val2 = document.getElementById("hdnRatingCnt");
        ctlRatingCT = document.getElementById("lblRatingCount");
        
        if (val == null)
        {
            return;
        }
        
        //ctlRatingCT.innerHTML = "";
        
        ratVal = val2.value + " rating";
        if (val2.value != 1)
        {
            ratVal += "s";
        }
        
        var host;
        host = location.host; 
        
        switch (val.value)
            {
            case "0":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_white.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_white.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_white.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_white.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_white.gif";
                       
                break;            
            case "1":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_orange.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_white.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_white.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_white.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_white.gif";                             
                break;
            
            case "2":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_orange.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_orange.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_white.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_white.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_white.gif";                          
                break;
            
            case "3":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_orange.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_orange.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_orange.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_white.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_white.gif";                          
            
                break;
            
            case "4":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_orange.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_orange.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_orange.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_orange.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_white.gif";                            
                break;
            case "5":
                    ctl = document.getElementById("star1");
                    ctl.src= "http://" + host + "/images/target_orange.gif";
                    ct2 = document.getElementById("star2");
                    ct2.src= "http://" + host + "/images/target_orange.gif";
                    ct3 = document.getElementById("star3");
                    ct3.src= "http://" + host + "/images/target_orange.gif";
                    ct4 = document.getElementById("star4");
                    ct4.src= "http://" + host + "/images/target_orange.gif";
                    ct5 = document.getElementById("star5");
                    ct5.src= "http://" + host + "/images/target_orange.gif";              
                break;
            default:
                break;                
            }
            //reset the lblRatingsCount 
            ctlRatingCT.innerHTML = ratVal;  
    }
    
/**
*/    
            function popUpHelp(arg)
            {

                switch (arg)
                {
                    case "1":
                        window.open('../help/help.aspx?val=1','monkey','width=300,height=300,resizable=no');
                        break;
                    case "2":
                        window.open('../help/help.aspx?val=2','monkey','width=300,height=305,resizable=no');
                        break;
                    case "3": //Terms of Use
                        window.open('../docs/TermsOfUse.htm','monkey','width=350,height=300,resizable=no,scrollbars=yes');
                        break;
                    case "4":
                        window.open('../help/help.aspx?val=4','monkey','width=350,height=300,resizable=no,scrollbars=yes');
                        break;
                    case "5": //Privacy Policy
                        window.open('../docs/PrivacyPolicy.htm','monkey','width=350,height=300,resizable=no,scrollbars=yes');
                        break;                                                
                        
                }

            }  
                         
/**
*/ 	
        function count()
        {
        
            ctl = document.getElementById("txtAreaCode");
            if (ctl.value.length > 2)
            {
                ctl2 = document.getElementById("txtPhoneNum");
                ctl2.focus();
            }
            return;
        }

/*
*/
    function EnableBT()
    {
    alert("enabling");
    var ctl;
    ctl = document.getElementById("cboBoardType");
    ctl.disabled = false;
    
    ctl = document.getElementById("rdoOther");
    ctl.checked = false;
    
    ctl = document.getElementById("txtOtherBoard");
    ctl.disabled = true;
    return;
    }

/*
*/
function CheckComment()
{
    ctl = document.getElementById("txtComment");
    
    if (ctl.value.length > 0)
    {
        return true;
    }
    return false;
}

/*
*/
    function ToggleBT()
    {
    
    ctl = document.getElementById("chkOther");
    //alert(ctl.checked);
    if (ctl.checked == true) //turn on txtbox; turn off dropdown
    {
      
        ctl = document.getElementById("cboBoardType");
        ctl.disabled = true;
        
        ctl = document.getElementById("txtOtherBoard");
        ctl.disabled = false;      
    
    }
    else    //turn off txtbox; turn on dropdown
    {
        ctl = document.getElementById("cboBoardType");
        ctl.disabled = false;
        
        ctl = document.getElementById("txtOtherBoard");
        ctl.disabled = true;           
    }
    
    

    return;
    }

/**
Processed on ImgThumbnail MouseOver to show rollover imgs
*/
	function ImgHover(val)
	{
        var ctl;
        var hdnCtl;
     
        //get handle to the main pic
        ctl = document.getElementById("Pic1");        
        
        switch(val)
            {
            case "1":
            hdnCtl = document.getElementById("hdnPic1URL");    //get handle to the hidden img item which user has hovered over
            ctl.src = hdnCtl.value;                     //get and set URL
                 break;
 
            case "2":
            hdnCtl = document.getElementById("hdnPic2URL");    //get handle to the hidden img item which user has hovered over
            ctl.src = hdnCtl.value;                                              
            
                break;
            case "3":
            hdnCtl = document.getElementById("hdnPic3URL");    //get handle to the hidden img item which user has hovered over
            ctl.src = hdnCtl.value;                                                
            
                break;
            case "4":
            hdnCtl = document.getElementById("hdnPic4URL");    //get handle to the hidden img item which user has hovered over
            ctl.src = hdnCtl.value;                                                
            
                break;

            default:
                break;
            }
        return;
	}

/*
Clears HTML tags: used on textbox/textarea
*/
function ClearHTMLTags()
            {
                  
                  for(var i=0;i<document.forms[0].elements.length;i++)
                  {
                        if (document.forms[0].elements[i].type == "text" || document.forms[0].elements[i].type == "textarea")
                        {
                              if (document.forms[0].elements[i].value.indexOf("<") >= 0)
                              {
                                    do
                                    {
                                          document.forms[0][i].value = document.forms[0].elements[i].value.replace("<","&lt;")
                                    }
                                    while (document.forms[0].elements[i].value.indexOf("<") >= 0);
                              }
                              
                              if (document.forms[0].elements[i].value.indexOf(">") >= 0)
                              {      
                                    do
                                    {
                                          document.forms[0][i].value = document.forms[0].elements[i].value.replace(">","&gt;")
                                    }
                                    while (document.forms[0].elements[i].value.indexOf(">") >= 0);
                              }
                        }
                  }
            }
/*
function validateTextBoxes() {
 //alert("in validate fn");
               var expression = "[^<>]+";
               var numberForms = window.document.forms.length;
               var formIndex;
               for (formIndex = 0; formIndex < numberForms; formIndex++)
               {
                    var form = document.forms[formIndex];
                    var control;
                    var i;
                    for(i = 0; i < form.elements.length; i++) {
                         control = form.elements[i];
                         if(control.type == "text" || control.type=="textarea") {
                              if(control.value == "") continue;
                                  var rx = new RegExp(expression);
                                   var matches = rx.exec(control.value);
                                   if(matches != control.value) {
                                        alert("Please Remove any < > tags in the TextBox");
                                        control.focus();
                                        return false;
                                   }
                         }
                    }
               }
               return true;
          }
*/            