using System;

internal sealed class _0023_003Dzf6ky6Ed_W6_0024mG670oESJTJQ_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003DzNDN2q2o_003D, int _0023_003Dzgp68pOXI64by, int _0023_003DzSu3qtbY_003D, double _0023_003DzZ75z7WM_003D, double _0023_003Dzqe7o7AQ_003D, double _0023_003Dz2oCif7s_003D, double _0023_003DzjEHAzAA_003D, ref double[] _0023_003Dz61IPlm0_003D, int _0023_003DzldhEeJoZY0ht)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = -1 - _0023_003DzSu3qtbY_003D + _0023_003Dzgp68pOXI64by;
		int num5 = -1 + _0023_003DzldhEeJoZY0ht;
		if (_0023_003DzpGjKR04_003D == 2)
		{
			num3 = Math.Abs(_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003Dz2oCif7s_003D) + Math.Abs(_0023_003DzjEHAzAA_003D) + Math.Abs(_0023_003DzNDN2q2o_003D[2 + _0023_003DzSu3qtbY_003D + num4]);
			if (num3 == 0.0)
			{
				_0023_003Dz61IPlm0_003D[1 + num5] = 0.0;
				_0023_003Dz61IPlm0_003D[2 + num5] = 0.0;
			}
			else
			{
				num = _0023_003DzNDN2q2o_003D[2 + _0023_003DzSu3qtbY_003D + num4] / num3;
				_0023_003Dz61IPlm0_003D[1 + num5] = num * _0023_003DzNDN2q2o_003D[1 + 2 * _0023_003DzSu3qtbY_003D + num4] + (_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003DzZ75z7WM_003D) * ((_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003Dz2oCif7s_003D) / num3) - _0023_003Dzqe7o7AQ_003D * (_0023_003DzjEHAzAA_003D / num3);
				_0023_003Dz61IPlm0_003D[2 + num5] = num * (_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] + _0023_003DzNDN2q2o_003D[2 + 2 * _0023_003DzSu3qtbY_003D + num4] - _0023_003DzZ75z7WM_003D - _0023_003Dz2oCif7s_003D);
			}
			return;
		}
		num3 = Math.Abs(_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003Dz2oCif7s_003D) + Math.Abs(_0023_003DzjEHAzAA_003D) + Math.Abs(_0023_003DzNDN2q2o_003D[2 + _0023_003DzSu3qtbY_003D + num4]) + Math.Abs(_0023_003DzNDN2q2o_003D[3 + _0023_003DzSu3qtbY_003D + num4]);
		if (num3 == 0.0)
		{
			_0023_003Dz61IPlm0_003D[1 + num5] = 0.0;
			_0023_003Dz61IPlm0_003D[2 + num5] = 0.0;
			_0023_003Dz61IPlm0_003D[3 + num5] = 0.0;
		}
		else
		{
			num = _0023_003DzNDN2q2o_003D[2 + _0023_003DzSu3qtbY_003D + num4] / num3;
			num2 = _0023_003DzNDN2q2o_003D[3 + _0023_003DzSu3qtbY_003D + num4] / num3;
			_0023_003Dz61IPlm0_003D[1 + num5] = (_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003DzZ75z7WM_003D) * ((_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] - _0023_003Dz2oCif7s_003D) / num3) - _0023_003Dzqe7o7AQ_003D * (_0023_003DzjEHAzAA_003D / num3) + _0023_003DzNDN2q2o_003D[1 + 2 * _0023_003DzSu3qtbY_003D + num4] * num + _0023_003DzNDN2q2o_003D[1 + 3 * _0023_003DzSu3qtbY_003D + num4] * num2;
			_0023_003Dz61IPlm0_003D[2 + num5] = num * (_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] + _0023_003DzNDN2q2o_003D[2 + 2 * _0023_003DzSu3qtbY_003D + num4] - _0023_003DzZ75z7WM_003D - _0023_003Dz2oCif7s_003D) + _0023_003DzNDN2q2o_003D[2 + 3 * _0023_003DzSu3qtbY_003D + num4] * num2;
			_0023_003Dz61IPlm0_003D[3 + num5] = num2 * (_0023_003DzNDN2q2o_003D[1 + _0023_003DzSu3qtbY_003D + num4] + _0023_003DzNDN2q2o_003D[3 + 3 * _0023_003DzSu3qtbY_003D + num4] - _0023_003DzZ75z7WM_003D - _0023_003Dz2oCif7s_003D) + num * _0023_003DzNDN2q2o_003D[3 + 2 * _0023_003DzSu3qtbY_003D + num4];
		}
	}
}
