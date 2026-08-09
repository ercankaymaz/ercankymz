using System.Collections.Generic;

namespace SourceGrid;

public interface ISpannedRangesCollection
{
	int Count { get; }

	void Add(Range range);

	void Update(Range oldRange, Range newRange);

	void Redim(int rowCount, int colCount);

	void Remove(Range range);

	Range? GetFirstIntersectedRange(Position pos);

	List<Range> GetRanges(Range range);

	Range? FindRangeWithStart(Position start);

	Range[] ToArray();
}
