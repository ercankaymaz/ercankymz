using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.ColorSpaces.Companding;

public static class SRgbCompanding
{
	private const int Length = 65537;

	private const int Scale = 65535;

	private static readonly Lazy<float[]> LazyCompressTable = new Lazy<float[]>(delegate
	{
		float[] array = new float[65537];
		for (int i = 0; i < array.Length; i++)
		{
			double num = (double)i / 65535.0;
			num = ((!(num <= 0.0031308049535603713)) ? (1.055 * Math.Pow(num, 5.0 / 12.0) - 0.055) : (num * 12.92));
			array[i] = (float)num;
		}
		return array;
	}, isThreadSafe: true);

	private static readonly Lazy<float[]> LazyExpandTable = new Lazy<float[]>(delegate
	{
		float[] array = new float[65537];
		for (int i = 0; i < array.Length; i++)
		{
			double num = (double)i / 65535.0;
			num = ((!(num <= 0.04045)) ? Math.Pow((num + 0.055) / 1.055, 2.4) : (num / 12.92));
			array[i] = (float)num;
		}
		return array;
	}, isThreadSafe: true);

	private static float[] ExpandTable => LazyExpandTable.Value;

	private static float[] CompressTable => LazyCompressTable.Value;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Expand(Span<Vector4> vectors)
	{
		if (Avx2.IsSupported && vectors.Length >= 2)
		{
			CompandAvx2(vectors, ExpandTable);
			if (Numerics.Modulo2(vectors.Length) != 0)
			{
				int length = vectors.Length;
				int num = length - 1;
				Expand(ref MemoryMarshal.GetReference<Vector4>(vectors.Slice(num, length - num)));
			}
		}
		else
		{
			CompandScalar(vectors, ExpandTable);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Compress(Span<Vector4> vectors)
	{
		if (Avx2.IsSupported && vectors.Length >= 2)
		{
			CompandAvx2(vectors, CompressTable);
			if (Numerics.Modulo2(vectors.Length) != 0)
			{
				int length = vectors.Length;
				int num = length - 1;
				Compress(ref MemoryMarshal.GetReference<Vector4>(vectors.Slice(num, length - num)));
			}
		}
		else
		{
			CompandScalar(vectors, CompressTable);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Expand(ref Vector4 vector)
	{
		vector.X = Expand(vector.X);
		vector.Y = Expand(vector.Y);
		vector.Z = Expand(vector.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Compress(ref Vector4 vector)
	{
		vector.X = Compress(vector.X);
		vector.Y = Compress(vector.Y);
		vector.Z = Compress(vector.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Expand(float channel)
	{
		if (!(channel <= 0.04045f))
		{
			return MathF.Pow((channel + 0.055f) / 1.055f, 2.4f);
		}
		return channel / 12.92f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Compress(float channel)
	{
		if (!(channel <= 0.0031308f))
		{
			return 1.055f * MathF.Pow(channel, 5f / 12f) - 0.055f;
		}
		return 12.92f * channel;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void CompandAvx2(Span<Vector4> vectors, float[] table)
	{
		fixed (float* arrayDataReference = &MemoryMarshal.GetArrayDataReference<float>(table))
		{
			Vector256<float> vector = Vector256.Create(65535f);
			Vector256<float> zero = Vector256<float>.Zero;
			Vector256<int> right = Vector256.Create(1);
			ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(vectors));
			ref Vector256<float> right2 = ref Unsafe.Add(ref reference, (uint)vectors.Length / 2u);
			while (Unsafe.IsAddressLessThan(ref reference, ref right2))
			{
				Vector256<float> right3 = Avx.Multiply(vector, reference);
				right3 = Avx.Min(Avx.Max(zero, right3), vector);
				Vector256<int> vector2 = Avx.ConvertToVector256Int32WithTruncation(right3);
				Vector256<float> right4 = Avx.ConvertToVector256Single(vector2);
				Vector256<float> left = Numerics.Lerp(Avx2.GatherVector256(arrayDataReference, vector2, 4), Avx2.GatherVector256(arrayDataReference, Avx2.Add(vector2, right), 4), Avx.Subtract(right3, right4));
				reference = Avx.Blend(left, reference, 136);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void CompandScalar(Span<Vector4> vectors, float[] table)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		fixed (float* arrayDataReference = &MemoryMarshal.GetArrayDataReference<float>(table))
		{
			Vector4 zero = Vector4.Zero;
			Vector4 max = default(Vector4);
			((Vector4)(ref max))._002Ector(65535f);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(vectors);
			ref Vector4 right = ref Unsafe.Add(ref reference, (uint)vectors.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				Vector4 val = Numerics.Clamp(reference * 65535f, zero, max);
				float x = val.X;
				float y = val.Y;
				float z = val.Z;
				uint num = (uint)x;
				uint num2 = (uint)y;
				uint num3 = (uint)z;
				reference.X = Numerics.Lerp(arrayDataReference[num], arrayDataReference[num + 1], x - (float)(int)num);
				reference.Y = Numerics.Lerp(arrayDataReference[num2], arrayDataReference[num2 + 1], y - (float)(int)num2);
				reference.Z = Numerics.Lerp(arrayDataReference[num3], arrayDataReference[num3 + 1], z - (float)(int)num3);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
