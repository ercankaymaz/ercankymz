using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd
{
	private enum _0023_003Dz0NLOuv63eEPMLlNRSILwnvLzcBfg
	{

	}

	private sealed class _0023_003DzrLfvVbIKP44TPS4MC7txyBXpKgCF
	{
		private Stream _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i;

		private byte[] _0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk;

		public _0023_003DzrLfvVbIKP44TPS4MC7txyBXpKgCF(Stream _0023_003DzTq8rkRWKl8Wp2otRJWkNtE1it5ME)
		{
			_0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i = _0023_003DzTq8rkRWKl8Wp2otRJWkNtE1it5ME;
			_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk = new byte[4];
		}

		public Stream _0023_003DzMXFCXjijr7px9B0FRcwcUAHuyKMp()
		{
			return _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i;
		}

		public short _0023_003Dzo6O_00245NKJSwWVYqS2mKY0IJaO9_0024ei()
		{
			_0023_003Dz_RQYB_00242QPDdV140efg_00245Rpw_003D(2);
			return (short)(_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[0] | (_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[1] << 8));
		}

		public int _0023_003Dz7wzW0hwe1bah0RXNukGxbwc_003D()
		{
			_0023_003Dz_RQYB_00242QPDdV140efg_00245Rpw_003D(4);
			return _0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[0] | (_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[1] << 8) | (_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[2] << 16) | (_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[3] << 24);
		}

		private static void _0023_003DzTCFx3Ucm6LweYOab3I_0024RAeWyXYUK()
		{
			throw new EndOfStreamException();
		}

		private void _0023_003Dz_RQYB_00242QPDdV140efg_00245Rpw_003D(int _0023_003DzuKNychnkxzxeLm44IOdWhwrpKcd4)
		{
			int num = 0;
			int num2 = 0;
			if (_0023_003DzuKNychnkxzxeLm44IOdWhwrpKcd4 == 1)
			{
				num2 = _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i.ReadByte();
				if (num2 == -1)
				{
					_0023_003DzTCFx3Ucm6LweYOab3I_0024RAeWyXYUK();
				}
				_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i.Read(_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk, num, _0023_003DzuKNychnkxzxeLm44IOdWhwrpKcd4 - num);
				if (num2 == 0)
				{
					_0023_003DzTCFx3Ucm6LweYOab3I_0024RAeWyXYUK();
				}
				num += num2;
			}
			while (num < _0023_003DzuKNychnkxzxeLm44IOdWhwrpKcd4);
		}

		public void _0023_003DzOxtKjgvjVujUSUOmwNvGHZgJ7cfT()
		{
			Stream stream = _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i;
			_0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i = null;
			stream?.Close();
			_0023_003DzeZgzwdzwM4X3iEvvQw6LwgGWdFEk = null;
		}

		public byte[] _0023_003DzdUKr3AqX5L7I9zujWNynseA_003D(int _0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1)
		{
			if (_0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1];
			int num = 0;
			do
			{
				int num2 = _0023_003Dz2AVDN2oGnQzT8YD2sWEOEQ4iSg9i.Read(array, num, _0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				_0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1 -= num2;
			}
			while (_0023_003DzPcDSXxpeU5ZwHXQjrTGagQOI_PL1 > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	private static byte[] _0023_003DzTYEs38RPHfqtuExKjX6MT4FU1COb;

	private static ConcurrentDictionary<int, string> _0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc;

	private static byte[] _0023_003Dzb5FLofkcOiiiayN5_0024W0EsNMnm4_4;

	private static int _0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh;

	private static int _0023_003Dzf0hbiEDzfDvVXJeEVdxxuG9rtOe7;

	private static _0023_003DzrLfvVbIKP44TPS4MC7txyBXpKgCF _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh;

	private static short _0023_003Dz2a6pKa5M0UEY0OmRzxBC953mbw0J;

	private static _0023_003Dz0NLOuv63eEPMLlNRSILwnvLzcBfg _0023_003DzJDL_0024KSDGFgky6HRplKTPKDjnwwpl;

	private static int _0023_003Dzd_0024qd7SsaykDx_lKmqpPtb_QT2UkG;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd()
	{
		int num = 1065114761;
		int num2 = 1275358211 - num;
		_0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc = new ConcurrentDictionary<int, string>();
		_0023_003Dzd_0024qd7SsaykDx_lKmqpPtb_QT2UkG += -(~(-(~(~(-(-(~(~((-1088610490 ^ num) - num2)))))))));
		_0023_003DzJDL_0024KSDGFgky6HRplKTPKDjnwwpl |= (_0023_003Dz0NLOuv63eEPMLlNRSILwnvLzcBfg)16;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0023_003Dz4A3Alm0_003D(int _0023_003Dzxt29mngBZp598irzEaNVZo1zELpe)
	{
		if (_0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc.TryGetValue(_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe, out var value))
		{
			return value;
		}
		return _0023_003Dz3ncuh4RojRbO78II_0024BkO_0024JA_003D(_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe, _0023_003DzuLhZYCCUd3PTEPFkjruuWemnFNjP: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string _0023_003Dz3ncuh4RojRbO78II_0024BkO_0024JA_003D(int _0023_003Dzxt29mngBZp598irzEaNVZo1zELpe, bool _0023_003DzuLhZYCCUd3PTEPFkjruuWemnFNjP)
	{
		int num = 1319701118;
		int num2 = 464441031 - num;
		string value = null;
		byte[] array;
		int num18;
		int num19;
		int num20;
		int num22;
		byte[] array4;
		byte[] array3;
		int num21;
		while (true)
		{
			bool lockTaken = false;
			ConcurrentDictionary<int, string> obj = _0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				int num5;
				if (_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh == null)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					Assembly callingAssembly;
					try
					{
						callingAssembly = Assembly.GetCallingAssembly();
					}
					catch (PlatformNotSupportedException)
					{
						callingAssembly = executingAssembly;
					}
					_0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh |= (-2085135179 ^ num) - num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = -841574536 - num + num2;
					stringBuilder.Append((char)(byte)num3).Append((char)(byte)(num3 >> 24)).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = (0x50EE01DF ^ num) - num2;
					stringBuilder.Append((char)(byte)(num3 >> 24)).Append((char)(byte)num3).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = num + -464440928 + num2;
					stringBuilder.Append((char)(byte)num3);
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh = new _0023_003DzrLfvVbIKP44TPS4MC7txyBXpKgCF(manifestResourceStream);
					short num4 = (short)(_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003Dzo6O_00245NKJSwWVYqS2mKY0IJaO9_0024ei() ^ (short)(~(-(~(-(-(~(~(-(~((-2085673008 ^ num) - num2)))))))))));
					if (num4 == 0)
					{
						_0023_003Dz2a6pKa5M0UEY0OmRzxBC953mbw0J = (short)(_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003Dzo6O_00245NKJSwWVYqS2mKY0IJaO9_0024ei() ^ (short)(~(-(-(~(-(~(-(~(~(-(~(-2119986594 - num + num2)))))))))))));
					}
					else
					{
						_0023_003DzTYEs38RPHfqtuExKjX6MT4FU1COb = _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzdUKr3AqX5L7I9zujWNynseA_003D(num4);
					}
					callingAssembly = executingAssembly;
					AssemblyName _0023_003Dz_P3c1uPQ4CNZ1RCrY_yYetRASolt = _0023_003DzxqSFhzbF9k_jYU_0024t5qeoKd__4tnu(callingAssembly);
					_0023_003Dzb5FLofkcOiiiayN5_0024W0EsNMnm4_4 = _0023_003Dz04j2WbiSKGiFocj1XqhNj6jh9xpx(_0023_003Dz_P3c1uPQ4CNZ1RCrY_yYetRASolt);
					num5 = _0023_003Dzd_0024qd7SsaykDx_lKmqpPtb_QT2UkG;
					_0023_003Dzd_0024qd7SsaykDx_lKmqpPtb_QT2UkG = 0;
					num5 ^= (num ^ 0x4F10D6FC) - num2;
					long num6 = _0023_003DzL2YGmMRLVUQ83uqk3TZ_0024KupEcD8J._0023_003Dz4A3Alm0_003D();
					num5 ^= (int)num6;
					num5 ^= num + 1309241782 + num2;
					int num7 = 0;
					int num8 = 0;
					int num9 = num5;
					int num10 = 0;
					global::_0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D<int> _0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2 = null;
					int num11 = 0;
					num10 = num9;
					int num12 = 0;
					int num13 = 0;
					num12 = 0;
					num11 = (-138384944 - num - num2) ^ num10;
					_0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2 = null;
					num8 = num11;
					num13 = 0;
					num12 = -2085827006 ^ num ^ num2;
					_0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2 = ((global::_0023_003DzgaFaIrFT46JHf_00248i3m_0024v_EEt331Vztv4xA_003D_003D<int>)new _0023_003DzaVpYfGyUw4K8RFvaEO6_Mglwe4zLEdpfCg_003D_003D._0023_003Dz7hRN5Rg_003D(-2120006093 - num + num2)
					{
						_0023_003DzqMLoHoQ_003D = num8
					}).GetEnumerator();
					try
					{
						while (_0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2._0023_003DzpZoU3PfuwSerq6SNZMhRutkewugnEuDYS0qtUqZ2N8_6kg_Y0esTwb6ZiCEft0XfU3_002444GU_003D())
						{
							num13 = _0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2._0023_003DzJ_6Fq6ssfE70_0024Ap1165Fqkyg5GwDBwe4pq03TEYx4O4HGcnbQ0NzHykTJmYNBCjnGfJO1h12cYah();
							num11 ^= num13 - num12;
							num12 -= 3 + num11 >> 8;
						}
					}
					finally
					{
						_0023_003DzSIYmTZ6_00249uNgdMe1FqA2OSUbFhh20G8ZJg_003D_003D2?._0023_003DzBfj4rLQuIs4orp78rm53qyjX3AQ5IxIkZECOMXcjOiLjDca9_zhnzESRuVSetEgoqzRgUpn4Y2kt();
					}
					num7 = num11;
					int num14 = num7 * (num + 2120011384 - num2) % ((457937954 - num) ^ num2);
					num5 ^= 2120721149 + num - num2 + ~(-(~(-(-(~(~(-(~((-2120006400 - num) | num2)))))))));
					num5 ^= ~(-(~(-(-(~(~(-(~((1042319700 + num) ^ num2)))))))));
					num5 = num14 + num5;
					_0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh = (_0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh & ((num ^ -1817392699) - num2)) ^ ((2120012879 + num) ^ num2);
					_0023_003Dzf0hbiEDzfDvVXJeEVdxxuG9rtOe7 = num5;
					if (((uint)_0023_003DzJDL_0024KSDGFgky6HRplKTPKDjnwwpl & (uint)(-(~(-(~(-(~(~(-(~(-2120006106 - num + num2))))))))))) == 0)
					{
						_0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh = (num ^ -2085651843) - num2;
					}
				}
				else
				{
					num5 = _0023_003Dzf0hbiEDzfDvVXJeEVdxxuG9rtOe7;
				}
				if (_0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh == ((num + 2119984501) ^ num2))
				{
					value = new string(new char[3]
					{
						(char)((num ^ -2085826849) - num2),
						'0',
						(char)((2120006035 + num) ^ num2)
					});
					return value;
				}
				int num15 = _0023_003Dzxt29mngBZp598irzEaNVZo1zELpe ^ (1493954415 - num + num2) ^ num5;
				num15 ^= (num + -1657654485) ^ num2;
				_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzMXFCXjijr7px9B0FRcwcUAHuyKMp().Position = num15;
				if (_0023_003DzTYEs38RPHfqtuExKjX6MT4FU1COb != null)
				{
					array = _0023_003DzTYEs38RPHfqtuExKjX6MT4FU1COb;
				}
				else
				{
					short num16 = ((_0023_003Dz2a6pKa5M0UEY0OmRzxBC953mbw0J != -1) ? _0023_003Dz2a6pKa5M0UEY0OmRzxBC953mbw0J : ((short)(_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003Dzo6O_00245NKJSwWVYqS2mKY0IJaO9_0024ei() ^ (-2120031008 - num + num2) ^ num15)));
					if (num16 == 0)
					{
						array = null;
					}
					else
					{
						array = _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzdUKr3AqX5L7I9zujWNynseA_003D(num16);
						for (int num17 = 0; num17 != array.Length; num17 = 1 + num17)
						{
							array[num17] ^= (byte)(_0023_003Dzf0hbiEDzfDvVXJeEVdxxuG9rtOe7 >> ((3 & num17) << 3));
						}
					}
				}
				num18 = _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003Dz7wzW0hwe1bah0RXNukGxbwc_003D() ^ num15 ^ -(~(-(~(-(~(-(~(~(-(~((-1703192164 ^ num) - num2))))))))))) ^ num5;
				if (num18 == ((-2120006091 - num) ^ num2))
				{
					byte[] array2 = _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzdUKr3AqX5L7I9zujWNynseA_003D(4);
					_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe = ((num ^ -1953481012) - num2) ^ num5;
					_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe;
					goto IL_0013;
				}
				num19 = _0023_003Dz60Vo5DVNI5Cz6zDzSe5X9f64_FNh;
				num20 = num + -462833217 + num2;
				num21 = num19 - 12;
				num22 = num18;
				num18 &= (-1817391562 ^ num) - num2;
				array3 = _0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzdUKr3AqX5L7I9zujWNynseA_003D(num18);
				array4 = _0023_003Dzb5FLofkcOiiiayN5_0024W0EsNMnm4_4;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
			break;
			IL_0013:
			if (_0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc.TryGetValue(_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe, out value))
			{
				return value;
			}
		}
		bool flag = (num22 & (609300793 + num + num2)) != 0;
		bool flag2 = (num22 & (-1683042617 - num - num2)) != 0;
		bool flag3 = (num22 & ((num ^ 0x1C5331C9) + num2)) != 0;
		byte[] array5 = array;
		byte[] array6 = array3;
		byte[] array7 = array5;
		byte b = 0;
		byte b2 = 0;
		int num23 = 0;
		int num24 = 0;
		ushort num25 = 0;
		byte b3 = 0;
		byte b4 = 0;
		uint num26 = 0u;
		b3 = array7[1];
		num24 = array6.Length;
		b4 = (byte)((11 + num24) ^ (7 + b3));
		num26 = (uint)((array7[0] | (array7[2] << 8)) + (b4 << 3));
		num23 = 0;
		num25 = 0;
		for (; num23 < num24; num23++)
		{
			if ((num23 & 1) == 0)
			{
				num26 = (uint)((int)num26 * (464655044 - num - num2) + ((num ^ 0x7D89D004) + num2));
				num25 = (ushort)(num26 >> 16);
			}
			b2 = (byte)num25;
			num25 >>= 8;
			b = array6[num23];
			array6[num23] = (byte)(b ^ b3 ^ (3 + b4) ^ b2);
			b4 = b;
		}
		array3 = array6;
		if (array4 != null != (num20 != num19))
		{
			for (int i = 0; i < num18; i++)
			{
				byte b5 = array4[i & 7];
				b5 = (byte)((b5 << 3) | (b5 >> 5));
				array3[i] ^= b5;
			}
		}
		byte[] array8;
		int num27;
		if (!flag2)
		{
			array8 = array3;
			num27 = num18;
		}
		else
		{
			num27 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
			array8 = new byte[num27];
			_0023_003Dz6tTWg4KHRLzeq1t0jA25bFzTQKmb(array3, 4, array8);
		}
		if (flag && num21 == num20 - 12)
		{
			char[] array9 = new char[num27];
			for (int j = 0; j < num27; j++)
			{
				array9[j] = (char)array8[j];
			}
			value = new string(array9);
		}
		else
		{
			char[] array10 = new char[num27 / 2];
			int num28 = 0;
			for (int num29 = 0; num29 < num27; num29 = 2 + num29)
			{
				array10[num28++] = (char)(array8[num29] | (array8[num29 + 1] << 8));
			}
			value = new string(array10);
		}
		num21 += ((464441012 - num) ^ num2) + (3 & num21) << 5;
		if (num21 != num20 - 12 + ((-2085826890 ^ num) - num2 + ((num20 - 12) & 3) << 5))
		{
			int num30 = (num18 + _0023_003Dzxt29mngBZp598irzEaNVZo1zELpe) ^ (-2119069523 - num + num2) ^ (num21 & (2120007384 + num - num2));
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = (464440975 - num) ^ num2;
			stringBuilder.Append((char)(byte)num3);
			value = num30.ToString(stringBuilder.ToString());
		}
		if (!flag3 && _0023_003DzuLhZYCCUd3PTEPFkjruuWemnFNjP)
		{
			value = string.Intern(value);
			_0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc[_0023_003Dzxt29mngBZp598irzEaNVZo1zELpe] = value;
			if (_0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc.Count == num + -464440650 + num2)
			{
				bool lockTaken2 = false;
				ConcurrentDictionary<int, string> obj2 = _0023_003DzOzt9hqAbqVYKcaAJBTOE2X6lgDvc;
				try
				{
					Monitor.Enter(obj2, ref lockTaken2);
					if (_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh != null)
					{
						_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh._0023_003DzOxtKjgvjVujUSUOmwNvGHZgJ7cfT();
						_0023_003DzCTSFEU3m37MJlbtUjNMYHswlscxh = null;
						_0023_003DzTYEs38RPHfqtuExKjX6MT4FU1COb = null;
						_0023_003Dzb5FLofkcOiiiayN5_0024W0EsNMnm4_4 = null;
					}
				}
				finally
				{
					if (lockTaken2)
					{
						Monitor.Exit(obj2);
					}
				}
			}
		}
		return value;
	}

	private static AssemblyName _0023_003DzxqSFhzbF9k_jYU_0024t5qeoKd__4tnu(Assembly _0023_003DzSY8_M_ORL8RefQqPEc0NMEEtgIAt)
	{
		try
		{
			return _0023_003DzSY8_M_ORL8RefQqPEc0NMEEtgIAt.GetName();
		}
		catch
		{
			return new AssemblyName(_0023_003DzSY8_M_ORL8RefQqPEc0NMEEtgIAt.FullName);
		}
	}

	private static byte[] _0023_003Dz04j2WbiSKGiFocj1XqhNj6jh9xpx(AssemblyName _0023_003Dz_P3c1uPQ4CNZ1RCrY_yYetRASolt)
	{
		byte[] array = _0023_003Dz_P3c1uPQ4CNZ1RCrY_yYetRASolt.GetPublicKeyToken();
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		return array;
	}

	private static void _0023_003Dz6tTWg4KHRLzeq1t0jA25bFzTQKmb(byte[] _0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU, int _0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c, byte[] _0023_003Dz4HoJeY0wSlITrVAWw1AAuPAiKwAa)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = _0023_003Dz4HoJeY0wSlITrVAWw1AAuPAiKwAa.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU[_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU[_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c] >> 2) + 3;
				int num6 = ((_0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU[_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c] << 8) | _0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU[_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c + 1]) & 0x3FF;
				_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0023_003Dz4HoJeY0wSlITrVAWw1AAuPAiKwAa[num++] = _0023_003Dz4HoJeY0wSlITrVAWw1AAuPAiKwAa[num7++];
				}
			}
			else
			{
				_0023_003Dz4HoJeY0wSlITrVAWw1AAuPAiKwAa[num++] = _0023_003Dzn4FJfMZyZtT5ZocErrHbp1MgIBCU[_0023_003DzTHbuuiN578tsXkoWN3oEHnmBAA_0024c++];
			}
		}
	}
}
