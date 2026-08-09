using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal abstract class _0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl
{
	public readonly Point3D[] _0023_003DzDKVESdcjwYUE;

	public readonly Toolpath.Motion[] _0023_003DzRwuOq0Upg_0024zq;

	public Point3D _0023_003DzlJZ1aN4_003D;

	protected _0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl(LeadBase _0023_003DzS3WVCr8Gsb__0024, _0023_003Dzd86dNsN4xKzhYGmjDaDdvCmQzLLQY4unJG52BicbBdEm _0023_003DzfX4euWM_003D, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D)
	{
		_0023_003DzlJZ1aN4_003D = Point3D.Origin;
		_0023_003DzlJZ1aN4_003D.TransformBy(_0023_003DzfX4euWM_003D);
		_0023_003DzRwuOq0Upg_0024zq = _0023_003DzUNQ_t5U_003D(_0023_003DzS3WVCr8Gsb__0024.Motions, _0023_003DzfX4euWM_003D, _0023_003Dz1v8WebVg_QJi, _0023_003DzS3WVCr8Gsb__0024.Feed ?? (_0023_003Dz4w6tHu4_003D / 10.0));
		_0023_003DzDKVESdcjwYUE = _0023_003DzUNQ_t5U_003D(_0023_003DzS3WVCr8Gsb__0024.InterPoints, _0023_003DzfX4euWM_003D);
	}

	protected _0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl(LeadBase _0023_003DzS3WVCr8Gsb__0024, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dz9BM_0024JJOnfyrP, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo)
		: this(_0023_003DzS3WVCr8Gsb__0024, new _0023_003Dzd86dNsN4xKzhYGmjDaDdvCmQzLLQY4unJG52BicbBdEm(_0023_003Dz9BM_0024JJOnfyrP, _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw, _0023_003DzCIpOJSfcMrGo), _0023_003Dz1v8WebVg_QJi, _0023_003Dz4w6tHu4_003D)
	{
	}

	private Point3D[] _0023_003DzUNQ_t5U_003D(Point3D[] _0023_003DzTbDlaOM_003D, Transformation _0023_003DzLS0sR0pzioXc)
	{
		Point3D[] array = Utility.DeepCopy(_0023_003DzTbDlaOM_003D);
		Point3D[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].TransformBy(_0023_003DzLS0sR0pzioXc);
		}
		return array;
	}

	private Toolpath.Motion[] _0023_003DzUNQ_t5U_003D(Toolpath.Motion[] _0023_003DzTbDlaOM_003D, Transformation _0023_003DzLS0sR0pzioXc, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D)
	{
		Toolpath.Motion[] array = new Toolpath.Motion[_0023_003DzTbDlaOM_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Toolpath.Motion motion = (array[i] = (Toolpath.Motion)_0023_003DzTbDlaOM_003D[i].Clone());
			motion._0023_003DzUNQ_t5U_003D(_0023_003DzLS0sR0pzioXc);
			motion._0023_003Dz41Aikc8L0dNl(Plane.XY);
			motion.Speed = _0023_003Dz1v8WebVg_QJi;
			motion.Feed = _0023_003Dz4w6tHu4_003D;
		}
		return array;
	}
}
