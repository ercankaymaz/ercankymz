using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Geometry;

public class UtilityEx : Utility
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<MethodInfo, bool> _0023_003DzjTm_0024W0PepbRQmziXzw_003D_003D;

		public static Func<MethodInfo, bool> _0023_003DzhCyhPHkj8tLUT0uS3A_003D_003D;

		internal bool _0023_003DzOikUf8WV6k2Is8K9bOpWsKg1JOFs_T5Kdw_003D_003D(MethodInfo _0023_003DzLtLprGE_003D)
		{
			return _0023_003DzLtLprGE_003D.GetCustomAttributes(typeof(AmbientValueAttribute), inherit: false).Length != 0;
		}

		internal bool _0023_003DzLgV8q1PiKT2ICKRJ0ZJSh8ODXkP0qxUB6g_003D_003D(MethodInfo _0023_003DzLtLprGE_003D)
		{
			return _0023_003DzLtLprGE_003D.GetParameters().Length == 1;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static MethodInfo _0023_003DzXhfqTFjlw4iPPpKK2xgqKSk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static SizeF _0023_003Dz5Bf5v8YOXRun = SizeF.Empty;

	public static LinearDim DrawLinearDimPreview(Workspace workSpace, Plane dimPlane, Point3D extLine1, Point3D extLine2, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		Plane plane = dimPlane.Clone() as Plane;
		Point3D[] array = new Point3D[2];
		Point2D[] array2 = new Point2D[2];
		array[0] = extLine1.Clone() as Point3D;
		array[1] = extLine2.Clone() as Point3D;
		if (workSpace.CurrentTransformation != null)
		{
			plane.TransformBy(workSpace.CurrentTransformation);
			array[0].TransformBy(workSpace.CurrentTransformation);
			array[1].TransformBy(workSpace.CurrentTransformation);
		}
		workSpace.ScreenToPlane(mousePos, plane, out var intPoint);
		array2[0] = plane.Project(array[0]);
		array2[1] = plane.Project(array[1]);
		Point2D point2D = plane.Project(intPoint);
		if (_0023_003Dz8x_2BNo_003D(array2[0], array2[1], point2D))
		{
			return DrawLinearDimPreview(workSpace, dimPlane, new Line(extLine1, extLine2), mousePos, previewDrawParams);
		}
		Vector3D vector3D;
		Point2D pt;
		Point2D pt2;
		if ((point2D.X > array2[0].X && point2D.X > array2[1].X) || (point2D.X < array2[0].X && point2D.X < array2[1].X))
		{
			vector3D = dimPlane.AxisY;
			pt = new Point3D(array2[0].X, array2[0].Y);
			pt2 = new Point3D(array2[0].X, array2[1].Y);
		}
		else
		{
			vector3D = dimPlane.AxisX;
			pt = new Point3D(array2[0].X, array2[0].Y);
			pt2 = new Point3D(array2[1].X, array2[0].Y);
		}
		Vector3D y = Vector3D.Cross(dimPlane.AxisZ, vector3D);
		return _0023_003DzwGFC0Rk082BgPgvIvg_003D_003D(workSpace, new Plane(dimPlane.PointAt(pt), vector3D, y), new Line(dimPlane.PointAt(pt), dimPlane.PointAt(pt2)), mousePos, previewDrawParams, array[0], array[1]);
	}

	public static LinearDim DrawLinearDimPreview(Workspace workSpace, Plane dimPlane, Line line, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return _0023_003DzwGFC0Rk082BgPgvIvg_003D_003D(workSpace, dimPlane, line, mousePos, previewDrawParams, null, null);
	}

	private static LinearDim _0023_003DzwGFC0Rk082BgPgvIvg_003D_003D(Workspace _0023_003DzrWsecjleHtud, Plane _0023_003Dz4QnibOYoOZnkuhlugQ_003D_003D, Line _0023_003DzunkZy48_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, DimensionPreviewDrawParams _0023_003DzH3bEyMTjmB7r, Point3D _0023_003DzT2MfhCjZUoVZ, Point3D _0023_003Dz93rC0W4PrnNW)
	{
		Color currentWireColor = _0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.CurrentWireColor;
		float currentLineWidth = _0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.CurrentLineWidth;
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzH3bEyMTjmB7r.Color);
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetLineSize(_0023_003DzH3bEyMTjmB7r.LineSize);
		Plane plane = _0023_003Dz4QnibOYoOZnkuhlugQ_003D_003D.Clone() as Plane;
		Point3D[] array = new Point3D[2]
		{
			_0023_003DzunkZy48_003D.StartPoint.Clone() as Point3D,
			_0023_003DzunkZy48_003D.EndPoint.Clone() as Point3D
		};
		if (_0023_003DzrWsecjleHtud.CurrentTransformation != null)
		{
			plane.TransformBy(_0023_003DzrWsecjleHtud.CurrentTransformation);
			array[0].TransformBy(_0023_003DzrWsecjleHtud.CurrentTransformation);
			array[1].TransformBy(_0023_003DzrWsecjleHtud.CurrentTransformation);
		}
		Point2D[] array2 = new Point2D[2]
		{
			plane.Project(array[0]),
			plane.Project(array[1])
		};
		int num = 1;
		bool flag = array2[0].X > array2[num].X || (Utility.AreEqual(array2[0].X, array2[1].X, double.MaxValue) && array2[0].Y > array2[1].Y);
		_0023_003DzrWsecjleHtud.ScreenToPlane(_0023_003DzTYCHRugcseEq, plane, out var intPoint);
		Point3D point3D = (Point3D)intPoint.Clone();
		Point3D point3D2 = (Point3D)array[flag ? num : 0].Clone();
		Point3D point3D3 = (Point3D)array[(!flag) ? num : 0].Clone();
		Vector3D vector3D = new Vector3D(point3D2, point3D3);
		Vector3D vector3D2 = Vector3D.Cross(plane.AxisZ, vector3D);
		List<Point3D> list = new List<Point3D>();
		Plane plane2 = ((!(point3D2.X - point3D3.X > 1E-06)) ? new Plane(point3D2, vector3D, vector3D2) : new Plane(point3D2, -1.0 * vector3D, -1.0 * vector3D2));
		Point2D point2D = new Plane(point3D2, vector3D, vector3D2).Project(point3D);
		Segment3D seg = new Segment3D(point3D2, point3D3);
		double num2 = point3D.DistanceTo(seg);
		if (point2D.Y > 0.0)
		{
			num2 *= -1.0;
		}
		Point3D start = (Point3D)point3D2.Clone();
		Point3D end = (Point3D)point3D3.Clone();
		Line line = (Line)new Line(start, end).Offset(num2, plane2.AxisZ)[0];
		if (_0023_003DzT2MfhCjZUoVZ == null)
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(point3D2));
		}
		else if (flag)
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(_0023_003Dz93rC0W4PrnNW));
		}
		else
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(_0023_003DzT2MfhCjZUoVZ));
		}
		list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(line.StartPoint));
		if (_0023_003Dz93rC0W4PrnNW == null)
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(point3D3));
		}
		else if (flag)
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(_0023_003DzT2MfhCjZUoVZ));
		}
		else
		{
			list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(_0023_003Dz93rC0W4PrnNW));
		}
		list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(line.EndPoint));
		Segment3D seg2 = new Segment3D(point3D2, line.StartPoint);
		Segment3D seg3 = new Segment3D(point3D3, line.EndPoint);
		Point3D point = point3D.ProjectTo(seg2);
		Point3D point2 = point3D.ProjectTo(seg3);
		list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(point));
		list.Add(_0023_003DzrWsecjleHtud.WorldToScreen(point2));
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLines(list.ToArray());
		Point3D point3D4 = intPoint.Clone() as Point3D;
		if (_0023_003DzrWsecjleHtud._0023_003DzFq8cO_00245h9dst() != null)
		{
			point3D4.TransformBy(_0023_003DzrWsecjleHtud._0023_003DzFq8cO_00245h9dst());
		}
		LinearDim linearDim = new LinearDim(plane2, point3D2, point3D3, point3D4, _0023_003DzH3bEyMTjmB7r.TextHeight);
		Point3D point3D5 = ((intPoint.DistanceTo(line.StartPoint) < intPoint.DistanceTo(line.EndPoint)) ? line.StartPoint : line.EndPoint);
		Vector3D vector3D3 = new Vector3D(point3D5, intPoint);
		vector3D3.Normalize();
		Vector3D _0023_003Dzv_0024Gzcjk_003D = plane2.AxisY.Clone() as Vector3D;
		_0023_003DzSv05nkLpzEnu(_0023_003DzrWsecjleHtud, _0023_003DzH3bEyMTjmB7r, linearDim);
		double num3 = new Segment3D(line.StartPoint, line.EndPoint).Project(intPoint);
		_0023_003DzxA2Q_0024Ub4u0Bp(_0023_003DzrWsecjleHtud, linearDim, intPoint, point3D5, vector3D3, _0023_003Dzv_0024Gzcjk_003D, linearDim.WidthFactor, num3 < 0.0 || num3 > 1.0, _0023_003DzH3bEyMTjmB7r);
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetColorWireframe(currentWireColor);
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetLineSize(currentLineWidth);
		if (_0023_003DzrWsecjleHtud.CurrentTransformation != null)
		{
			linearDim.TransformBy(_0023_003DzrWsecjleHtud._0023_003DzFq8cO_00245h9dst());
		}
		return linearDim;
	}

	public static RadialDim DrawRadialDimPreview(Workspace workSpace, Circle circle, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return _0023_003DzIkYOSxXM6T4mWK9k5A_003D_003D(workSpace, circle.Plane, circle, mousePos, previewDrawParams, _0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D: false);
	}

	public static RadialDim DrawRadialDimPreview(Workspace workSpace, Plane dimPlane, Circle circle, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return _0023_003DzIkYOSxXM6T4mWK9k5A_003D_003D(workSpace, dimPlane, circle, mousePos, previewDrawParams, _0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D: false);
	}

	public static DiametricDim DrawDiametricDimPreview(Workspace workSpace, Circle circle, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return _0023_003DzIkYOSxXM6T4mWK9k5A_003D_003D(workSpace, circle.Plane, circle, mousePos, previewDrawParams, _0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D: true) as DiametricDim;
	}

	public static DiametricDim DrawDiametricDimPreview(Workspace workSpace, Plane dimPlane, Circle circle, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return _0023_003DzIkYOSxXM6T4mWK9k5A_003D_003D(workSpace, dimPlane, circle, mousePos, previewDrawParams, _0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D: true) as DiametricDim;
	}

	private static RadialDim _0023_003DzIkYOSxXM6T4mWK9k5A_003D_003D(Workspace _0023_003DzrWsecjleHtud, Plane _0023_003Dz4QnibOYoOZnkuhlugQ_003D_003D, Circle _0023_003DzYWGeNiFltsHT, System.Drawing.Point _0023_003DzUbpRylvVcgm7, DimensionPreviewDrawParams _0023_003DzH3bEyMTjmB7r, bool _0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D)
	{
		Circle circle = (Circle)_0023_003DzYWGeNiFltsHT.Clone();
		Plane plane = _0023_003Dz4QnibOYoOZnkuhlugQ_003D_003D.Clone() as Plane;
		if (_0023_003DzrWsecjleHtud.CurrentTransformation != null)
		{
			circle.TransformBy(_0023_003DzrWsecjleHtud.CurrentTransformation);
			plane.TransformBy(_0023_003DzrWsecjleHtud.CurrentTransformation);
		}
		_0023_003DzrWsecjleHtud.ScreenToPlane(_0023_003DzUbpRylvVcgm7, plane, out var intPoint);
		Color currentWireColor = _0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.CurrentWireColor;
		float currentLineWidth = _0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.CurrentLineWidth;
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzH3bEyMTjmB7r.Color);
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetLineSize(_0023_003DzH3bEyMTjmB7r.LineSize);
		RadialDim radialDim = ((!_0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D) ? new RadialDim(_0023_003DzYWGeNiFltsHT, intPoint, _0023_003DzH3bEyMTjmB7r.TextHeight) : new DiametricDim(_0023_003DzYWGeNiFltsHT, intPoint, _0023_003DzH3bEyMTjmB7r.TextHeight));
		_0023_003DzSv05nkLpzEnu(_0023_003DzrWsecjleHtud, _0023_003DzH3bEyMTjmB7r, radialDim);
		radialDim.LinearScale = _0023_003DzH3bEyMTjmB7r.DistancesScaleFactor;
		RegenParams visualRefinement = _0023_003DzrWsecjleHtud.GetVisualRefinement();
		radialDim.PrepareText(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, _0023_003DzrWsecjleHtud), ref _0023_003DzH3bEyMTjmB7r.WidthFactor, out var width, out var _, out var _, out var _);
		Vector3D vector3D = new Vector3D(circle.Center, intPoint);
		vector3D.Normalize();
		Point2D point2D = new Plane(circle.Plane.Origin, plane.AxisX, plane.AxisY).Project(intPoint);
		Vector3D vector3D2 = (Utility.TextNeedsToBeFlippedAccordingToDrawingRules(Math.Atan2(x: point2D.X, y: point2D.Y) - Math.PI / 2.0) ? Vector3D.Cross(vector3D, plane.AxisZ) : Vector3D.Cross(plane.AxisZ, vector3D));
		Point3D point3D = intPoint + 0.5 * width * vector3D;
		Point3D point3D2 = circle.Center + circle.Radius * vector3D;
		if (intPoint.DistanceTo(point3D2) < 0.5 * width)
		{
			point3D = ((!(intPoint.DistanceTo(_0023_003DzYWGeNiFltsHT.Center) > _0023_003DzYWGeNiFltsHT.Radius)) ? point3D2 : (point3D2 + width * vector3D));
		}
		if (_0023_003Dzazdg8kk4uNYwtYD9fw_003D_003D)
		{
			_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLine(_0023_003DzrWsecjleHtud.WorldToScreen(circle.Center - circle.Radius * vector3D), _0023_003DzrWsecjleHtud.WorldToScreen(circle.Center + circle.Radius * vector3D));
		}
		else
		{
			_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLine(_0023_003DzrWsecjleHtud.WorldToScreen(circle.Center), _0023_003DzrWsecjleHtud.WorldToScreen(circle.Center + circle.Radius * vector3D));
		}
		Point3D point3D3 = point3D + radialDim.TextGap * vector3D2;
		Point3D point3D4 = point3D + (radialDim.Height + radialDim.TextGap) * vector3D2;
		Point3D point3D5 = point3D4 - vector3D * width;
		Point3D point3D6 = point3D5 - vector3D2 * radialDim.Height;
		Point3D[] pointList = new Point3D[4] { point3D3, point3D4, point3D5, point3D6 };
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLineLoop(_0023_003DzrWsecjleHtud.WorldToScreen(pointList));
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLine(_0023_003DzrWsecjleHtud.WorldToScreen(point3D2), _0023_003DzrWsecjleHtud.WorldToScreen(point3D));
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetColorWireframe(currentWireColor);
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.SetLineSize(currentLineWidth);
		return radialDim;
	}

	public static AngularDim DrawAngularDimPreview(Workspace workSpace, Plane dimPlane, Line firstLine, Line secondLine, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		Color currentWireColor = workSpace._0023_003DzmNZD0Zs_003D.CurrentWireColor;
		float currentLineWidth = workSpace._0023_003DzmNZD0Zs_003D.CurrentLineWidth;
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(previewDrawParams.Color);
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(previewDrawParams.LineSize);
		Plane plane = dimPlane.Clone() as Plane;
		Line line = firstLine.Clone() as Line;
		Line line2 = secondLine.Clone() as Line;
		if (workSpace.CurrentTransformation != null)
		{
			line.TransformBy(workSpace.CurrentTransformation);
			line2.TransformBy(workSpace.CurrentTransformation);
			plane.TransformBy(workSpace.CurrentTransformation);
		}
		workSpace.ScreenToPlane(mousePos, plane, out var intPoint);
		Segment3D.Intersection(new Segment3D(line.StartPoint, line.EndPoint), new Segment3D(line2.StartPoint, line2.EndPoint), infinite: true, out var pointOnA, out var pointOnB);
		Segment2D segment2D = new Segment2D(plane.Project(line.StartPoint), plane.Project(line.EndPoint));
		int quadIndex;
		Interval interval = new VectorClock(secAxis: new Segment2D(plane.Project(line2.StartPoint), plane.Project(line2.EndPoint)), mainAxis: segment2D).Locate(plane.Project(intPoint) - plane.Project(pointOnA), out quadIndex);
		workSpace._0023_003DzmNZD0Zs_003D.DrawPoints(new Point3D[1] { workSpace.WorldToScreen(pointOnA) });
		Arc arc = new Arc(plane, pointOnA, intPoint.DistanceTo(pointOnA), interval.Low, interval.High);
		arc.Regen(workSpace.GetVisualRefinement());
		workSpace._0023_003DzmNZD0Zs_003D.DrawLineStrip(workSpace.WorldToScreen(arc.Vertices));
		workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(arc.StartPoint), workSpace.WorldToScreen(arc.Center));
		workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(arc.EndPoint), workSpace.WorldToScreen(arc.Center));
		Point3D point = ((line.StartPoint.DistanceTo(pointOnA) > line.EndPoint.DistanceTo(pointOnA)) ? line.EndPoint : line.StartPoint);
		if (!(line2.StartPoint.DistanceTo(pointOnA) > line2.EndPoint.DistanceTo(pointOnA)))
		{
			_ = line2.StartPoint;
		}
		else
		{
			_ = line2.EndPoint;
		}
		if (!plane.PointAt(pointOnA).IsOnCurve(line, 1E-06))
		{
			workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(point), workSpace.WorldToScreen(arc.Center));
		}
		if (!plane.PointAt(pointOnA).IsOnCurve(line2, 1E-06))
		{
			workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(point), workSpace.WorldToScreen(arc.Center));
		}
		Point3D point3D = intPoint.Clone() as Point3D;
		if (workSpace._0023_003DzFq8cO_00245h9dst() != null)
		{
			point3D.TransformBy(workSpace._0023_003DzFq8cO_00245h9dst());
		}
		AngularDim angularDim = new AngularDim(dimPlane, firstLine, secondLine, point3D, point3D, previewDrawParams.TextHeight);
		_0023_003DzSv05nkLpzEnu(workSpace, previewDrawParams, angularDim);
		RegenParams visualRefinement = workSpace.GetVisualRefinement();
		angularDim.PrepareText(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, workSpace), ref previewDrawParams.WidthFactor, out var width, out var _, out pointOnB, out var _);
		Vector3D vector3D = new Vector3D(intPoint, arc.Center);
		vector3D.Normalize();
		Point2D point2D = angularDim.Plane.Project(angularDim.DimLinePosition);
		if (Utility.TextNeedsToBeFlippedAccordingToDrawingRules(Utility.ArcTanProblem(point2D.X, point2D.Y) + Math.PI / 6.0))
		{
			vector3D.Negate();
		}
		Vector3D vector3D2 = Vector3D.Cross(vector3D, plane.AxisZ);
		Point3D point3D2 = intPoint + 0.5 * width * vector3D2;
		Point3D point3D3 = point3D2 + angularDim.TextGap * vector3D;
		Point3D point3D4 = point3D2 + (angularDim.Height + angularDim.TextGap) * vector3D;
		Point3D point3D5 = point3D4 - vector3D2 * width;
		Point3D point3D6 = point3D5 - vector3D * angularDim.Height;
		Point3D[] pointList = new Point3D[4] { point3D3, point3D4, point3D5, point3D6 };
		workSpace._0023_003DzmNZD0Zs_003D.DrawLineLoop(workSpace.WorldToScreen(pointList));
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(currentLineWidth);
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(currentWireColor);
		return angularDim;
	}

	public static AngularDim DrawAngularDimPreview(Workspace workSpace, Arc arc, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		Color currentWireColor = workSpace._0023_003DzmNZD0Zs_003D.CurrentWireColor;
		float currentLineWidth = workSpace._0023_003DzmNZD0Zs_003D.CurrentLineWidth;
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(previewDrawParams.Color);
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(previewDrawParams.LineSize);
		Arc arc2 = arc.Clone() as Arc;
		if (workSpace.CurrentTransformation != null)
		{
			arc2.TransformBy(workSpace.CurrentTransformation);
		}
		workSpace.ScreenToPlane(mousePos, arc2.Plane, out var intPoint);
		Point3D center = arc2.Center;
		workSpace._0023_003DzmNZD0Zs_003D.DrawPoints(new Point3D[1] { workSpace.WorldToScreen(center) });
		Arc arc3 = new Arc(arc2.Plane, center, intPoint.DistanceTo(center), arc.Domain.Low, arc.Domain.High);
		Line line = new Line(arc3.StartPoint, arc2.StartPoint);
		Line line2 = new Line(arc3.EndPoint, arc2.EndPoint);
		arc3.Regen(workSpace.GetVisualRefinement());
		workSpace._0023_003DzmNZD0Zs_003D.DrawLineStrip(workSpace.WorldToScreen(arc3.Vertices));
		workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(line.StartPoint), workSpace.WorldToScreen(line.EndPoint));
		workSpace._0023_003DzmNZD0Zs_003D.DrawLine(workSpace.WorldToScreen(line2.StartPoint), workSpace.WorldToScreen(line2.EndPoint));
		Point3D point3D = intPoint.Clone() as Point3D;
		if (workSpace._0023_003DzFq8cO_00245h9dst() != null)
		{
			point3D.TransformBy(workSpace._0023_003DzFq8cO_00245h9dst());
		}
		AngularDim angularDim = new AngularDim(arc.Plane, arc.StartPoint, arc.EndPoint, point3D, previewDrawParams.TextHeight);
		_0023_003DzSv05nkLpzEnu(workSpace, previewDrawParams, angularDim);
		RegenParams visualRefinement = workSpace.GetVisualRefinement();
		angularDim.PrepareText(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, workSpace), ref previewDrawParams.WidthFactor, out var width, out var _, out var _, out var _);
		Vector3D vector3D = new Vector3D(intPoint, arc2.Center);
		vector3D.Normalize();
		Point2D point2D = angularDim.Plane.Project(angularDim.DimLinePosition);
		if (Utility.TextNeedsToBeFlippedAccordingToDrawingRules(Utility.ArcTanProblem(point2D.X, point2D.Y) + Math.PI / 6.0))
		{
			vector3D.Negate();
		}
		Vector3D vector3D2 = Vector3D.Cross(vector3D, arc2.Plane.AxisZ);
		Point3D point3D2 = intPoint + 0.5 * width * vector3D2;
		Point3D point3D3 = point3D2 + angularDim.TextGap * vector3D;
		Point3D point3D4 = point3D2 + (angularDim.Height + angularDim.TextGap) * vector3D;
		Point3D point3D5 = point3D4 - vector3D2 * width;
		Point3D point3D6 = point3D5 - vector3D * angularDim.Height;
		Point3D[] pointList = new Point3D[4] { point3D3, point3D4, point3D5, point3D6 };
		workSpace._0023_003DzmNZD0Zs_003D.DrawLineLoop(workSpace.WorldToScreen(pointList));
		new Circle(arc3.Plane, arc3.Radius).Project(intPoint, out var t);
		if (!arc3.Domain.Includes(t, testOpenInterval: false))
		{
			Point3D point3D7 = ((Point3D.DistanceSquared(arc3.MidPoint, point3D2) > Point3D.DistanceSquared(arc3.MidPoint, point3D6)) ? point3D2 : point3D6);
			Point3D start = ((Point3D.DistanceSquared(arc3.StartPoint, point3D7) > Point3D.DistanceSquared(arc3.EndPoint, point3D7)) ? arc3.EndPoint : arc3.StartPoint);
			Arc arc4 = new Arc(arc3.Center, start, point3D7);
			arc4.Regen(workSpace.GetVisualRefinement());
			workSpace._0023_003DzmNZD0Zs_003D.DrawLineStrip(workSpace.WorldToScreen(arc4.Vertices));
		}
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(currentLineWidth);
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(currentWireColor);
		return angularDim;
	}

	public static AngularDim DrawAngularDimPreview(Workspace workSpace, Plane dimPlane, Point3D origin, Point3D extLine1, Point3D extLine2, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		return DrawAngularDimPreview(workSpace, dimPlane, new Line(origin, extLine1), new Line(origin, extLine2), mousePos, previewDrawParams);
	}

	public static OrdinateDim DrawOrdinateDimPreview(Workspace workSpace, Plane dimPlane, Point3D definingPoint, double hookLen, double offsetFromDefiningPoint, bool vertical, System.Drawing.Point mousePos, DimensionPreviewDrawParams previewDrawParams)
	{
		Color currentWireColor = workSpace._0023_003DzmNZD0Zs_003D.CurrentWireColor;
		float currentLineWidth = workSpace._0023_003DzmNZD0Zs_003D.CurrentLineWidth;
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(previewDrawParams.Color);
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(previewDrawParams.LineSize);
		List<Point3D> list = new List<Point3D>();
		Plane plane = dimPlane.Clone() as Plane;
		Point3D point3D = definingPoint.Clone() as Point3D;
		if (workSpace.CurrentTransformation != null)
		{
			plane.TransformBy(workSpace.CurrentTransformation);
			point3D.TransformBy(workSpace.CurrentTransformation);
		}
		workSpace.ScreenToPlane(mousePos, plane, out var intPoint);
		Point3D point3D2 = intPoint.Clone() as Point3D;
		if (workSpace._0023_003DzFq8cO_00245h9dst() != null)
		{
			point3D2.TransformBy(workSpace._0023_003DzFq8cO_00245h9dst());
		}
		double textHeight = previewDrawParams.TextHeight;
		_ = previewDrawParams.TextGap;
		OrdinateDim ordinateDim = new OrdinateDim(dimPlane, definingPoint, point3D2, vertical, textHeight);
		_0023_003DzSv05nkLpzEnu(workSpace, previewDrawParams, ordinateDim);
		ordinateDim.LinearScale = previewDrawParams.DistancesScaleFactor;
		RegenParams visualRefinement = workSpace.GetVisualRefinement();
		ordinateDim.PrepareText(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, workSpace), ref previewDrawParams.WidthFactor, out var width, out var _, out var _, out var boxMax);
		Segment3D[] array = OrdinateDim.Preview(dimPlane, definingPoint, point3D2, vertical, width, hookLen, offsetFromDefiningPoint, ordinateDim.TextVerticalPosition, out boxMax);
		Segment3D[] array2 = array;
		foreach (Segment3D segment3D in array2)
		{
			list.Add(workSpace.WorldToScreen(segment3D.P0));
			list.Add(workSpace.WorldToScreen(segment3D.P1));
		}
		workSpace._0023_003DzmNZD0Zs_003D.DrawLines(list.ToArray());
		Vector3D vector3D = new Vector3D(array[2].P0, array[2].P1);
		vector3D.Normalize();
		Vector3D vector3D2 = Vector3D.Cross(vector3D, plane.AxisZ);
		Point3D point3D3 = intPoint - 0.5 * ordinateDim.Height * vector3D2 + 0.5 * width * vector3D;
		Point3D point3D4 = point3D3 + ordinateDim.Height * vector3D2;
		Point3D point3D5 = point3D4 - vector3D * width;
		Point3D point3D6 = point3D5 - vector3D2 * ordinateDim.Height;
		Point3D[] pointList = new Point3D[4] { point3D3, point3D4, point3D5, point3D6 };
		workSpace._0023_003DzmNZD0Zs_003D.DrawLineLoop(workSpace.WorldToScreen(pointList));
		workSpace._0023_003DzmNZD0Zs_003D.SetLineSize(currentLineWidth);
		workSpace._0023_003DzmNZD0Zs_003D.SetColorWireframe(currentWireColor);
		return ordinateDim;
	}

	private static bool _0023_003Dz8x_2BNo_003D(Point2D _0023_003DzJcO3mNI_003D, Point2D _0023_003DzB4LRl84_003D, Point2D _0023_003DzHgpT6M8_003D)
	{
		if ((!(_0023_003DzHgpT6M8_003D.X > _0023_003DzJcO3mNI_003D.X) || !(_0023_003DzHgpT6M8_003D.X < _0023_003DzB4LRl84_003D.X) || !(_0023_003DzHgpT6M8_003D.Y > _0023_003DzJcO3mNI_003D.Y) || !(_0023_003DzHgpT6M8_003D.Y < _0023_003DzB4LRl84_003D.Y)) && (!(_0023_003DzHgpT6M8_003D.X < _0023_003DzJcO3mNI_003D.X) || !(_0023_003DzHgpT6M8_003D.X < _0023_003DzB4LRl84_003D.X) || !(_0023_003DzHgpT6M8_003D.Y > _0023_003DzJcO3mNI_003D.Y) || !(_0023_003DzHgpT6M8_003D.Y > _0023_003DzB4LRl84_003D.Y)) && (!(_0023_003DzHgpT6M8_003D.X > _0023_003DzJcO3mNI_003D.X) || !(_0023_003DzHgpT6M8_003D.X > _0023_003DzB4LRl84_003D.X) || !(_0023_003DzHgpT6M8_003D.Y > _0023_003DzJcO3mNI_003D.Y) || !(_0023_003DzHgpT6M8_003D.Y > _0023_003DzB4LRl84_003D.Y)) && (!(_0023_003DzHgpT6M8_003D.X > _0023_003DzJcO3mNI_003D.X) || !(_0023_003DzHgpT6M8_003D.X > _0023_003DzB4LRl84_003D.X) || !(_0023_003DzHgpT6M8_003D.Y < _0023_003DzJcO3mNI_003D.Y) || !(_0023_003DzHgpT6M8_003D.Y < _0023_003DzB4LRl84_003D.Y)))
		{
			if (_0023_003DzHgpT6M8_003D.X < _0023_003DzJcO3mNI_003D.X && _0023_003DzHgpT6M8_003D.X < _0023_003DzB4LRl84_003D.X && _0023_003DzHgpT6M8_003D.Y < _0023_003DzJcO3mNI_003D.Y)
			{
				return _0023_003DzHgpT6M8_003D.Y < _0023_003DzB4LRl84_003D.Y;
			}
			return false;
		}
		return true;
	}

	private static void _0023_003DzxA2Q_0024Ub4u0Bp(Workspace _0023_003DzrWsecjleHtud, Dimension _0023_003DziNQtoAk_003D, Point3D _0023_003DzFcXCpKE_003D, Point3D _0023_003DzUYFJQ6LLtHOF, Vector3D _0023_003Dz7fYqpNc_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D, double _0023_003Dz51kNFoRhUGYl, bool _0023_003DzQmW6nPlNdrDJ, DimensionPreviewDrawParams _0023_003DzH3bEyMTjmB7r)
	{
		_0023_003DziNQtoAk_003D.LinearScale = _0023_003DzH3bEyMTjmB7r.DistancesScaleFactor;
		RegenParams visualRefinement = _0023_003DzrWsecjleHtud.GetVisualRefinement();
		_0023_003DziNQtoAk_003D.PrepareText(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, _0023_003DzrWsecjleHtud), ref _0023_003Dz51kNFoRhUGYl, out var width, out var _, out var _, out var _);
		Point3D point3D = _0023_003DzFcXCpKE_003D + 0.5 * width * _0023_003Dz7fYqpNc_003D;
		if (_0023_003DzFcXCpKE_003D.DistanceTo(_0023_003DzUYFJQ6LLtHOF) < 0.5 * width)
		{
			point3D = _0023_003DzUYFJQ6LLtHOF + width * _0023_003Dz7fYqpNc_003D;
		}
		Point3D point3D2 = point3D + _0023_003DziNQtoAk_003D.TextGap * _0023_003Dzv_0024Gzcjk_003D;
		Point3D point3D3 = point3D + (_0023_003DziNQtoAk_003D.Height + _0023_003DziNQtoAk_003D.TextGap) * _0023_003Dzv_0024Gzcjk_003D;
		Point3D point3D4 = point3D3 - _0023_003Dz7fYqpNc_003D * width;
		Point3D point3D5 = point3D4 - _0023_003Dzv_0024Gzcjk_003D * _0023_003DziNQtoAk_003D.Height;
		Point3D[] pointList = new Point3D[4] { point3D2, point3D3, point3D4, point3D5 };
		_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLineLoop(_0023_003DzrWsecjleHtud.WorldToScreen(pointList));
		if (_0023_003DzQmW6nPlNdrDJ)
		{
			_0023_003DzrWsecjleHtud._0023_003DzmNZD0Zs_003D.DrawLine(_0023_003DzrWsecjleHtud.WorldToScreen(point3D), _0023_003DzrWsecjleHtud.WorldToScreen(_0023_003DzUYFJQ6LLtHOF));
		}
		_0023_003DziNQtoAk_003D.LinearScale = 1.0;
	}

	private static void _0023_003DzSv05nkLpzEnu(Workspace _0023_003DzrWsecjleHtud, DimensionPreviewDrawParams _0023_003DzH3bEyMTjmB7r, Dimension _0023_003DziNQtoAk_003D)
	{
		_0023_003DziNQtoAk_003D.LinearDimensionUnits = _0023_003DzH3bEyMTjmB7r.LinearDimensionUnits;
		_0023_003DziNQtoAk_003D.Precision = _0023_003DzH3bEyMTjmB7r.Precision;
		if (!string.IsNullOrEmpty(_0023_003DzH3bEyMTjmB7r.TextOverride))
		{
			_0023_003DziNQtoAk_003D.TextOverride = _0023_003DzH3bEyMTjmB7r.TextOverride;
		}
		if (!string.IsNullOrEmpty(_0023_003DzH3bEyMTjmB7r.TextSuffix))
		{
			_0023_003DziNQtoAk_003D.TextSuffix = _0023_003DzH3bEyMTjmB7r.TextSuffix;
		}
		if (!string.IsNullOrEmpty(_0023_003DzH3bEyMTjmB7r.TextPrefix))
		{
			_0023_003DziNQtoAk_003D.TextPrefix = _0023_003DzH3bEyMTjmB7r.TextPrefix;
		}
		_0023_003DziNQtoAk_003D.SuppressLeadingZeros = _0023_003DzH3bEyMTjmB7r.SuppressLeadingZeros;
		_0023_003DziNQtoAk_003D.SuppressTrailingZeros = _0023_003DziNQtoAk_003D.SuppressTrailingZeros;
		_0023_003DziNQtoAk_003D.ToleranceMode = _0023_003DzH3bEyMTjmB7r.ToleranceMode;
		_0023_003DziNQtoAk_003D.TolerancePrecision = _0023_003DzH3bEyMTjmB7r.TolerancePrecision;
		_0023_003DziNQtoAk_003D.ToleranceSuppressLeadingZeros = _0023_003DzH3bEyMTjmB7r.ToleranceSuppressLeadingZeros;
		_0023_003DziNQtoAk_003D.ToleranceSuppressTralingZeros = _0023_003DzH3bEyMTjmB7r.ToleranceSuppressTrailingZeros;
		_0023_003DziNQtoAk_003D.WidthFactor = _0023_003DzH3bEyMTjmB7r.WidthFactor;
		if (_0023_003DzrWsecjleHtud is Design { CurrentSketch: not null } design)
		{
			_0023_003DziNQtoAk_003D.Height = design.CurrentSketch.screenToWorldInvariantFactor * (double)_0023_003DzrWsecjleHtud._0023_003DzipBYly6zFKAp()._0023_003DzIjzPUT72VTAG * design.CurrentSketch.TextScaleFactor;
			_0023_003DziNQtoAk_003D.TextGap = 0.25 * _0023_003DziNQtoAk_003D.Height;
		}
	}

	public static void DrawInteractiveSectionPlane(Drawing workSpace, View view, Point3D[] points, int numPoints, Point3D current)
	{
		switch (numPoints)
		{
		case 0:
			DrawArrow(workSpace, current);
			return;
		case 1:
		{
			if (current != null)
			{
				workSpace.RenderContext.DrawLine(workSpace.WorldToScreen(points[0]), workSpace.WorldToScreen(current));
			}
			Vector2D vector2D = new Vector2D(points[0], current);
			vector2D.TransformBy(new Rotation(-Math.PI / 2.0, Vector3D.AxisZ));
			vector2D.Normalize();
			DrawArrow(workSpace, points[0], vector2D);
			DrawArrow(workSpace, current, vector2D);
			return;
		}
		}
		DrawPositionMark(workSpace, current);
		Point3D point = points[0];
		Point3D point2 = points[1];
		workSpace.RenderContext.DrawLine(workSpace.WorldToScreen(point), workSpace.WorldToScreen(point2));
		Vector2D u = new Vector2D(workSpace.WorldToScreen(point), workSpace.WorldToScreen(point2));
		Point3D point3 = (view.BoxMin + view.BoxMax) / 2.0;
		Vector2D v = new Vector2D((workSpace.WorldToScreen(point) + workSpace.WorldToScreen(point2)) / 2.0, workSpace.WorldToScreen(current));
		double num = Vector2D.PerpDotProduct(u, v);
		if (current != null)
		{
			workSpace.RenderContext.DrawLine(workSpace.WorldToScreen(point3), workSpace.WorldToScreen(current));
		}
		Vector2D vector2D2 = new Vector2D(points[0], points[1]);
		vector2D2.TransformBy(new Rotation(-Math.PI / 2.0, Vector3D.AxisZ));
		vector2D2 *= (double)((workSpace.ActiveSheet.AngleProjectionMode == angleProjectionType.ThirdAngle) ? 1 : (-1));
		vector2D2.Normalize();
		if (num > 0.0)
		{
			DrawArrow(workSpace, points[0], vector2D2);
			DrawArrow(workSpace, points[1], vector2D2);
		}
		else
		{
			DrawArrow(workSpace, points[0], vector2D2 * -1.0);
			DrawArrow(workSpace, points[1], vector2D2 * -1.0);
		}
	}

	public static void DrawArrow(Workspace workSpace, Point3D head, Vector2D direction = null, double length = 32.0, double width = 8.0)
	{
		if (direction == null)
		{
			direction = new Vector2D(1.0, 0.0);
		}
		Vector2D vector2D = (Vector2D)direction.Clone();
		vector2D.TransformBy(new Rotation(Math.PI / 2.0, Vector3D.AxisZ));
		Point3D point3D = workSpace.WorldToScreen(head);
		Point2D p = point3D - direction * length;
		Point2D pt = point3D - direction * (length / 2.0) + vector2D * (width / 2.0);
		Point2D pt2 = point3D - direction * (length / 2.0) - vector2D * (width / 2.0);
		workSpace.RenderContext.DrawLine(p, point3D - direction * (length / 2.0));
		workSpace.RenderContext.DrawTriangles(new Point3D[3]
		{
			Plane.XY.PointAt(pt2),
			point3D,
			Plane.XY.PointAt(pt)
		});
		workSpace.RenderContext.SetLineSize(1f);
	}

	public static void DrawPositionMark(Workspace workSpace, Point3D center, double size = 20.0)
	{
		Point3D point3D = workSpace.WorldToScreen(center);
		Point2D a = workSpace.WorldToScreen(center.X - 1.0, center.Y, 0.0);
		Vector2D vector2D = Vector2D.Subtract(a, point3D);
		vector2D.Normalize();
		a = point3D + vector2D * size;
		Point2D p = point3D - vector2D * size;
		workSpace.RenderContext.DrawLine(a, p);
		Point2D a2 = workSpace.WorldToScreen(center.X, center.Y - 1.0, 0.0);
		Vector2D vector2D2 = Vector2D.Subtract(a2, point3D);
		vector2D2.Normalize();
		a2 = point3D + vector2D2 * size;
		Point2D p2 = point3D - vector2D2 * size;
		workSpace.RenderContext.DrawLine(a2, p2);
		workSpace.RenderContext.SetLineSize(1f);
	}

	public static byte[] ConvertImageToBytes(Image image)
	{
		if (image != null)
		{
			return (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
		}
		return null;
	}

	public static Bitmap ConvertBytesToImage(byte[] data)
	{
		if (data == null)
		{
			return null;
		}
		return new Bitmap(new MemoryStream(data));
	}

	internal static Bitmap _0023_003Dz3nqRsaSSSvFx(Bitmap _0023_003DzoMb5r_0024o_003D, Size _0023_003DzQL2Qzbg_003D)
	{
		try
		{
			Bitmap bitmap = new Bitmap(_0023_003DzQL2Qzbg_003D.Width, _0023_003DzQL2Qzbg_003D.Height, _0023_003DzoMb5r_0024o_003D.PixelFormat);
			using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
			{
				ImageAttributes imageAttributes = new ImageAttributes();
				try
				{
					imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.DrawImage(_0023_003DzoMb5r_0024o_003D, Rectangle.FromLTRB(0, 0, _0023_003DzQL2Qzbg_003D.Width, _0023_003DzQL2Qzbg_003D.Height), 0, 0, _0023_003DzoMb5r_0024o_003D.Width, _0023_003DzoMb5r_0024o_003D.Height, GraphicsUnit.Pixel, imageAttributes);
				}
				finally
				{
					((IDisposable)imageAttributes).Dispose();
				}
			}
			return bitmap;
		}
		catch
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601595));
		}
	}

	internal static Size _0023_003DzowV4NhAf418J(Size _0023_003Dz0ERMHbg_003D, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		return new Size((int)((float)_0023_003Dz0ERMHbg_003D.Width * _0023_003Dzme4iFiwq7lcq.Width), (int)((float)_0023_003Dz0ERMHbg_003D.Height * _0023_003Dzme4iFiwq7lcq.Height));
	}

	internal static LegendItem[] _0023_003DzowV4NhAf418J(LegendItem[] _0023_003Dzy78_0024Z10_003D, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		LegendItem[] array = new LegendItem[_0023_003Dzy78_0024Z10_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Size size = new Size((int)((float)_0023_003Dzy78_0024Z10_003D[i].Width * _0023_003Dzme4iFiwq7lcq.Width), (int)((float)_0023_003Dzy78_0024Z10_003D[i].Height * _0023_003Dzme4iFiwq7lcq.Height));
			array[i] = new LegendItem(size.Width, size.Height, _0023_003Dzy78_0024Z10_003D[i].Color);
		}
		return array;
	}

	internal static System.Drawing.Point _0023_003DzowV4NhAf418J(System.Drawing.Point _0023_003DzxGL6Kng_003D, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		return new System.Drawing.Point((int)((float)_0023_003DzxGL6Kng_003D.X * _0023_003Dzme4iFiwq7lcq.Width), (int)((float)_0023_003DzxGL6Kng_003D.Y * _0023_003Dzme4iFiwq7lcq.Height));
	}

	internal static int _0023_003DzowV4NhAf418J(int _0023_003DzsLHxXyo_003D, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		return (int)((float)_0023_003DzsLHxXyo_003D * _0023_003Dzme4iFiwq7lcq.Width);
	}

	internal static float _0023_003DzowV4NhAf418J(float _0023_003DzsLHxXyo_003D, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		return _0023_003DzsLHxXyo_003D * _0023_003Dzme4iFiwq7lcq.Width;
	}

	internal static Font _0023_003DzowV4NhAf418J(Font _0023_003Dz6FupbG0_003D, bool _0023_003DzzihtqSXtvdcF, SizeF _0023_003Dzme4iFiwq7lcq)
	{
		Font result = null;
		if (_0023_003Dz6FupbG0_003D != null)
		{
			string name = _0023_003Dz6FupbG0_003D.FontFamily.Name;
			float emSize = _0023_003DzowV4NhAf418J(_0023_003Dz6FupbG0_003D.Size, _0023_003Dzme4iFiwq7lcq);
			FontStyle style = _0023_003Dz6FupbG0_003D.Style;
			GraphicsUnit unit = _0023_003Dz6FupbG0_003D.Unit;
			result = new Font(name, emSize, style, unit);
			if (_0023_003DzzihtqSXtvdcF)
			{
				_0023_003Dz6FupbG0_003D.Dispose();
			}
		}
		return result;
	}

	public static SizeF GetScalingLevel()
	{
		if (_0023_003Dz5Bf5v8YOXRun.IsEmpty)
		{
			float width;
			float height;
			using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
			{
				width = graphics.DpiX / 96f;
				height = graphics.DpiY / 96f;
			}
			_0023_003Dz5Bf5v8YOXRun = new SizeF(width, height);
		}
		return _0023_003Dz5Bf5v8YOXRun;
	}

	public static Image LoadBitmapWithoutLockingFile(string filePath)
	{
		if (Utility.IsUnsupportedFormat(filePath))
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(filePath);
		try
		{
			return new Bitmap(bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public static Bitmap MakeGrayscale(Bitmap original)
	{
		Bitmap bitmap = new Bitmap(original.Width, original.Height);
		System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
		ColorMatrix colorMatrix = new ColorMatrix(new float[5][]
		{
			new float[5] { 0.3f, 0.3f, 0.3f, 0f, 0f },
			new float[5] { 0.59f, 0.59f, 0.59f, 0f, 0f },
			new float[5] { 0.11f, 0.11f, 0.11f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { 0f, 0f, 0f, 0f, 1f }
		});
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix);
		graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttributes);
		graphics.Dispose();
		return bitmap;
	}

	public static Bitmap SetImageOpacity(Image image, float opacity)
	{
		Bitmap bitmap = new Bitmap(image.Width, image.Height);
		using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
		ColorMatrix colorMatrix = new ColorMatrix();
		colorMatrix.Matrix33 = opacity;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
		return bitmap;
	}

	internal static double _0023_003DzSg7URJz1jbSCe_0024oh0g_003D_003D(GraphicsUnit _0023_003DzBuzzQdMhtT4y, linearUnitsType _0023_003DzDFsuEGG0eGEy)
	{
		return (double)_0023_003DzlWUSjmTD6fl_2lLLAg_003D_003D(_0023_003DzBuzzQdMhtT4y) / Utility.GetUnitsToMmFactor(_0023_003DzDFsuEGG0eGEy);
	}

	private static float _0023_003DzlWUSjmTD6fl_2lLLAg_003D_003D(GraphicsUnit _0023_003DzZJXtl2s_003D)
	{
		float num = 1f;
		switch (_0023_003DzZJXtl2s_003D)
		{
		case GraphicsUnit.Display:
			num = 100f;
			break;
		case GraphicsUnit.Document:
			num = 300f;
			break;
		case GraphicsUnit.Point:
			num = 72f;
			break;
		case GraphicsUnit.Millimeter:
			num = 25.4f;
			break;
		}
		return (float)(25.4 / (double)num);
	}

	internal static void _0023_003DzlsHh7Ow_0024_xdaU0vZm3yFMoCS26zm7BELgg_003D_003D(Point3D[] _0023_003Dz2CEdlpzLDMJwvZujpjy0xoA_003D, out Point3D[] _0023_003DzA4Kdx8KfjVqQpNWI_A_003D_003D, out IndexTriangle[] _0023_003DzCGWdziEfRkB7tRv0OFtdwiV_o0Iv, Mesh.natureType _0023_003DzTsQcYDaMpSSrW05csA_003D_003D)
	{
		Utility.TrianglesToIndexedTriangles(_0023_003Dz2CEdlpzLDMJwvZujpjy0xoA_003D, out _0023_003DzA4Kdx8KfjVqQpNWI_A_003D_003D, out _0023_003DzCGWdziEfRkB7tRv0OFtdwiV_o0Iv, _0023_003DzTsQcYDaMpSSrW05csA_003D_003D);
	}

	internal static void _0023_003Dzg91LQv_00243gSwKmCjnSw_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Grid._0023_003Dzp2xC_56LDhr6 _0023_003Dza3HTvMWw3UP_0024, IViewport _0023_003DzYzWi5Yw_003D, double[] _0023_003DzCMtv5oFqB_00244L, double[] _0023_003Dzkd_0024s_0024x2NM8Xs, drawCall _0023_003Dz6yafPvPznHYG)
	{
		switch (_0023_003Dza3HTvMWw3UP_0024)
		{
		case (Grid._0023_003Dzp2xC_56LDhr6)2:
			_0023_003DzkNsGzEB4P_0024sJ(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003Dzkd_0024s_0024x2NM8Xs, _0023_003Dz6yafPvPznHYG);
			break;
		case (Grid._0023_003Dzp2xC_56LDhr6)1:
			_0023_003DzmNZD0Zs_003D.PushModelView();
			_0023_003DzmNZD0Zs_003D.SetModelViewMatrix(_0023_003DzYzWi5Yw_003D.Camera.ModelViewMatrix);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
			_0023_003Dz6yafPvPznHYG(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
			_0023_003DzmNZD0Zs_003D.PopModelView();
			break;
		case (Grid._0023_003Dzp2xC_56LDhr6)0:
			_0023_003DzmNZD0Zs_003D.PushModelView();
			_0023_003DzmNZD0Zs_003D.SetModelViewMatrix(_0023_003DzYzWi5Yw_003D.Camera.ModelViewMatrix);
			_0023_003DzkNsGzEB4P_0024sJ(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzCMtv5oFqB_00244L, _0023_003Dz6yafPvPznHYG);
			_0023_003DzmNZD0Zs_003D.PopModelView();
			break;
		}
	}

	private static void _0023_003DzkNsGzEB4P_0024sJ(RenderContextBase _0023_003DzoC62DbA_003D, IViewport _0023_003DzYzWi5Yw_003D, double[] _0023_003Dzn6kXkJHLdtvX, drawCall _0023_003Dz6yafPvPznHYG)
	{
		if (_0023_003Dzn6kXkJHLdtvX != null)
		{
			_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestOff);
			_0023_003DzoC62DbA_003D.PushProjection();
			_0023_003DzoC62DbA_003D.SetProjectionMatrix(_0023_003DzYzWi5Yw_003D.Camera.GetCustomProjectionMatrix(_0023_003Dzn6kXkJHLdtvX).MatrixAsVectorByColumn);
			_0023_003Dz6yafPvPznHYG(_0023_003DzoC62DbA_003D, _0023_003DzYzWi5Yw_003D);
			_0023_003DzoC62DbA_003D.PopProjection();
			_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestLess);
		}
	}

	internal static bool[] _0023_003DzIBrdGNM_003D(ClippingPlaneBase[] _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		bool[] array = new bool[_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length];
		for (int i = 0; i < _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; i++)
		{
			array[i] = _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[i].Active;
		}
		return array;
	}

	internal static bool _0023_003Dzh_0024PIPDO0q5pY(Entity _0023_003DzpWC0efg_003D)
	{
		if (!_0023_003DzpWC0efg_003D.IsPolygonal())
		{
			return _0023_003DzpWC0efg_003D is BlockReference;
		}
		return true;
	}

	internal static void _0023_003Dzr_u_0024IHWHVAAGbXbZAg_003D_003D(double _0023_003DznCapsq3EyzM5, int _0023_003DzKUa593x0j662, int _0023_003DzrOjrO8tu6wbm, bool _0023_003DzkPBo_0024TDVHEJXyVd0yQ_003D_003D, out Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out Vector3D[] _0023_003Dz2pcdJKEqM3of, out PointF[] _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D)
	{
		Utility.CreateSphere(Mesh.natureType.RichSmooth, _0023_003DznCapsq3EyzM5, _0023_003DzKUa593x0j662, _0023_003DzrOjrO8tu6wbm, computeNormals: true, _0023_003DzkPBo_0024TDVHEJXyVd0yQ_003D_003D, out _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out _0023_003Dz2pcdJKEqM3of, out _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D);
	}

	internal static void _0023_003Dz39qa4kLY69E2922TrA_003D_003D(double _0023_003Dzm6tjENc1Myuh, double _0023_003DzebO_0024QKzCFWCS, double _0023_003DzkQAiKLA_003D, int _0023_003DzKUa593x0j662, int _0023_003DzrOjrO8tu6wbm, out Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out Vector3D[] _0023_003Dz2pcdJKEqM3of)
	{
		Utility.CreateCone(Mesh.natureType.Smooth, _0023_003Dzm6tjENc1Myuh, _0023_003DzebO_0024QKzCFWCS, _0023_003DzkQAiKLA_003D, _0023_003DzKUa593x0j662, computeNormals: true, out var _, out var _, out _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out _0023_003Dz2pcdJKEqM3of);
	}

	internal static void _0023_003DzLlW7aSdsQyHy(Camera _0023_003DzZ_0024IejP0R_0024_Cw, Point3D[] _0023_003Dz_KfgXoE_003D, out double _0023_003Dz8SiEeqqjUObS, out double _0023_003DzVbNvU5kkJhqV)
	{
		double num = double.MinValue;
		double num2 = double.MaxValue;
		Vector3D viewNormal = _0023_003DzZ_0024IejP0R_0024_Cw.ViewNormal;
		for (int i = 0; i < _0023_003Dz_KfgXoE_003D.Length; i++)
		{
			double num3 = 0.0 - Vector3D.Dot(Vector3D.Subtract(_0023_003Dz_KfgXoE_003D[i], _0023_003DzZ_0024IejP0R_0024_Cw.Location), viewNormal);
			if (num3 < num2)
			{
				num2 = num3;
			}
			if (num3 > num)
			{
				num = num3;
			}
		}
		_0023_003Dz8SiEeqqjUObS = Math.Min(num2, num);
		_0023_003DzVbNvU5kkJhqV = Math.Max(num2, num);
		if (_0023_003DzVbNvU5kkJhqV - _0023_003Dz8SiEeqqjUObS < 1E-06)
		{
			_0023_003Dz8SiEeqqjUObS -= 0.5;
			_0023_003DzVbNvU5kkJhqV += 0.5;
		}
		if (_0023_003DzZ_0024IejP0R_0024_Cw.ProjectionMode == projectionType.Perspective)
		{
			if (_0023_003Dz8SiEeqqjUObS < 0.0)
			{
				_0023_003Dz8SiEeqqjUObS = _0023_003DzZ_0024IejP0R_0024_Cw.Near / 100.0;
			}
			if (_0023_003DzVbNvU5kkJhqV < 0.0)
			{
				_0023_003DzVbNvU5kkJhqV = _0023_003Dz8SiEeqqjUObS * 1000.0;
			}
		}
	}

	internal static float[,] _0023_003Dz2bKxheQfGiA2(float _0023_003Dz_12yiIc_003D, float _0023_003Dzehequ9E_003D, float _0023_003DzuHzN414_003D, float _0023_003DzlpaGCtg_003D, float _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D)
	{
		return Utility.GetTransformationMatrix(_0023_003Dz_12yiIc_003D, _0023_003Dzehequ9E_003D, _0023_003DzuHzN414_003D, _0023_003DzlpaGCtg_003D, _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D);
	}
}
