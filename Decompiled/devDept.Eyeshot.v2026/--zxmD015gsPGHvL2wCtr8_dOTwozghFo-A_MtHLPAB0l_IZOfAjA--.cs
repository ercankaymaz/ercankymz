using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using devDept.Geometry;

internal static class _0023_003DzxmD015gsPGHvL2wCtr8_dOTwozghFo_0024A_MtHLPAB0l_IZOfAjA_003D_003D
{
	internal static Vector3D _0023_003DzdVv0tHg0zCjX(this XbimVector3D _0023_003DzpNiHXuO0e1lX)
	{
		return new Vector3D(_0023_003DzpNiHXuO0e1lX.X, _0023_003DzpNiHXuO0e1lX.Y, _0023_003DzpNiHXuO0e1lX.Z);
	}

	internal static Vector3D _0023_003DzdVv0tHg0zCjX(this IIfcVector _0023_003DzLMLGfQxn_xCW)
	{
		Vector3D vector3D = _0023_003DzLMLGfQxn_xCW.Orientation._0023_003DzdVv0tHg0zCjX();
		vector3D.Length = _0023_003DzLMLGfQxn_xCW.Magnitude;
		return vector3D;
	}

	internal static Vector3D _0023_003DzdVv0tHg0zCjX(this IIfcDirection _0023_003DzWEGYeSN_0024iQ_0024S)
	{
		return new Vector3D(_0023_003DzWEGYeSN_0024iQ_0024S.X, _0023_003DzWEGYeSN_0024iQ_0024S.Y, (_0023_003DzWEGYeSN_0024iQ_0024S.Dim == 2L) ? 0.0 : _0023_003DzWEGYeSN_0024iQ_0024S.Z);
	}

	internal static double[] _0023_003DzxmkascJ__U8n(this IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue> _0023_003DzNhhHwg9l8Zi0)
	{
		double[] array = new double[_0023_003DzNhhHwg9l8Zi0.Count];
		for (int i = 0; i < _0023_003DzNhhHwg9l8Zi0.Count; i++)
		{
			array[i] = _0023_003DzNhhHwg9l8Zi0[i];
		}
		return array;
	}

	internal static double[] _0023_003DzxmkascJ__U8n(this IItemSet<Xbim.Ifc2x3.MeasureResource.IfcParameterValue> _0023_003DzNhhHwg9l8Zi0)
	{
		double[] array = new double[_0023_003DzNhhHwg9l8Zi0.Count];
		for (int i = 0; i < _0023_003DzNhhHwg9l8Zi0.Count; i++)
		{
			array[i] = _0023_003DzNhhHwg9l8Zi0[i];
		}
		return array;
	}
}
