using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class LengthConstraint : ValueConstraint
{
	private sealed class _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LengthConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(int _0023_003DzU7pGb3X7Zp4G)
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
			LengthConstraint lengthConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = lengthConstraint._0023_003Dzjrbkyo8_003D(0)._0023_003Dz2s6gjYE_003D() - lengthConstraint.value;
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
			_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2 = this;
			}
			else
			{
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2 = new _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(0);
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2;
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

	protected LengthConstraint(LengthConstraint another)
		: base(another)
	{
	}

	internal LengthConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal LengthConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzbfrNXYE_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzbfrNXYE_003D);
		_0023_003Dz_09KxNE_003D();
	}

	protected LengthConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal ExpVector _0023_003DzMz6jweqqHEoi()
	{
		return _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(0, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	internal ExpVector _0023_003DzDO1A1VPzNcGH()
	{
		return _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(1, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private ExpVector _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(int _0023_003Dz437_00244ak_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		return _0023_003Dzjrbkyo8_003D(0)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(_0023_003Dz437_00244ak_003D, _0023_003Dzrgqz890sj_0024X9);
	}

	private protected override Transformation _0023_003DzKPUxzjlpDSMi()
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003Dz7d5lgPw_003D();
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new LengthConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new LengthConstraint(this);
	}
}
