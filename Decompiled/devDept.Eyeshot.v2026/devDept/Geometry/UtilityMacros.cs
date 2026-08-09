using System;

namespace devDept.Geometry;

public class UtilityMacros
{
	public static void CROSS(ref double[] dest, double[] v1, double[] v2)
	{
		dest[0] = v1[1] * v2[2] - v1[2] * v2[1];
		dest[1] = v1[2] * v2[0] - v1[0] * v2[2];
		dest[2] = v1[0] * v2[1] - v1[1] * v2[0];
	}

	public static double DOT(double[] v1, double[] v2)
	{
		return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
	}

	public static void SUB(ref double[] dest, double[] v1, double[] v2)
	{
		dest[0] = v1[0] - v2[0];
		dest[1] = v1[1] - v2[1];
		dest[2] = v1[2] - v2[2];
	}

	private static void _0023_003Dz4IzSWRWHLQWh(ref double[] _0023_003DzaoQTclc_003D, double _0023_003DzbvIFYko_003D, double[] _0023_003Dz77g161c_003D)
	{
		_0023_003DzaoQTclc_003D[0] = _0023_003DzbvIFYko_003D * _0023_003Dz77g161c_003D[0];
		_0023_003DzaoQTclc_003D[1] = _0023_003DzbvIFYko_003D * _0023_003Dz77g161c_003D[1];
		_0023_003DzaoQTclc_003D[2] = _0023_003DzbvIFYko_003D * _0023_003Dz77g161c_003D[2];
	}

	public static void TRANSFORM(ref double[] v, Transformation xform)
	{
		double[] array = xform.ActOnLeft(v[0], v[1], v[2], 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		v[0] = num * array[0];
		v[1] = num * array[1];
		v[2] = num * array[2];
	}

	public static void NORMALIZE(ref double[] v)
	{
		double num = Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
		v[0] /= num;
		v[1] /= num;
		v[2] /= num;
	}
}
