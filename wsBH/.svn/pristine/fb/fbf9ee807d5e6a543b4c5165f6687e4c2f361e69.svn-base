using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Web.Script.Services;
using DALLayer;
using Rss;
using System.Web.Script.Serialization;

namespace BoardHunt.wsBH
{
    /// <summary>
    /// Summary description for BHService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    //[ToolboxItem(false)]
    public class BHService : System.Web.Services.WebService
    {
/*
*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloBH()
        {
            return "Hello BH";
        }

        /*
        */
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLiveBoardCount(int iData)
        {
            ErrorLog.ErrorRoutine(false, "WS:GetLiveBoardCount");

            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"SELECT count(id) as count from tblEntry where iStatus = 1";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    return dbManager.DataReader["count"].ToString();
                }
                return "-1";
            }
            catch (Exception ex)
            {

                ErrorLog.ErrorRoutine(false, "WS:GetUserCount:Error:" + ex.Message);
                classes.Email.SendErrorEmail("WS:GetUserCount:Error");
                return "-1";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
/*
*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUserCount()
        {
            ErrorLog.ErrorRoutine(false, "GetUserCount");
            string strSQL = string.Empty;
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);

            strSQL = @"SELECT count(id) as count from tblUser";

            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.Text, strSQL);

                if (dbManager.DataReader.Read())
                {
                    return dbManager.DataReader["count"].ToString();
                }
                return "-1";
            }
            catch (Exception ex)
            {

                ErrorLog.ErrorRoutine(false, "WS:GetUserCount:Error:" + ex.Message);
                classes.Email.SendErrorEmail("WS:GetUserCount:Error");
                return "-1";
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

/*
 */
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool TestEventJSON(string strData)
        {
            ErrorLog.ErrorRoutine(false, "strData:" + strData);
            ErrorLog.ErrorRoutine(false, "TestEventJSON");
            return true;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int isPro(int uID)
        {

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

            //todo: check services table for entry with id and status = 1; if cool then enable btnNudge

            try
            {
                int retVal = 0;

                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@UserID", uID);
                dbManager.AddParameters(1,"@returnValue",null,ParameterDirection.ReturnValue);

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "IsPro");
                retVal = Convert.ToInt32(dbManager.Parameters[1].Value);

                return retVal;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:IsPro:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:IsPro:IsPro Failed: " + ex.Message);
                return 0;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            
        }
      
        public void boost(int uID,int uEntryId)
        {
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            try
            {
                int retVal = 0;

                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@UserID", uID);
                dbManager.AddParameters(1, "@EntryId", uEntryId);
                //dbManager.AddParameters(2, "@returnValue", null, ParameterDirection.ReturnValue);

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateBoost");
                //retVal = Convert.ToInt32(dbManager.Parameters[1].Value);

                //return retVal;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:IsPro:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:IsPro:IsPro Failed: " + ex.Message);
             
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CreateRSS()
        {
            ErrorLog.ErrorRoutine(false, "RSSCreated");
            string strSQL = string.Empty;
            strSQL = @"Select TOP 5 e.iD, e.iUser, e.iCategory, e.iHtFt, e.iHtIn, e.txtBrand, e.txtDetails, e.txtOtherBoardType, e.txtGearItem, e.fltPrice, e.dCreateDate, e.txtImgPath1, tblUser.userDir
                       FROM tblEntry e
                       INNER JOIN tblUser ON e.iUser = tblUser.iD
                       WHERE adtype = '1' AND iCategory = '1' 
                       ORDER BY e.dCreateDate DESC";

            DataSet dsItems = new DataSet();
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            try
            {
                dbManager.Open();
                dsItems = dbManager.ExecuteDataSet(CommandType.Text, strSQL);

                RssChannel channel = new RssChannel();
                foreach (DataRow dr in dsItems.Tables[0].Rows)
                {
                   RssItem item = new RssItem();

                    item.Title = dr["iHtFt"].ToString() + "' " + dr["iHtIn"].ToString() + "\" " + dr["txtBrand"].ToString() + ": " + Global.DecodeCategory(dr["iCategory"]);
                    item.Link = new Uri("http://www.malzook.com/surfboard.aspx?iD=" + dr["iD"].ToString());

                    string strUrl = string.Empty;
                    if (dr["txtImgPath1"] != DBNull.Value && dr["txtImgPath1"].ToString().Length > 1)
                    {
                        string strUserDir = Global.ReplaceEx(dr["userDir"].ToString(), @"\", @"/");
                        strUrl = "<img width=\"75\" height=\"75\" src=\"" + GetPicPath("thmbNail_" + dr["txtImgPath1"].ToString(), strUserDir) + "\"/>";
                    }
                    item.Description = strUrl + Global.FormatDetails(dr["txtDetails"], (int)50);
                    item.PubDate = Convert.ToDateTime(dr["dCreateDate"].ToString());

                    channel.Items.Add(item);
                }

                channel.Generator = "Boardhunt RSS Generator";
                channel.Title = "Boardhunt: Used Surfboards for Sale";
                channel.Description = "Boardhunt: Latest Boards";
                channel.LastBuildDate = channel.Items.LatestPubDate();
                channel.Link = new Uri("http://www.malzook.com/rss/surfboards.xml");

                RssImage rssImg = new RssImage();
                rssImg.Link = new Uri("http://www.malzook.com");
                rssImg.Title = "Boardhunt logo";
                rssImg.Height = 100;
                rssImg.Width = 160;
                rssImg.Url = new Uri("http://www.malzook.com/images/BHLogo.gif");
                rssImg.Description = "Boardhunt is the online surfboard marketplace that allows searching and selling of used surfboards";
                channel.Image = rssImg;

                RssFeed feed = new RssFeed();
                feed.Channels.Add(channel);
                feed.Write(Server.MapPath(".\\..\\rss\\") + "surfboards.xml");

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Admin:CreateRSS:" + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }  
        }
/*
 */
        public void InsertBoardForRatings(int bId)
        {
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@EntryId", bId);

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "[sp_InsertBoardForRating]");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:InsertBoardForRatings:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:InsertBoardForRatings:Error: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

/*
    */
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool AddVote(int bVal, int iEntry)
        {
            //bVal: 0 = thumbs down ; 1 = thumbs up 

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {

                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@bVal", bVal);
                dbManager.AddParameters(1, "@EntryId", iEntry);

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "[sp_AddVote]");
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:AddVote:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:AddVote:Error: " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

        }
/*
*/
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public classes.Vote GetVotes(int iEntry)
        {
            //bVal: 0 = thumbs down ; 1 = thumbs up 

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            classes.Vote iVote = new classes.Vote();

            //try
            //{

            //    iVote.thumbsdown = 8;
            //    iVote.thumbsup = 10;
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.ErrorRoutine(false, "Error: GetVotes: " + ex.Message);
            //}
            //finally
            //{
            //    dbManager.Close();
            //    dbManager.Dispose();
            //}
            //return iVote;


            try
            {
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@EntryId", iEntry);

                dbManager.Open();
                dbManager.ExecuteReader(CommandType.StoredProcedure, "[sp_GetVotes]");
                if (dbManager.DataReader.Read())
                {
                    iVote.thumbsdown = Convert.ToInt32(dbManager.DataReader["ithumbsdown"]);
                    iVote.thumbsup = Convert.ToInt32(dbManager.DataReader["ithumbsup"]);
                }

                //return iVote;

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:GetVotes:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:GetVotes:Error: " + ex.Message);

            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
            return iVote;
        } 

/*
 */
        public void ToggleBoostStatus(int usr, int iAll, int bId, int status)
        {
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString; ;

            try
            {
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "@UseriD", usr);
                dbManager.AddParameters(1, "@BoostAll", iAll);
                dbManager.AddParameters(2, "@BoardiD", bId);
                dbManager.AddParameters(3, "@BoostBit", status);

                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ToggleBoostStatus");

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ws:ToggleBoostStatus:Error: " + ex.Message);
                classes.Email.SendErrorEmail("ws:ToggleBoostStatus:Error: " + ex.Message);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        
        }
      
/*
 */
        public string GetPicPath(object imgPicPath, string uD)
        {
            string imgPath;
            string strServerURL;

            strServerURL = System.Configuration.ConfigurationSettings.AppSettings["ServerURL"];

            //if the imgPicPath is null or empty then just display a blank white area
            if (imgPicPath == DBNull.Value || imgPicPath.ToString() == "")
            {
                imgPath = strServerURL + "/images/s1x1.gif";
            }
            else
            {
                imgPath = strServerURL + "/users/" + uD + "surfboards/" + Path.GetFileName(imgPicPath.ToString());
            }
            return imgPath;
        }
    }
}
