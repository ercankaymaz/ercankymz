using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal sealed class DownScalingComponentProcessor2 : ComponentProcessor
{
	private Block8x8F dequantizationTable;

	public DownScalingComponentProcessor2(MemoryAllocator memoryAllocator, JpegFrame frame, IRawJpegData rawJpeg, Size postProcessorBufferSize, IJpegComponent component)
		: base(memoryAllocator, frame, postProcessorBufferSize, component, 4)
	{
		dequantizationTable = rawJpeg.QuantizationTables[component.QuantizationTableIndex];
		ScaledFloatingPointDCT.AdjustToIDCT(ref dequantizationTable);
	}

	public override void CopyBlocksToColorBuffer(int spectralStep)
	{
		Buffer2D<Block8x8> spectralBlocks = base.Component.SpectralBlocks;
		float maxColorChannelValue = base.Frame.MaxColorChannelValue;
		float normalizationValue = MathF.Ceiling(maxColorChannelValue * 0.5f);
		int width = base.ColorBuffer.Width;
		int height = base.Component.SamplingFactors.Height;
		Size subSamplingDivisors = base.Component.SubSamplingDivisors;
		Block8x8F block = default(Block8x8F);
		int num = spectralStep * height;
		for (int i = 0; i < height; i++)
		{
			int y = i * base.BlockAreaSize.Height;
			Span<float> span = base.ColorBuffer.DangerousGetRowSpan(y);
			Span<Block8x8> span2 = spectralBlocks.DangerousGetRowSpan(num + i);
			for (int j = 0; j < spectralBlocks.Width; j++)
			{
				block.LoadFrom(ref span2[j]);
				ScaledFloatingPointDCT.TransformIDCT_4x4(ref block, ref dequantizationTable, normalizationValue, maxColorChannelValue);
				int index = j * base.BlockAreaSize.Width;
				ScaledCopyTo(ref block, ref span[index], width, subSamplingDivisors.Width, subSamplingDivisors.Height);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ScaledCopyTo(ref Block8x8F block, ref float destRef, int destStrideWidth, int horizontalScale, int verticalScale)
	{
		CopyArbitraryScale(ref block, ref destRef, (uint)destStrideWidth, (uint)horizontalScale, (uint)verticalScale);
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void CopyArbitraryScale(ref Block8x8F reference, ref float areaOrigin, uint areaStride, uint num7, uint num3)
		{
			for (nuint num = 0u; num < 4; num++)
			{
				nuint num2 = num * num3;
				nuint num4 = num * 8;
				for (nuint num5 = 0u; num5 < 4; num5++)
				{
					nuint num6 = num5 * num7;
					float num8 = reference[num4 + num5];
					for (nuint num9 = 0u; num9 < num3; num9++)
					{
						nuint num10 = (num2 + num9) * areaStride + num6;
						for (nuint num11 = 0u; num11 < num7; num11++)
						{
							Unsafe.Add(ref areaOrigin, num10 + num11) = num8;
						}
					}
				}
			}
		}
	}
}
