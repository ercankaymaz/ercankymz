using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D
{
	public enum _0023_003DzWbIbatcG6O_00243
	{

	}

	public Point3D[] _0023_003DzQ7usAag_003D(ICurve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003DzF7GfYSI_003D, double _0023_003DzccAR5G0_003D)
	{
		return _0023_003DzQ7usAag_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D, null, _0023_003DzccAR5G0_003D);
	}

	public Point3D[] _0023_003DzQ7usAag_003D(ICurve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003DzF7GfYSI_003D, Plane _0023_003DztbNIz2B1iYtt, double _0023_003DzccAR5G0_003D)
	{
		Point3D[] array = _0023_003DzQ7usAag_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D, _0023_003DztbNIz2B1iYtt, _0023_003DzccAR5G0_003D, null, null, null, null, null);
		List<Point3D> list = new List<Point3D>();
		Point3D[] array2 = array;
		foreach (Point3D point3D in array2)
		{
			if (Surface._0023_003Dz5uD5f33zAE2Q(new InitialPoint(point3D.X, point3D.Y, point3D.Z, ((InterPoint)point3D).u, ((InterPoint)point3D).v, ((InterPoint)point3D).s, ((InterPoint)point3D).t), _0023_003DzF7GfYSI_003D, _0023_003DzF7GfYSI_003D._0023_003DzVx1luJEZaaC7().Diagonal, _0023_003DzRVoDPs0_003D: false))
			{
				list.Add(point3D);
			}
		}
		return list.ToArray();
	}

	private static bool _0023_003DzbIDY9BOTPqfc(Point3D _0023_003DzOHpyMcKw0SXo, List<Point3D> _0023_003DzTyB0NW0_003D, double _0023_003DzccAR5G0_003D, ICurve _0023_003DzshZYG54_003D, Surface _0023_003DzR58imxw_003D)
	{
		if (_0023_003DzTyB0NW0_003D.Count == 0)
		{
			_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
			return true;
		}
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		if (_0023_003DzR58imxw_003D.collapsedEdges != null)
		{
			if (_0023_003DzR58imxw_003D.collapsedEdges._0023_003Dze5l_0024RiEBG8Fu() != null && Point3D.Distance(_0023_003DzOHpyMcKw0SXo, _0023_003DzR58imxw_003D.collapsedEdges._0023_003Dze5l_0024RiEBG8Fu()) / _0023_003DzccAR5G0_003D < Utility._0023_003Dzjyaz_Vfaky9X)
			{
				flag = true;
			}
			if (_0023_003DzR58imxw_003D.collapsedEdges._0023_003DzVa_0024oj2xEedri() != null && Point3D.Distance(_0023_003DzOHpyMcKw0SXo, _0023_003DzR58imxw_003D.collapsedEdges._0023_003DzVa_0024oj2xEedri()) / _0023_003DzccAR5G0_003D < Utility._0023_003Dzjyaz_Vfaky9X)
			{
				flag = true;
			}
			if (_0023_003DzR58imxw_003D.collapsedEdges._0023_003DzdeQouaJ8sRT8() != null && Point3D.Distance(_0023_003DzOHpyMcKw0SXo, _0023_003DzR58imxw_003D.collapsedEdges._0023_003DzdeQouaJ8sRT8()) / _0023_003DzccAR5G0_003D < Utility._0023_003Dzjyaz_Vfaky9X)
			{
				flag2 = true;
			}
			if (_0023_003DzR58imxw_003D.collapsedEdges._0023_003Dz7Q8NCjwVr8CM() != null && Point3D.Distance(_0023_003DzOHpyMcKw0SXo, _0023_003DzR58imxw_003D.collapsedEdges._0023_003Dz7Q8NCjwVr8CM()) / _0023_003DzccAR5G0_003D < Utility._0023_003Dzjyaz_Vfaky9X)
			{
				flag2 = true;
			}
		}
		foreach (InterPoint item in _0023_003DzTyB0NW0_003D)
		{
			if (Point3D.Distance(item, _0023_003DzOHpyMcKw0SXo) / _0023_003DzccAR5G0_003D < Utility._0023_003Dzjyaz_Vfaky9X)
			{
				InterPoint interPoint2 = (InterPoint)_0023_003DzOHpyMcKw0SXo;
				if (Utility.AreEqual(item.u, interPoint2.u, _0023_003DzshZYG54_003D.Domain.Length * 10000.0) && (flag || Utility.AreEqual(item.s, interPoint2.s, _0023_003DzR58imxw_003D.DomainU.Length * 10000.0)) && (flag2 || Utility.AreEqual(item.t, interPoint2.t, _0023_003DzR58imxw_003D.DomainV.Length * 10000.0)))
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
			return true;
		}
		return false;
	}

	public Point3D[] _0023_003DzQ7usAag_003D(ICurve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003DzF7GfYSI_003D, Plane _0023_003DztbNIz2B1iYtt, double _0023_003DzccAR5G0_003D, TrimCurve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU, AnalyticSurf _0023_003DzCR0hmkqR988uzp4COA_003D_003D, Surface _0023_003Dz4wZe_0024Xg_003D, Vector3D _0023_003DzPsHFxZf6VuL6)
	{
		bool num = Utility.IsLine(_0023_003Dz8fpRyMu9aKjE);
		bool flag = _0023_003Dz8fpRyMu9aKjE.GetType() == typeof(Circle);
		PlanarSurface ps;
		bool flag2 = _0023_003DzF7GfYSI_003D is PlanarSurface || (_0023_003DzF7GfYSI_003D is TabulatedSurface tabulatedSurface && tabulatedSurface.TryGetPlanar(out ps));
		bool flag3 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D is TabulatedSurf { Directrix: Circle directrix } tabulatedSurf && Vector3D.AreParallel((Vector3D)tabulatedSurf.Generatrix.Clone() / tabulatedSurf.Generatrix.Length, directrix.Plane.AxisZ);
		bool flag4 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D.GetType() == typeof(CylindricalSurf);
		bool flag5 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D is TabulatedSurf { Directrix: Ellipse { IsCircle: not false } directrix2 } tabulatedSurf2 && Vector3D.AreParallel((Vector3D)tabulatedSurf2.Generatrix.Clone() / tabulatedSurf2.Generatrix.Length, directrix2.Plane.AxisZ);
		bool flag6 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D is RevolvedSurf revolvedSurf && Utility.IsLine(revolvedSurf.Generatrix) && Vector3D.AreParallel(revolvedSurf.Generatrix.StartTangent, revolvedSurf.Plane.AxisZ);
		bool flag7 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D.GetType() == typeof(ConicalSurf);
		bool flag8 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D.GetType() == typeof(SphericalSurf);
		bool flag9 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D is RevolvedSurf { Generatrix: Arc { Domain: { Length: var length } } generatrix } revolvedSurf2 && Utility._0023_003Dz_Dm7r9Ftq7Ss(length, Math.PI, generatrix.Domain.Length) && generatrix.Center == revolvedSurf2.Plane.Origin;
		bool flag10 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D.GetType() == typeof(ToroidalSurf);
		bool flag11 = _0023_003DzCR0hmkqR988uzp4COA_003D_003D != null && _0023_003DzCR0hmkqR988uzp4COA_003D_003D is RevolvedSurf { Generatrix: Arc generatrix2 } revolvedSurf3 && Math.Abs(revolvedSurf3.Plane.DistanceTo(generatrix2.Center)) < Utility._0023_003DzxhnLabVjXjPg && generatrix2.Center != revolvedSurf3.Plane.Origin;
		bool num2 = (num || flag) && (flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9 || flag10 || flag11);
		bool _0023_003Dzx3pYiE0_003D = true;
		Surface _0023_003Dz_0024KKopL9T7nzT;
		AnalyticSurf _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
		if (num2 && _0023_003Dz4wZe_0024Xg_003D != null)
		{
			if (_0023_003DzPsHFxZf6VuL6 != null)
			{
				Transformation xform = Transformation.CreateTranslation(_0023_003DzPsHFxZf6VuL6);
				((Entity)_0023_003Dz8fpRyMu9aKjE).TransformBy(xform);
			}
			if (flag2)
			{
				_0023_003Dzx3pYiE0_003D = true;
			}
			else if (flag4)
			{
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(v: ((CylindricalSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Plane.AxisZ, u: ((CylindricalSurface)_0023_003Dz4wZe_0024Xg_003D).SeamPlane.AxisY);
			}
			else if (flag3)
			{
				Circle circle = (Circle)((TabulatedSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Directrix;
				new CylindricalSurf(circle.Plane, circle.Radius);
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(circle.Plane.AxisZ, ((Circle)((TabulatedSurface)_0023_003Dz4wZe_0024Xg_003D).Directrix).Plane.AxisZ);
			}
			else if (flag5)
			{
				Ellipse ellipse = (Ellipse)((TabulatedSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Directrix;
				Circle circle = new Circle(ellipse.Plane, ellipse.Center, ellipse.RadiusX);
				new CylindricalSurf(circle.Plane, circle.Radius);
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(circle.Plane.AxisZ, ((Circle)((TabulatedSurface)_0023_003Dz4wZe_0024Xg_003D).Directrix).Plane.AxisZ);
			}
			else if (flag6)
			{
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(((RevolvedSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Plane.AxisZ, ((RevolvedSurface)_0023_003Dz4wZe_0024Xg_003D).Axis);
			}
			else if (flag7)
			{
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(v: ((ConicalSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Plane.AxisZ, u: ((ConicalSurface)_0023_003Dz4wZe_0024Xg_003D).SeamPlane.AxisY);
			}
			else if (flag8)
			{
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(v: ((SphericalSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Plane.AxisZ, u: ((SphericalSurface)_0023_003Dz4wZe_0024Xg_003D).SeamPlane.AxisY);
			}
			else if (flag9)
			{
				RevolvedSurf obj = (RevolvedSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D;
				new SphericalSurf(radius: ((Arc)obj.Generatrix).Radius, plane: obj.Plane);
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(obj.Plane.AxisZ, ((Circle)((SphericalSurface)_0023_003Dz4wZe_0024Xg_003D).Generatrix).Plane.AxisZ);
			}
			else if (flag10)
			{
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(((ToroidalSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D).Plane.AxisZ, ((ToroidalSurface)_0023_003Dz4wZe_0024Xg_003D).Plane.AxisZ);
			}
			else
			{
				if (!flag11)
				{
					throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965701));
				}
				RevolvedSurf obj2 = (RevolvedSurf)_0023_003DzCR0hmkqR988uzp4COA_003D_003D;
				Arc arc = (Arc)obj2.Generatrix;
				double num3 = Math.Abs(obj2.Plane.Origin.DistanceTo(arc.Center));
				if (num3 < arc.Radius && arc.Domain.Length < Math.PI)
				{
					num3 *= -1.0;
				}
				new ToroidalSurf(obj2.Plane, num3, arc.Radius);
				_0023_003Dzx3pYiE0_003D = Vector3D.AreCoincident(obj2.Plane.AxisZ, ((ToroidalSurface)_0023_003Dz4wZe_0024Xg_003D).Axis);
			}
			_0023_003Dz_0024KKopL9T7nzT = _0023_003Dz4wZe_0024Xg_003D;
			_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D = _0023_003DzCR0hmkqR988uzp4COA_003D_003D;
		}
		else
		{
			_0023_003Dz_0024KKopL9T7nzT = _0023_003DzF7GfYSI_003D;
			_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D = null;
		}
		Point3D[] array = _0023_003Dz7XOXgvOEVlaU(_0023_003Dz_0024KKopL9T7nzT, _0023_003Dz8fpRyMu9aKjE, _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D, _0023_003Dzx3pYiE0_003D, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D: true, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003DztbNIz2B1iYtt, _0023_003DzccAR5G0_003D, _0023_003DznbZoSmWt0NXt6IJtqNzBrqOnUXC7: false);
		Point3D[] array2;
		if (num2 && _0023_003Dz4wZe_0024Xg_003D != null)
		{
			if (_0023_003DzPsHFxZf6VuL6 != null)
			{
				Transformation xform2 = Transformation.CreateTranslation(-1.0 * _0023_003DzPsHFxZf6VuL6);
				((Entity)_0023_003Dz8fpRyMu9aKjE).TransformBy(xform2);
				array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].TransformBy(xform2);
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				InitialPoint initialPoint = (InitialPoint)array[j].Clone();
				if (_0023_003DzF7GfYSI_003D is TabulatedSurface tabulatedSurface2)
				{
					initialPoint.s *= tabulatedSurface2.scaleU;
				}
				else if (_0023_003DzF7GfYSI_003D is RevolvedSurface revolvedSurface)
				{
					initialPoint.s *= revolvedSurface.scaleU;
					initialPoint.s += revolvedSurface.DomainU.Low;
					initialPoint.t *= revolvedSurface.scaleV;
					if (!(_0023_003DzF7GfYSI_003D is ToroidalSurface) && !(_0023_003DzF7GfYSI_003D is SphericalSurface))
					{
						initialPoint.t += revolvedSurface.DomainV.Low;
					}
				}
				array[j] = initialPoint;
			}
		}
		List<Point3D> list = new List<Point3D>(array);
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			InitialPoint initialPoint2 = (InitialPoint)array2[i];
			if (_0023_003DzF7GfYSI_003D.IsClosedU && Utility._0023_003DzuW42NHK3HaLL(initialPoint2.s, _0023_003DzF7GfYSI_003D.DomainU.Low, _0023_003DzF7GfYSI_003D.DomainU.Length))
			{
				InitialPoint initialPoint3 = new InitialPoint(initialPoint2.X, initialPoint2.Y, initialPoint2.Z, initialPoint2.u, initialPoint2.v, _0023_003DzF7GfYSI_003D.DomainU.High, initialPoint2.t);
				initialPoint3.curveTx = _0023_003Dz8fpRyMu9aKjE.EndTangent.X;
				initialPoint3.curveTy = _0023_003Dz8fpRyMu9aKjE.EndTangent.Y;
				initialPoint3.curveTz = _0023_003Dz8fpRyMu9aKjE.EndTangent.Z;
				initialPoint3._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
				if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
				{
					initialPoint3.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
				}
				else if (_0023_003DzoHguvx0by0LU != null)
				{
					initialPoint3.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
				}
				_0023_003DzbIDY9BOTPqfc(initialPoint3, list, _0023_003DzccAR5G0_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D);
			}
			else if (_0023_003DzF7GfYSI_003D.IsClosedU && Utility._0023_003DzuW42NHK3HaLL(initialPoint2.s, _0023_003DzF7GfYSI_003D.DomainU.High, _0023_003DzF7GfYSI_003D.DomainU.Length))
			{
				InitialPoint initialPoint4 = new InitialPoint(initialPoint2.X, initialPoint2.Y, initialPoint2.Z, initialPoint2.u, initialPoint2.v, _0023_003DzF7GfYSI_003D.DomainU.Low, initialPoint2.t);
				initialPoint4.curveTx = _0023_003Dz8fpRyMu9aKjE.EndTangent.X;
				initialPoint4.curveTy = _0023_003Dz8fpRyMu9aKjE.EndTangent.Y;
				initialPoint4.curveTz = _0023_003Dz8fpRyMu9aKjE.EndTangent.Z;
				initialPoint4._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
				if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
				{
					initialPoint4.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
				}
				else if (_0023_003DzoHguvx0by0LU != null)
				{
					initialPoint4.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
				}
				_0023_003DzbIDY9BOTPqfc(initialPoint4, list, _0023_003DzccAR5G0_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D);
			}
			if (_0023_003DzF7GfYSI_003D.IsClosedV && Utility._0023_003DzuW42NHK3HaLL(initialPoint2.t, _0023_003DzF7GfYSI_003D.DomainV.Low, _0023_003DzF7GfYSI_003D.DomainV.Length))
			{
				InitialPoint initialPoint5 = new InitialPoint(initialPoint2.X, initialPoint2.Y, initialPoint2.Z, initialPoint2.u, initialPoint2.v, initialPoint2.s, _0023_003DzF7GfYSI_003D.DomainV.High);
				initialPoint5.curveTx = _0023_003Dz8fpRyMu9aKjE.EndTangent.X;
				initialPoint5.curveTy = _0023_003Dz8fpRyMu9aKjE.EndTangent.Y;
				initialPoint5.curveTz = _0023_003Dz8fpRyMu9aKjE.EndTangent.Z;
				initialPoint5._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
				if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
				{
					initialPoint5.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
				}
				else if (_0023_003DzoHguvx0by0LU != null)
				{
					initialPoint5.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
				}
				_0023_003DzbIDY9BOTPqfc(initialPoint5, list, _0023_003DzccAR5G0_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D);
			}
			else if (_0023_003DzF7GfYSI_003D.IsClosedV && Utility._0023_003DzuW42NHK3HaLL(initialPoint2.t, _0023_003DzF7GfYSI_003D.DomainV.High, _0023_003DzF7GfYSI_003D.DomainV.Length))
			{
				InitialPoint initialPoint6 = new InitialPoint(initialPoint2.X, initialPoint2.Y, initialPoint2.Z, initialPoint2.u, initialPoint2.v, initialPoint2.s, _0023_003DzF7GfYSI_003D.DomainV.Low);
				initialPoint6.curveTx = _0023_003Dz8fpRyMu9aKjE.EndTangent.X;
				initialPoint6.curveTy = _0023_003Dz8fpRyMu9aKjE.EndTangent.Y;
				initialPoint6.curveTz = _0023_003Dz8fpRyMu9aKjE.EndTangent.Z;
				initialPoint6._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
				if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
				{
					initialPoint6.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
				}
				else if (_0023_003DzoHguvx0by0LU != null)
				{
					initialPoint6.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
				}
				_0023_003DzbIDY9BOTPqfc(initialPoint6, list, _0023_003DzccAR5G0_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D);
			}
		}
		return list.ToArray();
	}

	internal static Point3D[] _0023_003DzGxr4M_HPrMkl(ICurve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003DzF7GfYSI_003D, Plane _0023_003DztbNIz2B1iYtt, double _0023_003DzccAR5G0_003D, TrimCurve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU)
	{
		Curve nurbsForm = _0023_003Dz8fpRyMu9aKjE.GetNurbsForm();
		if (!_0023_003Dz5p7_0024ZhlZ7wNcqcc8Vw_003D_003D(nurbsForm, _0023_003DzF7GfYSI_003D, _0023_003DzccAR5G0_003D, out var _0023_003DzovIe_fE_003D))
		{
			return new Point3D[0];
		}
		List<Point3D> list = new List<Point3D>();
		foreach (Tuple<Curve, Surface> item in _0023_003DzovIe_fE_003D)
		{
			if (!_0023_003DzUhQEKrRzaznj(nurbsForm, _0023_003DzF7GfYSI_003D, item.Item1.Domain.Mid, item.Item2.DomainU.Mid, item.Item2.DomainV.Mid, _0023_003DzccAR5G0_003D, out var _0023_003DzqoHxF0k_003D))
			{
				continue;
			}
			_0023_003DzqoHxF0k_003D._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
			if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
			}
			else if (_0023_003DzoHguvx0by0LU != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
			}
			if ((_0023_003DzqoHxF0k_003D.u > _0023_003Dz8fpRyMu9aKjE.Domain.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003Dz8fpRyMu9aKjE.Domain.Low, _0023_003Dz8fpRyMu9aKjE.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.u < _0023_003Dz8fpRyMu9aKjE.Domain.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003Dz8fpRyMu9aKjE.Domain.High, _0023_003Dz8fpRyMu9aKjE.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s > _0023_003DzF7GfYSI_003D.DomainU.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzF7GfYSI_003D.DomainU.Low, _0023_003DzF7GfYSI_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s < _0023_003DzF7GfYSI_003D.DomainU.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzF7GfYSI_003D.DomainU.High, _0023_003DzF7GfYSI_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t > _0023_003DzF7GfYSI_003D.DomainV.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzF7GfYSI_003D.DomainV.Low, _0023_003DzF7GfYSI_003D.DomainV.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t < _0023_003DzF7GfYSI_003D.DomainV.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzF7GfYSI_003D.DomainV.High, _0023_003DzF7GfYSI_003D.DomainV.Length * 10.0)) && _0023_003DzbIDY9BOTPqfc(_0023_003DzqoHxF0k_003D, list, _0023_003DzccAR5G0_003D, nurbsForm, _0023_003DzF7GfYSI_003D))
			{
				Vector3D vector3D = item.Item1.TangentAt(_0023_003DzqoHxF0k_003D.u);
				Vector3D vector3D2 = item.Item2.NormalAt(_0023_003DzqoHxF0k_003D.s, _0023_003DzqoHxF0k_003D.t);
				double num = Math.Abs(vector3D * vector3D2);
				if (num < 0.14 && num > 0.0001)
				{
					_0023_003DzCtRyVyaBWgbH(item.Item1, item.Item2, list, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003DzccAR5G0_003D);
				}
			}
		}
		return list.ToArray();
	}

	private static _0023_003DzWbIbatcG6O_00243 _0023_003DzrLRhLtofvSkH(ICurve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003Dz_0024KKopL9T7nzT, bool _0023_003Dzx3pYiE0_003D, bool _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D, TrimCurve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU, double _0023_003DzccAR5G0_003D, out Point3D[] _0023_003Dzh5zIRDeVqFGp, AnalyticSurf _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D)
	{
		_0023_003Dzh5zIRDeVqFGp = new Point3D[0];
		bool flag = Utility.IsLine(_0023_003Dz8fpRyMu9aKjE);
		bool flag2 = _0023_003Dz8fpRyMu9aKjE.GetType() == typeof(Circle);
		bool flag3 = _0023_003Dz8fpRyMu9aKjE.GetType() == typeof(Arc);
		bool num = _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D != null;
		bool flag4 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is TabulatedSurf { Directrix: Circle directrix } tabulatedSurf && Vector3D.AreParallel((Vector3D)tabulatedSurf.Generatrix.Clone() / tabulatedSurf.Generatrix.Length, directrix.Plane.AxisZ);
		bool flag5 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D.GetType() == typeof(CylindricalSurf);
		bool flag6 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is TabulatedSurf { Directrix: Ellipse { IsCircle: not false } directrix2 } tabulatedSurf2 && Vector3D.AreParallel((Vector3D)tabulatedSurf2.Generatrix.Clone() / tabulatedSurf2.Generatrix.Length, directrix2.Plane.AxisZ);
		bool flag7 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is RevolvedSurf revolvedSurf && Utility.IsLine(revolvedSurf.Generatrix) && Vector3D.AreParallel(revolvedSurf.Generatrix.StartTangent, revolvedSurf.Plane.AxisZ);
		bool flag8 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D.GetType() == typeof(ConicalSurf);
		bool flag9 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D.GetType() == typeof(SphericalSurf);
		bool flag10 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is RevolvedSurf { Generatrix: Arc { Domain: { Length: var length } } generatrix } revolvedSurf2 && Utility._0023_003Dz_Dm7r9Ftq7Ss(length, Math.PI, generatrix.Domain.Length) && generatrix.Center == revolvedSurf2.Plane.Origin;
		bool flag11 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is ToroidalSurf;
		bool flag12 = num && _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is RevolvedSurf { Generatrix: Arc generatrix2 } revolvedSurf3 && Math.Abs(revolvedSurf3.Plane.DistanceTo(generatrix2.Center)) < Utility._0023_003DzxhnLabVjXjPg * generatrix2.Radius && generatrix2.Center != revolvedSurf3.Plane.Origin;
		bool flag13 = false;
		bool flag14 = false;
		Transformation _0023_003DzNDQ_E88_003D = null;
		Plane plane = null;
		PlanarSurface _0023_003DzaR3A1ks_003D;
		if (_0023_003Dz_0024KKopL9T7nzT is PlanarSurface planarSurface)
		{
			flag13 = true;
			plane = planarSurface.Plane;
		}
		else if (_0023_003Dz_0024KKopL9T7nzT is TabulatedSurface tabulatedSurface && tabulatedSurface._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D, out _0023_003DzNDQ_E88_003D))
		{
			flag14 = true;
			plane = _0023_003DzaR3A1ks_003D.Plane;
		}
		bool num2 = flag && plane != null && Vector3D.AreOrthogonal(new Line(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint).Tangent, plane.AxisZ);
		bool flag15 = _0023_003Dz8fpRyMu9aKjE is PlanarEntity planarEntity && plane != null && Vector3D.AreParallel(plane.AxisZ, planarEntity.Plane.AxisZ);
		bool flag16 = plane != null && _0023_003Dz8fpRyMu9aKjE.IsInPlane(plane, _0023_003DzccAR5G0_003D * Utility._0023_003DzheSR8QM7q9ya);
		if (num2 || flag15 || flag16)
		{
			return (_0023_003DzWbIbatcG6O_00243)1;
		}
		if (flag && _0023_003Dz_0024KKopL9T7nzT is TabulatedSurface tabulatedSurface2)
		{
			Vector3D vector3D = (Vector3D)tabulatedSurface2.Generatrix.Clone();
			vector3D.Normalize();
			if (Vector3D.AreParallel(new Line(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint).Tangent, vector3D))
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
		}
		if (flag && flag4)
		{
			Circle circle = (Circle)((TabulatedSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D).Directrix;
			Vector3D vector3D2 = new Vector3D(circle.Plane.Origin, circle.StartPoint);
			vector3D2.Normalize();
			CylindricalSurf _0023_003DzrI2jLi0_003D = new CylindricalSurf(circle.Plane.Origin, circle.Plane.AxisZ, vector3D2, circle.Radius);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzadWUxF21cNZzsOHXfr9wPps_003D(_0023_003DzrI2jLi0_003D, (TabulatedSurface)_0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint), circle);
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag5)
		{
			CylindricalSurf _0023_003DzrI2jLi0_003D2 = (CylindricalSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzuddelKN5A4BzU6GMrQpbSag_003D(_0023_003DzrI2jLi0_003D2, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag6)
		{
			Ellipse ellipse = (Ellipse)((TabulatedSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D).Directrix;
			Circle circle2 = new Circle(ellipse.Plane, ellipse.Center, ellipse.RadiusX);
			Vector3D vector3D3 = new Vector3D(circle2.Plane.Origin, circle2.StartPoint);
			vector3D3.Normalize();
			CylindricalSurf _0023_003DzrI2jLi0_003D3 = new CylindricalSurf(circle2.Plane.Origin, circle2.Plane.AxisZ, vector3D3, circle2.Radius);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzadWUxF21cNZzsOHXfr9wPps_003D(_0023_003DzrI2jLi0_003D3, (TabulatedSurface)_0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint), circle2);
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag7)
		{
			RevolvedSurf revolvedSurf4 = (RevolvedSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			revolvedSurf4.Generatrix.ClosestPointTo(revolvedSurf4.Plane.Origin, out var t);
			double radius = Point3D.Distance(revolvedSurf4.Plane.Origin, revolvedSurf4.Generatrix.PointAt(t));
			CylindricalSurf _0023_003DzrI2jLi0_003D4 = new CylindricalSurf(revolvedSurf4.Plane.Origin, revolvedSurf4.Plane.AxisZ, revolvedSurf4.Plane.AxisX, radius);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzuddelKN5A4BzU6GMrQpbSag_003D(_0023_003DzrI2jLi0_003D4, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag8)
		{
			ConicalSurf _0023_003DzrI2jLi0_003D5 = (ConicalSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzRSS29Um2HaKP1afdQiM62lc_003D(_0023_003DzrI2jLi0_003D5, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag9)
		{
			SphericalSurf sphericalSurf = (SphericalSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			if (sphericalSurf.Plane.Origin.DistanceTo(new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint)) > sphericalSurf.Radius)
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzLrFUYa1xwg7B8Hud0JMFRUmousbE(sphericalSurf, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag10)
		{
			RevolvedSurf obj = (RevolvedSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			SphericalSurf sphericalSurf2 = new SphericalSurf(radius: ((Arc)obj.Generatrix).Radius, plane: obj.Plane);
			if (sphericalSurf2.Plane.Origin.DistanceTo(new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint)) > sphericalSurf2.Radius)
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzLrFUYa1xwg7B8Hud0JMFRUmousbE(sphericalSurf2, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag11)
		{
			ToroidalSurf toroidalSurf = (ToroidalSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			if (toroidalSurf.Plane.Origin.DistanceTo(new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint)) > toroidalSurf.MajorRadius + toroidalSurf.MinorRadius)
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
			Circle obj2 = (Circle)((ToroidalSurface)_0023_003Dz_0024KKopL9T7nzT).Generatrix.Clone();
			obj2.Rotate(0.0 - _0023_003Dz_0024KKopL9T7nzT.rotAngleU, toroidalSurf.Plane.AxisZ, toroidalSurf.Plane.Origin);
			bool _0023_003DztuMTeiU_003D = !Vector3D.AreCoincident(obj2.Plane.AxisZ, toroidalSurf.Plane.AxisY);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzSvK3OjfW1BD5VxWMgvUsFheXVMjE(toroidalSurf, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, _0023_003DztuMTeiU_003D, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag12)
		{
			RevolvedSurf revolvedSurf5 = (RevolvedSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D;
			Circle circle3 = (Circle)revolvedSurf5.Generatrix;
			double num3 = Math.Abs(revolvedSurf5.Plane.Origin.DistanceTo(circle3.Center));
			if (num3 < circle3.Radius && circle3.Domain.Length < Math.PI)
			{
				num3 *= -1.0;
			}
			if (revolvedSurf5.Plane.Origin.DistanceTo(new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint)) > num3 + circle3.Radius)
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
			ToroidalSurf toroidalSurf2 = new ToroidalSurf(revolvedSurf5.Plane, num3, circle3.Radius);
			bool _0023_003DztuMTeiU_003D2 = !Vector3D.AreCoincident(circle3.Plane.AxisZ, toroidalSurf2.Plane.AxisY);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzSvK3OjfW1BD5VxWMgvUsFheXVMjE(toroidalSurf2, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, _0023_003DztuMTeiU_003D2, new Segment3D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint));
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag2 && (flag13 || flag14))
		{
			Circle circle4 = (Circle)_0023_003Dz8fpRyMu9aKjE;
			_0023_003Dzh5zIRDeVqFGp = circle4.IntersectWithPlane(plane);
			Point3D[] array;
			if (flag14)
			{
				TabulatedSurface tabulatedSurface3 = (TabulatedSurface)_0023_003Dz_0024KKopL9T7nzT;
				array = _0023_003Dzh5zIRDeVqFGp;
				for (int i = 0; i < array.Length; i++)
				{
					InterPoint interPoint = (InterPoint)array[i];
					if (_0023_003DzNDQ_E88_003D != null)
					{
						interPoint.s /= _0023_003DzNDQ_E88_003D.ScaleFactorX;
						interPoint.t /= _0023_003DzNDQ_E88_003D.ScaleFactorY;
					}
					interPoint.s *= tabulatedSurface3.scaleU;
					interPoint.s += tabulatedSurface3.DomainU.Low;
					interPoint.t += tabulatedSurface3.DomainV.Low;
				}
			}
			Arc arc = new Arc(circle4.Plane, circle4.Center, circle4.Radius, circle4.Domain.Low, circle4.Domain.High);
			Curve nurbsForm = circle4.GetNurbsForm();
			array = _0023_003Dzh5zIRDeVqFGp;
			for (int i = 0; i < array.Length; i++)
			{
				InitialPoint initialPoint = (InitialPoint)array[i];
				arc.GetNurbsFormParameterFromRadian(initialPoint.u, out var nurbsParam);
				initialPoint.u = nurbsParam;
				Vector3D vector3D4 = nurbsForm.Evaluate(nurbsParam, 1)[1];
				initialPoint.curveTx = vector3D4.X;
				initialPoint.curveTy = vector3D4.Y;
				initialPoint.curveTz = vector3D4.Z;
				initialPoint._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
				if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
				{
					initialPoint.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
				}
				else if (_0023_003DzoHguvx0by0LU != null)
				{
					initialPoint.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
				}
			}
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag3 && (flag13 || flag14))
		{
			Arc arc2 = (Arc)_0023_003Dz8fpRyMu9aKjE;
			Point3D[] array2 = new Circle(arc2.Plane, arc2.Center, arc2.Radius).IntersectWithPlane(plane);
			Point3D[] array;
			if (flag14)
			{
				TabulatedSurface tabulatedSurface4 = (TabulatedSurface)_0023_003Dz_0024KKopL9T7nzT;
				array = array2;
				for (int i = 0; i < array.Length; i++)
				{
					InterPoint interPoint2 = (InterPoint)array[i];
					if (_0023_003DzNDQ_E88_003D != null)
					{
						interPoint2.s /= _0023_003DzNDQ_E88_003D.ScaleFactorX;
						interPoint2.t /= _0023_003DzNDQ_E88_003D.ScaleFactorY;
					}
					interPoint2.s *= tabulatedSurface4.scaleU;
					interPoint2.s += tabulatedSurface4.DomainU.Low;
					interPoint2.t += tabulatedSurface4.DomainV.Low;
				}
			}
			Curve nurbsForm2 = arc2.GetNurbsForm();
			List<Point3D> list = new List<Point3D>();
			array = array2;
			for (int i = 0; i < array.Length; i++)
			{
				InitialPoint initialPoint2 = (InitialPoint)array[i];
				if (Utility._0023_003Dz4DFkbZmBwKQn(initialPoint2.u, arc2.Domain, out var _0023_003DzMSkhoo0y_0024u))
				{
					initialPoint2.u = _0023_003DzMSkhoo0y_0024u;
					arc2.GetNurbsFormParameterFromRadian(initialPoint2.u, out var nurbsParam2);
					initialPoint2.u = nurbsParam2;
					Vector3D vector3D5 = nurbsForm2.Evaluate(nurbsParam2, 1)[1];
					initialPoint2.curveTx = vector3D5.X;
					initialPoint2.curveTy = vector3D5.Y;
					initialPoint2.curveTz = vector3D5.Z;
					initialPoint2._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
					if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
					{
						initialPoint2.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
					}
					else if (_0023_003DzoHguvx0by0LU != null)
					{
						initialPoint2.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
					}
					list.Add(initialPoint2);
				}
			}
			_0023_003Dzh5zIRDeVqFGp = list.ToArray();
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag13)
		{
			Line line = new Line(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint);
			PlanarSurface planarSurface2 = (PlanarSurface)_0023_003Dz_0024KKopL9T7nzT;
			double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D = _0023_003DzccAR5G0_003D * 1E-05;
			if (planarSurface2.Plane != null && !Vector3D.AreOrthogonal(line.Tangent, planarSurface2.Plane.AxisZ))
			{
				_0023_003DzpZJGtACpJL6Efs27uw_003D_003D(line, planarSurface2, null, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003Dzh5zIRDeVqFGp);
			}
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		if (flag && flag14)
		{
			Line line2 = new Line(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint);
			TabulatedSurface tabulatedSurface5 = (TabulatedSurface)_0023_003Dz_0024KKopL9T7nzT;
			tabulatedSurface5.TryGetPlanar(out var ps);
			double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D2 = _0023_003DzccAR5G0_003D * 1E-05;
			if (ps.Plane != null && !Vector3D.AreOrthogonal(line2.Tangent, ps.Plane.AxisZ))
			{
				_0023_003DzpZJGtACpJL6Efs27uw_003D_003D(line2, ps, tabulatedSurface5, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D2, out _0023_003Dzh5zIRDeVqFGp);
			}
			_0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(_0023_003Dz8fpRyMu9aKjE, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003Dzh5zIRDeVqFGp);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
			return (_0023_003DzWbIbatcG6O_00243)0;
		}
		return (_0023_003DzWbIbatcG6O_00243)2;
	}

	private static bool _0023_003DzQkzXPvBnkcEmto_0024dIHC_fQY_003D(Circle _0023_003Dzw6jQxH4k7cf_0024, PlanarSurface _0023_003Dz42Cx_4Czbilr, ref Point3D[] _0023_003DzNiprk_0024o_003D)
	{
		if (Vector3D.AreOrthogonal(_0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ, _0023_003Dz42Cx_4Czbilr.Plane.AxisZ) && Utility.Compare(_0023_003Dzw6jQxH4k7cf_0024.Radius, _0023_003Dzw6jQxH4k7cf_0024.Center.DistanceTo(_0023_003Dz42Cx_4Czbilr.Plane)) == 0)
		{
			_0023_003Dz42Cx_4Czbilr.Project(_0023_003Dzw6jQxH4k7cf_0024.Center, out var u, out var v);
			Point3D point3D = _0023_003Dz42Cx_4Czbilr.PointAt(u, v);
			_0023_003Dzw6jQxH4k7cf_0024.Project(point3D, out var t);
			if (_0023_003Dzw6jQxH4k7cf_0024.Domain.Includes(t, testOpenInterval: false) && _0023_003Dz42Cx_4Czbilr.DomainU.Includes(u, testOpenInterval: false) && _0023_003Dz42Cx_4Czbilr.DomainV.Includes(v, testOpenInterval: false))
			{
				_0023_003DzNiprk_0024o_003D = new Point3D[1]
				{
					new InitialPoint(point3D.X, point3D.Y, point3D.Z, t, 0.0, u, v)
				};
				return true;
			}
		}
		return false;
	}

	private static _0023_003DzWbIbatcG6O_00243 _0023_003DzpZJGtACpJL6Efs27uw_003D_003D(Line _0023_003DzQ9zpGF0_003D, PlanarSurface _0023_003Dz42Cx_4Czbilr, TabulatedSurface _0023_003DzQPs31LY_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out Point3D[] _0023_003DzNiprk_0024o_003D)
	{
		_0023_003DzNiprk_0024o_003D = new Point3D[0];
		Vector3D tangent = _0023_003DzQ9zpGF0_003D.Tangent;
		if (Vector3D.AreOrthogonal(tangent, _0023_003Dz42Cx_4Czbilr.Plane.AxisZ))
		{
			return (_0023_003DzWbIbatcG6O_00243)1;
		}
		if (new Segment3D(_0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint).IntersectWith(_0023_003Dz42Cx_4Czbilr.Plane, infinite: false, out var intPoint))
		{
			_0023_003DzQ9zpGF0_003D.Project(intPoint, out var t);
			if (_0023_003DzQ9zpGF0_003D.Domain._0023_003DzNoPt9TsyzDMJ(t))
			{
				_0023_003Dz42Cx_4Czbilr.Project(intPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, true, out double u, out double v);
				if (_0023_003Dz42Cx_4Czbilr.DomainU._0023_003DzNoPt9TsyzDMJ(u) && _0023_003Dz42Cx_4Czbilr.DomainV._0023_003DzNoPt9TsyzDMJ(v))
				{
					InitialPoint initialPoint = new InitialPoint(intPoint.X, intPoint.Y, intPoint.Z, t, 0.0, u, v);
					initialPoint.curveTx = tangent.X;
					initialPoint.curveTy = tangent.Y;
					initialPoint.curveTz = tangent.Z;
					Point3D[] array = new InitialPoint[1] { initialPoint };
					_0023_003DzNiprk_0024o_003D = array;
					if (_0023_003DzQPs31LY_003D != null)
					{
						initialPoint.s *= _0023_003DzQPs31LY_003D.scaleU;
						initialPoint.s += _0023_003DzQPs31LY_003D.DomainU.Low;
					}
					return (_0023_003DzWbIbatcG6O_00243)0;
				}
			}
		}
		return (_0023_003DzWbIbatcG6O_00243)1;
	}

	private static _0023_003DzWbIbatcG6O_00243 _0023_003DzwwkhANCqh1p7EKXzHA_003D_003D(Line _0023_003DzQ9zpGF0_003D, RevolvedSurface _0023_003DzQcLk4fU_003D, TabulatedSurface _0023_003DzQPs31LY_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out Point3D[] _0023_003DzNiprk_0024o_003D)
	{
		_0023_003DzNiprk_0024o_003D = new Point3D[0];
		Vector3D startTangent = _0023_003DzQ9zpGF0_003D.StartTangent;
		Segment3D segment3D = new Segment3D(_0023_003DzQcLk4fU_003D.Plane.Origin, _0023_003DzQcLk4fU_003D.Plane.Origin + _0023_003DzQcLk4fU_003D.Plane.AxisZ);
		if (Vector3D.AreOrthogonal(startTangent, _0023_003DzQcLk4fU_003D.Axis))
		{
			Plane plane = (Plane)_0023_003DzQcLk4fU_003D.Plane.Clone();
			double num;
			if (_0023_003DzQcLk4fU_003D is ToroidalSurface toroidalSurface)
			{
				num = _0023_003DzQ9zpGF0_003D.StartPoint.DistanceTo(segment3D);
				if (num < toroidalSurface.MajorRadius - toroidalSurface.MinorRadius || num > toroidalSurface.MajorRadius + toroidalSurface.MinorRadius)
				{
					return (_0023_003DzWbIbatcG6O_00243)1;
				}
			}
			else if (_0023_003DzQcLk4fU_003D is SphericalSurface sphericalSurface)
			{
				num = _0023_003DzQ9zpGF0_003D.StartPoint.DistanceTo(segment3D);
				if (num > sphericalSurface.Radius)
				{
					return (_0023_003DzWbIbatcG6O_00243)1;
				}
			}
			else if (_0023_003DzQcLk4fU_003D is ConicalSurface { HalfAngle: var halfAngle } conicalSurface)
			{
				if (!(Math.Abs(halfAngle) < 1.5707963267938965) && !(Math.Abs(halfAngle) > 1.5707963267958966))
				{
					return (_0023_003DzWbIbatcG6O_00243)2;
				}
				double num2 = (0.0 - conicalSurface.Radius) / Math.Tan(halfAngle);
				double num3 = segment3D.Project(_0023_003DzQ9zpGF0_003D.StartPoint);
				_0023_003DzEGKj_0024SNUUihi = Math.Abs((num2 - num3) * Math.Tan(halfAngle));
				if (_0023_003DzEGKj_0024SNUUihi < 1E-12)
				{
					return (_0023_003DzWbIbatcG6O_00243)2;
				}
				num = plane.DistanceTo(_0023_003DzQ9zpGF0_003D.StartPoint);
			}
			else
			{
				num = plane.DistanceTo(_0023_003DzQ9zpGF0_003D.StartPoint);
			}
			plane.Translate(plane.AxisZ * num);
			Arc arc = new Arc(plane, Point2D.Origin, _0023_003DzEGKj_0024SNUUihi, 0.0, Math.PI * 2.0);
			if (Utility.IntersectionLineCircle(_0023_003DzQ9zpGF0_003D, arc, plane, infiniteLine: false, out var i, out var i2))
			{
				List<Point3D> list = new List<Point3D>();
				double t;
				double u;
				double v;
				if (i != null)
				{
					_0023_003DzQ9zpGF0_003D.Project(i, out t);
					if (_0023_003DzQ9zpGF0_003D.Domain._0023_003DzNoPt9TsyzDMJ(t))
					{
						_0023_003DzQcLk4fU_003D.Project(i, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, true, out u, out v);
						if (_0023_003DzQcLk4fU_003D.PointAt(u, v).DistanceTo(i) < _0023_003DzEGKj_0024SNUUihi && _0023_003DzQcLk4fU_003D.DomainU._0023_003DzNoPt9TsyzDMJ(u) && _0023_003DzQcLk4fU_003D.DomainV._0023_003DzNoPt9TsyzDMJ(v))
						{
							InitialPoint initialPoint = new InitialPoint(i.X, i.Y, i.Z, t, 0.0, u, v)
							{
								curveTx = startTangent.X,
								curveTy = startTangent.Y,
								curveTz = startTangent.Z
							};
							if (_0023_003DzQcLk4fU_003D.IsClosedU)
							{
								if (Utility.Compare(initialPoint.s, _0023_003DzQcLk4fU_003D.DomainU.Low) == 0)
								{
									InitialPoint initialPoint2 = (InitialPoint)initialPoint.Clone();
									initialPoint2.s = _0023_003DzQcLk4fU_003D.DomainU.High;
									list.Add(initialPoint2);
								}
								else if (Utility.Compare(initialPoint.s, _0023_003DzQcLk4fU_003D.DomainU.High) == 0)
								{
									InitialPoint initialPoint3 = (InitialPoint)initialPoint.Clone();
									initialPoint3.s = _0023_003DzQcLk4fU_003D.DomainU.Low;
									list.Add(initialPoint3);
								}
							}
							list.Add(initialPoint);
						}
					}
				}
				if (i2 != null)
				{
					_0023_003DzQ9zpGF0_003D.Project(i2, out t);
					if (_0023_003DzQ9zpGF0_003D.Domain._0023_003DzNoPt9TsyzDMJ(t))
					{
						_0023_003DzQcLk4fU_003D.Project(i2, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, true, out u, out v);
						if (_0023_003DzQcLk4fU_003D.PointAt(u, v).DistanceTo(i2) < _0023_003DzEGKj_0024SNUUihi && _0023_003DzQcLk4fU_003D.DomainU._0023_003DzNoPt9TsyzDMJ(u) && _0023_003DzQcLk4fU_003D.DomainV._0023_003DzNoPt9TsyzDMJ(v))
						{
							InitialPoint initialPoint4 = new InitialPoint(i2.X, i2.Y, i2.Z, t, 0.0, u, v)
							{
								curveTx = startTangent.X,
								curveTy = startTangent.Y,
								curveTz = startTangent.Z
							};
							if (_0023_003DzQcLk4fU_003D.IsClosedU)
							{
								if (Utility.Compare(initialPoint4.s, _0023_003DzQcLk4fU_003D.DomainU.Low) == 0)
								{
									InitialPoint initialPoint5 = (InitialPoint)initialPoint4.Clone();
									initialPoint5.s = _0023_003DzQcLk4fU_003D.DomainU.High;
									list.Add(initialPoint5);
								}
								else if (Utility.Compare(initialPoint4.s, _0023_003DzQcLk4fU_003D.DomainU.High) == 0)
								{
									InitialPoint initialPoint6 = (InitialPoint)initialPoint4.Clone();
									initialPoint6.s = _0023_003DzQcLk4fU_003D.DomainU.Low;
									list.Add(initialPoint6);
								}
							}
							list.Add(initialPoint4);
						}
					}
				}
				if (_0023_003DzQPs31LY_003D != null)
				{
					Curve nurbsForm = arc.GetNurbsForm();
					foreach (InterPoint item in list)
					{
						arc.GetNurbsFormParameterFromRadian(item.s, out item.s, nurbsForm);
						item.s *= _0023_003DzQPs31LY_003D.scaleU;
						item.s += _0023_003DzQPs31LY_003D.DomainU.Low;
					}
				}
				_0023_003DzNiprk_0024o_003D = list.ToArray();
				if (_0023_003DzNiprk_0024o_003D.Length == 0)
				{
					return (_0023_003DzWbIbatcG6O_00243)1;
				}
				return (_0023_003DzWbIbatcG6O_00243)0;
			}
		}
		else if (Vector3D.AreParallel(startTangent, _0023_003DzQcLk4fU_003D.Axis))
		{
			if (_0023_003DzQcLk4fU_003D is ToroidalSurface toroidalSurface2)
			{
				double num4 = _0023_003DzQ9zpGF0_003D.StartPoint.DistanceTo(segment3D);
				if (num4 < toroidalSurface2.MajorRadius - toroidalSurface2.MinorRadius || num4 > toroidalSurface2.MajorRadius + toroidalSurface2.MinorRadius)
				{
					return (_0023_003DzWbIbatcG6O_00243)1;
				}
			}
			else if (_0023_003DzQcLk4fU_003D.GetType() == typeof(CylindricalSurface))
			{
				return (_0023_003DzWbIbatcG6O_00243)1;
			}
		}
		return (_0023_003DzWbIbatcG6O_00243)2;
	}

	private static void _0023_003DzCtRyVyaBWgbH(Curve _0023_003DzzmfUkNI_003D, Surface _0023_003DzKBncRpw_003D, List<Point3D> _0023_003DzrdSL0CI_003D, Curve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU, double _0023_003DzccAR5G0_003D)
	{
		if (_0023_003DzUhQEKrRzaznj(_0023_003DzzmfUkNI_003D, _0023_003DzKBncRpw_003D, _0023_003DzzmfUkNI_003D.Domain.Low, _0023_003DzKBncRpw_003D.DomainU.Low, _0023_003DzKBncRpw_003D.DomainV.Low, _0023_003DzccAR5G0_003D, out var _0023_003DzqoHxF0k_003D))
		{
			_0023_003DzqoHxF0k_003D._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
			if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
			}
			else if (_0023_003DzoHguvx0by0LU != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
			}
			if ((_0023_003DzqoHxF0k_003D.u > _0023_003DzzmfUkNI_003D.Domain.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003DzzmfUkNI_003D.Domain.Low, _0023_003DzzmfUkNI_003D.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.u <= _0023_003DzzmfUkNI_003D.Domain.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003DzzmfUkNI_003D.Domain.High, _0023_003DzzmfUkNI_003D.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s >= _0023_003DzKBncRpw_003D.DomainU.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzKBncRpw_003D.DomainU.Low, _0023_003DzKBncRpw_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s <= _0023_003DzKBncRpw_003D.DomainU.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzKBncRpw_003D.DomainU.High, _0023_003DzKBncRpw_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t >= _0023_003DzKBncRpw_003D.DomainV.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzKBncRpw_003D.DomainV.Low, _0023_003DzKBncRpw_003D.DomainV.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t <= _0023_003DzKBncRpw_003D.DomainV.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzKBncRpw_003D.DomainV.High, _0023_003DzKBncRpw_003D.DomainV.Length * 10.0)))
			{
				Utility._0023_003DzbIDY9BOTPqfc(_0023_003DzqoHxF0k_003D, _0023_003DzrdSL0CI_003D, _0023_003DzccAR5G0_003D);
			}
		}
		if (_0023_003DzUhQEKrRzaznj(_0023_003DzzmfUkNI_003D, _0023_003DzKBncRpw_003D, _0023_003DzzmfUkNI_003D.Domain.High, _0023_003DzKBncRpw_003D.DomainU.High, _0023_003DzKBncRpw_003D.DomainV.High, _0023_003DzccAR5G0_003D, out _0023_003DzqoHxF0k_003D))
		{
			_0023_003DzqoHxF0k_003D._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
			if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
			}
			else if (_0023_003DzoHguvx0by0LU != null)
			{
				_0023_003DzqoHxF0k_003D.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
			}
			if ((_0023_003DzqoHxF0k_003D.u > _0023_003DzzmfUkNI_003D.Domain.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003DzzmfUkNI_003D.Domain.Low, _0023_003DzzmfUkNI_003D.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.u <= _0023_003DzzmfUkNI_003D.Domain.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.u, _0023_003DzzmfUkNI_003D.Domain.High, _0023_003DzzmfUkNI_003D.Domain.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s >= _0023_003DzKBncRpw_003D.DomainU.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzKBncRpw_003D.DomainU.Low, _0023_003DzKBncRpw_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.s <= _0023_003DzKBncRpw_003D.DomainU.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.s, _0023_003DzKBncRpw_003D.DomainU.High, _0023_003DzKBncRpw_003D.DomainU.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t >= _0023_003DzKBncRpw_003D.DomainV.Low || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzKBncRpw_003D.DomainV.Low, _0023_003DzKBncRpw_003D.DomainV.Length * 10.0)) && (_0023_003DzqoHxF0k_003D.t <= _0023_003DzKBncRpw_003D.DomainV.High || Utility.AreEqual(_0023_003DzqoHxF0k_003D.t, _0023_003DzKBncRpw_003D.DomainV.High, _0023_003DzKBncRpw_003D.DomainV.Length * 10.0)))
			{
				Utility._0023_003DzbIDY9BOTPqfc(_0023_003DzqoHxF0k_003D, _0023_003DzrdSL0CI_003D, _0023_003DzccAR5G0_003D);
			}
		}
	}

	private static bool _0023_003Dz5p7_0024ZhlZ7wNcqcc8Vw_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, Surface _0023_003DzF7GfYSI_003D, double _0023_003DzccAR5G0_003D, out List<Tuple<Curve, Surface>> _0023_003DzovIe_fE_003D)
	{
		LinkedList<Marker<Curve>> linkedList = new LinkedList<Marker<Curve>>();
		foreach (Curve item in _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(_0023_003Dz8fpRyMu9aKjE))
		{
			linkedList.AddLast(item);
		}
		if (_0023_003DzF7GfYSI_003D.shrunk == null)
		{
			_0023_003DzF7GfYSI_003D._0023_003DzIQv8kUn9rJJPHOmQIg_003D_003D();
		}
		List<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D> list = _0023_003DzqGVCgrBynBx__0zpNyyIoDq1UDfHNc80x4V1z5BRniPJF0BHLg_003D_003D._0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(_0023_003DzF7GfYSI_003D.shrunk);
		LinkedList<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>> linkedList2 = new LinkedList<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>>();
		foreach (_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D item2 in list)
		{
			linkedList2.AddLast(item2);
		}
		_0023_003DzovIe_fE_003D = null;
		Point3D min;
		Point3D max;
		Point3D min2;
		Point3D max2;
		bool flag;
		bool flag2;
		do
		{
			foreach (Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D> item3 in linkedList2)
			{
				item3.Item.ControlBoundingBox(out min, out max);
				foreach (Marker<Curve> item4 in linkedList)
				{
					item4.Item.ControlBoundingBox(out min2, out max2);
					if (Utility.DoOverlapOrTouch(min, max, min2, max2, _0023_003DzccAR5G0_003D))
					{
						item3.Mark = true;
						item4.Mark = true;
					}
				}
			}
			flag = false;
			LinkedList<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>> linkedList3 = new LinkedList<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>>();
			LinkedListNode<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>> linkedListNode = linkedList2.First;
			do
			{
				Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D> value = linkedListNode.Value;
				if (value.Mark)
				{
					if (value.Item._0023_003Dz8WVqzxw7BhZD19zKSk8S2jg_003D(0.0, Utility._0023_003DzJ2MUkYo_2suxunAM1w_003D_003D, out var _0023_003DzpNUGTDJpdp7L, out var _0023_003DzSeQxWSWveqlL))
					{
						linkedList3.AddLast(_0023_003DzpNUGTDJpdp7L);
						linkedList3.AddLast(_0023_003DzSeQxWSWveqlL);
						flag = true;
					}
					else
					{
						linkedList3.AddLast(value);
					}
					linkedListNode = linkedListNode.Next;
				}
				else
				{
					LinkedListNode<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>> next = linkedListNode.Next;
					linkedList2.Remove(linkedListNode);
					linkedListNode = next;
				}
			}
			while (linkedListNode != null);
			if (flag)
			{
				linkedList2 = new LinkedList<Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>>(linkedList3);
			}
			flag2 = false;
			LinkedList<Marker<Curve>> linkedList4 = new LinkedList<Marker<Curve>>();
			LinkedListNode<Marker<Curve>> linkedListNode2 = linkedList.First;
			if (linkedList.Count == 0)
			{
				return false;
			}
			do
			{
				Curve curve = linkedListNode2.Value;
				if (linkedListNode2.Value.Mark)
				{
					if (_0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov._0023_003DznQ_0024Lpt8_0024jA_TU82zSQ_003D_003D(curve.ControlPoints, 0.0, Utility._0023_003DzJ2MUkYo_2suxunAM1w_003D_003D))
					{
						linkedList4.AddLast(curve);
					}
					else
					{
						_0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003Dz87PsHa5sRJbE(curve, out var _0023_003Dzj9kq7RRev6fS, out var _0023_003DzWQkHZg1gwsuM);
						linkedList4.AddLast(_0023_003Dzj9kq7RRev6fS);
						linkedList4.AddLast(_0023_003DzWQkHZg1gwsuM);
						flag2 = true;
					}
					linkedListNode2 = linkedListNode2.Next;
				}
				else
				{
					LinkedListNode<Marker<Curve>> next2 = linkedListNode2.Next;
					linkedList.Remove(linkedListNode2);
					linkedListNode2 = next2;
				}
			}
			while (linkedListNode2 != null);
			if (flag2)
			{
				linkedList = new LinkedList<Marker<Curve>>(linkedList4);
			}
		}
		while (flag2 || flag);
		_0023_003DzovIe_fE_003D = new List<Tuple<Curve, Surface>>();
		foreach (Marker<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D> item5 in linkedList2)
		{
			_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D2 = item5;
			_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D2.ControlBoundingBox(out min, out max);
			foreach (Marker<Curve> item6 in linkedList)
			{
				item6.Item.ControlBoundingBox(out min2, out max2);
				if (Utility.DoOverlapOrTouch(min, max, min2, max2, _0023_003DzccAR5G0_003D))
				{
					_0023_003DzovIe_fE_003D.Add(new Tuple<Curve, Surface>(item6, _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D2));
				}
			}
		}
		return true;
	}

	private static bool _0023_003DzUhQEKrRzaznj(Curve _0023_003DzzmfUkNI_003D, Surface _0023_003DzKBncRpw_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzccAR5G0_003D, out InitialPoint _0023_003DzqoHxF0k_003D)
	{
		double num = _0023_003Dz_eY3Y4c_003D;
		double num2 = _0023_003DzuwH5j5s_003D;
		double num3 = _0023_003DzNDQ_E88_003D;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		bool isClosed = _0023_003DzzmfUkNI_003D.IsClosed;
		double low = _0023_003DzzmfUkNI_003D.Domain.Low;
		double high = _0023_003DzzmfUkNI_003D.Domain.High;
		bool isClosedU = _0023_003DzKBncRpw_003D.IsClosedU;
		double low2 = _0023_003DzKBncRpw_003D.DomainU.Low;
		double high2 = _0023_003DzKBncRpw_003D.DomainU.High;
		bool isClosedV = _0023_003DzKBncRpw_003D.IsClosedV;
		double low3 = _0023_003DzKBncRpw_003D.DomainV.Low;
		double high3 = _0023_003DzKBncRpw_003D.DomainV.High;
		_0023_003DzqoHxF0k_003D = new InitialPoint(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		int i = 0;
		double num7 = double.MaxValue;
		double coincTol = 1E-10;
		for (; i < 32; i++)
		{
			Vector3D[] array = _0023_003DzzmfUkNI_003D.Evaluate(_0023_003Dz_eY3Y4c_003D, 1);
			Vector3D[,] array2 = _0023_003DzKBncRpw_003D.Evaluate(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, 1);
			Vector3D q = array[0];
			Vector3D vector3D = array[1];
			Vector3D vector3D2 = array2[0, 0];
			Vector3D vector3D3 = array2[1, 0];
			Vector3D vector3D4 = array2[0, 1];
			Vector3D vector3D5 = Vector3D.Cross(vector3D3, vector3D4);
			Vector3D vector3D6 = (Vector3D)vector3D.Clone();
			Vector3D vector3D7 = (Vector3D)vector3D5.Clone();
			bool flag = false;
			if (vector3D6.IsValid() && vector3D7.IsValid() && vector3D6.Normalize() && vector3D7.Normalize())
			{
				flag = Vector3D.AreOrthogonal(vector3D6, vector3D7, 0.0001);
			}
			Vector3D r;
			double rLen;
			bool num8 = Utility.PointCoincidence(vector3D2, q, _0023_003DzccAR5G0_003D, out r, out rLen, coincTol);
			bool flag2 = rLen < num7;
			if (num8)
			{
				if (flag && _0023_003DzscA8U9UU7P2p(_0023_003DzzmfUkNI_003D, _0023_003DzKBncRpw_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003DzccAR5G0_003D, out var _0023_003DzqoHxF0k_003D2))
				{
					_0023_003DzqoHxF0k_003D = _0023_003DzqoHxF0k_003D2;
					return true;
				}
				_0023_003DzqoHxF0k_003D = new InitialPoint(vector3D2.X, vector3D2.Y, vector3D2.Z, _0023_003Dz_eY3Y4c_003D, 0.0, _0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D);
				_0023_003DzqoHxF0k_003D.curveTx = vector3D.X;
				_0023_003DzqoHxF0k_003D.curveTy = vector3D.Y;
				_0023_003DzqoHxF0k_003D.curveTz = vector3D.Z;
				return true;
			}
			double num9 = vector3D * vector3D5;
			double num10 = _0023_003Dz_eY3Y4c_003D;
			double num11 = _0023_003DzuwH5j5s_003D;
			double num12 = _0023_003DzNDQ_E88_003D;
			if (Math.Abs(num9) < 1E-12)
			{
				Vector3D[] array3 = new Vector3D[2] { vector3D, vector3D3 };
				bool flag3 = true;
				if (vector3D3.LengthSquared < 1E-12)
				{
					flag3 = false;
					array3[1] = vector3D4;
				}
				double num13 = array3[0] * array3[0];
				double num14 = array3[0] * array3[1];
				double num15 = array3[1] * array3[1];
				num9 = num13 * num15 - num14 * num14;
				num10 += r * (num14 * array3[1] - num15 * array3[0]) / num9;
				if (flag3)
				{
					num11 += r * (num14 * array3[0] - num13 * array3[1]) / num9;
				}
				else
				{
					num12 += r * (num14 * array3[0] - num13 * array3[1]) / num9;
				}
			}
			else
			{
				num10 -= vector3D3 * Vector3D.Cross(vector3D4, r) / num9;
				num11 += vector3D4 * Vector3D.Cross(vector3D, r) / num9;
				num12 += vector3D * Vector3D.Cross(vector3D3, r) / num9;
			}
			double length = ((num10 - _0023_003Dz_eY3Y4c_003D) * vector3D).Length;
			double length2 = ((num11 - _0023_003DzuwH5j5s_003D) * vector3D3 + (num12 - _0023_003DzNDQ_E88_003D) * vector3D4).Length;
			bool num16 = Utility.ParametersDontChangeSignificantly(length, _0023_003DzccAR5G0_003D);
			bool flag4 = Utility.ParametersDontChangeSignificantly(length2, _0023_003DzccAR5G0_003D);
			if (num16 && flag4)
			{
				return false;
			}
			if (isClosed)
			{
				if (num10 < low)
				{
					num10 = high - (low - num10);
				}
				else if (num10 > high)
				{
					num10 = low + (num10 - high);
				}
			}
			else if (num10 < low)
			{
				num10 = low;
			}
			else if (num10 > high)
			{
				num10 = high;
			}
			if (i > 2 && num10 == num && (num10 == low || num10 == high) && !flag2)
			{
				num10 = _0023_003DzzmfUkNI_003D.Domain.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num4]);
				num4++;
			}
			num = _0023_003Dz_eY3Y4c_003D;
			_0023_003Dz_eY3Y4c_003D = num10;
			if (isClosedU)
			{
				if (num11 < low2)
				{
					num11 = high2 - (low2 - num11);
				}
				else if (num11 > high2)
				{
					num11 = low2 + (num11 - high2);
				}
			}
			else if (num11 < low2)
			{
				num11 = low2;
			}
			else if (num11 > high2)
			{
				num11 = high2;
			}
			if (isClosedV)
			{
				if (num12 < low3)
				{
					num12 = high3 - (low3 - num12);
				}
				else if (num12 > high3)
				{
					num12 = low3 + (num12 - high3);
				}
			}
			else if (num12 < low3)
			{
				num12 = low3;
			}
			else if (num12 > high3)
			{
				num12 = high3;
			}
			if (i > 2 && num11 == num2 && num12 == num3 && !flag2)
			{
				if (num11 == low2 || num11 == high2)
				{
					num11 = _0023_003DzKBncRpw_003D.DomainU.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num5]);
					num5++;
				}
				if (num12 == low3 || num12 == high3)
				{
					num12 = _0023_003DzKBncRpw_003D.DomainV.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num6]);
					num6++;
				}
			}
			num2 = _0023_003DzuwH5j5s_003D;
			_0023_003DzuwH5j5s_003D = num11;
			num3 = _0023_003DzNDQ_E88_003D;
			_0023_003DzNDQ_E88_003D = num12;
			num7 = rLen;
		}
		return false;
	}

	private static bool _0023_003DzscA8U9UU7P2p(Curve _0023_003DzzmfUkNI_003D, Surface _0023_003DzKBncRpw_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzccAR5G0_003D, out InitialPoint _0023_003DzqoHxF0k_003D)
	{
		double num = _0023_003Dz_eY3Y4c_003D;
		double num2 = _0023_003DzuwH5j5s_003D;
		double num3 = _0023_003DzNDQ_E88_003D;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		bool isClosed = _0023_003DzzmfUkNI_003D.IsClosed;
		double low = _0023_003DzzmfUkNI_003D.Domain.Low;
		double high = _0023_003DzzmfUkNI_003D.Domain.High;
		bool isClosedU = _0023_003DzKBncRpw_003D.IsClosedU;
		double low2 = _0023_003DzKBncRpw_003D.DomainU.Low;
		double high2 = _0023_003DzKBncRpw_003D.DomainU.High;
		bool isClosedV = _0023_003DzKBncRpw_003D.IsClosedV;
		double low3 = _0023_003DzKBncRpw_003D.DomainV.Low;
		double high3 = _0023_003DzKBncRpw_003D.DomainV.High;
		_0023_003DzqoHxF0k_003D = new InitialPoint(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		int i = 0;
		double num7 = double.MaxValue;
		double num8 = double.MaxValue;
		double num9 = 0.01;
		for (; i < 32; i++)
		{
			Vector3D[] array = _0023_003DzzmfUkNI_003D.Evaluate(_0023_003Dz_eY3Y4c_003D, 2);
			Vector3D[,] array2 = _0023_003DzKBncRpw_003D.Evaluate(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, 2);
			Vector3D vector3D = array[0];
			Vector3D vector3D2 = array[1];
			Vector3D vector3D3 = array[2];
			Vector3D vector3D4 = array2[0, 0];
			Vector3D vector3D5 = array2[1, 0];
			Vector3D vector3D6 = array2[0, 1];
			Vector3D a = array2[2, 0];
			Vector3D vector3D7 = array2[1, 1];
			Vector3D b = array2[0, 2];
			Vector3D vector3D8 = Vector3D.Cross(vector3D5, vector3D6);
			double length = vector3D8.Length;
			Vector3D vector3D9 = (Vector3D)vector3D2.Clone();
			Vector3D vector3D10 = (Vector3D)vector3D8.Clone();
			if (!vector3D9.IsValid() && !vector3D10.IsValid() && !vector3D9.Normalize() && !vector3D10.Normalize())
			{
				return false;
			}
			if (vector3D9.Length != 1.0)
			{
				vector3D9.Normalize();
			}
			if (vector3D10.Length != 1.0)
			{
				vector3D10.Normalize();
			}
			Vector3D r;
			double rLen;
			bool num10 = Utility.PointCoincidence(vector3D4, vector3D, _0023_003DzccAR5G0_003D, out r, out rLen, 1E-12) && Vector3D.AreOrthogonal(vector3D9, vector3D10, 1E-12);
			bool flag = rLen < num7;
			if (num10)
			{
				_0023_003DzqoHxF0k_003D = new InitialPoint(vector3D4.X, vector3D4.Y, vector3D4.Z, _0023_003Dz_eY3Y4c_003D, 0.0, _0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D);
				_0023_003DzqoHxF0k_003D.curveTx = vector3D2.X;
				_0023_003DzqoHxF0k_003D.curveTy = vector3D2.Y;
				_0023_003DzqoHxF0k_003D.curveTz = vector3D2.Z;
				return true;
			}
			double[,] array3 = new double[4, 3];
			double[] array4 = new double[4];
			array3[0, 0] = vector3D2.X;
			array3[0, 1] = 0.0 - vector3D5.X;
			array3[0, 2] = 0.0 - vector3D6.X;
			array3[1, 0] = vector3D2.Y;
			array3[1, 1] = 0.0 - vector3D5.Y;
			array3[1, 2] = 0.0 - vector3D6.Y;
			array3[2, 0] = vector3D2.Z;
			array3[2, 1] = 0.0 - vector3D5.Z;
			array3[2, 2] = 0.0 - vector3D6.Z;
			array4[0] = vector3D.X - vector3D4.X;
			array4[1] = vector3D.Y - vector3D4.Y;
			array4[2] = vector3D.Z - vector3D4.Z;
			double length2 = vector3D2.Length;
			double num11 = Vector3D.Dot(vector3D2, vector3D3);
			Vector3D u = (vector3D3 * length2 * length2 - vector3D2 * num11) / (length2 * length2 * length2);
			Vector3D v = (Vector3D.Cross(a, vector3D6) + Vector3D.Cross(vector3D5, vector3D7)) / length - Vector3D.Cross(vector3D5, vector3D6) * (Vector3D.Cross(a, vector3D6) + Vector3D.Cross(vector3D5, vector3D7)) * Vector3D.Cross(vector3D5, vector3D6) / (length * length * length);
			Vector3D v2 = (Vector3D.Cross(vector3D7, vector3D6) + Vector3D.Cross(vector3D5, b)) / length - Vector3D.Cross(vector3D5, vector3D6) * (Vector3D.Cross(vector3D7, vector3D6) + Vector3D.Cross(vector3D5, b)) * Vector3D.Cross(vector3D5, vector3D6) / (length * length * length);
			double num12 = Vector3D.Dot(u, vector3D10);
			double num13 = Vector3D.Dot(vector3D9, v);
			double num14 = Vector3D.Dot(vector3D9, v2);
			array3[3, 0] = num12;
			array3[3, 1] = num13;
			array3[3, 2] = num14;
			array4[3] = Vector3D.Dot(vector3D9, vector3D10);
			double[] _0023_003Dzyk2fsPo_003D = new double[3] { _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D };
			double num15 = 0.0;
			for (int j = 0; j < array4.Length; j++)
			{
				num15 += array4[j] * array4[j];
			}
			num9 = ((!(num8 > num15)) ? (num9 * 10.0) : (num9 / 10.0));
			num8 = num15;
			_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D._0023_003DzBLRPGmwPXW4LTycuqQ_003D_003D(array3, array4, ref _0023_003Dzyk2fsPo_003D, num9);
			double num16 = _0023_003Dz_eY3Y4c_003D - _0023_003Dzyk2fsPo_003D[0];
			double num17 = _0023_003DzuwH5j5s_003D - _0023_003Dzyk2fsPo_003D[1];
			double num18 = _0023_003DzNDQ_E88_003D - _0023_003Dzyk2fsPo_003D[2];
			double length3 = ((num16 - _0023_003Dz_eY3Y4c_003D) * vector3D2).Length;
			double length4 = ((num17 - _0023_003DzuwH5j5s_003D) * vector3D5 + (num18 - _0023_003DzNDQ_E88_003D) * vector3D6).Length;
			bool num19 = Utility.ParametersDontChangeSignificantly(length3, _0023_003DzccAR5G0_003D);
			bool flag2 = Utility.ParametersDontChangeSignificantly(length4, _0023_003DzccAR5G0_003D);
			if (num19 && flag2)
			{
				return false;
			}
			if (isClosed)
			{
				if (num16 < low)
				{
					num16 = high - (low - num16);
				}
				else if (num16 > high)
				{
					num16 = low + (num16 - high);
				}
			}
			else if (num16 < low)
			{
				num16 = low;
			}
			else if (num16 > high)
			{
				num16 = high;
			}
			if (i > 2 && num16 == num && (num16 == low || num16 == high) && !flag)
			{
				num16 = _0023_003DzzmfUkNI_003D.Domain.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num4]);
				num4++;
			}
			num = _0023_003Dz_eY3Y4c_003D;
			_0023_003Dz_eY3Y4c_003D = num16;
			if (isClosedU)
			{
				if (num17 < low2)
				{
					num17 = high2 - (low2 - num17);
				}
				else if (num17 > high2)
				{
					num17 = low2 + (num17 - high2);
				}
			}
			else if (num17 < low2)
			{
				num17 = low2;
			}
			else if (num17 > high2)
			{
				num17 = high2;
			}
			if (isClosedV)
			{
				if (num18 < low3)
				{
					num18 = high3 - (low3 - num18);
				}
				else if (num18 > high3)
				{
					num18 = low3 + (num18 - high3);
				}
			}
			else if (num18 < low3)
			{
				num18 = low3;
			}
			else if (num18 > high3)
			{
				num18 = high3;
			}
			if (i > 2 && num17 == num2 && num18 == num3 && !flag)
			{
				if (num17 == low2 || num17 == high2)
				{
					num17 = _0023_003DzKBncRpw_003D.DomainU.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num5]);
					num5++;
				}
				if (num18 == low3 || num18 == high3)
				{
					num18 = _0023_003DzKBncRpw_003D.DomainV.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[num6]);
					num6++;
				}
			}
			num2 = _0023_003DzuwH5j5s_003D;
			_0023_003DzuwH5j5s_003D = num17;
			num3 = _0023_003DzNDQ_E88_003D;
			_0023_003DzNDQ_E88_003D = num18;
			num7 = rLen;
		}
		return false;
	}

	internal static Point3D[] _0023_003DzuddelKN5A4BzU6GMrQpbSag_003D(CylindricalSurf _0023_003DzrI2jLi0_003D, Surface _0023_003Dz4wZe_0024Xg_003D, bool _0023_003Dzx3pYiE0_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		Point3D[] array = _0023_003DzrI2jLi0_003D.IntersectWith(_0023_003DzSwfghCo_003D);
		if (array.Length != 0)
		{
			_0023_003Dz4wZe_0024Xg_003D.Project(_0023_003DzrI2jLi0_003D.Plane.Origin, double.MaxValue, true, out double _, out double v);
			double rotAngleU = _0023_003Dz4wZe_0024Xg_003D.rotAngleU;
			bool flag = Vector3D.AreOpposite(_0023_003DzrI2jLi0_003D.Plane.AxisZ, ((CylindricalSurface)_0023_003Dz4wZe_0024Xg_003D).Generatrix.StartTangent);
			Point3D[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				InterPoint interPoint = (InterPoint)array2[i];
				double num = interPoint.s - rotAngleU;
				if (!_0023_003Dzx3pYiE0_003D)
				{
					num *= -1.0;
				}
				if (num < 0.0)
				{
					num += Math.PI * 2.0;
				}
				interPoint.s = num;
				interPoint.t += v;
				if (flag)
				{
					interPoint.t *= -1.0;
				}
			}
		}
		return array;
	}

	internal static Point3D[] _0023_003DzadWUxF21cNZzsOHXfr9wPps_003D(CylindricalSurf _0023_003DzrI2jLi0_003D, TabulatedSurface _0023_003Dz4wZe_0024Xg_003D, bool _0023_003Dzx3pYiE0_003D, Segment3D _0023_003DzSwfghCo_003D, Circle _0023_003DzlUzbkfsR992FgQZZzw_003D_003D)
	{
		Point3D[] array = _0023_003DzrI2jLi0_003D.IntersectWith(_0023_003DzSwfghCo_003D);
		List<Point3D> list = new List<Point3D>();
		if (array.Length != 0)
		{
			_0023_003Dz4wZe_0024Xg_003D.Project(_0023_003DzrI2jLi0_003D.Plane.Origin, double.MaxValue, true, out double _, out double v);
			Vector3D obj = (Vector3D)_0023_003Dz4wZe_0024Xg_003D.Generatrix.Clone();
			obj.Normalize();
			bool flag = Vector3D.AreOpposite(obj, _0023_003DzrI2jLi0_003D.Plane.AxisZ);
			Circle circle = (Circle)_0023_003DzlUzbkfsR992FgQZZzw_003D_003D.Clone();
			if (!_0023_003Dzx3pYiE0_003D)
			{
				circle.Reverse();
			}
			Interval domainU = _0023_003Dz4wZe_0024Xg_003D.DomainU;
			Point3D[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				InterPoint interPoint = (InterPoint)array2[i];
				double num = interPoint.s;
				if (!_0023_003Dzx3pYiE0_003D)
				{
					num = Math.PI * 2.0 - num;
				}
				num += domainU.Low;
				if (!domainU._0023_003DzNoPt9TsyzDMJ(num))
				{
					if (!(interPoint.s < 1E-12) && !(interPoint.s > 6.283185307178586))
					{
						continue;
					}
					num = Math.PI * 2.0 - interPoint.s;
					if (!_0023_003Dzx3pYiE0_003D)
					{
						num = Math.PI * 2.0 - num;
					}
					num += domainU.Low;
					if (!domainU._0023_003DzNoPt9TsyzDMJ(num))
					{
						continue;
					}
				}
				circle.GetNurbsFormParameterFromRadian(num, out var nurbsParam);
				interPoint.s = nurbsParam;
				if (flag)
				{
					interPoint.t *= -1.0;
				}
				interPoint.t += v;
				list.Add(interPoint);
			}
		}
		return list.ToArray();
	}

	internal static Point3D[] _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(IList<Point3D> _0023_003Dzh5zIRDeVqFGp, Surface _0023_003Dz_0024KKopL9T7nzT, bool _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_0023_003DzX5UoPdYta6PN3aRrrg_003D_003D)
		{
			foreach (InitialPoint item in _0023_003Dzh5zIRDeVqFGp)
			{
				bool flag;
				if (_0023_003Dz_0024KKopL9T7nzT.IsTrimmed)
				{
					_0023_003Dz_0024KKopL9T7nzT.ControlBoundingBox(out var min, out var max);
					Size3D size3D = new Size3D(min, max);
					flag = Surface._0023_003Dz5uD5f33zAE2Q(item, _0023_003Dz_0024KKopL9T7nzT, size3D.Diagonal, _0023_003DzRVoDPs0_003D: false);
				}
				else
				{
					flag = _0023_003Dz_0024KKopL9T7nzT.DomainV._0023_003DzNoPt9TsyzDMJ(item.t) && _0023_003Dz_0024KKopL9T7nzT.DomainU._0023_003DzNoPt9TsyzDMJ(item.s);
				}
				if (flag)
				{
					list.Add(item);
				}
			}
		}
		else
		{
			foreach (InitialPoint item2 in _0023_003Dzh5zIRDeVqFGp)
			{
				bool flag;
				if (_0023_003Dz_0024KKopL9T7nzT.IsTrimmed)
				{
					_0023_003Dz_0024KKopL9T7nzT.PointAt(new Point2D(item2.s, item2.t));
					flag = _0023_003Dz_0024KKopL9T7nzT.Trimming.IsPointInside(new Point2D(item2.s, item2.t));
				}
				else
				{
					flag = _0023_003Dz_0024KKopL9T7nzT.DomainV.Includes(item2.t, testOpenInterval: true) && _0023_003Dz_0024KKopL9T7nzT.DomainU.Includes(item2.s, testOpenInterval: true);
				}
				if (flag)
				{
					list.Add(item2);
				}
			}
		}
		return list.ToArray();
	}

	internal static Point3D[] _0023_003DzRSS29Um2HaKP1afdQiM62lc_003D(ConicalSurf _0023_003DzrI2jLi0_003D, Surface _0023_003Dz4wZe_0024Xg_003D, bool _0023_003Dzx3pYiE0_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		Point3D[] array = _0023_003DzrI2jLi0_003D.IntersectWith(_0023_003DzSwfghCo_003D);
		if (array.Length != 0)
		{
			_0023_003Dz4wZe_0024Xg_003D.Project(_0023_003DzrI2jLi0_003D.Plane.Origin + _0023_003DzrI2jLi0_003D.Plane.AxisX * _0023_003DzrI2jLi0_003D.Radius, double.MaxValue, true, out double u, out double v);
			double rotAngleU = _0023_003Dz4wZe_0024Xg_003D.rotAngleU;
			Point3D[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				InterPoint interPoint = (InterPoint)array2[i];
				double num = interPoint.s - rotAngleU;
				if (!_0023_003Dzx3pYiE0_003D)
				{
					num *= -1.0;
				}
				if (num < 0.0)
				{
					num += Math.PI * 2.0;
				}
				interPoint.s = num + u;
				if (interPoint.s > _0023_003Dz4wZe_0024Xg_003D.DomainU.High)
				{
					interPoint.s -= Math.PI * 2.0;
				}
				else if (interPoint.s < _0023_003Dz4wZe_0024Xg_003D.DomainU.Low)
				{
					interPoint.s += Math.PI * 2.0;
				}
				interPoint.t += v;
			}
		}
		return array;
	}

	internal static Point3D[] _0023_003DzLrFUYa1xwg7B8Hud0JMFRUmousbE(SphericalSurf _0023_003Dz7TFjJCU_003D, Surface _0023_003Dz4wZe_0024Xg_003D, bool _0023_003Dzx3pYiE0_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		Point3D[] array = _0023_003Dz7TFjJCU_003D.IntersectWith(_0023_003DzSwfghCo_003D);
		if (array.Length != 0)
		{
			double rotAngleU = _0023_003Dz4wZe_0024Xg_003D.rotAngleU;
			double num = _0023_003Dz4wZe_0024Xg_003D.DomainV.Low - -Math.PI / 2.0;
			Point3D[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				InterPoint interPoint = (InterPoint)array2[i];
				double num2 = interPoint.s - rotAngleU;
				if (!_0023_003Dzx3pYiE0_003D)
				{
					num2 *= -1.0;
				}
				if (num2 < 0.0)
				{
					num2 += Math.PI * 2.0;
				}
				interPoint.s = num2;
				interPoint.t += num;
				if (interPoint.t > _0023_003Dz4wZe_0024Xg_003D.DomainV.High)
				{
					interPoint.t -= Math.PI * 2.0;
				}
				else if (interPoint.t < _0023_003Dz4wZe_0024Xg_003D.DomainV.Low)
				{
					interPoint.t += Math.PI * 2.0;
				}
				if (interPoint.s > _0023_003Dz4wZe_0024Xg_003D.DomainU.High)
				{
					interPoint.s -= Math.PI * 2.0;
				}
				else if (interPoint.s < _0023_003Dz4wZe_0024Xg_003D.DomainU.Low)
				{
					interPoint.s += Math.PI * 2.0;
				}
			}
		}
		return array;
	}

	internal static Point3D[] _0023_003DzSvK3OjfW1BD5VxWMgvUsFheXVMjE(ToroidalSurf _0023_003Dz7TFjJCU_003D, Surface _0023_003Dz4wZe_0024Xg_003D, bool _0023_003DzbOec4yw_003D, bool _0023_003DztuMTeiU_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		Point3D[] array = _0023_003Dz7TFjJCU_003D.IntersectWith(_0023_003DzSwfghCo_003D);
		if (array.Length != 0)
		{
			double rotAngleU = _0023_003Dz4wZe_0024Xg_003D.rotAngleU;
			double rotAngleV = _0023_003Dz4wZe_0024Xg_003D.rotAngleV;
			_0023_003Dz4wZe_0024Xg_003D.PointInversion(_0023_003Dz7TFjJCU_003D.PointAt(0.0, 0.0), Utility._0023_003DzxhnLabVjXjPg, out var proj);
			double num = proj.Y;
			if (_0023_003Dz4wZe_0024Xg_003D.DomainV.Low < 0.0)
			{
				num -= Math.PI * 2.0;
			}
			Point3D[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				InterPoint interPoint = (InterPoint)array2[i];
				double u = interPoint.s;
				double v = interPoint.t;
				if (_0023_003Dz7TFjJCU_003D.MajorRadius < 0.0)
				{
					if (_0023_003Dz4wZe_0024Xg_003D.Project(interPoint, out u, out v) && _0023_003Dz4wZe_0024Xg_003D.PointAt(u, v).DistanceTo(interPoint) < Utility._0023_003DzheSR8QM7q9ya)
					{
						interPoint.s = u;
						interPoint.t = v;
					}
					continue;
				}
				u -= rotAngleU;
				v -= rotAngleV;
				if (!_0023_003DzbOec4yw_003D)
				{
					u *= -1.0;
				}
				if (!_0023_003DztuMTeiU_003D)
				{
					v *= -1.0;
				}
				if (u < 0.0)
				{
					u += Math.PI * 2.0;
				}
				if (v < 0.0)
				{
					v += Math.PI * 2.0;
				}
				interPoint.s = u + _0023_003Dz4wZe_0024Xg_003D.DomainU.Low;
				interPoint.t = v + num;
				if (interPoint.t > _0023_003Dz4wZe_0024Xg_003D.DomainV.High)
				{
					interPoint.t -= Math.PI * 2.0;
				}
				else if (interPoint.t < _0023_003Dz4wZe_0024Xg_003D.DomainV.Low)
				{
					interPoint.t += Math.PI * 2.0;
				}
				if (interPoint.s > _0023_003Dz4wZe_0024Xg_003D.DomainU.High)
				{
					interPoint.s -= Math.PI * 2.0;
				}
				else if (interPoint.s < _0023_003Dz4wZe_0024Xg_003D.DomainU.Low)
				{
					interPoint.s += Math.PI * 2.0;
				}
			}
		}
		return array;
	}

	internal static Point3D[] _0023_003Dz7XOXgvOEVlaU(Surface _0023_003Dz_0024KKopL9T7nzT, ICurve _0023_003Dz8fpRyMu9aKjE, AnalyticSurf _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D, bool _0023_003Dzx3pYiE0_003D, bool _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D, TrimCurve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU, Plane _0023_003DzrWdn_0024Fk57aGTs6NraQ_003D_003D, double _0023_003DzccAR5G0_003D, bool _0023_003DznbZoSmWt0NXt6IJtqNzBrqOnUXC7)
	{
		Point3D[] _0023_003Dzh5zIRDeVqFGp = new Point3D[0];
		_0023_003Dz_0024KKopL9T7nzT.ControlBoundingBox(0.001, out var min, out var max);
		Curve nurbsForm = _0023_003Dz8fpRyMu9aKjE.GetNurbsForm();
		nurbsForm.ControlBoundingBox(0.001, out var min2, out var max2);
		if (!Utility.DoOverlap(min, max, min2, max2))
		{
			return _0023_003Dzh5zIRDeVqFGp;
		}
		if (_0023_003DzrLRhLtofvSkH(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz_0024KKopL9T7nzT, _0023_003Dzx3pYiE0_003D, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU, _0023_003DzccAR5G0_003D, out _0023_003Dzh5zIRDeVqFGp, _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D) == (_0023_003DzWbIbatcG6O_00243)2)
		{
			if (_0023_003DzrWdn_0024Fk57aGTs6NraQ_003D_003D == null && _0023_003DznbZoSmWt0NXt6IJtqNzBrqOnUXC7)
			{
				_0023_003DzrWdn_0024Fk57aGTs6NraQ_003D_003D = _0023_003Dz_0024KKopL9T7nzT._0023_003DzNY5YUv279_SW(nurbsForm, out var _0023_003Dz53Y4nJywjeVd);
				_0023_003DzccAR5G0_003D = _0023_003Dz53Y4nJywjeVd.Diagonal;
			}
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzGxr4M_HPrMkl(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzrWdn_0024Fk57aGTs6NraQ_003D_003D, _0023_003DzccAR5G0_003D, _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, _0023_003DzoHguvx0by0LU);
			_0023_003Dzh5zIRDeVqFGp = _0023_003DzW9Fs5mwcv7kY3J7ZgQ_003D_003D(_0023_003Dzh5zIRDeVqFGp, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D);
		}
		return _0023_003Dzh5zIRDeVqFGp;
	}

	private static void _0023_003DzToASpaChySw7H7HQ06Lr_0024V5gK5iD(ICurve _0023_003Dz8fpRyMu9aKjE, TrimCurve _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D, Surface _0023_003DzoHguvx0by0LU, Point3D[] _0023_003Dzh5zIRDeVqFGp)
	{
		for (int i = 0; i < _0023_003Dzh5zIRDeVqFGp.Length; i++)
		{
			InitialPoint initialPoint = (InitialPoint)_0023_003Dzh5zIRDeVqFGp[i];
			initialPoint.curveTx = _0023_003Dz8fpRyMu9aKjE.EndTangent.X;
			initialPoint.curveTy = _0023_003Dz8fpRyMu9aKjE.EndTangent.Y;
			initialPoint.curveTz = _0023_003Dz8fpRyMu9aKjE.EndTangent.Z;
			initialPoint._0023_003DzutFG6gdoV0Ic = _0023_003DzMgIxPhNS00ioe4fS1Q9yGuA_003D;
			if (_0023_003DzoHguvx0by0LU != null && _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP() != null)
			{
				initialPoint.startPointCurveOwner = _0023_003DzoHguvx0by0LU._0023_003Dz1PC0lMBv7hGP();
			}
			else if (_0023_003DzoHguvx0by0LU != null)
			{
				initialPoint.startPointCurveOwner = _0023_003DzoHguvx0by0LU;
			}
		}
	}
}
