using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLuvToCieLchuvConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieLchuv Convert(in CieLuv input)
	{
		float l = input.L;
		float u = input.U;
		float v = input.V;
		float c = MathF.Sqrt(u * u + v * v);
		float num = GeometryUtilities.RadianToDegree(MathF.Atan2(v, u));
		for (num %= 360f; num < 0f; num += 360f)
		{
		}
		return new CieLchuv(l, c, num, input.WhitePoint);
	}
}
