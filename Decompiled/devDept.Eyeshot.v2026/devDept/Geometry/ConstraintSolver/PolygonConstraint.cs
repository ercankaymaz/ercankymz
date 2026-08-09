using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class PolygonConstraint : Constraint
{
	private sealed class _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public PolygonConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint[] _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzyaD0bSz_GU7YbxcqfxT4_0024G0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003Dzq3QaQ6Q2Wme48svxw1rOoTo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003DzUnP_0024QESb_00246XFkSWc7zqnuk0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzNe_0024IRCnnN3Qm;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzQoHHkb25IUQA;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz5rB_0024TTK5JohqltWG6w_003D_003D;

		[DebuggerHidden]
		public _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D = null;
			_0023_003Dzq3QaQ6Q2Wme48svxw1rOoTo_003D = null;
			_0023_003DzNe_0024IRCnnN3Qm = null;
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
			PolygonConstraint polygonConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				SketchCurve[] entities = polygonConstraint.GetEntities();
				_0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D = polygonConstraint._0023_003DzxFUvVgwzeDsGisiwHI_0024ZvwM_003D(entities, entities.Length - 1, polygonConstraint.Center);
				_0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024 = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D.Length;
				_0023_003DzyaD0bSz_GU7YbxcqfxT4_0024G0_003D = _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024 / 2;
				_0023_003DzQoHHkb25IUQA = 1;
				goto IL_0153;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA]._0023_003Dzuc1z_scDJBr3().y - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003Dz5rB_0024TTK5JohqltWG6w_003D_003D]._0023_003Dzuc1z_scDJBr3().y;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzQoHHkb25IUQA += 2;
				goto IL_0153;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzQoHHkb25IUQA += 2;
				goto IL_0206;
			case 4:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzQoHHkb25IUQA += 2;
				goto IL_02fc;
			case 5:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzNe_0024IRCnnN3Qm.y - polygonConstraint.Center.y._0023_003DzV29zQ3g_003D();
				_0023_003DzU7pGb3X7Zp4G = 6;
				return true;
			case 6:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					return false;
				}
				IL_0153:
				if (_0023_003DzQoHHkb25IUQA < _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024)
				{
					_0023_003Dz5rB_0024TTK5JohqltWG6w_003D_003D = ((_0023_003DzQoHHkb25IUQA < _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024 - 1) ? (_0023_003DzQoHHkb25IUQA + 1) : 0);
					_0023_003DzezVIuujSK1H9 = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA]._0023_003Dzuc1z_scDJBr3().x - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003Dz5rB_0024TTK5JohqltWG6w_003D_003D]._0023_003Dzuc1z_scDJBr3().x;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003Dzq3QaQ6Q2Wme48svxw1rOoTo_003D = (_0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[1]._0023_003Dzuc1z_scDJBr3() - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[0]._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
				_0023_003DzQoHHkb25IUQA = 2;
				goto IL_0206;
				IL_02fc:
				if (_0023_003DzQoHHkb25IUQA < _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024 - 2)
				{
					ExpVector _0023_003DzizVqTKE_003D = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA + 1]._0023_003Dzuc1z_scDJBr3() - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA]._0023_003Dzuc1z_scDJBr3();
					ExpVector _0023_003Dzt38nTwk_003D = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA + 3]._0023_003Dzuc1z_scDJBr3() - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA + 2]._0023_003Dzuc1z_scDJBr3();
					Exp exp = (polygonConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d ? _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003DzwnmeKH36nol2(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D) : _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc: false));
					_0023_003DzezVIuujSK1H9 = exp - _0023_003DzUnP_0024QESb_00246XFkSWc7zqnuk0_003D;
					_0023_003DzU7pGb3X7Zp4G = 4;
					return true;
				}
				_0023_003DzNe_0024IRCnnN3Qm = new ExpVector(0.0, 0.0, 0.0);
				for (int i = 0; i < _0023_003DzyaD0bSz_GU7YbxcqfxT4_0024G0_003D; i++)
				{
					SketchPoint sketchPoint = _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[2 * i];
					_0023_003DzNe_0024IRCnnN3Qm += sketchPoint._0023_003Dzuc1z_scDJBr3();
				}
				_0023_003DzNe_0024IRCnnN3Qm /= (Exp)_0023_003DzyaD0bSz_GU7YbxcqfxT4_0024G0_003D;
				_0023_003DzezVIuujSK1H9 = _0023_003DzNe_0024IRCnnN3Qm.x - polygonConstraint.Center.x._0023_003DzV29zQ3g_003D();
				_0023_003DzU7pGb3X7Zp4G = 5;
				return true;
				IL_0206:
				if (_0023_003DzQoHHkb25IUQA < _0023_003DzA8yZaWEsF5CbDpx7QGsXSJiHUGY_0024 - 4)
				{
					_0023_003DzezVIuujSK1H9 = (_0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA + 1]._0023_003Dzuc1z_scDJBr3() - _0023_003Dzmsa_nm5VYG7I2aPpWNtDvNs_003D[_0023_003DzQoHHkb25IUQA]._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - _0023_003Dzq3QaQ6Q2Wme48svxw1rOoTo_003D;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
				_0023_003DzUnP_0024QESb_00246XFkSWc7zqnuk0_003D = Math.PI * 2.0 / (double)_0023_003DzyaD0bSz_GU7YbxcqfxT4_0024G0_003D;
				_0023_003DzQoHHkb25IUQA = 0;
				goto IL_02fc;
			}
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
			_0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e2 = this;
			}
			else
			{
				_0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e2 = new _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e(0);
				_0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e2;
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

	public SketchPoint Center
	{
		get
		{
			SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(_0023_003DzpK4oXctemjLc() - 1);
			if (sketchCurve.GetType() == typeof(SketchPoint))
			{
				return (SketchPoint)sketchCurve;
			}
			Center = _0023_003DzE4mfvVc_003D(_0023_003DzxFUvVgwzeDsGisiwHI_0024ZvwM_003D(GetEntities(), _0023_003DzpK4oXctemjLc(), null));
			return Center;
		}
		set
		{
			_0023_003Dz9x52aV0_003D(_0023_003DzpK4oXctemjLc() - 1, value);
		}
	}

	internal PolygonConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal PolygonConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchLine[] _0023_003DzyIUKu5w_003D, SketchPoint _0023_003DzbUvT9Pc_003D = null)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzxFUvVgwzeDsGisiwHI_0024ZvwM_003D(_0023_003DzyIUKu5w_003D, _0023_003DzyIUKu5w_003D.Length, _0023_003DzbUvT9Pc_003D);
	}

	protected PolygonConstraint(PolygonConstraint another)
		: base(another)
	{
	}

	protected PolygonConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	private SketchPoint[] _0023_003DzxFUvVgwzeDsGisiwHI_0024ZvwM_003D(SketchCurve[] _0023_003DzyIUKu5w_003D, int _0023_003Dz7ohjoJ4EvXxL, SketchPoint _0023_003DzbUvT9Pc_003D)
	{
		SketchPoint[] array = new SketchPoint[_0023_003Dz7ohjoJ4EvXxL * 2];
		bool flag = _0023_003DzpK4oXctemjLc() == 0;
		for (int i = 0; i < _0023_003Dz7ohjoJ4EvXxL; i++)
		{
			SketchLine sketchLine = (SketchLine)_0023_003DzyIUKu5w_003D[i];
			if (flag)
			{
				_0023_003DzRCrpdGA_003D(sketchLine);
			}
			array[2 * i] = sketchLine.StartPoint;
			array[2 * i + 1] = sketchLine.EndPoint;
		}
		if (_0023_003DzbUvT9Pc_003D == null)
		{
			_0023_003DzbUvT9Pc_003D = _0023_003DzE4mfvVc_003D(array);
		}
		if (flag)
		{
			_0023_003DzRCrpdGA_003D(_0023_003DzbUvT9Pc_003D);
		}
		return array;
	}

	private SketchPoint _0023_003DzE4mfvVc_003D(SketchPoint[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		SketchPoint sketchPoint = new SketchPoint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D());
		foreach (SketchPoint sketchPoint2 in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			Param x = sketchPoint.x;
			x._0023_003DzO_0024HwSzQ_003D(x._0023_003DzV29zQ3g_003D() + sketchPoint2.x._0023_003DzV29zQ3g_003D());
			Param y = sketchPoint.y;
			y._0023_003DzO_0024HwSzQ_003D(y._0023_003DzV29zQ3g_003D() + sketchPoint2.y._0023_003DzV29zQ3g_003D());
		}
		Param x2 = sketchPoint.x;
		x2._0023_003DzO_0024HwSzQ_003D(x2._0023_003DzV29zQ3g_003D() / (double)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length);
		Param y2 = sketchPoint.y;
		y2._0023_003DzO_0024HwSzQ_003D(y2._0023_003DzV29zQ3g_003D() / (double)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length);
		return sketchPoint;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzrmEsL8gEK91SBPHQfsG0iKJclT0e(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new PolygonConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new PolygonConstraint(this);
	}
}
