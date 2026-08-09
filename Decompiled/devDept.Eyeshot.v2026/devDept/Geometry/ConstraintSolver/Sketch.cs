using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class Sketch : ISerializable, ICloneable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<SketchCurve, IEnumerable<SketchPoint>> _0023_003DzzvQvaeJ_0024ta46wry40w_003D_003D;

		public static Func<SketchCurve, bool> _0023_003DzS3T8D0Ciz2S8Flqllw_003D_003D;

		internal IEnumerable<SketchPoint> _0023_003DzEqwYSQpagIXrT9ioYMVatPOW9vQt(SketchCurve _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.Vertices;
		}

		internal bool _0023_003Dz5Kx_zWkBru7LljqoWE_0024312b7oB71(SketchCurve _0023_003Dzt_m8zV0_003D)
		{
			return !(_0023_003Dzt_m8zV0_003D is SketchPoint);
		}
	}

	private sealed class _0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D
	{
		public Constraint _0023_003Dz9EdxXqI_003D;

		internal bool _0023_003DzXE2ScOI8Rumrq31Xjw_003D_003D(Type _0023_003DzNDQ_E88_003D)
		{
			return _0023_003DzNDQ_E88_003D.IsInstanceOfType(_0023_003Dz9EdxXqI_003D);
		}
	}

	internal readonly SketchInternal _sketchInternal;

	private readonly Param _dragX = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656789), _0023_003DziG55oRyj2zxanVvf0Q_003D_003D: false);

	private readonly Param _dragY = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656769), _0023_003DziG55oRyj2zxanVvf0Q_003D_003D: false);

	internal Type[] unsupportedTranslateConstraints = new Type[1] { typeof(PointFixedConstraint) };

	internal Type[] supportedRotateConstraints = new Type[7]
	{
		typeof(PointOnConstraint),
		typeof(CoincidentConstraint),
		typeof(PerpendicularConstraint),
		typeof(ParallelConstraint),
		typeof(TangentConstraint),
		typeof(LengthConstraint),
		typeof(EqualConstraint)
	};

	internal Type[] supportedScaleConstraints = new Type[3]
	{
		typeof(PointOnConstraint),
		typeof(CoincidentConstraint),
		typeof(HVConstraint)
	};

	internal Type[] unsupportedMirrorConstraints = new Type[4]
	{
		typeof(PointFixedConstraint),
		typeof(PerpendicularConstraint),
		typeof(TangentConstraint),
		typeof(AngleConstraint)
	};

	public int RankExcess => _sketchInternal.RankExcess;

	public Plane SketchPlane
	{
		get
		{
			return _sketchInternal.Plane;
		}
		set
		{
			_sketchInternal.Plane = value;
		}
	}

	public Constraint[] Constraints => _sketchInternal._0023_003DzmhwHHfYvC_oJ().ToArray();

	public List<SketchCurve> CurveList => _sketchInternal._0023_003DzW1wgPM78KxwE();

	public int DOF => _sketchInternal.DOF;

	public Sketch()
	{
		_sketchInternal = new SketchInternal();
		Telemetry.Instance.AddUsage(this, Telemetry.moduleType.Generic);
	}

	public Sketch(Plane sketchPlane)
		: this()
	{
		SketchPlane = sketchPlane;
	}

	protected Sketch(Sketch another)
	{
		_sketchInternal = (SketchInternal)another._sketchInternal.Clone();
		SketchPlane = (Plane)another.SketchPlane.Clone();
	}

	protected Sketch(SerializationInfo info, StreamingContext context)
		: this()
	{
		_sketchInternal = (SketchInternal)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656781), typeof(SketchInternal));
	}

	public void Clear()
	{
		_sketchInternal._0023_003DztXK6GnE_003D();
	}

	public void DragEnd()
	{
		_sketchInternal.dragExp.Clear();
	}

	public void DragStart(params SketchCurve[] entities)
	{
		_dragX._0023_003DzO_0024HwSzQ_003D(0.0);
		_dragY._0023_003DzO_0024HwSzQ_003D(0.0);
		for (int i = 0; i < entities.Length; i++)
		{
			foreach (SketchPoint item3 in entities[i]._0023_003DzgJiUT1qDtKLT())
			{
				Exp item = item3.x._0023_003Dzuc1z_scDJBr3()._0023_003Dz7cZ02rs_003D(_dragX._0023_003Dzuc1z_scDJBr3() + item3.x._0023_003Dzuc1z_scDJBr3()._0023_003DzBUjqlpM_003D());
				Exp item2 = item3.y._0023_003Dzuc1z_scDJBr3()._0023_003Dz7cZ02rs_003D(_dragY._0023_003Dzuc1z_scDJBr3() + item3.y._0023_003Dzuc1z_scDJBr3()._0023_003DzBUjqlpM_003D());
				_sketchInternal.dragExp.Add(item);
				_sketchInternal.dragExp.Add(item2);
			}
		}
	}

	public void Drag(double dx, double dy)
	{
		Param dragX = _dragX;
		dragX._0023_003DzO_0024HwSzQ_003D(dragX._0023_003DzV29zQ3g_003D() + dx);
		Param dragY = _dragY;
		dragY._0023_003DzO_0024HwSzQ_003D(dragY._0023_003DzV29zQ3g_003D() + dy);
	}

	public void Drag(Point2D from, Point2D to)
	{
		Drag(to.X - from.X, to.Y - from.Y);
	}

	public bool RemoveConstraint(Constraint constraint)
	{
		if (_sketchInternal._0023_003DzmhwHHfYvC_oJ().Contains(constraint))
		{
			constraint.Destroy();
			return true;
		}
		return false;
	}

	public void AddConstraint(Constraint constraint)
	{
		constraint._0023_003DzxWZ7yqG65a6T(_sketchInternal.idGenerator.New());
		_sketchInternal._0023_003Dz55vCXok_003D(constraint);
		constraint._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(_sketchInternal);
		_sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D = Math.Max(_sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D, constraint._0023_003DzDQs07gDx7oDr().value);
		foreach (IdPath id in constraint._ids)
		{
			if (_sketchInternal._0023_003DzXKRytQoXWc2o(id, 0) is SketchCurve sketchCurve)
			{
				sketchCurve._0023_003Dz55vCXok_003D(constraint);
			}
		}
	}

	public void AddEntity(SketchCurve sketchCurve)
	{
		sketchCurve._0023_003DzxWZ7yqG65a6T(_sketchInternal.idGenerator.New());
		_sketchInternal._0023_003DzRCrpdGA_003D(sketchCurve);
		sketchCurve._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(_sketchInternal);
		_sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D = Math.Max(_sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D, sketchCurve._0023_003DzDQs07gDx7oDr().value);
	}

	public SketchPoint AddPoint(double x, double y)
	{
		SketchPoint sketchPoint = new SketchPoint(_sketchInternal);
		sketchPoint._0023_003DzF56xZpo_003D(x, y);
		return sketchPoint;
	}

	public SketchPoint AddPoint(Point2D point)
	{
		SketchPoint sketchPoint = new SketchPoint(_sketchInternal);
		sketchPoint._0023_003DzF56xZpo_003D(point.X, point.Y);
		return sketchPoint;
	}

	public SketchPoint AddPoint3D(Point3D point)
	{
		return new SketchPoint(_sketchInternal)
		{
			Position = point
		};
	}

	public SketchSpline AddSpline(IList<Point2D> controlPoints)
	{
		if (controlPoints.Count != 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656996));
		}
		SketchSpline sketchSpline = new SketchSpline(_sketchInternal);
		for (int i = 0; i < sketchSpline.ControlPoints.Length; i++)
		{
			sketchSpline.ControlPoints[i]._0023_003DzF56xZpo_003D(controlPoints[i].X, controlPoints[i].Y);
		}
		return sketchSpline;
	}

	internal SketchSpline AddSpline(Curve _0023_003DzISVxDgkU0JWQ, SketchPoint _0023_003DzLxQW3eiASmKM, bool _0023_003DzAqOpw0w_003D)
	{
		_0023_003DzLxQW3eiASmKM.ParentCurve.children.Remove(_0023_003DzLxQW3eiASmKM);
		return new SketchSpline(_sketchInternal, _0023_003DzISVxDgkU0JWQ, _0023_003DzLxQW3eiASmKM, _0023_003DzAqOpw0w_003D);
	}

	public SketchCurve[] AddRoundedRectangle(double x, double y, double width, double height, double radius)
	{
		List<ISketchCurve> list = new List<ISketchCurve>();
		list.Add(AddLine(x + radius, y, x + width - radius, y));
		list.Add(AddArc(x + width - radius, y + radius, radius, Utility.DegToRad(270.0), Utility.DegToRad(360.0), radConstraint: false));
		list.Add(AddLine(x + width, y + radius, x + width, y + height - radius));
		list.Add(AddArc(x + width - radius, y + height - radius, radius, Utility.DegToRad(0.0), Utility.DegToRad(90.0), radConstraint: false));
		list.Add(AddLine(x + width - radius, y + height, x + radius, y + height));
		list.Add(AddArc(x + radius, y + height - radius, radius, Utility.DegToRad(90.0), Utility.DegToRad(180.0), radConstraint: false));
		list.Add(AddLine(x, y + height - radius, x, y + radius));
		list.Add(AddArc(x + radius, y + radius, radius, Utility.DegToRad(180.0), Utility.DegToRad(270.0), radConstraint: false));
		for (int i = 0; i < 7; i++)
		{
			AddConstraintJoin(list[i].EndPoint, list[i + 1].StartPoint);
			AddConstraintTangent((SketchCurve)list[i], (SketchCurve)list[i + 1]);
		}
		AddConstraintJoin(list[7].EndPoint, list[0].StartPoint);
		AddConstraintTangent((SketchCurve)list[7], (SketchCurve)list[0]);
		AddConstraintHorizontal((SketchLine)list[0]);
		AddConstraintHorizontal((SketchLine)list[4]);
		AddConstraintVertical((SketchLine)list[2]);
		AddConstraintVertical((SketchLine)list[6]);
		AddConstraintEqualRadius((SketchArc)list[1], (SketchArc)list[3]);
		AddConstraintEqualRadius((SketchArc)list[3], (SketchArc)list[5]);
		AddConstraintEqualRadius((SketchArc)list[5], (SketchArc)list[7]);
		AddConstraintDistance((SketchLine)list[0], (SketchLine)list[4]);
		AddConstraintDistance((SketchLine)list[2], (SketchLine)list[6]);
		AddConstraintRadius((SketchArc)list[1]);
		return _0023_003Dz_HzXvPc63iDTyvCI22WbHjQEZHLvLS3jrA_003D_003D(list);
	}

	public SketchCurve[] AddSlot(double x, double y, double length, double radius, double angle = 0.0, bool dimConstraint = true)
	{
		return _0023_003DzAAIG9vo_003D(x, y, length, radius, angle, dimConstraint);
	}

	private SketchCurve[] _0023_003DzAAIG9vo_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003Dz736ekIs_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003Dz6pajdGM_003D, bool _0023_003DzEcL_0024t1GwEDpi)
	{
		List<ISketchCurve> list = new List<ISketchCurve>();
		Point2D[] array = new Point2D[4]
		{
			new Point2D(0.0, 0.0 - _0023_003DzEGKj_0024SNUUihi),
			new Point2D(_0023_003Dz736ekIs_003D, 0.0 - _0023_003DzEGKj_0024SNUUihi),
			new Point2D(_0023_003Dz736ekIs_003D, _0023_003DzEGKj_0024SNUUihi),
			new Point2D(0.0, _0023_003DzEGKj_0024SNUUihi)
		};
		Transformation xform = new Translation(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D) * new Rotation(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ);
		Point2D[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].TransformBy(xform);
		}
		Point2D center = Point2D.MidPoint(array[0], array[3]);
		Point2D center2 = (array[1] + array[2]) / 2.0;
		list.Add(AddLine(array[0], array[1]));
		list.Add(AddArc(center2, array[1], array[2]));
		list.Add(AddLine(array[2], array[3]));
		list.Add(AddArc(center, array[3], array[0]));
		for (int j = 0; j < 3; j++)
		{
			AddConstraintJoin(list[j].EndPoint, list[j + 1].StartPoint);
			AddConstraintTangent((SketchCurve)list[j], (SketchCurve)list[j + 1]);
		}
		AddConstraintJoin(list[3].EndPoint, list[0].StartPoint);
		AddConstraintTangent((SketchCurve)list[3], (SketchCurve)list[0]);
		if (_0023_003DzEcL_0024t1GwEDpi)
		{
			AddConstraintRadius((SketchArc)list[3]);
			AddConstraintLength((SketchCurve)list[0]);
		}
		AddConstraintEqualRadius((SketchArc)list[3], (SketchArc)list[1]);
		if (_0023_003Dz6pajdGM_003D == 0.0)
		{
			AddConstraintHorizontal((SketchLine)list[0]);
		}
		return _0023_003Dz_HzXvPc63iDTyvCI22WbHjQEZHLvLS3jrA_003D_003D(list);
	}

	private static SketchCurve[] _0023_003Dz_HzXvPc63iDTyvCI22WbHjQEZHLvLS3jrA_003D_003D(List<ISketchCurve> _0023_003DzWc9WmS8VMsuA)
	{
		SketchCurve[] array = new SketchCurve[_0023_003DzWc9WmS8VMsuA.Count];
		for (int i = 0; i < _0023_003DzWc9WmS8VMsuA.Count; i++)
		{
			array[i] = (SketchCurve)_0023_003DzWc9WmS8VMsuA[i];
		}
		return array;
	}

	private SketchLine _0023_003DzU6RJXiI_003D(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, bool _0023_003DzSfBIGFVI4ONZ, bool _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D)
	{
		SketchLine sketchLine = new SketchLine(_sketchInternal, _0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D, _0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D);
		sketchLine.Construction = _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D;
		if (_0023_003DzSfBIGFVI4ONZ)
		{
			AddConstraintLength(sketchLine);
		}
		return sketchLine;
	}

	public SketchLine AddLine(Point2D statPoint, Point2D endPoint, bool lenConstraint = false, bool construction = false)
	{
		return AddLine(statPoint.X, statPoint.Y, endPoint.X, endPoint.Y, lenConstraint, construction);
	}

	public SketchLine AddLine(SketchPoint startPoint, SketchPoint endPoint, bool construction = false)
	{
		SketchLine sketchLine = AddLine(startPoint.Position.X, startPoint.Position.Y, endPoint.Position.X, endPoint.Position.Y, lengthConstraint: false, construction);
		AddConstraintJoin(sketchLine.StartPoint, startPoint);
		AddConstraintJoin(sketchLine.EndPoint, endPoint);
		return sketchLine;
	}

	public SketchLine AddLine(double x1, double y1, double x2, double y2, bool lengthConstraint = false, bool construction = false)
	{
		return _0023_003DzU6RJXiI_003D(x1, y1, x2, y2, lengthConstraint, construction);
	}

	public SketchPoint AddOrigin()
	{
		return AddPoint(0.0, 0.0).FixToOrigin();
	}

	public SketchLine AddAxisX(SketchPoint origin, double length = 100.0)
	{
		SketchLine sketchLine = _0023_003DzU6RJXiI_003D(0.0, 0.0, length, 0.0, _0023_003DzSfBIGFVI4ONZ: true, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: true);
		AddConstraintJoin(sketchLine.StartPoint, origin);
		AddConstraintHorizontal(sketchLine);
		return sketchLine;
	}

	public SketchLine AddAxisMinusX(SketchPoint origin, double length = 100.0)
	{
		SketchLine sketchLine = _0023_003DzU6RJXiI_003D(0.0 - length, 0.0, 0.0, 0.0, _0023_003DzSfBIGFVI4ONZ: true, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: true);
		AddConstraintJoin(sketchLine.EndPoint, origin);
		AddConstraintHorizontal(sketchLine);
		return sketchLine;
	}

	public SketchLine AddAxisY(SketchPoint origin, double length = 100.0)
	{
		SketchLine sketchLine = _0023_003DzU6RJXiI_003D(0.0, 0.0, 0.0, length, _0023_003DzSfBIGFVI4ONZ: true, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: true);
		AddConstraintJoin(sketchLine.StartPoint, origin);
		AddConstraintVertical(sketchLine);
		return sketchLine;
	}

	public SketchLine AddAxisMinusY(SketchPoint origin, double length = 100.0)
	{
		SketchLine sketchLine = _0023_003DzU6RJXiI_003D(0.0, 0.0 - length, 0.0, 0.0, _0023_003DzSfBIGFVI4ONZ: true, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: true);
		AddConstraintJoin(sketchLine.EndPoint, origin);
		AddConstraintVertical(sketchLine);
		return sketchLine;
	}

	public SketchEllipticalArc AddEllipticalArc(Point2D center, Point2D startPoint, Point2D endPoint, double rx, double ry, bool construction = false)
	{
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal);
		sketchEllipticalArc.Center._0023_003DzF56xZpo_003D(center.X, center.Y);
		sketchEllipticalArc.StartPoint._0023_003DzF56xZpo_003D(startPoint.X, startPoint.Y);
		sketchEllipticalArc.EndPoint._0023_003DzF56xZpo_003D(endPoint.X, endPoint.Y);
		sketchEllipticalArc.Construction = construction;
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(rx);
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(ry);
		return sketchEllipticalArc;
	}

	public SketchEllipticalArc AddEllipticalArc(Point2D center, Point2D startPoint, Point2D endPoint, double rx, double ry, Vector2D axisX, Vector2D axisY, bool construction = false)
	{
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal);
		sketchEllipticalArc.Center._0023_003DzF56xZpo_003D(center.X, center.Y);
		sketchEllipticalArc.StartPoint._0023_003DzF56xZpo_003D(startPoint.X, startPoint.Y);
		sketchEllipticalArc.EndPoint._0023_003DzF56xZpo_003D(endPoint.X, endPoint.Y);
		sketchEllipticalArc.Construction = construction;
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(rx);
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(ry);
		sketchEllipticalArc.basis._0023_003DzNKqPBn1ISogO(axisX, axisY);
		return sketchEllipticalArc;
	}

	public SketchArc AddArc(double cx, double cy, double radius, double startAngle, double endAngle, bool radConstraint = true, bool construction = false)
	{
		SketchArc sketchArc = new SketchArc(_sketchInternal);
		sketchArc.Center._0023_003DzF56xZpo_003D(cx, cy);
		Interval interval = new Interval(startAngle, endAngle);
		if (interval.IsDecreasing)
		{
			interval.Swap();
		}
		if (interval.Length > Math.PI * 2.0)
		{
			interval.t1 = interval.t0 + Math.PI * 2.0;
		}
		sketchArc._startPoint._0023_003DzF56xZpo_003D(cx + Math.Cos(interval.t0) * radius, cy + Math.Sin(interval.t0) * radius);
		sketchArc._endPoint._0023_003DzF56xZpo_003D(cx + Math.Cos(interval.t1) * radius, cy + Math.Sin(interval.t1) * radius);
		sketchArc.Construction = construction;
		if (radConstraint)
		{
			AddConstraintRadius(sketchArc);
		}
		return sketchArc;
	}

	public SketchLine AddLine(SketchPoint startPoint, Point2D endPoint)
	{
		startPoint.ParentCurve.children.Remove(startPoint);
		return new SketchLine(_sketchInternal, startPoint, endPoint);
	}

	public SketchLine AddLine(Point2D startPoint, SketchPoint endPoint)
	{
		endPoint.ParentCurve.children.Remove(endPoint);
		return new SketchLine(_sketchInternal, startPoint, endPoint);
	}

	public SketchEllipticalArc AddEllipticalArc(SketchEllipse skEllipse, Point2D startPoint, Point2D endPoint)
	{
		skEllipse.children.Remove(skEllipse.Center);
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal, skEllipse.Center, startPoint, endPoint);
		sketchEllipticalArc.basis = skEllipse.basis.Clone() as ExpBasis2d;
		sketchEllipticalArc.basis._0023_003DzOjiryAH4CnPe(sketchEllipticalArc.Center.x, sketchEllipticalArc.Center.y);
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(skEllipse.r0._0023_003DzV29zQ3g_003D());
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(skEllipse.r1._0023_003DzV29zQ3g_003D());
		return sketchEllipticalArc;
	}

	public SketchEllipticalArc AddEllipticalArc(SketchEllipse skEllArc, SketchPoint startPoint, Point2D endPoint)
	{
		skEllArc.children.Remove(skEllArc.Center);
		skEllArc.children.Remove(startPoint);
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal, skEllArc.Center, startPoint, endPoint);
		sketchEllipticalArc.basis = skEllArc.basis.Clone() as ExpBasis2d;
		sketchEllipticalArc.basis._0023_003DzOjiryAH4CnPe(sketchEllipticalArc.Center.x, sketchEllipticalArc.Center.y);
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(skEllArc.r0._0023_003DzV29zQ3g_003D());
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(skEllArc.r1._0023_003DzV29zQ3g_003D());
		return sketchEllipticalArc;
	}

	public SketchEllipticalArc AddEllipticalArc(SketchEllipse skEllArc, Point2D center, Point2D startPoint, SketchPoint endPoint)
	{
		skEllArc.children.Remove(endPoint);
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal, center, startPoint, endPoint);
		sketchEllipticalArc.basis = skEllArc.basis.Clone() as ExpBasis2d;
		sketchEllipticalArc.basis._0023_003DzOjiryAH4CnPe(sketchEllipticalArc.Center.x, sketchEllipticalArc.Center.y);
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(skEllArc.r0._0023_003DzV29zQ3g_003D());
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(skEllArc.r1._0023_003DzV29zQ3g_003D());
		return sketchEllipticalArc;
	}

	public SketchArc AddArc(SketchPoint center, Point2D startPoint, Point2D endPoint)
	{
		center.ParentCurve.children.Remove(center);
		return new SketchArc(_sketchInternal, center, startPoint, endPoint);
	}

	public SketchArc AddArc(SketchPoint center, SketchPoint startPoint, Point2D endPoint)
	{
		center.ParentCurve.children.Remove(center);
		startPoint.ParentCurve.children.Remove(startPoint);
		return new SketchArc(_sketchInternal, center, startPoint, endPoint);
	}

	public SketchArc AddArc(Point2D center, Point2D startPoint, SketchPoint endPoint)
	{
		endPoint.ParentCurve.children.Remove(endPoint);
		return new SketchArc(_sketchInternal, center, startPoint, endPoint);
	}

	public SketchArc AddArc(Point2D center, Point2D startPoint, Point2D endPoint, bool construction = false)
	{
		SketchArc sketchArc = new SketchArc(_sketchInternal);
		sketchArc.Center._0023_003DzF56xZpo_003D(center.X, center.Y);
		sketchArc._startPoint._0023_003DzF56xZpo_003D(startPoint.X, startPoint.Y);
		sketchArc._endPoint._0023_003DzF56xZpo_003D(endPoint.X, endPoint.Y);
		sketchArc.Construction = construction;
		return sketchArc;
	}

	private SketchCircle _0023_003DzumMJIhLqjQQU(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzWAKvyMOaICWrYa7j6A_003D_003D, bool _0023_003Dzgq8OMdiS_0024yqV, bool _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D)
	{
		SketchCircle sketchCircle = new SketchCircle(_sketchInternal);
		sketchCircle.Center._0023_003DzF56xZpo_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		sketchCircle.radius._0023_003DzO_0024HwSzQ_003D(_0023_003DzWAKvyMOaICWrYa7j6A_003D_003D / 2.0);
		sketchCircle.Construction = _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D;
		if (_0023_003Dzgq8OMdiS_0024yqV)
		{
			AddConstraintDiameter(sketchCircle);
		}
		return sketchCircle;
	}

	public SketchEllipse AddConstructionEllipse(double x, double y, double rx, double ry)
	{
		return _0023_003Dznttp7Pw_003D(x, y, rx, ry, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: true);
	}

	public SketchEllipse AddEllipse(double x, double y, double rx, double ry)
	{
		return _0023_003Dznttp7Pw_003D(x, y, rx, ry, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: false);
	}

	public SketchEllipse AddEllipse(double x, double y, double rx, double ry, Vector2D u, Vector2D v)
	{
		return _0023_003Dznttp7Pw_003D(x, y, rx, ry, u, v, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: false);
	}

	public SketchEllipse AddEllipse(Point2D center, double rx, double ry)
	{
		return _0023_003Dznttp7Pw_003D(center.X, center.Y, rx, ry, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: false);
	}

	public SketchEllipse ProjectEllipticalArc(EllipticalArc ellArc)
	{
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(_sketchInternal);
		Point2D point2D = SketchPlane.Project(ellArc.Center);
		sketchEllipticalArc.Center._0023_003DzF56xZpo_003D(point2D.X, point2D.Y);
		Point2D point2D2 = SketchPlane.Project(ellArc.StartPoint);
		sketchEllipticalArc.p0._0023_003DzF56xZpo_003D(point2D2.X, point2D2.Y);
		Point2D point2D3 = SketchPlane.Project(ellArc.EndPoint);
		sketchEllipticalArc.p1._0023_003DzF56xZpo_003D(point2D3.X, point2D3.Y);
		sketchEllipticalArc.r0._0023_003DzO_0024HwSzQ_003D(ellArc.RadiusX);
		sketchEllipticalArc.r1._0023_003DzO_0024HwSzQ_003D(ellArc.RadiusY);
		sketchEllipticalArc.basis._0023_003DzYlbK4cc_003D(new ExpVector(ellArc.Plane.AxisX.X, ellArc.Plane.AxisX.Y, ellArc.Plane.AxisX.Z));
		sketchEllipticalArc.basis._0023_003Dzv0UNgsQ_003D(new ExpVector(ellArc.Plane.AxisY.X, ellArc.Plane.AxisY.Y, ellArc.Plane.AxisY.Z));
		return sketchEllipticalArc;
	}

	public SketchEllipse ProjectEllipse(Ellipse ellipse)
	{
		SketchEllipse sketchEllipse = new SketchEllipse(_sketchInternal);
		Point2D point2D = SketchPlane.Project(ellipse.Center);
		sketchEllipse.Center._0023_003DzF56xZpo_003D(point2D.X, point2D.Y);
		sketchEllipse.r0._0023_003DzO_0024HwSzQ_003D(ellipse.RadiusX);
		sketchEllipse.r1._0023_003DzO_0024HwSzQ_003D(ellipse.RadiusY);
		sketchEllipse.basis._0023_003DzYlbK4cc_003D(new ExpVector(ellipse.Plane.AxisX.X, ellipse.Plane.AxisX.Y, ellipse.Plane.AxisX.Z));
		sketchEllipse.basis._0023_003Dzv0UNgsQ_003D(new ExpVector(ellipse.Plane.AxisY.X, ellipse.Plane.AxisY.Y, ellipse.Plane.AxisY.Z));
		return sketchEllipse;
	}

	private SketchEllipse _0023_003Dznttp7Pw_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, bool _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D)
	{
		SketchEllipse sketchEllipse = new SketchEllipse(_sketchInternal);
		sketchEllipse.Construction = _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D;
		sketchEllipse.Center._0023_003DzF56xZpo_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		sketchEllipse.r0._0023_003DzO_0024HwSzQ_003D(_0023_003DzTAvzjIc_003D);
		sketchEllipse.r1._0023_003DzO_0024HwSzQ_003D(_0023_003DzpbGuOuw_003D);
		return sketchEllipse;
	}

	private SketchEllipse _0023_003Dznttp7Pw_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, Vector2D _0023_003Dz_eY3Y4c_003D, Vector2D _0023_003Dz77g161c_003D, bool _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D)
	{
		SketchEllipse sketchEllipse = new SketchEllipse(_sketchInternal);
		sketchEllipse.Construction = _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D;
		sketchEllipse.Center._0023_003DzF56xZpo_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		sketchEllipse.r0._0023_003DzO_0024HwSzQ_003D(_0023_003DzTAvzjIc_003D);
		sketchEllipse.r1._0023_003DzO_0024HwSzQ_003D(_0023_003DzpbGuOuw_003D);
		sketchEllipse.basis._0023_003DzNKqPBn1ISogO(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D);
		return sketchEllipse;
	}

	public SketchCircle AddCircle(double x, double y, double diameter, bool diamConstraint = true, bool construction = false)
	{
		return _0023_003DzumMJIhLqjQQU(x, y, diameter, diamConstraint, construction);
	}

	public SketchCircle AddCircle(Point2D center, double radius, bool diamConstraint = true, bool construction = false)
	{
		return _0023_003DzumMJIhLqjQQU(center.X, center.Y, 2.0 * radius, diamConstraint, construction);
	}

	public SketchLine[] AddPolygon(IList<Point2D> points, bool horVerConstraints, bool construction = false)
	{
		return _0023_003Dz42xH9OQ_003D(points.ToArray(), horVerConstraints, construction);
	}

	public SketchLine[] AddPolygon(params Point2D[] points)
	{
		return _0023_003Dz42xH9OQ_003D(points.ToArray(), _0023_003DzBx5rwYJOgcXn: false, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D: false);
	}

	private SketchLine[] _0023_003Dz42xH9OQ_003D(Point2D[] _0023_003DzrdSL0CI_003D, bool _0023_003DzBx5rwYJOgcXn, bool _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D)
	{
		if (_0023_003DzrdSL0CI_003D.First() == _0023_003DzrdSL0CI_003D.Last())
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656953));
		}
		Point2D[] array = new Point2D[_0023_003DzrdSL0CI_003D.Length + 1];
		Array.Copy(_0023_003DzrdSL0CI_003D, array, _0023_003DzrdSL0CI_003D.Length);
		array[^1] = (Point2D)array[0].Clone();
		int num = array.Length;
		SketchLine[] array2 = new SketchLine[num - 1];
		for (int i = 0; i < num - 1; i++)
		{
			array2[i] = AddLine(array[i].X, array[i].Y, array[i + 1].X, array[i + 1].Y, lengthConstraint: false, _0023_003DzUMkSW7nO3Amic5YDlqGdTXw_003D);
			if (_0023_003DzBx5rwYJOgcXn)
			{
				if (array[i].X == array[i + 1].X)
				{
					AddConstraintVertical(array2[i]);
				}
				else if (array[i].Y == array[i + 1].Y)
				{
					AddConstraintHorizontal(array2[i]);
				}
			}
		}
		for (int j = 0; j < array2.Length - 1; j++)
		{
			AddConstraintJoin(array2[j].EndPoint, array2[j + 1].StartPoint);
		}
		AddConstraintJoin(array2[^1].EndPoint, array2[0].StartPoint);
		return array2;
	}

	public SketchLine[] AddOpenPolygon(params Point2D[] points)
	{
		return AddOpenPolygon(points, horVerConstraints: false);
	}

	public SketchLine[] AddOpenPolygon(IList<Point2D> points, bool horVerConstraints)
	{
		return _0023_003Dz_39sBt2LXMup(points.ToArray(), horVerConstraints);
	}

	private SketchLine[] _0023_003Dz_39sBt2LXMup(Point2D[] _0023_003DzrdSL0CI_003D, bool _0023_003DzBx5rwYJOgcXn)
	{
		SketchLine[] array = new SketchLine[_0023_003DzrdSL0CI_003D.Length - 1];
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			array[i] = AddLine(_0023_003DzrdSL0CI_003D[i], _0023_003DzrdSL0CI_003D[i + 1]);
			if (_0023_003DzBx5rwYJOgcXn)
			{
				if (_0023_003DzrdSL0CI_003D[i].X == _0023_003DzrdSL0CI_003D[i + 1].X)
				{
					AddConstraintVertical(array[i]);
				}
				else if (_0023_003DzrdSL0CI_003D[i].Y == _0023_003DzrdSL0CI_003D[i + 1].Y)
				{
					AddConstraintHorizontal(array[i]);
				}
			}
		}
		for (int j = 0; j < _0023_003DzrdSL0CI_003D.Length - 2; j++)
		{
			AddConstraintJoin(array[j].EndPoint, array[j + 1].StartPoint);
		}
		return array;
	}

	public SketchLine[] AddRectangle(double x, double y, double width, double height, double angle = 0.0, bool construction = false, bool lengthConstraints = true)
	{
		Point2D[] array = new Point2D[4]
		{
			new Point2D(0.0, 0.0),
			new Point2D(width, 0.0),
			new Point2D(width, height),
			new Point2D(0.0, height)
		};
		Transformation xform = new Rotation(angle, Vector3D.AxisZ) * new Translation(x, y);
		Point2D[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].TransformBy(xform);
		}
		SketchLine[] array3 = AddPolygon(array, construction);
		if (angle == 0.0)
		{
			AddConstraintHorizontal(array3[0]);
			AddConstraintHorizontal(array3[2]);
			AddConstraintVertical(array3[1]);
			AddConstraintVertical(array3[3]);
		}
		else
		{
			AddConstraintParallel(array3[0], array3[2]);
			AddConstraintParallel(array3[1], array3[3]);
			AddConstraintPerpendicular(array3[0], array3[1]);
		}
		if (lengthConstraints)
		{
			AddConstraintDistance(array3[0], array3[2], height);
			AddConstraintDistance(array3[1], array3[3], width);
		}
		return array3;
	}

	public SketchArc[] AddCircularSlot(double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius, bool dimConstraint = true)
	{
		double num = startAngle + deltaAngle;
		SketchArc sketchArc = AddArc(x, y, radius - slotRadius, startAngle, num, dimConstraint);
		SketchArc sketchArc2 = AddArc(x, y, radius + slotRadius, startAngle, num, radConstraint: false);
		SketchArc sketchArc3 = AddArc(x + radius * Math.Cos(startAngle), y + radius * Math.Sin(startAngle), slotRadius, Math.PI + startAngle, Math.PI * 2.0 + startAngle, dimConstraint);
		SketchArc sketchArc4 = AddArc(x + radius * Math.Cos(num), y + radius * Math.Sin(num), slotRadius, num, num + Math.PI, radConstraint: false);
		AddConstraintJoin(sketchArc.StartPoint, sketchArc3.StartPoint);
		AddConstraintJoin(sketchArc3.EndPoint, sketchArc2.StartPoint);
		AddConstraintJoin(sketchArc2.EndPoint, sketchArc4.StartPoint);
		AddConstraintJoin(sketchArc4.EndPoint, sketchArc.EndPoint);
		AddConstraintJoin(sketchArc.Center, sketchArc2.Center);
		AddConstraintTangent(sketchArc, sketchArc3);
		AddConstraintTangent(sketchArc, sketchArc4);
		AddConstraintTangent(sketchArc2, sketchArc3);
		AddConstraintTangent(sketchArc2, sketchArc4);
		if (dimConstraint)
		{
			AddConstraintLength(sketchArc2, (radius + slotRadius) * deltaAngle);
		}
		return new SketchArc[4] { sketchArc3, sketchArc2, sketchArc4, sketchArc };
	}

	public SketchLine[] AddHexagon(double radius, bool inscribed, out SketchPoint center, double angle = 0.0)
	{
		return _0023_003Dz42xH9OQ_003D(6, radius, angle, inscribed, out center);
	}

	public SketchLine[] AddInscribedPolygon(int sides, double radius, bool inscribed, out SketchPoint center, double angle = 0.0)
	{
		return _0023_003Dz42xH9OQ_003D(sides, radius, angle, inscribed, out center);
	}

	public SketchLine[] AddPolygon(Point2D center, int sides, double radius, double angle, out SketchPoint polyCenter)
	{
		PolygonConstraint _0023_003Dz9EdxXqI_003D;
		SketchLine[] result = _0023_003Dz42xH9OQ_003D(center.X, center.Y, sides, radius, angle, out _0023_003Dz9EdxXqI_003D);
		polyCenter = _0023_003Dz9EdxXqI_003D.Center;
		return result;
	}

	public SketchLine[] AddPolygon(Point2D center, int sides, double radius, double angle, out PolygonConstraint constraint)
	{
		return _0023_003Dz42xH9OQ_003D(center.X, center.Y, sides, radius, angle, out constraint);
	}

	private SketchLine[] _0023_003Dz42xH9OQ_003D(double _0023_003DztVEXAWo_003D, double _0023_003DzbqrXutw_003D, int _0023_003Dz_C5M_0024TZrmoaK, double _0023_003DzEGKj_0024SNUUihi, double _0023_003Dz6pajdGM_003D, out PolygonConstraint _0023_003Dz9EdxXqI_003D)
	{
		double num = 0.0 / (double)_0023_003Dz_C5M_0024TZrmoaK + _0023_003Dz6pajdGM_003D;
		double x = _0023_003DztVEXAWo_003D + _0023_003DzEGKj_0024SNUUihi * Math.Cos(num);
		double y = _0023_003DzbqrXutw_003D + _0023_003DzEGKj_0024SNUUihi * Math.Sin(num);
		SketchLine[] array = new SketchLine[_0023_003Dz_C5M_0024TZrmoaK];
		for (int i = 1; i < _0023_003Dz_C5M_0024TZrmoaK + 1; i++)
		{
			num = (double)i * (Math.PI * 2.0) / (double)_0023_003Dz_C5M_0024TZrmoaK + _0023_003Dz6pajdGM_003D;
			double num2 = _0023_003DztVEXAWo_003D + _0023_003DzEGKj_0024SNUUihi * Math.Cos(num);
			double num3 = _0023_003DzbqrXutw_003D + _0023_003DzEGKj_0024SNUUihi * Math.Sin(num);
			array[i - 1] = AddLine(x, y, num2, num3);
			x = num2;
			y = num3;
		}
		_0023_003Dz9EdxXqI_003D = AddConstraintPolygon(array);
		return array;
	}

	private SketchLine[] _0023_003Dz42xH9OQ_003D(int _0023_003Dz_C5M_0024TZrmoaK, double _0023_003DzEGKj_0024SNUUihi, double _0023_003Dz6pajdGM_003D, bool _0023_003DzwAD1bnhu5fmPetX54A_003D_003D, out SketchPoint _0023_003DzbUvT9Pc_003D)
	{
		double num = _0023_003DzEGKj_0024SNUUihi;
		if (_0023_003DzwAD1bnhu5fmPetX54A_003D_003D)
		{
			num = _0023_003DzEGKj_0024SNUUihi / Math.Cos(Math.PI / (double)_0023_003Dz_C5M_0024TZrmoaK);
		}
		SketchCircle sketchCircle = AddCircle(0.0, 0.0, _0023_003DzEGKj_0024SNUUihi * 2.0, diamConstraint: true, construction: true);
		_0023_003DzbUvT9Pc_003D = sketchCircle.Center;
		double num2 = 0.0 / (double)_0023_003Dz_C5M_0024TZrmoaK + _0023_003Dz6pajdGM_003D;
		double x = num * Math.Cos(num2);
		double y = num * Math.Sin(num2);
		SketchLine[] array = new SketchLine[_0023_003Dz_C5M_0024TZrmoaK];
		for (int i = 1; i < _0023_003Dz_C5M_0024TZrmoaK + 1; i++)
		{
			num2 = (double)i * (Math.PI * 2.0) / (double)_0023_003Dz_C5M_0024TZrmoaK + _0023_003Dz6pajdGM_003D;
			double num3 = num * Math.Cos(num2);
			double num4 = num * Math.Sin(num2);
			array[i - 1] = AddLine(x, y, num3, num4);
			AddConstraintPointOn(array[i - 1].StartPoint, sketchCircle);
			x = num3;
			y = num4;
		}
		for (int j = 0; j < _0023_003Dz_C5M_0024TZrmoaK - 1; j++)
		{
			AddConstraintJoin(array[j], array[j + 1]);
		}
		AddConstraintJoin(array[^1].EndPoint, array[0].StartPoint);
		for (int k = 1; k < _0023_003Dz_C5M_0024TZrmoaK; k++)
		{
			AddConstraintEqualLength(array[k], array[k - 1]);
		}
		if (_0023_003Dz6pajdGM_003D == 0.0)
		{
			AddConstraintHorizontal(array[1]);
		}
		return array;
	}

	public solveFailureType Solve(SketchItem dragTarget = null)
	{
		HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y;
		return _sketchInternal._0023_003DzOykoXtw_003D(out _0023_003Dz5PjoC_vVvm2Y, dragTarget);
	}

	public void Translate(double x, double y)
	{
		Translate(CurveList, x, y);
	}

	public void Translate(IList<SketchCurve> curves, double x, double y)
	{
		Translation _0023_003Dz63vmKM0_003D = new Translation(x, y);
		_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(curves, _0023_003Dz63vmKM0_003D, unsupportedTranslateConstraints, _0023_003DzWSPv6zs_003D: false);
	}

	public void Rotate(Point2D center, double angle)
	{
		Rotate(CurveList, center, angle);
	}

	public void Rotate(IList<SketchCurve> curves, Point2D center, double angle)
	{
		Rotation _0023_003Dz63vmKM0_003D = new Rotation(angle, Vector3D.AxisZ, new Point3D(center.X, center.Y));
		_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(curves, _0023_003Dz63vmKM0_003D, supportedRotateConstraints, _0023_003DzWSPv6zs_003D: true);
	}

	public void Scale(Point2D fixedPoint, double factorX, double factorY)
	{
		Scale(CurveList, fixedPoint, factorX, factorY);
	}

	public void Scale(IList<SketchCurve> curves, Point2D fixedPoint, double factorX, double factorY)
	{
		Scaling _0023_003Dz63vmKM0_003D = new Scaling(new Point3D(fixedPoint.X, fixedPoint.Y), factorX, factorY);
		_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(curves, _0023_003Dz63vmKM0_003D, supportedScaleConstraints, _0023_003DzWSPv6zs_003D: true);
	}

	public void Mirror(Plane plane = null)
	{
		Mirror(CurveList, plane);
	}

	public void Mirror(IList<SketchCurve> curves, Plane plane = null)
	{
		Transformation _0023_003Dz63vmKM0_003D = new Mirror(plane ?? Plane.YZ);
		_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(curves, _0023_003Dz63vmKM0_003D, unsupportedMirrorConstraints, _0023_003DzWSPv6zs_003D: false);
	}

	private void _0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(IList<SketchCurve> _0023_003DzTj1oJWREOpXS, Transformation _0023_003Dz63vmKM0_003D, Type[] _0023_003Dz5aeiFLs8BijX, bool _0023_003DzWSPv6zs_003D)
	{
		foreach (SketchPoint item in _0023_003DzTj1oJWREOpXS.SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzEqwYSQpagIXrT9ioYMVatPOW9vQt).Distinct())
		{
			_0023_003DzfkoXsQVhNX4K(item.Constraints, _0023_003DzWSPv6zs_003D, _0023_003Dz5aeiFLs8BijX);
			item._0023_003DzUNQ_t5U_003D(_0023_003Dz63vmKM0_003D);
		}
		foreach (SketchCurve item2 in _0023_003DzTj1oJWREOpXS.Where((SketchCurve _0023_003Dzt_m8zV0_003D) => !(_0023_003Dzt_m8zV0_003D is SketchPoint)))
		{
			_0023_003DzfkoXsQVhNX4K(item2.Constraints, _0023_003DzWSPv6zs_003D, _0023_003Dz5aeiFLs8BijX);
			item2._0023_003DzUNQ_t5U_003D(_0023_003Dz63vmKM0_003D);
		}
	}

	private void _0023_003DzfkoXsQVhNX4K(IEnumerable<Constraint> _0023_003DzheZZscU_003D, bool _0023_003DzWSPv6zs_003D, Type[] _0023_003DzTLd6lkE_003D)
	{
		using IEnumerator<Constraint> enumerator = _0023_003DzheZZscU_003D.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D _0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D2 = new _0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D();
			_0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D2._0023_003Dz9EdxXqI_003D = enumerator.Current;
			if (_0023_003DzWSPv6zs_003D != _0023_003DzTLd6lkE_003D.Any(_0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D2._0023_003DzXE2ScOI8Rumrq31Xjw_003D_003D))
			{
				_0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D2._0023_003Dz9EdxXqI_003D.Destroy();
			}
		}
	}

	private void _0023_003Dzqx2DhVY_003D(XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656906));
		_sketchInternal._0023_003Dzqx2DhVY_003D(_0023_003DzDdJAEBo_003D);
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private void _0023_003DzVemZ00E_003D(XmlReader _0023_003DzkKz7OWA_003D)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(_0023_003DzkKz7OWA_003D);
		_sketchInternal._0023_003DzVemZ00E_003D(xmlDocument.FirstChild, _0023_003DzHFcgloE_003D: false);
	}

	public void Write(string filePath, Formatting formatting = Formatting.Indented)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(filePath, Encoding.ASCII)
		{
			Formatting = formatting
		};
		_0023_003Dzqx2DhVY_003D(xmlTextWriter);
		xmlTextWriter.Close();
	}

	public void Read(string filePath)
	{
		XmlReader xmlReader = XmlReader.Create(filePath);
		_0023_003DzVemZ00E_003D(xmlReader);
		xmlReader.Close();
	}

	public string WriteToString()
	{
		StringWriter stringWriter = new StringWriter();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
		_0023_003Dzqx2DhVY_003D(xmlTextWriter);
		xmlTextWriter.Close();
		return stringWriter.ToString();
	}

	public void ReadFromString(string content)
	{
		XmlReader xmlReader = XmlReader.Create(new StringReader(content));
		_0023_003DzVemZ00E_003D(xmlReader);
		xmlReader.Close();
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSurface(amount);
	}

	public Surface[] ExtrudeAsSurface(double amount)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSurface(amount * SketchPlane.AxisZ);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSurface(amount, draftAngleInRadians, tolerance);
	}

	public Surface[] ExtrudeAsSurface(double amount, double draftAngleInRadians, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSurface(SketchPlane.AxisZ * amount, draftAngleInRadians, tolerance);
	}

	public Brep[] ExtrudeAsBrep(double amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions();
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].ExtrudeAsBrep(amount, angleInRadians, tolerance);
		}
		return array2;
	}

	public Brep[] ExtrudeAsBrep(Interval amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions();
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].ExtrudeAsBrep(amount, angleInRadians, tolerance);
		}
		return array2;
	}

	public Brep[] ExtrudeAsBrep(Vector3D amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions();
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].ExtrudeAsBrep(amount, angleInRadians, tolerance);
		}
		return array2;
	}

	public Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsMesh(amount, deviation, meshNature);
	}

	public T ExtrudeAsMesh<T>(double amount, double deviation, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsMesh<T>(amount, deviation, meshNature);
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsMesh(amount, deviation, angle, meshNature);
	}

	public Mesh ExtrudeAsMesh(Interval amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsMesh(amount, deviation, angle, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsMesh<T>(amount, deviation, angle, meshNature);
	}

	public Solid ExtrudeAsSolid(double x, double y, double z, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid(x, y, z, tolerance);
	}

	public T ExtrudeAsSolid<T>(double x, double y, double z, double tolerance) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid<T>(new Vector3D(x, y, z), tolerance);
	}

	public Solid ExtrudeAsSolid(double amount, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid(amount, tolerance);
	}

	public T ExtrudeAsSolid<T>(double amount, double tolerance) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid<T>(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid(amount, tolerance);
	}

	public T ExtrudeAsSolid<T>(Vector3D amount, double tolerance) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().ExtrudeAsSolid<T>(amount, tolerance);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return RevolveAsMesh(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return RevolveAsMesh<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dzy3xpVRWmFrao().RevolveAsMesh(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		T result = new T();
		_0023_003Dzy3xpVRWmFrao().RevolveAsMesh<Mesh>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
		return result;
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003Dzy3xpVRWmFrao().RevolveAsSurface(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return RevolveAsSurface(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Brep[] RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions(skipOpenContours: false);
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].RevolveAsBrep(intervalAngle, axis, center, tolerance);
		}
		return array2;
	}

	public Brep[] RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions(skipOpenContours: false);
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].RevolveAsBrep(startAngle, deltaAngle, axis, center, tolerance);
		}
		return array2;
	}

	public Brep[] RevolveAsBrep(double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		Region[] array = ConvertToRegions(skipOpenContours: false);
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].RevolveAsBrep(deltaAngle, axis, center, tolerance);
		}
		return array2;
	}

	public Brep[] RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep[] RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(intervalAngle.Low, intervalAngle.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance) where T : Solid, new()
	{
		return RevolveAsSolid<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public T RevolveAsSolid<T>(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance) where T : Solid, new()
	{
		return RevolveAsSolid<T>(intervalAngle.Low, intervalAngle.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().RevolveAsSolid(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003Dzy3xpVRWmFrao().RevolveAsSolid(intervalAngle, axis, center, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().RevolveAsSolid<T>(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsSurface(rail, tol, methodType);
	}

	public Brep[] SweepAsBrep(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Region[] array = ConvertToRegions(skipOpenContours: false);
		Brep[] array2 = new Brep[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].SweepAsBrep(rail, tol, methodType);
		}
		return array2;
	}

	public Brep[] SweepAsBrep(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Region[] array = ConvertToRegions(skipOpenContours: false);
		List<Brep> list = new List<Brep>();
		for (int i = 0; i < array.Length; i++)
		{
			list.AddRange(array[i].SweepAsBrep(rail, tol, merge, methodType));
		}
		return list.ToArray();
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsMesh(rail, tol, methodType, natureType);
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsMesh<T>(rail, tol, methodType, natureType);
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsMesh(rail, tol, merge, methodType, natureType);
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsMesh<T>(rail, tol, merge, methodType, natureType);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsSolid(rail, tolerance, sweepMethod);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsSolid<T>(rail, tolerance, sweepMethod);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsSolid(rail, tolerance, merge, sweepMethod);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return _0023_003Dzy3xpVRWmFrao().SweepAsSolid<T>(rail, tolerance, merge, sweepMethod);
	}

	private Region _0023_003Dzy3xpVRWmFrao()
	{
		Region[] array = ConvertToRegions();
		if (array != null && array.Length != 0)
		{
			return array[0];
		}
		return null;
	}

	public Region[] ConvertToRegions(bool skipOpenContours = true)
	{
		_0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(_0023_003DzcAtPIuFLCyhPxLQTtQ_003D_003D: false, _0023_003DzIz4u_00246wI5Q9M: false, out var _0023_003DzpIZC_0024x5EiUBN, out var _, _0023_003Dzmyw8uNw_003D: true);
		if (_0023_003DzpIZC_0024x5EiUBN.Length == 0)
		{
			return null;
		}
		Size3D size3D = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(_0023_003DzpIZC_0024x5EiUBN);
		double gap = Utility._0023_003DzxhnLabVjXjPg * size3D.Max;
		ICurve[] connectedCurves = Utility.GetConnectedCurves(_0023_003DzpIZC_0024x5EiUBN, gap);
		List<Region> list = new List<Region>();
		Region[] array = Utility.DetectRegionsFromContours(connectedCurves, SketchPlane);
		foreach (Region region in array)
		{
			if (!skipOpenContours && region.ContourList.Count == 1 && !region.ContourList[0].IsClosed)
			{
				list.Add(region);
			}
			if (region.IsValid())
			{
				list.Add(region);
			}
		}
		return list.ToArray();
	}

	public ICurve[] ConvertToCurves(bool keepConstructionCurves)
	{
		_0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(keepConstructionCurves, _0023_003DzIz4u_00246wI5Q9M: false, out var _0023_003DzpIZC_0024x5EiUBN, out var _, _0023_003Dzmyw8uNw_003D: true);
		return _0023_003DzpIZC_0024x5EiUBN;
	}

	public ICurve[] ConvertToCurves(bool keepConstructionCurves, out SketchCurve[] curveSketch)
	{
		_0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(keepConstructionCurves, _0023_003DzIz4u_00246wI5Q9M: false, out var _0023_003DzpIZC_0024x5EiUBN, out curveSketch, _0023_003Dzmyw8uNw_003D: true);
		return _0023_003DzpIZC_0024x5EiUBN;
	}

	public void ConvertToCurves(bool keepConstructionCurves, bool keepPoints, out ICurve[] curveList, out SketchCurve[] curveSketch)
	{
		_0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(keepConstructionCurves, keepPoints, out curveList, out curveSketch, _0023_003Dzmyw8uNw_003D: true);
	}

	internal void _0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(bool _0023_003DzcAtPIuFLCyhPxLQTtQ_003D_003D, bool _0023_003DzIz4u_00246wI5Q9M, out ICurve[] _0023_003DzpIZC_0024x5EiUBN, out SketchCurve[] _0023_003DzGs_n0KbO_6uxyZjG2Q_003D_003D, bool _0023_003Dzmyw8uNw_003D)
	{
		_0023_003DzpIZC_0024x5EiUBN = null;
		_0023_003DzGs_n0KbO_6uxyZjG2Q_003D_003D = null;
		solveFailureType solveFailureType2 = Solve();
		if (_0023_003Dzmyw8uNw_003D && solveFailureType2 != solveFailureType.Success)
		{
			throw new InvalidSketchException();
		}
		List<ICurve> list = new List<ICurve>();
		List<SketchCurve> list2 = new List<SketchCurve>();
		List<SketchCurve> curveList = CurveList;
		for (int i = 0; i < curveList.Count; i++)
		{
			SketchCurve sketchCurve = curveList[i];
			ICurve item = ((sketchCurve._0023_003DzZ_ilKakl9sw5() != null) ? ((ICurve)sketchCurve._0023_003DzZ_ilKakl9sw5().Clone()) : sketchCurve._0023_003DzxXXV_0024fQ_003D());
			if (sketchCurve is SketchPoint)
			{
				if (_0023_003DzIz4u_00246wI5Q9M)
				{
					list.Add(item);
					list2.Add(sketchCurve);
				}
			}
			else if (sketchCurve.Construction)
			{
				if (_0023_003DzcAtPIuFLCyhPxLQTtQ_003D_003D)
				{
					list.Add(item);
					list2.Add(sketchCurve);
				}
			}
			else
			{
				list.Add(item);
				list2.Add(sketchCurve);
			}
		}
		_0023_003DzpIZC_0024x5EiUBN = list.ToArray();
		_0023_003DzGs_n0KbO_6uxyZjG2Q_003D_003D = list2.ToArray();
	}

	public virtual SketchSurrogate ConvertToSurrogate()
	{
		return new SketchSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656781), _sketchInternal);
	}

	public object Clone()
	{
		return new Sketch(this);
	}

	private T _0023_003DzQCEY3y0YzX38<T>(T _0023_003Dz95Fqw_A_003D, double _0023_003DzPzO_0024GUk_003D) where T : ValueConstraint
	{
		_0023_003Dz95Fqw_A_003D.SetValue(_0023_003DzPzO_0024GUk_003D);
		return _0023_003Dz95Fqw_A_003D;
	}

	public LengthConstraint AddConstraintLength(SketchCurve curve)
	{
		return new LengthConstraint(_sketchInternal, curve);
	}

	public LengthConstraint AddConstraintLength(SketchCurve curve, double length)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintLength(curve), length);
	}

	public DiameterConstraint AddConstraintDiameter(SketchCurve curve)
	{
		return new DiameterConstraint(_sketchInternal, curve);
	}

	public DiameterConstraint AddConstraintDiameter(SketchCurve curve, double diameter)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintDiameter(curve), diameter);
	}

	public RadiusConstraint AddConstraintRadius(SketchCurve curve)
	{
		return new RadiusConstraint(_sketchInternal, curve);
	}

	public RadiusConstraint AddConstraintRadius(SketchCurve curve, double radius)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintRadius(curve), radius);
	}

	public EqualConstraint AddConstraintEqualLength(SketchCurve entity1, SketchCurve entity2)
	{
		EqualConstraint equalConstraint = new EqualConstraint(_sketchInternal, entity1, entity2);
		equalConstraint._0023_003DzVUUc_0024UKEScLr(EqualConstraint.LengthType.Length);
		equalConstraint._0023_003DzP6E_df8i8jgA(EqualConstraint.LengthType.Length);
		return equalConstraint;
	}

	public EqualConstraint AddConstraintEqualRadius(SketchCircle circle1, SketchCircle circle2)
	{
		EqualConstraint equalConstraint = new EqualConstraint(_sketchInternal, circle1, circle2);
		equalConstraint._0023_003DzVUUc_0024UKEScLr(EqualConstraint.LengthType.Radius);
		equalConstraint._0023_003DzP6E_df8i8jgA(EqualConstraint.LengthType.Radius);
		return equalConstraint;
	}

	public HVConstraint AddConstraintVertical(SketchLine sketchLine)
	{
		return new HVConstraint(_sketchInternal, sketchLine)
		{
			orientation = hvOrientation.OX
		};
	}

	public void AddConstraintVertical(params SketchLine[] sketchLines)
	{
		foreach (SketchLine sketchLine in sketchLines)
		{
			AddConstraintVertical(sketchLine);
		}
	}

	public HVConstraint AddConstraintHorizontal(SketchLine sketchLine)
	{
		return new HVConstraint(_sketchInternal, sketchLine)
		{
			orientation = hvOrientation.OY
		};
	}

	public void AddConstraintHorizontal(params SketchLine[] sketchLines)
	{
		foreach (SketchLine sketchLine in sketchLines)
		{
			AddConstraintHorizontal(sketchLine);
		}
	}

	public HVConstraint AddConstraintVertical(SketchPoint a, SketchPoint b)
	{
		return new HVConstraint(_sketchInternal, a, b)
		{
			orientation = hvOrientation.OX
		};
	}

	public HVConstraint AddConstraintHorizontal(SketchPoint a, SketchPoint b)
	{
		return new HVConstraint(_sketchInternal, a, b)
		{
			orientation = hvOrientation.OY
		};
	}

	public PointOnConstraint AddConstraintPointOn(SketchPoint point, SketchCurve curve)
	{
		return new PointOnConstraint(_sketchInternal, point, curve);
	}

	public PointAtConstraint AddConstraintPointAt(SketchPoint point, SketchCurve curve, double value)
	{
		return new PointAtConstraint(_sketchInternal, point, curve, value);
	}

	public MidPointConstraint AddConstraintMidPoint(SketchPoint point, SketchCurve curve)
	{
		return new MidPointConstraint(_sketchInternal, point, curve);
	}

	public PointOnConstraint AddConstraintPointOn(SketchPoint point, SketchCurve curve, double value)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintPointOn(point, curve), value);
	}

	public AngleConstraint AddConstraintAngle(SketchArc sketchArc)
	{
		return new AngleConstraint(_sketchInternal, sketchArc);
	}

	public AngleConstraint AddConstraintAngle(SketchPoint sketchPointStart, SketchPoint sketchPointCenter, SketchPoint sketchPointEnd)
	{
		return new AngleConstraint(_sketchInternal, new SketchCurve[3] { sketchPointStart, sketchPointCenter, sketchPointEnd });
	}

	public AngleConstraint AddConstraintAngle(SketchPoint sketchPointStart, SketchPoint sketchPointCenter, SketchPoint sketchPointEnd, double value)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintAngle(sketchPointStart, sketchPointCenter, sketchPointEnd), value);
	}

	public AngleConstraint AddConstraintAngle(SketchArc sketchArc, double value)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintAngle(sketchArc), value);
	}

	public AngleConstraint AddConstraintAngle(SketchLine line1, SketchLine line2)
	{
		return new AngleConstraint(_sketchInternal, line1, line2);
	}

	public AngleConstraint AddConstraintAngle(SketchLine sketchLine1, SketchLine sketchLine2, double angle)
	{
		AngleConstraint angleConstraint = AddConstraintAngle(sketchLine1, sketchLine2);
		return _0023_003DzQCEY3y0YzX38(angleConstraint, (double)Math.Sign(angleConstraint.GetValue()) * Math.Abs(angle));
	}

	public AngleConstraint AddConstraintAngle(SketchLine sketchLine1, SketchLine sketchLine2, Point2D quadrantPoint)
	{
		Segment2D segment2D = new Segment2D(sketchLine1.StartPoint.PlanePosition, sketchLine1.EndPoint.PlanePosition);
		Segment2D segment2D2 = new Segment2D(sketchLine2.StartPoint.PlanePosition, sketchLine2.EndPoint.PlanePosition);
		VectorClock vectorClock = new VectorClock(segment2D, segment2D2);
		if (!Segment2D.IntersectionLine(segment2D, segment2D2, out var i))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656627));
		}
		int num = vectorClock.Quadrant(quadrantPoint - i);
		AngleConstraint angleConstraint = new AngleConstraint(_sketchInternal, sketchLine1, sketchLine2);
		angleConstraint._0023_003DzA_WUrzZQ5SEjFakyKPc32NE_003D(vectorClock.SwappedAxis == (num == 1 || num == 3));
		return angleConstraint;
	}

	public AngleConstraint AddConstraintAngle(SketchLine line1, SketchLine line2, Point2D quadrantPoint, double angle)
	{
		AngleConstraint angleConstraint = AddConstraintAngle(line1, line2, quadrantPoint);
		return _0023_003DzQCEY3y0YzX38(angleConstraint, (double)Math.Sign(angleConstraint.GetValue()) * Math.Abs(angle));
	}

	public PolygonConstraint AddConstraintPolygon(SketchLine[] sides, out SketchPoint polygonCenter)
	{
		PolygonConstraint polygonConstraint = new PolygonConstraint(_sketchInternal, sides);
		polygonCenter = polygonConstraint.Center;
		return polygonConstraint;
	}

	public PolygonConstraint AddConstraintPolygon(SketchLine[] sides, SketchPoint center = null)
	{
		return new PolygonConstraint(_sketchInternal, sides, center);
	}

	public ParallelConstraint AddConstraintParallel(SketchCurve entity1, SketchCurve entity2)
	{
		return new ParallelConstraint(_sketchInternal, entity1, entity2);
	}

	public PerpendicularConstraint AddConstraintPerpendicular(SketchCurve entity1, SketchCurve entity2)
	{
		return new PerpendicularConstraint(_sketchInternal, entity1, entity2);
	}

	public CollinearPointsConstraint AddConstraintCollinear(SketchPoint p1, SketchPoint p2, SketchPoint p3)
	{
		return new CollinearPointsConstraint(_sketchInternal, p1, p2, p3);
	}

	public HorizontalPointsDistanceConstraint AddConstraintHorizontalDistance(SketchPoint point1, SketchPoint point2)
	{
		return new HorizontalPointsDistanceConstraint(_sketchInternal, point1, point2);
	}

	public VerticalPointsDistanceConstraint AddConstraintVerticalDistance(SketchPoint point1, SketchPoint point2)
	{
		return new VerticalPointsDistanceConstraint(_sketchInternal, point1, point2);
	}

	public PointsDistanceConstraint AddConstraintDistance(SketchPoint point1, SketchPoint point2)
	{
		return new PointsDistanceConstraint(_sketchInternal, point1, point2);
	}

	public PointsDistanceConstraint AddConstraintDistance(SketchPoint point1, SketchPoint point2, double distance)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintDistance(point1, point2), distance);
	}

	public HorizontalPointsDistanceConstraint AddConstraintHorizontalDistance(SketchPoint point1, SketchPoint point2, double distance)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintHorizontalDistance(point1, point2), distance);
	}

	public VerticalPointsDistanceConstraint AddConstraintVerticalDistance(SketchPoint point1, SketchPoint point2, double distance)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintVerticalDistance(point1, point2), distance);
	}

	public LinesDistanceConstraint AddConstraintDistance(SketchLine line1, SketchLine line2)
	{
		return new LinesDistanceConstraint(_sketchInternal, line1, line2);
	}

	public LinesDistanceConstraint AddConstraintDistance(SketchLine entity1, SketchLine entity2, double distance)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintDistance(entity1, entity2), distance);
	}

	public PointLineDistanceConstraint AddConstraintDistance(SketchPoint point, SketchLine line)
	{
		return new PointLineDistanceConstraint(_sketchInternal, point, line);
	}

	public PointLineDistanceConstraint AddConstraintDistance(SketchPoint point, SketchLine line, double distance)
	{
		return _0023_003DzQCEY3y0YzX38(AddConstraintDistance(point, line), distance);
	}

	public CoincidentConstraint AddConstraintJoin(SketchPoint point1, SketchPoint point2)
	{
		return new CoincidentConstraint(_sketchInternal, point1, point2);
	}

	public CoincidentConstraint AddConstraintConcentric(SketchCircle circle1, SketchCircle circle2)
	{
		return new CoincidentConstraint(_sketchInternal, circle1.Center, circle2.Center);
	}

	public ConcentricCirclesDistanceConstraint AddConstraintConcentricDistance(SketchCircle circle1, SketchCircle circle2)
	{
		return new ConcentricCirclesDistanceConstraint(_sketchInternal, circle1, circle2);
	}

	public void AddConstraintFixedPoint(SketchCurve sketchCurve)
	{
		new PointFixedConstraint(_sketchInternal, sketchCurve._0023_003DzgJiUT1qDtKLT().ToList()[0]);
	}

	private double _0023_003Dz1UvcOKOlO_k_0024(SketchPoint _0023_003DzlY77YgY_003D, ISketchCurve _0023_003Dz8fpRyMu9aKjE, out bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D)
	{
		double num = _0023_003DzlY77YgY_003D.PlanePosition.DistanceTo(_0023_003Dz8fpRyMu9aKjE.StartPoint.PlanePosition);
		double num2 = _0023_003DzlY77YgY_003D.PlanePosition.DistanceTo(_0023_003Dz8fpRyMu9aKjE.EndPoint.PlanePosition);
		if (!(_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D = num < num2))
		{
			return num2;
		}
		return num;
	}

	private double _0023_003Dz1UvcOKOlO_k_0024(SketchPoint _0023_003DzlY77YgY_003D, LinkedList<ISketchCurve> _0023_003DznAREz44_pB8t, out LinkedListNode<ISketchCurve> _0023_003Dzv_00241u4AU_003D, out bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D)
	{
		double num = -1.0;
		_0023_003Dzv_00241u4AU_003D = null;
		_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D = false;
		for (LinkedListNode<ISketchCurve> linkedListNode = _0023_003DznAREz44_pB8t.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			if (linkedListNode.Value.StartPoint != _0023_003DzlY77YgY_003D && linkedListNode.Value.EndPoint != _0023_003DzlY77YgY_003D)
			{
				bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2;
				double num2 = _0023_003Dz1UvcOKOlO_k_0024(_0023_003DzlY77YgY_003D, linkedListNode.Value, out _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2);
				if (_0023_003Dzv_00241u4AU_003D == null || num2 < num)
				{
					_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D = _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2;
					num = num2;
					_0023_003Dzv_00241u4AU_003D = linkedListNode;
				}
			}
		}
		return num;
	}

	public CoincidentConstraint[] AddConstraintJoin(params ISketchCurve[] entities)
	{
		if (entities.Length < 2)
		{
			return new CoincidentConstraint[0];
		}
		CoincidentConstraint[] array = new CoincidentConstraint[entities.Length - 1];
		LinkedList<ISketchCurve> linkedList = new LinkedList<ISketchCurve>(entities);
		LinkedListNode<ISketchCurve> _0023_003Dzv_00241u4AU_003D;
		bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D;
		double num = _0023_003Dz1UvcOKOlO_k_0024(linkedList.First.Value.StartPoint, linkedList, out _0023_003Dzv_00241u4AU_003D, out _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D);
		double num2 = _0023_003Dz1UvcOKOlO_k_0024(linkedList.First.Value.EndPoint, linkedList, out _0023_003Dzv_00241u4AU_003D, out _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D);
		SketchPoint sketchPoint = ((num < num2) ? linkedList.First.Value.StartPoint : linkedList.First.Value.EndPoint);
		for (int i = 0; i < entities.Length - 1; i++)
		{
			linkedList.RemoveFirst();
			_0023_003Dz1UvcOKOlO_k_0024(sketchPoint, linkedList, out var _0023_003Dzv_00241u4AU_003D2, out var _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2);
			SketchPoint _0023_003DzFj_0024IqDQ_003D = (_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2 ? _0023_003Dzv_00241u4AU_003D2.Value.StartPoint : _0023_003Dzv_00241u4AU_003D2.Value.EndPoint);
			array[i] = new CoincidentConstraint(_sketchInternal, sketchPoint, _0023_003DzFj_0024IqDQ_003D);
			sketchPoint = (_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2 ? _0023_003Dzv_00241u4AU_003D2.Value.EndPoint : _0023_003Dzv_00241u4AU_003D2.Value.StartPoint);
			_0023_003Dzv_00241u4AU_003D2.Value = linkedList.First.Value;
		}
		return array;
	}

	public CoincidentConstraint AddConstraintJoin(ISketchCurve entityA, ISketchCurve entityB)
	{
		bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D;
		double num = _0023_003Dz1UvcOKOlO_k_0024(entityA.StartPoint, entityB, out _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D);
		bool _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2;
		double num2 = _0023_003Dz1UvcOKOlO_k_0024(entityA.EndPoint, entityB, out _0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2);
		if (num < num2)
		{
			if (!_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D)
			{
				return new CoincidentConstraint(_sketchInternal, entityA.StartPoint, entityB.EndPoint);
			}
			return new CoincidentConstraint(_sketchInternal, entityA.StartPoint, entityB.StartPoint);
		}
		if (!_0023_003Dz_cKAbtfonTWKy0roBw_003D_003D2)
		{
			return new CoincidentConstraint(_sketchInternal, entityA.EndPoint, entityB.EndPoint);
		}
		return new CoincidentConstraint(_sketchInternal, entityA.EndPoint, entityB.StartPoint);
	}

	public MirrorConstraint AddConstraintMirror(SketchCurve ent1, SketchCurve ent2, SketchLine axis)
	{
		if (ent1.GetType() != ent2.GetType())
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656577));
		}
		return new MirrorConstraint(_sketchInternal, ent1, ent2, axis);
	}

	public TangentConstraint AddConstraintTangent(SketchCurve ent1, SketchCurve ent2)
	{
		return new TangentConstraint(_sketchInternal, ent1, ent2);
	}

	public CollinearConstraint AddConstraintCollinear(SketchCurve line1, SketchCurve line2)
	{
		return new CollinearConstraint(_sketchInternal, line1, line2);
	}

	public IEnumerable<Constraint> GetRedundantConstraints()
	{
		return _sketchInternal._0023_003DzcY5bzszfS2iK();
	}

	public bool IsValid(Constraint constraint)
	{
		return _sketchInternal._0023_003Dzqh_BTJs_003D(constraint);
	}
}
