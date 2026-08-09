using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

internal static class _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh
{
	private sealed class _0023_003Dz9CZItq3lpV7RBWHLvx8vD43lcQBt
	{
		private Stream _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E;

		private byte[] _0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2;

		public _0023_003Dz9CZItq3lpV7RBWHLvx8vD43lcQBt(Stream _0023_003Dz4jufzZA5AVOngJtOOqbxHyirKkWw)
		{
			_0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E = _0023_003Dz4jufzZA5AVOngJtOOqbxHyirKkWw;
			_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2 = new byte[4];
		}

		public Stream _0023_003DzVbB5zgzjUJmlffSvGV2iTTMCiQ6Q()
		{
			return _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E;
		}

		public short _0023_003Dz92XEmDsMI3BXfzPH_0024cD1QozGfI_0024y()
		{
			_0023_003Dz8bzwnhsWmsZH71sqzG6xifI_003D(2);
			return (short)(_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[0] | (_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[1] << 8));
		}

		public int _0023_003Dzv8abtNguUeHqs_0024pvUBsLzdo_003D()
		{
			_0023_003Dz8bzwnhsWmsZH71sqzG6xifI_003D(4);
			return _0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[0] | (_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[1] << 8) | (_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[2] << 16) | (_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[3] << 24);
		}

		private static void _0023_003DzZdLHfancXC_SD0cH6MD_VbnPR60v()
		{
			throw new EndOfStreamException();
		}

		private void _0023_003Dz8bzwnhsWmsZH71sqzG6xifI_003D(int _0023_003DzGcI_FGD8F_5Bofok2409JS1FgmSM)
		{
			int num = 0;
			int num2 = 0;
			if (_0023_003DzGcI_FGD8F_5Bofok2409JS1FgmSM == 1)
			{
				num2 = _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E.ReadByte();
				if (num2 == -1)
				{
					_0023_003DzZdLHfancXC_SD0cH6MD_VbnPR60v();
				}
				_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E.Read(_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2, num, _0023_003DzGcI_FGD8F_5Bofok2409JS1FgmSM - num);
				if (num2 == 0)
				{
					_0023_003DzZdLHfancXC_SD0cH6MD_VbnPR60v();
				}
				num += num2;
			}
			while (num < _0023_003DzGcI_FGD8F_5Bofok2409JS1FgmSM);
		}

		public void _0023_003Dz7FBLy4r_x3s3iOjMXBQFOJC_0024M6u6()
		{
			Stream stream = _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E;
			_0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E = null;
			stream?.Close();
			_0023_003DziecwuMhtJX9S5ohC21T7jzPLClG2 = null;
		}

		public byte[] _0023_003Dzwq6JHTaYSq71UM1SKeh_0024Htk_003D(int _0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w)
		{
			if (_0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w];
			int num = 0;
			do
			{
				int num2 = _0023_003DzI8vpSpmkADVacSG_PVBurxXuRt2E.Read(array, num, _0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				_0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w -= num2;
			}
			while (_0023_003DzjY3fWETW1E3YkZrAFQdDo6D7ot6w > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	private enum _0023_003DzO2xCrWTDH4l3TZjPpicseag3qQku
	{

	}

	private static byte[] _0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei;

	private static ConcurrentDictionary<int, string> _0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg;

	private static byte[] _0023_003Dzdq_0024P86WEoGZzEv3F9Ef2LUu6FK8U;

	private static int _0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7;

	private static int _0023_003DzrkPPSaaZ_00249YBhz3WbVkAkyjq_0024C0e;

	private static _0023_003Dz9CZItq3lpV7RBWHLvx8vD43lcQBt _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW;

	private static short _0023_003DzgqYLqlpOPcO7Nu3MO0bmHhRtC5_0024n;

	private static _0023_003DzO2xCrWTDH4l3TZjPpicseag3qQku _0023_003DzcIWm7eMqGLymrnndv7OVNCATSokq;

	private static int _0023_003Dz4ZcFEaDt_7QHs7krVsLTzDX6qUAU;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh()
	{
		int num = -589823128;
		int num2 = 0x7126B785 ^ num;
		_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg = new ConcurrentDictionary<int, string>();
		_0023_003Dz4ZcFEaDt_7QHs7krVsLTzDX6qUAU += -(~(~(-(-(~(-(~(~((1522628329 + num) ^ num2)))))))));
		_0023_003DzcIWm7eMqGLymrnndv7OVNCATSokq = (_0023_003DzO2xCrWTDH4l3TZjPpicseag3qQku)16 | _0023_003DzcIWm7eMqGLymrnndv7OVNCATSokq;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0023_003DzE8QrneA_003D(int _0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE)
	{
		if (_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg.TryGetValue(_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE, out var value))
		{
			return value;
		}
		return _0023_003Dz8d8PzxsJ1qaCMu4EqoyiWrA_003D(_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE, _0023_003Dzvil2Y31WnFE07rtcNQe0rCt0mAWd: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string _0023_003Dz8d8PzxsJ1qaCMu4EqoyiWrA_003D(int _0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE, bool _0023_003Dzvil2Y31WnFE07rtcNQe0rCt0mAWd)
	{
		int num = 1006421943;
		int num2 = num + 294180178;
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
			lock (_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg)
			{
				int num5;
				if (_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW == null)
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
					_0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7 |= -292569808 - num + num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = (num + -37487230) ^ num2;
					stringBuilder.Append((char)(byte)num3).Append((char)(byte)(num3 >> 24)).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = -1177963020 - num - num2;
					stringBuilder.Append((char)(byte)(num3 >> 24)).Append((char)(byte)num3).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = num + 1987943301 + num2;
					stringBuilder.Append((char)(byte)num3);
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW = new _0023_003Dz9CZItq3lpV7RBWHLvx8vD43lcQBt(manifestResourceStream);
					short num4 = (short)(_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dz92XEmDsMI3BXfzPH_0024cD1QozGfI_0024y() ^ (short)(-(~(~(-(~(-(~(-(~((0x7679E43B ^ num) - num2)))))))))));
					if (num4 == 0)
					{
						_0023_003DzgqYLqlpOPcO7Nu3MO0bmHhRtC5_0024n = (short)(_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dz92XEmDsMI3BXfzPH_0024cD1QozGfI_0024y() ^ (short)(-(~(~(-(-(~(-(~(-(~(~((num + 294179984) ^ num2)))))))))))));
					}
					else
					{
						_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei = _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dzwq6JHTaYSq71UM1SKeh_0024Htk_003D(num4);
					}
					callingAssembly = executingAssembly;
					AssemblyName _0023_003DzBMzZtvcfdvvyUYIBNi0iBWrpw5Bl = _0023_003Dz5cVOuQ95AGQZ7QCFxI6shP0QgMM5(callingAssembly);
					_0023_003Dzdq_0024P86WEoGZzEv3F9Ef2LUu6FK8U = _0023_003DzX62rS1oiQt5rcNujFkzKRsLcf_002485(_0023_003DzBMzZtvcfdvvyUYIBNi0iBWrpw5Bl);
					num5 = _0023_003Dz4ZcFEaDt_7QHs7krVsLTzDX6qUAU;
					num5 ^= 590037735 - num + num2;
					_0023_003Dz4ZcFEaDt_7QHs7krVsLTzDX6qUAU = 0;
					long num6 = _0023_003DzYCKXTZQlebGSmVlt0a2mzopploz1._0023_003DzE8QrneA_003D();
					num5 ^= (int)num6;
					num5 ^= (-398387779 + num) ^ num2;
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					int num10 = num5;
					global::_0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D<int> _0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2 = null;
					num9 = num10;
					int num11 = 0;
					int num12 = 0;
					int num13 = 0;
					num11 = 0;
					num12 = (1704198089 - num - num2) ^ num9;
					_0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2 = null;
					num8 = num12;
					num11 = num ^ 0x76795ACB ^ num2;
					num13 = 0;
					_0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2 = ((global::_0023_003DzGaGCq803zlpROmYrcAX7Hny_RomteZj7Sg_003D_003D<int>)new _0023_003DzVvbpYwN10k2uiaqfGvO5g9neZyNQWwL6uQ_003D_003D._0023_003DzAvn2b38_003D(-294180180 - num + num2)
					{
						_0023_003DzmQTFaQA_003D = num8
					}).GetEnumerator();
					try
					{
						while (_0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2._0023_003DzKaw26Jpi7A801T9KVFoes0MSU6K8mKC_0024lH5s_0024JHXOhCwLuAdd6iMBHpWWF0eJp7SYdcLoEk_003D())
						{
							num13 = _0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2._0023_003Dz9Qi6yiWJTjR82fb1tLS_00243oeapdTjq_cmi_0024p1G2UnPoSsbwy3tG_egse2qXcMfTmo0b5Z0eBEGGHU();
							num12 ^= num13 - num11;
							num11 -= num12 + 3 >> 8;
						}
					}
					finally
					{
						_0023_003DzbhhBMjOeZ_0024a69vT5PVxhwlzioZnXpklOIA_003D_003D2?._0023_003DzKD_0024bhmWErv51A_Zdgx4zCwWFLbN5ON0_cvSg_0024sQXWm5koiMTktwIS0R_0024pfVHoW_svYJhU_DDDDih();
					}
					num7 = num12;
					int num14 = num7 * ((num ^ 0x76797601) - num2) % ((-2011195237 - num) ^ num2);
					num5 ^= num + 294895236 - num2 + -(~(-(~(~(-(-(~(~((-294179971 - num) ^ num2)))))))));
					num5 ^= ~(-(-(~(~(-(-(~(~(-(~(1793612513 + num + num2)))))))))));
					num5 = num14 + num5;
					_0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7 = (_0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7 & ((0x66795BCC ^ num) - num2)) ^ ((294174678 + num) ^ num2);
					_0023_003DzrkPPSaaZ_00249YBhz3WbVkAkyjq_0024C0e = num5;
					if (((uint)_0023_003DzcIWm7eMqGLymrnndv7OVNCATSokq & (uint)(-(~(-(~(~(-(-(~(-(~(~((num ^ -1987664546) + num2))))))))))))) == 0)
					{
						_0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7 = (-1987969430 - num) ^ num2;
					}
				}
				else
				{
					num5 = _0023_003DzrkPPSaaZ_00249YBhz3WbVkAkyjq_0024C0e;
				}
				if (_0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7 == (num ^ -1987589882) + num2)
				{
					value = new string(new char[3]
					{
						(char)((-1987943160 - num) ^ num2),
						'0',
						(char)(num + 1987943320 + num2)
					});
					return value;
				}
				int num15 = _0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE ^ (num ^ 0x2E5587EC ^ num2) ^ num5;
				num15 ^= num + -1654876896 + num2;
				_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003DzVbB5zgzjUJmlffSvGV2iTTMCiQ6Q().Position = num15;
				if (_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei != null)
				{
					array = _0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei;
				}
				else
				{
					short num16 = ((_0023_003DzgqYLqlpOPcO7Nu3MO0bmHhRtC5_0024n != -1) ? _0023_003DzgqYLqlpOPcO7Nu3MO0bmHhRtC5_0024n : ((short)(_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dz92XEmDsMI3BXfzPH_0024cD1QozGfI_0024y() ^ (num ^ -1987655235 ^ num2) ^ num15)));
					if (num16 == 0)
					{
						array = null;
					}
					else
					{
						array = _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dzwq6JHTaYSq71UM1SKeh_0024Htk_003D(num16);
						for (int num17 = 0; num17 != array.Length; num17 = 1 + num17)
						{
							array[num17] ^= (byte)(_0023_003DzrkPPSaaZ_00249YBhz3WbVkAkyjq_0024C0e >> ((3 & num17) << 3));
						}
					}
				}
				num18 = _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dzv8abtNguUeHqs_0024pvUBsLzdo_003D() ^ num15 ^ -(~(~(-(~(-(~(-(~(-268311238 + num + num2))))))))) ^ num5;
				if (num18 == -1987943234 - num - num2)
				{
					byte[] array2 = _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dzwq6JHTaYSq71UM1SKeh_0024Htk_003D(4);
					_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE = ((0x30ADF4D ^ num) + num2) ^ num5;
					_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE;
					goto IL_0013;
				}
				num19 = _0023_003Dz4FKxX3Gej31lwyhZNNhPuXiUOYk7;
				num20 = num + 295787992 - num2;
				num21 = num19 - 12;
				num22 = num18;
				num18 &= (2121738925 - num) ^ num2;
				array3 = _0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dzwq6JHTaYSq71UM1SKeh_0024Htk_003D(num18);
				array4 = _0023_003Dzdq_0024P86WEoGZzEv3F9Ef2LUu6FK8U;
			}
			break;
			IL_0013:
			if (_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg.TryGetValue(_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE, out value))
			{
				return value;
			}
		}
		bool flag = (num22 & ((-1233560898 ^ num) - num2)) != 0;
		bool flag2 = (num22 & ((-1853303470 + num) ^ num2)) != 0;
		bool flag3 = (num22 & (242690734 - num + num2)) != 0;
		byte[] array5 = array;
		byte[] array6 = array3;
		byte[] array7 = array5;
		int num23 = 0;
		ushort num24 = 0;
		byte b = 0;
		byte b2 = 0;
		byte b3 = 0;
		byte b4 = 0;
		int num25 = 0;
		uint num26 = 0u;
		b3 = array7[1];
		num23 = array6.Length;
		b4 = (byte)((11 + num23) ^ (b3 + 7));
		num26 = (uint)((array7[0] | (array7[2] << 8)) + (b4 << 3));
		num25 = 0;
		num24 = 0;
		for (; num25 < num23; num25++)
		{
			if ((1 & num25) == 0)
			{
				num26 = (uint)((int)num26 * ((num + 294262589) ^ num2) + (-291649167 - num + num2));
				num24 = (ushort)(num26 >> 16);
			}
			b = (byte)num24;
			num24 >>= 8;
			b2 = array6[num25];
			array6[num25] = (byte)(b2 ^ b3 ^ (b4 + 3) ^ b);
			b4 = b2;
		}
		array3 = array6;
		if (array4 != null != (num20 != num19))
		{
			for (int num27 = 0; num27 < num18; num27 = 1 + num27)
			{
				byte b5 = array4[num27 & 7];
				b5 = (byte)((b5 << 3) | (b5 >> 5));
				array3[num27] ^= b5;
			}
		}
		byte[] array8;
		int num28;
		if (!flag2)
		{
			array8 = array3;
			num28 = num18;
		}
		else
		{
			num28 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
			array8 = new byte[num28];
			_0023_003Dz5568yqW_0024_EPTUsDTUQdKF9luwwW5(array3, 4, array8);
		}
		if (flag && num21 == num20 - 12)
		{
			char[] array9 = new char[num28];
			for (int num29 = 0; num29 < num28; num29 = 1 + num29)
			{
				array9[num29] = (char)array8[num29];
			}
			value = new string(array9);
		}
		else
		{
			char[] array10 = new char[num28 / 2];
			int num30 = 0;
			int num31 = 0;
			while (num30 < num28)
			{
				array10[num31++] = (char)(array8[num30] | (array8[1 + num30] << 8));
				num30 = 2 + num30;
			}
			value = new string(array10);
		}
		num21 += (0x76795A3F ^ num) - num2 + (3 & num21) << 5;
		if (num21 != num20 - 12 + (((-1987943123 - num) ^ num2) + ((num20 - 12) & 3) << 5))
		{
			int num32 = (num18 + _0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE) ^ ((0x766F2036 ^ num) - num2) ^ (num21 & ((-1987944517 - num) ^ num2));
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = (num ^ 0x76795AD6) - num2;
			stringBuilder.Append((char)(byte)num3);
			value = num32.ToString(stringBuilder.ToString());
		}
		if (!flag3 && _0023_003Dzvil2Y31WnFE07rtcNQe0rCt0mAWd)
		{
			value = string.Intern(value);
			_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg[_0023_003DziHvgOA7wzkuhOtXq1gVI21agOwjE] = value;
			if (_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg.Count == ((-1987941408 - num) ^ num2))
			{
				lock (_0023_003Dz7RSvif9Pj_0024_wQ4XAvVFOJ6b_0024Fubg)
				{
					if (_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW != null)
					{
						_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW._0023_003Dz7FBLy4r_x3s3iOjMXBQFOJC_0024M6u6();
						_0023_003DziEJWGW_6eJyeyefIdgmxNA0gfdaW = null;
						_0023_003DzOq83c0J1W5slmCrMmz9wMm_00243pRei = null;
						_0023_003Dzdq_0024P86WEoGZzEv3F9Ef2LUu6FK8U = null;
					}
				}
			}
		}
		return value;
	}

	private static AssemblyName _0023_003Dz5cVOuQ95AGQZ7QCFxI6shP0QgMM5(Assembly _0023_003DzItRqgNnhuHZgdSvwag6fTU9GvOSE)
	{
		try
		{
			return _0023_003DzItRqgNnhuHZgdSvwag6fTU9GvOSE.GetName();
		}
		catch
		{
			return new AssemblyName(_0023_003DzItRqgNnhuHZgdSvwag6fTU9GvOSE.FullName);
		}
	}

	private static byte[] _0023_003DzX62rS1oiQt5rcNujFkzKRsLcf_002485(AssemblyName _0023_003DzBMzZtvcfdvvyUYIBNi0iBWrpw5Bl)
	{
		byte[] array = _0023_003DzBMzZtvcfdvvyUYIBNi0iBWrpw5Bl.GetPublicKeyToken();
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		return array;
	}

	private static void _0023_003Dz5568yqW_0024_EPTUsDTUQdKF9luwwW5(byte[] _0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN, int _0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys, byte[] _0023_003Dzo4ElPgrYwA6YsWEbZqDiDa0_0024QdQE)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = _0023_003Dzo4ElPgrYwA6YsWEbZqDiDa0_0024QdQE.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN[_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN[_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys] >> 2) + 3;
				int num6 = ((_0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN[_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys] << 8) | _0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN[_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys + 1]) & 0x3FF;
				_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0023_003Dzo4ElPgrYwA6YsWEbZqDiDa0_0024QdQE[num++] = _0023_003Dzo4ElPgrYwA6YsWEbZqDiDa0_0024QdQE[num7++];
				}
			}
			else
			{
				_0023_003Dzo4ElPgrYwA6YsWEbZqDiDa0_0024QdQE[num++] = _0023_003Dzk7GdASWg1QS5N5qUyDnSj2IUs4vN[_0023_003Dz0EzMYl_Y8j4t4icTU3QYQxVuthys++];
			}
		}
	}
}
