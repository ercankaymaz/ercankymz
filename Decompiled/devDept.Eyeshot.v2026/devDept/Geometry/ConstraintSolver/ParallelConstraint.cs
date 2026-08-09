using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class ParallelConstraint : Constraint
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
		public ParallelConstraint _0023_003DzopRx0_MBcTQs;

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
			ParallelConstraint parallelConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				SketchCurve _0023_003Dz8fpRyMu9aKjE = parallelConstraint._0023_003DzCobWdDk49r6E<SketchLine>(0);
				SketchCurve _0023_003Dz8fpRyMu9aKjE2 = parallelConstraint._0023_003DzCobWdDk49r6E<SketchLine>(1);
				ExpVector _0023_003DzizVqTKE_003D = _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, parallelConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, parallelConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				ExpVector _0023_003Dzt38nTwk_003D = _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, parallelConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, parallelConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				Exp _0023_003DzBJFJHwk_003D = (parallelConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d ? _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003DzwnmeKH36nol2(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D) : _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc: false));
				switch (parallelConstraint._0023_003Dz0neAlmEyvmPj())
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
				break;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 2:
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

	internal enum Option
	{
		Codirected,
		Antidirected
	}

	private Option option_;

	protected ParallelConstraint(ParallelConstraint another)
		: base(another)
	{
		_0023_003DzmJuZp_0024UcZA5h(another._0023_003Dz0neAlmEyvmPj());
	}

	internal ParallelConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal ParallelConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzEIpBwhg_003D, SketchCurve _0023_003DziMjqlCo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzEIpBwhg_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DziMjqlCo_003D);
		_0023_003DzzzMmR6wZVKHE();
	}

	protected ParallelConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
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

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		return new ParallelConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D);
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

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new ParallelConstraintSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656850), _0023_003Dz0neAlmEyvmPj());
	}

	public override object Clone()
	{
		return new ParallelConstraint(this);
	}
}
