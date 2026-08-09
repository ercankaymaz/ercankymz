using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MS.Internal;

internal static class VectorUtilities
{
	public static Matrix GetMatrixFromTransform(GeneralTransform generalTransform)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Transform val = (Transform)(object)((generalTransform is Transform) ? generalTransform : null);
		if (val != null)
		{
			return val.Value;
		}
		return Matrix.Identity;
	}

	public static bool AngleIsGreaterThan(Vector a, Vector b, double angleInRadian)
	{
		if (!(angleInRadian <= 0.0))
		{
			_ = Math.PI;
		}
		double num = Math.Cos(angleInRadian);
		double num2 = ((Vector)(ref a)).X * ((Vector)(ref b)).X + ((Vector)(ref a)).Y * ((Vector)(ref b)).Y;
		if (num2 >= 0.0)
		{
			if (num <= 0.0)
			{
				return false;
			}
			return num2 * num2 < num * num * ((Vector)(ref a)).LengthSquared * ((Vector)(ref b)).LengthSquared;
		}
		if (num >= 0.0)
		{
			return true;
		}
		return num2 * num2 > num * num * ((Vector)(ref a)).LengthSquared * ((Vector)(ref b)).LengthSquared;
	}

	public static Point Midpoint(Point a, Point b)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		return new Point((((Point)(ref a)).X + ((Point)(ref b)).X) / 2.0, (((Point)(ref a)).Y + ((Point)(ref b)).Y) / 2.0);
	}

	public static Point WeightedAverage(Point a, Point b, double t)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		double num = 1.0 - t;
		return new Point(num * ((Point)(ref a)).X + t * ((Point)(ref b)).X, num * ((Point)(ref a)).Y + t * ((Point)(ref b)).Y);
	}

	public static bool AreVeryClose(Point a, Point b)
	{
		return (((Point)(ref b)).X - ((Point)(ref a)).X) * (((Point)(ref b)).X - ((Point)(ref a)).X) + (((Point)(ref b)).Y - ((Point)(ref a)).Y) * (((Point)(ref b)).Y - ((Point)(ref a)).Y) <= FloatingPointArithmetic.SquaredDistanceTolerance;
	}

	public static Vector Unscale(Vector start, Vector scale)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		return new Vector(((Vector)(ref start)).X / ((Vector)(ref scale)).X, ((Vector)(ref start)).Y / ((Vector)(ref scale)).Y);
	}

	public static bool ComputeClosestPointOnTransformedLineSegment(Point point, Point a, Point b, Matrix matrix, double toleranceSquared, out double resultParameter, out Point resultPoint, out double resultDistanceSquared)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		Vector a2 = (b - a) * matrix;
		Vector b2 = point - a * matrix;
		double lengthSquared = ((Vector)(ref a2)).LengthSquared;
		resultParameter = ((lengthSquared < FloatingPointArithmetic.SquaredDistanceTolerance) ? 0.0 : (Dot(a2, b2) / lengthSquared));
		if (resultParameter <= 0.0)
		{
			resultParameter = 0.0;
			resultPoint = a;
		}
		else if (resultParameter >= 1.0)
		{
			resultParameter = 1.0;
			resultPoint = b;
		}
		else
		{
			resultPoint = WeightedAverage(a, b, resultParameter);
		}
		Vector val = resultPoint * matrix - point;
		resultDistanceSquared = ((Vector)(ref val)).LengthSquared;
		return resultDistanceSquared <= toleranceSquared;
	}

	public static double Dot(Vector a, Vector b)
	{
		return ((Vector)(ref a)).X * ((Vector)(ref b)).X + ((Vector)(ref a)).Y * ((Vector)(ref b)).Y;
	}

	public static double Distance(Point a, Point b)
	{
		double num = ((Point)(ref a)).X - ((Point)(ref b)).X;
		double num2 = ((Point)(ref a)).Y - ((Point)(ref b)).Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static double SquaredDistance(Point a, Point b)
	{
		double num = ((Point)(ref a)).X - ((Point)(ref b)).X;
		double num2 = ((Point)(ref a)).Y - ((Point)(ref b)).Y;
		return num * num + num2 * num2;
	}

	internal static bool ArePolylinesClose(List<Point> p, double[] lengthP, int firstP, int lastP, List<Point> q, double[] lengthQ, int firstQ, int lastQ, double distanceTolerance, ref int firstBadVertexInQ)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		double num = distanceTolerance * distanceTolerance;
		int i = firstP;
		double num2 = lengthP[firstP];
		double num3 = lengthQ[firstQ];
		for (int j = firstQ + 1; j < lastQ; j++)
		{
			for (; i <= lastP && lengthQ[j] - num3 > lengthP[i] - num2; i++)
			{
			}
			if (i > lastP)
			{
				for (int k = j; k < lastQ; k++)
				{
					if (SquaredDistance(p[lastP], q[k]) > num)
					{
						firstBadVertexInQ = k;
						return false;
					}
				}
				return true;
			}
			Vector val = p[i] - p[i - 1];
			val *= (lengthQ[j] - num3 - lengthP[i - 1] + num2) / (lengthP[i] - lengthP[i - 1]);
			Point a = p[i - 1] + val;
			if (SquaredDistance(a, q[j]) > num)
			{
				firstBadVertexInQ = j;
				return false;
			}
		}
		return true;
	}

	public static double[] GetCumulatedChordLength(List<Point> points, int firstIndex, int lastIndex)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (firstIndex <= lastIndex && firstIndex >= 0 && lastIndex >= 0 && firstIndex < points.Count)
		{
			_ = points.Count;
		}
		double[] array = new double[lastIndex - firstIndex + 1];
		double num = (array[0] = 0.0);
		int num2 = firstIndex + 1;
		int num3 = 1;
		while (num2 <= lastIndex)
		{
			num = (array[num3] = num + Distance(points[num2 - 1], points[num2]));
			num2++;
			num3++;
		}
		return array;
	}

	public static Vector UnitNormal(Vector v)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		Vector result = default(Vector);
		((Vector)(ref result))._002Ector(((Vector)(ref v)).Y, 0.0 - ((Vector)(ref v)).X);
		((Vector)(ref result)).Normalize();
		return result;
	}

	public static bool HaveOppositeDirections(Vector a, Vector b)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		double lengthSquared = ((Vector)(ref a)).LengthSquared;
		double lengthSquared2 = ((Vector)(ref b)).LengthSquared;
		if (lengthSquared >= FloatingPointArithmetic.SquaredDistanceTolerance && lengthSquared2 >= FloatingPointArithmetic.SquaredDistanceTolerance)
		{
			double num = a * b / Math.Sqrt(lengthSquared * lengthSquared2);
			return num < -0.99999;
		}
		return false;
	}

	public static bool ComputeClosestPointOnLineSegment(Point point, Point a, Point b, double toleranceSquared, out double resultParameter, out Point resultPoint, out double resultDistanceSquared)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return ComputeClosestPointOnTransformedLineSegment(point, a, b, Matrix.Identity, toleranceSquared, out resultParameter, out resultPoint, out resultDistanceSquared);
	}

	public static bool IsZero(Vector a)
	{
		return ((Vector)(ref a)).LengthSquared < FloatingPointArithmetic.SquaredDistanceTolerance;
	}

	internal static Vector Scale(Vector start, Vector scale)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		return new Vector(((Vector)(ref start)).X * ((Vector)(ref scale)).X, ((Vector)(ref start)).Y * ((Vector)(ref scale)).Y);
	}

	internal static Vector InvertScale(Vector scale)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return new Vector((((Vector)(ref scale)).X == 0.0) ? 0.0 : (1.0 / ((Vector)(ref scale)).X), (((Vector)(ref scale)).Y == 0.0) ? 0.0 : (1.0 / ((Vector)(ref scale)).Y));
	}

	internal static Vector RemoveMirror(Vector currentScale)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Vector(Math.Abs(((Vector)(ref currentScale)).X), Math.Abs(((Vector)(ref currentScale)).Y));
	}

	internal static Rect Scale(Vector vector, Rect rect)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Matrix val = default(Matrix);
		((Matrix)(ref val))._002Ector(((Vector)(ref vector)).X, 0.0, 0.0, ((Vector)(ref vector)).Y, 0.0, 0.0);
		Rect result = default(Rect);
		((Rect)(ref result))._002Ector(((Rect)(ref rect)).TopLeft * val, ((Rect)(ref rect)).BottomRight * val);
		return result;
	}
}
