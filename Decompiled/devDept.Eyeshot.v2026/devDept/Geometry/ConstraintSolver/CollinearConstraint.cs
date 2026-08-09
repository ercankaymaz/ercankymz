using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class CollinearConstraint : Constraint
{
	private sealed class _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public CollinearConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzwwPa75rl1gGj4A6Xuw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzQIwwLyJZ8NOLQ1TlBg_003D_003D;

		[DebuggerHidden]
		public _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzwwPa75rl1gGj4A6Xuw_003D_003D = null;
			_0023_003DzQIwwLyJZ8NOLQ1TlBg_003D_003D = null;
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
			CollinearConstraint collinearConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				SketchCurve _0023_003Dz8fpRyMu9aKjE = collinearConstraint._0023_003DzCobWdDk49r6E<SketchLine>(0);
				SketchCurve _0023_003Dz8fpRyMu9aKjE2 = collinearConstraint._0023_003DzCobWdDk49r6E<SketchLine>(1);
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzwwPa75rl1gGj4A6Xuw_003D_003D = _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzQIwwLyJZ8NOLQ1TlBg_003D_003D = _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane) - _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, collinearConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzezVIuujSK1H9 = ExpVector._0023_003DzyJipUOg_003D(_0023_003DzjbqS1qE_003D, _0023_003DzwwPa75rl1gGj4A6Xuw_003D_003D).z;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = ExpVector._0023_003DzyJipUOg_003D(_0023_003DzwwPa75rl1gGj4A6Xuw_003D_003D, _0023_003DzQIwwLyJZ8NOLQ1TlBg_003D_003D).z;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
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
			_0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P2 = this;
			}
			else
			{
				_0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P2 = new _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P(0);
				_0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P2;
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

	protected CollinearConstraint(CollinearConstraint another)
		: base(another)
	{
	}

	internal CollinearConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal CollinearConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzQvaHyao_003D, SketchCurve _0023_003DzNyidyKE_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzQvaHyao_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzNyidyKE_003D);
	}

	protected CollinearConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzZtjHekZHLSz3w1r9KHvo2wPThz6P(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new CollinearConstraintSurrogate(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D)
	{
		return new CollinearConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D);
	}

	public override object Clone()
	{
		return new CollinearConstraint(this);
	}
}
