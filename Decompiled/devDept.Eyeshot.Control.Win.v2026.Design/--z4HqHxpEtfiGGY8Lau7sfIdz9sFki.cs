using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki
{
	private sealed class _0023_003Dz99xad0qGw1aMuhTEKD9CSQqSHyvr
	{
		private Stream _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu;

		private byte[] _0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i;

		public _0023_003Dz99xad0qGw1aMuhTEKD9CSQqSHyvr(Stream _0023_003Dz6EGnF4GeYx_ppRXxagzIny8cAt64)
		{
			_0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu = _0023_003Dz6EGnF4GeYx_ppRXxagzIny8cAt64;
			_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i = new byte[4];
		}

		public Stream _0023_003DzuxB0JN6F87OueOjv0EiN8ZGZAXs7()
		{
			return _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu;
		}

		public short _0023_003DzbrKlhC_xk5DYPdNCcabAbaF3Anjn()
		{
			_0023_003DzMbnGs_002484FIbdCUo2J_QrxNM_003D(2);
			return (short)(_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[0] | (_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[1] << 8));
		}

		public int _0023_003DzC5Ue3NVwjFhnh9rXIV6qmdw_003D()
		{
			_0023_003DzMbnGs_002484FIbdCUo2J_QrxNM_003D(4);
			return _0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[0] | (_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[1] << 8) | (_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[2] << 16) | (_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[3] << 24);
		}

		private static void _0023_003DzUaxWX6vCIRSpmBCVirpAn0s7Alin()
		{
			throw new EndOfStreamException();
		}

		private void _0023_003DzMbnGs_002484FIbdCUo2J_QrxNM_003D(int _0023_003Dzi_G8N7IOB8SZkkj6kenEFl3AKA_Y)
		{
			int num = 0;
			int num2 = 0;
			if (_0023_003Dzi_G8N7IOB8SZkkj6kenEFl3AKA_Y == 1)
			{
				num2 = _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu.ReadByte();
				if (num2 == -1)
				{
					_0023_003DzUaxWX6vCIRSpmBCVirpAn0s7Alin();
				}
				_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu.Read(_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i, num, _0023_003Dzi_G8N7IOB8SZkkj6kenEFl3AKA_Y - num);
				if (num2 == 0)
				{
					_0023_003DzUaxWX6vCIRSpmBCVirpAn0s7Alin();
				}
				num += num2;
			}
			while (num < _0023_003Dzi_G8N7IOB8SZkkj6kenEFl3AKA_Y);
		}

		public void _0023_003Dz_00245HP46Yx4MoYF8RQvLPm40xrvPgA()
		{
			Stream stream = _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu;
			_0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu = null;
			stream?.Close();
			_0023_003DznJcThJqA0_PuIIgWiGuGMXUS0p6i = null;
		}

		public byte[] _0023_003DzzGgLm_JpB_rbvkKOWt85qbA_003D(int _0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X)
		{
			if (_0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X];
			int num = 0;
			do
			{
				int num2 = _0023_003Dz2o39rtkiNvIKmrma386RDXMqyKdu.Read(array, num, _0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				_0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X -= num2;
			}
			while (_0023_003DzQntvMSaR_0024ccktltL0yoprf4b5Q1X > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	private enum _0023_003DzTM8DesmDK6PIZErUHS06zZdNki5t
	{

	}

	private static byte[] _0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei;

	private static ConcurrentDictionary<int, string> _0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS;

	private static byte[] _0023_003Dz_0024vhQsYzmZN6_mF2CzZzjoRLOICHE;

	private static int _0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe;

	private static int _0023_003DzT9FKzIScBAOG8B2oDuQfqdQOuGEv;

	private static _0023_003Dz99xad0qGw1aMuhTEKD9CSQqSHyvr _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS;

	private static short _0023_003DzL9a7XFhvKCfNYLDx893x15XQhPLc;

	private static _0023_003DzTM8DesmDK6PIZErUHS06zZdNki5t _0023_003Dz9NBR2fVURELOkn0r2iPtHvDSkWbg;

	private static int _0023_003DzM2_0024doYfxnpvY9Cfmu1dm5P1a2Ltl;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki()
	{
		int num = -517470319;
		int num2 = -2402648 - num;
		_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS = new ConcurrentDictionary<int, string>();
		_0023_003DzM2_0024doYfxnpvY9Cfmu1dm5P1a2Ltl += ~(-(-(~(~(-(~(-(~(-860938438 + num - num2)))))))));
		_0023_003Dz9NBR2fVURELOkn0r2iPtHvDSkWbg |= (_0023_003DzTM8DesmDK6PIZErUHS06zZdNki5t)16;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0023_003Dznx1EMIs_003D(int _0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t)
	{
		if (_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS.TryGetValue(_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t, out var value))
		{
			return value;
		}
		return _0023_003DztzTq3fJACEiFL08WFA__xCo_003D(_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t, _0023_003DzhLWBf0iQ01bxE1aeZvaVvCl6HhjT: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string _0023_003DztzTq3fJACEiFL08WFA__xCo_003D(int _0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t, bool _0023_003DzhLWBf0iQ01bxE1aeZvaVvCl6HhjT)
	{
		int num = 329448526;
		int num2 = num + -2087968535;
		string value = null;
		byte[] array;
		int num17;
		int num18;
		int num19;
		int num21;
		byte[] array4;
		byte[] array3;
		int num20;
		while (true)
		{
			lock (_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS)
			{
				int num5;
				if (_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS == null)
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
					_0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe |= num ^ -2070580229 ^ num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = -655527624 + num - num2;
					stringBuilder.Append((char)(byte)num3).Append((char)(byte)(num3 >> 24)).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = num ^ -403921600 ^ num2;
					stringBuilder.Append((char)(byte)(num3 >> 24)).Append((char)(byte)num3).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = 2087982435 - num + num2;
					stringBuilder.Append((char)(byte)(num3 >> 8)).Append((char)(byte)num3);
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS = new _0023_003Dz99xad0qGw1aMuhTEKD9CSQqSHyvr(manifestResourceStream);
					short num4 = (short)(_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzbrKlhC_xk5DYPdNCcabAbaF3Anjn() ^ (short)(~(-(-(~(~(-(~(-(~(-(~((-2087957408 + num) ^ num2)))))))))))));
					if (num4 == 0)
					{
						_0023_003DzL9a7XFhvKCfNYLDx893x15XQhPLc = (short)(_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzbrKlhC_xk5DYPdNCcabAbaF3Anjn() ^ (short)(-(~(-(~(~(-(~(-(-(~(~(-1429044717 - num - num2)))))))))))));
					}
					else
					{
						_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei = _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzzGgLm_JpB_rbvkKOWt85qbA_003D(num4);
					}
					callingAssembly = executingAssembly;
					AssemblyName _0023_003DzS4SXI_58ysRMAI9OTsNCGXITrjqE = _0023_003DzNLB4dedvig9WEymq37aZU_00245MVtao(callingAssembly);
					_0023_003Dz_0024vhQsYzmZN6_mF2CzZzjoRLOICHE = _0023_003Dz3fwJG9uDhbetAfu_cx11cqrVQDZe(_0023_003DzS4SXI_58ysRMAI9OTsNCGXITrjqE);
					num5 = _0023_003DzM2_0024doYfxnpvY9Cfmu1dm5P1a2Ltl;
					num5 ^= -1981677900 + num + num2;
					_0023_003DzM2_0024doYfxnpvY9Cfmu1dm5P1a2Ltl = 0;
					long num6 = _0023_003DzeUhoxGmGoknQy6UOkug_0024WwrsW776._0023_003Dznx1EMIs_003D();
					num5 ^= (int)num6;
					num5 ^= (num ^ 0x1345A1FA) - num2;
					int num7 = 0;
					int num8 = num5;
					int num9 = 0;
					int num10 = 0;
					global::_0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D<int> _0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2 = null;
					int num11 = 0;
					int num12 = 0;
					int num13 = 0;
					num10 = num8;
					num13 = 0;
					num11 = (num + 826245508 + num2) ^ num10;
					_0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2 = null;
					num7 = num11;
					num13 = -2071076596 ^ num ^ num2;
					num12 = 0;
					_0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2 = ((global::_0023_003DzMrhBpPnDzolitdOwUNNW0ieImh4gU9CMrA_003D_003D<int>)new _0023_003DzvVk8rrCZQSpSrY3J6sBG8_0024_0024HcPmMUkFVBA_003D_003D._0023_003Dztgqm2r4_003D(2087968533 - num + num2)
					{
						_0023_003Dz3iPku7s_003D = num7
					}).GetEnumerator();
					try
					{
						while (_0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2._0023_003Dzu24uCyrA6l4A4D0E8WPH4JUdWyoEW_0024bfOwW69FTSuEqD6_JBoS8_jPtd6Wx4CffFEyThftg_003D())
						{
							num12 = _0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2._0023_003DzpZoU3PfuwSerq6SNZMhRutkewugnEuDYS0qtUqZ2N88h97WWKyz50Q4MPBP_G0q9eHCy_0024i7Zzxoi();
							num11 ^= num12 - num13;
							num13 -= 3 + num11 >> 8;
						}
					}
					finally
					{
						_0023_003DzRXXiQJlcBn8hYO1bGEjyrkZzcVIuGI4H_g_003D_003D2?._0023_003Dz03wpUA_xTVPqgOrNAORsJCXgVqvrkmeoyyhaKAwRhktCyTdEAKKZ5ThoUL3sLhNB7HM2CROCWNhj();
					}
					num9 = num11;
					int num14 = num9 * (num + -2087963242 - num2) % ((-1440002776 - num) ^ num2);
					num5 ^= (num ^ -2070349273) - num2 + -(~(-(~(-(~(~(-(~(num + 1429071178 + num2)))))))));
					num5 ^= -(~(-(~(~(-(-(~(~(-782335742 - num - num2)))))))));
					num5 = (_0023_003DzT9FKzIScBAOG8B2oDuQfqdQOuGEv = num14 + num5);
					_0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe = (_0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe & ((0x6B721E75 ^ num) + num2)) ^ (-1429064695 - num - num2);
					if (((uint)_0023_003Dz9NBR2fVURELOkn0r2iPtHvDSkWbg & (uint)(-(~(-(~(-(~(~(-(~((num + 1429071480) ^ num2))))))))))) == 0)
					{
						_0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe = (num ^ 0x7B7372CD) + num2;
					}
				}
				else
				{
					num5 = _0023_003DzT9FKzIScBAOG8B2oDuQfqdQOuGEv;
				}
				if (_0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe == -2087924573 + num - num2)
				{
					value = new string(new char[3]
					{
						(char)(-2071076575 ^ num ^ num2),
						'0',
						(char)(1429071571 + num + num2)
					});
					return value;
				}
				int num15 = _0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t ^ (-1347556959 - num - num2) ^ num5;
				num15 ^= (-1676861209 ^ num) + num2;
				_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzuxB0JN6F87OueOjv0EiN8ZGZAXs7().Position = num15;
				if (_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei != null)
				{
					array = _0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei;
				}
				else
				{
					short num16 = ((_0023_003DzL9a7XFhvKCfNYLDx893x15XQhPLc != -1) ? _0023_003DzL9a7XFhvKCfNYLDx893x15XQhPLc : ((short)(_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzbrKlhC_xk5DYPdNCcabAbaF3Anjn() ^ ((-1429066920 - num) ^ num2) ^ num15)));
					if (num16 == 0)
					{
						array = null;
					}
					else
					{
						array = _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzzGgLm_JpB_rbvkKOWt85qbA_003D(num16);
						for (int i = 0; i != array.Length; i++)
						{
							array[i] ^= (byte)(_0023_003DzT9FKzIScBAOG8B2oDuQfqdQOuGEv >> ((3 & i) << 3));
						}
					}
				}
				num17 = _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzC5Ue3NVwjFhnh9rXIV6qmdw_003D() ^ num15 ^ -(~(-(~(-(~(~(-(~(-(~((num ^ 0x62443CEE) + num2))))))))))) ^ num5;
				if (num17 == num + -2087968537 - num2)
				{
					byte[] array2 = _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzzGgLm_JpB_rbvkKOWt85qbA_003D(4);
					_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t = (1935540544 - num + num2) ^ num5;
					_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t;
					goto IL_0013;
				}
				num18 = _0023_003DzhqgL2uS6VHPPAHz0an_uQqjlSEQe;
				num19 = -2070582785 ^ num ^ num2;
				num20 = num18 - 12;
				num21 = num17;
				num17 &= num + 1697506938 + num2;
				array3 = _0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003DzzGgLm_JpB_rbvkKOWt85qbA_003D(num17);
				array4 = _0023_003Dz_0024vhQsYzmZN6_mF2CzZzjoRLOICHE;
			}
			break;
			IL_0013:
			if (_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS.TryGetValue(_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t, out value))
			{
				return value;
			}
		}
		bool flag = (num21 & (-355329659 - num - num2)) != 0;
		bool flag2 = (num21 & (num ^ 0x48DE179 ^ num2)) != 0;
		bool flag3 = (num21 & (-1670127849 - num + num2)) != 0;
		byte[] array5 = array;
		byte[] array6 = array3;
		byte[] array7 = array5;
		uint num22 = 0u;
		int num23 = 0;
		ushort num24 = 0;
		byte b = 0;
		byte b2 = 0;
		byte b3 = 0;
		int num25 = 0;
		byte b4 = 0;
		b4 = array7[1];
		num25 = array6.Length;
		b3 = (byte)((11 + num25) ^ (7 + b4));
		num22 = (uint)((array7[0] | (array7[2] << 8)) + (b3 << 3));
		num24 = 0;
		num23 = 0;
		while (num23 < num25)
		{
			if ((num23 & 1) == 0)
			{
				num22 = (uint)((int)num22 * ((-2088148356 + num) ^ num2) + (-1426540472 - num - num2));
				num24 = (ushort)(num22 >> 16);
			}
			b2 = (byte)num24;
			num24 >>= 8;
			b = array6[num23];
			array6[num23] = (byte)(b ^ b4 ^ (3 + b3) ^ b2);
			num23++;
			b3 = b;
		}
		array3 = array6;
		if (array4 != null != (num19 != num18))
		{
			for (int j = 0; j < num17; j++)
			{
				byte b5 = array4[j & 7];
				b5 = (byte)((b5 << 3) | (b5 >> 5));
				array3[j] ^= b5;
			}
		}
		byte[] array8;
		int num26;
		if (!flag2)
		{
			array8 = array3;
			num26 = num17;
		}
		else
		{
			num26 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
			array8 = new byte[num26];
			_0023_003DzHeoKeEgUqUj0ek8bAPNf7HOzW5JY(array3, 4, array8);
		}
		if (flag && num20 == num19 - 12)
		{
			char[] array9 = new char[num26];
			for (int k = 0; k < num26; k++)
			{
				array9[k] = (char)array8[k];
			}
			value = new string(array9);
		}
		else
		{
			char[] array10 = new char[num26 / 2];
			int l = 0;
			int num27 = 0;
			for (; l < num26; l += 2)
			{
				array10[num27++] = (char)(array8[l] | (array8[1 + l] << 8));
			}
			value = new string(array10);
		}
		num20 += (-2071076602 ^ num ^ num2) + (num20 & 3) << 5;
		if (num20 != num19 - 12 + (2087968662 - num + num2 + ((num19 - 12) & 3) << 5))
		{
			int num28 = (num17 + _0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t) ^ (num ^ -2071745791 ^ num2) ^ (num20 & (2087969828 - num + num2));
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = num + -2087968447 - num2;
			stringBuilder.Append((char)(byte)num3);
			value = num28.ToString(stringBuilder.ToString());
		}
		if (!flag3 && _0023_003DzhLWBf0iQ01bxE1aeZvaVvCl6HhjT)
		{
			value = string.Intern(value);
			_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS[_0023_003DzLlaZfQ_0024bVDdsrxhurO1ZZVlO7z1t] = value;
			if (_0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS.Count == ((-1429071783 - num) ^ num2))
			{
				bool lockTaken = false;
				ConcurrentDictionary<int, string> obj = _0023_003Dzhi6FXkI__00247Ss6R6ehaJyLy6IYADS;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS != null)
					{
						_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS._0023_003Dz_00245HP46Yx4MoYF8RQvLPm40xrvPgA();
						_0023_003DzakV5o_0T7Mch7vknTjUMUZY_uQjS = null;
						_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei = null;
						_0023_003Dz_0024vhQsYzmZN6_mF2CzZzjoRLOICHE = null;
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
		}
		return value;
	}

	private static AssemblyName _0023_003DzNLB4dedvig9WEymq37aZU_00245MVtao(Assembly _0023_003DzRgCE10tasbrCMOk_NOekCjsNuNUD)
	{
		try
		{
			return _0023_003DzRgCE10tasbrCMOk_NOekCjsNuNUD.GetName();
		}
		catch
		{
			return new AssemblyName(_0023_003DzRgCE10tasbrCMOk_NOekCjsNuNUD.FullName);
		}
	}

	private static byte[] _0023_003Dz3fwJG9uDhbetAfu_cx11cqrVQDZe(AssemblyName _0023_003DzS4SXI_58ysRMAI9OTsNCGXITrjqE)
	{
		byte[] array = _0023_003DzS4SXI_58ysRMAI9OTsNCGXITrjqE.GetPublicKeyToken();
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		return array;
	}

	private static void _0023_003DzHeoKeEgUqUj0ek8bAPNf7HOzW5JY(byte[] _0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0, int _0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU, byte[] _0023_003DzIglhIvhNzk6KXNyAxNsQ6VE2nm7t)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = _0023_003DzIglhIvhNzk6KXNyAxNsQ6VE2nm7t.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0[_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0[_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU] >> 2) + 3;
				int num6 = ((_0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0[_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU] << 8) | _0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0[_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU + 1]) & 0x3FF;
				_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0023_003DzIglhIvhNzk6KXNyAxNsQ6VE2nm7t[num++] = _0023_003DzIglhIvhNzk6KXNyAxNsQ6VE2nm7t[num7++];
				}
			}
			else
			{
				_0023_003DzIglhIvhNzk6KXNyAxNsQ6VE2nm7t[num++] = _0023_003Dzty_0024ECiboqMkzf6YcRKPWj0sjhjD0[_0023_003DzDSqXKQ3B4aS_k4WAHCK7zJ1_BFrU++];
			}
		}
	}
}
