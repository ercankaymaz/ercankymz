using System.Numerics;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal static class FastFloatingPointDCT
{
	private const float C_1_175876 = 1.1758755f;

	private const float C_1_961571 = -1.9615705f;

	private const float C_0_390181 = -0.39018065f;

	private const float C_0_899976 = -0.8999762f;

	private const float C_2_562915 = -2.5629156f;

	private const float C_0_298631 = 0.29863134f;

	private const float C_2_053120 = 2.05312f;

	private const float C_3_072711 = 3.072711f;

	private const float C_1_501321 = 1.5013211f;

	private const float C_0_541196 = 0.5411961f;

	private const float C_1_847759 = -1.847759f;

	private const float C_0_765367 = 0.76536685f;

	private const float C_0_125 = 0.125f;

	private static readonly Vector4 InvSqrt2 = new Vector4(0.707107f);

	public static void TransformIDCT(ref JpegBlock8x8F src, ref JpegBlock8x8F dest, ref JpegBlock8x8F temp)
	{
		src.TransposeInto(ref temp);
		IDCT8x4_LeftPart(ref temp, ref dest);
		IDCT8x4_RightPart(ref temp, ref dest);
		dest.TransposeInto(ref temp);
		IDCT8x4_LeftPart(ref temp, ref dest);
		IDCT8x4_RightPart(ref temp, ref dest);
		dest.MultiplyInplace(0.125f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void IDCT8x4_LeftPart(ref JpegBlock8x8F s, ref JpegBlock8x8F d)
	{
		Vector4 v1L = s.V1L;
		Vector4 v7L = s.V7L;
		Vector4 vector = v1L + v7L;
		Vector4 v3L = s.V3L;
		Vector4 vector2 = v3L + v7L;
		Vector4 v5L = s.V5L;
		Vector4 vector3 = v3L + v5L;
		Vector4 vector4 = v1L + v5L;
		Vector4 vector5 = (vector + vector3) * 1.1758755f;
		vector2 = vector2 * -1.9615705f + vector5;
		vector4 = vector4 * -0.39018065f + vector5;
		vector *= -0.8999762f;
		vector3 *= -2.5629156f;
		Vector4 vector6 = v7L * 0.29863134f + vector + vector2;
		Vector4 vector7 = v5L * 2.05312f + vector3 + vector4;
		Vector4 vector8 = v3L * 3.072711f + vector3 + vector2;
		Vector4 vector9 = v1L * 1.5013211f + vector + vector4;
		Vector4 v2L = s.V2L;
		Vector4 v6L = s.V6L;
		vector5 = (v2L + v6L) * 0.5411961f;
		Vector4 v0L = s.V0L;
		Vector4 v4L = s.V4L;
		vector = v0L + v4L;
		vector3 = v0L - v4L;
		vector2 = vector5 + v6L * -1.847759f;
		vector4 = vector5 + v2L * 0.76536685f;
		v0L = vector + vector4;
		v3L = vector - vector4;
		v1L = vector3 + vector2;
		v2L = vector3 - vector2;
		d.V0L = v0L + vector9;
		d.V7L = v0L - vector9;
		d.V1L = v1L + vector8;
		d.V6L = v1L - vector8;
		d.V2L = v2L + vector7;
		d.V5L = v2L - vector7;
		d.V3L = v3L + vector6;
		d.V4L = v3L - vector6;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void IDCT8x4_RightPart(ref JpegBlock8x8F s, ref JpegBlock8x8F d)
	{
		Vector4 v1R = s.V1R;
		Vector4 v7R = s.V7R;
		Vector4 vector = v1R + v7R;
		Vector4 v3R = s.V3R;
		Vector4 vector2 = v3R + v7R;
		Vector4 v5R = s.V5R;
		Vector4 vector3 = v3R + v5R;
		Vector4 vector4 = v1R + v5R;
		Vector4 vector5 = (vector + vector3) * 1.1758755f;
		vector2 = vector2 * -1.9615705f + vector5;
		vector4 = vector4 * -0.39018065f + vector5;
		vector *= -0.8999762f;
		vector3 *= -2.5629156f;
		Vector4 vector6 = v7R * 0.29863134f + vector + vector2;
		Vector4 vector7 = v5R * 2.05312f + vector3 + vector4;
		Vector4 vector8 = v3R * 3.072711f + vector3 + vector2;
		Vector4 vector9 = v1R * 1.5013211f + vector + vector4;
		Vector4 v2R = s.V2R;
		Vector4 v6R = s.V6R;
		vector5 = (v2R + v6R) * 0.5411961f;
		Vector4 v0R = s.V0R;
		Vector4 v4R = s.V4R;
		vector = v0R + v4R;
		vector3 = v0R - v4R;
		vector2 = vector5 + v6R * -1.847759f;
		vector4 = vector5 + v2R * 0.76536685f;
		v0R = vector + vector4;
		v3R = vector - vector4;
		v1R = vector3 + vector2;
		v2R = vector3 - vector2;
		d.V0R = v0R + vector9;
		d.V7R = v0R - vector9;
		d.V1R = v1R + vector8;
		d.V6R = v1R - vector8;
		d.V2R = v2R + vector7;
		d.V5R = v2R - vector7;
		d.V3R = v3R + vector6;
		d.V4R = v3R - vector6;
	}

	public static void FDCT8x4_LeftPart(ref JpegBlock8x8F s, ref JpegBlock8x8F d)
	{
		Vector4 v0L = s.V0L;
		Vector4 v7L = s.V7L;
		Vector4 vector = v0L + v7L;
		Vector4 vector2 = v0L - v7L;
		v7L = s.V6L;
		v0L = s.V1L;
		Vector4 vector3 = v0L + v7L;
		Vector4 vector4 = v0L - v7L;
		v7L = s.V5L;
		v0L = s.V2L;
		Vector4 vector5 = v0L + v7L;
		Vector4 vector6 = v0L - v7L;
		v0L = s.V3L;
		v7L = s.V4L;
		Vector4 vector7 = v0L + v7L;
		Vector4 vector8 = v0L - v7L;
		v0L = vector + vector7;
		Vector4 vector9 = vector - vector7;
		v7L = vector3 + vector5;
		Vector4 vector10 = vector3 - vector5;
		d.V0L = v0L + v7L;
		d.V4L = v0L - v7L;
		float num = 0.541196f;
		float num2 = 1.306563f;
		d.V2L = num * vector10 + num2 * vector9;
		d.V6L = num * vector9 - num2 * vector10;
		num = 1.175876f;
		num2 = 0.785695f;
		vector9 = num * vector8 + num2 * vector2;
		v0L = num * vector2 - num2 * vector8;
		num = 1.38704f;
		num2 = 0.275899f;
		vector10 = num * vector6 + num2 * vector4;
		v7L = num * vector4 - num2 * vector6;
		d.V3L = v0L - vector10;
		d.V5L = vector9 - v7L;
		float num3 = 0.707107f;
		v0L = (v0L + vector10) * num3;
		vector9 = (vector9 + v7L) * num3;
		d.V1L = v0L + vector9;
		d.V7L = v0L - vector9;
	}

	public static void FDCT8x4_RightPart(ref JpegBlock8x8F s, ref JpegBlock8x8F d)
	{
		Vector4 v0R = s.V0R;
		Vector4 v7R = s.V7R;
		Vector4 vector = v0R + v7R;
		Vector4 vector2 = v0R - v7R;
		v7R = s.V6R;
		v0R = s.V1R;
		Vector4 vector3 = v0R + v7R;
		Vector4 vector4 = v0R - v7R;
		v7R = s.V5R;
		v0R = s.V2R;
		Vector4 vector5 = v0R + v7R;
		Vector4 vector6 = v0R - v7R;
		v0R = s.V3R;
		v7R = s.V4R;
		Vector4 vector7 = v0R + v7R;
		Vector4 vector8 = v0R - v7R;
		v0R = vector + vector7;
		Vector4 vector9 = vector - vector7;
		v7R = vector3 + vector5;
		Vector4 vector10 = vector3 - vector5;
		d.V0R = v0R + v7R;
		d.V4R = v0R - v7R;
		float num = 0.541196f;
		float num2 = 1.306563f;
		d.V2R = num * vector10 + num2 * vector9;
		d.V6R = num * vector9 - num2 * vector10;
		num = 1.175876f;
		num2 = 0.785695f;
		vector9 = num * vector8 + num2 * vector2;
		v0R = num * vector2 - num2 * vector8;
		num = 1.38704f;
		num2 = 0.275899f;
		vector10 = num * vector6 + num2 * vector4;
		v7R = num * vector4 - num2 * vector6;
		d.V3R = v0R - vector10;
		d.V5R = vector9 - v7R;
		v0R = (v0R + vector10) * InvSqrt2;
		vector9 = (vector9 + v7R) * InvSqrt2;
		d.V1R = v0R + vector9;
		d.V7R = v0R - vector9;
	}

	public static void TransformFDCT(ref JpegBlock8x8F src, ref JpegBlock8x8F dest, ref JpegBlock8x8F temp, bool offsetSourceByNeg128)
	{
		src.TransposeInto(ref temp);
		if (offsetSourceByNeg128)
		{
			temp.AddToAllInplace(new Vector4(-128f));
		}
		FDCT8x4_LeftPart(ref temp, ref dest);
		FDCT8x4_RightPart(ref temp, ref dest);
		dest.TransposeInto(ref temp);
		FDCT8x4_LeftPart(ref temp, ref dest);
		FDCT8x4_RightPart(ref temp, ref dest);
		dest.MultiplyInplace(0.125f);
	}

	public static void TransformFDCT(ref JpegBlock8x8F src, ref JpegBlock8x8F dest, ref JpegBlock8x8F temp)
	{
		src.TransposeInto(ref temp);
		FDCT8x4_LeftPart(ref temp, ref dest);
		FDCT8x4_RightPart(ref temp, ref dest);
		dest.TransposeInto(ref temp);
		FDCT8x4_LeftPart(ref temp, ref dest);
		FDCT8x4_RightPart(ref temp, ref dest);
		dest.MultiplyInplace(0.125f);
	}
}
