using System;
using System.Buffers;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegFrameComponentSpecificationParameters(byte identifier, byte horizontalSamplingFactor, byte verticalSamplingFactor, byte quantizationTableSelector)
{
	public byte Identifier { get; } = identifier;

	public byte HorizontalSamplingFactor { get; } = horizontalSamplingFactor;

	public byte VerticalSamplingFactor { get; } = verticalSamplingFactor;

	public byte QuantizationTableSelector { get; } = quantizationTableSelector;

	public static bool TryParse(ReadOnlySequence<byte> buffer, byte numberOfComponents, out JpegFrameComponentSpecificationParameters component)
	{
		if (buffer.IsSingleSegment)
		{
			return TryParse(buffer.First.Span, numberOfComponents, out component);
		}
		if (buffer.Length < 3)
		{
			component = default(JpegFrameComponentSpecificationParameters);
			return false;
		}
		Span<byte> destination = stackalloc byte[3];
		buffer.Slice(0, 3).CopyTo(destination);
		byte quantizationTableSelector = destination[2];
		byte b = destination[1];
		byte identifier = destination[0];
		component = new JpegFrameComponentSpecificationParameters(identifier, (byte)(b >> 4), (byte)(b & 0xF), quantizationTableSelector);
		return true;
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, byte numberOfComponents, out JpegFrameComponentSpecificationParameters component)
	{
		if (buffer.Length < 3)
		{
			component = default(JpegFrameComponentSpecificationParameters);
			return false;
		}
		byte identifier = buffer[0];
		byte b = (byte)((numberOfComponents == 1) ? 17 : buffer[1]);
		byte quantizationTableSelector = buffer[2];
		component = new JpegFrameComponentSpecificationParameters(identifier, (byte)(b >> 4), (byte)(b & 0xF), quantizationTableSelector);
		return true;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		if (buffer.Length < 3)
		{
			bytesWritten = 0;
			return false;
		}
		buffer[0] = Identifier;
		buffer[1] = (byte)((HorizontalSamplingFactor << 4) | (VerticalSamplingFactor & 0xF));
		buffer[2] = QuantizationTableSelector;
		bytesWritten = 3;
		return true;
	}
}
