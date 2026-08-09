using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using _0003;
using _0004;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buComm.FTP;
using buComm.ModbusTCP;
using buComm.UdpNetworkVars;

namespace _0004
{
	[CompilerGenerated]
	internal sealed class _0001
	{
		internal static readonly int _0001/* Not supported: data(00 2D 53 33) */;
	}
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	internal sealed class _0001 : Attribute
	{
	}
}
namespace _0005
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0005
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0004
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0001
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	internal class _0003 : Attribute
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
							num2 = global::_0003._0002.m__0001;
						}
					}
					while (false);
					P_0 = num - num2;
					num = (global::_0003._0002._0001 ? 1 : 0);
				}
				if (num == 0 && 0 == 0)
				{
					return _0005._0004._0001(P_0);
				}
				return _0005._0004._0001(P_0);
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
			return global::_0003._0002._0001._0001(P_0);
		}

		static _0002()
		{
			global::_0003._0002.m__0001 = "1";
			m__0002 = "120";
			if (3u != 0)
			{
				global::_0003._0002._0001 = null;
				global::_0003._0002._0001 = new object();
				global::_0003._0002._0001 = false;
			}
			while (true)
			{
				global::_0003._0002.m__0001 = 0;
				bool num = global::_0001._0002(global::_0003._0002.m__0001, "1");
				int num4;
				do
				{
					if (num)
					{
						if (4 == 0)
						{
							return;
						}
						global::_0003._0002._0001 = true;
						global::_0003._0002._0001 = new Dictionary<int, string>();
					}
					int num2 = _008C_0002._001F_0003(m__0002);
					if (false)
					{
						continue;
					}
					global::_0003._0002.m__0001 = num2;
					Stream stream = _008E_0002._007E_0080_0003(_008D_0002._007F_0003(), "{f8511b9e-22b8-40b1-adf3-f8736d139c4f}");
					try
					{
						int num3 = _0090_0002._0083_0003(_008F_0002._007E_0081_0003(stream));
						byte[] array = new byte[num3];
						while (true)
						{
							_0080_0002._007E_0011_0003(stream, array, 0, num3);
							while (0 == 0)
							{
								global::_0003._0002._0001 = _0005._0004._0001(array);
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
							_0011._007E_0089(stream);
						}
					}
				}
				while (num4 != 0);
			}
		}
	}
}
namespace _0007
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal sealed class _0001 : Attribute
	{
	}
}
namespace _0003
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class _0003 : Attribute
	{
	}
}
namespace _0005
{
	internal enum _0003
	{
		_0001,
		_0002,
		_0003,
		_0004
	}
}
namespace _0004
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
				global::_0005._0004._0001(P_0.Length, 0, this._0001, P_0);
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
						global::_0004._0003._0001._0001 = array;
						while (0 == 0)
						{
							global::_0004._0003._0001._0002 = new int[29]
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
						global::_0004._0003._0001._0004 = array2;
						goto IL_0059;
						IL_002e:
						global::_0004._0003._0001._0003 = new int[30]
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
				global::_0005._0004._0001(P_0, this);
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
						global::_0004._0003._0005._0001 = array;
						while (0 == 0)
						{
							num = 3;
							if (num != 0)
							{
								int[] array2 = new int[num];
								RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
								global::_0004._0003._0005._0002 = array2;
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
							_0001[num] = global::_0005._0004._0001(48 + num << 8);
							goto IL_0071;
						}
						goto IL_00b8;
						IL_00ab:
						_0006._0002[num++] = 9;
						goto IL_00b8;
						IL_00b8:
						if (num < 256)
						{
							_0001[num] = global::_0005._0004._0001(256 + num << 7);
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
									_0001[num] = global::_0005._0004._0001(-88 + num << 8);
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
										_0002[num] = global::_0005._0004._0001(num << 11);
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
							_0001[num] = global::_0005._0004._0001(-256 + num << 9);
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
	internal class _0004
	{
		[NonSerialized]
		internal static GetString _0010;

		static void _0001(int P_0, FTPControlSocket P_1)
		{
			bool flag = default(bool);
			while (true)
			{
				if (2 == 0)
				{
					return;
				}
				P_1._0001 = P_0;
				if (7 == 0)
				{
					continue;
				}
				bool num = P_1._0001 == null;
				if (0 == 0)
				{
					flag = num;
				}
				if (flag)
				{
					if (0 == 0)
					{
						throw new SystemException(_0010(107393885));
					}
					return;
				}
				if (5u != 0)
				{
					break;
				}
			}
			_0001(P_1, P_1._0001, P_1._0001);
		}

		static byte[] _0001(Master P_0, ushort P_1, byte P_2, ushort P_3, ushort P_4, ushort P_5, ushort P_6)
		{
			byte[] array = new byte[P_6 * 2 + 17];
			byte[] array2 = _0084._0002_0002((short)P_1);
			array[0] = array2[1];
			array[1] = array2[0];
			byte[] array3;
			do
			{
				array3 = _0084._0002_0002(_0091_0002._0084_0003((short)(11 + P_6 * 2)));
				array[4] = array3[0];
			}
			while (false);
			array[5] = array3[1];
			array[6] = P_2;
			array[7] = 23;
			byte[] array4 = _0084._0002_0002(_0091_0002._0084_0003((short)P_3));
			array[8] = array4[0];
			array[9] = array4[1];
			byte[] array5 = _0084._0002_0002(_0091_0002._0084_0003((short)P_4));
			array[10] = array5[0];
			array[11] = array5[1];
			byte[] array6 = _0084._0002_0002(_0091_0002._0084_0003((short)P_5));
			array[12] = array6[0];
			array[13] = array6[1];
			byte[] array7 = _0084._0002_0002(_0091_0002._0084_0003((short)P_6));
			array[14] = array7[0];
			array[15] = array7[1];
			array[16] = (byte)(P_6 * 2);
			return array;
		}

		static string _0001(int P_0)
		{
			int num = P_0;
			byte[] array = global::_0003._0002._0001;
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
						num8 = ((num5 & 0x1F) << 24) + (global::_0003._0002._0001[num++] << 16);
						while (true)
						{
							num7 = num8 + (global::_0003._0002._0001[num++] << 8);
							if (false)
							{
								break;
							}
							num8 = num7 + global::_0003._0002._0001[num++];
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
						num10 = global::_0003._0002._0001[num++];
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
				byte[] array2 = _0092_0002._0086_0003(_009D._007E_0086_0002(_0017._0093(), global::_0003._0002._0001, num, num6));
				string text = _0093_0002._0087_0003(_009D._007E_0086_0002(_0017._0093(), array2, 0, array2.Length));
				if (global::_0003._0002._0001)
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

		static global::_0004._0003._0004 _0001(global::_0004._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0003];
			Array.Copy(P_0._0002, P_0._0002, array, 0, P_0._0003);
			return new global::_0004._0003._0004(array);
		}

		static int _0001(global::_0004._0003._0007 P_0)
		{
			return P_0.ReadByte() | (P_0.ReadByte() << 8);
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncWriteVar_ToPlc")]
		static extern unsafe uint _0001(byte* P_0, byte* P_1);

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_DisConnect")]
		static extern void _0001();

		static void _0001(Master P_0, ushort P_1, byte P_2, byte P_3, byte P_4)
		{
			bool num;
			int num2;
			if (3u != 0)
			{
				bool flag = P_0._0001 == null || P_0._0002 == null;
				num = flag;
				if (0 == 0)
				{
					if (num)
					{
						return;
					}
					num2 = P_4;
					goto IL_0030;
				}
				goto IL_0063;
			}
			goto IL_009f;
			IL_009f:
			P_0._0001 = null;
			goto IL_0055;
			IL_0063:
			if (num)
			{
				P_0._0001(P_1, P_2, P_3, P_4);
			}
			return;
			IL_0055:
			num2 = ((P_0._0001 != null) ? 1 : 0);
			goto IL_005e;
			IL_0030:
			if (3 == 0)
			{
				goto IL_005e;
			}
			if (num2 != 254 || 7 == 0)
			{
				goto IL_0055;
			}
			P_0._0002 = null;
			goto IL_009f;
			IL_005e:
			if (-1 == 0)
			{
				goto IL_0030;
			}
			bool flag2 = (byte)num2 != 0;
			num = flag2;
			goto IL_0063;
		}

		static FTPReply _0001(string P_0, string P_1, FTPControlSocket P_2)
		{
			string text = _009E._007E_0087_0002(P_1, 0, 3);
			string text2 = _0094_0002._007E_0088_0003(P_1, 4);
			FTPReply result;
			if (2u != 0)
			{
				result = new FTPReply(text, text2);
				if (!_0084_0002._007E_0015_0003(text, P_0))
				{
					throw new FTPException(text2, text);
				}
			}
			return result;
		}

		static void _0001(FTPControlSocket P_0)
		{
			NetworkStream stream = new NetworkStream(P_0._0001, ownsSocket: true);
			P_0._0001 = new StreamWriter(stream);
			P_0._0001 = new StreamReader(stream);
		}

		static global::_0004._0003._0004 _0001(global::_0004._0003._0005 P_0)
		{
			byte[] array = new byte[P_0._0002];
			Array.Copy(P_0._0002, 0, array, 0, P_0._0002);
			return new global::_0004._0003._0004(array);
		}

		static void _0001(FTPControlSocket P_0, Socket P_1, int P_2)
		{
			bool flag = default(bool);
			while (true)
			{
				IL_0001:
				if (4 == 0)
				{
					goto IL_002e;
				}
				bool num = P_2 > 0;
				goto IL_0053;
				IL_0056:
				num = flag;
				if (6 == 0)
				{
					goto IL_0053;
				}
				if (num)
				{
					_009F obj = _009F._007E_0088_0002;
					if (uint.MaxValue != 0)
					{
						obj(P_1, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, P_2);
					}
					goto IL_002e;
				}
				break;
				IL_002e:
				_009F._007E_0088_0002(P_1, SocketOptionLevel.Socket, SocketOptionName.SendTimeout, P_2);
				while (uint.MaxValue != 0)
				{
					if (1 == 0)
					{
						goto IL_0001;
					}
					if (0 == 0)
					{
						return;
					}
				}
				goto IL_0056;
				IL_0053:
				flag = num;
				goto IL_0056;
			}
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarDINTFromPlc2")]
		static extern unsafe int _0001(string[] P_0, int P_1, int* P_2, byte* P_3);

		static void _0001(string P_0, Stream P_1, FTPClient P_2)
		{
			if (0 == 0)
			{
				_0001(P_0, P_2);
			}
			StreamWriter streamWriter = new StreamWriter(P_1);
			StreamReader streamReader;
			if (0 == 0)
			{
				streamReader = new StreamReader(_0001(P_2));
			}
			IOException ex = null;
			string text = null;
			try
			{
				while (true)
				{
					if (uint.MaxValue != 0)
					{
						if ((text = global::_0005._007E_0013(streamReader)) == null)
						{
							break;
						}
						_0095_0002._007E_0089_0003(streamWriter, text, 0, _000E._007E_0019(text));
						_0011._007E_008A(streamWriter);
					}
				}
			}
			catch (IOException ex2)
			{
				ex = ex2;
			}
			finally
			{
				while (1 == 0)
				{
				}
				_0011._007E_0088(streamWriter);
			}
			try
			{
				do
				{
					_0011._007E_0086(streamReader);
				}
				while (3 == 0);
			}
			catch (IOException ex3)
			{
				_0082_0002._0013_0003(_0010(107397313), _0010(107394667), global::_0005._007E_0012(_0081_0002._0012_0003()));
				_008F._0014_0002(ex3, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _0010(107397313));
			}
			if (ex != null)
			{
				throw ex;
			}
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceAddress")]
		static extern unsafe void _0001(byte* P_0);

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_GetState")]
		static extern int _0001();

		static byte[] _0001(byte[] P_0, ushort P_1, Master P_2)
		{
			bool num = global::_0003._007E_0006(P_2._0002);
			bool flag = default(bool);
			if (0 == 0)
			{
				flag = num;
			}
			if (flag)
			{
				try
				{
					_0096_0002._007E_008A_0003(P_2._0002, P_0, 0, P_0.Length, SocketFlags.None);
					int num2 = _0096_0002._007E_008B_0003(P_2._0002, P_2._0002, 0, P_2._0002.Length, SocketFlags.None);
					byte b;
					byte b2;
					if (0 == 0)
					{
						int num3 = num2;
						b = P_2._0002[6];
						b2 = P_2._0002[7];
						if (num3 == 0)
						{
							_0001(P_2, P_1, b, P_0[7], (byte)254);
						}
						bool flag2 = b2 > 128;
						num2 = (flag2 ? 1 : 0);
					}
					if (num2 != 0)
					{
						b2 -= 128;
						_0001(P_2, P_1, b, b2, P_2._0002[8]);
						return null;
					}
					byte[] array;
					if (b2 >= 5 && b2 != 23)
					{
						array = new byte[2];
						_0095._001E_0002(P_2._0002, 10, array, 0, 2);
					}
					else
					{
						array = new byte[P_2._0002[8]];
						_0095._001E_0002(P_2._0002, 9, array, 0, P_2._0002[8]);
					}
					return array;
				}
				catch (SystemException)
				{
					_0001(P_2, P_1, P_0[6], P_0[7], (byte)254);
				}
			}
			else
			{
				_0001(P_2, P_1, P_0[6], P_0[7], (byte)254);
			}
			return null;
		}

		static void _0001(Master P_0, byte[] P_1, ushort P_2)
		{
			if (P_0._0001 != null && global::_0003._007E_0006(P_0._0001))
			{
				try
				{
					_0097_0002._007E_008C_0003(P_0._0001, P_1, 0, P_1.Length, SocketFlags.None, P_0._0001, null);
					_0097_0002._007E_008D_0003(P_0._0001, P_0._0001, 0, P_0._0001.Length, SocketFlags.None, P_0._0002, P_0._0001);
				}
				catch (SystemException)
				{
					_0001(P_0, P_2, P_1[6], P_1[7], (byte)254);
				}
			}
			else
			{
				_0001(P_0, P_2, P_1[6], P_1[7], (byte)254);
			}
			while (3 == 0)
			{
			}
		}

		static string _0001(FTPControlSocket P_0)
		{
			string text = global::_0005._007E_0013(P_0._0001);
			int num;
			if (text != null)
			{
				num = _000E._007E_0019(text);
				goto IL_0030;
			}
			if (false)
			{
				goto IL_01c3;
			}
			int num2 = 1;
			goto IL_0210;
			IL_01d2:
			StringBuilder stringBuilder;
			return global::_0005._007E_0011(stringBuilder);
			IL_007b:
			bool flag;
			string text2;
			char num3;
			if (0 == 0)
			{
				if (flag)
				{
					_0012_0002._007E_0098_0002(P_0._0001, global::_0005._007E_0011(stringBuilder));
				}
				text2 = _009E._007E_0087_0002(global::_0005._007E_0011(stringBuilder), 0, 3);
				num3 = _0089_0002._007E_001B_0003(stringBuilder, 3);
				goto IL_00c5;
			}
			goto IL_0168;
			IL_01c3:
			bool flag2;
			string text3;
			bool flag3;
			if (!flag2)
			{
				text3 = global::_0005._007E_0013(P_0._0001);
				flag3 = text3 == null;
				goto IL_00f5;
			}
			goto IL_01d2;
			IL_0030:
			num2 = ((num == 0) ? 1 : 0);
			goto IL_0210;
			IL_0210:
			bool flag4 = (byte)num2 != 0;
			while (true)
			{
				IL_0216:
				if (flag4)
				{
					throw new IOException(_0010(107393828));
				}
				if (false)
				{
					break;
				}
				stringBuilder = new StringBuilder(text);
				while (true)
				{
					num = (P_0._0001 ? 1 : 0);
					if (false)
					{
						break;
					}
					flag = (byte)num != 0;
					if (false)
					{
						goto IL_0216;
					}
					if (1 == 0)
					{
						continue;
					}
					goto IL_007b;
				}
				goto IL_0030;
			}
			goto IL_00f5;
			IL_00c5:
			if (num3 == '-')
			{
				flag2 = false;
				goto IL_01c3;
			}
			goto IL_01d2;
			IL_00f5:
			if (flag3)
			{
				throw new IOException(_0010(107393828));
			}
			if (P_0._0001)
			{
				_0012_0002._007E_0098_0002(P_0._0001, text3);
			}
			bool num4;
			if (_000E._007E_0019(text3) > 3 && _0084_0002._007E_0015_0003(_009E._007E_0087_0002(text3, 0, 3), text2))
			{
				num4 = _0089_0002._007E_001A_0003(text3, 3) == ' ';
				goto IL_0168;
			}
			goto IL_0197;
			IL_0197:
			_0098_0002._007E_008E_0003(stringBuilder, _0010(107393787));
			_0098_0002._007E_008E_0003(stringBuilder, text3);
			goto IL_01c3;
			IL_0168:
			if (false)
			{
				goto IL_00c5;
			}
			if (!num4)
			{
				goto IL_0197;
			}
			_0098_0002._007E_008E_0003(stringBuilder, _0094_0002._007E_0088_0003(text3, 3));
			flag2 = true;
			goto IL_01c3;
		}

		static Socket _0001(FTPControlSocket P_0, FTPConnectMode P_1)
		{
			bool flag = P_1 == FTPConnectMode.ACTIVE;
			if (3u != 0)
			{
				if (6 == 0)
				{
					goto IL_002a;
				}
				if (!flag && 0 == 0)
				{
					return P_0._0001();
				}
			}
			if (0 == 0)
			{
				return _0001(P_0);
			}
			goto IL_002a;
			IL_002a:
			Socket result = default(Socket);
			return result;
		}

		static int _0001(global::_0004._0003._0004 P_0, global::_0004._0003._0002 P_1)
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

		static void _0001(global::_0004._0003._0003 P_0, int P_1)
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

		static int _0001(global::_0004._0003._0002 P_0, int P_1)
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

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceName")]
		static extern unsafe void _0001(byte* P_0);

		static bool _0001(global::_0004._0003._0001 P_0)
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
								global::_0004._0003._0003 obj = P_0._0001;
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
							P_0._0003 = global::_0004._0003._0001._0001[num5 - 257];
							P_0._0002 = global::_0004._0003._0001._0002[num5 - 257];
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
							P_0._0004 = global::_0004._0003._0001._0003[num5];
							P_0._0002 = global::_0004._0003._0001._0004[num5];
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

		static byte[] _0001(ushort P_0, ushort P_1, ushort P_2, Master P_3, byte P_4, byte P_5)
		{
			byte[] array = new byte[12];
			byte[] array2 = _0084._0002_0002((short)P_1);
			array[0] = array2[1];
			array[1] = array2[0];
			byte[] array4;
			if (uint.MaxValue != 0)
			{
				array[5] = 6;
				array[6] = P_5;
				array[7] = P_4;
				do
				{
					byte[] array3 = _0084._0002_0002(_0091_0002._0084_0003((short)P_0));
					array[8] = array3[0];
					array[9] = array3[1];
					array4 = _0084._0002_0002(_0091_0002._0084_0003((short)P_2));
				}
				while (8 == 0);
				array[10] = array4[0];
			}
			array[11] = array4[1];
			return array;
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarBOOLFromPlc")]
		static extern unsafe int _0001(string[] P_0, int P_1, bool* P_2);

		static string _0001(int P_0)
		{
			object obj = global::_0003._0002._0001;
			_0099_0002._008F_0003(obj);
			string result = default(string);
			try
			{
				global::_0003._0002._0001.TryGetValue(P_0, out var value);
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
					_0099_0002._0090_0003(obj);
				}
				while (false);
			}
			return _0001(P_0);
			IL_0061:
			return result;
		}

		static void _0001(IPEndPoint P_0, FTPControlSocket P_1)
		{
			byte[] array = _009B_0002._0092_0003(_008F_0002._007E_0082_0003(_009A_0002._007E_0091_0003(P_0)));
			byte[] array2 = P_1.ToByteArray((ushort)_000E._007E_001B(P_0));
			string text = global::_0005._007E_0011(_009C_0002._007E_0093_0003(_0098_0002._007E_008E_0003(_009C_0002._007E_0093_0003(_0098_0002._007E_008E_0003(_009C_0002._007E_0093_0003(_0098_0002._007E_008E_0003(_009C_0002._007E_0093_0003(_0098_0002._007E_008E_0003(_009C_0002._007E_0093_0003(_0098_0002._007E_008E_0003(_009C_0002._0093_0003(new StringBuilder(_0010(107393750)), array[0]), _0010(107393741)), array[1]), _0010(107393741)), array[2]), _0010(107393741)), array[3]), _0010(107393741)), array2[0]), _0010(107393741)), array2[1]));
			string text2 = _0001(P_1, text);
			_0001(_0010(107394705), text2, P_1);
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarLREALFromPlc")]
		static extern unsafe int _0001(string[] P_0, int P_1, double* P_2, byte* P_3);

		static int _0001(int P_0, byte[] P_1, int P_2, global::_0004._0003._0003 P_3)
		{
			int num = P_3._0001;
			int num2;
			if (P_0 <= P_3._0002)
			{
				num2 = P_3._0001;
				goto IL_00e1;
			}
			P_0 = P_3._0002;
			goto IL_0057;
			IL_008a:
			Array.Copy(P_3._0001, num - P_0, P_1, P_2, P_0);
			int num3;
			P_3._0002 -= num3;
			goto IL_00a9;
			IL_007f:
			int num4 = P_2;
			int num6;
			int num5 = num6;
			goto IL_0081;
			IL_0057:
			do
			{
				num3 = P_0;
			}
			while (3 == 0);
			num2 = P_0;
			if (false)
			{
				goto IL_00e1;
			}
			num6 = num2 - num;
			while (num6 > 0)
			{
				Array.Copy(P_3._0001, 32768 - num6, P_1, P_2, num6);
				if (false)
				{
					continue;
				}
				goto IL_007f;
			}
			goto IL_008a;
			IL_00a9:
			if (P_3._0002 < 0)
			{
				throw new InvalidOperationException();
			}
			if (3u != 0)
			{
				return num3;
			}
			goto IL_0057;
			IL_00e1:
			num4 = num2 - P_3._0002;
			num5 = P_0;
			if (0 == 0)
			{
				num = (num4 + num5) & 0x7FFF;
				goto IL_0057;
			}
			goto IL_0081;
			IL_0081:
			P_2 = num4 + num5;
			if (4u != 0)
			{
				P_0 = num;
				goto IL_008a;
			}
			goto IL_00a9;
		}

		static int _0001(global::_0004._0003._0007 P_0)
		{
			return _0001(P_0) | (_0001(P_0) << 16);
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarINTFromPlc")]
		static extern unsafe int _0001(string[] P_0, int P_1, short* P_2);

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Log")]
		static extern int _0001();

		static double _0001(byte[] P_0)
		{
			return _009C._0084_0002(P_0, 0);
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarREALFromPlc")]
		static extern unsafe int _0001(string[] P_0, int P_1, float* P_2, byte* P_3);

		static bool _0001(global::_0004._0003._0005 P_0, global::_0004._0003._0002 P_1)
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
					int num6 = global::_0004._0003._0005._0002[P_0._0006];
					int num7 = _0001(P_1, num6);
					if (num7 < 0)
					{
						return false;
					}
					_0001(P_1, num6);
					num7 += global::_0004._0003._0005._0001[P_0._0006];
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
					P_0._0001 = new global::_0004._0003._0004(P_0._0001);
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
					P_0._0001[global::_0004._0003._0005._0003[P_0._0007]] = (byte)num2;
					P_0._0007++;
					goto case 3;
				}
				continue;
				IL_027e:
				P_0._0001 = 4;
			}
		}

		static int _0001(global::_0004._0003._0002 P_0)
		{
			return P_0._0003;
		}

		static bool _0001(global::_0004._0003._0002 P_0)
		{
			return P_0._0001 == P_0._0002;
		}

		static void _0001(global::_0004._0003._0002 P_0)
		{
			P_0._0001 >>= P_0._0003 & 7;
			P_0._0003 &= -8;
		}

		static bool _0001(global::_0004._0003._0001 P_0)
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
								P_0._0001 = global::_0004._0003._0004._0001;
								P_0._0002 = global::_0004._0003._0004._0002;
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
									P_0._0001 = new global::_0004._0003._0005();
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

		static void _0001(string P_0, FTPClient P_1)
		{
			P_1._0001 = _0001(P_1._0001, P_1._0001);
			string text = _0001(P_1._0001, global::_0002._0003(_0010(107393768), P_0));
			string[] array = new string[2]
			{
				_0010(107394658),
				_0010(107394653)
			};
			P_1._0001 = _0001(text, array, P_1._0001);
		}

		static void _0001(global::_0004._0003._0002 P_0, int P_1)
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

		static int _0001(global::_0004._0003._0003 P_0, global::_0004._0003._0002 P_1, int P_2)
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

		static short _0001(int P_0)
		{
			return (short)((global::_0004._0003._0006._0001[P_0 & 0xF] << 12) | (global::_0004._0003._0006._0001[(P_0 >> 4) & 0xF] << 8) | (global::_0004._0003._0006._0001[(P_0 >> 8) & 0xF] << 4) | global::_0004._0003._0006._0001[P_0 >> 12]);
		}

		static int _0001(NetVars P_0, int P_1)
		{
			int num = default(int);
			if (0 == 0)
			{
				num = 0;
			}
			int num2 = 0;
			int num3;
			if (true)
			{
				num3 = 0;
			}
			int num6 = default(int);
			while (true)
			{
				int num4 = num3;
				int num5 = P_0._0001.Count;
				while (true)
				{
					int num7;
					if (!(num4 < num5 && num3 < P_1))
					{
						num6 = checked((int)_009D_0002._0095_0003((double)num / 256.0));
						num7 = num;
						goto IL_0343;
					}
					int num8 = num;
					bool num9 = (P_0._0001[num3].DataTypes == DataTypes.booltype) | (P_0._0001[num3].DataTypes == DataTypes.bytetype);
					bool num10 = P_0._0001[num3].DataTypes == DataTypes.sinttype;
					if (8u != 0)
					{
						if ((num9 || num10) | (P_0._0001[num3].DataTypes == DataTypes.usintType))
						{
							num = checked(num + 1);
							num2 = num;
						}
						if ((P_0._0001[num3].DataTypes == DataTypes.wordtype) | (P_0._0001[num3].DataTypes == DataTypes.inttype) | (P_0._0001[num3].DataTypes == DataTypes.uinttype))
						{
							num = checked(num + 2);
							int num11 = num;
							if ((num11 % 256 <= num8 % 256) & (num11 % 256 != 0))
							{
								num = checked((int)(256.0 * _009D_0002._0094_0003((double)num8 / 256.0)) + 2);
							}
						}
						num9 = (P_0._0001[num3].DataTypes == DataTypes.dwordtype) | (P_0._0001[num3].DataTypes == DataTypes.udinttype);
						num10 = P_0._0001[num3].DataTypes == DataTypes.dinttype;
					}
					if ((num9 || num10) | (P_0._0001[num3].DataTypes == DataTypes.realtype))
					{
						num = checked(num + 4);
						int num12 = num;
						num4 = ((num12 % 256 <= num8 % 256) ? 1 : 0);
						num5 = num12;
						if (false)
						{
							continue;
						}
						if (((uint)num4 & ((num5 % 256 != 0) ? 1u : 0u)) != 0)
						{
							checked
							{
								num7 = (int)(256.0 * _009D_0002._0094_0003((double)num8 / 256.0));
								if (false)
								{
									goto IL_0343;
								}
								num = num7 + 4;
							}
						}
					}
					int num13;
					int num15;
					int num16;
					if (P_0._0001[num3].DataTypes == DataTypes.lrealtype)
					{
						num = checked(num + 8);
						num13 = num;
						if (false)
						{
							goto IL_0364;
						}
						int num14 = num13;
						num15 = num14 % 256;
						num16 = num8 % 256;
						if (false)
						{
							goto IL_02a9;
						}
						if ((num15 <= num16) & (num14 % 256 != 0))
						{
							num = checked((int)(256.0 * _009D_0002._0094_0003((double)num8 / 256.0)) + 8);
						}
					}
					if (P_0._0001[num3].DataTypes != DataTypes.stringtype)
					{
						break;
					}
					num = checked(num + P_0._0001[num3].FieldLength + 1);
					int num17 = num;
					num15 = num17;
					num16 = 256;
					goto IL_02a9;
					IL_0363:
					num13 = num6;
					goto IL_0364;
					IL_035d:
					int num18;
					num7 = checked(num7 - num18);
					if (false)
					{
						goto IL_0343;
					}
					num6 = num7;
					goto IL_0363;
					IL_0351:
					bool num19;
					int num20;
					int num21;
					if (((uint)num19 & ((num20 > num21) ? 1u : 0u)) != 0)
					{
						num7 = num6;
						num18 = 1;
						goto IL_035d;
					}
					goto IL_0363;
					IL_02a9:
					num19 = num15 % num16 <= num8 % 256;
					num20 = num17 % 256;
					num21 = 0;
					if (num21 == 0)
					{
						if (num19 && (uint)num20 > (uint)num21)
						{
							num = checked((int)(256.0 * _009D_0002._0094_0003((double)num8 / 256.0)) + P_0._0001[num3].FieldLength + 1);
						}
						break;
					}
					goto IL_0351;
					IL_0364:
					return num13;
					IL_0343:
					num18 = 256;
					if (num18 != 0)
					{
						num19 = num7 % num18 == 0;
						num20 = num6;
						num21 = 0;
						goto IL_0351;
					}
					goto IL_035d;
				}
				num3 = checked(num3 + 1);
			}
		}

		static byte[] _0001(byte[] P_0)
		{
			global::_0004._0003._0007 obj = new global::_0004._0003._0007(P_0);
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
						switch ((_0003)num4)
						{
						case _0003._0002:
							goto IL_006a;
						case _0003._0004:
						{
							byte[] array3 = new byte[16]
							{
								8, 21, 46, 191, 104, 164, 62, 45, 94, 109,
								120, 143, 90, 137, 40, 234
							};
							byte[] array4 = new byte[16]
							{
								70, 30, 75, 67, 177, 165, 48, 75, 143, 127,
								83, 91, 223, 126, 246, 158
							};
							if (false)
							{
								goto default;
							}
							ICryptoTransform cryptoTransform = _0001(array4, array3, true);
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
						byte[] array5;
						if (0 == 0)
						{
							if (num7 >= num5)
							{
								break;
							}
							int num8 = _0001(obj);
							num9 = _0001(obj);
							array5 = new byte[num8];
							if (-1 == 0)
							{
								goto end_IL_017c;
							}
							obj.Read(array5, 0, array5.Length);
							num7 = num9;
						}
						_0001(num7, new global::_0004._0003._0001(array5), array2, num6);
						num6 += num9;
					}
					goto IL_0156;
					continue;
					end_IL_017c:
					break;
				}
			}
		}

		static string _0001(FTPControlSocket P_0, string P_1)
		{
			while (true)
			{
				bool num = P_0._0001;
				while (true)
				{
					bool flag = num;
					if (5u != 0)
					{
						num = flag;
						if (true)
						{
							if (8 == 0)
							{
								continue;
							}
							if (num)
							{
								_0012_0002._007E_0098_0002(P_0._0001, global::_0002._0003(_0010(107393759), P_1));
							}
							_0012_0002._007E_0099_0002(P_0._0001, global::_0002._0003(P_1, _0010(107394230)));
							if (6 == 0)
							{
								break;
							}
							_0011._007E_0087(P_0._0001);
							num = global::_0001._0002(P_1, _0010(107393973));
						}
						if (!num)
						{
							return _0001(P_0);
						}
					}
					if (4u != 0)
					{
						return _0010(107393973);
					}
					string result;
					return result;
				}
			}
		}

		static void _0001(StreamWriter P_0, FTPControlSocket P_1)
		{
			bool num;
			while (true)
			{
				if (8u != 0)
				{
					num = P_0 != null;
					if (false)
					{
						break;
					}
					bool flag = num;
					if (0 == 0)
					{
						num = flag;
						break;
					}
				}
			}
			if (num && 0 == 0)
			{
				P_1._0001 = P_0;
			}
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_ConnectByIP")]
		static extern int _0001();

		static NetworkStream _0001(FTPClient P_0)
		{
			if (8 == 0)
			{
				goto IL_0021;
			}
			Socket socket = P_0._0001;
			bool flag = P_0._0001 == FTPConnectMode.ACTIVE;
			goto IL_0051;
			IL_0061:
			NetworkStream result = new NetworkStream(socket, ownsSocket: true);
			if (0 == 0)
			{
				return result;
			}
			goto IL_001d;
			IL_0051:
			if (flag)
			{
				goto IL_001d;
			}
			goto IL_0061;
			IL_001d:
			if (3 == 0)
			{
			}
			goto IL_0021;
			IL_0021:
			if (1 == 0)
			{
				goto IL_0051;
			}
			socket = _0090._007E_0016_0002(P_0._0001);
			goto IL_0061;
		}

		static void _0001(string P_0, FTPClient P_1, bool P_2, Stream P_3)
		{
			BufferedStream bufferedStream;
			if (true)
			{
				bufferedStream = new BufferedStream(P_3);
				if (0 == 0)
				{
					_0001(P_2, P_0, P_1);
					goto IL_00dc;
				}
			}
			goto IL_004b;
			IL_005e:
			byte[] array = default(byte[]);
			int num = default(int);
			if ((num = _0080_0002._007E_0011_0003(bufferedStream, array, 0, array.Length)) > 0)
			{
				goto IL_004b;
			}
			_0011._007E_0084(bufferedStream);
			BinaryWriter binaryWriter = default(BinaryWriter);
			_0011._007E_0082(binaryWriter);
			if (true)
			{
				_0011._007E_0083(binaryWriter);
			}
			if (4 == 0)
			{
				goto IL_00dc;
			}
			if (4u != 0)
			{
				return;
			}
			goto IL_003b;
			IL_004b:
			do
			{
				_007F_0002._007E_000E_0003(binaryWriter, array, 0, num);
			}
			while (4 == 0);
			goto IL_005e;
			IL_00dc:
			binaryWriter = new BinaryWriter(_0001(P_1));
			goto IL_003b;
			IL_003b:
			array = new byte[512];
			num = 0;
			goto IL_005e;
		}

		static void _0001(string P_0, int P_1)
		{
			try
			{
				object obj;
				do
				{
					obj = global::_0003._0002._0001;
				}
				while (false);
				_0099_0002._008F_0003(obj);
				try
				{
					do
					{
						if (4u != 0)
						{
							global::_0003._0002._0001.Add(P_1, P_0);
						}
					}
					while (false);
				}
				finally
				{
					if (0 == 0)
					{
						_0099_0002._0090_0003(obj);
					}
				}
			}
			catch
			{
			}
		}

		static void _0001(bool P_0, FTPControlSocket P_1)
		{
			P_1._0001 = P_0;
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarDINTFromPlc")]
		static extern unsafe int _0001(string[] P_0, int P_1, int* P_2);

		static int _0001(int P_0, global::_0004._0003._0001 P_1, byte[] P_2, int P_3)
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
			goto IL_009b;
			IL_0031:
			int num3;
			int num4;
			P_3 = num3 + num4;
			goto IL_0034;
			IL_0034:
			num3 = num2;
			int num5 = default(int);
			if (5u != 0)
			{
				num2 = num3 + num5;
				P_0 -= num5;
				if (P_0 == 0)
				{
					return num2;
				}
				goto IL_0045;
			}
			goto IL_0058;
			IL_0073:
			num3 = P_1._0001;
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
			num = _0001(P_0, P_2, P_3, P_1._0001);
			goto IL_009b;
			IL_0045:
			if (_0001(P_1))
			{
				goto IL_0073;
			}
			num3 = P_1._0001._0002;
			goto IL_0058;
			IL_0058:
			num4 = 0;
			if (num4 != 0)
			{
				goto IL_0015;
			}
			if (num3 > num4 && P_1._0001 != 11)
			{
				goto IL_0073;
			}
			return num2;
			IL_009b:
			num5 = num;
			num3 = P_3;
			num4 = num5;
			goto IL_0031;
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarBOOLFromPlc2")]
		static extern unsafe int _0001(string[] P_0, int P_1, byte* P_2, byte* P_3);

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Init")]
		static extern int _0001();

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarSTRINGFromPlc")]
		static extern unsafe int _0001(string[] P_0, byte* P_1);

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SymbolsCount")]
		static extern uint _0001();

		static void _0001(string P_0, bool P_1, string P_2, FTPClient P_3)
		{
			do
			{
				if (8 == 0 || 5 == 0)
				{
					return;
				}
			}
			while (false);
			FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read);
			Stream stream;
			if (4u != 0)
			{
				stream = fileStream;
			}
			if (2u != 0)
			{
				if (5u != 0)
				{
					_0001(P_2, P_3, P_1, stream);
				}
			}
		}

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceIP")]
		static extern unsafe void _0001(byte* P_0);

		static ushort _0001(ushort P_0)
		{
			if (6u != 0)
			{
				int num = P_0;
				int num2 = 65280;
				do
				{
					num = (num & num2) >> 8;
					int num3 = P_0;
					int num4 = 255;
					do
					{
						if (num4 != 0)
						{
							num3 &= num4;
							num4 = 8;
						}
					}
					while (num4 == 0);
					num2 = num3 << num4;
				}
				while (3 == 0);
				return (ushort)(num | num2);
			}
			ushort result;
			return result;
		}

		static FTPReply _0001(string P_0, string[] P_1, FTPControlSocket P_2)
		{
			string text;
			string text2;
			FTPReply result;
			int num;
			int num2;
			if (global::_0001._0002(P_0, _0010(107393973)))
			{
				if (7u != 0)
				{
					return new FTPReply(_0010(107397313), _0010(107397313));
				}
			}
			else
			{
				do
				{
					text = _009E._007E_0087_0002(P_0, 0, 3);
				}
				while (false);
				text2 = _0094_0002._007E_0088_0003(P_0, 4);
				result = new FTPReply(text, text2);
				num = 0;
				if (num != 0)
				{
					goto IL_00a3;
				}
				num2 = num;
			}
			goto IL_00aa;
			IL_00aa:
			num = num2;
			nint num3 = (nint)P_1.LongLength;
			goto IL_00ae;
			IL_00ae:
			if (0 == 0)
			{
				num3 = (int)num3;
			}
			bool num4 = num < num3;
			do
			{
				bool flag = num4;
				num4 = flag;
			}
			while (false);
			if (num4)
			{
				if (_0084_0002._007E_0015_0003(text, P_1[num2]))
				{
					return result;
				}
				num = num2;
				goto IL_00a3;
			}
			throw new FTPException(text2, text);
			IL_00a3:
			num3 = 1;
			if (true)
			{
				num2 = num + 1;
				goto IL_00aa;
			}
			goto IL_00ae;
		}

		static void _0001(int P_0, int P_1, global::_0004._0003._0002 P_2, byte[] P_3)
		{
			int num;
			if (true)
			{
				if (P_2._0001 < P_2._0002)
				{
					throw new InvalidOperationException();
				}
				num = P_1 + P_0;
				if (0 > P_1 || P_1 > num || num > P_3.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((P_0 & 1) == 0)
				{
					goto IL_0087;
				}
				P_2._0001 |= (uint)((P_3[P_1++] & 0xFF) << P_2._0003);
			}
			P_2._0003 += 8;
			goto IL_0087;
			IL_0087:
			P_2._0001 = P_3;
			P_2._0001 = P_1;
			P_2._0002 = num;
		}

		static byte[] _0001(Master P_0, ushort P_1, byte P_2, ushort P_3, ushort P_4, ushort P_5, byte P_6)
		{
			int num = P_5;
			byte[] array;
			do
			{
				array = new byte[num + 11];
				do
				{
					byte[] array2 = _0084._0002_0002((short)P_1);
					array[0] = array2[1];
					array[1] = array2[0];
					byte[] array3 = _0084._0002_0002(_0091_0002._0084_0003((short)(5 + P_5)));
					array[4] = array3[0];
					array[5] = array3[1];
					array[6] = P_2;
				}
				while (7 == 0);
				array[7] = P_6;
				byte[] array4 = _0084._0002_0002(_0091_0002._0084_0003((short)P_3));
				array[8] = array4[0];
				array[9] = array4[1];
				num = ((P_6 >= 15) ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				byte[] array5 = _0084._0002_0002(_0091_0002._0084_0003((short)P_4));
				array[10] = array5[0];
				array[11] = array5[1];
				array[12] = (byte)(P_5 - 2);
			}
			return array;
		}

		static void _0001(global::_0004._0003._0003 P_0, int P_1, int P_2)
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

		static void _0001(string P_0, FTPClient P_1, string P_2)
		{
			_0001(P_0, P_1);
			while (true)
			{
				FileInfo fileInfo = new FileInfo(P_2);
				if (false)
				{
					break;
				}
				BinaryWriter binaryWriter = new BinaryWriter(new FileStream(P_2, FileMode.OpenOrCreate));
				IOException ex;
				bool flag;
				do
				{
					BinaryReader binaryReader = new BinaryReader(_0001(P_1));
					int num = 4096;
					if (0 == 0)
					{
						byte[] array = new byte[num];
						ex = null;
						try
						{
							if (0 == 0)
							{
							}
							int num2;
							while ((num2 = _0080_0002._007E_0010_0003(binaryReader, array, 0, array.Length)) > 0)
							{
								_007F_0002._007E_000E_0003(binaryWriter, array, 0, num2);
							}
						}
						catch (IOException ex2)
						{
							ex = ex2;
						}
						finally
						{
							_0011._007E_0083(binaryWriter);
							if (ex != null && _009E_0002._0096_0003(global::_0005._007E_000E(fileInfo)))
							{
								_009F_0002._0097_0003(global::_0005._007E_000E(fileInfo));
							}
							while (2 == 0)
							{
							}
						}
					}
					try
					{
						do
						{
							_0011._007E_001E(binaryReader);
						}
						while (false);
					}
					catch (IOException ex3)
					{
						_0082_0002._0013_0003(_0010(107397313), _0010(107394667), global::_0005._007E_0012(_0081_0002._0012_0003()));
						_008F._0014_0002(ex3, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _0010(107397313));
					}
					flag = ex != null;
				}
				while (false);
				if (flag)
				{
					if (5 == 0)
					{
						continue;
					}
					throw ex;
				}
				break;
			}
		}

		static void _0001(bool P_0, string P_1, FTPClient P_2)
		{
			P_2._0001 = _0001(P_2._0001, P_2._0001);
			int num = (P_0 ? 1 : 0);
			string text2;
			if (0 == 0)
			{
				string text = ((num != 0) ? _0010(107394248) : _0010(107394225));
				if (false)
				{
					goto IL_009d;
				}
				text2 = _0001(P_2._0001, global::_0002._0003(text, P_1));
				num = 2;
			}
			string[] array = new string[num];
			array[0] = _0010(107394658);
			array[1] = _0010(107394653);
			string[] array2 = array;
			goto IL_009d;
			IL_009d:
			P_2._0001 = _0001(text2, array2, P_2._0001);
		}

		static int _0001(global::_0004._0003._0003 P_0)
		{
			return 32768 - P_0._0002;
		}

		static void _0001(Stream P_0, FTPClient P_1, bool P_2, string P_3)
		{
			if (false)
			{
				goto IL_0160;
			}
			StreamReader streamReader = new StreamReader(P_0);
			_0001(P_2, P_3, P_1);
			StreamWriter streamWriter = new StreamWriter(_0001(P_1));
			FTPConnect.SendPersentage = 0.0;
			int num = 1000;
			if (FTPConnect.TotalLineCount > 0)
			{
				num = _0001_0003._0098_0003((double)FTPConnect.TotalLineCount / 100.0);
			}
			string text = null;
			goto IL_018e;
			IL_018e:
			while (true)
			{
				if ((text = global::_0005._007E_0013(streamReader)) != null)
				{
					_0095_0002._007E_0089_0003(streamWriter, text, 0, _000E._007E_0019(text));
					_0095_0002._007E_0089_0003(streamWriter, _0010(107394230), 0, _000E._0019(_0010(107394230)));
					if (-1 == 0)
					{
						continue;
					}
					FTPConnect.SentLineCount++;
					if (FTPConnect.SentLineCount % num != 0)
					{
						continue;
					}
					if (false)
					{
						return;
					}
					if (FTPConnect.TotalLineCount > 0)
					{
						FTPConnect.SendPersentage = (double)FTPConnect.SentLineCount / (double)FTPConnect.TotalLineCount;
						if (P_1._0001 != null)
						{
							break;
						}
					}
					continue;
				}
				_0011._007E_0086(streamReader);
				_0011._007E_0087(streamWriter);
				_0011._007E_0088(streamWriter);
				return;
			}
			FtpFileSendEventArg ftpFileSendEventArg = new FtpFileSendEventArg();
			ftpFileSendEventArg.ActualLineIndex = FTPConnect.SentLineCount;
			ftpFileSendEventArg.TotalLineCount = FTPConnect.TotalLineCount;
			goto IL_0160;
			IL_0160:
			ftpFileSendEventArg.SendPersentage = FTPConnect.SendPersentage;
			_0002_0003._007E_0099_0003(P_1._0001, ftpFileSendEventArg);
			_0003_0003._009A_0003();
			goto IL_018e;
		}

		static void _0001(global::_0004._0003._0003 P_0, int P_1, int P_2)
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

		static int _0001(global::_0004._0003._0002 P_0, byte[] P_1, int P_2, int P_3)
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

		static void _0001(string P_0, Stream P_1, FTPClient P_2)
		{
			_0001(P_0, P_2);
			BinaryWriter binaryWriter = new BinaryWriter(P_1);
			BinaryReader binaryReader;
			if (0 == 0)
			{
				binaryReader = new BinaryReader(_0001(P_2));
			}
			int num = 4096;
			if (num != 0)
			{
				int num2 = num;
				num = num2;
			}
			byte[] array = new byte[num];
			IOException ex = null;
			try
			{
				if (7 == 0)
				{
					goto IL_004c;
				}
				goto IL_005e;
				IL_005e:
				int num3 = default(int);
				if ((num3 = _0080_0002._007E_0010_0003(binaryReader, array, 0, array.Length)) > 0)
				{
					goto IL_004c;
				}
				goto end_IL_0046;
				IL_004c:
				_007F_0002._007E_000E_0003(binaryWriter, array, 0, num3);
				goto IL_005e;
				end_IL_0046:;
			}
			catch (IOException ex2)
			{
				ex = ex2;
			}
			finally
			{
				while (1 == 0)
				{
				}
				_0011._007E_0083(binaryWriter);
			}
			if (0 == 0)
			{
				try
				{
					do
					{
						_0011._007E_001E(binaryReader);
					}
					while (3 == 0);
				}
				catch (IOException ex3)
				{
					_0082_0002._0013_0003(_0010(107397313), _0010(107394667), global::_0005._007E_0012(_0081_0002._0012_0003()));
					_008F._0014_0002(ex3, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _0010(107397313));
				}
			}
			if (ex != null)
			{
				throw ex;
			}
		}

		static void _0001(FTPClient P_0)
		{
			string[] array = default(string[]);
			if (7u != 0 && 0 == 0)
			{
				if (5 == 0)
				{
					goto IL_0073;
				}
				array = new string[2]
				{
					_0010(107394611),
					_0010(107394606)
				};
			}
			if (false)
			{
				return;
			}
			string text = _0001(P_0._0001);
			goto IL_0073;
			IL_0073:
			P_0._0001 = _0001(text, array, P_0._0001);
		}

		static Socket _0001(FTPControlSocket P_0)
		{
			Socket result;
			while (true)
			{
				Socket socket;
				if (7u != 0)
				{
					socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					goto IL_0014;
				}
				goto IL_00b3;
				IL_0014:
				IPHostEntry iPHostEntry = _0018_0002._009F_0002(_0004_0003._009B_0003());
				IPEndPoint iPEndPoint = new IPEndPoint(_0019_0002._007E_0001_0003(iPHostEntry)[0], 0);
				_001B_0002._007E_0004_0003(socket, iPEndPoint);
				if (false)
				{
					continue;
				}
				_0091._007E_0019_0002(socket, 5);
				int num = _000E._007E_001B((IPEndPoint)_0005_0003._007E_009C_0003(socket));
				IPAddress iPAddress = _009A_0002._007E_0091_0003((IPEndPoint)_0005_0003._007E_009C_0003(socket));
				_0001((IPEndPoint)_0005_0003._007E_009C_0003(socket), P_0);
				goto IL_00b3;
				IL_00b3:
				result = socket;
				if (0 == 0)
				{
					break;
				}
				goto IL_0014;
			}
			return result;
		}

		static bool _0001(string P_0, List<string> P_1, List<double> P_2, List<string> P_3, string P_4)
		{
			if (false)
			{
				goto IL_00cb;
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			int num5;
			if ((P_3.Count > 0) & (P_1.Count > 0))
			{
				num5 = 0;
				goto IL_020c;
			}
			throw new RegisterException(P_0);
			IL_020c:
			int num6 = num5;
			int num7 = P_3.Count - 1;
			if (0 == 0)
			{
				num6 = ((num6 > num7) ? 1 : 0);
				num7 = 0;
			}
			int num8;
			if (num6 == num7)
			{
				num = 0.0;
				num2 = 0.0;
				num3 = 0.0;
				num8 = 0;
				goto IL_00cb;
			}
			throw new RegisterException(P_0);
			IL_00cb:
			int num9;
			while (true)
			{
				IL_00cb_2:
				num9 = ((num8 <= P_3[num5].Length - 1) ? 1 : 0);
				while (true)
				{
					double num10;
					if (num9 != 0)
					{
						string value = P_3[num5].Substring(num8, 1);
						num10 = (int)Convert.ToByte(Convert.ToChar(value));
						goto IL_00b3;
					}
					int num11 = 0;
					int num12;
					int num18;
					while (true)
					{
						bool flag = num11 <= P_1[0].Length - 1;
						num12 = (flag ? 1 : 0);
						int num13;
						int num19;
						while (true)
						{
							IL_0145:
							if (num12 != 0)
							{
								string value2 = P_1[0].Substring(num11, 1);
								num13 = Convert.ToByte(Convert.ToChar(value2));
								if (0 == 0)
								{
									break;
								}
								goto IL_0195;
							}
							int num14 = 0;
							goto IL_017e;
							IL_0195:
							if (num13 != 0)
							{
								string value3 = P_4.Substring(num14, 1);
								double num15 = (int)Convert.ToByte(Convert.ToChar(value3));
								num3 += num15 * 51.95;
								num14++;
								goto IL_017e;
							}
							num4 = (num + num2 + num3) * 9.912;
							int num16 = 0;
							while (num16 <= P_2.Count - 1)
							{
								double num17 = Math.Abs(P_2[num16] - num4);
								if (num17 < 0.0001)
								{
									return true;
								}
								num12 = num16;
								if (1 == 0)
								{
									goto IL_0145;
								}
								num18 = 1;
								if (num18 != 0)
								{
									num16 = num12 + num18;
									continue;
								}
								goto IL_00c8;
							}
							goto end_IL_012c;
							IL_017e:
							num19 = ((num14 <= P_4.Length - 1) ? 1 : 0);
							if (4 == 0)
							{
								goto IL_0128;
							}
							bool flag2 = (byte)num19 != 0;
							num13 = (flag2 ? 1 : 0);
							goto IL_0195;
						}
						num10 = num13;
						if (0 == 0)
						{
							double num20 = num10;
							num2 += num20 * 47.93;
							num19 = num11;
							goto IL_0128;
						}
						goto IL_00b3;
						IL_0128:
						num11 = num19 + 1;
						continue;
						end_IL_012c:
						break;
					}
					num9 = num5;
					if (0 == 0)
					{
						break;
					}
					continue;
					IL_00c8:
					num8 = num12 + num18;
					goto IL_00cb_2;
					IL_00b3:
					double num21 = num10;
					num += num21 * 17.92;
					num12 = num8;
					num18 = 1;
					goto IL_00c8;
				}
				break;
			}
			num5 = num9 + 1;
			goto IL_020c;
		}

		static void _0001(byte[] P_0, global::_0004._0003._0004 P_1)
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

		static int _0001(global::_0004._0003._0002 P_0)
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

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Connect")]
		static extern int _0001();

		[DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_GetSymbols")]
		static extern unsafe uint _0001(int P_0, byte* P_1, ref int P_2);

		static int _0001(global::_0004._0003._0003 P_0)
		{
			return P_0._0002;
		}

		static ICryptoTransform _0001(byte[] P_0, byte[] P_1, bool P_2)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			try
			{
				ICryptoTransform result;
				while (true)
				{
					ICryptoTransform cryptoTransform;
					if (0 == 0 && !P_2)
					{
						if (false)
						{
							continue;
						}
						cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(P_1, P_0);
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
					cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(P_1, P_0);
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

		static void _0001(FTPControlSocket P_0)
		{
			if (0 == 0)
			{
			}
			string text2 = default(string);
			do
			{
				IL_0004:
				if (6u != 0)
				{
					string text = _0001(P_0);
					if (0 == 0)
					{
						text2 = text;
					}
					if (3 == 0)
					{
						goto IL_0004;
					}
					_0001(_0010(107394239), text2, P_0);
				}
			}
			while (false);
		}

		static void _0001(bool P_0, FTPClient P_1, string P_2, string P_3)
		{
			do
			{
				if (8 == 0 || 5 == 0)
				{
					return;
				}
			}
			while (false);
			FileStream fileStream = new FileStream(P_2, FileMode.Open, FileAccess.Read);
			Stream stream;
			if (4u != 0)
			{
				stream = fileStream;
			}
			if (2u != 0)
			{
				if (5u != 0)
				{
					_0001(stream, P_1, P_0, P_3);
				}
			}
		}

		static void _0001(string P_0, string P_1, FTPClient P_2)
		{
			_0001(P_0, P_2);
			FileInfo fileInfo = new FileInfo(P_1);
			FileInfo fileInfo2 = default(FileInfo);
			if (0 == 0)
			{
				fileInfo2 = fileInfo;
			}
			StreamWriter streamWriter = new StreamWriter(P_1);
			StreamReader streamReader = new StreamReader(_0001(P_2));
			IOException ex = null;
			string text = null;
			try
			{
				while (true)
				{
					IL_007e:
					bool num = (text = global::_0005._007E_0013(streamReader)) != null;
					while (true)
					{
						bool flag = num;
						while (true)
						{
							num = flag;
							if (8 == 0)
							{
								break;
							}
							if (num)
							{
								if (false)
								{
									continue;
								}
								goto IL_0048;
							}
							goto end_IL_008f;
						}
						continue;
						IL_0048:
						_0095_0002._007E_0089_0003(streamWriter, text, 0, _000E._007E_0019(text));
						if (4u != 0)
						{
							_0011._007E_008A(streamWriter);
						}
						goto IL_007e;
						continue;
						end_IL_008f:
						break;
					}
					break;
				}
			}
			catch (IOException ex2)
			{
				if (0 == 0)
				{
					ex = ex2;
				}
			}
			finally
			{
				_0011._007E_0088(streamWriter);
				if (ex != null && _009E_0002._0096_0003(global::_0005._007E_000E(fileInfo2)))
				{
					_009F_0002._0097_0003(global::_0005._007E_000E(fileInfo2));
				}
			}
			try
			{
				_0011._007E_0086(streamReader);
			}
			catch (IOException ex3)
			{
				do
				{
					_0082_0002._0013_0003(_0010(107397313), _0010(107394667), global::_0005._007E_0012(_0081_0002._0012_0003()));
				}
				while (6 == 0);
				_008F._0014_0002(ex3, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _0010(107397313));
			}
			bool num2 = ex != null;
			do
			{
				bool flag2 = num2;
				num2 = flag2;
			}
			while (false);
			if (num2 ? true : false)
			{
				throw ex;
			}
		}

		static void _0001(IPAddress P_0, int P_1, int P_2, StreamWriter P_3, FTPControlSocket P_4)
		{
			if (0 == 0)
			{
				_0001(P_3, P_4);
			}
			P_4._0001 = true;
			IPEndPoint iPEndPoint = new IPEndPoint(P_0, P_2);
			P_4._0001 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_0001(P_1, P_4);
			if (0 == 0)
			{
				_001B_0002._007E_0003_0003(P_4._0001, iPEndPoint);
				_0001(P_4);
			}
			_0001(P_4);
			P_4._0001 = false;
		}

		static _0004()
		{
			Strings.CreateGetStringDelegate(typeof(_0004));
		}
	}
}
namespace _0004
{
	[CompilerGenerated]
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

		internal static readonly _0002 _0001/* Not supported: data(46 1E 4B 43 B1 A5 30 4B 8F 7F 53 5B DF 7E F6 9E) */;

		internal static readonly _0004 _0001/* Not supported: data(03 00 00 00 04 00 00 00 05 00 00 00 06 00 00 00 07 00 00 00 08 00 00 00 09 00 00 00 0A 00 00 00 0B 00 00 00 0D 00 00 00 0F 00 00 00 11 00 00 00 13 00 00 00 17 00 00 00 1B 00 00 00 1F 00 00 00 23 00 00 00 2B 00 00 00 33 00 00 00 3B 00 00 00 43 00 00 00 53 00 00 00 63 00 00 00 73 00 00 00 83 00 00 00 A3 00 00 00 C3 00 00 00 E3 00 00 00 02 01 00 00) */;

		internal static readonly _0001 _0001/* Not supported: data(02 00 00 00 03 00 00 00 07 00 00 00) */;

		internal static readonly _0002 _0002/* Not supported: data(00 08 04 0C 02 0A 06 0E 01 09 05 0D 03 0B 07 0F) */;

		internal static readonly _0005 _0001/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 06 00 00 00 06 00 00 00 07 00 00 00 07 00 00 00 08 00 00 00 08 00 00 00 09 00 00 00 09 00 00 00 0A 00 00 00 0A 00 00 00 0B 00 00 00 0B 00 00 00 0C 00 00 00 0C 00 00 00 0D 00 00 00 0D 00 00 00) */;

		internal static readonly _0003 _0001/* Not supported: data(10 00 00 00 11 00 00 00 12 00 00 00 00 00 00 00 08 00 00 00 07 00 00 00 09 00 00 00 06 00 00 00 0A 00 00 00 05 00 00 00 0B 00 00 00 04 00 00 00 0C 00 00 00 03 00 00 00 0D 00 00 00 02 00 00 00 0E 00 00 00 01 00 00 00 0F 00 00 00) */;

		internal static readonly _0002 _0003/* Not supported: data(08 15 2E BF 68 A4 3E 2D 5E 6D 78 8F 5A 89 28 EA) */;

		internal static readonly _0001 _0002/* Not supported: data(03 00 00 00 03 00 00 00 0B 00 00 00) */;

		internal static readonly _0004 _0002/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 00 00 00 00) */;

		internal static readonly _0005 _0002/* Not supported: data(01 00 00 00 02 00 00 00 03 00 00 00 04 00 00 00 05 00 00 00 07 00 00 00 09 00 00 00 0D 00 00 00 11 00 00 00 19 00 00 00 21 00 00 00 31 00 00 00 41 00 00 00 61 00 00 00 81 00 00 00 C1 00 00 00 01 01 00 00 81 01 00 00 01 02 00 00 01 03 00 00 01 04 00 00 01 06 00 00 01 08 00 00 01 0C 00 00 01 10 00 00 01 18 00 00 01 20 00 00 01 30 00 00 01 40 00 00 01 60 00 00) */;
	}
}
