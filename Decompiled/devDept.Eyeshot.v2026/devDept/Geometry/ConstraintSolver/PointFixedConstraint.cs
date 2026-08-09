using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class PointFixedConstraint : Constraint
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
		public PointFixedConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzMdd_0024ralL_0024rbmrfJeXA_003D_003D;

		[DebuggerHidden]
		public _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzMdd_0024ralL_0024rbmrfJeXA_003D_003D = null;
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
			PointFixedConstraint pointFixedConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzMdd_0024ralL_0024rbmrfJeXA_003D_003D = pointFixedConstraint._0023_003Dzjrbkyo8_003D(0)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, pointFixedConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				_0023_003DzezVIuujSK1H9 = _0023_003DzMdd_0024ralL_0024rbmrfJeXA_003D_003D.x - pointFixedConstraint.x;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzMdd_0024ralL_0024rbmrfJeXA_003D_003D.y - pointFixedConstraint.y;
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

	internal Exp x;

	internal Exp y;

	internal hvOrientation? orientation;

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

	protected PointFixedConstraint(PointFixedConstraint another)
		: base(another)
	{
		x = (Exp)another.x.Clone();
		y = (Exp)another.y.Clone();
	}

	internal PointFixedConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal PointFixedConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzDVubtvo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		x = new Exp(_0023_003DzDVubtvo_003D.x._0023_003DzV29zQ3g_003D());
		y = new Exp(_0023_003DzDVubtvo_003D.y._0023_003DzV29zQ3g_003D());
		_0023_003DzRCrpdGA_003D(_0023_003DzDVubtvo_003D);
	}

	protected PointFixedConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		x = (Exp)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817), typeof(Exp));
		y = (Exp)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525), typeof(Exp));
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

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), x.ToString());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), y.ToString());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		x = new Exp(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446)].Value._0023_003DzR61OsnE_003D());
		y = new Exp(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754)].Value._0023_003DzR61OsnE_003D());
	}

	public void UpdateCoordinate(double dx, double dy)
	{
		x = new Exp(dx);
		y = new Exp(dy);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new PointFixedConstraintSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817), x);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525), y);
	}

	public override object Clone()
	{
		return new PointFixedConstraint(this);
	}
}
