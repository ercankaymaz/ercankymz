namespace SourceGrid;

public class ValidatingCellEventArgs : CellCancelEventArgs
{
	private object p_NewValue;

	public object NewValue
	{
		get
		{
			return p_NewValue;
		}
		set
		{
			p_NewValue = value;
		}
	}

	public ValidatingCellEventArgs(CellContext pCellContext, object p_NewValue)
		: base(pCellContext)
	{
		this.p_NewValue = p_NewValue;
	}
}
