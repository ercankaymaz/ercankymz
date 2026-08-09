using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class PointOnConstraint : ValueConstraint
{
	private sealed class _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7 : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public PointOnConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D;

		[DebuggerHidden]
		public _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D = null;
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
			PointOnConstraint pointOnConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				ExpVector expVector = pointOnConstraint._0023_003DzSWo2AzPwT9_B();
				_0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D = pointOnConstraint.Curve._0023_003DzHay5oSnsOrhEx1IRfA_003D_003D(pointOnConstraint.value, pointOnConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - expVector;
				_0023_003DzezVIuujSK1H9 = _0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D.x;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D.y;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (pointOnConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d)
				{
					_0023_003DzezVIuujSK1H9 = _0023_003Dz09H2SD8YkOlKfgoM1w_003D_003D.z;
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
			_0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7 _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu8;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu8 = this;
			}
			else
			{
				_0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu8 = new _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7(0);
				_0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu8._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu8;
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

	public SketchCurve Point
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

	public SketchCurve Curve
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

	public override bool Reference
	{
		get
		{
			return true;
		}
		set
		{
			base.Reference = true;
		}
	}

	protected PointOnConstraint(PointOnConstraint another)
		: base(another)
	{
	}

	internal PointOnConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_selectByRefPoints = true;
	}

	internal PointOnConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzlY77YgY_003D, SketchCurve _0023_003DzdbWJotE_003D, bool _0023_003DzYWqyvPg_003D = true)
		: base(_0023_003DzjCETKTg_003D)
	{
		Reference = _0023_003DzYWqyvPg_003D;
		_0023_003DzRCrpdGA_003D(_0023_003DzlY77YgY_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzdbWJotE_003D);
		SetValue(0.5);
		_0023_003Dz_09KxNE_003D();
		_selectByRefPoints = true;
	}

	protected PointOnConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal ExpVector _0023_003DzSWo2AzPwT9_B()
	{
		return Point._0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	private Vector3D _0023_003DzhEcJiupHflwE()
	{
		return Point._0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(null)._0023_003DzBUjqlpM_003D();
	}

	[SpecialName]
	internal override bool _0023_003DzJ9zJNpOhSoUG()
	{
		return !Reference;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzQVSiyU2Qi1AFLQAg6ntM8Dbnruu7(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private protected override Transformation _0023_003DzKPUxzjlpDSMi()
	{
		Vector3D vector3D = Point._0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane)._0023_003DzBUjqlpM_003D();
		if (!_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d)
		{
			vector3D.Z = 0.0;
		}
		return _0023_003DzNY5YUv279_SW()._0023_003Dz7d5lgPw_003D() * new Translation(vector3D);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new PointOnConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new PointOnConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		SketchPoint _0023_003DzlY77YgY_003D;
		SketchCurve _0023_003DzdbWJotE_003D;
		if (_0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D is SketchPoint)
		{
			_0023_003DzlY77YgY_003D = _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D as SketchPoint;
			_0023_003DzdbWJotE_003D = _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D;
		}
		else
		{
			_0023_003DzlY77YgY_003D = _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D as SketchPoint;
			_0023_003DzdbWJotE_003D = _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D;
		}
		return new PointOnConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003DzlY77YgY_003D, _0023_003DzdbWJotE_003D);
	}
}
