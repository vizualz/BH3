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
    public partial class index2 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        protected System.Web.UI.WebControls.DropDownList cboLocation;

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
            this.lnkSignIn.Click += new System.EventHandler(this.lnkSignIn_Click);
            this.lnkSignUp.Click += new System.EventHandler(this.lnkSignUp_Click);
            this.lnkPost.Click += new System.EventHandler(this.lnkPost_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                //lnkSignIn.Text = Global.SetLnkSignIn();
                //lnkSignUp.Text = Global.SetLnkSignUp();
                BindData();
            }
        }
/*
 */
        public void BindData()
        {

        }
/*
 */
        public void ImageButton_Click(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            string desc;
            string qryString;

            qryString = string.Empty;

            //build query string
            //if (cboLocation.SelectedItem.Text == "All")
            //{
            //    qryString = "loc=all";
            //}
            //else
            //{
            //    qryString = "loc=" + cboLocation.SelectedItem.Value;
            //}

            if (e.CommandName == "ImageBtn")
            {
                qryString += "iCat=1&bt=" + e.CommandArgument;;

                //if (txtKeywords.Text.Length > 0)
                //{
                //    desc = HttpUtility.UrlEncode(Global.CheckString(txtKeywords.Text));
                //    qryString += "&desc=" + desc;
                //}

                string redirHere = "Surfboardsforsale.aspx?" + qryString;
                Response.Redirect(redirHere, false);
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
        public void View_ItemDetail(object sender, DataListCommandEventArgs e)
        {

        }
/*
 */
        private void lnkSignIn_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignIn.Text);
        }
/*
*/
        private void lnkSignUp_Click(object sender, System.EventArgs e)
        {
            Global.NavigatePage(lnkSignUp.Text);
        }
/*
*/
        private void lnkPost_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("post.aspx");
        } 
    }
}
