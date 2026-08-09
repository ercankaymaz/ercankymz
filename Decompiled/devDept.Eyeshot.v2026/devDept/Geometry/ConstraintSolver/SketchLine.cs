using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class SketchLine : SketchCurve, ISketchCurve
{
	private sealed class _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchLine _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchLine sketchLine = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchLine.p0;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchLine.p1;
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
			_0023_003DzJV67isVNrVw_dfLM8Q_003D_003D _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzJV67isVNrVw_dfLM8Q_003D_003D2 = this;
			}
			else
			{
				_0023_003DzJV67isVNrVw_dfLM8Q_003D_003D2 = new _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D(0);
				_0023_003DzJV67isVNrVw_dfLM8Q_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D2;
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

	internal SketchPoint p0;

	internal SketchPoint p1;

	public SketchPoint StartPoint => p0;

	public SketchPoint EndPoint => p1;

	public Vector3D[] SegmentPoints => new Vector3D[2]
	{
		p0.Position.AsVector,
		p1.Position.AsVector
	};

	protected SketchLine(SketchLine another)
		: base(another)
	{
		p0 = AddChild(new SketchPoint(another.p0));
		p1 = AddChild(new SketchPoint(another.p1));
	}

	internal SketchLine(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
	}

	internal SketchLine(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(_0023_003Dz3k5Uze_VdwnF);
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchLine(SketchInternal _0023_003DzjCETKTg_003D, Point2D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(_0023_003DzMnu3zKCWb6Kc);
		p0._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
	}

	internal SketchLine(SketchInternal _0023_003DzjCETKTg_003D, Point2D _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p0._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
		p1._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchLine(SketchInternal _0023_003DzjCETKTg_003D, double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p0._0023_003DzF56xZpo_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D);
		p1._0023_003DzF56xZpo_003D(_0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D);
	}

	protected SketchLine(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		p0 = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656532), typeof(SketchPoint));
		p1 = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656515), typeof(SketchPoint));
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		return new Line(StartPoint.Position, EndPoint.Position);
	}

	public override void Reverse()
	{
		SketchPoint sketchPoint = p1;
		SketchPoint sketchPoint2 = p0;
		p0 = sketchPoint;
		p1 = sketchPoint2;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzJV67isVNrVw_dfLM8Q_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzJV67isVNrVw_dfLM8Q_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!p0._0023_003Dztl9hmdI_003D())
		{
			return p1._0023_003Dztl9hmdI_003D();
		}
		return true;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchLineSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656532), p0);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656515), p1);
	}

	public override object Clone()
	{
		return new SketchLine(this);
	}

	protected internal override SketchCurve OnSplit(Vector3D position)
	{
		SketchLine sketchLine = new SketchLine(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D());
		sketchLine.p1._0023_003Dzp88PjKDmx6K1(p1._0023_003DzOy1CtAC3DuWW());
		p1._0023_003Dzp88PjKDmx6K1(position);
		sketchLine.p0._0023_003Dzp88PjKDmx6K1(p1._0023_003DzOy1CtAC3DuWW());
		return sketchLine;
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		ExpVector expVector = p0._0023_003Dzuc1z_scDJBr3();
		ExpVector expVector2 = p1._0023_003Dzuc1z_scDJBr3();
		return expVector + (expVector2 - expVector) * _0023_003DzNDQ_E88_003D;
	}

	internal override ExpVector _0023_003DznwYbRgIzSbCB(Exp _0023_003DzNDQ_E88_003D)
	{
		return p1._0023_003Dzuc1z_scDJBr3() - p0._0023_003Dzuc1z_scDJBr3();
	}

	internal override Exp _0023_003Dz2s6gjYE_003D()
	{
		return (p1._0023_003Dzuc1z_scDJBr3() - p0._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		return null;
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		Line obj = (Line)_0023_003DzZ_ilKakl9sw5();
		obj.StartPoint = StartPoint.Position;
		obj.EndPoint = EndPoint.Position;
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
	}

	public override Point3D[] IntersectWith(SketchCurve skCurve)
	{
		Line line = (Line)GetGeometricEntity();
		ICurve geometricEntity = skCurve.GetGeometricEntity();
		List<Point3D> list = new List<Point3D>();
		if (geometricEntity is Circle arc)
		{
			if (Utility.IntersectionLineCircle(line, arc, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, infiniteLine: false, out var i, out var i2))
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
			return list.ToArray();
		}
		return base.IntersectWith(skCurve);
	}
}
