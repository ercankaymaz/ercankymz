using System;
using System.Buffers;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegScanHeader(byte numberOfComponents, JpegScanComponentSpecificationParameters[]? components, byte startOfSpectralSelection, byte endOfSpectralSelection, byte successiveApproximationBitPositionHigh, byte successiveApproximationBitPositionLow)
{
	public JpegScanComponentSpecificationParameters[]? Components { get; } = components;

	public byte NumberOfComponents { get; } = numberOfComponents;

	public byte StartOfSpectralSelection { get; } = startOfSpectralSelection;

	public byte EndOfSpectralSelection { get; } = endOfSpectralSelection;

	public byte SuccessiveApproximationBitPositionHigh { get; } = successiveApproximationBitPositionHigh;

	public byte SuccessiveApproximationBitPositionLow { get; } = successiveApproximationBitPositionLow;

	public byte BytesRequired => (byte)(4 + 2 * NumberOfComponents);

	internal bool ShadowEquals(JpegScanHeader other)
	{
		if (NumberOfComponents == other.NumberOfComponents && StartOfSpectralSelection == other.StartOfSpectralSelection && EndOfSpectralSelection == other.EndOfSpectralSelection && SuccessiveApproximationBitPositionHigh == other.SuccessiveApproximationBitPositionHigh)
		{
			return SuccessiveApproximationBitPositionLow == other.SuccessiveApproximationBitPositionLow;
		}
		return false;
	}

	public static bool TryParse(ReadOnlySequence<byte> buffer, bool metadataOnly, out JpegScanHeader scanHeader, out int bytesConsumed)
	{
		ReadOnlyMemory<byte> first;
		if (buffer.IsSingleSegment)
		{
			first = buffer.First;
			return TryParse(first.Span, metadataOnly, out scanHeader, out bytesConsumed);
		}
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			scanHeader = default(JpegScanHeader);
			return false;
		}
		first = buffer.First;
		byte b = first.Span[0];
		buffer = buffer.Slice(1L);
		bytesConsumed++;
		if (buffer.Length < 2 * b + 3)
		{
			scanHeader = default(JpegScanHeader);
			return false;
		}
		JpegScanComponentSpecificationParameters[] array;
		if (metadataOnly)
		{
			array = null;
			buffer = buffer.Slice(2 * b);
			bytesConsumed += 2 * b;
		}
		else
		{
			array = new JpegScanComponentSpecificationParameters[b];
			for (int i = 0; i < array.Length; i++)
			{
				JpegScanComponentSpecificationParameters.TryParse(buffer, out array[i]);
				buffer = buffer.Slice(2L);
				bytesConsumed += 2;
			}
		}
		Span<byte> destination = stackalloc byte[4];
		buffer.Slice(0, 3).CopyTo(destination);
		byte b2 = destination[2];
		byte endOfSpectralSelection = destination[1];
		byte startOfSpectralSelection = destination[0];
		bytesConsumed += 3;
		scanHeader = new JpegScanHeader(b, array, startOfSpectralSelection, endOfSpectralSelection, (byte)(b2 >> 4), (byte)(b2 & 0xF));
		return true;
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, bool metadataOnly, out JpegScanHeader scanHeader, out int bytesConsumed)
	{
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			scanHeader = default(JpegScanHeader);
			return false;
		}
		byte b = buffer[0];
		buffer = buffer.Slice(1);
		bytesConsumed++;
		if (buffer.Length < 2 * b + 3)
		{
			scanHeader = default(JpegScanHeader);
			return false;
		}
		JpegScanComponentSpecificationParameters[] array;
		if (metadataOnly)
		{
			array = null;
			buffer = buffer.Slice(2 * b);
			bytesConsumed += 2 * b;
		}
		else
		{
			array = new JpegScanComponentSpecificationParameters[b];
			for (int i = 0; i < array.Length; i++)
			{
				JpegScanComponentSpecificationParameters.TryParse(buffer, out array[i]);
				buffer = buffer.Slice(2);
				bytesConsumed += 2;
			}
		}
		byte b2 = buffer[2];
		byte endOfSpectralSelection = buffer[1];
		byte startOfSpectralSelection = buffer[0];
		bytesConsumed += 3;
		scanHeader = new JpegScanHeader(b, array, startOfSpectralSelection, endOfSpectralSelection, (byte)(b2 >> 4), (byte)(b2 & 0xF));
		return true;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		if (buffer.IsEmpty)
		{
			bytesWritten = 0;
			return false;
		}
		buffer[0] = NumberOfComponents;
		buffer = buffer.Slice(1);
		bytesWritten = 1;
		JpegScanComponentSpecificationParameters[] components = Components;
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
		if (buffer.Length < 3)
		{
			return false;
		}
		buffer[0] = StartOfSpectralSelection;
		buffer[1] = EndOfSpectralSelection;
		buffer[2] = (byte)((SuccessiveApproximationBitPositionHigh << 4) | (SuccessiveApproximationBitPositionLow & 0xF));
		bytesWritten += 3;
		return true;
	}
}
