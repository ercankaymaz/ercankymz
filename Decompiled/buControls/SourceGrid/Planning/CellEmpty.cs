using System;
using SourceGrid.Cells;

namespace SourceGrid.Planning;

public class CellEmpty : Cell
{
	private DateTime start;

	private DateTime end;

	public DateTime Start => start;

	public DateTime End => end;

	public CellEmpty(DateTime start, DateTime end)
		: base(null)
	{
		this.start = start;
		this.end = end;
	}
}
