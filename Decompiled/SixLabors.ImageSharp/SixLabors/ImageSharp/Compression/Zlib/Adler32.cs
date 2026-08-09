using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal static class Adler32
{
	public const uint SeedValue = 1u;

	private const uint BASE = 65521u;

	private const uint NMAX = 5552u;

	private const int MinBufferSize = 64;

	private const int BlockSize = 32;

	private static ReadOnlySpan<byte> Tap1Tap2 => new byte[32]
	{
		32, 31, 30, 29, 28, 27, 26, 25, 24, 23,
		22, 21, 20, 19, 18, 17, 16, 15, 14, 13,
		12, 11, 10, 9, 8, 7, 6, 5, 4, 3,
		2, 1
	};

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Calculate(ReadOnlySpan<byte> buffer)
	{
		return Calculate(1u, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	public static uint Calculate(uint adler, ReadOnlySpan<byte> buffer)
	{
		if (buffer.IsEmpty)
		{
			return adler;
		}
		if (Avx2.IsSupported && buffer.Length >= 64)
		{
			return CalculateAvx2(adler, buffer);
		}
		if (Ssse3.IsSupported && buffer.Length >= 64)
		{
			return CalculateSse(adler, buffer);
		}
		if (AdvSimd.IsSupported)
		{
			return CalculateArm(adler, buffer);
		}
		return CalculateScalar(adler, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateSse(uint adler, ReadOnlySpan<byte> buffer)
	{
		uint s = adler & 0xFFFF;
		uint s2 = (adler >> 16) & 0xFFFF;
		uint length = (uint)buffer.Length;
		uint num = length / 32;
		length -= num * 32;
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(buffer))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference<byte>(Tap1Tap2))
			{
				byte* ptr = reference;
				Vector128<sbyte> right = Sse2.LoadVector128((sbyte*)reference2);
				Vector128<sbyte> right2 = Sse2.LoadVector128((sbyte*)(reference2 + 16));
				Vector128<byte> zero = Vector128<byte>.Zero;
				Vector128<short> right3 = Vector128.Create((short)1);
				while (num != 0)
				{
					uint num2 = 173u;
					if (num2 > num)
					{
						num2 = num;
					}
					num -= num2;
					Vector128<uint> vector = Vector128.CreateScalar(s * num2);
					Vector128<uint> left = Vector128.CreateScalar(s2);
					Vector128<uint> vector2 = Vector128<uint>.Zero;
					do
					{
						Vector128<byte> left2 = Sse3.LoadDquVector128(ptr);
						Vector128<byte> left3 = Sse3.LoadDquVector128(ptr + 16);
						vector = Sse2.Add(vector, vector2);
						vector2 = Sse2.Add(vector2, Sse2.SumAbsoluteDifferences(left2, zero).AsUInt32());
						Vector128<short> left4 = Ssse3.MultiplyAddAdjacent(left2, right);
						left = Sse2.Add(left, Sse2.MultiplyAddAdjacent(left4, right3).AsUInt32());
						vector2 = Sse2.Add(vector2, Sse2.SumAbsoluteDifferences(left3, zero).AsUInt32());
						Vector128<short> left5 = Ssse3.MultiplyAddAdjacent(left3, right2);
						left = Sse2.Add(left, Sse2.MultiplyAddAdjacent(left5, right3).AsUInt32());
						ptr += 32;
					}
					while (--num2 != 0);
					left = Sse2.Add(left, Sse2.ShiftLeftLogical(vector, 5));
					vector2 = Sse2.Add(vector2, Sse2.Shuffle(vector2, 78));
					s += vector2.ToScalar();
					left = Sse2.Add(left, Sse2.Shuffle(left, 177));
					left = Sse2.Add(left, Sse2.Shuffle(left, 78));
					s2 = left.ToScalar();
					s %= 65521;
					s2 %= 65521;
				}
				if (length != 0)
				{
					HandleLeftOver(ptr, length, ref s, ref s2);
				}
				return s | (s2 << 16);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	public unsafe static uint CalculateAvx2(uint adler, ReadOnlySpan<byte> buffer)
	{
		uint s = adler & 0xFFFF;
		uint s2 = (adler >> 16) & 0xFFFF;
		uint num = (uint)buffer.Length;
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(buffer))
		{
			byte* ptr = reference;
			Vector256<byte> zero = Vector256<byte>.Zero;
			Vector256<short> right = Vector256.Create((short)1);
			Vector256<sbyte> right2 = Vector256.Create(32, 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1);
			Vector256<uint> vector = Vector256.CreateScalar(s);
			Vector256<uint> vector2 = Vector256.CreateScalar(s2);
			while (num >= 32)
			{
				int num2 = (int)((num < 5552) ? num : 5552);
				num2 -= num2 % 32;
				num -= (uint)num2;
				Vector256<uint> right3 = vector;
				Vector256<uint> vector3 = Vector256<uint>.Zero;
				while (num2 >= 32)
				{
					Vector256<byte> left = Avx.LoadVector256(ptr);
					Vector256<ushort> vector4 = Avx2.SumAbsoluteDifferences(left, zero);
					vector = Avx2.Add(vector, vector4.AsUInt32());
					vector3 = Avx2.Add(vector3, right3);
					vector2 = Avx2.Add(Avx2.MultiplyAddAdjacent(Avx2.MultiplyAddAdjacent(left, right2), right).AsUInt32(), vector2);
					right3 = vector;
					ptr += 32;
					num2 -= 32;
				}
				vector3 = Avx2.ShiftLeftLogical(vector3, 5);
				vector2 = Avx2.Add(vector2, vector3);
				s = (uint)Numerics.EvenReduceSum(vector.AsInt32());
				s2 = (uint)Numerics.ReduceSum(vector2.AsInt32());
				s %= 65521;
				s2 %= 65521;
				vector = Vector256.CreateScalar(s);
				vector2 = Vector256.CreateScalar(s2);
			}
			if (num != 0)
			{
				HandleLeftOver(ptr, num, ref s, ref s2);
			}
			return s | (s2 << 16);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateArm(uint adler, ReadOnlySpan<byte> buffer)
	{
		uint s = adler & 0xFFFF;
		uint s2 = (adler >> 16) & 0xFFFF;
		uint length = (uint)buffer.Length;
		long num = length / 32;
		length -= (uint)(int)(num * 32);
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(buffer))
		{
			byte* ptr = reference;
			while (num != 0L)
			{
				uint num2 = 173u;
				if (num2 > num)
				{
					num2 = (uint)num;
				}
				num -= num2;
				Vector128<uint> vector = Vector128<uint>.Zero;
				Vector128<uint> vector2 = vector.WithElement(3, s * num2);
				Vector128<ushort> vector3 = Vector128<ushort>.Zero;
				Vector128<ushort> vector4 = Vector128<ushort>.Zero;
				Vector128<ushort> vector5 = Vector128<ushort>.Zero;
				Vector128<ushort> vector6 = Vector128<ushort>.Zero;
				do
				{
					Vector128<ushort> vector7 = AdvSimd.LoadVector128(ptr).AsUInt16();
					Vector128<ushort> vector8 = AdvSimd.LoadVector128(ptr + 16).AsUInt16();
					vector2 = AdvSimd.Add(vector2, vector);
					vector = AdvSimd.AddPairwiseWideningAndAdd(vector.AsUInt32(), AdvSimd.AddPairwiseWideningAndAdd(AdvSimd.AddPairwiseWidening(vector7.AsByte()).AsUInt16(), vector8.AsByte()));
					vector3 = AdvSimd.AddWideningLower(vector3, vector7.GetLower().AsByte());
					vector4 = AdvSimd.AddWideningLower(vector4, vector7.GetUpper().AsByte());
					vector5 = AdvSimd.AddWideningLower(vector5, vector8.GetLower().AsByte());
					vector6 = AdvSimd.AddWideningLower(vector6, vector8.GetUpper().AsByte());
					ptr += 32;
				}
				while (--num2 != 0);
				vector2 = AdvSimd.ShiftLeftLogical(vector2, 5);
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector3.GetLower(), Vector64.Create((ushort)32, (ushort)31, (ushort)30, (ushort)29));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector3.GetUpper(), Vector64.Create((ushort)28, (ushort)27, (ushort)26, (ushort)25));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector4.GetLower(), Vector64.Create((ushort)24, (ushort)23, (ushort)22, (ushort)21));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector4.GetUpper(), Vector64.Create((ushort)20, (ushort)19, (ushort)18, (ushort)17));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector5.GetLower(), Vector64.Create((ushort)16, (ushort)15, (ushort)14, (ushort)13));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector5.GetUpper(), Vector64.Create((ushort)12, (ushort)11, (ushort)10, (ushort)9));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector6.GetLower(), Vector64.Create((ushort)8, (ushort)7, (ushort)6, (ushort)5));
				vector2 = AdvSimd.MultiplyWideningLowerAndAdd(vector2, vector6.GetUpper(), Vector64.Create((ushort)4, (ushort)3, (ushort)2, (ushort)1));
				Vector64<uint> left = AdvSimd.AddPairwise(vector.GetLower(), vector.GetUpper());
				Vector64<uint> right = AdvSimd.AddPairwise(vector2.GetLower(), vector2.GetUpper());
				Vector64<uint> vector9 = AdvSimd.AddPairwise(left, right);
				s += AdvSimd.Extract(vector9, 0);
				s2 += AdvSimd.Extract(vector9, 1);
				s %= 65521;
				s2 %= 65521;
			}
			if (length != 0)
			{
				HandleLeftOver(ptr, length, ref s, ref s2);
			}
			return s | (s2 << 16);
		}
	}

	private unsafe static void HandleLeftOver(byte* localBufferPtr, uint length, ref uint s1, ref uint s2)
	{
		if (length >= 16)
		{
			s2 += (s1 += *localBufferPtr);
			s2 += (s1 += localBufferPtr[1]);
			s2 += (s1 += localBufferPtr[2]);
			s2 += (s1 += localBufferPtr[3]);
			s2 += (s1 += localBufferPtr[4]);
			s2 += (s1 += localBufferPtr[5]);
			s2 += (s1 += localBufferPtr[6]);
			s2 += (s1 += localBufferPtr[7]);
			s2 += (s1 += localBufferPtr[8]);
			s2 += (s1 += localBufferPtr[9]);
			s2 += (s1 += localBufferPtr[10]);
			s2 += (s1 += localBufferPtr[11]);
			s2 += (s1 += localBufferPtr[12]);
			s2 += (s1 += localBufferPtr[13]);
			s2 += (s1 += localBufferPtr[14]);
			s2 += (s1 += localBufferPtr[15]);
			localBufferPtr += 16;
			length -= 16;
		}
		while (length-- != 0)
		{
			s2 += (s1 += *(localBufferPtr++));
		}
		if (s1 >= 65521)
		{
			s1 -= 65521u;
		}
		s2 %= 65521u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateScalar(uint adler, ReadOnlySpan<byte> buffer)
	{
		uint num = adler & 0xFFFF;
		uint num2 = (adler >> 16) & 0xFFFF;
		fixed (byte* ptr = buffer)
		{
			byte* ptr2 = ptr;
			uint num3 = (uint)buffer.Length;
			while (num3 != 0)
			{
				uint num4 = ((num3 < 5552) ? num3 : 5552u);
				num3 -= num4;
				while (num4 >= 16)
				{
					num2 += (num += *ptr2);
					num2 += (num += ptr2[1]);
					num2 += (num += ptr2[2]);
					num2 += (num += ptr2[3]);
					num2 += (num += ptr2[4]);
					num2 += (num += ptr2[5]);
					num2 += (num += ptr2[6]);
					num2 += (num += ptr2[7]);
					num2 += (num += ptr2[8]);
					num2 += (num += ptr2[9]);
					num2 += (num += ptr2[10]);
					num2 += (num += ptr2[11]);
					num2 += (num += ptr2[12]);
					num2 += (num += ptr2[13]);
					num2 += (num += ptr2[14]);
					num2 += (num += ptr2[15]);
					ptr2 += 16;
					num4 -= 16;
				}
				while (num4-- != 0)
				{
					num2 += (num += *(ptr2++));
				}
				num %= 65521;
				num2 %= 65521;
			}
			return (num2 << 16) | num;
		}
	}
}
