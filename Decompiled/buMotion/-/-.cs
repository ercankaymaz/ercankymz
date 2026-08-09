using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using _0003;
using _0004;
using _0007;

namespace _0007
{
	internal class _0003
	{
		static int _0001(global::_0003._0003._0007 P_0)
		{
			return _0001(P_0) | (_0001(P_0) << 16);
		}

		unsafe static int _0001(global::_0003._0003._0003 P_0, global::_0003._0003._0002 P_1, int P_2)
		{
			void* ptr = stackalloc byte[8];
			int val = P_2;
			int num = 32768;
			if (num != 0)
			{
				num -= P_0._0002;
			}
			P_2 = Math.Min(Math.Min(val, num), _0001(P_1));
			((int*)ptr)[1] = 32768 - P_0._0001;
			if (P_2 > ((int*)ptr)[1])
			{
				*(int*)ptr = _0001(P_1, P_0._0001, P_0._0001, ((int*)ptr)[1]);
				if (*(int*)ptr == ((int*)ptr)[1])
				{
					*(int*)ptr += _0001(P_1, P_0._0001, 0, P_2 - ((int*)ptr)[1]);
				}
			}
			else
			{
				*(int*)ptr = _0001(P_1, P_0._0001, P_0._0001, P_2);
			}
			P_0._0001 = (P_0._0001 + *(int*)ptr) & 0x7FFF;
			P_0._0002 += *(int*)ptr;
			return *(int*)ptr;
		}

		static int _0001(global::_0003._0003._0002 P_0)
		{
			return P_0._0003;
		}

		unsafe static byte[] _0001(byte[] P_0)
		{
			void* ptr = stackalloc byte[16];
			global::_0003._0003._0007 obj = new global::_0003._0003._0007(P_0);
			byte[] array = new byte[0];
			int num = _0001(obj);
			int num2 = num >> 24;
			if (num - (num2 << 24) == 8223355)
			{
				switch ((global::_0003._0002)num2)
				{
				case global::_0003._0002._0002:
					*(int*)ptr = _0001(obj);
					array = new byte[*(int*)ptr];
					((int*)ptr)[1] = 0;
					while (((int*)ptr)[1] < *(int*)ptr)
					{
						((int*)ptr)[2] = _0001(obj);
						((int*)ptr)[3] = _0001(obj);
						byte[] array4 = new byte[((int*)ptr)[2]];
						obj.Read(array4, 0, array4.Length);
						_0001(((int*)ptr)[3], new global::_0003._0003._0001(array4), array, ((int*)ptr)[1]);
						((int*)ptr)[1] += ((int*)ptr)[3];
					}
					break;
				case global::_0003._0002._0004:
				{
					byte[] array2 = new byte[16]
					{
						201, 80, 94, 114, 235, 160, 51, 114, 247, 67,
						48, 250, 50, 202, 208, 95
					};
					byte[] array3 = new byte[16]
					{
						65, 118, 42, 16, 60, 135, 183, 161, 59, 70,
						97, 95, 176, 151, 119, 160
					};
					using (ICryptoTransform cryptoTransform = _0001(true, array2, array3))
					{
						array = _0001(cryptoTransform.TransformFinalBlock(P_0, 4, P_0.Length - 4));
					}
					break;
				}
				default:
					throw new ArgumentOutOfRangeException("version", num2, "Selected compression algorithm is not supported.");
				}
				obj.Close();
				obj = null;
				return array;
			}
			throw new FormatException("Unknown Header");
		}

		static void _0001(global::_0003._0003._0002 P_0)
		{
			P_0._0001 >>= P_0._0003 & 7;
			P_0._0003 &= -8;
		}

		static int _0001(global::_0003._0003._0007 P_0)
		{
			return P_0.ReadByte() | (P_0.ReadByte() << 8);
		}

		static int _0001(global::_0003._0003._0002 P_0, int P_1)
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

		static global::_0003._0003._0004 _0001(global::_0003._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0002];
			Array.Copy(P_0._0002, 0, array, 0, P_0._0002);
			return new global::_0003._0003._0004(array);
		}

		unsafe static bool _0001(global::_0003._0003._0001 P_0)
		{
			int num = 12;
			if (num == 0)
			{
				goto IL_00ca;
			}
			void* ptr = stackalloc byte[num];
			((int*)ptr)[1] = P_0._0001;
			int num5 = default(int);
			while (true)
			{
				int num3;
				int num2;
				switch (((int*)ptr)[1])
				{
				case 3:
					num3 = (P_0._0005 = _0001(P_0._0001, 16));
					goto IL_013d;
				case 4:
					num3 = _0001(P_0._0001, 16);
					if (false)
					{
						goto IL_013d;
					}
					goto IL_0166;
				case 5:
					break;
				case 6:
					if (!_0001(P_0._0001, P_0._0001))
					{
						return false;
					}
					P_0._0001 = _0001(P_0._0001);
					P_0._0002 = _0001(P_0._0001);
					P_0._0001 = 7;
					goto case 7;
				case 7:
				case 8:
				case 9:
				case 10:
					return _0001(P_0);
				case 12:
					goto end_IL_022c;
				default:
					num2 = 0;
					goto IL_0219;
				case 2:
					{
						num2 = (P_0._0001 ? 1 : 0);
						if (0 == 0)
						{
							goto IL_0072;
						}
						goto IL_0219;
					}
					IL_0219:
					return (byte)num2 != 0;
					IL_013d:
					if (num3 < 0)
					{
						return false;
					}
					_0001(P_0._0001, 16);
					P_0._0001 = 4;
					goto case 4;
				}
				goto IL_017f;
				IL_0072:
				if (num2 != 0)
				{
					P_0._0001 = 12;
					return false;
				}
				*(int*)ptr = _0001(P_0._0001, 3);
				if (*(int*)ptr < 0)
				{
					return false;
				}
				_0001(P_0._0001, 3);
				int num4 = *(int*)ptr;
				if (8u != 0)
				{
					if ((num4 & 1) != 0)
					{
						if (7 == 0)
						{
							continue;
						}
						P_0._0001 = true;
					}
					num5 = *(int*)ptr >> 1;
					goto IL_00c9;
				}
				goto IL_01b1;
				IL_017f:
				((int*)ptr)[2] = _0001(P_0._0001, P_0._0001, P_0._0005);
				P_0._0005 -= ((int*)ptr)[2];
				num4 = P_0._0005;
				goto IL_01b1;
				IL_01b1:
				if (num4 == 0)
				{
					P_0._0001 = 2;
					return true;
				}
				return !_0001(P_0._0001);
				IL_0166:
				if (num3 < 0)
				{
					return false;
				}
				_0001(P_0._0001, 16);
				P_0._0001 = 5;
				goto IL_017f;
				continue;
				end_IL_022c:
				break;
			}
			if (5 == 0)
			{
				goto IL_0125;
			}
			return false;
			IL_00c9:
			num = num5;
			goto IL_00ca;
			IL_00ca:
			switch (num)
			{
			case 0:
				break;
			case 1:
				P_0._0001 = global::_0003._0003._0004._0001;
				P_0._0002 = global::_0003._0003._0004._0002;
				P_0._0001 = 7;
				goto IL_0125;
			case 2:
				P_0._0001 = new global::_0003._0003._0005();
				P_0._0001 = 6;
				goto IL_0125;
			default:
				goto IL_0125;
			}
			_0001(P_0._0001);
			if (1 == 0)
			{
				goto IL_00c9;
			}
			P_0._0001 = 3;
			goto IL_0125;
			IL_0125:
			return true;
		}

		static string _0001(int P_0)
		{
			object obj = _0004._0002._0001;
			global::_0015_0002._0092_0002(obj);
			string result = default(string);
			try
			{
				_0004._0002._0001.TryGetValue(P_0, out var value);
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
					global::_0015_0002._0093_0002(obj);
				}
				while (false);
			}
			return _0001(P_0);
			IL_0061:
			return result;
		}

		unsafe static bool _0001(global::_0003._0003._0005 P_0, global::_0003._0003._0002 P_1)
		{
			void* ptr = stackalloc byte[16];
			while (true)
			{
				*(int*)ptr = P_0._0001;
				switch (*(int*)ptr)
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
					while (P_0._0007 < P_0._0004)
					{
						((int*)ptr)[1] = _0001(P_1, 3);
						if (((int*)ptr)[1] < 0)
						{
							return false;
						}
						_0001(P_1, 3);
						P_0._0001[global::_0003._0003._0005._0003[P_0._0007]] = (byte)((uint*)ptr)[1];
						P_0._0007++;
					}
					P_0._0001 = new global::_0003._0003._0004(P_0._0001);
					P_0._0001 = null;
					P_0._0007 = 0;
					P_0._0001 = 4;
					goto case 4;
				case 4:
				{
					int num;
					while (((num = _0001(P_0._0001, P_1)) & -16) == 0)
					{
						byte[] array = P_0._0002;
						((int*)ptr)[2] = P_0._0007;
						P_0._0007 = ((int*)ptr)[2] + 1;
						array[((int*)ptr)[2]] = (P_0._0001 = (byte)num);
						if (P_0._0007 == P_0._0005)
						{
							return true;
						}
					}
					if (num < 0)
					{
						return false;
					}
					if (num >= 17)
					{
						P_0._0001 = 0;
					}
					P_0._0006 = num - 16;
					P_0._0001 = 5;
					break;
				}
				case 5:
					break;
				default:
					continue;
				case 0:
					P_0._0002 = _0001(P_1, 5);
					if (P_0._0002 < 0)
					{
						return false;
					}
					P_0._0002 += 257;
					_0001(P_1, 5);
					P_0._0001 = 1;
					goto case 1;
				}
				((int*)ptr)[3] = global::_0003._0003._0005._0002[P_0._0006];
				int num2 = _0001(P_1, ((int*)ptr)[3]);
				if (num2 < 0)
				{
					return false;
				}
				_0001(P_1, ((int*)ptr)[3]);
				num2 += global::_0003._0003._0005._0001[P_0._0006];
				while (num2-- > 0)
				{
					byte[] array2 = P_0._0002;
					((int*)ptr)[2] = P_0._0007;
					P_0._0007 = ((int*)ptr)[2] + 1;
					array2[((int*)ptr)[2]] = P_0._0001;
				}
				if (P_0._0007 == P_0._0005)
				{
					break;
				}
				P_0._0001 = 4;
			}
			return true;
		}

		static int _0001(global::_0003._0003._0003 P_0)
		{
			return P_0._0002;
		}

		static global::_0003._0003._0004 _0001(global::_0003._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0003];
			Array.Copy(P_0._0002, P_0._0002, array, 0, P_0._0003);
			return new global::_0003._0003._0004(array);
		}

		static int _0001(global::_0003._0003._0003 P_0)
		{
			return 32768 - P_0._0002;
		}

		static void _0001(global::_0003._0003._0003 P_0, int P_1)
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

		static int _0001(global::_0003._0003._0002 P_0)
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

		static void _0001(int P_0, int P_1, global::_0003._0003._0002 P_2, byte[] P_3)
		{
			int num;
			if (true)
			{
				if (P_2._0001 < P_2._0002)
				{
					throw new InvalidOperationException();
				}
				num = P_0 + P_1;
				if (0 > P_0 || P_0 > num || num > P_3.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((P_1 & 1) == 0)
				{
					goto IL_0087;
				}
				P_2._0001 |= (uint)((P_3[P_0++] & 0xFF) << P_2._0003);
			}
			P_2._0003 += 8;
			goto IL_0087;
			IL_0087:
			P_2._0001 = P_3;
			P_2._0001 = P_0;
			P_2._0002 = num;
		}

		unsafe static void _0001(global::_0003._0003._0004 P_0, byte[] P_1)
		{
			void* ptr = stackalloc byte[64];
			int[] array = new int[16];
			int[] array2 = new int[16];
			((int*)ptr)[3] = 0;
			while (((int*)ptr)[3] < P_1.Length)
			{
				((int*)ptr)[4] = P_1[((int*)ptr)[3]];
				if (((int*)ptr)[4] > 0)
				{
					array[((int*)ptr)[4]]++;
				}
				((int*)ptr)[3]++;
			}
			*(int*)ptr = 0;
			((int*)ptr)[1] = 512;
			((int*)ptr)[5] = 1;
			while (((int*)ptr)[5] <= 15)
			{
				array2[((int*)ptr)[5]] = *(int*)ptr;
				*(int*)ptr += array[((int*)ptr)[5]] << 16 - ((int*)ptr)[5];
				if (((int*)ptr)[5] >= 10)
				{
					((int*)ptr)[6] = array2[((int*)ptr)[5]] & 0x1FF80;
					((int*)ptr)[7] = *(int*)ptr & 0x1FF80;
					((int*)ptr)[1] += ((int*)ptr)[7] - ((int*)ptr)[6] >> 16 - ((int*)ptr)[5];
				}
				((int*)ptr)[5]++;
			}
			P_0._0001 = new short[((int*)ptr)[1]];
			((int*)ptr)[2] = 512;
			((int*)ptr)[8] = 15;
			while (((int*)ptr)[8] >= 10)
			{
				((int*)ptr)[9] = *(int*)ptr & 0x1FF80;
				*(int*)ptr -= array[((int*)ptr)[8]] << 16 - ((int*)ptr)[8];
				((int*)ptr)[10] = *(int*)ptr & 0x1FF80;
				while (((int*)ptr)[10] < ((int*)ptr)[9])
				{
					P_0._0001[_0001(((int*)ptr)[10])] = (short)((-((int*)ptr)[2] << 4) | ((int*)ptr)[8]);
					((int*)ptr)[2] += 1 << ((int*)ptr)[8] - 9;
					((int*)ptr)[10] += 128;
				}
				((int*)ptr)[8]--;
			}
			((int*)ptr)[11] = 0;
			while (((int*)ptr)[11] < P_1.Length)
			{
				((int*)ptr)[12] = P_1[((int*)ptr)[11]];
				if (((int*)ptr)[12] != 0)
				{
					*(int*)ptr = array2[((int*)ptr)[12]];
					do
					{
						((int*)ptr)[13] = _0001(*(int*)ptr);
						if (((int*)ptr)[12] <= 9)
						{
							do
							{
								P_0._0001[((int*)ptr)[13]] = (short)((((int*)ptr)[11] << 4) | ((int*)ptr)[12]);
								((int*)ptr)[13] += 1 << ((int*)ptr)[12];
							}
							while (((int*)ptr)[13] < 512);
							continue;
						}
						((int*)ptr)[14] = P_0._0001[((int*)ptr)[13] & 0x1FF];
						((int*)ptr)[15] = 1 << (((int*)ptr)[14] & 0xF);
						((int*)ptr)[14] = -(((int*)ptr)[14] >> 4);
						do
						{
							P_0._0001[((int*)ptr)[14] | (((int*)ptr)[13] >> 9)] = (short)((((int*)ptr)[11] << 4) | ((int*)ptr)[12]);
							((int*)ptr)[13] += 1 << ((int*)ptr)[12];
						}
						while (((int*)ptr)[13] < ((int*)ptr)[15]);
					}
					while (false);
					array2[((int*)ptr)[12]] = *(int*)ptr + (1 << 16 - ((int*)ptr)[12]);
				}
				((int*)ptr)[11]++;
			}
		}

		static short _0001(int P_0)
		{
			return (short)((global::_0003._0003._0006._0001[P_0 & 0xF] << 12) | (global::_0003._0003._0006._0001[(P_0 >> 4) & 0xF] << 8) | (global::_0003._0003._0006._0001[(P_0 >> 8) & 0xF] << 4) | global::_0003._0003._0006._0001[P_0 >> 12]);
		}

		static void _0001(global::_0003._0003._0003 P_0, int P_1, int P_2)
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

		unsafe static int _0001(int P_0, global::_0003._0003._0001 P_1, byte[] P_2, int P_3)
		{
			void* ptr = stackalloc byte[8];
			*(int*)ptr = 0;
			int num;
			int num2;
			do
			{
				IL_0095:
				num = P_1._0001;
				num2 = 11;
				if (num2 == 0)
				{
					continue;
				}
				if (num != num2)
				{
					((int*)ptr)[1] = _0001(P_0, P_2, P_3, P_1._0001);
					P_3 += ((int*)ptr)[1];
					*(int*)ptr += ((int*)ptr)[1];
					P_0 -= ((int*)ptr)[1];
					if (P_0 == 0)
					{
						return *(int*)ptr;
					}
				}
				if (_0001(P_1))
				{
					goto IL_0095;
				}
				num = P_1._0001._0002;
				num2 = 0;
			}
			while (num > num2 && P_1._0001 != 11);
			return *(int*)ptr;
		}

		unsafe static bool _0001(global::_0003._0003._0001 P_0)
		{
			void* ptr = stackalloc byte[12];
			while (true)
			{
				int num = _0001(P_0._0001);
				while (true)
				{
					IL_01fd:
					int num2 = num;
					int num3 = 258;
					while (true)
					{
						int num4;
						if (num2 >= num3)
						{
							*(int*)ptr = P_0._0001;
							int num5;
							int num6;
							switch (*(int*)ptr)
							{
							case 7:
								while (((num4 = _0001(P_0._0001, P_0._0001)) & -256) == 0)
								{
									if (6u != 0)
									{
										_0001(P_0._0001, num4);
										if (--num >= 258)
										{
											continue;
										}
									}
									goto IL_0078;
								}
								if (num4 < 257)
								{
									goto IL_00a3;
								}
								goto IL_00c6;
							case 8:
								if (P_0._0002 > 0)
								{
									P_0._0001 = 8;
									((int*)ptr)[1] = _0001(P_0._0001, P_0._0002);
									if (((int*)ptr)[1] < 0)
									{
										return false;
									}
									if (false)
									{
										goto IL_00c6;
									}
									_0001(P_0._0001, P_0._0002);
									P_0._0003 += ((int*)ptr)[1];
								}
								P_0._0001 = 9;
								goto case 9;
							case 9:
								if (false)
								{
									goto end_IL_0203;
								}
								num4 = _0001(P_0._0002, P_0._0001);
								if (num4 < 0)
								{
									goto IL_0163;
								}
								P_0._0004 = global::_0003._0003._0001._0003[num4];
								P_0._0002 = global::_0003._0003._0001._0004[num4];
								goto case 10;
							case 10:
								{
									num5 = P_0._0002;
									num6 = 0;
									goto IL_0186;
								}
								IL_01d3:
								_0001(P_0._0001, P_0._0003, P_0._0004);
								num5 = num - P_0._0003;
								if (6u != 0)
								{
									num = num5;
									P_0._0001 = 7;
									break;
								}
								goto IL_01a9;
								IL_00c6:
								P_0._0003 = global::_0003._0003._0001._0001[num4 - 257];
								P_0._0002 = global::_0003._0003._0001._0002[num4 - 257];
								goto case 8;
								IL_0078:
								if (5u != 0)
								{
									return true;
								}
								goto IL_01a5;
								IL_0186:
								if (num5 > num6)
								{
									P_0._0001 = 10;
									((int*)ptr)[2] = _0001(P_0._0001, P_0._0002);
									goto IL_01a5;
								}
								goto IL_01d3;
								IL_01a5:
								num5 = ((int*)ptr)[2];
								goto IL_01a9;
								IL_01a9:
								num6 = 0;
								if (num6 != 0)
								{
									goto IL_0186;
								}
								if (num5 < num6)
								{
									return false;
								}
								_0001(P_0._0001, P_0._0002);
								P_0._0004 += ((int*)ptr)[2];
								goto IL_01d3;
							}
							goto IL_01fd;
						}
						return true;
						IL_00a3:
						num2 = num4;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						goto IL_00ab;
						IL_0163:
						return false;
						continue;
						end_IL_0203:
						break;
					}
					break;
					IL_00ab:
					if (num2 < num3)
					{
						return false;
					}
					P_0._0002 = null;
					P_0._0001 = null;
					P_0._0001 = 2;
					return true;
				}
			}
		}

		static void _0001(global::_0003._0003._0002 P_0, int P_1)
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

		static void _0001(global::_0003._0003._0003 P_0, int P_1, int P_2)
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

		static bool _0001(global::_0003._0003._0002 P_0)
		{
			return P_0._0001 == P_0._0002;
		}

		unsafe static int _0001(global::_0003._0003._0004 P_0, global::_0003._0003._0002 P_1)
		{
			void* ptr;
			int num3;
			int num2;
			if (0 == 0)
			{
				int num = 16;
				while (true)
				{
					ptr = stackalloc byte[num];
					if ((num2 = _0001(P_1, 9)) < 0)
					{
						break;
					}
					if ((num3 = P_0._0001[num2]) >= 0)
					{
						if (0 == 0)
						{
							_0001(P_1, num3 & 0xF);
							num = num3;
							if (0 == 0)
							{
								return num >> 4;
							}
							continue;
						}
						goto IL_00bb;
					}
					goto IL_014e;
				}
				((int*)ptr)[3] = P_1._0003;
				num2 = _0001(P_1, ((int*)ptr)[3]);
				goto IL_00f2;
			}
			goto IL_00fb;
			IL_00f2:
			num3 = P_0._0001[num2];
			goto IL_00fb;
			IL_00ff:
			if ((num3 & 0xF) <= ((int*)ptr)[3])
			{
				_0001(P_1, num3 & 0xF);
				return num3 >> 4;
			}
			goto IL_0118;
			IL_00bb:
			if (4u != 0)
			{
				if ((num3 & 0xF) <= ((int*)ptr)[2])
				{
					_0001(P_1, num3 & 0xF);
					if (0 == 0)
					{
						return num3 >> 4;
					}
					goto IL_00f2;
				}
				return -1;
			}
			goto IL_00ff;
			IL_0118:
			return -1;
			IL_014e:
			*(int*)ptr = -(num3 >> 4);
			((int*)ptr)[1] = num3 & 0xF;
			if ((num2 = _0001(P_1, ((int*)ptr)[1])) >= 0)
			{
				num3 = P_0._0001[*(int*)ptr | (num2 >> 9)];
				_0001(P_1, num3 & 0xF);
				return num3 >> 4;
			}
			((int*)ptr)[2] = P_1._0003;
			num2 = _0001(P_1, ((int*)ptr)[2]);
			num3 = P_0._0001[*(int*)ptr | (num2 >> 9)];
			goto IL_00bb;
			IL_00fb:
			if (num3 >= 0)
			{
				goto IL_00ff;
			}
			goto IL_0118;
		}

		static void _0001(string P_0, int P_1)
		{
			try
			{
				object obj;
				do
				{
					obj = _0004._0002._0001;
				}
				while (false);
				global::_0015_0002._0092_0002(obj);
				try
				{
					do
					{
						if (4u != 0)
						{
							_0004._0002._0001.Add(P_1, P_0);
						}
					}
					while (false);
				}
				finally
				{
					if (0 == 0)
					{
						global::_0015_0002._0093_0002(obj);
					}
				}
			}
			catch
			{
			}
		}

		unsafe static int _0001(int P_0, byte[] P_1, int P_2, global::_0003._0003._0003 P_3)
		{
			void* ptr = stackalloc byte[12];
			int num;
			int num2;
			while (true)
			{
				*(int*)ptr = P_3._0001;
				num = P_0;
				num2 = P_3._0002;
				if (1 == 0)
				{
					break;
				}
				if (6u != 0)
				{
					if (num > num2)
					{
						P_0 = P_3._0002;
					}
					else
					{
						*(int*)ptr = (P_3._0001 - P_3._0002 + P_0) & 0x7FFF;
					}
					((int*)ptr)[1] = P_0;
					if (false)
					{
						continue;
					}
					if (0 == 0)
					{
						((int*)ptr)[2] = P_0 - *(int*)ptr;
						num = ((int*)ptr)[2];
						num2 = 0;
						if (num2 != 0)
						{
							goto IL_00a2;
						}
						if (num <= num2)
						{
							goto IL_00a9;
						}
						Array.Copy(P_3._0001, 32768 - ((int*)ptr)[2], P_1, P_2, ((int*)ptr)[2]);
					}
					num = P_2;
					num2 = ((int*)ptr)[2];
				}
				goto IL_00a2;
				IL_00a2:
				P_2 = num + num2;
				P_0 = *(int*)ptr;
				goto IL_00a9;
				IL_00a9:
				Array.Copy(P_3._0001, *(int*)ptr - P_0, P_1, P_2, P_0);
				P_3._0002 -= ((int*)ptr)[1];
				num = P_3._0002;
				num2 = 0;
				break;
			}
			if (num < num2)
			{
				throw new InvalidOperationException();
			}
			return ((int*)ptr)[1];
		}

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
						cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(P_1, P_2);
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
					cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(P_1, P_2);
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

		static string _0001(int P_0)
		{
			int num = P_0;
			byte[] array = _0004._0002._0001;
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
						num8 = ((num5 & 0x1F) << 24) + (_0004._0002._0001[num++] << 16);
						while (true)
						{
							num7 = num8 + (_0004._0002._0001[num++] << 8);
							if (false)
							{
								break;
							}
							num8 = num7 + _0004._0002._0001[num++];
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
						num10 = _0004._0002._0001[num++];
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
				byte[] array2 = global::_0018_0002._0096_0002(global::_0017_0002._007E_0095_0002(global::_0016_0002._0094_0002(), _0004._0002._0001, num, num6));
				string text = global::_0019_0002._0097_0002(global::_0017_0002._007E_0095_0002(global::_0016_0002._0094_0002(), array2, 0, array2.Length));
				if (_0004._0002._0001)
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

		unsafe static int _0001(global::_0003._0003._0002 P_0, byte[] P_1, int P_2, int P_3)
		{
			void* ptr = stackalloc byte[12];
			*(int*)ptr = 0;
			while (P_0._0003 > 0 && P_3 > 0)
			{
				P_1[P_2++] = (byte)P_0._0001;
				P_0._0001 >>= 8;
				P_0._0003 -= 8;
				P_3--;
				(*(int*)ptr)++;
			}
			if (P_3 == 0)
			{
				return *(int*)ptr;
			}
			((int*)ptr)[1] = P_0._0002 - P_0._0001;
			if (P_3 > ((int*)ptr)[1])
			{
				P_3 = ((int*)ptr)[1];
			}
			Array.Copy(P_0._0001, P_0._0001, P_1, P_2, P_3);
			P_0._0001 += P_3;
			if (((P_0._0001 - P_0._0002) & 1) != 0)
			{
				byte[] array = P_0._0001;
				((int*)ptr)[2] = P_0._0001;
				P_0._0001 = ((int*)ptr)[2] + 1;
				P_0._0001 = (uint)(array[((int*)ptr)[2]] & 0xFF);
				P_0._0003 = 8;
			}
			return *(int*)ptr + P_3;
		}
	}
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	internal sealed class _0001 : Attribute
	{
	}
}
namespace _0004
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0001 : Attribute
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
namespace _0002
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0007
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0002
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
namespace _0004
{
	internal class _0002
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
							num2 = _0004._0002.m__0001;
						}
					}
					while (false);
					P_0 = num - num2;
					num = (_0004._0002._0001 ? 1 : 0);
				}
				if (num == 0 && 0 == 0)
				{
					return _0007._0003._0001(P_0);
				}
				return _0007._0003._0001(P_0);
			}
		}

		private static readonly string m__0001;

		private static readonly string m__0002;

		internal static readonly byte[] _0001;

		internal static readonly Dictionary<int, string> _0001;

		internal static readonly object _0001;

		internal static readonly bool _0001;

		private static readonly int m__0001;

		public static string _0001(int P_0)
		{
			return _0004._0002._0001._0001(P_0);
		}

		static _0002()
		{
			_0004._0002.m__0001 = "1";
			m__0002 = "169";
			if (3u != 0)
			{
				_0004._0002._0001 = null;
				_0004._0002._0001 = new object();
				_0004._0002._0001 = false;
			}
			while (true)
			{
				_0004._0002.m__0001 = 0;
				bool num = global::_0014._001F(_0004._0002.m__0001, "1");
				int num4;
				do
				{
					if (num)
					{
						if (4 == 0)
						{
							return;
						}
						_0004._0002._0001 = true;
						_0004._0002._0001 = new Dictionary<int, string>();
					}
					int num2 = global::_0011._001B(m__0002);
					if (false)
					{
						continue;
					}
					_0004._0002.m__0001 = num2;
					Stream stream = global::_0080_0002._007E_0007_0003(global::_007F_0002._0006_0003(), "{163c7c6e-2694-4892-9368-a495d655cdb5}");
					try
					{
						int num3 = global::_0081_0002._0008_0003(global::_001B_0002._007E_009B_0002(stream));
						byte[] array = new byte[num3];
						while (true)
						{
							global::_0082_0002._007E_000E_0003(stream, array, 0, num3);
							while (0 == 0)
							{
								_0004._0002._0001 = _0007._0003._0001(array);
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
							global::_001C._007E_0092(stream);
						}
					}
				}
				while (num4 != 0);
			}
		}
	}
}
namespace _0006
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal sealed class _0001 : Attribute
	{
	}
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0003
{
	internal enum _0002
	{
		_0001,
		_0002,
		_0003,
		_0004
	}
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
				global::_0007._0003._0001(0, P_0.Length, this._0001, P_0);
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
						global::_0003._0003._0001._0001 = array;
						while (0 == 0)
						{
							global::_0003._0003._0001._0002 = new int[29]
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
						global::_0003._0003._0001._0004 = array2;
						goto IL_0059;
						IL_002e:
						global::_0003._0003._0001._0003 = new int[30]
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
				global::_0007._0003._0001(this, P_0);
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
						global::_0003._0003._0005._0001 = array;
						while (0 == 0)
						{
							num = 3;
							if (num != 0)
							{
								int[] array2 = new int[num];
								RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
								global::_0003._0003._0005._0002 = array2;
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
							_0001[num] = global::_0007._0003._0001(48 + num << 8);
							goto IL_0071;
						}
						goto IL_00b8;
						IL_00ab:
						_0006._0002[num++] = 9;
						goto IL_00b8;
						IL_00b8:
						if (num < 256)
						{
							_0001[num] = global::_0007._0003._0001(256 + num << 7);
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
									_0001[num] = global::_0007._0003._0001(-88 + num << 8);
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
										_0002[num] = global::_0007._0003._0001(num << 11);
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
							_0001[num] = global::_0007._0003._0001(-256 + num << 9);
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
}
namespace _0005
{
	[CompilerGenerated]
	internal sealed class _0001
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

		internal static readonly _0002 _0001/* Not supported: data(41 76 2A 10 3C 87 B7 A1 3B 46 61 5F B0 97 77 A0) */;

		internal static readonly _0004 _0001/* Not supported: data(03 00 00 00 04 00 00 00 05 00 00 00 06 00 00 00 07 00 00 00 08 00 00 00 09 00 00 00 0A 00 00 00 0B 00 00 00 0D 00 00 00 0F 00 00 00 11 00 00 00 13 00 00 00 17 00 00 00 1B 00 00 00 1F 00 00 00 23 00 00 00 2B 00 00 00 33 00 00 00 3B 00 00 00 43 00 00 00 53 00 00 00 63 00 00 00 73 00 00 00 83 00 00 00 A3 00 00 00 C3 00 00 00 E3 00 00 00 02 01 00 00) */;

		internal static readonly _0001 _0001/* Not supported: data(02 00 00 00 03 00 00 00 07 00 00 00) */;

		internal static readonly _0002 _0002/* Not supported: data(00 08 04 0C 02 0A 06 0E 01 09 05 0D 03 0B 07 0F) */;

		internal static readonly _0005 _0001/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 06 00 00 00 06 00 00 00 07 00 00 00 07 00 00 00 08 00 00 00 08 00 00 00 09 00 00 00 09 00 00 00 0A 00 00 00 0A 00 00 00 0B 00 00 00 0B 00 00 00 0C 00 00 00 0C 00 00 00 0D 00 00 00 0D 00 00 00) */;

		internal static readonly _0003 _0001/* Not supported: data(10 00 00 00 11 00 00 00 12 00 00 00 00 00 00 00 08 00 00 00 07 00 00 00 09 00 00 00 06 00 00 00 0A 00 00 00 05 00 00 00 0B 00 00 00 04 00 00 00 0C 00 00 00 03 00 00 00 0D 00 00 00 02 00 00 00 0E 00 00 00 01 00 00 00 0F 00 00 00) */;

		internal static readonly _0002 _0003/* Not supported: data(C9 50 5E 72 EB A0 33 72 F7 43 30 FA 32 CA D0 5F) */;

		internal static readonly _0001 _0002/* Not supported: data(03 00 00 00 03 00 00 00 0B 00 00 00) */;

		internal static readonly _0004 _0002/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 00 00 00 00) */;

		internal static readonly _0005 _0002/* Not supported: data(01 00 00 00 02 00 00 00 03 00 00 00 04 00 00 00 05 00 00 00 07 00 00 00 09 00 00 00 0D 00 00 00 11 00 00 00 19 00 00 00 21 00 00 00 31 00 00 00 41 00 00 00 61 00 00 00 81 00 00 00 C1 00 00 00 01 01 00 00 81 01 00 00 01 02 00 00 01 03 00 00 01 04 00 00 01 06 00 00 01 08 00 00 01 0C 00 00 01 10 00 00 01 18 00 00 01 20 00 00 01 30 00 00 01 40 00 00 01 60 00 00) */;
	}
}
