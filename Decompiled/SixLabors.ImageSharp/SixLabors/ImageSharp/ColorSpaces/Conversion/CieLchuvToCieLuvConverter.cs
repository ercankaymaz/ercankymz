using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLchuvToCieLuvConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieLuv Convert(in CieLchuv input)
	{
		float l = input.L;
		float c = input.C;
		float x = GeometryUtilities.DegreeToRadian(input.H);
		float u = c * MathF.Cos(x);
		float v = c * MathF.Sin(x);
		return new CieLuv(l, u, v, input.WhitePoint);
	}
}
