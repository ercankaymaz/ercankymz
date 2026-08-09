using System;
using System.Buffers;
using SixLabors.ImageSharp.Formats.Webp.BitReader;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class Vp8Decoder : IDisposable
{
	private Vp8MacroBlock leftMacroBlock;

	public Vp8FrameHeader FrameHeader { get; }

	public Vp8PictureHeader PictureHeader { get; }

	public Vp8FilterHeader FilterHeader { get; }

	public Vp8SegmentHeader SegmentHeader { get; }

	public int NumPartsMinusOne { get; set; }

	public Vp8BitReader[] Vp8BitReaders { get; }

	public Vp8QuantMatrix[] DeQuantMatrices { get; }

	public bool UseSkipProbability { get; set; }

	public byte SkipProbability { get; set; }

	public Vp8Proba Probabilities { get; set; }

	public byte[] IntraT { get; set; }

	public byte[] IntraL { get; }

	public int MbWidth { get; }

	public int MbHeight { get; }

	public int TopLeftMbX { get; set; }

	public int TopLeftMbY { get; set; }

	public int BottomRightMbX { get; set; }

	public int BottomRightMbY { get; set; }

	public int MbX { get; set; }

	public int MbY { get; set; }

	public Vp8MacroBlockData[] MacroBlockData { get; }

	public Vp8MacroBlock[] MacroBlockInfo { get; }

	public LoopFilter Filter { get; set; }

	public Vp8FilterInfo[,] FilterStrength { get; }

	public IMemoryOwner<byte> YuvBuffer { get; }

	public Vp8TopSamples[] YuvTopSamples { get; }

	public IMemoryOwner<byte> CacheY { get; }

	public IMemoryOwner<byte> CacheU { get; }

	public IMemoryOwner<byte> CacheV { get; }

	public int CacheYOffset { get; set; }

	public int CacheUvOffset { get; set; }

	public int CacheYStride { get; }

	public int CacheUvStride { get; }

	public IMemoryOwner<byte> TmpYBuffer { get; }

	public IMemoryOwner<byte> TmpUBuffer { get; }

	public IMemoryOwner<byte> TmpVBuffer { get; }

	public IMemoryOwner<byte> Pixels { get; }

	public Vp8FilterInfo[] FilterInfo { get; set; }

	public Vp8MacroBlock CurrentMacroBlock => MacroBlockInfo[MbX];

	public Vp8MacroBlock LeftMacroBlock => leftMacroBlock ?? (leftMacroBlock = new Vp8MacroBlock());

	public Vp8MacroBlockData CurrentBlockData => MacroBlockData[MbX];

	public Vp8Decoder(Vp8FrameHeader frameHeader, Vp8PictureHeader pictureHeader, Vp8SegmentHeader segmentHeader, Vp8Proba probabilities, MemoryAllocator memoryAllocator)
	{
		FilterHeader = new Vp8FilterHeader();
		FrameHeader = frameHeader;
		PictureHeader = pictureHeader;
		SegmentHeader = segmentHeader;
		Probabilities = probabilities;
		IntraL = new byte[4];
		MbWidth = (int)(PictureHeader.Width + 15 >> 4);
		MbHeight = (int)(PictureHeader.Height + 15 >> 4);
		CacheYStride = 16 * MbWidth;
		CacheUvStride = 8 * MbWidth;
		MacroBlockInfo = new Vp8MacroBlock[MbWidth + 1];
		MacroBlockData = new Vp8MacroBlockData[MbWidth];
		YuvTopSamples = new Vp8TopSamples[MbWidth];
		FilterInfo = new Vp8FilterInfo[MbWidth];
		for (int i = 0; i < MbWidth; i++)
		{
			MacroBlockInfo[i] = new Vp8MacroBlock();
			MacroBlockData[i] = new Vp8MacroBlockData();
			YuvTopSamples[i] = new Vp8TopSamples();
			FilterInfo[i] = new Vp8FilterInfo();
		}
		MacroBlockInfo[MbWidth] = new Vp8MacroBlock();
		DeQuantMatrices = new Vp8QuantMatrix[4];
		FilterStrength = new Vp8FilterInfo[4, 2];
		for (int j = 0; j < 4; j++)
		{
			DeQuantMatrices[j] = new Vp8QuantMatrix();
			for (int k = 0; k < 2; k++)
			{
				FilterStrength[j, k] = new Vp8FilterInfo();
			}
		}
		uint width = pictureHeader.Width;
		uint height = pictureHeader.Height;
		byte num = WebpConstants.FilterExtraRows[2];
		int num2 = num * CacheYStride;
		int num3 = num / 2 * CacheUvStride;
		YuvBuffer = memoryAllocator.Allocate<byte>(832 + num2);
		CacheY = memoryAllocator.Allocate<byte>(16 * CacheYStride + num2);
		int length = 16 * CacheUvStride + num3;
		CacheU = memoryAllocator.Allocate<byte>(length);
		CacheV = memoryAllocator.Allocate<byte>(length);
		TmpYBuffer = memoryAllocator.Allocate<byte>((int)width);
		TmpUBuffer = memoryAllocator.Allocate<byte>((int)width);
		TmpVBuffer = memoryAllocator.Allocate<byte>((int)width);
		Pixels = memoryAllocator.Allocate<byte>((int)(width * height * 4));
		Vp8BitReaders = new Vp8BitReader[8];
	}

	public void PrecomputeFilterStrengths()
	{
		if (Filter == LoopFilter.None)
		{
			return;
		}
		Vp8FilterHeader filterHeader = FilterHeader;
		for (int i = 0; i < 4; i++)
		{
			int num;
			if (SegmentHeader.UseSegment)
			{
				num = SegmentHeader.FilterStrength[i];
				if (!SegmentHeader.Delta)
				{
					num += filterHeader.FilterLevel;
				}
			}
			else
			{
				num = filterHeader.FilterLevel;
			}
			for (int j = 0; j <= 1; j++)
			{
				Vp8FilterInfo vp8FilterInfo = FilterStrength[i, j];
				int num2 = num;
				if (filterHeader.UseLfDelta)
				{
					num2 += filterHeader.RefLfDelta[0];
					if (j > 0)
					{
						num2 += filterHeader.ModeLfDelta[0];
					}
				}
				num2 = ((num2 >= 0) ? ((num2 > 63) ? 63 : num2) : 0);
				if (num2 > 0)
				{
					int num3 = num2;
					if (filterHeader.Sharpness > 0)
					{
						num3 = ((filterHeader.Sharpness <= 4) ? (num3 >> 1) : (num3 >> 2));
						int num4 = 9 - filterHeader.Sharpness;
						if (num3 > num4)
						{
							num3 = num4;
						}
					}
					if (num3 < 1)
					{
						num3 = 1;
					}
					vp8FilterInfo.InnerLevel = (byte)num3;
					vp8FilterInfo.Limit = (byte)(2 * num2 + num3);
					vp8FilterInfo.HighEdgeVarianceThreshold = (byte)((num2 >= 40) ? 2u : ((num2 >= 15) ? 1u : 0u));
				}
				else
				{
					vp8FilterInfo.Limit = 0;
				}
				vp8FilterInfo.UseInnerFiltering = j == 1;
			}
		}
	}

	public void Dispose()
	{
		YuvBuffer.Dispose();
		CacheY.Dispose();
		CacheU.Dispose();
		CacheV.Dispose();
		TmpYBuffer.Dispose();
		TmpUBuffer.Dispose();
		TmpVBuffer.Dispose();
		Pixels.Dispose();
	}
}
