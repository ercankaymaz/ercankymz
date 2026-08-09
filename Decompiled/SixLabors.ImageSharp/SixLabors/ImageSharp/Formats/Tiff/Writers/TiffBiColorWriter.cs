using System;
using System.Buffers;
using SixLabors.ImageSharp.Formats.Tiff.Compression;
using SixLabors.ImageSharp.Formats.Tiff.Constants;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace SixLabors.ImageSharp.Formats.Tiff.Writers;

internal sealed class TiffBiColorWriter<TPixel> : TiffBaseColorWriter<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly Image<TPixel> imageBlackWhite;

	private IMemoryOwner<byte> pixelsAsGray;

	private IMemoryOwner<byte> bitStrip;

	public override int BitsPerPixel => 1;

	public TiffBiColorWriter(ImageFrame<TPixel> image, MemoryAllocator memoryAllocator, Configuration configuration, TiffEncoderEntriesCollector entriesCollector)
		: base(image, memoryAllocator, configuration, entriesCollector)
	{
		imageBlackWhite = new Image<TPixel>(configuration, new ImageMetadata(), new ImageFrame<TPixel>[1] { image.Clone() });
		imageBlackWhite.Mutate(delegate(IImageProcessingContext img)
		{
			img.BinaryDither(KnownDitherings.FloydSteinberg);
		});
	}

	protected override void EncodeStrip(int y, int height, TiffBaseCompressor compressor)
	{
		int width = base.Image.Width;
		if (compressor.Method == TiffCompression.CcittGroup3Fax || compressor.Method == TiffCompression.Ccitt1D || compressor.Method == TiffCompression.CcittGroup4Fax)
		{
			int stripPixels = width * height;
			if (pixelsAsGray == null)
			{
				pixelsAsGray = base.MemoryAllocator.Allocate<byte>(stripPixels);
			}
			imageBlackWhite.ProcessPixelRows(delegate(PixelAccessor<TPixel> accessor)
			{
				Span<byte> span4 = pixelsAsGray.GetSpan();
				int num9 = y + height;
				int num10 = 0;
				for (int i = y; i < num9; i++)
				{
					Span<TPixel> rowSpan = accessor.GetRowSpan(i);
					Span<byte> destBytes = span4.Slice(num10 * width, width);
					PixelOperations<TPixel>.Instance.ToL8Bytes(base.Configuration, rowSpan, destBytes, width);
					num10++;
				}
				compressor.CompressStrip(span4.Slice(0, stripPixels), height);
			});
			return;
		}
		int length = base.BytesPerRow * height;
		if (bitStrip == null)
		{
			bitStrip = base.MemoryAllocator.Allocate<byte>(length);
		}
		if (pixelsAsGray == null)
		{
			pixelsAsGray = base.MemoryAllocator.Allocate<byte>(width);
		}
		Span<byte> span = pixelsAsGray.GetSpan();
		Span<byte> rows = bitStrip.Slice(0, length);
		rows.Clear();
		Buffer2D<TPixel> pixelBuffer = imageBlackWhite.Frames.RootFrame.PixelBuffer;
		int num = 0;
		int num2 = y + height;
		for (int num3 = y; num3 < num2; num3++)
		{
			int num4 = 0;
			int num5 = 0;
			int num6 = num * base.BytesPerRow;
			Span<byte> span2 = rows.Slice(num6, rows.Length - num6);
			Span<TPixel> span3 = pixelBuffer.DangerousGetRowSpan(num3);
			PixelOperations<TPixel>.Instance.ToL8Bytes(base.Configuration, span3, span, width);
			for (int num7 = 0; num7 < base.Image.Width; num7++)
			{
				int num8 = 7 - num4;
				if (span[num7] == byte.MaxValue)
				{
					span2[num5] |= (byte)(1 << num8);
				}
				num4++;
				if (num4 == 8)
				{
					num5++;
					num4 = 0;
				}
			}
			num++;
		}
		compressor.CompressStrip(rows, height);
	}

	protected override void Dispose(bool disposing)
	{
		imageBlackWhite?.Dispose();
		pixelsAsGray?.Dispose();
		bitStrip?.Dispose();
	}
}
