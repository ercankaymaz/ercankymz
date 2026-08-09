using System;
using System.Text;

internal sealed class _0023_003DzN24h2c_6LfH2a5wAN2jSyjk_003D(uint _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003Dzx5fE0Zn26f8WRpa4yw_003D_003D _0023_003DzHFWw_0024Winsv58, ulong _0023_003DzoLNS3E1Pxgua) : _0023_003Dz7EU3jafgrAIj0FjRJ8wRX1Q_003D(_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003DzHFWw_0024Winsv58, 2u, _0023_003DzoLNS3E1Pxgua)
{
	protected bool _0023_003DzME60cCnxXIXE;

	protected int _0023_003Dz_yMTmEgfVuaD = 1;

	protected byte[] _0023_003DzlXr_BL4NDfki = new byte[8];

	protected int _0023_003DzvCNjd6gQks_B;

	protected ulong _0023_003DzSTeGJfMWQEuB;

	protected string _0023_003DzKekPLiGH_Cv8;

	protected ulong _0023_003DzU0nrhTTeA8C7;

	public override ulong _0023_003DzlR6_0024bFKxIO9L(byte[] _0023_003DzK42AOhaAnl4C, ulong _0023_003DzNYxlP17PRu00, ulong _0023_003Dzv1TeLYMxx2me)
	{
		ulong num = _0023_003Dzv1TeLYMxx2me - _0023_003DzNYxlP17PRu00 >> 3;
		ulong num2 = 0uL;
		while (_0023_003Dz2F1zp4WtKF3x < _0023_003DziZiYS_Z2g6V4 && num2 < num)
		{
			int num3 = 0;
			if (_0023_003DzME60cCnxXIXE)
			{
				for (; num2 < num; num2++)
				{
					if (_0023_003DzvCNjd6gQks_B != 0 && _0023_003DzvCNjd6gQks_B >= _0023_003Dz_yMTmEgfVuaD)
					{
						break;
					}
					int num4 = 0;
					if (_0023_003DzvCNjd6gQks_B == 0)
					{
						if ((_0023_003DzK42AOhaAnl4C[0] & 1) != 0)
						{
							_0023_003Dz_yMTmEgfVuaD = 8;
						}
						else
						{
							_0023_003Dz_yMTmEgfVuaD = 1;
						}
					}
					_0023_003DzlXr_BL4NDfki[_0023_003DzvCNjd6gQks_B] = _0023_003DzK42AOhaAnl4C[num4];
					num4++;
					_0023_003DzvCNjd6gQks_B++;
				}
				if (_0023_003DzvCNjd6gQks_B > 0 && _0023_003DzvCNjd6gQks_B == _0023_003Dz_yMTmEgfVuaD)
				{
					if (_0023_003Dz_yMTmEgfVuaD == 1)
					{
						_0023_003DzSTeGJfMWQEuB = (ulong)(_0023_003DzlXr_BL4NDfki[0] >> 1);
					}
					else
					{
						_0023_003DzSTeGJfMWQEuB = ((ulong)_0023_003DzlXr_BL4NDfki[0] >> 1) + ((ulong)_0023_003DzlXr_BL4NDfki[1] << 7) + ((ulong)_0023_003DzlXr_BL4NDfki[2] << 15) + ((ulong)_0023_003DzlXr_BL4NDfki[3] << 23) + ((ulong)_0023_003DzlXr_BL4NDfki[4] << 31) + ((ulong)_0023_003DzlXr_BL4NDfki[5] << 39) + ((ulong)_0023_003DzlXr_BL4NDfki[6] << 47) + ((ulong)_0023_003DzlXr_BL4NDfki[7] << 55);
					}
					_0023_003DzME60cCnxXIXE = false;
					_0023_003Dz_yMTmEgfVuaD = 1;
					Array.Clear(_0023_003DzlXr_BL4NDfki, 0, _0023_003DzlXr_BL4NDfki.Length);
					_0023_003DzvCNjd6gQks_B = 0;
					_0023_003DzKekPLiGH_Cv8 = string.Empty;
					_0023_003DzU0nrhTTeA8C7 = 0uL;
				}
			}
			if (!_0023_003DzME60cCnxXIXE)
			{
				ulong num5 = _0023_003DzSTeGJfMWQEuB - _0023_003DzU0nrhTTeA8C7;
				ulong num6 = num - num2;
				if (num5 < num6)
				{
					num6 = num5;
				}
				_0023_003DzKekPLiGH_Cv8 += Encoding.UTF8.GetString(_0023_003DzK42AOhaAnl4C, num3, (int)num6);
				num3 += (int)num6;
				num2 += num6;
				_0023_003DzU0nrhTTeA8C7 += num6;
				if (_0023_003DzU0nrhTTeA8C7 == _0023_003DzSTeGJfMWQEuB)
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003DzG_0024XFWIs_003D(_0023_003DzKekPLiGH_Cv8);
					_0023_003Dz2F1zp4WtKF3x++;
					_0023_003DzME60cCnxXIXE = true;
					_0023_003Dz_yMTmEgfVuaD = 1;
					Array.Clear(_0023_003DzlXr_BL4NDfki, 0, _0023_003DzlXr_BL4NDfki.Length);
					_0023_003DzvCNjd6gQks_B = 0;
					_0023_003DzSTeGJfMWQEuB = 0uL;
					_0023_003DzKekPLiGH_Cv8 = string.Empty;
					_0023_003DzU0nrhTTeA8C7 = 0uL;
				}
			}
		}
		return num2 * 8;
	}
}
