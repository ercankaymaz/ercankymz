using System;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal abstract class JpegHuffmanScanDecoder : JpegScanDecoder
{
	protected JpegDecoder Decoder { get; private set; }

	public JpegHuffmanScanDecoder(JpegDecoder decoder)
	{
		Decoder = decoder;
	}

	protected int InitDecodeComponents(JpegFrameHeader frameHeader, JpegScanHeader scanHeader, Span<JpegHuffmanDecodingComponent> components)
	{
		int num = 1;
		int num2 = 1;
		JpegFrameComponentSpecificationParameters[] components2 = frameHeader.Components;
		for (int i = 0; i < components2.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components2[i];
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			num2 = Math.Max(num2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		if (components.Length < scanHeader.NumberOfComponents)
		{
			throw new InvalidOperationException();
		}
		for (int j = 0; j < scanHeader.NumberOfComponents; j++)
		{
			JpegScanComponentSpecificationParameters jpegScanComponentSpecificationParameters = scanHeader.Components[j];
			int componentIndex = 0;
			JpegFrameComponentSpecificationParameters? jpegFrameComponentSpecificationParameters2 = null;
			for (int k = 0; k < frameHeader.NumberOfComponents; k++)
			{
				JpegFrameComponentSpecificationParameters value = frameHeader.Components[k];
				if (jpegScanComponentSpecificationParameters.ScanComponentSelector == value.Identifier)
				{
					componentIndex = k;
					jpegFrameComponentSpecificationParameters2 = value;
				}
			}
			if (!jpegFrameComponentSpecificationParameters2.HasValue)
			{
				JpegScanDecoder.ThrowInvalidDataException("The specified component is missing.");
			}
			JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent = components[j];
			if (jpegHuffmanDecodingComponent == null)
			{
				jpegHuffmanDecodingComponent = (components[j] = new JpegHuffmanDecodingComponent());
			}
			jpegHuffmanDecodingComponent.ComponentIndex = componentIndex;
			jpegHuffmanDecodingComponent.HorizontalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().HorizontalSamplingFactor;
			jpegHuffmanDecodingComponent.VerticalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().VerticalSamplingFactor;
			jpegHuffmanDecodingComponent.DcTable = Decoder.GetHuffmanTable(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector);
			jpegHuffmanDecodingComponent.AcTable = Decoder.GetHuffmanTable(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector);
			jpegHuffmanDecodingComponent.QuantizationTable = Decoder.GetQuantizationTable(jpegFrameComponentSpecificationParameters2.GetValueOrDefault().QuantizationTableSelector);
			jpegHuffmanDecodingComponent.HorizontalSubsamplingFactor = num / jpegHuffmanDecodingComponent.HorizontalSamplingFactor;
			jpegHuffmanDecodingComponent.VerticalSubsamplingFactor = num2 / jpegHuffmanDecodingComponent.VerticalSamplingFactor;
			jpegHuffmanDecodingComponent.DcPredictor = 0;
		}
		return scanHeader.NumberOfComponents;
	}

	protected JpegHuffmanDecodingComponent[] InitDecodeComponents(JpegFrameHeader frameHeader, JpegScanHeader scanHeader)
	{
		JpegHuffmanDecodingComponent[] array = new JpegHuffmanDecodingComponent[scanHeader.NumberOfComponents];
		InitDecodeComponents(frameHeader, scanHeader, array);
		return array;
	}

	protected static int DecodeHuffmanCode(ref JpegBitReader reader, JpegHuffmanDecodingTable table)
	{
		int bitsPeeked;
		int code16bit = reader.PeekBits(16, out bitsPeeked);
		JpegHuffmanDecodingTable.Entry entry = table.Lookup(code16bit);
		bitsPeeked = Math.Min(entry.CodeSize, bitsPeeked);
		reader.TryAdvanceBits(bitsPeeked, out var _);
		return entry.SymbolValue;
	}

	protected static JpegHuffmanDecodingTable.Entry DecodeHuffmanCode(ref JpegBitReader reader, JpegHuffmanDecodingTable table, out int code, out int bitsRead)
	{
		int num = reader.PeekBits(16, out bitsRead);
		JpegHuffmanDecodingTable.Entry result = table.Lookup(num);
		bitsRead = Math.Min(result.CodeSize, bitsRead);
		reader.TryAdvanceBits(bitsRead, out var _);
		code = num >> 16 - bitsRead;
		return result;
	}

	protected static int ReceiveAndExtend(ref JpegBitReader reader, int length)
	{
		if (!reader.TryReadBits(length, out var bits, out var isMarkerEncountered))
		{
			if (isMarkerEncountered)
			{
				JpegScanDecoder.ThrowInvalidDataException("Expect raw data from bit stream. Yet a marker is encountered.");
			}
			JpegScanDecoder.ThrowInvalidDataException("The bit stream ended prematurely.");
		}
		return Extend(bits, length);
		static int Extend(int v, int nbits)
		{
			return v - (((v + v >> nbits) - 1) & ((1 << nbits) - 1));
		}
	}
}
