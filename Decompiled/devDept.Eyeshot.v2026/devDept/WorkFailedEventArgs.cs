using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept;

public class WorkFailedEventArgs : WorkUnitEventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Exception _0023_003DzXs4Gi_JKah92K31lkg_003D_003D;

	public Exception Exception
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXs4Gi_JKah92K31lkg_003D_003D;
		}
	}

	public string Error => Exception?.ToString();

	public WorkFailedEventArgs(WorkUnit wu, Exception exception)
		: base(wu)
	{
		_0023_003DzXs4Gi_JKah92K31lkg_003D_003D = exception;
	}
}
