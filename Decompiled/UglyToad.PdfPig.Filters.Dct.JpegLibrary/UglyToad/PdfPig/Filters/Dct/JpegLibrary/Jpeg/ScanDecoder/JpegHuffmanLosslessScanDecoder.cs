using System;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal sealed class JpegHuffmanLosslessScanDecoder : JpegHuffmanScanDecoder
{
	private readonly JpegFrameHeader _frameHeader;

	private readonly ushort _restartInterval;

	private readonly int _mcusPerLine;

	private readonly int _mcusPerColumn;

	private readonly JpegPartialScanlineAllocator _allocator;

	private readonly JpegHuffmanDecodingComponent[] _components;

	public JpegHuffmanLosslessScanDecoder(JpegDecoder decoder, JpegFrameHeader frameHeader)
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
		_restartInterval = decoder.GetRestartInterval();
		_mcusPerLine = (frameHeader.SamplesPerLine + num - 1) / num;
		_mcusPerColumn = (frameHeader.NumberOfLines + num2 - 1) / num2;
		JpegBlockOutputWriter outputWriter = decoder.GetOutputWriter();
		if (outputWriter == null)
		{
			JpegScanDecoder.ThrowInvalidDataException("Output writer is not set.");
		}
		_allocator = new JpegPartialScanlineAllocator(outputWriter, decoder.MemoryPool);
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
			if (jpegHuffmanDecodingComponent.DcTable == null)
			{
				JpegScanDecoder.ThrowInvalidDataException($"Huffman table of component {jpegHuffmanDecodingComponent.ComponentIndex} is not defined.");
			}
		}
		JpegPartialScanlineAllocator allocator = _allocator;
		int mcusPerLine = _mcusPerLine;
		int mcusPerColumn = _mcusPerColumn;
		JpegBitReader reader2 = new JpegBitReader(reader.RemainingBytes);
		int restartInterval = _restartInterval;
		int num = restartInterval;
		int startOfSpectralSelection = scanHeader.StartOfSpectralSelection;
		int num2 = 1 << _frameHeader.SamplePrecision - scanHeader.SuccessiveApproximationBitPositionLow - 1;
		for (int j = 0; j < mcusPerColumn; j++)
		{
			for (int k = 0; k < mcusPerLine; k++)
			{
				Span<JpegHuffmanDecodingComponent> span3 = span;
				for (int i = 0; i < span3.Length; i++)
				{
					JpegHuffmanDecodingComponent obj = span3[i];
					int componentIndex = obj.ComponentIndex;
					JpegHuffmanDecodingTable dcTable = obj.DcTable;
					int horizontalSamplingFactor = obj.HorizontalSamplingFactor;
					int verticalSamplingFactor = obj.VerticalSamplingFactor;
					int num3 = k * horizontalSamplingFactor;
					int num4 = j * verticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						Span<short> scanlineSpan = allocator.GetScanlineSpan(componentIndex, num4 + l);
						Span<short> span4 = ((l == 0 && j == 0) ? default(Span<short>) : allocator.GetScanlineSpan(componentIndex, num4 + l - 1));
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							int num5 = ReadSampleLossless(ref reader2, dcTable);
							if (j == 0 || (restartInterval > 0 && num == restartInterval))
							{
								if (k == 0 && m == 0)
								{
									num5 += num2;
								}
								else
								{
									int num6 = scanlineSpan[num3 + m - 1];
									int num7 = ((l == 0) ? num2 : span4[num3 + m]);
									int num8 = ((l == 0) ? num2 : span4[num3 + m - 1]);
									int num9 = num5;
									num5 = num9 + startOfSpectralSelection switch
									{
										1 => num6, 
										2 => num7, 
										3 => num8, 
										4 => num6 + num7 - num8, 
										5 => num6 + (num7 - num8 >> 1), 
										6 => num7 + (num6 - num8 >> 1), 
										7 => num6 + num7 >> 1, 
										_ => 0, 
									};
								}
							}
							else if (k == 0)
							{
								num5 += span4[num3 + m];
							}
							else
							{
								int num10 = num5;
								num5 = num10 + startOfSpectralSelection switch
								{
									1 => scanlineSpan[num3 + m - 1], 
									2 => span4[num3 + m], 
									3 => span4[num3 + m - 1], 
									4 => scanlineSpan[num3 + m - 1] + span4[num3 + m] - span4[num3 + m - 1], 
									5 => scanlineSpan[num3 + m - 1] + (span4[num3 + m] - span4[num3 + m - 1] >> 1), 
									6 => span4[num3 + m] + (scanlineSpan[num3 + m - 1] - span4[num3 + m - 1] >> 1), 
									7 => scanlineSpan[num3 + m - 1] + span4[num3 + m] >> 1, 
									_ => 0, 
								};
							}
							scanlineSpan[num3 + m] = (short)num5;
						}
					}
				}
				if (restartInterval > 0 && --num == 0)
				{
					reader2.AdvanceAlignByte();
					JpegMarker jpegMarker = reader2.TryReadMarker();
					if (jpegMarker == JpegMarker.EndOfImage)
					{
						int num11 = reader.RemainingByteCount - reader2.RemainingBits / 8;
						reader.TryAdvance(num11 - 2);
						return;
					}
					if (!jpegMarker.IsRestartMarker())
					{
						throw new InvalidOperationException("Expect restart marker.");
					}
					num = restartInterval;
				}
			}
			if (j == mcusPerColumn - 1)
			{
				Span<JpegHuffmanDecodingComponent> span5 = span;
				for (int i = 0; i < span5.Length; i++)
				{
					JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent2 = span5[i];
					allocator.FlushLastMcu(jpegHuffmanDecodingComponent2.ComponentIndex, (j + 1) * jpegHuffmanDecodingComponent2.VerticalSamplingFactor);
				}
			}
			else
			{
				Span<JpegHuffmanDecodingComponent> span6 = span;
				for (int i = 0; i < span6.Length; i++)
				{
					JpegHuffmanDecodingComponent jpegHuffmanDecodingComponent3 = span6[i];
					allocator.FlushMcu(jpegHuffmanDecodingComponent3.ComponentIndex, (j + 1) * jpegHuffmanDecodingComponent3.VerticalSamplingFactor);
				}
			}
		}
		reader2.AdvanceAlignByte();
		int num12 = reader.RemainingByteCount - reader2.RemainingBits / 8;
		if (reader2.TryPeekMarker() != 0 && !reader2.TryPeekMarker().IsRestartMarker())
		{
			num12 -= 2;
		}
		reader.TryAdvance(num12);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ReadSampleLossless(ref JpegBitReader reader, JpegHuffmanDecodingTable losslessTable)
	{
		int num = JpegHuffmanScanDecoder.DecodeHuffmanCode(ref reader, losslessTable);
		switch (num)
		{
		case 16:
			num = 32768;
			break;
		default:
			num = JpegHuffmanScanDecoder.ReceiveAndExtend(ref reader, num);
			break;
		case 0:
			break;
		}
		return num;
	}

	public override void Dispose()
	{
		_allocator.Dispose();
	}
}
