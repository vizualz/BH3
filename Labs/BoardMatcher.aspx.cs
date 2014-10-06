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

namespace BoardHunt.Labs
{
    public partial class BoardMatcher : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DropDownList cboExperience;
        protected System.Web.UI.WebControls.TextBox txtWeight;
        protected System.Web.UI.WebControls.TextBox txtHeightFt;
        protected System.Web.UI.WebControls.TextBox txtHeightIn;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {

            ListItem liA = new ListItem("Beginner","0");
            ListItem liB = new ListItem("Imtermediate", "1");
            ListItem liC = new ListItem("Pro", "2");

            cboExperience.Items.Add(liA);
            cboExperience.Items.Add(liB);
            cboExperience.Items.Add(liC);
        
        }
/*
 */
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int tmpHtIn;
            int tmpHtFt;
            string tmpBoardType = string.Empty;
            int tmpWeight;

            tmpHtIn = Convert.ToInt16(txtHeightIn.Text);
            tmpHtFt = Convert.ToInt16(txtHeightFt.Text);
            tmpWeight = Convert.ToInt16(txtWeight.Text);

            switch (cboExperience.SelectedValue)
            {
                //beginner @height + 10in
                case "0":
                    tmpHtIn += 10;
                    if (tmpHtIn > 11)
                    {
                        tmpHtIn -= 12;   //reset
                        tmpHtFt += 1;    //scale
                    }
                    tmpBoardType = "Go longboard: "; 
                    break;
                //intermediate  @height + 5 in     
                case "1":
                    tmpBoardType = "Go funshape: ";
                    break;
                //pro @height
                case "2":
                    tmpBoardType = "Shortboard: ";
                    break;
            }
            lblResult.Text = tmpBoardType + tmpHtFt + "\"" + tmpHtIn + "'";
            if (tmpWeight > 200)
                lblResult.Text += " AND a little thicker in the rails";
            
        }


    }
}
