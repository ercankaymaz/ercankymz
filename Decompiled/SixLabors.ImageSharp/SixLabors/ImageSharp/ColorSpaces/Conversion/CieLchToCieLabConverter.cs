using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLchToCieLabConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieLab Convert(in CieLch input)
	{
		float l = input.L;
		float c = input.C;
		float x = GeometryUtilities.DegreeToRadian(input.H);
		float a = c * MathF.Cos(x);
		float b = c * MathF.Sin(x);
		return new CieLab(l, a, b, input.WhitePoint);
	}
}
