// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.GlyphDataTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class GlyphDataTable : OpenTypeFontTable
{
  public const string Tag = "glyf";
  internal byte[] GlyphTable;
  private const int ARG_1_AND_2_ARE_WORDS = 1;
  private const int WE_HAVE_A_SCALE = 8;
  private const int MORE_COMPONENTS = 32 /*0x20*/;
  private const int WE_HAVE_AN_X_AND_Y_SCALE = 64 /*0x40*/;
  private const int WE_HAVE_A_TWO_BY_TWO = 128 /*0x80*/;

  public GlyphDataTable()
    : base((OpenTypeFontface) null, "glyf")
  {
    this.DirectoryEntry.Tag = "glyf";
  }

  public GlyphDataTable(OpenTypeFontface fontData)
    : base(fontData, "glyf")
  {
    this.DirectoryEntry.Tag = "glyf";
    this.Read();
  }

  public void Read()
  {
    try
    {
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public byte[] GetGlyphData(int glyph)
  {
    int offset = this.GetOffset(glyph);
    int count = this.GetOffset(glyph + 1) - offset;
    byte[] dst = new byte[count];
    Buffer.BlockCopy((Array) this._fontData.FontSource.Bytes, offset, (Array) dst, 0, count);
    return dst;
  }

  public int GetGlyphSize(int glyph) => this.GetOffset(glyph + 1) - this.GetOffset(glyph);

  public int GetOffset(int glyph)
  {
    return this.DirectoryEntry.Offset + this._fontData.loca.LocaTable[glyph];
  }

  public void CompleteGlyphClosure(Dictionary<int, object> glyphs)
  {
    int count = glyphs.Count;
    int[] array = new int[glyphs.Count];
    glyphs.Keys.CopyTo(array, 0);
    if (!glyphs.ContainsKey(0))
      glyphs.Add(0, (object) null);
    for (int index = 0; index < count; ++index)
      this.AddCompositeGlyphs(glyphs, array[index]);
  }

  private void AddCompositeGlyphs(Dictionary<int, object> glyphs, int glyph)
  {
    int offset1 = this.GetOffset(glyph);
    if (offset1 == this.GetOffset(glyph + 1))
      return;
    this._fontData.Position = offset1;
    if (this._fontData.ReadShort() >= (short) 0)
      return;
    this._fontData.SeekOffset(8);
    while (true)
    {
      int num = (int) this._fontData.ReadUFWord();
      int key = (int) this._fontData.ReadUFWord();
      if (!glyphs.ContainsKey(key))
        goto label_11;
label_3:
      if ((num & 32 /*0x20*/) != 0)
      {
        int offset2 = (num & 1) == 0 ? 2 : 4;
        if ((num & 8) != 0)
          offset2 += 2;
        else if ((num & 64 /*0x40*/) != 0)
          offset2 += 4;
        if ((num & 128 /*0x80*/) != 0)
          offset2 += 8;
        this._fontData.SeekOffset(offset2);
        continue;
      }
      break;
label_11:
      glyphs.Add(key, (object) null);
      goto label_3;
    }
  }

  public override void PrepareForCompilation()
  {
    base.PrepareForCompilation();
    if (this.DirectoryEntry.Length == 0)
      this.DirectoryEntry.Length = this.GlyphTable.Length;
    this.DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(this.GlyphTable);
  }

  public override void Write(OpenTypeFontWriter writer)
  {
    writer.Write(this.GlyphTable, 0, this.DirectoryEntry.PaddedLength);
  }
}
