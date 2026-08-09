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
public class SketchPoint : SketchCurve
{
	private sealed class _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchPoint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchPoint sketchPoint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchPoint;
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
			_0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D2 = this;
			}
			else
			{
				_0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D2 = new _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D(0);
				_0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D2;
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

	private sealed class _0023_003DzYdiatun97A0ia0I7CQ_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchPoint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzYdiatun97A0ia0I7CQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchPoint sketchPoint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchPoint.x;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchPoint.y;
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
			_0023_003DzYdiatun97A0ia0I7CQ_003D_003D _0023_003DzYdiatun97A0ia0I7CQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzYdiatun97A0ia0I7CQ_003D_003D2 = this;
			}
			else
			{
				_0023_003DzYdiatun97A0ia0I7CQ_003D_003D2 = new _0023_003DzYdiatun97A0ia0I7CQ_003D_003D(0);
				_0023_003DzYdiatun97A0ia0I7CQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzYdiatun97A0ia0I7CQ_003D_003D2;
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

	internal Param x = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446));

	internal Param y = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754));

	private ExpVector exp_;

	public Point3D Position
	{
		get
		{
			return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.PointAt(x._0023_003DzV29zQ3g_003D(), y._0023_003DzV29zQ3g_003D());
		}
		set
		{
			Point2D point2D = _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.Project(value);
			x._0023_003DzO_0024HwSzQ_003D(point2D.X);
			y._0023_003DzO_0024HwSzQ_003D(point2D.Y);
		}
	}

	public Point2D PlanePosition
	{
		get
		{
			return new Point2D(x._0023_003DzV29zQ3g_003D(), y._0023_003DzV29zQ3g_003D());
		}
		set
		{
			x._0023_003DzO_0024HwSzQ_003D(value.X);
			y._0023_003DzO_0024HwSzQ_003D(value.Y);
		}
	}

	internal SketchPoint(SketchPoint _0023_003DzySgeilxprQOK)
		: base(_0023_003DzySgeilxprQOK)
	{
		x = _0023_003DzySgeilxprQOK.x._0023_003DzqZwFarHnpOoH();
		y = _0023_003DzySgeilxprQOK.y._0023_003DzqZwFarHnpOoH();
	}

	internal SketchPoint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal SketchPoint()
	{
	}

	protected SketchPoint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		x = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), typeof(Param));
		y = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), typeof(Param));
	}

	public SketchPoint FixToOrigin()
	{
		new PointFixedConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), this);
		return this;
	}

	public SketchPoint FixToOrigin(out PointFixedConstraint pointFixedConstraint)
	{
		pointFixedConstraint = new PointFixedConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), this);
		return this;
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
		Point2D planePosition = PlanePosition;
		planePosition.TransformBy(_0023_003DzLS0sR0pzioXc);
		_0023_003DzF56xZpo_003D(planePosition.X, planePosition.Y);
	}

	public override Point3D[] IntersectWith(SketchCurve curve)
	{
		return new Point3D[0];
	}

	internal void _0023_003DzF56xZpo_003D(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D)
	{
		x._0023_003DzO_0024HwSzQ_003D(_0023_003Dz3YfTAqg_003D);
		y._0023_003DzO_0024HwSzQ_003D(_0023_003DzpilgH4E_003D);
	}

	public void SetPosition(Point3D pos)
	{
		_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.Project(pos, out var s, out var t);
		x._0023_003DzO_0024HwSzQ_003D(s);
		y._0023_003DzO_0024HwSzQ_003D(t);
	}

	internal Vector3D _0023_003DzOy1CtAC3DuWW()
	{
		return Position.AsVector;
	}

	internal void _0023_003Dzp88PjKDmx6K1(Vector3D _0023_003DzPzO_0024GUk_003D)
	{
		SetPosition(_0023_003DzOy1CtAC3DuWW().AsPoint);
	}

	internal ExpVector _0023_003Dzuc1z_scDJBr3()
	{
		if (exp_ == null)
		{
			exp_ = new ExpVector(x, y, 0.0);
		}
		if (transform != null)
		{
			return transform(exp_);
		}
		return exp_;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzYdiatun97A0ia0I7CQ_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzYdiatun97A0ia0I7CQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzTsDyYjVk0lq0C_zVKg_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!x.changed)
		{
			return y.changed;
		}
		return true;
	}

	internal bool _0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(SketchCurve _0023_003Dz8fpRyMu9aKjE, ref PointOnConstraint _0023_003DzT5pbgeuUHI_Z)
	{
		return _0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(_0023_003Dz8fpRyMu9aKjE, ref _0023_003DzT5pbgeuUHI_Z, null);
	}

	private bool _0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(SketchCurve _0023_003Dz8fpRyMu9aKjE, ref PointOnConstraint _0023_003DzT5pbgeuUHI_Z, SketchCurve _0023_003Dz4wcRs5s_003D)
	{
		for (int i = 0; i < usedInConstraints.Count; i++)
		{
			if (usedInConstraints[i] is PointOnConstraint pointOnConstraint && pointOnConstraint.Curve._0023_003DzuwORSGsM0fc5(_0023_003Dz8fpRyMu9aKjE))
			{
				_0023_003DzT5pbgeuUHI_Z = pointOnConstraint;
				return true;
			}
		}
		for (int j = 0; j < usedInConstraints.Count; j++)
		{
			if (usedInConstraints[j] is CoincidentConstraint coincidentConstraint)
			{
				SketchCurve sketchCurve = coincidentConstraint._0023_003DzQZBvZdCfU5am(this);
				PointOnConstraint _0023_003DzT5pbgeuUHI_Z2 = null;
				if (!sketchCurve._0023_003DzuwORSGsM0fc5(_0023_003Dz4wcRs5s_003D) && sketchCurve is SketchPoint && (sketchCurve as SketchPoint)._0023_003DzWy5ODiRx9LoLSYk81iML_7Q_003D(_0023_003Dz8fpRyMu9aKjE, ref _0023_003DzT5pbgeuUHI_Z2, this))
				{
					_0023_003DzT5pbgeuUHI_Z = _0023_003DzT5pbgeuUHI_Z2;
					return true;
				}
			}
		}
		return false;
	}

	private bool _0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(SketchCurve _0023_003DzlY77YgY_003D, SketchCurve _0023_003Dz4wcRs5s_003D)
	{
		if (_0023_003DzlY77YgY_003D._0023_003DzuwORSGsM0fc5(this))
		{
			return true;
		}
		for (int i = 0; i < usedInConstraints.Count; i++)
		{
			if (usedInConstraints[i] is CoincidentConstraint coincidentConstraint)
			{
				SketchCurve sketchCurve = coincidentConstraint._0023_003DzQZBvZdCfU5am(this);
				if (sketchCurve._0023_003DzuwORSGsM0fc5(_0023_003DzlY77YgY_003D) || (!sketchCurve._0023_003DzuwORSGsM0fc5(_0023_003Dz4wcRs5s_003D) && sketchCurve is SketchPoint && (sketchCurve as SketchPoint)._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(_0023_003DzlY77YgY_003D, this)))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool _0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(SketchCurve _0023_003DzlY77YgY_003D)
	{
		return _0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(_0023_003DzlY77YgY_003D, null);
	}

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), x._0023_003DzV29zQ3g_003D()._0023_003Dz1eU15ZU_003D());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), y._0023_003DzV29zQ3g_003D()._0023_003Dz1eU15ZU_003D());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		x._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446)].Value._0023_003DzR61OsnE_003D());
		y._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754)].Value._0023_003DzR61OsnE_003D());
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		return _0023_003Dzuc1z_scDJBr3();
	}

	internal override ExpVector _0023_003DznwYbRgIzSbCB(Exp _0023_003DzNDQ_E88_003D)
	{
		return null;
	}

	internal override Exp _0023_003Dz2s6gjYE_003D()
	{
		return null;
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		return null;
	}

	public override string ToString()
	{
		return Position.ToString();
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchPointSurrogate(this);
	}

	public override object Clone()
	{
		return new SketchPoint(this);
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		((Point)_0023_003DzZ_ilKakl9sw5()).Position = Position;
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		return new Point(Position);
	}

	public override void Reverse()
	{
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), x);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), y);
	}
}
