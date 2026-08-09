using System;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal abstract class ComponentProcessor : IDisposable
{
	protected JpegFrame Frame { get; }

	protected IJpegComponent Component { get; }

	protected Buffer2D<float> ColorBuffer { get; }

	protected Size BlockAreaSize { get; }

	public ComponentProcessor(MemoryAllocator memoryAllocator, JpegFrame frame, Size postProcessorBufferSize, IJpegComponent component, int blockSize)
	{
		Frame = frame;
		Component = component;
		BlockAreaSize = component.SubSamplingDivisors * blockSize;
		ColorBuffer = memoryAllocator.Allocate2DOveraligned<float>(postProcessorBufferSize.Width, postProcessorBufferSize.Height, BlockAreaSize.Height);
	}

	public abstract void CopyBlocksToColorBuffer(int row);

	public void ClearSpectralBuffers()
	{
		Buffer2D<Block8x8> spectralBlocks = Component.SpectralBlocks;
		for (int i = 0; i < spectralBlocks.Height; i++)
		{
			spectralBlocks.DangerousGetRowSpan(i).Clear();
		}
	}

	public Span<float> GetColorBufferRowSpan(int row)
	{
		return ColorBuffer.DangerousGetRowSpan(row);
	}

	public void Dispose()
	{
		ColorBuffer.Dispose();
	}
}
