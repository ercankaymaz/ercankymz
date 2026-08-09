using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal static class ZigZag
{
	private const byte _ = byte.MaxValue;

	public static ReadOnlySpan<byte> ZigZagOrder => new byte[80]
	{
		0, 1, 8, 16, 9, 2, 3, 10, 17, 24,
		32, 25, 18, 11, 4, 5, 12, 19, 26, 33,
		40, 48, 41, 34, 27, 20, 13, 6, 7, 14,
		21, 28, 35, 42, 49, 56, 57, 50, 43, 36,
		29, 22, 15, 23, 30, 37, 44, 51, 58, 59,
		52, 45, 38, 31, 39, 46, 53, 60, 61, 54,
		47, 55, 62, 63, 63, 63, 63, 63, 63, 63,
		63, 63, 63, 63, 63, 63, 63, 63, 63, 63
	};

	public static ReadOnlySpan<byte> TransposingOrder => new byte[80]
	{
		0, 8, 1, 2, 9, 16, 24, 17, 10, 3,
		4, 11, 18, 25, 32, 40, 33, 26, 19, 12,
		5, 6, 13, 20, 27, 34, 41, 48, 56, 49,
		42, 35, 28, 21, 14, 7, 15, 22, 29, 36,
		43, 50, 57, 58, 51, 44, 37, 30, 23, 31,
		38, 45, 52, 59, 60, 53, 46, 39, 47, 54,
		61, 62, 55, 63, 63, 63, 63, 63, 63, 63,
		63, 63, 63, 63, 63, 63, 63, 63, 63, 63
	};

	private static ReadOnlySpan<byte> SseShuffleMasks => new byte[352]
	{
		0, 1, 255, 255, 2, 3, 4, 5, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
		255, 255, 255, 255, 2, 3, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 0, 1, 255, 255, 2, 3, 255, 255,
		6, 7, 8, 9, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 4, 5, 255, 255, 255, 255,
		6, 7, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 10, 11,
		12, 13, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 8, 9, 255, 255, 255, 255, 10, 11,
		255, 255, 255, 255, 255, 255, 6, 7, 255, 255,
		255, 255, 255, 255, 255, 255, 8, 9, 255, 255,
		4, 5, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 6, 7, 255, 255, 255, 255, 2, 3,
		255, 255, 255, 255, 255, 255, 4, 5, 255, 255,
		255, 255, 255, 255, 255, 255, 0, 1, 255, 255,
		2, 3, 255, 255, 255, 255, 255, 255, 255, 255,
		12, 13, 255, 255, 14, 15, 255, 255, 255, 255,
		255, 255, 255, 255, 10, 11, 255, 255, 255, 255,
		255, 255, 12, 13, 255, 255, 255, 255, 8, 9,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		10, 11, 255, 255, 6, 7, 255, 255, 255, 255,
		255, 255, 255, 255, 8, 9, 255, 255, 255, 255,
		255, 255, 4, 5, 255, 255, 255, 255, 6, 7,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		2, 3, 4, 5, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		8, 9, 255, 255, 255, 255, 10, 11, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 6, 7,
		8, 9, 255, 255, 12, 13, 255, 255, 14, 15,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 12, 13, 255, 255,
		255, 255, 14, 15, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 10, 11, 12, 13, 255, 255,
		14, 15
	};

	private static ReadOnlySpan<byte> AvxShuffleMasks => new byte[608]
	{
		0, 0, 0, 0, 1, 0, 0, 0, 4, 0,
		0, 0, 255, 255, 255, 255, 1, 0, 0, 0,
		2, 0, 0, 0, 4, 0, 0, 0, 5, 0,
		0, 0, 0, 1, 8, 9, 2, 3, 4, 5,
		10, 11, 255, 255, 255, 255, 255, 255, 12, 13,
		2, 3, 4, 5, 14, 15, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 0, 1, 8, 9, 2, 3,
		255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
		10, 11, 255, 255, 255, 255, 0, 0, 0, 0,
		1, 0, 0, 0, 2, 0, 0, 0, 5, 0,
		0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
		4, 0, 0, 0, 5, 0, 0, 0, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 0, 1, 8, 9,
		2, 0, 0, 0, 3, 0, 0, 0, 6, 0,
		0, 0, 7, 0, 0, 0, 0, 0, 0, 0,
		1, 0, 0, 0, 4, 0, 0, 0, 5, 0,
		0, 0, 255, 255, 255, 255, 255, 255, 8, 9,
		2, 3, 4, 5, 10, 11, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 12, 13, 6, 7,
		255, 255, 255, 255, 255, 255, 255, 255, 8, 9,
		14, 15, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 2, 3, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 4, 5, 10, 11, 255, 255,
		255, 255, 255, 255, 12, 13, 6, 7, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		0, 1, 8, 9, 2, 3, 255, 255, 255, 255,
		255, 255, 255, 255, 12, 13, 6, 7, 14, 15,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 2, 0, 0, 0, 3, 0, 0, 0,
		6, 0, 0, 0, 7, 0, 0, 0, 2, 0,
		0, 0, 5, 0, 0, 0, 6, 0, 0, 0,
		7, 0, 0, 0, 8, 9, 2, 3, 255, 255,
		255, 255, 255, 255, 4, 5, 10, 11, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 12, 13, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		0, 1, 6, 7, 255, 255, 255, 255, 255, 255,
		255, 255, 8, 9, 2, 3, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 4, 5, 10, 11,
		12, 13, 6, 7, 255, 255, 255, 255, 255, 255,
		6, 7, 14, 15, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 2, 0, 0, 0, 3, 0, 0, 0,
		5, 0, 0, 0, 6, 0, 0, 0, 3, 0,
		0, 0, 6, 0, 0, 0, 7, 0, 0, 0,
		255, 255, 255, 255, 255, 255, 255, 255, 4, 5,
		14, 15, 255, 255, 255, 255, 255, 255, 255, 255,
		8, 9, 2, 3, 10, 11, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 0, 1, 10, 11, 12, 13,
		2, 3, 255, 255, 255, 255, 255, 255, 0, 1,
		6, 7, 8, 9, 2, 3, 10, 11
	};

	public unsafe static void ApplyTransposingZigZagOrderingSsse3(ref Block8x8 block)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(SseShuffleMasks))
		{
			Vector128<byte> vector = block.V0.AsByte();
			Vector128<byte> value = block.V1.AsByte();
			Vector128<byte> vector2 = block.V2.AsByte();
			Vector128<byte> vector3 = block.V3.AsByte();
			Vector128<byte> vector4 = block.V4.AsByte();
			Vector128<byte> vector5 = block.V5.AsByte();
			Vector128<byte> value2 = block.V6.AsByte();
			Vector128<byte> vector6 = block.V7.AsByte();
			Vector128<short> left = Ssse3.Shuffle(vector, Sse2.LoadVector128(reference)).AsInt16();
			Vector128<short> right = Ssse3.Shuffle(value, Sse2.LoadVector128(reference + 16)).AsInt16();
			Vector128<short> vector7 = Sse2.Or(right: Ssse3.Shuffle(vector2, Sse2.LoadVector128(reference + 32)).AsInt16(), left: Sse2.Or(left, right));
			vector7 = Sse2.Insert(vector7.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 0), 6).AsInt16();
			Vector128<short> left2 = Ssse3.Shuffle(vector, Sse2.LoadVector128(reference + 48)).AsInt16();
			Vector128<short> right2 = Ssse3.Shuffle(value, Sse2.LoadVector128(reference + 64)).AsInt16();
			Vector128<short> vector8 = Sse2.Or(left2, right2);
			vector8 = Sse2.Insert(vector8.AsUInt16(), Sse2.Extract(vector2.AsUInt16(), 2), 4).AsInt16();
			vector8 = Sse2.Insert(vector8.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 1), 5).AsInt16();
			vector8 = Sse2.Insert(vector8.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 0), 6).AsInt16();
			vector8 = Sse2.Insert(vector8.AsUInt16(), Sse2.Extract(vector5.AsUInt16(), 0), 7).AsInt16();
			Vector128<short> left3 = Ssse3.Shuffle(vector, Sse2.LoadVector128(reference + 80)).AsInt16();
			Vector128<short> right3 = Ssse3.Shuffle(value, Sse2.LoadVector128(reference + 96)).AsInt16();
			Vector128<short> vector9 = Sse2.Or(right: Ssse3.Shuffle(vector2, Sse2.LoadVector128(reference + 112)).AsInt16(), left: Sse2.Or(left3, right3));
			vector9 = Sse2.Insert(vector9.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 2), 1).AsInt16();
			vector9 = Sse2.Insert(vector9.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 1), 0).AsInt16();
			Vector128<short> left4 = Ssse3.Shuffle(vector4, Sse2.LoadVector128(reference + 128)).AsInt16();
			Vector128<short> right4 = Ssse3.Shuffle(vector5, Sse2.LoadVector128(reference + 144)).AsInt16();
			Vector128<short> vector10 = Sse2.Or(right: Ssse3.Shuffle(value2, Sse2.LoadVector128(reference + 160)).AsInt16(), left: Sse2.Or(left4, right4));
			vector10 = Sse2.Insert(vector10.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 3), 0).AsInt16();
			vector10 = Sse2.Insert(vector10.AsUInt16(), Sse2.Extract(vector6.AsUInt16(), 0), 4).AsInt16();
			Vector128<short> left5 = Ssse3.Shuffle(value, Sse2.LoadVector128(reference + 176)).AsInt16();
			Vector128<short> right5 = Ssse3.Shuffle(vector2, Sse2.LoadVector128(reference + 192)).AsInt16();
			Vector128<short> vector11 = Sse2.Or(right: Ssse3.Shuffle(vector3, Sse2.LoadVector128(reference + 208)).AsInt16(), left: Sse2.Or(left5, right5));
			vector11 = Sse2.Insert(vector11.AsUInt16(), Sse2.Extract(vector.AsUInt16(), 7), 3).AsInt16();
			vector11 = Sse2.Insert(vector11.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 4), 7).AsInt16();
			Vector128<short> left6 = Ssse3.Shuffle(vector5, Sse2.LoadVector128(reference + 224)).AsInt16();
			Vector128<short> right6 = Ssse3.Shuffle(value2, Sse2.LoadVector128(reference + 240)).AsInt16();
			Vector128<short> vector12 = Sse2.Or(right: Ssse3.Shuffle(vector6, Sse2.LoadVector128(reference + 256)).AsInt16(), left: Sse2.Or(left6, right6));
			vector12 = Sse2.Insert(vector12.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 6), 7).AsInt16();
			vector12 = Sse2.Insert(vector12.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 5), 6).AsInt16();
			Vector128<short> left7 = Ssse3.Shuffle(value2, Sse2.LoadVector128(reference + 272)).AsInt16();
			Vector128<short> right7 = Ssse3.Shuffle(vector6, Sse2.LoadVector128(reference + 288)).AsInt16();
			Vector128<short> vector13 = Sse2.Or(left7, right7);
			vector13 = Sse2.Insert(vector13.AsUInt16(), Sse2.Extract(vector2.AsUInt16(), 7), 0).AsInt16();
			vector13 = Sse2.Insert(vector13.AsUInt16(), Sse2.Extract(vector3.AsUInt16(), 7), 1).AsInt16();
			vector13 = Sse2.Insert(vector13.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 6), 2).AsInt16();
			vector13 = Sse2.Insert(vector13.AsUInt16(), Sse2.Extract(vector5.AsUInt16(), 5), 3).AsInt16();
			Vector128<short> left8 = Ssse3.Shuffle(vector5, Sse2.LoadVector128(reference + 304)).AsInt16();
			Vector128<short> right8 = Ssse3.Shuffle(value2, Sse2.LoadVector128(reference + 320)).AsInt16();
			Vector128<short> vector14 = Sse2.Or(right: Ssse3.Shuffle(vector6, Sse2.LoadVector128(reference + 336)).AsInt16(), left: Sse2.Or(left8, right8));
			vector14 = Sse2.Insert(vector14.AsUInt16(), Sse2.Extract(vector4.AsUInt16(), 7), 1).AsInt16();
			block.V0 = vector7;
			block.V1 = vector8;
			block.V2 = vector9;
			block.V3 = vector10;
			block.V4 = vector11;
			block.V5 = vector12;
			block.V6 = vector13;
			block.V7 = vector14;
		}
	}

	public unsafe static void ApplyTransposingZigZagOrderingAvx2(ref Block8x8 block)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference<byte>(AvxShuffleMasks))
		{
			Vector256<byte> vector = block.V01.AsByte();
			Vector256<byte> vector2 = block.V23.AsByte();
			Vector256<byte> vector3 = block.V45.AsByte();
			Vector256<byte> vector4 = block.V67.AsByte();
			Vector256<int> control = Avx.LoadVector256(reference).AsInt32();
			Vector256<byte> left = Avx2.Shuffle(Avx2.PermuteVar8x32(vector.AsInt32(), control).AsByte(), Avx.LoadVector256(reference + 32)).AsByte();
			Vector256<byte> value = Avx2.PermuteVar8x32(vector2.AsInt32(), control).AsByte();
			value = Avx2.Shuffle(value, Avx.LoadVector256(reference + 64)).AsByte();
			Vector256<int> control2 = Avx.LoadVector256(reference + 96).AsInt32();
			Vector256<byte> value2 = Avx2.PermuteVar8x32(vector3.AsInt32(), control2).AsByte();
			Vector256<byte> right = Avx2.Shuffle(value2, Avx.LoadVector256(reference + 128)).AsByte();
			Vector256<byte> vector5 = Avx2.Or(left, Avx2.Or(value, right));
			Vector256<int> control3 = Avx.LoadVector256(reference + 160).AsInt32();
			Vector256<byte> value3 = Avx2.PermuteVar8x32(vector.AsInt32(), control3).AsByte();
			Vector256<byte> left2 = Avx2.Shuffle(value3, Avx.LoadVector256(reference + 192)).AsByte();
			Vector256<byte> value4 = Avx2.PermuteVar8x32(vector2.AsInt32(), control2).AsByte();
			value4 = Avx2.Shuffle(value4, Avx.LoadVector256(reference + 224)).AsByte();
			Vector256<byte> left3 = Avx2.Shuffle(value2, Avx.LoadVector256(reference + 256)).AsByte();
			Vector256<byte> value5 = Avx2.PermuteVar8x32(vector4.AsInt32(), control3).AsByte();
			Vector256<byte> vector6 = Avx2.Or(right: Avx2.Or(left3, Avx2.Shuffle(value5, Avx.LoadVector256(reference + 288)).AsByte()), left: Avx2.Or(left2, value4));
			Vector256<byte> left4 = Avx2.Shuffle(value3, Avx.LoadVector256(reference + 320)).AsByte();
			Vector256<int> control4 = Avx.LoadVector256(reference + 352).AsInt32();
			Vector256<byte> value6 = Avx2.PermuteVar8x32(vector2.AsInt32(), control4).AsByte();
			Vector256<byte> right2 = Avx2.Shuffle(value6, Avx.LoadVector256(reference + 384)).AsByte();
			Vector256<byte> value7 = Avx2.PermuteVar8x32(vector3.AsInt32(), control4).AsByte();
			value7 = Avx2.Shuffle(value7, Avx.LoadVector256(reference + 416)).AsByte();
			Vector256<byte> vector7 = Avx2.Or(right: Avx2.Or(value7, Avx2.Shuffle(value5, Avx.LoadVector256(reference + 448)).AsByte()), left: Avx2.Or(left4, right2));
			Vector256<byte> left5 = Avx2.Shuffle(value6, Avx.LoadVector256(reference + 480)).AsByte();
			Vector256<int> control5 = Avx.LoadVector256(reference + 512).AsInt32();
			Vector256<byte> value8 = Avx2.PermuteVar8x32(vector3.AsInt32(), control5).AsByte();
			value8 = Avx2.Shuffle(value8, Avx.LoadVector256(reference + 544)).AsByte();
			Vector256<byte> value9 = Avx2.PermuteVar8x32(vector4.AsInt32(), control5).AsByte();
			value9 = Avx2.Shuffle(value9, Avx.LoadVector256(reference + 576)).AsByte();
			Vector256<byte> vector8 = Avx2.Or(left5, Avx2.Or(value8, value9));
			block.V01 = vector5.AsInt16();
			block.V23 = vector6.AsInt16();
			block.V45 = vector7.AsInt16();
			block.V67 = vector8.AsInt16();
		}
	}
}
