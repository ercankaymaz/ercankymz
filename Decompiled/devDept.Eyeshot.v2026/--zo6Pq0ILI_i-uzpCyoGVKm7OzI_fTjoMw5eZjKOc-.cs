using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D : ValueConstraint
{
	private sealed class _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn(int _0023_003DzU7pGb3X7Zp4G)
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
			_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2 = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				SketchCurve sketchCurve = _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003Dzjrbkyo8_003D(0);
				SketchCurve sketchCurve2 = _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003Dzjrbkyo8_003D(1);
				Exp exp = sketchCurve._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
				Exp exp2 = sketchCurve2._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
				if (_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003DztzVH4bgcw7I_4lhmCyXZHL9o_bAi(sketchCurve, sketchCurve2))
				{
					if (_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003Dz0neAlmEyvmPj() == _0023_003DzBD2gHw0_003D.FirstInside)
					{
						_0023_003DzezVIuujSK1H9 = exp - exp2 - _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2.value._0023_003Dzuc1z_scDJBr3();
						_0023_003DzU7pGb3X7Zp4G = 1;
						return true;
					}
					_0023_003DzezVIuujSK1H9 = exp2 - exp - _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2.value._0023_003Dzuc1z_scDJBr3();
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				}
				Exp exp3 = (sketchCurve._0023_003DzvZpvBdFc_0024vJr0ob44g_003D_003D(_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - sketchCurve2._0023_003DzvZpvBdFc_0024vJr0ob44g_003D_003D(_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane))._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
				switch (_0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2._0023_003Dz0neAlmEyvmPj())
				{
				case _0023_003DzBD2gHw0_003D.Outside:
					_0023_003DzezVIuujSK1H9 = exp3 - exp - exp2 - _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2.value._0023_003Dzuc1z_scDJBr3();
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				case _0023_003DzBD2gHw0_003D.FirstInside:
					_0023_003DzezVIuujSK1H9 = exp2 - exp - exp3 - _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2.value._0023_003Dzuc1z_scDJBr3();
					_0023_003DzU7pGb3X7Zp4G = 4;
					return true;
				case _0023_003DzBD2gHw0_003D.SecondInside:
					_0023_003DzezVIuujSK1H9 = exp - exp2 - exp3 - _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D2.value._0023_003Dzuc1z_scDJBr3();
					_0023_003DzU7pGb3X7Zp4G = 5;
					return true;
				}
				break;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 4:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 5:
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
			_0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn2 = this;
			}
			else
			{
				_0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn2 = new _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn(0);
				_0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn2;
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

	internal enum _0023_003DzBD2gHw0_003D : byte
	{
		Outside = 11,
		FirstInside,
		SecondInside
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzBD2gHw0_003D _0023_003DziJ_M6HE_003D;

	internal _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal _0023_003Dzo6Pq0ILI_i_0024uzpCyoGVKm7OzI_fTjoMw5eZjKOc_003D(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzGQE5xwU_003D, SketchCurve _0023_003Dzfm4oGj8_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzGQE5xwU_003D);
		_0023_003DzRCrpdGA_003D(_0023_003Dzfm4oGj8_003D);
		value._0023_003DzO_0024HwSzQ_003D(1.0);
		_0023_003DzzzMmR6wZVKHE();
		_0023_003Dz_09KxNE_003D();
	}

	internal _0023_003DzBD2gHw0_003D _0023_003Dz0neAlmEyvmPj()
	{
		return _0023_003DziJ_M6HE_003D;
	}

	internal void _0023_003DzmJuZp_0024UcZA5h(_0023_003DzBD2gHw0_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DziJ_M6HE_003D = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	internal override Enum _0023_003DzO2eKyem9cuf9()
	{
		return _0023_003Dz0neAlmEyvmPj();
	}

	[SpecialName]
	internal override void _0023_003DzDESu9hNNQZcg(Enum _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzmJuZp_0024UcZA5h((_0023_003DzBD2gHw0_003D)(object)_0023_003DzPzO_0024GUk_003D);
	}

	private SketchPoint _0023_003DzuKkIuMJiDcmZ(SketchCurve _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzbfrNXYE_003D is SketchCircle)
		{
			return (_0023_003DzbfrNXYE_003D as SketchCircle).Center;
		}
		if (_0023_003DzbfrNXYE_003D is SketchArc)
		{
			return (_0023_003DzbfrNXYE_003D as SketchArc).Center;
		}
		return null;
	}

	private bool _0023_003DztzVH4bgcw7I_4lhmCyXZHL9o_bAi(SketchCurve _0023_003DzGQE5xwU_003D, SketchCurve _0023_003Dzfm4oGj8_003D)
	{
		SketchPoint sketchPoint = _0023_003DzuKkIuMJiDcmZ(_0023_003DzGQE5xwU_003D);
		SketchPoint sketchPoint2 = _0023_003DzuKkIuMJiDcmZ(_0023_003Dzfm4oGj8_003D);
		if (sketchPoint != null && sketchPoint2 != null)
		{
			return sketchPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchPoint2);
		}
		return false;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003Dz2BW0FX7gEr__0024APRbHcLA_0024sPJdUKn(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private protected override Transformation _0023_003DzKPUxzjlpDSMi()
	{
		SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(0);
		SketchCurve sketchCurve2 = _0023_003Dzjrbkyo8_003D(1);
		Vector3D vector3D = sketchCurve._0023_003DzvZpvBdFc_0024vJr0ob44g_003D_003D(null)._0023_003DzBUjqlpM_003D();
		Vector3D _0023_003DzooV0J_0024g_003D = sketchCurve2._0023_003DzvZpvBdFc_0024vJr0ob44g_003D_003D(null)._0023_003DzBUjqlpM_003D();
		if (_0023_003DztzVH4bgcw7I_4lhmCyXZHL9o_bAi(sketchCurve, sketchCurve2))
		{
			return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003Dz7d5lgPw_003D() * new Translation(vector3D);
		}
		return _0023_003DzfMtoRYsslA7_(vector3D, _0023_003DzooV0J_0024g_003D, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}
}
