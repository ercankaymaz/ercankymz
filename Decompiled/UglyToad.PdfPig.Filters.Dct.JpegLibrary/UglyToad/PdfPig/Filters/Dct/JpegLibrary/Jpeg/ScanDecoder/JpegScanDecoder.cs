using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal abstract class JpegScanDecoder : IDisposable
{
	public abstract void ProcessScan(ref JpegReader reader, JpegScanHeader scanHeader);

	public abstract void Dispose();

	public static JpegScanDecoder? Create(JpegMarker sofMarker, JpegDecoder decoder, JpegFrameHeader header)
	{
		switch (sofMarker)
		{
		case JpegMarker.StartOfFrame0:
		case JpegMarker.StartOfFrame1:
			return new JpegHuffmanBaselineScanDecoder(decoder, header);
		case JpegMarker.StartOfFrame2:
			return new JpegHuffmanProgressiveScanDecoder(decoder, header);
		case JpegMarker.StartOfFrame3:
			return new JpegHuffmanLosslessScanDecoder(decoder, header);
		case JpegMarker.StartOfFrame9:
			return new JpegArithmeticSequentialScanDecoder(decoder, header);
		case JpegMarker.StartOfFrame10:
			return new JpegArithmeticProgressiveScanDecoder(decoder, header);
		default:
			return null;
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	protected static void ThrowInvalidDataException(string message)
	{
		throw new InvalidDataException("Failed to decode JPEG data. " + message);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	protected static void ThrowInvalidDataException(int offset, string message)
	{
		throw new InvalidDataException($"Failed to decode JPEG data at offset {offset}. {message}");
	}

	protected static void DequantizeBlockAndUnZigZag(JpegQuantizationTable quantizationTable, ref JpegBlock8x8 input, ref JpegBlock8x8F output)
	{
		ref ushort reference = ref MemoryMarshal.GetReference(quantizationTable.Elements);
		ref short source = ref Unsafe.As<JpegBlock8x8, short>(ref input);
		ref float source2 = ref Unsafe.As<JpegBlock8x8F, float>(ref output);
		for (int i = 0; i < 64; i++)
		{
			Unsafe.Add(ref source2, JpegZigZag.InternalBufferIndexToBlock(i)) = Unsafe.Add(ref reference, i) * Unsafe.Add(ref source, i);
		}
	}

	protected static void ShiftDataLevel(ref JpegBlock8x8F source, ref JpegBlock8x8 destination, int levelShift)
	{
		ref float source2 = ref Unsafe.As<JpegBlock8x8F, float>(ref source);
		ref short source3 = ref Unsafe.As<JpegBlock8x8, short>(ref destination);
		for (int i = 0; i < 64; i++)
		{
			Unsafe.Add(ref source3, i) = (short)(JpegMathHelper.RoundToInt32(Unsafe.Add(ref source2, i)) + levelShift);
		}
	}
}
