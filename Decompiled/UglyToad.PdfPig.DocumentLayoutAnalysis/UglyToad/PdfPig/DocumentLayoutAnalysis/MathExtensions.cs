using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class MathExtensions
{
	public static float Mode(this IEnumerable<float> array)
	{
		if (array == null || !array.Any())
		{
			return float.NaN;
		}
		IOrderedEnumerable<(int, float)> source = from v in array
			group v by v into v
			select (v.Count(), Key: v.Key) into g
			orderby g.Item1 descending
			select g;
		(int, float) tuple = source.First();
		if (source.Count() > 1 && tuple.Item1 == source.ElementAt(1).Item1)
		{
			return float.NaN;
		}
		return tuple.Item2;
	}

	public static double Mode(this IEnumerable<double> array)
	{
		if (array == null || !array.Any())
		{
			return double.NaN;
		}
		IOrderedEnumerable<(int, double)> source = from v in array
			group v by v into v
			select (v.Count(), Key: v.Key) into g
			orderby g.Item1 descending
			select g;
		(int, double) tuple = source.First();
		if (source.Count() > 1 && tuple.Item1 == source.ElementAt(1).Item1)
		{
			return double.NaN;
		}
		return tuple.Item2;
	}

	public static bool AlmostEqualsToZero(this double number, double epsilon = 1E-05)
	{
		if (number > 0.0 - epsilon)
		{
			return number < epsilon;
		}
		return false;
	}

	public static bool AlmostEquals(this double number, double other, double epsilon = 1E-05)
	{
		return (number - other).AlmostEqualsToZero(epsilon);
	}
}
