using System;
using devDept.Geometry;

internal class _0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov
{
	public static bool _0023_003DznQ_0024Lpt8_0024jA_TU82zSQ_003D_003D(Point4D[] _0023_003DzFduYrbQ_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		if (_0023_003DzFduYrbQ_003D.Length == 2)
		{
			return true;
		}
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzFduYrbQ_003D[0]._0023_003Dz53cmpTHe6Yih();
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzQ9zpGF0_003D = _0023_003DzFduYrbQ_003D[^1]._0023_003Dz53cmpTHe6Yih() - _0023_003Dz1v6oPQk_003D;
		if (_0023_003DzQ9zpGF0_003D._0023_003DzbV1eOjg_003D() < 1E-09)
		{
			double num = 1E-18;
			for (int i = 1; i < _0023_003DzFduYrbQ_003D.Length - 1; i++)
			{
				if ((_0023_003DzFduYrbQ_003D[i]._0023_003Dz53cmpTHe6Yih() - _0023_003Dz1v6oPQk_003D)._0023_003DzEi_F9g8kJ9d2() > num)
				{
					return false;
				}
			}
			return true;
		}
		if (_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D > 0.0 && !_0023_003Dzf5TqJXrD_0024tP8(_0023_003DzFduYrbQ_003D, _0023_003DzQ9zpGF0_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D))
		{
			return false;
		}
		if (_0023_003Dz0mZ4_0024fFWxsTX > 0.0 && !_0023_003DzBiCglBef_0024tCL(_0023_003DzFduYrbQ_003D, _0023_003Dz0mZ4_0024fFWxsTX))
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003Dzf5TqJXrD_0024tP8(Point4D[] _0023_003DzFduYrbQ_003D, _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzQ9zpGF0_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		double num = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D * _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzFduYrbQ_003D[0]._0023_003Dz53cmpTHe6Yih();
		for (int i = 1; i < _0023_003DzFduYrbQ_003D.Length - 1; i++)
		{
			if ((_0023_003DzQ9zpGF0_003D ^ (_0023_003DzFduYrbQ_003D[i]._0023_003Dz53cmpTHe6Yih() - _0023_003Dz1v6oPQk_003D))._0023_003DzEi_F9g8kJ9d2() > num)
			{
				return false;
			}
		}
		return true;
	}

	private static bool _0023_003DzBiCglBef_0024tCL(Point4D[] _0023_003DzFduYrbQ_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		double num = Math.Cos(_0023_003Dz0mZ4_0024fFWxsTX + 1E-12);
		double num2 = Math.Sqrt(1.0 - num * num);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzyWVxcUWfUOBv = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzzzGF1TpipLsn = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D = _0023_003DzFduYrbQ_003D[0]._0023_003Dz53cmpTHe6Yih();
		double num3 = 1.0;
		double num4 = 0.0;
		int _0023_003Dz437_00244ak_003D = 0;
		bool flag = true;
		while (_0023_003DzAjVUKeRcDK1W(_0023_003DzFduYrbQ_003D, ref _0023_003Dz437_00244ak_003D, in _0023_003DzlY77YgY_003D, ref _0023_003DzzzGF1TpipLsn, ref _0023_003DzyWVxcUWfUOBv))
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				double num5 = Utility.Clamp(_0023_003DzzzGF1TpipLsn * _0023_003Dz1v6oPQk_003D, -1.0, 1.0);
				double num6 = Math.Sqrt(1.0 - num5 * num5);
				if (num5 < num || num5 < num * num3 + num2 * num4)
				{
					return false;
				}
				double num7 = num3 * num5 - num4 * num6;
				num4 = num4 * num5 + num3 * num6;
				num3 = num7;
			}
			_0023_003Dz1v6oPQk_003D = _0023_003DzzzGF1TpipLsn;
			_0023_003DzlY77YgY_003D = _0023_003DzyWVxcUWfUOBv;
		}
		return true;
	}

	internal static bool _0023_003DzAjVUKeRcDK1W(Point4D[] _0023_003DzFduYrbQ_003D, ref int _0023_003Dz437_00244ak_003D, in _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzzzGF1TpipLsn, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzyWVxcUWfUOBv)
	{
		for (double num = 0.0; num <= 1E-09; num = _0023_003DzzzGF1TpipLsn._0023_003DzbV1eOjg_003D())
		{
			if (_0023_003Dz437_00244ak_003D >= _0023_003DzFduYrbQ_003D.Length - 1)
			{
				return false;
			}
			_0023_003DzyWVxcUWfUOBv = _0023_003DzFduYrbQ_003D[++_0023_003Dz437_00244ak_003D]._0023_003Dz53cmpTHe6Yih();
			_0023_003DzzzGF1TpipLsn = _0023_003DzyWVxcUWfUOBv - _0023_003DzlY77YgY_003D;
		}
		return true;
	}

	internal static bool _0023_003Dz_0024R8AOQijyV6b(Point4D[] _0023_003DzFduYrbQ_003D, ref int _0023_003Dz437_00244ak_003D, in _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzL7LPA5z5RiLy, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzWSiCdJ3aS_0024OH)
	{
		for (double num = 0.0; num <= 1E-09; num = _0023_003DzL7LPA5z5RiLy._0023_003DzbV1eOjg_003D())
		{
			if (_0023_003Dz437_00244ak_003D < 1)
			{
				return false;
			}
			_0023_003DzWSiCdJ3aS_0024OH = _0023_003DzFduYrbQ_003D[--_0023_003Dz437_00244ak_003D]._0023_003Dz53cmpTHe6Yih();
			_0023_003DzL7LPA5z5RiLy = _0023_003DzlY77YgY_003D - _0023_003DzWSiCdJ3aS_0024OH;
		}
		return true;
	}

	public static bool _0023_003DznQ_0024Lpt8_0024jA_TU82zSQ_003D_003D(Point4D[,] _0023_003DzFduYrbQ_003D, int _0023_003DzyzK8swU_003D, bool _0023_003DzCJkr8nY_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		int num = _0023_003DzlLB8YgQ_003D(_0023_003DzCJkr8nY_003D, _0023_003DzFduYrbQ_003D);
		if (num == 2)
		{
			return true;
		}
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzJLfdvPw_003D(0, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzQ9zpGF0_003D = _0023_003DzJLfdvPw_003D(num - 1, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D) - _0023_003Dz1v6oPQk_003D;
		if (_0023_003DzQ9zpGF0_003D._0023_003DzbV1eOjg_003D() < 1E-09)
		{
			double num2 = 1E-18;
			for (int i = 1; i < num - 1; i++)
			{
				if ((_0023_003DzJLfdvPw_003D(i, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D) - _0023_003Dz1v6oPQk_003D)._0023_003DzEi_F9g8kJ9d2() > num2)
				{
					return false;
				}
			}
			return true;
		}
		if (_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D > 0.0 && !_0023_003Dzf5TqJXrD_0024tP8(_0023_003DzFduYrbQ_003D, _0023_003DzQ9zpGF0_003D, _0023_003DzyzK8swU_003D, _0023_003DzCJkr8nY_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D))
		{
			return false;
		}
		if (_0023_003Dz0mZ4_0024fFWxsTX > 0.0 && !_0023_003DzBiCglBef_0024tCL(_0023_003DzFduYrbQ_003D, _0023_003DzyzK8swU_003D, _0023_003DzCJkr8nY_003D, _0023_003Dz0mZ4_0024fFWxsTX))
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003Dzf5TqJXrD_0024tP8(Point4D[,] _0023_003DzFduYrbQ_003D, _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzQ9zpGF0_003D, int _0023_003DzyzK8swU_003D, bool _0023_003DzCJkr8nY_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		double num = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D * _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzJLfdvPw_003D(0, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D);
		int num2 = _0023_003DzlLB8YgQ_003D(_0023_003DzCJkr8nY_003D, _0023_003DzFduYrbQ_003D);
		for (int i = 1; i < num2 - 1; i++)
		{
			if ((_0023_003DzQ9zpGF0_003D ^ (_0023_003DzJLfdvPw_003D(i, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D) - _0023_003Dz1v6oPQk_003D))._0023_003DzEi_F9g8kJ9d2() > num)
			{
				return false;
			}
		}
		return true;
	}

	private static bool _0023_003DzBiCglBef_0024tCL(Point4D[,] _0023_003DzFduYrbQ_003D, int _0023_003DzyzK8swU_003D, bool _0023_003DzCJkr8nY_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		double num = Math.Cos(_0023_003Dz0mZ4_0024fFWxsTX + 1E-12);
		double num2 = Math.Sqrt(1.0 - num * num);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzyWVxcUWfUOBv = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzzzGF1TpipLsn = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D = _0023_003DzJLfdvPw_003D(0, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D);
		double num3 = 1.0;
		double num4 = 0.0;
		int _0023_003Dz736ekIs_003D = _0023_003DzlLB8YgQ_003D(_0023_003DzCJkr8nY_003D, _0023_003DzFduYrbQ_003D);
		int _0023_003Dz437_00244ak_003D = 0;
		bool flag = true;
		while (_0023_003DzAjVUKeRcDK1W(_0023_003DzFduYrbQ_003D, _0023_003DzCJkr8nY_003D, _0023_003Dz736ekIs_003D, _0023_003DzyzK8swU_003D, ref _0023_003Dz437_00244ak_003D, in _0023_003DzlY77YgY_003D, ref _0023_003DzzzGF1TpipLsn, ref _0023_003DzyWVxcUWfUOBv))
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				double num5 = Utility.Clamp(_0023_003DzzzGF1TpipLsn * _0023_003Dz1v6oPQk_003D, -1.0, 1.0);
				double num6 = Math.Sqrt(1.0 - num5 * num5);
				if (num5 < num || num5 < num * num3 + num2 * num4)
				{
					return false;
				}
				double num7 = num3 * num5 - num4 * num6;
				num4 = num4 * num5 + num3 * num6;
				num3 = num7;
			}
			_0023_003Dz1v6oPQk_003D = _0023_003DzzzGF1TpipLsn;
			_0023_003DzlY77YgY_003D = _0023_003DzyWVxcUWfUOBv;
		}
		return true;
	}

	private static bool _0023_003DzAjVUKeRcDK1W(Point4D[,] _0023_003DzFduYrbQ_003D, bool _0023_003DzCJkr8nY_003D, int _0023_003Dz736ekIs_003D, int _0023_003DzyzK8swU_003D, ref int _0023_003Dz437_00244ak_003D, in _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzzzGF1TpipLsn, ref _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzyWVxcUWfUOBv)
	{
		for (double num = 0.0; num <= 1E-09; num = _0023_003DzzzGF1TpipLsn._0023_003DzbV1eOjg_003D())
		{
			if (_0023_003Dz437_00244ak_003D >= _0023_003Dz736ekIs_003D - 1)
			{
				return false;
			}
			_0023_003DzyWVxcUWfUOBv = _0023_003DzJLfdvPw_003D(++_0023_003Dz437_00244ak_003D, _0023_003DzCJkr8nY_003D, _0023_003DzyzK8swU_003D, _0023_003DzFduYrbQ_003D);
			_0023_003DzzzGF1TpipLsn = _0023_003DzyWVxcUWfUOBv - _0023_003DzlY77YgY_003D;
		}
		return true;
	}

	private static _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzJLfdvPw_003D(int _0023_003Dz437_00244ak_003D, bool _0023_003DzCJkr8nY_003D, int _0023_003DzbkJlOE9ppBah, Point4D[,] _0023_003DzFduYrbQ_003D)
	{
		return (_0023_003DzCJkr8nY_003D ? _0023_003DzFduYrbQ_003D[_0023_003Dz437_00244ak_003D, _0023_003DzbkJlOE9ppBah] : _0023_003DzFduYrbQ_003D[_0023_003DzbkJlOE9ppBah, _0023_003Dz437_00244ak_003D])._0023_003Dz53cmpTHe6Yih();
	}

	private static int _0023_003DzlLB8YgQ_003D(bool _0023_003DzCJkr8nY_003D, Point4D[,] _0023_003DzFduYrbQ_003D)
	{
		if (!_0023_003DzCJkr8nY_003D)
		{
			return _0023_003DzFduYrbQ_003D.GetLength(1);
		}
		return _0023_003DzFduYrbQ_003D.GetLength(0);
	}
}
