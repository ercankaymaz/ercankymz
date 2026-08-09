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
public class HVConstraint : Constraint
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
		public HVConstraint _0023_003DzopRx0_MBcTQs;

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
			HVConstraint hVConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				switch (hVConstraint.orientation)
				{
				case hvOrientation.OX:
					_0023_003DzezVIuujSK1H9 = hVConstraint._0023_003DzMz6jweqqHEoi().x - hVConstraint._0023_003DzDO1A1VPzNcGH().x;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				case hvOrientation.OY:
					_0023_003DzezVIuujSK1H9 = hVConstraint._0023_003DzMz6jweqqHEoi().y - hVConstraint._0023_003DzDO1A1VPzNcGH().y;
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				case hvOrientation.OZ:
					_0023_003DzezVIuujSK1H9 = hVConstraint._0023_003DzMz6jweqqHEoi().z - hVConstraint._0023_003DzDO1A1VPzNcGH().z;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
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

	internal hvOrientation orientation;

	public bool IsHorizontal => orientation == hvOrientation.OY;

	protected HVConstraint(HVConstraint another)
		: base(another)
	{
		orientation = another.orientation;
	}

	internal HVConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal HVConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzDVubtvo_003D, SketchCurve _0023_003DzFj_0024IqDQ_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzDVubtvo_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DzFj_0024IqDQ_003D);
	}

	internal HVConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzQ9zpGF0_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzQ9zpGF0_003D);
	}

	protected HVConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		orientation = (hvOrientation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656190), typeof(hvOrientation));
	}

	internal ExpVector _0023_003DzMz6jweqqHEoi()
	{
		return _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(0, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	internal ExpVector _0023_003DzDO1A1VPzNcGH()
	{
		return _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(1, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	internal virtual ExpVector _0023_003DzYPdsWiifM_ksD4Skhw_003D_003D(int _0023_003DzyzK8swU_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dz1uzJIBKKgWz8<SketchPoint>(2))
		{
			return _0023_003DzCobWdDk49r6E<SketchPoint>(_0023_003DzyzK8swU_003D)._0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(_0023_003Dzrgqz890sj_0024X9);
		}
		return _0023_003DzCobWdDk49r6E<SketchLine>(0)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(_0023_003DzyzK8swU_003D, _0023_003Dzrgqz890sj_0024X9);
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

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656176), orientation.ToString());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656176)].Value._0023_003DzzlWCyhw_003D(ref orientation);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new HVConstraintSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656190), orientation);
	}

	public override object Clone()
	{
		return new HVConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		return new HVConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D)
		{
			orientation = orientation
		};
	}
}
