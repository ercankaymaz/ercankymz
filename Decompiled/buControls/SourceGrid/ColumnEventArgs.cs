using System;

namespace SourceGrid;

public class ColumnEventArgs : EventArgs
{
	private int pColumn;

	public int Column
	{
		get
		{
			return pColumn;
		}
		set
		{
			pColumn = value;
		}
	}

	public ColumnEventArgs(int pColumn)
	{
		this.pColumn = pColumn;
	}
}
