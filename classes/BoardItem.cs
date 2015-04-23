using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DALLayer;

namespace BoardHunt.classes
{

    public class BoardItem : BaseItem
    {
        //=======================================
        //Private Class Data Members
        //=======================================        
        //Data Members: possibly common to all board types
        private int htFt;
        private int htIn;

        private decimal width;
        private int widthNum;    //Width Numerator
        private int widthDenum;  //Width Denomenator

        private int thickness;
        private int thickNum;    //Thickness Numerator
        private int thickDenum;  //Thickness Denomenator
        private int boardType;  //shortboard,phish, longboard
        private string brand;
        private int tailType;
        private int fins;
        private string otherBoardType;
        private string gearItem;    //for category 4 items only
        private bool editMode;      //post/edit
        private int iCondition;
        private string model;
        private string videoLink;
        private string shaper;
     
        //constructor
        public BoardItem()
        {
            editMode = false;   //currently using for post/edit
            Category = (int)-1;
            Details = string.Empty;
            Brand = string.Empty;
            Model = string.Empty;
            ImgPath1 = string.Empty;      //init img paths with
            ImgPath2 = string.Empty;
            ImgPath3 = string.Empty;
            ImgPath4 = string.Empty;
        }

        //====================================================================
        //Properties
        //====================================================================

        public string VideoLink
        {
            get { return videoLink; }
            set { videoLink = value; }
        } 

        public string Model
        {
            get { return model; }
            set { model = value; }
        } 
        
        public int ICondition
        {
            get { return iCondition; }
            set { iCondition = value; }
        }        
        
        public int HtFt
        {
            get { return htFt; }
            set { htFt = value; }
        }

        public int HtIn
        {
            get { return htIn; }
            set { htIn = value; }
        }

        public decimal Width
        {
            get { return width; }
            set { width = value; }
        }

        public int WidthNum
        {
            get { return widthNum; }
            set { widthNum = value; }
        }

        public int WidthDenum
        {
            get { return widthDenum; }
            set { widthDenum = value; }
        }

        public int Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public int ThickNum
        {
            get { return thickNum; }
            set { thickNum = value; }
        }

        public int ThickDenum
        {
            get { return thickDenum; }
            set { thickDenum = value; }
        }
        public int BoardType
        {
            get { return boardType; }
            set { boardType = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Shaper
        {
            get { return shaper; }
            set { shaper = value; }
        }

        public int TailType
        {
            get { return tailType; }
            set { tailType = value; }
        }

        public int Fins
        {
            get { return fins; }
            set { fins = value; }
        }

        public string OtherBoardType
        {
            get { return otherBoardType; }
            set { otherBoardType = value; }
        }

        public string GearItem
        {
            get { return gearItem; }
            set { gearItem = value; }
        }

        public bool EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }

        /// <summary>
        /// Public Methods
        /// </summary>
        public override bool SaveItem()
        {
            string myConnectString;
            string strSQL = "Zippo";

            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;
            
            //Build SQL
            switch (Category)
            {
                case (int)1: //SURF

                    switch (AdType)
                    {
                        case 1: //selling
					strSQL = "INSERT INTO tblEntry (Location, txtTown, txtZip, adType, iCategory, iBoardType, txtBrand, iHtFt, iHtIn, iTailType, iFins, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, width, widthNum, widthDenum, Thick, ThickNum, ThickDenum, iRatingVal, iRatingCount, iCondition, activateCode, iShip, txtShaper, iStatus, txtModel)";
					strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + Zip + "', '" + AdType + "', '" + Category + "', '" + BoardType + "', '" + Brand + "', '" + HtFt +
                                      "', '" + HtIn + "', '" + TailType + "', '" + Fins + "' , '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                      "', '" + Width + "','" + WidthNum + "','" + WidthDenum + "','" + Thickness + "','" + ThickNum + "','" + ThickDenum + "','" + (int)0 +
                                      "','" + (int)0 + "','" + ICondition + "','" + ActivateCode + "','" + Ship + "','" + Shaper + "','" + (int)1 + "','" + model + "')";
                            break;
                        case 2: //wanted
                            strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, iHtFt, iHtIn, iBoardType,  txtDetails, dCreateDate, fltPrice, iUser, iRatingVal, iRatingCount, iShip, iStatus)";
                            strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + HtFt +
                                      "', '" + HtIn + "', '" + BoardType + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + (int)0 + "','" + (int)0 + "','" + Ship + "','" + (int)1 + "')";   
                            break;
                        case 3: //showcase
                            strSQL = "INSERT INTO tblEntry (Location, txtTown, adTitle, adType, iCategory, txtBrand, txtWeb, txtGearItem, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, txtGenDimensions, iRatingVal, iRatingCount, activateCode, iStatus)";
                            strSQL += "VALUES ('" + Location + "', '" + Town + "','" + AdTitle + "', '" + AdType + "', '" + Category + "', '" + Brand + "', '" + WebURL +
                                      "', '" + GearItem + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                      "', '" + GenDimensions + "','" + (int)0 + "','" + (int)0 + "','" + ActivateCode + "','" + (int)1 + "')";   
                            break;
                        case 4: //ShaperHouse 
                            strSQL = "INSERT INTO tblEntry (Location, iBoardType, adType, iCategory, txtBrand, txtModel, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, txtGenDimensions, iRatingVal, iRatingCount, iStatus, activateCode, EntryVideoEmbed)";
                            strSQL += "VALUES ('" + Location + "', '" + BoardType + "','" + AdType + "', '" + Category + "', '" + Brand + "','" + model + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                      "', '" + GenDimensions + "','" + (int)0 + "','" + (int)0 + "','" + Status + "','" + ActivateCode + "','" + videoLink + "')";  //WHY is iStatus 4?
                            break;
                    }                    
                    break;
                
                case (int)2: //SNOW
                    //TODO: for adtypes
                    strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, iBoardType, txtBrand, iHtFt, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, iRatingVal, iRatingCount, activateCode, iShip, iStatus)";
                    strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + BoardType + "', '" + Brand + "', '" + HtFt +
                              "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                              IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                              "','" + (int)0 + "','" + (int)0 + "','" + ActivateCode + "','" + Ship + "','" + (int)1 + "')";
                    break;
                
                case (int)3: //OTHER boards
                    //TODO: for adtypes
                    if (BoardType == (int)0 || BoardType.ToString() == "")
                    {
                        strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, txtBrand, txtGenDimensions, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, iRatingVal, iRatingCount, txtOtherBoardType, activateCode, iShip, iStatus)";
                        strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + Brand + "', '" + GenDimensions +
                                  "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                  IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                  "','" + (int)0 + "','" + (int)0 + "','" + OtherBoardType + "','" + ActivateCode + "','" + Ship + "','" + (int)1 + "')";
                    }
                    else
                    {
                        strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, iBoardType, txtBrand, txtGenDimensions, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, iRatingVal, iRatingCount, activateCode, iStatus)";
                        strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + BoardType + "', '" + Brand + "', '" + GenDimensions +
                                  "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                  IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                  "','" + (int)0 + "','" + (int)0 + "','" + ActivateCode + "','" + (int)1 + "')";
                    }
                    break;

                case (int)4: //Gear

                    switch (AdType)
                    {
                        case 1: //Selling
                            //TODO: for adtypes
                            strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, txtBrand, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, iRatingVal, iRatingCount, txtGearItem, activateCode, iShip, iStatus)";
                            strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + Brand + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                      "','" + (int)0 + "','" + (int)0 + "','" + GearItem + "','" + ActivateCode + "','" + Ship + "','" + (int)1 + "')";
                            break;
                        case 2: //Wanted
                            strSQL = "INSERT INTO tblEntry (Location, txtTown, adType, iCategory, iHtFt, iHtIn, iBoardType,  txtDetails, dCreateDate, fltPrice, iUser, iRatingVal, iRatingCount, activateCode, iStatus)";
                            strSQL += "VALUES ('" + Location + "', '" + Town + "', '" + AdType + "', '" + Category + "', '" + HtFt +
                                      "', '" + HtIn + "', '" + BoardType + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + (int)0 + "','" + (int)0 + "','" + ActivateCode + "','" + (int)1 + "')";
                            break;
                        case 3: //Showcase
                            strSQL = "INSERT INTO tblEntry (Location, txtTown, adTitle, adType, iCategory, txtBrand, txtWeb, txtGearItem, txtDetails, dCreateDate, fltPrice, iUser, txtImgPath1, txtImgPath2, txtImgPath3, txtImgPath4, txtGenDimensions, iRatingVal, iRatingCount, activateCode, iStatus)";
                            strSQL += "VALUES ('" + Location + "', '" + Town + "','" + AdTitle + "', '" + AdType + "', '" + Category + "', '" + Brand + "', '" + WebURL +
                                      "', '" + GearItem + "', '" + Details + "' , '" + Created + "' , '" + Price + "', '" +
                                      IUser + "', '" + ImgPath1 + "', '" + ImgPath2 + "', '" + ImgPath3 + "', '" + ImgPath4 +
                                      "', '" + GenDimensions + "','" + (int)0 + "','" + (int)0 + "','" + ActivateCode + "','" + (int)1 + "')";
                            break;
                    }
                    break;
            }
     
            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();
 
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();

                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "ErrMessage: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL: " + strSQL);
                ErrorLog.ErrorRoutine(false, "Error Saving");
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }
/*
 * Updates an entries data in the db
*/ 
        public bool UpdateItem()
        {
            string myConnectString;
            string strSQL = "";

            //build SQL
			strSQL = "UPDATE tblEntry SET dLastModified ='" + DateTime.Now + "',Location = '" + Location + "',txtTown = '" + Town + "',txtZip = '" + Zip + "',txtDetails = '" + Details + "',txtBrand = '" + Brand + "',fltPrice = '" + Price + "'";

            if (PriceChange == 1)
                strSQL += ",iPriceChange ='" + 1 + "'";
            
            //can't do this
            if (ImgPath1 != "KEEP") {strSQL += ",txtImgPath1 = '" + ImgPath1 + "'";}
            if (ImgPath2 != "KEEP") {strSQL += ",txtImgPath2 = '" + ImgPath2 + "'";}
            if (ImgPath3 != "KEEP") {strSQL += ",txtImgPath3 = '" + ImgPath3 + "'";}
            if (ImgPath4 != "KEEP") {strSQL += ",txtImgPath4 = '" + ImgPath4 + "'";}

            //Build SQL for category specific
            switch (Category)
            {
                case 1: //surf
                    strSQL += ",txtShaper = '" + Shaper + "'";

                    //Build SQL for surf board dimensions (Width & Thickness)
                    strSQL += ",iBoardType = '" + BoardType + "'";
                    strSQL += ",iHtFt = '" + HtFt + "',iHtIn = '" + HtIn + "'";

                    strSQL += ",width ='" + Width + "',widthNum ='" + WidthNum + "',widthDeNum ='" + WidthDenum + "'";
                    strSQL += ",Thick = '" + Thickness + "',ThickNum ='" + ThickNum + "',ThickDenum = '" + ThickDenum + "'";

                    strSQL += ",iTailType = '" + TailType + "',iFins = '" + Fins + "'";
                    strSQL += ",iShip = '" + Ship + "' ";
                    break;

                case 2: //snow
                    strSQL += ",iBoardType = '" + BoardType + "'";
                    strSQL += ",iHtFt = '" + HtFt + "'";
                    strSQL += ",iShip = '" + Ship + "' ";
                    break;
                
                case 3: //other boards
                    
                    if (BoardType.ToString() != "" && BoardType > (int)0)
                    {
                        strSQL += ",iBoardType = '" + BoardType + "'";
                        strSQL += ",txtOtherBoardType = NULL";
                    }
                    else
                    {
                        strSQL += ",iBoardType = NULL";
                        strSQL += ",txtOtherBoardType = '" + OtherBoardType + "'";
                        
                    }
                    strSQL += ",txtShaper = '" + Shaper + "'";
                    strSQL += ", txtGenDimensions = '" + GenDimensions + "'";
                    strSQL += ",iShip = '" + Ship + "' ";
                    break;
                
                case 4: //gear
                    strSQL += ",txtGearItem = '" + GearItem + "'";
                    strSQL += ",iShip = '" + Ship + "' ";
                    break;
            }
            strSQL += "WHERE iD = '" + EntryId + "'";

            //ErrorLog.ErrorRoutine(false, "strSQL:Update: " + strSQL);
            
            //get connect string
            myConnectString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;            
            SqlConnection myConnection = new SqlConnection(myConnectString);

            try
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(strSQL, myConnection);
                objCommand.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "Error:BoardItems.cs:UpdateItem: " + ex.Message);
                ErrorLog.ErrorRoutine(false, "Error:BoardItems.cs:UpdateItem:StrSQL: " + strSQL);

                return false; 
            }

            finally
            {
                myConnection.Close();
            }
        }
/*
 */
    /*
     * Update model entries for ShaperHouse.  Decided to make it it's own method to avoid complicated code.
    */
        public bool UpdateModel()
        {
            string strSQL = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;


            //build SQL
            //strSQL = "UPDATE tblEntry SET dLastModified ='" + Modified + "',Location = '" + Location + "',txtTown = '" + Town + "',txtDetails = '" + Details + "',txtBrand = '" + Brand + "',fltPrice = '" + Price + "'";
            strSQL = "UPDATE tblEntry SET txtDetails = '" + Details + "', fltPrice = '" + Price + "'";

            //Build SQL for surf board dimensions (Width & Thickness)
            strSQL += ", iBoardType = '" + BoardType + "'";
            strSQL += ", txtGenDimensions = '" + GenDimensions + "'";
            strSQL += ", txtModel = '" + Model + "'";
            strSQL += ", EntryVideoEmbed = '" + videoLink + "'";

            //can't do this
            if (ImgPath1 != "KEEP") { strSQL += ",txtImgPath1 = '" + ImgPath1 + "'"; }
            if (ImgPath2 != "KEEP") { strSQL += ",txtImgPath2 = '" + ImgPath2 + "'"; }
            if (ImgPath3 != "KEEP") { strSQL += ",txtImgPath3 = '" + ImgPath3 + "'"; }
            if (ImgPath4 != "KEEP") { strSQL += ",txtImgPath4 = '" + ImgPath4 + "'"; }

            strSQL += " WHERE iD = '" + EntryId + "'";

            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BoardItem:UpdateModel:Error:" + ex.Message);
                ErrorLog.ErrorRoutine(false, "strSQL:" + strSQL);
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
        public bool PublishBoard(string iD, bool pubVal)
        {
            string strSQL = string.Empty;

            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;;

            if (pubVal)
                strSQL = "UPDATE tblEntry SET iStatus = '5' WHERE iD = '" + iD + "'";
            else
                strSQL = "UPDATE tblEntry SET iStatus = '4' WHERE iD = '" + iD + "'";
            
            try
            {
                dbManager.Open();
                dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(false, "BoardItem:PublishBoard:Error:" + ex.Message);
                return false;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }


    }
}
