namespace SourceGrid;

public class CellCancelEventArgs(CellContext pCellContext) : CellContextEventArgs(pCellContext)
{
	private bool bool_0 = false;

	public bool Cancel
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}
}
