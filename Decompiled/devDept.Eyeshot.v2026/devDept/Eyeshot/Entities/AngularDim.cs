using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class AngularDim : Dimension, ITwoArrowheads
{
	private angleFormatType _angleFormat;

	private double _extLineExt;

	private double _extLineOffset;

	private bool _showExtLine1 = true;

	private bool _showExtLine2 = true;

	internal Point3D start;

	internal Point3D end;

	private Arc dimArc;

	private Point3D[] _leadingArcVertices;

	private Point3D[] _trailingArcVertices;

	private double startAng;

	private double endAng;

	private double textAng;

	private Point2D start2D;

	private Point2D end2D;

	private arrowheadType _leftArrowhead;

	private arrowheadType _rightArrowhead;

	public angleFormatType AngleFormat
	{
		get
		{
			return _angleFormat;
		}
		set
		{
			_angleFormat = value;
			DimSetup();
		}
	}

	public double ExtLineExt
	{
		get
		{
			return _extLineExt;
		}
		set
		{
			_extLineExt = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ExtLineOffset
	{
		get
		{
			return _extLineOffset;
		}
		set
		{
			_extLineOffset = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool ShowExtLine1
	{
		get
		{
			return _showExtLine1;
		}
		set
		{
			_showExtLine1 = value;
			DimSetup();
		}
	}

	public bool ShowExtLine2
	{
		get
		{
			return _showExtLine2;
		}
		set
		{
			_showExtLine2 = value;
			DimSetup();
		}
	}

	public arrowheadType LeftArrowhead
	{
		get
		{
			return _leftArrowhead;
		}
		set
		{
			_leftArrowhead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public arrowheadType RightArrowhead
	{
		get
		{
			return _rightArrowhead;
		}
		set
		{
			_rightArrowhead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public Point3D Origin
	{
		get
		{
			return base.Plane.Origin;
		}
		set
		{
			base.Plane.Origin = value;
			DimSetup();
		}
	}

	public Point3D ExtLine1
	{
		get
		{
			return start;
		}
		set
		{
			start = value;
			DimSetup();
		}
	}

	public Point3D ExtLine2
	{
		get
		{
			return end;
		}
		set
		{
			end = value;
			DimSetup();
		}
	}

	public Arc UnderlyingArc => dimArc;

	public double StartAngle => startAng;

	public double EndAngle => endAng;

	public double Radius => dimArc.Radius;

	[Obsolete("Use the constructor that accepts the Plane without the origin parameter instead (The origin will be the Plane origin).")]
	public AngularDim(Plane dimPlane, Point3D origin, Point3D extLine1, Point3D extLine2, Point3D dimLinePos, double textHeight)
		: base(dimPlane, origin, textHeight)
	{
		_0023_003DztGdcVOA_003D((Point3D)extLine1.Clone(), (Point3D)extLine2.Clone(), (Point3D)dimLinePos.Clone());
	}

	public AngularDim(Plane dimPlane, Point3D extLine1, Point3D extLine2, Point3D dimLinePos, double textHeight)
		: base(dimPlane, (Point3D)dimPlane.Origin.Clone(), textHeight)
	{
		_0023_003DztGdcVOA_003D((Point3D)extLine1.Clone(), (Point3D)extLine2.Clone(), (Point3D)dimLinePos.Clone());
	}

	public AngularDim(Plane sketchPlane, Point2D origin, Point2D extLine1, Point2D extLine2, Point2D dimLinePos, double textHeight)
		: base(sketchPlane, sketchPlane.PointAt(origin), textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(extLine1), sketchPlane.PointAt(extLine2), sketchPlane.PointAt(dimLinePos));
	}

	protected AngularDim(AngularDim another)
		: base(another)
	{
		start = (Point3D)another.start.Clone();
		end = (Point3D)another.end.Clone();
		LeftArrowhead = another.LeftArrowhead;
		RightArrowhead = another.RightArrowhead;
		ExtLineExt = another.ExtLineExt;
		ExtLineOffset = another.ExtLineOffset;
		AngleFormat = another.AngleFormat;
		ShowExtLine1 = another.ShowExtLine1;
		ShowExtLine2 = another.ShowExtLine2;
		DimSetup();
	}

	public AngularDim(Plane dimPlane, Line line1, Line line2, Point3D quadrantPoint, Point3D dimLinePos, double textHeight)
		: base(dimPlane, dimLinePos, textHeight)
	{
		Point3D startPoint = line1.StartPoint;
		Point3D endPoint = line1.EndPoint;
		Point3D startPoint2 = line2.StartPoint;
		Point3D endPoint2 = line2.EndPoint;
		Segment2D segment2D = new Segment2D(dimPlane.Project(startPoint), dimPlane.Project(endPoint));
		Segment2D segment2D2 = new Segment2D(dimPlane.Project(startPoint2), dimPlane.Project(endPoint2));
		if (!Segment2D.IntersectionLine(segment2D, segment2D2, out var i))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954966));
		}
		Point3D point3D = dimPlane.PointAt(i);
		double radius = Point2D.Distance(i, dimPlane.Project(quadrantPoint));
		Vector3D vector3D = new Vector3D(startPoint, endPoint);
		Vector3D y = Vector3D.Cross(dimPlane.AxisZ, vector3D);
		Plane plane = new Plane(point3D, vector3D, y);
		Circle circle = new Circle(plane, radius);
		Point3D point = startPoint2;
		if (endPoint2.DistanceTo(point3D) > startPoint2.DistanceTo(point3D))
		{
			point = endPoint2;
		}
		circle.Project(point, out var t);
		circle.Project(quadrantPoint, out var t2);
		double num = t;
		num = ((!(t > Math.PI)) ? (num + Math.PI) : (num - Math.PI));
		double num2 = ((t < num) ? t : num);
		double num3 = ((t > num) ? t : num);
		double radius2 = Point3D.Distance(point3D, dimLinePos);
		Circle circle2 = new Circle(plane, radius2);
		Point3D point3D2;
		Point3D point3D3;
		if (t2 <= num2)
		{
			point3D2 = circle2.PointAt(0.0);
			point3D3 = circle2.PointAt(num2);
		}
		else if (t2 < Math.PI)
		{
			point3D2 = circle2.PointAt(Math.PI);
			point3D3 = circle2.PointAt(num2);
		}
		else if (t2 <= num3)
		{
			point3D2 = circle2.PointAt(Math.PI);
			point3D3 = circle2.PointAt(num3);
		}
		else
		{
			point3D2 = circle2.PointAt(0.0);
			point3D3 = circle2.PointAt(num3);
		}
		Vector3D vector3D2 = new Vector3D(point3D, point3D2);
		vector3D2.Normalize();
		Vector3D vector3D3 = new Vector3D(point3D, point3D3);
		vector3D3.Normalize();
		Vector3D vector3D4 = Vector3D.Cross(vector3D2, vector3D3);
		vector3D4.Normalize();
		double num4 = Vector3D.Dot(dimPlane.AxisZ, vector3D4);
		double _0023_003Dzaz4ytce7k8HamMiM6g_003D_003D = segment2D.Project(dimPlane.Project(point3D2));
		point3D2 = _0023_003DzYianhtHVqYzX(_0023_003Dzaz4ytce7k8HamMiM6g_003D_003D, point3D2, startPoint, endPoint, point3D, vector3D2);
		double _0023_003Dzaz4ytce7k8HamMiM6g_003D_003D2 = segment2D2.Project(dimPlane.Project(point3D3));
		point3D3 = _0023_003DzYianhtHVqYzX(_0023_003Dzaz4ytce7k8HamMiM6g_003D_003D2, point3D3, startPoint2, endPoint2, point3D, vector3D3);
		base.Plane.Origin = point3D;
		if (num4 > 0.0)
		{
			_0023_003DztGdcVOA_003D(point3D2, point3D3, (Point3D)dimLinePos.Clone());
		}
		else
		{
			_0023_003DztGdcVOA_003D(point3D3, point3D2, (Point3D)dimLinePos.Clone());
		}
	}

	protected internal AngularDim(AngularDimSurrogate surrogate)
		: this(surrogate.Plane, surrogate.ExtLine1, surrogate.ExtLine2, surrogate.DimLinePosition, surrogate.Height)
	{
	}

	protected AngularDim(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		base.Plane.Origin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954910), typeof(Point3D));
		start = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), typeof(Point3D));
		end = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), typeof(Point3D));
		LeftArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954577), typeof(arrowheadType));
		RightArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954567), typeof(arrowheadType));
		ExtLineExt = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954560));
		ExtLineOffset = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528));
		AngleFormat = (angleFormatType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954743), typeof(angleFormatType));
		ShowExtLine1 = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954732));
		ShowExtLine2 = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954696));
		UpdateDistance();
	}

	protected override string GetFormattedValue(double value)
	{
		string result = string.Empty;
		switch (AngleFormat)
		{
		case angleFormatType.DecimalDegrees:
			result = string.Format(_formatString, value) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954660);
			break;
		case angleFormatType.Radians:
			result = string.Format(_formatString, Utility.DegToRad(value)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954668);
			break;
		case angleFormatType.Gradians:
		{
			double num = value * 1.111111;
			result = string.Format(_formatString, num) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425);
			break;
		}
		case angleFormatType.DegMinSec:
		{
			_0023_003DzDzCcl2_ypkFmFd_0024KC8bTrdM_003D(value, out var _0023_003DzbU0rLpQ_003D, out var _0023_003DzF7v9r2A_003D, out var _0023_003DzGWdfTV4_003D);
			result = _0023_003DzbU0rLpQ_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954660) + _0023_003DzF7v9r2A_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930) + string.Format(_formatString, _0023_003DzGWdfTV4_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930888);
			break;
		}
		}
		return result;
	}

	private void _0023_003DzDzCcl2_ypkFmFd_0024KC8bTrdM_003D(double _0023_003DzPzO_0024GUk_003D, out int _0023_003DzbU0rLpQ_003D, out int _0023_003DzF7v9r2A_003D, out double _0023_003DzGWdfTV4_003D)
	{
		_0023_003DzGWdfTV4_003D = _0023_003DzPzO_0024GUk_003D * 3600.0;
		_0023_003DzbU0rLpQ_003D = (int)Math.Floor(_0023_003DzGWdfTV4_003D / 3600.0);
		_0023_003DzGWdfTV4_003D = Math.Abs(_0023_003DzGWdfTV4_003D % 3600.0);
		_0023_003DzF7v9r2A_003D = (int)Math.Floor(_0023_003DzGWdfTV4_003D / 60.0);
		_0023_003DzGWdfTV4_003D %= 60.0;
	}

	internal double _0023_003Dzgy2eWaUzG03z()
	{
		return ExtLineExt * ScaleOverall;
	}

	internal double _0023_003DzKTDbYiAY8p4J()
	{
		return ExtLineOffset * ScaleOverall;
	}

	private void _0023_003DztGdcVOA_003D(Point3D _0023_003DzO97ip_0024TQ_0024juS, Point3D _0023_003DzM7o0gT3hjI42, Point3D _0023_003Dz2AZWQ2NrfVgE)
	{
		start = _0023_003DzO97ip_0024TQ_0024juS;
		end = _0023_003DzM7o0gT3hjI42;
		base.DimLinePosition = _0023_003Dz2AZWQ2NrfVgE;
		LeftArrowhead = arrowheadType.Arrow;
		RightArrowhead = arrowheadType.Arrow;
		ExtLineExt = height * 0.5;
		ExtLineOffset = height * 0.25;
	}

	private Point3D _0023_003DzYianhtHVqYzX(double _0023_003Dzaz4ytce7k8HamMiM6g_003D_003D, Point3D _0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D, Point3D _0023_003DzIkjwDBsMiu3c, Point3D _0023_003DzKycvMzpz1xgE, Point3D _0023_003DziHKCNYWbvNY7ro7EkBTEAZQ_003D, Vector3D _0023_003DzAKYsX_Y_003D)
	{
		if (_0023_003Dzaz4ytce7k8HamMiM6g_003D_003D < 0.0 || _0023_003Dzaz4ytce7k8HamMiM6g_003D_003D > 1.0)
		{
			double num = Point3D.Distance(_0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D, _0023_003DzIkjwDBsMiu3c);
			double num2 = Point3D.Distance(_0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D, _0023_003DzKycvMzpz1xgE);
			double num3 = Point3D.Distance(_0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D, _0023_003DziHKCNYWbvNY7ro7EkBTEAZQ_003D);
			double num4;
			double b;
			Point3D point3D;
			if (num < num2)
			{
				num4 = num;
				b = Point3D.Distance(_0023_003DziHKCNYWbvNY7ro7EkBTEAZQ_003D, _0023_003DzIkjwDBsMiu3c);
				point3D = _0023_003DzIkjwDBsMiu3c;
			}
			else
			{
				num4 = num2;
				b = Point3D.Distance(_0023_003DziHKCNYWbvNY7ro7EkBTEAZQ_003D, _0023_003DzKycvMzpz1xgE);
				point3D = _0023_003DzKycvMzpz1xgE;
			}
			if ((num3 < num4 || Utility.AreEqual(num3, num4, 1.0)) && Utility.Compare(1E-09, num3 + num4, b) == 1)
			{
				point3D = _0023_003DziHKCNYWbvNY7ro7EkBTEAZQ_003D + _0023_003DzAKYsX_Y_003D * num3 / 10.0;
			}
			_0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D = point3D;
		}
		return _0023_003DzPEMrt7dzgpIGj4l_dSS0Dfo_003D;
	}

	public override object Clone()
	{
		return new AngularDim(this);
	}

	protected override void UpdateDistance()
	{
		start2D = base.Plane.Project(start);
		startAng = Utility.ArcTanProblem(start2D.X, start2D.Y);
		if (Math.Abs(startAng - Math.PI * 2.0) < 1E-12)
		{
			startAng = 0.0;
		}
		end2D = base.Plane.Project(end);
		endAng = Utility.ArcTanProblem(end2D.X, end2D.Y);
		if (Math.Abs(endAng) < 1E-12)
		{
			endAng = Math.PI * 2.0;
		}
		if (endAng < startAng)
		{
			endAng += Math.PI * 2.0;
		}
		double num = Utility.RadToDeg(endAng - startAng);
		if (num < 0.0)
		{
			Utility.Swap(ref start, ref end);
			Utility.Swap(ref start2D, ref end2D);
			Utility.Swap(ref startAng, ref endAng);
			base.Distance = 0.0 - num;
		}
		else
		{
			base.Distance = num;
		}
	}

	protected internal override Transformation GetBillboardTransformation(DrawParams data, out double scaleX, out double scaleY, out double scaleZ)
	{
		data.Viewport.Camera.GetFrame(out var _, out var camX, out var camY, out var _);
		Plane plane = (Plane)base.Plane.Clone();
		plane.Origin = Point3D.Origin;
		plane.Rotate(textAng, plane.AxisZ);
		if (textFlipped)
		{
			plane.Rotate(Math.PI, plane.AxisZ);
		}
		plane.Rotate(Math.PI / 2.0, plane.AxisZ);
		_0023_003Dz6_tAcSMiWiQ_0024635CMcOdIWk_003D(data, out var _0023_003Dzk3JS5glTSWfF, out scaleX, out scaleY, out scaleZ);
		return _0023_003Dzk3JS5glTSWfF * new Align3D(plane, new Plane(Point3D.Origin, camX, camY));
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(start.X, start.Y, start.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		start.X = num * array[0];
		start.Y = num * array[1];
		start.Z = num * array[2];
		array = xform.ActOnLeft(end.X, end.Y, end.Z, 1.0);
		num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		end.X = num * array[0];
		end.Y = num * array[1];
		end.Z = num * array[2];
		array = xform.ActOnLeft(base.DimLinePosition.X, base.DimLinePosition.Y, base.DimLinePosition.Z, 1.0);
		num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		base.DimLinePosition.X = num * array[0];
		base.DimLinePosition.Y = num * array[1];
		base.DimLinePosition.Z = num * array[2];
		if (xform.HasScaling)
		{
			double scaleFactor = xform.ScaleFactorX;
			if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
			{
				ExtLineExt *= scaleFactor;
				ExtLineOffset *= scaleFactor;
			}
		}
		base.TransformBy(xform);
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		dimArc.TransformBy(_0023_003DzLS0sR0pzioXc);
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
	}

	internal override void RegenInternal(RegenParams _0023_003DzELu0Pss_003D)
	{
		PrepareText(_0023_003DzELu0Pss_003D, ref myWidthFactor, out exactWidth, out exactDescend, out var _, out var _);
		int verticesLength = 8;
		Point3D[] array = InitVerticesOnPlane(ref verticesLength);
		array[0] = base.Plane.Origin;
		array[2] = start;
		array[3] = end;
		array[4] = base.DimLinePosition;
		_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(array, verticesLength);
		dimArc = new Arc(0.0, 0.0, 0.0, array[4].DistanceTo(Point3D.Origin), startAng, endAng);
		dimLineY = array[4].Y;
		double radius = dimArc.Radius;
		double num = start2D.DistanceTo(Point2D.Origin) + _0023_003DzKTDbYiAY8p4J();
		array[0].X = num;
		array[0].Y = 0.0;
		array[1] = new Point3D();
		array[1].X = dimArc.Radius + ((num > radius) ? (0.0 - _0023_003Dzgy2eWaUzG03z()) : _0023_003Dzgy2eWaUzG03z());
		array[1].Y = 0.0;
		if (!ShowExtLine1)
		{
			array[0] = array[1];
		}
		Rotation xform = new Rotation(startAng, Vector3D.AxisZ, Point3D.Origin);
		array[0].TransformBy(xform);
		array[1].TransformBy(xform);
		double num2 = dimArc.Length();
		double _0023_003DzS_jd4PN2HwcY = 0.0;
		if (dimArc.Diameter > _0023_003DzJ7p5EJnvP7td())
		{
			Circle circle = new Circle(0.0, 0.0, 0.0, dimArc.Radius);
			circle.Rotate(startAng, Vector3D.AxisZ);
			circle.Project(array[4], out var t);
			if (t > dimArc.Domain.Length && t > Math.PI + dimArc.Domain.Length / 2.0)
			{
				t -= Math.PI * 2.0;
			}
			double _0023_003Dz2AZWQ2NrfVgE = t * Radius;
			_0023_003DzgFzRnM_0024C_rz3(_0023_003Dz2AZWQ2NrfVgE, num2, LeftArrowhead, RightArrowhead, out _0023_003DzS_jd4PN2HwcY, out var _, out var _);
			textAng = startAng + _0023_003DzS_jd4PN2HwcY / dimArc.Radius;
		}
		else
		{
			switch (base.TextLocation)
			{
			case elementPositionType.Auto:
				if (base.UseDefaultTextPosition)
				{
					_textIsInside = true;
					textAng = (startAng + endAng) / 2.0;
				}
				else
				{
					textAng = Utility.ArcTanProblem(array[4].X, array[4].Y);
					_textIsInside = textAng > startAng && textAng < endAng;
				}
				break;
			case elementPositionType.Inside:
				_textIsInside = true;
				textAng = (startAng + endAng) / 2.0;
				break;
			case elementPositionType.Outside:
				_textIsInside = false;
				textAng = endAng;
				break;
			}
			_0023_003DzL3Hw_0024qWYdWdp_0024JA5XQ_003D_003D(LeftArrowhead, RightArrowhead, _0023_003DzJ7p5EJnvP7td(), num2, num2 / 2.0, num2 / 2.0, base.UseDefaultTextPosition);
		}
		textFlipped = Utility.TextNeedsToBeFlippedAccordingToDrawingRules(textAng + Math.PI / 6.0);
		double num3 = end2D.DistanceTo(Point2D.Origin) + _0023_003DzKTDbYiAY8p4J();
		array[2].X = num3;
		array[2].Y = 0.0;
		array[3] = new Point3D();
		array[3].X = dimArc.Radius + ((num3 > radius) ? (0.0 - _0023_003Dzgy2eWaUzG03z()) : _0023_003Dzgy2eWaUzG03z());
		array[3].Y = 0.0;
		array[2].TransformBy(new Rotation(endAng, Vector3D.AxisZ, Point3D.Origin));
		array[3].TransformBy(new Rotation(endAng, Vector3D.AxisZ, Point3D.Origin));
		if (!ShowExtLine2)
		{
			array[2] = array[3];
		}
		textLines = new List<string>();
		firstVertexIndexForTexts = 4;
		double num4 = _0023_003DzSKl3eSMXQFvZ();
		array[firstVertexIndexForTexts] = new Point3D((0.0 - exactWidth) / 2.0 + prefixWidth, textFlipped ? (0.0 - num4) : num4);
		if (textFlipped)
		{
			_textBottomLeft2D = new Point2D(dimArc.Radius + num4, exactWidth / 2.0);
		}
		else
		{
			_textBottomLeft2D = new Point2D(dimArc.Radius - num4, (0.0 - exactWidth) / 2.0);
		}
		_0023_003DzzCaChFUggCUnnuTszAfinDY_003D(array, _0023_003DzCpjsF78_003D: false, _0023_003DzjTr87nBCi_hO: true);
		Rotation rotation = new Rotation(Math.PI / 2.0, Vector3D.AxisZ, Point3D.Origin);
		Translation translation = new Translation(dimArc.Radius, 0.0);
		Transformation transformation = new Rotation(textAng, Vector3D.AxisZ, Point3D.Origin) * translation * rotation;
		for (int i = firstVertexIndexForTexts; i < verticesLength; i++)
		{
			array[i].TransformBy(transformation);
		}
		for (int j = 0; j < _basicToleranceBoxVertices.Length; j++)
		{
			_basicToleranceBoxVertices[j] = transformation * _basicToleranceBoxVertices[j];
		}
		Circle circle2 = new Circle(0.0, 0.0, 0.0, dimArc.Radius);
		circle2.Project(array[4], out var t2);
		circle2.Project(array[5], out var t3);
		if (array[4].X > 0.0 && array[5].X > 0.0 && array[4].Y * array[5].Y < 0.0)
		{
			Interval domain = new Interval(dimArc.Domain.Low, dimArc.Domain.High);
			Interval domain2 = new Interval(dimArc.Domain.Low, dimArc.Domain.High);
			double num5 = t2;
			double num6 = t3;
			if (t2 < t3)
			{
				t2 += Math.PI * 2.0;
			}
			else
			{
				t3 += Math.PI * 2.0;
			}
			if (t2 < dimArc.Domain.Low)
			{
				domain = new Interval(t2, dimArc.Domain.High);
			}
			if (t3 > dimArc.Domain.High)
			{
				domain = new Interval(dimArc.Domain.Low, t3);
			}
			if (num5 < num6)
			{
				num6 -= Math.PI * 2.0;
			}
			else
			{
				num5 -= Math.PI * 2.0;
			}
			if (num5 < dimArc.Domain.Low)
			{
				domain2 = new Interval(num5, dimArc.Domain.High);
			}
			if (num6 > dimArc.Domain.High)
			{
				domain2 = new Interval(dimArc.Domain.Low, num6);
			}
			if (domain.Length < domain2.Length)
			{
				dimArc.Domain = domain;
			}
			else
			{
				dimArc.Domain = domain2;
			}
		}
		else
		{
			Interval domain3 = new Interval(dimArc.Domain.Low, dimArc.Domain.High);
			Interval domain4 = new Interval(dimArc.Domain.Low, dimArc.Domain.High);
			bool flag = false;
			bool flag2 = false;
			if (t2 < dimArc.Domain.Low)
			{
				domain3 = new Interval(t2, dimArc.Domain.High);
				flag = true;
			}
			if (t3 > dimArc.Domain.High)
			{
				domain3 = new Interval(dimArc.Domain.Low, t3);
				flag2 = true;
			}
			if (flag && flag2)
			{
				dimArc.Domain = new Interval(t2, t3);
			}
			else if (flag)
			{
				double num7 = t3 + Math.PI * 2.0;
				if (num7 > dimArc.Domain.High)
				{
					domain4 = new Interval(dimArc.Domain.Low, num7);
				}
				if (domain3.Length < domain4.Length)
				{
					dimArc.Domain = domain3;
				}
				else
				{
					dimArc.Domain = domain4;
				}
			}
			else if (flag2)
			{
				double num8 = t2 - Math.PI * 2.0;
				if (num8 < dimArc.Domain.Low)
				{
					domain4 = new Interval(num8, dimArc.Domain.High);
				}
				if (domain3.Length < domain4.Length)
				{
					dimArc.Domain = domain3;
				}
				else
				{
					dimArc.Domain = domain4;
				}
			}
		}
		_0023_003Dz0nJAUFysbna4boWQhQ_003D_003D(array);
		Transformation transformation2 = new Transformation();
		transformation2.Rotation(Plane.XY, base.Plane);
		dimArc.TransformBy(transformation2);
		if (base.TextVerticalPosition == verticalAlignmentType.Centered)
		{
			List<Point3D> list = _basicToleranceBoxVertices.ToList();
			list.Add((Point3D)list[0].Clone());
			LinearPath c = new LinearPath(list);
			Point3D[] array2 = dimArc.IntersectWith(c, 0.0, computeParameters: false);
			if (array2.Length == 1)
			{
				dimArc.Project(array2[0], out var t4);
				ICurve sub;
				if (_0023_003DzS_jd4PN2HwcY > 0.0)
				{
					dimArc.SubCurve(dimArc.Domain.Low, t4, out sub);
				}
				else
				{
					dimArc.SubCurve(t4, dimArc.Domain.High, out sub);
				}
				((Entity)sub).Regen(_0023_003DzELu0Pss_003D);
				_leadingArcVertices = ((Entity)sub).Vertices;
				_trailingArcVertices = Array.Empty<Point3D>();
			}
			else if (array2.Length == 2)
			{
				dimArc.Project(array2[0], out var t5);
				dimArc.Project(array2[1], out var t6);
				if (t5 > t6)
				{
					Utility.Swap(ref t5, ref t6);
				}
				dimArc.SubCurve(dimArc.Domain.Low, t5, out var sub2);
				((Entity)sub2).Regen(_0023_003DzELu0Pss_003D);
				_leadingArcVertices = ((Entity)sub2).Vertices;
				dimArc.SubCurve(t6, dimArc.Domain.High, out sub2);
				((Entity)sub2).Regen(_0023_003DzELu0Pss_003D);
				_trailingArcVertices = ((Entity)sub2).Vertices;
			}
			else
			{
				dimArc.Regen(_0023_003DzELu0Pss_003D);
				_leadingArcVertices = dimArc.Vertices;
				_trailingArcVertices = Array.Empty<Point3D>();
			}
		}
		else
		{
			dimArc.Regen(_0023_003DzELu0Pss_003D);
			_leadingArcVertices = dimArc.Vertices;
			_trailingArcVertices = Array.Empty<Point3D>();
		}
		if (base.ToleranceMode != toleranceType.Basic)
		{
			_basicToleranceBoxVertices = Array.Empty<Point3D>();
		}
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	internal override void GetLines(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		base.GetLines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D, _0023_003DzzGo2_Wb1L5us, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
		List<Point3D> list = new List<Point3D>();
		list.Add(_vertices[0]);
		list.Add(_vertices[1]);
		list.AddRange(GetLinesFromVertices(_leadingArcVertices, addLast: false));
		list.AddRange(GetLinesFromVertices(_trailingArcVertices, addLast: false));
		list.Add(_vertices[2]);
		list.Add(_vertices[3]);
		if (!_0023_003DzzGo2_Wb1L5us || LeftArrowhead == arrowheadType.Oblique)
		{
			Point3D[] arrowHeadPoints = GetArrowHeadPoints(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: true);
			list.AddRange(arrowHeadPoints);
		}
		if (!_0023_003DzzGo2_Wb1L5us || RightArrowhead == arrowheadType.Oblique)
		{
			Point3D[] arrowHeadPoints = GetArrowHeadPoints(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: false);
			list.AddRange(arrowHeadPoints);
		}
		list.AddRange(_0023_003DzyIUKu5w_003D);
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	private Transformation _0023_003DzKw0JSvso00Xq()
	{
		return new Rotation(startAng, Vector3D.AxisZ) * new Translation(dimArc.Radius, 0.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ);
	}

	private Transformation _0023_003Dzxd1wPlvPgXlh()
	{
		return new Rotation(endAng, Vector3D.AxisZ) * new Translation(dimArc.Radius, 0.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ);
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D> list = new List<Point3D>();
		Point3D[] array = null;
		if (LeftArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: true);
			list.AddRange(array);
		}
		if (RightArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: false);
			list.AddRange(array);
		}
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { list.ToArray() };
		}
		return Dimension._0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(base._0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix()), list.ToArray());
	}

	protected override Transformation GetTextMatrix()
	{
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		transformation = transformation * new Rotation(textAng, Vector3D.AxisZ) * new Translation(_textBottomLeft2D.X, _textBottomLeft2D.Y);
		if (textFlipped)
		{
			transformation *= (Transformation)new Rotation(Math.PI, Vector3D.AxisZ);
		}
		return transformation * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * new Scaling(base.ScaleX * base.ScaleBackward, base.ScaleY * base.ScaleUpsideDown);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			_0023_003Dz_GuEQ6Cz_DBs(context, _vertices, 4);
			context.DrawLineStrip(_leadingArcVertices);
			if (_trailingArcVertices.Length != 0)
			{
				context.DrawLineStrip(_trailingArcVertices);
			}
		}
		else
		{
			drawData.DrawBuffer(context, 0);
			drawData.DrawBuffer(context, nextPart: true);
			if (_trailingArcVertices.Length != 0)
			{
				drawData.DrawBuffer(context, nextPart: true);
			}
		}
		DrawHeads(context);
	}

	protected override void DrawHeadsInternal(RenderContextBase context, object myParams)
	{
		DrawArrowHead(context, LeftArrowhead, dimArc.Radius, startAng, reverse: false);
		DrawArrowHead(context, RightArrowhead, dimArc.Radius, endAng, reverse: true);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[4]
		{
			_vertices[0],
			_vertices[1],
			_vertices[2],
			_vertices[3]
		}, 4, 2) || dimArc.InsideOrCrossingFrustum(data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[4]
		{
			_vertices[0],
			_vertices[1],
			_vertices[2],
			_vertices[3]
		}, 4, 2) || dimArc.InsideOrCrossingScreenPolygon(data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected void DrawArrowHead(RenderContextBase context, arrowheadType arrowhead, double myDistance, double angle, bool reverse)
	{
		switch (arrowhead)
		{
		case arrowheadType.Arrow:
			_0023_003DzxMD3s1S2eIKw(context, myDistance, angle, reverse);
			break;
		case arrowheadType.Tick:
			_0023_003DzZl3uTZY2SDdp(context, myDistance, angle, reverse);
			break;
		case arrowheadType.Dot:
			_0023_003DzT2MIyACvYuZK(context, myDistance, angle, reverse);
			break;
		case arrowheadType.Oblique:
			_0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(context, myDistance, angle, reverse);
			break;
		}
	}

	internal override void _0023_003DzbC_0024QQAMwgTKD(DrawParams _0023_003DzELu0Pss_003D)
	{
		base._0023_003DzbC_0024QQAMwgTKD(_0023_003DzELu0Pss_003D);
		prevExt = ExtLineExt;
		prevOffset = ExtLineOffset;
		_extLineExt = height * 0.5;
		_extLineOffset = height * 0.25;
	}

	internal override void _0023_003DzWFT5K6qE53AJ()
	{
		_extLineOffset = prevOffset;
		_extLineExt = prevExt;
		base._0023_003DzWFT5K6qE53AJ();
	}

	private void _0023_003DzxMD3s1S2eIKw(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzkJwy_6DWl7EF, double _0023_003Dz6pajdGM_003D, bool _0023_003DzEXLcE10_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Rotation(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ) * new Translation(_0023_003DzkJwy_6DWl7EF, 0.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ));
		if (_0023_003DzEXLcE10_003D ? (!_arrowsIsInside) : _arrowsIsInside)
		{
			DrawArrowPointingLeft(_0023_003DzB8iS0QA_003D);
		}
		else
		{
			DrawArrowPointingRight(_0023_003DzB8iS0QA_003D);
		}
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzZl3uTZY2SDdp(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzkJwy_6DWl7EF, double _0023_003Dz6pajdGM_003D, bool _0023_003DzEXLcE10_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(_0023_003Dz6pajdGM_003D), 0.0, 0.0, 1.0);
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_0023_003DzkJwy_6DWl7EF, 0.0, 0.0);
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(135.0, 0.0, 0.0, 1.0);
		DrawTick(_0023_003DzB8iS0QA_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzT2MIyACvYuZK(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzkJwy_6DWl7EF, double _0023_003Dz6pajdGM_003D, bool _0023_003DzEXLcE10_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(_0023_003Dz6pajdGM_003D), 0.0, 0.0, 1.0);
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_0023_003DzkJwy_6DWl7EF, 0.0, 0.0);
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(90.0, 0.0, 0.0, 1.0);
		DrawDot(_0023_003DzB8iS0QA_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzkJwy_6DWl7EF, double _0023_003Dz6pajdGM_003D, bool _0023_003DzEXLcE10_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(_0023_003Dz6pajdGM_003D), 0.0, 0.0, 1.0);
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_0023_003DzkJwy_6DWl7EF, 0.0, 0.0);
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(135.0, 0.0, 0.0, 1.0);
		DrawOblique(_0023_003DzB8iS0QA_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954644) + LeftArrowhead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954636) + RightArrowhead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955363) + ExtLineExt);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955342) + ExtLineOffset);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955306) + AngleFormat);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955293) + ShowExtLine1);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955518) + ShowExtLine2);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new AngularDimSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954910), base.Plane.Origin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), start);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), end);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954577), LeftArrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954567), RightArrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954560), ExtLineExt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528), ExtLineOffset);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954743), AngleFormat);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954732), ShowExtLine1);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954696), ShowExtLine2);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[4]
			{
				base.Plane.Origin,
				start,
				end,
				base.DimLinePosition
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	protected override double GetScaledDistance()
	{
		return base.Distance;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (Point3D.DistanceSquared(Origin, ExtLine1) < 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955483));
			return false;
		}
		if (Point3D.DistanceSquared(Origin, ExtLine2) < 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955431));
			return false;
		}
		if (Point3D.DistanceSquared(Origin, base.DimLinePosition) < 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955123));
			return false;
		}
		return base.IsValid(log);
	}
}
