using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Processing.Processors.Transforms;

internal readonly struct ResizeKernel
{
	private unsafe readonly float* bufferPtr;

	public int StartIndex
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public int Length
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public unsafe Span<float> Values
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return new Span<float>(bufferPtr, Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe ResizeKernel(int startIndex, float* bufferPtr, int length)
	{
		StartIndex = startIndex;
		this.bufferPtr = bufferPtr;
		Length = length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Vector4 Convolve(Span<Vector4> rowSpan)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return ConvolveCore(ref rowSpan[StartIndex]);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe Vector4 ConvolveCore(ref Vector4 rowStartRef)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		if (Avx2.IsSupported && Fma.IsSupported)
		{
			float* ptr = bufferPtr;
			float* ptr2 = ptr + (Length & -4);
			Vector256<float> vector = Vector256<float>.Zero;
			Vector256<float> vector2 = Vector256<float>.Zero;
			Vector256<int> control = Unsafe.ReadUnaligned<Vector256<int>>(ref MemoryMarshal.GetReference<byte>((ReadOnlySpan<byte>)new byte[32]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
				1, 0, 0, 0, 1, 0, 0, 0, 1, 0,
				0, 0
			}));
			while (ptr < ptr2)
			{
				vector = Fma.MultiplyAdd(Unsafe.As<Vector4, Vector256<float>>(ref rowStartRef), Avx2.PermuteVar8x32(Vector256.CreateScalarUnsafe(*(double*)ptr).AsSingle(), control), vector);
				vector2 = Fma.MultiplyAdd(Unsafe.As<Vector4, Vector256<float>>(ref Unsafe.Add(ref rowStartRef, 2)), Avx2.PermuteVar8x32(Vector256.CreateScalarUnsafe(*(double*)(ptr + 2)).AsSingle(), control), vector2);
				ptr += 4;
				rowStartRef = ref Unsafe.Add(ref rowStartRef, 4);
			}
			vector = Avx.Add(vector, vector2);
			if ((Length & 3) >= 2)
			{
				vector = Fma.MultiplyAdd(Unsafe.As<Vector4, Vector256<float>>(ref rowStartRef), Avx2.PermuteVar8x32(Vector256.CreateScalarUnsafe(*(double*)ptr).AsSingle(), control), vector);
				ptr += 2;
				rowStartRef = ref Unsafe.Add(ref rowStartRef, 2);
			}
			Vector128<float> c = Sse.Add(vector.GetLower(), vector.GetUpper());
			if ((Length & 1) != 0)
			{
				c = Fma.MultiplyAdd(Unsafe.As<Vector4, Vector128<float>>(ref rowStartRef), Vector128.Create(*ptr), c);
			}
			return (Vector4)c;
		}
		Vector4 val = Vector4.Zero;
		float* ptr3 = bufferPtr;
		float* ptr4 = bufferPtr + Length;
		while (ptr3 < ptr4)
		{
			val += rowStartRef * *ptr3;
			ptr3++;
			rowStartRef = ref Unsafe.Add(ref rowStartRef, 1);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe ResizeKernel AlterLeftValue(int left)
	{
		return new ResizeKernel(left, bufferPtr, Length);
	}

	internal void Fill(Span<double> values)
	{
		for (int i = 0; i < Length; i++)
		{
			Values[i] = (float)values[i];
		}
	}
}
