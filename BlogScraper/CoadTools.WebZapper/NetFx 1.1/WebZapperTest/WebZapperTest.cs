using System;

using CoadTools.WebZapper;
using CoadTools.WebZapper.Specialized;
using CoadTools.WebZapper.Specialized.eBay;

namespace WebZapperTest
{
	class WebZapperTest
	{

		public WebZapperTest()
		{
//			MyeBay ebay = WebZap.getMyeBay("ncoad", "vMr.dTpyZlg1qPS4.b.n302");
//			foreach (eBayData.eBayItemRow item in ebay.Watching)
//        Console.WriteLine(item.Title + "\n\n");

			TVGuide.TVShow[] shows = TVGuide.getTVShows("61315", "77801", "X-Files");
			foreach (TVGuide.TVShow show in shows)
				Console.WriteLine(show.Show + ": " + show.Episode + "\n\t" + show.Description + "\n");


			Console.WriteLine("\n\nPress [ENTER] to exit...");
			Console.ReadLine();
		}

		[STAThread]
		static void Main(string[] args)
		{ WebZapperTest wzt = new WebZapperTest(); }
	}
}
