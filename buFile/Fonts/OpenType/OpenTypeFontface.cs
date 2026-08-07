// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OpenTypeFontface
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
internal sealed class OpenTypeFontface
{
  private readonly string _fullFaceName;
  private ulong _checkSum;
  private XFontSource _fontSource;
  internal FontTechnology _fontTechnology;
  internal OpenTypeFontface.OffsetTable _offsetTable;
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
  private static readonly int[] _entrySelectors = new int[31 /*0x1F*/]
  {
    0,
    0,
    1,
    1,
    2,
    2,
    2,
    2,
    3,
    3,
    3,
    3,
    3,
    3,
    3,
    3,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4,
    4
  };
  private int _pos;

  private OpenTypeFontface(OpenTypeFontface fontface)
  {
    this._offsetTable = fontface._offsetTable;
    this._fullFaceName = fontface._fullFaceName;
  }

  public OpenTypeFontface(byte[] data, string faceName)
  {
    this._fullFaceName = faceName;
    int length = data.Length;
    Array.Copy((Array) data, (Array) this.FontSource.Bytes, length);
    this.Read();
  }

  public OpenTypeFontface(XFontSource fontSource)
  {
    this.FontSource = fontSource;
    this.Read();
    this._fullFaceName = this.name.FullFontName;
  }

  public static OpenTypeFontface CetOrCreateFrom(XFontSource fontSource)
  {
    OpenTypeFontface fontface;
    OpenTypeFontface from;
    if (OpenTypeFontfaceCache.TryGetFontface(fontSource.Key, out fontface))
    {
      from = fontface;
    }
    else
    {
      Debug.Assert(fontSource.Fontface != null);
      OpenTypeFontface openTypeFontface = OpenTypeFontfaceCache.AddFontface(fontSource.Fontface);
      Debug.Assert(fontSource.Fontface == openTypeFontface);
      from = openTypeFontface;
    }
    return from;
  }

  public string FullFaceName => this._fullFaceName;

  public ulong CheckSum
  {
    get
    {
      if (this._checkSum == 0UL)
        this._checkSum = FontHelper.CalcChecksum(this.FontSource.Bytes);
      return this._checkSum;
    }
  }

  public XFontSource FontSource
  {
    get => this._fontSource;
    private set
    {
      this._fontSource = value != null ? value : throw new InvalidOperationException("Font cannot be resolved.");
    }
  }

  public bool CanRead => this.FontSource != null;

  public bool CanWrite => this.FontSource == null;

  public void AddTable(OpenTypeFontTable fontTable)
  {
    if (!this.CanWrite)
      throw new InvalidOperationException("Font image cannot be modified.");
    if (fontTable == null)
      throw new ArgumentNullException(nameof (fontTable));
    if (fontTable._fontData == null)
    {
      fontTable._fontData = this;
    }
    else
    {
      Debug.Assert(fontTable._fontData.CanRead);
      fontTable = (OpenTypeFontTable) new IRefFontTable(this, fontTable);
    }
    this.TableDictionary[fontTable.DirectoryEntry.Tag] = fontTable.DirectoryEntry;
    string tag = fontTable.DirectoryEntry.Tag;
    // ISSUE: reference to a compiler-generated method
    switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(tag))
    {
      case 434964004:
        if (!(tag == "GSUB"))
          break;
        this.gsub = fontTable as GlyphSubstitutionTable;
        break;
      case 845761475:
        if (!(tag == "head"))
          break;
        this.head = fontTable as FontHeaderTable;
        break;
      case 907020398:
        if (!(tag == "OS/2"))
          break;
        this.os2 = fontTable as OS2Table;
        break;
      case 1528723513:
        if (!(tag == "glyf"))
          break;
        this.glyf = fontTable as GlyphDataTable;
        break;
      case 2313681479:
        if (!(tag == "post"))
          break;
        this.post = fontTable as PostScriptTable;
        break;
      case 2369371622:
        if (!(tag == "name"))
          break;
        this.name = fontTable as NameTable;
        break;
      case 2535196162:
        if (!(tag == "hmtx"))
          break;
        this.hmtx = fontTable as HorizontalMetricsTable;
        break;
      case 2558566155:
        if (!(tag == "fpgm"))
          break;
        this.fpgm = fontTable as FontProgram;
        break;
      case 3043500476:
        if (!(tag == "cmap"))
          break;
        this.cmap = fontTable as CMapTable;
        break;
      case 3306288315:
        if (!(tag == "hhea"))
          break;
        this.hhea = fontTable as HorizontalHeaderTable;
        break;
      case 3576627490:
        if (!(tag == "prep"))
          break;
        this.prep = fontTable as ControlValueProgram;
        break;
      case 3731619403:
        if (!(tag == "maxp"))
          break;
        this.maxp = fontTable as MaximumProfileTable;
        break;
      case 4046673656:
        if (!(tag == "cvt "))
          break;
        this.cvt = fontTable as ControlValueTable;
        break;
      case 4111303092:
        if (!(tag == "loca"))
          break;
        this.loca = fontTable as IndexToLocationTable;
        break;
    }
  }

  internal void Read()
  {
    try
    {
      uint num = this.ReadULong();
      if (num == 1953784678U)
      {
        this._fontTechnology = FontTechnology.TrueTypeCollection;
        throw new InvalidOperationException("TrueType collection fonts are not yet supported by PDFsharp.");
      }
      this._offsetTable.Version = num;
      this._offsetTable.TableCount = (int) this.ReadUShort();
      this._offsetTable.SearchRange = this.ReadUShort();
      this._offsetTable.EntrySelector = this.ReadUShort();
      this._offsetTable.RangeShift = this.ReadUShort();
      Debug.Assert(this._pos == 12);
      this._fontTechnology = this._offsetTable.Version != 1330926671U ? FontTechnology.TrueTypeOutlines : FontTechnology.PostscriptOutlines;
      for (int index = 0; index < this._offsetTable.TableCount; ++index)
      {
        TableDirectoryEntry tableDirectoryEntry = TableDirectoryEntry.ReadFrom(this);
        this.TableDictionary.Add(tableDirectoryEntry.Tag, tableDirectoryEntry);
      }
      if (this.TableDictionary.ContainsKey("bhed"))
        throw new NotSupportedException("Bitmap fonts are not supported by PDFsharp.");
      if (this.Seek("cmap") != -1)
        this.cmap = new CMapTable(this);
      if (this.Seek("cvt ") != -1)
        this.cvt = new ControlValueTable(this);
      if (this.Seek("fpgm") != -1)
        this.fpgm = new FontProgram(this);
      if (this.Seek("maxp") != -1)
        this.maxp = new MaximumProfileTable(this);
      if (this.Seek("name") != -1)
        this.name = new NameTable(this);
      if (this.Seek("head") != -1)
        this.head = new FontHeaderTable(this);
      if (this.Seek("hhea") != -1)
        this.hhea = new HorizontalHeaderTable(this);
      if (this.Seek("hmtx") != -1)
        this.hmtx = new HorizontalMetricsTable(this);
      if (this.Seek("OS/2") != -1)
        this.os2 = new OS2Table(this);
      if (this.Seek("post") != -1)
        this.post = new PostScriptTable(this);
      if (this.Seek("glyf") != -1)
        this.glyf = new GlyphDataTable(this);
      if (this.Seek("loca") != -1)
        this.loca = new IndexToLocationTable(this);
      if (this.Seek("GSUB") != -1)
        this.gsub = new GlyphSubstitutionTable(this);
      if (this.Seek("prep") == -1)
        return;
      this.prep = new ControlValueProgram(this);
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }

  public OpenTypeFontface CreateFontSubSet(Dictionary<int, object> glyphs, bool cidFont)
  {
    OpenTypeFontface fontSubSet = new OpenTypeFontface(this);
    IndexToLocationTable fontTable1 = new IndexToLocationTable();
    fontTable1.ShortIndex = this.loca.ShortIndex;
    GlyphDataTable fontTable2 = new GlyphDataTable();
    if (!cidFont)
      fontSubSet.AddTable((OpenTypeFontTable) this.cmap);
    if (this.cvt != null)
      fontSubSet.AddTable((OpenTypeFontTable) this.cvt);
    if (this.fpgm != null)
      fontSubSet.AddTable((OpenTypeFontTable) this.fpgm);
    fontSubSet.AddTable((OpenTypeFontTable) fontTable2);
    fontSubSet.AddTable((OpenTypeFontTable) this.head);
    fontSubSet.AddTable((OpenTypeFontTable) this.hhea);
    fontSubSet.AddTable((OpenTypeFontTable) this.hmtx);
    fontSubSet.AddTable((OpenTypeFontTable) fontTable1);
    if (this.maxp != null)
      fontSubSet.AddTable((OpenTypeFontTable) this.maxp);
    if (this.prep != null)
      fontSubSet.AddTable((OpenTypeFontTable) this.prep);
    this.glyf.CompleteGlyphClosure(glyphs);
    int count = glyphs.Count;
    int[] array = new int[count];
    glyphs.Keys.CopyTo(array, 0);
    Array.Sort<int>(array);
    int num = 0;
    for (int index = 0; index < count; ++index)
      num += this.glyf.GetGlyphSize(array[index]);
    fontTable2.DirectoryEntry.Length = num;
    int numGlyphs = (int) this.maxp.numGlyphs;
    fontTable1.LocaTable = new int[numGlyphs + 1];
    fontTable2.GlyphTable = new byte[fontTable2.DirectoryEntry.PaddedLength];
    int dstOffset = 0;
    int index1 = 0;
    for (int glyph = 0; glyph < numGlyphs; ++glyph)
    {
      fontTable1.LocaTable[glyph] = dstOffset;
      if ((index1 >= count ? 0 : (array[index1] == glyph ? 1 : 0)) != 0)
      {
        ++index1;
        byte[] glyphData = this.glyf.GetGlyphData(glyph);
        int length = glyphData.Length;
        if (length > 0)
        {
          Buffer.BlockCopy((Array) glyphData, 0, (Array) fontTable2.GlyphTable, dstOffset, length);
          dstOffset += length;
        }
      }
    }
    fontTable1.LocaTable[numGlyphs] = dstOffset;
    fontSubSet.Compile();
    return fontSubSet;
  }

  private void Compile()
  {
    MemoryStream memoryStream = new MemoryStream();
    OpenTypeFontWriter writer = new OpenTypeFontWriter((Stream) memoryStream);
    int count = this.TableDictionary.Count;
    int entrySelector = OpenTypeFontface._entrySelectors[count];
    this._offsetTable.Version = 65536U /*0x010000*/;
    this._offsetTable.TableCount = count;
    this._offsetTable.SearchRange = (ushort) ((1 << entrySelector) * 16 /*0x10*/);
    this._offsetTable.EntrySelector = (ushort) entrySelector;
    this._offsetTable.RangeShift = (ushort) ((count - (1 << entrySelector)) * 16 /*0x10*/);
    this._offsetTable.Write(writer);
    string[] array = new string[count];
    this.TableDictionary.Keys.CopyTo(array, 0);
    Array.Sort<string>(array, (IComparer<string>) StringComparer.Ordinal);
    int num = 12 + 16 /*0x10*/ * count;
    for (int index = 0; index < count; ++index)
    {
      TableDirectoryEntry table = this.TableDictionary[array[index]];
      if ((table.Tag == "glyf" ? 1 : (table.Tag == "loca" ? 1 : 0)) != 0)
        this.GetType();
      table.FontTable.PrepareForCompilation();
      table.Offset = num;
      writer.Position = num;
      table.FontTable.Write(writer);
      num = writer.Position;
      writer.Position = 12 + 16 /*0x10*/ * index;
      table.Write(writer);
    }
    writer.Stream.Flush();
    int length = (int) writer.Stream.Length;
    this.FontSource = XFontSource.CreateCompiledFont(memoryStream.ToArray());
  }

  public int Position
  {
    get => this._pos;
    set => this._pos = value;
  }

  public int Seek(string tag)
  {
    int num;
    if (this.TableDictionary.ContainsKey(tag))
    {
      this._pos = this.TableDictionary[tag].Offset;
      num = this._pos;
    }
    else
      num = -1;
    return num;
  }

  public int SeekOffset(int offset)
  {
    this._pos += offset;
    return this._pos;
  }

  public byte ReadByte() => this._fontSource.Bytes[this._pos++];

  public short ReadShort()
  {
    int pos = this._pos;
    this._pos += 2;
    return (short) ((int) this._fontSource.Bytes[pos] << 8 | (int) this._fontSource.Bytes[pos + 1]);
  }

  public ushort ReadUShort()
  {
    int pos = this._pos;
    this._pos += 2;
    return (ushort) ((uint) this._fontSource.Bytes[pos] << 8 | (uint) this._fontSource.Bytes[pos + 1]);
  }

  public int ReadLong()
  {
    int pos = this._pos;
    this._pos += 4;
    return (int) this._fontSource.Bytes[pos] << 24 | (int) this._fontSource.Bytes[pos + 1] << 16 /*0x10*/ | (int) this._fontSource.Bytes[pos + 2] << 8 | (int) this._fontSource.Bytes[pos + 3];
  }

  public uint ReadULong()
  {
    int pos = this._pos;
    this._pos += 4;
    return (uint) ((int) this._fontSource.Bytes[pos] << 24 | (int) this._fontSource.Bytes[pos + 1] << 16 /*0x10*/ | (int) this._fontSource.Bytes[pos + 2] << 8) | (uint) this._fontSource.Bytes[pos + 3];
  }

  public int ReadFixed()
  {
    int pos = this._pos;
    this._pos += 4;
    return (int) this._fontSource.Bytes[pos] << 24 | (int) this._fontSource.Bytes[pos + 1] << 16 /*0x10*/ | (int) this._fontSource.Bytes[pos + 2] << 8 | (int) this._fontSource.Bytes[pos + 3];
  }

  public short ReadFWord()
  {
    int pos = this._pos;
    this._pos += 2;
    return (short) ((int) this._fontSource.Bytes[pos] << 8 | (int) this._fontSource.Bytes[pos + 1]);
  }

  public ushort ReadUFWord()
  {
    int pos = this._pos;
    this._pos += 2;
    return (ushort) ((uint) this._fontSource.Bytes[pos] << 8 | (uint) this._fontSource.Bytes[pos + 1]);
  }

  public long ReadLongDate()
  {
    int pos = this._pos;
    this._pos += 8;
    byte[] bytes = this._fontSource.Bytes;
    return (long) bytes[pos] << 56 | (long) bytes[pos + 1] << 48 /*0x30*/ | (long) bytes[pos + 2] << 40 | (long) bytes[pos + 3] << 32 /*0x20*/ | (long) bytes[pos + 4] << 24 | (long) bytes[pos + 5] << 16 /*0x10*/ | (long) bytes[pos + 6] << 8 | (long) bytes[pos + 7];
  }

  public string ReadString(int size)
  {
    char[] chArray = new char[size];
    for (int index = 0; index < size; ++index)
      chArray[index] = (char) this._fontSource.Bytes[this._pos++];
    return new string(chArray);
  }

  public byte[] ReadBytes(int size)
  {
    byte[] numArray = new byte[size];
    for (int index = 0; index < size; ++index)
      numArray[index] = this._fontSource.Bytes[this._pos++];
    return numArray;
  }

  public void Read(byte[] buffer) => this.Read(buffer, 0, buffer.Length);

  public void Read(byte[] buffer, int offset, int length)
  {
    Buffer.BlockCopy((Array) this._fontSource.Bytes, this._pos, (Array) buffer, offset, length);
    this._pos += length;
  }

  public string ReadTag() => this.ReadString(4);

  internal string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "OpenType fontfaces: {0}", (object) this._fullFaceName);
    }
  }

  internal struct OffsetTable
  {
    public uint Version;
    public int TableCount;
    public ushort SearchRange;
    public ushort EntrySelector;
    public ushort RangeShift;

    public void Write(OpenTypeFontWriter writer)
    {
      writer.WriteUInt(this.Version);
      writer.WriteShort(this.TableCount);
      writer.WriteUShort(this.SearchRange);
      writer.WriteUShort(this.EntrySelector);
      writer.WriteUShort(this.RangeShift);
    }
  }
}
