using System;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal class JpegArithmeticSequentialScanDecoder : JpegArithmeticScanDecoder
{
	private readonly JpegFrameHeader _frameHeader;

	private readonly int _maxHorizontalSampling;

	private readonly int _maxVerticalSampling;

	private readonly ushort _restartInterval;

	private readonly int _mcusPerLine;

	private readonly int _mcusPerColumn;

	private readonly int _levelShift;

	private readonly JpegArithmeticDecodingComponent[] _components;

	public JpegArithmeticSequentialScanDecoder(JpegDecoder decoder, JpegFrameHeader frameHeader)
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
		_components = new JpegArithmeticDecodingComponent[frameHeader.NumberOfComponents];
		for (int j = 0; j < _components.Length; j++)
		{
			_components[j] = new JpegArithmeticDecodingComponent();
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
		Span<JpegArithmeticDecodingComponent> span = _components.AsSpan(0, InitDecodeComponents(frameHeader, scanHeader, _components));
		JpegArithmeticDecodingComponent[] components = _components;
		foreach (JpegArithmeticDecodingComponent obj in components)
		{
			obj.DcPredictor = 0;
			obj.DcContext = 0;
			obj.DcStatistics?.Reset();
			obj.AcStatistics?.Reset();
		}
		Reset();
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
				Span<JpegArithmeticDecodingComponent> span2 = span;
				for (int i = 0; i < span2.Length; i++)
				{
					JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent = span2[i];
					int componentIndex = jpegArithmeticDecodingComponent.ComponentIndex;
					int horizontalSamplingFactor = jpegArithmeticDecodingComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegArithmeticDecodingComponent.VerticalSamplingFactor;
					int horizontalSubsamplingFactor = jpegArithmeticDecodingComponent.HorizontalSubsamplingFactor;
					int verticalSubsamplingFactor = jpegArithmeticDecodingComponent.VerticalSubsamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int y = (num2 + l) * 8;
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							JpegBlock8x8 source = default(JpegBlock8x8);
							ReadBlock(ref reader2, jpegArithmeticDecodingComponent, ref source);
							JpegScanDecoder.DequantizeBlockAndUnZigZag(jpegArithmeticDecodingComponent.QuantizationTable, ref source, ref value);
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
						JpegScanDecoder.ThrowInvalidDataException("Restart marker is expected.");
					}
					num = _restartInterval;
					Span<JpegArithmeticDecodingComponent> span3 = span;
					for (int i = 0; i < span3.Length; i++)
					{
						JpegArithmeticDecodingComponent obj2 = span3[i];
						obj2.DcPredictor = 0;
						obj2.DcContext = 0;
						obj2.DcStatistics?.Reset();
						obj2.AcStatistics?.Reset();
					}
					Reset();
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

	private void ReadBlock(ref JpegBitReader reader, JpegArithmeticDecodingComponent component, ref JpegBlock8x8 destinationBlock)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref destinationBlock);
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
		reference = (short)component.DcPredictor;
		JpegArithmeticStatistics acStatistics = component.AcStatistics;
		JpegArithmeticDecodingTable acTable = component.AcTable;
		for (int i = 1; i <= 63; i++)
		{
			reference2 = ref acStatistics.GetReference(3 * (i - 1));
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
			int num4 = DecodeBinaryDecision(ref reader, ref GetFixedBinReference());
			reference2 = ref Unsafe.Add(ref reference2, 2);
			int num5 = DecodeBinaryDecision(ref reader, ref reference2);
			if (num5 != 0 && DecodeBinaryDecision(ref reader, ref reference2) != 0)
			{
				num5 <<= 1;
				reference2 = ref acStatistics.GetReference((i <= acTable.AcKx) ? 189 : 217);
				while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					if ((num5 <<= 1) == 32768)
					{
						JpegScanDecoder.ThrowInvalidDataException("Invalid arithmetic code.");
					}
					reference2 = ref Unsafe.Add(ref reference2, 1);
				}
			}
			int num6 = num5;
			reference2 = ref Unsafe.Add(ref reference2, 14);
			while ((num5 >>= 1) != 0)
			{
				if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					num6 |= num5;
				}
			}
			num6++;
			if (num4 != 0)
			{
				num6 = -num6;
			}
			Unsafe.Add(ref reference, i) = (short)num6;
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
