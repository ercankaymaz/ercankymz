using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class EllipticalArc : Ellipse
{
	internal Interval angle;

	public override bool IsPoint
	{
		get
		{
			if (!base.IsPoint)
			{
				return AngleInRadians < 1E-12;
			}
			return true;
		}
	}

	public Interval Angle => angle;

	public double AngleInRadians => angle.Length;

	public double AngleInDegrees => 180.0 * angle.Length / Math.PI;

	public override Interval Domain
	{
		get
		{
			return angle;
		}
		set
		{
			Arc._0023_003DzP7Itlc0_003D(this, ref angle, value);
		}
	}

	public override Point3D StartPoint => PointAt(angle.t0);

	public override Point3D EndPoint => PointAt(angle.t1);

	public override bool IsClosed => angle.IsTwoPI;

	public override Vector3D StartTangent => TangentAt(angle.t0);

	public override Vector3D EndTangent => TangentAt(angle.t1);

	public EllipticalArc(Point3D center, double rx, double ry, double endParameter)
		: base(center, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(center, rx, ry, endParameter))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(double x, double y, double z, double rx, double ry, double endParameter)
		: base(x, y, z, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Point3D(x, y, z), rx, ry, endParameter))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Point3D center, double rx, double ry, double startParameter, double endParameter)
		: base(center, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(center, rx, ry), new Interval(startParameter, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Point3D center, double rx, double ry, double startAngleInRadians, double endAngleInRadians, bool polarAngles)
		: base(center, rx, ry)
	{
		if (polarAngles)
		{
			double _0023_003DzIjggO4c_003D;
			double _0023_003Dz9tHB74A_003D;
			bool num = _0023_003DziP0yJQmsmusc(rx, ry, startAngleInRadians, endAngleInRadians, out _0023_003DzIjggO4c_003D, out _0023_003Dz9tHB74A_003D);
			if (!_0023_003DzuvS5KTE_003D(new Ellipse(center, rx, ry), new Interval(_0023_003DzIjggO4c_003D, _0023_003Dz9tHB74A_003D)))
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
			}
			if (num)
			{
				Reverse();
			}
		}
		else if (!_0023_003DzuvS5KTE_003D(new Ellipse(center, rx, ry), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(double x, double y, double z, double rx, double ry, double startParameter, double endParameter)
		: base(x, y, z, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(new Point3D(x, y, z), rx, ry), new Interval(startParameter, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(double x, double y, double z, double rx, double ry, double startAngleInRadians, double endAngleInRadians, bool polarAngles)
		: this(new Point3D(x, y, z), rx, ry, startAngleInRadians, endAngleInRadians, polarAngles)
	{
	}

	public EllipticalArc(Plane arcPlane, Point3D center, double rx, double ry, double endParameter)
		: base(arcPlane, center, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, center, rx, ry), new Interval(0.0, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, Point3D center, double rx, double ry, double startParameter, double endParameter)
		: base(arcPlane, center, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, center, rx, ry), new Interval(startParameter, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, double rx, double ry, double startParameter, double endParameter)
		: base(arcPlane, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, rx, ry), new Interval(startParameter, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, Point3D center, double rx, double ry, double startAngleInRadians, double endAngleInRadians, bool polarAngles)
		: base(arcPlane, center, rx, ry)
	{
		if (polarAngles)
		{
			double _0023_003DzIjggO4c_003D;
			double _0023_003Dz9tHB74A_003D;
			bool num = _0023_003DziP0yJQmsmusc(rx, ry, startAngleInRadians, endAngleInRadians, out _0023_003DzIjggO4c_003D, out _0023_003Dz9tHB74A_003D);
			if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, center, rx, ry), new Interval(_0023_003DzIjggO4c_003D, _0023_003Dz9tHB74A_003D)))
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
			}
			if (num)
			{
				Reverse();
			}
		}
		else if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, center, rx, ry), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, Point2D center, double rx, double ry, double startParameter, double endParameter)
		: base(arcPlane, center, rx, ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, base.Plane.PointAt(center), rx, ry), new Interval(startParameter, endParameter)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, Point2D center, double rx, double ry, double startAngleInRadians, double endAngleInRadians, bool polarAngles)
		: base(arcPlane, center, rx, ry)
	{
		if (polarAngles)
		{
			double _0023_003DzIjggO4c_003D;
			double _0023_003Dz9tHB74A_003D;
			bool num = _0023_003DziP0yJQmsmusc(rx, ry, startAngleInRadians, endAngleInRadians, out _0023_003DzIjggO4c_003D, out _0023_003Dz9tHB74A_003D);
			if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, base.Plane.PointAt(center), rx, ry), new Interval(_0023_003DzIjggO4c_003D, _0023_003Dz9tHB74A_003D)))
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
			}
			if (num)
			{
				Reverse();
			}
		}
		else if (!_0023_003DzuvS5KTE_003D(new Ellipse(base.Plane, base.Plane.PointAt(center), rx, ry), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
	}

	public EllipticalArc(Plane arcPlane, Point3D center, double rx, double ry, Point3D start, Point3D end, bool flip)
		: base(arcPlane, center, rx, ry)
	{
		angle = new Interval(0.0, Math.PI * 2.0);
		Project(start, out var t);
		Project(end, out var t2);
		if (Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0))
		{
			t = 0.0;
		}
		if (Utility.AreEqual(t2, 0.0, Math.PI * 2.0))
		{
			t2 = Math.PI * 2.0;
		}
		if (flip)
		{
			Utility.Swap(ref t, ref t2);
		}
		if (t > t2 || Math.Abs(t - t2) < 1E-12)
		{
			t2 += Math.PI * 2.0;
		}
		Domain = new Interval(t, t2);
	}

	protected EllipticalArc(EllipticalArc another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		angle = another.angle;
	}

	protected internal EllipticalArc(EllipticalArcSurrogate surrogate)
		: this(surrogate.GetPlane(), surrogate.GetRadiusX(), surrogate.GetRadiusY(), surrogate.GetDomain().t0, surrogate.GetDomain().t1)
	{
	}

	internal EllipticalArc(GEllipticalArc _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Plane, _0023_003DzQwa1qM0_003D.RadiusX, _0023_003DzQwa1qM0_003D.RadiusY, _0023_003DzQwa1qM0_003D.Domain.t0, _0023_003DzQwa1qM0_003D.Domain.t1)
	{
	}

	protected EllipticalArc(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		angle = (Interval)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955066), typeof(Interval));
	}

	public override object Clone()
	{
		return new EllipticalArc(this);
	}

	public override object CloneWithTessellation()
	{
		return new EllipticalArc(this, RegenMode != regenType.RegenAndCompile);
	}

	private bool _0023_003DzuvS5KTE_003D(Ellipse _0023_003Dz4KQWdJ4_003D, Interval _0023_003DzZMsr2cz1T3kPmxsY8ta9kK_0024Rehng)
	{
		_radiusY = _0023_003Dz4KQWdJ4_003D._radiusY;
		_radiusX = _0023_003Dz4KQWdJ4_003D._radiusX;
		angle = _0023_003DzZMsr2cz1T3kPmxsY8ta9kK_0024Rehng;
		if (angle.IsDecreasing)
		{
			angle.Swap();
			Reverse();
		}
		if (angle.Length > Math.PI * 2.0)
		{
			angle.t1 = angle.t0 + Math.PI * 2.0;
		}
		return IsValid();
	}

	private bool _0023_003DzuvS5KTE_003D(Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, double _0023_003DzfSrrN4sXVX5o0WAWDg_003D_003D)
	{
		return _0023_003DzuvS5KTE_003D(new Ellipse(_0023_003DzbUvT9Pc_003D, _0023_003DzTAvzjIc_003D, _0023_003DzpbGuOuw_003D), new Interval(0.0, _0023_003DzfSrrN4sXVX5o0WAWDg_003D_003D));
	}

	private static bool _0023_003DziP0yJQmsmusc(double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, double _0023_003Dzsu9_0024FLqqWoZkm14dgdZ0KW8_003D, double _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D, out double _0023_003DzIjggO4c_003D, out double _0023_003Dz9tHB74A_003D)
	{
		if (_0023_003Dzsu9_0024FLqqWoZkm14dgdZ0KW8_003D == _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
		Interval interval = new Interval(_0023_003Dzsu9_0024FLqqWoZkm14dgdZ0KW8_003D, _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D);
		bool result = false;
		if (interval.IsDecreasing)
		{
			interval.Swap();
			result = true;
		}
		double num = Math.PI * 2.0;
		if (interval.Length > num)
		{
			interval.t1 = interval.t0 + num;
		}
		_0023_003DzIjggO4c_003D = _0023_003DzwNEfHBMh6b57(_0023_003DzTAvzjIc_003D, _0023_003DzpbGuOuw_003D, interval.t0);
		_0023_003Dz9tHB74A_003D = _0023_003DzwNEfHBMh6b57(_0023_003DzTAvzjIc_003D, _0023_003DzpbGuOuw_003D, interval.t1);
		while (_0023_003DzIjggO4c_003D >= _0023_003Dz9tHB74A_003D)
		{
			_0023_003Dz9tHB74A_003D += num;
		}
		if (Utility.AreEqual(_0023_003DzIjggO4c_003D, _0023_003Dz9tHB74A_003D, num) && Utility.AreEqual(interval.Length, num, num))
		{
			_0023_003Dz9tHB74A_003D += num;
		}
		return result;
	}

	internal static double _0023_003DzwNEfHBMh6b57(double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, double _0023_003Dzv3_XI_A_003D)
	{
		double num = Math.Atan(_0023_003DzTAvzjIc_003D / _0023_003DzpbGuOuw_003D * Math.Tan(_0023_003Dzv3_XI_A_003D));
		double num2;
		for (num2 = _0023_003Dzv3_XI_A_003D; num2 < 0.0; num2 += Math.PI * 2.0)
		{
		}
		while (num2 > Math.PI * 2.0)
		{
			num2 -= Math.PI * 2.0;
		}
		if (num2 == 0.0 || num2 == Math.PI / 2.0 || num2 == Math.PI || num2 == 4.71238898038469 || num2 == Math.PI * 2.0)
		{
			num = num2;
		}
		else if (num2 > Math.PI / 2.0 && num2 < 4.71238898038469)
		{
			num += Math.PI;
		}
		else if (num2 > 4.71238898038469 && num2 < Math.PI * 2.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	public static bool GetIntervalOfAngles(double rx, double ry, double startParam, double endParam, out double startAngleInRadians, out double endAngleInRadians)
	{
		if (startParam == endParam)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967758));
		}
		Interval interval = new Interval(startParam, endParam);
		bool result = false;
		if (interval.IsDecreasing)
		{
			interval.Swap();
			result = true;
		}
		double num = Math.PI * 2.0;
		if (interval.Length > num)
		{
			interval.t1 = interval.t0 + num;
		}
		startAngleInRadians = _0023_003Dz0ubKfhlbW12o(rx, ry, interval.t0);
		endAngleInRadians = _0023_003Dz0ubKfhlbW12o(rx, ry, interval.t1);
		while (startAngleInRadians >= endAngleInRadians)
		{
			endAngleInRadians += num;
		}
		if (Utility.AreEqual(startAngleInRadians, endAngleInRadians, num) && Utility.AreEqual(interval.Length, num, num))
		{
			endAngleInRadians += num;
		}
		return result;
	}

	internal static double _0023_003Dz0ubKfhlbW12o(double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, double _0023_003DzY6soE2U_003D)
	{
		double num = Math.Atan(_0023_003DzpbGuOuw_003D / _0023_003DzTAvzjIc_003D * Math.Tan(_0023_003DzY6soE2U_003D));
		double num2;
		for (num2 = _0023_003DzY6soE2U_003D; num2 < 0.0; num2 += Math.PI * 2.0)
		{
		}
		while (num2 > Math.PI * 2.0)
		{
			num2 -= Math.PI * 2.0;
		}
		if (num2 == 0.0 || num2 == Math.PI / 2.0 || num2 == Math.PI || num2 == 4.71238898038469 || num2 == Math.PI * 2.0)
		{
			num = num2;
		}
		else if (num2 > Math.PI / 2.0 && num2 < 4.71238898038469)
		{
			num += Math.PI;
		}
		else if (num2 > 4.71238898038469 && num2 < Math.PI * 2.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (AngleInRadians <= 1E-12 || AngleInRadians > 6.283185307180586)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955053));
			return false;
		}
		return base.IsValid(log);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955214) + angle.t0 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(angle.t0) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955163) + angle.t1 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(angle.t1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		return stringBuilder.ToString();
	}

	public override void Reverse()
	{
		base.Reverse();
		angle.Reverse();
		RegenMode = regenType.RegenAndCompile;
	}

	public override bool TrimBy(Point3D limit, bool flipSide)
	{
		ClosestPointTo(limit, out var t);
		return TrimAt(t, flipSide);
	}

	public override bool TrimAt(double t, bool flipSide)
	{
		if (t > angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length) && t < angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length))
		{
			if (flipSide)
			{
				Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
			}
			else
			{
				Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
			}
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public override bool ExtendAt(double t)
	{
		if (IsClosed)
		{
			return false;
		}
		if ((t < angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length)) || (t > angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length)))
		{
			Interval _0023_003DzJUOlPYhShISQ = angle;
			if (t > angle.t1)
			{
				Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
				if (t > Math.PI * 2.0 && t - angle.t0 > Math.PI * 2.0 + Utility._0023_003DzheSR8QM7q9ya)
				{
					t = angle.t0 + Math.PI * 2.0;
				}
				Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
			}
			else
			{
				Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
				if (angle.t1 - t > Math.PI * 2.0 + Utility._0023_003DzheSR8QM7q9ya)
				{
					t = angle.t1 - Math.PI * 2.0;
				}
				Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
			}
			Utility._0023_003Dz7iiwRWggF9n_(_0023_003DzJUOlPYhShISQ, ref angle);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public override bool ExtendBy(Point3D limit, bool curveEnd = true)
	{
		if (base.IsCircle)
		{
			return false;
		}
		base.Project(limit, out var t);
		Interval _0023_003DzJUOlPYhShISQ = angle;
		if (curveEnd)
		{
			Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
			Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
		}
		else
		{
			Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
			Arc._0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
		}
		Utility._0023_003Dz7iiwRWggF9n_(_0023_003DzJUOlPYhShISQ, ref angle);
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	public override bool Project(Point3D pt, out double t)
	{
		double num = _0023_003DzAzVFPYFo2TLf(pt);
		if (Math.Abs(Math.Abs(num) - Math.PI * 2.0) < Utility._0023_003DzxhnLabVjXjPg)
		{
			num = 0.0;
		}
		t = angle.t0 + num;
		if ((t < angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length)) || (t > angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length)))
		{
			Curve nurbsForm;
			using (new _0023_003DzspExml1j72mr_FI04NKW780_003D())
			{
				nurbsForm = GetNurbsForm();
			}
			nurbsForm.Project(pt, out var t2);
			if (Utility.AreEqual(t2, nurbsForm.Domain.Low, nurbsForm.Domain.Length))
			{
				t = angle.t0;
				return true;
			}
			if (Utility.AreEqual(t2, nurbsForm.Domain.High, nurbsForm.Domain.Length))
			{
				t = angle.t1;
				return true;
			}
			if (t2 > nurbsForm.Domain.Low && t2 < nurbsForm.Domain.High)
			{
				Point3D point3D = nurbsForm.PointAt(t2);
				Point3D b = PointAt(t);
				if (Point3D.Distance(point3D, b) > (base.RadiusX + base.RadiusY) / 4.0)
				{
					return Project(point3D, out t);
				}
			}
		}
		return true;
	}

	public override void ClosestPointTo(Point3D pt, out double t)
	{
		double num = _0023_003DzAzVFPYFo2TLf(pt);
		t = angle.t0 + num;
		if ((t < angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length)) || (t > angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length)))
		{
			bool flag = false;
			_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
			Curve nurbsForm;
			try
			{
				nurbsForm = GetNurbsForm();
			}
			finally
			{
				((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
			}
			nurbsForm.Project(pt, out var t2);
			if (Utility.AreEqual(t2, nurbsForm.Domain.Low, nurbsForm.Domain.Length))
			{
				t = angle.t0;
				flag = true;
			}
			else if (Utility.AreEqual(t2, nurbsForm.Domain.High, nurbsForm.Domain.Length))
			{
				t = angle.t1;
				flag = true;
			}
			else if (t2 > nurbsForm.Domain.Low && t2 < nurbsForm.Domain.High)
			{
				Point3D point = nurbsForm.PointAt(t2);
				Project(point, out t);
				flag = true;
			}
			if (!flag)
			{
				if (Point3D.DistanceSquared(pt, StartPoint) <= Point3D.DistanceSquared(pt, EndPoint))
				{
					t = angle.t0;
				}
				else
				{
					t = angle.t1;
				}
				return;
			}
		}
		double num2 = Point3D.DistanceSquared(pt, PointAt(t));
		double num3 = Point3D.DistanceSquared(pt, EndPoint);
		if (num3 < num2)
		{
			if (Point3D.DistanceSquared(pt, StartPoint) <= num3)
			{
				t = angle.t0;
			}
			else
			{
				t = angle.t1;
			}
		}
		else if (Point3D.DistanceSquared(pt, StartPoint) <= num2)
		{
			t = angle.t0;
		}
	}

	private double _0023_003DzAzVFPYFo2TLf(Point3D _0023_003DzMlCq3wk_003D)
	{
		base.Project(_0023_003DzMlCq3wk_003D, out var t);
		for (t -= angle.t0; t < 0.0; t += Math.PI * 2.0)
		{
		}
		while (t > Math.PI * 2.0 || Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0))
		{
			t -= Math.PI * 2.0;
		}
		return t;
	}

	public override Curve GetNurbsForm()
	{
		if (Utility._0023_003Dz1hSRhoQON8zJ(angle))
		{
			if (angle.Low == 0.0)
			{
				return base.GetNurbsForm();
			}
			EllipticalArc ellipticalArc = new EllipticalArc(base.Plane, Point2D.Origin, base.RadiusX, base.RadiusY, angle.Low, angle.Low + Math.PI);
			EllipticalArc ellipticalArc2 = new EllipticalArc(base.Plane, Point2D.Origin, base.RadiusX, base.RadiusY, angle.Low + Math.PI, angle.Low + Math.PI * 2.0);
			return Curve.Merge(new ICurve[2]
			{
				ellipticalArc.GetNurbsForm(),
				ellipticalArc2.GetNurbsForm()
			}, clean: true, resetDomain: false);
		}
		Point3D startPoint = StartPoint;
		Vector3D vector3D = TangentAt(Domain.t0);
		Point3D endPoint = EndPoint;
		Vector3D vector3D2 = TangentAt(Domain.t1);
		Point3D point3D = PointAt(Domain.Mid);
		if (Vector3D.AreCoincident(vector3D, vector3D2, 1E-06))
		{
			if (Math.Abs(angle.Length - Math.PI * 2.0) < 0.01)
			{
				return base.GetNurbsForm();
			}
			return Curve.GlobalInterpolation(new Point3D[3] { startPoint, point3D, endPoint }, 2);
		}
		if (Utility.Compare(Math.PI, Domain.Length) == 0)
		{
			vector3D2 = new Vector3D(0.0 - vector3D.X, 0.0 - vector3D.Y, 0.0 - vector3D.Z);
		}
		Curve curve = new Curve(startPoint, vector3D, endPoint, vector3D2, point3D);
		if (curve.Degree == 0)
		{
			curve = new Line(startPoint, endPoint).GetNurbsForm();
			curve.DegreeElevate(1);
		}
		curve._0023_003DziP9fFuA_003D.Scale(Domain.Length);
		curve._0023_003DziP9fFuA_003D.Offset(Domain.t0);
		return curve;
	}

	private Curve _0023_003DzYwS8zldTEAkl()
	{
		Curve[] array = new Curve[4]
		{
			new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, 0.0, Math.PI / 2.0).GetNurbsForm(),
			new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, Math.PI / 2.0, Utility._0023_003DzSNemwQo_003D).GetNurbsForm(),
			new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, Utility._0023_003DzSNemwQo_003D, 4.71238898038469).GetNurbsForm(),
			new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, 4.71238898038469, Math.PI * 2.0).GetNurbsForm()
		};
		Curve[] array2 = new Curve[5];
		int num = (int)Math.Floor(Domain.Low / (Math.PI / 2.0));
		if (num < 0)
		{
			num = 4 + num;
		}
		for (int i = 0; i < num; i++)
		{
			array2[i] = array[i];
		}
		array2[num] = new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, Math.PI / 2.0 * (double)num, Domain.Low).GetNurbsForm();
		array2[num + 1] = new EllipticalArc(base.Plane, base.Center, base.RadiusX, base.RadiusY, Domain.Low, Math.PI / 2.0 * (double)(num + 1)).GetNurbsForm();
		for (int j = num + 2; j < 5; j++)
		{
			array2[j] = array[j - 1];
		}
		Curve[] array3 = new Curve[5];
		int num2 = 0;
		int num3 = num + 1;
		while (num3 <= 5)
		{
			array3[num2] = array2[num3 % 5];
			num3++;
			num2++;
		}
		Curve curve = Curve.Merge(array3, clean: true);
		curve.KnotVector.Offset(Domain.Low);
		return curve;
	}

	public override void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		if (angle.IsTwoPI)
		{
			base.GetTightBBox(out boxMin, out boxMax);
			return;
		}
		double[] array = new double[3]
		{
			Utility.ArcTanProblem(base.RadiusX * base.Plane.AxisX.X, base.RadiusY * base.Plane.AxisY.X),
			Utility.ArcTanProblem(base.RadiusX * base.Plane.AxisX.Y, base.RadiusY * base.Plane.AxisY.Y),
			Utility.ArcTanProblem(base.RadiusX * base.Plane.AxisX.Z, base.RadiusY * base.Plane.AxisY.Z)
		};
		List<double> list = new List<double>();
		for (int i = 0; i < 3; i++)
		{
			if (Utility._0023_003DzHIeX7C3oyv3F(array[i], Domain, _0023_003DzQFI4Hrif1AaZ: true, out var _0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D))
			{
				list.AddRange(_0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D);
			}
		}
		list.Add(angle.t0);
		list.Add(angle.t1);
		list = list.Distinct().ToList();
		Point3D[] array2 = new Point3D[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			array2[j] = PointAt(list[j]);
		}
		Utility.ComputeBoundingBox(array2, out boxMin, out boxMax);
	}

	public override void Regen(RegenParams data)
	{
		int num = Utility.NumberOfSegments(Math.Max(_radiusY, _radiusX), angle.Length, data.Deviation, data.Angle);
		_vertices = new Point3D[num + 1];
		for (int i = 0; i < num + 1; i++)
		{
			double t = angle.t0 + (double)i * angle.Length / (double)num;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		double radiusX = base.RadiusX;
		double radiusY = base.RadiusY;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D(1.0 / (radiusX * radiusX), 1.0 / (radiusY * radiusY), new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ).Matrix, 0.0, 0.0, 0.0, -1.0, radiusX * Math.Cos(Domain.Min), radiusY * Math.Sin(Domain.Min), radiusX * Math.Cos(Domain.Max), radiusY * Math.Sin(Domain.Max), ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 };
	}

	public override bool GetParamFromLength(double length, double curveLength, out double t)
	{
		if (Utility.AreEqual(length, 0.0, curveLength))
		{
			t = Domain.Low;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = Domain.High;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = Domain.Low;
			return false;
		}
		t = Domain.Low + Domain.Length / 2.0;
		return _0023_003DzfBAEGQbap942tumNKRuGZg1QNxBX(length, curveLength, ref t);
	}

	public override bool SubCurve(double t0, double t1, out ICurve sub)
	{
		bool flag = Math.Abs(Math.Abs(angle.Length) - Math.PI * 2.0) < 1E-12;
		if (!Circle._0023_003DzJUU5L0s5zlzq(flag, angle.t0, angle.t1, Math.PI * 2.0, ref t0, ref t1))
		{
			sub = null;
			return false;
		}
		if (flag && Math.Abs(Math.Abs(t1 - t0) - Math.PI * 2.0) < 1E-12)
		{
			sub = (EllipticalArc)Clone();
			return true;
		}
		sub = new EllipticalArc(base.Plane, base.Plane.Origin, base.RadiusX, base.RadiusY, t0, t1);
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	public override bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		if (t > angle.t0 + 1E-12 && t < angle.t1 - 1E-12)
		{
			lower = new EllipticalArc(base.Plane, (Point3D)base.Center.Clone(), _radiusX, _radiusY, angle.t0, t);
			upper = new EllipticalArc(base.Plane, (Point3D)base.Center.Clone(), _radiusX, _radiusY, t, angle.t1);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new EllipticalArcSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955066), angle);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		if (IsClosed)
		{
			return base.EstimateBoundingBox(blocks, layers);
		}
		Point3D[] array = new Point3D[3];
		double length = angle.Length;
		array[0] = PointAt(angle.t0 + 0.0 * length / 2.0);
		array[1] = PointAt(angle.t0 + length / 2.0);
		array[2] = PointAt(angle.t0 + 2.0 * length / 2.0);
		return array;
	}

	public override Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Point3D[] array = new Brep.Vertex[4];
		Point3D[] array2 = array;
		array2[0] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.StartPoint.X, _0023_003Dz6nnnQo75Qjsf.StartPoint.Y, _0023_003Dz6nnnQo75Qjsf.StartPoint.Z);
		array2[1] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.EndPoint.X, _0023_003Dz6nnnQo75Qjsf.EndPoint.Y, _0023_003Dz6nnnQo75Qjsf.EndPoint.Z);
		array2[2] = new Brep.Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
		array2[3] = new Brep.Vertex(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
		Brep.Edge[] edges = new Brep.Edge[4]
		{
			new Brep.Edge((ICurve)_0023_003Dz6nnnQo75Qjsf.Clone(), 0, 1),
			new Brep.Edge((ICurve)curve.Clone(), 2, 3),
			new Brep.Edge(new Line((Point3D)array2[0].Clone(), (Point3D)array2[2].Clone()), 0, 2),
			new Brep.Edge(new Line((Point3D)array2[1].Clone(), (Point3D)array2[3].Clone()), 1, 3)
		};
		Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
		{
			new Brep.OrientedEdge(0),
			new Brep.OrientedEdge(3),
			new Brep.OrientedEdge(1, sense: false),
			new Brep.OrientedEdge(2, sense: false)
		};
		Surface surface = Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve);
		NurbsSurf surface2 = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		return new Brep(array2, edges, new Brep.Face[1]
		{
			new Brep.Face(surface2, new Brep.Loop(segments))
		});
	}

	public override Region OffsetToRegion(double amount, bool sharp)
	{
		if (IsClosed)
		{
			return base.OffsetToRegion(amount, sharp);
		}
		ICurve curve = (ICurve)Clone();
		ICurve[] array = Offset(amount, base.Plane.AxisZ, sharp);
		ICurve curve2 = ((array != null) ? array[0] : null);
		if (amount > 0.0)
		{
			curve.Reverse();
		}
		else
		{
			curve2.Reverse();
		}
		Line line = new Line(curve2.EndPoint, curve.StartPoint);
		Line line2 = new Line(curve.EndPoint, curve2.StartPoint);
		return new Region(new CompositeCurve(new ICurve[4] { line, curve, line2, curve2 }, sortAndOrient: false), base.Plane, sortAndOrient: false);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2 = new _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D(new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(new _0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D(base.Plane.Origin.ToArray(), base.RadiusX, base.RadiusY, base.Plane.AxisX.ToArray(), base.Plane.AxisY.ToArray())), Domain.Min, Domain.Max, _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D: false);
		_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2._0023_003Dzx3pYiE0_003D = true;
		_0023_003DzYe_6EnQecc8d(_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2 };
	}
}
