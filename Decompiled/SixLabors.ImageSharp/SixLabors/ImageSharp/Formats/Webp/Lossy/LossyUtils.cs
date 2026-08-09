using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal static class LossyUtils
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8_Sse16x16(Span<byte> a, Span<byte> b)
	{
		if (Avx2.IsSupported)
		{
			return Vp8_Sse16xN_Avx2(a, b, 4);
		}
		if (Sse2.IsSupported)
		{
			return Vp8_Sse16xN_Sse2(a, b, 8);
		}
		if (AdvSimd.IsSupported)
		{
			return Vp8_Sse16x16_Neon(a, b);
		}
		return Vp8_SseNxN(a, b, 16, 16);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8_Sse16x8(Span<byte> a, Span<byte> b)
	{
		if (Avx2.IsSupported)
		{
			return Vp8_Sse16xN_Avx2(a, b, 2);
		}
		if (Sse2.IsSupported)
		{
			return Vp8_Sse16xN_Sse2(a, b, 4);
		}
		if (AdvSimd.IsSupported)
		{
			return Vp8_Sse16x8_Neon(a, b);
		}
		return Vp8_SseNxN(a, b, 16, 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8_Sse4x4(Span<byte> a, Span<byte> b)
	{
		if (Avx2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(a);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(b);
			Vector256<byte> vector = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref reference), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, 32)));
			Vector256<byte> vector2 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, 64)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, 96)));
			Vector256<byte> vector3 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref reference2), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, 32)));
			Vector256<byte> vector4 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, 64)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, 96)));
			Vector256<int> vector5 = Avx2.UnpackLow(vector.AsInt32(), vector2.AsInt32());
			Vector256<int> vector6 = Avx2.UnpackLow(vector3.AsInt32(), vector4.AsInt32());
			Vector256<byte> vector7 = Avx2.UnpackLow(vector5.AsByte(), Vector256<byte>.Zero);
			Vector256<byte> vector8 = Avx2.UnpackLow(vector6.AsByte(), Vector256<byte>.Zero);
			Vector256<short> vector9 = Avx2.SubtractSaturate(vector7.AsInt16(), vector8.AsInt16());
			return Numerics.ReduceSum(Avx2.MultiplyAddAdjacent(vector9, vector9));
		}
		if (Sse2.IsSupported)
		{
			ref byte reference3 = ref MemoryMarshal.GetReference<byte>(a);
			ref byte reference4 = ref MemoryMarshal.GetReference<byte>(b);
			Vector128<byte> vector10 = Unsafe.As<byte, Vector128<byte>>(ref reference3);
			Vector128<byte> vector11 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference3, 32));
			Vector128<byte> vector12 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference3, 64));
			Vector128<byte> vector13 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference3, 96));
			Vector128<byte> vector14 = Unsafe.As<byte, Vector128<byte>>(ref reference4);
			Vector128<byte> vector15 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference4, 32));
			Vector128<byte> vector16 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference4, 64));
			Vector128<byte> vector17 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference4, 96));
			Vector128<int> vector18 = Sse2.UnpackLow(vector10.AsInt32(), vector11.AsInt32());
			Vector128<int> vector19 = Sse2.UnpackLow(vector12.AsInt32(), vector13.AsInt32());
			Vector128<int> vector20 = Sse2.UnpackLow(vector14.AsInt32(), vector15.AsInt32());
			Vector128<int> vector21 = Sse2.UnpackLow(vector16.AsInt32(), vector17.AsInt32());
			Vector128<byte> vector22 = Sse2.UnpackLow(vector18.AsByte(), Vector128<byte>.Zero);
			Vector128<byte> vector23 = Sse2.UnpackLow(vector19.AsByte(), Vector128<byte>.Zero);
			Vector128<byte> vector24 = Sse2.UnpackLow(vector20.AsByte(), Vector128<byte>.Zero);
			Vector128<byte> vector25 = Sse2.UnpackLow(vector21.AsByte(), Vector128<byte>.Zero);
			Vector128<short> vector26 = Sse2.SubtractSaturate(vector22.AsInt16(), vector24.AsInt16());
			Vector128<short> vector27 = Sse2.SubtractSaturate(vector23.AsInt16(), vector25.AsInt16());
			Vector128<int> left = Sse2.MultiplyAddAdjacent(vector26, vector26);
			Vector128<int> right = Sse2.MultiplyAddAdjacent(vector27, vector27);
			return Numerics.ReduceSum(Sse2.Add(left, right));
		}
		if (AdvSimd.IsSupported)
		{
			return Vp8_Sse4x4_Neon(a, b);
		}
		return Vp8_SseNxN(a, b, 4, 4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8_SseNxN(Span<byte> a, Span<byte> b, int w, int h)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < h; i++)
		{
			for (int j = 0; j < w; j++)
			{
				int num3 = a[num2 + j] - b[num2 + j];
				num += num3 * num3;
			}
			num2 += 32;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Vp8_Sse16xN_Sse2(Span<byte> a, Span<byte> b, int numPairs)
	{
		Vector128<int> vector = Vector128<int>.Zero;
		nuint num = 0u;
		ref byte reference = ref MemoryMarshal.GetReference<byte>(a);
		ref byte reference2 = ref MemoryMarshal.GetReference<byte>(b);
		for (int i = 0; i < numPairs; i++)
		{
			Vector128<byte> a2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num));
			Vector128<byte> b2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num));
			Vector128<byte> a3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num + 32));
			Vector128<byte> b3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num + 32));
			Vector128<int> left = SubtractAndAccumulate(a2, b2);
			Vector128<int> right = SubtractAndAccumulate(a3, b3);
			vector = Sse2.Add(vector, Sse2.Add(left, right));
			num += 64;
		}
		return Numerics.ReduceSum(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Vp8_Sse16xN_Avx2(Span<byte> a, Span<byte> b, int numPairs)
	{
		Vector256<int> vector = Vector256<int>.Zero;
		nuint num = 0u;
		ref byte reference = ref MemoryMarshal.GetReference<byte>(a);
		ref byte reference2 = ref MemoryMarshal.GetReference<byte>(b);
		for (int i = 0; i < numPairs; i++)
		{
			Vector256<byte> a2 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num + 32)));
			Vector256<byte> b2 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num + 32)));
			Vector256<byte> a3 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num + 64)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, num + 96)));
			Vector256<byte> b3 = Vector256.Create(Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num + 64)), Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference2, num + 96)));
			Vector256<int> left = SubtractAndAccumulate(a2, b2);
			Vector256<int> right = SubtractAndAccumulate(a3, b3);
			vector = Avx2.Add(vector, Avx2.Add(left, right));
			num += 128;
		}
		return Numerics.ReduceSum(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static int Vp8_Sse16x16_Neon(Span<byte> a, Span<byte> b)
	{
		Vector128<uint> vector = Vector128<uint>.Zero;
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(a))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference<byte>(b))
			{
				for (int i = 0; i < 16; i++)
				{
					vector = AccumulateSSE16Neon(reference + i * 32, reference2 + i * 32, vector);
				}
			}
		}
		return Numerics.ReduceSumArm(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static int Vp8_Sse16x8_Neon(Span<byte> a, Span<byte> b)
	{
		Vector128<uint> vector = Vector128<uint>.Zero;
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(a))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference<byte>(b))
			{
				for (int i = 0; i < 8; i++)
				{
					vector = AccumulateSSE16Neon(reference + i * 32, reference2 + i * 32, vector);
				}
			}
		}
		return Numerics.ReduceSumArm(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Vp8_Sse4x4_Neon(Span<byte> a, Span<byte> b)
	{
		Vector128<byte> left = Load4x4Neon(a).AsByte();
		Vector128<byte> right = Load4x4Neon(b).AsByte();
		Vector128<byte> vector = AdvSimd.AbsoluteDifference(left, right);
		Vector64<byte> vector2 = vector.GetLower().AsByte();
		Vector64<byte> vector3 = vector.GetUpper().AsByte();
		Vector128<ushort> value = AdvSimd.MultiplyWideningLower(vector2, vector2);
		Vector128<ushort> value2 = AdvSimd.MultiplyWideningLower(vector3, vector3);
		Vector128<uint> left2 = AdvSimd.AddPairwiseWidening(value);
		Vector128<uint> right2 = AdvSimd.AddPairwiseWidening(value2);
		return Numerics.ReduceSumArm(AdvSimd.Add(left2, right2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static Vector128<uint> Load4x4Neon(Span<byte> src)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(src))
		{
			return AdvSimd.LoadAndInsertScalar(AdvSimd.LoadAndInsertScalar(AdvSimd.LoadAndInsertScalar(AdvSimd.LoadAndInsertScalar(Vector128<uint>.Zero, 0, (uint*)reference), 1, (uint*)reference + 8), 2, (uint*)reference + 16), 3, (uint*)reference + 24);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static Vector128<uint> AccumulateSSE16Neon(byte* a, byte* b, Vector128<uint> sum)
	{
		Vector128<byte> left = AdvSimd.LoadVector128(a);
		Vector128<byte> right = AdvSimd.LoadVector128(b);
		Vector128<byte> vector = AdvSimd.AbsoluteDifference(left, right);
		Vector64<byte> lower = vector.GetLower();
		Vector64<byte> upper = vector.GetUpper();
		Vector128<ushort> value = AdvSimd.MultiplyWideningLower(lower, lower);
		Vector128<ushort> value2 = AdvSimd.MultiplyWideningLower(upper, upper);
		Vector128<uint> left2 = AdvSimd.AddPairwiseWidening(value);
		Vector128<uint> right2 = AdvSimd.AddPairwiseWidening(value2);
		return AdvSimd.Add(sum, AdvSimd.Add(left2, right2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<int> SubtractAndAccumulate(Vector128<byte> a, Vector128<byte> b)
	{
		Vector128<byte> left = Sse2.SubtractSaturate(a, b);
		Vector128<byte> right = Sse2.SubtractSaturate(b, a);
		Vector128<byte> left2 = Sse2.Or(left, right);
		Vector128<byte> vector = Sse2.UnpackLow(left2, Vector128<byte>.Zero);
		Vector128<byte> vector2 = Sse2.UnpackHigh(left2, Vector128<byte>.Zero);
		Vector128<int> left3 = Sse2.MultiplyAddAdjacent(vector.AsInt16(), vector.AsInt16());
		Vector128<int> right2 = Sse2.MultiplyAddAdjacent(vector2.AsInt16(), vector2.AsInt16());
		return Sse2.Add(left3, right2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector256<int> SubtractAndAccumulate(Vector256<byte> a, Vector256<byte> b)
	{
		Vector256<byte> left = Avx2.SubtractSaturate(a, b);
		Vector256<byte> right = Avx2.SubtractSaturate(b, a);
		Vector256<byte> left2 = Avx2.Or(left, right);
		Vector256<byte> vector = Avx2.UnpackLow(left2, Vector256<byte>.Zero);
		Vector256<byte> vector2 = Avx2.UnpackHigh(left2, Vector256<byte>.Zero);
		Vector256<int> left3 = Avx2.MultiplyAddAdjacent(vector.AsInt16(), vector.AsInt16());
		Vector256<int> right2 = Avx2.MultiplyAddAdjacent(vector2.AsInt16(), vector2.AsInt16());
		return Avx2.Add(left3, right2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Vp8Copy4X4(Span<byte> src, Span<byte> dst)
	{
		Copy(src, dst, 4, 4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Vp8Copy16X8(Span<byte> src, Span<byte> dst)
	{
		Copy(src, dst, 16, 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Copy(Span<byte> src, Span<byte> dst, int w, int h)
	{
		int num = 0;
		for (int i = 0; i < h; i++)
		{
			src.Slice(num, w).CopyTo(dst.Slice(num, w));
			num += 32;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8Disto16X16(Span<byte> a, Span<byte> b, Span<ushort> w, Span<int> scratch)
	{
		int num = 0;
		for (int i = 0; i < 512; i += 128)
		{
			for (int j = 0; j < 16; j += 4)
			{
				num += Vp8Disto4X4(a.Slice(j + i, 112), b.Slice(j + i, 112), w, scratch);
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Vp8Disto4X4(Span<byte> a, Span<byte> b, Span<ushort> w, Span<int> scratch)
	{
		if (Sse41.IsSupported)
		{
			return Math.Abs(TTransformSse41(a, b, w)) >> 5;
		}
		int num = TTransform(a, w, scratch);
		return Math.Abs(TTransform(b, w, scratch) - num) >> 5;
	}

	public static void DC16(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = offset - 1;
		int num2 = offset - 32;
		int num3 = 16;
		for (int i = 0; i < 16; i++)
		{
			num3 += yuv[num + i * 32] + yuv[num2 + i];
		}
		Put16(num3 >> 5, dst);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TM16(Span<byte> dst, Span<byte> yuv, int offset)
	{
		TrueMotion(dst, yuv, offset, 16);
	}

	public static void VE16(Span<byte> dst, Span<byte> yuv, int offset)
	{
		Span<byte> span = yuv.Slice(offset - 32, 16);
		for (int i = 0; i < 16; i++)
		{
			int num = i * 32;
			span.CopyTo(dst.Slice(num, dst.Length - num));
		}
	}

	public static void HE16(Span<byte> dst, Span<byte> yuv, int offset)
	{
		offset--;
		for (int num = 16; num > 0; num--)
		{
			byte value = yuv[offset];
			Memset(dst, value, 0, 16);
			offset += 32;
			dst = dst.Slice(32, dst.Length - 32);
		}
	}

	public static void DC16NoTop(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = 8;
		for (int i = 0; i < 16; i++)
		{
			num += yuv[-1 + i * 32 + offset];
		}
		Put16(num >> 4, dst);
	}

	public static void DC16NoLeft(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = 8;
		for (int i = 0; i < 16; i++)
		{
			num += yuv[i - 32 + offset];
		}
		Put16(num >> 4, dst);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DC16NoTopLeft(Span<byte> dst)
	{
		Put16(128, dst);
	}

	public static void DC8uv(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = 8;
		int num2 = offset - 1;
		int num3 = offset - 32;
		for (int i = 0; i < 8; i++)
		{
			num += yuv[num3 + i] + yuv[num2 + i * 32];
		}
		Put8x8uv((byte)(num >> 4), dst);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TM8uv(Span<byte> dst, Span<byte> yuv, int offset)
	{
		TrueMotion(dst, yuv, offset, 8);
	}

	public static void VE8uv(Span<byte> dst, Span<byte> yuv, int offset)
	{
		Span<byte> span = yuv.Slice(offset - 32, 8);
		for (int i = 0; i < 256; i += 32)
		{
			int num = i;
			span.CopyTo(dst.Slice(num, dst.Length - num));
		}
	}

	public static void HE8uv(Span<byte> dst, Span<byte> yuv, int offset)
	{
		offset--;
		for (int i = 0; i < 8; i++)
		{
			byte value = yuv[offset];
			Memset(dst, value, 0, 8);
			dst = dst.Slice(32, dst.Length - 32);
			offset += 32;
		}
	}

	public static void DC8uvNoTop(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = 4;
		int num2 = offset - 1;
		for (int i = 0; i < 256; i += 32)
		{
			num += yuv[num2 + i];
		}
		Put8x8uv((byte)(num >> 3), dst);
	}

	public static void DC8uvNoLeft(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = offset - 32;
		int num2 = 4;
		for (int i = 0; i < 8; i++)
		{
			num2 += yuv[num + i];
		}
		Put8x8uv((byte)(num2 >> 3), dst);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DC8uvNoTopLeft(Span<byte> dst)
	{
		Put8x8uv(128, dst);
	}

	public static void DC4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = 4;
		int num2 = offset - 32;
		int num3 = offset - 1;
		for (int i = 0; i < 4; i++)
		{
			num += yuv[num2 + i] + yuv[num3 + i * 32];
		}
		num >>= 3;
		for (int j = 0; j < 128; j += 32)
		{
			Memset(dst, (byte)num, j, 4);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TM4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		TrueMotion(dst, yuv, offset, 4);
	}

	public static void VE4(Span<byte> dst, Span<byte> yuv, int offset, Span<byte> vals)
	{
		int num = offset - 32;
		vals[0] = Avg3(yuv[num - 1], yuv[num], yuv[num + 1]);
		vals[1] = Avg3(yuv[num], yuv[num + 1], yuv[num + 2]);
		vals[2] = Avg3(yuv[num + 1], yuv[num + 2], yuv[num + 3]);
		vals[3] = Avg3(yuv[num + 2], yuv[num + 3], yuv[num + 4]);
		for (int i = 0; i < 128; i += 32)
		{
			int num2 = i;
			vals.CopyTo(dst.Slice(num2, dst.Length - num2));
		}
	}

	public static void HE4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = offset - 1;
		byte a = yuv[num - 32];
		byte b = yuv[num];
		byte b2 = yuv[num + 32];
		byte b3 = yuv[num + 64];
		byte b4 = yuv[num + 96];
		uint num2 = (uint)(16843009 * Avg3(a, b, b2));
		BinaryPrimitives.WriteUInt32BigEndian(dst, num2);
		num2 = (uint)(16843009 * Avg3(b, b2, b3));
		ref Span<byte> reference = ref dst;
		BinaryPrimitives.WriteUInt32BigEndian(reference.Slice(32, reference.Length - 32), num2);
		num2 = (uint)(16843009 * Avg3(b2, b3, b4));
		reference = ref dst;
		BinaryPrimitives.WriteUInt32BigEndian(reference.Slice(64, reference.Length - 64), num2);
		num2 = (uint)(16843009 * Avg3(b3, b4, b4));
		reference = ref dst;
		BinaryPrimitives.WriteUInt32BigEndian(reference.Slice(96, reference.Length - 96), num2);
	}

	public static void RD4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = offset - 1;
		byte b = yuv[num];
		byte b2 = yuv[num + 32];
		byte b3 = yuv[num + 64];
		byte c = yuv[num + 96];
		byte b4 = yuv[num - 32];
		byte b5 = yuv[offset - 32];
		byte b6 = yuv[offset + 1 - 32];
		byte b7 = yuv[offset + 2 - 32];
		byte a = yuv[offset + 3 - 32];
		Dst(dst, 0, 3, Avg3(b2, b3, c));
		byte v = Avg3(b, b2, b3);
		Dst(dst, 1, 3, v);
		Dst(dst, 0, 2, v);
		byte v2 = Avg3(b4, b, b2);
		Dst(dst, 2, 3, v2);
		Dst(dst, 1, 2, v2);
		Dst(dst, 0, 1, v2);
		byte v3 = Avg3(b5, b4, b);
		Dst(dst, 3, 3, v3);
		Dst(dst, 2, 2, v3);
		Dst(dst, 1, 1, v3);
		Dst(dst, 0, 0, v3);
		byte v4 = Avg3(b6, b5, b4);
		Dst(dst, 3, 2, v4);
		Dst(dst, 2, 1, v4);
		Dst(dst, 1, 0, v4);
		byte v5 = Avg3(b7, b6, b5);
		Dst(dst, 3, 1, v5);
		Dst(dst, 2, 0, v5);
		Dst(dst, 3, 0, Avg3(a, b7, b6));
	}

	public static void VR4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		int num = offset - 1;
		byte b = yuv[num];
		byte b2 = yuv[num + 32];
		byte a = yuv[num + 64];
		byte b3 = yuv[num - 32];
		byte b4 = yuv[offset - 32];
		byte b5 = yuv[offset + 1 - 32];
		byte b6 = yuv[offset + 2 - 32];
		byte b7 = yuv[offset + 3 - 32];
		byte v = Avg2(b3, b4);
		Dst(dst, 0, 0, v);
		Dst(dst, 1, 2, v);
		byte v2 = Avg2(b4, b5);
		Dst(dst, 1, 0, v2);
		Dst(dst, 2, 2, v2);
		byte v3 = Avg2(b5, b6);
		Dst(dst, 2, 0, v3);
		Dst(dst, 3, 2, v3);
		Dst(dst, 3, 0, Avg2(b6, b7));
		Dst(dst, 0, 3, Avg3(a, b2, b));
		Dst(dst, 0, 2, Avg3(b2, b, b3));
		byte v4 = Avg3(b, b3, b4);
		Dst(dst, 0, 1, v4);
		Dst(dst, 1, 3, v4);
		byte v5 = Avg3(b3, b4, b5);
		Dst(dst, 1, 1, v5);
		Dst(dst, 2, 3, v5);
		byte v6 = Avg3(b4, b5, b6);
		Dst(dst, 2, 1, v6);
		Dst(dst, 3, 3, v6);
		Dst(dst, 3, 1, Avg3(b5, b6, b7));
	}

	public static void LD4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		byte a = yuv[offset - 32];
		byte b = yuv[offset + 1 - 32];
		byte b2 = yuv[offset + 2 - 32];
		byte b3 = yuv[offset + 3 - 32];
		byte b4 = yuv[offset + 4 - 32];
		byte b5 = yuv[offset + 5 - 32];
		byte b6 = yuv[offset + 6 - 32];
		byte b7 = yuv[offset + 7 - 32];
		Dst(dst, 0, 0, Avg3(a, b, b2));
		byte v = Avg3(b, b2, b3);
		Dst(dst, 1, 0, v);
		Dst(dst, 0, 1, v);
		byte v2 = Avg3(b2, b3, b4);
		Dst(dst, 2, 0, v2);
		Dst(dst, 1, 1, v2);
		Dst(dst, 0, 2, v2);
		byte v3 = Avg3(b3, b4, b5);
		Dst(dst, 3, 0, v3);
		Dst(dst, 2, 1, v3);
		Dst(dst, 1, 2, v3);
		Dst(dst, 0, 3, v3);
		byte v4 = Avg3(b4, b5, b6);
		Dst(dst, 3, 1, v4);
		Dst(dst, 2, 2, v4);
		Dst(dst, 1, 3, v4);
		byte v5 = Avg3(b5, b6, b7);
		Dst(dst, 3, 2, v5);
		Dst(dst, 2, 3, v5);
		Dst(dst, 3, 3, Avg3(b6, b7, b7));
	}

	public static void VL4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		byte a = yuv[offset - 32];
		byte b = yuv[offset + 1 - 32];
		byte b2 = yuv[offset + 2 - 32];
		byte b3 = yuv[offset + 3 - 32];
		byte b4 = yuv[offset + 4 - 32];
		byte b5 = yuv[offset + 5 - 32];
		byte b6 = yuv[offset + 6 - 32];
		byte c = yuv[offset + 7 - 32];
		Dst(dst, 0, 0, Avg2(a, b));
		byte v = Avg2(b, b2);
		Dst(dst, 1, 0, v);
		Dst(dst, 0, 2, v);
		byte v2 = Avg2(b2, b3);
		Dst(dst, 2, 0, v2);
		Dst(dst, 1, 2, v2);
		byte v3 = Avg2(b3, b4);
		Dst(dst, 3, 0, v3);
		Dst(dst, 2, 2, v3);
		Dst(dst, 0, 1, Avg3(a, b, b2));
		byte v4 = Avg3(b, b2, b3);
		Dst(dst, 1, 1, v4);
		Dst(dst, 0, 3, v4);
		byte v5 = Avg3(b2, b3, b4);
		Dst(dst, 2, 1, v5);
		Dst(dst, 1, 3, v5);
		byte v6 = Avg3(b3, b4, b5);
		Dst(dst, 3, 1, v6);
		Dst(dst, 2, 3, v6);
		Dst(dst, 3, 2, Avg3(b4, b5, b6));
		Dst(dst, 3, 3, Avg3(b5, b6, c));
	}

	public static void HD4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		byte b = yuv[offset - 1];
		byte b2 = yuv[offset - 1 + 32];
		byte b3 = yuv[offset - 1 + 64];
		byte a = yuv[offset - 1 + 96];
		byte b4 = yuv[offset - 1 - 32];
		byte b5 = yuv[offset - 32];
		byte b6 = yuv[offset + 1 - 32];
		byte c = yuv[offset + 2 - 32];
		byte v = Avg2(b, b4);
		Dst(dst, 0, 0, v);
		Dst(dst, 2, 1, v);
		byte v2 = Avg2(b2, b);
		Dst(dst, 0, 1, v2);
		Dst(dst, 2, 2, v2);
		byte v3 = Avg2(b3, b2);
		Dst(dst, 0, 2, v3);
		Dst(dst, 2, 3, v3);
		Dst(dst, 0, 3, Avg2(a, b3));
		Dst(dst, 3, 0, Avg3(b5, b6, c));
		Dst(dst, 2, 0, Avg3(b4, b5, b6));
		byte v4 = Avg3(b, b4, b5);
		Dst(dst, 1, 0, v4);
		Dst(dst, 3, 1, v4);
		byte v5 = Avg3(b2, b, b4);
		Dst(dst, 1, 1, v5);
		Dst(dst, 3, 2, v5);
		byte v6 = Avg3(b3, b2, b);
		Dst(dst, 1, 2, v6);
		Dst(dst, 3, 3, v6);
		Dst(dst, 1, 3, Avg3(a, b3, b2));
	}

	public static void HU4(Span<byte> dst, Span<byte> yuv, int offset)
	{
		byte a = yuv[offset - 1];
		byte b = yuv[offset - 1 + 32];
		byte b2 = yuv[offset - 1 + 64];
		byte b3 = yuv[offset - 1 + 96];
		Dst(dst, 0, 0, Avg2(a, b));
		byte v = Avg2(b, b2);
		Dst(dst, 2, 0, v);
		Dst(dst, 0, 1, v);
		byte v2 = Avg2(b2, b3);
		Dst(dst, 2, 1, v2);
		Dst(dst, 0, 2, v2);
		Dst(dst, 1, 0, Avg3(a, b, b2));
		byte v3 = Avg3(b, b2, b3);
		Dst(dst, 3, 0, v3);
		Dst(dst, 1, 1, v3);
		byte v4 = Avg3(b2, b3, b3);
		Dst(dst, 3, 1, v4);
		Dst(dst, 1, 2, v4);
		Dst(dst, 3, 2, b3);
		Dst(dst, 2, 2, b3);
		Dst(dst, 0, 3, b3);
		Dst(dst, 1, 3, b3);
		Dst(dst, 2, 3, b3);
		Dst(dst, 3, 3, b3);
	}

	public static void TransformWht(Span<short> input, Span<short> output, Span<int> scratch)
	{
		Span<int> span = scratch.Slice(0, 16);
		span.Clear();
		for (int i = 0; i < 4; i++)
		{
			int index = 4 + i;
			int index2 = 8 + i;
			int index3 = 12 + i;
			int num = input[i] + input[index3];
			int num2 = input[index] + input[index2];
			int num3 = input[index] - input[index2];
			int num4 = input[i] - input[index3];
			span[i] = num + num2;
			span[index2] = num - num2;
			span[index] = num4 + num3;
			span[index3] = num4 - num3;
		}
		int num5 = 0;
		for (int j = 0; j < 4; j++)
		{
			int num6 = j * 4;
			int num7 = span[num6] + 3;
			int num8 = num7 + span[3 + num6];
			int num9 = span[1 + num6] + span[2 + num6];
			int num10 = span[1 + num6] - span[2 + num6];
			int num11 = num7 - span[3 + num6];
			output[num5] = (short)(num8 + num9 >> 3);
			output[num5 + 16] = (short)(num11 + num10 >> 3);
			output[num5 + 32] = (short)(num8 - num9 >> 3);
			output[num5 + 48] = (short)(num11 - num10 >> 3);
			num5 += 64;
		}
	}

	public static int TTransform(Span<byte> input, Span<ushort> w, Span<int> scratch)
	{
		int num = 0;
		Span<int> span = scratch.Slice(0, 16);
		span.Clear();
		int num2 = 0;
		for (int i = 0; i < 4; i++)
		{
			int index = num2 + 1;
			int index2 = num2 + 2;
			int index3 = num2 + 3;
			int num3 = input[num2] + input[index2];
			int num4 = input[index] + input[index3];
			int num5 = input[index] - input[index3];
			int num6 = input[num2] - input[index2];
			span[i * 4] = num3 + num4;
			span[1 + i * 4] = num6 + num5;
			span[2 + i * 4] = num6 - num5;
			span[3 + i * 4] = num3 - num4;
			num2 += 32;
		}
		for (int j = 0; j < 4; j++)
		{
			int num7 = span[j] + span[8 + j];
			int num8 = span[4 + j] + span[12 + j];
			int num9 = span[4 + j] - span[12 + j];
			int num10 = span[j] - span[8 + j];
			int value = num7 + num8;
			int value2 = num10 + num9;
			int value3 = num10 - num9;
			int value4 = num7 - num8;
			num += w[0] * Math.Abs(value);
			num += w[4] * Math.Abs(value2);
			num += w[8] * Math.Abs(value3);
			num += w[12] * Math.Abs(value4);
			w = w.Slice(1, w.Length - 1);
		}
		return num;
	}

	public static int TTransformSse41(Span<byte> inputA, Span<byte> inputB, Span<ushort> w)
	{
		Vector128<byte> vector = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputA));
		Vector128<byte> vector2 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputA.Slice(32, 16)));
		Vector128<byte> vector3 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputA.Slice(64, 16)));
		Vector128<long> vector4 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputA.Slice(96, 16))).AsInt64();
		Vector128<byte> vector5 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputB));
		Vector128<byte> vector6 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputB.Slice(32, 16)));
		Vector128<byte> vector7 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputB.Slice(64, 16)));
		Vector128<long> vector8 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(inputB.Slice(96, 16))).AsInt64();
		Vector128<int> vector9 = Sse2.UnpackLow(vector.AsInt32(), vector5.AsInt32());
		Vector128<int> vector10 = Sse2.UnpackLow(vector2.AsInt32(), vector6.AsInt32());
		Vector128<int> vector11 = Sse2.UnpackLow(vector3.AsInt32(), vector7.AsInt32());
		Vector128<int> vector12 = Sse2.UnpackLow(vector4.AsInt32(), vector8.AsInt32());
		Vector128<short> left = Sse41.ConvertToVector128Int16(vector9.AsByte());
		Vector128<short> left2 = Sse41.ConvertToVector128Int16(vector10.AsByte());
		Vector128<short> right = Sse41.ConvertToVector128Int16(vector11.AsByte());
		Vector128<short> right2 = Sse41.ConvertToVector128Int16(vector12.AsByte());
		Vector128<short> left3 = Sse2.Add(left, right);
		Vector128<short> right3 = Sse2.Add(left2, right2);
		Vector128<short> right4 = Sse2.Subtract(left2, right2);
		Vector128<short> left4 = Sse2.Subtract(left, right);
		Vector128<short> b = Sse2.Add(left3, right3);
		Vector128<short> b2 = Sse2.Add(left4, right4);
		Vector128<short> b3 = Sse2.Subtract(left4, right4);
		Vector128<short> b4 = Sse2.Subtract(left3, right3);
		Vp8Transpose_2_4x4_16b(b, b2, b3, b4, out var output, out var output2, out var output3, out var output4);
		Vector128<ushort> vector13 = Unsafe.As<ushort, Vector128<ushort>>(ref MemoryMarshal.GetReference<ushort>(w));
		Vector128<ushort> vector14 = Unsafe.As<ushort, Vector128<ushort>>(ref MemoryMarshal.GetReference<ushort>(w.Slice(8, 8)));
		left3 = Sse2.Add(output.AsInt16(), output3.AsInt16());
		right3 = Sse2.Add(output2.AsInt16(), output4.AsInt16());
		right4 = Sse2.Subtract(output2.AsInt16(), output4.AsInt16());
		Vector128<short> left5 = Sse2.Subtract(output.AsInt16(), output3.AsInt16());
		b = Sse2.Add(left3, right3);
		b2 = Sse2.Add(left5, right4);
		b3 = Sse2.Subtract(left5, right4);
		b4 = Sse2.Subtract(left3, right3);
		Vector128<long> vector15 = Sse2.UnpackLow(b.AsInt64(), b2.AsInt64());
		Vector128<long> vector16 = Sse2.UnpackLow(b3.AsInt64(), b4.AsInt64());
		Vector128<long> vector17 = Sse2.UnpackHigh(b.AsInt64(), b2.AsInt64());
		Vector128<long> vector18 = Sse2.UnpackHigh(b3.AsInt64(), b4.AsInt64());
		Vector128<ushort> vector19 = Ssse3.Abs(vector15.AsInt16());
		Vector128<ushort> vector20 = Ssse3.Abs(vector16.AsInt16());
		Vector128<ushort> vector21 = Ssse3.Abs(vector17.AsInt16());
		Vector128<ushort> vector22 = Ssse3.Abs(vector18.AsInt16());
		Vector128<int> left6 = Sse2.MultiplyAddAdjacent(vector19.AsInt16(), vector13.AsInt16());
		Vector128<int> right5 = Sse2.MultiplyAddAdjacent(vector20.AsInt16(), vector14.AsInt16());
		Vector128<int> left7 = Sse2.MultiplyAddAdjacent(vector21.AsInt16(), vector13.AsInt16());
		Vector128<int> right6 = Sse2.MultiplyAddAdjacent(vector22.AsInt16(), vector14.AsInt16());
		Vector128<int> vector23 = Sse2.Add(left6, right5);
		return Numerics.ReduceSum(Sse2.Subtract(right: Sse2.Add(left7, right6).AsInt32(), left: vector23.AsInt32()));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Vp8Transpose_2_4x4_16b(Vector128<short> b0, Vector128<short> b1, Vector128<short> b2, Vector128<short> b3, out Vector128<long> output0, out Vector128<long> output1, out Vector128<long> output2, out Vector128<long> output3)
	{
		Vector128<short> vector = Sse2.UnpackLow(b0, b1);
		Vector128<short> vector2 = Sse2.UnpackLow(b2, b3);
		Vector128<short> vector3 = Sse2.UnpackHigh(b0, b1);
		Vector128<short> vector4 = Sse2.UnpackHigh(b2, b3);
		Vector128<int> vector5 = Sse2.UnpackLow(vector.AsInt32(), vector2.AsInt32());
		Vector128<int> vector6 = Sse2.UnpackLow(vector3.AsInt32(), vector4.AsInt32());
		Vector128<int> vector7 = Sse2.UnpackHigh(vector.AsInt32(), vector2.AsInt32());
		Vector128<int> vector8 = Sse2.UnpackHigh(vector3.AsInt32(), vector4.AsInt32());
		output0 = Sse2.UnpackLow(vector5.AsInt64(), vector6.AsInt64());
		output1 = Sse2.UnpackHigh(vector5.AsInt64(), vector6.AsInt64());
		output2 = Sse2.UnpackLow(vector7.AsInt64(), vector8.AsInt64());
		output3 = Sse2.UnpackHigh(vector7.AsInt64(), vector8.AsInt64());
	}

	public static void TransformTwo(Span<short> src, Span<byte> dst, Span<int> scratch)
	{
		if (Sse2.IsSupported)
		{
			ref short reference = ref MemoryMarshal.GetReference<short>(src);
			Vector128<long> left = Vector128.Create(Unsafe.As<short, long>(ref reference), 0L);
			Vector128<long> left2 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 4)), 0L);
			Vector128<long> left3 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 8)), 0L);
			Vector128<long> left4 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 12)), 0L);
			Vector128<long> right = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 16)), 0L);
			Vector128<long> right2 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 20)), 0L);
			Vector128<long> right3 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 24)), 0L);
			Vector128<long> right4 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 28)), 0L);
			left = Sse2.UnpackLow(left, right);
			left2 = Sse2.UnpackLow(left2, right2);
			left3 = Sse2.UnpackLow(left3, right3);
			left4 = Sse2.UnpackLow(left4, right4);
			Vector128<short> vector = Sse2.Add(left.AsInt16(), left3.AsInt16());
			Vector128<short> vector2 = Sse2.Subtract(left.AsInt16(), left3.AsInt16());
			Vector128<short> right5 = Vector128.Create((short)20091);
			Vector128<short> right6 = Vector128.Create((short)(-30068));
			Vector128<short> left5 = Sse2.MultiplyHigh(left2.AsInt16(), right6);
			Vector128<short> right7 = Sse2.MultiplyHigh(left4.AsInt16(), right5);
			Vector128<short> vector3 = Sse2.Subtract(left2.AsInt16(), left4.AsInt16());
			Vector128<short> right8 = Sse2.Add(right: Sse2.Subtract(left5, right7), left: vector3.AsInt16());
			Vector128<short> left6 = Sse2.MultiplyHigh(left2.AsInt16(), right5);
			Vector128<short> right9 = Sse2.MultiplyHigh(left4.AsInt16(), right6);
			Vector128<short> left7 = Sse2.Add(left2.AsInt16(), left4.AsInt16());
			Vector128<short> right10 = Sse2.Add(left6, right9);
			Vector128<short> right11 = Sse2.Add(left7, right10);
			Vector128<short> b = Sse2.Add(vector.AsInt16(), right11);
			Vector128<short> b2 = Sse2.Add(vector2.AsInt16(), right8);
			Vector128<short> b3 = Sse2.Subtract(vector2.AsInt16(), right8);
			Vector128<short> b4 = Sse2.Subtract(vector.AsInt16(), right11);
			Vp8Transpose_2_4x4_16b(b, b2, b3, b4, out var output, out var output2, out var output3, out var output4);
			Vector128<short> left8 = Sse2.Add(output.AsInt16(), Vector128.Create((short)4));
			vector = Sse2.Add(left8, output3.AsInt16());
			vector2 = Sse2.Subtract(left8, output3.AsInt16());
			left5 = Sse2.MultiplyHigh(output2.AsInt16(), right6);
			right7 = Sse2.MultiplyHigh(output4.AsInt16(), right5);
			Vector128<short> left9 = Sse2.Subtract(output2.AsInt16(), output4.AsInt16());
			Vector128<short> right12 = Sse2.Subtract(left5, right7);
			right8 = Sse2.Add(left9, right12);
			left6 = Sse2.MultiplyHigh(output2.AsInt16(), right5);
			right9 = Sse2.MultiplyHigh(output4.AsInt16(), right6);
			Vector128<short> left10 = Sse2.Add(output2.AsInt16(), output4.AsInt16());
			right10 = Sse2.Add(left6, right9);
			right11 = Sse2.Add(left10, right10);
			b = Sse2.Add(vector, right11);
			b2 = Sse2.Add(vector2, right8);
			b3 = Sse2.Subtract(vector2, right8);
			b4 = Sse2.Subtract(vector, right11);
			Vector128<short> b5 = Sse2.ShiftRightArithmetic(b, 3);
			Vector128<short> b6 = Sse2.ShiftRightArithmetic(b2, 3);
			Vector128<short> b7 = Sse2.ShiftRightArithmetic(b3, 3);
			Vector128<short> b8 = Sse2.ShiftRightArithmetic(b4, 3);
			Vp8Transpose_2_4x4_16b(b5, b6, b7, b8, out output, out output2, out output3, out output4);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(dst);
			Vector128<byte> left11 = Vector128.Create(Unsafe.As<byte, long>(ref reference2), 0L).AsByte();
			Vector128<byte> left12 = Vector128.Create(Unsafe.As<byte, long>(ref Unsafe.Add(ref reference2, 32)), 0L).AsByte();
			Vector128<byte> left13 = Vector128.Create(Unsafe.As<byte, long>(ref Unsafe.Add(ref reference2, 64)), 0L).AsByte();
			Vector128<byte> left14 = Vector128.Create(Unsafe.As<byte, long>(ref Unsafe.Add(ref reference2, 96)), 0L).AsByte();
			left11 = Sse2.UnpackLow(left11, Vector128<byte>.Zero);
			left12 = Sse2.UnpackLow(left12, Vector128<byte>.Zero);
			left13 = Sse2.UnpackLow(left13, Vector128<byte>.Zero);
			left14 = Sse2.UnpackLow(left14, Vector128<byte>.Zero);
			left11 = Sse2.Add(left11.AsInt16(), output.AsInt16()).AsByte();
			left12 = Sse2.Add(left12.AsInt16(), output2.AsInt16()).AsByte();
			left13 = Sse2.Add(left13.AsInt16(), output3.AsInt16()).AsByte();
			left14 = Sse2.Add(left14.AsInt16(), output4.AsInt16()).AsByte();
			left11 = Sse2.PackUnsignedSaturate(left11.AsInt16(), left11.AsInt16());
			left12 = Sse2.PackUnsignedSaturate(left12.AsInt16(), left12.AsInt16());
			left13 = Sse2.PackUnsignedSaturate(left13.AsInt16(), left13.AsInt16());
			left14 = Sse2.PackUnsignedSaturate(left14.AsInt16(), left14.AsInt16());
			ref byte reference3 = ref MemoryMarshal.GetReference<byte>(dst);
			Unsafe.As<byte, Vector64<byte>>(ref reference3) = left11.GetLower();
			Unsafe.As<byte, Vector64<byte>>(ref Unsafe.Add(ref reference3, 32)) = left12.GetLower();
			Unsafe.As<byte, Vector64<byte>>(ref Unsafe.Add(ref reference3, 64)) = left13.GetLower();
			Unsafe.As<byte, Vector64<byte>>(ref Unsafe.Add(ref reference3, 96)) = left14.GetLower();
		}
		else
		{
			TransformOne(src, dst, scratch);
			TransformOne(src.Slice(16, src.Length - 16), dst.Slice(4, dst.Length - 4), scratch);
		}
	}

	public static void TransformOne(Span<short> src, Span<byte> dst, Span<int> scratch)
	{
		if (Sse2.IsSupported)
		{
			ref short reference = ref MemoryMarshal.GetReference<short>(src);
			Vector128<long> vector = Vector128.Create(Unsafe.As<short, long>(ref reference), 0L);
			Vector128<long> vector2 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 4)), 0L);
			Vector128<long> vector3 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 8)), 0L);
			Vector128<long> vector4 = Vector128.Create(Unsafe.As<short, long>(ref Unsafe.Add(ref reference, 12)), 0L);
			Vector128<short> vector5 = Sse2.Add(vector.AsInt16(), vector3.AsInt16());
			Vector128<short> vector6 = Sse2.Subtract(vector.AsInt16(), vector3.AsInt16());
			Vector128<short> right = Vector128.Create((short)20091);
			Vector128<short> right2 = Vector128.Create((short)(-30068));
			Vector128<short> left = Sse2.MultiplyHigh(vector2.AsInt16(), right2);
			Vector128<short> right3 = Sse2.MultiplyHigh(vector4.AsInt16(), right);
			Vector128<short> vector7 = Sse2.Subtract(vector2.AsInt16(), vector4.AsInt16());
			Vector128<short> right4 = Sse2.Add(right: Sse2.Subtract(left, right3), left: vector7.AsInt16());
			Vector128<short> left2 = Sse2.MultiplyHigh(vector2.AsInt16(), right);
			Vector128<short> right5 = Sse2.MultiplyHigh(vector4.AsInt16(), right2);
			Vector128<short> left3 = Sse2.Add(vector2.AsInt16(), vector4.AsInt16());
			Vector128<short> right6 = Sse2.Add(left2, right5);
			Vector128<short> right7 = Sse2.Add(left3, right6);
			Vector128<short> b = Sse2.Add(vector5.AsInt16(), right7);
			Vector128<short> b2 = Sse2.Add(vector6.AsInt16(), right4);
			Vector128<short> b3 = Sse2.Subtract(vector6.AsInt16(), right4);
			Vector128<short> b4 = Sse2.Subtract(vector5.AsInt16(), right7);
			Vp8Transpose_2_4x4_16b(b, b2, b3, b4, out var output, out var output2, out var output3, out var output4);
			Vector128<short> left4 = Sse2.Add(output.AsInt16(), Vector128.Create((short)4));
			vector5 = Sse2.Add(left4, output3.AsInt16());
			vector6 = Sse2.Subtract(left4, output3.AsInt16());
			left = Sse2.MultiplyHigh(output2.AsInt16(), right2);
			right3 = Sse2.MultiplyHigh(output4.AsInt16(), right);
			Vector128<short> left5 = Sse2.Subtract(output2.AsInt16(), output4.AsInt16());
			Vector128<short> right8 = Sse2.Subtract(left, right3);
			right4 = Sse2.Add(left5, right8);
			left2 = Sse2.MultiplyHigh(output2.AsInt16(), right);
			right5 = Sse2.MultiplyHigh(output4.AsInt16(), right2);
			Vector128<short> left6 = Sse2.Add(output2.AsInt16(), output4.AsInt16());
			right6 = Sse2.Add(left2, right5);
			right7 = Sse2.Add(left6, right6);
			b = Sse2.Add(vector5, right7);
			b2 = Sse2.Add(vector6, right4);
			b3 = Sse2.Subtract(vector6, right4);
			b4 = Sse2.Subtract(vector5, right7);
			Vector128<short> b5 = Sse2.ShiftRightArithmetic(b, 3);
			Vector128<short> b6 = Sse2.ShiftRightArithmetic(b2, 3);
			Vector128<short> b7 = Sse2.ShiftRightArithmetic(b3, 3);
			Vector128<short> b8 = Sse2.ShiftRightArithmetic(b4, 3);
			Vp8Transpose_2_4x4_16b(b5, b6, b7, b8, out output, out output2, out output3, out output4);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(dst);
			Vector128<byte> left7 = Sse2.ConvertScalarToVector128Int32(Unsafe.As<byte, int>(ref reference2)).AsByte();
			Vector128<byte> left8 = Sse2.ConvertScalarToVector128Int32(Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, 32))).AsByte();
			Vector128<byte> left9 = Sse2.ConvertScalarToVector128Int32(Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, 64))).AsByte();
			Vector128<byte> left10 = Sse2.ConvertScalarToVector128Int32(Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, 96))).AsByte();
			left7 = Sse2.UnpackLow(left7, Vector128<byte>.Zero);
			left8 = Sse2.UnpackLow(left8, Vector128<byte>.Zero);
			left9 = Sse2.UnpackLow(left9, Vector128<byte>.Zero);
			left10 = Sse2.UnpackLow(left10, Vector128<byte>.Zero);
			left7 = Sse2.Add(left7.AsInt16(), output.AsInt16()).AsByte();
			left8 = Sse2.Add(left8.AsInt16(), output2.AsInt16()).AsByte();
			left9 = Sse2.Add(left9.AsInt16(), output3.AsInt16()).AsByte();
			left10 = Sse2.Add(left10.AsInt16(), output4.AsInt16()).AsByte();
			left7 = Sse2.PackUnsignedSaturate(left7.AsInt16(), left7.AsInt16());
			left8 = Sse2.PackUnsignedSaturate(left8.AsInt16(), left8.AsInt16());
			left9 = Sse2.PackUnsignedSaturate(left9.AsInt16(), left9.AsInt16());
			left10 = Sse2.PackUnsignedSaturate(left10.AsInt16(), left10.AsInt16());
			ref byte reference3 = ref MemoryMarshal.GetReference<byte>(dst);
			int num = Sse2.ConvertToInt32(left7.AsInt32());
			int num2 = Sse2.ConvertToInt32(left8.AsInt32());
			int num3 = Sse2.ConvertToInt32(left9.AsInt32());
			int num4 = Sse2.ConvertToInt32(left10.AsInt32());
			Unsafe.As<byte, int>(ref reference3) = num;
			Unsafe.As<byte, int>(ref Unsafe.Add(ref reference3, 32)) = num2;
			Unsafe.As<byte, int>(ref Unsafe.Add(ref reference3, 64)) = num3;
			Unsafe.As<byte, int>(ref Unsafe.Add(ref reference3, 96)) = num4;
		}
		else
		{
			Span<int> span = scratch.Slice(0, 16);
			int num5 = 0;
			for (int i = 0; i < 4; i++)
			{
				int index = i + 4;
				int index2 = i + 8;
				int index3 = i + 12;
				int num6 = src[i] + src[index2];
				int num7 = src[i] - src[index2];
				int num8 = Mul2(src[index]) - Mul1(src[index3]);
				int num9 = Mul1(src[index]) + Mul2(src[index3]);
				span[num5++] = num6 + num9;
				span[num5++] = num7 + num8;
				span[num5++] = num7 - num8;
				span[num5++] = num6 - num9;
			}
			num5 = 0;
			int num10 = 0;
			for (int j = 0; j < 4; j++)
			{
				int index4 = num5 + 4;
				int index5 = num5 + 8;
				int index6 = num5 + 12;
				int num11 = span[num5] + 4;
				int num12 = num11 + span[index5];
				int num13 = num11 - span[index5];
				int num14 = Mul2(span[index4]) - Mul1(span[index6]);
				int num15 = Mul1(span[index4]) + Mul2(span[index6]);
				ref Span<byte> reference4 = ref dst;
				int num16 = num10;
				Store(reference4.Slice(num16, reference4.Length - num16), 0, 0, num12 + num15);
				reference4 = ref dst;
				num16 = num10;
				Store(reference4.Slice(num16, reference4.Length - num16), 1, 0, num13 + num14);
				reference4 = ref dst;
				num16 = num10;
				Store(reference4.Slice(num16, reference4.Length - num16), 2, 0, num13 - num14);
				reference4 = ref dst;
				num16 = num10;
				Store(reference4.Slice(num16, reference4.Length - num16), 3, 0, num12 - num15);
				num5++;
				num10 += 32;
			}
		}
	}

	public static void TransformDc(Span<short> src, Span<byte> dst)
	{
		int v = src[0] + 4;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				Store(dst, j, i, v);
			}
		}
	}

	public static void TransformAc3(Span<short> src, Span<byte> dst)
	{
		int num = src[0] + 4;
		int num2 = Mul2(src[4]);
		int num3 = Mul1(src[4]);
		int c = Mul2(src[1]);
		int d = Mul1(src[1]);
		Store2(dst, 0, num + num3, d, c);
		Store2(dst, 1, num + num2, d, c);
		Store2(dst, 2, num - num2, d, c);
		Store2(dst, 3, num - num3, d, c);
	}

	public static void TransformUv(Span<short> src, Span<byte> dst, Span<int> scratch)
	{
		ref Span<short> reference = ref src;
		TransformTwo(reference.Slice(0, reference.Length), dst, scratch);
		reference = ref src;
		TransformTwo(reference.Slice(32, reference.Length - 32), dst.Slice(128, dst.Length - 128), scratch);
	}

	public static void TransformDcuv(Span<short> src, Span<byte> dst)
	{
		if (src[0] != 0)
		{
			ref Span<short> reference = ref src;
			TransformDc(reference.Slice(0, reference.Length), dst);
		}
		if (src[16] != 0)
		{
			ref Span<short> reference = ref src;
			Span<short> src2 = reference.Slice(16, reference.Length - 16);
			ref Span<byte> reference2 = ref dst;
			TransformDc(src2, reference2.Slice(4, reference2.Length - 4));
		}
		if (src[32] != 0)
		{
			ref Span<short> reference = ref src;
			Span<short> src3 = reference.Slice(32, reference.Length - 32);
			ref Span<byte> reference2 = ref dst;
			TransformDc(src3, reference2.Slice(128, reference2.Length - 128));
		}
		if (src[48] != 0)
		{
			ref Span<short> reference = ref src;
			Span<short> src4 = reference.Slice(48, reference.Length - 48);
			ref Span<byte> reference2 = ref dst;
			TransformDc(src4, reference2.Slice(132, reference2.Length - 132));
		}
	}

	public static void SimpleVFilter16(Span<byte> p, int offset, int stride, int thresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte source = ref Unsafe.Add(ref MemoryMarshal.GetReference<byte>(p), (uint)offset);
			Vector128<byte> p2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Subtract(ref source, 2 * stride));
			Vector128<byte> p3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Subtract(ref source, stride));
			Vector128<byte> q = Unsafe.As<byte, Vector128<byte>>(ref source);
			Vector128<byte> q2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref source, (uint)stride));
			DoFilter2Sse2(ref p2, ref p3, ref q, ref q2, thresh);
			ref byte source2 = ref Unsafe.Add(ref MemoryMarshal.GetReference<byte>(p), (uint)offset);
			Unsafe.As<byte, Vector128<sbyte>>(ref Unsafe.Subtract(ref source2, stride)) = p3.AsSByte();
			Unsafe.As<byte, Vector128<sbyte>>(ref source2) = q.AsSByte();
			return;
		}
		int t = 2 * thresh + 1;
		int num = 16 + offset;
		for (int i = offset; i < num; i++)
		{
			if (NeedsFilter(p, i, stride, t))
			{
				DoFilter2(p, i, stride);
			}
		}
	}

	public static void SimpleHFilter16(Span<byte> p, int offset, int stride, int thresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref Unsafe.Add(ref MemoryMarshal.GetReference<byte>(p), (uint)(offset - 2));
			Load16x4(ref reference, ref Unsafe.Add(ref reference, (uint)(8 * stride)), stride, out var p2, out var p3, out var q, out var q2);
			DoFilter2Sse2(ref p2, ref p3, ref q, ref q2, thresh);
			Store16x4(p2, p3, q, q2, ref reference, ref Unsafe.Add(ref reference, (uint)(8 * stride)), stride);
			return;
		}
		int t = 2 * thresh + 1;
		int num = offset + 16 * stride;
		for (int i = offset; i < num; i += stride)
		{
			if (NeedsFilter(p, i, 1, t))
			{
				DoFilter2(p, i, 1);
			}
		}
	}

	public static void SimpleVFilter16i(Span<byte> p, int offset, int stride, int thresh)
	{
		if (Sse2.IsSupported)
		{
			for (int num = 3; num > 0; num--)
			{
				offset += 4 * stride;
				SimpleVFilter16(p, offset, stride, thresh);
			}
		}
		else
		{
			for (int num2 = 3; num2 > 0; num2--)
			{
				offset += 4 * stride;
				SimpleVFilter16(p, offset, stride, thresh);
			}
		}
	}

	public static void SimpleHFilter16i(Span<byte> p, int offset, int stride, int thresh)
	{
		if (Sse2.IsSupported)
		{
			for (int num = 3; num > 0; num--)
			{
				offset += 4;
				SimpleHFilter16(p, offset, stride, thresh);
			}
		}
		else
		{
			for (int num2 = 3; num2 > 0; num2--)
			{
				offset += 4;
				SimpleHFilter16(p, offset, stride, thresh);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void VFilter16(Span<byte> p, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(p);
			Vector128<byte> p2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset - 4 * stride)));
			Vector128<byte> p3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset - 3 * stride)));
			Vector128<byte> p4 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset - 2 * stride)));
			Vector128<byte> p5 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset - stride)));
			Vector128<byte> left = Abs(p4, p5);
			left = Sse2.Max(left, Abs(p2, p3));
			left = Sse2.Max(left, Abs(p3, p4));
			Vector128<byte> q = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)offset));
			Vector128<byte> q2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + stride)));
			Vector128<byte> q3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 2 * stride)));
			p2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 3 * stride)));
			left = Sse2.Max(left, Abs(q2, q));
			left = Sse2.Max(left, Abs(p2, q3));
			left = Sse2.Max(left, Abs(q3, q2));
			ComplexMask(p4, p5, q, q2, thresh, ithresh, ref left);
			DoFilter6Sse2(ref p3, ref p4, ref p5, ref q, ref q2, ref q3, left, hevThresh);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(p);
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(offset - 3 * stride))) = p3.AsInt32();
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(offset - 2 * stride))) = p4.AsInt32();
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(offset - stride))) = p5.AsInt32();
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)offset)) = q.AsInt32();
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(offset + stride))) = q2.AsInt32();
			Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(offset + 2 * stride))) = q3.AsInt32();
		}
		else
		{
			FilterLoop26(p, offset, stride, 1, 16, thresh, ithresh, hevThresh);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void HFilter16(Span<byte> p, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(p);
			ref byte reference2 = ref Unsafe.Add(ref reference, (uint)(offset - 4));
			Load16x4(ref reference2, ref Unsafe.Add(ref reference2, (uint)(8 * stride)), stride, out var p2, out var p3, out var q, out var q2);
			Vector128<byte> left = Abs(q, q2);
			left = Sse2.Max(left, Abs(p2, p3));
			left = Sse2.Max(left, Abs(p3, q));
			Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference, (uint)(offset + 8 * stride)), stride, out var p4, out var p5, out var q3, out var q4);
			left = Sse2.Max(left, Abs(p5, p4));
			left = Sse2.Max(left, Abs(q4, q3));
			left = Sse2.Max(left, Abs(q3, p5));
			ComplexMask(q, q2, p4, p5, thresh, ithresh, ref left);
			DoFilter6Sse2(ref p3, ref q, ref q2, ref p4, ref p5, ref q3, left, hevThresh);
			Store16x4(p2, p3, q, q2, ref reference2, ref Unsafe.Add(ref reference2, (uint)(8 * stride)), stride);
			Store16x4(p4, p5, q3, q4, ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference, (uint)(offset + 8 * stride)), stride);
		}
		else
		{
			FilterLoop26(p, offset, 1, stride, 16, thresh, ithresh, hevThresh);
		}
	}

	public static void VFilter16i(Span<byte> p, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(p);
			Vector128<byte> q = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)offset));
			Vector128<byte> q2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + stride)));
			Vector128<byte> p2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 2 * stride)));
			Vector128<byte> p3 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 3 * stride)));
			for (int num = 3; num > 0; num--)
			{
				int num2 = offset + 2 * stride;
				Span<byte> span = p.Slice(num2, p.Length - num2);
				offset += 4 * stride;
				Vector128<byte> left = Abs(p3, p2);
				left = Sse2.Max(left, Abs(q, q2));
				left = Sse2.Max(left, Abs(q2, p2));
				q = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)offset));
				q2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + stride)));
				Vector128<byte> vector = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 2 * stride)));
				Vector128<byte> vector2 = Unsafe.As<byte, Vector128<byte>>(ref Unsafe.Add(ref reference, (uint)(offset + 3 * stride)));
				left = Sse2.Max(left, Abs(vector, vector2));
				left = Sse2.Max(left, Abs(q, q2));
				left = Sse2.Max(left, Abs(q2, vector));
				ComplexMask(p2, p3, q, q2, thresh, ithresh, ref left);
				DoFilter4Sse2(ref p2, ref p3, ref q, ref q2, left, hevThresh);
				ref byte reference2 = ref MemoryMarshal.GetReference<byte>(span);
				Unsafe.As<byte, Vector128<int>>(ref reference2) = p2.AsInt32();
				Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)stride)) = p3.AsInt32();
				Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(stride * 2))) = q.AsInt32();
				Unsafe.As<byte, Vector128<int>>(ref Unsafe.Add(ref reference2, (uint)(stride * 3))) = q2.AsInt32();
				p2 = vector;
				p3 = vector2;
			}
		}
		else
		{
			for (int num3 = 3; num3 > 0; num3--)
			{
				offset += 4 * stride;
				FilterLoop24(p, offset, stride, 1, 16, thresh, ithresh, hevThresh);
			}
		}
	}

	public static void HFilter16i(Span<byte> p, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(p);
			Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference, (uint)(offset + 8 * stride)), stride, out var p2, out var p3, out var q, out var q2);
			for (int num = 3; num > 0; num--)
			{
				ref byte reference2 = ref Unsafe.Add(ref reference, (uint)(offset + 2));
				offset += 4;
				Vector128<byte> left = Abs(q, q2);
				left = Sse2.Max(left, Abs(p2, p3));
				left = Sse2.Max(left, Abs(p3, q));
				Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference, (uint)(offset + 8 * stride)), stride, out p2, out p3, out var q3, out var q4);
				left = Sse2.Max(left, Abs(q3, q4));
				left = Sse2.Max(left, Abs(p2, p3));
				left = Sse2.Max(left, Abs(p3, q3));
				ComplexMask(q, q2, p2, p3, thresh, ithresh, ref left);
				DoFilter4Sse2(ref q, ref q2, ref p2, ref p3, left, hevThresh);
				Store16x4(q, q2, p2, p3, ref reference2, ref Unsafe.Add(ref reference2, (uint)(8 * stride)), stride);
				q = q3;
				q2 = q4;
			}
		}
		else
		{
			for (int num2 = 3; num2 > 0; num2--)
			{
				offset += 4;
				FilterLoop24(p, offset, 1, stride, 16, thresh, ithresh, hevThresh);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void VFilter8(Span<byte> u, Span<byte> v, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(u);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(v);
			Vector128<byte> p = LoadUvEdge(ref reference, ref reference2, offset - 4 * stride);
			Vector128<byte> p2 = LoadUvEdge(ref reference, ref reference2, offset - 3 * stride);
			Vector128<byte> p3 = LoadUvEdge(ref reference, ref reference2, offset - 2 * stride);
			Vector128<byte> p4 = LoadUvEdge(ref reference, ref reference2, offset - stride);
			Vector128<byte> left = Abs(p3, p4);
			left = Sse2.Max(left, Abs(p, p2));
			left = Sse2.Max(left, Abs(p2, p3));
			Vector128<byte> q = LoadUvEdge(ref reference, ref reference2, offset);
			Vector128<byte> q2 = LoadUvEdge(ref reference, ref reference2, offset + stride);
			Vector128<byte> q3 = LoadUvEdge(ref reference, ref reference2, offset + 2 * stride);
			p = LoadUvEdge(ref reference, ref reference2, offset + 3 * stride);
			left = Sse2.Max(left, Abs(q2, q));
			left = Sse2.Max(left, Abs(p, q3));
			left = Sse2.Max(left, Abs(q3, q2));
			ComplexMask(p3, p4, q, q2, thresh, ithresh, ref left);
			DoFilter6Sse2(ref p2, ref p3, ref p4, ref q, ref q2, ref q3, left, hevThresh);
			StoreUv(p2, ref reference, ref reference2, offset - 3 * stride);
			StoreUv(p3, ref reference, ref reference2, offset - 2 * stride);
			StoreUv(p4, ref reference, ref reference2, offset - stride);
			StoreUv(q, ref reference, ref reference2, offset);
			StoreUv(q2, ref reference, ref reference2, offset + stride);
			StoreUv(q3, ref reference, ref reference2, offset + 2 * stride);
		}
		else
		{
			FilterLoop26(u, offset, stride, 1, 8, thresh, ithresh, hevThresh);
			FilterLoop26(v, offset, stride, 1, 8, thresh, ithresh, hevThresh);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void HFilter8(Span<byte> u, Span<byte> v, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(u);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(v);
			Load16x4(ref Unsafe.Add(ref reference, (uint)(offset - 4)), ref Unsafe.Add(ref reference2, (uint)(offset - 4)), stride, out var p, out var p2, out var q, out var q2);
			Vector128<byte> left = Abs(q, q2);
			left = Sse2.Max(left, Abs(p, p2));
			left = Sse2.Max(left, Abs(p2, q));
			Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference2, (uint)offset), stride, out var p3, out var p4, out var q3, out var q4);
			left = Sse2.Max(left, Abs(p4, p3));
			left = Sse2.Max(left, Abs(q4, q3));
			left = Sse2.Max(left, Abs(q3, p4));
			ComplexMask(q, q2, p3, p4, thresh, ithresh, ref left);
			DoFilter6Sse2(ref p2, ref q, ref q2, ref p3, ref p4, ref q3, left, hevThresh);
			Store16x4(p, p2, q, q2, ref Unsafe.Add(ref reference, (uint)(offset - 4)), ref Unsafe.Add(ref reference2, (uint)(offset - 4)), stride);
			Store16x4(p3, p4, q3, q4, ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference2, (uint)offset), stride);
		}
		else
		{
			FilterLoop26(u, offset, 1, stride, 8, thresh, ithresh, hevThresh);
			FilterLoop26(v, offset, 1, stride, 8, thresh, ithresh, hevThresh);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void VFilter8i(Span<byte> u, Span<byte> v, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(u);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(v);
			Vector128<byte> p = LoadUvEdge(ref reference, ref reference2, offset);
			Vector128<byte> vector = LoadUvEdge(ref reference, ref reference2, offset + stride);
			Vector128<byte> p2 = LoadUvEdge(ref reference, ref reference2, offset + stride * 2);
			Vector128<byte> p3 = LoadUvEdge(ref reference, ref reference2, offset + stride * 3);
			Vector128<byte> left = Abs(p2, p3);
			left = Sse2.Max(left, Abs(p, vector));
			left = Sse2.Max(left, Abs(vector, p2));
			offset += 4 * stride;
			Vector128<byte> q = LoadUvEdge(ref reference, ref reference2, offset);
			Vector128<byte> q2 = LoadUvEdge(ref reference, ref reference2, offset + stride);
			vector = LoadUvEdge(ref reference, ref reference2, offset + stride * 2);
			p = LoadUvEdge(ref reference, ref reference2, offset + stride * 3);
			left = Sse2.Max(left, Abs(q2, q));
			left = Sse2.Max(left, Abs(p, vector));
			left = Sse2.Max(left, Abs(vector, q2));
			ComplexMask(p2, p3, q, q2, thresh, ithresh, ref left);
			DoFilter4Sse2(ref p2, ref p3, ref q, ref q2, left, hevThresh);
			StoreUv(p2, ref reference, ref reference2, offset + -2 * stride);
			StoreUv(p3, ref reference, ref reference2, offset + -1 * stride);
			StoreUv(q, ref reference, ref reference2, offset);
			StoreUv(q2, ref reference, ref reference2, offset + stride);
		}
		else
		{
			int offset2 = offset + 4 * stride;
			FilterLoop24(u, offset2, stride, 1, 8, thresh, ithresh, hevThresh);
			FilterLoop24(v, offset2, stride, 1, 8, thresh, ithresh, hevThresh);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void HFilter8i(Span<byte> u, Span<byte> v, int offset, int stride, int thresh, int ithresh, int hevThresh)
	{
		if (Sse2.IsSupported)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(u);
			ref byte reference2 = ref MemoryMarshal.GetReference<byte>(v);
			Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference2, (uint)offset), stride, out var p, out var p2, out var q, out var q2);
			Vector128<byte> left = Abs(q, q2);
			left = Sse2.Max(left, Abs(p, p2));
			left = Sse2.Max(left, Abs(p2, q));
			offset += 4;
			Load16x4(ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference2, (uint)offset), stride, out var p3, out var p4, out p2, out p);
			left = Sse2.Max(left, Abs(p4, p3));
			left = Sse2.Max(left, Abs(p, p2));
			left = Sse2.Max(left, Abs(p2, p4));
			ComplexMask(q, q2, p3, p4, thresh, ithresh, ref left);
			DoFilter4Sse2(ref q, ref q2, ref p3, ref p4, left, hevThresh);
			offset -= 2;
			Store16x4(q, q2, p3, p4, ref Unsafe.Add(ref reference, (uint)offset), ref Unsafe.Add(ref reference2, (uint)offset), stride);
		}
		else
		{
			int offset2 = offset + 4;
			FilterLoop24(u, offset2, 1, stride, 8, thresh, ithresh, hevThresh);
			FilterLoop24(v, offset2, 1, stride, 8, thresh, ithresh, hevThresh);
		}
	}

	public static void Mean16x4(Span<byte> input, Span<uint> dc)
	{
		if (Ssse3.IsSupported)
		{
			Vector128<byte> right = Vector128.Create((short)255).AsByte();
			Vector128<byte> vector = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(input));
			Vector128<byte> vector2 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(input.Slice(32, 16)));
			Vector128<byte> vector3 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(input.Slice(64, 16)));
			Vector128<byte> vector4 = Unsafe.As<byte, Vector128<byte>>(ref MemoryMarshal.GetReference<byte>(input.Slice(96, 16)));
			Vector128<short> vector5 = Sse2.ShiftRightLogical(vector.AsInt16(), 8);
			Vector128<short> vector6 = Sse2.ShiftRightLogical(vector2.AsInt16(), 8);
			Vector128<short> vector7 = Sse2.ShiftRightLogical(vector3.AsInt16(), 8);
			Vector128<short> vector8 = Sse2.ShiftRightLogical(vector4.AsInt16(), 8);
			Vector128<byte> vector9 = Sse2.And(vector, right);
			Vector128<byte> vector10 = Sse2.And(vector2, right);
			Vector128<byte> vector11 = Sse2.And(vector3, right);
			Vector128<byte> vector12 = Sse2.And(vector4, right);
			Vector128<int> left = Sse2.Add(vector5.AsInt32(), vector9.AsInt32());
			Vector128<int> right2 = Sse2.Add(vector6.AsInt32(), vector10.AsInt32());
			Vector128<int> left2 = Sse2.Add(vector7.AsInt32(), vector11.AsInt32());
			Vector128<int> right3 = Sse2.Add(vector8.AsInt32(), vector12.AsInt32());
			Vector128<int> left3 = Sse2.Add(left, right2);
			Vector128<int> right4 = Sse2.Add(left2, right3);
			Vector128<int> vector13 = Sse2.Add(left3, right4);
			Vector128<uint> vector14 = Sse2.UnpackLow(Ssse3.HorizontalAdd(vector13.AsInt16(), vector13.AsInt16()), Vector128<short>.Zero).AsUInt32();
			Unsafe.As<uint, Vector128<uint>>(ref MemoryMarshal.GetReference<uint>(dc)) = vector14;
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			uint num = 0u;
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					num += input[k + j * 32];
				}
			}
			dc[i] = num;
			input = input.Slice(4, input.Length - 4);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte Avg2(byte a, byte b)
	{
		return (byte)(a + b + 1 >> 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte Avg3(byte a, byte b, byte c)
	{
		return (byte)(a + 2 * b + c + 2 >> 2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Dst(Span<byte> dst, int x, int y, byte v)
	{
		dst[x + y * 32] = v;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte Clip8B(int v)
	{
		return (byte)(((v & -256) == 0) ? ((uint)v) : ((v >= 0) ? 255u : 0u));
	}

	public static int Vp8BitCost(int bit, byte proba)
	{
		if (bit != 0)
		{
			return WebpLookupTables.Vp8EntropyCost[255 - proba];
		}
		return WebpLookupTables.Vp8EntropyCost[proba];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void Put16(int v, Span<byte> dst)
	{
		for (int i = 0; i < 16; i++)
		{
			int num = i * 32;
			Memset(dst.Slice(num, dst.Length - num), (byte)v, 0, 16);
		}
	}

	private static void TrueMotion(Span<byte> dst, Span<byte> yuv, int offset, int size)
	{
		int num = offset - 32;
		ref Span<byte> reference = ref yuv;
		int num2 = num;
		Span<byte> span = reference.Slice(num2, reference.Length - num2);
		byte b = yuv[num - 1];
		int num3 = offset - 1;
		byte b2 = yuv[num3];
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				dst[j] = (byte)Clamp255(b2 + span[j] - b);
			}
			num3 += 32;
			b2 = yuv[num3];
			reference = ref dst;
			dst = reference.Slice(32, reference.Length - 32);
		}
	}

	private static void FilterLoop24(Span<byte> p, int offset, int hStride, int vStride, int size, int thresh, int ithresh, int hevThresh)
	{
		int t = 2 * thresh + 1;
		while (size-- > 0)
		{
			if (NeedsFilter2(p, offset, hStride, t, ithresh))
			{
				if (Hev(p, offset, hStride, hevThresh))
				{
					DoFilter2(p, offset, hStride);
				}
				else
				{
					DoFilter4(p, offset, hStride);
				}
			}
			offset += vStride;
		}
	}

	private static void FilterLoop26(Span<byte> p, int offset, int hStride, int vStride, int size, int thresh, int ithresh, int hevThresh)
	{
		int t = 2 * thresh + 1;
		while (size-- > 0)
		{
			if (NeedsFilter2(p, offset, hStride, t, ithresh))
			{
				if (Hev(p, offset, hStride, hevThresh))
				{
					DoFilter2(p, offset, hStride);
				}
				else
				{
					DoFilter6(p, offset, hStride);
				}
			}
			offset += vStride;
		}
	}

	private static void DoFilter2(Span<byte> p, int offset, int step)
	{
		int num = p[offset - 2 * step];
		int num2 = p[offset - step];
		int num3 = p[offset];
		int num4 = p[offset + step];
		int num5 = 3 * (num3 - num2) + WebpLookupTables.Sclip1(num - num4);
		int num6 = WebpLookupTables.Sclip2(num5 + 4 >> 3);
		int num7 = WebpLookupTables.Sclip2(num5 + 3 >> 3);
		p[offset - step] = WebpLookupTables.Clip1(num2 + num7);
		p[offset] = WebpLookupTables.Clip1(num3 - num6);
	}

	private static void DoFilter2Sse2(ref Vector128<byte> p1, ref Vector128<byte> p0, ref Vector128<byte> q0, ref Vector128<byte> q1, int thresh)
	{
		Vector128<byte> right = Vector128.Create((byte)128);
		Vector128<byte> vector = Sse2.Xor(p1, right);
		Vector128<byte> vector2 = Sse2.Xor(q1, right);
		Vector128<byte> right2 = NeedsFilter(p1, p0, q0, q1, thresh);
		p0 = Sse2.Xor(p0, right);
		q0 = Sse2.Xor(q0, right);
		Vector128<byte> left = GetBaseDelta(vector.AsSByte(), p0.AsSByte(), q0.AsSByte(), vector2.AsSByte()).AsByte();
		left = Sse2.And(left, right2);
		DoSimpleFilterSse2(ref p0, ref q0, left);
		p0 = Sse2.Xor(p0, right);
		q0 = Sse2.Xor(q0, right);
	}

	private static void DoFilter4Sse2(ref Vector128<byte> p1, ref Vector128<byte> p0, ref Vector128<byte> q0, ref Vector128<byte> q1, Vector128<byte> mask, int tresh)
	{
		Vector128<byte> notHev = GetNotHev(ref p1, ref p0, ref q0, ref q1, tresh);
		Vector128<byte> vector = Vector128.Create((byte)128);
		p1 = Sse2.Xor(p1, vector);
		p0 = Sse2.Xor(p0, vector);
		q0 = Sse2.Xor(q0, vector);
		q1 = Sse2.Xor(q1, vector);
		Vector128<sbyte> vector2 = Sse2.SubtractSaturate(p1.AsSByte(), q1.AsSByte());
		vector2 = Sse2.AndNot(notHev, vector2.AsByte()).AsSByte();
		Vector128<sbyte> right = Sse2.SubtractSaturate(q0.AsSByte(), p0.AsSByte());
		vector2 = Sse2.AddSaturate(vector2, right);
		vector2 = Sse2.AddSaturate(vector2, right);
		vector2 = Sse2.AddSaturate(vector2, right);
		vector2 = Sse2.And(vector2.AsByte(), mask).AsSByte();
		right = Sse2.AddSaturate(vector2, Vector128.Create((byte)3).AsSByte());
		Vector128<sbyte> vector3 = Sse2.AddSaturate(vector2, Vector128.Create((byte)4).AsSByte());
		right = SignedShift8b(right.AsByte());
		vector3 = SignedShift8b(vector3.AsByte());
		p0 = Sse2.AddSaturate(p0.AsSByte(), right).AsByte();
		q0 = Sse2.SubtractSaturate(q0.AsSByte(), vector3).AsByte();
		p0 = Sse2.Xor(p0, vector);
		q0 = Sse2.Xor(q0, vector);
		right = Sse2.Add(vector3, vector.AsSByte());
		vector3 = Sse2.Average(right.AsByte(), Vector128<byte>.Zero).AsSByte();
		vector3 = Sse2.Subtract(vector3, Vector128.Create((sbyte)64));
		vector3 = Sse2.And(notHev, vector3.AsByte()).AsSByte();
		q1 = Sse2.SubtractSaturate(q1.AsSByte(), vector3).AsByte();
		p1 = Sse2.AddSaturate(p1.AsSByte(), vector3).AsByte();
		p1 = Sse2.Xor(p1.AsByte(), vector);
		q1 = Sse2.Xor(q1.AsByte(), vector);
	}

	private static void DoFilter6Sse2(ref Vector128<byte> p2, ref Vector128<byte> p1, ref Vector128<byte> p0, ref Vector128<byte> q0, ref Vector128<byte> q1, ref Vector128<byte> q2, Vector128<byte> mask, int tresh)
	{
		Vector128<byte> notHev = GetNotHev(ref p1, ref p0, ref q0, ref q1, tresh);
		Vector128<byte> right = Vector128.Create((byte)128);
		p1 = Sse2.Xor(p1, right);
		p0 = Sse2.Xor(p0, right);
		q0 = Sse2.Xor(q0, right);
		q1 = Sse2.Xor(q1, right);
		p2 = Sse2.Xor(p2, right);
		q2 = Sse2.Xor(q2, right);
		Vector128<sbyte> baseDelta = GetBaseDelta(p1.AsSByte(), p0.AsSByte(), q0.AsSByte(), q1.AsSByte());
		Vector128<byte> fl = Sse2.And(right: Sse2.AndNot(notHev, mask), left: baseDelta.AsByte());
		DoSimpleFilterSse2(ref p0, ref q0, fl);
		fl = Sse2.And(right: Sse2.And(notHev, mask), left: baseDelta.AsByte());
		Vector128<byte> vector = Sse2.UnpackLow(Vector128<byte>.Zero, fl);
		Vector128<byte> vector2 = Sse2.UnpackHigh(Vector128<byte>.Zero, fl);
		Vector128<short> right2 = Vector128.Create((short)2304);
		Vector128<short> vector3 = Sse2.MultiplyHigh(vector.AsInt16(), right2);
		Vector128<short> vector4 = Sse2.MultiplyHigh(vector2.AsInt16(), right2);
		Vector128<short> right3 = Vector128.Create((short)63);
		Vector128<short> vector5 = Sse2.Add(vector3, right3);
		Vector128<short> vector6 = Sse2.Add(vector4, right3);
		Vector128<short> vector7 = Sse2.Add(vector5, vector3);
		Vector128<short> vector8 = Sse2.Add(vector6, vector4);
		Vector128<short> a0Low = Sse2.Add(vector7, vector3);
		Vector128<short> a0High = Sse2.Add(vector8, vector4);
		Update2Pixels(ref p2, ref q2, vector5, vector6);
		Update2Pixels(ref p1, ref q1, vector7, vector8);
		Update2Pixels(ref p0, ref q0, a0Low, a0High);
	}

	private static void DoSimpleFilterSse2(ref Vector128<byte> p0, ref Vector128<byte> q0, Vector128<byte> fl)
	{
		Vector128<sbyte> vector = Sse2.AddSaturate(fl.AsSByte(), Vector128.Create((byte)3).AsSByte());
		Vector128<sbyte> vector2 = Sse2.AddSaturate(fl.AsSByte(), Vector128.Create((byte)4).AsSByte());
		vector2 = SignedShift8b(vector2.AsByte()).AsSByte();
		vector = SignedShift8b(vector.AsByte()).AsSByte();
		q0 = Sse2.SubtractSaturate(q0.AsSByte(), vector2).AsByte();
		p0 = Sse2.AddSaturate(p0.AsSByte(), vector).AsByte();
	}

	private static Vector128<byte> GetNotHev(ref Vector128<byte> p1, ref Vector128<byte> p0, ref Vector128<byte> q0, ref Vector128<byte> q1, int hevThresh)
	{
		Vector128<byte> left = Abs(p1, p0);
		Vector128<byte> right = Abs(q1, q0);
		return Sse2.CompareEqual(Sse2.SubtractSaturate(right: Vector128.Create((byte)hevThresh), left: Sse2.Max(left, right)), Vector128<byte>.Zero);
	}

	private static void DoFilter4(Span<byte> p, int offset, int step)
	{
		int index = offset - 2 * step;
		int num = p[index];
		int num2 = p[offset - step];
		int num3 = p[offset];
		int num4 = p[offset + step];
		int num5 = 3 * (num3 - num2);
		int num6 = WebpLookupTables.Sclip2(num5 + 4 >> 3);
		int num7 = WebpLookupTables.Sclip2(num5 + 3 >> 3);
		int num8 = num6 + 1 >> 1;
		p[index] = WebpLookupTables.Clip1(num + num8);
		p[offset - step] = WebpLookupTables.Clip1(num2 + num7);
		p[offset] = WebpLookupTables.Clip1(num3 - num6);
		p[offset + step] = WebpLookupTables.Clip1(num4 - num8);
	}

	private static void DoFilter6(Span<byte> p, int offset, int step)
	{
		int num = 2 * step;
		int num2 = 3 * step;
		int index = offset - step;
		int num3 = p[offset - num2];
		int num4 = p[offset - num];
		int num5 = p[index];
		int num6 = p[offset];
		int num7 = p[offset + step];
		int num8 = p[offset + num];
		int num9 = WebpLookupTables.Sclip1(3 * (num6 - num5) + WebpLookupTables.Sclip1(num4 - num7));
		int num10 = 27 * num9 + 63 >> 7;
		int num11 = 18 * num9 + 63 >> 7;
		int num12 = 9 * num9 + 63 >> 7;
		p[offset - num2] = WebpLookupTables.Clip1(num3 + num12);
		p[offset - num] = WebpLookupTables.Clip1(num4 + num11);
		p[index] = WebpLookupTables.Clip1(num5 + num10);
		p[offset] = WebpLookupTables.Clip1(num6 - num10);
		p[offset + step] = WebpLookupTables.Clip1(num7 - num11);
		p[offset + num] = WebpLookupTables.Clip1(num8 - num12);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool NeedsFilter(Span<byte> p, int offset, int step, int t)
	{
		int num = p[offset + -2 * step];
		int num2 = p[offset - step];
		int num3 = p[offset];
		int num4 = p[offset + step];
		return 4 * WebpLookupTables.Abs0(num2 - num3) + WebpLookupTables.Abs0(num - num4) <= t;
	}

	private static bool NeedsFilter2(Span<byte> p, int offset, int step, int t, int it)
	{
		int num = 2 * step;
		int num2 = 3 * step;
		int num3 = p[offset - 4 * step];
		int num4 = p[offset - num2];
		int num5 = p[offset - num];
		int num6 = p[offset - step];
		int num7 = p[offset];
		int num8 = p[offset + step];
		int num9 = p[offset + num];
		int num10 = p[offset + num2];
		if (4 * WebpLookupTables.Abs0(num6 - num7) + WebpLookupTables.Abs0(num5 - num8) > t)
		{
			return false;
		}
		if (WebpLookupTables.Abs0(num3 - num4) <= it && WebpLookupTables.Abs0(num4 - num5) <= it && WebpLookupTables.Abs0(num5 - num6) <= it && WebpLookupTables.Abs0(num10 - num9) <= it && WebpLookupTables.Abs0(num9 - num8) <= it)
		{
			return WebpLookupTables.Abs0(num8 - num7) <= it;
		}
		return false;
	}

	private static Vector128<byte> NeedsFilter(Vector128<byte> p1, Vector128<byte> p0, Vector128<byte> q0, Vector128<byte> q1, int thresh)
	{
		Vector128<byte> vector = Vector128.Create((byte)thresh);
		Vector128<byte> left = Abs(p1, q1);
		Vector128<byte> right = Vector128.Create((byte)254);
		Vector128<short> vector2 = Sse2.ShiftRightLogical(Sse2.And(left, right).AsInt16(), 1);
		Vector128<byte> vector3 = Abs(p0, q0);
		return Sse2.CompareEqual(Sse2.SubtractSaturate(Sse2.AddSaturate(Sse2.AddSaturate(vector3, vector3).AsByte(), vector2.AsByte()), vector.AsByte()), Vector128<byte>.Zero);
	}

	private static void Load16x4(ref byte r0, ref byte r8, int stride, out Vector128<byte> p1, out Vector128<byte> p0, out Vector128<byte> q0, out Vector128<byte> q1)
	{
		Load8x4(ref r0, (uint)stride, out var p2, out var q2);
		Load8x4(ref r8, (uint)stride, out p0, out q1);
		p1 = Sse2.UnpackLow(p2.AsInt64(), p0.AsInt64()).AsByte();
		p0 = Sse2.UnpackHigh(p2.AsInt64(), p0.AsInt64()).AsByte();
		q0 = Sse2.UnpackLow(q2.AsInt64(), q1.AsInt64()).AsByte();
		q1 = Sse2.UnpackHigh(q2.AsInt64(), q1.AsInt64()).AsByte();
	}

	private static void Load8x4(ref byte bRef, nuint stride, out Vector128<byte> p, out Vector128<byte> q)
	{
		uint e = Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 6 * stride));
		uint e2 = Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 2 * stride));
		uint e3 = Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 4 * stride));
		Vector128<byte> vector = Vector128.Create(Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 0 * stride)), e3, e2, e).AsByte();
		Vector128<byte> vector2 = Vector128.Create(e3: Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 7 * stride)), e2: Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 3 * stride)), e1: Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 5 * stride)), e0: Unsafe.As<byte, uint>(ref Unsafe.Add(ref bRef, 1 * stride))).AsByte();
		Vector128<sbyte> vector3 = Sse2.UnpackLow(vector.AsSByte(), vector2.AsSByte());
		Vector128<sbyte> vector4 = Sse2.UnpackHigh(vector.AsSByte(), vector2.AsSByte());
		Vector128<short> vector5 = Sse2.UnpackLow(vector3.AsInt16(), vector4.AsInt16());
		Vector128<short> vector6 = Sse2.UnpackHigh(vector3.AsInt16(), vector4.AsInt16());
		p = Sse2.UnpackLow(vector5.AsInt32(), vector6.AsInt32()).AsByte();
		q = Sse2.UnpackHigh(vector5.AsInt32(), vector6.AsInt32()).AsByte();
	}

	private static void Store16x4(Vector128<byte> p1, Vector128<byte> p0, Vector128<byte> q0, Vector128<byte> q1, ref byte r0Ref, ref byte r8Ref, int stride)
	{
		Vector128<byte> vector = Sse2.UnpackLow(p1, p0);
		Vector128<byte> vector2 = Sse2.UnpackHigh(p1, p0);
		Vector128<byte> vector3 = Sse2.UnpackLow(q0, q1);
		Vector128<byte> vector4 = Sse2.UnpackHigh(q0, q1);
		Vector128<byte> vector5 = vector;
		vector = Sse2.UnpackLow(vector5.AsInt16(), vector3.AsInt16()).AsByte();
		vector3 = Sse2.UnpackHigh(vector5.AsInt16(), vector3.AsInt16()).AsByte();
		Vector128<byte> vector6 = vector2;
		vector2 = Sse2.UnpackLow(vector6.AsInt16(), vector4.AsInt16()).AsByte();
		vector4 = Sse2.UnpackHigh(vector6.AsInt16(), vector4.AsInt16()).AsByte();
		Store4x4(vector, ref r0Ref, stride);
		Store4x4(vector3, ref Unsafe.Add(ref r0Ref, (uint)(4 * stride)), stride);
		Store4x4(vector2, ref r8Ref, stride);
		Store4x4(vector4, ref Unsafe.Add(ref r8Ref, (uint)(4 * stride)), stride);
	}

	private static void Store4x4(Vector128<byte> x, ref byte dstRef, int stride)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			Unsafe.As<byte, int>(ref Unsafe.Add(ref dstRef, (uint)num)) = Sse2.ConvertToInt32(x.AsInt32());
			x = Sse2.ShiftRightLogical128BitLane(x, 4);
			num += stride;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<sbyte> GetBaseDelta(Vector128<sbyte> p1, Vector128<sbyte> p0, Vector128<sbyte> q0, Vector128<sbyte> q1)
	{
		Vector128<sbyte> left = Sse2.SubtractSaturate(p1, q1);
		Vector128<sbyte> vector = Sse2.SubtractSaturate(q0, p0);
		Vector128<sbyte> right = Sse2.AddSaturate(left, vector);
		Vector128<sbyte> right2 = Sse2.AddSaturate(vector, right);
		return Sse2.AddSaturate(vector, right2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<sbyte> SignedShift8b(Vector128<byte> x)
	{
		Vector128<byte> vector = Sse2.UnpackLow(Vector128<byte>.Zero, x);
		Vector128<byte> vector2 = Sse2.UnpackHigh(Vector128<byte>.Zero, x);
		Vector128<short> left = Sse2.ShiftRightArithmetic(vector.AsInt16(), 11);
		Vector128<short> right = Sse2.ShiftRightArithmetic(vector2.AsInt16(), 11);
		return Sse2.PackSignedSaturate(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ComplexMask(Vector128<byte> p1, Vector128<byte> p0, Vector128<byte> q0, Vector128<byte> q1, int thresh, int ithresh, ref Vector128<byte> mask)
	{
		Vector128<byte> right = Vector128.Create((byte)ithresh);
		Vector128<byte> left = Sse2.CompareEqual(Sse2.SubtractSaturate(mask, right), Vector128<byte>.Zero);
		Vector128<byte> right2 = NeedsFilter(p1, p0, q0, q1, thresh);
		mask = Sse2.And(left, right2);
	}

	private static void Update2Pixels(ref Vector128<byte> pi, ref Vector128<byte> qi, Vector128<short> a0Low, Vector128<short> a0High)
	{
		Vector128<byte> vector = Vector128.Create((byte)128);
		Vector128<short> left = Sse2.ShiftRightArithmetic(a0Low, 7);
		Vector128<short> right = Sse2.ShiftRightArithmetic(a0High, 7);
		Vector128<sbyte> right2 = Sse2.PackSignedSaturate(left, right);
		pi = Sse2.AddSaturate(pi.AsSByte(), right2).AsByte();
		qi = Sse2.SubtractSaturate(qi.AsSByte(), right2).AsByte();
		pi = Sse2.Xor(pi, vector.AsByte());
		qi = Sse2.Xor(qi, vector.AsByte());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> LoadUvEdge(ref byte uRef, ref byte vRef, int offset)
	{
		Vector128<long> left = Vector128.Create(Unsafe.As<byte, long>(ref Unsafe.Add(ref uRef, (uint)offset)), 0L);
		Vector128<long> right = Vector128.Create(Unsafe.As<byte, long>(ref Unsafe.Add(ref vRef, (uint)offset)), 0L);
		return Sse2.UnpackLow(left, right).AsByte();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void StoreUv(Vector128<byte> x, ref byte uRef, ref byte vRef, int offset)
	{
		Unsafe.As<byte, Vector64<byte>>(ref Unsafe.Add(ref uRef, (uint)offset)) = x.GetLower();
		Unsafe.As<byte, Vector64<byte>>(ref Unsafe.Add(ref vRef, (uint)offset)) = x.GetUpper();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> Abs(Vector128<byte> p, Vector128<byte> q)
	{
		return Sse2.Or(Sse2.SubtractSaturate(q, p), Sse2.SubtractSaturate(p, q));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool Hev(Span<byte> p, int offset, int step, int thresh)
	{
		byte num = p[offset - 2 * step];
		int num2 = p[offset - step];
		int num3 = p[offset];
		int num4 = p[offset + step];
		if (WebpLookupTables.Abs0(num - num2) <= thresh)
		{
			return WebpLookupTables.Abs0(num4 - num3) > thresh;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void Store(Span<byte> dst, int x, int y, int v)
	{
		int index = x + y * 32;
		dst[index] = Clip8B(dst[index] + (v >> 3));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void Store2(Span<byte> dst, int y, int dc, int d, int c)
	{
		Store(dst, 0, y, dc + d);
		Store(dst, 1, y, dc + c);
		Store(dst, 2, y, dc - c);
		Store(dst, 3, y, dc - d);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Mul1(int a)
	{
		return (a * 20091 >> 16) + a;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Mul2(int a)
	{
		return a * 35468 >> 16;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void Put8x8uv(byte value, Span<byte> dst)
	{
		for (int i = 0; i < 256; i += 32)
		{
			Memset(dst, value, i, 8);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void Memset(Span<byte> dst, byte value, int startIdx, int count)
	{
		dst.Slice(startIdx, count).Fill(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Clamp255(int x)
	{
		if (x >= 0)
		{
			if (x <= 255)
			{
				return x;
			}
			return 255;
		}
		return 0;
	}
}
