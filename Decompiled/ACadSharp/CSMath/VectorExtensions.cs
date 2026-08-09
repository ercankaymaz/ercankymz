using System;
using System.Collections.Generic;

namespace CSMath;

public static class VectorExtensions
{
	public static T Add<T>(this T left, T right) where T : IVector, new()
	{
		return left.applyFunctionByComponentIndex(right, (double o, double x) => o + x);
	}

	public static double AngleBetweenVectors<T>(this T v, T u) where T : IVector, new()
	{
		if (v.IsZero() || u.IsZero())
		{
			throw new InvalidOperationException("Cannot calculate the angle between two vectors, if one is zero.");
		}
		return Math.Acos(v.Dot(u) / (v.GetLength() * u.GetLength()));
	}

	public static T Convert<T>(this IVector v) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < Math.Min(result.Dimension, v.Dimension); i++)
		{
			result[i] = v[i];
		}
		return result;
	}

	public static T CopyValues<T>(this T v, IVector source) where T : IVector, new()
	{
		for (int i = 0; i < Math.Min(v.Dimension, source.Dimension); i++)
		{
			v[i] = source[i];
		}
		return v;
	}

	public static double DistanceFrom<T>(this T v, T u) where T : IVector, new()
	{
		return v.Subtract(u).GetLength();
	}

	public static T Divide<T>(this T left, T right) where T : IVector, new()
	{
		return left.applyFunctionByComponentIndex(right, (double o, double x) => o / x);
	}

	public static T Divide<T>(this T left, double scalar) where T : IVector, new()
	{
		return left.applyFunctionByScalar(scalar, (double o, double x) => o / x);
	}

	public static double Dot<T>(this T left, T right) where T : IVector
	{
		double num = 0.0;
		for (int i = 0; i < left.Dimension; i++)
		{
			num += left[i] * right[i];
		}
		return num;
	}

	public static double GetLength<T>(this T vector) where T : IVector
	{
		return Math.Sqrt(vector.GetLengthSquared());
	}

	public static double GetLengthSquared<T>(this T vector) where T : IVector
	{
		double num = 0.0;
		for (int i = 0; i < vector.Dimension; i++)
		{
			num += Math.Pow(vector[i], 2.0);
		}
		return num;
	}

	public static bool IsEqual<T>(this T left, T right) where T : IVector
	{
		for (int i = 0; i < left.Dimension; i++)
		{
			if (left[i] != right[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsEqual<T>(this T left, T right, int ndecimals) where T : IVector
	{
		for (int i = 0; i < left.Dimension; i++)
		{
			if (Math.Round(left[i], ndecimals) != Math.Round(right[i], ndecimals))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsNaN<T>(this T v) where T : IVector
	{
		for (int i = 0; i < v.Dimension; i++)
		{
			if (double.IsNaN(v[i]))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsNormalized<T>(this T v) where T : IVector
	{
		return v.GetLength() == 1.0;
	}

	public static bool IsParallel<T>(this T left, T right) where T : IVector
	{
		if (left.IsZero() || right.IsZero())
		{
			return false;
		}
		double obj = 0.0;
		for (int i = 0; i < left.Dimension; i++)
		{
			if (i == 0)
			{
				obj = right[i] / left[i];
			}
			else if (!(right[i] / left[i]).Equals(obj))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsPerpendicular<T>(this T left, T right) where T : IVector
	{
		return left.Dot(right) == 0.0;
	}

	public static bool IsZero<T>(this T v) where T : IVector
	{
		return v.GetLength() == 0.0;
	}

	public static T Mid<T>(this T start, T end) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < start.Dimension; i++)
		{
			result[i] = (start[i] + end[i]) * 0.5;
		}
		return result;
	}

	public static T Multiply<T>(this T left, T right) where T : IVector, new()
	{
		return left.applyFunctionByComponentIndex(right, (double o, double x) => o * x);
	}

	public static T Multiply<T>(this T left, double scalar) where T : IVector, new()
	{
		return left.applyFunctionByScalar(scalar, (double o, double x) => o * x);
	}

	public static T Normalize<T>(this T vector) where T : IVector, new()
	{
		double length = vector.GetLength();
		T result = new T();
		for (int i = 0; i < result.Dimension; i++)
		{
			result[i] = vector[i] / length;
		}
		return result;
	}

	public static T Round<T>(this T vector) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < result.Dimension; i++)
		{
			result[i] = Math.Round(vector[i]);
		}
		return result;
	}

	public static T Round<T>(this T vector, int digits) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < result.Dimension; i++)
		{
			result[i] = Math.Round(vector[i], digits);
		}
		return result;
	}

	public static T RoundZero<T>(this T vector, double threshold = 1E-12) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < result.Dimension; i++)
		{
			result[i] = (MathHelper.IsZero(vector[i], threshold) ? 0.0 : vector[i]);
		}
		return result;
	}

	public static T Subtract<T>(this T left, T right) where T : IVector, new()
	{
		return left.applyFunctionByComponentIndex(right, (double o, double x) => o - x);
	}

	public static IEnumerable<double> ToEnumerable<T>(this T v) where T : IVector
	{
		for (int i = 0; i < v.Dimension; i++)
		{
			yield return v[i];
		}
	}

	private static T applyFunctionByComponentIndex<T>(this T left, T right, Func<double, double, double> op) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < left.Dimension; i++)
		{
			result[i] = op(left[i], right[i]);
		}
		return result;
	}

	private static T applyFunctionByScalar<T>(this T v, double scalar, Func<double, double, double> op) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < v.Dimension; i++)
		{
			result[i] = op(v[i], scalar);
		}
		return result;
	}
}
