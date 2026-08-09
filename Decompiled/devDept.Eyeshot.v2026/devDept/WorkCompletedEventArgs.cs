namespace devDept;

public class WorkCompletedEventArgs : WorkUnitEventArgs
{
	public WorkCompletedEventArgs(WorkUnit wu)
		: base(wu)
	{
	}
}
