using System;

namespace SourceGrid;

public class RowInfoEventArgs : EventArgs
{
	private RowInfo p_RowInfo;

	public RowInfo Row => p_RowInfo;

	public RowInfoEventArgs(RowInfo p_RowInfo)
	{
		this.p_RowInfo = p_RowInfo;
	}
}
