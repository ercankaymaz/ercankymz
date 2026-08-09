using System.Diagnostics;

internal struct _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public long _0023_003Dzyk2fsPo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public long _0023_003DzvXOLtKg_003D;

	public _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(long _0023_003Dzyk2fsPo_003D, long _0023_003DzvXOLtKg_003D)
	{
		this._0023_003Dzyk2fsPo_003D = _0023_003Dzyk2fsPo_003D;
		this._0023_003DzvXOLtKg_003D = _0023_003DzvXOLtKg_003D;
	}

	public _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		_0023_003Dzyk2fsPo_003D = (long)_0023_003DzBJFJHwk_003D;
		_0023_003DzvXOLtKg_003D = (long)_0023_003Dz40R7bAU_003D;
	}

	public _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzMlCq3wk_003D)
	{
		_0023_003Dzyk2fsPo_003D = _0023_003DzMlCq3wk_003D._0023_003Dzyk2fsPo_003D;
		_0023_003DzvXOLtKg_003D = _0023_003DzMlCq3wk_003D._0023_003DzvXOLtKg_003D;
	}

	public static bool operator ==(_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzjbqS1qE_003D, _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D == _0023_003Dz1v6oPQk_003D._0023_003Dzyk2fsPo_003D)
		{
			return _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D == _0023_003Dz1v6oPQk_003D._0023_003DzvXOLtKg_003D;
		}
		return false;
	}

	public static bool operator !=(_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzjbqS1qE_003D, _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D == _0023_003Dz1v6oPQk_003D._0023_003Dzyk2fsPo_003D)
		{
			return _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D != _0023_003Dz1v6oPQk_003D._0023_003DzvXOLtKg_003D;
		}
		return true;
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null)
		{
			return false;
		}
		if (_0023_003DzCX9Hbao_003D is _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2)
		{
			if (_0023_003Dzyk2fsPo_003D == _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D)
			{
				return _0023_003DzvXOLtKg_003D == _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
