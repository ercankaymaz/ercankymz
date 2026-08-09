using System;
using System.IO;
using System.Text;

internal sealed class _0023_003DzRCSzLwxOTjNO
{
	public enum _0023_003Dz3nCm8N8_003D
	{

	}

	public enum _0023_003DzIaMpQArClRxi
	{

	}

	public string _0023_003DzN5mckSmx8lqo;

	private ulong _0023_003Dzo9_0024wIkLM6_f4;

	private ulong _0023_003Dzzd9_0024yonMltZJ;

	private int _0023_003DzIPkYOHaD0Sst = 100;

	public int _0023_003Dz1zGgNp4_003D = -1;

	private bool _0023_003Dz94JGf5I2MtcN;

	private _0023_003Dz_0024MxlXedqAKDi _0023_003DzdE8tMii_zMXm;

	public FileStream _0023_003DzWPFOr9I_003D;

	public _0023_003DzRCSzLwxOTjNO()
	{
	}

	public _0023_003DzRCSzLwxOTjNO(string _0023_003Dz_HZ81V0_003D, _0023_003Dz3nCm8N8_003D _0023_003DznXXM9vk_003D, int _0023_003DzcHyOvJw_003D)
	{
		_0023_003DzN5mckSmx8lqo = _0023_003Dz_HZ81V0_003D.Trim();
		_0023_003DzIPkYOHaD0Sst = _0023_003DzcHyOvJw_003D;
		if (_0023_003DznXXM9vk_003D == (_0023_003Dz3nCm8N8_003D)0)
		{
			_0023_003DzWPFOr9I_003D = new FileStream(_0023_003DzN5mckSmx8lqo, FileMode.Open, FileAccess.Read);
			_0023_003Dz1zGgNp4_003D = 3;
			_0023_003Dz94JGf5I2MtcN = true;
			if (_0023_003DzdE8tMii_zMXm == null && _0023_003DzWPFOr9I_003D != null)
			{
				_0023_003Dzzd9_0024yonMltZJ = (ulong)_0023_003DzWPFOr9I_003D.Seek(0L, SeekOrigin.End);
			}
			else
			{
				_0023_003Dzzd9_0024yonMltZJ = _0023_003DzeXy0xhJF13y4(0L, _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003DzGMXG5430qmd3);
			}
			_0023_003Dzo9_0024wIkLM6_f4 = _0023_003DzVz5VrVqTZjrL(_0023_003Dzzd9_0024yonMltZJ);
		}
	}

	private ulong _0023_003DzeXy0xhJF13y4(long _0023_003DzfBEBL_o_003D, int _0023_003Dz6grTDAjLWHGq)
	{
		if (_0023_003Dz1zGgNp4_003D < 0 && _0023_003DzdE8tMii_zMXm != null)
		{
			if (_0023_003DzdE8tMii_zMXm._0023_003DzT51EUwQ_003D((ulong)_0023_003DzfBEBL_o_003D, _0023_003Dz6grTDAjLWHGq))
			{
				return _0023_003DzdE8tMii_zMXm._0023_003DzpdeSbFA_003D();
			}
		}
		return 0uL;
	}

	public ulong _0023_003DztHjoe2jiYLP6(ulong _0023_003DzfWfUF1AbUw0J)
	{
		ulong num = _0023_003DzfWfUF1AbUw0J / 1020;
		ulong num2 = _0023_003DzfWfUF1AbUw0J - num * 1020;
		return num * 1024 + num2;
	}

	public ulong _0023_003DzVz5VrVqTZjrL(ulong _0023_003Dzm_0024xs_0024ee3NLPa)
	{
		ulong num = _0023_003Dzm_0024xs_0024ee3NLPa >> 10;
		ulong val = _0023_003Dzm_0024xs_0024ee3NLPa & 0x3FF;
		return num * 1020 + Math.Min(val, 1020uL);
	}

	public void _0023_003DzuuY9lIM_003D(ref _0023_003Dz96tvohaTMGJFgBYD4A_003D_003D _0023_003Dz8Vwa6Pc_003D, int _0023_003DzfjCaYvw_003D, int _0023_003DzfBEBL_o_003D)
	{
		ulong _0023_003DzfBEBL_o_003D2 = _0023_003DztUjb52A_003D((_0023_003DzIaMpQArClRxi)0) + (ulong)_0023_003DzfjCaYvw_003D;
		_0023_003Dz736ekIs_003D((_0023_003DzIaMpQArClRxi)0);
		ulong _0023_003DzI6pOOus_003D = 0uL;
		long _0023_003DzmzccG7u4pTgu = 0L;
		_0023_003Dz7A4qy1apwoGU(ref _0023_003DzI6pOOus_003D, ref _0023_003DzmzccG7u4pTgu, (_0023_003DzIaMpQArClRxi)0);
		long num = Math.Min(_0023_003DzfjCaYvw_003D, 1020 - _0023_003DzmzccG7u4pTgu);
		byte[] _0023_003Dzvo35by0HxqIC = new byte[1024];
		while (_0023_003DzfjCaYvw_003D > 0)
		{
			_0023_003Dz1wiUjU8F4u1r(ref _0023_003Dzvo35by0HxqIC, _0023_003DzI6pOOus_003D);
			_0023_003DzfjCaYvw_003D -= (int)num;
			_0023_003DzmzccG7u4pTgu = 0L;
			_0023_003DzI6pOOus_003D++;
			num = Math.Min(_0023_003DzfjCaYvw_003D, 1020);
		}
		_0023_003DzujSinAX1TfQq(ref _0023_003Dz8Vwa6Pc_003D, _0023_003DzWPFOr9I_003D, _0023_003DzfBEBL_o_003D);
		_0023_003DzT51EUwQ_003D(_0023_003DzfBEBL_o_003D2, (_0023_003DzIaMpQArClRxi)0, _0023_003DzWPFOr9I_003D);
	}

	public static uint _0023_003DzYoQgFvtOfyiP(uint _0023_003DzXULhp_00248_003D)
	{
		_0023_003DzXULhp_00248_003D = ((_0023_003DzXULhp_00248_003D << 8) & 0xFF00FF00u) | ((_0023_003DzXULhp_00248_003D >> 8) & 0xFF00FF);
		return (_0023_003DzXULhp_00248_003D << 16) | (_0023_003DzXULhp_00248_003D >> 16);
	}

	public static void _0023_003DzZMNwpELh2N_0024Q(byte[] _0023_003Dzvo35by0HxqIC, ulong _0023_003DzI6pOOus_003D)
	{
		uint _0023_003DzXULhp_00248_003D = new _0023_003DzZelPogVo28vS()._0023_003DzL9woobs_003D(0u, _0023_003Dzvo35by0HxqIC, 0, 1020);
		_0023_003DzXULhp_00248_003D = _0023_003DzYoQgFvtOfyiP(_0023_003DzXULhp_00248_003D);
		uint num = BitConverter.ToUInt32(_0023_003Dzvo35by0HxqIC, 1020);
		if (_0023_003DzXULhp_00248_003D != num)
		{
			throw new Exception(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742195), _0023_003DzXULhp_00248_003D, num, _0023_003DzI6pOOus_003D));
		}
	}

	public static uint _0023_003DzHCHDNiA_003D(byte[] _0023_003Dza9PrWnt6TkgA, int _0023_003Dz14lzA48_003D)
	{
		if (_0023_003Dza9PrWnt6TkgA == null || _0023_003Dz14lzA48_003D <= 0 || _0023_003Dz14lzA48_003D > _0023_003Dza9PrWnt6TkgA.Length)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742159));
		}
		return _0023_003DzJvn_uod6c0KB(new _0023_003DzZelPogVo28vS()._0023_003DzL9woobs_003D(0u, _0023_003Dza9PrWnt6TkgA, 0, 1020));
	}

	public static uint _0023_003DzJvn_uod6c0KB(uint _0023_003DzXULhp_00248_003D)
	{
		_0023_003DzXULhp_00248_003D = ((_0023_003DzXULhp_00248_003D << 8) & 0xFF00FF00u) | ((_0023_003DzXULhp_00248_003D >> 8) & 0xFF00FF);
		return (_0023_003DzXULhp_00248_003D << 16) | (_0023_003DzXULhp_00248_003D >> 16);
	}

	private void _0023_003DzujSinAX1TfQq(ref _0023_003Dz96tvohaTMGJFgBYD4A_003D_003D _0023_003Dz8Vwa6Pc_003D, FileStream _0023_003DzdLqTRfo_003D, int _0023_003DzWqXa4n244FUF)
	{
		using (_0023_003DzdLqTRfo_003D = new FileStream(_0023_003DzdLqTRfo_003D.Name, FileMode.Open, FileAccess.Read))
		{
			BinaryReader binaryReader = new BinaryReader(_0023_003DzdLqTRfo_003D);
			try
			{
				byte[] bytes = binaryReader.ReadBytes(8);
				_0023_003Dz8Vwa6Pc_003D._0023_003DzSeTR2cdZjCyF = Encoding.ASCII.GetChars(bytes);
				_0023_003Dz8Vwa6Pc_003D._0023_003DzqeEQW_0024E_003D = binaryReader.ReadUInt32();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzPTM7dmE_003D = binaryReader.ReadUInt32();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzgfCf0g2tA_00248x = binaryReader.ReadUInt64();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzJvSTylPP3ZC4 = binaryReader.ReadUInt64();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzJ0wj_MyDQIHi = binaryReader.ReadUInt64();
				_0023_003Dz8Vwa6Pc_003D._0023_003Dz_0024yfaUwU_003D = binaryReader.ReadUInt64();
				_0023_003DzdLqTRfo_003D.Close();
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
	}

	public void _0023_003Dz1wiUjU8F4u1r(ref byte[] _0023_003Dzvo35by0HxqIC, ulong _0023_003DzI6pOOus_003D)
	{
		if (_0023_003DzWPFOr9I_003D != null)
		{
			_0023_003DzT51EUwQ_003D(_0023_003DzI6pOOus_003D * 1024, (_0023_003DzIaMpQArClRxi)1);
			if (_0023_003Dz1zGgNp4_003D < 0 && _0023_003DzdE8tMii_zMXm != null)
			{
				_0023_003DzdE8tMii_zMXm._0023_003DzuuY9lIM_003D(_0023_003Dzvo35by0HxqIC, 1024uL);
			}
			else
			{
				_0023_003DzWPFOr9I_003D.Read(_0023_003Dzvo35by0HxqIC, 0, 1024);
			}
		}
	}

	public void _0023_003DzT51EUwQ_003D(ulong _0023_003DzfBEBL_o_003D, _0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U, FileStream _0023_003DzWPFOr9I_003D)
	{
		long _0023_003DzfBEBL_o_003D2 = (long)((_0023_003DzwDw4oqTZBK7U == (_0023_003DzIaMpQArClRxi)1) ? _0023_003DzfBEBL_o_003D : _0023_003DztHjoe2jiYLP6(_0023_003DzfBEBL_o_003D));
		_0023_003DzeXy0xhJF13y4(_0023_003DzfBEBL_o_003D2, _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003Dz5z31Zx6y55n8);
	}

	public void _0023_003Dz7A4qy1apwoGU(ref ulong _0023_003DzI6pOOus_003D, ref long _0023_003DzmzccG7u4pTgu, _0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U)
	{
		ulong num = _0023_003DztUjb52A_003D(_0023_003DzwDw4oqTZBK7U);
		if (_0023_003DzwDw4oqTZBK7U == (_0023_003DzIaMpQArClRxi)1)
		{
			_0023_003DzI6pOOus_003D = num >> 10;
			_0023_003DzmzccG7u4pTgu = (long)(num & 0x3FF);
		}
		else
		{
			_0023_003DzI6pOOus_003D = num / 1020;
			_0023_003DzmzccG7u4pTgu = (long)(num - _0023_003DzI6pOOus_003D * 1020);
		}
	}

	public ulong _0023_003Dz736ekIs_003D(_0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U)
	{
		if (_0023_003DzwDw4oqTZBK7U == (_0023_003DzIaMpQArClRxi)1)
		{
			if (_0023_003Dz94JGf5I2MtcN)
			{
				return _0023_003Dzzd9_0024yonMltZJ;
			}
			_0023_003DzWPFOr9I_003D.Seek(0L, SeekOrigin.Current);
			long result = _0023_003DzWPFOr9I_003D.Seek(0L, SeekOrigin.End);
			_0023_003DzWPFOr9I_003D.Seek(0L, SeekOrigin.Begin);
			return (ulong)result;
		}
		return _0023_003Dzo9_0024wIkLM6_f4;
	}

	private ulong _0023_003DztUjb52A_003D(_0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U)
	{
		ulong num = (ulong)_0023_003DzWPFOr9I_003D.Seek(0L, SeekOrigin.Current);
		if (_0023_003DzwDw4oqTZBK7U == (_0023_003DzIaMpQArClRxi)1)
		{
			return num;
		}
		return _0023_003DzVz5VrVqTZjrL(num);
	}

	public void _0023_003DzT51EUwQ_003D(ulong _0023_003DzfBEBL_o_003D, _0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U)
	{
		long offset = (long)((_0023_003DzwDw4oqTZBK7U == (_0023_003DzIaMpQArClRxi)1) ? _0023_003DzfBEBL_o_003D : _0023_003DztHjoe2jiYLP6(_0023_003DzfBEBL_o_003D));
		_0023_003DzWPFOr9I_003D.Seek(offset, SeekOrigin.Begin);
	}

	public void _0023_003DzuuY9lIM_003D(ref byte[] _0023_003DzDj6LpX0_003D, long _0023_003DzfjCaYvw_003D, long _0023_003DzFYX4Qmo_003D)
	{
		ulong num = _0023_003DztUjb52A_003D((_0023_003DzIaMpQArClRxi)0) + (ulong)_0023_003DzfjCaYvw_003D;
		ulong num2 = _0023_003Dz736ekIs_003D((_0023_003DzIaMpQArClRxi)0);
		if (num > num2)
		{
			throw new Exception();
		}
		ulong _0023_003DzI6pOOus_003D = 0uL;
		long _0023_003DzmzccG7u4pTgu = 0L;
		_0023_003Dz7A4qy1apwoGU(ref _0023_003DzI6pOOus_003D, ref _0023_003DzmzccG7u4pTgu, (_0023_003DzIaMpQArClRxi)0);
		long num3 = Math.Min(_0023_003DzfjCaYvw_003D, 1020 - _0023_003DzmzccG7u4pTgu);
		byte[] _0023_003Dzvo35by0HxqIC = new byte[1024];
		int num4 = 0;
		while (_0023_003DzfjCaYvw_003D > 0)
		{
			_0023_003Dz1wiUjU8F4u1r(ref _0023_003Dzvo35by0HxqIC, _0023_003DzI6pOOus_003D);
			switch (_0023_003DzIPkYOHaD0Sst)
			{
			case 100:
				_0023_003DzZMNwpELh2N_0024Q(_0023_003Dzvo35by0HxqIC, _0023_003DzI6pOOus_003D);
				break;
			default:
			{
				uint num5 = (uint)Math.Round(100.0 / (double)_0023_003DzIPkYOHaD0Sst);
				if (_0023_003DzI6pOOus_003D % num5 == 0L || _0023_003DzfjCaYvw_003D < 1024)
				{
					_0023_003DzZMNwpELh2N_0024Q(_0023_003Dzvo35by0HxqIC, _0023_003DzI6pOOus_003D);
				}
				break;
			}
			case 0:
				break;
			}
			Array.Copy(_0023_003Dzvo35by0HxqIC, (int)_0023_003DzmzccG7u4pTgu, _0023_003DzDj6LpX0_003D, num4, (int)num3);
			num4 += (int)num3;
			_0023_003DzfjCaYvw_003D -= num3;
			_0023_003DzmzccG7u4pTgu = 0L;
			_0023_003DzI6pOOus_003D++;
			num3 = Math.Min(_0023_003DzfjCaYvw_003D, 1020L);
		}
		_0023_003DzT51EUwQ_003D(num, (_0023_003DzIaMpQArClRxi)0);
	}
}
