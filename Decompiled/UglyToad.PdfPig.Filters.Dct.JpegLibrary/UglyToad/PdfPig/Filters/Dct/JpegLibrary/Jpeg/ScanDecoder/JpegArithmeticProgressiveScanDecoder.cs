using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal sealed class JpegArithmeticProgressiveScanDecoder : JpegArithmeticScanDecoder
{
	private readonly JpegFrameHeader _frameHeader;

	private readonly int _mcusPerLine;

	private readonly int _mcusPerColumn;

	private readonly int _levelShift;

	private ushort _restartInterval;

	private int _mcusBeforeRestart;

	private readonly JpegBlockOutputWriter _outputWriter;

	private readonly JpegBlockAllocator _allocator;

	private readonly JpegArithmeticDecodingComponent[] _components;

	public JpegArithmeticProgressiveScanDecoder(JpegDecoder decoder, JpegFrameHeader frameHeader)
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
		_components = new JpegArithmeticDecodingComponent[frameHeader.NumberOfComponents];
		for (int j = 0; j < _components.Length; j++)
		{
			_components[j] = new JpegArithmeticDecodingComponent();
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
		Span<JpegArithmeticDecodingComponent> components = _components.AsSpan(0, InitDecodeComponents(_frameHeader, scanHeader, _components));
		JpegArithmeticDecodingComponent[] components2 = _components;
		foreach (JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent in components2)
		{
			if (scanHeader.StartOfSpectralSelection == 0 && scanHeader.SuccessiveApproximationBitPositionHigh == 0)
			{
				jpegArithmeticDecodingComponent.DcPredictor = 0;
				jpegArithmeticDecodingComponent.DcContext = 0;
				jpegArithmeticDecodingComponent.DcStatistics?.Reset();
			}
			if (scanHeader.StartOfSpectralSelection != 0)
			{
				jpegArithmeticDecodingComponent.AcStatistics?.Reset();
			}
		}
		_restartInterval = base.Decoder.GetRestartInterval();
		_mcusBeforeRestart = _restartInterval;
		Reset();
		if (components.Length == 1)
		{
			DecodeProgressiveDataNonInterleaved(ref reader, scanHeader, components[0]);
		}
		else
		{
			DecodeProgressiveDataInterleaved(ref reader, scanHeader, components);
		}
	}

	private void DecodeProgressiveDataInterleaved(ref JpegReader reader, JpegScanHeader scanHeader, Span<JpegArithmeticDecodingComponent> components)
	{
		Span<JpegArithmeticDecodingComponent> span = components;
		for (int i = 0; i < span.Length; i++)
		{
			JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent = span[i];
			if (jpegArithmeticDecodingComponent.DcTable == null || jpegArithmeticDecodingComponent.DcStatistics == null)
			{
				JpegScanDecoder.ThrowInvalidDataException("DC table is missing.");
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
				Span<JpegArithmeticDecodingComponent> span2 = components;
				for (int i = 0; i < span2.Length; i++)
				{
					JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent2 = span2[i];
					int componentIndex = jpegArithmeticDecodingComponent2.ComponentIndex;
					int horizontalSamplingFactor = jpegArithmeticDecodingComponent2.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegArithmeticDecodingComponent2.VerticalSamplingFactor;
					int num = k * horizontalSamplingFactor;
					int num2 = j * verticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int blockY = num2 + l;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(componentIndex, num + m, blockY);
							ReadBlockProgressiveDC(ref bitReader, jpegArithmeticDecodingComponent2, scanHeader, ref blockReference);
						}
					}
				}
				if (!HandleRestart(ref bitReader, ref reader, ref scanHeader, ref MemoryMarshal.GetReference(components), components.Length))
				{
					return;
				}
			}
		}
	}

	private void DecodeProgressiveDataNonInterleaved(ref JpegReader reader, JpegScanHeader scanHeader, JpegArithmeticDecodingComponent component)
	{
		JpegBlockAllocator allocator = _allocator;
		JpegBitReader bitReader = new JpegBitReader(reader.RemainingBytes);
		int componentIndex = component.ComponentIndex;
		int num = (_frameHeader.SamplesPerLine + 8 * component.HorizontalSubsamplingFactor - 1) / (8 * component.HorizontalSubsamplingFactor);
		int num2 = (_frameHeader.NumberOfLines + 8 * component.VerticalSubsamplingFactor - 1) / (8 * component.VerticalSubsamplingFactor);
		if (scanHeader.StartOfSpectralSelection == 0)
		{
			if (component.DcTable == null || component.DcStatistics == null)
			{
				JpegScanDecoder.ThrowInvalidDataException("DC table is missing.");
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(componentIndex, j, i);
					ReadBlockProgressiveDC(ref bitReader, component, scanHeader, ref blockReference);
					if (!HandleRestart(ref bitReader, ref reader, ref scanHeader, ref component, 1))
					{
						return;
					}
				}
			}
			return;
		}
		if (component.AcTable == null || component.AcStatistics == null)
		{
			JpegScanDecoder.ThrowInvalidDataException("AC table is missing");
		}
		for (int k = 0; k < num2; k++)
		{
			for (int l = 0; l < num; l++)
			{
				ref JpegBlock8x8 blockReference2 = ref allocator.GetBlockReference(componentIndex, l, k);
				ReadBlockProgressiveAC(ref bitReader, component, scanHeader, ref blockReference2);
				if (!HandleRestart(ref bitReader, ref reader, ref scanHeader, ref component, 1))
				{
					return;
				}
			}
		}
	}

	private bool HandleRestart(ref JpegBitReader bitReader, ref JpegReader reader, ref JpegScanHeader scanHeader, ref JpegArithmeticDecodingComponent componentRef, int componentCount)
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
			for (int i = 0; i < componentCount; i++)
			{
				if (scanHeader.StartOfSpectralSelection == 0 && scanHeader.SuccessiveApproximationBitPositionHigh == 0)
				{
					componentRef.DcPredictor = 0;
					componentRef.DcContext = 0;
					componentRef.DcStatistics?.Reset();
				}
				if (scanHeader.StartOfSpectralSelection != 0)
				{
					componentRef.AcStatistics?.Reset();
				}
				componentRef = ref Unsafe.Add(ref componentRef, 1);
			}
			Reset();
		}
		return true;
	}

	private void ReadBlockProgressiveDC(ref JpegBitReader reader, JpegArithmeticDecodingComponent component, JpegScanHeader scanHeader, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
		if (scanHeader.SuccessiveApproximationBitPositionHigh == 0)
		{
			ref byte reference2 = ref Unsafe.Add(ref component.DcStatistics.GetReference(), component.DcContext);
			if (DecodeBinaryDecision(ref reader, ref reference2) == 0)
			{
				component.DcContext = 0;
			}
			else
			{
				int num = DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1));
				reference2 = ref Unsafe.Add(ref reference2, 2 + num);
				int num2 = DecodeBinaryDecision(ref reader, ref reference2);
				if (num2 != 0)
				{
					reference2 = ref component.DcStatistics.GetReference(20);
					while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						if ((num2 <<= 1) == 32768)
						{
							JpegScanDecoder.ThrowInvalidDataException("Invalid arithmetic code.");
						}
						reference2 = ref Unsafe.Add(ref reference2, 1);
					}
				}
				if (num2 < (int)(1L << component.DcTable.DcL >> 1))
				{
					component.DcContext = 0;
				}
				else if (num2 > (int)(1L << component.DcTable.DcU >> 1))
				{
					component.DcContext = 12 + num * 4;
				}
				else
				{
					component.DcContext = 4 + num * 4;
				}
				int num3 = num2;
				reference2 = ref Unsafe.Add(ref reference2, 14);
				while ((num2 >>= 1) != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						num3 |= num2;
					}
				}
				num3++;
				if (num != 0)
				{
					num3 = -num3;
				}
				component.DcPredictor = (short)(component.DcPredictor + num3);
			}
			reference = (short)(component.DcPredictor << (int)scanHeader.SuccessiveApproximationBitPositionLow);
		}
		else
		{
			reference |= (short)(DecodeBinaryDecision(ref reader, ref GetFixedBinReference()) << (int)scanHeader.SuccessiveApproximationBitPositionLow);
		}
	}

	private void ReadBlockProgressiveAC(ref JpegBitReader reader, JpegArithmeticDecodingComponent component, JpegScanHeader scanHeader, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
		JpegArithmeticStatistics acStatistics = component.AcStatistics;
		JpegArithmeticDecodingTable acTable = component.AcTable;
		if (scanHeader.SuccessiveApproximationBitPositionHigh == 0)
		{
			byte startOfSpectralSelection = scanHeader.StartOfSpectralSelection;
			int endOfSpectralSelection = scanHeader.EndOfSpectralSelection;
			int successiveApproximationBitPositionLow = scanHeader.SuccessiveApproximationBitPositionLow;
			for (int i = startOfSpectralSelection; i <= endOfSpectralSelection; i++)
			{
				ref byte reference2 = ref acStatistics.GetReference(3 * (i - 1));
				if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					break;
				}
				while (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1)) == 0)
				{
					reference2 = ref Unsafe.Add(ref reference2, 3);
					i++;
					if (i > 63)
					{
						JpegScanDecoder.ThrowInvalidDataException("Invalid arithmetic code.");
					}
				}
				int num = DecodeBinaryDecision(ref reader, ref GetFixedBinReference());
				reference2 = ref Unsafe.Add(ref reference2, 2);
				int num2 = DecodeBinaryDecision(ref reader, ref reference2);
				if (num2 != 0 && DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					num2 <<= 1;
					reference2 = ref acStatistics.GetReference((i <= acTable.AcKx) ? 189 : 217);
					while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						if ((num2 <<= 1) == 32768)
						{
							JpegScanDecoder.ThrowInvalidDataException("Invalid arithmetic code.");
						}
						reference2 = ref Unsafe.Add(ref reference2, 1);
					}
				}
				int num3 = num2;
				reference2 = ref Unsafe.Add(ref reference2, 14);
				while ((num2 >>= 1) != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						num3 |= num2;
					}
				}
				num3++;
				if (num != 0)
				{
					num3 = -num3;
				}
				Unsafe.Add(ref reference, i) = (short)(num3 << successiveApproximationBitPositionLow);
			}
		}
		else
		{
			ReadBlockProgressiveACRefined(ref reader, acStatistics, scanHeader, ref reference);
		}
	}

	private void ReadBlockProgressiveACRefined(ref JpegBitReader reader, JpegArithmeticStatistics acStatistics, JpegScanHeader scanHeader, ref short blockDataRef)
	{
		int startOfSpectralSelection = scanHeader.StartOfSpectralSelection;
		int endOfSpectralSelection = scanHeader.EndOfSpectralSelection;
		int num = 1 << (int)scanHeader.SuccessiveApproximationBitPositionLow;
		int num2 = -1 << (int)scanHeader.SuccessiveApproximationBitPositionLow;
		int num3 = endOfSpectralSelection;
		while (num3 > 0 && Unsafe.Add(ref blockDataRef, num3) == 0)
		{
			num3--;
		}
		for (int i = startOfSpectralSelection; i <= endOfSpectralSelection; i++)
		{
			ref byte reference = ref acStatistics.GetReference(3 * (i - 1));
			if (i > num3 && DecodeBinaryDecision(ref reader, ref reference) != 0)
			{
				break;
			}
			while (true)
			{
				ref short reference2 = ref Unsafe.Add(ref blockDataRef, i);
				if (reference2 != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference, 2)) != 0)
					{
						if (reference2 < 0)
						{
							reference2 = (short)(reference2 + num2);
						}
						else
						{
							reference2 = (short)(reference2 + num);
						}
					}
					break;
				}
				if (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference, 1)) != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref GetFixedBinReference()) != 0)
					{
						reference2 = (short)(reference2 + num2);
					}
					else
					{
						reference2 = (short)(reference2 + num);
					}
					break;
				}
				reference = ref Unsafe.Add(ref reference, 3);
				i++;
				if (i > endOfSpectralSelection)
				{
					JpegScanDecoder.ThrowInvalidDataException("Invalid arithmetic code.");
				}
			}
		}
	}

	public override void Dispose()
	{
		JpegBlockAllocator allocator = _allocator;
		int mcusPerColumn = _mcusPerColumn;
		int mcusPerLine = _mcusPerLine;
		int levelShift = _levelShift;
		JpegArithmeticDecodingComponent[] components = _components;
		Unsafe.SkipInit<JpegBlock8x8F>(out var value);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value3);
		for (int i = 0; i < mcusPerColumn; i++)
		{
			for (int j = 0; j < mcusPerLine; j++)
			{
				JpegArithmeticDecodingComponent[] array = components;
				foreach (JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent in array)
				{
					int componentIndex = jpegArithmeticDecodingComponent.ComponentIndex;
					int horizontalSamplingFactor = jpegArithmeticDecodingComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegArithmeticDecodingComponent.VerticalSamplingFactor;
					int num = j * horizontalSamplingFactor;
					int num2 = i * verticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int blockY = num2 + l;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(componentIndex, num + m, blockY);
							JpegScanDecoder.DequantizeBlockAndUnZigZag(jpegArithmeticDecodingComponent.QuantizationTable, ref blockReference, ref value);
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
