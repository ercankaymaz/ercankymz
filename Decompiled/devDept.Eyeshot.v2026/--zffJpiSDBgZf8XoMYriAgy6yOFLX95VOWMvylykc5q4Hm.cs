using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm : _0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl
{
	public _0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm(Lead _0023_003Dzalvl9z8_003D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dz9BM_0024JJOnfyrP, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo)
		: base(_0023_003Dzalvl9z8_003D, _0023_003Dz9BM_0024JJOnfyrP, _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw, _0023_003Dz1v8WebVg_QJi, _0023_003Dz4w6tHu4_003D, _0023_003DzCIpOJSfcMrGo)
	{
	}

	internal bool _0023_003Dz5M9agOPDMhxd(Geometry3D _0023_003Dz0y8dHgRbs7n3, Setup _0023_003Dz9cS3uG0_003D, Machining3D _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D, double _0023_003Dz89Mrb8s_003D, out Toolpath.Motion[] _0023_003DzzF0HA1IaMpzg)
	{
		_0023_003DzzF0HA1IaMpzg = null;
		Toolpath.Motion another = _0023_003DzRwuOq0Upg_0024zq[0];
		Toolpath toolpath = new Toolpath(Utility.DeepCopy(_0023_003DzRwuOq0Upg_0024zq));
		toolpath.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		toolpath.Regen(_0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.Tolerance);
		Project3D project3D = new Project3D(_0023_003Dz9cS3uG0_003D, _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.Tool, _0023_003Dz0y8dHgRbs7n3, toolpath.allVertices, 0.0, _0023_003Dz89Mrb8s_003D - _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.AxialStockToLeave);
		project3D.Tolerance = _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.Tolerance;
		project3D.AxialStockToLeave = _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.AxialStockToLeave;
		project3D.RadialStockToLeave = _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.RadialStockToLeave;
		project3D._0023_003DzDOhy2axZcCW3uVD72j_gWiI_003D = true;
		project3D.DoWork();
		List<Toolpath.Motion> motionList = project3D.Result.MotionList;
		if (motionList.Count < 1)
		{
			return false;
		}
		foreach (Toolpath.Motion item in motionList)
		{
			item.CopyFrom(another);
		}
		_0023_003DzzF0HA1IaMpzg = motionList.ToArray();
		return true;
	}
}
