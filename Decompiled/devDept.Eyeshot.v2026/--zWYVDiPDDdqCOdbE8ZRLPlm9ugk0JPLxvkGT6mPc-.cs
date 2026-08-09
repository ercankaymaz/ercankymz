using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzWYVDiPDDdqCOdbE8ZRLPlm9ugk0JPLxvkGT6mPc_003D : IComparer<_0023_003Dz9EaLsos56zhlqklwSdaMHsBa9NYylORilg_003D_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzG78STymyQKJs;

	public _0023_003DzWYVDiPDDdqCOdbE8ZRLPlm9ugk0JPLxvkGT6mPc_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		_0023_003DzG78STymyQKJs = _0023_003Dz_Pbwmxzwl0tt;
	}

	public int _0023_003DzwR5yzjDgavw_0024(_0023_003DzWYVDiPDDdqCOdbE8ZRLPlm9ugk0JPLxvkGT6mPc_003D _0023_003DzNDQ_E88_003D)
	{
		return 0;
	}

	public double _0023_003DzBQK4IXfNdgsl(_0023_003DzcQiRB3Mv_00246WF _0023_003DzDVubtvo_003D, _0023_003DzcQiRB3Mv_00246WF _0023_003DzFj_0024IqDQ_003D)
	{
		_0023_003DzcQiRB3Mv_00246WF obj = _0023_003DzcQiRB3Mv_00246WF._0023_003DzUvTix_0024okzODR(_0023_003DzFj_0024IqDQ_003D, _0023_003DzDVubtvo_003D);
		return _0023_003DzcQiRB3Mv_00246WF._0023_003DzHX2sd2E_003D(obj, obj);
	}

	public int Compare(_0023_003Dz9EaLsos56zhlqklwSdaMHsBa9NYylORilg_003D_003D _0023_003DzBJFJHwk_003D, _0023_003Dz9EaLsos56zhlqklwSdaMHsBa9NYylORilg_003D_003D _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D._0023_003DzzBupebA_003D != _0023_003Dz40R7bAU_003D._0023_003DzzBupebA_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003DzzBupebA_003D < _0023_003Dz40R7bAU_003D._0023_003DzzBupebA_003D)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003DzzBupebA_003D > _0023_003Dz40R7bAU_003D._0023_003DzzBupebA_003D)
			{
				return 1;
			}
			return 0;
		}
		_0023_003DzcQiRB3Mv_00246WF _0023_003DzDVubtvo_003D = _0023_003DzG78STymyQKJs[(int)_0023_003DzBJFJHwk_003D._0023_003DzzBupebA_003D]._0023_003DzIIL2q6XkW9OP();
		double num = _0023_003DzBQK4IXfNdgsl(_0023_003DzDVubtvo_003D, _0023_003DzBJFJHwk_003D._0023_003DzrNyhm6g_003D);
		double num2 = _0023_003DzBQK4IXfNdgsl(_0023_003DzDVubtvo_003D, _0023_003Dz40R7bAU_003D._0023_003DzrNyhm6g_003D);
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}
}
