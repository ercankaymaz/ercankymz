using System.Collections.Generic;

namespace SourceGrid;

public class SpannedRangesList : List<Range>, ISpannedRangesCollection
{
	public void Update(Range oldRange, Range newRange)
	{
		int num = IndexOf(oldRange);
		if (num < 0)
		{
			throw new RangeNotFoundException();
		}
		base[num] = newRange;
	}

	public void Redim(int rowCount, int colCount)
	{
	}

	public new void Remove(Range range)
	{
		int num = IndexOf(range);
		if (num < 0)
		{
			throw new RangeNotFoundException();
		}
		RemoveAt(num);
	}

	public Range? GetFirstIntersectedRange(Position pos)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Range value = base[i];
			if (value.Contains(pos))
			{
				return value;
			}
		}
		return null;
	}

	public List<Range> GetRanges(Range range)
	{
		List<Range> list = new List<Range>();
		for (int i = 0; i < base.Count; i++)
		{
			Range item = base[i];
			if (item.Contains(range))
			{
				list.Add(item);
			}
		}
		return list;
	}

	public Range? FindRangeWithStart(Position start)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Range value = base[i];
			if (value.Start.Equals(start))
			{
				return value;
			}
		}
		return null;
	}

	Range[] ISpannedRangesCollection.ToArray()
	{
		return ToArray();
	}
}
