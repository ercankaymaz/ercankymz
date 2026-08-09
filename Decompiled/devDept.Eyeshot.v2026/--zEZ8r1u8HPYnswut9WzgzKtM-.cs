using System.Collections.Generic;
using System.Diagnostics;

internal class _0023_003DzEZ8r1u8HPYnswut9WzgzKtM_003D : _0023_003DzsbeHAAjCqCPR
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected _0023_003Dz3ORRwnUaVbd8 _0023_003Dzsuiz4uo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected double _0023_003DzALgPimU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[] _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D;

	public _0023_003DzEZ8r1u8HPYnswut9WzgzKtM_003D()
	{
		_0023_003DzzhSDYPa50tjn = null;
		_0023_003Dz_0024KKopL9T7nzT = null;
		_0023_003Dzsuiz4uo_003D = null;
		_0023_003DzALgPimU_003D = 0.0;
		_0023_003DzqBfSlyfgN_zy.Clear();
		_0023_003DzqBfSlyfgN_zy.Add(new _0023_003DzA4VSB_BJWjRqoVnNLXRJWAM_003D());
		_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D = 0.1;
	}

	public override void Dispose()
	{
		_0023_003DzqBfSlyfgN_zy.Clear();
		base.Dispose();
	}

	public void _0023_003Dz3gkATJs_003D(_0023_003Dz3ORRwnUaVbd8 _0023_003DzB68dg9Q_003D)
	{
		_0023_003Dzsuiz4uo_003D = _0023_003DzB68dg9Q_003D;
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DzjMxCQzALYgSK();
	}

	public void _0023_003DzMFlIwko_003D(double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzALgPimU_003D = _0023_003DzId5C3LA_003D;
	}

	public double _0023_003DzIRgdVG0_003D()
	{
		return _0023_003DzALgPimU_003D;
	}

	public List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[] _0023_003DzZ_0024UxBO0_003D()
	{
		List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[] array = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Length];
		for (int i = 0; i < _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Length; i++)
		{
			array[i] = _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D[i];
		}
		return array;
	}

	public override void _0023_003Dzc_0024pb7t4_003D()
	{
		_0023_003DzrskxlNgbDTFVphxdceUHAhdaYA1i();
	}

	private void _0023_003DzrskxlNgbDTFVphxdceUHAhdaYA1i()
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[_0023_003Dzsuiz4uo_003D._0023_003DzQCpIBcjML_Au.Count];
		for (int i = 0; i < _0023_003Dzsuiz4uo_003D._0023_003DzQCpIBcjML_Au.Count; i++)
		{
			_0023_003Dzg1UaApmiTJ0G _0023_003DzgqZzIes_003D = _0023_003Dzsuiz4uo_003D._0023_003DzQCpIBcjML_Au[i];
			_0023_003Dz7eKPBkriWjLT(_0023_003DzgqZzIes_003D);
			_0023_003DzqBfSlyfgN_zy[0]._0023_003Dzc_0024pb7t4_003D();
			_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D[i] = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>(_0023_003DzqBfSlyfgN_zy[0]._0023_003DzbbwM8JeHW4GP());
			_0023_003DzqBfSlyfgN_zy[0]._0023_003DzjMxCQzALYgSK();
		}
	}

	private void _0023_003Dz7eKPBkriWjLT(_0023_003Dzg1UaApmiTJ0G _0023_003DzgqZzIes_003D)
	{
		uint num = (uint)(_0023_003DzgqZzIes_003D._0023_003DzKyPYkL4vdW1Z() / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D + 1.0);
		for (uint num2 = 0u; num2 <= num; num2++)
		{
			double _0023_003DzNDQ_E88_003D = (double)num2 / (double)num;
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = _0023_003DzgqZzIes_003D._0023_003DzOXmvu5c_003D(_0023_003DzNDQ_E88_003D);
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2 = new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D);
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzId5C3LA_003D = _0023_003DzALgPimU_003D;
			_0023_003DzqBfSlyfgN_zy[0]._0023_003Dzak_n3oJBpB71(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2);
		}
	}
}
