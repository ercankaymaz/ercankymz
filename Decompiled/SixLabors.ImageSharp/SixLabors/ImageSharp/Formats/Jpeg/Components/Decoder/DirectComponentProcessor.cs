using System;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal sealed class DirectComponentProcessor : ComponentProcessor
{
	private Block8x8F dequantizationTable;

	public DirectComponentProcessor(MemoryAllocator memoryAllocator, JpegFrame frame, IRawJpegData rawJpeg, Size postProcessorBufferSize, IJpegComponent component)
		: base(memoryAllocator, frame, postProcessorBufferSize, component, 8)
	{
		dequantizationTable = rawJpeg.QuantizationTables[component.QuantizationTableIndex];
		FloatingPointDCT.AdjustToIDCT(ref dequantizationTable);
	}

	public override void CopyBlocksToColorBuffer(int spectralStep)
	{
		Buffer2D<Block8x8> spectralBlocks = base.Component.SpectralBlocks;
		float maxColorChannelValue = base.Frame.MaxColorChannelValue;
		int width = base.ColorBuffer.Width;
		int height = base.Component.SamplingFactors.Height;
		int num = spectralStep * height;
		Size subSamplingDivisors = base.Component.SubSamplingDivisors;
		Block8x8F block = default(Block8x8F);
		for (int i = 0; i < height; i++)
		{
			int y = i * base.BlockAreaSize.Height;
			Span<float> span = base.ColorBuffer.DangerousGetRowSpan(y);
			Span<Block8x8> span2 = spectralBlocks.DangerousGetRowSpan(num + i);
			for (int j = 0; j < spectralBlocks.Width; j++)
			{
				block.LoadFrom(ref span2[j]);
				block.MultiplyInPlace(ref dequantizationTable);
				FloatingPointDCT.TransformIDCT(ref block);
				block.NormalizeColorsAndRoundInPlace(maxColorChannelValue);
				int index = j * base.BlockAreaSize.Width;
				block.ScaledCopyTo(ref span[index], width, subSamplingDivisors.Width, subSamplingDivisors.Height);
			}
		}
	}
}
