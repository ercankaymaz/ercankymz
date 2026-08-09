using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal static class _0023_003DqJ75rpI46d2e8QXpNMN_0024n8TL1Vj_1GqTYBVSrg8oPYEM_003D
{
	public static byte[] _0023_003Dz52W686Mkn2Ch_0024VW_0024mQ_003D_003D(object _0023_003DzjYYAPCA_003D, ulong _0023_003DzVC9FBdo_003D, _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzwBouG0w_003D, RandomNumberGenerator _0023_003Dzf4Pqh9s_003D)
	{
		return _0023_003Dzl0sRAzefc8UICElxFy4RJeg_003D(_0023_003Dz4_Z93rVUyRdjsh8W60rvgetSisr3(_0023_003DzjYYAPCA_003D), _0023_003DzYyPLY4fIFQfDrG_0024ZwQPdEG4Ftf_0024v0_P52w_003D_003D(_0023_003DzVC9FBdo_003D), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
	}

	public static byte[] _0023_003Dzl0sRAzefc8UICElxFy4RJeg_003D(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzwBouG0w_003D, RandomNumberGenerator _0023_003Dzf4Pqh9s_003D)
	{
		int num = _0023_003DzjYYAPCA_003D.Length;
		if (num == 0)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzwBouG0w_003D._0023_003Dz6yWKn5RWb7TX7YfTPmAuYkQGbBUVyb7IKq9weDETUYolhIQUjGNVzu8Rgtk0LZEsFpyFDs_3SQhqAnPpIg_003D_003D();
		int num3 = _0023_003DzwBouG0w_003D._0023_003DzxmlC_Zo_oW81BAJ8I65ymN9fvteApvKrAhr_ENOUJQ_eQprME4lFPgaCIgbDK_01_sDs3v8_003D();
		int num4 = num % num2;
		int num5 = (num + (num2 - 1)) / num2;
		byte[] array;
		if (num4 == 0)
		{
			array = new byte[num];
			Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, 0, array, 0, num);
		}
		else
		{
			int _0023_003DzwBouG0w_003D2 = _0023_003DzRy5d63gSP_00249Te4Qeykp9og4VSQib(num4);
			byte[] bytes = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D2).GetBytes(num2);
			if (num5 == 1)
			{
				array = bytes;
			}
			else
			{
				array = new byte[num2 * num5];
				Buffer.BlockCopy(bytes, 0, array, num2 * (num5 - 1), num2);
			}
			Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, 0, array, 0, _0023_003DzjYYAPCA_003D.Length);
		}
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaWFxm5_jgeAwi2PjV1Hk_002498_003D._0023_003DzV7AM42Yl2jAbY4wp6gCgLY9P_CS2oHevdw_003D_003D(array, 0, array.Length / 4 * 4, _0023_003DzVC9FBdo_003D);
		byte[] array2 = new byte[_0023_003DzwBouG0w_003D._0023_003DzxmlC_Zo_oW81BAJ8I65ymN9fvteApvKrAhr_ENOUJQ_eQprME4lFPgaCIgbDK_01_sDs3v8_003D() * num5];
		for (int i = 0; i < num5; i++)
		{
			_0023_003DzwBouG0w_003D._0023_003Dz9htoK_3JkptM8kqGKCoLls0gCyl0YxEaqpdWRGC0cgW64QQ0i2FuHnA5ifidkO1VpyhTlQoeTNtHe8H3_00243_HfdI_003D(array, num2 * i, num2, array2, num3 * i, _0023_003Dzf4Pqh9s_003D);
		}
		return array2;
	}

	private static int _0023_003DzRy5d63gSP_00249Te4Qeykp9og4VSQib(int _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D < 8)
		{
			return 200;
		}
		return 1;
	}

	public static byte[] _0023_003Dz4_Z93rVUyRdjsh8W60rvgetSisr3(object _0023_003DzjYYAPCA_003D)
	{
		if (!(_0023_003DzjYYAPCA_003D is sbyte b))
		{
			if (!(_0023_003DzjYYAPCA_003D is byte b2))
			{
				if (!(_0023_003DzjYYAPCA_003D is short _0023_003DzjYYAPCA_003D2))
				{
					if (!(_0023_003DzjYYAPCA_003D is ushort _0023_003DzjYYAPCA_003D3))
					{
						if (!(_0023_003DzjYYAPCA_003D is int _0023_003DzjYYAPCA_003D4))
						{
							if (!(_0023_003DzjYYAPCA_003D is uint _0023_003DzjYYAPCA_003D5))
							{
								if (!(_0023_003DzjYYAPCA_003D is long _0023_003DzjYYAPCA_003D6))
								{
									if (!(_0023_003DzjYYAPCA_003D is ulong _0023_003DzjYYAPCA_003D7))
									{
										if (!(_0023_003DzjYYAPCA_003D is byte[] result))
										{
											if (!(_0023_003DzjYYAPCA_003D is string s))
											{
												if (_0023_003DzjYYAPCA_003D is IEnumerable enumerable)
												{
													MemoryStream memoryStream = new MemoryStream();
													foreach (object item in enumerable)
													{
														byte[] array = _0023_003Dz4_Z93rVUyRdjsh8W60rvgetSisr3(item);
														memoryStream.Write(array, 0, array.Length);
													}
													return memoryStream.ToArray();
												}
												throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619588));
											}
											return Encoding.Unicode.GetBytes(s);
										}
										return result;
									}
									return _0023_003DzYyPLY4fIFQfDrG_0024ZwQPdEG4Ftf_0024v0_P52w_003D_003D(_0023_003DzjYYAPCA_003D7);
								}
								return _0023_003Dzcorj7sW_aPaTLfcWJs5WvwisVgIo0My_fCr_0024sSI_003D(_0023_003DzjYYAPCA_003D6);
							}
							return _0023_003DzSw5MkiCDFSQ4sDPOjBbkY8iWFYmz32Bj0g_003D_003D(_0023_003DzjYYAPCA_003D5);
						}
						return _0023_003DzEKUC_0024FYQGeSj_0024czc6cmQQ4o_003D(_0023_003DzjYYAPCA_003D4);
					}
					return _0023_003DzWYX7vGDeMhd_CwPL8lT2gFv2JGRKPBFgxKG2WXpaRjiE(_0023_003DzjYYAPCA_003D3);
				}
				return _0023_003DzvH4Gw1lCmc5_0024GxR6bwWWn5ZC5jLT(_0023_003DzjYYAPCA_003D2);
			}
			return new byte[1] { b2 };
		}
		return new byte[1] { (byte)b };
	}

	private static byte[] _0023_003DzvH4Gw1lCmc5_0024GxR6bwWWn5ZC5jLT(short _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzWYX7vGDeMhd_CwPL8lT2gFv2JGRKPBFgxKG2WXpaRjiE((ushort)_0023_003DzjYYAPCA_003D);
	}

	private static byte[] _0023_003DzWYX7vGDeMhd_CwPL8lT2gFv2JGRKPBFgxKG2WXpaRjiE(ushort _0023_003DzjYYAPCA_003D)
	{
		byte[] array = new byte[2];
		array[1] = (byte)_0023_003DzjYYAPCA_003D;
		array[0] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		return array;
	}

	private static byte[] _0023_003DzEKUC_0024FYQGeSj_0024czc6cmQQ4o_003D(int _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzSw5MkiCDFSQ4sDPOjBbkY8iWFYmz32Bj0g_003D_003D((uint)_0023_003DzjYYAPCA_003D);
	}

	private static byte[] _0023_003DzSw5MkiCDFSQ4sDPOjBbkY8iWFYmz32Bj0g_003D_003D(uint _0023_003DzjYYAPCA_003D)
	{
		byte[] array = new byte[4];
		array[3] = (byte)_0023_003DzjYYAPCA_003D;
		array[2] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		array[1] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		array[0] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
		return array;
	}

	private static byte[] _0023_003Dzcorj7sW_aPaTLfcWJs5WvwisVgIo0My_fCr_0024sSI_003D(long _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzYyPLY4fIFQfDrG_0024ZwQPdEG4Ftf_0024v0_P52w_003D_003D((ulong)_0023_003DzjYYAPCA_003D);
	}

	private static byte[] _0023_003DzYyPLY4fIFQfDrG_0024ZwQPdEG4Ftf_0024v0_P52w_003D_003D(ulong _0023_003DzjYYAPCA_003D)
	{
		byte[] array = new byte[8];
		array[7] = (byte)_0023_003DzjYYAPCA_003D;
		array[6] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		array[5] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		array[4] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
		array[3] = (byte)(_0023_003DzjYYAPCA_003D >> 32);
		array[2] = (byte)(_0023_003DzjYYAPCA_003D >> 40);
		array[1] = (byte)(_0023_003DzjYYAPCA_003D >> 48);
		array[0] = (byte)(_0023_003DzjYYAPCA_003D >> 56);
		return array;
	}
}
