using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using SixLabors.ImageSharp.Common.Helpers;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

[StructLayout(LayoutKind.Explicit)]
internal struct Block8x8F : IEquatable<Block8x8F>
{
	public const int Size = 64;

	[FieldOffset(0)]
	public Vector4 V0L;

	[FieldOffset(16)]
	public Vector4 V0R;

	[FieldOffset(32)]
	public Vector4 V1L;

	[FieldOffset(48)]
	public Vector4 V1R;

	[FieldOffset(64)]
	public Vector4 V2L;

	[FieldOffset(80)]
	public Vector4 V2R;

	[FieldOffset(96)]
	public Vector4 V3L;

	[FieldOffset(112)]
	public Vector4 V3R;

	[FieldOffset(128)]
	public Vector4 V4L;

	[FieldOffset(144)]
	public Vector4 V4R;

	[FieldOffset(160)]
	public Vector4 V5L;

	[FieldOffset(176)]
	public Vector4 V5R;

	[FieldOffset(192)]
	public Vector4 V6L;

	[FieldOffset(208)]
	public Vector4 V6R;

	[FieldOffset(224)]
	public Vector4 V7L;

	[FieldOffset(240)]
	public Vector4 V7R;

	public const int RowCount = 8;

	[FieldOffset(0)]
	public Vector256<float> V0;

	[FieldOffset(32)]
	public Vector256<float> V1;

	[FieldOffset(64)]
	public Vector256<float> V2;

	[FieldOffset(96)]
	public Vector256<float> V3;

	[FieldOffset(128)]
	public Vector256<float> V4;

	[FieldOffset(160)]
	public Vector256<float> V5;

	[FieldOffset(192)]
	public Vector256<float> V6;

	[FieldOffset(224)]
	public Vector256<float> V7;

	public float this[int idx]
	{
		get
		{
			return this[(uint)idx];
		}
		set
		{
			this[(uint)idx] = value;
		}
	}

	internal float this[nuint idx]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Unsafe.Add(ref Unsafe.As<Block8x8F, float>(ref this), idx);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Unsafe.Add(ref Unsafe.As<Block8x8F, float>(ref this), idx) = value;
		}
	}

	public float this[int x, int y]
	{
		get
		{
			return this[(uint)(y * 8 + x)];
		}
		set
		{
			this[(uint)(y * 8 + x)] = value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Block8x8F Load(Span<float> data)
	{
		return Unsafe.ReadUnaligned<Block8x8F>(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetReference<float>(data)));
	}

	public unsafe void LoadFrom(Span<int> source)
	{
		fixed (Vector4* v0L = &V0L)
		{
			float* ptr = (float*)v0L;
			for (int i = 0; i < 64; i++)
			{
				ptr[i] = source[i];
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ScaledCopyTo(float[] dest)
	{
		Unsafe.WriteUnaligned(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetArrayDataReference<float>(dest)), this);
	}

	public float[] ToArray()
	{
		float[] array = new float[64];
		ScaledCopyTo(array);
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void MultiplyInPlace(float value)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		if (Avx.IsSupported)
		{
			Vector256<float> right = Vector256.Create(value);
			V0 = Avx.Multiply(V0, right);
			V1 = Avx.Multiply(V1, right);
			V2 = Avx.Multiply(V2, right);
			V3 = Avx.Multiply(V3, right);
			V4 = Avx.Multiply(V4, right);
			V5 = Avx.Multiply(V5, right);
			V6 = Avx.Multiply(V6, right);
			V7 = Avx.Multiply(V7, right);
		}
		else
		{
			Vector4 val = default(Vector4);
			((Vector4)(ref val))._002Ector(value);
			V0L *= val;
			V0R *= val;
			V1L *= val;
			V1R *= val;
			V2L *= val;
			V2R *= val;
			V3L *= val;
			V3R *= val;
			V4L *= val;
			V4R *= val;
			V5L *= val;
			V5R *= val;
			V6L *= val;
			V6R *= val;
			V7L *= val;
			V7R *= val;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void MultiplyInPlace(ref Block8x8F other)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		if (Avx.IsSupported)
		{
			V0 = Avx.Multiply(V0, other.V0);
			V1 = Avx.Multiply(V1, other.V1);
			V2 = Avx.Multiply(V2, other.V2);
			V3 = Avx.Multiply(V3, other.V3);
			V4 = Avx.Multiply(V4, other.V4);
			V5 = Avx.Multiply(V5, other.V5);
			V6 = Avx.Multiply(V6, other.V6);
			V7 = Avx.Multiply(V7, other.V7);
			return;
		}
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddInPlace(float value)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		if (Avx.IsSupported)
		{
			Vector256<float> right = Vector256.Create(value);
			V0 = Avx.Add(V0, right);
			V1 = Avx.Add(V1, right);
			V2 = Avx.Add(V2, right);
			V3 = Avx.Add(V3, right);
			V4 = Avx.Add(V4, right);
			V5 = Avx.Add(V5, right);
			V6 = Avx.Add(V6, right);
			V7 = Avx.Add(V7, right);
		}
		else
		{
			Vector4 val = default(Vector4);
			((Vector4)(ref val))._002Ector(value);
			V0L += val;
			V0R += val;
			V1L += val;
			V1R += val;
			V2L += val;
			V2R += val;
			V3L += val;
			V3R += val;
			V4L += val;
			V4R += val;
			V5L += val;
			V5R += val;
			V6L += val;
			V6R += val;
			V7L += val;
			V7R += val;
		}
	}

	public static void Quantize(ref Block8x8F block, ref Block8x8 dest, ref Block8x8F qt)
	{
		if (Avx2.IsSupported)
		{
			MultiplyIntoInt16_Avx2(ref block, ref qt, ref dest);
			ZigZag.ApplyTransposingZigZagOrderingAvx2(ref dest);
			return;
		}
		if (Ssse3.IsSupported)
		{
			MultiplyIntoInt16_Sse2(ref block, ref qt, ref dest);
			ZigZag.ApplyTransposingZigZagOrderingSsse3(ref dest);
			return;
		}
		for (int i = 0; i < 64; i++)
		{
			int idx = ZigZag.TransposingOrder[i];
			float num = block[idx] * qt[idx];
			num += ((num < 0f) ? (-0.5f) : 0.5f);
			dest[i] = (short)num;
		}
	}

	public void RoundInto(ref Block8x8 dest)
	{
		for (int i = 0; i < 64; i++)
		{
			float num = this[i];
			num = ((!(num < 0f)) ? (num + 0.5f) : (num - 0.5f));
			dest[i] = (short)num;
		}
	}

	public Block8x8 RoundAsInt16Block()
	{
		Block8x8 dest = default(Block8x8);
		RoundInto(ref dest);
		return dest;
	}

	public void NormalizeColorsAndRoundInPlace(float maximum)
	{
		if (SimdUtils.HasVector8)
		{
			NormalizeColorsAndRoundInPlaceVector8(maximum);
			return;
		}
		NormalizeColorsInPlace(maximum);
		RoundInPlace();
	}

	public void DE_NormalizeColors(float maximum)
	{
		if (SimdUtils.HasVector8)
		{
			NormalizeColorsAndRoundInPlaceVector8(maximum);
			return;
		}
		NormalizeColorsInPlace(maximum);
		RoundInPlace();
	}

	public void RoundInPlace()
	{
		for (int i = 0; i < 64; i++)
		{
			this[i] = MathF.Round(this[i]);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void LoadFrom(ref Block8x8 source)
	{
		if (SimdUtils.HasVector8)
		{
			LoadFromInt16ExtendedAvx2(ref source);
		}
		else
		{
			LoadFromInt16Scalar(ref source);
		}
	}

	public void LoadFromInt16ExtendedAvx2(ref Block8x8 source)
	{
		ref Vector<short> reference = ref Unsafe.As<Block8x8, Vector<short>>(ref source);
		ref Vector<float> reference2 = ref Unsafe.As<Block8x8F, Vector<float>>(ref this);
		SimdUtils.ExtendedIntrinsics.ConvertToSingle(reference, out var dest, out var dest2);
		reference2 = dest;
		Unsafe.Add(ref reference2, 1) = dest2;
		SimdUtils.ExtendedIntrinsics.ConvertToSingle(Unsafe.Add(ref reference, 1), out dest, out dest2);
		Unsafe.Add(ref reference2, 2) = dest;
		Unsafe.Add(ref reference2, 3) = dest2;
		SimdUtils.ExtendedIntrinsics.ConvertToSingle(Unsafe.Add(ref reference, 2), out dest, out dest2);
		Unsafe.Add(ref reference2, 4) = dest;
		Unsafe.Add(ref reference2, 5) = dest2;
		SimdUtils.ExtendedIntrinsics.ConvertToSingle(Unsafe.Add(ref reference, 3), out dest, out dest2);
		Unsafe.Add(ref reference2, 6) = dest;
		Unsafe.Add(ref reference2, 7) = dest2;
	}

	public bool EqualsToScalar(int value)
	{
		if (Avx2.IsSupported)
		{
			Vector256<int> right = Vector256.Create(value);
			for (nuint num = 0u; num < 8; num++)
			{
				if (Avx2.MoveMask(Avx2.CompareEqual(Avx.ConvertToVector256Int32WithTruncation(Unsafe.Add(ref V0, num)), right).AsByte()) != -1)
				{
					return false;
				}
			}
			return true;
		}
		ref float source = ref Unsafe.As<Block8x8F, float>(ref this);
		for (nuint num2 = 0u; num2 < 64; num2++)
		{
			if ((int)Unsafe.Add(ref source, num2) != value)
			{
				return false;
			}
		}
		return true;
	}

	public bool Equals(Block8x8F other)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		if (V0L == other.V0L && V0R == other.V0R && V1L == other.V1L && V1R == other.V1R && V2L == other.V2L && V2R == other.V2R && V3L == other.V3L && V3R == other.V3R && V4L == other.V4L && V4R == other.V4R && V5L == other.V5L && V5R == other.V5R && V6L == other.V6L && V6R == other.V6R && V7L == other.V7L)
		{
			return V7R == other.V7R;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		return Equals((Block8x8F?)obj);
	}

	public override int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		int value = HashCode.Combine<Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4>(V0L, V1L, V2L, V3L, V4L, V5L, V6L, V7L);
		int value2 = HashCode.Combine<Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4>(V0R, V1R, V2R, V3R, V4R, V5R, V6R, V7R);
		return HashCode.Combine(value, value2);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		for (int i = 0; i < 63; i++)
		{
			stringBuilder.Append(this[i]).Append(',');
		}
		stringBuilder.Append(this[63]).Append(']');
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void TransposeInplace()
	{
		if (Avx.IsSupported)
		{
			TransposeInplace_Avx();
		}
		else
		{
			TransposeInplace_Scalar();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void TransposeInplace_Scalar()
	{
		ref float source = ref Unsafe.As<Block8x8F, float>(ref this);
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector<float> NormalizeAndRound(Vector<float> row, Vector<float> off, Vector<float> max)
	{
		row += off;
		row = Vector.Max(row, Vector<float>.Zero);
		row = Vector.Min(row, max);
		return row.FastRound();
	}

	public void NormalizeColorsInPlace(float maximum)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		Vector4 min = default(Vector4);
		((Vector4)(ref min))._002Ector(0f);
		Vector4 max = default(Vector4);
		((Vector4)(ref max))._002Ector(maximum);
		Vector4 val = default(Vector4);
		((Vector4)(ref val))._002Ector(MathF.Ceiling(maximum * 0.5f));
		V0L = Numerics.Clamp(V0L + val, min, max);
		V0R = Numerics.Clamp(V0R + val, min, max);
		V1L = Numerics.Clamp(V1L + val, min, max);
		V1R = Numerics.Clamp(V1R + val, min, max);
		V2L = Numerics.Clamp(V2L + val, min, max);
		V2R = Numerics.Clamp(V2R + val, min, max);
		V3L = Numerics.Clamp(V3L + val, min, max);
		V3R = Numerics.Clamp(V3R + val, min, max);
		V4L = Numerics.Clamp(V4L + val, min, max);
		V4R = Numerics.Clamp(V4R + val, min, max);
		V5L = Numerics.Clamp(V5L + val, min, max);
		V5R = Numerics.Clamp(V5R + val, min, max);
		V6L = Numerics.Clamp(V6L + val, min, max);
		V6R = Numerics.Clamp(V6R + val, min, max);
		V7L = Numerics.Clamp(V7L + val, min, max);
		V7R = Numerics.Clamp(V7R + val, min, max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void NormalizeColorsAndRoundInPlaceVector8(float maximum)
	{
		Vector<float> off = new Vector<float>(MathF.Ceiling(maximum * 0.5f));
		Vector<float> max = new Vector<float>(maximum);
		ref Vector<float> reference = ref Unsafe.As<Vector4, Vector<float>>(ref V0L);
		reference = NormalizeAndRound(reference, off, max);
		ref Vector<float> reference2 = ref Unsafe.As<Vector4, Vector<float>>(ref V1L);
		reference2 = NormalizeAndRound(reference2, off, max);
		ref Vector<float> reference3 = ref Unsafe.As<Vector4, Vector<float>>(ref V2L);
		reference3 = NormalizeAndRound(reference3, off, max);
		ref Vector<float> reference4 = ref Unsafe.As<Vector4, Vector<float>>(ref V3L);
		reference4 = NormalizeAndRound(reference4, off, max);
		ref Vector<float> reference5 = ref Unsafe.As<Vector4, Vector<float>>(ref V4L);
		reference5 = NormalizeAndRound(reference5, off, max);
		ref Vector<float> reference6 = ref Unsafe.As<Vector4, Vector<float>>(ref V5L);
		reference6 = NormalizeAndRound(reference6, off, max);
		ref Vector<float> reference7 = ref Unsafe.As<Vector4, Vector<float>>(ref V6L);
		reference7 = NormalizeAndRound(reference7, off, max);
		ref Vector<float> reference8 = ref Unsafe.As<Vector4, Vector<float>>(ref V7L);
		reference8 = NormalizeAndRound(reference8, off, max);
	}

	public void LoadFromInt16Scalar(ref Block8x8 source)
	{
		ref short source2 = ref Unsafe.As<Block8x8, short>(ref source);
		V0L.X = Unsafe.Add(ref source2, 0);
		V0L.Y = Unsafe.Add(ref source2, 1);
		V0L.Z = Unsafe.Add(ref source2, 2);
		V0L.W = Unsafe.Add(ref source2, 3);
		V0R.X = Unsafe.Add(ref source2, 4);
		V0R.Y = Unsafe.Add(ref source2, 5);
		V0R.Z = Unsafe.Add(ref source2, 6);
		V0R.W = Unsafe.Add(ref source2, 7);
		V1L.X = Unsafe.Add(ref source2, 8);
		V1L.Y = Unsafe.Add(ref source2, 9);
		V1L.Z = Unsafe.Add(ref source2, 10);
		V1L.W = Unsafe.Add(ref source2, 11);
		V1R.X = Unsafe.Add(ref source2, 12);
		V1R.Y = Unsafe.Add(ref source2, 13);
		V1R.Z = Unsafe.Add(ref source2, 14);
		V1R.W = Unsafe.Add(ref source2, 15);
		V2L.X = Unsafe.Add(ref source2, 16);
		V2L.Y = Unsafe.Add(ref source2, 17);
		V2L.Z = Unsafe.Add(ref source2, 18);
		V2L.W = Unsafe.Add(ref source2, 19);
		V2R.X = Unsafe.Add(ref source2, 20);
		V2R.Y = Unsafe.Add(ref source2, 21);
		V2R.Z = Unsafe.Add(ref source2, 22);
		V2R.W = Unsafe.Add(ref source2, 23);
		V3L.X = Unsafe.Add(ref source2, 24);
		V3L.Y = Unsafe.Add(ref source2, 25);
		V3L.Z = Unsafe.Add(ref source2, 26);
		V3L.W = Unsafe.Add(ref source2, 27);
		V3R.X = Unsafe.Add(ref source2, 28);
		V3R.Y = Unsafe.Add(ref source2, 29);
		V3R.Z = Unsafe.Add(ref source2, 30);
		V3R.W = Unsafe.Add(ref source2, 31);
		V4L.X = Unsafe.Add(ref source2, 32);
		V4L.Y = Unsafe.Add(ref source2, 33);
		V4L.Z = Unsafe.Add(ref source2, 34);
		V4L.W = Unsafe.Add(ref source2, 35);
		V4R.X = Unsafe.Add(ref source2, 36);
		V4R.Y = Unsafe.Add(ref source2, 37);
		V4R.Z = Unsafe.Add(ref source2, 38);
		V4R.W = Unsafe.Add(ref source2, 39);
		V5L.X = Unsafe.Add(ref source2, 40);
		V5L.Y = Unsafe.Add(ref source2, 41);
		V5L.Z = Unsafe.Add(ref source2, 42);
		V5L.W = Unsafe.Add(ref source2, 43);
		V5R.X = Unsafe.Add(ref source2, 44);
		V5R.Y = Unsafe.Add(ref source2, 45);
		V5R.Z = Unsafe.Add(ref source2, 46);
		V5R.W = Unsafe.Add(ref source2, 47);
		V6L.X = Unsafe.Add(ref source2, 48);
		V6L.Y = Unsafe.Add(ref source2, 49);
		V6L.Z = Unsafe.Add(ref source2, 50);
		V6L.W = Unsafe.Add(ref source2, 51);
		V6R.X = Unsafe.Add(ref source2, 52);
		V6R.Y = Unsafe.Add(ref source2, 53);
		V6R.Z = Unsafe.Add(ref source2, 54);
		V6R.W = Unsafe.Add(ref source2, 55);
		V7L.X = Unsafe.Add(ref source2, 56);
		V7L.Y = Unsafe.Add(ref source2, 57);
		V7L.Z = Unsafe.Add(ref source2, 58);
		V7L.W = Unsafe.Add(ref source2, 59);
		V7R.X = Unsafe.Add(ref source2, 60);
		V7R.Y = Unsafe.Add(ref source2, 61);
		V7R.Z = Unsafe.Add(ref source2, 62);
		V7R.W = Unsafe.Add(ref source2, 63);
	}

	private static void MultiplyIntoInt16_Avx2(ref Block8x8F a, ref Block8x8F b, ref Block8x8 dest)
	{
		ref Vector256<float> v = ref a.V0;
		ref Vector256<float> v2 = ref b.V0;
		ref Vector256<short> v3 = ref dest.V01;
		Vector256<int> control = Vector256.Create(0, 1, 4, 5, 2, 3, 6, 7);
		for (nuint num = 0u; num < 8; num += 2)
		{
			Vector256<int> left = Avx.ConvertToVector256Int32(Avx.Multiply(Unsafe.Add(ref v, num + 0), Unsafe.Add(ref v2, num + 0)));
			Vector256<int> right = Avx.ConvertToVector256Int32(Avx.Multiply(Unsafe.Add(ref v, num + 1), Unsafe.Add(ref v2, num + 1)));
			Vector256<short> vector = Avx2.PackSignedSaturate(left, right);
			vector = Avx2.PermuteVar8x32(vector.AsInt32(), control).AsInt16();
			Unsafe.Add(ref v3, num / 2) = vector;
		}
	}

	private static void MultiplyIntoInt16_Sse2(ref Block8x8F a, ref Block8x8F b, ref Block8x8 dest)
	{
		ref Vector128<float> source = ref Unsafe.As<Block8x8F, Vector128<float>>(ref a);
		ref Vector128<float> source2 = ref Unsafe.As<Block8x8F, Vector128<float>>(ref b);
		ref Vector128<short> source3 = ref Unsafe.As<Block8x8, Vector128<short>>(ref dest);
		for (nuint num = 0u; num < 16; num += 2)
		{
			Vector128<int> left = Sse2.ConvertToVector128Int32(Sse.Multiply(Unsafe.Add(ref source, num + 0), Unsafe.Add(ref source2, num + 0)));
			Vector128<int> right = Sse2.ConvertToVector128Int32(Sse.Multiply(Unsafe.Add(ref source, num + 1), Unsafe.Add(ref source2, num + 1)));
			Vector128<short> vector = Sse2.PackSignedSaturate(left, right);
			Unsafe.Add(ref source3, num / 2) = vector;
		}
	}

	private void TransposeInplace_Avx()
	{
		Vector256<float> left = Avx.InsertVector128(V0, Unsafe.As<Vector4, Vector128<float>>(ref V4L), 1);
		Vector256<float> right = Avx.InsertVector128(V1, Unsafe.As<Vector4, Vector128<float>>(ref V5L), 1);
		Vector256<float> left2 = Avx.InsertVector128(V2, Unsafe.As<Vector4, Vector128<float>>(ref V6L), 1);
		Vector256<float> right2 = Avx.InsertVector128(V3, Unsafe.As<Vector4, Vector128<float>>(ref V7L), 1);
		Vector256<float> left3 = Avx.InsertVector128(Unsafe.As<Vector4, Vector128<float>>(ref V0R).ToVector256(), Unsafe.As<Vector4, Vector128<float>>(ref V4R), 1);
		Vector256<float> right3 = Avx.InsertVector128(Unsafe.As<Vector4, Vector128<float>>(ref V1R).ToVector256(), Unsafe.As<Vector4, Vector128<float>>(ref V5R), 1);
		Vector256<float> left4 = Avx.InsertVector128(Unsafe.As<Vector4, Vector128<float>>(ref V2R).ToVector256(), Unsafe.As<Vector4, Vector128<float>>(ref V6R), 1);
		Vector256<float> right4 = Avx.InsertVector128(Unsafe.As<Vector4, Vector128<float>>(ref V3R).ToVector256(), Unsafe.As<Vector4, Vector128<float>>(ref V7R), 1);
		Vector256<float> vector = Avx.UnpackLow(left, right);
		Vector256<float> vector2 = Avx.UnpackLow(left2, right2);
		Vector256<float> right5 = Avx.Shuffle(vector, vector2, 78);
		V0 = Avx.Blend(vector, right5, 204);
		V1 = Avx.Blend(vector2, right5, 51);
		Vector256<float> vector3 = Avx.UnpackLow(left3, right3);
		Vector256<float> vector4 = Avx.UnpackLow(left4, right4);
		right5 = Avx.Shuffle(vector3, vector4, 78);
		V4 = Avx.Blend(vector3, right5, 204);
		V5 = Avx.Blend(vector4, right5, 51);
		Vector256<float> vector5 = Avx.UnpackHigh(left, right);
		Vector256<float> vector6 = Avx.UnpackHigh(left2, right2);
		right5 = Avx.Shuffle(vector5, vector6, 78);
		V2 = Avx.Blend(vector5, right5, 204);
		V3 = Avx.Blend(vector6, right5, 51);
		Vector256<float> vector7 = Avx.UnpackHigh(left3, right3);
		Vector256<float> vector8 = Avx.UnpackHigh(left4, right4);
		right5 = Avx.Shuffle(vector7, vector8, 78);
		V6 = Avx.Blend(vector7, right5, 204);
		V7 = Avx.Blend(vector8, right5, 51);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ScaledCopyFrom(ref float areaOrigin, int areaStride)
	{
		CopyFrom1x1Scale(ref Unsafe.As<float, byte>(ref areaOrigin), ref Unsafe.As<Block8x8F, byte>(ref this), areaStride);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ScaledCopyTo(ref float areaOrigin, int areaStride, int horizontalScale, int verticalScale)
	{
		if (horizontalScale == 1 && verticalScale == 1)
		{
			CopyTo1x1Scale(ref Unsafe.As<Block8x8F, byte>(ref this), ref Unsafe.As<float, byte>(ref areaOrigin), areaStride);
		}
		else if (horizontalScale == 2 && verticalScale == 2)
		{
			CopyTo2x2Scale(ref areaOrigin, areaStride);
		}
		else
		{
			CopyArbitraryScale(ref areaOrigin, (uint)areaStride, (uint)horizontalScale, (uint)verticalScale);
		}
	}

	private void CopyTo2x2Scale(ref float areaOrigin, int areaStride)
	{
		ref Vector2 destBase = ref Unsafe.As<float, Vector2>(ref areaOrigin);
		nuint destStride = (uint)areaStride / 2u;
		WidenCopyRowImpl2x(ref V0L, ref destBase, 0u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 1u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 2u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 3u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 4u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 5u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 6u, destStride);
		WidenCopyRowImpl2x(ref V0L, ref destBase, 7u, destStride);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static void WidenCopyRowImpl2x(ref Vector4 selfBase, ref Vector2 source, nuint row, nuint num2)
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			ref Vector4 reference = ref Unsafe.Add(ref selfBase, 2 * row);
			ref Vector4 reference2 = ref Unsafe.Add(ref reference, 1);
			nuint num = 2 * row * num2;
			ref Vector4 reference3 = ref Unsafe.As<Vector2, Vector4>(ref Unsafe.Add(ref source, num));
			ref Vector4 reference4 = ref Unsafe.As<Vector2, Vector4>(ref Unsafe.Add(ref source, num + num2));
			Vector4 val = default(Vector4);
			((Vector4)(ref val))._002Ector(reference.X);
			val.Z = reference.Y;
			val.W = reference.Y;
			Vector4 val2 = default(Vector4);
			((Vector4)(ref val2))._002Ector(reference.Z);
			val2.Z = reference.W;
			val2.W = reference.W;
			Vector4 val3 = default(Vector4);
			((Vector4)(ref val3))._002Ector(reference2.X);
			val3.Z = reference2.Y;
			val3.W = reference2.Y;
			Vector4 val4 = default(Vector4);
			((Vector4)(ref val4))._002Ector(reference2.Z);
			val4.Z = reference2.W;
			val4.W = reference2.W;
			reference3 = val;
			Unsafe.Add(ref reference3, 1) = val2;
			Unsafe.Add(ref reference3, 2) = val3;
			Unsafe.Add(ref reference3, 3) = val4;
			reference4 = val;
			Unsafe.Add(ref reference4, 1) = val2;
			Unsafe.Add(ref reference4, 2) = val3;
			Unsafe.Add(ref reference4, 3) = val4;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CopyArbitraryScale(ref float areaOrigin, uint areaStride, uint horizontalScale, uint verticalScale)
	{
		for (nuint num = 0u; num < 8; num++)
		{
			nuint num2 = num * verticalScale;
			nuint num3 = num * 8;
			for (nuint num4 = 0u; num4 < 8; num4++)
			{
				nuint num5 = num4 * horizontalScale;
				float num6 = this[(int)(num3 + num4)];
				nuint num7 = num2 * areaStride + num5;
				nuint num8 = 0u;
				while (num8 < verticalScale)
				{
					for (nuint num9 = 0u; num9 < horizontalScale; num9++)
					{
						Unsafe.Add(ref areaOrigin, num7 + num9) = num6;
					}
					num8++;
					num7 += areaStride;
				}
			}
		}
	}

	private static void CopyTo1x1Scale(ref byte origin, ref byte dest, int areaStride)
	{
		int destStride = areaStride * 4;
		CopyRowImpl(ref origin, ref dest, destStride, 0);
		CopyRowImpl(ref origin, ref dest, destStride, 1);
		CopyRowImpl(ref origin, ref dest, destStride, 2);
		CopyRowImpl(ref origin, ref dest, destStride, 3);
		CopyRowImpl(ref origin, ref dest, destStride, 4);
		CopyRowImpl(ref origin, ref dest, destStride, 5);
		CopyRowImpl(ref origin, ref dest, destStride, 6);
		CopyRowImpl(ref origin, ref dest, destStride, 7);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static void CopyRowImpl(ref byte source, ref byte reference, int num, int row)
		{
			source = ref Unsafe.Add(ref source, (uint)(row * 8 * 4));
			reference = ref Unsafe.Add(ref reference, (uint)(row * num));
			Unsafe.CopyBlock(ref reference, ref source, 32u);
		}
	}

	private static void CopyFrom1x1Scale(ref byte origin, ref byte dest, int areaStride)
	{
		int sourceStride = areaStride * 4;
		CopyRowImpl(ref origin, ref dest, sourceStride, 0);
		CopyRowImpl(ref origin, ref dest, sourceStride, 1);
		CopyRowImpl(ref origin, ref dest, sourceStride, 2);
		CopyRowImpl(ref origin, ref dest, sourceStride, 3);
		CopyRowImpl(ref origin, ref dest, sourceStride, 4);
		CopyRowImpl(ref origin, ref dest, sourceStride, 5);
		CopyRowImpl(ref origin, ref dest, sourceStride, 6);
		CopyRowImpl(ref origin, ref dest, sourceStride, 7);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static void CopyRowImpl(ref byte source, ref byte reference, int num, int row)
		{
			source = ref Unsafe.Add(ref source, (uint)(row * num));
			reference = ref Unsafe.Add(ref reference, (uint)(row * 8 * 4));
			Unsafe.CopyBlock(ref reference, ref source, 32u);
		}
	}
}
