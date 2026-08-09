using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003Dz_Mmvp7fuyyRjmLR7WNpqQ_0024EB0UIq7utZG_0024uJuRdE0XplhraWYg_003D_003D : _0023_003DzA4VSB_BJWjRqoVnNLXRJWAM_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Setup _0023_003DzXBmvcLs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Geometry3D _0023_003DzDrKwE3hZ6YHg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dzh7tR_QM_003D;

	public void _0023_003Dz12p2jmUTCnCB(Setup _0023_003Dz9cS3uG0_003D, Geometry3D _0023_003Dz0y8dHgRbs7n3, _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_Bn_pNI_003D)
	{
		_0023_003DzXBmvcLs_003D = _0023_003Dz9cS3uG0_003D;
		_0023_003DzDrKwE3hZ6YHg = _0023_003Dz0y8dHgRbs7n3;
		_0023_003Dzh7tR_QM_003D = _0023_003Dz_Bn_pNI_003D;
	}

	public override void _0023_003Dzc_0024pb7t4_003D()
	{
		foreach (_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D item in _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D)
		{
			_0023_003DzxrkbfhlDvuRAo6Isuw_003D_003D(_0023_003DzXBmvcLs_003D, item, null);
		}
	}

	private void _0023_003DzxrkbfhlDvuRAo6Isuw_003D_003D(Setup _0023_003Dz9cS3uG0_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003Dzrli3h4E_003D, List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D)
	{
		double num = _0023_003DzzhSDYPa50tjn._0023_003DzIkPRXYA_003D() - 1E-12;
		Interval a = new Interval(_0023_003Dzrli3h4E_003D._0023_003DzBJFJHwk_003D - num, _0023_003Dzrli3h4E_003D._0023_003DzBJFJHwk_003D + num);
		Interval a2 = new Interval(_0023_003Dzrli3h4E_003D._0023_003Dz40R7bAU_003D - num, _0023_003Dzrli3h4E_003D._0023_003Dz40R7bAU_003D + num);
		_0023_003DzBhBGHtMU6jbT _0023_003DzAdkfXSo_003D = new _0023_003DzBhBGHtMU6jbT
		{
			_0023_003DzgxEO_Ds_003D = a.Low,
			_0023_003DzueQi_IQ_003D = a.High,
			_0023_003DzPkYBqKE_003D = a2.Low,
			_0023_003DzKnTEIEE_003D = a2.High
		};
		if (_0023_003Dzh7tR_QM_003D != null)
		{
			Interval b = new Interval(_0023_003Dzh7tR_QM_003D._0023_003Dz2bkFrf_00246WSWM._0023_003DzBJFJHwk_003D, _0023_003Dzh7tR_QM_003D._0023_003DzsVJSw85carf0._0023_003DzBJFJHwk_003D);
			Interval b2 = new Interval(_0023_003Dzh7tR_QM_003D._0023_003Dz2bkFrf_00246WSWM._0023_003Dz40R7bAU_003D, _0023_003Dzh7tR_QM_003D._0023_003DzsVJSw85carf0._0023_003Dz40R7bAU_003D);
			Interval interval = Interval.Intersection(a, b);
			Interval interval2 = Interval.Intersection(a2, b2);
			_0023_003DzAdkfXSo_003D = new _0023_003DzBhBGHtMU6jbT
			{
				_0023_003DzgxEO_Ds_003D = interval.Low,
				_0023_003DzueQi_IQ_003D = interval.High,
				_0023_003DzPkYBqKE_003D = interval2.Low,
				_0023_003DzKnTEIEE_003D = interval2.High
			};
		}
		IEnumerable<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> enumerable = _0023_003DzDrKwE3hZ6YHg._0023_003Dzqjt65kap4ZyB(_0023_003Dz9cS3uG0_003D, _0023_003DzAdkfXSo_003D);
		Point3D[] vertices = _0023_003DzDrKwE3hZ6YHg.GetVertices(_0023_003Dz9cS3uG0_003D);
		foreach (_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D item in enumerable)
		{
			if (_0023_003Dzrli3h4E_003D._0023_003Dz_JojPRlCDQpL(item._0023_003DzEzv5_0024vo_003D))
			{
				if (_0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D != null && !_0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D.Contains(item))
				{
					_0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D.Add(item);
				}
				_0023_003DzzhSDYPa50tjn._0023_003DzAuzAB79Pwj5S4SKNzQ_003D_003D(_0023_003Dzrli3h4E_003D, item._0023_003DzEzv5_0024vo_003D, vertices);
			}
		}
	}
}
