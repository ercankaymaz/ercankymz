using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

internal static class _0023_003DzfjT7Eit3rFpkIqO_0024WhOaMOr8PS8G
{
	private struct _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg
	{
		public Version _0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg;

		public bool _0023_003DzVt95OwotLijCnA10daiPTy7gy5cF;

		public string _0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi;

		public string _0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY;

		public bool _0023_003Dzj7bWEfXcgzl5Dn7gOPdw_CLzrPTX;

		public string _0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe;

		public bool _0023_003DzhD4q2JaSeWD1SbYheNmNh1KGquX3;

		public _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg(string _0023_003DznrxtSFOrVpm6HA6GQjtimf3C9tKi)
		{
			this = default(_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg);
			_0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg = new Version();
			_0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi = string.Empty;
			string[] array = _0023_003DznrxtSFOrVpm6HA6GQjtimf3C9tKi.Split(',');
			foreach (string text in array)
			{
				string text2 = text.Trim();
				if (text2.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315839), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg = new Version(text2.Substring(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315839).Length));
					_0023_003DzVt95OwotLijCnA10daiPTy7gy5cF = true;
				}
				else if (text2.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315824), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY = text2.Substring(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315824).Length);
					if (_0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315793), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY = null;
					}
					_0023_003Dzj7bWEfXcgzl5Dn7gOPdw_CLzrPTX = true;
				}
				else if (text2.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315779), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe = text2.Substring(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315779).Length);
					if (_0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315901), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe = null;
					}
					_0023_003DzhD4q2JaSeWD1SbYheNmNh1KGquX3 = true;
				}
				else
				{
					_0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi = text2;
				}
			}
		}

		public string _0023_003DzyJSwnkk8Hnvi(bool _0023_003DzSsBE9g1_s4TpT4z1FLRqnSjBvsIK)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi);
			if (_0023_003DzSsBE9g1_s4TpT4z1FLRqnSjBvsIK)
			{
				stringBuilder.Append(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315874)).Append(_0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg);
			}
			stringBuilder.Append(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315857)).Append(_0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY ?? _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315856)).Append(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315698))
				.Append(_0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe ?? _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315690));
			return stringBuilder.ToString();
		}
	}

	private sealed class _0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT
	{
		private byte[] _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg = new byte[256];

		private int _0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0;

		private int _0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7;

		public _0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT(byte[] _0023_003DzibgHvbr7axovGOoyC_s0nE4_003D)
		{
			int num = _0023_003DzibgHvbr7axovGOoyC_s0nE4_003D.Length;
			for (_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 = 0; _0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 < 256; _0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0++)
			{
				_0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0] = (byte)_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0;
			}
			for (_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 = (_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7 = 0); _0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 < 256; _0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0++)
			{
				_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7 = (_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7 + _0023_003DzibgHvbr7axovGOoyC_s0nE4_003D[_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 % num] + _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0]) & 0xFF;
				_0023_003DzukbIhwAwrrNYm6_x0UA_mlllz3qY(_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0, _0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7);
			}
		}

		private void _0023_003DzukbIhwAwrrNYm6_x0UA_mlllz3qY(int _0023_003DzrEjTJrzu1l5hesgxB9NoL46_0024Ty5i, int _0023_003DzAwB96_kEttdJF4Vv9_7R1rxtlPs6)
		{
			byte b = _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzrEjTJrzu1l5hesgxB9NoL46_0024Ty5i];
			_0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzrEjTJrzu1l5hesgxB9NoL46_0024Ty5i] = _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzAwB96_kEttdJF4Vv9_7R1rxtlPs6];
			_0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzAwB96_kEttdJF4Vv9_7R1rxtlPs6] = b;
		}

		public byte _0023_003DzcCKlwUl9YCKF7PDDtedO528_003D()
		{
			_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 = (_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0 + 1) & 0xFF;
			_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7 = (_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7 + _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0]) & 0xFF;
			_0023_003DzukbIhwAwrrNYm6_x0UA_mlllz3qY(_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0, _0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7);
			return _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[(byte)(_0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzTAQT1a1UXn5P_0024ck1NZNAtBoVMfj0] + _0023_003Dztmkc_0024M5pCJ0RGJ7uQmXMTLZ4AGfg[_0023_003DzoIcMWW93sPQEYZIJh8bsFX_0024uj_0024m7])];
		}
	}

	private static class _0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D
	{
		internal sealed class _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo
		{
			public string _0023_003DzVV5q_0024H2_RdUVXPIL_0024V7q_OA_003D;

			private string _0023_003Dzutvy4aLogzyWu_bnZ__vA7tPi2SQ;

			public string _0023_003Dz6RyEi5A_003D;

			public string _0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv;

			public bool _0023_003DzINsdZnSdGwqzgWMmCtbLxzvQV03Q;

			public bool _0023_003DzLioTw_00245sMTZHqh0tZgSPNm1b0Z99;

			public bool _0023_003DzcaI6hkeDtmYHweBptkaGRsv63Krg;

			public bool _0023_003DzC4N_0024G3ZbfoMH7u1qdrkpEPfb1pbm;

			public bool _0023_003Dzxztxz_92Jfkd55LmaMCoxddQfs_0024y;

			public bool _0023_003Dz2Kc_phXB4YbzHvY20DZ6LQjjqHCL;

			public string _0023_003Dz_0024IhMQuEmeNhkKEarutLbvf8vph2_0024;

			private string _0023_003DzkFysjnHxnC4VJgzv4iOMbJ5GfALX;

			public string _0023_003DzyNQMuWREENOFIQipMY08GYGHKEzJ()
			{
				if (_0023_003Dzutvy4aLogzyWu_bnZ__vA7tPi2SQ == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003DzVV5q_0024H2_RdUVXPIL_0024V7q_OA_003D);
					_0023_003Dzutvy4aLogzyWu_bnZ__vA7tPi2SQ = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003Dzutvy4aLogzyWu_bnZ__vA7tPi2SQ;
			}

			public string _0023_003DzHZqXBB_00244Q_0024iBkHCdw8FdpNeX3tdg()
			{
				if (_0023_003DzkFysjnHxnC4VJgzv4iOMbJ5GfALX == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003Dz_0024IhMQuEmeNhkKEarutLbvf8vph2_0024);
					_0023_003DzkFysjnHxnC4VJgzv4iOMbJ5GfALX = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003DzkFysjnHxnC4VJgzv4iOMbJ5GfALX;
			}
		}

		private struct _0023_003Dzh8SK4yI_003D
		{
			private readonly string _0023_003DzyqLJe_0024w_003D;

			private FileStream _0023_003DzBZAGDbo2LlXn;

			public _0023_003Dzh8SK4yI_003D(string _0023_003Dzi5WnxDI_003D)
			{
				this = default(_0023_003Dzh8SK4yI_003D);
				_0023_003DzyqLJe_0024w_003D = _0023_003Dzi5WnxDI_003D;
			}

			public bool _0023_003DzqnS08i0_003D()
			{
				try
				{
					if (_0023_003DzBZAGDbo2LlXn != null)
					{
						return false;
					}
					_0023_003DzBZAGDbo2LlXn = new FileStream(_0023_003DzyqLJe_0024w_003D, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128, FileOptions.DeleteOnClose);
				}
				catch
				{
					return false;
				}
				return true;
			}

			public void _0023_003Dzkq42Q9Q_003D()
			{
				Stopwatch stopwatch = null;
				int num = 25;
				int num2 = 250;
				while (!_0023_003DzqnS08i0_003D())
				{
					if (stopwatch == null)
					{
						stopwatch = Stopwatch.StartNew();
					}
					else
					{
						if (stopwatch.Elapsed.TotalSeconds > 300.0)
						{
							throw new TimeoutException(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315679), _0023_003DzyqLJe_0024w_003D));
						}
						if (num < num2)
						{
							num = Math.Min(num * 2, num2);
						}
					}
					Thread.Sleep(num);
				}
			}

			public void _0023_003DzBQZQ_0024yw_003D()
			{
				if (_0023_003DzBZAGDbo2LlXn != null)
				{
					_0023_003DzBZAGDbo2LlXn.Dispose();
					_0023_003DzBZAGDbo2LlXn = null;
				}
			}
		}

		private sealed class _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D : IEnumerable<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo>, IEnumerable, IEnumerator<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo>, IDisposable, IEnumerator
		{
			private int _0023_003DzwdenRi7jLOW7;

			private _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003Dz1ia6zb9jvQhU;

			private int _0023_003Dz3cfb3P0AOYvXFR8B_g_003D_003D;

			private string _0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D;

			public string _0023_003Dzl3k1qyFrrxANLXfg_0024A_003D_003D;

			private string[] _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D;

			private string _0023_003Dz7tx8zFpEH8hhU765Vw_003D_003D;

			private int _0023_003DzSLS9woq4F0gp;

			[DebuggerHidden]
			public _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D(int _0023_003DzwdenRi7jLOW7)
			{
				this._0023_003DzwdenRi7jLOW7 = _0023_003DzwdenRi7jLOW7;
				_0023_003Dz3cfb3P0AOYvXFR8B_g_003D_003D = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			private void _0023_003DzVQWSW1R3jeNNTBpIuA_003D_003D()
			{
				_0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D = null;
				_0023_003Dz7tx8zFpEH8hhU765Vw_003D_003D = null;
				_0023_003DzwdenRi7jLOW7 = -2;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zVQWSW1R3jeNNTBpIuA==
				this._0023_003DzVQWSW1R3jeNNTBpIuA_003D_003D();
			}

			private bool _0023_003DzGUKktgk_003D()
			{
				int num = _0023_003DzwdenRi7jLOW7;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_0023_003DzwdenRi7jLOW7 = -1;
					goto IL_0163;
				}
				_0023_003DzwdenRi7jLOW7 = -1;
				string text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315760);
				_0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D = text.Split(',');
				if (_0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D == null && !_0023_003DzsJLHTamotTgh0lgmRkj04DiEMYz_0024())
				{
					return false;
				}
				_0023_003Dz7tx8zFpEH8hhU765Vw_003D_003D = _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D[0];
				_0023_003DzSLS9woq4F0gp = 1;
				goto IL_0171;
				IL_0163:
				_0023_003DzSLS9woq4F0gp += 4;
				goto IL_0171;
				IL_0171:
				if (_0023_003DzSLS9woq4F0gp < _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D.Length)
				{
					string text2 = _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D[_0023_003DzSLS9woq4F0gp];
					if (_0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D == null || text2.Equals(_0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D, StringComparison.Ordinal))
					{
						_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2 = new _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo();
						_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003Dz6RyEi5A_003D = _0023_003Dz7tx8zFpEH8hhU765Vw_003D_003D;
						_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003DzVV5q_0024H2_RdUVXPIL_0024V7q_OA_003D = text2;
						string text3 = _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D[_0023_003DzSLS9woq4F0gp + 1];
						int num2 = text3.IndexOf('|');
						if (num2 >= 0)
						{
							string text4 = text3.Substring(0, num2);
							text3 = text3.Substring(num2 + 1);
							_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003DzINsdZnSdGwqzgWMmCtbLxzvQV03Q = text4.IndexOf('a') != -1;
							_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003DzLioTw_00245sMTZHqh0tZgSPNm1b0Z99 = text4.IndexOf('b') != -1;
							_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003DzcaI6hkeDtmYHweBptkaGRsv63Krg = text4.IndexOf('c') != -1;
							_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003Dz2Kc_phXB4YbzHvY20DZ6LQjjqHCL = text4.IndexOf('f') != -1;
						}
						_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv = text3;
						_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2._0023_003Dz_0024IhMQuEmeNhkKEarutLbvf8vph2_0024 = _0023_003DzAMUZ_eOwlKsYMDcm0w_003D_003D[_0023_003DzSLS9woq4F0gp + 2];
						_0023_003Dz1ia6zb9jvQhU = _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo2;
						_0023_003DzwdenRi7jLOW7 = 1;
						return true;
					}
					goto IL_0163;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zGUKktgk=
				return this._0023_003DzGUKktgk_003D();
			}

			[DebuggerHidden]
			private _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003DzT_O2KYdWaHu4qKmtJ4otZ6mUpqf8z7yPHg5HtA2mf4XwEZOMX7Gvd9_1JDcwfrrxCT8qwXzqm3VHs_0024YGivcNYXN1F4hq()
			{
				return _0023_003Dz1ia6zb9jvQhU;
			}

			_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo IEnumerator<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo>.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zT_O2KYdWaHu4qKmtJ4otZ6mUpqf8z7yPHg5HtA2mf4XwEZOMX7Gvd9_1JDcwfrrxCT8qwXzqm3VHs$YGivcNYXN1F4hq
				return this._0023_003DzT_O2KYdWaHu4qKmtJ4otZ6mUpqf8z7yPHg5HtA2mf4XwEZOMX7Gvd9_1JDcwfrrxCT8qwXzqm3VHs_0024YGivcNYXN1F4hq();
			}

			[DebuggerHidden]
			private void _0023_003DzAcq2IeWc2pQh0wbSYw_003D_003D()
			{
				throw new NotSupportedException();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zAcq2IeWc2pQh0wbSYw==
				this._0023_003DzAcq2IeWc2pQh0wbSYw_003D_003D();
			}

			[DebuggerHidden]
			private object _0023_003Dzi9BftOhdlbt7GDOegbhw9Bo_003D()
			{
				return _0023_003Dz1ia6zb9jvQhU;
			}

			object IEnumerator.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zi9BftOhdlbt7GDOegbhw9Bo=
				return this._0023_003Dzi9BftOhdlbt7GDOegbhw9Bo_003D();
			}

			[DebuggerHidden]
			private IEnumerator<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo> _0023_003DzHYyP96h5yKAzPs3tpigm2T7kUU_R6_0024tRiAA5yZhX1wSyp0EF01u5bx7V30qJGuIFI1dqNX84TDEqZ3m7SRttCOTTiNCV()
			{
				_0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D2;
				if (_0023_003DzwdenRi7jLOW7 == -2 && _0023_003Dz3cfb3P0AOYvXFR8B_g_003D_003D == Thread.CurrentThread.ManagedThreadId)
				{
					_0023_003DzwdenRi7jLOW7 = 0;
					_0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D2 = this;
				}
				else
				{
					_0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D2 = new _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D(0);
				}
				_0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D2._0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D = _0023_003Dzl3k1qyFrrxANLXfg_0024A_003D_003D;
				return _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D2;
			}

			IEnumerator<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo> IEnumerable<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zHYyP96h5yKAzPs3tpigm2T7kUU_R6$tRiAA5yZhX1wSyp0EF01u5bx7V30qJGuIFI1dqNX84TDEqZ3m7SRttCOTTiNCV
				return this._0023_003DzHYyP96h5yKAzPs3tpigm2T7kUU_R6_0024tRiAA5yZhX1wSyp0EF01u5bx7V30qJGuIFI1dqNX84TDEqZ3m7SRttCOTTiNCV();
			}

			[DebuggerHidden]
			private IEnumerator _0023_003Dz56mciETyffkkCD9Z65snV_0024E_003D()
			{
				return _0023_003DzHYyP96h5yKAzPs3tpigm2T7kUU_R6_0024tRiAA5yZhX1wSyp0EF01u5bx7V30qJGuIFI1dqNX84TDEqZ3m7SRttCOTTiNCV();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=z56mciETyffkkCD9Z65snV$E=
				return this._0023_003Dz56mciETyffkkCD9Z65snV_0024E_003D();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IEnumerable<_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo> _0023_003DzIdnSB5VqEjeqfye7raY13gW4o52s(string _0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D)
		{
			return new _0023_003Dzj6YIRpuhSGtXI0pTagyY2i4_003D(-2)
			{
				_0023_003Dzl3k1qyFrrxANLXfg_0024A_003D_003D = _0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D
			};
		}

		internal static byte[] _0023_003Dza6iTZaOfMp9xQzJcvsTPi3hSriwu(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv);
			if (manifestResourceStream == null)
			{
				return null;
			}
			int num = (int)manifestResourceStream.Length;
			byte[] array = new byte[num];
			manifestResourceStream.Read(array, 0, num);
			manifestResourceStream.Dispose();
			if (_0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003DzINsdZnSdGwqzgWMmCtbLxzvQV03Q)
			{
				array = _0023_003DzeIMHdMI_MhrTHGiUPXkiHKYDGBvF(array);
			}
			if (_0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003DzLioTw_00245sMTZHqh0tZgSPNm1b0Z99)
			{
				array = _0023_003Dzvv_NWAcTivxIYkleU3EkUH8aKN_0024R(array);
			}
			return array;
		}

		internal static string _0023_003DzLaIH3fuzKq575hU6VQ_jltblQee7(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg, bool _0023_003DzZrF8jtxvrBiilM4qlQtUUX6a01Wn, byte[] _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024)
		{
			string path = (_0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003Dz2Kc_phXB4YbzHvY20DZ6LQjjqHCL ? _0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv : _0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003Dz6RyEi5A_003D);
			string text = Path.Combine(Path.GetTempPath(), path);
			try
			{
				Directory.CreateDirectory(text);
			}
			catch
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				text = Path.Combine(text, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317278));
				text = Path.Combine(text, path);
				Directory.CreateDirectory(text);
				if (text == null)
				{
					throw;
				}
			}
			string text2 = Path.Combine(text, _0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg._0023_003DzHZqXBB_00244Q_0024iBkHCdw8FdpNeX3tdg());
			_0023_003Dzh8SK4yI_003D _0023_003Dzh8SK4yI_003D2 = new _0023_003Dzh8SK4yI_003D(text2 + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317249));
			_0023_003Dzh8SK4yI_003D2._0023_003Dzkq42Q9Q_003D();
			try
			{
				if (!File.Exists(text2))
				{
					if (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024 == null)
					{
						_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024 = _0023_003Dza6iTZaOfMp9xQzJcvsTPi3hSriwu(_0023_003DzP0i7eYdAo2KYy3I4QjDWgc_2A_0024vg);
					}
					File.WriteAllBytes(text2, _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024);
					if (_0023_003DzZrF8jtxvrBiilM4qlQtUUX6a01Wn)
					{
						try
						{
							_0023_003DzYYDuOlIBFXKoaHaRrvH_MIYFh4n3(text2, null, 4);
							_0023_003DzYYDuOlIBFXKoaHaRrvH_MIYFh4n3(text, null, 4);
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				_0023_003Dzh8SK4yI_003D2._0023_003DzBQZQ_0024yw_003D();
			}
			return text2;
		}

		internal static void _0023_003DzlaXWCfV27kXkJw_0024l17W39EMR7hZq(string _0023_003DzazXz6E3OrhHep6OsPS7nGHWrE8Af, bool _0023_003DzmbYVUpOCaewXqXO9zhHrV3yzKBmT)
		{
			bool flag = false;
			try
			{
				File.Delete(_0023_003DzazXz6E3OrhHep6OsPS7nGHWrE8Af);
				flag = true;
			}
			catch
			{
			}
			string directoryName = Path.GetDirectoryName(_0023_003DzazXz6E3OrhHep6OsPS7nGHWrE8Af);
			bool flag2 = false;
			try
			{
				Directory.Delete(directoryName);
				flag = true;
			}
			catch
			{
			}
			if (!_0023_003DzmbYVUpOCaewXqXO9zhHrV3yzKBmT)
			{
				return;
			}
			if (!flag)
			{
				try
				{
					_0023_003DzYYDuOlIBFXKoaHaRrvH_MIYFh4n3(_0023_003DzazXz6E3OrhHep6OsPS7nGHWrE8Af, null, 4);
				}
				catch
				{
				}
			}
			if (!flag2)
			{
				try
				{
					_0023_003DzYYDuOlIBFXKoaHaRrvH_MIYFh4n3(directoryName, null, 4);
				}
				catch
				{
				}
			}
		}
	}

	private static class _0023_003Dzw_DSwYT5xxnug4uqMlEbwifOALBh
	{
		internal static readonly Dictionary<string, Assembly> _0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D = new Dictionary<string, Assembly>(StringComparer.Ordinal);
	}

	private static int _0023_003DzXB2fFzSMmazN_k_0024TAVcb0N7Hz9aA;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzsJLHTamotTgh0lgmRkj04DiEMYz_0024()
	{
		if (!_0023_003Dz_0024D8PscdO0BQsOmJ3ypHSk_Ro2MG4())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003Dz_0024D8PscdO0BQsOmJ3ypHSk_Ro2MG4()
	{
		StackTrace stackTrace = new StackTrace();
		Type type = (stackTrace.GetFrame(3)?.GetMethod())?.DeclaringType;
		if ((object)type == typeof(RuntimeMethodHandle))
		{
			return false;
		}
		if ((object)type == null)
		{
			return false;
		}
		if ((object)type.Assembly != typeof(_0023_003DzfjT7Eit3rFpkIqO_0024WhOaMOr8PS8G).Assembly)
		{
			return false;
		}
		return true;
	}

	internal static Assembly _0023_003DzCR5Jlyc_003D(string _0023_003DzjgvhseYsuprRAUkmSkQmGBZQhv3L)
	{
		return _0023_003DzyhXTevhTPSgFuWrWZTxzXczBcMHg(_0023_003DzjgvhseYsuprRAUkmSkQmGBZQhv3L);
	}

	private static Assembly _0023_003DzwSKke6scIoURjlklr67_0024CSet2mFX(object _0023_003DzUNNLWvM_003D, ResolveEventArgs _0023_003DzJeoE3Tk_003D)
	{
		return _0023_003DzyhXTevhTPSgFuWrWZTxzXczBcMHg(_0023_003DzJeoE3Tk_003D.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzyhXTevhTPSgFuWrWZTxzXczBcMHg(string _0023_003DzjgvhseYsuprRAUkmSkQmGBZQhv3L)
	{
		_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2 = new _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg(_0023_003DzjgvhseYsuprRAUkmSkQmGBZQhv3L.ToUpperInvariant());
		_0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo = null;
		bool flag = false;
		int num = 0;
		if (!_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzhD4q2JaSeWD1SbYheNmNh1KGquX3 || _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe != null)
		{
			foreach (_0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo item in _0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzIdnSB5VqEjeqfye7raY13gW4o52s(null))
			{
				if (!item._0023_003DzyNQMuWREENOFIQipMY08GYGHKEzJ().StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317109), StringComparison.Ordinal))
				{
					continue;
				}
				_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3 = new _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg(item._0023_003DzyNQMuWREENOFIQipMY08GYGHKEzJ().Substring(5));
				if (_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3._0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi != _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzWky6L6BIq7sNJcRKIFbsRIs5BRFi || _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3._0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY != _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzRFBRu2aCWWWQCF_0024x2sjsBwuFk9OY || (_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzhD4q2JaSeWD1SbYheNmNh1KGquX3 && _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3._0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe != _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzVVip83TNtmxungxAqdkwU0Wep8oe))
				{
					continue;
				}
				if (_0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzVt95OwotLijCnA10daiPTy7gy5cF && _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3._0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg != _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg)
				{
					flag = true;
					if (num == 0)
					{
						num = _0023_003DzQ6NIhEd5UNyOjet4E02ACi0_003D();
					}
					if (num != 2 || _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg > _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg3._0023_003Dzx8bHmhO836sfU5d57BgIq23AKTQg)
					{
						continue;
					}
				}
				_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo = item;
				break;
			}
		}
		if (_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo == null && !flag)
		{
			string s = _0023_003Dz9NEFTM2JVivI4cx0815S3G4qiBfg2._0023_003DzyJSwnkk8Hnvi(_0023_003DzSsBE9g1_s4TpT4z1FLRqnSjBvsIK: false);
			string _0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			using IEnumerator<_0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo> enumerator2 = _0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzIdnSB5VqEjeqfye7raY13gW4o52s(_0023_003Dz3pujlTEKEIUwWD4qB87nBbY_003D).GetEnumerator();
			if (enumerator2.MoveNext())
			{
				_0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo current2 = enumerator2.Current;
				_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo = current2;
			}
		}
		if (_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo == null)
		{
			return null;
		}
		Dictionary<string, Assembly> _0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D = _0023_003Dzw_DSwYT5xxnug4uqMlEbwifOALBh._0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D;
		Assembly value;
		lock (_0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D)
		{
			if (!_0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D.TryGetValue(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo._0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv, out value))
			{
				byte[] array = _0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003Dza6iTZaOfMp9xQzJcvsTPi3hSriwu(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo);
				if (array == null)
				{
					return null;
				}
				bool flag2 = _0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo._0023_003DzcaI6hkeDtmYHweBptkaGRsv63Krg;
				if (!flag2)
				{
					try
					{
						value = Assembly.Load(array);
					}
					catch (FileLoadException)
					{
						flag2 = true;
					}
					catch (BadImageFormatException)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					try
					{
						string assemblyFile = _0023_003DznywnPIKWhAh_0024fRcKhM82BMQ_003D._0023_003DzLaIH3fuzKq575hU6VQ_jltblQee7(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo, _0023_003DzZrF8jtxvrBiilM4qlQtUUX6a01Wn: true, array);
						value = Assembly.LoadFrom(assemblyFile);
					}
					catch
					{
					}
				}
				_0023_003Dzd7qJavC8B8Fj2uveeuNo_0024Nc_003D.Add(_0023_003DzUhdonrEDV8UNwfvXUzOIRrbcoPSo._0023_003DzD0aX7PDjRusfPK0yW6YFaDtxzeUv, value);
			}
		}
		return value;
	}

	private static int _0023_003DzQ6NIhEd5UNyOjet4E02ACi0_003D()
	{
		int num = _0023_003DzXB2fFzSMmazN_k_0024TAVcb0N7Hz9aA;
		if (num == 0)
		{
			num = (_0023_003DzXB2fFzSMmazN_k_0024TAVcb0N7Hz9aA = (((object)Type.GetType(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317113)) == null) ? 1 : 2));
		}
		return num;
	}

	internal static void _0023_003Dznx1EMIs_003D()
	{
		AppDomain.CurrentDomain.AssemblyResolve += (object _0023_003DzUNNLWvM_003D, ResolveEventArgs _0023_003DzJeoE3Tk_003D) => _0023_003DzyhXTevhTPSgFuWrWZTxzXczBcMHg(_0023_003DzJeoE3Tk_003D.Name);
	}

	private static int _0023_003DzaBmFrJ3W4IivYXf8gGZo5iwXc_n9(byte[] _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024, int _0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr)
	{
		return _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr] | (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 1] << 24) | (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 2] << 8) | (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 3] << 16);
	}

	private static int _0023_003DzBh4_0024eTi0o4kX3POp5qw1NtPohcTX(byte[] _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024, int _0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr)
	{
		return (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr] << 8) | _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 1] | (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 2] << 16) | (_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[_0023_003DzF5kGlJRxwnY_4LCErV8GPj5mWhhr + 3] << 24);
	}

	private static byte[] _0023_003Dzvv_NWAcTivxIYkleU3EkUH8aKN_0024R(byte[] _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024)
	{
		int num = _0023_003DzaBmFrJ3W4IivYXf8gGZo5iwXc_n9(_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024, 0);
		if (num != -1686991929)
		{
			throw new Exception();
		}
		int num2 = _0023_003DzBh4_0024eTi0o4kX3POp5qw1NtPohcTX(_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024, 4);
		Stream stream = new MemoryStream(_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024, writable: false);
		stream.Position = 8L;
		stream = new DeflateStream(stream, CompressionMode.Decompress);
		BinaryReader binaryReader = new BinaryReader(stream);
		_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024 = binaryReader.ReadBytes(num2);
		binaryReader.Close();
		int num3 = _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024.Length;
		if (num3 != num2)
		{
			throw new Exception();
		}
		return _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] _0023_003DzeIMHdMI_MhrTHGiUPXkiHKYDGBvF(byte[] _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024)
	{
		string s = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317154);
		byte[] array = Convert.FromBase64String(s);
		_0023_003DzeUhoxGmGoknQy6UOkug_0024WwrsW776._0023_003Dznx1EMIs_003D(array);
		_0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT _0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT2 = new _0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT(array);
		int num = _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024.Length;
		byte b = 0;
		byte b2 = 121;
		byte[] array2 = new byte[8] { 148, 68, 208, 52, 241, 93, 195, 220 };
		for (int i = 0; i != num; i++)
		{
			if (b == 0)
			{
				b2 = _0023_003DzWkrq383yZOhd9kTT8laWk5poq_0024HT2._0023_003DzcCKlwUl9YCKF7PDDtedO528_003D();
			}
			b++;
			if (b == 32)
			{
				b = 0;
			}
			_0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024[i] ^= (byte)(b2 ^ array2[(i >> 2) & 3] ^ array2[b & 3]);
		}
		return _0023_003DzJFVP3ETpwnvmuVN5_RUjOyNhg9J_0024;
	}

	[DllImport("kernel32.dll", EntryPoint = "MoveFileEx")]
	private static extern bool _0023_003DzYYDuOlIBFXKoaHaRrvH_MIYFh4n3(string _0023_003DzQxBXVYqTjCLcmnrxg4Z8GUqMqq2n, string _0023_003DzYSH3h2Tnu_9n4YtQmzuAo5YSrMgG, int _0023_003DzK8RLFFB3GVlh2zOev13aFJU_003D);
}
