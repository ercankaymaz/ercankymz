using System;
using System.Buffers;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegFrameHeader(byte samplePrecision, ushort numberOfLines, ushort samplesPerLine, byte numberOfComponents, JpegFrameComponentSpecificationParameters[]? components)
{
	public JpegFrameComponentSpecificationParameters[]? Components { get; } = components;

	public byte SamplePrecision { get; } = samplePrecision;

	public ushort NumberOfLines { get; } = numberOfLines;

	public ushort SamplesPerLine { get; } = samplesPerLine;

	public byte NumberOfComponents { get; } = numberOfComponents;

	public byte BytesRequired => (byte)(6 + 3 * NumberOfComponents);

	public static bool TryParse(ReadOnlySequence<byte> buffer, bool metadataOnly, out JpegFrameHeader frameHeader, out int bytesConsumed)
	{
		if (buffer.IsSingleSegment)
		{
			return TryParse(buffer.First.Span, metadataOnly, out frameHeader, out bytesConsumed);
		}
		bytesConsumed = 0;
		if (buffer.Length < 6)
		{
			frameHeader = default(JpegFrameHeader);
			return false;
		}
		Span<byte> destination = stackalloc byte[6];
		buffer.Slice(0, 6).CopyTo(destination);
		byte b = destination[5];
		ushort samplesPerLine = (ushort)(destination[4] | (destination[3] << 8));
		ushort numberOfLines = (ushort)(destination[2] | (destination[1] << 8));
		byte samplePrecision = destination[0];
		buffer = buffer.Slice(6L);
		bytesConsumed += 6;
		if (buffer.Length < 3 * b)
		{
			frameHeader = default(JpegFrameHeader);
			return false;
		}
		if (metadataOnly)
		{
			bytesConsumed += 3 * b;
			frameHeader = new JpegFrameHeader(samplePrecision, numberOfLines, samplesPerLine, b, null);
			return true;
		}
		JpegFrameComponentSpecificationParameters[] array = new JpegFrameComponentSpecificationParameters[b];
		for (int i = 0; i < array.Length; i++)
		{
			if (!JpegFrameComponentSpecificationParameters.TryParse(buffer, b, out array[i]))
			{
				frameHeader = default(JpegFrameHeader);
				return false;
			}
			buffer = buffer.Slice(3L);
			bytesConsumed += 3;
		}
		frameHeader = new JpegFrameHeader(samplePrecision, numberOfLines, samplesPerLine, b, array);
		return true;
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, bool metadataOnly, out JpegFrameHeader frameHeader, out int bytesConsumed)
	{
		bytesConsumed = 0;
		if (buffer.Length < 6)
		{
			frameHeader = default(JpegFrameHeader);
			return false;
		}
		byte b = buffer[5];
		ushort samplesPerLine = (ushort)(buffer[4] | (buffer[3] << 8));
		ushort numberOfLines = (ushort)(buffer[2] | (buffer[1] << 8));
		byte samplePrecision = buffer[0];
		buffer = buffer.Slice(6);
		bytesConsumed += 6;
		if (buffer.Length < 3 * b)
		{
			frameHeader = default(JpegFrameHeader);
			return false;
		}
		if (metadataOnly)
		{
			bytesConsumed += 3 * b;
			frameHeader = new JpegFrameHeader(samplePrecision, numberOfLines, samplesPerLine, b, null);
			return true;
		}
		JpegFrameComponentSpecificationParameters[] array = new JpegFrameComponentSpecificationParameters[b];
		for (int i = 0; i < array.Length; i++)
		{
			if (!JpegFrameComponentSpecificationParameters.TryParse(buffer, b, out array[i]))
			{
				frameHeader = default(JpegFrameHeader);
				return false;
			}
			buffer = buffer.Slice(3);
			bytesConsumed += 3;
		}
		frameHeader = new JpegFrameHeader(samplePrecision, numberOfLines, samplesPerLine, b, array);
		return true;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		if (buffer.Length < 6)
		{
			bytesWritten = 0;
			return false;
		}
		buffer[0] = SamplePrecision;
		buffer[1] = (byte)(NumberOfLines >> 8);
		buffer[2] = (byte)NumberOfLines;
		buffer[3] = (byte)(SamplesPerLine >> 8);
		buffer[4] = (byte)SamplesPerLine;
		buffer[5] = NumberOfComponents;
		buffer = buffer.Slice(6);
		bytesWritten = 6;
		JpegFrameComponentSpecificationParameters[] components = Components;
		if (components == null || components.Length < NumberOfComponents)
		{
			throw new InvalidOperationException("Components are not specified.");
		}
		for (int i = 0; i < NumberOfComponents; i++)
		{
			if (!components[i].TryWrite(buffer, out var bytesWritten2))
			{
				return false;
			}
			buffer = buffer.Slice(bytesWritten2);
			bytesWritten += bytesWritten2;
		}
		return true;
	}

	internal bool ShadowEquals(JpegFrameHeader other)
	{
		if (SamplePrecision == other.SamplePrecision && NumberOfLines == other.NumberOfLines && SamplesPerLine == other.SamplesPerLine)
		{
			return NumberOfComponents == other.NumberOfComponents;
		}
		return false;
	}
}
