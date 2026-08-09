using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept;

public class WorkUnitEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly WorkUnit _0023_003DzpxwtqFufOF_1T7SOOjha4S4_003D;

	public WorkUnit WorkUnit
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpxwtqFufOF_1T7SOOjha4S4_003D;
		}
	}

	public WorkUnitEventArgs(WorkUnit wu)
	{
		_0023_003DzpxwtqFufOF_1T7SOOjha4S4_003D = wu;
	}
}
