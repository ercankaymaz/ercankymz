using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class TangentConstraint : Constraint
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Exp, double> _0023_003DzctmtDKLXaeFxoDNAVA_003D_003D;

		internal double _0023_003Dzgs3wsXGY_HFtOXf_00245w_003D_003D(Exp _0023_003DzbfrNXYE_003D)
		{
			return Math.Abs(_0023_003DzbfrNXYE_003D._0023_003DzBUjqlpM_003D());
		}
	}

	private sealed class _0023_003DzWSASDjXv103zaevwCQ_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TangentConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzWSASDjXv103zaevwCQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
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
			TangentConstraint tangentConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				double _0023_003DznRQNINw_003D = 0.0;
				double _0023_003DzzfwCHI0_003D = 0.0;
				Exp _0023_003Dzt_m8zV0_003D = null;
				Param _0023_003DzB68dg9Q_003D = null;
				if (!tangentConstraint._0023_003Dz5rJkJRGabEkw_nkThw_003D_003D(ref _0023_003DznRQNINw_003D, ref _0023_003DzzfwCHI0_003D, ref _0023_003Dzt_m8zV0_003D, ref _0023_003DzB68dg9Q_003D))
				{
					_0023_003DzezVIuujSK1H9 = tangentConstraint.t0;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				if (_0023_003DzB68dg9Q_003D != null)
				{
					_0023_003DzezVIuujSK1H9 = _0023_003DzB68dg9Q_003D;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
				break;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (!(tangentConstraint._0023_003Dzjrbkyo8_003D(0) is SketchLine) || !(tangentConstraint._0023_003Dzjrbkyo8_003D(1) is SketchLine))
				{
					_0023_003DzezVIuujSK1H9 = tangentConstraint.t1;
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				}
				break;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private Param _0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Param IEnumerator<Param>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcbi5nOQLxptNo77Yg$Jc8aWyZ$460IrsvT18voWlqLZB4j6K0Q==
			return this._0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D();
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
		private IEnumerator<Param> _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D()
		{
			_0023_003DzWSASDjXv103zaevwCQ_003D_003D _0023_003DzWSASDjXv103zaevwCQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzWSASDjXv103zaevwCQ_003D_003D2 = this;
			}
			else
			{
				_0023_003DzWSASDjXv103zaevwCQ_003D_003D2 = new _0023_003DzWSASDjXv103zaevwCQ_003D_003D(0);
				_0023_003DzWSASDjXv103zaevwCQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzWSASDjXv103zaevwCQ_003D_003D2;
		}

		IEnumerator<Param> IEnumerable<Param>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxNlvRhfIQy$WVUDjMQaY8aVUHXYxmRLXzqjrr$kou4GwVwkDgQ==
			return this._0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9 : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TangentConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchCurve _0023_003DzlQDp342y1Cekf54k3g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchCurve _0023_003DzOp_glCyQo56zW_nofw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzPbYJcAsFldmSRABP2A_003D_003D;

		[DebuggerHidden]
		public _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzlQDp342y1Cekf54k3g_003D_003D = null;
			_0023_003DzOp_glCyQo56zW_nofw_003D_003D = null;
			_0023_003DzPbYJcAsFldmSRABP2A_003D_003D = null;
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
			TangentConstraint tangentConstraint = _0023_003DzopRx0_MBcTQs;
			double _0023_003DznRQNINw_003D;
			double _0023_003DzzfwCHI0_003D;
			Exp _0023_003Dzt_m8zV0_003D;
			Param _0023_003DzB68dg9Q_003D;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzlQDp342y1Cekf54k3g_003D_003D = tangentConstraint._0023_003Dzjrbkyo8_003D(0);
				_0023_003DzOp_glCyQo56zW_nofw_003D_003D = tangentConstraint._0023_003Dzjrbkyo8_003D(1);
				ExpVector _0023_003DzCJkr8nY_003D = _0023_003DzlQDp342y1Cekf54k3g_003D_003D._0023_003DznwYbRgIzSbCB(tangentConstraint.t0);
				ExpVector _0023_003DzCJkr8nY_003D2 = _0023_003DzOp_glCyQo56zW_nofw_003D_003D._0023_003DznwYbRgIzSbCB(tangentConstraint.t1);
				_0023_003DzCJkr8nY_003D = _0023_003DzlQDp342y1Cekf54k3g_003D_003D._0023_003Dz_0024B4JBsGot9sy()._0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(_0023_003DzCJkr8nY_003D);
				_0023_003DzCJkr8nY_003D = tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(_0023_003DzCJkr8nY_003D);
				_0023_003DzCJkr8nY_003D2 = _0023_003DzOp_glCyQo56zW_nofw_003D_003D._0023_003Dz_0024B4JBsGot9sy()._0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(_0023_003DzCJkr8nY_003D2);
				_0023_003DzCJkr8nY_003D2 = tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(_0023_003DzCJkr8nY_003D2);
				if (tangentConstraint.addAngle)
				{
					Exp _0023_003DzBJFJHwk_003D = (tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d ? _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003DzwnmeKH36nol2(_0023_003DzCJkr8nY_003D, _0023_003DzCJkr8nY_003D2) : _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzCJkr8nY_003D, _0023_003DzCJkr8nY_003D2, _0023_003DzYRitoXujv8Dc: false));
					switch (tangentConstraint._0023_003Dz0neAlmEyvmPj())
					{
					case Option.Codirected:
						_0023_003DzezVIuujSK1H9 = _0023_003DzBJFJHwk_003D;
						_0023_003DzU7pGb3X7Zp4G = 1;
						return true;
					case Option.Antidirected:
						_0023_003DzezVIuujSK1H9 = Exp._0023_003Dz0v89Hn0_003D(_0023_003DzBJFJHwk_003D) - Math.PI;
						_0023_003DzU7pGb3X7Zp4G = 2;
						return true;
					}
				}
				goto IL_014d;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_014d;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_014d;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 4:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzPbYJcAsFldmSRABP2A_003D_003D.y;
				_0023_003DzU7pGb3X7Zp4G = 5;
				return true;
			case 5:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d)
				{
					_0023_003DzezVIuujSK1H9 = _0023_003DzPbYJcAsFldmSRABP2A_003D_003D.z;
					_0023_003DzU7pGb3X7Zp4G = 6;
					return true;
				}
				goto IL_0278;
			case 6:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					goto IL_0278;
				}
				IL_014d:
				_0023_003DznRQNINw_003D = tangentConstraint.t0._0023_003DzV29zQ3g_003D();
				_0023_003DzzfwCHI0_003D = tangentConstraint.t1._0023_003DzV29zQ3g_003D();
				_0023_003Dzt_m8zV0_003D = null;
				_0023_003DzB68dg9Q_003D = null;
				if (tangentConstraint._0023_003Dz5rJkJRGabEkw_nkThw_003D_003D(ref _0023_003DznRQNINw_003D, ref _0023_003DzzfwCHI0_003D, ref _0023_003Dzt_m8zV0_003D, ref _0023_003DzB68dg9Q_003D))
				{
					tangentConstraint.t0._0023_003DzO_0024HwSzQ_003D(_0023_003DznRQNINw_003D);
					tangentConstraint.t1._0023_003DzO_0024HwSzQ_003D(_0023_003DzzfwCHI0_003D);
					if (_0023_003Dzt_m8zV0_003D != null)
					{
						_0023_003DzezVIuujSK1H9 = _0023_003Dzt_m8zV0_003D;
						_0023_003DzU7pGb3X7Zp4G = 3;
						return true;
					}
					break;
				}
				_0023_003DzPbYJcAsFldmSRABP2A_003D_003D = _0023_003DzOp_glCyQo56zW_nofw_003D_003D._0023_003DzHay5oSnsOrhEx1IRfA_003D_003D(tangentConstraint.t1, tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003DzlQDp342y1Cekf54k3g_003D_003D._0023_003DzHay5oSnsOrhEx1IRfA_003D_003D(tangentConstraint.t0, tangentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzezVIuujSK1H9 = _0023_003DzPbYJcAsFldmSRABP2A_003D_003D.x;
				_0023_003DzU7pGb3X7Zp4G = 4;
				return true;
				IL_0278:
				_0023_003DzPbYJcAsFldmSRABP2A_003D_003D = null;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private Exp _0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Exp IEnumerator<Exp>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg==
			return this._0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D();
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
		private IEnumerator<Exp> _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D()
		{
			_0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9 _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH10;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH10 = this;
			}
			else
			{
				_0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH10 = new _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9(0);
				_0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH10._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH10;
		}

		IEnumerator<Exp> IEnumerable<Exp>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv$MbIdl_IomwTLQ==
			return this._0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	internal enum Option : byte
	{
		Codirected,
		Antidirected
	}

	private Option option_;

	internal Param t0 = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657226));

	internal Param t1 = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657201));

	private bool addAngle = true;

	public double FirstParam => t0._0023_003DzV29zQ3g_003D();

	public double SecondParam => t1._0023_003DzV29zQ3g_003D();

	protected TangentConstraint(TangentConstraint another)
		: base(another)
	{
		t0 = another.t0._0023_003DzqZwFarHnpOoH();
		t1 = another.t1._0023_003DzqZwFarHnpOoH();
		_0023_003DzmJuZp_0024UcZA5h(another._0023_003Dz0neAlmEyvmPj());
	}

	internal TangentConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal TangentConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzEIpBwhg_003D, SketchCurve _0023_003DziMjqlCo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzEIpBwhg_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DziMjqlCo_003D);
		_0023_003Dz_09KxNE_003D();
		_0023_003DzzzMmR6wZVKHE();
	}

	protected TangentConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		t0 = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657226), typeof(Param));
		t1 = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657201), typeof(Param));
		_0023_003DzmJuZp_0024UcZA5h((Option)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656850), typeof(Option)));
	}

	internal Option _0023_003Dz0neAlmEyvmPj()
	{
		return option_;
	}

	internal void _0023_003DzmJuZp_0024UcZA5h(Option _0023_003DzPzO_0024GUk_003D)
	{
		option_ = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	internal override Enum _0023_003DzO2eKyem9cuf9()
	{
		return _0023_003Dz0neAlmEyvmPj();
	}

	[SpecialName]
	internal override void _0023_003DzDESu9hNNQZcg(Enum _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzmJuZp_0024UcZA5h((Option)(object)_0023_003DzPzO_0024GUk_003D);
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzWSASDjXv103zaevwCQ_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzWSASDjXv103zaevwCQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		return new TangentConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D);
	}

	public void GetTangentParameters(out double s0, out double s1)
	{
		s0 = t0._0023_003Dzuc1z_scDJBr3()._0023_003DzBUjqlpM_003D();
		s1 = t1._0023_003Dzuc1z_scDJBr3()._0023_003DzBUjqlpM_003D();
	}

	private bool _0023_003Dz_09KxNE_003D()
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzIAHusRU_003D(_0023_003DzGVWngirLnmOL());
		addAngle = false;
		List<Exp> source = _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D().ToList();
		addAngle = true;
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(_0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
		double _0023_003DzPzO_0024GUk_003D = 0.0;
		double _0023_003DzPzO_0024GUk_003D2 = 0.0;
		double num = -1.0;
		for (double num2 = 0.0; num2 < 1.0; num2 += 0.125)
		{
			for (double num3 = 0.0; num3 < 1.0; num3 += 0.125)
			{
				t0._0023_003DzO_0024HwSzQ_003D(num2);
				t1._0023_003DzO_0024HwSzQ_003D(num3);
				_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
				double num4 = source.Sum((Exp _0023_003DzbfrNXYE_003D) => Math.Abs(_0023_003DzbfrNXYE_003D._0023_003DzBUjqlpM_003D()));
				if (!(num >= 0.0) || !(num < num4))
				{
					_0023_003DzPzO_0024GUk_003D = t0._0023_003DzV29zQ3g_003D();
					_0023_003DzPzO_0024GUk_003D2 = t1._0023_003DzV29zQ3g_003D();
					num = num4;
				}
			}
		}
		t0._0023_003DzO_0024HwSzQ_003D(_0023_003DzPzO_0024GUk_003D);
		t1._0023_003DzO_0024HwSzQ_003D(_0023_003DzPzO_0024GUk_003D2);
		return true;
	}

	private bool _0023_003Dz5rJkJRGabEkw_nkThw_003D_003D(ref double _0023_003DznRQNINw_003D, ref double _0023_003DzzfwCHI0_003D, ref Exp _0023_003Dzt_m8zV0_003D, ref Param _0023_003DzB68dg9Q_003D)
	{
		SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(0);
		SketchCurve sketchCurve2 = _0023_003Dzjrbkyo8_003D(1);
		ISketchCurve sketchCurve3 = sketchCurve as ISketchCurve;
		ISketchCurve sketchCurve4 = sketchCurve2 as ISketchCurve;
		if (sketchCurve3 != null && sketchCurve4 != null)
		{
			if (sketchCurve3.StartPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchCurve4.StartPoint))
			{
				_0023_003DznRQNINw_003D = 0.0;
				_0023_003DzzfwCHI0_003D = 0.0;
				return true;
			}
			if (sketchCurve3.StartPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchCurve4.EndPoint))
			{
				_0023_003DznRQNINw_003D = 0.0;
				_0023_003DzzfwCHI0_003D = 1.0;
				return true;
			}
			if (sketchCurve3.EndPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchCurve4.StartPoint))
			{
				_0023_003DznRQNINw_003D = 1.0;
				_0023_003DzzfwCHI0_003D = 0.0;
				return true;
			}
			if (sketchCurve3.EndPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchCurve4.EndPoint))
			{
				_0023_003DznRQNINw_003D = 1.0;
				_0023_003DzzfwCHI0_003D = 1.0;
				return true;
			}
		}
		if (sketchCurve3 != null)
		{
			PointOnConstraint _0023_003DzT5pbgeuUHI_Z = null;
			if (sketchCurve3.StartPoint._0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(sketchCurve2, ref _0023_003DzT5pbgeuUHI_Z))
			{
				_0023_003DznRQNINw_003D = 0.0;
				_0023_003DzB68dg9Q_003D = t1;
				_0023_003Dzt_m8zV0_003D = new Exp(t1) - _0023_003DzT5pbgeuUHI_Z._0023_003Dzl9_0024CU_0024ixjyyw();
				return true;
			}
			if (sketchCurve3.EndPoint._0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(sketchCurve2, ref _0023_003DzT5pbgeuUHI_Z))
			{
				_0023_003DznRQNINw_003D = 1.0;
				_0023_003DzB68dg9Q_003D = t1;
				_0023_003Dzt_m8zV0_003D = new Exp(t1) - _0023_003DzT5pbgeuUHI_Z._0023_003Dzl9_0024CU_0024ixjyyw();
				return true;
			}
		}
		if (sketchCurve4 != null)
		{
			PointOnConstraint _0023_003DzT5pbgeuUHI_Z2 = null;
			if (sketchCurve4.StartPoint._0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(sketchCurve, ref _0023_003DzT5pbgeuUHI_Z2))
			{
				_0023_003DzB68dg9Q_003D = t0;
				_0023_003Dzt_m8zV0_003D = new Exp(t0) - _0023_003DzT5pbgeuUHI_Z2._0023_003Dzl9_0024CU_0024ixjyyw();
				_0023_003DzzfwCHI0_003D = 0.0;
				return true;
			}
			if (sketchCurve4.EndPoint._0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(sketchCurve, ref _0023_003DzT5pbgeuUHI_Z2))
			{
				_0023_003DzB68dg9Q_003D = t0;
				_0023_003Dzt_m8zV0_003D = new Exp(t0) - _0023_003DzT5pbgeuUHI_Z2._0023_003Dzl9_0024CU_0024ixjyyw();
				_0023_003DzzfwCHI0_003D = 1.0;
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DznwrLHiN7IqOKBWcwADpMpdYAxXH9(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private protected virtual bool _0023_003DzX91pvtI_003D()
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D obj = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		obj._0023_003DzFZC8G3iHtBMiEUB3b_0024Ox7_0024E_003D = false;
		obj._0023_003Dz2AL_0024zf8_003D(t0);
		obj._0023_003Dz2AL_0024zf8_003D(t1);
		obj._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(_0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
		return obj._0023_003DzOykoXtw_003D() == solveFailureType.Success;
	}

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657226), t0._0023_003DzV29zQ3g_003D()._0023_003Dz1eU15ZU_003D());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657201), t1._0023_003DzV29zQ3g_003D()._0023_003Dz1eU15ZU_003D());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		t0._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657226)].Value._0023_003DzR61OsnE_003D());
		t1._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657201)].Value._0023_003DzR61OsnE_003D());
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new TangentConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new TangentConstraint(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657226), t0);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657201), t1);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656850), _0023_003Dz0neAlmEyvmPj());
	}
}
