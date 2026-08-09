using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using SixLabors.ImageSharp.Common.Helpers;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

[StructLayout(LayoutKind.Explicit, Size = 128)]
internal struct Block8x8
{
	public const int Size = 64;

	[FieldOffset(0)]
	public Vector128<short> V0;

	[FieldOffset(16)]
	public Vector128<short> V1;

	[FieldOffset(32)]
	public Vector128<short> V2;

	[FieldOffset(48)]
	public Vector128<short> V3;

	[FieldOffset(64)]
	public Vector128<short> V4;

	[FieldOffset(80)]
	public Vector128<short> V5;

	[FieldOffset(96)]
	public Vector128<short> V6;

	[FieldOffset(112)]
	public Vector128<short> V7;

	[FieldOffset(0)]
	public Vector256<short> V01;

	[FieldOffset(32)]
	public Vector256<short> V23;

	[FieldOffset(64)]
	public Vector256<short> V45;

	[FieldOffset(96)]
	public Vector256<short> V67;

	public short this[int idx]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Unsafe.Add(ref Unsafe.As<Block8x8, short>(ref this), (uint)idx);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Unsafe.Add(ref Unsafe.As<Block8x8, short>(ref this), (uint)idx) = value;
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

	public static Block8x8 Load(Span<short> data)
	{
		return Unsafe.ReadUnaligned<Block8x8>(ref Unsafe.As<short, byte>(ref MemoryMarshal.GetReference<short>(data)));
	}

	public Block8x8F AsFloatBlock()
	{
		Block8x8F result = default(Block8x8F);
		result.LoadFrom(ref this);
		return result;
	}

	public short[] ToArray()
	{
		short[] array = new short[64];
		CopyTo(array);
		return array;
	}

	public void CopyTo(Span<short> destination)
	{
		Unsafe.WriteUnaligned(ref Unsafe.As<short, byte>(ref MemoryMarshal.GetReference<short>(destination)), this);
	}

	public void CopyTo(Span<int> destination)
	{
		for (int i = 0; i < 64; i++)
		{
			destination[i] = this[i];
		}
	}

	public static Block8x8 Load(ReadOnlySpan<byte> data)
	{
		Unsafe.SkipInit<Block8x8>(out var value);
		value.LoadFrom(data);
		return value;
	}

	public void LoadFrom(ReadOnlySpan<byte> source)
	{
		for (int i = 0; i < 64; i++)
		{
			this[i] = source[i];
		}
	}

	public void LoadFrom(Span<int> source)
	{
		for (int i = 0; i < 64; i++)
		{
			this[i] = (short)source[i];
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		for (int i = 0; i < 64; i++)
		{
			stringBuilder.Append(this[i]);
			if (i < 63)
			{
				stringBuilder.Append(',');
			}
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public nint GetLastNonZeroIndex()
	{
		if (Avx2.IsSupported)
		{
			Vector256<short> zero = Vector256<short>.Zero;
			ref Vector256<short> source = ref Unsafe.As<Block8x8, Vector256<short>>(ref this);
			for (nint num = 3; num >= 0; num--)
			{
				int num2 = Avx2.MoveMask(Avx2.CompareEqual(Unsafe.Add(ref source, num), zero).AsByte());
				if (num2 != -1)
				{
					uint num3 = (uint)BitOperations.LeadingZeroCount((uint)(~num2));
					uint num4 = 15 - num3 / 2;
					return num * 16 + (nint)num4;
				}
			}
			return -1;
		}
		nint num5 = 63;
		ref short source2 = ref Unsafe.As<Block8x8, short>(ref this);
		while (num5 >= 0 && Unsafe.Add(ref source2, num5) == 0)
		{
			num5--;
		}
		return num5;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void TransposeInplace()
	{
		ref short source = ref Unsafe.As<Block8x8, short>(ref this);
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 1), ref Unsafe.Add(ref source, 8));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 2), ref Unsafe.Add(ref source, 16));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 3), ref Unsafe.Add(ref source, 24));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 4), ref Unsafe.Add(ref source, 32));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 5), ref Unsafe.Add(ref source, 40));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 6), ref Unsafe.Add(ref source, 48));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 7), ref Unsafe.Add(ref source, 56));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 10), ref Unsafe.Add(ref source, 17));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 11), ref Unsafe.Add(ref source, 25));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 12), ref Unsafe.Add(ref source, 33));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 13), ref Unsafe.Add(ref source, 41));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 14), ref Unsafe.Add(ref source, 49));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 15), ref Unsafe.Add(ref source, 57));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 19), ref Unsafe.Add(ref source, 26));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 20), ref Unsafe.Add(ref source, 34));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 21), ref Unsafe.Add(ref source, 42));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 22), ref Unsafe.Add(ref source, 50));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 23), ref Unsafe.Add(ref source, 58));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 28), ref Unsafe.Add(ref source, 35));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 29), ref Unsafe.Add(ref source, 43));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 30), ref Unsafe.Add(ref source, 51));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 31), ref Unsafe.Add(ref source, 59));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 37), ref Unsafe.Add(ref source, 44));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 38), ref Unsafe.Add(ref source, 52));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 39), ref Unsafe.Add(ref source, 60));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 46), ref Unsafe.Add(ref source, 53));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 47), ref Unsafe.Add(ref source, 61));
		RuntimeUtility.Swap(ref Unsafe.Add(ref source, 55), ref Unsafe.Add(ref source, 62));
	}

	public static long TotalDifference(ref Block8x8 a, ref Block8x8 b)
	{
		long num = 0L;
		for (int i = 0; i < 64; i++)
		{
			int value = a[i] - b[i];
			num += Math.Abs(value);
		}
		return num;
	}
}
