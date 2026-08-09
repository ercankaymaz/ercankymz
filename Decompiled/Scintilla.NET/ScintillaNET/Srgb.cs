using System;
using System.Drawing;

namespace ScintillaNET;

internal struct Srgb(float R, float G, float B)
{
	public float R = R;

	public float G = G;

	public float B = B;

	public readonly OkLab ToOkLab()
	{
		float num = 0.41222146f * R + 0.53633255f * G + 0.051445995f * B;
		float num2 = 0.2119035f * R + 0.6806995f * G + 0.10739696f * B;
		float num3 = 0.08830246f * R + 0.28171885f * G + 0.6299787f * B;
		float num4 = (float)Math.Pow(num, 1.0 / 3.0);
		float num5 = (float)Math.Pow(num2, 1.0 / 3.0);
		float num6 = (float)Math.Pow(num3, 1.0 / 3.0);
		return new OkLab(0.21045426f * num4 + 0.7936178f * num5 - 0.004072047f * num6, 1.9779985f * num4 - 2.4285922f * num5 + 0.4505937f * num6, 0.025904037f * num4 + 0.78277177f * num5 - 0.80867577f * num6);
	}

	public static Srgb FromColor(Color c)
	{
		return new Srgb((float)(int)c.R / 255f, (float)(int)c.G / 255f, (float)(int)c.B / 255f);
	}

	public readonly Color ToColor()
	{
		return Color.FromArgb((byte)(R * 255f), (byte)(G * 255f), (byte)(B * 255f));
	}

	public readonly Srgb ToLinearSrgb()
	{
		return new Srgb(Helpers.Clamp(ColorSpace.SrgbToLinearSrgb(R), 0f, 1f), Helpers.Clamp(ColorSpace.SrgbToLinearSrgb(G), 0f, 1f), Helpers.Clamp(ColorSpace.SrgbToLinearSrgb(B), 0f, 1f));
	}

	public readonly Srgb ToSrgb()
	{
		return new Srgb(Helpers.Clamp(ColorSpace.LinearSrgbToSrgb(R), 0f, 1f), Helpers.Clamp(ColorSpace.LinearSrgbToSrgb(G), 0f, 1f), Helpers.Clamp(ColorSpace.LinearSrgbToSrgb(B), 0f, 1f));
	}

	public override readonly string ToString()
	{
		return FormattableString.Invariant($"(R:{R}, G:{G}, B:{B})");
	}
}
