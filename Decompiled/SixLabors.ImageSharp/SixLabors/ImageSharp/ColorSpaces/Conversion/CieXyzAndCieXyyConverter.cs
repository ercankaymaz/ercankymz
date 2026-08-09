using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieXyzAndCieXyyConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieXyy Convert(in CieXyz input)
	{
		float num = input.X / (input.X + input.Y + input.Z);
		float num2 = input.Y / (input.X + input.Y + input.Z);
		if (float.IsNaN(num) || float.IsNaN(num2))
		{
			return new CieXyy(0f, 0f, input.Y);
		}
		return new CieXyy(num, num2, input.Y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieXyz Convert(in CieXyy input)
	{
		if (MathF.Abs(input.Y) < Constants.Epsilon)
		{
			return new CieXyz(0f, 0f, input.Yl);
		}
		float x = input.X * input.Yl / input.Y;
		float yl = input.Yl;
		float z = (1f - input.X - input.Y) * yl / input.Y;
		return new CieXyz(x, yl, z);
	}
}
