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

internal static class _0023_003DzlKA2LHz43UvxZCVdqwc8LqoqXCz9
{
	private struct _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup
	{
		public Version _0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj;

		public bool _0023_003Dz2DRk9uU21y54_0024_RFi8RvqFDUXve7;

		public string _0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb;

		public string _0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH;

		public bool _0023_003DzE2siU_00245UaIEzA51Hnj3aqYSFUa9x;

		public string _0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX;

		public bool _0023_003DzdfX_0024rS8ax7bCDya_0024HsYb1OvqCSAL;

		public _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup(string _0023_003DztrMkox2hE4ts_My3XBNJAn_0024P4Dop)
		{
			this = default(_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup);
			_0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj = new Version();
			_0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb = string.Empty;
			string[] array = _0023_003DztrMkox2hE4ts_My3XBNJAn_0024P4Dop.Split(',');
			foreach (string text in array)
			{
				string text2 = text.Trim();
				if (text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748164), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj = new Version(text2.Substring(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748164).Length));
					_0023_003Dz2DRk9uU21y54_0024_RFi8RvqFDUXve7 = true;
				}
				else if (text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748401), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH = text2.Substring(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748401).Length);
					if (_0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748386), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH = null;
					}
					_0023_003DzE2siU_00245UaIEzA51Hnj3aqYSFUa9x = true;
				}
				else if (text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748400), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX = text2.Substring(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748400).Length);
					if (_0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941266), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX = null;
					}
					_0023_003DzdfX_0024rS8ax7bCDya_0024HsYb1OvqCSAL = true;
				}
				else
				{
					_0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb = text2;
				}
			}
		}

		public string _0023_003DzMJxIBbzMj_kJ(bool _0023_003DzzONRnY81xsY1xFQTFWgfg0SjrzWe)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb);
			if (_0023_003DzzONRnY81xsY1xFQTFWgfg0SjrzWe)
			{
				stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748358)).Append(_0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj);
			}
			stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748341)).Append(_0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748328)).Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748310))
				.Append(_0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302694870));
			return stringBuilder.ToString();
		}
	}

	private static class _0023_003DzIGo3kMlW7_0024MHJz7ea2k3jD6Vrhkd
	{
		internal static readonly Dictionary<string, Assembly> _0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D = new Dictionary<string, Assembly>(StringComparer.Ordinal);
	}

	private static class _0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D
	{
		private struct _0023_003Dzh4hU_0024yo_003D
		{
			private readonly string _0023_003Dzr8EfuaY_003D;

			private FileStream _0023_003Dz109bWIpC_jci;

			public _0023_003Dzh4hU_0024yo_003D(string _0023_003Dzg5oC_Hs_003D)
			{
				this = default(_0023_003Dzh4hU_0024yo_003D);
				_0023_003Dzr8EfuaY_003D = _0023_003Dzg5oC_Hs_003D;
			}

			public bool _0023_003DzGm2TFPE_003D()
			{
				try
				{
					if (_0023_003Dz109bWIpC_jci != null)
					{
						return false;
					}
					_0023_003Dz109bWIpC_jci = new FileStream(_0023_003Dzr8EfuaY_003D, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128, FileOptions.DeleteOnClose);
				}
				catch
				{
					return false;
				}
				return true;
			}

			public void _0023_003DzjWsDxpk_003D()
			{
				Stopwatch stopwatch = null;
				int num = 25;
				int num2 = 250;
				while (!_0023_003DzGm2TFPE_003D())
				{
					if (stopwatch == null)
					{
						stopwatch = Stopwatch.StartNew();
					}
					else
					{
						if (stopwatch.Elapsed.TotalSeconds > 300.0)
						{
							throw new TimeoutException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748302), _0023_003Dzr8EfuaY_003D));
						}
						if (num < num2)
						{
							num = Math.Min(num * 2, num2);
						}
					}
					Thread.Sleep(num);
				}
			}

			public void _0023_003Dz0s3XAv0_003D()
			{
				if (_0023_003Dz109bWIpC_jci != null)
				{
					_0023_003Dz109bWIpC_jci.Dispose();
					_0023_003Dz109bWIpC_jci = null;
				}
			}
		}

		private sealed class _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D : IEnumerable<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024>, IEnumerable, IEnumerator<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024>, IDisposable, IEnumerator
		{
			private int _0023_003DzU7pGb3X7Zp4G;

			private _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003DzezVIuujSK1H9;

			private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

			private string _0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D;

			public string _0023_003Dzv1Peb2AtY7btwXYjIg_003D_003D;

			private string[] _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D;

			private string _0023_003Dz6ZM0pZCLd8orcYOwNg_003D_003D;

			private int _0023_003Dz9xraizeN7vwK;

			[DebuggerHidden]
			public _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D(int _0023_003DzU7pGb3X7Zp4G)
			{
				this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
				_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
			{
				_0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D = null;
				_0023_003Dz6ZM0pZCLd8orcYOwNg_003D_003D = null;
				_0023_003DzU7pGb3X7Zp4G = -2;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
				this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
			}

			private bool _0023_003DzgJGb6QU_003D()
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_0023_003DzU7pGb3X7Zp4G = -1;
					goto IL_0163;
				}
				_0023_003DzU7pGb3X7Zp4G = -1;
				string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302749019);
				_0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D = text.Split(',');
				if (_0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D == null && !_0023_003DzhLBMr1WWDFCtouO_0024MEmY7XdjD_0024Nt())
				{
					return false;
				}
				_0023_003Dz6ZM0pZCLd8orcYOwNg_003D_003D = _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D[0];
				_0023_003Dz9xraizeN7vwK = 1;
				goto IL_0171;
				IL_0163:
				_0023_003Dz9xraizeN7vwK += 4;
				goto IL_0171;
				IL_0171:
				if (_0023_003Dz9xraizeN7vwK < _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D.Length)
				{
					string text2 = _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D[_0023_003Dz9xraizeN7vwK];
					if (_0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D == null || text2.Equals(_0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D, StringComparison.Ordinal))
					{
						_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242 = new _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024();
						_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003Dzut_0024Dxi4_003D = _0023_003Dz6ZM0pZCLd8orcYOwNg_003D_003D;
						_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzU_T25fSkjGmXl8nV5WnrGp4_003D = text2;
						string text3 = _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D[_0023_003Dz9xraizeN7vwK + 1];
						int num2 = text3.IndexOf('|');
						if (num2 >= 0)
						{
							string text4 = text3.Substring(0, num2);
							text3 = text3.Substring(num2 + 1);
							_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzK_0024D76cdInBJ_0024R40JzSiwx8FbdIee = text4.IndexOf('a') != -1;
							_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzGMTaMYVVK5ZAN3h1O_0024n4lUwkqUDP = text4.IndexOf('b') != -1;
							_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzFTXKA_0024_0024D8xGDXhWbYTnTSST9xx9B = text4.IndexOf('c') != -1;
							_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzYXdAEUH7Jw7_gidHIQWLt_mR_0024NGN = text4.IndexOf('f') != -1;
						}
						_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6 = text3;
						_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242._0023_003DzR9ipmGaQ5pU6TdiuHUONVT2Nwk6B = _0023_003DzXi_0024DANpoQ7K15nvC1w_003D_003D[_0023_003Dz9xraizeN7vwK + 2];
						_0023_003DzezVIuujSK1H9 = _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_00242;
						_0023_003DzU7pGb3X7Zp4G = 1;
						return true;
					}
					goto IL_0163;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zgJGb6QU=
				return this._0023_003DzgJGb6QU_003D();
			}

			[DebuggerHidden]
			private _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003DzSrMVwqTtkaRASocp_jeFYZ8dv6ZqDMk3kZYA8ozpdl_0024lNbMJxr0_bSsA_ZDIJhaYJQV0UUaW7zxlkgRsYixMvYkAJEHJ()
			{
				return _0023_003DzezVIuujSK1H9;
			}

			_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 IEnumerator<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024>.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zSrMVwqTtkaRASocp_jeFYZ8dv6ZqDMk3kZYA8ozpdl$lNbMJxr0_bSsA_ZDIJhaYJQV0UUaW7zxlkgRsYixMvYkAJEHJ
				return this._0023_003DzSrMVwqTtkaRASocp_jeFYZ8dv6ZqDMk3kZYA8ozpdl_0024lNbMJxr0_bSsA_ZDIJhaYJQV0UUaW7zxlkgRsYixMvYkAJEHJ();
			}

			[DebuggerHidden]
			private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
			{
				throw new NotSupportedException();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
				this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
			}

			[DebuggerHidden]
			private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
			{
				return _0023_003DzezVIuujSK1H9;
			}

			object IEnumerator.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
				return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
			}

			[DebuggerHidden]
			private IEnumerator<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024> _0023_003DzO3ajmu6N1rw0eUJ9j_0024q_00245pocYHpwdnGTDohkK9rlCk6DtCfxzssPsKs4gtwfjAmgMnyaB87_ll1EmnjQl8si7_0024By_0024r1Y()
			{
				_0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D2;
				if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Thread.CurrentThread.ManagedThreadId)
				{
					_0023_003DzU7pGb3X7Zp4G = 0;
					_0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D2 = this;
				}
				else
				{
					_0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D2 = new _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D(0);
				}
				_0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D2._0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D = _0023_003Dzv1Peb2AtY7btwXYjIg_003D_003D;
				return _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D2;
			}

			IEnumerator<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024> IEnumerable<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zO3ajmu6N1rw0eUJ9j$q$5pocYHpwdnGTDohkK9rlCk6DtCfxzssPsKs4gtwfjAmgMnyaB87_ll1EmnjQl8si7$By$r1Y
				return this._0023_003DzO3ajmu6N1rw0eUJ9j_0024q_00245pocYHpwdnGTDohkK9rlCk6DtCfxzssPsKs4gtwfjAmgMnyaB87_ll1EmnjQl8si7_0024By_0024r1Y();
			}

			[DebuggerHidden]
			private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
			{
				return _0023_003DzO3ajmu6N1rw0eUJ9j_0024q_00245pocYHpwdnGTDohkK9rlCk6DtCfxzssPsKs4gtwfjAmgMnyaB87_ll1EmnjQl8si7_0024By_0024r1Y();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
				return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
			}
		}

		internal sealed class _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024
		{
			public string _0023_003DzU_T25fSkjGmXl8nV5WnrGp4_003D;

			private string _0023_003DzFtBvYv6po9mNleMBYKDvnPsd9TqU;

			public string _0023_003Dzut_0024Dxi4_003D;

			public string _0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6;

			public bool _0023_003DzK_0024D76cdInBJ_0024R40JzSiwx8FbdIee;

			public bool _0023_003DzGMTaMYVVK5ZAN3h1O_0024n4lUwkqUDP;

			public bool _0023_003DzFTXKA_0024_0024D8xGDXhWbYTnTSST9xx9B;

			public bool _0023_003DzdgtrhN_0024Hm3zCcyGydbf9Y8LjYf_W;

			public bool _0023_003DzZ9uhMTqmxtOaQVXLQvJXWK_0024ZhO6B;

			public bool _0023_003DzYXdAEUH7Jw7_gidHIQWLt_mR_0024NGN;

			public string _0023_003DzR9ipmGaQ5pU6TdiuHUONVT2Nwk6B;

			private string _0023_003DzlRBe97sTg9qYttA3YX4W7A82HeRi;

			public string _0023_003DzKCQGmHptr38ZGzkHInEe_0024LJhE_0024vn()
			{
				if (_0023_003DzFtBvYv6po9mNleMBYKDvnPsd9TqU == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003DzU_T25fSkjGmXl8nV5WnrGp4_003D);
					_0023_003DzFtBvYv6po9mNleMBYKDvnPsd9TqU = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003DzFtBvYv6po9mNleMBYKDvnPsd9TqU;
			}

			public string _0023_003DzdBerDW6Jpwj9Eq7r3GsprXqg8Dm5()
			{
				if (_0023_003DzlRBe97sTg9qYttA3YX4W7A82HeRi == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003DzR9ipmGaQ5pU6TdiuHUONVT2Nwk6B);
					_0023_003DzlRBe97sTg9qYttA3YX4W7A82HeRi = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003DzlRBe97sTg9qYttA3YX4W7A82HeRi;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IEnumerable<_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024> _0023_003Dz4FiJ5RuaXnPpUFwPZUpvFOwte98t(string _0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D)
		{
			return new _0023_003DzmsOHod0lW9GDGiJj4vJnUUo_003D(-2)
			{
				_0023_003Dzv1Peb2AtY7btwXYjIg_003D_003D = _0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D
			};
		}

		internal static byte[] _0023_003DzifWSJDIS6eGB0f3ZQwW107K31ojE(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6);
			if (manifestResourceStream == null)
			{
				return null;
			}
			int num = (int)manifestResourceStream.Length;
			byte[] array = new byte[num];
			manifestResourceStream.Read(array, 0, num);
			manifestResourceStream.Dispose();
			if (_0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzK_0024D76cdInBJ_0024R40JzSiwx8FbdIee)
			{
				array = _0023_003Dz_0024zITHnQj3tC8xiM0VJuMnULgSM_5(array);
			}
			if (_0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzGMTaMYVVK5ZAN3h1O_0024n4lUwkqUDP)
			{
				array = _0023_003DzEX345WVjeauTYn3l_gfcNPqlYH_L(array);
			}
			return array;
		}

		internal static string _0023_003DzInU4Lb52VwkH_00248DIea4u5ZahPjr8(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY, bool _0023_003Dz1C0ED3dsZw4Y2Fc6alFXbGnlPX27, byte[] _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L)
		{
			string path = (_0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzYXdAEUH7Jw7_gidHIQWLt_mR_0024NGN ? _0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6 : _0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003Dzut_0024Dxi4_003D);
			string text = Path.Combine(Path.GetTempPath(), path);
			try
			{
				Directory.CreateDirectory(text);
			}
			catch
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				text = Path.Combine(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748834));
				text = Path.Combine(text, path);
				Directory.CreateDirectory(text);
				if (text == null)
				{
					throw;
				}
			}
			string text2 = Path.Combine(text, _0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY._0023_003DzdBerDW6Jpwj9Eq7r3GsprXqg8Dm5());
			_0023_003Dzh4hU_0024yo_003D _0023_003Dzh4hU_0024yo_003D2 = new _0023_003Dzh4hU_0024yo_003D(text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748845));
			_0023_003Dzh4hU_0024yo_003D2._0023_003DzjWsDxpk_003D();
			try
			{
				if (!File.Exists(text2))
				{
					if (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L == null)
					{
						_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L = _0023_003DzifWSJDIS6eGB0f3ZQwW107K31ojE(_0023_003Dzh6KXjRf__0024Qeke_0024EPHTo61YqzMbfY);
					}
					File.WriteAllBytes(text2, _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L);
					if (_0023_003Dz1C0ED3dsZw4Y2Fc6alFXbGnlPX27)
					{
						try
						{
							_0023_003DzGQSJiVr8GDrk394bmMtuT0NPcG7L(text2, null, 4);
							_0023_003DzGQSJiVr8GDrk394bmMtuT0NPcG7L(text, null, 4);
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				_0023_003Dzh4hU_0024yo_003D2._0023_003Dz0s3XAv0_003D();
			}
			return text2;
		}

		internal static void _0023_003Dz_WYq_6xHsoahJ7MQMFMKDUYJhC8K(string _0023_003DzfMfDOZ8JtD3_0024bCYpTfF5nTshtzbu, bool _0023_003DzLHZ84Jgez_0024mg1YIaz0BWW9B4Y_00248g)
		{
			bool flag = false;
			try
			{
				File.Delete(_0023_003DzfMfDOZ8JtD3_0024bCYpTfF5nTshtzbu);
				flag = true;
			}
			catch
			{
			}
			string directoryName = Path.GetDirectoryName(_0023_003DzfMfDOZ8JtD3_0024bCYpTfF5nTshtzbu);
			bool flag2 = false;
			try
			{
				Directory.Delete(directoryName);
				flag = true;
			}
			catch
			{
			}
			if (!_0023_003DzLHZ84Jgez_0024mg1YIaz0BWW9B4Y_00248g)
			{
				return;
			}
			if (!flag)
			{
				try
				{
					_0023_003DzGQSJiVr8GDrk394bmMtuT0NPcG7L(_0023_003DzfMfDOZ8JtD3_0024bCYpTfF5nTshtzbu, null, 4);
				}
				catch
				{
				}
			}
			if (!flag2)
			{
				try
				{
					_0023_003DzGQSJiVr8GDrk394bmMtuT0NPcG7L(directoryName, null, 4);
				}
				catch
				{
				}
			}
		}
	}

	private sealed class _0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi
	{
		private byte[] _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u = new byte[256];

		private int _0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc;

		private int _0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ;

		public _0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi(byte[] _0023_003DzEjqsTdZwnSNY_0024JDw5hjP030_003D)
		{
			int num = _0023_003DzEjqsTdZwnSNY_0024JDw5hjP030_003D.Length;
			for (_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc = 0; _0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc < 256; _0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc++)
			{
				_0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc] = (byte)_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc;
			}
			for (_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc = (_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ = 0); _0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc < 256; _0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc++)
			{
				_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ = (_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ + _0023_003DzEjqsTdZwnSNY_0024JDw5hjP030_003D[_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc % num] + _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc]) & 0xFF;
				_0023_003DznD12vXppwsrLrjVjXSJQNborE83J(_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc, _0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ);
			}
		}

		private void _0023_003DznD12vXppwsrLrjVjXSJQNborE83J(int _0023_003Dzrmkf8RBhg4GQQyX4baS5Ermg1pI5, int _0023_003DzNg43Ysl_ZWQtOxRWijg6WEYLon4v)
		{
			byte b = _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dzrmkf8RBhg4GQQyX4baS5Ermg1pI5];
			_0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dzrmkf8RBhg4GQQyX4baS5Ermg1pI5] = _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003DzNg43Ysl_ZWQtOxRWijg6WEYLon4v];
			_0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003DzNg43Ysl_ZWQtOxRWijg6WEYLon4v] = b;
		}

		public byte _0023_003DzkAnN_0024DhwODa_bSXez13Dhfw_003D()
		{
			_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc = (_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc + 1) & 0xFF;
			_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ = (_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ + _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc]) & 0xFF;
			_0023_003DznD12vXppwsrLrjVjXSJQNborE83J(_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc, _0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ);
			return _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[(byte)(_0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dz7e8Yrcx9zCTA3G2UUOXbnkbMqvbc] + _0023_003Dzm0eqwhGgaygPtH8oM41fHMyXnD_u[_0023_003Dz3N9v884jwQGD3mC6XKD0j05lKtgJ])];
		}
	}

	private static int _0023_003DzlcXG2PmvyPOmGk84ywwj1VFKWP2B;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzhLBMr1WWDFCtouO_0024MEmY7XdjD_0024Nt()
	{
		if (!_0023_003DzXsy2hC7YaXCpqK0T0Ng1nL4ZJ1Q_0024())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzXsy2hC7YaXCpqK0T0Ng1nL4ZJ1Q_0024()
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
		if ((object)type.Assembly != typeof(_0023_003DzlKA2LHz43UvxZCVdqwc8LqoqXCz9).Assembly)
		{
			return false;
		}
		return true;
	}

	internal static Assembly _0023_003DzjbqS1qE_003D(string _0023_003Dz5DzLtMaZWH_9_0024jxBg5hkVMRycVn8)
	{
		return _0023_003DzpM8prqzB89AoixWJ5TXpHq_VPDDk(_0023_003Dz5DzLtMaZWH_9_0024jxBg5hkVMRycVn8);
	}

	private static Assembly _0023_003Dzeqv9a5oyHhyzKrYQH0Svj1OaqckC(object _0023_003Dz9VjL5i0_003D, ResolveEventArgs _0023_003Dz53Cncpw_003D)
	{
		return _0023_003DzpM8prqzB89AoixWJ5TXpHq_VPDDk(_0023_003Dz53Cncpw_003D.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzpM8prqzB89AoixWJ5TXpHq_VPDDk(string _0023_003Dz5DzLtMaZWH_9_0024jxBg5hkVMRycVn8)
	{
		_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2 = new _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup(_0023_003Dz5DzLtMaZWH_9_0024jxBg5hkVMRycVn8.ToUpperInvariant());
		_0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 = null;
		bool flag = false;
		int num = 0;
		if (!_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DzdfX_0024rS8ax7bCDya_0024HsYb1OvqCSAL || _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX != null)
		{
			foreach (_0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 item in _0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dz4FiJ5RuaXnPpUFwPZUpvFOwte98t(null))
			{
				if (!item._0023_003DzKCQGmHptr38ZGzkHInEe_0024LJhE_0024vn().StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748825), StringComparison.Ordinal))
				{
					continue;
				}
				_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3 = new _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup(item._0023_003DzKCQGmHptr38ZGzkHInEe_0024LJhE_0024vn().Substring(5));
				if (_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3._0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb != _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003Dz_0024B3xU86csBRwJIdSRExYJjv_0024gRfb || _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3._0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH != _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003Dzp0JO8CJquQlTHeuWKFUGOAnVFHmH || (_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DzdfX_0024rS8ax7bCDya_0024HsYb1OvqCSAL && _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3._0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX != _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DznT1AEA5ZGgF9TmtYvu0L1AhwKnhX))
				{
					continue;
				}
				if (_0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003Dz2DRk9uU21y54_0024_RFi8RvqFDUXve7 && _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3._0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj != _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj)
				{
					flag = true;
					if (num == 0)
					{
						num = _0023_003Dzzmtai2CH46ic05YmZLRvNM0_003D();
					}
					if (num != 2 || _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj > _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup3._0023_003DzRKnl_swifAV5md4cv1eQo2VvutJj)
					{
						continue;
					}
				}
				_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 = item;
				break;
			}
		}
		if (_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 == null && !flag)
		{
			string s = _0023_003DzEo1MpEvVrF9tNHEHVWtC_0024b9cVFup2._0023_003DzMJxIBbzMj_kJ(_0023_003DzzONRnY81xsY1xFQTFWgfg0SjrzWe: false);
			string _0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			using IEnumerator<_0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024> enumerator2 = _0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dz4FiJ5RuaXnPpUFwPZUpvFOwte98t(_0023_003Dzesz07J94hIOv_VqSqqmx2YE_003D).GetEnumerator();
			if (enumerator2.MoveNext())
			{
				_0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 current2 = enumerator2.Current;
				_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 = current2;
			}
		}
		if (_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024 == null)
		{
			return null;
		}
		Dictionary<string, Assembly> _0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D = _0023_003DzIGo3kMlW7_0024MHJz7ea2k3jD6Vrhkd._0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D;
		Assembly value;
		lock (_0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D)
		{
			if (!_0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D.TryGetValue(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024._0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6, out value))
			{
				byte[] array = _0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003DzifWSJDIS6eGB0f3ZQwW107K31ojE(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024);
				if (array == null)
				{
					return null;
				}
				bool flag2 = _0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024._0023_003DzFTXKA_0024_0024D8xGDXhWbYTnTSST9xx9B;
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
						string assemblyFile = _0023_003DzONK_0024zIswwu7HV2_xQ1D0ypM_003D._0023_003DzInU4Lb52VwkH_00248DIea4u5ZahPjr8(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024, _0023_003Dz1C0ED3dsZw4Y2Fc6alFXbGnlPX27: true, array);
						value = Assembly.LoadFrom(assemblyFile);
					}
					catch
					{
					}
				}
				_0023_003DzAXUMWjJ_00241g7trRx3kEyqD2U_003D.Add(_0023_003Dzz1v7SQ4MOJYS2hrqcO3pWOLEZvj_0024._0023_003DzBD6fghUICa4e8W_0024aIjEz7mx79AT6, value);
			}
		}
		return value;
	}

	private static int _0023_003Dzzmtai2CH46ic05YmZLRvNM0_003D()
	{
		int num = _0023_003DzlcXG2PmvyPOmGk84ywwj1VFKWP2B;
		if (num == 0)
		{
			num = (_0023_003DzlcXG2PmvyPOmGk84ywwj1VFKWP2B = (((object)Type.GetType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748805)) == null) ? 1 : 2));
		}
		return num;
	}

	internal static void _0023_003DzE8QrneA_003D()
	{
		AppDomain.CurrentDomain.AssemblyResolve += _0023_003Dzeqv9a5oyHhyzKrYQH0Svj1OaqckC;
	}

	private static int _0023_003DzdT3xJvh4k5_UaANrgfHHw4KdMTuw(byte[] _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L, int _0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8)
	{
		return _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8] | (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 1] << 24) | (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 2] << 8) | (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 3] << 16);
	}

	private static int _0023_003Dzeei_K8HKXm_0024fot9ZKUmbyRtDf9O1(byte[] _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L, int _0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8)
	{
		return (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8] << 8) | _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 1] | (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 2] << 16) | (_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[_0023_003DzMmVQxgFDvMt_00243b8zCZTspc_JyWj8 + 3] << 24);
	}

	private static byte[] _0023_003DzEX345WVjeauTYn3l_gfcNPqlYH_L(byte[] _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L)
	{
		int num = _0023_003DzdT3xJvh4k5_UaANrgfHHw4KdMTuw(_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L, 0);
		if (num != -1686991929)
		{
			throw new Exception();
		}
		int num2 = _0023_003Dzeei_K8HKXm_0024fot9ZKUmbyRtDf9O1(_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L, 4);
		Stream stream = new MemoryStream(_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L, writable: false);
		stream.Position = 8L;
		stream = new DeflateStream(stream, CompressionMode.Decompress);
		BinaryReader binaryReader = new BinaryReader(stream);
		_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L = binaryReader.ReadBytes(num2);
		binaryReader.Close();
		int num3 = _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L.Length;
		if (num3 != num2)
		{
			throw new Exception();
		}
		return _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] _0023_003Dz_0024zITHnQj3tC8xiM0VJuMnULgSM_5(byte[] _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L)
	{
		string s = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302749518);
		byte[] array = Convert.FromBase64String(s);
		_0023_003DzYCKXTZQlebGSmVlt0a2mzopploz1._0023_003DzE8QrneA_003D(array);
		_0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi _0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi2 = new _0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi(array);
		int num = _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L.Length;
		byte b = 0;
		byte b2 = 121;
		byte[] array2 = new byte[8] { 148, 68, 208, 52, 241, 93, 195, 220 };
		for (int i = 0; i != num; i++)
		{
			if (b == 0)
			{
				b2 = _0023_003DzZr0ocBavrh2uGNYTb7ofomr_00240XKi2._0023_003DzkAnN_0024DhwODa_bSXez13Dhfw_003D();
			}
			b++;
			if (b == 32)
			{
				b = 0;
			}
			_0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L[i] ^= (byte)(b2 ^ array2[(i >> 2) & 3] ^ array2[b & 3]);
		}
		return _0023_003DzQZeCHPUBPef1R6y_C93F4hWWJC3L;
	}

	[DllImport("kernel32.dll", EntryPoint = "MoveFileEx")]
	private static extern bool _0023_003DzGQSJiVr8GDrk394bmMtuT0NPcG7L(string _0023_003DzJJTWXUQ24xvkDYisTDTZ8Vuz3QF_0024, string _0023_003DzeoU1L8dM3Yy2_oHKrS6TdJYuoVWi, int _0023_003Dz_r3AYv3DgqmzcFHJV_4oqDk_003D);
}
