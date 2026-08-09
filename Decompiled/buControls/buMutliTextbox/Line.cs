using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace buMutliTextbox;

public class Line : IEnumerable, IEnumerable<Char>, IList<Char>, ICollection<Char>
{
	protected List<Char> chars;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private Brush brush_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	public string FoldingStartMarker
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string FoldingEndMarker
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public bool IsChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public DateTime LastVisit
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public Brush BackgroundBrush
	{
		[CompilerGenerated]
		get
		{
			return brush_0;
		}
		[CompilerGenerated]
		set
		{
			brush_0 = value;
		}
	}

	public int UniqueId
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public int AutoIndentSpacesNeededCount
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public virtual string Text
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder(Count);
			using (IEnumerator<Char> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(enumerator.Current.c);
				}
			}
			return stringBuilder.ToString();
		}
	}

	public int StartSpacesCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < Count && this[i].c == ' '; i++)
			{
				num++;
			}
			return num;
		}
	}

	public Char this[int index]
	{
		get
		{
			return chars[index];
		}
		set
		{
			chars[index] = value;
		}
	}

	public int Count => chars.Count;

	public bool IsReadOnly => false;

	internal Line(int int_2)
	{
		UniqueId = int_2;
		chars = new List<Char>();
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		FoldingStartMarker = null;
		FoldingEndMarker = null;
		for (int i = 0; i < Count; i++)
		{
			Char value = this[i];
			value.style &= (StyleIndex)(ushort)(~(int)styleIndex);
			this[i] = value;
		}
	}

	public void ClearFoldingMarkers()
	{
		FoldingStartMarker = null;
		FoldingEndMarker = null;
	}

	public int IndexOf(Char item)
	{
		return chars.IndexOf(item);
	}

	public void Insert(int index, Char item)
	{
		chars.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		chars.RemoveAt(index);
	}

	public void Add(Char item)
	{
		chars.Add(item);
	}

	public void Clear()
	{
		chars.Clear();
	}

	public bool Contains(Char item)
	{
		return chars.Contains(item);
	}

	public void CopyTo(Char[] array, int arrayIndex)
	{
		chars.CopyTo(array, arrayIndex);
	}

	public bool Remove(Char item)
	{
		return chars.Remove(item);
	}

	public IEnumerator<Char> GetEnumerator()
	{
		return chars.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return chars.GetEnumerator();
	}

	public virtual void RemoveRange(int index, int count)
	{
		if (index < Count)
		{
			chars.RemoveRange(index, Math.Min(Count - index, count));
		}
	}

	public virtual void TrimExcess()
	{
		chars.TrimExcess();
	}

	public virtual void AddRange(IEnumerable<Char> collection)
	{
		chars.AddRange(collection);
	}
}
