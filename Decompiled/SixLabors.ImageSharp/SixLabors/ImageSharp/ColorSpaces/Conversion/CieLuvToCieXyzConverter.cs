using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLuvToCieXyzConverter
{
	public static CieXyz Convert(in CieLuv input)
	{
		float l = input.L;
		float u = input.U;
		float v = input.V;
		float num = ComputeU0(input.WhitePoint);
		float num2 = ComputeV0(input.WhitePoint);
		float num3 = ((l > 8.000001f) ? Numerics.Pow3((l + 16f) / 116f) : (l / 903.2963f));
		float num4 = (52f * l / (u + 13f * l * num) - 1f) / 3f;
		float num5 = -5f * num3;
		float num6 = (num3 * (39f * l / (v + 13f * l * num2) - 5f) - num5) / (num4 - -0.3333333f);
		float num7 = num6 * num4 + num5;
		if (float.IsNaN(num6) || num6 < 0f)
		{
			num6 = 0f;
		}
		if (float.IsNaN(num3) || num3 < 0f)
		{
			num3 = 0f;
		}
		if (float.IsNaN(num7) || num7 < 0f)
		{
			num7 = 0f;
		}
		return new CieXyz(num6, num3, num7);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float ComputeU0(in CieXyz input)
	{
		return 4f * input.X / (input.X + 15f * input.Y + 3f * input.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float ComputeV0(in CieXyz input)
	{
		return 9f * input.Y / (input.X + 15f * input.Y + 3f * input.Z);
	}
}
