using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal static class FloatingPointDCT
{
	private static readonly Vector4 mm128_F_0_7071 = new Vector4(0.70710677f);

	private static readonly Vector4 mm128_F_0_3826 = new Vector4(0.38268343f);

	private static readonly Vector4 mm128_F_0_5411 = new Vector4(0.5411961f);

	private static readonly Vector4 mm128_F_1_3065 = new Vector4(1.306563f);

	private static readonly Vector4 mm128_F_1_4142 = new Vector4(1.4142135f);

	private static readonly Vector4 mm128_F_1_8477 = new Vector4(1.847759f);

	private static readonly Vector4 mm128_F_n1_0823 = new Vector4(-1.0823922f);

	private static readonly Vector4 mm128_F_n2_6131 = new Vector4(-2.613126f);

	private static readonly float[] AdjustmentCoefficients = new float[64]
	{
		1f, 1.3870399f, 1.306563f, 1.1758755f, 1f, 0.78569496f, 0.5411961f, 0.27589938f, 1.3870399f, 1.9238797f,
		1.812255f, 1.6309863f, 1.3870399f, 1.0897902f, 0.7506606f, 0.38268346f, 1.306563f, 1.812255f, 1.707107f, 1.5363555f,
		1.306563f, 1.02656f, 0.7071068f, 0.36047992f, 1.1758755f, 1.6309863f, 1.5363555f, 1.3826833f, 1.1758755f, 0.9238795f,
		0.63637924f, 0.32442334f, 1f, 1.3870399f, 1.306563f, 1.1758755f, 1f, 0.78569496f, 0.5411961f, 0.27589938f,
		0.78569496f, 1.0897902f, 1.02656f, 0.9238795f, 0.78569496f, 0.61731654f, 0.42521507f, 0.21677275f, 0.5411961f, 0.7506606f,
		0.7071068f, 0.63637924f, 0.5411961f, 0.42521507f, 0.29289323f, 0.14931567f, 0.27589938f, 0.38268346f, 0.36047992f, 0.32442334f,
		0.27589938f, 0.21677275f, 0.14931567f, 0.076120466f
	};

	public static void AdjustToIDCT(ref Block8x8F quantTable)
	{
		ref float source = ref Unsafe.As<Block8x8F, float>(ref quantTable);
		ref float reference = ref MemoryMarshal.GetReference<float>((Span<float>)AdjustmentCoefficients);
		for (nuint num = 0u; num < 64; num++)
		{
			ref float reference2 = ref Unsafe.Add(ref source, num);
			reference2 = 0.125f * reference2 * Unsafe.Add(ref reference, num);
		}
		quantTable.TransposeInplace();
	}

	public static void AdjustToFDCT(ref Block8x8F quantTable)
	{
		ref float source = ref Unsafe.As<Block8x8F, float>(ref quantTable);
		ref float reference = ref MemoryMarshal.GetReference<float>((Span<float>)AdjustmentCoefficients);
		for (nuint num = 0u; num < 64; num++)
		{
			ref float reference2 = ref Unsafe.Add(ref source, num);
			reference2 = 0.125f / (reference2 * Unsafe.Add(ref reference, num));
		}
		quantTable.TransposeInplace();
	}

	public static void TransformIDCT(ref Block8x8F block)
	{
		if (Avx.IsSupported)
		{
			IDCT8x8_Avx(ref block);
		}
		else
		{
			IDCT_Vector4(ref block);
		}
	}

	public static void TransformFDCT(ref Block8x8F block)
	{
		if (Avx.IsSupported)
		{
			FDCT8x8_Avx(ref block);
		}
		else
		{
			FDCT_Vector4(ref block);
		}
	}

	private static void IDCT_Vector4(ref Block8x8F transposedBlock)
	{
		IDCT8x4_Vector(ref transposedBlock.V0L);
		IDCT8x4_Vector(ref transposedBlock.V0R);
		transposedBlock.TransposeInplace();
		IDCT8x4_Vector(ref transposedBlock.V0L);
		IDCT8x4_Vector(ref transposedBlock.V0R);
		static void IDCT8x4_Vector(ref Vector4 vecRef)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			Vector4 val = Unsafe.Add(ref vecRef, 0);
			Vector4 val2 = Unsafe.Add(ref vecRef, 4);
			Vector4 val3 = Unsafe.Add(ref vecRef, 8);
			Vector4 val4 = Unsafe.Add(ref vecRef, 12);
			Vector4 val5 = val;
			Vector4 val6 = val5 + val3;
			Vector4 val7 = val5 - val3;
			Vector4 val8 = val2 + val4;
			Vector4 val9 = (val2 - val4) * mm128_F_1_4142 - val8;
			val = val6 + val8;
			val4 = val6 - val8;
			val2 = val7 + val9;
			val3 = val7 - val9;
			Vector4 val10 = Unsafe.Add(ref vecRef, 2);
			Vector4 val11 = Unsafe.Add(ref vecRef, 6);
			Vector4 val12 = Unsafe.Add(ref vecRef, 10);
			Vector4 val13 = Unsafe.Add(ref vecRef, 14);
			Vector4 val14 = val12 + val11;
			Vector4 val15 = val12 - val11;
			Vector4 val16 = val10 + val13;
			Vector4 val17 = val10 - val13;
			val13 = val16 + val14;
			val7 = (val16 - val14) * mm128_F_1_4142;
			val5 = (val15 + val17) * mm128_F_1_8477;
			val6 = val17 * mm128_F_n1_0823 + val5;
			val9 = val15 * mm128_F_n2_6131 + val5;
			val12 = val9 - val13;
			val11 = val7 - val12;
			val10 = val6 - val11;
			Unsafe.Add(ref vecRef, 0) = val + val13;
			Unsafe.Add(ref vecRef, 14) = val - val13;
			Unsafe.Add(ref vecRef, 2) = val2 + val12;
			Unsafe.Add(ref vecRef, 12) = val2 - val12;
			Unsafe.Add(ref vecRef, 4) = val3 + val11;
			Unsafe.Add(ref vecRef, 10) = val3 - val11;
			Unsafe.Add(ref vecRef, 6) = val4 + val10;
			Unsafe.Add(ref vecRef, 8) = val4 - val10;
		}
	}

	private static void FDCT_Vector4(ref Block8x8F block)
	{
		FDCT8x4_Vector(ref block.V0L);
		FDCT8x4_Vector(ref block.V0R);
		block.TransposeInplace();
		FDCT8x4_Vector(ref block.V0L);
		FDCT8x4_Vector(ref block.V0R);
		static void FDCT8x4_Vector(ref Vector4 vecRef)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			Vector4 val = Unsafe.Add(ref vecRef, 0) + Unsafe.Add(ref vecRef, 14);
			Vector4 val2 = Unsafe.Add(ref vecRef, 0) - Unsafe.Add(ref vecRef, 14);
			Vector4 val3 = Unsafe.Add(ref vecRef, 2) + Unsafe.Add(ref vecRef, 12);
			Vector4 val4 = Unsafe.Add(ref vecRef, 2) - Unsafe.Add(ref vecRef, 12);
			Vector4 val5 = Unsafe.Add(ref vecRef, 4) + Unsafe.Add(ref vecRef, 10);
			Vector4 val6 = Unsafe.Add(ref vecRef, 4) - Unsafe.Add(ref vecRef, 10);
			Vector4 val7 = Unsafe.Add(ref vecRef, 6) + Unsafe.Add(ref vecRef, 8);
			Vector4 val8 = Unsafe.Add(ref vecRef, 6) - Unsafe.Add(ref vecRef, 8);
			Vector4 val9 = val + val7;
			Vector4 val10 = val - val7;
			Vector4 val11 = val3 + val5;
			Vector4 val12 = val3 - val5;
			Unsafe.Add(ref vecRef, 0) = val9 + val11;
			Unsafe.Add(ref vecRef, 8) = val9 - val11;
			Vector4 val13 = (val12 + val10) * mm128_F_0_7071;
			Unsafe.Add(ref vecRef, 4) = val10 + val13;
			Unsafe.Add(ref vecRef, 12) = val10 - val13;
			val9 = val8 + val6;
			val11 = val6 + val4;
			val12 = val4 + val2;
			Vector4 val14 = (val9 - val12) * mm128_F_0_3826;
			Vector4 val15 = mm128_F_0_5411 * val9 + val14;
			Vector4 val16 = mm128_F_1_3065 * val12 + val14;
			Vector4 val17 = val11 * mm128_F_0_7071;
			Vector4 val18 = val2 + val17;
			Vector4 val19 = val2 - val17;
			Unsafe.Add(ref vecRef, 10) = val19 + val15;
			Unsafe.Add(ref vecRef, 6) = val19 - val15;
			Unsafe.Add(ref vecRef, 2) = val18 + val16;
			Unsafe.Add(ref vecRef, 14) = val18 - val16;
		}
	}

	private static void FDCT8x8_Avx(ref Block8x8F block)
	{
		FDCT8x8_1D_Avx(ref block);
		block.TransposeInplace();
		FDCT8x8_1D_Avx(ref block);
		static void FDCT8x8_1D_Avx(ref Block8x8F reference)
		{
			Vector256<float> left = Avx.Add(reference.V0, reference.V7);
			Vector256<float> vector = Avx.Subtract(reference.V0, reference.V7);
			Vector256<float> left2 = Avx.Add(reference.V1, reference.V6);
			Vector256<float> vector2 = Avx.Subtract(reference.V1, reference.V6);
			Vector256<float> right = Avx.Add(reference.V2, reference.V5);
			Vector256<float> vector3 = Avx.Subtract(reference.V2, reference.V5);
			Vector256<float> right2 = Avx.Add(reference.V3, reference.V4);
			Vector256<float> left3 = Avx.Subtract(reference.V3, reference.V4);
			Vector256<float> left4 = Avx.Add(left, right2);
			Vector256<float> vector4 = Avx.Subtract(left, right2);
			Vector256<float> right3 = Avx.Add(left2, right);
			Vector256<float> left5 = Avx.Subtract(left2, right);
			reference.V0 = Avx.Add(left4, right3);
			reference.V4 = Avx.Subtract(left4, right3);
			Vector256<float> right4 = Vector256.Create(0.70710677f);
			Vector256<float> right5 = Avx.Multiply(Avx.Add(left5, vector4), right4);
			reference.V2 = Avx.Add(vector4, right5);
			reference.V6 = Avx.Subtract(vector4, right5);
			left4 = Avx.Add(left3, vector3);
			right3 = Avx.Add(vector3, vector2);
			left5 = Avx.Add(vector2, vector);
			Vector256<float> va = Avx.Multiply(Avx.Subtract(left4, left5), Vector256.Create(0.38268343f));
			Vector256<float> right6 = SimdUtils.HwIntrinsics.MultiplyAdd(va, Vector256.Create(0.5411961f), left4);
			Vector256<float> right7 = SimdUtils.HwIntrinsics.MultiplyAdd(va, Vector256.Create(1.306563f), left5);
			Vector256<float> right8 = Avx.Multiply(right3, right4);
			Vector256<float> left6 = Avx.Add(vector, right8);
			Vector256<float> left7 = Avx.Subtract(vector, right8);
			reference.V5 = Avx.Add(left7, right6);
			reference.V3 = Avx.Subtract(left7, right6);
			reference.V1 = Avx.Add(left6, right7);
			reference.V7 = Avx.Subtract(left6, right7);
		}
	}

	private static void IDCT8x8_Avx(ref Block8x8F transposedBlock)
	{
		IDCT8x8_1D_Avx(ref transposedBlock);
		transposedBlock.TransposeInplace();
		IDCT8x8_1D_Avx(ref transposedBlock);
		static void IDCT8x8_1D_Avx(ref Block8x8F block)
		{
			Vector256<float> v = block.V0;
			Vector256<float> v2 = block.V2;
			Vector256<float> v3 = block.V4;
			Vector256<float> v4 = block.V6;
			Vector256<float> left = v;
			Vector256<float> left2 = Avx.Add(left, v3);
			Vector256<float> left3 = Avx.Subtract(left, v3);
			Vector256<float> vector = Vector256.Create(1.4142135f);
			Vector256<float> vector2 = Avx.Add(v2, v4);
			Vector256<float> right = SimdUtils.HwIntrinsics.MultiplySubtract(vector2, Avx.Subtract(v2, v4), vector);
			v = Avx.Add(left2, vector2);
			v4 = Avx.Subtract(left2, vector2);
			v2 = Avx.Add(left3, right);
			v3 = Avx.Subtract(left3, right);
			Vector256<float> v5 = block.V1;
			Vector256<float> v6 = block.V3;
			Vector256<float> v7 = block.V5;
			Vector256<float> v8 = block.V7;
			Vector256<float> right2 = Avx.Add(v7, v6);
			Vector256<float> vector3 = Avx.Subtract(v7, v6);
			Vector256<float> left4 = Avx.Add(v5, v8);
			Vector256<float> vector4 = Avx.Subtract(v5, v8);
			v8 = Avx.Add(left4, right2);
			Vector256<float> left5 = Avx.Multiply(Avx.Subtract(left4, right2), vector);
			Vector256<float> va = Avx.Multiply(Avx.Add(vector3, vector4), Vector256.Create(1.847759f));
			left2 = SimdUtils.HwIntrinsics.MultiplyAdd(va, vector4, Vector256.Create(-1.0823922f));
			right = SimdUtils.HwIntrinsics.MultiplyAdd(va, vector3, Vector256.Create(-2.613126f));
			v7 = Avx.Subtract(right, v8);
			v6 = Avx.Subtract(left5, v7);
			v5 = Avx.Subtract(left2, v6);
			block.V0 = Avx.Add(v, v8);
			block.V7 = Avx.Subtract(v, v8);
			block.V1 = Avx.Add(v2, v7);
			block.V6 = Avx.Subtract(v2, v7);
			block.V2 = Avx.Add(v3, v6);
			block.V5 = Avx.Subtract(v3, v6);
			block.V3 = Avx.Add(v4, v5);
			block.V4 = Avx.Subtract(v4, v5);
		}
	}
}
