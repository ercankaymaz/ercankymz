using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class SketchCircle : SketchCurve
{
	private sealed class _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchCircle _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchCircle sketchCircle = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchCircle.radius;
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
		private Param _0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Param IEnumerator<Param>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcbi5nOQLxptNo77Yg$Jc8aWyZ$460IrsvT18voWlqLZB4j6K0Q==
			return this._0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D();
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
		private IEnumerator<Param> _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D()
		{
			_0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D2 = this;
			}
			else
			{
				_0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D2 = new _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D(0);
				_0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D2;
		}

		IEnumerator<Param> IEnumerable<Param>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxNlvRhfIQy$WVUDjMQaY8aVUHXYxmRLXzqjrr$kou4GwVwkDgQ==
			return this._0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003DzK56eBig1iCdElMJTCQ_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchCircle _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzK56eBig1iCdElMJTCQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchCircle sketchCircle = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchCircle.c;
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
		private SketchPoint _0023_003DzQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		SketchPoint IEnumerator<SketchPoint>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw
			return this._0023_003DzQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw();
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
		private IEnumerator<SketchPoint> _0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs()
		{
			_0023_003DzK56eBig1iCdElMJTCQ_003D_003D _0023_003DzK56eBig1iCdElMJTCQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzK56eBig1iCdElMJTCQ_003D_003D2 = this;
			}
			else
			{
				_0023_003DzK56eBig1iCdElMJTCQ_003D_003D2 = new _0023_003DzK56eBig1iCdElMJTCQ_003D_003D(0);
				_0023_003DzK56eBig1iCdElMJTCQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzK56eBig1iCdElMJTCQ_003D_003D2;
		}

		IEnumerator<SketchPoint> IEnumerable<SketchPoint>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu$6dMK5KWTFCGpitTsTGs
			return this._0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	internal SketchPoint c;

	internal Param radius = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954668));

	public virtual double Radius
	{
		get
		{
			return radius._0023_003DzV29zQ3g_003D();
		}
		set
		{
			radius._0023_003DzO_0024HwSzQ_003D(value);
		}
	}

	public SketchPoint Center => c;

	protected SketchCircle(SketchCircle another)
		: base(another)
	{
		c = AddChild((SketchPoint)another.Center.Clone());
		radius = another.radius._0023_003DzqZwFarHnpOoH();
	}

	internal SketchCircle(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		c = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
	}

	internal SketchCircle(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		c = AddChild(_0023_003DzbUvT9Pc_003D);
	}

	protected SketchCircle(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		c = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656765), typeof(SketchPoint));
		radius = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), typeof(Param));
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzK56eBig1iCdElMJTCQ_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzK56eBig1iCdElMJTCQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override SketchPoint _0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D(_0023_003DzpIxZyllUf71E32IBGeiYQ3GZCeope4AwcQ_003D_003D _0023_003Dz437_00244ak_003D)
	{
		return c;
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!c._0023_003Dztl9hmdI_003D())
		{
			return radius.changed;
		}
		return true;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchCircleSurrogate(this);
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzAo_00245w06EoxdTvuaXNA_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
		double scaleFactor = Math.Abs(_0023_003DzLS0sR0pzioXc.ScaleFactorX);
		if (_0023_003DzLS0sR0pzioXc.IsScaleFactorUniform() || _0023_003DzLS0sR0pzioXc.IsScaleFactorUniformForPlanar(Plane.XY, ref scaleFactor))
		{
			Radius *= scaleFactor;
		}
	}

	public override Point3D[] IntersectWith(SketchCurve curve)
	{
		Circle circle = (Circle)GetGeometricEntity();
		ICurve geometricEntity = curve.GetGeometricEntity();
		List<Point3D> list = new List<Point3D>();
		if (geometricEntity is Line line)
		{
			if (Utility.IntersectionLineCircle(line, circle, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, infiniteLine: false, out var i, out var i2))
			{
				if (i != null)
				{
					list.Add(i);
				}
				if (i2 != null)
				{
					list.Add(i2);
				}
			}
		}
		else
		{
			if (!(geometricEntity is Circle arc))
			{
				return circle.IntersectWith(geometricEntity);
			}
			if (Utility.IntersectionCircleCircle(arc, circle, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, out var i3, out var i4))
			{
				if (i3 != null)
				{
					list.Add(i3);
				}
				if (i4 != null)
				{
					list.Add(i4);
				}
			}
		}
		return list.ToArray();
	}

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954668), Math.Abs(radius._0023_003DzV29zQ3g_003D())._0023_003Dz1eU15ZU_003D());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		radius._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954668)].Value._0023_003DzR61OsnE_003D());
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		Exp _0023_003DzBJFJHwk_003D = _0023_003DzNDQ_E88_003D * 2.0 * Math.PI;
		return c._0023_003Dzuc1z_scDJBr3() + new ExpVector(Exp._0023_003DzHqHPcG0_003D(_0023_003DzBJFJHwk_003D), Exp._0023_003DzzFteY6c_003D(_0023_003DzBJFJHwk_003D), 0.0) * _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
	}

	internal override ExpVector _0023_003DznwYbRgIzSbCB(Exp _0023_003DzNDQ_E88_003D)
	{
		Exp _0023_003DzBJFJHwk_003D = _0023_003DzNDQ_E88_003D * 2.0 * Math.PI;
		return new ExpVector(-Exp._0023_003DzzFteY6c_003D(_0023_003DzBJFJHwk_003D), Exp._0023_003DzHqHPcG0_003D(_0023_003DzBJFJHwk_003D), 0.0);
	}

	internal override Exp _0023_003Dz2s6gjYE_003D()
	{
		return new Exp(2.0) * Math.PI * _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		return Exp._0023_003Dz0v89Hn0_003D(radius);
	}

	internal override ExpVector _0023_003DzwwGQT0MxcNOs()
	{
		return Center._0023_003Dzuc1z_scDJBr3();
	}

	public override object Clone()
	{
		return new SketchCircle(this);
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		Circle obj = (Circle)_0023_003DzZ_ilKakl9sw5();
		obj.Plane = (Plane)_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.Clone();
		obj.Center = Center.Position;
		obj.Radius = Math.Abs(Radius);
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		return new Circle(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, Center.PlanePosition, Math.Abs(Radius));
	}

	public override void Reverse()
	{
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656765), c);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), radius);
	}
}
