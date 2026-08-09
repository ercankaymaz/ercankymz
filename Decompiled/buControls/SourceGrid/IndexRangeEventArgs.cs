using System;

namespace SourceGrid;

public class IndexRangeEventArgs : EventArgs
{
	private int p_iStartIndex;

	private int p_iCount;

	public int StartIndex => p_iStartIndex;

	public int Count => p_iCount;

	public IndexRangeEventArgs(int p_iStartIndex, int p_iCount)
	{
		this.p_iStartIndex = p_iStartIndex;
		this.p_iCount = p_iCount;
	}
}
