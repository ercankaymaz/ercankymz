using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using _0001;
using _0005;
using _0006;
using _0007;
using _0008;
using Opaline2Cs;
using PowerNest2Cs;

namespace _0005
{
	internal class _0003
	{
		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#24")]
		static extern IntPtr _0001(int P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#307")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#17")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#46")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#43")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#100")]
		static extern IntPtr _0001();

		static _0007._0003._0004 _0001(_0007._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0003];
			Array.Copy(P_0._0002, P_0._0002, array, 0, P_0._0003);
			return new _0007._0003._0004(array);
		}

		static void _0001(byte[] P_0, _0007._0003._0004 P_1)
		{
			int[] array = new int[16];
			int[] array2 = new int[16];
			foreach (int num in P_0)
			{
				if (num > 0)
				{
					array[num]++;
				}
			}
			if (3 == 0)
			{
				goto IL_0081;
			}
			int num2 = 0;
			int num3 = 512;
			int num4 = 1;
			goto IL_00b3;
			IL_0081:
			int num7;
			int num8;
			int num9;
			int num10;
			if (num4 >= 10)
			{
				int num5 = array2[num4] & 0x1FF80;
				int num6 = num2 & 0x1FF80;
				num7 = num3;
				num8 = num6 - num5;
				num9 = 16;
				num10 = num4;
				goto IL_00a6;
			}
			goto IL_00ad;
			IL_00a6:
			int num11 = num9 - num10;
			goto IL_00a7;
			IL_00ad:
			num4++;
			goto IL_00b3;
			IL_00a7:
			num3 = num7 + (num8 >> num11);
			goto IL_00ad;
			IL_00b3:
			int num12 = num4;
			while (num12 > 15)
			{
				P_1._0001 = new short[num3];
				int num13 = 512;
				int num14 = 15;
				while (true)
				{
					if (num14 >= 10)
					{
						num7 = num2;
						num8 = 130944;
						goto IL_00d8;
					}
					int num15 = 0;
					while (true)
					{
						int num16 = num15;
						int num17;
						int num18;
						while (true)
						{
							if (num16 >= P_0.Length)
							{
								return;
							}
							if (4u != 0)
							{
								num17 = P_0[num15];
								if (num17 == 0)
								{
									break;
								}
							}
							num2 = array2[num17];
							num18 = _0001(num2);
							num16 = num17;
							if (false)
							{
								continue;
							}
							goto IL_0168;
						}
						goto IL_0203;
						IL_0203:
						num15++;
						continue;
						IL_0168:
						if (num16 <= 9)
						{
							do
							{
								P_1._0001[num18] = (short)((num15 << 4) | num17);
								num18 += 1 << num17;
							}
							while (num18 < 512);
							goto IL_01f3;
						}
						int num19 = P_1._0001[num18 & 0x1FF];
						num12 = 1;
						if (num12 == 0)
						{
							break;
						}
						int num20 = num12 << (num19 & 0xF);
						num19 = -(num19 >> 4);
						while (true)
						{
							P_1._0001[num19 | (num18 >> 9)] = (short)((num15 << 4) | num17);
							num7 = num18;
							num8 = 1;
							if (num8 == 0)
							{
								break;
							}
							num11 = num17;
							if (false)
							{
								goto IL_00a7;
							}
							num18 = num7 + (num8 << num11);
							if (num18 < num20)
							{
								continue;
							}
							goto IL_01f3;
						}
						goto IL_00d8;
						IL_01f3:
						array2[num17] = num2 + (1 << 16 - num17);
						goto IL_0203;
					}
					break;
					IL_00d8:
					int num21 = num7 & num8;
					num2 -= array[num14] << 16 - num14;
					int num22 = num2 & 0x1FF80;
					while (num22 < num21)
					{
						P_1._0001[_0001(num22)] = (short)((-num13 << 4) | num14);
						num7 = num13;
						num8 = 1;
						num9 = num14 - 9;
						num10 = 31;
						if (num10 != 0)
						{
							num13 = num7 + (num8 << (num9 & num10));
							num22 += 128;
							continue;
						}
						goto IL_00a6;
					}
					num14--;
				}
			}
			array2[num4] = num2;
			int num23 = num2;
			int num24 = array[num4];
			int num25 = 16;
			int num26 = num4;
			if (uint.MaxValue != 0)
			{
				num25 -= num26;
				num26 = 31;
			}
			num2 = num23 + (num24 << (num25 & num26));
			goto IL_0081;
		}

		static _0007._0003._0004 _0001(_0007._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0002];
			Array.Copy(P_0._0002, 0, array, 0, P_0._0002);
			return new _0007._0003._0004(array);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#150")]
		static extern uint _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#121")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#211")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, int P_2, double P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#62")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, double[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#34")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, int P_2);

		static void _0001(Opaline P_0)
		{
			_0001(P_0._0001.__Ptr);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#155")]
		static extern void _0001(IntPtr P_0, int P_1);

		static void _0001(_0007._0003._0002 P_0, int P_1)
		{
			while (true)
			{
				P_0._0001 >>= P_1;
				while (0 == 0)
				{
					P_0._0003 -= P_1;
					if (8u != 0)
					{
						return;
					}
				}
			}
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#13")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, Orientation[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#306")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#27")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, int[] P_2, int P_3, Point P_4);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#603")]
		static extern int _0001(out uint _0002);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#142")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, uint _0004, out IntPtr _0005, out double _0006, out double _0007, out double _0008);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#146")]
		static extern double _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#18")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3, double P_4);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#117")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#36")]
		static extern int _0001(IntPtr P_0, string P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#22")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, IntPtr _0004, out Point _0005, out Orientation _0006);

		static void _0001(_0007._0003._0003 P_0, int P_1)
		{
			while (true)
			{
				int num = P_0._0002++;
				while (0 == 0)
				{
					if (num != 32768)
					{
						if (8 == 0)
						{
							break;
						}
						P_0._0001[P_0._0001++] = (byte)P_1;
						if (0 == 0)
						{
							if (0 == 0)
							{
								P_0._0001 &= 32767;
								return;
							}
							continue;
						}
					}
					if (8 == 0)
					{
						break;
					}
					throw new InvalidOperationException();
				}
			}
		}

		static int _0001(_0007._0003._0002 P_0, byte[] P_1, int P_2, int P_3)
		{
			int num = 0;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3 = P_0._0003;
					int num5;
					if (5u != 0)
					{
						if (num3 > 0)
						{
							num = P_3;
							if (false)
							{
								break;
							}
							if (num > 0)
							{
								P_1[P_2++] = (byte)P_0._0001;
								goto IL_011e;
							}
						}
						while (true)
						{
							if (P_3 != 0)
							{
								int num4 = P_0._0002 - P_0._0001;
								if (P_3 > num4)
								{
									P_3 = num4;
								}
								Array.Copy(P_0._0001, P_0._0001, P_1, P_2, P_3);
								P_0._0001 += P_3;
								if (((P_0._0001 - P_0._0002) & 1) != 0)
								{
									P_0._0001 = (uint)(P_0._0001[P_0._0001++] & 0xFF);
									P_0._0003 = 8;
								}
								if (8 == 0)
								{
									break;
								}
								if (0 == 0)
								{
									if (8 == 0)
									{
										continue;
									}
									num5 = num2;
									if (8 == 0)
									{
										goto IL_0075;
									}
									goto IL_0102;
								}
							}
							num5 = num2;
							goto IL_0075;
							IL_0075:
							return num5;
						}
						goto IL_011e;
					}
					goto IL_0104;
					IL_0104:
					return num3;
					IL_0102:
					num3 = num5 + P_3;
					goto IL_0104;
					IL_011e:
					P_0._0001 >>= 8;
					P_0._0003 -= 8;
					P_3--;
					num2++;
				}
			}
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#144")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, uint P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#200")]
		static extern IntPtr _0001(IntPtr P_0, double P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#507")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#511")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#103")]
		static extern void _0001(string P_0);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#106")]
		static extern IntPtr _0001(IntPtr P_0, uint P_1, uint P_2, double P_3);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#131")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, double P_2, _0006._0001 P_3);

		static void _0001(_0007._0003._0003 P_0, int P_1, int P_2)
		{
			if ((P_0._0002 += P_1) > 32768)
			{
				throw new InvalidOperationException();
			}
			int num = (P_0._0001 - P_2) & 0x7FFF;
			if (0 == 0)
			{
				int num2 = 32768;
				int num3 = P_1;
				if (0 == 0)
				{
					int num4 = num2 - num3;
					if (num > num4 || P_0._0001 >= num4)
					{
						goto IL_00c2;
					}
					num2 = P_1;
					num3 = P_2;
				}
				if (num2 <= num3)
				{
					Array.Copy(P_0._0001, num, P_0._0001, P_0._0001, P_1);
					P_0._0001 += P_1;
				}
				else
				{
					while (P_1-- > 0)
					{
						P_0._0001[P_0._0001++] = P_0._0001[num++];
					}
				}
				return;
			}
			goto IL_00c2;
			IL_00c2:
			_0001(P_0, num, P_1);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#143")]
		static extern double _0001(IntPtr P_0, IntPtr P_1, uint P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#23")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, string P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#132")]
		static extern uint _0001(IntPtr P_0, double P_1, _0006._0001 P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#102")]
		static extern void _0001(IntPtr P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#64")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, Point P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#514")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#509")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		static int _0001(_0007._0003._0002 P_0, int P_1)
		{
			while (P_0._0003 < P_1)
			{
				if (P_0._0001 == P_0._0002)
				{
					if (false)
					{
						break;
					}
					if (true)
					{
						return -1;
					}
				}
				else
				{
					if (7 == 0)
					{
						continue;
					}
					P_0._0001 |= (uint)(((P_0._0001[P_0._0001++] & 0xFF) | ((P_0._0001[P_0._0001++] & 0xFF) << 8)) << P_0._0003);
				}
				P_0._0003 += 16;
				break;
			}
			long num = P_0._0001;
			int num2 = 1;
			while (true)
			{
				int num3;
				if (0 == 0)
				{
					num2 <<= P_1;
					if (false)
					{
						break;
					}
				}
				else if (num3 == 0)
				{
					continue;
				}
				num2--;
				break;
			}
			return (int)(num & num2);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#99")]
		static extern int _0001(IntPtr P_0);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#115")]
		static extern void _0001(IntPtr P_0, int P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#72")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#204")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr[] P_1, int P_2, int[] P_3, IntPtr[] P_4, int P_5, double P_6);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#110")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out double _0004, out double _0005, out double _0006, out double _0007, out uint _0008);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#69")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, double P_2);

		static int _0001(_0007._0003._0003 P_0)
		{
			return P_0._0002;
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#125")]
		static extern void _0001(IntPtr P_0, double P_1, double P_2, double P_3);

		static Opaline2Cs.Session _0001(Opaline P_0)
		{
			IntPtr intPtr;
			if (0 == 0)
			{
				if (6 == 0)
				{
					goto IL_004a;
				}
				intPtr = _0001();
				goto IL_0009;
			}
			goto IL_0030;
			IL_004a:
			Opaline2Cs.Session result;
			return result;
			IL_0030:
			IntPtr intPtr2 = default(IntPtr);
			intPtr = intPtr2;
			if (false || 3 == 0)
			{
				goto IL_0009;
			}
			Opaline2Cs.Session result2 = Opaline2Cs.Wrappable.Create(intPtr, new Opaline2Cs.Session());
			if (7 == 0)
			{
				goto IL_004a;
			}
			return result2;
			IL_0009:
			if (0 == 0)
			{
				intPtr2 = intPtr;
			}
			goto IL_0030;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#70")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#201")]
		static extern IntPtr _0001(IntPtr P_0, double P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#47")]
		static extern int _0001(IntPtr P_0, int P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#119")]
		static extern int _0001(IntPtr P_0);

		static ICryptoTransform _0001(bool P_0, byte[] P_1, byte[] P_2)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			try
			{
				ICryptoTransform result;
				while (true)
				{
					ICryptoTransform cryptoTransform;
					if (0 == 0 && !P_0)
					{
						if (false)
						{
							continue;
						}
						cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(P_2, P_1);
						goto IL_0025;
					}
					goto IL_003e;
					IL_0025:
					result = cryptoTransform;
					if (3 == 0)
					{
						goto IL_003e;
					}
					break;
					IL_003e:
					cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(P_2, P_1);
					goto IL_0025;
				}
				return result;
			}
			finally
			{
				if (6u != 0 && aesCryptoServiceProvider != null && 0 == 0)
				{
					((IDisposable)aesCryptoServiceProvider).Dispose();
				}
			}
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#521")]
		static extern int _0001(IntPtr P_0, double P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#505")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#214")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3, double P_4);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#108")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, uint P_2, double P_3, double P_4, double P_5);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#14")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Orientation[] P_2, int P_3, int P_4, IntPtr[] P_5);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#301")]
		static extern IntPtr _0001();

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#303")]
		static extern int _0001(IntPtr P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#63")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, Point[] P_2, bool[] P_3, int P_4);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#533")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, IntPtr _0004, out int _0005);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#130")]
		static extern void _0001(IntPtr P_0, int P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#552")]
		static extern int _0001(IntPtr P_0, Side P_1, Side P_2);

		static Opaline2Cs.Session _0001(int P_0, Opaline P_1)
		{
			IntPtr intPtr;
			if (0 == 0)
			{
				if (6 == 0)
				{
					goto IL_004a;
				}
				intPtr = _0001();
				goto IL_0009;
			}
			goto IL_0030;
			IL_004a:
			Opaline2Cs.Session result;
			return result;
			IL_0030:
			IntPtr intPtr2 = default(IntPtr);
			intPtr = intPtr2;
			if (false || 3 == 0)
			{
				goto IL_0009;
			}
			Opaline2Cs.Session result2 = Opaline2Cs.Wrappable.Create(intPtr, new Opaline2Cs.Session());
			if (7 == 0)
			{
				goto IL_004a;
			}
			return result2;
			IL_0009:
			if (0 == 0)
			{
				intPtr2 = intPtr;
			}
			goto IL_0030;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#313")]
		static extern Orientation _0001(int P_0);

		static void _0001(_0007._0003._0002 P_0)
		{
			P_0._0001 >>= P_0._0003 & 7;
			P_0._0003 &= -8;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#1007")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#137")]
		static extern uint _0001(IntPtr P_0, uint P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#213")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3, int[] P_4, IntPtr[] P_5, int P_6, double P_7);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#504")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, CommonCutType P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#33")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#52")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr[] P_1, int P_2);

		static string _0001(int P_0)
		{
			int num = P_0;
			byte[] array = global::_0001._0005._0001;
			int num2 = num;
			int num3 = num2 + 1;
			if (0 == 0)
			{
				num = num3;
			}
			int num4 = array[num2];
			int num6;
			while (true)
			{
				int num5 = num4;
				if ((num5 & 0x80) == 0)
				{
					num6 = num5;
					if (num6 != 0)
					{
						break;
					}
					return string.Empty;
				}
				num4 = num5;
				if (-1 == 0)
				{
					continue;
				}
				int num8;
				if (7u != 0)
				{
					int num7 = num4 & 0x40;
					while (num7 != 0)
					{
						num8 = ((num5 & 0x1F) << 24) + (global::_0001._0005._0001[num++] << 16);
						while (true)
						{
							num7 = num8 + (global::_0001._0005._0001[num++] << 8);
							if (false)
							{
								break;
							}
							num8 = num7 + global::_0001._0005._0001[num++];
							if (false)
							{
								continue;
							}
							goto IL_00a2;
						}
					}
					int num9 = num5 & 0x3F;
					int num10 = 8;
					do
					{
						num9 <<= num10;
						num10 = global::_0001._0005._0001[num++];
					}
					while (false);
					num4 = num9 + num10;
				}
				num6 = num4;
				break;
				IL_00a2:
				num6 = num8;
				break;
			}
			while (false)
			{
			}
			string result;
			try
			{
				byte[] array2 = global::_0003._0003(global::_0002._007E_0002(global::_0001._0001(), global::_0001._0005._0001, num, num6));
				string text = global::_0004._0004(global::_0002._007E_0002(global::_0001._0001(), array2, 0, array2.Length));
				if (global::_0001._0005._0001)
				{
					_0001(text, P_0);
				}
				result = text;
			}
			catch
			{
				do
				{
					result = null;
				}
				while (false);
			}
			return result;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#502")]
		static extern int _0001(IntPtr P_0, double P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#123")]
		static extern void _0001(IntPtr P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6);

		static void _0001(PowerNest2 P_0, bool P_1)
		{
			while (true)
			{
				bool flag = !P_0._0001;
				bool num = flag;
				while (true)
				{
					if (num)
					{
						if (false)
						{
							break;
						}
						if (0 == 0)
						{
							bool flag2 = P_1;
							num = flag2;
							if (2 == 0)
							{
								continue;
							}
							if (!num)
							{
								goto IL_003c;
							}
						}
						_0001(P_0._0001.__Ptr);
						_0001(P_0);
						goto IL_003c;
					}
					goto IL_0040;
					IL_003c:
					if (false)
					{
						break;
					}
					goto IL_0040;
					IL_0040:
					if (4 == 0)
					{
						break;
					}
					P_0._0001 = true;
					return;
				}
			}
		}

		static void _0001(int P_0, byte[] P_1, _0007._0003._0002 P_2, int P_3)
		{
			int num;
			if (true)
			{
				if (P_2._0001 < P_2._0002)
				{
					throw new InvalidOperationException();
				}
				num = P_0 + P_3;
				if (0 > P_0 || P_0 > num || num > P_1.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((P_3 & 1) == 0)
				{
					goto IL_0087;
				}
				P_2._0001 |= (uint)((P_1[P_0++] & 0xFF) << P_2._0003);
			}
			P_2._0003 += 8;
			goto IL_0087;
			IL_0087:
			P_2._0001 = P_1;
			P_2._0001 = P_0;
			P_2._0002 = num;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#19")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, Orientation[] P_3, Point[] P_4, int P_5);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#111")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out uint _0004, out uint _0005, out double _0006);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#112")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#702")]
		static extern int _0001();

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#216")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, int P_2, double P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#212")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, int P_2, double P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#510")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, int P_2);

		static int _0001(_0007._0003._0002 P_0)
		{
			return P_0._0003;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#215")]
		static extern IntPtr _0001(IntPtr P_0, int P_1, IntPtr[] P_2, int[] P_3, IntPtr[] P_4, Orientation[] P_5, Point[] P_6);

		static bool _0001(_0007._0003._0001 P_0)
		{
			int num = _0001(P_0._0001);
			while (true)
			{
				int num2 = num;
				int num3 = 258;
				while (true)
				{
					if (num2 < num3)
					{
						return true;
					}
					while (true)
					{
						int num4 = P_0._0001;
						num2 = num4;
						num3 = 7;
						if (num3 == 0)
						{
							break;
						}
						int num5;
						switch (num2 - num3)
						{
						case 0:
							while (true)
							{
								if (((num5 = _0001(P_0._0001, P_0._0001)) & -256) != 0)
								{
									if (num5 >= 257)
									{
										break;
									}
									if (0 == 0)
									{
										goto IL_009a;
									}
								}
								_0007._0003._0003 obj = P_0._0001;
								int num6 = num5;
								if (4u != 0)
								{
									_0001(obj, num6);
								}
								if (--num < 258)
								{
									return true;
								}
							}
							P_0._0003 = _0007._0003._0001._0001[num5 - 257];
							P_0._0002 = _0007._0003._0001._0002[num5 - 257];
							goto case 1;
						case 1:
							if (P_0._0002 > 0)
							{
								P_0._0001 = 8;
								int num8 = _0001(P_0._0001, P_0._0002);
								if (num8 < 0)
								{
									return false;
								}
								_0001(P_0._0001, P_0._0002);
								P_0._0003 += num8;
							}
							P_0._0001 = 9;
							goto case 2;
						case 2:
							num5 = _0001(P_0._0002, P_0._0001);
							if (num5 < 0)
							{
								return false;
							}
							P_0._0004 = _0007._0003._0001._0003[num5];
							P_0._0002 = _0007._0003._0001._0004[num5];
							goto case 3;
						case 3:
							{
								if (P_0._0002 > 0)
								{
									P_0._0001 = 10;
									int num7 = _0001(P_0._0001, P_0._0002);
									if (num7 < 0)
									{
										return false;
									}
									_0001(P_0._0001, P_0._0002);
									P_0._0004 += num7;
								}
								_0001(P_0._0001, P_0._0003, P_0._0004);
								num -= P_0._0003;
								P_0._0001 = 7;
								break;
							}
							IL_009a:
							if (num5 < 0)
							{
								return false;
							}
							goto IL_00a0;
						}
						goto end_IL_01dc;
						IL_00a0:
						P_0._0002 = null;
						P_0._0001 = null;
						if (false)
						{
							continue;
						}
						P_0._0001 = 2;
						return true;
					}
					continue;
					end_IL_01dc:
					break;
				}
			}
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#66")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr[] P_1, int P_2, Point P_3);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#124")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#68")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#602")]
		static extern int _0001(out byte _0002, int _0003, uint _0004, uint _0005);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#73")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, double[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#520")]
		static extern int _0001(IntPtr P_0, int P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#98")]
		static extern void _0001(IntPtr _0002, [MarshalAs(UnmanagedType.LPUTF8Str)] string _0003);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#138")]
		static extern IntPtr _0001(IntPtr P_0, uint P_1);

		static void _0001(PowerNest2 P_0)
		{
			if (4 == 0)
			{
				return;
			}
			IEnumerator<GCHandle> enumerator = P_0._0001.GetEnumerator();
			try
			{
				GCHandle gCHandle = default(GCHandle);
				while (true)
				{
					if (global::_0005._007E_0005(enumerator))
					{
						goto IL_0038;
					}
					if (7u != 0)
					{
						break;
					}
					goto IL_0020;
					IL_0020:
					if (2 == 0)
					{
						goto IL_0038;
					}
					gCHandle.Free();
					continue;
					IL_0038:
					GCHandle current = enumerator.Current;
					if (0 == 0)
					{
						gCHandle = current;
					}
					goto IL_0020;
				}
			}
			finally
			{
				if (6u != 0 && enumerator != null)
				{
					do
					{
						global::_0006._007E_0006(enumerator);
					}
					while (false);
				}
			}
			P_0._0001.Clear();
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#122")]
		static extern int _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#51")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, int _0004, out IntPtr _0005, out Point _0006, out Orientation _0007);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#154")]
		static extern uint _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#121")]
		static extern int _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#145")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out double _0004, out double _0005, out double _0006);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#133")]
		static extern int _0001(IntPtr P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#530")]
		static extern int _0001(IntPtr P_0, int P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#203")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int[] P_3, int P_4, double P_5);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#501")]
		static extern int _0001(IntPtr P_0, double P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#32")]
		static extern int _0001(StringBuilder P_0);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#113")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, uint _0004, IntPtr _0005, out double _0006, out double _0007, out double _0008, out double _000E, out double _000F, out double _0010);

		static IntPtr _0001(IUserData P_0, PowerNest2 P_1)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr3;
			while (true)
			{
				IntPtr intPtr2 = intPtr;
				bool num = P_0 != null;
				do
				{
					bool flag = num;
					num = flag;
				}
				while (8 == 0);
				GCHandle gCHandle;
				if (num)
				{
					gCHandle = global::_0007._0008(P_0);
					intPtr3 = global::_0008._000E(gCHandle);
					goto IL_002e;
				}
				goto IL_003d;
				IL_003d:
				IntPtr intPtr4;
				while (true)
				{
					intPtr = intPtr2;
					if (false)
					{
						break;
					}
					intPtr4 = intPtr;
					if (false)
					{
						continue;
					}
					goto IL_0047;
				}
				continue;
				IL_0047:
				intPtr3 = intPtr4;
				if (0 == 0)
				{
					break;
				}
				goto IL_002e;
				IL_002e:
				intPtr2 = intPtr3;
				P_1._0001.Add(gCHandle);
				goto IL_003d;
			}
			return intPtr3;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#80")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2, double P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#506")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#16")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2, double P_3, double P_4, double P_5);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#105")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, int P_2);

		static void _0001(_0007._0003._0003 P_0, int P_1, int P_2)
		{
			if (-1 == 0)
			{
				return;
			}
			while (true)
			{
				int num = P_2;
				int num2 = num - 1;
				if (2u != 0)
				{
					P_2 = num2;
					if (num <= 0 || 5 == 0)
					{
						break;
					}
					P_0._0001[P_0._0001++] = P_0._0001[P_1++];
					P_0._0001 &= 32767;
					num = P_1;
					if (3 == 0)
					{
						goto IL_0051;
					}
					num2 = 32767;
				}
				num &= num2;
				goto IL_0051;
				IL_0051:
				P_1 = num;
			}
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#153")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#151")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, uint P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#141")]
		static extern uint _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#135")]
		static extern void _0001(IntPtr _0002, uint _0003, out uint _0004, out IntPtr _0005, out IntPtr _0006);

		static IUserData _0001(IntPtr P_0)
		{
			bool num = _000E._000F(P_0, IntPtr.Zero);
			if (0 == 0)
			{
				bool flag = num;
				if (2 == 0)
				{
					goto IL_003d;
				}
				num = flag;
			}
			if (num)
			{
				goto IL_001b;
			}
			goto IL_0023;
			IL_0023:
			GCHandle gCHandle = _000F._0011(P_0);
			goto IL_002e;
			IL_003d:
			IUserData result = default(IUserData);
			if (uint.MaxValue != 0)
			{
				return result;
			}
			goto IL_001b;
			IL_002e:
			if (6 == 0)
			{
				goto IL_0023;
			}
			result = gCHandle.Target as IUserData;
			goto IL_003d;
			IL_001b:
			result = null;
			if (false)
			{
				goto IL_002e;
			}
			goto IL_003d;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#531")]
		static extern int _0001(IntPtr P_0, double P_1);

		static int _0001(int P_0, byte[] P_1, _0007._0003._0003 P_2, int P_3)
		{
			int num = P_2._0001;
			int num2;
			if (P_3 <= P_2._0002)
			{
				num2 = P_2._0001;
				goto IL_00e1;
			}
			P_3 = P_2._0002;
			goto IL_0057;
			IL_008a:
			Array.Copy(P_2._0001, num - P_3, P_1, P_0, P_3);
			int num3;
			P_2._0002 -= num3;
			goto IL_00a9;
			IL_007f:
			int num4 = P_0;
			int num6;
			int num5 = num6;
			goto IL_0081;
			IL_0057:
			do
			{
				num3 = P_3;
			}
			while (3 == 0);
			num2 = P_3;
			if (false)
			{
				goto IL_00e1;
			}
			num6 = num2 - num;
			while (num6 > 0)
			{
				Array.Copy(P_2._0001, 32768 - num6, P_1, P_0, num6);
				if (false)
				{
					continue;
				}
				goto IL_007f;
			}
			goto IL_008a;
			IL_00a9:
			if (P_2._0002 < 0)
			{
				throw new InvalidOperationException();
			}
			if (3u != 0)
			{
				return num3;
			}
			goto IL_0057;
			IL_00e1:
			num4 = num2 - P_2._0002;
			num5 = P_3;
			if (0 == 0)
			{
				num = (num4 + num5) & 0x7FFF;
				goto IL_0057;
			}
			goto IL_0081;
			IL_0081:
			P_0 = num4 + num5;
			if (4u != 0)
			{
				P_3 = num;
				goto IL_008a;
			}
			goto IL_00a9;
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#127")]
		static extern void _0001(IntPtr P_0, double P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#304")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, int P_2, Point P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#25")]
		static extern int _0001(IntPtr P_0, global::_0001._0003 P_1, IntPtr P_2, global::_0001._0002 P_3, IntPtr P_4);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#61")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#67")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#44")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, Point[] P_3, Point[] P_4, int P_5);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#149")]
		static extern int _0001(IntPtr P_0, IntPtr P_1);

		static int _0001(_0007._0003._0007 P_0)
		{
			return P_0.ReadByte() | (P_0.ReadByte() << 8);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#109")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, uint P_2, double P_3, double P_4, uint P_5, uint P_6, double P_7, double P_8, uint P_9, uint P_10, double P_11, double P_12, uint P_13, uint P_14);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#305")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int P_3);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#79")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int P_3, double P_4);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#534")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, IntPtr _0004, int _0005, out IntPtr _0006);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#21")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, out double _0004, out int _0005);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#308")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, Point[] P_2, int[] P_3, int P_4);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#513")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, CommonCutClusterConstraint P_2, CommonCutClusterConstraint P_3);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#140")]
		static extern IntPtr _0001(IntPtr P_0, uint P_1);

		static PowerNest2Cs.Session _0001(PowerNest2 P_0)
		{
			IntPtr intPtr;
			if (0 == 0)
			{
				if (6 == 0)
				{
					goto IL_004a;
				}
				intPtr = _0001();
				goto IL_0009;
			}
			goto IL_0030;
			IL_004a:
			PowerNest2Cs.Session result;
			return result;
			IL_0030:
			IntPtr intPtr2 = default(IntPtr);
			intPtr = intPtr2;
			if (false || 3 == 0)
			{
				goto IL_0009;
			}
			PowerNest2Cs.Session result2 = PowerNest2Cs.Wrappable.Create(intPtr, new PowerNest2Cs.Session());
			if (7 == 0)
			{
				goto IL_004a;
			}
			return result2;
			IL_0009:
			if (0 == 0)
			{
				intPtr2 = intPtr;
			}
			goto IL_0030;
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#116")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, int P_2);

		static bool _0001(_0007._0003._0002 P_0)
		{
			return P_0._0001 == P_0._0002;
		}

		static void _0001(string P_0, int P_1)
		{
			try
			{
				object obj;
				do
				{
					obj = global::_0001._0005._0001;
				}
				while (false);
				_0010._0012(obj);
				try
				{
					do
					{
						if (4u != 0)
						{
							global::_0001._0005._0001.Add(P_1, P_0);
						}
					}
					while (false);
				}
				finally
				{
					if (0 == 0)
					{
						_0010._0013(obj);
					}
				}
			}
			catch
			{
			}
		}

		static short _0001(int P_0)
		{
			return (short)((_0007._0003._0006._0001[P_0 & 0xF] << 12) | (_0007._0003._0006._0001[(P_0 >> 4) & 0xF] << 8) | (_0007._0003._0006._0001[(P_0 >> 8) & 0xF] << 4) | _0007._0003._0006._0001[P_0 >> 12]);
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#104")]
		static extern IntPtr _0001(IntPtr P_0, double P_1, double P_2, double P_3, double P_4, uint P_5);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#2002")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr[] P_1, int P_2, int[] P_3, IntPtr[] P_4, int P_5, double P_6, string P_7, StringBuilder P_8);

		static int _0001(int P_0, byte[] P_1, _0007._0003._0001 P_2, int P_3)
		{
			if (false)
			{
				goto IL_0034;
			}
			int num = 0;
			int num2 = default(int);
			if (num == 0)
			{
				num2 = num;
				goto IL_0073;
			}
			goto IL_0098;
			IL_0031:
			int num3;
			int num4;
			P_0 = num3 + num4;
			goto IL_0034;
			IL_0034:
			num3 = num2;
			int num5 = default(int);
			if (5u != 0)
			{
				num2 = num3 + num5;
				P_3 -= num5;
				if (P_3 == 0)
				{
					return num2;
				}
				goto IL_0045;
			}
			goto IL_0058;
			IL_0073:
			num3 = P_2._0001;
			num4 = 11;
			goto IL_0015;
			IL_0015:
			if (num4 == 0)
			{
				goto IL_0031;
			}
			if (num3 == num4)
			{
				goto IL_0045;
			}
			num = _0001(P_0, P_1, P_2._0001, P_3);
			goto IL_0098;
			IL_0045:
			if (_0001(P_2))
			{
				goto IL_0073;
			}
			num3 = P_2._0001._0002;
			goto IL_0058;
			IL_0058:
			num4 = 0;
			if (num4 != 0)
			{
				goto IL_0015;
			}
			if (num3 > num4 && P_2._0001 != 11)
			{
				goto IL_0073;
			}
			return num2;
			IL_0098:
			num5 = num;
			num3 = P_0;
			num4 = num5;
			goto IL_0031;
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#118")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#302")]
		static extern int _0001(string P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#20")]
		static extern IntPtr _0001(IntPtr P_0, IntPtr P_1, IntPtr[] P_2, int P_3, double P_4);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#114")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out double _0004, out double _0005, out uint _0006, out uint _0007, out double _0008, out double _000E, out uint _000F, out uint _0010, out double _0011, out double _0012, out uint _0013, out uint _0014);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#209")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);

		static int _0001(_0007._0003._0004 P_0, _0007._0003._0002 P_1)
		{
			int num2;
			int num = (num2 = _0001(P_1, 9));
			int num7 = default(int);
			while (true)
			{
				int num9;
				int num4;
				if (num >= 0)
				{
					int num3 = (num4 = P_0._0001[num2]);
					int num5 = 0;
					if (num5 == 0)
					{
						if (num3 < num5)
						{
							int num6 = -(num4 >> 4);
							if (7u != 0)
							{
								num7 = num6;
							}
							int num8 = num4 & 0xF;
							num9 = (num2 = _0001(P_1, num8));
							goto IL_0063;
						}
						_0001(P_1, num4 & 0xF);
						num3 = num4;
						num5 = 4;
					}
					return num3 >> num5;
				}
				int num10 = P_1._0003;
				num2 = _0001(P_1, num10);
				num4 = P_0._0001[num2];
				num9 = num4;
				if (-1 == 0)
				{
					goto IL_0063;
				}
				if (num9 < 0)
				{
					break;
				}
				int num11 = num4 & 0xF;
				if (7 == 0)
				{
					goto IL_0084;
				}
				if (false)
				{
					goto IL_00a3;
				}
				if (num11 > num10)
				{
					break;
				}
				_0001(P_1, num4 & 0xF);
				num = num4;
				if (4u != 0)
				{
					return num >> 4;
				}
				goto IL_00b9;
				IL_00a3:
				num4 = num11;
				int num12;
				if ((num4 & 0xF) <= num12)
				{
					_0001(P_1, num4 & 0xF);
					num = num4 >> 4;
					goto IL_00b9;
				}
				return -1;
				IL_0063:
				if (0 == 0)
				{
					if (num9 < 0)
					{
						num12 = P_1._0003;
						num2 = _0001(P_1, num12);
						num11 = P_0._0001[num7 | (num2 >> 9)];
						goto IL_00a3;
					}
					num4 = P_0._0001[num7 | (num2 >> 9)];
					_0001(P_1, num4 & 0xF);
					num9 = num4;
				}
				num11 = num9 >> 4;
				goto IL_0084;
				IL_00b9:
				if (true)
				{
					return num;
				}
				continue;
				IL_0084:
				return num11;
			}
			return -1;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#508")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, double P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#206")]
		static extern IntPtr _0001(IntPtr _0002, IntPtr _0003, int _0004, out IntPtr _0005);

		static int _0001(_0007._0003._0007 P_0)
		{
			return _0001(P_0) | (_0001(P_0) << 16);
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#512")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, IntPtr _0004, out int _0005);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#503")]
		static extern int _0001(IntPtr P_0, double P_1);

		static int _0001(_0007._0003._0003 P_0)
		{
			return 32768 - P_0._0002;
		}

		static string _0001(int P_0)
		{
			object obj = global::_0001._0005._0001;
			_0010._0012(obj);
			string result = default(string);
			try
			{
				global::_0001._0005._0001.TryGetValue(P_0, out var value);
				while (value != null)
				{
					if (false)
					{
						continue;
					}
					if (7 == 0)
					{
						goto IL_0061;
					}
					result = value;
					return result;
				}
			}
			finally
			{
				do
				{
					_0010._0013(obj);
				}
				while (false);
			}
			return _0001(P_0);
			IL_0061:
			return result;
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#134")]
		static extern int _0001(IntPtr P_0);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#208")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, string P_2);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#205")]
		static extern int _0001(IntPtr _0002, IntPtr _0003, out int _0004);

		static int _0001(_0007._0003._0003 P_0, _0007._0003._0002 P_1, int P_2)
		{
			int num = P_2;
			if (0 == 0)
			{
				num = Math.Min(num, 32768 - P_0._0002);
			}
			int num2 = _0001(P_1);
			while (true)
			{
				int num3 = Math.Min(num, num2);
				do
				{
					P_2 = num3;
					num3 = 32768;
				}
				while (num3 == 0);
				int num4 = num3 - P_0._0001;
				while (true)
				{
					if (P_2 <= num4)
					{
						goto IL_0080;
					}
					int num5;
					if (true)
					{
						num5 = _0001(P_1, P_0._0001, P_0._0001, num4);
						num = num5;
						num2 = num4;
						if (false)
						{
							break;
						}
						if (num != num2)
						{
							goto IL_0094;
						}
					}
					num5 += _0001(P_1, P_0._0001, 0, P_2 - num4);
					goto IL_0094;
					IL_0094:
					P_0._0001 = (P_0._0001 + num5) & 0x7FFF;
					if (false)
					{
						continue;
					}
					P_0._0002 += num5;
					if (0 == 0)
					{
						return num5;
					}
					goto IL_0080;
					IL_0080:
					num5 = _0001(P_1, P_0._0001, P_0._0001, P_2);
					goto IL_0094;
				}
			}
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#107")]
		static extern void _0001(IntPtr P_0, IntPtr P_1, int P_2);

		static int _0001(_0007._0003._0002 P_0)
		{
			int num = P_0._0002;
			int num2;
			while (true)
			{
				num2 = P_0._0001;
				if (false)
				{
					break;
				}
				num -= num2;
				if (false)
				{
					continue;
				}
				num2 = P_0._0003;
				break;
			}
			do
			{
				if (0 == 0)
				{
					num2 >>= 3;
				}
			}
			while (false);
			return num + num2;
		}

		static void _0001(Opaline P_0, bool P_1)
		{
			bool num = !P_0._0001;
			while (num)
			{
				num = P_1;
				if (false)
				{
					continue;
				}
				bool flag = num;
				num = flag;
				if (false)
				{
					continue;
				}
				if (num)
				{
					goto IL_0020;
				}
				goto IL_002d;
				IL_002d:
				if (0 == 0)
				{
					break;
				}
				goto IL_0029;
				IL_0029:
				if (4 == 0)
				{
					goto IL_0020;
				}
				goto IL_002d;
				IL_0020:
				if (0 == 0)
				{
					_0001(P_0);
				}
				goto IL_0029;
			}
			P_0._0001 = true;
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#65")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);

		static bool _0001(_0007._0003._0001 P_0)
		{
			int num = P_0._0001;
			int num2 = num - 2;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if ((P_0._0005 = _0001(P_0._0001, 16)) < 0)
					{
						return false;
					}
					goto IL_012c;
				case 2:
					if (_0001(P_0._0001, 16) < 0)
					{
						return false;
					}
					_0001(P_0._0001, 16);
					P_0._0001 = 5;
					goto case 3;
				case 3:
				{
					int num5 = _0001(P_0._0001, P_0._0001, P_0._0005);
					P_0._0005 -= num5;
					goto IL_018c;
				}
				case 4:
					if (!_0001(P_0._0001, P_0._0001))
					{
						return false;
					}
					P_0._0001 = _0001(P_0._0001);
					P_0._0002 = _0001(P_0._0001);
					goto IL_01e6;
				case 5:
				case 6:
				case 7:
				case 8:
					return _0001(P_0);
				case 10:
					if (0 == 0)
					{
						return false;
					}
					goto IL_01e6;
				default:
					return false;
				case 0:
					{
						if (P_0._0001)
						{
							P_0._0001 = 12;
							return false;
						}
						int num3 = _0001(P_0._0001, 3);
						while (true)
						{
							if (num3 < 0)
							{
								return false;
							}
							_0001(P_0._0001, 3);
							if ((num3 & 1) != 0)
							{
								P_0._0001 = true;
							}
							int num4 = num3 >> 1;
							num2 = num4;
							if (false)
							{
								break;
							}
							switch (num2)
							{
							default:
								if (false)
								{
									continue;
								}
								goto IL_010f;
							case 0:
								_0001(P_0._0001);
								P_0._0001 = 3;
								if (6u != 0)
								{
									goto IL_010f;
								}
								goto IL_018c;
							case 1:
								P_0._0001 = _0007._0003._0004._0001;
								P_0._0002 = _0007._0003._0004._0002;
								do
								{
									P_0._0001 = 7;
								}
								while (false);
								goto IL_010f;
							case 2:
								{
									if (6 == 0)
									{
										break;
									}
									P_0._0001 = new _0007._0003._0005();
									P_0._0001 = 6;
									goto IL_010f;
								}
								IL_010f:
								return true;
							}
							goto IL_012c;
						}
						break;
					}
					IL_012c:
					_0001(P_0._0001, 16);
					P_0._0001 = 4;
					goto case 2;
					IL_018c:
					if (0 == 0)
					{
						if (P_0._0005 == 0)
						{
							P_0._0001 = 2;
							return true;
						}
						return !_0001(P_0._0001);
					}
					goto case 5;
					IL_01e6:
					P_0._0001 = 7;
					goto case 5;
				}
			}
		}

		static byte[] _0001(byte[] P_0)
		{
			_0007._0003._0007 obj = new _0007._0003._0007(P_0);
			while (true)
			{
				byte[] array = new byte[0];
				byte[] array2;
				if (0 == 0)
				{
					array2 = array;
				}
				while (true)
				{
					int num = _0001(obj);
					int num2 = num;
					int num3 = 24;
					int num4;
					do
					{
						num4 = num2 >> num3;
						num2 = num4;
						num3 = 24;
					}
					while (num3 == 0);
					if (num - (num2 << num3) == 8223355)
					{
						switch ((_0008._0001)num4)
						{
						case _0008._0001._0002:
							goto IL_006a;
						case _0008._0001._0004:
						{
							byte[] array3 = new byte[16]
							{
								238, 192, 51, 250, 7, 167, 166, 187, 75, 68,
								54, 116, 10, 95, 154, 229
							};
							byte[] array4 = new byte[16]
							{
								47, 135, 167, 81, 240, 166, 219, 226, 151, 214,
								24, 0, 57, 48, 53, 164
							};
							if (false)
							{
								goto default;
							}
							ICryptoTransform cryptoTransform = _0001(true, array4, array3);
							try
							{
								array2 = _0001(cryptoTransform.TransformFinalBlock(P_0, 4, P_0.Length - 4));
							}
							finally
							{
								if (0 == 0)
								{
									cryptoTransform?.Dispose();
								}
							}
							break;
						}
						default:
							throw new ArgumentOutOfRangeException("version", num4, "Selected compression algorithm is not supported.");
						}
						goto IL_0156;
					}
					throw new FormatException("Unknown Header");
					IL_0156:
					obj.Close();
					obj = null;
					return array2;
					IL_006a:
					if (6 == 0)
					{
						continue;
					}
					int num5 = _0001(obj);
					array2 = new byte[num5];
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num9;
						if (0 == 0)
						{
							if (num7 >= num5)
							{
								break;
							}
							int num8 = _0001(obj);
							num9 = _0001(obj);
							byte[] array5 = new byte[num8];
							if (-1 == 0)
							{
								goto end_IL_017c;
							}
							obj.Read(array5, 0, array5.Length);
							num7 = _0001(num6, array2, new _0007._0003._0001(array5), num9);
						}
						num6 += num9;
					}
					goto IL_0156;
					continue;
					end_IL_017c:
					break;
				}
			}
		}

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#120")]
		static extern int _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#136")]
		static extern void _0001(IntPtr _0002, out int _0003, out double _0004, out double _0005);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#210")]
		static extern int _0001(IntPtr P_0, global::_0001._0003 P_1, IntPtr P_2, _0001 P_3, IntPtr P_4);

		static bool _0001(_0007._0003._0005 P_0, _0007._0003._0002 P_1)
		{
			while (true)
			{
				int num2;
				int num3;
				int num4;
				int num;
				switch (P_0._0001)
				{
				case 1:
					P_0._0003 = _0001(P_1, 5);
					if (P_0._0003 < 0)
					{
						return false;
					}
					P_0._0003++;
					_0001(P_1, 5);
					P_0._0005 = P_0._0002 + P_0._0003;
					P_0._0002 = new byte[P_0._0005];
					P_0._0001 = 2;
					goto case 2;
				case 2:
					P_0._0004 = _0001(P_1, 4);
					if (P_0._0004 < 0)
					{
						return false;
					}
					P_0._0004 += 4;
					_0001(P_1, 4);
					P_0._0001 = new byte[19];
					P_0._0007 = 0;
					P_0._0001 = 3;
					goto case 3;
				case 3:
					if (P_0._0007 < P_0._0004)
					{
						num2 = _0001(P_1, 3);
						num3 = num2;
						num4 = 0;
						goto IL_0131;
					}
					goto IL_016d;
				case 4:
				{
					int num5;
					while (((num5 = _0001(P_0._0001, P_1)) & -16) == 0)
					{
						P_0._0002[P_0._0007++] = (P_0._0001 = (byte)num5);
						num3 = P_0._0007;
						num4 = P_0._0005;
						if (0 == 0)
						{
							if (num3 == num4)
							{
								return true;
							}
							continue;
						}
						goto IL_0131;
					}
					if (num5 < 0)
					{
						num = 0;
						goto IL_01e8;
					}
					if (num5 >= 17)
					{
						P_0._0001 = 0;
					}
					P_0._0006 = num5 - 16;
					P_0._0001 = 5;
					goto case 5;
				}
				case 5:
				{
					int num6 = _0007._0003._0005._0002[P_0._0006];
					int num7 = _0001(P_1, num6);
					if (num7 < 0)
					{
						return false;
					}
					_0001(P_1, num6);
					num7 += _0007._0003._0005._0001[P_0._0006];
					while (num7-- > 0)
					{
						P_0._0002[P_0._0007++] = P_0._0001;
					}
					if (P_0._0007 == P_0._0005)
					{
						return true;
					}
					if (false)
					{
						goto IL_016d;
					}
					goto IL_027e;
				}
				case 0:
					{
						P_0._0002 = _0001(P_1, 5);
						num = P_0._0002;
						if (3u != 0)
						{
							if (num < 0)
							{
								return false;
							}
							P_0._0002 += 257;
							_0001(P_1, 5);
							P_0._0001 = 1;
							goto case 1;
						}
						goto IL_01e8;
					}
					IL_01e8:
					return (byte)num != 0;
					IL_016d:
					P_0._0001 = new _0007._0003._0004(P_0._0001);
					P_0._0001 = null;
					P_0._0007 = 0;
					P_0._0001 = 4;
					goto case 4;
					IL_0131:
					if (num3 < num4)
					{
						return false;
					}
					_0001(P_1, 3);
					P_0._0001[_0007._0003._0005._0003[P_0._0007]] = (byte)num2;
					P_0._0007++;
					goto case 3;
				}
				continue;
				IL_027e:
				P_0._0001 = 4;
			}
		}

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#71")]
		static extern int _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#126")]
		static extern void _0001(IntPtr P_0, double P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#112")]
		static extern uint _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#147")]
		static extern int _0001(IntPtr P_0, IntPtr P_1);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#152")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out IntPtr _0004, out uint _0005, out uint _0006, out uint _0007);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#532")]
		static extern int _0001(IntPtr P_0, double P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#26")]
		static extern int _0001(IntPtr P_0, int P_1);

		[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#35")]
		static extern IntPtr _0001(IntPtr P_0, Point[] P_1, int P_2, double P_3);

		[DllImport("opaline3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#148")]
		static extern void _0001(IntPtr _0002, IntPtr _0003, out int _0004, out uint _0005);
	}
	internal delegate void _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2);
}
namespace _0001
{
	internal delegate void _0002(IntPtr P_0, IntPtr P_1, IntPtr P_2);
	internal delegate int _0003(IntPtr P_0);
}
namespace _0006
{
	internal delegate int _0001(IntPtr P_0);
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	internal sealed class _0001 : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0004 : Attribute
	{
	}
}
namespace _0007
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0004
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0002
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0007
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0003
{
	internal sealed class _0001
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 116)]
		internal struct _0001
		{
		}

		internal static readonly _0001 _0001/* Not supported: data(01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 0E 00 0F 00 10 00 11 00 12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1A 00 1B 00 1C 00 1D 00 1E 00 1F 00 7F 00 80 00 81 00 82 00 83 00 84 00 86 00 87 00 88 00 89 00 8A 00 8B 00 8C 00 8D 00 8E 00 8F 00 90 00 91 00 92 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9A 00 9B 00 9C 00 9D 00 9E 00 9F 00) */;
	}
}
namespace _0001
{
	internal class _0005
	{
		public static class _0001
		{
			public static string _0001(int P_0)
			{
				int num = P_0;
				if (8u != 0)
				{
					int num2 = 107396847;
					do
					{
						if (num2 != 0)
						{
							P_0 = num ^ num2;
							num = P_0;
							num2 = _0005.m__0001;
						}
					}
					while (false);
					P_0 = num - num2;
					num = (_0005._0001 ? 1 : 0);
				}
				if (num == 0 && 0 == 0)
				{
					return global::_0005._0003._0001(P_0);
				}
				return global::_0005._0003._0001(P_0);
			}
		}

		private static readonly string m__0001;

		private static readonly string _0002;

		internal static readonly byte[] _0001;

		internal static readonly Dictionary<int, string> _0001;

		internal static readonly object _0001;

		internal static readonly bool _0001;

		private static readonly int m__0001;

		public static string _0001(int P_0)
		{
			return _0005._0001._0001(P_0);
		}

		static _0005()
		{
			_0005.m__0001 = "1";
			_0002 = "246";
			if (3u != 0)
			{
				_0005._0001 = null;
				_0005._0001 = new object();
				_0005._0001 = false;
			}
			while (true)
			{
				_0005.m__0001 = 0;
				bool num = _0015._0019(_0005.m__0001, "1");
				int num4;
				do
				{
					if (num)
					{
						if (4 == 0)
						{
							return;
						}
						_0005._0001 = true;
						_0005._0001 = new Dictionary<int, string>();
					}
					int num2 = _0016._001A(_0002);
					if (false)
					{
						continue;
					}
					_0005.m__0001 = num2;
					Stream stream = _0018._007E_001C(_0017._001B(), "{83af42fd-9d96-4a96-ab01-e96d3dd2da63}");
					try
					{
						int num3 = _001A._001E(_0019._007E_001D(stream));
						byte[] array = new byte[num3];
						while (true)
						{
							_001B._007E_001F(stream, array, 0, num3);
							while (0 == 0)
							{
								_0005._0001 = global::_0005._0003._0001(array);
								array = null;
								if (4u != 0)
								{
									return;
								}
							}
						}
					}
					finally
					{
						if (stream != null)
						{
							global::_0006._007E_0006(stream);
						}
					}
				}
				while (num4 != 0);
			}
		}
	}
}
namespace _0005
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal sealed class _0002 : Attribute
	{
	}
}
namespace _0004
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0008
{
	internal enum _0001
	{
		_0001,
		_0002,
		_0003,
		_0004
	}
}
namespace _0007
{
	internal static class _0003
	{
		internal sealed class _0001
		{
			internal static readonly int[] _0001;

			internal static readonly int[] _0002;

			internal static readonly int[] _0003;

			internal static readonly int[] _0004;

			internal int _0001;

			internal int _0002;

			internal int _0003;

			internal int _0004;

			internal int _0005;

			internal bool _0001;

			internal _0002 _0001;

			internal _0003 _0001;

			internal _0005 _0001;

			internal _0004 _0001;

			internal _0004 _0002;

			public _0001(byte[] P_0)
			{
				this._0001 = new _0002();
				this._0001 = new _0003();
				this._0001 = 2;
				global::_0005._0003._0001(0, P_0, this._0001, P_0.Length);
			}

			static _0001()
			{
				while (true)
				{
					int num = 29;
					while (true)
					{
						int[] array = new int[num];
						RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
						global::_0007._0003._0001._0001 = array;
						while (0 == 0)
						{
							global::_0007._0003._0001._0002 = new int[29]
							{
								0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
								1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
								4, 4, 4, 4, 5, 5, 5, 5, 0
							};
							if (1 == 0)
							{
								continue;
							}
							goto IL_002e;
						}
						goto IL_0059;
						IL_0042:
						num = 30;
						if (num == 0)
						{
							continue;
						}
						int[] array2 = new int[num];
						RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
						global::_0007._0003._0001._0004 = array2;
						goto IL_0059;
						IL_002e:
						global::_0007._0003._0001._0003 = new int[30]
						{
							1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
							33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
							1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
						};
						goto IL_0042;
						IL_0059:
						if (false)
						{
							break;
						}
						if (0 == 0)
						{
							return;
						}
						goto IL_0042;
					}
				}
			}
		}

		internal sealed class _0002
		{
			internal byte[] _0001;

			internal int _0001;

			internal int _0002;

			internal uint _0001;

			internal int _0003;
		}

		internal sealed class _0003
		{
			internal byte[] _0001 = new byte[32768];

			internal int _0001;

			internal int _0002;
		}

		internal sealed class _0004
		{
			internal short[] _0001;

			public static readonly _0004 _0001;

			public static readonly _0004 _0002;

			static _0004()
			{
				byte[] array = new byte[288];
				int num = default(int);
				while (true)
				{
					IL_000f:
					if (0 == 0)
					{
						if (0 == 0)
						{
							num = 0;
						}
						if (-1 == 0)
						{
							goto IL_0086;
						}
						while (num < 144)
						{
							array[num++] = 8;
						}
						if (true)
						{
							while (num < 256)
							{
								if (false)
								{
									goto IL_000f;
								}
								array[num++] = 9;
							}
							goto IL_0071;
						}
					}
					goto IL_00a1;
					IL_0071:
					int num2;
					int num3;
					while (true)
					{
						num2 = num;
						num3 = 280;
						if (num3 == 0)
						{
							break;
						}
						if (num2 >= num3)
						{
							goto IL_0086;
						}
						array[num++] = 7;
					}
					goto IL_00b0;
					IL_00ad:
					num2 = num;
					num3 = 32;
					goto IL_00b0;
					IL_00a1:
					num = 0;
					goto IL_00ad;
					IL_00b0:
					if (num2 >= num3)
					{
						if (8u != 0)
						{
							break;
						}
						goto IL_0071;
					}
					array[num++] = 5;
					goto IL_00ad;
					IL_0086:
					while (num < 288)
					{
						array[num++] = 8;
					}
					_0001 = new _0004(array);
					array = new byte[32];
					goto IL_00a1;
				}
				_0002 = new _0004(array);
			}

			public _0004(byte[] P_0)
			{
				global::_0005._0003._0001(P_0, this);
			}
		}

		internal sealed class _0005
		{
			internal static readonly int[] _0001;

			internal static readonly int[] _0002;

			internal byte[] _0001;

			internal byte[] _0002;

			internal _0004 _0001;

			internal int _0001;

			internal int _0002;

			internal int _0003;

			internal int _0004;

			internal int _0005;

			internal int _0006;

			internal byte _0001;

			internal int _0007;

			internal static readonly int[] _0003;

			static _0005()
			{
				while (true)
				{
					int num = 3;
					while (true)
					{
						IL_0001:
						int[] array = new int[num];
						RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
						global::_0007._0003._0005._0001 = array;
						while (0 == 0)
						{
							num = 3;
							if (num != 0)
							{
								int[] array2 = new int[num];
								RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
								global::_0007._0003._0005._0002 = array2;
								if (false)
								{
									continue;
								}
								num = 19;
							}
							if (num != 0)
							{
								int[] array3 = new int[num];
								RuntimeHelpers.InitializeArray(array3, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
								_0003 = array3;
								return;
							}
							goto IL_0001;
						}
						break;
					}
				}
			}
		}

		internal sealed class _0006
		{
			private static readonly int[] _0001;

			internal static readonly byte[] _0001;

			private static readonly short[] _0001;

			private static readonly byte[] _0002;

			private static readonly short[] _0002;

			private static readonly byte[] _0003;

			static _0006()
			{
				while (true)
				{
					_0006._0001 = new int[19]
					{
						16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
						11, 4, 12, 3, 13, 2, 14, 1, 15
					};
					while (true)
					{
						IL_0017:
						_0006._0001 = new byte[16]
						{
							0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
							5, 13, 3, 11, 7, 15
						};
						_0001 = new short[286];
						_0006._0002 = new byte[286];
						if (false)
						{
							goto IL_00ab;
						}
						int num = 0;
						goto IL_01a6;
						IL_01a6:
						if (num < 144)
						{
							_0001[num] = global::_0005._0003._0001(48 + num << 8);
							goto IL_0071;
						}
						goto IL_00b8;
						IL_00ab:
						_0006._0002[num++] = 9;
						goto IL_00b8;
						IL_00b8:
						if (num < 256)
						{
							_0001[num] = global::_0005._0003._0001(256 + num << 7);
							goto IL_00ab;
						}
						if (false)
						{
							break;
						}
						while (true)
						{
							int num2 = num;
							while (num2 >= 280)
							{
								while (num < 286)
								{
									_0001[num] = global::_0005._0003._0001(-88 + num << 8);
									_0006._0002[num++] = 8;
								}
								_0002 = new short[30];
								_0003 = new byte[30];
								if (false)
								{
									goto end_IL_00f0;
								}
								num = 0;
								while (true)
								{
									if (num < 30)
									{
										_0002[num] = global::_0005._0003._0001(num << 11);
										if (2 == 0)
										{
											break;
										}
										_0003[num] = 5;
										num2 = num;
										if (3 == 0)
										{
											goto IL_00f1;
										}
										num = num2 + 1;
										continue;
									}
									return;
								}
								goto IL_0017;
								IL_00f1:;
							}
							_0001[num] = global::_0005._0003._0001(-256 + num << 9);
							if (7 == 0)
							{
								goto end_IL_0017;
							}
							_0006._0002[num++] = 7;
							continue;
							end_IL_00f0:
							break;
						}
						goto IL_0071;
						IL_0071:
						if (0 == 0)
						{
							_0006._0002[num++] = 8;
							goto IL_01a6;
						}
						goto IL_00b8;
						continue;
						end_IL_0017:
						break;
					}
				}
			}
		}

		internal sealed class _0007 : MemoryStream
		{
			public _0007(byte[] P_0)
				: base(P_0, writable: false)
			{
			}
		}
	}
	internal sealed class _0004
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 12)]
		internal struct _0001
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
		internal struct _0002
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 76)]
		internal struct _0003
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 116)]
		internal struct _0004
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 120)]
		internal struct _0005
		{
		}

		internal static readonly _0002 _0001/* Not supported: data(2F 87 A7 51 F0 A6 DB E2 97 D6 18 00 39 30 35 A4) */;

		internal static readonly _0004 _0001/* Not supported: data(03 00 00 00 04 00 00 00 05 00 00 00 06 00 00 00 07 00 00 00 08 00 00 00 09 00 00 00 0A 00 00 00 0B 00 00 00 0D 00 00 00 0F 00 00 00 11 00 00 00 13 00 00 00 17 00 00 00 1B 00 00 00 1F 00 00 00 23 00 00 00 2B 00 00 00 33 00 00 00 3B 00 00 00 43 00 00 00 53 00 00 00 63 00 00 00 73 00 00 00 83 00 00 00 A3 00 00 00 C3 00 00 00 E3 00 00 00 02 01 00 00) */;

		internal static readonly _0001 _0001/* Not supported: data(02 00 00 00 03 00 00 00 07 00 00 00) */;

		internal static readonly _0002 _0002/* Not supported: data(00 08 04 0C 02 0A 06 0E 01 09 05 0D 03 0B 07 0F) */;

		internal static readonly _0005 _0001/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 06 00 00 00 06 00 00 00 07 00 00 00 07 00 00 00 08 00 00 00 08 00 00 00 09 00 00 00 09 00 00 00 0A 00 00 00 0A 00 00 00 0B 00 00 00 0B 00 00 00 0C 00 00 00 0C 00 00 00 0D 00 00 00 0D 00 00 00) */;

		internal static readonly _0003 _0001/* Not supported: data(10 00 00 00 11 00 00 00 12 00 00 00 00 00 00 00 08 00 00 00 07 00 00 00 09 00 00 00 06 00 00 00 0A 00 00 00 05 00 00 00 0B 00 00 00 04 00 00 00 0C 00 00 00 03 00 00 00 0D 00 00 00 02 00 00 00 0E 00 00 00 01 00 00 00 0F 00 00 00) */;

		internal static readonly _0002 _0003/* Not supported: data(EE C0 33 FA 07 A7 A6 BB 4B 44 36 74 0A 5F 9A E5) */;

		internal static readonly _0001 _0002/* Not supported: data(03 00 00 00 03 00 00 00 0B 00 00 00) */;

		internal static readonly _0004 _0002/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 00 00 00 00) */;

		internal static readonly _0005 _0002/* Not supported: data(01 00 00 00 02 00 00 00 03 00 00 00 04 00 00 00 05 00 00 00 07 00 00 00 09 00 00 00 0D 00 00 00 11 00 00 00 19 00 00 00 21 00 00 00 31 00 00 00 41 00 00 00 61 00 00 00 81 00 00 00 C1 00 00 00 01 01 00 00 81 01 00 00 01 02 00 00 01 03 00 00 01 04 00 00 01 06 00 00 01 08 00 00 01 0C 00 00 01 10 00 00 01 18 00 00 01 20 00 00 01 30 00 00 01 40 00 00 01 60 00 00) */;
	}
}
