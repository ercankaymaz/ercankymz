using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegDecoder
{
	private ReadOnlySequence<byte> _inputBuffer;

	private JpegFrameHeader? _frameHeader;

	private ushort _restartInterval;

	private byte? _maxHorizontalSamplingFactor;

	private byte? _maxVerticalSamplingFactor;

	private JpegBlockOutputWriter? _outputWriter;

	private JpegScanDecoder? _scanDecoder;

	private List<JpegQuantizationTable>? _quantizationTables;

	private List<JpegHuffmanDecodingTable>? _huffmanTables;

	private List<JpegArithmeticDecodingTable>? _arithmeticTables;

	public MemoryPool<byte>? MemoryPool { get; set; }

	public JpegMarker StartOfFrame { get; set; }

	public JpegAdobeApplicationSpecific? AdobeApplicationSpecific { get; private set; }

	public int Width => GetFrameHeader().SamplesPerLine;

	public int Height => GetFrameHeader().NumberOfLines;

	public int Precision => GetFrameHeader().SamplePrecision;

	public int NumberOfComponents => GetFrameHeader().NumberOfComponents;

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

	public int Identify()
	{
		return Identify(loadQuantizationTables: false);
	}

	public int Identify(bool loadQuantizationTables)
	{
		if (_inputBuffer.IsEmpty)
		{
			throw new InvalidOperationException("Input buffer is not specified.");
		}
		JpegReader reader = new JpegReader(_inputBuffer);
		_frameHeader = null;
		bool flag = true;
		while (flag && !reader.IsEmpty)
		{
			if (!reader.TryReadMarker(out var marker))
			{
				ThrowInvalidDataException(reader.ConsumedByteCount, "No marker found.");
			}
			flag = ProcessMarkerForIdentification(marker, ref reader, loadQuantizationTables);
		}
		JpegFrameHeader? frameHeader = _frameHeader;
		if (!frameHeader.HasValue)
		{
			throw new InvalidOperationException("Frame header was not found.");
		}
		return reader.ConsumedByteCount;
	}

	private bool ProcessMarkerForIdentification(JpegMarker marker, ref JpegReader reader, bool loadQuantizationTables)
	{
		switch (marker)
		{
		case JpegMarker.StartOfFrame0:
		case JpegMarker.StartOfFrame1:
		case JpegMarker.StartOfFrame2:
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
			StartOfFrame = marker;
			ProcessFrameHeader(ref reader, metadataOnly: false, overrideAllowed: false);
			break;
		case JpegMarker.StartOfScan:
			ProcessScanHeader(ref reader, metadataOnly: true);
			break;
		case JpegMarker.DefineRestartInterval:
			ProcessDefineRestartInterval(ref reader);
			break;
		case JpegMarker.DefineQuantizationTable:
			ProcessDefineQuantizationTable(ref reader, loadQuantizationTables);
			break;
		case JpegMarker.EndOfImage:
			return false;
		case JpegMarker.App14:
			ProcessAdobeApplicationSpecificMarker(ref reader);
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
		return true;
	}

	public bool TryEstimateQuality(out float quality)
	{
		if (_quantizationTables == null)
		{
			quality = 0f;
			return false;
		}
		JpegQuantizationTable quantizationTable = GetQuantizationTable(0);
		if (quantizationTable.IsEmpty)
		{
			quality = 0f;
			return false;
		}
		quality = EstimateQuality(quantizationTable, JpegStandardQuantizationTable.GetLuminanceTable(JpegElementPrecision.Precision8Bit, 0), out var dVariance);
		quantizationTable = GetQuantizationTable(1);
		if (!quantizationTable.IsEmpty)
		{
			float val = EstimateQuality(quantizationTable, JpegStandardQuantizationTable.GetChrominanceTable(JpegElementPrecision.Precision8Bit, 0), out dVariance);
			quality = Math.Min(quality, val);
		}
		quality = JpegMathHelper.Clamp(quality, 0f, 100f);
		return true;
	}

	private static float EstimateQuality(JpegQuantizationTable quantizationTable, JpegQuantizationTable standardTable, out float dVariance)
	{
		bool flag = true;
		double num = 0.0;
		double num2 = 0.0;
		ref ushort reference = ref MemoryMarshal.GetReference(quantizationTable.Elements);
		ref ushort reference2 = ref MemoryMarshal.GetReference(standardTable.Elements);
		for (int i = 0; i < 64; i++)
		{
			ushort num3 = Unsafe.Add(ref reference, i);
			double num4;
			if (num3 == 0)
			{
				num4 = 999.99;
			}
			else
			{
				ushort num5 = Unsafe.Add(ref reference2, i);
				num4 = 100.0 * (double)(int)num3 / (double)(int)num5;
			}
			num += num4;
			num2 += num4 * num4;
			if (num3 != 1)
			{
				flag = false;
			}
		}
		num /= 64.0;
		num2 /= 64.0;
		dVariance = (float)(num2 - num * num);
		if (flag)
		{
			return 100f;
		}
		if (num <= 100.0)
		{
			return (float)((200.0 - num) / 2.0);
		}
		return (float)(5000.0 / num);
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

	private void ProcessAdobeApplicationSpecificMarker(ref JpegReader reader)
	{
		if (!reader.TryReadLength(out var length))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment length.");
		}
		if (!reader.TryReadBytes(length, out var bytes))
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Unexpected end of input data when reading segment content.");
		}
		if (JpegAdobeApplicationSpecific.TryParse(bytes, out var adobeApplicationSpecific))
		{
			AdobeApplicationSpecific = adobeApplicationSpecific;
		}
	}

	public void LoadTables(Memory<byte> content)
	{
		LoadTables(new ReadOnlySequence<byte>(content));
	}

	public void LoadTables(ReadOnlySequence<byte> content)
	{
		JpegReader reader = new JpegReader(content);
		JpegMarker marker;
		while (!reader.IsEmpty && reader.TryReadMarker(out marker))
		{
			switch (marker)
			{
			case JpegMarker.DefineHuffmanTable:
				ProcessDefineHuffmanTable(ref reader);
				break;
			case JpegMarker.DefineArithmeticCodingConditioning:
				ProcessDefineArithmeticCodingConditioning(ref reader);
				break;
			case JpegMarker.DefineQuantizationTable:
				ProcessDefineQuantizationTable(ref reader, loadQuantizationTables: true);
				break;
			case JpegMarker.DefineRestartInterval:
				ProcessDefineRestartInterval(ref reader);
				break;
			case JpegMarker.EndOfImage:
				return;
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
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowInvalidDataException(string message)
	{
		throw new InvalidDataException(message);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowInvalidDataException(int offset, string message)
	{
		throw new InvalidDataException($"Failed to decode JPEG data at offset {offset}. {message}");
	}

	private JpegFrameHeader GetFrameHeader()
	{
		if (!_frameHeader.HasValue)
		{
			throw new InvalidOperationException("Call Identify() before this operation.");
		}
		return _frameHeader.GetValueOrDefault();
	}

	public void SetFrameHeader(JpegFrameHeader frameHeader)
	{
		_frameHeader = frameHeader;
	}

	public int GetMaximumHorizontalSampling()
	{
		if (_maxHorizontalSamplingFactor.HasValue)
		{
			return _maxHorizontalSamplingFactor.GetValueOrDefault();
		}
		JpegFrameHeader frameHeader = GetFrameHeader();
		if (frameHeader.Components == null)
		{
			throw new InvalidOperationException();
		}
		int num = 1;
		JpegFrameComponentSpecificationParameters[] components = frameHeader.Components;
		foreach (JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters in components)
		{
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
		}
		_maxHorizontalSamplingFactor = (byte)num;
		return num;
	}

	public int GetMaximumVerticalSampling()
	{
		if (_maxVerticalSamplingFactor.HasValue)
		{
			return _maxVerticalSamplingFactor.GetValueOrDefault();
		}
		JpegFrameHeader frameHeader = GetFrameHeader();
		if (frameHeader.Components == null)
		{
			throw new InvalidOperationException();
		}
		int num = 1;
		JpegFrameComponentSpecificationParameters[] components = frameHeader.Components;
		foreach (JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters in components)
		{
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		_maxVerticalSamplingFactor = (byte)num;
		return num;
	}

	public byte GetHorizontalSampling(int componentIndex)
	{
		JpegFrameComponentSpecificationParameters[] components = GetFrameHeader().Components;
		if (components == null)
		{
			throw new InvalidOperationException();
		}
		if ((uint)componentIndex >= (uint)components.Length)
		{
			throw new ArgumentOutOfRangeException("componentIndex");
		}
		return components[componentIndex].HorizontalSamplingFactor;
	}

	public byte GetVerticalSampling(int componentIndex)
	{
		JpegFrameComponentSpecificationParameters[] components = GetFrameHeader().Components;
		if (components == null)
		{
			throw new InvalidOperationException();
		}
		if ((uint)componentIndex >= (uint)components.Length)
		{
			throw new ArgumentOutOfRangeException("componentIndex");
		}
		return components[componentIndex].VerticalSamplingFactor;
	}

	public void SetOutputWriter(JpegBlockOutputWriter outputWriter)
	{
		_outputWriter = outputWriter ?? throw new ArgumentNullException("outputWriter");
	}

	public void Decode()
	{
		if (_inputBuffer.IsEmpty)
		{
			throw new InvalidOperationException("Input buffer is not specified.");
		}
		if (_outputWriter == null)
		{
			throw new InvalidOperationException("The output buffer is not specified.");
		}
		JpegReader reader = new JpegReader(_inputBuffer);
		_scanDecoder = null;
		if (!reader.TryReadStartOfImageMarker())
		{
			ThrowInvalidDataException(reader.ConsumedByteCount, "Marker StartOfImage not found.");
			return;
		}
		try
		{
			bool flag = true;
			while (flag && !reader.IsEmpty)
			{
				if (!reader.TryReadMarker(out var marker))
				{
					ThrowInvalidDataException(reader.ConsumedByteCount, "No marker found.");
					break;
				}
				flag = ProcessMarkerForDecode(marker, ref reader);
			}
		}
		finally
		{
			_scanDecoder?.Dispose();
			_scanDecoder = null;
		}
	}

	private bool ProcessMarkerForDecode(JpegMarker marker, ref JpegReader reader)
	{
		switch (marker)
		{
		case JpegMarker.StartOfFrame0:
		case JpegMarker.StartOfFrame1:
		case JpegMarker.StartOfFrame2:
		case JpegMarker.StartOfFrame3:
		case JpegMarker.StartOfFrame9:
		case JpegMarker.StartOfFrame10:
			ProcessFrameHeader(ref reader, metadataOnly: false, overrideAllowed: true);
			_scanDecoder = JpegScanDecoder.Create(marker, this, _frameHeader.GetValueOrDefault());
			break;
		case JpegMarker.StartOfFrame5:
		case JpegMarker.StartOfFrame6:
		case JpegMarker.StartOfFrame7:
		case JpegMarker.StartOfFrame11:
		case JpegMarker.StartOfFrame13:
		case JpegMarker.StartOfFrame14:
		case JpegMarker.StartOfFrame15:
			ThrowInvalidDataException(reader.ConsumedByteCount, $"This type of JPEG stream is not supported ({marker}).");
			break;
		case JpegMarker.DefineHuffmanTable:
			ProcessDefineHuffmanTable(ref reader);
			break;
		case JpegMarker.DefineArithmeticCodingConditioning:
			ProcessDefineArithmeticCodingConditioning(ref reader);
			break;
		case JpegMarker.DefineQuantizationTable:
			ProcessDefineQuantizationTable(ref reader, loadQuantizationTables: true);
			break;
		case JpegMarker.DefineRestartInterval:
			ProcessDefineRestartInterval(ref reader);
			break;
		case JpegMarker.StartOfScan:
		{
			if (_scanDecoder == null)
			{
				ThrowInvalidDataException(reader.ConsumedByteCount, "Scan header appears before frame header.");
			}
			JpegScanHeader scanHeader = ProcessScanHeader(ref reader, metadataOnly: false);
			_scanDecoder.ProcessScan(ref reader, scanHeader);
			break;
		}
		case JpegMarker.EndOfImage:
			return false;
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
			break;
		}
		return true;
	}

	public void ProcessScan(ref JpegReader reader, JpegScanHeader scanHeader)
	{
		using JpegScanDecoder jpegScanDecoder = JpegScanDecoder.Create(StartOfFrame, this, GetFrameHeader());
		if (jpegScanDecoder == null)
		{
			throw new NotSupportedException("This image type is not supported.");
		}
		jpegScanDecoder.ProcessScan(ref reader, scanHeader);
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

	public ushort GetRestartInterval()
	{
		return _restartInterval;
	}

	public void SetRestartInterval(int restartInterval)
	{
		if ((uint)restartInterval > 65535u)
		{
			throw new ArgumentOutOfRangeException("restartInterval");
		}
		_restartInterval = (ushort)restartInterval;
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

	private void ProcessDefineArithmeticCodingConditioning(ref JpegReader reader)
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
			ProcessDefineArithmeticCodingConditioning(bytes, reader.ConsumedByteCount - length);
		}
	}

	private void ProcessDefineArithmeticCodingConditioning(ReadOnlySequence<byte> segment, int currentOffset)
	{
		while (!segment.IsEmpty)
		{
			if (!JpegArithmeticDecodingTable.TryParse(segment, out JpegArithmeticDecodingTable arithmeticTable, out int bytesConsumed))
			{
				ThrowInvalidDataException(currentOffset, "Failed to parse arithmetic coding conditioning.");
				break;
			}
			segment = segment.Slice(bytesConsumed);
			currentOffset += bytesConsumed;
			SetArithmeticTable(arithmeticTable);
		}
	}

	private void ProcessDefineQuantizationTable(ref JpegReader reader, bool loadQuantizationTables)
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
		else if (loadQuantizationTables)
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

	public void ClearHuffmanTable()
	{
		_huffmanTables?.Clear();
	}

	public void ClearArithmeticTable()
	{
		_arithmeticTables?.Clear();
	}

	public void ClearQuantizationTable()
	{
		_quantizationTables?.Clear();
	}

	public void SetHuffmanTable(JpegHuffmanDecodingTable table)
	{
		if (table == null)
		{
			throw new ArgumentNullException("table");
		}
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

	internal void SetArithmeticTable(JpegArithmeticDecodingTable table)
	{
		List<JpegArithmeticDecodingTable> list = _arithmeticTables;
		if (list == null)
		{
			list = (_arithmeticTables = new List<JpegArithmeticDecodingTable>(4));
		}
		for (int i = 0; i < list.Count; i++)
		{
			JpegArithmeticDecodingTable jpegArithmeticDecodingTable = list[i];
			if (jpegArithmeticDecodingTable.TableClass == table.TableClass && jpegArithmeticDecodingTable.Identifier == table.Identifier)
			{
				list[i] = table;
				return;
			}
		}
		list.Add(table);
	}

	public void SetQuantizationTable(JpegQuantizationTable table)
	{
		if (table.IsEmpty)
		{
			throw new ArgumentException("No actual quantization table is provided.", "table");
		}
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

	public JpegHuffmanDecodingTable? GetHuffmanTable(bool isDcTable, byte identifier)
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

	internal JpegArithmeticDecodingTable? GetArithmeticTable(bool isDcTable, byte identifier)
	{
		List<JpegArithmeticDecodingTable> arithmeticTables = _arithmeticTables;
		if (arithmeticTables == null)
		{
			return null;
		}
		int num = ((!isDcTable) ? 1 : 0);
		foreach (JpegArithmeticDecodingTable item in arithmeticTables)
		{
			if (item.TableClass == num && item.Identifier == identifier)
			{
				return item;
			}
		}
		return null;
	}

	public JpegQuantizationTable GetQuantizationTable(byte identifier)
	{
		List<JpegQuantizationTable> quantizationTables = _quantizationTables;
		if (quantizationTables == null)
		{
			return default(JpegQuantizationTable);
		}
		foreach (JpegQuantizationTable item in quantizationTables)
		{
			if (item.Identifier == identifier)
			{
				return item;
			}
		}
		return default(JpegQuantizationTable);
	}

	public void Reset()
	{
		ResetInput();
		ResetHeader();
		ResetTables();
		ResetOutputWriter();
	}

	public void ResetInput()
	{
		_inputBuffer = default(ReadOnlySequence<byte>);
	}

	public void ResetHeader()
	{
		_frameHeader = null;
		_restartInterval = 0;
		_maxHorizontalSamplingFactor = null;
		_maxVerticalSamplingFactor = null;
	}

	public void ResetTables()
	{
		_huffmanTables?.Clear();
		_arithmeticTables?.Clear();
		_quantizationTables?.Clear();
	}

	internal JpegBlockOutputWriter? GetOutputWriter()
	{
		return _outputWriter;
	}

	public void ResetOutputWriter()
	{
		_outputWriter = null;
	}
}
