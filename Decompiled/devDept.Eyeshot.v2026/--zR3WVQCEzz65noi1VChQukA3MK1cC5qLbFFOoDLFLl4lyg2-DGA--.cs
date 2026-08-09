using System;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D : _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D
{
	public _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(Point3D[] _0023_003DzrdSL0CI_003D)
		: base(_0023_003DzrdSL0CI_003D)
	{
		if (!Machining._0023_003DzySfSteI_003D(_0023_003DzrdSL0CI_003D))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994526));
		}
	}

	public _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzl_0024MIsC0_003D)
		: base(_0023_003Dzl_0024MIsC0_003D)
	{
	}

	internal override bool _0023_003DzlPrfzfc_003D(_0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl _0023_003DzS3WVCr8Gsb__0024, cutDirectionType _0023_003DzCIpOJSfcMrGo, double _0023_003Dzm0CYiiE_003D = 1E-06)
	{
		bool flag = Utility.IsOrientedClockwise(_0023_003DzFsatqHw_003D);
		if (_0023_003DzCIpOJSfcMrGo == cutDirectionType.Climb)
		{
			flag = !flag;
		}
		Point3D[] _0023_003DzDKVESdcjwYUE = _0023_003DzS3WVCr8Gsb__0024._0023_003DzDKVESdcjwYUE;
		foreach (Point3D point3D in _0023_003DzDKVESdcjwYUE)
		{
			if (!(Point2D.DistanceSquared(point3D, _0023_003DzS3WVCr8Gsb__0024._0023_003DzlJZ1aN4_003D) < _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D) && Utility.PointInPolygon(point3D, _0023_003DzFsatqHw_003D) != flag)
			{
				return false;
			}
		}
		return base._0023_003DzlPrfzfc_003D(_0023_003DzS3WVCr8Gsb__0024, _0023_003DzCIpOJSfcMrGo, _0023_003Dzm0CYiiE_003D);
	}

	public override object Clone()
	{
		return new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(this);
	}
}
