using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzbM5iIPhXT9mletY6xA_003D_003D : IComparer<_0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcQiRB3Mv_00246WF _0023_003DzwxCQeqZKf5y5;

	public _0023_003DzbM5iIPhXT9mletY6xA_003D_003D(_0023_003DzcQiRB3Mv_00246WF _0023_003DzCREyuzFnGFhJ)
	{
		_0023_003DzwxCQeqZKf5y5 = _0023_003DzCREyuzFnGFhJ;
	}

	public int _0023_003DzwR5yzjDgavw_0024(_0023_003DzbM5iIPhXT9mletY6xA_003D_003D _0023_003DzNDQ_E88_003D)
	{
		return 0;
	}

	public double _0023_003DzBQK4IXfNdgsl(_0023_003DzcQiRB3Mv_00246WF _0023_003DzDVubtvo_003D, _0023_003DzcQiRB3Mv_00246WF _0023_003DzFj_0024IqDQ_003D)
	{
		_0023_003DzcQiRB3Mv_00246WF obj = _0023_003DzcQiRB3Mv_00246WF._0023_003DzUvTix_0024okzODR(_0023_003DzFj_0024IqDQ_003D, _0023_003DzDVubtvo_003D);
		return _0023_003DzcQiRB3Mv_00246WF._0023_003DzHX2sd2E_003D(obj, obj);
	}

	public int Compare(_0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D _0023_003DzBJFJHwk_003D, _0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D _0023_003Dz40R7bAU_003D)
	{
		double num = _0023_003DzBQK4IXfNdgsl(_0023_003DzBJFJHwk_003D._0023_003DzpdeSbFA_003D, _0023_003DzwxCQeqZKf5y5);
		double num2 = _0023_003DzBQK4IXfNdgsl(_0023_003Dz40R7bAU_003D._0023_003DzpdeSbFA_003D, _0023_003DzwxCQeqZKf5y5);
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
