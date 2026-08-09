using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal static class JpegMathHelper
{
	private static ReadOnlySpan<byte> Log2DeBruijn => new byte[32]
	{
		0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
		16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
		15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
		4, 31
	};

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int RoundToInt32(float value)
	{
		return (int)Math.Round(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short RoundToInt16(float value)
	{
		return (short)Math.Round(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Clamp(int value, int min, int max)
	{
		return Math.Min(Math.Max(value, min), max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Clamp(float value, float min, float max)
	{
		return Math.Min(Math.Max(value, min), max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Log2(uint value)
	{
		return Log2SoftwareFallback(value);
	}

	private static int Log2SoftwareFallback(uint value)
	{
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		return Unsafe.AddByteOffset(ref MemoryMarshal.GetReference(Log2DeBruijn), (IntPtr)(int)(value * 130329821 >> 27));
	}
}
