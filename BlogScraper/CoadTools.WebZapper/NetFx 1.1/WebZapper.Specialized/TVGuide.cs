using System;

namespace CoadTools.WebZapper.Specialized
{
	public class TVGuide
	{
		public static TVShow[] getTVShows(string ProviderCode, string ZipCode, string Search)
		{
			bool finished = false;
			TVShowCollection shows = new TVShowCollection();
			string html = WebZap.ObtainWebPage("http://www.tvguide.com/listings/search/SearchResults.asp?I=" + ProviderCode + "&Zip=" + ZipCode + "&FormText=" + Search);
			
			int lastday = 0; int month = 0;
			int after = 0;
		
			while (!finished)
			{
				TVShow tv = new TVShow();

				// Obtain the day of the show
				string day = WebZap.getHTML(html, ref after, "<td ALIGN=\"LEFT\" valign=\"top\" nowrap>", "									", "\n").Trim();
				day = day.Substring(4, day.Length - 4).Trim();

				// Obtain the time of the show
				string time = WebZap.getHTML(html, ref after, "<td ALIGN=\"LEFT\" valign=\"top\" nowrap>", "									", "\n").Trim();

				// Check to see if we were at the end of the month and starting a new month
				if (int.Parse(day) < lastday) month++;
				lastday = int.Parse(day);

				// Build the date & time for this show
				string daytime = DateTime.Now.Month + month + "/" + day + "/" + DateTime.Now.Year + " " + time;
				tv.Time = DateTime.Parse(daytime);

				// Obtain the TitleID from the java script line
				tv.TitleID = int.Parse(WebZap.getHTML(html, ref after, "','", "','"));

				// Get the title of the show
				string show = WebZap.getHTML(html, ref after, "<font SIZE=\"-1\" COLOR=\"MidnightBlue\" STYLE=\"text-decoration:none\">", "										", "\n").Trim();

				// Determain if this show is an episode
				if (show.LastIndexOf(": ") > -1)
				{
					tv.Show = show.Substring(0, show.LastIndexOf(": "));
					tv.Episode = show.Substring(tv.Show.Length + 2, show.Length - (tv.Show.Length + 2));
				}
				else tv.Show = show;

				// Obtain the channel
				string channel = WebZap.getHTML(html, ref after, "<font SIZE=\"-1\" COLOR=\"MidnightBlue\" face=\"arial,helvetica\">", "									", "\n").Trim();
				tv.Channel = int.Parse(channel);

				// Obtain the network
				string network = WebZap.getHTML(html, ref after, "<font SIZE=\"-1\" COLOR=\"MidnightBlue\" face=\"arial,helvetica\">", "									", "\n").Trim();
				tv.Network = network;

				// Display the show
				// Console.WriteLine(tv.Show + ", " + tv.Episode + ", " + tv.Time + ", " + channel + ", " + network);

				// Add to the collection.
				shows.Add(tv);

				finished = (html.IndexOf("</table>", after, 500) > -1);
			}

			return shows.ToArray();
		}
		
		
		#region Class: TVShowCollection
		public class TVShowCollection : System.Collections.CollectionBase
		{
			public TVShow this[int index]
			{ get {return (TVShow) List[index];} }
			public void Add(TVShow s)
			{ List.Add(s); }
			public TVShow[] ToArray()
			{
				TVShow[] shows = new TVShow[List.Count];
				List.CopyTo(shows, 0);
				return shows;
			}
		}

		#endregion

		#region Class: TVShow
		public class TVShow : System.IComparable
		{
			public DateTime Time;
			public string Show;
			public string Episode;
			public int Channel;
			public string Network;
			public int TitleID;

			#region Property Variables
			private string m_Description = "";
			#endregion

			public int CompareTo(object tv)
			{ return Time.CompareTo(((TVShow) tv).Time); }

			public string Description
			{
				get
				{
					if (m_Description == "")
					{
						string html = WebZap.ObtainWebPage("http://www.tvguide.com/listings/closerlook.asp?Q=" + TitleID);
						m_Description = WebZap.getHTML(html, "					<br><font Size=\"-1\">", "\n					</b></font>").Trim();
					}
					return m_Description;
				}
			}
			public override string ToString()
			{ return Show + (Episode == "" ? "" : ": " + Episode);} 
		}
		#endregion
	}
}
