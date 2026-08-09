using System;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal sealed class JpegHuffmanBaselineScanDecoder : JpegHuffmanScanDecoder
{
	private readonly JpegFrameHeader _frameHeader;

	private readonly int _maxHorizontalSampling;

	private readonly int _maxVerticalSampling;

	private readonly ushort _restartInterval;

	private readonly int _mcusPerLine;

	private readonly int _mcusPerColumn;

	private readonly int _levelShift;

	private readonly JpegHuffmanDecodingComponent[] _components;

	public JpegHuffmanBaselineScanDecoder(JpegDecoder decoder, JpegFrameHeader frameHeader)
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
		_maxHorizontalSampling = num;
		_maxVerticalSampling = num2;
		_restartInterval = decoder.GetRestartInterval();
		_mcusPerLine = (frameHeader.SamplesPerLine + 8 * num - 1) / (8 * num);
		_mcusPerColumn = (frameHeader.NumberOfLines + 8 * num2 - 1) / (8 * num2);
		_levelShift = 1 << frameHeader.SamplePrecision - 1;
		_components = new JpegHuffmanDecodingComponent[frameHeader.NumberOfComponents];
		for (int j = 0; j < _components.Length; j++)
		{
			_components[j] = new JpegHuffmanDecodingComponent();
		}
	}

	public override void ProcessScan(ref JpegReader reader, JpegScanHeader scanHeader)
	{
		JpegFrameHeader frameHeader = _frameHeader;
		JpegBlockOutputWriter outputWriter = base.Decoder.GetOutputWriter();
		if (frameHeader.Components == null)
		{
			JpegScanDecoder.ThrowInvalidDataException("Component parameters are missing in JPEG frame header.");
		}
		if (scanHeader.Components == null)
		{
			JpegScanDecoder.ThrowInvalidDataException("Component parameters are missing in JPEG scan header.");
		}
		if (outputWriter == null)
		{
			throw new InvalidOperationException("Output writer is not specified.");
		}
		Span<JpegHuffmanDecodingComponent> span = _components.AsSpan(0, InitDecodeComponents(frameHeader, scanHeader, _components));
		Span<JpegHuffmanDecodingComponent> span2 = span;
		for (int i = 0; i < span2.Length; i++)
		{
			JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent = span2[i];
			if (jpegHuffmanDecodingComponent.DcTable == null || jpegHuffmanDecodingComponent.AcTable == null)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Huffman table of component {jpegHuffmanDecodingComponent.ComponentIndex} is not defined.");
			}
			if (jpegHuffmanDecodingComponent.QuantizationTable.IsEmpty)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Quantization table of component {jpegHuffmanDecodingComponent.ComponentIndex} is not defined.");
			}
		}
		int maxHorizontalSampling = _maxHorizontalSampling;
		int maxVerticalSampling = _maxVerticalSampling;
		int num = _restartInterval;
		int mcusPerLine = _mcusPerLine;
		int mcusPerColumn = _mcusPerColumn;
		int levelShift = _levelShift;
		JpegBitReader reader2 = new JpegBitReader(reader.RemainingBytes);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value3);
		for (int j = 0; j < mcusPerColumn; j++)
		{
			int num2 = j * maxVerticalSampling;
			for (int k = 0; k < mcusPerLine; k++)
			{
				int num3 = k * maxHorizontalSampling;
				Span<JpegHuffmanDecodingComponent> span3 = span;
				for (int i = 0; i < span3.Length; i++)
				{
					JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent2 = span3[i];
					int componentIndex = jpegHuffmanDecodingComponent2.ComponentIndex;
					int horizontalSamplingFactor = jpegHuffmanDecodingComponent2.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegHuffmanDecodingComponent2.VerticalSamplingFactor;
					int horizontalSubsamplingFactor = jpegHuffmanDecodingComponent2.HorizontalSubsamplingFactor;
					int verticalSubsamplingFactor = jpegHuffmanDecodingComponent2.VerticalSubsamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int y = (num2 + l) * 8;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							JpegBlock8x8 source = default(JpegBlock8x8);
							ReadBlockBaseline(ref reader2, jpegHuffmanDecodingComponent2, ref source);
							JpegScanDecoder.DequantizeBlockAndUnZigZag(jpegHuffmanDecodingComponent2.QuantizationTable, ref source, ref value);
							FastFloatingPointDCT.TransformIDCT(ref value, ref value2, ref value3);
							JpegScanDecoder.ShiftDataLevel(ref value2, ref source, levelShift);
							WriteBlock(outputWriter, ref Unsafe.As<JpegBlock8x8, short>(ref source), componentIndex, (num3 + m) * 8, y, horizontalSubsamplingFactor, verticalSubsamplingFactor);
						}
					}
				}
				if (_restartInterval > 0 && --num == 0)
				{
					reader2.AdvanceAlignByte();
					JpegMarker jpegMarker = reader2.TryReadMarker();
					if (jpegMarker == JpegMarker.EndOfImage)
					{
						int num4 = reader.RemainingByteCount - reader2.RemainingBits / 8;
						reader.TryAdvance(num4 - 2);
						return;
					}
					if (!jpegMarker.IsRestartMarker())
					{
						throw new InvalidOperationException("Expect restart marker.");
					}
					num = _restartInterval;
					Span<JpegHuffmanDecodingComponent> span4 = span;
					for (int i = 0; i < span4.Length; i++)
					{
						span4[i].DcPredictor = 0;
					}
				}
			}
		}
		reader2.AdvanceAlignByte();
		int num5 = reader.RemainingByteCount - reader2.RemainingBits / 8;
		if (reader2.TryPeekMarker() != 0 && !reader2.TryPeekMarker().IsRestartMarker())
		{
			num5 -= 2;
		}
		reader.TryAdvance(num5);
	}

	private static void ReadBlockBaseline(ref JpegBitReader reader, JpegHuffmanDecodingComponent component, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
		int num = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, component.DcTable);
		if (num != 0)
		{
			num = JpegHuffmanScanDecoder.ReceiveAndExtend(ref reader, num);
		}
		num = (component.DcPredictor = num + component.DcPredictor);
		reference = (short)num;
		JpegHuffmanDecodingTable acTable = component.AcTable;
		int num3 = 1;
		while (num3 < 64)
		{
			int num4 = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, acTable);
			int num5 = num4 >> 4;
			num4 &= 0xF;
			if (num4 != 0)
			{
				num3 += num5;
				num4 = JpegHuffmanScanDecoder.ReceiveAndExtend(ref reader, num4);
				Unsafe.Add(ref reference, Math.Min(num3++, 63)) = (short)num4;
				continue;
			}
			if (num5 != 0)
			{
				num3 += 16;
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void WriteBlock(JpegBlockOutputWriter outputWriter, ref short blockRef, int componentIndex, int x, int y, int horizontalSubsamplingFactor, int verticalSubsamplingFactor)
	{
		if (horizontalSubsamplingFactor == 1 && verticalSubsamplingFactor == 1)
		{
			outputWriter.WriteBlock(ref blockRef, componentIndex, x, y);
		}
		else
		{
			WriteBlockSlow(outputWriter, ref blockRef, componentIndex, x, y, horizontalSubsamplingFactor, verticalSubsamplingFactor);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WriteBlockSlow(JpegBlockOutputWriter outputWriter, ref short blockRef, int componentIndex, int x, int y, int horizontalSubsamplingFactor, int verticalSubsamplingFactor)
	{
		Unsafe.SkipInit<JpegBlock8x8>(out var value);
		int num = JpegMathHelper.Log2((uint)horizontalSubsamplingFactor);
		int num2 = JpegMathHelper.Log2((uint)verticalSubsamplingFactor);
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref Unsafe.AsRef(in value));
		for (int i = 0; i < verticalSubsamplingFactor; i++)
		{
			for (int j = 0; j < horizontalSubsamplingFactor; j++)
			{
				int num3 = 8 * i;
				int num4 = 8 * j;
				for (int k = 0; k < 8; k++)
				{
					ref short source = ref Unsafe.Add(ref reference, 8 * k);
					ref short source2 = ref Unsafe.Add(ref blockRef, (num3 + k >> num2) * 8);
					for (int l = 0; l < 8; l++)
					{
						Unsafe.Add(ref source, l) = Unsafe.Add(ref source2, num4 + l >> num);
					}
				}
				outputWriter.WriteBlock(ref reference, componentIndex, x + 8 * j, y + 8 * i);
			}
		}
	}

	public override void Dispose()
	{
	}
}
