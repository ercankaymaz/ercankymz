using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal static class _0023_003DqN_Lzrpin_XrYR283pJ4HqqFVXOIqB9OF64C2AZJAFII_003D
{
	public static byte[] _0023_003DzNT1kTLCvIXcU4Pgtyw_003D_003D(object _0023_003Dz9jrlnWk_003D, ulong _0023_003DzBxpHhQ0_003D, _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003Dztgqm2r4_003D, RandomNumberGenerator _0023_003DzzKDx05I_003D)
	{
		return _0023_003DzyN1xGRdwmcdZYnEovXP26ks_003D(_0023_003DzngWw6xCDnvqC9f09N73y9vUdquBK(_0023_003Dz9jrlnWk_003D), _0023_003DzPqiNJJ0hRE_0024eEUmaFMLG57ohP68GGo3NYg_003D_003D(_0023_003DzBxpHhQ0_003D), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
	}

	public static byte[] _0023_003DzyN1xGRdwmcdZYnEovXP26ks_003D(byte[] _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003Dztgqm2r4_003D, RandomNumberGenerator _0023_003DzzKDx05I_003D)
	{
		int num = _0023_003Dz9jrlnWk_003D.Length;
		if (num == 0)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003Dztgqm2r4_003D._0023_003Dzl3Rckx5OVe4f3GM0WfBt7ZdV11R_0024nASNDSkqwIZT1MAKB0ukP_00242MtXtNOAkqHH1UoeoQg0tHnRD_x9ZBIg_003D_003D();
		int num3 = _0023_003Dztgqm2r4_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D();
		int num4 = num % num2;
		int num5 = (num + (num2 - 1)) / num2;
		byte[] array;
		if (num4 == 0)
		{
			array = new byte[num];
			Buffer.BlockCopy(_0023_003Dz9jrlnWk_003D, 0, array, 0, num);
		}
		else
		{
			int _0023_003Dztgqm2r4_003D2 = _0023_003Dzt4_0024i5InnhmTGZgznYieKLpHKcIyb(num4);
			byte[] bytes = new _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D2).GetBytes(num2);
			if (num5 == 1)
			{
				array = bytes;
			}
			else
			{
				array = new byte[num2 * num5];
				Buffer.BlockCopy(bytes, 0, array, num2 * (num5 - 1), num2);
			}
			Buffer.BlockCopy(_0023_003Dz9jrlnWk_003D, 0, array, 0, _0023_003Dz9jrlnWk_003D.Length);
		}
		_0023_003Dq7DDRIUR2HfeJRmeMtT4tOMe2NRdGzg4TR_S1kTwkG2I_003D._0023_003Dz6pRZrF8Tjm9s_0024hBAQ5OlLqCNsbQZJH_mzg_003D_003D(array, 0, array.Length / 4 * 4, _0023_003DzBxpHhQ0_003D);
		byte[] array2 = new byte[_0023_003Dztgqm2r4_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D() * num5];
		for (int i = 0; i < num5; i++)
		{
			_0023_003Dztgqm2r4_003D._0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(array, num2 * i, num2, array2, num3 * i, _0023_003DzzKDx05I_003D);
		}
		return array2;
	}

	private static int _0023_003Dzt4_0024i5InnhmTGZgznYieKLpHKcIyb(int _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D < 8)
		{
			return 200;
		}
		return 1;
	}

	public static byte[] _0023_003DzngWw6xCDnvqC9f09N73y9vUdquBK(object _0023_003Dz9jrlnWk_003D)
	{
		if (!(_0023_003Dz9jrlnWk_003D is sbyte b))
		{
			if (!(_0023_003Dz9jrlnWk_003D is byte b2))
			{
				if (!(_0023_003Dz9jrlnWk_003D is short _0023_003Dz9jrlnWk_003D2))
				{
					if (!(_0023_003Dz9jrlnWk_003D is ushort _0023_003Dz9jrlnWk_003D3))
					{
						if (!(_0023_003Dz9jrlnWk_003D is int _0023_003Dz9jrlnWk_003D4))
						{
							if (!(_0023_003Dz9jrlnWk_003D is uint _0023_003Dz9jrlnWk_003D5))
							{
								if (!(_0023_003Dz9jrlnWk_003D is long _0023_003Dz9jrlnWk_003D6))
								{
									if (!(_0023_003Dz9jrlnWk_003D is ulong _0023_003Dz9jrlnWk_003D7))
									{
										if (!(_0023_003Dz9jrlnWk_003D is byte[] result))
										{
											if (!(_0023_003Dz9jrlnWk_003D is string s))
											{
												if (_0023_003Dz9jrlnWk_003D is IEnumerable enumerable)
												{
													MemoryStream memoryStream = new MemoryStream();
													foreach (object item in enumerable)
													{
														byte[] array = _0023_003DzngWw6xCDnvqC9f09N73y9vUdquBK(item);
														memoryStream.Write(array, 0, array.Length);
													}
													return memoryStream.ToArray();
												}
												throw new ArgumentOutOfRangeException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312189));
											}
											return Encoding.Unicode.GetBytes(s);
										}
										return result;
									}
									return _0023_003DzPqiNJJ0hRE_0024eEUmaFMLG57ohP68GGo3NYg_003D_003D(_0023_003Dz9jrlnWk_003D7);
								}
								return _0023_003DzkIhmgjnhBqkDwfyWYOGxLku4xChTRFghOXE11yk_003D(_0023_003Dz9jrlnWk_003D6);
							}
							return _0023_003Dz53CTWqsj87hnG9KGmxZlmsrxTAb0svrsLQ_003D_003D(_0023_003Dz9jrlnWk_003D5);
						}
						return _0023_003DzAz_0024QjTx7dw5iqvfLnjcfpf4_003D(_0023_003Dz9jrlnWk_003D4);
					}
					return _0023_003DzYJj9UEohlGgBFyloCJcHMRZu78b32VdXIXuyGJ4Yn4BX(_0023_003Dz9jrlnWk_003D3);
				}
				return _0023_003DzeM5JrebzrKcYxqPLl8U8lsxKZhIh(_0023_003Dz9jrlnWk_003D2);
			}
			return new byte[1] { b2 };
		}
		return new byte[1] { (byte)b };
	}

	private static byte[] _0023_003DzeM5JrebzrKcYxqPLl8U8lsxKZhIh(short _0023_003Dz9jrlnWk_003D)
	{
		return _0023_003DzYJj9UEohlGgBFyloCJcHMRZu78b32VdXIXuyGJ4Yn4BX((ushort)_0023_003Dz9jrlnWk_003D);
	}

	private static byte[] _0023_003DzYJj9UEohlGgBFyloCJcHMRZu78b32VdXIXuyGJ4Yn4BX(ushort _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = new byte[2];
		array[1] = (byte)_0023_003Dz9jrlnWk_003D;
		array[0] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		return array;
	}

	private static byte[] _0023_003DzAz_0024QjTx7dw5iqvfLnjcfpf4_003D(int _0023_003Dz9jrlnWk_003D)
	{
		return _0023_003Dz53CTWqsj87hnG9KGmxZlmsrxTAb0svrsLQ_003D_003D((uint)_0023_003Dz9jrlnWk_003D);
	}

	private static byte[] _0023_003Dz53CTWqsj87hnG9KGmxZlmsrxTAb0svrsLQ_003D_003D(uint _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = new byte[4];
		array[3] = (byte)_0023_003Dz9jrlnWk_003D;
		array[2] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		array[1] = (byte)(_0023_003Dz9jrlnWk_003D >> 16);
		array[0] = (byte)(_0023_003Dz9jrlnWk_003D >> 24);
		return array;
	}

	private static byte[] _0023_003DzkIhmgjnhBqkDwfyWYOGxLku4xChTRFghOXE11yk_003D(long _0023_003Dz9jrlnWk_003D)
	{
		return _0023_003DzPqiNJJ0hRE_0024eEUmaFMLG57ohP68GGo3NYg_003D_003D((ulong)_0023_003Dz9jrlnWk_003D);
	}

	private static byte[] _0023_003DzPqiNJJ0hRE_0024eEUmaFMLG57ohP68GGo3NYg_003D_003D(ulong _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = new byte[8];
		array[7] = (byte)_0023_003Dz9jrlnWk_003D;
		array[6] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		array[5] = (byte)(_0023_003Dz9jrlnWk_003D >> 16);
		array[4] = (byte)(_0023_003Dz9jrlnWk_003D >> 24);
		array[3] = (byte)(_0023_003Dz9jrlnWk_003D >> 32);
		array[2] = (byte)(_0023_003Dz9jrlnWk_003D >> 40);
		array[1] = (byte)(_0023_003Dz9jrlnWk_003D >> 48);
		array[0] = (byte)(_0023_003Dz9jrlnWk_003D >> 56);
		return array;
	}
}
