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
using System.Data.SqlClient;
using DALLayer;

namespace BoardHunt.Qna
{
    
    public partial class QManager : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.LinkButton lnkSignIn;
        protected System.Web.UI.WebControls.LinkButton lnkSignUp;
        protected System.Web.UI.WebControls.LinkButton lnkPost;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Put user code to initialize the page here
                lnkSignIn.Text = Global.SetLnkSignIn();
                lnkSignUp.Text = Global.SetLnkSignUp();

                Global.AuthenticateUser();
            }

            // Call the LoadData method to populate control,
            //LoadData();

            ItemsGet();

            //Page.DataBind();
        }

        protected void LoadData()
        {

            string strSQL;

            hndUserId.Value = Session["userId"].ToString();

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            //Formulate SQL
            strSQL = @"SELECT q.QiD, q.Cat, q.status, q.CreateDate, q.CloseDate, q.PublishFlg, q.Question, q.iUser, q.iViews, q.NotifyFlg
                       FROM Questions q 
                       WHERE iUser = '" + Session["userId"].ToString() + "'";
            strSQL += " ORDER BY CreateDate DESC";

            ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);

            //query to get the service info
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {

                    try
                    {
                        dlEntryList.DataSource = dbManager.DataReader;
                        dlEntryList.DataBind();

                        ErrorLog.ErrorRoutine(false, "QManager:LoadData:Done");
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorRoutine(false, "Error:QManager:LoadData: " + ex.Message);
                    }
                }
                else
                {
                    //lblClosing.Text = "Whoops - an error occured somewhere here.  Please try again.";
                    ErrorLog.ErrorRoutine(false, "QManager:LoadData:Nothing to read");
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:OrderForm:LoadOneTimePurchase:Msg: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }
/*
 */ 
        //Fired when user clicks the edit link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
        public void GetValues(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            Response.Redirect("PostQ.aspx?" + "q=" + e.CommandArgument.ToString() + "&uId=" + hndUserId.Value);
        }
/*
 */ 
        //Fired when user clicks the view link.  NOTE: This handler will not fire unless VIEWSTATE is set to False.
        public void ViewPage(object src, CommandEventArgs e)
        {
            //Go to edit item page			
            Response.Redirect("QDetails.aspx?" + "q=" + e.CommandArgument.ToString());
        }
/*
 */
        public bool GetPublishedStatus(object objStat)
        {
            if (objStat.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
/*
 */
        public bool GetNotifyStatus(object objStat)
        {

            ErrorLog.ErrorRoutine(false, "QManager:GetNotifyStatus");

            if (objStat.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
/*
*/
        public void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserMenu.aspx", true);
        }

/*
*/
        public void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                //instantiate Q class
                classes.Question oQuestion = new classes.Question();

                //iterate list control and set values
                if (dlEntryList.Items.Count > 0)
                {
                    foreach (DataListItem item in dlEntryList.Items)
                    {
                        CheckBox pubNotify = item.FindControl("chkNotify") as CheckBox;
                        if (pubNotify.Checked == true)
                        {
                            //find the id and publish it
                            HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                            oQuestion.UpdateNotifyValue(hdnVal.Value, "1");

                        }
                        else
                        {
                            //find the id and un-publish it
                            HiddenField hdnVal = item.FindControl("hdnItemVal") as HiddenField;
                            oQuestion.UpdateNotifyValue(hdnVal.Value, "0");
                        }
                    }

                }

                ItemsGet();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error Updating Blog for Publish: " + ex.Message);
                return;
            }

            finally { }



        }
/**
 */
        public void dlEntryList_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Error:QManager:dlEntryList_OnItemDataBound");
            
            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {
                //LinkButton lnkbtn = (LinkButton)e.Item.FindControl("btnDelete");
                //if (lnkbtn != null)
                //{
                //    lnkbtn.Attributes.Add("OnClick", "if(confirm('Are you sure you want to delete this item?')==false){event.returnValue=false;return false;}else{return true;}");

                //}

                //LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                //if (lnkbtn2 != null)
                //{

                //    lnkbtn2.Attributes.Add("OnClick", "if(confirm('Are you sure you want to tag this item as sold?')==false){event.returnValue=false;return false;}else{return true;}");
                //    //if (lnkbtn2.Text == "SOLD") {lnkbtn2.Enabled = false; }
                //}

            }
        }
/**
 */
        public void dlEntryList_OnItemCreated(object sender, DataListItemEventArgs e)
        {
            ErrorLog.ErrorRoutine(false, "Error:QManager:dlEntryList_OnItemCreated");
            
            if (e.Item.ItemType != ListItemType.Header || e.Item.ItemType != ListItemType.Footer)
            {

                //LinkButton lnkbtn2 = (LinkButton)e.Item.FindControl("lnkBtnSold");
                //if (lnkbtn2 != null)
                //{
                //    if (lnkbtn2.Text == "SOLD") { lnkbtn2.Enabled = false; }

                //}

            }
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
            Response.Redirect("../post.aspx");

        }
/*
 */
        private void ItemsGet()
        {
            //declare variables	
            string strSQL;
            string myConnectString;

            //Create connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                //Formulate SQL
                strSQL = @"SELECT q.QiD, q.Cat, q.status, q.CreateDate, q.CloseDate, q.PublishFlg, q.Question, q.iUser, q.iViews, q.NotifyFlg
                       FROM Questions q 
                       WHERE iUser = '" + Session["userId"].ToString() + "'";
                strSQL += " ORDER BY CreateDate DESC";

                // Read sample item info from SQL into a DataSet
                DataSet dsItems = new DataSet();

                SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, myConnection);

                objAdapter.Fill(dsItems, "tblEntry");
                int listCount = dsItems.Tables["tblEntry"].Rows.Count;

                //Do we need to display the back and forward controls?
                if (listCount <= (int)15)
                {
                    //If search yields no results, set message
                    if (listCount == (int)0)
                    {
                        lblNoResult.Text = "Your currently have no entries.";
                        dlEntryList.Visible = false;
                    }

                    //HidePaging();
                }

                lblCount.Text = "(" + listCount.ToString() + ")";

                // Populate the repeater control with the Items DataSet
                
                //PagedDataSource objPds = new PagedDataSource();
                //objPds.DataSource = dsItems.Tables[0].DefaultView;
                //objPds.AllowPaging = true;
                //objPds.PageSize = 15;

                //objPds.CurrentPageIndex = CurrentPage;

                //lblCurrentPage.Text = " " + (CurrentPage + 1).ToString() + " of "
                //    + objPds.PageCount.ToString();

                //// Disable Prev or Next buttons if necessary
                //cmdPrev.Enabled = !objPds.IsFirstPage;
                //cmdNext.Enabled = !objPds.IsLastPage;

                //bind to DataList control
                dlEntryList.DataSource = dsItems;
                dlEntryList.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:PageManager:ItemsGet(): " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }
/*
 */
        //Returns truncated string with configurable number of characters
        public string FormatDetails(object oChunk)
        {
            //set cLen to oVal
            int cLen = (int)45;

            //get string
            string txtChunk = oChunk.ToString();

            //if the string length is greater than our cut-off pt. prepare to truncate
            if (txtChunk.Length > cLen)
            {

                int n = cLen;

                //check if substring @ cLen pos. is char or whitespace
                if (txtChunk.Substring(n, 1).ToString() != " ")
                {

                    do
                    {
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
        }
         
    }
}
