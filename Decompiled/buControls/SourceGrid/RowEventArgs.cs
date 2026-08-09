using System;

namespace SourceGrid;

public class RowEventArgs : EventArgs
{
	private int pRow;

	public int Row
	{
		get
		{
			return pRow;
		}
		set
		{
			pRow = value;
		}
	}

	public RowEventArgs(int pRow)
	{
		this.pRow = pRow;
	}
}
