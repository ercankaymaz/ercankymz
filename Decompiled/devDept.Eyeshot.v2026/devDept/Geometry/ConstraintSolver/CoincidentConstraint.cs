using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class CoincidentConstraint : Constraint
{
	private sealed class _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7 : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public CoincidentConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D;

		[DebuggerHidden]
		public _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D = null;
			_0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D = null;
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
			CoincidentConstraint coincidentConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D = coincidentConstraint.FirstPoint._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, coincidentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D = coincidentConstraint.SecondPoint._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, coincidentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzezVIuujSK1H9 = _0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D.x - _0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D.x;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D.y - _0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D.y;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (coincidentConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d)
				{
					_0023_003DzezVIuujSK1H9 = _0023_003DzjwblsqHcC9I_0024MPqzsA_003D_003D.z - _0023_003DzsjUuhs8Vfzv9HZNTNA_003D_003D.z;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
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
			_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7 _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8 = this;
			}
			else
			{
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8 = new _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(0);
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8;
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

	public SketchPoint FirstPoint
	{
		get
		{
			return (SketchPoint)_0023_003Dzjrbkyo8_003D(0);
		}
		set
		{
			_0023_003Dz9x52aV0_003D(0, value);
		}
	}

	public SketchPoint SecondPoint
	{
		get
		{
			return (SketchPoint)_0023_003Dzjrbkyo8_003D(1);
		}
		set
		{
			_0023_003Dz9x52aV0_003D(1, value);
		}
	}

	protected CoincidentConstraint(CoincidentConstraint another)
		: base(another)
	{
	}

	internal CoincidentConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal CoincidentConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzDVubtvo_003D, SketchCurve _0023_003DzFj_0024IqDQ_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzDVubtvo_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzFj_0024IqDQ_003D);
	}

	protected CoincidentConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal SketchCurve _0023_003DzQZBvZdCfU5am(SketchCurve _0023_003DzB68dg9Q_003D)
	{
		if (FirstPoint == _0023_003DzB68dg9Q_003D)
		{
			return SecondPoint;
		}
		return FirstPoint;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new CoincidentConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new CoincidentConstraint(this);
	}
}
