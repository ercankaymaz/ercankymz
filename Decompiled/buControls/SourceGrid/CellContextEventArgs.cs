using System;

namespace SourceGrid;

public class CellContextEventArgs : EventArgs
{
	private CellContext pCellContext;

	public CellContext CellContext => pCellContext;

	public CellContextEventArgs(CellContext pCellContext)
	{
		this.pCellContext = pCellContext;
	}
}
