using System;
using System.Linq;

internal sealed class _0023_003DzoQKWjrkqIhXb5ryfSQ_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<char, byte> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		public static Func<char, byte> _0023_003DzL8A4vc001c0gQY3dGg_003D_003D;

		public static Func<char, bool> _0023_003Dz_0024Ih3oa_GFwhYEReUfQ_003D_003D;

		public static Func<char, bool> _0023_003DzHhvXzEysP1BL_0024_g37Q_003D_003D;

		internal byte _0023_003DzSF4bhwTbVwoJeJNJnCtGlhKPGKb6(char _0023_003Dzt_m8zV0_003D)
		{
			return (byte)_0023_003Dzt_m8zV0_003D;
		}

		internal byte _0023_003Dz_Nrj73lmtqZWxXRxnApkO2JXrYe5(char _0023_003Dzt_m8zV0_003D)
		{
			return (byte)_0023_003Dzt_m8zV0_003D;
		}

		internal bool _0023_003DztjF2dk50LfVyilGQbd_Q1Ou_A0DQ(char _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D != '\0';
		}

		internal bool _0023_003DzC_juke0i_LiHo_udbRIomOs6lPlL(char _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D != '\0';
		}
	}

	public static int _0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = 0;

	private static int _0023_003DzkTZ_xalfYzV8 = 4096;

	public static int _0023_003Dz8Rb96EakVFNGlYpl1A_003D_003D = 8;

	public static long _0023_003Dzhp8Ae59zU5tx(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		return _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D * 8 + (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D & 7);
	}

	public static void _0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003Dz6FwR9P9lp4Ih)
	{
		long num = _0023_003Dzhp8Ae59zU5tx(_0023_003Dz3vRWvQs_003D);
		long num2 = _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D * 8;
		long num3 = _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D + _0023_003Dz6FwR9P9lp4Ih;
		if (num + _0023_003Dz6FwR9P9lp4Ih > num2)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xF;
			Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302677577), _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D, _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D, _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D, _0023_003Dz6FwR9P9lp4Ih);
		}
		else if (num + _0023_003Dz6FwR9P9lp4Ih < 0)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xF;
			Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302677577), _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D, _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D, _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D, _0023_003Dz6FwR9P9lp4Ih);
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D = 0L;
			_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = '\0';
			return;
		}
		_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D += (int)(num3 >> 3);
		_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = (char)(num3 & 7);
	}

	public static char _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		byte b = 0;
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return '\0';
		}
		byte b2 = _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D];
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0')
		{
			b = b2;
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D++;
		}
		else
		{
			b = (byte)(b2 << (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
			if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D - 1)
			{
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xF;
				return (char)b;
			}
			b2 = _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1 + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D];
			b |= (byte)(b2 >> 8 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
			_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 8L);
		}
		return (char)b;
	}

	public static bool _0023_003Dz_0024PP3O5hMq0pp(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003DzLyzNvlA_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return true;
		}
		return false;
	}

	public static bool _0023_003DzHtScIBKHBP_XBmRzNA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D.Length < _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D.Length < _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 2 || _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D.Length == _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D)
		{
			return true;
		}
		return false;
	}

	public static uint _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		ushort num = _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0u;
		}
		return (uint)((_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D) << 16) | num);
	}

	public static uint _0023_003DzVnPImbFsAmVPG3awjA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		ushort num = _0023_003Dz_cmRwf5uPgvrBqq7lA_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0u;
		}
		ushort num2 = _0023_003Dz_cmRwf5uPgvrBqq7lA_003D_003D(_0023_003Dz3vRWvQs_003D);
		return (uint)((num << 16) | num2);
	}

	public static void _0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, uint _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)_0023_003DzPzO_0024GUk_003D);
		_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(_0023_003DzPzO_0024GUk_003D >> 16));
	}

	public static ushort _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char c = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0;
		}
		return (ushort)(((uint)_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D) << 8) | c);
	}

	public static ushort _0023_003Dz_cmRwf5uPgvrBqq7lA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char c = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0;
		}
		char c2 = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		return (ushort)(((uint)c << 8) | c2);
	}

	public static void _0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ushort _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D & 0xFF));
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D >> 8));
	}

	public static uint _0023_003DzTECSPIvA_0024fnvqe1H6g_003D_003D(uint _0023_003Dz_0024D8vcl0_003D, uint _0023_003DzyzK8swU_003D, byte[] _0023_003DzBDOXyf0_003D, long _0023_003Dz9JZgoew_003D)
	{
		uint num = _0023_003Dz_0024D8vcl0_003D;
		uint[] array = new uint[256]
		{
			0u, 49345u, 49537u, 320u, 49921u, 960u, 640u, 49729u, 50689u, 1728u,
			1920u, 51009u, 1280u, 50625u, 50305u, 1088u, 52225u, 3264u, 3456u, 52545u,
			3840u, 53185u, 52865u, 3648u, 2560u, 51905u, 52097u, 2880u, 51457u, 2496u,
			2176u, 51265u, 55297u, 6336u, 6528u, 55617u, 6912u, 56257u, 55937u, 6720u,
			7680u, 57025u, 57217u, 8000u, 56577u, 7616u, 7296u, 56385u, 5120u, 54465u,
			54657u, 5440u, 55041u, 6080u, 5760u, 54849u, 53761u, 4800u, 4992u, 54081u,
			4352u, 53697u, 53377u, 4160u, 61441u, 12480u, 12672u, 61761u, 13056u, 62401u,
			62081u, 12864u, 13824u, 63169u, 63361u, 14144u, 62721u, 13760u, 13440u, 62529u,
			15360u, 64705u, 64897u, 15680u, 65281u, 16320u, 16000u, 65089u, 64001u, 15040u,
			15232u, 64321u, 14592u, 63937u, 63617u, 14400u, 10240u, 59585u, 59777u, 10560u,
			60161u, 11200u, 10880u, 59969u, 60929u, 11968u, 12160u, 61249u, 11520u, 60865u,
			60545u, 11328u, 58369u, 9408u, 9600u, 58689u, 9984u, 59329u, 59009u, 9792u,
			8704u, 58049u, 58241u, 9024u, 57601u, 8640u, 8320u, 57409u, 40961u, 24768u,
			24960u, 41281u, 25344u, 41921u, 41601u, 25152u, 26112u, 42689u, 42881u, 26432u,
			42241u, 26048u, 25728u, 42049u, 27648u, 44225u, 44417u, 27968u, 44801u, 28608u,
			28288u, 44609u, 43521u, 27328u, 27520u, 43841u, 26880u, 43457u, 43137u, 26688u,
			30720u, 47297u, 47489u, 31040u, 47873u, 31680u, 31360u, 47681u, 48641u, 32448u,
			32640u, 48961u, 32000u, 48577u, 48257u, 31808u, 46081u, 29888u, 30080u, 46401u,
			30464u, 47041u, 46721u, 30272u, 29184u, 45761u, 45953u, 29504u, 45313u, 29120u,
			28800u, 45121u, 20480u, 37057u, 37249u, 20800u, 37633u, 21440u, 21120u, 37441u,
			38401u, 22208u, 22400u, 38721u, 21760u, 38337u, 38017u, 21568u, 39937u, 23744u,
			23936u, 40257u, 24320u, 40897u, 40577u, 24128u, 23040u, 39617u, 39809u, 23360u,
			39169u, 22976u, 22656u, 38977u, 34817u, 18624u, 18816u, 35137u, 19200u, 35777u,
			35457u, 19008u, 19968u, 36545u, 36737u, 20288u, 36097u, 19904u, 19584u, 35905u,
			17408u, 33985u, 34177u, 17728u, 34561u, 18368u, 18048u, 34369u, 33281u, 17088u,
			17280u, 33601u, 16640u, 33217u, 32897u, 16448u
		};
		while (_0023_003Dz9JZgoew_003D > 0 && _0023_003DzBDOXyf0_003D.Length > _0023_003DzyzK8swU_003D)
		{
			char c = (char)(_0023_003DzBDOXyf0_003D[_0023_003DzyzK8swU_003D] ^ (ushort)(num & 0xFF));
			num = ((num >> 8) & 0xFF) ^ array[(uint)c];
			_0023_003DzyzK8swU_003D++;
			_0023_003Dz9JZgoew_003D--;
		}
		return num;
	}

	public static double _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		switch (_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
		case '\0':
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, Convert.ToInt32(_0023_003DzsLhEgUCw0_0024hi())))
			{
				return double.NaN;
			}
			return _0023_003DzbvaYVuPBILMifY5ISw_003D_003D(_0023_003Dz3vRWvQs_003D);
		case '\u0001':
			return 1.0;
		case '\u0002':
			return 0.0;
		default:
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return double.NaN;
		}
	}

	public static double _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ref int _0023_003DzEZdZXKE_003D)
	{
		_0023_003DzEZdZXKE_003D = 0;
		switch (_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
		case '\0':
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, Convert.ToInt32(_0023_003DzsLhEgUCw0_0024hi())))
			{
				return double.NaN;
			}
			return _0023_003DzbvaYVuPBILMifY5ISw_003D_003D(_0023_003Dz3vRWvQs_003D);
		case '\u0001':
			return 1.0;
		case '\u0002':
			return 0.0;
		default:
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			_0023_003DzEZdZXKE_003D = 1;
			return double.NaN;
		}
	}

	public static char _0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return '\0';
		}
		char c = (char)_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D];
		char c2;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D < '\a')
		{
			c2 = (char)((c & (192 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D)) >> 6 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
		}
		else
		{
			c2 = (char)((c & 1) << 1);
			if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D < _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D - 1)
			{
				c = (char)_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1 + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D];
				c2 = (char)(c2 | (ushort)((c & 0x80) >> 7));
			}
		}
		_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 2L);
		return c2;
	}

	public static double _0023_003DzbvaYVuPBILMifY5ISw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		return BitConverter.Int64BitsToDouble((long)_0023_003DzdwIe5njtnPSvRBml2A_003D_003D(_0023_003Dz3vRWvQs_003D));
	}

	public static double _0023_003DzsLhEgUCw0_0024hi()
	{
		int[] array = new int[Convert.ToInt32(2)];
		array[0] = -1;
		array[1] = -1;
		return 0.0;
	}

	public static string _0023_003DzEEVETvtsg1JDM51ofA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzpOLl8c3ZLgZYIt1SIA_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		char[] array = new char[num + 1];
		uint num2;
		for (num2 = 0u; num2 < num; num2++)
		{
			array[num2] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		array[num2] = '\0';
		return new string(array).TrimEnd(default(char));
	}

	public static ushort _0023_003DzpOLl8c3ZLgZYIt1SIA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		return _0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D) switch
		{
			'\0' => _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D), 
			'\u0001' => (ushort)(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D) & 0xFF), 
			'\u0002' => 0, 
			_ => 256, 
		};
	}

	public static uint _0023_003DzIc53QGkvADm6DCWQqQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		switch (_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
		case '\0':
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0u;
			}
			return _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		case '\u0001':
			return (uint)(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D) & 0xFF);
		case '\u0002':
			return 0u;
		default:
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return 256u;
		}
	}

	public static char _0023_003DzZFbeCjw_0024SgOL(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return '\0';
		}
		byte result = Convert.ToByte((_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D] & (128 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D)) >> 7 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
		_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 1L);
		return (char)result;
	}

	public static int _0023_003Dz1U7L9b57R1sq(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003Dzu2BB2ECAhm0u4k5_dyv5JPQ_003D _0023_003Dzy0p1LSY_003D)
	{
		long _0023_003DzICoifrU_003D = _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D;
		_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003DzICoifrU_003D == _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D)
		{
			return 16;
		}
		_0023_003Dzy0p1LSY_003D._0023_003Dz14lzA48_003D = (ushort)(_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D & 0xF);
		_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D = (char)((_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D & 0xF0) >> 4);
		_0023_003Dzy0p1LSY_003D._0023_003Dzku6JKh215pgu = '\0';
		_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D = 0L;
		if (_0023_003Dzy0p1LSY_003D._0023_003Dz14lzA48_003D > _0023_003DzzwiXPjhfUa8AtxYhx9KiJWs_003D._0023_003DzaJ5tSPXNrQUx || _0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D > '\u000e')
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return 16;
		}
		char[] array = new char[8];
		if (_0023_003Dzy0p1LSY_003D._0023_003Dz14lzA48_003D != 0)
		{
			for (int num = _0023_003Dzy0p1LSY_003D._0023_003Dz14lzA48_003D - 1; num >= 0; num--)
			{
				array[num] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
			}
			byte[] value = array.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzSF4bhwTbVwoJeJNJnCtGlhKPGKb6).ToArray();
			_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D = BitConverter.ToUInt32(value, 0);
		}
		return 0;
	}

	public static _0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D _0023_003DzXsIh1rvxJKL4VDMciYZxfjI_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		_0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D result = default(_0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_13)
		{
			result._0023_003DzxQiMvvk_003D = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
			result._0023_003DzqsdMfnE_003D = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		else
		{
			result._0023_003DzxQiMvvk_003D = _0023_003DzIc53QGkvADm6DCWQqQ_003D_003D(_0023_003Dz3vRWvQs_003D);
			result._0023_003DzqsdMfnE_003D = _0023_003DzIc53QGkvADm6DCWQqQ_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		result._0023_003DzPzO_0024GUk_003D = (double)result._0023_003DzxQiMvvk_003D + (double)result._0023_003DzqsdMfnE_003D / 86400000.0;
		return result;
	}

	public static void _0023_003Dz7UV6_1cle4AHDxT0lA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003DzyHvf9x5nZeqH, _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_13)
		{
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = (short)_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		else
		{
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = (short)_0023_003DzpOLl8c3ZLgZYIt1SIA_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004)
		{
			_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D = _0023_003DzIc53QGkvADm6DCWQqQ_003D_003D(_0023_003Dz3vRWvQs_003D);
			_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = (int)(_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D >> 24);
			_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
			if (_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D < 4)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzS_00246o7tc_003D = (((_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D & 1) != 0) ? _0023_003DzFfCN5WW9Tdsi(_0023_003DzyHvf9x5nZeqH) : null);
				_0023_003Dz1MMYB1g_003D._0023_003DzNRAY4Ytn3BwJ = (((_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D & 2) != 0) ? _0023_003DzFfCN5WW9Tdsi(_0023_003DzyHvf9x5nZeqH) : null);
			}
			else
			{
				_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D = 0;
			}
			if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D < 192 || _0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D > 200)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = 194;
				_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D = 0xC2000000u | (_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D & 0xFFFFFF);
			}
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = (short)_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003Dz8HcH5k8gg4tjdHQeMg_003D_003D(_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D);
		}
	}

	public static string _0023_003DzFfCN5WW9Tdsi(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007)
		{
			return _0023_003DzVstUwpqh_XG3sem5gA_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return _0023_003DzEEVETvtsg1JDM51ofA_003D_003D(_0023_003Dz3vRWvQs_003D);
	}

	public static string _0023_003DzVstUwpqh_XG3sem5gA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzpOLl8c3ZLgZYIt1SIA_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num * 2 > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		char[] array = new char[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			array[num2] = (char)_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return new string(array);
	}

	public static void _0023_003Dzze2UXTEwHs7_0024(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003Dz27AcvYoE2Fgi)
	{
		_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D = (int)_0023_003Dz27AcvYoE2Fgi >> 3;
		_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = (char)(_0023_003Dz27AcvYoE2Fgi & 7);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D || (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D == _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D && _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D != 0))
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		}
	}

	public static int _0023_003DzNLeIN7Y6_0024e7tSJWu0g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003DzBX9TJ6b3P9MJ, ushort _0023_003Dz_0024D8vcl0_003D)
	{
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D > '\0')
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D++;
			_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = '\0';
		}
		if (_0023_003DzBX9TJ6b3P9MJ > _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return 0;
		}
		long _0023_003Dz9JZgoew_003D = _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D - _0023_003DzBX9TJ6b3P9MJ;
		uint num = _0023_003DzTECSPIvA_0024fnvqe1H6g_003D_003D(_0023_003Dz_0024D8vcl0_003D, (uint)_0023_003DzBX9TJ6b3P9MJ, _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, _0023_003Dz9JZgoew_003D);
		ushort num2 = _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (num == num2)
		{
			return 1;
		}
		return 0;
	}

	public static int _0023_003DzmieIvQ6Nlcv3Kvo_Mx0yGJM_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, byte[] _0023_003DzmK3Wuz1Y4VC7xSwVrA_003D_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D < 16)
		{
			return 0;
		}
		for (int i = 0; i <= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D - 16; i++)
		{
			int j;
			for (j = 0; j < 16 && _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[i + j + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D] == _0023_003DzmK3Wuz1Y4VC7xSwVrA_003D_003D[j]; j++)
			{
			}
			if (j == 16)
			{
				_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D = i + j;
				_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = '\0';
				return -1;
			}
		}
		return 0;
	}

	public static void _0023_003Dzz6TGAa_00249_0024UXwDf772Q_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ref char[] _0023_003DzaoQTclc_003D, uint _0023_003Dz736ekIs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz736ekIs_003D > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return;
		}
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0')
		{
			_0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003Dz6HmSyXEGI2Yd(ref _0023_003DzaoQTclc_003D, 0, _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)(_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D), (int)_0023_003Dz736ekIs_003D);
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D += (int)_0023_003Dz736ekIs_003D;
			return;
		}
		for (uint num = 0u; num < _0023_003Dz736ekIs_003D; num++)
		{
			_0023_003DzaoQTclc_003D[num] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
	}

	public static void _0023_003Dzz6TGAa_00249_0024UXwDf772Q_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ref byte[] _0023_003DzaoQTclc_003D, uint _0023_003Dz_0024VrompQ_003D, uint _0023_003Dz736ekIs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz736ekIs_003D > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return;
		}
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0')
		{
			_0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003Dz6HmSyXEGI2Yd(ref _0023_003DzaoQTclc_003D, (int)_0023_003Dz_0024VrompQ_003D, _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)(_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D), (int)_0023_003Dz736ekIs_003D);
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D += (int)_0023_003Dz736ekIs_003D;
			return;
		}
		for (uint num = 0u; num < _0023_003Dz736ekIs_003D; num++)
		{
			_0023_003DzaoQTclc_003D[num] = (byte)_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
	}

	public static ushort _0023_003DzXUhLpBbulwpgYUJ_00246g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D > '\0')
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D++;
			_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = '\0';
		}
		return _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
	}

	public static ushort _0023_003Dzd4NhITyTEbyEavXV1w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char c = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0;
		}
		char c2 = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		return (ushort)(((uint)c << 8) | c2);
	}

	public static ulong _0023_003DzZOauMz1g50pWNXRUIg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char[] array = new char[8];
		ulong num = 0uL;
		int num2 = 8 - 1;
		int num3 = 0;
		while (num2 >= 0)
		{
			array[num2] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0uL;
			}
			if ((array[num2] & 0x80) == 0)
			{
				return num | ((ulong)array[num2] << num3);
			}
			array[num2] &= '\u007f';
			num |= (ulong)array[num2] << num3;
			num2--;
			num3 += 7;
		}
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		return 0uL;
	}

	public static long _0023_003DzgsiQcsLBThO6HCjonA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char[] array = new char[5];
		int num = 0;
		ulong num2 = 0uL;
		int num3 = 4;
		int num4 = 0;
		while (num3 >= 0)
		{
			array[num3] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0L;
			}
			if ((array[num3] & 0x80) == 0)
			{
				if ((array[num3] & 0x40) != 0)
				{
					num = 1;
					array[num3] &= '¿';
				}
				num2 |= (ulong)array[num3] << num4;
				if (num == 0)
				{
					return (long)num2;
				}
				return (long)(0L - num2);
			}
			array[num3] &= '\u007f';
			num2 |= (ulong)array[num3] << num4;
			num3--;
			num4 += 7;
		}
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		return 0L;
	}

	public static uint _0023_003DzsSMZgrlDrnkJgYNfxw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		ushort[] array = new ushort[2];
		uint num = 0u;
		int num2 = 1;
		int num3 = 0;
		while (num2 >= 0)
		{
			array[num2] = _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0u;
			}
			if ((array[num2] & 0x8000) == 0)
			{
				return num | (uint)(array[num2] << num3);
			}
			array[num2] &= 32767;
			num |= (uint)(array[num2] << num3);
			num2--;
			num3 += 15;
		}
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		return 0u;
	}

	public static void _0023_003DzPOPMTQFTE1Jrxs8Dlw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		long num = (_0023_003Dz3vRWvQs_003D._0023_003DzAddCv_o_003D = _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D);
		_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D = 0L;
		if (_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D > 0)
		{
			_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D -= num;
		}
	}

	public static ushort _0023_003DzYuRGDIItzQZbWuMWBA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		switch (_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
		case '\0':
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0;
			}
			return _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		case '\u0001':
			return (ushort)(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D) + 496);
		default:
			return _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
	}

	public static string _0023_003DzzIzjt7GFga5tef_5hQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, uint _0023_003Dz736ekIs_003D)
	{
		char[] _0023_003DzaoQTclc_003D = new char[_0023_003Dz736ekIs_003D + 1];
		_0023_003Dzz6TGAa_00249_0024UXwDf772Q_003D_003D(_0023_003Dz3vRWvQs_003D, ref _0023_003DzaoQTclc_003D, _0023_003Dz736ekIs_003D);
		_0023_003DzaoQTclc_003D[_0023_003Dz736ekIs_003D] = '\0';
		return new string(_0023_003DzaoQTclc_003D);
	}

	public static char[] _0023_003DzzIzjt7GFga5tef_5hQ_003D_003D(uint _0023_003Dz736ekIs_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char[] _0023_003DzaoQTclc_003D = new char[_0023_003Dz736ekIs_003D + 1];
		_0023_003Dzz6TGAa_00249_0024UXwDf772Q_003D_003D(_0023_003Dz3vRWvQs_003D, ref _0023_003DzaoQTclc_003D, _0023_003Dz736ekIs_003D);
		_0023_003DzaoQTclc_003D[_0023_003Dz736ekIs_003D] = '\0';
		return _0023_003DzaoQTclc_003D;
	}

	public static ulong _0023_003DznzH957y9e5tn3ab5vg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		ulong num = 0uL;
		uint num2 = ((uint)_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D) << 1) | _0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D);
		switch (num2)
		{
		case 1u:
			return _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		case 2u:
			return _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		case 4u:
			return _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		default:
		{
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
			{
				return 0uL;
			}
			for (uint num3 = 0u; num3 < 8; num3++)
			{
				num <<= 8;
				if (num3 < num2)
				{
					num |= _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
				}
			}
			return _0023_003DzynkKMHM76TFF10R5fQ_003D_003D._0023_003DzGMt5PQsn8sXb(num);
		}
		}
	}

	public static void _0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0')
		{
			while (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
			{
				_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
			}
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] = (byte)_0023_003DzPzO_0024GUk_003D;
		}
		else
		{
			while (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1 >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
			{
				_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
			}
			byte b = (byte)(_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] & (255 << 8 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] = (byte)(b | ((int)_0023_003DzPzO_0024GUk_003D >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
			b = (byte)(_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1] & (255 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1] = (byte)(b | ((uint)_0023_003DzPzO_0024GUk_003D << 8 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
		}
		_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 8L);
	}

	public static string _0023_003Dz6cnF59iRD2LqmcbGOw_003D_003D(string _0023_003Dzx_0024k0MJeH4KrY)
	{
		int num = 0;
		ushort num2 = 0;
		if (_0023_003Dzx_0024k0MJeH4KrY == null)
		{
			return null;
		}
		int num3 = 0;
		if (!string.IsNullOrEmpty(_0023_003Dzx_0024k0MJeH4KrY))
		{
			for (num2 = _0023_003Dzx_0024k0MJeH4KrY[num3]; num2 != 0; num2 = _0023_003Dzx_0024k0MJeH4KrY[num3])
			{
				num++;
				if (num2 >= 256)
				{
					num++;
				}
				if (num2 >= 2048)
				{
					num++;
				}
				num3++;
				if (num3 == _0023_003Dzx_0024k0MJeH4KrY.Length)
				{
					break;
				}
			}
		}
		char[] array = new char[num];
		int num4 = 0;
		int num5 = 0;
		if (!string.IsNullOrEmpty(_0023_003Dzx_0024k0MJeH4KrY))
		{
			num2 = _0023_003Dzx_0024k0MJeH4KrY[num5];
			while (num2 != 0 && num5 < _0023_003Dzx_0024k0MJeH4KrY.Length)
			{
				if (num2 < 256)
				{
					array[num4++] = Convert.ToChar(num2 & 0xFF);
				}
				else if (num2 < 2048)
				{
					array[num4++] = Convert.ToChar((num2 >> 6) | 0xC0);
					array[num4++] = Convert.ToChar((num2 & 0x3F) | 0x80);
				}
				else
				{
					array[num4++] = Convert.ToChar((num2 >> 12) | 0xE0);
					array[num4++] = Convert.ToChar(((num2 >> 6) & 0x3F) | 0x80);
					array[num4++] = Convert.ToChar((num2 & 0x3F) | 0x80);
				}
				num5++;
				if (num5 == _0023_003Dzx_0024k0MJeH4KrY.Length)
				{
					break;
				}
				num2 = _0023_003Dzx_0024k0MJeH4KrY[num5];
			}
		}
		return new string(array);
	}

	public static bool _0023_003DznYgw_JooiUl4_00242AtmA_003D_003D(double _0023_003DzkXQ_IWk_003D)
	{
		if (double.IsNaN(_0023_003DzkXQ_IWk_003D))
		{
			return true;
		}
		return false;
	}

	public static int _0023_003DzIUFV0mq5977EDcTDuQ_003D_003D(string _0023_003Dzx_0024k0MJeH4KrY)
	{
		int num = 0;
		if (_0023_003Dzx_0024k0MJeH4KrY != string.Empty)
		{
			return 0;
		}
		if (Convert.ToInt32(_0023_003Dzx_0024k0MJeH4KrY) % _0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzJCnFmK7ZM5AA6IxQBQ_003D_003D != 0)
		{
			string text = _0023_003Dzx_0024k0MJeH4KrY;
			for (ushort num2 = _0023_003DzmFHrC5Of4sv_0024K_yWtQ_003D_003D(text); num2 != 0; num2 = _0023_003DzmFHrC5Of4sv_0024K_yWtQ_003D_003D(text))
			{
				num++;
				text += 2;
			}
			return num;
		}
		char[] array = _0023_003Dzx_0024k0MJeH4KrY.ToCharArray();
		for (int i = 0; array[i] != 0; i++)
		{
			num++;
		}
		return num;
	}

	public static char _0023_003Dz73YcTxFYZTFzKDoMzg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		return Convert.ToChar((int)(((uint)_0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D) << 3) | ((uint)_0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D) << 2) | ((uint)_0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D) << 1) | _0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D)));
	}

	public static string _0023_003DzlMz46tUKX7SibIahkA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003DzYsh789A_003D)
	{
		long num = _0023_003DzYsh789A_003D / 8;
		int num2 = (int)_0023_003DzYsh789A_003D % 8;
		char[] _0023_003DzaoQTclc_003D = new char[num + ((num2 == 0) ? 1 : 2)];
		_0023_003Dzz6TGAa_00249_0024UXwDf772Q_003D_003D(_0023_003Dz3vRWvQs_003D, ref _0023_003DzaoQTclc_003D, (uint)num);
		_0023_003DzaoQTclc_003D[num] = '\0';
		if (num2 != 0)
		{
			_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D++;
			_0023_003DzaoQTclc_003D[num + 1] = '\0';
			for (int i = 0; i < num2; i++)
			{
				char c = _0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D);
				_0023_003DzaoQTclc_003D[num] |= Convert.ToChar((int)((uint)c << i));
			}
			_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D--;
		}
		return new string(_0023_003DzaoQTclc_003D);
	}

	public static double _0023_003Dzc588ZmfHocbCab2a_0024w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003Dz0eSiJtQ_003D)
	{
		switch (_0023_003DzLnBx7E2UL4exZyaLYA_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
		case '\0':
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, Convert.ToInt32(_0023_003DzsLhEgUCw0_0024hi())))
			{
				return _0023_003DzsLhEgUCw0_0024hi();
			}
			return _0023_003Dz0eSiJtQ_003D;
		case '\u0003':
			return _0023_003DzbvaYVuPBILMifY5ISw_003D_003D(_0023_003Dz3vRWvQs_003D);
		case '\u0002':
		{
			byte[] bytes = BitConverter.GetBytes(_0023_003Dz0eSiJtQ_003D);
			bytes[4] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[5] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[0] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[1] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[2] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[3] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, Convert.ToInt32(_0023_003DzsLhEgUCw0_0024hi())))
			{
				return _0023_003DzsLhEgUCw0_0024hi();
			}
			_0023_003Dz0eSiJtQ_003D = BitConverter.ToDouble(bytes, 0);
			return _0023_003Dz0eSiJtQ_003D;
		}
		default:
		{
			byte[] bytes = BitConverter.GetBytes(_0023_003Dz0eSiJtQ_003D);
			bytes[0] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[1] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[2] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			bytes[3] = Convert.ToByte(_0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D));
			if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, Convert.ToInt32(_0023_003DzsLhEgUCw0_0024hi())))
			{
				return _0023_003DzsLhEgUCw0_0024hi();
			}
			_0023_003Dz0eSiJtQ_003D = BitConverter.ToDouble(bytes, 0);
			return _0023_003Dz0eSiJtQ_003D;
		}
		}
	}

	public static void _0023_003DzyWks_0024q77PNU1J85I_0024Q_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ref double _0023_003DzBJFJHwk_003D, ref double _0023_003Dz40R7bAU_003D, ref double _0023_003DzId5C3LA_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2000 && _0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D) != 0)
		{
			_0023_003DzBJFJHwk_003D = 0.0;
			_0023_003Dz40R7bAU_003D = 0.0;
			_0023_003DzId5C3LA_003D = 1.0;
		}
		else
		{
			_0023_003DzBJFJHwk_003D = _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003Dz3vRWvQs_003D);
			_0023_003Dz40R7bAU_003D = _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003Dz3vRWvQs_003D);
			_0023_003DzId5C3LA_003D = _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
	}

	public static string _0023_003DzYqZW7zk4t9HcVqjur_0024DMMHY_003D(ref char[] _0023_003DzaoQTclc_003D, int _0023_003Dz_0024VrompQ_003D, char[] _0023_003DzqjMrmuo_003D, int _0023_003DzD71rs7s_003D, int _0023_003DzxGXPCWPnCtti)
	{
		char[] array = new char[_0023_003DzaoQTclc_003D.Length + _0023_003DzxGXPCWPnCtti];
		char[] value = _0023_003DzaoQTclc_003D;
		char c = _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
		while ((c = _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D]) != 0)
		{
			_0023_003DzD71rs7s_003D++;
			if (_0023_003DzaoQTclc_003D.Length >= array.Length)
			{
				return null;
			}
			if (c == '\\' && _0023_003DzaoQTclc_003D.Length + 1 < array.Length && (_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == '"' || _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == 'r' || _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == 'n'))
			{
				if (_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == 'r')
				{
					_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '\r';
					_0023_003Dz_0024VrompQ_003D++;
					_0023_003DzD71rs7s_003D++;
				}
				else if (_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == 'n')
				{
					_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '\n';
					_0023_003Dz_0024VrompQ_003D++;
					_0023_003DzD71rs7s_003D++;
				}
			}
			else if (c == '\\' && _0023_003DzaoQTclc_003D.Length + 7 < array.Length && _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] == 'u')
			{
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += c;
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += 'U';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '+';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
			}
			else if (c < '\u0080')
			{
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += c;
				_0023_003Dz_0024VrompQ_003D++;
			}
			else if ((c & 0xE0) == 192)
			{
				if (_0023_003DzaoQTclc_003D.Length + 7 >= array.Length)
				{
					return null;
				}
				ushort num = Convert.ToUInt16(((c & 0x1F) << 6) | (_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] & 0x3F));
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '\\';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += 'U';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '+';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] = Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num >> 12));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] = Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num >> 8));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] = Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num >> 4));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] = Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
			}
			else if ((c & 0xF0) == 224)
			{
				if (_0023_003DzaoQTclc_003D.Length + 2 < array.Length && _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] >= '\u0080' && _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] <= '¿' && _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D + 1] >= '\u0080')
				{
					_ = _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D + 1];
				}
				if (_0023_003DzaoQTclc_003D.Length + 1 < array.Length && c == 'à')
				{
					_ = _0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D];
				}
				if (_0023_003DzaoQTclc_003D.Length + 7 >= array.Length)
				{
					return null;
				}
				ushort num2 = Convert.ToUInt16(((c & 0xF) << 12) | ((_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D] & 0x3F) << 6) | (_0023_003DzqjMrmuo_003D[_0023_003DzD71rs7s_003D + 1] & 0x3F));
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '\\';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += 'U';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += '+';
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num2 >> 12));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num2 >> 8));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num2 >> 4));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzaoQTclc_003D[_0023_003Dz_0024VrompQ_003D] += Convert.ToChar(_0023_003DzK_0024ppVLk_003D(num2));
				_0023_003Dz_0024VrompQ_003D++;
				_0023_003DzD71rs7s_003D++;
				_0023_003DzD71rs7s_003D++;
			}
		}
		if (_0023_003DzaoQTclc_003D.Length >= array.Length)
		{
			return null;
		}
		return new string(value);
	}

	public static char[] _0023_003DzfV97elAdPe3hGmo3PAN9af0_003D(char[] _0023_003Dz_0024n2nrac_003D)
	{
		int num = 0;
		int num2 = _0023_003Dz_0024n2nrac_003D.Length;
		char[] array = new char[num2];
		int num3 = 0;
		char c = _0023_003Dz_0024n2nrac_003D[num3];
		while (num2 >= 0 && c != 0)
		{
			num2--;
			if (c < '\u0080')
			{
				array[num++] = c;
				num3++;
			}
			else if ((c & 0xE0) == 192)
			{
				if (num2 >= 1)
				{
					array[num++] = Convert.ToChar(((c & 0x1F) << 6) | (_0023_003Dz_0024n2nrac_003D[1] & 0x3F));
				}
				num2--;
				num3++;
			}
			else if ((c & 0xF0) == 224)
			{
				if (num2 >= 2 && _0023_003Dz_0024n2nrac_003D[1] >= '\u0080' && _0023_003Dz_0024n2nrac_003D[1] <= '¿' && _0023_003Dz_0024n2nrac_003D[2] >= '\u0080')
				{
					_ = _0023_003Dz_0024n2nrac_003D[2];
				}
				if (num2 >= 1 && c == 'à')
				{
					_ = _0023_003Dz_0024n2nrac_003D[1];
				}
				if (num2 >= 2)
				{
					array[num++] = Convert.ToChar(((c & 0xF) << 12) | ((_0023_003Dz_0024n2nrac_003D[1] & 0x3F) << 6) | (_0023_003Dz_0024n2nrac_003D[2] & 0x3F));
				}
				num3++;
				num3++;
				num2--;
				num2--;
			}
			if (_0023_003Dz_0024n2nrac_003D.Length == num3)
			{
				break;
			}
			c = _0023_003Dz_0024n2nrac_003D[num3];
		}
		return array;
	}

	private static int _0023_003DzK_0024ppVLk_003D(int _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzt_m8zV0_003D &= 0xF;
		if (_0023_003Dzt_m8zV0_003D < 10)
		{
			return 48 + _0023_003Dzt_m8zV0_003D;
		}
		return 65 + _0023_003Dzt_m8zV0_003D - 10;
	}

	public static ulong _0023_003DzdwIe5njtnPSvRBml2A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0uL;
		}
		return ((ulong)_0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D) << 32) | num;
	}

	public static ulong _0023_003Dzquu4jmYrQFLA7Y8BBK8Hu28_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzVnPImbFsAmVPG3awjA_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz_0024PP3O5hMq0pp(_0023_003Dz3vRWvQs_003D, 0))
		{
			return 0uL;
		}
		uint num2 = _0023_003DzVnPImbFsAmVPG3awjA_003D_003D(_0023_003Dz3vRWvQs_003D);
		return ((ulong)num << 32) | num2;
	}

	public static double _0023_003DzTKlEB2SL3deZ7kgCXQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		int num = 0;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2000)
		{
			num = _0023_003DzZFbeCjw_0024SgOL(_0023_003Dz3vRWvQs_003D);
		}
		if (num == 0)
		{
			return _0023_003DzUxnKYQSefFfXQrpXLg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return 0.0;
	}

	public static ushort _0023_003DzMrcYf5qcT4wrDdWugA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, uint _0023_003DzyzK8swU_003D, long _0023_003Dzl4sfwALYBp27, ushort _0023_003Dz_0024D8vcl0_003D)
	{
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		while (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D > '\0')
		{
			_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, '\0');
		}
		if (_0023_003Dzl4sfwALYBp27 > _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 2 >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		if (_0023_003Dzl4sfwALYBp27 > _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return 0;
		}
		long _0023_003Dz9JZgoew_003D = _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D - _0023_003Dzl4sfwALYBp27;
		ushort num = (ushort)_0023_003DzTECSPIvA_0024fnvqe1H6g_003D_003D(_0023_003Dz_0024D8vcl0_003D, (uint)_0023_003Dzl4sfwALYBp27, _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, _0023_003Dz9JZgoew_003D);
		_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, num);
		return num;
	}

	public static void _0023_003DzQsq2ZYzCZZUp(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		if (_0023_003DzPzO_0024GUk_003D != 0)
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] |= (byte)(128 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
		}
		else
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] &= (byte)(~(128 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
		}
		_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 1L);
	}

	public static void _0023_003Dza0kkIhPRD3LeS77_3VEn6MU_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char[] _0023_003DzmK3Wuz1Y4VC7xSwVrA_003D_003D)
	{
		for (int i = 0; i < 16; i++)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzmK3Wuz1Y4VC7xSwVrA_003D_003D[i]);
		}
	}

	public static void _0023_003DzRyg26WvI33SePw1FGg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003Dz14lzA48_003D)
	{
		_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D = new byte[_0023_003Dz14lzA48_003D];
		if (_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D.Length != 0)
		{
			_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D = _0023_003Dz14lzA48_003D;
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D = 0L;
			_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D = '\0';
		}
	}

	public static void _0023_003Dz6oMnGdQgzlRf55iK7g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz8SEdsjQ_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003DzKV5V6WI_003D)
	{
		_0023_003Dz8SEdsjQ_003D._0023_003DzQ3hPewo_003D = _0023_003DzKV5V6WI_003D._0023_003DzQ3hPewo_003D;
		_0023_003Dz8SEdsjQ_003D._0023_003DzWyA_BDmgBAuw = _0023_003DzKV5V6WI_003D._0023_003DzWyA_BDmgBAuw;
		_0023_003Dz8SEdsjQ_003D._0023_003DzG_0024i1Pyc_003D = _0023_003DzKV5V6WI_003D._0023_003DzG_0024i1Pyc_003D;
		_0023_003Dz8SEdsjQ_003D._0023_003Dzr_0024FR0SY_003D = _0023_003DzKV5V6WI_003D._0023_003Dzr_0024FR0SY_003D;
	}

	public static void _0023_003DzimjTRxaM0ri4cIfh8g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char[] _0023_003DzpiolRKc_003D, uint _0023_003Dz736ekIs_003D)
	{
		if (_0023_003DzpiolRKc_003D == null)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			if (_0023_003Dz736ekIs_003D <= 128)
			{
				for (uint num = 0u; num < _0023_003Dz736ekIs_003D; num++)
				{
					_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
				}
			}
		}
		else if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0' && _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dz736ekIs_003D < _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			byte[] _0023_003Dzb7SPTpc_003D = _0023_003DzpiolRKc_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz_Nrj73lmtqZWxXRxnApkO2JXrYe5).ToArray();
			_0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003Dz6HmSyXEGI2Yd(ref _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D, _0023_003Dzb7SPTpc_003D, 0, (int)_0023_003Dz736ekIs_003D);
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D += (int)_0023_003Dz736ekIs_003D;
		}
		else
		{
			for (int i = 0; i < _0023_003Dz736ekIs_003D; i++)
			{
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[i]);
			}
		}
	}

	public static void _0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ushort _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D > 256)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
			return;
		}
		switch (_0023_003DzPzO_0024GUk_003D)
		{
		case 0:
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(2));
			break;
		case 256:
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(3));
			break;
		default:
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)_0023_003DzPzO_0024GUk_003D);
			break;
		}
	}

	public static void _0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		byte b = _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[(int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D];
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D < '\a')
		{
			char c = (char)(192 >> (int)_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D);
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] = (byte)((b & ~(uint)c) | ((uint)_0023_003DzPzO_0024GUk_003D << 6 - _0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D));
		}
		else
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D] = (byte)((b & 0xFE) | ((int)_0023_003DzPzO_0024GUk_003D >> 1));
			if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1 >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
			{
				_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
			}
			b = _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1];
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D[_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 1] = (byte)((b & 0x7F) | ((_0023_003DzPzO_0024GUk_003D & 1) << 7));
		}
		_0023_003Dz386FlJJnA8JXA5UO9ksH5ts_003D(_0023_003Dz3vRWvQs_003D, 2L);
	}

	public static int _0023_003DzK_0024ppVLk_003D(char _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzt_m8zV0_003D = (char)(_0023_003Dzt_m8zV0_003D & 0xF);
		if (_0023_003Dzt_m8zV0_003D < '\n')
		{
			return 48 + _0023_003Dzt_m8zV0_003D;
		}
		return 65 + _0023_003Dzt_m8zV0_003D - 10;
	}

	public static string _0023_003DzVGPF7F6iC6_0024JtOLZOg_003D_003D(string _0023_003Dzx_0024k0MJeH4KrY, int _0023_003Dz9JZgoew_003D)
	{
		ushort num = 0;
		int num2 = 0;
		if (string.IsNullOrEmpty(_0023_003Dzx_0024k0MJeH4KrY))
		{
			return null;
		}
		int num3 = _0023_003Dz9JZgoew_003D + 1;
		char[] array = new char[num3];
		if (array == null)
		{
			return null;
		}
		int num5;
		int num4 = (num5 = 0);
		while (num4 < _0023_003Dz9JZgoew_003D - 1)
		{
			num = _0023_003Dzx_0024k0MJeH4KrY[num2];
			num4++;
			if (num < 256)
			{
				if (num5 + 1 >= num3)
				{
					num3 += 2;
					Array.Resize(ref array, array.Length + num3);
				}
				array[num5++] = (char)(num & 0xFF);
			}
			else
			{
				if (num5 + 7 > num3)
				{
					num3 += 8;
					Array.Resize(ref array, array.Length + num3);
				}
				array[num5++] = '\\';
				array[num5++] = 'U';
				array[num5++] = '+';
				array[num5++] = (char)_0023_003DzK_0024ppVLk_003D((char)(num >> 12));
				array[num5++] = (char)_0023_003DzK_0024ppVLk_003D((char)(num >> 8));
				array[num5++] = (char)_0023_003DzK_0024ppVLk_003D((char)(num >> 4));
				array[num5++] = (char)_0023_003DzK_0024ppVLk_003D((char)num);
			}
			num2++;
		}
		array[num5] = '\0';
		return new string(array);
	}

	public static string _0023_003DzSq36vjfGtQK6wwUQOQ_003D_003D(string _0023_003Dzx_0024k0MJeH4KrY)
	{
		int num = 0;
		int i = 0;
		if (string.IsNullOrEmpty(_0023_003Dzx_0024k0MJeH4KrY))
		{
			return null;
		}
		for (; _0023_003Dzx_0024k0MJeH4KrY[i] != 0; i++)
		{
			num++;
		}
		return _0023_003DzVGPF7F6iC6_0024JtOLZOg_003D_003D(_0023_003Dzx_0024k0MJeH4KrY, num + 1);
	}

	public static void _0023_003DztkJKTUhSUMjuCUuRLA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, string _0023_003DzpiolRKc_003D)
	{
		int num = (string.IsNullOrEmpty(_0023_003DzpiolRKc_003D) ? (_0023_003DzIUFV0mq5977EDcTDuQ_003D_003D(_0023_003DzpiolRKc_003D) + 1) : 0);
		_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)num);
		for (int i = 0; i < num; i++)
		{
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[i]);
		}
	}

	public static void _0023_003DzZsgtj124ImqngnN8_0024A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char[] _0023_003DzpiolRKc_003D)
	{
		int num = 0;
		if (_0023_003DzpiolRKc_003D != null && _0023_003DzpiolRKc_003D.Length >= 1)
		{
			num = _0023_003DzpiolRKc_003D.Length + 1;
		}
		if (num != 0)
		{
			Array.Resize(ref _0023_003DzpiolRKc_003D, num);
			_0023_003DzpiolRKc_003D[num - 1] = '\0';
		}
		_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)num);
		for (int i = 0; i < num; i++)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[i]);
		}
	}

	public static int _0023_003DzmzwK_0024I2Bx4IE(int _0023_003Dzt_m8zV0_003D)
	{
		return Convert.ToInt32((_0023_003Dzt_m8zV0_003D >= 48 && _0023_003Dzt_m8zV0_003D <= 57) || (_0023_003Dzt_m8zV0_003D >= 97 && _0023_003Dzt_m8zV0_003D <= 102) || (_0023_003Dzt_m8zV0_003D >= 65 && _0023_003Dzt_m8zV0_003D <= 70));
	}

	public static void _0023_003Dzz9MZlueoJ2aE(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, string _0023_003DzuwH5j5s_003D)
	{
		if (_0023_003DzuwH5j5s_003D != null && _0023_003DzuwH5j5s_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302677514)))
		{
			_0023_003DzuwH5j5s_003D = _0023_003DzuwH5j5s_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302677514), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934509));
		}
		if (_0023_003Dz3nn_f5nvp37LLF_96g_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
			if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007)
			{
				if (string.IsNullOrEmpty(_0023_003DzuwH5j5s_003D))
				{
					_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
					return;
				}
				string text = _0023_003DzSq36vjfGtQK6wwUQOQ_003D_003D(_0023_003DzuwH5j5s_003D);
				int num = text.Length + 1;
				_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)num);
				for (int i = 0; i < num; i++)
				{
					_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, text[i]);
				}
				if (!string.IsNullOrEmpty(_0023_003DzuwH5j5s_003D))
				{
					text = null;
				}
			}
			else
			{
				_0023_003DztkJKTUhSUMjuCUuRLA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzuwH5j5s_003D);
			}
		}
		else if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007)
		{
			if (string.IsNullOrEmpty(_0023_003DzuwH5j5s_003D))
			{
				_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
				return;
			}
			char[] array = new char[(_0023_003DzuwH5j5s_003D.Length + 1) * 2];
			char[] value = array;
			int num2 = 0;
			int num3 = 0;
			ushort num4;
			while ((num4 = _0023_003DzuwH5j5s_003D[num2]) != 0)
			{
				if (num4 == 92 && _0023_003DzuwH5j5s_003D[0] == 'U' && _0023_003DzuwH5j5s_003D[1] == '+' && _0023_003DzmzwK_0024I2Bx4IE(_0023_003DzuwH5j5s_003D[2]) != 0 && _0023_003DzmzwK_0024I2Bx4IE(_0023_003DzuwH5j5s_003D[3]) != 0 && _0023_003DzmzwK_0024I2Bx4IE(_0023_003DzuwH5j5s_003D[4]) != 0 && _0023_003DzmzwK_0024I2Bx4IE(_0023_003DzuwH5j5s_003D[5]) != 0)
				{
					int num5 = _0023_003DzuwH5j5s_003D[2];
					if (Convert.ToInt32(Uri.IsHexDigit((char)num5)) > 0)
					{
						array[num3] = (char)num5;
						_0023_003DzuwH5j5s_003D += 6;
					}
					else
					{
						array[num3] = (char)num4;
					}
				}
				else
				{
					array[num3] = (char)num4;
				}
				num2++;
				num3++;
			}
			array[num3] = '\0';
			_0023_003DztkJKTUhSUMjuCUuRLA_003D_003D(_0023_003Dz3vRWvQs_003D, new string(value));
		}
		else
		{
			char[] _0023_003DzpiolRKc_003D = ((_0023_003DzuwH5j5s_003D != null) ? _0023_003DzuwH5j5s_003D.ToCharArray() : string.Empty.ToCharArray());
			_0023_003DzZsgtj124ImqngnN8_0024A_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D);
		}
	}

	public static void _0023_003DzeyfnSLufPtmOYCfR9w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, uint _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D > 255)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
			_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
		}
		else if (_0023_003DzPzO_0024GUk_003D == 0)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(2));
		}
		else
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)_0023_003DzPzO_0024GUk_003D);
		}
	}

	public static void _0023_003Dz8pL_0024qxCNAmolD7E61A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ulong _0023_003DzXULhp_00248_003D)
	{
		char[] array = new char[_0023_003Dz8Rb96EakVFNGlYpl1A_003D_003D];
		ulong num = 127uL;
		int num2 = _0023_003Dz8Rb96EakVFNGlYpl1A_003D_003D - 1;
		int num3 = 0;
		while (num2 >= 0)
		{
			array[num2] = (char)((_0023_003DzXULhp_00248_003D & num) >> num3);
			array[num2] |= '\u0080';
			num <<= 7;
			num2--;
			num3 += 7;
		}
		for (num2 = 0; num2 < 4 && (array[num2] & 0x7F) == 0; num2++)
		{
		}
		if ((array[num2] & 0x40) != 0 && num2 > 0)
		{
			num2--;
		}
		array[num2] &= '\u007f';
		for (num3 = _0023_003Dz8Rb96EakVFNGlYpl1A_003D_003D - 1; num3 >= num2; num3--)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, array[num3]);
		}
	}

	public static void _0023_003DzoYf1TaTuGH4yQgKE2w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003DzXULhp_00248_003D)
	{
		int num = 0;
		char[] array = new char[5];
		ulong num2 = 127uL;
		ulong num3 = (ulong)_0023_003DzXULhp_00248_003D;
		if (_0023_003DzXULhp_00248_003D < 0)
		{
			num = 1;
			num3 = (ulong)(-_0023_003DzXULhp_00248_003D);
		}
		int num4 = 4;
		int num5 = 0;
		while (num4 >= 0)
		{
			array[num4] = (char)((num3 & num2) >> num5);
			array[num4] |= '\u0080';
			num2 <<= 7;
			num4--;
			num5 += 7;
		}
		for (num4 = 0; num4 < 4 && (array[num4] & 0x7F) == 0; num4++)
		{
		}
		if ((array[num4] & 0x40) != 0 && num4 > 0)
		{
			num4--;
		}
		array[num4] &= '\u007f';
		if (num != 0)
		{
			array[num4] |= '@';
		}
		for (num5 = 4; num5 >= num4; num5--)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, array[num5]);
		}
	}

	public static void _0023_003Dz63aQG1mpqaVR61YnVg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ushort _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D >> 8));
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D & 0xFF));
	}

	public static ushort _0023_003DztYW39oFj4OGApieKpu6HTvk_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003Dzl4sfwALYBp27, ushort _0023_003Dz_0024D8vcl0_003D)
	{
		while (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D > '\0')
		{
			_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
		}
		if (_0023_003Dzl4sfwALYBp27 > _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + 2 >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		if (_0023_003Dzl4sfwALYBp27 > _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D || _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return 0;
		}
		long _0023_003Dz9JZgoew_003D = _0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D - _0023_003Dzl4sfwALYBp27;
		ushort num = (ushort)_0023_003DzTECSPIvA_0024fnvqe1H6g_003D_003D(_0023_003Dz_0024D8vcl0_003D, (uint)_0023_003Dzl4sfwALYBp27, _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, _0023_003Dz9JZgoew_003D);
		_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		_0023_003Dz63aQG1mpqaVR61YnVg_003D_003D(_0023_003Dz3vRWvQs_003D, num);
		return num;
	}

	public static void _0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D == 0L)
		{
			_0023_003DzRyg26WvI33SePw1FGg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzkTZ_xalfYzV8);
			return;
		}
		Array.Resize(ref _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)(_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D + _0023_003DzkTZ_xalfYzV8));
		if (_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D != null)
		{
			_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D += _0023_003DzkTZ_xalfYzV8;
		}
	}

	public static void _0023_003Dz9taVsgUdU82ChQ55_0024A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D != null)
		{
			_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D = null;
		}
		_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D = 0L;
	}

	public static void _0023_003DzrI_0024cKiQS35kUvs0x2g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ushort _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D < 256)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)_0023_003DzPzO_0024GUk_003D);
		}
		else if (_0023_003DzPzO_0024GUk_003D < 32767)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D - 496));
		}
		else
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
		}
	}

	public static void _0023_003DzbkQVEFeW8MiSgvY4zg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, long _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, (uint)((int)_0023_003DzPzO_0024GUk_003D & -1));
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, (uint)_0023_003DzPzO_0024GUk_003D);
	}

	public static void _0023_003DzbkQVEFeW8MiSgvY4zg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ulong _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, (uint)((int)_0023_003DzPzO_0024GUk_003D & -1));
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(_0023_003DzPzO_0024GUk_003D >> 32));
	}

	public static void _0023_003DzIsvFn_0024X7xeC2NfzH3A_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		byte[] bytes = BitConverter.GetBytes(_0023_003DzPzO_0024GUk_003D);
		for (int i = 0; i < 8; i++)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)bytes[i]);
		}
	}

	public static void _0023_003DzRngBjMiOwn9Z(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003Dzu2BB2ECAhm0u4k5_dyv5JPQ_003D _0023_003Dzy0p1LSY_003D, bool _0023_003DzQk7ez9E_003D)
	{
		if (_0023_003Dzy0p1LSY_003D == null)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
			return;
		}
		if (_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D == 0L)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)((uint)_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D << 4));
			return;
		}
		byte[] array = new byte[8];
		array = BitConverter.GetBytes(_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D);
		if (_0023_003DzQk7ez9E_003D)
		{
			array[4] = 1;
		}
		int num = 3;
		while (num >= 0 && array[num] == 0)
		{
			num--;
		}
		char c = (char)((uint)_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D << 4);
		c = (char)(c | (ushort)(num + 1));
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, c);
		while (num >= 0)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)array[num]);
			num--;
		}
	}

	public static void _0023_003DzRngBjMiOwn9Z(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003Dzu2BB2ECAhm0u4k5_dyv5JPQ_003D _0023_003Dzy0p1LSY_003D)
	{
		byte[] array = new byte[8];
		ulong num = 0uL;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D <= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_13)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)_0023_003Dzy0p1LSY_003D._0023_003Dz14lzA48_003D);
			_0023_003Dz5XODgc_sk4zo4j563A_003D_003D._0023_003DzYcojfyxfc_0024nM7mcxWA_003D_003D(ref _0023_003Dz3vRWvQs_003D, ref _0023_003Dzy0p1LSY_003D);
			return;
		}
		if (_0023_003Dzy0p1LSY_003D == null)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
			return;
		}
		if (_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D == 0L)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)((uint)_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D << 4));
			return;
		}
		Array.Clear(array, 0, array.Length);
		num = (ulong)_0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D;
		if (!BitConverter.IsLittleEndian)
		{
			num = _0023_003Dz6_0024dSqadBPPqd(num);
		}
		Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 0, 8);
		int num2 = 7;
		while (num2 >= 0 && array[num2] == 0)
		{
			num2--;
		}
		byte b = (byte)((uint)_0023_003Dzy0p1LSY_003D._0023_003DzzsSfH74_003D << 4);
		b |= (byte)(num2 + 1);
		_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)b);
		while (num2 >= 0)
		{
			_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)array[num2]);
			num2--;
		}
	}

	private static ulong _0023_003Dz6_0024dSqadBPPqd(ulong _0023_003DzPzO_0024GUk_003D)
	{
		return ((_0023_003DzPzO_0024GUk_003D & 0xFF) << 56) | ((_0023_003DzPzO_0024GUk_003D & 0xFF00) << 40) | ((_0023_003DzPzO_0024GUk_003D & 0xFF0000) << 24) | ((_0023_003DzPzO_0024GUk_003D & 0xFF000000u) << 8) | ((_0023_003DzPzO_0024GUk_003D & 0xFF00000000L) >> 8) | ((_0023_003DzPzO_0024GUk_003D & 0xFF0000000000L) >> 24) | ((_0023_003DzPzO_0024GUk_003D & 0xFF000000000000L) >> 40) | ((_0023_003DzPzO_0024GUk_003D & 0xFF00000000000000uL) >> 56);
	}

	public static void _0023_003DzNsO_0024nKqHaAjKImoVIQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, ulong _0023_003DzPzO_0024GUk_003D)
	{
		int num = 0;
		int num2 = 0;
		ulong num3 = 17293822569102704640uL;
		num = 16;
		while (num != 0)
		{
			if ((_0023_003DzPzO_0024GUk_003D & num3) != 0L)
			{
				num2 = num;
				break;
			}
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(num2 << 2));
			_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, (char)(num2 & 1));
			for (num = 0; num < num2; num++)
			{
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)(_0023_003DzPzO_0024GUk_003D & 0xFF));
				_0023_003DzPzO_0024GUk_003D >>= 8;
			}
			num--;
			num3 >>= 8;
		}
	}

	public static void _0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D == 0.0)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(2));
			return;
		}
		if (_0023_003DzPzO_0024GUk_003D == 1.0)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			return;
		}
		_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
		_0023_003DzIsvFn_0024X7xeC2NfzH3A_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
	}

	public static void _0023_003DzqNQOROFccemdpS4S6uubZ64_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D _0023_003Dz9s8KP64_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_13)
		{
			_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzxQiMvvk_003D);
			_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzqsdMfnE_003D);
		}
		else
		{
			_0023_003DzeyfnSLufPtmOYCfR9w_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzxQiMvvk_003D);
			_0023_003DzeyfnSLufPtmOYCfR9w_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzqsdMfnE_003D);
		}
	}

	public static void _0023_003DzhZebN9rsc34Qwal6dufbt5Q_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D _0023_003Dz9s8KP64_003D)
	{
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzxQiMvvk_003D);
		_0023_003Dz6WvvySCN9jlVhqSHbg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz9s8KP64_003D._0023_003DzqsdMfnE_003D);
	}

	public static int _0023_003Dz8tP0kw0r48_b(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, string _0023_003Dz_0024n2nrac_003D)
	{
		if (string.IsNullOrEmpty(_0023_003Dz_0024n2nrac_003D))
		{
			return 1;
		}
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007)
		{
			return Convert.ToInt32(!Convert.ToBoolean(_0023_003Dz_0024n2nrac_003D[0]));
		}
		return Convert.ToInt32(!Convert.ToBoolean((ushort)_0023_003Dz_0024n2nrac_003D[0]));
	}

	public static void _0023_003DzyjBv_qJg2rn3_002479WeA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003DzyHvf9x5nZeqH, _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004)
		{
			if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004)
			{
				_0023_003DzhrkxzwCk8mrWg6ZyTKFZfiU_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz1MMYB1g_003D);
			}
			_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
			_0023_003DzeyfnSLufPtmOYCfR9w_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D);
			if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D == 0 && (_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D & 0xFF000000u) != 0)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = (int)_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D >> 24;
			}
			if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D == 194)
			{
				if (_0023_003Dz1MMYB1g_003D._0023_003DzS_00246o7tc_003D != null && _0023_003Dz8tP0kw0r48_b(_0023_003Dz3vRWvQs_003D, _0023_003Dz1MMYB1g_003D._0023_003DzS_00246o7tc_003D) == 0)
				{
					_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D |= 1;
				}
				if (_0023_003Dz1MMYB1g_003D._0023_003DzS_00246o7tc_003D != null && _0023_003Dz8tP0kw0r48_b(_0023_003Dz3vRWvQs_003D, _0023_003Dz1MMYB1g_003D._0023_003DzNRAY4Ytn3BwJ) == 0)
				{
					_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D |= 2;
				}
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, (char)_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D);
				if ((_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D & 1) != 0)
				{
					_0023_003Dzz9MZlueoJ2aE(_0023_003DzyHvf9x5nZeqH, _0023_003Dz1MMYB1g_003D._0023_003DzS_00246o7tc_003D);
				}
				if ((_0023_003Dz1MMYB1g_003D._0023_003Dzjcx0hV4_003D & 2) != 0)
				{
					_0023_003Dzz9MZlueoJ2aE(_0023_003DzyHvf9x5nZeqH, _0023_003Dz1MMYB1g_003D._0023_003DzNRAY4Ytn3BwJ);
				}
			}
			else
			{
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, '\0');
			}
		}
		else
		{
			_0023_003DzfnNjWRK7Xova5AjkplwiBEf39XUG(_0023_003Dz3vRWvQs_003D, _0023_003Dz1MMYB1g_003D);
			_0023_003DzhSDF7_Wqyum0y4Ie9A_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D);
		}
	}

	public static void _0023_003DzNXcleaHqnHzQq_5nhw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, uint _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)_0023_003DzPzO_0024GUk_003D);
		if (_0023_003DzPzO_0024GUk_003D > 32767)
		{
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(_0023_003DzPzO_0024GUk_003D >> 15));
		}
	}

	public static void _0023_003DzhG_GW6MfGVv7bhqWGA_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, char _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(_0023_003DzPzO_0024GUk_003D & 8));
		_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(_0023_003DzPzO_0024GUk_003D & 4));
		_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(_0023_003DzPzO_0024GUk_003D & 2));
		_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(_0023_003DzPzO_0024GUk_003D & 1));
	}

	public static char _0023_003DzDrWDC2x2zTEIADD1nQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003DzPzO_0024GUk_003D, double _0023_003DzSuxKDcTKSrsk)
	{
		char result = Convert.ToChar(0);
		if (Math.Abs(_0023_003DzPzO_0024GUk_003D - _0023_003DzSuxKDcTKSrsk) < 1E-12)
		{
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
		}
		else
		{
			byte[] bytes = BitConverter.GetBytes(_0023_003DzPzO_0024GUk_003D);
			byte[] bytes2 = BitConverter.GetBytes(_0023_003DzSuxKDcTKSrsk);
			ushort[] destinationArray = new ushort[bytes.Length];
			Array.Copy(bytes, destinationArray, bytes.Length);
			ushort[] destinationArray2 = new ushort[bytes2.Length];
			Array.Copy(bytes2, destinationArray2, bytes2.Length);
			result = Convert.ToChar(3);
			_0023_003DzQZehKf3sykuirWo42Q_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToChar(3));
			_0023_003DzIsvFn_0024X7xeC2NfzH3A_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
		}
		return result;
	}

	public static void _0023_003Dz5F_0024FsTVG7SJAFPufAg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2000)
		{
			if (_0023_003DzPzO_0024GUk_003D == 0.0)
			{
				_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
				return;
			}
			_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
			_0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
		}
		else
		{
			_0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzPzO_0024GUk_003D);
		}
	}

	public static void _0023_003Dz_xWCWFU600eQBgnbDg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2000 && _0023_003DzBJFJHwk_003D == 0.0 && _0023_003Dz40R7bAU_003D == 0.0 && _0023_003DzId5C3LA_003D == 1.0)
		{
			_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(1));
			return;
		}
		_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, Convert.ToChar(0));
		_0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzBJFJHwk_003D);
		_0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz40R7bAU_003D);
		if (_0023_003DzBJFJHwk_003D == 0.0 && _0023_003Dz40R7bAU_003D == 0.0)
		{
			_0023_003DzId5C3LA_003D = ((_0023_003DzId5C3LA_003D <= 0.0) ? (-1.0) : 1.0);
		}
		_0023_003DzHn_fNLrdLTrOOcli7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzId5C3LA_003D);
	}

	public static uint _0023_003DzbY6K_00246w6vmXLOLyWwGz1AuA_003D(uint _0023_003Dz_0024D8vcl0_003D, uint _0023_003DzyzK8swU_003D, byte[] _0023_003DzBDOXyf0_003D, int _0023_003Dz9JZgoew_003D)
	{
		uint num = ~_0023_003Dz_0024D8vcl0_003D;
		uint[] array = new uint[256]
		{
			0u, 1996959894u, 3993919788u, 2567524794u, 124634137u, 1886057615u, 3915621685u, 2657392035u, 249268274u, 2044508324u,
			3772115230u, 2547177864u, 162941995u, 2125561021u, 3887607047u, 2428444049u, 498536548u, 1789927666u, 4089016648u, 2227061214u,
			450548861u, 1843258603u, 4107580753u, 2211677639u, 325883990u, 1684777152u, 4251122042u, 2321926636u, 335633487u, 1661365465u,
			4195302755u, 2366115317u, 997073096u, 1281953886u, 3579855332u, 2724688242u, 1006888145u, 1258607687u, 3524101629u, 2768942443u,
			901097722u, 1119000684u, 3686517206u, 2898065728u, 853044451u, 1172266101u, 3705015759u, 2882616665u, 651767980u, 1373503546u,
			3369554304u, 3218104598u, 565507253u, 1454621731u, 3485111705u, 3099436303u, 671266974u, 1594198024u, 3322730930u, 2970347812u,
			795835527u, 1483230225u, 3244367275u, 3060149565u, 1994146192u, 31158534u, 2563907772u, 4023717930u, 1907459465u, 112637215u,
			2680153253u, 3904427059u, 2013776290u, 251722036u, 2517215374u, 3775830040u, 2137656763u, 141376813u, 2439277719u, 3865271297u,
			1802195444u, 476864866u, 2238001368u, 4066508878u, 1812370925u, 453092731u, 2181625025u, 4111451223u, 1706088902u, 314042704u,
			2344532202u, 4240017532u, 1658658271u, 366619977u, 2362670323u, 4224994405u, 1303535960u, 984961486u, 2747007092u, 3569037538u,
			1256170817u, 1037604311u, 2765210733u, 3554079995u, 1131014506u, 879679996u, 2909243462u, 3663771856u, 1141124467u, 855842277u,
			2852801631u, 3708648649u, 1342533948u, 654459306u, 3188396048u, 3373015174u, 1466479909u, 544179635u, 3110523913u, 3462522015u,
			1591671054u, 702138776u, 2966460450u, 3352799412u, 1504918807u, 783551873u, 3082640443u, 3233442989u, 3988292384u, 2596254646u,
			62317068u, 1957810842u, 3939845945u, 2647816111u, 81470997u, 1943803523u, 3814918930u, 2489596804u, 225274430u, 2053790376u,
			3826175755u, 2466906013u, 167816743u, 2097651377u, 4027552580u, 2265490386u, 503444072u, 1762050814u, 4150417245u, 2154129355u,
			426522225u, 1852507879u, 4275313526u, 2312317920u, 282753626u, 1742555852u, 4189708143u, 2394877945u, 397917763u, 1622183637u,
			3604390888u, 2714866558u, 953729732u, 1340076626u, 3518719985u, 2797360999u, 1068828381u, 1219638859u, 3624741850u, 2936675148u,
			906185462u, 1090812512u, 3747672003u, 2825379669u, 829329135u, 1181335161u, 3412177804u, 3160834842u, 628085408u, 1382605366u,
			3423369109u, 3138078467u, 570562233u, 1426400815u, 3317316542u, 2998733608u, 733239954u, 1555261956u, 3268935591u, 3050360625u,
			752459403u, 1541320221u, 2607071920u, 3965973030u, 1969922972u, 40735498u, 2617837225u, 3943577151u, 1913087877u, 83908371u,
			2512341634u, 3803740692u, 2075208622u, 213261112u, 2463272603u, 3855990285u, 2094854071u, 198958881u, 2262029012u, 4057260610u,
			1759359992u, 534414190u, 2176718541u, 4139329115u, 1873836001u, 414664567u, 2282248934u, 4279200368u, 1711684554u, 285281116u,
			2405801727u, 4167216745u, 1634467795u, 376229701u, 2685067896u, 3608007406u, 1308918612u, 956543938u, 2808555105u, 3495958263u,
			1231636301u, 1047427035u, 2932959818u, 3654703836u, 1088359270u, 936918000u, 2847714899u, 3736837829u, 1202900863u, 817233897u,
			3183342108u, 3401237130u, 1404277552u, 615818150u, 3134207493u, 3453421203u, 1423857449u, 601450431u, 3009837614u, 3294710456u,
			1567103746u, 711928724u, 3020668471u, 3272380065u, 1510334235u, 755167117u
		};
		while (_0023_003Dz9JZgoew_003D > 0)
		{
			char c = (char)(_0023_003DzBDOXyf0_003D[_0023_003DzyzK8swU_003D] ^ (ushort)(num & 0xFF));
			num = ((num >> 8) & 0xFF) ^ array[(uint)c];
			_0023_003DzyzK8swU_003D++;
			_0023_003Dz9JZgoew_003D--;
		}
		return ~num;
	}

	public static _0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D _0023_003DzkZZxf07DhIDKv6VbCgVKcyA_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		_0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D result = default(_0023_003DzqpJvXc3YfskYIv_00241BzA09lXd7ra2qxjZ0Q_003D_003D);
		result._0023_003DzxQiMvvk_003D = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		result._0023_003DzqsdMfnE_003D = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		result._0023_003DzPzO_0024GUk_003D = (double)result._0023_003DzxQiMvvk_003D + (double)result._0023_003DzqsdMfnE_003D / 86400000.0;
		return result;
	}

	public static char[] _0023_003DzfjmH9GTZWkAtZpQAVw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char[] array = null;
		ushort num = _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num * 2 > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		array = new char[num];
		for (ushort num2 = 0; num2 < num; num2++)
		{
			array[num2] = Convert.ToChar(_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D));
		}
		if (num != 0)
		{
			Array.Resize(ref array, num - 1);
		}
		return array;
	}

	public static char[] _0023_003DzawQRa_7eZbw6WU8xTg_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		char[] array = null;
		ushort num = _0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		array = new char[num];
		for (ushort num2 = 0; num2 < num; num2++)
		{
			array[num2] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return array;
	}

	public static string _0023_003DzeIJJVdCsD9KaAH64bQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 && (_0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xC0) == 0)
		{
			char[] array = null;
			uint num2 = num / 2;
			if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
			{
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
				return null;
			}
			array = new char[num];
			if (array == null)
			{
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xF;
				return null;
			}
			for (uint num3 = 0u; num3 < num2; num3++)
			{
				array[num3] = (char)_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
			}
			array = array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DztjF2dk50LfVyilGQbd_Q1Ou_A0DQ).ToArray();
			return new string(array);
		}
		char[] array2 = null;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		array2 = new char[num];
		for (uint num3 = 0u; num3 < num; num3++)
		{
			array2[num3] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return new string(array2);
	}

	public static string _0023_003DzCQYbmisjbQ3OcUOG_0024w_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		uint num = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 && (_0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & 0xC0) == 0)
		{
			char[] array = null;
			uint num2 = 0u;
			uint num3 = num / 4;
			long _0023_003Dz27AcvYoE2Fgi = _0023_003Dzhp8Ae59zU5tx(_0023_003Dz3vRWvQs_003D);
			if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D || num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
			{
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
				return null;
			}
			array = new char[num + 2];
			if (array == null)
			{
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
				return null;
			}
			num2 = _0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
			if ((num2 & 0xFF0000) != 0)
			{
				_0023_003Dzze2UXTEwHs7_0024(_0023_003Dz3vRWvQs_003D, _0023_003Dz27AcvYoE2Fgi);
				num3 = num / 2;
				_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
				for (uint num4 = 0u; num4 < num3; num4++)
				{
					array[num4] = (char)_0023_003Dz85zD9xmra6Q12EgnBg_003D_003D(_0023_003Dz3vRWvQs_003D);
				}
			}
			else
			{
				array[0] = (char)num2;
				for (uint num4 = 1u; num4 < num3; num4++)
				{
					array[num4] = (char)_0023_003DzOrZffIjHys4Oo7jm5w_003D_003D(_0023_003Dz3vRWvQs_003D);
				}
			}
			array = array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzC_juke0i_LiHo_udbRIomOs6lPlL).ToArray();
			return new string(array);
		}
		char[] array2 = null;
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + num > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return null;
		}
		array2 = new char[num];
		for (uint num4 = 0u; num4 < num; num4++)
		{
			array2[num4] = _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		return new string(array2);
	}

	public static bool _0023_003Dz3nn_f5nvp37LLF_96g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 && (_0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003Dz4ISvjGxDRDPQDj1sgA_003D_003D()) == 0)
		{
			return true;
		}
		return false;
	}

	public static void _0023_003Dzhk7yl3aOSxg4(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzV_0024cl2oc_003D)
	{
		if (_0023_003DzV_0024cl2oc_003D._0023_003DzBJFJHwk_003D == 0.0 && _0023_003DzV_0024cl2oc_003D._0023_003Dz40R7bAU_003D == 0.0)
		{
			_0023_003DzV_0024cl2oc_003D._0023_003DzId5C3LA_003D = ((_0023_003DzV_0024cl2oc_003D._0023_003DzId5C3LA_003D <= 0.0) ? (-1.0) : 1.0);
		}
	}

	public static bool _0023_003DzJynTp1gV3QJODbQ6Sw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003Dzt1tcnPg_003D, int _0023_003DzLyzNvlA_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003Dzt1tcnPg_003D >= _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			return true;
		}
		return false;
	}

	public static ushort _0023_003DzmFHrC5Of4sv_0024K_yWtQ_003D_003D(string _0023_003Dz1v6oPQk_003D)
	{
		return (ushort)(((uint)_0023_003Dz1v6oPQk_003D[1] << 8) + _0023_003Dz1v6oPQk_003D[0]);
	}

	private static void _0023_003DzhrkxzwCk8mrWg6ZyTKFZfiU_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004 && _0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004)
		{
			if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D == 0)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = 195;
			}
			if (_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D == 256)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = 192;
			}
			else if (_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D == 0)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = 193;
			}
			_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D = (uint)(_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D << 24);
			if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D == 195)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D |= _0023_003DzeO1oUoawysI7gD_sTe7zFNQM4Rd2(_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D);
			}
		}
	}

	private static void _0023_003DzfnNjWRK7Xova5AjkplwiBEf39XUG(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004 || _0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004)
		{
			return;
		}
		if (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D == 0 && (_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D & 0xFF000000u) != 0)
		{
			_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D = (int)(_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D >> 24);
		}
		_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D &= 16777215u;
		_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = Convert.ToInt16(_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003Dz8HcH5k8gg4tjdHQeMg_003D_003D(_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D));
		switch (_0023_003Dz1MMYB1g_003D._0023_003DzJTQziP0_003D)
		{
		case 0:
		case 192:
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = 256;
			break;
		case 193:
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = 0;
			break;
		case 194:
		case 195:
			if (_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D == 256)
			{
				_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = Convert.ToInt16(_0023_003Dz1MMYB1g_003D._0023_003DzFd5hios_003D & 0xFF);
			}
			break;
		case 200:
			_0023_003Dz1MMYB1g_003D._0023_003DzyzK8swU_003D = 0;
			break;
		}
	}

	private static uint _0023_003DzeO1oUoawysI7gD_sTe7zFNQM4Rd2(short _0023_003DzyzK8swU_003D)
	{
		if (_0023_003DzyzK8swU_003D >= 256)
		{
			return 0u;
		}
		_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2 = default(_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D);
		_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzAN9e1_0024CqSaV8Z5bYhw_003D_003D[_0023_003DzyzK8swU_003D];
		return (uint)((_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003DzRpXgovo_003D << 16) | (_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003Dz5rQzobg_003D << 8) | _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003Dz1v6oPQk_003D);
	}

	public static void _0023_003DzbLltiX65NnCMSw2BQQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003Dz14lzA48_003D)
	{
		if (_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D == 0L)
		{
			_0023_003DzRyg26WvI33SePw1FGg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz14lzA48_003D);
			return;
		}
		Array.Resize(ref _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D + _0023_003Dz14lzA48_003D);
		if (_0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D == null)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
		}
		_0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003DzI5_0024Ghy3dyMTX(ref _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D, '\0', _0023_003Dz14lzA48_003D);
		_0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D += _0023_003Dz14lzA48_003D;
	}

	public static bool _0023_003Dz3ZaP1M22bbCK9dFi5tFTVXdzF14J(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D)
	{
		if ((_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 && _0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007) || (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 && _0023_003Dz3vRWvQs_003D._0023_003DzWyA_BDmgBAuw < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007))
		{
			return true;
		}
		return false;
	}

	public static void _0023_003DzLaQtQNE3I5oo0oG0cQ_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003DzNs_0024gaB7uF94h)
	{
		long num = _0023_003Dzhp8Ae59zU5tx(_0023_003DzNs_0024gaB7uF94h);
		long _0023_003DzICoifrU_003D = _0023_003DzNs_0024gaB7uF94h._0023_003DzICoifrU_003D;
		while (_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D + _0023_003DzICoifrU_003D > _0023_003Dz3vRWvQs_003D._0023_003Dz14lzA48_003D)
		{
			_0023_003Dz0YGEGME3kRS8Z_002436Ag_003D_003D(_0023_003Dz3vRWvQs_003D);
		}
		if (_0023_003Dz3vRWvQs_003D._0023_003DzR2oVwk0_003D == '\0')
		{
			_0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003Dz6HmSyXEGI2Yd(ref _0023_003Dz3vRWvQs_003D._0023_003DzpiolRKc_003D, (int)_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D, _0023_003DzNs_0024gaB7uF94h._0023_003DzpiolRKc_003D, 0, (int)_0023_003DzICoifrU_003D);
			_0023_003Dz3vRWvQs_003D._0023_003DzICoifrU_003D += _0023_003DzICoifrU_003D;
		}
		else
		{
			_0023_003Dzze2UXTEwHs7_0024(_0023_003DzNs_0024gaB7uF94h, 0L);
			for (uint num2 = 0u; num2 < _0023_003DzICoifrU_003D; num2++)
			{
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzNERU8d6edpVTDpw3pg_003D_003D(_0023_003DzNs_0024gaB7uF94h));
			}
			for (uint num2 = 0u; num2 < num % 8; num2++)
			{
				_0023_003DzQsq2ZYzCZZUp(_0023_003Dz3vRWvQs_003D, _0023_003DzZFbeCjw_0024SgOL(_0023_003DzNs_0024gaB7uF94h));
			}
		}
		_0023_003Dzze2UXTEwHs7_0024(_0023_003DzNs_0024gaB7uF94h, 0L);
	}

	public static void _0023_003DziTDjd0u6l7fNn63Z0_0024wLs9E_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003Dz14lzA48_003D, _0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003DzHxHuHA_4oGZc)
	{
		_0023_003DzRyg26WvI33SePw1FGg_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003Dz14lzA48_003D);
		_0023_003Dz6oMnGdQgzlRf55iK7g_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzHxHuHA_4oGZc);
	}

	public static void _0023_003DziXN5ApGYXXPKs1N_0024uw_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz63aQG1mpqaVR61YnVg_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D >> 16));
		_0023_003Dz63aQG1mpqaVR61YnVg_003D_003D(_0023_003Dz3vRWvQs_003D, Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D & 0xFFFF));
	}

	public static void _0023_003Dz6DUEIZK6UMeDnihc3g_003D_003D(_0023_003DzFvyq4DxY5iiH33RiCQ_003D_003D _0023_003Dz3vRWvQs_003D, string _0023_003DzpiolRKc_003D)
	{
		long num = 0L;
		num = ((_0023_003DzpiolRKc_003D == null) ? 0 : ((!_0023_003Dz3nn_f5nvp37LLF_96g_003D_003D(_0023_003Dz3vRWvQs_003D)) ? _0023_003DzpiolRKc_003D.Length : _0023_003DzIUFV0mq5977EDcTDuQ_003D_003D(_0023_003DzpiolRKc_003D)));
		if (num > 32767)
		{
			_0023_003DzFF8AlvkBb2jhwmYC0g_003D_003D = _0023_003Dz3vRWvQs_003D._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003DzCxlNIMUwS8YMmZodO0uX_0024A8FO3Gn;
			num = 32767L;
		}
		else if (num == 0L)
		{
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
		}
		else if (_0023_003Dz3vRWvQs_003D._0023_003DzQ3hPewo_003D >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_13)
		{
			if (!_0023_003Dz3nn_f5nvp37LLF_96g_003D_003D(_0023_003Dz3vRWvQs_003D))
			{
				_0023_003DzfV97elAdPe3hGmo3PAN9af0_003D(_0023_003DzpiolRKc_003D.ToCharArray());
				_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)num);
				for (int i = 0; i <= num; i++)
				{
					_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[i]);
				}
			}
			else
			{
				_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(num + 1));
				for (int j = 0; j <= num; j++)
				{
					_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[j]);
				}
			}
		}
		else if (_0023_003Dz3nn_f5nvp37LLF_96g_003D_003D(_0023_003Dz3vRWvQs_003D))
		{
			char[] _0023_003DzaoQTclc_003D = new char[1024];
			string text = _0023_003Dz6cnF59iRD2LqmcbGOw_003D_003D(_0023_003DzpiolRKc_003D);
			_0023_003DzYqZW7zk4t9HcVqjur_0024DMMHY_003D(ref _0023_003DzaoQTclc_003D, 0, text.ToCharArray(), 0, 1024);
			num = _0023_003DzaoQTclc_003D.Length;
			if (num != 0L)
			{
				_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(num + 1));
				for (int k = 0; k <= num; k++)
				{
					_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzaoQTclc_003D[k]);
				}
			}
			else
			{
				_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
			}
			text = null;
		}
		else if (num != 0L)
		{
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, (ushort)(num + 1));
			for (int l = 0; l <= num; l++)
			{
				_0023_003DzVpsTDmyAgIhtKP_rmA_003D_003D(_0023_003Dz3vRWvQs_003D, _0023_003DzpiolRKc_003D[l]);
			}
		}
		else
		{
			_0023_003DzCf5YJKBhd_0024C1FLDCtQ_003D_003D(_0023_003Dz3vRWvQs_003D, 0);
		}
	}

	public static bool _0023_003DzhRMdBKBwsaVPwVzuDQdguNc_003D(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003DzRafC4s_0024Sj8Qc)
	{
		if (_0023_003DzRafC4s_0024Sj8Qc._0023_003Dz8Vwa6Pc_003D._0023_003DzWyA_BDmgBAuw >= _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007)
		{
			return (_0023_003DzRafC4s_0024Sj8Qc._0023_003DzG_0024i1Pyc_003D & _0023_003DzT7AmRxK_tlTdDtdoaEv5_0024XtV1mn_0024._0023_003Dz4ISvjGxDRDPQDj1sgA_003D_003D()) == 0;
		}
		return false;
	}
}
