using System;

namespace ScintillaNET;

internal class ColorSpace
{
	public static float SrgbToLinearSrgb(float x)
	{
		if (!((double)x >= 0.04045))
		{
			return x / 12.92f;
		}
		return (float)Math.Pow((x + 0.055f) / 1.055f, 2.4000000953674316);
	}

	public static float LinearSrgbToSrgb(float x)
	{
		if (!((double)x >= 0.0031308))
		{
			return 12.92f * x;
		}
		return 1.055f * (float)Math.Pow(x, 5.0 / 12.0) - 0.055f;
	}
}
