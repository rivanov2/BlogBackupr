using System;

namespace CoadTools.WebZapper.Specialized.eBay
{
	public enum eBayItemStatus {Winning, Loosing};
	public class MyeBay
	{
		#region Property Variables
		private CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable m_BiddingOn = new eBayData.eBayItemDataTable();
		private CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable m_BidsWon = new eBayData.eBayItemDataTable();
		private CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable m_BidsLost = new eBayData.eBayItemDataTable();
		private CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable m_Watching = new eBayData.eBayItemDataTable();

		private DateTime m_TimeStamp = DateTime.Now;
		#endregion

		#region Constructor(s)
		public MyeBay() {}
		#endregion
			
		#region Public Properties
		public CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable BiddingOn
		{
			get {return m_BiddingOn;}
			set {m_BiddingOn = value;}
		}
		public CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable BidsWon
		{
			get {return m_BidsWon;}
			set {m_BidsWon = value;}
		}
		public CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable BidsLost
		{
			get {return m_BidsLost;}
			set {m_BidsLost = value;}
		}
		public CoadTools.WebZapper.Specialized.eBay.eBayData.eBayItemDataTable Watching
		{
			get {return m_Watching;}
			set {m_Watching = value;}
		}
		public DateTime TimeStamp
		{
			get {return m_TimeStamp;}
			set {m_TimeStamp = value;}
		}
			#endregion
	}		
}
