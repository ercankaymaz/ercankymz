using System;
using System.Text;

internal sealed class _0023_003DzA3Z1dYVi2EXQAqU5KlA_FRQ_003D
{
	private _0023_003DzRCSzLwxOTjNO _0023_003Dz7gw3N9c_003D;

	private ulong _0023_003DzBem4dCnPu2Yd;

	private ulong _0023_003Dzo9_0024wIkLM6_f4;

	private ulong _0023_003DzQOy1WtIfflQe;

	public _0023_003DzA3Z1dYVi2EXQAqU5KlA_FRQ_003D(_0023_003DzRCSzLwxOTjNO _0023_003Dz7gw3N9c_003D, ulong _0023_003Dz5iYe6uc_003D, ulong _0023_003DzUpea2ha7lyGP)
	{
		this._0023_003Dz7gw3N9c_003D = _0023_003Dz7gw3N9c_003D;
		_0023_003DzBem4dCnPu2Yd = _0023_003Dz5iYe6uc_003D;
		_0023_003DzQOy1WtIfflQe = _0023_003Dz5iYe6uc_003D;
		_0023_003Dzo9_0024wIkLM6_f4 = _0023_003DzUpea2ha7lyGP;
	}

	public string _0023_003DzaZ5ER5LKHj3n()
	{
		byte[] _0023_003Dz7ONt2yugdcPX = new byte[49152];
		long num = _0023_003Dzx_sdUG0Jm7Dk(ref _0023_003Dz7ONt2yugdcPX, 49152L);
		int num2 = _0023_003Dz7ONt2yugdcPX.Length;
		while (num != 0L)
		{
			byte[] _0023_003Dz7ONt2yugdcPX2 = new byte[49152];
			long num3 = _0023_003Dzx_sdUG0Jm7Dk(ref _0023_003Dz7ONt2yugdcPX2, num);
			Array.Resize(ref _0023_003Dz7ONt2yugdcPX, num2 + (int)num3);
			Array.Copy(_0023_003Dz7ONt2yugdcPX2, 0, _0023_003Dz7ONt2yugdcPX, num2, (int)num3);
			num2 += (int)num3;
			num = num3;
		}
		return Encoding.UTF8.GetString(_0023_003Dz7ONt2yugdcPX, 0, num2);
	}

	private long _0023_003Dzx_sdUG0Jm7Dk(ref byte[] _0023_003Dz7ONt2yugdcPX, long _0023_003DzoDUu9A596UC_0024)
	{
		if (_0023_003DzQOy1WtIfflQe > _0023_003DzBem4dCnPu2Yd + _0023_003Dzo9_0024wIkLM6_f4)
		{
			return 0L;
		}
		long num = (long)(_0023_003DzBem4dCnPu2Yd + _0023_003Dzo9_0024wIkLM6_f4 - _0023_003DzQOy1WtIfflQe);
		if (num <= 0)
		{
			return 0L;
		}
		long num2 = 0L;
		num2 = num;
		long num3 = Math.Min(_0023_003DzoDUu9A596UC_0024, num2);
		_0023_003Dz7gw3N9c_003D._0023_003DzT51EUwQ_003D(_0023_003DzQOy1WtIfflQe, (_0023_003DzRCSzLwxOTjNO._0023_003DzIaMpQArClRxi)0);
		_0023_003Dz7gw3N9c_003D._0023_003DzuuY9lIM_003D(ref _0023_003Dz7ONt2yugdcPX, num3, 0L);
		_0023_003DzQOy1WtIfflQe += (ulong)num3;
		return num3;
	}
}
