using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using devDept.Geometry;

internal sealed class _0023_003DzVss84oikfBMVUb36Rd_00247Di0iyxUN
{
	private sealed class _0023_003Dz_00245gUm2U_003D
	{
		private sealed class _0023_003Dz50188W33pg0HI6xVLQ_003D_003D : IEnumerable<_0023_003Dz_00245gUm2U_003D>, IEnumerable, IEnumerator<_0023_003Dz_00245gUm2U_003D>, IDisposable, IEnumerator
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private int _0023_003DzU7pGb3X7Zp4G;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private _0023_003Dz_00245gUm2U_003D _0023_003DzezVIuujSK1H9;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public _0023_003Dz_00245gUm2U_003D _0023_003DzopRx0_MBcTQs;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private _0023_003Dz_00245gUm2U_003D _0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D;

			[DebuggerHidden]
			public _0023_003Dz50188W33pg0HI6xVLQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
			{
				this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
				_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
			{
				_0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D = null;
				_0023_003DzU7pGb3X7Zp4G = -2;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
				this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
			}

			private bool MoveNext()
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D2 = _0023_003DzopRx0_MBcTQs;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D = _0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D._0023_003DzDGmKoao_003D();
					if (_0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D == _0023_003Dz_00245gUm2U_003D2)
					{
						return false;
					}
				}
				else
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D = _0023_003Dz_00245gUm2U_003D2;
				}
				_0023_003DzezVIuujSK1H9 = _0023_003DzgLmC9cwxZXSHyVBzuw_003D_003D;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private _0023_003Dz_00245gUm2U_003D _0023_003Dz6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs_003D()
			{
				return _0023_003DzezVIuujSK1H9;
			}

			_0023_003Dz_00245gUm2U_003D IEnumerator<_0023_003Dz_00245gUm2U_003D>.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=z6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs=
				return this._0023_003Dz6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs_003D();
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
			private IEnumerator<_0023_003Dz_00245gUm2U_003D> _0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D()
			{
				_0023_003Dz50188W33pg0HI6xVLQ_003D_003D _0023_003Dz50188W33pg0HI6xVLQ_003D_003D2;
				if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
				{
					_0023_003DzU7pGb3X7Zp4G = 0;
					_0023_003Dz50188W33pg0HI6xVLQ_003D_003D2 = this;
				}
				else
				{
					_0023_003Dz50188W33pg0HI6xVLQ_003D_003D2 = new _0023_003Dz50188W33pg0HI6xVLQ_003D_003D(0);
					_0023_003Dz50188W33pg0HI6xVLQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
				}
				return _0023_003Dz50188W33pg0HI6xVLQ_003D_003D2;
			}

			IEnumerator<_0023_003Dz_00245gUm2U_003D> IEnumerable<_0023_003Dz_00245gUm2U_003D>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico$AlTYKEIOGY8=
				return this._0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D();
			}

			[DebuggerHidden]
			private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
			{
				return _0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
				return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
			}
		}

		public _0023_003DzF6l0Wio_003D _0023_003DzF6l0Wio_003D;

		private _0023_003Dz_00245gUm2U_003D _0023_003DzKLJJUimQMnxGA4drog_003D_003D;

		public _0023_003Dz_00245gUm2U_003D(_0023_003DzF6l0Wio_003D _0023_003Dz_0024BTSBRo_003D)
		{
			_0023_003DzF6l0Wio_003D = _0023_003Dz_0024BTSBRo_003D;
		}

		public _0023_003Dz_00245gUm2U_003D _0023_003DzDGmKoao_003D()
		{
			return _0023_003DzKLJJUimQMnxGA4drog_003D_003D;
		}

		public void _0023_003Dzhp_0024fZss_003D(_0023_003Dz_00245gUm2U_003D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzKLJJUimQMnxGA4drog_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public _0023_003Dz_00245gUm2U_003D _0023_003Dzx9P_oXY_003D()
		{
			return new _0023_003Dz_00245gUm2U_003D(_0023_003DzF6l0Wio_003D);
		}

		public static double _0023_003DzOxKU6GM_003D(_0023_003Dz_00245gUm2U_003D _0023_003DzRVoDPs0_003D, _0023_003Dz_00245gUm2U_003D _0023_003Dzl_0024MIsC0_003D)
		{
			return _0023_003DzF6l0Wio_003D._0023_003DzOxKU6GM_003D(_0023_003DzRVoDPs0_003D._0023_003DzF6l0Wio_003D, _0023_003Dzl_0024MIsC0_003D._0023_003DzF6l0Wio_003D);
		}

		[IteratorStateMachine(typeof(_0023_003Dz50188W33pg0HI6xVLQ_003D_003D))]
		public IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003Dzf_00244xy23jJnAF()
		{
			return new _0023_003Dz50188W33pg0HI6xVLQ_003D_003D(-2)
			{
				_0023_003DzopRx0_MBcTQs = this
			};
		}

		public override bool Equals(object _0023_003DzCX9Hbao_003D)
		{
			return _0023_003DzF6l0Wio_003D == ((_0023_003Dz_00245gUm2U_003D)_0023_003DzCX9Hbao_003D)._0023_003DzF6l0Wio_003D;
		}

		public override string ToString()
		{
			return _0023_003DzF6l0Wio_003D.ToString();
		}
	}

	private sealed class _0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Point2D
	{
		public int _0023_003Dz437_00244ak_003D;

		internal bool _0023_003DzTR91eyvNBnIKOxb__Q_003D_003D(IndexLine _0023_003Dzt_m8zV0_003D)
		{
			if (_0023_003Dzt_m8zV0_003D.V1 != _0023_003Dz437_00244ak_003D)
			{
				return _0023_003Dzt_m8zV0_003D.V2 != _0023_003Dz437_00244ak_003D;
			}
			return false;
		}
	}

	private sealed class _0023_003Dz_0024PcG_maJxbuZ
	{
		[Serializable]
		private sealed class _0023_003Dz2IEmqow_003D
		{
			public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

			public static Func<_0023_003Dz_00245gUm2U_003D, _0023_003Dz_00245gUm2U_003D> _0023_003DzUdr4O3AsaCYJAKzjhQ_003D_003D;

			public static Func<double, _0023_003Dz_00245gUm2U_003D, double> _0023_003DzW6VNWCUPEKb1Yg8DZQ_003D_003D;

			public static Func<_0023_003Dz_00245gUm2U_003D, string> _0023_003DzwwY5ZBi2wUYuUPrxAA_003D_003D;

			internal _0023_003Dz_00245gUm2U_003D _0023_003Dzh75W5EgIEhtlHkAb_K9ccMe4FGXRvYmm7g_003D_003D(_0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D)
			{
				return _0023_003Dzwi058ac_003D._0023_003Dzx9P_oXY_003D();
			}

			internal double _0023_003DzgJwwmCt0lNIjFMpeYw_003D_003D(double _0023_003DzH1SwwS4_003D, _0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D)
			{
				return _0023_003DzH1SwwS4_003D + _0023_003Dz_00245gUm2U_003D._0023_003DzOxKU6GM_003D(_0023_003Dzwi058ac_003D, _0023_003Dzwi058ac_003D._0023_003DzDGmKoao_003D());
			}

			internal string _0023_003DzLIvH8sxUhogAbR5wuA_003D_003D(_0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D)
			{
				return _0023_003Dzwi058ac_003D.ToString();
			}
		}

		private sealed class _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D
		{
			public _0023_003Dz_0024PcG_maJxbuZ _0023_003DzopRx0_MBcTQs;

			public _0023_003Dz_0024PcG_maJxbuZ _0023_003DzA_u56iPDnPW7;

			public double _0023_003Dz2uMCpAK510dx;

			internal void _0023_003DzxI_wt_kodqTX2h2qOA_003D_003D(_0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D)
			{
				if (_0023_003Dzwi058ac_003D._0023_003DzDGmKoao_003D() == _0023_003DzopRx0_MBcTQs._0023_003DzMn_N27Esy8SQ())
				{
					return;
				}
				_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D2 = _0023_003Dzwi058ac_003D._0023_003DzDGmKoao_003D()._0023_003DzDGmKoao_003D();
				_0023_003Dz_0024PcG_maJxbuZ _0023_003Dz_0024PcG_maJxbuZ2 = null;
				double num = -1.0;
				while (_0023_003Dz_00245gUm2U_003D2 != _0023_003DzopRx0_MBcTQs._0023_003DzMn_N27Esy8SQ())
				{
					_0023_003Dz_0024PcG_maJxbuZ _0023_003Dz_0024PcG_maJxbuZ3 = _0023_003DzopRx0_MBcTQs._0023_003DzSYpMBWOUv39U(_0023_003Dzwi058ac_003D._0023_003DzF6l0Wio_003D, _0023_003Dz_00245gUm2U_003D2._0023_003DzF6l0Wio_003D);
					_0023_003Dz_0024PcG_maJxbuZ _0023_003Dz_0024PcG_maJxbuZ4 = _0023_003Dz_0024PcG_maJxbuZ3._0023_003DziSu0e_o_003D();
					double num2 = _0023_003Dz_0024PcG_maJxbuZ3._0023_003DzbAyqU54_003D();
					double num3 = _0023_003Dz_0024PcG_maJxbuZ4._0023_003DzbAyqU54_003D();
					if (_0023_003Dz_0024PcG_maJxbuZ2 == null || num2 < num)
					{
						num = num2;
						_0023_003Dz_0024PcG_maJxbuZ2 = _0023_003Dz_0024PcG_maJxbuZ3;
					}
					if (num3 < num)
					{
						num = num3;
						_0023_003Dz_0024PcG_maJxbuZ2 = _0023_003Dz_0024PcG_maJxbuZ4;
					}
					_0023_003Dz_00245gUm2U_003D2 = _0023_003Dz_00245gUm2U_003D2._0023_003DzDGmKoao_003D();
				}
				lock (_0023_003DzA_u56iPDnPW7)
				{
					if (_0023_003Dz_0024PcG_maJxbuZ2 != null && num < _0023_003Dz2uMCpAK510dx)
					{
						_0023_003Dz2uMCpAK510dx = num;
						_0023_003DzA_u56iPDnPW7 = _0023_003Dz_0024PcG_maJxbuZ2;
					}
				}
			}
		}

		private sealed class _0023_003DzThMorOKkX_m9tBKf8w_003D_003D
		{
			public _0023_003Dz_00245gUm2U_003D _0023_003Dzng5L35w_003D;

			internal bool _0023_003DzobEQ4PGWqQQP0WGFew_003D_003D(_0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D)
			{
				return _0023_003Dzwi058ac_003D != _0023_003Dzng5L35w_003D;
			}
		}

		private _0023_003Dz_00245gUm2U_003D _0023_003DzDZp1rtpUD8LzMNHUzg_003D_003D;

		public _0023_003Dz_0024PcG_maJxbuZ(IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzwDQzNwGdCj4a)
		{
			_0023_003Dzf_0024CG3l1yClDe(_0023_003DzwDQzNwGdCj4a.First());
		}

		public _0023_003Dz_00245gUm2U_003D _0023_003DzMn_N27Esy8SQ()
		{
			return _0023_003DzDZp1rtpUD8LzMNHUzg_003D_003D;
		}

		public void _0023_003Dzf_0024CG3l1yClDe(_0023_003Dz_00245gUm2U_003D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzDZp1rtpUD8LzMNHUzg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public _0023_003Dz_0024PcG_maJxbuZ _0023_003Dz8_ZYz_0024AF6Na7(double _0023_003Dz2uMCpAK510dx, out double _0023_003Dzx9mJdMs_003D)
		{
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2 = new _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D();
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzopRx0_MBcTQs = this;
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003Dz2uMCpAK510dx = _0023_003Dz2uMCpAK510dx;
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzA_u56iPDnPW7 = this;
			Parallel.ForEach(_0023_003Dz8UoYj98_003D(), _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzxI_wt_kodqTX2h2qOA_003D_003D);
			_0023_003Dzx9mJdMs_003D = _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003Dz2uMCpAK510dx;
			return _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzA_u56iPDnPW7;
		}

		private _0023_003Dz_0024PcG_maJxbuZ _0023_003DziSu0e_o_003D()
		{
			IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzwDQzNwGdCj4a = _0023_003DzE07dytdLcViysI9nbFDVhfU_003D().Reverse();
			_0023_003DzJKePfk0_003D(_0023_003DzwDQzNwGdCj4a, _0023_003DzdEvMFOw_003D: true);
			return new _0023_003Dz_0024PcG_maJxbuZ(_0023_003DzwDQzNwGdCj4a);
		}

		private _0023_003Dz_0024PcG_maJxbuZ _0023_003DzSYpMBWOUv39U(_0023_003DzF6l0Wio_003D _0023_003Dz0ZkNffc_003D, _0023_003DzF6l0Wio_003D _0023_003DzUBk7hDs_003D)
		{
			_0023_003DzThMorOKkX_m9tBKf8w_003D_003D _0023_003DzThMorOKkX_m9tBKf8w_003D_003D2 = new _0023_003DzThMorOKkX_m9tBKf8w_003D_003D();
			_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D2 = null;
			_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D3 = null;
			IList<_0023_003Dz_00245gUm2U_003D> list = _0023_003DzE07dytdLcViysI9nbFDVhfU_003D();
			_0023_003DzJKePfk0_003D(list, _0023_003DzdEvMFOw_003D: true);
			foreach (_0023_003Dz_00245gUm2U_003D item in list)
			{
				if (item._0023_003DzF6l0Wio_003D == _0023_003Dz0ZkNffc_003D)
				{
					_0023_003Dz_00245gUm2U_003D2 = item;
				}
				if (item._0023_003DzF6l0Wio_003D == _0023_003DzUBk7hDs_003D)
				{
					_0023_003Dz_00245gUm2U_003D3 = item;
				}
			}
			_0023_003Dz_00245gUm2U_003D obj = _0023_003Dz_00245gUm2U_003D2._0023_003DzDGmKoao_003D();
			_0023_003DzThMorOKkX_m9tBKf8w_003D_003D2._0023_003Dzng5L35w_003D = _0023_003Dz_00245gUm2U_003D3._0023_003DzDGmKoao_003D();
			_0023_003DzJKePfk0_003D(obj._0023_003Dzf_00244xy23jJnAF().TakeWhile(_0023_003DzThMorOKkX_m9tBKf8w_003D_003D2._0023_003DzobEQ4PGWqQQP0WGFew_003D_003D).Reverse(), _0023_003DzdEvMFOw_003D: false);
			obj._0023_003Dzhp_0024fZss_003D(_0023_003DzThMorOKkX_m9tBKf8w_003D_003D2._0023_003Dzng5L35w_003D);
			_0023_003Dz_00245gUm2U_003D2._0023_003Dzhp_0024fZss_003D(_0023_003Dz_00245gUm2U_003D3);
			return new _0023_003Dz_0024PcG_maJxbuZ(list);
		}

		private IList<_0023_003Dz_00245gUm2U_003D> _0023_003DzE07dytdLcViysI9nbFDVhfU_003D()
		{
			return _0023_003Dz8UoYj98_003D().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzh75W5EgIEhtlHkAb_K9ccMe4FGXRvYmm7g_003D_003D).ToList();
		}

		public double _0023_003DzbAyqU54_003D()
		{
			return _0023_003Dz8UoYj98_003D().Aggregate(0.0, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzgJwwmCt0lNIjFMpeYw_003D_003D);
		}

		private IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003Dz8UoYj98_003D()
		{
			return _0023_003DzMn_N27Esy8SQ()._0023_003Dzf_00244xy23jJnAF();
		}

		public override string ToString()
		{
			string arg = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659761), _0023_003Dz8UoYj98_003D().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzLIvH8sxUhogAbR5wuA_003D_003D).ToArray());
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659772), _0023_003DzbAyqU54_003D(), arg);
		}
	}

	private sealed class _0023_003DzCyMkm_0024xZcX_5 : _0023_003DzF6l0Wio_003D
	{
		public readonly int _0023_003Dz6ivnsYc_003D;

		private Point2D _0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D;

		private Point2D _0023_003DzMceFipG6e89Xy7qy7A_003D_003D;

		public _0023_003DzCyMkm_0024xZcX_5(Point2D _0023_003DzAqOpw0w_003D, Point2D _0023_003Dzk64JNOo_003D, int _0023_003DzyzK8swU_003D, int _0023_003Dz9iVQ96E_003D)
			: base(_0023_003DzyzK8swU_003D)
		{
			_0023_003DzE8NmKSc_003D(_0023_003DzAqOpw0w_003D);
			_0023_003DzEGrVsNI_003D(_0023_003Dzk64JNOo_003D);
			_0023_003Dz6ivnsYc_003D = _0023_003Dz9iVQ96E_003D;
		}

		public Point2D _0023_003DzTlWHc6c_003D()
		{
			return _0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D;
		}

		private void _0023_003DzE8NmKSc_003D(Point2D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public Point2D _0023_003Dz6FBK7II_003D()
		{
			return _0023_003DzMceFipG6e89Xy7qy7A_003D_003D;
		}

		private void _0023_003DzEGrVsNI_003D(Point2D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzMceFipG6e89Xy7qy7A_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659778), _0023_003DznN5ttMs_003D, _0023_003Dz6ivnsYc_003D);
		}
	}

	private abstract class _0023_003DzF6l0Wio_003D
	{
		public readonly int _0023_003DznN5ttMs_003D;

		protected _0023_003DzF6l0Wio_003D(int _0023_003DzyzK8swU_003D)
		{
			_0023_003DznN5ttMs_003D = _0023_003DzyzK8swU_003D;
		}

		public static double _0023_003DzOxKU6GM_003D(_0023_003DzF6l0Wio_003D _0023_003DzUBk7hDs_003D, _0023_003DzF6l0Wio_003D _0023_003Dz0ZkNffc_003D)
		{
			double num = -1.0;
			if (_0023_003DzUBk7hDs_003D is _0023_003Dzt2i9eQo_003D _0023_003Dzt2i9eQo_003D2)
			{
				if (_0023_003Dz0ZkNffc_003D is _0023_003Dzt2i9eQo_003D _0023_003Dzt2i9eQo_003D3)
				{
					num = _0023_003Dzt2i9eQo_003D2._0023_003DzGzVkJTnv39tt().DistanceTo(_0023_003Dzt2i9eQo_003D3._0023_003DzGzVkJTnv39tt());
				}
				else if (_0023_003Dz0ZkNffc_003D is _0023_003DzCyMkm_0024xZcX_5 _0023_003DzCyMkm_0024xZcX_6)
				{
					num = _0023_003Dzt2i9eQo_003D2._0023_003DzGzVkJTnv39tt().DistanceTo(_0023_003DzCyMkm_0024xZcX_6._0023_003DzTlWHc6c_003D());
				}
			}
			else if (_0023_003DzUBk7hDs_003D is _0023_003DzCyMkm_0024xZcX_5 _0023_003DzCyMkm_0024xZcX_7)
			{
				if (_0023_003Dz0ZkNffc_003D is _0023_003DzCyMkm_0024xZcX_5 _0023_003DzCyMkm_0024xZcX_8)
				{
					num = _0023_003DzCyMkm_0024xZcX_7._0023_003Dz6FBK7II_003D().DistanceTo(_0023_003DzCyMkm_0024xZcX_8._0023_003DzTlWHc6c_003D());
				}
				else if (_0023_003Dz0ZkNffc_003D is _0023_003Dzt2i9eQo_003D _0023_003Dzt2i9eQo_003D4)
				{
					num = _0023_003DzCyMkm_0024xZcX_7._0023_003Dz6FBK7II_003D().DistanceTo(_0023_003Dzt2i9eQo_003D4._0023_003DzGzVkJTnv39tt());
				}
			}
			if (num == -1.0)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659611));
			}
			return num;
		}
	}

	private sealed class _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc : IEnumerable<_0023_003Dz_00245gUm2U_003D>, IEnumerable, IEnumerator<_0023_003Dz_00245gUm2U_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dz_00245gUm2U_003D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzwDQzNwGdCj4a;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003Dzu94UYti1wBAM6VtSgQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzThMorOKkX_m9tBKf8w_003D_003D _0023_003DzuDwMokKAURNt;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<_0023_003Dz_00245gUm2U_003D> _0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D;

		[DebuggerHidden]
		public _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzuDwMokKAURNt = null;
			_0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D = null;
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			switch (_0023_003DzU7pGb3X7Zp4G)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D = _0023_003DzwDQzNwGdCj4a.ToList();
				_0023_003DzuDwMokKAURNt = new _0023_003DzThMorOKkX_m9tBKf8w_003D_003D();
				_0023_003DzuDwMokKAURNt._0023_003Dzwi058ac_003D = _0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D.First();
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzuDwMokKAURNt._0023_003Dzwi058ac_003D = _0023_003Dz8DZedho_003D(_0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D, _0023_003DzuDwMokKAURNt._0023_003DzBq1VsI0ETm8TrnSRccO_n3l8lKS1);
				break;
			}
			if (_0023_003DzuDwMokKAURNt._0023_003Dzwi058ac_003D != null)
			{
				_0023_003DzREr05bvpkJWjbZiEWAbxQHY_003D.Remove(_0023_003DzuDwMokKAURNt._0023_003Dzwi058ac_003D);
				_0023_003DzezVIuujSK1H9 = _0023_003DzuDwMokKAURNt._0023_003Dzwi058ac_003D;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
			_0023_003DzuDwMokKAURNt = null;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private _0023_003Dz_00245gUm2U_003D _0023_003Dz6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		_0023_003Dz_00245gUm2U_003D IEnumerator<_0023_003Dz_00245gUm2U_003D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=z6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs=
			return this._0023_003Dz6WFPLFZ3w38rlNWrWn1CWojnhbrzystIiISA2mAq2tqLUkTUdrI4irs_003D();
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
		private IEnumerator<_0023_003Dz_00245gUm2U_003D> _0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D()
		{
			_0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc2 = this;
			}
			else
			{
				_0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc2 = new _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc(0);
			}
			_0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc2._0023_003DzwDQzNwGdCj4a = _0023_003Dzu94UYti1wBAM6VtSgQ_003D_003D;
			return _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc2;
		}

		IEnumerator<_0023_003Dz_00245gUm2U_003D> IEnumerable<_0023_003Dz_00245gUm2U_003D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico$AlTYKEIOGY8=
			return this._0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzE6N_MQXdscypkFXFFWdJGXrVcvdNN3hBnI6JzSErico_0024AlTYKEIOGY8_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D<_0023_003DzWWgGxds_003D, _0023_003DzpYJWPro_003D> where _0023_003DzpYJWPro_003D : IComparable<_0023_003DzpYJWPro_003D>
	{
		public Func<_0023_003DzWWgGxds_003D, _0023_003DzpYJWPro_003D> _0023_003Dz743TWCo_003D;

		internal _0023_003DzWWgGxds_003D _0023_003DzJg4NpC8FtWZ5HCwieA_003D_003D(_0023_003DzWWgGxds_003D _0023_003DzP_THC5xsuSx2, _0023_003DzWWgGxds_003D _0023_003DzActn3gM_003D)
		{
			if (_0023_003Dz743TWCo_003D(_0023_003DzActn3gM_003D).CompareTo(_0023_003Dz743TWCo_003D(_0023_003DzP_THC5xsuSx2)) <= 0)
			{
				return _0023_003DzActn3gM_003D;
			}
			return _0023_003DzP_THC5xsuSx2;
		}
	}

	private sealed class _0023_003DzThMorOKkX_m9tBKf8w_003D_003D
	{
		public _0023_003Dz_00245gUm2U_003D _0023_003Dzwi058ac_003D;

		internal double _0023_003DzBq1VsI0ETm8TrnSRccO_n3l8lKS1(_0023_003Dz_00245gUm2U_003D _0023_003DzuwH5j5s_003D)
		{
			return _0023_003Dz_00245gUm2U_003D._0023_003DzOxKU6GM_003D(_0023_003Dzwi058ac_003D, _0023_003DzuwH5j5s_003D);
		}
	}

	private sealed class _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Point2D
	{
		public IList<IndexLine> _0023_003DzheZZscU_003D;

		public IList<_0023_003DzWWgGxds_003D> _0023_003DzrdSL0CI_003D;

		internal bool _0023_003Dzybu8YsXBZNQJhOW40A_003D_003D(_0023_003DzWWgGxds_003D _0023_003Dzx63Fsgc_003D, int _0023_003Dz437_00244ak_003D)
		{
			_0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D<_0023_003DzWWgGxds_003D> _0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D2 = new _0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D<_0023_003DzWWgGxds_003D>();
			_0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D2._0023_003Dz437_00244ak_003D = _0023_003Dz437_00244ak_003D;
			return _0023_003DzheZZscU_003D.All(_0023_003Dz_0024Hb0lbzSxtKvJc9iOAXnzy4_003D2._0023_003DzTR91eyvNBnIKOxb__Q_003D_003D);
		}

		internal _0023_003Dz_00245gUm2U_003D _0023_003DzdtO3jWyQxYSdUeEjQQ_003D_003D(_0023_003DzWWgGxds_003D _0023_003DzB68dg9Q_003D)
		{
			return new _0023_003Dz_00245gUm2U_003D(new _0023_003Dzt2i9eQo_003D(_0023_003DzB68dg9Q_003D, _0023_003DzrdSL0CI_003D.IndexOf(_0023_003DzB68dg9Q_003D)));
		}

		internal _0023_003Dz_00245gUm2U_003D _0023_003DzqrnmUMvycSuGPJufxA_003D_003D(IndexLine _0023_003Dzt_m8zV0_003D, int _0023_003Dz437_00244ak_003D)
		{
			return new _0023_003Dz_00245gUm2U_003D(new _0023_003DzCyMkm_0024xZcX_5(_0023_003DzrdSL0CI_003D[_0023_003Dzt_m8zV0_003D.V1], _0023_003DzrdSL0CI_003D[_0023_003Dzt_m8zV0_003D.V2], _0023_003Dzt_m8zV0_003D.V1, _0023_003Dzt_m8zV0_003D.V2));
		}
	}

	private sealed class _0023_003Dzt2i9eQo_003D : _0023_003DzF6l0Wio_003D
	{
		private Point2D _0023_003Dz1HAmnWRC5rCXRUB3Sw_003D_003D;

		public _0023_003Dzt2i9eQo_003D(Point2D _0023_003DzlY77YgY_003D, int _0023_003DzyzK8swU_003D)
			: base(_0023_003DzyzK8swU_003D)
		{
			_0023_003DzFzV1CHaagmwJ(_0023_003DzlY77YgY_003D);
		}

		public Point2D _0023_003DzGzVkJTnv39tt()
		{
			return _0023_003Dz1HAmnWRC5rCXRUB3Sw_003D_003D;
		}

		private void _0023_003DzFzV1CHaagmwJ(Point2D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz1HAmnWRC5rCXRUB3Sw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public override string ToString()
		{
			return _0023_003DznN5ttMs_003D.ToString();
		}
	}

	private static void _0023_003DzJKePfk0_003D(IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzwDQzNwGdCj4a, bool _0023_003DzdEvMFOw_003D)
	{
		_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D2 = null;
		_0023_003Dz_00245gUm2U_003D _0023_003Dz_00245gUm2U_003D3 = null;
		foreach (_0023_003Dz_00245gUm2U_003D item in _0023_003DzwDQzNwGdCj4a)
		{
			if (_0023_003Dz_00245gUm2U_003D3 == null)
			{
				_0023_003Dz_00245gUm2U_003D3 = item;
			}
			_0023_003Dz_00245gUm2U_003D2?._0023_003Dzhp_0024fZss_003D(item);
			_0023_003Dz_00245gUm2U_003D2 = item;
		}
		if (_0023_003DzdEvMFOw_003D)
		{
			_0023_003Dz_00245gUm2U_003D2._0023_003Dzhp_0024fZss_003D(_0023_003Dz_00245gUm2U_003D3);
		}
	}

	private static T _0023_003Dz8DZedho_003D<T, TComparable>(IEnumerable<T> _0023_003DzCnyyw88_003D, Func<T, TComparable> _0023_003Dz743TWCo_003D) where TComparable : IComparable<TComparable>
	{
		_0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D<T, TComparable> _0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D2 = new _0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D<T, TComparable>();
		_0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D2._0023_003Dz743TWCo_003D = _0023_003Dz743TWCo_003D;
		return _0023_003DzCnyyw88_003D.DefaultIfEmpty().Aggregate(_0023_003DzSf6OrOkI_0024Q_YbixrykHJQfc_003D2._0023_003DzJg4NpC8FtWZ5HCwieA_003D_003D);
	}

	[IteratorStateMachine(typeof(_0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc))]
	private static IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzyNLhSl4A17A2pnbnIQ_003D_003D(IEnumerable<_0023_003Dz_00245gUm2U_003D> _0023_003DzwDQzNwGdCj4a)
	{
		return new _0023_003DzP5nEjrqeaKbsjDCtFlyadzU025Oc(-2)
		{
			_0023_003Dzu94UYti1wBAM6VtSgQ_003D_003D = _0023_003DzwDQzNwGdCj4a
		};
	}

	public static int[] _0023_003DzboSI9t_0024bnGwt<T>(IList<T> _0023_003DzrdSL0CI_003D, IList<IndexLine> _0023_003DzheZZscU_003D, double _0023_003DzoT334mIO_GIq) where T : Point2D
	{
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<T> _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2 = new _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<T>();
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzheZZscU_003D = _0023_003DzheZZscU_003D;
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzrdSL0CI_003D = _0023_003DzrdSL0CI_003D;
		List<_0023_003Dz_00245gUm2U_003D> list = _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzrdSL0CI_003D.Where(_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003Dzybu8YsXBZNQJhOW40A_003D_003D).Select(_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzdtO3jWyQxYSdUeEjQQ_003D_003D).ToList();
		list.AddRange(_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzheZZscU_003D.Select(_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzqrnmUMvycSuGPJufxA_003D_003D));
		List<_0023_003Dz_00245gUm2U_003D> list2 = _0023_003DzyNLhSl4A17A2pnbnIQ_003D_003D(list).ToList();
		_0023_003DzJKePfk0_003D(list2, _0023_003DzdEvMFOw_003D: true);
		_0023_003Dz_0024PcG_maJxbuZ _0023_003Dz_0024PcG_maJxbuZ2 = new _0023_003Dz_0024PcG_maJxbuZ(list2);
		double num = -1.0;
		double num2 = _0023_003Dz_0024PcG_maJxbuZ2._0023_003DzbAyqU54_003D();
		while ((double)_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzrdSL0CI_003D.Count <= 150.0)
		{
			double _0023_003Dzx9mJdMs_003D;
			_0023_003Dz_0024PcG_maJxbuZ _0023_003Dz_0024PcG_maJxbuZ3 = _0023_003Dz_0024PcG_maJxbuZ2._0023_003Dz8_ZYz_0024AF6Na7(num2, out _0023_003Dzx9mJdMs_003D);
			if (_0023_003Dz_0024PcG_maJxbuZ3 == null)
			{
				break;
			}
			num = (num2 - _0023_003Dzx9mJdMs_003D) / num2 * 100.0;
			if (_0023_003Dzx9mJdMs_003D >= num2 || num <= _0023_003DzoT334mIO_GIq)
			{
				break;
			}
			_0023_003Dz_0024PcG_maJxbuZ2 = _0023_003Dz_0024PcG_maJxbuZ3;
			num2 = _0023_003Dzx9mJdMs_003D;
		}
		List<int> list3 = new List<int>(list2.Count);
		foreach (_0023_003Dz_00245gUm2U_003D item in _0023_003Dz_0024PcG_maJxbuZ2._0023_003DzMn_N27Esy8SQ()._0023_003Dzf_00244xy23jJnAF())
		{
			list3.Add(item._0023_003DzF6l0Wio_003D._0023_003DznN5ttMs_003D);
			if (item._0023_003DzF6l0Wio_003D is _0023_003DzCyMkm_0024xZcX_5 _0023_003DzCyMkm_0024xZcX_6)
			{
				list3.Add(_0023_003DzCyMkm_0024xZcX_6._0023_003Dz6ivnsYc_003D);
			}
		}
		return list3.ToArray();
	}
}
