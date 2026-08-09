using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003Dzd86dNsN4xKzhYGmjDaDdvCmQzLLQY4unJG52BicbBdEm : Transformation
{
	public _0023_003Dzd86dNsN4xKzhYGmjDaDdvCmQzLLQY4unJG52BicbBdEm(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dz9BM_0024JJOnfyrP, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, cutDirectionType _0023_003DzCIpOJSfcMrGo)
	{
		Point3D _0023_003Dz0dLh_0024eBXCsQF = _0023_003Dz9BM_0024JJOnfyrP._0023_003DzFsatqHw_003D[_0023_003DzGaSzuaHRZ_0024fm];
		double angle = _0023_003DzeiRXG7s_003D(_0023_003Dz9BM_0024JJOnfyrP._0023_003DzFsatqHw_003D, _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw).Angle;
		_0023_003DztGdcVOA_003D(angle, _0023_003DzCIpOJSfcMrGo, _0023_003Dz0dLh_0024eBXCsQF);
	}

	public _0023_003Dzd86dNsN4xKzhYGmjDaDdvCmQzLLQY4unJG52BicbBdEm(_0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DzOm40_LfQ2mOP, cutDirectionType _0023_003DzCIpOJSfcMrGo)
	{
		Toolpath.Motion motion = _0023_003DzOm40_LfQ2mOP._0023_003DzRwuOq0Upg_0024zq[0];
		double angle = motion._0023_003Dz_0024SVYRCY_003D().Angle;
		_0023_003DztGdcVOA_003D(angle, _0023_003DzCIpOJSfcMrGo, motion.StartPoint);
	}

	private void _0023_003DztGdcVOA_003D(double _0023_003Dz6pajdGM_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo, Point3D _0023_003Dz0dLh_0024eBXCsQF)
	{
		Transformation transformation = ((_0023_003DzCIpOJSfcMrGo == cutDirectionType.Conventional) ? ((Transformation)new Mirror(Plane.XZ)) : ((Transformation)new Identity()));
		transformation = new Translation(_0023_003Dz0dLh_0024eBXCsQF.AsVector) * new Rotation(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ) * transformation;
		base.Matrix = transformation.Matrix;
	}

	private Vector2D _0023_003DzeiRXG7s_003D(Point3D[] _0023_003DzrdSL0CI_003D, int _0023_003DzyzK8swU_003D, bool _0023_003DzdnLFZC6dNqmw)
	{
		if (!_0023_003DzdnLFZC6dNqmw)
		{
			return new Vector2D(_0023_003DzrdSL0CI_003D[_0023_003DzyzK8swU_003D - 1], _0023_003DzrdSL0CI_003D[_0023_003DzyzK8swU_003D]);
		}
		return new Vector2D(_0023_003DzrdSL0CI_003D[_0023_003DzyzK8swU_003D], _0023_003DzrdSL0CI_003D[_0023_003DzyzK8swU_003D + 1]);
	}
}
