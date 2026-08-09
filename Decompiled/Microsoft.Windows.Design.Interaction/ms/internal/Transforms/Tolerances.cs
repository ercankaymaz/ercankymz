using System;
using System.Windows;

namespace MS.Internal.Transforms;

internal static class Tolerances
{
	private static readonly double ZeroThreshold = 2.220446049250313E-15;

	public static bool NearZero(double d)
	{
		return Math.Abs(d) < ZeroThreshold;
	}

	public static bool NearZero(Vector vector)
	{
		if (NearZero(((Vector)(ref vector)).X))
		{
			return NearZero(((Vector)(ref vector)).Y);
		}
		return false;
	}
}
