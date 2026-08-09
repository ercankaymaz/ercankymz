using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal struct JpegBlock8x8F
{
	public const int Size = 64;

	public Vector4 V0L;

	public Vector4 V0R;

	public Vector4 V1L;

	public Vector4 V1R;

	public Vector4 V2L;

	public Vector4 V2R;

	public Vector4 V3L;

	public Vector4 V3R;

	public Vector4 V4L;

	public Vector4 V4R;

	public Vector4 V5L;

	public Vector4 V5R;

	public Vector4 V6L;

	public Vector4 V6R;

	public Vector4 V7L;

	public Vector4 V7R;

	public float this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if ((uint)index >= 64u)
			{
				ThrowArgumentOutOfRangeException("index");
			}
			return Unsafe.Add(ref Unsafe.As<JpegBlock8x8F, float>(ref this), index);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			if ((uint)index >= 64u)
			{
				ThrowArgumentOutOfRangeException("index");
			}
			Unsafe.Add(ref Unsafe.As<JpegBlock8x8F, float>(ref this), index) = value;
		}
	}

	public float this[int x, int y]
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

	public static JpegBlock8x8F operator *(in JpegBlock8x8F block, float value)
	{
		ref JpegBlock8x8F reference = ref Unsafe.AsRef(in block);
		JpegBlock8x8F result = block;
		result.V0L = Vector4.Multiply(reference.V0L, value);
		result.V0R = Vector4.Multiply(reference.V0R, value);
		result.V1L = Vector4.Multiply(reference.V1L, value);
		result.V1R = Vector4.Multiply(reference.V1R, value);
		result.V2L = Vector4.Multiply(reference.V2L, value);
		result.V2R = Vector4.Multiply(reference.V2R, value);
		result.V3L = Vector4.Multiply(reference.V3L, value);
		result.V3R = Vector4.Multiply(reference.V3R, value);
		result.V4L = Vector4.Multiply(reference.V4L, value);
		result.V4R = Vector4.Multiply(reference.V4R, value);
		result.V5L = Vector4.Multiply(reference.V5L, value);
		result.V5R = Vector4.Multiply(reference.V5R, value);
		result.V6L = Vector4.Multiply(reference.V6L, value);
		result.V6R = Vector4.Multiply(reference.V6R, value);
		result.V7L = Vector4.Multiply(reference.V7L, value);
		result.V7R = Vector4.Multiply(reference.V7R, value);
		return result;
	}

	public static JpegBlock8x8F operator /(in JpegBlock8x8F block, float value)
	{
		ref JpegBlock8x8F reference = ref Unsafe.AsRef(in block);
		JpegBlock8x8F result = block;
		result.V0L = Vector4.Divide(reference.V0L, value);
		result.V0R = Vector4.Divide(reference.V0R, value);
		result.V1L = Vector4.Divide(reference.V1L, value);
		result.V1R = Vector4.Divide(reference.V1R, value);
		result.V2L = Vector4.Divide(reference.V2L, value);
		result.V2R = Vector4.Divide(reference.V2R, value);
		result.V3L = Vector4.Divide(reference.V3L, value);
		result.V3R = Vector4.Divide(reference.V3R, value);
		result.V4L = Vector4.Divide(reference.V4L, value);
		result.V4R = Vector4.Divide(reference.V4R, value);
		result.V5L = Vector4.Divide(reference.V5L, value);
		result.V5R = Vector4.Divide(reference.V5R, value);
		result.V6L = Vector4.Divide(reference.V6L, value);
		result.V6R = Vector4.Divide(reference.V6R, value);
		result.V7L = Vector4.Divide(reference.V7L, value);
		result.V7R = Vector4.Divide(reference.V7R, value);
		return result;
	}

	public static JpegBlock8x8F operator +(in JpegBlock8x8F block, float value)
	{
		ref JpegBlock8x8F reference = ref Unsafe.AsRef(in block);
		JpegBlock8x8F result = block;
		Vector4 right = new Vector4(value);
		result.V0L = Vector4.Add(reference.V0L, right);
		result.V0R = Vector4.Add(reference.V0R, right);
		result.V1L = Vector4.Add(reference.V1L, right);
		result.V1R = Vector4.Add(reference.V1R, right);
		result.V2L = Vector4.Add(reference.V2L, right);
		result.V2R = Vector4.Add(reference.V2R, right);
		result.V3L = Vector4.Add(reference.V3L, right);
		result.V3R = Vector4.Add(reference.V3R, right);
		result.V4L = Vector4.Add(reference.V4L, right);
		result.V4R = Vector4.Add(reference.V4R, right);
		result.V5L = Vector4.Add(reference.V5L, right);
		result.V5R = Vector4.Add(reference.V5R, right);
		result.V6L = Vector4.Add(reference.V6L, right);
		result.V6R = Vector4.Add(reference.V6R, right);
		result.V7L = Vector4.Add(reference.V7L, right);
		result.V7R = Vector4.Add(reference.V7R, right);
		return result;
	}

	public static JpegBlock8x8F operator -(in JpegBlock8x8F block, float value)
	{
		ref JpegBlock8x8F reference = ref Unsafe.AsRef(in block);
		JpegBlock8x8F result = block;
		Vector4 right = new Vector4(value);
		result.V0L = Vector4.Subtract(reference.V0L, right);
		result.V0R = Vector4.Subtract(reference.V0R, right);
		result.V1L = Vector4.Subtract(reference.V1L, right);
		result.V1R = Vector4.Subtract(reference.V1R, right);
		result.V2L = Vector4.Subtract(reference.V2L, right);
		result.V2R = Vector4.Subtract(reference.V2R, right);
		result.V3L = Vector4.Subtract(reference.V3L, right);
		result.V3R = Vector4.Subtract(reference.V3R, right);
		result.V4L = Vector4.Subtract(reference.V4L, right);
		result.V4R = Vector4.Subtract(reference.V4R, right);
		result.V5L = Vector4.Subtract(reference.V5L, right);
		result.V5R = Vector4.Subtract(reference.V5R, right);
		result.V6L = Vector4.Subtract(reference.V6L, right);
		result.V6R = Vector4.Subtract(reference.V6R, right);
		result.V7L = Vector4.Subtract(reference.V7L, right);
		result.V7R = Vector4.Subtract(reference.V7R, right);
		return result;
	}

	public void MultiplyInplace(float value)
	{
		V0L *= value;
		V0R *= value;
		V1L *= value;
		V1R *= value;
		V2L *= value;
		V2R *= value;
		V3L *= value;
		V3R *= value;
		V4L *= value;
		V4R *= value;
		V5L *= value;
		V5R *= value;
		V6L *= value;
		V6R *= value;
		V7L *= value;
		V7R *= value;
	}

	public void MultiplyInplace(ref JpegBlock8x8F other)
	{
		V0L *= other.V0L;
		V0R *= other.V0R;
		V1L *= other.V1L;
		V1R *= other.V1R;
		V2L *= other.V2L;
		V2R *= other.V2R;
		V3L *= other.V3L;
		V3R *= other.V3R;
		V4L *= other.V4L;
		V4R *= other.V4R;
		V5L *= other.V5L;
		V5R *= other.V5R;
		V6L *= other.V6L;
		V6R *= other.V6R;
		V7L *= other.V7L;
		V7R *= other.V7R;
	}

	public void AddToAllInplace(Vector4 diff)
	{
		V0L += diff;
		V0R += diff;
		V1L += diff;
		V1R += diff;
		V2L += diff;
		V2R += diff;
		V3L += diff;
		V3R += diff;
		V4L += diff;
		V4R += diff;
		V5L += diff;
		V5R += diff;
		V6L += diff;
		V6R += diff;
		V7L += diff;
		V7R += diff;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void TransposeInto(ref JpegBlock8x8F d)
	{
		d.V0L.X = V0L.X;
		d.V1L.X = V0L.Y;
		d.V2L.X = V0L.Z;
		d.V3L.X = V0L.W;
		d.V4L.X = V0R.X;
		d.V5L.X = V0R.Y;
		d.V6L.X = V0R.Z;
		d.V7L.X = V0R.W;
		d.V0L.Y = V1L.X;
		d.V1L.Y = V1L.Y;
		d.V2L.Y = V1L.Z;
		d.V3L.Y = V1L.W;
		d.V4L.Y = V1R.X;
		d.V5L.Y = V1R.Y;
		d.V6L.Y = V1R.Z;
		d.V7L.Y = V1R.W;
		d.V0L.Z = V2L.X;
		d.V1L.Z = V2L.Y;
		d.V2L.Z = V2L.Z;
		d.V3L.Z = V2L.W;
		d.V4L.Z = V2R.X;
		d.V5L.Z = V2R.Y;
		d.V6L.Z = V2R.Z;
		d.V7L.Z = V2R.W;
		d.V0L.W = V3L.X;
		d.V1L.W = V3L.Y;
		d.V2L.W = V3L.Z;
		d.V3L.W = V3L.W;
		d.V4L.W = V3R.X;
		d.V5L.W = V3R.Y;
		d.V6L.W = V3R.Z;
		d.V7L.W = V3R.W;
		d.V0R.X = V4L.X;
		d.V1R.X = V4L.Y;
		d.V2R.X = V4L.Z;
		d.V3R.X = V4L.W;
		d.V4R.X = V4R.X;
		d.V5R.X = V4R.Y;
		d.V6R.X = V4R.Z;
		d.V7R.X = V4R.W;
		d.V0R.Y = V5L.X;
		d.V1R.Y = V5L.Y;
		d.V2R.Y = V5L.Z;
		d.V3R.Y = V5L.W;
		d.V4R.Y = V5R.X;
		d.V5R.Y = V5R.Y;
		d.V6R.Y = V5R.Z;
		d.V7R.Y = V5R.W;
		d.V0R.Z = V6L.X;
		d.V1R.Z = V6L.Y;
		d.V2R.Z = V6L.Z;
		d.V3R.Z = V6L.W;
		d.V4R.Z = V6R.X;
		d.V5R.Z = V6R.Y;
		d.V6R.Z = V6R.Z;
		d.V7R.Z = V6R.W;
		d.V0R.W = V7L.X;
		d.V1R.W = V7L.Y;
		d.V2R.W = V7L.Z;
		d.V3R.W = V7L.W;
		d.V4R.W = V7R.X;
		d.V5R.W = V7R.Y;
		d.V6R.W = V7R.Z;
		d.V7R.W = V7R.W;
	}

	private static void ThrowArgumentOutOfRangeException(string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName);
	}

	private static void ThrowArgumentException(string message)
	{
		throw new ArgumentException(message);
	}
}
