using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal struct JpegHuffmanEncodingTableCollection
{
	private readonly struct EncodingTableWithIdentifier
	{
		public byte TableClass { get; }

		public byte Identifier { get; }

		public object EncodingTable { get; }

		public EncodingTableWithIdentifier(byte tableClass, byte identifier, JpegHuffmanEncodingTable encodingTable)
		{
			TableClass = tableClass;
			Identifier = identifier;
			EncodingTable = encodingTable;
		}

		public EncodingTableWithIdentifier(byte tableClass, byte identifier, JpegHuffmanEncodingTableBuilder tableBuilder)
		{
			TableClass = tableClass;
			Identifier = identifier;
			EncodingTable = tableBuilder;
		}
	}

	private List<EncodingTableWithIdentifier>? _tables;

	public readonly bool IsEmpty => _tables == null;

	public readonly bool ContainsTableBuilder()
	{
		if (_tables == null)
		{
			return false;
		}
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (table.EncodingTable is JpegHuffmanEncodingTableBuilder)
			{
				return true;
			}
		}
		return false;
	}

	public JpegHuffmanEncodingTableCollection DeepClone()
	{
		if (_tables == null)
		{
			return default(JpegHuffmanEncodingTableCollection);
		}
		return new JpegHuffmanEncodingTableCollection
		{
			_tables = new List<EncodingTableWithIdentifier>(_tables)
		};
	}

	public readonly JpegHuffmanEncodingTable? GetTable(bool isDcTable, byte identifier)
	{
		if (_tables == null)
		{
			return null;
		}
		byte b = ((!isDcTable) ? ((byte)1) : ((byte)0));
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (table.TableClass == b && table.Identifier == identifier)
			{
				return table.EncodingTable as JpegHuffmanEncodingTable;
			}
		}
		return null;
	}

	public readonly JpegHuffmanEncodingTableBuilder? GetTableBuilder(bool isDcTable, byte identifier)
	{
		if (_tables == null)
		{
			return null;
		}
		byte b = ((!isDcTable) ? ((byte)1) : ((byte)0));
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (table.TableClass == b && table.Identifier == identifier)
			{
				return table.EncodingTable as JpegHuffmanEncodingTableBuilder;
			}
		}
		return null;
	}

	public void AddTable(byte tableClass, byte identifier, JpegHuffmanEncodingTable? encodingTable)
	{
		if (_tables == null)
		{
			_tables = new List<EncodingTableWithIdentifier>();
		}
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (table.TableClass == tableClass && table.Identifier == identifier)
			{
				throw new InvalidOperationException();
			}
		}
		if (encodingTable == null)
		{
			_tables.Add(new EncodingTableWithIdentifier(tableClass, identifier, new JpegHuffmanEncodingTableBuilder()));
		}
		else
		{
			_tables.Add(new EncodingTableWithIdentifier(tableClass, identifier, encodingTable));
		}
	}

	public readonly ushort GetTotalBytesRequired()
	{
		if (_tables == null)
		{
			throw new InvalidOperationException();
		}
		ushort num = 0;
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (!(table.EncodingTable is JpegHuffmanEncodingTable jpegHuffmanEncodingTable))
			{
				throw new InvalidOperationException();
			}
			num++;
			num += jpegHuffmanEncodingTable.BytesRequired;
		}
		return num;
	}

	public readonly bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		if (_tables == null)
		{
			throw new InvalidOperationException();
		}
		bytesWritten = 0;
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (!(table.EncodingTable is JpegHuffmanEncodingTable jpegHuffmanEncodingTable))
			{
				throw new InvalidOperationException();
			}
			if (buffer.IsEmpty)
			{
				return false;
			}
			buffer[0] = (byte)((table.TableClass << 4) | (table.Identifier & 0xF));
			buffer = buffer.Slice(1);
			bytesWritten++;
			if (!jpegHuffmanEncodingTable.TryWrite(buffer, out var bytesWritten2))
			{
				bytesWritten += bytesWritten2;
				return false;
			}
			buffer = buffer.Slice(bytesWritten2);
			bytesWritten += bytesWritten2;
		}
		return true;
	}

	public readonly void Write(ref JpegWriter writer)
	{
		if (_tables == null)
		{
			throw new InvalidOperationException();
		}
		foreach (EncodingTableWithIdentifier table in _tables)
		{
			if (!(table.EncodingTable is JpegHuffmanEncodingTable jpegHuffmanEncodingTable))
			{
				throw new InvalidOperationException();
			}
			int length = 1 + jpegHuffmanEncodingTable.BytesRequired;
			Span<byte> buffer = writer.GetSpan(length);
			buffer[0] = (byte)((table.TableClass << 4) | (table.Identifier & 0xF));
			buffer = buffer.Slice(1);
			jpegHuffmanEncodingTable.TryWrite(buffer, out var _);
			writer.Advance(length);
		}
	}

	public readonly void BuildTables(bool optimal)
	{
		List<EncodingTableWithIdentifier> tables = _tables;
		if (tables == null)
		{
			return;
		}
		for (int i = 0; i < tables.Count; i++)
		{
			EncodingTableWithIdentifier encodingTableWithIdentifier = tables[i];
			if (encodingTableWithIdentifier.EncodingTable is JpegHuffmanEncodingTableBuilder jpegHuffmanEncodingTableBuilder)
			{
				tables[i] = new EncodingTableWithIdentifier(encodingTableWithIdentifier.TableClass, encodingTableWithIdentifier.Identifier, jpegHuffmanEncodingTableBuilder.Build(optimal));
			}
		}
	}
}
