using System;
using System.Diagnostics;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 : _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D[][] _0023_003DzW_A1z8Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dz7aIurrDeQXkqESPYOQ_003D_003D = true;

	public _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7(Point3D[] _0023_003DzrdSL0CI_003D, Point3D[][] _0023_003DzBLGbisU_003D, bool _0023_003DzoQcRoMY_003D)
		: base(_0023_003DzrdSL0CI_003D)
	{
		if (!Machining._0023_003Dz6QH8iAk_003D(_0023_003DzrdSL0CI_003D))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995667));
		}
		_0023_003DzW_A1z8Q_003D = _0023_003DzBLGbisU_003D;
		_0023_003Dz7aIurrDeQXkqESPYOQ_003D_003D = _0023_003DzoQcRoMY_003D;
	}

	public _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7(_0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 _0023_003Dzl_0024MIsC0_003D)
		: base(_0023_003Dzl_0024MIsC0_003D)
	{
		_0023_003DzW_A1z8Q_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzW_A1z8Q_003D;
	}

	public bool _0023_003DzrDz685g1xhyc()
	{
		return _0023_003Dz7aIurrDeQXkqESPYOQ_003D_003D;
	}

	internal override bool _0023_003DzlPrfzfc_003D(_0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl _0023_003DzS3WVCr8Gsb__0024, cutDirectionType _0023_003DzCIpOJSfcMrGo, double _0023_003Dzm0CYiiE_003D = 1E-06)
	{
		Point3D[][] array = _0023_003DzW_A1z8Q_003D;
		for (int i = 0; i < array.Length; i++)
		{
			if (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D._0023_003Dz9h5MY_A_003D(array[i], _0023_003DzS3WVCr8Gsb__0024._0023_003DzDKVESdcjwYUE, _0023_003Dzm0CYiiE_003D))
			{
				return false;
			}
		}
		return true;
	}

	public override bool _0023_003Dz9h5MY_A_003D(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		return false;
	}

	public override object Clone()
	{
		return new _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7(this);
	}
}
