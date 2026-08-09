using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal static class _0023_003DqEcE_dnDzdNcmr1ilrWUcQ52MvAN3ZHyGFRcpM7LnC4w_003D
{
	public static byte[] _0023_003DzK9xcv_hDDu6kvqXnkg_003D_003D(object _0023_003DziDLVpbY_003D, ulong _0023_003Dz5rQzobg_003D, _0023_003DqX0L7PWJ_0024pi7E1lZI88eAO5sAobDJ0hDC4y368rHz_0024nU_003D _0023_003DzAvn2b38_003D, RandomNumberGenerator _0023_003DzR58imxw_003D)
	{
		return _0023_003DzswucMeaQi20Z0ApFERiagLs_003D(_0023_003Dzf0splXt0bRX707FLbXEfteTwqmJi(_0023_003DziDLVpbY_003D), _0023_003DzXQ_0024Ki2NrLBMR1dgw4YW_0024wh4HsWT2_bRrCw_003D_003D(_0023_003Dz5rQzobg_003D), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
	}

	public static byte[] _0023_003DzswucMeaQi20Z0ApFERiagLs_003D(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, _0023_003DqX0L7PWJ_0024pi7E1lZI88eAO5sAobDJ0hDC4y368rHz_0024nU_003D _0023_003DzAvn2b38_003D, RandomNumberGenerator _0023_003DzR58imxw_003D)
	{
		int num = _0023_003DziDLVpbY_003D.Length;
		if (num == 0)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzAvn2b38_003D._0023_003Dz0tAR8yUFkU2jUm3AVFRoKtDLjDSmTKVAJNq86eLtMcXspFPCn0S4gvshDBjTY247PBKXdzvFQ6fsojO_0024Ag_003D_003D();
		int num3 = _0023_003DzAvn2b38_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D();
		int num4 = num % num2;
		int num5 = (num + (num2 - 1)) / num2;
		byte[] array;
		if (num4 == 0)
		{
			array = new byte[num];
			Buffer.BlockCopy(_0023_003DziDLVpbY_003D, 0, array, 0, num);
		}
		else
		{
			int _0023_003DzAvn2b38_003D2 = _0023_003Dz8dH375fyOE8_nEDnreXi6AU4w7wy(num4);
			byte[] bytes = new _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D2).GetBytes(num2);
			if (num5 == 1)
			{
				array = bytes;
			}
			else
			{
				array = new byte[num2 * num5];
				Buffer.BlockCopy(bytes, 0, array, num2 * (num5 - 1), num2);
			}
			Buffer.BlockCopy(_0023_003DziDLVpbY_003D, 0, array, 0, _0023_003DziDLVpbY_003D.Length);
		}
		_0023_003Dq83txtBmFlxymCNA_sU7I_0024dGG2o5r1_0024iekY4LWIcGipg_003D._0023_003Dzb_PcqFOYBcXHDo3Hh2cmxoigNyH9J8_FuQ_003D_003D(array, 0, array.Length / 4 * 4, _0023_003Dz5rQzobg_003D);
		byte[] array2 = new byte[_0023_003DzAvn2b38_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D() * num5];
		for (int i = 0; i < num5; i++)
		{
			_0023_003DzAvn2b38_003D._0023_003DzLwoZv45Pa4_0024jy1VJmhNsdx9TWiqb9GD1vXh6snfFDPWJagI3PaOJZtlcbubGf3aChPH5hztl2z13_hbHC_00243_coA_003D(array, num2 * i, num2, array2, num3 * i, _0023_003DzR58imxw_003D);
		}
		return array2;
	}

	private static int _0023_003Dz8dH375fyOE8_nEDnreXi6AU4w7wy(int _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D < 8)
		{
			return 200;
		}
		return 1;
	}

	public static byte[] _0023_003Dzf0splXt0bRX707FLbXEfteTwqmJi(object _0023_003DziDLVpbY_003D)
	{
		if (!(_0023_003DziDLVpbY_003D is sbyte b))
		{
			if (!(_0023_003DziDLVpbY_003D is byte b2))
			{
				if (!(_0023_003DziDLVpbY_003D is short _0023_003DziDLVpbY_003D2))
				{
					if (!(_0023_003DziDLVpbY_003D is ushort _0023_003DziDLVpbY_003D3))
					{
						if (!(_0023_003DziDLVpbY_003D is int _0023_003DziDLVpbY_003D4))
						{
							if (!(_0023_003DziDLVpbY_003D is uint _0023_003DziDLVpbY_003D5))
							{
								if (!(_0023_003DziDLVpbY_003D is long _0023_003DziDLVpbY_003D6))
								{
									if (!(_0023_003DziDLVpbY_003D is ulong _0023_003DziDLVpbY_003D7))
									{
										if (!(_0023_003DziDLVpbY_003D is byte[] result))
										{
											if (!(_0023_003DziDLVpbY_003D is string s))
											{
												if (_0023_003DziDLVpbY_003D is IEnumerable enumerable)
												{
													MemoryStream memoryStream = new MemoryStream();
													foreach (object item in enumerable)
													{
														byte[] array = _0023_003Dzf0splXt0bRX707FLbXEfteTwqmJi(item);
														memoryStream.Write(array, 0, array.Length);
													}
													return memoryStream.ToArray();
												}
												throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910280));
											}
											return Encoding.Unicode.GetBytes(s);
										}
										return result;
									}
									return _0023_003DzXQ_0024Ki2NrLBMR1dgw4YW_0024wh4HsWT2_bRrCw_003D_003D(_0023_003DziDLVpbY_003D7);
								}
								return _0023_003DzNP_nH_17iohlBWdpuQnE3l2BOZz7yKI9MjnZhtM_003D(_0023_003DziDLVpbY_003D6);
							}
							return _0023_003DztSHlzqGENe80H1Q1nJ8gQzhwiAiw5qTUug_003D_003D(_0023_003DziDLVpbY_003D5);
						}
						return _0023_003DzkgWKAmD00KgXmEjZHdA9FP8_003D(_0023_003DziDLVpbY_003D4);
					}
					return _0023_003DzRnKlvni7bhgZN3z7mor3jrXPC5VcSjhgVUdaw6EsybSD(_0023_003DziDLVpbY_003D3);
				}
				return _0023_003Dzc96ZTWX3CkrtCVespenbf41H1Zfc(_0023_003DziDLVpbY_003D2);
			}
			return new byte[1] { b2 };
		}
		return new byte[1] { (byte)b };
	}

	private static byte[] _0023_003Dzc96ZTWX3CkrtCVespenbf41H1Zfc(short _0023_003DziDLVpbY_003D)
	{
		return _0023_003DzRnKlvni7bhgZN3z7mor3jrXPC5VcSjhgVUdaw6EsybSD((ushort)_0023_003DziDLVpbY_003D);
	}

	private static byte[] _0023_003DzRnKlvni7bhgZN3z7mor3jrXPC5VcSjhgVUdaw6EsybSD(ushort _0023_003DziDLVpbY_003D)
	{
		byte[] array = new byte[2];
		array[1] = (byte)_0023_003DziDLVpbY_003D;
		array[0] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		return array;
	}

	private static byte[] _0023_003DzkgWKAmD00KgXmEjZHdA9FP8_003D(int _0023_003DziDLVpbY_003D)
	{
		return _0023_003DztSHlzqGENe80H1Q1nJ8gQzhwiAiw5qTUug_003D_003D((uint)_0023_003DziDLVpbY_003D);
	}

	private static byte[] _0023_003DztSHlzqGENe80H1Q1nJ8gQzhwiAiw5qTUug_003D_003D(uint _0023_003DziDLVpbY_003D)
	{
		byte[] array = new byte[4];
		array[3] = (byte)_0023_003DziDLVpbY_003D;
		array[2] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		array[1] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		array[0] = (byte)(_0023_003DziDLVpbY_003D >> 24);
		return array;
	}

	private static byte[] _0023_003DzNP_nH_17iohlBWdpuQnE3l2BOZz7yKI9MjnZhtM_003D(long _0023_003DziDLVpbY_003D)
	{
		return _0023_003DzXQ_0024Ki2NrLBMR1dgw4YW_0024wh4HsWT2_bRrCw_003D_003D((ulong)_0023_003DziDLVpbY_003D);
	}

	private static byte[] _0023_003DzXQ_0024Ki2NrLBMR1dgw4YW_0024wh4HsWT2_bRrCw_003D_003D(ulong _0023_003DziDLVpbY_003D)
	{
		byte[] array = new byte[8];
		array[7] = (byte)_0023_003DziDLVpbY_003D;
		array[6] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		array[5] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		array[4] = (byte)(_0023_003DziDLVpbY_003D >> 24);
		array[3] = (byte)(_0023_003DziDLVpbY_003D >> 32);
		array[2] = (byte)(_0023_003DziDLVpbY_003D >> 40);
		array[1] = (byte)(_0023_003DziDLVpbY_003D >> 48);
		array[0] = (byte)(_0023_003DziDLVpbY_003D >> 56);
		return array;
	}
}
