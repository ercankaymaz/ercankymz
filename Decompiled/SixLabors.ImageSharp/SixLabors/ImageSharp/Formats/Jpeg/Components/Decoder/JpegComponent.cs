using System;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal class JpegComponent : IDisposable, IJpegComponent
{
	private readonly MemoryAllocator memoryAllocator;

	public byte Id { get; }

	public int DcPredictor { get; set; }

	public int HorizontalSamplingFactor { get; }

	public int VerticalSamplingFactor { get; }

	public Buffer2D<Block8x8> SpectralBlocks { get; private set; }

	public Size SubSamplingDivisors { get; private set; }

	public int QuantizationTableIndex { get; }

	public int Index { get; }

	public Size SizeInBlocks { get; private set; }

	public Size SamplingFactors { get; set; }

	public int WidthInBlocks { get; private set; }

	public int HeightInBlocks { get; private set; }

	public int DcTableId { get; set; }

	public int AcTableId { get; set; }

	public JpegFrame Frame { get; }

	public JpegComponent(MemoryAllocator memoryAllocator, JpegFrame frame, byte id, int horizontalFactor, int verticalFactor, byte quantizationTableIndex, int index)
	{
		this.memoryAllocator = memoryAllocator;
		Frame = frame;
		Id = id;
		HorizontalSamplingFactor = horizontalFactor;
		VerticalSamplingFactor = verticalFactor;
		SamplingFactors = new Size(HorizontalSamplingFactor, VerticalSamplingFactor);
		QuantizationTableIndex = quantizationTableIndex;
		Index = index;
	}

	public void Dispose()
	{
		SpectralBlocks?.Dispose();
		SpectralBlocks = null;
	}

	public void Init(int maxSubFactorH, int maxSubFactorV)
	{
		WidthInBlocks = (int)MathF.Ceiling(MathF.Ceiling((float)Frame.PixelWidth / 8f) * (float)HorizontalSamplingFactor / (float)maxSubFactorH);
		HeightInBlocks = (int)MathF.Ceiling(MathF.Ceiling((float)Frame.PixelHeight / 8f) * (float)VerticalSamplingFactor / (float)maxSubFactorV);
		int width = Frame.McusPerLine * HorizontalSamplingFactor;
		int height = Frame.McusPerColumn * VerticalSamplingFactor;
		SizeInBlocks = new Size(width, height);
		SubSamplingDivisors = new Size(maxSubFactorH, maxSubFactorV).DivideBy(SamplingFactors);
		if (SubSamplingDivisors.Width == 0 || SubSamplingDivisors.Height == 0)
		{
			JpegThrowHelper.ThrowBadSampling();
		}
	}

	public void AllocateSpectral(bool fullScan)
	{
		if (SpectralBlocks == null)
		{
			int width = SizeInBlocks.Width;
			int height = (fullScan ? SizeInBlocks.Height : VerticalSamplingFactor);
			SpectralBlocks = memoryAllocator.Allocate2D<Block8x8>(width, height, AllocationOptions.Clean);
		}
	}
}
