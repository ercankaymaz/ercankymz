using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class ConicalSurf : CylindricalSurf
{
	private readonly double _halfAngle;

	public double HalfAngle => _halfAngle;

	public Point3D Tip
	{
		get
		{
			if (!(Math.Sin(_halfAngle) * Math.Cos(_halfAngle) < 0.0))
			{
				return base.Plane.Origin - base.Plane.AxisZ * Math.Abs(base.Radius / Math.Tan(Math.Abs(_halfAngle)));
			}
			return base.Plane.Origin + base.Plane.AxisZ * Math.Abs(base.Radius / Math.Tan(Math.Abs(_halfAngle)));
		}
	}

	public ConicalSurf(Point3D location, Vector3D axis, Vector3D refDir, double radius, double halfAngle, int index = 0)
		: base(location, axis, refDir, radius, index)
	{
		_halfAngle = halfAngle;
	}

	protected internal ConicalSurf(Plane plane, double radius, double halfAngle, int index = 0)
		: base(plane, radius, index)
	{
		_halfAngle = halfAngle;
	}

	public ConicalSurf(ConicalSurf another)
		: base(another)
	{
		_halfAngle = another._halfAngle;
	}

	public override object Clone()
	{
		return new ConicalSurf(this);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new ConicalSurfSurrogate(this);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Vector3D vector3D = base.Normal(point, out tu, out tv);
		Vector3D axis = Vector3D.Cross(vector3D, base.Plane.AxisZ);
		double angleInRadians = 0.0 - _halfAngle;
		vector3D.TransformBy(new Rotation(angleInRadians, axis, Point3D.Origin));
		tv.TransformBy(new Rotation(angleInRadians, axis, Point3D.Origin));
		return vector3D;
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D;
		Surface surface = _0023_003Dz6VRTLeo_003D(trimLoops, out _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
		surface.TranslationID = base.TranslationID;
		if (reverse)
		{
			surface.ReverseU();
		}
		return Surface._0023_003DzNxaR6FzQJCTX(surface, trimLoops, _0023_003Dz4IdClGB7rrJOo8FQbQ_003D_003D: true, _0023_003DzpGLMqOBpGtiN_0024iaD_0024A_003D_003D: false, _0023_003DzBBEA37cFU9UA_HEvnA_003D_003D: false, null);
	}

	public override Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated)
	{
		Surface surface = _0023_003Dz6VRTLeo_003D(edgeCurves, out notRotated);
		surface.TranslationID = base.TranslationID;
		notRotated.TranslationID = base.TranslationID;
		if (!sense)
		{
			surface.ReverseU();
			notRotated.ReverseU();
		}
		return surface;
	}

	internal Surface _0023_003Dz6VRTLeo_003D(IList<ICurve> _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		PlanarSurf._0023_003DzHNhzuamBoympuHB_8w_003D_003D(base.Plane, _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, out var _0023_003DzG0W_0024gTEMzheB);
		bool flag = Math.Sin(_halfAngle) * Math.Cos(_halfAngle) < 0.0;
		Line _0023_003DzOGUeWbk_003D;
		if (_0023_003DzG0W_0024gTEMzheB.Length > 1E-12)
		{
			bool flag2 = false;
			if (_0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D.Count == 1 && _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D[0].IsClosed)
			{
				Plane plane = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
				ICurve[] individualCurves = _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D[0].GetIndividualCurves();
				for (int i = 0; i < individualCurves.Length; i++)
				{
					ICurve curve = individualCurves[i];
					if (Math.Abs(plane.DistanceTo(curve.StartPoint)) < Utility._0023_003Dzjyaz_Vfaky9X)
					{
						plane.Project(curve.StartPoint, out var s, out var _);
						if (s > 0.0 && i > 0 && Vector3D.AreCoincident(individualCurves[i - 1].EndTangent, curve.StartTangent))
						{
							flag2 = Math.Abs(HalfAngle) > 0.1;
						}
					}
				}
			}
			double length = _0023_003DzG0W_0024gTEMzheB.Length;
			if (flag)
			{
				double num = Math.Abs(base.Radius / Math.Tan(Math.Abs(_halfAngle)));
				_0023_003DzG0W_0024gTEMzheB.t0 -= length * base.ExtensionAmount;
				_0023_003DzG0W_0024gTEMzheB.t1 += length * base.ExtensionAmount;
				if (_0023_003DzG0W_0024gTEMzheB.t1 > num || flag2)
				{
					_0023_003DzG0W_0024gTEMzheB.t1 = num;
				}
			}
			else
			{
				double num = 0.0 - Math.Abs(base.Radius / Math.Tan(Math.Abs(_halfAngle)));
				_0023_003DzG0W_0024gTEMzheB.t0 -= length * base.ExtensionAmount;
				if (_0023_003DzG0W_0024gTEMzheB.t0 < num || flag2)
				{
					_0023_003DzG0W_0024gTEMzheB.t0 = num;
				}
				_0023_003DzG0W_0024gTEMzheB.t1 += length * base.ExtensionAmount;
			}
		}
		else
		{
			if (Utility.AreEqual(Math.Abs(_halfAngle), Math.PI / 2.0, 1.0))
			{
				PlanarSurf._0023_003Dzq2rheECiVvE_Rpm9bw_003D_003D(new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ), _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, out var _0023_003Dz5D8mFln5vcyJ);
				double num2 = _0023_003Dz5D8mFln5vcyJ.Length * base.ExtensionAmount;
				double num3 = _0023_003Dz5D8mFln5vcyJ.t0 - num2;
				_0023_003Dz5D8mFln5vcyJ.t0 = ((num3 > Utility._0023_003DzxhnLabVjXjPg) ? num3 : 0.0);
				_0023_003Dz5D8mFln5vcyJ.t1 += num2;
				Point3D start = base.Plane.Origin + base.Plane.AxisX * _0023_003Dz5D8mFln5vcyJ.t0;
				Point3D end = base.Plane.Origin + base.Plane.AxisX * _0023_003Dz5D8mFln5vcyJ.t1;
				_0023_003DzOGUeWbk_003D = new Line(start, end);
				return _0023_003DztQPGNFuy20PDvagYoZnbvj7NmyLe(_0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, _0023_003DzOGUeWbk_003D, out _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
			}
			ICurve curve2 = _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D[0].GetIndividualCurves()[0];
			double num4;
			if (curve2 is Circle)
			{
				num4 = ((Circle)curve2).Radius;
			}
			else if (curve2 is Ellipse)
			{
				num4 = ((Ellipse)curve2).RadiusX;
			}
			else if (curve2 is Line)
			{
				Line obj = (Line)curve2;
				Segment3D seg = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ);
				double val = obj.StartPoint.DistanceTo(seg);
				double val2 = obj.EndPoint.DistanceTo(seg);
				num4 = Math.Max(val, val2);
			}
			else
			{
				Curve curve3 = (Curve)curve2;
				num4 = 1.0 / curve3.Curvature(curve2.Domain.ParameterAt(0.0));
			}
			double num5 = num4 / Math.Tan(Math.Abs(_halfAngle));
			if (_halfAngle < 0.0)
			{
				_0023_003DzG0W_0024gTEMzheB.t1 += num5;
				_0023_003DzG0W_0024gTEMzheB.t0 -= _0023_003DzG0W_0024gTEMzheB.Length * base.ExtensionAmount;
			}
			else
			{
				_0023_003DzG0W_0024gTEMzheB.t0 -= num5;
				_0023_003DzG0W_0024gTEMzheB.t1 += _0023_003DzG0W_0024gTEMzheB.Length * base.ExtensionAmount;
			}
		}
		Point3D point3D = base.Plane.Origin + base.Plane.AxisX * base.Radius;
		Point3D obj2 = (Point3D)point3D.Clone();
		double num6 = Math.Cos(_halfAngle);
		Point3D start2 = obj2 + base.Plane.AxisZ * _0023_003DzG0W_0024gTEMzheB.t0 / Math.Abs(num6);
		Point3D end2 = (Point3D)point3D.Clone();
		end2 += base.Plane.AxisZ * _0023_003DzG0W_0024gTEMzheB.t1 / Math.Abs(num6);
		_0023_003DzOGUeWbk_003D = new Line(start2, end2);
		if (num6 < 0.0)
		{
			_0023_003DzOGUeWbk_003D.Reverse();
		}
		double num7 = _halfAngle;
		if (_halfAngle < -Math.PI / 2.0)
		{
			num7 += Utility._0023_003DzSNemwQo_003D;
		}
		else if (_halfAngle > Math.PI / 2.0)
		{
			num7 -= Utility._0023_003DzSNemwQo_003D;
		}
		_0023_003DzOGUeWbk_003D.Rotate(num7, base.Plane.AxisY, point3D);
		return _0023_003DztQPGNFuy20PDvagYoZnbvj7NmyLe(_0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, _0023_003DzOGUeWbk_003D, out _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
	}

	private Surface _0023_003DztQPGNFuy20PDvagYoZnbvj7NmyLe(IList<ICurve> _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, Line _0023_003DzOGUeWbk_003D, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		Surface surface = _0023_003DzOGUeWbk_003D.RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = (Surface)surface.Clone();
		if (surface is RevolvedSurface && Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(base.Plane, _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, surface, out var _0023_003Dz6pajdGM_003D))
		{
			surface.Rotate(_0023_003Dz6pajdGM_003D, base.Plane.AxisZ, base.Plane.Origin);
		}
		return surface;
	}

	private bool _0023_003DzhQrBLRX_EHjSK0cHarsCadVpLbsq(IList<ICurve> _0023_003DzRTbTK_0024KwG32W)
	{
		Vector3D vector3D = null;
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			if (item is Circle)
			{
				if (vector3D == null)
				{
					vector3D = ((Circle)item).Plane.AxisZ;
				}
				else if (Vector3D.AreOpposite(((Circle)item).Plane.AxisZ, vector3D))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963747) + _halfAngle + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(_halfAngle) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		return stringBuilder.ToString();
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
		double num = (double)(-Math.Sign(Math.Sin(_halfAngle) * Math.Cos(_halfAngle))) * Math.Abs(base.Radius / Math.Tan(Math.Abs(_halfAngle)));
		Point3D _0023_003DzPzO_0024GUk_003D = base.Plane.Origin + base.Plane.AxisZ * num;
		if (num > 0.0)
		{
			collapsedEdges._0023_003DzvBU31wjltOH3(_0023_003DzPzO_0024GUk_003D);
		}
		else
		{
			collapsedEdges._0023_003DzusxA4ZTGhQeL(_0023_003DzPzO_0024GUk_003D);
		}
	}

	public override Point3D PointAt(double u, double v)
	{
		double num = base.Radius + v * Math.Sin(HalfAngle);
		return base.Plane.PointAt(num * Math.Cos(u), num * Math.Sin(u), v * Math.Cos(HalfAngle));
	}

	public new Point3D[] IntersectWith(Segment3D line)
	{
		Transformation xform = Transformation.CreateAlignment(base.Plane, Plane.XY);
		Point3D point3D = (Point3D)line.P0.Clone();
		Point3D point3D2 = (Point3D)line.P1.Clone();
		point3D.TransformBy(xform);
		point3D2.TransformBy(xform);
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		double length = vector3D.Length;
		vector3D.Normalize();
		double num = Math.Cos(HalfAngle) * Math.Cos(HalfAngle);
		double num2 = 1.0 - num;
		double num3 = base.Radius / Math.Tan(Math.Abs(HalfAngle));
		if (HalfAngle > 0.0)
		{
			num3 *= -1.0;
		}
		double num4 = point3D.Z - num3;
		double num5 = (0.0 - num) * vector3D.LengthSquared + vector3D.Z * vector3D.Z;
		double num6 = (0.0 - num) * vector3D.X * point3D.X - num * vector3D.Y * point3D.Y + num2 * vector3D.Z * num4;
		double num7 = (0.0 - num) * point3D.X * point3D.X - num * point3D.Y * point3D.Y + num2 * num4 * num4;
		double num8 = num6 * num6 - num5 * num7;
		List<double> list = new List<double>();
		if (num8 > Utility._0023_003DzxhnLabVjXjPg)
		{
			if (Math.Abs(num5) < Utility._0023_003DzxhnLabVjXjPg)
			{
				if (Math.Abs(num6) > Utility._0023_003DzxhnLabVjXjPg)
				{
					list.Add((0.0 - num6) / (2.0 * num6));
				}
			}
			else
			{
				list.Add((0.0 - num6 + Math.Sqrt(num8)) / num5);
				list.Add((0.0 - num6 - Math.Sqrt(num8)) / num5);
			}
		}
		else if (Math.Abs(num8) < Utility._0023_003DzxhnLabVjXjPg && num5 != 0.0)
		{
			list.Add((0.0 - num6) / num5);
		}
		List<Point3D> list2 = new List<Point3D>();
		for (int i = 0; i < list.Count; i++)
		{
			double num9 = list[i];
			Point3D point3D3 = point3D + num9 * vector3D;
			if (!(num9 < 0.0 - Utility._0023_003DzxhnLabVjXjPg) && !(num9 > (1.0 + Utility._0023_003DzxhnLabVjXjPg) * length) && !((!(HalfAngle > 0.0)) ? (num3 - point3D3.Z < 0.0) : (num3 - point3D3.Z > 0.0)))
			{
				double num10 = point3D3.Z / Math.Cos(HalfAngle);
				double num11 = Math.Atan2(point3D3.Y, point3D3.X);
				if (num11 < 0.0)
				{
					num11 += Math.PI * 2.0;
				}
				Point3D point3D4 = PointAt(num11, num10);
				list2.Add(new InitialPoint(point3D4.X, point3D4.Y, point3D4.Z, num9, 0.0, num11, num10));
			}
		}
		return list2.ToArray();
	}
}
