using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal struct JpegHuffmanEncodingTableBuilderCollection : IDisposable
{
	private readonly struct TableBuilderWithIdentifier(byte tableClass, byte identifier, JpegHuffmanEncodingTableBuilder tableBuilder)
	{
		public byte TableClass { get; } = tableClass;

		public byte Identifier { get; } = identifier;

		public JpegHuffmanEncodingTableBuilder TableBuilder { get; } = tableBuilder;
	}

	private List<TableBuilderWithIdentifier>? _builders;

	public JpegHuffmanEncodingTableBuilder GetOrCreateTableBuilder(bool isDcTable, byte identifier)
	{
		byte b = ((!isDcTable) ? ((byte)1) : ((byte)0));
		List<TableBuilderWithIdentifier> list = _builders;
		if (list == null)
		{
			list = (_builders = new List<TableBuilderWithIdentifier>(4));
		}
		foreach (TableBuilderWithIdentifier item in list)
		{
			if (item.TableClass == b && item.Identifier == identifier)
			{
				return item.TableBuilder;
			}
		}
		JpegHuffmanEncodingTableBuilder jpegHuffmanEncodingTableBuilder = new JpegHuffmanEncodingTableBuilder();
		list.Add(new TableBuilderWithIdentifier(b, identifier, jpegHuffmanEncodingTableBuilder));
		return jpegHuffmanEncodingTableBuilder;
	}

	public JpegHuffmanEncodingTableCollection BuildTables(bool optimal = false)
	{
		if (_builders == null)
		{
			return default(JpegHuffmanEncodingTableCollection);
		}
		JpegHuffmanEncodingTableCollection result = default(JpegHuffmanEncodingTableCollection);
		foreach (TableBuilderWithIdentifier builder in _builders)
		{
			result.AddTable(builder.TableClass, builder.Identifier, builder.TableBuilder.Build(optimal));
		}
		return result;
	}

	public void Dispose()
	{
		if (_builders != null)
		{
			_builders.Clear();
			_builders = null;
		}
	}
}
