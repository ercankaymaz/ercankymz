using System;

namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class Vp8EncIterator
{
	public const int YOffEnc = 0;

	public const int UOffEnc = 16;

	public const int VOffEnc = 24;

	private const int MaxIntra16Mode = 2;

	private const int MaxIntra4Mode = 2;

	private const int MaxUvMode = 2;

	private const int DefaultAlpha = -1;

	private readonly int mbw;

	private readonly int mbh;

	private readonly int predsWidth;

	private readonly byte[] vp8TopLeftI4 = new byte[16]
	{
		17, 21, 25, 29, 13, 17, 21, 25, 9, 13,
		17, 21, 5, 9, 13, 17
	};

	private int currentMbIdx;

	private int nzIdx;

	private int yTopIdx;

	private int uvTopIdx;

	public int X { get; set; }

	public int Y { get; set; }

	public byte[] YuvIn { get; }

	public byte[] YuvOut { get; set; }

	public byte[] YuvOut2 { get; set; }

	public byte[] YuvP { get; }

	public byte[] YLeft { get; }

	public byte[] UvLeft { get; }

	public sbyte[] LeftDerr { get; }

	public byte[] YTop { get; }

	public byte[] UvTop { get; }

	public byte[] Preds { get; }

	public int PredIdx { get; private set; }

	public uint[] Nz { get; }

	public sbyte[] TopDerr { get; }

	public byte[] I4Boundary { get; }

	public int I4BoundaryIdx { get; set; }

	public int I4 { get; set; }

	public int[] TopNz { get; }

	public int[] LeftNz { get; }

	public long LumaBits { get; set; }

	public long[,] BitCount { get; }

	public long UvBits { get; set; }

	public int CountDown { get; set; }

	public byte[] Scratch { get; }

	public short[] Scratch2 { get; }

	public int[] Scratch3 { get; }

	public Vp8MacroBlockInfo CurrentMacroBlockInfo => Mb[currentMbIdx];

	private Vp8MacroBlockInfo[] Mb { get; }

	public Vp8EncIterator(Vp8Encoder enc)
		: this(enc.YTop, enc.UvTop, enc.Nz, enc.MbInfo, enc.Preds, enc.TopDerr, enc.Mbw, enc.Mbh)
	{
	}

	public Vp8EncIterator(byte[] yTop, byte[] uvTop, uint[] nz, Vp8MacroBlockInfo[] mb, byte[] preds, sbyte[] topDerr, int mbw, int mbh)
	{
		YTop = yTop;
		UvTop = uvTop;
		Nz = nz;
		Mb = mb;
		Preds = preds;
		TopDerr = topDerr;
		LeftDerr = new sbyte[4];
		this.mbw = mbw;
		this.mbh = mbh;
		currentMbIdx = 0;
		nzIdx = 1;
		yTopIdx = 0;
		uvTopIdx = 0;
		predsWidth = 4 * mbw + 1;
		PredIdx = predsWidth;
		YuvIn = new byte[512];
		YuvOut = new byte[512];
		YuvOut2 = new byte[512];
		YuvP = new byte[1792];
		YLeft = new byte[32];
		UvLeft = new byte[32];
		TopNz = new int[9];
		LeftNz = new int[9];
		I4Boundary = new byte[37];
		BitCount = new long[4, 3];
		Scratch = new byte[512];
		Scratch2 = new short[272];
		Scratch3 = new int[16];
		MemoryExtensions.AsSpan<byte>(YuvIn).Fill(204);
		MemoryExtensions.AsSpan<byte>(YuvOut).Fill(204);
		MemoryExtensions.AsSpan<byte>(YuvOut2).Fill(204);
		MemoryExtensions.AsSpan<byte>(YuvP).Fill(204);
		MemoryExtensions.AsSpan<byte>(YLeft).Fill(204);
		MemoryExtensions.AsSpan<byte>(UvLeft).Fill(204);
		MemoryExtensions.AsSpan<byte>(Scratch).Fill(204);
		Reset();
	}

	public void Init()
	{
		Reset();
	}

	public static void InitFilter()
	{
	}

	public void StartI4()
	{
		I4 = 0;
		I4BoundaryIdx = vp8TopLeftI4[0];
		for (int i = 0; i < 17; i++)
		{
			I4Boundary[i] = YLeft[15 - i + 1];
		}
		Span<byte> span = MemoryExtensions.AsSpan<byte>(YTop, yTopIdx);
		for (int i = 0; i < 16; i++)
		{
			I4Boundary[17 + i] = span[i];
		}
		if (X < mbw - 1)
		{
			for (int i = 16; i < 20; i++)
			{
				I4Boundary[17 + i] = span[i];
			}
		}
		else
		{
			for (int i = 16; i < 20; i++)
			{
				I4Boundary[17 + i] = I4Boundary[32];
			}
		}
		NzToBytes();
	}

	public void Import(Span<byte> y, Span<byte> u, Span<byte> v, int yStride, int uvStride, int width, int height, bool importBoundarySamples)
	{
		int num = (Y * yStride + X) * 16;
		int num2 = (Y * uvStride + X) * 8;
		ref Span<byte> reference = ref y;
		int num3 = num;
		Span<byte> src = reference.Slice(num3, reference.Length - num3);
		reference = ref u;
		num3 = num2;
		Span<byte> src2 = reference.Slice(num3, reference.Length - num3);
		reference = ref v;
		num3 = num2;
		Span<byte> src3 = reference.Slice(num3, reference.Length - num3);
		int num4 = Math.Min(width - X * 16, 16);
		int num5 = Math.Min(height - Y * 16, 16);
		int num6 = num4 + 1 >> 1;
		int num7 = num5 + 1 >> 1;
		Span<byte> dst = MemoryExtensions.AsSpan<byte>(YuvIn, 0);
		Span<byte> dst2 = MemoryExtensions.AsSpan<byte>(YuvIn, 16);
		Span<byte> dst3 = MemoryExtensions.AsSpan<byte>(YuvIn, 24);
		ImportBlock(src, yStride, dst, num4, num5, 16);
		ImportBlock(src2, uvStride, dst2, num6, num7, 8);
		ImportBlock(src3, uvStride, dst3, num6, num7, 8);
		if (!importBoundarySamples)
		{
			return;
		}
		if (X == 0)
		{
			InitLeft();
		}
		else
		{
			Span<byte> span = MemoryExtensions.AsSpan<byte>(YLeft);
			Span<byte> span2 = MemoryExtensions.AsSpan<byte>(UvLeft, 0, 16);
			Span<byte> span3 = MemoryExtensions.AsSpan<byte>(UvLeft, 16, 16);
			if (Y == 0)
			{
				span[0] = 127;
				span2[0] = 127;
				span3[0] = 127;
			}
			else
			{
				span[0] = y[num - 1 - yStride];
				span2[0] = u[num2 - 1 - uvStride];
				span3[0] = v[num2 - 1 - uvStride];
			}
			reference = ref y;
			num3 = num - 1;
			Span<byte> src4 = reference.Slice(num3, reference.Length - num3);
			reference = ref span;
			ImportLine(src4, yStride, reference.Slice(1, reference.Length - 1), num5, 16);
			reference = ref u;
			num3 = num2 - 1;
			Span<byte> src5 = reference.Slice(num3, reference.Length - num3);
			reference = ref span2;
			ImportLine(src5, uvStride, reference.Slice(1, reference.Length - 1), num7, 8);
			reference = ref v;
			num3 = num2 - 1;
			Span<byte> src6 = reference.Slice(num3, reference.Length - num3);
			reference = ref span3;
			ImportLine(src6, uvStride, reference.Slice(1, reference.Length - 1), num7, 8);
		}
		Span<byte> dst4 = MemoryExtensions.AsSpan<byte>(YTop, yTopIdx, 16);
		if (Y == 0)
		{
			dst4.Fill(127);
			MemoryExtensions.AsSpan<byte>(UvTop, uvTopIdx, 16).Fill(127);
			return;
		}
		reference = ref y;
		num3 = num - yStride;
		ImportLine(reference.Slice(num3, reference.Length - num3), 1, dst4, num4, 16);
		reference = ref u;
		num3 = num2 - uvStride;
		ImportLine(reference.Slice(num3, reference.Length - num3), 1, MemoryExtensions.AsSpan<byte>(UvTop, uvTopIdx, 8), num6, 8);
		reference = ref v;
		num3 = num2 - uvStride;
		ImportLine(reference.Slice(num3, reference.Length - num3), 1, MemoryExtensions.AsSpan<byte>(UvTop, uvTopIdx + 8, 8), num6, 8);
	}

	public int FastMbAnalyze(uint quality)
	{
		uint num = 8 + 9 * quality / 100;
		Span<uint> span = stackalloc uint[16];
		for (int i = 0; i < 16; i += 4)
		{
			LossyUtils.Mean16x4(MemoryExtensions.AsSpan<byte>(YuvIn, i * 32), span.Slice(i, 4));
		}
		uint num2 = 0u;
		uint num3 = 0u;
		for (int i = 0; i < 16; i++)
		{
			num2 += span[i];
			num3 += span[i] * span[i];
		}
		if (num * num3 < num2 * num2)
		{
			SetIntra16Mode(0);
		}
		else
		{
			Span<byte> span2 = stackalloc byte[16];
			SetIntra4Mode(span2);
		}
		return 0;
	}

	public int MbAnalyzeBestIntra16Mode()
	{
		int num = -1;
		int intra16Mode = 0;
		MakeLuma16Preds();
		for (int i = 0; i < 2; i++)
		{
			Vp8Histogram vp8Histogram = new Vp8Histogram();
			vp8Histogram.CollectHistogram(MemoryExtensions.AsSpan<byte>(YuvIn, 0), MemoryExtensions.AsSpan<byte>(YuvP, Vp8Encoding.Vp8I16ModeOffsets[i]), 0, 16);
			int alpha = vp8Histogram.GetAlpha();
			if (alpha > num)
			{
				num = alpha;
				intra16Mode = i;
			}
		}
		SetIntra16Mode(intra16Mode);
		return num;
	}

	public int MbAnalyzeBestIntra4Mode(int bestAlpha)
	{
		Span<byte> span = stackalloc byte[16];
		Vp8Histogram vp8Histogram = new Vp8Histogram();
		int num = 0;
		StartI4();
		do
		{
			int num2 = -1;
			Vp8Histogram[] array = new Vp8Histogram[2];
			Span<byte> reference = MemoryExtensions.AsSpan<byte>(YuvIn, (int)WebpLookupTables.Vp8Scan[I4]);
			MakeIntra4Preds();
			for (int i = 0; i < 2; i++)
			{
				array[num] = new Vp8Histogram();
				array[num].CollectHistogram(reference, MemoryExtensions.AsSpan<byte>(YuvP, Vp8Encoding.Vp8I4ModeOffsets[i]), 0, 1);
				int alpha = array[num].GetAlpha();
				if (alpha > num2)
				{
					num2 = alpha;
					span[I4] = (byte)i;
					num ^= 1;
				}
			}
			array[num ^ 1].Merge(vp8Histogram);
		}
		while (RotateI4(MemoryExtensions.AsSpan<byte>(YuvIn, 0)));
		int alpha2 = vp8Histogram.GetAlpha();
		if (alpha2 > bestAlpha)
		{
			SetIntra4Mode(span);
			bestAlpha = alpha2;
		}
		return bestAlpha;
	}

	public int MbAnalyzeBestUvMode()
	{
		int num = -1;
		int num2 = 0;
		int intraUvMode = 0;
		MakeChroma8Preds();
		for (int i = 0; i < 2; i++)
		{
			Vp8Histogram vp8Histogram = new Vp8Histogram();
			vp8Histogram.CollectHistogram(MemoryExtensions.AsSpan<byte>(YuvIn, 16), MemoryExtensions.AsSpan<byte>(YuvP, Vp8Encoding.Vp8UvModeOffsets[i]), 16, 24);
			int alpha = vp8Histogram.GetAlpha();
			if (alpha > num)
			{
				num = alpha;
			}
			if (i == 0 || alpha < num2)
			{
				num2 = alpha;
				intraUvMode = i;
			}
		}
		SetIntraUvMode(intraUvMode);
		return num;
	}

	public void SetIntra16Mode(int mode)
	{
		Span<byte> span = MemoryExtensions.AsSpan<byte>(Preds, PredIdx);
		for (int i = 0; i < 4; i++)
		{
			span.Slice(0, 4).Fill((byte)mode);
			int num = predsWidth;
			span = span.Slice(num, span.Length - num);
		}
		CurrentMacroBlockInfo.MacroBlockType = Vp8MacroBlockType.I16X16;
	}

	public void SetIntra4Mode(ReadOnlySpan<byte> modes)
	{
		int num = 0;
		int num2 = PredIdx;
		for (int num3 = 4; num3 > 0; num3--)
		{
			modes.Slice(num, 4).CopyTo(MemoryExtensions.AsSpan<byte>(Preds, num2));
			num2 += predsWidth;
			num += 4;
		}
		CurrentMacroBlockInfo.MacroBlockType = Vp8MacroBlockType.I4X4;
	}

	public int GetCostLuma16(Vp8ModeScore rd, Vp8EncProba proba, Vp8Residual res)
	{
		int num = 0;
		NzToBytes();
		res.Init(0, 1, proba);
		res.SetCoeffs(rd.YDcLevels);
		num += res.GetResidualCost(TopNz[8] + LeftNz[8]);
		res.Init(1, 0, proba);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				int ctx = TopNz[j] + LeftNz[i];
				res.SetCoeffs(MemoryExtensions.AsSpan<short>(rd.YAcLevels, (j + i * 4) * 16, 16));
				num += res.GetResidualCost(ctx);
				TopNz[j] = (LeftNz[i] = ((res.Last >= 0) ? 1 : 0));
			}
		}
		return num;
	}

	public short[] GetCostModeI4(byte[] modes)
	{
		int num = predsWidth;
		int predIdx = PredIdx;
		int num2 = I4 & 3;
		int num3 = I4 >> 2;
		int num4 = ((num2 == 0) ? Preds[predIdx + num3 * num - 1] : modes[I4 - 1]);
		int num5 = ((num3 == 0) ? Preds[predIdx - num + num2] : modes[I4 - 4]);
		return WebpLookupTables.Vp8FixedCostsI4[num5, num4];
	}

	public int GetCostLuma4(Span<short> levels, Vp8EncProba proba, Vp8Residual res)
	{
		int num = I4 & 3;
		int num2 = I4 >> 2;
		res.Init(0, 3, proba);
		int ctx = TopNz[num] + LeftNz[num2];
		res.SetCoeffs(levels);
		return 0 + res.GetResidualCost(ctx);
	}

	public int GetCostUv(Vp8ModeScore rd, Vp8EncProba proba, Vp8Residual res)
	{
		int num = 0;
		NzToBytes();
		res.Init(0, 2, proba);
		for (int i = 0; i <= 2; i += 2)
		{
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < 2; k++)
				{
					int ctx = TopNz[4 + i + k] + LeftNz[4 + i + j];
					res.SetCoeffs(MemoryExtensions.AsSpan<short>(rd.UvLevels, (i * 2 + k + j * 2) * 16, 16));
					num += res.GetResidualCost(ctx);
					TopNz[4 + i + k] = (LeftNz[4 + i + j] = ((res.Last >= 0) ? 1 : 0));
				}
			}
		}
		return num;
	}

	public void SetIntraUvMode(int mode)
	{
		CurrentMacroBlockInfo.UvMode = mode;
	}

	public void SetSkip(bool skip)
	{
		CurrentMacroBlockInfo.Skip = skip;
	}

	public void SetSegment(int segment)
	{
		CurrentMacroBlockInfo.Segment = segment;
	}

	public void StoreDiffusionErrors(Vp8ModeScore rd)
	{
		for (int i = 0; i <= 1; i++)
		{
			Span<sbyte> span = MemoryExtensions.AsSpan<sbyte>(TopDerr, X * 4 + i, 2);
			Span<sbyte> span2 = MemoryExtensions.AsSpan<sbyte>(LeftDerr, i, 2);
			span2[0] = (sbyte)rd.Derr[i, 0];
			span2[1] = (sbyte)(3 * rd.Derr[i, 2] >> 2);
			span[0] = (sbyte)rd.Derr[i, 1];
			span[1] = (sbyte)(rd.Derr[i, 2] - span2[1]);
		}
	}

	public bool IsDone()
	{
		return CountDown <= 0;
	}

	public bool Next()
	{
		if (++X == mbw)
		{
			SetRow(++Y);
		}
		else
		{
			currentMbIdx++;
			nzIdx++;
			PredIdx += 4;
			yTopIdx += 16;
			uvTopIdx += 16;
		}
		return --CountDown > 0;
	}

	public void SaveBoundary()
	{
		int x = X;
		int y = Y;
		Span<byte> span = MemoryExtensions.AsSpan<byte>(YuvOut, 0);
		Span<byte> span2 = MemoryExtensions.AsSpan<byte>(YuvOut, 16);
		if (x < mbw - 1)
		{
			for (int i = 0; i < 16; i++)
			{
				YLeft[i + 1] = span[15 + i * 32];
			}
			for (int j = 0; j < 8; j++)
			{
				UvLeft[j + 1] = span2[7 + j * 32];
				UvLeft[j + 16 + 1] = span2[15 + j * 32];
			}
			YLeft[0] = YTop[yTopIdx + 15];
			UvLeft[0] = UvTop[uvTopIdx + 7];
			UvLeft[16] = UvTop[uvTopIdx + 8 + 7];
		}
		if (y < mbh - 1)
		{
			span.Slice(480, 16).CopyTo(MemoryExtensions.AsSpan<byte>(YTop, yTopIdx));
			span2.Slice(224, 16).CopyTo(MemoryExtensions.AsSpan<byte>(UvTop, uvTopIdx));
		}
	}

	public bool RotateI4(Span<byte> yuvOut)
	{
		int num = WebpLookupTables.Vp8Scan[I4];
		Span<byte> span = yuvOut.Slice(num, yuvOut.Length - num);
		Span<byte> span2 = MemoryExtensions.AsSpan<byte>(I4Boundary);
		int i4BoundaryIdx = I4BoundaryIdx;
		for (int i = 0; i <= 3; i++)
		{
			span2[i4BoundaryIdx - 4 + i] = span[i + 96];
		}
		if ((I4 & 3) != 3)
		{
			for (int i = 0; i <= 2; i++)
			{
				span2[i4BoundaryIdx + i] = span[3 + (2 - i) * 32];
			}
		}
		else
		{
			for (int i = 0; i <= 3; i++)
			{
				span2[i4BoundaryIdx + i] = span2[i4BoundaryIdx + i + 4];
			}
		}
		num = I4 + 1;
		I4 = num;
		if (I4 == 16)
		{
			return false;
		}
		I4BoundaryIdx = vp8TopLeftI4[I4];
		return true;
	}

	public void ResetAfterSkip()
	{
		if (CurrentMacroBlockInfo.MacroBlockType == Vp8MacroBlockType.I16X16)
		{
			Nz[nzIdx] = 0u;
			LeftNz[8] = 0;
		}
		else
		{
			Nz[nzIdx] &= 16777216u;
		}
	}

	public void MakeLuma16Preds()
	{
		Span<byte> left = ((X != 0) ? MemoryExtensions.AsSpan<byte>(YLeft) : ((Span<byte>)null));
		Span<byte> top = ((Y != 0) ? MemoryExtensions.AsSpan<byte>(YTop, yTopIdx) : ((Span<byte>)null));
		Vp8Encoding.EncPredLuma16(YuvP, left, top);
	}

	public void MakeChroma8Preds()
	{
		Span<byte> left = ((X != 0) ? MemoryExtensions.AsSpan<byte>(UvLeft) : ((Span<byte>)null));
		Span<byte> top = ((Y != 0) ? MemoryExtensions.AsSpan<byte>(UvTop, uvTopIdx) : ((Span<byte>)null));
		Vp8Encoding.EncPredChroma8(YuvP, left, top);
	}

	public void MakeIntra4Preds()
	{
		Vp8Encoding.EncPredLuma4(YuvP, I4Boundary, I4BoundaryIdx, MemoryExtensions.AsSpan<byte>(Scratch, 0, 4));
	}

	public void SwapOut()
	{
		byte[] yuvOut = YuvOut;
		YuvOut = YuvOut2;
		YuvOut2 = yuvOut;
	}

	public void NzToBytes()
	{
		Span<uint> span = MemoryExtensions.AsSpan<uint>(Nz);
		uint nz = span[nzIdx - 1];
		uint nz2 = span[nzIdx];
		Span<int> span2 = TopNz;
		Span<int> span3 = LeftNz;
		span2[0] = Bit(nz2, 12);
		span2[1] = Bit(nz2, 13);
		span2[2] = Bit(nz2, 14);
		span2[3] = Bit(nz2, 15);
		span2[4] = Bit(nz2, 18);
		span2[5] = Bit(nz2, 19);
		span2[6] = Bit(nz2, 22);
		span2[7] = Bit(nz2, 23);
		span2[8] = Bit(nz2, 24);
		span3[0] = Bit(nz, 3);
		span3[1] = Bit(nz, 7);
		span3[2] = Bit(nz, 11);
		span3[3] = Bit(nz, 15);
		span3[4] = Bit(nz, 17);
		span3[5] = Bit(nz, 19);
		span3[6] = Bit(nz, 21);
		span3[7] = Bit(nz, 23);
	}

	public void BytesToNz()
	{
		uint num = 0u;
		int[] topNz = TopNz;
		int[] leftNz = LeftNz;
		num |= (uint)((topNz[0] << 12) | (topNz[1] << 13));
		num |= (uint)((topNz[2] << 14) | (topNz[3] << 15));
		num |= (uint)((topNz[4] << 18) | (topNz[5] << 19));
		num |= (uint)((topNz[6] << 22) | (topNz[7] << 23));
		num |= (uint)(topNz[8] << 24);
		num |= (uint)((leftNz[0] << 3) | (leftNz[1] << 7));
		num |= (uint)(leftNz[2] << 11);
		num |= (uint)((leftNz[4] << 17) | (leftNz[6] << 21));
		Nz[nzIdx] = num;
	}

	private static void ImportBlock(Span<byte> src, int srcStride, Span<byte> dst, int w, int h, int size)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < h; i++)
		{
			Span<byte> span = src.Slice(num2, w);
			ref Span<byte> reference = ref dst;
			int num3 = num;
			span.CopyTo(reference.Slice(num3, reference.Length - num3));
			if (w < size)
			{
				dst.Slice(num + w, size - w).Fill(dst[num + w - 1]);
			}
			num += 32;
			num2 += srcStride;
		}
		for (int j = h; j < size; j++)
		{
			Span<byte> span = dst.Slice(num - 32, size);
			ref Span<byte> reference = ref dst;
			int num3 = num;
			span.CopyTo(reference.Slice(num3, reference.Length - num3));
			num += 32;
		}
	}

	private static void ImportLine(Span<byte> src, int srcStride, Span<byte> dst, int len, int totalLen)
	{
		int num = 0;
		int i;
		for (i = 0; i < len; i++)
		{
			dst[i] = src[num];
			num += srcStride;
		}
		for (; i < totalLen; i++)
		{
			dst[i] = dst[len - 1];
		}
	}

	private void Reset()
	{
		SetRow(0);
		SetCountDown(mbw * mbh);
		InitTop();
		Array.Clear(BitCount);
	}

	private void SetRow(int y)
	{
		X = 0;
		Y = y;
		currentMbIdx = y * mbw;
		nzIdx = 1;
		yTopIdx = 0;
		uvTopIdx = 0;
		PredIdx = predsWidth + y * 4 * predsWidth;
		InitLeft();
	}

	private void InitLeft()
	{
		Span<byte> span = MemoryExtensions.AsSpan<byte>(YLeft);
		Span<byte> span2 = MemoryExtensions.AsSpan<byte>(UvLeft, 0, 16);
		Span<byte> span3 = MemoryExtensions.AsSpan<byte>(UvLeft, 16, 16);
		byte b = (byte)((Y > 0) ? 129u : 127u);
		span[0] = b;
		span2[0] = b;
		span3[0] = b;
		span.Slice(1, 16).Fill(129);
		span2.Slice(1, 8).Fill(129);
		span3.Slice(1, 8).Fill(129);
		LeftNz[8] = 0;
		MemoryExtensions.AsSpan<sbyte>(LeftDerr).Clear();
	}

	private void InitTop()
	{
		int num = mbw * 16;
		MemoryExtensions.AsSpan<byte>(YTop, 0, num).Fill(127);
		MemoryExtensions.AsSpan<byte>(UvTop).Fill(127);
		MemoryExtensions.AsSpan<uint>(Nz).Clear();
		int num2 = 4 * mbw + 1;
		int num3 = 4 * mbh + 1;
		int num4 = num2 * num3;
		MemoryExtensions.AsSpan<byte>(Preds, num4 + predsWidth, mbw).Clear();
		MemoryExtensions.AsSpan<sbyte>(TopDerr).Clear();
	}

	private static int Bit(uint nz, int n)
	{
		return ((nz & (1 << n)) != 0) ? 1 : 0;
	}

	private void SetCountDown(int countDown)
	{
		CountDown = countDown;
	}
}
