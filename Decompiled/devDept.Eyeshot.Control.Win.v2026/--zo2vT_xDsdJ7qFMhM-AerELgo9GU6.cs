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

internal static class _0023_003Dzo2vT_xDsdJ7qFMhM_0024AerELgo9GU6
{
	private sealed class _0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx
	{
		private byte[] _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc = new byte[256];

		private int _0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3;

		private int _0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273;

		public _0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx(byte[] _0023_003DzH_00249tccXtoJIoKG4aiRpMxpo_003D)
		{
			int num = _0023_003DzH_00249tccXtoJIoKG4aiRpMxpo_003D.Length;
			for (_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 = 0; _0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 < 256; _0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3++)
			{
				_0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3] = (byte)_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3;
			}
			for (_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 = (_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273 = 0); _0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 < 256; _0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3++)
			{
				_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273 = (_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273 + _0023_003DzH_00249tccXtoJIoKG4aiRpMxpo_003D[_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 % num] + _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3]) & 0xFF;
				_0023_003Dz5Fl_0024m1eqoGzIEFi8EU9tHGcnyH_00246(_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3, _0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273);
			}
		}

		private void _0023_003Dz5Fl_0024m1eqoGzIEFi8EU9tHGcnyH_00246(int _0023_003Dz2sb7sukYM31ZvOMy4QgSDxORcQ_4, int _0023_003DzEgnFK4AdeNC6dH504p2XUFX92WWF)
		{
			byte b = _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003Dz2sb7sukYM31ZvOMy4QgSDxORcQ_4];
			_0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003Dz2sb7sukYM31ZvOMy4QgSDxORcQ_4] = _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzEgnFK4AdeNC6dH504p2XUFX92WWF];
			_0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzEgnFK4AdeNC6dH504p2XUFX92WWF] = b;
		}

		public byte _0023_003Dzee0RmGcZndRd0c_0024hYiT23Xs_003D()
		{
			_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 = (_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3 + 1) & 0xFF;
			_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273 = (_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273 + _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3]) & 0xFF;
			_0023_003Dz5Fl_0024m1eqoGzIEFi8EU9tHGcnyH_00246(_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3, _0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273);
			return _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[(byte)(_0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzSkRxv3N93h5CQiIl2ubOsxY1zFT3] + _0023_003DzIlosqMtrLnfuvbaJJbiNb5zjfvKc[_0023_003DzM5t3w2CN6p_guHNtU5q5QIwPW273])];
		}
	}

	private static class _0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D
	{
		private sealed class _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D : IEnumerable<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro>, IEnumerable, IEnumerator<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro>, IDisposable, IEnumerator
		{
			private int _0023_003Dz0FVSO5LFyxyq;

			private _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003Dzn0gRlKh1Xs_0024z;

			private int _0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D;

			private string _0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D;

			public string _0023_003DzfKi3ue3fi8u39ADrVw_003D_003D;

			private string[] _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D;

			private string _0023_003DzL6833cF254dsc4iU4w_003D_003D;

			private int _0023_003DzrBbLi9gbWAhX;

			[DebuggerHidden]
			public _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D(int _0023_003Dz0FVSO5LFyxyq)
			{
				this._0023_003Dz0FVSO5LFyxyq = _0023_003Dz0FVSO5LFyxyq;
				_0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			private void _0023_003DztGebTB5LtngkpFRyVA_003D_003D()
			{
				_0023_003DzLpHmoY82u_K4wDwOPw_003D_003D = null;
				_0023_003DzL6833cF254dsc4iU4w_003D_003D = null;
				_0023_003Dz0FVSO5LFyxyq = -2;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=ztGebTB5LtngkpFRyVA==
				this._0023_003DztGebTB5LtngkpFRyVA_003D_003D();
			}

			private bool _0023_003DzCENN6fc_003D()
			{
				int num = _0023_003Dz0FVSO5LFyxyq;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_0023_003Dz0FVSO5LFyxyq = -1;
					goto IL_0163;
				}
				_0023_003Dz0FVSO5LFyxyq = -1;
				string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611529);
				_0023_003DzLpHmoY82u_K4wDwOPw_003D_003D = text.Split(',');
				if (_0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D == null && !_0023_003DzeyZGBeZrbf0fsYNuGL79_0024WhXkn0t())
				{
					return false;
				}
				_0023_003DzL6833cF254dsc4iU4w_003D_003D = _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D[0];
				_0023_003DzrBbLi9gbWAhX = 1;
				goto IL_0171;
				IL_0163:
				_0023_003DzrBbLi9gbWAhX += 4;
				goto IL_0171;
				IL_0171:
				if (_0023_003DzrBbLi9gbWAhX < _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D.Length)
				{
					string text2 = _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D[_0023_003DzrBbLi9gbWAhX];
					if (_0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D == null || text2.Equals(_0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D, StringComparison.Ordinal))
					{
						_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2 = new _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro();
						_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzI87hjWw_003D = _0023_003DzL6833cF254dsc4iU4w_003D_003D;
						_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzyEIzz37e4HL649awVrohlCw_003D = text2;
						string text3 = _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D[_0023_003DzrBbLi9gbWAhX + 1];
						int num2 = text3.IndexOf('|');
						if (num2 >= 0)
						{
							string text4 = text3.Substring(0, num2);
							text3 = text3.Substring(num2 + 1);
							_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003Dzbq5PWV0Qc_0024apX_dW8U4834vns_Pe = text4.IndexOf('a') != -1;
							_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzAfB8t2d6W_0024y1MB1gQxrmOczkt30G = text4.IndexOf('b') != -1;
							_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzeHtiGbwhqyisRlzb2f6X8AwTRoUL = text4.IndexOf('c') != -1;
							_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzkmudC19KJChxzyjeqKTdsMiLzxgg = text4.IndexOf('f') != -1;
						}
						_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t = text3;
						_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2._0023_003DzVM4kz8Vjohg_002429Q_DzLz4I5ltu_00244 = _0023_003DzLpHmoY82u_K4wDwOPw_003D_003D[_0023_003DzrBbLi9gbWAhX + 2];
						_0023_003Dzn0gRlKh1Xs_0024z = _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro2;
						_0023_003Dz0FVSO5LFyxyq = 1;
						return true;
					}
					goto IL_0163;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zCENN6fc=
				return this._0023_003DzCENN6fc_003D();
			}

			[DebuggerHidden]
			private _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003DzghlRVogzPoap_QtGpSJxNu2Dc0f1GjmB_ZDXqZNSuYaVStA0W8qvHCkem_0024gB0Lo5R0Dd8WNhCpGnp4HBKJ8Wf9t0YRjX()
			{
				return _0023_003Dzn0gRlKh1Xs_0024z;
			}

			_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro IEnumerator<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro>.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zghlRVogzPoap_QtGpSJxNu2Dc0f1GjmB_ZDXqZNSuYaVStA0W8qvHCkem$gB0Lo5R0Dd8WNhCpGnp4HBKJ8Wf9t0YRjX
				return this._0023_003DzghlRVogzPoap_QtGpSJxNu2Dc0f1GjmB_ZDXqZNSuYaVStA0W8qvHCkem_0024gB0Lo5R0Dd8WNhCpGnp4HBKJ8Wf9t0YRjX();
			}

			[DebuggerHidden]
			private void _0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D()
			{
				throw new NotSupportedException();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zSJDwxsp$EPiLsdD2FQ==
				this._0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D();
			}

			[DebuggerHidden]
			private object _0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D()
			{
				return _0023_003Dzn0gRlKh1Xs_0024z;
			}

			object IEnumerator.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zmzmoZTP$PubEDyNMJew_S2I=
				return this._0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D();
			}

			[DebuggerHidden]
			private IEnumerator<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro> _0023_003Dz1Z5M5WTxLLVws2Lz7UPnZ7H2pt_rPfyaRgL07_0024kEZQMalkwS_QzOnEDVr2I016N1ZiLNoj21NwpC0fDLsJcKLNM3Hi79()
			{
				_0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D2;
				if (_0023_003Dz0FVSO5LFyxyq == -2 && _0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D == Thread.CurrentThread.ManagedThreadId)
				{
					_0023_003Dz0FVSO5LFyxyq = 0;
					_0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D2 = this;
				}
				else
				{
					_0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D2 = new _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D(0);
				}
				_0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D2._0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D = _0023_003DzfKi3ue3fi8u39ADrVw_003D_003D;
				return _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D2;
			}

			IEnumerator<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro> IEnumerable<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=z1Z5M5WTxLLVws2Lz7UPnZ7H2pt_rPfyaRgL07$kEZQMalkwS_QzOnEDVr2I016N1ZiLNoj21NwpC0fDLsJcKLNM3Hi79
				return this._0023_003Dz1Z5M5WTxLLVws2Lz7UPnZ7H2pt_rPfyaRgL07_0024kEZQMalkwS_QzOnEDVr2I016N1ZiLNoj21NwpC0fDLsJcKLNM3Hi79();
			}

			[DebuggerHidden]
			private IEnumerator _0023_003DzJVmfuxvyPUS91uHSAPj3GTo_003D()
			{
				return _0023_003Dz1Z5M5WTxLLVws2Lz7UPnZ7H2pt_rPfyaRgL07_0024kEZQMalkwS_QzOnEDVr2I016N1ZiLNoj21NwpC0fDLsJcKLNM3Hi79();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zJVmfuxvyPUS91uHSAPj3GTo=
				return this._0023_003DzJVmfuxvyPUS91uHSAPj3GTo_003D();
			}
		}

		internal sealed class _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro
		{
			public string _0023_003DzyEIzz37e4HL649awVrohlCw_003D;

			private string _0023_003Dz59seO3VNpZklpwYv6ANca_0024Cb2s2o;

			public string _0023_003DzI87hjWw_003D;

			public string _0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t;

			public bool _0023_003Dzbq5PWV0Qc_0024apX_dW8U4834vns_Pe;

			public bool _0023_003DzAfB8t2d6W_0024y1MB1gQxrmOczkt30G;

			public bool _0023_003DzeHtiGbwhqyisRlzb2f6X8AwTRoUL;

			public bool _0023_003Dz3fhHLy5Gvh336rmVb4gGUYN_008a;

			public bool _0023_003DzEJWIYrAJ8MJ2HsGhOgO4vU7vDGo_0024;

			public bool _0023_003DzkmudC19KJChxzyjeqKTdsMiLzxgg;

			public string _0023_003DzVM4kz8Vjohg_002429Q_DzLz4I5ltu_00244;

			private string _0023_003Dz1Rku87Y5J49XzSAhd8gihiCgcNG_;

			public string _0023_003DzdquYlAFxoEmakdIcW0go7Cu2KRKo()
			{
				if (_0023_003Dz59seO3VNpZklpwYv6ANca_0024Cb2s2o == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003DzyEIzz37e4HL649awVrohlCw_003D);
					_0023_003Dz59seO3VNpZklpwYv6ANca_0024Cb2s2o = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003Dz59seO3VNpZklpwYv6ANca_0024Cb2s2o;
			}

			public string _0023_003Dz98AA0BPoC5ysKuls4LWdooixdH0x()
			{
				if (_0023_003Dz1Rku87Y5J49XzSAhd8gihiCgcNG_ == null)
				{
					byte[] array = Convert.FromBase64String(_0023_003DzVM4kz8Vjohg_002429Q_DzLz4I5ltu_00244);
					_0023_003Dz1Rku87Y5J49XzSAhd8gihiCgcNG_ = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return _0023_003Dz1Rku87Y5J49XzSAhd8gihiCgcNG_;
			}
		}

		private struct _0023_003Dzyw9nmrA_003D
		{
			private readonly string _0023_003DzI6MHShg_003D;

			private FileStream _0023_003Dzt2uTtTYAreci;

			public _0023_003Dzyw9nmrA_003D(string _0023_003Dz83HaHYE_003D)
			{
				this = default(_0023_003Dzyw9nmrA_003D);
				_0023_003DzI6MHShg_003D = _0023_003Dz83HaHYE_003D;
			}

			public bool _0023_003DzW2Jyt7g_003D()
			{
				try
				{
					if (_0023_003Dzt2uTtTYAreci != null)
					{
						return false;
					}
					_0023_003Dzt2uTtTYAreci = new FileStream(_0023_003DzI6MHShg_003D, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128, FileOptions.DeleteOnClose);
				}
				catch
				{
					return false;
				}
				return true;
			}

			public void _0023_003DzTC_InOc_003D()
			{
				Stopwatch stopwatch = null;
				int num = 25;
				int num2 = 250;
				while (!_0023_003DzW2Jyt7g_003D())
				{
					if (stopwatch == null)
					{
						stopwatch = Stopwatch.StartNew();
					}
					else
					{
						if (stopwatch.Elapsed.TotalSeconds > 300.0)
						{
							throw new TimeoutException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611480), _0023_003DzI6MHShg_003D));
						}
						if (num < num2)
						{
							num = Math.Min(num * 2, num2);
						}
					}
					Thread.Sleep(num);
				}
			}

			public void _0023_003DztXPi6iI_003D()
			{
				if (_0023_003Dzt2uTtTYAreci != null)
				{
					_0023_003Dzt2uTtTYAreci.Dispose();
					_0023_003Dzt2uTtTYAreci = null;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IEnumerable<_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro> _0023_003Dzp1fiBvifwRB3XT6Rw4kqN5jON3jX(string _0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D)
		{
			return new _0023_003Dz9TBDAaMrrrKHRgfcK3OtBmM_003D(-2)
			{
				_0023_003DzfKi3ue3fi8u39ADrVw_003D_003D = _0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D
			};
		}

		internal static byte[] _0023_003Dzskri3O7VpswKv7hyPt53rpvkFCH4(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t);
			if (manifestResourceStream == null)
			{
				return null;
			}
			int num = (int)manifestResourceStream.Length;
			byte[] array = new byte[num];
			manifestResourceStream.Read(array, 0, num);
			manifestResourceStream.Dispose();
			if (_0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003Dzbq5PWV0Qc_0024apX_dW8U4834vns_Pe)
			{
				array = _0023_003Dz4jdvtXV174NkZEdX3jtw73e_00248aqo(array);
			}
			if (_0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003DzAfB8t2d6W_0024y1MB1gQxrmOczkt30G)
			{
				array = _0023_003DzoHxJk4bsciXge6uJnxkVtixevjfF(array);
			}
			return array;
		}

		internal static string _0023_003Dz_f7ABfpSKmETch9sxzDc0MOrBgIu(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ, bool _0023_003DzRxAqclp_0024TM_oEcMQxAEBlyD1b7Oi, byte[] _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It)
		{
			string path = (_0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003DzkmudC19KJChxzyjeqKTdsMiLzxgg ? _0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t : _0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003DzI87hjWw_003D);
			string text = Path.Combine(Path.GetTempPath(), path);
			try
			{
				Directory.CreateDirectory(text);
			}
			catch
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				text = Path.Combine(text, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611620));
				text = Path.Combine(text, path);
				Directory.CreateDirectory(text);
				if (text == null)
				{
					throw;
				}
			}
			string text2 = Path.Combine(text, _0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ._0023_003Dz98AA0BPoC5ysKuls4LWdooixdH0x());
			_0023_003Dzyw9nmrA_003D _0023_003Dzyw9nmrA_003D2 = new _0023_003Dzyw9nmrA_003D(text2 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611639));
			_0023_003Dzyw9nmrA_003D2._0023_003DzTC_InOc_003D();
			try
			{
				if (!File.Exists(text2))
				{
					if (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It == null)
					{
						_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It = _0023_003Dzskri3O7VpswKv7hyPt53rpvkFCH4(_0023_003Dz1MAmBLuFrw4qkRw0MuvR7s76WGLJ);
					}
					File.WriteAllBytes(text2, _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It);
					if (_0023_003DzRxAqclp_0024TM_oEcMQxAEBlyD1b7Oi)
					{
						try
						{
							_0023_003Dz0nKakCWnOajLumNIG9CUnmheBisc(text2, null, 4);
							_0023_003Dz0nKakCWnOajLumNIG9CUnmheBisc(text, null, 4);
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				_0023_003Dzyw9nmrA_003D2._0023_003DztXPi6iI_003D();
			}
			return text2;
		}

		internal static void _0023_003Dzc5erjcElBBvqXjMbef26ZxEWVvui(string _0023_003DzOGpgns3mvh06yam_0024_0024kjNRfT7A1PG, bool _0023_003DzhWJ_l9m4ZBKYuX47CPvRvC_8VKbj)
		{
			bool flag = false;
			try
			{
				File.Delete(_0023_003DzOGpgns3mvh06yam_0024_0024kjNRfT7A1PG);
				flag = true;
			}
			catch
			{
			}
			string directoryName = Path.GetDirectoryName(_0023_003DzOGpgns3mvh06yam_0024_0024kjNRfT7A1PG);
			bool flag2 = false;
			try
			{
				Directory.Delete(directoryName);
				flag = true;
			}
			catch
			{
			}
			if (!_0023_003DzhWJ_l9m4ZBKYuX47CPvRvC_8VKbj)
			{
				return;
			}
			if (!flag)
			{
				try
				{
					_0023_003Dz0nKakCWnOajLumNIG9CUnmheBisc(_0023_003DzOGpgns3mvh06yam_0024_0024kjNRfT7A1PG, null, 4);
				}
				catch
				{
				}
			}
			if (!flag2)
			{
				try
				{
					_0023_003Dz0nKakCWnOajLumNIG9CUnmheBisc(directoryName, null, 4);
				}
				catch
				{
				}
			}
		}
	}

	private static class _0023_003DzehcVkurY6xnUh7T377yH_0024sEk7ANi
	{
		internal static readonly Dictionary<string, Assembly> _0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D = new Dictionary<string, Assembly>(StringComparer.Ordinal);
	}

	private struct _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ
	{
		public Version _0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc;

		public bool _0023_003Dzxe51SRjzT2GBhfaXl4QOQ_0024MU6HLS;

		public string _0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU;

		public string _0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx;

		public bool _0023_003Dz3rEKnS1IowWlPj13o0CaWArpFoNQ;

		public string _0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX;

		public bool _0023_003DzqbciidopUpxc6g5jOE_51Ooq4hC7;

		public _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ(string _0023_003DzEfI_ZF9C82vLElE5LIwbtuG9QhXk)
		{
			this = default(_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ);
			_0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc = new Version();
			_0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU = string.Empty;
			string[] array = _0023_003DzEfI_ZF9C82vLElE5LIwbtuG9QhXk.Split(',');
			foreach (string text in array)
			{
				string text2 = text.Trim();
				if (text2.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611320), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc = new Version(text2.Substring(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611320).Length));
					_0023_003Dzxe51SRjzT2GBhfaXl4QOQ_0024MU6HLS = true;
				}
				else if (text2.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611081), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx = text2.Substring(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611081).Length);
					if (_0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611098), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx = null;
					}
					_0023_003Dz3rEKnS1IowWlPj13o0CaWArpFoNQ = true;
				}
				else if (text2.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611116), StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX = text2.Substring(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611116).Length);
					if (_0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611126), StringComparison.OrdinalIgnoreCase))
					{
						_0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX = null;
					}
					_0023_003DzqbciidopUpxc6g5jOE_51Ooq4hC7 = true;
				}
				else
				{
					_0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU = text2;
				}
			}
		}

		public string _0023_003Dz7hPSjOJY7XeB(bool _0023_003DzChS9P9SDFRCfKI_0024Mj_aSP4Ppi_1x)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU);
			if (_0023_003DzChS9P9SDFRCfKI_0024Mj_aSP4Ppi_1x)
			{
				stringBuilder.Append(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611147)).Append(_0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc);
			}
			stringBuilder.Append(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611162)).Append(_0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx ?? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611177)).Append(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611195))
				.Append(_0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX ?? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611459));
			return stringBuilder.ToString();
		}
	}

	private static int _0023_003Dz6TDk_QTAifewm0M3D0mfD4q6846h;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzeyZGBeZrbf0fsYNuGL79_0024WhXkn0t()
	{
		if (!_0023_003Dz5mTGcsJXB8i9Um8_0024PBf_kYeuhwoy())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003Dz5mTGcsJXB8i9Um8_0024PBf_kYeuhwoy()
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
		if ((object)type.Assembly != typeof(_0023_003Dzo2vT_xDsdJ7qFMhM_0024AerELgo9GU6).Assembly)
		{
			return false;
		}
		return true;
	}

	internal static Assembly _0023_003Dz6It9KyA_003D(string _0023_003DzTmoIev_W00hh08erAfOR6Cp9Omeh)
	{
		return _0023_003DzaKgelPm062arzyQ8xFEaPF4yzY7R(_0023_003DzTmoIev_W00hh08erAfOR6Cp9Omeh);
	}

	private static Assembly _0023_003Dz_Lat6Qog8QJfZHPeURrqGpsvEZqw(object _0023_003DzxwGby4M_003D, ResolveEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		return _0023_003DzaKgelPm062arzyQ8xFEaPF4yzY7R(_0023_003Dzs9Vs9Ak_003D.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzaKgelPm062arzyQ8xFEaPF4yzY7R(string _0023_003DzTmoIev_W00hh08erAfOR6Cp9Omeh)
	{
		_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2 = new _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ(_0023_003DzTmoIev_W00hh08erAfOR6Cp9Omeh.ToUpperInvariant());
		_0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro = null;
		bool flag = false;
		int num = 0;
		if (!_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzqbciidopUpxc6g5jOE_51Ooq4hC7 || _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX != null)
		{
			foreach (_0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro item in _0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003Dzp1fiBvifwRB3XT6Rw4kqN5jON3jX(null))
			{
				if (!item._0023_003DzdquYlAFxoEmakdIcW0go7Cu2KRKo().StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611659), StringComparison.Ordinal))
				{
					continue;
				}
				_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3 = new _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ(item._0023_003DzdquYlAFxoEmakdIcW0go7Cu2KRKo().Substring(5));
				if (_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3._0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU != _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003Dzye8X03YFdAar8UCRyqQsvJicnHSU || _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3._0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx != _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzAJqWNh_00245gxz0uUB7tUsOpmGwgLYx || (_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzqbciidopUpxc6g5jOE_51Ooq4hC7 && _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3._0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX != _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzmtaQHLAeLwmy4rQlBSUw7WajzsBX))
				{
					continue;
				}
				if (_0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003Dzxe51SRjzT2GBhfaXl4QOQ_0024MU6HLS && _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3._0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc != _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc)
				{
					flag = true;
					if (num == 0)
					{
						num = _0023_003DzWYOhA7IxOy10QQMELb05g_s_003D();
					}
					if (num != 2 || _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc > _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ3._0023_003DzOzfNCYQIBOOahtZEBTQW69nk_0024kuc)
					{
						continue;
					}
				}
				_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro = item;
				break;
			}
		}
		if (_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro == null && !flag)
		{
			string s = _0023_003DzimOPi6XS6dw_KZjjs1S2m8B4fqQJ2._0023_003Dz7hPSjOJY7XeB(_0023_003DzChS9P9SDFRCfKI_0024Mj_aSP4Ppi_1x: false);
			string _0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			using IEnumerator<_0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro> enumerator2 = _0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003Dzp1fiBvifwRB3XT6Rw4kqN5jON3jX(_0023_003DzyN_0024LtvNNm_YgoBcPDqoy5wY_003D).GetEnumerator();
			if (enumerator2.MoveNext())
			{
				_0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro current2 = enumerator2.Current;
				_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro = current2;
			}
		}
		if (_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro == null)
		{
			return null;
		}
		Dictionary<string, Assembly> _0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D = _0023_003DzehcVkurY6xnUh7T377yH_0024sEk7ANi._0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D;
		Assembly value;
		lock (_0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D)
		{
			if (!_0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D.TryGetValue(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro._0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t, out value))
			{
				byte[] array = _0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003Dzskri3O7VpswKv7hyPt53rpvkFCH4(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro);
				if (array == null)
				{
					return null;
				}
				bool flag2 = _0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro._0023_003DzeHtiGbwhqyisRlzb2f6X8AwTRoUL;
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
						string assemblyFile = _0023_003DzZdZlgSxHzgcmbYMtzdlinDk_003D._0023_003Dz_f7ABfpSKmETch9sxzDc0MOrBgIu(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro, _0023_003DzRxAqclp_0024TM_oEcMQxAEBlyD1b7Oi: true, array);
						value = Assembly.LoadFrom(assemblyFile);
					}
					catch
					{
					}
				}
				_0023_003DzRApUJJmqRBBEqXhZqY2_0024Pgk_003D.Add(_0023_003DzFi9nY0C1rFdny6aCAdWG9IFYT8ro._0023_003DzPcnFfvASwqImHr0y3ikoaXU92U9t, value);
			}
		}
		return value;
	}

	private static int _0023_003DzWYOhA7IxOy10QQMELb05g_s_003D()
	{
		int num = _0023_003Dz6TDk_QTAifewm0M3D0mfD4q6846h;
		if (num == 0)
		{
			num = (_0023_003Dz6TDk_QTAifewm0M3D0mfD4q6846h = (((object)Type.GetType(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611679)) == null) ? 1 : 2));
		}
		return num;
	}

	internal static void _0023_003DzDw__wI8_003D()
	{
		AppDomain.CurrentDomain.AssemblyResolve += _0023_003Dz_Lat6Qog8QJfZHPeURrqGpsvEZqw;
	}

	private static int _0023_003DzdlKrF5eocO3owX8RVIGfOP7BRq6Q(byte[] _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It, int _0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024)
	{
		return _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024] | (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 1] << 24) | (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 2] << 8) | (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 3] << 16);
	}

	private static int _0023_003DzWHjibUWBbof3GlMuGi26BS5Zjb5x(byte[] _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It, int _0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024)
	{
		return (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024] << 8) | _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 1] | (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 2] << 16) | (_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[_0023_003Dz_0024VoLxXwtnP4o2FLyw23sshMkZIP_0024 + 3] << 24);
	}

	private static byte[] _0023_003DzoHxJk4bsciXge6uJnxkVtixevjfF(byte[] _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It)
	{
		int num = _0023_003DzdlKrF5eocO3owX8RVIGfOP7BRq6Q(_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It, 0);
		if (num != -1686991929)
		{
			throw new Exception();
		}
		int num2 = _0023_003DzWHjibUWBbof3GlMuGi26BS5Zjb5x(_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It, 4);
		Stream stream = new MemoryStream(_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It, writable: false);
		stream.Position = 8L;
		stream = new DeflateStream(stream, CompressionMode.Decompress);
		BinaryReader binaryReader = new BinaryReader(stream);
		_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It = binaryReader.ReadBytes(num2);
		binaryReader.Close();
		int num3 = _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It.Length;
		if (num3 != num2)
		{
			throw new Exception();
		}
		return _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] _0023_003Dz4jdvtXV174NkZEdX3jtw73e_00248aqo(byte[] _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It)
	{
		string s = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611992);
		byte[] array = Convert.FromBase64String(s);
		_0023_003DzFIfdRy030CZPLe1923s0NXj3psgi._0023_003DzDw__wI8_003D(array);
		_0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx _0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx2 = new _0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx(array);
		int num = _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It.Length;
		byte b = 0;
		byte b2 = 121;
		byte[] array2 = new byte[8] { 148, 68, 208, 52, 241, 93, 195, 220 };
		for (int i = 0; i != num; i++)
		{
			if (b == 0)
			{
				b2 = _0023_003DzS9zLl5Gog2c6oviWIFh3Q9FSFRcx2._0023_003Dzee0RmGcZndRd0c_0024hYiT23Xs_003D();
			}
			b++;
			if (b == 32)
			{
				b = 0;
			}
			_0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It[i] ^= (byte)(b2 ^ array2[(i >> 2) & 3] ^ array2[b & 3]);
		}
		return _0023_003DziiBR6wO0PWJbT0MEZNVggXWnt1It;
	}

	[DllImport("kernel32.dll", EntryPoint = "MoveFileEx")]
	private static extern bool _0023_003Dz0nKakCWnOajLumNIG9CUnmheBisc(string _0023_003Dz2ekH4919qythK8Yg8u470HsKCdAl, string _0023_003DzL4vexpHZextnznfIBIrHlxgmAlKB, int _0023_003DzIdUgHbY9T3Nr6rNHuCkzqLA_003D);
}
