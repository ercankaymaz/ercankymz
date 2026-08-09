using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal sealed class DownScalingComponentProcessor8 : ComponentProcessor
{
	private readonly float dcDequantizatizer;

	public DownScalingComponentProcessor8(MemoryAllocator memoryAllocator, JpegFrame frame, IRawJpegData rawJpeg, Size postProcessorBufferSize, IJpegComponent component)
		: base(memoryAllocator, frame, postProcessorBufferSize, component, 1)
	{
		dcDequantizatizer = 0.125f * rawJpeg.QuantizationTables[component.QuantizationTableIndex][0];
	}

	public override void CopyBlocksToColorBuffer(int spectralStep)
	{
		Buffer2D<Block8x8> spectralBlocks = base.Component.SpectralBlocks;
		float maxColorChannelValue = base.Frame.MaxColorChannelValue;
		float normalizationValue = MathF.Ceiling(maxColorChannelValue * 0.5f);
		int width = base.ColorBuffer.Width;
		int height = base.Component.SamplingFactors.Height;
		Size subSamplingDivisors = base.Component.SubSamplingDivisors;
		int num = spectralStep * height;
		for (int i = 0; i < height; i++)
		{
			int y = i * base.BlockAreaSize.Height;
			Span<float> span = base.ColorBuffer.DangerousGetRowSpan(y);
			Span<Block8x8> span2 = spectralBlocks.DangerousGetRowSpan(num + i);
			for (int j = 0; j < spectralBlocks.Width; j++)
			{
				float value = ScaledFloatingPointDCT.TransformIDCT_1x1(span2[j][0], dcDequantizatizer, normalizationValue, maxColorChannelValue);
				int index = j * base.BlockAreaSize.Width;
				ScaledCopyTo(value, ref span[index], width, subSamplingDivisors.Width, subSamplingDivisors.Height);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ScaledCopyTo(float value, ref float destRef, int destStrideWidth, int horizontalScale, int verticalScale)
	{
		if (horizontalScale == 1 && verticalScale == 1)
		{
			destRef = value;
			return;
		}
		if (horizontalScale == 2 && verticalScale == 2)
		{
			destRef = value;
			Unsafe.Add(ref destRef, 1) = value;
			Unsafe.Add(ref destRef, (uint)destStrideWidth) = value;
			Unsafe.Add(ref destRef, (uint)(1 + destStrideWidth)) = value;
			return;
		}
		for (nuint num = 0u; num < (uint)verticalScale; num++)
		{
			for (nuint num2 = 0u; num2 < (uint)horizontalScale; num2++)
			{
				Unsafe.Add(ref destRef, num2) = value;
			}
			destRef = ref Unsafe.Add(ref destRef, (uint)destStrideWidth);
		}
	}
}
