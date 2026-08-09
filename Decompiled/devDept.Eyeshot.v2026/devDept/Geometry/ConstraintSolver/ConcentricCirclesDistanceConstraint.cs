using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class ConcentricCirclesDistanceConstraint : ValueConstraint
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
		public ConcentricCirclesDistanceConstraint _0023_003DzopRx0_MBcTQs;

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
			ConcentricCirclesDistanceConstraint concentricCirclesDistanceConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = concentricCirclesDistanceConstraint.FirstCircle._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D() - concentricCirclesDistanceConstraint.SecondCircle._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D() - concentricCirclesDistanceConstraint.value;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				return false;
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

	internal hvOrientation? orientation;

	public SketchCurve FirstCircle
	{
		get
		{
			return _0023_003Dzjrbkyo8_003D(0);
		}
		set
		{
			_0023_003Dz9x52aV0_003D(0, value);
		}
	}

	public SketchCurve SecondCircle
	{
		get
		{
			return _0023_003Dzjrbkyo8_003D(1);
		}
		set
		{
			_0023_003Dz9x52aV0_003D(1, value);
		}
	}

	internal ConcentricCirclesDistanceConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	protected ConcentricCirclesDistanceConstraint(ConcentricCirclesDistanceConstraint another)
		: base(another)
	{
	}

	internal ConcentricCirclesDistanceConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzEIpBwhg_003D, SketchCurve _0023_003DziMjqlCo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzEIpBwhg_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DziMjqlCo_003D);
		_0023_003Dz_09KxNE_003D();
	}

	protected ConcentricCirclesDistanceConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal ExpVector _0023_003Dz_00245IAO5iCWYNr()
	{
		return FirstCircle._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane).ToArray()[0];
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

	public override object Clone()
	{
		return new ConcentricCirclesDistanceConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		return new ConcentricCirclesDistanceConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new ConcentricCirclesDistanceConstraintSurrogate(this);
	}
}
