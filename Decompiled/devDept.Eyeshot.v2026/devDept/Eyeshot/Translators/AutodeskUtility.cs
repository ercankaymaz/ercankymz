using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class AutodeskUtility
{
	internal static Entity ReadSolid(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D _0023_003DzZbOaTIM_003D, double _0023_003Dzetc0sjwdrddceszzig_003D_003D, string _0023_003Dz_0024ZlTCnbJcghi, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		Entity entity;
		if (_0023_003Dz_s59BFycTcLUOE0fVw_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzqiqldgRGLZLgH668WopyQAY_003D) && _0023_003DzqiqldgRGLZLgH668WopyQAY_003D.Length == 2)
		{
			_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998093), _0023_003Dz_0024ZlTCnbJcghi));
			entity = new Line(_0023_003DzqiqldgRGLZLgH668WopyQAY_003D[0], _0023_003DzqiqldgRGLZLgH668WopyQAY_003D[1]);
		}
		else if (_0023_003DzqiqldgRGLZLgH668WopyQAY_003D != null && _0023_003DzqiqldgRGLZLgH668WopyQAY_003D.Length == 3)
		{
			Plane pln = new Plane(_0023_003DzqiqldgRGLZLgH668WopyQAY_003D[0], _0023_003DzZbOaTIM_003D);
			LinearPath linearPath = new LinearPath(_0023_003DzqiqldgRGLZLgH668WopyQAY_003D[0], _0023_003DzqiqldgRGLZLgH668WopyQAY_003D[1], _0023_003DzqiqldgRGLZLgH668WopyQAY_003D[2]);
			Vector3D vector3D = new Vector3D(_0023_003DzqiqldgRGLZLgH668WopyQAY_003D[0], _0023_003DzqiqldgRGLZLgH668WopyQAY_003D[1], _0023_003DzqiqldgRGLZLgH668WopyQAY_003D[2]);
			if (vector3D.Normalize() && Vector3D.AreOpposite(vector3D, _0023_003DzZbOaTIM_003D))
			{
				linearPath.Reverse();
			}
			entity = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), new LinearPath[1] { linearPath }, pln);
		}
		else
		{
			Plane pln2 = new Plane(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003DzZbOaTIM_003D);
			LinearPath linearPath2 = new LinearPath(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2]);
			entity = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), new LinearPath[1] { linearPath2 }, pln2);
		}
		if (_0023_003Dzetc0sjwdrddceszzig_003D_003D != 0.0)
		{
			entity.AutodeskProperties = new AutodeskProperties
			{
				Thickness = _0023_003Dzetc0sjwdrddceszzig_003D_003D,
				ExtrusionDir = _0023_003DzZbOaTIM_003D
			};
		}
		return entity;
	}

	private static bool _0023_003Dz_s59BFycTcLUOE0fVw_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Point3D[] _0023_003DzqiqldgRGLZLgH668WopyQAY_003D)
	{
		_0023_003DzqiqldgRGLZLgH668WopyQAY_003D = null;
		List<Point3D> list = new List<Point3D>(2) { _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] };
		for (int i = 1; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			int num = 0;
			for (int j = 0; j < list.Count; j++)
			{
				if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] == list[j])
				{
					num++;
				}
			}
			if (num == 0)
			{
				list.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
			}
		}
		if (list.Count == _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length)
		{
			return false;
		}
		_0023_003DzqiqldgRGLZLgH668WopyQAY_003D = list.ToArray();
		return true;
	}
}
