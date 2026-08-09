using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal static class _0023_003DqJTjaQmhkW8F60LVdPhnyDwADUWaHNqD2qYMVmbk_zcU_003D
{
	public static byte[] _0023_003DzmPHvYSeoVNXFzVNfng_003D_003D(object _0023_003Dzq80RbjQ_003D, ulong _0023_003DzZzVr6_0024U_003D, _0023_003DquMh_RbFIfA6Odscsrwq4H1xZqNu1kphCuT2OFISKuWI_003D _0023_003Dz7hRN5Rg_003D, RandomNumberGenerator _0023_003DzcbLoSrg_003D)
	{
		return _0023_003Dz9H_28IGfOkUAaRu_00247BDVLUs_003D(_0023_003DzhD38a3WXV0KK_0024tO1hPCGDpBbMFcy(_0023_003Dzq80RbjQ_003D), _0023_003Dzb8kCpO514TZOiFQd23ZjstL2tA_0024yKNlyIg_003D_003D(_0023_003DzZzVr6_0024U_003D), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
	}

	public static byte[] _0023_003Dz9H_28IGfOkUAaRu_00247BDVLUs_003D(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, _0023_003DquMh_RbFIfA6Odscsrwq4H1xZqNu1kphCuT2OFISKuWI_003D _0023_003Dz7hRN5Rg_003D, RandomNumberGenerator _0023_003DzcbLoSrg_003D)
	{
		int num = _0023_003Dzq80RbjQ_003D.Length;
		if (num == 0)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003Dz7hRN5Rg_003D._0023_003DzSEY04nxJtfqOe_NEWeo3eOc0Etbe_0024Jj8XZu70RmqdWkClVfxadDA7Yv3_toO92Ul_00242tmYNYn1vth6Wdsbw_003D_003D();
		int num3 = _0023_003Dz7hRN5Rg_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D();
		int num4 = num % num2;
		int num5 = (num + (num2 - 1)) / num2;
		byte[] array;
		if (num4 == 0)
		{
			array = new byte[num];
			Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, 0, array, 0, num);
		}
		else
		{
			int _0023_003Dz7hRN5Rg_003D2 = _0023_003Dz204kYI_0024ffTR_dc4HOFUk9KhdG3oy(num4);
			byte[] bytes = new _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D2).GetBytes(num2);
			if (num5 == 1)
			{
				array = bytes;
			}
			else
			{
				array = new byte[num2 * num5];
				Buffer.BlockCopy(bytes, 0, array, num2 * (num5 - 1), num2);
			}
			Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, 0, array, 0, _0023_003Dzq80RbjQ_003D.Length);
		}
		_0023_003Dq0d3UOaLcwAHpHXr73AEsTkHo9keJqsf1eDwAJmr_UdU_003D._0023_003DzG_wKkFN53GnGuWGf136K_0024SM2O6QGzBVrYA_003D_003D(array, 0, array.Length / 4 * 4, _0023_003DzZzVr6_0024U_003D);
		byte[] array2 = new byte[_0023_003Dz7hRN5Rg_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D() * num5];
		for (int i = 0; i < num5; i++)
		{
			_0023_003Dz7hRN5Rg_003D._0023_003Dzhdoh5k6m_0024AO52PAYFXGKQO9OGwW5kHwW2wyWQpayqijlwE_0024xck_GBc28La0KktESKmzv8a_0024ZIXdc4iz8z4aF4eo_003D(array, num2 * i, num2, array2, num3 * i, _0023_003DzcbLoSrg_003D);
		}
		return array2;
	}

	private static int _0023_003Dz204kYI_0024ffTR_dc4HOFUk9KhdG3oy(int _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D < 8)
		{
			return 200;
		}
		return 1;
	}

	public static byte[] _0023_003DzhD38a3WXV0KK_0024tO1hPCGDpBbMFcy(object _0023_003Dzq80RbjQ_003D)
	{
		if (!(_0023_003Dzq80RbjQ_003D is sbyte b))
		{
			if (!(_0023_003Dzq80RbjQ_003D is byte b2))
			{
				if (!(_0023_003Dzq80RbjQ_003D is short _0023_003Dzq80RbjQ_003D2))
				{
					if (!(_0023_003Dzq80RbjQ_003D is ushort _0023_003Dzq80RbjQ_003D3))
					{
						if (!(_0023_003Dzq80RbjQ_003D is int _0023_003Dzq80RbjQ_003D4))
						{
							if (!(_0023_003Dzq80RbjQ_003D is uint _0023_003Dzq80RbjQ_003D5))
							{
								if (!(_0023_003Dzq80RbjQ_003D is long _0023_003Dzq80RbjQ_003D6))
								{
									if (!(_0023_003Dzq80RbjQ_003D is ulong _0023_003Dzq80RbjQ_003D7))
									{
										if (!(_0023_003Dzq80RbjQ_003D is byte[] result))
										{
											if (!(_0023_003Dzq80RbjQ_003D is string s))
											{
												if (_0023_003Dzq80RbjQ_003D is IEnumerable enumerable)
												{
													MemoryStream memoryStream = new MemoryStream();
													foreach (object item in enumerable)
													{
														byte[] array = _0023_003DzhD38a3WXV0KK_0024tO1hPCGDpBbMFcy(item);
														memoryStream.Write(array, 0, array.Length);
													}
													return memoryStream.ToArray();
												}
												throw new ArgumentOutOfRangeException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527909));
											}
											return Encoding.Unicode.GetBytes(s);
										}
										return result;
									}
									return _0023_003Dzb8kCpO514TZOiFQd23ZjstL2tA_0024yKNlyIg_003D_003D(_0023_003Dzq80RbjQ_003D7);
								}
								return _0023_003DzSvHi6MEHNLUzFCPy3BGUcuNZD4IAF4PlALG2QCE_003D(_0023_003Dzq80RbjQ_003D6);
							}
							return _0023_003Dzgo8hWygHKx6Y0BbU1BfRPS1ZvSXKnXGitQ_003D_003D(_0023_003Dzq80RbjQ_003D5);
						}
						return _0023_003Dzbf4242Kh3Bs__0024q5dP8bz9eo_003D(_0023_003Dzq80RbjQ_003D4);
					}
					return _0023_003DzyWTUh9XWVWotwS5AG8v6AzFNIS5QOTMwdN811xydRzZt(_0023_003Dzq80RbjQ_003D3);
				}
				return _0023_003Dzb1C2CSggtH_0024xvMV6bSHYU16q6ZjX(_0023_003Dzq80RbjQ_003D2);
			}
			return new byte[1] { b2 };
		}
		return new byte[1] { (byte)b };
	}

	private static byte[] _0023_003Dzb1C2CSggtH_0024xvMV6bSHYU16q6ZjX(short _0023_003Dzq80RbjQ_003D)
	{
		return _0023_003DzyWTUh9XWVWotwS5AG8v6AzFNIS5QOTMwdN811xydRzZt((ushort)_0023_003Dzq80RbjQ_003D);
	}

	private static byte[] _0023_003DzyWTUh9XWVWotwS5AG8v6AzFNIS5QOTMwdN811xydRzZt(ushort _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = new byte[2];
		array[1] = (byte)_0023_003Dzq80RbjQ_003D;
		array[0] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		return array;
	}

	private static byte[] _0023_003Dzbf4242Kh3Bs__0024q5dP8bz9eo_003D(int _0023_003Dzq80RbjQ_003D)
	{
		return _0023_003Dzgo8hWygHKx6Y0BbU1BfRPS1ZvSXKnXGitQ_003D_003D((uint)_0023_003Dzq80RbjQ_003D);
	}

	private static byte[] _0023_003Dzgo8hWygHKx6Y0BbU1BfRPS1ZvSXKnXGitQ_003D_003D(uint _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = new byte[4];
		array[3] = (byte)_0023_003Dzq80RbjQ_003D;
		array[2] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		array[1] = (byte)(_0023_003Dzq80RbjQ_003D >> 16);
		array[0] = (byte)(_0023_003Dzq80RbjQ_003D >> 24);
		return array;
	}

	private static byte[] _0023_003DzSvHi6MEHNLUzFCPy3BGUcuNZD4IAF4PlALG2QCE_003D(long _0023_003Dzq80RbjQ_003D)
	{
		return _0023_003Dzb8kCpO514TZOiFQd23ZjstL2tA_0024yKNlyIg_003D_003D((ulong)_0023_003Dzq80RbjQ_003D);
	}

	private static byte[] _0023_003Dzb8kCpO514TZOiFQd23ZjstL2tA_0024yKNlyIg_003D_003D(ulong _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = new byte[8];
		array[7] = (byte)_0023_003Dzq80RbjQ_003D;
		array[6] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		array[5] = (byte)(_0023_003Dzq80RbjQ_003D >> 16);
		array[4] = (byte)(_0023_003Dzq80RbjQ_003D >> 24);
		array[3] = (byte)(_0023_003Dzq80RbjQ_003D >> 32);
		array[2] = (byte)(_0023_003Dzq80RbjQ_003D >> 40);
		array[1] = (byte)(_0023_003Dzq80RbjQ_003D >> 48);
		array[0] = (byte)(_0023_003Dzq80RbjQ_003D >> 56);
		return array;
	}
}
