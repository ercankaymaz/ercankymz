using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class CollinearPointsConstraint : HVConstraint
{
	private sealed class _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public CollinearPointsConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe(int _0023_003DzU7pGb3X7Zp4G)
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
			CollinearPointsConstraint collinearPointsConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				ExpVector expVector = collinearPointsConstraint._0023_003DzNY5YUv279_SW()._0023_003DzKyvCwHrKUJHX(collinearPointsConstraint._0023_003DzMz6jweqqHEoi());
				ExpVector expVector2 = collinearPointsConstraint._0023_003DzNY5YUv279_SW()._0023_003DzKyvCwHrKUJHX(collinearPointsConstraint._0023_003DzDO1A1VPzNcGH());
				ExpVector expVector3 = collinearPointsConstraint._0023_003DzNY5YUv279_SW()._0023_003DzKyvCwHrKUJHX(collinearPointsConstraint._0023_003DzjxGZK3i_0024RZ8l());
				_0023_003DzezVIuujSK1H9 = Exp._0023_003DzmSWwcFA_003D(expVector2.x - expVector.x, expVector2.y - expVector.y) - Exp._0023_003DzmSWwcFA_003D(expVector3.x - expVector2.x, expVector3.y - expVector2.y);
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
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
			_0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe2 = this;
			}
			else
			{
				_0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe2 = new _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe(0);
				_0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe2;
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

	internal CollinearPointsConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal CollinearPointsConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzDVubtvo_003D, SketchCurve _0023_003DzFj_0024IqDQ_003D, SketchCurve _0023_003DzjdeMMkk_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzDVubtvo_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzFj_0024IqDQ_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzjdeMMkk_003D);
	}

	protected CollinearPointsConstraint(CollinearPointsConstraint another)
		: base(another)
	{
	}

	protected CollinearPointsConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal ExpVector _0023_003DzjxGZK3i_0024RZ8l()
	{
		return _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(2, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzAzxlKv8szI0QFvKly_DWy6jObsXe(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override ExpVector _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(int _0023_003DzyzK8swU_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		return _0023_003DzCobWdDk49r6E<SketchPoint>(_0023_003DzyzK8swU_003D)._0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(_0023_003Dzrgqz890sj_0024X9);
	}

	public override object Clone()
	{
		return new CollinearPointsConstraint(this);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new CollinearPointsConstraintSurrogate(this);
	}
}
