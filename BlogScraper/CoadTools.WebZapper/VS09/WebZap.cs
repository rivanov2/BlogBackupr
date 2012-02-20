/*
 * Project:       WebZapper
 * Author:        Noah Coad, http://coad.net/noah
 * Created:       ~Mid 2003
 * Description:   String location routines helpful for working with HTML in web pages.
 * Notes:         -
 * Action Items:  - Replace adhoc "FixHTML" with actual .NET HTMl parsing engine.
 * Modifications: -
 * 
 */

#region  Namespace Inclusions 
using System;
using System.Net;
using System.Text;
#endregion

namespace CoadTools.WebZapper
{
	public class WebZap
	{
		#region  General Routines 
		public static string ObtainWebPage(string url)
		{ return ASCIIEncoding.Default.GetString((new WebClient()).DownloadData(url)); }
		#endregion

		#region  String (HTML) Locating Routines 
		public static string getHTML(string html, string start, string end)
		{
			int after = 0;
			return getHTML(html, ref after, "", start, end);
		}

		public static string getHTML(string html, ref int after, string start, string end)
		{ return getHTML(html, ref after, "", start, end); }

		public static string getHTML(string html, string prefix, string start, string end)
		{
			int after = 0;
			return getHTML(html, ref after, prefix, start, end);
		}

		public static string getHTML(string html, ref int after, string prefix, string start, string end)
		{
			TextLocation loc = getLocation(html, ref after, prefix, start, end);

			if (loc == TextLocation.Empty) return String.Empty;

			// Everything okay
			return FixHTML(html.Substring(loc.StartText, loc.EndText - loc.StartText));
		}

		public static string FixHTML(string html)
		{
			html = html.Replace("&nbsp;", " ");
			html = html.Replace("&amp;", "&");
			html = html.Replace("&gt;", ">");
			html = html.Replace("&lt;", "<");
			html = html.Replace("&deg;", "°");
			return html;
		}

		
		public static TextLocation getLocation(string html, ref int after, string prefix, string start, string end)
		{
			// pres = PreFix Start, outs = Outside Start, ins = Inside Start
			int pres = 0, outs = 0, ins = 0, e = 0;

			// The starting string was specified as the prefix, swap
			if (prefix != "" & start == "") {start = prefix; prefix = "";}

			// First find the prefix
			if (!prefix.Equals("")) pres = html.IndexOf(prefix, after);
			else pres += after;
			
			// Prefix not found, return with nothing.
			if (pres == -1) return TextLocation.Empty;

			outs = html.IndexOf(start, pres);
			ins = outs + start.Length;
			e = html.IndexOf(end, ins);
			after = e + end.Length;

			// Ending not found
			if (e == -1) return TextLocation.Empty;

			return new TextLocation(pres, outs, ins, e, after);
		}
		#endregion
	}
}
