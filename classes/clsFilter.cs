using System;

namespace BoardHunt.classes
{
	public class clsFilter
	{

		private string f_HtFt;
		private string f_HtIn;

		private string t_HtFt;
		private string t_HtIn;
		private string keywords;
		private string loc;
		private string fins;
		private string tail;
		private string cond;
		private int listingtype;
		private int hotDeal;
		private string priceMin;
		private string priceMax;
		private string boardType;


		public clsFilter ()
		{

			cond = "Cond";
			tail = "Tail";
			loc = "Region";
			fins = "Fins";
			hotDeal = 0;
		}

		public string BoardType
		{
			get { return boardType; }
			set { boardType = value; }
		}

		public string F_HtFt
		{
			get { return f_HtFt; }
			set { f_HtFt = value; }
		}

		public string F_HtIn
		{
			get { return F_HtIn; }
			set { f_HtIn = value; }
		}

		public string T_HtFt
		{
			get { return T_HtFt; }
			set { T_HtFt = value; }
		}

		public string T_HtIn
		{
			get { return t_HtIn; }
			set { t_HtIn = value; }
		}

		public int HotDeal
		{
			get { return hotDeal; }
			set { hotDeal = value; }
		}

		public string PriceMin
		{
			get { return priceMin; }
			set { priceMin = value; }
		}

		public string PriceMax
		{
			get { return priceMax; }
			set { priceMax = value; }
		}

		public string Tail
		{
			get { return tail; }
			set { tail = value; }
		}

		public string Loc
		{
			get { return loc; }
			set { loc = value; }
		}

		public string Fins
		{
			get { return fins; }
			set { fins = value; }
		}

		public string Keywords
		{
			get { return keywords; }
			set { keywords = value; }
		}
	}
}

