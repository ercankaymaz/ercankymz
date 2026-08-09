using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLabToCieLchConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieLch Convert(in CieLab input)
	{
		float l = input.L;
		float a = input.A;
		float b = input.B;
		float c = MathF.Sqrt(a * a + b * b);
		float num = GeometryUtilities.RadianToDegree(MathF.Atan2(b, a));
		for (num %= 360f; num < 0f; num += 360f)
		{
		}
		return new CieLch(l, c, num, input.WhitePoint);
	}
}
