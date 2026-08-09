using System.Collections.Generic;
using QuadTreeLib;

namespace SourceGrid;

public class QuadTreeRangesList : QuadTree, ISpannedRangesCollection
{
	public QuadTreeRangesList(Range bounds)
		: base(bounds)
	{
	}

	public Range[] ToArray()
	{
		return base.Contents.ToArray();
	}

	public new void Remove(Range range)
	{
		base.Remove(range);
	}

	public void Redim(int rowCount, int colCount)
	{
		while (base.Bounds.RowsCount <= rowCount)
		{
			Grow();
		}
		while (base.Bounds.ColumnsCount <= colCount)
		{
			Grow();
		}
	}

	public void Update(Range oldRange, Range newRange)
	{
		if (!QueryFirst(oldRange.Start).HasValue)
		{
			throw new RangeNotFoundException();
		}
		Remove(oldRange);
		Insert(newRange);
	}

	public void Add(Range range)
	{
		Insert(range);
	}

	public List<Range> GetRanges(Range range)
	{
		return Query(range);
	}

	public Range? GetFirstIntersectedRange(Position pos)
	{
		return QueryFirst(pos) ?? ((Range?)null);
	}

	public Range? FindRangeWithStart(Position start)
	{
		return QueryFirst(start);
	}
}
