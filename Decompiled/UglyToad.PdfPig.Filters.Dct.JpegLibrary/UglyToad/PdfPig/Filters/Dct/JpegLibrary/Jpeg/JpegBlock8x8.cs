using System;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

public struct JpegBlock8x8
{
	private unsafe fixed short _data[64];

	public short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if ((uint)index >= 64u)
			{
				ThrowArgumentOutOfRangeException("index");
			}
			return Unsafe.Add(ref Unsafe.As<JpegBlock8x8, short>(ref this), index);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			if ((uint)index >= 64u)
			{
				ThrowArgumentOutOfRangeException("index");
			}
			Unsafe.Add(ref Unsafe.As<JpegBlock8x8, short>(ref this), index) = value;
		}
	}

	public short this[int x, int y]
	{
		get
		{
			return this[y * 8 + x];
		}
		set
		{
			this[y * 8 + x] = value;
		}
	}

	private static void ThrowArgumentOutOfRangeException(string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName);
	}
}
