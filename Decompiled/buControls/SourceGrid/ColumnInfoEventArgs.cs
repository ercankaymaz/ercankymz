using System;

namespace SourceGrid;

public class ColumnInfoEventArgs : EventArgs
{
	private ColumnInfo p_ColumnInfo;

	public ColumnInfo Column => p_ColumnInfo;

	public ColumnInfoEventArgs(ColumnInfo p_ColumnInfo)
	{
		this.p_ColumnInfo = p_ColumnInfo;
	}
}
