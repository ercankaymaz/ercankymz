using System;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal sealed class JpegHuffmanProgressiveScanDecoder : JpegHuffmanScanDecoder
{
	private readonly JpegFrameHeader _frameHeader;

	private readonly int _mcusPerLine;

	private readonly int _mcusPerColumn;

	private readonly int _levelShift;

	private ushort _restartInterval;

	private int _mcusBeforeRestart;

	private int _eobrun;

	private readonly JpegBlockOutputWriter _outputWriter;

	private readonly JpegBlockAllocator _allocator;

	private readonly JpegHuffmanDecodingComponent[] _components;

	public JpegHuffmanProgressiveScanDecoder(JpegDecoder decoder, JpegFrameHeader frameHeader)
		: base(decoder)
	{
		_frameHeader = frameHeader;
		int num = 1;
		int num2 = 1;
		JpegFrameComponentSpecificationParameters[] components = frameHeader.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components[i];
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			num2 = Math.Max(num2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		_mcusPerLine = (frameHeader.SamplesPerLine + 8 * num - 1) / (8 * num);
		_mcusPerColumn = (frameHeader.NumberOfLines + 8 * num2 - 1) / (8 * num2);
		_levelShift = 1 << frameHeader.SamplePrecision - 1;
		JpegBlockOutputWriter outputWriter = decoder.GetOutputWriter();
		if (outputWriter == null)
		{
			JpegScanDecoder.ThrowInvalidDataException("Output writer is not set.");
		}
		_outputWriter = outputWriter;
		_allocator = new JpegBlockAllocator(decoder.MemoryPool);
		_allocator.Allocate(frameHeader);
		_components = new JpegHuffmanDecodingComponent[frameHeader.NumberOfComponents];
		for (int j = 0; j < _components.Length; j++)
		{
			_components[j] = new JpegHuffmanDecodingComponent();
		}
	}

	public override void ProcessScan(ref JpegReader reader, JpegScanHeader scanHeader)
	{
		if (scanHeader.Components == null)
		{
			throw new InvalidOperationException();
		}
		if (base.Decoder.GetOutputWriter() == null)
		{
			throw new InvalidOperationException();
		}
		Span<JpegHuffmanDecodingComponent> span = _components.AsSpan(0, InitDecodeComponents(_frameHeader, scanHeader, _components));
		Span<JpegHuffmanDecodingComponent> span2 = span;
		for (int i = 0; i < span2.Length; i++)
		{
			JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent = span2[i];
			if (jpegHuffmanDecodingComponent.QuantizationTable.IsEmpty)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Quantization table of component {jpegHuffmanDecodingComponent.ComponentIndex} is not defined.");
			}
		}
		_restartInterval = base.Decoder.GetRestartInterval();
		_mcusBeforeRestart = _restartInterval;
		_eobrun = 0;
		if (span.Length == 1)
		{
			DecodeProgressiveDataNonInterleaved(ref reader, scanHeader, span[0]);
		}
		else
		{
			DecodeProgressiveDataInterleaved(ref reader, scanHeader, span);
		}
	}

	private void DecodeProgressiveDataInterleaved(ref JpegReader reader, JpegScanHeader scanHeader, Span<JpegHuffmanDecodingComponent> components)
	{
		Span<JpegHuffmanDecodingComponent> span = components;
		for (int i = 0; i < span.Length; i++)
		{
			JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent = span[i];
			if (jpegHuffmanDecodingComponent.DcTable == null)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Huffman table of component {jpegHuffmanDecodingComponent.ComponentIndex} is not defined.");
			}
		}
		JpegBlockAllocator allocator = _allocator;
		JpegBitReader bitReader = new JpegBitReader(reader.RemainingBytes);
		int mcusPerColumn = _mcusPerColumn;
		int mcusPerLine = _mcusPerLine;
		for (int j = 0; j < mcusPerColumn; j++)
		{
			for (int k = 0; k < mcusPerLine; k++)
			{
				Span<JpegHuffmanDecodingComponent> span2 = components;
				for (int i = 0; i < span2.Length; i++)
				{
					JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent2 = span2[i];
					int componentIndex = jpegHuffmanDecodingComponent2.ComponentIndex;
					int horizontalSamplingFactor = jpegHuffmanDecodingComponent2.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegHuffmanDecodingComponent2.VerticalSamplingFactor;
					int num = k * horizontalSamplingFactor;
					int num2 = j * verticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int blockY = num2 + l;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							ReadBlockProgressiveDC(ref bitReader, jpegHuffmanDecodingComponent2, scanHeader, ref allocator.GetBlockReference(componentIndex, num + m, blockY));
						}
					}
				}
				if (!HandleRestart(ref bitReader, ref reader))
				{
					return;
				}
			}
		}
	}

	private void DecodeProgressiveDataNonInterleaved(ref JpegReader reader, JpegScanHeader scanHeader, JpegHuffmanDecodingComponent component)
	{
		JpegBlockAllocator allocator = _allocator;
		JpegBitReader bitReader = new JpegBitReader(reader.RemainingBytes);
		int componentIndex = component.ComponentIndex;
		int num = (_frameHeader.SamplesPerLine + 8 * component.HorizontalSubsamplingFactor - 1) / (8 * component.HorizontalSubsamplingFactor);
		int num2 = (_frameHeader.NumberOfLines + 8 * component.VerticalSubsamplingFactor - 1) / (8 * component.VerticalSubsamplingFactor);
		if (scanHeader.StartOfSpectralSelection == 0)
		{
			if (component.DcTable == null)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Huffman table of component {componentIndex} is not defined.");
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(componentIndex, j, i);
					ReadBlockProgressiveDC(ref bitReader, component, scanHeader, ref blockReference);
					if (!HandleRestart(ref bitReader, ref reader))
					{
						return;
					}
				}
			}
			return;
		}
		JpegHuffmanDecodingTable acTable = component.AcTable;
		if (acTable == null)
		{
			JpegScanDecoder.ThrowInvalidDataException($"Huffman table of component {componentIndex} is not defined.");
		}
		for (int k = 0; k < num2; k++)
		{
			for (int l = 0; l < num; l++)
			{
				ref JpegBlock8x8 blockReference2 = ref allocator.GetBlockReference(componentIndex, l, k);
				ReadBlockProgressiveAC(ref bitReader, acTable, scanHeader, ref _eobrun, ref blockReference2);
				if (!HandleRestart(ref bitReader, ref reader))
				{
					return;
				}
			}
		}
	}

	private bool HandleRestart(ref JpegBitReader bitReader, ref JpegReader reader)
	{
		if (_restartInterval > 0 && --_mcusBeforeRestart == 0)
		{
			bitReader.AdvanceAlignByte();
			JpegMarker jpegMarker = bitReader.TryReadMarker();
			if (jpegMarker == JpegMarker.EndOfImage)
			{
				int num = reader.RemainingByteCount - bitReader.RemainingBits / 8;
				reader.TryAdvance(num - 2);
				return false;
			}
			if (!jpegMarker.IsRestartMarker())
			{
				throw new InvalidOperationException("Expect restart marker.");
			}
			_mcusBeforeRestart = _restartInterval;
			_eobrun = 0;
			JpegHuffmanDecodingComponent[] components = _components;
			for (int i = 0; i < components.Length; i++)
			{
				components[i].DcPredictor = 0;
			}
		}
		return true;
	}

	private static void ReadBlockProgressiveDC(ref JpegBitReader reader, JpegHuffmanDecodingComponent component, JpegScanHeader scanHeader, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
		if (scanHeader.SuccessiveApproximationBitPositionHigh == 0)
		{
			int num = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, component.DcTable);
			if (num != 0)
			{
				num = JpegHuffmanScanDecoder.ReceiveAndExtend(ref reader, num);
			}
			num = (component.DcPredictor = num + component.DcPredictor);
			reference = (short)(num << (int)scanHeader.SuccessiveApproximationBitPositionLow);
		}
		else
		{
			if (!reader.TryReadBits(1, out var bits, out var _))
			{
				JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
			}
			reference |= (short)(bits << (int)scanHeader.SuccessiveApproximationBitPositionLow);
		}
	}

	private static void ReadBlockProgressiveAC(ref JpegBitReader reader, JpegHuffmanDecodingTable acTable, JpegScanHeader scanHeader, ref int eobrun, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
		if (scanHeader.SuccessiveApproximationBitPositionHigh == 0)
		{
			if (eobrun != 0)
			{
				eobrun--;
				return;
			}
			byte startOfSpectralSelection = scanHeader.StartOfSpectralSelection;
			int endOfSpectralSelection = scanHeader.EndOfSpectralSelection;
			int successiveApproximationBitPositionLow = scanHeader.SuccessiveApproximationBitPositionLow;
			int num;
			for (num = startOfSpectralSelection; num <= endOfSpectralSelection; num++)
			{
				int num2 = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, acTable);
				int num3 = num2 >> 4;
				num2 &= 0xF;
				num += num3;
				if (num2 != 0)
				{
					num2 = JpegHuffmanScanDecoder.ReceiveAndExtend(ref reader, num2);
					Unsafe.Add(ref reference, Math.Min(num, 63)) = (short)(num2 << successiveApproximationBitPositionLow);
				}
				else if (num3 != 15)
				{
					eobrun = 1 << num3;
					if (num3 != 0)
					{
						if (!reader.TryReadBits(num3, out var bits, out var _))
						{
							JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
						}
						eobrun += bits;
					}
					eobrun--;
					break;
				}
			}
		}
		else
		{
			ReadBlockProgressiveACRefined(ref reader, acTable, scanHeader, ref eobrun, ref reference);
		}
	}

	private static void ReadBlockProgressiveACRefined(ref JpegBitReader reader, JpegHuffmanDecodingTable acTable, JpegScanHeader scanHeader, ref int eobrun, ref short blockDataRef)
	{
		byte startOfSpectralSelection = scanHeader.StartOfSpectralSelection;
		int endOfSpectralSelection = scanHeader.EndOfSpectralSelection;
		int num = 1 << (int)scanHeader.SuccessiveApproximationBitPositionLow;
		int num2 = -1 << (int)scanHeader.SuccessiveApproximationBitPositionLow;
		int i = startOfSpectralSelection;
		if (eobrun == 0)
		{
			for (; i <= endOfSpectralSelection; i++)
			{
				int num3 = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, acTable);
				int num4 = num3 >> 4;
				num3 &= 0xF;
				if (num3 != 0)
				{
					if (!reader.TryReadBits(1, out var bits, out var _))
					{
						JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
					}
					num3 = ((bits != 0) ? num : num2);
				}
				else if (num4 != 15)
				{
					eobrun = 1 << num4;
					if (num4 != 0)
					{
						if (!reader.TryReadBits(num4, out var bits2, out var _))
						{
							JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
						}
						eobrun += bits2;
					}
					break;
				}
				do
				{
					ref short reference = ref Unsafe.Add(ref blockDataRef, i);
					if (reference != 0)
					{
						if (!reader.TryReadBits(1, out var bits3, out var _))
						{
							JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
						}
						if (bits3 != 0 && (reference & num) == 0)
						{
							reference += (short)((reference >= 0) ? num : num2);
						}
					}
					else if (--num4 < 0)
					{
						break;
					}
					i++;
				}
				while (i <= endOfSpectralSelection);
				if (num3 != 0 && i < 64)
				{
					Unsafe.Add(ref blockDataRef, i) = (short)num3;
				}
			}
		}
		if (eobrun <= 0)
		{
			return;
		}
		for (; i <= endOfSpectralSelection; i++)
		{
			ref short reference2 = ref Unsafe.Add(ref blockDataRef, i);
			if (reference2 != 0)
			{
				if (!reader.TryReadBits(1, out var bits4, out var _))
				{
					JpegScanDecoder.ThrowInvalidDataException("Unexpected end of JPEG data stream.");
				}
				if (bits4 != 0 && (reference2 & num) == 0)
				{
					reference2 += (short)((reference2 > 0) ? num : num2);
				}
			}
		}
		eobrun--;
	}

	public override void Dispose()
	{
		JpegBlockAllocator allocator = _allocator;
		int mcusPerColumn = _mcusPerColumn;
		int mcusPerLine = _mcusPerLine;
		int levelShift = _levelShift;
		JpegHuffmanDecodingComponent[] components = _components;
		Unsafe.SkipInit<JpegBlock8x8F>(out var value);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value3);
		for (int i = 0; i < mcusPerColumn; i++)
		{
			for (int j = 0; j < mcusPerLine; j++)
			{
				JpegHuffmanDecodingComponent[] array = components;
				foreach (JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent in array)
				{
					int componentIndex = jpegHuffmanDecodingComponent.ComponentIndex;
					int horizontalSamplingFactor = jpegHuffmanDecodingComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegHuffmanDecodingComponent.VerticalSamplingFactor;
					int num = j * horizontalSamplingFactor;
					int num2 = i * verticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int blockY = num2 + l;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(componentIndex, num + m, blockY);
							JpegScanDecoder.DequantizeBlockAndUnZigZag(jpegHuffmanDecodingComponent.QuantizationTable, ref blockReference, ref value);
							FastFloatingPointDCT.TransformIDCT(ref value, ref value2, ref value3);
							JpegScanDecoder.ShiftDataLevel(ref value2, ref blockReference, levelShift);
						}
					}
				}
			}
		}
		allocator.Flush(_outputWriter);
		allocator.Dispose();
	}
}
