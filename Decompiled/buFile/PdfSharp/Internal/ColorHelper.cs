using System;

namespace PdfSharp.Internal;

internal static class ColorHelper
{
	public static float sRgbToScRgb(byte bval)
	{
		float num = (float)(int)bval / 255f;
		if ((double)num <= 0.0)
		{
			return 0f;
		}
		if ((double)num <= 0.04045)
		{
			return num / 12.92f;
		}
		if (num < 1f)
		{
			return (float)Math.Pow(((double)num + 0.055) / 1.055, 2.4);
		}
		return 1f;
	}

	public static byte ScRgbTosRgb(float val)
	{
		if ((double)val <= 0.0)
		{
			return 0;
		}
		if ((double)val <= 0.0031308)
		{
			return (byte)(255f * val * 12.92f + 0.5f);
		}
		if ((double)val < 1.0)
		{
			return (byte)(255f * (1.055f * (float)Math.Pow(val, 5.0 / 12.0) - 0.055f) + 0.5f);
		}
		return byte.MaxValue;
	}
}
