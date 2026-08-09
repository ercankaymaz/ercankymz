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
public class LinesDistanceConstraint : ValueConstraint
{
	private sealed class _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LinesDistanceConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE(int _0023_003DzU7pGb3X7Zp4G)
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
			LinesDistanceConstraint linesDistanceConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003DzRV_qN4O3vHon(linesDistanceConstraint._0023_003Dz_00245IAO5iCWYNr(), linesDistanceConstraint._0023_003DzXPDMwqohrEGJ9mm4Dg_003D_003D(), linesDistanceConstraint._0023_003DzmmsOqNu9Dr3JP3Rq9A_003D_003D(), linesDistanceConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d) - linesDistanceConstraint.value._0023_003Dzuc1z_scDJBr3();
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
			_0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE2 = this;
			}
			else
			{
				_0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE2 = new _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE(0);
				_0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE2;
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

	private option option_;

	internal hvOrientation? orientation;

	public SketchCurve FirstLine
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

	public SketchCurve SecondLine
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

	internal LinesDistanceConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	protected LinesDistanceConstraint(LinesDistanceConstraint another)
		: base(another)
	{
	}

	internal LinesDistanceConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzEIpBwhg_003D, SketchCurve _0023_003DziMjqlCo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzEIpBwhg_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DziMjqlCo_003D);
		_0023_003DzzzMmR6wZVKHE();
		_0023_003Dz_09KxNE_003D();
	}

	protected LinesDistanceConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal option _0023_003Dz0neAlmEyvmPj()
	{
		return option_;
	}

	internal void _0023_003DzmJuZp_0024UcZA5h(option _0023_003DzPzO_0024GUk_003D)
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
		_0023_003DzmJuZp_0024UcZA5h((option)(object)_0023_003DzPzO_0024GUk_003D);
	}

	internal ExpVector _0023_003Dz_00245IAO5iCWYNr()
	{
		return FirstLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane).ToArray()[0];
	}

	internal ExpVector _0023_003DzXPDMwqohrEGJ9mm4Dg_003D_003D()
	{
		return SecondLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane).ToArray()[0];
	}

	internal ExpVector _0023_003DzmmsOqNu9Dr3JP3Rq9A_003D_003D()
	{
		return SecondLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane).ToArray()[1];
	}

	private Vector3D _0023_003DzhEcJiupHflwE()
	{
		return FirstLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(null).ToArray()[0]._0023_003DzBUjqlpM_003D();
	}

	private Vector3D _0023_003DzqKkY_0024x43Pqv2cc2ZvQ_003D_003D()
	{
		return SecondLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(null).ToArray()[0]._0023_003DzBUjqlpM_003D();
	}

	private Vector3D _0023_003Dzx_y_rZCuQE2IFiMO5A_003D_003D()
	{
		return SecondLine._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(null).ToArray()[1]._0023_003DzBUjqlpM_003D();
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzFWfWPUumfMIx_yDPcU1h3hiojMcE(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private protected override Transformation _0023_003DzKPUxzjlpDSMi()
	{
		Vector3D _0023_003Dzop_0024it39_ZL_0024_ = _0023_003DzqKkY_0024x43Pqv2cc2ZvQ_003D_003D();
		Vector3D _0023_003DzrKXgunQO4p3G = _0023_003Dzx_y_rZCuQE2IFiMO5A_003D_003D();
		Vector3D _0023_003DzR6UMaNQ_003D = _0023_003DzhEcJiupHflwE();
		return _0023_003Dzw_0024BlG4ni0FuJ8eKFhw_003D_003D(_0023_003Dzop_0024it39_ZL_0024_, _0023_003DzrKXgunQO4p3G, _0023_003DzR6UMaNQ_003D, _0023_003DzNY5YUv279_SW());
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new LinesDistanceConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new LinesDistanceConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		return new LinesDistanceConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D);
	}
}
