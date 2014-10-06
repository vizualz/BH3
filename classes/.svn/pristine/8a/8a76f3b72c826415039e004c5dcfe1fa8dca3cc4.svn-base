using System;

namespace BoardHunt.classes
{
    /// <summary>
    /// Object Item Generic Base Class for all Item Types.
    /// Created 8/21/2007 AHM
    /// </summary>
    public class BaseItem
    {
        //=======================================
        //Private Class Data Members
        //=======================================
        private int      entryID;       //Entry ID
        private int      location;
        private int      adType;
        private int      category;
        private string   details;
        private int      iUser;         //User ID
        private string imgPath1;        //FilePath 1
        private string imgPath2;        //FilePath 2
        private string imgPath3;        //FilePath 3
        private string imgPath4;        //FilePath 4
        private Decimal price;          //tblEntry.fltprice
        private string txtPrice;        //price but in text format.  allows users like shapers to specify range

        private int rating;
        private DateTime created;       //Date Created
        private DateTime modified;      //Date Last Modified
        private DateTime expired;       //Date Created

        //private DateTime? expired = null;

        private int ratingCnt;
        private int ratingVal;
        private int trade;
        private int status;
        private string town;
        private string genDimensions;
        private string webURL;
        private string adTitle;         //title that reads across the Showcase item
        private string activateCode;    //used to "mark as sold"
        private int iShip;
        private int priceChange;
        private int editMode; // 0=None,1=FromPreview,2=FromManager

        //====================================================================
        //Constructor
        //====================================================================
        public BaseItem()
        {
            //
            // TODO: Add constructor logic here
            //
            priceChange = 0;
            editMode = 0;
        }

        //====================================================================
        //Properties
        //====================================================================
        public int EntryId{
            get { return entryID; }
            set { entryID = value; }
        }

        public int Location
        {
            get { return location; }
            set { location = value; }
        }

        public int AdType
        {
            get { return adType; }
            set { adType = value; }

        }

        public int Category
        {
            get { return category; }
            set { category = value; }

        }

        public string Details
        {
            get { return details; }
            set { details = value; }

        }

        public int IUser
        {
            get { return iUser; }
            set { iUser = value; }

        }

        public string ImgPath1
        {
            get { return imgPath1; }
            set { imgPath1 = value; }

        }

        public string ImgPath2
        {
            get { return imgPath2; }
            set { imgPath2 = value; }

        }

        public string ImgPath3
        {
            get { return imgPath3; }
            set { imgPath3 = value; }

        }

        public string ImgPath4
        {
            get { return imgPath4; }
            set { imgPath4 = value; }

        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }

        }

        public string TxtPrice
        {
            get { return txtPrice; }
            set { txtPrice = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }

        }

        public DateTime Created
        {
            get { return created; }
            set { created = value; }

        }

        public DateTime Modified
        {
            get { return modified; }
            set { modified = value; }

        }

        public DateTime Expired
        {
            get { return expired; }
            set { expired = value; }
        }

        public int RatingCnt
        {
            get { return ratingCnt; }
            set { ratingCnt = value; }

        }

        public int RatingVal
        {
            get { return ratingVal; }
            set { ratingVal = value; }

        }
       
        public int Trade
        {
            get { return trade; }
            set { trade = value; }

        }

        public int Status
        {
            get { return status; }
            set { status = value; }

        }

        public string Town
        {
            get { return town; }
            set { town = value; }

        }

        public string GenDimensions
        {
            get { return genDimensions; }
            set { genDimensions = value; }

        }

        public string WebURL
        {
            get { return webURL; }
            set { webURL = value; }

        }

        public string AdTitle
        {
            get { return adTitle; }
            set { adTitle = value; }

        }

        public virtual bool SaveItem()
        {
            return false;
        }

        public string ActivateCode
        {
            get { return activateCode; }
            set { activateCode = value; }
        }

        public int Ship
        {
            get { return iShip; }
            set { iShip = value; }
        }

        public int PriceChange
        {
            get { return priceChange; }
            set { priceChange = value; }
        }

        public int EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }
    }
}
