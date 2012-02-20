#region Namespace Inclusions
using System;

using CoadTools.WebZapper;
#endregion

namespace CoadTools.WebZapper.Specialized
{
	public class MiscSites
	{
		#region Stock Info
		public struct StockInfo
		{
			public string Ticker;
			public float LastTrade;
			public string imgsrc;
			public int Volume;
			public string RecentNewsText;
			public string RecentNewsURL;
			public float PreviousClose;
			public float Open;
			public float DayLow;
			public float DayHigh;

			public StockInfo(string Ticker)
			{
				this.Ticker = Ticker;
				this.LastTrade = 0;
				this.imgsrc = "http://ichart.yahoo.com/v?s=" + Ticker;
				this.Volume = 0;
				this.RecentNewsText = "";
				this.RecentNewsURL = "";
				this.Open = 0;
				this.PreviousClose = 0;
				this.DayHigh = 0;
				this.DayLow = 0;
			}
			
		}

		public static StockInfo getStockInfo(string Ticker)
		{
			string html = WebZap.ObtainWebPage("http://finance.yahoo.com/q?s=" + Ticker + "&d=2b");
			
			StockInfo info = new StockInfo(Ticker);

			info.LastTrade = float.Parse(WebZap.getHTML(html, "Last Trade<br>", "<b>", "</b>"));
			info.Volume = (int) float.Parse(WebZap.getHTML(html, "", "Volume<br>", "</font>"));
			info.RecentNewsURL = WebZap.getHTML(html, "Yahoo TimeStamp", "href=\"", "\">");
			info.RecentNewsText = WebZap.getHTML(html, "Yahoo TimeStamp", "\">", "</a>");
			info.PreviousClose = float.Parse(WebZap.getHTML(html, "", "Prev Cls<br>", "</font>"));
			info.Open = float.Parse(WebZap.getHTML(html, "", "Open<br>", "</font>"));
			info.DayLow = float.Parse(WebZap.getHTML(html, "", "Day's Range<br>", " - "));
			info.DayHigh = float.Parse(WebZap.getHTML(html, "Day's Range<br>", " - ", "</font>"));

			return info;
		}
		#endregion

		#region Weather Info

		#region Weather Info Structures
		public struct WeatherForcast
		{
			public string Text;
			public string Date;
			public int High;
			public int Low;
			public string ImgSrc;
			public string UVIndex;

			public WeatherForcast(bool dummy)
			{
				this.Text = "";
				this.Date = "";
				this.High = 0;
				this.Low = 0;
				this.ImgSrc = "";
				this.UVIndex = "";
			}
		}

		public struct WeatherInfo
		{
			public string ZipCode;
			public int Temp;
			public string Text;
			public string ImgSrc;
			public int FeelsLike;
			public string UVIndex;
			public string Wind;
			public int DewPoint;
			public int Humidity;
			public string Visibility;
			public string City;
			public string ReportedBy;
			public string LastUpdated;
			public string Barometer;
			public WeatherForcast[] Forcast;

			public WeatherInfo(string ZipCode)
			{
				this.ZipCode = ZipCode;
				this.Temp = 0;
				this.Text = "";
				this.ImgSrc = "";
				this.FeelsLike = 0;
				this.UVIndex = "";
				this.Wind = "";
				this.DewPoint = 0;
				this.Humidity = 0;
				this.Visibility = "";
				this.City = "";
				this.ReportedBy = "";
				this.LastUpdated = "";
				this.Barometer = "";
				this.Forcast = new WeatherForcast[10];
			}

			public override string ToString()
			{
				string s = "";

				s += "Zip Code:     " + ZipCode + "\n";
				s += "Temperature:  " + Temp + "\n";
				s += "Text:         " + Text + "\n";
				s += "Feels Like:   " + FeelsLike + "\n";
				s += "UVIndex:      " + UVIndex + "\n";
				s += "Wind:         " + Wind + "\n";
				s += "DewPoint:     " + DewPoint + "\n";
				s += "Humidity:     " + Humidity + "\n";
				s += "Visibility:   " + Visibility + "\n";
				s += "City:         " + City + "\n";
				s += "Reported By:  " + ReportedBy + "\n";
				s += "Last Updated: " + LastUpdated + "\n";
				s += "Barometer:    " + Barometer + "\n";

				return s;
			}
		}
		#endregion

		public static WeatherInfo getWeatherInfo(string ZipCode)
		{
			string html = WebZap.ObtainWebPage("http://www.weather.com/weather/local/" + ZipCode);
			
			WeatherInfo info = new WeatherInfo(ZipCode);

			info.Temp = int.Parse(WebZap.getHTML(html, "<TD VALIGN=\"MIDDLE\" ALIGN=\"CENTER\" CLASS=\"obsTempTextBlue\"><B>", "&deg;F"));
			info.Text = WebZap.getHTML(html, "<TD VALIGN=\"TOP\" ALIGN=\"CENTER\" CLASS=\"obsTextBlue\"><B>", "</B></TD>").Trim();
			info.ImgSrc = WebZap.getHTML(html, "<!-- insert wx icon --><img src=\"", "\" ");
			info.FeelsLike = int.Parse(WebZap.getHTML(html, "<!-- insert feels like temp -->", "&deg;F"));
			info.UVIndex = WebZap.getHTML(html, "<!-- insert UV number -->", "</td>");
			info.Wind = WebZap.getHTML(html, "<!-- insert wind information -->", "</td>");
			info.DewPoint = int.Parse(WebZap.getHTML(html, "<!-- insert dew point -->", "&deg;F"));
			info.Humidity = int.Parse(WebZap.getHTML(html, "<!-- insert humidity -->", " %</td>"));
			info.Visibility = WebZap.getHTML(html, "<!-- insert visibility -->", "</td>");
			info.City = WebZap.getHTML(html, "Local Weather - ", " (" + ZipCode);
			info.ReportedBy = WebZap.getHTML(html, "<!-- insert reported by and last updated info -->as reported at ", ".&nbsp;&nbsp;");
			info.LastUpdated = WebZap.getHTML(html, ".&nbsp;&nbsp;Last Updated ", " (", ")");
			info.Barometer = WebZap.getHTML(html, "<!-- insert barometer information -->", "</td>");

			int after = 0;
			for (int r = 0; r < 10; r++)
			{
				if (r < 2) info.Forcast[r].Date = WebZap.getHTML(html, ref after, "<!-- insert load change day/date here -->", "   ", "</A>") + " " + WebZap.getHTML(html, ref after, "<BR>", "   ");
				else info.Forcast[r].Date = WebZap.getHTML(html, ref after, "<!-- insert no link day name here -->\n               ", "<B").Trim() + " " + WebZap.getHTML(html, ref after, "R>", "\n");
				info.Forcast[r].ImgSrc = WebZap.getHTML(html, ref after, "  <IMG SRC=\"", "\" ");
				info.Forcast[r].Text = WebZap.getHTML(html, ref after, "ALT=\"", "\">");
				info.Forcast[r].High = int.Parse(WebZap.getHTML(html, ref after, "      &nbsp;\n      \n      ", "&deg;F").Trim());
				info.Forcast[r].Low = int.Parse(WebZap.getHTML(html, ref after, "      &nbsp;\n      ", "&deg;F").Trim());
				info.Forcast[r].UVIndex = WebZap.getHTML(html, ref after, "UV Index:&nbsp;", "\n");
			}

			return info;
		}
		#endregion

		#region eBay Items
		public static eBay.MyeBay getMyeBay(string userid, string EncodedPassword)
		{
			return getMyeBay("http://cgi1.ebay.com/aw-cgi/ebayISAPI.dll?MyEbayItemsBiddingOn&userid=" + userid + "&pass=" + EncodedPassword + "&dayssince=30");
		}
		
		public static eBay.MyeBay getMyeBay(string url)
		{
			bool finished; int after = 0;
			eBay.MyeBay my = new eBay.MyeBay();
			string html = WebZap.ObtainWebPage(url);

			// Collect the Currently Bidding on Items (Winning or Loosing)
			finished = false;
			while (!finished)
			{
				eBay.eBayData.eBayItemRow item = (new eBay.eBayData.eBayItemDataTable()).NeweBayItemRow();
				item.Catagory = int.Parse(WebZap.getHTML(html, ref after, "http://cgi.ebay.com/ws/eBayISAPI.dll?ViewItem&amp;category=", "&amp").Trim());
				item.Title = WebZap.getHTML(html, ref after, "\">", "</a>").Trim();
				item.ItemNumber = int.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">", "</font>"));
				item.StartPrice = float.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">$", "</font>"));
				item.CurrentPrice = float.Parse(WebZap.getHTML(html, ref after, "$", "\n").Trim());

				string status = WebZap.getHTML(html, ref after, "http://pics.ebay.com/aw/pics/myebay/", ".gif");
				if (status == "greenCheck") item.CurrentStatus = (int) eBay.eBayItemStatus.Winning;
				else if (status == "redEx") item.CurrentStatus = (int) eBay.eBayItemStatus.Loosing;
				else item.CurrentStatus = (int) eBay.eBayItemStatus.Loosing;

				item.MaxBid = float.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">$", "<br>"));
				item.Quantity = int.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">", "</font>"));
				item.NumBids = int.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">", "</font>"));
				item.StartDate = DateTime.Parse(WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">", "</font>"));
				
				string EndTime = WebZap.getHTML(html, ref after, "<font face=\"Arial, sans-serif\" size=\"-1\">", "</font>");
				EndTime = EndTime.Replace(" ", " " + DateTime.Now.Year + " ").Replace("-", " ");
				if (DateTime.Parse(EndTime) < DateTime.Now) EndTime = EndTime.Replace(DateTime.Now.Year + "", (DateTime.Now.Year + 1) + "");
				item.EndTime = DateTime.Parse(EndTime).Add(TimeSpan.FromHours(8)).Add(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));

				my.BiddingOn.Rows.Add(item);
				
				finished = (html.Substring(after, 300).IndexOf("</table>") > -1);
			}

			// Collect the Currently Bidding on Items (Winning or Loosing)
			finished = false;


			return my;
		}
		
		#endregion
	}
}
