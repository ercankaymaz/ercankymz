using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using SixLabors.ImageSharp.Common.Helpers;

namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal static class QuantEnc
{
	private static readonly ushort[] WeightY = new ushort[16]
	{
		38, 32, 20, 9, 32, 28, 17, 7, 20, 17,
		10, 4, 9, 7, 4, 2
	};

	private const int MaxLevel = 2047;

	private const int C1 = 7;

	private const int C2 = 8;

	private const int DSHIFT = 4;

	private const int DSCALE = 1;

	private static ReadOnlySpan<byte> Zigzag => new byte[16]
	{
		0, 1, 4, 8, 5, 2, 3, 6, 9, 12,
		13, 10, 7, 11, 14, 15
	};

	public static void PickBestIntra16(Vp8EncIterator it, ref Vp8ModeScore rd, Vp8SegmentInfo[] segmentInfos, Vp8EncProba proba)
	{
		Vp8SegmentInfo vp8SegmentInfo = segmentInfos[it.CurrentMacroBlockInfo.Segment];
		int lambdaI = vp8SegmentInfo.LambdaI16;
		int tLambda = vp8SegmentInfo.TLambda;
		Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvIn, 0);
		Span<int> scratch = it.Scratch3;
		Vp8ModeScore vp8ModeScore = new Vp8ModeScore();
		Vp8Residual res = new Vp8Residual();
		Vp8ModeScore b = vp8ModeScore;
		Vp8ModeScore a = rd;
		bool flag = IsFlatSource16(span);
		rd.ModeI16 = -1;
		for (int i = 0; i < 4; i++)
		{
			Span<byte> span2 = MemoryExtensions.AsSpan<byte>(it.YuvOut2, 0);
			b.ModeI16 = i;
			b.Nz = (uint)ReconstructIntra16(it, vp8SegmentInfo, b, span2, i);
			b.D = LossyUtils.Vp8_Sse16x16(span, span2);
			b.SD = ((tLambda != 0) ? Mult8B(tLambda, LossyUtils.Vp8Disto16X16(span, span2, WeightY, scratch)) : 0);
			b.H = WebpConstants.Vp8FixedCostsI16[i];
			b.R = it.GetCostLuma16(b, proba, res);
			if (flag)
			{
				flag = IsFlat(b.YAcLevels, 16, 0);
				if (flag)
				{
					b.D *= 2L;
					b.SD *= 2L;
				}
			}
			b.SetRdScore(lambdaI);
			if (i == 0 || b.Score < a.Score)
			{
				RuntimeUtility.Swap(ref a, ref b);
				it.SwapOut();
			}
		}
		if (a != rd)
		{
			rd = a;
		}
		rd.SetRdScore(vp8SegmentInfo.LambdaMode);
		it.SetIntra16Mode(rd.ModeI16);
		if ((rd.Nz & 0x100FFFF) == 16777216 && rd.D > vp8SegmentInfo.MinDisto)
		{
			vp8SegmentInfo.StoreMaxDelta(rd.YDcLevels);
		}
	}

	public static bool PickBestIntra4(Vp8EncIterator it, ref Vp8ModeScore rd, Vp8SegmentInfo[] segmentInfos, Vp8EncProba proba, int maxI4HeaderBits)
	{
		Vp8SegmentInfo vp8SegmentInfo = segmentInfos[it.CurrentMacroBlockInfo.Segment];
		int lambdaI = vp8SegmentInfo.LambdaI4;
		int tLambda = vp8SegmentInfo.TLambda;
		Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvIn, 0);
		Span<byte> yuvOut = MemoryExtensions.AsSpan<byte>(it.YuvOut2, 0);
		Span<int> scratch = it.Scratch3;
		int num = 0;
		Vp8ModeScore vp8ModeScore = new Vp8ModeScore();
		if (maxI4HeaderBits == 0)
		{
			return false;
		}
		vp8ModeScore.InitScore();
		vp8ModeScore.H = 211L;
		vp8ModeScore.SetRdScore(vp8SegmentInfo.LambdaMode);
		it.StartI4();
		Vp8ModeScore vp8ModeScore2 = new Vp8ModeScore();
		Vp8ModeScore vp8ModeScore3 = new Vp8ModeScore();
		Vp8Residual res = new Vp8Residual();
		Span<short> levels = stackalloc short[16];
		do
		{
			vp8ModeScore2.Clear();
			int num2 = -1;
			ref Span<byte> reference = ref span;
			int num3 = WebpLookupTables.Vp8Scan[it.I4];
			Span<byte> span2 = reference.Slice(num3, reference.Length - num3);
			short[] costModeI = it.GetCostModeI4(rd.ModesI4);
			reference = ref yuvOut;
			num3 = WebpLookupTables.Vp8Scan[it.I4];
			Span<byte> b = reference.Slice(num3, reference.Length - num3);
			Span<byte> a = MemoryExtensions.AsSpan<byte>(it.Scratch);
			a.Clear();
			vp8ModeScore2.InitScore();
			it.MakeIntra4Preds();
			for (int i = 0; i < 10; i++)
			{
				vp8ModeScore3.Clear();
				levels.Clear();
				vp8ModeScore3.Nz = (uint)ReconstructIntra4(it, vp8SegmentInfo, levels, span2, a, i);
				vp8ModeScore3.D = LossyUtils.Vp8_Sse4x4(span2, a);
				vp8ModeScore3.SD = ((tLambda != 0) ? Mult8B(tLambda, LossyUtils.Vp8Disto4X4(span2, a, WeightY, scratch)) : 0);
				vp8ModeScore3.H = costModeI[i];
				if (i > 0 && IsFlat(levels, 1, 3))
				{
					vp8ModeScore3.R = 140L;
				}
				else
				{
					vp8ModeScore3.R = 0L;
				}
				vp8ModeScore3.SetRdScore(lambdaI);
				if (num2 < 0 || vp8ModeScore3.Score < vp8ModeScore2.Score)
				{
					vp8ModeScore3.R += it.GetCostLuma4(levels, proba, res);
					vp8ModeScore3.SetRdScore(lambdaI);
					if (num2 < 0 || vp8ModeScore3.Score < vp8ModeScore2.Score)
					{
						vp8ModeScore2.CopyScore(vp8ModeScore3);
						num2 = i;
						RuntimeUtility.Swap(ref a, ref b);
						levels.CopyTo(MemoryExtensions.AsSpan<short>(vp8ModeScore.YAcLevels, it.I4 * 16, 16));
					}
				}
			}
			vp8ModeScore2.SetRdScore(vp8SegmentInfo.LambdaMode);
			vp8ModeScore.AddScore(vp8ModeScore2);
			if (vp8ModeScore.Score >= rd.Score)
			{
				return false;
			}
			num += (int)vp8ModeScore2.H;
			if (num > maxI4HeaderBits)
			{
				return false;
			}
			Span<byte> src = b;
			reference = ref yuvOut;
			num3 = WebpLookupTables.Vp8Scan[it.I4];
			LossyUtils.Vp8Copy4X4(src, reference.Slice(num3, reference.Length - num3));
			rd.ModesI4[it.I4] = (byte)num2;
			it.TopNz[it.I4 & 3] = (it.LeftNz[it.I4 >> 2] = ((vp8ModeScore2.Nz != 0) ? 1 : 0));
		}
		while (it.RotateI4(yuvOut));
		rd.CopyScore(vp8ModeScore);
		it.SetIntra4Mode(rd.ModesI4);
		it.SwapOut();
		MemoryExtensions.AsSpan<short>(vp8ModeScore.YAcLevels).CopyTo(rd.YAcLevels);
		return true;
	}

	public static void PickBestUv(Vp8EncIterator it, ref Vp8ModeScore rd, Vp8SegmentInfo[] segmentInfos, Vp8EncProba proba)
	{
		Vp8SegmentInfo vp8SegmentInfo = segmentInfos[it.CurrentMacroBlockInfo.Segment];
		int lambdaUv = vp8SegmentInfo.LambdaUv;
		Span<byte> a = MemoryExtensions.AsSpan<byte>(it.YuvIn, 16);
		Span<byte> a2 = MemoryExtensions.AsSpan<byte>(it.YuvOut2, 16);
		Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvOut, 16);
		Span<byte> b = span;
		Vp8ModeScore vp8ModeScore = new Vp8ModeScore();
		Vp8ModeScore vp8ModeScore2 = new Vp8ModeScore();
		Vp8Residual res = new Vp8Residual();
		rd.ModeUv = -1;
		vp8ModeScore.InitScore();
		for (int i = 0; i < 4; i++)
		{
			vp8ModeScore2.Clear();
			vp8ModeScore2.Nz = (uint)ReconstructUv(it, vp8SegmentInfo, vp8ModeScore2, a2, i);
			vp8ModeScore2.D = LossyUtils.Vp8_Sse16x8(a, a2);
			vp8ModeScore2.SD = 0L;
			vp8ModeScore2.H = WebpConstants.Vp8FixedCostsUv[i];
			vp8ModeScore2.R = it.GetCostUv(vp8ModeScore2, proba, res);
			if (i > 0 && IsFlat(vp8ModeScore2.UvLevels, 8, 2))
			{
				vp8ModeScore2.R += 1120L;
			}
			vp8ModeScore2.SetRdScore(lambdaUv);
			if (i == 0 || vp8ModeScore2.Score < vp8ModeScore.Score)
			{
				vp8ModeScore.CopyScore(vp8ModeScore2);
				rd.ModeUv = i;
				MemoryExtensions.CopyTo<short>(vp8ModeScore2.UvLevels, MemoryExtensions.AsSpan<short>(rd.UvLevels));
				for (int j = 0; j < 2; j++)
				{
					rd.Derr[j, 0] = vp8ModeScore2.Derr[j, 0];
					rd.Derr[j, 1] = vp8ModeScore2.Derr[j, 1];
					rd.Derr[j, 2] = vp8ModeScore2.Derr[j, 2];
				}
				RuntimeUtility.Swap(ref a2, ref b);
			}
		}
		it.SetIntraUvMode(rd.ModeUv);
		rd.AddScore(vp8ModeScore);
		if (b != span)
		{
			LossyUtils.Vp8Copy16X8(b, span);
		}
		it.StoreDiffusionErrors(rd);
	}

	public static int ReconstructIntra16(Vp8EncIterator it, Vp8SegmentInfo dqm, Vp8ModeScore rd, Span<byte> yuvOut, int mode)
	{
		Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8I16ModeOffsets[mode]);
		Span<byte> span2 = MemoryExtensions.AsSpan<byte>(it.YuvIn, 0);
		int num = 0;
		Span<short> span3 = MemoryExtensions.AsSpan<short>(it.Scratch2);
		Span<int> scratch = MemoryExtensions.AsSpan<int>(it.Scratch3, 0, 16);
		span3.Clear();
		scratch.Clear();
		Span<short> span4 = span3.Slice(0, 16);
		Span<short> span5 = span3.Slice(16, 256);
		for (int i = 0; i < 16; i += 2)
		{
			ref Span<byte> reference = ref span2;
			int num2 = WebpLookupTables.Vp8Scan[i];
			Span<byte> src = reference.Slice(num2, reference.Length - num2);
			reference = ref span;
			num2 = WebpLookupTables.Vp8Scan[i];
			Vp8Encoding.FTransform2(src, reference.Slice(num2, reference.Length - num2), span5.Slice(i * 16, 16), span5.Slice((i + 1) * 16, 16), scratch);
		}
		Vp8Encoding.FTransformWht(span5, span4, scratch);
		num |= QuantizeBlock(span4, rd.YDcLevels, ref dqm.Y2) << 24;
		for (int i = 0; i < 16; i += 2)
		{
			span5[i * 16] = (span5[(i + 1) * 16] = 0);
			num |= Quantize2Blocks(span5.Slice(i * 16, 32), MemoryExtensions.AsSpan<short>(rd.YAcLevels, i * 16, 32), ref dqm.Y1) << i;
		}
		LossyUtils.TransformWht(span4, span5, scratch);
		for (int i = 0; i < 16; i += 2)
		{
			ref Span<byte> reference = ref span;
			int num2 = WebpLookupTables.Vp8Scan[i];
			Span<byte> reference2 = reference.Slice(num2, reference.Length - num2);
			Span<short> input = span5.Slice(i * 16, 32);
			reference = ref yuvOut;
			num2 = WebpLookupTables.Vp8Scan[i];
			Vp8Encoding.ITransformTwo(reference2, input, reference.Slice(num2, reference.Length - num2), scratch);
		}
		return num;
	}

	public static int ReconstructIntra4(Vp8EncIterator it, Vp8SegmentInfo dqm, Span<short> levels, Span<byte> src, Span<byte> yuvOut, int mode)
	{
		Span<byte> reference = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8I4ModeOffsets[mode]);
		Span<short> span = MemoryExtensions.AsSpan<short>(it.Scratch2, 0, 16);
		Span<int> scratch = MemoryExtensions.AsSpan<int>(it.Scratch3, 0, 16);
		Vp8Encoding.FTransform(src, reference, span, scratch);
		int result = QuantizeBlock(span, levels, ref dqm.Y1);
		Vp8Encoding.ITransformOne(reference, span, yuvOut, scratch);
		return result;
	}

	public static int ReconstructUv(Vp8EncIterator it, Vp8SegmentInfo dqm, Vp8ModeScore rd, Span<byte> yuvOut, int mode)
	{
		Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8UvModeOffsets[mode]);
		Span<byte> span2 = MemoryExtensions.AsSpan<byte>(it.YuvIn, 16);
		int num = 0;
		Span<short> tmp = MemoryExtensions.AsSpan<short>(it.Scratch2, 0, 128);
		Span<int> scratch = MemoryExtensions.AsSpan<int>(it.Scratch3, 0, 16);
		for (int i = 0; i < 8; i += 2)
		{
			ref Span<byte> reference = ref span2;
			int num2 = WebpLookupTables.Vp8ScanUv[i];
			Span<byte> src = reference.Slice(num2, reference.Length - num2);
			reference = ref span;
			num2 = WebpLookupTables.Vp8ScanUv[i];
			Vp8Encoding.FTransform2(src, reference.Slice(num2, reference.Length - num2), tmp.Slice(i * 16, 16), tmp.Slice((i + 1) * 16, 16), scratch);
		}
		CorrectDcValues(it, ref dqm.Uv, tmp, rd);
		for (int i = 0; i < 8; i += 2)
		{
			num |= Quantize2Blocks(tmp.Slice(i * 16, 32), MemoryExtensions.AsSpan<short>(rd.UvLevels, i * 16, 32), ref dqm.Uv) << i;
		}
		for (int i = 0; i < 8; i += 2)
		{
			ref Span<byte> reference = ref span;
			int num2 = WebpLookupTables.Vp8ScanUv[i];
			Span<byte> reference2 = reference.Slice(num2, reference.Length - num2);
			Span<short> input = tmp.Slice(i * 16, 32);
			reference = ref yuvOut;
			num2 = WebpLookupTables.Vp8ScanUv[i];
			Vp8Encoding.ITransformTwo(reference2, input, reference.Slice(num2, reference.Length - num2), scratch);
		}
		return num << 16;
	}

	public static void RefineUsingDistortion(Vp8EncIterator it, Vp8SegmentInfo[] segmentInfos, Vp8ModeScore rd, bool tryBothModes, bool refineUvMode, int mbHeaderLimit)
	{
		long num = 36028797018963967L;
		int num2 = 0;
		bool flag = tryBothModes || it.CurrentMacroBlockInfo.MacroBlockType == Vp8MacroBlockType.I16X16;
		Vp8SegmentInfo vp8SegmentInfo = segmentInfos[it.CurrentMacroBlockInfo.Segment];
		long num3 = vp8SegmentInfo.I4Penalty;
		long num4 = 0L;
		long num5 = (tryBothModes ? mbHeaderLimit : 36028797018963967L);
		if (flag)
		{
			int intra16Mode = -1;
			Span<byte> span = MemoryExtensions.AsSpan<byte>(it.YuvIn, 0);
			for (int i = 0; i < 4; i++)
			{
				Span<byte> b = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8I16ModeOffsets[i]);
				long num6 = LossyUtils.Vp8_Sse16x16(span, b) * 256 + WebpConstants.Vp8FixedCostsI16[i] * 106;
				if ((i <= 0 || WebpConstants.Vp8FixedCostsI16[i] <= num5) && num6 < num)
				{
					intra16Mode = i;
					num = num6;
				}
			}
			if ((it.X == 0 || it.Y == 0) && IsFlatSource16(span))
			{
				intra16Mode = ((it.X != 0) ? 2 : 0);
				tryBothModes = false;
			}
			it.SetIntra16Mode(intra16Mode);
		}
		if (tryBothModes || !flag)
		{
			flag = false;
			it.StartI4();
			do
			{
				int num7 = -1;
				long num8 = 36028797018963967L;
				Span<byte> span2 = MemoryExtensions.AsSpan<byte>(it.YuvIn, (int)WebpLookupTables.Vp8Scan[it.I4]);
				short[] costModeI = it.GetCostModeI4(rd.ModesI4);
				it.MakeIntra4Preds();
				for (int i = 0; i < 10; i++)
				{
					Span<byte> b2 = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8I4ModeOffsets[i]);
					long num9 = LossyUtils.Vp8_Sse4x4(span2, b2) * 256 + costModeI[i] * 11;
					if (num9 < num8)
					{
						num7 = i;
						num8 = num9;
					}
				}
				num4 += costModeI[num7];
				rd.ModesI4[it.I4] = (byte)num7;
				num3 += num8;
				if (num3 >= num || num4 > num5)
				{
					flag = true;
					break;
				}
				Span<byte> yuvOut = MemoryExtensions.AsSpan<byte>(it.YuvOut2, (int)WebpLookupTables.Vp8Scan[it.I4]);
				num2 |= ReconstructIntra4(it, vp8SegmentInfo, MemoryExtensions.AsSpan<short>(rd.YAcLevels, it.I4 * 16, 16), span2, yuvOut, num7) << it.I4;
			}
			while (it.RotateI4(MemoryExtensions.AsSpan<byte>(it.YuvOut2, 0)));
		}
		if (!flag)
		{
			it.SetIntra4Mode(rd.ModesI4);
			it.SwapOut();
			num = num3;
		}
		else
		{
			int mode = it.Preds[it.PredIdx];
			num2 = ReconstructIntra16(it, vp8SegmentInfo, rd, MemoryExtensions.AsSpan<byte>(it.YuvOut, 0), mode);
		}
		if (refineUvMode)
		{
			int intraUvMode = -1;
			long num10 = 36028797018963967L;
			Span<byte> a = MemoryExtensions.AsSpan<byte>(it.YuvIn, 16);
			for (int i = 0; i < 4; i++)
			{
				Span<byte> b3 = MemoryExtensions.AsSpan<byte>(it.YuvP, Vp8Encoding.Vp8UvModeOffsets[i]);
				long num11 = LossyUtils.Vp8_Sse16x8(a, b3) * 256 + WebpConstants.Vp8FixedCostsUv[i] * 120;
				if (num11 < num10)
				{
					intraUvMode = i;
					num10 = num11;
				}
			}
			it.SetIntraUvMode(intraUvMode);
		}
		num2 |= ReconstructUv(it, vp8SegmentInfo, rd, MemoryExtensions.AsSpan<byte>(it.YuvOut, 16), it.CurrentMacroBlockInfo.UvMode);
		rd.Nz = (uint)num2;
		rd.Score = num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Quantize2Blocks(Span<short> input, Span<short> output, ref Vp8Matrix mtx)
	{
		return QuantizeBlock(input.Slice(0, 16), output.Slice(0, 16), ref mtx) | (QuantizeBlock(input.Slice(16, 16), output.Slice(16, 16), ref mtx) << 1);
	}

	public unsafe static int QuantizeBlock(Span<short> input, Span<short> output, ref Vp8Matrix mtx)
	{
		if (Avx2.IsSupported)
		{
			Vector256<short> vector = Unsafe.As<short, Vector256<short>>(ref MemoryMarshal.GetReference<short>(input));
			Vector256<ushort> right = Unsafe.As<ushort, Vector256<ushort>>(ref mtx.IQ[0]);
			Vector256<ushort> vector2 = Unsafe.As<ushort, Vector256<ushort>>(ref mtx.Q[0]);
			Vector256<ushort> vector3 = Avx2.Abs(vector);
			Avx2.Add(right: Unsafe.As<short, Vector256<short>>(ref mtx.Sharpen[0]), left: vector3.AsInt16());
			Vector256<ushort> right2 = Avx2.MultiplyHigh(vector3, right);
			Vector256<ushort> left = Avx2.MultiplyLow(vector3, right);
			Vector256<ushort> vector4 = Avx2.UnpackLow(left, right2);
			Vector256<ushort> vector5 = Avx2.UnpackHigh(left, right2);
			Vector256<uint> vector6 = Unsafe.As<uint, Vector256<uint>>(ref mtx.Bias[0]);
			Vector256<uint> vector7 = Unsafe.As<uint, Vector256<uint>>(ref mtx.Bias[8]);
			vector4 = Avx2.Add(vector4.AsInt32(), vector6.AsInt32()).AsUInt16();
			vector5 = Avx2.Add(vector5.AsInt32(), vector7.AsInt32()).AsUInt16();
			vector4 = Avx2.ShiftRightArithmetic(vector4.AsInt32(), 17).AsUInt16();
			vector5 = Avx2.ShiftRightArithmetic(vector5.AsInt32(), 17).AsUInt16();
			Vector256<short> vector8 = Avx2.Sign(Avx2.Min(Avx2.PackSignedSaturate(vector4.AsInt32(), vector5.AsInt32()), Vector256.Create((short)2047)), vector);
			vector = Avx2.MultiplyLow(vector8, vector2.AsInt16());
			Unsafe.As<short, Vector256<short>>(ref MemoryMarshal.GetReference<short>(input)) = vector;
			Vector256<byte> left2 = Avx2.Shuffle(vector8.AsByte(), Vector256.Create(0, 1, 2, 3, 8, 9, 254, byte.MaxValue, 10, 11, 4, 5, 6, 7, 12, 13, 2, 3, 8, 9, 10, 11, 4, 5, 254, byte.MaxValue, 6, 7, 12, 13, 14, 15));
			Vector256<byte> vector9 = Avx2.Shuffle(vector8.AsByte(), Vector256.Create(254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 14, 15, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 0, 1, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue));
			Vector256<byte> right3 = Avx2.Permute2x128(vector9, vector9, 1);
			Vector256<short> vector10 = Avx2.Or(left2, right3).AsInt16();
			Unsafe.As<short, Vector256<short>>(ref MemoryMarshal.GetReference<short>(output)) = vector10;
			return (Avx2.MoveMask(Avx2.CompareEqual(Avx2.PackSignedSaturate(vector10, vector10), Vector256<sbyte>.Zero)) != -1) ? 1 : 0;
		}
		if (Sse41.IsSupported)
		{
			Vector128<short> vector11 = Unsafe.As<short, Vector128<short>>(ref MemoryMarshal.GetReference<short>(input));
			Vector128<short> vector12 = Unsafe.As<short, Vector128<short>>(ref MemoryMarshal.GetReference<short>(input.Slice(8, 8)));
			Vector128<ushort> right4 = Unsafe.As<ushort, Vector128<ushort>>(ref mtx.IQ[0]);
			Vector128<ushort> right5 = Unsafe.As<ushort, Vector128<ushort>>(ref mtx.IQ[8]);
			Vector128<ushort> vector13 = Unsafe.As<ushort, Vector128<ushort>>(ref mtx.Q[0]);
			Vector128<ushort> vector14 = Unsafe.As<ushort, Vector128<ushort>>(ref mtx.Q[8]);
			Vector128<ushort> vector15 = Ssse3.Abs(vector11);
			Vector128<ushort> vector16 = Ssse3.Abs(vector12);
			Vector128<short> right6 = Unsafe.As<short, Vector128<short>>(ref mtx.Sharpen[0]);
			Vector128<short> right7 = Unsafe.As<short, Vector128<short>>(ref mtx.Sharpen[8]);
			Sse2.Add(vector15.AsInt16(), right6);
			Sse2.Add(vector16.AsInt16(), right7);
			Vector128<ushort> right8 = Sse2.MultiplyHigh(vector15, right4);
			Vector128<ushort> left3 = Sse2.MultiplyLow(vector15, right4);
			Vector128<ushort> right9 = Sse2.MultiplyHigh(vector16, right5);
			Vector128<ushort> left4 = Sse2.MultiplyLow(vector16, right5);
			Vector128<ushort> vector17 = Sse2.UnpackLow(left3, right8);
			Vector128<ushort> vector18 = Sse2.UnpackHigh(left3, right8);
			Vector128<ushort> vector19 = Sse2.UnpackLow(left4, right9);
			Vector128<ushort> vector20 = Sse2.UnpackHigh(left4, right9);
			Vector128<uint> vector21 = Unsafe.As<uint, Vector128<uint>>(ref mtx.Bias[0]);
			Vector128<uint> vector22 = Unsafe.As<uint, Vector128<uint>>(ref mtx.Bias[4]);
			Vector128<uint> vector23 = Unsafe.As<uint, Vector128<uint>>(ref mtx.Bias[8]);
			Vector128<uint> vector24 = Unsafe.As<uint, Vector128<uint>>(ref mtx.Bias[12]);
			vector17 = Sse2.Add(vector17.AsInt32(), vector21.AsInt32()).AsUInt16();
			vector18 = Sse2.Add(vector18.AsInt32(), vector22.AsInt32()).AsUInt16();
			vector19 = Sse2.Add(vector19.AsInt32(), vector23.AsInt32()).AsUInt16();
			vector20 = Sse2.Add(vector20.AsInt32(), vector24.AsInt32()).AsUInt16();
			vector17 = Sse2.ShiftRightArithmetic(vector17.AsInt32(), 17).AsUInt16();
			vector18 = Sse2.ShiftRightArithmetic(vector18.AsInt32(), 17).AsUInt16();
			vector19 = Sse2.ShiftRightArithmetic(vector19.AsInt32(), 17).AsUInt16();
			vector20 = Sse2.ShiftRightArithmetic(vector20.AsInt32(), 17).AsUInt16();
			Vector128<short> left5 = Sse2.PackSignedSaturate(vector17.AsInt32(), vector18.AsInt32());
			Vector128<short> left6 = Sse2.PackSignedSaturate(vector19.AsInt32(), vector20.AsInt32());
			Vector128<short> right10 = Vector128.Create((short)2047);
			Vector128<short> left7 = Sse2.Min(left5, right10);
			left6 = Sse2.Min(left6, right10);
			Vector128<short> vector25 = Ssse3.Sign(left7, vector11);
			left6 = Ssse3.Sign(left6, vector12);
			vector11 = Sse2.MultiplyLow(vector25, vector13.AsInt16());
			vector12 = Sse2.MultiplyLow(left6, vector14.AsInt16());
			ref short reference = ref MemoryMarshal.GetReference<short>(input);
			Unsafe.As<short, Vector128<short>>(ref reference) = vector11;
			Unsafe.As<short, Vector128<short>>(ref Unsafe.Add(ref reference, 8)) = vector12;
			Vector128<byte> left8 = Ssse3.Shuffle(vector25.AsByte(), Vector128.Create(0, 1, 2, 3, 8, 9, 254, byte.MaxValue, 10, 11, 4, 5, 6, 7, 12, 13));
			Vector128<byte> right11 = Ssse3.Shuffle(vector25.AsByte(), Vector128.Create(254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 14, 15, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue));
			Vector128<byte> left9 = Ssse3.Shuffle(left6.AsByte(), Vector128.Create(2, 3, 8, 9, 10, 11, 4, 5, 254, byte.MaxValue, 6, 7, 12, 13, 14, 15));
			Vector128<byte> right12 = Ssse3.Shuffle(left6.AsByte(), Vector128.Create(254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 0, 1, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue, 254, byte.MaxValue));
			Vector128<byte> vector26 = Sse2.Or(left8, right12);
			Vector128<byte> vector27 = Sse2.Or(left9, right11);
			ref short reference2 = ref MemoryMarshal.GetReference<short>(output);
			Unsafe.As<short, Vector128<short>>(ref reference2) = vector26.AsInt16();
			Unsafe.As<short, Vector128<short>>(ref Unsafe.Add(ref reference2, 8)) = vector27.AsInt16();
			return (Sse2.MoveMask(Sse2.CompareEqual(Sse2.PackSignedSaturate(vector26.AsInt16(), vector27.AsInt16()), Vector128<sbyte>.Zero)) != 65535) ? 1 : 0;
		}
		int num = -1;
		for (int i = 0; i < 16; i++)
		{
			int num2 = Zigzag[i];
			bool flag = input[num2] < 0;
			uint num3 = (uint)((flag ? (-input[num2]) : input[num2]) + mtx.Sharpen[num2]);
			if (num3 > mtx.ZThresh[num2])
			{
				uint num4 = mtx.Q[num2];
				uint iQ = mtx.IQ[num2];
				uint b = mtx.Bias[num2];
				int num5 = QuantDiv(num3, iQ, b);
				if (num5 > 2047)
				{
					num5 = 2047;
				}
				if (flag)
				{
					num5 = -num5;
				}
				input[num2] = (short)(num5 * (int)num4);
				output[i] = (short)num5;
				if (num5 != 0)
				{
					num = i;
				}
			}
			else
			{
				output[i] = 0;
				input[num2] = 0;
			}
		}
		return (num >= 0) ? 1 : 0;
	}

	public unsafe static int QuantizeSingle(Span<short> v, ref Vp8Matrix mtx)
	{
		int num = v[0];
		bool flag = num < 0;
		if (flag)
		{
			num = -num;
		}
		if (num > (int)mtx.ZThresh[0])
		{
			int num2 = QuantDiv((uint)num, mtx.IQ[0], mtx.Bias[0]) * mtx.Q[0];
			int num3 = num - num2;
			v[0] = (short)(flag ? (-num2) : num2);
			return (flag ? (-num3) : num3) >> 1;
		}
		v[0] = 0;
		return (flag ? (-num) : num) >> 1;
	}

	public static void CorrectDcValues(Vp8EncIterator it, ref Vp8Matrix mtx, Span<short> tmp, Vp8ModeScore rd)
	{
		for (int i = 0; i <= 1; i++)
		{
			Span<sbyte> span = MemoryExtensions.AsSpan<sbyte>(it.TopDerr, it.X * 4 + i, 2);
			Span<sbyte> span2 = MemoryExtensions.AsSpan<sbyte>(it.LeftDerr, i, 2);
			Span<short> v = tmp.Slice(i * 4 * 16, 64);
			v[0] += (short)(7 * span[0] + 8 * span2[0] >> 3);
			int num = QuantizeSingle(v, ref mtx);
			v[16] += (short)(7 * span[1] + 8 * num >> 3);
			ref Span<short> reference = ref v;
			int num2 = QuantizeSingle(reference.Slice(16, reference.Length - 16), ref mtx);
			v[32] += (short)(7 * num + 8 * span2[1] >> 3);
			reference = ref v;
			int num3 = QuantizeSingle(reference.Slice(32, reference.Length - 32), ref mtx);
			v[48] += (short)(7 * num2 + 8 * num3 >> 3);
			reference = ref v;
			int num4 = QuantizeSingle(reference.Slice(48, reference.Length - 48), ref mtx);
			rd.Derr[i, 0] = num2;
			rd.Derr[i, 1] = num3;
			rd.Derr[i, 2] = num4;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFlatSource16(Span<byte> src)
	{
		Span<byte> span = MemoryExtensions.AsSpan<byte>(BitConverter.GetBytes((uint)(src[0] * 16843009)));
		for (nuint num = 0u; num < 16; num++)
		{
			if (!MemoryExtensions.SequenceEqual<byte>(src.Slice(0, 4), (ReadOnlySpan<byte>)span) || !MemoryExtensions.SequenceEqual<byte>(src.Slice(4, 4), (ReadOnlySpan<byte>)span) || !MemoryExtensions.SequenceEqual<byte>(src.Slice(8, 4), (ReadOnlySpan<byte>)span) || !MemoryExtensions.SequenceEqual<byte>(src.Slice(12, 4), (ReadOnlySpan<byte>)span))
			{
				return false;
			}
			src = src.Slice(32, src.Length - 32);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFlat(Span<short> levels, int numBlocks, int thresh)
	{
		int num = 0;
		ref short reference = ref MemoryMarshal.GetReference<short>(levels);
		nuint num2 = 0u;
		while (numBlocks-- > 0)
		{
			for (nuint num3 = 1u; num3 < 16; num3++)
			{
				num += ((Unsafe.Add(ref reference, num2) != 0) ? 1 : 0);
				if (num > thresh)
				{
					return false;
				}
			}
			num2 += 16;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Mult8B(int a, int b)
	{
		return a * b + 128 >> 8;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int QuantDiv(uint n, uint iQ, uint b)
	{
		return (int)(n * iQ + b >> 17);
	}
}
