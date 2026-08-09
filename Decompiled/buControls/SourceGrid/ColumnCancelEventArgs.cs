namespace SourceGrid;

public class ColumnCancelEventArgs : ColumnEventArgs
{
	private bool bool_0;

	private int proposedFocusedColumn;

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

	public int ProposedColumn => proposedFocusedColumn;

	public ColumnCancelEventArgs(int currentFocusedColumn, int proposedFocusedColumn)
		: base(currentFocusedColumn)
	{
		this.proposedFocusedColumn = proposedFocusedColumn;
	}
}
