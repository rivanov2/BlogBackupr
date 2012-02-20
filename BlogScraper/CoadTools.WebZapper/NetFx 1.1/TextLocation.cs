using System;

namespace CoadTools.WebZapper
{
	public struct TextLocation
	{
		/* 
		 * This is a test <code lan=C#>of code</code> inside.
		 * prefix = "<code"
		 * start = ">"
		 * end = "</code>"
		 * Inside = "of code"
		 * OusideStart = ">of code<
		 * 
		 */

		#region  Empty Value 
		public static readonly TextLocation Empty = new TextLocation(-1, -1, -1, -1, -1);
		#endregion

		#region  Public Fields 
		public int PrefixTag;
		public int StartTag;
		public int StartText;
		public int EndText;
		public int EndTag;
		#endregion

		#region  Constructor 
		public TextLocation(int PrefixTag, int StartTag, int StartText, int EndText, int EndTag)
		{
			this.PrefixTag = PrefixTag;
			this.StartTag = StartTag;
			this.StartText = StartText;
			this.EndText = EndText;
			this.EndTag = EndTag;
		}
		#endregion

		#region  Equality Support 
		public override bool Equals(Object o)
		{ 
			if (o is TextLocation) return this == (TextLocation) o;
			else return false;
		}
		public static bool operator == (TextLocation a, TextLocation b)
		{ return a.PrefixTag == b.PrefixTag && a.StartText == b.StartText && a.StartTag == b.StartTag && a.EndText == b.EndText && a.EndTag == b.EndTag; }
		public static bool operator != (TextLocation a, TextLocation b)
		{ return !(a == b); }
		public override int GetHashCode()
		{ return base.GetHashCode(); }
		#endregion
	}
}
