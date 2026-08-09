using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal class JpegEncoder
{
	private int _minimumBufferSegmentSize;

	private JpegBlockInputReader? _input;

	private IBufferWriter<byte>? _output;

	private List<JpegQuantizationTable>? _quantizationTables;

	private JpegHuffmanEncodingTableCollection _huffmanTables;

	private List<JpegHuffmanEncodingComponent>? _encodeComponents;

	public bool MostOptimalCoding { get; set; }

	protected int MinimumBufferSegmentSize => _minimumBufferSegmentSize;

	public MemoryPool<byte>? MemoryPool { get; set; }

	private static ReadOnlySpan<byte> BitCountTable => new byte[256]
	{
		0, 1, 2, 2, 3, 3, 3, 3, 4, 4,
		4, 4, 4, 4, 4, 4, 5, 5, 5, 5,
		5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
		5, 5, 6, 6, 6, 6, 6, 6, 6, 6,
		6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
		6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
		6, 6, 6, 6, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8
	};

	public JpegEncoder()
		: this(4096)
	{
	}

	public JpegEncoder(int minimumBufferSegmentSize)
	{
		_minimumBufferSegmentSize = minimumBufferSegmentSize;
	}

	protected T CloneParameters<T>() where T : JpegEncoder, new()
	{
		bool flag = _huffmanTables.ContainsTableBuilder();
		T val = new T
		{
			_minimumBufferSegmentSize = _minimumBufferSegmentSize,
			_quantizationTables = _quantizationTables,
			_huffmanTables = (flag ? _huffmanTables.DeepClone() : _huffmanTables)
		};
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents != null)
		{
			foreach (JpegHuffmanEncodingComponent item in encodeComponents)
			{
				val.AddComponent((byte)item.ComponentIndex, item.QuantizationTable.Identifier, item.DcTableIdentifier, item.AcTableIdentifier, item.HorizontalSamplingFactor, item.VerticalSamplingFactor);
			}
		}
		return val;
	}

	public void SetInputReader(JpegBlockInputReader inputReader)
	{
		_input = inputReader ?? throw new ArgumentNullException("inputReader");
	}

	public void SetOutput(IBufferWriter<byte> output)
	{
		_output = output ?? throw new ArgumentNullException("output");
	}

	public void SetQuantizationTable(JpegQuantizationTable table)
	{
		if (table.IsEmpty)
		{
			throw new ArgumentException("Quantization table is not initialized.", "table");
		}
		if (table.ElementPrecision != 0)
		{
			throw new InvalidOperationException("Only baseline JPEG is supported.");
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

	public void SetHuffmanTable(bool isDcTable, byte identifier, JpegHuffmanEncodingTable? table)
	{
		_huffmanTables.AddTable((!isDcTable) ? ((byte)1) : ((byte)0), identifier, table);
	}

	public void SetHuffmanTable(bool isDcTable, byte identifier)
	{
		SetHuffmanTable(isDcTable, identifier, null);
	}

	private JpegQuantizationTable GetQuantizationTable(byte identifier)
	{
		if (_quantizationTables == null)
		{
			return default(JpegQuantizationTable);
		}
		foreach (JpegQuantizationTable quantizationTable in _quantizationTables)
		{
			if (quantizationTable.Identifier == identifier)
			{
				return quantizationTable;
			}
		}
		return default(JpegQuantizationTable);
	}

	public void AddComponent(byte componentIndex, byte quantizationTableIdentifier, byte huffmanDcTableIdentifier, byte huffmanAcTableIdentifier, byte horizontalSubsampling, byte verticalSubsampling)
	{
		if (horizontalSubsampling != 1 && horizontalSubsampling != 2 && horizontalSubsampling != 4)
		{
			throw new ArgumentOutOfRangeException("horizontalSubsampling", "Subsampling factor can only be 1, 2 or 4.");
		}
		if (verticalSubsampling != 1 && verticalSubsampling != 2 && verticalSubsampling != 4)
		{
			throw new ArgumentOutOfRangeException("verticalSubsampling", "Subsampling factor can only be 1, 2 or 4.");
		}
		List<JpegHuffmanEncodingComponent> list = _encodeComponents;
		if (list == null)
		{
			list = (_encodeComponents = new List<JpegHuffmanEncodingComponent>(4));
		}
		foreach (JpegHuffmanEncodingComponent item2 in list)
		{
			if (item2.ComponentIndex == componentIndex)
			{
				throw new ArgumentException("The component index is already used by another component.", "componentIndex");
			}
		}
		JpegQuantizationTable quantizationTable = GetQuantizationTable(quantizationTableIdentifier);
		if (quantizationTable.IsEmpty)
		{
			throw new ArgumentException("Quantization table is not defined.", "quantizationTableIdentifier");
		}
		JpegHuffmanEncodingTable table = _huffmanTables.GetTable(isDcTable: true, huffmanDcTableIdentifier);
		JpegHuffmanEncodingTableBuilder jpegHuffmanEncodingTableBuilder = null;
		if (table == null)
		{
			jpegHuffmanEncodingTableBuilder = _huffmanTables.GetTableBuilder(isDcTable: true, huffmanDcTableIdentifier);
			if (jpegHuffmanEncodingTableBuilder == null)
			{
				throw new ArgumentException("Huffman table is not defined.", "huffmanDcTableIdentifier");
			}
		}
		JpegHuffmanEncodingTable table2 = _huffmanTables.GetTable(isDcTable: false, huffmanAcTableIdentifier);
		JpegHuffmanEncodingTableBuilder jpegHuffmanEncodingTableBuilder2 = null;
		if (table2 == null)
		{
			jpegHuffmanEncodingTableBuilder2 = _huffmanTables.GetTableBuilder(isDcTable: false, huffmanAcTableIdentifier);
			if (jpegHuffmanEncodingTableBuilder2 == null)
			{
				throw new ArgumentException("Huffman table is not defined.", "huffmanAcTableIdentifier");
			}
		}
		JpegHuffmanEncodingComponent item = new JpegHuffmanEncodingComponent
		{
			Index = list.Count,
			ComponentIndex = componentIndex,
			HorizontalSamplingFactor = horizontalSubsampling,
			VerticalSamplingFactor = verticalSubsampling,
			DcTableIdentifier = huffmanDcTableIdentifier,
			AcTableIdentifier = huffmanAcTableIdentifier,
			DcTable = table,
			AcTable = table2,
			DcTableBuilder = jpegHuffmanEncodingTableBuilder,
			AcTableBuilder = jpegHuffmanEncodingTableBuilder2,
			QuantizationTable = quantizationTable
		};
		list.Add(item);
	}

	protected JpegWriter CreateJpegWriter()
	{
		return new JpegWriter(_output ?? throw new InvalidOperationException("Output is not specified."), _minimumBufferSegmentSize);
	}

	public virtual void Encode()
	{
		bool num = _huffmanTables.ContainsTableBuilder();
		JpegWriter writer = CreateJpegWriter();
		WriteStartOfImage(ref writer);
		WriteQuantizationTables(ref writer);
		JpegFrameHeader frameHeader = WriteStartOfFrame(ref writer);
		JpegBlockAllocator jpegBlockAllocator = (num ? new JpegBlockAllocator(MemoryPool) : null);
		try
		{
			if (jpegBlockAllocator != null)
			{
				jpegBlockAllocator.Allocate(frameHeader);
				TransformBlocks(jpegBlockAllocator);
				BuildHuffmanTables(frameHeader, jpegBlockAllocator, MostOptimalCoding);
				WriteHuffmanTables(ref writer);
				WriteStartOfScan(ref writer);
				WritePreparedScanData(frameHeader, jpegBlockAllocator, ref writer);
			}
			else
			{
				WriteHuffmanTables(ref writer);
				WriteStartOfScan(ref writer);
				WriteScanData(ref writer);
			}
		}
		finally
		{
			jpegBlockAllocator?.Dispose();
		}
		WriteEndOfImage(ref writer);
		writer.Flush();
	}

	protected static void WriteStartOfImage(ref JpegWriter writer)
	{
		writer.WriteMarker(JpegMarker.StartOfImage);
	}

	protected void WriteQuantizationTables(ref JpegWriter writer)
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

	protected void WriteHuffmanTables(ref JpegWriter writer)
	{
		if (_huffmanTables.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		writer.WriteMarker(JpegMarker.DefineHuffmanTable);
		ushort totalBytesRequired = _huffmanTables.GetTotalBytesRequired();
		writer.WriteLength(totalBytesRequired);
		_huffmanTables.Write(ref writer);
	}

	protected JpegFrameHeader WriteStartOfFrame(ref JpegWriter writer)
	{
		JpegBlockInputReader input = _input;
		if (input == null)
		{
			throw new InvalidOperationException("Input is not specified.");
		}
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		JpegFrameComponentSpecificationParameters[] array = new JpegFrameComponentSpecificationParameters[encodeComponents.Count];
		for (int i = 0; i < encodeComponents.Count; i++)
		{
			JpegHuffmanEncodingComponent jpegHuffmanEncodingComponent = encodeComponents[i];
			array[i] = new JpegFrameComponentSpecificationParameters((byte)jpegHuffmanEncodingComponent.ComponentIndex, jpegHuffmanEncodingComponent.HorizontalSamplingFactor, jpegHuffmanEncodingComponent.VerticalSamplingFactor, jpegHuffmanEncodingComponent.QuantizationTable.Identifier);
		}
		JpegFrameHeader result = new JpegFrameHeader(8, (ushort)input.Height, (ushort)input.Width, (byte)array.Length, array);
		writer.WriteMarker(JpegMarker.StartOfFrame0);
		byte bytesRequired = result.BytesRequired;
		writer.WriteLength(bytesRequired);
		Span<byte> span = writer.GetSpan(bytesRequired);
		result.TryWrite(span, out var _);
		writer.Advance(bytesRequired);
		return result;
	}

	protected void WriteStartOfScan(ref JpegWriter writer)
	{
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		JpegScanComponentSpecificationParameters[] array = new JpegScanComponentSpecificationParameters[encodeComponents.Count];
		for (int i = 0; i < encodeComponents.Count; i++)
		{
			JpegHuffmanEncodingComponent jpegHuffmanEncodingComponent = encodeComponents[i];
			array[i] = new JpegScanComponentSpecificationParameters((byte)jpegHuffmanEncodingComponent.ComponentIndex, jpegHuffmanEncodingComponent.DcTableIdentifier, jpegHuffmanEncodingComponent.AcTableIdentifier);
		}
		JpegScanHeader jpegScanHeader = new JpegScanHeader((byte)array.Length, array, 0, 63, 0, 0);
		writer.WriteMarker(JpegMarker.StartOfScan);
		byte bytesRequired = jpegScanHeader.BytesRequired;
		writer.WriteLength(bytesRequired);
		Span<byte> span = writer.GetSpan(bytesRequired);
		jpegScanHeader.TryWrite(span, out var _);
		writer.Advance(bytesRequired);
	}

	protected void TransformBlocks(JpegBlockAllocator allocator)
	{
		JpegBlockInputReader jpegBlockInputReader = _input ?? throw new InvalidOperationException("Input is not specified.");
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		int num = 1;
		int num2 = 1;
		foreach (JpegHuffmanEncodingComponent item in encodeComponents)
		{
			item.DcPredictor = 0;
			num = Math.Max(num, item.HorizontalSamplingFactor);
			num2 = Math.Max(num2, item.VerticalSamplingFactor);
		}
		foreach (JpegHuffmanEncodingComponent item2 in encodeComponents)
		{
			item2.HorizontalSubsamplingFactor = num / item2.HorizontalSamplingFactor;
			item2.VerticalSubsamplingFactor = num2 / item2.VerticalSamplingFactor;
		}
		int num3 = (jpegBlockInputReader.Width + 8 * num - 1) / (8 * num);
		int num4 = (jpegBlockInputReader.Height + 8 * num2 - 1) / (8 * num2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value3);
		for (int i = 0; i < num4; i++)
		{
			for (int j = 0; j < num3; j++)
			{
				foreach (JpegHuffmanEncodingComponent item3 in encodeComponents)
				{
					int index = item3.Index;
					int horizontalSamplingFactor = item3.HorizontalSamplingFactor;
					int verticalSamplingFactor = item3.VerticalSamplingFactor;
					int horizontalSubsamplingFactor = item3.HorizontalSubsamplingFactor;
					int verticalSubsamplingFactor = item3.VerticalSubsamplingFactor;
					int num5 = j * horizontalSamplingFactor;
					int num6 = i * verticalSamplingFactor;
					for (int k = 0; k < verticalSamplingFactor; k++)
					{
						int num7 = num6 + k;
						for (int l = 0; l < horizontalSamplingFactor; l++)
						{
							ref JpegBlock8x8 blockReference = ref allocator.GetBlockReference(index, num5 + l, num7);
							ReadBlock(jpegBlockInputReader, ref blockReference, item3.Index, (num5 + l) * 8 * horizontalSubsamplingFactor, num7 * 8 * verticalSubsamplingFactor, horizontalSubsamplingFactor, verticalSubsamplingFactor);
							ShiftDataLevel(ref blockReference, ref value, 128);
							FastFloatingPointDCT.TransformFDCT(ref value, ref value2, ref value3);
							ZigZagAndQuantizeBlock(item3.QuantizationTable, ref value2, ref blockReference);
						}
					}
				}
			}
		}
	}

	protected void BuildHuffmanTables(JpegFrameHeader frameHeader, JpegBlockAllocator allocator, bool optimal = false)
	{
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		int num = 1;
		int num2 = 1;
		foreach (JpegHuffmanEncodingComponent item in encodeComponents)
		{
			item.DcPredictor = 0;
			num = Math.Max(num, item.HorizontalSamplingFactor);
			num2 = Math.Max(num2, item.VerticalSamplingFactor);
		}
		int num3 = (frameHeader.SamplesPerLine + 8 * num - 1) / (8 * num);
		int num4 = (frameHeader.NumberOfLines + 8 * num2 - 1) / (8 * num2);
		for (int i = 0; i < num4; i++)
		{
			for (int j = 0; j < num3; j++)
			{
				foreach (JpegHuffmanEncodingComponent item2 in encodeComponents)
				{
					int index = item2.Index;
					int horizontalSamplingFactor = item2.HorizontalSamplingFactor;
					int verticalSamplingFactor = item2.VerticalSamplingFactor;
					int num5 = j * horizontalSamplingFactor;
					int num6 = i * verticalSamplingFactor;
					for (int k = 0; k < verticalSamplingFactor; k++)
					{
						int blockY = num6 + k;
						for (int l = 0; l < horizontalSamplingFactor; l++)
						{
							GatherBlockStatistics(item2, ref allocator.GetBlockReference(index, num5 + l, blockY));
						}
					}
				}
			}
		}
		_huffmanTables.BuildTables(optimal);
		foreach (JpegHuffmanEncodingComponent item3 in encodeComponents)
		{
			item3.DcTable = _huffmanTables.GetTable(isDcTable: true, item3.DcTableIdentifier);
			item3.AcTable = _huffmanTables.GetTable(isDcTable: false, item3.AcTableIdentifier);
			item3.DcTableBuilder = null;
			item3.DcTableBuilder = null;
		}
	}

	private static void GatherBlockStatistics(JpegHuffmanEncodingComponent component, ref JpegBlock8x8 block)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref block);
		int num = reference;
		int value = num - component.DcPredictor;
		component.DcPredictor = num;
		if (component.DcTableBuilder != null)
		{
			GatherRunLengthCodeStatistics(component.DcTableBuilder, 0, value);
		}
		JpegHuffmanEncodingTableBuilder acTableBuilder = component.AcTableBuilder;
		if (acTableBuilder == null)
		{
			return;
		}
		int num2 = 0;
		for (int i = 1; i < 64; i++)
		{
			value = Unsafe.Add(ref reference, i);
			if (value == 0)
			{
				num2++;
				continue;
			}
			while (num2 > 15)
			{
				acTableBuilder.IncrementCodeCount(240);
				num2 -= 16;
			}
			GatherRunLengthCodeStatistics(acTableBuilder, num2, value);
			num2 = 0;
		}
		if (num2 > 0)
		{
			acTableBuilder.IncrementCodeCount(0);
		}
	}

	protected void WritePreparedScanData(JpegFrameHeader frameHeader, JpegBlockAllocator allocator, ref JpegWriter writer)
	{
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		int num = 1;
		int num2 = 1;
		foreach (JpegHuffmanEncodingComponent item in encodeComponents)
		{
			item.DcPredictor = 0;
			num = Math.Max(num, item.HorizontalSamplingFactor);
			num2 = Math.Max(num2, item.VerticalSamplingFactor);
		}
		int num3 = (frameHeader.SamplesPerLine + 8 * num - 1) / (8 * num);
		int num4 = (frameHeader.NumberOfLines + 8 * num2 - 1) / (8 * num2);
		writer.EnterBitMode();
		for (int i = 0; i < num4; i++)
		{
			for (int j = 0; j < num3; j++)
			{
				foreach (JpegHuffmanEncodingComponent item2 in encodeComponents)
				{
					int index = item2.Index;
					int horizontalSamplingFactor = item2.HorizontalSamplingFactor;
					int verticalSamplingFactor = item2.VerticalSamplingFactor;
					int num5 = j * horizontalSamplingFactor;
					int num6 = i * verticalSamplingFactor;
					for (int k = 0; k < verticalSamplingFactor; k++)
					{
						int blockY = num6 + k;
						for (int l = 0; l < horizontalSamplingFactor; l++)
						{
							EncodeBlock(ref writer, item2, ref allocator.GetBlockReference(index, num5 + l, blockY));
						}
					}
				}
			}
		}
		writer.ExitBitMode();
	}

	protected void WriteScanData(ref JpegWriter writer)
	{
		JpegBlockInputReader jpegBlockInputReader = _input ?? throw new InvalidOperationException("Input is not specified.");
		List<JpegHuffmanEncodingComponent> encodeComponents = _encodeComponents;
		if (encodeComponents == null || encodeComponents.Count == 0)
		{
			throw new InvalidOperationException("No component is specified.");
		}
		int num = 1;
		int num2 = 1;
		foreach (JpegHuffmanEncodingComponent item in encodeComponents)
		{
			item.DcPredictor = 0;
			num = Math.Max(num, item.HorizontalSamplingFactor);
			num2 = Math.Max(num2, item.VerticalSamplingFactor);
		}
		foreach (JpegHuffmanEncodingComponent item2 in encodeComponents)
		{
			item2.HorizontalSubsamplingFactor = num / item2.HorizontalSamplingFactor;
			item2.VerticalSubsamplingFactor = num2 / item2.VerticalSamplingFactor;
		}
		int num3 = (jpegBlockInputReader.Width + 8 * num - 1) / (8 * num);
		int num4 = (jpegBlockInputReader.Height + 8 * num2 - 1) / (8 * num2);
		writer.EnterBitMode();
		Unsafe.SkipInit<JpegBlock8x8F>(out var value);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value2);
		Unsafe.SkipInit<JpegBlock8x8F>(out var value3);
		for (int i = 0; i < num4; i++)
		{
			int num5 = i * num2;
			for (int j = 0; j < num3; j++)
			{
				int num6 = j * num;
				foreach (JpegHuffmanEncodingComponent item3 in encodeComponents)
				{
					int horizontalSamplingFactor = item3.HorizontalSamplingFactor;
					int verticalSamplingFactor = item3.VerticalSamplingFactor;
					int horizontalSubsamplingFactor = item3.HorizontalSubsamplingFactor;
					int verticalSubsamplingFactor = item3.VerticalSubsamplingFactor;
					for (int k = 0; k < verticalSamplingFactor; k++)
					{
						int y = (num5 + k) * 8;
						for (int l = 0; l < horizontalSamplingFactor; l++)
						{
							JpegBlock8x8 block = default(JpegBlock8x8);
							ReadBlock(jpegBlockInputReader, ref block, item3.Index, (num6 + l) * 8, y, horizontalSubsamplingFactor, verticalSubsamplingFactor);
							ShiftDataLevel(ref block, ref value, 128);
							FastFloatingPointDCT.TransformFDCT(ref value, ref value2, ref value3);
							ZigZagAndQuantizeBlock(item3.QuantizationTable, ref value2, ref block);
							EncodeBlock(ref writer, item3, ref block);
						}
					}
				}
			}
		}
		writer.ExitBitMode();
	}

	private static void ReadBlock(JpegBlockInputReader inputReader, ref JpegBlock8x8 block, int componentIndex, int x, int y, int h, int v)
	{
		ref short blockRef = ref Unsafe.As<JpegBlock8x8, short>(ref block);
		if (h == 1 && v == 1)
		{
			inputReader.ReadBlock(ref blockRef, componentIndex, x, y);
		}
		else
		{
			ReadBlockWithSubsample(inputReader, ref blockRef, componentIndex, x, y, h, v);
		}
	}

	private static void ReadBlockWithSubsample(JpegBlockInputReader inputReader, ref short blockRef, int componentIndex, int x, int y, int horizontalSubsampling, int verticalSubsampling)
	{
		Unsafe.SkipInit<JpegBlock8x8>(out var value);
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref value);
		int num = JpegMathHelper.Log2((uint)horizontalSubsampling);
		int num2 = JpegMathHelper.Log2((uint)verticalSubsampling);
		int num3 = 3 - num;
		int num4 = 3 - num2;
		for (int i = 0; i < verticalSubsampling; i++)
		{
			for (int j = 0; j < horizontalSubsampling; j++)
			{
				inputReader.ReadBlock(ref reference, componentIndex, x + 8 * j, y + 8 * i);
				CopySubsampleBlock(ref reference, ref blockRef, j << num3, i << num4, num, num2);
			}
		}
		int num5 = num + num2;
		if (num5 > 0)
		{
			int num6 = 1 << num5 - 1;
			for (int k = 0; k < 64; k++)
			{
				Unsafe.Add(ref blockRef, k) = (short)(Unsafe.Add(ref blockRef, k) + num6 >> num5);
			}
		}
	}

	private static void CopySubsampleBlock(ref short sourceRef, ref short destinationRef, int blockOffsetX, int blockOffsetY, int hShift, int vShift)
	{
		for (int i = 0; i < 8; i++)
		{
			ref short source = ref Unsafe.Add(ref sourceRef, i * 8);
			ref short source2 = ref Unsafe.Add(ref destinationRef, (blockOffsetY + (i >> vShift)) * 8 + blockOffsetX);
			for (int j = 0; j < 8; j++)
			{
				Unsafe.Add(ref source2, j >> hShift) += Unsafe.Add(ref source, j);
			}
		}
	}

	private static void ShiftDataLevel(ref JpegBlock8x8 source, ref JpegBlock8x8F destination, int levelShift)
	{
		ref short source2 = ref Unsafe.As<JpegBlock8x8, short>(ref source);
		ref float source3 = ref Unsafe.As<JpegBlock8x8F, float>(ref destination);
		for (int i = 0; i < 64; i++)
		{
			Unsafe.Add(ref source3, i) = Unsafe.Add(ref source2, i) - levelShift;
		}
	}

	private static void ZigZagAndQuantizeBlock(JpegQuantizationTable quantizationTable, ref JpegBlock8x8F input, ref JpegBlock8x8 output)
	{
		ref ushort reference = ref MemoryMarshal.GetReference(quantizationTable.Elements);
		ref float source = ref Unsafe.As<JpegBlock8x8F, float>(ref input);
		ref short source2 = ref Unsafe.As<JpegBlock8x8, short>(ref output);
		for (int i = 0; i < 64; i++)
		{
			float num = Unsafe.Add(ref source, JpegZigZag.InternalBufferIndexToBlock(i));
			ushort num2 = Unsafe.Add(ref reference, i);
			Unsafe.Add(ref source2, i) = JpegMathHelper.RoundToInt16(num / (float)(int)num2);
		}
	}

	private static void EncodeBlock(ref JpegWriter writer, JpegHuffmanEncodingComponent component, ref JpegBlock8x8 block)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref block);
		int num = reference;
		int value = num - component.DcPredictor;
		component.DcPredictor = num;
		EncodeRunLength(ref writer, component.DcTable, 0, value);
		JpegHuffmanEncodingTable acTable = component.AcTable;
		int num2 = 0;
		for (int i = 1; i < 64; i++)
		{
			value = Unsafe.Add(ref reference, i);
			if (value == 0)
			{
				num2++;
				continue;
			}
			while (num2 > 15)
			{
				EncodeHuffmanSymbol(ref writer, acTable, 240);
				num2 -= 16;
			}
			EncodeRunLength(ref writer, acTable, num2, value);
			num2 = 0;
		}
		if (num2 > 0)
		{
			EncodeHuffmanSymbol(ref writer, acTable, 0);
		}
	}

	private static void GatherRunLengthCodeStatistics(JpegHuffmanEncodingTableBuilder tableBuilder, int zeroRunLength, int value)
	{
		int num = value;
		if (num < 0)
		{
			num = -value;
		}
		int num2 = ((num >= 256) ? (8 + BitCountTable[num >> 8]) : BitCountTable[num]);
		tableBuilder.IncrementCodeCount((zeroRunLength << 4) | num2);
	}

	private static void EncodeRunLength(ref JpegWriter writer, JpegHuffmanEncodingTable encodingTable, int zeroRunLength, int value)
	{
		int num = value;
		int num2 = value;
		if (num < 0)
		{
			num = -value;
			num2 = value - 1;
		}
		int num3 = ((num >= 256) ? (8 + BitCountTable[num >> 8]) : BitCountTable[num]);
		EncodeHuffmanSymbol(ref writer, encodingTable, (zeroRunLength << 4) | num3);
		if (num3 > 0)
		{
			writer.WriteBits((uint)(num2 & ((1 << num3) - 1)), num3);
		}
	}

	private static void EncodeHuffmanSymbol(ref JpegWriter writer, JpegHuffmanEncodingTable encodingTable, int symbol)
	{
		encodingTable.GetCode(symbol, out var code, out var codeLength);
		writer.WriteBits(code, codeLength);
	}

	protected static void WriteEndOfImage(ref JpegWriter writer)
	{
		writer.WriteMarker(JpegMarker.EndOfImage);
	}

	public void ResetInputReader()
	{
		_input = null;
	}

	public void ResetTables()
	{
		_quantizationTables = null;
		_huffmanTables = default(JpegHuffmanEncodingTableCollection);
	}

	public void ResetComponents()
	{
		_encodeComponents = null;
	}

	public void ResetOutput()
	{
		_output = null;
	}

	public void Reset()
	{
		ResetInputReader();
		ResetTables();
		ResetComponents();
		ResetOutput();
	}
}
