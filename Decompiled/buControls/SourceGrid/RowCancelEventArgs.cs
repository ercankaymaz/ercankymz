namespace SourceGrid;

public class RowCancelEventArgs : RowEventArgs
{
	private bool bool_0 = false;

	private int proposedFocusedRow;

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

	public int ProposedRow => proposedFocusedRow;

	public RowCancelEventArgs(int currentFocusedRow, int proposedFocusedRow)
		: base(currentFocusedRow)
	{
		this.proposedFocusedRow = proposedFocusedRow;
	}
}
