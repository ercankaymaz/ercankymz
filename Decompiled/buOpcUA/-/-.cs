using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using _0002;
using _0005;
using _0006;
using Opc.Ua;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buOpcUA;

namespace _0001
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	internal sealed class _0001 : Attribute
	{
	}
}
namespace _0003
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0002 : Attribute
	{
	}
}
namespace _0002
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0003
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0003 : Attribute
	{
	}
}
namespace _0005
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	internal class _0001 : Attribute
	{
	}
}
namespace _0003
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	internal class _0004 : Attribute
	{
	}
	internal sealed class _0001
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 116)]
		internal struct _0001
		{
		}

		internal static readonly _0001 _0001/* Not supported: data(01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 0E 00 0F 00 10 00 11 00 12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1A 00 1B 00 1C 00 1D 00 1E 00 1F 00 7F 00 80 00 81 00 82 00 83 00 84 00 86 00 87 00 88 00 89 00 8A 00 8B 00 8C 00 8D 00 8E 00 8F 00 90 00 91 00 92 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9A 00 9B 00 9C 00 9D 00 9E 00 9F 00) */;
	}
}
namespace _0005
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
							num2 = _0005._0002.m__0001;
						}
					}
					while (false);
					P_0 = num - num2;
					num = (_0005._0002._0001 ? 1 : 0);
				}
				if (num == 0 && 0 == 0)
				{
					return global::_0002._0003._0001(P_0);
				}
				return global::_0002._0003._0001(P_0);
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
			return _0005._0002._0001._0001(P_0);
		}

		static _0002()
		{
			_0005._0002.m__0001 = "1";
			m__0002 = "97";
			if (3u != 0)
			{
				_0005._0002._0001 = null;
				_0005._0002._0001 = new object();
				_0005._0002._0001 = false;
			}
			while (true)
			{
				_0005._0002.m__0001 = 0;
				bool num = _0084._008B(_0005._0002.m__0001, "1");
				int num4;
				do
				{
					if (num)
					{
						if (4 == 0)
						{
							return;
						}
						_0005._0002._0001 = true;
						_0005._0002._0001 = new Dictionary<int, string>();
					}
					int num2 = _0097._0001_0002(m__0002);
					if (false)
					{
						continue;
					}
					_0005._0002.m__0001 = num2;
					Stream stream = _0099._007E_0003_0002(_0098._0002_0002(), "{3bcae739-7deb-435a-9f3e-41ba545ee0c4}");
					try
					{
						int num3 = _009B._0005_0002(_009A._007E_0004_0002(stream));
						byte[] array = new byte[num3];
						while (true)
						{
							_009C._007E_0006_0002(stream, array, 0, num3);
							while (0 == 0)
							{
								_0005._0002._0001 = global::_0002._0003._0001(array);
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
							global::_0005._007E_0007(stream);
						}
					}
				}
				while (num4 != 0);
			}
		}
	}
}
namespace _0003
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
	internal sealed class _0005 : Attribute
	{
	}
}
namespace _0002
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class _0002 : Attribute
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
namespace _0006
{
	internal static class _0001
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
				global::_0002._0003._0001(P_0, this._0001, 0, P_0.Length);
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
						global::_0006._0001._0001._0001 = array;
						while (0 == 0)
						{
							global::_0006._0001._0001._0002 = new int[29]
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
						global::_0006._0001._0001._0004 = array2;
						goto IL_0059;
						IL_002e:
						global::_0006._0001._0001._0003 = new int[30]
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
				global::_0002._0003._0001(this, P_0);
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
						global::_0006._0001._0005._0001 = array;
						while (0 == 0)
						{
							num = 3;
							if (num != 0)
							{
								int[] array2 = new int[num];
								RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
								global::_0006._0001._0005._0002 = array2;
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
							_0001[num] = global::_0002._0003._0001(48 + num << 8);
							goto IL_0071;
						}
						goto IL_00b8;
						IL_00ab:
						_0006._0002[num++] = 9;
						goto IL_00b8;
						IL_00b8:
						if (num < 256)
						{
							_0001[num] = global::_0002._0003._0001(256 + num << 7);
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
									_0001[num] = global::_0002._0003._0001(-88 + num << 8);
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
										_0002[num] = global::_0002._0003._0001(num << 11);
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
							_0001[num] = global::_0002._0003._0001(-256 + num << 9);
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
namespace _0002
{
	internal class _0003
	{
		[NonSerialized]
		internal static GetString _008B;

		static int _0001(_0006._0001._0003 P_0)
		{
			return P_0._0002;
		}

		static int _0001(_0006._0001._0003 P_0)
		{
			return 32768 - P_0._0002;
		}

		static int _0001(_0006._0001._0002 P_0)
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

		static void _0001(_0006._0001._0002 P_0)
		{
			P_0._0001 >>= P_0._0003 & 7;
			P_0._0003 &= -8;
		}

		static bool _0001(_0006._0001._0002 P_0)
		{
			return P_0._0001 == P_0._0002;
		}

		static int _0001(_0006._0001._0007 P_0)
		{
			return _0001(P_0) | (_0001(P_0) << 16);
		}

		static bool _0001(_0006._0001._0005 P_0, _0006._0001._0002 P_1)
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
					int num6 = _0006._0001._0005._0002[P_0._0006];
					int num7 = _0001(P_1, num6);
					if (num7 < 0)
					{
						return false;
					}
					_0001(P_1, num6);
					num7 += _0006._0001._0005._0001[P_0._0006];
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
					P_0._0001 = new _0006._0001._0004(P_0._0001);
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
					P_0._0001[_0006._0001._0005._0003[P_0._0007]] = (byte)num2;
					P_0._0007++;
					goto case 3;
				}
				continue;
				IL_027e:
				P_0._0001 = 4;
			}
		}

		static ApplicationConfiguration _0001(OpcClient P_0)
		{
			ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration();
			_008C._007E_0093(applicationConfiguration, P_0._0001);
			_008D._007E_0095(applicationConfiguration, ApplicationType.Client);
			_008C._007E_0094(applicationConfiguration, _009E._0008_0002(_008B(107396165), new object[1] { _009D._0007_0002() }));
			_0090._007E_0098(applicationConfiguration, new SecurityConfiguration
			{
				AutoAcceptUntrustedCertificates = true
			});
			_0092._007E_009B(applicationConfiguration, new TransportQuotas
			{
				OperationTimeout = 120000
			});
			_0093._007E_009C(applicationConfiguration, new ClientConfiguration
			{
				DefaultSessionTimeout = 120000
			});
			_009F._007E_000E_0002(applicationConfiguration, new TraceConfiguration());
			return applicationConfiguration;
		}

		static void _0001(byte[] P_0, _0006._0001._0002 P_1, int P_2, int P_3)
		{
			int num;
			if (true)
			{
				if (P_1._0001 < P_1._0002)
				{
					throw new InvalidOperationException();
				}
				num = P_2 + P_3;
				if (0 > P_2 || P_2 > num || num > P_0.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((P_3 & 1) == 0)
				{
					goto IL_0087;
				}
				P_1._0001 |= (uint)((P_0[P_2++] & 0xFF) << P_1._0003);
			}
			P_1._0003 += 8;
			goto IL_0087;
			IL_0087:
			P_1._0001 = P_0;
			P_1._0001 = P_2;
			P_1._0002 = num;
		}

		static void _0001(_0006._0001._0003 P_0, int P_1)
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

		static void _0001(_0006._0001._0002 P_0, int P_1)
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

		static int _0001(_0006._0001._0002 P_0, byte[] P_1, int P_2, int P_3)
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

		static void _0001(_0006._0001._0003 P_0, int P_1, int P_2)
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

		static void _0001(int P_0, string P_1)
		{
			try
			{
				object obj;
				do
				{
					obj = _0005._0002._0001;
				}
				while (false);
				_0001_0002._000F_0002(obj);
				try
				{
					do
					{
						if (4u != 0)
						{
							_0005._0002._0001.Add(P_0, P_1);
						}
					}
					while (false);
				}
				finally
				{
					if (0 == 0)
					{
						_0001_0002._0010_0002(obj);
					}
				}
			}
			catch
			{
			}
		}

		static int _0001(_0006._0001._0002 P_0)
		{
			return P_0._0003;
		}

		static int _0001(_0006._0001._0007 P_0)
		{
			return P_0.ReadByte() | (P_0.ReadByte() << 8);
		}

		static short _0001(int P_0)
		{
			return (short)((_0006._0001._0006._0001[P_0 & 0xF] << 12) | (_0006._0001._0006._0001[(P_0 >> 4) & 0xF] << 8) | (_0006._0001._0006._0001[(P_0 >> 8) & 0xF] << 4) | _0006._0001._0006._0001[P_0 >> 12]);
		}

		static void _0001(_0006._0001._0003 P_0, int P_1, int P_2)
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

		static bool _0001(_0006._0001._0001 P_0)
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
								P_0._0001 = _0006._0001._0004._0001;
								P_0._0002 = _0006._0001._0004._0002;
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
									P_0._0001 = new _0006._0001._0005();
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

		static bool _0001(_0006._0001._0001 P_0)
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
								_0006._0001._0003 obj = P_0._0001;
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
							P_0._0003 = _0006._0001._0001._0001[num5 - 257];
							P_0._0002 = _0006._0001._0001._0002[num5 - 257];
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
							P_0._0004 = _0006._0001._0001._0003[num5];
							P_0._0002 = _0006._0001._0001._0004[num5];
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

		static int _0001(byte[] P_0, _0006._0001._0001 P_1, int P_2, int P_3)
		{
			int num = 0;
			int num5 = default(int);
			while (true)
			{
				int num2 = P_1._0001;
				while (true)
				{
					if (num2 == 11)
					{
						goto IL_0054;
					}
					int num3 = P_3;
					goto IL_008e;
					IL_007a:
					return num;
					IL_0054:
					if (_0001(P_1))
					{
						break;
					}
					int num4;
					if (P_1._0001._0002 > 0)
					{
						num3 = P_1._0001;
						num4 = 11;
						goto IL_0072;
					}
					goto IL_007a;
					IL_0045:
					num = num3 + num4;
					P_2 -= num5;
					num3 = P_2;
					if (false)
					{
						goto IL_008e;
					}
					if (num3 == 0)
					{
						return num;
					}
					goto IL_0054;
					IL_008e:
					num4 = P_2;
					if (6u != 0)
					{
						if (false)
						{
							goto IL_0072;
						}
						num2 = _0001(num3, num4, P_0, P_1._0001);
						if (-1 == 0)
						{
							continue;
						}
						num5 = num2;
						P_3 += num5;
						num3 = num;
						num4 = num5;
					}
					goto IL_0045;
					IL_0072:
					if (num4 == 0)
					{
						goto IL_0045;
					}
					if (num3 != num4)
					{
						break;
					}
					goto IL_007a;
				}
			}
		}

		static int _0001(_0006._0001._0004 P_0, _0006._0001._0002 P_1)
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

		static int _0001(int P_0, int P_1, byte[] P_2, _0006._0001._0003 P_3)
		{
			int num = P_3._0001;
			int num2;
			if (P_1 <= P_3._0002)
			{
				num2 = P_3._0001;
				goto IL_00e1;
			}
			P_1 = P_3._0002;
			goto IL_0057;
			IL_008a:
			Array.Copy(P_3._0001, num - P_1, P_2, P_0, P_1);
			int num3;
			P_3._0002 -= num3;
			goto IL_00a9;
			IL_007f:
			int num4 = P_0;
			int num6;
			int num5 = num6;
			goto IL_0081;
			IL_0057:
			do
			{
				num3 = P_1;
			}
			while (3 == 0);
			num2 = P_1;
			if (false)
			{
				goto IL_00e1;
			}
			num6 = num2 - num;
			while (num6 > 0)
			{
				Array.Copy(P_3._0001, 32768 - num6, P_2, P_0, num6);
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
			num5 = P_1;
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
				P_1 = num;
				goto IL_008a;
			}
			goto IL_00a9;
		}

		static int _0001(_0006._0001._0002 P_0, int P_1)
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

		static string _0001(int P_0)
		{
			object obj = _0005._0002._0001;
			_0001_0002._000F_0002(obj);
			string result = default(string);
			try
			{
				_0005._0002._0001.TryGetValue(P_0, out var value);
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
					_0001_0002._0010_0002(obj);
				}
				while (false);
			}
			return _0001(P_0);
			IL_0061:
			return result;
		}

		static void _0001(_0006._0001._0004 P_0, byte[] P_1)
		{
			int[] array = new int[16];
			int[] array2 = new int[16];
			foreach (int num in P_1)
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
				P_0._0001 = new short[num3];
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
							if (num16 >= P_1.Length)
							{
								return;
							}
							if (4u != 0)
							{
								num17 = P_1[num15];
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
								P_0._0001[num18] = (short)((num15 << 4) | num17);
								num18 += 1 << num17;
							}
							while (num18 < 512);
							goto IL_01f3;
						}
						int num19 = P_0._0001[num18 & 0x1FF];
						num12 = 1;
						if (num12 == 0)
						{
							break;
						}
						int num20 = num12 << (num19 & 0xF);
						num19 = -(num19 >> 4);
						while (true)
						{
							P_0._0001[num19 | (num18 >> 9)] = (short)((num15 << 4) | num17);
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
						P_0._0001[_0001(num22)] = (short)((-num13 << 4) | num14);
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

		static _0006._0001._0004 _0001(_0006._0001._0005 P_0)
		{
			byte[] array = new byte[P_0._0002];
			Array.Copy(P_0._0002, 0, array, 0, P_0._0002);
			return new _0006._0001._0004(array);
		}

		static int _0001(_0006._0001._0003 P_0, _0006._0001._0002 P_1, int P_2)
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

		static ICryptoTransform _0001(byte[] P_0, bool P_1, byte[] P_2)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			try
			{
				ICryptoTransform result;
				while (true)
				{
					ICryptoTransform cryptoTransform;
					if (0 == 0 && !P_1)
					{
						if (false)
						{
							continue;
						}
						cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(P_2, P_0);
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
					cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(P_2, P_0);
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

		static byte[] _0001(byte[] P_0)
		{
			_0006._0001._0007 obj = new _0006._0001._0007(P_0);
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
						switch ((_0005._0003)num4)
						{
						case _0005._0003._0002:
							goto IL_006a;
						case _0005._0003._0004:
						{
							byte[] array3 = new byte[16]
							{
								41, 119, 223, 17, 137, 53, 230, 67, 210, 22,
								2, 209, 212, 74, 157, 194
							};
							byte[] array4 = new byte[16]
							{
								170, 148, 176, 238, 220, 155, 217, 235, 4, 86,
								206, 67, 226, 158, 189, 79
							};
							if (false)
							{
								goto default;
							}
							ICryptoTransform cryptoTransform = _0001(array4, true, array3);
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
							num7 = _0001(array2, new _0006._0001._0001(array5), num9, num6);
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

		static string _0001(int P_0)
		{
			int num = P_0;
			byte[] array = _0005._0002._0001;
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
						num8 = ((num5 & 0x1F) << 24) + (_0005._0002._0001[num++] << 16);
						while (true)
						{
							num7 = num8 + (_0005._0002._0001[num++] << 8);
							if (false)
							{
								break;
							}
							num8 = num7 + _0005._0002._0001[num++];
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
						num10 = _0005._0002._0001[num++];
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
				byte[] array2 = _0004_0002._0013_0002(_0003_0002._007E_0012_0002(_0002_0002._0011_0002(), _0005._0002._0001, num, num6));
				string text = _0005_0002._0014_0002(_0003_0002._007E_0012_0002(_0002_0002._0011_0002(), array2, 0, array2.Length));
				if (_0005._0002._0001)
				{
					_0001(P_0, text);
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

		static _0006._0001._0004 _0001(_0006._0001._0005 P_0)
		{
			byte[] array = new byte[P_0._0003];
			Array.Copy(P_0._0002, P_0._0002, array, 0, P_0._0003);
			return new _0006._0001._0004(array);
		}

		static _0003()
		{
			Strings.CreateGetStringDelegate(typeof(_0003));
		}
	}
}
namespace _0004
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

		internal static readonly _0002 _0001/* Not supported: data(AA 94 B0 EE DC 9B D9 EB 04 56 CE 43 E2 9E BD 4F) */;

		internal static readonly _0004 _0001/* Not supported: data(03 00 00 00 04 00 00 00 05 00 00 00 06 00 00 00 07 00 00 00 08 00 00 00 09 00 00 00 0A 00 00 00 0B 00 00 00 0D 00 00 00 0F 00 00 00 11 00 00 00 13 00 00 00 17 00 00 00 1B 00 00 00 1F 00 00 00 23 00 00 00 2B 00 00 00 33 00 00 00 3B 00 00 00 43 00 00 00 53 00 00 00 63 00 00 00 73 00 00 00 83 00 00 00 A3 00 00 00 C3 00 00 00 E3 00 00 00 02 01 00 00) */;

		internal static readonly _0001 _0001/* Not supported: data(02 00 00 00 03 00 00 00 07 00 00 00) */;

		internal static readonly _0002 _0002/* Not supported: data(00 08 04 0C 02 0A 06 0E 01 09 05 0D 03 0B 07 0F) */;

		internal static readonly _0005 _0001/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 06 00 00 00 06 00 00 00 07 00 00 00 07 00 00 00 08 00 00 00 08 00 00 00 09 00 00 00 09 00 00 00 0A 00 00 00 0A 00 00 00 0B 00 00 00 0B 00 00 00 0C 00 00 00 0C 00 00 00 0D 00 00 00 0D 00 00 00) */;

		internal static readonly _0003 _0001/* Not supported: data(10 00 00 00 11 00 00 00 12 00 00 00 00 00 00 00 08 00 00 00 07 00 00 00 09 00 00 00 06 00 00 00 0A 00 00 00 05 00 00 00 0B 00 00 00 04 00 00 00 0C 00 00 00 03 00 00 00 0D 00 00 00 02 00 00 00 0E 00 00 00 01 00 00 00 0F 00 00 00) */;

		internal static readonly _0002 _0003/* Not supported: data(29 77 DF 11 89 35 E6 43 D2 16 02 D1 D4 4A 9D C2) */;

		internal static readonly _0001 _0002/* Not supported: data(03 00 00 00 03 00 00 00 0B 00 00 00) */;

		internal static readonly _0004 _0002/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 01 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 02 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 03 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 04 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 05 00 00 00 00 00 00 00) */;

		internal static readonly _0005 _0002/* Not supported: data(01 00 00 00 02 00 00 00 03 00 00 00 04 00 00 00 05 00 00 00 07 00 00 00 09 00 00 00 0D 00 00 00 11 00 00 00 19 00 00 00 21 00 00 00 31 00 00 00 41 00 00 00 61 00 00 00 81 00 00 00 C1 00 00 00 01 01 00 00 81 01 00 00 01 02 00 00 01 03 00 00 01 04 00 00 01 06 00 00 01 08 00 00 01 0C 00 00 01 10 00 00 01 18 00 00 01 20 00 00 01 30 00 00 01 40 00 00 01 60 00 00) */;
	}
}
