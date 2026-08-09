using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using ns27;

namespace buMutliTextbox;

public class Range : IEnumerable<Place>, IEnumerable
{
	[CompilerGenerated]
	private sealed class Class47 : IDisposable, IEnumerable<Place>, IEnumerator<Place>, IEnumerable, IEnumerator
	{
		private int int_0;

		private Place place_0;

		private int int_1;

		public Range range_0;

		private RangeRect rangeRect_0;

		private int int_2;

		private int int_3;

		Place IEnumerator<Place>.Current => place_0;

		object IEnumerator.Current => place_0;

		public Class47(int int_4)
		{
			int_0 = int_4;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			int num = int_0;
			if (num == 0)
			{
				int_0 = -1;
				rangeRect_0 = range_0.Bounds;
				if (rangeRect_0.iStartLine >= 0)
				{
					int_2 = rangeRect_0.iStartLine;
					goto IL_0049;
				}
				return false;
			}
			if (num == 1)
			{
				int_0 = -1;
				goto IL_009c;
			}
			return false;
			IL_0049:
			if (int_2 <= rangeRect_0.iEndLine)
			{
				int_3 = rangeRect_0.iStartChar;
				goto IL_00ac;
			}
			return false;
			IL_009c:
			int_3++;
			goto IL_00ac;
			IL_00ac:
			if (int_3 < rangeRect_0.iEndChar)
			{
				if (int_3 < range_0.tb[int_2].Count)
				{
					place_0 = new Place(int_3, int_2);
					int_0 = 1;
					return true;
				}
				goto IL_009c;
			}
			int_2++;
			goto IL_0049;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Place> IEnumerable<Place>.GetEnumerator()
		{
			Class47 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class47(0)
				{
					range_0 = range_0
				};
			}
			else
			{
				int_0 = 0;
				result = this;
			}
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Place>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class Class48 : IDisposable, IEnumerable<Place>, IEnumerator<Place>, IEnumerable, IEnumerator
	{
		private int int_0;

		private Place place_0;

		private int int_1;

		private Place place_1;

		public Place place_2;

		private bool bool_0;

		public bool bool_1;

		public Range range_0;

		private Range range_1;

		private Range range_2;

		Place IEnumerator<Place>.Current => place_0;

		object IEnumerator.Current => place_0;

		public Class48(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			range_1 = null;
			range_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			switch (int_0)
			{
			case 4:
				int_0 = -1;
				goto IL_006b;
			default:
				return false;
			case 0:
				int_0 = -1;
				if (!bool_0)
				{
					range_2 = new Range(range_0.tb, place_1, place_1);
					if (!(place_1 < range_0.End))
					{
						goto IL_00e8;
					}
					goto IL_0229;
				}
				range_1 = new Range(range_0.tb, place_1, place_1);
				goto IL_0180;
			case 1:
				int_0 = -1;
				goto IL_0180;
			case 2:
				int_0 = -1;
				goto IL_01f4;
			case 3:
				{
					int_0 = -1;
					goto IL_0265;
				}
				IL_0229:
				if (range_2.Start.iChar < range_0.tb[range_2.Start.iLine].Count)
				{
					place_0 = range_2.Start;
					int_0 = 3;
					return true;
				}
				goto IL_0265;
				IL_0265:
				if (!range_2.GoRight())
				{
					goto IL_00e8;
				}
				goto IL_0229;
				IL_00e8:
				range_2 = new Range(range_0.tb, range_0.Start, range_0.Start);
				if (range_2.Start < place_1)
				{
					goto IL_0032;
				}
				goto IL_012f;
				IL_012f:
				range_2 = null;
				goto IL_0136;
				IL_006b:
				if (range_2.GoRight() && range_2.Start < place_1)
				{
					goto IL_0032;
				}
				goto IL_012f;
				IL_0180:
				while (range_1.GoLeft() && range_1.start >= range_0.Start)
				{
					if (range_1.Start.iChar < range_0.tb[range_1.Start.iLine].Count)
					{
						place_0 = range_1.Start;
						int_0 = 1;
						return true;
					}
				}
				range_1 = new Range(range_0.tb, range_0.End, range_0.End);
				goto IL_01f4;
				IL_0032:
				if (range_2.Start.iChar < range_0.tb[range_2.Start.iLine].Count)
				{
					place_0 = range_2.Start;
					int_0 = 4;
					return true;
				}
				goto IL_006b;
				IL_01f4:
				while (range_1.GoLeft() && range_1.start >= place_1)
				{
					if (range_1.Start.iChar < range_0.tb[range_1.Start.iLine].Count)
					{
						place_0 = range_1.Start;
						int_0 = 2;
						return true;
					}
				}
				range_1 = null;
				goto IL_0136;
				IL_0136:
				return false;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Place> IEnumerable<Place>.GetEnumerator()
		{
			Class48 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class48(0)
				{
					range_0 = range_0
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.place_1 = place_2;
			@class.bool_0 = bool_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Place>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class49 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private string string_0;

		public string string_1;

		private RegexOptions regexOptions_0;

		public RegexOptions regexOptions_1;

		public Range range_1;

		private string string_2;

		private List<Place> list_0;

		private Regex regex_0;

		internal IEnumerator ienumerator_0;

		private Match match_0;

		private Range range_2;

		private Group group_0;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class49(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_220(this);
				}
			}
			string_2 = null;
			list_0 = null;
			regex_0 = null;
			ienumerator_0 = null;
			match_0 = null;
			range_2 = null;
			group_0 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					Range range = range_1;
					Class76.smethod_302(out string_2, range, ref list_0);
					regex_0 = new Regex(string_0, regexOptions_0);
					ienumerator_0 = regex_0.Matches(string_2).GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					range_2 = null;
					group_0 = null;
					match_0 = null;
				}
				if (ienumerator_0.MoveNext())
				{
					match_0 = (Match)ienumerator_0.Current;
					range_2 = new Range(range_1.tb);
					group_0 = match_0.Groups["range"];
					if (!group_0.Success)
					{
						group_0 = match_0.Groups[0];
					}
					range_2.Start = list_0[group_0.Index];
					range_2.End = list_0[group_0.Index + group_0.Length];
					range_0 = range_2;
					int_0 = 1;
					return true;
				}
				Class76.smethod_220(this);
				ienumerator_0 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class49 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class49(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.string_0 = string_1;
			@class.regexOptions_0 = regexOptions_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class50 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private Regex regex_0;

		public Regex regex_1;

		public Range range_1;

		private string string_0;

		private List<Place> list_0;

		internal IEnumerator ienumerator_0;

		private Match match_0;

		private Range range_2;

		private Group group_0;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class50(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_145(this);
				}
			}
			string_0 = null;
			list_0 = null;
			ienumerator_0 = null;
			match_0 = null;
			range_2 = null;
			group_0 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					Range range = range_1;
					Class76.smethod_302(out string_0, range, ref list_0);
					ienumerator_0 = regex_0.Matches(string_0).GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					range_2 = null;
					group_0 = null;
					match_0 = null;
				}
				if (ienumerator_0.MoveNext())
				{
					match_0 = (Match)ienumerator_0.Current;
					range_2 = new Range(range_1.tb);
					group_0 = match_0.Groups["range"];
					if (!group_0.Success)
					{
						group_0 = match_0.Groups[0];
					}
					range_2.Start = list_0[group_0.Index];
					range_2.End = list_0[group_0.Index + group_0.Length];
					range_0 = range_2;
					int_0 = 1;
					return true;
				}
				Class76.smethod_145(this);
				ienumerator_0 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class50 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class50(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.regex_0 = regex_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class51 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private string string_0;

		public string string_1;

		private RegexOptions regexOptions_0;

		public RegexOptions regexOptions_1;

		public Range range_1;

		private Regex regex_0;

		internal IEnumerator<Range> ienumerator_0;

		private Range range_2;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class51(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_557(this);
				}
			}
			regex_0 = null;
			ienumerator_0 = null;
			range_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					regex_0 = new Regex(string_0, regexOptions_0);
					ienumerator_0 = range_1.GetRangesByLines(regex_0).GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					range_2 = null;
				}
				if (ienumerator_0.MoveNext())
				{
					range_2 = ienumerator_0.Current;
					range_0 = range_2;
					int_0 = 1;
					return true;
				}
				Class76.smethod_557(this);
				ienumerator_0 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class51 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class51(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.string_0 = string_1;
			@class.regexOptions_0 = regexOptions_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class52 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private Regex regex_0;

		public Regex regex_1;

		public Range range_1;

		private FileTextSource fileTextSource_0;

		private int int_2;

		private bool bool_0;

		private Range range_2;

		internal IEnumerator<Range> ienumerator_0;

		private Range range_3;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class52(int int_3)
		{
			int_0 = int_3;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_395(this);
				}
			}
			fileTextSource_0 = null;
			range_2 = null;
			ienumerator_0 = null;
			range_3 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					range_1.Normalize();
					fileTextSource_0 = range_1.tb.TextSource as FileTextSource;
					int_2 = range_1.Start.iLine;
					goto IL_0050;
				}
				if (num == 1)
				{
					int_0 = -3;
					range_3 = null;
					goto IL_0121;
				}
				return false;
				IL_0050:
				if (int_2 <= range_1.End.iLine)
				{
					bool_0 = fileTextSource_0 == null || fileTextSource_0.IsLineLoaded(int_2);
					range_2 = new Range(range_1.tb, new Place(0, int_2), new Place(range_1.tb[int_2].Count, int_2));
					if (int_2 == range_1.Start.iLine || int_2 == range_1.End.iLine)
					{
						range_2 = range_2.GetIntersectionWith(range_1);
					}
					ienumerator_0 = range_2.GetRanges(regex_0).GetEnumerator();
					int_0 = -3;
					goto IL_0121;
				}
				return false;
				IL_0121:
				if (ienumerator_0.MoveNext())
				{
					range_3 = ienumerator_0.Current;
					range_0 = range_3;
					int_0 = 1;
					return true;
				}
				Class76.smethod_395(this);
				ienumerator_0 = null;
				if (!bool_0)
				{
					Class76.smethod_656(fileTextSource_0, int_2);
				}
				range_2 = null;
				int_2++;
				goto IL_0050;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class52 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class52(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.regex_0 = regex_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class Class53 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		private int int_0;

		private Range range_0;

		private int int_1;

		private string string_0;

		public string string_1;

		private RegexOptions regexOptions_0;

		public RegexOptions regexOptions_1;

		public Range range_1;

		private Regex regex_0;

		private FileTextSource fileTextSource_0;

		private int int_2;

		private bool bool_0;

		private Range range_2;

		private List<Range> list_0;

		private IEnumerator<Range> ienumerator_0;

		private Range range_3;

		private int int_3;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class53(int int_4)
		{
			int_0 = int_4;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			regex_0 = null;
			fileTextSource_0 = null;
			range_2 = null;
			list_0 = null;
			ienumerator_0 = null;
			range_3 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			int num = int_0;
			if (num == 0)
			{
				int_0 = -1;
				range_1.Normalize();
				regex_0 = new Regex(string_0, regexOptions_0);
				fileTextSource_0 = range_1.tb.TextSource as FileTextSource;
				int_2 = range_1.End.iLine;
				goto IL_0067;
			}
			if (num == 1)
			{
				int_0 = -1;
				int_3--;
				goto IL_01a4;
			}
			return false;
			IL_0067:
			if (int_2 >= range_1.Start.iLine)
			{
				bool_0 = fileTextSource_0 == null || fileTextSource_0.IsLineLoaded(int_2);
				range_2 = new Range(range_1.tb, new Place(0, int_2), new Place(range_1.tb[int_2].Count, int_2));
				if (int_2 == range_1.Start.iLine || int_2 == range_1.End.iLine)
				{
					range_2 = range_2.GetIntersectionWith(range_1);
				}
				list_0 = new List<Range>();
				ienumerator_0 = range_2.GetRanges(regex_0).GetEnumerator();
				try
				{
					while (ienumerator_0.MoveNext())
					{
						range_3 = ienumerator_0.Current;
						list_0.Add(range_3);
						range_3 = null;
					}
				}
				finally
				{
					if (ienumerator_0 != null)
					{
						ienumerator_0.Dispose();
					}
				}
				ienumerator_0 = null;
				int_3 = list_0.Count - 1;
				goto IL_01a4;
			}
			return false;
			IL_01a4:
			if (int_3 >= 0)
			{
				range_0 = list_0[int_3];
				int_0 = 1;
				return true;
			}
			if (!bool_0)
			{
				Class76.smethod_656(fileTextSource_0, int_2);
			}
			range_2 = null;
			list_0 = null;
			int_2--;
			goto IL_0067;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class53 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class53(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.string_0 = string_1;
			@class.regexOptions_0 = regexOptions_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class Class54 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		private int int_0;

		private Range range_0;

		private int int_1;

		private bool bool_0;

		public bool bool_1;

		public Range range_1;

		private RangeRect rangeRect_0;

		private int int_2;

		private Range range_2;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class54(int int_3)
		{
			int_0 = int_3;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			range_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			switch (int_0)
			{
			case 2:
				int_0 = -1;
				range_2 = null;
				goto IL_002c;
			default:
				return false;
			case 0:
				int_0 = -1;
				if (range_1.ColumnSelectionMode)
				{
					rangeRect_0 = range_1.Bounds;
					int_2 = rangeRect_0.iStartLine;
					goto IL_003c;
				}
				range_0 = range_1;
				int_0 = 1;
				return true;
			case 1:
				{
					int_0 = -1;
					return false;
				}
				IL_002c:
				int_2++;
				goto IL_003c;
				IL_003c:
				if (int_2 <= rangeRect_0.iEndLine)
				{
					if (rangeRect_0.iStartChar <= range_1.tb[int_2].Count || bool_0)
					{
						range_2 = new Range(range_1.tb, rangeRect_0.iStartChar, int_2, Math.Min(rangeRect_0.iEndChar, range_1.tb[int_2].Count), int_2);
						range_0 = range_2;
						int_0 = 2;
						return true;
					}
					goto IL_002c;
				}
				return false;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class54 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class54(0)
				{
					range_1 = range_1
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.bool_0 = bool_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class55 : IDisposable, IEnumerator<Place>, IEnumerator
	{
		internal int int_0;

		private Place place_0;

		public Range range_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		internal IEnumerator<Place> ienumerator_0;

		private Place place_1;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		Place IEnumerator<Place>.Current => place_0;

		object IEnumerator.Current => place_0;

		public Class55(int int_9)
		{
			int_0 = int_9;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_251(this);
				}
			}
			ienumerator_0 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 2:
					int_0 = -1;
					int_8++;
					goto IL_0032;
				default:
					return false;
				case 0:
					int_0 = -1;
					if (!range_0.ColumnSelectionMode)
					{
						int_1 = Math.Min(range_0.end.iLine, range_0.start.iLine);
						int_2 = Math.Max(range_0.end.iLine, range_0.start.iLine);
						int_3 = Class76.smethod_113(range_0);
						int_4 = Class76.smethod_236(range_0);
						if (int_1 >= 0)
						{
							int_5 = int_1;
							goto IL_011d;
						}
						return false;
					}
					ienumerator_0 = range_0.method_0().GetEnumerator();
					int_0 = -3;
					goto IL_01ae;
				case 1:
					{
						int_0 = -3;
						goto IL_01ae;
					}
					IL_0032:
					if (int_8 <= int_7)
					{
						place_0 = new Place(int_8, int_5);
						int_0 = 2;
						return true;
					}
					int_5++;
					goto IL_011d;
					IL_011d:
					if (int_5 <= int_2)
					{
						int_6 = ((int_5 == int_1) ? int_3 : 0);
						int_7 = ((int_5 != int_2) ? (range_0.tb[int_5].Count - 1) : Math.Min(int_4 - 1, range_0.tb[int_5].Count - 1));
						int_8 = int_6;
						goto IL_0032;
					}
					return false;
					IL_01ae:
					if (ienumerator_0.MoveNext())
					{
						place_1 = ienumerator_0.Current;
						place_0 = place_1;
						int_0 = 1;
						return true;
					}
					Class76.smethod_251(this);
					ienumerator_0 = null;
					return false;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	internal sealed class Class56 : IDisposable, IEnumerable, IEnumerable<Char>, IEnumerator, IEnumerator<Char>
	{
		internal int int_0;

		private Char char_0;

		private int int_1;

		public Range range_0;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		internal IEnumerator<Place> ienumerator_0;

		private Place place_0;

		private int int_6;

		private int int_7;

		private int int_8;

		private Line line_0;

		private int int_9;

		Char IEnumerator<Char>.Current => char_0;

		object IEnumerator.Current => char_0;

		public Class56(int int_10)
		{
			int_0 = int_10;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_548(this);
				}
			}
			ienumerator_0 = null;
			line_0 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 2:
					int_0 = -1;
					int_9++;
					goto IL_0032;
				default:
					return false;
				case 0:
					int_0 = -1;
					if (!range_0.ColumnSelectionMode)
					{
						int_2 = Math.Min(range_0.end.iLine, range_0.start.iLine);
						int_3 = Math.Max(range_0.end.iLine, range_0.start.iLine);
						int_4 = Class76.smethod_113(range_0);
						int_5 = Class76.smethod_236(range_0);
						if (int_2 >= 0)
						{
							int_6 = int_2;
							goto IL_011d;
						}
						return false;
					}
					ienumerator_0 = range_0.method_0().GetEnumerator();
					int_0 = -3;
					goto IL_01ca;
				case 1:
					{
						int_0 = -3;
						goto IL_01ca;
					}
					IL_0032:
					if (int_9 <= int_8)
					{
						char_0 = line_0[int_9];
						int_0 = 2;
						return true;
					}
					line_0 = null;
					int_6++;
					goto IL_011d;
					IL_011d:
					if (int_6 <= int_3)
					{
						int_7 = ((int_6 == int_2) ? int_4 : 0);
						int_8 = ((int_6 != int_3) ? (range_0.tb[int_6].Count - 1) : Math.Min(int_5 - 1, range_0.tb[int_6].Count - 1));
						line_0 = range_0.tb[int_6];
						int_9 = int_7;
						goto IL_0032;
					}
					return false;
					IL_01ca:
					if (ienumerator_0.MoveNext())
					{
						place_0 = ienumerator_0.Current;
						char_0 = range_0.tb[place_0];
						int_0 = 1;
						return true;
					}
					Class76.smethod_548(this);
					ienumerator_0 = null;
					return false;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Char> IEnumerable<Char>.GetEnumerator()
		{
			Class56 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class56(0)
				{
					range_0 = range_0
				};
			}
			else
			{
				int_0 = 0;
				result = this;
			}
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Char>)this).GetEnumerator();
		}
	}

	internal Place start;

	internal Place end;

	public readonly buMultiTextBox tb;

	internal int int_0 = -1;

	internal int int_1 = 0;

	internal string string_0;

	internal List<Place> list_0;

	internal int int_2 = -1;

	private bool bool_0;

	public virtual bool IsEmpty
	{
		get
		{
			if (!ColumnSelectionMode)
			{
				return Start == End;
			}
			return Start.iChar == End.iChar;
		}
	}

	public bool ColumnSelectionMode
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Place Start
	{
		get
		{
			return start;
		}
		set
		{
			end = (start = value);
			int_0 = -1;
			Class76.smethod_27(this);
		}
	}

	public Place End
	{
		get
		{
			return end;
		}
		set
		{
			end = value;
			Class76.smethod_27(this);
		}
	}

	public virtual string Text
	{
		get
		{
			if (!ColumnSelectionMode)
			{
				int num = Math.Min(end.iLine, start.iLine);
				int num2 = Math.Max(end.iLine, start.iLine);
				int num3 = Class76.smethod_113(this);
				int num4 = Class76.smethod_236(this);
				if (num >= 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = num; i <= num2; i++)
					{
						int num5 = ((i == num) ? num3 : 0);
						int num6 = ((i != num2) ? (tb[i].Count - 1) : Math.Min(tb[i].Count - 1, num4 - 1));
						for (int j = num5; j <= num6; j++)
						{
							stringBuilder.Append(tb[i][j].c);
						}
						if (i != num2 && num != num2)
						{
							stringBuilder.AppendLine();
						}
					}
					return stringBuilder.ToString();
				}
				return null;
			}
			return Class76.smethod_109(this);
		}
	}

	public int Length
	{
		get
		{
			if (!ColumnSelectionMode)
			{
				int num = Math.Min(end.iLine, start.iLine);
				int num2 = Math.Max(end.iLine, start.iLine);
				int num3 = 0;
				if (num >= 0)
				{
					for (int i = num; i <= num2; i++)
					{
						int num4 = ((i == num) ? Class76.smethod_113(this) : 0);
						int num5 = ((i != num2) ? (tb[i].Count - 1) : Math.Min(tb[i].Count - 1, Class76.smethod_236(this) - 1));
						num3 += num5 - num4 + 1;
						if (i != num2 && num != num2)
						{
							num3 += Environment.NewLine.Length;
						}
					}
					return num3;
				}
				return 0;
			}
			return Class76.smethod_447(false, this);
		}
	}

	public int TextLength
	{
		get
		{
			if (!ColumnSelectionMode)
			{
				return Length;
			}
			return Class76.smethod_447(true, this);
		}
	}

	public char CharAfterStart
	{
		get
		{
			if (Start.iChar < tb[Start.iLine].Count)
			{
				return tb[Start.iLine][Start.iChar].c;
			}
			return '\n';
		}
	}

	public char CharBeforeStart
	{
		get
		{
			if (Start.iChar <= tb[Start.iLine].Count)
			{
				if (Start.iChar > 0)
				{
					return tb[Start.iLine][Start.iChar - 1].c;
				}
				return '\n';
			}
			return '\n';
		}
	}

	public int FromLine => Math.Min(Start.iLine, End.iLine);

	public int ToLine => Math.Max(Start.iLine, End.iLine);

	public IEnumerable<Char> Chars
	{
		[IteratorStateMachine(typeof(Class56))]
		get
		{
			//yield-return decompiler failed: Method not found
			Class56 @class = new Class56(-2);
			@class.range_0 = this;
			return @class;
		}
	}

	public RangeRect Bounds
	{
		get
		{
			int iStartChar = Math.Min(Start.iChar, End.iChar);
			int iStartLine = Math.Min(Start.iLine, End.iLine);
			int iEndChar = Math.Max(Start.iChar, End.iChar);
			int iEndLine = Math.Max(Start.iLine, End.iLine);
			return new RangeRect(iStartLine, iStartChar, iEndLine, iEndChar);
		}
	}

	public bool ReadOnly
	{
		get
		{
			if (!tb.ReadOnly)
			{
				ReadOnlyStyle readOnlyStyle = null;
				Style[] styles = tb.Styles;
				foreach (Style style in styles)
				{
					if (style is ReadOnlyStyle)
					{
						readOnlyStyle = (ReadOnlyStyle)style;
						break;
					}
				}
				if (readOnlyStyle != null)
				{
					StyleIndex styleIndex = ToStyleIndex(tb.GetStyleIndex(readOnlyStyle));
					if (!IsEmpty)
					{
						foreach (Char @char in Chars)
						{
							if ((@char.style & styleIndex) != StyleIndex.None)
							{
								return true;
							}
						}
					}
					else
					{
						Line line = tb[start.iLine];
						if (!bool_0)
						{
							if (start.iChar < line.Count && start.iChar > 0)
							{
								Char obj = line[start.iChar - 1];
								Char obj2 = line[start.iChar];
								if ((obj.style & styleIndex) != StyleIndex.None && (obj2.style & styleIndex) != StyleIndex.None)
								{
									return true;
								}
							}
						}
						else
						{
							foreach (Range subRange in GetSubRanges(includeEmpty: false))
							{
								line = tb[subRange.start.iLine];
								if (subRange.start.iChar < line.Count && subRange.start.iChar > 0)
								{
									Char obj3 = line[subRange.start.iChar - 1];
									Char obj4 = line[subRange.start.iChar];
									if ((obj3.style & styleIndex) != StyleIndex.None && (obj4.style & styleIndex) != StyleIndex.None)
									{
										return true;
									}
								}
							}
						}
					}
				}
				return false;
			}
			return true;
		}
		set
		{
			ReadOnlyStyle readOnlyStyle = null;
			Style[] styles = tb.Styles;
			foreach (Style style in styles)
			{
				if (style is ReadOnlyStyle)
				{
					readOnlyStyle = (ReadOnlyStyle)style;
					break;
				}
			}
			if (readOnlyStyle == null)
			{
				readOnlyStyle = new ReadOnlyStyle();
			}
			if (!value)
			{
				ClearStyle(readOnlyStyle);
			}
			else
			{
				SetStyle(readOnlyStyle);
			}
		}
	}

	public Range(buMultiTextBox tb)
	{
		this.tb = tb;
	}

	public Range(buMultiTextBox tb, int iStartChar, int iStartLine, int iEndChar, int iEndLine)
		: this(tb)
	{
		start = new Place(iStartChar, iStartLine);
		end = new Place(iEndChar, iEndLine);
	}

	public Range(buMultiTextBox tb, Place start, Place end)
		: this(tb)
	{
		this.start = start;
		this.end = end;
	}

	public Range(buMultiTextBox tb, int iLine)
		: this(tb)
	{
		start = new Place(0, iLine);
		end = new Place(tb[iLine].Count, iLine);
	}

	public bool Contains(Place place)
	{
		if (place.iLine >= Math.Min(start.iLine, end.iLine))
		{
			if (place.iLine <= Math.Max(start.iLine, end.iLine))
			{
				Place place2 = start;
				Place place3 = end;
				if (place2.iLine > place3.iLine || (place2.iLine == place3.iLine && place2.iChar > place3.iChar))
				{
					Place place4 = place2;
					place2 = place3;
					place3 = place4;
				}
				if (!bool_0)
				{
					if (place.iLine == place2.iLine && place.iChar < place2.iChar)
					{
						return false;
					}
					if (place.iLine == place3.iLine && place.iChar > place3.iChar)
					{
						return false;
					}
				}
				else if (place.iChar < place2.iChar || place.iChar > place3.iChar)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public virtual Range GetIntersectionWith(Range range)
	{
		if (!ColumnSelectionMode)
		{
			Range range2 = Clone();
			Range range3 = range.Clone();
			range2.Normalize();
			range3.Normalize();
			Place place = ((!(range2.Start > range3.Start)) ? range3.Start : range2.Start);
			Place place2 = ((!(range2.End < range3.End)) ? range3.End : range2.End);
			if (!(place2 < place))
			{
				return tb.GetRange(place, place2);
			}
			return new Range(tb, start, start);
		}
		return Class76.smethod_552(range, this);
	}

	public Range GetUnionWith(Range range)
	{
		Range range2 = Clone();
		Range range3 = range.Clone();
		range2.Normalize();
		range3.Normalize();
		Place fromPlace = ((!(range2.Start < range3.Start)) ? range3.Start : range2.Start);
		Place toPlace = ((!(range2.End > range3.End)) ? range3.End : range2.End);
		return tb.GetRange(fromPlace, toPlace);
	}

	public void SelectAll()
	{
		ColumnSelectionMode = false;
		Start = new Place(0, 0);
		if (tb.LinesCount != 0)
		{
			end = new Place(0, 0);
			start = new Place(tb[tb.LinesCount - 1].Count, tb.LinesCount - 1);
		}
		else
		{
			Start = new Place(0, 0);
		}
		if (this == tb.Selection)
		{
			tb.Invalidate();
		}
	}

	public string GetCharsBeforeStart(int charsCount)
	{
		int num = tb.PlaceToPosition(Start) - charsCount;
		if (num < 0)
		{
			num = 0;
		}
		return new Range(tb, tb.PositionToPlace(num), Start).Text;
	}

	public string GetCharsAfterStart(int charsCount)
	{
		return GetCharsBeforeStart(-charsCount);
	}

	public Range Clone()
	{
		return (Range)MemberwiseClone();
	}

	public bool GoRight()
	{
		Place place = start;
		GoRight(shift: false);
		return place != start;
	}

	public virtual bool GoRightThroughFolded()
	{
		if (!ColumnSelectionMode)
		{
			if (start.iLine < tb.LinesCount - 1 || start.iChar < tb[tb.LinesCount - 1].Count)
			{
				if (start.iChar >= tb[start.iLine].Count)
				{
					start = new Place(0, start.iLine + 1);
				}
				else
				{
					start.Offset(1, 0);
				}
				int_0 = -1;
				end = start;
				Class76.smethod_27(this);
				return true;
			}
			return false;
		}
		return Class76.smethod_732(this);
	}

	public bool GoLeft()
	{
		ColumnSelectionMode = false;
		Place place = start;
		GoLeft(shift: false);
		return place != start;
	}

	public bool GoLeftThroughFolded()
	{
		ColumnSelectionMode = false;
		if (start.iChar != 0 || start.iLine != 0)
		{
			if (start.iChar <= 0)
			{
				start = new Place(tb[start.iLine - 1].Count, start.iLine - 1);
			}
			else
			{
				start.Offset(-1, 0);
			}
			int_0 = -1;
			end = start;
			Class76.smethod_27(this);
			return true;
		}
		return false;
	}

	public void GoLeft(bool shift)
	{
		ColumnSelectionMode = false;
		if (shift || !(start > end))
		{
			if (start.iChar != 0 || start.iLine != 0)
			{
				if (start.iChar <= 0 || tb.LineInfos[start.iLine].VisibleState != VisibleState.Visible)
				{
					int num = Class76.smethod_735(tb, start.iLine);
					if (num == start.iLine)
					{
						return;
					}
					start = new Place(tb[num].Count, num);
				}
				else
				{
					start.Offset(-1, 0);
				}
			}
			if (!shift)
			{
				end = start;
			}
			Class76.smethod_27(this);
			int_0 = -1;
		}
		else
		{
			Start = End;
		}
	}

	public void GoRight(bool shift)
	{
		ColumnSelectionMode = false;
		if (shift || !(start < end))
		{
			if (start.iLine < tb.LinesCount - 1 || start.iChar < tb[tb.LinesCount - 1].Count)
			{
				if (start.iChar >= tb[start.iLine].Count || tb.LineInfos[start.iLine].VisibleState != VisibleState.Visible)
				{
					int num = Class76.smethod_97(tb, start.iLine);
					if (num == start.iLine)
					{
						return;
					}
					start = new Place(0, num);
				}
				else
				{
					start.Offset(1, 0);
				}
			}
			if (!shift)
			{
				end = start;
			}
			Class76.smethod_27(this);
			int_0 = -1;
		}
		else
		{
			Start = End;
		}
	}

	public void SetStyle(Style style)
	{
		int i = Class76.smethod_241(tb, style);
		SetStyle(ToStyleIndex(i));
		tb.Invalidate();
	}

	public void SetStyle(Style style, string regexPattern)
	{
		StyleIndex styleLayer = ToStyleIndex(Class76.smethod_241(tb, style));
		SetStyle(styleLayer, regexPattern, RegexOptions.None);
	}

	public void SetStyle(Style style, Regex regex)
	{
		StyleIndex styleLayer = ToStyleIndex(Class76.smethod_241(tb, style));
		SetStyle(styleLayer, regex);
	}

	public void SetStyle(Style style, string regexPattern, RegexOptions options)
	{
		StyleIndex styleLayer = ToStyleIndex(Class76.smethod_241(tb, style));
		SetStyle(styleLayer, regexPattern, options);
	}

	public void SetStyle(StyleIndex styleLayer, string regexPattern, RegexOptions options)
	{
		if (Math.Abs(Start.iLine - End.iLine) > 1000)
		{
			options |= SyntaxHighlighter.RegexCompiledOption;
		}
		foreach (Range range in GetRanges(regexPattern, options))
		{
			range.SetStyle(styleLayer);
		}
		tb.Invalidate();
	}

	public void SetStyle(StyleIndex styleLayer, Regex regex)
	{
		foreach (Range range in GetRanges(regex))
		{
			range.SetStyle(styleLayer);
		}
		tb.Invalidate();
	}

	public void SetStyle(StyleIndex styleIndex)
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		int num3 = Class76.smethod_113(this);
		int num4 = Class76.smethod_236(this);
		if (num < 0)
		{
			return;
		}
		for (int i = num; i <= num2; i++)
		{
			int num5 = ((i == num) ? num3 : 0);
			int num6 = ((i != num2) ? (tb[i].Count - 1) : Math.Min(num4 - 1, tb[i].Count - 1));
			for (int j = num5; j <= num6; j++)
			{
				Char value = tb[i][j];
				value.style |= styleIndex;
				tb[i][j] = value;
			}
		}
	}

	public void SetFoldingMarkers(string startFoldingPattern, string finishFoldingPattern)
	{
		SetFoldingMarkers(startFoldingPattern, finishFoldingPattern, SyntaxHighlighter.RegexCompiledOption);
	}

	public void SetFoldingMarkers(string startFoldingPattern, string finishFoldingPattern, RegexOptions options)
	{
		if (!(startFoldingPattern == finishFoldingPattern))
		{
			foreach (Range range in GetRanges(startFoldingPattern, options))
			{
				tb[range.Start.iLine].FoldingStartMarker = startFoldingPattern;
			}
			foreach (Range range2 in GetRanges(finishFoldingPattern, options))
			{
				tb[range2.Start.iLine].FoldingEndMarker = startFoldingPattern;
			}
			tb.Invalidate();
		}
		else
		{
			SetFoldingMarkers(startFoldingPattern, options);
		}
	}

	public void SetFoldingMarkers(string foldingPattern, RegexOptions options)
	{
		foreach (Range range in GetRanges(foldingPattern, options))
		{
			if (range.Start.iLine > 0)
			{
				tb[range.Start.iLine - 1].FoldingEndMarker = foldingPattern;
			}
			tb[range.Start.iLine].FoldingStartMarker = foldingPattern;
		}
		tb.Invalidate();
	}

	public IEnumerable<Range> GetRanges(string regexPattern)
	{
		return GetRanges(regexPattern, RegexOptions.None);
	}

	[IteratorStateMachine(typeof(Class49))]
	public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
	{
		//yield-return decompiler failed: Method not found
		return new Class49(-2)
		{
			range_1 = this,
			string_1 = regexPattern,
			regexOptions_1 = options
		};
	}

	[IteratorStateMachine(typeof(Class51))]
	public IEnumerable<Range> GetRangesByLines(string regexPattern, RegexOptions options)
	{
		//yield-return decompiler failed: Method not found
		return new Class51(-2)
		{
			range_1 = this,
			string_1 = regexPattern,
			regexOptions_1 = options
		};
	}

	[IteratorStateMachine(typeof(Class52))]
	public IEnumerable<Range> GetRangesByLines(Regex regex)
	{
		//yield-return decompiler failed: Method not found
		return new Class52(-2)
		{
			range_1 = this,
			regex_1 = regex
		};
	}

	[IteratorStateMachine(typeof(Class53))]
	public IEnumerable<Range> GetRangesByLinesReversed(string regexPattern, RegexOptions options)
	{
		//yield-return decompiler failed: Method not found
		return new Class53(-2)
		{
			range_1 = this,
			string_1 = regexPattern,
			regexOptions_1 = options
		};
	}

	[IteratorStateMachine(typeof(Class50))]
	public IEnumerable<Range> GetRanges(Regex regex)
	{
		//yield-return decompiler failed: Method not found
		return new Class50(-2)
		{
			range_1 = this,
			regex_1 = regex
		};
	}

	public void ClearStyle(params Style[] styles)
	{
		try
		{
			ClearStyle(tb.GetStyleIndexMask(styles));
		}
		catch
		{
		}
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		int num3 = Class76.smethod_113(this);
		int num4 = Class76.smethod_236(this);
		if (num < 0)
		{
			return;
		}
		for (int i = num; i <= num2; i++)
		{
			int num5 = ((i == num) ? num3 : 0);
			int num6 = ((i != num2) ? (tb[i].Count - 1) : Math.Min(num4 - 1, tb[i].Count - 1));
			for (int j = num5; j <= num6; j++)
			{
				Char value = tb[i][j];
				value.style &= (StyleIndex)(ushort)(~(int)styleIndex);
				tb[i][j] = value;
			}
		}
		tb.Invalidate();
	}

	public void ClearFoldingMarkers()
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		if (num >= 0)
		{
			for (int i = num; i <= num2; i++)
			{
				tb[i].ClearFoldingMarkers();
			}
			tb.Invalidate();
		}
	}

	public void BeginUpdate()
	{
		int_1++;
	}

	public void EndUpdate()
	{
		int_1--;
		if (int_1 == 0)
		{
			Class76.smethod_27(this);
		}
	}

	public override string ToString()
	{
		return "Start: " + Start.ToString() + " End: " + End.ToString();
	}

	public void Normalize()
	{
		if (Start > End)
		{
			Inverse();
		}
	}

	public void Inverse()
	{
		Place place = start;
		start = end;
		end = place;
	}

	public void Expand()
	{
		Normalize();
		start = new Place(0, start.iLine);
		end = new Place(tb.GetLineLength(end.iLine), end.iLine);
	}

	[IteratorStateMachine(typeof(Class55))]
	IEnumerator<Place> IEnumerable<Place>.GetEnumerator()
	{
		//yield-return decompiler failed: Method not found
		return new Class55(0)
		{
			range_0 = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<Place>)this).GetEnumerator();
	}

	public Range GetFragment(string allowedSymbolsPattern)
	{
		return GetFragment(allowedSymbolsPattern, RegexOptions.None);
	}

	public Range GetFragment(Style style, bool allowLineBreaks)
	{
		StyleIndex styleIndexMask = tb.GetStyleIndexMask(new Style[1] { style });
		Range range = new Range(tb);
		range.Start = Start;
		while (range.GoLeftThroughFolded() && (allowLineBreaks || range.CharAfterStart != '\n'))
		{
			if (range.Start.iChar < tb.GetLineLength(range.Start.iLine) && (tb[range.Start].style & styleIndexMask) == 0)
			{
				range.GoRightThroughFolded();
				break;
			}
		}
		Place place = range.Start;
		range.Start = Start;
		while ((allowLineBreaks || range.CharAfterStart != '\n') && (range.Start.iChar >= tb.GetLineLength(range.Start.iLine) || (tb[range.Start].style & styleIndexMask) != StyleIndex.None) && range.GoRightThroughFolded())
		{
		}
		Place place2 = range.Start;
		return new Range(tb, place, place2);
	}

	public Range GetFragment(string allowedSymbolsPattern, RegexOptions options)
	{
		Range range = new Range(tb);
		range.Start = Start;
		Regex regex = new Regex(allowedSymbolsPattern, options);
		while (range.GoLeftThroughFolded())
		{
			if (!regex.IsMatch(range.CharAfterStart.ToString()))
			{
				range.GoRightThroughFolded();
				break;
			}
		}
		Place place = range.Start;
		range.Start = Start;
		while (regex.IsMatch(range.CharAfterStart.ToString()) && range.GoRightThroughFolded())
		{
		}
		Place place2 = range.Start;
		return new Range(tb, place, place2);
	}

	public void GoWordLeft(bool shift)
	{
		ColumnSelectionMode = false;
		if (shift || !(start > end))
		{
			Range range = Clone();
			bool flag = false;
			while (Class76.smethod_47(this, range.CharBeforeStart))
			{
				flag = true;
				range.GoLeft(shift);
			}
			bool flag2 = false;
			while (Class76.smethod_254(this, range.CharBeforeStart))
			{
				flag2 = true;
				range.GoLeft(shift);
			}
			if (!flag2 && (!flag || range.CharBeforeStart != '\n'))
			{
				range.GoLeft(shift);
			}
			Start = range.Start;
			End = range.End;
			if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
			{
				GoRight(shift);
			}
		}
		else
		{
			Start = End;
		}
	}

	public void GoWordRight(bool shift, bool goToStartOfNextWord = false)
	{
		ColumnSelectionMode = false;
		if (shift || !(start < end))
		{
			Range range = Clone();
			bool flag = false;
			if (range.CharAfterStart == '\n')
			{
				range.GoRight(shift);
				flag = true;
			}
			bool flag2 = false;
			while (Class76.smethod_47(this, range.CharAfterStart))
			{
				flag2 = true;
				range.GoRight(shift);
			}
			if (!((flag2 || flag) && goToStartOfNextWord))
			{
				bool flag3 = false;
				while (Class76.smethod_254(this, range.CharAfterStart))
				{
					flag3 = true;
					range.GoRight(shift);
				}
				if (!flag3)
				{
					range.GoRight(shift);
				}
				if (goToStartOfNextWord && !flag2)
				{
					while (Class76.smethod_47(this, range.CharAfterStart))
					{
						range.GoRight(shift);
					}
				}
			}
			Start = range.Start;
			End = range.End;
			if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
			{
				GoLeft(shift);
			}
		}
		else
		{
			Start = End;
		}
	}

	public static StyleIndex ToStyleIndex(int i)
	{
		return (StyleIndex)(1 << i);
	}

	[IteratorStateMachine(typeof(Class54))]
	public IEnumerable<Range> GetSubRanges(bool includeEmpty)
	{
		//yield-return decompiler failed: Method not found
		return new Class54(-2)
		{
			range_1 = this,
			bool_1 = includeEmpty
		};
	}

	public bool IsReadOnlyLeftChar()
	{
		if (!tb.ReadOnly)
		{
			Range range = Clone();
			range.Normalize();
			if (range.start.iChar != 0)
			{
				if (!ColumnSelectionMode)
				{
					range.GoLeft(shift: true);
				}
				else
				{
					Class76.smethod_198(range);
				}
				return range.ReadOnly;
			}
			return false;
		}
		return true;
	}

	public bool IsReadOnlyRightChar()
	{
		if (!tb.ReadOnly)
		{
			Range range = Clone();
			range.Normalize();
			if (range.end.iChar < tb[end.iLine].Count)
			{
				if (!ColumnSelectionMode)
				{
					range.GoRight(shift: true);
				}
				else
				{
					Class76.smethod_847(range);
				}
				return range.ReadOnly;
			}
			return false;
		}
		return true;
	}

	[IteratorStateMachine(typeof(Class48))]
	public IEnumerable<Place> GetPlacesCyclic(Place startPlace, bool backward = false)
	{
		//yield-return decompiler failed: Method not found
		return new Class48(-2)
		{
			range_0 = this,
			place_2 = startPlace,
			bool_1 = backward
		};
	}

	[IteratorStateMachine(typeof(Class47))]
	private IEnumerable<Place> method_0()
	{
		//yield-return decompiler failed: Method not found
		return new Class47(-2)
		{
			range_0 = this
		};
	}
}
