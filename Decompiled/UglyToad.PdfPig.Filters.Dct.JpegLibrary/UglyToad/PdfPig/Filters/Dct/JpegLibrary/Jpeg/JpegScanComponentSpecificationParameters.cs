using System;
using System.Buffers;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegScanComponentSpecificationParameters(byte scanComponentSelector, byte dcEntropyCodingTableSelector, byte acEntropyCodingTableSelector)
{
	public byte ScanComponentSelector { get; } = scanComponentSelector;

	public byte DcEntropyCodingTableSelector { get; } = dcEntropyCodingTableSelector;

	public byte AcEntropyCodingTableSelector { get; } = acEntropyCodingTableSelector;

	public static bool TryParse(ReadOnlySequence<byte> buffer, out JpegScanComponentSpecificationParameters component)
	{
		if (buffer.IsSingleSegment)
		{
			return TryParse(buffer.First.Span, out component);
		}
		if (buffer.Length < 2)
		{
			component = default(JpegScanComponentSpecificationParameters);
			return false;
		}
		Span<byte> destination = stackalloc byte[2];
		buffer.Slice(0, 2).CopyTo(destination);
		byte b = destination[1];
		byte scanComponentSelector = destination[0];
		component = new JpegScanComponentSpecificationParameters(scanComponentSelector, (byte)(b >> 4), (byte)(b & 0xF));
		return true;
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, out JpegScanComponentSpecificationParameters component)
	{
		if (buffer.Length < 2)
		{
			component = default(JpegScanComponentSpecificationParameters);
			return false;
		}
		byte b = buffer[1];
		byte scanComponentSelector = buffer[0];
		component = new JpegScanComponentSpecificationParameters(scanComponentSelector, (byte)(b >> 4), (byte)(b & 0xF));
		return true;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		if (buffer.Length < 2)
		{
			bytesWritten = 0;
			return false;
		}
		buffer[0] = ScanComponentSelector;
		buffer[1] = (byte)((DcEntropyCodingTableSelector << 4) | (AcEntropyCodingTableSelector & 0xF));
		bytesWritten = 2;
		return true;
	}
}
