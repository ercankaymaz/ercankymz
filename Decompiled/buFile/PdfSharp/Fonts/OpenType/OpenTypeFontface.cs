#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts.OpenType;

[DebuggerDisplay("{DebuggerDisplay}")]
internal sealed class OpenTypeFontface
{
	internal struct OffsetTable
	{
		public uint Version;

		public int TableCount;

		public ushort SearchRange;

		public ushort EntrySelector;

		public ushort RangeShift;

		public void Write(OpenTypeFontWriter writer)
		{
			writer.WriteUInt(Version);
			writer.WriteShort(TableCount);
			writer.WriteUShort(SearchRange);
			writer.WriteUShort(EntrySelector);
			writer.WriteUShort(RangeShift);
		}
	}

	private readonly string _fullFaceName;

	private ulong _checkSum;

	private XFontSource _fontSource;

	internal FontTechnology _fontTechnology;

	internal OffsetTable _offsetTable;

	internal Dictionary<string, TableDirectoryEntry> TableDictionary = new Dictionary<string, TableDirectoryEntry>();

	internal CMapTable cmap;

	internal ControlValueTable cvt;

	internal FontProgram fpgm;

	internal MaximumProfileTable maxp;

	internal NameTable name;

	internal ControlValueProgram prep;

	internal FontHeaderTable head;

	internal HorizontalHeaderTable hhea;

	internal HorizontalMetricsTable hmtx;

	internal OS2Table os2;

	internal PostScriptTable post;

	internal GlyphDataTable glyf;

	internal IndexToLocationTable loca;

	internal GlyphSubstitutionTable gsub;

	internal VerticalHeaderTable vhea;

	internal VerticalMetricsTable vmtx;

	private static readonly int[] _entrySelectors = new int[31]
	{
		0, 0, 1, 1, 2, 2, 2, 2, 3, 3,
		3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
		4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
		4
	};

	private int _pos;

	public string FullFaceName => _fullFaceName;

	public ulong CheckSum
	{
		get
		{
			if (_checkSum == 0)
			{
				_checkSum = FontHelper.CalcChecksum(FontSource.Bytes);
			}
			return _checkSum;
		}
	}

	public XFontSource FontSource
	{
		get
		{
			return _fontSource;
		}
		private set
		{
			if (value == null)
			{
				throw new InvalidOperationException("Font cannot be resolved.");
			}
			_fontSource = value;
		}
	}

	public bool CanRead => FontSource != null;

	public bool CanWrite => FontSource == null;

	public int Position
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = value;
		}
	}

	internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "OpenType fontfaces: {0}", _fullFaceName);

	private OpenTypeFontface(OpenTypeFontface fontface)
	{
		_offsetTable = fontface._offsetTable;
		_fullFaceName = fontface._fullFaceName;
	}

	public OpenTypeFontface(byte[] data, string faceName)
	{
		_fullFaceName = faceName;
		int length = data.Length;
		Array.Copy(data, FontSource.Bytes, length);
		Read();
	}

	public OpenTypeFontface(XFontSource fontSource)
	{
		FontSource = fontSource;
		Read();
		_fullFaceName = name.FullFontName;
	}

	public static OpenTypeFontface CetOrCreateFrom(XFontSource fontSource)
	{
		if (OpenTypeFontfaceCache.TryGetFontface(fontSource.Key, out var fontface))
		{
			return fontface;
		}
		Debug.Assert(fontSource.Fontface != null);
		fontface = OpenTypeFontfaceCache.AddFontface(fontSource.Fontface);
		Debug.Assert(fontSource.Fontface == fontface);
		return fontface;
	}

	public void AddTable(OpenTypeFontTable fontTable)
	{
		if (!CanWrite)
		{
			throw new InvalidOperationException("Font image cannot be modified.");
		}
		if (fontTable == null)
		{
			throw new ArgumentNullException("fontTable");
		}
		if (fontTable._fontData == null)
		{
			fontTable._fontData = this;
		}
		else
		{
			Debug.Assert(fontTable._fontData.CanRead);
			fontTable = new IRefFontTable(this, fontTable);
		}
		TableDictionary[fontTable.DirectoryEntry.Tag] = fontTable.DirectoryEntry;
		switch (fontTable.DirectoryEntry.Tag)
		{
		case "cmap":
			cmap = fontTable as CMapTable;
			break;
		case "cvt ":
			cvt = fontTable as ControlValueTable;
			break;
		case "fpgm":
			fpgm = fontTable as FontProgram;
			break;
		case "maxp":
			maxp = fontTable as MaximumProfileTable;
			break;
		case "name":
			name = fontTable as NameTable;
			break;
		case "head":
			head = fontTable as FontHeaderTable;
			break;
		case "hhea":
			hhea = fontTable as HorizontalHeaderTable;
			break;
		case "hmtx":
			hmtx = fontTable as HorizontalMetricsTable;
			break;
		case "OS/2":
			os2 = fontTable as OS2Table;
			break;
		case "post":
			post = fontTable as PostScriptTable;
			break;
		case "glyf":
			glyf = fontTable as GlyphDataTable;
			break;
		case "loca":
			loca = fontTable as IndexToLocationTable;
			break;
		case "GSUB":
			gsub = fontTable as GlyphSubstitutionTable;
			break;
		case "prep":
			prep = fontTable as ControlValueProgram;
			break;
		}
	}

	internal void Read()
	{
		try
		{
			uint num = ReadULong();
			if (num == 1953784678)
			{
				_fontTechnology = FontTechnology.TrueTypeCollection;
				throw new InvalidOperationException("TrueType collection fonts are not yet supported by PDFsharp.");
			}
			_offsetTable.Version = num;
			_offsetTable.TableCount = ReadUShort();
			_offsetTable.SearchRange = ReadUShort();
			_offsetTable.EntrySelector = ReadUShort();
			_offsetTable.RangeShift = ReadUShort();
			Debug.Assert(_pos == 12);
			if (_offsetTable.Version == 1330926671)
			{
				_fontTechnology = FontTechnology.PostscriptOutlines;
			}
			else
			{
				_fontTechnology = FontTechnology.TrueTypeOutlines;
			}
			for (int i = 0; i < _offsetTable.TableCount; i++)
			{
				TableDirectoryEntry tableDirectoryEntry = TableDirectoryEntry.ReadFrom(this);
				TableDictionary.Add(tableDirectoryEntry.Tag, tableDirectoryEntry);
			}
			if (TableDictionary.ContainsKey("bhed"))
			{
				throw new NotSupportedException("Bitmap fonts are not supported by PDFsharp.");
			}
			if (Seek("cmap") != -1)
			{
				cmap = new CMapTable(this);
			}
			if (Seek("cvt ") != -1)
			{
				cvt = new ControlValueTable(this);
			}
			if (Seek("fpgm") != -1)
			{
				fpgm = new FontProgram(this);
			}
			if (Seek("maxp") != -1)
			{
				maxp = new MaximumProfileTable(this);
			}
			if (Seek("name") != -1)
			{
				name = new NameTable(this);
			}
			if (Seek("head") != -1)
			{
				head = new FontHeaderTable(this);
			}
			if (Seek("hhea") != -1)
			{
				hhea = new HorizontalHeaderTable(this);
			}
			if (Seek("hmtx") != -1)
			{
				hmtx = new HorizontalMetricsTable(this);
			}
			if (Seek("OS/2") != -1)
			{
				os2 = new OS2Table(this);
			}
			if (Seek("post") != -1)
			{
				post = new PostScriptTable(this);
			}
			if (Seek("glyf") != -1)
			{
				glyf = new GlyphDataTable(this);
			}
			if (Seek("loca") != -1)
			{
				loca = new IndexToLocationTable(this);
			}
			if (Seek("GSUB") != -1)
			{
				gsub = new GlyphSubstitutionTable(this);
			}
			if (Seek("prep") != -1)
			{
				prep = new ControlValueProgram(this);
			}
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}

	public OpenTypeFontface CreateFontSubSet(Dictionary<int, object> glyphs, bool cidFont)
	{
		OpenTypeFontface openTypeFontface = new OpenTypeFontface(this);
		IndexToLocationTable indexToLocationTable = new IndexToLocationTable();
		indexToLocationTable.ShortIndex = loca.ShortIndex;
		GlyphDataTable glyphDataTable = new GlyphDataTable();
		if (!cidFont)
		{
			openTypeFontface.AddTable(cmap);
		}
		if (cvt != null)
		{
			openTypeFontface.AddTable(cvt);
		}
		if (fpgm != null)
		{
			openTypeFontface.AddTable(fpgm);
		}
		openTypeFontface.AddTable(glyphDataTable);
		openTypeFontface.AddTable(head);
		openTypeFontface.AddTable(hhea);
		openTypeFontface.AddTable(hmtx);
		openTypeFontface.AddTable(indexToLocationTable);
		if (maxp != null)
		{
			openTypeFontface.AddTable(maxp);
		}
		if (prep != null)
		{
			openTypeFontface.AddTable(prep);
		}
		glyf.CompleteGlyphClosure(glyphs);
		int count = glyphs.Count;
		int[] array = new int[count];
		glyphs.Keys.CopyTo(array, 0);
		Array.Sort(array);
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			num += glyf.GetGlyphSize(array[i]);
		}
		glyphDataTable.DirectoryEntry.Length = num;
		int numGlyphs = maxp.numGlyphs;
		indexToLocationTable.LocaTable = new int[numGlyphs + 1];
		glyphDataTable.GlyphTable = new byte[glyphDataTable.DirectoryEntry.PaddedLength];
		int num2 = 0;
		int num3 = 0;
		for (int j = 0; j < numGlyphs; j++)
		{
			indexToLocationTable.LocaTable[j] = num2;
			if (num3 < count && array[num3] == j)
			{
				num3++;
				byte[] glyphData = glyf.GetGlyphData(j);
				int num4 = glyphData.Length;
				if (num4 > 0)
				{
					Buffer.BlockCopy(glyphData, 0, glyphDataTable.GlyphTable, num2, num4);
					num2 += num4;
				}
			}
		}
		indexToLocationTable.LocaTable[numGlyphs] = num2;
		openTypeFontface.Compile();
		return openTypeFontface;
	}

	private void Compile()
	{
		MemoryStream memoryStream = new MemoryStream();
		OpenTypeFontWriter openTypeFontWriter = new OpenTypeFontWriter(memoryStream);
		int count = TableDictionary.Count;
		int num = _entrySelectors[count];
		_offsetTable.Version = 65536u;
		_offsetTable.TableCount = count;
		_offsetTable.SearchRange = (ushort)((1 << num) * 16);
		_offsetTable.EntrySelector = (ushort)num;
		_offsetTable.RangeShift = (ushort)((count - (1 << num)) * 16);
		_offsetTable.Write(openTypeFontWriter);
		string[] array = new string[count];
		TableDictionary.Keys.CopyTo(array, 0);
		Array.Sort(array, StringComparer.Ordinal);
		int num2 = 12 + 16 * count;
		for (int i = 0; i < count; i++)
		{
			TableDirectoryEntry tableDirectoryEntry = TableDictionary[array[i]];
			if (tableDirectoryEntry.Tag == "glyf" || tableDirectoryEntry.Tag == "loca")
			{
				GetType();
			}
			tableDirectoryEntry.FontTable.PrepareForCompilation();
			tableDirectoryEntry.Offset = num2;
			openTypeFontWriter.Position = num2;
			tableDirectoryEntry.FontTable.Write(openTypeFontWriter);
			int position = openTypeFontWriter.Position;
			num2 = position;
			openTypeFontWriter.Position = 12 + 16 * i;
			tableDirectoryEntry.Write(openTypeFontWriter);
		}
		openTypeFontWriter.Stream.Flush();
		int num3 = (int)openTypeFontWriter.Stream.Length;
		FontSource = XFontSource.CreateCompiledFont(memoryStream.ToArray());
	}

	public int Seek(string tag)
	{
		if (TableDictionary.ContainsKey(tag))
		{
			_pos = TableDictionary[tag].Offset;
			return _pos;
		}
		return -1;
	}

	public int SeekOffset(int offset)
	{
		_pos += offset;
		return _pos;
	}

	public byte ReadByte()
	{
		return _fontSource.Bytes[_pos++];
	}

	public short ReadShort()
	{
		int pos = _pos;
		_pos += 2;
		return (short)((_fontSource.Bytes[pos] << 8) | _fontSource.Bytes[pos + 1]);
	}

	public ushort ReadUShort()
	{
		int pos = _pos;
		_pos += 2;
		return (ushort)((_fontSource.Bytes[pos] << 8) | _fontSource.Bytes[pos + 1]);
	}

	public int ReadLong()
	{
		int pos = _pos;
		_pos += 4;
		return (_fontSource.Bytes[pos] << 24) | (_fontSource.Bytes[pos + 1] << 16) | (_fontSource.Bytes[pos + 2] << 8) | _fontSource.Bytes[pos + 3];
	}

	public uint ReadULong()
	{
		int pos = _pos;
		_pos += 4;
		return (uint)((_fontSource.Bytes[pos] << 24) | (_fontSource.Bytes[pos + 1] << 16) | (_fontSource.Bytes[pos + 2] << 8) | _fontSource.Bytes[pos + 3]);
	}

	public int ReadFixed()
	{
		int pos = _pos;
		_pos += 4;
		return (_fontSource.Bytes[pos] << 24) | (_fontSource.Bytes[pos + 1] << 16) | (_fontSource.Bytes[pos + 2] << 8) | _fontSource.Bytes[pos + 3];
	}

	public short ReadFWord()
	{
		int pos = _pos;
		_pos += 2;
		return (short)((_fontSource.Bytes[pos] << 8) | _fontSource.Bytes[pos + 1]);
	}

	public ushort ReadUFWord()
	{
		int pos = _pos;
		_pos += 2;
		return (ushort)((_fontSource.Bytes[pos] << 8) | _fontSource.Bytes[pos + 1]);
	}

	public long ReadLongDate()
	{
		int pos = _pos;
		_pos += 8;
		byte[] bytes = _fontSource.Bytes;
		return (long)(((ulong)bytes[pos] << 56) | ((ulong)bytes[pos + 1] << 48) | ((ulong)bytes[pos + 2] << 40) | ((ulong)bytes[pos + 3] << 32) | ((ulong)bytes[pos + 4] << 24) | ((ulong)bytes[pos + 5] << 16) | ((ulong)bytes[pos + 6] << 8) | bytes[pos + 7]);
	}

	public string ReadString(int size)
	{
		char[] array = new char[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = (char)_fontSource.Bytes[_pos++];
		}
		return new string(array);
	}

	public byte[] ReadBytes(int size)
	{
		byte[] array = new byte[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = _fontSource.Bytes[_pos++];
		}
		return array;
	}

	public void Read(byte[] buffer)
	{
		Read(buffer, 0, buffer.Length);
	}

	public void Read(byte[] buffer, int offset, int length)
	{
		Buffer.BlockCopy(_fontSource.Bytes, _pos, buffer, offset, length);
		_pos += length;
	}

	public string ReadTag()
	{
		return ReadString(4);
	}
}
