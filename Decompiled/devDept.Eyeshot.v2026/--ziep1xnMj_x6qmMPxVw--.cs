using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003Dziep1xnMj_x6qmMPxVw_003D_003D<_0023_003DzI_Ff6bs_003D, _0023_003DzNLSLrIc_003D> : IComparer<_0023_003DzI_Ff6bs_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Func<_0023_003DzI_Ff6bs_003D, _0023_003DzNLSLrIc_003D> _0023_003DzMyACiOA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IComparer<_0023_003DzNLSLrIc_003D> _0023_003Dz4zn204U_003D;

	public _0023_003Dziep1xnMj_x6qmMPxVw_003D_003D(Func<_0023_003DzI_Ff6bs_003D, _0023_003DzNLSLrIc_003D> _0023_003DzMyACiOA_003D)
		: this(_0023_003DzMyACiOA_003D, (IComparer<_0023_003DzNLSLrIc_003D>)null)
	{
	}

	public _0023_003Dziep1xnMj_x6qmMPxVw_003D_003D(Func<_0023_003DzI_Ff6bs_003D, _0023_003DzNLSLrIc_003D> _0023_003DzMyACiOA_003D, IComparer<_0023_003DzNLSLrIc_003D> _0023_003Dz4zn204U_003D)
	{
		this._0023_003Dz4zn204U_003D = _0023_003Dz4zn204U_003D ?? Comparer<_0023_003DzNLSLrIc_003D>.Default;
		this._0023_003DzMyACiOA_003D = _0023_003DzMyACiOA_003D;
	}

	public int Compare(_0023_003DzI_Ff6bs_003D _0023_003DzBJFJHwk_003D, _0023_003DzI_Ff6bs_003D _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D == null && _0023_003Dz40R7bAU_003D == null)
		{
			return 0;
		}
		if (_0023_003DzBJFJHwk_003D == null)
		{
			return -1;
		}
		if (_0023_003Dz40R7bAU_003D == null)
		{
			return 1;
		}
		return _0023_003Dz4zn204U_003D.Compare(_0023_003DzMyACiOA_003D(_0023_003DzBJFJHwk_003D), _0023_003DzMyACiOA_003D(_0023_003Dz40R7bAU_003D));
	}
}
