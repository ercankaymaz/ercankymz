using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegOptimizer
{
	private readonly int _minimumBufferSegmentSize;

	private ReadOnlySequence<byte> _inputBuffer;

	private JpegFrameHeader? _frameHeader;

	private ushort _restartInterval;

	private List<JpegQuantizationTable>? _quantizationTables;

	private List<JpegHuffmanDecodingTable>? _huffmanTables;

	private JpegHuffmanEncodingTableCollection _encodingTables;

	private IBufferWriter<byte>? _output;

	public bool MostOptimalCoding { get; set; }

	public JpegOptimizer()
		: this(4096)
	{
	}

	public JpegOptimizer(int minimumBufferSegmentSize)
	{
		_minimumBufferSegmentSize = minimumBufferSegmentSize;
	}

	public void SetInput(ReadOnlyMemory<byte> input)
	{
		SetInput(new ReadOnlySequence<byte>(input));
	}

	public void SetInput(ReadOnlySequence<byte> input)
	{
		_inputBuffer = input;
		_frameHeader = null;
		_restartInterval = 0;
	}

	public void Scan()
	{
		if (_inputBuffer.IsEmpty)
		{
			throw new InvalidOperationException("Input buffer is not specified.");
		}
		JpegReader reader = new JpegReader(_inputBuffer);
		_frameHeader = null;
		bool flag = false;
		bool flag2 = false;
		while (!flag2 && !reader.IsEmpty)
		{
			if (!reader.TryReadMarker(out var marker))
			{
				ThrowInvalidDataException(reader.ConsumedByteCount, "No marker found.");
				return;
			}
			switch (marker)
			{
			case JpegMarker.StartOfFrame0:
				ProcessFrameHeader(ref reader, metadataOnly: false, overrideAllowed: false);
				break;
			case JpegMarker.StartOfFrame1:
				ProcessFrameHeader(ref reader, metadataOnly: false, overrideAllowed: false);
				break;
			case JpegMarker.StartOfFrame3:
			case JpegMarker.StartOfFrame5:
			case JpegMarker.StartOfFrame6:
			case JpegMarker.StartOfFrame7:
			case JpegMarker.StartOfFrame9:
			case JpegMarker.StartOfFrame10:
			case JpegMarker.StartOfFrame11:
			case JpegMarker.StartOfFrame13:
			case JpegMarker.StartOfFrame14:
			case JpegMarker.StartOfFrame15:
				ThrowInvalidDataException(reader.ConsumedByteCount, $"This type of JPEG stream is not supported ({marker}).");
				return;
			case JpegMarker.DefineHuffmanTable:
				ProcessDefineHuffmanTable(ref reader);
				break;
			case JpegMarker.DefineQuantizationTable:
				ProcessDefineQuantizationTable(ref reader);
				break;
			case JpegMarker.DefineRestartInterval:
				ProcessDefineRestartInterval(ref reader);
				break;
			case JpegMarker.StartOfScan:
			{
				JpegScanHeader scanHeader = ProcessScanHeader(ref reader, metadataOnly: false);
				ProcessScanBaseline(ref reader, scanHeader);
				flag = true;
				break;
			}
			case JpegMarker.EndOfImage:
				flag2 = true;
				break;
			default:
				ProcessOtherMarker(ref reader);
				break;
			case JpegMarker.DefineRestart0:
			case JpegMarker.DefineRestart1:
			case JpegMarker.DefineRestart2:
			case JpegMarker.DefineRestart3:
			case JpegMarker.DefineRestart4:
			case JpegMarker.DefineRestart5:
			case JpegMarker.DefineRestart6:
			case JpegMarker.DefineRestart7:
			case JpegMarker.StartOfImage:
				break;
			}
		}
		if (!flag)
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "No image data is read.");
		}
	}

	private void ProcessFrameHeader(ref JpegReader reader, bool metadataOnly, bool overrideAllowed)
	{
		ReadOnlySequence<byte> bytes;
		JpegFrameHeader frameHeader;
		int bytesConsumed;
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		else if (!reader.TryReadBytes(length, out bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		else if (!JpegFrameHeader.TryParse(bytes, metadataOnly, out frameHeader, out bytesConsumed))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount - length + bytesConsumed, "Failed to parse frame header.");
		}
		else if (!overrideAllowed && _frameHeader.HasValue)
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Multiple frame is not supported.");
		}
		else
		{
			_frameHeader = frameHeader;
		}
	}

	private static void ProcessOtherMarker(ref JpegReader reader)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		else if (!reader.TryAdvance(length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data reached.");
		}
	}

	private static JpegScanHeader ProcessScanHeader(ref JpegReader reader, bool metadataOnly)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		if (!reader.TryReadBytes(length, out var bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		if (!JpegScanHeader.TryParse(bytes, metadataOnly, out var scanHeader, out var bytesConsumed))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount - length + bytesConsumed, "Failed to parse scan header.");
		}
		return scanHeader;
	}

	private void ProcessDefineRestartInterval(ref JpegReader reader)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
			return;
		}
		if (!reader.TryReadBytes(length, out var bytes) || bytes.Length < 2)
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
			return;
		}
		Span<byte> span = stackalloc byte[2];
		bytes.Slice(0, 2).CopyTo(span);
		_restartInterval = BinaryPrimitives.ReadUInt16BigEndian(span);
	}

	private void ProcessDefineHuffmanTable(ref JpegReader reader)
	{
		ReadOnlySequence<byte> bytes;
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		else if (!reader.TryReadBytes(length, out bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		else
		{
			ProcessDefineHuffmanTable(bytes, reader.ConsumedByteCount - length);
		}
	}

	private void ProcessDefineHuffmanTable(ReadOnlySequence<byte> segment, int currentOffset)
	{
		while (!segment.IsEmpty)
		{
			if (!JpegHuffmanDecodingTable.TryParse(segment, out JpegHuffmanDecodingTable huffmanTable, out int bytesConsumed))
			{
				ThrowInvalidDataException(currentOffset, "Failed to parse Huffman table.");
				break;
			}
			segment = segment.Slice(bytesConsumed);
			currentOffset += bytesConsumed;
			SetHuffmanTable(huffmanTable);
		}
	}

	private void ProcessDefineQuantizationTable(ref JpegReader reader)
	{
		ReadOnlySequence<byte> bytes;
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		else if (!reader.TryReadBytes(length, out bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		else
		{
			ProcessDefineQuantizationTable(bytes, reader.ConsumedByteCount - length);
		}
	}

	private void ProcessDefineQuantizationTable(ReadOnlySequence<byte> segment, int currentOffset)
	{
		while (!segment.IsEmpty)
		{
			if (!JpegQuantizationTable.TryParse(segment, out var quantizationTable, out var bytesConsumed))
			{
				ThrowInvalidDataException(currentOffset, "Failed to parse quantization table.");
				break;
			}
			segment = segment.Slice(bytesConsumed);
			currentOffset += bytesConsumed;
			SetQuantizationTable(quantizationTable);
		}
	}

	private void SetHuffmanTable(JpegHuffmanDecodingTable table)
	{
		List<JpegHuffmanDecodingTable> list = _huffmanTables;
		if (list == null)
		{
			list = (_huffmanTables = new List<JpegHuffmanDecodingTable>(4));
		}
		for (int i = 0; i < list.Count; i++)
		{
			JpegHuffmanDecodingTable jpegHuffmanDecodingTable = list[i];
			if (jpegHuffmanDecodingTable.TableClass == table.TableClass && jpegHuffmanDecodingTable.Identifier == table.Identifier)
			{
				list[i] = table;
				return;
			}
		}
		list.Add(table);
	}

	private JpegHuffmanDecodingTable? GetHuffmanTable(bool isDcTable, byte identifier)
	{
		List<JpegHuffmanDecodingTable> huffmanTables = _huffmanTables;
		if (huffmanTables == null)
		{
			return null;
		}
		int num = ((!isDcTable) ? 1 : 0);
		foreach (JpegHuffmanDecodingTable item in huffmanTables)
		{
			if (item.TableClass == num && item.Identifier == identifier)
			{
				return item;
			}
		}
		return null;
	}

	internal void SetQuantizationTable(JpegQuantizationTable table)
	{
		List<JpegQuantizationTable> list = _quantizationTables;
		if (list == null)
		{
			list = (_quantizationTables = new List<JpegQuantizationTable>(2));
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Identifier == table.Identifier)
			{
				list[i] = table;
				return;
			}
		}
		list.Add(table);
	}

	private void ProcessScanBaseline(ref JpegReader reader, JpegScanHeader scanHeader)
	{
		JpegFrameHeader valueOrDefault = _frameHeader.GetValueOrDefault();
		if (scanHeader.Components == null)
		{
			throw new InvalidOperationException();
		}
		byte b = 1;
		byte b2 = 1;
		JpegFrameComponentSpecificationParameters[] components = valueOrDefault.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components[i];
			b = Math.Max(b, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			b2 = Math.Max(b2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		using JpegHuffmanEncodingTableBuilderCollection jpegHuffmanEncodingTableBuilderCollection = default(JpegHuffmanEncodingTableBuilderCollection);
		JpegTranscodeComponent[] array = new JpegTranscodeComponent[scanHeader.NumberOfComponents];
		for (int j = 0; j < scanHeader.NumberOfComponents; j++)
		{
			JpegScanComponentSpecificationParameters jpegScanComponentSpecificationParameters = scanHeader.Components[j];
			int componentIndex = 0;
			JpegFrameComponentSpecificationParameters? jpegFrameComponentSpecificationParameters2 = null;
			for (int k = 0; k < valueOrDefault.NumberOfComponents; k++)
			{
				JpegFrameComponentSpecificationParameters value = valueOrDefault.Components[k];
				if (jpegScanComponentSpecificationParameters.ScanComponentSelector == value.Identifier)
				{
					componentIndex = k;
					jpegFrameComponentSpecificationParameters2 = value;
				}
			}
			if (!jpegFrameComponentSpecificationParameters2.HasValue)
			{
				throw new InvalidDataException();
			}
			array[j] = new JpegTranscodeComponent
			{
				ComponentIndex = componentIndex,
				HorizontalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().HorizontalSamplingFactor,
				VerticalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().VerticalSamplingFactor,
				DcTable = GetHuffmanTable(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector),
				AcTable = GetHuffmanTable(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector),
				DcTableBuilder = jpegHuffmanEncodingTableBuilderCollection.GetOrCreateTableBuilder(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector),
				AcTableBuilder = jpegHuffmanEncodingTableBuilderCollection.GetOrCreateTableBuilder(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector)
			};
		}
		int num = (valueOrDefault.SamplesPerLine + 8 * b - 1) / (8 * b);
		int num2 = (valueOrDefault.NumberOfLines + 8 * b2 - 1) / (8 * b2);
		JpegBitReader reader2 = new JpegBitReader(reader.RemainingBytes);
		int num3 = _restartInterval;
		for (int l = 0; l < num2; l++)
		{
			for (int m = 0; m < num; m++)
			{
				JpegTranscodeComponent[] array2 = array;
				foreach (JpegTranscodeComponent jpegTranscodeComponent in array2)
				{
					int horizontalSamplingFactor = jpegTranscodeComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegTranscodeComponent.VerticalSamplingFactor;
					for (int n = 0; n < verticalSamplingFactor; n++)
					{
						for (int num4 = 0; num4 < horizontalSamplingFactor; num4++)
						{
							ProcessBlockBaseline(ref reader2, jpegTranscodeComponent);
						}
					}
				}
				if (_restartInterval > 0 && --num3 == 0)
				{
					reader2.AdvanceAlignByte();
					JpegMarker jpegMarker = reader2.TryReadMarker();
					if (jpegMarker == JpegMarker.EndOfImage)
					{
						int num5 = reader.RemainingByteCount - reader2.RemainingBits / 8;
						reader.TryAdvance(num5 - 2);
						return;
					}
					if (!jpegMarker.IsRestartMarker())
					{
						throw new InvalidOperationException("Expect restart marker.");
					}
					num3 = _restartInterval;
				}
			}
		}
		reader2.AdvanceAlignByte();
		int num6 = reader.RemainingByteCount - reader2.RemainingBits / 8;
		if (reader2.TryPeekMarker() != 0 && !reader2.TryPeekMarker().IsRestartMarker())
		{
			num6 -= 2;
		}
		reader.TryAdvance(num6);
		_encodingTables = jpegHuffmanEncodingTableBuilderCollection.BuildTables(MostOptimalCoding);
	}

	private static void ProcessBlockBaseline(ref JpegBitReader reader, JpegTranscodeComponent component)
	{
		int num = DecodeHuffmanCode(ref reader, component.DcTable);
		component.DcTableBuilder.IncrementCodeCount(num);
		if (num != 0)
		{
			Receive(ref reader, num);
		}
		int num2 = 1;
		while (num2 < 64)
		{
			int num3 = DecodeHuffmanCode(ref reader, component.AcTable);
			component.AcTableBuilder.IncrementCodeCount(num3);
			int num4 = num3 >> 4;
			num3 &= 0xF;
			if (num3 != 0)
			{
				num2 += num4;
				num2++;
				Receive(ref reader, num3);
				continue;
			}
			if (num4 != 0)
			{
				num2 += 16;
				continue;
			}
			break;
		}
	}

	private static int DecodeHuffmanCode(ref JpegBitReader reader, JpegHuffmanDecodingTable table)
	{
		int bitsPeeked;
		int code16bit = reader.PeekBits(16, out bitsPeeked);
		JpegHuffmanDecodingTable.Entry entry = table.Lookup(code16bit);
		bitsPeeked = Math.Min(entry.CodeSize, bitsPeeked);
		reader.TryAdvanceBits(bitsPeeked, out var _);
		return entry.SymbolValue;
	}

	private static int Receive(ref JpegBitReader reader, int length)
	{
		if (!reader.TryReadBits(length, out var bits, out var isMarkerEncountered))
		{
			if (isMarkerEncountered)
			{
				ThrowInvalidDataException("Expect raw data from bit stream. Yet a marker is encountered.");
			}
			ThrowInvalidDataException("The bit stream ended prematurely.");
		}
		return bits;
	}

	public void SetOutput(IBufferWriter<byte> output)
	{
		_output = output ?? throw new ArgumentNullException("output");
	}

	public void Optimize(bool strip = true)
	{
		if (_encodingTables.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		IBufferWriter<byte> writer = _output ?? throw new InvalidOperationException();
		JpegReader reader = new JpegReader(_inputBuffer);
		JpegWriter writer2 = new JpegWriter(writer, _minimumBufferSegmentSize);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		while (!flag && !reader.IsEmpty)
		{
			if (!reader.TryReadMarker(out var marker))
			{
				ThrowInvalidDataException(reader.ConsumedByteCount, "No marker found.");
				return;
			}
			switch (marker)
			{
			case JpegMarker.StartOfImage:
				writer2.WriteMarker(marker);
				break;
			case JpegMarker.StartOfFrame0:
			case JpegMarker.StartOfFrame1:
			case JpegMarker.App0:
				writer2.WriteMarker(marker);
				CopyMarkerData(ref reader, ref writer2);
				break;
			case JpegMarker.StartOfFrame2:
				ProcessFrameHeader(ref reader, metadataOnly: false, overrideAllowed: true);
				throw new InvalidDataException("Progressive JPEG is not supported currently.");
			case JpegMarker.StartOfFrame3:
			case JpegMarker.StartOfFrame5:
			case JpegMarker.StartOfFrame6:
			case JpegMarker.StartOfFrame7:
			case JpegMarker.StartOfFrame9:
			case JpegMarker.StartOfFrame10:
			case JpegMarker.StartOfFrame11:
			case JpegMarker.StartOfFrame13:
			case JpegMarker.StartOfFrame14:
			case JpegMarker.StartOfFrame15:
				ThrowInvalidDataException(reader.ConsumedByteCount, $"This type of JPEG stream is not supported ({marker}).");
				return;
			case JpegMarker.DefineHuffmanTable:
				if (!flag2)
				{
					WriteHuffmanTables(ref writer2);
					flag2 = true;
				}
				break;
			case JpegMarker.DefineQuantizationTable:
				if (!flag3)
				{
					WriteQuantizationTables(ref writer2);
					flag3 = true;
				}
				break;
			case JpegMarker.StartOfScan:
			{
				writer2.WriteMarker(marker);
				ReadOnlySequence<byte> buffer = CopyMarkerData(ref reader, ref writer2);
				if (!JpegScanHeader.TryParse(buffer, metadataOnly: false, out var scanHeader, out var _))
				{
					ThrowInvalidDataException(reader.ConsumedByteCount - (int)buffer.Length, "Failed to parse scan header.");
				}
				CopyScanBaseline(ref reader, ref writer2, scanHeader);
				break;
			}
			case JpegMarker.DefineRestart0:
			case JpegMarker.DefineRestart1:
			case JpegMarker.DefineRestart2:
			case JpegMarker.DefineRestart3:
			case JpegMarker.DefineRestart4:
			case JpegMarker.DefineRestart5:
			case JpegMarker.DefineRestart6:
			case JpegMarker.DefineRestart7:
				writer2.WriteMarker(marker);
				break;
			case JpegMarker.EndOfImage:
				writer2.WriteMarker(JpegMarker.EndOfImage);
				flag = true;
				break;
			default:
				if (strip)
				{
					SkipMarkerData(ref reader);
					break;
				}
				writer2.WriteMarker(marker);
				CopyMarkerData(ref reader, ref writer2);
				break;
			}
		}
		writer2.Flush();
	}

	private static void SkipMarkerData(ref JpegReader reader)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		if (!reader.TryAdvance(length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
	}

	private static ReadOnlySequence<byte> CopyMarkerData(ref JpegReader reader, ref JpegWriter writer)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		if (!reader.TryReadBytes(length, out var bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		writer.WriteLength(length);
		writer.WriteBytes(bytes);
		return bytes;
	}

	private void WriteHuffmanTables(ref JpegWriter writer)
	{
		if (_encodingTables.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		writer.WriteMarker(JpegMarker.DefineHuffmanTable);
		ushort totalBytesRequired = _encodingTables.GetTotalBytesRequired();
		writer.WriteLength(totalBytesRequired);
		_encodingTables.Write(ref writer);
	}

	private void WriteQuantizationTables(ref JpegWriter writer)
	{
		List<JpegQuantizationTable> quantizationTables = _quantizationTables;
		if (quantizationTables == null)
		{
			throw new InvalidOperationException();
		}
		writer.WriteMarker(JpegMarker.DefineQuantizationTable);
		ushort num = 0;
		foreach (JpegQuantizationTable item in quantizationTables)
		{
			num += item.BytesRequired;
		}
		writer.WriteLength(num);
		foreach (JpegQuantizationTable item2 in quantizationTables)
		{
			Span<byte> span = writer.GetSpan(item2.BytesRequired);
			item2.TryWrite(span, out var bytesWritten);
			writer.Advance(bytesWritten);
		}
	}

	private void CopyScanBaseline(ref JpegReader reader, ref JpegWriter writer, JpegScanHeader scanHeader)
	{
		JpegFrameHeader valueOrDefault = _frameHeader.GetValueOrDefault();
		if (scanHeader.Components == null)
		{
			throw new InvalidOperationException();
		}
		byte b = 1;
		byte b2 = 1;
		JpegFrameComponentSpecificationParameters[] components = valueOrDefault.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components[i];
			b = Math.Max(b, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			b2 = Math.Max(b2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		JpegTranscodeComponent[] array = new JpegTranscodeComponent[scanHeader.NumberOfComponents];
		for (int j = 0; j < scanHeader.NumberOfComponents; j++)
		{
			JpegScanComponentSpecificationParameters jpegScanComponentSpecificationParameters = scanHeader.Components[j];
			int componentIndex = 0;
			JpegFrameComponentSpecificationParameters? jpegFrameComponentSpecificationParameters2 = null;
			for (int k = 0; k < valueOrDefault.NumberOfComponents; k++)
			{
				JpegFrameComponentSpecificationParameters value = valueOrDefault.Components[k];
				if (jpegScanComponentSpecificationParameters.ScanComponentSelector == value.Identifier)
				{
					componentIndex = k;
					jpegFrameComponentSpecificationParameters2 = value;
				}
			}
			if (!jpegFrameComponentSpecificationParameters2.HasValue)
			{
				throw new InvalidDataException();
			}
			array[j] = new JpegTranscodeComponent
			{
				ComponentIndex = componentIndex,
				HorizontalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().HorizontalSamplingFactor,
				VerticalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().VerticalSamplingFactor,
				DcTable = GetHuffmanTable(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector),
				AcTable = GetHuffmanTable(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector),
				DcEncodingTable = _encodingTables.GetTable(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector),
				AcEncodingTable = _encodingTables.GetTable(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector)
			};
		}
		int num = (valueOrDefault.SamplesPerLine + 8 * b - 1) / (8 * b);
		int num2 = (valueOrDefault.NumberOfLines + 8 * b2 - 1) / (8 * b2);
		JpegBitReader reader2 = new JpegBitReader(reader.RemainingBytes);
		int num3 = _restartInterval;
		bool flag = false;
		writer.EnterBitMode();
		for (int l = 0; l < num2; l++)
		{
			if (flag)
			{
				break;
			}
			for (int m = 0; m < num; m++)
			{
				if (flag)
				{
					break;
				}
				JpegTranscodeComponent[] array2 = array;
				foreach (JpegTranscodeComponent jpegTranscodeComponent in array2)
				{
					int horizontalSamplingFactor = jpegTranscodeComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegTranscodeComponent.VerticalSamplingFactor;
					for (int n = 0; n < verticalSamplingFactor; n++)
					{
						for (int num4 = 0; num4 < horizontalSamplingFactor; num4++)
						{
							CopyBlockBaseline(ref reader2, ref writer, jpegTranscodeComponent);
						}
					}
				}
				if (_restartInterval > 0 && --num3 == 0)
				{
					reader2.AdvanceAlignByte();
					JpegMarker jpegMarker = reader2.TryReadMarker();
					if (jpegMarker == JpegMarker.EndOfImage)
					{
						flag = true;
						break;
					}
					if (!jpegMarker.IsRestartMarker())
					{
						throw new InvalidOperationException("Expect restart marker.");
					}
					num3 = _restartInterval;
					writer.ExitBitMode();
					writer.WriteMarker(jpegMarker);
					writer.EnterBitMode();
				}
			}
		}
		reader2.AdvanceAlignByte();
		writer.ExitBitMode();
		int num5 = reader.RemainingByteCount - reader2.RemainingBits / 8;
		if (flag)
		{
			num5 -= 2;
		}
		else if (reader2.TryPeekMarker() != 0 && !reader2.TryPeekMarker().IsRestartMarker())
		{
			num5 -= 2;
		}
		reader.TryAdvance(num5);
	}

	private static void CopyBlockBaseline(ref JpegBitReader reader, ref JpegWriter writer, JpegTranscodeComponent component)
	{
		int num = DecodeHuffmanCode(ref reader, component.DcTable);
		component.DcEncodingTable.GetCode(num, out var code, out var codeLength);
		writer.WriteBits(code, codeLength);
		if (num != 0)
		{
			int bits = Receive(ref reader, num);
			writer.WriteBits((uint)bits, num);
		}
		int num2 = 1;
		while (num2 < 64)
		{
			num = DecodeHuffmanCode(ref reader, component.AcTable);
			component.AcEncodingTable.GetCode(num, out code, out codeLength);
			writer.WriteBits(code, codeLength);
			int num3 = num >> 4;
			num &= 0xF;
			if (num != 0)
			{
				num2 += num3 + 1;
				int bits2 = Receive(ref reader, num);
				writer.WriteBits((uint)bits2, num);
				continue;
			}
			if (num3 != 0)
			{
				num2 += 16;
				continue;
			}
			break;
		}
	}

	private static void ThrowInvalidDataException(string message)
	{
		throw new InvalidDataException(message);
	}

	private static void ThrowInvalidDataException(int offset, string message)
	{
		throw new InvalidDataException($"Failed to decode JPEG data at offset {offset}. {message}");
	}
}
