using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

internal sealed class _0023_003Dzi34rfaFGynKfVrmvSmrRLxMNVpZxoYbbssjSQmGdCd8wL0oHEHxQ_0024zso8XvNpS7cJw_003D_003D
{
	private Point3D[] _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;

	private IndexTriangle[] _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D;

	private IndexLine[][] _0023_003Dz6jyPFiQTur_0024S;

	private Surface _0023_003DzBXeGKPzO7YMs;

	public _0023_003Dzi34rfaFGynKfVrmvSmrRLxMNVpZxoYbbssjSQmGdCd8wL0oHEHxQ_0024zso8XvNpS7cJw_003D_003D(Surface _0023_003Dz_0024KKopL9T7nzT)
	{
		_0023_003DzBXeGKPzO7YMs = _0023_003Dz_0024KKopL9T7nzT;
		_0023_003DzBXeGKPzO7YMs._0023_003DzAqb6W_dLZ1oE(out _0023_003DzME2BuaSnJsM4mEn84A_003D_003D, out _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D, out _0023_003Dz6jyPFiQTur_0024S);
	}

	public Size2D _0023_003DzL9woobs_003D(ICurve[] _0023_003DzKTAIrow_003D)
	{
		int num = _0023_003DzKTAIrow_003D.Length;
		List<Point2D> list = new List<Point2D>();
		WriteFileParams _0023_003DzYwiCXkk_003D = new WriteFileParams();
		if (num == 1)
		{
			Curve nurbsForm = _0023_003DzKTAIrow_003D[0].GetNurbsForm();
			Point3D euclid = nurbsForm.Pw[1].Euclid;
			PointUv pointUv = _0023_003Dzg87J5_0024wEkz3L(euclid, _0023_003DzYwiCXkk_003D);
			if (!(pointUv != null))
			{
				_0023_003Dz7kIqYhuqn6GZ(euclid, nurbsForm);
				return new Size2D(_0023_003DzBXeGKPzO7YMs.DomainU.Length, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
			}
			list.Add(new Point2D(pointUv.U, pointUv.V));
			Point3D euclid2 = nurbsForm.Pw[nurbsForm._0023_003DzFNjygTLTZtF3() - 1].Euclid;
			pointUv = _0023_003Dzg87J5_0024wEkz3L(euclid2, _0023_003DzYwiCXkk_003D);
			if (!(pointUv != null))
			{
				_0023_003Dz7kIqYhuqn6GZ(euclid2, nurbsForm);
				return new Size2D(_0023_003DzBXeGKPzO7YMs.DomainU.Length, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
			}
			list.Add(new Point2D(pointUv.U, pointUv.V));
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				Curve nurbsForm2 = _0023_003DzKTAIrow_003D[i].GetNurbsForm();
				Point3D euclid3 = nurbsForm2.Pw[0].Euclid;
				PointUv pointUv2 = _0023_003Dzg87J5_0024wEkz3L(euclid3, _0023_003DzYwiCXkk_003D);
				if (pointUv2 != null)
				{
					list.Add(new Point2D(pointUv2.U, pointUv2.V));
					continue;
				}
				_0023_003Dz7kIqYhuqn6GZ(euclid3, nurbsForm2);
				return new Size2D(_0023_003DzBXeGKPzO7YMs.DomainU.Length, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
			}
		}
		Utility.ComputeBoundingRect(list, out var boxMin, out var boxMax);
		return new Size2D(boxMin, boxMax);
	}

	private PointUv _0023_003Dzg87J5_0024wEkz3L(Point3D _0023_003Dzl3DhHgI_003D, WriteFileParams _0023_003DzYwiCXkk_003D)
	{
		SortedList<double, PointUv> sortedList = new SortedList<double, PointUv>();
		IndexTriangle[] array = _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D;
		foreach (IndexTriangle indexTriangle in array)
		{
			PointUv pointUv = (PointUv)_0023_003DzME2BuaSnJsM4mEn84A_003D_003D[indexTriangle.V1];
			PointUv pointUv2 = (PointUv)_0023_003DzME2BuaSnJsM4mEn84A_003D_003D[indexTriangle.V2];
			PointUv pointUv3 = (PointUv)_0023_003DzME2BuaSnJsM4mEn84A_003D_003D[indexTriangle.V3];
			Plane plane = new Plane(pointUv, pointUv2, pointUv3);
			Point2D point2D = plane.Project(pointUv);
			Point2D point2D2 = plane.Project(pointUv2);
			Point2D point2D3 = plane.Project(pointUv3);
			Point2D point2D4 = plane.Project(_0023_003Dzl3DhHgI_003D);
			if (_0023_003DzmPn2XXu8_L2D(point2D4.X, point2D4.Y, point2D.X, point2D.Y, point2D2.X, point2D2.Y, point2D3.X, point2D3.Y, out var _0023_003Dz_eY3Y4c_003D, out var _0023_003Dz77g161c_003D))
			{
				Vector2D vector2D = new Vector2D(point2D, point2D3);
				Vector2D vector2D2 = new Vector2D(point2D, point2D2);
				Point3D point3D = plane.PointAt(_0023_003Dz_eY3Y4c_003D * vector2D.X + _0023_003Dz77g161c_003D * vector2D2.X, _0023_003Dz_eY3Y4c_003D * vector2D.Y + _0023_003Dz77g161c_003D * vector2D2.Y);
				double key = Point3D.DistanceSquared(point3D, _0023_003Dzl3DhHgI_003D);
				Vector2D vector2D3 = new Vector2D(new Point2D(pointUv.U, pointUv.V), new Point2D(pointUv3.U, pointUv3.V));
				Vector2D vector2D4 = new Vector2D(new Point2D(pointUv.U, pointUv.V), new Point2D(pointUv2.U, pointUv2.V));
				double u = pointUv.U + _0023_003Dz_eY3Y4c_003D * vector2D3.X + _0023_003Dz77g161c_003D * vector2D4.X;
				double v = pointUv.V + _0023_003Dz_eY3Y4c_003D * vector2D3.Y + _0023_003Dz77g161c_003D * vector2D4.Y;
				sortedList[key] = new PointUv(point3D.X, point3D.Y, point3D.Z, u, v);
			}
		}
		PointUv result = null;
		if (sortedList.Count > 0)
		{
			return sortedList.Values[0];
		}
		IndexLine[][] array2 = _0023_003Dz6jyPFiQTur_0024S;
		foreach (IndexLine[] array3 in array2)
		{
			foreach (IndexLine indexLine in array3)
			{
				PointUv pointUv4 = (PointUv)_0023_003DzME2BuaSnJsM4mEn84A_003D_003D[indexLine.V1];
				PointUv pointUv5 = (PointUv)_0023_003DzME2BuaSnJsM4mEn84A_003D_003D[indexLine.V2];
				Segment3D segment3D = new Segment3D(pointUv4, pointUv5);
				double num = segment3D.Project(_0023_003Dzl3DhHgI_003D);
				if (num >= 0.0 && num <= 1.0)
				{
					double key2 = Point3D.DistanceSquared(segment3D.PointAt(num), _0023_003Dzl3DhHgI_003D);
					Vector3D vector3D = new Vector3D(pointUv4, pointUv5);
					Point3D point3D2 = pointUv4 + vector3D * num;
					Vector2D vector2D5 = new Vector2D(new Point2D(pointUv4.U, pointUv4.V), new Point2D(pointUv5.U, pointUv5.V));
					double u2 = pointUv4.U * vector2D5.X * num;
					double v2 = pointUv4.V * vector2D5.Y * num;
					sortedList[key2] = new PointUv(point3D2.X, point3D2.Y, point3D2.Z, u2, v2);
				}
			}
		}
		if (sortedList.Count > 0)
		{
			return sortedList.Values[0];
		}
		return result;
	}

	private static bool _0023_003DzmPn2XXu8_L2D(double _0023_003DzuTkHiyI_003D, double _0023_003Dz0KVPVlc_003D, double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, double _0023_003DzuPuPztg_003D, double _0023_003Dz4693IIk_003D, out double _0023_003Dz_eY3Y4c_003D, out double _0023_003Dz77g161c_003D)
	{
		double[] array = new double[2]
		{
			_0023_003DzuPuPztg_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz4693IIk_003D - _0023_003DzpilgH4E_003D
		};
		double[] array2 = new double[2]
		{
			_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz8qV981c_003D - _0023_003DzpilgH4E_003D
		};
		double[] array3 = new double[2]
		{
			_0023_003DzuTkHiyI_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz0KVPVlc_003D - _0023_003DzpilgH4E_003D
		};
		double num = array[0] * array[0] + array[1] * array[1];
		double num2 = array2[0] * array2[0] + array2[1] * array2[1];
		double num3 = array[0] * array2[0] + array[1] * array2[1];
		double num4 = array[0] * array3[0] + array[1] * array3[1];
		double num5 = array2[0] * array3[0] + array2[1] * array3[1];
		double num6 = num * num2 - num3 * num3;
		double num7 = 1.0 / num6;
		_0023_003Dz_eY3Y4c_003D = (num2 * num4 - num3 * num5) * num7;
		_0023_003Dz77g161c_003D = (num * num5 - num3 * num4) * num7;
		if (_0023_003Dz_eY3Y4c_003D > 0.0 - Utility._0023_003Dzjyaz_Vfaky9X && _0023_003Dz77g161c_003D > 0.0 - Utility._0023_003Dzjyaz_Vfaky9X)
		{
			return _0023_003Dz_eY3Y4c_003D + _0023_003Dz77g161c_003D < 1.0 + Utility._0023_003Dzjyaz_Vfaky9X;
		}
		return false;
	}

	private void _0023_003Dz7kIqYhuqn6GZ(Point3D _0023_003Dzl3DhHgI_003D, Curve _0023_003Dz8fpRyMu9aKjE)
	{
	}
}
