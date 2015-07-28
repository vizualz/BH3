//////////////////////////////////////////////////////////////////////////
///
///		Project:		Boardhunt 
///		File:			index.aspx.cs
///		Project log:	
///						6/06/06  -	Not the best date to start a project log
///									Got the file upload working
///									Error in writing path to DB - check type
///						6/07/06  -	Changed imgPath type in SQL DB to txt 'char'
///									Posting seems to work but buggy with complex filenames
///						7/25/06  -	Added GlobalAuthenticate()
///						9/22/06  - 	All project logging witll be done on this page from this point forward
///									Globalized SignInOutUpMyAcct link
///									Organized global.css; Still needs a revamp
///									UserMenu delete is now working! ...I was very happy about this.
///									Web.Config now using global connectString - mucho cleaner
///						9/28/06  -	Fixed width to allow decimal values
///									post cell added to stylesheet
///									fixed layout on post_item
///						10/02/06 -	Added Edit_profile.aspx page: Allows users to change personal settings like email or phone num.			
///						10/13/06 -	revised styles to pages; Little bugs and nuiances taken care of with Fab
///						10/16/06 -	Added snowboards, sponsor me link, added colors to user menu, longer desc enables - change in db field
///						10/20/06 -	Fixed edit_item undate issue.  *STATIC is the word of the day!  Fixing posting images/verification
///									DataBound first control for Fins!
///						10/27/06 -  Last few days:  Javascript for 255 char max on textarea, "No results display"
///						10/29/06 -	Fixed Login:  Page load got removed somehow
///						10/31/06 -  Massive database fix
///						11/06/06 -  New stuff happening on architecture.  Will *NOT* have "One Page For All" as this will prevent from several
///									people working simutaneously on the project
///									Posts done for all categories except for Gear; Sell and Wanted will use same Post page;  Same search results page
///									and multiple ItemDetails, and edit details pages.  Other than that wishing I had a real office!
///						12/09/06 -	Update entry count on post (for surf only) todo: other post pages
///						01/17/07 -	Bugfix post_snow.aspx: We'll now allow a user to enter in a dec height value but remove it before posting						
///									Changed copyright
///									About revision #1
///									Hide paging controls when no paging is needed
///						02/09/07 -	Putting in the mandatory post preview page;  A lot more work than I thought!			
///						04/04/07 -  There are 4 pics now for ItemDetails
///                                 Check for null URLreferral object to allow cut/paste
///                                 ItemDetails format display (width, thickness)
///                     04/06/07 -  Search results link now reads "Search Again"
///                                 Deactivated all links but surf
///                                 Clear button for Register Page
///                                 "My Account" is now "My Menu"
///                                 Acct type removed for edit profile page
///                     04/07/07 -  Remember Me implemented (that wasn't so hard now was it???)
///                     04/10/07 -  Validator fixes on Login and Register pages
///                                 Error checking on post_item (num/denum)
///                                 Currency display fix for all list controls
///                                 Started fixes to edit_item (4 pics)
///                     04/19/07 -  Fix 4 Pic display on Item_edit (still buggy)
///                                 Add text warning for 200kb imgs
///                                 Favs bugfix - twas broke
///                                 bugfix on edit profile
///                                 Preview page shined up some
///                                 camera now an imagelink
///                                 dynamic resizing for s1x1.gif for empty pics
///                                 Edit_item details box word wrapping text now
///                                 help text style made bolder
///                                 All managers hide controls and show result label
///                                 Removed confusing edit button for pics
///                 
///
///
//////////////////////////////////////////////////////////////////////////

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DALLayer;

namespace BoardHunt
{
    public partial class index : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.TextBox txtKeywords;
        protected System.Web.UI.WebControls.Label lblSold;

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {

            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            //if (!Page.IsPostBack)
            //{
            //    BindData();
            //}

        }
/*
 */
        public void BindData()
        {
            return;

        }
/*
 */
        public void ImageButton_Click(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            string qryString;

            qryString = string.Empty;

            if (e.CommandName == "imgBtnSearch")
            {
                if (e.CommandArgument.ToString() != "0")
                    qryString += "iCat=1&bt=" + e.CommandArgument;
                else
                    qryString += "iCat=1";

                //if (txtKeywords.Text.Length > 0)
                //{
                //    desc = HttpUtility.UrlEncode(Global.CheckString(txtKeywords.Text));
                //    qryString += "&desc=" + desc;
                //}

                string redirHere = "Surfboardsforsale.aspx?" + qryString;
                Response.Redirect(redirHere, true);
            }
			else if(e.CommandName == ""){

			}
        }

/*
 */
        public string FormatHeightFt(object heightFt)
        {
            return heightFt.ToString() + "\'";
        }
        /*
         */
        public string FormatHeightIn(object heightIn)
        {
            return heightIn.ToString() + "\"" + "&nbsp;";
        }
        /*
         */
        //Fired when user clicks the DataList item.  NOTE:  This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            Response.Redirect("surfboard.aspx?" + "iD=" + e.CommandArgument.ToString() + "&uId=" + e.CommandName.ToString() + "&iCat=1");
        }
        /*
         */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk, object oVal)
        {
            //set cLen to oVal
            int cLen = Convert.ToInt32(oVal);

            //get string
            string txtChunk = oChunk.ToString();

            //if the string length is greater than our cut-off pt. -- prepare to truncate
            if (txtChunk.Length > cLen)
            {
                int n = cLen;

                //check if substring @ cLen pos. is char or whitespace
                if (txtChunk.Substring(n, 1).ToString() != " ")
                {
                    do
                    {
                        //TODO: look into this
                        //if (n >= cLength)
                        //return txtChunk;

                        n++;
                        if (n == txtChunk.Length) break;

                        if (txtChunk.Substring(n, 1).ToString() == " ")
                        {
                            break;
                        }
                    } while (n < txtChunk.Length);
                }

                //remove characters after cLen chars.
                if (txtChunk.Length > n)
                {
                    txtChunk = txtChunk.Remove(n, txtChunk.Length - n) + "...";
                }
            }
            return txtChunk;

            ////PAD with HTML white space here
            //char c = '#';
            //txtChunk = oChunk.ToString().PadRight(15, c);
            //return Global.ReplaceEx(txtChunk, "#", @"&nbsp;");
        }

/*
*/

        protected void btnSearchSurfboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Surfboardsforsale.aspx", true);
        }

        protected void btnSellSurfboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("post.aspx", true);
        }

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			Response.Redirect("login.aspx", true);
		}
    }
}
