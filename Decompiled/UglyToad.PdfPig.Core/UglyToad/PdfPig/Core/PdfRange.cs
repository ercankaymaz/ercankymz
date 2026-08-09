using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Core;

public readonly struct PdfRange
{
	private readonly IReadOnlyList<double> rangeArray;

	private readonly int startingIndex;

	public double Min => rangeArray[startingIndex * 2];

	public double Max => rangeArray[startingIndex * 2 + 1];

	public PdfRange(IEnumerable<double> range)
		: this(range, 0)
	{
	}

	public PdfRange(IEnumerable<double> range, int index)
	{
		rangeArray = range.ToArray();
		startingIndex = index;
	}
}
