using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

internal static class _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4
{
	private sealed class _0023_003Dz1IfzPqHBjIj4JMzIggy2UPVvtH7i
	{
		private Stream _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024;

		private byte[] _0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp;

		public _0023_003Dz1IfzPqHBjIj4JMzIggy2UPVvtH7i(Stream _0023_003Dz3oFhDKoPcHYHRzNl4eKrysOCzTZp)
		{
			_0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024 = _0023_003Dz3oFhDKoPcHYHRzNl4eKrysOCzTZp;
			_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp = new byte[4];
		}

		public Stream _0023_003Dz8E7XitH6jB835uOamEZNZpOFuY97()
		{
			return _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024;
		}

		public short _0023_003DzRQNcdF19o1aULFeADaDy67v2AmyB()
		{
			_0023_003DzD5QhyfZIpFwb4pXV6HbYcEk_003D(2);
			return (short)(_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[0] | (_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[1] << 8));
		}

		public int _0023_003DzU1ggUotGG08j_QQkqxmy3Vc_003D()
		{
			_0023_003DzD5QhyfZIpFwb4pXV6HbYcEk_003D(4);
			return _0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[0] | (_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[1] << 8) | (_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[2] << 16) | (_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[3] << 24);
		}

		private static void _0023_003DzCJ26sXAAsOeeIRH2MUDniE1XFwPX()
		{
			throw new EndOfStreamException();
		}

		private void _0023_003DzD5QhyfZIpFwb4pXV6HbYcEk_003D(int _0023_003DzQV_0024iSS3jpJSjImanADLAqdtkSd1X)
		{
			int num = 0;
			int num2 = 0;
			if (_0023_003DzQV_0024iSS3jpJSjImanADLAqdtkSd1X == 1)
			{
				num2 = _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024.ReadByte();
				if (num2 == -1)
				{
					_0023_003DzCJ26sXAAsOeeIRH2MUDniE1XFwPX();
				}
				_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024.Read(_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp, num, _0023_003DzQV_0024iSS3jpJSjImanADLAqdtkSd1X - num);
				if (num2 == 0)
				{
					_0023_003DzCJ26sXAAsOeeIRH2MUDniE1XFwPX();
				}
				num += num2;
			}
			while (num < _0023_003DzQV_0024iSS3jpJSjImanADLAqdtkSd1X);
		}

		public void _0023_003DzZlxzl5rfBJEjckDm4LLLUSIR_xtX()
		{
			Stream stream = _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024;
			_0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024 = null;
			stream?.Close();
			_0023_003DzquY0MZd46kmr9wUF8_pEDzRugREp = null;
		}

		public byte[] _0023_003DzBrYjnoAh_00247Xq2lLbxhB_0024SC4_003D(int _0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm)
		{
			if (_0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm];
			int num = 0;
			do
			{
				int num2 = _0023_003DzXYt8Y_p5tliQvVtu2u7QTYXJwKK_0024.Read(array, num, _0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				_0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm -= num2;
			}
			while (_0023_003Dz3baF2nz_0024H8yfgPXyqRVuHhYo97zm > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	private enum _0023_003DzjUqKNIiZjU6FeI912wicRJt1VbSQ
	{

	}

	private static byte[] _0023_003DzU42mUoeSjSo35UBICkSmr6zNOyLF;

	private static ConcurrentDictionary<int, string> _0023_003DztXAox3G1UcI41pFtk62icYBfxRaU;

	private static byte[] _0023_003DzDsYoH1_mRARXf0kaeTp6QGS7xdQu;

	private static int _0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg;

	private static int _0023_003Dzh0L5MHVt7xlSooDjAIuv5WG207a9;

	private static _0023_003Dz1IfzPqHBjIj4JMzIggy2UPVvtH7i _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi;

	private static short _0023_003DzFUkDHWRII3Z0gXhYhoDoxCVQBDFO;

	private static _0023_003DzjUqKNIiZjU6FeI912wicRJt1VbSQ _0023_003Dz67WmnKcmQSF3W2t0l42T6zceoYrZ;

	private static int _0023_003DzmPSeZublv9KPpOZuV22QRfPhH_0024Gp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4()
	{
		int num = -533125455;
		int num2 = 0x57C41FE6 ^ num;
		_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU = new ConcurrentDictionary<int, string>();
		_0023_003DzmPSeZublv9KPpOZuV22QRfPhH_0024Gp += -(~(~(-(-(~(-(~(-(~(~(1291288757 - num + num2)))))))))));
		_0023_003Dz67WmnKcmQSF3W2t0l42T6zceoYrZ |= (_0023_003DzjUqKNIiZjU6FeI912wicRJt1VbSQ)16;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0023_003DzDw__wI8_003D(int _0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom)
	{
		if (_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU.TryGetValue(_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom, out var value))
		{
			return value;
		}
		return _0023_003Dzn16EKOolkO7z5cupziJDsoE_003D(_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom, _0023_003DzAAXP7wYpV3QTDf6Kp0_0024HOD2P_NEu: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string _0023_003Dzn16EKOolkO7z5cupziJDsoE_003D(int _0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom, bool _0023_003DzAAXP7wYpV3QTDf6Kp0_0024HOD2P_NEu)
	{
		int num = -1465369013;
		int num2 = -1839783621 - num;
		string value = null;
		byte[] array;
		int num18;
		int num19;
		int num20;
		int num21;
		byte[] array4;
		byte[] array3;
		int num22;
		while (true)
		{
			lock (_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU)
			{
				int num5;
				if (_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi == null)
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
					_0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg |= 1841393991 + num + num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = -89748608 - num - num2;
					stringBuilder.Append((char)(byte)num3).Append((char)(byte)(num3 >> 24)).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = (-904417841 ^ num) + num2;
					stringBuilder.Append((char)(byte)(num3 >> 24)).Append((char)(byte)num3).Append((char)(byte)(num3 >> 16))
						.Append((char)(byte)(num3 >> 8));
					num3 = (1090954317 + num) ^ num2;
					stringBuilder.Append((char)(byte)num3);
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi = new _0023_003Dz1IfzPqHBjIj4JMzIggy2UPVvtH7i(manifestResourceStream);
					short num4 = (short)(_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzRQNcdF19o1aULFeADaDy67v2AmyB() ^ (short)(-(~(-(~(~(-(-(~(-(~(~((0x4107011E ^ num) - num2)))))))))))));
					if (num4 == 0)
					{
						_0023_003DzFUkDHWRII3Z0gXhYhoDoxCVQBDFO = (short)(_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzRQNcdF19o1aULFeADaDy67v2AmyB() ^ (short)(~(-(~(-(-(~(~(-(~((1090949212 + num) ^ num2)))))))))));
					}
					else
					{
						_0023_003DzU42mUoeSjSo35UBICkSmr6zNOyLF = _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzBrYjnoAh_00247Xq2lLbxhB_0024SC4_003D(num4);
					}
					callingAssembly = executingAssembly;
					AssemblyName _0023_003DzOK83kWyuM8rq7hxi_1Rs18Vj1DtN = _0023_003DzOOsmf6C7FHuu_0024hWMKR6ELrdQnVSa(callingAssembly);
					_0023_003DzDsYoH1_mRARXf0kaeTp6QGS7xdQu = _0023_003Dz1TfIab9wJ3dMg2Y3uSiXODVX85_C(_0023_003DzOK83kWyuM8rq7hxi_1Rs18Vj1DtN);
					num5 = _0023_003DzmPSeZublv9KPpOZuV22QRfPhH_0024Gp;
					num5 ^= -206736492 - num + num2;
					_0023_003DzmPSeZublv9KPpOZuV22QRfPhH_0024Gp = 0;
					long num6 = _0023_003DzFIfdRy030CZPLe1923s0NXj3psgi._0023_003DzDw__wI8_003D();
					num5 ^= (int)num6;
					num5 ^= num ^ 0x28BE9CC6 ^ num2;
					int num7 = 0;
					int num8 = num5;
					int num9 = 0;
					int num10 = 0;
					global::_0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D<int> _0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2 = null;
					num9 = num8;
					int num11 = 0;
					int num12 = 0;
					int num13 = 0;
					num11 = 0;
					num13 = (1852357700 - num - num2) ^ num9;
					_0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2 = null;
					num12 = 0;
					num11 = 0x4106DCCE ^ num ^ num2;
					num10 = num13;
					_0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2 = ((global::_0023_003Dz5If6inyENVFvJG4JJZmHH0CPOVDw_6h6Pw_003D_003D<int>)new _0023_003DzuVtOgPoaxY2C4lDE8UuFvTjZ0e_0024Bs4UShw_003D_003D._0023_003DzwBouG0w_003D((num + 1839783619) | num2)
					{
						_0023_003DzTFNDoh0_003D = num10
					}).GetEnumerator();
					try
					{
						while (_0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2._0023_003Dz1N5zmqMVJa5a7895tScaS9F5kEOPBLpaIbgOntO_up_0024mJ_0024rlGRppuG3kjTVDcrpFFdux9e0_003D())
						{
							num12 = _0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2._0023_003DzbWTro8Ofp6GfrsLs5918L0W1PZLNIPA2tbg00hkwaERjF4ERuGpVpe8tDmvoeZ8Igwj65WVhFWv_();
							num13 ^= num12 - num11;
							num11 -= 3 + num13 >> 8;
						}
					}
					finally
					{
						_0023_003DzNLH1VGyzsIpHjLd7VjjTXLjTut_XyK6scQ_003D_003D2?._0023_003DzWLE4Xs3tCKCOH7MyZwn4AwoGeDv1ikzZX89NeXEfaoEJmMbKRW29WRKN_0024Fg0xWJPEwg0dgvcfPaQ();
					}
					num7 = num13;
					num5 ^= -1839068563 - num - num2 + -(~(~(-(~(-(~(-(~((1839783408 + num) ^ num2)))))))));
					int num14 = num7 * (-1839778328 - num - num2) % ((1063350482 + num) ^ num2);
					num5 ^= -(~(~(-(-(~(-(~(~(-(~((num ^ -761707356) - num2)))))))))));
					num5 += num14;
					_0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg = (_0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg & (-822519091 - num + num2)) ^ (num ^ 0x4106C63F ^ num2);
					_0023_003Dzh0L5MHVt7xlSooDjAIuv5WG207a9 = num5;
					if (((uint)_0023_003Dz67WmnKcmQSF3W2t0l42T6zceoYrZ & (uint)(-(~(~(-(~(-(~(-(-(~(~(-1839783639 - num - num2))))))))))))) == 0)
					{
						_0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg = 1839827583 + num + num2;
					}
				}
				else
				{
					num5 = _0023_003Dzh0L5MHVt7xlSooDjAIuv5WG207a9;
				}
				if (_0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg == (0x41067701 ^ num ^ num2))
				{
					value = new string(new char[3]
					{
						(char)(num + 1090954493 - num2),
						'0',
						(char)(num ^ 0x4106DCE3 ^ num2)
					});
					return value;
				}
				int num15 = _0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom ^ (1199673897 + num - num2) ^ num5;
				num15 ^= -438807237 - num + num2;
				_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003Dz8E7XitH6jB835uOamEZNZpOFuY97().Position = num15;
				if (_0023_003DzU42mUoeSjSo35UBICkSmr6zNOyLF != null)
				{
					array = _0023_003DzU42mUoeSjSo35UBICkSmr6zNOyLF;
				}
				else
				{
					short num16 = ((_0023_003DzFUkDHWRII3Z0gXhYhoDoxCVQBDFO != -1) ? _0023_003DzFUkDHWRII3Z0gXhYhoDoxCVQBDFO : ((short)(_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzRQNcdF19o1aULFeADaDy67v2AmyB() ^ ((0x4107758B ^ num) - num2) ^ num15)));
					if (num16 == 0)
					{
						array = null;
					}
					else
					{
						array = _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzBrYjnoAh_00247Xq2lLbxhB_0024SC4_003D(num16);
						for (int num17 = 0; num17 != array.Length; num17 = 1 + num17)
						{
							array[num17] ^= (byte)(_0023_003Dzh0L5MHVt7xlSooDjAIuv5WG207a9 >> ((3 & num17) << 3));
						}
					}
				}
				num18 = _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzU1ggUotGG08j_QQkqxmy3Vc_003D() ^ num15 ^ -(~(-(~(~(-(-(~(-(~(~((309742118 - num) ^ num2))))))))))) ^ num5;
				if (num18 == ((-1090968763 ^ num) | num2))
				{
					byte[] array2 = _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzBrYjnoAh_00247Xq2lLbxhB_0024SC4_003D(4);
					_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom = (1050178098 - num + num2) ^ num5;
					_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom;
					goto IL_0013;
				}
				num19 = (num ^ 0x416F553D) - num2;
				num20 = _0023_003DzbT0H2msWyGJxARpbo8CYo8J8HUcg;
				num21 = num18;
				num22 = num20 - 12;
				num18 &= num + 2108219076 + num2;
				array3 = _0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzBrYjnoAh_00247Xq2lLbxhB_0024SC4_003D(num18);
				array4 = _0023_003DzDsYoH1_mRARXf0kaeTp6QGS7xdQu;
			}
			break;
			IL_0013:
			if (_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU.TryGetValue(_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom, out value))
			{
				return value;
			}
		}
		bool flag = (num21 & (-766041797 - num - num2)) != 0;
		bool flag2 = (num21 & ((num ^ 0x3EF9235B) + num2)) != 0;
		bool flag3 = (num21 & ((1918312763 - num) ^ num2)) != 0;
		byte[] array5 = array;
		byte[] array6 = array3;
		byte[] array7 = array5;
		uint num23 = 0u;
		byte b = 0;
		ushort num24 = 0;
		int num25 = 0;
		byte b2 = 0;
		byte b3 = 0;
		int num26 = 0;
		byte b4 = 0;
		b3 = array7[1];
		num25 = array6.Length;
		b = (byte)((11 + num25) ^ (b3 + 7));
		num23 = (uint)((array7[0] | (array7[2] << 8)) + (b << 3));
		num26 = 0;
		num24 = 0;
		while (num26 < num25)
		{
			if ((1 & num26) == 0)
			{
				num23 = (uint)((int)num23 * ((num ^ -1090756794) + num2) + ((-1842300290 - num) ^ num2));
				num24 = (ushort)(num23 >> 16);
			}
			b2 = (byte)num24;
			num24 >>= 8;
			b4 = array6[num26];
			array6[num26] = (byte)(b3 ^ b4 ^ (b + 3) ^ b2);
			b = b4;
			num26 = 1 + num26;
		}
		array3 = array6;
		if (array4 != null != (num19 != num20))
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
			_0023_003DzzAHc5ZbeGmkGboAXsGoWiaSRBxQt(array3, 4, array8);
		}
		if (flag && num22 == num19 - 12)
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
			for (int num31 = 0; num31 < num28; num31 = 2 + num31)
			{
				array10[num30++] = (char)(array8[num31] | (array8[1 + num31] << 8));
			}
			value = new string(array10);
		}
		num22 += num + 1090954532 - num2 + (3 & num22) << 5;
		if (num22 != num19 - 12 + (-1090954278 - num + num2 + ((num19 - 12) & 3) << 5))
		{
			int num32 = (_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom + num18) ^ ((num + 1090021949) ^ num2) ^ (num22 & (-1839782328 - num - num2));
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = (num ^ -1090968797) + num2;
			stringBuilder.Append((char)(byte)num3);
			value = num32.ToString(stringBuilder.ToString());
		}
		if (!flag3 && _0023_003DzAAXP7wYpV3QTDf6Kp0_0024HOD2P_NEu)
		{
			value = string.Intern(value);
			_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU[_0023_003DzuhnWGUrRnUpEN_0uTyao618i7gom] = value;
			if (_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU.Count == ((1090954986 + num) ^ num2))
			{
				lock (_0023_003DztXAox3G1UcI41pFtk62icYBfxRaU)
				{
					if (_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi != null)
					{
						_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi._0023_003DzZlxzl5rfBJEjckDm4LLLUSIR_xtX();
						_0023_003Dz7fxZhJ4jl5jHOrr5oiJzHGvTVDYi = null;
						_0023_003DzU42mUoeSjSo35UBICkSmr6zNOyLF = null;
						_0023_003DzDsYoH1_mRARXf0kaeTp6QGS7xdQu = null;
					}
				}
			}
		}
		return value;
	}

	private static AssemblyName _0023_003DzOOsmf6C7FHuu_0024hWMKR6ELrdQnVSa(Assembly _0023_003DzqiQZ9ICrZbqq_a49_zFXjil3X065)
	{
		try
		{
			return _0023_003DzqiQZ9ICrZbqq_a49_zFXjil3X065.GetName();
		}
		catch
		{
			return new AssemblyName(_0023_003DzqiQZ9ICrZbqq_a49_zFXjil3X065.FullName);
		}
	}

	private static byte[] _0023_003Dz1TfIab9wJ3dMg2Y3uSiXODVX85_C(AssemblyName _0023_003DzOK83kWyuM8rq7hxi_1Rs18Vj1DtN)
	{
		byte[] array = _0023_003DzOK83kWyuM8rq7hxi_1Rs18Vj1DtN.GetPublicKeyToken();
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		return array;
	}

	private static void _0023_003DzzAHc5ZbeGmkGboAXsGoWiaSRBxQt(byte[] _0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls, int _0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms, byte[] _0023_003DzdtMyHAQ2EOw2Pw8_SAIAT8Iq4MDn)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = _0023_003DzdtMyHAQ2EOw2Pw8_SAIAT8Iq4MDn.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls[_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls[_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms] >> 2) + 3;
				int num6 = ((_0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls[_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms] << 8) | _0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls[_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms + 1]) & 0x3FF;
				_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0023_003DzdtMyHAQ2EOw2Pw8_SAIAT8Iq4MDn[num++] = _0023_003DzdtMyHAQ2EOw2Pw8_SAIAT8Iq4MDn[num7++];
				}
			}
			else
			{
				_0023_003DzdtMyHAQ2EOw2Pw8_SAIAT8Iq4MDn[num++] = _0023_003Dz3eMYQe8Odkznne4f4wgfLxVyL9ls[_0023_003DzyZFXot_00245a41aDpiPO18HgU7tMfms++];
			}
		}
	}
}
